---
title: Combinación de Presentaciones
type: docs
weight: 40
url: /es/java/merge-presentation/
keywords: "Combinar PowerPoint, PPTX, PPT, combinar PowerPoint, combinar presentación, Java"
description: "Combina o fusiona presentaciones de PowerPoint en Java"
---


{{% alert  title="Consejo" color="primary" %}} 

Es posible que desees consultar la aplicación en línea gratuita de **Aspose** [Merger app](https://products.aspose.app/slides/merger). Permite a las personas fusionar presentaciones de PowerPoint en el mismo formato (PPT a PPT, PPTX a PPTX, etc.) y fusionar presentaciones en diferentes formatos (PPT a PPTX, PPTX a ODP, etc.).

[![todo:texto_alternativo_de_imagen](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 


## **Fusión de Presentaciones**

Cuando fusionas una presentación a otra, estás combinando efectivamente sus diapositivas en una sola presentación para obtener un archivo.

{{% alert title="Info" color="info" %}}

La mayoría de los programas de presentación (PowerPoint u OpenOffice) carecen de funciones que permiten a los usuarios combinar presentaciones de esta manera. 

Sin embargo, [**Aspose.Slides para Java**](https://products.aspose.com/slides/java/) permite fusionar presentaciones de diferentes maneras. Puedes fusionar presentaciones con todas sus formas, estilos, textos, formatos, comentarios, animaciones, etc. sin tener que preocuparte por la pérdida de calidad o datos. 

**Ver también**

[Clonar Diapositivas](https://docs.aspose.com/slides/java/clone-slides/). 

{{% /alert %}}

### **Qué Se Puede Fusionar**

Con Aspose.Slides, puedes fusionar 

* presentaciones completas. Todas las diapositivas de las presentaciones terminan en una presentación
* diapositivas específicas. Las diapositivas seleccionadas terminan en una presentación
* presentaciones en un formato (PPT a PPT, PPTX a PPTX, etc.) y en diferentes formatos (PPT a PPTX, PPTX a ODP, etc.) entre sí. 

{{% alert title="Nota" color="warning" %}} 

Además de presentaciones, Aspose.Slides permite fusionar otros archivos:

* [Imágenes](https://products.aspose.com/slides/java/merger/image-to-image/), como [JPG a JPG](https://products.aspose.com/slides/java/merger/jpg-to-jpg/) o [PNG a PNG](https://products.aspose.com/slides/java/merger/png-to-png/)
* Documentos, como [PDF a PDF](https://products.aspose.com/slides/java/merger/pdf-to-pdf/) o [HTML a HTML](https://products.aspose.com/slides/java/merger/html-to-html/)
* Y dos archivos diferentes como [imagen a PDF](https://products.aspose.com/slides/java/merger/image-to-pdf/) o [JPG a PDF](https://products.aspose.com/slides/java/merger/jpg-to-pdf/) o [TIFF a PDF](https://products.aspose.com/slides/java/merger/tiff-to-pdf/).

{{% /alert %}}

### **Opciones de Fusión**

Puedes aplicar opciones que determinan si

* cada diapositiva en la presentación de salida conserva un estilo único
* se utiliza un estilo específico para todas las diapositivas en la presentación de salida. 

Para fusionar presentaciones, Aspose.Slides proporciona métodos [AddClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) (del [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection) interface). Hay varias implementaciones de los métodos `AddClone` que definen los parámetros del proceso de fusión de presentaciones. Cada objeto Presentación tiene una colección [Slides](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) , por lo que puedes llamar a un método `AddClone` desde la presentación a la que deseas fusionar las diapositivas. 

El método `AddClone` devuelve un objeto `ISlide`, que es un clon de la diapositiva fuente. Las diapositivas en una presentación de salida son simplemente una copia de las diapositivas de la fuente. Por lo tanto, puedes realizar cambios en las diapositivas resultantes (por ejemplo, aplicar estilos o opciones de formato o diseños) sin preocuparte por que las presentaciones fuente se vean afectadas. 

## **Fusionar Presentaciones** 

Aspose.Slides proporciona el método [**AddClone(ISlide)**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) que te permite combinar diapositivas mientras las diapositivas conservan sus diseños y estilos (parámetros predeterminados). 

Este código Java te muestra cómo fusionar presentaciones:

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

## **Fusionar Presentaciones con Master de Diapositivas**

Aspose.Slides proporciona el método [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) que te permite combinar diapositivas mientras aplicas una plantilla de presentación de master de diapositivas. De esta manera, si es necesario, puedes cambiar el estilo de las diapositivas en la presentación de salida. 

Este código en Java demuestra la operación descrita:

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

{{% alert title="Nota" color="warning" %}} 

El diseño de la diapositiva para el master de diapositivas se determina automáticamente. Cuando no se puede determinar un diseño apropiado, si el parámetro booleano `allowCloneMissingLayout` del método `AddClone` se establece en verdadero, se utiliza el diseño de la diapositiva fuente. De lo contrario, se lanzará una [PptxEditException](https://reference.aspose.com/slides/java/com.aspose.slides/PptxEditException). 

{{% /alert %}}

Si deseas que las diapositivas en la presentación de salida tengan un diseño de diapositiva diferente, utiliza en su lugar el método [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) al fusionar. 

## **Fusionar Diapositivas Específicas de Presentaciones**

Este código Java te muestra cómo seleccionar y combinar diapositivas específicas de diferentes presentaciones para obtener una presentación de salida:

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

## **Fusionar Presentaciones con Diseño de Diapositiva**

Este código Java te muestra cómo combinar diapositivas de presentaciones mientras aplicas tu diseño de diapositiva preferido para obtener una presentación de salida:

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

## **Fusionar Presentaciones con Diferentes Tamaños de Diapositivas**

{{% alert title="Nota" color="warning" %}} 

No puedes fusionar presentaciones con diferentes tamaños de diapositivas. 

{{% /alert %}}

Para fusionar 2 presentaciones con diferentes tamaños de diapositivas, debes redimensionar una de las presentaciones para que su tamaño coincida con el de la otra presentación. 

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

## **Fusionar Diapositivas a Sección de Presentación**

Este código Java te muestra cómo fusionar una diapositiva específica a una sección en una presentación:

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

{{% alert title="Consejo" color="primary" %}}

Aspose ofrece una [aplicación web de Collage GRATIS](https://products.aspose.app/slides/collage). Usando este servicio en línea, puedes fusionar [JPG a JPG](https://products.aspose.app/slides/collage/jpg) o imágenes PNG a PNG, crear [rejillas de fotos](https://products.aspose.app/slides/collage/photo-grid), y más. 

{{% /alert %}}