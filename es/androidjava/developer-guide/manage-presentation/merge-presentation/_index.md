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
description: "Fusiona sin esfuerzo presentaciones de PowerPoint (PPT, PPTX) y OpenDocument (ODP) con Aspose.Slides para Android vía Java, optimizando tu flujo de trabajo."
---
## **Visión general**

Combinar presentaciones de PowerPoint y OpenDocument es una tarea habitual en muchas aplicaciones Android, sobre todo al generar informes, compilar diapositivas de distintas fuentes o automatizar flujos de trabajo de presentaciones. Aspose.Slides ofrece una API potente y fácil de usar para combinar varios archivos PPT, PPTX u ODP en una única presentación sin necesidad de instalar Microsoft PowerPoint, LibreOffice o OpenOffice.

En esta guía aprenderás a combinar presentaciones de PowerPoint y OpenDocument con sólo unas pocas líneas de código. Proporcionaremos ejemplos listos para usar y mostraremos cómo conservar el formato de las diapositivas, los diseños y otros elementos de la presentación durante el proceso de combinación.

Ya sea que estés desarrollando una aplicación empresarial de gran escala o una herramienta de automatización sencilla, Aspose.Slides hace que combinar presentaciones sea rápido, fiable y escalable. Aspose.Slides permite combinar presentaciones de diferentes maneras. Puedes combinar presentaciones con todas sus formas, estilos, texto, formato, comentarios, animaciones y mucho más—sin preocuparte por la pérdida de calidad o datos.

{{% alert color="info" %}}
Ver también: [Clone Slides](https://docs.aspose.com/slides/es/androidjava/clone-slides/)
{{% /alert %}}

### **Qué se puede combinar**

Con Aspose.Slides puedes combinar 

* presentaciones completas. Todas las diapositivas de las presentaciones terminan en una sola presentación
* diapositivas específicas. Las diapositivas seleccionadas terminan en una sola presentación
* presentaciones en un mismo formato (PPT a PPT, PPTX a PPTX, etc.) y en formatos diferentes (PPT a PPTX, PPTX a ODP, etc.) entre sí. 

### **Opciones de combinación**

Puedes aplicar opciones que determinen si

* cada diapositiva en la presentación de salida conserva un estilo único
* se utiliza un estilo específico para todas las diapositivas de la presentación de salida. 

Para combinar presentaciones, Aspose.Slides proporciona los métodos [AddClone](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) (de la interfaz [ISlideCollection](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ISlideCollection)). Existen varias implementaciones de los métodos `AddClone` que definen los parámetros del proceso de combinación. Cada objeto Presentation tiene una colección [Slides](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/Presentation#getSlides--) , por lo que puedes invocar un método `AddClone` desde la presentación en la que deseas combinar diapositivas.

El método `AddClone` devuelve un objeto `ISlide`, que es una clonación de la diapositiva de origen. Las diapositivas en una presentación de salida son simplemente una copia de las diapositivas de origen. Por lo tanto, puedes modificar las diapositivas resultantes (por ejemplo, aplicar estilos, opciones de formato o diseños) sin que las presentaciones originales se vean afectadas. 

## **Combinar presentaciones** 

Aspose.Slides ofrece el método [**AddClone(ISlide)**](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) que permite combinar diapositivas mientras estas conservan sus diseños y estilos (parámetros predeterminados).

Este código Java muestra cómo combinar presentaciones:

```java
import com.aspose.slides.*;

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

## **Combinar presentaciones con una diapositiva maestra**

Aspose.Slides ofrece el método [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) que permite combinar diapositivas aplicando una plantilla maestra de presentación. De este modo, si es necesario, puedes cambiar el estilo de las diapositivas en la presentación de salida.

Este código Java demuestra la operación descrita:

```java
import com.aspose.slides.*;

Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres1.getMasters().get_Item(0), true);
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
El diseño de diapositiva para la diapositiva maestra se determina automáticamente. Cuando no se puede determinar un diseño apropiado, si el parámetro booleano `allowCloneMissingLayout` del método `AddClone` se establece en true, se utiliza el diseño de la diapositiva de origen. En caso contrario, se lanzará una [PptxEditException](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/PptxEditException).
{{% /alert %}}

Si deseas que las diapositivas en la presentación de salida tengan un diseño de diapositiva diferente, utiliza el método [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) en su lugar al combinar.

## **Combinar diapositivas específicas de presentaciones**

Combinar diapositivas específicas de varias presentaciones es útil para crear paquetes de diapositivas personalizados. Aspose.Slides for Android vía Java permite seleccionar e importar solo las diapositivas que necesitas. La API conserva el formato, el diseño y el aspecto de las diapositivas originales.

El siguiente código Java crea una nueva presentación, añade diapositivas de título de dos presentaciones distintas y guarda el resultado en un archivo:

```java
import com.aspose.slides.*;

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
import com.aspose.slides.*;

static ISlide getTitleSlide(IPresentation presentation) {
    for (ISlide slide : presentation.getSlides()) {
        if (slide.getLayoutSlide().getLayoutType() == SlideLayoutType.Title) {
            return slide;
        }
    }
    return null;
}
```

## **Combinar presentaciones con un diseño de diapositiva**

Este código Java muestra cómo combinar diapositivas de presentaciones aplicando el diseño de diapositiva que prefieras para obtener una única presentación de salida:

```java
import com.aspose.slides.*;

Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres1.getLayoutSlides().get_Item(0));
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

## **Combinar presentaciones con tamaños de diapositiva diferentes**

{{% alert title="Note" color="warning" %}} 
No es posible combinar presentaciones con tamaños de diapositiva diferentes. 
{{% /alert %}}

Para combinar 2 presentaciones con tamaños de diapositiva distintos, debes redimensionar una de ellas para que su tamaño coincida con el de la otra presentación. 

Este ejemplo de código muestra la operación descrita:

```java
import com.aspose.slides.*;

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

## **Combinar diapositivas en una sección de presentación**

Este código Java muestra cómo combinar una diapositiva específica en una sección de una presentación:

```java
import com.aspose.slides.*;

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

{{% alert title="Tip" color="info" %}}
Aspose ofrece una aplicación web GRATUITA de collage ([Collage web app](https://products.aspose.app/slides/es/collage)). Con este servicio en línea, puedes combinar [JPG a JPG](https://products.aspose.app/slides/es/collage/jpg) o PNG a PNG, crear [cuadrículas de fotos](https://products.aspose.app/slides/es/collage/photo-grid), etc. 
{{% /alert %}}

## **FAQ**

### ¿Existen limitaciones en el número de diapositivas al combinar presentaciones?

No hay limitaciones estrictas. Aspose.Slides puede manejar archivos grandes, pero el rendimiento depende del tamaño y los recursos del sistema. Para presentaciones muy extensas, se recomienda usar una JVM de 64 bits y asignar suficiente memoria heap.

### ¿Puedo combinar presentaciones con vídeo o audio incrustados?

Sí, Aspose.Slides conserva el contenido multimedia incrustado en las diapositivas, aunque la presentación final puede volverse considerablemente más grande.

### ¿Se conservan las fuentes al combinar presentaciones?

Sí. Las fuentes usadas en las presentaciones de origen se preservan en el archivo de salida, siempre que estén instaladas en el sistema o [incrustadas](/slides/es/androidjava/embedded-font/).