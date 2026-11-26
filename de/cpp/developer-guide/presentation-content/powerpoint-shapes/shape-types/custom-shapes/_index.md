---
title: Präsentationsformen in C++ anpassen
linktitle: Benutzerdefinierte Form
type: docs
weight: 20
url: /de/cpp/custom-shape/
keywords:
- benutzerdefinierte Form
- Form hinzufügen
- Form erstellen
- Form ändern
- Formgeometrie
- Geometriepfad
- Pfadpunkte
- Bearbeitungspunkte
- Punkt hinzufügen
- Punkt entfernen
- Bearbeitungsoperation
- abgerundete Ecke
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Erstellen und Anpassen von Formen in PowerPoint-Präsentationen mit Aspose.Slides für C++: Geometriepfade, abgerundete Ecken, zusammengesetzte Formen."
---
## **Übersicht**

Dieser Artikel erklärt, wie Sie Präsentationsformen in Aspose.Slides anpassen können, indem Sie die Formgeometrie über Edit Points und Geometriepfade bearbeiten. Er zeigt, wie Sie mit [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) und [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/) arbeiten, um vorhandene Formen zu ändern, grundlegende Pfadbearbeitungsoperationen durchzuführen, Punkte hinzuzufügen oder zu entfernen und die aktualisierte Geometrie wieder auf eine Form anzuwenden.

Er demonstriert außerdem, wie benutzerdefinierte und zusammengesetzte Formen erstellt werden, wie Formen mit abgerundeten Ecken gebaut werden und wie ermittelt wird, ob eine Formgeometrie geschlossen ist.

## **Form mit Bearbeitungspunkten ändern**

In PowerPoint können Sie **Edit Points** verwenden, um ein Quadrat zu verändern:

* Einen Eckpunkt nach innen oder außen verschieben.
* Die Krümmung an einem Punkt anpassen.
* Neue Punkte hinzufügen.

Das Bearbeiten von Punkten ermöglicht es Ihnen, die Kontur einer Form zu ändern oder eine bestehende Form als Basis für eine neue zu nutzen.

## **Tipps zur Formbearbeitung**

![overview_image](custom_shape_0.png)

Beim Bearbeiten von PowerPoint‑Formen sollten Sie folgende Konzepte berücksichtigen:

* Eine Form (oder ihr Pfad) kann entweder geschlossen oder offen sein.
* Der Pfad einer Form besteht aus Ankerpunkten, die durch Segmente verbunden sind.
* Ein Segment kann gerade oder gekrümmt sein. Ankerpunkte und Steuer‑Handles bestimmen seine Form.
* Ankerpunkte existieren als Eckpunkte, gerade Punkte oder glatte Punkte:
  * An einem Eckpunkt können benachbarte Segmente einen Winkel bilden.
  * An einem glatten Punkt sind die beiden Steuer‑Handles ausgerichtet und gleich weit vom Ankerpunkt entfernt.
  * An einem geraden Punkt sind die beiden Steuer‑Handles ausgerichtet, können aber unterschiedliche Abstände vom Ankerpunkt haben.
* Das Verschieben von Ankerpunkten oder das Anpassen ihrer Handles ändert die Kontur der Form.

Um PowerPoint‑Formen über Edit Points zu bearbeiten, stellt **Aspose.Slides** die Klasse [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) und das Interface [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/) bereit.

* Eine [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/)-Instanz repräsentiert einen Geometriepfad des [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/)-Objekts.
* Um den [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) von einer [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/)-Instanz zu erhalten, können Sie die Methode [IGeometryShape::GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/) verwenden.
* Um den [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) für eine Form festzulegen, können Sie diese Methoden benutzen: [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) für Formen mit einem einzelnen Pfad und [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) für Formen mit mehreren Pfaden.
* Um Segmente hinzuzufügen, können Sie die Methoden unter [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/) verwenden.
* Mit den Methoden [IGeometryPath::set_Stroke](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_stroke/) und [IGeometryPath::set_FillMode](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_fillmode/) können Sie das Aussehen eines Geometriepfads festlegen.
* Mit der Methode [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) können Sie den Geometriepfad einer [GeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/geometryshape/) als Array von Pfadsegmenten abrufen.

