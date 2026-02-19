---
title: Encabezado y pie de página
type: docs
weight: 220
url: /es/nodejs-java/examples/elements/header-footer/
keywords:
- ejemplo de código
- encabezado
- pie de página
- PowerPoint
- OpenDocument
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Controla los encabezados y pies de página de las diapositivas con Aspose.Slides para Node.js: añade fechas, números de diapositiva y texto personalizado en PPT, PPTX y ODP con ejemplos en JavaScript."
---
Este artículo muestra cómo añadir pies de página y actualizar los marcadores de posición de fecha y hora usando **Aspose.Slides for Node.js via Java**.

## **Agregar un pie de página**
Añade texto al área del pie de página de una diapositiva y hazlo visible.

```js
function addHeaderFooter() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setFooterText("My footer");
        slide.getHeaderFooterManager().setFooterVisibility(true);

        presentation.save("header_footer.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Actualizar fecha y hora**
Modifica el marcador de posición de fecha y hora en una diapositiva.

```js
function updateDateTime() {
    let presentation = new aspose.slides.Presentation("header_footer.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setDateTimeText("01/01/2024");
        slide.getHeaderFooterManager().setDateTimeVisibility(true);

        presentation.save("header_footer_updated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```