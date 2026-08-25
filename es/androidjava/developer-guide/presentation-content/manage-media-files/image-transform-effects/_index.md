---
title: Gestionar efectos de transformación de imagen en presentaciones en Android
linktitle: Efectos de transformación de imagen
type: docs
weight: 11
url: /es/androidjava/image-transform-effects/
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
- Android
- Java
- Aspose.Slides
description: "Aplicar, encadenar, inspeccionar, eliminar y verificar efectos de transformación de imagen para marcos de imagen con Aspose.Slides para Android mediante Java."
---
## **Descripción general**

Aspose.Slides representa los ajustes de imagen como una colección ordenada de operaciones de transformación de imagen. Para un marco de imagen, comience con el [ISlidesPicture](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/islidespicture/) del marco y acceda a [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/islidespicture/#getImageTransform--). La [IImageTransformOperationCollection](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iimagetransformoperationcollection/) devuelta le permite añadir, enumerar, inspeccionar, eliminar y limpiar efectos sin reescribir los bytes originales de la imagen.

Este artículo muestra un flujo de trabajo completo para brillo y contraste, transformaciones de color, desenfoque, transparencia, cadenas de efectos ordenadas, valores efectivos, eliminación y verificación de ida y vuelta en PPTX.

## **Comprender la propiedad de los efectos y la reutilización de imágenes**

Un recurso de imagen y la imagen que lo muestra son objetos diferentes:

- [IPPImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ippimage/) almacena o hace referencia a los datos de imagen origen que posee la presentación.
- [ISlidesPicture](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/islidespicture/) pertenece a un relleno de imagen y hace referencia a un recurso de imagen mientras almacena la colección de transformaciones de imagen.
- [IPictureFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ipictureframe/) es la forma de diapositiva que posee el relleno de imagen correspondiente, la geometría, los ajustes de recorte y demás formato a nivel de marco.

Por lo tanto, las operaciones de transformación de imagen no modifican los bytes en [IPPImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ippimage/). Cuando el mismo `IPPImage` se pasa a [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) más de una vez, cada nuevo marco de imagen recibe su propio `ISlidesPicture` y su propia colección de transformaciones. Aplicar escala de grises a un marco no hace que los demás marcos queden en escala de grises, aunque todos reutilicen el mismo recurso de imagen incrustado.

El mismo modelo `ISlidesPicture.getImageTransform` también se usa en otros rellenos de imagen, como un fondo de forma o de diapositiva. Los ejemplos a continuación se centran en marcos de imagen.

## **Usar intervalos y unidades de parámetro válidos**

Los métodos mostrados utilizan los siguientes intervalos semánticos y unidades. Mantenga los valores dentro de estos intervalos aunque una versión particular de la biblioteca no rechace inmediatamente cada valor fuera de rango; el formato de presentación objetivo puede normalizar, omitir o rechazar datos no válidos al guardar o cuando PowerPoint abra el archivo.

| Operación | Parámetros | Rango válido y unidad |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` a `100`, por ciento; `0` deja el componente sin cambios. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | Ninguno | No hay parámetros numéricos. El alfa no cambia. |
| [addDuotoneEffect](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | Dos colores para píxeles oscuros y claros. Los valores de los canales RGB y alfa usados por `android.graphics.Color` van de `0` a `255`. |
| [addTintEffect](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | Matiz de `0` inclusive a `360` exclusivo, en grados; cantidad de `-100` a `100`, por ciento. |
| [addHSLEffect](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | Matiz de `0` inclusive a `360` exclusivo, en grados; saturación y luminancia de `-100` a `100`, por ciento. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | El color de reemplazo usa valores de canal de `0` a `255`. Los valores alfa existentes no cambian. |
| [addBlurEffect](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | Radio no negativo medido en puntos; `grow` es un Boolean que controla si el contenido desenfocado puede extenderse fuera de los límites originales. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | Porcentaje no negativo. Use `0` a `100` para la escala de opacidad normal: `0` es totalmente transparente y `100` conserva el alfa existente. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0` a `100`, por ciento de opacidad. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0` a `100`, por ciento de umbral alfa. Los valores por debajo se vuelven transparentes; los valores en o por encima se vuelven opacos. |

Para la modulación alfa fija, la transparencia y la opacidad son complementarias. Por ejemplo, un 35 % de transparencia corresponde a una cantidad de modulación alfa del 65 %.

## **Aplicar brillo y contraste**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) devuelve una operación [IBrightnessContrast](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ibrightnesscontrast/). Sus ajustes escalares se suministran cuando se crea la operación. [IBrightnessContrast.getEffective](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ibrightnesscontrast/#getEffective--) devuelve valores de solo lectura calculados que pueden inspeccionarse o registrarse.

El siguiente ejemplo aumenta el brillo un 15 % y el contraste un 20 %, luego renderiza una vista previa sin modificar la imagen incrustada:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    IBrightnessContrast brightnessContrast = imageTransform.addBrightnessContrastEffect(15f, 20f);

    IBrightnessContrastEffectiveData effectiveValues = brightnessContrast.getEffective();
    System.out.println("Brightness: " + effectiveValues.getBrightness() + "%");
    System.out.println("Contrast: " + effectiveValues.getContrast() + "%");

    IImage preview = slide.getImage();
    try {
        preview.save("brightness-contrast-preview.png", ImageFormat.Png);
    } finally {
        preview.dispose();
    }
} finally {
    presentation.dispose();
}
```

[BrightnessContrast](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/brightnesscontrast/) es una extensión de efecto de imagen de Office 2010 y es menos portátil que el efecto de luminancia estándar de DrawingML. Cuando el brillo y el contraste deben permanecer editables después de una ida y vuelta en PPTX, use [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) y verifique el resultado tras volver a abrir el archivo. La sección de limitaciones de formato explica esta distinción con más detalle.

## **Aplicar transformaciones de color**

Los efectos de color pueden aplicarse de forma independiente a diferentes marcos de imagen que reutilizan un mismo recurso de imagen. El siguiente ejemplo crea cinco marcos y aplica escala de grises, duotono, tinte, ajuste HSL y sustitución de color.

[IDuotone](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iduotone/) contiene dos parámetros de color editables de forma independiente: `color1` asigna los píxeles oscuros, mientras que `color2` asigna los píxeles claros. Esto lo convierte en un ejemplo útil de un efecto cuyas configuraciones son más complejas que un solo valor escalar.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame grayFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image);
    grayFrame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect();

    IPictureFrame duotoneFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image);
    IDuotone duotone = duotoneFrame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect();
    duotone.getColor1().setColor(Color.rgb(0, 0, 128));
    duotone.getColor2().setColor(Color.rgb(255, 215, 0));

    IPictureFrame tintFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image);
    tintFrame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210f, 35f);

    IPictureFrame hslFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image);
    hslFrame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30f, 20f, -10f);

    IPictureFrame replacementFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image);
    IColorReplace colorReplacement = replacementFrame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect();
    colorReplacement.getColor().setColor(Color.rgb(100, 149, 237));

    presentation.save("color-transformations.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) sustituye el color de cada píxel por un color fijo mientras conserva el alfa. Es diferente de [addColorChangeEffect](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--), que asigna un color fuente a otro y expone ambos formatos de color origen y destino.

## **Añadir desenfoque, transparencia y efectos alfa**

[addBlurEffect](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) afecta a todos los canales de color, incluido el alfa. Establezca `grow` en `true` cuando el borde desenfocado pueda extenderse más allá de los límites originales de la imagen.

Para una transparencia uniforme, use [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-). Multiplica cada valor alfa existente, de modo que los píxeles parcialmente transparentes permanecen proporcionalmente diferentes. [addAlphaReplaceEffect](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) asigna un único valor alfa a todos los píxeles. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) convierte el alfa a dos niveles según un umbral.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame blurredFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 140, image);
    IBlur blur = blurredFrame.getPictureFormat().getPicture().getImageTransform().addBlurEffect(4.5, true);
    blur.setRadius(5);

    IPictureFrame transparentFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 20, 200, 140, image);
    IAlphaModulateFixed alphaModulate = transparentFrame.getPictureFormat().getPicture().getImageTransform().addAlphaModulateFixedEffect(65f);
    alphaModulate.setAmount(60f);

    IPictureFrame uniformAlphaFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 180, 200, 140, image);
    uniformAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaReplaceEffect(55f);

    IPictureFrame binaryAlphaFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 180, 200, 140, image);
    IAlphaBiLevel alphaBiLevel = binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaBiLevelEffect(50f);
    alphaBiLevel.setThreshold(45f);
    binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaInverseEffect();

    presentation.save("blur-and-alpha-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Otras operaciones alfa sin parámetros incluyen [addAlphaCeilingEffect](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--) que hace que cualquier alfa distinto de cero sea totalmente opaco; [addAlphaFloorEffect](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--) que hace que cualquier alfa por debajo del 100 % sea totalmente transparente; y [addAlphaInverseEffect](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--) que cambia el alfa a `100% - alpha`.

## **Construir una cadena de efectos ordenada**

Cada método `add...Effect` añade una nueva operación al final de la colección. El renderizador usa la colección como una canalización ordenada: la salida de la operación 0 se convierte en la entrada de la operación 1, y así sucesivamente. En consecuencia, las mismas operaciones en un orden diferente pueden producir una imagen distinta.

Por ejemplo, aplicar escala de grises y luego tinte elimina primero la información cromática y después colorea el resultado de luminancia. Aplicar tinte y luego escala de grises elimina de nuevo el tinte. De forma similar, la sustitución alfa puede sobrescribir los valores alfa calculados por operaciones anteriores, mientras que la modulación alfa conserva sus diferencias relativas.

El siguiente ejemplo construye una cadena de cuatro operaciones, la guarda como PPTX, vuelve a abrir la presentación, comprueba tanto los tipos de operación como su orden, y renderiza el resultado reabierto:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    imageTransform.addGrayScaleEffect();
    imageTransform.addTintEffect(220f, 25f);
    imageTransform.addBlurEffect(2.5, false);
    imageTransform.addAlphaModulateFixedEffect(80f);

    presentation.save("image-transform-chain.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation("image-transform-chain.pptx");
try {
    IShape reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (reopenedShape instanceof IPictureFrame) {
        IPictureFrame reopenedFrame = (IPictureFrame) reopenedShape;
        IImageTransformOperationCollection reopenedTransform = reopenedFrame.getPictureFormat().getPicture().getImageTransform();
        boolean orderIsPreserved = reopenedTransform.size() == 4 && 
                reopenedTransform.get_Item(0) instanceof IGrayScale && 
                reopenedTransform.get_Item(1) instanceof ITint && 
                reopenedTransform.get_Item(2) instanceof IBlur && 
                reopenedTransform.get_Item(3) instanceof IAlphaModulateFixed;
        System.out.println(orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.");

        IImage renderedSlide = reopenedPresentation.getSlides().get_Item(0).getImage();
        try {
            renderedSlide.save("reopened-effect-chain.png", ImageFormat.Png);
        } finally {
            renderedSlide.dispose();
        }
    } else {
        System.out.println("The reopened shape is not a picture frame.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

La colección no impone una matriz de compatibilidad que restrinja las operaciones de color, alfa y desenfoque a cadenas separadas. Pueden combinarse, pero no siempre son útiles. Una sustitución de color fija elimina la variación RGB producida por efectos de color anteriores; la escala de grises después del duotono elimina los dos colores seleccionados; y las operaciones de techo, suelo, sustitución o bi‑nivel alfa pueden descartar el detalle alfa creado antes. Construya la cadena según la secuencia de procesamiento de píxeles deseada en lugar de tratar sus elementos como banderas de formato sin orden.

## **Inspeccionar valores editables y efectivos**

Una operación editable es el objeto almacenado en `ISlidesPicture.getImageTransform`. Según el efecto, puede exponer miembros grabables directamente. Por ejemplo, [IBlur](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iblur/) expone los valores grabables `radius` y `grow`, [IAlphaModulateFixed](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ialphamodulatefixed/) expone un `amount` grabable, y [IAlphaBiLevel](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ialphabilevel/) expone un `threshold` grabable. Los efectos de color como [IDuotone](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iduotone/) exponen objetos [IColorFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/icolorformat/) mutables.

Algunas interfaces de operación, incluidas [IBrightnessContrast](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ihsl/), [ITint](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itint/), y [IAlphaReplace](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ialphareplace/), no exponen sus escalares de creación como propiedades grabables. Para cambiar esos ajustes, elimine la operación y añada una de reemplazo en la posición requerida.

Los datos efectivos devueltos por `getEffective()` se calculan y son de solo lectura. Son útiles para resolver colores dependientes del tema y leer los valores normalizados que usa el renderizador, pero no constituyen otra superficie de edición. El siguiente ejemplo enumera la cadena e inspecciona los valores efectivos donde la API correspondiente los proporciona:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("image-transform-chain.pptx");
try {
    IPictureFrame pictureFrame = null;

    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();

        for (int index = 0; index < imageTransform.size(); index++) {
            IImageTransformOperation operation = imageTransform.get_Item(index);
            System.out.println(index + ": " + operation.getClass().getSimpleName());

            if (operation instanceof IBrightnessContrast) {
                IBrightnessContrastEffectiveData data = ((IBrightnessContrast) operation).getEffective();
                System.out.println("  Brightness: " + data.getBrightness());
                System.out.println("  Contrast: " + data.getContrast());
            } else if (operation instanceof ILuminance) {
                ILuminanceEffectiveData data = ((ILuminance) operation).getEffective();
                System.out.println("  Brightness: " + data.getBrightness());
                System.out.println("  Contrast: " + data.getContrast());
            } else if (operation instanceof IDuotone) {
                IDuotoneEffectiveData data = ((IDuotone) operation).getEffective();
                System.out.println("  Dark color: " + data.getColor1());
                System.out.println("  Light color: " + data.getColor2());
            } else if (operation instanceof IColorReplace) {
                IColorReplaceEffectiveData data = ((IColorReplace) operation).getEffective();
                System.out.println("  Replacement color: " + data.getColor());
            } else if (operation instanceof IHSL) {
                IHSLEffectiveData data = ((IHSL) operation).getEffective();
                System.out.println("  HSL: " + data.getHue() + ", " + data.getSaturation() + ", " + data.getLuminance());
            } else if (operation instanceof ITint) {
                ITintEffectiveData data = ((ITint) operation).getEffective();
                System.out.println("  Tint: " + data.getHue() + ", " + data.getAmount());
            } else if (operation instanceof IBlur) {
                IBlurEffectiveData data = ((IBlur) operation).getEffective();
                System.out.println("  Blur radius: " + data.getRadius() + " pt");
            } else if (operation instanceof IAlphaModulateFixed) {
                IAlphaModulateFixedEffectiveData data = ((IAlphaModulateFixed) operation).getEffective();
                System.out.println("  Alpha amount: " + data.getAmount() + "%");
            } else if (operation instanceof IAlphaReplace) {
                IAlphaReplaceEffectiveData data = ((IAlphaReplace) operation).getEffective();
                System.out.println("  Replacement alpha: " + data.getAlpha() + "%");
            } else if (operation instanceof IAlphaBiLevel) {
                IAlphaBiLevelEffectiveData data = ((IAlphaBiLevel) operation).getEffective();
                System.out.println("  Alpha threshold: " + data.getThreshold() + "%");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Los efectos sin parámetros como escala de grises, techo alfa e inverso alfa también tienen un objeto de datos efectivo, pero no hay configuraciones escalares que imprimir. Su presencia y posición en la colección son la información importante.

## **Eliminar o limpiar transformaciones de imagen**

Use [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) para eliminar una operación por índice. Como los índices cambian tras una eliminación, busque el objetivo primero y elimínelo después de la enumeración. Use [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/imagetransformoperationcollection/#clear--) para eliminar toda la cadena.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("image-transform-chain.pptx");
try {
    IPictureFrame pictureFrame = null;

    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        int blurIndex = -1;

        for (int index = 0; index < imageTransform.size(); index++) {
            if (imageTransform.get_Item(index) instanceof IBlur) {
                blurIndex = index;
                break;
            }
        }

        if (blurIndex >= 0) {
            imageTransform.removeAt(blurIndex);
            System.out.println("The blur operation was removed.");
        }

        imageTransform.clear();
        System.out.println("Remaining operations: " + imageTransform.size());
        presentation.save("image-transforms-cleared.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Eliminar o limpiar transformaciones solo afecta al formato de la imagen. No elimina, recomprime ni altera de otro modo el recurso [IPPImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ippimage/) reutilizado.

## **Considerar formatos de presentación y destinos de exportación**

Las transformaciones de imagen se originan en DrawingML, por lo que PPTX es el formato editable preferido para cadenas de efectos. Incluso con PPTX, no todas las operaciones tienen la misma portabilidad:

- Las operaciones estándar de DrawingML como luminancia, escala de grises, duotono, tinte, HSL, desenfoque y operaciones alfa comunes tienen mayor probabilidad de sobrevivir a una ida y vuelta en PPTX. Siempre vuelva a abrir el archivo generado e inspeccione la colección cuando la preservación sea un requisito.
- [BrightnessContrast](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/brightnesscontrast/) es una extensión de Office 2010 y no el estándar de luminancia de DrawingML. Puede usarse para renderizado en memoria, pero no hay garantía de que siga siendo un [IBrightnessContrast](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ibrightnesscontrast/) editable después de guardar y volver a abrir PPTX. Prefiera [addLuminanceEffect](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) para ajustes persistentes de brillo y contraste.
- El formato binario PPT precede al modelo completo de efectos DrawingML. Guardar en PPT puede omitir operaciones no compatibles, reducir una cadena a un subconjunto admitido o aproximar la apariencia. No use PPT como formato de verificación para una cadena editable compleja.
- Renderizar a PNG, JPEG, TIFF, PDF, SVG, HTML u otro output visual aplica la cadena admitida a la apariencia renderizada. esas salidas no contienen una `IImageTransformOperationCollection` editable; los formatos raster aplanan el resultado en píxeles, y las exportaciones de documento/vector almacenan su propia representación de renderizado.
- Los efectos no hacen que una imagen enlazada sea autocontenida. Renderizar una imagen vinculada sigue dependiendo de que el recurso enlazado esté disponible cuando se cargue la presentación.

Diferentes consumidores de presentaciones pueden renderizar casos límite de forma distinta, sobre todo cuando se combinan varias operaciones alfa o de cuantización de color. Para una salida crítica, pruebe tanto la ida y vuelta editable como el formato de exportación final con la misma versión de Aspose.Slides utilizada en producción.

## **Preguntas frecuentes**

**¿Los efectos de transformación de imagen modifican los datos de la imagen incrustada?**

No. Las operaciones pertenecen al `ISlidesPicture` usado por el relleno de imagen. Los bytes subyacentes de `IPPImage` permanecen sin cambios.

**¿Dos marcos de imagen que reutilizan la misma imagen comparten sus efectos?**

No. Reutilizar un `IPPImage` evita datos de imagen duplicados, pero cada marco de imagen normalmente tiene un `ISlidesPicture` y una colección de transformaciones de imagen independientes.

**¿Se pueden combinar efectos de color, desenfoque y alfa?**

Sí. La colección los acepta en una única cadena ordenada. Considere lo que cada operación hace sobre la salida de la anterior, ya que las operaciones de sustitución y umbral pueden descartar color o detalle alfa previo.

**¿Por qué los valores efectivos son de solo lectura?**

Los datos efectivos representan valores calculados usados para el renderizado, incluidos los colores resueltos. Edite la operación almacenada en la colección de transformaciones donde existan miembros grabables; de lo contrario, elimínela y añada una de sustitución con nuevos parámetros de creación.

**¿Qué formato debo usar para preservar una cadena de transformaciones?**

Use PPTX y verifique el archivo volviéndolo a abrir. PPT legacy no puede representar el modelo completo de efectos DrawingML, y los formatos de exportación renderizados conservan la apariencia más que las operaciones de transformación editables.