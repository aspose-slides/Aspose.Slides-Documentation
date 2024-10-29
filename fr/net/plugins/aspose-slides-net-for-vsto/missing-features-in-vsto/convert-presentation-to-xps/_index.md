---
title: Convertir une présentation en XPS
type: docs
weight: 60
url: /fr/net/convert-presentation-to-xps/
---

Le format **XPS** est également largement utilisé pour l'échange de données. Aspose.Slides pour .NET prend en compte son importance et offre un support intégré pour convertir une présentation en document **XPS**.

La méthode **Save** exposée par la classe Presentation peut être utilisée pour convertir l'ensemble de la présentation en document **XPS**. De plus, la classe **XpsOptions** expose la propriété **SaveMetafileAsPng** qui peut être définie sur vrai ou faux selon les besoins.
## **Exemple**

``` 

 //Instancier un objet Presentation qui représente un fichier de présentation

Presentation pres = new Presentation("Conversion.ppt");

//Sauvegarder la présentation en document TIFF

pres.Save("converted.xps", Aspose.Slides.Export.SaveFormat.Xps);

``` 
## **Télécharger l'exemple en cours d'exécution**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/Converting to XPS/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Converting%20to%20XPS)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode)
## **Télécharger le code d'exemple**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)

{{% alert color="primary" %}} 

Pour plus de détails, visitez [Conversion en XPS](/slides/fr/net/convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document/).

{{% /alert %}}