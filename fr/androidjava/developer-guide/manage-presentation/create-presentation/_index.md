---
title: Créer une présentation PowerPoint en Java
linktitle: Créer une présentation
type: docs
weight: 10
url: /androidjava/create-presentation/
keywords: créer ppt java, créer présentation ppt, créer pptx java
description: Apprenez à créer des présentations PowerPoint, par exemple PPT, PPTX en utilisant Java depuis zéro.
---

## **Créer une présentation PowerPoint**
Pour ajouter une simple ligne droite à une diapositive sélectionnée de la présentation, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe Presentation.
1. Obtenez la référence d'une diapositive en utilisant son index.
1. Ajoutez une forme automatique de type ligne en utilisant la méthode addAutoShape exposée par l'objet Shapes.
1. Écrivez la présentation modifiée en tant que fichier PPTX.

Dans l'exemple ci-dessous, nous avons ajouté une ligne à la première diapositive de la présentation.

```java
// Instancier un objet Presentation qui représente un fichier de présentation
Presentation pres = new Presentation();
try {
    // Obtenir la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);

    // Ajouter une autoshape de type ligne
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    pres.save("NewPresentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```