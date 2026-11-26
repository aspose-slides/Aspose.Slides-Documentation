---
title: Gérer les contrôles ActiveX dans les présentations avec Python
linktitle: ActiveX
type: docs
weight: 80
url: /fr/python-net/activex/
keywords:
- ActiveX
- contrôle ActiveX
- gérer ActiveX
- ajouter ActiveX
- modifier ActiveX
- lecteur multimédia
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Modifier les zones de texte et les boutons ActiveX, mettre à jour les aperçus des contrôles et réutiliser un contrôle Windows Media Player dans les présentations PowerPoint avec Aspose.Slides pour Python via .NET."
---
## **Introduction**

Les contrôles ActiveX offrent à une diapositive PowerPoint des éléments interactifs tels que des zones de texte, des boutons de commande et des lecteurs multimédias. Aspose.Slides for Python via .NET expose les contrôles d’une diapositive via [Slide.controls](https://reference.aspose.com/slides/python-net/aspose.slides/slide/controls/). Utilisez cette collection pour modifier un contrôle, le déplacer sur la diapositive ou le supprimer.

## **List ActiveX Controls and Their Stored Properties**

Pour examiner un modèle inconnu, ouvrez‑le en lecture et parcourez les contrôles de chaque diapositive. L’exemple indique le numéro de la diapositive, le nom du contrôle, [class_id](https://reference.aspose.com/slides/python-net/aspose.slides/control/class_id/), et chaque paire clé‑valeur dans [properties](https://reference.aspose.com/slides/python-net/aspose.slides/control/#properties). Il lit la présentation sans activer les contrôles, déclencher des événements ou des macros, modifier des valeurs ou enregistrer le fichier.

```python
import aspose.slides as slides

with slides.Presentation("ActiveX.pptm") as presentation:
    for slide_number, slide in enumerate(presentation.slides, start=1):
        for control in slide.controls:
            print(f"Slide {slide_number} | {control.name} | {control.class_id}")
            properties = control.properties
            if properties is None:
                print("  Properties unavailable")
                continue

            if properties.count == 0:
                print("  []")
            for entry in properties:
                print(f"  {entry.key} = {entry.value}")
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

Une collection de propriétés vide apparaît sous la forme `[]`. Pour les contrôles qui utilisent un stockage binaire, `properties` peut retourner `None`, affiché comme `Properties unavailable`. Si vous avez uniquement besoin des noms, utilisez [names_of_properties](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/names_of_properties/) après avoir vérifié la valeur `None`. Le rapport répertorie les propriétés disponibles dans la présentation. Un contrôle peut prendre en charge des propriétés supplémentaires à l’exécution.

## **Modify ActiveX Controls**

L’exemple suppose une présentation activée pour les macros contenant une zone de texte nommée `TextBox1` et un bouton de commande nommé `CommandButton1` sur la première diapositive. Il utilise la [control properties collection](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/) pour modifier la valeur de la zone de texte et la légende du bouton. Chaque contrôle possède également un aperçu statique que PowerPoint peut afficher avant l’activation. Fournissez un PNG pour chaque contrôle montrant le texte et l’apparence mis à jour. L’exemple affecte ces images via [Control.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/control/substitute_picture_format/).

L’exemple déplace chaque contrôle de la première diapositive de 100 points vers le bas en modifiant son [frame](https://reference.aspose.com/slides/python-net/aspose.slides/control/frame/). Il enregistre la présentation modifiée au format PPTM, puis utilise [ControlCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/controlcollection/clear/) pour enregistrer une seconde copie avec tous les contrôles ActiveX supprimés de cette diapositive.

```python
from pathlib import Path

import aspose.slides as slides

with slides.Presentation("ActiveX.pptm") as presentation:
    controls = presentation.slides[0].controls
    text_box = next((control for control in controls if control.name == "TextBox1"), None)
    button = next((control for control in controls if control.name == "CommandButton1"), None)
    text_box_preview = Path("text-box-preview.png")
    button_preview = Path("button-preview.png")

    if text_box is None or button is None or text_box.properties is None or button.properties is None:
        print("The first slide must contain both named controls with editable properties.")
    elif not text_box_preview.is_file() or not button_preview.is_file():
        print("Supply both preview images before updating the controls.")
    else:
        text_box.properties.remove("Value")
        text_box.properties.add("Value", "Changed text")
        button.properties.remove("Caption")
        button.properties.add("Caption", "Show message")

        for control, preview in [(text_box, text_box_preview), (button, button_preview)]:
            image_data = preview.read_bytes()
            control.substitute_picture_format.picture.image = presentation.images.add_image(image_data)

        for control in controls:
            frame = control.frame
            control.frame = slides.ShapeFrame(frame.x, frame.y + 100, frame.width, frame.height, frame.flip_h, frame.flip_v, frame.rotation)

        presentation.save("edited-controls.pptm", slides.export.SaveFormat.PPTM)
        controls.clear()
        presentation.save("removed-controls.pptm", slides.export.SaveFormat.PPTM)
```

## **Add an ActiveX Media Player Control**

Pour réutiliser un contrôle Windows Media Player configuré, commencez avec un modèle dont la première diapositive contient un lecteur nommé `WindowsMediaPlayer1`. [SlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) copie la diapositive entière dans une nouvelle présentation. L’exemple définit l’`URL` du lecteur dans sa [properties collection](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/) et enregistre la diapositive clonée comme seule diapositive du résultat. La vidéo reste externe, choisissez donc un chemin accessible au lecteur pendant la lecture.

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as template, slides.Presentation() as presentation:
    slide = presentation.slides.add_clone(template.slides[0])
    player = next((control for control in slide.controls if control.name == "WindowsMediaPlayer1"), None)

    if player is None or player.properties is None:
        print("The template slide must contain a named media player with editable properties.")
    else:
        player.properties.remove("URL")
        player.properties.add("URL", "Wildlife.mp4")
        presentation.slides.remove_at(0)
        presentation.save("linked-video.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Aspose.Slides peut‑il préserver les contrôles ActiveX sans les exécuter ?**

Oui. Aspose.Slides peut lire et enregistrer les contrôles, y compris leurs propriétés et positions, sans les activer.

**En quoi les contrôles ActiveX diffèrent‑ils des objets OLE ?**

Les contrôles ActiveX permettent aux utilisateurs d’interagir avec une diapositive, par exemple en saisissant du texte ou en cliquant sur un bouton. Un [OLE object](/slides/fr/python-net/manage-ole/) permet à une diapositive de contenir ou de lier du contenu géré par une autre application, comme une feuille de calcul Excel.

**Les événements ActiveX déclencheront‑ils toujours les macros VBA après avoir enregistré une présentation avec Aspose.Slides ?**

Enregistrez la présentation dans un format activé pour les macros tel que PPTM afin de conserver son projet VBA. PowerPoint pour Windows peut exécuter les gestionnaires d’événements existants lorsque ses paramètres de sécurité autorisent à la fois les contrôles ActiveX et les macros.