---
title: Ermitteln des Original‑Präsentationsformats in Python
linktitle: Quellformat
type: docs
weight: 35
url: /de/python-net/detect-presentation-source-format/
keywords:
- Quellformat
- Präsentationsformat erkennen
- PowerPoint
- OpenDocument
- Präsentation
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Lesen Sie das ursprüngliche Format einer geladenen Präsentation in Python mit Aspose.Slides für Python über .NET, vergleichen Sie Erkennungs-APIs und verarbeiten Sie Dateien, Streams und Legacy-Formate."
---
## **Übersicht**

Nachdem Sie eine Präsentation geladen haben, lesen Sie die schreibgeschützte [Presentation.source_format](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/source_format/) Eigenschaft, um ihr ursprüngliches Format zu bestimmen. Verwenden Sie sie, wenn die nachfolgende Verarbeitung vom Format abhängt, aus dem die aktuelle Instanz geladen wurde.

Das Quellformat unterscheidet sich vom für eine Ausgabedatei ausgewählten [SaveFormat](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/saveformat/). Das Speichern in ein anderes Format ändert das Quellformat der bestehenden Instanz nicht.

## **Quellformat einer Datei lesen**

Dieses Beispiel erfordert eine vorhandene Datei `sample.pptx`. Es lädt die Datei und wählt eine Anwendungs‑Verarbeitungspolicy mithilfe von [Presentation.source_format](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/source_format/), anstatt den Dateinamen zu verwenden. Ändern Sie den Eingabepfad, um andere Formate zu testen. Das Beispiel gibt die gewählte Policy aus; ersetzen Sie die Meldungen durch Ihre Anwendungslogik.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    source_format = presentation.source_format
    if source_format in (slides.SourceFormat.PPT, slides.SourceFormat.PPS, slides.SourceFormat.POT):
        print("Use the legacy PowerPoint processing policy.")
    elif source_format == slides.SourceFormat.PPTX:
        print("Use the standard PPTX processing policy.")
    else:
        print(f"Use the general policy for {source_format.name}.")
```

## **Erkennen der unterstützten Werte**

Die [SourceFormat](https://reference.aspose.com/slides/de/python-net/aspose.slides/sourceformat/) Aufzählung unterscheidet die folgenden Präsentationsformate. Die untenstehenden Erweiterungen sind konventionelle Erweiterungen, keine Rekonstruktion des ursprünglichen Dateinamens.

| SourceFormat‑Wert | Erweiterung | Format |
| --- | --- | --- |
| `PPT` | `.ppt` | PowerPoint 97–2003‑Präsentation |
| `PPTX` | `.pptx` | Office‑Open‑XML‑Präsentation |
| `PPTM` | `.pptm` | Makro‑aktivierte Office‑Open‑XML‑Präsentation |
| `PPS` | `.pps` | PowerPoint 97–2003‑Diashow |
| `PPSX` | `.ppsx` | Office‑Open‑XML‑Diashow |
| `PPSM` | `.ppsm` | Makro‑aktivierte Office‑Open‑XML‑Diashow |
| `POT` | `.pot` | PowerPoint 97–2003‑Vorlage |
| `POTX` | `.potx` | Office‑Open‑XML‑Vorlage |
| `POTM` | `.potm` | Makro‑aktivierte Office‑Open‑XML‑Vorlage |
| `ODP` | `.odp` | OpenDocument‑Präsentation |
| `OTP` | `.otp` | OpenDocument‑Präsentationsvorlage |
| `FODP` | `.fodp` | Flat‑XML‑ODF‑Präsentation |
| `XML` | `.xml` | PowerPoint‑XML‑Präsentation |

## **Quellformat eines Streams lesen**

Dieses Beispiel erfordert eine vorhandene Datei `sample.pps`. Das Einlesen ihrer Bytes in einen Memory‑Stream modelliert Eingaben ohne Dateinamen, beispielsweise einen Datenbankwert oder ein hochgeladenes Byte‑Array. Der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Konstruktor erhält nur den Stream.

```python
import io
import aspose.slides as slides

with open("sample.pps", "rb") as input_file:
    data = input_file.read()

with io.BytesIO(data) as stream:
    with slides.Presentation(stream) as presentation:
        print(f"Source format: {presentation.source_format.name}")
