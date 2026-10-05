---
title: Convertir PPT y PPTX a PDF en Java [Características avanzadas incluidas]
linktitle: PowerPoint a PDF
type: docs
weight: 40
url: /es/java/convert-powerpoint-to-pdf/
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
- Java
- Aspose.Slides
description: "Convierta PowerPoint PPT/PPTX a PDFs de alta calidad y buscables en Java usando Aspose.Slides, con ejemplos de código rápidos y opciones de conversión avanzadas."
---
## **Visión general**

Convertir presentaciones de PowerPoint (PPT, PPTX, ODP, etc.) a formato PDF en Java ofrece varias ventajas, incluida la compatibilidad entre diferentes dispositivos y la preservación del diseño y formato de su presentación. Esta guía muestra cómo convertir presentaciones a documentos PDF, usar distintas opciones para controlar la calidad de las imágenes, incluir diapositivas ocultas, proteger con contraseña los archivos PDF, detectar sustituciones de fuentes, seleccionar diapositivas específicas para la conversión y aplicar normas de cumplimiento a los documentos de salida.

## **Conversiones de PowerPoint a PDF**

Con Aspose.Slides, puedes convertir presentaciones en los siguientes formatos a PDF:

* **PPT**
* **PPTX**
* **ODP**

Para convertir una presentación a PDF, pase el nombre del archivo como argumento a la clase [Presentación](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) y luego guarde la presentación como PDF usando el método [guardar](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-). La clase [Presentación](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) expone el método [guardar](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) que normalmente se utiliza para convertir una presentación a PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides para Java inserta la información de su API y el número de versión en los documentos de salida. Por ejemplo, al convertir una presentación a PDF, Aspose.Slides completa el campo Application con "*Aspose.Slides*" y el campo PDF Producer con un valor en formato "*Aspose.Slides v XX.XX*". **Nota** que no puede indicar a Aspose.Slides que cambie o elimine esta información de los documentos de salida.
{{% /alert %}}

Permite convertir:

* Presentaciones completas a PDF
* Diapositivas específicas de una presentación a PDF

Exporta presentaciones a PDF, garantizando que los PDFs resultantes coincidan estrechamente con las presentaciones originales. Los elementos y atributos se renderizan con precisión en la conversión, incluyendo:

* Imágenes
* Cuadros de texto y formas
* Formato de texto
* Formato de párrafo
* Hipervínculos
* Encabezados y pies de página
* Viñetas
* Tablas

## **Convertir PowerPoint a PDF**

El proceso estándar de conversión de PowerPoint a PDF utiliza opciones predeterminadas. En este caso, Aspose.Slides intenta convertir la presentación proporcionada a PDF usando configuraciones óptimas con los niveles máximos de calidad.

El siguiente ejemplo carga una presentación y guarda todas las diapositivas visibles en PDF usando la configuración de exportación predeterminada.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose ofrece un convertidor online gratuito [**convertidor de PowerPoint a PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) que demuestra el proceso de conversión de presentación a PDF. Puede ejecutar una prueba con este convertidor para una implementación en vivo del procedimiento descrito aquí.
{{% /alert %}}

## **Convertir PowerPoint a PDF con opciones**

Aspose.Slides proporciona opciones personalizadas—propiedades de la clase [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/)—que le permiten personalizar el PDF resultante, bloquear el PDF con una contraseña o especificar cómo debe proceder el proceso de conversión.

### **Convertir PowerPoint a PDF con opciones personalizadas**

Con opciones de conversión personalizadas, puede definir su configuración de calidad preferida para imágenes rasterizadas, especificar cómo se deben manejar los metarchivos, establecer un nivel de compresión para el texto, configurar DPI para imágenes y más.

El siguiente ejemplo exporta una presentación a PDF 1.5 con la calidad JPEG establecida en 90, resolución de imagen a 300 DPI, metarchivos guardados como PNG y compresión de texto Flate.

