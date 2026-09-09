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
description: "Apprenez comment extraire des objets Flash des diapositives PowerPoint et OpenDocument en Python avec Aspose.Slides, des exemples de code complets et les meilleures pratiques."
---
## **Vue d'ensemble**

Cet article explique comment extraire des objets Flash des présentations en utilisant Aspose.Slides. Il montre comment trouver un contrôle Flash par son nom dans la collection de contrôles d’une diapositive et travailler avec les données de l’objet SWF intégré.

## **Extraire les objets Flash des présentations**

Aspose.Slides for Python via Java fournit une fonctionnalité d’extraction des objets Flash d’une présentation. Vous pouvez accéder au contrôle Flash par son nom et l’extraire de la présentation, y compris les données de l’objet SWF stockées.

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

**Quels formats de présentation sont pris en charge lors de l'extraction du contenu Flash ?**

[Aspose.Slides prend en charge](/slides/fr/python-java/supported-file-formats/) les principaux formats PowerPoint tels que PPT et PPTX, car il peut charger ces conteneurs et accéder à leurs contrôles, y compris les éléments ActiveX liés à Flash.

**Puis-je convertir une présentation contenant du Flash en HTML5 et préserver l'interactivité du Flash ?**

Non. Aspose.Slides n'exécute pas le contenu SWF ni ne convertit son interactivité. Bien que l'exportation vers [HTML](/slides/fr/python-java/convert-powerpoint-to-html/)/[HTML5](/slides/fr/python-java/export-to-html5/) soit prise en charge, le Flash ne fonctionnera pas dans les navigateurs modernes en raison de la fin de son support. Le chemin recommandé consiste à remplacer le Flash par des alternatives telles que la vidéo ou les animations HTML5 avant l'exportation.

**D'un point de vue sécurité, Aspose.Slides exécute-t-il des fichiers SWF lors de la lecture d'une présentation ?**

Non. Aspose.Slides traite le Flash comme des données binaires intégrées dans le fichier et n'exécute pas le contenu SWF pendant le traitement.

**Comment dois-je gérer les présentations qui incluent du Flash ainsi que d'autres fichiers incorporés via OLE ?**

Aspose.Slides prend en charge l'[extraction d'objets OLE incorporés](/slides/fr/python-java/manage-ole/), vous pouvez donc traiter tout le contenu incorporé lié en une seule passe, en gérant les contrôles Flash et les autres documents incorporés via OLE ensemble.