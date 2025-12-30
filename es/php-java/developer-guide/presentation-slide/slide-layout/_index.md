---
title: Aplicar o cambiar diseños de diapositiva en PHP
linktitle: Diseño de diapositiva
type: docs
weight: 60
url: /es/php-java/slide-layout/
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
- contenido con leyenda
- imagen con leyenda
- título y texto vertical
- título vertical y texto
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Gestiona y personaliza los diseños de diapositiva en Aspose.Slides para PHP mediante Java. Explora los tipos de diseño, el control de marcadores de posición y la visibilidad del pie de página a través de ejemplos de código."
---

## **Visión general**

Un diseño de diapositiva define la disposición de los recuadros de marcadores de posición y el formato del contenido de una diapositiva. Controla qué marcadores de posición están disponibles y dónde aparecen. Los diseños de diapositiva le ayudan a crear presentaciones de forma rápida y coherente, ya sea que esté creando algo sencillo o más complejo. Algunos de los diseños de diapositiva más comunes en PowerPoint incluyen:

**Diseño de diapositiva de título** – Incluye dos marcadores de posición de texto: uno para el título y otro para el subtítulo.

**Diseño de Título y Contenido** – Presenta un marcador de posición de título más pequeño en la parte superior y uno más grande debajo para el contenido principal (como texto, viñetas, gráficos, imágenes y más).

**Diseño en blanco** – No contiene marcadores de posición, lo que le brinda control total para diseñar la diapositiva desde cero.

Los diseños de diapositiva forman parte de una diapositiva maestra, que es la diapositiva de nivel superior que define los estilos de diseño para la presentación. Puede acceder y modificar los diseños de diapositiva a través de la diapositiva maestra, ya sea por su tipo, nombre o ID único. Alternativamente, puede editar un diseño de diapositiva específico directamente dentro de la presentación.

Para trabajar con diseños de diapositiva en Aspose.Slides for PHP, puede usar:

- Métodos como [getLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getLayoutSlides) y [getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getMasters) bajo la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)
- Tipos como [LayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/masterlayoutslidecollection/), [LayoutPlaceholderManager](https://reference.aspose.com/slides/php-java/aspose.slides/layoutplaceholdermanager/) y [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Para obtener más información sobre el trabajo con diapositivas maestras, consulte el artículo [Diapositiva maestra](/slides/es/php-java/slide-master/).
{{% /alert %}}

## **Agregar diseños de diapositiva a presentaciones**

Para personalizar la apariencia y la estructura de sus diapositivas, puede necesitar agregar nuevos diseños de diapositiva a una presentación. Aspose.Slides for PHP le permite comprobar si un diseño específico ya existe, agregar uno nuevo si es necesario y usarlo para insertar diapositivas basadas en ese diseño.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Acceda a la [MasterLayoutSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/masterlayoutslidecollection/).
3. Compruebe si el diseño de diapositiva deseado ya existe en la colección. Si no, añada el diseño de diapositiva que necesita.
4. Añada una diapositiva vacía basada en el nuevo diseño de diapositiva.
5. Guarde la presentación.

El siguiente código PHP muestra cómo agregar un diseño de diapositiva a una presentación de PowerPoint:
```php
// Instanciar la clase Presentation que representa un archivo PowerPoint.
$presentation = new Presentation("Sample.pptx");
try {
    // Recorrer los tipos de diapositiva de diseño para seleccionar una diapositiva de diseño.
    $layoutSlides = $presentation->getMasters()->get_Item(0)->getLayoutSlides();
    $layoutSlide = null;
    if (!java_is_null($layoutSlides->getByType(SlideLayoutType::TitleAndObject))) {
        $layoutSlide = $layoutSlides->getByType(SlideLayoutType::TitleAndObject);
    } else {
        $layoutSlide = $layoutSlides->getByType(SlideLayoutType::Title);
    }

    if (java_is_null($layoutSlide)) {
        // Una situación en la que la presentación no contiene todos los tipos de diseño.
        // El archivo de presentación contiene solo tipos de diseño Blank y Custom.
        // Sin embargo, las diapositivas de diseño con tipos personalizados pueden tener nombres reconocibles,
        // como "Title", "Title and Content", etc., que pueden usarse para la selección de diapositiva de diseño.
        // También puedes basarte en un conjunto de tipos de forma de marcador de posición.
        // Por ejemplo, una diapositiva de título debería tener solo el tipo de marcador de posición Title, y así sucesivamente.
        foreach($layoutSlides as $titleAndObjectLayoutSlide) {
            if (java_values($titleAndObjectLayoutSlide->getName()) == "Title and Object") {
                $layoutSlide = $titleAndObjectLayoutSlide;
                break;
            }
        }

        if (java_is_null($layoutSlide)) {
            foreach($layoutSlides as $titleLayoutSlide) {
                if (java_values($titleLayoutSlide->getName()) == "Title") {
                    $layoutSlide = $titleLayoutSlide;
                    break;
                }
            }

            if (java_is_null($layoutSlide)) {
                $layoutSlide = $layoutSlides->getByType(SlideLayoutType::Blank);
                if (java_is_null($layoutSlide)) {
                    $layoutSlide = $layoutSlides->add(SlideLayoutType::TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // Añadir una diapositiva vacía usando la diapositiva de diseño añadida.
    $presentation->getSlides()->insertEmptySlide(0, $layoutSlide);

    // Guardar la presentación en disco.
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **Eliminar diseños de diapositiva no utilizados**

Aspose.Slides proporciona el método [removeUnusedLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) de la clase [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/) para permitirle eliminar diseños de diapositiva no deseados y sin uso.

El siguiente código PHP muestra cómo eliminar un diseño de diapositiva de una presentación de PowerPoint:
```php
$presentation = new Presentation("Presentation.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **Agregar marcadores de posición a los diseños de diapositiva**

Aspose.Slides proporciona el método [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/#getPlaceholderManager), que le permite agregar nuevos marcadores de posición a un diseño de diapositiva.

Este administrador contiene métodos para los siguientes tipos de marcadores de posición:

| Marcador de posición de PowerPoint | [LayoutPlaceholderManager](https://reference.aspose.com/slides/php-java/aspose.slides/layoutplaceholdermanager/) Método |
| ----------------------------------- | ------------------------------------------------------------ |
| ![Content](content.png) | addContentPlaceholder(float x, float y, float width, float height) |
| ![Content (Vertical)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Text](text.png) | addTextPlaceholder(float x, float y, float width, float height) |
| ![Text (Vertical)](textV.png) | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Picture](picture.png) | addPicturePlaceholder(float x, float y, float width, float height) |
| ![Chart](chart.png) | addChartPlaceholder(float x, float y, float width, float height) |
| ![Table](table.png) | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Media](media.png) | addMediaPlaceholder(float x, float y, float width, float height) |
| ![Online Image](onlineimage.png) | addOnlineImagePlaceholder(float x, float y, float width, float height) |

El siguiente código PHP muestra cómo agregar nuevas formas de marcadores de posición al diseño en blanco:
```php
$presentation = new Presentation();
try {
    // Obtén la diapositiva de diseño en blanco.
    $layout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

    // Obtén el gestor de marcadores de posición de la diapositiva de diseño.
    $placeholderManager = $layout->getPlaceholderManager();

    // Añade diferentes marcadores de posición a la diapositiva de diseño en blanco.
    $placeholderManager->addContentPlaceholder(20, 20, 310, 270);
    $placeholderManager->addVerticalTextPlaceholder(350, 20, 350, 270);
    $placeholderManager->addChartPlaceholder(20, 310, 310, 180);
    $placeholderManager->addTablePlaceholder(350, 310, 350, 180);

    // Añade una nueva diapositiva con el diseño en blanco.
    $newSlide = $presentation->getSlides()->addEmptySlide($layout);

    $presentation->save("Placeholders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


El resultado:

![Los marcadores de posición en el diseño de diapositiva](add_placeholders.png)

## **Establecer visibilidad del pie de página para un diseño de diapositiva**

En las presentaciones de PowerPoint, los elementos del pie de página como la fecha, el número de diapositiva y el texto personalizado pueden mostrarse u ocultarse según el diseño de la diapositiva. Aspose.Slides for PHP le permite controlar la visibilidad de estos marcadores de posición del pie de página. Esto es útil cuando desea que ciertos diseños muestren la información del pie de página mientras que otros permanezcan limpios y minimalistas.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Obtenga una referencia al diseño de diapositiva por su índice.
3. Establezca el marcador de posición del pie de página de la diapositiva como visible.
4. Establezca el marcador de posición del número de diapositiva como visible.
5. Establezca el marcador de posición de fecha y hora como visible.
6. Guarde la presentación.

El siguiente código PHP muestra cómo establecer la visibilidad del pie de página de una diapositiva y realizar tareas relacionadas:
```php
$presentation = new Presentation("Presentation.ppt");
try {
    $headerFooterManager = $presentation->getLayoutSlides()->get_Item(0)->getHeaderFooterManager();

    if (!$headerFooterManager->isFooterVisible()) {
        $headerFooterManager->setFooterVisibility(true);
    }

    if (!$headerFooterManager->isSlideNumberVisible()) {
        $headerFooterManager->setSlideNumberVisibility(true);
    }

    if (!$headerFooterManager->isDateTimeVisible()) {
        $headerFooterManager->setDateTimeVisibility(true);
    }

    $headerFooterManager->setFooterText("Footer text");
    $headerFooterManager->setDateTimeText("Date and time text");

    $presentation->save("Presentation.ppt", SaveFormat::Ppt);
} finally {
    $presentation->dispose();
}
```


## **Establecer visibilidad del pie de página hijo para una diapositiva**

En las presentaciones de PowerPoint, los elementos del pie de página como la fecha, el número de diapositiva y el texto personalizado pueden controlarse a nivel de diapositiva maestra para garantizar la coherencia en todas las diapositivas de diseño. Aspose.Slides for PHP le permite establecer la visibilidad y el contenido de estos marcadores de posición del pie de página en la diapositiva maestra y propagar estos ajustes a todas las diapositivas de diseño hijas. Este enfoque asegura una información de pie de página uniforme en toda la presentación.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Obtenga una referencia a la diapositiva maestra por su índice.
3. Establezca los marcadores de posición del pie de página de la maestra y de todas sus hijas como visibles.
4. Establezca los marcadores de posición del número de diapositiva de la maestra y de todas sus hijas como visibles.
5. Establezca los marcadores de posición de fecha y hora de la maestra y de todas sus hijas como visibles.
6. Guarde la presentación.

El siguiente código PHP demuestra esta operación:
```php
$presentation = new Presentation("presentation.ppt");
try {
    $headerFooterManager = $presentation->getMasters()->get_Item(0)->getHeaderFooterManager();

    $headerFooterManager->setFooterAndChildFootersVisibility(true);
    $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);

    $headerFooterManager->setFooterAndChildFootersText("Footer text");
    $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");

    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **Preguntas frecuentes**

**¿Cuál es la diferencia entre una diapositiva maestra y una diapositiva de diseño?**

Una diapositiva maestra define el tema general y el formato predeterminado, mientras que las diapositivas de diseño definen disposiciones específicas de marcadores de posición para diferentes tipos de contenido.

**¿Puedo copiar una diapositiva de diseño de una presentación a otra?**

Sí, puede clonar una diapositiva de diseño de la colección de diseños de una presentación, accesible mediante el método [getLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getLayoutSlides), e insertarla en otra presentación usando el método `addClone`.

**¿Qué ocurre si elimino una diapositiva de diseño que aún es utilizada por una diapositiva?**

Si intenta eliminar una diapositiva de diseño que todavía está referenciada por al menos una diapositiva en la presentación, Aspose.Slides lanzará una [PptxEditException](https://reference.aspose.com/slides/php-java/aspose.slides/pptxeditexception/). Para evitarlo, use [removeUnusedLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#removeUnusedLayoutSlides), que elimina de forma segura solo los diseños de diapositiva que no están en uso.