## **Einfache Bearbeitungsoperationen**

Verwenden Sie die folgenden Methoden, um einen Geometriepfad zu bearbeiten. Überladungen, die einen Index akzeptieren, fügen ein Segment an dieser nullbasierten Position im Segment‑Array des Pfads ein.

| Operation | Methode |
| --- | --- |
| Eine gerade Linie anhängen oder einfügen. | [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) |
| Eine kubische Bézier‑Kurve mit zwei Steuerpunkten und einem Endpunkt anhängen oder einfügen. | [GeometryPath::CubicBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/cubicbezierto/) |
| Eine quadratische Bézier‑Kurve mit einem Steuerpunkt und einem Endpunkt anhängen oder einfügen. | [GeometryPath::QuadraticBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/quadraticbezierto/) |
| Einen elliptischen Bogen mit den angegebenen Abmessungen und Winkeln in Grad anhängen. | [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/) |
| Die aktuelle Figur schließen, indem ihr Endpunkt mit dem Startpunkt verbunden wird. | [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) |
| Den Startpunkt einer Figur festlegen. | [GeometryPath::MoveTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/moveto/) |
| Ein Segment bei einem nullbasierten Index entfernen. | [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/) |

## **Benutzerdefinierte Punkte zu einer Form hinzufügen**

Dieses Beispiel fügt einer rechteckigen Form zwei Punkte mithilfe von [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) ein und wendet den bearbeiteten Pfad mit [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) an. Die Koordinaten sind relativ zur Form: Beide neuen Punkte liegen in der Mitte, 100 Punkte vom linken Rand und 50 Punkte vom oberen Rand entfernt. Die Segment‑Indizes 1 und 4 positionieren sie an den oberen bzw. unteren Kanten und ziehen diese Kanten nach innen.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 200.0f, 100.0f);

auto geometryPath = shape->GetGeometryPaths()->idx_get(0);
geometryPath->LineTo(100.0f, 50.0f, 1);
geometryPath->LineTo(100.0f, 50.0f, 4);

shape->SetGeometryPath(geometryPath);
```

![example1_image](custom_shape_1.png)

## **Punkte aus einer Form entfernen**

Dieses Beispiel verändert die Kontur einer herzförmigen Form, indem das Segment am nullbasierten Index 2 mit [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/) entfernt wird. Durch Anwenden des modifizierten Pfads mit [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) wird die Kontur der Form aktualisiert.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Heart, 100.0f, 100.0f, 300.0f, 300.0f);

auto path = shape->GetGeometryPaths()->idx_get(0);
path->RemoveAt(2);

shape->SetGeometryPath(path);
```
![example2_image](custom_shape_2.png)

## **Benutzerdefinierte Form erstellen**

Dieses Beispiel erzeugt einen fünfzackigen Stern mit [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/). Wechselnde äußere und innere Radien von 100 bzw. 50 Punkten definieren die Spitzen und Einziehungen; ein Schritt von 72 Grad verteilt die fünf Spitzen gleichmäßig. Der Pfad wird mit [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) geschlossen und mit [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) auf eine rechteckige Form angewendet, wodurch deren Kontur ersetzt wird.

