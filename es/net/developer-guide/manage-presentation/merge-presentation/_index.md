---
title: Combinar presentaciones de forma eficiente en .NET
linktitle: Combinar presentaciones
type: docs
weight: 40
url: /es/net/merge-presentation/
keywords:
- combinar PowerPoint
- combinar presentaciones
- combinar diapositivas
- combinar PPT
- combinar PPTX
- combinar ODP
- combinar PowerPoint
- combinar presentaciones
- combinar diapositivas
- combinar PPT
- combinar PPTX
- combinar ODP
- .NET
- C#
- Aspose.Slides
description: "Fusiona sin esfuerzo presentaciones de PowerPoint (PPT, PPTX) y OpenDocument (ODP) con Aspose.Slides para .NET, simplificando tu flujo de trabajo."
---

## **Optimizar la combinación de presentaciones**

Con [Aspose.Slides for .NET](https://products.aspose.com/slides/net/), combine sin problemas presentaciones de PowerPoint preservando estilos, diseños y todos los elementos. A diferencia de otras herramientas, Aspose.Slides combina presentaciones sin comprometer la calidad ni perder datos. Fusiona presentaciones completas, diapositivas específicas e incluso diferentes formatos de archivo (PPT a PPTX, etc.).

### **Funciones de combinación**

- **Fusión completa de presentación:** Reúne todas las diapositivas en un solo archivo.
- **Fusión de diapositiva específica:** Elige y combina diapositivas seleccionadas.
- **Fusión entre formatos:** Integra presentaciones de diferentes formatos, manteniendo la integridad.

{{% alert title="Tip" color="primary" %}}  

¿Busca una herramienta rápida y **gratuita en línea** para **combinar presentaciones de PowerPoint**? Pruebe el [**Aspose PowerPoint Merger**](https://products.aspose.app/slides/merger).  

- **Combine archivos de PowerPoint fácilmente**: Combine varias presentaciones **PPT, PPTX, ODP** en un solo archivo.  
- **Admite diferentes formatos**: Fusiona **PPT a PPTX**, **PPTX a ODP**, y más.  
- **No requiere instalación**: Funciona directamente en su navegador, rápido y seguro.  

[![Merge PowerPoint Files Online](slides-merger.png)](https://products.aspose.app/slides/merger)  

Comience a combinar sus archivos de PowerPoint con la **herramienta gratuita en línea de Aspose** hoy!  

{{% /alert %}}

## **Combinación de presentaciones**

Cuando [combina una presentación con otra](https://products.aspose.com/slides/net/merger/ppt/), está combinando efectivamente sus diapositivas en una sola presentación para obtener un archivo. 

{{% alert title="Info" color="info" %}}

La mayoría de los programas de presentación (PowerPoint u OpenOffice) carecen de funciones que permitan a los usuarios combinar presentaciones de esta manera. 

[**Aspose.Slides for .NET**](https://products.aspose.com/slides/net/) , sin embargo, le permite combinar presentaciones de diferentes maneras. Puede combinar presentaciones con todas sus formas, estilos, textos, formato, comentarios, animaciones, etc., sin preocuparse por la pérdida de calidad o datos. 

**Ver también**

[Clone Slides](https://docs.aspose.com/slides/net/cloning-commenting-and-manipulating-slides/#cloning-commentingandmanipulatingslides-cloningslides)*.* 

{{% /alert %}}

### **Qué se puede combinar**

Con Aspose.Slides, puede combinar  

* presentaciones completas. Todas las diapositivas de las presentaciones terminan en una sola presentación  
* diapositivas específicas. Las diapositivas seleccionadas terminan en una sola presentación  
* presentaciones en un mismo formato (PPT a PPT, PPTX a PPTX, etc.) y en formatos diferentes (PPT a PPTX, PPTX a ODP, etc.) entre sí.  

{{% alert title="Note" color="warning" %}} 

Además de presentaciones, Aspose.Slides le permite combinar otros archivos:

* [Imágenes](https://products.aspose.com/slides/net/merger/image-to-image/), como [JPG a JPG](https://products.aspose.com/slides/net/merger/jpg-to-jpg/) o [PNG a PNG](https://products.aspose.com/slides/net/merger/png-to-png/)  
* Documentos, como [PDF a PDF](https://products.aspose.com/slides/net/merger/pdf-to-pdf/) o [HTML a HTML](https://products.aspose.com/slides/net/merger/html-to-html/)  
* Y dos archivos diferentes como [imagen a PDF](https://products.aspose.com/slides/net/merger/image-to-pdf/), JPG a PDF o [TIFF a PDF](https://products.aspose.com/slides/net/merger/tiff-to-pdf/).  

{{% /alert %}}

### **Opciones de combinación**

Puede aplicar opciones que determinen si  

* cada diapositiva en la presentación de salida mantiene un estilo único  
* se utiliza un estilo específico para todas las diapositivas en la presentación de salida.  

Para combinar presentaciones, Aspose.Slides proporciona métodos [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone) (de la interfaz [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection)). Hay varias implementaciones de los métodos `AddClone` que definen los parámetros del proceso de combinación. Cada objeto Presentation tiene una colección [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides), por lo que puede llamar a un método `AddClone` desde la presentación a la que desea combinar diapositivas. 

El método `AddClone` devuelve un objeto `ISlide`, que es una copia de la diapositiva fuente. Las diapositivas en una presentación de salida son simplemente una copia de las diapositivas de la fuente. Por lo tanto, puede modificar las diapositivas resultantes (por ejemplo, aplicar estilos, opciones de formato o diseños) sin preocuparse de que las presentaciones origen se vean afectadas. 

## **Combinar presentaciones** 

Aspose.Slides proporciona el método [**AddClone (ISlide)**](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone) que permite combinar diapositivas mientras estas conservan sus diseños y estilos (parámetros predeterminados). 

Este código C# le muestra cómo combinar presentaciones:
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


## **Combinar presentaciones con maestro de diapositivas**

Aspose.Slides proporciona el método [**AddClone (ISlide, IMasterSlide, Boolean)**](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/2) que permite combinar diapositivas aplicando una plantilla de maestro de diapositivas. De esta forma, si es necesario, puede cambiar el estilo de las diapositivas en la presentación de salida. 

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

El diseño de la diapositiva del maestro se determina automáticamente. Cuando no se puede determinar un diseño apropiado, si el parámetro booleano `allowCloneMissingLayout` del método `AddClone` está establecido en true, se usa el diseño de la diapositiva origen. De lo contrario, se lanzará una [PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception). 

{{% /alert %}}

Si desea que las diapositivas en la presentación de salida tengan un diseño diferente, utilice el método [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/1) en su lugar al combinar. 

## **Combinar diapositivas específicas de presentaciones**

Combinar diapositivas específicas de múltiples presentaciones es útil para crear colecciones de diapositivas personalizadas. Aspose.Slides for .NET permite seleccionar e importar solo las diapositivas que necesita. La API conserva el formato, el diseño y el estilo de las diapositivas originales.

El siguiente código C# crea una nueva presentación, añade diapositivas de título de dos presentaciones distintas y guarda el resultado en un archivo:
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


## **Combinar presentaciones con diseño de diapositiva**

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


## **Combinar presentaciones con diferentes tamaños de diapositiva**

{{% alert title="Note" color="warning" %}} 

No se pueden combinar presentaciones con tamaños de diapositiva diferentes. 

{{% /alert %}}

Para combinar 2 presentaciones con tamaños de diapositiva diferentes, debe redimensionar una de las presentaciones para que su tamaño coincida con el de la otra. 

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


## **Combinar diapositivas a una sección de presentación**

Este código C# le muestra cómo combinar una diapositiva específica a una sección en una presentación:
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

Aspose ofrece una [aplicación web GRATUITA de Collage](https://products.aspose.app/slides/collage). Con este servicio en línea, puede combinar [JPG a JPG](https://products.aspose.app/slides/collage/jpg) o PNG a PNG, crear [cuadrículas de fotos](https://products.aspose.app/slides/collage/photo-grid) y mucho más. 

{{% /alert %}}

## **FAQ**

**¿Se conservan las notas del orador durante la combinación?**

Sí. Al clonar diapositivas, Aspose.Slides transfiere todos los elementos de la diapositiva, incluidas las notas, el formato y las animaciones.

**¿Se copian los comentarios y sus autores?**

Los comentarios, como parte del contenido de la diapositiva, se copian junto con ella. Las etiquetas de autor de los comentarios se conservan como objetos de comentario en la presentación resultante.

**¿Qué ocurre si la presentación origen está protegida con contraseña?**

Debe abrirse [con la contraseña](/slides/es/net/password-protected-presentation/) mediante [LoadOptions.Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/); tras la carga, esas diapositivas pueden clonarse de forma segura en un archivo de destino sin protección (o también protegido).

**¿Qué tan seguro es el proceso de combinación respecto a hilos concurrentes?**

No utilice la misma instancia de [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) desde [múltiples hilos](/slides/es/net/multithreading/). La regla recomendada es “un documento — un hilo”; diferentes archivos pueden procesarse en paralelo en hilos separados.