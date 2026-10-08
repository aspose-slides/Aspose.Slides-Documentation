---
title: Convertir PPT y PPTX a PDF en Python vía Java [Funciones avanzadas incluidas]
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
- adjunto
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Java
- Aspose.Slides
description: "Convertir PowerPoint PPT/PPTX a PDFs de alta calidad y buscables en Python vía Java usando Aspose.Slides, con ejemplos de código rápidos y opciones de conversión avanzadas."
---
## **Visión general**

Convertir presentaciones de PowerPoint (PPT, PPTX, ODP, etc.) a formato PDF en Python mediante Java ofrece varias ventajas, incluida la compatibilidad entre diferentes dispositivos y la preservación del diseño y formato de su presentación. Esta guía muestra cómo convertir presentaciones a documentos PDF, usar distintas opciones para controlar la calidad de la imagen, incluir diapositivas ocultas, proteger con contraseña los archivos PDF, detectar sustituciones de fuentes, seleccionar diapositivas específicas para la conversión y aplicar normas de cumplimiento a los documentos de salida.

## **Conversiones de PowerPoint a PDF**

Con Aspose.Slides, puede convertir presentaciones en los siguientes formatos a PDF:

* **PPT**
* **PPTX**
* **ODP**

Para convertir una presentación a PDF, pase el nombre del archivo como argumento a la clase [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) y luego guarde la presentación como PDF usando el método [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save). La clase [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) expone el método [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) que se usa normalmente para convertir una presentación a PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java inserta la información de su API y el número de versión en los documentos de salida. Por ejemplo, al convertir una presentación a PDF, Aspose.Slides rellena el campo Application con "*Aspose.Slides*" y el campo PDF Producer con un valor del tipo "*Aspose.Slides v XX.XX*". **Nota** que no puede indicar a Aspose.Slides que cambie o elimine esta información de los documentos de salida.
{{% /alert %}}

Aspose.Slides permite convertir:

* Presentaciones completas a PDF
* Diapositivas específicas de una presentación a PDF

Aspose.Slides exporta presentaciones a PDF, asegurando que los PDF resultantes coincidan estrechamente con las presentaciones originales. Los elementos y atributos se renderizan con precisión en la conversión, incluidos:

* Imágenes
* Cuadros de texto y formas
* Formato de texto
* Formato de párrafo
* Hipervínculos
* Encabezados y pies de página
* Viñetas
* Tablas

## **Convertir PowerPoint a PDF**

La conversión estándar usa la configuración de exportación PDF predeterminada. Use opciones personalizadas cuando necesite controlar la calidad de la imagen, el contenido de la página o el cumplimiento del PDF.

Instale [Aspose.Slides for Python via Java](/slides/es/python-java/installation/) y un tiempo de ejecución Java compatible antes de ejecutar los ejemplos. Cada ejemplo lee `presentation.pptx` del directorio de trabajo actual; reemplácelo con su archivo PPT, PPTX o ODP. Inicie la JVM una vez por proceso de Python.

El siguiente ejemplo carga una presentación y guarda todas las diapositivas visibles en PDF usando la configuración de exportación predeterminada.

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
Aspose ofrece un [**Convertidor de PowerPoint a PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) en línea gratuito que muestra el proceso de conversión de presentación a PDF. Puede ejecutar una prueba con este conversor para una implementación real del procedimiento descrito aquí.
{{% /alert %}}

## **Convertir PowerPoint a PDF con Opciones**

Aspose.Slides proporciona opciones personalizadas—propiedades bajo la clase [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/)—que le permiten personalizar el PDF resultante, bloquear el PDF con una contraseña o especificar cómo debe proceder el proceso de conversión.

### **Convertir PowerPoint a PDF con Opciones Personalizadas**

Usando opciones de conversión personalizadas, puede definir su configuración de calidad preferida para imágenes raster, especificar cómo deben manejarse los metafiles, establecer un nivel de compresión para el texto, configurar DPI para las imágenes y más.

El siguiente ejemplo exporta una presentación a PDF 1.5 con calidad JPEG establecida en 90, resolución de imagen a 300 DPI, metafiles guardados como PNG y compresión de texto Flate.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, PdfTextCompression, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setJpegQuality(jpype.JByte(90))
pdf_options.setSufficientResolution(300)
pdf_options.setSaveMetafilesAsPng(True)
pdf_options.setTextCompression(PdfTextCompression.Flate)
pdf_options.setCompliance(PdfCompliance.Pdf15)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-custom.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Conservar Archivos OLE Incorporados como Adjuntos PDF**

