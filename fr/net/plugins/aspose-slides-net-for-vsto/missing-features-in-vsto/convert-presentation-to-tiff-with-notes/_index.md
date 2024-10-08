---
title: Convertir une présentation en Tiff avec des notes
type: docs
weight: 50
url: /fr/net/convert-presentation-to-tiff-with-notes/
---

TIFF est l'un des nombreux formats d'image largement utilisés que Aspose.Slides pour .NET prend en charge pour convertir une présentation avec des notes en images. Vous pouvez également générer des miniatures de diapos dans la vue Notes. Ci-dessous se trouvent deux extraits de code qui montrent comment générer des images TIFF d'une présentation en vue Notes.

La méthode [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save) exposée par la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) peut être utilisée pour convertir l'ensemble de la présentation en vue Notes en TIFF. Vous pouvez également générer une miniature de diapositive en vue Notes pour des diapositives individuelles.
## **Exemple**

``` 

  //Instancier un objet Presentation qui représente un fichier de présentation

 Presentation pres = new Presentation("Conversion.pptx");

 //Sauvegarder la présentation au format TIFF avec des notes

 pres.Save("ConvertedwithNotes.tiff", SaveFormat.TiffNotes);

``` 
## **Télécharger l'exemple en cours d'exécution**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/Tiff conversion with note/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Tiff%20conversion%20with%20note)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode)
## **Télécharger le code d'exemple**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)

{{% alert color="primary" %}} 

Pour plus de détails, visitez [Convertir une présentation avec des notes](/slides/fr/net/convert-powerpoint-ppt-and-pptx-to-tiff-with-notes/).

{{% /alert %}}