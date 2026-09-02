---
title: Gestionar efectos de transformación de imagen en presentaciones con JavaScript
linktitle: Efectos de Transformación de Imagen
type: docs
weight: 11
url: /es/nodejs-java/image-transform-effects/
keywords:
- transformación de imagen
- efecto de imagen
- brillo
- contraste
- escala de grises
- duotono
- tono
- HSL
- reemplazo de color
- desenfoque
- transparencia
- efecto alfa
- cadena de efectos
- PowerPoint
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Aplicar, encadenar, inspeccionar, eliminar y verificar los efectos de transformación de imagen para fotogramas de imagen con Aspose.Slides para Node.js mediante Java."
---
## **Descripción general**

Aspose.Slides representa los ajustes de imagen como una colección ordenada de operaciones de transformación de imagen. Para un fotograma de imagen, comience con el [Picture](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/picture/) del fotograma y acceda a [Picture.getImageTransform](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/picture/). La [ImageTransformOperationCollection](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/imagetransformoperationcollection/) devuelta le permite anexar, enumerar, inspeccionar, eliminar y borrar efectos sin reescribir los bytes de la imagen original.

Este artículo muestra un flujo de trabajo completo para brillo y contraste, transformaciones de color, desenfoque, transparencia, cadenas de efectos ordenadas, valores efectivos, eliminación y verificación de ida y vuelta de PPTX.

## **Comprender la propiedad de los efectos y la reutilización de imágenes**

Un recurso de imagen y la imagen que la muestra son objetos diferentes:

- [PPImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/ppimage/) almacena o referencia los datos de imagen origen que pertenece a la presentación.
- [Picture](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/picture/) pertenece a un relleno de imagen y se refiere a un recurso de imagen mientras almacena la colección de transformaciones de imagen.
- [PictureFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/pictureframe/) es la forma de diapositiva que posee el relleno de imagen correspondiente, la geometría, la configuración de recorte y demás formato a nivel de fotograma.

Por lo tanto, las operaciones de transformación de imagen no modifican los bytes en [PPImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/ppimage/). Cuando el mismo [PPImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/ppimage/) se pasa a [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shapecollection/) más de una vez, cada nuevo fotograma de imagen recibe su propio [Picture](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/picture/) y su propia colección de transformaciones. Aplicar escala de grises a un fotograma no hace que los demás fotogramas sean en escala de grises, aunque todos reutilicen el mismo recurso de imagen incrustado.

El mismo modelo [Picture.getImageTransform](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/picture/) también se utiliza en otros rellenos de imagen, como el fondo de una forma o de una diapositiva. Los ejemplos siguientes se centran en fotogramas de imagen.

## **Utilizar rangos y unidades de parámetros válidos**

Los métodos demostrados usan los siguientes rangos semánticos y unidades. Mantenga los valores dentro de estos rangos aunque una versión concreta de la biblioteca no rechace inmediatamente cada valor fuera de rango; el formato de presentación de destino puede normalizar, omitir o rechazar datos inválidos al guardar o cuando PowerPoint abra el archivo.