Si una presentación contiene un libro de Excel incrustado, puede querer que los destinatarios del PDF accedan a los datos del libro además de ver las diapositivas. Llame a [setIncludeOleData](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setIncludeOleData) con `True` para conservar los archivos OLE incrustados como adjuntos en el PDF resultante.

El valor predeterminado es `False`: la imagen de vista previa o el ícono del objeto OLE se renderiza en la página del PDF, pero su archivo incrustado no se incluye como adjunto. Establecer la opción a `True` incluye también los datos del archivo. La vista previa sigue siendo una representación visual; el adjunto permite a los destinatarios abrir o guardar el archivo incrustado por separado. El objeto OLE no se convierte en una hoja de cálculo interactiva en la página del PDF.

El siguiente ejemplo carga una presentación que ya contiene un libro de Excel incrustado y lo exporta a PDF con el libro adjunto.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setIncludeOleData(True)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

Para comprobar el resultado:

1. Abra el PDF exportado en un visor que admita archivos adjuntos, como Adobe Acrobat Reader.
2. Abra el panel de **Adjuntos** del visor y localice el libro incrustado.
3. Guarde el adjunto y ábralo en Excel para inspeccionar sus datos, o ábralo directamente si el visor lo permite. La vista previa en la página del PDF es independiente del adjunto.

{{% alert color="info" title="Note" %}}
Las normas PDF/A imponen restricciones sobre los adjuntos: PDF/A-1 prohíbe archivos incrustados, PDF/A-2 permite solo adjuntos PDF/A, y PDF/A-3 permite otros tipos de archivo, incluidos libros de Excel. Estos son requisitos de las normas, no limitaciones específicas de Aspose.Slides. Este ejemplo usa la configuración de cumplimiento PDF predeterminada y no demuestra la exportación PDF/A.
{{% /alert %}}

### **Convertir PowerPoint a PDF con Diapositivas Ocultas**

Si una presentación contiene diapositivas ocultas, puede usar el método [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) de la clase [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) para incluir las diapositivas ocultas como páginas en el PDF resultante.

El siguiente ejemplo exporta una presentación a PDF, incluyendo cualquier diapositiva oculta.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setShowHiddenSlides(True)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-hidden-slides.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Convertir PowerPoint a un PDF Protegido con Contraseña**

El siguiente ejemplo exporta una presentación a un PDF que requiere la contraseña `password` para abrirse. Los permisos de acceso permiten la impresión, incluida la impresión de alta calidad.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfAccessPermissions, PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setPassword("password")
pdf_options.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-protected.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Detectar Sustituciones de Fuentes**

Aspose.Slides proporciona el método [setWarningCallback](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setWarningCallback) bajo la clase [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) que permite detectar sustituciones de fuentes durante el proceso de conversión de presentación a PDF.

El siguiente ejemplo exporta una presentación a PDF e imprime advertencias de sustitución de fuentes en la consola. Solo se imprime una advertencia cuando una fuente no disponible se sustituye durante la exportación. Use un proxy JPype para recibir callbacks de advertencia de la API Java. Convierta la cadena de descripción de Java a una cadena de Python antes de comprobar su prefijo:

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


handler = FontSubstitutionHandler()
callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)

pdf_options = PdfOptions()
pdf_options.setWarningCallback(callback)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-font-warnings.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Para obtener más información sobre sustitución de fuentes, consulte el artículo [Sustitución de fuentes](/slides/es/python-java/font-substitution/).
{{% /alert %}}

### **Manejar Fuentes sin una Variante Negrita dedicada**

Una presentación puede aplicar formato negrita a texto aun cuando su fuente no tenga una variante negrita dedicada. El texto puede aparecer negrita mediante negrita sintética, que engrosa artificialmente los glifos normales. Cuando ese texto parece demasiado grueso o difiere de la apariencia prevista en el PDF, pruebe a llamar a [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles) con `True`. Esta opción renderiza el texto afectado como un mapa de bits durante la exportación PDF y puede mejorar su apariencia para ciertas fuentes. Su valor predeterminado es `False`.

La presentación de ejemplo contiene dos cuadros de texto: uno con texto normal y otro con formato negrita aplicado a la misma fuente, que no tiene variante negrita dedicada. El siguiente ejemplo carga la presentación, habilita la rasterización de estilos de fuente no compatibles y la exporta a PDF:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setRasterizeUnsupportedFontStyles(True)

