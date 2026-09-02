---
title: Formatear formas de PowerPoint en JavaScript
linktitle: Formateo de formas
type: docs
weight: 20
url: /es/nodejs-java/shape-formatting/
keywords:
- formatear forma
- formatear línea
- efecto de boceto
- línea de forma con boceto
- formatear estilo de unión
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Formatea formas de PowerPoint en JavaScript usando Aspose.Slides—establece estilos de relleno, línea y efecto para archivos PPT, PPTX y ODP con precisión y control total."
---
## **Introducción**

En PowerPoint, puedes añadir formas a las diapositivas. Dado que las formas están compuestas por líneas, puedes darles formato modificando o aplicando efectos a sus contornos. Además, puedes dar formato a las formas especificando ajustes que controlan cómo se rellenan sus interiores.

![Formato de forma en PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Node.js via Java proporciona clases y métodos que permiten dar formato a las formas utilizando las mismas opciones disponibles en PowerPoint.

## **Formato de líneas**

Usando Aspose.Slides, puedes especificar un estilo de línea personalizado para una forma. Los pasos siguientes describen el procedimiento:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/).
1. Obtener una referencia a una diapositiva por su índice.
1. Añadir un [AutoShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/autoshape/) a la diapositiva.
1. Establecer el [line style](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/linestyle/) de la forma.
1. Establecer el ancho de la línea.
1. Establecer el [dash style](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/linedashstyle/) de la línea.
1. Establecer el color de la línea para la forma.
1. Guardar la presentación modificada como un archivo PPTX.

El siguiente código muestra cómo dar formato a un `AutoShape` de tipo rectángulo:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instanciar la clase Presentation que representa un archivo de presentación.
let presentation = new aspose.slides.Presentation();
try {
    // Obtener la primera diapositiva.
    let slide = presentation.getSlides().get_Item(0);

    // Agregar una forma automática del tipo Rectángulo.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 75);

    // Eliminar el relleno de la forma rectangular.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // Aplicar formato a las líneas del rectángulo.
    shape.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.ThickThin));
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));

    // Establecer el color de la línea del rectángulo.
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // Guardar el archivo PPTX en disco.
    presentation.save("formatted_lines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Líneas formateadas en la presentación](formatted-lines.png)

## **Aplicar efectos de boceto a las líneas de la forma**

Un efecto de boceto hace que la línea de una forma parezca dibujada a mano. Usa [Shape.getLineFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shape/) para acceder a la configuración de la línea, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/lineformat/) para acceder a la configuración del boceto y [SketchFormat.setSketchType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sketchformat/) para seleccionar un valor de la enumeración [LineSketchType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/linesketchtype/).

