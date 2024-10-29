---
title: Rendu en Tiff par Dimension Définie par l'Utilisateur
type: docs
weight: 40
url: /fr/net/rendered-as-tiff-by-user-defined-dimension/
---

L'exemple suivant montre comment convertir une présentation en document TIFF avec une taille d'image personnalisée en utilisant la classe **TiffOptions**.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Conversion en Tiff au format défini.tiff";

//Instancier un objet Presentation qui représente un fichier de présentation

Presentation pres = new Presentation(srcFileName);

//Instancier la classe TiffOptions

Aspose.Slides.Export.TiffOptions opts = new Aspose.Slides.Export.TiffOptions();

//Définir le type de compression

opts.CompressionType = TiffCompressionTypes.Default;

//Types de compression

//Default - Spécifie le schéma de compression par défaut (LZW).

//None - Spécifie aucune compression.

//CCITT3

//CCITT4

//LZW

//RLE

//Depth - dépend du type de compression et ne peut pas être défini manuellement.

//Unité de résolution - est toujours égale à "2" (points par pouce)

//Définir le DPI de l'image

opts.DpiX = 200;

opts.DpiY = 100;

//Définir la taille de l'image

opts.ImageSize = new Size(1728, 1078);

//Sauvegarder la présentation en TIFF avec la taille d'image spécifiée

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff, opts);

``` 
## **Télécharger le Code Source**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20Tiff%20as%20defined%20format%20%28Aspose.Slides%29.zip)