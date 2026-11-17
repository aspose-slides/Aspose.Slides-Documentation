---
title: Gestionar efectos de transformación de imagen en presentaciones con JavaScript
linktitle: Efectos de transformación de imagen
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
- tinte
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
description: "Aplicar, encadenar, inspeccionar, eliminar y verificar los efectos de transformación de imagen para marcos de imagen con Aspose.Slides para Node.js mediante Java."
---
## **Visión general**

Aspose.Slides representa los ajustes de imagen como una colección ordenada de operaciones de transformación de imagen. Para un marco de imagen, comience con el [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) del marco y acceda a [Picture.getImageTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/). La [ImageTransformOperationCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) devuelta le permite añadir, enumerar, inspeccionar, eliminar y limpiar efectos sin reescribir los bytes originales de la imagen.

Este artículo muestra un flujo de trabajo completo para brillo y contraste, transformaciones de color, desenfoque, transparencia, cadenas de efectos ordenadas, valores efectivos, eliminación y verificación de ida y vuelta en PPTX.

## **Comprender la propiedad del efecto y la reutilización de imágenes**

Un recurso de imagen y la imagen que la muestra son objetos diferentes:

- [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) almacena o referencia los datos de imagen fuente que posee la presentación.
- [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) pertenece a un relleno de imagen y se refiere a un recurso de imagen mientras almacena la colección de transformaciones de imagen.
- [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) es la forma de diapositiva que posee el relleno de imagen correspondiente, la geometría, la configuración de recorte y demás formato a nivel de marco.

Por lo tanto, las operaciones de transformación de imagen no modifican los bytes en [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/). Cuando el mismo [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) se pasa a [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/) más de una vez, cada nuevo marco de imagen recibe su propio [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) y su propia colección de transformaciones. Aplicar escala de grises a un marco no vuelve en escala de grises a los demás marcos, aunque todos reutilicen el mismo recurso de imagen incrustado.

El mismo modelo [Picture.getImageTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) también se utiliza en otros rellenos de imagen, como una forma o el fondo de una diapositiva. Los ejemplos siguientes se centran en marcos de imagen.

## **Utilizar rangos y unidades de parámetros válidos**

Los métodos demostrados usan los siguientes rangos semánticos y unidades. Mantenga los valores dentro de estos rangos aunque una versión concreta de la biblioteca no rechace inmediatamente cada valor fuera de rango; el formato de presentación destino puede normalizar, omitir o rechazar datos no válidos durante el guardado o cuando PowerPoint abra el archivo.

