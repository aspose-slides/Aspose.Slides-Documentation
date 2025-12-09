---
title: Публичный API и обратные несовместимые изменения в Aspose.Slides для .NET 15.10.0
linktitle: Aspose.Slides для .NET 15.10.0
type: docs
weight: 200
url: /ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-10-0/
keywords:
- миграция
- унаследованный код
- современный код
- унаследованный подход
- современный подход
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Обзор обновлений публичного API и разрушающих изменений в Aspose.Slides для .NET, позволяющих плавно мигрировать ваши решения для презентаций PowerPoint PPT, PPTX и ODP."
---

{{% alert color="primary" %}} 

Эта страница перечисляет все [добавленные](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-10-0/) или [удалённые](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-10-0/) классы, методы, свойства и т.д., а также другие изменения, введённые в API Aspose.Slides for .NET 15.10.0.

{{% /alert %}} 
## **Изменения публичного API**
#### **Новый VideoPlayerHtmlController добавлен для поддержки экспорта медиа‑файлов в HTML**
Новый публичный класс VideoPlayerHtmlController был добавлен в пространство имён Aspose.Slides.Export. С помощью экземпляра этого класса пользователь может экспортировать видео‑ и аудиофайлы в HTML.
Конструкторы VideoPlayerHtmlController принимают следующие параметры:

path: Путь, где будут сгенерированы видео‑ и аудиофайлы  
fileName: Имя HTML‑файла  

baseUri: Базовый URI, который будет использован для генерации ссылок  
Пример использования:

``` csharp

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
В интерфейс Aspose.Slides.Animation.ISequence добавлены 2 новых метода.

``` csharp

 IEffect AddEffect(IChart chart, EffectChartMajorGroupingType type, int index, EffectType effectType, EffectSubtype subtype, EffectTriggerType triggerType);

IEffect AddEffect(IChart chart, EffectChartMinorGroupingType type, int seriesIndex, int categoriesIndex, EffectType effectType, EffectSubtype subtype, EffectTriggerType triggerType);

``` 

Эти методы предназначены для поддержки анимации элементов диаграммы:
по сериям
по категориям
по элементам серии
по элементам категории

Были введены два новых перечисления EffectChartMajorGroupingType и EffectChartMinorGroupingType, связанные с анимацией элементов диаграммы.

Чтобы добавить анимацию серии к диаграмме, можно использовать следующий код:

``` csharp

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

Анимация категорий:

``` csharp

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

Анимация элементов серии:

``` csharp

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

Анимация элементов категорий:

``` csharp

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