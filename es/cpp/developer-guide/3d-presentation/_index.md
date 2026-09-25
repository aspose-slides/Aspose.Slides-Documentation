---
title: Crear efectos 3D en presentaciones usando C++
linktitle: Presentación 3D
type: docs
weight: 232
url: /es/cpp/3d-presentation/
keywords:
- PowerPoint 3D
- presentación 3D
- rotación 3D
- profundidad 3D
- extrusión 3D
- degradado 3D
- texto 3D
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Aplicar y renderizar efectos 3D para formas y texto de PowerPoint en C++ con Aspose.Slides. Configurar cámara, iluminación, material, extrusión, rellenos y texto 3D."
---
## **Visión general**

Aspose.Slides para C++ puede crear, editar, conservar y renderizar formato 3D al estilo PowerPoint para formas y texto. Este artículo cubre efectos 3D como rotación, extrusión, biseles, iluminación, material, rellenos con degradado o imagen, y texto 3D.

{{% alert color="info" title="Note" %}}
Este artículo trata sobre los efectos de formato 3D en formas y texto de PowerPoint. No se trata de insertar o editar archivos de modelo 3D independientes. Cuando exportas una diapositiva a una imagen, PDF o HTML, Aspose.Slides renderiza esos efectos 3D en la salida 2D exportada.
{{% /alert %}}

## **Conceptos de formato 3D**

Utiliza el método [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishape/get_threedformat/) para aplicar formato 3D a una forma. El método devuelve [IThreeDFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/ithreedformat/), que controla la escena 3D para esa forma.

Para texto, usa el método [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframeformat/get_threedformat/). Este aplica formato 3D al marco de texto en lugar del cuerpo de la forma.

Los métodos más importantes son:

