---
title: Gérer les objets d'encre de présentation en JavaScript
linktitle: "Gérer l'encre"
type: docs
weight: 95
url: /fr/nodejs-java/manage-ink/
keywords:
- encre
- objet encre
- trace encre
- gérer l'encre
- dessiner l'encre
- dessin
- PowerPoint
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Gérer les objets d'encre PowerPoint—créer, modifier et styliser l'encre numérique avec Aspose.Slides pour Node.js. Obtenez des exemples de code JavaScript pour les traces, la couleur et la taille du pinceau."
---

PowerPoint propose la fonction encre pour vous permettre de dessiner des formes non standard, utilisables pour mettre en évidence d’autres objets, montrer des connexions et des processus, et attirer l’attention sur des éléments spécifiques d’une diapositive. 

Aspose.Slides fournit tous les types d’encre (par exemple la classe [Ink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ink/)) dont vous avez besoin pour créer et gérer des objets encre.

## **Différences entre les objets classiques et les objets encre**

Les objets d’une diapositive PowerPoint sont généralement représentés par des objets forme. Un objet forme, dans sa forme la plus simple, est un conteneur qui définit la zone de l’objet lui‑même (son cadre) ainsi que ses propriétés. Ces dernières comprennent la taille de la zone du conteneur, la forme du conteneur, l’arrière‑plan du conteneur, etc. Pour plus d’informations, voir [Shape Layout Format](https://docs.aspose.com/slides/nodejs-java/shape-manipulations/#access-layout-formats-for-shape).

Cependant, lorsque PowerPoint manipule un objet encre, il ignore toutes les propriétés du cadre de l’objet (conteneur) sauf sa taille. La taille de la zone du conteneur est déterminée par les valeurs standard `width` et `height` :

![ink_powerpoint1](ink_powerpoint1.png)

## **Traces d’Inkshape**

Une trace est un élément de base ou une norme utilisée pour enregistrer la trajectoire d’un stylet lorsqu’un utilisateur écrit de l’encre numérique. Les traces sont des enregistrements qui décrivent des séquences de points connectés. 

La forme la plus simple de codage indique les coordonnées X et Y de chaque point d’échantillonnage. Lorsque tous les points connectés sont rendus, ils produisent une image comme celle‑ci :

![ink_powerpoint2](ink_powerpoint2.png)

## **Propriétés du pinceau pour le dessin**

Vous pouvez utiliser un pinceau pour dessiner des lignes reliant les points des éléments de trace. Le pinceau possède sa propre couleur et sa propre taille, correspondant aux méthodes `Brush.setColor` et `Brush.setSize`. 

### **Définir la couleur du pinceau d’encre**

Ce code JavaScript montre comment définir la couleur d’un pinceau :
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var ink = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var traces = ink.getTraces();
    var brush = traces[0].getBrush();
    var brushColor = brush.getColor();
    brush.setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Définir la taille du pinceau d’encre** 

Ce code JavaScript montre comment définir la taille d’un pinceau :
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var ink = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var traces = ink.getTraces();
    var brush = traces[0].getBrush();
    var brushSize = brush.getSize();
    brush.setSize(java.newInstanceSync("java.awt.Dimension", 5, 10));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


En général, la largeur et la hauteur d’un pinceau ne correspondent pas, de sorte que PowerPoint n’affiche pas la taille du pinceau (la section des données est grisées). Mais lorsque la largeur et la hauteur du pinceau correspondent, PowerPoint affiche sa taille ainsi :

![ink_powerpoint3](ink_powerpoint3.png)

Pour plus de clarté, augmentons la hauteur de l’objet encre et examinons les dimensions importantes :

![ink_powerpoint4](ink_powerpoint4.png)

Le conteneur (cadre) ne tient pas compte de la taille des pinceaux — il suppose toujours que l’épaisseur de la ligne est nulle (voir la dernière image). 

Ainsi, pour déterminer la zone visible de l’ensemble de l’objet encre, nous devons prendre en compte la taille du pinceau des objets trace. Ici, l’objet cible (l’objet trace de texte manuscrit) a été mis à l’échelle selon la taille du conteneur (cadre). Lorsque la taille du conteneur (cadre) change, la taille du pinceau reste constante et inversement. 

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint présente le même comportement lorsqu’il traite du texte :

![ink_powerpoint6](ink_powerpoint6.png)

**Lectures complémentaires**

* Pour en savoir plus sur les formes en général, consultez la section [PowerPoint Shapes](https://docs.aspose.com/slides/nodejs-java/powerpoint-shapes/).
* Pour plus d’informations sur les valeurs effectives, voir [Shape Effective Properties](https://docs.aspose.com/slides/nodejs-java/shape-effective-properties/#getting-effective-font-height-value).