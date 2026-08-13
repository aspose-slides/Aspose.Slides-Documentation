---
title: Публичный API и несовместимые изменения в Aspose.Slides для .NET 15.10.0
linktitle: Aspose.Slides для .NET 15.10.0
type: docs
weight: 200
url: /ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-10-0/
keywords:
- миграция
- устаревший код
- современный код
- устаревший подход
- современный подход
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Обзор обновлений публичного API и разрывных изменений в Aspose.Slides для .NET, позволяющий плавно мигрировать решения для презентаций PowerPoint PPT, PPTX и ODP."
---
{{% alert color="info" %}} 
Эта страница перечисляет все [добавленные](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-10-0/) или [удалённые](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-10-0/) классы, методы, свойства и т. д., а также другие изменения, внесённые в API Aspose.Slides для .NET 15.10.0.
{{% /alert %}} 
## **Изменения публичного API**
#### **Добавлен новый VideoPlayerHtmlController для поддержки экспорта медиа‑файлов в HTML**
Новый публичный класс VideoPlayerHtmlController был добавлен в пространство имён Aspose.Slides.Export. Используя экземпляр этого класса, пользователь может экспортировать видео‑ и аудиофайлы в HTML.  
Конструкторы VideoPlayerHtmlController принимают следующие параметры:

path: Путь, где будут созданы видео‑ и аудиофайлы  
fileName: Имя HTML‑файла  

baseUri: Базовый URI, который будет использоваться для создания ссылок  
Пример использования:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


 using (Presentation pres = new Presentation("example.pptx"))

{

    const string path = "path";

    const string fileName = "video.html";

    const string baseUri = "http://www.example.com/";

    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path: path, fileName: fileName, baseUri: baseUri);

    HtmlOptions htmlOptions = new HtmlOptions(controller);

    SVGOptions svgOptions = new SVGOptions(controller);

    htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);

    htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

    pres.Save(Path.Combine(path, fileName), SaveFormat.Html, htmlOptions);

}

``` 
#### **API анимации серий диаграмм добавлен**
В интерфейс Aspose.Slides.Animation.ISequence было добавлено 2 новых метода.

``` csharp
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;


 IEffect AddEffect(IChart chart, EffectChartMajorGroupingType type, int index, EffectType effectType, EffectSubtype subtype, EffectTriggerType triggerType);

IEffect AddEffect(IChart chart, EffectChartMinorGroupingType type, int seriesIndex, int categoriesIndex, EffectType effectType, EffectSubtype subtype, EffectTriggerType triggerType);

``` 

Эти методы предназначены для поддержки анимации элементов диаграммы:
by series
by categories
by series elements
by categories elements

Были введены два новых перечисления EffectChartMajorGroupingType и EffectChartMinorGroupingType, связанные с анимацией элементов диаграммы.

Чтобы добавить анимацию серии в диаграмму, можно использовать следующий код:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

string inFileName = "sample.pptx";
string outFileName = "output.pptx";

using (Presentation pres = new Presentation(inFileName))
{
    var slide = pres.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None,
        EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMajorGroupingType.BySeries, 0,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMajorGroupingType.BySeries, 1,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMajorGroupingType.BySeries, 2,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMajorGroupingType.BySeries, 3,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    pres.Save(outFileName, SaveFormat.Pptx);
}
``` 

Categories animation:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

string inFileName = "sample.pptx";
string outFileName = "output.pptx";

using (Presentation pres = new Presentation(inFileName))
{
    var slide = pres.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None,
        EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMajorGroupingType.ByCategory, 0,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMajorGroupingType.ByCategory, 1,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMajorGroupingType.ByCategory, 2,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMajorGroupingType.ByCategory, 3,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    pres.Save(outFileName, SaveFormat.Pptx);
}
``` 

Series elements animation:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

string inFileName = "sample.pptx";
string outFileName = "output.pptx";

using (Presentation pres = new Presentation(inFileName))
{
    var slide = pres.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None,
        EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInSeries, 0, 0,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInSeries, 0, 1,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInSeries, 0, 2,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInSeries, 0, 3,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInSeries, 1, 0,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInSeries, 1, 1,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInSeries, 1, 2,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInSeries, 1, 3,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInSeries, 2, 0,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInSeries, 2, 1,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInSeries, 2, 2,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInSeries, 2, 3,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    pres.Save(outFileName, SaveFormat.Pptx);
}
``` 

Categories elements animation:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

string inFileName = "sample.pptx";
string outFileName = "output.pptx";

using (Presentation pres = new Presentation(inFileName))
{
    var slide = pres.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None,
        EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInCategory, 0, 0,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInCategory, 0, 1,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInCategory, 0, 2,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInCategory, 0, 3,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInCategory, 1, 0,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInCategory, 1, 1,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInCategory, 1, 2,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInCategory, 1, 3,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInCategory, 2, 0,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInCategory, 2, 1,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInCategory, 2, 2,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
        EffectChartMinorGroupingType.ByElementInCategory, 2, 3,
        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    pres.Save(outFileName, SaveFormat.Pptx);
}
```