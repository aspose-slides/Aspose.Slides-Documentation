---
title: Convertir PowerPoint en SWF Flash
type: docs
weight: 80
url: /fr/php-java/convert-powerpoint-to-swf-flash/
keywords: "PPT, PPTX en SWF"
description: "Convertir PowerPoint PPT, PPTX en SWF "
---

## **Convertir PPT(X) en SWF**
La méthode [Save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) exposée par la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) peut être utilisée pour convertir l'ensemble de la présentation en document **SWF**. L'exemple suivant montre comment convertir une présentation en document **SWF** en utilisant les options fournies par la classe [**SWFOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/SwfOptions). Vous pouvez également inclure des commentaires dans le SWF généré en utilisant la classe [**ISWFOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/ISwfOptions) et l'interface [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/INotesCommentsLayoutingOptions).

```php
  $pres = new Presentation("Sample.pptx");
  try {
    $swfOptions = new SwfOptions();
    $swfOptions->setViewerIncluded(false);
    $swfOptions->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomFull);
    # Sauvegarde de la présentation
    $pres->save("Sample.swf", SaveFormat::Swf, $swfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
```php

```