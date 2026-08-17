---
title: Управление плейсхолдерами презентации в .NET
linktitle: Управление плейсхолдерами
type: docs
weight: 10
url: /ru/net/manage-placeholder/
keywords:
- плейсхолдер
- текстовый плейсхолдер
- плейсхолдер изображения
- плейсхолдер диаграммы
- плейсхолдер содержимого
- текст подсказки
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как просматривать и редактировать текстовые, графические, диаграммные и содержательные плейсхолдеры, а также понять наследование плейсхолдеров с помощью Aspose.Slides для .NET."
---
## **Обзор**

Плейсхолдер — это фигура, резервирующая позицию для определённого типа контента в шаблоне презентации. Распространённые примеры — заголовок, основной текст, изображение, диаграмма и универсальные плейсхолдеры содержимого. В отличие от обычной фигуры, плейсхолдер может наследовать свою позицию, размер, форматирование и другие параметры от слайда‑макета или слайда‑шаблона.

Aspose.Slides предоставляет информацию о плейсхолдерах через свойство [IShape.Placeholder](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape/placeholder/). Это свойство возвращает объект [IPlaceholder](https://reference.aspose.com/slides/ru/net/aspose.slides/iplaceholder/) либо `null` для обычной фигуры. Используйте [IPlaceholder.Type](https://reference.aspose.com/slides/ru/net/aspose.slides/iplaceholder/type/) для определения того, какой контент ожидается в плейсхолдере.

Тип интерфейса фигуры остаётся важным, даже после того как известен тип плейсхолдера:

- Пустой текстовый, графический, диаграммный или контентный плейсхолдер обычно представляет [IAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/).
- Заполненный графический плейсхолдер может быть представлен [IPictureFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/ipictureframe/).
- Заполненный диаграммный плейсхолдер может быть представлен [IChart](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichart/).
- Контентный плейсхолдер может содержать несколько типов контента. Проверяйте как [IPlaceholder.Type](https://reference.aspose.com/slides/ru/net/aspose.slides/iplaceholder/type/), так и интерфейс фигуры во время выполнения, вместо предположения, что каждый плейсхолдер является [IAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.Type](https://reference.aspose.com/slides/ru/net/aspose.slides/iplaceholder/type/) описывает роль плейсхолдера; он не гарантирует тип фигуры во время выполнения. Всегда проверяйте тип перед доступом к членам, специфичным для текста, изображения, диаграммы, таблицы или медиа.
{{% /alert %}}

## **Понимание наследования плейсхолдеров**

Плейсхолдеры образуют иерархию:

1. Слайд‑шаблон (master) задаёт переиспользуемые стили и, в некоторых случаях, плейсхолдеры уровня шаблона.
2. Слайд‑макет (layout) определяет расположение, используемое одним или несколькими обычными слайдами, и может наследовать от шаблона.
3. Обычный слайд содержит плейсхолдеры для данного слайда и может наследовать от своего макета.

Вызовите [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape/getbaseplaceholder/) для перехода на один уровень выше в этой иерархии. Плейсхолдер слайда обычно возвращает свой плейтсхолдер макета; плейсхолдер макета может вернуть плейтсхолдер шаблона. Метод возвращает `null`, когда у фигуры нет базового плейсхолдера.

Следующий пример выводит список плейсхолдеров на первом слайде и их базовые плейсхолдеры:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = shape.Placeholder.Type;
    var typeName = shape.GetType().Name;
    Console.WriteLine($"Slide placeholder: {placeholderType}; shape interface: {typeName}");

    var layoutPlaceholder = shape.GetBasePlaceholder();
    if (layoutPlaceholder != null)
    {
        var layoutPlaceholderType = layoutPlaceholder.Placeholder?.Type;
        Console.WriteLine($"  Layout placeholder: {layoutPlaceholderType}");

        var masterPlaceholder = layoutPlaceholder.GetBasePlaceholder();
        if (masterPlaceholder != null)
        {
            var masterPlaceholderType = masterPlaceholder.Placeholder?.Type;
            Console.WriteLine($"  Master placeholder: {masterPlaceholderType}");
        }
    }
}
```

Редактирование плейсхолдера на обычном слайде создаёт или изменяет локальное переопределение для этого слайда. Редактирование соответствующего макета или шаблона может повлиять на все слайды, которые всё ещё наследуют эти настройки. Обычная локальная фигура не имеет базового плейсхолдера и не начинает наследовать просто потому, что занимает те же координаты.

## **Изменение текста в плейсхолдере**

Плейсхолдеры заголовка, центрированного заголовка, подзаголовка, тела и текста обычно поддерживают текст. Проверьте, является ли фигура [IAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/), перед использованием её свойства [TextFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/textframe/).

Этот пример обновляет первый заголовочный плейсхолдер на первом слайде и сохраняет результат:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
IAutoShape? titleShape = null;

foreach (var shape in slide.Shapes)
{
    if (shape is not IAutoShape autoShape || autoShape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = autoShape.Placeholder.Type;
    if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle)
    {
        titleShape = autoShape;
        break;
    }
}

if (titleShape == null)
{
    throw new InvalidOperationException("The first slide does not contain a title placeholder.");
}

titleShape.TextFrame.Text = "Quarterly Business Review";
presentation.Save("title-placeholder-updated.pptx", SaveFormat.Pptx);
```

Такой подход избегает приведения графических, диаграммных, табличных или медиа‑плейсхолдеров к [IAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/). Он также идентифицирует плейсхолдер по назначению, а не полагается на хрупкий индекс фигуры.

## **Установка текста подсказки в макете**

Текст подсказки — это инструктивный текст, отображаемый в пустом плейсхолдере во время проектирования, например *Щёлкните, чтобы добавить заголовок*. Устанавливайте пользовательский текст подсказки в плейсхолдере макета, а не через коллекцию фигур обычного слайда. Получите доступ к макету через [ISlide.LayoutSlide](https://reference.aspose.com/slides/ru/net/aspose.slides/islide/layoutslide/) и пройдитесь по [ILayoutSlide.Shapes](https://reference.aspose.com/slides/ru/net/aspose.slides/ibaseslide/shapes/).

Следующий пример меняет подсказки заголовка и подзаголовка в макете, используемом первым слайдом:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var layoutSlide = presentation.Slides[0].LayoutSlide;

foreach (var shape in layoutSlide.Shapes)
{
    if (shape is not IAutoShape autoShape || autoShape.Placeholder == null)
    {
        continue;
    }

    switch (autoShape.Placeholder.Type)
    {
        case PlaceholderType.Title:
        case PlaceholderType.CenteredTitle:
            autoShape.TextFrame.Text = "Enter a concise slide title";
            break;
        case PlaceholderType.Subtitle:
            autoShape.TextFrame.Text = "Enter a subtitle or reporting period";
            break;
    }
}

presentation.Save("custom-placeholder-prompts.pptx", SaveFormat.Pptx);
```

Текст подсказки не является обычным содержимым слайда. Он предназначен для пустых плейсхолдеров в редакторах, таких как PowerPoint. Как только пользователь или программа задаёт реальный контент, подсказка более не отображается. Изменение подсказки также не заменяет существующий текст на слайдах, использующих данный макет.

## **Обновление плейсхолдера изображения**

Существует два варианта обработки:

- Если графический плейсхолдер уже заполнен и представлен [IPictureFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/ipictureframe/), замените изображение через [IPictureFillFormat.Picture](https://reference.aspose.com/slides/ru/net/aspose.slides/ipicturefillformat/picture/) и [ISlidesPicture.Image](https://reference.aspose.com/slides/ru/net/aspose.slides/islidespicture/image/).
- Если это всё ещё пустой плейсхолдер, добавьте графический кадр в координатах плейсхолдера с помощью [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/ishapecollection/addpictureframe/) и удалите пустой плейсхолдер.

Следующий пример поддерживает оба случая и сохраняет презентацию:

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("picture-template.pptx");
var slide = presentation.Slides[0];
IShape? picturePlaceholder = null;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder?.Type == PlaceholderType.Picture)
    {
        picturePlaceholder = shape;
        break;
    }
}

if (picturePlaceholder == null)
{
    throw new InvalidOperationException("The first slide does not contain a picture placeholder.");
}

var imageBytes = File.ReadAllBytes("replacement.png");
var image = presentation.Images.AddImage(imageBytes);

if (picturePlaceholder is IPictureFrame pictureFrame)
{
    pictureFrame.PictureFormat.Picture.Image = image;
}
else
{
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, picturePlaceholder.X, picturePlaceholder.Y, picturePlaceholder.Width, picturePlaceholder.Height, image);
    slide.Shapes.Remove(picturePlaceholder);
}

presentation.Save("picture-placeholder-updated.pptx", SaveFormat.Pptx);
```

Созданная замена для пустого плейсхолдера является локальным графическим кадром, а не новым плейсхолдером, поскольку [IShape.Placeholder](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape/placeholder/) только для чтения. Она сохраняет зарезервированную позицию, но больше не наследует поведение, специфичное для плейсхолдера. Если сохранение связи с плейсхолдером критично, подготовьте и заполните плейсхолдер в PowerPoint сначала, а затем обновите полученный [IPictureFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/ipictureframe/) с помощью Aspose.Slides.

Для прозрачности изображения, обрезки и других эффектов, специфичных для изображений, см. раздел [Manage Picture Frames](/slides/ru/net/picture-frame/). Эти операции относятся к графическому кадру или заливке изображения, а не к метаданным плейсхолдера.

## **Работа с плейсхолдерами диаграмм и содержимого**

Заполненный плейсхолдер диаграммы может быть представлен [IChart](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichart/). Этот пример находит такую диаграмму по типу плейсхолдера и интерфейсу во время выполнения, меняет её заголовок и сохраняет файл:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("chart-template.pptx");
var slide = presentation.Slides[0];
IChart? placeholderChart = null;

foreach (var shape in slide.Shapes)
{
    if (shape is IChart chart && shape.Placeholder?.Type == PlaceholderType.Chart)
    {
        placeholderChart = chart;
        break;
    }
}

if (placeholderChart == null)
{
    throw new InvalidOperationException("The first slide does not contain a populated chart placeholder.");
}

placeholderChart.HasTitle = true;
placeholderChart.ChartTitle.AddTextFrameForOverriding("Quarterly Revenue");
presentation.Save("chart-placeholder-updated.pptx", SaveFormat.Pptx);
```

Общий плейсхолдер содержимого обычно имеет тип [PlaceholderType.Object](https://reference.aspose.com/slides/ru/net/aspose.slides/placeholdertype/). В PowerPoint он выступает в роли контейнера для разных типов контента: диаграмм, таблиц, схем, изображений и медиа. После заполнения проанализируйте реальный интерфейс фигуры, чтобы узнать, что она содержит. Специальные макеты могут также использовать [PlaceholderType.Chart](https://reference.aspose.com/slides/ru/net/aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/ru/net/aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/ru/net/aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/ru/net/aspose.slides/placeholdertype/), либо [PlaceholderType.Diagram](https://reference.aspose.com/slides/ru/net/aspose.slides/placeholdertype/).

Aspose.Slides не преобразует пустой плейсхолдер [IAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/) в [IChart](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichart/) простым изменением [IPlaceholder.Type](https://reference.aspose.com/slides/ru/net/aspose.slides/iplaceholder/type/); тип только для чтения. Чтобы программно заполнить пустую диаграмму или область содержимого, добавьте необходимый объект в координаты плейсхолдера и затем удалите пустой плейсхолдер. Следующий пример делает это для диаграммы:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("content-template.pptx");
var slide = presentation.Slides[0];
IShape? targetPlaceholder = null;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder?.Type is PlaceholderType.Chart or PlaceholderType.Object)
    {
        targetPlaceholder = shape;
        break;
    }
}

if (targetPlaceholder == null)
{
    throw new InvalidOperationException("The first slide does not contain a chart or content placeholder.");
}

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, targetPlaceholder.X, targetPlaceholder.Y, targetPlaceholder.Width, targetPlaceholder.Height);
chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("Quarterly Revenue");
slide.Shapes.Remove(targetPlaceholder);
presentation.Save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx);
```

Добавленная диаграмма — обычная локальная диаграмма. Она занимает область плейсхолдера, но не наследует свойства от макетного плейсхолдера. При необходимости заменить категории, серии или данные книги используйте специализированные статьи по управлению [диаграммами](/slides/ru/net/powerpoint-charts/).

## **Полный пример: обновление текста или изображения**

Следующий сквозной пример открывает шаблон, ищет на первом слайде заголовочный или графический плейсхолдер, проверяет типы плейсхолдера и фигуры, обновляет соответствующий контент и сохраняет результат. Пример намеренно избегает предположений о индексе фигуры или приведения всех плейсхолдеров к одному интерфейсу.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
var updated = false;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = shape.Placeholder.Type;

    if ((placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) && shape is IAutoShape titleShape)
    {
        titleShape.TextFrame.Text = "Quarterly Business Review";
        updated = true;
        break;
    }

    if (placeholderType == PlaceholderType.Picture)
    {
        var imageBytes = File.ReadAllBytes("replacement.png");
        var image = presentation.Images.AddImage(imageBytes);

        if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.PictureFormat.Picture.Image = image;
        }
        else
        {
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, shape.X, shape.Y, shape.Width, shape.Height, image);
            slide.Shapes.Remove(shape);
        }

        updated = true;
        break;
    }
}

if (!updated)
{
    throw new InvalidOperationException("No supported title or picture placeholder was found on the first slide.");
}

presentation.Save("placeholder-content-updated.pptx", SaveFormat.Pptx);
```

## **Вопросы и ответы**

**Что такое базовый плейсхолдер?**

Базовый плейсхолдер — это соответствующая фигура на макете или шаблоне, от которой наследуется другой плейсхолдер. Используйте [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape/getbaseplaceholder/) для его получения. Обычная локальная фигура возвращает `null`, потому что она не входит в иерархию плейсхолдеров.

**Можно ли изменить все заголовки слайдов, отредактировав плейсхолдер макета?**

Можно изменить наследуемое форматирование или текст подсказки через макет, но фактическое содержимое заголовков хранится в обычных слайдах. Чтобы заменить реальный текст заголовков во всей презентации, пройдитесь по слайдам и обновите каждый заголовочный плейсхолдер.

**Как управлять плейсхолдерами даты, номера слайда, верхнего и нижнего колонтитулов?**

Используйте менеджеры верхних и нижних колонтитулов на соответствующем уровне: слайд, макет, шаблон, заметки или раздача. См. раздел [Manage Presentation Header and Footer](/slides/ru/net/presentation-header-and-footer/) для полноценных примеров.