---
title: Combinar Presentación
type: docs
weight: 40
url: /es/python-net/merge-presentation/
keywords: "Combinar PowerPoint, PPTX, PPT, combinar PowerPoint, fusionar presentación, combinar presentación, Python"
description: "Combina o fusiona Presentaciones de PowerPoint en Python"
---

{{% alert  title="Consejo" color="primary" %}} 

Es posible que desees revisar la **app de fusión en línea gratuita de Aspose** [Merger app](https://products.aspose.app/slides/merger). Permite a las personas fusionar presentaciones de PowerPoint en el mismo formato (PPT a PPT, PPTX a PPTX, etc.) y fusionar presentaciones en diferentes formatos (PPT a PPTX, PPTX a ODP, etc.).

[![todo:texto_alt_imagen](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 


## **Fusión de Presentaciones**

Cuando fusionas una presentación con otra, efectivamente estás combinando sus diapositivas en una sola presentación para obtener un archivo único. 

{{% alert title="Información" color="info" %}}

La mayoría de los programas de presentación (PowerPoint u OpenOffice) carecen de funciones que permitan a los usuarios combinar presentaciones de esta manera. 

Sin embargo, [**Aspose.Slides para Python a través de .NET**](https://products.aspose.com/slides/python-net/) te permite fusionar presentaciones de diferentes maneras. Puedes combinar presentaciones con todas sus formas, estilos, textos, formatos, comentarios, animaciones, etc. sin tener que preocuparte por la pérdida de calidad o datos. 

**Ver también**

[Clonar Diapositivas](https://docs.aspose.com/slides/python-net/cloning-commenting-and-manipulating-slides/#cloning-commentingandmanipulatingslides-cloningslides)*.* 

{{% /alert %}}

### **Qué se Puede Fusionar**

Con Aspose.Slides, puedes fusionar 

* presentaciones completas. Todas las diapositivas de las presentaciones terminan en una sola presentación
* diapositivas específicas. Las diapositivas seleccionadas terminan en una sola presentación
* presentaciones en un formato (PPT a PPT, PPTX a PPTX, etc.) y en diferentes formatos (PPT a PPTX, PPTX a ODP, etc.) entre sí. 

{{% alert title="Nota" color="warning" %}} 

Además de presentaciones, Aspose.Slides te permite fusionar otros archivos:

* [Imágenes](https://products.aspose.com/slides/python-net/merger/image-to-image/), como [JPG a JPG](https://products.aspose.com/slides/python-net/merger/jpg-to-jpg/) o [PNG a PNG](https://products.aspose.com/slides/python-net/merger/png-to-png/)
* Documentos, como [PDF a PDF](https://products.aspose.com/slides/python-net/merger/pdf-to-pdf/) o [HTML a HTML](https://products.aspose.com/slides/python-net/merger/html-to-html/)
* Y dos archivos diferentes, como [imagen a PDF](https://products.aspose.com/slides/python-net/merger/image-to-pdf/) o [JPG a PDF](https://products.aspose.com/slides/python-net/merger/jpg-to-pdf/) o [TIFF a PDF](https://products.aspose.com/slides/python-net/merger/tiff-to-pdf/).

{{% /alert %}}

### **Opciones de Fusión**

Puedes aplicar opciones que determinen si

* cada diapositiva en la presentación de salida retiene un estilo único
* se usa un estilo específico para todas las diapositivas en la presentación de salida. 

Para fusionar presentaciones, Aspose.Slides proporciona métodos [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) (de la interfaz [ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/)). Hay varias implementaciones de los métodos `add_clone` que definen los parámetros del proceso de fusión de presentaciones. Cada objeto Presentation tiene una colección [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), por lo que puedes llamar a un método `add_clone` desde la presentación a la que deseas fusionar diapositivas. 

El método `add_clone` devuelve un objeto `ISlide`, que es un clon de la diapositiva fuente. Las diapositivas en una presentación de salida son simplemente una copia de las diapositivas de la fuente. Por lo tanto, puedes realizar cambios en las diapositivas resultantes (por ejemplo, aplicar estilos o opciones de formato o diseños) sin preocuparte de que las presentaciones fuente se vean afectadas. 

## **Fusionar Presentaciones** 

Aspose.Slides proporciona el método [**AddClone (ISlide)**](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) que te permite combinar diapositivas mientras las diapositivas retienen sus diseños y estilos (parámetros predeterminados). 

Este código de Python te muestra cómo fusionar presentaciones:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres1:
    with slides.Presentation("Presentation1.pptx") as pres2:
        for slide in pres2.slides:
            pres1.slides.add_clone(slide)
        pres1.save("combined.pptx", slides.export.SaveFormat.PPTX)
```

## **Fusionar Presentaciones con Maestro de Diapositivas**

Aspose.Slides proporciona el método [**add_clone (ISlide, IMasterSlide, Boolean)**](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) que te permite combinar diapositivas mientras aplicas una plantilla de presentación de maestro de diapositivas. De esta manera, si es necesario, puedes cambiar el estilo de las diapositivas en la presentación de salida. 

Este código en Python demuestra la operación descrita:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres1:
    with slides.Presentation("Presentation1.pptx") as pres2:
        for slide in pres2.slides:
            pres1.slides.add_clone(slide, pres1.masters[0], allow_clone_missing_layout = True)
        pres1.save("combined_with_master.pptx", slides.export.SaveFormat.PPTX) 
```

{{% alert title="Nota" color="warning" %}} 

El diseño de la diapositiva para el maestro de diapositivas se determina automáticamente. Cuando no se puede determinar un diseño apropiado, si el parámetro booleano `allowCloneMissingLayout` del método `add_clone` se establece en verdadero, se utiliza el diseño de la diapositiva fuente. De lo contrario, se lanzará una [PptxEditException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxeditexception/). 

{{% /alert %}}

Si deseas que las diapositivas en la presentación de salida tengan un diseño de diapositiva diferente, usa el método [add_clone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) en su lugar al fusionar. 

## **Fusionar Diapositivas Específicas de Presentaciones**

Este código de Python te muestra cómo seleccionar y combinar diapositivas específicas de diferentes presentaciones para obtener una presentación de salida:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres1:
    with slides.Presentation("Presentation1.pptx") as pres2:
        for slide in pres2.slides:
            pres1.slides.add_clone(slide, pres1.layout_slides[0])
        pres1.save("combined_with_layout.pptx", slides.export.SaveFormat.PPTX) 
```

## **Fusionar Presentaciones Con Diseño de Diapositivas**

Este código de Python te muestra cómo combinar diapositivas de presentaciones mientras aplicas tu diseño de diapositiva preferido a ellas para obtener una presentación de salida:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres1:
    with slides.Presentation("Presentation1.pptx") as pres2:
        for slide in pres2.slides:
            pres1.slides.add_clone(slide, pres1.layout_slides[0])
        pres1.save("combined_with_layout.pptx", slides.export.SaveFormat.PPTX) 
```

## **Fusionar Presentaciones Con Diferentes Tamaños de Diapositivas**

{{% alert title="Nota" color="warning" %}} 

No puedes fusionar presentaciones con diferentes tamaños de diapositivas. 

{{% /alert %}}

Para fusionar 2 presentaciones con diferentes tamaños de diapositivas, debes redimensionar una de las presentaciones para que su tamaño coincida con el de la otra presentación. 

Este código de muestra demuestra la operación descrita:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres1:
    with slides.Presentation("Presentation1.pptx") as pres2:
        pres2.slide_size.set_size(pres1.slide_size.size.width, pres1.slide_size.size.height, slides.SlideSizeScaleType.ENSURE_FIT)
        for slide in pres2.slides:
            pres1.slides.add_clone(slide)
        pres1.save("combined_size.pptx", slides.export.SaveFormat.PPTX) 
```

## **Fusionar Diapositivas en Sección de Presentación**

Este código de Python te muestra cómo fusionar una diapositiva específica en una sección de una presentación:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres1:
    with slides.Presentation("Presentation1.pptx") as pres2:
        for slide in pres2.slides:
            pres1.slides.add_clone(slide, pres1.sections[0])
        pres1.save("combined_sections.pptx", slides.export.SaveFormat.PPTX) 
```

La diapositiva se añade al final de la sección. 

{{% alert title="Consejo" color="primary" %}}

Aspose proporciona una [aplicación web gratuita de Collage](https://products.aspose.app/slides/collage). Usando este servicio en línea, puedes fusionar [JPG a JPG](https://products.aspose.app/slides/collage/jpg) o imágenes PNG a PNG, crear [recuadros de fotos](https://products.aspose.app/slides/collage/photo-grid), y más. 

{{% /alert %}}