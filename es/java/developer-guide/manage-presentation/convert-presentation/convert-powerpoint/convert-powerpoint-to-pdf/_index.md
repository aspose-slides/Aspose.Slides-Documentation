---
title: Convertir PowerPoint a PDF en Java
linktitle: Convertir PowerPoint a PDF
type: docs
weight: 40
url: /java/convert-powerpoint-to-pdf/
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
- Aspose.Slides para Java
description: "Convierte presentaciones de PowerPoint a PDF en Java. Guarda PowerPoint como PDF con estándares de conformidad o accesibilidad."
---

## **Descripción general**

Convertir documentos de PowerPoint a formato PDF ofrece varias ventajas, incluida la garantía de compatibilidad a través de diferentes dispositivos y la preservación del diseño y formato de su presentación. Este artículo le muestra cómo convertir presentaciones a documentos PDF, utilizar varias opciones para controlar la calidad de la imagen, incluir diapositivas ocultas, proteger con contraseña los documentos PDF, detectar sustituciones de fuentes, seleccionar diapositivas para la conversión y aplicar estándares de conformidad a los documentos de salida.

## **Conversiones de PowerPoint a PDF**

Usando Aspose.Slides, puede convertir presentaciones en estos formatos a PDF:

* PPT
* PPTX
* ODP

Para convertir una presentación a PDF, simplemente tiene que pasar el nombre del archivo como un argumento en la clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) y luego guardar la presentación como un PDF usando un método [Save](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-). La clase [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) expone el método [Save](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-) que se utiliza generalmente para convertir una presentación a PDF.

{{%  alert title="NOTA"  color="warning"   %}} 

Aspose.Slides para Java escribe directamente información de la API y el número de versión en los documentos de salida. Por ejemplo, cuando convierte una presentación a PDF, Aspose.Slides para Java llena el campo de Aplicación con el valor '*Aspose.Slides*' y el campo de Productor PDF con un valor en forma de '*Aspose.Slides v XX.XX*'. **Nota** que no puede instruir a Aspose.Slides para Java a cambiar o eliminar esta información de los documentos de salida.

{{% /alert %}}

Aspose.Slides le permite convertir:

* toda una presentación a PDF
* diapositivas específicas en una presentación a PDF
* una presentación 

Aspose.Slides exporta presentaciones a PDF de una manera que hace que el contenido de los PDFs resultantes sea muy similar al de las presentaciones originales. Estos elementos y atributos conocidos a menudo se representan correctamente en las conversiones de presentación a PDF:

* imágenes
* cuadros de texto y otras formas
* textos y su formato
* párrafos y su formato
* hipervínculos
* encabezados y pies de página
* viñetas
* tablas

## **Convertir PowerPoint a PDF**

La operación estándar de conversión de PDF de PowerPoint se ejecuta utilizando opciones predeterminadas. En este caso, Aspose.Slides intenta convertir la presentación proporcionada a PDF utilizando configuraciones óptimas en los niveles de calidad máxima.

Este código de Java le muestra cómo convertir un PowerPoint a PDF:

