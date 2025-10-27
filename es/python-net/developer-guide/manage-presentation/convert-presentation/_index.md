---
title: Convertir presentaciones a varios formatos en Python
linktitle: Convertir presentaciones
type: docs
weight: 70
url: /es/python-net/developer-guide/manage-presentation/convert-presentation/
keywords:
- convertir presentación
- exportar presentación
- PPT a PPTX
- PPT a PDF
- PPTX a PDF
- PPT a XPS
- PPTX a XPS
- PPT a TIFF
- PPTX a TIFF
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Convierta presentaciones de PowerPoint y OpenDocument a PPTX, PDF, XPS, TIFF y más con Aspose.Slides para Python mediante .NET. Conversión simple y de alta calidad."
---

## **Introducción**

Esta página ofrece una visión general de la conversión de presentaciones con Aspose.Slides para Python mediante .NET. Resume los escenarios compatibles y señala guías específicas que muestran el código exacto para exportar presentaciones y diapositivas a formatos como PDF, XPS, TIFF, así como para convertir entre PPT y PPTX. Cuando corresponde, los artículos enlazados resaltan opciones específicas del formato —por ejemplo, renderizar notas o ajustar la calidad de la imagen— y limitaciones conocidas como el soporte parcial en rutas PPT→PPTX. Utilice esta página para elegir un formato de destino y luego siga la receta enlazada.

## **Conversión de PPT a PPTX**

### **Acerca de PPT/PPTX**

PPT es el formato binario antiguo de PowerPoint (97–2003), mientras que PPTX es el formato Open XML empaquetado en ZIP introducido en PowerPoint 2007. En comparación con PPT, PPTX suele generar archivos más pequeños, admite funciones modernas, funciona bien con automatización de documentos y se recomienda para almacenamiento a largo plazo y flujos de trabajo multiplataforma.

### **Convertir PPT a PPTX**

Aspose.Slides admite la conversión de presentaciones PPT al formato PPTX. La ventaja principal de usar la API de Aspose.Slides para esta tarea es la simplicidad del flujo de trabajo necesario para lograr el resultado deseado. En la práctica, puede realizar la conversión con un código mínimo mientras mantiene alta fidelidad de diapositivas, diseños y medios.

{{% alert color="primary" %}}
Read more: [Convert PPT to PPTX in Python](/slides/es/python-net/convert-ppt-to-pptx/).
{{% /alert %}}

## **Conversión de presentaciones a PDF**

### **Acerca de PDF**

El [Portable Document Format](https://en.wikipedia.org/wiki/PDF) (PDF) es un formato de archivo creado por Adobe Systems para intercambiar documentos entre organizaciones. Su propósito es garantizar que el contenido de un documento se muestre con la misma apariencia visual independientemente de la plataforma en la que se visualice.

### **Convertir presentaciones a PDF**

Cualquier presentación que pueda cargarse en Aspose.Slides puede convertirse en un documento PDF. Puede exportar presentaciones a PDF directamente con el componente Aspose.Slides; no se requieren bibliotecas de terceros ni el componente Aspose.PDF.

{{% alert color="primary" %}}
Read more: [Convert PPT & PPTX to PDF in Python](/slides/es/python-net/convert-powerpoint-to-pdf/).
{{% /alert %}}

## **Conversión de presentaciones a XPS**

### **Acerca de XPS**

La [XML Paper Specification](https://en.wikipedia.org/wiki/Open_XML_Paper_Specification) (XPS) es un lenguaje de descripción de páginas y formato de documento fijo desarrollado originalmente por Microsoft. Al igual que PDF, XPS es un formato de documento de diseño fijo diseñado para preservar la fidelidad del documento y proporcionar una apariencia independiente del dispositivo.

### **Convertir presentaciones a XPS**

Cualquier presentación que pueda cargarse con Aspose.Slides puede convertirse al formato XPS. Aspose.Slides utiliza un motor de diseño de página y renderizado de alta fidelidad para producir salida en el formato XPS de diseño fijo. Cabe destacar que Aspose.Slides genera XPS directamente sin depender de Windows Presentation Foundation (WPF).

{{% alert color="primary" %}}
Read more: [Convert PowerPoint Presentations to XPS in Python](/slides/es/python-net/convert-powerpoint-to-xps/).
{{% /alert %}}

## **Conversión de presentaciones a TIFF**

### **Acerca de TIFF**

El [Tagged Image File Format](https://en.wikipedia.org/wiki/TIFF) (TIFF) es un formato de imagen raster conocida por almacenar múltiples imágenes (páginas) en un solo archivo. Desarrollado originalmente por Aldus, es ampliamente compatible con aplicaciones de escaneo, fax y otras de procesamiento de imágenes.

### **Convertir presentaciones a TIFF**

Cualquier documento que pueda cargarse en Aspose.Slides también puede convertirse directamente a un archivo TIFF sin componentes de terceros. Opcionalmente, puede especificar el tamaño de imagen para las páginas del TIFF resultante.

{{% alert color="primary" %}}
Read more: [Convert PowerPoint Presentations to TIFF in Python](/slides/es/python-net/convert-powerpoint-to-tiff/).
{{% /alert %}}

## **FAQ**

**¿Puedo incluir diapositivas ocultas al exportar a PDF/XPS?**

Sí. La exportación admite incluir diapositivas ocultas mediante la opción correspondiente en la configuración de [PDF](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/)/[XPS](https://reference.aspose.com/slides/python-net/aspose.slides.export/xpsoptions/show_hidden_slides/).

**¿Se admite guardar en el formato PDF/A (para archivo de archivo)?**

Sí, los niveles de cumplimiento PDF/A [están disponibles](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfcompliance/) (incluyendo A-2a/A-2b/A-2u y A-3a/A-3b) durante la exportación.

**¿Qué ocurre con las fuentes durante la conversión: se incrustan o se sustituyen?**

Existen opciones flexibles: puede [incrustar todos los glifos o solo los subconjuntos usados](/slides/es/python-net/embedded-font/), especificar una [fuente de respaldo](/slides/es/python-net/fallback-font/), y [controlar el comportamiento](/slides/es/python-net/font-substitution/) cuando una fuente carece de ciertos estilos.

**¿Cómo puedo controlar la calidad y el tamaño del PDF resultante?**

Hay opciones disponibles para la [calidad JPEG](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/), la [compresión de texto](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/text_compression/), y un umbral de [resolución suficiente](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) para imágenes, además de un modo que selecciona la [mejor compresión para imágenes](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/best_images_compression_ratio/).

**¿Puedo exportar solo un rango de diapositivas (por ejemplo, 5–12)?**

Sí, la exportación admite seleccionar un subconjunto de diapositivas.

**¿Se admite el procesamiento multinúcleo de varios archivos al mismo tiempo?**

Es aceptable procesar diferentes presentaciones en paralelo en procesos separados. Importante: el mismo objeto de [presentación](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) no debe cargarse ni guardarse desde [múltiples subprocesos](/slides/es/python-net/multithreading/).

**¿Existen riesgos al aplicar la licencia desde diferentes subprocesos?**

Sí, las llamadas a [configuración de licencia](/slides/es/python-net/licensing/) no son seguras para subprocesos y requieren sincronización.