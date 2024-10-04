---
title: Convertir PowerPoint a PDF en C#
linktitle: Convertir PowerPoint a PDF
type: docs
weight: 40
url: /net/convert-powerpoint-to-pdf/
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
- C#
- Csharp
- .NET
- Aspose.Slides para .NET
description: "Convierte presentaciones de PowerPoint a PDF en C# o .NET. Guarda PowerPoint como PDF cumpliendo con normas de accesibilidad o conformidad."
---

## **Descripción general**

Convertir documentos de PowerPoint a formato PDF ofrece varias ventajas, incluyendo asegurar la compatibilidad a través de diferentes dispositivos y preservar el diseño y formato de tu presentación. Este artículo te muestra cómo convertir presentaciones a documentos PDF, usar varias opciones para controlar la calidad de la imagen, incluir diapositivas ocultas, proteger documentos PDF con contraseña, detectar sustituciones de fuentes, seleccionar diapositivas para conversión y aplicar estándares de conformidad a los documentos de salida.

## **Conversiones de PowerPoint a PDF**

Usando Aspose.Slides, puedes convertir presentaciones en estos formatos a PDF:

* PPT
* PPTX
* ODP

Para convertir una presentación a PDF, simplemente debes pasar el nombre del archivo como un argumento en la clase [`Presentation`](https://reference.aspose.com/slides/net/aspose.slides/presentation/) y luego guardar la presentación como un PDF usando un método [`Save`](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). La clase [`Presentation`](https://reference.aspose.com/slides/net/aspose.slides/presentation/) expone el método [`Save`](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/#presentationsave-method-5-of-9) que se utiliza típicamente para convertir una presentación a PDF.

{{%  alert title="NOTA"  color="warning"   %}} 

Aspose.Slides para .NET escribe directamente la información de la API y el número de versión en los documentos de salida. Por ejemplo, cuando convierte una presentación a PDF, Aspose.Slides para .NET llena el campo de Aplicación con el valor '*Aspose.Slides*' y el campo del Productor de PDF con un valor en la forma '*Aspose.Slides v XX.XX*'. **Nota** que no puedes instruir a Aspose.Slides para .NET para cambiar o eliminar esta información de los documentos de salida.

{{% /alert %}}

Aspose.Slides te permite convertir:

* toda una presentación a PDF
* diapositivas específicas en una presentación a PDF
* una presentación 

Aspose.Slides exporta presentaciones a PDF de manera que el contenido de los PDFs resultantes sea muy similar al de las presentaciones originales. Estos elementos y atributos conocidos a menudo se representan correctamente en las conversiones de presentación a PDF:

* imágenes
* cuadros de texto y otras formas
* textos y su formato
* párrafos y su formato
* hiperenlaces
* encabezados y pies de página
* viñetas
* tablas

## **Convertir PowerPoint a PDF**

La operación estándar de conversión de PowerPoint a PDF se ejecuta usando opciones predeterminadas. En este caso, Aspose.Slides trata de convertir la presentación proporcionada a PDF usando configuraciones óptimas en los niveles de calidad máximos.

Este código C# te muestra cómo convertir un PowerPoint (PPT, PPTX, ODP) a PDF:

```c#
// Instancia una clase Presentation que representa un archivo de PowerPoint, puede ser PPT, PPTX, ODP, etc.
Presentation presentation = new Presentation("PowerPoint.ppt");

// Guarda la presentación como un PDF
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{%  alert  color="primary"  %}} 

Aspose proporciona un [**convertidor de PowerPoint a PDF en línea gratuito**](https://products.aspose.app/slides/conversion/ppt-to-pdf) que demuestra el proceso de conversión de presentación a PDF. Para una implementación en vivo del procedimiento descrito aquí, puedes hacer una prueba con el convertidor.

{{% /alert %}}

## **Convertir PowerPoint a PDF con opciones**

Aspose.Slides proporciona opciones personalizadas—propiedades bajo la clase [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)—que te permiten personalizar el PDF (resultado del proceso de conversión), bloquear el PDF con una contraseña, o incluso especificar cómo debe llevarse a cabo el proceso de conversión.

### **Convertir PowerPoint a PDF con opciones personalizadas**

Usando opciones de conversión personalizadas, puedes establecer tu configuración de calidad preferida para imágenes rasterizadas, especificar cómo deben manejarse los metafiles, establecer un nivel de compresión para textos, establecer DPI para imágenes, etc.

El siguiente ejemplo de código demuestra una operación en la que una presentación de PowerPoint se convierte a PDF con varias opciones personalizadas:

```c#
// Instancia la clase PdfOptions
PdfOptions pdfOptions = new PdfOptions
{
    // Establece la calidad para imágenes JPG
    JpegQuality = 90,

    // Establece DPI para imágenes
    SufficientResolution = 300,

    // Establece el comportamiento para metafiles
    SaveMetafilesAsPng = true,

    // Establece el nivel de compresión de texto para contenido textual
    TextCompression = PdfTextCompression.Flate,

    // Define el modo de conformidad de PDF
    Compliance = PdfCompliance.Pdf15
};

// Instancia la clase Presentation que representa un documento de PowerPoint
using (Presentation presentation = new Presentation("PowerPoint.pptx"))
{
    // Guarda la presentación como un documento PDF
    presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
}
```

### **Convertir PowerPoint a PDF con diapositivas ocultas**

Si una presentación contiene diapositivas ocultas, puedes usar una opción personalizada—la propiedad [`ShowHiddenSlides`](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) de la clase [`PdfOptions`](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)—para instruir a Aspose.Slides a incluir las diapositivas ocultas como páginas en el PDF resultante.

Este código C# te muestra cómo convertir una presentación de PowerPoint a PDF incluyendo diapositivas ocultas:

```c#
// Instancia una clase Presentation que representa un archivo de PowerPoint
Presentation presentation = new Presentation("PowerPoint.pptx");

// Instancia la clase PdfOptions
PdfOptions pdfOptions = new PdfOptions();

// Agrega diapositivas ocultas
pdfOptions.ShowHiddenSlides = true;

// Guarda la presentación como un PDF
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Convertir PowerPoint a PDF protegido por contraseña**

Este código C# te muestra cómo convertir un PowerPoint a un PDF protegido por contraseña (usando parámetros de protección de la clase [`PdfOptions`](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)):

```c#
// Instancia un objeto Presentation que representa un archivo de PowerPoint
Presentation presentation = new Presentation("PowerPoint.pptx");

/// Instancia la clase PdfOptions
PdfOptions pdfOptions = new PdfOptions();

// Establece la contraseña del PDF y los permisos de acceso
pdfOptions.Password = "contraseña";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

// Guarda la presentación como un PDF
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Detectar sustituciones de fuentes**

Aspose.Slides proporciona la propiedad [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) bajo la clase [SaveOptions](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/) para permitirte detectar sustituciones de fuentes en un proceso de conversión de presentación a PDF. 

Este código C# te muestra cómo detectar sustituciones de fuentes: xxx 

```c#
public static void Main()
{
    LoadOptions loadOptions = new LoadOptions();
    FontSubstSendsWarningCallback warningCallback = new FontSubstSendsWarningCallback();
    loadOptions.WarningCallback = warningCallback;

    using (Presentation pres = new Presentation("pres.pptx", loadOptions))
    {
    }
}

private class FontSubstSendsWarningCallback : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.CompatibilityIssue)
            return ReturnAction.Continue;

        if (warning.WarningType == WarningType.DataLoss &&
            warning.Description.StartsWith("Se sustituirá la fuente"))
        {
            Console.WriteLine($"Advertencia de sustitución de fuente: {warning.Description}");
        }

        return ReturnAction.Continue;
    }
}
```

{{%  alert color="primary"  %}} 

Para más información sobre cómo obtener devoluciones de llamada para sustituciones de fuentes en un proceso de renderizado, consulta [Obteniendo devoluciones de llamada de advertencia para la sustitución de fuentes](https://docs.aspose.com/slides/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Para más información sobre la sustitución de fuentes, consulta el artículo [Sustitución de fuentes](https://docs.aspose.com/slides/net/font-substitution/).

{{% /alert %}} 

## **Convertir diapositivas seleccionadas en PowerPoint a PDF**

Este código C# te muestra cómo convertir diapositivas específicas en una presentación de PowerPoint a PDF:

```c#
// Instancia un objeto Presentation que representa un archivo de PowerPoint
Presentation presentation = new Presentation("PowerPoint.pptx");

