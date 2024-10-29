---
title: Visor de Presentaciones
type: docs
weight: 50
url: /es/php-java/presentation-viewer/
keywords: "Visor de PPT de PowerPoint"
description: "Visor de PPT de PowerPoint"
---

{{% alert color="primary" %}} 

Aspose.Slides para PHP a través de Java se utiliza para crear archivos de presentación, completos con diapositivas. Estas diapositivas se pueden ver abriendo presentaciones con Microsoft PowerPoint. Pero a veces, los desarrolladores también pueden necesitar ver diapositivas como imágenes en su visor de imágenes favorito o crear su propio visor de presentaciones. En tales casos, Aspose.Slides para PHP a través de Java le permite exportar una diapositiva individual a una imagen. Este artículo describe cómo hacerlo.

{{% /alert %}} 

## **Ejemplo en Vivo**
Puede probar la aplicación gratuita [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) para ver lo que puede implementar con la API de Aspose.Slides:

[](https://products.aspose.app/slides/viewer/)

[![todo:image_alt_text](slides-viewer.png)](https://products.aspose.app/slides/viewer/)

## **Generar Imagen SVG de Diapositiva**
Para generar una imagen SVG de cualquier diapositiva deseada con Aspose.Slides para PHP a través de Java, siga los pasos a continuación:

- Cree una instancia de la [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) clase.
- Obtenga la referencia de la diapositiva deseada utilizando su ID o índice.
- Obtenga la imagen SVG en un flujo de memoria.
- Guarde el flujo de memoria en un archivo.

```php
  # Instanciar una clase Presentation que representa el archivo de presentación
  $pres = new Presentation("CreateSlidesSVGImage.pptx");
  try {
    # Acceder a la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Crear un objeto de flujo de memoria
    $svgStream = new Java("java.io.FileOutputStream", "Aspose_out.svg");
    # Generar imagen SVG de la diapositiva y guardar en el flujo de memoria
    $sld->writeAsSvg($svgStream);
    $svgStream->close();
  } catch (JavaException $e) {
  } finally {
    $pres->dispose();
  }
```

## **Generar SVG con IDs de Forma Personalizados**
Aspose.Slides para PHP a través de Java se puede utilizar para generar [SVG](https://docs.fileformat.com/page-description-language/svg/) de una diapositiva con ID de forma personalizados. Para ello, use la propiedad ID de [ISvgShape](https://reference.aspose.com/slides/php-java/aspose.slides/ISvgShape), que representa el ID personalizado de las formas en el SVG generado. CustomSvgShapeFormattingController se puede utilizar para establecer el ID de la forma.

```php

  class CustomSvgShapeFormattingController {
    private $m_shapeIndex;

    function __construct() {
      $this->m_shapeIndex = 0;
    }

    function __construct($shapeStartIndex) {
      $this->m_shapeIndex = $shapeStartIndex;
    }

    function formatShape($svgShape, $shape) {
      $svgShape->setId(sprintf("shape-%d", $m_shapeIndex++));
    }
  }

  $pres = new Presentation("pptxFileName.pptx");
  try {
    $stream = new Java("java.io.FileOutputStream", "Aspose_out.svg");
    try {
      $svgOptions = new SVGOptions();
      $shapeFormattingController = java_closure(new CustomSvgShapeFormattingController(), null, java("com.aspose.slides.ISvgShapeFormattingController"));
      $svgOptions->setShapeFormattingController($shapeFormattingController);
      $pres->getSlides()->get_Item(0)->writeAsSvg($stream, $svgOptions);
    } finally {
      if (!java_is_null($stream)) {
        $stream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    $pres->dispose();
  }
```

## **Crear Imagen en Miniatura de Diapositivas**
Aspose.Slides para PHP a través de Java le ayuda a generar imágenes en miniatura de las diapositivas. Para generar la miniatura de cualquier diapositiva deseada utilizando Aspose.Slides para PHP a través de Java:

1. Cree una instancia de la [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) clase.
1. Obtenga la referencia de cualquier diapositiva deseada utilizando su ID o índice.
1. Obtenga la imagen en miniatura de la diapositiva referenciada en una escala especificada.
1. Guarde la imagen en miniatura en cualquier formato de imagen deseado.

```php
  # Instanciar una clase Presentation que representa el archivo de presentación
  $pres = new Presentation("ThumbnailFromSlide.pptx");
  try {
    # Acceder a la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Crear una imagen a escala completa
    $slideImage = $sld->getImage(1.0, 1.0);
    # Guardar la imagen en disco en formato JPEG
    try {
      $slideImage->save("Thumbnail_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    $pres->dispose();
  }
```

## **Crear Miniatura con Dimensiones Definidas por el Usuario**

1. Cree una instancia de la [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) clase.
1. Obtenga la referencia de cualquier diapositiva deseada utilizando su ID o índice.
1. Obtenga la imagen en miniatura de la diapositiva referenciada en una escala especificada.
1. Guarde la imagen en miniatura en cualquier formato de imagen deseado.

```php
  # Instanciar una clase Presentation que representa el archivo de presentación
  $pres = new Presentation("ThumbnailWithUserDefinedDimensions.pptx");
  try {
    # Acceder a la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Dimensión definida por el usuario
    $desiredX = 1200;
    $desiredY = 800;
    # Obtener el valor escalado de X e Y
    $ScaleX = 1.0 / $pres->getSlideSize()->getSize()->getWidth() * $desiredX;
    $ScaleY = 1.0 / $pres->getSlideSize()->getSize()->getHeight() * $desiredY;
    # Crear una imagen a escala completa
    $slideImage = $sld->getImage($ScaleX, $ScaleY);
    # Guardar la imagen en disco en formato JPEG
    try {
      $slideImage->save("Thumbnail_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    $pres->dispose();
  }
```

## **Crear Miniatura de Diapositiva en Vista de Diapositivas de Notas**
Para generar la miniatura de cualquier diapositiva deseada en la Vista de Diapositivas de Notas utilizando Aspose.Slides para PHP a través de Java:

1. Cree una instancia de la [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) clase.
1. Obtenga la referencia de cualquier diapositiva deseada utilizando su ID o índice.
1. Obtenga la imagen en miniatura de la diapositiva referenciada en una escala especificada en la vista de Diapositivas de Notas.
1. Guarde la imagen en miniatura en cualquier formato de imagen deseado.

El fragmento de código a continuación produce una miniatura de la primera diapositiva de una presentación en la Vista de Diapositivas de Notas.

```php
  # Instanciar una clase Presentation que representa el archivo de presentación
  $pres = new Presentation("ThumbnailWithUserDefinedDimensions.pptx");
  try {
    # Acceder a la primera diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Dimensión definida por el usuario
    $desiredX = 1200;
    $desiredY = 800;
    # Obtener el valor escalado de X e Y
    $ScaleX = 1.0 / $pres->getSlideSize()->getSize()->getWidth() * $desiredX;
    $ScaleY = 1.0 / $pres->getSlideSize()->getSize()->getHeight() * $desiredY;
    $opts = new RenderingOptions();
    $opts->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomTruncated);
    # Crear una imagen a escala completa
    $slideImage = $sld->getImage($opts, $ScaleX, $ScaleY);
    # Guardar la imagen en disco en formato JPEG
    try {
      $slideImage->save("Thumbnail_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    $pres->dispose();
  }
```