---  
title: Presentación 3D  
type: docs  
weight: 232  
url: /cpp/3d-presentation/  
keywords:  
- 3D  
- PowerPoint 3D  
- presentación 3D  
- rotación 3D  
- profundidad 3D  
- extrusión 3D  
- degradado 3D  
- texto 3D  
- presentación de PowerPoint  
- C++  
- Aspose.Slides para C++  
description: "Presentación 3D de PowerPoint en C++"  
---  

## Descripción general  
Desde Aspose.Slides 20.9 es posible crear y modificar modelos 3D de PowerPoint. Esto se puede lograr aplicando un conjunto de efectos 3D a las formas 2D. Al crear una vista de cámara sobre la forma, puedes rotarla por el eje. Crea una extrusión o profundidad en la forma, lo que transformará la forma de una forma 2D a un modelo 3D.  
Configurar el efecto de luz en la forma 3D o cambiar los materiales puede hacer que parezca más viva. Cambiar los colores de los modelos 3D a un degradado 3D, modificar el contorno de las formas, agregar un bisel hace que el modelo 3D tenga más volumen. Todos los efectos 3D se pueden aplicar tanto a modelos 3D de PowerPoint como a textos.  

Observemos el primer ejemplo de creación de modelos 3D, que incluye todas las características mencionadas anteriormente:  
``` cpp  
using namespace Aspose::Slides;  
using namespace Aspose::Slides::Export;  

auto imageScale = 2;  

auto presentation = System::MakeObject<Presentation>();  
auto slide = presentation->get_Slide(0);  

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);  
shape->get_TextFrame()->set_Text(u"3D");  
shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);  

shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);  
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);  
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::ThreePt);  
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);  
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Matte);  
shape->get_ThreeDFormat()->set_ExtrusionHeight(100);  
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(System::Drawing::Color::get_Blue());  

auto thumbnail = slide->GetImage(imageScale, imageScale);  
thumbnail->Save(u"sample_3d.png");  
thumbnail->Dispose();  

presentation->Save(u"sandbox_3d.pptx", Export::SaveFormat::Pptx);  
presentation->Dispose();  
```  

El modelo 3D resultante de PowerPoint:  

![todo:image_alt_text](img_01_01.png)  

## Rotación 3D  
En PowerPoint, la rotación de formas está disponible a través de:  

![todo:image_alt_text](img_02_01.png)  

