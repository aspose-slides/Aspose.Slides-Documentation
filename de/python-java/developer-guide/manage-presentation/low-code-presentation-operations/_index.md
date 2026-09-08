---
title: Low-Code-Präsentationsoperationen in Python via Java
linktitle: Low-Code-API
type: docs
weight: 50
url: /de/python-java/low-code-presentation-operations/
keywords:
- Low-Code-Präsentations-API
- Präsentation konvertieren
- Präsentationen zusammenführen
- Folien iterieren
- Formen iterieren
- Text iterieren
- Formen sammeln
- Präsentation komprimieren
- Unbenutzte Masterfolien entfernen
- Unbenutzte Layoutfolien entfernen
- Eingebettete Schriften komprimieren
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Verwenden Sie die Aspose.Slides Low-Code-API in Python via Java, um Präsentationen zu konvertieren und zusammenzuführen, Inhalte zu iterieren, Shapes zu sammeln und die Präsentationsgröße zu reduzieren."
---
## **Übersicht**

Die [Aspose.Slides für Python via Java](https://reference.aspose.com/slides/de/python-java/aspose.slides/) API stellt statische Hilfsklassen für gängige Präsentationsoperationen bereit. Diese Helfer kapseln häufig genutzte Workflows des Objektmodells in fokussierten Methoden, sodass Sie Dateien konvertieren oder zusammenführen, Präsentationselemente verarbeiten, Shapes sammeln und nicht verwendete Inhalte mit weniger Code entfernen können.

Low‑Code‑Helfer sind am nützlichsten, wenn die Operation auf eine gesamte Datei oder Präsentation angewendet wird und der Standard‑Workflow Ihren Anforderungen entspricht. Verwenden Sie das vollständige [Aspose.Slides‑Objektmodell](https://reference.aspose.com/slides/de/python-java/aspose.slides/), wenn Sie eine feinkörnige Kontrolle über einzelne Folien, Master, Layouts, Shapes, Exporteinstellungen oder Beziehungen zwischen Präsentationselementen benötigen.

Die folgende Tabelle fasst die verfügbaren Helfer zusammen:

| Hilfsmittel | Verwendungszweck |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/de/python-java/aspose.slides/convert/) | Konvertieren einer Präsentation in ein anderes Format mit einem direkten Datei‑zu‑Datei‑Aufruf. |
| [Merger](https://reference.aspose.com/slides/de/python-java/aspose.slides/merger/) | Kombinieren kompletter Präsentationsdateien desselben Formats. |
| [ForEach](https://reference.aspose.com/slides/de/python-java/aspose.slides/foreach/) | Ausführen einer Aktion für jede Folie, jedes Shape, jeden Absatz oder Textabschnitt. |
| [Collect](https://reference.aspose.com/slides/de/python-java/aspose.slides/collect/) | Abrufen von Shapes aus der gesamten Präsentation für wiederholte Verarbeitung oder Analyse. |
| [Compress](https://reference.aspose.com/slides/de/python-java/aspose.slides/compress/) | Entfernen nicht genutzter Master und Layouts sowie Reduzierung eingebetteter Schriftartdaten. |

## **Eine Präsentation konvertieren**

Verwenden Sie [Convert.autoByExtension](https://reference.aspose.com/slides/de/python-java/aspose.slides/convert/#autoByExtension), wenn die Dateierweiterung des Ausgabepfads ausreicht, um das Exportformat zu bestimmen. Die Methode öffnet die Quellpräsentation, ermittelt das erforderliche Format aus dem Ausgabepfad und schreibt das Ergebnis.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Convert

Convert.autoByExtension("input.pptx", "output.pdf")
```

Die [Convert](https://reference.aspose.com/slides/de/python-java/aspose.slides/convert/)‑Klasse bietet außerdem dedizierte Methoden für PDF-, SVG-, JPEG-, PNG‑ und TIFF‑Ausgabe. Verwenden Sie das vollständige Objektmodell, wenn Sie die Präsentation vor dem Export prüfen oder ändern oder eine Exportoption konfigurieren müssen, die vom ausgewählten Helfer nicht bereitgestellt wird. Siehe [Convert Presentation](/slides/de/python-java/convert-presentation/) für format‑spezifische Workflows und Optionen.

## **Präsentationen zusammenführen**

Verwenden Sie [Merger.process](https://reference.aspose.com/slides/de/python-java/aspose.slides/merger/#process), um komplette Präsentationsdateien mit einem Aufruf zu kombinieren. Die Eingabedateien müssen dasselbe Dateiformat besitzen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Merger

input_files = jpype.JArray(jpype.JString)(["part-1.pptx", "part-2.pptx"])
Merger.process(input_files, "merged.pptx")
```

Der Helfer ist geeignet, wenn alle Folien zu einem Ergebnis hinzugefügt werden sollen, ohne sie einzeln auszuwählen oder neu zuzuordnen. Verwenden Sie das vollständige Objektmodell, wenn Sie ausgewählte Folien zusammenführen, einen Ziel‑Master oder ein Layout anwenden, Abschnitte explizit erhalten oder unterschiedliche Foliengrößen abgleichen müssen. Siehe [Merge Presentations](/slides/de/python-java/merge-presentation/) für diese Szenarien.

## **Durch Präsentationselemente iterieren**

Die [ForEach](https://reference.aspose.com/slides/de/python-java/aspose.slides/foreach/)‑Klasse ruft einen Callback für jeden angeforderten Typ von Präsentationselement auf. Sie vermeidet verschachtelte Schleifen über Sammlungen und ist praktisch für prüfungen‑ oder formatierungsänderungen auf gesamten Präsentationen.

Das folgende Beispiel verwendet [ForEach.slide](https://reference.aspose.com/slides/de/python-java/aspose.slides/foreach/#slide), [ForEach.shape](https://reference.aspose.com/slides/de/python-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/de/python-java/aspose.slides/foreach/#paragraph) und [ForEach.portion](https://reference.aspose.com/slides/de/python-java/aspose.slides/foreach/#portion), um die entsprechenden Elemente zu prüfen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ForEach, Presentation

def print_slide(slide, index):
    print(f"Slide {index}: {slide.getShapes().size()} shapes")

def print_shape(shape, slide, index):
    print(f"Shape {index} on {slide.getClass().getSimpleName()}: {shape.getName()}")

def print_paragraph(paragraph, slide, index):
    print(f"Paragraph {index} on {slide.getClass().getSimpleName()}: {paragraph.getText()}")

def print_portion(portion, paragraph, slide, index):
    print(f"Portion {index} on {slide.getClass().getSimpleName()}: {portion.getText()}")

presentation = Presentation("input.pptx")
try:
    ForEach.slide(presentation, print_slide)
    ForEach.shape(presentation, print_shape)
    ForEach.paragraph(presentation, print_paragraph)
    ForEach.portion(presentation, print_portion)
finally:
    presentation.dispose()
```

Standardmäßig umfasst die durchlaufweite Shape‑ und Text‑Traversal normale, Master‑ und Layout‑Folien. Überladungen mit einem `includeNotes`‑Parameter können zudem Notizfolien verarbeiten. Verwenden Sie direkte Schleifen, wenn die Traversierungsreihenfolge, ein früher Abbruch, Filterung vor dem Callback oder eine detaillierte Eltern‑Kind‑Steuerung wichtig sind.

## **Shapes sammeln**

Verwenden Sie [Collect.shapes](https://reference.aspose.com/slides/de/python-java/aspose.slides/collect/#shapes), wenn Sie eine Sammlung aller Shapes einer Präsentation benötigen und nicht für jedes Shape einen Callback ausführen wollen. Dies ist nützlich, wenn dieselbe Menge mehrfach gefiltert, gezählt oder verarbeitet werden soll.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Collect, Presentation

presentation = Presentation("input.pptx")
try:
    shapes = Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.getName()}: {shape.getClass().getSimpleName()}")
finally:
    presentation.dispose()
```

Verwenden Sie stattdessen [ForEach.shape](https://reference.aspose.com/slides/de/python-java/aspose.slides/foreach/#shape), wenn jedes Shape sofort bearbeitet werden kann und Sie das gesammelte Ergebnis nicht behalten müssen.

## **Präsentationsinhalt komprimieren**

Die [Compress](https://reference.aspose.com/slides/de/python-java/aspose.slides/compress/)‑Klasse kann nicht genutzte strukturelle Elemente entfernen und eingebettete Schriftartdaten reduzieren:

- [removeUnusedLayoutSlides](https://reference.aspose.com/slides/de/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) entfernt Layout‑Folien, auf die keine normale Folie verweist.
- [removeUnusedMasterSlides](https://reference.aspose.com/slides/de/python-java/aspose.slides/compress/#removeUnusedMasterSlides) entfernt Master‑Folien, die nicht mehr verwendet werden.
- [compressEmbeddedFonts](https://reference.aspose.com/slides/de/python-java/aspose.slides/compress/#compressEmbeddedFonts) entfernt nicht genutzte Zeichen aus eingebetteten Schriften.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    Compress.removeUnusedLayoutSlides(presentation)
    Compress.removeUnusedMasterSlides(presentation)
    Compress.compressEmbeddedFonts(presentation)

    presentation.save("compressed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Entfernen Sie zunächst nicht genutzte Layouts, bevor Sie nicht genutzte Master entfernen, damit ein Master, der nach der Layout‑Bereinigung nicht mehr referenziert wird, ebenfalls gelöscht werden kann. Speichern Sie die optimierte Präsentation in einer neuen Datei, falls Sie später die ursprünglichen Master, Layouts oder die vollständigen eingebetteten Schriftartdaten benötigen. Weitere Details finden Sie unter [Slide Master](/slides/de/python-java/slide-master/) und [Embedded Font](/slides/de/python-java/embedded-font/).

## **FAQ**

**Wann sollte ich die Low‑Code‑API statt des vollständigen Objektmodells verwenden?**

Verwenden Sie Low‑Code‑Helfer, wenn eine Standard‑Operation auf eine komplette Datei oder Präsentation zutrifft und keine detaillierte Kontrolle über einzelne Elemente erforderlich ist. Nutzen Sie das vollständige Objektmodell, wenn Sie bestimmte Folien auswählen, Beziehungen zwischen Master und Layout steuern, Zwischenzustände prüfen oder Verhalten konfigurieren müssen, das der Helfer nicht bereitstellt.

**Kann Merger Präsentationen in unterschiedlichen Dateiformaten kombinieren?**

Nein. [Merger.process](https://reference.aspose.com/slides/de/python-java/aspose.slides/merger/#process) erfordert Eingabedateien im selben Format. Konvertieren Sie die Eingabedateien zunächst in ein gemeinsames Format, zum Beispiel mit [Convert.autoByExtension](https://reference.aspose.com/slides/de/python-java/aspose.slides/convert/#autoByExtension), und führen Sie anschließend die konvertierten Dateien zusammen.

**Verarbeitet ForEach Master‑, Layout‑ und Notizfolien?**

[ForEach.slide](https://reference.aspose.com/slides/de/python-java/aspose.slides/foreach/#slide) iteriert über normale Präsentationsfolien. Präsentationsweite [ForEach.shape](https://reference.aspose.com/slides/de/python-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/de/python-java/aspose.slides/foreach/#paragraph) und [ForEach.portion](https://reference.aspose.com/slides/de/python-java/aspose.slides/foreach/#portion) schließen standardmäßig normale, Master‑ und Layout‑Folien ein. Verwenden Sie deren Überladungen mit `includeNotes` = `True`, um Notizfolien einzubeziehen.

**Was ist der Unterschied zwischen ForEach.shape und Collect.shapes?**

Verwenden Sie [ForEach.shape](https://reference.aspose.com/slides/de/python-java/aspose.slides/foreach/#shape), um jedes Shape sofort über einen Callback zu verarbeiten. Verwenden Sie [Collect.shapes](https://reference.aspose.com/slides/de/python-java/aspose.slides/collect/#shapes), wenn Sie ein iterierbares Ergebnis benötigen, das Sie behalten, filtern, zählen oder mehrfach durchlaufen können.

**Macht Compress immer die Präsentationsdatei kleiner?**

Nicht unbedingt. Das Ergebnis hängt davon ab, ob die Präsentation nicht genutzte Layouts, nicht genutzte Master oder eingebettete Schriften mit ungenutzten Zeichen enthält. Wenn keine dieser Komponenten vorhanden ist, reduzieren die entsprechenden [Compress](https://reference.aspose.com/slides/de/python-java/aspose.slides/compress/)‑Operationen die Dateigröße möglicherweise nicht.

**Werden Änderungen, die durch ForEach oder Compress vorgenommen wurden, automatisch gespeichert?**

Nein. Diese Helfer arbeiten auf dem geladenen [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Objekt im Speicher. Nachdem Sie Elemente in einem [ForEach](https://reference.aspose.com/slides/de/python-java/aspose.slides/foreach/)‑Callback geändert oder [Compress](https://reference.aspose.com/slides/de/python-java/aspose.slides/compress/) ausgeführt haben, rufen Sie [Presentation.save](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#save) auf, um das Ergebnis zu schreiben.

## **Verwandte Artikel**

- [Convert Presentation](/slides/de/python-java/convert-presentation/)
- [Merge Presentations](/slides/de/python-java/merge-presentation/)
- [Slide Master](/slides/de/python-java/slide-master/)
- [Manage Text Box](/slides/de/python-java/manage-textbox/)
- [Embedded Font](/slides/de/python-java/embedded-font/)