# Разработка игровых сервисов
Отчет по лабораторной работе #1 выполнил(а):
- Фалалеев Вадим Эдуардович
- РИ-300012

Отметка о выполнении заданий (заполняется студентом):

| Задание | Выполнение | Баллы |
| ------ | ------ | ------ |
| Задание 1 | * | 100 |
| Задание 2 | * | 100 |
| Задание 3 | * | 100 |

знак "*" - задание выполнено; знак "#" - задание не выполнено;

Работу проверили:
- к.т.н., доцент Денисов Д.В.
- к.э.н., доцент Панов М.А.
- ст. преп., Фадеев В.О.

Структура отчета

- Данные о работе: название работы, фио, группа, выполненные задания.
- Цель работы.
- Задание 1.
- Код реализации выполнения задания. Визуализация результатов выполнения (если применимо).
- Задание 2.
- Код реализации выполнения задания. Визуализация результатов выполнения (если применимо).
- Задание 3.
- Код реализации выполнения задания. Визуализация результатов выполнения (если применимо).
- Выводы.

## Цель работы
ознакомиться с основными функциями Unity и взаимодействием с объектами внутри редактора.

## Задание 1
### В разделе «план работы» пошагово выполнить каждый пункт с описанием и примера реализации задач по теме видео самостоятельной работы.
План работы: 
1) Создать новый проект из шаблона 3D – Core;
2) Проверить, что настроена интеграция редактора Unity и Visual Studio Code
(пункты 8-10 введения);
3) Создать объект Plane;
4) Создать объект Cube;
5) Создать объект Sphere;
6) Установить компонент Sphere Collider для объекта Sphere;
7) Настроить Sphere Collider в роли триггера;
8) Объект куб перекрасить в красный цвет;
9) Добавить кубу симуляцию физики, при это куб не должен проваливаться
под Plane;
10) Написать скрипт, который будет выводить в консоль сообщение о том,
что объект Sphere столкнулся с объектом Cube;
11) При столкновении Cube должен менять свой цвет на зелёный, а при
завершении столкновения обратно на красный.

Ход работы:

- Я создал 3D проект в Unity версии 2022.1.0f1(Я уже работал с Unity, поэтому давно установил его и настроил интеграцию с Visual Studio).

- На сцену проекта добавил 3 объекта: Cube, Sphere и Plane и добавил объекту Cube материал ForCube красного цвета.

