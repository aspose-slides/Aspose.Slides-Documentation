---
title: ActiveX
type: docs
weight: 200
url: /es/php-java/examples/elements/activex/
keywords:
- ActiveX
- control ActiveX
- añadir ActiveX
- acceder a ActiveX
- eliminar ActiveX
- propiedades de ActiveX
- ejemplos de código
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Aprenda cómo localizar, editar y eliminar controles ActiveX en PHP con Aspose.Slides, incluida la actualización de propiedades para presentaciones de PowerPoint."
---
Demuestra cómo añadir, acceder, eliminar y configurar controles ActiveX en una presentación usando **Aspose.Slides for PHP via Java**.

## **Añadir un control ActiveX**

Inserte un nuevo control ActiveX.

```php
function addActiveX() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Añadir un nuevo control ActiveX.
        $control = $slide->getControls()->addControl(ControlType::WindowsMediaPlayer, 50, 50, 100, 50);

        $presentation->save("activex.pptm", SaveFormat::Pptm);
    } finally {
        // Liberar la presentación.
        $presentation->dispose();
    }
}
```

## **Acceder a un control ActiveX**

Lea información del primer control ActiveX en la diapositiva.

```php
function accessActiveX() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Acceder al primer control ActiveX.
        $control = $slide->getControls()->get_Item(0);

        echo "Control Name: " . $control->getName() . PHP_EOL;
    } finally {
        // Liberar la presentación.
        $presentation->dispose();
    }
}
```

## **Eliminar un control ActiveX**

Elimine un control ActiveX existente de la diapositiva.

```php
function removeActiveX() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        if (java_values($slide->getControls()->size()) > 0) {
            // Eliminar el primer control ActiveX.
            $slide->getControls()->removeAt(0);
        }

        $presentation->save("activex_removed.pptm", SaveFormat::Pptm);
    } finally {
        // Liberar la presentación.
        $presentation->dispose();
    }
}
```

## **Establecer propiedades del control ActiveX**

Configure varias propiedades del control ActiveX.

```php
function setActiveXProperties() {
    $presentation = new Presentation("activex.pptm");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Suponiendo que el primer control es el que añadimos.
        $control = $slide->getControls()->get_Item(0);

        // Configurar propiedades.
        $control->getProperties()->set_Item("Caption", "Click Me");
        $control->getProperties()->set_Item("Enabled", "true");

        $presentation->save("activex_properties.pptm", SaveFormat::Pptm);
    } finally {
        // Liberar la presentación.
        $presentation->dispose();
    }
}
```