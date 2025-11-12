---
title: Gérer les portions de texte dans les présentations avec Python
linktitle: Portion de texte
type: docs
weight: 70
url: /fr/python-net/portion/
keywords:
- portion de texte
- partie de texte
- coordonnées du texte
- position du texte
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Apprenez à gérer les portions de texte dans les présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour Python via .NET, en améliorant les performances et la personnalisation."
---

## **Obtenir les coordonnées des portions de texte**

La méthode [get_coordinates](https://reference.aspose.com/slides/python-net/aspose.slides/portion/get_coordinates/) a été ajoutée à la classe [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) qui permet de récupérer les coordonnées des portions de texte :

```py
import aspose.slides as slides

with slides.Presentation("HelloWorld.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    text_frame = shape.text_frame

    for paragraph in text_frame.paragraphs:
        for portion in paragraph.portions:
            point = portion.get_coordinates()
            print("Corrdinates X =" + str(point.x) + " Corrdinates Y =" + str(point.y))
```

## **FAQ**

**Puis‑je appliquer un hyperlien à seulement une partie du texte au sein d’un même paragraphe ?**

Oui, vous pouvez [attribuer un hyperlien](/slides/fr/python-net/manage-hyperlinks/) à une portion individuelle ; seul ce fragment sera cliquable, pas le paragraphe entier.

**Comment fonctionne l’héritage de style : qu’est‑ce qu’une Portion remplace, et qu’est‑ce qui est hérité du Paragraph/TextFrame ?**

Les propriétés au niveau de la Portion ont la priorité la plus élevée. Si une propriété n’est pas définie sur la [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/), le moteur la récupère du [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) ; si elle n’est pas définie non plus là, il la prend du [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) ou du style du [theme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/theme/) .

**Que se passe‑t‑il si la police spécifiée pour une Portion est absente sur la machine/serveur cible ?**

Les [règles de substitution de police](/slides/fr/python-net/font-selection-sequence/) s’appliquent. Le texte peut se réorganiser : les métriques, la césure et la largeur peuvent changer, ce qui est important pour un positionnement précis.

**Puis‑je définir une transparence ou un dégradé de remplissage du texte spécifique à une Portion, indépendamment du reste du paragraphe ?**

Oui, la couleur du texte, le remplissage et la transparence au niveau de la [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) peuvent différer des fragments voisins.