```cpp
#include <DOM/GeometryPath.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/point_f.h>
#include <system/collections/list.h>
#include <system/math.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::Drawing;

auto points = System::MakeObject<List<PointF>>();

auto outerRadius = 100.0f;
auto innerRadius = 50.0f;
auto angleStep = 72;

for (auto angle = -90; angle < 270; angle += angleStep)
{
    auto radians = angle * (Math::PI / 180.f);
    auto x = outerRadius * Math::Cos(radians);
    auto y = outerRadius * Math::Sin(radians);
    points->Add(PointF((float)x + outerRadius, (float)y + outerRadius));

    radians = Math::PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math::Cos(radians);
    y = innerRadius * Math::Sin(radians);
    points->Add(PointF((float)x + outerRadius, (float)y + outerRadius));
}

auto starPath = System::MakeObject<GeometryPath>();
starPath->MoveTo(points->idx_get(0));

for (auto i = 1; i < points->get_Count(); i++)
{
    starPath->LineTo(points->idx_get(i));
}

starPath->CloseFigure();

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, outerRadius * 2, outerRadius * 2);
shape->SetGeometryPath(starPath);
```
![example3_image](custom_shape_3.png)

## **Zusammengesetzte benutzerdefinierte Form erstellen**

Dieses Beispiel definiert zwei geschlossene [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/)-Objekte für das obere und untere Drittel einer Form. Durch Anwenden beider Pfade mit [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) entsteht eine einzelne zusammengesetzte Form mit einer Lücke im mittleren Drittel.

```cpp
#include <DOM/GeometryPath.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 200.0f, 100.0f);

auto topPath = System::MakeObject<GeometryPath>();
topPath->MoveTo(0.0f, 0.0f);
topPath->LineTo(shape->get_Width(), 0.0f);
topPath->LineTo(shape->get_Width(), shape->get_Height() / 3);
topPath->LineTo(0.0f, shape->get_Height() / 3);
topPath->CloseFigure();

auto bottomPath = System::MakeObject<GeometryPath>();
bottomPath->MoveTo(0.0f, shape->get_Height() / 3 * 2);
bottomPath->LineTo(shape->get_Width(), shape->get_Height() / 3 * 2);
bottomPath->LineTo(shape->get_Width(), shape->get_Height());
bottomPath->LineTo(0.0f, shape->get_Height());
bottomPath->CloseFigure();

auto paths = System::MakeArray<SharedPtr<IGeometryPath>>({ topPath, bottomPath });

shape->SetGeometryPaths(paths);
```
![example4_image](custom_shape_4.png)

## **Benutzerdefinierte Form mit abgerundeten Ecken erstellen**

Dieses Beispiel kombiniert gerade Segmente mit [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/), um eine Form mit nach innen gekrümmten Ecken zu erzeugen. Jeder Eckradius legt die Breite und Höhe des Bogens in Punkten fest, und der -90‑Grad‑Winkel zeichnet ein gegen den Uhrzeigersinn gedrehtes Viertel‑Ellipse. Der fertige Pfad wird mit [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) angewendet, und die Präsentation wird im PPTX‑Format gespeichert.

