---
title: Gestion des objets d'encre dans les présentations avec Python
linktitle: Gestion de l'encre
type: docs
weight: 95
url: /fr/python-net/manage-ink/
keywords:
- encre
- objet d'encre
- trace d'encre
- gérer l'encre
- dessiner l'encre
- dessin
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Gestion des objets d'encre PowerPoint — créez, modifiez et stylisez l'encre numérique avec Aspose.Slides pour Python via .NET. Obtenez des exemples de code pour les traces, la couleur et la taille du pinceau."
---

PowerPoint fournit la fonction encre pour vous permettre de dessiner des figures non standard, qui peuvent être utilisées pour mettre en évidence d'autres objets, afficher des connexions et des processus, et attirer l'attention sur des éléments spécifiques d'une diapositive. 

Aspose.Slides fournit l'espace de noms [aspose.slides.ink](https://reference.aspose.com/slides/python-net/aspose.slides.ink/), qui contient les types dont vous avez besoin pour créer et gérer des objets encre. 

## **Différences entre les objets normaux et les objets encre**

Les objets sur une diapositive PowerPoint sont généralement représentés par des objets forme. Un objet forme, dans sa forme la plus simple, est un conteneur qui définit la zone de l'objet lui‑même (son cadre) ainsi que ses propriétés. Ces dernières comprennent la taille de la zone du conteneur, la forme du conteneur, l'arrière‑plan du conteneur, etc. Pour plus d'informations, voir [Shape Layout Format](https://docs.aspose.com/slides/python-net/shape-manipulations/#access-layout-formats-for-shape).

Cependant, lorsque PowerPoint gère un objet encre, il ignore toutes les propriétés du cadre de l'objet (conteneur) sauf sa taille. La taille de la zone du conteneur est déterminée par les valeurs standard `width` et `height` :

![ink_powerpoint1](ink_powerpoint1.png)

## **Traces d'Inkshape**

Une trace est un élément de base ou une norme utilisée pour enregistrer la trajectoire d'un stylo lorsqu'un utilisateur écrit de l'encre numérique. Les traces sont des enregistrements qui décrivent des séquences de points connectés. 

La forme d'encodage la plus simple spécifie les coordonnées X et Y de chaque point d'échantillonnage. Lorsque tous les points connectés sont rendus, ils produisent une image comme celle‑ci :

![ink_powerpoint2](ink_powerpoint2.png)

## Propriétés du pinceau pour le dessin 

Vous pouvez utiliser un pinceau pour tracer des lignes reliant les points des éléments de trace. Le pinceau possède sa propre couleur et taille, correspondant aux propriétés `Brush.color` et `Brush.size`. 

### **Définir la couleur du pinceau encre**

Ce code Python vous montre comment définir la couleur d'un pinceau :
```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as pres:
    ink = pres.slides[0].shapes[0]
    traces = ink.traces
    brush = traces[0].brush
    brush_color = brush.color
    brush.color = draw.Color.red
```


### **Définir la taille du pinceau encre** 

Ce code Python vous montre comment définir la taille d'un pinceau :
```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as pres:
    ink = pres.slides[0].shapes[0]
    traces = ink.traces
    brush = traces[0].brush
    brush_size = brush.size
    brush.size = draw.SizeF(5.0, 10.0)
```


En général, la largeur et la hauteur d'un pinceau ne correspondent pas, de sorte que PowerPoint n'affiche pas la taille du pinceau (la section des données est grisée). Mais lorsque la largeur et la hauteur du pinceau correspondent, PowerPoint affiche sa taille de cette manière :

![ink_powerpoint3](ink_powerpoint3.png)

Pour plus de clarté, augmentons la hauteur de l'objet encre et examinons les dimensions importantes :

![ink_powerpoint4](ink_powerpoint4.png)

Le conteneur (cadre) ne tient pas compte de la taille des pinceaux — il suppose toujours que l'épaisseur de la ligne est nulle (voir la dernière image). 

Par conséquent, pour déterminer la zone visible de l'ensemble de l'objet encre, nous devons prendre en compte la taille du pinceau des objets trace. Ici, l'objet cible (l'objet trace du texte manuscrit) a été mis à l'échelle à la taille du conteneur (cadre). Lorsque la taille du conteneur (cadre) change, la taille du pinceau reste constante et inversement. 

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint adopte le même comportement lorsqu'il traite du texte :

![ink_powerpoint6](ink_powerpoint6.png)

**Lectures complémentaires**

* Pour en savoir plus sur les formes en général, consultez la section [PowerPoint Shapes](https://docs.aspose.com/slides/python-net/powerpoint-shapes/). 
* Pour plus d'informations sur les valeurs effectives, voir [Shape Effective Properties](https://docs.aspose.com/slides/python-net/shape-effective-properties/#get-effective-font-height-value).