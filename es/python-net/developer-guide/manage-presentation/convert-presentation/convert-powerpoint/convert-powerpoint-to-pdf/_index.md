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
  - Aspose.Slides
description: "Guía paso a paso para convertir PPT y PPTX a PDFs de alta calidad y compatibles con WCAG en Python con Aspose.Slides: incluye protección con contraseña, selección de diapositivas y control de la calidad de imagen."
---

## **Descripción general**

Convertir documentos de PowerPoint al formato PDF ofrece varias ventajas, incluyendo asegurar la compatibilidad entre diferentes dispositivos y preservar el diseño y la formateo de tu presentación. Este artículo te muestra cómo convertir presentaciones a documentos PDF, usar varias opciones para controlar la calidad de imagen, incluir diapositivas ocultas, proteger documentos PDF con contraseña, detectar sustituciones de fuentes, seleccionar diapositivas para conversión y aplicar estándares de cumplimiento a los documentos de salida.

## **Conversiones de PowerPoint a PDF**

Usando Aspose.Slides, puedes convertir presentaciones en estos formatos a PDF:

* PPT
* PPTX
* ODP

Para convertir una presentación a PDF en Python, simplemente debes pasar el nombre del archivo como un argumento en la clase [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) y luego guardar la presentación como un PDF usando un método [Save](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/#methods). La clase [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) expone el método [Save](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/#methods) que se utiliza comúnmente para convertir una presentación a PDF.

{{%  alert title="NOTA"  color="warning"   %}} 

Aspose.Slides para Python escribe directamente la información de la API y el número de versión en los documentos de salida. Por ejemplo, cuando convierte una presentación a PDF, Aspose.Slides para Python llena el campo de Aplicación con el valor '*Aspose.Slides*' y el campo de Productor PDF con un valor en la forma '*Aspose.Slides v XX.XX*'. **Nota** que no puedes instruir a Aspose.Slides para Python para cambiar o eliminar esta información de los documentos de salida.

{{% /alert %}}

Aspose.Slides permite convertir:

* una presentación completa a PDF
* diapositivas específicas en una presentación a PDF
* una presentación 

Aspose.Slides exporta presentaciones a PDF de una manera que hace que el contenido de los PDFs resultantes sea muy similar al de las presentaciones originales. Estos elementos y atributos conocidos suelen renderizarse correctamente en conversiones de presentación a PDF:

* imágenes
* cuadros de texto y otras formas
* textos y su formato
* párrafos y su formato
* hiperenlaces
* encabezados y pies de página
* viñetas
* tablas

## **Convertir PowerPoint a PDF**

La operación estándar de conversión de PowerPoint a PDF se ejecuta usando opciones predeterminadas. En este caso, Aspose.Slides intenta convertir la presentación proporcionada a PDF usando configuraciones óptimas en los niveles de calidad máximos. Este código Python te muestra cómo convertir un PowerPoint a PDF:

_Pasos: Conversiones de PowerPoint a PDF en Python_

El siguiente código de ejemplo explica estas conversiones usando Python a través de .NET
- <a name="python-net-powerpoint-to-pdf"><strong>Pasos: Convertir PowerPoint a PDF usando Python a través de .NET</a></strong>
- <a name="python-net-ppt-to-pdf"><strong>Pasos: Convertir PPT a PDF usando Python a través de .NET</a></strong>
- <a name="python-net-pptx-to-pdf"><strong>Pasos: Convertir PPTX a PDF usando Python a través de .NET</a></strong>
- <a name="python-net-odp-to-pdf"><strong>Pasos: Convertir ODP a PDF usando Python a través de .NET</a></strong>
- <a name="python-net-odp-to-pdf"><strong>Pasos: Convertir PPS a PDF usando Python a través de .NET</a></strong>

_Pasos de Código:_

- Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) y proporciona el archivo de PowerPoint.
  * _.ppt_ extensión para cargar **PPT** archivo dentro de la clase _Presentation_.
  * _.pptx_ extensión para cargar **PPTX** archivo dentro de la clase _Presentation_.
  * _.odp_ extensión para cargar **ODP** archivo dentro de la clase _Presentation_.
  * _.pps_ extensión para cargar **PPS** archivo dentro de la clase _Presentation_.
