---
title: Converti presentazione in XPS
type: docs
weight: 60
url: /it/net/convert-presentation-to-xps/
---
**XPS** è anche ampiamente utilizzato per lo scambio di dati. Aspose.Slides per .NET si occupa della sua importanza e fornisce il supporto integrato per la conversione di una presentazione in documento XPS.

Il metodo **Save** esposto dalla classe Presentation può essere utilizzato per convertire l'intera presentazione in documento **XPS**. Inoltre, la classe **XpsOptions** espone la proprietà **SaveMetafileAsPng** che può essere impostata su true o false secondo le necessità.
## **Example**

``` 

 //Istanzia un oggetto Presentation che rappresenta un file di presentazione

Presentation pres = new Presentation("Conversion.ppt");

//Salvataggio della presentazione in un documento TIFF

pres.Save("converted.xps", Aspose.Slides.Export.SaveFormat.Xps);

``` 
## **Scarica esempio in esecuzione**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Converting%20to%20XPS)
## **Scarica codice di esempio**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

Per ulteriori dettagli, visita [Converti presentazioni PowerPoint in XPS in .NET](/slides/it/net/convert-powerpoint-to-xps/).

{{% /alert %}}