---
title: Convertir PowerPoint en Word
type: docs
weight: 110
url: /fr/net/convert-powerpoint-to-word/
keywords:
- Convertir PowerPoint
- PPT
- PPTX
- Présentation
- Word
- DOCX
- DOC
- PPTX en DOCX
- PPT en DOC
- PPTX en DOC
- PPT en DOCX
- C#
- Csharp
- .NET
- Aspose.Slides
description: "Convertir une présentation PowerPoint en Word en C# ou .NET"
---

Si vous prévoyez d'utiliser du contenu textuel ou des informations provenant d'une présentation (PPT ou PPTX) de nouvelles manières, vous pourriez bénéficier de la conversion de la présentation en Word (DOC ou DOCX).

* Comparé à Microsoft PowerPoint, l'application Microsoft Word est mieux équipée en outils ou fonctionnalités pour le contenu.
* En plus des fonctions d'édition dans Word, vous pourriez également bénéficier de fonctionnalités de collaboration, d'impression et de partage améliorées.

{{% alert color="primary" %}}

Vous voudrez peut-être essayer notre [**Convertisseur en ligne de présentation à Word**](https://products.aspose.app/slides/conversion/ppt-to-word) pour voir ce que vous pourriez gagner en travaillant avec du contenu textuel provenant des diapositives.

{{% /alert %}}

### **Aspose.Slides et Aspose.Words**

Pour convertir un fichier PowerPoint (PPTX ou PPT) en Word (DOCX ou DOC), vous avez besoin à la fois de [Aspose.Slides pour .NET](https://products.aspose.com/slides/net/) et de [Aspose.Words pour .NET](https://products.aspose.com/words/net/).

En tant qu'API autonome, [Aspose.Slides](https://products.aspose.app/slides) pour .NET fournit des fonctions qui vous permettent d'extraire des textes des présentations.

[Aspose.Words](https://docs.aspose.com/words/net/) est une API avancée de traitement de documents qui permet aux applications de générer, modifier, convertir, rendre, imprimer des fichiers et effectuer d'autres tâches avec des documents sans utiliser Microsoft Word.

## **Convertir PowerPoint en Word**

1. Ajoutez ces espaces de noms à votre fichier program.cs :

```c#
using Aspose.Slides;
using Aspose.Words;
using System.IO;
```

2. Utilisez ce petit extrait de code pour convertir le PowerPoint en Word :

```c#
using var presentation = new Presentation("sample.pptx");

var doc = new Document();
var builder = new DocumentBuilder(doc);

foreach (var slide in presentation.Slides)
{
    // génère une image de la diapositive et l'enregistre dans un flux mémoire
    using var image = slide.GetImage(1, 1);
    using var imageStream = new MemoryStream();
    image.Save(imageStream, ImageFormat.Png);

    imageStream.Seek(0, SeekOrigin.Begin);
    builder.InsertImage(imageStream.ToArray());

    // insère les textes de la diapositive
    foreach (var shape in slide.Shapes)
    {
        if (shape is AutoShape autoShape)
        {
            builder.Writeln(autoShape.TextFrame.Text);
        }
    }

    builder.InsertBreak(BreakType.PageBreak);
}

doc.Save("output.docx");
```