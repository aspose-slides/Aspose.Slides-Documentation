---
title: Convertir la présentation en HTML
type: docs
weight: 40
url: /fr/net/convert-presentation-to-html/
---

**HTML** est l'un des nombreux formats largement utilisés pour l'échange de données. **Aspose.Slides for .NET** offre une prise en charge de la conversion d'une présentation en HTML. Ci-dessous, un extrait de code qui montre comment faire.
## **Exemple**
``` 

 //Instantiate a Presentation object that represents a presentation file

Presentation pres = new Presentation("Conversion.ppt");

HtmlOptions htmlOpt = new HtmlOptions();

htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);

//Saving the presentation to HTML

pres.Save("Converted.html", Aspose.Slides.Export.SaveFormat.Html, htmlOpt);

``` 
## **Télécharger l'exemple fonctionnel**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Converting%20to%20HTML)
## **Télécharger le code source**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

Pour plus de détails, consultez [Convertir des présentations PowerPoint en HTML dans .NET](/slides/fr/net/convert-powerpoint-to-html/).

{{% /alert %}}