---
title: "Convertir PPT y PPTX a PDF en Python | Opciones avanzadas"
linktitle: "PowerPoint a PDF"
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
description: "Guía paso a paso para convertir PPT, PPTX y ODP a PDFs de alta calidad y compatibles con WCAG en Python con Aspose.Slides—incluye protección con contraseña, selección de diapositivas y control de calidad de imágenes."
showReadingTime: true
---
## **Visión general**

Convertir presentaciones de PowerPoint (PPT, PPTX, ODP) a formato PDF en Python ofrece varias ventajas, entre ellas garantizar la compatibilidad entre diferentes dispositivos y preservar el diseño y formato de la presentación. Esta guía muestra cómo convertir presentaciones a documentos PDF, utilizar diversas opciones para controlar la calidad de imagen, incluir diapositivas ocultas, proteger con contraseña los documentos PDF, detectar sustituciones de fuentes, seleccionar diapositivas específicas para la conversión y aplicar normas de cumplimiento a los documentos de salida.

## **Conversiones de PowerPoint a PDF**

Con Aspose.Slides, puedes convertir presentaciones en estos formatos a PDF:

* **PPT**
* **PPTX**
* **ODP**

Para convertir una presentación a PDF en Python, simplemente debes pasar el nombre del archivo como argumento a la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) y luego guardar la presentación como PDF usando el método [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/). La clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) expone el método [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) que se utiliza habitualmente para convertir una presentación a PDF.

{{% alert color="info" title="Note" %}}

Aspose.Slides for Python inserta la información de su API y el número de versión en los documentos de salida. Por ejemplo, cuando convierte una presentación a PDF, Aspose.Slides for Python completa el campo Application con el valor '*Aspose.Slides*' y el campo PDF Producer con un valor en forma '*Aspose.Slides v XX.XX*'. **Nota** que no puedes indicar a Aspose.Slides for Python que cambie o elimine esta información de los documentos de salida.

{{% /alert %}}

Aspose.Slides permite:

* Convertir presentaciones completas a PDF
* Convertir diapositivas específicas de una presentación a PDF

Aspose.Slides exporta presentaciones a PDF, garantizando que el contenido de los PDFs resultantes coincida estrechamente con las presentaciones originales. Los elementos y atributos se renderizan con precisión en la conversión, incluyendo:

* Imágenes
* Cuadros de texto y formas
* Formato de texto
* Formato de párrafo
* Hipervínculos
* Encabezados y pies de página
* Viñetas
* Tablas

## **Convertir PowerPoint a PDF**

El proceso estándar de conversión de PowerPoint a PDF utiliza opciones predeterminadas. En este caso, Aspose.Slides intenta convertir la presentación proporcionada a PDF usando ajustes óptimos en los niveles de máxima calidad.

El siguiente ejemplo carga una presentación y guarda todas las diapositivas visibles en PDF usando la configuración de exportación predeterminada.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.ppt") as presentation:
    presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{% alert color="info" title="Note" %}}

Aspose ofrece un [**Convertidor de PowerPoint a PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) gratuito en línea que muestra el proceso de conversión de presentación a PDF. Para una implementación en vivo del procedimiento descrito aquí, puedes probar el convertidor.

{{% /alert %}}

## **Convertir PowerPoint a PDF con opciones**

Aspose.Slides proporciona opciones personalizadas—propiedades bajo la clase [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/)—que permiten personalizar el PDF (resultado del proceso de conversión), bloquear el PDF con una contraseña o incluso especificar cómo debe desarrollarse el proceso de conversión.

### **Convertir PowerPoint a PDF con opciones personalizadas**

Con opciones de conversión personalizadas, puedes establecer la configuración de calidad preferida para imágenes raster, especificar cómo deben manejarse los metarchivos, definir un nivel de compresión para el texto, establecer DPI para las imágenes, etc.

El siguiente ejemplo exporta una presentación a PDF 1.5 con calidad JPEG establecida en 90, resolución de imagen a 300 DPI, metarchivos guardados como PNG y compresión de texto Flate.

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

### **Seleccionar automáticamente la compresión de imágenes**

Cuando una presentación contiene muchas fotografías o capturas de pantalla, reducir el tamaño del PDF exportado puede facilitar su envío por correo electrónico o su descarga. Establece [PdfOptions.best_images_compression_ratio](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/best_images_compression_ratio/) a `True` para seleccionar automáticamente el algoritmo de compresión más apropiado para cada imagen durante la exportación a PDF.

