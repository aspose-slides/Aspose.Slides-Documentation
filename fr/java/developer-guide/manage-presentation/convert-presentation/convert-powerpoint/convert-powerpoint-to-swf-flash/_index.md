---
title: Convertir les présentations PowerPoint en SWF Flash en Java
linktitle: PowerPoint vers SWF
type: docs
weight: 80
url: /fr/java/convert-powerpoint-to-swf-flash/
keywords:
- convertir PowerPoint
- convertir présentation
- convertir diapositive
- convertir PPT
- convertir PPTX
- PowerPoint vers SWF
- présentation vers SWF
- diapositive vers SWF
- PPT vers SWF
- PPTX vers SWF
- PowerPoint vers Flash
- présentation vers Flash
- diapositive vers Flash
- PPT vers Flash
- PPTX vers Flash
- enregistrer PPT en tant que SWF
- enregistrer PPTX en tant que SWF
- exporter PPT vers SWF
- exporter PPTX vers SWF
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Convertir PowerPoint (PPT/PPTX) en SWF Flash en Java avec Aspose.Slides. Exemples de code étape par étape, sortie rapide et de qualité, sans automatisation PowerPoint."
---

## **Convertir PPT(X) en SWF**
La méthode [Save](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) exposée par la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) peut être utilisée pour convertir l'intégralité de la présentation en document **SWF**. L'exemple suivant montre comment convertir une présentation en document **SWF** en utilisant les options fournies par la classe [**SWFOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/SwfOptions). Vous pouvez également inclure des commentaires dans le SWF généré en utilisant la classe [**ISWFOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/ISwfOptions) et l'interface [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/INotesCommentsLayoutingOptions).
```java
Presentation pres = new Presentation("Sample.pptx");
try {
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.setViewerIncluded(false);
    swfOptions.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
    
    // Enregistrement de la présentation
    pres.save("Sample.swf", SaveFormat.Swf, swfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```
