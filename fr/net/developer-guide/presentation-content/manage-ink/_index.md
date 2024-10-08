---
title: Gérer l'encre
type: docs
weight: 95
url: /fr/net/manage-ink/
keywords: "Encre dans PowerPoint, Outils d'encre, C# Encre, Dessiner dans PowerPoint, Présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET "
description: "Utilisez les outils d'encre pour dessiner des objets dans PowerPoint C#"
---

PowerPoint fournit la fonction d'encre pour vous permettre de dessiner des figures non-standard, qui peuvent être utilisées pour mettre en évidence d'autres objets, montrer des connexions et des processus, et attirer l'attention sur des éléments spécifiques d'une diapositive.

Aspose.Slides fournit l'interface [Aspose.Slides.Ink](https://reference.aspose.com/slides/net/aspose.slides.ink/), qui contient les types dont vous avez besoin pour créer et gérer des objets d'encre.

## **Différences entre les Objets Normaux et les Objets d'Encre**

Les objets sur une diapositive PowerPoint sont généralement représentés par des objets de forme. Un objet de forme, sous sa forme la plus simple, est un conteneur qui définit la zone de l'objet lui-même (son cadre) ainsi que ses propriétés. Ces dernières incluent la taille de la zone du conteneur, la forme du conteneur, l'arrière-plan du conteneur, etc. Pour plus d'informations, voir [Format de Disposition de Forme](https://docs.aspose.com/slides/net/shape-manipulations/#access-layout-formats-for-shape).

Cependant, lorsque PowerPoint traite un objet d'encre, il ignore toutes les propriétés du cadre de l'objet (conteneur) sauf sa taille. La taille de la zone du conteneur est déterminée par les valeurs standard `width` et `height` :

![ink_powerpoint1](ink_powerpoint1.png)

## **Traces d'Inkshape**

Une trace est un élément de base ou une norme utilisée pour enregistrer la trajectoire d'un stylo à mesure qu'un utilisateur écrit de l'encre numérique. Les traces sont des enregistrements qui décrivent des séquences de points connectés.

La forme la plus simple d'encodage spécifie les coordonnées X et Y de chaque point d'échantillonnage. Lorsque tous les points connectés sont rendus, ils produisent une image comme celle-ci :

![ink_powerpoint2](ink_powerpoint2.png)

## Propriétés de Pinceau Pour Dessiner 

Vous pouvez utiliser un pinceau pour dessiner des lignes reliant les points des éléments de trace. Le pinceau a sa propre couleur et taille, correspondant aux propriétés `Brush.Color` et `Brush.Size`.

### **Définir la Couleur du Pinceau d'Encre**

Ce code C# vous montre comment définir la couleur d'un pinceau :

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

### **Définir la Taille du Pinceau d'Encre **

Ce code C# vous montre comment définir la taille d'un pinceau :

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

En général, la largeur et la hauteur d'un pinceau ne correspondent pas, donc PowerPoint n'affiche pas la taille du pinceau (la section de données est grisée). Mais lorsque la largeur et la hauteur du pinceau correspondent, PowerPoint affiche sa taille de cette manière :

![ink_powerpoint3](ink_powerpoint3.png)

Pour plus de clarté, augmentons la hauteur de l'objet d'encre et examinons les dimensions importantes :

![ink_powerpoint4](ink_powerpoint4.png)

Le conteneur (cadre) ne prend pas en compte la taille des pinceaux--il suppose toujours que l'épaisseur de la ligne est nulle (voir la dernière image).

Par conséquent, pour déterminer la zone visible de l'ensemble de l'objet d'encre, nous devons tenir compte de la taille du pinceau des objets de trace. Ici, l'objet cible (l'objet de trace de texte manuscrit) a été mis à l'échelle à la taille du conteneur (cadre). Lorsque la taille du conteneur (cadre) change, la taille du pinceau reste constante et vice versa.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint exhibe le même comportement lorsqu'il traite des textes :

![ink_powerpoint6](ink_powerpoint6.png)

**Lectures complémentaires**

* Pour lire sur les formes en général, voir la section [Formes PowerPoint](https://docs.aspose.com/slides/net/powerpoint-shapes/). 
* Pour plus d'informations sur les valeurs effectives, voir [Propriétés Effectives des Formes](https://docs.aspose.com/slides/net/shape-effective-properties/#get-effective-font-height-value).