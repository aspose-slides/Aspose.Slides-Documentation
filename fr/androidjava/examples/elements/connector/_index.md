---
title: Connecteur
type: docs
weight: 190
url: /fr/androidjava/examples/elements/connector/
keywords:
- exemple de code
- Connecteur
- PowerPoint
- OpenDocument
- présentation
- Android
- Java
- Aspose.Slides
description: "Apprenez comment ajouter, acheminer et styliser des connecteurs entre des formes en utilisant Aspose.Slides pour Android, avec des exemples Java pour les présentations PPT, PPTX et ODP."
---
Cet article montre comment connecter des formes à l'aide de connecteurs et modifier leurs cibles en utilisant **Aspose.Slides for Android via Java**.

## **Ajouter un connecteur**

Insérez une forme de connecteur entre deux points de la diapositive.

```java
static void addConnector() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100);
    } finally {
        presentation.dispose();
    }
}
```

## **Accéder à un connecteur**

Récupérez la première forme de connecteur ajoutée à une diapositive.

```java
static void accessConnector() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

        // Accéder au premier connecteur de la diapositive.
        IConnector connector = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IConnector) {
                connector = (IConnector) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Supprimer un connecteur**

Supprimez un connecteur de la diapositive.

```java
static void removeConnector() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

        slide.getShapes().remove(connector);
    } finally {
        presentation.dispose();
    }
}
```

## **Reconnecter des formes**

Attachez un connecteur à deux formes en attribuant des cibles de début et de fin.

```java
static void reconnectShapes() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
        IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 50, 50);
        IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

        connector.setStartShapeConnectedTo(shape1);
        connector.setEndShapeConnectedTo(shape2);
    } finally {
        presentation.dispose();
    }
}
```