- Guarda la _Presentation_ en formato **PDF** llamando al método **Save** y usando la enumeración **SaveFormat.PDF**.
  

```python
import aspose.slides as slides

# Instancia una clase Presentation que representa un archivo de PowerPoint
presentation = slides.Presentation("PowerPoint.ppt")

# Guarda la presentación como un PDF
presentation.save("PPT-a-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{%  alert  color="primary"  %}} 

Aspose proporciona un [**convertidor de PowerPoint a PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) en línea gratuito que demuestra el proceso de conversión de presentación a PDF. Para una implementación en vivo del procedimiento descrito aquí, puedes hacer una prueba con el convertidor.

{{% /alert %}}

## Convertir PowerPoint a PDF con Opciones

Aspose.Slides proporciona opciones personalizadas—propiedades bajo la clase [PdfOptions](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.export/pdfoptions/)—que te permiten personalizar el PDF (resultado del proceso de conversión), bloquear el PDF con una contraseña, o incluso especificar cómo debe ir el proceso de conversión.

### **Convertir PowerPoint a PDF con Opciones Personalizadas**

Usando opciones de conversión personalizadas, puedes establecer tu configuración de calidad preferida para imágenes rasterizadas, especificar cómo deben manejarse los metafiles, establecer un nivel de compresión para textos, establecer DPI para imágenes, etc.

El siguiente ejemplo de código demuestra una operación en la que se convierte una presentación de PowerPoint a PDF con varias opciones personalizadas:

```python
import aspose.slides as slides

# Instancia la clase PdfOptions
pdf_options = slides.export.PdfOptions()

# Establece la calidad para imágenes JPG
pdf_options.jpeg_quality = 90

# Establece DPI para imágenes
pdf_options.sufficient_resolution = 300

# Establece el comportamiento para metafiles
pdf_options.save_metafiles_as_png = True

# Establece el nivel de compresión de texto para contenido textual
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE

# Define el modo de cumplimiento del PDF
pdf_options.compliance = slides.export.PdfCompliance.PDF15

