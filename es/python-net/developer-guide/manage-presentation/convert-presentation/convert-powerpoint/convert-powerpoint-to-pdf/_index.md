---
title: Convertir PPT y PPTX a PDF en Python | Opciones avanzadas
linktitle: PowerPoint a PDF
type: docs
weight: 40
url: /es/python-net/convert-powerpoint-to-pdf/
aliases:
  - /python-net/convert-to-pdf/
keywords:
  - convertir PowerPoint
  - presentación
  - PowerPoint a PDF
  - PPT a PDF
  - PPTX a PDF
  - guardar PowerPoint como PDF
  - adjunto
  - PDF/A1a
  - PDF/A1b
  - PDF/UA
  - Python
  - Aspose.Slides for Python
description: "Guía paso a paso para convertir PPT, PPTX y ODP a PDFs de alta calidad y compatibles con WCAG en Python con Aspose.Slides—incluye protección con contraseña, selección de diapositivas y control de calidad de imagen."
showReadingTime: true
---
## **Visión general**

Convertir presentaciones de PowerPoint (PPT, PPTX, ODP) a formato PDF en Python ofrece varias ventajas, entre ellas garantizar la compatibilidad entre diferentes dispositivos y preservar el diseño y el formato de la presentación. Esta guía muestra cómo convertir presentaciones a documentos PDF, utilizar distintas opciones para controlar la calidad de imagen, incluir diapositivas ocultas, proteger con contraseña los documentos PDF, detectar sustituciones de fuentes, seleccionar diapositivas específicas para la conversión y aplicar normas de cumplimiento a los documentos de salida.

## **Conversiones de PowerPoint a PDF**

Con Aspose.Slides, puedes convertir presentaciones en estos formatos a PDF:

* **PPT**
* **PPTX**
* **ODP**

Para convertir una presentación a PDF en Python, solo tienes que pasar el nombre del archivo como argumento a la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) y luego guardar la presentación como PDF mediante el método [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/). La clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) expone el método [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) que se usa típicamente para convertir una presentación a PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python inserta la información de su API y el número de versión en los documentos de salida. Por ejemplo, cuando convierte una presentación a PDF, Aspose.Slides for Python rellena el campo Application con el valor '*Aspose.Slides*' y el campo PDF Producer con un valor del tipo '*Aspose.Slides v XX.XX*'. **Nota** de que no puedes indicar a Aspose.Slides for Python que cambie o elimine esta información de los documentos de salida.
{{% /alert %}}

Aspose.Slides permite convertir:

* Presentaciones completas a PDF
* Diapositivas específicas de una presentación a PDF

Aspose.Slides exporta presentaciones a PDF, asegurando que el contenido de los PDFs resultantes coincida estrechamente con las presentaciones originales. Los elementos y atributos se renderizan con precisión en la conversión, incluidos:

* Imágenes
* Cuadros de texto y formas
* Formato de texto
* Formato de párrafo
* Hipervínculos
* Encabezados y pies de página
* Viñetas
* Tablas

## **Convertir PowerPoint a PDF**

El proceso estándar de conversión de PowerPoint a PDF utiliza opciones predeterminadas. En este caso, Aspose.Slides intenta convertir la presentación proporcionada a PDF usando configuraciones óptimas en los niveles de calidad máximos.

El siguiente ejemplo carga una presentación y guarda todas las diapositivas visibles en PDF usando la configuración de exportación predeterminada.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.ppt") as presentation:
    presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{% alert color="info" title="Note" %}}
Aspose ofrece un [**convertidor gratuito en línea de PowerPoint a PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) que muestra el proceso de conversión de presentación a PDF. Para una implementación en vivo del procedimiento descrito aquí, puedes probar el convertidor.
{{% /alert %}}

## **Convertir PowerPoint a PDF con opciones**

Aspose.Slides proporciona opciones personalizadas—propiedades de la clase [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/)—que permiten personalizar el PDF (resultado del proceso de conversión), bloquear el PDF con una contraseña o incluso especificar cómo debe ejecutarse el proceso de conversión.

### **Convertir PowerPoint a PDF con opciones personalizadas**

Con opciones de conversión personalizadas, puedes establecer tu configuración de calidad preferida para imágenes rasterizadas, especificar cómo se deben manejar los metarchivos, definir un nivel de compresión para el texto, establecer DPI para las imágenes, etc.