// Establece un array de posiciones de diapositivas
int[] slides = { 1, 3 };

// Guarda la presentación como un PDF
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **Convertir PowerPoint a PDF con tamaño de diapositiva personalizado**

Este código C# te muestra cómo convertir un PowerPoint cuando su tamaño de diapositiva está especificado a un PDF:

```c#
// Instancia un objeto Presentation que representa un archivo de PowerPoint 
Presentation presentation = new Presentation("SelectedSlides.pptx");
Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];
auxPresentation.Slides.InsertClone(0, slide);

// Establece el tipo y tamaño de la diapositiva 
// auxPresentation.SlideSize.SetSize(presentation.SlideSize.Size.Width, presentation.SlideSize.Size.Height,SlideSizeScaleType.EnsureFit);
auxPresentation.SlideSize.SetSize(612F, 792F,SlideSizeScaleType.EnsureFit);

PdfOptions pdfOptions = new PdfOptions();
INotesCommentsLayoutingOptions options = pdfOptions.NotesCommentsLayouting;
options.NotesPosition = NotesPositions.BottomFull;

auxPresentation.Save("PDFnotes_out.pdf", SaveFormat.Pdf, pdfOptions);
```

## **Convertir PowerPoint a PDF en vista de notas**

Este código C# te muestra cómo convertir un PowerPoint a PDF notas:

