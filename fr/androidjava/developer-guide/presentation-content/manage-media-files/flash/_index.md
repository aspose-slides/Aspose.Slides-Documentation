---
title: Extraire des objets Flash des présentations sur Android
linktitle: Flash
type: docs
weight: 10
url: /fr/androidjava/flash/
keywords:
- extraire flash
- objet flash
- PowerPoint
- OpenDocument
- présentation
- Android
- Java
- Aspose.Slides
description: "Apprenez comment extraire des objets Flash des diapositives PowerPoint et OpenDocument en Java avec Aspose.Slides pour Android, avec des exemples de code complets et les meilleures pratiques."
---

## **Extraire des objets Flash des présentations**

Aspose.Slides for Android via Java fournit une fonctionnalité d'extraction d'objets flash d'une présentation. Vous pouvez accéder au contrôle flash par son nom et l'extraire de la présentation, y compris les données d'objet SWF stockées.
```java
// Instancier la classe Presentation qui représente le PPTX
Presentation pres = new Presentation();
try {
    IControlCollection controls = pres.getSlides().get_Item(0).getControls();
    Control flashControl = null;
    for (IControl control : controls)
    {
        if (control.getName() == "ShockwaveFlash1")
        {
            flashControl = (Control)control;
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Quels formats de présentation sont pris en charge lors de l'extraction du contenu Flash ?**

[Aspose.Slides supporte](/slides/fr/androidjava/supported-file-formats/) les principaux formats PowerPoint tels que PPT et PPTX, car il peut charger ces conteneurs et accéder à leurs contrôles, y compris les éléments ActiveX liés à Flash.

**Puis-je convertir une présentation contenant du Flash en HTML5 et préserver l'interactivité Flash ?**

Non. Aspose.Slides n'exécute pas le contenu SWF ni ne convertit son interactivité. Bien que l'exportation vers [HTML](/slides/fr/androidjava/convert-powerpoint-to-html/)/[HTML5](/slides/fr/androidjava/export-to-html5/) soit prise en charge, le Flash ne fonctionnera pas dans les navigateurs modernes en raison de la fin du support. La voie recommandée est de remplacer le Flash par des alternatives telles que la vidéo ou les animations HTML5 avant l'exportation.

**Du point de vue de la sécurité, Aspose.Slides exécute-t-il des fichiers SWF lors de la lecture d'une présentation ?**

Non. Aspose.Slides considère le Flash comme des données binaires intégrées au fichier et n'exécute pas le contenu SWF pendant le traitement.

**Comment gérer les présentations qui incluent du Flash ainsi que d'autres fichiers intégrés via OLE ?**

Aspose.Slides prend en charge [l'extraction d'objets OLE intégrés](/slides/fr/androidjava/manage-ole/), vous permettant de traiter tout le contenu intégré lié en une seule passe, en gérant les contrôles Flash et les autres documents intégrés OLE ensemble.