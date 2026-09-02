---
title: Low-Code-Präsentationsoperationen in Python
linktitle: Low-Code API
type: docs
weight: 50
url: /de/python-net/low-code-presentation-operations/
keywords:
- Low-Code-Präsentations-API
- Präsentation konvertieren
- Präsentationen zusammenführen
- Formen sammeln
- Präsentation komprimieren
- Unbenutzte Master-Folien entfernen
- Unbenutzte Layout-Folien entfernen
- Eingebettete Schriftarten komprimieren
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Verwenden Sie die Aspose.Slides Low-Code-API in Python, um Präsentationen zu konvertieren und zusammenzuführen, Formen zu sammeln und die Dateigröße der Präsentation zu reduzieren."
---
## **Überblick**

Das [aspose.slides.lowcode](https://reference.aspose.com/slides/de/python-net/aspose.slides.lowcode/) Modul stellt Hilfsklassen für gängige Präsentationsoperationen bereit. Diese Helfer kapseln häufig genutzte Objektmodell‑Workflows in fokussierten Methoden, sodass Sie Dateien konvertieren oder zusammenführen, Formen sammeln und ungenutzten Inhalt mit weniger Code entfernen können.

Low‑Code‑Helfer sind am nützlichsten, wenn die Operation auf eine gesamte Datei oder Präsentation angewendet wird und der Standard‑Workflow Ihren Anforderungen entspricht. Verwenden Sie das vollständige [Aspose.Slides‑Objektmodell](https://reference.aspose.com/slides/de/python-net/aspose.slides/), wenn Sie eine feinkörnige Kontrolle über einzelne Folien, Master, Layouts, Formen, Exporteinstellungen oder Beziehungen zwischen Präsentationselementen benötigen.

Die folgende Tabelle fasst die verfügbaren Helfer zusammen:

| Helfer | Verwendungszweck |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/de/python-net/aspose.slides.lowcode/convert/) | Konvertieren einer Präsentation in ein anderes Format mit einem direkten Datei‑zu‑Datei‑Aufruf. |
| [Merger](https://reference.aspose.com/slides/de/python-net/aspose.slides.lowcode/merger/) | Zusammenführen kompletter Präsentationsdateien desselben Formats. |
| [Collect](https://reference.aspose.com/slides/de/python-net/aspose.slides.lowcode/collect/) | Abrufen von Formen aus der gesamten Präsentation für wiederholte Verarbeitung oder Analyse. |
| [Compress](https://reference.aspose.com/slides/de/python-net/aspose.slides.lowcode/compress/) | Entfernen nicht verwendeter Master und Layouts sowie Reduzieren eingebetteter Schriftartdaten. |

## **Präsentation konvertieren**

Verwenden Sie [Convert.auto_by_extension](https://reference.aspose.com/slides/de/python-net/aspose.slides.lowcode/convert/auto_by_extension/), wenn die Dateierweiterung des Ausgabedokuments ausreicht, um das Exportformat zu bestimmen. Die Methode öffnet die Quellpräsentation, ermittelt das erforderliche Format aus dem Ausgabepfad und schreibt das Ergebnis.

```python
import aspose.slides as slides

slides.lowcode.Convert.auto_by_extension("input.pptx", "output.pdf")
```

Die [Convert](https://reference.aspose.com/slides/de/python-net/aspose.slides.lowcode/convert/) Klasse bietet außerdem dedizierte Methoden für die Ausgabe in PDF, SVG, JPEG, PNG und TIFF. Verwenden Sie das vollständige Objektmodell, wenn Sie die Präsentation vor dem Export prüfen oder ändern oder eine Exportoption konfigurieren müssen, die vom gewählten Helfer nicht bereitgestellt wird. Siehe [Präsentation konvertieren](/slides/de/python-net/convert-presentation/) für format‑spezifische Workflows und Optionen.

## **Präsentationen zusammenführen**

Verwenden Sie [Merger.process](https://reference.aspose.com/slides/de/python-net/aspose.slides.lowcode/merger/process/), um komplette Präsentationsdateien mit einem Aufruf zu kombinieren. Die Eingabedateien müssen dasselbe Dateiformat haben.

```python
import aspose.slides as slides

input_files = ["part-1.pptx", "part-2.pptx"]
slides.lowcode.Merger.process(input_files, "merged.pptx")
```

Der Helfer ist geeignet, wenn alle Folien zu einem Ergebnis hinzugefügt werden sollen, ohne sie einzeln auszuwählen oder neu zuzuordnen. Verwenden Sie das vollständige Objektmodell, wenn Sie ausgewählte Folien zusammenführen, einen Ziel‑Master oder ein Layout anwenden, Abschnitte explizit beibehalten oder unterschiedliche Foliengrößen angleichen müssen. Siehe [Präsentationen zusammenführen](/slides/de/python-net/merge-presentation/) für diese Szenarien.

## **Formen sammeln**

Verwenden Sie [Collect.shapes](https://reference.aspose.com/slides/de/python-net/aspose.slides.lowcode/collect/shapes/), wenn Sie eine Sammlung aller Formen einer Präsentation benötigen. Dies ist nützlich, wenn dieselbe Menge mehrfach gefiltert, gezählt oder verarbeitet werden soll.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    shapes = slides.lowcode.Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.name}: {type(shape).__name__}")
```

Verwenden Sie direkte Sammlungsschleifen, wenn die Durchlaufreihenfolge, ein frühzeitiger Abbruch, Filterung vor der Verarbeitung oder eine detaillierte Eltern‑Kind‑Steuerung wichtig sind.

## **Präsentationsinhalt komprimieren**

Die [Compress](https://reference.aspose.com/slides/de/python-net/aspose.slides.lowcode/compress/) Klasse kann nicht genutzte Strukturelemente entfernen und eingebettete Schriftartdaten reduzieren:

- [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/de/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) entfernt Layout‑Folien, auf die keine reguläre Folie verweist.
- [Compress.remove_unused_master_slides](https://reference.aspose.com/slides/de/python-net/aspose.slides.lowcode/compress/remove_unused_master_slides/) entfernt Master‑Folien, die nicht mehr verwendet werden.
- [Compress.compress_embedded_fonts](https://reference.aspose.com/slides/de/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) entfernt ungenutzte Zeichen aus eingebetteten Schriftarten.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    slides.lowcode.Compress.compress_embedded_fonts(presentation)

    presentation.save("compressed.pptx", slides.export.SaveFormat.PPTX)
```

Entfernen Sie nicht verwendete Layouts vor nicht verwendeten Mastern, damit ein Master, der nach der Layout‑Bereinigung nicht mehr referenziert wird, ebenfalls entfernt werden kann. Speichern Sie die optimierte Präsentation in einer neuen Datei, falls Sie später die ursprünglichen Master, Layouts oder die vollständigen eingebetteten Schriftartdaten benötigen. Weitere Details finden Sie unter [Slide Master](/slides/de/python-net/slide-master/) und [Embedded Font](/slides/de/python-net/embedded-font/).

## **FAQ**

**Wann sollte ich die Low‑Code‑API anstelle des vollständigen Objektmodells verwenden?**

Verwenden Sie Low‑Code‑Helfer, wenn eine Standard‑Operation auf eine komplette Datei oder Präsentation angewendet wird und keine detaillierte Kontrolle über einzelne Elemente erfordert. Verwenden Sie das vollständige Objektmodell, wenn Sie bestimmte Folien auswählen, Beziehungen zwischen Master und Layout steuern, den Zwischenzustand prüfen oder ein Verhalten konfigurieren müssen, das der Helfer nicht bereitstellt.

**Kann Merger Präsentationen in unterschiedlichen Dateiformaten kombinieren?**

Nein. [Merger.process](https://reference.aspose.com/slides/de/python-net/aspose.slides.lowcode/merger/process/) erfordert Eingabedateien im selben Format. Konvertieren Sie die Eingabedateien zuerst in ein gemeinsames Format, zum Beispiel mit [Convert.auto_by_extension](https://reference.aspose.com/slides/de/python-net/aspose.slides.lowcode/convert/auto_by_extension/), und fügen Sie anschließend die konvertierten Dateien zusammen.

**Was enthält Collect.shapes?**

[Collect.shapes](https://reference.aspose.com/slides/de/python-net/aspose.slides.lowcode/collect/shapes/) ruft Formen aus der Präsentation ab, sodass sie beibehalten, gefiltert, gezählt oder mehrfach durchlaufen werden können. Verwenden Sie direkte Sammlungsschleifen, wenn Sie eine präzise Kontrolle darüber benötigen, welche Folientypen oder verschachtelten Objekte besucht werden.

**Reduziert Compress immer die Dateigröße der Präsentation?**

Nicht zwingend. Das Ergebnis hängt davon ab, ob die Präsentation nicht genutzte Layouts, nicht genutzte Master oder eingebettete Schriftarten mit ungenutzten Zeichen enthält. Wenn keiner dieser Fälle vorliegt, können die entsprechenden [Compress](https://reference.aspose.com/slides/de/python-net/aspose.slides.lowcode/compress/) Vorgänge die Dateigröße möglicherweise nicht reduzieren.

**Werden Änderungen, die von Compress vorgenommen werden, automatisch gespeichert?**

Nein. Diese Helfer arbeiten auf dem geladenen [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Objekt im Speicher. Nachdem Sie [Compress](https://reference.aspose.com/slides/de/python-net/aspose.slides.lowcode/compress/) ausgeführt haben, rufen Sie [Presentation.save](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/save/) auf, um das Ergebnis zu schreiben.

## **Verwandte Artikel**

- [Präsentation konvertieren](/slides/de/python-net/convert-presentation/)
- [Präsentationen zusammenführen](/slides/de/python-net/merge-presentation/)
- [Folienmaster](/slides/de/python-net/slide-master/)
- [Textfeld verwalten](/slides/de/python-net/manage-textbox/)
- [Eingebettete Schriftart](/slides/de/python-net/embedded-font/)