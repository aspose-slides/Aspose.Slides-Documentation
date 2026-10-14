---
title: Formato de formas de PowerPoint en Android
linktitle: Formato de forma
type: docs
weight: 20
url: /es/androidjava/shape-formatting/
keywords:
- formato de forma
- formato de línea
- efecto de bosquejo
- línea de forma de bosquejo
- formato de estilo de unión
- relleno degradado
- relleno de patrón
- relleno de imagen
- relleno de textura
- relleno de color sólido
- transparencia de forma
- renderizado de forma en blanco y negro
- renderizado de forma en escala de grises
- rotar forma
- efecto de bisel 3D
- efecto de rotación 3D
- restablecer formato
- PowerPoint
- presentación
- Android
- Java
- Aspose.Slides
description: "Aprenda a dar formato a las formas de PowerPoint en Android con Aspose.Slides—establezca estilos de relleno, línea y efecto para archivos PPT, PPTX y ODP con precisión y control total."
---
## **Introducción**

En PowerPoint, puedes añadir formas a las diapositivas. Dado que las formas están compuestas por líneas, puedes darles formato modificando o aplicando efectos a sus contornos. Además, puedes dar formato a las formas especificando ajustes que controlan cómo se rellenan sus interiores.

![Formato de forma en PowerPoint](format-shape-powerpoint.png)

Aspose.Slides para Android mediante Java proporciona interfaces y métodos que permiten dar formato a las formas utilizando las mismas opciones disponibles en PowerPoint.

## **Formato de líneas**

Con Aspose.Slides, puedes especificar un estilo de línea personalizado para una forma. Los siguientes pasos describen el procedimiento:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Obtener una referencia a una diapositiva por su índice.
1. Agregar un [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) a la diapositiva.
1. Establecer el [estilo de línea](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linestyle/) de la forma.
1. Establecer el ancho de la línea.
1. Establecer el [estilo de guión](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linedashstyle/) de la línea.
1. Establecer el color de la línea para la forma.
1. Guardar la presentación modificada como un archivo PPTX.

El siguiente código muestra cómo dar formato a un `AutoShape` rectangular:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instanciar la clase Presentation que representa un archivo de presentación.
Presentation presentation = new Presentation();
try {
    // Obtener la primera diapositiva.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Añadir una forma automática del tipo Rectángulo.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Eliminar el relleno de la forma rectángulo para que solo sus líneas sean visibles.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // Aplicar formato a las líneas del rectángulo.
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // Establecer el color de la línea del rectángulo.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Guardar el archivo PPTX en disco.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![Las líneas formateadas en la presentación](formatted-lines.png)

## **Aplicar efectos de boceto a las líneas de la forma**

Un efecto de boceto hace que la línea de una forma parezca dibujada a mano. Utiliza [IShape.getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) para acceder a la configuración de la línea, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/) para acceder a la configuración del boceto y [ISketchFormat.setSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/) para seleccionar un valor de la enumeración [LineSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/).

