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
description: "Convertir PowerPoint (PPT/PPTX) a SWF Flash en PHP con Aspose.Slides. Ejemplos de código paso a paso, salida de alta calidad y rápida, sin automatización de PowerPoint."
---

## **Convertir presentaciones a Flash**

El método [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) expuesto por la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) puede usarse para convertir toda la presentación en un documento **SWF**. El siguiente ejemplo muestra cómo convertir una presentación en un documento **SWF** utilizando las opciones proporcionadas por la clase [SWFOptions](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/). También puede incluir comentarios en el SWF generado mediante la clase [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/notescommentslayoutingoptions/).
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

[setViewerIncluded](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/setviewerincluded/) agrega una interfaz de reproductor incrustada (controles de navegación, paneles, búsqueda). Desactívelo si planea usar su propio reproductor o necesita un marco SWF sin interfaz.

**¿Qué ocurre si una fuente original falta en la máquina de exportación?**

Aspose.Slides sustituirá la fuente que especifique mediante [setDefaultRegularFont](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) en [SwfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/swfoptions/) para evitar un fallback no intencionado.