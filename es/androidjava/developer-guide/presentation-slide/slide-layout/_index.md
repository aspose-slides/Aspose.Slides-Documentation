---
title: Diseño de Diapositivas
type: docs
weight: 60
url: /es/androidjava/slide-layout/
keyword: "Establecer tamaño de diapositiva, configurar opciones de diapositiva, especificar tamaño de diapositiva, visibilidad del pie de página, pie de página secundario, escalado de contenido, tamaño de página, Java, Aspose.Slides"
description: "Establecer el tamaño y las opciones de la diapositiva de PowerPoint en Java"
---

Un diseño de diapositiva contiene los cuadros de marcador de posición y la información de formato para todo el contenido que aparece en una diapositiva. El diseño determina los marcadores de posición de contenido disponibles y dónde se colocan.

Los diseños de diapositivas te permiten crear y diseñar presentaciones rápidamente (ya sean simples o complejas). Estos son algunos de los diseños de diapositivas más populares utilizados en las presentaciones de PowerPoint:

* **Diseño de Diapositiva de Título**. Este diseño consta de dos marcadores de posición de texto. Un marcador de posición es para el título y el otro es para el subtítulo.
* **Diseño de Título y Contenido**. Este diseño contiene un marcador de posición relativamente pequeño en la parte superior para el título y un marcador de posición más grande para el contenido principal (gráfico, párrafos, lista con viñetas, lista numerada, imágenes, etc).
* **Diseño en Blanco**. Este diseño carece de marcadores de posición, por lo que te permite crear elementos desde cero.

Dado que un patrón de diapositiva es la diapositiva jerárquica principal que almacena información sobre los diseños de diapositivas, puedes usar la diapositiva maestra para acceder a los diseños de diapositivas y realizar cambios en ellos. Se puede acceder a una diapositiva de diseño por tipo o nombre. De manera similar, cada diapositiva tiene un id único, que puede ser utilizado para acceder a ella.

Alternativamente, puedes hacer cambios directamente a un diseño de diapositiva específico en una presentación.

* Para permitirte trabajar con diseños de diapositivas (incluidos los de las diapositivas maestras), Aspose.Slides proporciona propiedades como [getLayoutSlides()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getLayoutSlides--) y [getMasters()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) bajo la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
* Para realizar tareas relacionadas, Aspose.Slides proporciona [MasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/masterslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/masterlayoutslidecollection/), [SlideSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/), [BaseSlideHeaderFooterManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslideheaderfootermanager/), y muchos otros tipos.

{{% alert title="Info" color="info" %}}

