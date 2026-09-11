---
title: Rechtecke zu Präsentationen in Python über Java hinzufügen
linktitle: Rechteck
type: docs
weight: 80
url: /de/python-java/rectangle/
keywords:
- Rechteck hinzufügen
- Rechteck erstellen
- Rechtecksform
- einfaches Rechteck
- formatiertes Rechteck
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Verbessern Sie Ihre PowerPoint‑Präsentationen, indem Sie mit Aspose.Slides für Python über Java Rechtecke hinzufügen – gestalten und ändern Sie Formen programmgesteuert."
---
## **Übersicht**

Dieser Artikel zeigt, wie man Rechteckformen zu PowerPoint‑Folien mit Aspose.Slides hinzufügt. Er behandelt das Erstellen eines einfachen Rechtecks, das Erstellen eines formatierten Rechtecks und das Speichern der aktualisierten Präsentation als PPTX‑Datei. Sie sehen außerdem, wie man grundlegende Rechtecksformatierungen anwendet, wie eine einfarbige Füllfarbe, Linienfarbe und Linienstärke. Darüber hinaus verweist der FAQ‑Abschnitt des Artikels auf verwandte Rechteckaufgaben, einschließlich abgerundeter Ecken, Bildfüllungen, visueller Effekte, Hyperlinks, Formschlösser, Exportoptionen und effektiver Eigenschaften.

## **Rechteck zu einer Folie hinzufügen**

Um ein einfaches Rechteck zu einer ausgewählten Folie der Präsentation hinzuzufügen, befolgen Sie die folgenden Schritte:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/).
- Holen Sie sich eine Referenz auf eine Folie über deren Index.
- Fügen Sie über die Methode [addAutoShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapecollection/#addAutoShape) des [ShapeCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapecollection/)‑Objekts eine [AutoShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/autoshape/) vom Typ Rechteck hinzu.
- Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Im nachstehenden Beispiel haben wir ein einfaches Rechteck zur ersten Folie der Präsentation hinzugefügt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Instanziieren Sie die Presentation‑Klasse, die die PPTX‑Datei darstellt.
presentation = Presentation()
try:
    # Holen Sie die erste Folie.
    slide = presentation.getSlides().get_Item(0)

    # Fügen Sie eine Rechteckform hinzu.
    slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50)

    # Schreiben Sie die PPTX‑Datei auf die Festplatte.
    presentation.save("RecShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Formatiertes Rechteck zu einer Folie hinzufügen**

Um ein formatiertes Rechteck zu einer Folie hinzuzufügen, befolgen Sie die folgenden Schritte:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/).
- Holen Sie sich eine Referenz auf eine Folie über deren Index.
- Fügen Sie über die Methode [addAutoShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapecollection/#addAutoShape) des [ShapeCollection](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapecollection/)‑Objekts eine [AutoShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/autoshape/) vom Typ Rechteck hinzu.
- Setzen Sie den [fill type](https://reference.aspose.com/slides/de/python-java/aspose.slides/filltype/) des Rechtecks auf solid.
- Setzen Sie die Farbe des Rechtecks mittels der Methode [setColor](https://reference.aspose.com/slides/de/python-java/aspose.slides/colorformat/#setColor) auf der einfarbigen Füllfarbe des [FillFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/fillformat/)‑Objekts, das dem [Shape](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/)‑Objekt zugeordnet ist.
- Setzen Sie die Farbe der Kontur des Rechtecks.
- Setzen Sie die Breite der Kontur des Rechtecks.
- Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Die oben genannten Schritte sind im nachstehenden Beispiel umgesetzt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Instanziieren Sie die Presentation‑Klasse, die die PPTX‑Datei darstellt.
presentation = Presentation()
try:
    # Holen Sie die erste Folie.
    slide = presentation.getSlides().get_Item(0)

    # Fügen Sie eine Rechteckform hinzu.
    rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50)

    # Formatieren Sie die Füllung des Rechtecks.
    rectangle.getFillFormat().setFillType(FillType.Solid)
    rectangle.getFillFormat().getSolidFillColor().setColor(Color.GRAY)

    # Formatieren Sie die Kontur des Rechtecks.
    rectangle.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    rectangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    rectangle.getLineFormat().setWidth(5)

    # Schreiben Sie die PPTX‑Datei auf die Festplatte.
    presentation.save("RecShp2.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Wie füge ich ein Rechteck mit abgerundeten Ecken hinzu?**

Verwenden Sie den abgerundeten [shape type](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapetype/) und passen Sie den Eckenradius in den Eigenschaften der Form an; das Abrunden kann auch für jede Ecke einzeln über Geometrie‑Anpassungen erfolgen.

**Wie fülle ich ein Rechteck mit einem Bild (Textur)?**

Wählen Sie den Bild‑[fill type](https://reference.aspose.com/slides/de/python-java/aspose.slides/filltype/), geben Sie die Bildquelle an und konfigurieren Sie die [stretching/tiling modes](https://reference.aspose.com/slides/de/python-java/aspose.slides/picturefillmode/).

**Kann ein Rechteck Schatten und Leuchteffekt haben?**

Ja. [Outer/inner shadow, glow, and soft edges](/slides/de/python-java/shape-effect/) stehen mit einstellbaren Parametern zur Verfügung.

**Kann ich ein Rechteck in eine Schaltfläche mit Hyperlink verwandeln?**

Ja. [Assign a hyperlink](/slides/de/python-java/manage-hyperlinks/) dem Klick auf die Form (Springen zu einer Folie, Datei, Webadresse oder E‑Mail).

**Wie kann ich ein Rechteck vor Verschieben und Änderungen schützen?**

[Use shape locks](/slides/de/python-java/applying-protection-to-presentation/): Sie können das Verschieben, die Größenänderung, Auswahl oder Textbearbeitung verhindern, um das Layout zu bewahren.

**Kann ich ein Rechteck in ein Rasterbild oder SVG umwandeln?**

Ja. Sie können die Form mit [render the shape](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#getImage) zu einem Bild in einer angegebenen Größe/Skalierung rendern oder sie [export it as SVG](/slides/de/python-java/create-shape-thumbnails/) für die Vektornutzung exportieren.

**Wie erhalte ich schnell die tatsächlichen (effektiven) Eigenschaften eines Rechtecks unter Berücksichtigung von Design und Vererbung?**

[Use the shape’s effective properties](/slides/de/python-java/shape-effective-properties/): Die API liefert berechnete Werte, die Design‑Stile, Layout und lokale Einstellungen berücksichtigen, und vereinfacht so die Analyse der Formatierung.