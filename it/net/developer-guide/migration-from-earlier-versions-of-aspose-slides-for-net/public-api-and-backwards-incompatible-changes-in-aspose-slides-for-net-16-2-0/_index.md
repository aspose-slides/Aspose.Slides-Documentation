---
title: API Pubbliche e Modifiche Incompatibili Retroattive in Aspose.Slides per .NET 16.2.0
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
description: "Esamina gli aggiornamenti dell'API pubblica e le modifiche incompatibili in Aspose.Slides per .NET per migrare agevolmente le tue soluzioni di presentazione PowerPoint PPT, PPTX e ODP."
---
{{% alert color="primary" %}} 

Questa pagina elenca tutte le classi, i metodi, le proprietà aggiunti o rimossi e così via, nonché le altre modifiche introdotte con l'API di Aspose.Slides per .NET 16.2.0.

{{% /alert %}} 
## **Modifiche API Pubbliche**
#### **Le proprietà UpdateDateTimeFields e UpdateSlideNumberFields sono state rimosse**
Le proprietà UpdateDateTimeFields e UpdateSlideNumberFields sono state rimosse dalla classe Aspose.Slides.Presentation e dall'interfaccia Aspose.Slides.IPresentation.  
La proprietà Text delle classi Aspose.Slides.TextFrame, Paragraph, Portion e delle interfacce Aspose.Slides.ITextFrame, IParagraph, IPortion restituisce il testo con i campi "datetime" aggiornati.  
Inoltre le proprietà Presentation.DocumentProperties.CreatedTime, LastSavedTime e LastPrinted sono diventate di sola lettura.  
#### **L'enumerazione Slides.Charts.CategoryAxisType è stata resa pubblica**
Usata nelle proprietà IAxis.CategoryAxisType e Axis.CategoryAxisType per determinare il tipo di asse di categoria.  
CategoryAxisType.Auto - il tipo di asse di categoria verrà determinato automaticamente durante la serializzazione (questo comportamento non è ancora implementato)  
CategoryAxisType.Text - il tipo di asse di categoria è Text  
CategoryAxisType.Date - il tipo di asse di categoria è DateTime  
#### **Estrazione veloce del testo**
Il nuovo metodo statico GetPresentationText è stato aggiunto alla classe Presentation. Esistono due overload di questo metodo:

``` csharp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)

``` 

L'argomento enum ExtractionMode indica la modalità per organizzare l'output del risultato testuale e può essere impostato sui seguenti valori:  
Unarranged - Il testo grezzo senza tener conto della posizione sulla diapositiva  
Arranged - Il testo è posizionato nello stesso ordine della diapositiva  

La modalità Unarranged può essere usata quando la velocità è fondamentale, è più veloce della modalità Arranged.  

PresentationText rappresenta il testo grezzo estratto dalla presentazione. Contiene una proprietà SlidesText dallo spazio dei nomi Aspose.Slides.Util che restituisce un array di oggetti ISlideText. Ogni oggetto rappresenta il testo della diapositiva corrispondente. L'oggetto ISlideText ha le seguenti proprietà:

ISlideText.Text - Il testo sulle forme della diapositiva  
ISlideText.MasterText - Il testo sulle forme della master page per questa diapositiva  
ISlideText.LayoutText - Il testo sulle forme della pagina di layout per questa diapositiva  
ISlideText.NotesText - Il testo sulle forme della pagina delle note per questa diapositiva  

Esiste anche una classe SlideText che implementa l'interfaccia ISlideText.  

La nuova API può essere utilizzata così:

``` csharp

 PresentationText text1 = Presentation.GetPresentationText("presentation.ppt");

Console.WriteLine(text1.SlidesText[0].Text);

Console.WriteLine(text1.SlidesText[0].LayoutText);

Console.WriteLine(text1.SlidesText[0].MasterText);

Console.WriteLine(text1.SlidesText[0].NotesText);

PresentationText text2 = Presentation.GetPresentationText("presentation.pptx", ExtractionMode.Unarranged)

``` 
#### **L'interfaccia ILegacyDiagram e la classe LegacyDiagram sono state aggiunte**
L'interfaccia Aspose.Slides.ILegacyDiagram e la classe Aspose.Slides.LegacyDiagram sono state aggiunte per rappresentare l'oggetto diagramma legacy. L'oggetto diagramma legacy è un formato vecchio di diagrammi proveniente da PowerPoint 97-2003.  
La nuova classe fornisce metodi per convertire il diagramma legacy in un oggetto SmartArt moderno modificabile o in un GroupShape modificabile.  
#### **Aggiunto nuovo membro dell'enumerazione Aspose.Slides.TextAlignment (JustifyLow)**
È stato aggiunto un nuovo membro dell'enumerazione TextAlignment:  
JustifyLow - Giustificazione Kashida bassa.  
#### **Nuove proprietà per Aspose.Slides.IOleObjectFrame e OleObjectFrame**
Sono state aggiunte nuove proprietà all'interfaccia IOleObjectFrame e alla classe OleObjectFrame che implementa questa interfaccia. Queste proprietà forniscono informazioni su un oggetto incorporato nella presentazione:  
EmbeddedFileExtension - Restituisce l'estensione file dell'oggetto incorporato corrente o una stringa vuota se l'oggetto non è un collegamento  
EmbeddedFileLabel - Restituisce il nome file dell'oggetto OLE incorporato  
EmbeddedFileName - Restituisce il percorso dell'oggetto OLE incorporato  
#### **Aggiunta nuova proprietà CategoryAxisType alle classi IAxis e Axis**
La proprietà CategoryAxisType specifica il tipo di asse di categoria.

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
#### **Aggiunta nuova proprietà ShowLabelAsDataCallout alla classe DataLabelFormat e all'interfaccia IDataLabelFormat**
La proprietà ShowLabelAsDataCallout determina se l'etichetta dati del grafico specificato verrà visualizzata come callout dati o come etichetta dati.

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
#### **Aggiunta la proprietà DrawSlidesFrame a PdfOptions e XpsOptions**
La proprietà booleana DrawSlidesFrame è stata aggiunta alle interfacce Aspose.Slides.Export.IPdfOptions, Aspose.Slides.Export.IXpsOptions e alle classi correlate Aspose.Slides.Export.PdfOptions, Aspose.Slides.Export.XpsOptions.  
Il bordo nero attorno a ciascuna diapositiva verrà disegnato se questa proprietà è impostata su 'true'.

``` csharp

 using (Presentation pres = new Presentation("input.pptx"))

{

    pres.Save("output.pdf", SaveFormat.Pdf, new PdfOptions() { DrawSlidesFrame = true });

}

```