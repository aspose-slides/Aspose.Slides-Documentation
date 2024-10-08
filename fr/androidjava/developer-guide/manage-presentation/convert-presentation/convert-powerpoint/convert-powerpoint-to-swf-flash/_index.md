---
title: Convertir PowerPoint en SWF Flash
type: docs
weight: 80
url: /fr/androidjava/convert-powerpoint-to-swf-flash/
keywords: "PPT, PPTX en SWF"
description: "Convertir PowerPoint PPT, PPTX en SWF en Java"
---

## **Convertir PPT(X) en SWF**
La méthode [Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) exposée par la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) peut être utilisée pour convertir l'ensemble de la présentation en document **SWF**. L'exemple suivant montre comment convertir une présentation en document **SWF** en utilisant les options fournies par la classe [**SWFOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SwfOptions). Vous pouvez également inclure des commentaires dans le SWF généré en utilisant la classe [**ISWFOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISwfOptions) et l'interface [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INotesCommentsLayoutingOptions).

```java
Presentation pres = new Presentation("Sample.pptx");
try {
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.setViewerIncluded(false);
    swfOptions.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
    
    // Sauvegarder la présentation
    pres.save("Sample.swf", SaveFormat.Swf, swfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```