El siguiente ejemplo exporta una presentación a PDF 1.5 con calidad JPEG del 90 %, resolución de imagen de 300 DPI, metarchivos guardados como PNG y compresión de texto Flate.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.jpeg_quality = 90
pdf_options.sufficient_resolution = 300
pdf_options.save_metafiles_as_png = True
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE
pdf_options.compliance = slides.export.PdfCompliance.PDF15

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Conservar archivos OLE incrustados como adjuntos PDF**

Si una presentación contiene un libro de Excel incrustado, puede que desees que los destinatarios del PDF accedan a los datos del libro además de ver las diapositivas. Establece [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) a `True` para conservar los archivos OLE incrustados como adjuntos en el PDF resultante.

El valor predeterminado es `False`: la imagen de vista previa o el icono del objeto OLE se renderizan en la página PDF, pero su archivo incrustado no se incluye como adjunto. Al establecer la opción en `True` se incluye también el dato del archivo. La vista previa sigue siendo una representación visual; el adjunto permite a los destinatarios abrir o guardar el archivo incrustado por separado. El objeto OLE no se convierte en una hoja de cálculo interactiva de Excel en la página PDF.

El siguiente ejemplo carga una presentación que ya contiene un libro de Excel incrustado y la exporta a PDF con el libro adjunto.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.include_ole_data = True

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Para comprobar el resultado:

1. Abre el PDF exportado en un visor que admita archivos adjuntos, como Adobe Acrobat Reader.
2. Abre el panel **Attachments** del visor y localiza el libro incrustado.
3. Guarda el adjunto y ábrelo en Excel para inspeccionar sus datos, o ábrelo directamente si el visor lo permite. La vista previa en la página PDF es independiente del adjunto.

{{% alert color="info" title="Note" %}}
Las normas PDF/A imponen restricciones a los adjuntos: PDF/A‑1 prohíbe los archivos incrustados, PDF/A‑2 permite solo adjuntos PDF/A y PDF/A‑3 permite otros tipos de archivo, incluidos los libros de Excel. Estas son exigencias de las normas, no limitaciones específicas de Aspose.Slides. Este ejemplo usa la configuración de cumplimiento PDF predeterminada y no muestra la exportación a PDF/A.
{{% /alert %}}

### **Convertir PowerPoint a PDF con diapositivas ocultas**

Si una presentación contiene diapositivas ocultas, puedes usar una opción personalizada—la propiedad [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) de la clase [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/)—para indicar a Aspose.Slides que incluya las diapositivas ocultas como páginas en el PDF resultante.

El siguiente ejemplo exporta una presentación a PDF, incluyendo cualquier diapositiva oculta.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.show_hidden_slides = True

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Convertir PowerPoint a un PDF protegido con contraseña**

El siguiente ejemplo exporta una presentación a un PDF que requiere la contraseña `password` para abrirse. Los permisos de acceso permiten la impresión, incluida la impresión de alta calidad.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.password = "password"
pdf_options.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

## **Convertir diapositivas seleccionadas de PowerPoint a PDF**

El siguiente ejemplo exporta las diapositivas 1 y 3 de una presentación a PDF. Los números de diapositiva en este arreglo son base‑uno, y la presentación de entrada debe contener al menos tres diapositivas.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.pptx") as presentation:
    slide_numbers = [1, 3]
    presentation.save("PPTX-to-PDF.pdf", slide_numbers, slides.export.SaveFormat.PDF)
```

## **Convertir PowerPoint a PDF con tamaño de diapositiva personalizado**

El siguiente ejemplo copia la primera diapositiva de una presentación a una nueva presentación con un tamaño de diapositiva de 612 × 792 puntos (8,5 × 11 pulgadas). Escala el contenido de la diapositiva para ajustarlo y exporta la diapositiva única a PDF.

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

with slides.Presentation("SelectedSlides.pptx") as presentation:
    with slides.Presentation() as resized_presentation:
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # Eliminar la diapositiva en blanco con la que se creó la nueva presentación.
        resized_presentation.slides.remove_at(1)

        resized_presentation.save("PDF_with_custom_slide_size.pdf", slides.export.SaveFormat.PDF)
```

## **Convertir PowerPoint a PDF en vista de diapositiva de notas**

