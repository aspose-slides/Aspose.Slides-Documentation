---
title: Gérer les contrôles ActiveX dans les présentations à l'aide de Python
linktitle: ActiveX
type: docs
weight: 80
url: /fr/python-java/activex/
keywords:
- ActiveX
- Contrôle ActiveX
- gérer ActiveX
- ajouter ActiveX
- modifier ActiveX
- lecteur multimédia
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Modifier les zones de texte et les boutons ActiveX, mettre à jour les aperçus des contrôles et réutiliser un contrôle Windows Media Player dans les présentations PowerPoint avec Aspose.Slides pour Python via Java."
---
## **Introduction**

Les contrôles ActiveX offrent à une diapositive PowerPoint des éléments interactifs tels que des zones de texte, des boutons de commande et des lecteurs multimédias. Aspose.Slides for Python via Java expose les contrôles d’une diapositive via [BaseSlide.getControls](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getControls). Utilisez cette collection pour modifier un contrôle, le déplacer sur la diapositive ou le supprimer.

## **Lister les contrôles ActiveX et leurs propriétés stockées**

Pour examiner un modèle inconnu, ouvrez‑le en lecture et parcourez les contrôles de chaque diapositive. L’exemple indique le numéro de la diapositive, le nom du contrôle, [getClassId](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getClassId) et chaque paire clé‑valeur dans [getProperties](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getProperties). Il lit la présentation sans activer les contrôles, déclencher des événements ou des macros, modifier des valeurs ou enregistrer le fichier.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("ActiveX.pptm")
try:
    for slide_number, slide in enumerate(presentation.getSlides(), start=1):
        for control in slide.getControls():
            print(f"Slide {slide_number} | {control.getName()} | {control.getClassId()}")
            properties = control.getProperties()
            if properties is None:
                print("  Properties unavailable")
            elif properties.getCount() == 0:
                print("  []")
            else:
                for name in properties.getNamesOfProperties():
                    print(f"  {name} = {properties.get_Item(name)}")
finally:
    presentation.dispose()
```

La sortie sélectionnée de `ActiveX.pptm` montre une zone de texte et un bouton de commande.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Une collection de propriétés vide apparaît sous la forme `[]`. Pour les contrôles qui utilisent le stockage binaire, [getProperties](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getProperties) peut renvoyer `None`, affiché comme `Properties unavailable`. Si vous avez seulement besoin des noms, utilisez [getNamesOfProperties](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties) après avoir vérifié que la collection est disponible. Le rapport répertorie les propriétés accessibles depuis la présentation. Un contrôle peut prendre en charge des propriétés supplémentaires à l’exécution.

## **Modifier les contrôles ActiveX**

L’exemple suppose une présentation compatible avec les macros contenant une zone de texte nommée `TextBox1` et un bouton de commande nommé `CommandButton1` sur la première diapositive. Il utilise la [collection de propriétés du contrôle](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/) pour modifier la valeur de la zone de texte et la légende du bouton. Chaque contrôle possède également un aperçu statique que PowerPoint peut afficher avant l’activation. Fournissez un PNG pour chaque contrôle montrant le texte et l’apparence mis à jour. L’exemple affecte ces images via [Control.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getSubstitutePictureFormat).

L’exemple décale chaque contrôle de la première diapositive de 100 points vers le bas en définissant son cadre avec [Control.setFrame](https://reference.aspose.com/slides/python-java/aspose.slides/control/#setFrame). Il enregistre la présentation modifiée au format PPTM, puis utilise [ControlCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/controlcollection/#clear) pour enregistrer une seconde copie sans aucun contrôle ActiveX sur cette diapositive.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeFrame

presentation = Presentation("ActiveX.pptm")
try:
    controls = presentation.getSlides().get_Item(0).getControls()
    by_name = {str(control.getName()): control for control in controls}
    text_box = by_name.get("TextBox1")
    button = by_name.get("CommandButton1")
    if text_box is None or button is None or text_box.getProperties() is None or button.getProperties() is None:
        print("The first slide must contain both named controls with editable properties.")
    else:
        text_box_bytes = Path("text-box-preview.png").read_bytes()
        button_bytes = Path("button-preview.png").read_bytes()
        text_box_preview = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(text_box_bytes))
        button_preview = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(button_bytes))
        text_box.getProperties().set_Item("Value", "Changed text")
        button.getProperties().set_Item("Caption", "Show message")
        text_box.getSubstitutePictureFormat().getPicture().setImage(text_box_preview)
        button.getSubstitutePictureFormat().getPicture().setImage(button_preview)

        for control in controls:
            frame = control.getFrame()
            moved = ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation())
            control.setFrame(moved)
        presentation.save("edited-controls.pptm", SaveFormat.Pptm)

        controls.clear()
        presentation.save("removed-controls.pptm", SaveFormat.Pptm)
except OSError as error:
    print(f"Could not read a control preview: {error}")
finally:
    presentation.dispose()
```

## **Ajouter un contrôle ActiveX Windows Media Player**

Pour réutiliser un lecteur Windows Media Player configuré, partez d’un modèle dont la première diapositive contient un lecteur nommé `WindowsMediaPlayer1`. [SlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addClone) copie la diapositive entière dans une nouvelle présentation. L’exemple fixe le `URL` du lecteur dans sa [collection de propriétés](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/) et enregistre la diapositive clonée comme unique diapositive du résultat. La vidéo reste externe, choisissez donc un chemin accessible au lecteur pendant la lecture.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

template = Presentation("template.pptx")
try:
    presentation = Presentation()
    try:
        slides = presentation.getSlides()
        slide = slides.addClone(template.getSlides().get_Item(0))
        player = next((control for control in slide.getControls() if control.getName() == "WindowsMediaPlayer1"), None)
        if player is None or player.getProperties() is None:
            print("The template slide must contain a named media player with editable properties.")
        else:
            player.getProperties().set_Item("URL", "Wildlife.mp4")
            slides.removeAt(0)
            presentation.save("linked-video.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    template.dispose()
```

## **FAQ**

**Aspose.Slides peut‑il conserver les contrôles ActiveX sans les exécuter ?**

Oui. Aspose.Slides peut lire et enregistrer les contrôles, y compris leurs propriétés et leurs positions, sans les activer.

**En quoi les contrôles ActiveX diffèrent‑ils des objets OLE ?**

Les contrôles ActiveX permettent aux utilisateurs d’interagir avec une diapositive, par exemple en saisissant du texte ou en cliquant sur un bouton. Un [OLE object](/slides/fr/python-java/manage-ole/) permet à une diapositive de contenir ou de lier du contenu géré par une autre application, comme une feuille de calcul Excel.

**Les événements ActiveX déclencheront‑ils toujours des macros VBA après avoir enregistré une présentation avec Aspose.Slides ?**

Enregistrez la présentation dans un format compatible avec les macros tel que PPTM pour conserver son projet VBA. PowerPoint pour Windows peut exécuter les gestionnaires d’événements existants lorsque ses paramètres de sécurité permettent à la fois les contrôles ActiveX et les macros.