---
title: Convertir presentaciones de PowerPoint a SWF Flash en Java
linktitle: PowerPoint a SWF
type: docs
weight: 80
url: /es/java/convert-powerpoint-to-swf-flash/
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
- Java
- Aspose.Slides
description: "Convierta PowerPoint (PPT/PPTX) a SWF Flash en Java con Aspose.Slides. Ejemplos de código paso a paso, salida de alta calidad y rápida, sin automatización de PowerPoint."
---

## **Convertir PPT(X) a SWF**
El método [Save](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) expuesto por la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) se puede usar para convertir toda la presentación en un documento **SWF**. El siguiente ejemplo muestra cómo convertir una presentación en un documento **SWF** utilizando las opciones proporcionadas por la clase [**SWFOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/SwfOptions). También puede incluir comentarios en el SWF generado usando la clase [**ISWFOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/ISwfOptions) y la interfaz [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/INotesCommentsLayoutingOptions).
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
