---
title: Obtenir les limites des portions de texte dans les présentations en Python
linktitle: Limites de la portion
type: docs
weight: 47
url: /fr/python-net/portion-bounds/
keywords:
- limites de la portion de texte
- portion de texte
- partie de texte
- coordonnées du texte
- position du texte
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Apprenez comment récupérer les limites des portions de texte dans les présentations PowerPoint et OpenDocument en utilisant Aspose.Slides pour Python via .NET."
---
## **Vue d'ensemble**

Une portion de texte représente un fragment spécifique de texte à l'intérieur d'un paragraphe et vous permet de travailler avec ce fragment de manière indépendante du contenu environnant. Dans Aspose.Slides, les portions peuvent être utilisées lorsqu'il faut récupérer les limites d'un fragment de texte, appliquer un formatage uniquement à une partie d'un paragraphe ou contrôler le comportement du texte à un niveau plus détaillé.

Cet article montre comment obtenir le rectangle englobant d'une portion en utilisant [Portion.get_rect](https://reference.aspose.com/slides/fr/python-net/aspose.slides/portion/get_rect/). Il montre également comment obtenir les coordonnées du début d'une portion en utilisant [Portion.get_coordinates](https://reference.aspose.com/slides/fr/python-net/aspose.slides/portion/get_coordinates/). De plus, il met en évidence des scénarios courants liés aux portions, tels que l'application d'un hyperlien à un fragment de texte unique, la compréhension de la façon dont le formatage est résolu via la portion, le paragraphe, le cadre de texte et l'héritage du thème, et la gestion des cas où une police spécifiée est indisponible.

## **Obtenir les limites d'une portion de texte**

Utilisez [Portion.get_rect](https://reference.aspose.com/slides/fr/python-net/aspose.slides/portion/get_rect/) pour récupérer le rectangle englobant d'une portion de texte :

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    for paragraph in shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            rectangle = portion.get_rect()
            print(f"X = {rectangle.x}; Y = {rectangle.y}; Width = {rectangle.width}; Height = {rectangle.height}")
```

## **Obtenir les coordonnées d'une portion de texte**

Utilisez [Portion.get_coordinates](https://reference.aspose.com/slides/fr/python-net/aspose.slides/portion/get_coordinates/) pour récupérer les coordonnées du début d'une portion de texte :

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    for paragraph in shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            point = portion.get_coordinates()
            print(f"X = {point.x}; Y = {point.y}")
```

## **FAQ**

**Puis-je appliquer un hyperlien à seulement une partie du texte d'un même paragraphe ?**

Oui, vous pouvez [attribuer un hyperlien](/slides/fr/python-net/manage-hyperlinks/) à une portion individuelle ; seul ce fragment sera cliquable, pas tout le paragraphe.

**Comment fonctionne l'héritage des styles : qu'est-ce qu'une portion surcharge, et qu'est‑ce qui est repris d'un paragraphe ou d'un cadre de texte ?**

Les propriétés au niveau de la portion ont la priorité la plus élevée. Si une propriété n'est pas définie sur la [Portion](https://reference.aspose.com/slides/fr/python-net/aspose.slides/portion/), Aspose.Slides la récupère depuis le [Paragraph](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraph/). Si elle n'est pas non plus définie là‑bas, Aspose.Slides utilise le style du [TextFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/) ou du [theme](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/theme/).

**Que se passe-t-il si la police spécifiée pour une portion est absente sur la machine ou le serveur cible ?**

Les [règles de substitution de police](/slides/fr/python-net/font-selection-sequence/) s'appliquent. Le texte peut se reformater : les métriques, la césure et la largeur peuvent changer, ce qui impacte le positionnement précis.

**Puis‑je définir la transparence du remplissage du texte ou un dégradé propre à une portion, indépendamment du reste du paragraphe ?**

Oui, la couleur du texte, le remplissage et la transparence au niveau de la [Portion](https://reference.aspose.com/slides/fr/python-net/aspose.slides/portion/) peuvent différer des fragments voisins.