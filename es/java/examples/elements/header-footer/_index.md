---
title: Encabezado y pie de página
type: docs
weight: 220
url: /es/java/examples/elements/header-footer/
keywords:
- ejemplo de código
- encabezado
- pie de página
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Controla los encabezados y pies de página de las diapositivas con Aspose.Slides para Java: añade fechas, números de diapositiva y texto personalizado en PPT, PPTX y ODP con ejemplos en Java."
---
Este artículo muestra cómo añadir pies de página y actualizar los marcadores de posición de fecha y hora usando **Aspose.Slides for Java**.

## **Añadir un pie de página**

Añadir texto al área del pie de página de una diapositiva y hacerlo visible.

```java
static void addHeaderFooter() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setFooterText("My footer");
        slide.getHeaderFooterManager().setFooterVisibility(true);
    } finally {
        presentation.dispose();
    }
}
```

## **Actualizar fecha y hora**

Modificar el marcador de posición de fecha y hora en una diapositiva.

```java
static void updateDateTime() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setDateTimeText("01/01/2024");
        slide.getHeaderFooterManager().setDateTimeVisibility(true);
    } finally {
        presentation.dispose();
    }
}
```