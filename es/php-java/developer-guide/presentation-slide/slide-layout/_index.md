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
- diseño no usado
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
- PHP
- Aspose.Slides
description: "Aplicar, crear y modificar diseños de diapositiva en Aspose.Slides para PHP mediante Java, añadir marcadores de posición, eliminar diseños no usados y controlar la visibilidad del pie de página."
---
## **Visión general**

Un diseño de diapositiva define las posiciones y el formato de los marcadores de posición, como títulos, texto, imágenes, gráficos y tablas. Aplicar un diseño brinda a las diapositivas una estructura coherente mientras permite que cada diapositiva contenga su propio contenido.

Los diseños más comunes incluyen:

- **Diapositiva de título**: Contiene marcadores de posición de título y subtítulo.
- **Título y contenido**: Contiene un marcador de posición de título y un marcador de posición de contenido de propósito general.
- **En blanco**: No contiene marcadores de posición de contenido y es útil cuando cada forma se posicionará manualmente.

## **Comprender la herencia de los diseños**

Una presentación tiene tres niveles relacionados:

1. Una [diapositiva maestra](https://reference.aspose.com/slides/es/php-java/aspose.slides/masterslide/) define el tema, el formato compartido, los fondos y los objetos comunes.
1. Una [diapositiva de diseño](https://reference.aspose.com/slides/es/php-java/aspose.slides/layoutslide/) pertenece a una maestra y define una disposición particular de marcadores de posición.
1. Una [diapositiva normal](https://reference.aspose.com/slides/es/php-java/aspose.slides/slide/) utiliza un diseño y almacena el contenido introducido para esa diapositiva.

Una diapositiva normal hereda el tema y el formato de su diseño, y el diseño hereda de su maestra. Un valor establecido directamente en una diapositiva normal sobrescribe el valor heredado en ese nivel. Cuando se crea una diapositiva normal, sus formas de marcador de posición se generan a partir del diseño seleccionado, mientras que el contenido introducido en esos marcadores pertenece a la diapositiva normal.

Agregue los marcadores de posición necesarios a un diseño antes de crear diapositivas a partir de él. Añadir otro marcador de posición a un diseño posteriormente no agrega automáticamente una forma de marcador de posición correspondiente a las diapositivas normales existentes.

Esta relación tiene dos consecuencias importantes:

- Cambiar el formato heredado o la geometría de los marcadores de posición existentes en un diseño puede actualizar todas las diapositivas que dependen de él. Antes de editar un diseño que ya está en uso, inspeccione sus diapositivas dependientes y revise la presentación resultante.
- Un diseño que todavía es utilizado por una diapositiva no puede eliminarse. Reasigne sus diapositivas dependientes a otro diseño primero, o elimine solo los diseños no usados.

Para obtener más información sobre el nivel superior de esta jerarquía, consulte [Diapositiva maestra](/slides/es/php-java/slide-master/).

Para ocultar logotipos heredados o formas decorativas de la maestra en una diapositiva o mediante un diseño compartido, consulte [Controlar la visibilidad de los gráficos de la maestra](/slides/es/php-java/slide-master/). El ejemplo compara dos diapositivas que utilizan la misma maestra.

## **Seleccionar y aplicar un diseño de diapositiva**

Utilice un tipo de diseño cuando la presentación sigue definiciones estándar de diseños de PowerPoint. Los nombres de los diseños pueden ser editados por el usuario y pueden localizarse, por lo que la selección basada en nombres es menos fiable a menos que controle la plantilla de origen.

El siguiente ejemplo busca **Título y contenido** en la primera maestra. Si ese diseño no está disponible, recurre deliberadamente a **En blanco**. La segunda verificación de nulo es necesaria porque una presentación puede contener solo diseños personalizados. El diseño seleccionado se aplica luego a la primera diapositiva normal mediante el método [Slide.setLayoutSlide](https://reference.aspose.com/slides/es/php-java/aspose.slides/slide/#setLayoutSlide).

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlides = $presentation->getMasters()->get_Item(0)->getLayoutSlides();
    $targetLayout = $layoutSlides->getByType(SlideLayoutType::TitleAndObject);

    if (java_is_null($targetLayout)) {
        $targetLayout = $layoutSlides->getByType(SlideLayoutType::Blank);
    }

    if (java_is_null($targetLayout)) {
        throw new \RuntimeException("The first master does not contain a suitable layout slide.");
    }

    $presentation->getSlides()->get_Item(0)->setLayoutSlide($targetLayout);
    $presentation->save("output-with-new-layout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Cambiar el diseño de una diapositiva no elimina las formas habituales añadidas directamente a la diapositiva. Sin embargo, las posiciones de los marcadores de posición, el formato heredado y la correspondencia entre los marcadores existentes y el nuevo diseño pueden cambiar, por lo que es necesario inspeccionar el resultado al alternar entre diseños sustancialmente diferentes.

## **Agregar una diapositiva de diseño**

La selección y la creación son operaciones distintas. El ejemplo anterior selecciona un diseño existente; no lo crea. Para crear un diseño, invoque el método [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/es/php-java/aspose.slides/masterlayoutslidecollection/#add) en la colección de diseños de la maestra de destino.

El siguiente ejemplo siempre añade un nuevo **Título y contenido** llamado `Report Title and Content`, y luego agrega una diapositiva normal basada en él. Los nombres de los diseños deben ser únicos dentro de la colección.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $reportLayout = $masterSlide->getLayoutSlides()->add(SlideLayoutType::TitleAndObject, "Report Title and Content");
    $presentation->getSlides()->addEmptySlide($reportLayout);

    $presentation->save("output-with-report-layout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Agregue un diseño solo cuando la plantilla realmente necesite otra estructura reutilizable. Si ya existe un diseño adecuado, selecciónelo y reutilícelo en lugar de crear un duplicado.

## **Agregar marcadores de posición a una diapositiva de diseño**

El método [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/es/php-java/aspose.slides/layoutslide/#getPlaceholderManager) proporciona un [LayoutPlaceholderManager](https://reference.aspose.com/slides/es/php-java/aspose.slides/layoutplaceholdermanager/) para añadir formas de marcador de posición a un diseño.

| Marcador de posición PowerPoint | `LayoutPlaceholderManager` Method |
| ----------------------------------- | --------------------------------- |
| ![Contenido](content.png) | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/php-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Contenido (vertical)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Texto](text.png) | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/php-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Texto (vertical)](textV.png) | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Imagen](picture.png) | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/php-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Gráfico](chart.png) | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/php-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Tabla](table.png) | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/php-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/php-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Medios](media.png) | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/php-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Imagen en línea](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/php-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

El siguiente ejemplo verifica que el diseño **En blanco** exista, añade cuatro marcadores de posición a él y luego crea una diapositiva normal que utilice el diseño modificado. El orden es intencional: los marcadores de posición se añaden antes de crear la diapositiva normal, de modo que Aspose.Slides pueda generar las formas de marcador de posición correspondientes en esa diapositiva.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation();
try {
    $blankLayout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

    if (java_is_null($blankLayout)) {
        throw new \RuntimeException("The presentation does not contain a Blank layout slide.");
    }

    $placeholderManager = $blankLayout->getPlaceholderManager();
    $placeholderManager->addContentPlaceholder(20, 20, 310, 270);
    $placeholderManager->addVerticalTextPlaceholder(350, 20, 350, 270);
    $placeholderManager->addChartPlaceholder(20, 310, 310, 180);
    $placeholderManager->addTablePlaceholder(350, 310, 350, 180);

    $presentation->getSlides()->addEmptySlide($blankLayout);
    $presentation->save("output-with-placeholders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

El resultado:

![Los marcadores de posición en la diapositiva de diseño](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Modificar el formato heredado o la geometría de los marcadores de posición del diseño existente puede afectar a las diapositivas dependientes. Un marcador de posición de diseño recién añadido no se rellena retroactivamente en las diapositivas normales existentes. Pruebe los cambios de diseño en una copia de la presentación e inspeccione cada diapositiva dependiente.
{{% /alert %}}

## **Eliminar diseños de diapositiva no utilizados**

Utilice el método [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/es/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) para eliminar los diseños que no son referenciados por ninguna diapositiva normal. El método deja intactos los diseños que todavía están en uso.

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    $presentation->save("output-without-unused-layouts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Para eliminar un diseño específico, primero utilice su método [hasDependingSlides](https://reference.aspose.com/slides/es/php-java/aspose.slides/layoutslide/#hasDependingSlides) o [getDependingSlides](https://reference.aspose.com/slides/es/php-java/aspose.slides/layoutslide/#getDependingSlides). Reasigne cualquier diapositiva dependiente antes de llamar a [LayoutSlide.remove](https://reference.aspose.com/slides/es/php-java/aspose.slides/layoutslide/#remove). Intentar eliminar un diseño en uso genera una [PptxEditException](https://reference.aspose.com/slides/es/php-java/aspose.slides/pptxeditexception/).

## **Controlar la visibilidad del pie de página en una diapositiva de diseño**

Un diseño tiene sus propios marcadores de posición de pie de página, número de diapositiva y fecha/hora. Utilice el método [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/es/php-java/aspose.slides/layoutslide/#getHeaderFooterManager) para controlar esos marcadores de posición en un diseño. Esto es útil cuando, por ejemplo, los diseños de contenido deben mostrar pies de página pero los diseños de título no.

El siguiente ejemplo selecciona un diseño de forma segura y hace visibles sus elementos de pie de página:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::TitleAndObject);

    if (java_is_null($layoutSlide)) {
        $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    }

    if (java_is_null($layoutSlide)) {
        throw new \RuntimeException("The presentation does not contain a suitable layout slide.");
    }

    $headerFooterManager = $layoutSlide->getHeaderFooterManager();
    $headerFooterManager->setFooterVisibility(true);
    $headerFooterManager->setSlideNumberVisibility(true);
    $headerFooterManager->setDateTimeVisibility(true);
    $headerFooterManager->setFooterText("Footer text");
    $headerFooterManager->setDateTimeText("Date and time text");

    $presentation->save("output-with-layout-footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Controlar la visibilidad del pie de página en una maestra y sus diseños hijos**

Para aplicar configuraciones de pie de página consistentes en toda una jerarquía de maestra, utilice el método [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/es/php-java/aspose.slides/masterslide/#getHeaderFooterManager). Los métodos de propagación de [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/es/php-java/aspose.slides/masterslideheaderfootermanager/) actúan sobre la maestra y sus diapositivas de diseño y diapositivas normales dependientes; no se dirigen a una sola diapositiva normal.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $headerFooterManager = $presentation->getMasters()->get_Item(0)->getHeaderFooterManager();
    $headerFooterManager->setFooterAndChildFootersVisibility(true);
    $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);
    $headerFooterManager->setFooterAndChildFootersText("Footer text");
    $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");

    $presentation->save("output-with-master-footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**¿Cuál es la diferencia entre una diapositiva maestra y una diapositiva de diseño?**

Una diapositiva maestra define el tema y el formato compartido de la presentación. Una diapositiva de diseño pertenece a una maestra y define una disposición reutilizable de marcadores de posición. Las diapositivas normales usan esos diseños y almacenan contenido específico de cada diapositiva.

**¿Puedo copiar una diapositiva de diseño de una presentación a otra?**

Sí. Añada una copia a la colección de destino mediante el método [addClone](https://reference.aspose.com/slides/es/php-java/aspose.slides/globallayoutslidecollection/#addClone). Al copiar entre presentaciones, también verifique fuentes, temas, imágenes y otros recursos utilizados por el diseño de origen.

**¿Qué ocurre cuando modifico un diseño que ya está en uso?**

Las diapositivas dependientes heredan los cambios del diseño a menos que sobrescriban localmente el formato u objetos afectados. Por lo tanto, la geometría de los marcadores de posición y el estilo heredado pueden cambiar en muchas diapositivas a la vez. Utilice [getDependingSlides](https://reference.aspose.com/slides/es/php-java/aspose.slides/layoutslide/#getDependingSlides) para identificar las diapositivas afectadas antes de editar el diseño.

**¿Qué ocurre si elimino un diseño que todavía está en uso?**

Aspose.Slides lanza una [PptxEditException](https://reference.aspose.com/slides/es/php-java/aspose.slides/pptxeditexception/). Reasigne primero las diapositivas dependientes, o utilice [removeUnusedLayoutSlides](https://reference.aspose.com/slides/es/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) para eliminar solo los diseños no referenciados.