---
title: Convertir PPT y PPTX a PDF en Python mediante Java [Incluidas características avanzadas]
linktitle: PowerPoint a PDF
type: docs
weight: 40
url: /es/python-java/convert-powerpoint-to-pdf/
keywords:
- convertir PowerPoint
- convertir presentación
- PowerPoint a PDF
- presentación a PDF
- PPT a PDF
- convertir PPT a PDF
- PPTX a PDF
- convertir PPTX a PDF
- guardar PowerPoint como PDF
- guardar PPT como PDF
- guardar PPTX como PDF
- exportar PPT a PDF
- exportar PPTX a PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Java
- Aspose.Slides
description: "Convertir PowerPoint PPT/PPTX a PDFs de alta calidad y buscables en Python mediante Java usando Aspose.Slides, con ejemplos de código rápidos y opciones avanzadas de conversión."
---
## **Visión general**

Convertir presentaciones de PowerPoint (PPT, PPTX, ODP, etc.) a formato PDF en Python mediante Java ofrece varias ventajas, entre ellas la compatibilidad con diferentes dispositivos y la preservación del diseño y formato de su presentación. Esta guía muestra cómo convertir presentaciones a documentos PDF, usar diversas opciones para controlar la calidad de imagen, incluir diapositivas ocultas, proteger con contraseña los archivos PDF, detectar sustituciones de fuentes, seleccionar diapositivas específicas para la conversión y aplicar normas de cumplimiento a los documentos de salida.

## **Conversiones de PowerPoint a PDF**

Con Aspose.Slides, puede convertir presentaciones en los siguientes formatos a PDF:

* **PPT**
* **PPTX**
* **ODP**

Para convertir una presentación a PDF, pase el nombre del archivo como argumento a la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) y luego guarde la presentación como PDF mediante el método [save](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#save). La clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) expone el método [save](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#save) que se utiliza habitualmente para convertir una presentación a PDF.

{{% alert color="info" title="Note" %}}

Aspose.Slides for Python via Java inserta la información de su API y el número de versión en los documentos de salida. Por ejemplo, al convertir una presentación a PDF, Aspose.Slides rellena el campo Application con "*Aspose.Slides*" y el campo PDF Producer con un valor del tipo "*Aspose.Slides v XX.XX*". **Nota** que no puede indicar a Aspose.Slides que cambie o elimine esta información de los documentos de salida.

{{% /alert %}}

Aspose.Slides le permite convertir:

* Presentaciones completas a PDF
* Diapositivas específicas de una presentación a PDF

Aspose.Slides exporta presentaciones a PDF, asegurando que los PDF resultantes coincidan estrechamente con las presentaciones originales. Los elementos y atributos se renderizan con precisión en la conversión, incluidos:

* Imágenes
* Cuadros de texto y formas
* Formato de texto
* Formato de párrafo
* Hipervínculos
* Cabeceras y pies de página
* Viñetas
* Tablas

## **Convertir PowerPoint a PDF**

La conversión estándar utiliza la configuración predeterminada de exportación a PDF. Use opciones personalizadas cuando necesite controlar la calidad de imagen, el contenido de la página o el cumplimiento de PDF.

Instale [Aspose.Slides for Python via Java](/slides/es/python-java/installation/) y un tiempo de ejecución Java compatible antes de ejecutar los ejemplos. Cada ejemplo lee `presentation.pptx` desde el directorio de trabajo actual; reemplácelo por su archivo PPT, PPTX u ODP. Inicie la JVM una sola vez por proceso Python.

Este código convierte una presentación a PDF:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}

