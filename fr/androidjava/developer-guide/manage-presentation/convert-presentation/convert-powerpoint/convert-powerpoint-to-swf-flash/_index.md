---
title: Convertir les présentations PowerPoint en SWF Flash sur Android
linktitle: PowerPoint vers SWF
type: docs
weight: 80
url: /fr/androidjava/convert-powerpoint-to-swf-flash/
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
- enregistrer PPT en SWF
- enregistrer PPTX en SWF
- exporter PPT en SWF
- exporter PPTX en SWF
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Convertir PowerPoint (PPT/PPTX) en SWF Flash avec Java et Aspose.Slides pour Android. Exemples de code pas à pas, sortie rapide de haute qualité, sans automatisation PowerPoint."
---

## **Convertir PPT(X) en SWF**
La méthode [Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) exposée par la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) peut être utilisée pour convertir l'intégralité de la présentation en document **SWF**. L'exemple suivant montre comment convertir une présentation en document **SWF** en utilisant les options fournies par la classe [**SWFOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SwfOptions). Vous pouvez également inclure des commentaires dans le SWF généré en utilisant la classe [**ISWFOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISwfOptions) et l'interface [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INotesCommentsLayoutingOptions).
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


## **FAQ**

**Can I include hidden slides in the SWF?**

Oui. Activez les diapositives masquées en utilisant la méthode [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/swfoptions/#setShowHiddenSlides-boolean-) de la classe [SwfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/swfoptions/). Par défaut, les diapositives masquées ne sont pas exportées.

**How can I control compression and the final SWF size?**

Utilisez la méthode [setCompressed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/swfoptions/#setCompressed-boolean-) et ajustez la qualité JPEG via [setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/swfoptions/#setJpegQuality-int-) pour équilibrer la taille du fichier et la fidélité de l'image.

**What is 'setViewerIncluded' for, and when should I disable it?**

[setViewerIncluded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/swfoptions/#setViewerIncluded-boolean-) ajoute une interface lecteur intégrée (contrôles de navigation, panneaux, recherche). Désactivez‑la si vous prévoyez d'utiliser votre propre lecteur ou si vous avez besoin d'une trame SWF dépouillée sans interface.

**What happens if a source font is missing on the export machine?**

Aspose.Slides remplacera la police que vous spécifiez via [setDefaultRegularFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) dans [SwfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/swfoptions/) afin d'éviter un remplacement non voulu.