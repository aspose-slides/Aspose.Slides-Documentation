---
title: FAQ
type: docs
weight: 340
url: /de/python-net/faq/
keywords:
- FAQ
- Präsentationsformat
- Speicherüberlauf-Fehler
- Foliengröße
- Text extrahieren
- Text abrufen
- Absatzgröße
- Tabellen formatieren
- Schriftart
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Erhalten Sie Antworten auf häufig gestellte Fragen zu Aspose.Slides für Python via .NET, einschließlich Unterstützung für PowerPoint und OpenDocument, Installationsanleitungen, Lizenzierung und Fehlersuche."
---

## **Unterstützte Dateiformate**

**Q:** Welche Dateiformate unterstützt Aspose.Slides für Python via .NET?

**A:** Aspose.Slides für Python via .NET unterstützt die in [Supported File Formats](/slides/de/python-net/supported-file-formats/) beschriebenen Dateiformate.

## **Ausnahmen**

**Q:** Ich erhalte eine Out-of-Memory-Ausnahme beim Laden einer großen PPT-Datei mit Bildern. Gibt es eine Begrenzung in Aspose.Slides bezüglich der Dateigröße?

**A:** Es gibt keine spezifische Formel zur Berechnung der von Aspose.Slides unterstützten Präsentationsgröße. Es sollte genügend Speicherplatz vorhanden sein, um die gesamte Präsentationsstruktur und die Bilder im Arbeitsspeicher unterzubringen. Normalerweise belegen Bilder im Speicher mehr Platz als auf der Festplatte, insbesondere wenn Bilder zusätzliche Effekte haben.

Im Allgemeinen kann Aspose.Slides für Python via .NET Präsentationsdateien von etwa 300 MB auf einem Server mit 4 GB RAM problemlos verarbeiten.

## **Arbeiten mit Folien**

**Q:** Kann ich die Größe der Folien in einer Präsentation ändern?

**A:** Sie können die `slide_size`‑Eigenschaft der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse verwenden, um die Größe der Folien in einer Präsentation festzulegen.

**Q:** Gibt es eine Möglichkeit, Folien unterschiedlicher Größe in einer Präsentation zu definieren?

**A:** Da die Foliengröße in Microsoft PowerPoint‑Dokumenten auf Präsentationsebene definiert ist, gibt es keine Möglichkeit, dies zu tun.

**Q:** Unterstützt Aspose.Slides für Python via .NET die Vorschau einer Folie vor dem Speichern?

**A:** Sie können die Präsentationsfolien in Bilder rendern und diese Bilder für die Vorschau der Folien verwenden.

## **Arbeiten mit Text**

**Q:** Ist es möglich, den gesamten Text einer Präsentation abzurufen?

**A:** Aspose.Slides für Python via .NET stellt die [SlideUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/)‑Klasse im Namespace `aspose.slides.util` bereit, die verschiedene Methoden zum Abrufen des gesamten Textes aus Präsentationen bietet.

**Q:** Warum unterscheiden sich die Absatzgrößen unter Windows und Linux?

**A:** Die Berechnung der Absatzgrößen basiert auf der Berechnung der Textgröße, die den jeweiligen Absatz repräsentiert. Die Textgrößenberechnung erfolgt anhand der Metriken der in der PowerPoint‑Präsentation angegebenen Schriftart. Fehlt die angegebene Schriftart, wird sie durch die ähnlichste Schriftart ersetzt, jedoch hat diese Schriftart andere Metriken als die ursprüngliche. Dadurch führt die Berechnung der Absatzgrößen in verschiedenen Systemen zu unterschiedlichen Ergebnissen, abhängig vom Satz installierter Schriftarten. Um das gleiche Ergebnis auf unterschiedlichen Betriebssystemen zu erzielen, müssen Sie dieselben Schriftarten auf den Systemen installieren oder sie zur Laufzeit als [external fonts](/slides/de/python-net/custom-font/) laden.

## **Formatierung und Bilder**

**Q:** Wie kann ich die Farbe eines Tabellengitters festlegen?

**A:** Sie können die Farbe aller Tabellengitter oder nur des Rands um die gesamte Tabelle ändern. Zum Ändern aller Ränder verwenden Sie bitte die `cell_format`‑Eigenschaft der [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/)‑Klasse. Für den Rand der gesamten Tabelle sollten Sie die Zellen durchlaufen und die Farbe der äußeren Ränder ändern.

**Q:** Welche Maße verwendet Aspose.Slides für Python via .NET zum Platzieren von Bildern?

**A:** Die Koordinaten und Größen aller Formen auf den Folien werden in Punkten (72 dpi) gemessen.

## **Arbeiten mit Schriftarten**

**Q:** Warum unterscheiden sich beim Konvertieren von PPT zu PDF oder Bildern die Schriftarten in den Ausgabedokumenten?

**A:** Dieses Problem kann darauf hinweisen, dass die in der Präsentation verwendeten Schriftarten im Betriebssystem, auf dem der Code ausgeführt wurde, fehlen. Sie sollten die Schriftarten im Betriebssystem installieren oder sie als externe Schriftarten mithilfe der [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/)‑Klasse laden, wie unten gezeigt:
```cs
folders = [ "path_to_a_folder_with_fonts" ]
aspose.slides.FontsLoader.load_external_fonts(folders)
```
