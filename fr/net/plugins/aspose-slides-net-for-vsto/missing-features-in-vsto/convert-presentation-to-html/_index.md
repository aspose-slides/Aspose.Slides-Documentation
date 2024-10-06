---
title: Convertir une présentation en HTML
type: docs
weight: 40
url: /net/convert-presentation-to-html/
---

**HTML** est l'un des plusieurs formats largement utilisés pour l'échange de données. **Aspose.Slides pour .NET** prend en charge la conversion d'une présentation en HTML. Voici un extrait de code qui vous montre comment faire.
## **Exemple**
``` 

 //Instancier un objet Presentation qui représente un fichier de présentation

Presentation pres = new Presentation("Conversion.ppt");

HtmlOptions htmlOpt = new HtmlOptions();

htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);

//Sauvegarder la présentation en HTML

pres.Save("Converted.html", Aspose.Slides.Export.SaveFormat.Html, htmlOpt);

``` 
## **Télécharger l'exemple en cours d'exécution**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/Converting to HTML/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Converting%20to%20HTML)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode)
## **Télécharger le code d'exemple**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)

{{% alert color="primary" %}} 

Pour plus de détails, visitez [Convertir une présentation en HTML](/slides/net/convert-powerpoint-ppt-and-pptx-to-html/).

{{% /alert %}}