---
title: Convertir des présentations PowerPoint en PDF avec notes en Java
linktitle: PowerPoint en PDF avec notes
type: docs
weight: 50
url: /fr/java/convert-powerpoint-to-pdf-with-notes/
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
- enregistrer la présentation en PDF
- enregistrer PPT en PDF
- enregistrer PPTX en PDF
- exporter PPT en PDF
- exporter PPTX en PDF
- notes du présentateur
- PDF avec notes
- Java
- Aspose.Slides
description: "Convertir les formats PPT et PPTX en PDF avec notes à l'aide d'Aspose.Slides pour Java. Conserver les mises en page et les notes du présentateur pour des présentations professionnelles."
---
## **Aperçu**

Dans cet article, vous apprendrez comment convertir des présentations PowerPoint au format PDF avec les notes du présentateur à l'aide d'Aspose.Slides. Ce guide couvrira les étapes nécessaires et fournira des exemples de code pour vous aider à accomplir cette tâche efficacement. À la fin de cet article, vous serez capable de :

- Mettre en œuvre le processus de conversion pour transformer les diapositives PowerPoint en documents PDF tout en conservant les notes du présentateur.
- Personnaliser le PDF de sortie afin de garantir que les notes du présentateur sont incluses et formatées selon vos exigences.

Pour définir les dimensions et l’orientation de la page des notes avant l’exportation, consultez [Notes Page Size](/slides/fr/java/notes-size/).

## **Convertir PowerPoint en PDF avec notes**

La méthode `save` de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/) peut être utilisée pour convertir une présentation PPT ou PPTX en PDF avec les notes du présentateur. Avec Aspose.Slides, vous chargez simplement la présentation, configurez les options de mise en page à l’aide de la classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/notescommentslayoutingoptions/) pour inclure les notes du présentateur, puis vous enregistrez le fichier au format PDF. L’extrait de code suivant montre comment convertir une présentation d’exemple en PDF en vue « Notes Slide ».

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

// Configurer les options PDF pour le rendu des notes du présentateur.
NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(NotesPositions.BottomFull); // Rendre les notes du présentateur sous la diapositive.

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Save the presentation to PDF with speaker notes.
presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="info" title="Note" %}}
Vous voudrez peut-être consulter le [Convertisseur PowerPoint en PDF en ligne]https://products.aspose.app/slides/fr/conversion.
{{% /alert %}}