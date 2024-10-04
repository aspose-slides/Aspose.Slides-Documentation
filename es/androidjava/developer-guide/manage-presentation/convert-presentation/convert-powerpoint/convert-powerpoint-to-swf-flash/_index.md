---
title: Convertir PowerPoint a SWF Flash
type: docs
weight: 80
url: /androidjava/convert-powerpoint-to-swf-flash/
keywords: "PPT, PPTX a SWF"
description: "Convertir PowerPoint PPT, PPTX a SWF en Java"
---

## **Convertir PPT(X) a SWF**
El método [Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) expuesto por la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) se puede utilizar para convertir toda la presentación en un documento **SWF**. El siguiente ejemplo muestra cómo convertir una presentación en un documento **SWF** utilizando las opciones proporcionadas por la clase [**SWFOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SwfOptions). También puede incluir comentarios en el SWF generado utilizando la clase [**ISWFOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISwfOptions) y la interfaz [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INotesCommentsLayoutingOptions).

```java
Presentation pres = new Presentation("Sample.pptx");
try {
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.setViewerIncluded(false);
    swfOptions.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
    
    // Guardando presentación
    pres.save("Sample.swf", SaveFormat.Swf, swfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```