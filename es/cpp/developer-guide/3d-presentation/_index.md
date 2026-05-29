---
title: Crear efectos 3D en presentaciones usando C++
linktitle: Presentación 3D
type: docs
weight: 232
url: /es/cpp/3d-presentation/
keywords:
- PowerPoint 3D
- Presentación 3D
- Rotación 3D
- Profundidad 3D
- Extrusión 3D
- Degradado 3D
- Texto 3D
- PowerPoint
- Presentación
- C++
- Aspose.Slides
description: "Aplicar y renderizar efectos 3D para formas y texto de PowerPoint en C++ con Aspose.Slides. Configurar cámara, iluminación, material, extrusión, rellenos y texto 3D."
---
## **Visión general**

Aspose.Slides for C++ puede crear, editar, conservar y renderizar formato 3D al estilo PowerPoint para formas y texto. Este artículo cubre efectos 3D como rotación, extrusión, biseles, iluminación, material, rellenos degradado o de imagen, y texto 3D.

{{% alert color="primary" %}}

Este artículo trata sobre los efectos de formato 3D en formas y texto de PowerPoint. No se trata de insertar o editar archivos de modelo 3D independientes. Cuando exportas una diapositiva a una imagen, PDF o HTML, Aspose.Slides renderiza esos efectos 3D en la salida 2D exportada.

{{% /alert %}}

## **Conceptos de formato 3D**

Utiliza el método [get_ThreeDFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishape/get_threedformat/) de la interfaz [IShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishape/) para aplicar formato 3D a una forma. El método devuelve [IThreeDFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/ithreedformat/), que controla la escena 3D para esa forma.

Para texto, utiliza el método [get_ThreeDFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframeformat/get_threedformat/) de la interfaz [ITextFrameFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframeformat/). Esto aplica formato 3D al marco de texto en lugar del cuerpo de la forma.

Los métodos más importantes son:

