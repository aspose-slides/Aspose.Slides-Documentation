---
title: Public API i zmiany niekompatybilne wstecz w Aspose.Slides dla .NET 16.2.0
linktitle: Aspose.Slides dla .NET 16.2.0
type: docs
weight: 230
url: /pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/
keywords:
- migracja
- kod legacy
- kod nowoczesny
- podejście legacy
- podejście nowoczesne
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Przegląd aktualizacji publicznego API i zmian łamiących w Aspose.Slides dla .NET, aby płynnie migrować rozwiązania prezentacji PowerPoint PPT, PPTX i ODP."
---
{{% alert color="primary" %}} 

Ta strona wymienia wszystkie [added](/slides/pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) lub [removed](/slides/pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) klasy, metody, właściwości i podobne, a także inne zmiany wprowadzone w API Aspose.Slides for .NET 16.2.0.

{{% /alert %}} 
## **Public API Changes**
#### **Properties UpdateDateTimeFields and UpdateSlideNumberFields Have Been Removed**
Właściwości UpdateDateTimeFields i UpdateSlideNumberFields zostały usunięte z klasy Aspose.Slides.Presentation oraz z interfejsu Aspose.Slides.IPresentation.
Właściwość Text klas Aspose.Slides.TextFrame, Paragraph, Portion oraz interfejsów Aspose.Slides.ITextFrame, IParagraph, IPortion zwraca tekst z zaktualizowanymi polami „datetime”.
Ponadto właściwości Presentation.DocumentProperties.CreatedTime, LastSavedTime i LastPrinted stały się tylko do odczytu.
#### **Enum Slides.Charts.CategoryAxisType Has Been Switched to Public**
Używany w właściwościach IAxis.CategoryAxisType i Axis.CategoryAxisType do określania typu osi kategorii.
CategoryAxisType.Auto – typ osi kategorii będzie określany automatycznie podczas serializacji (to zachowanie nie jest obecnie zaimplementowane)
CategoryAxisType.Text – typ osi kategorii to Text
CategoryAxisType.Date – typ osi kategorii to DateTime
#### **Fast Text Extraction**
Do klasy Presentation dodano nową metodę statyczną GetPresentationText. Istnieją dwa przeciążenia tej metody:

``` csharp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)

``` 

Argument enum ExtractionMode wskazuje tryb organizacji wyniku tekstowego i może przyjąć następujące wartości:
Unarranged – surowy tekst bez uwzględniania pozycji na slajdzie
Arranged – tekst jest ułożony w takiej samej kolejności jak na slajdzie

Tryb Unarranged może być używany, gdy liczy się prędkość, jest szybszy niż tryb Arranged.

PresentationText reprezentuje surowy tekst wyodrębniony z prezentacji. Zawiera właściwość SlidesText z przestrzeni nazw Aspose.Slides.Util, która zwraca tablicę obiektów ISlideText. Każdy obiekt reprezentuje tekst na odpowiednim slajdzie. Obiekt ISlideText posiada następujące właściwości:

ISlideText.Text – tekst na kształtach slajdu
ISlideText.MasterText – tekst na kształtach strony nadrzędnej dla tego slajdu
ISlideText.LayoutText – tekst na kształtach strony układu dla tego slajdu
ISlideText.NotesText – tekst na kształtach strony notatek dla tego slajdu

Istnieje także klasa SlideText implementująca interfejs ISlideText.

Nowe API można używać w następujący sposób:

``` csharp

 PresentationText text1 = Presentation.GetPresentationText("presentation.ppt");

Console.WriteLine(text1.SlidesText[0].Text);

Console.WriteLine(text1.SlidesText[0].LayoutText);

Console.WriteLine(text1.SlidesText[0].MasterText);

Console.WriteLine(text1.SlidesText[0].NotesText);

PresentationText text2 = Presentation.GetPresentationText("presentation.pptx", ExtractionMode.Unarranged)

``` 
#### **ILegacyDiagram Interface and LegacyDiagram Class Have Been Added**
Interfejs Aspose.Slides.ILegacyDiagram i klasa Aspose.Slides.LegacyDiagram zostały dodane w celu reprezentacji obiektu diagramu legacy. Obiekt diagramu legacy jest starszym formatem diagramów z PowerPoint 97-2003.
Nowa klasa udostępnia metody konwertowania diagramu legacy na nowoczesny edytowalny obiekt SmartArt lub na edytowalny GroupShape.
#### **New Aspose.Slides.TextAlignment Enum Member Added (JustifyLow)**
Dodano nowy element wyliczenia TextAlignment:
JustifyLow – niskie uzasadnienie Kashida.
#### **New Properties for Aspose.Slides.IOleObjectFrame and OleObjectFrame**
Do interfejsu IOleObjectFrame i klasy OleObjectFrame implementującej ten interfejs dodano nowe właściwości. Właściwości te służą do udostępniania informacji o obiekcie osadzonym w prezentacji:
EmbeddedFileExtension – zwraca rozszerzenie pliku aktualnie osadzonego obiektu lub pusty ciąg, jeśli obiekt nie jest łączem
EmbeddedFileLabel – zwraca nazwę pliku osadzonego obiektu OLE
EmbeddedFileName – zwraca ścieżkę osadzonego obiektu OLE
#### **New Property CategoryAxisType Has Been Added to IAxis and Axis Classes**
Właściwość CategoryAxisType określa typ osi kategorii.

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
#### **New Property ShowLabelAsDataCallout Has Been Added to DataLabelFormat Class and IDataLabelFormat Interface**
Właściwość ShowLabelAsDataCallout określa, czy etykieta danych wykresu ma być wyświetlana jako odnośnik danych, czy jako etykieta danych.

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
#### **Property DrawSlidesFrame Has Been Added to PdfOptions and XpsOptions**
Właściwość boolowska DrawSlidesFrame została dodana do interfejsów Aspose.Slides.Export.IPdfOptions, Aspose.Slides.Export.IXpsOptions oraz do powiązanych klas Aspose.Slides.Export.PdfOptions, Aspose.Slides.Export.XpsOptions.
Czarna ramka wokół każdego slajdu zostanie narysowana, jeśli ta właściwość zostanie ustawiona na 'true'.

``` csharp

 using (Presentation pres = new Presentation("input.pptx"))
{
    pres.Save("output.pdf", SaveFormat.Pdf, new PdfOptions() { DrawSlidesFrame = true });
}
```