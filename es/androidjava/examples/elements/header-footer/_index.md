---
title: Encabezado y pie de página
type: docs
weight: 220
url: /es/androidjava/examples/elements/header-footer/
keywords:
- ejemplo de código
- encabezado
- pie de página
- PowerPoint
- OpenDocument
- presentación
- Android
- Java
- Aspose.Slides
description: "Controla los encabezados y pies de página de las diapositivas con Aspose.Slides para Android: agrega fechas, números de diapositiva y texto personalizado en PPT, PPTX y ODP con ejemplos en Java."
---
Este artículo muestra cómo agregar pies de página y actualizar los marcadores de posición de fecha y hora usando **Aspose.Slides for Android via Java**.

## **Agregar un pie de página**

Agregue texto al área del pie de página de una diapositiva y hágalo visible.

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

Modifique el marcador de posición de fecha y hora en una diapositiva.

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