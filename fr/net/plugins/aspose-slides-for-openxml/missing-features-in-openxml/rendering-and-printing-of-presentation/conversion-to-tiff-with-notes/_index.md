---
title: Conversion en TIFF avec notes
type: docs
weight: 10
url: /fr/net/conversion-to-tiff-with-notes/
---

TIFF est l'un des nombreux formats d'image largement utilisés que Aspose.Slides for .NET prend en charge pour la conversion d'une présentation avec notes en images. Vous pouvez également générer des miniatures de diapositive dans la vue Notes Slide. Ci-dessous, deux extraits de code montrent comment générer des images TIFF d'une présentation en vue Notes Slide.

La méthode **Save** exposée par la classe **Presentation** peut être utilisée pour convertir l'intégralité de la présentation en vue Notes Slide au format TIFF. Vous pouvez également générer une miniature de diapositive en vue Notes Slide pour des diapositives individuelles.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Tiff conversion with note.pptx";

string destFileName = FilePath + "Tiff conversion with note.tiff";

//Instantiate a Presentation object that represents a presentation file

Presentation pres = new Presentation(srcFileName);

//Saving the presentation to TIFF notes

pres.Save(destFileName, SaveFormat.TiffNotes);

``` 
## **Télécharger le code d'exemple**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Tiff%20conversion%20with%20note%20%28Aspose.Slides%29.zip)