---
title: Gérer l'encre
type: docs
weight: 95
url: /fr/python-net/manage-ink/
keywords: "Encre dans PowerPoint, outils d'encre, encre Python, dessiner dans PowerPoint, présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Utilisez des outils d'encre pour dessiner des objets dans PowerPoint Python"
---

PowerPoint fournit la fonction d'encre pour vous permettre de dessiner des figures non standards, qui peuvent être utilisées pour mettre en évidence d'autres objets, montrer des connexions et des processus, et attirer l'attention sur des éléments spécifiques d'une diapositive. 

Aspose.Slides fournit l'interface [Aspose.Slides.Ink](https://reference.aspose.com/slides/python-net/aspose.slides.ink/), qui contient les types nécessaires pour créer et gérer des objets d'encre. 

## **Différences entre les objets réguliers et les objets d'encre**

Les objets sur une diapositive PowerPoint sont généralement représentés par des objets de forme. Un objet de forme, dans sa forme la plus simple, est un conteneur qui définit la zone de l'objet lui-même (son cadre) ainsi que ses propriétés. Celles-ci comprennent la taille de la zone du conteneur, la forme du conteneur, l'arrière-plan du conteneur, etc. Pour plus d'informations, consultez [Format de mise en page de forme](https://docs.aspose.com/slides/python-net/shape-manipulations/#access-layout-formats-for-shape).

Cependant, lorsque PowerPoint traite un objet d'encre, il ignore toutes les propriétés du cadre de l'objet (conteneur) sauf sa taille. La taille de la zone du conteneur est déterminée par les valeurs standard de `width` et `height`:

![ink_powerpoint1](ink_powerpoint1.png)

## **Traces d'encre**

Une trace est un élément de base ou standard utilisé pour enregistrer la trajectoire d'un stylo alors qu'un utilisateur écrit avec de l'encre numérique. Les traces sont des enregistrements qui décrivent des séquences de points connectés. 

La forme la plus simple de codage spécifie les coordonnées X et Y de chaque point d'échantillon. Lorsque tous les points connectés sont rendus, ils produisent une image comme celle-ci:

![ink_powerpoint2](ink_powerpoint2.png)

## Propriétés du pinceau pour dessiner 

Vous pouvez utiliser un pinceau pour dessiner des lignes connectant les points des éléments de trace. Le pinceau a sa propre couleur et taille, correspondant aux propriétés `Brush.Color` et `Brush.Size`. 

### **Définir la couleur du pinceau d'encre**

Ce code Python vous montre comment définir la couleur d'un pinceau:

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

### **Définir la taille du pinceau d'encre** 

Ce code Python vous montre comment définir la taille d'un pinceau:

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

En général, la largeur et la hauteur d'un pinceau ne correspondent pas, donc PowerPoint n'affiche pas la taille du pinceau (la section de données est grisée). Mais lorsque la largeur et la hauteur du pinceau correspondent, PowerPoint affiche sa taille de cette manière:

![ink_powerpoint3](ink_powerpoint3.png)

Pour plus de clarté, augmentons la hauteur de l'objet d'encre et examinons les dimensions importantes: 

![ink_powerpoint4](ink_powerpoint4.png)

Le conteneur (cadre) ne prend pas en compte la taille des pinceaux--il suppose toujours que l'épaisseur de la ligne est nulle (voir la dernière image). 

Donc, pour déterminer la zone visible de l'ensemble de l'objet d'encre, nous devons considérer la taille du pinceau des objets de trace. Ici, l'objet cible (l'objet de trace de texte manuscrit) a été mis à l'échelle à la taille du conteneur (cadre). Lorsque la taille du conteneur (cadre) change, la taille du pinceau reste constante et vice versa. 

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint présente le même comportement lorsqu'il s'agit de textes:

![ink_powerpoint6](ink_powerpoint6.png)

**Lectures complémentaires**

* Pour lire sur les formes en général, consultez la section [Formes PowerPoint](https://docs.aspose.com/slides/python-net/powerpoint-shapes/). 
* Pour plus d'informations sur les valeurs effectives, consultez [Propriétés effectives de la forme](https://docs.aspose.com/slides/python-net/shape-effective-properties/#get-effective-font-height-value). 
