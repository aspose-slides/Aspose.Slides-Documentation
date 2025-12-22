---
title: Aplicar o Cambiar diseños de diapositiva en Android
linktitle: Diseño de diapositiva
type: docs
weight: 60
url: /es/androidjava/slide-layout/
keywords:
- diseño de diapositiva
- diseño de contenido
- marcador de posición
- diseño de presentación
- diseño de diapositiva
- diseño no utilizado
- visibilidad del pie de página
- diapositiva de título
- título y contenido
- encabezado de sección
- dos contenidos
- comparación
- solo título
- diseño en blanco
- contenido con subtítulo
- imagen con subtítulo
- título y texto vertical
- título vertical y texto
- PowerPoint
- OpenDocument
- presentación
- Android
- Java
- Aspose.Slides
description: "Administre y personalice los diseños de diapositivas en Aspose.Slides para Android. Explore los tipos de diseño, el control de marcadores de posición y la visibilidad del pie de página mediante ejemplos de código Java."
---

## **Visión general**

Un diseño de diapositiva define la disposición de los cuadros de marcador de posición y el formato del contenido en una diapositiva. Controla qué marcadores de posición están disponibles y dónde aparecen. Los diseños de diapositiva le ayudan a crear presentaciones de forma rápida y coherente, ya sea que esté creando algo simple o más complejo. Algunos de los diseños de diapositiva más comunes en PowerPoint incluyen:

**Diseño de diapositiva de título** – Incluye dos marcadores de posición de texto: uno para el título y otro para el subtítulo.

**Diseño de título y contenido** – Presenta un marcador de posición de título más pequeño en la parte superior y uno más grande debajo para el contenido principal (como texto, viñetas, gráficos, imágenes y más).

**Diseño en blanco** – No contiene marcadores de posición, dándole control total para diseñar la diapositiva desde cero.

Los diseños de diapositiva forman parte de una diapositiva maestra, que es la diapositiva de nivel superior que define los estilos de diseño para la presentación. Puede acceder y modificar las diapositivas de diseño a través de la diapositiva maestra, ya sea por su tipo, nombre o ID único. Alternativamente, puede editar una diapositiva de diseño específica directamente dentro de la presentación.

Para trabajar con diseños de diapositiva en Aspose.Slides para Android, puede usar:

- Métodos como [getLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getLayoutSlides--) y [getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) bajo la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)
- Tipos como [ILayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutplaceholdermanager/), y [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Para obtener más información sobre el trabajo con diapositivas maestras, consulte el artículo [Slide Master](/slides/es/androidjava/slide-master/).
{{% /alert %}}

## **Agregar diseños de diapositiva a presentaciones**

Para personalizar la apariencia y la estructura de sus diapositivas, puede que necesite agregar nuevas diapositivas de diseño a una presentación. Aspose.Slides para Android le permite verificar si un diseño específico ya existe, agregar uno nuevo si es necesario y usarlo para insertar diapositivas basadas en ese diseño.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Acceda a la [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterlayoutslidecollection/).
1. Verifique si la diapositiva de diseño deseada ya existe en la colección. Si no, agregue la diapositiva de diseño que necesita.
1. Agregue una diapositiva vacía basada en la nueva diapositiva de diseño.
1. Guarde la presentación.

El siguiente código Java muestra cómo agregar un diseño de diapositiva a una presentación de PowerPoint:
```java
// Instanciar la clase Presentation que representa un archivo PowerPoint.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // Recorrer los tipos de diapositivas de diseño para seleccionar una diapositiva de diseño.
    IMasterLayoutSlideCollection layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide layoutSlide = null;
    if (layoutSlides.getByType(SlideLayoutType.TitleAndObject) != null)
        layoutSlide = layoutSlides.getByType(SlideLayoutType.TitleAndObject);
    else
        layoutSlide = layoutSlides.getByType(SlideLayoutType.Title);

    if (layoutSlide == null) {
        // Situación en la que la presentación no contiene todos los tipos de diseños.
        // El archivo de presentación contiene solo tipos de diseño en blanco y personalizados.
        // Sin embargo, las diapositivas de diseño con tipos personalizados pueden tener nombres reconocibles,
        // como "Title", "Title and Content", etc., que pueden usarse para la selección de diapositivas de diseño.
        // También puede basarse en un conjunto de tipos de formas de marcador de posición.
        // Por ejemplo, una diapositiva de título debería tener solo el tipo de marcador de posición Title, y así sucesivamente.
        for (ILayoutSlide titleAndObjectLayoutSlide : layoutSlides) {
            if (titleAndObjectLayoutSlide.getName().equals("Title and Object")) {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null) {
            for (ILayoutSlide titleLayoutSlide : layoutSlides) {
                if (titleLayoutSlide.getName().equals("Title")) {
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

    // Añadir una diapositiva vacía usando la diapositiva de diseño añadida.
    presentation.getSlides().insertEmptySlide(0, layoutSlide);

    // Guardar la presentación en disco.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Eliminar diseños de diapositiva no utilizados**

Aspose.Slides proporciona el método [removeUnusedLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) de la clase [Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/) para permitirle eliminar diseños de diapositiva no deseados y sin uso.

El siguiente código Java muestra cómo eliminar una diapositiva de diseño de una presentación de PowerPoint:
```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Agregar marcadores de posición a diseños de diapositiva**

Aspose.Slides ofrece el método [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) que permite agregar nuevos marcadores de posición a una diapositiva de diseño.

Este administrador contiene métodos para los siguientes tipos de marcadores de posición:

| Marcador de posición de PowerPoint | Método de [ILayoutPlaceholderManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutplaceholdermanager/) |
| ----------------------------------- | ------------------------------------------------------------ |
| ![Contenido](content.png) | addContentPlaceholder(float x, float y, float width, float height) |
| ![Contenido (Vertical)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Texto](text.png) | addTextPlaceholder(float x, float y, float width, float height) |
| ![Texto (Vertical)](textV.png) | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Imagen](picture.png) | addPicturePlaceholder(float x, float y, float width, float height) |
| ![Gráfico](chart.png) | addChartPlaceholder(float x, float y, float width, float height) |
| ![Tabla](table.png) | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Multimedia](media.png) | addMediaPlaceholder(float x, float y, float width, float height) |
| ![Imagen en línea](onlineimage.png) | addOnlineImagePlaceholder(float x, float y, float width, float height) |

