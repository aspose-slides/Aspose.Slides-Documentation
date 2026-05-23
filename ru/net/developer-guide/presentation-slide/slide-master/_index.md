---
title: Управление слайд‑мастерами презентации в .NET
linktitle: Слайд‑мастер
type: docs
weight: 80
url: /ru/net/slide-master/
keywords:
- слайд‑мастер
- мастер‑слайд
- PPT мастер‑слайд
- несколько мастер‑слайдов
- сравнение мастер‑слайдов
- фон
- заполнитель
- клонирование мастер‑слайда
- копирование мастер‑слайда
- дублирование мастер‑слайда
- неиспользуемый мастер‑слайд
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Управление слайд‑мастерами в Aspose.Slides для .NET: доступ, редактирование, клонирование, сравнение и удаление мастер‑слайдов в презентациях PowerPoint и OpenDocument."
---
## **Обзор**

**Слайд‑мастер** определяет общие настройки дизайна для группы слайдов. Он может содержать общие фигуры, логотипы, фоны, стили текста, параметры темы и настройки нижних колонтитулов. В PowerPoint редактирование слайд‑мастера — обычный способ поддерживать презентацию в едином стиле без повторения одинакового форматирования на каждом слайде.

Aspose.Slides for .NET поддерживает ту же модель. Презентация может содержать один или несколько слайд‑мастеров, каждый из которых может включать несколько макетных слайдов. Обычные слайды обычно не ссылаются непосредственно на слайд‑мастер. Вместо этого обычный слайд использует макетный слайд, который принадлежит слайд‑мастеру.

Иерархия выглядит так:

1. **Slide master** – определяет общий дизайн и тему.  
1. **Layout slide** – определяет конкретное расположение заполнителей и форматирование уровня макета.  
1. **Normal slide** – содержит фактическое содержимое презентации и использует один макетный слайд.

![Иерархия слайд‑мастеров, макетных слайдов и обычных слайдов](slide-master_2.jpg)

