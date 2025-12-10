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
- extracción de texto de presentación
- diapositiva maestra
- notas del orador
- extracción de texto de diapositivas
- C#
description: "Aprenda cómo extraer texto de archivos PPT, PPTX y ODP en .NET usando Open XML SDK, con acceso basado en XML, consejos de rendimiento y soluciones alternativas de conversión para aplicaciones en la nube."
---

## **Open XML SDK**

El **Open XML SDK** ofrece un método altamente estructurado y eficiente para extraer texto de archivos de presentación —especialmente **PPTX**, que sigue el estándar Open XML. Al proporcionar acceso directo al XML subyacente, este SDK permite un manejo más rápido y flexible del contenido de las diapositivas en comparación con los métodos tradicionales.

## **Acceso Directo al XML**

- **Analizar Texto Directamente**: El Open XML SDK le permite extraer texto de las partes XML sin renderizar las diapositivas.
- **Elementos Estructurados**: Como el texto se almacena en etiquetas XML bien definidas, es más sencillo recuperarlo y procesarlo.

### **Ejemplo: Extrayendo Texto Directamente del Contenido XML de una Diapositiva**
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


## **Ventajas de Rendimiento**

- **Extracción Más Rápida**: Elimina la sobrecarga de abrir PowerPoint u otras API de alto nivel.
- **Menor Uso de Memoria**: Sólo se acceden a las partes XML relevantes, reduciendo el consumo de recursos.
- **No Se Necesita Microsoft PowerPoint**: Lo libera de requisitos de instalación adicionales.

### **Ejemplo: Extrayendo Texto de Forma Eficiente Sin Cargar Toda la Presentación**
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


## **Identificación de Elementos de Texto**

### **Detalles de la Extracción de Texto de Presentaciones**

Al extraer texto de presentaciones, considere los siguientes factores:

- **El Texto Puede Residir en Diferentes Secciones**: Diapositivas normales, diapositivas maestras, diseños o notas del orador.
- **Marcadores de Posición Predeterminados**: Las diapositivas maestras y los diseños pueden incluir marcadores (por ejemplo, “Haga clic para editar el estilo del título maestro”) que no son contenido real de la presentación.
- **Filtrar Texto Vacío u Oculto**: Algunos elementos pueden estar vacíos o no estar destinados a mostrarse.

### **Etiquetas que Contienen Texto**

En un archivo **PPTX**, el texto se almacena generalmente en:
- Elementos `<a:t>` dentro de `<a:p>` (párrafos)
- Elementos `<a:r>` (segmentos de texto dentro de los párrafos)

### **Ejemplo: Extrayendo Todos los Elementos de Texto de una Diapositiva**
```csharp
var textElements = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>();
foreach (var text in textElements)
{
    Console.WriteLine(text.Text);
}
```


## **ODP y PPT**

### **Imposibilidad de Extraer Texto Directamente**

- A diferencia de **PPTX**, **PPT** (formato binario) y **ODP** (OpenDocument Presentation) **no son compatibles** con Open XML SDK.
- **PPT** almacena el contenido en un formato binario cerrado, lo que complica la extracción de texto.
- **ODP** se basa en **OpenDocument XML**, que difiere estructuralmente de PPTX.

### **Solución Alternativa: Convertir a PPTX**

Para extraer texto de **PPT** o **ODP**, el enfoque recomendado es:

1. **Convertir PPT → PPTX** usando PowerPoint o una herramienta de terceros.  
2. **Convertir ODP → PPTX** mediante LibreOffice o PowerPoint.  
3. **Extraer texto** del nuevo PPTX usando Open XML SDK.

### **Ejemplo: Convertir ODP a PPTX mediante la línea de comandos de LibreOffice**
```sh
soffice --headless --convert-to pptx presentation.odp
```


## **Plataformas y Frameworks Compatibles**

- **Windows**: .NET Framework 4.6.1 y superiores, .NET Core 2.1+, .NET 5/6/7.
- **Linux/macOS**: .NET Core 2.1+, .NET 5/6/7.
- **Entornos en la Nube**: Microsoft Azure Functions, AWS Lambda (.NET Core), contenedores Docker.
- **Compatibilidad con Aplicaciones de Office**: No se requiere instalación de Microsoft Office.
- **Lenguajes de Programación Compatibles**: Open XML SDK puede usarse con **C#**, **VB.NET**, **F#** y otros lenguajes compatibles con .NET.

## **Conclusión**

Aprovechar el **Open XML SDK** para la **extracción de texto de PPTX** brinda tanto eficiencia como claridad, mientras que **PPT y ODP** exigen un paso de conversión inicial para un procesamiento fluido. Adoptar este enfoque garantiza **alto rendimiento**, **flexibilidad** y **amplia compatibilidad** con aplicaciones modernas de .NET.