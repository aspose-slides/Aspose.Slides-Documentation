---
title: Fusión eficiente de presentaciones en .NET
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

## **Optimice la fusión de sus presentaciones**

Con [Aspose.Slides for .NET](https://products.aspose.com/slides/net/), combine presentaciones de PowerPoint de forma fluida mientras preserva estilos, diseños y todos los elementos. A diferencia de otras herramientas, Aspose.Slides combina presentaciones sin comprometer la calidad ni perder datos. Fusiona presentaciones completas, diapositivas específicas e incluso diferentes formatos de archivo (PPT a PPTX, etc.).

### **Funciones de fusión**

- **Fusión completa de presentación:** Reúne todas las diapositivas en un solo archivo.
- **Fusión de diapositiva específica:** Seleccione y combine las diapositivas elegidas.
- **Fusión cruzada de formatos:** Integre presentaciones con diferentes formatos, manteniendo la integridad.

{{% alert title="Tip" color="primary" %}}  

¿Busca una herramienta **online gratuita** y rápida para **fusionar presentaciones PowerPoint**? Pruebe el [**Aspose PowerPoint Merger**](https://products.aspose.app/slides/merger).  

- **Fusión fácil de archivos PowerPoint**: Combine múltiples presentaciones **PPT, PPTX, ODP** en un solo archivo.  
- **Soporta diferentes formatos**: Fusiona **PPT a PPTX**, **PPTX a ODP**, y más.  
- **Sin necesidad de instalación**: Funciona directamente en su navegador, rápido y seguro.  

[![Merge PowerPoint Files Online](slides-merger.png)](https://products.aspose.app/slides/merger)  

¡Comience a fusionar sus archivos PowerPoint con la **herramienta online gratuita de Aspose** hoy!  

{{% /alert %}}

## **Fusión de presentaciones**

Cuando [fusiona una presentación con otra](https://products.aspose.com/slides/net/merger/ppt/), está combinando efectivamente sus diapositivas en una sola presentación para obtener un único archivo. 

{{% alert title="Info" color="info" %}}

La mayoría de los programas de presentación (PowerPoint u OpenOffice) carecen de funciones que permitan a los usuarios combinar presentaciones de esta manera. 

[**Aspose.Slides for .NET**](https://products.aspose.com/slides/net/) , sin embargo, le permite fusionar presentaciones de diferentes maneras. Puede fusionar presentaciones con todas sus formas, estilos, textos, formatos, comentarios, animaciones, etc., sin preocuparse por la pérdida de calidad o datos. 

**Ver también**

[Clonar diapositivas](https://docs.aspose.com/slides/net/cloning-commenting-and-manipulating-slides/#cloning-commentingandmanipulatingslides-cloningslides)*.* 

{{% /alert %}}

### **Qué se puede fusionar**

Con Aspose.Slides, puede fusionar 

* toda presentación completa. Todas las diapositivas de las presentaciones terminan en una sola presentación
* diapositivas específicas. Las diapositivas seleccionadas terminan en una sola presentación
* presentaciones en un mismo formato (PPT a PPT, PPTX a PPTX, etc.) y en diferentes formatos (PPT a PPTX, PPTX a ODP, etc.) entre sí. 

{{% alert title="Note" color="warning" %}} 

Además de presentaciones, Aspose.Slides le permite fusionar otros archivos:

* [Imágenes](https://products.aspose.com/slides/net/merger/image-to-image/), como [JPG a JPG](https://products.aspose.com/slides/net/merger/jpg-to-jpg/) o [PNG a PNG](https://products.aspose.com/slides/net/merger/png-to-png/)
* Documentos, como [PDF a PDF](https://products.aspose.com/slides/net/merger/pdf-to-pdf/) o [HTML a HTML](https://products.aspose.com/slides/net/merger/html-to-html/)
* Y dos archivos diferentes como [imagen a PDF](https://products.aspose.com/slides/net/merger/image-to-pdf/) o [JPG a PDF](https://products.aspose.com/slides/net/merger/jpg-to-pdf/) o [TIFF a PDF](https://products.aspose.com/slides/net/merger/tiff-to-pdf/).

{{% /alert %}}

### **Opciones de fusión**

Puede aplicar opciones que determinan si

* cada diapositiva en la presentación de salida conserva un estilo único
* se utiliza un estilo específico para todas las diapositivas en la presentación de salida. 

Para fusionar presentaciones, Aspose.Slides proporciona métodos [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone) (de la interfaz [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection)). Hay varias implementaciones de los métodos `AddClone` que definen los parámetros del proceso de fusión de presentaciones. Cada objeto Presentation tiene una colección [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides), por lo que puede llamar a un método `AddClone` desde la presentación a la que desea fusionar diapositivas. 

El método `AddClone` devuelve un objeto `ISlide`, que es un clon de la diapositiva origen. Las diapositivas en una presentación de salida son simplemente una copia de las diapositivas de origen. Por lo tanto, puede modificar las diapositivas resultantes (por ejemplo, aplicar estilos, opciones de formato o diseños) sin preocuparse de que las presentaciones origen se vean afectadas. 

## **Fusionar presentaciones** 

Aspose.Slides proporciona el método [**AddClone (ISlide)**](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone) que le permite combinar diapositivas mientras estas conservan sus diseños y estilos (parámetros predeterminados). 

Este código C# le muestra cómo fusionar presentaciones:
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

Aspose.Slides proporciona el método [**AddClone (ISlide, IMasterSlide, Boolean)**](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/2) que le permite combinar diapositivas aplicando una plantilla de maestro de diapositivas. De este modo, si es necesario, puede cambiar el estilo de las diapositivas en la presentación de salida. 

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

El diseño de diapositiva para el maestro se determina automáticamente. Cuando no se puede determinar un diseño apropiado, si el parámetro booleano `allowCloneMissingLayout` del método `AddClone` se establece en true, se utiliza el diseño de la diapositiva origen. De lo contrario, se lanzará una [PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception). 

{{% /alert %}}

Si desea que las diapositivas en la presentación de salida tengan un diseño de diapositiva diferente, utilice el método [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/1) en su lugar al fusionar. 

## **Fusionar diapositivas específicas de presentaciones**

Fusionar diapositivas específicas de múltiples presentaciones es útil para crear colecciones de diapositivas personalizadas. Aspose.Slides for .NET le permite seleccionar e importar solo las diapositivas que necesita. La API preserva el formato, el diseño y el aspecto de las diapositivas originales.

El siguiente código C# crea una nueva presentación, agrega diapositivas de título de dos presentaciones diferentes y guarda el resultado en un archivo:
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

Este código C# le muestra cómo combinar diapositivas de presentaciones aplicando el diseño de diapositiva que prefiera para obtener una presentación de salida única:
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

Para fusionar 2 presentaciones con diferentes tamaños de diapositiva, debe cambiar el tamaño de una de ellas para que coincida con el tamaño de la otra. 

El código de ejemplo muestra la operación descrita:
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


## **Fusionar diapositivas en una sección de la presentación**

Este código C# le muestra cómo fusionar una diapositiva específica en una sección de una presentación:
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


La diapositiva se agrega al final de la sección. 

{{% alert title="Tip" color="primary" %}}

Aspose ofrece una [aplicación web GRATUITA de Collage](https://products.aspose.app/slides/collage). Con este servicio online, puede fusionar imágenes [JPG a JPG](https://products.aspose.app/slides/collage/jpg) o PNG a PNG, crear [cuadrículas de fotos](https://products.aspose.app/slides/collage/photo-grid), y mucho más. 

{{% /alert %}}

## **Preguntas frecuentes**

**¿Se preservan las notas del presentador durante la fusión?**

Sí. Al clonar diapositivas, Aspose.Slides transfiere todos los elementos de la diapositiva, incluidas las notas, el formato y las animaciones.

**¿Se transfieren los comentarios y sus autores?**

Los comentarios, como parte del contenido de la diapositiva, se copian con la diapositiva. Las etiquetas de autor del comentario se conservan como objetos de comentario en la presentación resultante.

**¿Qué ocurre si la presentación origen está protegida con contraseña?**

Debe ser [abierta con la contraseña](/slides/es/net/password-protected-presentation/) mediante [LoadOptions.Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/); después de cargarla, esas diapositivas pueden clonarse de forma segura en un archivo de destino sin protección (o también protegido).

**¿Qué tan segura es la fusión respecto a hilos?**

No utilice la misma instancia de [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) desde [múltiples hilos](/slides/es/net/multithreading/). La regla recomendada es "un documento — un hilo"; diferentes archivos pueden procesarse en paralelo en hilos separados.