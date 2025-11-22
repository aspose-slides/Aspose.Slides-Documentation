---
title: Aplicar o Cambiar un Diseño de Diapositiva en JavaScript
linktitle: Diseño de Diapositiva
type: docs
weight: 60
url: /es/nodejs-java/slide-layout/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda cómo administrar y personalizar los diseños de diapositiva en Aspose.Slides para Node.js. Explore los tipos de diseño, el control de marcadores de posición, la visibilidad del pie de página y la manipulación de diseños mediante ejemplos de código en JavaScript."
---

## **Visión general**

Un diseño de diapositiva define la disposición de los cuadros de marcador de posición y el formato del contenido en una diapositiva. Controla qué marcadores de posición están disponibles y dónde aparecen. Los diseños de diapositiva le ayudan a crear presentaciones de forma rápida y coherente, ya sea que esté creando algo simple o más complejo. Algunos de los diseños de diapositiva más comunes en PowerPoint incluyen:

**Diseño de diapositiva de título** – Incluye dos marcadores de posición de texto: uno para el título y otro para el subtítulo.

**Diseño de título y contenido** – Presenta un marcador de posición de título más pequeño en la parte superior y uno más grande debajo para el contenido principal (como texto, viñetas, gráficos, imágenes y más).

**Diseño en blanco** – No contiene marcadores de posición, lo que le brinda control total para diseñar la diapositiva desde cero.

Los diseños de diapositiva forman parte de una diapositiva maestra, que es la diapositiva de nivel superior que define los estilos de diseño para la presentación. Puede acceder y modificar los diseños de diapositiva a través de la diapositiva maestra, ya sea por su tipo, nombre o ID único. Alternativamente, puede editar un diseño de diapositiva específico directamente dentro de la presentación.

Para trabajar con diseños de diapositiva en Aspose.Slides for Node.js, puede usar:

- Métodos como [getLayoutSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getLayoutSlides) y [getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getMasters) bajo la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 
- Tipos como [LayoutSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterlayoutslidecollection/), [LayoutPlaceholderManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutplaceholdermanager/) y [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Para obtener más información sobre el trabajo con diapositivas maestras, consulte el artículo [Slide Master](/slides/es/nodejs-java/slide-master/).
{{% /alert %}}

## **Agregar diseños de diapositiva a presentaciones**

Para personalizar la apariencia y estructura de sus diapositivas, puede que necesite agregar nuevos diseños de diapositiva a una presentación. Aspose.Slides for Node.js le permite verificar si un diseño específico ya existe, agregar uno nuevo si es necesario y usarlo para insertar diapositivas basadas en ese diseño.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Acceda a la [MasterLayoutSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterlayoutslidecollection/).
1. Verifique si el diseño de diapositiva deseado ya existe en la colección. Si no, añada el diseño de diapositiva que necesita.
1. Añada una diapositiva en blanco basada en el nuevo diseño de diapositiva.
1. Guarde la presentación.

El siguiente código JavaScript muestra cómo agregar un diseño de diapositiva a una presentación de PowerPoint:
```js
// Instanciar la clase Presentation que representa un archivo PowerPoint.
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    // Recorrer los tipos de diapositivas de diseño para seleccionar una diapositiva de diseño.
    let layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    let layoutSlide = null;
    if (layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject)) != null) {
        layoutSlide = layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject));
    } else {
        layoutSlide = layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.Title));
    }

    if (layoutSlide == null) {
        // Situación en la que la presentación no contiene todos los tipos de diseño.
        // El archivo de presentación contiene solo los tipos de diseño Blank y Custom.
        // Sin embargo, las diapositivas de diseño con tipos personalizados pueden tener nombres reconocibles,
        // como "Title", "Title and Content", etc., que pueden usarse para la selección de diapositivas de diseño.
        // También puedes basarte en un conjunto de tipos de forma de marcador de posición.
        // Por ejemplo, una diapositiva Title debería tener solo el tipo de marcador de posición Title, y así sucesivamente.
        for (let i = 0; i < layoutSlides.size(); i++) {
            let titleAndObjectLayoutSlide = layoutSlides.get_Item(i);
            if (titleAndObjectLayoutSlide.getName() === "Title and Object") {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null) {
            for (let i = 0; i < layoutSlides.size(); i++) {
                let titleLayoutSlide = layoutSlides.get_Item(i);
                if (titleLayoutSlide.getName() === "Title") {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }

            if (layoutSlide == null) {
                layoutSlide = layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.Blank));
                if (layoutSlide == null) {
                    layoutSlide = layoutSlides.add(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject), "Title and Object");
                }
            }
        }
    }

    // Añadir una diapositiva vacía usando la diapositiva de diseño añadida.
    presentation.getSlides().insertEmptySlide(0, layoutSlide);

    // Guardar la presentación en disco.
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Eliminar diseños de diapositiva no utilizados**

Aspose.Slides proporciona el método [removeUnusedLayoutSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) de la clase [Compress](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/) para permitirle eliminar diseños de diapositiva no deseados y sin usar.

El siguiente código JavaScript muestra cómo eliminar un diseño de diapositiva de una presentación de PowerPoint:
```js
let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Agregar marcadores de posición a los diseños de diapositiva**

Aspose.Slides proporciona el método [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslide/#getPlaceholderManager), que le permite agregar nuevos marcadores de posición a un diseño de diapositiva.

Este gestor contiene métodos para los siguientes tipos de marcadores de posición:

| Marcador de posición de PowerPoint | Método [LayoutPlaceholderManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutplaceholdermanager/) |
| ----------------------------------- | ------------------------------------------------------------ |
| ![Contenido](content.png) | addContentPlaceholder(float x, float y, float width, float height) |
| ![Contenido (Vertical)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Texto](text.png) | addTextPlaceholder(float x, float y, float width, float height) |
| ![Texto (Vertical)](textV.png) | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Imagen](picture.png) | addPicturePlaceholder(float x, float y, float width, float height) |
| ![Gráfico](chart.png) | addChartPlaceholder(float x, float y, float width, float height) |
| ![Tabla](table.png) | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Medios](media.png) | addMediaPlaceholder(float x, float y, float width, float height) |
| ![Imagen en línea](onlineimage.png) | addOnlineImagePlaceholder(float x, float y, float width, float height) |

