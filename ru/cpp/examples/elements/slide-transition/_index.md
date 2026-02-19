---
title: Переход слайда
type: docs
weight: 110
url: /ru/cpp/examples/elements/slide-transition/
keywords:
- пример кода
- переход слайда
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Освойте переходы слайдов в Aspose.Slides для C++: добавляйте, настраивайте и упорядочивайте эффекты и длительности с примерами C++ для презентаций PPT, PPTX и ODP."
---
Эта статья демонстрирует применение эффектов переходов слайдов и таймингов с помощью **Aspose.Slides for C++**.

## **Добавить переход слайда**

Примените эффект плавного перехода к первому слайду.

```cpp
static void AddSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    // Применить плавный переход.
    slide->get_SlideShowTransition()->set_Type(TransitionType::Fade);

    presentation->Dispose();
}
```

## **Получить доступ к переходу слайда**

Прочитайте тип перехода, текущий назначенный слайду.

```cpp
static void AccessSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_Type(TransitionType::Push);

    // Доступ к типу перехода.
    auto type = slide->get_SlideShowTransition()->get_Type();

    presentation->Dispose();
}
```

## **Удалить переход слайда**

Удалите любой эффект перехода, установив тип в `None`.

```cpp
static void RemoveSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_Type(TransitionType::Fade);

    // Удалить переход, установив None.
    slide->get_SlideShowTransition()->set_Type(TransitionType::None);

    presentation->Dispose();
}
```

## **Установить длительность перехода**

Укажите, как долго слайд отображается перед автоматическим перемещением вперед.

```cpp
static void SetTransitionDuration()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_AdvanceOnClick(true);
    slide->get_SlideShowTransition()->set_AdvanceAfterTime(2000); // В миллисекундах.

    presentation->Dispose();
}
```