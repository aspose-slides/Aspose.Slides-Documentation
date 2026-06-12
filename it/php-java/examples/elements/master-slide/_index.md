---
title: Diapositiva Master
type: docs
weight: 30
url: /it/php-java/examples/elements/master-slide/
keywords:
- diapositiva master
- aggiungi diapositiva master
- accedi alla diapositiva master
- rimuovi diapositiva master
- diapositiva master non utilizzata
- esempi di codice
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Gestisci le diapositive master in PHP con Aspose.Slides: crea, modifica, clona e formatta temi, sfondi e segnaposti per unificare le diapositive in PowerPoint e OpenDocument."
---
Le diapositive master costituiscono il livello più alto della gerarchia di ereditarietà delle diapositive in PowerPoint. Una **diapositiva master** definisce elementi di design comuni come sfondi, loghi e formattazione del testo. Le **diapositive layout** ereditano dalle diapositive master e le **diapositive normali** ereditano dalle diapositive layout.

Questo articolo dimostra come creare, modificare e gestire le diapositive master usando Aspose.Slides per PHP via Java.

## **Aggiungi una Diapositiva Master**

Questo esempio mostra come creare una nuova diapositiva master clonando quella predefinita.

```php
function addMasterSlide() {
    $presentation = new Presentation();
    try {
        // Clona la diapositiva master predefinita.
        $defaultMasterSlide = $presentation->getMasters()->get_Item(0);
        $newMasterSlide = $presentation->getMasters()->addClone($defaultMasterSlide);

        $presentation->save("master_slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Suggerimento 1:** Le diapositive master offrono un modo per applicare un branding coerente o elementi di design condivisi su tutte le diapositive. Qualsiasi modifica apportata al master si rifletterà automaticamente sulle diapositive layout e normali dipendenti.

> 💡 **Suggerimento 2:** Qualsiasi forma o formattazione aggiunta a una diapositiva master viene ereditata dalle diapositive layout e, a loro volta, da tutte le diapositive normali che usano quei layout.
> L'immagine sotto illustra come una casella di testo aggiunta su una diapositiva master venga resa automaticamente sulla diapositiva finale.

![Master Inheritance Example](master-slide-banner.png)

## **Accedi a una Diapositiva Master**

Puoi accedere alle diapositive master usando il metodo `Presentation::getMasters`. Ecco come recuperarle e lavorare con esse:

```php
function accessMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // Accedi alla prima diapositiva master.
        $firstMasterSlide = $presentation->getMasters()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **Rimuovi una Diapositiva Master**

Le diapositive master possono essere rimosse sia per indice che per riferimento.

```php
function removeMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // Rimuovi per indice.
        $presentation->getMasters()->removeAt(0);

        // Oppure rimuovi per riferimento.
        $firstMasterSlide = $presentation->getMasters()->get_Item(0);
        $presentation->getMasters()->remove($firstMasterSlide);

        $presentation->save("master_slide_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Rimuovi Diapositive Master Non Utilizzate**

Alcune presentazioni contengono diapositive master non utilizzate. Rimuovere queste diapositive può aiutare a ridurre le dimensioni del file.

```php
function removeUnusedMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // Rimuovi tutte le diapositive master inutilizzate (anche quelle contrassegnate come Preserve).
        $presentation->getMasters()->removeUnused(true);

        $presentation->save("master_slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> ⚙️ **Suggerimento:** Usa `removeUnused(true)` per pulire le diapositive master non utilizzate e minimizzare le dimensioni della presentazione.