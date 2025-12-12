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
description: "Fusiona sin esfuerzo presentaciones PowerPoint (PPT, PPTX) y OpenDocument (ODP) con Aspose.Slides para Android mediante Java, optimizando tu flujo de trabajo."
---

{{% alert  title="Tip" color="primary" %}}

Puede que le interese probar la **aplicación web gratuita de Aspose** [Merger app](https://products.aspose.app/slides/merger). Permite combinar presentaciones de PowerPoint en el mismo formato (PPT a PPT, PPTX a PPTX, etc.) y combinar presentaciones en formatos diferentes (PPT a PPTX, PPTX a ODP, etc.).

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}}

## **Fusión de presentaciones**

Al fusionar una presentación con otra, está combinando efectivamente sus diapositivas en una sola presentación para obtener un único archivo.

{{% alert title="Info" color="info" %}}

La mayoría de los programas de presentación (PowerPoint o OpenOffice) carecen de funciones que permitan a los usuarios combinar presentaciones de esta manera.

[**Aspose.Slides for Android via Java**](https://products.aspose.com/slides/androidjava/), sin embargo, le permite fusionar presentaciones de distintas formas. Puede combinar presentaciones con todas sus formas, estilos, textos, formato, comentarios, animaciones, etc., sin preocuparse por la pérdida de calidad o datos.

**Ver también**

[Clone Slides](https://docs.aspose.com/slides/androidjava/clone-slides/).

{{% /alert %}}

### **Qué se puede fusionar**

Con Aspose.Slides, puede fusionar

* presentaciones completas. Todas las diapositivas de las presentaciones terminan en una sola presentación
* diapositivas específicas. Las diapositivas seleccionadas terminan en una sola presentación
* presentaciones en un mismo formato (PPT a PPT, PPTX a PPTX, etc.) y en formatos diferentes (PPT a PPTX, PPTX a ODP, etc.) entre sí.

{{% alert title="Note" color="warning" %}}

Además de presentaciones, Aspose.Slides le permite fusionar otros archivos:

* [Imágenes](https://products.aspose.com/slides/androidjava/merger/image-to-image/), como [JPG a JPG](https://products.aspose.com/slides/androidjava/merger/jpg-to-jpg/) o [PNG a PNG](https://products.aspose.com/slides/androidjava/merger/png-to-png/)
* Documentos, como [PDF a PDF](https://products.aspose.com/slides/androidjava/merger/pdf-to-pdf/) o [HTML a HTML](https://products.aspose.com/slides/androidjava/merger/html-to-html/)
* Y **dos** archivos diferentes, como [imagen a PDF](https://products.aspose.com/slides/androidjava/merger/image-to-pdf/), [JPG a PDF](https://products.aspose.com/slides/androidjava/merger/jpg-to-pdf/) o [TIFF a PDF](https://products.aspose.com/slides/androidjava/merger/tiff-to-pdf/).

{{% /alert %}}

### **Opciones de fusión**

Puede aplicar opciones que determinen si

* cada diapositiva en la presentación de salida conserva un estilo único
* se utiliza un estilo específico para todas las diapositivas en la presentación de salida.

Para fusionar presentaciones, Aspose.Slides ofrece los métodos [AddClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) (de la interfaz [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection)). Existen varias implementaciones de los métodos `AddClone` que definen los parámetros del proceso de fusión de presentaciones. Cada objeto Presentation tiene una colección [Slides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) , por lo que puede invocar un método `AddClone` desde la presentación a la que desea fusionar diapositivas.

El método `AddClone` devuelve un objeto `ISlide`, que es una clonación de la diapositiva de origen. Las diapositivas en la presentación de salida son simplemente una copia de las diapositivas de origen. Por lo tanto, puede modificar las diapositivas resultantes (por ejemplo, aplicar estilos, opciones de formato o diseños) sin que las presentaciones de origen se vean afectadas.

## **Fusionar presentaciones**

Aspose.Slides proporciona el método [**AddClone(ISlide)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) que permite combinar diapositivas mientras estas conservan sus diseños y estilos (parámetros predeterminados).

Este código Java muestra cómo fusionar presentaciones:
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


## **Fusionar presentaciones con una diapositiva maestra**

Aspose.Slides proporciona el método [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) que permite combinar diapositivas aplicando una plantilla de presentación maestra. De este modo, si es necesario, puede cambiar el estilo de las diapositivas en la presentación de salida.

Este código Java muestra la operación descrita:
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

El diseño de la diapositiva maestra se determina automáticamente. Cuando no se puede determinar un diseño apropiado, si el parámetro booleano `allowCloneMissingLayout` del método `AddClone` está establecido en true, se utiliza el diseño de la diapositiva de origen. De lo contrario, se lanzará una [PptxEditException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PptxEditException).

{{% /alert %}}

Si desea que las diapositivas en la presentación de salida tengan un diseño de diapositiva diferente, utilice el método [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) en su lugar al fusionar.

## **Fusionar diapositivas específicas de presentaciones**

Fusionar diapositivas específicas de varias presentaciones es útil para crear decks personalizados. Aspose.Slides for Android via Java le permite seleccionar e importar solo las diapositivas que necesita. La API conserva el formato, el diseño y la apariencia de las diapositivas originales.

El siguiente código Java crea una nueva presentación, añade diapositivas de título de dos presentaciones distintas y guarda el resultado en un archivo:
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


## **Fusionar presentaciones con un diseño de diapositiva**

Este código Java muestra cómo combinar diapositivas de presentaciones aplicando el diseño de diapositiva preferido para obtener una única presentación de salida:
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


## **Fusionar presentaciones con tamaños de diapositiva diferentes**

{{% alert title="Note" color="warning" %}}

No se pueden fusionar presentaciones con tamaños de diapositiva diferentes.

{{% /alert %}}

Para fusionar 2 presentaciones con tamaños de diapositiva distintos, debe redimensionar una de ellas para que coincida con el tamaño de la otra presentación.

Este fragmento de código muestra la operación descrita:
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


## **Fusionar diapositivas a una sección de presentación**

Este código Java muestra cómo fusionar una diapositiva específica a una sección de una presentación:
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

Aspose ofrece una aplicación web **GRATUITA** de Collage ([FREE Collage web app](https://products.aspose.app/slides/collage)). Con este servicio en línea, puede fusionar imágenes [JPG a JPG](https://products.aspose.app/slides/collage/jpg) o PNG a PNG, crear [rejillas de fotos](https://products.aspose.app/slides/collage/photo-grid), etc.

{{% /alert %}}

## **FAQ**

**¿Existen limitaciones en la cantidad de diapositivas al fusionar presentaciones?**

No hay limitaciones estrictas. Aspose.Slides puede manejar archivos grandes, pero el rendimiento depende del tamaño y los recursos del sistema. Para presentaciones muy extensas, se recomienda usar una JVM de 64 bits y asignar suficiente memoria heap.

**¿Puedo fusionar presentaciones con video o audio incrustados?**

Sí, Aspose.Slides conserva el contenido multimedia incorporado en las diapositivas, aunque la presentación final puede volverse significativamente mayor.

**¿Se conservan las fuentes al fusionar presentaciones?**

Sí. Las fuentes utilizadas en las presentaciones de origen se preservan en el archivo resultante, siempre que estén instaladas en el sistema o [incrustadas](/slides/es/androidjava/embedded-font/).