| Operación | Parámetros | Rango válido y unidad |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `brightness`, `contrast` | `-100` a `100`, por ciento; `0` deja el componente sin cambios. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/imagetransformoperationcollection/) | Ninguno | No hay parámetros numéricos. Alfa permanece sin cambios. |
| [addDuotoneEffect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color1`, `color2` | Dos colores para píxeles oscuros y claros. Los canales RGB y alfa en `java.awt.Color` usan valores de `0` a `255`. |
| [addTintEffect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `amount` | El tono es de `0` inclusive a `360` exclusivo, en grados; la cantidad es de `-100` a `100`, por ciento. |
| [addHSLEffect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `saturation`, `luminance` | El tono es de `0` inclusive a `360` exclusivo, en grados; saturación y luminancia son de `-100` a `100`, por ciento. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color` | El color de sustitución usa valores de canal de `0` a `255`. Los valores alfa existentes no se modifican. |
| [addBlurEffect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `radius`, `grow` | El radio es no negativo y se mide en puntos; `grow` es un Boolean que controla si el contenido desenfocado puede extenderse fuera de los límites originales. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `amount` | Porcentaje no negativo. Use `0` a `100` para escalar la opacidad ordinaria: `0` es totalmente transparente y `100` conserva el alfa existente. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `alpha` | `0` a `100`, por ciento de opacidad. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `threshold` | `0` a `100`, por ciento de umbral alfa. Los valores por debajo se vuelven transparentes; los valores iguales o superiores se vuelven opacos. |

Para la modulación alfa fija, la transparencia y la opacidad son complementarias. Por ejemplo, un 35 % de transparencia corresponde a una cantidad de modulación alfa del 65 %.

## **Aplicar brillo y contraste**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/imagetransformoperationcollection/) devuelve una operación [BrightnessContrast](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/brightnesscontrast/). Sus ajustes escalares se suministran cuando se crea la operación. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/brightnesscontrast/) devuelve valores calculados de solo lectura que pueden inspeccionarse o registrarse.

El siguiente ejemplo incrementa el brillo en un 15 % y el contraste en un 20 %, luego genera una vista previa sin modificar la imagen incrustada:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 260, image);
    const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    const brightnessContrast = imageTransform.addBrightnessContrastEffect(15, 20);

    const effectiveValues = brightnessContrast.getEffective();
    console.log("Brightness: " + effectiveValues.getBrightness() + "%");
    console.log("Contrast: " + effectiveValues.getContrast() + "%");

    const preview = slide.getImage();
    try {
        preview.save("brightness-contrast-preview.png", aspose.slides.ImageFormat.Png);
    } finally {
        preview.dispose();
    }
} finally {
    presentation.dispose();
}
```

[BrightnessContrast](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/brightnesscontrast/) es una extensión de efecto de imagen de Office 2010 y es menos portátil que el efecto de luminancia estándar de DrawingML. Cuando el brillo y el contraste deben permanecer editables después de una ida y vuelta de PPTX, use [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/imagetransformoperationcollection/) y verifique el resultado tras volver a abrir el archivo. La sección de limitaciones de formato explica esta distinción con más detalle.

## **Aplicar transformaciones de color**

Los efectos de color pueden aplicarse de forma independiente a diferentes fotogramas de imagen que reutilizan un mismo recurso de imagen. El siguiente ejemplo crea cinco fotogramas y aplica escala de grises, duotono, tono, ajuste HSL y sustitución de color.

[Duotone](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/duotone/) contiene dos parámetros de color editables de forma independiente: `color1` asigna los píxeles oscuros, mientras que `color2` asigna los píxeles claros. Esto lo convierte en un ejemplo útil de un efecto cuyas configuraciones son más complejas que un único valor escalar.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const grayFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 180, 120, image);
    grayFrame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect();

    const duotoneFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 220, 20, 180, 120, image);
    const duotone = duotoneFrame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect();
    duotone.getColor1().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 128));
    duotone.getColor2().setColor(java.newInstanceSync("java.awt.Color", 255, 215, 0));

    const tintFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 420, 20, 180, 120, image);
    tintFrame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210, 35);

    const hslFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 120, 170, 180, 120, image);
    hslFrame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30, 20, -10);

    const replacementFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 320, 170, 180, 120, image);
    const colorReplacement = replacementFrame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect();
    colorReplacement.getColor().setColor(java.newInstanceSync("java.awt.Color", 100, 149, 237));

    presentation.save("color-transformations.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/imagetransformoperationcollection/) sustituye el color de cada píxel por un color fijo manteniendo el alfa. Es diferente de [addColorChangeEffect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/imagetransformoperationcollection/), que asigna un color origen a otro y expone los formatos de color origen y destino.

## **Añadir desenfoque, transparencia y efectos alfa**

[addBlurEffect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/imagetransformoperationcollection/) afecta a todos los canales de color, incluido el alfa. Establezca `grow` en `true` cuando el borde desenfocado pueda extenderse más allá de los límites originales de la imagen.

Para una transparencia uniforme, use [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/imagetransformoperationcollection/). Multiplica cada valor alfa existente, de modo que los píxeles parcialmente transparentes siguen siendo proporcionalmente diferentes. [addAlphaReplaceEffect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/imagetransformoperationcollection/) asigna, en cambio, un único valor alfa a todos los píxeles. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/imagetransformoperationcollection/) convierte el alfa en dos niveles basados en un umbral.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const blurredFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 140, image);
    const blur = blurredFrame.getPictureFormat().getPicture().getImageTransform().addBlurEffect(4.5, true);
    blur.setRadius(5);

    const transparentFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 240, 20, 200, 140, image);
    const alphaModulate = transparentFrame.getPictureFormat().getPicture().getImageTransform().addAlphaModulateFixedEffect(65);
    alphaModulate.setAmount(60);

    const uniformAlphaFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 180, 200, 140, image);
    uniformAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaReplaceEffect(55);

    const binaryAlphaFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 240, 180, 200, 140, image);
    const alphaBiLevel = binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaBiLevelEffect(50);
    alphaBiLevel.setThreshold(45);
    binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaInverseEffect();

    presentation.save("blur-and-alpha-effects.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Otras operaciones alfa sin parámetros incluyen [addAlphaCeilingEffect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/imagetransformoperationcollection/), que hace que todo alfa distinto de cero sea totalmente opaco; [addAlphaFloorEffect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/imagetransformoperationcollection/), que hace que todo alfa por debajo del 100 % sea totalmente transparente; y [addAlphaInverseEffect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/imagetransformoperationcollection/), que cambia el alfa a `100% - alfa`.

## **Construir una cadena de efectos ordenada**

Cada método `add...Effect` añade una nueva operación al final de la colección. El renderizador utiliza la colección como una canalización ordenada: la salida de la operación 0 pasa a ser la entrada de la operación 1, y así sucesivamente. En consecuencia, las mismas operaciones en un orden diferente pueden producir una imagen distinta.

Por ejemplo, escala de grises seguido de tono elimina primero la información cromática y luego recolorea el resultado de luminancia. Tono seguido de escala de grises elimina de nuevo el tono. De manera similar, la sustitución alfa puede sobrescribir los valores alfa calculados por operaciones anteriores, mientras que la modulación alfa conserva sus diferencias relativas.

El siguiente ejemplo crea una cadena de cuatro operaciones, la guarda como PPTX, vuelve a abrir la presentación, comprueba tanto los tipos de operación como su orden, y renderiza el resultado reabierto:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 260, image);
    const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    imageTransform.addGrayScaleEffect();
    imageTransform.addTintEffect(220, 25);
    imageTransform.addBlurEffect(2.5, false);
    imageTransform.addAlphaModulateFixedEffect(80);

    presentation.save("image-transform-chain.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation("image-transform-chain.pptx");
try {
    const reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (java.instanceOf(reopenedShape, "com.aspose.slides.IPictureFrame")) {
        const reopenedTransform = reopenedShape.getPictureFormat().getPicture().getImageTransform();
        const orderIsPreserved = reopenedTransform.size() === 4 &&
            java.instanceOf(reopenedTransform.get_Item(0), "com.aspose.slides.IGrayScale") &&
            java.instanceOf(reopenedTransform.get_Item(1), "com.aspose.slides.ITint") &&
            java.instanceOf(reopenedTransform.get_Item(2), "com.aspose.slides.IBlur") &&
            java.instanceOf(reopenedTransform.get_Item(3), "com.aspose.slides.IAlphaModulateFixed");
        console.log(orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.");

        const renderedSlide = reopenedPresentation.getSlides().get_Item(0).getImage();
        try {
            renderedSlide.save("reopened-effect-chain.png", aspose.slides.ImageFormat.Png);
        } finally {
            renderedSlide.dispose();
        }
    } else {
        console.log("The reopened shape is not a picture frame.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

La colección no impone una matriz de compatibilidad que limite las operaciones de color, alfa y desenfoque a cadenas separadas. Pueden combinarse, pero las combinaciones no siempre son útiles. Una sustitución de color fija elimina la variación RGB producida por efectos de color anteriores; la escala de grises después del duotono elimina los dos colores seleccionados; y las operaciones de techo, suelo, sustitución o bi‑nivel alfa pueden descartar detalles alfa creados antes. Constrúyala según la secuencia deseada de procesamiento de píxeles en lugar de tratar sus elementos como banderas de formato sin orden.

## **Inspeccionar valores editables y efectivos**

Una operación editable es el objeto almacenado en [Picture.getImageTransform](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/picture/). Según el efecto, puede exponer miembros escribibles directamente. Por ejemplo, [Blur](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/blur/) expone valores escribibles `radius` y `grow`, [AlphaModulateFixed](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/alphamodulatefixed/) expone un `amount` escribible, y [AlphaBiLevel](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/alphabilevel/) expone un `threshold` escribible. Los efectos de color como [Duotone](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/duotone/) exponen objetos mutables [ColorFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/colorformat/).

Algunas operaciones, incluidos [BrightnessContrast](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/tint/) y [AlphaReplace](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/alphareplace/), no exponen sus escalares de creación como propiedades escribibles. Para cambiar esos ajustes, elimine la operación y añada una de sustitución en la posición requerida.

Los datos efectivos devueltos por `getEffective()` se calculan y son de solo lectura. Son útiles para resolver colores dependientes del tema y leer los valores normalizados que utiliza el renderizador, pero no constituyen otra superficie de edición. El siguiente ejemplo recorre la cadena e inspecciona los valores efectivos donde la API correspondiente los proporciona:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("image-transform-chain.pptx");
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();
    let pictureFrame = null;

    for (let index = 0; index < shapes.size(); index++) {
        const shape = shapes.get_Item(index);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();

        for (let index = 0; index < imageTransform.size(); index++) {
            const operation = imageTransform.get_Item(index);
            console.log(index + ": " + operation.getClass().getSimpleName());

            if (java.instanceOf(operation, "com.aspose.slides.IBrightnessContrast")) {
                const data = operation.getEffective();
                console.log("  Brightness: " + data.getBrightness());
                console.log("  Contrast: " + data.getContrast());
            } else if (java.instanceOf(operation, "com.aspose.slides.ILuminance")) {
                const data = operation.getEffective();
                console.log("  Brightness: " + data.getBrightness());
                console.log("  Contrast: " + data.getContrast());
            } else if (java.instanceOf(operation, "com.aspose.slides.IDuotone")) {
                const data = operation.getEffective();
                console.log("  Dark color: " + data.getColor1());
                console.log("  Light color: " + data.getColor2());
            } else if (java.instanceOf(operation, "com.aspose.slides.IColorReplace")) {
                const data = operation.getEffective();
                console.log("  Replacement color: " + data.getColor());
            } else if (java.instanceOf(operation, "com.aspose.slides.IHSL")) {
                const data = operation.getEffective();
                console.log("  HSL: " + data.getHue() + ", " + data.getSaturation() + ", " + data.getLuminance());
            } else if (java.instanceOf(operation, "com.aspose.slides.ITint")) {
                const data = operation.getEffective();
                console.log("  Tint: " + data.getHue() + ", " + data.getAmount());
            } else if (java.instanceOf(operation, "com.aspose.slides.IBlur")) {
                const data = operation.getEffective();
                console.log("  Blur radius: " + data.getRadius() + " pt");
            } else if (java.instanceOf(operation, "com.aspose.slides.IAlphaModulateFixed")) {
                const data = operation.getEffective();
                console.log("  Alpha amount: " + data.getAmount() + "%");
            } else if (java.instanceOf(operation, "com.aspose.slides.IAlphaReplace")) {
                const data = operation.getEffective();
                console.log("  Replacement alpha: " + data.getAlpha() + "%");
            } else if (java.instanceOf(operation, "com.aspose.slides.IAlphaBiLevel")) {
                const data = operation.getEffective();
                console.log("  Alpha threshold: " + data.getThreshold() + "%");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Los efectos sin parámetros, como escala de grises, techo alfa e inverso alfa, también disponen de un objeto de datos efectivo, pero no hay ajustes escalares que imprimir. Su presencia y posición en la colección son la información importante.

## **Eliminar o borrar transformaciones de imagen**

Use [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/imagetransformoperationcollection/) para eliminar una operación por índice. Como los índices cambian después de una eliminación, busque primero el objetivo y elimínelo tras la enumeración. Use [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/imagetransformoperationcollection/) para borrar toda la cadena.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("image-transform-chain.pptx");
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();
    let pictureFrame = null;

    for (let index = 0; index < shapes.size(); index++) {
        const shape = shapes.get_Item(index);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        let blurIndex = -1;

        for (let index = 0; index < imageTransform.size(); index++) {
            if (java.instanceOf(imageTransform.get_Item(index), "com.aspose.slides.IBlur")) {
                blurIndex = index;
                break;
            }
        }

        if (blurIndex >= 0) {
            imageTransform.removeAt(blurIndex);
            console.log("The blur operation was removed.");
        }

        imageTransform.clear();
        console.log("Remaining operations: " + imageTransform.size());
        presentation.save("image-transforms-cleared.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Eliminar o borrar transformaciones sólo modifica el formato de la imagen. No elimina, recompime ni altera de otro modo el recurso [PPImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/ppimage/) reutilizado.

## **Considerar formatos de presentación y destinos de exportación**

Las transformaciones de imagen se originan en DrawingML, por lo que PPTX es el formato editable preferido para cadenas de efectos. Incluso con PPTX, no todas las operaciones tienen la misma portabilidad:

- Las operaciones estándar de DrawingML como luminancia, escala de grises, duotono, tono, HSL, desenfoque y operaciones alfa comunes tienen la mejor probabilidad de sobrevivir a una ida y vuelta de PPTX. Siempre vuelva a abrir el archivo generado e inspeccione la colección cuando la preservación sea un requisito.
- [BrightnessContrast](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/brightnesscontrast/) es una extensión de Office 2010 más que la operación de luminancia estándar de DrawingML. Puede usarse para renderizado en memoria, pero no se garantiza que permanezca como una operación editable [BrightnessContrast](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/brightnesscontrast/) tras guardar y volver a abrir PPTX. Prefiera [addLuminanceEffect](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/imagetransformoperationcollection/) para ajustes persistentes de brillo y contraste.
- El formato binario PPT precede al modelo completo de efectos DrawingML. Guardar en PPT puede omitir operaciones no soportadas, reducir una cadena a un subconjunto admitido o aproximar la apariencia. No use PPT como formato de verificación para una cadena editable compleja.
- Renderizar a PNG, JPEG, TIFF, PDF, SVG, HTML u otro salida visual aplica la cadena admitida a la apariencia renderizada. esas salidas no contienen una [ImageTransformOperationCollection](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/imagetransformoperationcollection/) editable; los formatos raster aplanan el resultado en píxeles, y las exportaciones de documento/vector almacenan su propia representación de renderizado.
- Los efectos no convierten una imagen vinculada en autocontenida. Renderizar una imagen vinculada sigue dependiendo de que el recurso vinculado esté disponible cuando se cargue la presentación.

Diferentes consumidores de presentaciones pueden renderizar casos límite de forma distinta, sobre todo cuando se combinan varias operaciones alfa o de cuantización de color. Para salidas críticas, pruebe tanto la ida y vuelta editable como el formato de exportación final con la misma versión de Aspose.Slides utilizada en producción.

## **FAQ**

**¿Los efectos de transformación de imagen modifican los datos de la imagen incrustada?**

No. Las operaciones pertenecen al [Picture](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/picture/) utilizado por el relleno de imagen. Los bytes subyacentes de [PPImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/ppimage/) permanecen sin cambios.

**¿Dos fotogramas de imagen que reutilizan la misma imagen comparten sus efectos?**

No. Reutilizar un [PPImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/ppimage/) evita datos de imagen duplicados, pero cada fotograma de imagen normalmente tiene su propio [Picture](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/picture/) y su propia colección de transformaciones.

**¿Se pueden combinar efectos de color, desenfoque y alfa?**

Sí. La colección los acepta en una única cadena ordenada. Considere lo que cada operación hace sobre la salida de la anterior, ya que las operaciones de sustitución y umbral pueden descartar detalles de color o alfa anteriores.

**¿Por qué los valores efectivos son de solo lectura?**

Los datos efectivos representan valores calculados usados para el renderizado, incluidos los colores resueltos. Edite la operación almacenada en la colección de transformaciones donde existan miembros escribibles; de lo contrario elimínela y añada una de sustitución con nuevos parámetros de creación.

**¿Qué formato debo usar para preservar una cadena de transformaciones?**

Use PPTX y verifique el archivo volviéndolo a abrir. El PPT heredado no puede representar el modelo completo de efectos DrawingML, y los formatos de exportación renderizados conservan la apariencia más que las operaciones de transformación editables.