```cpp
#include <DOM/GeometryPath.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto shapeX = 20.f;
auto shapeY = 20.f;
auto shapeWidth = 300.f;
auto shapeHeight = 200.f;

auto leftTopSize = 50.f;
auto rightTopSize = 20.f;
auto rightBottomSize = 40.f;
auto leftBottomSize = 10.f;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Custom, shapeX, shapeY, shapeWidth, shapeHeight);

auto topLeft = PointF(leftTopSize, 0.0f);
auto topRight = PointF(shapeWidth - rightTopSize, 0.0f);
auto rightBottom = PointF(shapeWidth, shapeHeight - rightBottomSize);
auto bottomLeft = PointF(leftBottomSize, shapeHeight);
auto leftTop = PointF(0.0f, leftTopSize);

auto geometryPath = System::MakeObject<GeometryPath>();
geometryPath->MoveTo(topLeft);
geometryPath->LineTo(topRight);
geometryPath->ArcTo(rightTopSize, rightTopSize, 180.0f, -90.0f);
geometryPath->LineTo(rightBottom);
geometryPath->ArcTo(rightBottomSize, rightBottomSize, -90.0f, -90.0f);
geometryPath->LineTo(bottomLeft);
geometryPath->ArcTo(leftBottomSize, leftBottomSize, 0.0f, -90.0f);
geometryPath->LineTo(leftTop);
geometryPath->ArcTo(leftTopSize, leftTopSize, 90.0f, -90.0f);
geometryPath->CloseFigure();

shape->SetGeometryPath(geometryPath);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Ermitteln, ob eine Formgeometrie geschlossen ist**

Der folgende Helfer prüft, ob jeder nicht leere Geometriepfad mit einem Schließ‑Segment endet. Er liest [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) und vergleicht den letzten Segment‑Befehl [IPathSegment::get_PathCommand](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_pathcommand/) mit [PathCommandType::Close](https://reference.aspose.com/slides/cpp/aspose.slides/pathcommandtype/). Er liefert **false**, wenn keine nicht leeren Pfade vorhanden sind. Diese Prüfung betrachtet nur den letzten Befehl jedes Pfads; sie untersucht nicht jede Unterfigur innerhalb eines Pfads. Das Beispiel gibt `True` für ein Rechteck aus.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/ShapeType.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include <system/console.h>
#include <DOM/IPathSegment.h>
#include <DOM/PathCommandType.h>

using namespace Aspose::Slides;
using namespace System;

auto isGeometryClosed = [](SharedPtr<IGeometryShape> geometryShape)
{
    auto hasNonemptyPath = false;
    for (auto&& geometryPath : geometryShape->GetGeometryPaths())
    {
        auto segments = geometryPath->get_PathData();
        if (segments->get_Length() == 0)
        {
            continue;
        }

        hasNonemptyPath = true;
        auto lastSegment = segments->idx_get(segments->get_Length() - 1);
        if (lastSegment->get_PathCommand() != PathCommandType::Close)
        {
            return false;
        }
    }
    return hasNonemptyPath;
};

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
Console::WriteLine(isGeometryClosed(shape));
```

## **Geometriepfadbefehle prüfen**

Laden Sie [contour.pptx](contour.pptx) herunter und legen Sie die Datei im Arbeitsverzeichnis der Anwendung ab. Die erste Form auf der ersten Folie hat eine gerade obere Kante, eine kubische Bézier‑Kurve und eine gerade abschließende Kante. Verwenden Sie [GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/), um die Pfade auszulesen. Für jeden Pfad liefert [get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) die Segmente in Zeichenreihenfolge. Der durch [get_PathCommand](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_pathcommand/) zurückgegebene Befehl bestimmt, wie die Werte von [get_SegmentData](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_segmentdata/) zu interpretieren sind.

```cpp
#include <DOM/IGeometryPath.h>
#include <DOM/IGeometryShape.h>
#include <DOM/IPathSegment.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/PathCommandType.h>
#include <DOM/Presentation.h>
#include <system/array.h>
#include <system/console.h>
#include <system/enum.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"contour.pptx");

auto shape = ExplicitCast<IGeometryShape>(presentation->get_Slide(0)->get_Shape(0));
auto paths = shape->GetGeometryPaths();

for (auto i = 0; i < paths->get_Length(); ++i)
{
    auto segments = paths->idx_get(i)->get_PathData();
    for (auto j = 0; j < segments->get_Length(); ++j)
    {
        auto segment = segments->idx_get(j);
        auto command = segment->get_PathCommand();
        auto data = segment->get_SegmentData();
        String detail;
        switch (command)
        {
            case PathCommandType::MoveTo:
            case PathCommandType::LineTo:
                detail = String::Format(u"destination=({0}, {1})", data->idx_get(0), data->idx_get(1));
                break;
            case PathCommandType::CubicBezierTo:
                detail = String::Format(u"control1=({0}, {1}) control2=({2}, {3}) end=({4}, {5})", data);
                break;
            case PathCommandType::Close:
                detail = u"no coordinates";
                break;
            default:
            {
                auto values = MakeArray<String>(data->get_Length());
                for (auto k = 0; k < data->get_Length(); ++k)
                {
                    values->idx_set(k, String::Format(u"{0}", data->idx_get(k)));
                }
                detail = String::Format(u"raw=[{0}]", String::Join(u", ", values));
                break;
            }
        }
        Console::WriteLine(u"Path {0}, segment {1}: {2} {3}", i, j, Enum<PathCommandType>::GetName(command), detail);
    }
}
```

