---
title: Convertir les présentations PowerPoint en PDF avec notes sur Android
linktitle: PowerPoint en PDF avec notes
type: docs
weight: 50
url: /fr/androidjava/convert-powerpoint-to-pdf-with-notes/
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
- Android
- Java
- Aspose.Slides
description: "Convertir les formats PPT et PPTX en PDF avec notes à l'aide d'Aspose.Slides pour Android via Java. Conserver la mise en page et les notes du présentateur pour des présentations professionnelles."
---
## **Vue d'ensemble**

Dans cet article, vous apprendrez comment convertir des présentations PowerPoint au format PDF avec les notes du présentateur à l'aide d'Aspose.Slides. Ce guide couvrira les étapes nécessaires et fournira des exemples de code pour vous aider à réaliser cette tâche efficacement. À la fin de cet article, vous serez capable de :

- Mettre en œuvre le processus de conversion pour transformer les diapositives PowerPoint en documents PDF tout en conservant les notes du présentateur.
- Personnaliser le PDF de sortie afin que les notes du présentateur soient incluses et formatées selon vos exigences.

Pour définir les dimensions et l’orientation de la page des notes avant l’exportation, consultez [Taille de la page des notes](/slides/fr/androidjava/notes-size/).

## **Convertir PowerPoint en PDF avec notes**

La méthode `save` de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/) peut être utilisée pour convertir une présentation PPT ou PPTX en PDF avec les notes du présentateur. Avec Aspose.Slides, il suffit de charger la présentation, de configurer les options de mise en page à l’aide de la classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/notescommentslayoutingoptions/) pour inclure les notes du présentateur, puis d’enregistrer le fichier au format PDF. Le fragment de code suivant montre comment convertir une présentation d’exemple en PDF en affichage des notes.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
	// Configurer les options PDF pour le rendu des notes du présentateur.
	NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
	notesOptions.setNotesPosition(NotesPositions.BottomFull); // Rendre les notes du présentateur sous la diapositive.

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(notesOptions);

	// Enregistrer la présentation en PDF avec les notes du présentateur.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="info" title="Remarque" %}}
Vous voudrez peut‑être consulter le [Convertisseur en ligne PowerPoint vers PDF d'Aspose](https://products.aspose.app/slides/fr/conversion).
{{% /alert %}}