---
title: Управление мастерами слайдов презентации в .NET
linktitle: Мастер слайда
type: docs
weight: 80
url: /ru/net/slide-master/
keywords:
- мастер слайдов
- мастер слайда
- мастер‑слайд PPT
- несколько мастеров слайдов
- сравнение мастеров слайдов
- фон
- заполнитель
- клонирование мастера слайда
- копирование мастера слайда
- дублирование мастера слайда
- неиспользуемый мастер‑слайд
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Управляйте мастерами слайдов в Aspose.Slides для .NET: получайте доступ, редактируйте, клонируйте, сравнивайте и удаляйте мастера слайдов в презентациях PowerPoint и OpenDocument."
---
## **Обзор**

**Мастер слайдов** определяет общие настройки оформления для группы слайдов. Он может содержать общие фигуры, логотипы, фоны, стили текста, настройки темы и нижних колонтитулов. В PowerPoint редактирование мастера слайдов — обычный способ обеспечить согласованность презентации без повторения одинакового форматирования на каждом слайде.

Aspose.Slides for .NET поддерживает ту же модель. Презентация может содержать один или несколько мастеров слайдов, и каждый мастер слайдов может содержать несколько макетных слайдов. Обычные слайды обычно не ссылаются напрямую на мастер‑слайд. Вместо этого обычный слайд использует макетный слайд, который принадлежит мастеру слайдов.

Иерархия выглядит так:

1. **Slide master** — определяет общий дизайн и тему.  
1. **Layout slide** — определяет конкретное расположение заполнителей и форматирование уровня макета.  
1. **Normal slide** — содержит фактическое содержимое презентации и использует один макетный слайд.

![Иерархия мастеров слайдов, макетных слайдов и обычных слайдов](slide-master_2.jpg)

