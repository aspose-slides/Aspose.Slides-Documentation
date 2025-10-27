---
title: Eine Präsentation in Python erstellen
linktitle: Präsentation erstellen
type: docs
weight: 10
url: /de/python-net/create-presentation/
keywords:
- Präsentation erstellen
- Neue Präsentation
- PPT erstellen
- Neue PPT
- PPTX erstellen
- Neue PPTX
- ODP erstellen
- Neue ODP
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "PowerPoint‑Präsentationen in Python mit Aspose.Slides erstellen – PPT-, PPTX- und ODP-Dateien erzeugen, von der OpenDocument‑Unterstützung profitieren und sie programmgesteuert speichern für zuverlässige Ergebnisse."
---

## **Übersicht**

Aspose.Slides for Python ermöglicht das Erstellen einer brandneuen Präsentationsdatei vollständig im Code. Dieser Artikel zeigt den Kernablauf – das Erzeugen eines [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Objekts, das Abrufen der ersten Folie, das Einfügen einer einfachen Form und das Speichern des Ergebnisses – damit Sie sehen, wie wenig Einrichtung nötig ist, um eine Präsentation ohne Microsoft Office zu generieren. Da dieselbe API PPT, PPTX und ODP Dateien schreibt, können Sie sowohl traditionelle PowerPoint‑ als auch OpenDocument‑Formate aus einer einzigen Codebasis ansprechen. Aspose.Slides eignet sich für Desktop‑, Web‑ oder Serverumgebungen und bietet Ihrer Python‑Anwendung einen effizienten Ausgangspunkt, um reichhaltigere Inhalte wie Text, Bilder oder Diagramme hinzuzufügen, sobald das anfängliche Folienset vorhanden ist.

## **Eine Präsentation erstellen**

Das Erstellen einer PowerPoint‑Datei von Grund auf in Aspose.Slides for Python ist so einfach wie das Instanziieren der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse. Der Konstruktor liefert automatisch ein leeres Deck mit einer einzigen Folie, das Ihnen sofort eine Zeichenfläche für Formen, Text, Diagramme oder andere Inhalte bietet, die Ihre Anwendung benötigt. Sobald Sie diese Folie bearbeiten – oder neue hinzufügen – können Sie das Ergebnis als PPTX, das alte PPT‑Format oder sogar OpenDocument‑Formate speichern. Das kurze Codebeispiel unten veranschaulicht diesen Ablauf, indem es eine einfache Form zur ersten Folie hinzufügt.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
2. Holen Sie eine Referenz zur Folie über ihren Index.  
3. Fügen Sie ein [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)‑Objekt vom Typ `CLOUD` mit der Methode `add_auto_shape` hinzu, die über die `shapes`‑Sammlung bereitgestellt wird.  
4. Fügen Sie dem AutoShape Text hinzu.  
5. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Im folgenden Beispiel wird ein Wolken‑Shape zur ersten Folie der Präsentation hinzugefügt.

```py
import aspose.slides as slides

# Instanziiere die Presentation‑Klasse, die eine Präsentationsdatei repräsentiert.
with slides.Presentation() as presentation:
    # Hole die erste Folie.
    slide = presentation.slides[0]

    # Füge ein AutoShape vom Typ CLOUD hinzu.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # Speichere die Präsentation als PPTX‑Datei.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![Die neue Präsentation](new_presentation.png)

## **FAQ**

**In welchen Formaten kann ich eine neue Präsentation speichern?**

Sie können in [PPTX, PPT und ODP](/slides/de/python-net/save-presentation/) speichern und in [PDF](/slides/de/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/de/python-net/convert-powerpoint-to-xps/), [HTML](/slides/de/python-net/convert-powerpoint-to-html/), [SVG](/slides/de/python-net/convert-powerpoint-to-png/) und [Bilder](/slides/de/python-net/convert-powerpoint-to-png/) exportieren, unter anderem.

**Kann ich von einer Vorlage (POTX/POTM) ausgehen und als reguläre PPTX speichern?**

Ja. Laden Sie die Vorlage und speichern Sie sie im gewünschten Format; POTX/POTM/PPTM und ähnliche Formate sind [unterstützt](/slides/de/python-net/supported-file-formats/).

**Wie kann ich die Foliengröße bzw. das Seitenverhältnis beim Erstellen einer Präsentation steuern?**

Setzen Sie die [Foliengröße](/slides/de/python-net/slide-size/) (einschließlich Voreinstellungen wie 4:3 und 16:9 oder benutzerdefinierte Abmessungen) und wählen Sie, wie Inhalte skaliert werden sollen.

**In welchen Einheiten werden Größen und Koordinaten gemessen?**

In Punkten: 1 Zoll entspricht 72 Einheiten.

**Wie gehe ich mit sehr großen Präsentationen (mit vielen Mediendateien) um, um den Speicherverbrauch zu reduzieren?**

Verwenden Sie [BLOB‑Verwaltungsstrategien](/slides/de/python-net/manage-blob/), begrenzen Sie den In‑Memory‑Speicher durch Nutzung temporärer Dateien und bevorzugen Sie dateibasierte Workflows statt rein speicherbasierter Streams.

**Kann ich Präsentationen parallel erstellen/speichern?**

Sie können nicht dieselbe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Instanz aus [mehreren Threads](/slides/de/python-net/multithreading/) bedienen. Führen Sie getrennte, isolierte Instanzen pro Thread oder Prozess aus.

**Wie entferne ich das Testwasserzeichen und die Einschränkungen?**

[Wenden Sie eine Lizenz](/slides/de/python-net/licensing/) pro Prozess an. Die Lizenz‑XML muss unverändert bleiben, und die Lizenz‑Initialisierung sollte synchronisiert werden, wenn mehrere Threads beteiligt sind.

**Kann ich das erstellte PPTX digital signieren?**

Ja. [Digitale Signaturen](/slides/de/python-net/digital-signature-in-powerpoint/) (Hinzufügen und Verifizieren) werden für Präsentationen unterstützt.

**Werden Makros (VBA) in erstellten Präsentationen unterstützt?**

Ja. Sie können [VBA‑Projekte erstellen/bearbeiten](/slides/de/python-net/presentation-via-vba/) und makroaktivierte Dateien wie PPTM/PPSM speichern.