```c#
// Instancia una clase Presentation que representa un archivo de PowerPoint
using (Presentation presentation = new Presentation("NotesFile.pptx"))
{
	PdfOptions pdfOptions = new PdfOptions();
	INotesCommentsLayoutingOptions options = pdfOptions.NotesCommentsLayouting;
	options.NotesPosition = NotesPositions.BottomFull;

	// Guarda la presentación en PDF notas
	presentation.Save("Pdf_Notes_out.tiff", SaveFormat.Pdf, pdfOptions);
}
```

## **Normas de accesibilidad y conformidad para PDF**

Aspose.Slides te permite usar un procedimiento de conversión que cumple con las [Directrices de accesibilidad para el contenido web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Puedes exportar un documento de PowerPoint a PDF utilizando cualquiera de estos estándares de conformidad: **PDF/A1a**, **PDF/A1b**, y **PDF/UA**.

Este código C# demuestra una operación de conversión de PowerPoint a PDF en la que se obtienen múltiples PDFs basados en diferentes estándares de conformidad:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres-a1a-compliance.pdf", SaveFormat.Pdf, new PdfOptions()
    {
        Compliance = PdfCompliance.PdfA1a
    });
   
    pres.Save("pres-a1b-compliance.pdf", SaveFormat.Pdf, new PdfOptions()
    {
        Compliance = PdfCompliance.PdfA1b
    });
   
    pres.Save("pres-ua-compliance.pdf", SaveFormat.Pdf, new PdfOptions()
   {
        Compliance = PdfCompliance.PdfUa
    });
}
```

{{% alert title="Nota" color="warning" %}} 

El soporte de Aspose.Slides para operaciones de conversión a PDF se extiende al permitirte convertir PDF a los formatos de archivo más populares. Puedes realizar conversiones de [PDF a HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/), [PDF a imagen](https://products.aspose.com/slides/net/conversion/pdf-to-image/), [PDF a JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/), y [PDF a PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/). Otras operaciones de conversión de PDF a formatos especializados—[PDF a SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/), [PDF a TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/), y [PDF a XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/)—también son compatibles.

{{% /alert %}}