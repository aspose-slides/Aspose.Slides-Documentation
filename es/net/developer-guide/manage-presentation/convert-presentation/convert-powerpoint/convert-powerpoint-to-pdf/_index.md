---
title: Convertir PPT y PPTX a PDF en C# [Funciones avanzadas incluidas]
linktitle: Convertir PPT y PPTX a PDF
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
- ODP a PDF
- convertir ODP a PDF
- guardar PowerPoint como PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- C#
- Csharp
- .NET
- Aspose.Slides para .NET
description: "Aprenda cómo convertir presentaciones PPT, PPTX y ODP a PDF en C# o .NET usando Aspose.Slides. Implemente funciones avanzadas como protección con contraseña, normas de cumplimiento y opciones personalizadas para obtener documentos PDF de alta calidad y accesibles."
---

## **Visión general**

Convertir presentaciones de PowerPoint (PPT, PPTX, ODP, etc.) a formato PDF en C# ofrece varias ventajas, incluida la compatibilidad entre diferentes dispositivos y la preservación del diseño y formato de su presentación. Esta guía muestra cómo convertir presentaciones a documentos PDF, usar diversas opciones para controlar la calidad de imagen, incluir diapositivas ocultas, proteger con contraseña los archivos PDF, detectar sustituciones de fuentes, seleccionar diapositivas específicas para la conversión y aplicar normas de cumplimiento a los documentos de salida.

## **Conversiones de PowerPoint a PDF**

Con Aspose.Slides, puede convertir presentaciones en los siguientes formatos a PDF:

* **PPT**
* **PPTX**
* **ODP**

Para convertir una presentación a PDF, pase el nombre del archivo como argumento a la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) y luego guarde la presentación como PDF usando un método [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). La clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) expone el método [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) que se utiliza típicamente para convertir una presentación a PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides para .NET inserta la información de su API y el número de versión en los documentos de salida. Por ejemplo, al convertir una presentación a PDF, Aspose.Slides rellena el campo Application con "*Aspose.Slides*" y el campo PDF Producer con un valor en forma "*Aspose.Slides v XX.XX*". **Nota** que no puede indicarle a Aspose.Slides que cambie o elimine esta información de los documentos de salida.

{{% /alert %}}

Aspose.Slides le permite convertir:

* Presentaciones completas a PDF
* Diapositivas específicas de una presentación a PDF

Aspose.Slides exporta presentaciones a PDF, garantizando que los PDFs resultantes coincidan estrechamente con las presentaciones originales. Los elementos y atributos se renderizan con precisión en la conversión, incluyendo:

* Imágenes
* Cuadros de texto y formas
* Formato de texto
* Formato de párrafo
* Hipervínculos
* Encabezados y pies de página
* Viñetas
* Tablas

## **Convertir PowerPoint a PDF**

El proceso estándar de conversión de PowerPoint a PDF utiliza opciones predeterminadas. En este caso, Aspose.Slides intenta convertir la presentación proporcionada a PDF usando configuraciones óptimas al nivel máximo de calidad.

Este código C# le muestra cómo convertir una presentación (PPT, PPTX, ODP, etc.) a PDF:
```c#
// Instanciar la clase Presentation que representa un archivo PowerPoint u OpenDocument.
using var presentation = new Presentation("PowerPoint.ppt");

// Guardar la presentación como PDF.
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```


{{%  alert  color="primary"  %}} 

Aspose ofrece un convertidor gratuito en línea de PowerPoint a PDF [**convertidor de PowerPoint a PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) que demuestra el proceso de conversión de presentación a PDF. Puede ejecutar una prueba con este convertidor para una implementación en vivo del procedimiento descrito aquí.

{{% /alert %}}

## **Convertir PowerPoint a PDF con Opciones**

Aspose.Slides ofrece opciones personalizadas —propiedades bajo la clase [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)— que le permiten personalizar el PDF resultante, proteger el PDF con una contraseña o especificar cómo debe proceder el proceso de conversión.

### **Convertir PowerPoint a PDF con Opciones Personalizadas**

Utilizando opciones de conversión personalizadas, puede definir su configuración de calidad preferida para imágenes rasterizadas, especificar cómo deben manejarse los metarchivos, establecer un nivel de compresión para el texto, configurar DPI para las imágenes y más.

El ejemplo de código a continuación muestra cómo convertir una presentación de PowerPoint a PDF con varias opciones personalizadas.
```c#
 // Instanciar la clase PdfOptions.
 var pdfOptions = new PdfOptions
 {
     // Establecer la calidad para imágenes JPG.
     JpegQuality = 90,

     // Establecer DPI para imágenes.
     SufficientResolution = 300,

     // Establecer el comportamiento para metafiles.
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


### **Convertir PowerPoint a PDF con Diapositivas Ocultas**

Si una presentación contiene diapositivas ocultas, puede usar la propiedad [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) de la clase [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) para incluir las diapositivas ocultas como páginas en el PDF resultante.

Este código C# muestra cómo convertir una presentación de PowerPoint a PDF incluyendo diapositivas ocultas:
```c#
// Instanciar la clase Presentation que representa un archivo PowerPoint u OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// Instanciar la clase PdfOptions.
var pdfOptions = new PdfOptions();

// Agregar diapositivas ocultas.
pdfOptions.ShowHiddenSlides = true;

// Guardar la presentación como PDF.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```


