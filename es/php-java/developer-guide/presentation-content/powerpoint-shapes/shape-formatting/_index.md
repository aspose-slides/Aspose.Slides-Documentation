---
title: Formatear formas de PowerPoint en PHP
linktitle: Formato de formas
type: docs
weight: 20
url: /es/php-java/shape-formatting/
keywords:
- formato de forma
- formato de línea
- efecto de boceto
- línea de forma boceto
- formato de estilo de unión
- relleno degradado
- relleno de patrón
- relleno de imagen
- relleno de textura
- relleno de color sólido
- transparencia de forma
- representación de forma en blanco y negro
- representación de forma en escala de grises
- rotar forma
- efecto de bisel 3D
- efecto de rotación 3D
- restablecer formato
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Aprende a formatear formas de PowerPoint en PHP usando Aspose.Slides—establece estilos de relleno, línea y efecto para archivos PPT, PPTX y ODP con precisión y control total."
---
## **Introducción**

En PowerPoint, puedes añadir formas a las diapositivas. Dado que las formas están compuestas por líneas, puedes darles formato modificando o aplicando efectos a sus contornos. Además, puedes dar formato a las formas especificando ajustes que controlan cómo se rellenan sus interiores.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides para PHP a través de Java proporciona clases y métodos que permiten dar formato a las formas usando las mismas opciones disponibles en PowerPoint.

## **Formato de líneas**

Usando Aspose.Slides, puedes especificar un estilo de línea personalizado para una forma. Los siguientes pasos describen el procedimiento:

