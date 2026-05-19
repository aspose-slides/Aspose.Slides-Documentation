---
title: Convertir PPT y PPTX a PDF en Python | Opciones avanzadas
linktitle: PowerPoint a PDF
type: docs
weight: 40
url: /es/python-net/convert-powerpoint-to-pdf/
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
description: "Guía paso a paso para convertir PPT, PPTX y ODP a PDFs de alta calidad y compatibles con WCAG en Python con Aspose.Slides—incluye protección con contraseña, selección de diapositivas y control de calidad de imagen."
showReadingTime: true
---
## **Descripción general**

Convertir presentaciones de PowerPoint (PPT, PPTX, ODP) a formato PDF en Python ofrece varias ventajas, entre ellas garantizar la compatibilidad entre diferentes dispositivos y preservar el diseño y el formato de su presentación. Esta guía muestra cómo convertir presentaciones a documentos PDF, utilizar diversas opciones para controlar la calidad de imagen, incluir diapositivas ocultas, proteger con contraseña los documentos PDF, detectar sustituciones de fuentes, seleccionar diapositivas específicas para la conversión y aplicar normas de cumplimiento a los documentos de salida.

## **Conversiones de PowerPoint a PDF**

Usando Aspose.Slides, puede convertir presentaciones en estos formatos a PDF:

* **PPT**
* **PPTX**
* **ODP**

