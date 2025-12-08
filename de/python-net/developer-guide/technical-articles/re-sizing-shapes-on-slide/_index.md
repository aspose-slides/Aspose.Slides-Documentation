---
title: Formen in Präsentationen mit Python skalieren
linktitle: Formen skalieren
type: docs
weight: 130
url: /de/python-net/re-sizing-shapes-on-slide/
keywords:
- Form skalieren
- Formgröße ändern
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Einfach Formen auf PowerPoint- und OpenDocument-Folien mit Aspose.Slides für Python über .NET skalieren — automatisieren Sie die Anpassung des Folienlayouts und steigern Sie die Produktivität."
---

## **Übersicht**

Eine der häufigsten Fragen von Aspose.Slides for Python‑Kunden ist, wie man Formen so skaliert, dass bei einer Änderung der Foliengröße die Daten nicht abgeschnitten werden. Dieser kurze technische Beitrag zeigt, wie das geht.

## **Formen skalieren**

Damit sich Formen bei einer Änderung der Foliengröße nicht verschieben, aktualisieren Sie die Position und die Abmessungen jeder Form, sodass sie zum neuen Folienlayout passen.
```py
import aspose.slides as slides

    # Präsentationsdatei laden.
    with slides.Presentation("sample.pptx") as presentation:
        # Originalgröße der Folie abrufen.
        current_height = presentation.slide_size.size.height
        current_width = presentation.slide_size.size.width

        # Foliengröße ändern, ohne vorhandene Formen zu skalieren.
        presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

        # Neue Foliengröße abrufen.
        new_height = presentation.slide_size.size.height
        new_width = presentation.slide_size.size.width

        height_ratio = new_height / current_height
        width_ratio = new_width / current_width

        # Formen auf jeder Folie skalieren und neu positionieren.
        for slide in presentation.slides:
            for shape in slide.shapes:
                # Größe der Form skalieren.
                shape.height = shape.height * height_ratio
                shape.width = shape.width * width_ratio

                # Position der Form skalieren.
                shape.y = shape.y * height_ratio
                shape.x = shape.x * width_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert color="primary" %}} 
Wenn eine Folie eine Tabelle enthält, funktioniert der obige Code nicht korrekt. In diesem Fall muss jede Zelle der Tabelle skaliert werden.
{{% /alert %}} 

Verwenden Sie den folgenden Code, um Folien mit Tabellen zu skalieren. Bei Tabellen ist das Setzen von Breite oder Höhe ein Sonderfall: Sie müssen die einzelnen Zeilenhöhen und Spaltenbreiten anpassen, um die Gesamtabmessungen der Tabelle zu ändern.
```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # Originale Foliengröße abrufen.
    current_height = presentation.slide_size.size.height
    current_width = presentation.slide_size.size.width

    # Foliengröße ändern, ohne vorhandene Formen zu skalieren.
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    # Neue Foliengröße abrufen.
    new_height = presentation.slide_size.size.height
    new_width = presentation.slide_size.size.width

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    for master in presentation.masters:
        for shape in master.shapes:
            # Formgröße skalieren.
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # Formposition skalieren.
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

        for layout_slide in master.layout_slides:
            for shape in layout_slide.shapes:
                # Formgröße skalieren.
                shape.height = shape.height * height_ratio
                shape.width = shape.width * width_ratio

                # Formposition skalieren.
                shape.y = shape.y * height_ratio
                shape.x = shape.x * width_ratio

    for slide in presentation.slides:
        for shape in slide.shapes:
            # Formgröße skalieren.
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # Formposition skalieren.
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

            if type(shape) is slides.Table:
                for row in shape.rows:
                    row.minimal_height = row.minimal_height * height_ratio
                for column in shape.columns:
                    column.width = column.width * width_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Warum werden Formen nach dem Skalieren einer Folie verzerrt oder abgeschnitten?**

Beim Skalieren einer Folie behalten Formen ihre ursprüngliche Position und Größe, sofern die Skalierung nicht explizit geändert wird. Das kann dazu führen, dass Inhalte abgeschnitten oder Formen missaligned werden.

**Funktioniert der bereitgestellte Code für alle Formtypen?**

Das Basisbeispiel funktioniert für die meisten Formtypen (Textfelder, Bilder, Diagramme usw.). Bei Tabellen müssen Sie jedoch Zeilen und Spalten separat behandeln, da Höhe und Breite einer Tabelle durch die Abmessungen der einzelnen Zellen bestimmt werden.

**Wie skaliere ich Tabellen beim Skalieren einer Folie?**

Sie müssen alle Zeilen und Spalten der Tabelle durchlaufen und deren Höhe und Breite proportional anpassen, wie im zweiten Codebeispiel gezeigt.

**Funktioniert dieses Skalieren auch für Master‑Folien und Layout‑Folien?**

Ja, Sie sollten außerdem durch [Masterfolien](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) und [Layoutfolien](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/layout_slides/) iterieren und dieselbe Skalierungslogik auf deren Formen anwenden, um Konsistenz in der gesamten Präsentation sicherzustellen.

**Kann ich die Orientierung einer Folie (Portrait/Landscape) zusammen mit dem Skalieren ändern?**

Ja. Sie können [presentation.slide_size.orientation](https://reference.aspose.com/slides/python-net/aspose.slides/islidesize/orientation/) verwenden, um die Orientierung zu ändern. Stellen Sie sicher, dass Sie die Skalierungslogik entsprechend anpassen, um das Layout beizubehalten.

**Gibt es ein Limit für die Foliengröße, die ich festlegen kann?**

Aspose.Slides unterstützt benutzerdefinierte Größen, aber sehr große Größen können die Leistung oder die Kompatibilität mit einigen PowerPoint‑Versionen beeinträchtigen.

**Wie kann ich verhindern, dass Formen mit festem Seitenverhältnis verzerrt werden?**

Sie können die Eigenschaft `aspect_ratio_locked` der Form vor dem Skalieren prüfen. Ist sie gesperrt, passen Sie Breite oder Höhe proportional an, anstatt sie einzeln zu skalieren.