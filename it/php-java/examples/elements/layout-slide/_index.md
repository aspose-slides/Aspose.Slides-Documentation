---
title: Diapositiva di layout
type: docs
weight: 20
url: /it/php-java/examples/elements/layout-slide/
keywords:
- diapositiva di layout
- aggiungi diapositiva di layout
- accedi alla diapositiva di layout
- rimuovi diapositiva di layout
- diapositiva di layout inutilizzata
- clona diapositiva di layout
- esempi di codice
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Usa PHP per gestire le diapositive di layout con Aspose.Slides: crea, applica, clona, rinomina e personalizza segnaposti e temi nelle presentazioni per PPT, PPTX e ODP."
---
Questo articolo dimostra come lavorare con **Layout Slides** in Aspose.Slides per PHP tramite Java. Una diapositiva di layout definisce il design e la formattazione ereditati dalle diapositive normali. È possibile aggiungere, accedere, clonare e rimuovere le diapositive di layout, nonché eliminare quelle inutilizzate per ridurre le dimensioni della presentazione.

## **Aggiungi una diapositiva di layout**

È possibile creare una diapositiva di layout personalizzata per definire una formattazione riutilizzabile. Ad esempio, potresti aggiungere una casella di testo che appare su tutte le diapositive che utilizzano questo layout.

```php
function addLayoutSlide() {
    $presentation = new Presentation();
    try {
        $masterSlide = $presentation->getMasters()->get_Item(0);

        // Crea una diapositiva di layout con un tipo di layout vuoto e un nome personalizzato.
        $layoutSlide = $presentation->getLayoutSlides()->add($masterSlide, SlideLayoutType::Blank, "Main layout");

        $presentation->save("layout_slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Suggerimento 1:** Le diapositive di layout fungono da modelli per le diapositive individuali. È possibile definire gli elementi comuni una volta e riutilizzarli in molte diapositive.
> 
> 💡 **Suggerimento 2:** Quando aggiungi forme o testo a una diapositiva di layout, tutte le diapositive basate su quel layout mostreranno automaticamente questo contenuto condiviso. Lo screenshot qui sotto mostra due diapositive, ciascuna che eredita una casella di testo dallo stesso layout.

![Diapositive che ereditano contenuto di layout](layout-slide-result.png)

## **Accedi a una diapositiva di layout**

Le diapositive di layout possono essere accessibili per indice o per tipo di layout (ad es., `Blank`, `Title`, `SectionHeader`, ecc.).

```php
function accessLayoutSlide() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // Accesso per indice.
        $firstLayoutSlide = $presentation->getLayoutSlides()->get_Item(0);

        // Accesso per tipo di layout.
        $blankLayoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    } finally {
        $presentation->dispose();
    }
}
```

## **Rimuovi una diapositiva di layout**

È possibile rimuovere una diapositiva di layout specifica se non è più necessaria.

```php
function removeLayoutSlide() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // Ottieni una diapositiva di layout per tipo e rimuovila.
        $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Custom);
        $presentation->getLayoutSlides()->remove($layoutSlide);

        $presentation->save("layout_slide_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Rimuovi le diapositive di layout inutilizzate**

Per ridurre le dimensioni della presentazione, potresti voler rimuovere le diapositive di layout che non sono utilizzate da alcuna diapositiva normale.

```php
function removeUnusedLayoutSlides() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // Rimuove automaticamente tutte le diapositive di layout non referenziate da alcuna diapositiva.
        $presentation->getLayoutSlides()->removeUnused();

        $presentation->save("layout_slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Clona una diapositiva di layout**

È possibile duplicare una diapositiva di layout usando il metodo `addClone`.

```php
function cloneLayoutSlides() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // Ottieni una diapositiva di layout esistente per tipo.
        $blankLayoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

        // Clona la diapositiva di layout alla fine della raccolta di diapositive di layout.
        $clonedLayoutSlide = $presentation->getLayoutSlides()->addClone($blankLayoutSlide);

        $presentation->save("layout_slide_cloned.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> ✅ **Riepilogo:** Le diapositive di layout sono strumenti potenti per gestire una formattazione coerente tra le diapositive. Aspose.Slides consente un controllo completo sulla creazione, gestione e ottimizzazione delle diapositive di layout.