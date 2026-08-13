---
title: Gestionar fondos de presentación en Android
linktitle: Fondo de diapositiva
type: docs
weight: 20
url: /es/androidjava/presentation-background/
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
- Android
- Java
- Aspose.Slides
description: "Aprenda a establecer fondos dinámicos en archivos PowerPoint y OpenDocument usando Aspose.Slides para Android a través de Java, con consejos de código para mejorar sus presentaciones."
---
## **Introducción**

Los colores sólidos, los degradados y las imágenes se utilizan habitualmente como fondos de diapositivas. Puedes establecer el fondo para una **diapositiva normal** (una sola diapositiva) o una **diapositiva maestra** (se aplica a varias diapositivas a la vez).

![Fondo de PowerPoint](powerpoint-background.png)

## **Establecer un fondo de color sólido para una diapositiva normal**

Aspose.Slides le permite establecer un color sólido como fondo para una diapositiva concreta en una presentación, incluso si la presentación utiliza una diapositiva maestra. El cambio se aplica solo a la diapositiva seleccionada.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/).
2. Establezca el [BackgroundType](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/backgroundtype/) de la diapositiva a `OwnBackground`.
3. Establezca el [FillType](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/filltype/) del fondo de la diapositiva a `Solid`.
4. Utilice el método [getSolidFillColor](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) en [FillFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/fillformat/) para especificar el color sólido del fondo.
5. Guarde la presentación modificada.

El siguiente ejemplo en Java muestra cómo establecer un color sólido azul como fondo de una diapositiva normal:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Crear una instancia de la clase Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Establecer el color de fondo de la diapositiva a azul.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    // Guardar la presentación en el disco.
    presentation.save("SolidColorBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Establecer un fondo de color sólido para una diapositiva maestra**

Aspose.Slides le permite establecer un color sólido como fondo para la diapositiva maestra en una presentación. La diapositiva maestra actúa como una plantilla que controla el formato de todas las diapositivas, por lo que al elegir un color sólido para el fondo de la diapositiva maestra, se aplica a cada diapositiva.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/).
2. Establezca el [BackgroundType](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/backgroundtype/) de la diapositiva maestra (mediante `getMasters`) a `OwnBackground`.
3. Establezca el [FillType](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/filltype/) del fondo de la diapositiva maestra a `Solid`.
4. Utilice el método [getSolidFillColor](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) para especificar el color sólido del fondo.
5. Guarde la presentación modificada.

El siguiente ejemplo en Java muestra cómo establecer un color sólido (verde) como fondo de una diapositiva maestra:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Crear una instancia de la clase Presentation.
Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

    // Establecer el color de fondo de la diapositiva maestra a verde.
    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

    // Guardar la presentación en el disco.
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Establecer un fondo degradado para una diapositiva**

