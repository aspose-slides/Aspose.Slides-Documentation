---
title: Hyperlien
type: docs
weight: 130
url: /fr/java/examples/elements/hyperlink/
keywords:
- exemple de code
- hyperlien
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Ajoutez et gérez les hyperliens dans Aspose.Slides for Java : texte du lien, formes et images, définissez les cibles et les actions pour PPT, PPTX et ODP avec des exemples Java."
---
Cet article montre comment ajouter, accéder, supprimer et mettre à jour des hyperliens sur des formes en utilisant **Aspose.Slides for Java**.

## **Ajouter un hyperlien**

Créez une forme rectangulaire avec un hyperlien pointant vers un site Web externe.

```java
static void addHyperlink() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        textPortion.getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com"));
    } finally {
        presentation.dispose();
    }
}
```

## **Accéder à un hyperlien**

Lisez les informations d'hyperlien à partir de la partie texte d'une forme.

```java
static void accessHyperlink() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        textPortion.getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com"));

        IHyperlink hyperlink = textPortion.getPortionFormat().getHyperlinkClick();
    } finally {
        presentation.dispose();
    }
}
```

## **Supprimer un hyperlien**

Supprimez l'hyperlien du texte d'une forme.

```java
static void removeHyperlink() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        textPortion.getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com"));

        textPortion.getPortionFormat().setHyperlinkClick(null);
    } finally {
        presentation.dispose();
    }
}
```

## **Mettre à jour un hyperlien**

Modifiez la cible d'un hyperlien existant. Utilisez `HyperlinkManager` pour modifier le texte contenant déjà un hyperlien, ce qui reproduit la façon dont PowerPoint met à jour les hyperliens en toute sécurité.

```java
static void updateHyperlink() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        textPortion.getPortionFormat().setHyperlinkClick(new Hyperlink("https://old.example.com"));

        // Modifier un hyperlien dans le texte existant doit être effectué via
        // HyperlinkManager plutôt qu'en définissant la propriété directement.
        // Cela reproduit la façon dont PowerPoint met à jour les hyperliens en toute sécurité.
        textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com");
    } finally {
        presentation.dispose();
    }
}
```