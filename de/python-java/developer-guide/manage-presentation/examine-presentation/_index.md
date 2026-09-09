---
title: Abrufen und Aktualisieren von Präsentationsinformationen in Python via Java
linktitle: Präsentationsinformationen
type: docs
weight: 30
url: /de/python-java/examine-presentation/
keywords:
- Präsentationsformat
- Präsentationseigenschaften
- Dokumenteigenschaften
- Eigenschaften abrufen
- Eigenschaften lesen
- Eigenschaften ändern
- Eigenschaften modifizieren
- Eigenschaften aktualisieren
- PPTX untersuchen
- PPT untersuchen
- ODP untersuchen
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Untersuchen Sie Folien, Struktur und Metadaten in PowerPoint- und OpenDocument-Präsentationen mit Python via Java für schnellere Einblicke und intelligentere Inhaltsprüfungen."
---
## **Übersicht**

Aspose.Slides kann das Format einer Präsentation erkennen und deren Dokumentmetadaten auslesen, ohne ein vollständiges Präsentationsobjektmodell zu erstellen. Dies ist nützlich, wenn Sie Dateien klassifizieren, ein Inventar erstellen oder Eigenschaften prüfen müssen, bevor Sie entscheiden, ob Sie den Präsentationsinhalt laden und verarbeiten.

Die Beispiele erfordern Aspose.Slides für Python via Java und eine kompatible Java-Laufzeit. Jedes Beispiel startet die JVM, falls sie nicht bereits läuft. Stellen Sie vorhandene Präsentationsdateien an den in den Beispielen verwendeten Pfaden bereit.

