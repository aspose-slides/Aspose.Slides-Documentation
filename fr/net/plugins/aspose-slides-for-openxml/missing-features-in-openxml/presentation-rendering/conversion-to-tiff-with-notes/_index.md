---
title: Conversion en TIFF avec notes
type: docs
weight: 10
url: /fr/net/conversion-to-tiff-with-notes/
---
TIFF est l'un des nombreux formats d'image largement utilisés que Aspose.Slides for .NET prend en charge pour convertir une présentation avec des notes en images. Vous pouvez également générer des miniatures de diapositives dans la vue Diapositive de notes. Vous trouverez ci-dessous deux extraits de code qui montrent comment générer des images TIFF d'une présentation dans la vue Diapositive de notes.

La méthode **Save** exposée par la classe **Presentation** peut être utilisée pour convertir l'intégralité de la présentation dans la vue Diapositive de notes en TIFF. Vous pouvez également générer une miniature de diapositive dans la vue Diapositive de notes pour des diapositives individuelles.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

string FilePath = @"..\..\..\Sample Files\";
string srcFileName = FilePath + "Tiff conversion with note.pptx";
string destFileName = FilePath + "Tiff conversion with note.tiff";

//Instanciez un objet Presentation qui représente un fichier de présentation
using (Presentation pres = new Presentation(srcFileName))
{
    //Placez les notes du présentateur sous chaque diapositive rendue
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    //Enregistrement de la présentation au format TIFF avec notes
    pres.Save(destFileName, SaveFormat.Tiff, tiffOptions);
}
``` 
## **Télécharger le code d'exemple**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Tiff%20conversion%20with%20note%20%28Aspose.Slides%29.zip)