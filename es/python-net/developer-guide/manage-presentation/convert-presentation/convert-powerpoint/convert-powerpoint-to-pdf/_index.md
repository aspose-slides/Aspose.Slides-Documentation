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
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Aspose.Slides for Python
description: "Guía paso a paso para convertir PPT, PPTX y ODP a PDFs de alta calidad y compatibles con WCAG en Python con Aspose.Slides—incluye protección con contraseña, selección de diapositivas y control de la calidad de imagen."
showReadingTime: true
---
## **Visión general**

La conversión de presentaciones de PowerPoint (PPT, PPTX, ODP) a formato PDF en Python ofrece varias ventajas, incluido garantizar la compatibilidad entre diferentes dispositivos y preservar el diseño y formato de su presentación. Esta guía muestra cómo convertir presentaciones a documentos PDF, utilizar diversas opciones para controlar la calidad de las imágenes, incluir diapositivas ocultas, proteger con contraseña los documentos PDF, detectar sustituciones de fuentes, seleccionar diapositivas específicas para la conversión y aplicar normas de cumplimiento a los documentos de salida.

## **Instalación**

```bash
pip install aspose.slides
```

El paquete incluye el tiempo de ejecución que necesita, por lo que Microsoft PowerPoint no tiene que estar instalado en la máquina que realiza la conversión.

## **Conversiones de PowerPoint a PDF**

Utilizando Aspose.Slides, puede convertir presentaciones en estos formatos a PDF:

* **PPT**
* **PPTX**
* **ODP**

Para convertir una presentación a PDF en Python, simplemente debe pasar el nombre del archivo como argumento en la clase [Presentation](https://docs.aspose.com/slides/es/python-net/api-reference/aspose.slides/presentation/) y luego guardar la presentación como PDF utilizando el método [Save](https://docs.aspose.com/slides/es/python-net/api-reference/aspose.slides/presentation/#methods). La clase [Presentation](https://docs.aspose.com/slides/es/python-net/api-reference/aspose.slides/presentation/) expone el método [Save](https://docs.aspose.com/slides/es/python-net/api-reference/aspose.slides/presentation/#methods) que se usa típicamente para convertir una presentación a PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides para Python escribe directamente la información de la API y el número de versión en los documentos de salida. Por ejemplo, cuando convierte una presentación a PDF, Aspose.Slides para Python rellena el campo Application con el valor '*Aspose.Slides*' y el campo PDF Producer con un valor en forma '*Aspose.Slides v XX.XX*'. **Nota** que no puede indicar a Aspose.Slides para Python que cambie o elimine esta información de los documentos de salida.

{{% /alert %}}

Aspose.Slides permite convertir:

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

La operación estándar de conversión de PowerPoint a PDF se ejecuta utilizando opciones predeterminadas. En este caso, Aspose.Slides intenta convertir la presentación proporcionada a PDF usando configuraciones óptimas con los niveles máximos de calidad. Este código Python le muestra cómo convertir un PowerPoint a PDF:

_Pasos: Conversiones de PowerPoint a PDF en Python_

El siguiente código de ejemplo explica estas conversiones usando Python vía .NET
- <a name="python-net-powerpoint-to-pdf"><strong>Pasos: Convertir PowerPoint a PDF usando Python vía .NET</a></strong>
- <a name="python-net-ppt-to-pdf"><strong>Pasos: Convertir PPT a PDF usando Python vía .NET</a></strong>
- <a name="python-net-pptx-to-pdf"><strong>Pasos: Convertir PPTX a PDF usando Python vía .NET</a></strong>
- <a name="python-net-odp-to-pdf"><strong>Pasos: Convertir ODP a PDF usando Python vía .NET</a></strong>
- <a name="python-net-odp-to-pdf"><strong>Pasos: Convertir PPS a PDF usando Python vía .NET</a></strong>

_Pasos del código:_

- Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/) y proporcionarle el archivo PowerPoint.
  * Extensión _.ppt_ para cargar un archivo **PPT** dentro de la clase _Presentation_.
  * Extensión _.pptx_ para cargar un archivo **PPTX** dentro de la clase _Presentation_.
  * Extensión _.odp_ para cargar un archivo **ODP** dentro de la clase _Presentation_.
  * Extensión _.pps_ para cargar un archivo **PPS** dentro de la clase _Presentation_.
- Guardar la _Presentation_ en formato **PDF** llamando al método **Save** y usando la enumeración **SaveFormat.PDF**.

