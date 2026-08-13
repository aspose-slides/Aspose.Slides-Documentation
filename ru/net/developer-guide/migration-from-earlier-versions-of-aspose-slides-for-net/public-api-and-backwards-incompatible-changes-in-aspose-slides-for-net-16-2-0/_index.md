---
title: Публичный API и несовместимые изменения в Aspose.Slides для .NET 16.2.0
linktitle: Aspose.Slides для .NET 16.2.0
type: docs
weight: 230
url: /ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/
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
description: "Изучите обновления публичного API и разрушающие изменения в Aspose.Slides для .NET, чтобы плавно мигрировать ваши решения для презентаций PowerPoint PPT, PPTX и ODP."
---
{{% alert color="info" %}} 

Эта страница перечисляет все [добавленные](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) или [удалённые](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) классы, методы, свойства и т. д., а также другие изменения, введённые в API Aspose.Slides for .NET 16.2.0.

{{% /alert %}} 
## **Изменения публичного API**
#### **Свойства UpdateDateTimeFields и UpdateSlideNumberFields удалены**
Свойства UpdateDateTimeFields и UpdateSlideNumberFields были удалены из класса Aspose.Slides.Presentation и из интерфейса Aspose.Slides.IPresentation.
Свойство Text классов Aspose.Slides.TextFrame, Paragraph, Portion и интерфейсов Aspose.Slides.ITextFrame, IParagraph, IPortion возвращает текст с обновлёнными полями "datetime".
Также свойства Presentation.DocumentProperties.CreatedTime, LastSavedTime и LastPrinted стали только для чтения.
#### **Перечисление Slides.Charts.CategoryAxisType сделано публичным**
Используется в свойствах IAxis.CategoryAxisType и Axis.CategoryAxisType для определения типа оси категорий.
CategoryAxisType.Auto – тип оси категорий будет определён автоматически во время сериализации (это поведение пока не реализовано)
CategoryAxisType.Text – тип оси категорий – Text
CategoryAxisType.Date – тип оси категорий – DateTime
#### **Быстрое извлечение текста**
В класс Presentation был добавлен новый статический метод GetPresentationText. Для этого метода существует две перегрузки:

``` csharp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)

``` 

Аргумент enum ExtractionMode указывает режим организации результата текста и может принимать следующие значения:
Unarranged – исходный текст без учёта положения на слайде
Arranged – текст расположен в том же порядке, что и на слайде

Режим Unarranged можно использовать, когда важна скорость; он быстрее режима Arranged.

PresentationText представляет собой исходный текст, извлечённый из презентации. Он содержит свойство SlidesText из пространства имён Aspose.Slides.Util, которое возвращает массив объектов ISlideText. Каждый объект представляет текст на соответствующем слайде. Объекты ISlideText имеют следующие свойства:
ISlideText.Text – текст фигур на слайде
ISlideText.MasterText – текст фигур на главной странице для этого слайда
ISlideText.LayoutText – текст фигур на странице макета для этого слайда
ISlideText.NotesText – текст фигур на странице заметок для этого слайда

Также существует класс SlideText, который реализует интерфейс ISlideText.

Новый API можно использовать так:

``` csharp
using System;
using Aspose.Slides;

// Извлечь текст без учёта его положения на слайде (самый быстрый режим).
IPresentationText text1 = PresentationFactory.Instance.GetPresentationText(
    "presentation.ppt", TextExtractionArrangingMode.Unarranged);

Console.WriteLine(text1.SlidesText[0].Text);
Console.WriteLine(text1.SlidesText[0].LayoutText);
Console.WriteLine(text1.SlidesText[0].MasterText);
Console.WriteLine(text1.SlidesText[0].NotesText);

// Извлечь текст, расположенный в том же порядке, что и на слайде.
IPresentationText text2 = PresentationFactory.Instance.GetPresentationText(
    "presentation.pptx", TextExtractionArrangingMode.Arranged);

Console.WriteLine(text2.SlidesText[0].Text);
``` 
#### **Добавлены интерфейс ILegacyDiagram и класс LegacyDiagram**
Интерфейс Aspose.Slides.ILegacyDiagram и класс Aspose.Slides.LegacyDiagram были добавлены для представления объекта устаревшей диаграммы. Объект устаревшей диаграммы — это старый формат диаграмм из PowerPoint 97‑2003.
Новый класс предоставляет методы для преобразования устаревшей диаграммы в современный редактируемый объект SmartArt или в редактируемый GroupShape.
#### **Добавлен новый элемент перечисления Aspose.Slides.TextAlignment (JustifyLow)**
Был добавлен новый элемент перечисления TextAlignment:
JustifyLow – выравнивание Kashida low.
#### **Новые свойства для Aspose.Slides.IOleObjectFrame и OleObjectFrame**
Были добавлены новые свойства к интерфейсу IOleObjectFrame и классу OleObjectFrame, реализующему этот интерфейс. Эти свойства используют для предоставления информации об объекте, встроенном в презентацию:
EmbeddedFileExtension – возвращает расширение файла текущего встроенного объекта или пустую строку, если объект не является ссылкой
EmbeddedFileLabel – возвращает имя файла встроенного OLE‑объекта
EmbeddedFileName – возвращает путь к встроенному OLE‑объекту
#### **Добавлено новое свойство CategoryAxisType в классы IAxis и Axis**
Свойство CategoryAxisType указывает тип оси категорий.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

string sourcePptxFileName = "chart.pptx";
string pptxOutPath = "chart_out.pptx";

using (Presentation pres = new Presentation(sourcePptxFileName))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;

    chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
    chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;
    chart.Axes.HorizontalAxis.MajorUnit = 1;
    chart.Axes.HorizontalAxis.MajorUnitScale = TimeUnitType.Months;

    pres.Save(pptxOutPath, SaveFormat.Pptx);
}
``` 
#### **Добавлено новое свойство ShowLabelAsDataCallout в класс DataLabelFormat и интерфейс IDataLabelFormat**
Свойство ShowLabelAsDataCallout определяет, будет ли метка данных указанной диаграммы отображаться как вызов данных или как метка данных.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

string pptxFileName = "callout_labels.pptx";

using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 500, 400);

    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;
    chart.ChartData.Series[0].Labels[2].DataLabelFormat.ShowLabelAsDataCallout = false;

    pres.Save(pptxFileName, SaveFormat.Pptx);
}
``` 
#### **Добавлено свойство DrawSlidesFrame в PdfOptions и XpsOptions**
Булево свойство DrawSlidesFrame было добавлено к интерфейсам Aspose.Slides.Export.IPdfOptions, Aspose.Slides.Export.IXpsOptions и к соответствующим классам Aspose.Slides.Export.PdfOptions, Aspose.Slides.Export.XpsOptions.
Черная рамка вокруг каждого слайда будет отрисована, если это свойство установлено в значение true.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


 using (Presentation pres = new Presentation("input.pptx"))

{

    pres.Save("output.pdf", SaveFormat.Pdf, new PdfOptions() { DrawSlidesFrame = true });

}
```