1. Crear una instancia de la clase [Presentación](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Obtener una referencia a una diapositiva por su índice.
1. Añadir un [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) a la diapositiva.
1. Establecer el [estilo de línea](https://reference.aspose.com/slides/php-java/aspose.slides/linestyle/) de la forma.
1. Establecer el ancho de la línea.
1. Establecer el [estilo de guion](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/) de la línea.
1. Establecer el color de la línea para la forma.
1. Guardar la presentación modificada como archivo PPTX.

El siguiente código PHP muestra cómo dar formato a un `AutoShape` rectangular:

```php
// Instanciar la clase Presentation que representa un archivo de presentación.
$presentation = new Presentation();
try {
    // Obtener la primera diapositiva.
    $slide = $presentation->getSlides()->get_Item(0);

    // Añadir una autoforma del tipo Rectángulo.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

    // Establecer el color de relleno para la forma rectangular.
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    // Aplicar formato a las líneas del rectángulo.
    $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
    $shape->getLineFormat()->setWidth(7);
    $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);

    // Establecer el color para la línea del rectángulo.
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // Guardar el archivo PPTX en disco.
    $presentation->save("formatted_lines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

El resultado:

![Las líneas formateadas en la presentación](formatted-lines.png)

## **Aplicar efectos de boceto a las líneas de la forma**

Un efecto de boceto hace que una línea de forma parezca dibujada a mano. Usa [Shape.getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) para acceder a los ajustes de línea, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/) para acceder a los ajustes de boceto y [SketchFormat.setSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/) para seleccionar un valor de la enumeración [LineSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/).

El siguiente código PHP muestra cómo aplicar un efecto [LineSketchType.Curved](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/), leer el valor asignado explícitamente y eliminar el efecto con [LineSketchType.None](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/):

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

    // Acceder al formato de línea de la forma y a su formato de boceto.
    $sketchFormat = $shape->getLineFormat()->getSketchFormat();

    // Aplicar un efecto de boceto.
    $sketchFormat->setSketchType(LineSketchType::Curved);

    // Leer el efecto de boceto asignado directamente a la forma.
    $explicitSketchType = $sketchFormat->getSketchType();
    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;

    // Eliminar el efecto de boceto.
    $sketchFormat->setSketchType(LineSketchType::None);
} finally {
    $presentation->dispose();
}
```

El valor devuelto por [SketchFormat.getSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/) representa el ajuste asignado directamente a la forma. Si el formato de línea puede heredarse de un tema, diapositiva maestra o diapositiva de diseño, usa [LineFormat.getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/), accede al método `getSketchFormat` del objeto devuelto y lee su valor `getSketchType`. El valor efectivo refleja el formato que realmente se aplica después de resolver la herencia:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $lineFormat = $shape->getLineFormat();

    $explicitSketchType = $lineFormat->getSketchFormat()->getSketchType();
    $effectiveLineFormat = $lineFormat->getEffective();
    $effectiveSketchType = $effectiveLineFormat->getSketchFormat()->getSketchType();

    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;
    echo "Effective sketch type: " . $effectiveSketchType . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Formato de estilos de unión**

Estas son las tres opciones de tipo de unión:

* Redondo
* Inglete
* Bisel

Por defecto, cuando PowerPoint une dos líneas en un ángulo (como en la esquina de una forma), utiliza el ajuste **Redondo**. Sin embargo, si dibujas una forma con ángulos agudos, puede que prefieras la opción **Inglete**.

![El estilo de unión en la presentación](join-style-powerpoint.png)

El siguiente código PHP muestra cómo se crearon tres rectángulos (como se muestra en la imagen anterior) usando los ajustes de unión Inglete, Bisel y Redondo:

```php
// Instanciar la clase Presentation que representa un archivo de presentación.
$presentation = new Presentation();
try {
    // Obtener la primera diapositiva.
    $slide = $presentation->getSlides()->get_Item(0);

    // Añadir tres autoformas del tipo Rectángulo.
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

    // Establecer el color de relleno para cada forma rectangular.
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

    // Establecer el ancho de la línea.
    $shape1->getLineFormat()->setWidth(15);
    $shape2->getLineFormat()->setWidth(15);
    $shape3->getLineFormat()->setWidth(15);

    // Establecer el color para la línea de cada rectángulo.
    $shape1->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape3->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // Establecer el estilo de unión.
    $shape1->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
    $shape2->getLineFormat()->setJoinStyle(LineJoinStyle::Bevel);
    $shape3->getLineFormat()->setJoinStyle(LineJoinStyle::Round);

    // Añadir texto a cada rectángulo.
    $shape1->getTextFrame()->setText("Miter Join Style");
    $shape2->getTextFrame()->setText("Bevel Join Style");
    $shape3->getTextFrame()->setText("Round Join Style");

    // Guardar el archivo PPTX en disco.
    $presentation->save("join_styles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Relleno degradado**

En PowerPoint, el Relleno degradado es una opción de formato que permite aplicar una transición continua de colores a una forma. Por ejemplo, puedes aplicar dos o más colores de modo que uno se desvanezca gradualmente en otro.

Así es como se aplica un relleno degradado a una forma usando Aspose.Slides:

1. Crear una instancia de la clase [Presentación](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Obtener una referencia a una diapositiva por su índice.
1. Añadir un [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) a la diapositiva.
1. Establecer el [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) de la forma a `Gradient`.
1. Añadir tus dos colores preferidos con posiciones definidas usando los métodos `add` de la colección de paradas de degradado expuesta por la clase [GradientFormat](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/).
1. Guardar la presentación modificada como archivo PPTX.

El siguiente código PHP muestra cómo aplicar un efecto de relleno degradado a una elipse:

```php
// Instanciar la clase Presentation que representa un archivo de presentación.
$presentation = new Presentation();
try {
    // Obtener la primera diapositiva.
    $slide = $presentation->getSlides()->get_Item(0);

    // Añadir una autoforma del tipo Elipse.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

    // Aplicar formato de degradado a la elipse.
    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape::Linear);

    // Establecer la dirección del degradado.
    $shape->getFillFormat()->getGradientFormat()->setGradientDirection(GradientDirection::FromCorner2);

    // Añadir dos paradas de degradado.
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0, PresetColor::Red);

    // Guardar el archivo PPTX en disco.
    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

El resultado:

![La elipse con relleno degradado](gradient-fill.png)

Si un degradado se ve diferente en una imagen exportada que en PowerPoint, consulta [Choose a Gradient Rendering Style](/slides/es/php-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Puedes seleccionar un estilo de renderizado sin cambiar el relleno degradado almacenado en la presentación.

## **Relleno con patrón**

En PowerPoint, el Relleno con patrón es una opción de formato que permite aplicar un diseño de dos colores —como puntos, rayas, cruzados o cuadros— a una forma. Puedes elegir colores personalizados para el primer plano y el fondo del patrón.

Aspose.Slides ofrece más de 45 estilos de patrón predefinidos que puedes aplicar a las formas para mejorar el aspecto visual de tus presentaciones. Incluso después de seleccionar un patrón predefinido, aún puedes especificar los colores exactos que debe usar.

Así es como se aplica un relleno con patrón a una forma usando Aspose.Slides:

1. Crear una instancia de la clase [Presentación](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Obtener una referencia a una diapositiva por su índice.
1. Añadir un [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) a la diapositiva.
1. Establecer el [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) de la forma a `Pattern`.
1. Elegir un estilo de patrón entre las opciones predefinidas.
1. Establecer el [Color de fondo](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getBackColor) del patrón.
1. Establecer el [Color de primer plano](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getForeColor) del patrón.
1. Guardar la presentación modificada como archivo PPTX.

El siguiente código PHP muestra cómo aplicar un relleno con patrón a un rectángulo:

```php
// Instanciar la clase Presentation que representa un archivo de presentación.
$presentation = new Presentation();
try {
    // Obtener la primera diapositiva.
    $slide = $presentation->getSlides()->get_Item(0);

    // Añadir una autoforma del tipo Rectángulo.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Establecer el tipo de relleno a Patrón.
    $shape->getFillFormat()->setFillType(FillType::Pattern);

    // Establecer el estilo de patrón.
    $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);

    // Establecer los colores de fondo y primer plano del patrón.
    $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

    // Guardar el archivo PPTX en disco.
    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

El resultado:

![El rectángulo con relleno de patrón](pattern-fill.png)

## **Relleno con imagen**

En PowerPoint, el Relleno con imagen es una opción de formato que permite insertar una imagen dentro de una forma, utilizándola efectivamente como fondo de la forma.

Así es como se usa Aspose.Slides para aplicar un relleno con imagen a una forma:

1. Crear una instancia de la clase [Presentación](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Obtener una referencia a una diapositiva por su índice.
1. Añadir un [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) a la diapositiva.
1. Establecer el [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) de la forma a `Picture`.
1. Establecer el modo de relleno de imagen a `Tile` (u otro modo preferido).
1. Crear un objeto [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) a partir de la imagen que deseas usar.
1. Pasar la imagen al método `SlidesPicture.setImage`.
1. Guardar la presentación modificada como archivo PPTX.

Supongamos que tenemos un archivo "lotus.png" con la siguiente imagen:

![La imagen de loto](lotus.png)

El siguiente código PHP muestra cómo rellenar una forma con la imagen:

```php
// Instanciar la clase Presentation que representa un archivo de presentación.
$presentation = new Presentation();
try {
    // Obtener la primera diapositiva.
    $slide = $presentation->getSlides()->get_Item(0);

    // Añadir una autoforma del tipo Rectángulo.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

    // Establecer el tipo de relleno a Imagen.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Establecer el modo de relleno de imagen.
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    // Cargar una imagen y agregarla a los recursos de la presentación.
    $image = Images::fromFile("lotus.png");
    $picture = $presentation->getImages()->addImage($image);
    $image->dispose();

    // Establecer la imagen.
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);

    // Guardar el archivo PPTX en disco.
    $presentation->save("picture_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

El resultado:

![La forma con relleno de imagen](picture-fill.png)

### **Imagen en mosaico como textura**

Si deseas establecer una imagen en mosaico como textura y personalizar el comportamiento del mosaico, puedes usar los siguientes métodos de la clase [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode): Establece el modo de relleno de imagen —`Tile` o `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileAlignment): Especifica la alineación de los mosaicos dentro de la forma.
- [setTileFlip](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileFlip): Controla si el mosaico se voltea horizontalmente, verticalmente o en ambas direcciones.
- [setTileOffsetX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetX): Establece el desplazamiento horizontal del mosaico (en puntos) desde el origen de la forma.
- [setTileOffsetY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetY): Establece el desplazamiento vertical del mosaico (en puntos) desde el origen de la forma.
- [setTileScaleX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleX): Define la escala horizontal del mosaico como porcentaje.
- [setTileScaleY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleY): Define la escala vertical del mosaico como porcentaje.

El siguiente fragmento de código muestra cómo añadir una forma rectangular con relleno de imagen en mosaico y configurar las opciones del mosaico:

```php
// Instanciar la clase Presentation que representa un archivo de presentación.
$presentation = new Presentation();
try {
    // Obtener la primera diapositiva.
    $firstSlide = $presentation->getSlides()->get_Item(0);

    // Añadir una autoforma rectangular.
    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

    // Establecer el tipo de relleno de la forma a Imagen.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Cargar la imagen y añadirla a los recursos de la presentación.
    $sourceImage = Images::fromFile("lotus.png");
    $presentationImage = $presentation->getImages()->addImage($sourceImage);
    $sourceImage->dispose();

    // Asignar la imagen a la forma.
    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);

    // Configurar el modo de relleno de imagen y las propiedades de mosaico.
    $pictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $pictureFillFormat->setTileOffsetX(-32);
    $pictureFillFormat->setTileOffsetY(-32);
    $pictureFillFormat->setTileScaleX(50);
    $pictureFillFormat->setTileScaleY(50);
    $pictureFillFormat->setTileAlignment(RectangleAlignment::BottomRight);
    $pictureFillFormat->setTileFlip(TileFlip::FlipBoth);

    // Guardar el archivo PPTX en disco.
    $presentation->save("tile.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

El resultado:

![Las opciones de mosaico](tile-options.png)

## **Relleno de color sólido**

En PowerPoint, el Relleno de color sólido es una opción de formato que llena una forma con un solo color uniforme. Este color de fondo plano se aplica sin degradados, texturas ni patrones.

Para aplicar un relleno de color sólido a una forma usando Aspose.Slides, sigue estos pasos:

1. Crear una instancia de la clase [Presentación](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Obtener una referencia a una diapositiva por su índice.
1. Añadir un [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) a la diapositiva.
1. Establecer el [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) de la forma a `Solid`.
1. Asignar el color de relleno que prefieras a la forma.
1. Guardar la presentación modificada como archivo PPTX.

El siguiente código PHP muestra cómo aplicar un relleno de color sólido a un rectángulo en una diapositiva de PowerPoint:

```php
// Instanciar la clase Presentation que representa un archivo de presentación.
$presentation = new Presentation();
try {
    // Obtener la primera diapositiva.
    $slide = $presentation->getSlides()->get_Item(0);

    // Añadir una autoforma del tipo Rectángulo.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Establecer el tipo de relleno a Sólido.
    $shape->getFillFormat()->setFillType(FillType::Solid);

    // Establecer el color de relleno.
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    // Guardar el archivo PPTX en disco.
    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

El resultado:

![La forma con relleno de color sólido](solid-color-fill.png)

## **Establecer transparencia**

En PowerPoint, cuando aplicas un relleno de color sólido, degradado, imagen o textura a formas, también puedes establecer un nivel de transparencia para controlar la opacidad del relleno. Un valor de transparencia mayor hace que la forma sea más translúcida, permitiendo que el fondo u objetos subyacentes sean parcialmente visibles.

Aspose.Slides permite establecer el nivel de transparencia ajustando el valor alfa del color usado para el relleno. Así es como se hace:

1. Crear una instancia de la clase [Presentación](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Obtener una referencia a una diapositiva por su índice.
1. Añadir un [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) a la diapositiva.
1. Establecer el [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) a `Solid`.
1. Usar `Color` para definir un color con transparencia (el componente `alpha` controla la transparencia).
1. Guardar la presentación.

El siguiente código PHP muestra cómo aplicar un color de relleno transparente a un rectángulo:

```php
// Instanciar la clase Presentation que representa un archivo de presentación.
$presentation = new Presentation();
try {
    // Obtener la primera diapositiva.
    $slide = $presentation->getSlides()->get_Item(0);

    // Añadir una autoforma rectangular sólida.
    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Añadir una autoforma rectangular transparente sobre la forma sólida.
    $transparentShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
    $transparentShape->getFillFormat()->setFillType(FillType::Solid);
    $transparentShape->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", 255, 255, 0, 204));

    // Guardar el archivo PPTX en disco.
    $presentation->save("shape_transparency.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

El resultado:

![La forma transparente](shape-transparency.png)

## **Rotar formas**

Aspose.Slides permite rotar formas en presentaciones de PowerPoint. Esto puede ser útil al posicionar elementos visuales con necesidades específicas de alineación o diseño.

Para rotar una forma en una diapositiva, sigue estos pasos:

1. Crear una instancia de la clase [Presentación](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Obtener una referencia a una diapositiva por su índice.
1. Añadir un [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) a la diapositiva.
1. Establecer la propiedad de rotación de la forma al ángulo deseado.
1. Guardar la presentación.

El siguiente código PHP muestra cómo rotar una forma 5 grados:

```php
// Instanciar la clase Presentation que representa un archivo de presentación.
$presentation = new Presentation();
try {
    // Obtener la primera diapositiva.
    $slide = $presentation->getSlides()->get_Item(0);

    // Añadir una autoforma del tipo Rectángulo.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Rotar la forma 5 grados.
    $shape->setRotation(5);

    // Guardar el archivo PPTX en disco.
    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

El resultado:

![La rotación de la forma](shape-rotation.png)

## **Añadir efectos de bisel 3D**

Aspose.Slides permite aplicar efectos de bisel 3D a las formas configurando sus propiedades [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/).

Para añadir efectos de bisel 3D a una forma, sigue estos pasos:

1. Instanciar la clase [Presentación](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Obtener una referencia a una diapositiva por su índice.
1. Añadir un [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) a la diapositiva.
1. Configurar el [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/) de la forma para definir los ajustes de bisel.
1. Guardar la presentación.

El siguiente código PHP muestra cómo aplicar efectos de bisel 3D a una forma:

```php
// Crear una instancia de la clase Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Añadir una forma a la diapositiva.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $shape->getLineFormat()->setWidth(2.0);

    // Establecer las propiedades ThreeDFormat de la forma.
    $shape->getThreeDFormat()->setDepth(4);
    $shape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $shape->getThreeDFormat()->getBevelTop()->setHeight(6);
    $shape->getThreeDFormat()->getBevelTop()->setWidth(6);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::ThreePt);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);

    // Guardar la presentación como archivo PPTX.
    $presentation->save("3D_bevel_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

El resultado:

![El efecto de bisel 3D](3D-bevel-effect.png)

## **Añadir efectos de rotación 3D**

Aspose.Slides permite aplicar efectos de rotación 3D a las formas configurando sus propiedades [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/).

Para aplicar rotación 3D a una forma:

1. Crear una instancia de la clase [Presentación](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Obtener una referencia a una diapositiva por su índice.
1. Añadir un [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) a la diapositiva.
1. Usar [setCameraType](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setCameraType) y [setLightType](https://reference.aspose.com/slides/php-java/aspose.slides/lightrig/#setLightType) para definir la rotación 3D.
1. Guardar la presentación.

El siguiente código PHP muestra cómo aplicar efectos de rotación 3D a una forma:

```php
// Crear una instancia de la clase Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $autoShape->getTextFrame()->setText("Hello, Aspose!");

    $autoShape->getThreeDFormat()->setDepth(6);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(40, 35, 20);
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);

    // Guardar la presentación como archivo PPTX.
    $presentation->save("3D_rotation_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

El resultado:

![El efecto de rotación 3D](3D-rotation-effect.png)

## **Controlar la representación en blanco y negro para formas**

El método [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setBlackWhiteMode) especifica cómo se representa una forma individual cuando una presentación se visualiza o procesa en modo blanco y negro. No habilita la visualización en blanco y negro por sí mismo y no cambia el relleno, la línea u otro formato de la forma en modo color normal.

Utiliza un valor de la clase [BlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/blackwhitemode/) para seleccionar el comportamiento deseado. Por ejemplo, `Automatic` permite que la aplicación de renderizado elija la conversión, `Gray` y `LightGray` usan coloración gris, `BlackWhite` usa solo negro y blanco, `Black` y `White` forzan un solo color, `Color` conserva el color normal, y `Hidden` omite la forma en modo blanco y negro. `NotDefined` indica que no se ha asignado ningún modo a nivel de forma.

El siguiente código PHP crea una forma coloreada y hace que aparezca gris en modo de visualización blanco y negro:

```php
use aspose\slides\BlackWhiteMode;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $orange = new Java("java.awt.Color", 255, 165, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($orange);

    // Mantener el relleno naranja en modo color, pero representar la forma con coloración gris en modo blanco y negro.
    $shape->setBlackWhiteMode(BlackWhiteMode::Gray);

    $presentation->save("shape_black_white_mode.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

En modo de color normal, el rectángulo mantiene su relleno naranja. En un flujo de trabajo de visualización en blanco y negro, utiliza color gris porque su modo está establecido a `Gray`. Esto permite conservar una diapositiva a todo color mientras se define una apariencia distinta para impresión, vista previa u otros flujos que respeten la configuración de visualización en blanco y negro de la presentación.

## **Restablecer formato**

El siguiente código Java muestra cómo restablecer el formato de una diapositiva y devolver la posición, tamaño y formato de todas las formas con marcadores de posición en la [LayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/) a sus valores predeterminados:

```php
$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        // Restablecer cada forma en la diapositiva que tiene un marcador de posición en el diseño.
        $slide->reset();
    }
    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Preguntas frecuentes**

**¿El formato de las formas afecta al tamaño final del archivo de la presentación?**

Solo de forma mínima. Las imágenes y los medios incrustados ocupan la mayor parte del espacio del archivo, mientras que los parámetros de forma como colores, efectos y degradados se almacenan como metadatos y prácticamente no añaden tamaño extra.

**¿Cómo puedo detectar formas en una diapositiva que compartan un formato idéntico para poder agruparlas?**

Compara las propiedades clave de formato de cada forma —relleno, línea y ajustes de efecto. Si todos los valores correspondientes coinciden, trata sus estilos como idénticos y agrupa lógicamente esas formas, lo que simplifica la gestión posterior de estilos.

**¿Puedo guardar un conjunto de estilos de forma personalizados en un archivo separado para reutilizarlos en otras presentaciones?**

Sí. Guarda formas de muestra con los estilos deseados en una presentación de plantilla o en un archivo de plantilla .POTX. Al crear una nueva presentación, abre la plantilla, clona las formas con estilo que necesites y vuelve a aplicar su formato donde sea necesario.