---
title: ActiveX
type: docs
weight: 200
url: /sv/php-java/examples/elements/activex/
keywords:
- ActiveX
- ActiveX-kontroll
- Lägg till ActiveX
- Åtkomst till ActiveX
- Ta bort ActiveX
- ActiveX-egenskaper
- kodexempel
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Lär dig hur du hittar, redigerar och tar bort ActiveX-kontroller i PHP med Aspose.Slides, inklusive egenskapsuppdateringar för PowerPoint-presentationer."
---
Visar hur man lägger till, får åtkomst till, tar bort och konfigurerar ActiveX‑kontroller i en presentation med **Aspose.Slides for PHP via Java**.

## **Lägg till en ActiveX‑kontroll**

Infoga en ny ActiveX‑kontroll.

```php
function addActiveX() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Lägg till en ny ActiveX‑kontroll.
        $control = $slide->getControls()->addControl(ControlType::WindowsMediaPlayer, 50, 50, 100, 50);

        $presentation->save("activex.pptm", SaveFormat::Pptm);
    } finally {
        // Frigör presentationen.
        $presentation->dispose();
    }
}
```

## **Få åtkomst till en ActiveX‑kontroll**

Läs information från den första ActiveX‑kontrollen på bilden.

```php
function accessActiveX() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Få åtkomst till den första ActiveX‑kontrollen.
        $control = $slide->getControls()->get_Item(0);

        echo "Control Name: " . $control->getName() . PHP_EOL;
    } finally {
        // Frigör presentationen.
        $presentation->dispose();
    }
}
```

## **Ta bort en ActiveX‑kontroll**

Ta bort en befintlig ActiveX‑kontroll från bilden.

```php
function removeActiveX() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        if (java_values($slide->getControls()->size()) > 0) {
            // Ta bort den första ActiveX‑kontrollen.
            $slide->getControls()->removeAt(0);
        }

        $presentation->save("activex_removed.pptm", SaveFormat::Pptm);
    } finally {
        // Frigör presentationen.
        $presentation->dispose();
    }
}
```

## **Ställ in ActiveX‑egenskaper**

Konfigurera flera ActiveX‑egenskaper.

```php
function setActiveXProperties() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Antar att den första kontrollen är den vi lade till.
        $control = $slide->getControls()->get_Item(0);

        // Konfigurera egenskaper.
        $control->getProperties()->set_Item("Caption", "Click Me");
        $control->getProperties()->set_Item("Enabled", "true");

        $presentation->save("activex_properties.pptm", SaveFormat::Pptm);
    } finally {
        // Frigör presentationen.
        $presentation->dispose();
    }
}
```