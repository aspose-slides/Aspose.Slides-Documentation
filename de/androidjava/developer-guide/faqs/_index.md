---
title: FAQs
type: docs
weight: 340
url: /androidjava/faqs/
keywords:
- FAQ
- PowerPoint
- Präsentationsformat
- Speicherfehler
- Foliengröße
- Text extrahieren
- Text abrufen
- Absatzgröße
- Tabellen formatieren
- Schriftart
- Android
- Java
- Aspose.Slides für Android über Java
---

## **Unterstützte Dateiformate**

**F: Welche Dateiformate unterstützt Aspose.Slides für Android über Java?**

**A**: Aspose.Slides für Android über Java unterstützt die in [Unterstützte Dateiformate](/slides/androidjava/supported-file-formats/) beschriebenen Dateiformate.

## **Ausnahmen**

**F: Ich erhalte eine Speicherüberschreitungsausnahme, während ich eine große PPT-Datei mit Bildern lade. Gibt es eine Einschränkung in Aspose.Slides hinsichtlich der Dateigröße?**

**A**: Es gibt keine spezifische Formel zur Berechnung der von Aspose.Slides unterstützten Präsentationsgröße. Es sollte genügend Speicherplatz vorhanden sein, um die gesamte Präsentationsstruktur und die Bilder im Speicher unterzubringen. Normalerweise belegen Bilder im Speicher mehr Platz als auf der Festplatte, insbesondere wenn Bilder zusätzliche Effekte haben.

Im Allgemeinen kann Aspose.Slides für Android über Java Präsentationsdateien mit etwa 300 MB auf einem Server mit 4 GB RAM problemlos verarbeiten.

## **Arbeiten mit Folien**

**F: Kann ich die Größe der Folien in einer Präsentation ändern?**

**A**: Sie können die `getSlideSize`-Methode verwenden, die von der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) Klasse bereitgestellt wird, um die Größe der Folien in einer Präsentation zu definieren.

**F: Gibt es eine Möglichkeit, Folien unterschiedlicher Größe in einer Präsentation zu definieren?**

**A**: Da die Größe der Folien auf Präsentationsebene in Microsoft PowerPoint-Dokumenten definiert ist, gibt es keine Möglichkeit, dies zu tun.

**F: Unterstützt Aspose.Slides für Android über Java die Vorschau einer Folie vor dem Speichern?**

**A**: Sie können die Präsentationsfolien in Bilder rendern und diese Bilder zur Vorschau der Folien verwenden.

## **Arbeiten mit Text**

**F: Ist es möglich, den gesamten Text aus einer Präsentation abzurufen?**

**A**: Aspose.Slides für Android über Java bietet die [SlideUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slideutil/) Klasse, die verschiedene Methoden zum Abrufen des gesamten Textes aus den Präsentationen bereitstellt.

**F: Warum sind die Absatzgrößen auf PC und Android unterschiedlich?**

**A**: Die Berechnung der Absatzgrößen basiert auf der Berechnung der Textgröße, die den gegebenen Absatz darstellt. Die Berechnung der Textgröße basiert auf den Metriken der in der PowerPoint-Präsentation angegebenen Schriftart. Wenn die angegebene Schriftart fehlt, wird sie durch die ähnlichste Schriftart ersetzt, aber diese Schriftart hat andere Metriken als die ursprünglichen. Infolgedessen führt die Berechnung der Absatzgrößen auf verschiedenen Systemen zu unterschiedlichen Ergebnissen, abhängig von der Menge der installierten Schriftarten. Um das gleiche Ergebnis auf verschiedenen Betriebssystemen zu erzielen, müssen Sie die gleichen Schriftarten auf den Systemen installieren oder sie zur Laufzeit als [externe Schriftarten](/slides/androidjava/custom-font/) laden.

## **Formatierung und Bilder**

**F: Wie kann ich die Farbe eines Tabellenrahmens festlegen?**

**A**: Sie können die Farbe aller Tabellenrahmen oder nur den Rahmen um die gesamte Tabelle ändern. Um alle Rahmen zu ändern, verwenden Sie bitte die Methode `getCellFormat` aus dem [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) Interface. Für den Rahmen der gesamten Tabelle sollten Sie die Zellen durchlaufen und die Farbe der äußeren Rahmen ändern.

**F: Welche Maße verwendet Aspose.Slides für Android über Java, um Bilder zu platzieren?**

**A**: Die Koordinaten und Größen aller Formen auf den Folien werden in Punkten (72 dpi) gemessen.

## **Arbeiten mit Schriftarten**

**F: Warum sind die Schriftarten beim Konvertieren von PPT in PDF oder Bilder in den Ausgabedokumenten unterschiedlich?**

**A**: Dieses Problem könnte darauf hindeuten, dass die in der Präsentation verwendeten Schriftarten im Betriebssystem, auf dem der Code ausgeführt wurde, fehlen. Sie sollten die Schriftarten im Betriebssystem installieren oder sie als externe Schriftarten mit der [FontsLoader](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/) Klasse laden, wie unten gezeigt:
```java
String[] folders = new String[] { "path_to_a_folder_with_fonts" };
FontsLoader.loadExternalFonts(folders);
```