El siguiente código JavaScript muestra cómo agregar nuevas formas de marcador de posición al diseño en blanco:
```js
let presentation = new aspose.slides.Presentation();
try {
    // Obtener la diapositiva de diseño en blanco.
    let layout = presentation.getLayoutSlides().getByType(java.newByte(aspose.slides.SlideLayoutType.Blank));

    // Obtener el gestor de marcadores de posición de la diapositiva de diseño.
    let placeholderManager = layout.getPlaceholderManager();

    // Agregar diferentes marcadores de posición a la diapositiva de diseño en blanco.
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    // Agregar una nueva diapositiva con el diseño en blanco.
    let newSlide = presentation.getSlides().addEmptySlide(layout);

    presentation.save("Placeholders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


El resultado:

![Los marcadores de posición en el diseño de diapositiva](add_placeholders.png)

## **Establecer visibilidad del pie de página para un diseño de diapositiva**

En presentaciones de PowerPoint, los elementos de pie de página como la fecha, el número de diapositiva y el texto personalizado pueden mostrarse u ocultarse según el diseño de la diapositiva. Aspose.Slides for Node.js le permite controlar la visibilidad de estos marcadores de posición de pie de página. Esto es útil cuando desea que ciertos diseños muestren información de pie de página mientras que otros permanezcan limpios y mínimos.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Obtenga una referencia a un diseño de diapositiva por su índice.
1. Establezca el marcador de posición del pie de página de la diapositiva como visible.
1. Establezca el marcador de posición del número de diapositiva como visible.
1. Establezca el marcador de posición de fecha y hora como visible.
1. Guarde la presentación.

El siguiente código JavaScript muestra cómo establecer la visibilidad del pie de página de una diapositiva y realizar tareas relacionadas:
```js
let presentation = new aspose.slides.Presentation("Presentation.ppt");
try {
    let headerFooterManager = presentation.getLayoutSlides().get_Item(0).getHeaderFooterManager();

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

    presentation.save("Presentation.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```


## **Establecer visibilidad del pie de página secundario para una diapositiva**

En presentaciones de PowerPoint, los elementos de pie de página como la fecha, el número de diapositiva y el texto personalizado pueden controlarse a nivel de la diapositiva maestra para garantizar la consistencia en todos los diseños de diapositiva. Aspose.Slides for Node.js le permite establecer la visibilidad y el contenido de estos marcadores de posición de pie de página en la diapositiva maestra y propagar estos ajustes a todos los diseños de diapositiva secundarios. Este enfoque garantiza información de pie de página uniforme en toda su presentación.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Obtenga una referencia a la diapositiva maestra por su índice.
1. Establezca los marcadores de posición del pie de página de la maestra y de todos los diseños secundarios como visibles.
1. Establezca los marcadores de posición del número de diapositiva de la maestra y de todos los diseños secundarios como visibles.
1. Establezca los marcadores de posición de fecha y hora de la maestra y de todos los diseños secundarios como visibles.
1. Guarde la presentación.

El siguiente código JavaScript demuestra esta operación:
```js
let presentation = new aspose.slides.Presentation("Presentation.ppt");
try {
    let headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();

    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Preguntas frecuentes**

**¿Cuál es la diferencia entre una diapositiva maestra y un diseño de diapositiva?**

Una diapositiva maestra define el tema general y el formato predeterminado, mientras que los diseños de diapositiva definen disposiciones específicas de marcadores de posición para diferentes tipos de contenido.

**¿Puedo copiar un diseño de diapositiva de una presentación a otra?**

Sí, puede clonar un diseño de diapositiva de la colección de diseños de diapositiva de una presentación, accesible mediante el método [getLayoutSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getLayoutSlides), e insertarlo en otra presentación usando el método `addClone`.

**¿Qué ocurre si elimino un diseño de diapositiva que todavía es utilizado por una diapositiva?**

Si intenta eliminar un diseño de diapositiva que aún está referenciado por al menos una diapositiva en la presentación, Aspose.Slides lanzará una [PptxEditException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxeditexception/). Para evitarlo, use [removeUnusedLayoutSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides), que elimina de forma segura solo los diseños de diapositiva que no están en uso.