### **Convertir PowerPoint a PDF Protegido con Contraseña**

Este código C# demuestra cómo convertir una presentación de PowerPoint en un PDF protegido con contraseña usando los parámetros de protección de la clase [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/):
```c#
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


### **Detectar Sustituciones de Fuentes**

Aspose.Slides ofrece la propiedad [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) bajo la clase [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), que permite detectar sustituciones de fuentes durante el proceso de conversión de presentación a PDF.

Este código C# muestra cómo detectar sustituciones de fuentes:
```c#
public static void Main()
{
    // Instanciar la clase Presentation que representa un archivo PowerPoint u OpenDocument.
    using var presentation = new Presentation("sample.pptx");

    // Establecer el callback de advertencia en las opciones PDF.
    var pdfOptions = new PdfOptions();
    pdfOptions.WarningCallback = new FontSubstitutionHandler();

    // Guardar la presentación como PDF.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}

// Implementación del callback de advertencia.
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


{{%  alert color="primary"  %}} 

Para obtener más información sobre cómo recibir callbacks para sustituciones de fuentes durante el proceso de renderizado, consulte [Getting Warning Callbacks for Fonts Substitution](/slides/es/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Para obtener más información sobre la sustitución de fuentes, consulte el artículo [Font Substitution](/slides/es/net/font-substitution/).

{{% /alert %}} 

## **Convertir Diapositivas Seleccionadas de PowerPoint a PDF**

Este código C# demuestra cómo convertir solo diapositivas específicas de una presentación de PowerPoint a PDF:
```c#
// Instanciar la clase Presentation que representa un archivo PowerPoint o OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// Establecer la matriz de números de diapositivas.
int[] slides = { 1, 3 };

// Guardar la presentación como PDF.
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```


## **Convertir PowerPoint a PDF con Tamaño de Diapositiva Personalizado**

Este código C# demuestra cómo convertir una presentación de PowerPoint a PDF con un tamaño de diapositiva especificado:
```c#
var slideWidth = 612;
var slideHeight = 792;

// Cargar una presentación de PowerPoint.
using var presentation = new Presentation("SelectedSlides.pptx");

// Crear una nueva presentación con un tamaño de diapositiva ajustado.
using var resizedPresentation = new Presentation();

// Establecer el tamaño de diapositiva personalizado.
resizedPresentation.SlideSize.SetSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

// Clonar la primera diapositiva de la presentación original.
var slide = presentation.Slides[0];
resizedPresentation.Slides.InsertClone(0, slide);

// Guardar la presentación redimensionada en un PDF con notas.
resizedPresentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf);
```


## **Convertir PowerPoint a PDF en Vista de Notas**

Este código C# demuestra cómo convertir una presentación de PowerPoint a un PDF que incluye notas:
```c#
// Cargar una presentación de PowerPoint.
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


## **Accesibilidad y Normas de Cumplimiento para PDF**

Aspose.Slides le permite usar un procedimiento de conversión que cumple con las [Directrices de Accesibilidad para el Contenido Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Puede exportar un documento de PowerPoint a PDF usando cualquiera de estas normas de cumplimiento: **PDF/A1a**, **PDF/A1b** y **PDF/UA**.

Este código C# muestra un proceso de conversión de PowerPoint a PDF que produce varios PDFs basados en diferentes normas de cumplimiento:
```c#
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

Aspose.Slides admite operaciones de conversión de PDF, permitiéndole convertir archivos PDF a formatos de archivo populares. Puede realizar conversiones de [PDF a HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/), [PDF a imagen](https://products.aspose.com/slides/net/conversion/pdf-to-image/), [PDF a JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/), y [PDF a PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/). Otras operaciones de conversión de PDF a formatos especializados —[PDF a SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/), [PDF a TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/), y [PDF a XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/)—también son compatibles.

{{% /alert %}}

## **Preguntas frecuentes**

**¿Puedo convertir varios archivos PowerPoint a PDF en lote?**

Sí, Aspose.Slides admite la conversión por lotes de varios archivos PPT o PPTX a PDF. Puede iterar a través de sus archivos y aplicar el proceso de conversión mediante programación.

**¿Es posible proteger con contraseña el PDF convertido?**

Absolutamente. Utilice la clase [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) para establecer una contraseña y definir permisos de acceso durante el proceso de conversión.

**¿Cómo incluyo diapositivas ocultas en el PDF?**

Establezca la propiedad `ShowHiddenSlides` en la clase [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) a `true` para incluir diapositivas ocultas en el PDF resultante.

**¿Puede Aspose.Slides mantener alta calidad de imagen en el PDF?**

Sí, puede controlar la calidad de imagen estableciendo propiedades como `JpegQuality` y `SufficientResolution` en la clase [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) para garantizar imágenes de alta calidad en su PDF.

**¿Aspose.Slides admite normas de cumplimiento PDF/A?**

Sí, Aspose.Slides le permite exportar PDFs que cumplen con diversas normas, incluidas PDF/A1a, PDF/A1b y PDF/UA, garantizando que sus documentos cumplan con los requisitos de accesibilidad y archivo.

## **Recursos adicionales**

- [Documentación de Aspose.Slides para .NET](/slides/es/net/)
- [Referencia de API de Aspose.Slides para .NET](https://reference.aspose.com/slides/net/)
- [Convertidores gratuitos en línea de Aspose](https://products.aspose.app/slides/conversion)