| Método | Qué controla | Cuándo usarlo |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/es/cpp/aspose.slides/ithreedformat/get_camera/) | Punto de vista, tipo de cámara predefinida, rotación, zoom y perspectiva. | Rotar el objeto en el espacio 3D o coincidir con un preset de rotación 3D de PowerPoint. |
| [get_LightRig](https://reference.aspose.com/slides/es/cpp/aspose.slides/ithreedformat/get_lightrig/) | Preajuste de luz, dirección y rotación de la luz. | Cambiar cómo aparecen los reflejos y sombras en la superficie 3D. |
| [set_Material](https://reference.aspose.com/slides/es/cpp/aspose.slides/ithreedformat/set_material/) | Material de la superficie, como plano, mate, plástico o metal. | Hacer que la misma geometría parezca más plana, más suave, brillante o metálica. |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/es/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | Cuán lejos se extiende la forma hacia atrás desde su cara frontal. | Convertir una forma plana en un objeto 3D visiblemente grueso. |
| [get_ExtrusionColor](https://reference.aspose.com/slides/es/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | Color de los lados extruidos. | Hacer visible la profundidad o coordinar el color del lado con el relleno frontal. |
| [set_Depth](https://reference.aspose.com/slides/es/cpp/aspose.slides/ithreedformat/set_depth/) | Profundidad 3D adicional utilizada por el formato 3D de PowerPoint. | Ajustar finamente la profundidad de formas o texto, especialmente junto con la configuración de bisel y material. |
| [get_BevelTop](https://reference.aspose.com/slides/es/cpp/aspose.slides/ithreedformat/get_beveltop/) y [get_BevelBottom](https://reference.aspose.com/slides/es/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | Bordes elevados o redondeados en las caras frontal y posterior. | Añadir un borde suavizado o moldeado en lugar de una cara plana y afilada. |
| [get_ContourColor](https://reference.aspose.com/slides/es/cpp/aspose.slides/ithreedformat/get_contourcolor/) y [set_ContourWidth](https://reference.aspose.com/slides/es/cpp/aspose.slides/ithreedformat/set_contourwidth/) | Contorno alrededor del objeto 3D. | Resaltar el contorno del objeto en la salida renderizada. |

## **Crear una forma 3D**

Una forma normalmente necesita cuatro tipos de configuraciones antes de que parezca convincentemente 3D:

- Configuraciones de cámara, porque la vista frontal predeterminada puede ocultar la extrusión.
- Configuraciones de luz, porque la iluminación hace que las caras y los lados sean legibles.
- Configuraciones de material, porque la superficie afecta cómo se renderiza la luz.
- Configuraciones de extrusión o profundidad, porque una forma plana necesita grosor.

El siguiente ejemplo crea un rectángulo, añade texto a su cara frontal, aplica formato 3D, guarda la presentación como PPTX y renderiza la diapositiva a una imagen PNG.

```cpp
const float imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);
shape->get_TextFrame()->set_Text(u"3D");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto frontColor = System::Drawing::Color::get_CornflowerBlue();
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(frontColor);

auto extrusionColor = System::Drawing::Color::get_Blue();
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

En PowerPoint, la rotación 3D se configura desde el panel Rotación 3D. Los valores de rotación X, Y y Z corresponden a la rotación que estableces mediante la API de cámara.

![Panel de rotación 3D de PowerPoint con los valores de rotación X, Y y Z resaltados](img_02_01.png)

En Aspose.Slides, establece el tipo de cámara y la rotación a través de [IThreeDFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/ithreedformat/):

```cpp
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
```

Utiliza la cámara cuando necesitas cambiar cómo el espectador ve el objeto. No modifica la geometría 2D de la forma en la diapositiva. Cambia el punto de vista 3D utilizado por PowerPoint y por Aspose.Slides al renderizar.

## **Añadir extrusión y profundidad**

La extrusión hace que una forma parezca gruesa al extenderla detrás de la cara frontal. En PowerPoint, el control de profundidad establece este grosor visible, y el control de color define el color de las caras laterales.

![Controles de profundidad de PowerPoint mapeados a las propiedades de color de extrusión y altura de extrusión](img_02_02.png)

Establece [set_ExtrusionHeight](https://reference.aspose.com/slides/es/cpp/aspose.slides/ithreedformat/set_extrusionheight/) para el grosor y [get_ExtrusionColor](https://reference.aspose.com/slides/es/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) para el color de los lados:

```cpp
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);

auto extrusionColor = System::Drawing::Color::get_Purple();
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);
```

Utiliza [set_Depth](https://reference.aspose.com/slides/es/cpp/aspose.slides/ithreedformat/set_depth/) cuando necesitas trabajar directamente con el valor de profundidad de PowerPoint o combinar profundidad con bisel, material y efectos de texto. En muchos escenarios de formas, `set_ExtrusionHeight` es la configuración más clara porque expresa directamente la extrusión visible.

## **Usar rellenos degradado o de imagen con efectos 3D**

El formato 3D es independiente del relleno de la forma. Puedes aplicar un color sólido, un degradado, un patrón o un relleno de imagen a la cara frontal y seguir usando la misma cámara, luz, material y configuraciones de extrusión.

Este ejemplo aplica un relleno degradado a la forma y un color de extrusión más oscuro a los lados:

```cpp
const float imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);
shape->get_TextFrame()->set_Text(u"3D Gradient");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto firstGradientColor = System::Drawing::Color::get_Blue();
auto secondGradientColor = System::Drawing::Color::get_Orange();
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, firstGradientColor);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(100.0f, secondGradientColor);

auto extrusionColor = System::Drawing::Color::get_DarkOrange();
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

Para usar un relleno de imagen en su lugar, agrega la imagen a la presentación y asígnala al relleno de la forma:

```cpp
auto imageData = System::IO::File::ReadAllBytes(u"image.jpg");
auto image = presentation->get_Images()->AddImage(imageData);

shape->get_FillFormat()->set_FillType(FillType::Picture);
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

auto extrusionColor = System::Drawing::Color::get_DarkOrange();
shape->get_ThreeDFormat()->get_Camera()->SetRotation(10.0f, 20.0f, 30.0f);
shape->get_ThreeDFormat()->set_ExtrusionHeight(150.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);
```

![Rectángulo 3D renderizado con relleno fotográfico en la cara frontal y extrusión naranja](img_02_04.png)

## **Aplicar formato 3D al texto**

El formato 3D de una forma afecta el cuerpo de la forma. El formato 3D del texto afecta el marco de texto. Esto es útil para efectos similares a WordArt donde las propias letras necesitan extrusión, material, iluminación y configuraciones de cámara.

El siguiente ejemplo crea texto con un relleno de patrón, aplica una transformación WordArt y configura los ajustes 3D en [ITextFrameFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframeformat/):

```cpp
const float imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_TextFrame()->set_Text(u"3D Text");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Pattern);

auto foregroundColor = System::Drawing::Color::get_DarkOrange();
auto backgroundColor = System::Drawing::Color::get_White();
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

![Texto 3D renderizado con una transformación WordArt arqueada, relleno de patrón naranja y extrusión oscura](img_02_05.png)

## **Comportamiento de exportación y renderizado**

Aspose.Slides conserva el formato 3D al guardar en formatos de PowerPoint como PPTX. Al renderizar o exportar a formatos de diseño fijo, la escena 3D se rasteriza o dibuja en la salida como un resultado 2D. Esto se aplica cuando renderizas diapositivas a [PNG](/slides/es/cpp/convert-powerpoint-to-png/), exportas a [PDF](/slides/es/cpp/convert-powerpoint-to-pdf/), exportas a [HTML](/slides/es/cpp/convert-powerpoint-to-html/), o generas fotogramas para [conversión de video](/slides/es/cpp/convert-powerpoint-to-video/).

- Las imágenes y los PDFs exportados no son interactivos. El objeto no puede ser rotado por el espectador después de la exportación.
- La apariencia final depende de la combinación de cámara, conjunto de luces, material, extrusión, relleno y escalado de la diapositiva.
- Si necesitas inspeccionar valores de formato heredados o basados en el tema, lee las [propiedades efectivas de la forma](/slides/es/cpp/shape-effective-properties/).
- Algunos formatos de salida no pueden almacenar formato 3D editable de PowerPoint. En esos formatos, el resultado visual se renderiza en lugar de preservarse como ajustes 3D editables.

## **Preguntas frecuentes**

**¿Puede Aspose.Slides crear presentaciones 3D interactivas?**

Aspose.Slides crea y renderiza efectos 3D de PowerPoint para formas y texto. No convierte las imágenes, PDFs o páginas HTML exportadas en escenas 3D interactivas que el espectador pueda rotar. En PPTX, el formato 3D permanece editable en PowerPoint siempre que el formato lo admita.

**¿Cuál es la diferencia entre un modelo 3D y un efecto 3D?**

Un modelo 3D es un objeto 3D independiente insertado en una presentación. Un efecto 3D es un formato aplicado a una forma o texto de PowerPoint regular, como rotación, extrusión, bisel, iluminación y material. Este artículo cubre los efectos 3D.

**¿Qué configuraciones son necesarias para una forma 3D visible?**

Como mínimo, establece una rotación de cámara y ya sea extrusión o profundidad. En la práctica, también configura un conjunto de luces y material para que las caras renderizadas tengan reflejos y sombras claros.

**¿Puedo aplicar efectos 3D tanto a formas como a texto?**

Sí. Utiliza [IShape](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishape/) para el cuerpo de la forma y [ITextFrameFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/itextframeformat/) para el texto.

**¿Aparecerán los efectos 3D al exportar a imágenes, PDF, HTML o fotogramas de video?**

Sí. Aspose.Slides renderiza los efectos 3D al generar imágenes de diapositivas, salida PDF, salida HTML y fotogramas usados para la conversión a video. La salida exportada contiene la apariencia renderizada, no un objeto 3D editable.

**¿Puedo leer los valores 3D finales después de aplicar la herencia y la configuración del tema?**

Sí. Utiliza las API de formato efectivo descritas en [Shape Effective Properties](/slides/es/cpp/shape-effective-properties/) para leer la cámara final, el conjunto de luces, el bisel y los valores 3D relacionados.