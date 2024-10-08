---
title: Convertir PowerPoint a PDF en Java
linktitle: Convertir PowerPoint a PDF
type: docs
weight: 40
url: /es/androidjava/convert-powerpoint-to-pdf/
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
- Java
- Aspose.Slides para Android a través de Java
description: "Convierte presentaciones de PowerPoint a PDF en Java. Guarda PowerPoint como PDF cumpliendo con normas de accesibilidad."
---

## **Descripción general**

Convertir documentos de PowerPoint a formato PDF ofrece varias ventajas, incluyendo asegurar la compatibilidad entre diferentes dispositivos y preservar el diseño y formato de tu presentación. Este artículo te muestra cómo convertir presentaciones a documentos PDF, utilizar varias opciones para controlar la calidad de la imagen, incluir diapositivas ocultas, proteger con contraseña documentos PDF, detectar sustituciones de fuentes, seleccionar diapositivas para conversión y aplicar estándares de cumplimiento a los documentos de salida.

## **Conversiones de PowerPoint a PDF**

Usando Aspose.Slides, puedes convertir presentaciones en estos formatos a PDF:

* PPT
* PPTX
* ODP

Para convertir una presentación a PDF, simplemente tienes que pasar el nombre del archivo como argumento en la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) y luego guardar la presentación como un PDF usando un método [Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-). La clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) expone el método [Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) que se utiliza comúnmente para convertir una presentación a PDF.

{{%  alert title="NOTA"  color="warning"   %}} 

Aspose.Slides para Android a través de Java escribe directamente información de la API y el número de versión en los documentos de salida. Por ejemplo, cuando convierte una presentación a PDF, Aspose.Slides para Android a través de Java llena el campo Application con el valor '*Aspose.Slides*' y el campo PDF Producer con un valor en forma de '*Aspose.Slides v XX.XX*'. **Nota** que no puedes instruir a Aspose.Slides para Android a través de Java para cambiar o eliminar esta información de los documentos de salida.

{{% /alert %}}

Aspose.Slides permite convertir:

* una presentación completa a PDF
* diapositivas específicas en una presentación a PDF
* una presentación 

Aspose.Slides exporta presentaciones a PDF de forma que el contenido de los PDFs resultantes sea muy similar al de las presentaciones originales. Estos elementos y atributos conocidos a menudo se renderizan correctamente en conversiones de presentación a PDF:

* imágenes
* cuadros de texto y otras formas
* textos y su formato
* párrafos y su formato
* hipervínculos
* encabezados y pies de página
* viñetas
* tablas

## **Convertir PowerPoint a PDF**

La operación estándar de conversión de PowerPoint a PDF se ejecuta utilizando opciones predeterminadas. En este caso, Aspose.Slides intenta convertir la presentación proporcionada a PDF utilizando configuraciones óptimas en los niveles de calidad máximos.

Este código Java te muestra cómo convertir un PowerPoint a PDF:

```java
// Instancia una clase Presentation que representa un archivo de PowerPoint
Presentation pres = new Presentation("PowerPoint.ppt");
try {
    // Guarda la presentación como un PDF
    pres.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert  color="primary"  %}} 

Aspose proporciona un [**convertidor de PowerPoint a PDF gratuito**](https://products.aspose.app/slides/conversion/ppt-to-pdf) que demuestra el proceso de conversión de presentación a PDF. Para una implementación en vivo del procedimiento descrito aquí, puedes hacer una prueba con el convertidor.

{{% /alert %}}

## **Convertir PowerPoint a PDF con opciones**

Aspose.Slides proporciona opciones personalizadas—propiedades bajo la clase [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PdfOptions)—que te permiten personalizar el PDF (resultante del proceso de conversión), bloquear el PDF con una contraseña, o incluso especificar cómo debería ser el proceso de conversión.

### **Convertir PowerPoint a PDF con opciones personalizadas**

Usando opciones de conversión personalizadas, puedes establecer tu configuración de calidad preferida para imágenes rasterizadas, especificar cómo se deben manejar los metafiles, establecer un nivel de compresión para los textos, establecer DPI para imágenes, etc.

El siguiente ejemplo de código demuestra una operación en la que una presentación de PowerPoint se convierte a PDF con varias opciones personalizadas:

```java
// Instancia la clase PdfOptions
PdfOptions pdfOptions = new PdfOptions();

