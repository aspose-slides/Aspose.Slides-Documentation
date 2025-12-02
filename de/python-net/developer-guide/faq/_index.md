---
title: FAQ
type: docs
weight: 340
url: /de/python-net/faq/
keywords:
- FAQ
- Präsentationsformat
- Out-of-Memory-Fehler
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

**Q: Welche Dateiformate unterstützt Aspose.Slides für Python via .NET?**

**A**: Aspose.Slides für Python via .NET unterstützt die in [Supported File Formats](/slides/de/python-net/supported-file-formats/) beschriebenen Dateiformate.

## **Ausnahmen**

**Q: Ich erhalte beim Laden einer großen PPT-Datei mit Bildern eine Out‑Of‑Memory‑Ausnahme. Gibt es eine Beschränkung in Aspose.Slides bezüglich der Dateigröße?**

**A**: Es gibt keine feste Formel zur Berechnung der von Aspose.Slides unterstützten Präsentationsgröße. Es muss genügend Speicher vorhanden sein, um die gesamte Präsentationsstruktur und die Bilder im Arbeitsspeicher zu halten. Normalerweise beanspruchen Bilder im Speicher mehr Platz als auf der Festplatte, insbesondere wenn die Bilder zusätzliche Effekte besitzen.

Im Allgemeinen kann Aspose.Slides für Python via .NET Präsentationsdateien von etwa 300 MB auf einem Server mit 4 GB RAM problemlos verarbeiten.

## **Arbeiten mit Folien**

**Q: Kann ich die Größe der Folien in einer Präsentation ändern?**

**A**: Sie können die `slide_size`‑Eigenschaft der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse verwenden, um die Größe der Folien in einer Präsentation festzulegen.

**Q: Gibt es eine Möglichkeit, Folien unterschiedlicher Größe in einer Präsentation zu definieren?**

**A**: Da die Foliengröße in Microsoft‑PowerPoint‑Dokumenten auf Präsentationsebene definiert wird, gibt es keine Möglichkeit, dies zu tun.

**Q: Unterstützt Aspose.Slides für Python via .NET die Vorschau einer Folie vor dem Speichern?**

**A**: Sie können die Präsentationsfolien in Bilder rendern und diese Bilder für die Vorschau der Folien verwenden.

## **Arbeiten mit Text**

**Q: Ist es möglich, den gesamten Text einer Präsentation abzurufen?**

**A**: Aspose.Slides für Python via .NET stellt die [SlideUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/)‑Klasse im Namespace `aspose.slides.util` bereit, die verschiedene Methoden zum Abrufen des gesamten Textes aus Präsentationen bietet.

**Q: Warum unterscheiden sich die Absatzgrößen unter Windows und Linux?**

**A**: Die Berechnung der Absatzgrößen basiert auf der Berechnung der Textgröße, die den jeweiligen Absatz darstellt. Die Textgrößenberechnung verwendet die Metriken der im PowerPoint‑Dokument angegebenen Schriftart. Fehlt die angegebene Schriftart, wird sie durch die dem Original am ähnlichsten ersetzte Schriftart ersetzt, deren Metriken jedoch von den Originalmetriken abweichen. Dadurch führt die Berechnung der Absatzgrößen auf unterschiedlichen Systemen zu unterschiedlichen Ergebnissen, abhängig von der Menge der installierten Schriftarten. Um auf verschiedenen Betriebssystemen das gleiche Ergebnis zu erzielen, müssen die gleichen Schriftarten auf den Systemen installiert oder zur Laufzeit als [external fonts](/slides/de/python-net/custom-font/) geladen werden.

## **Formatierung und Bilder**

**Q: Wie kann ich die Farbe eines Tabellenrahmens festlegen?**

**A**: Sie können die Farbe aller Tabellenrahmen oder nur des Rahmens um die gesamte Tabelle ändern. Zum Ändern aller Rahmen verwenden Sie die `cell_format`‑Eigenschaft der [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/)‑Klasse. Für den Rahmen der gesamten Tabelle sollten Sie die Zellen iterieren und die Farbe der äußeren Rahmen ändern.

**Q: Welche Maßeinheit verwendet Aspose.Slides für Python via .NET zum Platzieren von Bildern?**

**A**: Die Koordinaten und Größen aller Formen auf den Folien werden in Punkten (72 dpi) gemessen.

## **Arbeiten mit Schriftarten**

**Q: Warum unterscheiden sich die Schriftarten in den Ausgabedokumenten beim Konvertieren von PPT zu PDF oder Bildern?**

**A**: Dieses Problem kann darauf hinweisen, dass die in der Präsentation verwendeten Schriftarten im Betriebssystem, auf dem der Code ausgeführt wurde, fehlen. Sie sollten die Schriftarten im Betriebssystem installieren oder sie als externe Schriftarten über die [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/)‑Klasse wie unten gezeigt laden:
```cs
folders = [ "path_to_a_folder_with_fonts" ]
aspose.slides.FontsLoader.load_external_fonts(folders)
```
