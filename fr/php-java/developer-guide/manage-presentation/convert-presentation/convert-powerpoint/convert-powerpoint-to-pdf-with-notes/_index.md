---
title: Convertir PowerPoint en PDF avec Notes
type: docs
weight: 50
url: /fr/php-java/convert-powerpoint-to-pdf-with-notes/
keywords: "convertir powerpoint en pdf avec notes en java"
description: "Convertir PowerPoint en PDF avec notes"
---

## **Convertir PowerPoint en PDF avec Taille de Diapositive Personnalisée**
L'exemple suivant montre comment convertir une présentation en document PDF contenant des notes avec une taille de diapositive personnalisée. Où chaque pouce équivaut à 72.

```php
// Instancier un objet Presentation qui représente un fichier de présentation
  $presIn = new Presentation("SelectedSlides.pptx");
  $presOut = new Presentation();
  try {
    $slide = $presIn->getSlides()->get_Item(0);
    $presOut->getSlides()->insertClone(0, $slide);
    # Définir le Type et la Taille de la Diapositive
    $presOut->getSlideSize()->setSize(612.0, 792.0, SlideSizeScaleType::EnsureFit);
    $pdfOptions = new PdfOptions();
    $pdfOptions->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomFull);
    $presOut->save("PDF-SelectedSlide.pdf", SaveFormat::Pdf, $pdfOptions);
  } finally {
    if (!java_is_null($presIn)) {
      $presIn->dispose();
    }
    if (!java_is_null($presOut)) {
      $presOut->dispose();
    }
  }
```

## **Convertir PowerPoint en PDF en Vue de Diapositive avec Notes**
La méthode [**Save**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-) exposée par la classe [**Presentation**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) peut être utilisée pour convertir l'ensemble de la présentation en vue de diapositive avec notes en PDF. Les extraits de code ci-dessous mettent à jour la présentation d'exemple en PDF en vue de diapositive avec notes.

```php
  $pres = new Presentation("presentation.pptx");
  try {
    $pdfOptions = new PdfOptions();
    $pdfOptions->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomFull);
    $pres->save($resourcesOutputPath . "PDF-Notes.pdf", SaveFormat::Pdf, $pdfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 

Vous voudrez peut-être consulter le convertisseur Aspose [PowerPoint en PDF](https://products.aspose.app/slides/conversion/powerpoint-to-pdf) ou [PPT en PDF](https://products.aspose.app/slides/conversion/ppt-to-pdf). 

{{% /alert %}}