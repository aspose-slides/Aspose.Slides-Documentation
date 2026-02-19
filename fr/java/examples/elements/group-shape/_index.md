---
title: Forme groupée
type: docs
weight: 170
url: /fr/java/examples/elements/group-shape/
keywords:
- exemple de code
- forme groupée
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Gérer les formes groupées dans Aspose.Slides for Java : créer, imbriquer, aligner, réorganiser et styliser les formes groupées avec des exemples Java dans des présentations PPT, PPTX et ODP."
---
Exemples de création de groupes de formes, d'accès, de dégroupage et de suppression à l'aide de **Aspose.Slides for Java**.

## **Ajouter une forme groupée**

Créez un groupe contenant deux formes de base.

```java
static void addGroupShape() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IGroupShape group = slide.getShapes().addGroupShape();
        group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
        group.getShapes().addAutoShape(ShapeType.Ellipse, 60, 0, 50, 50);
    } finally {
        presentation.dispose();
    }
}
```

## **Accéder à une forme groupée**

Récupérez la première forme groupée d’une diapositive.

```java
static void accessGroupShape() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IGroupShape group = slide.getShapes().addGroupShape();
        group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

        IGroupShape firstGroup = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IGroupShape) {
                firstGroup = (IGroupShape) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Supprimer une forme groupée**

Supprimez une forme groupée de la diapositive.

```java
static void removeGroupShape() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IGroupShape group = slide.getShapes().addGroupShape();

        slide.getShapes().remove(group);
    } finally {
        presentation.dispose();
    }
}
```

## **Dégrouper les formes**

Déplacez les formes hors du conteneur de groupe.

```java
static void ungroupShapes() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IGroupShape group = slide.getShapes().addGroupShape();
        IAutoShape rect = group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

        // Déplacer la forme hors du groupe.
        slide.getShapes().addClone(rect);
        group.getShapes().remove(rect);
    } finally {
        presentation.dispose();
    }
}
```