---
title: Convertir presentaciones de PowerPoint en modo de folleto en Android
linktitle: Modo de folleto
type: docs
weight: 150
url: /es/androidjava/convert-powerpoint-in-handout-mode/
keywords:
- convertir PowerPoint
- convertir presentación
- modo de folleto
- folleto
- PPT
- PPTX
- PowerPoint
- presentación
- Android
- Java
- Aspose.Slides
description: "Convertir presentaciones a folletos en Java. Configurar diapositivas por página, conservar notas, exportar a PDF o imágenes con Aspose.Slides para Android, con código de ejemplo. Pruébalo gratis."
---
## **Introducción**

Aspose.Slides permite convertir presentaciones a varios formatos, incluida la creación de folletos para imprimir en modo Folleto. Este modo le permite configurar cómo aparecen varias diapositivas en una sola página, lo que resulta útil para conferencias, seminarios y otros eventos. Puede activar este modo estableciendo el método `setSlidesLayoutOptions` en las interfaces [IPdfOptions](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ihtmloptions/) y [ITiffOptions](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itiffoptions/).

Para establecer las dimensiones y la orientación de la página del folleto antes de la exportación, vea [Tamaño de página de notas](/slides/es/androidjava/notes-size/).

## **Exportación en modo de folleto**

Para configurar el modo de folleto, utilice el objeto [HandoutLayoutingOptions](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/handoutlayoutingoptions/) que determina cuántas diapositivas se colocan en una sola página y otros parámetros de visualización.

Abajo se muestra un ejemplo de código que demuestra cómo convertir una presentación a PDF en modo de folleto.

```java
import com.aspose.slides.*;

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

	// Exportar la presentación a PDF con el diseño seleccionado.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
Ten en cuenta que el método `setSlidesLayoutOptions` solo está disponible para ciertos formatos de salida, como PDF, HTML, TIFF, y cuando se renderiza como imágenes.
{{% /alert %}} 

## **Preguntas frecuentes**

**¿Cuál es el número máximo de miniaturas de diapositivas por página en el modo Folleto?**

Aspose.Slides admite [preajustes](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/handouttype/) de hasta 9 miniaturas por página con orden horizontal o vertical: 1, 2, 3, 4 (horizontal/vertical), 6 (horizontal/vertical) y 9 (horizontal/vertical).

**¿Puedo definir una cuadrícula personalizada, como 5 u 8 diapositivas por página?**

No. El número y el orden de las miniaturas están controlados estrictamente por la clase [HandoutType](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/handouttype/); no se admiten diseños arbitrarios.

**¿Puedo incluir diapositivas ocultas en la salida del folleto?**

Sí. Habilite las diapositivas ocultas mediante el método `setShowHiddenSlides` en la configuración de exportación para el formato de destino, como [PdfOptions](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/htmloptions/) o [TiffOptions](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/tiffoptions/).