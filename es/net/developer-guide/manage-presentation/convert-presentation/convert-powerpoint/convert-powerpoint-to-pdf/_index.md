---
title: Convertir PPT y PPTX a PDF en .NET [Características avanzadas incluidas]
linktitle: PowerPoint a PDF
type: docs
weight: 40
url: /es/net/convert-powerpoint-to-pdf/
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
- .NET
- C#
- Aspose.Slides
description: "Convertir PowerPoint PPT/PPTX a PDF de alta calidad y buscables en .NET usando Aspose.Slides, con ejemplos de código C# rápidos y opciones avanzadas de conversión."
---
## **Visión general**

Convertir presentaciones de PowerPoint (PPT, PPTX, ODP, etc.) a formato PDF en C# ofrece varias ventajas, entre ellas la compatibilidad con distintos dispositivos y la conservación del diseño y formato de la presentación. Esta guía muestra cómo convertir presentaciones a documentos PDF, usar distintas opciones para controlar la calidad de imagen, incluir diapositivas ocultas, proteger con contraseña los archivos PDF, detectar sustituciones de fuentes, seleccionar diapositivas concretas para la conversión y aplicar normas de cumplimiento a los documentos resultantes.

## **Conversiones de PowerPoint a PDF**

Con Aspose.Slides, puedes convertir presentaciones de los siguientes formatos a PDF:

* **PPT**
* **PPTX**
* **ODP**

Para convertir una presentación a PDF, pasa el nombre del archivo como argumento a la clase [Presentación](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/) y luego guarda la presentación como PDF mediante el método [Guardar](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/save/). La clase [Presentación](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/) expone el método [Guardar](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/save/) que normalmente se utiliza para convertir una presentación a PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for .NET inserta la información de su API y el número de versión en los documentos de salida. Por ejemplo, al convertir una presentación a PDF, Aspose.Slides rellena el campo Application con "*Aspose.Slides*" y el campo PDF Producer con un valor en formato "*Aspose.Slides v XX.XX*". **Nota** de que no puedes indicar a Aspose.Slides que cambie o elimine esta información de los documentos de salida.

{{% /alert %}}

Aspose.Slides permite convertir:

* Presentaciones completas a PDF
* Diapositivas específicas de una presentación a PDF

Aspose.Slides exporta presentaciones a PDF, garantizando que los PDF resultantes coincidan estrechamente con las presentaciones originales. Los elementos y atributos se renderizan con precisión en la conversión, incluidos:

* Imágenes
* Cuadros de texto y formas
* Formato de texto
* Formato de párrafo
* Hipervínculos
* Cabeceras y pies de página
* Viñetas
* Tablas

## **Convertir PowerPoint a PDF**

El proceso estándar de conversión de PowerPoint a PDF usa opciones predeterminadas. En este caso, Aspose.Slides intenta convertir la presentación proporcionada a PDF utilizando configuraciones óptimas en los niveles máximos de calidad.

Este código C# muestra cómo convertir una presentación (PPT, PPTX, ODP, etc.) a PDF:

```c#
using Aspose.Slides;
using Aspise.Slides.Export;

// Instanciar la clase Presentation que representa un archivo PowerPoint u OpenDocument.
using var presentation = new Presentation("PowerPoint.ppt");

// Guardar la presentación como PDF.
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{%  alert  color="info"  %}} 

Aspose ofrece un [**convertidor online gratuito de PowerPoint a PDF**](https://products.aspose.app/slides/es/conversion/ppt-to-pdf) que muestra el proceso de conversión de presentación a PDF. Puedes probar este convertidor para ver una implementación en directo del procedimiento descrito aquí.

{{% /alert %}}

## **Convertir PowerPoint a PDF con opciones**

Aspose.Slides proporciona opciones personalizadas—propiedades bajo la clase [PdfOptions](https://reference.aspose.com/slides/es/net/aspose.slides.export/pdfoptions/)—que permiten personalizar el PDF resultante, bloquearlo con una contraseña o especificar cómo debe proceder el proceso de conversión.

### **Convertir PowerPoint a PDF con opciones personalizadas**

Con opciones de conversión personalizadas, puedes definir la configuración de calidad preferida para imágenes raster, especificar cómo se deben manejar los metarchivos, establecer un nivel de compresión para el texto, configurar DPI para imágenes y mucho más.

El siguiente ejemplo de código muestra cómo convertir una presentación de PowerPoint a PDF con varias opciones personalizadas.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanciar la clase PdfOptions.
var pdfOptions = new PdfOptions
{
    // Establecer la calidad para imágenes JPG.
    JpegQuality = 90,

    // Establecer DPI para imágenes.
    SufficientResolution = 300,

    // Definir el comportamiento de los metarchivos.
    SaveMetafilesAsPng = true,

    // Establecer el nivel de compresión de texto para contenido textual.
    TextCompression = PdfTextCompression.Flate,

    // Definir el modo de cumplimiento PDF.
    Compliance = PdfCompliance.Pdf15
};

// Instanciar la clase Presentation que representa un archivo PowerPoint u OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// Guardar la presentación como documento PDF.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Convertir PowerPoint a PDF con diapositivas ocultas**

Si una presentación contiene diapositivas ocultas, puedes usar la propiedad [ShowHiddenSlides](https://reference.aspose.com/slides/es/net/aspose.slides.export/pdfoptions/showhiddenslides/) de la clase [PdfOptions](https://reference.aspose.com/slides/es/net/aspose.slides.export/pdfoptions/) para incluir las diapositivas ocultas como páginas en el PDF resultante.

Este código C# muestra cómo convertir una presentación de PowerPoint a PDF incluyendo las diapositivas ocultas:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanciar la clase Presentation que representa un archivo PowerPoint u OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// Instanciar la clase PdfOptions.
var pdfOptions = new PdfOptions();

// Añadir diapositivas ocultas.
pdfOptions.ShowHiddenSlides = true;

// Guardar la presentación como PDF.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Convertir PowerPoint a PDF protegido con contraseña**

Este código C# demuestra cómo convertir una presentación de PowerPoint en un PDF protegido con contraseña usando los parámetros de protección de la clase [PdfOptions](https://reference.aspose.com/slides/es/net/aspose.slides.export/pdfoptions/):

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanciar la clase Presentation que representa un archivo PowerPoint u OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// Instanciar la clase PdfOptions.
var pdfOptions = new PdfOptions();

// Establecer una contraseña PDF y permisos de acceso.
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

// Guardar la presentación como PDF.
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Detectar sustituciones de fuentes**

Aspose.Slides ofrece la propiedad [WarningCallback](https://reference.aspose.com/slides/es/net/aspose.slides.export/saveoptions/warningcallback/) bajo la clase [PdfOptions](https://reference.aspose.com/slides/es/net/aspose.slides.export/pdfoptions/), que permite detectar sustituciones de fuentes durante el proceso de conversión de presentación a PDF.

Este código C# muestra cómo detectar sustituciones de fuentes:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;

public static void Main()
{
    // Instanciar la clase Presentation que representa un archivo PowerPoint u OpenDocument.
    using var presentation = new Presentation("sample.pptx");

    // Establecer la callback de advertencia en las opciones PDF.
    var pdfOptions = new PdfOptions();
    pdfOptions.WarningCallback = new FontSubstitutionHandler();

    // Guardar la presentación como PDF.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}

// Implementación de la callback de advertencia.
private class FontSubstitutionHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss &&
            warning.Description.StartsWith("Font will be substituted"))
        {
            Console.WriteLine($"Font substitution warning: {warning.Description}");
        }

        return ReturnAction.Continue;
    }
}
```

{{%  alert color="info"  %}} 

Para obtener más información sobre cómo recibir callbacks de sustitución de fuentes durante el proceso de renderizado, consulta [Obtención de callbacks de advertencia para sustitución de fuentes](/slides/es/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Para más información sobre sustitución de fuentes, consulta el artículo [Sustitución de fuentes](/slides/es/net/font-substitution/).

{{% /alert %}} 

## **Convertir diapositivas seleccionadas de PowerPoint a PDF**

Este código C# muestra cómo convertir únicamente diapositivas específicas de una presentación de PowerPoint a PDF:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanciar la clase Presentation que representa un archivo PowerPoint u OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// Establecer el array de números de diapositivas.
int[] slides = { 1, 3 };

// Guardar la presentación como PDF.
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **Convertir PowerPoint a PDF con tamaño de diapositiva personalizado**

Este código C# muestra cómo convertir una presentación de PowerPoint a PDF con un tamaño de diapositiva especificado:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

var slideWidth = 612;
var slideHeight = 792;

// Cargar una presentación PowerPoint.
using var presentation = new Presentation("SelectedSlides.pptx");

// Crear una nueva presentación con un tamaño de diapositiva ajustado.
using var resizedPresentation = new Presentation();

// Establecer el tamaño de diapositiva personalizado.
resizedPresentation.SlideSize.SetSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

// Clonar la primera diapositiva de la presentación original.
var slide = presentation.Slides[0];
resizedPresentation.Slides.InsertClone(0, slide);

// Eliminar la diapositiva en blanco con la que se creó la nueva presentación.
resizedPresentation.Slides.RemoveAt(1);

// Guardar la presentación redimensionada como PDF.
resizedPresentation.Save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
```

## **Convertir PowerPoint a PDF en vista de diapositiva de notas**

Este código C# muestra cómo convertir una presentación de PowerPoint a un PDF que incluye notas:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Cargar una presentación PowerPoint.
using var presentation = new Presentation("NotesFile.pptx");

// Configurar las opciones PDF con diseño de notas.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    }
};

// Guardar la presentación en un PDF con notas.
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```

## **Accesibilidad y normas de cumplimiento para PDF**

Aspose.Slides permite usar un procedimiento de conversión que cumple con las [Directrices de Accesibilidad al Contenido Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Puedes exportar un documento de PowerPoint a PDF utilizando cualquiera de estas normas de cumplimiento: **PDF/A1a**, **PDF/A1b** y **PDF/UA**.

Este código C# demuestra un proceso de conversión de PowerPoint a PDF que genera varios PDFs basados en diferentes normas de cumplimiento:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.Save("pres-a1a-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfA1a
});

