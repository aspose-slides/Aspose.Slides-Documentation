---
title: Formen in Präsentationen in C++ anpassen
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
description: "Erstellen und anpassen von Formen in PowerPoint-Präsentationen mit Aspose.Slides für C++: Geometriepfade, abgerundete Ecken, zusammengesetzte Formen."
---

## **Eine Form mit Bearbeitungspunkten ändern**
Betrachten Sie ein Quadrat. In PowerPoint können Sie mit **Bearbeitungspunkten** 

* die Ecke des Quadrats nach innen oder außen verschieben
* die Krümmung einer Ecke oder eines Punktes festlegen
* neue Punkte zum Quadrat hinzufügen
* Punkte auf dem Quadrat manipulieren usw. 

Im Wesentlichen können Sie die beschriebenen Vorgänge an jeder Form ausführen. Mit Bearbeitungspunkten können Sie eine Form ändern oder aus einer bestehenden Form eine neue Form erstellen. 

## **Tipps zur Formbearbeitung**

![overview_image](custom_shape_0.png)

Bevor Sie beginnen, PowerPoint‑Formen über Bearbeitungspunkte zu bearbeiten, sollten Sie folgende Punkte zu Formen beachten:

* Eine Form (oder ihr Pfad) kann entweder geschlossen oder geöffnet sein.
* Wenn eine Form geschlossen ist, fehlt ein Anfangs‑ oder Endpunkt. Bei einer offenen Form gibt es einen Anfang und ein Ende. 
* Alle Formen bestehen aus mindestens 2 Ankerpunkten, die durch Linien miteinander verbunden sind.
* Eine Linie ist gerade oder gekrümmt. Ankerpunkte bestimmen die Art der Linie. 
* Ankerpunkte existieren als Eckpunkte, gerade Punkte oder glatte Punkte:
  * Ein Eckpunkt ist ein Punkt, an dem 2 gerade Linien in einem Winkel zusammenlaufen. 
  * Ein glatter Punkt ist ein Punkt, an dem 2 Handles in einer geraden Linie liegen und die Segmente der Linie in einer sanften Kurve zusammenlaufen. In diesem Fall sind alle Handles in gleichem Abstand vom Ankerpunkt getrennt. 
  * Ein gerader Punkt ist ein Punkt, an dem 2 Handles in einer geraden Linie liegen und die Segmente der Linie in einer sanften Kurve zusammenlaufen. In diesem Fall müssen die Handles nicht im gleichen Abstand vom Ankerpunkt getrennt sein. 
* Durch Verschieben oder Bearbeiten von Ankerpunkten (was den Winkel der Linien ändert) können Sie das Aussehen einer Form verändern. 

Um PowerPoint‑Formen über Bearbeitungspunkte zu bearbeiten, stellt **Aspose.Slides** die Klasse [**GeometryPath**](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) und das Interface [**IGeometryPath**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_path) bereit. 