Un degradado es un efecto gráfico creado por un cambio gradual de color. Cuando se utiliza como fondo de diapositiva, los degradados pueden hacer que las presentaciones se vean más artísticas y profesionales. Aspose.Slides le permite establecer un color degradado como fondo de las diapositivas.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/).
2. Establezca el [BackgroundType](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/backgroundtype/) de la diapositiva a `OwnBackground`.
3. Establezca el [FillType](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/filltype/) del fondo de la diapositiva a `Gradient`.
4. Utilice el método [getGradientFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/fillformat/#getGradientFormat--) en [FillFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/fillformat/) para configurar los ajustes de degradado deseados.
5. Guarde la presentación modificada.

El siguiente ejemplo en Java muestra cómo establecer un color degradado como fondo de una diapositiva:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Crear una instancia de la clase Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    // Aplicar un efecto de degradado al fondo.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient);

    IGradientFormat gradientFormat = slide.getBackground().getFillFormat().getGradientFormat();
    gradientFormat.setTileFlip(TileFlip.FlipBoth);

    // Añadir los colores del degradado. Sin paradas de degradado, el fondo vuelve a una rampa predeterminada de negro a blanco.
    gradientFormat.getGradientStops().add(0f, Color.CYAN);
    gradientFormat.getGradientStops().add(1f, Color.BLUE);

    // Guardar la presentación en el disco.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Establecer una imagen como fondo de diapositiva**

Además de los rellenos sólidos y degradados, Aspose.Slides le permite usar imágenes como fondos de diapositiva.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/).
2. Establezca el [BackgroundType](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/backgroundtype/) de la diapositiva a `OwnBackground`.
3. Establezca el [FillType](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/filltype/) del fondo de la diapositiva a `Picture`.
4. Cargue la imagen que desea usar como fondo de la diapositiva.
5. Añada la imagen a la colección de imágenes de la presentación.
6. Utilice el método [getPictureFillFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/fillformat/#getPictureFillFormat--) en [FillFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/fillformat/) para asignar la imagen como fondo.
7. Guarde la presentación modificada.

El siguiente ejemplo en Java muestra cómo establecer una imagen como fondo de una diapositiva:

```java
import com.aspose.slides.*;

// Crear una instancia de la clase Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Establecer las propiedades de la imagen de fondo.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Picture);
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    
    // Cargar la imagen.
    IImage image = Images.fromFile("Tulips.jpg");
    // Añadir la imagen a la colección de imágenes de la presentación.
    IPPImage ppImage = presentation.getImages().addImage(image);
    image.dispose();

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);
    
    // Guardar la presentación en el disco.
    presentation.save("ImageAsBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El siguiente fragmento de código muestra cómo establecer el tipo de relleno de fondo a una imagen en mosaico y modificar sus propiedades de mosaico:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IBackground background = firstSlide.getBackground();

    background.setType(BackgroundType.OwnBackground);
    background.getFillFormat().setFillType(FillType.Picture);

    IImage newImage = Images.fromFile("image.png");
    IPPImage ppImage = presentation.getImages().addImage(newImage);
    newImage.dispose();

    // Establecer la imagen utilizada para el relleno del fondo.
    IPictureFillFormat backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // Establecer el modo de relleno de imagen a Mosaico y ajustar las propiedades del mosaico.
    backPictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    backPictureFillFormat.setTileOffsetX(15f);
    backPictureFillFormat.setTileOffsetY(15f);
    backPictureFillFormat.setTileScaleX(46f);
    backPictureFillFormat.setTileScaleY(87f);
    backPictureFillFormat.setTileAlignment(RectangleAlignment.Center);
    backPictureFillFormat.setTileFlip(TileFlip.FlipY);

    presentation.save("TileBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" %}}
Lea más: [**Imagen en mosaico como textura**](/slides/es/androidjava/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Cambiar la transparencia de la imagen de fondo**

Puede que desee ajustar la transparencia de la imagen de fondo de una diapositiva para que el contenido de la diapositiva destaque. El siguiente código Java le muestra cómo cambiar la transparencia de la imagen de fondo de una diapositiva:

```java
import com.aspose.slides.*;

int transparencyValue = 30; // Por ejemplo.

Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Obtener la colección de operaciones de transformación de imagen.
    IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

    // Buscar un efecto de transparencia de porcentaje fijo existente.
    IAlphaModulateFixed transparencyOperation = null;
    for (IImageTransformOperation operation : imageTransform) {
        if (operation instanceof IAlphaModulateFixed) {
            transparencyOperation = (IAlphaModulateFixed)operation;
            break;
        }
    }

    // Establecer el nuevo valor de transparencia.
    if (transparencyOperation == null) {
        imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
    }
    else {
        transparencyOperation.setAmount(100 - transparencyValue);
    }

    presentation.save("TransparentBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Obtener el valor del fondo de la diapositiva**

Aspose.Slides proporciona la interfaz [IBackgroundEffectiveData](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ibackgroundeffectivedata/) para obtener los valores efectivos del fondo de una diapositiva. Esta interfaz expone el [FillFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) y el [EffectFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--) efectivos.

Utilizando el método `getBackground` de la clase [BaseSlide](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/baseslide/), puede obtener el fondo efectivo de una diapositiva.

El siguiente ejemplo en Java muestra cómo obtener el valor efectivo del fondo de una diapositiva:

```java
import com.aspose.slides.*;

// Crear una instancia de la clase Presentation.
Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Obtener el fondo efectivo, teniendo en cuenta la maestra, la disposición y el tema.
    IBackgroundEffectiveData effBackground = slide.getBackground().getEffective();
    
    if (effBackground.getFillFormat().getFillType() == FillType.Solid)
        System.out.println("Fill color: " + effBackground.getFillFormat().getSolidFillColor());
    else
        System.out.println("Fill type: " + effBackground.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

## **FAQ**

### ¿Puedo restablecer un fondo personalizado y restaurar el fondo del tema/disposición?

Sí. Elimine el relleno personalizado de la diapositiva y el fondo volverá a heredarse del [layout](/slides/es/androidjava/slide-layout/)/[master](/slides/es/androidjava/slide-master/) correspondiente (es decir, del [tema de fondo](/slides/es/androidjava/presentation-theme/)).

### ¿Qué ocurre con el fondo si cambio el tema de la presentación más adelante?

Si una diapositiva tiene su propio relleno, permanecerá sin cambios. Si el fondo se hereda del [layout](/slides/es/androidjava/slide-layout/)/[master](/slides/es/androidjava/slide-master/), se actualizará para coincidir con el [nuevo tema](/slides/es/androidjava/presentation-theme/).