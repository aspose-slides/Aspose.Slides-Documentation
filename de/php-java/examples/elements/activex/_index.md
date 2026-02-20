---
title: ActiveX
type: docs
weight: 200
url: /de/php-java/examples/elements/activex/
keywords:
- ActiveX
- ActiveX-Steuerelement
- ActiveX hinzufügen
- ActiveX zugreifen
- ActiveX entfernen
- ActiveX-Eigenschaften
- Codebeispiele
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie ActiveX-Steuerelemente in PHP mit Aspose.Slides finden, bearbeiten und entfernen, einschließlich der Aktualisierung von Eigenschaften für PowerPoint-Präsentationen."
---
Demonstriert, wie man ActiveX‑Steuerelemente zu einer Präsentation hinzufügt, darauf zugreift, sie entfernt und konfiguriert, wobei **Aspose.Slides for PHP via Java** verwendet wird.

## **ActiveX‑Steuerelement hinzufügen**

Fügen Sie ein neues ActiveX‑Steuerelement ein.

```php
function addActiveX() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Fügt ein neues ActiveX-Steuerelement hinzu.
        $control = $slide->getControls()->addControl(ControlType::WindowsMediaPlayer, 50, 50, 100, 50);

        $presentation->save("activex.pptm", SaveFormat::Pptm);
    } finally {
        // Präsentation freigeben.
        $presentation->dispose();
    }
}
```

## **Auf ein ActiveX‑Steuerelement zugreifen**

Lesen Sie Informationen vom ersten ActiveX‑Steuerelement auf der Folie.

```php
function accessActiveX() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Greift auf das erste ActiveX-Steuerelement zu.
        $control = $slide->getControls()->get_Item(0);

        echo "Control Name: " . $control->getName() . PHP_EOL;
    } finally {
        // Präsentation freigeben.
        $presentation->dispose();
    }
}
```

## **ActiveX‑Steuerelement entfernen**

Löschen Sie ein vorhandenes ActiveX‑Steuerelement von der Folie.

```php
function removeActiveX() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        if (java_values($slide->getControls()->size()) > 0) {
            // Entfernt das erste ActiveX-Steuerelement.
            $slide->getControls()->removeAt(0);
        }

        $presentation->save("activex_removed.pptm", SaveFormat::Pptm);
    } finally {
        // Präsentation freigeben.
        $presentation->dispose();
    }
}
```

## **ActiveX‑Eigenschaften festlegen**

Konfigurieren Sie mehrere ActiveX‑Eigenschaften.

```php
function setActiveXProperties() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Annahme: das erste Steuerelement ist das, das wir hinzugefügt haben.
        $control = $slide->getControls()->get_Item(0);

        // Eigenschaften konfigurieren.
        $control->getProperties()->set_Item("Caption", "Click Me");
        $control->getProperties()->set_Item("Enabled", "true");

        $presentation->save("activex_properties.pptm", SaveFormat::Pptm);
    } finally {
        // Präsentation freigeben.
        $presentation->dispose();
    }
}
```