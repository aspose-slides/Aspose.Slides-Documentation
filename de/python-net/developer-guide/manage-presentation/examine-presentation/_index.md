---
title: Abrufen und Aktualisieren von Präsentationsinformationen in Python
linktitle: Präsentationsinformationen
type: docs
weight: 30
url: /de/python-net/examine-presentation/
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
- Aspose.Slides
description: "Untersuchen Sie Folien, Struktur und Metadaten in PowerPoint- und OpenDocument-Präsentationen mit Python für schnellere Einblicke und intelligentere Inhaltsprüfungen."
---
## **Übersicht**

Aspose.Slides kann das Format einer Präsentation ermitteln und die Dokumentmetadaten auslesen, ohne ein vollständiges Präsentationsobjektmodell zu erstellen. Dies ist nützlich, wenn Sie Dateien klassifizieren, ein Inventar erstellen oder Eigenschaften prüfen müssen, bevor Sie entscheiden, ob die Präsentationsinhalte geladen und verarbeitet werden sollen.

Dieser Artikel demonstriert eine leichte Inspektion über [PresentationFactory](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentationfactory/) und [PresentationInfo](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentationinfo/), sowie gezielte Aktualisierungen über [DocumentProperties](https://reference.aspose.com/slides/de/python-net/aspose.slides/documentproperties/).

## **Prüfen des Präsentationsformats**

Verwenden Sie [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentationfactory/get_presentation_info/), um eine Datei zu inspizieren, ohne eine [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Instanz zu erstellen. Die Eigenschaft [PresentationInfo.load_format](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentationinfo/load_format/) gibt das erkannte Format zurück, z. B. PPTX, PPT oder ODP.

```python
import aspose.slides as slides

file_names = ["pres.pptx", "pres.ppt", "pres.odp"]

for file_name in file_names:
    presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_name)
    print(f"{file_name}: {presentation_info.load_format}")
```

## **Erstellen eines leichten Präsentationsinventars**

Wenn Sie viele Präsentationsdateien verarbeiten, benötigen Sie möglicherweise ein kompaktes Inventar zur Validierung, Indexierung oder für ein Dokumenten‑Management‑System. In diesem Szenario verwenden Sie [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentationfactory/get_presentation_info/), um ein [PresentationInfo](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentationinfo/)‑Objekt zu erhalten, und rufen dann [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentationinfo/read_document_properties/) auf, um die Dokumentmetadaten zu lesen. Dieser Ansatz erstellt keine [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Instanz und erfordert nicht, dass Sie das komplette Präsentationsobjektmodell durchlaufen.

Die von [DocumentProperties](https://reference.aspose.com/slides/de/python-net/aspose.slides/documentproperties/) bereitgestellten erweiterten Eigenschaften liefern folgende Inventarwerte:

| Eigenschaft | Inventarwert |
| --- | --- |
| [slides](https://reference.aspose.com/slides/de/python-net/aspose.slides/documentproperties/slides/de/) | Gesamtzahl der Folien. |
| [hidden_slides](https://reference.aspose.com/slides/de/python-net/aspose.slides/documentproperties/hidden_slides/) | Anzahl versteckter Folien. |
| [notes](https://reference.aspose.com/slides/de/python-net/aspose.slides/documentproperties/notes/) | Anzahl der Folien, die Notizen enthalten. |
| [paragraphs](https://reference.aspose.com/slides/de/python-net/aspose.slides/documentproperties/paragraphs/) | Gesamtzahl der Absätze, sofern verfügbar. |
| [words](https://reference.aspose.com/slides/de/python-net/aspose.slides/documentproperties/words/) | Gesamtzahl der Wörter. |
| [multimedia_clips](https://reference.aspose.com/slides/de/python-net/aspose.slides/documentproperties/multimedia_clips/) | Gesamtzahl der Audio‑ und Videoclips. |

Das folgende Beispiel liest diese Werte, ohne ein [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Objekt zu erstellen, und gibt ein kompaktes Inventar aus. Es kombiniert zudem [heading_pairs](https://reference.aspose.com/slides/de/python-net/aspose.slides/documentproperties/heading_pairs/) mit [titles_of_parts](https://reference.aspose.com/slides/de/python-net/aspose.slides/documentproperties/titles_of_parts/), um Inhaltsgruppen wie Schriftarten, Designs und Folientitel anzuzeigen.

```python
import os
import aspose.slides as slides

file_path = "sample.pptx"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_path)
document_properties = presentation_info.read_document_properties()

print(f"File: {os.path.basename(file_path)}")
print(f"Format: {presentation_info.load_format}")
print(f"Title: {document_properties.title}")
print(f"Author: {document_properties.author}")
print("Statistics:")
print(f"  Slides: {document_properties.slides}")
print(f"  Hidden slides: {document_properties.hidden_slides}")
print(f"  Slides with notes: {document_properties.notes}")
print(f"  Paragraphs: {document_properties.paragraphs}")
print(f"  Words: {document_properties.words}")
print(f"  Multimedia clips: {document_properties.multimedia_clips}")

heading_pairs = document_properties.heading_pairs or []
titles_of_parts = document_properties.titles_of_parts or []
part_index = 0

if not heading_pairs or not titles_of_parts:
    print("Content groups: not available")
else:
    print("Content groups:")

    for heading_pair in heading_pairs:
        print(f"  {heading_pair.name} ({heading_pair.count})")

        for _ in range(heading_pair.count):
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

Jedes [HeadingPair](https://reference.aspose.com/slides/de/python-net/aspose.slides/headingpair/) liefert einen Gruppennamen und die Anzahl der Elemente in dieser Gruppe. [DocumentProperties.titles_of_parts](https://reference.aspose.com/slides/de/python-net/aspose.slides/documentproperties/titles_of_parts/) ist eine flache, geordnete Sammlung, sodass Sie die Anzahl aufeinanderfolgender Titel verarbeiten, die durch jedes Heading‑Pair angegeben werden.

### **Gespeicherte Metadaten und Formatbeschränkungen**

Die von [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentationinfo/read_document_properties/) zurückgegebenen Inventareigenschaften spiegeln die im Quell‑Dokument verfügbaren Metadaten wider. Aspose.Slides lädt und durchläuft das Präsentationsobjektmodell nicht, um diese Werte für diesen Aufruf neu zu berechnen. Fehlende Eigenschaften werden durch Standardwerte dargestellt, und gespeicherte Werte können veraltet sein, wenn die Anwendung, die die Datei zuletzt gespeichert hat, deren Dokumenteigenschaften nicht aktualisiert hat.

- **PPTX:** Das Format stellt erweiterte Dokumenteigenschaften für Folien‑, Notiz‑, versteckte‑Folien‑, Absatz‑, Wort‑ und Multimediacounts sowie Heading‑Pairs und Part‑Titles bereit. Die Verfügbarkeit hängt davon ab, welche Eigenschaften vom Dokumentproduzenten geschrieben wurden.
- **PPT:** Das Binärformat kann entsprechende Dokument‑Zusammenfassungs‑Eigenschaften speichern. Ist eine Eigenschaft nicht vorhanden oder wurde vom Dokumentproduzenten nicht aktualisiert, gibt Aspose.Slides den gespeicherten oder Standardwert zurück, anstatt ihn aus den Folien zu berechnen.
- **ODP:** OpenDocument‑Metadaten liefern allgemeine Dokumentstatistiken wie Seiten‑, Absatz‑ und Wortzahlen, jedoch lassen sich diese Werte nicht immer auf jede PowerPoint‑spezifische erweiterte Eigenschaft abbilden. Metadaten zu versteckten Folien, Notizfolien, Multimedia, Heading‑Pairs und Part‑Titles können fehlen, und die Inventareigenschaften geben ggf. Standardwerte zurück. Behandeln Sie einen Nullwert oder eine leere Sammlung nicht als endgültigen Beweis dafür, dass der entsprechende Inhalt fehlt.

Verwenden Sie den leichten Metadatenansatz für Inventare und Vorprüfungen. Laden Sie die Präsentation und inspizieren Sie ihr Live‑Objektmodell, wenn das Ergebnis In‑Memory‑Änderungen widerspiegeln muss oder wenn Sie den tatsächlichen Präsentationsinhalt verifizieren wollen.

## **Präsentationseigenschaften aktualisieren**

Die von [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentationinfo/read_document_properties/) zurückgegebenen Eigenschaften können ebenfalls geändert werden, ohne eine [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Instanz zu erstellen. Wenden Sie die Änderungen mit [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentationinfo/update_document_properties/) an und schreiben Sie anschließend die gebundene Präsentation mit [PresentationInfo.write_binded_presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentationinfo/write_binded_presentation/).

Das folgende Bild zeigt die ursprünglichen Dokumenteigenschaften.

![Ursprüngliche Dokumenteigenschaften der PowerPoint‑Präsentation](input_properties.png)

Das folgende Beispiel ändert den Titel und den zuletzt gespeicherten Zeitpunkt und schreibt das Ergebnis in eine neue Datei:

```python
import datetime
import aspose.slides as slides

source_file = "sample.pptx"
output_file = "sample_with_updated_properties.pptx"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(source_file)
document_properties = presentation_info.read_document_properties()

document_properties.title = "Quarterly sales report"
document_properties.last_saved_time = datetime.datetime.now(datetime.timezone.utc)

presentation_info.update_document_properties(document_properties)

with open(output_file, "wb") as output_stream:
    presentation_info.write_binded_presentation(output_stream)
```

Das folgende Bild zeigt die geänderten Dokumenteigenschaften.

![Geänderte Dokumenteigenschaften der PowerPoint‑Präsentation](output_properties.png)

## **Nützliche Links**

Für verwandte Sicherheitsprüfungen und Schutzeinstellungen siehe die folgenden Artikel:

- [Password-Protect Presentations](/slides/de/python-net/password-protected-presentation/)
- [Write-Protect Presentations](/slides/de/python-net/write-protected-presentation/)

## **FAQ**

**Wie kann ich prüfen, ob Schriftarten eingebettet sind und welche das sind?**

Laden Sie die Präsentation und verwenden Sie [Presentation.fonts_manager](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/fonts_manager/). Rufen Sie [FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/de/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) auf, um die eingebetteten Schriftarten zu erhalten, und [FontsManager.get_fonts](https://reference.aspose.com/slides/de/python-net/aspose.slides/fontsmanager/get_fonts/), um die von der Präsentation verwendeten Schriftarten zu erhalten. Vergleichen Sie die beiden Ergebnisse, um Schriftarten zu finden, die für die Darstellung erforderlich, aber nicht eingebettet sind.

**Wie kann ich schnell erkennen, ob die Datei versteckte Folien enthält und wie viele?**

Wenn die gespeicherten Dokumentmetadaten ausreichen, lesen Sie [DocumentProperties.hidden_slides](https://reference.aspose.com/slides/de/python-net/aspose.slides/documentproperties/hidden_slides/) über [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentationfactory/get_presentation_info/) und [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentationinfo/read_document_properties/). Dies eignet sich für ein leichtes Inventar. Wenn die Präsentation im Speicher verändert wurde, können die gespeicherten Metadaten fehlen oder veraltet sein; in diesem Fall iterieren Sie über [Presentation.slides](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/slides/de/) und prüfen jede Folie über die Eigenschaft [Slide.hidden](https://reference.aspose.com/slides/de/python-net/aspose.slides/slide/hidden/).

**Kann ich erkennen, ob eine benutzerdefinierte Foliengröße und -ausrichtung verwendet wird und ob sie von den Vorgaben abweicht?**

Ja. Laden Sie die Präsentation und lesen Sie [Presentation.slide_size](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/slide_size/). Prüfen Sie [SlideSize.type](https://reference.aspose.com/slides/de/python-net/aspose.slides/slidesize/type/), [SlideSize.size](https://reference.aspose.com/slides/de/python-net/aspose.slides/slidesize/size/) und [SlideSize.orientation](https://reference.aspose.com/slides/de/python-net/aspose.slides/slidesize/orientation/), um die aktuellen Einstellungen mit den erwarteten Vorgaben und Abmessungen zu vergleichen.

**Gibt es eine schnelle Möglichkeit zu erkennen, ob Diagramme externe Datenquellen referenzieren?**

Ja. Lokalisieren Sie jedes [Chart](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chart/) und prüfen Sie [ChartData.data_source_type](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdata/data_source_type/). Für eine externe Arbeitsmappe lesen Sie [ChartData.external_workbook_path](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chartdata/external_workbook_path/). Der Datentyp und Pfad zeigen eine externe Referenz an, aber die Verfügbarkeit des Ziels muss separat geprüft werden.

**Wie kann ich „schwere“ Folien beurteilen, die das Rendern oder den PDF‑Export verlangsamen könnten?**

Es gibt keine einzelne Komplexitäts‑Eigenschaft. Durchlaufen Sie [Presentation.slides](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/slides/de/) und die [BaseSlide.shapes](https://reference.aspose.com/slides/de/python-net/aspose.slides/baseslide/shapes/)‑Sammlung jeder Folie. Verwenden Sie die Anzahl der Formen sowie das Vorhandensein großer Bilder, Effekte, Animationen oder Multimedia als Indikatoren und messen Sie eine repräsentative Render‑ oder Exportzeit, bevor Sie eine Folie als bestätigten Performance‑Engpass einstufen.