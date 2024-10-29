---
title: PowerPoint in PDF Notizen konvertieren
type: docs
weight: 50
url: /de/php-java/convert-powerpoint-to-pdf-with-notes/
keywords: "powerpoint in pdf mit notizen in java konvertieren"
description: "PowerPoint in PDF mit Notizen konvertieren"
---

## **PowerPoint in PDF mit benutzerdefinierter Foliengröße konvertieren**
Das folgende Beispiel zeigt, wie man eine Präsentation in ein PDF-Notizdokument mit benutzerdefinierter Foliengröße konvertiert. Dabei entspricht jeder Zoll 72.

```php
// Instanziere ein Presentation-Objekt, das eine Präsentationsdatei darstellt
  $presIn = new Presentation("SelectedSlides.pptx");
  $presOut = new Presentation();
  try {
    $slide = $presIn->getSlides()->get_Item(0);
    $presOut->getSlides()->insertClone(0, $slide);
    # Festlegen von Folientyp und Größe
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

## **PowerPoint in PDF im Notizen-Folienansicht konvertieren**
Die [**Save**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-) Methode der [**Presentation**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse kann verwendet werden, um die gesamte Präsentation in der Notizen-Folienansicht in PDF zu konvertieren. Die folgenden Code-Snippets aktualisieren die Beispielpräsentation zu PDF in der Notizen-Folienansicht.

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

Sie möchten möglicherweise den Aspose [PowerPoint zu PDF](https://products.aspose.app/slides/conversion/powerpoint-to-pdf) oder [PPT zu PDF](https://products.aspose.app/slides/conversion/ppt-to-pdf) Konverter ausprobieren. 

{{% /alert %}}