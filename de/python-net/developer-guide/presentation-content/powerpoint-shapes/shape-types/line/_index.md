---
title: Linienformen in Präsentationen mit Python erstellen
linktitle: Linie
type: docs
weight: 50
url: /de/python-net/developer-guide/presentation-content/powerpoint-shapes/shape-types/line/
keywords:
- Linie
- Linie erstellen
- Linie hinzufügen
- einfache Linie
- Linie konfigurieren
- Linie anpassen
- Strichstil
- Pfeilspitze
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie die Linienformatierung in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Python via .NET manipulieren können. Entdecken Sie Eigenschaften, Methoden und Beispiele."
---

## **Übersicht**

Aspose.Slides für Python via .NET unterstützt das Hinzufügen verschiedener Formen zu Folien. In diesem Thema beginnen wir mit Formen, indem wir Linien zu den Folien hinzufügen. Mit Aspose.Slides können Entwickler nicht nur einfache Linien erstellen, sondern auch einige ausgefallene Linien auf den Folien zeichnen.

## **Einfache Linien erstellen**

Verwenden Sie Aspose.Slides, um einer Folie eine einfache Linie als Trenn- oder Verbindungselement hinzuzufügen. Um einer ausgewählten Folie in einer Präsentation eine einfache Linie hinzuzufügen, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
2. Holen Sie eine Referenz auf die Folie über ihren Index.  
3. Fügen Sie eine [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) vom Typ `LINE` mithilfe der Methode `add_auto_shape` des [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/)‑Objekts hinzu.  
4. Speichern Sie die Präsentation als PPTX‑Datei.

Im folgenden Beispiel wird einer ersten Folie der Präsentation eine Linie hinzugefügt.

```py
import aspose.slides as slides

# Instantiate the Presentation class.
with slides.Presentation() as presentation:

    # Get the first slide.
    slide = presentation.slides[0]

    # Add an auto shape of type LINE.
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # Save the presentation as a PPTX file.
    presentation.save("line_shape.pptx", slides.export.SaveFormat.PPTX)
```

## **Pfeilförmige Linien erstellen**

Aspose.Slides ermöglicht das Konfigurieren von Linieneigenschaften, um sie optisch ansprechender zu gestalten. Im Folgenden konfigurieren wir einige Eigenschaften einer Linie, damit sie wie ein Pfeil aussieht. Gehen Sie dabei wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
2. Holen Sie eine Referenz auf eine Folie über ihren Index.  
3. Fügen Sie eine [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) vom Typ `LINE` mithilfe der Methode `add_auto_shape` des [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/)‑Objekts hinzu.  
4. Legen Sie den [line style](https://reference.aspose.com/slides/python-net/aspose.slides/linestyle/) fest.  
5. Legen Sie die Linienstärke fest.  
6. Legen Sie den [dash style](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) der Linie fest.  
7. Legen Sie den [arrowhead style](https://reference.aspose.com/slides/python-net/aspose.slides/linearrowheadstyle/) und die Länge für den Startpunkt der Linie fest.  
8. Legen Sie den Pfeilspitzenstil und die Länge für den Endpunkt der Linie fest.  
9. Speichern Sie die Präsentation als PPTX‑Datei.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiate the Presentation class that represents the PPTX file.
with slides.Presentation() as presentation:
    # Get the first slide.
    slide = presentation.slides[0]

    # Add an auto shape of type LINE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # Apply formatting to the line.
    shape.line_format.style = slides.LineStyle.THICK_BETWEEN_THIN
    shape.line_format.width = 10

    shape.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    shape.line_format.begin_arrowhead_length = slides.LineArrowheadLength.SHORT
    shape.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.OVAL

    shape.line_format.end_arrowhead_length = slides.LineArrowheadLength.LONG
    shape.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE

    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.maroon

    # Save the presentation as a PPTX file.
    presentation.save("line_shape_2.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Kann ich eine normale Linie in einen Verbinder umwandeln, sodass sie an Formen „einrastet“?**

Nein. Eine normale Linie (eine [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) vom Typ [LINE](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/)) wird nicht automatisch zu einem Verbinder. Um sie an Formen einrasten zu lassen, verwenden Sie den dedizierten [Connector](https://reference.aspose.com/slides/python-net/aspose.slides/connector/)-Typ und die [entsprechenden APIs](/slides/de/python-net/connector/) für Verbindungen.

**Was soll ich tun, wenn die Eigenschaften einer Linie vom Theme geerbt werden und es schwer ist, die endgültigen Werte zu bestimmen?**

[Lesen Sie die effektiven Eigenschaften](/slides/de/python-net/shape-effective-properties/) über die Klassen [ILineFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilineformateffectivedata/) und [ILineFillFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilinefillformateffectivedata/). Diese berücksichtigen bereits Vererbung und Theme‑Stile.

**Kann ich eine Linie gegen Bearbeitung (Verschieben, Größenänderung) sperren?**

Ja. Formen bieten [Lock‑Objekte](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/auto_shape_lock/), mit denen Sie [Bearbeitungs‑Operationen verbieten](/slides/de/python-net/applying-protection-to-presentation/).