Dieser Artikel demonstriert eine leichte Inspektion mittels [PresentationFactory](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentationfactory/) und [PresentationInfo](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentationinfo/), sowie gezielte Aktualisierungen über [DocumentProperties](https://reference.aspose.com/slides/de/python-java/aspose.slides/documentproperties/).

## **Prüfen des Präsentationsformats**

Verwenden Sie [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentationfactory/#getPresentationInfo), um eine Datei zu prüfen, ohne eine [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) Instanz zu erstellen. Die Methode [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentationinfo/#getLoadFormat) gibt das erkannte Format zurück, z. B. PPTX, PPT oder ODP.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadFormat, PresentationFactory

file_names = ["pres.pptx", "pres.ppt", "pres.odp"]

for file_name in file_names:
    presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_name)
    load_format = presentation_info.getLoadFormat()
    format_name = f"Other ({load_format})"

    if load_format == LoadFormat.Pptx:
        format_name = "PPTX"
    elif load_format == LoadFormat.Ppt:
        format_name = "PPT"
    elif load_format == LoadFormat.Odp:
        format_name = "ODP"

    print(f"{file_name}: {format_name}")
```

## **Erstellung eines leichten Präsentationsinventars**

Wenn Sie viele Präsentationsdateien verarbeiten, benötigen Sie möglicherweise ein kompaktes Inventar für Validierung, Indexierung oder ein Dokumenten‑Management‑System. In diesem Szenario verwenden Sie [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentationfactory/#getPresentationInfo), um ein [PresentationInfo](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentationinfo/) Objekt zu erhalten, und rufen dann [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentationinfo/#readDocumentProperties) auf, um die Dokumentmetadaten zu lesen. Dieser Ansatz erstellt keine [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) Instanz und erfordert nicht das Durchlaufen des gesamten Präsentationsobjektmodells.

Die von [DocumentProperties](https://reference.aspose.com/slides/de/python-java/aspose.slides/documentproperties/) bereitgestellten erweiterten Eigenschaften liefern die folgenden Inventarwerte:

| Methode | Inventarwert |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/de/python-java/aspose.slides/documentproperties/#getSlides) | Gesamtzahl der Folien. |
| [getHiddenSlides](https://reference.aspose.com/slides/de/python-java/aspose.slides/documentproperties/#getHiddenSlides) | Anzahl der ausgeblendeten Folien. |
| [getNotes](https://reference.aspose.com/slides/de/python-java/aspose.slides/documentproperties/#getNotes) | Anzahl der Folien, die Notizen enthalten. |
| [getParagraphs](https://reference.aspose.com/slides/de/python-java/aspose.slides/documentproperties/#getParagraphs) | Gesamtzahl der Absätze, falls verfügbar. |
| [getWords](https://reference.aspose.com/slides/de/python-java/aspose.slides/documentproperties/#getWords) | Gesamtzahl der Wörter. |
| [getMultimediaClips](https://reference.aspose.com/slides/de/python-java/aspose.slides/documentproperties/#getMultimediaClips) | Gesamtzahl der Audio‑ und Videoclips. |

Das folgende Beispiel liest diese Werte, ohne ein [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) Objekt zu erstellen, und gibt ein kompaktes Inventar aus. Es kombiniert außerdem [getHeadingPairs](https://reference.aspose.com/slides/de/python-java/aspose.slides/documentproperties/#getHeadingPairs) mit [getTitlesOfParts](https://reference.aspose.com/slides/de/python-java/aspose.slides/documentproperties/#getTitlesOfParts), um Inhaltsgruppen wie Schriftarten, Designs und Folientitel anzuzeigen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import LoadFormat, PresentationFactory

file_path = "sample.pptx"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_path)
document_properties = presentation_info.readDocumentProperties()

load_format = presentation_info.getLoadFormat()
format_name = f"Other ({load_format})"

if load_format == LoadFormat.Pptx:
    format_name = "PPTX"
elif load_format == LoadFormat.Ppt:
    format_name = "PPT"
elif load_format == LoadFormat.Odp:
    format_name = "ODP"

print(f"File: {Path(file_path).name}")
print(f"Format: {format_name}")
print(f"Title: {document_properties.getTitle()}")
print(f"Author: {document_properties.getAuthor()}")
print("Statistics:")
print(f"  Slides: {document_properties.getSlides()}")
print(f"  Hidden slides: {document_properties.getHiddenSlides()}")
print(f"  Slides with notes: {document_properties.getNotes()}")
print(f"  Paragraphs: {document_properties.getParagraphs()}")
print(f"  Words: {document_properties.getWords()}")
print(f"  Multimedia clips: {document_properties.getMultimediaClips()}")

heading_pairs = document_properties.getHeadingPairs()
titles_of_parts = document_properties.getTitlesOfParts()
heading_pairs = heading_pairs if heading_pairs is not None else []
titles_of_parts = titles_of_parts if titles_of_parts is not None else []
part_index = 0

if len(heading_pairs) == 0 or len(titles_of_parts) == 0:
    print("Content groups: not available")
else:
    print("Content groups:")

    for heading_pair in heading_pairs:
        print(f"  {heading_pair.getName()} ({heading_pair.getCount()})")

        for part_offset in range(heading_pair.getCount()):
            if part_index >= len(titles_of_parts):
                break
            print(f"    - {titles_of_parts[part_index]}")
            part_index += 1

    if part_index < len(titles_of_parts):
        print("  Other parts:")

        while part_index < len(titles_of_parts):
            print(f"    - {titles_of_parts[part_index]}")
            part_index += 1
```

Jedes [HeadingPair](https://reference.aspose.com/slides/de/python-java/aspose.slides/headingpair/) liefert einen Gruppennamen und die Anzahl der Elemente in dieser Gruppe. [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/de/python-java/aspose.slides/documentproperties/#getTitlesOfParts) gibt ein flaches, geordnetes Array zurück, sodass die Anzahl aufeinanderfolgender Titel, die von jedem Heading‑Pair angegeben wird, verarbeitet werden kann.

### **Gespeicherte Metadaten und Formatbeschränkungen**

Die von [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentationinfo/#readDocumentProperties) zurückgegebenen Inventareigenschaften spiegeln die im Quell‑Dokument verfügbaren Metadaten wider. Aspose.Slides lädt das Präsentationsobjektmodell nicht und durchläuft es nicht, um diese Werte für diesen Aufruf neu zu berechnen. Fehlende Eigenschaften werden durch Standardwerte dargestellt, und gespeicherte Werte können veraltet sein, wenn die Anwendung, die die Datei zuletzt gespeichert hat, ihre Dokumenteigenschaften nicht aktualisiert hat.

- **PPTX:** Das Format liefert erweiterte Dokumenteigenschaften für Folien‑, Notiz‑, ausgeblendete‑Folien‑, Absatz‑, Wort‑ und Multimediacounts sowie Heading‑Pairs und Part‑Titles. Die Verfügbarkeit hängt davon ab, welche Eigenschaften vom Dokumentersteller geschrieben wurden.  
- **PPT:** Das Binärformat kann entsprechende document‑summary‑Eigenschaften speichern. Ist eine Eigenschaft nicht vorhanden oder wurde vom Dokumentersteller nicht aktualisiert, gibt Aspose.Slides ihren gespeicherten oder Standardwert zurück, anstatt sie aus den Folien zu berechnen.  
- **ODP:** OpenDocument‑Metadaten bieten allgemeine Dokumentstatistiken wie Seiten‑, Absatz‑ und Wortzahlen, jedoch lassen sich diese Werte nicht auf sämtliche PowerPoint‑spezifischen erweiterten Eigenschaften abbilden. Metadaten zu ausgeblendeten Folien, Notizen‑Folien, Multimedia, Heading‑Pairs und Part‑Titles können fehlen, und die Inventareigenschaften geben möglicherweise Standardwerte zurück. Ein Nullwert oder ein leeres Array sollten nicht als eindeutiger Nachweis dafür angesehen werden, dass der entsprechende Inhalt fehlt.

Verwenden Sie den leichten Metadaten‑Ansatz für Inventare und vorläufige Prüfungen. Laden Sie die Präsentation und prüfen Sie ihr Live‑Objektmodell, wenn das Ergebnis in‑Memory‑Änderungen widerspiegeln muss oder Sie den tatsächlichen Präsentationsinhalt verifizieren möchten.

## **Präsentationseigenschaften aktualisieren**

Die von [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentationinfo/#readDocumentProperties) zurückgegebenen Eigenschaften können auch geändert werden, ohne eine [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) Instanz zu erstellen. Wenden Sie die Änderungen mit [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentationinfo/#updateDocumentProperties) an und schreiben Sie dann die gebundene Präsentation mit [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentationinfo/#writeBindedPresentation).

Das folgende Bild zeigt die ursprünglichen Dokumenteigenschaften der PowerPoint‑Präsentation.

![Originale Dokumenteigenschaften der PowerPoint‑Präsentation](input_properties.png)

Das folgende Beispiel ändert den Titel und die zuletzt gespeicherte Zeit und schreibt das Ergebnis in eine neue Datei:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory
from java.io import FileOutputStream
from java.util import Date

source_file = "sample.pptx"
output_file = "sample_with_updated_properties.pptx"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(source_file)
document_properties = presentation_info.readDocumentProperties()

document_properties.setTitle("Quarterly sales report")
last_saved_time = Date()
document_properties.setLastSavedTime(last_saved_time)

presentation_info.updateDocumentProperties(document_properties)
output_stream = FileOutputStream(output_file)
try:
    presentation_info.writeBindedPresentation(output_stream)
finally:
    output_stream.close()
```

Das folgende Bild zeigt die geänderten Dokumenteigenschaften der PowerPoint‑Präsentation.

![Geänderte Dokumenteigenschaften der PowerPoint‑Präsentation](output_properties.png)

## **Nützliche Links**

Für verwandte Sicherheitsprüfungen und Schutzeinstellungen siehe die folgenden Artikel:

- [Password‑Protect Presentations](/slides/de/python-java/password-protected-presentation/)
- [Write‑Protect Presentations](/slides/de/python-java/write-protected-presentation/)

## **FAQ**

**Wie kann ich prüfen, ob Schriftarten eingebettet sind und welche das sind?**

Laden Sie die Präsentation und verwenden Sie [Presentation.getFontsManager](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getFontsManager). Rufen Sie [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) auf, um die eingebetteten Schriftarten zu erhalten, und [FontsManager.getFonts](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontsmanager/#getFonts), um die von der Präsentation verwendeten Schriftarten zu erhalten. Vergleichen Sie beide Ergebnisse, um Schriftarten zu finden, die für die Darstellung erforderlich, aber nicht eingebettet sind.

**Wie kann ich schnell feststellen, ob die Datei ausgeblendete Folien enthält und wie viele?**

Wenn die gespeicherten Dokumentmetadaten ausreichen, lesen Sie [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/de/python-java/aspose.slides/documentproperties/#getHiddenSlides) über [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentationfactory/#getPresentationInfo) und [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentationinfo/#readDocumentProperties). Dies eignet sich für ein leichtes Inventar. Wenn die Präsentation im Speicher verändert wurde, können die gespeicherten Metadaten fehlen oder veraltet sein; in diesem Fall iterieren Sie über [Presentation.getSlides](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getSlides) und prüfen jede Folie mit [Slide.getHidden](https://reference.aspose.com/slides/de/python-java/aspose.slides/slide/#getHidden).

**Kann ich erkennen, ob eine benutzerdefinierte Foliengröße und -ausrichtung verwendet werden und ob sie von den Vorgaben abweichen?**

Ja. Laden Sie die Präsentation und rufen Sie [Presentation.getSlideSize](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getSlideSize) auf. Verwenden Sie [SlideSize.getType](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidesize/#getType), [SlideSize.getSize](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidesize/#getSize) und [SlideSize.getOrientation](https://reference.aspose.com/slides/de/python-java/aspose.slides/slidesize/#getOrientation), um die aktuellen Einstellungen mit den erwarteten Vorgaben und Abmessungen zu vergleichen.

**Gibt es eine schnelle Möglichkeit zu erkennen, ob Diagramme externe Datenquellen referenzieren?**

Ja. Suchen Sie jedes [Chart](https://reference.aspose.com/slides/de/python-java/aspose.slides/chart/) und rufen Sie [ChartData.getDataSourceType](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdata/#getDataSourceType) auf. Für eine externe Arbeitsmappe rufen Sie [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/de/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) auf. Der Datentyp und der Pfad identifizieren eine externe Referenz, aber die Prüfung, ob das Ziel verfügbar ist, erfordert eine separate Ressourcen‑Kontrolle.

**Wie kann ich 'schwere' Folien beurteilen, die das Rendering oder den PDF‑Export verlangsamen könnten?**

Es gibt keine einzelne Komplexitäts‑Eigenschaft. Durchlaufen Sie [Presentation.getSlides](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getSlides) und für jede Folie die [BaseSlide.getShapes](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseslide/#getShapes)‑Sammlung. Nutzen Sie die Anzahl der Formen sowie das Vorhandensein großer Bilder, Effekte, Animationen oder Multimedia als Hinweisindikatoren und messen Sie ein repräsentatives Rendering oder Export, bevor Sie eine Folie als bestätigten Performance‑Flaschenhals einstufen.