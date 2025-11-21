---
title: "Cómo extraer texto de archivos PPT, PPTX y ODP usando Open XML SDK en .NET"
linktitle: Open XML SDK
type: docs
weight: 20
url: /es/net/extracting-text-on-cloud-platforms-using-open-xml-sdk/
keywords:
- plataformas en la nube
- integración en la nube
- Open XML SDK
- extracción de texto PPTX
- procesamiento de diapositivas .NET
- extracción de texto de presentaciones
- diapositiva maestra
- notas del orador
- extracción de texto de diapositivas
- C#
description: "Aprenda cómo extraer texto de archivos PPT, PPTX y ODP en .NET usando Open XML SDK, con acceso basado en XML, consejos de rendimiento y soluciones de conversión para aplicaciones en la nube."
---

# Extracción de texto de PPT, PPTX, ODP usando Open XML SDK

## Open XML SDK

El **Open XML SDK** proporciona un método altamente estructurado y eficiente para extraer texto de archivos de presentación, especialmente **PPTX**, que sigue el estándar Open XML. Al ofrecer acceso directo al XML subyacente, este SDK permite un manejo más rápido y flexible del contenido de las diapositivas en comparación con los métodos tradicionales.

## Acceso directo al XML

- **Analizar texto directamente**: El Open XML SDK permite extraer texto de las partes XML sin renderizar las diapositivas.
- **Elementos estructurados**: Debido a que el texto se almacena en etiquetas XML bien definidas, es más sencillo recuperarlo y procesarlo.

### Ejemplo: Extracción directa de texto del contenido XML de una diapositiva
```csharp
using (PresentationDocument presentation = PresentationDocument.Open("presentation.pptx", false))
{
    var slidePart = presentation.PresentationPart.SlideParts.FirstOrDefault();
    if (slidePart != null)
    {
        var textElements = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>();
        foreach (var text in textElements)
        {
            Console.WriteLine(text.Text);
        }
    }
}
```


## Ventajas de rendimiento

- **Extracción más rápida**: Evita la sobrecarga de abrir PowerPoint u otras APIs de alto nivel.
- **Menor uso de memoria**: Sólo se acceden a las partes XML relevantes, reduciendo el consumo de recursos.
- **No se necesita Microsoft PowerPoint**: Elimina la necesidad de instalaciones adicionales.

### Ejemplo: Extracción eficiente de texto sin cargar toda la presentación
```csharp
using (PresentationDocument presentation = PresentationDocument.Open("presentation.pptx", false))
{
    foreach (var slidePart in presentation.PresentationPart.SlideParts)
    {
        var texts = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>().Select(t => t.Text);
        Console.WriteLine(string.Join(" ", texts));
    }
}
```


## Identificación de elementos de texto

### Detalles de la extracción de texto de presentaciones

Al extraer texto de presentaciones, considere los siguientes factores:

- **El texto puede residir en distintas secciones**: Diapositivas normales, diapositivas maestras, diseños o notas del orador.
- **Marcadores de posición predeterminados**: Las diapositivas maestras y los diseños pueden incluir marcadores de posición (p. ej., “Click to edit Master title style”) que no son contenido real de la presentación.
- **Filtrado de texto vacío o oculto**: Algunos elementos pueden estar vacíos o no destinados a mostrarse.

### Etiquetas que contienen texto

En un archivo **PPTX**, el texto se almacena generalmente en:
- elementos `<a:t>` dentro de `<a:p>` (párrafos)
- elementos `<a:r>` (segmentos de texto dentro de los párrafos)

### Ejemplo: Extracción de todos los elementos de texto de una diapositiva
```csharp
var textElements = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>();
foreach (var text in textElements)
{
    Console.WriteLine(text.Text);
}
```


## ODP y PPT

### Imposibilidad de extraer texto directamente

- A diferencia de **PPTX**, **PPT** (formato binario) y **ODP** (OpenDocument Presentation) **no son compatibles** con Open XML SDK.
- **PPT** almacena el contenido en un formato binario cerrado, lo que complica la extracción de texto.
- **ODP** se basa en **OpenDocument XML**, que difiere estructuralmente de PPTX.

### Solución alternativa: Convertir a PPTX

Para extraer texto de **PPT** o **ODP**, el enfoque recomendado es:

1. **Convertir PPT → PPTX** usando PowerPoint o una herramienta de terceros.  
2. **Convertir ODP → PPTX** mediante LibreOffice o PowerPoint.  
3. **Extraer texto** del nuevo PPTX usando Open XML SDK.

### Ejemplo: Conversión de ODP a PPTX mediante la línea de comandos de LibreOffice
```sh
soffice --headless --convert-to pptx presentation.odp
```


## Plataformas y marcos compatibles

- **Windows**: .NET Framework 4.6.1 y superiores, .NET Core 2.1+, .NET 5/6/7.
- **Linux/macOS**: .NET Core 2.1+, .NET 5/6/7.
- **Entornos en la nube**: Microsoft Azure Functions, AWS Lambda (.NET Core), contenedores Docker.
- **Compatibilidad con aplicaciones de Office**: No se requiere instalación de Microsoft Office.
- **Lenguajes de programación compatibles**: Open XML SDK se puede usar con **C#**, **VB.NET**, **F#** y otros lenguajes compatibles con .NET.

## Conclusión

Aprovechar el **Open XML SDK** para la **extracción de texto de PPTX** ofrece tanto eficiencia como claridad, mientras que **PPT y ODP** requieren un paso de conversión inicial para un procesamiento fluido. Adoptar este enfoque garantiza **alto rendimiento**, **flexibilidad** y **amplia compatibilidad** con aplicaciones .NET modernas.