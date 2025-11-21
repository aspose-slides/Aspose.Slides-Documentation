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
description: Обзор обновлений публичного API и разрушающих изменений в Aspose.Slides для .NET, позволяющий плавно мигрировать ваши решения презентаций PowerPoint PPT, PPTX и ODP.
---

{{% alert color="primary" %}} 

Эта страница перечисляет все [добавленные](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) или [удалённые](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) классы, методы, свойства и т.д., а также другие изменения, внесённые в API Aspose.Slides for .NET 16.2.0.

{{% /alert %}} 
## **Изменения публичного API**
#### **Свойства UpdateDateTimeFields и UpdateSlideNumberFields удалены**
Свойства UpdateDateTimeFields и UpdateSlideNumberFields удалены из класса Aspose.Slides.Presentation и из интерфейса Aspose.Slides.IPresentation.  
Свойство Text классов Aspose.Slides.TextFrame, Paragraph, Portion и интерфейсов Aspose.Slides.ITextFrame, IParagraph, IPortion возвращает текст с обновлёнными полями «datetime».  
Также свойства Presentation.DocumentProperties.CreatedTime, LastSavedTime и LastPrinted стали только для чтения.  
#### **Перечисление Slides.Charts.CategoryAxisType сделано публичным**
Используется в свойствах IAxis.CategoryAxisType и Axis.CategoryAxisType для определения типа категориальной оси.  
CategoryAxisType.Auto — тип оси будет определён автоматически во время сериализации (поведение пока не реализовано)  
CategoryAxisType.Text — тип оси — Text  
CategoryAxisType.Date — тип оси — DateTime  
#### **Быстрое извлечение текста**
В класс Presentation добавлен новый статический метод GetPresentationText. У метода две перегрузки:

``` csharp
PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)
``` 

Аргумент перечисления ExtractionMode указывает режим организации вывода текстового результата и может принимать следующие значения:  
Unarranged — необработанный текст без учёта положения на слайде  
Arranged — текст расположен в том же порядке, что и на слайде  

Режим Unarranged можно использовать, когда важна скорость; он быстрее, чем режим Arranged.

PresentationText представляет необработанный текст, извлечённый из презентации. Он содержит свойство SlidesText из пространства имён Aspose.Slides.Util, которое возвращает массив объектов ISlideText. Каждый объект представляет текст на соответствующем слайде. Объект ISlideText имеет следующие свойства:

ISlideText.Text — текст фигур на слайде  
ISlideText.MasterText — текст фигур на мастер‑странице для этого слайда  
ISlideText.LayoutText — текст фигур на странице макета для этого слайда  
ISlideText.NotesText — текст фигур на странице заметок для этого слайда  

Существует также класс SlideText, реализующий интерфейс ISlideText.

Новый API можно использовать так:

``` csharp
PresentationText text1 = Presentation.GetPresentationText("presentation.ppt");

Console.WriteLine(text1.SlidesText[0].Text);

Console.WriteLine(text1.SlidesText[0].LayoutText);

Console.WriteLine(text1.SlidesText[0].MasterText);

Console.WriteLine(text1.SlidesText[0].NotesText);

PresentationText text2 = Presentation.GetPresentationText("presentation.pptx", ExtractionMode.Unarranged)
``` 
#### **Добавлены интерфейс ILegacyDiagram и класс LegacyDiagram**
Интерфейс Aspose.Slides.ILegacyDiagram и класс Aspose.Slides.LegacyDiagram добавлены для представления устаревшего объекта диаграммы. Устаревший объект диаграммы — это формат диаграмм из PowerPoint 97‑2003.  
Новый класс предоставляет методы для преобразования устаревшей диаграммы в современный редактируемый объект SmartArt или в редактируемый GroupShape.  
#### **В перечисление Aspose.Slides.TextAlignment добавлен новый член (JustifyLow)**
В перечисление TextAlignment добавлен новый член:  
JustifyLow — выравнивание Кашида низко.  
#### **Новые свойства для Aspose.Slides.IOleObjectFrame и OleObjectFrame**
В интерфейс IOleObjectFrame и класс OleObjectFrame, реализующий этот интерфейс, добавлены новые свойства, используемые для предоставления информации об объекте, внедрённом в презентацию:  
EmbeddedFileExtension — возвращает расширение файла текущего внедрённого объекта или пустую строку, если объект не является ссылкой  
EmbeddedFileLabel — возвращает имя файла внедрённого OLE‑объекта  
EmbeddedFileName — возвращает путь к внедрённому OLE‑объекту  
#### **В классы IAxis и Axis добавлено свойство CategoryAxisType**
Свойство CategoryAxisType указывает тип категориальной оси.

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
#### **В класс DataLabelFormat и интерфейс IDataLabelFormat добавлено свойство ShowLabelAsDataCallout**
Свойство ShowLabelAsDataCallout определяет, будет ли метка данных указанной диаграммы отображаться как выноска данных или как обычная метка.

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
Булево свойство DrawSlidesFrame добавлено в интерфейсы Aspose.Slides.Export.IPdfOptions, Aspose.Slides.Export.IXpsOptions и в соответствующие классы Aspose.Slides.Export.PdfOptions, Aspose.Slides.Export.XpsOptions.  
Чёрная рамка вокруг каждого слайда будет отрисована, если это свойство установлено в «true».

``` csharp
using (Presentation pres = new Presentation("input.pptx"))
{
    pres.Save("output.pdf", SaveFormat.Pdf, new PdfOptions() { DrawSlidesFrame = true });
}
```