```python
import aspose.slides as slides

# Instancia una clase Presentation que representa un archivo PowerPoint
presentation = slides.Presentation("PowerPoint.ppt")

# Guarda la presentación como PDF
presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{%  alert  color="primary"  %}} 

Aspose ofrece un [**convertidor de PowerPoint a PDF**](https://products.aspose.app/slides/es/conversion/ppt-to-pdf) gratuito en línea que demuestra el proceso de conversión de presentación a PDF. Para una implementación en vivo del procedimiento descrito aquí, puede probar el convertidor.

{{% /alert %}}

## **Convertir PowerPoint a PDF con opciones**

Aspose.Slides proporciona opciones personalizadas —propiedades bajo la clase [PdfOptions](https://docs.aspose.com/slides/es/python-net/api-reference/aspose.slides.export/pdfoptions/)— que le permiten personalizar el PDF (resultado del proceso de conversión), bloquear el PDF con una contraseña o incluso especificar cómo debe realizarse el proceso de conversión.

### **Convertir PowerPoint a PDF con opciones personalizadas**

Utilizando opciones de conversión personalizadas, puede definir su configuración de calidad preferida para imágenes rasterizadas, especificar cómo se deben manejar los metafiles, establecer un nivel de compresión para textos, definir DPI para imágenes, etc.

El ejemplo de código a continuación demuestra una operación en la que una presentación de PowerPoint se convierte a PDF con varias opciones personalizadas:

```python
import aspose.slides as slides

# Instancia la clase PdfOptions
# Establece la calidad para imágenes JPG
# Establece DPI para imágenes
# Establece el comportamiento de los metaficheros
# Establece el nivel de compresión de texto para el contenido textual
# Define el modo de cumplimiento del PDF
# Instancia la clase Presentation que representa un documento PowerPoint
with slides.Presentation("PowerPoint.pptx") as presentation:
    # Guarda la presentación como documento PDF
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Convertir PowerPoint a PDF con diapositivas ocultas**

Si una presentación contiene diapositivas ocultas, puede usar una opción personalizada —la propiedad `show_hidden_slides` de la clase [PdfOptions](https://docs.aspose.com/slides/es/python-net/api-reference/aspose.slides.export/pdfoptions/)— para indicar a Aspose.Slides que incluya las diapositivas ocultas como páginas en el PDF resultante.

Este código Python le muestra cómo convertir una presentación de PowerPoint a PDF incluyendo las diapositivas ocultas:

```python
import aspose.slides as slides

# Instancia una clase Presentation que representa un archivo PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# Instancia la clase PdfOptions
pdfOptions = slides.export.PdfOptions()

# Añade diapositivas ocultas
pdfOptions.show_hidden_slides = True

# Guarda la presentación como PDF
presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

### **Convertir PowerPoint a PDF protegido con contraseña**

Este código Python le muestra cómo convertir un PowerPoint a un PDF protegido con contraseña (utilizando los parámetros de protección de la clase [PdfOptions](https://docs.aspose.com/slides/es/python-net/api-reference/aspose.slides.export/pdfoptions/)):

```python
import aspose.slides as slides

# Instancia un objeto Presentation que representa un archivo PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# Instancia la clase PdfOptions
pdfOptions = slides.export.PdfOptions()

# Establece la contraseña del PDF y los permisos de acceso
pdfOptions.password = "password"
pdfOptions.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

# Guarda la presentación como PDF
presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **Convertir diapositivas seleccionadas de PowerPoint a PDF**

Este código Python le muestra cómo convertir diapositivas específicas de una presentación de PowerPoint a PDF:

```python
import aspose.slides as slides

# Instancia un objeto Presentation que representa un archivo PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# Establece una matriz de posiciones de diapositivas
slides_array = [ 1, 3 ]

# Guarda la presentación como PDF
presentation.save("PPTX-to-PDF.pdf", slides_array, slides.export.SaveFormat.PDF)
```

## **Convertir PowerPoint a PDF con tamaño de diapositiva personalizado**

Este código Python le muestra cómo convertir un PowerPoint cuando su tamaño de diapositiva está especificado a PDF:

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

# Instancia la clase Presentation que representa un archivo PowerPoint o OpenDocument.
with slides.Presentation("SelectedSlides.pptx") as presentation:

    # Crea una nueva presentación con un tamaño de diapositiva ajustado.
    with slides.Presentation() as resized_presentation:

        # Establece el tamaño de diapositiva personalizado.
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)

        # Clona la primera diapositiva de la presentación original y elimina la diapositiva vacía predeterminada.
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)
        resized_presentation.slides.remove_at(1)

        # Guarda la presentación redimensionada como PDF.
        resized_presentation.save("PDF_with_custom_slide_size.pdf", slides.export.SaveFormat.PDF)