Para obtener más información sobre el trabajo con Diapositivas Maestras en particular, consulta el artículo [Diapositiva Maestra](https://docs.aspose.com/slides/androidjava/slide-master/).

{{% /alert %}}

## **Agregar Diseño de Diapositiva a la Presentación**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Accede a la [colección MasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterlayoutslidecollection/).
1. Revisa las diapositivas de diseño existentes para confirmar que el diseño de diapositiva requerido ya existe en la colección de Diapositivas de Diseño. De lo contrario, agrega la diapositiva de diseño que desees.
1. Agrega una diapositiva en blanco basada en la nueva diapositiva de diseño.
1. Guarda la presentación.

Este código Java te muestra cómo agregar un diseño de diapositiva a una presentación de PowerPoint:

```java
// Instancia una clase Presentation que representa el archivo de presentación
Presentation pres = new Presentation("AccessSlides.pptx");
try {
    // Revisa los tipos de diapositivas de diseño
    IMasterLayoutSlideCollection layoutSlides = pres.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide layoutSlide = null;

    if (layoutSlides.getByType(SlideLayoutType.TitleAndObject) != null)
        layoutSlide = layoutSlides.getByType(SlideLayoutType.TitleAndObject);
    else
        layoutSlide = layoutSlides.getByType(SlideLayoutType.Title);

    if (layoutSlide == null) {
        // La situación en la que una presentación no contiene algunos tipos de diseño.
        // El archivo de presentación solo contiene tipos de diseño en blanco y personalizados.
        // Pero las diapositivas de diseño con tipos personalizados tienen nombres de diapositiva diferentes,
        // como "Título", "Título y Contenido", etc. Y es posible usar estos
        // nombres para la selección de la diapositiva de diseño.
        // También puedes utilizar un conjunto de tipos de forma de marcador de posición. Por ejemplo,
        // la diapositiva de título debería tener únicamente el tipo de marcador de posición de Título, etc.
        for (ILayoutSlide titleAndObjectLayoutSlide : layoutSlides) {
            if (titleAndObjectLayoutSlide.getName() == "Title and Object") {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }
        if (layoutSlide == null) {
            for (ILayoutSlide titleLayoutSlide : layoutSlides) {
                if (titleLayoutSlide.getName() == "Title") {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }
            if (layoutSlide == null) {
                layoutSlide = layoutSlides.getByType(SlideLayoutType.Blank);
                if (layoutSlide == null) {
                    layoutSlide = layoutSlides.add(SlideLayoutType.TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // Agrega una diapositiva vacía con el diseño agregado
    pres.getSlides().insertEmptySlide(0, layoutSlide);

    // Guarda la presentación en disco
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Eliminar Diapositiva de Diseño No Utilizada**

Aspose.Slides proporciona el método [removeUnusedLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) de la clase [Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/) para permitirte eliminar diapositivas de diseño no deseadas y no utilizadas. Este código Java te muestra cómo eliminar una diapositiva de diseño de una presentación de PowerPoint:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.removeUnusedLayoutSlides(pres);

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Establecer Tamaño y Tipo para el Diseño de Diapositiva**

Para permitirte establecer el tamaño y tipo para una diapositiva de diseño específica, Aspose.Slides proporciona las propiedades [getType()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#getType--) y [getSize()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#getSize--) (de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)). Este Java demuestra la operación:

```java
// Instancia un objeto Presentation que representa un archivo de presentación
Presentation presentation = new Presentation("demo.pptx");
try {
    Presentation auxPresentation = new Presentation();
    try {
        // Establece el tamaño de la diapositiva para la presentación generada al de la fuente
        auxPresentation.getSlideSize().setSize(540, 720, SlideSizeScaleType.EnsureFit);
        //getType());
        auxPresentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.Maximize);
        
        // Clona la diapositiva requerida
        auxPresentation.getSlides().addClone(presentation.getSlides().get_Item(0));
        auxPresentation.getSlides().removeAt(0);
        
        // Guarda la presentación en disco
        auxPresentation.save("size.pptx", SaveFormat.Pptx);
    } finally {
        auxPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Establecer Visibilidad del Pie de Página Dentro de la Diapositiva**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Obtén la referencia de una diapositiva a través de su índice.
1. Establece la visibilidad del marcador de posición del pie de página de la diapositiva a visible.
1. Establece la visibilidad del marcador de posición de fecha y hora a visible.
1. Guarda la presentación.

Este código Java te muestra cómo establecer la visibilidad para un pie de página de diapositiva (y realizar tareas relacionadas):

```java
Presentation presentation = new Presentation("presentation.ppt");
try {
    IBaseSlideHeaderFooterManager headerFooterManager = presentation.getSlides().get_Item(0).getHeaderFooterManager();
    if (!headerFooterManager.isFooterVisible()) // El método isFooterVisible se usa para especificar que falta un marcador de posición de pie de página de la diapositiva
    {
        headerFooterManager.setFooterVisibility(true); // El método setFooterVisibility se usa para establecer un marcador de posición de pie de página de diapositiva como visible
    }
    if (!headerFooterManager.isSlideNumberVisible()) // El método isSlideNumberVisible se usa para especificar que falta un marcador de posición de número de página de la diapositiva
    {
        headerFooterManager.setSlideNumberVisibility(true); // El método setSlideNumberVisibility se usa para establecer un marcador de posición de número de página de la diapositiva como visible
    }
    if (!headerFooterManager.isDateTimeVisible()) // El método isDateTimeVisible se usa para especificar que falta un marcador de posición de fecha y hora de la diapositiva
    {
        headerFooterManager.setDateTimeVisibility(true); // El método SetFooterVisibility se utiliza para establecer un marcador de posición de fecha y hora de la diapositiva como visible
    }
    headerFooterManager.setFooterText("Texto del pie de página"); // El método SetFooterText se usa para establecer un texto para un marcador de posición de pie de página de la diapositiva.
    headerFooterManager.setDateTimeText("Texto de fecha y hora"); // El método SetDateTimeText se usa para establecer un texto para un marcador de posición de fecha y hora de la diapositiva.
} finally {
    presentation.dispose();
}
```

## **Establecer Visibilidad del Pie de Página Secundario Dentro de la Diapositiva**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Obtén una referencia para la diapositiva maestra a través de su índice.
1. Establece la diapositiva maestra y todos los marcadores de posición de pie de página secundarios a visible.
1. Establece un texto para la diapositiva maestra y todos los marcadores de posición de pie de página secundarios.
1. Establece un texto para la diapositiva maestra y todos los marcadores de posición de fecha y hora secundarios.
1. Guarda la presentación.

Este código Java demuestra la operación:

```java
Presentation presentation = new Presentation("presentation.ppt");
try {
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();
    headerFooterManager.setFooterAndChildFootersVisibility(true); // El método setFooterAndChildFootersVisibility se usa para establecer la diapositiva maestra y todos los marcadores de posición de pie de página secundarios como visibles
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // El método setSlideNumberAndChildSlideNumbersVisibility se utiliza para establecer la diapositiva maestra y todos los marcadores de posición de número de página secundarios como visibles
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // El método setDateTimeAndChildDateTimesVisibility se utiliza para establecer una diapositiva maestra y todos los marcadores de posición de fecha y hora secundarios como visibles

    headerFooterManager.setFooterAndChildFootersText("Texto del pie de página"); // El método setFooterAndChildFootersText se utiliza para establecer textos para la diapositiva maestra y todos los marcadores de posición de pie de página secundarios
    headerFooterManager.setDateTimeAndChildDateTimesText("Texto de fecha y hora"); // El método setDateTimeAndChildDateTimesText se utiliza para establecer texto para la diapositiva maestra y todos los marcadores de posición de fecha y hora secundarios
} finally {
    presentation.dispose();
}
```

## **Establecer Tamaño de Diapositiva con Respecto al Escalado de Contenido**

1. Crea una instancia de la [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) clase y carga la presentación que contiene la diapositiva cuyo tamaño deseas establecer.
1. Crea otra instancia de la [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) clase para generar una nueva presentación.
1. Obtén la referencia de la diapositiva (de la primera presentación) a través de su índice.
1. Establece la visibilidad del marcador de posición del pie de página de la diapositiva a visible.
1. Establece la visibilidad del marcador de posición de fecha y hora a visible.
1. Guarda la presentación.

Este código Java demuestra la operación:

```java
// Instancia un objeto Presentation que representa un archivo de presentación
Presentation presentation = new Presentation("demo.pptx");
try {
    // Establece el tamaño de la diapositiva para las presentaciones generadas al de la fuente
    presentation.getSlideSize().setSize(540, 720, SlideSizeScaleType.EnsureFit); // El método SetSize se usa para establecer el tamaño de la diapositiva con escala de contenido para asegurar ajuste
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.Maximize); // El método SetSize se usa para establecer el tamaño de la diapositiva con el tamaño máximo del contenido

    // Guarda la presentación en disco
    presentation.save("Set_Size&Type_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Establecer Tamaño de Página al Generar PDF**

Ciertas presentaciones (como carteles) a menudo se convierten a documentos PDF. Si deseas convertir tu PowerPoint a PDF para acceder a las mejores opciones de impresión y accesibilidad, deseas establecer tus diapositivas en tamaños que se adapten a documentos PDF (A4, por ejemplo).

Aspose.Slides proporciona la clase [SlideSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/) para permitirte especificar tus configuraciones preferidas para las diapositivas. Este código Java te muestra cómo usar la propiedad [getType()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#getType--) (de la clase `SlideSize`) para establecer un tamaño de papel específico para las diapositivas en una presentación:

```java
// Instancia un objeto Presentation que representa un archivo de presentación 
Presentation presentation = new Presentation();
try {
    // Establece la propiedad SlideSize.Type  
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper,SlideSizeScaleType.EnsureFit);
    
    // Establece diferentes propiedades para las opciones PDF
    PdfOptions opts = new  PdfOptions();
    opts.setSufficientResolution(600);
    
    // Guarda la presentación en disco
    presentation.save("SetPDFPageSize_out.pdf", SaveFormat.Pdf, opts);
} finally {
    presentation.dispose();
}
```