---
title: Conversion en PDF
type: docs
weight: 30
url: /fr/net/conversion-to-pdf/
---

Les documents PDF sont largement utilisés comme un format standard d'échange de documents entre organisations, secteurs gouvernementaux et individus. C'est un format populaire, donc les développeurs sont souvent invités à convertir des fichiers de présentation Microsoft PowerPoint en documents PDF. Réalisant cette éventuelle exigence, Aspose.Slides pour .NET supporte la conversion de présentations en documents PDF sans utiliser d'autre composant.

**Aspose.Slides pour .NET** offre la classe Presentation qui représente un fichier de présentation. La classe **Presentation** expose la méthode Save qui peut être appelée pour convertir l'ensemble de la présentation en un document **PDF**. La classe **PdfOptions** fournit des options pour créer le **PDF** telles que JpegQuality, TextCompression, Compliance et d'autres. Ces options peuvent être utilisées pour obtenir le standard de PDF souhaité.

``` csharp

 string FilePath = @"..\..\..\Fichiers d'échantillon\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Conversion en PDF.pdf";

//Instancier un objet Presentation qui représente un fichier de présentation

Presentation pres = new Presentation(srcFileName);

//Sauvegarder la présentation en PDF avec les options par défaut

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Pdf);

``` 
## **Télécharger le code d'échantillon**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20PDF%20%28Aspose.Slides%29.zip)