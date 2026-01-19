---
title: Rendu en Tiff
type: docs
weight: 30
url: /fr/net/rendered-as-tiff/
---

Le format TIFF est connu pour sa flexibilité à prendre en charge des images et des données multipages. En tenant compte de l'importance et de la popularité du format TIFF, Aspose.Slides pour .NET offre la prise en charge de la conversion des présentations en document TIFF.  
Cet article explique les différentes options d'exportation TIFF :

- Conversion d'une présentation en TIFF avec la taille par défaut.  
- Conversion d'une présentation en TIFF avec une taille personnalisée.

La méthode **Save** exposée par la classe **Presentation** peut être appelée par les développeurs pour convertir l'intégralité de la présentation en document **TIFF**. De plus, la classe TiffOptions expose la propriété ImageSize qui permet au développeur de définir la taille de l'image si nécessaire.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Conversion to Tiff.tiff";

//Instantiate a Presentation object that represents a presentation file

using (Presentation pres = new Presentation(srcFileName))

{

    //Saving the presentation to TIFF document

    pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff);

}

``` 
## **Télécharger le code d'exemple**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20to%20Tiff%20%28Aspose.Slides%29.zip)