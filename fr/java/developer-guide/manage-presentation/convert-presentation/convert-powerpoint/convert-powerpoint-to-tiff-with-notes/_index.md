---
title: Convertir les présentations PowerPoint en TIFF avec des notes en Java
linktitle: PowerPoint vers TIFF avec notes
type: docs
weight: 100
url: /fr/java/convert-powerpoint-to-tiff-with-notes/
keywords:
- convertir PowerPoint
- convertir présentation
- convertir diapositive
- convertir PPT
- convertir PPTX
- PowerPoint en TIFF
- présentation en TIFF
- diapositive en TIFF
- PPT en TIFF
- PPTX en TIFF
- enregistrer PPT en TIFF
- enregistrer PPTX en TIFF
- exporter PPT en TIFF
- exporter PPTX en TIFF
- PowerPoint avec notes
- présentation avec notes
- diapositive avec notes
- PPT avec notes
- PPTX avec notes
- TIFF avec notes
- Java
- Aspose.Slides
description: "Convertissez les présentations PowerPoint en TIFF avec notes à l'aide d'Aspose.Slides pour Java. Apprenez à exporter les diapositives avec les notes du présentateur de manière efficace."
---

## **Aperçu**

Aspose.Slides for Java fournit une solution simple pour convertir des présentations PowerPoint et OpenDocument (PPT, PPTX et ODP) avec notes au format TIFF. Ce format est largement utilisé pour le stockage d'images de haute qualité, l'impression et l'archivage de documents. Avec Aspose.Slides, vous pouvez non seulement exporter des présentations complètes avec les notes du présentateur, mais aussi générer des miniatures de diapositives en affichage Diapositive de notes. Le processus de conversion est simple et efficace, en utilisant la méthode `save` de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) pour transformer l'ensemble de la présentation en une série d'images TIFF tout en conservant les notes et la mise en page.

## **Convertir une présentation en TIFF avec notes**

Enregistrer une présentation PowerPoint ou OpenDocument au format TIFF avec notes à l'aide d'Aspose.Slides for Java implique les étapes suivantes :

1. Instancier la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) : charger un fichier PowerPoint ou OpenDocument.  
1. Configurer les options de disposition de sortie : utilisez la classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/notescommentslayoutingoptions/) pour spécifier comment les notes et les commentaires doivent être affichés.  
1. Enregistrer la présentation au format TIFF : passez les options configurées à la méthode [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) .

Supposons que nous ayons un fichier "speaker_notes.pptx" contenant la diapositive suivante :

![La diapositive de présentation avec notes du présentateur](slide_with_notes.png)

Le fragment de code ci-dessous montre comment convertir la présentation en image TIFF en affichage Diapositive de notes en utilisant la méthode [setSlidesLayoutOptions](https://reference.aspose.com/slides/java/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) :

```java
// Instancier la classe Presentation qui représente un fichier de présentation.
Presentation presentation = new Presentation("speaker_notes.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull); // Afficher les notes sous la diapositive.

    // Configurer les options TIFF avec la mise en page des notes.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setDpiX(300);
    tiffOptions.setDpiY(300);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Enregistrer la présentation au format TIFF avec les notes du présentateur.
    presentation.save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```


Le résultat :

![L'image TIFF avec notes du présentateur](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Découvrez le Convertisseur gratuit PowerPoint en affiche d'Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).
{{% /alert %}}