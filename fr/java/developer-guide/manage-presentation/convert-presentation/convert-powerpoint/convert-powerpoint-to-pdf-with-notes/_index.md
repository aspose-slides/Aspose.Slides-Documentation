---
title: Convertir les présentations PowerPoint en PDF avec notes en Java
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
- enregistrer la présentation au format PDF
- enregistrer PPT au format PDF
- enregistrer PPTX au format PDF
- exporter PPT en PDF
- exporter PPTX en PDF
- notes du présentateur
- PDF avec notes
- Java
- Aspose.Slides
description: "Convertir les formats PPT et PPTX en PDF avec notes à l’aide d’Aspose.Slides pour Java. Conserver les mises en page et les notes du présentateur pour des présentations professionnelles."
---
## **Aperçu**

Dans cet article, vous apprendrez comment convertir des présentations PowerPoint au format PDF avec les notes du présentateur à l’aide d’Aspose.Slides. Ce guide couvrira les étapes nécessaires et fournira des exemples de code pour vous aider à réaliser cette tâche efficacement. À la fin de cet article, vous serez capable de :

- Mettre en œuvre le processus de conversion pour transformer les diapositives PowerPoint en documents PDF tout en conservant les notes du présentateur.
- Personnaliser le PDF de sortie afin de garantir que les notes du présentateur sont incluses et formatées selon vos exigences.

## **Convertir PowerPoint en PDF avec notes**

La méthode `save` de la classe [Présentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/) peut être utilisée pour convertir une présentation PPT ou PPTX en PDF avec les notes du présentateur. Avec Aspose.Slides, il vous suffit de charger la présentation, de configurer les options de mise en page à l’aide de la classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/notescommentslayoutingoptions/) pour inclure les notes du présentateur, puis d’enregistrer le fichier au format PDF. L’extrait de code suivant montre comment convertir une présentation d’exemple en PDF en vue des diapositives de notes.

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

{{% alert color="info" %}} 
Vous voudrez peut-être consulter le [Convertisseur PowerPoint en PDF en ligne](https://products.aspose.app/slides/fr/conversion) d’Aspose. 
{{% /alert %}}