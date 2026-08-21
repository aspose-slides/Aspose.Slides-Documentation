---
title: Formatear formas de PowerPoint en C++
linktitle: Formateo de formas
type: docs
weight: 20
url: /es/cpp/shape-formatting/
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
- renderizado de forma en blanco y negro
- renderizado de forma en escala de grises
- rotar forma
- efecto de bisel 3D
- efecto de rotación 3D
- restablecer formato
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Aprenda a formatear formas de PowerPoint en C++ usando Aspose.Slides—establezca estilos de relleno, línea y efecto para archivos PPT, PPTX y ODP con precisión y control total."
---
## **Introducción**

En PowerPoint, puedes añadir formas a las diapositivas. Dado que las formas se componen de líneas, puedes formatearlas modificando o aplicando efectos a sus contornos. Además, puedes formatear las formas especificando ajustes que controlan cómo se rellenan sus interiores.

![formato de forma en PowerPoint](format-shape-powerpoint.png)

Aspose.Slides para C++ proporciona interfaces y métodos que permiten formatear formas utilizando las mismas opciones disponibles en PowerPoint.

## **Formatear líneas**

Con Aspose.Slides, puedes especificar un estilo de línea personalizado para una forma. Los siguientes pasos describen el procedimiento:

1. Crear una instancia de la clase [Presentación](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/).
1. Obtener una referencia a una diapositiva mediante su índice.
1. Agregar un [IAutoShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/iautoshape/) a la diapositiva.
1. Establecer el [estilo de línea](https://reference.aspose.com/slides/es/cpp/aspose.slides/linestyle/) de la forma.
1. Establecer el grosor de la línea.
1. Establecer el [estilo de guión](https://reference.aspose.com/slides/es/cpp/aspose.slides/linedashstyle/) de la línea.
1. Establecer el color de la línea para la forma.
1. Guardar la presentación modificada como un archivo PPTX.

El siguiente código muestra cómo formatear un `AutoShape` rectangular:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/LineDashStyle.h>
#include <DOM/LineStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

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

// Establecer el color de la línea del rectángulo.
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Guardar el archivo PPTX en disco.
presentation->Save(u"formatted_lines.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Las líneas formateadas en la presentación](formatted-lines.png)

## **Aplicar efectos de boceto a las líneas de la forma**

Un efecto de boceto hace que la línea de una forma parezca dibujada a mano. Utiliza [IShape::get_LineFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishape/get_lineformat/) para acceder a los ajustes de línea, [ILineFormat::get_SketchFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/ilineformat/get_sketchformat/) para acceder a los ajustes de boceto, y [ISketchFormat::set_SketchType](https://reference.aspose.com/slides/es/cpp/aspose.slides/isketchformat/set_sketchtype/) para seleccionar un valor de la enumeración [LineSketchType](https://reference.aspose.com/slides/es/cpp/aspose.slides/linesketchtype/).

El siguiente código C++ muestra cómo aplicar un efecto [LineSketchType::Curved](https://reference.aspose.com/slides/es/cpp/aspose.slides/linesketchtype/), leer el valor asignado explícitamente y eliminar el efecto con [LineSketchType::None](https://reference.aspose.com/slides/es/cpp/aspose.slides/linesketchtype/):

```cpp
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

// Access the shape's line format and its sketch format.
auto sketchFormat = shape->get_LineFormat()->get_SketchFormat();

// Apply a sketch effect.
sketchFormat->set_SketchType(LineSketchType::Curved);

// Read the sketch effect assigned directly to the shape.
auto explicitSketchType = sketchFormat->get_SketchType();
Console::WriteLine(u"Explicit sketch type: {0}", explicitSketchType);

// Remove the sketch effect.
sketchFormat->set_SketchType(LineSketchType::None);

presentation->Dispose();
```

El valor devuelto por [ISketchFormat::get_SketchType](https://reference.aspose.com/slides/es/cpp/aspose.slides/isketchformat/get_sketchtype/) representa el ajuste asignado directamente a la forma. Si el formato de la línea puede heredarse de un tema, una diapositiva maestra o una diapositiva de diseño, usa [ILineFormat::GetEffective](https://reference.aspose.com/slides/es/cpp/aspose.slides/ilineformat/geteffective/), accede a [ILineFormatEffectiveData::get_SketchFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/ilineformateffectivedata/get_sketchformat/) y lee [ISketchFormatEffectiveData::get_SketchType](https://reference.aspose.com/slides/es/cpp/aspose.slides/isketchformateffectivedata/get_sketchtype/). El valor efectivo refleja el formato que realmente se aplica tras resolver la herencia:

```cpp
auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);
auto lineFormat = shape->get_LineFormat();

auto explicitSketchType = lineFormat->get_SketchFormat()->get_SketchType();
auto effectiveLineFormat = lineFormat->GetEffective();
auto effectiveSketchType = effectiveLineFormat->get_SketchFormat()->get_SketchType();

Console::WriteLine(u"Explicit sketch type: {0}", explicitSketchType);
Console::WriteLine(u"Effective sketch type: {0}", effectiveSketchType);

presentation->Dispose();
```

## **Formatear estilos de unión**

Estas son las tres opciones de tipo de unión:

* Redondo
* Inglete
* Bisel

Por defecto, cuando PowerPoint une dos líneas en un ángulo (por ejemplo, en la esquina de una forma), utiliza la configuración **Redondo**. Sin embargo, si dibujas una forma con ángulos agudos, puede que prefieras la opción **Inglete**.

![El estilo de unión en la presentación](join-style-powerpoint.png)

El siguiente código C++ muestra cómo se crearon tres rectángulos (como se muestra en la imagen anterior) utilizando los ajustes de tipo de unión Inglete, Bisel y Redondo:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LineJoinStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

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

## **Relleno degradado**

En PowerPoint, el Relleno degradado es una opción de formato que permite aplicar una fusión continua de colores a una forma. Por ejemplo, puedes aplicar dos o más colores de modo que uno se desvanezca gradualmente en otro.

Así es como se aplica un relleno degradado a una forma usando Aspose.Slides:

1. Crear una instancia de la clase [Presentación](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/).
1. Obtener una referencia a una diapositiva mediante su índice.
1. Agregar un [IAutoShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/iautoshape/) a la diapositiva.
1. Establecer el [FillType](https://reference.aspose.com/slides/es/cpp/aspose.slides/filltype/) de la forma a `Gradient`.
1. Agregar tus dos colores preferidos con posiciones definidas usando los métodos `Add` de la colección de paradas de degradado expuesta por la interfaz [IGradientFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/igradientformat/).
1. Guardar la presentación modificada como un archivo PPTX.

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientDirection.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/PresetColor.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

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

![La elipse con relleno degradado](gradient-fill.png)

## **Relleno de patrón**

En PowerPoint, el Relleno de patrón es una opción de formato que permite aplicar un diseño bicolor—como puntos, rayas, tramas o cuadros—a una forma. Puedes elegir colores personalizados para el primer plano y el fondo del patrón.

Aspose.Slides proporciona más de 45 estilos de patrón predefinidos que puedes aplicar a las formas para mejorar el aspecto visual de tus presentaciones. Incluso después de seleccionar un patrón predefinido, puedes especificar los colores exactos que debe usar.

Así es como se aplica un relleno de patrón a una forma usando Aspose.Slides:

1. Crear una instancia de la clase [Presentación](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/).
1. Obtener una referencia a una diapositiva mediante su índice.
1. Agregar un [IAutoShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/iautoshape/) a la diapositiva.
1. Establecer el [FillType](https://reference.aspose.com/slides/es/cpp/aspose.slides/filltype/) de la forma a `Pattern`.
1. Elegir un estilo de patrón de las opciones predefinidas.
1. Establecer el [Background Color](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipatternformat/get_backcolor/) del patrón.
1. Establecer el [Foreground Color](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipatternformat/get_forecolor/) del patrón.
1. Guardar la presentación modificada como un archivo PPTX.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IPatternFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PatternStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Instanciar la clase Presentation que representa un archivo de presentación.
auto presentation = MakeObject<Presentation>();

// Obtener la primera diapositiva.
auto slide = presentation->get_Slide(0);

// Agregar una forma automática del tipo Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Establecer el tipo de relleno a Pattern.
shape->get_FillFormat()->set_FillType(FillType::Pattern);

// Establecer el estilo del patrón.
shape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);

// Establecer los colores de fondo y de primer plano del patrón.
shape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
shape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

// Guardar el archivo PPTX en disco.
presentation->Save(u"pattern_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![El rectángulo con relleno de patrón](pattern-fill.png)

## **Relleno de imagen**

En PowerPoint, el Relleno de imagen es una opción de formato que permite insertar una imagen dentro de una forma—utilizando la imagen como fondo de la forma.

Así es como se usa Aspose.Slides para aplicar un relleno de imagen a una forma:

1. Crear una instancia de la clase [Presentación](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/).
1. Obtener una referencia a una diapositiva mediante su índice.
1. Agregar un [IAutoShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/iautoshape/) a la diapositiva.
1. Establecer el [FillType](https://reference.aspose.com/slides/es/cpp/aspose.slides/filltype/) de la forma a `Picture`.
1. Establecer el modo de relleno de imagen a `Tile` (u otro modo preferido).
1. Crear un objeto [IPPImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/ippimage/) a partir de la imagen que deseas usar.
1. Pasar la imagen al método `ISlidesPicture.set_Image`.
1. Guardar la presentación modificada como un archivo PPTX.

![La imagen del loto](lotus.png)

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

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

// Cargar una imagen y agregarla a los recursos de la presentación.
auto image = Images::FromFile(u"lotus.png");
auto picture = presentation->get_Images()->AddImage(image);
image->Dispose();

// Establecer la imagen.
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(picture);

// Guardar el archivo PPTX en disco.
presentation->Save(u"picture_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![La forma con relleno de imagen](picture-fill.png)

### **Imagen en mosaico como textura**

Si deseas establecer una imagen en mosaico como textura y personalizar el comportamiento del mosaico, puedes usar los siguientes métodos de la interfaz [IPictureFillFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipicturefillformat/) y de la clase [PictureFillFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/picturefillformat/):

- [set_PictureFillMode](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): Establece el modo de relleno de imagen—`Tile` o `Stretch`.
- [set_TileAlignment](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): Especifica la alineación de los mosaicos dentro de la forma.
- [set_TileFlip](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipicturefillformat/set_tileflip/): Controla si el mosaico se invierte horizontalmente, verticalmente o en ambas direcciones.
- [set_TileOffsetX](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): Establece el desplazamiento horizontal del mosaico (en puntos) respecto al origen de la forma.
- [set_TileOffsetY](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): Establece el desplazamiento vertical del mosaico (en puntos) respecto al origen de la forma.
- [set_TileScaleX](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): Define la escala horizontal del mosaico como un porcentaje.
- [set_TileScaleY](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): Define la escala vertical del mosaico como un porcentaje.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/ShapeType.h>
#include <DOM/TileFlip.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instanciar la clase Presentation que representa un archivo de presentación.
auto presentation = MakeObject<Presentation>();

// Obtener la primera diapositiva.
auto firstSlide = presentation->get_Slide(0);

// Añadir una forma automática rectangular.
auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

// Establecer el tipo de relleno de la forma a Picture.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// Cargar la imagen y agregarla a los recursos de la presentación.
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

![Las opciones de mosaico](tile-options.png)

## **Relleno de color sólido**

En PowerPoint, el Relleno de color sólido es una opción de formato que llena una forma con un único color uniforme. Este fondo liso se aplica sin degradados, texturas ni patrones.

Para aplicar un relleno de color sólido a una forma usando Aspose.Slides, sigue estos pasos:

1. Crear una instancia de la clase [Presentación](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/).
1. Obtener una referencia a una diapositiva mediante su índice.
1. Agregar un [IAutoShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/iautoshape/) a la diapositiva.
1. Establecer el [FillType](https://reference.aspose.com/slides/es/cpp/aspose.slides/filltype/) de la forma a `Solid`.
1. Asignar el color de relleno que prefieras a la forma.
1. Guardar la presentación modificada como un archivo PPTX.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Instanciar la clase Presentation que representa un archivo de presentación.
auto presentation = MakeObject<Presentation>();

// Obtener la primera diapositiva.
auto slide = presentation->get_Slide(0);

// Añadir una forma automática del tipo Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Establecer el tipo de relleno a Solid.
shape->get_FillFormat()->set_FillType(FillType::Solid);

// Establecer el color de relleno.
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

// Guardar el archivo PPTX en disco.
presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![La forma con relleno de color sólido](solid-color-fill.png)

## **Establecer transparencia**

En PowerPoint, cuando aplicas un relleno de color sólido, degradado, imagen o textura a las formas, también puedes establecer un nivel de transparencia para controlar la opacidad del relleno. Un valor de transparencia mayor hace que la forma sea más translúcida, permitiendo que el fondo u objetos subyacentes sean parcialmente visibles.

Aspose.Slides permite establecer el nivel de transparencia ajustando el valor alfa del color usado para el relleno. Así es como se hace:

1. Crear una instancia de la clase [Presentación](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/).
1. Obtener una referencia a una diapositiva mediante su índice.
1. Agregar un [IAutoShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/iautoshape/) a la diapositiva.
1. Establecer el [FillType](https://reference.aspose.com/slides/es/cpp/aspose.slides/filltype/) a `Solid`.
1. Usar `Color` para definir un color con transparencia (el componente `alpha` controla la transparencia).
1. Guardar la presentación.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Instanciar la clase Presentation que representa un archivo de presentación.
auto presentation = MakeObject<Presentation>();

// Obtener la primera diapositiva.
auto slide = presentation->get_Slide(0);

// Añadir una forma automática rectangular sólida.
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// Añadir una forma automática rectangular transparente sobre la forma sólida.
auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(204, 255, 255, 0));

// Guardar el archivo PPTX en disco.
presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![La forma transparente](shape-transparency.png)

## **Rotar formas**

Aspose.Slides permite rotar formas en presentaciones de PowerPoint. Esto puede ser útil al posicionar elementos visuales con alineaciones o diseños específicos.

Para rotar una forma en una diapositiva, sigue estos pasos:

1. Crear una instancia de la clase [Presentación](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/).
1. Obtener una referencia a una diapositiva mediante su índice.
1. Agregar un [IAutoShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/iautoshape/) a la diapositiva.
1. Establecer la propiedad de rotación de la forma al ángulo deseado.
1. Guardar la presentación.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

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

![La rotación de la forma](shape-rotation.png)

## **Añadir efectos de bisel 3D**

Aspose.Slides permite aplicar efectos de bisel 3D a las formas configurando sus propiedades [ThreeDFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/threedformat/).

Para añadir efectos de bisel 3D a una forma, sigue estos pasos:

1. Instanciar la clase [Presentación](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/).
1. Obtener una referencia a una diapositiva mediante su índice.
1. Agregar un [IAutoShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/iautoshape/) a la diapositiva.
1. Configurar el [ThreeDFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/threedformat/) de la forma para definir los ajustes de bisel.
1. Guardar la presentación.

```cpp
#include <DOM/BevelPresetType.h>
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeBevel.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Create an instance of the Presentation class.
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

// Save the presentation as a PPTX file.
presentation->Save(u"3D_bevel_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![El efecto de bisel 3D](3D-bevel-effect.png)

## **Añadir efectos de rotación 3D**

Aspose.Slides permite aplicar efectos de rotación 3D a las formas configurando sus propiedades [ThreeDFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/threedformat/).

Para aplicar rotación 3D a una forma:

1. Crear una instancia de la clase [Presentación](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/).
1. Obtener una referencia a una diapositiva mediante su índice.
1. Agregar un [IAutoShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/iautoshape/) a la diapositiva.
1. Utilizar [set_CameraType](https://reference.aspose.com/slides/es/cpp/aspose.slides/icamera/set_cameratype/) y [set_LightType](https://reference.aspose.com/slides/es/cpp/aspose.slides/ilightrig/set_lighttype/) para definir la rotación 3D.
1. Guardar la presentación.

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/ILightRig.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

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

![El efecto de rotación 3D](3D-rotation-effect.png)

## **Controlar el renderizado en blanco y negro para formas**

El método [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishape/set_blackwhitemode/) especifica cómo se renderiza una forma individual cuando una presentación se visualiza o procesa en modo blanco y negro. No habilita la visualización en blanco y negro por sí mismo y no cambia el relleno, la línea u otros formatos de la forma en modo de color normal.

Utiliza un valor de la enumeración [BlackWhiteMode](https://reference.aspose.com/slides/es/cpp/aspose.slides/blackwhitemode/) para seleccionar el comportamiento deseado. Por ejemplo, `Automatic` permite que la aplicación de renderizado elija la conversión, `Gray` y `LightGray` usan tonalidades grises, `BlackWhite` utiliza solo negro y blanco, `Black` y `White` fuerzan un único color, `Color` conserva el color normal, y `Hidden` omite la forma en modo blanco y negro. `NotDefined` indica que no se ha asignado un modo a nivel de forma.

El siguiente código C++ crea una forma coloreada y hace que aparezca gris en modo de visualización en blanco y negro:

```cpp
#include <DOM/BlackWhiteMode.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());

// Keep the orange fill in color mode, but render the shape with gray coloring in black-and-white mode.
shape->set_BlackWhiteMode(BlackWhiteMode::Gray);

presentation->Save(u"shape_black_white_mode.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

En modo de color normal, el rectángulo conserva su relleno naranja. En un flujo de trabajo de visualización en blanco y negro, utiliza un color gris porque su modo está configurado a `Gray`. Esto permite conservar una diapositiva a todo color mientras se define una apariencia distinta para la impresión, vista previa u otros procesos que respeten la configuración de visualización en blanco y negro de la presentación.

## **Restablecer formato**

El siguiente código C++ muestra cómo restablecer el formato de una diapositiva y devolver la posición, el tamaño y el formato de todas las formas con marcadores de posición en la [LayoutSlide](https://reference.aspose.com/slides/es/cpp/aspose.slides/layoutslide/) a sus valores predeterminados:

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

for (auto&& slide : System::IterateOver(presentation->get_Slides()))
{
    // Restablecer cada forma en la diapositiva que tiene un marcador de posición en el diseño.
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Preguntas frecuentes**

**¿Afecta el formateado de las formas al tamaño final del archivo de la presentación?**

Solo de forma mínima. Las imágenes y los archivos multimedia incrustados ocupan la mayor parte del espacio del archivo, mientras que los parámetros de las formas, como colores, efectos y degradados, se almacenan como metadatos y prácticamente no añaden tamaño extra.

**¿Cómo puedo detectar formas en una diapositiva que comparten el mismo formato para poder agruparlas?**

Compara las propiedades clave de formato de cada forma—relleno, línea y ajustes de efectos. Si todos los valores correspondientes coinciden, considera sus estilos como idénticos y agrupa lógicamente esas formas, lo que simplifica la gestión de estilos posteriormente.

**¿Puedo guardar un conjunto de estilos de forma personalizados en un archivo separado para reutilizarlos en otras presentaciones?**

Sí. Guarda formas de muestra con los estilos deseados en una presentación de plantilla o en un archivo de plantilla .POTX. Cuando crees una nueva presentación, abre la plantilla, clona las formas con estilo que necesites y vuelve a aplicar su formato donde sea necesario.