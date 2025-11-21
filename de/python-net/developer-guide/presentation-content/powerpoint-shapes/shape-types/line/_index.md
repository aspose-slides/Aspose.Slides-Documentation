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
description: "Erfahren Sie, wie Sie die Linienformatierung in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Python via .NET manipulieren können. Entdecken Sie Eigenschaften, Methoden und Beispiele."
---

## **Übersicht**

Aspose.Slides für Python via .NET unterstützt das Hinzufügen verschiedener Formen zu den Folien. In diesem Thema beginnen wir mit Formen, indem wir Linien zu den Folien hinzufügen. Mit Aspose.Slides können Entwickler nicht nur einfache Linien erstellen, sondern auch ausgefallene Linien auf den Folien zeichnen.

## **Einfache Linien erstellen**

Verwenden Sie Aspose.Slides, um einer Folie eine einfache Linie als Trenn- oder Verbindungslinie hinzuzufügen. So fügen Sie einer ausgewählten Folie in einer Präsentation eine einfache Linie hinzu:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich eine Referenz auf die Folie nach Index.
1. Fügen Sie dem [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/)‑Objekt eine [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) vom Typ `LINE` über die Methode `add_auto_shape` hinzu.
1. Speichern Sie die Präsentation als PPTX‑Datei.

Im folgenden Beispiel wird einer ersten Folie der Präsentation eine Linie hinzugefügt.
```py
import aspose.slides as slides

# Instanziieren der Presentation‑Klasse.
with slides.Presentation() as presentation:

    # Erste Folie holen.
    slide = presentation.slides[0]

    # AutoShape vom Typ LINE hinzufügen.
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # Präsentation als PPTX‑Datei speichern.
    presentation.save("line_shape.pptx", slides.export.SaveFormat.PPTX)
```


## **Pfeilförmige Linien erstellen**

Aspose.Slides ermöglicht das Konfigurieren von Linieneigenschaften, um sie optisch ansprechender zu gestalten. Im Folgenden konfigurieren wir einige Eigenschaften einer Linie, sodass sie wie ein Pfeil aussieht. Vorgehensweise:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich eine Referenz auf eine Folie nach Index.
1. Fügen Sie dem [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/)‑Objekt eine [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) vom Typ `LINE` über die Methode `add_auto_shape` hinzu.
1. Setzen Sie den [line style](https://reference.aspose.com/slides/python-net/aspose.slides/linestyle/).
1. Setzen Sie die Linienbreite.
1. Setzen Sie den [dash style](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) der Linie.
1. Setzen Sie den [arrowhead style](https://reference.aspose.com/slides/python-net/aspose.slides/linearrowheadstyle/) und die Länge für den Startpunkt der Linie.
1. Setzen Sie den Pfeilspitzen‑Stil und die Länge für den Endpunkt der Linie.
1. Speichern Sie die Präsentation als PPTX‑Datei.
```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanziieren der Presentation-Klasse, die die PPTX-Datei darstellt.
with slides.Presentation() as presentation:
    # Erste Folie holen.
    slide = presentation.slides[0]

    # AutoShape vom Typ LINE hinzufügen.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # Formatierung auf die Linie anwenden.
    shape.line_format.style = slides.LineStyle.THICK_BETWEEN_THIN
    shape.line_format.width = 10

    shape.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    shape.line_format.begin_arrowhead_length = slides.LineArrowheadLength.SHORT
    shape.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.OVAL

    shape.line_format.end_arrowhead_length = slides.LineArrowheadLength.LONG
    shape.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE

    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.maroon

    # Präsentation als PPTX-Datei speichern.
    presentation.save("line_shape_2.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Kann ich eine normale Linie in einen Connector umwandeln, sodass sie an Formen "einrastet"?**

Nein. Eine normale Linie (ein [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) vom Typ [LINE](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/)) wird nicht automatisch zu einem Connector. Verwenden Sie den dedizierten [Connector](https://reference.aspose.com/slides/python-net/aspose.slides/connector/)-Typ und die [corresponding APIs](/slides/de/python-net/connector/) für Verbindungen.

**Was soll ich tun, wenn die Eigenschaften einer Linie vom Theme geerbt werden und es schwierig ist, die endgültigen Werte zu bestimmen?**

[Lesen Sie die effektiven Eigenschaften](/slides/de/python-net/shape-effective-properties/) über die Klassen [ILineFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilinefillformateffectivedata/) – diese berücksichtigen bereits Vererbung und Theme‑Stile.

**Kann ich eine Linie gegen Bearbeiten (Verschieben, Größenänderung) sperren?**

Ja. Formen bieten [lock objects](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/auto_shape_lock/), mit denen Sie [disallow editing operations](/slides/de/python-net/applying-protection-to-presentation/) deaktivieren können.