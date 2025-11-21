---
title: Convertir des présentations PowerPoint en documents Word sous .NET
linktitle: PowerPoint vers Word
type: docs
weight: 110
url: /fr/net/convert-powerpoint-to-word/
keywords:
- convertir PowerPoint
- convertir présentation
- convertir diapositive
- convertir PPT
- convertir PPTX
- PowerPoint vers Word
- présentation vers Word
- diapositive vers Word
- PPT vers Word
- PPTX vers Word
- PowerPoint vers DOCX
- présentation vers DOCX
- diapositive vers DOCX
- PPT vers DOCX
- PPTX vers DOCX
- PowerPoint vers DOC
- présentation vers DOC
- diapositive vers DOC
- PPT vers DOC
- PPTX vers DOC
- enregistrer PPT en DOCX
- enregistrer PPTX en DOCX
- exporter PPT en DOCX
- exporter PPTX en DOCX
- .NET
- C#
- Aspose.Slides
description: "Convertissez les diapositives PowerPoint PPT et PPTX en documents Word modifiables en C# à l'aide d'Aspose.Slides pour .NET, en conservant la mise en page, les images et le formatage précis."
---

## **Vue d'ensemble**

Cet article fournit une solution pour les développeurs afin de convertir des présentations PowerPoint et OpenDocument en documents Word à l'aide d'Aspose.Slides for .NET et d'Aspose.Words for .NET. Le guide étape par étape vous accompagne à chaque étape du processus de conversion.

## **Convertir une présentation en document Word**

Suivez les instructions ci-dessous pour convertir une présentation PowerPoint ou OpenDocument en document Word :

1. Instanciez la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) et chargez un fichier de présentation.  
2. Instanciez les classes [Document](https://reference.aspose.com/words/net/aspose.words/document/) et [DocumentBuilder](https://reference.aspose.com/words/net/aspose.words/documentbuilder/) pour générer un document Word.  
3. Définissez la taille de page du document Word afin qu’elle corresponde à celle de la présentation à l’aide de la propriété [DocumentBuilder.PageSetup](https://reference.aspose.com/words/net/aspose.words/documentbuilder/pagesetup/).  
4. Définissez les marges du document Word à l’aide de la propriété [DocumentBuilder.PageSetup](https://reference.aspose.com/words/net/aspose.words/documentbuilder/pagesetup/).  
5. Parcourez toutes les diapositives de la présentation à l’aide de la propriété [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/).  
   - Générez une image de diapositive en utilisant la méthode `GetImage` de l’interface [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/) et enregistrez‑la dans un flux mémoire.  
   - Ajoutez l’image de la diapositive au document Word en utilisant la méthode `InsertImage` de la classe [DocumentBuilder](https://reference.aspose.com/words/net/aspose.words/documentbuilder/).  
6. Enregistrez le document Word dans un fichier.

Supposons que nous disposions d’une présentation « sample.pptx » qui ressemble à ceci :

![PowerPoint presentation](PowerPoint.png)

L’exemple de code C# suivant montre comment convertir la présentation PowerPoint en document Word :
```cs
// Charger un fichier de présentation.
using var presentation = new Presentation("sample.pptx");

// Créer les objets Document et DocumentBuilder.
var document = new Document();
var builder = new DocumentBuilder(document);

// Définir la taille de page dans le document Word.
var slideSize = presentation.SlideSize.Size;
builder.PageSetup.PageWidth = slideSize.Width;
builder.PageSetup.PageHeight = slideSize.Height;

// Définir les marges du document Word.
builder.PageSetup.LeftMargin = 0;
builder.PageSetup.RightMargin = 0;
builder.PageSetup.TopMargin = 0;
builder.PageSetup.BottomMargin = 0;

const float scaleX = 2, scaleY = 2;

// Parcourir toutes les diapositives de la présentation.
foreach (var slide in presentation.Slides)
{
    // Générer une image de diapositive et l'enregistrer dans un flux mémoire.
    using var image = slide.GetImage(scaleX, scaleY);
    using var imageStream = new MemoryStream();
    image.Save(imageStream, ImageFormat.Png);

    // Ajouter l'image de la diapositive au document Word.
    imageStream.Seek(0, SeekOrigin.Begin);
    builder.InsertImage(imageStream.ToArray(), builder.PageSetup.PageWidth, builder.PageSetup.PageHeight);

    builder.InsertBreak(BreakType.PageBreak);
}

// Enregistrer le document Word dans un fichier.
document.Save("output.docx");
```


Le résultat :

![Word document](Word.png)

{{% alert color="primary" %}} 

Essayez notre [**convertisseur en ligne PPT vers Word**](https://products.aspose.app/slides/conversion/ppt-to-word) pour voir ce que vous pouvez gagner en convertissant des présentations PowerPoint et OpenDocument en documents Word. 

{{% /alert %}}

## **FAQ**

**Quels composants doivent être installés pour convertir des présentations PowerPoint et OpenDocument en documents Word ?**

Vous devez simplement ajouter les packages NuGet respectifs pour [Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET) et [Aspose.Words for .NET](https://www.nuget.org/packages/Aspose.Words/) à votre projet C#. Les deux bibliothèques fonctionnent comme des API autonomes, et il n’est pas nécessaire d’avoir Microsoft Office installé.

**Tous les formats de présentation PowerPoint et OpenDocument sont‑ils pris en charge ?**

Aspose.Slides for .NET [prend en charge tous les formats de présentation](/slides/fr/net/supported-file-formats/), y compris PPT, PPTX, ODP et autres formats courants. Cela garantit que vous pouvez travailler avec des présentations créées dans diverses versions de Microsoft PowerPoint.