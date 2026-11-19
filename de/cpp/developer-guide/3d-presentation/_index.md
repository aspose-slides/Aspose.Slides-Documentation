---
title: 3D-Effekte in Präsentationen mit C++ erstellen
linktitle: 3D-Präsentation
type: docs
weight: 232
url: /de/cpp/3d-presentation/
keywords:
- 3D PowerPoint
- 3D-Präsentation
- 3D-Drehung
- 3D-Tiefe
- 3D-Extrusion
- 3D-Verlauf
- 3D-Text
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Wenden Sie 3D‑Effekte für PowerPoint‑Formen und -Text in C++ mit Aspose.Slides an und rendern Sie sie. Konfigurieren Sie Kamera, Beleuchtung, Material, Extrusion, Füllungen und 3D‑Text."
---
## **Übersicht**

Aspose.Slides für C++ kann PowerPoint‑ähnliche 3D‑Formatierung für Formen und Text erstellen, bearbeiten, beibehalten und rendern. Dieser Artikel behandelt 3D‑Effekte wie Drehung, Extrusion, Abschrägungen, Beleuchtung, Material, Verlauf‑ oder Bildfüllungen und 3D‑Text.

{{% alert color="info" title="Note" %}}
Dieser Artikel behandelt 3D‑Formatierungseffekte für PowerPoint‑Formen und -Text. Er befasst sich nicht mit dem Einfügen oder Bearbeiten eigenständiger 3D‑Modelldateien. Wenn Sie eine Folie in ein Bild, PDF oder HTML exportieren, rendert Aspose.Slides diese 3D‑Effekte in die exportierte 2D‑Ausgabe.
{{% /alert %}}

## **3D-Formatierungskonzepte**

Verwenden Sie die [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_threedformat/) Methode, um eine 3D‑Formatierung auf eine Form anzuwenden. Die Methode gibt ein [IThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/) zurück, das die 3D‑Szene für diese Form steuert.

Für Text verwenden Sie die [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/get_threedformat/) Methode. Diese wendet die 3D‑Formatierung auf den Textrahmen anstelle des Formkörpers an.

Die wichtigsten Methoden sind:

| Methode | Was es steuert | Wann es zu verwenden ist |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_camera/) | Ansichtspunkt, voreingestellter Kameratyp, Drehung, Zoom und Perspektive. | Drehen Sie das Objekt im 3D‑Raum oder passen Sie es an eine PowerPoint‑3D‑Drehvorgabe an. |
| [get_LightRig](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_lightrig/) | Lichtvoreinstellung, Richtung und Lichtdrehung. | Ändern Sie, wie Hervorhebungen und Schatten auf der 3D‑Oberfläche erscheinen. |
| [set_Material](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_material/) | Oberflächenmaterial, z. B. flach, matt, Kunststoff oder Metall. | Lassen Sie dieselbe Geometrie flacher, weicher, glänzender oder metallisch aussehen. |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | Wie weit die Form von ihrer Vorderseite nach hinten reicht. | Verwandeln Sie eine flache Form in ein deutlich dickes 3D‑Objekt. |
| [get_ExtrusionColor](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | Farbe der extrudierten Seiten. | Machen Sie die Tiefe sichtbar oder stimmen Sie die Seitenfarbe mit der Vorderfüllung ab. |
| [set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_depth/) | Zusätzliche 3D‑Tiefe, die von der PowerPoint‑3D‑Formatierung verwendet wird. | Passen Sie die Tiefe für Formen oder Text fein an, insbesondere zusammen mit Abschrägungs‑ und Materialeinstellungen. |
| [get_BevelTop](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_beveltop/) und [get_BevelBottom](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | Erhöhte oder abgerundete Kanten an Vorder‑ und Rückseiten. | Fügen Sie eine abgeflachte oder geformte Kante statt einer scharfen flachen Fläche hinzu. |
| [get_ContourColor](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_contourcolor/) und [set_ContourWidth](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_contourwidth/) | Umriss um das 3D‑Objekt. | Betonen Sie die Objektgrenze in der gerenderten Ausgabe. |

## **Erstellen einer 3D-Form**

Eine Form benötigt in der Regel vier Arten von Einstellungen, bevor sie überzeugend 3D wirkt:

- Kameraeinstellungen, weil die Standardvorderansicht die Extrusion verbergen kann.
- Lichteinstellungen, da Beleuchtung die Flächen und Seiten lesbar macht.
- Materialeinstellungen, weil die Oberfläche beeinflusst, wie Licht gerendert wird.
- Extrusions‑ oder Tiefe‑Einstellungen, weil eine flache Form Dicke benötigt.

Das folgende Beispiel erzeugt ein Rechteck, fügt seiner Vorderseite Text hinzu und wendet 3D‑Formatierung an. Die Kameradrehwerte sind in Grad angegeben, und die Extrusionshöhe beträgt 100 Punkte. Das Beispiel rendert die Folie zu einem PNG‑Bild mit doppelt so großen Standardabmessungen und speichert die Präsentation als PPTX.

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

## **Eine Form mit der Kamera rotieren**

In PowerPoint wird die 3D‑Drehung über das Fenster „3‑D‑Drehung“ konfiguriert. Die X‑, Y‑ und Z‑Drehwerte entsprechen der Drehung, die Sie über die Kamera‑API festlegen.

![PowerPoint‑Fenster „3‑D‑Drehung“ mit hervorgehobenen X‑, Y‑ und Z‑Drehwerten](img_02_01.png)

In Aspose.Slides greifen Sie über [IThreeDFormat::get_Camera](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_camera/) auf die Kamera zu. Dieses Beispiel erstellt ein Rechteck, wählt eine orthografische Vorderansicht und setzt seine X‑, Y‑ und Z‑Drehungen auf 20, 30 bzw. 40 Grad. Es konfiguriert die Form im Speicher, ohne eine Datei zu speichern:

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

Verwenden Sie die Kamera, wenn Sie ändern müssen, wie der Betrachter das Objekt sieht. Sie ändert nicht die 2D‑Formgeometrie auf der Folie. Sie ändert den 3D‑Blickpunkt, den PowerPoint und Aspose.Slides beim Rendern verwenden.

### **Kameraausrichtung von einer Vorlagenform kopieren**

Um die Kameraausrichtung einer Vorlagenform zu übernehmen, lesen Sie deren Vorgabe mit [get_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/get_cameratype/) und wenden Sie sie mit [set_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/set_cameratype/) an. Das Beispiel öffnet `template.pptx` und kopiert die Kameraausrichtung von der ersten Form auf der ersten Folie zur zweiten Form. Beide Formen besitzen bereits 3D‑Beleuchtung, und die zweite Form hat keine explizite Kameradrehung.

[GetRotation](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/getrotation/) gibt die Winkel in Grad zurück. Index `0` ist die Breite, Index `1` die Länge und Index `2` die Umdrehung. Übergaben Sie die Winkel in dieser Reihenfolge an [SetRotation](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/setrotation/). Hat die Quelle keine explizite Drehung, gibt `GetRotation` einen Null‑Pointer zurück, sodass die Winkel der zweiten Form unverändert bleiben. Eine explizite Drehung von `(0, 0, 0)` liefert ein Array aus drei Nullen und sollte kopiert werden.

```cpp
#include <DOM/ICamera.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);

auto sourceCamera = slide->get_Shape(0)->get_ThreeDFormat()->get_Camera();
auto destinationCamera = slide->get_Shape(1)->get_ThreeDFormat()->get_Camera();

destinationCamera->set_CameraType(sourceCamera->get_CameraType());
auto angles = sourceCamera->GetRotation();
if (angles != nullptr)
{
    destinationCamera->SetRotation(angles[0], angles[1], angles[2]);
}

presentation->Save(u"camera-copy.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Wenn Sie `camera-copy.pptx` in PowerPoint erneut öffnen, hat der Pfeil rechts dieselbe Kamera‑Vorgabe und Drehung wie das Rechteck links. Beide Formen verwenden dieselbe Beleuchtung und Extrusionstiefe.

![Ein blaues 3D‑Rechteck und ein nach rechts zeigender Pfeil mit übereinstimmender Kameraausrichtung, von oben und rechts betrachtet](camera-orientation.png)

## **Extrusion und Tiefe hinzufügen**

Extrusion lässt eine Form dick wirken, indem sie hinter die Vorderfläche verlängert wird. In PowerPoint legt die Tiefensteuerung diese sichtbare Dicke fest, und die Farbsteuerung legt die Farbe der Seitenflächen fest.

![PowerPoint‑Tiefensteuerungen, zugeordnet zu Extrusionsfarbe und Extrusionshöhe‑Eigenschaften](img_02_02.png)

Setzen Sie [IThreeDFormat::set_ExtrusionHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_extrusionheight/) für die Dicke und [IThreeDFormat::get_ExtrusionColor](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) für die Seitenfarbe. Dieses Beispiel gibt einem Rechteck eine 100‑Punkte‑Extrusion mit violetten Seiten und dreht die Kamera, um die Dicke sichtbar zu machen. Es konfiguriert die Form im Speicher, ohne eine Datei zu speichern:

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

Die Methode [IThreeDFormat::set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_depth/) legt die Tiefe einer 3D‑Form fest. Die Methode [set_ExtrusionHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_extrusionheight/) steuert die Höhe des Extrusionseffekts, wie in diesem Beispiel gezeigt.

## **Verlauf- oder Bildfüllungen mit 3D-Effekten verwenden**

Die 3D‑Formatierung ist unabhängig von der Formfüllung. Sie können der Vorderfläche eine einfarbige, Verlauf-, Muster- oder Bildfüllung zuweisen und dennoch dieselbe Kamera, Beleuchtung, Material‑ und Extrusionseinstellungen verwenden.

Dieses Beispiel wendet einen Blau‑zu‑Orange‑Verlauf auf die Vorderfläche und eine dunkelorange Farbe auf die 150‑Punkte‑Extrusion an. Die Verlaufsstopps bei 0 % bzw. 100 % markieren Anfang und Ende des Verlaufs. Die Kameradrehwerte sind in Grad angegeben. Die Folie wird zu einem PNG‑Bild mit doppelter Standardgröße gerendert:

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

![Gerendertes 3D‑Rechteck mit einem Blau‑zu‑Orange‑Verlauf und orangefarbener Extrusion](img_02_03.png)

Um stattdessen eine Bildfüllung zu verwenden, fügen Sie das Bild der Präsentation hinzu und weisen es der Formfüllung zu. Dieses Beispiel erfordert eine vorhandene Datei namens "image.jpg" im Arbeitsverzeichnis. Es streckt das Bild, um das Rechteck zu füllen, wendet eine 150‑Punkte‑Extrusion an und setzt die Kameradrehung in Grad. Es konfiguriert die Form im Speicher, ohne eine Datei zu speichern oder zu rendern:

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

![Gerendertes 3D‑Rechteck mit Fotofüllung auf der Vorderseite und orangefarbener Extrusion](img_02_04.png)

## **3D-Formatierung auf Text anwenden**

Die 3D‑Formatierung einer Form wirkt sich auf den Formkörper aus. Die 3D‑Formatierung von Text wirkt sich auf den Textrahmen aus. Das ist nützlich für WordArt‑ähnliche Effekte, bei denen die Buchstaben selbst Extrusion, Material, Beleuchtung und Kamera‑Einstellungen benötigen.

Das folgende Beispiel erzeugt Text mit einem orange‑weiß gestreiften Muster, wendet einen Aufwärtsbogen an und konfiguriert 3D‑Einstellungen über [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/get_threedformat/). Die Extrusionshöhe und Tiefe werden in Punkten angegeben, die Lichtdrehung in Grad. Die Formfüllung und Kontur werden ausgeblendet, sodass nur der Text sichtbar ist. Das Beispiel rendert ein PNG‑Bild mit doppelter Standardfoliengröße und speichert die Präsentation als PPTX:

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

![Gerenderter 3D‑Text mit einem gewölbten WordArt‑Transform, orangefarbiger Mustelfüllung und dunkler Extrusion](img_02_05.png)

## **Text flach auf einer 3D-Form halten**

Um Text lesbar zu halten und gleichzeitig das 3D‑Erscheinungsbild einer Form beizubehalten, rufen Sie [ITextFrameFormat::set_KeepTextFlat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_keeptextflat/) über [ITextFrame::get_TextFrameFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_textframeformat/) auf. Ist der Wert `true`, bleibt der Text außerhalb der 3D‑Szene. Ist er `false`, nimmt der Text an der Szene teil und folgt ihrer 3D‑Ausrichtung.

Diese Einstellung entfernt nicht die 3D‑Formatierung der Form: Kamera, Beleuchtung, Material und Extrusion bleiben über [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_threedformat/) konfiguriert. Sie unterscheidet sich zudem von einer normalen Drehung. [IShape::set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_rotation/) dreht die Form in der Folienebene, während [ITextFrameFormat::set_RotationAngle](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_rotationangle/) die benutzerdefinierte Drehung des Textes innerhalb seines Begrenzungsrahmens steuert. Das Ausbleiben des Textes in der 3D‑Szene setzt keine dieser Winkel zurück.

Das folgende eigenständige Beispiel erzeugt ein blaues Rechteck mit Text und dupliziert es neben dem Original. Beide Formen besitzen dieselbe 3D‑Formatierung; nur die Texteinstellung unterscheidet sich: `false` links und `true` rechts. Die Kamerawinkel werden in Grad angegeben, die Extrusionshöhe beträgt 40 Punkte. Das Beispiel speichert die Präsentation als PPTX und rendert die Vergleichsfolie zu einem PNG mit doppelter Standardgröße.

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

Links folgt der Text der 3D‑Ausrichtung. Rechts bleibt er flach und leichter lesbar. Beide Rechtecke behalten dieselbe sichtbare Extrusion und 3D‑Ausrichtung bei.

![Nebeneinander stehende 3D‑Rechtecke: KeepTextFlat ist links false und rechts true](keep_text_flat.png)

## **Export- und Renderingverhalten**

Aspose.Slides bewahrt die 3D‑Formatierung beim Speichern in PowerPoint‑Formaten wie PPTX. Beim Rendern oder Exportieren in feste Layout‑Formate wird die 3D‑Szene rasterisiert oder in das Ergebnis als 2D‑Ausgabe gezeichnet. Dies gilt, wenn Sie Folien zu [PNG](/slides/de/cpp/convert-powerpoint-to-png/), [PDF](/slides/de/cpp/convert-powerpoint-to-pdf/), [HTML](/slides/de/cpp/convert-powerpoint-to-html/) rendern oder Frames für [video conversion](/slides/de/cpp/convert-powerpoint-to-video/) erzeugen.

Beachten Sie folgende Punkte:

- Exportierte Bilder und PDFs sind nicht interaktiv. Das Objekt kann nach dem Export nicht vom Betrachter rotiert werden.
- Das endgültige Aussehen hängt von der Kombination aus Kamera, Light‑Rig, Material, Extrusion, Füllung und Folien­skalierung ab.
- Wenn Sie vererbte oder themenbasierte Formatierungswerte prüfen müssen, lesen Sie die [effektiven Formeigenschaften](/slides/de/cpp/shape-effective-properties/).
- Einige Ausgabformate können die editierbare PowerPoint‑3D‑Formatierung nicht speichern. In diesen Formaten wird das visuelle Ergebnis gerendert anstatt als editierbare 3D‑Einstellungen erhalten zu bleiben.

## **FAQ**

**Kann Aspose.Slides interaktive 3D‑Präsentationen erstellen?**

Aspose.Slides erstellt und rendert PowerPoint‑3D‑Effekte für Formen und Text. Es macht exportierte Bilder, PDFs oder HTML‑Seiten nicht zu interaktiven 3D‑Szenen, die ein Betrachter rotieren kann. In PPTX bleibt die 3D‑Formatierung in PowerPoint editierbar, sofern das Format dies unterstützt.

**Was ist der Unterschied zwischen einem 3D‑Modell und einem 3D‑Effekt?**

Ein 3D‑Modell ist ein separates 3D‑Objekt, das in eine Präsentation eingefügt wird. Ein 3D‑Effekt ist eine Formatierung, die auf eine reguläre PowerPoint‑Form oder -Text angewendet wird, etwa Drehung, Extrusion, Abschrägung, Beleuchtung und Material. Dieser Artikel behandelt 3D‑Effekte.

**Welche Einstellungen sind für eine sichtbare 3D‑Form erforderlich?**

Mindestens müssen Sie eine Kameradrehung sowie entweder Extrusion oder Tiefe festlegen. In der Praxis sollten Sie außerdem ein Light‑Rig und Material einstellen, damit die gerenderten Flächen klare Highlights und Schatten aufweisen.

**Kann ich 3D‑Effekte sowohl auf Formen als auch auf Text anwenden?**

Ja. Verwenden Sie [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_threedformat/) für den Formkörper und [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/get_threedformat/) für Text.

**Werden 3D‑Effekte beim Export in Bilder, PDF, HTML oder Videoframes erscheinen?**

Ja. Aspose.Slides rendert 3D‑Effekte beim Erzeugen von Folienbildern, PDF‑Ausgabe, HTML‑Ausgabe und Frames, die für die Videokonvertierung verwendet werden. Die exportierte Ausgabe enthält das gerenderte Erscheinungsbild, jedoch kein editierbares 3D‑Objekt.

**Kann ich die endgültigen 3D‑Werte nach Vererbung und Anwendung von Theme‑Einstellungen auslesen?**

Ja. Verwenden Sie die APIs für effektive Formatierung, die in [Effektive Formeigenschaften](/slides/de/cpp/shape-effective-properties/) beschrieben werden, um die endgültigen Werte für Kamera, Light‑Rig, Abschrägung und verwandte 3D‑Parameter auszulesen.