---
title: Formato de formas de PowerPoint en C++
linktitle: Formato de forma
type: docs
weight: 20
url: /es/cpp/shape-formatting/
keywords:
- formatear forma
- formatear línea
- formatear estilo de unión
- relleno de degradado
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
- C++
- Aspose.Slides
description: "Aprende a formatear formas de PowerPoint en C++ usando Aspose.Slides—establece estilos de relleno, línea y efecto para archivos PPT, PPTX y ODP con precisión y control total."
---

## **Descripción general**

En PowerPoint, puedes añadir formas a las diapositivas. Como las formas se componen de líneas, puedes formatearlas modificando o aplicando efectos a sus contornos. Además, puedes formatear las formas especificando configuraciones que controlan cómo se rellenan sus interiores.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides para C++ proporciona interfaces y métodos que te permiten formatear formas usando las mismas opciones disponibles en PowerPoint.

## **Formatear líneas**

Con Aspose.Slides, puedes especificar un estilo de línea personalizado para una forma. Los siguientes pasos describen el procedimiento:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtén una referencia a una diapositiva por su índice.
1. Añade un [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) a la diapositiva.
1. Establece el [line style](https://reference.aspose.com/slides/cpp/aspose.slides/linestyle/) de la forma.
1. Define el ancho de la línea.
1. Establece el [dash style](https://reference.aspose.com/slides/cpp/aspose.slides/linedashstyle/) de la línea.
1. Define el color de la línea para la forma.
1. Guarda la presentación modificada como archivo PPTX.

El siguiente código muestra cómo formatear un `AutoShape` rectangular:
```cpp
// Instanciar la clase Presentation que representa un archivo de presentación.
auto presentation = MakeObject<Presentation>();

// Obtener la primera diapositiva.
auto slide = presentation->get_Slide(0);

// Añadir una forma automática del tipo Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

// Establecer el color de relleno para la forma rectangular.
shape->get_FillFormat()->set_FillType(FillType::NoFill);

// Aplicar formato a las líneas del rectángulo.
shape->get_LineFormat()->set_Style(LineStyle::ThickThin);
shape->get_LineFormat()->set_Width(7);
shape->get_LineFormat()->set_DashStyle(LineDashStyle::Dash);

// Establecer el color para la línea del rectángulo.
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Guardar el archivo PPTX en disco.
presentation->Save(u"formatted_lines.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


El resultado:

![Líneas formateadas en la presentación](formatted-lines.png)

## **Formatear estilos de unión**

Estas son las tres opciones de tipo de unión:

* Round
* Miter
* Bevel

Por defecto, cuando PowerPoint une dos líneas en un ángulo (como en la esquina de una forma), utiliza la configuración **Round**. Sin embargo, si dibujas una forma con ángulos agudos, puede que prefieras la opción **Miter**.

![Estilo de unión en la presentación](join-style-powerpoint.png)

El siguiente código C++ muestra cómo se crearon tres rectángulos (como se muestra en la imagen anterior) usando las configuraciones de tipo de unión Miter, Bevel y Round:
```cpp
// Instanciar la clase Presentation que representa un archivo de presentación.
auto presentation = MakeObject<Presentation>();

// Obtener la primera diapositiva.
auto slide = presentation->get_Slide(0);

// Agregar tres formas automáticas del tipo Rectangle.
auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

// Establecer el color de relleno para cada forma rectangular.
shape1->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape2->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape3->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// Establecer el ancho de la línea.
shape1->get_LineFormat()->set_Width(15);
shape2->get_LineFormat()->set_Width(15);
shape3->get_LineFormat()->set_Width(15);

// Establecer el color de la línea de cada rectángulo.
shape1->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape3->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Establecer el estilo de unión.
shape1->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
shape2->get_LineFormat()->set_JoinStyle(LineJoinStyle::Bevel);
shape3->get_LineFormat()->set_JoinStyle(LineJoinStyle::Round);

// Agregar texto a cada rectángulo.
shape1->get_TextFrame()->set_Text(u"Miter Join Style");
shape2->get_TextFrame()->set_Text(u"Bevel Join Style");
shape3->get_TextFrame()->set_Text(u"Round Join Style");

// Guardar el archivo PPTX en disco.
presentation->Save(u"join_styles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **Relleno de degradado**

En PowerPoint, el Relleno de degradado es una opción de formato que permite aplicar una mezcla continua de colores a una forma. Por ejemplo, puedes aplicar dos o más colores de modo que uno se desvanezca gradualmente en otro.

Así es como se aplica un relleno de degradado a una forma usando Aspose.Slides:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtén una referencia a una diapositiva por su índice.
1. Añade un [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) a la diapositiva.
1. Establece el [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) de la forma a `Gradient`.
1. Añade tus dos colores preferidos con posiciones definidas usando los métodos `Add` de la colección de paradas de degradado expuesta por la interfaz [IGradientFormat](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/).
1. Guarda la presentación modificada como archivo PPTX.

El siguiente código C++ muestra cómo aplicar un efecto de relleno de degradado a una elipse:
```cpp
// Instanciar la clase Presentation que representa un archivo de presentación.
auto presentation = MakeObject<Presentation>();

// Obtener la primera diapositiva.
auto slide = presentation->get_Slide(0);

// Agregar una forma automática del tipo Ellipse.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

// Aplicar formato de degradado a la elipse.
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);

// Establecer la dirección del degradado.
shape->get_FillFormat()->get_GradientFormat()->set_GradientDirection(GradientDirection::FromCorner2);

// Agregar dos paradas de degradado.
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

// Guardar el archivo PPTX en disco.
presentation->Save(u"gradient_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


El resultado:

![Elipse con relleno de degradado](gradient-fill.png)

## **Relleno de patrón**

En PowerPoint, el Relleno de patrón es una opción de formato que te permite aplicar un diseño bicolor—como puntos, rayas, tramado o cuadros—a una forma. Puedes elegir colores personalizados para el primer plano y el fondo del patrón.

Aspose.Slides ofrece más de 45 estilos de patrón predefinidos que puedes aplicar a las formas para mejorar el atractivo visual de tus presentaciones. Incluso después de seleccionar un patrón predefinido, puedes especificar los colores exactos que debe usar.

Así es como se aplica un relleno de patrón a una forma usando Aspose.Slides:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtén una referencia a una diapositiva por su índice.
1. Añade un [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) a la diapositiva.
1. Establece el [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) de la forma a `Pattern`.
1. Elige un estilo de patrón entre las opciones predefinidas.
1. Establece el [Background Color](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_backcolor/) del patrón.
1. Establece el [Foreground Color](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_forecolor/) del patrón.
1. Guarda la presentación modificada como archivo PPTX.

El siguiente código C++ muestra cómo aplicar un relleno de patrón a un rectángulo:
```cpp
// Instanciar la clase Presentation que representa un archivo de presentación.
auto presentation = MakeObject<Presentation>();

// Obtener la primera diapositiva.
auto slide = presentation->get_Slide(0);

// Agregar una forma automática del tipo Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Establecer el tipo de relleno a Pattern.
shape->get_FillFormat()->set_FillType(FillType::Pattern);

// Establecer el estilo de patrón.
shape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);

// Establecer los colores de fondo y de primer plano del patrón.
shape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
shape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

// Guardar el archivo PPTX en disco.
presentation->Save(u"pattern_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


El resultado:

![Rectángulo con relleno de patrón](pattern-fill.png)

## **Relleno de imagen**

En PowerPoint, el Relleno de imagen es una opción de formato que permite insertar una imagen dentro de una forma, utilizando efectivamente la imagen como fondo de la forma.

Así es como se usa Aspose.Slides para aplicar un relleno de imagen a una forma:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtén una referencia a una diapositiva por su índice.
1. Añade un [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) a la diapositiva.
1. Establece el [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) de la forma a `Picture`.
1. Establece el modo de relleno de imagen a `Tile` (u otro modo preferido).
1. Crea un objeto [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) a partir de la imagen que deseas usar.
1. Pasa la imagen al método `ISlidesPicture.set_Image`.
1. Guarda la presentación modificada como archivo PPTX.

Supongamos que tenemos un archivo "lotus.png" con la siguiente imagen:

![Imagen del loto](lotus.png)

El siguiente código C++ muestra cómo rellenar una forma con la imagen:
```cpp
// Instanciar la clase Presentation que representa un archivo de presentación.
auto presentation = MakeObject<Presentation>();

// Obtener la primera diapositiva.
auto slide = presentation->get_Slide(0);

// Agregar una forma automática del tipo Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

// Establecer el tipo de relleno a Picture.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Establecer el modo de relleno de imagen.
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Tile);

// Cargar una imagen y añadirla a los recursos de la presentación.
auto image = Images::FromFile(u"lotus.png");
auto picture = presentation->get_Images()->AddImage(image);
image->Dispose();

// Establecer la imagen.
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(picture);

// Guardar el archivo PPTX en disco.
presentation->Save(u"picture_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


El resultado:

![Forma con relleno de imagen](picture-fill.png)

### **Imagen en mosaico como textura**

Si deseas establecer una imagen en mosaico como textura y personalizar el comportamiento del mosaico, puedes usar los siguientes métodos de la interfaz [IPictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/) y la clase [PictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillformat/):

- [set_PictureFillMode](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): Define el modo de relleno de imagen—`Tile` o `Stretch`.
- [set_TileAlignment](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): Especifica la alineación de los mosaicos dentro de la forma.
- [set_TileFlip](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileflip/): Controla si el mosaico se voltea horizontalmente, verticalmente o en ambos ejes.
- [set_TileOffsetX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): Define el desplazamiento horizontal del mosaico (en puntos) desde el origen de la forma.
- [set_TileOffsetY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): Define el desplazamiento vertical del mosaico (en puntos) desde el origen de la forma.
- [set_TileScaleX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): Define la escala horizontal del mosaico como porcentaje.
- [set_TileScaleY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): Define la escala vertical del mosaico como porcentaje.

El siguiente ejemplo de código muestra cómo añadir una forma rectangular con un relleno de imagen en mosaico y configurar las opciones de mosaico:
```cpp
// Instanciar la clase Presentation que representa un archivo de presentación.
auto presentation = MakeObject<Presentation>();

// Obtener la primera diapositiva.
auto firstSlide = presentation->get_Slide(0);

// Añadir una forma automática del tipo Rectangle.
auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

// Establecer el tipo de relleno de la forma a Picture.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Cargar la imagen y añadirla a los recursos de la presentación.
auto sourceImage = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(sourceImage);
sourceImage->Dispose();

// Asignar la imagen a la forma.
auto pictureFillFormat = shape->get_FillFormat()->get_PictureFillFormat();
pictureFillFormat->get_Picture()->set_Image(presentationImage);

// Configurar el modo de relleno de imagen y las propiedades de mosaico.
pictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
pictureFillFormat->set_TileOffsetX(-32);
pictureFillFormat->set_TileOffsetY(-32);
pictureFillFormat->set_TileScaleX(50);
pictureFillFormat->set_TileScaleY(50);
pictureFillFormat->set_TileAlignment(RectangleAlignment::BottomRight);
pictureFillFormat->set_TileFlip(TileFlip::FlipBoth);

// Guardar el archivo PPTX en disco.
presentation->Save(u"tile.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


El resultado:

![Opciones de mosaico](tile-options.png)

## **Relleno de color sólido**

En PowerPoint, el Relleno de color sólido es una opción de formato que llena una forma con un solo color uniforme. Este color de fondo liso se aplica sin degradados, texturas ni patrones.

Para aplicar un relleno de color sólido a una forma usando Aspose.Slides, sigue estos pasos:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtén una referencia a una diapositiva por su índice.
1. Añade un [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) a la diapositiva.
1. Establece el [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) de la forma a `Solid`.
1. Asigna el color de relleno que prefieras a la forma.
1. Guarda la presentación modificada como archivo PPTX.

El siguiente código C++ muestra cómo aplicar un relleno de color sólido a un rectángulo en una diapositiva de PowerPoint:
```cpp
// Instanciar la clase Presentation que representa un archivo de presentación.
auto presentation = MakeObject<Presentation>();

// Obtener la primera diapositiva.
auto slide = presentation->get_Slide(0);

// Agregar una forma automática del tipo Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Establecer el tipo de relleno a Solid.
shape->get_FillFormat()->set_FillType(FillType::Solid);

// Establecer el color de relleno.
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

// Guardar el archivo PPTX en disco.
presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


El resultado:

![Forma con relleno de color sólido](solid-color-fill.png)

## **Establecer transparencia**

En PowerPoint, cuando aplicas un color sólido, degradado, imagen o textura a las formas, también puedes establecer un nivel de transparencia para controlar la opacidad del relleno. Un valor de transparencia más alto hace que la forma sea más translúcida, permitiendo que el fondo o los objetos subyacentes se vean parcialmente.

Aspose.Slides te permite establecer el nivel de transparencia ajustando el valor alfa en el color usado para el relleno. Así se hace:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtén una referencia a una diapositiva por su índice.
1. Añade un [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) a la diapositiva.
1. Establece el [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) a `Solid`.
1. Usa `Color` para definir un color con transparencia (el componente `alpha` controla la transparencia).
1. Guarda la presentación.

El siguiente código C++ muestra cómo aplicar un color de relleno transparente a un rectángulo:
```cpp
// Instanciar la clase Presentation que representa un archivo de presentación.
auto presentation = MakeObject<Presentation>();

// Obtener la primera diapositiva.
auto slide = presentation->get_Slide(0);

// Agregar una forma automática rectangular sólida.
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Agregar una forma automática rectangular transparente sobre la forma sólida.
auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(204, 255, 255, 0));

// Guardar el archivo PPTX en disco.
presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


El resultado:

![Forma transparente](shape-transparency.png)

## **Rotar formas**

Aspose.Slides permite rotar formas en presentaciones de PowerPoint. Esto puede ser útil al posicionar elementos visuales con requisitos específicos de alineación o diseño.

Para rotar una forma en una diapositiva, sigue estos pasos:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtén una referencia a una diapositiva por su índice.
1. Añade un [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) a la diapositiva.
1. Establece la propiedad de rotación de la forma al ángulo deseado.
1. Guarda la presentación.

El siguiente código C++ muestra cómo rotar una forma 5 grados:
```cpp
// Instanciar la clase Presentation que representa un archivo de presentación.
auto presentation = MakeObject<Presentation>();

// Obtener la primera diapositiva.
auto slide = presentation->get_Slide(0);

// Añadir una forma automática del tipo Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Rotar la forma 5 grados.
shape->set_Rotation(5);

// Guardar el archivo PPTX en disco.
presentation->Save(u"shape_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


El resultado:

![Rotación de la forma](shape-rotation.png)

## **Agregar efectos de bisel 3D**

Aspose.Slides permite aplicar efectos de bisel 3D a las formas configurando sus propiedades [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/).

Para añadir efectos de bisel 3D a una forma, sigue estos pasos:

1. Instancia la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtén una referencia a una diapositiva por su índice.
1. Añade un [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) a la diapositiva.
1. Configura el [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/) de la forma para definir la configuración del bisel.
1. Guarda la presentación.

El siguiente código C++ muestra cómo aplicar efectos de bisel 3D a una forma:
```cpp
// Crear una instancia de la clase Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Add a shape to the slide.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Green());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->set_Width(2.0);

// Set the shape's ThreeDFormat properties.
shape->get_ThreeDFormat()->set_Depth(4.0);
shape->get_ThreeDFormat()->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
shape->get_ThreeDFormat()->get_BevelTop()->set_Height(6);
shape->get_ThreeDFormat()->get_BevelTop()->set_Width(6);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::ThreePt);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);

// Guardar la presentación como archivo PPTX.
presentation->Save(u"3D_bevel_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


El resultado:

![Efecto de bisel 3D](3D-bevel-effect.png)

## **Agregar efectos de rotación 3D**

Aspose.Slides permite aplicar efectos de rotación 3D a las formas configurando sus propiedades [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/).

Para aplicar rotación 3D a una forma:

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtén una referencia a una diapositiva por su índice.
1. Añade un [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) a la diapositiva.
1. Usa [set_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/set_cameratype/) y [set_LightType](https://reference.aspose.com/slides/cpp/aspose.slides/ilightrig/set_lighttype/) para definir la rotación 3D.
1. Guarda la presentación.

El siguiente código C++ muestra cómo aplicar efectos de rotación 3D a una forma:
```cpp
// Crear una instancia de la clase Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_TextFrame()->set_Text(u"Hello, Aspose!");

shape->get_ThreeDFormat()->set_Depth(6);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(40, 35, 20);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

// Guardar la presentación como archivo PPTX.
presentation->Save(u"3D_rotation_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


El resultado:

![Efecto de rotación 3D](3D-rotation-effect.png)

## **Restablecer formato**

El siguiente código C++ muestra cómo restablecer el formato de una diapositiva y devolver la posición, el tamaño y el formato de todas las formas con marcadores de posición en el [LayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/layoutslide/) a sus valores predeterminados:
```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // Restablecer cada forma en la diapositiva que tiene un marcador de posición en el diseño.
    slide->Reset();
}
```


## **Preguntas frecuentes**

**¿El formato de forma afecta al tamaño final del archivo de la presentación?**

Solo de forma mínima. Las imágenes y los medios incrustados ocupan la mayor parte del espacio del archivo, mientras que los parámetros de forma como colores, efectos y degradados se almacenan como metadatos y apenas añaden tamaño.

**¿Cómo puedo detectar formas en una diapositiva que comparten un formato idéntico para agruparlas?**

Compara las propiedades clave de formato de cada forma—relleno, línea y configuraciones de efectos. Si todos los valores correspondientes coinciden, considera sus estilos como idénticos y agrupa lógicamente esas formas, lo que simplifica la gestión de estilos posterior.

**¿Puedo guardar un conjunto de estilos de forma personalizados en un archivo separado para reutilizarlos en otras presentaciones?**

Sí. Guarda formas de muestra con los estilos deseados en una presentación de diapositivas de plantilla o en un archivo .POTX. Al crear una nueva presentación, abre la plantilla, clona las formas con estilo que necesites y vuelve a aplicar su formato donde sea necesario.