| Operación | Parámetros | Rango válido y unidad |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `brightness`, `contrast` | `-100` a `100`, por ciento; `0` deja el componente sin cambios. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | Ninguno | No hay parámetros numéricos. Alfa no se modifica. |
| [addDuotoneEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color1`, `color2` | Dos colores para píxeles oscuros y claros. Los canales RGB y alfa en `java.awt.Color` usan valores de `0` a `255`. |
| [addTintEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `amount` | Matiz es de `0` inclusive a `360` exclusivo, en grados; la cantidad es de `-100` a `100`, por ciento. |
| [addHSLEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `saturation`, `luminance` | Matiz es de `0` inclusive a `360` exclusivo, en grados; saturación y luminancia son de `-100` a `100`, por ciento. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color` | El color de reemplazo usa valores de canal de `0` a `255`. Los valores alfa existentes no se modifican. |
| [addBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `radius`, `grow` | El radio es no negativo y se mide en puntos; `grow` es un Boolean que controla si el contenido desenfocado puede extenderse fuera de los límites originales. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `amount` | Porcentaje no negativo. Use `0` a `100` para escalar opacidad de forma ordinaria: `0` es totalmente transparente y `100` conserva el alfa existente. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `alpha` | `0` a `100`, por ciento de opacidad. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `threshold` | `0` a `100`, por ciento de umbral alfa. Los valores por debajo se vuelven transparentes; los valores en o por encima se vuelven opacos. |

Para la modulación alfa fija, la transparencia y la opacidad son complementarias. Por ejemplo, un 35 % de transparencia corresponde a una cantidad de modulación alfa del 65 %.

## **Aplicar brillo y contraste**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) devuelve una operación [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/). Sus ajustes escalares se suministran cuando se crea la operación. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) devuelve valores calculados de solo lectura que pueden inspeccionarse o registrarse.

El siguiente ejemplo aumenta el brillo un 15 % y el contraste un 20 %, y luego genera una vista previa sin modificar la imagen incrustada:

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

[BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) es una extensión de efecto de imagen de Office 2010 y es menos portátil que el efecto de luminancia estándar de DrawingML. Cuando el brillo y el contraste deben seguir editables después de una ida y vuelta en PPTX, use [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) y verifique el resultado tras volver a abrir el archivo. La sección de limitaciones de formato explica esta distinción con más detalle.

## **Aplicar transformaciones de color**

Los efectos de color pueden aplicarse de forma independiente a diferentes marcos de imagen que reutilizan un mismo recurso de imagen. El siguiente ejemplo crea cinco marcos y aplica escala de grises, duotono, tinte, ajuste HSL y reemplazo de color.

[Duotone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/duotone/) contiene dos parámetros de color editables de forma independiente: `color1` asigna los píxeles oscuros, mientras que `color2` asigna los píxeles claros. Esto lo convierte en un ejemplo útil de un efecto cuyas configuraciones son más complejas que un único valor escalar.

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

[addColorReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) reemplaza el color de cada píxel por un color fijo manteniendo el alfa. Es diferente de [addColorChangeEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/), que asigna un color fuente a otro y expone ambos formatos de color fuente y destino.

### **Aplicar un umbral de luminancia**

Un umbral de luminancia puede facilitar la distinción de marcas tenues en una página escaneada respecto al fondo. [addGrayScaleEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) conserva tonos intermedios de gris. [addBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) asigna la luminancia a negro o blanco, mientras que [addAlphaBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) aplica un umbral a la opacidad.

El umbral de luminancia varía del 0 % al 100 %, inclusive. Los píxeles por debajo del umbral se vuelven negros. Los píxeles en o por encima se vuelven blancos. Incrementar el umbral vuelve más tonos negros porque más de ellos caen bajo el límite.

Descargue [grayscale-swatches.png](grayscale-swatches.png) en el directorio de trabajo. Cada etiqueta indica el nivel de gris original en una escala de 0 a 255. El ejemplo coloca el original junto a dos copias y guarda el umbral de cada copia en la presentación.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 150, slides.SlideSizeScaleType.DoNotScale);
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const sourceImage = slides.Images.fromFile("grayscale-swatches.png");
    let image;
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const captions = ["Original", "Threshold 20%", "Threshold 60%"];
    const frames = [];
    for (let i = 0; i < captions.length; i++) {
        const x = 12 + 240 * i;
        const label = shapes.addAutoShape(slides.ShapeType.Rectangle, x, 12, 216, 36);
        label.getTextFrame().setText(captions[i]);
        const frame = shapes.addPictureFrame(slides.ShapeType.Rectangle, x, 60, 216, 72, image);
        frames.push(frame);
    }

    frames[1].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(20);
    frames[2].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(60);
    
    presentation.save("luminance-threshold.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Abra la presentación resultante en PowerPoint para comparar los tres marcos. La muestra etiquetada 96 tiene aproximadamente un 38 % de luminancia (96 de 255). Se vuelve blanca al 20 % de umbral y negra al 60 % de umbral.

![Muestras de escala de grises original junto a los resultados en blanco y negro a umbrales de luminancia del 20% y 60%](luminance-threshold.png)

## **Añadir desenfoque, transparencia y efectos alfa**

[addBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) afecta a todos los canales de color, incluido el alfa. Establezca `grow` en `true` cuando el borde desenfocado pueda extenderse más allá de los límites originales de la imagen.

Para una transparencia uniforme, use [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/). Multiplica cada valor alfa existente, de modo que los píxeles parcialmente transparentes siguen siendo proporcionalmente diferentes. [addAlphaReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) asigna, en su lugar, un único valor alfa a todos los píxeles. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) convierte el alfa a dos niveles según un umbral.

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

Otras operaciones alfa sin parámetros incluyen [addAlphaCeilingEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/), que hace que cualquier alfa distinto de cero sea totalmente opaco; [addAlphaFloorEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/), que hace que cualquier alfa por debajo del 100 % sea totalmente transparente; y [addAlphaInverseEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/), que cambia el alfa a `100% - alpha`.

## **Construir una cadena de efectos ordenada**

Cada método `add...Effect` añade una nueva operación al final de la colección. El motor de renderizado utiliza la colección como una tubería ordenada: la salida de la operación 0 pasa a ser la entrada de la operación 1, y así sucesivamente. Por consiguiente, las mismas operaciones en un orden distinto pueden producir una imagen diferente.

Por ejemplo, aplicar escala de grises y después tinte elimina primero la información cromática y después recolorea el resultado de luminancia. Aplicar tinte y luego escala de grises elimina el tinte de nuevo. De forma similar, la sustitución alfa puede sobrescribir los valores alfa calculados por operaciones anteriores, mientras que la modulación alfa preserva sus diferencias relativas.

El siguiente ejemplo construye una cadena de cuatro operaciones, la guarda como PPTX, vuelve a abrir la presentación, comprueba tanto los tipos de operación como su orden, y renderiza el resultado reabierto:

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

La colección no impone una matriz de compatibilidad que limite los efectos de color, alfa y desenfoque a cadenas separadas. Pueden combinarse, pero no siempre resulta útil. Un reemplazo de color fijo elimina la variación RGB generada por efectos de color anteriores; la escala de grises después de duotono elimina los dos colores seleccionados; y las operaciones de techo, suelo, sustitución o bi‑nivel alfa pueden descartar detalle alfa creado anteriormente. Construya la cadena según la secuencia de procesamiento de píxeles deseada en lugar de tratar sus elementos como indicadores de formato sin orden.

<!-- visual-explanation:image-transform-effects:start -->
[![La misma imagen pasa primero por escala de grises y luego por tinte, y viceversa. Las dos imágenes finales en escala de grises tienen tonos diferentes.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*En esta ilustración de Aspose.Slides for .NET 26.11, un tinte de 220 ° al 25 % deja la imagen en escala de grises sin cambios. Aplicar el mismo tinte antes de la escala de grises produce tonos diferentes.*
<!-- visual-explanation:image-transform-effects:end -->

## **Inspeccionar valores editables y efectivos**

Una operación editable es el objeto almacenado en [Picture.getImageTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/). Según el efecto, puede exponer miembros grabables directamente. Por ejemplo, [Blur](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blur/) expone los valores grabables `radius` y `grow`, [AlphaModulateFixed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/alphamodulatefixed/) expone un `amount` grabable, y [AlphaBiLevel](https://reference.aspose.com/slides/nodejs-java/aspose.slides/alphabilevel/) expone un `threshold` grabable. Los efectos de color como [Duotone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/duotone/) exponen objetos [ColorFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/) mutables.

Algunas operaciones, incluidas [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/nodejs-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tint/) y [AlphaReplace](https://reference.aspose.com/slides/nodejs-java/aspose.slides/alphareplace/), no exponen sus escalares de creación como propiedades grabables. Para cambiar esas configuraciones, elimine la operación y añada una de reemplazo en la posición requerida.

Los datos efectivos devueltos por `getEffective()` se calculan y son de solo lectura. Son útiles para resolver colores dependientes del tema y leer los valores normalizados que usa el motor de renderizado, pero no constituyen otra superficie de edición. El siguiente ejemplo enumera la cadena e inspecciona los valores efectivos donde la API correspondiente los proporciona:

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

Los efectos sin parámetros como escala de grises, techo alfa e inverso alfa también poseen un objeto de datos efectivo, pero no hay ajustes escalares que imprimir. Su presencia y posición en la colección son la información importante.

## **Eliminar o limpiar transformaciones de imagen**

Utilice [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) para eliminar una operación por índice. Como los índices cambian tras la eliminación, busque primero el objetivo y elimínelo después de la enumeración. Utilice [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) para eliminar la cadena completa.

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

Eliminar o limpiar transformaciones cambia solo el formato de la imagen. No elimina, recomprime ni altera de otro modo el recurso [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) reutilizado.

## **Considerar formatos de presentación y destinos de exportación**

Las transformaciones de imagen se originan en DrawingML, por lo que PPTX es el formato editable preferido para cadenas de efectos. Incluso con PPTX, no todas las operaciones tienen la misma portabilidad:

- Las operaciones estándar de DrawingML como luminancia, escala de grises, duotono, tinte, HSL, desenfoque y operaciones alfa comunes tienen mayor probabilidad de sobrevivir a una ida y vuelta en PPTX. Siempre vuelva a abrir el archivo generado e inspeccione la colección cuando la preservación sea un requisito.
- [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) es una extensión de Office 2010 en lugar de la operación estándar de luminancia de DrawingML. Puede usarse para renderizado en memoria, pero no está garantizado que permanezca como una operación editable de [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) tras guardar y volver a abrir PPTX. Prefiera [addLuminanceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) para ajustes persistentes de brillo y contraste.
- El formato binario PPT precede al modelo completo de efectos DrawingML. Guardar en PPT puede omitir operaciones no admitidas, reducir una cadena a un subconjunto soportado o aproximar la apariencia. No use PPT como formato de verificación para una cadena editable compleja.
- Renderizar a PNG, JPEG, TIFF, PDF, SVG, HTML u otro formato visual aplica la cadena soportada a la apariencia renderizada. Esos resultados no contienen una [ImageTransformOperationCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) editable; los formatos raster aplanan el resultado en píxeles, y las exportaciones de documento/vector almacenan su propia representación de renderizado.
- Los efectos no convierten una imagen enlazada en un recurso autónomo. Renderizar una imagen enlazada sigue dependiendo de que el recurso enlazado esté disponible cuando se cargue la presentación.

Diferentes consumidores de presentaciones pueden renderizar casos límite de forma distinta, sobre todo cuando se combinan varias operaciones alfa o de cuantización de color. Para una salida crítica, pruebe tanto la ida y vuelta editable como el formato de exportación final con la misma versión de Aspose.Slides utilizada en producción.

## **FAQ**

**¿Los efectos de transformación de imagen modifican los datos de la imagen incrustada?**

No. Las operaciones pertenecen al [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) utilizado por el relleno de imagen. Los bytes subyacentes de [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) permanecen sin cambios.

**¿Dos marcos de imagen que reutilizan la misma imagen comparten sus efectos?**

No. Reutilizar un [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) evita datos de imagen duplicados, pero cada marco de imagen normalmente tiene su propio [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) y su propia colección de transformaciones de imagen.

**¿Se pueden combinar efectos de color, desenfoque y alfa?**

Sí. La colección los acepta en una sola cadena ordenada. Considere lo que cada operación hace sobre la salida de la anterior, ya que las operaciones de sustitución y umbral pueden descartar detalle de color o alfa previo.

**¿Por qué los valores efectivos son de solo lectura?**

Los datos efectivos representan los valores calculados usados para el renderizado, incluidos los colores resueltos. Edite la operación almacenada en la colección de transformaciones donde existan miembros grabables; de lo contrario elimínela y añada una de reemplazo con nuevos parámetros de creación.

**¿Qué formato debo usar para conservar una cadena de transformaciones?**

Use PPTX y verifique el archivo volviéndolo a abrir. El legado PPT no puede representar el modelo completo de efectos DrawingML, y los formatos de exportación renderizados conservan solo la apariencia, no las operaciones de transformación editables.