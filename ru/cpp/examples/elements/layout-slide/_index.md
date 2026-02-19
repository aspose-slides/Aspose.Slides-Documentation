---
title: Слайд‑макет
type: docs
weight: 20
url: /ru/cpp/examples/elements/layout-slide/
keywords:
- пример кода
- слайд‑макет
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Основные слайды‑макеты в Aspose.Slides for C++: выбирайте, применяйте и настраивайте макеты слайдов, заполнители и мастеры с примерами на C++ для презентаций PPT, PPTX и ODP."
---
В этой статье демонстрируется, как работать с **Layout Slides** в Aspose.Slides for C++. Слайд‑макет определяет дизайн и форматирование, наследуемое обычными слайдами. Вы можете добавлять, получать доступ, клонировать и удалять слайды‑макеты, а также очищать неиспользуемые, чтобы уменьшить размер презентации.

## **Добавить слайд‑макет**

Вы можете создать пользовательский слайд‑макет для определения переиспользуемого форматирования. Например, можно добавить текстовое поле, которое будет отображаться на всех слайдах, использующих этот макет.

```cpp
static void AddLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto masterSlide = presentation->get_Master(0);

    // Создать слайд‑макет с типом пустого макета и пользовательским именем.
    auto layoutSlide = presentation->get_LayoutSlides()->Add(masterSlide, SlideLayoutType::Blank, u"Main layout");

    // Добавить текстовое поле к слайду‑макету.
    auto layoutTextBox = layoutSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 75, 75, 150, 150);
    layoutTextBox->get_TextFrame()->set_Text(u"Layout Slide Text");

    // Добавить два слайда, используя этот макет; оба унаследуют текст из макета.
    presentation->get_Slides()->AddEmptySlide(layoutSlide);
    presentation->get_Slides()->AddEmptySlide(layoutSlide);

    presentation->Dispose();
}
```

> 💡 **Примечание 1:** Слайды‑макеты служат шаблонами для отдельных слайдов. Вы можете определить общие элементы один раз и переиспользовать их на многих слайдах.

> 💡 **Примечание 2:** Когда вы добавляете фигуры или текст в слайд‑макет, все слайды, основанные на этом макете, автоматически отображают этот общий контент.  
> Ниже показан скриншот двух слайдов, каждый из которых наследует текстовое поле из одного и того же слайда‑макета.

![Слайды, наследующие содержимое макета](layout-slide-result.png)

## **Получить доступ к слайду‑макету**

Слайды‑макеты можно получить по индексу или по типу макета (например, `Blank`, `Title`, `SectionHeader` и т.д.).

```cpp
static void AccessLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Доступ к слайду‑макету по индексу.
    auto firstLayoutSlide = presentation->get_LayoutSlide(0);

    // Доступ к слайду‑макету по типу.
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    presentation->Dispose();
}
```

## **Удалить слайд‑макет**

Вы можете удалить конкретный слайд‑макет, если он больше не нужен.

```cpp
static void RemoveLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Получить слайд‑макет по типу и удалить его.
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
    presentation->get_LayoutSlides()->Remove(blankLayoutSlide);

    presentation->Dispose();
}
```

## **Удалить неиспользуемые слайды‑макеты**

Чтобы уменьшить размер презентации, можно удалить слайды‑макеты, которые не используются ни одним обычным слайдом.

```cpp
static void RemoveUnusedLayoutSlides()
{
    auto presentation = MakeObject<Presentation>();

    // Автоматически удаляет все слайды‑макеты, на которые не ссылается ни один слайд.
    presentation->get_LayoutSlides()->RemoveUnused();

    presentation->Dispose();
}
```

## **Клонировать слайд‑макет**

Вы можете дублировать слайд‑макет с помощью метода `AddClone`.

```cpp
static void CloneLayoutSlides()
{
    auto presentation = MakeObject<Presentation>();

    // Получить существующий слайд-макет по типу.
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    // Клонировать слайд-макет в конец коллекции слайдов-макетов.
    auto clonedLayoutSlide = presentation->get_LayoutSlides()->AddClone(blankLayoutSlide);

    presentation->Dispose();
}
```

> ✅ **Итог:** Слайды‑макеты — это мощный инструмент для обеспечения единого форматирования на всех слайдах. Aspose.Slides предоставляет полный контроль над созданием, управлением и оптимизацией слайдов‑макетов.