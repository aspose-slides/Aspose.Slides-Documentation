---
title: Gérer l'encre
type: docs
weight: 95
url: /php-java/manage-ink/
keywords: "Encre dans PowerPoint, outils d'encre, Encre Java, Dessiner dans PowerPoint, présentation PowerPoint, Java, Aspose.Slides pour PHP via Java"
description: "Utilisez les outils d'encre pour dessiner des objets dans PowerPoint Java"
---

PowerPoint fournit la fonction d'encre pour vous permettre de dessiner des figures non standards, qui peuvent être utilisées pour mettre en évidence d'autres objets, montrer des connexions et des processus, et attirer l'attention sur des éléments spécifiques d'une diapositive.

Aspose.Slides fournit tous les types d'encre (par exemple, la classe [Ink](https://reference.aspose.com/slides/php-java/aspose.slides/ink/)) dont vous avez besoin pour créer et gérer des objets d'encre.

## **Différences entre les Objets Standards et les Objets d'Encre**

Les objets sur une diapositive PowerPoint sont typiquement représentés par des objets de forme. Un objet de forme, dans sa forme la plus simple, est un conteneur qui définit la zone de l'objet lui-même (son cadre) ainsi que ses propriétés. Ces dernières incluent la taille de la zone du conteneur, la forme du conteneur, l'arrière-plan du conteneur, etc. Pour plus d'informations, voir [Format de Mise en Page des Formes](https://docs.aspose.com/slides/php-java/shape-manipulations/#access-layout-formats-for-shape).

Cependant, lorsque PowerPoint traite un objet d'encre, il ignore toutes les propriétés du cadre de l'objet (conteneur) sauf sa taille. La taille de la zone du conteneur est déterminée par les valeurs standards de `width` et `height` :

![ink_powerpoint1](ink_powerpoint1.png)

## **Traces d'Inkshape**

Une trace est un élément de base ou standard utilisé pour enregistrer la trajectoire d'un stylo lorsqu'un utilisateur écrit de l'encre numérique. Les traces sont des enregistrements qui décrivent des séquences de points connectés.

La forme la plus simple d'encodage spécifie les coordonnées X et Y de chaque point d'échantillon. Lorsque tous les points connectés sont rendus, ils produisent une image comme celle-ci :

![ink_powerpoint2](ink_powerpoint2.png)

## Propriétés du Pinceau pour Dessiner

Vous pouvez utiliser un pinceau pour dessiner des lignes reliant les points des éléments de trace. Le pinceau a sa propre couleur et taille, correspondant aux propriétés `Brush.Color` et `Brush.Size`.

### **Définir la Couleur du Pinceau d'Encre**

Ce code PHP vous montre comment définir la couleur d'un pinceau :

```php
  $pres = new Presentation("pres.pptx");
  try {
    $ink = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $traces = $ink->getTraces();
    $brush = $traces[0]->getBrush();
    $brushColor = $brush->getColor();
    $brush->setColor(java("java.awt.Color")->RED);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Définir la Taille du Pinceau d'Encre**

Ce code PHP vous montre comment définir la taille d'un pinceau :

```php
  $pres = new Presentation("pres.pptx");
  try {
    $ink = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $traces = $ink->getTraces();
    $brush = $traces[0]->getBrush();
    $brushSize = $brush->getSize();
    $brush->setSize(new Java("java.awt.Dimension", 5, 10));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

En général, la largeur et la hauteur d'un pinceau ne correspondent pas, donc PowerPoint ne montre pas la taille du pinceau (la section de données est grisée). Mais lorsque la largeur et la hauteur du pinceau correspondent, PowerPoint affiche sa taille de cette manière :

![ink_powerpoint3](ink_powerpoint3.png)

Pour plus de clarté, augmentons la hauteur de l'objet d'encre et examinons les dimensions importantes :

![ink_powerpoint4](ink_powerpoint4.png)

Le conteneur (cadre) ne considère pas la taille des pinceaux--il suppose toujours que l'épaisseur de la ligne est zéro (voir la dernière image).

Par conséquent, pour déterminer la zone visible de l'ensemble de l'objet d'encre, nous devons tenir compte de la taille du pinceau des objets de trace. Ici, l'objet cible (l'objet de trace de texte manuscrit) a été mis à l'échelle à la taille du conteneur (cadre). Lorsque la taille du conteneur (cadre) change, la taille du pinceau reste constante et vice versa.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint présente le même comportement lorsqu'il s'agit de textes :

![ink_powerpoint6](ink_powerpoint6.png)

**Lectures complémentaires**

* Pour lire à propos des formes en général, voir la section [Formes PowerPoint](https://docs.aspose.com/slides/php-java/powerpoint-shapes/).
* Pour plus d'informations sur les valeurs effectives, voir [Propriétés Effectives des Formes](https://docs.aspose.com/slides/php-java/shape-effective-properties/#getting-effective-font-height-value).