---
title: FAQs
type: docs
weight: 340
url: /net/faqs/
keywords:
- FAQ
- PowerPoint
- Präsentationsformat
- Out of Memory Exception
- Foliengröße
- Text extrahieren
- Text abrufen
- Absatzgröße
- Tabellen formatieren
- Schriftart
- C#
- .NET
- Aspose.Slides für .NET
---

## **Unterstützte Dateiformate**

**Q: Welche Dateiformate unterstützt Aspose.Slides für .NET?**

**A**: Aspose.Slides für .NET unterstützt die in [Unterstützte Dateiformate](/slides/net/supported-file-formats/) beschriebenen Dateiformate.

## **Ausnahmen**

**Q: Ich erhalte eine OutOfMemoryException, während ich eine große PPT-Datei mit Bildern lade. Gibt es eine Begrenzung der Dateigröße in Aspose.Slides?**

**A**: Es gibt keine spezifische Formel zur Berechnung der von Aspose.Slides unterstützten Präsentationsgröße. Es sollte genügend Platz vorhanden sein, um die gesamte Präsentationsstruktur und Bilder im Speicher unterzubringen. Normalerweise nehmen Bilder im Speicher mehr Platz ein als auf der Festplatte, insbesondere wenn Bilder zusätzliche Effekte haben.

Im Allgemeinen kann Aspose.Slides für .NET Präsentationsdateien von etwa 300 MB auf einem Server mit 4 GB RAM problemlos verarbeiten.

## **Arbeiten mit Folien**

**Q: Kann ich die Größe der Folien in einer Präsentation ändern?**

**A**: Sie können die `SlideSize`-Eigenschaft der [Präsentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) Klasse verwenden, um die Größe der Folien in einer Präsentation zu definieren.

**Q: Gibt es eine Möglichkeit, Folien unterschiedlicher Größe in einer Präsentation zu definieren?**

**A**: Da die Größe von Folien auf Präsentationsebene in Microsoft PowerPoint-Dokumenten definiert ist, gibt es keine Möglichkeit, dies zu tun.

**Q: Unterstützt Aspose.Slides für .NET die Vorschau einer Folie vor dem Speichern?**

**A**: Sie können die Präsentationsfolien in Bilder rendern und diese Bilder zur Vorschau der Folien verwenden.

## **Arbeiten mit Text**

**Q: Ist es möglich, den gesamten Text aus einer Präsentation abzurufen?**

**A**: Aspose.Slides für .NET bietet die [SlideUtil](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/) Klasse im Namensraum `Aspose.Slides.Util`, die verschiedene Methoden zum Abrufen gesamten Textes aus den Präsentationen bereitstellt.

**Q: Warum sind die Absatzgrößen auf Windows- und Linux-Betriebssystemen unterschiedlich?**

**A**: Die Berechnung der Absatzgrößen basiert auf der Berechnung der Textgröße, die den gegebenen Absatz repräsentiert. Die Berechnung der Textgröße basiert auf den Metriken der im PowerPoint-Dokument angegebenen Schriftart. Wenn die angegebene Schriftart fehlt, wird sie durch die ähnlichste Schriftart ersetzt, aber diese Schriftart hat andere Metriken als die ursprünglichen. Infolgedessen führt die Berechnung der Absatzgrößen in verschiedenen Systemen zu unterschiedlichen Ergebnissen, abhängig von der Menge der installierten Schriftarten. Um auf verschiedenen Betriebssystemen dasselbe Ergebnis zu erzielen, müssen Sie dieselben Schriftarten auf den Systemen installieren oder sie zur Laufzeit als [externe Schriftarten](/slides/net/custom-font/) laden.

## **Formatierung und Bilder**

**Q: Wie kann ich die Farbe eines Tabellenrahmens einstellen?**

**A**: Sie können die Farbe aller Tabellenrahmen oder nur des Rahmens um die gesamte Tabelle ändern. Um alle Rahmen zu ändern, verwenden Sie bitte die `CellFormat`-Eigenschaft der [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) Schnittstelle. Für den Rahmen der gesamten Tabelle sollten Sie die Zellen durchlaufen und die Farbe der äußeren Rahmen ändern.

**Q: Welche Maße verwendet Aspose.Slides für .NET, um Bilder zu platzieren?**

**A**: Die Koordinaten und Größen aller Formen auf den Folien werden in Punkten (72 dpi) gemessen.

## **Arbeiten mit Schriftarten**

**Q: Warum sind die Schriftarten beim Konvertieren von PPT in PDF oder Bilder in den Ausgabedokumenten unterschiedlich?**

**A**: Dieses Problem könnte darauf hinweisen, dass die in der Präsentation verwendeten Schriftarten im Betriebssystem fehlen, auf dem der Code ausgeführt wurde. Sie sollten die Schriftarten im Betriebssystem installieren oder sie als externe Schriftarten mithilfe der [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/) Klasse laden, wie unten gezeigt:
```cs
var folders = new string[] { "path_to_a_folder_with_fonts" };
FontsLoader.LoadExternalFonts(folders);
```