---
title: Convertir presentaciones de PowerPoint en modo Handout en Android
linktitle: Modo Handout
type: docs
weight: 150
url: /es/androidjava/convert-powerpoint-in-Handout-mode/
keywords:
- convertir PowerPoint
- convertir presentación
- modo handout
- guía
- PPT
- PPTX
- PowerPoint
- presentación
- Android
- Java
- Aspose.Slides
description: "Convertir presentaciones a guías en Java. Establecer diapositivas por página, mantener notas, exportar a PDF o imágenes con Aspose.Slides para Android, con código de ejemplo. Pruébalo gratis."
---

## **Exportación en modo de Guías**

Aspose.Slides ofrece la capacidad de convertir presentaciones a varios formatos, incluyendo la creación de guías para imprimir en modo Handout. Este modo le permite configurar cómo aparecen varias diapositivas en una sola página, lo que resulta útil para conferencias, seminarios y otros eventos. Puede activar este modo estableciendo el método `setSlidesLayoutOptions` en las interfaces [IPdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihtmloptions/), y [ITiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itiffoptions/) .

Para configurar el modo Handout, use el objeto [HandoutLayoutingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/handoutlayoutingoptions/) , que determina cuántas diapositivas se colocan en una sola página y otros parámetros de visualización.

A continuación se muestra un ejemplo de código que muestra cómo convertir una presentación a PDF en modo Handout.
```java
// Cargar una presentación.
Presentation presentation = new Presentation("sample.pptx");
try {
	// Establecer las opciones de exportación.
	HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
	slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 4 diapositivas en una página horizontalmente
	slidesLayoutOptions.setPrintSlideNumbers(true);                   // imprimir números de diapositiva
	slidesLayoutOptions.setPrintFrameSlide(true);                     // imprimir un marco alrededor de las diapositivas
	slidesLayoutOptions.setPrintComments(false);                      // sin comentarios

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

	// Exportar la presentación a PDF con el diseño elegido.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```


{{% alert color="warning" %}} 
Tenga en cuenta que el método `setSlidesLayoutOptions` está disponible solo para ciertos formatos de salida, como PDF, HTML, TIFF, y al renderizar como imágenes.
{{% /alert %}} 

## **Preguntas frecuentes**

**¿Cuál es el número máximo de miniaturas de diapositivas por página en modo Handout?**

Aspose.Slides admite [preajustes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/handouttype/) de hasta 9 miniaturas por página con orden horizontal o vertical: 1, 2, 3, 4 (horizontal/vertical), 6 (horizontal/vertical) y 9 (horizontal/vertical).

**¿Puedo definir una cuadrícula personalizada, como 5 u 8 diapositivas por página?**

No. El número y el orden de las miniaturas están controlados estrictamente por la clase [HandoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/handouttype/) ; no se admiten diseños arbitrarios.

**¿Puedo incluir diapositivas ocultas en la salida Handout?**

Sí. Active las diapositivas ocultas usando el método `setShowHiddenSlides` en la configuración de exportación del formato de destino, como [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/htmloptions/), o [TiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/).