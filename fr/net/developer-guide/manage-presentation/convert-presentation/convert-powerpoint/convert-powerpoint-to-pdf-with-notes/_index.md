---
title: Convertir les présentations PowerPoint en PDF avec notes dans .NET
linktitle: PowerPoint en PDF avec notes
type: docs
weight: 50
url: /fr/net/convert-powerpoint-to-pdf-with-notes/
keywords:
- convertir PowerPoint
- convertir présentation
- convertir diapositive
- convertir PPT
- convertir PPTX
- PowerPoint en PDF
- présentation en PDF
- diapositive en PDF
- PPT en PDF
- PPTX en PDF
- enregistrer la présentation au format PDF
- enregistrer le PPT au format PDF
- enregistrer le PPTX au format PDF
- exporter le PPT en PDF
- exporter le PPTX en PDF
- notes du présentateur
- PDF avec notes
- .NET
- C#
- Aspose.Slides
description: "Convertir les formats PPT et PPTX en PDF avec notes à l’aide d’Aspose.Slides pour .NET. Préserver les mises en page et les notes du présentateur pour des présentations professionnelles."
---

## **Vue d’ensemble**

Dans cet article, vous apprendrez comment convertir des présentations PowerPoint au format PDF avec les notes du présentateur en utilisant Aspose.Slides. Ce guide couvrira les étapes nécessaires et fournira des exemples de code pour vous aider à accomplir cette tâche efficacement. À la fin de cet article, vous serez capable de :

- Mettre en œuvre le processus de conversion pour transformer les diapositives PowerPoint en documents PDF tout en préservant les notes du présentateur.  
- Personnaliser le PDF de sortie afin de garantir que les notes du présentateur sont incluses et formatées selon vos exigences.

## **Convertir PowerPoint en PDF avec notes**

La méthode `Save` de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) peut être utilisée pour convertir une présentation PPT ou PPTX en PDF avec les notes du présentateur. Avec Aspose.Slides, vous chargez simplement la présentation, configurez les options de mise en page à l'aide de la classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/) pour inclure les notes du présentateur, puis enregistrez le fichier au format PDF. L'extrait de code suivant montre comment convertir une présentation d'exemple en PDF en vue des diapositives de notes.
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

    // Enregistrer la présentation au format PDF avec les notes du présentateur.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}
```


{{% alert color="primary" %}} 
Vous voudrez peut‑être consulter le [Convertisseur PowerPoint en PDF en ligne d'Aspose](https://products.aspose.app/slides/conversion). 
{{% /alert %}}