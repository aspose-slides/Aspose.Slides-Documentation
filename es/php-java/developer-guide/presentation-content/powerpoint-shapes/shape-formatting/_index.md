---
title: Formatear formas de PowerPoint en PHP
linktitle: Formato de formas
type: docs
weight: 20
url: /es/php-java/shape-formatting/
keywords:
- formatear forma
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
- PHP
- Aspose.Slides
description: "Aprenda a formatear las formas de PowerPoint en PHP usando Aspose.Slides—establezca estilos de relleno, línea y efecto para archivos PPT, PPTX y ODP con precisión y control total."
---

## **Visión general**

En PowerPoint, puedes añadir formas a las diapositivas. Dado que las formas están compuestas por líneas, puedes darles formato modificando o aplicando efectos a sus contornos. Además, puedes dar formato a las formas especificando ajustes que controlan cómo se rellenan sus interiores.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides para PHP a través de Java proporciona clases y métodos que te permiten dar formato a las formas usando las mismas opciones disponibles en PowerPoint.

## **Formato de líneas**

Con Aspose.Slides, puedes especificar un estilo de línea personalizado para una forma. Los siguientes pasos describen el procedimiento:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Obtén una referencia a una diapositiva por su índice.
1. Añade un [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) a la diapositiva.
1. Establece el [line style](https://reference.aspose.com/slides/php-java/aspose.slides/linestyle/) de la forma.
1. Establece el ancho de línea.
1. Establece el [dash style](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/) de la línea.
1. Establece el color de línea para la forma.
1. Guarda la presentación modificada como un archivo PPTX.

El siguiente código PHP muestra cómo dar formato a un `AutoShape` rectangular:
```php
// Instanciar la clase Presentation que representa un archivo de presentación.
$presentation = new Presentation();
try {
    // Obtener la primera diapositiva.
    $slide = $presentation->getSlides()->get_Item(0);

    // Añadir una forma automática del tipo Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

    // Establecer el color de relleno para la forma rectangular.
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    // Aplicar formato a las líneas del rectángulo.
    $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
    $shape->getLineFormat()->setWidth(7);
    $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);

    // Establecer el color de la línea del rectángulo.
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

## **Formato de estilos de unión**

Estas son las tres opciones de tipo de unión:

* Redondo
* Inglete
* Bisel

Por defecto, cuando PowerPoint une dos líneas en un ángulo (por ejemplo, en la esquina de una forma), utiliza el ajuste **Redondo**. Sin embargo, si estás dibujando una forma con ángulos agudos, puedes preferir la opción **Inglete**.

![El estilo de unión en la presentación](join-style-powerpoint.png)

El siguiente código PHP muestra cómo se crearon tres rectángulos (como se ve en la imagen anterior) utilizando los ajustes de tipo de unión Inglete, Bisel y Redondo:
```php
// Instanciar la clase Presentation que representa un archivo de presentación.
$presentation = new Presentation();
try {
    // Obtener la primera diapositiva.
    $slide = $presentation->getSlides()->get_Item(0);

    // Añadir tres formas automáticas del tipo Rectangle.
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

    // Establecer el color de la línea de cada rectángulo.
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

En PowerPoint, Relleno degradado es una opción de formato que permite aplicar una mezcla continua de colores a una forma. Por ejemplo, puedes aplicar dos o más colores de forma que uno se desvanezca gradualmente en otro.

Así es como se aplica un relleno degradado a una forma usando Aspose.Slides:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Obtén una referencia a una diapositiva por su índice.
1. Añade un [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) a la diapositiva.
1. Establece el [FillType] de la forma a `Gradient`.
1. Añade tus dos colores preferidos con posiciones definidas usando los métodos `add` de la colección de paradas de degradado expuesta por la clase [GradientFormat].
1. Guarda la presentación modificada como un archivo PPTX.

```php
// Instanciar la clase Presentation que representa un archivo de presentación.
$presentation = new Presentation();
try {
    // Obtener la primera diapositiva.
    $slide = $presentation->getSlides()->get_Item(0);

    // Añadir una forma automática del tipo Elipse.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

    // Aplicar formato degradado a la elipse.
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

## **Relleno de patrón**

En PowerPoint, Relleno de patrón es una opción de formato que permite aplicar un diseño bicolor —como puntos, rayas, sombreados cruzados o cuadros— a una forma. Puedes elegir colores personalizados para el primer plano y el fondo del patrón.

Aspose.Slides ofrece más de 45 estilos de patrón predefinidos que puedes aplicar a las formas para mejorar el atractivo visual de tus presentaciones. Incluso después de seleccionar un patrón predefinido, puedes especificar los colores exactos que debe usar.

Así es como se aplica un relleno de patrón a una forma usando Aspose.Slides:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Obtén una referencia a una diapositiva por su índice.
1. Añade un [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) a la diapositiva.
1. Establece el [FillType] de la forma a `Pattern`.
1. Elige un estilo de patrón entre las opciones predefinidas.
1. Establece el [Background Color] del patrón.
1. Establece el [Foreground Color] del patrón.
1. Guarda la presentación modificada como un archivo PPTX.

```php
// Instanciar la clase Presentation que representa un archivo de presentación.
$presentation = new Presentation();
try {
    // Obtener la primera diapositiva.
    $slide = $presentation->getSlides()->get_Item(0);

    // Añadir una forma automática del tipo Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Establecer el tipo de relleno a Pattern.
    $shape->getFillFormat()->setFillType(FillType::Pattern);

    // Establecer el estilo de patrón.
    $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);

    // Establecer los colores de fondo y de primer plano del patrón.
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

## **Relleno de imagen**

En PowerPoint, Relleno de imagen es una opción de formato que permite insertar una imagen dentro de una forma—utilizando efectivamente la imagen como fondo de la forma.

Así es como se usa Aspose.Slides para aplicar un relleno de imagen a una forma:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Obtén una referencia a una diapositiva por su índice.
1. Añade un [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) a la diapositiva.
1. Establece el [FillType] de la forma a `Picture`.
1. Establece el modo de relleno de imagen a `Tile` (u otro modo preferido).
1. Crea un objeto [PPImage] a partir de la imagen que deseas usar.
1. Pasa la imagen al método `SlidesPicture.setImage`.
1. Guarda la presentación modificada como un archivo PPTX.

![La imagen del loto](lotus.png)

```php
// Instanciar la clase Presentation que representa un archivo de presentación.
$presentation = new Presentation();
try {
    // Obtener la primera diapositiva.
    $slide = $presentation->getSlides()->get_Item(0);

    // Añadir una forma automática del tipo Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

    // Establecer el tipo de relleno a Picture.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Establecer el modo de relleno de imagen.
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    // Cargar una imagen y añadirla a los recursos de la presentación.
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

Si deseas establecer una imagen en mosaico como textura y personalizar el comportamiento del mosaico, puedes usar los siguientes métodos de la clase [PictureFillFormat]:

- [setPictureFillMode]: Establece el modo de relleno de imagen—`Tile` o `Stretch`.
- [setTileAlignment]: Especifica la alineación de los mosaicos dentro de la forma.
- [setTileFlip]: Controla si el mosaico se voltea horizontalmente, verticalmente o en ambas direcciones.
- [setTileOffsetX]: Establece el desplazamiento horizontal del mosaico (en puntos) desde el origen de la forma.
- [setTileOffsetY]: Establece el desplazamiento vertical del mosaico (en puntos) desde el origen de la forma.
- [setTileScaleX]: Define la escala horizontal del mosaico como porcentaje.
- [setTileScaleY]: Define la escala vertical del mosaico como porcentaje.

```php
// Instanciar la clase Presentation que representa un archivo de presentación.
$presentation = new Presentation();
try {
    // Obtener la primera diapositiva.
    $firstSlide = $presentation->getSlides()->get_Item(0);

    // Añadir una forma automática rectangular.
    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

    // Establecer el tipo de relleno de la forma a Picture.
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


¡Las opciones de mosaico!

![Las opciones de mosaico](tile-options.png)

## **Relleno de color sólido**

En PowerPoint, Relleno de color sólido es una opción de formato que rellena una forma con un único color uniforme. Este color de fondo simple se aplica sin degradados, texturas ni patrones.

Para aplicar un relleno de color sólido a una forma usando Aspose.Slides, sigue estos pasos:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Obtén una referencia a una diapositiva por su índice.
1. Añade un [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) a la diapositiva.
1. Establece el [FillType] de la forma a `Solid`.
1. Asigna tu color de relleno preferido a la forma.
1. Guarda la presentación modificada como un archivo PPTX.

```php
// Instanciar la clase Presentation que representa un archivo de presentación.
$presentation = new Presentation();
try {
    // Obtener la primera diapositiva.
    $slide = $presentation->getSlides()->get_Item(0);

    // Añadir una forma automática del tipo Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Establecer el tipo de relleno a Solid.
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

En PowerPoint, cuando aplicas un relleno sólido, degradado, de imagen o de textura a las formas, también puedes establecer un nivel de transparencia para controlar la opacidad del relleno. Un valor de transparencia más alto hace que la forma sea más translúcida, permitiendo que el fondo u objetos subyacentes sean parcialmente visibles.

Aspose.Slides te permite establecer el nivel de transparencia ajustando el valor alfa en el color usado para el relleno. Así es como se hace:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Obtén una referencia a una diapositiva por su índice.
1. Añade un [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) a la diapositiva.
1. Establece el [FillType] a `Solid`.
1. Usa `Color` para definir un color con transparencia (el componente `alpha` controla la transparencia).
1. Guarda la presentación.

```php
// Instanciar la clase Presentation que representa un archivo de presentación.
$presentation = new Presentation();
try {
    // Obtener la primera diapositiva.
    $slide = $presentation->getSlides()->get_Item(0);

    // Añadir una forma automática rectangular sólida.
    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Añadir una forma automática rectangular transparente sobre la forma sólida.
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

Aspose.Slides permite rotar formas en presentaciones de PowerPoint. Esto puede ser útil al posicionar elementos visuales con requisitos específicos de alineación o diseño.

Para rotar una forma en una diapositiva, sigue estos pasos:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Obtén una referencia a una diapositiva por su índice.
1. Añade un [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) a la diapositiva.
1. Establece la propiedad de rotación de la forma al ángulo deseado.
1. Guarda la presentación.

```php
// Instanciar la clase Presentation que representa un archivo de presentación.
$presentation = new Presentation();
try {
    // Obtener la primera diapositiva.
    $slide = $presentation->getSlides()->get_Item(0);

    // Añadir una forma automática del tipo Rectangle.
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

## **Agregar efectos de bisel 3D**

Aspose.Slides permite aplicar efectos de bisel 3D a las formas configurando sus propiedades [ThreeDFormat].

Para agregar efectos de bisel 3D a una forma, sigue estos pasos:

1. Instancia la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Obtén una referencia a una diapositiva por su índice.
1. Añade un [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) a la diapositiva.
1. Configura el [ThreeDFormat] de la forma para definir los ajustes de bisel.
1. Guarda la presentación.

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

## **Agregar efectos de rotación 3D**

Aspose.Slides permite aplicar efectos de rotación 3D a las formas configurando sus propiedades [ThreeDFormat].

Para aplicar rotación 3D a una forma:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Obtén una referencia a una diapositiva por su índice.
1. Añade un [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) a la diapositiva.
1. Utiliza [setCameraType] y [setLightType] para definir la rotación 3D.
1. Guarda la presentación.

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

## **Restablecer formato**

El siguiente código Java muestra cómo restablecer el formato de una diapositiva y devolver la posición, tamaño y formato de todas las formas con marcadores de posición en el [LayoutSlide] a sus valores predeterminados:
```php
$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        // Restablecer cada forma de la diapositiva que tiene un marcador de posición en el diseño.
        $slide->reset();
    }
    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **Preguntas frecuentes**

**¿El formato de las formas afecta al tamaño final del archivo de la presentación?**

Solo mínimamente. Las imágenes y medios incrustados ocupan la mayor parte del espacio del archivo, mientras que los parámetros de las formas como colores, efectos y degradados se almacenan como metadatos y prácticamente no añaden tamaño adicional.

**¿Cómo puedo detectar formas en una diapositiva que comparten el mismo formato para poder agruparlas?**

Compara las propiedades clave de formato de cada forma —relleno, línea y ajustes de efectos. Si todos los valores correspondientes coinciden, considera sus estilos como idénticos y agrupa lógicamente esas formas, lo que simplifica la gestión posterior de estilos.

**¿Puedo guardar un conjunto de estilos de forma personalizados en un archivo separado para reutilizarlos en otras presentaciones?**

Sí. Guarda formas de muestra con los estilos deseados en una presentación de plantilla o en un archivo de plantilla .POTX. Al crear una nueva presentación, abre la plantilla, clona las formas con estilo que necesites y vuelve a aplicar su formato donde sea necesario.