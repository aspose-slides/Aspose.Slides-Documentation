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
- adjunto
- PDF/A1a
- PDF/A1b
- PDF/UA
- .NET
- C#
- Aspose.Slides
description: "Convierte presentaciones PowerPoint PPT/PPTX a PDFs de alta calidad y con capacidad de búsqueda en .NET usando Aspose.Slides, con ejemplos de código C# rápidos y opciones de conversión avanzadas."
---
## **Visión general**

Convertir presentaciones de PowerPoint (PPT, PPTX, ODP, etc.) a formato PDF en C# ofrece varias ventajas, incluida la compatibilidad entre diferentes dispositivos y la preservación del diseño y formato de su presentación. Esta guía muestra cómo convertir presentaciones a documentos PDF, usar diversas opciones para controlar la calidad de imagen, incluir diapositivas ocultas, proteger con contraseña los archivos PDF, detectar sustituciones de fuentes, seleccionar diapositivas específicas para la conversión y aplicar normas de cumplimiento a los documentos de salida.

## **Conversiones de PowerPoint a PDF**

Con Aspose.Slides, puede convertir presentaciones de los siguientes formatos a PDF:

* **PPT**
* **PPTX**
* **ODP**

Para convertir una presentación a PDF, pase el nombre del archivo como argumento a la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) y luego guarde la presentación como PDF usando el método [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). La clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) expone el método [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) que normalmente se utiliza para convertir una presentación a PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides para .NET inserta su información de API y número de versión en los documentos de salida. Por ejemplo, al convertir una presentación a PDF, Aspose.Slides completa el campo Application con "*Aspose.Slides*" y el campo PDF Producer con un valor en forma "*Aspose.Slides v XX.XX*". **Nota** que no puede indicar a Aspose.Slides que cambie o elimine esta información de los documentos de salida.
{{% /alert %}}

Aspose.Slides le permite convertir:

* Presentaciones completas a PDF
* Diapositivas específicas de una presentación a PDF

Aspose.Slides exporta presentaciones a PDF, asegurando que los PDF resultantes coincidan estrechamente con las presentaciones originales. Los elementos y atributos se renderizan con precisión en la conversión, incluyendo:

* Imágenes
* Cuadros de texto y formas
* Formato de texto
* Formato de párrafo
* Hipervínculos
* Encabezados y pies de página
* Viñetas
* Tablas

## **Convertir PowerPoint a PDF**

El proceso estándar de conversión de PowerPoint a PDF utiliza opciones predeterminadas. En este caso, Aspose.Slides intenta convertir la presentación proporcionada a PDF usando ajustes óptimos al nivel máximo de calidad.

El siguiente ejemplo carga una presentación y guarda todas las diapositivas visibles en PDF usando la configuración de exportación predeterminada.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.ppt");
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{% alert color="info" title="Note" %}}
Aspose ofrece un [**convertidor de PowerPoint a PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) en línea gratuito que muestra el proceso de conversión de presentación a PDF. Puede ejecutar una prueba con este convertidor para una implementación en vivo del procedimiento descrito aquí.
{{% /alert %}}

## **Convertir PowerPoint a PDF con opciones**

Aspose.Slides proporciona opciones personalizadas —propiedades bajo la clase [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)— que le permiten personalizar el PDF resultante, bloquear el PDF con una contraseña o especificar cómo debe proceder el proceso de conversión.

### **Convertir PowerPoint a PDF con opciones personalizadas**

Con opciones de conversión personalizadas, puede definir su configuración de calidad preferida para imágenes rasterizadas, especificar cómo deben manejarse los metafiles, establecer un nivel de compresión para el texto, configurar DPI para imágenes y más.

El siguiente ejemplo exporta una presentación a PDF 1.5 con la calidad JPEG ajustada a 90, la resolución de imagen establecida en 300 DPI, los metafiles guardados como PNG y compresión de texto Flate.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions
{
    JpegQuality = 90,
    SufficientResolution = 300,
    SaveMetafilesAsPng = true,
    TextCompression = PdfTextCompression.Flate,
    Compliance = PdfCompliance.Pdf15
};

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Conservar archivos OLE incrustados como adjuntos PDF**

