---
title: Convertir la présentation en TIFF avec notes
type: docs
weight: 50
url: /fr/net/convert-presentation-to-tiff-with-notes/
---

TIFF est l'un des nombreux formats d'image largement utilisés que Aspose.Slides for .NET prend en charge pour convertir une présentation avec notes en images. Vous pouvez également générer des miniatures de diapositives dans la vue Diapositive de notes. Ci-dessous, deux extraits de code montrent comment générer des images TIFF d'une présentation dans la vue Diapositive de notes.

La méthode [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save) exposée par la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) peut être utilisée pour convertir l'ensemble de la présentation en vue Diapositive de notes en TIFF. Vous pouvez également générer une miniature de diapositive en vue Diapositive de notes pour des diapositives individuelles.
## **Example**

``` 

  //Instantiate a Presentation object that represents a presentation file

 Presentation pres = new Presentation("Conversion.pptx");

 //Saving the presentation to TIFF notes

 pres.Save("ConvertedwithNotes.tiff", SaveFormat.TiffNotes);

``` 
## **Download Running Example**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Tiff%20conversion%20with%20note)
## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
Pour plus de détails, consultez [Convertir les présentations PowerPoint en TIFF avec notes en .NET](/slides/fr/net/convert-powerpoint-to-tiff-with-notes/).
{{% /alert %}}