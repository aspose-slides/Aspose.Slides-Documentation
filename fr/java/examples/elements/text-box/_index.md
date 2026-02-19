---
title: Zone de texte
type: docs
weight: 40
url: /fr/java/examples/elements/text-box/
keywords:
- exemple de code
- zone de texte
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Travaillez avec les zones de texte dans Aspose.Slides pour Java : ajoutez, formatez, alignez, enveloppez, ajustez automatiquement et stylisez le texte avec Java pour les présentations PPT, PPTX et ODP."
---
Dans Aspose.Slides, une **zone de texte** est représentée par un `AutoShape`. Pratiquement n'importe quelle forme peut contenir du texte, mais une zone de texte typique n'a ni remplissage ni bordure et n'affiche que du texte.

Ce guide explique comment ajouter, accéder et supprimer des zones de texte par programme.

## **Ajouter une zone de texte**

Une zone de texte est simplement un `AutoShape` sans remplissage ni bordure et contenant du texte formaté. Voici comment en créer une :

```java
public static void addTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Créez une forme rectangulaire (remplie par défaut avec bordure et aucun texte).
        IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100);

        // Supprimez le remplissage et la bordure pour qu'elle ressemble à une zone de texte typique.
        textBox.getFillFormat().setFillType(FillType.NoFill);
        textBox.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        // Définissez le formatage du texte.
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        IPortionFormat textFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();
        textFormat.getFillFormat().setFillType(FillType.Solid);
        textFormat.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        // Assignez le texte réel.
        textBox.getTextFrame().setText("Some text...");
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Remarque :** Tout `AutoShape` qui contient un `TextFrame` non vide peut fonctionner comme une zone de texte.

## **Accéder aux zones de texte par contenu**

Pour trouver toutes les zones de texte contenant un mot-clé spécifique (par exemple "Slide"), parcourez les formes et vérifiez leur texte :

```java
public static void accessTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        for (IShape shape : slide.getShapes()) {
            // Seules les AutoShapes peuvent contenir du texte modifiable.
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                if (autoShape.getTextFrame().getText().contains("Slide")) {
                    // Faire quelque chose avec la zone de texte correspondante.
                }
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Supprimer les zones de texte par contenu**

Cet exemple trouve et supprime toutes les zones de texte de la première diapositive qui contiennent un mot-clé spécifique :

```java
public static void removeTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        List<IShape> shapesToRemove = new ArrayList<IShape>();
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                if (autoShape.getTextFrame().getText().contains("Slide")) {
                    shapesToRemove.add(shape);
                }
            }
        }

        for (IShape shape : shapesToRemove) {
            slide.getShapes().remove(shape);
        }
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Astuce :** Créez toujours une copie de la collection de formes avant de la modifier pendant l'itération afin d'éviter les erreurs de modification de la collection.