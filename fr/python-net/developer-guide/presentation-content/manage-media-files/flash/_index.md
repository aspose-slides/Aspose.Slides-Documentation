---
title: Extraction d'objets Flash à partir de présentations en Python
linktitle: Flash
type: docs
weight: 10
url: /fr/python-net/flash/
keywords:
- extraction flash
- objet flash
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Apprenez comment extraire des objets Flash des diapositives PowerPoint et OpenDocument en Python avec Aspose.Slides, avec des exemples de code complets et les meilleures pratiques."
---

## **Extraire des objets Flash d’une présentation**
Aspose.Slides for Python via .NET offre une fonctionnalité d’extraction d’objets flash d’une présentation. Vous pouvez accéder au contrôle flash par son nom et l’extraire de la présentation, y compris les données d’objet SWF stockées.
```py
import aspose.slides as slides

with slides.Presentation("withFlash.pptm") as pres:
    controls = pres.slides[0].controls
    for control in controls:
        if control.Name == "ShockwaveFlash1":
            flashControl = control
```


## **FAQ**

**Quels formats de présentation sont pris en charge lors de l’extraction de contenu Flash ?**

[Aspose.Slides prend en charge](/slides/fr/python-net/supported-file-formats/) les principaux formats PowerPoint tels que PPT et PPTX, puisqu’il peut charger ces conteneurs et accéder à leurs contrôles, y compris les éléments ActiveX liés au Flash.

**Puis-je convertir une présentation contenant du Flash en HTML5 et conserver l’interactivité du Flash ?**

Non. Aspose.Slides n’exécute pas le contenu SWF ni ne convertit son interactivité. Bien que l’exportation vers [HTML](/slides/fr/python-net/convert-powerpoint-to-html/)/[HTML5](/slides/fr/python-net/export-to-html5/) soit prise en charge, le Flash ne se lira pas dans les navigateurs modernes en raison de la fin du support. La solution recommandée consiste à remplacer le Flash par des alternatives telles que la vidéo ou des animations HTML5 avant l’exportation.

**Du point de vue de la sécurité, Aspose.Slides exécute-t‑il des fichiers SWF lors de la lecture d’une présentation ?**

Non. Aspose.Slides traite le Flash comme des données binaires intégrées au fichier et n’exécute pas le contenu SWF pendant le traitement.

**Comment gérer les présentations qui contiennent du Flash ainsi que d’autres fichiers incorporés via OLE ?**

Aspose.Slides prend en charge [l'extraction d'objets OLE incorporés](/slides/fr/python-net/manage-ole/), vous permettant de traiter tout le contenu intégré en une seule passe, en gérant les contrôles Flash et les autres documents incorporés via OLE ensemble.