```java
import com.aspose.slides.*;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setJpegQuality((byte)90);
pdfOptions.setSufficientResolution(300);
pdfOptions.setSaveMetafilesAsPng(true);
pdfOptions.setTextCompression(PdfTextCompression.Flate);
pdfOptions.setCompliance(PdfCompliance.Pdf15);

Presentation presentation = new Presentation("PowerPoint.pptx");

try {
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Conservar archivos OLE incrustados como adjuntos PDF**

Si una presentación contiene un libro de Excel incrustado, puede que desee que los destinatarios del PDF accedan a los datos del libro además de ver las diapositivas. Llame a [setIncludeOleData](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) con `true` para conservar los archivos OLE incrustados como adjuntos en el PDF resultante.

El valor predeterminado es `false`: la imagen de vista previa o el ícono del objeto OLE se renderiza en la página PDF, pero su archivo incrustado no se incluye como adjunto. Establecer la opción a `true` incluye adicionalmente los datos del archivo. La vista previa sigue siendo una representación visual; el adjunto permite a los destinatarios abrir o guardar el archivo incrustado por separado. El objeto OLE no se convierte en una hoja de cálculo Excel interactiva en la página PDF.

El siguiente ejemplo carga una presentación que ya contiene un libro de Excel incrustado y lo exporta a PDF con el libro adjunto.

```java
import com.aspose.slides.*;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setIncludeOleData(true);

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Para comprobar el resultado:

1. Abra el PDF exportado en un visor que admita archivos adjuntos, como Adobe Acrobat Reader.
2. Abra el panel **Adjuntos** del visor y localice el libro incrustado.
3. Guarde el adjunto y ábralo en Excel para inspeccionar sus datos, o ábralo directamente si el visor lo permite. La vista previa en la página PDF es separada del adjunto.

{{% alert color="info" title="Note" %}}
Los estándares PDF/A imponen restricciones sobre los adjuntos: PDF/A-1 prohíbe archivos incrustados, PDF/A-2 solo permite adjuntos PDF/A y PDF/A-3 permite otros tipos de archivo, incluidos los libros de Excel. Estas son exigencias de los estándares, no restricciones específicas de Aspose.Slides. Este ejemplo usa la configuración predeterminada de cumplimiento PDF y no muestra la exportación PDF/A.
{{% /alert %}}

### **Convertir PowerPoint a PDF con diapositivas ocultas**

Si una presentación contiene diapositivas ocultas, puede usar el método [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) de la clase [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) para incluir las diapositivas ocultas como páginas en el PDF resultante.

El siguiente ejemplo exporta una presentación a PDF, incluyendo cualquier diapositiva oculta.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setShowHiddenSlides(true);

    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Convertir PowerPoint a un PDF protegido con contraseña**

El siguiente ejemplo exporta una presentación a un PDF que requiere la contraseña `password` para abrirse. Los permisos de acceso permiten la impresión, incluida la impresión de alta calidad.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Detectar sustituciones de fuentes**

Aspose.Slides proporciona el método [setWarningCallback](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) bajo la clase [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/), que permite detectar sustituciones de fuentes durante el proceso de conversión de presentación a PDF.

El siguiente ejemplo exporta una presentación a PDF e imprime en la consola advertencias de sustitución de fuentes. Se muestra una advertencia solo cuando una fuente no disponible es sustituida durante la exportación.

```java
import com.aspose.slides.*;

class FontSubstitutionHandler implements IWarningCallback {
    public int warning(IWarningInfo warning) {
        if (warning.getWarningType() == WarningType.DataLoss && warning.getDescription().startsWith("Font will be substituted")) {
            System.out.println("Font substitution warning: " + warning.getDescription());
        }
        return ReturnAction.Continue;
    }
}

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setWarningCallback(new FontSubstitutionHandler());

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Para obtener más información sobre la sustitución de fuentes, consulte el artículo [Sustitución de fuentes](/slides/es/java/font-substitution/).
{{% /alert %}} 

## **Convertir diapositivas seleccionadas de PowerPoint a PDF**

El siguiente ejemplo exporta las diapositivas 1 y 3 de una presentación a PDF. Los números de diapositiva en esta matriz comienzan en uno, y la presentación de entrada debe contener al menos tres diapositivas.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    int[] slides = { 1, 3 };
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **Convertir PowerPoint a PDF con tamaño de diapositiva personalizado**

El siguiente ejemplo copia la primera diapositiva de una presentación a una nueva presentación con un tamaño de diapositiva de 612 × 792 puntos (8,5 × 11 pulgadas). Escala el contenido de la diapositiva para ajustarlo y exporta la diapositiva única a PDF.

```java
import com.aspose.slides.*;

