---
title: 3D-Effekte in Präsentationen mit C++
linktitle: 3D-Präsentation
type: docs
weight: 232
url: /de/cpp/3d-presentation/
keywords:
- 3D PowerPoint
- 3D Präsentation
- 3D Drehung
- 3D Tiefe
- 3D Extrusion
- 3D Farbverlauf
- 3D Text
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Wenden Sie 3D-Effekte für PowerPoint-Formen und -Text in C++ mit Aspose.Slides an und rendern Sie sie. Konfigurieren Sie Kamera, Beleuchtung, Material, Extrusion, Füllungen und 3D-Text."
---
## **Übersicht**

Aspose.Slides für C++ kann PowerPoint‑ähnliche 3D‑Formatierung für Formen und Text erstellen, bearbeiten, erhalten und rendern. Dieser Artikel behandelt 3D‑Effekte wie Drehung, Extrusion, Abschrägungen, Beleuchtung, Material, Farbverlauf‑ oder Bildfüllungen und 3D‑Text.

{{% alert color="primary" %}}

Dieser Artikel behandelt 3D‑Formatierungseffekte für PowerPoint‑Formen und -Text. Es geht nicht um das Einfügen oder Bearbeiten von eigenständigen 3D‑Modelldateien. Wenn Sie eine Folie in ein Bild, PDF oder HTML exportieren, rendert Aspose.Slides diese 3D‑Effekte in das exportierte 2D‑Ergebnis.

{{% /alert %}}

## **Konzepte der 3D‑Formatierung**

Verwenden Sie die Schnittstelle [IShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/) und deren Methode [get_ThreeDFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/get_threedformat/), um einer Form 3D‑Formatierung zuzuweisen. Die Methode liefert ein [IThreeDFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/ithreedformat/), das die 3D‑Szene für diese Form steuert.

Für Text verwenden Sie die Schnittstelle [ITextFrameFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframeformat/) und deren Methode [get_ThreeDFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframeformat/get_threedformat/). Diese wendet die 3D‑Formatierung auf den Textrahmen anstelle des Formkörpers an.

Die wichtigsten Methoden sind:

