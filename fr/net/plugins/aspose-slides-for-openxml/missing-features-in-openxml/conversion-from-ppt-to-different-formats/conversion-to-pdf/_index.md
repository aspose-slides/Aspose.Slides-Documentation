---
title: Conversion en PDF
type: docs
weight: 30
url: /fr/net/conversion-to-pdf/
---

Les documents PDF sont largement utilisés comme format standard d'échange de documents entre organisations, secteurs gouvernementaux et particuliers. C'est un format populaire, de sorte que les développeurs sont souvent sollicités pour convertir des fichiers de présentation Microsoft PowerPoint en documents PDF. Conscients de cette possible exigence, Aspose.Slides for .NET prend en charge la conversion de présentations en documents PDF sans recourir à aucun autre composant.

**Aspose.Slides for .NET** propose la classe Presentation qui représente un fichier de présentation. La classe **Presentation** expose la méthode Save qui peut être appelée pour convertir l'ensemble de la présentation en un document **PDF**. La classe **PdfOptions** fournit des options pour créer le **PDF**, telles que JpegQuality, TextCompression, Compliance et d'autres. Ces options peuvent être utilisées pour obtenir le niveau de PDF souhaité.

``` csharp
 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to PDF.pdf";

//Instancier un objet Presentation qui représente un fichier de présentation

Presentation pres = new Presentation(srcFileName);

//Enregistrer la présentation au format PDF avec les options par défaut

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Pdf);
``` 
## **Télécharger le code d'exemple**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20PDF%20%28Aspose.Slides%29.zip)