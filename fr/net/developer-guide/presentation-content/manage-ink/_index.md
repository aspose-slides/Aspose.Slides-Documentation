---
title: Gérer les objets d'encre de présentation dans .NET
linktitle: Gérer l'encre
type: docs
weight: 95
url: /fr/net/manage-ink/
keywords:
- encre
- objet encre
- trace d'encre
- gérer l'encre
- dessiner l'encre
- dessin
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Gérez les objets d'encre PowerPoint — créez, modifiez et stylisez l'encre numérique avec Aspose.Slides pour .NET. Obtenez des exemples de code pour les traces, la couleur et la taille du pinceau."
---

PowerPoint propose la fonction encre qui vous permet de dessiner des figures non standard, pouvant être utilisées pour mettre en évidence d’autres objets, montrer des connexions et des processus, et attirer l’attention sur des éléments spécifiques d’une diapositive. 

Aspose.Slides fournit l’interface [Aspose.Slides.Ink](https://reference.aspose.com/slides/net/aspose.slides.ink/) qui contient les types nécessaires pour créer et gérer des objets encre. 

## **Différences entre les objets normaux et les objets encre**

Les objets d’une diapositive PowerPoint sont généralement représentés par des objets de forme. Un objet de forme, dans sa forme la plus simple, est un conteneur qui définit la zone de l’objet lui‑même (son cadre) ainsi que ses propriétés. Ces dernières comprennent la taille de la zone du conteneur, la forme du conteneur, l’arrière‑plan du conteneur, etc. Pour plus d’informations, voir [Shape Layout Format](https://docs.aspose.com/slides/net/shape-manipulations/#access-layout-formats-for-shape).

Cependant, lorsqu’il s’agit d’un objet encre, PowerPoint ignore toutes les propriétés du cadre de l’objet (conteneur) sauf sa taille. La taille de la zone du conteneur est déterminée par les valeurs standard `width` et `height` :

![ink_powerpoint1](ink_powerpoint1.png)

## **Traces Inkshape**

Une trace est un élément de base ou une norme utilisée pour enregistrer la trajectoire d’un stylet lorsque l’utilisateur écrit de l’encre numérique. Les traces sont des enregistrements qui décrivent des séquences de points connectés. 

La forme la plus simple d’encodage spécifie les coordonnées X et Y de chaque point d’échantillon. Lorsque tous les points connectés sont rendus, ils produisent une image comme celle‑ci :

![ink_powerpoint2](ink_powerpoint2.png)

## **Propriétés du pinceau pour le dessin**

Vous pouvez utiliser un pinceau pour dessiner des lignes reliant les points des éléments de trace. Le pinceau possède sa propre couleur et taille, correspondant aux propriétés `Brush.Color` et `Brush.Size`. 

### **Définir la couleur du pinceau encre**

This C# code shows you how to set the color for a brush:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    IInk ink = (IInk)pres.Slides[0].Shapes[0];
    IInkTrace[] traces = ink.Traces;
    IInkBrush brush = traces[0].Brush;
    Color brushColor = brush.Color;
    brush.Color = Color.Red;
}
```


### **Définir la taille du pinceau encre** 

This C# code shows you how to set the size for a brush:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    IInk ink = (IInk)pres.Slides[0].Shapes[0];
    IInkTrace[] traces = ink.Traces;
    IInkBrush brush = traces[0].Brush;
    SizeF brushSize = brush.Size;
    brush.Size = new SizeF(5f, 10f);
}
```


En général, la largeur et la hauteur d’un pinceau ne correspondent pas, ainsi PowerPoint n’affiche pas la taille du pinceau (la section des données est grisée). Mais lorsque la largeur et la hauteur du pinceau sont identiques, PowerPoint affiche sa taille de la manière suivante :

![ink_powerpoint3](ink_powerpoint3.png)

Pour plus de clarté, augmentons la hauteur de l’objet encre et examinons les dimensions importantes :

![ink_powerpoint4](ink_powerpoint4.png)

Le conteneur (cadre) ne prend pas en compte la taille des pinceaux — il suppose toujours que l’épaisseur de la ligne est nulle (voir la dernière image). 

Par conséquent, pour déterminer la zone visible de l’ensemble de l’objet encre, nous devons prendre en compte la taille du pinceau des objets trace. Ici, l’objet cible (l’objet trace du texte manuscrit) a été mis à l’échelle selon la taille du conteneur (cadre). Lorsque la taille du conteneur (cadre) change, la taille du pinceau reste constante et inversement. 

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint présente le même comportement lorsqu’il s’agit de textes :

![ink_powerpoint6](ink_powerpoint6.png)

**Lectures complémentaires**

* Pour en savoir plus sur les formes en général, consultez la section [PowerPoint Shapes](https://docs.aspose.com/slides/net/powerpoint-shapes/). 
* Pour plus d’informations sur les valeurs effectives, voir [Shape Effective Properties](https://docs.aspose.com/slides/net/shape-effective-properties/#get-effective-font-height-value).