El siguiente ejemplo exporta una presentación a PDF, colocando las notas del orador de cada diapositiva debajo de la propia diapositiva. Usa una presentación que contenga notas del orador para ver el resultado.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.slides_layout_options = slides.export.NotesCommentsLayoutingOptions()
pdf_options.slides_layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

with slides.Presentation("NotesFile.pptx") as presentation:
    presentation.save("Pdf_Notes_out.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

## **Accesibilidad y normas de cumplimiento para PDF**

Aspose.Slides permite usar un procedimiento de conversión que cumple con las [Pautas de Accesibilidad al Contenido Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Puedes exportar un documento PowerPoint a PDF usando cualquiera de estas normas de cumplimiento: **PDF/A1a**, **PDF/A1b** y **PDF/UA**.

Este código Python muestra una operación de conversión de PowerPoint a PDF en la que se obtienen varios PDFs basados en diferentes normas de cumplimiento:

```python
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

options = slides.export.PdfOptions()

options.compliance = slides.export.PdfCompliance.PDF_A1A
pres.save("pres-a1a-compliance.pdf", slides.export.SaveFormat.PDF, options)

options.compliance = slides.export.PdfCompliance.PDF_A1B
pres.save("pres-a1b-compliance.pdf", slides.export.SaveFormat.PDF, options)

options.compliance = slides.export.PdfCompliance.PDF_UA
pres.save("pres-ua-compliance.pdf", slides.export.SaveFormat.PDF, options)
```

{{% alert color="info" title="Note" %}}
El soporte de Aspose.Slides para operaciones de conversión de PDF permite convertir PDF a los formatos de archivo más populares. Puedes hacer [PDF a HTML](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/), [PDF a imagen](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/), [PDF a JPG](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/) y [PDF a PNG](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/) conversiones. Otras operaciones de conversión de PDF a formatos especializados—[PDF a SVG](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/), [PDF a TIFF](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/), y [PDF a XML](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/)—también están soportadas.
{{% /alert %}}

> **Nota:** Al exportar a PDF/UA, Aspose.Slides trata los gráficos complejos como SmartArt, diagramas y fórmulas como una única figura. Los elementos de ruta individuales no se conservan como contenido separado y pueden marcarse como artefactos; el texto alternativo se proporciona solo para la figura completa.

## **Preguntas frecuentes**

**¿Puede Aspose.Slides for Python eliminar la información de la aplicación del PDF?**

No, Aspose.Slides for Python incluye automáticamente la información de la API y el número de versión en el PDF de salida. Esta información no puede modificarse ni eliminarse.

**¿Cómo incluyo solo diapositivas específicas en la conversión a PDF?**

Puedes especificar los índices de diapositiva que deseas convertir pasando una matriz de posiciones de diapositiva al método [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/).

**¿Es posible proteger el PDF con contraseña durante la conversión?**

Sí, puedes establecer una contraseña y definir permisos de acceso usando la clase [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) antes de guardar la presentación como PDF.

**¿Aspose.Slides admite la conversión de PDF a otros formatos?**

Sí, Aspose.Slides admite la conversión de PDFs a formatos como HTML, formatos de imagen (JPG, PNG), SVG, TIFF y XML.

**¿Cómo puedo garantizar que mi PDF cumpla con las normas de accesibilidad?**

Establece la propiedad [compliance](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/compliance/) en [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) a normas como `PDF_A1A`, `PDF_A1B` o `PDF_UA` para asegurar el cumplimiento de las directrices de accesibilidad.

**¿Puedo incluir diapositivas ocultas en el PDF resultante?**

Sí, configurando la propiedad [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) en [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) a `True`, las diapositivas ocultas se incluirán en el PDF.

**¿Cómo ajusto la calidad y resolución de imagen durante la conversión?**

Utiliza las propiedades [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/) y [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) en [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) para controlar la calidad y resolución de imagen en el PDF resultante.

**¿Aspose.Slides gestiona automáticamente las sustituciones de fuentes?**

Aspose.Slides detecta sustituciones de fuentes durante la conversión, y puedes gestionarlas mediante la propiedad `warning_callback` en `SaveOptions` (actualmente con limitaciones).

## **Recursos adicionales**

- [Aspose.Slides for Python via .NET Documentation](/slides/es/python-net/)
- [Aspose.Slides API Reference](https://reference.aspose.com/slides/python-net/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)