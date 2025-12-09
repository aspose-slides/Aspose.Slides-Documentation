---
title: "Cómo extraer texto de PPT, PPTX y ODP con Aspose.Slides"
linktitle: Diapositivas
type: docs
weight: 30
url: /es/net/extracting-text-on-cloud-platforms-using-aspose-slides/
keywords:
- plataformas en la nube
- integración en la nube
- extracción de texto
- extraer texto
- PPT
- PPTX
- ODP
- archivos de presentación
- multiplataforma
- independiente de Office
- notas y comentarios
- indexación corporativa
- enriquecimiento de datos
- .NET
- Aspose.Slides
description: "Extrae texto de presentaciones en plataformas en la nube populares usando las API de Aspose.Slides, automatizando la búsqueda, el análisis y la exportación para PPT, PPTX y ODP."
---

# Extracción de texto de PPT, PPTX y ODP – Diapositivas

Aspose.Slides ofrece una **API potente y de alto nivel** para extraer texto de archivos de presentación, incluidos **PPT, PPTX y ODP**. A diferencia del Open XML SDK—que solo admite PPTX y requiere un análisis XML complejo—Aspose.Slides simplifica la extracción de texto, lo que le permite centrarse en integrar el contenido extraído en sus flujos de trabajo.

## Extracción rápida de texto con PresentationFactory.Instance.GetPresentationText

Para extraer texto de una presentación, la **API de Aspose.Slides** ofrece el método estático `PresentationFactory.Instance.GetPresentationText`. Incluye varias sobrecargas para trabajar con un archivo de presentación o un flujo de datos, capturando texto de **diapositivas, diapositivas maestras, diseños, notas y comentarios**. El texto extraído se accede a través de la interfaz `IPresentationText`.

Example usage:
```csharp
string filePath = "presentation.pptx";
TextExtractionArrangingMode mode = TextExtractionArrangingMode.Unarranged;

IPresentationText presentationText = PresentationFactory.Instance.GetPresentationText(filePath, mode);
ISlideText[] slideTexts = presentationText.SlidesText;

foreach (var slideText in slideTexts)
{
    Console.WriteLine("Slide Text: " + slideText.Text);
    Console.WriteLine("Notes Text: " + slideText.NotesText);
    Console.WriteLine("Comments Text: " + slideText.CommentsText);
}
```


## Modos de operación de GetPresentationText

El método `GetPresentationText` en `PresentationFactory` le permite afinar la extracción de texto mediante el parámetro `TextExtractionArrangingMode`, que controla cómo se organiza el texto en la salida.

### Modos disponibles:

- **TextExtractionArrangingMode.Unarranged** – Extrae el texto de forma libre, sin respetar el diseño original de la diapositiva.  
- **TextExtractionArrangingMode.Arranged** – Conserva el orden del texto según su ubicación en cada diapositiva.

Usage example:
```csharp
TextExtractionArrangingMode mode = TextExtractionArrangingMode.Arranged;
IPresentationText presentationText = PresentationFactory.Instance.GetPresentationText("presentation.pptx", mode);
ISlideText[] slideTexts = presentationText.SlidesText;

foreach (var slideText in slideTexts)
{
    Console.WriteLine("Slide Text (preserving order): " + slideText.Text);
}
```


## Ventajas clave de los métodos de PresentationFactory

- **No es necesario cargar presentaciones completas**: Minimiza el consumo de memoria y acelera la velocidad de procesamiento.  
- **Optimizado para archivos grandes**: Maneja eficientemente incluso presentaciones voluminosas, extrayendo texto rápidamente.  
- **Recupera notas y comentarios**: Incluye anotaciones de usuarios para una cobertura completa del contenido.  
- **Ideal para indexación y análisis de contenido**: Perfecto para sistemas empresariales que requieren procesamiento automatizado y enriquecimiento de datos.  
- **Independiente de Office**: Funciona sin necesidad de Microsoft PowerPoint instalado, ofreciendo una solución verdaderamente independiente.  
- **Compatibilidad multiformato**: Funciona sin problemas con **PPT, PPTX y ODP**.  
- **API flexible y potente**: Proporciona métodos versátiles para la extracción estructurada de texto.  
- **Cobertura completa de diapositivas**: Extrae texto de **diseños, diapositivas maestras, diapositivas estándar, fondos, notas del presentador y comentarios**.  
- **Compatibilidad multiplataforma**: Funciona en **Windows, Linux, macOS** y en entornos cloud.  
- **Alto rendimiento y escalabilidad**: Adecuado para **aplicaciones SaaS** y despliegues empresariales a gran escala.

## Sistemas operativos compatibles

Aspose.Slides se ejecuta en una variedad de sistemas operativos:

- **Windows** (p. ej., Windows 7, 8, 10, 11 y ediciones Server)  
- **Linux** (varias distribuciones, incluidas Ubuntu, Debian, Fedora, CentOS, etc.)  
- **macOS** (incluidas versiones modernas como 10.15 Catalina y posteriores)  

## Lenguajes de programación compatibles

Aspose.Slides se integra con múltiples plataformas y lenguajes:

- **C#** – Principalmente soportado a través de Aspose.Slides para .NET.  
- **Java** – API completa disponible con Aspose.Slides para Java.  
- **C++** – Aproveche Aspose.Slides para aplicaciones C++ críticas en rendimiento.  
- **Python vía .NET** – Incorpore la funcionalidad de Aspose.Slides usando interoperabilidad .NET.  
- **Otros lenguajes compatibles con .NET** – Utilice la biblioteca en cualquier entorno soportado por .NET.

## Conclusión

Aspose.Slides ofrece **extracción de texto completa** para presentaciones de PowerPoint y OpenDocument, soportando **diversos formatos de archivo, estructuración intuitiva del texto e implementación sencilla** en comparación con el Open XML SDK. Desde **diapositivas y notas hasta contenido de plantillas**, **Aspose.Slides** es una solución de alta eficiencia y rica en funcionalidades para extraer y gestionar el texto de presentaciones.