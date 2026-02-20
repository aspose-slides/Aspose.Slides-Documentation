---
title: ActiveX
type: docs
weight: 200
url: /php-java/examples/elements/activex/
keywords:
- ActiveX
- ActiveX control
- add ActiveX
- access ActiveX
- remove ActiveX
- ActiveX properties
- code examples
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Learn how to find, edit, and remove ActiveX controls in PHP with Aspose.Slides, including property updates for PowerPoint presentations."
---

Demonstrates how to add, access, remove, and configure ActiveX controls in a presentation using **Aspose.Slides for PHP via Java**.

## **Add an ActiveX Control**

Insert a new ActiveX control.

```php
function addActiveX() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Add a new ActiveX control.
        $control = $slide->getControls()->addControl(ControlType::WindowsMediaPlayer, 50, 50, 100, 50);

        $presentation->save("activex.pptm", SaveFormat::Pptm);
    } finally {
        // Dispose the presentation.
        $presentation->dispose();
    }
}
```

## **Access an ActiveX Control**

Read information from the first ActiveX control on the slide.

```php
function accessActiveX() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Access the first ActiveX control.
        $control = $slide->getControls()->get_Item(0);

        echo "Control Name: " . $control->getName() . PHP_EOL;
    } finally {
        // Dispose the presentation.
        $presentation->dispose();
    }
}
```

## **Remove an ActiveX Control**

Delete an existing ActiveX control from the slide.

```php
function removeActiveX() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        if (java_values($slide->getControls()->size()) > 0) {
            // Remove the first ActiveX control.
            $slide->getControls()->removeAt(0);
        }

        $presentation->save("activex_removed.pptm", SaveFormat::Pptm);
    } finally {
        // Dispose the presentation.
        $presentation->dispose();
    }
}
```

## **Set ActiveX Properties**

Configure several ActiveX properties.

```php
function setActiveXProperties() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Assuming the first control is the one we added.
        $control = $slide->getControls()->get_Item(0);

        // Configure properties.
        $control->getProperties()->set_Item("Caption", "Click Me");
        $control->getProperties()->set_Item("Enabled", "true");

        $presentation->save("activex_properties.pptm", SaveFormat::Pptm);
    } finally {
        // Dispose the presentation.
        $presentation->dispose();
    }
}
```
