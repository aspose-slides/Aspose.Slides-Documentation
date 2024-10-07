---
title: Form Miniaturen
type: docs
weight: 70
url: /cpp/shape-thumbnails/
keywords: 
- Form Miniatur
- Form Bild
- PowerPoint
- Präsentation
- C++
- Aspose.Slides für C++
description: "Extrahieren Sie Form Miniaturen aus PowerPoint-Präsentationen in C++"
---


## **Form Miniatur erstellen**
Aspose.Slides für C++ wird verwendet, um Präsentationsdateien zu erstellen, bei denen jede Seite eine Folie ist. Diese Folien können angesehen werden, indem die Präsentationsdateien mit Microsoft PowerPoint geöffnet werden. Manchmal müssen Entwickler die Bilder der Formen jedoch separat in einem Bildbetrachter anzeigen. In solchen Fällen hilft Ihnen Aspose.Slides für C++, Miniaturbilder der Folienformen zu erstellen. Wie Sie diese Funktion nutzen können, wird in diesem Artikel beschrieben.
Dieser Artikel erklärt, wie man Folienminiaturen auf verschiedene Weise generiert:

- Generierung einer Formminiatur innerhalb einer Folie.
- Generierung einer Formminiatur für eine Folienform mit benutzerdefinierten Abmessungen.
- Generierung einer Formminiatur innerhalb der Grenzen des Erscheinungsbilds einer Form.
- Generierung einer Miniatur eines SmartArt-Kindknotens.

## **Form Miniatur aus Folie generieren**
Um eine Formminiatur aus einer beliebigen Folie mit Aspose.Slides für C++ zu generieren:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse.
1. Erhalten Sie die Referenz einer beliebigen Folie anhand ihrer ID oder ihres Index.
1. Holen Sie sich das Bild der Formminiatur der referenzierten Folie im Standardmaßstab.
1. Speichern Sie das Miniaturbild in einem gewünschten Bildformat.

Das Beispiel unten generiert eine Formminiatur.

```cpp
auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage();
image->Save(u"Shape_thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```


## **Miniatur mit benutzerdefiniertem Skalierungsfaktor generieren**
Um die Formminiatur einer beliebigen Folienform mit Aspose.Slides für C++ zu generieren:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse.
1. Erhalten Sie die Referenz einer beliebigen Folie anhand ihrer ID oder ihres Index.
1. Holen Sie sich das Miniaturbild der referenzierten Folie mit den Formgrenzen.
1. Speichern Sie das Miniaturbild in einem gewünschten Bildformat.

Das Beispiel unten generiert eine Miniatur mit einem benutzerdefinierten Skalierungsfaktor.

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

## **Miniatur des Erscheinungsbilds der Grenzen einer Form erstellen**
Diese Methode zur Erstellung von Miniaturen für Formen ermöglicht es Entwicklern, eine Miniatur innerhalb der Grenzen des Erscheinungsbilds einer Form zu generieren. Sie berücksichtigt alle Formeffekte. Die generierte Formminiatur ist durch die Foliengrenzen eingeschränkt. Um eine Miniatur einer beliebigen Folienform innerhalb der Grenzen ihres Erscheinungsbilds zu generieren, verwenden Sie den folgenden Beispielcode:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse.
1. Erhalten Sie die Referenz einer beliebigen Folie anhand ihrer ID oder ihres Index.
1. Holen Sie sich das Miniaturbild der referenzierten Folie mit den Formgrenzen als Erscheinungsbild.
1. Speichern Sie das Miniaturbild in einem gewünschten Bildformat.

Das Beispiel unten erstellt eine Miniatur mit einem benutzerdefinierten Skalierungsfaktor.

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