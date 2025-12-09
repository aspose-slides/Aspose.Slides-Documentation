---
title: Renderizar diapositivas de presentación como imágenes SVG en .NET
linktitle: Diapositiva a SVG
type: docs
weight: 50
url: /es/net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint a SVG
- presentación a SVG
- diapositiva a SVG
- PPT a SVG
- PPTX a SVG
- guardar PPT como SVG
- guardar PPTX como SVG
- exportar PPT a SVG
- exportar PPTX a SVG
- renderizar diapositiva
- convertir diapositiva
- exportar diapositiva
- imagen vectorial
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Aprenda cómo renderizar diapositivas de PowerPoint como imágenes SVG usando Aspose.Slides para .NET. Visuales de alta calidad con ejemplos sencillos de código C#."
---

## **Visión general**

Este artículo explica cómo **convertir una presentación de PowerPoint al formato SVG usando C#**. Cubre los siguientes temas.

_Formato_: **PowerPoint**
- [C# PowerPoint a SVG](#csharp-powerpoint-to-svg)
- [C# Convertir PowerPoint a SVG](#csharp-powerpoint-to-svg)
- [C# Cómo convertir un archivo PowerPoint a SVG](#csharp-powerpoint-to-svg)

_Formato_: **PPT**
- [C# PPT a SVG](#csharp-ppt-to-svg)
- [C# Convertir PPT a SVG](#csharp-ppt-to-svg)
- [C# Cómo convertir un archivo PPT a SVG](#csharp-ppt-to-svg)

_Formato_: **PPTX**
- [C# PPTX a SVG](#csharp-pptx-to-svg)
- [C# Convertir PPTX a SVG](#csharp-pptx-to-svg)
- [C# Cómo convertir un archivo PPTX a SVG](#csharp-pptx-to-svg)

_Formato_: **ODP**
- [C# ODP a SVG](#csharp-odp-to-svg)
- [C# Convertir ODP a SVG](#csharp-odp-to-svg)
- [C# Cómo convertir un archivo ODP a SVG](#csharp-odp-to-svg)

_Formato_: **Slide**
- [C# Convertir diapositiva de PowerPoint a SVG](#render-a-slide-as-an-svg-image)
- [C# Convertir diapositiva PPT a SVG](#render-a-slide-as-an-svg-image)
- [C# Convertir diapositiva PPTX a SVG](#render-a-slide-as-an-svg-image)
- [C# Convertir diapositiva ODP a SVG](#render-a-slide-as-an-svg-image)

Otros temas cubiertos por este artículo.
- [Ver también](#see-also)

## **Formato SVG**
SVG—un acrónimo de Scalable Vector Graphics—es un tipo o formato gráfico estándar utilizado para renderizar imágenes bidimensionales. SVG almacena imágenes como vectores en XML con detalles que definen su comportamiento o apariencia. 

SVG es uno de los pocos formatos de imágenes que cumple con estándares muy altos en estos aspectos: escalabilidad, interactividad, rendimiento, accesibilidad, programabilidad, entre otros. Por estas razones, se usa comúnmente en el desarrollo web. 

Puede que desee usar archivos SVG cuando necesite

- **imprimir su presentación en un *formato muy grande*.** Las imágenes SVG pueden escalarse a cualquier resolución o nivel. Puede redimensionar las imágenes SVG tantas veces como sea necesario sin sacrificar calidad.
- **usar gráficos y diagramas de sus diapositivas en *diferentes medios o plataformas*.** La mayoría de los lectores pueden interpretar archivos SVG. 
- **obtener *tamaños de imagen lo más pequeños posible*.** Los archivos SVG suelen ser más pequeños que sus equivalentes de alta resolución en otros formatos, especialmente en formatos basados en mapa de bits (JPEG o PNG).

## **Renderizar una diapositiva como una imagen SVG**

Aspose.Slides for .NET le permite exportar diapositivas de sus presentaciones como imágenes SVG. Siga estos pasos para generar imágenes SVG:

_Pasos: conversiones de PowerPoint a SVG en C#_

El siguiente código de ejemplo explica estas conversiones usando .NET.
- <a name="csharp-powerpoint-to-svg" id="csharp-powerpoint-to-svg"><strong>Pasos: convertir PowerPoint a SVG en C#</strong></a>
- <a name="csharp-ppt-to-svg" id="csharp-ppt-to-svg"><strong>Pasos: convertir PPT a SVG en C#</strong></a>
- <a name="csharp-pptx-to-svg" id="csharp-pptx-to-svg"><strong>Pasos: convertir PPTX a SVG en C#</strong></a>
- <a name="csharp-odp-to-svg" id="csharp-odp-to-svg"><strong>Pasos: convertir ODP a SVG en C#</strong></a>

_Pasos de código:_

1. Crear una instancia de la [Presentación](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class.
   * _.ppt_ extensión para cargar **PPT** file dentro de la clase _Presentation_.
   * _.pptx_ extensión para cargar **PPTX** file dentro de la clase _Presentation_.
   * _.odp_ extensión para cargar **ODP** file dentro de la clase _Presentation_.
   * _.pps_ extensión para cargar **PPS** file dentro de la clase _Presentation_.
2. Recorrer todas las diapositivas de la presentación.
3. Escribir cada diapositiva en su propio archivo SVG mediante FileStream.

{{% alert color="primary" %}} 

Es posible que desee probar nuestra [aplicación web gratuita](https://products.aspose.app/slides/conversion/ppt-to-svg) en la que implementamos la función de conversión de PPT a SVG de Aspose.Slides for .NET.

{{% /alert %}} 

Este código de ejemplo en C# le muestra cómo convertir PowerPoint a SVG usando Aspose.Slides: 
``` csharp
// El objeto Presentation puede cargar formatos de PowerPoint como PPT, PPTX, ODP, etc.
using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (FileStream fileStream = new FileStream($"slide-{index}.svg", FileMode.Create, FileAccess.Write))
        {
            slide.WriteAsSvg(fileStream);   
        }
    }
}
```


## **Preguntas frecuentes**

**¿Por qué el SVG resultante puede verse diferente en distintos navegadores?**

El soporte para características específicas de SVG se implementa de manera distinta en los motores de los navegadores. Los parámetros de [SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) ayudan a suavizar las incompatibilidades.

**¿Es posible exportar no solo diapositivas sino también formas individuales a SVG?**

Sí. Cualquier [forma puede guardarse como un SVG separado](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/), lo que resulta conveniente para iconos, pictogramas y reutilización de gráficos.

**¿Se pueden combinar varias diapositivas en un único SVG (tira/documento)?**

El escenario estándar es una diapositiva → un SVG. Combinar varias diapositivas en un solo lienzo SVG es un paso de post‑procesamiento que se realiza a nivel de la aplicación.

## **Ver también** 

Este artículo también cubre estos temas. Los códigos son los mismos que arriba.

_Formato_: **PowerPoint**
- [C# PowerPoint a SVG Code](#csharp-powerpoint-to-svg)
- [C# PowerPoint a SVG API](#csharp-powerpoint-to-svg)
- [C# PowerPoint a SVG Programmatically](#csharp-powerpoint-to-svg)
- [C# PowerPoint a SVG Library](#csharp-powerpoint-to-svg)
- [C# Guardar PowerPoint como SVG](#csharp-powerpoint-to-svg)
- [C# Generar SVG desde PowerPoint](#csharp-powerpoint-to-svg)
- [C# Crear SVG desde PowerPoint](#csharp-powerpoint-to-svg)
- [C# PowerPoint a SVG Converter](#csharp-powerpoint-to-svg)

_Formato_: **PPT**
- [C# PPT a SVG Code](#csharp-ppt-to-svg)
- [C# PPT a SVG API](#csharp-ppt-to-svg)
- [C# PPT a SVG Programmatically](#csharp-ppt-to-svg)
- [C# PPT a SVG Library](#csharp-ppt-to-svg)
- [C# Guardar PPT como SVG](#csharp-ppt-to-svg)
- [C# Generar SVG desde PPT](#csharp-ppt-to-svg)
- [C# Crear SVG desde PPT](#csharp-ppt-to-svg)
- [C# PPT a SVG Converter](#csharp-ppt-to-svg)

_Formato_: **PPTX**
- [C# PPTX a SVG Code](#csharp-pptx-to-svg)
- [C# PPTX a SVG API](#csharp-pptx-to-svg)
- [C# PPTX a SVG Programmatically](#csharp-pptx-to-svg)
- [C# PPTX a SVG Library](#csharp-pptx-to-svg)
- [C# Guardar PPTX como SVG](#csharp-pptx-to-svg)
- [C# Generar SVG desde PPTX](#csharp-pptx-to-svg)
- [C# Crear SVG desde PPTX](#csharp-pptx-to-svg)
- [C# PPTX a SVG Converter](#csharp-pptx-to-svg)

_Formato_: **ODP**
- [C# ODP a SVG Code](#csharp-odp-to-svg)
- [C# ODP a SVG API](#csharp-odp-to-svg)
- [C# ODP a SVG Programmatically](#csharp-odp-to-svg)
- [C# ODP a SVG Library](#csharp-odp-to-svg)
- [C# Guardar ODP como SVG](#csharp-odp-to-svg)
- [C# Generar SVG desde ODP](#csharp-odp-to-svg)
- [C# Crear SVG desde ODP](#csharp-odp-to-svg)
- [C# ODP a SVG Converter](#csharp-odp-to-svg)