# Instancia la clase Presentation que representa un documento de PowerPoint
with slides.Presentation("PowerPoint.pptx") as presentation:
    # Guarda la presentación como un documento PDF
    presentation.save("PowerPoint-a-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Convertir PowerPoint a PDF con Diapositivas Ocultas**

Si una presentación contiene diapositivas ocultas, puedes usar una opción personalizada—la propiedad `show_hidden_slides` de la clase [PdfOptions](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.export/pdfoptions/)—para instruir a Aspose.Slides a incluir las diapositivas ocultas como páginas en el PDF resultante.

Este código Python te muestra cómo convertir una presentación de PowerPoint a PDF con las diapositivas ocultas incluidas:

```python
import aspose.slides as slides

# Instancia una clase Presentation que representa un archivo de PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# Instancia la clase PdfOptions
pdfOptions = slides.export.PdfOptions()

# Agrega diapositivas ocultas
pdfOptions.show_hidden_slides = True

# Guarda la presentación como un PDF
presentation.save("PowerPoint-a-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

### **Convertir PowerPoint a PDF Protegido con Contraseña**

Este código Python te muestra cómo convertir un PowerPoint a un PDF protegido con contraseña (usando parámetros de protección de la clase [PdfOptions](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.export/pdfoptions/)):

```python
import aspose.slides as slides

# Instancia un objeto Presentation que representa un archivo de PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# Instancia la clase PdfOptions
pdfOptions = slides.export.PdfOptions()

# Establece la contraseña del PDF y permisos de acceso
pdfOptions.password = "contraseña"
pdfOptions.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

# Guarda la presentación como un PDF
presentation.save("PPTX-a-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

### Detectar Sustituciones de Fuentes**

Aspose.Slides proporciona la propiedad `warning_callback` bajo la clase [SaveOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/saveoptions/) para permitirte detectar sustituciones de fuentes en un proceso de conversión de presentación a PDF. 

Este código Python te muestra cómo detectar sustituciones de fuentes:  

```python
[TODO[SLIDESPYNET-91]: los callbacks no son compatibles por ahora]
```

{{%  alert color="primary"  %}} 

Para obtener más información sobre sustituciones de fuentes, consulta el artículo sobre [Sustitución de Fuentes](https://docs.aspose.com/slides/python-net/font-substitution/).

{{% /alert %}} 

## **Convertir Diapositivas Seleccionadas en PowerPoint a PDF**

Este código Python te muestra cómo convertir diapositivas específicas en una presentación de PowerPoint a PDF:

```python
import aspose.slides as slides

# Instancia un objeto Presentation que representa un archivo de PowerPoint
presentation = slides.Presentation("PowerPoint.pptx")

# Establece un arreglo de posiciones de diapositivas
slides_array = [ 1, 3 ]

# Guarda la presentación como un PDF
presentation.save("PPTX-a-PDF.pdf", slides_array, slides.export.SaveFormat.PDF)
```

## **Convertir PowerPoint a PDF con Tamaño de Diapositiva Personalizado**

Este código Python te muestra cómo convertir un PowerPoint cuando su tamaño de diapositiva está especificado a un PDF:

```python
import aspose.slides as slides

# Instancia un objeto Presentation que representa un archivo de PowerPoint 
presentation = slides.Presentation("DiapositivasSeleccionadas.pptx")
auxPresentation = slides.Presentation()

slide = presentation.slides[0]

auxPresentation.slides.insert_clone(0, slide)

# Establece el tipo y tamaño de la diapositiva 
auxPresentation.slide_size.set_size(612, 792, slides.SlideSizeScaleType.ENSURE_FIT)

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

auxPresentation.save("PDFnotas_salida.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **Convertir PowerPoint a PDF en Vista de Diapositivas de Notas**

Este código Python te muestra cómo convertir un PowerPoint a PDF notas:

```python
import aspose.slides as slides

# Instancia una clase Presentation que representa un archivo de PowerPoint
presentation = slides.Presentation("ArchivoNotas.pptx")

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Guarda la presentación a PDF notas
presentation.Save("Pdf_Notas_salida.tiff", slides.export.SaveFormat.PDF, pdfOptions)
```

## **Estándares de Accesibilidad y Cumplimiento para PDF**

Aspose.Slides te permite usar un procedimiento de conversión que cumple con las [Directrices de Accesibilidad para el Contenido Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Puedes exportar un documento de PowerPoint a PDF usando cualquiera de estos estándares de cumplimiento: **PDF/A1a**, **PDF/A1b** y **PDF/UA**.

Este código Python demuestra una operación de conversión de PowerPoint a PDF en la que se obtienen múltiples PDFs basados en diferentes estándares de cumplimiento:

```python
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

options = slides.export.PdfOptions()

options.compliance = slides.export.PdfCompliance.PDF_A1A
pres.save("pres-a1a-cumplimiento.pdf", slides.export.SaveFormat.PDF, options)

options.compliance = slides.export.PdfCompliance.PDF_A1B
pres.save("pres-a1b-cumplimiento.pdf", slides.export.SaveFormat.PDF, options)

options.compliance = slides.export.PdfCompliance.PDF_UA
pres.save("pres-ua-cumplimiento.pdf", slides.export.SaveFormat.PDF, options)
```

{{% alert title="Nota" color="warning" %}} 

El soporte de Aspose.Slides para operaciones de conversión de PDF se extiende a permitirte convertir PDF a los formatos de archivo más populares. Puedes hacer conversiones de [PDF a HTML](https://products.aspose.com/slides/python-net/conversion/pdf-to-html/), [PDF a imagen](https://products.aspose.com/slides/python-net/conversion/pdf-to-image/), [PDF a JPG](https://products.aspose.com/slides/python-net/conversion/pdf-to-jpg/), y [PDF a PNG](https://products.aspose.com/slides/python-net/conversion/pdf-to-png/). Otras operaciones de conversión de PDF a formatos especializados—[PDF a SVG](https://products.aspose.com/slides/python-net/conversion/pdf-to-svg/), [PDF a TIFF](https://products.aspose.com/slides/python-net/conversion/pdf-to-tiff/), y [PDF a XML](https://products.aspose.com/slides/python-net/conversion/pdf-to-xml/)—también están soportadas.

{{% /alert %}}