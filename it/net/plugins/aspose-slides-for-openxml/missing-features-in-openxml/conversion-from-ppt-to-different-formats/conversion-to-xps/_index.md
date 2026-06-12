---
title: Conversione in XPS
type: docs
weight: 40
url: /it/net/conversion-to-xps/
---
**XPS** è anche ampiamente utilizzato per lo scambio di dati. Aspose.Slides per .NET si occupa della sua importanza e fornisce il supporto integrato per convertire una presentazione in documento XPS.

Il metodo **Save** esposto dalla classe Presentation può essere utilizzato per convertire l'intera presentazione in documento **XPS**. Inoltre, la classe **XpsOptions** espone la proprietà **SaveMetafileAsPng** che può essere impostata su true o false in base alle necessità.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to XPS.xps";

//Istanzia un oggetto Presentation che rappresenta un file di presentazione

Presentation pres = new Presentation(srcFileName);

//Salvataggio della presentazione in documento TIFF

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Xps);

``` 
## **Scarica Codice di Esempio**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20XPS%20%28Aspose.Slides%29.zip)