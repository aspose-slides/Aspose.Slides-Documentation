---
title: Gérer les objets d'encre de présentation sur Android
linktitle: Gérer l'encre
type: docs
weight: 95
url: /fr/androidjava/manage-ink/
keywords:
  - encre
  - objet d'encre
  - trace d'encre
  - gérer l'encre
  - dessiner l'encre
  - dessin
  - PowerPoint
  - présentation
  - Android
  - Java
  - Aspose.Slides
description: "Gérer les objets d'encre PowerPoint — créer, modifier et styliser l'encre numérique avec Aspose.Slides pour Android. Obtenez des exemples de code Java pour les traces, la couleur et la taille du pinceau."
---

PowerPoint offre la fonction d'encre pour vous permettre de dessiner des formes non standard, qui peuvent être utilisées pour mettre en évidence d'autres objets, montrer des connexions et des processus, et attirer l'attention sur des éléments spécifiques d'une diapositive. 

Aspose.Slides fournit tous les types d'encre (par exemple la classe [Encre](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ink/)) dont vous avez besoin pour créer et gérer des objets d'encre.

## **Différences entre les objets ordinaires et les objets d'encre**

Les objets sur une diapositive PowerPoint sont généralement représentés par des objets forme. Un objet forme, dans sa forme la plus simple, est un conteneur qui définit la zone de l'objet lui‑même (son cadre) ainsi que ses propriétés. Ces dernières incluent la taille de la zone du conteneur, la forme du conteneur, l'arrière‑plan du conteneur, etc. Pour plus d'informations, consultez [Format de disposition de forme](https://docs.aspose.com/slides/androidjava/shape-manipulations/#access-layout-formats-for-shape).

Cependant, lorsqu'un objet d'encre est manipulé dans PowerPoint, il ignore toutes les propriétés du cadre de l'objet (conteneur) sauf sa taille. La taille de la zone du conteneur est déterminée par les valeurs standard `width` et `height` :

![ink_powerpoint1](ink_powerpoint1.png)

## **Traces Inkshape**

Une trace est un élément de base ou une norme utilisée pour enregistrer la trajectoire d'un stylet lorsqu'un utilisateur écrit de l'encre numérique. Les traces sont des enregistrements qui décrivent des séquences de points connectés. 

La forme d'encodage la plus simple spécifie les coordonnées X et Y de chaque point d'échantillonnage. Lorsque tous les points connectés sont rendus, ils produisent une image comme celle‑ci :

![ink_powerpoint2](ink_powerpoint2.png)

## **Propriétés du pinceau pour le dessin**

Vous pouvez utiliser un pinceau pour tracer des lignes reliant les points des éléments de trace. Le pinceau possède sa propre couleur et taille, correspondant aux propriétés `Brush.Color` et `Brush.Size`. 

### **Définir la couleur du pinceau d'encre**

Ce code Java vous montre comment définir la couleur d'un pinceau :
```java
Presentation pres = new Presentation("pres.pptx");
try {
    IInk ink = (IInk)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IInkTrace[] traces = ink.getTraces();
    IInkBrush brush = traces[0].getBrush();
    Color brushColor = brush.getColor();
    brush.setColor(Color.RED);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Définir la taille du pinceau d'encre** 

Ce code Java vous montre comment définir la taille d'un pinceau :
```java
Presentation pres = new Presentation("pres.pptx");
try {
    IInk ink = (IInk)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IInkTrace[] traces = ink.getTraces();
    IInkBrush brush = traces[0].getBrush();
    Dimension2D brushSize = brush.getSize();
    brush.setSize(new Dimension(5, 10));
} finally {
    if (pres != null) pres.dispose();
}
```


En général, la largeur et la hauteur d'un pinceau ne correspondent pas, ainsi PowerPoint n'affiche pas la taille du pinceau (la section des données est grisées). Mais lorsque la largeur et la hauteur du pinceau correspondent, PowerPoint affiche sa taille de cette manière :

![ink_powerpoint3](ink_powerpoint3.png)

Pour plus de clarté, augmentons la hauteur de l'objet d'encre et examinons les dimensions importantes :

![ink_powerpoint4](ink_powerpoint4.png)

Le conteneur (cadre) ne prend pas en compte la taille des pinceaux — il suppose toujours que l'épaisseur de la ligne est nulle (voir la dernière image). 

Par conséquent, pour déterminer la zone visible de l'ensemble de l'objet d'encre, nous devons prendre en compte la taille du pinceau des objets trace. Ici, l'objet cible (l'objet trace du texte manuscrit) a été mis à l'échelle à la taille du conteneur (cadre). Lorsque la taille du conteneur (cadre) change, la taille du pinceau reste constante et inversement. 

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint présente le même comportement lorsqu'il traite du texte :

![ink_powerpoint6](ink_powerpoint6.png)

**Lectures complémentaires**

* Pour en savoir plus sur les formes en général, consultez la section [Formes PowerPoint](https://docs.aspose.com/slides/androidjava/powerpoint-shapes/).
* Pour plus d'informations sur les valeurs effectives, consultez [Propriétés effectives des formes](https://docs.aspose.com/slides/androidjava/shape-effective-properties/#getting-effective-font-height-value).