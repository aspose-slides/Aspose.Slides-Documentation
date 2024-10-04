---
title: Diseño de Diapositivas
type: docs
weight: 60
url: /php-java/slide-layout/
keyword: "Establecer tamaño de diapositiva, establecer opciones de diapositiva, especificar tamaño de diapositiva, visibilidad del pie de página, pie de página secundario, escalado de contenido, tamaño de página, Java, Aspose.Slides"
description: "Configura el tamaño y las opciones de diapositivas de PowerPoint"
---

Un diseño de diapositiva contiene las cajas de marcador de posición y la información de formato para todo el contenido que aparece en una diapositiva. El diseño determina los marcadores de posición de contenido disponibles y dónde se colocan.

Los diseños de diapositivas te permiten crear y diseñar presentaciones rápidamente (ya sean simples o complejas). Estos son algunos de los diseños de diapositivas más populares utilizados en presentaciones de PowerPoint:

* **Diseño de Diapositiva de Título**. Este diseño consta de dos marcadores de posición de texto. Un marcador de posición es para el título y el otro es para el subtítulo.
* **Diseño de Título y Contenido**. Este diseño contiene un marcador de posición relativamente pequeño en la parte superior para el título y un marcador de posición más grande para el contenido principal (gráfico, párrafos, lista con viñetas, lista numerada, imágenes, etc.).
* **Diseño en Blanco**. Este diseño carece de marcadores de posición, por lo que te permite crear elementos desde cero.

Dado que un máster de diapositivas es la diapositiva jerárquica principal que almacena información sobre los diseños de diapositivas, puedes usar la diapositiva maestra para acceder a los diseños de diapositivas y hacer cambios en ellos. Se puede acceder a una diapositiva de diseño por tipo o nombre. Del mismo modo, cada diapositiva tiene un identificador único, que se puede usar para acceder a ella.

Alternativamente, puedes hacer cambios directamente en un diseño de diapositiva específico en una presentación.

