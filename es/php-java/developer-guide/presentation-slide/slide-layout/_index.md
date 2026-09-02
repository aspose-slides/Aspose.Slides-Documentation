---
title: Aplicar o cambiar disposiciones de diapositivas en PHP
linktitle: Disposición de diapositiva
type: docs
weight: 60
url: /es/php-java/slide-layout/
keywords:
- disposición de diapositiva
- disposición de contenido
- marcador de posición
- diseño de presentación
- diseño de diapositiva
- disposición sin usar
- visibilidad del pie de página
- diapositiva de título
- título y contenido
- encabezado de sección
- dos contenidos
- comparación
- solo título
- disposición en blanco
- contenido con leyenda
- imagen con leyenda
- título y texto vertical
- título vertical y texto
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Aplicar, crear y modificar disposiciones de diapositivas en Aspose.Slides para PHP mediante Java, añadir marcadores de posición, eliminar disposiciones sin usar y controlar la visibilidad del pie de página."
---
## **Visión general**

Una disposición de diapositiva define las posiciones y el formato de los marcadores de posición, como títulos, texto, imágenes, gráficos y tablas. Aplicar una disposición otorga a las diapositivas una estructura coherente y, al mismo tiempo, permite que cada diapositiva contenga su propio contenido.

Las disposiciones más comunes son:

- **Diapositiva de título**: Contiene marcadores de posición para el título y el subtítulo.  
- **Título y contenido**: Contiene un marcador de posición para el título y otro de propósito general para contenido.  
- **En blanco**: No contiene marcadores de posición y es útil cuando cada forma se colocará manualmente.

## **Comprender la herencia de disposiciones**

Una presentación tiene tres niveles relacionados:

1. Una [diapositiva maestra](https://reference.aspose.com/slides/es/php-java/aspose.slides/masterslide/) define el tema, el formato compartido, los fondos y los objetos comunes.  
1. Una [diapositiva de disposición](https://reference.aspose.com/slides/es/php-java/aspose.slides/layoutslide/) pertenece a una maestra y define una disposición concreta de marcadores de posición.  
1. Una [diapositiva normal](https://reference.aspose.com/slides/es/php-java/aspose.slides/slide/) utiliza una disposición y almacena el contenido introducido para esa diapositiva.

Una diapositiva normal hereda el tema y el formato de su disposición, y la disposición hereda de su maestra. Un valor establecido directamente en una diapositiva normal sobrescribe el valor heredado en ese nivel. Cuando se crea una diapositiva normal, sus formas de marcador de posición se generan a partir de la disposición seleccionada, mientras que el contenido introducido en esos marcadores pertenece a la diapositiva normal.

Añada los marcadores de posición necesarios a una disposición antes de crear diapositivas a partir de ella. Añadir otro marcador de posición a una disposición después no inserta automáticamente una forma correspondiente en las diapositivas normales existentes.

Esta relación tiene dos consecuencias importantes:

- Cambiar el formato heredado o la geometría de los marcadores de posición existentes en una disposición puede actualizar todas las diapositivas que dependen de ella. Antes de editar una disposición que ya está en uso, revise sus diapositivas dependientes y el resultado de la presentación.  
- Una disposición que aún es utilizada por alguna diapositiva no puede eliminarse. Reasigne primero sus diapositivas dependientes a otra disposición, o elimine solo las disposiciones no utilizadas.

Para obtener más información sobre el nivel superior de esta jerarquía, consulte [Maestro de diapositivas](/slides/es/php-java/slide-master/).

## **Seleccionar y aplicar una disposición de diapositiva**

Utilice un tipo de disposición cuando la presentación sigue las definiciones estándar de PowerPoint. Los nombres de disposiciones son editables por el usuario y pueden localizarse, por lo que la selección basada en nombre es menos fiable a menos que controle la plantilla origen.

El siguiente ejemplo busca **Título y contenido** en la primera maestra. Si esa disposición no está disponible, recurre deliberadamente a **En blanco**. La segunda comprobación de nulo es necesaria porque una presentación puede contener solo disposiciones personalizadas. La disposición seleccionada se aplica entonces a la primera diapositiva normal mediante el método [Slide.setLayoutSlide](https://reference.aspose.com/slides/es/php-java/aspose.slides/slide/#setLayoutSlide).

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

Cambiar la disposición de una diapositiva no elimina las formas ordinarias añadidas directamente a la diapositiva. Sin embargo, las posiciones de los marcadores de posición, el formato heredado y la correspondencia entre los marcadores existentes y la nueva disposición pueden variar, por lo que es conveniente inspeccionar el resultado al alternar entre disposiciones sustancialmente diferentes.

## **Añadir una diapositiva de disposición**

Seleccionar y crear son operaciones distintas. El ejemplo anterior selecciona una disposición existente; no la crea. Para crear una disposición, llame al método [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/es/php-java/aspose.slides/masterlayoutslidecollection/#add) de la colección de disposiciones de la maestra de destino.

El siguiente ejemplo siempre añade una nueva disposición **Título y contenido** llamada `Report Title and Content`, y luego añade una diapositiva normal basada en ella. Los nombres de disposición deben ser únicos dentro de la colección.

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

Añada una disposición solo cuando la plantilla necesite realmente otra estructura reutilizable. Si ya existe una disposición adecuada, selecciónela y reutilícela en lugar de crear un duplicado.

## **Añadir marcadores de posición a una diapositiva de disposición**

El método [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/es/php-java/aspose.slides/layoutslide/#getPlaceholderManager) proporciona un [LayoutPlaceholderManager](https://reference.aspose.com/slides/es/php-java/aspose.slides/layoutplaceholdermanager/) para añadir formas de marcador de posición a una disposición.

| Marcador de posición de PowerPoint | Método `LayoutPlaceholderManager` |
| ---------------------------------- | --------------------------------- |
| ![Contenido](content.png) | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/php-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Contenido (Vertical)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Texto](text.png) | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/php-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Texto (Vertical)](textV.png) | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Imagen](picture.png) | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/php-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Gráfico](chart.png) | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/php-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Tabla](table.png) | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/php-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/php-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Medios](media.png) | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/php-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Imagen en línea](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/php-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

El siguiente ejemplo verifica que la disposición **En blanco** exista, añade cuatro marcadores de posición y luego crea una diapositiva normal que utiliza la disposición modificada. El orden es intencional: los marcadores se añaden antes de crear la diapositiva normal, de modo que Aspose.Slides pueda generar las formas correspondientes en esa diapositiva.

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

![Los marcadores de posición en la diapositiva de disposición](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Cambiar el formato heredado o la geometría de los marcadores de posición existentes en una disposición puede afectar a las diapositivas dependientes. Un marcador de posición añadido recientemente no se retroalimenta en las diapositivas normales existentes. Pruebe los cambios de disposición en una copia de la presentación y revise cada diapositiva dependiente.
{{% /alert %}}

## **Eliminar disposiciones de diapositiva no utilizadas**

Utilice el método [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/es/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) para eliminar disposiciones que no sean referenciadas por ninguna diapositiva normal. El método deja intactas las disposiciones que todavía están en uso.

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

Para eliminar una disposición específica, primero use su método [hasDependingSlides](https://reference.aspose.com/slides/es/php-java/aspose.slides/layoutslide/#hasDependingSlides) o [getDependingSlides](https://reference.aspose.com/slides/es/php-java/aspose.slides/layoutslide/#getDependingSlides). Reasigne cualquier diapositiva dependiente antes de llamar a [LayoutSlide.remove](https://reference.aspose.com/slides/es/php-java/aspose.slides/layoutslide/#remove). Intentar eliminar una disposición en uso genera una [PptxEditException](https://reference.aspose.com/slides/es/php-java/aspose.slides/pptxeditexception/).

## **Controlar la visibilidad del pie de página en una disposición de diapositiva**

Una disposición tiene sus propios marcadores de posición de pie de página, número de diapositiva y fecha/hora. Utilice el método [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/es/php-java/aspose.slides/layoutslide/#getHeaderFooterManager) para controlar esos marcadores en una disposición concreta. Esto resulta útil, por ejemplo, cuando los diseños de contenido deben mostrar pies de página pero los diseños de título no.

El siguiente ejemplo selecciona una disposición de forma segura y hace visibles sus elementos de pie de página:

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

## **Controlar la visibilidad del pie de página en una maestra y sus disposiciones hijas**

Para aplicar ajustes de pie de página consistentes en toda la jerarquía de una maestra, utilice el método [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/es/php-java/aspose.slides/masterslide/#getHeaderFooterManager). Los métodos de propagación de [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/es/php-java/aspose.slides/masterslideheaderfootermanager/) actúan sobre la maestra y sus diapositivas de disposición y diapositivas normales; no se dirigen a una sola diapositiva normal.

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

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre una diapositiva maestra y una diapositiva de disposición?**

Una diapositiva maestra define el tema y el formato compartido de la presentación. Una diapositiva de disposición pertenece a una maestra y define una disposición reutilizable de marcadores de posición. Las diapositivas normales utilizan esas disposiciones y almacenan el contenido específico de cada diapositiva.

**¿Puedo copiar una diapositiva de disposición de una presentación a otra?**

Sí. Añada una copia a la colección de destino con el método [addClone](https://reference.aspose.com/slides/es/php-java/aspose.slides/globallayoutslidecollection/#addClone). Al copiar entre presentaciones, también verifique fuentes, temas, imágenes y otros recursos utilizados por la disposición origen.

**¿Qué ocurre si modifico una disposición que ya está en uso?**

Las diapositivas dependientes heredan los cambios de la disposición, salvo que sobrescriban localmente el formato u objetos afectados. Por ello, la geometría de los marcadores de posición y el estilo heredado pueden variar simultáneamente en muchas diapositivas. Use [getDependingSlides](https://reference.aspose.com/slides/es/php-java/aspose.slides/layoutslide/#getDependingSlides) para identificar las diapositivas afectadas antes de editar la disposición.

**¿Qué ocurre si elimino una disposición que sigue en uso?**

Aspose.Slides lanza una [PptxEditException](https://reference.aspose.com/slides/es/php-java/aspose.slides/pptxeditexception/). Reasigne primero las diapositivas dependientes o utilice [removeUnusedLayoutSlides](https://reference.aspose.com/slides/es/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) para eliminar solo las disposiciones no referenciadas.