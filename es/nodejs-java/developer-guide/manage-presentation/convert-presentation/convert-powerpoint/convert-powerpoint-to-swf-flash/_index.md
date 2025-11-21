---
title: Convertir PowerPoint a SWF Flash
type: docs
weight: 80
url: /es/nodejs-java/convert-powerpoint-to-swf-flash/
keywords: "PPT, PPTX a SWF"
description: "Convertir PowerPoint PPT, PPTX a SWF en JavaScript"
---

## **Convertir PPT(X) a SWF**
El método [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) expuesto por la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) puede usarse para convertir toda la presentación en un documento **SWF**. El siguiente ejemplo muestra cómo convertir una presentación en un documento **SWF** utilizando las opciones proporcionadas por la clase [**SWFOptions**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SwfOptions). También puede incluir comentarios en el SWF generado usando la clase [**SWFOptions**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SwfOptions) y la clase [**NotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NotesCommentsLayoutingOptions).
```javascript
var pres = new aspose.slides.Presentation("Sample.pptx");
try {
    var swfOptions = new aspose.slides.SwfOptions();
    swfOptions.setViewerIncluded(false);
    swfOptions.getNotesCommentsLayouting().setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    // Guardando la presentación
    pres.save("Sample.swf", aspose.slides.SaveFormat.Swf, swfOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**¿Puedo incluir diapositivas ocultas en el SWF?**

Sí. Use el método [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/swfoptions/setshowhiddenslides/) en [SwfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/swfoptions/). Por defecto, las diapositivas ocultas no se exportan.

**¿Cómo puedo controlar la compresión y el tamaño final del SWF?**

Use el método [setCompressed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/swfoptions/setcompressed/) y [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/swfoptions/setjpegquality/) para equilibrar el tamaño del archivo y la fidelidad de la imagen.

**¿Para qué sirve 'setViewerIncluded' y cuándo debería usarlo?**

[setViewerIncluded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/swfoptions/setviewerincluded/) agrega una interfaz de reproductor incrustada (controles de navegación, paneles, búsqueda). Úselo si planea utilizar su propio reproductor o necesita un marco SWF básico sin UI.

**¿Qué ocurre si falta una fuente original en la máquina de exportación?**

Aspose.Slides sustituirá la fuente que especifique mediante [setDefaultRegularFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) en [SwfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/swfoptions/) para evitar una sustitución no deseada.