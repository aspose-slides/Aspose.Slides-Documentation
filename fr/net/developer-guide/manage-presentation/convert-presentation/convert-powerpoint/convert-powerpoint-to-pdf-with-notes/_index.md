---
title: Convertir des présentations PowerPoint en PDF avec notes dans .NET
linktitle: PowerPoint en PDF avec notes
type: docs
weight: 50
url: /fr/net/convert-powerpoint-to-pdf-with-notes/
keywords:
- convertir PowerPoint
- convertir la présentation
- convertir la diapositive
- convertir PPT
- convertir PPTX
- PowerPoint en PDF
- présentation en PDF
- diapositive en PDF
- PPT en PDF
- PPTX en PDF
- enregistrer la présentation au format PDF
- enregistrer PPT au format PDF
- enregistrer PPTX au format PDF
- exporter PPT en PDF
- exporter PPTX en PDF
- notes du présentateur
- PDF avec notes
- .NET
- C#
- Aspose.Slides
description: "Convertir les formats PPT et PPTX en PDF avec notes à l'aide d'Aspose.Slides pour .NET. Conserver les mises en page et les notes du présentateur pour des présentations professionnelles."
---

## **Vue d'ensemble**

Dans cet article, vous apprendrez comment convertir des présentations PowerPoint au format PDF avec les notes du présentateur à l'aide d'Aspose.Slides. Ce guide couvrira les étapes nécessaires et fournira des exemples de code pour vous aider à réaliser cette tâche efficacement. À la fin de cet article, vous serez capable de :

- Implémenter le processus de conversion pour transformer les diapositives PowerPoint en documents PDF tout en conservant les notes du présentateur.
- Personnaliser le PDF de sortie afin de garantir que les notes du présentateur sont incluses et mises en forme selon vos besoins.

## **Convertir PowerPoint en PDF avec notes**

La méthode `Save` de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) peut être utilisée pour convertir une présentation PPT ou PPTX en PDF avec les notes du présentateur. Avec Aspose.Slides, il suffit de charger la présentation, de configurer les options de mise en page à l'aide de la classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/) pour inclure les notes du présentateur, puis d'enregistrer le fichier au format PDF. L'extrait de code suivant montre comment convertir une présentation d'exemple en PDF en vue diapositive de notes.
```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Configurer les options PDF pour le rendu des notes du présentateur.
    PdfOptions pdfOptions = new PdfOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // Rendre les notes du présentateur sous la diapositive.
        }
    };

    // Enregistrer la présentation en PDF avec les notes du présentateur.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}
```


{{% alert color="primary" %}} 
Vous voudrez peut-être consulter le Convertisseur PowerPoint en PDF en ligne d'Aspose[Online PowerPoint to PDF Converter](https://products.aspose.app/slides/conversion). 
{{% /alert %}}