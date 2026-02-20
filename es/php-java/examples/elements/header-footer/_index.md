---
title: Encabezado y pie de página
type: docs
weight: 220
url: /es/php-java/examples/elements/header-footer/
keywords:
- encabezado y pie de página
- agregar encabezado y pie de página
- actualizar encabezado y pie de página
- ejemplos de código
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Controla encabezados y pies de página en PHP con Aspose.Slides: agrega o edita la fecha/hora, los números de diapositiva y el texto del pie, muestra u oculta los marcadores de posición en PPT, PPTX y ODP."
---
Muestra cómo agregar pies de página y actualizar los marcadores de posición de fecha y hora usando **Aspose.Slides for PHP via Java**.

## **Agregar un pie de página**
Añade texto al área del pie de página de una diapositiva y hazlo visible.

```php
function addHeaderFooter() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getHeaderFooterManager()->setFooterText("My footer");
        $slide->getHeaderFooterManager()->setFooterVisibility(true);

        $presentation->save("footer.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Actualizar fecha y hora**
Modifica el marcador de posición de fecha y hora en una diapositiva.

```php
function updateDateTime() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getHeaderFooterManager()->setDateTimeText("01/01/2024");
        $slide->getHeaderFooterManager()->setDateTimeVisibility(true);

        $presentation->save("datetime.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```