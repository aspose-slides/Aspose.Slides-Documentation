---
title: "Linienformen in Präsentationen mit Python erstellen"
linktitle: "Linie"
type: docs
weight: 50
url: /de/python-net/line/
keywords:
- "Linie"
- "Linie erstellen"
- "Linie hinzufügen"
- "einfache Linie"
- "Linie konfigurieren"
- "Linie anpassen"
- "Strichstil"
- "Pfeilspitze"
- "PowerPoint"
- "OpenDocument"
- "Präsentation"
- "Python"
- "Aspose.Slides"
description: "Erfahren Sie, wie Sie das Linienformat in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Python via .NET manipulieren können. Entdecken Sie Eigenschaften, Methoden und Beispiele."
---

## **Übersicht**

Aspose.Slides für Python via .NET unterstützt das Hinzufügen verschiedener Arten von Formen zu den Folien. In diesem Thema beginnen wir mit Formen, indem wir Linien zu den Folien hinzufügen. Mit Aspose.Slides können Entwickler nicht nur einfache Linien erstellen, sondern auch einige ausgefallene Linien auf den Folien zeichnen.

## **Einfache Linien erstellen**

Verwenden Sie Aspose.Slides, um einer Folie eine einfache Linie als einfachen Trennstrich oder Verbinder hinzuzufügen. Um einer ausgewählten Folie in einer Präsentation eine einfache Linie hinzuzufügen, führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.
2. Rufen Sie eine Referenz auf die Folie anhand ihres Index ab.
3. Fügen Sie eine [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) vom Typ `LINE` mithilfe der Methode `add_auto_shape` des [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/)-Objekts hinzu.
4. Speichern Sie die Präsentation als PPTX-Datei.

Im folgenden Beispiel wird eine Linie zur ersten Folie der Präsentation hinzugefügt.

```py
import aspose.slides as slides

# Instanziieren Sie die Presentation-Klasse.
with slides.Presentation() as presentation:

    # Rufen Sie die erste Folie ab.
    slide = presentation.slides[0]

    # Fügen Sie eine AutoShape vom Typ LINE hinzu.
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # Speichern Sie die Präsentation als PPTX-Datei.
    presentation.save("line_shape.pptx", slides.export.SaveFormat.PPTX)
```

## **Pfeilförmige Linien erstellen**

Aspose.Slides ermöglicht es Ihnen, Linieneigenschaften zu konfigurieren, um sie optisch ansprechender zu gestalten. Im Folgenden konfigurieren wir einige Eigenschaften einer Linie, damit sie wie ein Pfeil aussieht. Führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.
2. Rufen Sie eine Referenz auf eine Folie anhand ihres Index ab.
3. Fügen Sie eine [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) vom Typ `LINE` mithilfe der Methode `add_auto_shape` des [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/)-Objekts hinzu.
4. Setzen Sie den [line style](https://reference.aspose.com/slides/python-net/aspose.slides/linestyle/).
5. Setzen Sie die Linienbreite.
6. Setzen Sie den [dash style](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) der Linie.
7. Setzen Sie den [arrowhead style](https://reference.aspose.com/slides/python-net/aspose.slides/linearrowheadstyle/) und die Länge für den Startpunkt der Linie.
8. Setzen Sie den Pfeilspitzenstil und die Länge für den Endpunkt der Linie.
9. Speichern Sie die Präsentation als PPTX-Datei.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanziieren Sie die Presentation-Klasse, die die PPTX-Datei repräsentiert.
with slides.Presentation() as presentation:
    # Rufen Sie die erste Folie ab.
    slide = presentation.slides[0]

    # Fügen Sie eine AutoShape vom Typ LINE hinzu.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # Wenden Sie die Formatierung auf die Linie an.
    shape.line_format.style = slides.LineStyle.THICK_BETWEEN_THIN
    shape.line_format.width = 10

    shape.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    shape.line_format.begin_arrowhead_length = slides.LineArrowheadLength.SHORT
    shape.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.OVAL

    shape.line_format.end_arrowhead_length = slides.LineArrowheadLength.LONG
    shape.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE

    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.maroon

    # Speichern Sie die Präsentation als PPTX-Datei.
    presentation.save("line_shape_2.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Kann ich eine gewöhnliche Linie in einen Verbinder umwandeln, damit sie an Formen „schnappt“?**

Nein. Eine gewöhnliche Linie (eine [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) vom Typ [LINE](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/)) wird nicht automatisch zu einem Verbinder. Um sie an Formen „schnappen“ zu lassen, verwenden Sie den dedizierten [Connector](https://reference.aspose.com/slides/python-net/aspose.slides/connector/)-Typ und die [entsprechenden APIs](/slides/de/python-net/connector/) für Verbindungen.

**Was soll ich tun, wenn die Eigenschaften einer Linie vom Theme geerbt werden und es schwierig ist, die endgültigen Werte zu bestimmen?**

Lesen Sie die effektiven Eigenschaften über die Klassen [ILineFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilinefillformateffectivedata/) – diese berücksichtigen bereits Vererbung und Theme‑Stile.

**Kann ich eine Linie gegen Bearbeitung (Verschieben, Größenänderung) sperren?**

Ja. Formen stellen [lock objects](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/auto_shape_lock/) bereit, mit denen Sie [Bearbeitungsoperationen verhindern](/slides/de/python-net/applying-protection-to-presentation/).