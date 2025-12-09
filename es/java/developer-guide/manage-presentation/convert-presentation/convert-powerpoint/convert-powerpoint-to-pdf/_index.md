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
- PDF/A1a
- PDF/A1b
- PDF/UA
- Java
- Aspose.Slides
description: "Convertir presentaciones PowerPoint PPT/PPTX a PDFs de alta calidad y buscables en Java usando Aspose.Slides, con ejemplos de código rápidos y opciones de conversión avanzadas."
---

## **Resumen**

Convertir presentaciones de PowerPoint (PPT, PPTX, ODP, etc.) a formato PDF en Java ofrece varias ventajas, incluidas la compatibilidad entre diferentes dispositivos y la preservación del diseño y formato de su presentación. Esta guía muestra cómo convertir presentaciones a documentos PDF, usar diversas opciones para controlar la calidad de imagen, incluir diapositivas ocultas, proteger con contraseña los archivos PDF, detectar sustituciones de fuentes, seleccionar diapositivas específicas para la conversión y aplicar normas de cumplimiento a los documentos de salida.

## **Conversiones de PowerPoint a PDF**

Con Aspose.Slides, puede convertir presentaciones en los siguientes formatos a PDF:

* **PPT**
* **PPTX**
* **ODP**

Para convertir una presentación a PDF, pase el nombre del archivo como argumento a la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) y luego guarde la presentación como PDF usando un método `save`. La clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) expone el método `save` que se usa típicamente para convertir una presentación a PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Java inserta la información de su API y el número de versión en los documentos de salida. Por ejemplo, al convertir una presentación a PDF, Aspose.Slides completa el campo Application con "*Aspose.Slides*" y el campo PDF Producer con un valor del tipo "*Aspose.Slides v XX.XX*". **Note** que no puede instruir a Aspose.Slides para cambiar o eliminar esta información de los documentos de salida.

{{% /alert %}}

Aspose.Slides le permite convertir:

* Presentaciones completas a PDF
* Diapositivas específicas de una presentación a PDF

Aspose.Slides exporta presentaciones a PDF, asegurando que los PDFs resultantes coincidan estrechamente con las presentaciones originales. Los elementos y atributos se renderizan con precisión en la conversión, incluidos:

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

Este código muestra cómo convertir una presentación (PPT, PPTX, ODP, etc.) a PDF:
```java
// Instanciar la clase Presentation que representa un archivo PowerPoint u OpenDocument.
Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    // Guardar la presentación como PDF.
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```


{{%  alert  color="primary"  %}} 

