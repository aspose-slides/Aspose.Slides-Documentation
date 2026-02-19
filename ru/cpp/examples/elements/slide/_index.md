---
title: Слайд
type: docs
weight: 10
url: /ru/cpp/examples/elements/slide/
keywords:
- пример кода
- слайд
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Управляйте слайдами в Aspose.Slides for C++: создавайте, клонируйте, переупорядочьте, изменяйте размер, задавайте фон и применяйте переходы с помощью C++ для презентаций PPT, PPTX и ODP."
---
Эта статья содержит набор примеров, демонстрирующих работу со слайдами с помощью **Aspose.Slides for C++**. Вы узнаете, как добавлять, получать доступ, клонировать, перемещать и удалять слайды с использованием класса `Presentation`.

Каждый пример ниже включает краткое пояснение и фрагмент кода на C++.

## **Add a Slide**

Чтобы добавить новый слайд, сначала необходимо выбрать макет. В этом примере мы используем макет `Blank` и добавляем пустой слайд в презентацию.

```cpp
static void AddSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    presentation->get_Slides()->AddEmptySlide(blankLayout);

    presentation->Dispose();
}
```

> 💡 **Note:** Каждый макет слайда наследуется от мастер‑слайда, который определяет общий дизайн и структуру заполнителей. Ниже изображение, показывающее, как организованы мастер‑слайды и их связанные макеты в PowerPoint.

![Связь мастера и макета](master-layout-slide.png)

## **Access Slides by Index**

Вы можете получать доступ к слайдам по их индексу или находить индекс слайда по ссылке. Это удобно для перебора или изменения конкретных слайдов.

```cpp
static void AccessSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Добавьте еще один пустой слайд.
    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
    presentation->get_Slides()->AddEmptySlide(blankLayout);

    // Доступ к слайдам по индексу.
    auto firstSlide = presentation->get_Slide(0);
    auto secondSlide = presentation->get_Slide(1);

    // Получить индекс слайда из ссылки, затем получить доступ к нему по индексу.
    auto secondSlideIndex = presentation->get_Slides()->IndexOf(secondSlide);
    auto secondSlideByIndex = presentation->get_Slide(secondSlideIndex);

    presentation->Dispose();
}
```

## **Clone a Slide**

Этот пример демонстрирует, как клонировать существующий слайд. Клонированный слайд автоматически добавляется в конец коллекции слайдов.

```cpp
static void CloneSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto firstSlide = presentation->get_Slide(0);

    auto clonedSlide = presentation->get_Slides()->AddClone(firstSlide);

    auto clonedSlideIndex = presentation->get_Slides()->IndexOf(clonedSlide);

    presentation->Dispose();
}
```

## **Reorder Slides**

Вы можете изменить порядок слайдов, переместив один из них на новый индекс. В данном случае мы перемещаем клонированный слайд в первую позицию.

```cpp
static void ReorderSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto firstSlide = presentation->get_Slide(0);

    auto clonedSlide = presentation->get_Slides()->AddClone(firstSlide);

    presentation->get_Slides()->Reorder(0, clonedSlide);

    presentation->Dispose();
}
```

## **Remove a Slide**

Чтобы удалить слайд, просто укажите его и вызовите `Remove`. В этом примере добавляется второй слайд, а затем удаляется оригинальный, остаётся только новый.

```cpp
static void RemoveSlide()
{
    auto presentation = MakeObject<Presentation>();

    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
    auto secondSlide = presentation->get_Slides()->AddEmptySlide(blankLayout);

    auto firstSlide = presentation->get_Slide(0);
    presentation->get_Slides()->Remove(firstSlide);

    presentation->Dispose();
}
```