presentation.Save("pres-a1b-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfA1b
});

presentation.Save("pres-ua-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfUa
});
```

{{% alert title="Note" color="warning" %}} 

Aspose.Slides admite operaciones de conversión a PDF, permitiendo convertir archivos PDF a formatos populares. Puedes realizar conversiones de [PDF a HTML](https://products.aspose.com/slides/es/net/conversion/pdf-to-html/), [PDF a imagen](https://products.aspose.com/slides/es/net/conversion/pdf-to-image/), [PDF a JPG](https://products.aspose.com/slides/es/net/conversion/pdf-to-jpg/), y [PDF a PNG](https://products.aspose.com/slides/es/net/conversion/pdf-to-png/). Otras operaciones de conversión de PDF a formatos especializados—[PDF a SVG](https://products.aspose.com/slides/es/net/conversion/pdf-to-svg/), [PDF a TIFF](https://products.aspose.com/slides/es/net/conversion/pdf-to-tiff/), y [PDF a XML](https://products.aspose.com/slides/es/net/conversion/pdf-to-xml/)—también están soportadas.

{{% /alert %}}

> **Nota:** Al exportar a PDF/UA, Aspose.Slides trata los gráficos complejos como SmartArt, cuadros y fórmulas como una única figura. Los elementos de ruta individuales no se conservan como contenido separado y pueden marcarse como artefactos; el texto alternativo se proporciona solo para la figura completa.

## **FAQ**

### ¿Puedo convertir varios archivos PowerPoint a PDF de forma masiva?

Sí, Aspose.Slides soporta la conversión por lotes de varios archivos PPT o PPTX a PDF. Puedes iterar sobre tus archivos y aplicar el proceso de conversión programáticamente.

### ¿Es posible proteger con contraseña el PDF convertido?

Absolutamente. Utiliza la clase [PdfOptions](https://reference.aspose.com/slides/es/net/aspose.slides.export/pdfoptions/) para establecer una contraseña y definir permisos de acceso durante el proceso de conversión.

### ¿Cómo incluyo las diapositivas ocultas en el PDF?

Establece la propiedad `ShowHiddenSlides` en la clase [PdfOptions](https://reference.aspose.com/slides/es/net/aspose.slides.export/pdfoptions/) a `true` para incluir las diapositivas ocultas en el PDF resultante.

### ¿Puede Aspose.Slides mantener alta calidad de imagen en el PDF?

Sí, puedes controlar la calidad de imagen configurando propiedades como `JpegQuality` y `SufficientResolution` en la clase [PdfOptions](https://reference.aspose.com/slides/es/net/aspose.slides.export/pdfoptions/) para garantizar imágenes de alta calidad en tu PDF.

### ¿Aspose.Slides admite normas de cumplimiento PDF/A?

Sí, Aspose.Slides permite exportar PDFs que cumplen con diversas normas, incluidas PDF/A1a, PDF/A1b y PDF/UA, asegurando que tus documentos cumplan con requisitos de accesibilidad y archivo.

## **Recursos adicionales**

- [Documentación de Aspose.Slides para .NET](/slides/es/net/)
- [Referencia API de Aspose.Slides para .NET](https://reference.aspose.com/slides/es/net/)
- [Convertidores online gratuitos de Aspose](https://products.aspose.app/slides/es/conversion)