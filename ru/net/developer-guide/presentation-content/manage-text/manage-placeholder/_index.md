---
title: Управление заполнителями презентации в .NET
linktitle: Управление заполнителями
type: docs
weight: 10
url: /ru/net/manage-placeholder/
keywords:
- заполнитель
- текстовый заполнитель
- графический заполнитель
- заполнитель диаграммы
- заполнитель содержимого
- текст подсказки
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как просматривать и редактировать текстовые, графические, диаграммные и содержательные заполнители, а также понять наследование заполнителей с помощью Aspose.Slides для .NET."
---
## **Обзор**

Заполнитель — это объект, который резервирует позицию для определённого типа содержимого в шаблоне презентации. Распространённые примеры: заголовок, основной текст, изображение, диаграмма и универсальные заполнители содержимого. В отличие от обычного объекта, заполнитель может наследовать свою позицию, размер, форматирование и другие параметры от слайда‑макета или слайда‑мастера.

Aspose.Slides предоставляет информацию о заполнятеле через свойство [IShape.Placeholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/placeholder/). Это свойство возвращает объект [IPlaceholder](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/) или `null` для обычного объекта. Используйте [IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/) чтобы определить, что заполнитель предназначен хранить.

Интерфейс объекта всё ещё важен после того, как вы узнали тип заполнителя:

- Пустой текстовый, графический, диаграммный или содержательный заполнитель обычно представляется объектом [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).
- Заполненный графический заполнитель может быть представлен объектом [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/).
- Заполненный диаграммный заполнитель может быть представлен объектом [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/).
- Содержательный заполнитель может включать несколько видов содержимого. Проверьте как [IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/), так и интерфейс объекта во время выполнения, вместо того чтобы полагать, что каждый заполнитель является [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/) describes a placeholder's role; it does not guarantee the shape's runtime type. Always use a type check before accessing text, picture, chart, table, or media-specific members.
{{% /alert %}}

## **Понимание наследования заполнителей**

Заполнители образуют иерархию:

1. Слайд‑мастер определяет переиспользуемые стили и, в некоторых случаях, заполнители уровня мастера.
2. Слайд‑макет определяет расположение, используемое одним или несколькими обычными слайдами, и может наследоваться от мастера.
3. Обычный слайд содержит заполнители для этого слайда и может наследоваться от своего макета.

Вызовите [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/getbaseplaceholder/) чтобы переместиться на один уровень выше в этой иерархии. Заполнитель слайда обычно возвращает свой заполнитель‑макет; заполнитель‑макет может вернуть свой заполнитель‑мастер. Метод возвращает `null`, если объект не имеет базового заполнителя.

Следующий пример перечисляет заполнители на первом слайде и выводит их базовые заполнители:

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

Редактирование заполнителя на обычном слайде создаёт или изменяет локальное переопределение для этого слайда. Редактирование связанного макета или мастера может повлиять на все слайды, которые всё ещё наследуют эту настройку. Обычный локальный объект не имеет базового заполнителя и не начинает наследовать просто потому, что занимает те же координаты.

## **Удаление статуса заполнителя**

При адаптации шаблона используйте [IShape.RemovePlaceholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/removeplaceholder/) чтобы оставить существующий объект как обычный объект. Его свойство [Placeholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/placeholder/) становится `null`, но объект остаётся в коллекции слайда. В отличие от этого, [IShapeCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/remove/) удаляет объект из этой коллекции.

Следующий пример требует файл `template.pptx` с минимум одним слайдом и непустым текстовым заполнителем на первом слайде. Используйте заполнитель с форматированием, унаследованным от его макета или мастера, чтобы увидеть эффект удаления этой связи. Пример проверяет, что тот же объект остаётся, вызывает метод снова для теперь обычного объекта и сохраняет результат.

{{% alert color="warning" title="Warning" %}}
Removing placeholder status does not automatically preserve inherited appearance settings. The example below deliberately leaves those settings unchanged, so the output may look different. A shape whose position and size are entirely inherited can have zero coordinates and dimensions after the call and become invisible even though it remains in the collection.
{{% /alert %}}

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
var found = false;

