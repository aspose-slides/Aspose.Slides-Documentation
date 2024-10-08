---
title: Créer une présentation PowerPoint en utilisant Java
linktitle: Créer une présentation
type: docs
weight: 10
url: /fr/java/create-presentation/
keywords: créer ppt java, créer présentation ppt, créer pptx java
description: Apprenez à créer des présentations PowerPoint, par exemple PPT, PPTX en utilisant Java depuis zéro.
---

## **Créer une présentation PowerPoint**
Pour ajouter une simple ligne vierge à une diapositive sélectionnée de la présentation, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe Presentation.
1. Obtenez la référence d'une diapositive en utilisant son Index.
1. Ajoutez une AutoShape de type Line en utilisant la méthode addAutoShape exposée par l'objet Shapes.
1. Écrivez la présentation modifiée en tant que fichier PPTX.

Dans l'exemple donné ci-dessous, nous avons ajouté une ligne à la première diapositive de la présentation.

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