```

PPT, PPS und POT verwenden dasselbe zugrunde liegende Binärformat. Beim Laden über einen Dateipfad kann die Erweiterung helfen, zwischen Diashow und Vorlage zu unterscheiden. Ohne Dateinamen kann alter PPS‑ und POT‑Inhalt als `SourceFormat.PPT` gemeldet werden; das oben gezeigte PPS‑Beispiel meldet `PPT`.

Muss Ihre Anwendung diese Unterscheidung wahren, speichern Sie den ursprünglichen Dateinamen oder Subtyp‑Metadaten separat. Eine Erweiterung ist ein nützlicher Hinweis für diese alten Subtypen, sollte aber nicht die einzige Grundlage zur Identifizierung beliebiger Präsentationsinhalte sein.

## **Erkennung vor und nach dem Laden vergleichen**

Verwenden Sie [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentationfactory/get_presentation_info/) und [PresentationInfo.load_format](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentationinfo/load_format/), wenn Sie eine Datei prüfen müssen, bevor ihr vollständiges Präsentations‑Objektmodell geladen wird. Verwenden Sie [Presentation.source_format](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/source_format/), wenn die Instanz bereits existiert.

Dieses Beispiel erfordert `sample.pptx` und gibt `PPTX` für beide Prüfungen aus. In der Produktion wählen Sie die zum Verarbeitungsstadium passende API; eine bereits geladene Präsentation benötigt keine zweite Inspektion ausschließlich zum Ermitteln ihres Quellformats.

```python
import aspose.slides as slides

path = "sample.pptx"
information = slides.PresentationFactory.instance.get_presentation_info(path)
print(f"Before loading: {information.load_format.name}")

with slides.Presentation(path) as presentation:
    print(f"After loading: {presentation.source_format.name}")
```

Die Ergebnisse haben unterschiedliche Aufzählungstypen: [LoadFormat](https://reference.aspose.com/slides/de/python-net/aspose.slides/loadformat/) und [SourceFormat](https://reference.aspose.com/slides/de/python-net/aspose.slides/sourceformat/). Vergleichen Sie sie nicht, indem Sie ihre numerischen Werte casten, und gehen Sie nicht davon aus, dass jedes Format identische Erkennungsergebnisse liefert. Im im Folgenden beschriebenen Speichern‑und‑Wiederöffnen‑Check wurde PowerPoint XML vor dem Laden als `LoadFormat.UNKNOWN` und nach dem Laden als `SourceFormat.XML` gemeldet.

## **Quell‑ und Ausgabformate getrennt halten**

Dieses Beispiel erfordert `sample.pptx` und schreibt `converted.odp`. Es gibt sowohl vor als auch nach dem Speichern der ursprünglichen Instanz `PPTX` aus. Nur die neue Instanz, die aus der ODP‑Ausgabe geladen wird, meldet `ODP`.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    print(f"Before saving: {presentation.source_format.name}")

    presentation.save("converted.odp", slides.export.SaveFormat.ODP)
    print(f"After saving: {presentation.source_format.name}")

with slides.Presentation("converted.odp") as reopened:
    print(f"Reopened output: {reopened.source_format.name}")
```

Eine von Grund auf mit `slides.Presentation()` erstellte Präsentation meldet `SourceFormat.PPTX`. Sie hat keine Eingabedatei: Dies ist der Standardwert für eine neu erstellte Instanz, kein Hinweis darauf, dass eine PPTX‑Datei geladen wurde. Verfolgen Sie, ob Ihre Anwendung die Instanz erstellt oder geladen hat, falls diese Unterscheidung relevant ist.

## **Ein Quellformat einer Erweiterung zuordnen**

