---
title: Conversion en XPS
type: docs
weight: 40
url: /fr/net/conversion-to-xps/
---

Le format **XPS** est également largement utilisé pour l'échange de données. Aspose.Slides pour .NET prend en compte son importance et offre un support intégré pour la conversion d'une présentation en document XPS.

La méthode **Save** exposée par la classe Presentation peut être utilisée pour convertir l'ensemble de la présentation en document **XPS**. De plus, la classe **XpsOptions** expose la propriété **SaveMetafileAsPng** qui peut être définie sur vrai ou faux selon les besoins.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to XPS.xps";

//Instancier un objet Presentation qui représente un fichier de présentation

Presentation pres = new Presentation(srcFileName);

//Enregistrer la présentation au format TIFF

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Xps);

``` 
## **Télécharger le code d'exemple**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20XPS%20%28Aspose.Slides%29.zip)