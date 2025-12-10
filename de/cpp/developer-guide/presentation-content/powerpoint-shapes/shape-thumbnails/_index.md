---
title: Thumbnails von Präsentationsformen in C++ erstellen
linktitle: Shape Thumbnails
type: docs
weight: 70
url: /de/cpp/shape-thumbnails/
keywords:
- Shape-Thumbnail
- Shape-Bild
- Shape rendern
- Shape-Rendering
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Generieren Sie hochwertige Shape-Thumbnails aus PowerPoint-Folien mit Aspose.Slides für C++ – einfach Präsentations-Thumbnails erstellen und exportieren."
---

## **Ein Shape-Thumbnail erstellen**
Aspose.Slides for C++ wird verwendet, um Präsentationsdateien zu erstellen, bei denen jede Seite eine Folie ist. Diese Folien können angezeigt werden, indem die Präsentationsdateien mit Microsoft PowerPoint geöffnet werden. Manchmal müssen Entwickler jedoch die Bilder der Shapes getrennt in einem Bildbetrachter anzeigen. In solchen Fällen hilft Aspose.Slides for C++ beim Erzeugen von Thumbnail‑Bildern der Folien‑Shapes. Die Verwendung dieser Funktion wird in diesem Artikel beschrieben.

Dieser Artikel erklärt, wie man Folien‑Thumbnails auf verschiedene Arten erzeugt:

- Erzeugen eines Shape-Thumbnails innerhalb einer Folie.
- Erzeugen eines Shape-Thumbnails für ein Folien‑Shape mit benutzerdefinierten Abmessungen.
- Erzeugen eines Shape-Thumbnails innerhalb der Grenzen des Aussehens eines Shapes.
- Erzeugen eines Thumbnails eines SmartArt‑Kindknotens.

## **Ein Shape-Thumbnail aus einer Folie erzeugen**
Um ein Shape-Thumbnail aus einer beliebigen Folie mit Aspose.Slides for C++ zu erzeugen:

1. Erstellen Sie eine Instanz der[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)Klasse.
2. Holen Sie sich die Referenz einer beliebigen Folie über deren ID oder Index.
3. Rufen Sie das Shape‑Thumbnail‑Bild der referenzierten Folie in Standard‑Skalierung ab.
4. Speichern Sie das Thumbnail‑Bild in einem gewünschten Bildformat.

Das nachstehende Beispiel erzeugt ein Shape-Thumbnail.
```cpp
auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage();
image->Save(u"Shape_thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```


## **Ein Thumbnail mit benutzerdefiniertem Skalierungsfaktor erzeugen**
Um das Shape-Thumbnail einer beliebigen Folien‑Shape mit Aspose.Slides for C++ zu erzeugen:

1. Erstellen Sie eine Instanz der[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)Klasse.
2. Holen Sie sich die Referenz einer beliebigen Folie über deren ID oder Index.
3. Rufen Sie das Thumbnail‑Bild der referenzierten Folie mit den Shape‑Grenzen ab.
4. Speichern Sie das Thumbnail‑Bild in einem gewünschten Bildformat.

Das nachstehende Beispiel erzeugt ein Thumbnail mit einem benutzerdefinierten Skalierungsfaktor.
```cpp
auto bounds = ShapeThumbnailBounds::Shape;
auto scale = 1; // Skalierung entlang der X- und Y-Achsen.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Scaling Factor Thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```


## **Ein bounds‑basiertes Shape‑Appearance‑Thumbnail erstellen**
Diese Methode zum Erzeugen von Thumbnails von Shapes ermöglicht es Entwicklern, ein Thumbnail innerhalb der Grenzen des Aussehens des Shapes zu erzeugen. Dabei werden alle Shape‑Effekte berücksichtigt. Das erzeugte Shape‑Thumbnail ist durch die Folien‑Grenzen eingeschränkt. Um ein Thumbnail einer beliebigen Folien‑Shape innerhalb der Grenzen ihres Aussehens zu erzeugen, verwenden Sie den folgenden Beispielcode:

1. Erstellen Sie eine Instanz der[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)Klasse.
2. Holen Sie sich die Referenz einer beliebigen Folie über deren ID oder Index.
3. Rufen Sie das Thumbnail‑Bild der referenzierten Folie mit den Shape‑Grenzen als Aussehen ab.
4. Speichern Sie das Thumbnail‑Bild in einem gewünschten Bildformat.

Das nachstehende Beispiel erstellt ein Thumbnail mit einem benutzerdefinierten Skalierungsfaktor.
```cpp
auto bounds = ShapeThumbnailBounds::Appearance;
auto scale = 1; // Skalierung entlang der X- und Y-Achsen.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Shape_thumbnail_Bound_Shape_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```


## **FAQ**

**Welche Bildformate können beim Speichern von Shape-Thumbnails verwendet werden?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/cpp/aspose.slides/imageformat/), und andere. Shapes können auch als Vektor‑SVG[exportiert werden](https://reference.aspose.com/slides/cpp/aspose.slides/shape/writeassvg/), indem der Inhalt des Shapes als SVG gespeichert wird.

**Was ist der Unterschied zwischen Shape‑ und Appearance‑Grenzen beim Rendern eines Thumbnails?**

`Shape` verwendet die Geometrie des Shapes; `Appearance` berücksichtigt[visuelle Effekte](/slides/de/cpp/shape-effect/)(Schatten, Leuchten usw.).

**Was passiert, wenn ein Shape als versteckt markiert ist? Wird es trotzdem als Thumbnail gerendert?**

Ein verstecktes Shape bleibt Teil des Modells und kann gerendert werden; das versteckte Flag beeinflusst die Anzeige im Diashow‑Modus, verhindert jedoch nicht das Erzeugen des Bildes des Shapes.

**Werden Gruppenshapes, Diagramme, SmartArt und andere komplexe Objekte unterstützt?**

Ja. Jeder als[Shape](https://reference.aspose.com/slides/cpp/aspose.slides/shape/) dargestellte Objekt (einschließlich[GroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/groupshape/),[Chart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/), und[SmartArt](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartart/)) kann als Thumbnail oder als SVG gespeichert werden.

**Beeinflussen systemweit installierte Schriftarten die Qualität von Thumbnails für Text‑Shapes?**

Ja. Sie sollten die benötigten Schriftarten[bereitstellen](/slides/de/cpp/custom-font/)(oder[Schriftart‑Ersetzungen konfigurieren](/slides/de/cpp/font-substitution/)) , um unerwünschte Rückgriffe und Text‑Umflüsse zu vermeiden.