Aspose ofrece un **convertidor gratuito en línea de PowerPoint a PDF**[https://products.aspose.app/slides/conversion/ppt-to-pdf] que muestra el proceso de conversión de presentación a PDF. Puede ejecutar una prueba con este convertidor para una implementación real del procedimiento descrito aquí.

{{% /alert %}}

## **Convertir PowerPoint a PDF con Opciones**

Aspose.Slides proporciona opciones personalizadas —propiedades bajo la clase [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/)— que le permiten personalizar el PDF resultante, bloquear el PDF con una contraseña o especificar cómo debe proceder el proceso de conversión.

### **Convertir PowerPoint a PDF con Opciones Personalizadas**

Usando opciones de conversión personalizadas, puede definir su configuración de calidad preferida para imágenes rasterizadas, especificar cómo se deben manejar los metaficheros, establecer un nivel de compresión para el texto, configurar DPI para imágenes y más.

El ejemplo de código a continuación muestra cómo convertir una presentación de PowerPoint a PDF con varias opciones personalizadas.
```java
// Instanciar la clase PdfOptions.
PdfOptions pdfOptions = new PdfOptions();

// Establecer la calidad para imágenes JPG.
pdfOptions.setJpegQuality((byte)90);

// Establecer DPI para imágenes.
pdfOptions.setSufficientResolution(300);

// Establecer el comportamiento para metaficheros.
pdfOptions.setSaveMetafilesAsPng(true);

// Establecer el nivel de compresión de texto para el contenido textual.
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// Definir el modo de cumplimiento PDF.
pdfOptions.setCompliance(PdfCompliance.Pdf15);

// Instanciar la clase Presentation que representa un archivo PowerPoint u OpenDocument file.
Presentation presentation = new Presentation("PowerPoint.pptx");

try {
    // Guardar la presentación como documento PDF.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


### **Convertir PowerPoint a PDF con Diapositivas Ocultas**

Si una presentación contiene diapositivas ocultas, puede usar el método [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) de la clase [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) para incluir las diapositivas ocultas como páginas en el PDF resultante.

Este código muestra cómo convertir una presentación de PowerPoint a PDF con las diapositivas ocultas incluidas:
```java
// Instanciar la clase Presentation que representa un archivo PowerPoint u OpenDocument.
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

Este código demuestra cómo convertir una presentación de PowerPoint en un PDF protegido con contraseña usando los parámetros de protección de la clase [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/):
```java
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

Aspose.Slides proporciona el método [setWarningCallback](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) bajo la clase [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/), lo que le permite detectar sustituciones de fuentes durante el proceso de conversión de presentación a PDF.

Este código muestra cómo detectar sustituciones de fuentes:
```java
public static void main(String[] args) {
    // Instanciar la clase Presentation que representa un archivo PowerPoint u OpenDocument.
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


{{%  alert color="primary"  %}} 

Para obtener más información sobre cómo recibir devoluciones de llamada para sustituciones de fuentes durante el proceso de renderizado, consulte [Getting Warning Callbacks for Fonts Substitution](/slides/es/java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Para más información sobre sustitución de fuentes, vea el artículo [Font Substitution](/slides/es/java/font-substitution/).

{{% /alert %}} 

## **Convertir Diapositivas Seleccionadas de PowerPoint a PDF**

Este código demuestra cómo convertir solo diapositivas específicas de una presentación de PowerPoint a PDF:
```java
// Instanciar la clase Presentation que representa un archivo PowerPoint u OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Establecer arreglo de números de diapositivas.
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
float slideWidth = 612;
float slideHeight = 792;

// Instanciar la clase Presentation que representa un archivo PowerPoint u OpenDocument.
Presentation presentation = new Presentation("SelectedSlides.pptx");

// Crear una nueva presentación con un tamaño de diapositiva ajustado.
Presentation resizedPresentation = new Presentation();

try {
    // Establecer el tamaño de diapositiva personalizado.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);
    
    // Clonar la primera diapositiva de la presentación original.
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Guardar la presentación redimensionada en un PDF con notas.
    resizedPresentation.save("PDF_with_notes.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```


## **Convertir PowerPoint a PDF en Vista de Diapositiva de Notas**

Este código demuestra cómo convertir una presentación de PowerPoint a un PDF que incluya notas:
```java
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


## **Accesibilidad y Normas de Cumplimiento para PDF**

Aspose.Slides le permite usar un procedimiento de conversión que cumple con las [Directrices de Accesibilidad al Contenido Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Puede exportar un documento de PowerPoint a PDF usando cualquiera de estas normas de cumplimiento: **PDF/A1a**, **PDF/A1b** y **PDF/UA**.

Este código demuestra un proceso de conversión de PowerPoint a PDF que genera varios PDFs basados en diferentes normas de cumplimiento:
```java
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

Aspose.Slides admite operaciones de conversión a PDF, lo que le permite convertir archivos PDF a formatos de archivo populares. Puede realizar conversiones de [PDF a HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF a imagen](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF a JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/), y [PDF a PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/). Otras operaciones de conversión de PDF a formatos especializados —[PDF a SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF a TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/), y [PDF a XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/)— también son compatibles.

{{% /alert %}}

## **Preguntas Frecuentes**

1. **¿Puedo convertir varios archivos de PowerPoint a PDF de forma masiva?**

Sí, Aspose.Slides admite la conversión por lotes de múltiples archivos PPT o PPTX a PDF. Puede iterar a través de sus archivos y aplicar el proceso de conversión programáticamente.

2. **¿Es posible proteger con contraseña el PDF convertido?**

Absolutamente. Use la clase [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) para establecer una contraseña y definir permisos de acceso durante el proceso de conversión.

3. **¿Cómo incluyo diapositivas ocultas en el PDF?**

Utilice el método `setShowHiddenSlides` en la clase [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) para incluir las diapositivas ocultas en el PDF resultante.

4. **¿Puede Aspose.Slides mantener alta calidad de imagen en el PDF?**

Sí, puede controlar la calidad de imagen usando métodos como `setJpegQuality` y `setSufficientResolution` en la clase [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) para asegurar imágenes de alta calidad en su PDF.

5. **¿Aspose.Slides admite normas de cumplimiento PDF/A?**

Sí, Aspose.Slides le permite exportar PDFs que cumplan con diversas normas, incluidas PDF/A1a, PDF/A1b y PDF/UA, garantizando que sus documentos cumplan con requisitos de accesibilidad y archivado.

## **Recursos Adicionales**

- [Documentación de Aspose.Slides para Java](/slides/es/java/)
- [Referencia de API de Aspose.Slides para Java](https://reference.aspose.com/slides/java/)
- [Convertidores En Línea Gratuitos de Aspose](https://products.aspose.app/slides/conversion)