El siguiente código Java muestra cómo aplicar un efecto [LineSketchType.Curved](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/) , leer el valor asignado explícitamente y eliminar el efecto con [LineSketchType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // Acceder al formato de línea de la forma y a su formato de boceto.
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // Aplicar un efecto de boceto.
    sketchFormat.setSketchType(LineSketchType.Curved);

    // Leer el efecto de boceto asignado directamente a la forma.
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // Eliminar el efecto de boceto.
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

El valor devuelto por [ISketchFormat.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/) representa la configuración asignada directamente a la forma. Si el formato de la línea puede heredarse de un tema, diapositiva maestra o diapositiva de diseño, utiliza [ILineFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/), accede a [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformateffectivedata/), y lee [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformateffectivedata/). El valor efectivo refleja el formato que realmente se aplica después de resolver la herencia:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    ILineFormat lineFormat = shape.getLineFormat();

    int explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    ILineFormatEffectiveData effectiveLineFormat = lineFormat.getEffective();
    int effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    System.out.println("Explicit sketch type: " + explicitSketchType);
    System.out.println("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **Formato de estilos de unión**

Estas son las tres opciones de tipo de unión:

* Round
* Miter
* Bevel

Por defecto, cuando PowerPoint une dos líneas en un ángulo (como en la esquina de una forma), utiliza la configuración **Round**. Sin embargo, si estás dibujando una forma con ángulos agudos, puede que prefieras la opción **Miter**.

![El estilo de unión en la presentación](join-style-powerpoint.png)

El siguiente código Java muestra cómo se crearon tres rectángulos (como se muestra en la imagen anterior) utilizando los ajustes de tipo de unión Mert, Bevel y Round:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instanciar la clase Presentation que representa un archivo de presentación.
Presentation presentation = new Presentation();
try {
    // Obtener la primera diapositiva.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Añadir tres formas automáticas del tipo Rectángulo.
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Establecer el color de relleno para cada forma rectángulo.
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

    // Establecer el color de la línea de cada rectángulo.
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

    // Añadir texto a cada rectángulo.
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

En PowerPoint, el Gradient Fill es una opción de formato que permite aplicar una mezcla continua de colores a una forma. Por ejemplo, puedes aplicar dos o más colores de modo que uno se funda gradualmente en otro.

Así es como se aplica un relleno degradado a una forma utilizando Aspose.Slides:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Obtener una referencia a una diapositiva por su índice.
1. Agregar un [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) a la diapositiva.
1. Establecer el [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) de la forma a `Gradient`.
1. Añadir tus dos colores preferidos con posiciones definidas usando los métodos `add` de la colección de paradas de degradado expuesta por la interfaz [IGradientFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/).
1. Guardar la presentación modificada como un archivo PPTX.

```java
import com.aspose.slides.*;

// Instanciar la clase Presentation que representa un archivo de presentación.
Presentation presentation = new Presentation();
try {
    // Obtener la primera diapositiva.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Añadir una forma automática del tipo Elipse.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Aplicar formato de degradado a la elipse.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // Establecer la dirección del degradado.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // Añadir dos paradas de degradado.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // Guardar el archivo PPTX en disco.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![La elipse con relleno degradado](gradient-fill.png)

Si un degradado se ve diferente en una imagen exportada que en PowerPoint, consulta [Choose a Gradient Rendering Style](/slides/es/androidjava/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Puedes seleccionar un estilo de renderizado sin cambiar el relleno degradado almacenado en la presentación.

## **Relleno de patrón**

En PowerPoint, el Pattern Fill es una opción de formato que permite aplicar un diseño de dos colores —como puntos, rayas, tramas o cuadros— a una forma. Puedes elegir colores personalizados para el primer plano y el fondo del patrón.

Aspose.Slides ofrece más de 45 estilos de patrón predefinidos que puedes aplicar a las formas para mejorar el atractivo visual de tus presentaciones. Incluso después de seleccionar un patrón predefinido, puedes especificar los colores exactos que debe usar.

Así es como se aplica un relleno de patrón a una forma utilizando Aspose.Slides:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Obtener una referencia a una diapositiva por su índice.
1. Agregar un [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) a la diapositiva.
1. Establecer el [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) de la forma a `Pattern`.
1. Elegir un estilo de patrón de las opciones predefinidas.
1. Establecer el [Color de fondo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/patternformat/#getBackColor--) del patrón.
1. Establecer el [Color de primer plano](https://reference.aspose.com/slides/androidjava/com.aspose.slides/patternformat/#getForeColor--) del patrón.
1. Guardar la presentación modificada como un archivo PPTX.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instanciar la clase Presentation que representa un archivo de presentación.
Presentation presentation = new Presentation();
try {
    // Obtener la primera diapositiva.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Añadir una forma automática del tipo Rectángulo.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Establecer el tipo de relleno a Patrón.
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

![El rectángulo con relleno de patrón](pattern-fill.png)

## **Relleno de imagen**

En PowerPoint, el Picture Fill es una opción de formato que permite insertar una imagen dentro de una forma, utilizándola efectivamente como fondo de la forma.

Así es como se utiliza Aspose.Slides para aplicar un relleno de imagen a una forma:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Obtener una referencia a una diapositiva por su índice.
1. Agregar un [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) a la diapositiva.
1. Establecer el [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) de la forma a `Picture`.
1. Establecer el modo de relleno de imagen a `Tile` (u otro modo preferido).
1. Crear un objeto [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) a partir de la imagen que deseas usar.
1. Pasar la imagen al método `ISlidesPicture.setImage`.

Supongamos que tenemos un archivo "lotus.png" con la siguiente imagen:

![La imagen del loto](lotus.png)

```java
import com.aspose.slides.*;

// Instanciar la clase Presentation que representa un archivo de presentación.
Presentation presentation = new Presentation();
try {
    // Obtener la primera diapositiva.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Añadir una forma automática del tipo Rectángulo.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Establecer el tipo de relleno a Imagen.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Establecer el modo de relleno de imagen.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // Cargar una imagen y añadirla a los recursos de la presentación.
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

![La forma con relleno de imagen](picture-fill.png)

### **Imagen en mosaico como textura**

Si deseas establecer una imagen en mosaico como textura y personalizar el comportamiento del mosaico, puedes usar los siguientes métodos de la interfaz [IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) y la clase [PictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Establece el modo de relleno de imagen —`Tile` o `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Especifica la alineación de los mosaicos dentro de la forma.
- [setTileFlip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Controla si el mosaico se voltea horizontalmente, verticalmente o en ambos ejes.
- [setTileOffsetX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Establece el desplazamiento horizontal del mosaico (en puntos) desde el origen de la forma.
- [setTileOffsetY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Establece el desplazamiento vertical del mosaico (en puntos) desde el origen de la forma.
- [setTileScaleX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Define la escala horizontal del mosaico como un porcentaje.
- [setTileScaleY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Define la escala vertical del mosaico como un porcentaje.

El siguiente ejemplo de código muestra cómo agregar una forma rectangular con un relleno de imagen en mosaico y configurar las opciones de mosaico:

```java
import com.aspose.slides.*;

// Instanciar la clase Presentation que representa un archivo de presentación.
Presentation presentation = new Presentation();
try {
    // Obtener la primera diapositiva.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Añadir una forma automática rectangular.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Establecer el tipo de relleno de la forma a Imagen.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Cargar la imagen y añadirla a los recursos de la presentación.
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

![Las opciones de mosaico](tile-options.png)

## **Relleno de color sólido**

En PowerPoint, el Solid Color Fill es una opción de formato que rellena una forma con un único color uniforme. Este fondo liso se aplica sin degradados, texturas o patrones.

Para aplicar un relleno de color sólido a una forma usando Aspose.Slides, sigue estos pasos:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Obtener una referencia a una diapositiva por su índice.
1. Agregar un [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) a la diapositiva.
1. Establecer el [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) de la forma a `Solid`.
1. Asignar el color de relleno que prefieras a la forma.
1. Guardar la presentación modificada como un archivo PPTX.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instanciar la clase Presentation que representa un archivo de presentación.
Presentation presentation = new Presentation();
try {
    // Obtener la primera diapositiva.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Añadir una forma automática del tipo Rectángulo.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Establecer el tipo de relleno a Sólido.
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

![La forma con relleno de color sólido](solid-color-fill.png)

## **Establecer transparencia**

En PowerPoint, cuando aplicas un relleno de color sólido, degradado, imagen o textura a las formas, también puedes establecer un nivel de transparencia para controlar la opacidad del relleno. Un valor de transparencia más alto hace que la forma sea más translúcida, permitiendo que el fondo o los objetos subyacentes sean parcialmente visibles.

Aspose.Slides permite establecer el nivel de transparencia ajustando el valor alfa del color usado para el relleno. Así es como se hace:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Obtener una referencia a una diapositiva por su índice.
1. Agregar un [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) a la diapositiva.
1. Establecer el [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) a `Solid`.
1. Utilizar `Color` para definir un color con transparencia (el componente `alpha` controla la transparencia).
1. Guardar la presentación.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instanciar la clase Presentation que representa un archivo de presentación.
Presentation presentation = new Presentation();
try {
    // Obtener la primera diapositiva.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Añadir una forma automática rectangular sólida.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Añadir una forma automática rectangular transparente sobre la forma sólida.
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

![La forma transparente](shape-transparency.png)

## **Rotar formas**

Aspose.Slides permite rotar formas en presentaciones de PowerPoint. Esto puede ser útil al posicionar elementos visuales con requisitos específicos de alineación o diseño.

Para rotar una forma en una diapositiva, sigue estos pasos:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Obtener una referencia a una diapositiva por su índice.
1. Agregar un [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) a la diapositiva.
1. Establecer la propiedad de rotación de la forma al ángulo deseado.
1. Guardar la presentación.

```java
import com.aspose.slides.*;

// Instanciar la clase Presentation que representa un archivo de presentación.
Presentation presentation = new Presentation();
try {
    // Obtener la primera diapositiva.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Añadir una forma automática del tipo Rectángulo.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Rotar la forma 5 grados.
    shape.setRotation(5);

    // Guardar el archivo PPTX en disco.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![La rotación de la forma](shape-rotation.png)

## **Agregar efectos de bisel 3D**

Aspose.Slides permite aplicar efectos de bisel 3D a las formas configurando sus propiedades [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/threedformat/).

Para añadir efectos de bisel 3D a una forma, sigue estos pasos:

1. Instanciar la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Obtener una referencia a una diapositiva por su índice.
1. Agregar un [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) a la diapositiva.
1. Configurar el [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/threedformat/) de la forma para definir los ajustes de bisel.
1. Guardar la presentación.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Crear una instancia de la clase Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Añadir una forma a la diapositiva.
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

    // Guardar la presentación como archivo PPTX.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![El efecto de bisel 3D](3D-bevel-effect.png)

## **Agregar efectos de rotación 3D**

Aspose.Slides permite aplicar efectos de rotación 3D a las formas configurando sus propiedades [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/threedformat/).

Para aplicar rotación 3D a una forma:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Obtener una referencia a una diapositiva por su índice.
1. Agregar un [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) a la diapositiva.
1. Utilizar [setCameraType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setCameraType-int-) y [setLightType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilightrig/#setLightType-int-) para definir la rotación 3D.
1. Guardar la presentación.

```java
import com.aspose.slides.*;

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

    // Guardar la presentación como archivo PPTX.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![El efecto de rotación 3D](3D-rotation-effect.png)

## **Controlar el renderizado en blanco y negro de las formas**

El método [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) especifica cómo se representa una forma individual cuando una presentación se visualiza o procesa en modo blanco y negro. No habilita la visualización en blanco y negro por sí mismo, y no cambia el relleno, la línea ni otro formato de la forma en modo de color normal.

Utiliza un valor de la clase [BlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/blackwhitemode/) para seleccionar el comportamiento deseado. Por ejemplo, `Automatic` permite que la aplicación de renderizado elija la conversión, `Gray` y `LightGray` usan coloreado gris, `BlackWhite` usa solo negro y blanco, `Black` y `White` fuerzan un único color, `Color` preserva el coloreado normal, y `Hidden` omite la forma en modo blanco y negro. `NotDefined` indica que no se ha asignado un modo a nivel de forma.

El siguiente código Java crea una forma coloreada y hace que aparezca gris en el modo de visualización en blanco y negro:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    // Mantener el relleno naranja en modo color, pero representar la forma con coloración gris en modo blanco y negro.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

En modo de color normal, el rectángulo conserva su relleno naranja. En un flujo de trabajo de visualización en blanco y negro, utiliza el coloreado gris porque su modo está configurado a `Gray`. Esto permite conservar una diapositiva a color completo mientras se define una apariencia distinta para impresión, vista previa u otros flujos que respeten la configuración de visualización en blanco y negro de la presentación.

## **Restablecer formato**

El siguiente código Java muestra cómo restablecer el formato de una diapositiva y revertir la posición, tamaño y formato de todas las formas con marcadores de posición en el [LayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/layoutslide/) a sus valores predeterminados:

```java
import com.aspose.slides.*;

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

## **FAQ**

**¿Afecta el formato de las formas al tamaño final del archivo de la presentación?**

Solo de forma mínima. Las imágenes y los medios incrustados ocupan la mayor parte del espacio del archivo, mientras que los parámetros de las formas, como colores, efectos y degradados, se almacenan como metadatos y prácticamente no añaden tamaño adicional.

**¿Cómo puedo detectar formas en una diapositiva que compartan el mismo formato para poder agruparlas?**

Compara las propiedades clave de formato de cada forma —ajustes de relleno, línea y efecto. Si todos los valores correspondientes coinciden, trata sus estilos como idénticos y agrupa lógicamente esas formas, lo que simplifica la gestión de estilos posteriores.

**¿Puedo guardar un conjunto de estilos de forma personalizados en un archivo separado para reutilizarlos en otras presentaciones?**

Sí. Almacena formas de muestra con los estilos deseados en una presentación de plantilla o en un archivo de plantilla .POTX. Al crear una nueva presentación, abre la plantilla, clona las formas con estilo que necesites y vuelve a aplicar su formato donde sea necesario.