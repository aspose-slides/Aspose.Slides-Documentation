---
title: Convertir les présentations PowerPoint en PDF avec notes sous .NET
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
- enregistrer présentation au format PDF
- enregistrer PPT au format PDF
- enregistrer PPTX au format PDF
- exporter PPT en PDF
- exporter PPTX en PDF
- notes du présentateur
- PDF avec notes
- .NET
- C#
- Aspose.Slides
description: "Convertir les formats PPT et PPTX en PDF avec notes en utilisant Aspose.Slides pour .NET. Conserver la mise en page et les notes du présentateur pour des présentations professionnelles."
---
## **Aperçu**

Dans cet article, vous apprendrez comment convertir des présentations PowerPoint au format PDF avec les notes du présentateur à l'aide d'Aspose.Slides. Ce guide couvrira les étapes nécessaires et fournira des exemples de code pour vous aider à accomplir cette tâche efficacement. À la fin de cet article, vous serez capable de :

- Mettre en œuvre le processus de conversion pour transformer les diapositives PowerPoint en documents PDF tout en préservant les notes du présentateur.
- Personnaliser le PDF de sortie afin que les notes du présentateur soient incluses et formatées selon vos exigences.

Pour définir les dimensions et l'orientation de la page des notes avant l'exportation, consultez [Taille de la page des notes](/slides/fr/net/notes-size/).

## **Convertir PowerPoint en PDF avec notes**

La méthode `Save` de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/) peut être utilisée pour convertir une présentation PPT ou PPTX en PDF avec les notes du présentateur. Avec Aspose.Slides, il suffit de charger la présentation, de configurer les options de mise en page à l'aide de la classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/notescommentslayoutingoptions/) pour inclure les notes du présentateur, puis d'enregistrer le fichier au format PDF. Le fragment de code suivant montre comment convertir une présentation d'exemple en PDF en mode diapositives de notes.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

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

{{% alert color="info" %}} 
Vous pourriez vouloir consulter le [Convertisseur PowerPoint en PDF en ligne](https://products.aspose.app/slides/fr/conversion) d'Aspose. 
{{% /alert %}}