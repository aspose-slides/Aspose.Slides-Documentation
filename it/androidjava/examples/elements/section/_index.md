---
title: Sezione
type: docs
weight: 90
url: /it/androidjava/examples/elements/section/
keywords:
- esempio di codice
- sezione
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Gestisci le sezioni delle diapositive in Aspose.Slides per Android: crea, rinomina, riordina e raggruppa le diapositive con esempi Java per PPT, PPTX e ODP."
---
Esempi per gestire le sezioni di presentazione—aggiungere, accedere, rimuovere e rinominare programmaticamente utilizzando **Aspose.Slides for Android via Java**.

## **Aggiungi una sezione**

Crea una sezione che inizia a una diapositiva specifica.

```java
static void addSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Specifica la diapositiva che segna l'inizio della sezione.
        presentation.getSections().addSection("New Section", slide);
    } finally {
        presentation.dispose();
    }
}
```

## **Accedi a una sezione**

Leggi le informazioni della sezione da una presentazione.

```java
static void accessSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        presentation.getSections().addSection("My Section", slide);

        // Accedi a una sezione per indice.
        ISection section = presentation.getSections().get_Item(0);
        String sectionName = section.getName();
    } finally {
        presentation.dispose();
    }
}
```

## **Rimuovi una sezione**

Elimina una sezione aggiunta in precedenza.

```java
static void removeSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISection section = presentation.getSections().addSection("Temporary Section", slide);

        // Rimuovi la prima sezione.
        presentation.getSections().removeSection(section);
    } finally {
        presentation.dispose();
    }
}
```

## **Rinomina una sezione**

Modifica il nome di una sezione esistente.

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