| Methode | Was sie steuert | Wann zu verwenden |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/de/cpp/aspose.slides/ithreedformat/get_camera/) | Ansichtspunkt, voreingestellter Kameratyp, Drehung, Zoom und Perspektive. | Drehen Sie das Objekt im 3D‑Raum oder passen Sie es an eine vordefinierte PowerPoint‑3D‑Drehung an. |
| [get_LightRig](https://reference.aspose.com/slides/de/cpp/aspose.slides/ithreedformat/get_lightrig/) | Lichtvoreinstellung, Richtung und Lichtrotation. | Ändern Sie, wie Hervorhebungen und Schatten auf der 3D‑Oberfläche erscheinen. |
| [set_Material](https://reference.aspose.com/slides/de/cpp/aspose.slides/ithreedformat/set_material/) | Oberflächenmaterial, z. B. flach, matt, Kunststoff oder Metall. | Lassen Sie dieselbe Geometrie flacher, weicher, glänzender oder metallisch wirken. |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/de/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | Wie weit die Form von ihrer Vorderseite nach hinten ausgedehnt wird. | Verwandeln Sie eine flache Form in ein sichtbar dickes 3D‑Objekt. |
| [get_ExtrusionColor](https://reference.aspose.com/slides/de/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | Farbe der extrudierten Seiten. | Machen Sie die Tiefe sichtbar oder stimmen Sie die Seitenfarbe mit der Vordergrundfüllung ab. |
| [set_Depth](https://reference.aspose.com/slides/de/cpp/aspose.slides/ithreedformat/set_depth/) | Zusätzliche 3D‑Tiefe, die von der PowerPoint‑3D‑Formatierung verwendet wird. | Feinabstimmung der Tiefe für Formen oder Text, insbesondere in Kombination mit Abschrägung‑ und Materialeinstellungen. |
| [get_BevelTop](https://reference.aspose.com/slides/de/cpp/aspose.slides/ithreedformat/get_beveltop/) und [get_BevelBottom](https://reference.aspose.com/slides/de/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | Erhöhte oder abgerundete Kanten an Vorder- und Rückseiten. | Fügen Sie eine abgerundete oder geformte Kante hinzu, anstatt einer scharfen flachen Fläche. |
| [get_ContourColor](https://reference.aspose.com/slides/de/cpp/aspose.slides/ithreedformat/get_contourcolor/) und [set_ContourWidth](https://reference.aspose.com/slides/de/cpp/aspose.slides/ithreedformat/set_contourwidth/) | Umriss um das 3D‑Objekt. | Betonen Sie die Objektgrenze in der gerenderten Ausgabe. |

## **Erstelle eine 3D‑Form**

Eine Form benötigt gewöhnlich vier Arten von Einstellungen, bevor sie überzeugend 3D wirkt:

- Kameraeinstellungen, da die Standard‑Frontansicht die Extrusion verdecken kann.
- Lichteinstellungen, da Beleuchtung die Flächen und Seiten lesbar macht.
- Materialeinstellungen, da die Oberfläche beeinflusst, wie Licht gerendert wird.
- Extrusions‑ oder Tiefeinstellungen, da einer flachen Form Dicke fehlt.

Das folgende Beispiel erstellt ein Rechteck, fügt Text zu seiner Vorderfläche hinzu, wendet 3D‑Formatierung an, speichert die Präsentation als PPTX und rendert die Folie zu einem PNG‑Bild.



Das gerenderte Folienbild zeigt das Rechteck als dicken 3D‑Block:

![Gerendertes blaues 3D‑Rechteck mit weißem 3D‑Text auf der Vorderfläche](img_01_01.png)

## **Drehen einer Form mit der Kamera**

In PowerPoint wird die 3D‑Drehung im Bereich 3‑D‑Drehung konfiguriert. Die X‑, Y‑ und Z‑Drehwerte entsprechen der Drehung, die Sie über die Kamera‑API festlegen.

![PowerPoint‑3‑D‑Drehungsbereich mit hervorgehobenen X‑, Y‑ und Z‑Drehwerten](img_02_01.png)

In Aspose.Slides setzen Sie den Kameratyp und die Drehung über [IThreeDFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/ithreedformat/):

```cpp
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
```

Verwenden Sie die Kamera, wenn Sie ändern müssen, wie der Betrachter das Objekt sieht. Sie ändert nicht die 2D‑Formgeometrie auf der Folie. Sie ändert den 3D‑Blickpunkt, den PowerPoint und Aspose.Slides beim Rendern verwenden.

## **Extrusion und Tiefe hinzufügen**

Extrusion lässt eine Form durch Verlängerung hinter die Vorderfläche dick wirken. In PowerPoint legt die Tiefensteuerung diese sichtbare Dicke fest, und die Farbstoffsteuerung bestimmt die Farbe der Seitenflächen.

![PowerPoint‑Tiefensteuerungen, die den Extrusionsfarbe‑ und Extrusionshöhe‑Eigenschaften zugeordnet sind](img_02_02.png)

Setzen Sie [set_ExtrusionHeight](https://reference.aspose.com/slides/de/cpp/aspose.slides/ithreedformat/set_extrusionheight/) für die Dicke und [get_ExtrusionColor](https://reference.aspose.com/slides/de/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) für die Seitenfarbe:

```cpp
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);

auto extrusionColor = System::Drawing::Color::get_Purple();
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);
```

Verwenden Sie [set_Depth](https://reference.aspose.com/slides/de/cpp/aspose.slides/ithreedformat/set_depth/), wenn Sie den PowerPoint‑Tiefenwert direkt bearbeiten oder die Tiefe mit Abschrägung, Material und Texteffekten kombinieren müssen. In vielen Form‑Szenarien ist `set_ExtrusionHeight` die klarere Einstellung, weil sie die sichtbare Extrusion direkt ausdrückt.

## **Verwenden von Farbverlauf‑ oder Bildfüllungen mit 3D‑Effekten**

Die 3D‑Formatierung ist unabhängig von der Formfüllung. Sie können eine Volltonfarbe, einen Farbverlauf, ein Muster oder eine Bildfüllung auf die Vorderfläche anwenden und dennoch dieselben Kamera‑, Licht‑, Material‑ und Extrusionseinstellungen nutzen.

Dieses Beispiel wendet einen Farbverlauf auf die Form an und eine dunklere Extrusionsfarbe an den Seiten:

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

![Gerendertes 3D‑Rechteck mit einem blau‑zu‑orangefarbenen Farbverlauf und orangefarbener Extrusion](img_02_03.png)

Um stattdessen eine Bildfüllung zu verwenden, fügen Sie das Bild zur Präsentation hinzu und weisen es der Formfüllung zu:

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

![Gerendertes 3D‑Rechteck mit einer Fotofüllung auf der Vorderfläche und orangefarbener Extrusion](img_02_04.png)

## **3D‑Formatierung auf Text anwenden**

Die 3D‑Formatierung von Formen wirkt auf den Formkörper. Die 3D‑Formatierung von Text wirkt auf den Textrahmen. Das ist nützlich für WordArt‑ähnliche Effekte, bei denen die Buchstaben selbst Extrusion, Material, Beleuchtung und Kameraeinstellungen benötigen.

Das folgende Beispiel erstellt Text mit einer Musterfüllung, wendet eine WordArt‑Transformation an und konfiguriert 3D‑Einstellungen auf [ITextFrameFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframeformat/):

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

![Gerenderter 3D‑Text mit einer gebogenen WordArt‑Transformation, orangefarbiger Musterfüllung und dunkler Extrusion](img_02_05.png)

## **Export‑ und Renderverhalten**

Aspose.Slides erhält die 3D‑Formatierung beim Speichern in PowerPoint‑Formate wie PPTX. Beim Rendern oder Exportieren in feste Layout‑Formate wird die 3D‑Szene rasterisiert oder als 2D‑Ergebnis in die Ausgabe gezeichnet. Dies gilt, wenn Sie Folien zu [PNG](/slides/de/cpp/convert-powerpoint-to-png/) rendern, zu [PDF](/slides/de/cpp/convert-powerpoint-to-pdf/) exportieren, zu [HTML](/slides/de/cpp/convert-powerpoint-to-html/) exportieren oder Frames für die [video conversion](/slides/de/cpp/convert-powerpoint-to-video/) erzeugen.

Beachten Sie folgende Punkte:

- Exportierte Bilder und PDFs sind nicht interaktiv. Das Objekt kann nach dem Export nicht mehr vom Betrachter rotiert werden.
- Das endgültige Erscheinungsbild hängt von der Kombination aus Kamera, Lichtanlage, Material, Extrusion, Füllung und Folienvergrößerung ab.
- Wenn Sie vererbte oder themenbasierte Formatierungswerte prüfen müssen, lesen Sie die [effektiven Formeigenschaften](/slides/de/cpp/shape-effective-properties/).
- Einige Ausgabformate können die editierbare PowerPoint‑3D‑Formatierung nicht speichern. In diesen Formaten wird das visuelle Ergebnis gerendert, anstatt als editierbare 3D‑Einstellungen erhalten zu bleiben.

## **FAQ**

**Kann Aspose.Slides interaktive 3D‑Präsentationen erstellen?**

Aspose.Slides erzeugt und rendert PowerPoint‑3D‑Effekte für Formen und Text. Es macht exportierte Bilder, PDFs oder HTML‑Seiten jedoch nicht zu interaktiven 3D‑Szenen, die ein Betrachter rotieren kann. In PPTX bleibt die 3D‑Formatierung in PowerPoint editierbar, sofern das Format dies unterstützt.

**Was ist der Unterschied zwischen einem 3D‑Modell und einem 3D‑Effekt?**

Ein 3D‑Modell ist ein separates 3D‑Objekt, das in eine Präsentation eingefügt wird. Ein 3D‑Effekt ist eine Formatierung, die auf eine normale PowerPoint‑Form oder auf Text angewendet wird, beispielsweise Drehung, Extrusion, Abschrägung, Beleuchtung und Material. Dieser Artikel behandelt 3D‑Effekte.

**Welche Einstellungen sind für eine sichtbare 3D‑Form erforderlich?**

Mindestens müssen Sie eine Kameradrehung und entweder Extrusion oder Tiefe festlegen. In der Praxis sollten Sie zudem eine Lichtanlage und ein Material einstellen, damit die gerenderten Flächen klare Licht‑ und Schattenpunkte erhalten.

**Kann ich 3D‑Effekte sowohl auf Formen als auch auf Text anwenden?**

Ja. Verwenden Sie [IShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/) , um den Formkörper zu bearbeiten, und [ITextFrameFormat](https://reference.aspose.com/slides/de/cpp/aspose.slides/itextframeformat/), um Text zu formatieren.

**Werden 3D‑Effekte beim Exportieren zu Bildern, PDF, HTML oder Video‑Frames angezeigt?**

Ja. Aspose.Slides rendert 3D‑Effekte beim Erzeugen von Folien‑Bildern, PDF‑Ausgaben, HTML‑Ausgaben und bei den für die Videokonvertierung erzeugten Frames. Das exportierte Ergebnis enthält das gerenderte Erscheinungsbild, jedoch kein editierbares 3D‑Objekt.

**Kann ich die endgültigen 3D‑Werte nach Anwendung von Vererbung und Themen‑Einstellungen auslesen?**

Ja. Verwenden Sie die APIs für effektive Formatierung, die in [effektiven Formeigenschaften](/slides/de/cpp/shape-effective-properties/) beschrieben sind, um die endgültigen Werte für Kamera, Lichtanlage, Abschrägung und zugehörige 3D‑Parameter auszulesen.