for (var index = 0; index < slide.Shapes.Count; index++)
{
    if (slide.Shapes[index] is not IAutoShape shape || 
        shape.Placeholder == null || 
        string.IsNullOrEmpty(shape.TextFrame?.Text))
    {
        continue;
    }

    var shapeCount = slide.Shapes.Count;
    shape.RemovePlaceholder();

    Console.WriteLine($"Placeholder removed: {shape.Placeholder == null}");
    Console.WriteLine($"Same shape retained: {ReferenceEquals(slide.Shapes[index], shape)}");
    Console.WriteLine($"Shape count unchanged: {slide.Shapes.Count == shapeCount}");

    // Вызов метода на обычном объекте не имеет эффекта.
    shape.RemovePlaceholder();
    found = true;
    break;
}

if (found)
{
    presentation.Save("placeholder-status-removed.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("No nonempty text placeholder was found on the first slide.");
}
```

Для соответствующего заполнителя все три проверки выводят `True`. Текст остаётся, но унаследованные позиция, размер, вращение, шрифт, выравнивание абзаца, отступы текстового фрейма, вертикальная привязка, параметры заливки и линии могут измениться после удаления связи заполнителя. Например, унаследованное форматирование заголовка может вернуться к обычному форматированию текста. Смотрите [Макет слайда](/slides/ru/net/slide-layout/) для более подробной информации о макетах.

Чтобы сохранить ожидаемый внешний вид, зафиксируйте вычисленные позицию, размер и вращение до вызова и скопируйте необходимые значения эффективного форматирования в отдельные переменные. Получите эти значения через [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/), [IParagraphFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/geteffective/), [ITextFrameFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/geteffective/), [IFillFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/geteffective/), и [ILineFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/geteffective/). Не полагайтесь только на объекты эффективного форматирования, так как их значения текстового форматирования могут измениться после удаления связи. Явно примените полученные значения к обычному объекту после этого, включая семейство шрифта, размер, стиль, цвет, параметры абзаца, настройки текстового фрейма, заливку и линию, используемые в вашем шаблоне.

Унаследованную геометрию объекта также может потребоваться задать явно через [IGeometryShape.ShapeType](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/shapetype/). Для прямоугольного текстового заполнителя это означает назначить [ShapeType.Rectangle](https://reference.aspose.com/slides/net/aspose.slides/shapetype/); восстановление только заливки и линии может не восстановить видимый прямоугольник. Шаблоны с дополнительными эффектами или более сложным форматированием требуют также обработки этих настроек.

## **Изменение текста в заполнителе**

Заполнители заголовка, центрированного заголовка, подзаголовка, основного текста и текста обычно поддерживают текст. Проверьте наличие [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) прежде чем использовать его свойство [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/).

В этом примере обновляется первый заполнитель заголовка на первом слайде и сохраняется результат:

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

Этот шаблон избегает приведения заполнителей изображений, диаграмм, таблиц или медиа к типу [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/). Он также определяет заполнитель по назначению, а не полагается на хрупкий индекс объекта.

## **Установка текста подсказки в макете**

Текст подсказки — это инструкция во время проектирования, отображаемая в пустом заполнителе, например *Click to add title*. Установите пользовательский текст подсказки в заполнителе макета, а не пытаясь получить к нему доступ через коллекцию объектов обычного слайда. Доступ к макету можно получить через [ISlide.LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/islide/layoutslide/) и перебирая [ILayoutSlide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/shapes/).

Следующий пример изменяет подсказки заголовка и подзаголовка в макете, используемом первым слайдом:

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

Текст подсказки не является обычным содержимым слайда. Он предназначен для пустых заполнителей в редакторах, таких как PowerPoint. Как только пользователь или программа предоставят реальное содержимое, подсказка перестаёт отображаться. Изменение подсказки также не заменяет существующий текст на слайдах, использующих данный макет.

## **Обновление графического заполнителя**

Существует два случая для обработки:

- Если графический заполнитель уже заполнен и представлен объектом [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/), замените изображение через [IPictureFillFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picture/) и [ISlidesPicture.Image](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/image/).
- Если это всё ещё пустой заполнитель, добавьте графический фрейм в координатах заполнителя с помощью [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addpictureframe/) и удалите пустой заполнитель.

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

Созданная замена для пустого заполнителя представляет собой локальный графический фрейм, а не новый заполнитель, потому что [IShape.Placeholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/placeholder/) только для чтения. Он сохраняет зарезервированную позицию, но более не наследует поведение, специфичное для заполнителя. Если необходимо сохранять связь заполнителя, сначала подготовьте и заполните заполнитель в PowerPoint, а затем обновите полученный [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/) с помощью Aspose.Slides.

Для прозрачности изображения, обрезки и других эффектов, специфичных для изображений, см. [Управление графическими фреймами](/slides/ru/net/picture-frame/). Эти операции относятся к графическому фрейму или заливке изображения, а не к метаданным заполнителя.

## **Работа с заполнителями диаграмм и содержимого**

Заполненный заполнитель диаграммы может быть представлен объектом [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/). Этот пример находит такую диаграмму как по типу заполнителя, так и по интерфейсу во время выполнения, изменяет её заголовок и сохраняет файл:

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

Общий заполнитель содержимого обычно имеет тип [PlaceholderType.Object](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/). В PowerPoint он выступает в качестве запускающего элемента для нескольких типов содержимого, включая диаграммы, таблицы, диаграммы, изображения и медиа. После заполнения проверьте фактический интерфейс объекта, чтобы узнать, что он содержит. Специализированные макеты также могут использовать [PlaceholderType.Chart](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/), или [PlaceholderType.Diagram](https://reference.aspose.com/slides/net/aspose.slides/placeholdertype/).

Aspose.Slides не преобразует пустой заполнитель [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) в [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/) просто изменением [IPlaceholder.Type](https://reference.aspose.com/slides/net/aspose.slides/iplaceholder/type/); тип только для чтения. Чтобы программно заполнить пустую область диаграммы или содержимого, добавьте необходимый объект в координаты заполнителя, а затем удалите пустой заполнитель. Следующий пример делает это для диаграммы:

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

Добавленная диаграмма — обычная локальная диаграмма. Она занимает область заполнителя, но не наследует свойства от заполнителя макета. Используйте специальные статьи по управлению диаграммами [статьи по управлению диаграммами](/slides/ru/net/powerpoint-charts/), когда необходимо заменить её категории, серии или данные книги.

## **Полный пример: обновление текста или изображения**

Следующий сквозной пример открывает шаблон, ищет на первом слайде заполнитель заголовка или изображения, проверяет типы заполнителя и объекта, обновляет соответствующее содержимое и сохраняет результат. Пример специально избегает предположения о индексе объекта или приведения каждого заполнителя к одному интерфейсу.

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

## **Часто задаваемые вопросы**

**Что такое базовый заполнитель?**

Базовый заполнитель — это соответствующий объект на макете или мастере, от которого наследуется другой заполнитель. Используйте [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/net/aspose.slides/ishape/getbaseplaceholder/) чтобы получить его. Обычный локальный объект возвращает `null`, так как он не является частью иерархии заполнителей.

**Могу ли я изменить все заголовки слайдов, редактируя заполнитель макета?**

Вы можете изменить унаследованное форматирование или текст подсказки через макет, но фактическое содержимое заголовка хранится на обычных слайдах. Чтобы заменить реальный текст заголовков во всей презентации, пройдитесь по слайдам и обновите каждый заполнитель заголовка.

**Как управлять заполнителями даты, номера слайда, заголовка и нижнего колонтитула?**

Используйте менеджеры заголовков и нижних колонтитулов на соответствующем уровне слайда, макета, мастера, заметок или листов раздутых. См. [Управление заголовками и нижними колонтитулами презентации](/slides/ru/net/presentation-header-and-footer/) для полных примеров.