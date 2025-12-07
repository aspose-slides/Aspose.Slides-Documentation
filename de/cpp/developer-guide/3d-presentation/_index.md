---
title: "Erstellen von 3D-Präsentationen in C++"
linktitle: "3D-Präsentation"
type: docs
weight: 232
url: /de/cpp/3d-presentation/
keywords:
- "3D PowerPoint"
- "3D-Präsentation"
- "3D-Rotation"
- "3D-Tiefe"
- "3D-Extrusion"
- "3D-Verlauf"
- "3D-Text"
- "PowerPoint"
- "OpenDocument"
- "Präsentation"
- "C++"
- "Aspose.Slides"
description: "Erstellen Sie interaktive 3D-Präsentationen in C++ mit Aspose.Slides mühelos. Exportieren Sie schnell in PowerPoint- und OpenDocument-Formate für vielseitige Verwendung."
---

## **Übersicht**
Seit Aspose.Slides 20.9 ist es möglich, PowerPoint 3D Modelle zu erstellen und zu ändern. Dies kann erreicht werden, indem man 2D-Formen eine Reihe von 3D-Effekten hinzufügt. Durch das Erstellen einer Kameraperspektive auf der Form können Sie sie um die Achse drehen. Durch das Erzeugen einer Extrusion oder Tiefe auf der Form wird die Form von einer 2D Form zu einem 3D Modell transformiert. Das Einstellen des Lichteffekts auf der 3D Form oder das Ändern der Materialien kann ihr ein lebendigeres Aussehen verleihen. Das Ändern der Farben von 3D Modellen zu einem 3D Verlauf, das Modifizieren der Kontur von Formen und das Hinzufügen einer Abschrägung verleihen dem 3D Modell mehr Volumen. Alle 3D-Effekte können sowohl auf PowerPoint 3D Modelle als auch auf Texte angewendet werden.

Betrachten wir das erste Beispiel für die Erstellung von 3D Modellen, das alle oben genannten Funktionen enthält:
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


Das resultierende PowerPoint 3D Modell:

![todo:image_alt_text](img_01_01.png)

## **3D‑Rotation**
In PowerPoint ist die Formrotation über folgendes verfügbar:

![todo:image_alt_text](img_02_01.png)

Um PowerPoint 3D Modelle zu drehen, muss eine Kameraperspektive auf der Form erstellt werden. Dies geschieht mit der Methode [IThreeDFormat.get_Camera()](https://reference.aspose.com/slides/cpp/class/aspose.slides.three_d_format#ad2f989bd1fd64fd4136e1f17660035d4). Die Rotationsmethode wird aus der Kameraklasse aufgerufen, als würden Sie die Kamera drehen. Tatsächlich drehen Sie die Form auf der 3D Ebene, wenn Sie die Kamera relativ zur Form drehen.
``` cpp
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
// ... weitere 3D-Szenenparameter festlegen

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"sample_3d.png");
thumbnail->Dispose();
```


## **3D Tiefe und Extrusion**
Um Tiefe und Extrusion zu einem PowerPoint 3D Modell hinzuzufügen, verwenden Sie die Methode [IThreeDFormat.set_ExtrusionHeight()](https://reference.aspose.com/slides/cpp/class/aspose.slides.three_d_format#adf0bad4894b1c36d9e4b044ef4978295).  
Um die Extrusionsfarbe zu ändern, verwenden Sie die Methode [IThreeDFormat.get_ExtrusionColor()](https://reference.aspose.com/slides/cpp/class/aspose.slides.three_d_format#aa7db8859d23a9b4eb2f35f3a42025e9e):
``` cpp
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(System::Drawing::Color::get_Purple());
// ... weitere 3D-Szenenparameter festlegen

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"sample_3d.png");
thumbnail->Dispose();
```


Tiefenmenü in PowerPoint:

![todo:image_alt_text](img_02_02.png)


## **3D‑Verlauf**
Das Zeichnen eines 3D Verlaufs auf einem PowerPoint 3D Modell kann über die Methode [Shape.get_FillFormat().get_GradientFormat()](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format#a1f075336cb7a0e05cd5d7a706b6f4f58) erfolgen:
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


3D Modell mit 3D Verlauf:

![todo:image_alt_text](img_02_03.png)
  
Um einen Bildverlauf zu erstellen, verwenden Sie die Methode [Shape.get_FillFormat().get_PictureFillFormat()](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format#ac01c9a38197ddcd80c180aceeaf155cb):
``` cpp
auto imageData = System::IO::File::ReadAllBytes(u"image.jpg");
auto image = presentation->get_Images()->AddImage(imageData);

shape->get_FillFormat()->set_FillType(FillType::Picture);
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
// .. Einrichtung 3D: Kamera, LightRig, Extrusion

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"sample_3d.png");
thumbnail->Dispose();
```


3D Modell mit Bildverlauf:

![todo:image_alt_text](img_02_04.png)

## **3D‑Text (WordArt)**
Um Rotation, Extrusion, Licht und Verlauf auf Text anzuwenden und ihn zu einem 3D Text (WordArt) zu machen, müssen Sie die Methode [IAutoShape.get_TextFrame().get_TextFrameFormat().get_ThreeDFormat()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame_format#a5e681109403c2e57aa76a500fe508b30) verwenden:
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
// einrichten "Arch Up" WordArt Transformations-Effekt
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


Ein Beispiel für 3D Text (WordArt):

![todo:image_alt_text](img_02_05.png)

## **FAQ**

**Werden 3D‑Effekte beim Export einer Präsentation in Bilder/PDF/HTML beibehalten?**

Ja. Die Slides‑3D‑Engine rendert 3D‑Effekte beim Export in unterstützte Formate ([Bilder](/slides/de/cpp/convert-powerpoint-to-png/), [PDF](/slides/de/cpp/convert-powerpoint-to-pdf/), [HTML](/slides/de/cpp/convert-powerpoint-to-html/), usw.).

**Kann ich die „effektiven“ (finalen) 3D‑Parameterwerte abrufen, die Themen, Vererbung usw. berücksichtigen?**

Ja. Slides stellt APIs zum [Auslesen effektiver Werte](/slides/de/cpp/shape-effective-properties/) bereit (einschließlich für 3D‑Beleuchtung, Abschrägungen usw.), sodass Sie die letztendlich angewendeten Einstellungen sehen können.

**Funktionieren 3D‑Effekte beim Konvertieren einer Präsentation in ein Video?**

Ja. Beim [Erzeugen von Frames für das Video](/slides/de/cpp/convert-powerpoint-to-video/) werden 3D‑Effekte genauso gerendert wie bei [exportierten Bildern](/slides/de/cpp/convert-powerpoint-to-png/).