---
title: Convertir des présentations PowerPoint en documents Word en C#
linktitle: Convertir PowerPoint en Word
type: docs
weight: 110
url: /fr/net/convert-powerpoint-to-word/
keywords:
- PowerPoint en DOCX
- OpenDocument en DOCX
- présentation en DOCX
- diapositive en DOCX
- PPT en DOCX
- PPTX en DOCX
- ODP en DOCX
- PowerPoint en DOC
- OpenDocument en DOC
- présentation en DOC
- diapositive en DOC
- PPT en DOC
- PPTX en DOC
- ODP en DOC
- PowerPoint en Word
- OpenDocument en Word
- présentation en Word
- diapositive en Word
- PPT en Word
- PPTX en Word
- ODP en Word
- convertir PowerPoint
- convertir OpenDocument
- convertir présentation
- convertir diapositive
- convertir PPT
- convertir PPTX
- convertir ODP
- C#
- .NET
- Aspose.Slides
description: "Apprenez comment convertir facilement des présentations PowerPoint et OpenDocument en documents Word à l'aide d'Aspose.Slides pour .NET. Notre guide étape par étape avec du code C# d'exemple fournit la solution aux développeurs souhaitant optimiser leurs flux de travail documentaires."
---

## **Vue d'ensemble**

Cet article fournit une solution aux développeurs pour convertir les présentations PowerPoint et OpenDocument en documents Word en utilisant Aspose.Slides for .NET et Aspose.Words for .NET. Le guide étape par étape vous accompagne à chaque étape du processus de conversion.

## **Convertir une présentation en document Word**

Suivez les instructions ci‑dessous pour convertir une présentation PowerPoint ou OpenDocument en document Word :

1. Instancier la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) et charger un fichier de présentation.  
2. Instancier les classes [Document](https://reference.aspose.com/words/net/aspose.words/document/) et [DocumentBuilder](https://reference.aspose.com/words/net/aspose.words/documentbuilder/) pour créer un document Word.  
3. Définir la taille de la page du document Word pour qu’elle corresponde à celle de la présentation à l’aide de la propriété [DocumentBuilder.PageSetup](https://reference.aspose.com/words/net/aspose.words/documentbuilder/pagesetup/).  
4. Définir les marges du document Word à l’aide de la propriété [DocumentBuilder.PageSetup](https://reference.aspose.com/words/net/aspose.words/documentbuilder/pagesetup/).  
5. Parcourir toutes les diapositives de la présentation à l’aide de la propriété [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) :  
    - Générer une image de diapositive à l’aide de la méthode `GetImage` de l’interface [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/) et l’enregistrer dans un flux mémoire.  
    - Ajouter l’image de diapositive au document Word à l’aide de la méthode `InsertImage` de la classe [DocumentBuilder](https://reference.aspose.com/words/net/aspose.words/documentbuilder/).  
6. Enregistrer le document Word dans un fichier.

Supposons que nous ayons une présentation "sample.pptx" qui ressemble à ceci :

![Présentation PowerPoint](PowerPoint.png)

L’exemple de code C# suivant montre comment convertir la présentation PowerPoint en document Word :
```cs
// Charger un fichier de présentation.
using var presentation = new Presentation("sample.pptx");

// Créer les objets Document et DocumentBuilder.
var document = new Document();
var builder = new DocumentBuilder(document);

// Définir la taille de la page dans le document Word.
var slideSize = presentation.SlideSize.Size;
builder.PageSetup.PageWidth = slideSize.Width;
builder.PageSetup.PageHeight = slideSize.Height;

// Définir les marges dans le document Word.
builder.PageSetup.LeftMargin = 0;
builder.PageSetup.RightMargin = 0;
builder.PageSetup.TopMargin = 0;
builder.PageSetup.BottomMargin = 0;

const float scaleX = 2, scaleY = 2;

// Parcourir toutes les diapositives de la présentation.
foreach (var slide in presentation.Slides)
{
    // Générer une image de diapositive et l’enregistrer dans un flux mémoire.
    using var image = slide.GetImage(scaleX, scaleY);
    using var imageStream = new MemoryStream();
    image.Save(imageStream, ImageFormat.Png);

    // Ajouter l’image de diapositive au document Word.
    imageStream.Seek(0, SeekOrigin.Begin);
    builder.InsertImage(imageStream.ToArray(), builder.PageSetup.PageWidth, builder.PageSetup.PageHeight);

    builder.InsertBreak(BreakType.PageBreak);
}

// Enregistrer le document Word dans un fichier.
document.Save("output.docx");
```


Le résultat :

![Document Word](Word.png)

{{% alert color="primary" %}} 

Essayez notre [**Convertisseur PPT en Word en ligne**](https://products.aspose.app/slides/conversion/ppt-to-word) pour voir ce que vous pouvez gagner en convertissant des présentations PowerPoint et OpenDocument en documents Word. 

{{% /alert %}}

## **FAQ**

**Quels composants doivent être installés pour convertir les présentations PowerPoint et OpenDocument en documents Word ?**

Vous devez simplement ajouter les packages NuGet respectifs pour [Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET) et [Aspose.Words for .NET](https://www.nuget.org/packages/Aspose.Words/) à votre projet C#. Les deux bibliothèques fonctionnent comme des API autonomes et il n’est pas nécessaire d’installer Microsoft Office.

**Tous les formats de présentation PowerPoint et OpenDocument sont-ils pris en charge ?**

Aspose.Slides for .NET [prend en charge tous les formats de présentation](/slides/fr/net/supported-file-formats/), y compris PPT, PPTX, ODP et d’autres types de fichiers courants. Cela garantit que vous pouvez travailler avec des présentations créées dans diverses versions de Microsoft PowerPoint.