El siguiente código Java muestra cómo agregar nuevas formas de marcador de posición al diseño en blanco:
```java
Presentation presentation = new Presentation();
try {
    // Obtenga la diapositiva de diseño en blanco.
    ILayoutSlide layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    // Obtenga el administrador de marcadores de posición de la diapositiva de diseño.
    ILayoutPlaceholderManager placeholderManager = layout.getPlaceholderManager();

    // Añada diferentes marcadores de posición a la diapositiva de diseño en blanco.
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    // Añada una nueva diapositiva con el diseño en blanco.
    ISlide newSlide = presentation.getSlides().addEmptySlide(layout);

    presentation.save("Placeholders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


El resultado:

![Los marcadores de posición en la diapositiva de diseño](add_placeholders.png)

## **Establecer visibilidad del pie de página para una diapositiva de diseño**

En presentaciones de PowerPoint, los elementos del pie de página como la fecha, el número de diapositiva y el texto personalizado pueden mostrarse u ocultarse según el diseño de la diapositiva. Aspose.Slides para Android le permite controlar la visibilidad de estos marcadores de posición de pie de página. Esto es útil cuando desea que ciertos diseños muestren información de pie de página mientras que otros permanecen limpios y mínimos.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Obtenga una referencia a la diapositiva de diseño por su índice.
1. Establezca el marcador de posición del pie de página de la diapositiva como visible.
1. Establezca el marcador de posición del número de diapositiva como visible.
1. Establezca el marcador de posición de fecha y hora como visible.
1. Guarde la presentación.

El siguiente código Java muestra cómo establecer la visibilidad del pie de página de una diapositiva y realizar tareas relacionadas:
```java
Presentation presentation = new Presentation("Presentation.ppt");
try {
    ILayoutSlideHeaderFooterManager headerFooterManager = presentation.getLayoutSlides().get_Item(0).getHeaderFooterManager();

    if (!headerFooterManager.isFooterVisible()) {
        headerFooterManager.setFooterVisibility(true);
    }

    if (!headerFooterManager.isSlideNumberVisible()) {
        headerFooterManager.setSlideNumberVisibility(true);
    }

    if (!headerFooterManager.isDateTimeVisible()) {
        headerFooterManager.setDateTimeVisibility(true);
    }

    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("Presentation.ppt", SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```


## **Establecer visibilidad del pie de página hijo para una diapositiva**

En presentaciones de PowerPoint, los elementos del pie de página como la fecha, el número de diapositiva y el texto personalizado pueden controlarse a nivel de la diapositiva maestra para garantizar coherencia en todas las diapositivas de diseño. Aspose.Slides para Android permite establecer la visibilidad y el contenido de estos marcadores de posición de pie de página en la diapositiva maestra y propagar estos ajustes a todas las diapositivas de diseño hijas. Este enfoque asegura información uniforme de pie de página en toda la presentación.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Obtenga una referencia a la diapositiva maestra por su índice.
1. Establezca los marcadores de posición de pie de página de la maestra y de todos los hijos como visibles.
1. Establezca los marcadores de posición del número de diapositiva de la maestra y de todos los hijos como visibles.
1. Establezca los marcadores de posición de fecha y hora de la maestra y de todos los hijos como visibles.
1. Guarde la presentación.

El siguiente código Java demuestra esta operación:
```java
Presentation presentation = new Presentation("Presentation.ppt");
try {
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();

    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Preguntas frecuentes**

**¿Cuál es la diferencia entre una diapositiva maestra y una diapositiva de diseño?**

Una diapositiva maestra define el tema general y el formato predeterminado, mientras que las diapositivas de diseño definen disposiciones específicas de marcadores de posición para diferentes tipos de contenido.

**¿Puedo copiar una diapositiva de diseño de una presentación a otra?**

Sí, puede clonar una diapositiva de diseño de la colección de diapositivas de diseño de una presentación, accesible mediante el método [getLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getLayoutSlides--), e insertarla en otra presentación usando el método `addClone`.

**¿Qué sucede si elimino una diapositiva de diseño que todavía es usada por una diapositiva?**

Si intenta eliminar una diapositiva de diseño que todavía está referenciada por al menos una diapositiva en la presentación, Aspose.Slides lanzará una [PptxEditException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxeditexception/). Para evitarlo, use [removeUnusedLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) que elimina de forma segura solo las diapositivas de diseño que no están en uso.