---
title: Obtener devoluciones de llamada de advertencia para sustitución de fuentes en .NET
type: docs
weight: 120
url: /es/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- devolución de llamada de advertencia
- sustitución de fuentes
- proceso de renderizado
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Aprenda a obtener devoluciones de llamada de advertencia por sustitución de fuentes en Aspose.Slides para .NET y mostrar presentaciones de PowerPoint y OpenDocument con precisión."
---

## **Descripción general**

Aspose.Slides for .NET le permite recibir devoluciones de llamada de advertencia por sustitución de fuentes cuando una fuente requerida no está disponible en la máquina durante la renderización. Estas devoluciones de llamada ayudan a diagnosticar problemas con fuentes faltantes o inaccesibles.

## **Habilitar devoluciones de llamada de advertencia**

Aspose.Slides for .NET proporciona API sencillas para recibir devoluciones de llamada de advertencia al renderizar diapositivas de presentación. Siga estos pasos para configurar las devoluciones de llamada de advertencia:

1. Cree una clase de devolución de llamada personalizada que implemente la interfaz [IWarningCallback](https://reference.aspose.com/slides/net/aspose.slides.warnings/iwarningcallback/) para manejar advertencias.
1. Establezca la devolución de llamada de advertencia usando clases de opciones como [RenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/renderingoptions/), [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions/) y otras.
1. Cargue una presentación que utilice una fuente no disponible en la máquina de destino.
1. Genere una miniatura de diapositiva o exporte la presentación para observar el efecto.

**Clase de devolución de llamada de advertencia personalizada:**
```c#
class FontWarningHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss)
        {
            Console.WriteLine(warning.Description);
        }

        return ReturnAction.Continue;
    }
}

// Ejemplo de salida:
//
// La fuente será sustituida de XYZ a {Calibri,Cambria Math,MS Gothic,Gulim,Arial Unicode,SimSun,Segoe UI Symbol}}
```


**Generar una miniatura de diapositiva:**
```c#
// Configurar una devolución de llamada de advertencia para manejar advertencias relacionadas con fuentes durante la renderización de diapositivas.
var options = new RenderingOptions();
options.WarningCallback = new FontWarningHandler();

// Cargar la presentación desde la ruta de archivo especificada.
using var presentation = new Presentation("sample.pptx");

// Generar una imagen miniatura para cada diapositiva en la presentación.
foreach (var slide in presentation.Slides)
{
    // Obtener la imagen miniatura de la diapositiva utilizando las opciones de renderizado especificadas.
    using var image = slide.GetImage(options);
    // ...
}
```


**Exportar a formato PDF:**
```c#
// Configurar una devolución de llamada de advertencia para manejar advertencias relacionadas con fuentes durante la exportación a PDF.
var options = new PdfOptions();
options.WarningCallback = new FontWarningHandler();

// Cargar la presentación desde la ruta de archivo especificada.
using var presentation = new Presentation("sample.pptx");

// Exportar la presentación como PDF.
using var stream = new MemoryStream();
presentation.Save(stream, SaveFormat.Pdf, options);
// ...
```


**Exportar a formato HTML:**
```c#
// Configurar una devolución de llamada de advertencia para manejar advertencias relacionadas con fuentes durante la exportación a HTML.
var options = new HtmlOptions();
options.WarningCallback = new FontWarningHandler();

// Cargar la presentación desde la ruta de archivo especificada.
using var presentation = new Presentation("sample.pptx");

// Exportar la presentación en formato HTML.
using var stream = new MemoryStream();
presentation.Save(stream, SaveFormat.Html, options);
// ...
```