presentation = Presentation("unsupported-bold.pptx")
try:
    presentation.save("rasterized.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

Las siguientes vistas previas muestran la salida desactivada y la salida activada. En este ejemplo, el texto en negrita tiene trazos más gruesos con la opción desactivada. Con la opción activada, sus trazos son más ligeros; el texto normal permanece sin cambios. Compare los resultados antes de elegir la configuración para su presentación.

| Opción desactivada (`False`, predeterminado) | Opción activada (`True`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

En este ejemplo, habilitar la opción convierte solo el texto en negrita en un mapa de bits: no se puede seleccionar, copiar ni buscar como texto sin OCR, y sus bordes aparecen más suaves al 800 % de zoom. El texto normal sigue siendo buscable. Con la opción desactivada, ambas cadenas permanecen como texto.

Esta opción rasteriza el texto formateado como negrita cuando su fuente no tiene una variante negrita dedicada. [Sustitución de fuentes](/slides/es/python-java/font-substitution/) en su lugar selecciona otra fuente cuando la original no está disponible.

## **Convertir Diapositivas Seleccionadas de PowerPoint a PDF**

Los números de diapositiva pasados a [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) son basados en 1. Este ejemplo exporta las diapositivas 1 y 3 cuando ambas existen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide_numbers = jpype.JArray(jpype.JInt)([1, 3])
    presentation.save("presentation-selected-slides.pdf", slide_numbers, SaveFormat.Pdf)
finally:
    presentation.dispose()
```

## **Convertir PowerPoint a PDF con Tamaño de Diapositiva Personalizado**

Este ejemplo exporta la primera diapositiva en una página de 612 × 792 puntos (Carta EE. UU.). Clona la diapositiva en una nueva presentación con el tamaño especificado y escala el contenido de la diapositiva para ajustarlo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation("presentation.pptx")
resized_presentation = Presentation()
try:
    resized_presentation.getSlideSize().setSize(612, 792, SlideSizeScaleType.EnsureFit)
    slide = presentation.getSlides().get_Item(0)
    resized_presentation.getSlides().insertClone(0, slide)

    # Eliminar la diapositiva en blanco con la que se creó la nueva presentación.
    resized_presentation.getSlides().removeAt(1)

    resized_presentation.save("presentation-custom-size.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
    resized_presentation.dispose()
```

## **Convertir PowerPoint a PDF en Vista de Notas de Diapositiva**

El siguiente ejemplo exporta una presentación a PDF, colocando las notas del orador de cada diapositiva debajo de la diapositiva. Use una presentación que contenga notas del orador para ver el resultado.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

notes_options = NotesCommentsLayoutingOptions()
notes_options.setNotesPosition(NotesPositions.BottomFull)

pdf_options = PdfOptions()
pdf_options.setSlidesLayoutOptions(notes_options)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-with-notes.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

## **Normas de Accesibilidad y Cumplimiento para PDF**

Al preparar PDFs accesibles, consulte las [Directrices de accesibilidad de contenido web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Use [PdfOptions.setCompliance](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setCompliance) para seleccionar un estándar de salida: **PDF/A1a**, **PDF/A1b** y **PDF/UA**.

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

> **Nota:** Al exportar a PDF/UA, Aspose.Slides trata los gráficos complejos como SmartArt, diagramas y fórmulas como una única figura. Los elementos de ruta individuales no se conservan como contenido separado y pueden marcarse como artefactos; el texto alternativo se proporciona solo para la figura completa.

## **Preguntas frecuentes**

**¿Puedo convertir varios archivos PowerPoint a PDF de forma masiva?**

Sí, Aspose.Slides admite la conversión por lotes de varios archivos PPT o PPTX a PDF. Puede iterar sobre sus archivos y aplicar el proceso de conversión programáticamente.

**¿Es posible proteger con contraseña el PDF convertido?**

Sí. Use la clase [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) para establecer una contraseña y definir los permisos de acceso durante el proceso de conversión.

**¿Cómo incluyo diapositivas ocultas en el PDF?**

Llame a [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) con `True` en la clase [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) para incluir las diapositivas ocultas en el PDF resultante.

**¿Aspose.Slides mantiene alta calidad de imagen en el PDF?**

Sí, puede controlar la calidad de imagen usando métodos como [setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setJpegQuality) y [setSufficientResolution](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setSufficientResolution) en la clase [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) para garantizar imágenes de alta calidad en su PDF.

**¿Aspose.Slides admite normas de cumplimiento PDF/A?**

Sí, Aspose.Slides le permite exportar PDFs que cumplen con [varios estándares](https://reference.aspose.com/slides/python-java/aspose.slides/pdfcompliance/), incluidos PDF/A1a, PDF/A1b y PDF/UA, para accesibilidad o archivado. Elija el estándar apropiado y revise la salida según sus requisitos.

## **Recursos adicionales**

- [Aspose.Slides for Python via Java Documentation](/slides/es/python-java/)
- [Aspose.Slides for Python via Java API Reference](https://reference.aspose.com/slides/python-java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)