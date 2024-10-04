---
title: Convertir PowerPoint a SWF Flash
type: docs
weight: 80
url: /php-java/convert-powerpoint-to-swf-flash/
keywords: "PPT, PPTX a SWF"
description: "Convertir PowerPoint PPT, PPTX a SWF"
---

## **Convertir PPT(X) a SWF**
El método [Save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) expuesto por la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) se puede utilizar para convertir toda la presentación en un documento **SWF**. El siguiente ejemplo muestra cómo convertir una presentación en un documento **SWF** utilizando las opciones proporcionadas por la clase [**SWFOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/SwfOptions). También puedes incluir comentarios en el SWF generado utilizando la clase [**ISWFOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/ISwfOptions) y la interfaz [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/INotesCommentsLayoutingOptions).

```php
  $pres = new Presentation("Sample.pptx");
  try {
    $swfOptions = new SwfOptions();
    $swfOptions->setViewerIncluded(false);
    $swfOptions->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomFull);
    # Guardando presentación
    $pres->save("Sample.swf", SaveFormat::Swf, $swfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
```php

```