* Para permitirte trabajar con diseños de diapositivas (incluidos los que están en diapositivas maestras), Aspose.Slides proporciona propiedades como [getLayoutSlides()](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getLayoutSlides--) y [getMasters()](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getMasters--) bajo la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
* Para realizar tareas relacionadas, Aspose.Slides proporciona [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/masterlayoutslidecollection/), [SlideSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/), [BaseSlideHeaderFooterManager](https://reference.aspose.com/slides/php-java/aspose.slides/baseslideheaderfootermanager/), y muchos otros tipos.

{{% alert title="Info" color="info" %}}

Para obtener más información sobre cómo trabajar con Diapositivas Maestras en particular, consulta el artículo [Diapositiva Maestra](https://docs.aspose.com/slides/php-java/slide-master/).

{{% /alert %}}

## **Agregar Diseño de Diapositiva a la Presentación**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Accede a la colección [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/imasterlayoutslidecollection/).
1. Revisa las diapositivas de diseño existentes para confirmar que el diseño de diapositiva requerido ya existe en la colección de diapositivas de diseño. De lo contrario, añade el diseño de diapositiva que deseas.
1. Agrega una diapositiva vacía basada en la nueva diapositiva de diseño.
1. Guarda la presentación.

Este código PHP te muestra cómo añadir un diseño de diapositiva a una presentación de PowerPoint:

```php
  # Instancia una clase Presentation que representa el archivo de presentación
  $pres = new Presentation("AccessSlides.pptx");
  try {
    # Revisa tipos de diapositivas de diseño
    $layoutSlides = $pres->getMasters()->get_Item(0)->getLayoutSlides();
    $layoutSlide = null;
    if (!java_is_null($layoutSlides->getByType(SlideLayoutType::TitleAndObject))) {
      $layoutSlide = $layoutSlides->getByType(SlideLayoutType::TitleAndObject);
    } else {
      $layoutSlide = $layoutSlides->getByType(SlideLayoutType::Title);
    }
    if (java_is_null($layoutSlide)) {
      # La situación en la que una presentación no contiene algunos tipos de diseño.
      # El archivo de presentación solo contiene tipos de diseño en Blanco y Personalizados.
      # Pero las diapositivas de diseño con tipos personalizados tienen nombres de diapositivas diferentes,
      # como "Título", "Título y Contenido", etc. Y es posible usar estos
      # nombres para la selección de diapositivas de diseño.
      # También puedes usar un conjunto de tipos de formas de marcador de posición. Por ejemplo,
      # la diapositiva de título debería tener solo el tipo de marcador de posición de título, etc.
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
    # Agrega una diapositiva vacía con el diseño añadido
    $pres->getSlides()->insertEmptySlide(0, $layoutSlide);
    # Guarda la presentación en el disco
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Eliminar Diapositiva de Diseño No Utilizada**

Aspose.Slides proporciona el método [removeUnusedLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) de la clase [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/) para permitirte eliminar diapositivas de diseño no deseadas y no utilizadas. Este código PHP te muestra cómo eliminar una diapositiva de diseño de una presentación de PowerPoint:

```php
  $pres = new Presentation("pres.pptx");
  try {
    Compress->removeUnusedLayoutSlides($pres);
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Establecer Tamaño y Tipo para el Diseño de Diapositiva**

Para permitirte establecer el tamaño y tipo para una diapositiva de diseño específica, Aspose.Slides proporciona las propiedades [getType()](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/#getType--) y [getSize()](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/#getSize--) (de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)). Este Java demuestra la operación:

```php
  # Instancia un objeto Presentation que representa el archivo de presentación
  $presentation = new Presentation("demo.pptx");
  try {
    $auxPresentation = new Presentation();
    try {
      # Establece el tamaño de la diapositiva para la presentación generada al de la fuente
      $auxPresentation->getSlideSize()->setSize(540, 720, SlideSizeScaleType::EnsureFit);
      # getType());
      $auxPresentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::Maximize);
      # Clona la diapositiva requerida
      $auxPresentation->getSlides()->addClone($presentation->getSlides()->get_Item(0));
      $auxPresentation->getSlides()->removeAt(0);
      # Guarda la presentación en el disco
      $auxPresentation->save("size.pptx", SaveFormat::Pptx);
    } finally {
      $auxPresentation->dispose();
    }
  } finally {
    $presentation->dispose();
  }
```

## **Establecer Visibilidad del Pie de Página dentro de la Diapositiva**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Obtén la referencia de una diapositiva a través de su índice.
1. Establece el marcador de posición del pie de página de la diapositiva como visible.
1. Establece el marcador de posición de fecha y hora como visible.
1. Guarda la presentación.

Este código PHP te muestra cómo establecer la visibilidad para un pie de página de diapositiva (y realizar tareas relacionadas):

```php
  $presentation = new Presentation("presentation.ppt");
  try {
    $headerFooterManager = $presentation->getSlides()->get_Item(0)->getHeaderFooterManager();
    # El método isFooterVisible se usa para especificar que falta un marcador de posición de pie de página
    if (!$headerFooterManager->isFooterVisible()) {
      $headerFooterManager->setFooterVisibility(true);// El método setFooterVisibility se usa para establecer un marcador de posición de pie de página como visible

    }
    # El método isSlideNumberVisible se usa para especificar que falta un marcador de posición de número de diapositiva
    if (!$headerFooterManager->isSlideNumberVisible()) {
      $headerFooterManager->setSlideNumberVisibility(true);// El método setSlideNumberVisibility se usa para establecer un marcador de posición de número de diapositiva como visible

    }
    # El método isDateTimeVisible se usa para especificar que falta un marcador de posición de fecha y hora de la diapositiva
    if (!$headerFooterManager->isDateTimeVisible()) {
      $headerFooterManager->setDateTimeVisibility(true);// El método SetFooterVisibility se usa para establecer un marcador de posición de fecha y hora de la diapositiva como visible

    }
    $headerFooterManager->setFooterText("Texto del pie de página");// El método SetFooterText se usa para establecer un texto para un marcador de posición de pie de página.

    $headerFooterManager->setDateTimeText("Texto de fecha y hora");// El método SetDateTimeText se usa para establecer un texto para un marcador de posición de fecha y hora.

  } finally {
    $presentation->dispose();
  }
```

## **Establecer Visibilidad del Pie de Página Secundario dentro de la Diapositiva**

1. Crea una instancia de la [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) clase.
1. Obtén una referencia para la diapositiva maestra a través de su índice.
1. Establece la diapositiva maestra y todos los marcadores de posición de pie de página secundarios como visibles.
1. Establece un texto para la diapositiva maestra y todos los marcadores de posición de pie de página secundarios.
1. Establece un texto para la diapositiva maestra y todos los marcadores de posición de fecha y hora secundarios.
1. Guarda la presentación.

Este código PHP demuestra la operación:

```php
  $presentation = new Presentation("presentation.ppt");
  try {
    $headerFooterManager = $presentation->getMasters()->get_Item(0)->getHeaderFooterManager();
    $headerFooterManager->setFooterAndChildFootersVisibility(true);// El método setFooterAndChildFootersVisibility se usa para establecer la diapositiva maestra y todos los marcadores de posición de pie de página secundarios como visibles

    $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);// El método setSlideNumberAndChildSlideNumbersVisibility se usa para establecer la diapositiva maestra y todos los marcadores de posición de número de página secundarios como visibles

    $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);// El método setDateTimeAndChildDateTimesVisibility se usa para establecer una diapositiva maestra y todos los marcadores de posición de fecha y hora secundarios como visibles

    $headerFooterManager->setFooterAndChildFootersText("Texto del pie de página");// El método setFooterAndChildFootersText se usa para establecer textos para la diapositiva maestra y todos los marcadores de posición de pie de página secundarios

    $headerFooterManager->setDateTimeAndChildDateTimesText("Texto de fecha y hora");// El método setDateTimeAndChildDateTimesText se usa para establecer texto para la diapositiva maestra y todos los marcadores de posición de fecha y hora secundarios

  } finally {
    $presentation->dispose();
  }
```

## **Establecer Tamaño de Diapositiva con Respecto al Escalado de Contenido**

1. Crea una instancia de la [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) clase y carga la presentación que contiene la diapositiva cuyo tamaño deseas establecer.
1. Crea otra instancia de la [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) clase para generar una nueva presentación.
1. Obtén la referencia de la diapositiva (de la primera presentación) a través de su índice.
1. Establece el marcador de posición del pie de página de la diapositiva como visible.
1. Establece el marcador de posición de fecha y hora como visible.
1. Guarda la presentación.

Este código PHP demuestra la operación:

```php
  # Instancia un objeto Presentation que representa un archivo de presentación
  $presentation = new Presentation("demo.pptx");
  try {
    # Establece el tamaño de la diapositiva para las presentaciones generadas al de la fuente
    $presentation->getSlideSize()->setSize(540, 720, SlideSizeScaleType::EnsureFit);// El método SetSize se usa para establecer el tamaño de la diapositiva con escalado de contenido para asegurar el ajuste

    $presentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::Maximize);// El método SetSize se usa para establecer el tamaño de la diapositiva con el tamaño máximo del contenido

    # Guarda la presentación en el disco
    $presentation->save("Set_Size&Type_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Establecer Tamaño de Página al Generar PDF**

Ciertas presentaciones (como carteles) a menudo se convierten en documentos PDF. Si deseas convertir tu PowerPoint a PDF para acceder a las mejores opciones de impresión y accesibilidad, quieres establecer tus diapositivas en tamaños que se adapten a documentos PDF (A4, por ejemplo).

Aspose.Slides proporciona la clase [SlideSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/) para permitirte especificar tus configuraciones preferidas para las diapositivas. Este código PHP te muestra cómo usar la propiedad [getType()](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/#getType--) (de la clase `SlideSize`) para establecer un tamaño de papel específico para las diapositivas en una presentación:

```php
  # Instancia un objeto Presentation que representa un archivo de presentación
  $presentation = new Presentation();
  try {
    # Establece la propiedad SlideSize.Type
    $presentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::EnsureFit);
    # Establece diferentes propiedades para las opciones de PDF
    $opts = new PdfOptions();
    $opts->setSufficientResolution(600);
    # Guarda la presentación en el disco
    $presentation->save("SetPDFPageSize_out.pdf", SaveFormat::Pdf, $opts);
  } finally {
    $presentation->dispose();
  }
```