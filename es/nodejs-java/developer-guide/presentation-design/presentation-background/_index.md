---
title: Administrar fondos de presentación en JavaScript
linktitle: Fondo de diapositiva
type: docs
weight: 20
url: /es/nodejs-java/presentation-background/
keywords:
- fondo de presentación
- fondo de diapositiva
- color sólido
- color degradado
- fondo de imagen
- transparencia del fondo
- propiedades del fondo
- PowerPoint
- OpenDocument
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda a establecer fondos dinámicos en archivos PowerPoint y OpenDocument usando Aspose.Slides para Node.js, con consejos de código para mejorar sus presentaciones."
---

## **Visión general**

Los colores sólidos, los degradados y las imágenes se utilizan comúnmente como fondos de diapositiva. Puede establecer el fondo para una **diapositiva normal** (una sola diapositiva) o una **diapositiva maestra** (se aplica a varias diapositivas a la vez).

![Fondo de PowerPoint](powerpoint-background.png)

## **Establecer un fondo de color sólido para una diapositiva normal**

Aspose.Slides le permite establecer un color sólido como fondo para una diapositiva específica en una presentación, incluso si la presentación utiliza una diapositiva maestra. El cambio se aplica solo a la diapositiva seleccionada.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Establezca el [BackgroundType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/backgroundtype/) de la diapositiva a `OwnBackground`.
3. Establezca el [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) del fondo de la diapositiva a `Solid`.
4. Utilice el método [getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getSolidFillColor--) en [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/) para especificar el color sólido de fondo.
5. Guarde la presentación modificada.

