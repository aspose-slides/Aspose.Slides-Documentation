---
title: Encre
type: docs
weight: 180
url: /fr/androidjava/examples/elements/ink/
keywords:
- exemple de code
- encre
- PowerPoint
- OpenDocument
- présentation
- Android
- Java
- Aspose.Slides
description: "Travaillez avec l'encre dans Aspose.Slides for Android : dessinez, importez et modifiez les traits, ajustez la couleur et la largeur, et exportez vers PPT, PPTX et ODP à l'aide d'exemples Java."
---
Cet article fournit des exemples d'accès aux formes d'encre existantes et de leur suppression en utilisant **Aspose.Slides for Android via Java**.

> ❗ **Note:** Les formes d'encre représentent les entrées utilisateur provenant d'appareils spécialisés. Aspose.Slides ne peut pas créer de nouveaux traits d'encre de manière programmatique, mais vous pouvez lire et modifier les encres existantes.

## **Accéder à l'encre**

Lire les balises de la première forme d'encre d'une diapositive.

```java
static void accessInk() {
    Presentation presentation = new Presentation("ink.pptx");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IShape shape = slide.getShapes().get_Item(0);
        if (shape instanceof IInk) {
            IInk inkShape = (IInk) shape;
            ITagCollection tags = inkShape.getCustomData().getTags();
            if (tags.size() > 0) {
                String tagName = tags.getNameByIndex(0);
                // Utilisez tagName selon les besoins.
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Supprimer l'encre**

Supprimer une forme d'encre de la diapositive si elle existe.

```java
static void removeInk() {
    Presentation presentation = new Presentation("ink.pptx");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IInk ink = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IInk) {
                ink = (IInk) shape;
                break;
            }
        }
        if (ink != null) {
            slide.getShapes().remove(ink);
        }
    } finally {
        presentation.dispose();
    }
}
```