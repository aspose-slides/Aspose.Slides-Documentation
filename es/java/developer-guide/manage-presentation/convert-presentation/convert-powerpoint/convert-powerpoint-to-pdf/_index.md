---
title: Convertir PPT y PPTX a PDF en Java [Funciones avanzadas incluidas]
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
- PDF/A1a
- PDF/A1b
- PDF/UA
- Java
- Aspose.Slides
description: "Convertir PowerPoint PPT/PPTX a PDFs de alta calidad y buscables en Java con Aspose.Slides, con ejemplos de código rápidos y opciones de conversión avanzadas."
---
## **Visión general**

Convertir presentaciones de PowerPoint (PPT, PPTX, ODP, etc.) a formato PDF en Java ofrece varias ventajas, entre ellas la compatibilidad con diferentes dispositivos y la preservación del diseño y formato de su presentación. Esta guía muestra cómo convertir presentaciones a documentos PDF, usar diversas opciones para controlar la calidad de imagen, incluir diapositivas ocultas, proteger con contraseña los archivos PDF, detectar sustituciones de fuentes, seleccionar diapositivas específicas para la conversión y aplicar normas de cumplimiento a los documentos de salida.

## **Conversiones de PowerPoint a PDF**

Con Aspose.Slides, puede convertir presentaciones en los siguientes formatos a PDF:

* **PPT**
* **PPTX**
* **ODP**