В Aspose.Slides мастер‑слайд представлен интерфейсом [IMasterSlide](https://reference.aspose.com/slides/ru/net/aspose.slides/imasterslide/) . Все мастера слайдов в презентации доступны через коллекцию [Presentation.Masters](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/masters/) , которая реализует [IMasterSlideCollection](https://reference.aspose.com/slides/ru/net/aspose.slides/imasterslidecollection/) .

{{% alert color="info" title="Inheritance" %}}
Если одно и то же свойство определено на более чем одном уровне, выигрывает более специфичный уровень. Например, если мастер‑слайд и макетный слайд оба определяют фон, слайды, основанные на этом макете, используют фон макета. Для получения дополнительной информации о макетных слайдах см. [Применить или изменить макет слайдов](/slides/ru/net/slide-layout/) .
{{% /alert %}}

## **Доступ к мастерам слайдов**

В PowerPoint вы можете открыть представление Мастер слайдов через **View** > **Slide Master**.

![Команда Мастер слайдов на вкладке View в PowerPoint](slide-master_3.jpg)

В Aspose.Slides используйте коллекцию `Masters` для доступа к мастерам слайдов:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var firstMasterSlide = presentation.Masters[0];
var masterSlideCount = presentation.Masters.Count;
var firstMasterLayoutSlideCount = firstMasterSlide.LayoutSlides.Count;

Console.WriteLine("Master slides: " + masterSlideCount);
Console.WriteLine("Layouts in the first master: " + firstMasterLayoutSlideCount);
```

Вы также можете получить мастер‑слайд, используемый обычным слайдом, через его макет:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var slide = presentation.Slides[0];
var layoutSlide = slide.LayoutSlide;
var masterSlide = layoutSlide.MasterSlide;
var masterSlideName = masterSlide.Name;

Console.WriteLine(masterSlideName);
```

## **Содержимое мастера слайдов**

Мастер‑слайд — объект, похожий на слайд. Он реализует [IBaseSlide](https://reference.aspose.com/slides/ru/net/aspose.slides/ibaseslide/), поэтому предоставляет многие те же свойства слайда, используемые обычными и макетными слайдами. Члены, специфичные для мастера, перечислены на странице API [IMasterSlide](https://reference.aspose.com/slides/ru/net/aspose.slides/imasterslide/) .

К наиболее часто используемым членам мастера слайдов относятся:

| Член | Назначение |
| --- | --- |
| `Background` | Устанавливает фон слайда уровня мастера. |
| `Shapes` | Содержит фигуры, размещённые на мастере, такие как логотипы, рамки изображений и общий текст. |
| `LayoutSlides` | Содержит макетные слайды, принадлежащие данному мастеру. |
| `ThemeManager` | Обеспечивает доступ к API тем мастера. |
| `HeaderFooterManager` | Управляет колонтитулами, датами и номерами слайдов для мастера и его дочерних макетов. |
| `GetDependingSlides` | Возвращает обычные слайды, зависимые от мастера через их макеты. |

## **Добавить изображение в мастер слайдов**

Когда вы добавляете изображение в мастер‑слайд, оно появляется на слайдах, использующих макеты этого мастера. Это полезно для логотипов, водяных знаков, декоративных баннеров и других повторяющихся визуальных элементов.

Следующий пример добавляет логотип на первый мастер‑слайд:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

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

Для получения дополнительной информации о рамках изображений см. [Рамка изображения](/slides/ru/net/picture-frame/) .

## **Контроль видимости графики мастера**

Используйте [IBaseSlide.ShowMasterShapes](https://reference.aspose.com/slides/ru/net/aspose.slides/ibaseslide/showmastershapes/) , чтобы скрыть унаследованные графические элементы мастера, такие как логотипы или декоративные фигуры, без их удаления из мастера. Установите [Slide.ShowMasterShapes](https://reference.aspose.com/slides/ru/net/aspose.slides/slide/showmastershapes/) в `false` для слайда, которому необходимо скрыть эти графические элементы, и оставьте `true` для слайдов, где они должны отображаться.

Следующий автономный пример создаёт синюю декоративную полосу на мастере и два слайда, использующие один и тот же пустой макет. Полоса отображается на первом слайде и скрыта на втором. Входная презентация или изображение не требуются.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var masterSlide = presentation.Masters[0];
var layoutSlide = masterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank);
layoutSlide.ShowMasterShapes = true;

var slideHeight = presentation.SlideSize.Size.Height;
var band = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 60, slideHeight);
band.FillFormat.FillType = FillType.Solid;
band.FillFormat.SolidFillColor.Color = Color.SteelBlue;
band.LineFormat.FillFormat.FillType = FillType.NoFill;

var visibleSlide = presentation.Slides[0];
visibleSlide.LayoutSlide = layoutSlide;
visibleSlide.Shapes.Clear();

var hiddenSlide = presentation.Slides.AddEmptySlide(layoutSlide);

visibleSlide.ShowMasterShapes = true;
hiddenSlide.ShowMasterShapes = false;

presentation.Save("master-graphics.pptx", SaveFormat.Pptx);
```

Пример использует макет **Blank**, поставляемый с новой презентацией, и удаляет собственные заполнительные элементы первоначального слайда.

### **Выбор области применения настройки**

Обычный слайд использует свой мастер через [ISlide.LayoutSlide](https://reference.aspose.com/slides/ru/net/aspose.slides/islide/layoutslide/) и [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/ru/net/aspose.slides/ilayoutslide/masterslide/). Установка свойства для отдельного слайда влияет только на этот слайд. Установка [LayoutSlide.ShowMasterShapes](https://reference.aspose.com/slides/ru/net/aspose.slides/layoutslide/showmastershapes/) в `false` скрывает графику мастера для всех слайдов, использующих общий макет, даже если их собственная настройка `true`. Чтобы скрыть графику лишь на одном слайде, измените свойство слайда и оставьте общий макет без изменений.

Эта настройка не поддерживается как управление видимостью непосредственно на мастер‑слайде. На мастере она всегда возвращает `false`, а попытка установить `true` вызывает `NotSupportedException`. Применяйте её к обычному слайду или к макету.

### **Отличие графики от фона**

| Операция | Эффект |
| --- | --- |
| Скрыть графику мастера | Управляет видимостью унаследованных фигур мастера без их удаления или изменения собственных фигур слайда. |
| Изменить заливку фона слайда | Меняет цвет, градиент или изображение фона. Графика мастера — отдельные фигуры, которые могут оставаться видимыми поверх этого фона. См. [Фон презентации](/slides/ru/net/presentation-background/) . |
| Удалить фигуру из мастера | Удаляет общую исходную фигуру, делая её недоступной для любых слайдов, использующих этот мастер. |

## **Работа с заполнителями**

Заполнители обычно определяются на макетных слайдах. Мастер‑слайд предоставляет общий стиль и тему, которые наследуют эти макеты, а каждый макет решает, какие заполнители доступны и где они расположены.

В PowerPoint команды заполнителей доступны в представлении Мастер слайдов.

![Команда Вставить заполнитель в представлении Мастер слайдов PowerPoint](slide-master_5.png)

Чтобы добавить новые заполнители с помощью Aspose.Slides, работайте с макетным слайдом, принадлежащим мастеру:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

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

Вы также можете форматировать фигуры‑заполнители, уже существующие на мастере слайдов. Следующий пример находит заполнитель заголовка и применяет линейную градиентную заливку:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

![Отформатированный заполнитель заголовка, наследуемый обычными слайдами](slide-master_8.png)

Для более подробных вариантов форматирования заполнителей и текста см. [Установить текст подсказки в заполнителе](/slides/ru/net/manage-placeholder/) и [Форматирование текста](/slides/ru/net/text-formatting/) .

## **Изменить фон мастера слайдов**

Фон мастера наследуется макетами и слайдами, которые его не переопределяют. Следующий пример задает сплошной цвет фона для первого мастера слайдов:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];

masterSlide.Background.Type = BackgroundType.OwnBackground;
masterSlide.Background.FillFormat.FillType = FillType.Solid;
masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

presentation.Save("presentation-master-background.pptx", SaveFormat.Pptx);
```

Для связанных тем см. [Фон презентации](/slides/ru/net/presentation-background/) и [Тема презентации](/slides/ru/net/presentation-theme/) .

## **Клонировать мастер слайдов в другую презентацию**

Используйте [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/ru/net/aspose.slides/imasterslidecollection/addclone/) , чтобы скопировать мастер‑слайд в другую презентацию. Скопированный мастер затем может использоваться макетами и слайдами в целевой презентации.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var sourcePresentation = new Presentation("source.pptx");
using var destinationPresentation = new Presentation("destination.pptx");

var sourceMasterSlide = sourcePresentation.Masters[0];
var clonedMasterSlide = destinationPresentation.Masters.AddClone(sourceMasterSlide);

destinationPresentation.Save("destination-with-master.pptx", SaveFormat.Pptx);
```

Если вам нужно клонировать обычные слайды вместе с их мастером, см. [Клонировать слайды](/slides/ru/net/clone-slides/) .

## **Добавить несколько мастеров слайдов**

Презентация может содержать несколько мастеров слайдов. Это полезно, когда различные разделы требуют разного брендинга, структуры страниц или настроек темы.

![Команды PowerPoint для вставки и управления мастерами слайдов](slide-master_9.jpg)

Следующий пример клонирует мастер по умолчанию, задаёт клону другой фон, создаёт макет под этим клонированным мастером и добавляет новый слайд на основе этого макета:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **Сравнение мастеров слайдов**

Мастера слайдов можно сравнивать методом `Equals`, унаследованным от [IBaseSlide](https://reference.aspose.com/slides/ru/net/aspose.slides/ibaseslide/) . Сравнение проверяет структуру и статическое содержимое, такое как фигуры, текст, форматирование, анимацию и другие настройки слайда. Оно не сравнивает уникальные идентификаторы, такие как ID слайда, или динамические значения заполнителей, такие как текущая дата.

```csharp
using Aspose.Slides;

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

Для получения дополнительной информации см. [Сравнить слайды презентации](/slides/ru/net/compare-slides/) .

## **Установить представление мастера слайдов в качестве представления по умолчанию**

Используйте свойство `LastView` на [ViewProperties](https://reference.aspose.com/slides/ru/net/aspose.slides/viewproperties/) , чтобы управлять тем представлением, которое PowerPoint открывает первым. Следующий пример открывает презентацию в представлении Мастер слайдов:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("presentation-master-view.pptx", SaveFormat.Pptx);
```

Для более подробных настроек представления см. [Сохранить презентацию](/slides/ru/net/save-presentation/) .

## **Удалить неиспользуемые мастера слайдов**

В презентациях иногда присутствуют мастера слайдов, которые больше не используются обычными слайдами. Удаление неиспользуемых мастеров может уменьшить размер файла и упростить обслуживание шаблонов.

Используйте [MasterSlideCollection.RemoveUnused](https://reference.aspose.com/slides/ru/net/aspose.slides/masterslidecollection/removeunused/) , чтобы удалить неиспользуемые мастера из коллекции `Masters`:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

presentation.Masters.RemoveUnused(ignorePreserveField: true);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

Вы также можете использовать low-code‑метод [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/ru/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) :

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(presentation);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

## **FAQ**

**В чем разница между мастером слайдов и макетным слайдом?**

Мастер слайдов определяет общие настройки дизайна, такие как тема, фон, общие фигуры и стили текста. Макетный слайд принадлежит мастеру слайдов и задаёт конкретное расположение заполнителей. Обычный слайд использует макетный слайд, поэтому наследует свойства как от макета, так и от мастера.

**Можно ли в одной презентации иметь несколько мастеров слайдов?**

Да. Презентация может содержать несколько мастеров слайдов. Используйте несколько мастеров, когда разные разделы требуют разных визуальных систем или брендинга.

**Следует ли добавлять заполнители в мастер‑слайд или в макетный слайд?**

В большинстве случаев заполнители добавляются в макетные слайды. Общие визуальные элементы и общие форматы размещайте на мастере слайдов, а заполнители содержимого – на макетах, которые будут использовать обычные слайды.

**Могу ли я удалить мастер‑слайд, который всё ещё используется?**

Нет. Мастер‑слайд, имеющий зависимые слайды, нельзя безопасно удалить напрямую. Сначала перенесите эти слайды на макеты другого мастера или используйте метод очистки неиспользуемых мастеров, который удаляет только мастеры, не используемые в презентации.