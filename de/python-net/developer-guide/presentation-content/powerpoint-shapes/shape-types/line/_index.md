---
title: Linienformen in Präsentationen mit Python erstellen
linktitle: Linie
type: docs
weight: 50
url: /de/python-net/line/
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
description: "Erfahren Sie, wie Sie die Linienformatierung in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Python via .NET manipulieren. Entdecken Sie Eigenschaften, Methoden und Beispiele."
---

## **Übersicht**

Aspose.Slides for Python via .NET unterstützt das Hinzufügen verschiedener Formen zu Folien. In diesem Thema beginnen wir damit, Formen zu verwenden, indem wir Linien zu den Folien hinzufügen. Mit Aspose.Slides können Entwickler nicht nur einfache Linien erstellen, sondern auch einige ausgefallene Linien auf den Folien zeichnen.

## **Einfache Linien erstellen**

Verwenden Sie Aspose.Slides, um einer Folie eine einfache Linie als Trennzeichen oder Verbindung hinzuzufügen. Um einer ausgewählten Folie in einer Präsentation eine einfache Linie hinzuzufügen, führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.  
2. Holen Sie sich eine Referenz zur Folie nach Index.  
3. Fügen Sie ein [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) des Typs `LINE` mit der Methode `add_auto_shape` des [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) Objekts hinzu.  
4. Speichern Sie die Präsentation als PPTX-Datei.

Im Beispiel unten wird einer Linie zur ersten Folie der Präsentation hinzugefügt.

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

Aspose.Slides ermöglicht das Konfigurieren von Linieneigenschaften, um sie optisch ansprechender zu gestalten. Im Folgenden konfigurieren wir einige Eigenschaften einer Linie, um sie wie einen Pfeil aussehen zu lassen. Führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.  
2. Holen Sie sich eine Referenz zu einer Folie nach Index.  
3. Fügen Sie ein [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) des Typs `LINE` mit der Methode `add_auto_shape` des [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) Objekts hinzu.  
4. Setzen Sie den [Linienstil](https://reference.aspose.com/slides/python-net/aspose.slides/linestyle/).  
5. Setzen Sie die Linienbreite.  
6. Setzen Sie den [Strichstil](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/).  
7. Setzen Sie den [Pfeilspitzenstil](https://reference.aspose.com/slides/python-net/aspose.slides/linearrowheadstyle/) und die Länge für den Startpunkt der Linie.  
8. Setzen Sie den Pfeilspitzenstil und die Länge für den Endpunkt der Linie.  
9. Speichern Sie die Präsentation als PPTX-Datei.

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

**Kann ich eine reguläre Linie in einen Verbinder umwandeln, damit sie an Formen "schnappt"?**

Nein. Eine reguläre Linie (ein [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) des Typs [LINE](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/)) wird nicht automatisch zu einem Verbinder. Um sie an Formen schnappen zu lassen, verwenden Sie den dedizierten [Connector](https://reference.aspose.com/slides/python-net/aspose.slides/connector/) Typ und die entsprechenden APIs[/slides/python-net/connector/] für Verbindungen.

**Was soll ich tun, wenn die Linieneigenschaften vom Design geerbt werden und es schwierig ist, die endgültigen Werte zu bestimmen?**

Lesen Sie die effektiven Eigenschaften[/slides/python-net/shape-effective-properties/] durch die Klassen [ILineFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilinefillformateffectivedata/) – diese berücksichtigen bereits Vererbung und Design‑Stile.

**Kann ich eine Linie gegen Bearbeitung (Verschieben, Größenänderung) sperren?**

Ja. Formen bieten [Sperrobjekte](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/auto_shape_lock/), mit denen Sie [Bearbeitungsvorgänge verbieten](/slides/de/python-net/applying-protection-to-presentation/).