Para convertir una presentación a PDF, pase el nombre del archivo como argumento a la clase [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/) y luego guarde la presentación como PDF usando el método `save`. La clase [Presentation](https://reference.aspose.com/slides/es/java/com.aspose.slides/presentation/) expone el método `save` que normalmente se utiliza para convertir una presentación a PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Java inserta la información de su API y el número de versión en los documentos de salida. Por ejemplo, al convertir una presentación a PDF, Aspose.Slides completa el campo Application con "*Aspose.Slides*" y el campo PDF Producer con un valor en forma "*Aspose.Slides v XX.XX*". **Note** que no puede instruir a Aspose.Slides para que cambie o elimine esta información de los documentos de salida.

{{% /alert %}}

Aspose.Slides le permite convertir:

* Presentaciones completas a PDF
* Diapositivas específicas de una presentación a PDF

Aspose.Slides exporta presentaciones a PDF, garantizando que los PDFs resultantes coincidan estrechamente con las presentaciones originales. Los elementos y atributos se representan con precisión en la conversión, incluyendo:

* Imágenes
* Cuadros de texto y formas
* Formato de texto
* Formato de párrafo
* Hipervínculos
* Encabezados y pies de página
* Viñetas
* Tablas

## **Convertir PowerPoint a PDF**

El proceso estándar de conversión de PowerPoint a PDF utiliza opciones predeterminadas. En este caso, Aspose.Slides intenta convertir la presentación proporcionada a PDF usando configuraciones óptimas en los niveles máximos de calidad.

Este código muestra cómo convertir una presentación (PPT, PPTX, ODP, etc.) a PDF:

```java
import com.aspose.slides.*;

// Instanciar la clase Presentation que representa un archivo PowerPoint o OpenDocument.
Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    // Guardar la presentación como PDF.
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{%  alert  color="info"  %}} 

Aspose ofrece un [**convertidor de PowerPoint a PDF**](https://products.aspose.app/slides/es/conversion/ppt-to-pdf) gratuito en línea que demuestra el proceso de conversión de presentación a PDF. Puede probar este conversor para una implementación en directo del procedimiento descrito aquí.

{{% /alert %}}

## **Convertir PowerPoint a PDF con Opciones**

Aspose.Slides proporciona opciones personalizadas—propiedades bajo la clase [PdfOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/pdfoptions/)—que le permiten personalizar el PDF resultante, bloquear el PDF con una contraseña o especificar cómo debe proceder el proceso de conversión.

### **Convertir PowerPoint a PDF con Opciones Personalizadas**

Con opciones de conversión personalizadas, puede definir la configuración de calidad preferida para imágenes raster, especificar cómo se deben manejar los metarchivos, establecer un nivel de compresión para el texto, configurar DPI para imágenes y más.

El siguiente ejemplo de código demuestra cómo convertir una presentación de PowerPoint a PDF con varias opciones personalizadas.

```java
import com.aspose.slides.*;

// Instanciar la clase PdfOptions.
PdfOptions pdfOptions = new PdfOptions();

// Establecer la calidad de las imágenes JPG.
pdfOptions.setJpegQuality((byte)90);

// Establecer DPI para las imágenes.
pdfOptions.setSufficientResolution(300);

// Establecer el comportamiento de los metarchivos.
pdfOptions.setSaveMetafilesAsPng(true);

// Establecer el nivel de compresión de texto para el contenido textual.
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// Definir el modo de cumplimiento PDF.
pdfOptions.setCompliance(PdfCompliance.Pdf15);

// Instanciar la clase Presentation que representa un archivo PowerPoint o OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");

try {
    // Guardar la presentación como documento PDF.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Convertir PowerPoint a PDF con Diapositivas Ocultas**

Si una presentación contiene diapositivas ocultas, puede usar el método [setShowHiddenSlides](https://reference.aspose.com/slides/es/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) de la clase [PdfOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/pdfoptions/) para incluir las diapositivas ocultas como páginas en el PDF resultante.

Este código muestra cómo convertir una presentación de PowerPoint a PDF con diapositivas ocultas incluidas:

```java
import com.aspose.slides.*;

// Instanciar la clase Presentation que representa un archivo PowerPoint o OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Instanciar la clase PdfOptions.
    PdfOptions pdfOptions = new PdfOptions();

    // Añadir diapositivas ocultas.
    pdfOptions.setShowHiddenSlides(true);

    // Guardar la presentación como PDF.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Convertir PowerPoint a PDF Protegido con Contraseña**

Este código demuestra cómo convertir una presentación de PowerPoint en un PDF protegido con contraseña usando los parámetros de protección de la clase [PdfOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/pdfoptions/):

```java
import com.aspose.slides.*;

// Instanciar la clase Presentation que representa un archivo PowerPoint o OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Instanciar la clase PdfOptions.
    PdfOptions pdfOptions = new PdfOptions();

    // Establecer una contraseña PDF y permisos de acceso.
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    // Guardar la presentación como PDF.
    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Detectar Sustituciones de Fuentes**

Aspose.Slides proporciona el método [setWarningCallback](https://reference.aspose.com/slides/es/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) bajo la clase [PdfOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/pdfoptions/), lo que le permite detectar sustituciones de fuentes durante el proceso de conversión de presentación a PDF.

Este código muestra cómo detectar sustituciones de fuentes:

```java
import com.aspose.slides.*;

public static void main(String[] args) {
    // Instanciar la clase Presentation que representa un archivo PowerPoint o OpenDocument.
    Presentation presentation = new Presentation("sample.pptx");

    // Establecer la devolución de llamada de advertencia en las opciones PDF.
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setWarningCallback(new FontSubstitutionHandler());

    try {
        // Guardar la presentación como PDF.
        presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
    } finally {
        presentation.dispose();
    }
}

// Implementación de la devolución de llamada de advertencia.
private static class FontSubstitutionHandler implements IWarningCallback {
    public int warning(IWarningInfo warning) {
        if (warning.getWarningType() == WarningType.DataLoss &&
                warning.getDescription().startsWith("Font will be substituted")) {
            System.out.println("Font substitution warning: " + warning.getDescription());
        }

        return ReturnAction.Continue;
    }
}
```

{{%  alert color="info"  %}} 

Para obtener más información sobre cómo recibir devoluciones de llamada de sustitución de fuentes durante el proceso de renderizado, consulte [Obtención de devoluciones de llamada de advertencia para la sustitución de fuentes](/slides/es/java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Para más información sobre sustitución de fuentes, vea el artículo [Sustitución de fuentes](/slides/es/java/font-substitution/).

{{% /alert %}} 

## **Convertir Diapositivas Seleccionadas de PowerPoint a PDF**

Este código demuestra cómo convertir solo diapositivas específicas de una presentación de PowerPoint a PDF:

```java
import com.aspose.slides.*;

// Instanciar la clase Presentation que representa un archivo PowerPoint o OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Establecer la matriz de números de diapositivas.
    int[] slides = { 1, 3 };

    // Guardar la presentación como PDF.
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **Convertir PowerPoint a PDF con Tamaño de Diapositiva Personalizado**

Este código demuestra cómo convertir una presentación de PowerPoint a PDF con un tamaño de diapositiva especificado:

```java
import com.aspose.slides.*;

float slideWidth = 612;
float slideHeight = 792;

// Instanciar la clase Presentation que representa un archivo PowerPoint o OpenDocument.
Presentation presentation = new Presentation("SelectedSlides.pptx");

// Crear una nueva presentación con un tamaño de diapositiva ajustado.
Presentation resizedPresentation = new Presentation();

try {
    // Establecer el tamaño de diapositiva personalizado.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);
    
    // Clonar la primera diapositiva de la presentación original.
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Eliminar la diapositiva vacía con la que se creó la nueva presentación.
    resizedPresentation.getSlides().removeAt(1);

    // Guardar la presentación redimensionada como PDF.
    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Convertir PowerPoint a PDF en Vista de Notas de Diapositiva**

Este código demuestra cómo convertir una presentación de PowerPoint a un PDF que incluye notas:

```java
import com.aspose.slides.*;

// Instanciar la clase Presentation que representa un archivo PowerPoint o OpenDocument.
Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    // Configurar las opciones PDF con diseño de notas.
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // Guardar la presentación en un PDF con notas.
    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **Estándares de Accesibilidad y Cumplimiento para PDF**

Aspose.Slides le permite utilizar un procedimiento de conversión que cumple con las [Directrices de Accesibilidad al Contenido Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Puede exportar un documento de PowerPoint a PDF utilizando cualquiera de estos estándares de cumplimiento: **PDF/A1a**, **PDF/A1b** y **PDF/UA**.

Este código demuestra un proceso de conversión de PowerPoint a PDF que produce múltiples PDFs basados en diferentes estándares de cumplimiento:

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

{{% alert title="Note" color="warning" %}} 

Aspose.Slides admite operaciones de conversión de PDF, lo que le permite convertir archivos PDF a formatos de archivo populares. Puede realizar conversiones de [PDF a HTML](https://products.aspose.com/slides/es/java/conversion/pdf-to-html/), [PDF a imagen](https://products.aspose.com/slides/es/java/conversion/pdf-to-image/), [PDF a JPG](https://products.aspose.com/slides/es/java/conversion/pdf-to-jpg/) y [PDF a PNG](https://products.aspose.com/slides/es/java/conversion/pdf-to-png/). Otras operaciones de conversión de PDF a formatos especializados—[PDF a SVG](https://products.aspose.com/slides/es/java/conversion/pdf-to-svg/), [PDF a TIFF](https://products.aspose.com/slides/es/java/conversion/pdf-to-tiff/), y [PDF a XML](https://products.aspose.com/slides/es/java/conversion/pdf-to-xml/)—también son compatibles.

{{% /alert %}}

> **Note:** Al exportar a PDF/UA, Aspose.Slides trata los gráficos complejos como SmartArt, gráficos y fórmulas como una única figura. Los elementos de ruta individuales no se conservan como contenido separado y pueden marcarse como artefactos; el texto alternativo se proporciona solo para la figura completa.

## **Preguntas frecuentes**

### ¿Puedo convertir varios archivos PowerPoint a PDF en lote?

Sí, Aspose.Slides admite la conversión por lotes de varios archivos PPT o PPTX a PDF. Puede iterar a través de sus archivos y aplicar el proceso de conversión programáticamente.

### ¿Es posible proteger con contraseña el PDF convertido?

Por supuesto. Utilice la clase [PdfOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/pdfoptions/) para establecer una contraseña y definir permisos de acceso durante el proceso de conversión.

### ¿Cómo incluyo diapositivas ocultas en el PDF?

Use el método `setShowHiddenSlides` en la clase [PdfOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/pdfoptions/) para incluir las diapositivas ocultas en el PDF resultante.

### ¿Puede Aspose.Slides mantener alta calidad de imagen en el PDF?

Sí, puede controlar la calidad de imagen mediante métodos como `setJpegQuality` y `setSufficientResolution` en la clase [PdfOptions](https://reference.aspose.com/slides/es/java/com.aspose.slides/pdfoptions/) para garantizar imágenes de alta calidad en su PDF.

### ¿Aspose.Slides admite los estándares de cumplimiento PDF/A?

Sí, Aspose.Slides le permite exportar PDFs que cumplen con [varios estándares](https://reference.aspose.com/slides/es/java/com.aspose.slides/pdfcompliance/), incluidos PDF/A1a, PDF/A1b y PDF/UA, asegurando que sus documentos cumplan con los requisitos de accesibilidad y archivo.

## **Recursos adicionales**

- [Documentación de Aspose.Slides para Java](/slides/es/java/)
- [Referencia de API de Aspose.Slides para Java](https://reference.aspose.com/slides/es/java/)
- [Convertidores en línea gratuitos de Aspose](https://products.aspose.app/slides/es/conversion)