Aspose ofrece un conversor en línea gratuito de **PowerPoint a PDF** [(https://products.aspose.app/slides/es/conversion/ppt-to-pdf)](https://products.aspose.app/slides/es/conversion/ppt-to-pdf) que muestra el proceso de conversión de presentación a PDF. Puede probar este conversor para una implementación en vivo del procedimiento descrito aquí.

{{% /alert %}}

## **Convertir PowerPoint a PDF con opciones**

Aspose.Slides proporciona opciones personalizadas —propiedades de la clase [PdfOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/pdfoptions/)— que le permiten personalizar el PDF resultante, bloquear el PDF con una contraseña o especificar cómo debe proceder el proceso de conversión.

### **Convertir PowerPoint a PDF con opciones personalizadas**

Con opciones de conversión personalizadas, puede definir su configuración de calidad preferida para imágenes rasterizadas, especificar cómo se deben gestionar los metarchivos, establecer un nivel de compresión para el texto, configurar DPI para imágenes y más.

El siguiente ejemplo de código muestra cómo convertir una presentación de PowerPoint a PDF con varias opciones personalizadas.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, PdfTextCompression, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setJpegQuality(jpype.JByte(90))
    pdf_options.setSufficientResolution(300)
    pdf_options.setSaveMetafilesAsPng(True)
    pdf_options.setTextCompression(PdfTextCompression.Flate)
    pdf_options.setCompliance(PdfCompliance.Pdf15)
    presentation.save("presentation-custom.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Convertir PowerPoint a PDF con diapositivas ocultas**

Si una presentación contiene diapositivas ocultas, puede usar el método [setShowHiddenSlides](https://reference.aspose.com/slides/es/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) de la clase [PdfOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/pdfoptions/) para incluir las diapositivas ocultas como páginas en el PDF resultante.

Este código muestra cómo convertir una presentación de PowerPoint a PDF con las diapositivas ocultas incluidas:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setShowHiddenSlides(True)
    presentation.save("presentation-hidden-slides.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Convertir PowerPoint a PDF protegido con contraseña**

Este código demuestra cómo convertir una presentación de PowerPoint en un PDF protegido con contraseña usando los parámetros de protección de la clase [PdfOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/pdfoptions/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfAccessPermissions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setPassword("password")
    permissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint
    pdf_options.setAccessPermissions(permissions)
    presentation.save("presentation-protected.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Detectar sustituciones de fuentes**

Aspose.Slides proporciona el método [setWarningCallback](https://reference.aspose.com/slides/es/python-java/aspose.slides/saveoptions/#setWarningCallback) bajo la clase [PdfOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/pdfoptions/), lo que le permite detectar sustituciones de fuentes durante el proceso de conversión de presentación a PDF.

Utilice un proxy JPype para recibir las devoluciones de llamada de advertencia de la API Java. Convierta la cadena de descripción Java a una cadena Python antes de comprobar su prefijo:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, ReturnAction, SaveFormat, WarningType

class FontSubstitutionHandler:
    def warning(self, warning):
        description = str(warning.getDescription())
        if warning.getWarningType() == WarningType.DataLoss and description.startswith("Font will be substituted"):
            print(f"Font substitution warning: {description}")
        return ReturnAction.Continue


presentation = Presentation("presentation.pptx")
try:
    handler = FontSubstitutionHandler()
    callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
    pdf_options = PdfOptions()
    pdf_options.setWarningCallback(callback)
    presentation.save("presentation-font-warnings.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}

Para obtener más información sobre cómo recibir devoluciones de llamada para sustituciones de fuentes durante el proceso de renderizado, consulte [Getting Warning Callbacks for Fonts Substitution](/slides/es/python-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Para más información sobre sustitución de fuentes, vea el artículo [Font Substitution](/slides/es/python-java/font-substitution/).

{{% /alert %}}

## **Convertir diapositivas seleccionadas en PowerPoint a PDF**

Los números de diapositiva pasados a [Presentation.save](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#save) son basados en 1. Este ejemplo exporta las diapositivas 1 y 3 cuando ambas existen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    if presentation.getSlides().size() >= 3:
        slide_numbers = jpype.JArray(jpype.JInt)([1, 3])
        presentation.save("presentation-selected-slides.pdf", slide_numbers, SaveFormat.Pdf)
    else:
        print("The presentation must contain at least three slides.")
finally:
    presentation.dispose()
```

## **Convertir PowerPoint a PDF con tamaño de diapositiva personalizado**

Este ejemplo exporta la primera diapositiva en una página de 612 × 792 puntos (US Letter). Clona la diapositiva en una nueva presentación con el tamaño especificado:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation("presentation.pptx")
try:
    resized_presentation = Presentation()
    try:
        resized_presentation.getSlideSize().setSize(612.0, 792.0, SlideSizeScaleType.EnsureFit)
        if presentation.getSlides().size() > 0:
            slide = presentation.getSlides().get_Item(0)
            resized_presentation.getSlides().insertClone(0, slide)
            resized_presentation.getSlides().removeAt(1)
            resized_presentation.save("presentation-custom-size.pdf", SaveFormat.Pdf)
        else:
            print("The presentation contains no slides.")
    finally:
        resized_presentation.dispose()
finally:
    presentation.dispose()
```

## **Convertir PowerPoint a PDF en vista de diapositivas de notas**

Este código demuestra cómo convertir una presentación de PowerPoint a un PDF que incluya notas:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)
    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(notes_options)
    presentation.save("presentation-with-notes.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

## **Accesibilidad y normas de cumplimiento para PDF**

Al crear PDFs accesibles, consulte las [Pautas de Accesibilidad al Contenido Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Use [PdfOptions.setCompliance](https://reference.aspose.com/slides/es/python-java/aspose.slides/pdfoptions/#setCompliance) para seleccionar un estándar de salida: **PDF/A1a**, **PDF/A1b** y **PDF/UA**.

Este código muestra un proceso de conversión de PowerPoint a PDF que genera múltiples PDFs basados en diferentes normas de cumplimiento:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setCompliance(PdfCompliance.PdfA1a)
    presentation.save("presentation-a1a.pdf", SaveFormat.Pdf, pdf_options)
    pdf_options.setCompliance(PdfCompliance.PdfA1b)
    presentation.save("presentation-a1b.pdf", SaveFormat.Pdf, pdf_options)
    pdf_options.setCompliance(PdfCompliance.PdfUa)
    presentation.save("presentation-ua.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

> **Nota:** Al exportar a PDF/UA, Aspose.Slides trata gráficos complejos como SmartArt, diagramas y fórmulas como una única figura. Los elementos de ruta individuales no se conservan como contenido independiente y pueden marcarse como artefactos; el texto alternativo se proporciona solo para la figura completa.

## **Preguntas frecuentes**

**¿Puedo convertir varios archivos de PowerPoint a PDF en bloque?**

Sí, Aspose.Slides soporta la conversión por lotes de varios archivos PPT o PPTX a PDF. Puede iterar sobre sus archivos y aplicar el proceso de conversión programáticamente.

**¿Es posible proteger con contraseña el PDF convertido?**

Sí. Use la clase [PdfOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/pdfoptions/) para establecer una contraseña y definir permisos de acceso durante el proceso de conversión.

**¿Cómo incluyo diapositivas ocultas en el PDF?**

Utilice el método [setShowHiddenSlides](https://reference.aspose.com/slides/es/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) en la clase [PdfOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/pdfoptions/) para incluir diapositivas ocultas en el PDF resultante.

**¿Aspose.Slides mantiene alta calidad de imagen en el PDF?**

Sí, puede controlar la calidad de imagen usando métodos como [setJpegQuality](https://reference.aspose.com/slides/es/python-java/aspose.slides/pdfoptions/#setJpegQuality) y [setSufficientResolution](https://reference.aspose.com/slides/es/python-java/aspose.slides/pdfoptions/#setSufficientResolution) en la clase [PdfOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/pdfoptions/) para garantizar imágenes de alta calidad en su PDF.

**¿Aspose.Slides soporta normas de cumplimiento PDF/A?**

Sí, Aspose.Slides le permite exportar PDFs que cumplen con [varias normas](https://reference.aspose.com/slides/es/python-java/aspose.slides/pdfcompliance/), incluidas PDF/A1a, PDF/A1b y PDF/UA, para accesibilidad o archivado. Elija la norma adecuada y revise la salida según sus requisitos.

## **Recursos adicionales**

- [Aspose.Slides for Python via Java Documentation](/slides/es/python-java/)
- [Aspose.Slides for Python via Java API Reference](https://reference.aspose.com/slides/es/python-java/)
- [Conversores en línea gratuitos de Aspose](https://products.aspose.app/slides/es/conversion)