Das folgende Beispiel erfordert `sample.pptx`. Es ordnet jedem derzeit unterstützten [SourceFormat](https://reference.aspose.com/slides/de/python-net/aspose.slides/sourceformat/) Wert eine konventionelle Erweiterung zu, ohne den Eingabedateinamen zu analysieren. Der Fallback verhindert, dass stillschweigend einer nicht erkannten Variante eine Erweiterung zugewiesen wird.

```python
import aspose.slides as slides

extensions = {
    slides.SourceFormat.PPT: ".ppt",
    slides.SourceFormat.PPTX: ".pptx",
    slides.SourceFormat.PPTM: ".pptm",
    slides.SourceFormat.PPS: ".pps",
    slides.SourceFormat.PPSX: ".ppsx",
    slides.SourceFormat.PPSM: ".ppsm",
    slides.SourceFormat.POT: ".pot",
    slides.SourceFormat.POTX: ".potx",
    slides.SourceFormat.POTM: ".potm",
    slides.SourceFormat.ODP: ".odp",
    slides.SourceFormat.OTP: ".otp",
    slides.SourceFormat.FODP: ".fodp",
    slides.SourceFormat.XML: ".xml",
}

with slides.Presentation("sample.pptx") as presentation:
    extension = extensions.get(presentation.source_format)
    print(extension if extension is not None else "No extension mapping is available.")
```

Diese Zuordnung konvertiert keine Datei und stellt keinen alten PPS/POT‑Subtyp wieder her, der beim Laden aus einem Stream verloren ging. Zum eigentlichen Speichern wählen Sie explizit einen [SaveFormat](https://reference.aspose.com/slides/de/python-net/aspose.slides.export/saveformat/) oder verwenden die in [Save Presentations in Their Original Format](/slides/de/python-net/save-presentation/#save-presentations-in-their-original-format) gezeigte Umwandlung.

## **Formate durch Speichern und erneutes Öffnen überprüfen**

Dieses eigenständige Beispiel erstellt eine Präsentation und schreibt drei Dateien im Arbeitsverzeichnis, wobei Dateien mit denselben Namen überschrieben werden. Es öffnet jede Ausgabe sowohl über den Pfad als auch über einen Memory‑Stream erneut. Für PPTX und ODP berichten beide Wege das gespeicherte Format. Für PPS meldet das Laden über den Pfad `PPS`, während das Laden derselben Bytes ohne Dateinamen `PPT` meldet.

```python
import io
import aspose.slides as slides

formats = [slides.export.SaveFormat.PPTX, slides.export.SaveFormat.ODP, slides.export.SaveFormat.PPS]

with slides.Presentation() as presentation:
    for output_format in formats:
        path = f"roundtrip.{output_format.name.lower()}"
        presentation.save(path, output_format)

        with open(path, "rb") as input_file:
            data = input_file.read()

        with slides.Presentation(path) as from_file:
            with io.BytesIO(data) as stream:
                with slides.Presentation(stream) as from_stream:
                    print(f"{output_format.name}: file={from_file.source_format.name}, stream={from_stream.source_format.name}")
```

Der gleiche Check mit allen oben aufgeführten Formaten ergab folgende Ergebnisse für generierte Präsentationen mit passenden Erweiterungen:

| Gespeichertes Format | SourceFormat aus einem Dateipfad | SourceFormat aus einem namenlosen Stream |
| --- | --- | --- |
| PPT | `PPT` | `PPT` |
| PPTX, PPTM | `PPTX`, `PPTM` respectively | Same as file path |
| PPS | `PPS` | `PPT` |
| PPSX, PPSM | `PPSX`, `PPSM` respectively | Same as file path |
| POT | `POT` | `PPT` |
| POTX, POTM | `POTX`, `POTM` respectively | Same as file path |
| ODP, OTP | `ODP`, `OTP` respectively | Same as file path |
| FODP | `FODP` | `FODP` |
| PowerPoint XML | `XML` | `XML` |

In diesen Checks war die einzige Normalisierung des Quellformats PPS/POT zu `PPT` für namenlose Streams. Die Tabelle beschreibt die Formatidentifikation, nicht die Erhaltung aller Präsentations‑Features während einer Konvertierung.

## **FAQ**

**Ändert das Speichern in ODP das Quellformat einer aus PPTX geladenen Präsentation?**

Nein. Die bestehende Instanz meldet weiterhin `PPTX`. Eine aus der gespeicherten ODP‑Datei geladene Instanz meldet `ODP`.

**Kann ein Stream stets eine alte Präsentation, Diashow und Vorlage unterscheiden?**

Nein. PPT, PPS und POT teilen das Binärformat. Bewahren Sie Dateinamen oder Subtyp‑Metadaten separat, wenn diese Unterscheidung erforderlich ist.

**Welche API sollte ich verwenden, wenn die Präsentation bereits geladen ist?**

Lesen Sie [Presentation.source_format](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/source_format/). Verwenden Sie [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentationfactory/get_presentation_info/) für Inspektionen vor dem Laden.