---
title: Conversion en XPS
type: docs
weight: 40
url: /fr/net/conversion-to-xps/
---

**XPS** est également largement utilisé pour l’échange de données. Aspose.Slides pour .NET prend en compte son importance et fournit une prise en charge native de la conversion d’une présentation en document XPS.

La méthode **Save** exposée par la classe Presentation peut être utilisée pour convertir l’ensemble de la présentation en document **XPS**. De plus, la classe **XpsOptions** expose la propriété **SaveMetafileAsPng** qui peut être définie sur true ou false selon les besoins.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to XPS.xps";

//Instantiate a Presentation object that represents a presentation file

Presentation pres = new Presentation(srcFileName);

//Saving the presentation to TIFF document

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Xps);

``` 
## **Télécharger le code d'exemple**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20XPS%20%28Aspose.Slides%29.zip)