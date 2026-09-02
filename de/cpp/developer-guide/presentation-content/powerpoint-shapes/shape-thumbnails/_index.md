---
title: Erstellen von Miniaturansichten von Präsentationsformen in C++
linktitle: Form-Miniaturansichten
type: docs
weight: 70
url: /de/cpp/shape-thumbnails/
keywords:
- Form-Miniaturansicht
- Form-Bild
- Form rendern
- Form-Rendering
- visuelle Grenzen
- Form-Grenzen
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Erstellen Sie hochwertige Form-Miniaturansichten aus PowerPoint-Folien mit Aspose.Slides für C++ - einfach Präsentations-Miniaturansichten erstellen und exportieren."
---
## **Einführung**

Aspose.Slides wird verwendet, um Präsentationsdateien zu erstellen, bei denen jede Seite eine Folie ist. Diese Folien können durch Öffnen der Präsentationsdateien mit Microsoft PowerPoint angezeigt werden. Manchmal müssen Entwickler jedoch die Bilder der Formen separat in einem Bildbetrachter ansehen. In solchen Fällen hilft Aspose.Slides dabei, Miniaturbilder der Folienformen zu erzeugen. Die Verwendung dieser Funktion wird in diesem Artikel beschrieben.

Dieser Artikel erklärt, wie man Folien‑Thumbnails auf verschiedene Weise generiert:

- Generieren eines Form‑Thumbnails innerhalb einer Folie.  
- Generieren eines Form‑Thumbnails für eine Folienform mit benutzerdefinierten Abmessungen.  
- Generieren eines Form‑Thumbnails innerhalb der Grenzen des Erscheinungsbildes einer Form.

## **Ein Form‑Thumbnail aus einer Folie erzeugen**
Um ein Form‑Thumbnail aus einer beliebigen Folie mit Aspose.Slides für C++ zu erzeugen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/) Klasse.  
2. Holen Sie sich die Referenz einer beliebigen Folie über deren ID oder Index.  
3. Erhalten Sie das Form‑Thumbnail‑Bild der referenzierten Folie in Standardgröße.  
4. Speichern Sie das Thumbnail‑Bild in einem gewünschten Bildformat.

Das nachstehende Beispiel erzeugt ein Form‑Thumbnail.

```cpp
auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage();
image->Save(u"Shape_thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Ein Thumbnail mit benutzerdefiniertem Skalierungsfaktor erzeugen**
Um das Form‑Thumbnail einer beliebigen Folienform mit Aspose.Slides für C++ zu erzeugen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/) Klasse.  
2. Holen Sie sich die Referenz einer beliebigen Folie über deren ID oder Index.  
3. Erhalten Sie das Thumbnail‑Bild der referenzierten Folie mit Form‑Grenzen.  
4. Speichern Sie das Thumbnail‑Bild in einem gewünschten Bildformat.

Das nachstehende Beispiel erzeugt ein Thumbnail mit benutzerdefiniertem Skalierungsfaktor.

```cpp
auto bounds = ShapeThumbnailBounds::Shape;
auto scale = 1; // Skalierung entlang X- und Y-Achsen.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Scaling Factor Thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Ein bounds‑basiertes Form‑Erscheinungs‑Thumbnail erstellen**
Diese Methode zum Erstellen von Thumbnails für Formen ermöglicht es Entwicklern, ein Thumbnail innerhalb der Grenzen des Erscheinungsbildes einer Form zu erzeugen. Dabei werden alle Formeffekte berücksichtigt. Das erzeugte Form‑Thumbnail wird durch die Folien‑Grenzen eingeschränkt. Um ein Thumbnail einer beliebigen Folienform innerhalb ihrer Erscheinungsbild‑Grenzen zu erzeugen, verwenden Sie den folgenden Beispielcode:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/) Klasse.  
2. Holen Sie sich die Referenz einer beliebigen Folie über deren ID oder Index.  
3. Erhalten Sie das Thumbnail‑Bild der referenzierten Folie mit Form‑Grenzen als Erscheinungsbild.  
4. Speichern Sie das Thumbnail‑Bild in einem gewünschten Bildformat.

Das nachstehende Beispiel erstellt ein Thumbnail mit benutzerdefiniertem Skalierungsfaktor.

