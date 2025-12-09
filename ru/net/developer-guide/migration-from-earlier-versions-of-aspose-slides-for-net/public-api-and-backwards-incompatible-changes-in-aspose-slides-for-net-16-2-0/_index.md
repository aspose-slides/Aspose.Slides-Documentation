---
title: Публичный API и обратно несовместимые изменения в Aspose.Slides для .NET 16.2.0
linktitle: Aspose.Slides для .NET 16.2.0
type: docs
weight: 230
url: /ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/
keywords:
- миграция
- наследуемый код
- современный код
- наследуемый подход
- современный подход
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Изучите обновления публичного API и разрушающие изменения в Aspose.Slides для .NET, чтобы плавно перенести ваши решения презентаций PowerPoint PPT, PPTX и ODP."
---

{{% alert color="primary" %}} 

Эта страница перечисляет все [added](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) или [removed](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) классы, методы, свойства и т.п., а также другие изменения, внесённые в API Aspose.Slides for .NET 16.2.0.

{{% /alert %}} 
## **Изменения публичного API**
#### **Свойства UpdateDateTimeFields и UpdateSlideNumberFields были удалены**
Свойства UpdateDateTimeFields и UpdateSlideNumberFields были удалены из класса Aspose.Slides.Presentation и из интерфейса Aspose.Slides.IPresentation.  
Свойство Text классов Aspose.Slides.TextFrame, Paragraph, Portion и интерфейсов Aspose.Slides.ITextFrame, IParagraph, IPortion возвращает текст с обновлёнными полями «datetime».  
Также свойства Presentation.DocumentProperties.CreatedTime, LastSavedTime и LastPrinted стали только для чтения.  
#### **Перечисление Slides.Charts.CategoryAxisType стало публичным**
Используется в свойствах IAxis.CategoryAxisType и Axis.CategoryAxisType для определения типа оси категорий.  
CategoryAxisType.Auto - тип оси категорий будет определён автоматически во время сериализации (это поведение пока не реализовано)  
CategoryAxisType.Text - тип оси категорий – Text  
CategoryAxisType.Date - тип оси категорий – DateTime  
#### **Быстрое извлечение текста**
Новый статический метод GetPresentationText был добавлен в класс Presentation. Для этого метода существует две перегрузки:

``` csharp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)

``` 

Аргумент перечисления ExtractionMode указывает режим организации вывода результата текста и может принимать следующие значения:  
Unarranged - исходный текст без учёта позиции на слайде  
Arranged - текст располагается в том же порядке, что и на слайде  

Режим Unarranged можно использовать, когда важна скорость; он быстрее режима Arranged.  

PresentationText представляет собой исходный текст, извлечённый из презентации. Он содержит свойство SlidesText из пространства имён Aspose.Slides.Util, которое возвращает массив объектов ISlideText. Каждый объект представляет текст на соответствующем слайде. Объекты ISlideText имеют следующие свойства:  

ISlideText.Text - Текст на формах слайда  
ISlideText.MasterText - Текст на формах главного слайда для этого слайда  
ISlideText.LayoutText - Текст на формах макета слайда для этого слайда  
ISlideText.NotesText - Текст на формах страницы заметок для этого слайда  

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
#### **Добавлены интерфейс ILegacyDiagram и класс LegacyDiagram**
Интерфейс Aspose.Slides.ILegacyDiagram и класс Aspose.Slides.LegacyDiagram добавлены для представления объекта наследуемой диаграммы. Объект наследуемой диаграммы – это старый формат диаграмм PowerPoint 97‑2003.  
Новый класс предоставляет методы для преобразования наследуемой диаграммы в современный редактируемый объект SmartArt или в редактируемый GroupShape.  
#### **В перечисление Aspose.Slides.TextAlignment добавлен новый член (JustifyLow)**
Добавлен новый член перечисления TextAlignment:  
JustifyLow - Kashida justify low.  
#### **Новые свойства для Aspose.Slides.IOleObjectFrame и OleObjectFrame**
В интерфейс IOleObjectFrame и реализующий его класс OleObjectFrame добавлены новые свойства. Эти свойства используются для предоставления информации об объекте, встроенном в презентацию:  
EmbeddedFileExtension - Возвращает расширение файла для текущего встроенного объекта или пустую строку, если объект не является ссылкой  
EmbeddedFileLabel - Возвращает имя файла встроенного OLE‑объекта  
EmbeddedFileName - Возвращает путь к встроенному OLE‑объекту  
#### **В классы IAxis и Axis добавлено новое свойство CategoryAxisType**
Свойство CategoryAxisType определяет тип оси категорий.  

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
#### **В класс DataLabelFormat и интерфейс IDataLabelFormat добавлено новое свойство ShowLabelAsDataCallout**
Свойство ShowLabelAsDataCallout определяет, будет ли метка данных указанной диаграммы отображаться как подпись‑выноска или как метка данных.  

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
#### **В PdfOptions и XpsOptions добавлено свойство DrawSlidesFrame**
Булево свойство DrawSlidesFrame добавлено в интерфейсы Aspose.Slides.Export.IPdfOptions, Aspose.Slides.Export.IXpsOptions и в связанные классы Aspose.Slides.Export.PdfOptions, Aspose.Slides.Export.XpsOptions.  
Черный кадр вокруг каждого слайда будет отрисован, если это свойство установлено в «true».  

``` csharp

 using (Presentation pres = new Presentation("input.pptx"))

{

    pres.Save("output.pdf", SaveFormat.Pdf, new PdfOptions() { DrawSlidesFrame = true });

}

```