// Establece la calidad para imágenes JPG
pdfOptions.setJpegQuality((byte)90);

// Establece DPI para imágenes
pdfOptions.setSufficientResolution(300);

// Establece el comportamiento para metafiles
pdfOptions.setSaveMetafilesAsPng(true);

// Establece el nivel de compresión de texto para contenido textual
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// Define el modo de cumplimiento de PDF
pdfOptions.setCompliance(PdfCompliance.Pdf15);

// Instancia la clase Presentation que representa un documento de PowerPoint
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Guarda la presentación como un documento PDF
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Convertir PowerPoint a PDF con diapositivas ocultas**

Si una presentación contiene diapositivas ocultas, puedes usar una opción personalizada—la propiedad [ShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPdfOptions#getShowHiddenSlides--) de la clase [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PdfOptions)—para instruir a Aspose.Slides a incluir las diapositivas ocultas como páginas en el PDF resultante.

Este código Java te muestra cómo convertir una presentación de PowerPoint a PDF con diapositivas ocultas incluidas:

```java
// Instancia una clase Presentation que representa un archivo de PowerPoint
Presentation pres = new Presentation("PowerPoint.pptx");
try {
    // Instancia la clase PdfOptions
    PdfOptions pdfOptions = new PdfOptions();
    
    // Agrega diapositivas ocultas
    pdfOptions.setShowHiddenSlides(true);
    
    // Guarda la presentación como un PDF
    pres.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Convertir PowerPoint a PDF protegido con contraseña**

Este código Java te muestra cómo convertir un PowerPoint a un PDF protegido con contraseña (usando parámetros de protección de la clase [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PdfOptions)):

```java
// Instancia un objeto Presentation que representa un archivo de PowerPoint
Presentation pres = new Presentation("PowerPoint.pptx");
try {
    // Instancia la clase PdfOptions
    PdfOptions pdfOptions = new PdfOptions();
    
    // Establece la contraseña del PDF y los permisos de acceso
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);
    
    // Guarda la presentación como un PDF
    pres.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Detectar sustituciones de fuentes**

Aspose.Slides proporciona el método [getWarningCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#getWarningCallback--) bajo la clase [SaveOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/) para permitirte detectar sustituciones de fuentes en el proceso de conversión de presentación a PDF.

Este código Java te muestra cómo detectar sustituciones de fuentes: 

```java
public void main(String[] args)
{
    LoadOptions loadOptions = new LoadOptions();
    FontSubstSendsWarningCallback warningCallback = new FontSubstSendsWarningCallback();
    loadOptions.setWarningCallback(warningCallback);

    Presentation pres = new Presentation("pres.pptx", loadOptions);
    try {
        
    } finally {
        if (pres != null) pres.dispose();
    }
}

private class FontSubstSendsWarningCallback implements IWarningCallback
{
    public int warning(IWarningInfo warning)
    {
        if (warning.getWarningType() == WarningType.CompatibilityIssue)
            return ReturnAction.Continue;

        if (warning.getWarningType() == WarningType.DataLoss &&
                warning.getDescription().startsWith("Font will be substituted"))
        {
            System.out.println("Advertencia de sustitución de fuente: " + warning.getDescription());
        }

        return ReturnAction.Continue;
    }
}
```

{{%  alert color="primary"  %}} 

Para más información sobre cómo obtener callbacks para sustituciones de fuentes en un proceso de renderizado, consulta [Obteniendo Callbacks de Advertencia para la Sustitución de Fuentes](https://docs.aspose.com/slides/androidjava/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Para más información sobre la sustitución de fuentes, consulta el artículo [Sustitución de Fuentes](https://docs.aspose.com/slides/androidjava/font-substitution/).

{{% /alert %}} 

## **Convertir diapositivas seleccionadas en PowerPoint a PDF**

Este código Java te muestra cómo convertir diapositivas específicas en una presentación de PowerPoint a PDF:

```java
// Instancia un objeto Presentation que representa un archivo de PowerPoint
Presentation pres = new Presentation("PowerPoint.pptx");
try {
    // Establece un array de posiciones de diapositivas
    int[] slides = { 1, 3 };
    
    // Guarda la presentación como un PDF
    pres.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Convertir PowerPoint a PDF con tamaño de diapositiva personalizado**

Este código Java te muestra cómo convertir un PowerPoint cuando su tamaño de diapositiva está especificado a un PDF:

```java
// Instancia un objeto Presentation que representa un archivo de PowerPoint 
Presentation pres = new Presentation("SelectedSlides.pptx");
try {
    Presentation outPres = new Presentation();
    try {
        ISlide slide = pres.getSlides().get_Item(0);

        outPres.getSlides().insertClone(0, slide);
        
        // Establece el tipo y tamaño de la diapositiva 
        outPres.getSlideSize().setSize(612F, 792F, SlideSizeScaleType.EnsureFit);
        
        PdfOptions pdfOptions = new PdfOptions();
        INotesCommentsLayoutingOptions options = pdfOptions.getNotesCommentsLayouting();
        options.setNotesPosition(NotesPositions.BottomFull);

        outPres.save("PDFnotes_out.pdf", SaveFormat.Pdf, pdfOptions);
    } finally {
        if (pres != null) pres.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Convertir PowerPoint a PDF en vista de notas**

Este código Java te muestra cómo convertir un PowerPoint a PDF con notas:

```java
// Instancia una clase Presentation que representa un archivo de PowerPoint
Presentation pres = new Presentation("SelectedSlides.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    INotesCommentsLayoutingOptions options = pdfOptions.getNotesCommentsLayouting();
    options.setNotesPosition(NotesPositions.BottomFull);

    pres.save("Pdf_With_Notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Normas de accesibilidad y cumplimiento para PDF**

Aspose.Slides te permite utilizar un procedimiento de conversión que cumple con [Directrices de Accesibilidad al Contenido Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Puedes exportar un documento de PowerPoint a PDF utilizando cualquiera de estos estándares de cumplimiento: **PDF/A1a**, **PDF/A1b**, y **PDF/UA**.

Este código Java demuestra una operación de conversión de PowerPoint a PDF en la que se obtienen múltiples PDFs basados en diferentes estándares de cumplimiento:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    
    pdfOptions.setCompliance(PdfCompliance.PdfA1a);
    pres.save("pres-a1a-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfA1b);
    pres.save("pres-a1b-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfUa);
    pres.save("pres-ua-compliance.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Nota" color="warning" %}} 

El soporte de Aspose.Slides para operaciones de conversión a PDF se extiende a permitirte convertir PDF a los formatos de archivo más populares. Puedes hacer conversiones de [PDF a HTML](https://products.aspose.com/slides/androidjava/conversion/pdf-to-html/), [PDF a imagen](https://products.aspose.com/slides/androidjava/conversion/pdf-to-image/), [PDF a JPG](https://products.aspose.com/slides/androidjava/conversion/pdf-to-jpg/), y [PDF a PNG](https://products.aspose.com/slides/androidjava/conversion/pdf-to-png/). Otras operaciones de conversión de PDF a formatos especializados—[PDF a SVG](https://products.aspose.com/slides/androidjava/conversion/pdf-to-svg/), [PDF a TIFF](https://products.aspose.com/slides/androidjava/conversion/pdf-to-tiff/), y [PDF a XML](https://products.aspose.com/slides/androidjava/conversion/pdf-to-xml/)—también están soportadas.

{{% /alert %}}