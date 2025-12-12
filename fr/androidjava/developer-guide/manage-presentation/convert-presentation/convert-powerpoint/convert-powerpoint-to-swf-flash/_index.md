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
description: "Convertir PowerPoint (PPT/PPTX) en SWF Flash en Java avec Aspose.Slides pour Android. Exemples de code étape par étape, sortie rapide et de haute qualité, aucune automatisation PowerPoint."
---

## **Convertir PPT(X) en SWF**
La méthode [Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) exposée par la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) peut être utilisée pour convertir l’ensemble de la présentation en document **SWF**. L’exemple suivant montre comment convertir une présentation en document **SWF** en utilisant les options fournies par la classe [**SWFOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SwfOptions). Vous pouvez également inclure des commentaires dans le SWF généré en utilisant la classe [**ISWFOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISwfOptions) et l’interface [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INotesCommentsLayoutingOptions).

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

**Puis-je inclure des diapositives masquées dans le SWF ?**

Oui. Activez les diapositives masquées en utilisant la méthode [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/swfoptions/#setShowHiddenSlides-boolean-) dans [SwfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/swfoptions/). Par défaut, les diapositives masquées ne sont pas exportées.

**Comment puis‑je contrôler la compression et la taille finale du SWF ?**

Utilisez la méthode [setCompressed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/swfoptions/#setCompressed-boolean-) et le lien [ajuster la qualité JPEG](https://reference.aspose.com/slides/androidjava/com.aspose.slides/swfoptions/#setJpegQuality-int-) pour équilibrer la taille du fichier et la fidélité de l’image.

**À quoi sert 'setViewerIncluded' et quand devrais‑je le désactiver ?**

[setViewerIncluded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/swfoptions/#setViewerIncluded-boolean-) ajoute une interface lecteur intégrée (contrôles de navigation, panneaux, recherche). Désactivez‑la si vous prévoyez d’utiliser votre propre lecteur ou si vous avez besoin d’un cadre SWF minimal sans UI.

**Que se passe‑t‑il si une police source est absente sur la machine d’exportation ?**

Aspose.Slides remplacera la police que vous spécifiez via [setDefaultRegularFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) dans [SwfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/swfoptions/) afin d’éviter un repli non intentionnel.