El siguiente ejemplo carga una presentación existente, habilita la selección automática de compresión de imágenes y la guarda como documento PDF. Todas las demás configuraciones de exportación de PDF mantienen sus valores predeterminados.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.best_images_compression_ratio = True

with slides.Presentation("image-heavy.pptx") as presentation:
    presentation.save("image-heavy.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Esta opción elige un algoritmo de compresión para cada imagen. Reducir [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/) disminuye la calidad de la imagen JPEG, mientras que reducir [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) permite que las imágenes se muestren a una resolución inferior, lo que puede reducir el detalle. Habilitar la selección automática de compresión no disminuye por sí misma ninguno de estos valores.

Seleccionar algoritmos de compresión de imágenes requiere tiempo de procesamiento y memoria adicionales. La reducción de tamaño depende de las imágenes de la presentación y de la configuración de exportación; no se garantiza una reducción fija para cada presentación.

### **Conservar archivos OLE incrustados como adjuntos PDF**

Si una presentación contiene un libro de Excel incrustado, es posible que desees que los destinatarios del PDF puedan acceder a los datos del libro además de ver las diapositivas. Establece [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) a `True` para conservar los archivos OLE incrustados como adjuntos en el PDF resultante.

El valor predeterminado es `False`: la imagen de vista previa del objeto OLE o su icono se renderiza en la página del PDF, pero el archivo incrustado no se incluye como adjunto. Establecer la opción a `True` incluye además los datos del archivo. La vista previa sigue siendo una representación visual; el adjunto permite a los destinatarios abrir o guardar el archivo incrustado por separado. El objeto OLE no se convierte en una hoja de cálculo interactiva en la página del PDF.

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
3. Guarda el adjunto y ábrelo en Excel para inspeccionar sus datos, o ábrelo directamente si el visor lo permite. La vista previa en la página del PDF es independiente del adjunto.

{{% alert color="info" title="Note" %}}

Las normas PDF/A imponen restricciones sobre los adjuntos: PDF/A-1 prohíbe archivos incrustados, PDF/A-2 permite solo adjuntos PDF/A y PDF/A-3 permite otros tipos de archivo, incluidos libros de Excel. Estas son exigencias de las normas, no limitaciones específicas de Aspose.Slides. Este ejemplo utiliza la configuración de cumplimiento PDF predeterminada y no muestra la exportación a PDF/A.

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

### **Convertir PowerPoint a PDF protegido con contraseña**

El siguiente ejemplo exporta una presentación a un PDF que requiere la contraseña `password` para abrirse. Los permisos de acceso permiten la impresión, incluida la impresión de alta calidad.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.password = "password"
pdf_options.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

with slides.Presentation("PowerPoint.pptx") as presentation:
    presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Gestionar fuentes sin una variante negrita dedicada**

Una presentación puede aplicar formato negrita al texto aunque la fuente no tenga una variante negrita dedicada. El texto puede seguir apareciendo en negrita mediante negrita sintética, que engrosa artificialmente los glifos normales. Cuando ese texto resulta demasiado grueso o difiere de la apariencia prevista en el PDF, prueba a establecer [PdfOptions.rasterize_unsupported_font_styles](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/rasterize_unsupported_font_styles/) a `True`. Esta opción renderiza el texto afectado como mapa de bits durante la exportación a PDF y puede mejorar su apariencia para ciertas fuentes. Su valor predeterminado es `False`.

La presentación de ejemplo contiene dos cuadros de texto: uno con texto normal y otro con formato negrita aplicado a la misma fuente, que no tiene una variante negrita dedicada. El siguiente ejemplo carga la presentación, habilita la rasterización de estilos de fuente no compatibles y la exporta a PDF:

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.rasterize_unsupported_font_styles = True

with slides.Presentation("unsupported-bold.pptx") as presentation:
    presentation.save("rasterized.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Las siguientes vistas previas muestran la salida desactivada y la salida activada. En este ejemplo, el texto en negrita tiene trazos más gruesos con la opción desactivada. Con la opción activada, sus trazos son más ligeros; el texto normal permanece sin cambios. Compara los resultados antes de elegir la configuración para tu presentación.

| Opción desactivada (`False`, por defecto) | Opción activada (`True`) |
|---|---|
| ![PDF con rasterización de estilo de fuente no compatible desactivada](unsupported-bold-disabled.png) | ![PDF con rasterización de estilo de fuente no compatible activada](unsupported-bold-enabled.png) |

En este ejemplo, activar la opción convierte solo el texto en negrita en un mapa de bits: no puede seleccionarse, copiarse ni buscarse como texto sin OCR, y sus bordes aparecen más suaves al 800 % de zoom. El texto normal sigue siendo buscable. Con la opción desactivada, ambas cadenas permanecen como texto.

Esta opción rasteriza el texto formateado como negrita cuando su fuente no tiene una variante negrita dedicada. La [Font substitution](/slides/es/python-net/font-substitution/) selecciona otra fuente cuando la original no está disponible.

## **Convertir diapositivas seleccionadas de PowerPoint a PDF**

El siguiente ejemplo exporta las diapositivas 1 y 3 de una presentación a PDF. Los números de diapositiva en este arreglo son basados en 1, y la presentación de entrada debe contener al menos tres diapositivas.

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

## **Convertir PowerPoint a PDF en vista de diapositivas de notas**

El siguiente ejemplo exporta una presentación a PDF, colocando las notas del orador de cada diapositiva bajo la propia diapositiva. Usa una presentación que contenga notas del orador para ver el resultado.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.slides_layout_options = slides.export.NotesCommentsLayoutingOptions()
pdf_options.slides_layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

with slides.Presentation("NotesFile.pptx") as presentation:
    presentation.save("Pdf_Notes_out.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

## **Estándares de accesibilidad y cumplimiento para PDF**

Aspose.Slides permite utilizar un procedimiento de conversión que cumple con las [Guías de accesibilidad al contenido web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Puedes exportar un documento PowerPoint a PDF usando cualquiera de estos estándares de cumplimiento: **PDF/A1a**, **PDF/A1b** y **PDF/UA**.

Este código Python muestra una operación de conversión de PowerPoint a PDF en la que se obtienen varios PDFs basados en diferentes estándares de cumplimiento:

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

Aspose.Slides admite operaciones de conversión de PDF que permiten convertir PDF a los formatos de archivo más populares. Puedes hacer conversiones de [PDF a HTML](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/), [PDF a imagen](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/), [PDF a JPG](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/), y [PDF a PNG](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/). Otras operaciones de conversión de PDF a formatos especializados—[PDF a SVG](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/), [PDF a TIFF](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/), y [PDF a XML](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/)—también son compatibles.

{{% /alert %}}

> **Nota:** Al exportar a PDF/UA, Aspose.Slides trata gráficos complejos como SmartArt, gráficos y fórmulas como una única figura. Los elementos de ruta individuales no se conservan como contenido separado y pueden marcarse como artefactos; el texto alternativo se proporciona solo para la figura completa.

## **Preguntas frecuentes**

**¿Puede Aspose.Slides for Python eliminar la información de la aplicación del PDF?**

No, Aspose.Slides for Python incluye automáticamente la información de la API y el número de versión en el PDF de salida. Esta información no puede modificarse ni eliminarse.

**¿Cómo incluyo solo diapositivas específicas en la conversión a PDF?**

Puedes especificar los índices de diapositiva que deseas convertir pasando una matriz de posiciones de diapositiva al método [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/).

**¿Es posible proteger el PDF con contraseña durante la conversión?**

Sí, puedes establecer una contraseña y definir permisos de acceso utilizando la clase [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) antes de guardar la presentación como PDF.

**¿Aspose.Slides admite la conversión de PDF a otros formatos?**

Sí, Aspose.Slides admite la conversión de PDFs a formatos como HTML, formatos de imagen (JPG, PNG), SVG, TIFF y XML.

**¿Cómo puedo asegurar que mi PDF cumpla con los estándares de accesibilidad?**

Establece la propiedad [compliance](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/compliance/) en [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) a estándares como `PDF_A1A`, `PDF_A1B` o `PDF_UA` para garantizar el cumplimiento de las directrices de accesibilidad.

**¿Puedo incluir diapositivas ocultas en la salida PDF?**

Sí, configurando la propiedad [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) en [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) a `True` se incluirán las diapositivas ocultas en el PDF.

**¿Cómo ajusto la calidad y resolución de imagen durante la conversión?**

Utiliza las propiedades [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/) y [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) en [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) para controlar la calidad y resolución de imagen en el PDF resultante.

**¿Aspose.Slides gestiona automáticamente las sustituciones de fuentes?**

Aspose.Slides detecta sustituciones de fuentes durante la conversión, y puedes gestionarlas mediante la propiedad `warning_callback` en `SaveOptions` (actualmente con limitaciones).

## **Recursos adicionales**

- [Aspose.Slides for Python via .NET Documentation](/slides/es/python-net/)
- [Aspose.Slides API Reference](https://reference.aspose.com/slides/python-net/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)