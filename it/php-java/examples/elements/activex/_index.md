---
title: ActiveX
type: docs
weight: 200
url: /it/php-java/examples/elements/activex/
keywords:
- ActiveX
- controllo ActiveX
- aggiungere ActiveX
- accedere ActiveX
- rimuovere ActiveX
- proprietà ActiveX
- esempi di codice
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Scopri come trovare, modificare e rimuovere i controlli ActiveX in PHP con Aspose.Slides, inclusi gli aggiornamenti delle proprietà per le presentazioni PowerPoint."
---
Dimostra come aggiungere, accedere, rimuovere e configurare i controlli ActiveX in una presentazione utilizzando **Aspose.Slides for PHP via Java**.

## **Aggiungere un controllo ActiveX**

Inserisci un nuovo controllo ActiveX.

```php
function addActiveX() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Aggiungi un nuovo controllo ActiveX.
        $control = $slide->getControls()->addControl(ControlType::WindowsMediaPlayer, 50, 50, 100, 50);

        $presentation->save("activex.pptm", SaveFormat::Pptm);
    } finally {
        // Rilascia la presentazione.
        $presentation->dispose();
    }
}
```

## **Accedere a un controllo ActiveX**

Leggi le informazioni dal primo controllo ActiveX nella diapositiva.

```php
function accessActiveX() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Accedi al primo controllo ActiveX.
        $control = $slide->getControls()->get_Item(0);

        echo "Control Name: " . $control->getName() . PHP_EOL;
    } finally {
        // Rilascia la presentazione.
        $presentation->dispose();
    }
}
```

## **Rimuovere un controllo ActiveX**

Elimina un controllo ActiveX esistente dalla diapositiva.

```php
function removeActiveX() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        if (java_values($slide->getControls()->size()) > 0) {
            // Rimuovi il primo controllo ActiveX.
            $slide->getControls()->removeAt(0);
        }

        $presentation->save("activex_removed.pptm", SaveFormat::Pptm);
    } finally {
        // Rilascia la presentazione.
        $presentation->dispose();
    }
}
```

## **Impostare le proprietà ActiveX**

Configura diverse proprietà ActiveX.

```php
function setActiveXProperties() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Supponendo che il primo controllo sia quello aggiunto.
        $control = $slide->getControls()->get_Item(0);

        // Configura le proprietà.
        $control->getProperties()->set_Item("Caption", "Click Me");
        $control->getProperties()->set_Item("Enabled", "true");

        $presentation->save("activex_properties.pptm", SaveFormat::Pptm);
    } finally {
        // Rilascia la presentazione.
        $presentation->dispose();
    }
}
```