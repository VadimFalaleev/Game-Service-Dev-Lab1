# Разработка игровых сервисов
Отчет по лабораторной работе #1 выполнил(а):
- Фалалеев Вадим Эдуардович
- РИ-300012

Отметка о выполнении заданий (заполняется студентом):

| Задание | Выполнение | Баллы |
| ------ | ------ | ------ |
| Задание 1 | * | 60 |
| Задание 2 | * | 20 |
| Задание 3 | * | 20 |

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

- На сцену проекта добавил 3 объекта: Cube, Sphere и Plane и добавил объекту Cube материал "ForCube" красного цвета.

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

- Немного измменил скрипт: теперь при столкновении объекта Sphere с объектом Cube последний будет менять цвет на зеленый, а при завершении столкновения на красный. Чтобы скрипт работал, добавляю объекту Sphere компонент Rigidbody и ставлю галочку напротив Use Gravity, а в компоненте Sphere Collider убираю галочку напротив Is Trigger.

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

## Задание 2
### Продемонстрируйте на сцене в Unity следующее:
- Что произойдёт с координатами объекта, если он перестанет быть
дочерним?
- Создайте три различных примера работы компонента RigidBody?



## Задание 3
### Реализуйте на сцене генерацию n кубиков. Число n вводится пользователем после старта сцены.



## Выводы

Абзац умных слов о том, что было сделано и что было узнано.

| Plugin | README |
| ------ | ------ |
| Dropbox | [plugins/dropbox/README.md][PlDb] |
| GitHub | [plugins/github/README.md][PlGh] |
| Google Drive | [plugins/googledrive/README.md][PlGd] |
| OneDrive | [plugins/onedrive/README.md][PlOd] |
| Medium | [plugins/medium/README.md][PlMe] |
| Google Analytics | [plugins/googleanalytics/README.md][PlGa] |
