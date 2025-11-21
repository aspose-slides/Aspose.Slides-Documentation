---
title: Convertir PowerPoint en SWF Flash
type: docs
weight: 80
url: /fr/nodejs-java/convert-powerpoint-to-swf-flash/
keywords: "PPT, PPTX en SWF"
description: "Convertir PowerPoint PPT, PPTX en SWF avec JavaScript"
---

## **Convertir PPT(X) en SWF**
La méthode [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) exposée par la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) peut être utilisée pour convertir l’intégralité de la présentation en document **SWF**. L’exemple suivant montre comment convertir une présentation en document **SWF** en utilisant les options fournies par la classe [**SWFOptions**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SwfOptions). Vous pouvez également inclure des commentaires dans le SWF généré en utilisant la classe [**SWFOptions**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SwfOptions) et la classe [**NotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NotesCommentsLayoutingOptions).
```javascript
var pres = new aspose.slides.Presentation("Sample.pptx");
try {
    var swfOptions = new aspose.slides.SwfOptions();
    swfOptions.setViewerIncluded(false);
    swfOptions.getNotesCommentsLayouting().setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    // Enregistrement de la présentation
    pres.save("Sample.swf", aspose.slides.SaveFormat.Swf, swfOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Puis-je inclure les diapositives masquées dans le SWF ?**

Oui. Utilisez la méthode [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/swfoptions/setshowhiddenslides/) dans [SwfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/swfoptions/). Par défaut, les diapositives masquées ne sont pas exportées.

**Comment puis‑je contrôler la compression et la taille finale du SWF ?**

Utilisez les méthodes [setCompressed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/swfoptions/setcompressed/) et [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/swfoptions/setjpegquality/) pour équilibrer la taille du fichier et la fidélité des images.

**À quoi sert 'setViewerIncluded' et quand dois‑je l’utiliser ?**

[setViewerIncluded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/swfoptions/setviewerincluded/) ajoute une interface de lecteur intégrée (contrôles de navigation, panneaux, recherche). Utilisez‑la si vous prévoyez d’utiliser votre propre lecteur ou si vous avez besoin d’un cadre SWF sans interface utilisateur.

**Que se passe‑t‑il si une police source est manquante sur la machine d’exportation ?**

Aspose.Slides remplacera la police que vous spécifiez via [setDefaultRegularFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) dans [SwfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/swfoptions/) afin d’éviter un repli non souhaité.