El siguiente código JavaScript muestra cómo aplicar un efecto [LineSketchType.Curved](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/linesketchtype/) , leer el valor asignado explícitamente y eliminar el efecto con [LineSketchType.None](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/linesketchtype/):

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);

    // Acceder al formato de línea de la forma y a su formato de boceto.
    let sketchFormat = shape.getLineFormat().getSketchFormat();

    // Aplicar un efecto de boceto.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.Curved);

    // Leer el efecto de boceto asignado directamente a la forma.
    let explicitSketchType = sketchFormat.getSketchType();
    console.log("Explicit sketch type: " + explicitSketchType);

    // Eliminar el efecto de boceto.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.None);
} finally {
    presentation.dispose();
}
```

El valor devuelto por [SketchFormat.getSketchType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/sketchformat/) representa la configuración asignada directamente a la forma. Si el formato de la línea puede heredarse de un tema, diapositiva maestra o diapositiva de diseño, usa [LineFormat.getEffective](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/lineformat/), llama a `getSketchFormat` sobre el objeto devuelto y luego llama a su método `getSketchType`. El valor efectivo refleja el formato que realmente se aplica tras resolverse la herencia:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    let lineFormat = shape.getLineFormat();

    let explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    let effectiveLineFormat = lineFormat.getEffective();
    let effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    console.log("Explicit sketch type: " + explicitSketchType);
    console.log("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **Formato de estilos de unión**

Estas son las tres opciones de tipo de unión:

* Round
* Miter
* Bevel

Por defecto, cuando PowerPoint une dos líneas en un ángulo (por ejemplo, en la esquina de una forma), utiliza la configuración **Round**. Sin embargo, si dibujas una forma con ángulos agudos, puede que prefieras la opción **Miter**.

![Estilo de unión en la presentación](join-style-powerpoint.png)

El siguiente código JavaScript muestra cómo se crearon tres rectángulos (como se ve en la imagen anterior) utilizando los ajustes de tipo de unión Miter, Bevel y Round:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instanciar la clase Presentation que representa un archivo de presentación.
let presentation = new aspose.slides.Presentation();
try {
    // Obtener la primera diapositiva.
    let slide = presentation.getSlides().get_Item(0);

    // Agregar tres formas automáticas del tipo Rectángulo.
    let shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 75);
    let shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 20, 150, 75);
    let shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 135, 150, 75);

    // Establecer el color de relleno para cada forma rectangular.
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

    // Establecer el ancho de la línea.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // Establecer el color de la línea de cada rectángulo.
    shape1.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape2.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape3.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // Establecer el estilo de unión.
    shape1.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Miter));
    shape2.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Bevel));
    shape3.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Round));

    // Agregar texto a cada rectángulo.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // Guardar el archivo PPTX en disco.
    presentation.save("join_styles.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Relleno de degradado**

En PowerPoint, Relleno de degradado es una opción de formato que permite aplicar una mezcla continua de colores a una forma. Por ejemplo, puedes aplicar dos o más colores de manera que uno se desvanezca gradualmente en otro.

Así es como se aplica un relleno de degradado a una forma usando Aspose.Slides:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/).
1. Obtener una referencia a una diapositiva por su índice.
1. Añadir un [AutoShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/autoshape/) a la diapositiva.
1. Establecer el [FillType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/filltype/) de la forma a `Gradient`.
1. Añadir tus dos colores preferidos con posiciones definidas usando los métodos `add` de la colección de paradas de degradado expuesta por la clase [GradientFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/gradientformat/).
1. Guardar la presentación modificada como un archivo PPTX.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instanciar la clase Presentation que representa un archivo de presentación.
let presentation = new aspose.slides.Presentation();
try {
    // Obtener la primera diapositiva.
    let slide = presentation.getSlides().get_Item(0);

    // Agregar una forma automática del tipo Ellipse.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);

    // Aplicar formato de degradado a la elipse.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));

    // Establecer la dirección del degradado.
    shape.getFillFormat().getGradientFormat().setGradientDirection(aspose.slides.GradientDirection.FromCorner2);

    // Añadir dos paradas de degradado.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, aspose.slides.PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0, aspose.slides.PresetColor.Red);

    // Guardar el archivo PPTX en disco.
    presentation.save("gradient_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Elipse con relleno de degradado](gradient-fill.png)

## **Relleno de patrón**

En PowerPoint, Relleno de patrón es una opción de formato que permite aplicar un diseño bicolor —como puntos, rayas, tramado cruzado o cuadros— a una forma. Puedes elegir colores personalizados para el primer plano y el fondo del patrón.

Aspose.Slides ofrece más de 45 estilos de patrón predefinidos que puedes aplicar a las formas para mejorar el atractivo visual de tus presentaciones. Incluso después de seleccionar un patrón predefinido, puedes especificar los colores exactos que debe usar.

Así es como se aplica un relleno de patrón a una forma usando Aspose.Slides:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/).
1. Obtener una referencia a una diapositiva por su índice.
1. Añadir un [AutoShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/autoshape/) a la diapositiva.
1. Establecer el [FillType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/filltype/) de la forma a `Pattern`.
1. Elegir un estilo de patrón entre las opciones predefinidas.
1. Establecer el [Background Color](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/patternformat/#getBackColor--) del patrón.
1. Establecer el [Foreground Color](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/patternformat/#getForeColor--) del patrón.
1. Guardar la presentación modificada como un archivo PPTX.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instanciar la clase Presentation que representa un archivo de presentación.
let presentation = new aspose.slides.Presentation();
try {
    // Obtener la primera diapositiva.
    let slide = presentation.getSlides().get_Item(0);

    // Añadir una forma automática del tipo Rectángulo.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Establecer el tipo de relleno a Patrón.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));

    // Establecer el estilo del patrón.
    shape.getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.Trellis));

    // Establecer los colores de fondo y de primer plano del patrón.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // Guardar el archivo PPTX en disco.
    presentation.save("pattern_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Rectángulo con relleno de patrón](pattern-fill.png)

## **Relleno de imagen**

En PowerPoint, Relleno de imagen es una opción de formato que permite insertar una imagen dentro de una forma, utilizando efectivamente la imagen como fondo de la forma.

Así es como se utiliza Aspose.Slides para aplicar un relleno de imagen a una forma:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/).
1. Obtener una referencia a una diapositiva por su índice.
1. Añadir un [AutoShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/autoshape/) a la diapositiva.
1. Establecer el [FillType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/filltype/) de la forma a `Picture`.
1. Establecer el modo de relleno de imagen a `Tile` (u otro modo preferido).
1. Crear un objeto [PPImage](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/ppimage/) a partir de la imagen que deseas usar.
1. Pasar la imagen al método `ISlidesPicture.setImage`.
1. Guardar la presentación modificada como un archivo PPTX.

![La imagen del loto](lotus.png)

El siguiente código JavaScript muestra cómo rellenar una forma con la imagen:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instanciar la clase Presentation que representa un archivo de presentación.
let presentation = new aspose.slides.Presentation();
try {
    // Obtener la primera diapositiva.
    let slide = presentation.getSlides().get_Item(0);

    // Añadir una forma automática del tipo Rectángulo.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Establecer el tipo de relleno a Imagen.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // Establecer el modo de relleno de imagen.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Tile);

    // Cargar una imagen y añadirla a los recursos de la presentación.
    let image = aspose.slides.Images.fromFile("lotus.png");
    let picture = presentation.getImages().addImage(image);
    image.dispose();

    // Establecer la imagen.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Guardar el archivo PPTX en disco.
    presentation.save("picture_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Forma con relleno de imagen](picture-fill.png)

### **Imagen de mosaico como textura**

Si deseas establecer una imagen en mosaico como textura y personalizar el comportamiento del mosaico, puedes usar los siguientes métodos de la clase [PictureFillFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): Establece el modo de relleno de imagen—`Tile` o `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): Especifica la alineación de los mosaicos dentro de la forma.
- [setTileFlip](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): Controla si el mosaico se voltea horizontalmente, verticalmente o en ambos sentidos.
- [setTileOffsetX](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): Define el desplazamiento horizontal del mosaico (en puntos) respecto al origen de la forma.
- [setTileOffsetY](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): Define el desplazamiento vertical del mosaico (en puntos) respecto al origen de la forma.
- [setTileScaleX](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): Define la escala horizontal del mosaico como un porcentaje.
- [setTileScaleY](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): Define la escala vertical del mosaico como un porcentaje.

