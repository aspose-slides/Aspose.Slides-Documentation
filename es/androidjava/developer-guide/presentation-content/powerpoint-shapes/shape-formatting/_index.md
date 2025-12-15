---
title: "Formato de formas de PowerPoint en Android"
linktitle: "Formato de formas"
type: docs
weight: 20
url: /es/androidjava/shape-formatting/
keywords:
- formato de forma
- formato de línea
- formato de estilo de unión
- relleno degradado
- relleno de patrón
- relleno de imagen
- relleno de textura
- relleno de color sólido
- transparencia de forma
- rotar forma
- efecto de bisel 3D
- efecto de rotación 3D
- restablecer formato
- PowerPoint
- presentación
- Android
- Java
- Aspose.Slides
description: "Aprenda cómo formatear formas de PowerPoint en Android usando Aspose.Slides—establezca estilos de relleno, línea y efecto para archivos PPT, PPTX y ODP con precisión y control total."
---

## **Visión general**

En PowerPoint, puede agregar formas a las diapositivas. Dado que las formas están formadas por líneas, puede darles formato modificando o aplicando efectos a sus contornos. Además, puede dar formato a las formas especificando configuraciones que controlan cómo se rellenan sus interiores.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Android via Java proporciona interfaces y métodos que le permiten dar formato a las formas usando las mismas opciones disponibles en PowerPoint.

## **Formato de líneas**

Usando Aspose.Slides, puede especificar un estilo de línea personalizado para una forma. Los pasos siguientes describen el procedimiento:

1. Cree una instancia de la [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) clase.
1. Obtenga una referencia a una diapositiva por su índice.
1. Agregue un [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) a la diapositiva.
1. Establezca el [line style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linestyle/) de la forma.
1. Establezca el ancho de la línea.
1. Establezca el [dash style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linedashstyle/) de la línea.
1. Establezca el color de la línea para la forma.
1. Guarde la presentación modificada como un archivo PPTX.

