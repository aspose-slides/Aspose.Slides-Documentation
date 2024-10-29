---
title: PowerPoint in SWF Flash konvertieren
type: docs
weight: 80
url: /de/php-java/convert-powerpoint-to-swf-flash/
keywords: "PPT, PPTX zu SWF"
description: "Konvertieren Sie PowerPoint PPT, PPTX in SWF"
---

## **Konvertiere PPT(X) in SWF**
Die [Save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) Methode der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) Klasse kann verwendet werden, um die gesamte Präsentation in ein **SWF** Dokument zu konvertieren. Das folgende Beispiel zeigt, wie man eine Präsentation in ein **SWF** Dokument konvertiert, indem man die Optionen der [**SWFOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/SwfOptions) Klasse verwendet. Sie können auch Kommentare im generierten SWF mithilfe der [**ISWFOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/ISwfOptions) Klasse und der [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/INotesCommentsLayoutingOptions) Schnittstelle einfügen.

```php
  $pres = new Presentation("Sample.pptx");
  try {
    $swfOptions = new SwfOptions();
    $swfOptions->setViewerIncluded(false);
    $swfOptions->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomFull);
    # Präsentation speichern
    $pres->save("Sample.swf", SaveFormat::Swf, $swfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
```php

```