Para rotar modelos 3D de PowerPoint, es necesario crear una vista de cámara sobre la forma. Esto se hace con el método [IThreeDFormat.get_Camera()](https://reference.aspose.com/slides/cpp/class/aspose.slides.three_d_format#ad2f989bd1fd64fd4136e1f17660035d4)  
El método de rotación se llama desde la clase de cámara como si estuvieras rotando la cámara. De hecho, al rotar la cámara en relación con la forma, estás rotando la forma en el plano 3D.  

``` cpp  
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);  
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);  
// ... establecer otros parámetros de la escena 3D  

auto thumbnail = slide->GetImage(imageScale, imageScale);  
thumbnail->Save(u"sample_3d.png");  
thumbnail->Dispose();  
```  

## Profundidad y Extrusión 3D  
Para agregar profundidad y extrusión a un modelo 3D de PowerPoint, utiliza el método [IThreeDFormat.set_ExtrusionHeight()](https://reference.aspose.com/slides/cpp/class/aspose.slides.three_d_format#adf0bad4894b1c36d9e4b044ef4978295).  
Para modificar el color de la extrusión, utiliza el método [IThreeDFormat.get_ExtrusionColor()](https://reference.aspose.com/slides/cpp/class/aspose.slides.three_d_format#aa7db8859d23a9b4eb2f35f3a42025e9e):  

``` cpp  
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);  
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);  
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);  
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(System::Drawing::Color::get_Purple());  
// ... establecer otros parámetros de la escena 3D  

auto thumbnail = slide->GetImage(imageScale, imageScale);  
thumbnail->Save(u"sample_3d.png");  
thumbnail->Dispose();  
```  

Menú de profundidad en PowerPoint:  

![todo:image_alt_text](img_02_02.png)  

## Degradado 3D  
Dibujar un degradado 3D en un modelo 3D de PowerPoint se puede hacer mediante el método [Shape.get_FillFormat().get_GradientFormat()](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format#a1f075336cb7a0e05cd5d7a706b6f4f58):  

``` cpp  
using namespace Aspose::Slides;  

auto imageScale = 2;  

auto presentation = System::MakeObject<Presentation>();  
auto slide = presentation->get_Slide(0);  

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);  
shape->get_TextFrame()->set_Text(u"Degradado 3D");  
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);  

shape->get_FillFormat()->set_FillType(FillType::Gradient);  
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0, System::Drawing::Color::get_Blue());  
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(100.0f, System::Drawing::Color::get_Orange());  

shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);  
shape->get_ThreeDFormat()->get_Camera()->SetRotation(10.0f, 20.0f, 30.0f);  
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);  
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);  
shape->get_ThreeDFormat()->set_ExtrusionHeight(150.0);  
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(System::Drawing::Color::get_DarkOrange());  

auto thumbnail = slide->GetImage(imageScale, imageScale);  
thumbnail->Save(u"sample_3d.png");  
thumbnail->Dispose();  
```  

Modelo 3D con degradado 3D:  

![todo:image_alt_text](img_02_03.png)  

Para crear un degradado de imagen, utiliza el método [Shape.get_FillFormat().get_PictureFillFormat()](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format#ac01c9a38197ddcd80c180aceeaf155cb):  
``` cpp  
auto imageData = System::IO::File::ReadAllBytes(u"image.jpg");  
auto image = presentation->get_Images()->AddImage(imageData);  

shape->get_FillFormat()->set_FillType(FillType::Picture);  
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);  
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);  
// .. configurar 3D: Cámara, LightRig, Extrusión  

auto thumbnail = slide->GetImage(imageScale, imageScale);  
thumbnail->Save(u"sample_3d.png");  
thumbnail->Dispose();  
```  

Modelo 3D con degradado de imagen:  

![todo:image_alt_text](img_02_04.png)  

## Texto 3D (WordArt)  
Para aplicar rotación, extrusión, luz y degradado al texto y convertirlo en un texto 3D (WordArt), necesitas acceder al método [IAutoShape.get_TextFrame().get_TextFrameFormat().get_ThreeDFormat()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format#a5e681109403c2e57aa76a500fe508b30):  

``` cpp  
using namespace Aspose::Slides;  
using namespace Aspose::Slides::Export;  

auto imageScale = 2;  

auto presentation = System::MakeObject<Presentation>();  
auto slide = presentation->get_Slide(0);  

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);  
shape->get_FillFormat()->set_FillType(FillType::NoFill);  
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);  
shape->get_TextFrame()->set_Text(u"Texto 3D");  

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);  
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Pattern);  
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(System::Drawing::Color::get_DarkOrange());  
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(System::Drawing::Color::get_White());  
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::LargeGrid);  

shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(128.0f);  

auto textFrameFormat = shape->get_TextFrame()->get_TextFrameFormat();  
// configurar efecto de transformación "Arco hacia arriba" WordArt  
textFrameFormat->set_Transform(TextShapeType::ArchUp);  

textFrameFormat->get_ThreeDFormat()->set_ExtrusionHeight(3.5);  
textFrameFormat->get_ThreeDFormat()->set_Depth(3.0);  
textFrameFormat->get_ThreeDFormat()->set_Material(MaterialPresetType::Plastic);  
textFrameFormat->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);  
textFrameFormat->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);  
textFrameFormat->get_ThreeDFormat()->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);  

textFrame->get_TextFrameFormat()->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);  

auto thumbnail = slide->GetImage(imageScale, imageScale);  
thumbnail->Save(u"text3d.png");  
thumbnail->Dispose();  

presentation->Save(u"text3d.pptx", SaveFormat::Pptx);  
presentation->Dispose();  
```  

Un ejemplo de texto 3D (WordArt):  

![todo:image_alt_text](img_02_05.png)  


## No soportado - Próximamente  
Las siguientes características 3D de PowerPoint aún no son compatibles:  
- Bisel  
- Material  
- Contorno  
- Iluminación  

Continuamos mejorando nuestro motor 3D, y estas características son objeto de futuras implementaciones.  
