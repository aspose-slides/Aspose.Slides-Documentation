---
title: Rendu en Tiff avec des dimensions définies par l'utilisateur
type: docs
weight: 40
url: /fr/net/rendered-as-tiff-by-user-defined-dimension/
---
L'exemple suivant montre comment convertir une présentation en document TIFF avec une taille d'image personnalisée en utilisant la classe **TiffOptions**.

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;


 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to Tiff as defined format.tiff";

//Instancier un objet Presentation qui représente un fichier de présentation

Presentation pres = new Presentation(srcFileName);

//Instancier la classe TiffOptions

Aspose.Slides.Export.TiffOptions opts = new Aspose.Slides.Export.TiffOptions();

//Définir le type de compression

opts.CompressionType = TiffCompressionTypes.Default;

//Types de compression

//Default - Spécifie le schéma de compression par défaut (LZW).

//None - Indique qu'aucune compression n'est appliquée.

//CCITT3

//CCITT4

//LZW

//RLE

//Depth - dépend du type de compression et ne peut pas être défini manuellement.

//Resolution unit - est toujours égal à "2" (points par pouce)

//Définir le DPI de l'image

opts.DpiX = 200;

opts.DpiY = 100;

//Définir la taille de l'image

opts.ImageSize = new Size(1728, 1078);

//Save the presentation to TIFF with specified image size

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff, opts);
```
## **Télécharger le code d'exemple**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20Tiff%20as%20defined%20format%20%28Aspose.Slides%29.zip)