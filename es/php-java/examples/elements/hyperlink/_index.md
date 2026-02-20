---
title: Hipervínculo
type: docs
weight: 130
url: /es/php-java/examples/elements/hyperlink/
keywords:
- hipervínculo
- añadir hipervínculo
- acceder al hipervínculo
- eliminar hipervínculo
- actualizar hipervínculo
- ejemplos de código
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Añadir, editar y eliminar hipervínculos en PHP con Aspose.Slides: texto de enlace, formas, diapositivas, URL y correo electrónico; establecer destinos y acciones para PPT, PPTX y ODP."
---
Demuestra cómo agregar, acceder, eliminar y actualizar hipervínculos en formas usando **Aspose.Slides for PHP via Java**.

## **Añadir un hipervínculo**

Cree una forma rectangular con un hipervínculo que apunta a un sitio web externo.

```php
function addHyperlink() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
        $shape->getTextFrame()->setText("Aspose");

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $portion->getPortionFormat()->setHyperlinkClick(new Hyperlink("https://www.aspose.com"));

        $presentation->save("hyperlink.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Acceder a un hipervínculo**

Lea la información del hipervínculo de la porción de texto de una forma.

```php
function accessHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Suponiendo que la primera forma contiene el hipervínculo.
        $shape = $slide->getShapes()->get_Item(0);

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $hyperlink = $portion->getPortionFormat()->getHyperlinkClick();
    } finally {
        $presentation->dispose();
    }
}
```

## **Eliminar un hipervínculo**

Elimine el hipervínculo del texto de una forma.

```php
function removeHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Suponiendo que la primera forma contiene el hipervínculo.
        $shape = $slide->getShapes()->get_Item(0);

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $portion->getPortionFormat()->setHyperlinkClick(null);

        $presentation->save("hyperlink_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Actualizar un hipervínculo**

Cambie el destino de un hipervínculo existente. Use `HyperlinkManager` para modificar texto que ya contiene un hipervínculo, lo que imita cómo PowerPoint actualiza los hipervínculos de forma segura.

```php
function updateHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Suponiendo que la primera forma contiene el hipervínculo.
        $shape = $slide->getShapes()->get_Item(0);

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);

        // Cambiar un hipervínculo dentro del texto existente debe hacerse a través de
        // HyperlinkManager en lugar de establecer la propiedad directamente.
        // Esto imita cómo PowerPoint actualiza los hipervínculos de forma segura.
        $portion->getPortionFormat()->getHyperlinkManager()->setExternalHyperlinkClick("https://new.example.com");

        $presentation->save("hyperlink_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```