El siguiente ejemplo de código muestra cómo añadir una forma rectangular con un relleno de imagen en mosaico y configurar las opciones de los mosaicos:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instanciar la clase Presentation que representa un archivo de presentación.
let presentation = new aspose.slides.Presentation();
try {
    // Obtener la primera diapositiva.
    let firstSlide = presentation.getSlides().get_Item(0);

    // Añadir una forma automática rectangular.
    let shape = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 190, 95);

    // Establecer el tipo de relleno de la forma a Imagen.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // Cargar la imagen y añadirla a los recursos de la presentación.
    let sourceImage = aspose.slides.Images.fromFile("lotus.png");
    let presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Asignar la imagen a la forma.
    let pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Configurar el modo de relleno de imagen y las propiedades de mosaico.
    pictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.BottomRight));
    pictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipBoth);

    // Guardar el archivo PPTX en disco.
    presentation.save("tile.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Opciones de mosaico](tile-options.png)

## **Relleno de color sólido**

En PowerPoint, Relleno de color sólido es una opción de formato que rellena una forma con un solo color uniforme. Este color de fondo plano se aplica sin degradados, texturas ni patrones.

Para aplicar un relleno de color sólido a una forma usando Aspose.Slides, sigue estos pasos:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/).
1. Obtener una referencia a una diapositiva por su índice.
1. Añadir un [AutoShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/autoshape/) a la diapositiva.
1. Establecer el [FillType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/filltype/) de la forma a `Solid`.
1. Asignar el color de relleno que prefieras a la forma.
1. Guardar la presentación modificada como un archivo PPTX.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instanciar la clase Presentation que representa un archivo de presentación.
let presentation = new aspose.slides.Presentation();
try {
    // Obtener la primera diapositiva.
    let slide = presentation.getSlides().get_Item(0);

    // Añadir una forma automática del tipo Rectángulo.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Establecer el tipo de relleno a Sólido.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));

    // Establecer el color de relleno.
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // Guardar el archivo PPTX en disco.
    presentation.save("solid_color_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Forma con relleno de color sólido](solid-color-fill.png)

## **Establecer transparencia**

En PowerPoint, al aplicar un relleno de color sólido, degradado, imagen o textura a las formas, también puedes establecer un nivel de transparencia para controlar la opacidad del relleno. Un valor de transparencia más alto hace que la forma sea más translúcida, permitiendo que el fondo o los objetos subyacentes sean parcialmente visibles.

Aspose.Slides permite establecer el nivel de transparencia ajustando el valor alfa del color utilizado para el relleno. Así es como se hace:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/).
1. Obtener una referencia a una diapositiva por su índice.
1. Añadir un [AutoShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/autoshape/) a la diapositiva.
1. Establecer el [FillType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/filltype/) a `Solid`.
1. Usar `Color` para definir un color con transparencia (el componente `alpha` controla la transparencia).
1. Guardar la presentación.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instanciar la clase Presentation que representa un archivo de presentación.
let presentation = new aspose.slides.Presentation();
try {
    // Obtener la primera diapositiva.
    let slide = presentation.getSlides().get_Item(0);

    // Añadir una forma automática rectangular sólida.
    let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Añadir una forma automática rectangular transparente sobre la forma sólida.
    let transparentShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    transparentShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 255, 0, 204));

    // Guardar el archivo PPTX en disco.
    presentation.save("shape_transparency.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Forma transparente](shape-transparency.png)

## **Rotar formas**

Aspose.Slides permite rotar formas en presentaciones de PowerPoint. Esto puede ser útil al posicionar elementos visuales con requisitos específicos de alineación o diseño.

Para rotar una forma en una diapositiva, sigue estos pasos:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/).
1. Obtener una referencia a una diapositiva por su índice.
1. Añadir un [AutoShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/autoshape/) a la diapositiva.
1. Establecer la propiedad de rotación de la forma al ángulo deseado.
1. Guardar la presentación.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instanciar la clase Presentation que representa un archivo de presentación.
let presentation = new aspose.slides.Presentation();
try {
    // Obtener la primera diapositiva.
    let slide = presentation.getSlides().get_Item(0);

    // Añadir una forma automática del tipo Rectángulo.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Rotar la forma 5 grados.
    shape.setRotation(5);

    // Guardar el archivo PPTX en disco.
    presentation.save("shape_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Rotación de la forma](shape-rotation.png)

## **Añadir efectos de bisel 3D**

Aspose.Slides permite aplicar efectos de bisel 3D a las formas configurando sus propiedades [ThreeDFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/threedformat/).

Para añadir efectos de bisel 3D a una forma, sigue estos pasos:

1. Instanciar la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/).
1. Obtener una referencia a una diapositiva por su índice.
1. Añadir un [AutoShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/autoshape/) a la diapositiva.
1. Configurar el [ThreeDFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/threedformat/) de la forma para definir los ajustes de bisel.
1. Guardar la presentación.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Crear una instancia de la clase Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Añadir una forma a la diapositiva.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    shape.getLineFormat().setWidth(2.0);

    // Establecer las propiedades ThreeDFormat de la forma.
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);

    // Guardar la presentación como archivo PPTX.
    presentation.save("3D_bevel_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Efecto de bisel 3D](3D-bevel-effect.png)

## **Añadir efectos de rotación 3D**

Aspose.Slides permite aplicar efectos de rotación 3D a las formas configurando sus propiedades [ThreeDFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/threedformat/).

Para aplicar rotación 3D a una forma:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/).
1. Obtener una referencia a una diapositiva por su índice.
1. Añadir un [AutoShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/autoshape/) a la diapositiva.
1. Usar [setCameraType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/camera/#setCameraType) y [setLightType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/lightrig/#setLightType) para definir la rotación 3D.
1. Guardar la presentación.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Crear una instancia de la clase Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);

    // Guardar la presentación como archivo PPTX.
    presentation.save("3D_rotation_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Efecto de rotación 3D](3D-rotation-effect.png)

## **Controlar el renderizado en blanco y negro de las formas**

El método [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) especifica cómo se representa una forma individual cuando una presentación se visualiza o procesa en modo blanco y negro. No habilita la visualización en blanco y negro por sí mismo, y no cambia el relleno, la línea u otro formato de la forma en modo de color normal.

Utiliza un valor de la enumeración [BlackWhiteMode](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/blackwhitemode/) para seleccionar el comportamiento deseado. Por ejemplo, `Automatic` permite que la aplicación de renderizado elija la conversión, `Gray` y `LightGray` usan color gris, `BlackWhite` usa solo negro y blanco, `Black` y `White` obligan a un color único, `Color` preserva el color normal, y `Hidden` omite la forma en modo blanco y negro. `NotDefined` indica que no se ha asignado ningún modo a nivel de forma.

El siguiente código JavaScript crea una forma con color y hace que aparezca gris en modo de visualización en blanco y negro:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));

    // Mantener el relleno naranja en modo color, pero renderizar la forma con color gris en modo blanco y negro.
    shape.setBlackWhiteMode(java.newByte(aspose.slides.BlackWhiteMode.Gray));

    presentation.save("shape_black_white_mode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

En modo de color normal, el rectángulo conserva su relleno naranja. En un flujo de trabajo de visualización en blanco y negro, utiliza color gris porque su modo está configurado a `Gray`. Esto permite conservar una diapositiva a todo color mientras defines una apariencia distinta para impresión, vista previa u otros flujos que respeten la configuración de visualización en blanco y negro de la presentación.

## **Restablecer formato**

El siguiente código JavaScript muestra cómo restablecer el formato de una diapositiva y devolver la posición, el tamaño y el formato de todas las formas con marcadores de posición en el [LayoutSlide](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/layoutslide/) a sus valores predeterminados:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        // Restablecer cada forma en la diapositiva que tiene un marcador de posición en el diseño.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Preguntas frecuentes**

**¿Afecta el formato de las formas al tamaño final del archivo de la presentación?**

Solo de forma mínima. Las imágenes y medios incrustados ocupan la mayor parte del espacio del archivo, mientras que los parámetros de las formas, como colores, efectos y degradados, se almacenan como metadatos y prácticamente no añaden tamaño extra.

**¿Cómo puedo detectar formas en una diapositiva que compartan el mismo formato para poder agruparlas?**

Compara las propiedades de formato clave de cada forma —relleno, línea y ajustes de efecto. Si todos los valores correspondientes coinciden, considera sus estilos como idénticos y agrupa lógicamente esas formas, lo que simplifica la gestión de estilos posterior.

**¿Puedo guardar un conjunto de estilos de forma personalizados en un archivo separado para reutilizarlos en otras presentaciones?**

Sí. Guarda formas de muestra con los estilos deseados en una presentación de plantilla o en un archivo de plantilla .POTX. Al crear una nueva presentación, abre la plantilla, clona las formas con estilo que necesites y vuelve a aplicar su formato donde sea necesario.