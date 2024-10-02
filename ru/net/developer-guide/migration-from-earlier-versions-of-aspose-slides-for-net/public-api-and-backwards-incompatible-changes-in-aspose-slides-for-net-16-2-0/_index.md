---
title: Публичный API и несовместимые изменения в Aspose.Slides для .NET 16.2.0
type: docs
weight: 230
url: /ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/
---

{{% alert color="primary" %}} 

Эта страница содержит список всех [добавленных](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) или [удаленных](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) классов, методов, свойств и других изменений, введенных с API Aspose.Slides для .NET 16.2.0.

{{% /alert %}} 
## **Изменения публичного API**
#### **Свойства UpdateDateTimeFields и UpdateSlideNumberFields были удалены**
Свойства UpdateDateTimeFields и UpdateSlideNumberFields были удалены из класса Aspose.Slides.Presentation и из интерфейса Aspose.Slides.IPresentation.
Свойство Text классов Aspose.Slides.TextFrame, Paragraph, Portion и интерфейсов Aspose.Slides.ITextFrame, IParagraph, IPortion возвращает текст с обновленными полями "datetime".
Также свойства Presentation.DocumentProperties.CreatedTime, LastSavedTime и LastPrinted стали доступны только для чтения.
#### **Enum Slides.Charts.CategoryAxisType был переключен на публичный**
Используется в свойствах IAxis.CategoryAxisType и Axis.CategoryAxisType для определения типа категориальной оси.
CategoryAxisType.Auto - тип категориальной оси будет определен автоматически во время сериализации (это поведение сейчас не реализовано)
CategoryAxisType.Text - тип категориальной оси – Текст
CategoryAxisType.Date - тип категориальной оси – Дата и время
#### **Быстрое извлечение текста**
В класс Presentation был добавлен новый статический метод GetPresentationText. У этого метода есть два перегруженных варианта:

``` csharp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)

``` 

Аргумент Enum ExtractionMode указывает режим организации результата извлеченного текста и может быть установлен на следующие значения:
Unarranged - Сырой текст без учета позиции на слайде
Arranged - Текст расположен в том же порядке, что и на слайде

Режим Unarranged может использоваться, когда скорость критична, он быстрее, чем режим Arranged.

PresentationText представляет собой сырой текст, извлеченный из презентации. Он содержит свойство SlidesText из пространства имен Aspose.Slides.Util, которое возвращает массив объектов ISlideText. Каждый объект представляет текст на соответствующем слайде. Объект ISlideText имеет следующие свойства:

ISlideText.Text - текст на фигурах слайда
ISlideText.MasterText - текст на фигурах главной страницы для этого слайда
ISlideText.LayoutText - текст на фигурах страницы макета для этого слайда
ISlideText.NotesText - текст на фигурах страницы заметок для этого слайда

Также есть класс SlideText, который реализует интерфейс ISlideText.

Новый API можно использовать следующим образом:

``` csharp

 PresentationText text1 = Presentation.GetPresentationText("presentation.ppt");

Console.WriteLine(text1.SlidesText[0].Text);

Console.WriteLine(text1.SlidesText[0].LayoutText);

Console.WriteLine(text1.SlidesText[0].MasterText);

Console.WriteLine(text1.SlidesText[0].NotesText);

PresentationText text2 = Presentation.GetPresentationText("presentation.pptx", ExtractionMode.Unarranged)

``` 
#### **Интерфейс ILegacyDiagram и класс LegacyDiagram были добавлены**
Интерфейс Aspose.Slides.ILegacyDiagram и класс Aspose.Slides.LegacyDiagram были добавлены для представления объектов устаревшей диаграммы. Объект устаревшей диаграммы - это старый формат диаграмм из PowerPoint 97-2003.
Новый класс предоставляет методы для преобразования устаревшей диаграммы в современный редактируемый объект SmartArt или в редактируемый GroupShape.
#### **Добавлен новый член enum Aspose.Slides.TextAlignment (JustifyLow)**
В enum TextAlignment был добавлен новый член:
JustifyLow - Низкое обоснование квашида.
#### **Новые свойства для Aspose.Slides.IOleObjectFrame и OleObjectFrame**
В интерфейс IOleObjectFrame и в класс OleObjectFrame, реализующий этот интерфейс, было добавлено новое свойство. Эти свойства используются для предоставления информации об объекте, встроенном в презентацию:
EmbeddedFileExtension - Возвращает расширение файла для текущего встроенного объекта или пустую строку, если объект не является ссылкой
EmbeddedFileLabel - Возвращает имя файла встроенного OLE объекта
EmbeddedFileName - Возвращает путь к встроенному OLE объекту
#### **Новое свойство CategoryAxisType было добавлено в классы IAxis и Axis**
Свойство CategoryAxisType определяет тип категориальной оси.

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
#### **Новое свойство ShowLabelAsDataCallout было добавлено в класс DataLabelFormat и интерфейс IDataLabelFormat**
Свойство ShowLabelAsDataCallout определяет, будет ли заданный метка данных графика отображаться как выносная метка данных или как метка данных.

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
#### **Свойство DrawSlidesFrame было добавлено в PdfOptions и XpsOptions**
Булевое свойство DrawSlidesFrame было добавлено в интерфейсы Aspose.Slides.Export.IPdfOptions, Aspose.Slides.Export.IXpsOptions и в соответствующие классы Aspose.Slides.Export.PdfOptions, Aspose.Slides.Export.XpsOptions.
Черная рамка вокруг каждого слайда будет нарисована, если это свойство установлено в 'true'.

``` csharp

 using (Presentation pres = new Presentation("input.pptx"))

{

    pres.Save("output.pdf", SaveFormat.Pdf, new PdfOptions() { DrawSlidesFrame = true });

}

``` 