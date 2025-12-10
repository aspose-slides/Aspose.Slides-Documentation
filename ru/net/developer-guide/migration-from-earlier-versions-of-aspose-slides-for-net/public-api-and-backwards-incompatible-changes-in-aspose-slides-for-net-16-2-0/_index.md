---
title: Публичный API и обратные несовместимые изменения в Aspose.Slides для .NET 16.2.0
linktitle: Aspose.Slides для .NET 16.2.0
type: docs
weight: 230
url: /ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/
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
description: "Обзор обновлений публичного API и разрывных изменений в Aspose.Slides для .NET, позволяющих плавно мигрировать решения для презентаций PowerPoint PPT, PPTX и ODP."
---

{{% alert color="primary" %}} 

Эта страница перечисляет все [added](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) или [removed](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) классы, методы, свойства и т.д., а также другие изменения, внесённые в API Aspose.Slides for .NET 16.2.0.

{{% /alert %}} 
## **Изменения публичного API**
#### **Свойства UpdateDateTimeFields и UpdateSlideNumberFields удалены**
Свойства UpdateDateTimeFields и UpdateSlideNumberFields удалены из класса Aspose.Slides.Presentation и из интерфейса Aspose.Slides.IPresentation.
Свойство Text классов Aspose.Slides.TextFrame, Paragraph, Portion и интерфейсов Aspose.Slides.ITextFrame, IParagraph, IPortion возвращает текст с обновлёнными полями «datetime».
Также свойства Presentation.DocumentProperties.CreatedTime, LastSavedTime и LastPrinted стали только для чтения.
#### **Перечисление Slides.Charts.CategoryAxisType сделано публичным**
Используется в свойствах IAxis.CategoryAxisType и Axis.CategoryAxisType для определения типа оси категорий.
CategoryAxisType.Auto — тип оси категорий будет определён автоматически во время сериализации (это поведение пока не реализовано)  
CategoryAxisType.Text — тип оси категорий — Text  
CategoryAxisType.Date — тип оси категорий — DateTime
#### **Быстрое извлечение текста**
В класс Presentation добавлен новый статический метод GetPresentationText. Для этого метода существует две перегрузки:

``` csharp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)

``` 

Аргумент перечисления ExtractionMode указывает режим организации вывода текстового результата и может принимать следующие значения:
Unarranged — необработанный текст без учёта положения на слайде  
Arranged — текст располагается в том же порядке, что и на слайде

Режим Unarranged можно использовать, когда важна скорость; он быстрее, чем режим Arranged.

PresentationText представляет собой необработанный текст, извлечённый из презентации. Он содержит свойство SlidesText из пространства имён Aspose.Slides.Util, которое возвращает массив объектов ISlideText. Каждый объект представляет текст на соответствующем слайде. Объект ISlideText имеет следующие свойства:

ISlideText.Text — Текст на фигурах слайда  
ISlideText.MasterText — Текст на фигурах мастер‑страницы для этого слайда  
ISlideText.LayoutText — Текст на фигурах макетной страницы для этого слайда  
ISlideText.NotesText — Текст на фигурах страницы заметок для этого слайда

Также существует класс SlideText, реализующий интерфейс ISlideText.

Новый API можно использовать следующим образом:

``` csharp

 PresentationText text1 = Presentation.GetPresentationText("presentation.ppt");

Console.WriteLine(text1.SlidesText[0].Text);

Console.WriteLine(text1.SlidesText[0].LayoutText);

Console.WriteLine(text1.SlidesText[0].MasterText);

Console.WriteLine(text1.SlidesText[0].NotesText);

PresentationText text2 = Presentation.GetPresentationText("presentation.pptx", ExtractionMode.Unarranged)

``` 
#### **Интерфейс ILegacyDiagram и класс LegacyDiagram добавлены**
Интерфейс Aspose.Slides.ILegacyDiagram и класс Aspose.Slides.LegacyDiagram добавлены для представления объекта наследуемой диаграммы. Объект наследуемой диаграммы — это старый формат диаграмм из PowerPoint 97‑2003.
Новый класс предоставляет методы преобразования наследуемой диаграммы в современный редактируемый объект SmartArt или в редактируемый GroupShape.
#### **Добавлен новый член перечисления Aspose.Slides.TextAlignment (JustifyLow)**
Добавлен новый член перечисления TextAlignment:
JustifyLow — низкое выравнивание Kashida.
#### **Новые свойства для Aspose.Slides.IOleObjectFrame и OleObjectFrame**
В интерфейс IOleObjectFrame и реализующий его класс OleObjectFrame добавлены новые свойства. Эти свойства предоставляют информацию об объекте, встроенном в презентацию:
EmbeddedFileExtension — возвращает расширение файла текущего встроенного объекта или пустую строку, если объект не является ссылкой  
EmbeddedFileLabel — возвращает имя файла встроенного OLE‑объекта  
EmbeddedFileName — возвращает путь к встроенному OLE‑объекту
#### **Добавлено новое свойство CategoryAxisType в классы IAxis и Axis**
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
#### **Добавлено новое свойство ShowLabelAsDataCallout в класс DataLabelFormat и интерфейс IDataLabelFormat**
Свойство ShowLabelAsDataCallout определяет, будет ли подпись данных указанной диаграммы отображаться как выноска данных или как подпись данных.

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
#### **Свойство DrawSlidesFrame добавлено в PdfOptions и XpsOptions**
Булево свойство DrawSlidesFrame добавлено в интерфейсы Aspose.Slides.Export.IPdfOptions, Aspose.Slides.Export.IXpsOptions и в связанные классы Aspose.Slides.Export.PdfOptions, Aspose.Slides.Export.XpsOptions.
Чёрная рамка вокруг каждого слайда будет отрисовываться, если это свойство установлено в true.

``` csharp

 using (Presentation pres = new Presentation("input.pptx"))

{

    pres.Save("output.pdf", SaveFormat.Pdf, new PdfOptions() { DrawSlidesFrame = true });

}

```