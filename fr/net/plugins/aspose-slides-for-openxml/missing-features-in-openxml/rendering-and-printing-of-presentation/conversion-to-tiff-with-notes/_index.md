---  
title: Conversion en Tiff avec Notes  
type: docs  
weight: 10  
url: /fr/net/conversion-to-tiff-with-notes/  
---  

TIFF est l'un des plusieurs formats d'image largement utilisés que Aspose.Slides pour .NET prend en charge pour convertir une présentation avec des notes en images. Vous pouvez également générer des miniatures de diapositives dans la vue Diapositive de Notes. Ci-dessous, deux extraits de code montrent comment générer des images TIFF d'une présentation en vue Diapositive de Notes.

La méthode **Save** exposée par la classe **Presentation** peut être utilisée pour convertir l'ensemble de la présentation en vue Diapositive de Notes en TIFF. Vous pouvez également générer une miniature de diapositive en vue Diapositive de Notes pour des diapositives individuelles.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion Tiff avec note.pptx";

string destFileName = FilePath + "Conversion Tiff avec note.tiff";

//Instancier un objet Presentation qui représente un fichier de présentation

Presentation pres = new Presentation(srcFileName);

//Enregistrer la présentation en TIFF notes

pres.Save(destFileName, SaveFormat.TiffNotes);

```  
## **Télécharger le Code Exemple**  
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)  
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)  
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)  
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Tiff%20conversion%20with%20note%20%28Aspose.Slides%29.zip)