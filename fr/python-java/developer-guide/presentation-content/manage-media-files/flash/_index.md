---
title: Extraire des objets Flash des présentations en Python
linktitle: Flash
type: docs
weight: 10
url: /fr/python-java/flash/
keywords:
- extraire flash
- objet flash
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Apprenez comment extraire les objets Flash des diapositives PowerPoint et OpenDocument en Python avec Aspose.Slides, avec des exemples de code complets et les meilleures pratiques."
---
## **Vue d'ensemble**

Cet article explique comment extraire des objets Flash des présentations en utilisant Aspose.Slides. Il montre comment trouver un contrôle Flash par son nom dans la collection de contrôles d’une diapositive et travailler avec les données d’objet SWF intégrées.

## **Extraire des objets Flash des présentations**

Aspose.Slides for Python via Java offre une fonctionnalité d’extraction des objets flash d’une présentation. Vous pouvez accéder au contrôle Flash par son nom et l’extraire de la présentation, y compris les données d’objet SWF stockées.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

# Instancier la classe Presentation qui représente le PPTX.
presentation = Presentation()
try:
    controls = presentation.getSlides().get_Item(0).getControls()
    flash_control = None
    for control in controls:
        if control.getName() == "ShockwaveFlash1":
            flash_control = control
finally:
    presentation.dispose()
```

## **FAQ**

**Quels formats de présentation sont pris en charge lors de l’extraction de contenu Flash ?**

[Aspose.Slides prend en charge](/slides/fr/python-java/supported-file-formats/) les principaux formats PowerPoint tels que PPT et PPTX, car il peut charger ces conteneurs et accéder à leurs contrôles, y compris les éléments ActiveX liés au Flash.

**Puis‑je convertir une présentation contenant du Flash en HTML5 tout en conservant l’interactivité Flash ?**

Non. Aspose.Slides n’exécute pas le contenu SWF et ne convertit pas son interactivité. Bien que l’exportation vers [HTML](/slides/fr/python-java/convert-powerpoint-to-html/)/[HTML5](/slides/fr/python-java/export-to-html5/) soit prise en charge, le Flash ne fonctionnera pas dans les navigateurs modernes en raison de la fin de son support. La solution recommandée consiste à remplacer le Flash par des alternatives telles que la vidéo ou des animations HTML5 avant l’exportation.

**Du point de vue de la sécurité, Aspose.Slides exécute‑t‑il des fichiers SWF lors de la lecture d’une présentation ?**

Non. Aspose.Slides traite le Flash comme des données binaires intégrées au fichier et n’exécute pas le contenu SWF pendant le traitement.

**Comment gérer les présentations contenant du Flash ainsi que d’autres fichiers intégrés via OLE ?**

Aspose.Slides prend en charge [l’extraction d’objets OLE intégrés](/slides/fr/python-java/manage-ole/), vous permettant de traiter tout le contenu intégré en une seule passe, en gérant les contrôles Flash et les autres documents intégrés via OLE simultanément.