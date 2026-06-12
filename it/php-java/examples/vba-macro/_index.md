---
title: Macro VBA
type: docs
weight: 150
url: /it/php-java/examples/elements/vba-macro/
keywords:
- macro vba
- aggiungi macro vba
- accedi macro vba
- rimuovi macro vba
- esempi di codice
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Lavora con le macro VBA in PHP utilizzando Aspose.Slides: aggiungi o modifica progetti e moduli, firma o rimuovi macro e salva le presentazioni in PPT, PPTX e ODP."
---
Illustra come aggiungere, accedere e rimuovere macro VBA utilizzando **Aspose.Slides for PHP via Java**.

## **Aggiungi una macro VBA**

Crea una presentazione con un progetto VBA e un semplice modulo macro.

```php
function addVbaMacro() {
    $presentation = new Presentation();
    try {
        $presentation->setVbaProject(new VbaProject());

        $module = $presentation->getVbaProject()->getModules()->addEmptyModule("Module");
        $module->setSourceCode("Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

        $presentation->save("vba_macro.pptm", SaveFormat::Pptm);
    } finally {
        $presentation->dispose();
    }
}
```

## **Accedi a una macro VBA**

Recupera il primo modulo dal progetto VBA.

```php
function accessVbaMacro() {
    $presentation = new Presentation("vba_macro.pptm");
    try {
        $firstModule = $presentation->getVbaProject()->getModules()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **Rimuovi una macro VBA**

Elimina un modulo dal progetto VBA.

```php
function removeVbaMacro() {
    $presentation = new Presentation("vba_macro.pptm");
    try {
        // Supponendo che ci sia almeno un modulo nel progetto VBA.
        $module = $presentation->getVbaProject()->getModules()->get_Item(0);

        $presentation->getVbaProject()->getModules()->remove($module);

        $presentation->save("vba_macro_removed.pptm", SaveFormat::Pptm);
    } finally {
        $presentation->dispose();
    }
}
```