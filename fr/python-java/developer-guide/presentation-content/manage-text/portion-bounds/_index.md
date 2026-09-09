---
title: Obtenir les limites des portions de texte à partir de présentations en Python via Java
linktitle: Limites de la portion
type: docs
weight: 47
url: /fr/python-java/portion-bounds/
keywords:
- limites de la portion de texte
- portion de texte
- partie de texte
- coordonnées du texte
- position du texte
- PowerPoint
- présentation
- Python
- Java
- Aspose.Slides
description: "Apprenez comment récupérer les limites des portions de texte dans les présentations PowerPoint en utilisant Aspose.Slides pour Python via Java."
---
## **Vue d'ensemble**

Une portion de texte représente un fragment spécifique de texte à l'intérieur d'un paragraphe et vous permet de travailler avec ce fragment de manière indépendante du contenu environnant. Dans Aspose.Slides, les portions peuvent être utilisées lorsque vous devez récupérer les limites d'un fragment de texte, appliquer une mise en forme à une seule partie d'un paragraphe ou contrôler le comportement du texte à un niveau plus détaillé.

Cet article montre comment obtenir le rectangle de délimitation d'une portion en utilisant [Portion.getRect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/portion/#getRect). Il montre également comment obtenir les coordonnées du début d'une portion en utilisant [Portion.getCoordinates](https://reference.aspose.com/slides/fr/python-java/aspose.slides/portion/#getCoordinates). De plus, il met en évidence des scénarios courants liés aux portions, tels que l'application d'un hyperlien à un seul fragment de texte, la compréhension de la façon dont la mise en forme est résolue via l'héritage des portions, paragraphes, cadres de texte et thèmes, et la gestion des cas où une police spécifiée est indisponible.

## **Obtenir les limites d'une portion de texte**

Utilisez [Portion.getRect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/portion/#getRect) pour récupérer le rectangle de délimitation d'une portion de texte :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Shapes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    for paragraph in shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            rectangle = portion.getRect()
            print(f"X = {rectangle.x}; Y = {rectangle.y}; Width = {rectangle.width}; Height = {rectangle.height}")
finally:
    presentation.dispose()
```

## **Obtenir les coordonnées d'une portion de texte**

Utilisez [Portion.getCoordinates](https://reference.aspose.com/slides/fr/python-java/aspose.slides/portion/#getCoordinates) pour récupérer les coordonnées du début d'une portion de texte :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Shapes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    for paragraph in shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            point = portion.getCoordinates()
            print(f"X = {point.x}; Y = {point.y}")
finally:
    presentation.dispose()
```

## **FAQ**

**Puis-je appliquer un hyperlien uniquement à une partie du texte au sein d'un même paragraphe ?**

Oui, vous pouvez [attribuer un hyperlien](/slides/fr/python-java/manage-hyperlinks/) à une portion individuelle ; seul ce fragment sera cliquable, pas le paragraphe entier.

**Comment fonctionne l'héritage des styles : qu'est-ce qu'une portion surcharge, et qu'est‑ce qui provient d'un paragraphe ou d'un cadre de texte ?**

Les propriétés au niveau de la portion ont la priorité la plus élevée. Si une propriété n'est pas définie sur la [Portion](https://reference.aspose.com/slides/fr/python-java/aspose.slides/portion/), Aspose.Slides la récupère depuis le [Paragraph](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraph/). Si elle n'est pas non plus définie là, Aspose.Slides utilise le style du [TextFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframe/) ou du [theme](https://reference.aspose.com/slides/fr/python-java/aspose.slides/theme/).

**Que se passe‑t‑il si la police spécifiée pour une portion est absente sur la machine ou le serveur cible ?**

Les [règles de substitution de police](/slides/fr/python-java/font-selection-sequence/) s'appliquent. Le texte peut se ré‑organiser : les métriques, la césure et la largeur peuvent changer, ce qui est important pour un positionnement précis.

**Puis‑je définir la transparence ou un dégradé de remplissage du texte propre à une portion indépendamment du reste du paragraphe ?**

Oui, la couleur du texte, le remplissage et la transparence au niveau de la [Portion](https://reference.aspose.com/slides/fr/python-java/aspose.slides/portion/) peuvent différer des fragments voisins.