Si una presentación contiene un libro de Excel incrustado, es posible que desee que los destinatarios del PDF accedan a los datos del libro además de ver las diapositivas. Establezca [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) a `true` para conservar los archivos OLE incrustados como adjuntos en el PDF resultante.

El valor predeterminado es `false`: la imagen de vista previa o el icono del objeto OLE se renderiza en la página PDF, pero su archivo incrustado no se incluye como adjunto. Establecer la opción a `true` incluye adicionalmente los datos del archivo. La vista previa sigue siendo una representación visual; el adjunto permite a los destinatarios abrir o guardar el archivo incrustado por separado. El objeto OLE no se convierte en una hoja de cálculo Excel interactiva en la página PDF.

El siguiente ejemplo carga una presentación que ya contiene un libro de Excel incrustado y lo exporta a PDF con el libro adjunto.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { IncludeOleData = true };

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
```

Para comprobar el resultado:

1. Abra el PDF exportado en un visor que admita archivos adjuntos, como Adobe Acrobat Reader.
2. Abra el panel **Adjuntos** del visor y localice el libro incrustado.
3. Guarde el adjunto y ábralo en Excel para inspeccionar sus datos, o ábralo directamente si el visor lo permite. La vista previa en la página PDF es distinta del adjunto.

{{% alert color="info" title="Note" %}}
Las normas PDF/A impiden ciertos adjuntos: PDF/A-1 prohíbe los archivos incrustados, PDF/A-2 permite sólo adjuntos PDF/A, y PDF/A-3 permite otros tipos de archivo, incluidos los libros de Excel. Estos son requisitos de las normas, no restricciones específicas de Aspose.Slides. Este ejemplo usa la configuración de cumplimiento PDF predeterminada y no muestra la exportación PDF/A.
{{% /alert %}}

### **Convertir PowerPoint a PDF con diapositivas ocultas**

Si una presentación contiene diapositivas ocultas, puede usar la propiedad [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) de la clase [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) para incluir las diapositivas ocultas como páginas en el PDF resultante.

El siguiente ejemplo exporta una presentación a PDF, incluyendo cualquier diapositiva oculta.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.ShowHiddenSlides = true;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Convertir PowerPoint a un PDF protegido con contraseña**

El siguiente ejemplo exporta una presentación a un PDF que requiere la contraseña `password` para abrirse. Los permisos de acceso permiten la impresión, incluida la impresión de alta calidad.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Detectar sustituciones de fuentes**

Aspose.Slides proporciona la propiedad [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) bajo la clase [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), lo que le permite detectar sustituciones de fuentes durante el proceso de conversión de presentación a PDF.

El siguiente ejemplo exporta una presentación a PDF e imprime advertencias de sustitución de fuentes en la consola. Solo se imprime una advertencia cuando una fuente no disponible es sustituida durante la exportación.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;
using System;

var pdfOptions = new PdfOptions();
pdfOptions.WarningCallback = new FontSubstitutionHandler();

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);

class FontSubstitutionHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss && warning.Description.StartsWith("Font will be substituted"))
        {
            Console.WriteLine($"Font substitution warning: {warning.Description}");
        }

        return ReturnAction.Continue;
    }
}
```

{{% alert color="info" title="Note" %}}
Para obtener más información sobre la sustitución de fuentes, consulte el artículo [Sustitución de fuentes](/slides/es/net/font-substitution/).
{{% /alert %}} 

## **Convertir diapositivas seleccionadas de PowerPoint a PDF**

El siguiente ejemplo exporta las diapositivas 1 y 3 de una presentación a PDF. Los números de diapositiva en este arreglo comienzan en uno, y la presentación de entrada debe contener al menos tres diapositivas.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.pptx");
var slides = new[] { 1, 3 };
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **Convertir PowerPoint a PDF con tamaño de diapositiva personalizado**

