---
title: Low-Code Präsentationsoperationen in Python
linktitle: Low-Code-API
type: docs
weight: 50
url: /de/python-net/low-code-presentation-operations/
keywords:
- Low-Code Präsentations-API
- Präsentation konvertieren
- Präsentationen zusammenführen
- Formen sammeln
- Präsentation komprimieren
- Unbenutzte Masterfolien entfernen
- Unbenutzte Layoutfolien entfernen
- Eingebettete Schriften komprimieren
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Verwenden Sie die Aspose.Slides Low-Code-API in Python, um Präsentationen zu konvertieren und zusammenzuführen, Formen zu sammeln und die Präsentationsgröße zu reduzieren."
---
## **Übersicht**

Das Modul [aspose.slides.lowcode](https://reference.aspose.com/slides/de/python-net/aspose.slides.lowcode/) stellt Hilfsklassen für gängige Präsentationsoperationen bereit. Diese Helfer kapseln häufig genutzte Arbeitsabläufe des Objektmodells in fokussierten Methoden, sodass Sie Dateien konvertieren oder zusammenführen, Formen sammeln und ungenutzte Inhalte mit weniger Code entfernen können.

Low‑Code‑Helfer sind am nützlichsten, wenn die Operation auf eine gesamte Datei oder Präsentation angewendet wird und der Standard‑Workflow Ihren Anforderungen entspricht. Verwenden Sie das vollständige [Aspose.Slides‑Objektmodell](https://reference.aspose.com/slides/de/python-net/aspose.slides/), wenn Sie eine feinkörnige Kontrolle über einzelne Folien, Master, Layouts, Formen, Exporteinstellungen oder Beziehungen zwischen Präsentationselementen benötigen.

Die folgende Tabelle fasst die verfügbaren Helfer zusammen:

| Hilfsmittel | Verwendung |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/de/python-net/aspose.slides.lowcode/convert/) | Konvertieren einer Präsentation in ein anderes Format mit einem direkten Datei‑zu‑Datei‑Aufruf. |
| [Merger](https://reference.aspose.com/slides/de/python-net/aspose.slides.lowcode/merger/) | Kombinieren kompletter Präsentationsdateien desselben Formats. |
| [Collect](https://reference.aspose.com/slides/de/python-net/aspose.slides.lowcode/collect/) | Abrufen von Formen aus der gesamten Präsentation für wiederholte Verarbeitung oder Analyse. |
| [Compress](https://reference.aspose.com/slides/de/python-net/aspose.slides.lowcode/compress/) | Entfernen ungenutzter Master und Layouts sowie Reduzieren eingebetteter Schriftartdaten. |

## **Präsentation konvertieren**

Verwenden Sie [Convert.auto_by_extension](https://reference.aspose.com/slides/de/python-net/aspose.slides.lowcode/convert/auto_by_extension/), wenn die Dateierweiterung der Ausgabedatei ausreicht, um das Exportformat auszuwählen. Die Methode öffnet die Quellpräsentation, ermittelt das erforderliche Format aus dem Ausgabepfad und schreibt das Ergebnis.

```python
import aspose.slides as slides

slides.lowcode.Convert.auto_by_extension("input.pptx", "output.pdf")
```

Die Klasse [Convert](https://reference.aspose.com/slides/de/python-net/aspose.slides.lowcode/convert/) bietet zudem dedizierte Methoden für PDF, SVG, JPEG, PNG und TIFF. Verwenden Sie das vollständige Objektmodell, wenn Sie die Präsentation vor dem Export prüfen oder ändern oder eine Exportoption konfigurieren müssen, die vom ausgewählten Helfer nicht bereitgestellt wird. Siehe [Convert Presentation](/python-net/convert-presentation/) für format‑spezifische Arbeitsabläufe und Optionen.

## **Präsentationen zusammenführen**

Verwenden Sie [Merger.process](https://reference.aspose.com/slides/de/python-net/aspose.slides.lowcode/merger/process/), um komplette Präsentationsdateien mit einem Aufruf zu kombinieren. Die Eingabepäsentationen müssen das gleiche Dateiformat besitzen.

```python
import aspose.slides as slides

input_files = ["part-1.pptx", "part-2.pptx"]
slides.lowcode.Merger.process(input_files, "merged.pptx")
```

Der Helfer eignet sich, wenn alle Folien zu einem Ergebnis hinzugefügt werden sollen, ohne sie einzeln auszuwählen oder neu zuzuordnen. Verwenden Sie das vollständige Objektmodell, wenn Sie ausgewählte Folien zusammenführen, einen Ziel‑Master oder -Layout anwenden, Abschnitte explizit beibehalten oder unterschiedliche Foliengrößen abgleichen müssen. Siehe [Merge Presentations](/python-net/merge-presentation/) für diese Szenarien.

## **Formen sammeln**

Verwenden Sie [Collect.shapes](https://reference.aspose.com/slides/de/python-net/aspose.slides.lowcode/collect/shapes/), wenn Sie eine Sammlung aller Formen in einer Präsentation benötigen. Dies ist nützlich, wenn dieselbe Menge mehrfach gefiltert, gezählt oder verarbeitet werden soll.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    shapes = slides.lowcode.Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.name}: {type(shape).__name__}")
```

Verwenden Sie direkte Sammlungsschleifen, wenn die Durchlaufreihenfolge, ein vorzeitiger Abbruch, Vorfilterung vor der Verarbeitung oder eine detaillierte Eltern‑Kind‑Kontrolle wichtig sind.

## **Präsentationsinhalt komprimieren**

Die Klasse [Compress](https://reference.aspose.com/slides/de/python-net/aspose.slides.lowcode/compress/) kann ungenutzte Strukturelemente entfernen und eingebettete Schriftartdaten reduzieren:

- [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/de/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) entfernt Layout‑Folien, auf die keine normale Folie verweist.
- [Compress.remove_unused_master_slides](https://reference.aspose.com/slides/de/python-net/aspose.slides.lowcode/compress/remove_unused_master_slides/) entfernt Master‑Folien, die nicht mehr verwendet werden.
- [Compress.compress_embedded_fonts](https://reference.aspose.com/slides/de/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) entfernt ungenutzte Zeichen aus eingebetteten Schriften.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    slides.lowcode.Compress.compress_embedded_fonts(presentation)

    presentation.save("compressed.pptx", slides.export.SaveFormat.PPTX)
```

Entfernen Sie zuerst ungenutzte Layouts und danach ungenutzte Master, damit ein Master, der nach der Layout‑Bereinigung nicht mehr referenziert wird, ebenfalls entfernt werden kann. Speichern Sie die optimierte Präsentation in einer neuen Datei, wenn Sie die ursprünglichen Master, Layouts oder die vollständigen eingebetteten Schriftartdaten später noch benötigen könnten. Weitere Details finden Sie unter [Slide Master](/python-net/slide-master/) und [Embedded Font](/python-net/embedded-font/).

## **FAQ**

**Wann sollte ich die Low‑Code‑API anstelle des vollständigen Objektmodells verwenden?**

Verwenden Sie Low‑Code‑Helfer, wenn eine Standard‑Operation auf eine vollständige Datei oder Präsentation angewendet wird und keine detaillierte Kontrolle über einzelne Elemente erforderlich ist. Nutzen Sie das vollständige Objektmodell, wenn Sie bestimmte Folien auswählen, Master‑ und Layout‑Beziehungen steuern, Zwischenzustände prüfen oder ein Verhalten konfigurieren müssen, das der Helfer nicht bereitstellt.

**Kann Merger Präsentationen in unterschiedlichen Dateiformaten kombinieren?**

Nein. [Merger.process](https://reference.aspose.com/slides/de/python-net/aspose.slides.lowcode/merger/process/) erfordert Eingabepäsentationen im selben Format. Konvertieren Sie die Eingabedateien zunächst in ein gemeinsames Format, beispielsweise mit [Convert.auto_by_extension](https://reference.aspose.com/slides/de/python-net/aspose.slides.lowcode/convert/auto_by_extension/), und führen Sie dann die konvertierten Dateien zusammen.

**Was beinhaltet Collect.shapes?**

[Collect.shapes](https://reference.aspose.com/slides/de/python-net/aspose.slides.lowcode/collect/shapes/) ruft Formen aus der Präsentation ab, sodass sie behalten, gefiltert, gezählt oder mehrfach traversiert werden können. Verwenden Sie direkte Sammlungsschleifen, wenn Sie präzise steuern müssen, welche Folientypen oder verschachtelten Objekte besucht werden.

**Macht Compress die Präsentationsdatei immer kleiner?**

Nicht unbedingt. Das Ergebnis hängt davon ab, ob die Präsentation ungenutzte Layouts, ungenutzte Master oder eingebettete Schriften mit ungenutzten Zeichen enthält. Wenn keiner dieser Fälle zutrifft, können die entsprechenden [Compress](https://reference.aspose.com/slides/de/python-net/aspose.slides.lowcode/compress/)-Operationen die Dateigröße möglicherweise nicht reduzieren.

**Werden Änderungen, die von Compress vorgenommen werden, automatisch gespeichert?**

Nein. Diese Helfer arbeiten auf dem geladenen [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Objekt im Speicher. Nachdem Sie [Compress](https://reference.aspose.com/slides/de/python-net/aspose.slides.lowcode/compress/) ausgeführt haben, rufen Sie [Presentation.save](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/save/) auf, um das Ergebnis zu schreiben.

## **Verwandte Artikel**

- [Präsentation konvertieren](/python-net/convert-presentation/)
- [Präsentationen zusammenführen](/python-net/merge-presentation/)
- [Slide Master](/python-net/slide-master/)
- [Textfeld verwalten](/python-net/manage-textbox/)
- [Embedded Font](/python-net/embedded-font/)