```java
// Instancia una clase Presentation que representa un archivo de PowerPoint
Presentation pres = new Presentation("PowerPoint.ppt");
try {
    // Guarda la presentación como un PDF
    pres.save("PPT-a-PDF.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert  color="primary"  %}} 

Aspose proporciona un [**convertidor de PowerPoint a PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) en línea gratuito que demuestra el proceso de conversión de presentación a PDF. Para una implementación en vivo del procedimiento descrito aquí, puede realizar una prueba con el convertidor.

{{% /alert %}}

## **Convertir PowerPoint a PDF con Opciones**

Aspose.Slides proporciona opciones personalizadas—propiedades bajo la clase [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/PdfOptions)—que le permiten personalizar el PDF (resultante del proceso de conversión), bloquear el PDF con una contraseña o incluso especificar cómo debe llevarse a cabo el proceso de conversión.

### **Convertir PowerPoint a PDF con Opciones Personalizadas**

Usando opciones de conversión personalizadas, puede establecer su configuración de calidad preferida para imágenes rasterizadas, especificar cómo deben manejarse los metafiles, establecer un nivel de compresión para textos, establecer DPI para imágenes, etc.

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

// Define el modo de conformidad del PDF
pdfOptions.setCompliance(PdfCompliance.Pdf15);

// Instancia la clase Presentation que representa un documento de PowerPoint
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Guarda la presentación como un documento PDF
    presentation.save("PowerPoint-a-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Convertir PowerPoint a PDF con Diapositivas Ocultas**

Si una presentación contiene diapositivas ocultas, puede usar una opción personalizada—la propiedad [ShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/IPdfOptions#getShowHiddenSlides--) de la clase [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/PdfOptions)—para instruir a Aspose.Slides a incluir las diapositivas ocultas como páginas en el PDF resultante.

Este código de Java le muestra cómo convertir una presentación de PowerPoint a PDF con las diapositivas ocultas incluidas:

```java
// Instancia una clase Presentation que representa un archivo de PowerPoint
Presentation pres = new Presentation("PowerPoint.pptx");
try {
    // Instancia la clase PdfOptions
    PdfOptions pdfOptions = new PdfOptions();
    
    // Agrega diapositivas ocultas
    pdfOptions.setShowHiddenSlides(true);
    
    // Guarda la presentación como un PDF
    pres.save("PowerPoint-a-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Convertir PowerPoint a PDF Protegido con Contraseña**

Este código de Java le muestra cómo convertir un PowerPoint a un PDF protegido con contraseña (usando parámetros de protección de la clase [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/PdfOptions)):

```java
// Instancia un objeto Presentation que representa un archivo de PowerPoint
Presentation pres = new Presentation("PowerPoint.pptx");
try {
    // Instancia la clase PdfOptions
    PdfOptions pdfOptions = new PdfOptions();
    
    // Establece la contraseña del PDF y los permisos de acceso
    pdfOptions.setPassword("contraseña");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);
    
    // Guarda la presentación como un PDF
    pres.save("PPTX-a-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

### Detectar Sustituciones de Fuentes

Aspose.Slides proporciona el método [getWarningCallback](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#getWarningCallback--) bajo la clase [SaveOptions](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/) para permitirle detectar sustituciones de fuentes en el proceso de conversión de presentación a PDF. 

Este código de Java le muestra cómo detectar sustituciones de fuentes: 

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
                warning.getDescription().startsWith("La fuente será sustituida"))
        {
            System.out.println("Advertencia de sustitución de fuente: " + warning.getDescription());
        }

        return ReturnAction.Continue;
    }
}
```

{{%  alert color="primary"  %}} 

Para obtener más información sobre la obtención de callbacks para sustituciones de fuentes en un proceso de renderizado, consulte [Obtener Callbacks de Advertencia para la Sustitución de Fuentes](https://docs.aspose.com/slides/java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Para obtener más información sobre la sustitución de fuentes, consulte el artículo [Sustitución de Fuentes](https://docs.aspose.com/slides/java/font-substitution/).

{{% /alert %}} 

## **Convertir Diapositivas Seleccionadas en PowerPoint a PDF**

Este código de Java le muestra cómo convertir diapositivas específicas en una presentación de PowerPoint a PDF:

```java
// Instancia un objeto Presentation que representa un archivo de PowerPoint
Presentation pres = new Presentation("PowerPoint.pptx");
try {
    // Establece un array de posiciones de diapositivas
    int[] slides = { 1, 3 };
    
    // Guarda la presentación como un PDF
    pres.save("PPTX-a-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Convertir PowerPoint a PDF con Tamaño de Diapositiva Personalizado**

Este código de Java le muestra cómo convertir un PowerPoint cuando su tamaño de diapositiva está especificado a un PDF:

```java
// Instancia un objeto Presentation que representa un archivo de PowerPoint 
Presentation pres = new Presentation("DiapositivasSeleccionadas.pptx");
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

## **Convertir PowerPoint a PDF en Vista de Diapositivas con Notas**

Este código de Java le muestra cómo convertir un PowerPoint a PDF con notas:

```java
// Instancia una clase Presentation que representa un archivo de PowerPoint
Presentation pres = new Presentation("DiapositivasSeleccionadas.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    INotesCommentsLayoutingOptions options = pdfOptions.getNotesCommentsLayouting();
    options.setNotesPosition(NotesPositions.BottomFull);

    pres.save("Pdf_Con_Notas.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Estándares de Accesibilidad y Conformidad para PDF**

Aspose.Slides le permite utilizar un procedimiento de conversión que cumple con las [Pautas de Accesibilidad al Contenido Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Puede exportar un documento de PowerPoint a PDF utilizando cualquiera de estos estándares de conformidad: **PDF/A1a**, **PDF/A1b** y **PDF/UA**.

Este código de Java demuestra una operación de conversión de PowerPoint a PDF en la que se obtienen múltiples PDFs basados en diferentes estándares de conformidad:

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

El soporte de Aspose.Slides para operaciones de conversión a PDF se extiende a permitirle convertir PDF a los formatos de archivo más populares. Puede realizar conversiones de [PDF a HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF a imagen](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF a JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/) y [PDF a PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/). Otras operaciones de conversión de PDF a formatos especializados—[PDF a SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF a TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/) y [PDF a XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/)—también son compatibles.

{{% /alert %}}