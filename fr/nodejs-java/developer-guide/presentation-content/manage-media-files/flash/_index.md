---
title: Flash
type: docs
weight: 10
url: /fr/nodejs-java/flash/
description: Extraire les objets Flash d'une présentation PowerPoint avec JavaScript
---

## **Extraire les objets Flash d’une présentation**

Aspose.Slides pour Node.js via Java offre une fonctionnalité d’extraction d’objets flash d’une présentation. Vous pouvez accéder au contrôle flash par son nom et l’extraire de la présentation, y compris les données d’objet SWF stockées.
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var controls = pres.getSlides().get_Item(0).getControls();
    var flashControl = null;
    for (var i = 0; i < controls.size(); i++) {
        var control = controls.get_Item(i);
        console.log(control.getName() === "ShockwaveFlash1");
        if (control.getName() === "ShockwaveFlash1") {
            flashControl = control;
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Quels formats de présentation sont pris en charge lors de l’extraction de contenu Flash ?**

[Aspose.Slides prend en charge](/slides/fr/nodejs-java/supported-file-formats/) les principaux formats PowerPoint tels que PPT et PPTX, car il peut charger ces conteneurs et accéder à leurs contrôles, y compris les éléments ActiveX liés à Flash.

**Puis-je convertir une présentation contenant du Flash en HTML5 et conserver l’interactivité du Flash ?**

Non. Aspose.Slides n’exécute pas le contenu SWF ni ne convertit son interactivité. Bien que l’exportation vers [HTML](/slides/fr/nodejs-java/convert-powerpoint-to-html/)/[HTML5](/slides/fr/nodejs-java/export-to-html5/) soit prise en charge, le Flash ne fonctionnera pas dans les navigateurs modernes en raison de la fin du support. La solution recommandée consiste à remplacer le Flash par des alternatives telles que la vidéo ou des animations HTML5 avant l’exportation.

**Du point de vue de la sécurité, Aspose.Slides exécute-t-il des fichiers SWF lors de la lecture d’une présentation ?**

Non. Aspose.Slides considère le Flash comme des données binaires intégrées au fichier et n’exécute pas le contenu SWF pendant le traitement.

**Comment dois-je gérer les présentations qui incluent du Flash ainsi que d’autres fichiers intégrés via OLE ?**

Aspose.Slides prend en charge [l’extraction des objets OLE intégrés](/slides/fr/nodejs-java/manage-ole/), vous permettant de traiter tout le contenu intégré lié en une seule passe, en gérant les contrôles Flash et les autres documents intégrés via OLE ensemble.