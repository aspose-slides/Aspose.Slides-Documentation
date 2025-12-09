---
title: Convertir PPT y PPTX a PDF en .NET [Funciones avanzadas incluidas]
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
description: "Convierta presentaciones PowerPoint PPT/PPTX a PDFs de alta calidad y buscables en .NET usando Aspose.Slides, con ejemplos de código C# rápidos y opciones de conversión avanzadas."
---

## **Visión general**

Convertir presentaciones de PowerPoint (PPT, PPTX, ODP, etc.) a formato PDF en C# ofrece varias ventajas, como compatibilidad entre diferentes dispositivos y preservación del diseño y formato de su presentación. Esta guía muestra cómo convertir presentaciones a documentos PDF, usar diversas opciones para controlar la calidad de imagen, incluir diapositivas ocultas, proteger con contraseña los archivos PDF, detectar sustituciones de fuentes, seleccionar diapositivas específicas para la conversión y aplicar normas de cumplimiento a los documentos de salida.

## **Conversiones de PowerPoint a PDF**

Con Aspose.Slides, puede convertir presentaciones en los siguientes formatos a PDF:

* **PPT**
* **PPTX**
* **ODP**

Para convertir una presentación a PDF, pase el nombre del archivo como argumento a la clase [Presentación](https://reference.aspose.com/slides/net/aspose.slides/presentation/) y luego guarde la presentación como PDF mediante el método [Guardar](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). La clase [Presentación](https://reference.aspose.com/slides/net/aspose.slides/presentation/) expone el método [Guardar](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) que se utiliza típicamente para convertir una presentación a PDF.

{{%  alert title="NOTA"  color="warning"   %}} 

Aspose.Slides para .NET inserta su información de API y número de versión en los documentos de salida. Por ejemplo, al convertir una presentación a PDF, Aspose.Slides completa el campo Aplicación con "*Aspose.Slides*" y el campo Productor del PDF con un valor en forma "*Aspose.Slides v XX.XX*". **Nota** que no puede indicar a Aspose.Slides que cambie o elimine esta información de los documentos de salida.

{{% /alert %}}

Aspose.Slides le permite convertir:

* Presentaciones completas a PDF
* Diapositivas específicas de una presentación a PDF

Aspose.Slides exporta presentaciones a PDF, garantizando que los PDF resultantes coincidan estrechamente con las presentaciones originales. Los elementos y atributos se renderizan con precisión en la conversión, incluidos:

* Imágenes
* Cuadros de texto y formas
* Formato de texto
* Formato de párrafo
* Hipervínculos
* encabezados y pies de página
* Viñetas
* Tablas

## **Convertir PowerPoint a PDF**

El proceso estándar de conversión de PowerPoint a PDF usa opciones predeterminadas. En este caso, Aspose.Slides intenta convertir la presentación proporcionada a PDF usando configuraciones óptimas en los niveles máximos de calidad.

Este código C# le muestra cómo convertir una presentación (PPT, PPTX, ODP, etc.) a PDF:
```c#
// Instanciar la clase Presentation que representa un archivo PowerPoint u OpenDocument.
using var presentation = new Presentation("PowerPoint.ppt");

// Guardar la presentación como PDF.
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```


{{%  alert  color="primary"  %}} 

Aspose ofrece un [**convertidor en línea gratuito de PowerPoint a PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) que demuestra el proceso de conversión de presentación a PDF. Puede ejecutar una prueba con este convertidor para una implementación en vivo del procedimiento descrito aquí.

{{% /alert %}}

## **Convertir PowerPoint a PDF con opciones**

Aspose.Slides proporciona opciones personalizadas—propiedades bajo la clase [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)—que le permiten personalizar el PDF resultante, proteger el PDF con una contraseña o especificar cómo debe proceder el proceso de conversión.

### **Convertir PowerPoint a PDF con opciones personalizadas**

Con opciones de conversión personalizadas, puede definir su configuración de calidad preferida para imágenes raster, especificar cómo deben manejarse los metarchivos, establecer un nivel de compresión para texto, configurar DPI para imágenes y más.

El ejemplo de código a continuación muestra cómo convertir una presentación de PowerPoint a PDF con varias opciones personalizadas.
```c#
// Instanciar la clase PdfOptions.
var pdfOptions = new PdfOptions
{
    // Establecer la calidad para imágenes JPG.
    JpegQuality = 90,

    // Establecer DPI para imágenes.
    SufficientResolution = 300,

    // Establecer el comportamiento para metarchivos.
    SaveMetafilesAsPng = true,

    // Establecer el nivel de compresión de texto para contenido textual.
    TextCompression = PdfTextCompression.Flate,

    // Definir el modo de cumplimiento PDF.
    Compliance = PdfCompliance.Pdf15
};

// Instanciar la clase Presentation que representa un archivo PowerPoint o OpenDocument file.
using var presentation = new Presentation("PowerPoint.pptx");

// Guardar la presentación como documento PDF.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```


### **Convertir PowerPoint a PDF con diapositivas ocultas**

Si una presentación contiene diapositivas ocultas, puede usar la propiedad [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) de la clase [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) para incluir las diapositivas ocultas como páginas en el PDF resultante.

Este código C# muestra cómo convertir una presentación de PowerPoint a PDF con las diapositivas ocultas incluidas:
```c#
 // Instanciar la clase Presentation que representa un archivo PowerPoint o OpenDocument.
 using var presentation = new Presentation("PowerPoint.pptx");

 // Instanciar la clase PdfOptions.
 var pdfOptions = new PdfOptions();

 // Agregar diapositivas ocultas.
 pdfOptions.ShowHiddenSlides = true;

 // Guardar la presentación como PDF.
 presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```


### **Convertir PowerPoint a PDF protegido con contraseña**

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


### **Detectar sustituciones de fuentes**

Aspose.Slides proporciona la propiedad [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) bajo la clase [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), lo que le permite detectar sustituciones de fuentes durante el proceso de conversión de presentación a PDF.

Este código C# muestra cómo detectar sustituciones de fuentes:
```c#
public static void Main()
{
    // Instanciar la clase Presentation que representa un archivo PowerPoint o OpenDocument. 
    using var presentation = new Presentation("sample.pptx");

    // Establecer la función de devolución de llamada de advertencia en las opciones de PDF.
    var pdfOptions = new PdfOptions();
    pdfOptions.WarningCallback = new FontSubstitutionHandler();

    // Guardar la presentación como PDF.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}

// Implementación de la devolución de llamada de advertencia.
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

Para obtener más información sobre la recepción de callbacks para sustituciones de fuentes durante el proceso de renderizado, consulte [Obtención de callbacks de advertencia para sustitución de fuentes](/slides/es/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Para más información sobre sustitución de fuentes, vea el artículo [Sustitución de fuentes](/slides/es/net/font-substitution/).

{{% /alert %}} 

## **Convertir diapositivas seleccionadas de PowerPoint a PDF**

Este código C# demuestra cómo convertir solo diapositivas específicas de una presentación de PowerPoint a PDF:
```c#
// Instanciar la clase Presentation que representa un archivo PowerPoint o OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// Establecer el arreglo de números de diapositivas.
int[] slides = { 1, 3 };

// Guardar la presentación como PDF.
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```


## **Convertir PowerPoint a PDF con tamaño de diapositiva personalizado**

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


## **Convertir PowerPoint a PDF en vista de diapositiva de notas**

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


## **Accesibilidad y normas de cumplimiento para PDF**

Aspose.Slides le permite usar un procedimiento de conversión que cumple con las [Directrices de Accesibilidad al Contenido Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Puede exportar un documento de PowerPoint a PDF usando cualquiera de estas normas de cumplimiento: **PDF/A1a**, **PDF/A1b** y **PDF/UA**.

Este código C# demuestra un proceso de conversión de PowerPoint a PDF que produce varios PDF basados en diferentes normas de cumplimiento:
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


{{% alert title="Nota" color="warning" %}} 

Aspose.Slides admite operaciones de conversión a PDF, lo que le permite convertir archivos PDF a formatos de archivo populares. Puede realizar conversiones de [PDF a HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/), [PDF a imagen](https://products.aspose.com/slides/net/conversion/pdf-to-image/), [PDF a JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/), y [PDF a PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/). Otras operaciones de conversión de PDF a formatos especializados—[PDF a SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/), [PDF a TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/), y [PDF a XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/)—también son compatibles.

{{% /alert %}}

## **Preguntas frecuentes**

**¿Puedo convertir varios archivos PowerPoint a PDF en lote?**

Sí, Aspose.Slides admite la conversión por lotes de varios archivos PPT o PPTX a PDF. Puede iterar a través de sus archivos y aplicar el proceso de conversión programáticamente.

**¿Es posible proteger con contraseña el PDF convertido?**

Absolutamente. Use la clase [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) para establecer una contraseña y definir permisos de acceso durante el proceso de conversión.

**¿Cómo incluyo diapositivas ocultas en el PDF?**

Establezca la propiedad `ShowHiddenSlides` en la clase [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) en `true` para incluir diapositivas ocultas en el PDF resultante.

**¿Puede Aspose.Slides mantener alta calidad de imagen en el PDF?**

Sí, puede controlar la calidad de imagen configurando propiedades como `JpegQuality` y `SufficientResolution` en la clase [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) para garantizar imágenes de alta calidad en su PDF.

**¿Aspose.Slides admite normas de cumplimiento PDF/A?**

Sí, Aspose.Slides le permite exportar PDFs que cumplen con diversas normas, incluidas PDF/A1a, PDF/A1b y PDF/UA, asegurando que sus documentos cumplan con requisitos de accesibilidad y archivado.

## **Recursos adicionales**

- [Documentación de Aspose.Slides para .NET](/slides/es/net/)
- [Referencia API de Aspose.Slides para .NET](https://reference.aspose.com/slides/net/)
- [Convertidores en línea gratuitos de Aspose](https://products.aspose.app/slides/conversion)