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

**A**: Aspose.Slides für Python via .NET unterstützt die in [Unterstützte Dateiformate](/slides/de/python-net/supported-file-formats/) beschriebenen Dateiformate.

## **Ausnahmen**

**Q: Beim Laden einer großen PPT-Datei mit Bildern erhalte ich eine Out‑of‑Memory‑Exception. Gibt es eine Begrenzung in Aspose.Slides bezüglich der Dateigröße?**

**A**: Es gibt keine spezifische Formel zur Berechnung der von Aspose.Slides unterstützten Präsentationsgröße. Es sollte ausreichend Speicherplatz vorhanden sein, um die gesamte Präsentationsstruktur und die Bilder im Speicher zu halten. Normalerweise belegen Bilder im Speicher mehr Platz als auf der Festplatte, insbesondere wenn Bilder zusätzliche Effekte haben.

Im Allgemeinen kann Aspose.Slides für Python via .NET Präsentationsdateien von etwa 300 MB auf einem Server mit 4 GB RAM problemlos verarbeiten.

## **Arbeiten mit Folien**

**Q: Kann ich die Größe der Folien in einer Präsentation ändern?**

**A**: Sie können die Eigenschaft `slide_size` verwenden, die von der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse bereitgestellt wird, um die Größe der Folien in einer Präsentation festzulegen.

**Q: Gibt es eine Möglichkeit, Folien unterschiedlicher Größe in einer Präsentation zu definieren?**

**A**: Da die Größe der Folien in Microsoft‑PowerPoint‑Dokumenten auf Präsentationsebene definiert wird, gibt es keine Möglichkeit, dies zu tun.

**Q: Unterstützt Aspose.Slides für Python via .NET die Vorschau einer Folie vor dem Speichern?**

**A**: Sie können die Präsentationsfolien in Bilder rendern und diese Bilder zur Vorschau der Folien verwenden.

## **Arbeiten mit Text**

**Q: Ist es möglich, den gesamten Text aus einer Präsentation abzurufen?**

**A**: Aspose.Slides für Python via .NET stellt die Klasse [SlideUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/) im Namespace `aspose.slides.util` bereit, die verschiedene Methoden zum Abrufen des gesamten Textes aus den Präsentationen bietet.

**Q: Warum unterscheiden sich die Absatzgrößen unter Windows und Linux?**

**A**: Die Berechnung der Absatzgrößen basiert auf der Berechnung der Textgröße, die den jeweiligen Absatz darstellt. Die Textgrößenberechnung verwendet die Metriken der im PowerPoint‑Dokument angegebenen Schriftart. Fehlt die angegebene Schriftart, wird sie durch die ähnlichste Schriftart ersetzt, deren Metriken jedoch von den Originalmetriken abweichen. Dadurch führt die Berechnung der Absatzgrößen in unterschiedlichen Systemen zu verschiedenen Ergebnissen, abhängig vom Satz installierter Schriftarten. Um auf verschiedenen Betriebssystemen das gleiche Ergebnis zu erzielen, müssen Sie dieselben Schriftarten auf den Systemen installieren oder sie zur Laufzeit als [externe Schriften](/slides/de/python-net/custom-font/) laden.

## **Formatierung und Bilder**

**Q: Wie kann ich die Farbe eines Tabellenrahmens festlegen?**

**A**: Sie können die Farbe aller Tabellenrahmen oder nur des Rahmens um die gesamte Tabelle ändern. Zum Ändern aller Rahmen verwenden Sie bitte die Eigenschaft `cell_format` der Klasse [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/). Für den Rand der gesamten Tabelle sollten Sie die Zellen iterieren und die Farbe der äußeren Rahmen ändern.

**Q: Welche Maße verwendet Aspose.Slides für Python via .NET zum Platzieren von Bildern?**

**A**: Die Koordinaten und Größen aller Formen auf den Folien werden in Punkten (72 dpi) gemessen.

## **Arbeiten mit Schriften**

**Q: Warum unterscheiden sich die Schriftarten in den Ausgabedokumenten beim Konvertieren von PPT zu PDF oder Bildern?**

**A**: Dieses Problem kann darauf hinweisen, dass die in der Präsentation verwendeten Schriftarten im Betriebssystem, auf dem der Code ausgeführt wurde, fehlen. Sie sollten die Schriftarten im Betriebssystem installieren oder sie als externe Schriftarten laden, indem Sie die Klasse [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/) wie unten gezeigt verwenden:
```cs
folders = [ "path_to_a_folder_with_fonts" ]
aspose.slides.FontsLoader.load_external_fonts(folders)
```