El siguiente ejemplo copia la primera diapositiva de una presentación a una nueva presentación con un tamaño de diapositiva de 612 × 792 puntos (8,5 × 11 pulgadas). Escala el contenido de la diapositiva para ajustarlo y exporta la única diapositiva a PDF.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var slideWidth = 612;
var slideHeight = 792;

using var presentation = new Presentation("SelectedSlides.pptx");
using var resizedPresentation = new Presentation();

resizedPresentation.SlideSize.SetSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);
var slide = presentation.Slides[0];
resizedPresentation.Slides.InsertClone(0, slide);

// Remove the blank slide that the new presentation was created with.
resizedPresentation.Slides.RemoveAt(1);
resizedPresentation.Save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
```

## **Convertir PowerPoint a PDF en vista de notas**

El siguiente ejemplo exporta una presentación a PDF, colocando las notas del ponente de cada diapositiva debajo de la misma. Utilice una presentación que contenga notas del ponente para ver el resultado.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    }
};

using var presentation = new Presentation("NotesFile.pptx");
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```

## **Estándares de accesibilidad y cumplimiento para PDF**

Aspose.Slides le permite utilizar un procedimiento de conversión que cumple con las [Directrices de Accesibilidad al Contenido Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Puede exportar un documento PowerPoint a PDF usando cualquiera de estos estándares de cumplimiento: **PDF/A1a**, **PDF/A1b** y **PDF/UA**.

Este código C# demuestra un proceso de conversión de PowerPoint a PDF que produce múltiples PDFs basados en diferentes estándares de cumplimiento:

```csharp
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

{{% alert color="info" title="Note" %}}
Aspose.Slides admite operaciones de conversión de PDF, permitiendo convertir archivos PDF a formatos de archivo populares. Puede realizar conversiones de [PDF a HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/), [PDF a imagen](https://products.aspose.com/slides/net/conversion/pdf-to-image/), [PDF a JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/), y [PDF a PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/). Otras operaciones de conversión de PDF a formatos especializados —[PDF a SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/), [PDF a TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/), y [PDF a XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/)— también son compatibles.
{{% /alert %}}

> **Nota:** Al exportar a PDF/UA, Aspose.Slides trata los gráficos complejos como SmartArt, diagramas y fórmulas como una única figura. Los elementos de ruta individuales no se conservan como contenido separado y pueden marcarse como artefactos; el texto alternativo se proporciona sólo para la figura completa.

## **Preguntas frecuentes**

**¿Puedo convertir varios archivos PowerPoint a PDF en lote?**

Sí, Aspose.Slides admite la conversión por lotes de varios archivos PPT o PPTX a PDF. Puede iterar sobre sus archivos y aplicar el proceso de conversión mediante código.

**¿Es posible proteger con contraseña el PDF convertido?**

Sí. Utilice la clase [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) para establecer una contraseña y definir los permisos de acceso durante el proceso de conversión.

**¿Cómo incluyo diapositivas ocultas en el PDF?**

Establezca la propiedad [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) en la clase [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) a `true` para incluir diapositivas ocultas en el PDF resultante.

**¿Puede Aspose.Slides mantener alta calidad de imagen en el PDF?**

Sí, puede controlar la calidad de imagen estableciendo propiedades como [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) y [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) en la clase [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) para garantizar imágenes de alta calidad en su PDF.

**¿Aspose.Slides admite los estándares de cumplimiento PDF/A?**

Sí, Aspose.Slides le permite exportar PDFs que cumplen con varios estándares, incluidos PDF/A1a, PDF/A1b y PDF/UA, garantizando que sus documentos cumplan con los requisitos de accesibilidad y archivo.

## **Recursos adicionales**

- [Documentación de Aspose.Slides para .NET](/slides/es/net/)
- [Referencia de API de Aspose.Slides para .NET](https://reference.aspose.com/slides/net/)
- [Convertidores en línea gratuitos de Aspose](https://products.aspose.app/slides/conversion)