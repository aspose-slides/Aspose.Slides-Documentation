---
title: Conversione in PDF
type: docs
weight: 30
url: /it/net/conversion-to-pdf/
---
I documenti PDF sono ampiamente utilizzati come formato standard per lo scambio di documenti tra organizzazioni, settori governativi e privati. È un formato popolare, quindi gli sviluppatori sono spesso richiesti di convertire i file di presentazione Microsoft PowerPoint in documenti PDF. Consapevoli di questa possibile esigenza, Aspose.Slides for .NET supporta la conversione delle presentazioni in documenti PDF senza utilizzare alcun altro componente.

**Aspose.Slides for .NET** offre la classe Presentation che rappresenta un file di presentazione. La classe **Presentation** espone il metodo Save che può essere chiamato per convertire l'intera presentazione in un documento **PDF**. La classe **PdfOptions** fornisce opzioni per la creazione del **PDF**, come JpegQuality, TextCompression, Compliance e altre. Queste opzioni possono essere utilizzate per ottenere lo standard desiderato del PDF.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to PDF.pdf";

//Istanzia un oggetto Presentation che rappresenta un file di presentazione

Presentation pres = new Presentation(srcFileName);

//Salva la presentazione in PDF con le opzioni predefinite

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Pdf);

``` 
## **Scarica il Codice di Esempio**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20PDF%20%28Aspose.Slides%29.zip)