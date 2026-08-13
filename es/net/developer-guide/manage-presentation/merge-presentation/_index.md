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
description: "Fusiona fácilmente presentaciones PowerPoint (PPT, PPTX) y OpenDocument (ODP) con Aspose.Slides para .NET, optimizando tu flujo de trabajo."
---
## **Resumen**

Aspose.Slides le permite fusionar presentaciones clonando diapositivas de una presentación a otra. Este artículo explica cómo fusionar presentaciones completas o diapositivas seleccionadas, utilizar una diapositiva maestra o un diseño específico durante la fusión, manejar presentaciones con diferentes tamaños de diapositiva y añadir diapositivas fusionadas a una sección de la presentación. También cubre notas prácticas relacionadas con el contenido fusionado, incluidas las notas del orador, los comentarios, los archivos de origen protegidos con contraseña y el uso de hilos.

## **Optimice la fusión de presentaciones**

Con [Aspose.Slides for .NET](https://products.aspose.com/slides/es/net/), combine sin problemas presentaciones de PowerPoint conservando estilos, diseños y todos los elementos. A diferencia de otras herramientas, Aspose.Slides une presentaciones sin comprometer la calidad ni perder datos. Fusiona presentaciones completas, diapositivas específicas e incluso diferentes formatos de archivo (PPT a PPTX, etc.).

### **Características de fusión**

- **Fusión completa de presentación:** Reúna todas las diapositivas en un solo archivo.  
- **Fusión de diapositivas específicas:** Elija y combine diapositivas seleccionadas.  
- **Fusión entre formatos:** Integre presentaciones de diferentes formatos, manteniendo la integridad.  

{{% alert title="Consejo" color="info" %}}  

¿Busca una herramienta **gratuita en línea** y rápida para **fusionar presentaciones PowerPoint**? Pruebe el [**Aspose PowerPoint Merger**](https://products.aspose.app/slides/es/merger).  

- **Fusione archivos PowerPoint fácilmente**: Combine varias presentaciones **PPT, PPTX, ODP** en un solo archivo.  
- **Admite diferentes formatos**: Fusiona **PPT a PPTX**, **PPTX a ODP**, y más.  
- **No requiere instalación**: Funciona directamente en su navegador, rápido y seguro.  

[![Merge PowerPoint Files Online](slides-merger.png)](https://products.aspose.app/slides/es/merger)  

¡Comience a fusionar sus archivos PowerPoint con la **herramienta gratuita en línea de Aspose** hoy mismo!  

{{% /alert %}}

## **Fusión de presentaciones**

Cuando [fusiona una presentación con otra](https://products.aspose.com/slides/es/net/merger/ppt/), está combinando efectivamente sus diapositivas en una sola presentación para obtener un archivo. 

{{% alert title="Información" color="info" %}}

La mayoría de los programas de presentación (PowerPoint o OpenOffice) carecen de funciones que permitan a los usuarios combinar presentaciones de esta manera. 

Sin embargo, [**Aspose.Slides for .NET**](https://products.aspose.com/slides/es/net/) le permite fusionar presentaciones de diferentes maneras. Puede fusionar presentaciones con todas sus formas, estilos, textos, formatos, comentarios, animaciones, etc., sin preocuparse por la pérdida de calidad o datos. 

**Ver también**

[Clone Slides](https://docs.aspose.com/slides/es/net/cloning-commenting-and-manipulating-slides/#cloning-commentingandmanipulatingslides-cloningslides)*.* 

{{% /alert %}}

### **Qué se puede fusionar**

Con Aspose.Slides, puede fusionar 

* presentaciones completas. Todas las diapositivas de las presentaciones terminan en una sola presentación  
* diapositivas específicas. Las diapositivas seleccionadas terminan en una sola presentación  
* presentaciones en un formato (PPT a PPT, PPTX a PPTX, etc.) y en diferentes formatos (PPT a PPTX, PPTX a ODP, etc.) entre sí.  

{{% alert title="Nota" color="warning" %}} 

Además de las presentaciones, Aspose.Slides le permite fusionar otros archivos:

* [Imágenes](https://products.aspose.com/slides/es/net/merger/image-to-image/), como [JPG a JPG](https://products.aspose.com/slides/es/net/merger/jpg-to-jpg/) o [PNG a PNG](https://products.aspose.com/slides/es/net/merger/png-to-png/)  
* [Documentos](https://products.aspose.com/slides/es/net/merger/pdf-to-pdf/), como [PDF a PDF](https://products.aspose.com/slides/es/net/merger/pdf-to-pdf/) o [HTML a HTML](https://products.aspose.com/slides/es/net/merger/html-to-html/)  
* Y dos archivos diferentes como [imagen a PDF](https://products.aspose.com/slides/es/net/merger/image-to-pdf/) o [JPG a PDF](https://products.aspose.com/slides/es/net/merger/jpg-to-pdf/) o [TIFF a PDF](https://products.aspose.com/slides/es/net/merger/tiff-to-pdf/).  

{{% /alert %}}

### **Opciones de fusión**

Puede aplicar opciones que determinan si

* cada diapositiva en la presentación de salida conserva un estilo único  
* se utiliza un estilo específico para todas las diapositivas en la presentación de salida.  

Para fusionar presentaciones, Aspose.Slides proporciona métodos [AddClone](https://reference.aspose.com/slides/es/net/aspose.slides/islidecollection/methods/addclone) (de la interfaz [ISlideCollection](https://reference.aspose.com/slides/es/net/aspose.slides/islidecollection)). Hay varias implementaciones de los métodos `AddClone` que definen los parámetros del proceso de fusión de la presentación. Cada objeto Presentation tiene una colección [Slides](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/properties/slides), por lo que puede llamar a un método `AddClone` desde la presentación a la que desea fusionar diapositivas. 

El método `AddClone` devuelve un objeto `ISlide`, que es una copia de la diapositiva origen. Las diapositivas en una presentación de salida son simplemente una copia de las diapositivas de origen. Por lo tanto, puede modificar las diapositivas resultantes (por ejemplo, aplicar estilos, opciones de formato o diseños) sin preocuparse de que las presentaciones de origen se vean afectadas. 

## **Fusionar presentaciones** 

Aspose.Slides ofrece el método [**AddClone (ISlide)**](https://reference.aspose.com/slides/es/net/aspose.slides/islidecollection/methods/addclone) que permite combinar diapositivas mientras estas conservan sus diseños y estilos (parámetros predeterminados). 

Este código C# le muestra cómo fusionar presentaciones:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **Fusionar presentaciones con una diapositiva maestra**

Aspose.Slides ofrece el método [**AddClone (ISlide, IMasterSlide, Boolean)**](https://reference.aspose.com/slides/es/net/aspose.slides.islidecollection/addclone/methods/2) que permite combinar diapositivas aplicando una plantilla de diapositiva maestra. De este modo, si es necesario, puede cambiar el estilo de las diapositivas en la presentación de salida. 

Este código C# demuestra la operación descrita:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

{{% alert title="Nota" color="warning" %}} 

El diseño de diapositiva para la diapositiva maestra se determina automáticamente. Cuando no se puede determinar un diseño apropiado, si el parámetro booleano `allowCloneMissingLayout` del método `AddClone` está establecido en true, se utiliza el diseño de la diapositiva origen. De lo contrario, se lanzará una [PptxEditException](https://reference.aspose.com/slides/es/net/aspose.slides/pptxeditexception). 

{{% /alert %}}

Si desea que las diapositivas en la presentación de salida tengan un diseño de diapositiva diferente, utilice el método [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/es/net/aspose.slides.islidecollection/addclone/methods/1) en su lugar al fusionar. 

## **Fusionar diapositivas específicas de presentaciones**

Fusionar diapositivas específicas de varias presentaciones es útil para crear decks personalizados. Aspose.Slides for .NET le permite seleccionar e importar solo las diapositivas que necesita. La API conserva el formato, el diseño y el estilo de las diapositivas originales. 

El siguiente código C# crea una nueva presentación, añade diapositivas de título de dos presentaciones distintas y guarda el resultado en un archivo:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

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
```cs
using Aspose.Slides;

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

## **Fusionar presentaciones con un diseño de diapositiva**

Este código C# le muestra cómo combinar diapositivas de presentaciones aplicando el diseño de diapositiva que prefiera para obtener una sola presentación de salida:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

{{% alert title="Nota" color="warning" %}} 

Fusionar presentaciones con diferentes tamaños de diapositiva no genera un error, pero las diapositivas fusionadas adoptan el tamaño de diapositiva de la presentación de destino mientras sus formas conservan sus posiciones y tamaños originales, por lo que el contenido puede acabar descolocado o fuera de los límites de la diapositiva. 

{{% /alert %}}

Para fusionar 2 presentaciones con diferentes tamaños de diapositiva y mantener su contenido correctamente distribuido, cambie el tamaño de una de las presentaciones para que coincida con el de la otra. 

Este código de ejemplo demuestra la operación descrita:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

Este código C# le muestra cómo fusionar una diapositiva específica a una sección en una presentación:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

{{% alert title="Consejo" color="info" %}}

Aspose ofrece una [aplicación web GRATUITA de Collage](https://products.aspose.app/slides/es/collage). Con este servicio en línea, puede fusionar [JPG a JPG](https://products.aspose.app/slides/es/collage/jpg) o imágenes PNG a PNG, crear [rejillas de fotos](https://products.aspose.app/slides/es/collage/photo-grid), etc. 

{{% /alert %}}

## **Preguntas frecuentes**

### ¿Se conservan las notas del orador durante la fusión?

Sí. Al clonar diapositivas, Aspose.Slides transfiere todos los elementos de la diapositiva, incluidas las notas, el formato y las animaciones.

### ¿Se transfieren los comentarios y sus autores?

Los comentarios, como parte del contenido de la diapositiva, se copian con la diapositiva. Las etiquetas de autor de los comentarios se conservan como objetos de comentario en la presentación resultante.

### ¿Qué ocurre si la presentación de origen está protegida con contraseña?

Debe [abrirse con la contraseña](/slides/es/net/password-protected-presentation/) mediante [LoadOptions.Password](https://reference.aspose.com/slides/es/net/aspose.slides/loadoptions/password/); después de cargarla, esas diapositivas pueden clonarse de forma segura en un archivo de destino sin protección (o también protegido).

### ¿Qué tan segura es la fusión respecto a subprocesos?

No utilice la misma instancia de [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/) desde [múltiples hilos](/slides/es/net/multithreading/). La regla recomendada es “un documento — un hilo”; diferentes archivos pueden procesarse en paralelo en hilos separados.