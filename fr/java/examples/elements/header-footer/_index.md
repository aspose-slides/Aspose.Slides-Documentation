---
title: En-tête Pied de page
type: docs
weight: 220
url: /fr/java/examples/elements/header-footer/
keywords:
- exemple de code
- en-tête
- pied de page
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Contrôlez les en-têtes et pieds de page des diapositives avec Aspose.Slides for Java : ajoutez des dates, des numéros de diapositives et du texte personnalisé dans PPT, PPTX et ODP avec des exemples Java."
---
Cet article montre comment ajouter des pieds de page et mettre à jour les espaces réservés de date et d'heure en utilisant **Aspose.Slides for Java**.

## **Ajouter un pied de page**

Ajoutez du texte à la zone de pied de page d'une diapositive et rendez-le visible.

```java
static void addHeaderFooter() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setFooterText("My footer");
        slide.getHeaderFooterManager().setFooterVisibility(true);
    } finally {
        presentation.dispose();
    }
}
```

## **Mettre à jour la date et l'heure**

Modifiez l'espace réservé de date et d'heure d'une diapositive.

```java
static void updateDateTime() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setDateTimeText("01/01/2024");
        slide.getHeaderFooterManager().setDateTimeVisibility(true);
    } finally {
        presentation.dispose();
    }
}
```