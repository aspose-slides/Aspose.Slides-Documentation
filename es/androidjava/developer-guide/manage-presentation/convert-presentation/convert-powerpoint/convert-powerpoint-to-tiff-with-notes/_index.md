---
title: Convertir PowerPoint a TIFF con Notas
type: docs
weight: 100
url: /androidjava/convert-powerpoint-to-tiff-with-notes/
keywords: "Convertir PowerPoint a TIFF con notas"
description: "Convertir PowerPoint a TIFF con notas en Aspose.Slides."
---

## **Convertir PPT(X) en Vista de Diapositivas con Notas a TIFF**
El método [Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) expuesto por la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) se puede utilizar para convertir toda la presentación en vista de Diapositivas con Notas a TIFF. Los fragmentos de código a continuación actualizan la presentación de muestra a imágenes TIFF en vista de Diapositivas con Notas, como se muestra a continuación:

```java
//Instanciar un objeto Presentation que representa un archivo de presentación
Presentation pres = new Presentation("demo.pptx");
try {
    TiffOptions opts = new TiffOptions();
    opts.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
    
    //Guardar la presentación en notas TIFF
    pres.save("Tiff-Notes.tiff", SaveFormat.Tiff,opts);
} finally {
    if (pres != null) pres.dispose();
}
```

Los fragmentos de código anteriores actualizan la presentación de muestra a imágenes TIFF en vista de Diapositivas con Notas, como se muestra a continuación:

|**La vista de presentación fuente con notas de diapositiva**|** |
| :- | :- |
|![todo:image_alt_text](http://i.imgur.com/6HdY6IV.png)| |


|**La imagen TIFF generada en vista de Diapositivas con Notas**|** |
| :- | :- |
|![todo:image_alt_text](http://i.imgur.com/A3ttT2y.png)| |

{{% alert title="Consejo" color="primary" %}}

Puede que desee consultar el [convertidor GRATUITO de PowerPoint a Póster](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) de Aspose.

{{% /alert %}}