```cpp
auto bounds = ShapeThumbnailBounds::Appearance;
auto scale = 1; // Skalierung entlang X- und Y-Achsen.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Shape_thumbnail_Bound_Shape_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Die tatsächlichen visuellen Grenzen einer Form abrufen**

Die Frame‑Eigenschaften von [IShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/) – `IShape::get_X()`, `IShape::get_Y()`, `IShape::get_Width()` und `IShape::get_Height()` – beschreiben das Rechteck, das im Präsentationsmodell gespeichert ist. Der tatsächlich gerenderte Inhalt kann über diesen Rahmen hinausgehen oder ein anders ausgerichtetes Rechteck belegen. Rotation, Konturen, Pfeilspitzen, Textlayout und -überlauf, automatisch erzeugte SmartArt‑Geometrie und andere Rendering‑Effekte können den belegten Bereich verändern.

Verwenden Sie [Shape::GetVisualBounds](https://reference.aspose.com/slides/de/cpp/aspose.slides/shape/getvisualbounds/), um diesen belegten Bereich zu berechnen, ohne ein Bild zu erzeugen. Die Methode gibt ein [RectangleF](https://reference.aspose.com/slides/de/cpp/system.drawing/rectanglef/) in Folien‑Koordinaten zurück. Das zurückgegebene Rechteck ist nicht an die Folie geklippt, sodass seine Koordinaten negativ sein können, wenn der Inhalt über den Ursprung der Folie hinausreicht.

[Shape::GetVisualBounds](https://reference.aspose.com/slides/de/cpp/aspose.slides/shape/getvisualbounds/) ist derzeit nicht im [IShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/) Interface deklariert. Bewahren Sie daher die Form, die Sie aus der Form‑Sammlung der Folie erhalten, als Interface‑Wert auf und casten Sie sie nur, wenn Sie die Methode aufrufen.

Das folgende Beispiel holt und vergleicht die Frame‑ und visuellen Grenzen:

```cpp
auto presentation = MakeObject<Presentation>(u"example.pptx");

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

auto visualBounds = System::AsCast<Shape>(shape)->GetVisualBounds();

System::Drawing::RectangleF frameBounds(
    shape->get_X(), shape->get_Y(), shape->get_Width(), shape->get_Height());

Console::WriteLine(u"Frame bounds: {0}", frameBounds);
Console::WriteLine(u"Visual bounds: {0}", visualBounds);

presentation->Dispose();
```

Dasselbe [RectangleF](https://reference.aspose.com/slides/de/cpp/system.drawing/rectanglef/) kann verwendet werden, um benachbarte Formen an dessen `RectangleF::get_Left()`, `RectangleF::get_Right()`, `RectangleF::get_Top()` oder `RectangleF::get_Bottom()` Kante auszurichten; ausreichend Platz in einem erzeugten Layout zu reservieren; oder Inhalte außerhalb eines zulässigen Bereichs zu erkennen. Visuelle Grenzen sind besonders nützlich für SmartArt, Textfelder, Pfeile, Bilder, gedrehte Formen und Gruppierungen, bei denen der gespeicherte Rahmen das vollständige gerenderte Ergebnis nicht darstellt.

Verwenden Sie [Shape::GetVisualBounds](https://reference.aspose.com/slides/de/cpp/aspose.slides/shape/getvisualbounds/), wenn Sie Koordinaten für Layout oder Validierung benötigen und kein Bitmap benötigen. Verwenden Sie [IShape::GetImage](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishape/getimage/), wenn Sie die Form rendern müssen. Mit [ShapeThumbnailBounds](https://reference.aspose.com/slides/de/cpp/aspose.slides/shapethumbnailbounds/), `ShapeThumbnailBounds::Shape` bestimmt die Bildgröße aus den Form‑Grenzen, einschließlich Kontur‑Einstellungen, während `ShapeThumbnailBounds::Appearance` die Größe aus dem Erscheinungsbild der Form nimmt und das Ergebnis auf die Folien‑Grenzen beschränkt. Im Gegensatz dazu gibt [Shape::GetVisualBounds](https://reference.aspose.com/slides/de/cpp/aspose.slides/shape/getvisualbounds/) nur das berechnete Rechteck zurück und schneidet es nicht an die Folie zu.

## **FAQ**

**Welche Bildformate können beim Speichern von Form‑Thumbnails verwendet werden?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/de/cpp/aspose.slides/imageformat/) und weitere. Formen können auch als Vektor‑SVG [exportiert werden](https://reference.aspose.com/slides/de/cpp/aspose.slides/shape/writeassvg/), indem der Inhalt der Form als SVG gespeichert wird.

**Was ist der Unterschied zwischen Shape‑ und Appearance‑Grenzen beim Rendern eines Thumbnails?**

`Shape` verwendet die Geometrie der Form; `Appearance` berücksichtigt [visuelle Effekte](/slides/de/cpp/shape-effect/) (Schatten, Leuchten usw.).

**Was passiert, wenn eine Form als ausgeblendet markiert ist? Wird sie trotzdem als Thumbnail gerendert?**

Eine ausgeblendete Form bleibt Teil des Modells und kann gerendert werden; das Ausblenden‑Flag beeinflusst die Anzeige der Diashow, verhindert jedoch nicht die Erzeugung des Form‑Bildes.

**Werden Gruppierungen, Diagramme, SmartArt und andere komplexe Objekte unterstützt?**

Ja. Jeder Gegenstand, der als [Shape](https://reference.aspose.com/slides/de/cpp/aspose.slides/shape/) dargestellt wird (einschließlich [GroupShape](https://reference.aspose.com/slides/de/cpp/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/chart/) und [SmartArt](https://reference.aspose.com/slides/de/cpp/aspose.slides.smartart/smartart/)), kann als Thumbnail oder als SVG gespeichert werden.

**Beeinflussen systemweit installierte Schriftarten die Qualität von Thumbnails für Textformen?**

Ja. Sie sollten die erforderlichen Schriftarten bereitstellen (/slides/de/cpp/custom-font/) (oder [Schriftarten‑Substitutionen konfigurieren](/slides/de/cpp/font-substitution/)), um unerwünschte Fallbacks und Text‑Umfluss zu vermeiden.