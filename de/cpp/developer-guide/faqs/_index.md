---
title: FAQs
type: docs
weight: 340
url: /de/cpp/faqs/
keywords:
- FAQ
- PowerPoint
- Präsentationsformat
- Speicherüberlauf-Exception
- Foliengröße
- Text extrahieren
- Text abrufen
- Absatzgröße
- Tabellen formatieren
- Schriftart
- С++
- Aspose.Slides für С++
---

## **Unterstützte Dateiformate**

**F: Welche Dateiformate unterstützt Aspose.Slides für C++?**

**A**: Aspose.Slides für C++ unterstützt die in [Unterstützte Dateiformate](/slides/de/cpp/supported-file-formats/) beschriebenen Dateiformate.

## **Ausnahmen**

**F: Ich erhalte eine Speicherüberlauf-Exception, während ich eine große PPT-Datei mit Bildern lade. Gibt es eine Begrenzung in Aspose.Slides bezüglich der Dateigröße?**

**A**: Es gibt keine spezifische Formel zur Berechnung der von Aspose.Slides unterstützten Präsentationsgröße. Es sollte genügend Speicher vorhanden sein, um die gesamte Präsentationsstruktur und Bilder im Speicher unterzubringen. Normalerweise belegen Bilder im Speicher mehr Platz als die Festplatte, insbesondere wenn Bilder zusätzliche Effekte haben.

Im Allgemeinen kann Aspose.Slides für C++ Präsentationsdateien von etwa 300 MB auf einem Server mit 4 GB RAM problemlos verarbeiten.

## **Arbeiten mit Folien**

**F: Kann ich die Größe der Folien in einer Präsentation ändern?**

**A**: Sie können die `get_SlideSize`-Methode der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse verwenden, um die Größe der Folien in einer Präsentation zu definieren.

**F: Gibt es eine Möglichkeit, Folien unterschiedlicher Größe in einer Präsentation zu definieren?**

**A**: Da die Größe der Folien auf Präsentationsebene in Microsoft PowerPoint-Dokumenten definiert ist, gibt es keine Möglichkeit, dies zu tun.

**F: Unterstützt Aspose.Slides für C++ die Vorschau einer Folie vor dem Speichern?**

**A**: Sie können die Präsentationsfolien in Bilder umwandeln und diese Bilder zur Vorschau der Folien verwenden.

## **Arbeiten mit Text**

**F: Ist es möglich, den gesamten Text aus einer Präsentation abzurufen?**

**A**: Aspose.Slides für C++ bietet die [SlideUtil](https://reference.aspose.com/slides/cpp/aspose.slides.util/slideutil/) Klasse im `Aspose::Slides::Util` Namespace, die verschiedene Methoden zum Abrufen des gesamten Texts aus den Präsentationen bereitstellt.

**F: Warum sind die Absatzgrößen auf Windows und Linux-Betriebssystemen unterschiedlich?**

**A**: Die Berechnung der Absatzgrößen basiert auf der Berechnung der Textgröße, die den gegebenen Absatz darstellt. Die Berechnung der Textgröße basiert auf den Metriken der in der PowerPoint-Präsentation angegebenen Schriftart. Wenn die angegebene Schriftart fehlt, wird sie durch die ähnlichste Schriftart ersetzt, aber diese Schriftart hat andere Metriken als die ursprünglichen. Infolgedessen führt die Berechnung der Absatzgrößen auf verschiedenen Systemen zu unterschiedlichen Ergebnissen, abhängig von der Menge der installierten Schriftarten. Um dasselbe Ergebnis auf verschiedenen Betriebssystemen zu erzielen, müssen die gleichen Schriftarten auf den Systemen installiert oder zur Laufzeit als [externe Schriftarten](/slides/de/cpp/custom-font/) geladen werden.

## **Formatierung und Bilder**

**F: Wie kann ich die Farbe einer Tabellenkante festlegen?**

**A**: Sie können die Farbe aller Tabellenkanten oder nur der Kante um die gesamte Tabelle ändern. Für die Änderung aller Kanten verwenden Sie bitte die `get_CellFormat`-Methode des [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) Interfaces. Für die Kante der gesamten Tabelle sollten Sie die Zellen durchlaufen und die Farbe der äußeren Kanten ändern.

**F: Welches Maß verwendet Aspose.Slides für C++, um Bilder zu platzieren?**

**A**: Die Koordinaten und Größen aller Formen auf den Folien werden in Punkten (72 dpi) gemessen.

## **Arbeiten mit Schriftarten**

**F: Warum sind die Schriftarten beim Konvertieren von PPT in PDF oder Bilder in den Ausgabe-Dokumenten unterschiedlich?**

**A**: Dieses Problem könnte darauf hinweisen, dass die in der Präsentation verwendeten Schriftarten im Betriebssystem, auf dem der Code ausgeführt wurde, fehlen. Sie sollten die Schriftarten im Betriebssystem installieren oder sie als externe Schriftarten laden, indem Sie die [FontsLoader](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/) Klasse wie unten gezeigt verwenden:
```cpp
auto folders = MakeObject<Array<String>>(1, "path_to_a_folder_with_fonts");
FontsLoader::LoadExternalFonts(folders);
```