---
title: Erstellen von 3D‑Effekten in Präsentationen mit C++
linktitle: 3D‑Präsentation
type: docs
weight: 232
url: /de/cpp/3d-presentation/
keywords:
- 3D PowerPoint
- 3D‑Präsentation
- 3D‑Drehung
- 3D‑Tiefe
- 3D‑Extrusion
- 3D‑Verlauf
- 3D‑Text
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Wenden Sie 3D‑Effekte für PowerPoint‑Formen und -Text in C++ mit Aspose.Slides an und rendern Sie sie. Konfigurieren Sie Kamera, Beleuchtung, Material, Extrusion, Füllungen und 3D‑Text."
---
## **Übersicht**

Aspose.Slides für C++ kann 3D‑Formatierungen im PowerPoint‑Stil für Formen und Text erstellen, bearbeiten, erhalten und rendern. Dieser Artikel behandelt 3D‑Effekte wie Drehung, Extrusion, Abschrägungen, Beleuchtung, Material, Farbverlauf‑ oder Bildfüllungen und 3D‑Text.

{{% alert color="info" title="Note" %}}
Dieser Artikel behandelt 3D‑Formatierungseffekte für PowerPoint‑Formen und -Text. Es geht nicht um das Einfügen oder Bearbeiten von eigenständigen 3D‑Modelldateien. Wenn Sie eine Folie in ein Bild, PDF oder HTML exportieren, rendert Aspose.Slides diese 3D‑Effekte in die exportierte 2D‑Ausgabe.
{{% /alert %}}

## **Konzepte der 3D-Formatierung**

Verwenden Sie die Methode [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/get_threedformat/), um einer Form eine 3D‑Formatierung zuzuweisen. Die Methode gibt ein [IThreeDFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/ithreedformat/) zurück, das die 3D‑Szene für diese Form steuert.

Für Text verwenden Sie die Methode [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframeformat/get_threedformat/). Dies wendet die 3D‑Formatierung auf den Textrahmen anstatt auf den Formkörper an.

Die wichtigsten Methoden sind:

| Methode | Was es steuert | Wann zu verwenden |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/de/cpp/aspose.slides/ithreedformat/get_camera/) | Ansichtspunkt, vordefinierter Kameratyp, Drehung, Zoom und Perspektive. | Drehen Sie das Objekt im 3D‑Raum oder passen Sie ein PowerPoint‑3D‑Drehungsvorgabe an. |
| [get_LightRig](https://reference.aspose.com/slides/de/cpp/aspose.slides/ithreedformat/get_lightrig/) | Lichtvorgabe, Richtung und Lichtrotation. | Ändert, wie Highlights und Schatten auf der 3D‑Oberfläche erscheinen. |
| [set_Material](https://reference.aspose.com/slides/de/cpp/aspose.slides/ithreedformat/set_material/) | Oberflächenmaterial, z. B. flach, matt, Kunststoff oder Metall. | Lässt dieselbe Geometrie flacher, weicher, glänzender oder metallisch erscheinen. |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/de/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | Wie weit die Form von ihrer Vorderseite nach hinten erweitert wird. | Verwandelt eine flache Form in ein sichtbar dickes 3D‑Objekt. |
| [get_ExtrusionColor](https://reference.aspose.com/slides/de/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | Farbe der extrudierten Seiten. | Macht die Tiefe sichtbar oder koordiniert die Seitenfarbe mit der Vordergrundfüllung. |
| [set_Depth](https://reference.aspose.com/slides/de/cpp/aspose.slides/ithreedformat/set_depth/) | Zusätzliche 3D‑Tiefe, die von PowerPoint‑3D‑Formatierung verwendet wird. | Feinabstimmung der Tiefe für Formen oder Text, insbesondere zusammen mit Abschrägungs‑ und Materialeinstellungen. |
| [get_BevelTop](https://reference.aspose.com/slides/de/cpp/aspose.slides/ithreedformat/get_beveltop/) und [get_BevelBottom](https://reference.aspose.com/slides/de/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | Erhöhte oder abgerundete Kanten an Vorder‑ und Rückseite. | Fügt eine weiche oder geformte Kante statt einer scharfen flachen Fläche hinzu. |
| [get_ContourColor](https://reference.aspose.com/slides/de/cpp/aspose.slides/ithreedformat/get_contourcolor/) und [set_ContourWidth](https://reference.aspose.com/slides/de/cpp/aspose.slides/ithreedformat/set_contourwidth/) | Kontur um das 3D‑Objekt. | Betont die Objektgrenze in der gerenderten Ausgabe. |

## **Erstellen einer 3D‑Form**

- Kameraeinstellungen, da die Standard‑Vorderansicht die Extrusion verbergen kann.  
- Lichteinstellungen, da Beleuchtung die Flächen und Seiten lesbar macht.  
- Materialeinstellungen, da die Oberfläche beeinflusst, wie Licht gerendert wird.  
- Extrusions‑ oder Tiefe‑Einstellungen, da eine flache Form Dicke benötigt.

Das folgende Beispiel erstellt ein Rechteck, fügt Text auf der Vorderseite hinzu und wendet 3D‑Formatierung an. Die Kameradrehwerte sind in Grad angegeben, die Extrusionshöhe beträgt 100 Punkte. Das Beispiel rendert die Folie zu einem PNG‑Bild in doppelter Standardgröße und speichert die Präsentation als PPTX.

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

Das gerenderte Folienbild zeigt das Rechteck als dicken 3D‑Block:

![Gerendertes blaues 3D‑Rechteck mit weißem 3D‑Text auf der Vorderseite](img_01_01.png)

## **Drehen einer Form mit der Kamera**

In PowerPoint wird die 3D‑Drehung über das 3‑D‑Drehungsfenster konfiguriert. Die X‑, Y‑ und Z‑Drehwerte entsprechen der Drehung, die Sie über die Kamera‑API setzen.

![PowerPoint‑3‑D‑Drehungsfenster mit hervorgehobenen X‑, Y‑ und Z‑Drehwerten](img_02_01.png)

In Aspose.Slides greifen Sie über [IThreeDFormat::get_Camera](https://reference.aspose.com/slides/de/cpp/aspose.slides/ithreedformat/get_camera/) auf die Kamera zu. Dieses Beispiel erstellt ein Rechteck, wählt eine orthografische Vorderansicht und setzt seine X‑, Y‑ und Z‑Drehungen auf 20, 30 bzw. 40 Grad. Es konfiguriert die Form im Speicher, ohne eine Datei zu speichern:

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

Verwenden Sie die Kamera, wenn Sie ändern müssen, wie der Betrachter das Objekt sieht. Sie ändert nicht die 2D‑Geometrie der Form auf der Folie, sondern nur den 3D‑Blickwinkel, den PowerPoint und Aspose.Slides beim Rendern nutzen.

## **Extrusion und Tiefe hinzufügen**

Extrusion lässt eine Form dick wirken, indem sie hinter die Vorderseite erweitert wird. In PowerPoint legt die Tiefensteuerung diese sichtbare Dicke fest, die Farbsteuerung bestimmt die Farbe der Seitenflächen.

![PowerPoint‑Tiefensteuerungen, die den Extrusionsfarbe‑ und Extrusionshöhe‑Eigenschaften zugeordnet sind](img_02_02.png)

Setzen Sie [IThreeDFormat::set_ExtrusionHeight](https://reference.aspose.com/slides/de/cpp/aspose.slides/ithreedformat/set_extrusionheight/) für die Dicke und [IThreeDFormat::get_ExtrusionColor](https://reference.aspose.com/slides/de/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) für die Seitenfarbe. Dieses Beispiel gibt einem Rechteck eine 100‑Punkte‑Extrusion mit purpurfarbenen Seiten und dreht die Kamera, um die Dicke zu zeigen. Es konfiguriert die Form im Speicher, ohne eine Datei zu speichern:

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

Die Methode [IThreeDFormat::set_Depth](https://reference.aspose.com/slides/de/cpp/aspose.slides/ithreedformat/set_depth/) legt die Tiefe einer 3D‑Form fest. Die Methode [set_ExtrusionHeight](https://reference.aspose.com/slides/de/cpp/aspose.slides/ithreedformat/set_extrusionheight/) steuert die Höhe des Extrusionseffekts, wie im Beispiel gezeigt.

## **Verlaufs‑ oder Bildfüllungen mit 3D‑Effekten verwenden**

3D‑Formatierung ist unabhängig von der Formfüllung. Sie können eine Vollfarbe, einen Farbverlauf, ein Muster oder eine Bildfüllung auf die Vorderseite anwenden und trotzdem dieselbe Kamera, Licht, Material und Extrusion verwenden.

Dieses Beispiel wendet einen Blau‑zu‑Orange‑Verlauf auf die Vorderseite und eine dunkelorange Farbe auf die 150‑Punkte‑Extrusion an. Die Verlaufsstopps bei 0 % und 100 % markieren Anfang und Ende des Verlaufs. Die Kameradrehwerte sind in Grad angegeben. Die Folie wird zu einem PNG‑Bild in doppelter Standardgröße gerendert:

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

Das gerenderte Ergebnis behält den Verlauf auf der Vorderseite bei und rendert die Extrusion separat:

![Gerendertes 3D‑Rechteck mit einem blau‑zu‑orangefarbenen Farbverlauf und orangefarbener Extrusion](img_02_03.png)

Um stattdessen eine Bildfüllung zu verwenden, fügen Sie das Bild zur Präsentation hinzu und weisen es der Formfüllung zu. Dieses Beispiel erfordert eine vorhandene Datei namens "image.jpg" im Arbeitsverzeichnis. Es streckt das Bild, um das Rechteck zu füllen, wendet eine 150‑Punkte‑Extrusion an und setzt die Kameradrehung in Grad. Es konfiguriert die Form im Speicher, ohne eine Datei zu speichern oder zu rendern:

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

Das Bild wird auf der Vorderseite gerendert, während die Extrusion als 3D‑Seitenfläche erscheint:

![Gerendertes 3D‑Rechteck mit Fotofüllung auf der Vorderseite und orangefarbener Extrusion](img_02_04.png)

## **3D‑Formatierung auf Text anwenden**

Form‑3D‑Formatierung wirkt auf den Formkörper. Text‑3D‑Formatierung wirkt auf den Textrahmen. Das ist nützlich für WordArt‑ähnliche Effekte, bei denen die Buchstaben selbst Extrusion, Material, Beleuchtung und Kamera benötigen.

Das folgende Beispiel erzeugt Text mit einem orange‑weißen Gittermuster, wendet einen nach oben gebogenen Bogen an und konfiguriert 3D‑Einstellungen über [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframeformat/get_threedformat/). Die Extrusionshöhe und Tiefe sind in Punkten angegeben, die Lichtrotation in Grad. Die Formfüllung und Kontur werden ausgeblendet, sodass nur der Text sichtbar ist. Das Beispiel rendert ein PNG‑Bild in doppelter Foliengröße und speichert die Präsentation als PPTX:

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

Der Text wird als gebogener, extrudierter 3D‑Schriftzug gerendert:

![Gerenderter 3D‑Text mit einem gebogenen WordArt‑Effekt, orangefarbener Musterfüllung und dunkler Extrusion](img_02_05.png)

## **Text auf einer 3D‑Form flach halten**

Rufen Sie [ITextFrameFormat::set_KeepTextFlat](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframeformat/set_keeptextflat/) über [ITextFrame::get_TextFrameFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframe/get_textframeformat/) auf. Ist der Wert `true`, bleibt der Text außerhalb der 3D‑Szene. Ist er `false`, nimmt der Text an der Szene teil und folgt deren 3D‑Orientierung.

Diese Einstellung entfernt nicht die 3D‑Formatierung der Form: Kamera, Beleuchtung, Material und Extrusion bleiben über [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/get_threedformat/) konfiguriert. Sie unterscheidet sich außerdem von einer normalen Drehung. [IShape::set_Rotation](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/set_rotation/) dreht die Form in der Folienebene, während [ITextFrameFormat::set_RotationAngle](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframeformat/set_rotationangle/) die benutzerdefinierte Drehung des Textes innerhalb seines Begrenzungsrahmens steuert. Das Halten des Textes außerhalb der 3D‑Szene setzt keine dieser Winkel zurück.

Das folgende eigenständige Beispiel erstellt ein blaues Rechteck mit Text und klont es neben das Original. Beide Formen haben dieselbe 3D‑Formatierung; nur die Texteinstellung unterscheidet sich: `false` links und `true` rechts. Die Kamerawinkel sind in Grad angegeben, die Extrusionshöhe 40 Punkte. Das Beispiel speichert die Präsentation als PPTX und rendert die Vergleichsfolie zu PNG in doppelter Standardgröße.

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

Auf der linken Seite folgt der Text der 3D‑Orientierung. Auf der rechten Seite bleibt er flach und leichter lesbar. Beide Rechtecke behalten die gleiche sichtbare Extrusion und 3D‑Orientierung bei.

![Nebeneinander dargestellte 3D‑Rechtecke: KeepTextFlat ist links false und rechts true](keep_text_flat.png)

## **Export‑ und Rendering‑Verhalten**

Aspose.Slides bewahrt 3D‑Formatierung beim Speichern in PowerPoint‑Formate wie PPTX. Beim Rendern oder Exportieren in Fixed‑Layout‑Formate wird die 3D‑Szene rasterisiert bzw. als 2D‑Ergebnis in die Ausgabe gezeichnet. Dies gilt, wenn Sie Folien zu [PNG](/slides/de/cpp/convert-powerpoint-to-png/), zu [PDF](/slides/de/cpp/convert-powerpoint-to-pdf/), zu [HTML](/slides/de/cpp/convert-powerpoint-to-html/) rendern oder Frames für die [video conversion](/slides/de/cpp/convert-powerpoint-to-video/) erzeugen.

Beachten Sie Folgendes:

- Exportierte Bilder und PDFs sind nicht interaktiv. Das Objekt kann nach dem Export nicht vom Betrachter rotiert werden.  
- Das endgültige Erscheinungsbild hängt von der Kombination aus Kamera, Licht‑Rig, Material, Extrusion, Füllung und Folien‑Skalierung ab.  
- Wenn Sie vererbte oder themenbasierte Formatierungswerte prüfen müssen, lesen Sie die [effektiven Formeigenschaften](/slides/de/cpp/shape-effective-properties/).  
- Einige Ausgabeformate können editierbare PowerPoint‑3D‑Formatierungen nicht speichern. In diesen Formaten wird das visuelle Ergebnis gerendert, anstatt als editierbare 3D‑Einstellungen erhalten zu bleiben.

## **FAQ**

**Kann Aspose.Slides interaktive 3D‑Präsentationen erstellen?**

Aspose.Slides erzeugt und rendert PowerPoint‑3D‑Effekte für Formen und Text. Es macht exportierte Bilder, PDFs oder HTML‑Seiten jedoch nicht zu interaktiven 3D‑Szenen, die ein Betrachter rotieren könnte. In PPTX bleibt die 3D‑Formatierung in PowerPoint editierbar, sofern das Format dies unterstützt.

**Was ist der Unterschied zwischen einem 3D‑Modell und einem 3D‑Effekt?**

Ein 3D‑Modell ist ein separates 3D‑Objekt, das in eine Präsentation eingefügt wird. Ein 3D‑Effekt ist eine Formatierung, die auf eine reguläre PowerPoint‑Form oder auf Text angewendet wird, z. B. Drehung, Extrusion, Abschrägung, Beleuchtung und Material. Dieser Artikel behandelt 3D‑Effekte.

**Welche Einstellungen sind für eine sichtbare 3D‑Form erforderlich?**

Mindestens müssen Sie eine Kameradrehung sowie entweder Extrusion oder Tiefe setzen. In der Praxis sollten Sie zudem ein Licht‑Rig und ein Material festlegen, damit die gerenderten Flächen klare Highlights und Schatten erhalten.

**Kann ich 3D‑Effekte sowohl auf Formen als auch auf Text anwenden?**

Ja. Verwenden Sie [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/get_threedformat/) für den Formkörper und [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframeformat/get_threedformat/) für den Text.

**Werden 3D‑Effekte beim Export in Bilder, PDF, HTML oder Videoframes angezeigt?**

Ja. Aspose.Slides rendert 3D‑Effekte, wenn Folienbilder, PDF‑Ausgaben, HTML‑Ausgaben und Frames für die Videokonvertierung erzeugt werden. Die exportierte Ausgabe enthält das gerenderte Erscheinungsbild, nicht ein editierbares 3D‑Objekt.

**Kann ich die endgültigen 3D‑Werte nach Vererbung und Anwendung der Themen‑Einstellungen lesen?**

Ja. Verwenden Sie die effektiven Format‑APIs, die in den [effektiven Formeigenschaften](/slides/de/cpp/shape-effective-properties/) beschrieben sind, um die finalen Kamera‑, Licht‑Rig‑, Abschrägungs‑ und zugehörigen 3D‑Werte zu lesen.