![image](https://user-images.githubusercontent.com/54228342/191225646-a308aa11-9da0-4343-a3ab-4428178c7b89.png)

- Объекту Cube добавил компонент Rigidbody и поставил галочку напротив Use Gravity, чтобы объект падал на Plane. Благодаря тому, что в компоненте Box Collider этого же объекта не сотит галочка напротив Is Trigger, объект Cube не будет проваливаться сквозь объект Plane.

![image](https://user-images.githubusercontent.com/54228342/191226600-f4721db7-0103-4cfa-973b-3735bc9f572a.png)

- У объекта Sphere в компоненте Sphere Collider поставил галочку напротив Is Trigger и добавил скрипт Sphere Script.

![image](https://user-images.githubusercontent.com/54228342/191227685-f28686e7-dc78-4d63-a23b-914a25e993aa.png)

- Скрипт выводит сообщение в консоль о том, что объект столкнулся или завершил столкновение с другим объектом.

```c#

using UnityEngine;

public class SphereScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Объект столкнулся с " + other.gameObject.name);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Завершено столкновение с " + other.gameObject.name);
    }
}

```

![image](https://user-images.githubusercontent.com/54228342/191238638-b3bce739-01b2-480a-99bc-80fc7e6991ef.png)

- Немного изменил скрипт: теперь при столкновении объекта Sphere с объектом Cube последний будет менять цвет на зеленый, а при завершении столкновения на красный. Чтобы скрипт работал, добавляю объекту Sphere компонент Rigidbody и ставлю галочку напротив Use Gravity, а в компоненте Sphere Collider убираю галочку напротив Is Trigger.

```c#

private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Cube")
            collision.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Cube")
            collision.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
    }

```

![image](https://user-images.githubusercontent.com/54228342/191239954-1c5c8e94-bca8-4389-9de3-5115ffb9fdd4.png)
![image](https://user-images.githubusercontent.com/54228342/191241750-851e7a47-2fe6-4502-9bc1-28b251816595.png)
![image](https://user-images.githubusercontent.com/54228342/191241779-e2245e12-1420-4518-9d0e-2b443e06bb6e.png)

- Создадим для объекта Plane компонент Rigidbody и поставим галочку напротив Is Kinematic, чтобы объект не падал. Для этого же объекта создадим скрипт Plane Script, который будет уничтожать объект Sphere, если он касается объекта Plane.

![image](https://user-images.githubusercontent.com/54228342/191245544-ab5d2866-6abe-4a9d-9c3e-f705f8500743.png)

```c#

using UnityEngine;

public class PlaneScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Sphere")
            Destroy(collision.gameObject);
    }
}

```

- Далее добавим для объекта Sphere эффект взрыва после уничтожения. Для этого создадим пустой объект Point и добавим ему компоненты Rigidbody без галочек и Sphere Collider, в котором установим радиус, равный радиусу объекта Sphere. Создадим так же пустой объект SpawnSphere, в который добавим несколько объектов Sphere, но уже меньшего размера и распределим их случайно в небольшом расстоянии друг от друга. После всего создадим префабы двух этих объектов и удалим объекты со сцены.

![image](https://user-images.githubusercontent.com/54228342/191322310-844f8125-2ac9-4c81-804c-5acfc74785c0.png)
![image](https://user-images.githubusercontent.com/54228342/191322336-11660053-9519-4c4f-be94-e88a5d96c60e.png)

- Теперь вернемся к скрипту Plane Script, и добавим там несколько строчек.

```c#

using UnityEngine;

public class PlaneScript : MonoBehaviour
{
    [SerializeField] float radius = 5.0f; // Радиус взрыва
    [SerializeField] float force = 10f; // Сила взрыва

    [SerializeField] GameObject prefabPoint; // Используем префаб Point
    [SerializeField] GameObject prefabSpawnSphere; // Используем префаб SpawnSphere

    private void OnCollisionEnter(Collision collision) // Активируется, если один коллайдер касается другого
    {
        if (collision.gameObject.name == "Sphere") // Если объект с именем Sphere...
        {
            Destroy(collision.gameObject); // ... то он уничтожается
            Vector3 boomPosition = collision.gameObject.transform.position; // Координаты центра объекта
            Quaternion boomRotation = collision.gameObject.transform.rotation; // Угол поворота объекта
            Instantiate(prefabPoint, boomPosition, boomRotation);
            Instantiate(prefabSpawnSphere, boomPosition, boomRotation); // Создаются префабы на месте и под тем углом, где уничтожился объект Sphere

            Collider[] colliders = Physics.OverlapSphere(boomPosition, radius); // Создаем массив коллайдеров и записываем в него те, которые находятся
                                                                                // в радиусе места, где уничтожился объект Sphere
            foreach (Collider c in colliders) // Пробегаемся по каждому элементу массива и заставляем их лететь в сторону, обратную точки взрыва(от центра)
            {
                Rigidbody rb = GetComponent<Rigidbody>();
                if (rb != null)
                    rb.AddExplosionForce(force, boomPosition, radius, 3.0f);
            }
        }
    }
}

```

- Остается последний шаг. В инспекторе в скрипт Plane Script вставляем префабы в нужные ячейки.

![image](https://user-images.githubusercontent.com/54228342/191327514-c142ad0f-a384-485d-b4f5-b73e5a667909.png)

## Задание 2
### Продемонстрируйте на сцене в Unity следующее:
1) Что произойдёт с координатами объекта, если он перестанет быть
дочерним?
2) Создайте три различных примера работы компонента RigidBody

Ход работы:

- Все маленькие сферы внутри пустого объекта SpawnSphere являются дочерними. Запустим проект и после взрыва объекта поставим проект на паузу и выберем случайный дочерний объект. Посмотрим на его координаты.

![image](https://user-images.githubusercontent.com/54228342/191469070-f75301f5-f820-49f5-be46-6a09afde364a.png)

- Достанем этот же объект из объекта SpawnSphere. Теперь он не дочерний. Проверяем координаты. Видим, что они изменились.

![image](https://user-images.githubusercontent.com/54228342/191469794-853c22cf-c11d-44f8-9557-07e4bb7ed6db.png)

- Это связано с тем, что у дочерних объектов начало координат находится в точке, где расположен объект-родитель. Убедимся в этом. Сделаем наш объект снова дочерним, поставим ему координаты (0, 0, 0), после чего достанем его из объекта SpawnSphere и сравним его координаты с координатами SpawnSphere.

![image](https://user-images.githubusercontent.com/54228342/191472506-fda69d79-8763-4926-8f48-876182a002ba.png)
![image](https://user-images.githubusercontent.com/54228342/191472547-f803d058-24ac-41d2-86d4-28fc4bb419a8.png)

- Координаты оказались одинаковыми. Теперь поставим для объекта Sphere(14) координаты (0, 0, 0).

![image](https://user-images.githubusercontent.com/54228342/191472845-5f7d810f-e3ce-46ca-b328-f03bcc449e72.png)

- Увидим, что на самой сцене начало координат расположено в другом месте.

- Перейдем к Rigidbody и рассмотрим 3 примера работы этого компонента. Будем использовать объект Sphere для этого опыта. В первом примере мы уберем галочки напротив Use Gravity и Is Kinematic. Тогда объект будет себя вести, как будто он находится в космосе, где нет гравитации. Если его не трогать, то он будет стоять на месте, а если коснуться другим объектом(у которого нет галочки Is Kinematic), то он полетит в обратную сторону. Во втором примере поставим галочку напротив Use Gravity и посмотрим, что будет. Объект сразу же начал падать вниз, так как на него стали действовать силы гравитации. В третьем примере поставим галочку напротив Is Kinematic. Вторую галочку можно оставить, можно убрать - эффект от этого не изменится. Объект будет неподвижно стоять на одной точке и ничего его не сможет столкнуть. На него не будут действовать законы физики.

## Задание 3
### Реализуйте на сцене генерацию n кубиков. Число n вводится пользователем после старта сцены.

Ход работы:

- Для начала создадим панель, на которой будет кнопка и строка ввода.

![image](https://user-images.githubusercontent.com/54228342/191908791-2c077dd0-4993-49d7-b0b2-ff09483c63c7.png)

- Далее сделаем объект Cube префабом и создадим 2 пустых объекта CubePointMax и CubePointMin и дадим им компонент Box Collider. Они будут определять границы той территории, где смогут генерироваться новые объекты. Расставим эти объекты по краям объекта Plane следующим образом:

![image](https://user-images.githubusercontent.com/54228342/191909497-1312f237-4af7-4aec-8187-2ecf12197fd2.png)

- Следующим шагом нужно создать скрипт SpawnCubesScript, который генерирует количество объектов Cube, равное числу, написанному в строке ввода, в заданной области после нажатия кнопки. Сам скрипт прикрепляем к объекту Canvas.

```c#

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnCubesScript : MonoBehaviour
{
    [SerializeField] GameObject panel; // Определяем объект Panel на сцене.
    [SerializeField] InputField Field; // Определяем строку ввода на сцене.
    [SerializeField] GameObject cube; // Определяем объект, который будем генерировать.
    [SerializeField] GameObject cubePointMin; 
    [SerializeField] GameObject cubePointMax; // Определяем объекты, служащие границей для генерации объектов.
    [SerializeField] List<Vector3> spawnPoints = new(); // Определяем список, где будут хранится координаты, куда могут генерироваться объекты.

    public void Awake()
    {
        Time.timeScale = 0; // При запуске проект будет на паузе.
    }

    public void GenerateButton() // Этот метод бдует работать после нажатия кнопки.
    {
        GetPosition();

        panel.SetActive(false); // Закрываем панель.
        Time.timeScale = 1; // Убираем проект с паузы.

        for (int i = 0; i < int.Parse(Field.text); i++)
            Instantiate(cube, spawnPoints[i], cube.transform.rotation); // Генерируем нужно количество объектов.
    }

    private void GetPosition()
    {
        float cubePointMinX = cubePointMin.transform.position.x;
        float cubePointMinZ = cubePointMin.transform.position.z;
        float cubePointMaxX = cubePointMax.transform.position.x;
        float cubePointMaxZ = cubePointMax.transform.position.z; // Записываем координаты Х и Z границ для удобства.

        for (int i = 0; i < int.Parse(Field.text); i++)
        {
            Vector3 newPoint = new(
                Random.Range(cubePointMinX, cubePointMaxX),
                cubePointMax.transform.position.y,
                Random.Range(cubePointMinZ, cubePointMaxZ)); // Определяем точку, куда будем генерировать объект.

            if (!spawnPoints.Contains(newPoint))
                spawnPoints.Add(newPoint);  // Добавляем точку в список, если такой еще нет.
        }
    }
}

```

- Последние действия: в инспекторе добавляем все объекты в последний скрипт. После этого соединяем кнопку с методом GenerateButton().

![image](https://user-images.githubusercontent.com/54228342/191919643-92d4bd8d-8e9a-4451-a52a-5cc60d09bc59.png)
![image](https://user-images.githubusercontent.com/54228342/191919750-1587a6a1-3f07-4a8a-9c67-305f5acbcc48.png)

- Теперь запускаем проект, появляется окно ввода. Введем количество кубиков, например, 9. Нажимаем на кнопку и смотрим на результат(кубиков будет 10, потому что один стоял изначально из прошлого задания).

![image](https://user-images.githubusercontent.com/54228342/191934190-09968ac9-6ec9-4974-87c9-a412b5811cf2.png)
![image](https://user-images.githubusercontent.com/54228342/191934203-dd165106-f210-4b70-a027-248085beedb4.png)

## Выводы
По итогу выполнения первой лабораторной работы я ознакомился с основными функциями Unity и взаимодействием с объектами внутри редактора. Были выполнены все 3 задания. Работал с объекатми, их взаимодействиями и компонентами, материалом, интерфейсом, скриптами. Подробнее изучил компонент Rigidbody, рассмотрев 3 примера работы с ним. Изучал поведение координат у дочерних и простых объектов. Создал генерацию объектов на сцене.
Кроме Unity, работал с GitHub. Создал репозиторий, настроил файлы Readme и gitignore. Настроил интеграцию GitHub и проекта в Unity. 
