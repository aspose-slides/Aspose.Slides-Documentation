---
title: Convertir une présentation en XPS
type: docs
weight: 60
url: /fr/net/convert-presentation-to-xps/
---

**XPS** format est également très utilisé pour l'échange de données. Aspose.Slides pour .NET prend en compte son importance et fournit la prise en charge intégrée de la conversion d'une présentation en document XPS.

La méthode **Save** exposée par la classe Presentation peut être utilisée pour convertir l'intégralité de la présentation en document **XPS**. De plus, la classe **XpsOptions** expose la propriété **SaveMetafileAsPng** qui peut être définie sur true ou false selon les besoins.
## **Example**

``` 

 //Instancie un objet Presentation qui représente un fichier de présentation

Presentation pres = new Presentation("Conversion.ppt");

//Enregistrement de la présentation dans un document XPS

pres.Save("converted.xps", Aspose.Slides.Export.SaveFormat.Xps);

``` 
## **Exemple en cours d'exécution**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Converting%20to%20XPS)
## **Télécharger le code d'exemple**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
Pour plus de détails, consultez [Convert PowerPoint Presentations to XPS in .NET](/slides/fr/net/convert-powerpoint-to-xps/).
{{% /alert %}}