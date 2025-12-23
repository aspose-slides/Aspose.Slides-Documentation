---
title: Convertir presentaciones de PowerPoint a SWF Flash en PHP
linktitle: PowerPoint a SWF
type: docs
weight: 80
url: /es/php-java/convert-powerpoint-to-swf-flash/
keywords:
- convertir PowerPoint
- convertir presentación
- convertir diapositiva
- convertir PPT
- convertir PPTX
- PowerPoint a SWF
- presentación a SWF
- diapositiva a SWF
- PPT a SWF
- PPTX a SWF
- PowerPoint a Flash
- presentación a Flash
- diapositiva a Flash
- PPT a Flash
- PPTX a Flash
- guardar PPT como SWF
- guardar PPTX como SWF
- exportar PPT a SWF
- exportar PPTX a SWF
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Convertir PowerPoint (PPT/PPTX) a SWF Flash en PHP con Aspose.Slides. Ejemplos de código paso a paso, salida de alta calidad y sin automatización de PowerPoint."
---

## **Convertir presentaciones a Flash**
El método [Save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) expuesto por la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) se puede usar para convertir toda la presentación a un documento **SWF**. El siguiente ejemplo muestra cómo convertir una presentación a un documento **SWF** utilizando las opciones proporcionadas por la clase [**SWFOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/SwfOptions). También puede incluir comentarios en el SWF generado usando la clase [**ISWFOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/ISwfOptions) y la interfaz [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/INotesCommentsLayoutingOptions).
```php
  $pres = new Presentation("Sample.pptx");
  try {
    $swfOptions = new SwfOptions();
    $swfOptions->setViewerIncluded(false);
    $swfOptions->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomFull);
    # Guardando la presentación
    $pres->save("Sample.swf", SaveFormat::Swf, $swfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Preguntas frecuentes**

**¿Puedo incluir diapositivas ocultas en el SWF?**

Sí. Habilite las diapositivas ocultas usando el método [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/setshowhiddenslides/) en [SwfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/). Por defecto, las diapositivas ocultas no se exportan.

**¿Cómo puedo controlar la compresión y el tamaño final del SWF?**

Utilice el método [setCompressed](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/setcompressed/) y [adjust JPEG quality](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/setjpegquality/) para equilibrar el tamaño del archivo y la fidelidad de la imagen.

**¿Para qué sirve 'setViewerIncluded' y cuándo debería desactivarlo?**

[setViewerIncluded](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/setviewerincluded/) agrega una interfaz de reproductor integrada (controles de navegación, paneles, búsqueda). Desactívela si planea usar su propio reproductor o necesita un marco SWF sin interfaz.

**¿Qué ocurre si una fuente de origen falta en la máquina de exportación?**

Aspose.Slides sustituirá la fuente que usted indique mediante [setDefaultRegularFont](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) en [SwfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/) para evitar una sustitución no deseada.