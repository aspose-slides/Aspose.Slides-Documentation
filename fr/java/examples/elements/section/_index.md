---
title: Section
type: docs
weight: 90
url: /fr/java/examples/elements/section/
keywords:
- exemple de code
- section
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Gérez les sections de diapositives dans Aspose.Slides for Java : créez, renommez, réorganisez et regroupez les diapositives avec des exemples Java pour PPT, PPTX et ODP."
---
Exemples de gestion des sections de présentation — ajouter, accéder, supprimer et renommer celles‑ci par programmation à l'aide de **Aspose.Slides for Java**.

## **Ajouter une section**

Créer une section qui commence à une diapositive spécifique.

```java
static void addSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Spécifiez la diapositive qui marque le début de la section.
        presentation.getSections().addSection("New Section", slide);
    } finally {
        presentation.dispose();
    }
}
```

## **Accéder à une section**

Lire les informations de la section à partir d'une présentation.

```java
static void accessSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        presentation.getSections().addSection("My Section", slide);

        // Accédez à une section par indice.
        ISection section = presentation.getSections().get_Item(0);
        String sectionName = section.getName();
    } finally {
        presentation.dispose();
    }
}
```

## **Supprimer une section**

Supprimer une section précédemment ajoutée.

```java
static void removeSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISection section = presentation.getSections().addSection("Temporary Section", slide);

        // Supprimez la première section.
        presentation.getSections().removeSection(section);
    } finally {
        presentation.dispose();
    }
}
```

## **Renommer une section**

Modifier le nom d'une section existante.

```java
static void renameSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        presentation.getSections().addSection("Old Name", slide);

        ISection section = presentation.getSections().get_Item(0);
        section.setName("New Name");
    } finally {
        presentation.dispose();
    }
}
```