```

## **Convertir PowerPoint a PDF en vista de notas de diapositiva**

Este código Python le muestra cómo convertir un PowerPoint a notas PDF:

```python
import aspose.slides as slides

# Instancia una clase Presentation que representa un archivo PowerPoint
presentation = slides.Presentation("NotesFile.pptx")

# Configura las opciones PDF con el diseño de notas
pdfOptions = slides.export.PdfOptions()
pdfOptions.slides_layout_options = slides.export.NotesCommentsLayoutingOptions()
pdfOptions.slides_layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Guarda la presentación en un PDF con notas
presentation.save("Pdf_Notes_out.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **Normas de accesibilidad y cumplimiento para PDF**

Aspose.Slides le permite utilizar un procedimiento de conversión que cumpla con las [Directrices de accesibilidad de contenido web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Puede exportar un documento de PowerPoint a PDF utilizando cualquiera de estas normas de cumplimiento: **PDF/A1a**, **PDF/A1b** y **PDF/UA**.

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

{{% alert title="Note" color="warning" %}} 

El soporte de Aspose.Slides para operaciones de conversión a PDF se extiende permitiendo convertir PDF a los formatos de archivo más populares. Puede realizar conversiones de [PDF a HTML](https://products.aspose.com/slides/es/python-net/conversion/pdf-to-html/), [PDF a imagen](https://products.aspose.com/slides/es/python-net/conversion/pdf-to-image/), [PDF a JPG](https://products.aspose.com/slides/es/python-net/conversion/pdf-to-jpg/), y [PDF a PNG](https://products.aspose.com/slides/es/python-net/conversion/pdf-to-png/). Otras operaciones de conversión de PDF a formatos especializados —[PDF a SVG](https://products.aspose.com/slides/es/python-net/conversion/pdf-to-svg/), [PDF a TIFF](https://products.aspose.com/slides/es/python-net/conversion/pdf-to-tiff/), y [PDF a XML](https://products.aspose.com/slides/es/python-net/conversion/pdf-to-xml/)—también son compatibles.

{{% /alert %}}

> **Nota:** Al exportar a PDF/UA, Aspose.Slides trata los gráficos complejos como SmartArt, diagramas y fórmulas como una sola figura. Los elementos de ruta individuales no se conservan como contenido separado y pueden marcarse como artefactos; el texto alternativo se proporciona solo para la figura completa.

## **Preguntas frecuentes**

### ¿Puede Aspose.Slides para Python eliminar la información de la aplicación del PDF?

No, Aspose.Slides para Python incluye automáticamente la información de la API y el número de versión en el PDF de salida. Esta información no puede modificarse ni eliminarse.

### ¿Cómo incluyo solo diapositivas específicas en la conversión a PDF?

Puede especificar los índices de diapositiva que desea convertir pasando una matriz de posiciones de diapositivas al método `save`.

### ¿Es posible proteger con contraseña el PDF durante la conversión?

Sí, puede establecer una contraseña y definir permisos de acceso utilizando la clase `PdfOptions` antes de guardar la presentación como PDF.

### ¿Aspose.Slides admite la conversión de PDF a otros formatos?

Sí, Aspose.Slides admite la conversión de PDFs a formatos como HTML, formatos de imagen (JPG, PNG), SVG, TIFF y XML.

### ¿Cómo puedo asegurar que mi PDF cumpla con las normas de accesibilidad?

Establezca la propiedad `compliance` en `PdfOptions` a normas como `PDF_A1A`, `PDF_A1B` o `PDF_UA` para garantizar el cumplimiento de las directrices de accesibilidad.

### ¿Puedo incluir diapositivas ocultas en la salida PDF?

Sí, configurando la propiedad `show_hidden_slides` en `PdfOptions` a `True`, las diapositivas ocultas se incluirán en el PDF.

### ¿Cómo ajusto la calidad y resolución de las imágenes durante la conversión?

Utilice las propiedades `jpeg_quality` y `sufficient_resolution` en `PdfOptions` para controlar la calidad y resolución de las imágenes en el PDF resultante.

### ¿Aspose.Slides gestiona automáticamente las sustituciones de fuentes?

Aspose.Slides detecta sustituciones de fuentes durante la conversión, y usted puede gestionarlas mediante la propiedad `warning_callback` en `SaveOptions` (actualmente limitada).

## **Recursos adicionales**

- [Documentación de Aspose.Slides para .NET](https://docs.aspose.com/slides/es/python-net/)
- [Referencia de la API de Aspose.Slides](https://reference.aspose.com/slides/es/python-net/)
- [Convertidores gratuitos en línea de Aspose](https://products.aspose.app/slides/es/conversion)