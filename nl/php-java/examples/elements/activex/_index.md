---
title: ActiveX
type: docs
weight: 200
url: /nl/php-java/examples/elements/activex/
keywords:
- ActiveX
- ActiveX-besturingselement
- ActiveX toevoegen
- ActiveX benaderen
- ActiveX verwijderen
- ActiveX-eigenschappen
- codevoorbeelden
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Leer hoe u ActiveX‑besturingselementen kunt vinden, bewerken en verwijderen in PHP met Aspose.Slides, inclusief het bijwerken van eigenschappen voor PowerPoint‑presentaties."
---
Toont hoe u ActiveX‑besturingselementen kunt toevoegen, benaderen, verwijderen en configureren in een presentatie met **Aspose.Slides for PHP via Java**.

## **ActiveX‑besturingselement toevoegen**

Voeg een nieuw ActiveX‑besturingselement in.

```php
function addActiveX() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Voeg een nieuw ActiveX-besturingselement toe.
        $control = $slide->getControls()->addControl(ControlType::WindowsMediaPlayer, 50, 50, 100, 50);

        $presentation->save("activex.pptm", SaveFormat::Pptm);
    } finally {
        // De presentatie opruimen.
        $presentation->dispose();
    }
}
```

## **ActiveX‑besturingselement benaderen**

Lees de informatie van het eerste ActiveX‑besturingselement op de dia.

```php
function accessActiveX() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Benader het eerste ActiveX-besturingselement.
        $control = $slide->getControls()->get_Item(0);

        echo "Control Name: " . $control->getName() . PHP_EOL;
    } finally {
        // De presentatie opruimen.
        $presentation->dispose();
    }
}
```

## **ActiveX‑besturingselement verwijderen**

Verwijder een bestaand ActiveX‑besturingselement van de dia.

```php
function removeActiveX() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        if (java_values($slide->getControls()->size()) > 0) {
            // Verwijder het eerste ActiveX-besturingselement.
            $slide->getControls()->removeAt(0);
        }

        $presentation->save("activex_removed.pptm", SaveFormat::Pptm);
    } finally {
        // De presentatie opruimen.
        $presentation->dispose();
    }
}
```

## **ActiveX‑eigenschappen instellen**

Configureer verschillende ActiveX‑eigenschappen.

```php
function setActiveXProperties() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Aannemende dat het eerste besturingselement het toegevoegde is.
        $control = $slide->getControls()->get_Item(0);

        // Eigenschappen configureren.
        $control->getProperties()->set_Item("Caption", "Click Me");
        $control->getProperties()->set_Item("Enabled", "true");

        $presentation->save("activex_properties.pptm", SaveFormat::Pptm);
    } finally {
        // De presentatie opruimen.
        $presentation->dispose();
    }
}
```