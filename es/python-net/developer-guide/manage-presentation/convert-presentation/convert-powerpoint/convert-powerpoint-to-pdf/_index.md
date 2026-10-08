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
description: "Guía paso a paso para convertir PPT, PPTX y ODP a PDFs de alta calidad y compatibles con WCAG en Python con Aspose.Slides—incluye protección con contraseña, selección de diapositivas y control de la calidad de imagen."
showReadingTime: true
---
## **Visión general**

La conversión de presentaciones de PowerPoint (PPT, PPTX, ODP) a formato PDF en Python ofrece varias ventajas, incluida la garantía de compatibilidad entre diferentes dispositivos y la preservación del diseño y formato de su presentación. Esta guía muestra cómo convertir presentaciones a documentos PDF, utilizar diversas opciones para controlar la calidad de imagen, incluir diapositivas ocultas, proteger con contraseña los documentos PDF, detectar sustituciones de fuentes, seleccionar diapositivas específicas para la conversión y aplicar normas de cumplimiento a los documentos de salida.

## **Conversión de PowerPoint a PDF**

Usando Aspose.Slides, puede convertir presentaciones en estos formatos a PDF:

* **PPT**
* **PPTX**
* **ODP**

Para convertir una presentación a PDF en Python, simplemente tiene que pasar el nombre del archivo como argumento a la clase [Presentación](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) y luego guardar la presentación como un PDF usando un método [guardar](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/). La clase [Presentación](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) expone el método [guardar](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) que se usa típicamente para convertir una presentación a PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python inserta su información de API y número de versión en los documentos de salida. Por ejemplo, cuando convierte una presentación a PDF, Aspose.Slides for Python rellena el campo Application con el valor '*Aspose.Slides*' y el campo PDF Producer con un valor en forma '*Aspose.Slides v XX.XX*'. **Nota** que no puede instruir a Aspose.Slides for Python para cambiar o eliminar esta información de los documentos de salida.
{{% /alert %}}

Aspose.Slides le permite convertir:

* Presentaciones completas a PDF
* Diapositivas específicas de una presentación a PDF

Aspose.Slides exporta presentaciones a PDF, asegurando que el contenido de los PDFs resultantes coincida estrechamente con las presentaciones originales. Los elementos y atributos se renderizan con precisión en la conversión, incluyendo:

* Imágenes
* Cuadros de texto y formas
* Formato de texto
* Formato de párrafo
* Hipervínculos
* Encabezados y pies de página
* Viñetas
* Tablas

## **Convertir PowerPoint a PDF**

El proceso estándar de conversión de PowerPoint a PDF usa opciones predeterminadas. En este caso, Aspose.Slides intenta convertir la presentación proporcionada a PDF utilizando configuraciones óptimas en los niveles de calidad máximos.

El siguiente ejemplo carga una presentación y guarda todas las diapositivas visibles a PDF usando la configuración de exportación predeterminada.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.ppt") as presentation:
    presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{% alert color="info" title="Note" %}}
