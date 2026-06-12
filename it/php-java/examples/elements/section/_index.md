---
title: Sezione
type: docs
weight: 90
url: /it/php-java/examples/elements/section/
keywords:
- sezione
- sezione diapositiva
- aggiungere sezione
- accedere sezione
- rimuovere sezione
- rinominare sezione
- esempi di codice
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Gestisci le sezioni delle diapositive in PHP con Aspose.Slides: crea, rinomina, riordina facilmente, sposta le diapositive tra le sezioni e controlla la visibilità per PPT, PPTX e ODP."
---
Esempi per gestire le sezioni di presentazione—aggiungere, accedere, rimuovere e rinominare programmaticamente utilizzando **Aspose.Slides for PHP via Java**.

## **Aggiungi una sezione**

Crea una sezione che inizia a una diapositiva specifica.

```php
function addSection() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Specifica la diapositiva che segna l'inizio della sezione.
        $presentation->getSections()->addSection("New Section", $slide);

        $presentation->save("section.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Accedi a una sezione**

Leggi le informazioni della sezione da una presentazione.

```php
function accessSection() {
    $presentation = new Presentation("section.pptx");
    try {
        // Accedi a una sezione per indice.
        $section = $presentation->getSections()->get_Item(0);
        $sectionName = $section->getName();
    } finally {
        $presentation->dispose();
    }
}
```

## **Rimuovi una sezione**

Elimina una sezione precedentemente aggiunta.

```php
function removeSection() {
    $presentation = new Presentation("section.pptx");
    try {
        $section = $presentation->getSections()->get_Item(0);

        // Rimuovi la sezione.
        $presentation->getSections()->removeSection($section);

        $presentation->save("section_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Rinomina una sezione**

Cambia il nome di una sezione esistente.

```php
function renameSection() {
    $presentation = new Presentation("section.pptx");
    try {
        $section = $presentation->getSections()->get_Item(0);
        $section->setName("New Name");

        $presentation->save("section_renamed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```