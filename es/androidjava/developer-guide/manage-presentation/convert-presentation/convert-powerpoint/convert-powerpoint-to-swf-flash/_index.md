---
title: Convertir presentaciones PowerPoint a SWF Flash en Android
linktitle: PowerPoint a SWF
type: docs
weight: 80
url: /es/androidjava/convert-powerpoint-to-swf-flash/
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
- Android
- Java
- Aspose.Slides
description: "Convertir PowerPoint (PPT/PPTX) a SWF Flash en Java con Aspose.Slides para Android. Ejemplos de código paso a paso, salida rápida y de calidad, sin automatización de PowerPoint."
---

## **Convertir PPT(X) a SWF**
El método [Guardar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) expuesto por la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) se puede utilizar para convertir toda la presentación en un documento **SWF**. El siguiente ejemplo muestra cómo convertir una presentación en un documento **SWF** utilizando las opciones proporcionadas por la clase [**SWFOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SwfOptions). También puede incluir comentarios en el SWF generado usando la clase [**ISWFOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISwfOptions) y la interfaz [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INotesCommentsLayoutingOptions).
```java
Presentation pres = new Presentation("Sample.pptx");
try {
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.setViewerIncluded(false);
    swfOptions.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
    
    // Guardando la presentación
    pres.save("Sample.swf", SaveFormat.Swf, swfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**¿Puedo incluir diapositivas ocultas en el SWF?**

Sí. Habilite las diapositivas ocultas usando el método [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/swfoptions/#setShowHiddenSlides-boolean-) en [SwfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/swfoptions/). De forma predeterminada, las diapositivas ocultas no se exportan.

**¿Cómo puedo controlar la compresión y el tamaño final del SWF?**

Utilice el método [setCompressed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/swfoptions/#setCompressed-boolean-) y [ajuste la calidad JPEG](https://reference.aspose.com/slides/androidjava/com.aspose.slides/swfoptions/#setJpegQuality-int-) para equilibrar el tamaño del archivo y la fidelidad de la imagen.

**¿Para qué sirve 'setViewerIncluded' y cuándo debo desactivarlo?**

[setViewerIncluded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/swfoptions/#setViewerIncluded-boolean-) agrega una interfaz de reproductor incrustado (controles de navegación, paneles, búsqueda). Desactívelo si planea usar su propio reproductor o necesita un marco SWF sin interfaz.

**¿Qué ocurre si falta una fuente fuente en la máquina de exportación?**

Aspose.Slides sustituirá la fuente que indique mediante [setDefaultRegularFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) en [SwfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/swfoptions/) para evitar un reemplazo no deseado.