float slideWidth = 612;
float slideHeight = 792;

Presentation presentation = new Presentation("SelectedSlides.pptx");
Presentation resizedPresentation = new Presentation();

try {
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);
    
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Eliminar la diapositiva vacía con la que se creó la nueva presentación.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Convertir PowerPoint a PDF en vista de notas de diapositiva**

El siguiente ejemplo exporta una presentación a PDF, colocando las notas del orador de cada diapositiva debajo de la misma. Utilice una presentación que contenga notas del orador para ver el resultado.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **Estándares de accesibilidad y cumplimiento para PDF**

Aspose.Slides permite usar un procedimiento de conversión que cumple con [Directrices de Accesibilidad de Contenido Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Puede exportar un documento PowerPoint a PDF usando cualquiera de estos estándares de cumplimiento: **PDF/A1a**, **PDF/A1b** y **PDF/UA**.

Este código demuestra un proceso de conversión de PowerPoint a PDF que genera múltiples PDFs basados en diferentes estándares de cumplimiento:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();

    pdfOptions.setCompliance(PdfCompliance.PdfA1a);
    presentation.save("pres-a1a-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfA1b);
    presentation.save("pres-a1b-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfUa);
    presentation.save("pres-ua-compliance.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose.Slides soporta operaciones de conversión de PDF, permitiéndole convertir archivos PDF a formatos de archivo populares. Puede realizar conversiones de [PDF a HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF a imagen](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF a JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/), y [PDF a PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/). Otras operaciones de conversión de PDF a formatos especializados—[PDF a SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF a TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/), y [PDF a XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/)—también son compatibles.
{{% /alert %}}

> **Nota:** Al exportar a PDF/UA, Aspose.Slides trata los gráficos complejos como SmartArt, diagramas y fórmulas como una única figura. Los elementos de ruta individuales no se conservan como contenido separado y pueden marcarse como artefactos; el texto alternativo se proporciona solo para la figura completa.

## **Preguntas frecuentes**

**¿Puedo convertir varios archivos PowerPoint a PDF en lote?**

Sí, Aspose.Slides admite la conversión por lotes de varios archivos PPT o PPTX a PDF. Puede iterar sobre sus archivos y aplicar el proceso de conversión mediante código.

**¿Es posible proteger con contraseña el PDF convertido?**

Sí. Utilice la clase [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) para establecer una contraseña y definir los permisos de acceso durante el proceso de conversión.

**¿Cómo incluyo diapositivas ocultas en el PDF?**

Utilice el método [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) con `true` en la clase [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) para incluir las diapositivas ocultas en el PDF resultante.

**¿Puede Aspose.Slides mantener alta calidad de imagen en el PDF?**

Sí, puede controlar la calidad de la imagen mediante métodos como [setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) y [setSufficientResolution](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) en la clase [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) para garantizar imágenes de alta calidad en su PDF.

**¿Aspose.Slides admite los estándares de cumplimiento PDF/A?**

Sí, Aspose.Slides le permite exportar PDFs que cumplen con [varios estándares](https://reference.aspose.com/slides/java/com.aspose.slides/pdfcompliance/), incluidos PDF/A1a, PDF/A1b y PDF/UA, garantizando que sus documentos cumplan con los requisitos de accesibilidad y archivo.

## **Recursos adicionales**

- [Documentación de Aspose.Slides para Java](/slides/es/java/)
- [Referencia API de Aspose.Slides para Java](https://reference.aspose.com/slides/java/)
- [Convertidores en línea gratuitos de Aspose](https://products.aspose.app/slides/conversion)