El siguiente código muestra cómo dar formato a un `AutoShape` de tipo rectángulo:
```java
// Instanciar la clase Presentation que representa un archivo de presentación.
Presentation presentation = new Presentation();
try {
    // Obtener la primera diapositiva.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Agregar una forma automática del tipo Rectángulo.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Establecer el color de relleno para la forma de rectángulo.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // Aplicar formato a las líneas del rectángulo.
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // Establecer el color para la línea del rectángulo.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Guardar el archivo PPTX en disco.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


El resultado:

![The formatted lines in the presentation](formatted-lines.png)

## **Formato de estilos de unión**

Estas son las tres opciones de tipo de unión:

* Round
* Miter
* Bevel

De forma predeterminada, cuando PowerPoint une dos líneas en un ángulo (por ejemplo, en la esquina de una forma), utiliza la configuración **Round**. Sin embargo, si está dibujando una forma con ángulos agudos, puede preferir la opción **Miter**.

![The join style in the presentation](join-style-powerpoint.png)

El siguiente código Java muestra cómo se crearon tres rectángulos (como se muestra en la imagen anterior) usando los ajustes de unión Miter, Bevel y Round:
```java
// Instanciar la clase Presentation que representa un archivo de presentación.
Presentation presentation = new Presentation();
try {
    // Obtener la primera diapositiva.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Agregar tres formas automáticas del tipo Rectangle.
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Establecer el color de relleno para cada forma rectangular.
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // Establecer el ancho de la línea.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // Establecer el color para la línea de cada rectángulo.
    shape1.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape3.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Establecer el estilo de unión.
    shape1.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    shape2.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    shape3.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    // Agregar texto a cada rectángulo.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // Guardar el archivo PPTX en disco.
    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Relleno degradado**

En PowerPoint, el Relleno degradado es una opción de formato que le permite aplicar una transición continua de colores a una forma. Por ejemplo, puede aplicar dos o más colores de modo que uno se desvanezca gradualmente en otro.

A continuación se muestra cómo aplicar un relleno degradado a una forma usando Aspose.Slides:

1. Cree una instancia de la [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) clase.
1. Obtenga una referencia a una diapositiva por su índice.
1. Agregue un [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) a la diapositiva.
1. Establezca el [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) de la forma en `Gradient`.
1. Añada sus dos colores preferidos con posiciones definidas usando los métodos `add` de la colección de paradas de degradado expuesta por la interfaz [IGradientFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/).
1. Guarde la presentación modificada como un archivo PPTX.

El siguiente código Java muestra cómo aplicar un efecto de relleno degradado a una elipse:
```java
// Instanciar la clase Presentation que representa un archivo de presentación.
Presentation presentation = new Presentation();
try {
    // Obtener la primera diapositiva.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Agregar una forma automática del tipo Ellipse.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Aplicar formato de degradado a la elipse.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // Establecer la dirección del degradado.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // Añadir dos puntos de degradado.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // Guardar el archivo PPTX en disco.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


El resultado:

![The ellipse with gradient fill](gradient-fill.png)

## **Relleno de patrón**

En PowerPoint, el Relleno de patrón es una opción de formato que le permite aplicar un diseño de dos colores —como puntos, rayas, cruzados o cuadros— a una forma. Puede elegir colores personalizados para el primer plano y el fondo del patrón.

Aspose.Slides ofrece más de 45 estilos de patrón predefinidos que puede aplicar a las formas para mejorar la apariencia visual de sus presentaciones. Incluso después de seleccionar un patrón predefinido, aún puede especificar los colores exactos que debe usar.

A continuación se explica cómo aplicar un relleno de patrón a una forma usando Aspose.Slides:

1. Cree una instancia de la [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) clase.
1. Obtenga una referencia a una diapositiva por su índice.
1. Agregue un [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) a la diapositiva.
1. Establezca el [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) de la forma en `Pattern`.
1. Elija un estilo de patrón entre las opciones predefinidas.
1. Establezca el [Background Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/patternformat/#getBackColor--) del patrón.
1. Establezca el [Foreground Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/patternformat/#getForeColor--) del patrón.
1. Guarde la presentación modificada como un archivo PPTX.

El siguiente código Java muestra cómo aplicar un relleno de patrón a un rectángulo:
```java
// Instanciar la clase Presentation que representa un archivo de presentación.
Presentation presentation = new Presentation();
try {
    // Obtener la primera diapositiva.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Agregar una forma automática del tipo Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Establecer el tipo de relleno a Pattern.
    shape.getFillFormat().setFillType(FillType.Pattern);

    // Establecer el estilo de patrón.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // Establecer los colores de fondo y de primer plano del patrón.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // Guardar el archivo PPTX en disco.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


El resultado:

![The rectangle with pattern fill](pattern-fill.png)

## **Relleno de imagen**

En PowerPoint, el Relleno de imagen es una opción de formato que le permite insertar una imagen dentro de una forma, usando efectivamente la imagen como fondo de la forma.

A continuación se muestra cómo usar Aspose.Slides para aplicar un relleno de imagen a una forma:

1. Cree una instancia de la [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) clase.
1. Obtenga una referencia a una diapositiva por su índice.
1. Agregue un [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) a la diapositiva.
1. Establezca el [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) de la forma en `Picture`.
1. Establezca el modo de relleno de imagen en `Tile` (u otro modo que prefiera).
1. Cree un objeto [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) a partir de la imagen que desea usar.
1. Pase la imagen al método `ISlidesPicture.setImage`.
1. Guarde la presentación modificada como un archivo PPTX.

Supongamos que tenemos un archivo "lotus.png" con la siguiente imagen:

![The lotus picture](lotus.png)

El siguiente código Java muestra cómo rellenar una forma con la imagen:
```java
// Instanciar la clase Presentation que representa un archivo de presentación.
Presentation presentation = new Presentation();
try {
    // Obtener la primera diapositiva.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Agregar una forma automática del tipo Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Establecer el tipo de relleno a Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Establecer el modo de llenado de imagen.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // Cargar una imagen y agregarla a los recursos de la presentación.
    IImage image = Images.fromFile("lotus.png");
    IPPImage picture = presentation.getImages().addImage(image);
    image.dispose();

    // Establecer la imagen.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Guardar el archivo PPTX en disco.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


El resultado:

![The shape with picture fill](picture-fill.png)

### **Imagen en mosaico como textura**

Si desea establecer una imagen en mosaico como textura y personalizar el comportamiento del mosaico, puede usar los siguientes métodos de la interfaz [IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) y la clase [PictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Establece el modo de relleno de imagen —`Tile` o `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Especifica la alineación de los mosaicos dentro de la forma.
- [setTileFlip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Controla si el mosaico se voltea horizontalmente, verticalmente o en ambas direcciones.
- [setTileOffsetX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Establece el desplazamiento horizontal del mosaico (en puntos) desde el origen de la forma.
- [setTileOffsetY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Establece el desplazamiento vertical del mosaico (en puntos) desde el origen de la forma.
- [setTileScaleX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Define la escala horizontal del mosaico como porcentaje.
- [setTileScaleY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Define la escala vertical del mosaico como porcentaje.

El siguiente ejemplo de código muestra cómo agregar una forma rectangular con un relleno de imagen en mosaico y configurar las opciones del mosaico:
```java
// Instanciar la clase Presentation que representa un archivo de presentación.
Presentation presentation = new Presentation();
try {
    // Obtener la primera diapositiva.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Agregar una forma automática del tipo Rectangle.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Establecer el tipo de relleno de la forma a Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Cargar la imagen y agregarla a los recursos de la presentación.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Asignar la imagen a la forma.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Configurar el modo de relleno de imagen y las propiedades de mosaico.
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    // Guardar el archivo PPTX en disco.
    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


El resultado:

![The tile options](tile-options.png)

## **Relleno de color sólido**

En PowerPoint, el Relleno de color sólido es una opción de formato que llena una forma con un solo color uniforme. Este color de fondo simple se aplica sin degradados, texturas ni patrones.

Para aplicar un relleno de color sólido a una forma usando Aspose.Slides, siga estos pasos:

1. Cree una instancia de la [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) clase.
1. Obtenga una referencia a una diapositiva por su índice.
1. Agregue un [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) a la diapositiva.
1. Establezca el [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) de la forma en `Solid`.
1. Asigne el color de relleno que prefiera a la forma.
1. Guarde la presentación modificada como un archivo PPTX.

El siguiente código Java muestra cómo aplicar un relleno de color sólido a un rectángulo en una diapositiva de PowerPoint:
```java
// Instanciar la clase Presentation que representa un archivo de presentación.
Presentation presentation = new Presentation();
try {
    // Obtener la primera diapositiva.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Agregar una forma automática del tipo Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Establecer el tipo de relleno a Solid.
    shape.getFillFormat().setFillType(FillType.Solid);

    // Establecer el color de relleno.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // Guardar el archivo PPTX en disco.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


El resultado:

![The shape with solid color fill](solid-color-fill.png)

## **Establecer transparencia**

En PowerPoint, cuando aplica un relleno de color sólido, degradado, imagen o textura a las formas, también puede establecer un nivel de transparencia para controlar la opacidad del relleno. Un valor de transparencia mayor hace que la forma sea más translúcida, permitiendo que el fondo o los objetos subyacentes sean parcialmente visibles.

Aspose.Slides le permite establecer el nivel de transparencia ajustando el valor alfa del color usado para el relleno. Así es como se hace:

1. Cree una instancia de la [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) clase.
1. Obtenga una referencia a una diapositiva por su índice.
1. Agregue un [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) a la diapositiva.
1. Establezca el [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) en `Solid`.
1. Use `Color` para definir un color con transparencia (el componente `alpha` controla la transparencia).
1. Guarde la presentación.

El siguiente código Java muestra cómo aplicar un color de relleno transparente a un rectángulo:
```java
// Instanciar la clase Presentation que representa un archivo de presentación.
Presentation presentation = new Presentation();
try {
    // Obtener la primera diapositiva.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Agregar una forma automática de rectángulo sólido.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Agregar una forma automática de rectángulo transparente sobre la forma sólida.
    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 204));

    // Guardar el archivo PPTX en disco.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


El resultado:

![The transparent shape](shape-transparency.png)

## **Rotar formas**

Aspose.Slides le permite rotar formas en presentaciones de PowerPoint. Esto puede ser útil al posicionar elementos visuales con requisitos específicos de alineación o diseño.

Para rotar una forma en una diapositiva, siga estos pasos:

1. Cree una instancia de la [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) clase.
1. Obtenga una referencia a una diapositiva por su índice.
1. Agregue un [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) a la diapositiva.
1. Establezca la propiedad de rotación de la forma al ángulo deseado.
1. Guarde la presentación.

El siguiente código Java muestra cómo rotar una forma 5 grados:
```java
// Instanciar la clase Presentation que representa un archivo de presentación.
Presentation presentation = new Presentation();
try {
    // Obtener la primera diapositiva.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Agregar una forma automática del tipo Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Rotar la forma en 5 grados.
    shape.setRotation(5);

    // Guardar el archivo PPTX en disco.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


El resultado:

![The shape rotation](shape-rotation.png)

## **Agregar efectos de bisel 3D**

Aspose.Slides le permite aplicar efectos de bisel 3D a las formas configurando sus propiedades [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/threedformat/).

Para agregar efectos de bisel 3D a una forma, siga estos pasos:

1. Instancie la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Obtenga una referencia a una diapositiva por su índice.
1. Agregue un [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) a la diapositiva.
1. Configure el [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/threedformat/) de la forma para definir la configuración de bisel.
1. Guarde la presentación.

El siguiente código Java muestra cómo aplicar efectos de bisel 3D a una forma:
```java
// Crear una instancia de la clase Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Agregar una forma a la diapositiva.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE);
    shape.getLineFormat().setWidth(2.0);

    // Establecer las propiedades ThreeDFormat de la forma.
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    // Guardar la presentación como un archivo PPTX.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


El resultado:

![The 3D bevel effect](3D-bevel-effect.png)

## **Agregar efectos de rotación 3D**

Aspose.Slides le permite aplicar efectos de rotación 3D a las formas configurando sus propiedades [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/threedformat/).

Para aplicar rotación 3D a una forma:

1. Cree una instancia de la [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) clase.
1. Obtenga una referencia a una diapositiva por su índice.
1. Agregue un [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) a la diapositiva.
1. Use [setCameraType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setCameraType-int-) y [setLightType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilightrig/#setLightType-int-) para definir la rotación 3D.
1. Guarde la presentación.

El siguiente código Java muestra cómo aplicar efectos de rotación 3D a una forma:
```java
// Crear una instancia de la clase Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    // Guardar la presentación como un archivo PPTX.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


El resultado:

![The 3D rotation effect](3D-rotation-effect.png)

## **Restablecer formato**

El siguiente código Java muestra cómo restablecer el formato de una diapositiva y devolver la posición, el tamaño y el formato de todas las formas con marcadores de posición en el [LayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/layoutslide/) a sus configuraciones predeterminadas:
```java
Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Restablecer cada forma en la diapositiva que tiene un marcador de posición en el diseño.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Preguntas frecuentes**

**¿El formato de la forma afecta al tamaño final del archivo de la presentación?**

Solo de manera mínima. Las imágenes y los medios incrustados ocupan la mayor parte del espacio del archivo, mientras que los parámetros de la forma, como colores, efectos y degradados, se almacenan como metadatos y prácticamente no agregan tamaño extra.

**¿Cómo puedo detectar formas en una diapositiva que compartan el mismo formato para poder agruparlas?**

Compare las propiedades clave de formato de cada forma —relleno, línea y configuraciones de efecto. Si todos los valores correspondientes coinciden, trate sus estilos como idénticos y agrupe lógicamente esas formas, lo que simplifica la gestión de estilos posterior.

**¿Puedo guardar un conjunto de estilos de forma personalizados en un archivo separado para reutilizarlos en otras presentaciones?**

Sí. Guarde formas de muestra con los estilos deseados en una presentación de diapositivas plantilla o en un archivo de plantilla .POTX. Al crear una nueva presentación, abra la plantilla, clone las formas con estilo que necesite y vuelva a aplicar su formato donde sea requerido.