Para convertir una presentación a PDF en Python, simplemente debe pasar el nombre del archivo como argumento en la clase [Presentación](https://docs.aspose.com/slides/es/python-net/api-reference/aspose.slides/presentation/) y luego guardar la presentación como PDF utilizando el método [Save](https://docs.aspose.com/slides/es/python-net/api-reference/aspose.slides/presentation/#methods). La clase [Presentación](https://docs.aspose.com/slides/es/python-net/api-reference/aspose.slides/presentation/) expone el método [Save](https://docs.aspose.com/slides/es/python-net/api-reference/aspose.slides/presentation/#methods) que se utiliza habitualmente para convertir una presentación a PDF.

{{%  alert title="NOTA"  color="warning"   %}} 

Aspose.Slides for Python escribe directamente la información de la API y el número de versión en los documentos de salida. Por ejemplo, cuando convierte una presentación a PDF, Aspose.Slides for Python rellena el campo Application con el valor '*Aspose.Slides*' y el campo PDF Producer con un valor en forma '*Aspose.Slides v XX.XX*'. **Nota** que no puede indicar a Aspose.Slides for Python que cambie o elimine esta información de los documentos de salida.

{{% /alert %}}

Aspose.Slides permite conversiones:

* Presentaciones completas a PDF
* Diapositivas específicas en una presentación a PDF

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

La operación estándar de conversión de PowerPoint a PDF se ejecuta usando opciones predeterminadas. En este caso, Aspose.Slides intenta convertir la presentación proporcionada a PDF usando configuraciones óptimas en los niveles máximos de calidad. Este código Python le muestra cómo convertir un PowerPoint a PDF:

_Pasos: conversiones de PowerPoint a PDF en Python_

El siguiente código de ejemplo explica estas conversiones usando Python vía .NET
- <a name="python-net-powerpoint-to-pdf"><strong>Pasos: Convertir PowerPoint a PDF usando Python vía .NET</strong></a>
- <a name="python-net-ppt-to-pdf"><strong>Pasos: Convertir PPT a PDF usando Python vía .NET</strong></a>
- <a name="python-net-pptx-to-pdf"><strong>Pasos: Convertir PPTX a PDF usando Python vía .NET</strong></a>
- <a name="python-net-odp-to-pdf"><strong>Pasos: Convertir ODP a PDF usando Python vía .NET</strong></a>
- <a name="python-net-odp-to-pdf"><strong>Pasos: Convertir PPS a PDF usando Python vía .NET</strong></a>

_Pasos de código:_

- Cree una instancia de la clase [Presentación](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/) y proporciónela el archivo PowerPoint.
  * _.ppt_ extensión para cargar un archivo **PPT** dentro de la clase _Presentación_.
  * _.pptx_ extensión para cargar un archivo **PPTX** dentro de la clase _Presentación_.
  * _.odp_ extensión para cargar un archivo **ODP** dentro de la clase _Presentación_.
  * _.pps_ extensión para cargar un archivo **PPS** dentro de la clase _Presentación_.
- Guarde la _Presentación_ en formato **PDF** llamando al método **Save** y usando la enumeración **SaveFormat.PDF**.

```python
import aspose.slides as slides

# Instancia una clase Presentation que representa un archivo PowerPoint
presentation = slides.Presentation("PowerPoint.ppt")

# Guarda la presentación como PDF
presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{%  alert  color="primary"  %}} 

Aspose ofrece un [**convertidor de PowerPoint a PDF**](https://products.aspose.app/slides/es/conversion/ppt-to-pdf) gratuito en línea que muestra el proceso de conversión de presentación a PDF. Para una implementación en vivo del procedimiento descrito aquí, puede probar el convertidor.

{{% /alert %}}

## **Convertir PowerPoint a PDF con opciones**

Aspose.Slides proporciona opciones personalizadas —propiedades bajo la clase [PdfOptions](https://docs.aspose.com/slides/es/python-net/api-reference/aspose.slides.export/pdfoptions/)— que le permiten personalizar el PDF (resultado del proceso de conversión), bloquear el PDF con una contraseña, o incluso especificar cómo debe realizarse el proceso de conversión.

### **Convertir PowerPoint a PDF con opciones personalizadas**

Usando opciones de conversión personalizadas, puede establecer su configuración de calidad preferida para imágenes raster, especificar cómo deben manejarse los metarchivos, establecer un nivel de compresión para textos, fijar DPI para imágenes, etc.

El ejemplo de código a continuación muestra una operación en la que una presentación de PowerPoint se convierte a PDF con varias opciones personalizadas:

```python
import aspose.slides as slides

# Instancia la clase PdfOptions
pdf_options = slides.export.PdfOptions()

# Establece la calidad de las imágenes JPG
pdf_options.jpeg_quality = 90

# Establece el DPI para las imágenes
pdf_options.sufficient_resolution = 300

# Establece el comportamiento de los metafiles
pdf_options.save_metafiles_as_png = True

# Establece el nivel de compresión de texto para el contenido textual
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE

# Define el modo de cumplimiento del PDF
pdf_options.compliance = slides.export.PdfCompliance.PDF15

# Instancia la clase Presentation que representa un documento PowerPoint
with slides.Presentation("PowerPoint.pptx") as presentation:
    # Guarda la presentación como documento PDF
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Convertir PowerPoint a PDF con diapositivas ocultas**

Si una presentación contiene diapositivas ocultas, puede usar una opción personalizada —la propiedad `show_hidden_slides` de la clase [PdfOptions](https://docs.aspose.com/slides/es/python-net/api-reference/aspose.slides.export/pdfoptions/)— para indicar a Aspose.Slides que incluya las diapositivas ocultas como páginas en el PDF resultante.

Este código Python muestra cómo convertir una presentación de PowerPoint a PDF incluyendo las diapositivas ocultas:

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

Este código Python muestra cómo convertir un PowerPoint a un PDF protegido con contraseña (usando los parámetros de protección de la clase [PdfOptions](https://docs.aspose.com/slides/es/python-net/api-reference/aspose.slides.export/pdfoptions/)):

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

### **Detectar sustituciones de fuentes**

Aspose.Slides proporciona la propiedad `warning_callback` bajo la clase [SaveOptions](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/saveoptions/) para permitir detectar sustituciones de fuentes en el proceso de conversión de una presentación a PDF.

Este código Python muestra cómo detectar sustituciones de fuentes:  

```python
[TODO[SLIDESPYNET-91]: callbacks are not supported for now]
```

{{%  alert color="primary"  %}} 

Para más información sobre la sustitución de fuentes, consulte el artículo [Font Substitution](https://docs.aspose.com/slides/es/python-net/font-substitution/).

{{% /alert %}} 

## **Convertir diapositivas seleccionadas en PowerPoint a PDF**

Este código Python muestra cómo convertir diapositivas específicas en una presentación de PowerPoint a PDF:

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

Este código Python muestra cómo convertir un PowerPoint cuando su tamaño de diapositiva está especificado a un PDF:

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

        # Clona la primera diapositiva de la presentación original.
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # Guarda la presentación redimensionada en un PDF con notas.
        resized_presentation.save("PDF_with_notes.pdf", slides.export.SaveFormat.PDF)
```

## **Convertir PowerPoint a PDF en vista de notas de diapositiva**

Este código Python muestra cómo convertir un PowerPoint a PDF de notas:

```python
import aspose.slides as slides

# Instancia una clase Presentation que representa un archivo PowerPoint
presentation = slides.Presentation("NotesFile.pptx")

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Guarda la presentación en PDF con notas
presentation.Save("Pdf_Notes_out.tiff", slides.export.SaveFormat.PDF, pdfOptions)
```

## **Accesibilidad y normas de cumplimiento para PDF**

Aspose.Slides permite utilizar un procedimiento de conversión que cumpla con las [Directrices de Accesibilidad al Contenido Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Puede exportar un documento PowerPoint a PDF usando cualquiera de estas normas de cumplimiento: **PDF/A1a**, **PDF/A1b**, y **PDF/UA**.

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

{{% alert title="Nota" color="warning" %}} 

El soporte de Aspose.Slides para operaciones de conversión a PDF se extiende a permitir la conversión de PDF a los formatos de archivo más populares. Puede realizar conversiones de [PDF a HTML](https://products.aspose.com/slides/es/python-net/conversion/pdf-to-html/), [PDF a imagen](https://products.aspose.com/slides/es/python-net/conversion/pdf-to-image/), [PDF a JPG](https://products.aspose.com/slides/es/python-net/conversion/pdf-to-jpg/), y [PDF a PNG](https://products.aspose.com/slides/es/python-net/conversion/pdf-to-png/) . Otras operaciones de conversión de PDF a formatos especializados—[PDF a SVG](https://products.aspose.com/slides/es/python-net/conversion/pdf-to-svg/), [PDF a TIFF](https://products.aspose.com/slides/es/python-net/conversion/pdf-to-tiff/), y [PDF a XML](https://products.aspose.com/slides/es/python-net/conversion/pdf-to-xml/)—también son compatibles.

{{% /alert %}}

> **Nota:** Al exportar a PDF/UA, Aspose.Slides trata los gráficos complejos como SmartArt, diagramas y fórmulas como una única figura. Los elementos de ruta individuales no se conservan como contenido separado y pueden marcarse como artefactos; el texto alternativo se proporciona solo para la figura completa.

## **Preguntas frecuentes**

**¿Puede Aspose.Slides for Python eliminar la información de aplicación del PDF?**

No, Aspose.Slides for Python incluye automáticamente la información de la API y el número de versión en el PDF de salida. Esta información no puede modificarse ni eliminarse.

**¿Cómo incluyo solo diapositivas específicas en la conversión a PDF?**

Puede especificar los índices de diapositiva que desea convertir pasando una matriz de posiciones de diapositiva al método `save`.

**¿Es posible proteger con contraseña el PDF durante la conversión?**

Sí, puede establecer una contraseña y definir permisos de acceso usando la clase `PdfOptions` antes de guardar la presentación como PDF.

**¿Aspose.Slides soporta la conversión de PDF a otros formatos?**

Sí, Aspose.Slides soporta la conversión de PDFs a formatos como HTML, formatos de imagen (JPG, PNG), SVG, TIFF y XML.

**¿Cómo puedo asegurar que mi PDF cumpla con los estándares de accesibilidad?**

Establezca la propiedad `compliance` en `PdfOptions` a estándares como `PDF_A1A`, `PDF_A1B` o `PDF_UA` para garantizar el cumplimiento de las directrices de accesibilidad.

**¿Puedo incluir diapositivas ocultas en el PDF resultante?**

Sí, configurando la propiedad `show_hidden_slides` en `PdfOptions` a `True` se incluirán las diapositivas ocultas en el PDF.

**¿Cómo ajusto la calidad y resolución de imagen durante la conversión?**

Utilice las propiedades `jpeg_quality` y `sufficient_resolution` en `PdfOptions` para controlar la calidad y la resolución de imagen en el PDF resultante.

**¿Aspose.Slides gestiona automáticamente las sustituciones de fuentes?**

Aspose.Slides detecta sustituciones de fuentes durante la conversión, y puede gestionarlas usando la propiedad `warning_callback` en `SaveOptions` (actualmente con limitaciones).

## **Recursos adicionales**

- [Documentación de Aspose.Slides para .NET](https://docs.aspose.com/slides/es/python-net/)
- [Referencia de la API de Aspose.Slides](https://reference.aspose.com/slides/es/python-net/)
- [Convertidores gratuitos en línea de Aspose](https://products.aspose.app/slides/es/conversion)