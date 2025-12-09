---
title: Обновления публичного API и обратно несовместимые изменения в Aspose.Slides для .NET 16.2.0
linktitle: Aspose.Slides для .NET 16.2.0
type: docs
weight: 230
url: /ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/
keywords:
- миграция
- старый код
- современный код
- традиционный подход
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

Эта страница перечисляет все [added](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) или [removed](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) классы, методы, свойства и т.д., а также другие изменения, введённые в API Aspose.Slides для .NET 16.2.0.

{{% /alert %}} 
## **Изменения публичного API**
#### **Properties UpdateDateTimeFields and UpdateSlideNumberFields have been removed**
Свойства UpdateDateTimeFields и UpdateSlideNumberFields были удалены из класса Aspose.Slides.Presentation и из интерфейса Aspose.Slides.IPresentation.  
Свойство Text классов Aspose.Slides.TextFrame, Paragraph, Portion и интерфейсов Aspose.Slides.ITextFrame, IParagraph, IPortion возвращает текст с обновлёнными полями «datetime».  
Также свойства Presentation.DocumentProperties.CreatedTime, LastSavedTime и LastPrinted стали только для чтения.  
#### **Enum Slides.Charts.CategoryAxisType has been switched to public**
Используется в свойствах IAxis.CategoryAxisType и Axis.CategoryAxisType для определения типа оси категорий.  
CategoryAxisType.Auto — тип оси категорий будет определён автоматически во время сериализации (это поведение пока не реализовано)  
CategoryAxisType.Text — тип оси категорий — Text  
CategoryAxisType.Date — тип оси категорий — DateTime  
#### **Fast text extraction**
В класс Presentation добавлен новый статический метод GetPresentationText. У этого метода есть две перегрузки:

``` csharp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)

``` 

Аргумент enum ExtractionMode указывает режим организации вывода текстового результата и может принимать следующие значения:  
Unarranged — необработанный текст без учёта положения на слайде  
Arranged — текст размещён в том же порядке, что и на слайде  

Режим Unarranged можно использовать, когда важна скорость; он быстрее режима Arranged.  

PresentationText представляет собой необработанный текст, извлечённый из презентации. Он содержит свойство SlidesText из пространства имён Aspose.Slides.Util, которое возвращает массив объектов ISlideText. Каждый объект представляет текст на соответствующем слайде. Объекты ISlideText имеют следующие свойства:  

ISlideText.Text — текст фигур на слайде  
ISlideText.MasterText — текст фигур на главной странице для этого слайда  
ISlideText.LayoutText — текст фигур на странице макета для этого слайда  
ISlideText.NotesText — текст фигур на странице заметок для этого слайда  

Также существует класс SlideText, реализующий интерфейс ISlideText.  

Новый API можно использовать так:

``` csharp

 PresentationText text1 = Presentation.GetPresentationText("presentation.ppt");

Console.WriteLine(text1.SlidesText[0].Text);

Console.WriteLine(text1.SlidesText[0].LayoutText);

Console.WriteLine(text1.SlidesText[0].MasterText);

Console.WriteLine(text1.SlidesText[0].NotesText);

PresentationText text2 = Presentation.GetPresentationText("presentation.pptx", ExtractionMode.Unarranged)

``` 
#### **ILegacyDiagram interface and LegacyDiagram class have been added**
Интерфейс Aspose.Slides.ILegacyDiagram и класс Aspose.Slides.LegacyDiagram добавлены для представления объекта устаревшей диаграммы. Объект устаревшей диаграммы — это старый формат диаграмм из PowerPoint 97‑2003.  
Новый класс предоставляет методы для преобразования устаревшей диаграммы в современный редактируемый объект SmartArt или в редактируемый GroupShape.  
#### **New Aspose.Slides.TextAlignment enum membed added (JustifyLow)**
В enum Aspose.Slides.TextAlignment добавлен новый член (JustifyLow)  
Новый член enum TextAlignment добавлен:  
JustifyLow — низкое выравнивание с использованием кашиды.  
#### **New properties for Aspose.Slides.IOleObjectFrame and OleObjectFrame**
Новые свойства для Aspose.Slides.IOleObjectFrame и OleObjectFrame  
Новые свойства были добавлены в интерфейс IOleObjectFrame и класс OleObjectFrame, реализующий этот интерфейс. Эти свойства используются для предоставления информации об объекте, внедрённом в презентацию:  
EmbeddedFileExtension — возвращает расширение файла текущего внедрённого объекта или пустую строку, если объект не является ссылкой  
EmbeddedFileLabel — возвращает имя файла внедрённого OLE‑объекта  
EmbeddedFileName — возвращает путь к внедрённому OLE‑объекту  
#### **New property CategoryAxisType has been added to IAxis and Axis classes**
Новый свойство CategoryAxisType добавлено в классы IAxis и Axis  
Свойство CategoryAxisType указывает тип оси категорий.  

``` csharp

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
#### **New property ShowLabelAsDataCallout has been added to DataLabelFormat class and IDataLabelFormat interface**
Новый свойство ShowLabelAsDataCallout добавлен в класс DataLabelFormat и интерфейс IDataLabelFormat  
Свойство ShowLabelAsDataCallout определяет, будет ли указанная подпись данных диаграммы отображаться как выноска или как подпись данных.  

``` csharp

 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 500, 400);

   chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

   chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;

   chart.ChartData.Series[0].Labels[2].DataLabelFormat.ShowLabelAsDataCallout = false;

   pres.Save(pptxFileName, SaveFormat.Pptx);

}

``` 
#### **Property DrawSlidesFrame has been added to PdfOptions and XpsOptions**
Свойство DrawSlidesFrame добавлено в PdfOptions и XpsOptions  
Булево свойство DrawSlidesFrame добавлено в интерфейсы Aspose.Slides.Export.IPdfOptions, Aspose.Slides.Export.IXpsOptions и в соответствующие классы Aspose.Slides.Export.PdfOptions, Aspose.Slides.Export.XpsOptions.  
Черная рамка вокруг каждого слайда будет отрисовываться, если это свойство установлено в true.  

``` csharp

 using (Presentation pres = new Presentation("input.pptx"))

{

    pres.Save("output.pdf", SaveFormat.Pdf, new PdfOptions() { DrawSlidesFrame = true });

}

```