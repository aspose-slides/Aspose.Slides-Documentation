---  
title: 3D-Präsentation  
type: docs  
weight: 232  
url: /de/cpp/3d-presentation/  
keywords:  
- 3D  
- 3D PowerPoint  
- 3D-Präsentation  
- 3D-Rotation  
- 3D-Tiefe  
- 3D-Extrusion  
- 3D-Verlauf  
- 3D-Text  
- PowerPoint-Präsentation  
- C++  
- Aspose.Slides für C++  
description: "3D PowerPoint-Präsentation in C++"  
---  

## Übersicht  
Seit Aspose.Slides 20.9 ist es möglich, PowerPoint 3D-Modelle zu erstellen und zu bearbeiten. Dies kann erreicht werden, indem 2D-Formen eine Reihe von 3D-Effekten zugefügt werden. Durch das Erstellen einer Kameraperspektive auf der Form können Sie sie um die Achse drehen. Erstellen Sie eine Extrusion oder Tiefe auf der Form, die die Form von einer 2D-Form in ein 3D-Modell verwandelt. Das Einstellen des Lichteffekts auf der 3D-Form oder das Ändern der Materialien kann ihr ein lebendigeres Aussehen verleihen. Das Ändern der Farben von 3D-Modellen zu einem 3D-Verlauf, das Modifizieren des Formenumrisses und das Hinzufügen einer Fase verleihen dem 3D-Modell mehr Volumen. Alle 3D-Effekte können sowohl auf PowerPoint 3D-Modellen als auch auf Texten angewendet werden.

Lassen Sie uns das erste Beispiel zur Erstellung von 3D-Modellen betrachten, das alle oben genannten Funktionen umfasst:  
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

Das resultierende PowerPoint 3D-Modell:  

![todo:image_alt_text](img_01_01.png)  

## 3D-Rotation  
In PowerPoint ist die Formrotation über folgendes verfügbar:  

![todo:image_alt_text](img_02_01.png)  

Um PowerPoint 3D-Modelle zu rotieren, ist es notwendig, eine Kameraperspektive auf der Form zu erstellen. Dies erfolgt über die [IThreeDFormat.get_Camera()](https://reference.aspose.com/slides/cpp/class/aspose.slides.three_d_format#ad2f989bd1fd64fd4136e1f17660035d4)-Methode. Die Rotationsmethode wird von der Kameraklasse aufgerufen, als ob Sie die Kamera drehen würden. Tatsächlich drehen Sie, wenn Sie die Kamera relativ zur Form drehen, die Form in der 3D-Ebene.  

``` cpp  
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);  
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);  
// ... andere 3D-Szenenparameter einstellen  

auto thumbnail = slide->GetImage(imageScale, imageScale);  
thumbnail->Save(u"sample_3d.png");  
thumbnail->Dispose();  
```  

## 3D-Tiefe und Extrusion  
Um Tiefe und Extrusion für ein PowerPoint 3D-Modell hinzuzufügen, verwenden Sie die [IThreeDFormat.set_ExtrusionHeight()](https://reference.aspose.com/slides/cpp/class/aspose.slides.three_d_format#adf0bad4894b1c36d9e4b044ef4978295)-Methode.  
Für die Änderung der Extrusionsfarbe verwenden Sie die [IThreeDFormat.get_ExtrusionColor()](https://reference.aspose.com/slides/cpp/class/aspose.slides.three_d_format#aa7db8859d23a9b4eb2f35f3a42025e9e)-Methode:  

``` cpp  
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);  
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);  
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);  
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(System::Drawing::Color::get_Purple());  
// ... andere 3D-Szenenparameter einstellen  

auto thumbnail = slide->GetImage(imageScale, imageScale);  
thumbnail->Save(u"sample_3d.png");  
thumbnail->Dispose();  
```  

Tiefe-Menü in PowerPoint:  

![todo:image_alt_text](img_02_02.png)  

## 3D-Verlauf  
Das Zeichnen eines 3D-Verlaufs auf einem PowerPoint 3D-Modell kann über die [Shape.get_FillFormat().get_GradientFormat()](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format#a1f075336cb7a0e05cd5d7a706b6f4f58)-Methode erfolgen:  

``` cpp  
using namespace Aspose::Slides;  

auto imageScale = 2;  

auto presentation = System::MakeObject<Presentation>();  
auto slide = presentation->get_Slide(0);  

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);  
shape->get_TextFrame()->set_Text(u"3D Gradient");  
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

3D-Modell mit 3D-Verlauf:  

![todo:image_alt_text](img_02_03.png)  
  
Um einen Bildverlauf zu erstellen, verwenden Sie die [Shape.get_FillFormat().get_PictureFillFormat()](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format#ac01c9a38197ddcd80c180aceeaf155cb)-Methode:  
``` cpp  
auto imageData = System::IO::File::ReadAllBytes(u"image.jpg");  
auto image = presentation->get_Images()->AddImage(imageData);  

shape->get_FillFormat()->set_FillType(FillType::Picture);  
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);  
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);  
// .. 3D einstellen: Kamera, Licht, Extrusion  

auto thumbnail = slide->GetImage(imageScale, imageScale);  
thumbnail->Save(u"sample_3d.png");  
thumbnail->Dispose();  
```  

3D-Modell mit Bildverlauf:  

![todo:image_alt_text](img_02_04.png)  

## 3D-Text (WordArt)  
Um Rotation, Extrusion, Licht und Verlauf auf Text anzuwenden und ihn in einen 3D-Text (WordArt) zu verwandeln, müssen Sie die [IAutoShape.get_TextFrame().get_TextFrameFormat().get_ThreeDFormat()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format#a5e681109403c2e57aa76a500fe508b30)-Methode aufrufen:  

``` cpp  
using namespace Aspose::Slides;  
using namespace Aspose::Slides::Export;  

auto imageScale = 2;  

auto presentation = System::MakeObject<Presentation>();  
auto slide = presentation->get_Slide(0);  

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);  
shape->get_FillFormat()->set_FillType(FillType::NoFill);  
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);  
shape->get_TextFrame()->set_Text(u"3D Text");  

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);  
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Pattern);  
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(System::Drawing::Color::get_DarkOrange());  
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(System::Drawing::Color::get_White());  
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::LargeGrid);  

shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(128.0f);  

auto textFrameFormat = shape->get_TextFrame()->get_TextFrameFormat();  
// "Arch Up"-WordArt-Transformeffekt einrichten  
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

Ein Beispiel für 3D-Text (WordArt):  

![todo:image_alt_text](img_02_05.png)  

## Nicht unterstützt - Kommt bald  
Die folgenden PowerPoint 3D-Funktionen werden noch nicht unterstützt:  
- Fase  
- Material  
- Umriss  
- Beleuchtung  

Wir setzen unsere Verbesserungen an unserem 3D-Engine fort, und diese Funktionen sind Gegenstand weiterer Implementierungen.  
