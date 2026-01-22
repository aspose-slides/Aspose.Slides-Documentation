---
title: Fusionar presentaciones de forma eficiente en Android
linktitle: Fusionar presentaciones
type: docs
weight: 40
url: /es/androidjava/merge-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Fusiona sin esfuerzo presentaciones de PowerPoint (PPT, PPTX) y OpenDocument (ODP) con Aspose.Slides para Android mediante Java, optimizando tu flujo de trabajo."
---

{{% alert  title="Tip" color="primary" %}} 

Quizá quieras probar la **aplicación gratuita en línea de Aspose** [Merger app](https://products.aspose.app/slides/merger). Permite combinar presentaciones de PowerPoint en el mismo formato (PPT a PPT, PPTX a PPTX, etc.) y combinar presentaciones en distintos formatos (PPT a PPTX, PPTX a ODP, etc.).

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 


## **Presentation Merging**

Cuando combinas una presentación con otra, básicamente estás uniendo sus diapositivas en una sola presentación para obtener un único archivo. 

{{% alert title="Info" color="info" %}}

La mayoría de los programas de presentación (PowerPoint u OpenOffice) carecen de funciones que permitan a los usuarios combinar presentaciones de esa manera. 

[**Aspose.Slides for Android via Java**](https://products.aspose.com/slides/androidjava/), sin embargo, permite combinar presentaciones de diferentes maneras. Puedes combinar presentaciones con todas sus formas, estilos, textos, formato, comentarios, animaciones, etc., sin preocuparte por la pérdida de calidad o datos.

**See also**

[Clone Slides](https://docs.aspose.com/slides/androidjava/clone-slides/).

{{% /alert %}}

### **What Can Be Merged**

Con Aspose.Slides, puedes combinar 

* presentaciones completas. Todas las diapositivas de las presentaciones terminan en una sola presentación
* diapositivas específicas. Las diapositivas seleccionadas terminan en una sola presentación
* presentaciones en un mismo formato (PPT a PPT, PPTX a PPTX, etc.) y en diferentes formatos (PPT a PPTX, PPTX a ODP, etc.) entre sí. 

### **Merging Options**

Puedes aplicar opciones que determinen si

* cada diapositiva en la presentación de salida conserva un estilo único
* se utiliza un estilo específico para todas las diapositivas en la presentación de salida. 

Para combinar presentaciones, Aspose.Slides proporciona los métodos [AddClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) (de la interfaz [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection)). Existen varias implementaciones de los métodos `AddClone` que definen los parámetros del proceso de combinación de presentaciones. Cada objeto Presentation tiene una colección [Slides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--), por lo que puedes llamar al método `AddClone` desde la presentación a la que deseas combinar diapositivas.

El método `AddClone` devuelve un objeto `ISlide`, que es una copia de la diapositiva origen. Las diapositivas en la presentación de salida son simplemente una copia de las diapositivas de origen. Por lo tanto, puedes modificar las diapositivas resultantes (por ejemplo, aplicar estilos, opciones de formato o diseños) sin preocuparte de que las presentaciones origen se vean afectadas. 

## **Merge Presentations** 

Aspose.Slides ofrece el método [**AddClone(ISlide)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) que permite combinar diapositivas mientras estas conservan sus diseños y estilos (parámetros predeterminados).

Este código Java muestra cómo combinar presentaciones:
```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```


## **Merge Presentations with a Slide Master**

Aspose.Slides proporciona el método [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) que permite combinar diapositivas aplicando una plantilla maestra de presentación. De este modo, si es necesario, puedes cambiar el estilo de las diapositivas en la presentación de salida.

Este código Java demuestra la operación descrita:
```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres2.getMasters().get_Item(0), true);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```


{{% alert title="Note" color="warning" %}} 

El diseño de diapositiva para la diapositiva maestra se determina automáticamente. Cuando no se puede determinar un diseño apropiado, si el parámetro booleano `allowCloneMissingLayout` del método `AddClone` está establecido en true, se utiliza el diseño de la diapositiva origen. En caso contrario, se lanzará una [PptxEditException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PptxEditException).

{{% /alert %}}

Si deseas que las diapositivas en la presentación de salida tengan un diseño de diapositiva diferente, utiliza el método [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) en su lugar al combinar.

## **Merge Specific Slides from Presentations**

Combinar diapositivas específicas de varias presentaciones es útil para crear conjuntos de diapositivas personalizados. Aspose.Slides para Android mediante Java permite seleccionar e importar solo las diapositivas que necesitas. La API conserva el formato, el diseño y el estilo de las diapositivas originales.

El siguiente código Java crea una nueva presentación, añade diapositivas de título de otras dos presentaciones y guarda el resultado en un archivo:
```java
Presentation presentation = new Presentation();
Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    presentation.getSlides().removeAt(0);
    
    ISlide slide1 = getTitleSlide(presentation1);

    if (slide1 != null)
        presentation.getSlides().addClone(slide1);

    ISlide slide2 = getTitleSlide(presentation2);

    if (slide2 != null)
        presentation.getSlides().addClone(slide2);

    presentation.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
    presentation.dispose();
}
```

```java
static ISlide getTitleSlide(IPresentation presentation) {
    for (ISlide slide : presentation.getSlides()) {
        if (slide.getLayoutSlide().getLayoutType() == SlideLayoutType.Title) {
            return slide;
        }
    }
    return null;
}
```


## **Merge Presentations with a Slide Layout**

Este código Java muestra cómo combinar diapositivas de presentaciones aplicando el diseño de diapositiva que prefieras para obtener una única presentación de salida:
```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres2.getLayoutSlides().get_Item(0));
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```


## **Merge Presentations with Different Slide Sizes**

{{% alert title="Note" color="warning" %}} 

No puedes combinar presentaciones con diferentes tamaños de diapositiva. 

{{% /alert %}}

Para combinar 2 presentaciones con diferentes tamaños de diapositiva, debes redimensionar una de las presentaciones para que coincida con el tamaño de la otra.

Este código de ejemplo demuestra la operación descrita:
```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        pres2.getSlideSize().setSize((float)pres1.getSlideSize().getSize().getWidth(), (float)pres1.getSlideSize().getSize().getHeight(), SlideSizeScaleType.EnsureFit);

        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```


## **Merge Slides to a Presentation Section**

Este código Java muestra cómo combinar una diapositiva específica en una sección de una presentación:
```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres1.getSections().get_Item(0));
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```


La diapositiva se añade al final de la sección. 

{{% alert title="Tip" color="primary" %}}

Aspose ofrece una [aplicación web GRATUITA de Collage](https://products.aspose.app/slides/collage). Con este servicio en línea, puedes combinar [JPG a JPG](https://products.aspose.app/slides/collage/jpg) o PNG a PNG, crear [cuadrículas de fotos](https://products.aspose.app/slides/collage/photo-grid), etc. 

{{% /alert %}}

## **FAQ**

**¿Existen limitaciones en el número de diapositivas al combinar presentaciones?**

No hay limitaciones estrictas. Aspose.Slides puede manejar archivos grandes, pero el rendimiento depende del tamaño y los recursos del sistema. Para presentaciones muy extensas, se recomienda usar una JVM de 64 bits y asignar suficiente memoria heap.

**¿Puedo combinar presentaciones con vídeo o audio incrustados?**

Sí, Aspose.Slides conserva el contenido multimedia incrustado en las diapositivas, aunque la presentación final puede volverse significativamente más grande.

**¿Se conservarán las fuentes al combinar presentaciones?**

Sí. Las fuentes empleadas en las presentaciones origen se conservan en el archivo de salida, siempre que estén instaladas en el sistema o [incrustadas](/slides/es/androidjava/embedded-font/).