| Método | Qué controla | Cuándo usarlo |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/es/cpp/aspose.slides/ithreedformat/get_camera/) | Punto de vista, tipo de cámara preestablecido, rotación, zoom y perspectiva. | Rotar el objeto en el espacio 3D o coincidir con un preajuste de rotación 3D de PowerPoint. |
| [get_LightRig](https://reference.aspose.com/slides/es/cpp/aspose.slides/ithreedformat/get_lightrig/) | Preajuste de luz, dirección y rotación de la luz. | Cambiar cómo aparecen los reflejos y sombras en la superficie 3D. |
| [set_Material](https://reference.aspose.com/slides/es/cpp/aspose.slides/ithreedformat/set_material/) | Material de superficie, como plano, mate, plástico o metal. | Hacer que la misma geometría parezca más plana, suave, brillante o metálica. |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/es/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | Cuán lejos se extiende la forma hacia atrás desde su cara frontal. | Convertir una forma plana en un objeto 3D visiblemente grueso. |
| [get_ExtrusionColor](https://reference.aspose.com/slides/es/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | Color de los lados extruidos. | Hacer visible la profundidad o coordinar el color del lado con el relleno frontal. |
| [set_Depth](https://reference.aspose.com/slides/es/cpp/aspose.slides/ithreedformat/set_depth/) | Profundidad 3D adicional usada por el formato 3D de PowerPoint. | Ajustar finamente la profundidad para formas o texto, especialmente junto con los ajustes de bisel y material. |
| [get_BevelTop](https://reference.aspose.com/slides/es/cpp/aspose.slides/ithreedformat/get_beveltop/) y [get_BevelBottom](https://reference.aspose.com/slides/es/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | Bordes elevados o redondeados en las caras frontal y posterior. | Agregar un borde suavizado o moldeado en lugar de una cara plana y afilada. |
| [get_ContourColor](https://reference.aspose.com/slides/es/cpp/aspose.slides/ithreedformat/get_contourcolor/) y [set_ContourWidth](https://reference.aspose.com/slides/es/cpp/aspose.slides/ithreedformat/set_contourwidth/) | Contorno alrededor del objeto 3D. | Resaltar el contorno del objeto en la salida renderizada. |

## **Crear una forma 3D**

Una forma normalmente necesita cuatro tipos de configuraciones antes de parecer convincentemente 3D:

- Configuraciones de cámara, porque la vista frontal predeterminada puede ocultar la extrusión.
- Configuraciones de luz, porque la iluminación hace que las caras y los lados sean legibles.
- Configuraciones de material, porque la superficie afecta cómo se renderiza la luz.
- Configuraciones de extrusión o profundidad, porque una forma plana necesita grosor.

El siguiente ejemplo crea un rectángulo, añade texto a su cara frontal y aplica formato 3D. Los valores de rotación de la cámara están en grados, y la altura de extrusión es de 100 puntos. El ejemplo renderiza la diapositiva a una imagen PNG al doble de sus dimensiones predeterminadas y guarda la presentación como PPTX.

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

const auto imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_TextFrame()->set_Text(u"3D");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto frontColor = Color::get_CornflowerBlue();
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(frontColor);

auto extrusionColor = Color::get_Blue();
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"shape_3d.png");
thumbnail->Dispose();

presentation->Save(u"shape_3d.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

La imagen de la diapositiva renderizada muestra el rectángulo como un bloque 3D grueso:

![Rectángulo 3D azul renderizado con texto 3D blanco en la cara frontal](img_01_01.png)

## **Rotar una forma con la cámara**

En PowerPoint, la rotación 3D se configura desde el panel de Rotación 3‑D. Los valores de rotación X, Y y Z corresponden a la rotación que estableces a través de la API de cámara.

![Panel de rotación 3‑D de PowerPoint con los valores de rotación X, Y y Z resaltados](img_02_01.png)

En Aspose.Slides, accede a la cámara mediante [IThreeDFormat::get_Camera](https://reference.aspose.com/slides/es/cpp/aspose.slides/ithreedformat/get_camera/). Este ejemplo crea un rectángulo, selecciona una vista frontal ortográfica y establece sus rotaciones X, Y y Z en 20, 30 y 40 grados, respectivamente. Configura la forma en memoria sin guardar un archivo:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);

presentation->Dispose();
```

Usa la cámara cuando necesites cambiar cómo el espectador ve el objeto. No modifica la geometría 2D de la forma en la diapositiva. Cambia el punto de vista 3D usado por PowerPoint y por Aspose.Slides al renderizar.

## **Añadir extrusión y profundidad**

La extrusión hace que una forma parezca gruesa al extenderla detrás de la cara frontal. En PowerPoint, el control de profundidad establece este grosor visible, y el control de color define el color de los lados.

![Controles de profundidad de PowerPoint mapeados a las propiedades de color de extrusión y altura de extrusión](img_02_02.png)

Establece [IThreeDFormat::set_ExtrusionHeight](https://reference.aspose.com/slides/es/cpp/aspose.slides/ithreedformat/set_extrusionheight/) para el grosor y [IThreeDFormat::get_ExtrusionColor](https://reference.aspose.com/slides/es/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) para el color de los lados. Este ejemplo da al rectángulo una extrusión de 100 puntos con lados morados y rota la cámara para revelar su grosor. Configura la forma en memoria sin guardar un archivo:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/ILightRig.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);

auto extrusionColor = Color::get_Purple();
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

presentation->Dispose();
```

El método [IThreeDFormat::set_Depth](https://reference.aspose.com/slides/es/cpp/aspose.slides/ithreedformat/set_depth/) define la profundidad de una forma 3D. El método [set_ExtrusionHeight](https://reference.aspose.com/slides/es/cpp/aspose.slides/ithreedformat/set_extrusionheight/) controla la altura del efecto de extrusión, como se muestra en este ejemplo.

## **Usar rellenos con degradado o imagen con efectos 3D**

El formato 3D es independiente del relleno de la forma. Puedes aplicar un color sólido, degradado, patrón o relleno de imagen a la cara frontal y seguir usando la misma cámara, luz, material y configuraciones de extrusión.

Este ejemplo aplica un degradado de azul a naranja en la cara frontal y un color naranja oscuro a la extrusión de 150 puntos. Las paradas del degradado en 0 y 100 marcan el inicio y el final del degradado. Los valores de rotación de la cámara están en grados. La diapositiva se renderiza a una imagen PNG al doble de sus dimensiones predeterminadas:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/ILightRig.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <IImage.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace System::Drawing;

const auto imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);
shape->get_TextFrame()->set_Text(u"3D Gradient");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto firstGradientColor = Color::get_Blue();
auto secondGradientColor = Color::get_Orange();
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, firstGradientColor);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(100.0f, secondGradientColor);

auto extrusionColor = Color::get_DarkOrange();
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(10.0f, 20.0f, 30.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(150.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"gradient_3d.png");
thumbnail->Dispose();

presentation->Dispose();
```

La salida renderizada mantiene el degradado en la cara frontal y renderiza la extrusión por separado:

![Rectángulo 3D renderizado con un relleno degradado de azul a naranja y extrusión naranja](img_02_03.png)

Para usar un relleno de imagen, agrega la imagen a la presentación y asígnala al relleno de la forma. Este ejemplo requiere un archivo existente llamado "image.jpg" en el directorio de trabajo. Estira la imagen para llenar el rectángulo, aplica una extrusión de 150 puntos y define la rotación de la cámara en grados. Configura la forma en memoria sin guardar ni renderizar un archivo:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/ILightRig.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace System::Drawing;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);

auto imageData = File::ReadAllBytes(u"image.jpg");
auto image = presentation->get_Images()->AddImage(imageData);

shape->get_FillFormat()->set_FillType(FillType::Picture);
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

auto extrusionColor = Color::get_DarkOrange();
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(10.0f, 20.0f, 30.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(150.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

presentation->Dispose();
```

La imagen se renderiza en la cara frontal, mientras que la extrusión se renderiza como la superficie lateral 3D:

![Rectángulo 3D renderizado con un relleno fotográfico en la cara frontal y extrusión naranja](img_02_04.png)

## **Aplicar formato 3D al texto**

El formato 3D de la forma afecta al cuerpo de la forma. El formato 3D del texto afecta al marco de texto. Esto es útil para efectos tipo WordArt donde las letras mismas necesitan extrusión, material, iluminación y configuraciones de cámara.

El siguiente ejemplo crea texto con un patrón de cuadrícula naranja y blanco, aplica un arco ascendente y configura los ajustes 3D mediante [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframeformat/get_threedformat/). La altura de extrusión y la profundidad están en puntos, y la rotación de la luz está en grados. El relleno y el contorno de la forma se ocultan para que solo sea visible el texto. El ejemplo renderiza una imagen PNG al doble de las dimensiones predeterminadas de la diapositiva y guarda la presentación como PPTX:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPatternFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/PatternStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

const auto imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);

shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_TextFrame()->set_Text(u"3D Text");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Pattern);

auto foregroundColor = Color::get_DarkOrange();
auto backgroundColor = Color::get_White();
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(foregroundColor);
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(backgroundColor);
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::LargeGrid);

shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(128.0f);

auto textFrameFormat = shape->get_TextFrame()->get_TextFrameFormat();
textFrameFormat->set_Transform(TextShapeType::ArchUp);
textFrameFormat->get_ThreeDFormat()->set_ExtrusionHeight(3.5);
textFrameFormat->get_ThreeDFormat()->set_Depth(3.0);
textFrameFormat->get_ThreeDFormat()->set_Material(MaterialPresetType::Plastic);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);
textFrameFormat->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"text_3d.png");
thumbnail->Dispose();

presentation->Save(u"text_3d.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

El texto se renderiza como letras 3D curvadas y extruidas:

![Texto 3D renderizado con una transformación de WordArt arqueada, relleno de patrón naranja y extrusión oscura](img_02_05.png)

## **Mantener el texto plano en una forma 3D**

Para mantener el texto legible mientras se preserva la apariencia 3D de la forma, llama a [ITextFrameFormat::set_KeepTextFlat](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframeformat/set_keeptextflat/) a través de [ITextFrame::get_TextFrameFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframe/get_textframeformat/). Cuando el valor es `true`, el texto permanece fuera de la escena 3D. Cuando es `false`, el texto participa en la escena y sigue su orientación 3D.

Esta configuración no elimina el formato 3D de la forma: su cámara, iluminación, material y extrusión siguen configurados mediante [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishape/get_threedformat/). También es diferente de la rotación ordinaria. [IShape::set_Rotation](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishape/set_rotation/) rota la forma en el plano de la diapositiva, mientras que [ITextFrameFormat::set_RotationAngle](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframeformat/set_rotationangle/) controla la rotación personalizada del texto dentro de su cuadro delimitador. Mantener el texto fuera de la escena 3D no restablece ninguno de esos ángulos.

El siguiente ejemplo autónomo crea un rectángulo azul con texto y lo clona al lado del original. Ambas formas tienen el mismo formato 3D; solo difiere la configuración de texto: `false` a la izquierda y `true` a la derecha. Los ángulos de cámara están en grados y la altura de extrusión es de 40 puntos. El ejemplo guarda la presentación como PPTX y renderiza la diapositiva de comparación a PNG al doble de sus dimensiones predeterminadas.

```cpp
#include <DOM/ITextFrameFormat.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextAnchorType.h>
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 70.0f, 160.0f, 240.0f, 140.0f);

shape->get_TextFrame()->set_Text(u"Readable text");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(28.0f);
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->set_Alignment(TextAlignment::Center);
shape->get_TextFrame()->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Center);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_CornflowerBlue());

shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(30.0f, 30.0f, 0.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(40.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(Color::get_RoyalBlue());
shape->get_TextFrame()->get_TextFrameFormat()->set_KeepTextFlat(false);

auto clonedShape = slide->get_Shapes()->AddClone(shape, 400.0f, 160.0f);
auto flatTextShape = System::ExplicitCast<IAutoShape>(clonedShape);
flatTextShape->get_TextFrame()->get_TextFrameFormat()->set_KeepTextFlat(true);

presentation->Save(u"keep_text_flat.pptx", SaveFormat::Pptx);
auto image = slide->GetImage(2.0f, 2.0f);
image->Save(u"keep_text_flat.png");
image->Dispose();
presentation->Dispose();
```

A la izquierda, el texto sigue la orientación 3D. A la derecha, permanece plano y es más fácil de leer. Ambos rectángulos conservan la misma extrusión visible y orientación 3D.

![Rectángulos 3D lado a lado: KeepTextFlat es false a la izquierda y true a la derecha](keep_text_flat.png)

## **Comportamiento de exportación y renderizado**

Aspose.Slides preserva el formato 3D al guardar en formatos de PowerPoint como PPTX. Al renderizar o exportar a formatos de diseño fijo, la escena 3D se rasteriza o dibuja en la salida como un resultado 2D. Esto se aplica cuando renderizas diapositivas a [PNG](/slides/es/cpp/convert-powerpoint-to-png/), exportas a [PDF](/slides/es/cpp/convert-powerpoint-to-pdf/), exportas a [HTML](/slides/es/cpp/convert-powerpoint-to-html/), o generas fotogramas para [conversión de video](/slides/es/cpp/convert-powerpoint-to-video/).

- Las imágenes y PDFs exportados no son interactivos. El objeto no puede ser rotado por el espectador después de la exportación.
- La apariencia final depende de la combinación de cámara, luz, material, extrusión, relleno y escalado de la diapositiva.
- Si necesitas inspeccionar los valores de formato heredados o basados en el tema, lee las [propiedades efectivas de la forma](/slides/es/cpp/shape-effective-properties/).
- Algunos formatos de salida no pueden almacenar el formato 3D editable de PowerPoint. En esos formatos, el resultado visual se renderiza en lugar de preservarse como configuraciones 3D editables.

## **Preguntas frecuentes**

**¿Puede Aspose.Slides crear presentaciones 3D interactivas?**

Aspose.Slides crea y renderiza efectos 3D de PowerPoint para formas y texto. No convierte imágenes, PDFs o páginas HTML exportadas en escenas 3D interactivas que el espectador pueda rotar. En PPTX, el formato 3D sigue siendo editable en PowerPoint cuando el formato lo admite.

**¿Cuál es la diferencia entre un modelo 3D y un efecto 3D?**

Un modelo 3D es un objeto 3D independiente insertado en una presentación. Un efecto 3D es un formato aplicado a una forma o texto típico de PowerPoint, como rotación, extrusión, bisel, iluminación y material. Este artículo cubre efectos 3D.

**¿Qué configuraciones son necesarias para una forma 3D visible?**

Como mínimo, establece una rotación de cámara y ya sea extrusión o profundidad. En la práctica, también configura una luz y un material para que las caras renderizadas tengan resaltados y sombras claros.

**¿Puedo aplicar efectos 3D tanto a formas como a texto?**

Sí. Usa [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishape/get_threedformat/) para el cuerpo de la forma y [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframeformat/get_threedformat/) para el texto.

**¿Aparecerán los efectos 3D al exportar a imágenes, PDF, HTML o fotogramas de video?**

Sí. Aspose.Slides renderiza los efectos 3D al producir imágenes de diapositivas, salida PDF, salida HTML y fotogramas usados para la conversión a video. La salida exportada contiene la apariencia renderizada, no un objeto 3D editable.

**¿Puedo leer los valores finales 3D después de que se apliquen la herencia y los ajustes de tema?**

Sí. Utiliza las API de formato efectivo descritas en [Propiedades efectivas de la forma](/slides/es/cpp/shape-effective-properties/) para leer la cámara final, luz, bisel y demás valores 3D relacionados.