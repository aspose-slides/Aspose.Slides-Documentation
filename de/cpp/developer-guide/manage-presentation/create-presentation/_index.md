---
title: Präsentationen in C++ erstellen
linktitle: Präsentation erstellen
type: docs
weight: 10
url: /de/cpp/create-presentation/
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
- Präsentation
- C++
- Aspose.Slides
description: "Präsentationen in C++ mit Aspose.Slides erstellen - PPT-, PPTX- und ODP-Dateien erzeugen, von OpenDocument-Unterstützung profitieren und sie programmgesteuert speichern für zuverlässige Ergebnisse."
---

## **PowerPoint-Präsentation erstellen**
Um eine einfache gerade Linie zu einer ausgewählten Folie der Präsentation hinzuzufügen, folgen Sie bitte den nachstehenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
1. Holen Sie die Referenz einer Folie mithilfe ihres Index.
1. Fügen Sie eine AutoShape vom Typ Linie mithilfe der AddAutoShape-Methode hinzu, die vom Shapes-Objekt bereitgestellt wird.
1. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Im nachstehenden Beispiel haben wir eine Linie zur ersten Folie der Präsentation hinzugefügt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateNewPresentation-CreateNewPresentation.cpp" >}}

## **FAQ**

**In welchen Formaten kann ich eine neue Präsentation speichern?**

Sie können in [PPTX, PPT und ODP](/slides/de/cpp/save-presentation/) speichern und zu [PDF](/slides/de/cpp/convert-powerpoint-to-pdf/), [XPS](/slides/de/cpp/convert-powerpoint-to-xps/), [HTML](/slides/de/cpp/convert-powerpoint-to-html/), [SVG](/slides/de/cpp/convert-powerpoint-to-png/) und [Bildern](/slides/de/cpp/convert-powerpoint-to-png/) exportieren, unter anderem.

**Kann ich von einer Vorlage (POTX/POTM) starten und als reguläres PPTX speichern?**

Ja. Laden Sie die Vorlage und speichern Sie sie im gewünschten Format; POTX/POTM/PPTM und ähnliche Formate [werden unterstützt](/slides/de/cpp/supported-file-formats/).

**Wie kann ich die Foliengröße bzw. das Seitenverhältnis beim Erstellen einer Präsentation steuern?**

Legen Sie die [Foliengröße](/slides/de/cpp/slide-size/) fest (einschließlich Voreinstellungen wie 4:3 und 16:9 oder benutzerdefinierte Abmessungen) und bestimmen Sie, wie der Inhalt skaliert werden soll.

**In welchen Einheiten werden Größe und Koordinaten gemessen?**

In Punkten: 1 Zoll entspricht 72 Einheiten.

**Wie gehe ich mit sehr großen Präsentationen (mit vielen Mediendateien) um, um den Speicherverbrauch zu reduzieren?**

Verwenden Sie [BLOB-Verwaltungsstrategien](/slides/de/cpp/manage-blob/), begrenzen Sie den In‑Memory‑Speicher durch Nutzung temporärer Dateien und bevorzugen Sie dateibasierte Workflows gegenüber rein speicherinternen Streams.

**Kann ich Präsentationen parallel erstellen/speichern?**

Sie können nicht dieselbe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Instanz von [mehreren Threads](/slides/de/cpp/multithreading/) aus verwenden. Führen Sie separate, isolierte Instanzen pro Thread oder Prozess aus.

**Wie entferne ich das Testwasserzeichen und die Einschränkungen?**

[Wenden Sie eine Lizenz](/slides/de/cpp/licensing/) pro Prozess an. Die Lizenz‑XML muss unverändert bleiben, und die Lizenzkonfiguration sollte synchronisiert werden, wenn mehrere Threads beteiligt sind.

**Kann ich das von mir erstellte PPTX digital signieren?**

Ja. [Digitale Signaturen](/slides/de/cpp/digital-signature-in-powerpoint/) (Hinzufügen und Überprüfen) werden für Präsentationen unterstützt.

**Werden Makros (VBA) in erstellten Präsentationen unterstützt?**

Ja. Sie können [VBA‑Projekte erstellen/bearbeiten](/slides/de/cpp/presentation-via-vba/) und makrofähige Dateien wie PPTM/PPSM speichern.