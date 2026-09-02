---
title: Gestionar efectos de transformación de imagen en presentaciones con PHP
linktitle: Efectos de Transformación de Imagen
type: docs
weight: 11
url: /es/php-java/image-transform-effects/
keywords:
- transformación de imagen
- efecto de imagen
- brillo
- contraste
- escala de grises
- duotono
- tinte
- HSL
- reemplazo de color
- desenfoque
- transparencia
- efecto alfa
- cadena de efectos
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Aplicar, encadenar, inspeccionar, eliminar y verificar efectos de transformación de imagen para fotogramas de imagen con Aspose.Slides para PHP via Java."
---
## **Visión general**

Aspose.Slides representa los ajustes de imagen como una colección ordenada de operaciones de transformación de imagen. Para un fotograma de imagen, comience con el [Picture](https://reference.aspose.com/slides/es/php-java/aspose.slides/picture/) del fotograma y acceda a [Picture::getImageTransform](https://reference.aspose.com/slides/es/php-java/aspose.slides/picture/getimagetransform/). La [ImageTransformOperationCollection](https://reference.aspose.com/slides/es/php-java/aspose.slides/imagetransformoperationcollection/) devuelta le permite añadir, enumerar, inspeccionar, eliminar y limpiar efectos sin reescribir los bytes originales de la imagen.

Este artículo muestra un flujo de trabajo completo para brillo y contraste, transformaciones de color, desenfoque, transparencia, cadenas de efectos ordenadas, valores efectivos, eliminación y verificación de ida y vuelta en PPTX.

## **Comprender la propiedad de los efectos y la reutilización de imágenes**

Un recurso de imagen y la imagen que la muestra son objetos diferentes:

- [PPImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/ppimage/) almacena o hace referencia a los datos de imagen fuente que posee la presentación.
- [Picture](https://reference.aspose.com/slides/es/php-java/aspose.slides/picture/) pertenece a un relleno de imagen y se refiere a un recurso de imagen mientras almacena la colección de transformaciones de imagen.
- [PictureFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/pictureframe/) es la forma de diapositiva que posee el relleno de imagen correspondiente, la geometría, la configuración de recorte y otros formatos a nivel de fotograma.

Por lo tanto, las operaciones de transformación de imagen no modifican los bytes en [PPImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/ppimage/). Cuando el mismo `PPImage` se pasa a [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/shapecollection/addpictureframe/) más de una vez, cada nuevo fotograma de imagen recibe su propio `Picture` y su propia colección de transformaciones. Aplicar escala de grises a un fotograma no hace que los demás fotogramas sean en escala de grises, aunque todos reutilicen el mismo recurso de imagen incrustado.

El mismo modelo `Picture::getImageTransform` también es utilizado por otros rellenos de imagen, como una forma o el fondo de diapositiva. Los ejemplos a continuación se centran en fotogramas de imagen.

## **Usar rangos y unidades de parámetros válidos**

Los métodos demostrados utilizan los siguientes rangos semánticos y unidades. Mantenga los valores dentro de estos rangos aunque una versión concreta de la biblioteca no rechace inmediatamente cada valor fuera de rango; el formato de presentación de destino puede normalizar, omitir o rechazar datos no válidos durante el guardado o cuando PowerPoint abre el archivo.

| Operación | Parámetros | Rango y unidad válidos |
|---|---|---|
| [addLuminanceEffect](https://reference.aspose.com/slides/es/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) | `brightness`, `contrast` | `-100` a `100`, por ciento; `0` deja el componente sin cambios. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/es/php-java/aspose.slides/imagetransformoperationcollection/addgrayscaleeffect/) | Ninguno | No hay parámetros numéricos. Alfa no se modifica. |
| [addDuotoneEffect](https://reference.aspose.com/slides/es/php-java/aspose.slides/imagetransformoperationcollection/addduotoneeffect/) | `color1`, `color2` | Dos colores para píxeles oscuros y claros. Los canales RGB y alfa en `java.awt.Color` usan valores de `0` a `255`. |
| [addTintEffect](https://reference.aspose.com/slides/es/php-java/aspose.slides/imagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | `hue` es de `0` inclusive a `360` exclusivo, en grados; `amount` es de `-100` a `100`, por ciento. |
| [addHSLEffect](https://reference.aspose.com/slides/es/php-java/aspose.slides/imagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | `hue` es de `0` inclusive a `360` exclusivo, en grados; `saturation` y `luminance` son de `-100` a `100`, por ciento. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/es/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) | `color` | El color de sustitución usa valores de canal de `0` a `255`. Los valores alfa existentes no se modifican. |
| [addBlurEffect](https://reference.aspose.com/slides/es/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) | `radius`, `grow` | `radius` es no negativo y se mide en puntos; `grow` es un Boolean que controla si el contenido desenfocado puede extenderse fuera de los límites originales. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/es/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Porcentaje no negativo. Use `0` a `100` para un escalado de opacidad ordinario: `0` es totalmente transparente y `100` conserva el alfa existente. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/es/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` a `100`, por ciento de opacidad. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/es/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` a `100`, por ciento de umbral alfa. Los valores por debajo se vuelven transparentes; los valores en o por encima se vuelven opacos. |

Para la modulació​n alfa fija, la transparencia y la opacidad son complementarias. Por ejemplo, un 35 % de transparencia corresponde a una cantidad de modulación alfa del 65 %.

## **Aplicar brillo y contraste**

[ImageTransformOperationCollection::addLuminanceEffect](https://reference.aspose.com/slides/es/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) devuelve una operación [Luminance](https://reference.aspose.com/slides/es/php-java/aspose.slides/luminance/). Sus ajustes escalares se suministran cuando se crea la operación. [Luminance::getEffective](https://reference.aspose.com/slides/es/php-java/aspose.slides/luminance/geteffective/) devuelve valores calculados de solo lectura que pueden inspeccionarse o registrarse.

El siguiente ejemplo aumenta el brillo en un 15 % y el contraste en un 20 %, luego muestra una vista previa sin modificar la imagen incrustada:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 400, 260, $image);
    $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
    $luminance = $imageTransform->addLuminanceEffect(15, 20);

    $effectiveValues = $luminance->getEffective();
    echo "Brightness: " . java_values($effectiveValues->getBrightness()) . "%" . PHP_EOL;
    echo "Contrast: " . java_values($effectiveValues->getContrast()) . "%" . PHP_EOL;

    $preview = $slide->getImage();
    try {
        $preview->save("brightness-contrast-preview.png", ImageFormat::Png);
    } finally {
        if (!java_is_null($preview)) {
            $preview->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

`Luminance` es el efecto estándar de brillo y contraste de DrawingML. Cuando esos ajustes deben permanecer editables después de una ida y vuelta en PPTX, vuelva a abrir la presentación guardada y verifique tanto el tipo de operación como sus valores efectivos.

## **Aplicar transformaciones de color**

Los efectos de color pueden aplicarse de forma independiente a diferentes fotogramas de imagen que reutilizan un mismo recurso de imagen. El siguiente ejemplo crea cinco fotogramas y aplica escala de grises, duotono, tinte, ajuste HSL y sustitución de color.

[Duotone](https://reference.aspose.com/slides/es/php-java/aspose.slides/duotone/) contiene dos parámetros de color editables de forma independiente: `color1` asigna los píxeles oscuros, mientras que `color2` asigna los píxeles claros. Esto lo convierte en un ejemplo útil de un efecto cuyas configuraciones son más complejas que un único valor escalar.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $grayFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 180, 120, $image);
    $grayFrame->getPictureFormat()->getPicture()->getImageTransform()->addGrayScaleEffect();

    $duotoneFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 220, 20, 180, 120, $image);
    $duotone = $duotoneFrame->getPictureFormat()->getPicture()->getImageTransform()->addDuotoneEffect();
    $duotone->getColor1()->setColor(new Java("java.awt.Color", 0, 0, 128));
    $duotone->getColor2()->setColor(new Java("java.awt.Color", 255, 215, 0));

    $tintFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 420, 20, 180, 120, $image);
    $tintFrame->getPictureFormat()->getPicture()->getImageTransform()->addTintEffect(210, 35);

    $hslFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 120, 170, 180, 120, $image);
    $hslFrame->getPictureFormat()->getPicture()->getImageTransform()->addHSLEffect(30, 20, -10);

    $replacementFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 320, 170, 180, 120, $image);
    $colorReplacement = $replacementFrame->getPictureFormat()->getPicture()->getImageTransform()->addColorReplaceEffect();
    $colorReplacement->getColor()->setColor(new Java("java.awt.Color", 100, 149, 237));

    $presentation->save("color-transformations.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/es/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) sustituye el color de cada píxel por un color fijo mientras preserva el alfa. Es diferente de [addColorChangeEffect](https://reference.aspose.com/slides/es/php-java/aspose.slides/imagetransformoperationcollection/addcolorchangeeffect/), que asigna un color fuente a otro y expone ambos formatos de color origen y destino.

## **Añadir desenfoque, transparencia y efectos alfa**

[addBlurEffect](https://reference.aspose.com/slides/es/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) afecta a todos los canales de color, incluido el alfa. Establezca `grow` en `true` cuando el borde desenfocado pueda extenderse más allá de los límites originales de la imagen.

Para una transparencia uniforme, use [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/es/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/). Multiplica cada valor alfa existente, por lo que los píxeles parcialmente transparentes permanecen proporcionalmente diferentes. [addAlphaReplaceEffect](https://reference.aspose.com/slides/es/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) asigna, en cambio, un único valor alfa a todos los píxeles. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/es/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) convierte el alfa en dos niveles basados en un umbral.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $blurredFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 140, $image);
    $blur = $blurredFrame->getPictureFormat()->getPicture()->getImageTransform()->addBlurEffect(4.5, true);
    $blur->setRadius(5);

    $transparentFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 240, 20, 200, 140, $image);
    $alphaModulate = $transparentFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaModulateFixedEffect(65);
    $alphaModulate->setAmount(60);

    $uniformAlphaFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 180, 200, 140, $image);
    $uniformAlphaFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaReplaceEffect(55);

    $binaryAlphaFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 240, 180, 200, 140, $image);
    $alphaBiLevel = $binaryAlphaFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaBiLevelEffect(50);
    $alphaBiLevel->setThreshold(45);
    $binaryAlphaFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaInverseEffect();

    $presentation->save("blur-and-alpha-effects.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Otras operaciones alfa sin parámetros incluyen [addAlphaCeilingEffect](https://reference.aspose.com/slides/es/php-java/aspose.slides/imagetransformoperationcollection/addalphaceilingeffect/), que hace que todo alfa distinto de cero sea totalmente opaco; [addAlphaFloorEffect](https://reference.aspose.com/slides/es/php-java/aspose.slides/imagetransformoperationcollection/addalphaflooreffect/), que hace que todo alfa por debajo del 100 % sea totalmente transparente; y [addAlphaInverseEffect](https://reference.aspose.com/slides/es/php-java/aspose.slides/imagetransformoperationcollection/addalphainverseeffect/), que cambia el alfa a `100% - alpha`.

## **Construir una cadena de efectos ordenada**

Cada método `add...Effect` añade una nueva operación al final de la colección. El renderizador utiliza la colección como una tubería ordenada: la salida de la operación 0 se convierte en la entrada de la operación 1, y así sucesivamente. Por consiguiente, las mismas operaciones en un orden diferente pueden producir una imagen distinta.

Por ejemplo, aplicar escala de grises y luego tinte elimina primero la información cromática y después recolorea el resultado de luminancia. Aplicar tinte y luego escala de grises elimina el tinte nuevamente. De forma similar, el reemplazo alfa puede sobrescribir los valores alfa calculados por operaciones anteriores, mientras que la modulación alfa conserva sus diferencias relativas.

El siguiente ejemplo construye una cadena de cuatro operaciones, la guarda como PPTX, vuelve a abrir la presentación, comprueba tanto los tipos de operación como su orden, y renderiza el resultado reabierto:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 400, 260, $image);
    $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
    $imageTransform->addGrayScaleEffect();
    $imageTransform->addTintEffect(220, 25);
    $imageTransform->addBlurEffect(2.5, false);
    $imageTransform->addAlphaModulateFixedEffect(80);

    $presentation->save("image-transform-chain.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation("image-transform-chain.pptx");
try {
    $reopenedShape = $reopenedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($reopenedShape, new JavaClass("com.aspose.slides.PictureFrame"))) {
        $reopenedTransform = $reopenedShape->getPictureFormat()->getPicture()->getImageTransform();
        $orderIsPreserved = java_values($reopenedTransform->size()) === 4 && 
            java_instanceof($reopenedTransform->get_Item(0), new JavaClass("com.aspose.slides.GrayScale")) && 
            java_instanceof($reopenedTransform->get_Item(1), new JavaClass("com.aspose.slides.Tint")) && 
            java_instanceof($reopenedTransform->get_Item(2), new JavaClass("com.aspose.slides.Blur")) && 
            java_instanceof($reopenedTransform->get_Item(3), new JavaClass("com.aspose.slides.AlphaModulateFixed"));
        echo $orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.";

        $renderedSlide = $reopenedPresentation->getSlides()->get_Item(0)->getImage();
        try {
            $renderedSlide->save("reopened-effect-chain.png", ImageFormat::Png);
        } finally {
            if (!java_is_null($renderedSlide)) {
                $renderedSlide->dispose();
            }
        }
    } else {
        echo "The reopened shape is not a picture frame.";
    }
} finally {
    $reopenedPresentation->dispose();
}
```

La colección no impone una matriz de compatibilidad que restrinja las operaciones de color, alfa y desenfoque a cadenas separadas. Pueden combinarse, pero las combinaciones no siempre son útiles. Un reemplazo de color fijo elimina la variación RGB producida por efectos de color anteriores; la escala de grises después del duotono elimina los dos colores seleccionados; y las operaciones alfa de techo, suelo, reemplazo o bi‑nivel pueden descartar el detalle alfa creado antes. Construya la cadena según la secuencia de procesamiento de píxeles deseada en lugar de tratar sus elementos como banderas de formato sin orden.

## **Inspeccionar valores editables y efectivos**

Una operación editable es el objeto almacenado en `Picture::getImageTransform`. Según el efecto, puede exponer miembros grabables directamente. Por ejemplo, [Blur](https://reference.aspose.com/slides/es/php-java/aspose.slides/blur/) expone los valores grabables `radius` y `grow`, [AlphaModulateFixed](https://reference.aspose.com/slides/es/php-java/aspose.slides/alphamodulatefixed/) expone un `amount` grabable, y [AlphaBiLevel](https://reference.aspose.com/slides/es/php-java/aspose.slides/alphabilevel/) expone un `threshold` grabable. Los efectos de color como [Duotone](https://reference.aspose.com/slides/es/php-java/aspose.slides/duotone/) exponen objetos mutables [ColorFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/colorformat/).

Algunas operaciones, incluidas [Luminance](https://reference.aspose.com/slides/es/php-java/aspose.slides/luminance/), [HSL](https://reference.aspose.com/slides/es/php-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/es/php-java/aspose.slides/tint/) y [AlphaReplace](https://reference.aspose.com/slides/es/php-java/aspose.slides/alphareplace/), no exponen sus escalares de creación como propiedades grabables. Para cambiar esos ajustes, elimine la operación y añada una de reemplazo en la posición requerida.

Los datos efectivos devueltos por `getEffective()` se calculan y son de solo lectura. Son útiles para resolver colores dependientes del tema y leer los valores normalizados que el renderizador utiliza, pero no constituyen otra superficie de edición. El siguiente ejemplo enumera la cadena e inspecciona los valores efectivos donde la API correspondiente los proporciona:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("image-transform-chain.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
        $effectCount = java_values($imageTransform->size());

        for ($index = 0; $index < $effectCount; $index++) {
            $operation = $imageTransform->get_Item($index);
            echo $index . ": " . java_values($operation->getClass()->getSimpleName()) . PHP_EOL;

            if (java_instanceof($operation, new JavaClass("com.aspose.slides.Luminance"))) {
                $data = $operation->getEffective();
                echo "  Brightness: " . java_values($data->getBrightness()) . PHP_EOL;
                echo "  Contrast: " . java_values($data->getContrast()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.Duotone"))) {
                $data = $operation->getEffective();
                echo "  Dark color: " . java_values($data->getColor1()->toString()) . PHP_EOL;
                echo "  Light color: " . java_values($data->getColor2()->toString()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.ColorReplace"))) {
                $data = $operation->getEffective();
                echo "  Replacement color: " . java_values($data->getColor()->toString()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.HSL"))) {
                $data = $operation->getEffective();
                echo "  HSL: " . java_values($data->getHue()) . ", " . java_values($data->getSaturation()) . ", " . java_values($data->getLuminance()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.Tint"))) {
                $data = $operation->getEffective();
                echo "  Tint: " . java_values($data->getHue()) . ", " . java_values($data->getAmount()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.Blur"))) {
                $data = $operation->getEffective();
                echo "  Blur radius: " . java_values($data->getRadius()) . " pt" . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
                $data = $operation->getEffective();
                echo "  Alpha amount: " . java_values($data->getAmount()) . "%" . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaReplace"))) {
                $data = $operation->getEffective();
                echo "  Replacement alpha: " . java_values($data->getAlpha()) . "%" . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaBiLevel"))) {
                $data = $operation->getEffective();
                echo "  Alpha threshold: " . java_values($data->getThreshold()) . "%" . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Los efectos sin parámetros, como escala de grises, techo alfa e inverso alfa, todavía poseen un objeto de datos efectivos, pero no hay ajustes escalares que imprimir. Su presencia y posición en la colección son la información importante.

## **Eliminar o limpiar transformaciones de imagen**

Utilice [ImageTransformOperationCollection::removeAt](https://reference.aspose.com/slides/es/php-java/aspose.slides/imagetransformoperationcollection/removeat/) para eliminar una operación por índice. Como los índices cambian tras la eliminación, busque el objetivo primero y elimínelo después de la enumeración. Utilice [ImageTransformOperationCollection::clear](https://reference.aspose.com/slides/es/php-java/aspose.slides/imagetransformoperationcollection/clear/) para eliminar toda la cadena.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("image-transform-chain.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
        $effectCount = java_values($imageTransform->size());
        $blurIndex = -1;

        for ($index = 0; $index < $effectCount; $index++) {
            if (java_instanceof($imageTransform->get_Item($index), new JavaClass("com.aspose.slides.Blur"))) {
                $blurIndex = $index;
                break;
            }
        }

        if ($blurIndex >= 0) {
            $imageTransform->removeAt($blurIndex);
            echo "The blur operation was removed." . PHP_EOL;
        }

        $imageTransform->clear();
        echo "Remaining operations: " . java_values($imageTransform->size()) . PHP_EOL;
        $presentation->save("image-transforms-cleared.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Eliminar o limpiar transformaciones cambia solo el formato de la imagen. No elimina, recomprime ni altera de otro modo el recurso reutilizado [PPImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/ppimage/).

## **Considerar formatos de presentación y destinos de exportación**

Las transformaciones de imagen se originan en DrawingML, por lo que PPTX es el formato editable preferido para cadenas de efectos. Incluso con PPTX, no todas las operaciones tienen la misma portabilidad:

- Las operaciones estándar de DrawingML como luminancia, escala de grises, duotono, tinte, HSL, desenfoque y operaciones alfa comunes tienen la mayor probabilidad de sobrevivir a una ida y vuelta en PPTX. Siempre vuelva a abrir el archivo generado e inspeccione la colección cuando la preservación sea un requisito.
- El formato binario PPT precede al modelo completo de efectos DrawingML. Guardar en PPT puede omitir operaciones no compatibles, reducir una cadena a un subconjunto soportado o aproximar la apariencia. No use PPT como formato de verificación para una cadena editable compleja.
- Renderizar a PNG, JPEG, TIFF, PDF, SVG, HTML u otro salida visual aplica la cadena soportada a la apariencia renderizada. esas salidas no contienen una `ImageTransformOperationCollection` editable; los formatos raster aplanan el resultado en píxeles, y las exportaciones de documento o vector almacenan su propia representación de renderizado.
- Los efectos no hacen que una imagen enlazada sea autónoma. Renderizar una imagen enlazada sigue dependiendo de que el recurso enlazado esté disponible cuando se cargue la presentación.

Distintos consumidores de presentaciones pueden renderizar casos límite de manera diferente, especialmente cuando se combinan varias operaciones alfa o de cuantización de color. Para una salida crítica, pruebe tanto la ida y vuelta editable como el formato de exportación final con la misma versión de Aspose.Slides utilizada en producción.

## **Preguntas frecuentes**

**¿Los efectos de transformación de imagen modifican los datos de la imagen incrustada?**

No. Las operaciones pertenecen al `Picture` usado por el relleno de imagen. Los bytes subyacentes de `PPImage` permanecen sin cambios.

**¿Dos fotogramas de imagen que reutilizan la misma imagen comparten sus efectos?**

No. Reutilizar un `PPImage` evita datos de imagen duplicados, pero cada fotograma de imagen normalmente tiene su propio `Picture` y su propia colección de transformaciones de imagen.

**¿Se pueden combinar efectos de color, desenfoque y alfa?**

Sí. La colección los acepta en una única cadena ordenada. Considere lo que cada operación hace a la salida de la anterior, ya que las operaciones de reemplazo y umbral pueden descartar detalle de color o alfa anterior.

**¿Por qué los valores efectivos son de solo lectura?**

Los datos efectivos representan los valores calculados usados para el renderizado, incluidos los colores resueltos. Edite la operación almacenada en la colección de transformaciones donde existan miembros grabables; de lo contrario, elimínela y añada una de reemplazo con nuevos parámetros de creación.

**¿Qué formato debo usar para conservar una cadena de transformaciones?**

Use PPTX y verifique el archivo volviéndolo a abrir. El PPT legado no puede representar el modelo completo de efectos DrawingML, y los formatos de exportación renderizados preservan la apariencia más que las operaciones de transformación editables.