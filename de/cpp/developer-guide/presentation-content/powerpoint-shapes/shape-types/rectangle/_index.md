---
title: Rechtecke zu Präsentationen in C++ hinzufügen
linktitle: Rechteck
type: docs
weight: 80
url: /de/cpp/rectangle/
keywords:
- Rechteck hinzufügen
- Rechteck erstellen
- Rechteckform
- einfaches Rechteck
- formatiertes Rechteck
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Verbessern Sie Ihre PowerPoint-Präsentationen, indem Sie mit Aspose.Slides für C++ Rechtecke hinzufügen – gestalten und ändern Sie Formen mühelos programmgesteuert."
---

## **Einfaches Rechteck erstellen**
Wie bei vorherigen Themen geht es auch hier um das Hinzufügen einer Form, und diesmal diskutieren wir das Rechteck. In diesem Beitrag haben wir beschrieben, wie Entwickler einfache oder formatierte Rechtecke zu ihren Folien mit Aspose.Slides für C++ hinzufügen können. Um ein einfaches Rechteck zu einer ausgewählten Folie der Präsentation hinzuzufügen, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation class](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Holen Sie die Referenz einer Folie, indem Sie deren Index verwenden.
1. Fügen Sie über die AddAutoShape‑Methode des IShapes‑Objekts ein IAutoShape vom Typ Rectangle hinzu.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Im nachstehenden Beispiel haben wir ein einfaches Rechteck zur ersten Folie der Präsentation hinzugefügt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SimpleRectangle-SimpleRectangle.cpp" >}}

## **Formatiertes Rechteck erstellen**
Um ein formatiertes Rechteck zu einer Folie hinzuzufügen, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation class](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Holen Sie die Referenz einer Folie, indem Sie deren Index verwenden.
1. Fügen Sie über die AddAutoShape‑Methode des IShapes‑Objekts ein IAutoShape vom Typ Rectangle hinzu.
1. Setzen Sie den Fülltyp des Rechtecks auf Solid.
1. Setzen Sie die Farbe des Rechtecks über die Eigenschaft SolidFillColor.Color, die vom FillFormat‑Objekt des zugehörigen IShape‑Objekts bereitgestellt wird.
1. Setzen Sie die Farbe der Linien des Rechtecks.
1. Setzen Sie die Breite der Linien des Rechtecks.
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.
   Die obigen Schritte sind im nachstehenden Beispiel implementiert.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FormattedRectangle-FormattedRectangle.cpp" >}}

## **FAQ**

**Wie füge ich ein Rechteck mit abgerundeten Ecken hinzu?**

Verwenden Sie den abgerundeten [Shape‑Typ](https://reference.aspose.com/slides/cpp/aspose.slides/shapetype/) und passen Sie den Eckradius in den Eigenschaften der Form an; das Abrunden kann auch für jede Ecke einzeln über Geometrie‑Anpassungen erfolgen.

**Wie fülle ich ein Rechteck mit einem Bild (Textur)?**

Wählen Sie den Bild‑[Fill‑Typ](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/), geben Sie die Bildquelle an und konfigurieren Sie die [Dehn‑/Kachel‑Modi](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/).

**Kann ein Rechteck Schatten und Leuchten haben?**

Ja. [Außen‑/Innenschatten, Leuchten und weiche Kanten](/slides/de/cpp/shape-effect/) stehen mit einstellbaren Parametern zur Verfügung.

**Kann ich ein Rechteck in einen Button mit Hyperlink umwandeln?**

Ja. [Weisen Sie der Form einen Hyperlink](/slides/de/cpp/manage-hyperlinks/) für den Klick zu (Springt zu einer Folie, Datei, Webadresse oder E‑Mail).

**Wie kann ich ein Rechteck vor Verschieben und Änderungen schützen?**

[Verwenden Sie Form‑Sperren](/slides/de/cpp/applying-protection-to-presentation/): Sie können das Verschieben, die Größenänderung, die Auswahl oder das Text‑Bearbeiten verbieten, um das Layout zu erhalten.

**Kann ich ein Rechteck in ein Rasterbild oder SVG umwandeln?**

Ja. Sie können die Form [rendern](http://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/) zu einem Bild mit einer angegebenen Größe/Skalierung oder [als SVG exportieren](https://reference.aspose.com/slides/cpp/aspose.slides/shape/writeassvg/) für die Vektornutzung.

**Wie erhalte ich schnell die tatsächlichen (effektiven) Eigenschaften eines Rechtecks unter Berücksichtigung von Theme und Vererbung?**

[Verwenden Sie die effektiven Eigenschaften der Form](/slides/de/cpp/shape-effective-properties/): Die API liefert berechnete Werte, die Theme‑Stile, Layout und lokale Einstellungen berücksichtigen, und vereinfacht so die Analyse der Formatierung.