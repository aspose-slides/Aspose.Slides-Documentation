---
title: Renderizar una Diapositiva como una Imagen SVG en C#
linktitle: Renderizar una Diapositiva como una Imagen SVG
type: docs
weight: 50
url: /net/render-a-slide-as-an-svg-image/
description: Este artículo explica cómo convertir una presentación de PowerPoint al formato SVG utilizando C#. Puedes convertir formatos PPT, PPTX, ODP en imágenes SVG.
keywords: C# Convertir PowerPoint a SVG, C# PPT a SVG, C# PPTX a SVG
---

## Descripción General

Este artículo explica cómo **convertir una presentación de PowerPoint al formato SVG utilizando C#**. Cubre los siguientes temas.

_Formato_: **PowerPoint**
- [C# PowerPoint a SVG](#csharp-powerpoint-to-svg)
- [C# Convertir PowerPoint a SVG](#csharp-powerpoint-to-svg)
- [C# Cómo convertir un archivo de PowerPoint a SVG](#csharp-powerpoint-to-svg)

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

_Formato_: **Diapositiva**
- [C# Convertir Diapositiva de PowerPoint a SVG](#render-a-slide-as-an-svg-image)
- [C# Convertir Diapositiva de PPT a SVG](#render-a-slide-as-an-svg-image)
- [C# Convertir Diapositiva de PPTX a SVG](#render-a-slide-as-an-svg-image)
- [C# Convertir Diapositiva de ODP a SVG](#render-a-slide-as-an-svg-image)

Otros temas cubiertos por este artículo.
- [Ver También](#see-also)

## Formato SVG
SVG—un acrónimo de Gráficos Vectoriales Escalables—es un tipo o formato de gráficos estándar utilizado para renderizar imágenes bidimensionales. SVG almacena imágenes como vectores en XML con detalles que definen su comportamiento o apariencia.

SVG es uno de los pocos formatos para imágenes que cumple con estándares muy altos en estos términos: escalabilidad, interactividad, rendimiento, accesibilidad, programabilidad y otros. Por estas razones, se utiliza comúnmente en el desarrollo web.

Es posible que desees utilizar archivos SVG cuando necesites

- **imprimir tu presentación en un *formato muy grande*.** Las imágenes SVG pueden escalarse a cualquier resolución o nivel. Puedes redimensionar imágenes SVG tantas veces como sea necesario sin sacrificar calidad.
- **usar gráficos y diagramas de tus diapositivas en *diferentes medios o plataformas*.* La mayoría de los lectores pueden interpretar archivos SVG.
- **usar los *tamaños más pequeños posibles de imágenes*.** Los archivos SVG generalmente son más pequeños que sus equivalentes de alta resolución en otros formatos, especialmente aquellos basados en mapas de bits (JPEG o PNG).

## Renderizar una Diapositiva como una Imagen SVG

Aspose.Slides para .NET te permite exportar diapositivas en tus presentaciones como imágenes SVG. Sigue estos pasos para generar imágenes SVG:

_Pasos: Conversiones de PowerPoint a SVG en C#_

El siguiente código de muestra explica estas conversiones utilizando .NET.
- <a name="csharp-powerpoint-to-svg" id="csharp-powerpoint-to-svg"><strong>Pasos: Convertir PowerPoint a SVG en C#</strong></a>
- <a name="csharp-ppt-to-svg" id="csharp-ppt-to-svg"><strong>Pasos: Convertir PPT a SVG en C#</strong></a>
- <a name="csharp-pptx-to-svg" id="csharp-pptx-to-svg"><strong>Pasos: Convertir PPTX a SVG en C#</strong></a>
- <a name="csharp-odp-to-svg" id="csharp-odp-to-svg"><strong>Pasos: Convertir ODP a SVG en C#</strong></a>

_Pasos de Código:_

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
   * _.ppt_ extensión para cargar un archivo **PPT** dentro de la clase _Presentation_.
   * _.pptx_ extensión para cargar un archivo **PPTX** dentro de la clase _Presentation_.
   * _.odp_ extensión para cargar un archivo **ODP** dentro de la clase _Presentation_.
   * _.pps_ extensión para cargar un archivo **PPS** dentro de la clase _Presentation_.
2. Itera a través de todas las diapositivas en la presentación.
3. Escribe cada diapositiva en su propio archivo SVG a través de FileStream.

{{% alert color="primary" %}} 

Es posible que desees probar nuestra [aplicación web gratuita](https://products.aspose.app/slides/conversion/ppt-to-svg) en la que implementamos la función de conversión de PPT a SVG de Aspose.Slides para .NET.

{{% /alert %}} 

Este código de muestra en C# te muestra cómo convertir PowerPoint a SVG utilizando Aspose.Slides: 

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

## Ver También 

Este artículo también cubre estos temas. Los códigos son los mismos que los anteriores.

_Formato_: **PowerPoint**
- [C# PowerPoint a SVG Código](#csharp-powerpoint-to-svg)
- [C# PowerPoint a SVG API](#csharp-powerpoint-to-svg)
- [C# PowerPoint a SVG Programáticamente](#csharp-powerpoint-to-svg)
- [C# PowerPoint a SVG Biblioteca](#csharp-powerpoint-to-svg)
- [C# Guardar PowerPoint como SVG](#csharp-powerpoint-to-svg)
- [C# Generar SVG desde PowerPoint](#csharp-powerpoint-to-svg)
- [C# Crear SVG desde PowerPoint](#csharp-powerpoint-to-svg)
- [C# PowerPoint a SVG Conversor](#csharp-powerpoint-to-svg)

_Formato_: **PPT**
- [C# PPT a SVG Código](#csharp-ppt-to-svg)
- [C# PPT a SVG API](#csharp-ppt-to-svg)
- [C# PPT a SVG Programáticamente](#csharp-ppt-to-svg)
- [C# PPT a SVG Biblioteca](#csharp-ppt-to-svg)
- [C# Guardar PPT como SVG](#csharp-ppt-to-svg)
- [C# Generar SVG desde PPT](#csharp-ppt-to-svg)
- [C# Crear SVG desde PPT](#csharp-ppt-to-svg)
- [C# PPT a SVG Conversor](#csharp-ppt-to-svg)

_Formato_: **PPTX**
- [C# PPTX a SVG Código](#csharp-pptx-to-svg)
- [C# PPTX a SVG API](#csharp-pptx-to-svg)
- [C# PPTX a SVG Programáticamente](#csharp-pptx-to-svg)
- [C# PPTX a SVG Biblioteca](#csharp-pptx-to-svg)
- [C# Guardar PPTX como SVG](#csharp-pptx-to-svg)
- [C# Generar SVG desde PPTX](#csharp-pptx-to-svg)
- [C# Crear SVG desde PPTX](#csharp-pptx-to-svg)
- [C# PPTX a SVG Conversor](#csharp-pptx-to-svg)

_Formato_: **ODP**
- [C# ODP a SVG Código](#csharp-odp-to-svg)
- [C# ODP a SVG API](#csharp-odp-to-svg)
- [C# ODP a SVG Programáticamente](#csharp-odp-to-svg)
- [C# ODP a SVG Biblioteca](#csharp-odp-to-svg)
- [C# Guardar ODP como SVG](#csharp-odp-to-svg)
- [C# Generar SVG desde ODP](#csharp-odp-to-svg)
- [C# Crear SVG desde ODP](#csharp-odp-to-svg)
- [C# ODP a SVG Conversor](#csharp-odp-to-svg)