Die Form befindet sich bei (200, 100) Punkten auf der Folie. Die angegebenen Punkte sind relativ zur Form, wobei (0, 0) in der oberen linken Ecke liegt, x nach rechts und y nach unten zunimmt. Das abschließende Segment kehrt zum Startpunkt zurück, ohne weitere Koordinaten zu benötigen.

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **Formelemente extrahieren und prüfen**

Verwenden Sie [IGeometryShape::CreateShapeElements](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/createshapeelements/), um eine bestehende Form als Elemente zu untersuchen, die Pfad‑Punkte und Punkttypen enthalten. Werfen Sie jedes zurückgegebene [IShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/ishapeelement/) zu [ShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/) um, um die Arrays von [get_PathPoints](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathpoints/) und [get_PathTypes](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathtypes/) auszulesen. Diese Darstellung ist nützlich für Konturanalysen oder zum Weitergeben der Geometrie an benutzerdefinierte Zeichenwerkzeuge.

Das Beispiel öffnet eine Präsentation, findet die erste Geometry‑Shape direkt auf der ersten Folie und gibt deren Pfadsegmente aus. Verwenden Sie eine Präsentation, die eine Form mit geraden und gekrümmten Segmenten enthält, um beide Ausgaben zu sehen. Gruppen werden nicht durchsucht.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/ShapeType.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include <system/console.h>
#include <DOM/IShapeElement.h>
#include <DOM/ShapeElement.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IGeometryShape> shape;
for (auto&& candidate : slide->get_Shapes())
{
    shape = AsCast<IGeometryShape>(candidate);
    if (shape != nullptr)
    {
        break;
    }
}
if (shape == nullptr)
{
    Console::WriteLine(u"No geometry shape found on the first slide.");
    return;
}

