---
title: Publiczne API i zmiany niezgodne wstecz w Aspose.Slides dla .NET 16.2.0
linktitle: Aspose.Slides dla .NET 16.2.0
type: docs
weight: 230
url: /pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/
keywords:
- migracja
- kod starszy
- nowoczesny kod
- podejście starsze
- nowoczesne podejście
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Przegląd aktualizacji publicznego API oraz wprowadzających zmiany w Aspose.Slides dla .NET, aby płynnie migrować rozwiązania prezentacji PowerPoint PPT, PPTX i ODP."
---
{{% alert color="info" %}} 

Ta strona wymienia wszystkie [dodane](/slides/pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) lub [usunięte](/slides/pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) klasy, metody, właściwości i tak dalej, oraz inne zmiany wprowadzone w API Aspose.Slides for .NET 16.2.0 API.

{{% /alert %}} 
## **Zmiany w publicznym API**
#### **Usunięto właściwości UpdateDateTimeFields i UpdateSlideNumberFields**
Właściwości UpdateDateTimeFields i UpdateSlideNumberFields zostały usunięte z klasy Aspose.Slides.Presentation oraz z interfejsu Aspose.Slides.IPresentation.
Właściwość Text klas Aspose.Slides.TextFrame, Paragraph, Portion oraz interfejsów Aspose.Slides.ITextFrame, IParagraph, IPortion zwraca tekst z zaktualizowanymi polami „datetime”.
Ponadto właściwości Presentation.DocumentProperties.CreatedTime, LastSavedTime i LastPrinted stały się tylko do odczytu.
#### **Enum Slides.Charts.CategoryAxisType został udostępniony publicznie**
Używany w właściwościach IAxis.CategoryAxisType i Axis.CategoryAxisType do określenia typu osi kategorii.
CategoryAxisType.Auto - typ osi kategorii będzie określany automatycznie podczas serializacji (to zachowanie nie jest obecnie zaimplementowane)
CategoryAxisType.Text - typ osi kategorii to Text
CategoryAxisType.Date - typ osi kategorii to DateTime
#### **Szybkie wyodrębnianie tekstu**
Do klasy Presentation dodano nową metodę statyczną GetPresentationText. Istnieją dwie przeciążenia tej metody:

``` csharp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)

``` 

Argument enum ExtractionMode określa tryb organizacji wyniku tekstowego i może przyjąć następujące wartości:
Unarranged - surowy tekst bez uwzględniania pozycji na slajdzie
Arranged - tekst jest ułożony w takiej samej kolejności jak na slajdzie

Tryb Unarranged można używać, gdy liczy się szybkość, jest szybszy niż tryb Arranged.

PresentationText reprezentuje surowy tekst wyodrębniony z prezentacji. Zawiera właściwość SlidesText z przestrzeni nazw Aspose.Slides.Util, która zwraca tablicę obiektów ISlideText. Każdy obiekt reprezentuje tekst na odpowiednim slajdzie. Obiekt ISlideText posiada następujące właściwości:
ISlideText.Text - tekst na kształtach slajdu
ISlideText.MasterText - tekst na kształtach strony master dla tego slajdu
ISlideText.LayoutText - tekst na kształtach strony układu dla tego slajdu
ISlideText.NotesText - tekst na kształtach strony notatek dla tego slajdu

Istnieje również klasa SlideText, która implementuje interfejs ISlideText.

Nowe API można używać w następujący sposób:

``` csharp
using System;
using Aspose.Slides;

// Wyodrębnij tekst bez uwzględniania jego pozycji na slajdzie (najszybszy tryb).
IPresentationText text1 = PresentationFactory.Instance.GetPresentationText(
    "presentation.ppt", TextExtractionArrangingMode.Unarranged);

Console.WriteLine(text1.SlidesText[0].Text);
Console.WriteLine(text1.SlidesText[0].LayoutText);
Console.WriteLine(text1.SlidesText[0].MasterText);
Console.WriteLine(text1.SlidesText[0].NotesText);

// Wyodrębnij tekst ułożony w takiej samej kolejności jak na slajdzie.
IPresentationText text2 = PresentationFactory.Instance.GetPresentationText(
    "presentation.pptx", TextExtractionArrangingMode.Arranged);

Console.WriteLine(text2.SlidesText[0].Text);
``` 
#### **Dodano interfejs ILegacyDiagram i klasę LegacyDiagram**
Dodano interfejs Aspose.Slides.ILegacyDiagram oraz klasę Aspose.Slides.LegacyDiagram, aby reprezentować obiekt diagramu legacy. Obiekt diagramu legacy jest starszym formatem diagramów z PowerPoint 97-2003.
Nowa klasa udostępnia metody konwertowania diagramu legacy na nowoczesny edytowalny obiekt SmartArt lub na edytowalny GroupShape.
#### **Dodano nowy członek enum Aspose.Slides.TextAlignment (JustifyLow)**
Dodano nowy członek wyliczenia TextAlignment:
JustifyLow - niskie wyrównanie Kashida.
#### **Nowe właściwości dla Aspose.Slides.IOleObjectFrame i OleObjectFrame**
Do interfejsu IOleObjectFrame i klasy OleObjectFrame implementującej ten interfejs dodano nowe właściwości. Służą one do dostarczania informacji o obiekcie osadzonym w prezentacji:
EmbeddedFileExtension - zwraca rozszerzenie pliku aktualnie osadzonego obiektu lub pusty ciąg, jeśli obiekt nie jest łączem
EmbeddedFileLabel - zwraca nazwę pliku osadzonego obiektu OLE
EmbeddedFileName - zwraca ścieżkę osadzonego obiektu OLE
#### **Dodano nową właściwość CategoryAxisType do klas IAxis i Axis**
Właściwość CategoryAxisType określa typ osi kategorii.

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
#### **Dodano nową właściwość ShowLabelAsDataCallout do klasy DataLabelFormat i interfejsu IDataLabelFormat**
Właściwość ShowLabelAsDataCallout określa, czy etykieta danych określonego wykresu będzie wyświetlana jako etykieta wywołania danych czy jako etykieta danych.

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
#### **Dodano właściwość DrawSlidesFrame do PdfOptions i XpsOptions**
Do interfejsów Aspose.Slides.Export.IPdfOptions, Aspose.Slides.Export.IXpsOptions oraz powiązanych klas Aspose.Slides.Export.PdfOptions, Aspose.Slides.Export.XpsOptions dodano właściwość boolowską DrawSlidesFrame.
Czarna ramka wokół każdego slajdu zostanie narysowana, jeśli ta właściwość zostanie ustawiona na “true”.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


 using (Presentation pres = new Presentation("input.pptx"))

{

    pres.Save("output.pdf", SaveFormat.Pdf, new PdfOptions() { DrawSlidesFrame = true });

}
```