* Eine [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path)-Instanz stellt den Geometrie‑Pfad des Objekts [IGeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_shape) dar. 
* Um den `GeometryPath` aus der `IGeometryShape`‑Instanz abzurufen, können Sie die Methode [IGeometryShape::GetGeometryPaths](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_shape#a91c25d805702d632c17db86ca3b279c1) verwenden. 
* Um den `GeometryPath` für eine Form festzulegen, können Sie diese Methoden nutzen: [IGeometryShape::SetGeometryPath()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_shape#a350a80e5544519f5f840318f13ad7986) für *solide Formen* und [IGeometryShape::SetGeometryPaths()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_shape#a4b3837a4e393693b3ceaa0928181b750) für *komposite Formen*.
* Um Segmente hinzuzufügen, können Sie die Methoden unter [IGeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_path) verwenden. 
* Mit den Methoden [IGeometryPath::set_Stroke()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_path#aa819370fbd22ef49387672b8fe2ed147) und [IGeometryPath::set_FillMode()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_path#adf7a4e1a1a28b52a97bff0d5cad6f3d7) können Sie das Aussehen eines Geometrie‑Pfads festlegen.
* Mit der Methode [IGeometryPath::get_PathData()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_geometry_path#a9b1e40e8db9d4dd95fa4784e95d73fca) können Sie den Geometrie‑Pfad eines `GeometryShape` als Array von Pfadsegmenten abrufen. 
* Um weitere Anpassungsoptionen für die Formgeometrie zu nutzen, können Sie [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) in [GraphicsPath](https://reference.aspose.com/slides/cpp/class/system.drawing.drawing2_d.graphics_path) konvertieren.
* Verwenden Sie die Methoden [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.shape_util#ab319f6b9578de90a4863c883690f7daf) und [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.shape_util#ab319f6b9578de90a4863c883690f7daf) (aus der Klasse [ShapeUtil](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.shape_util)), um [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) in [GraphicsPath](https://reference.aspose.com/slides/cpp/class/system.drawing.drawing2_d.graphics_path) und zurück zu konvertieren. 

## **Einfache Bearbeitungsoperationen**

Dieser C++‑Code zeigt, wie man

**Eine Linie** am Ende eines Pfades hinzufügt
``` cpp
void LineTo(PointF point);
void LineTo(float x, float y);
```

**Eine Linie** an einer angegebenen Position des Pfades hinzufügt:
``` cpp    
void LineTo(PointF point, uint32_t index);
void LineTo(float x, float y, uint32_t index);
```

**Eine kubische Bézier‑Kurve** am Ende eines Pfades hinzufügt:
``` cpp
void CubicBezierTo(PointF point1, PointF point2, PointF point3);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```

**Eine kubische Bézier‑Kurve** an einer angegebenen Position des Pfades hinzufügt:
``` cpp
void CubicBezierTo(PointF point1, PointF point2, PointF point3, uint32_t index);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, uint32_t index);
```

**Eine quadratische Bézier‑Kurve** am Ende eines Pfades hinzufügt:
``` cpp
void QuadraticBezierTo(PointF point1, PointF point2);
void QuadraticBezierTo(float x1, float y1, float x2, float y2);
```

**Eine quadratische Bézier‑Kurve** an einer angegebenen Position des Pfades hinzufügt:
``` cpp
void QuadraticBezierTo(PointF point1, PointF point2, uint32_t index);
void QuadraticBezierTo(float x1, float y1, float x2, float y2, uint32_t index);
```

**Einen angegebenen Bogen** zu einem Pfad anhängt:
``` cpp
void ArcTo(float width, float heigth, float startAngle, float sweepAngle);
```

**Die aktuelle Figur** eines Pfades schließt:
``` cpp
void CloseFigure();
```

**Die Position für den nächsten Punkt** festlegt:
``` cpp
void MoveTo(PointF point);
void MoveTo(float x, float y);
```

**Das Pfadsegment** an einem angegebenen Index entfernt:
``` cpp
void RemoveAt(int32_t index);
```

## **Benutzerdefinierte Punkte zu einer Form hinzufügen**
1. Erstellen Sie eine Instanz der Klasse [GeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_shape) und setzen Sie den Typ [ShapeType.Rectangle](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#abe1c0baea327186bde49ad44636bb8c5).
2. Holen Sie sich eine Instanz der Klasse [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) von der Form.
3. Fügen Sie einen neuen Punkt zwischen den beiden oberen Punkten des Pfades hinzu.
4. Fügen Sie einen neuen Punkt zwischen den beiden unteren Punkten des Pfades hinzu.
5. Wenden Sie den Pfad auf die Form an.

Dieser C++‑Code zeigt, wie man benutzerdefinierte Punkte zu einer Form hinzufügt:
``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 200.0f, 100.0f));

SharedPtr<IGeometryPath> geometryPath = shape->GetGeometryPaths()->idx_get(0);

geometryPath->LineTo(100.0f, 50.0f, 1);
geometryPath->LineTo(100.0f, 50.0f, 4);
shape->SetGeometryPath(geometryPath);
```


![example1_image](custom_shape_1.png)

## **Punkte aus einer Form entfernen**

1. Erstellen Sie eine Instanz der Klasse [GeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_shape) und setzen Sie den Typ [ShapeType.Heart](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#abe1c0baea327186bde49ad44636bb8c5).
2. Holen Sie sich eine Instanz der Klasse [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path) von der Form.
3. Entfernen Sie das Segment des Pfades.
4. Wenden Sie den Pfad auf die Form an.

Dieser C++‑Code zeigt, wie man Punkte aus einer Form entfernt:
``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Heart, 100.0f, 100.0f, 300.0f, 300.0f));

SharedPtr<IGeometryPath> path = shape->GetGeometryPaths()->idx_get(0);
path->RemoveAt(2);
shape->SetGeometryPath(path);
```

![example2_image](custom_shape_2.png)

## **Eine benutzerdefinierte Form erstellen**

1. Berechnen Sie die Punkte für die Form.
2. Erstellen Sie eine Instanz der Klasse [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path).
3. Füllen Sie den Pfad mit den Punkten.
4. Erstellen Sie eine Instanz der Klasse [GeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_shape).
5. Wenden Sie den Pfad auf die Form an.

Dieser C++‑Code zeigt, wie man eine benutzerdefinierte Form erstellt:
``` cpp
SharedPtr<List<PointF>> points = System::MakeObject<List<PointF>>();

float R = 100.0f, r = 50.0f;
int32_t step = 72;

for (int32_t angle = -90; angle < 270; angle += step)
{
    double radians = angle * (Math::PI / 180.f);
    double x = outerRadius * Math::Cos(radians);
    double y = outerRadius * Math::Sin(radians);
    points->Add(PointF((float)x + outerRadius, (float)y + outerRadius));

    radians = Math::PI * (angle + step / 2) / 180.0;
    x = innerRadiusr * Math::Cos(radians);
    y = innerRadiusr * Math::Sin(radians);
    points->Add(PointF((float)x + outerRadius, (float)y + outerRadius));
}

SharedPtr<GeometryPath> starPath = System::MakeObject<GeometryPath>();
starPath->MoveTo(points->idx_get(0));

for (int32_t i = 1; i < points->get_Count(); i++)
{
    starPath->LineTo(points->idx_get(i));
}

starPath->CloseFigure();

SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, R * 2, R * 2));

shape->SetGeometryPath(starPath);
```

![example3_image](custom_shape_3.png)


## **Eine zusammengesetzte benutzerdefinierte Form erstellen**

1. Erstellen Sie eine Instanz der Klasse [GeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_shape).
2. Erstellen Sie eine erste Instanz der Klasse [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path).
3. Erstellen Sie eine zweite Instanz der Klasse [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path).
4. Wenden Sie die Pfade auf die Form an.

Dieser C++‑Code zeigt, wie man eine zusammengesetzte benutzerdefinierte Form erstellt:
``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 200.0f, 100.0f));

SharedPtr<IGeometryPath> geometryPath0 = System::MakeObject<GeometryPath>();
geometryPath0->MoveTo(0.0f, 0.0f);
geometryPath0->LineTo(shape->get_Width(), 0.0f);
geometryPath0->LineTo(shape->get_Width(), shape->get_Height() / 3);
geometryPath0->LineTo(0.0f, shape->get_Height() / 3);
geometryPath0->CloseFigure();

SharedPtr<IGeometryPath> geometryPath1 = System::MakeObject<GeometryPath>();
geometryPath1->MoveTo(0.0f, shape->get_Height() / 3 * 2);
geometryPath1->LineTo(shape->get_Width(), shape->get_Height() / 3 * 2);
geometryPath1->LineTo(shape->get_Width(), shape->get_Height());
geometryPath1->LineTo(0.0f, shape->get_Height());
geometryPath1->CloseFigure();

shape->SetGeometryPaths(System::MakeArray<SharedPtr<IGeometryPath>>({ geometryPath0, geometryPath1 }));
```

![example4_image](custom_shape_4.png)

## **Eine benutzerdefinierte Form mit abgerundeten Ecken erstellen**

Dieser C++‑Code zeigt, wie man eine benutzerdefinierte Form mit nach innen gerichteten abgerundeten Ecken erstellt:
```cpp
float shapeX = 20.f;
float shapeY = 20.f;
float shapeWidth = 300.f;
float shapeHeight = 200.f;

float leftTopSize = 50.f;
float rightTopSize = 20.f;
float rightBottomSize = 40.f;
float leftBottomSize = 10.f;

auto presentation = System::MakeObject<Presentation>();

auto childShape = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Custom, shapeX, shapeY, shapeWidth, shapeHeight);

auto geometryPath = System::MakeObject<GeometryPath>();

PointF point1(leftTopSize, 0.0f);
PointF point2(shapeWidth - rightTopSize, 0.0f);
PointF point3(shapeWidth, shapeHeight - rightBottomSize);
PointF point4(leftBottomSize, shapeHeight);
PointF point5(0.0f, leftTopSize);

geometryPath->MoveTo(point1);
geometryPath->LineTo(point2);
geometryPath->ArcTo(rightTopSize, rightTopSize, 180.0f, -90.0f);
geometryPath->LineTo(point3);
geometryPath->ArcTo(rightBottomSize, rightBottomSize, -90.0f, -90.0f);
geometryPath->LineTo(point4);
geometryPath->ArcTo(leftBottomSize, leftBottomSize, 0.0f, -90.0f);
geometryPath->LineTo(point5);
geometryPath->ArcTo(leftTopSize, leftTopSize, 90.0f, -90.0f);

geometryPath->CloseFigure();

childShape->SetGeometryPath(geometryPath);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```


## **Herausfinden, ob eine Formgeometrie geschlossen ist**

Eine geschlossene Form ist definiert als eine Form, bei der alle Seiten verbunden sind und eine einzige Grenze ohne Lücken bilden. Eine solche Form kann eine einfache geometrische Form oder ein komplexes benutzerdefiniertes Kontur sein. Das folgende Codebeispiel zeigt, wie man prüft, ob eine Formgeometrie geschlossen ist:
```cpp
bool IsGeometryClosed(SharedPtr<IGeometryShape> geometryShape)
{
    bool isClosed = false;

    for (auto&& geometryPath : geometryShape->GetGeometryPaths())
    {
        auto dataLength = geometryPath->get_PathData()->get_Length();
        if (dataLength == 0)
            continue;

        auto lastSegment = geometryPath->get_PathData()[dataLength - 1];
        isClosed = lastSegment->get_PathCommand() == PathCommandType::Close;

        if (!isClosed)
            return false;
    }

    return isClosed;
}
```


## **GeometryPath in GraphicsPath konvertieren** 

1. Erstellen Sie eine Instanz der Klasse [GeometryShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_shape).
2. Erstellen Sie eine Instanz der Klasse [GraphicsPath](https://reference.aspose.com/slides/cpp/class/system.drawing.drawing2_d.graphics_path) aus dem Namespace [System.Drawing.Drawing2D](https://reference.aspose.com/slides/cpp/namespace/system.drawing.drawing2_d).
3. Konvertieren Sie die [GraphicsPath](https://reference.aspose.com/slides/cpp/class/system.drawing.drawing2_d.graphics_path)-Instanz in die [GeometryPath](https://reference.aspose.com/slides/cpp/class/aspose.slides.geometry_path)-Instanz mithilfe von [ShapeUtil](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.shape_util).
4. Wenden Sie die Pfade auf die Form an.

Dieser C++‑Code – eine Implementierung der oben genannten Schritte – demonstriert den **GeometryPath**‑zu‑**GraphicsPath**‑Konvertierungsprozess:
``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 100.0f));

SharedPtr<IGeometryPath> originalPath = shape->GetGeometryPaths()->idx_get(0);
originalPath->set_FillMode(PathFillModeType::None);

SharedPtr<Drawing2D::GraphicsPath> graphicsPath = System::MakeObject<Drawing2D::GraphicsPath>();
graphicsPath->AddString(u"Text in shape", System::MakeObject<FontFamily>(u"Arial"), 1, 40.0f, PointF(10.0f, 10.0f), StringFormat::get_GenericDefault());

SharedPtr<IGeometryPath> textPath = ShapeUtil::GraphicsPathToGeometryPath(graphicsPath);
textPath->set_FillMode(PathFillModeType::Normal);

shape->SetGeometryPaths(System::MakeArray<SharedPtr<IGeometryPath>>({ originalPath, textPath }));
```

![example5_image](custom_shape_5.png)

## **FAQ**

**Was passiert mit Füllung und Kontur, nachdem die Geometrie ersetzt wurde?**

Der Stil bleibt an der Form erhalten; nur die Kontur ändert sich. Füllung und Kontur werden automatisch auf die neue Geometrie angewendet.

**Wie rotiere ich eine benutzerdefinierte Form korrekt zusammen mit ihrer Geometrie?**

Verwenden Sie die [Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/)‑Eigenschaft der Form; die Geometrie rotiert mit der Form, weil sie an das Koordinatensystem der Form gebunden ist.

**Kann ich eine benutzerdefinierte Form in ein Bild konvertieren, um das Ergebnis „einzusperren“?**

Ja. Exportieren Sie den gewünschten [Foliensatz](/slides/de/cpp/convert-powerpoint-to-png/) oder die [Form](/slides/de/cpp/create-shape-thumbnails/) selbst in ein Rasterformat; das vereinfacht die weitere Arbeit mit umfangreichen Geometrien.