for (auto&& element : shape->CreateShapeElements())
{
    auto shapeElement = ExplicitCast<ShapeElement>(element);
    auto points = shapeElement->get_PathPoints();
    auto types = shapeElement->get_PathTypes();
    Console::WriteLine(u"Shape element:");

    for (auto i = 0; i < points->get_Length(); i++)
    {
        auto pointType = types[i] & 0x07; // Segmenttyp beibehalten, Flags ausschließen.
        switch (pointType)
        {
            case 0:
                Console::WriteLine(u"Start figure at {0}", points[i]);
                break;
            case 1:
                Console::WriteLine(u"Line to {0}", points[i]);
                break;
            case 3:
                Console::WriteLine(u"Cubic Bezier: controls {0}, {1}; end {2}", points[i], points[i + 1], points[i + 2]);
                i += 2; // Verbraucht beide Steuerpunkte und den Endpunkt.
                break;
        }
        if ((types[i] & 0x80) != 0)
        {
            Console::WriteLine(u"Close subpath back to its starting point.");
        }
    }
}
```

Die Arrays korrespondieren indexweise: `points[i]` ist ein Punkt und `types[i]` beschreibt seine Rolle. Typ 0 startet eine Figur, Typ 1 zeichnet eine Linie vom vorherigen Punkt zum aktuellen Punkt. Ein kubisches Bézier‑Segment startet am vorherigen Endpunkt und nutzt drei aufeinanderfolgende Typ‑3‑Einträge: zwei Steuerpunkte gefolgt vom neuen Endpunkt. Die Schleife verarbeitet diese drei Einträge gemeinsam und prüft, ob der Endpunkt die Figur schließt.

Punkttypen enthalten außerdem Flags. Maskieren Sie mit `0x07`, um den Segmenttyp zu ermitteln, und prüfen Sie `0x80` separat, um einen geschlossenen Unterpfad zu erkennen. Beispiel: `129` (`0x81`) bedeutet ein Linien‑Endpunkt, der einen Unterpfad schließt, und `131` (`0x83`) bedeutet ein Bézier‑Endpunkt, der einen schließt. Das reine Vergleichen des Rohwerts mit `1` oder `3` würde diese Fälle übersehen. Andere Flags, etwa Dash (`0x10`) oder Marker (`0x20`), ändern den Grundsegmenttyp nicht.

**Koordinaten und Transformationen.** Punkte werden in Punkt (1/72 Zoll) gemessen, X wächst nach rechts, Y nach unten. Bei einer nicht gruppierten Form enthalten die extrahierten Koordinaten bereits die Position, die von [get_X](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_x/) und [get_Y](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_y/) zurückgegeben wird, und sie spiegeln die aktuelle Breite und Höhe wider. Beispiel: Ein nicht gedrehtes Rechteck bei `(100, 200)` mit Größe `120 × 80` hat Konturgrenzen `(100, 200)–(220, 280)`. Die Position der Form darf nicht erneut addiert werden. Subtrahieren Sie X und Y, um Koordinaten relativ zum nicht gedrehten Rahmen zu erhalten.

Die extrahierten Punkte berücksichtigen nicht die Rotation, die über [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) gesetzt wurde, noch horizontale bzw. vertikale Spiegelungen. Um die dargestellte Kontur wiederzugeben, wenden Sie diese Transformationen um den Mittelpunkt der Form an. Bei gruppierten Formen muss außerdem die Gruppen‑Koordinatenabbildung und -Transformation berücksichtigt werden; gehen Sie nicht davon aus, dass die extrahierten Punkte die endgültigen Folienkoordinaten darstellen, und wenden Sie keine Translation oder Skalierung doppelt an, wenn sie bereits im Kinder‑Rahmen enthalten ist.

**Prüfung vs. Bearbeitung.** Extrahierte Arrays beschreiben die Kontur; das Ändern dieser Arrays aktualisiert die Originalform nicht. Verwenden Sie diesen Ansatz, wenn Ihre Analyse‑ oder Zeichen‑Logik Punkt‑/Typ‑Arrays benötigt. Nutzen Sie [GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/), wenn Sie Geometrie‑Befehle im lokalen Koordinatensystem der Form benötigen oder die Geometrie bearbeiten wollen. Wenden Sie bearbeitete Pfade über [SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) oder [SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) an.

## **GeometryPath in GraphicsPath konvertieren**

Die aktuelle öffentliche API von Aspose.Slides für C++ stellt keine Konvertierungen zwischen Geometriepfaden und GraphicsPath‑Objekten bereit. Um eine Kontur zu prüfen, verwenden Sie Formelemente wie oben beschrieben. Zum Bearbeiten einer Form nutzen Sie Geometriepfade und wenden die aktualisierten Pfade auf die Form an.

## **FAQ**

**Was passiert mit Füllung und Kontur, nachdem die Geometrie ersetzt wurde?**

Der Stil bleibt an der Form erhalten; nur die Kontur ändert sich. Füllung und Kontur werden automatisch auf die neue Geometrie angewendet.

**Wie drehe ich eine benutzerdefinierte Form korrekt zusammen mit ihrer Geometrie?**

Verwenden Sie die Methode [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) der Form; die Geometrie dreht sich mit der Form, weil sie an das eigene Koordinatensystem der Form gebunden ist.

**Kann ich eine benutzerdefinierte Form in ein Bild konvertieren, um das Ergebnis „einzusperren“?**

Ja. Exportieren Sie den gewünschten [Folie](/slides/de/cpp/convert-powerpoint-to-png/)-Bereich oder die [Form](/slides/de/cpp/shape-thumbnails/) selbst in ein Rasterformat; das vereinfacht die weitere Arbeit mit komplexen Geometrien.