El siguiente ejemplo en JavaScript muestra cómo establecer un color sólido azul como fondo para una diapositiva normal:
```js
// Crear una instancia de la clase Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Establecer el color de fondo de la diapositiva a azul.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    
    // Guardar la presentación en disco.
    presentation.save("SolidColorBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Establecer un fondo de color sólido para la diapositiva maestra**

Aspose.Slides le permite establecer un color sólido como fondo para la diapositiva maestra en una presentación. La diapositiva maestra actúa como una plantilla que controla el formato de todas las diapositivas, por lo que al elegir un color sólido para el fondo de la diapositiva maestra, se aplica a cada diapositiva.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Establezca el [BackgroundType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/backgroundtype/) de la diapositiva maestra (a través de `getMasters`) a `OwnBackground`.
3. Establezca el [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) del fondo de la diapositiva maestra a `Solid`.
4. Utilice el método [getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getSolidFillColor--) para especificar el color sólido de fondo.
5. Guarde la presentación modificada.

El siguiente ejemplo en JavaScript muestra cómo establecer un color sólido (verde) como fondo para una diapositiva maestra:
```js
// Crear una instancia de la clase Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let masterSlide = presentation.getMasters().get_Item(0);

    // Establecer el color de fondo de la diapositiva maestra a Verde Bosque.
    masterSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    masterSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));

    // Guardar la presentación en disco.
    presentation.save("MasterSlideBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Establecer un fondo degradado para una diapositiva**

Un degradado es un efecto gráfico creado por un cambio gradual de color. Cuando se usa como fondo de diapositiva, los degradados pueden hacer que las presentaciones parezcan más artísticas y profesionales. Aspose.Slides le permite establecer un color degradado como fondo para las diapositivas.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Establezca el [BackgroundType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/backgroundtype/) de la diapositiva a `OwnBackground`.
3. Establezca el [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) del fondo de la diapositiva a `Gradient`.
4. Utilice el método [getGradientFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getGradientFormat) en [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/) para configurar sus ajustes de degradado preferidos.
5. Guarde la presentación modificada.

El siguiente ejemplo en JavaScript muestra cómo establecer un color degradado como fondo para una diapositiva:
```js
// Crear una instancia de la clase Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Aplicar un efecto de degradado al fondo.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    slide.getBackground().getFillFormat().getGradientFormat().setTileFlip(aspose.slides.TileFlip.FlipBoth);

    // Guardar la presentación en disco.
    presentation.save("GradientBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Establecer una imagen como fondo de diapositiva**

Además de los rellenos sólidos y degradados, Aspose.Slides le permite usar imágenes como fondos de diapositiva.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Establezca el [BackgroundType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/backgroundtype/) de la diapositiva a `OwnBackground`.
3. Establezca el [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) del fondo de la diapositiva a `Picture`.
4. Cargue la imagen que desea usar como fondo de la diapositiva.
5. Añada la imagen a la colección de imágenes de la presentación.
6. Utilice el método [getPictureFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getPictureFillFormat) en [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/) para asignar la imagen como fondo.
7. Guarde la presentación modificada.

El siguiente ejemplo en JavaScript muestra cómo establecer una imagen como fondo para una diapositiva:
```js
// Crear una instancia de la clase Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Establecer propiedades de la imagen de fondo.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);

    // Cargar la imagen.
    let image = aspose.slides.Images.fromFile("Tulips.jpg");
    // Añadir la imagen a la colección de imágenes de la presentación.
    let ppImage = presentation.getImages().addImage(image);
    image.dispose();

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);
    
    // Guardar la presentación en disco.
    presentation.save("ImageAsBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


El siguiente fragmento de código muestra cómo establecer el tipo de relleno de fondo a una imagen en mosaico y modificar las propiedades de mosaico:
```js
let presentation = new aspose.slides.Presentation();
try {
    let firstSlide = presentation.getSlides().get_Item(0);

    let background = firstSlide.getBackground();

    background.setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    background.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    let newImage = aspose.slides.Images.fromFile("image.png");
    let ppImage = presentation.getImages().addImage(newImage);
    newImage.dispose();

    // Establecer la imagen utilizada para el relleno del fondo.
    let backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // Establecer el modo de relleno de la imagen a Mosaico y ajustar las propiedades del mosaico.
    backPictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    backPictureFillFormat.setTileOffsetX(15.0);
    backPictureFillFormat.setTileOffsetY(15.0);
    backPictureFillFormat.setTileScaleX(46.0);
    backPictureFillFormat.setTileScaleY(87.0);
    backPictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.Center));
    backPictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipY);

    presentation.save("TileBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


{{% alert color="primary" %}}
Lea más: [**Imagen en mosaico como textura**](/slides/es/nodejs-java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Cambiar la transparencia de la imagen de fondo**

Es posible que desee ajustar la transparencia de la imagen de fondo de una diapositiva para que el contenido de la misma destaque. El siguiente código JavaScript le muestra cómo cambiar la transparencia de la imagen de fondo de una diapositiva:
```js
var transparencyValue = 30; // Por ejemplo.

// Obtener la colección de operaciones de transformación de imagen.
var imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

// Buscar un efecto de transparencia de porcentaje fijo existente.
var transparencyOperation = null;
for (let i = 0; i < imageTransform.size(); i++) {
    let operation = imageTransform.get_Item(i);
    if (java.instanceOf(operation, "com.aspose.slides.AlphaModulateFixed")) {
        transparencyOperation = operation;
        break;
    }
}

// Establecer el nuevo valor de transparencia.
if (transparencyOperation == null) {
    imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
} else {
    transparencyOperation.setAmount(100 - transparencyValue);
}
```


## **Obtener el valor del fondo de la diapositiva**

Aspose.Slides proporciona la clase `BackgroundEffectiveData` para recuperar los valores de fondo efectivos de una diapositiva. Esta clase expone el [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/) y el [EffectFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/) efectivos.

Usando el método `getBackground` de la clase [BaseSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/), puede obtener el fondo efectivo de una diapositiva.

El siguiente ejemplo en JavaScript muestra cómo obtener el valor efectivo del fondo de una diapositiva:
```js
// Crear una instancia de la clase Presentation.
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);

    // Obtener el fondo efectivo, teniendo en cuenta la diapositiva maestra, el diseño y el tema.
    let effBackground = slide.getBackground().getEffective();

    if (effBackground.getFillFormat().getFillType() == aspose.slides.FillType.Solid)
        console.log("Fill color:", effBackground.getFillFormat().getSolidFillColor().toString());
    else
        console.log("Fill type:", effBackground.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```


## **Preguntas frecuentes**

**¿Puedo restablecer un fondo personalizado y restaurar el fondo del tema/distribución?**

Sí. Elimine el relleno personalizado de la diapositiva y el fondo volverá a heredarse del [layout](/slides/es/nodejs-java/slide-layout/)/[master](/slides/es/nodejs-java/slide-master/) correspondiente (es decir, del [fondo del tema](/slides/es/nodejs-java/presentation-theme/)).

**¿Qué ocurre con el fondo si cambio el tema de la presentación más adelante?**

Si una diapositiva tiene su propio relleno, permanecerá sin cambios. Si el fondo se hereda del [layout](/slides/es/nodejs-java/slide-layout/)/[master](/slides/es/nodejs-java/slide-master/), se actualizará para coincidir con el [nuevo tema](/slides/es/nodejs-java/presentation-theme/).