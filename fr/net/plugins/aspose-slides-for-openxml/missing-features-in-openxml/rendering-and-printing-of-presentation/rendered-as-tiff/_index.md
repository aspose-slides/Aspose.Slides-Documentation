---
title: Rendu en Tiff
type: docs
weight: 30
url: /net/rendered-as-tiff/
---

Le format TIFF est reconnu pour sa flexibilité à accueillir des images et des données multipage. Compte tenu de l'importance et de la popularité du format TIFF, Aspose.Slides pour .NET offre le support pour convertir des présentations en documents TIFF. Cet article explique comment différentes options d'exportation TIFF :

- Conversion de la présentation en TIFF avec taille par défaut.
- Conversion de la présentation en TIFF avec taille personnalisée.

La méthode **Save** exposée par la classe **Presentation** peut être appelée par les développeurs pour convertir l'ensemble de la présentation en document **TIFF**. De plus, la classe TiffOptions expose la propriété ImageSize permettant au développeur de définir la taille de l'image si nécessaire.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Conversion to Tiff.tiff";

//Instancier un objet Presentation qui représente un fichier de présentation

using (Presentation pres = new Presentation(srcFileName))

{

    //Enregistrer la présentation en document TIFF

    pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff);

}

``` 
## **Télécharger le code source d'exemple**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20to%20Tiff%20%28Aspose.Slides%29.zip)