Aspose proporciona un [convertidor de PowerPoint a PDF](https://products.aspose.app/slides/conversion/ppt-to-pdf) gratuito en línea que demuestra el proceso de conversión de presentación a PDF. Para una implementación en vivo del procedimiento descrito aquí, puede probar el convertidor.
{{% /alert %}}

## **Convertir PowerPoint a PDF con opciones**

Aspose.Slides proporciona opciones personalizadas—propiedades bajo la clase [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/)—que le permiten personalizar el PDF (resultado del proceso de conversión), bloquear el PDF con una contraseña o incluso especificar cómo debe llevarse a cabo el proceso de conversión.

### **Convertir PowerPoint a PDF con opciones personalizadas**

Usando opciones de conversión personalizadas, puede establecer su configuración de calidad preferida para imágenes rasterizadas, especificar cómo deben manejarse los metarchivos, establecer un nivel de compresión para el texto, establecer DPI para las imágenes, etc.

El siguiente ejemplo exporta una presentación a PDF 1.5 con calidad JPEG establecida en 90, resolución de imagen establecida en 300 DPI, metarchivos guardados como PNG y compresión de texto Flate.

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

Si una presentación contiene un libro de Excel incrustado, puede querer que los destinatarios del PDF accedan a los datos del libro además de ver las diapositivas. Establezca [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) a `True` para conservar los archivos OLE incrustados como adjuntos en el PDF resultante.

El valor predeterminado es `False`: la imagen de vista previa o el icono del objeto OLE se renderiza en la página PDF, pero su archivo incrustado no se incluye como adjunto. Al establecer la opción en `True` también se incluye los datos del archivo. La vista previa sigue siendo una representación visual; el adjunto permite a los destinatarios abrir o guardar el archivo incrustado por separado. El objeto OLE no se convierte en una hoja de cálculo interactiva en la página PDF.

El siguiente ejemplo carga una presentación que ya contiene un libro de Excel incrustado y lo exporta a PDF con el libro adjunto.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.include_ole_data = True

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Para comprobar el resultado:

1. Abra el PDF exportado en un visor que admita adjuntos de archivo, como Adobe Acrobat Reader.
2. Abra el panel **Adjuntos** del visor y localice el libro incrustado.
3. Guarde el adjunto y ábralo en Excel para inspeccionar sus datos, o ábralo directamente si el visor lo permite. La vista previa en la página PDF es independiente del adjunto.

{{% alert color="info" title="Note" %}}
Las normas PDF/A imponen restricciones a los adjuntos: PDF/A‑1 prohíbe archivos incrustados, PDF/A‑2 permite solo adjuntos PDF/A y PDF/A‑3 permite otros tipos de archivo, incluidos libros de Excel. Estos son requisitos de las normas, no restricciones específicas de Aspose.Slides. Este ejemplo usa la configuración de cumplimiento PDF predeterminada y no demuestra la exportación PDF/A.
{{% /alert %}}

### **Convertir PowerPoint a PDF con diapositivas ocultas**

Si una presentación contiene diapositivas ocultas, puede usar una opción personalizada—la propiedad [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) de la clase [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/)—para indicar a Aspose.Slides que incluya las diapositivas ocultas como páginas en el PDF resultante.

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

### **Manejar fuentes sin un tipo de letra negrita dedicado**

Una presentación puede aplicar formato negrita al texto incluso cuando su fuente no tiene un tipo de letra negrita dedicado. El texto puede aparecer negrita mediante negrita sintética, que engrosa artificialmente los glifos regulares. Cuando ese texto parece demasiado grueso o difiere de la apariencia prevista en el PDF, intente establecer [PdfOptions.rasterize_unsupported_font_styles](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/rasterize_unsupported_font_styles/) a `True`. Esta opción renderiza el texto afectado como un mapa de bits durante la exportación a PDF y puede mejorar su apariencia para ciertas fuentes. Su valor predeterminado es `False`.

La presentación de ejemplo contiene dos cuadros de texto: uno con texto regular y otro con formato negrita aplicado a la misma fuente, que no tiene un tipo de letra negrita dedicado. El siguiente ejemplo carga la presentación, habilita la rasterización de estilos de fuente no compatibles y la exporta a PDF:

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.rasterize_unsupported_font_styles = True

with slides.Presentation("unsupported-bold.pptx") as presentation:
    presentation.save("rasterized.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

A continuación se muestran vistas preliminares del resultado con la opción desactivada y activada. En este ejemplo, el texto en negrita tiene trazos más gruesos con la opción desactivada. Con la opción activada, sus trazos son más ligeros; el texto regular permanece sin cambios. Compare los resultados antes de elegir la configuración para su presentación.

| Opción desactivada (`False`, por defecto) | Opción activada (`True`) |
|---|---|
| ![PDF con rasterización de estilo de fuente no compatible desactivada](unsupported-bold-disabled.png) | ![PDF con rasterización de estilo de fuente no compatible activada](unsupported-bold-enabled.png) |

En este ejemplo, habilitar la opción convierte solo el texto en negrita en un mapa de bits: no puede seleccionarse, copiarse o buscarse como texto sin OCR, y sus bordes aparecen más suaves al 800 % de zoom. El texto regular sigue siendo buscable. Con la opción desactivada, ambas cadenas permanecen como texto.

Esta opción rasteriza el texto formateado en negrita cuando su fuente no tiene un tipo de letra negrita dedicado. La [sustitución de fuentes](/slides/es/python-net/font-substitution/) selecciona en su lugar otra fuente cuando la original no está disponible.

## **Convertir diapositivas seleccionadas en PowerPoint a PDF**

El siguiente ejemplo exporta las diapositivas 1 y 3 de una presentación a PDF. Los números de diapositiva en este arreglo son basados en 1, y la presentación de entrada debe contener al menos tres diapositivas.

```python
import aspose.slides as slides

with slides.Presentation("PowerPoint.pptx") as presentation:
    slide_numbers = [1, 3]
    presentation.save("PPTX-to-PDF.pdf", slide_numbers, slides.export.SaveFormat.PDF)
```

## **Convertir PowerPoint a PDF con tamaño de diapositiva personalizado**

El siguiente ejemplo copia la primera diapositiva de una presentación a una nueva presentación con un tamaño de diapositiva de 612 × 792 puntos (8,5 × 11 pulgadas). Escala el contenido de la diapositiva para ajustarse y exporta la única diapositiva a PDF.

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

## **Convertir PowerPoint a PDF en vista de notas de diapositiva**

El siguiente ejemplo exporta una presentación a PDF, colocando las notas del orador de cada diapositiva debajo de la diapositiva. Use una presentación que contenga notas del orador para ver el resultado.

```python
import aspose.slides as slides

pdf_options = slides.export.PdfOptions()
pdf_options.slides_layout_options = slides.export.NotesCommentsLayoutingOptions()
pdf_options.slides_layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

with slides.Presentation("NotesFile.pptx") as presentation:
    presentation.save("Pdf_Notes_out.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

## **Accesibilidad y normas de cumplimiento para PDF**

Aspose.Slides le permite utilizar un procedimiento de conversión que cumple con las [Directrices de Accesibilidad de Contenido Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Puede exportar un documento PowerPoint a PDF usando cualquiera de estas normas de cumplimiento: **PDF/A1a**, **PDF/A1b** y **PDF/UA**.

Este código Python demuestra una operación de conversión de PowerPoint a PDF en la que se obtienen varios PDFs basados en diferentes normas de cumplimiento:

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
El soporte de Aspose.Slides para operaciones de conversión a PDF le permite convertir PDF a los formatos de archivo más populares. Puede hacer [PDF a HTML](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/), [PDF a imagen](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/), [PDF a JPG](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/) y [PDF a PNG](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/) conversiones. Otras operaciones de conversión de PDF a formatos especializados—[PDF a SVG](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/), [PDF a TIFF](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/), y [PDF a XML](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/)—también son compatibles.
{{% /alert %}}

> **Nota:** Al exportar a PDF/UA, Aspose.Slides trata gráficos complejos como SmartArt, diagramas y fórmulas como una única figura. Los elementos de ruta individuales no se conservan como contenido separado y pueden marcarse como artefactos; el texto alternativo se proporciona solo para la figura completa.

## **Preguntas frecuentes**

**¿Puede Aspose.Slides for Python eliminar la información de la aplicación del PDF?**

No, Aspose.Slides for Python incluye automáticamente la información de la API y el número de versión en el PDF de salida. Esta información no puede modificarse ni eliminarse.

**¿Cómo incluyo solo diapositivas específicas en la conversión a PDF?**

Puede especificar los índices de diapositiva que desea convertir pasando una matriz de posiciones de diapositiva al método [guardar](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/).

**¿Es posible proteger con contraseña el PDF durante la conversión?**

Sí, puede establecer una contraseña y definir permisos de acceso usando la clase [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) antes de guardar la presentación como PDF.

**¿Aspose.Slides admite la conversión de PDF a otros formatos?**

Sí, Aspose.Slides admite la conversión de PDFs a formatos como HTML, formatos de imagen (JPG, PNG), SVG, TIFF y XML.

**¿Cómo puedo asegurar que mi PDF cumpla con las normas de accesibilidad?**

Establezca la propiedad [compliance](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/compliance/) en [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) a normas como `PDF_A1A`, `PDF_A1B` o `PDF_UA` para garantizar el cumplimiento de las directrices de accesibilidad.

**¿Puedo incluir diapositivas ocultas en el PDF de salida?**

Sí, al establecer la propiedad [show_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/show_hidden_slides/) en [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) a `True`, las diapositivas ocultas se incluirán en el PDF.

**¿Cómo ajusto la calidad y resolución de imagen durante la conversión?**

Utilice las propiedades [jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/jpeg_quality/) y [sufficient_resolution](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/sufficient_resolution/) en [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/) para controlar la calidad y resolución de imagen en el PDF resultante.

**¿Aspose.Slides gestiona automáticamente las sustituciones de fuentes?**

Aspose.Slides detecta sustituciones de fuentes durante la conversión, y puede gestionarlas usando la propiedad `warning_callback` en `SaveOptions` (actualmente con limitaciones).

## **Recursos adicionales**

- [Aspose.Slides for Python via .NET Documentation](/slides/es/python-net/)
- [Referencia de la API de Aspose.Slides](https://reference.aspose.com/slides/python-net/)
- [Convertidores en línea gratuitos de Aspose](https://products.aspose.app/slides/conversion)