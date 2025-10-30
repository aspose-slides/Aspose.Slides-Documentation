---
title: Präsentation in Python erstellen
linktitle: Präsentation erstellen
type: docs
weight: 10
url: /de/python-net/create-presentation/
keywords:
- Präsentation erstellen
- neue Präsentation
- PPT erstellen
- neues PPT
- PPTX erstellen
- neues PPTX
- ODP erstellen
- neues ODP
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Erstellen Sie PowerPoint‑Präsentationen in Python mit Aspose.Slides — generieren Sie PPT-, PPTX‑ und ODP‑Dateien, profitieren Sie von OpenDocument‑Unterstützung und speichern Sie sie programmgesteuert für zuverlässige Ergebnisse."
---

## **Übersicht**

Aspose.Slides für Python ermöglicht es Ihnen, eine komplett neue Präsentationsdatei ausschließlich im Code zu erstellen. Dieser Artikel zeigt den Kern‑Workflow — Erstellung eines [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Objekts, Abrufen der ersten Folie, Einfügen einer einfachen Form und Speichern des Ergebnisses — so dass Sie sehen, wie wenig Aufwand nötig ist, um eine Präsentation ohne Microsoft Office zu erzeugen. Da dieselbe API PPT-, PPTX- und ODP‑Dateien schreibt, können Sie sowohl traditionelle PowerPoint‑ als auch OpenDocument‑Formate aus einer einzigen Codebasis heraus ansprechen. Aspose.Slides eignet sich für Desktop‑, Web‑ oder Server‑Umgebungen und bietet Ihrer Python‑Anwendung einen effizienten Ausgangspunkt, um nach dem Anlegen des ersten Folienstapels reichhaltigere Inhalte wie Text, Bilder oder Diagramme hinzuzufügen.

## **Präsentation erstellen**

Eine PowerPoint‑Datei von Grund auf in Aspose.Slides für Python zu erstellen ist so einfach wie das Instanziieren der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse. Der Konstruktor liefert automatisch ein leeres Deck mit einer einzigen Folie, sodass Sie sofort eine Leinwand für Formen, Text, Diagramme oder anderen Inhalt haben, den Ihre Anwendung benötigt. Sobald Sie diese Folie geändert — oder neue hinzugefügt — können Sie das Ergebnis als PPTX, das klassische PPT oder sogar als OpenDocument‑Format speichern. Das kurze Code‑Beispiel unten veranschaulicht diesen Workflow, indem es eine einfache Form zur ersten Folie hinzufügt.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.  
2. Holen Sie sich eine Referenz zur Folie über ihren Index.  
3. Fügen Sie ein [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)-Objekt vom Typ `CLOUD` mithilfe der `add_auto_shape`‑Methode der `shapes`‑Sammlung hinzu.  
4. Fügen Sie dem AutoShape Text hinzu.  
5. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Im Beispiel unten wird eine Wolkenform zur ersten Folie der Präsentation hinzugefügt.

```py
import aspose.slides as slides

# Instanziieren der Presentation-Klasse, die eine Präsentationsdatei darstellt.
with slides.Presentation() as presentation:
    # Holen Sie die erste Folie.
    slide = presentation.slides[0]

    # Fügen Sie eine Autoform vom Typ CLOUD hinzu.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # Speichern Sie die Präsentation als PPTX-Datei.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis:

![Die neue Präsentation](new_presentation.png)

## **FAQ**

**In welche Formate kann ich eine neue Präsentation speichern?**

Sie können in [PPTX, PPT und ODP](/slides/de/python-net/save-presentation/) speichern und in [PDF](/slides/de/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/de/python-net/convert-powerpoint-to-xps/), [HTML](/slides/de/python-net/convert-powerpoint-to-html/), [SVG](/slides/de/python-net/convert-powerpoint-to-png/) und [Bilder](/slides/de/python-net/convert-powerpoint-to-png/) exportieren, unter anderem.

**Kann ich von einer Vorlage (POTX/POTM) starten und als reguläres PPTX speichern?**

Ja. Laden Sie die Vorlage und speichern Sie sie im gewünschten Format; POTX/POTM/PPTM und ähnliche Formate werden [unterstützt](/slides/de/python-net/supported-file-formats/).

**Wie steuere ich die Foliengröße/Seitenverhältnis beim Erstellen einer Präsentation?**

Setzen Sie die [Foliengröße](/slides/de/python-net/slide-size/) (inklusive Voreinstellungen wie 4:3 und 16:9 oder benutzerdefinierte Abmessungen) und wählen Sie aus, wie der Inhalt skaliert werden soll.

**In welchen Einheiten werden Größen und Koordinaten gemessen?**

In Punkten: 1 Zoll entspricht 72 Einheiten.

**Wie gehe ich mit sehr großen Präsentationen (mit vielen Mediendateien) um, um den Speicherverbrauch zu reduzieren?**

Verwenden Sie [BLOB‑Verwaltungsstrategien](/slides/de/python-net/manage-blob/), begrenzen Sie den In‑Memory‑Speicher durch temporäre Dateien und bevorzugen Sie dateibasierte Workflows gegenüber reinem In‑Memory‑Streaming.

**Kann ich Präsentationen parallel erstellen/speichern?**

Sie können nicht dieselbe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Instanz von [mehreren Threads](/slides/de/python-net/multithreading/) aus bearbeiten. Führen Sie separate, isolierte Instanzen pro Thread oder Prozess aus.

**Wie entferne ich das Test‑Wasserzeichen und die Einschränkungen?**

[Wenden Sie eine Lizenz](/slides/de/python-net/licensing/) pro Prozess an. Die Lizenz‑XML darf nicht verändert werden, und die Lizenz‑Initialisierung sollte synchronisiert werden, wenn mehrere Threads beteiligt sind.

**Kann ich das PPTX, das ich erstelle, digital signieren?**

Ja. [Digitale Signaturen](/slides/de/python-net/digital-signature-in-powerpoint/) (Hinzufügen und Überprüfen) werden für Präsentationen unterstützt.

**Werden Makros (VBA) in erstellten Präsentationen unterstützt?**

Ja. Sie können [VBA‑Projekte erstellen/bearbeiten](/slides/de/python-net/presentation-via-vba/) und makro‑aktivierte Dateien wie PPTM/PPSM speichern.