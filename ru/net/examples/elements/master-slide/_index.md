---
title: Главный слайд
type: docs
weight: 30
url: /ru/net/examples/elements/master-slide/
keywords:
- главный слайд
- добавить главный слайд
- доступ к главному слайду
- удалить главный слайд
- неиспользуемый главный слайд
- пример кода
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Изучите примеры главных слайдов Aspose.Slides для .NET: создавайте, редактируйте и оформляйте главные слайды, заполнители и темы в PPT, PPTX и ODP с понятным кодом C#."
---
Главные слайды формируют верхний уровень иерархии наследования слайдов в PowerPoint. **Главный слайд** определяет общие элементы дизайна, такие как фоны, логотипы и форматирование текста. **Слайды‑макета** наследуются от главных слайдов, а **обычные слайды** наследуются от слайдов‑макета.

Эта статья демонстрирует, как создавать, изменять и управлять главными слайдами с помощью Aspose.Slides for .NET.

## **Добавить главный слайд**

В этом примере показано, как создать новый главный слайд, клонировав стандартный. Затем он добавляет баннер с названием компании ко всем слайдам через наследование макета.

```csharp
static void AddMasterSlide()
{
    using var presentation = new Presentation();

    // Клонировать стандартный главный слайд.
    var defaultMasterSlide = presentation.Masters[0];
    var newMasterSlide = presentation.Masters.AddClone(defaultMasterSlide);

    // Добавить баннер с названием компании в верхнюю часть главного слайда.
    var textBox = newMasterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 0, y: 0, width: 720, height: 25);
    textBox.TextFrame.Text = "Company Name";
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    textBox.FillFormat.FillType = FillType.NoFill;

    // Назначить новый главный слайд слайду‑макету.
    var layoutSlide = presentation.LayoutSlides[0];
    layoutSlide.MasterSlide = newMasterSlide;

    // Назначить слайд‑макет первым слайдом в презентации.
    presentation.Slides[0].LayoutSlide = layoutSlide;
}
```

> 💡 **Примечание 1:** Главные слайды позволяют применять единый брендинг или общие элементы дизайна ко всем слайдам. Любые изменения, внесённые в главный слайд, автоматически отражаются на зависимых слайдах‑макете и обычных слайдах.  
> 
> 💡 **Примечание 2:** Любые фигуры или форматирование, добавленные в главный слайд, наследуются слайдами‑макетами и, в свою очередь, всеми обычными слайдами, использующими эти макеты.  
> 
> Ниже изображение иллюстрирует, как текстовое поле, добавленное в главный слайд, автоматически отображается на конечном слайде.

![Пример наследования главного слайда](master-slide-banner.png)

## **Доступ к главному слайду**

Вы можете получить доступ к главным слайдам, используя коллекцию `Presentation.Masters`. Ниже показано, как извлекать их и работать с ними:

```csharp
static void AccessMasterSlide()
{
    using var presentation = new Presentation();

    // Получить первый главный слайд.
    var firstMasterSlide = presentation.Masters[0];

    // Изменить тип фона.
    firstMasterSlide.Background.Type = BackgroundType.OwnBackground;
}
```

## **Удалить главный слайд**

Главные слайды можно удалить по индексу или по ссылке.

```csharp
static void RemoveMasterSlide()
{
    using var presentation = new Presentation("sample.pptx");

    // Удалить главный слайд по индексу.
    presentation.Masters.RemoveAt(0);

    // Удалить главный слайд по ссылке.
    var firstMasterSlide = presentation.Masters[0];
    presentation.Masters.Remove(firstMasterSlide);
}
```

## **Удалить неиспользуемые главные слайды**

Некоторые презентации содержат главные слайды, которые не используются. Удаление этих слайдов может помочь уменьшить размер файла.

```csharp
static void RemoveUnusedMasterSlide()
{
    using var presentation = new Presentation();

    // Удалить все неиспользуемые главные слайды (в том числе помеченные как Preserve).
    presentation.Masters.RemoveUnused(ignorePreserveField: true);
}
```