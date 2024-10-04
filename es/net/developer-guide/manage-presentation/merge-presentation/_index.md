---
title: Combina Presentaciones de PowerPoint PPT, PPTX usando C#
linktitle: Combinar Presentación
type: docs
weight: 40
url: /net/merge-presentation/
keywords: "Combinar PowerPoint, PPTX, PPT, combinar PowerPoint, combinar presentación, combinar presentación, C#, Csharp, .NET"
description: "Combina o fusiona Presentaciones de PowerPoint en C# o .NET"
---

{{% alert title="Consejo" color="primary" %}}

Puede que desee consultar la aplicación **Merger gratuita en línea de Aspose** [Merger app](https://products.aspose.app/slides/merger). Permite a las personas combinar presentaciones de PowerPoint en el mismo formato (PPT a PPT, PPTX a PPTX, etc.) y combinar presentaciones en diferentes formatos (PPT a PPTX, PPTX a ODP, etc.).

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}}

## **Fusión de Presentaciones**

Cuando [fusionas una presentación con otra](https://products.aspose.com/slides/net/merger/ppt/), estás combinando efectivamente sus diapositivas en una sola presentación para obtener un archivo.

{{% alert title="Información" color="info" %}}

La mayoría de los programas de presentación (PowerPoint u OpenOffice) carecen de funciones que permitan a los usuarios combinar presentaciones de esa manera.

[**Aspose.Slides para .NET**](https://products.aspose.com/slides/net/), sin embargo, permite fusionar presentaciones de diferentes maneras. Puedes fusionar presentaciones con todas sus formas, estilos, textos, formato, comentarios, animaciones, etc. sin tener que preocuparte por la pérdida de calidad o de datos.

**Ver también**

[Clone Slides](https://docs.aspose.com/slides/net/cloning-commenting-and-manipulating-slides/#cloning-commentingandmanipulatingslides-cloningslides)*.*

{{% /alert %}}

### **Qué Puede Ser Fusionado**

Con Aspose.Slides, puedes fusionar

* presentaciones completas. Todas las diapositivas de las presentaciones terminan en una presentación
* diapositivas específicas. Las diapositivas seleccionadas terminan en una presentación
* presentaciones en un formato (PPT a PPT, PPTX a PPTX, etc.) y en diferentes formatos (PPT a PPTX, PPTX a ODP, etc.) entre sí.

{{% alert title="Nota" color="warning" %}}

Además de presentaciones, Aspose.Slides te permite fusionar otros archivos:

* [Imágenes](https://products.aspose.com/slides/net/merger/image-to-image/), como [JPG a JPG](https://products.aspose.com/slides/net/merger/jpg-to-jpg/) o [PNG a PNG](https://products.aspose.com/slides/net/merger/png-to-png/)
* Documentos, como [PDF a PDF](https://products.aspose.com/slides/net/merger/pdf-to-pdf/) o [HTML a HTML](https://products.aspose.com/slides/net/merger/html-to-html/)
* Y dos archivos diferentes, como [imagen a PDF](https://products.aspose.com/slides/net/merger/image-to-pdf/) o [JPG a PDF](https://products.aspose.com/slides/net/merger/jpg-to-pdf/) o [TIFF a PDF](https://products.aspose.com/slides/net/merger/tiff-to-pdf/).

{{% /alert %}}

### **Opciones de Fusión**

Puedes aplicar opciones que determinan si

* cada diapositiva en la presentación de salida mantiene un estilo único
* se utiliza un estilo específico para todas las diapositivas en la presentación de salida.

Para fusionar presentaciones, Aspose.Slides proporciona métodos [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone) (de la interfaz [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection)). Hay varias implementaciones de los métodos `AddClone` que definen los parámetros del proceso de fusión de presentaciones. Cada objeto Presentación tiene una colección [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides), por lo que puedes llamar al método `AddClone` desde la presentación a la que deseas fusionar diapositivas.

El método `AddClone` retorna un objeto `ISlide`, que es un clon de la diapositiva fuente. Las diapositivas en una presentación de salida son simplemente una copia de las diapositivas de la fuente. Por lo tanto, puedes realizar cambios en las diapositivas resultantes (por ejemplo, aplicar estilos o opciones de formato o diseños) sin preocuparte de que las presentaciones de origen se vean afectadas.

## **Combinar Presentaciones**

Aspose.Slides proporciona el método [**AddClone (ISlide)**](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone) que te permite combinar diapositivas mientras las diapositivas mantienen sus diseños y estilos (parámetros predeterminados).

Este código en C# te muestra cómo fusionar presentaciones:

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

## **Fusionar Presentaciones con Maestro de Diapositivas**

Aspose.Slides proporciona el método [**AddClone (ISlide, IMasterSlide, Boolean)**](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/2) que te permite combinar diapositivas mientras aplicas una plantilla de presentación de maestro de diapositivas. De esta manera, si es necesario, puedes cambiar el estilo de las diapositivas en la presentación de salida.

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

{{% alert title="Nota" color="warning" %}}

El diseño de la diapositiva para el maestro de diapositivas se determina automáticamente. Cuando no se puede determinar un diseño apropiado, si el parámetro booleano `allowCloneMissingLayout` del método `AddClone` está configurado como verdadero, se utiliza el diseño de la diapositiva fuente. De lo contrario, se lanzará una [PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception).

{{% /alert %}}

Si deseas que las diapositivas en la presentación de salida tengan un diseño de diapositiva diferente, utiliza el método [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/1) en su lugar al fusionar.

## **Fusionar Diapositivas Específicas de Presentaciones**

Este código en C# te muestra cómo seleccionar y combinar diapositivas específicas de diferentes presentaciones para obtener una presentación de salida:

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

## **Fusionar Presentaciones Con Diseño de Diapositivas**

Este código en C# te muestra cómo combinar diapositivas de presentaciones mientras aplicas tu diseño de diapositivas preferido para obtener una presentación de salida:

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

## **Fusionar Presentaciones Con Tamaños de Diapositivas Diferentes**

{{% alert title="Nota" color="warning" %}}

No puedes fusionar presentaciones con diferentes tamaños de diapositivas.

{{% /alert %}}

Para fusionar 2 presentaciones con diferentes tamaños de diapositivas, debes redimensionar una de las presentaciones para que su tamaño coincida con el de la otra presentación.

Este código de muestra demuestra la operación descrita:

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

## **Fusionar Diapositivas a la Sección de Presentación**

Este código en C# te muestra cómo fusionar una diapositiva específica a una sección en una presentación:

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

{{% alert title="Consejo" color="primary" %}}

Aspose proporciona una [aplicación web GRATUITA de Collage](https://products.aspose.app/slides/collage). Utilizando este servicio en línea, puedes fusionar [JPG a JPG](https://products.aspose.app/slides/collage/jpg) o imágenes PNG a PNG, crear [rejillas de fotos](https://products.aspose.app/slides/collage/photo-grid), y más.

{{% /alert %}}