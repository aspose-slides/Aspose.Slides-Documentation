---
title: Convertire la presentazione in HTML
type: docs
weight: 40
url: /it/net/convert-presentation-to-html/
---
**HTML** è uno dei numerosi formati ampiamente utilizzati per lo scambio di dati. **Aspose.Slides for .NET** fornisce il supporto per la conversione di una presentazione in HTML. Di seguito è riportato uno snippet di codice che mostra come fare.
## **Esempio**
``` 

 //Istanzia un oggetto Presentation che rappresenta un file di presentazione

Presentation pres = new Presentation("Conversion.ppt");

HtmlOptions htmlOpt = new HtmlOptions();

htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);

//Salva la presentazione in HTML

pres.Save("Converted.html", Aspose.Slides.Export.SaveFormat.Html, htmlOpt);

``` 
## **Scarica Esempio in Esecuzione**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Converting%20to%20HTML)
## **Scarica Codice di Esempio**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
Per ulteriori dettagli, visita [Converti presentazioni PowerPoint in HTML in .NET](/slides/it/net/convert-powerpoint-to-html/).
{{% /alert %}}