В Aspose.Slides слайд‑мастер представлен интерфейсом [IMasterSlide](https://reference.aspose.com/slides/ru/net/aspose.slides/imasterslide/). Все слайд‑мастера в презентации доступны через коллекцию [Presentation.Masters](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/masters/), реализующую [IMasterSlideCollection](https://reference.aspose.com/slides/ru/net/aspose.slides/imasterslidecollection/).

{{% alert color="info" title="Inheritance" %}}
Когда одно и то же свойство определено на нескольких уровнях, более конкретный уровень имеет приоритет. Например, если слайд‑мастер и макетный слайд оба определяют фон, слайды, основанные на этом макете, используют фон макетного слайда. Для получения дополнительной информации о макетных слайдах см. [Apply or Change Slide Layouts](/slides/ru/net/slide-layout/).
{{% /alert %}}

## **Access Slide Masters**

В PowerPoint вы можете открыть представление слайд‑мастера через **View** > **Slide Master**.

![Команда Slide Master на вкладке View в PowerPoint](slide-master_3.jpg)

В Aspose.Slides используйте коллекцию `Masters` для доступа к слайд‑мастерам:

```csharp
using var presentation = new Presentation("presentation.pptx");

var firstMasterSlide = presentation.Masters[0];
var masterSlideCount = presentation.Masters.Count;
var firstMasterLayoutSlideCount = firstMasterSlide.LayoutSlides.Count;

Console.WriteLine("Master slides: " + masterSlideCount);
Console.WriteLine("Layouts in the first master: " + firstMasterLayoutSlideCount);
```

Также можно получить слайд‑мастер, используемый обычным слайдом, через его макет:

```csharp
using var presentation = new Presentation("presentation.pptx");

var slide = presentation.Slides[0];
var layoutSlide = slide.LayoutSlide;
var masterSlide = layoutSlide.MasterSlide;
var masterSlideName = masterSlide.Name;

Console.WriteLine(masterSlideName);
```

## **What a Slide Master Contains**

Слайд‑мастер — это объект, похожий на слайд. Он реализует [IBaseSlide](https://reference.aspose.com/slides/ru/net/aspose.slides/ibaseslide/), поэтому предоставляет многие те же свойства слайдов, что и обычные и макетные слайды. Члены, специфичные для мастера, перечислены на странице API [IMasterSlide](https://reference.aspose.com/slides/ru/net/aspose.slides/imasterslide/).

Часто используемые члены слайд‑мастера включают:

| Member | Purpose |
| --- | --- |
| `Background` | Устанавливает фон уровня мастера. |
| `Shapes` | Сохраняет фигуры, размещённые на мастере, такие как логотипы, рамки изображений и общий текст. |
| `LayoutSlides` | Содержит макетные слайды, принадлежащие мастеру. |
| `ThemeManager` | Предоставляет доступ к API темы мастера. |
| `HeaderFooterManager` | Управляет заголовками, нижними колонтитулами, датами и номерами слайдов для мастера и его дочерних макетов. |
| `GetDependingSlides` | Возвращает обычные слайды, зависящие от мастера через их макеты. |

## **Add an Image to a Slide Master**

Когда вы добавляете изображение в слайд‑мастер, оно появляется на слайдах, использующих макеты этого мастера. Это удобно для логотипов, водяных знаков, декоративных полос и других повторяющихся визуальных элементов.

Следующий пример добавляет логотип на первый слайд‑мастер:

```csharp
using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var logoBytes = File.ReadAllBytes("logo.png");
var logoImage = presentation.Images.AddImage(logoBytes);

masterSlide.Shapes.AddPictureFrame(
    ShapeType.Rectangle,
    x: 20,
    y: 20,
    width: 80,
    height: 80,
    image: logoImage);

presentation.Save("presentation-with-logo.pptx", SaveFormat.Pptx);
```

Для получения более подробной информации о рамках изображений см. [Picture Frame](/slides/ru/net/picture-frame/).

## **Work with Placeholders**

Заполнители обычно определяются на макетных слайдах. Слайд‑мастер предоставляет общий стиль и тему, которые наследуют эти макеты, а каждый макет решает, какие заполнители доступны и где они расположены.

В PowerPoint команды заполнителей доступны в представлении слайд‑мастера.

![Команда Insert Placeholder в представлении Slide Master PowerPoint](slide-master_5.png)

Чтобы добавить новые заполнители с помощью Aspose.Slides, работайте с макетным слайдом, принадлежащим мастеру:

```csharp
using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var blankLayoutSlide =
    masterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank) ??
    masterSlide.LayoutSlides.Add(SlideLayoutType.Blank, "Blank");

blankLayoutSlide.PlaceholderManager.AddTextPlaceholder(
    x: 60,
    y: 120,
    width: 600,
    height: 80);

presentation.Slides.AddEmptySlide(blankLayoutSlide);
presentation.Save("presentation-with-placeholder.pptx", SaveFormat.Pptx);
```

Вы также можете форматировать уже существующие фигуры‑заполнители на слайд‑мастере. Следующий пример находит заполнитель заголовка и применяет линейный градиентный залив:

```csharp
using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var titlePlaceholder = FindPlaceholder(masterSlide, PlaceholderType.Title);

if (titlePlaceholder != null)
{
    var redGradientColor = Color.FromArgb(255, 0, 0);
    var purpleGradientColor = Color.FromArgb(128, 0, 128);

    titlePlaceholder.FillFormat.FillType = FillType.Gradient;
    titlePlaceholder.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
    titlePlaceholder.FillFormat.GradientFormat.GradientStops.Add(0, redGradientColor);
    titlePlaceholder.FillFormat.GradientFormat.GradientStops.Add(255, purpleGradientColor);
}

presentation.Save("presentation-title-style.pptx", SaveFormat.Pptx);

static IAutoShape? FindPlaceholder(IMasterSlide masterSlide, PlaceholderType placeholderType)
{
    foreach (var shape in masterSlide.Shapes)
    {
        if (shape is IAutoShape { Placeholder: not null } autoShape &&
            autoShape.Placeholder.Type == placeholderType)
        {
            return autoShape;
        }
    }

    return null;
}
```

![Отформатированный заголовок‑заполнитель, унаследованный обычными слайдами](slide-master_8.png)

Для получения дополнительных вариантов форматирования заполнителей и текста см. [Set Prompt Text in Placeholder](/slides/ru/net/manage-placeholder/) и [Text Formatting](/slides/ru/net/text-formatting/).

## **Change a Slide Master Background**

Фон мастера наследуется макетами и слайдами, которые его не переопределяют. Следующий пример задаёт сплошной цвет фона для первого слайд‑мастера:

```csharp
using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];

masterSlide.Background.Type = BackgroundType.OwnBackground;
masterSlide.Background.FillFormat.FillType = FillType.Solid;
masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

presentation.Save("presentation-master-background.pptx", SaveFormat.Pptx);
```

См. также [Presentation Background](/slides/ru/net/presentation-background/) и [Presentation Theme](/slides/ru/net/presentation-theme/).

## **Clone a Slide Master to Another Presentation**

Используйте [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/ru/net/aspose.slides/imasterslidecollection/addclone/) для копирования слайд‑мастера в другую презентацию. Скопированный мастер затем может использоваться макетами и слайдами в целевой презентации.

```csharp
using var sourcePresentation = new Presentation("source.pptx");
using var destinationPresentation = new Presentation("destination.pptx");

var sourceMasterSlide = sourcePresentation.Masters[0];
var clonedMasterSlide = destinationPresentation.Masters.AddClone(sourceMasterSlide);

destinationPresentation.Save("destination-with-master.pptx", SaveFormat.Pptx);
```

Если необходимо клонировать обычные слайды вместе с их мастером, см. [Clone Slides](/slides/ru/net/clone-slides/).

## **Add Multiple Slide Masters**

Презентация может содержать несколько слайд‑мастеров. Это полезно, когда разные разделы требуют различного фирменного стиля, структуры страниц или настроек темы.

![Команды PowerPoint для вставки и управления слайд‑мастерами](slide-master_9.jpg)

Следующий пример клонирует мастер по умолчанию, задаёт клону другой фон, создаёт макет под этим клонированным мастером и добавляет новый слайд на основе этого макета:

```csharp
using var presentation = new Presentation("presentation.pptx");

var defaultMasterSlide = presentation.Masters[0];
var sectionMasterSlide = presentation.Masters.AddClone(defaultMasterSlide);

sectionMasterSlide.Background.Type = BackgroundType.OwnBackground;
sectionMasterSlide.Background.FillFormat.FillType = FillType.Solid;
sectionMasterSlide.Background.FillFormat.SolidFillColor.Color = Color.LightSteelBlue;

var sourceBlankLayout =
    defaultMasterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank) ??
    defaultMasterSlide.LayoutSlides[0];
var sectionBlankLayout = sectionMasterSlide.LayoutSlides.AddClone(sourceBlankLayout);

presentation.Slides.AddEmptySlide(sectionBlankLayout);
presentation.Save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx);
```

## **Compare Slide Masters**

Слайд‑мастера можно сравнивать методом `Equals`, унаследованным от [IBaseSlide](https://reference.aspose.com/slides/ru/net/aspose.slides/ibaseslide/). Сравнение проверяет структуру и статическое содержимое, такое как фигуры, текст, форматирование, анимацию и другие настройки слайда. Оно не сравнивает уникальные идентификаторы, например ID слайдов, или динамические значения заполнителей, такие как текущая дата.

```csharp
using var firstPresentation = new Presentation("first.pptx");
using var secondPresentation = new Presentation("second.pptx");

var firstPresentationMasterCount = firstPresentation.Masters.Count;
var secondPresentationMasterCount = secondPresentation.Masters.Count;

for (var firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++)
{
    for (var secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++)
    {
        var firstMasterSlide = firstPresentation.Masters[firstMasterIndex];
        var secondMasterSlide = secondPresentation.Masters[secondMasterIndex];
        var areMasterSlidesEqual = firstMasterSlide.Equals(secondMasterSlide);

        if (areMasterSlidesEqual)
        {
            Console.WriteLine(
                "first.pptx master #{0} equals second.pptx master #{1}",
                firstMasterIndex,
                secondMasterIndex);
        }
    }
}
```

Для получения дополнительной информации см. [Compare Presentation Slides](/slides/ru/net/compare-slides/).

## **Set Slide Master View as the Default View**

Используйте свойство `LastView` на [ViewProperties](https://reference.aspose.com/slides/ru/net/aspose.slides/viewproperties/) для управления представлением, которое PowerPoint открывает первым. Следующий пример открывает презентацию в режиме Slide Master:

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("presentation-master-view.pptx", SaveFormat.Pptx);
```

Для получения информации о настройках представления см. [Save Presentation](/slides/ru/net/save-presentation/).

## **Remove Unused Master Slides**

Иногда презентации содержат слайд‑мастера, которые больше не используются обычными слайдами. Удаление неиспользуемых мастеров может уменьшить размер файла и упростить обслуживание шаблона.

Используйте [MasterSlideCollection.RemoveUnused](https://reference.aspose.com/slides/ru/net/aspose.slides/masterslidecollection/removeunused/) для удаления неиспользуемых мастеров из коллекции `Masters`:

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.Masters.RemoveUnused(ignorePreserveField: true);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

Вы также можете воспользоваться методом низко‑кода [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/compress/removeunusedmasterslides/):

```csharp
using var presentation = new Presentation("presentation.pptx");

Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(presentation);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

## **FAQ**

**В чём разница между слайд‑мастером и макетным слайдом?**

Слайд‑мастер определяет общие настройки дизайна, такие как тема, фон, общие фигуры и стили текста. Макетный слайд принадлежит слайд‑мастеру и задаёт конкретное расположение заполнителей. Обычный слайд использует макетный слайд, поэтому наследует как от макета, так и от мастера.

**Может ли одна презентация содержать несколько слайд‑мастеров?**

Да. Презентация может содержать несколько слайд‑мастеров. Используйте несколько мастеров, когда разные разделы требуют разных визуальных систем или фирменного стиля.

**Стоит ли добавлять заполнители в слайд‑мастер или в макетный слайд?**

В большинстве случаев заполнители добавляют в макетные слайды. Общие визуальные элементы и общие форматирования размещайте на слайд‑мастере, а заполнители содержимого — на макетах, которые будут использовать обычные слайды.

**Могу ли я удалить слайд‑мастер, который всё ещё используется?**

Нет. Слайд‑мастер, имеющий зависимые слайды, нельзя безопасно удалить напрямую. Сначала переместите эти слайды в макеты под другим мастером или используйте метод очистки неиспользуемых мастеров, который удаляет только те мастера, которые не задействованы.