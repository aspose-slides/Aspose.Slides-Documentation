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
description: "Erhalten Sie Antworten auf häufig gestellte Fragen zu Aspose.Slides für Python via .NET, einschließlich PowerPoint- und OpenDocument-Unterstützung, Installationsanleitung, Lizenzierung und Fehlerbehebung."
---

## **Unterstützte Dateiformate**

**Q: Welche Dateiformate unterstützt Aspose.Slides for Python via .NET?**

**A**: Aspose.Slides for Python via .NET unterstützt die in [Supported File Formats](/slides/de/python-net/supported-file-formats/) beschriebenen Dateiformate.

## **Ausnahmen**

**Q: Ich erhalte eine Out‑Of‑Memory‑Ausnahme beim Laden einer großen PPT‑Datei mit Bildern. Gibt es bei Aspose.Slides eine Begrenzung der Dateigröße?**

**A**: Es gibt keine spezifische Formel zur Berechnung der von Aspose.Slides unterstützten Präsentationsgröße. Es muss genügend Speicher vorhanden sein, um die gesamte Präsentationsstruktur und die Bilder im Arbeitsspeicher aufzunehmen. Normalerweise belegen Bilder im Arbeitsspeicher mehr Platz als auf der Festplatte, insbesondere wenn die Bilder zusätzliche Effekte haben.

Im Allgemeinen kann Aspose.Slides for Python via .NET Präsentationsdateien von etwa 300 MB auf einem Server mit 4 GB RAM problemlos verarbeiten.

## **Arbeiten mit Folien**

**Q: Kann ich die Größe der Folien in einer Präsentation ändern?**

**A**: Sie können die Eigenschaft `slide_size`, die von der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) bereitgestellt wird, verwenden, um die Größe der Folien in einer Präsentation festzulegen.

**Q: Gibt es eine Möglichkeit, Folien unterschiedlicher Größe in einer Präsentation zu definieren?**

**A**: Da die Foliengröße in Microsoft‑PowerPoint‑Dokumenten auf Präsentationsebene definiert ist, gibt es keine Möglichkeit, dies zu tun.

**Q: Unterstützt Aspose.Slides for Python via .NET die Vorschau einer Folie vor dem Speichern?**

**A**: Sie können die Folien der Präsentation in Bilder rendern und diese Bilder zur Vorschau der Folien verwenden.

## **Arbeiten mit Text**

**Q: Ist es möglich, den gesamten Text einer Präsentation abzurufen?**

**A**: Aspose.Slides for Python via .NET stellt die Klasse [SlideUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/) im Namensraum `aspose.slides.util` bereit, die verschiedene Methoden zum Abrufen des gesamten Textes aus Präsentationen bietet.

**Q: Warum unterscheiden sich die Absatzgrößen unter Windows und Linux?**

**A**: Die Berechnung der Absatzgrößen basiert auf der Berechnung der Textgröße, die den jeweiligen Absatz darstellt. Die Textgrößenberechnung orientiert sich an den Metriken der im PowerPoint‑Dokument angegebenen Schriftart. Fehlt die angegebene Schriftart, wird sie durch die ähnlichste Schriftart ersetzt, deren Metriken jedoch von den ursprünglichen abweichen. Dadurch führt die Berechnung der Absatzgrößen auf verschiedenen Systemen zu unterschiedlichen Ergebnissen, abhängig von der Menge der installierten Schriftarten. Um auf unterschiedlichen Betriebssystemen dasselbe Ergebnis zu erzielen, müssen Sie dieselben Schriftarten auf den Systemen installieren oder sie zur Laufzeit als [external fonts](/slides/de/python-net/custom-font/) laden.

## **Formatierung und Bilder**

**Q: Wie kann ich die Farbe eines Tabellenrahmens festlegen?**

**A**: Sie können die Farbe aller Tabellenrahmen oder nur den Rahmen um die gesamte Tabelle ändern. Zum Ändern aller Rahmen verwenden Sie bitte die Eigenschaft `cell_format` der Klasse [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/). Für den Rahmen der gesamten Tabelle sollten Sie die Zellen iterieren und die Farbe der äußeren Rahmen ändern.

**Q: Welche Maße verwendet Aspose.Slides for Python via .NET zum Platzieren von Bildern?**

**A**: Die Koordinaten und Größen aller Formen auf den Folien werden in Punkten (72 dpi) gemessen.

## **Arbeiten mit Schriftarten**

**Q: Warum unterscheiden sich die Schriftarten in den Ausgabedokumenten beim Konvertieren von PPT zu PDF oder Bildern?**

**A**: Dieses Problem kann darauf hinweisen, dass die in der Präsentation verwendeten Schriftarten im Betriebssystem, auf dem der Code ausgeführt wurde, fehlen. Sie sollten die Schriftarten im Betriebssystem installieren oder sie als externe Schriftarten mithilfe der Klasse [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/) laden, wie unten gezeigt:
```cs
folders = [ "path_to_a_folder_with_fonts" ]
aspose.slides.FontsLoader.load_external_fonts(folders)
```
