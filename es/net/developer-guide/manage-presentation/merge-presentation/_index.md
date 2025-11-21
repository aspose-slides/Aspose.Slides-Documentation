---
title: Fusionar presentaciones de forma eficiente en .NET
linktitle: Fusionar presentaciones
type: docs
weight: 40
url: /es/net/merge-presentation/
keywords:
- fusionar PowerPoint
- fusionar presentaciones
- fusionar diapositivas
- fusionar PPT
- fusionar PPTX
- fusionar ODP
- combinar PowerPoint
- combinar presentaciones
- combinar diapositivas
- combinar PPT
- combinar PPTX
- combinar ODP
- .NET
- C#
- Aspose.Slides
description: "Fusiona sin esfuerzo presentaciones PowerPoint (PPT, PPTX) y OpenDocument (ODP) con Aspose.Slides para .NET, optimizando tu flujo de trabajo."
---

## **Optimiza la fusión de presentaciones**

Con [Aspose.Slides for .NET](https://products.aspose.com/slides/net/), combina sin problemas presentaciones de PowerPoint mientras preservas estilos, diseños y todos los elementos. A diferencia de otras herramientas, Aspose.Slides combina presentaciones sin comprometer la calidad ni perder datos. Fusiona presentaciones completas, diapositivas específicas e incluso diferentes formatos de archivo (PPT a PPTX, etc.).

### **Características de fusión**

- **Fusión completa de presentación:** Agrupa todas las diapositivas en un solo archivo.  
- **Fusión de diapositivas específicas:** Selecciona y combina diapositivas elegidas.  
- **Fusión entre formatos:** Integra presentaciones de diferentes formatos, manteniendo la integridad.  

{{% alert title="Tip" color="primary" %}}  

¿Buscas una herramienta rápida y **gratuita en línea** para **combinar presentaciones de PowerPoint**? Prueba el [**Aspose PowerPoint Merger**](https://products.aspose.app/slides/merger).  

- **Fusiona archivos PowerPoint fácilmente**: Combina múltiples presentaciones **PPT, PPTX, ODP** en un solo archivo.  
- **Admite diferentes formatos**: Fusiona **PPT a PPTX**, **PPTX a ODP**, y más.  
- **Sin instalación requerida**: Funciona directamente en tu navegador, rápido y seguro.  

[![Merge PowerPoint Files Online](slides-merger.png)](https://products.aspose.app/slides/merger)  

¡Comienza a fusionar tus archivos PowerPoint con la **herramienta gratuita en línea de Aspose** hoy!  

{{% /alert %}}

## **Fusión de presentaciones**

Cuando [fusionas una presentación con otra](https://products.aspose.com/slides/net/merger/ppt/), estás combinando efectivamente sus diapositivas en una sola presentación para obtener un único archivo. 

{{% alert title="Info" color="info" %}}

La mayoría de los programas de presentación (PowerPoint u OpenOffice) carecen de funciones que permitan a los usuarios combinar presentaciones de esta manera. 

[**Aspose.Slides for .NET**](https://products.aspose.com/slides/net/), sin embargo, te permite fusionar presentaciones de diferentes maneras. Puedes fusionar presentaciones con todas sus formas, estilos, textos, formato, comentarios, animaciones, etc., sin preocuparte por la pérdida de calidad o datos. 

**Ver también**

[Clonar diapositivas](https://docs.aspose.com/slides/net/cloning-commenting-and-manipulating-slides/#cloning-commentingandmanipulatingslides-cloningslides)*.* 

{{% /alert %}}

### **Qué se puede fusionar**

Con Aspose.Slides, puedes fusionar 

* presentaciones completas. Todas las diapositivas de las presentaciones terminan en una sola presentación  
* diapositivas específicas. Las diapositivas seleccionadas terminan en una sola presentación  
* presentaciones en un formato (PPT a PPT, PPTX a PPTX, etc.) y en diferentes formatos (PPT a PPTX, PPTX a ODP, etc.) entre sí.  

{{% alert title="Note" color="warning" %}} 

Además de presentaciones, Aspose.Slides permite fusionar otros archivos:

* [Imágenes](https://products.aspose.com/slides/net/merger/image-to-image/), como [JPG a JPG](https://products.aspose.com/slides/net/merger/jpg-to-jpg/) o [PNG a PNG](https://products.aspose.com/slides/net/merger/png-to-png/)  
* Documentos, como [PDF a PDF](https://products.aspose.com/slides/net/merger/pdf-to-pdf/) o [HTML a HTML](https://products.aspose.com/slides/net/merger/html-to-html/)  
* Y dos archivos diferentes, como [imagen a PDF](https://products.aspose.com/slides/net/merger/image-to-pdf/), [JPG a PDF](https://products.aspose.com/slides/net/merger/jpg-to-pdf/) o [TIFF a PDF](https://products.aspose.com/slides/net/merger/tiff-to-pdf/).  

{{% /alert %}}

### **Opciones de fusión**

Puedes aplicar opciones que determinen si

* cada diapositiva de la presentación de salida conserva un estilo único  
* se utiliza un estilo específico para todas las diapositivas de la presentación de salida.  

Para fusionar presentaciones, Aspose.Slides ofrece los métodos [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone) (de la interfaz [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection)). Existen varias implementaciones de los métodos `AddClone` que definen los parámetros del proceso de fusión de presentaciones. Cada objeto Presentation tiene una colección [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides), por lo que puedes llamar a un método `AddClone` desde la presentación en la que deseas fusionar diapositivas. 

El método `AddClone` devuelve un objeto `ISlide`, que es una clonación de la diapositiva origen. Las diapositivas en una presentación de salida son simplemente una copia de las diapositivas de origen. Por lo tanto, puedes modificar las diapositivas resultantes (por ejemplo, aplicar estilos, opciones de formato o diseños) sin preocuparte de que las presentaciones de origen se vean afectadas. 

## **Fusionar presentaciones** 

Aspose.Slides ofrece el método [**AddClone (ISlide)**](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone) que permite combinar diapositivas mientras estas conservan sus diseños y estilos (parámetros predeterminados). 

Este código C# muestra cómo fusionar presentaciones:
```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    foreach (ISlide slide in pres2.Slides)
    {
        pres1.Slides.AddClone(slide);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```


## **Fusionar presentaciones con maestro de diapositivas** 

Aspose.Slides ofrece el método [**AddClone (ISlide, IMasterSlide, Boolean)**](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/2) que permite combinar diapositivas aplicando una plantilla de maestro de diapositivas. De esta forma, si es necesario, puedes cambiar el estilo de las diapositivas en la presentación de salida. 

Este código en C# demuestra la operación descrita:
```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    foreach (ISlide slide in pres2.Slides)
    {
        pres1.Slides.AddClone(slide, pres2.Masters[0], allowCloneMissingLayout: true);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```


{{% alert title="Note" color="warning" %}} 

El diseño de diapositiva para el maestro de diapositivas se determina automáticamente. Cuando no se puede determinar un diseño apropiado, si el parámetro booleano `allowCloneMissingLayout` del método `AddClone` está configurado en true, se utiliza el diseño de la diapositiva origen. De lo contrario, se lanzará [PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception). 

{{% /alert %}}

Si deseas que las diapositivas en la presentación de salida tengan un diseño de diapositiva diferente, usa el método [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/1) al fusionar. 

## **Fusionar diapositivas específicas de presentaciones** 

Fusionar diapositivas específicas de varias presentaciones es útil para crear juegos de diapositivas personalizados. Aspose.Slides for .NET te permite seleccionar e importar solo las diapositivas que necesitas. La API conserva el formato, diseño y estilo de las diapositivas originales. 

El siguiente código C# crea una nueva presentación, agrega diapositivas de título de dos presentaciones distintas y guarda el resultado en un archivo:
```cs
using (Presentation presentation = new Presentation())
using (Presentation presentation1 = new Presentation("presentation1.pptx"))
using (Presentation presentation2 = new Presentation("presentation2.pptx"))
{
    presentation.Slides.RemoveAt(0);

    ISlide slide1 = GetTitleSlide(presentation1);

    if (slide1 != null)
        presentation.Slides.AddClone(slide1);

    ISlide slide2 = GetTitleSlide(presentation2);

    if (slide2 != null)
        presentation.Slides.AddClone(slide2);

    presentation.Save("combined.pptx", SaveFormat.Pptx);
}
```

```cs
static ISlide GetTitleSlide(IPresentation presentation)
{
    foreach (ISlide slide in presentation.Slides)
    {
        if (slide.LayoutSlide.LayoutType == SlideLayoutType.Title)
        {
            return slide;
        }
    }
    return null;
}
```


## **Fusionar presentaciones con diseño de diapositiva** 

Este código C# muestra cómo combinar diapositivas de presentaciones aplicando tu diseño de diapositiva preferido para obtener una única presentación de salida:
```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    foreach (ISlide slide in pres2.Slides)
    {
        pres1.Slides.AddClone(slide, pres2.LayoutSlides[0]);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```


## **Fusionar presentaciones con diferentes tamaños de diapositiva** 

{{% alert title="Note" color="warning" %}} 

No se pueden fusionar presentaciones con diferentes tamaños de diapositiva. 

{{% /alert %}}

Para fusionar 2 presentaciones con diferentes tamaños de diapositiva, debes redimensionar una de ellas para que su tamaño coincida con el de la otra presentación. 

Este código de ejemplo demuestra la operación descrita:
```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
   pres2 = new Presentation("pres2.pptx"))
{
   pres2.SlideSize.SetSize(pres1.SlideSize.Size.Width, pres1.SlideSize.Size.Height, SlideSizeScaleType.EnsureFit);
 
   foreach (ISlide slide in pres2.Slides)
   {
       pres1.Slides.AddClone(slide);
   }
 
   pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```


## **Fusionar diapositivas a una sección de la presentación** 

Este código C# muestra cómo fusionar una diapositiva específica a una sección en una presentación:
```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    for (var index = 0; index < pres2.Slides.Count; index++)
    {
        ISlide slide = pres2.Slides[index];
        pres1.Slides.AddClone(slide, pres1.Sections[0]);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```


La diapositiva se añade al final de la sección. 

{{% alert title="Tip" color="primary" %}}

Aspose ofrece una [aplicación web GRATUITA Collage](https://products.aspose.app/slides/collage). Con este servicio en línea, puedes fusionar [JPG a JPG](https://products.aspose.app/slides/collage/jpg) o PNG a PNG, crear [cuadrículas de fotos](https://products.aspose.app/slides/collage/photo-grid), etc. 

{{% /alert %}}

## **FAQ**

**¿Se conservan las notas del orador durante la fusión?**

Sí. Al clonar diapositivas, Aspose.Slides transfiere todos los elementos de la diapositiva, incluidas notas, formato y animaciones.

**¿Se transfieren los comentarios y sus autores?**

Los comentarios, como parte del contenido de la diapositiva, se copian con la diapositiva. Las etiquetas de autor de los comentarios se conservan como objetos de comentario en la presentación resultante.

**¿Qué sucede si la presentación origen está protegida con contraseña?**

Debe ser [abierta con la contraseña](/slides/es/net/password-protected-presentation/) mediante [LoadOptions.Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/); tras la carga, esas diapositivas pueden clonarse de forma segura en un archivo destino sin protección (o también protegido).

**¿Qué tan segura es la fusión respecto a hilos?**

No utilice la misma instancia de [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) desde [múltiples hilos](/slides/es/net/multithreading/). La regla recomendada es "un documento — un hilo"; diferentes archivos pueden procesarse en paralelo en hilos separados.