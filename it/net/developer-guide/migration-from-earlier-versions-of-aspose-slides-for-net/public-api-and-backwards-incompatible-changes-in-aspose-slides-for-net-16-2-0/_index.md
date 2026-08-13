---
title: API Pubblica e Cambiamenti Incompatibili Retroattivi in Aspose.Slides per .NET 16.2.0
linktitle: Aspose.Slides per .NET 16.2.0
type: docs
weight: 230
url: /it/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/
keywords:
- migrazione
- codice legacy
- codice moderno
- approccio legacy
- approccio moderno
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Rivedi gli aggiornamenti dell'API pubblica e le modifiche incompatibili in Aspose.Slides per .NET per migrare senza problemi le tue soluzioni di presentazione PowerPoint PPT, PPTX e ODP."
---
{{% alert color="info" %}} 

Questa pagina elenca tutte le classi, i metodi, le proprietà e così via [added](/slides/it/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) o [removed](/slides/it/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/), e le altre modifiche introdotte con l'API Aspose.Slides per .NET 16.2.0.

{{% /alert %}} 
## **Modifiche all'API Pubblica**
#### **Le proprietà UpdateDateTimeFields e UpdateSlideNumberFields sono state rimosse**
Le proprietà UpdateDateTimeFields e UpdateSlideNumberFields sono state rimosse dalla classe Aspose.Slides.Presentation e dall'interfaccia Aspose.Slides.IPresentation.
La proprietà Text delle classi Aspose.Slides.TextFrame, Paragraph, Portion e delle interfacce Aspose.Slides.ITextFrame, IParagraph, IPortion restituisce il testo con i campi "datetime" aggiornati.
Inoltre le proprietà Presentation.DocumentProperties.CreatedTime, LastSavedTime e LastPrinted sono diventate di sola lettura.
#### **L'enumerazione Slides.Charts.CategoryAxisType è stata resa pubblica**
Utilizzata nelle proprietà IAxis.CategoryAxisType e Axis.CategoryAxisType per determinare il tipo di asse delle categorie.
CategoryAxisType.Auto - il tipo di asse delle categorie verrà determinato automaticamente durante la serializzazione (questo comportamento non è ancora implementato)
CategoryAxisType.Text - il tipo di asse delle categorie è Text
CategoryAxisType.Date - il tipo di asse delle categorie è DateTime
#### **Estrazione Rapida del Testo**
Il nuovo metodo statico GetPresentationText è stato aggiunto alla classe Presentation. Sono disponibili due overload per questo metodo:

``` csharp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)

``` 

L'argomento enum ExtractionMode indica la modalità per organizzare il risultato di testo e può essere impostato sui seguenti valori:
Unarranged - Il testo grezzo senza considerare la posizione sulla diapositiva
Arranged - Il testo è posizionato nello stesso ordine della diapositiva

La modalità Unarranged può essere usata quando la velocità è fondamentale, è più veloce della modalità Arranged.

PresentationText rappresenta il testo grezzo estratto dalla presentazione. Contiene una proprietà SlidesText dello spazio dei nomi Aspose.Slides.Util che restituisce un array di oggetti ISlideText. Ogni oggetto rappresenta il testo della diapositiva corrispondente. L'oggetto ISlideText ha le seguenti proprietà:
ISlideText.Text - Il testo delle forme della diapositiva
ISlideText.MasterText - Il testo delle forme della master page per questa diapositiva
ISlideText.LayoutText - Il testo delle forme della layout page per questa diapositiva
ISlideText.NotesText - Il testo delle forme della pagina delle note per questa diapositiva

C'è anche una classe SlideText che implementa l'interfaccia ISlideText.

La nuova API può essere utilizzata in questo modo:

``` csharp
using System;
using Aspose.Slides;

// Estrai il testo senza considerare la sua posizione sulla diapositiva (la modalità più veloce).
IPresentationText text1 = PresentationFactory.Instance.GetPresentationText(
    "presentation.ppt", TextExtractionArrangingMode.Unarranged);

Console.WriteLine(text1.SlidesText[0].Text);
Console.WriteLine(text1.SlidesText[0].LayoutText);
Console.WriteLine(text1.SlidesText[0].MasterText);
Console.WriteLine(text1.SlidesText[0].NotesText);

// Estrai il testo posizionato nello stesso ordine della diapositiva.
IPresentationText text2 = PresentationFactory.Instance.GetPresentationText(
    "presentation.pptx", TextExtractionArrangingMode.Arranged);

Console.WriteLine(text2.SlidesText[0].Text);
``` 
#### **Interfaccia ILegacyDiagram e classe LegacyDiagram sono state aggiunte**
L'interfaccia Aspose.Slides.ILegacyDiagram e la classe Aspose.Slides.LegacyDiagram sono state aggiunte per rappresentare l'oggetto diagramma legacy. L'oggetto diagramma legacy è un formato vecchio di diagrammi di PowerPoint 97-2003.
La nuova classe fornisce metodi per convertire il diagramma legacy in un oggetto SmartArt moderno modificabile o in un GroupShape modificabile.
#### **Nuovo membro dell'enumerazione Aspose.Slides.TextAlignment aggiunto (JustifyLow)**
È stato aggiunto un nuovo valore all'enumerazione TextAlignment: JustifyLow - allineamento Kashida basso.
#### **Nuove proprietà per Aspose.Slides.IOleObjectFrame e OleObjectFrame**
Una nuova proprietà è stata aggiunta all'interfaccia IOleObjectFrame e alla classe OleObjectFrame che implementa questa interfaccia. Queste proprietà forniscono informazioni su un oggetto incorporato nella presentazione:
EmbeddedFileExtension - Restituisce l'estensione del file per l'oggetto incorporato corrente o una stringa vuota se l'oggetto non è un collegamento
EmbeddedFileLabel - Restituisce il nome file dell'oggetto OLE incorporato
EmbeddedFileName - Restituisce il percorso dell'oggetto OLE incorporato
#### **Nuova proprietà CategoryAxisType aggiunta alle classi IAxis e Axis**
La proprietà CategoryAxisType specifica il tipo di asse delle categorie.

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
#### **Nuova proprietà ShowLabelAsDataCallout aggiunta alla classe DataLabelFormat e all'interfaccia IDataLabelFormat**
La proprietà ShowLabelAsDataCallout determina se l'etichetta dati del grafico specificato verrà visualizzata come chiamata dati o come etichetta dati.

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
#### **Proprietà DrawSlidesFrame aggiunta a PdfOptions e XpsOptions**
La proprietà booleana DrawSlidesFrame è stata aggiunta alle interfacce Aspose.Slides.Export.IPdfOptions, Aspose.Slides.Export.IXpsOptions e alle relative classi Aspose.Slides.Export.PdfOptions, Aspose.Slides.Export.XpsOptions. Il bordo nero attorno a ogni diapositiva verrà disegnato se questa proprietà è impostata su 'true'.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


 using (Presentation pres = new Presentation("input.pptx"))

{

    pres.Save("output.pdf", SaveFormat.Pdf, new PdfOptions() { DrawSlidesFrame = true });

}
```