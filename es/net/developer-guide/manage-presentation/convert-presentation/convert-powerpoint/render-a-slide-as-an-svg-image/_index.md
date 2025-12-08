---
title: Renderizar una diapositiva como imagen SVG en C#
linktitle: Renderizar una diapositiva como imagen SVG
type: docs
weight: 50
url: /es/net/render-a-slide-as-an-svg-image/
description: Este artículo explica cómo convertir una presentación de PowerPoint al formato SVG usando C#. Puede convertir los formatos PPT, PPTX y ODP en imágenes SVG.
keywords: C# Convertir PowerPoint a SVG, C# PPT a SVG, C# PPTX a SVG
---

## **Visión general**

Este artículo explica cómo **convertir presentaciones de PowerPoint al formato SVG utilizando C#**. Cubre los siguientes temas.

_Formato_: **PowerPoint**
- [C# PowerPoint a SVG](#csharp-powerpoint-to-svg)
- [C# PowerPoint a SVG](#csharp-powerpoint-to-svg)
- [C# PowerPoint a SVG](#csharp-powerpoint-to-svg)

_Formato_: **PPT**
- [C# PPT a SVG](#csharp-ppt-to-svg)
- [C# PPT a SVG](#csharp-ppt-to-svg)
- [C# PPT a SVG](#csharp-ppt-to-svg)

_Formato_: **PPTX**
- [C# PPTX a SVG](#csharp-pptx-to-svg)
- [C# PPTX a SVG](#csharp-pptx-to-svg)
- [C# PPTX a SVG](#csharp-pptx-to-svg)

_Formato_: **ODP**
- [C# ODP a SVG](#csharp-odp-to-svg)
- [C# ODP a SVG](#csharp-odp-to-svg)
- [C# ODP a SVG](#csharp-odp-to-svg)

_Formato_: **Slide**
- [C# Convertir diapositiva de PowerPoint a SVG](#render-a-slide-as-an-svg-image)
- [C# Convertir diapositiva PPT a SVG](#render-a-slide-as-an-svg-image)
- [C# Convertir diapositiva PPTX a SVG](#render-a-slide-as-an-svg-image)
- [C# Convertir diapositiva ODP a SVG](#render-a-slide-as-an-svg-image)

Otros temas cubiertos por este artículo.
- [Ver también](#see-also)

## **Formato SVG**
SVG—un acrónimo de Scalable Vector Graphics—es un tipo o formato estándar de gráficos utilizado para renderizar imágenes bidimensionales. SVG almacena imágenes como vectores en XML con detalles que definen su comportamiento o apariencia.

SVG es uno de los pocos formatos de imágenes que cumple estándares muy altos en estos aspectos: escalabilidad, interactividad, rendimiento, accesibilidad, programabilidad y otros. Por estas razones, se usa comúnmente en el desarrollo web.

Es posible que desee usar archivos SVG cuando necesita
- **imprimir su presentación en un *formato muy grande*.** Las imágenes SVG pueden escalar a cualquier resolución o nivel. Puede redimensionar las imágenes SVG tantas veces como sea necesario sin sacrificar la calidad.
- **usar gráficos y diagramas de sus diapositivas en *diferentes medios o plataformas*.** La mayoría de los lectores pueden interpretar archivos SVG.
- **usar los *tamaños más pequeños posibles de imágenes*.** Los archivos SVG son generalmente más pequeños que sus equivalentes de alta resolución en otros formatos, especialmente aquellos basados en mapa de bits (JPEG o PNG).

## **Renderizar una diapositiva como imagen SVG**

Aspose.Slides for .NET le permite exportar diapositivas en sus presentaciones como imágenes SVG. Siga estos pasos para generar imágenes SVG:

_Pasos: conversiones de PowerPoint a SVG en C#_

El siguiente código de ejemplo explica estas conversiones usando .NET.
- <a name="csharp-powerpoint-to-svg" id="csharp-powerpoint-to-svg"><strong>Pasos: Convertir PowerPoint a SVG en C#</strong></a>
- <a name="csharp-ppt-to-svg" id="csharp-ppt-to-svg"><strong>Pasos: Convertir PPT a SVG en C#</strong></a>
- <a name="csharp-pptx-to-svg" id="csharp-pptx-to-svg"><strong>Pasos: Convertir PPTX a SVG en C#</strong></a>
- <a name="csharp-odp-to-svg" id="csharp-odp-to-svg"><strong>Pasos: Convertir ODP a SVG en C#</strong></a>

_Pasos de código:_

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
   * _.ppt_ extensión para cargar archivo **PPT** dentro de la clase _Presentation_.
   * _.pptx_ extensión para cargar archivo **PPTX** dentro de la clase _Presentation_.
   * _.odp_ extensión para cargar archivo **ODP** dentro de la clase _Presentation_.
   * _.pps_ extensión para cargar archivo **PPS** dentro de la clase _Presentation_.
2. Itere a través de todas las diapositivas de la presentación.
3. Escriba cada diapositiva en su propio archivo SVG mediante FileStream.

{{% alert color="primary" %}} 

Es posible que desee probar nuestra [aplicación web gratuita](https://products.aspose.app/slides/conversion/ppt-to-svg) en la que implementamos la función de conversión de PPT a SVG de Aspose.Slides para .NET.

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

El soporte de características específicas de SVG se implementa de manera diferente en los motores de los navegadores. Los parámetros [SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) ayudan a suavizar las incompatibilidades.

**¿Es posible exportar no solo diapositivas sino también formas individuales a SVG?**

Sí. Cualquier [forma puede guardarse como un SVG separado](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/), lo cual es conveniente para íconos, pictogramas y reutilizar gráficos.

**¿Se pueden combinar varias diapositivas en un solo SVG (tira/documento)?**

El escenario estándar es una diapositiva → un SVG. Combinar varias diapositivas en un solo lienzo SVG es un paso de postprocesamiento que se realiza a nivel de la aplicación.

## **Ver también** 

Este artículo también cubre estos temas. Los códigos son los mismos que arriba.

_Formato_: **PowerPoint**
- [C# PowerPoint a SVG Código](#csharp-powerpoint-to-svg)
- [C# PowerPoint a SVG API](#csharp-powerpoint-to-svg)
- [C# PowerPoint a SVG programáticamente](#csharp-powerpoint-to-svg)
- [C# PowerPoint a SVG Biblioteca](#csharp-powerpoint-to-svg)
- [C# Guardar PowerPoint como SVG](#csharp-powerpoint-to-svg)
- [C# Generar SVG desde PowerPoint](#csharp-powerpoint-to-svg)
- [C# Crear SVG desde PowerPoint](#csharp-powerpoint-to-svg)
- [C# PowerPoint a SVG Convertidor](#csharp-powerpoint-to-svg)

_Formato_: **PPT**
- [C# PPT a SVG Código](#csharp-ppt-to-svg)
- [C# PPT a SVG API](#csharp-ppt-to-svg)
- [C# PPT a SVG programáticamente](#csharp-ppt-to-svg)
- [C# PPT a SVG Biblioteca](#csharp-ppt-to-svg)
- [C# Guardar PPT como SVG](#csharp-ppt-to-svg)
- [C# Generar SVG desde PPT](#csharp-ppt-to-svg)
- [C# Crear SVG desde PPT](#csharp-ppt-to-svg)
- [C# PPT a SVG Convertidor](#csharp-ppt-to-svg)

_Formato_: **PPTX**
- [C# PPTX a SVG Código](#csharp-pptx-to-svg)
- [C# PPTX a SVG API](#csharp-pptx-to-svg)
- [C# PPTX a SVG programáticamente](#csharp-pptx-to-svg)
- [C# PPTX a SVG Biblioteca](#csharp-pptx-to-svg)
- [C# Guardar PPTX como SVG](#csharp-pptx-to-svg)
- [C# Generar SVG desde PPTX](#csharp-pptx-to-svg)
- [C# Crear SVG desde PPTX](#csharp-pptx-to-svg)
- [C# PPTX a SVG Convertidor](#csharp-pptx-to-svg)

_Formato_: **ODP**
- [C# ODP a SVG Código](#csharp-odp-to-svg)
- [C# ODP a SVG API](#csharp-odp-to-svg)
- [C# ODP a SVG programáticamente](#csharp-odp-to-svg)
- [C# ODP a SVG Biblioteca](#csharp-odp-to-svg)
- [C# Guardar ODP como SVG](#csharp-odp-to-svg)
- [C# Generar SVG desde ODP](#csharp-odp-to-svg)
- [C# Crear SVG desde ODP](#csharp-odp-to-svg)
- [C# ODP a SVG Convertidor](#csharp-odp-to-svg)