---
title: FAQs
type: docs
weight: 340
url: /de/python-net/faqs/
keywords:
- FAQ
- PowerPoint
- Präsentationsformat
- Out of Memory-Fehler
- Foliengröße
- Text extrahieren
- Text abrufen
- Absatzgröße
- Tabellen formatieren
- Schriftart
- Python
- Aspose.Slides für Python über .NET
---

## **Unterstützte Dateiformate**

**Q: Welche Dateiformate unterstützt Aspose.Slides für Python über .NET?**

**A**: Aspose.Slides für Python über .NET unterstützt die in [Unterstützte Dateiformate](/slides/de/python-net/supported-file-formats/) beschriebenen Dateiformate.

## **Ausnahmen**

**Q: Ich erhalte eine Out of Memory-Ausnahme, während ich eine große PPT-Datei mit Bildern lade. Gibt es eine Einschränkung in Aspose.Slides bezüglich der Dateigröße?**

**A**: Es gibt keine spezifische Formel zur Berechnung der Präsentationsgröße, die von Aspose.Slides unterstützt wird. Es sollte genügend Speicherplatz vorhanden sein, um die gesamte Präsentationsstruktur und die Bilder im Speicher unterzubringen. Normalerweise belegen Bilder im Speicher mehr Platz als auf der Festplatte, insbesondere wenn Bilder zusätzliche Effekte haben.

Im Allgemeinen kann Aspose.Slides für Python über .NET Präsentationsdateien von etwa 300 MB auf einem Server mit 4 GB RAM problemlos verarbeiten.

## **Arbeiten mit Folien**

**Q: Kann ich die Größe der Folien in einer Präsentation ändern?**

**A**: Sie können die `slide_size`-Eigenschaft der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse verwenden, um die Größe der Folien in einer Präsentation zu definieren.

**Q: Gibt es eine Möglichkeit, Folien unterschiedlicher Größe in einer Präsentation zu definieren?**

**A**: Da die Größe der Folien auf Präsentationsebene in Microsoft PowerPoint-Dokumenten definiert ist, gibt es keine Möglichkeit, dies zu tun.

**Q: Unterstützt Aspose.Slides für Python über .NET die Vorschau einer Folie vor dem Speichern?**

**A**: Sie können die Präsentationsfolien in Bilder rendern und diese Bilder zur Vorschau der Folien verwenden.

## **Arbeiten mit Text**

**Q: Ist es möglich, den gesamten Text aus einer Präsentation abzurufen?**

**A**: Aspose.Slides für Python über .NET bietet die [SlideUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/) Klasse im `aspose.slides.util` Namespace, die verschiedene Methoden zum Abrufen des gesamten Texts aus den Präsentationen bereitstellt.

**Q: Warum sind die Absatzgrößen in Windows- und Linux-Betriebssystemen unterschiedlich?**

**A**: Die Berechnung der Absatzgrößen basiert auf der Berechnung der Textgröße, die den angegebenen Absatz darstellt. Die Berechnung der Textgröße basiert auf den Metriken der Schriftart, die in der PowerPoint-Präsentation angegeben ist. Wenn die angegebene Schriftart fehlt, wird sie durch die ähnlichste Schriftart ersetzt, aber diese Schriftart hat andere Metriken als die ursprüngliche. Infolgedessen führt die Berechnung der Absatzgrößen auf verschiedenen Systemen zu unterschiedlichen Ergebnissen, abhängig vom Satz der installierten Schriften. Um dasselbe Ergebnis auf verschiedenen Betriebssystemen zu erzielen, müssen Sie die gleichen Schriften auf den Systemen installieren oder sie zur Laufzeit als [externe Schriften](/slides/de/python-net/custom-font/) laden.

## **Formatierung und Bilder**

**Q: Wie kann ich die Farbe eines Tabellenrahmens festlegen?**

**A**: Sie können die Farbe aller Tabellenrahmen oder nur den Rahmen um die gesamte Tabelle ändern. Um alle Rahmen zu ändern, verwenden Sie bitte die `cell_format`-Eigenschaft der [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) Klasse. Für den Rahmen der gesamten Tabelle sollten Sie die Zellen durchlaufen und die Farbe der äußeren Rahmen ändern.

**Q: Welche Maße verwendet Aspose.Slides für Python über .NET, um Bilder zu platzieren?**

**A**: Die Koordinaten und Größen aller Formen auf den Folien werden in Punkten (72 dpi) gemessen.

## **Arbeiten mit Schriftarten**

**Q: Warum sind die Schriftarten bei der Konvertierung von PPT zu PDF oder Bildern in den Ausgabedokumenten unterschiedlich?**

**A**: Dieses Problem kann darauf hinweisen, dass die in der Präsentation verwendeten Schriftarten im Betriebssystem, auf dem der Code ausgeführt wurde, fehlen. Sie sollten die Schriftarten im Betriebssystem installieren oder sie als externe Schriftarten mit der [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/) Klasse wie unten gezeigt laden:
```cs
folders = [ "path_to_a_folder_with_fonts" ]
aspose.slides.FontsLoader.load_external_fonts(folders)
```