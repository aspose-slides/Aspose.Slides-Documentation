---
title: Crear un visor de presentaciones en PHP
linktitle: Visor de presentaciones
type: docs
weight: 50
url: /es/php-java/presentation-viewer/
keywords:
- ver presentación
- visor de presentaciones
- crear visor de presentaciones
- ver PPT
- ver PPTX
- ver ODP
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Crear un visor de presentaciones personalizado usando Aspose.Slides for PHP a través de Java. Mostrar fácilmente archivos PowerPoint y OpenDocument sin Microsoft PowerPoint."
---

Aspose.Slides para PHP a través de Java se utiliza para crear archivos de presentación con diapositivas. Estas diapositivas pueden verse abriendo las presentaciones en Microsoft PowerPoint, por ejemplo. Sin embargo, a veces los desarrolladores pueden necesitar ver las diapositivas como imágenes en su visor de imágenes preferido o crear su propio visor de presentaciones. En esos casos, Aspose.Slides permite exportar una diapositiva individual como imagen. Este artículo describe cómo hacerlo.

## **Generar una imagen SVG a partir de una diapositiva**

Para generar una imagen SVG a partir de una diapositiva de presentación con Aspose.Slides, siga los pasos a continuación:

1. Cree una instancia de la clase[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Obtenga la referencia a la diapositiva mediante su índice.
1. Abra un flujo de archivo.
1. Guarde la diapositiva como imagen SVG en el flujo de archivo.
```php
$slideIndex = 0;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$svgStream = new Java("java.io.FileOutputStream", "output.svg");
$slide->writeAsSvg($svgStream);
$svgStream->close();

$presentation->dispose();
```


## **Generar un SVG con un ID de forma personalizado**

Aspose.Slides puede usarse para generar un[SVG](https://docs.fileformat.com/page-description-language/svg/) a partir de una diapositiva con un ID de forma personalizado. Para ello, utilice el método`setId` de[SvgShape](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/).`CustomSvgShapeFormattingController` puede usarse para establecer el ID de la forma.
```php
$slideIndex = 0;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$shapeFormattingController = java_closure(new CustomSvgShapeFormattingController(0), null, java("com.aspose.slides.ISvgShapeFormattingController"));

$svgOptions = new SVGOptions();
$svgOptions->setShapeFormattingController($shapeFormattingController);

$svgStream = new Java("java.io.FileOutputStream", "output.svg");
$slide->writeAsSvg($svgStream, $svgOptions);
$svgStream->close();

$presentation->dispose();
```

```php
class CustomSvgShapeFormattingController {
    private $m_shapeIndex;

    public function __construct($shapeStartIndex) {
        $this->m_shapeIndex = $shapeStartIndex;
    }

    public function formatShape($svgShape, $shape) {
        $svgShape->setId(sprintf("shape-%d", $m_shapeIndex++));
    }
}
```


## **Crear una imagen en miniatura de una diapositiva**

Aspose.Slides le ayuda a generar imágenes en miniatura de diapositivas. Para generar una miniatura de una diapositiva usando Aspose.Slides, siga los pasos a continuación:

1. Cree una instancia de la clase[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Obtenga la referencia a la diapositiva mediante su índice.
1. Obtenga la imagen en miniatura de la diapositiva referenciada a una escala definida.
1. Guarde la imagen en miniatura en cualquier formato de imagen deseado.
```php
$slideIndex = 0;
$scaleX = 1.0;
$scaleY = $scaleX;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($scaleX, $scaleY);
$image->save("output.jpg", ImageFormat::Jpeg);
$image->dispose();

$presentation->dispose();
```


## **Crear una miniatura de diapositiva con dimensiones definidas por el usuario**

Para crear una imagen en miniatura de diapositiva con dimensiones definidas por el usuario, siga los pasos a continuación:

1. Cree una instancia de la clase[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Obtenga la referencia a la diapositiva mediante su índice.
1. Obtenga la imagen en miniatura de la diapositiva referenciada con las dimensiones definidas.
1. Guarde la imagen en miniatura en cualquier formato de imagen deseado.
```php
$slideIndex = 0;
$slideSize = new Java("java.awt.Dimension", 1200, 800);

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($slideSize);
$image->save("output.jpg", ImageFormat::Jpeg);
$image->dispose();

$presentation->dispose();
```


## **Crear una miniatura de diapositiva con notas del orador**

Para generar la miniatura de una diapositiva con notas del orador usando Aspose.Slides, siga los pasos a continuación:

1. Cree una instancia de la clase[RenderingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/renderingoptions/).
1. Utilice el método`RenderingOptions.setSlidesLayoutOptions` para establecer la posición de las notas del orador.
1. Cree una instancia de la clase[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Obtenga la referencia a la diapositiva mediante su índice.
1. Obtenga la imagen en miniatura de la diapositiva referenciada con las opciones de renderizado.
1. Guarde la imagen en miniatura en cualquier formato de imagen deseado.
```php
$slideIndex = 0;

$layoutingOptions = new NotesCommentsLayoutingOptions();
$layoutingOptions->setNotesPosition(NotesPositions::BottomTruncated);

$renderingOptions = new RenderingOptions();
$renderingOptions->setSlidesLayoutOptions($layoutingOptions);

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($renderingOptions);
$image->save("output.png", ImageFormat::Png);
$image->dispose();

$presentation->dispose();
```


## **Ejemplo en vivo**

Puede probar la aplicación gratuita [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) para ver lo que puede implementar con la API de Aspose.Slides:

![Online PowerPoint Viewer](online-PowerPoint-viewer.png)

## **Preguntas frecuentes**

**¿Puedo incrustar un visor de presentaciones en una aplicación web?**

Sí. Puede usar Aspose.Slides del lado del servidor para renderizar diapositivas como imágenes o HTML y mostrarlas en el navegador. Las funciones de navegación y zoom pueden implementarse con JavaScript para una experiencia interactiva.

**¿Cuál es la mejor manera de mostrar diapositivas dentro de un visor personalizado?**

El enfoque recomendado es renderizar cada diapositiva como una imagen (p. ej., PNG o SVG) o convertirla a HTML usando Aspose.Slides, y luego mostrar el resultado dentro de un control de imagen (para escritorio) o un contenedor HTML (para web).

**¿Cómo manejo presentaciones grandes con muchas diapositivas?**

Para presentaciones extensas, considere la carga diferida o el renderizado bajo demanda de diapositivas. Esto significa generar el contenido de una diapositiva solo cuando el usuario navega a ella, reduciendo el uso de memoria y el tiempo de carga.