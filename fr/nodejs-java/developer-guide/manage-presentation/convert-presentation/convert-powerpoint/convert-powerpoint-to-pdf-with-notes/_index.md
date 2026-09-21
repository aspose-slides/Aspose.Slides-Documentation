---
title: Convertir des présentations PowerPoint en PDF avec notes en JavaScript
linktitle: PowerPoint en PDF avec notes
type: docs
weight: 50
url: /fr/nodejs-java/convert-powerpoint-to-pdf-with-notes/
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
- exporter le PPT au format PDF
- exporter le PPTX au format PDF
- notes du présentateur
- PDF avec notes
- Node.js
- JavaScript
- Aspose.Slides
description: "Convertir les formats PPT et PPTX en PDF avec notes en JavaScript à l'aide d'Aspose.Slides pour Node.js. Conserver les mises en page et les notes du présentateur pour des présentations professionnelles."
---
## **Vue d'ensemble**

Dans cet article, vous apprendrez comment convertir des présentations PowerPoint au format PDF avec les notes du présentateur à l’aide d’Aspose.Slides. Ce guide couvrira les étapes nécessaires et fournira des exemples de code pour vous aider à accomplir cette tâche efficacement. À la fin de cet article, vous serez capable de :

- Mettre en œuvre le processus de conversion pour transformer les diapositives PowerPoint en documents PDF tout en conservant les notes du présentateur.
- Personnaliser le PDF de sortie afin que les notes du présentateur soient incluses et formatées selon vos exigences.

Pour définir les dimensions et l’orientation de la page des notes avant l’exportation, voir [Taille de la page des notes](/slides/fr/nodejs-java/notes-size/).

## **Convertir PowerPoint en PDF avec notes**

La méthode `save` de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/) peut être utilisée pour convertir une présentation PPT ou PPTX en PDF avec les notes du présentateur. Avec Aspose.Slides, il suffit de charger la présentation, de configurer les options de mise en page à l’aide de la classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/notescommentslayoutingoptions/) pour inclure les notes du présentateur, puis d’enregistrer le fichier au format PDF. L’extrait de code suivant montre comment convertir une présentation d’exemple en PDF en affichage diapositive de notes.

```js
const asposeSlides = require("aspose.slides.via.java");

let presentation = new asposeSlides.Presentation("sample.pptx");

// Configurer les options PDF pour le rendu des notes du présentateur.
let notesOptions = new asposeSlides.NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(asposeSlides.NotesPositions.BottomFull); // Rendre les notes du présentateur sous la diapositive.

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Save the presentation to PDF with speaker notes.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="info" title="Note" %}}

Vous voudrez peut-être consulter le [Convertisseur PowerPoint en PDF en ligne](https://products.aspose.app/slides/fr/conversion) d’Aspose.

{{% /alert %}}