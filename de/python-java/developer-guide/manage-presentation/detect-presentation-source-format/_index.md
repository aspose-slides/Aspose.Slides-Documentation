---
title: Ermitteln des Originalpräsentationsformats in Python via Java
linktitle: Quellformat
type: docs
weight: 35
url: /de/python-java/detect-presentation-source-format/
keywords:
- Quellformat
- Präsentationsformat erkennen
- PowerPoint
- OpenDocument
- Präsentation
- PPT
- PPTX
- Python
- Java
- Aspose.Slides
description: "Lesen Sie das urspruengliche Format einer geladenen Praesentation in Python via Java mit Aspose.Slides fuer Python via Java, vergleichen Sie Erkennungs-APIs und verarbeiten Sie Dateien, Streams und Legacy-Formate."
---
## **Übersicht**

Nach dem Laden einer Präsentation rufen Sie die [Presentation.getSourceFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getSourceFormat) Methode auf, um ihr ursprüngliches Format zu bestimmen. Verwenden Sie sie, wenn die nachfolgende Verarbeitung vom Format abhängt, aus dem die aktuelle Instanz geladen wurde.

Das Quellformat unterscheidet sich vom für eine Ausgabedatei gewählten [SaveFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/saveformat/). Das Speichern in ein anderes Format ändert nicht das Quellformat der vorhandenen Instanz.

Die Beispiele benötigen Aspose.Slides für Python via Java und eine kompatible Java‑Laufzeit. Jedes Beispiel startet die JVM, falls sie nicht bereits läuft.

## **Lesen des Quellformats einer Datei**

Dieses Beispiel erfordert eine vorhandene `sample.pptx` Datei. Es lädt die Datei und wählt eine Anwendungs‑Verarbeitungspolicy mit [Presentation.getSourceFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getSourceFormat), anstatt den Dateinamen zu verwenden. Ändern Sie den Eingabepfad, um andere Formate zu testen. Das Beispiel gibt die ausgewählte Policy aus; ersetzen Sie die Meldungen durch Ihre Anwendung‑Logik.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SourceFormat

presentation = Presentation("sample.pptx")
try:
    source_format = presentation.getSourceFormat()
    if source_format in (SourceFormat.Ppt, SourceFormat.Pps, SourceFormat.Pot):
        print("Use the legacy PowerPoint processing policy.")
    elif source_format == SourceFormat.Pptx:
        print("Use the standard PPTX processing policy.")
    else:
        print(f"Use the general policy for source format {source_format}.")
finally:
    presentation.dispose()
```

## **Erkennen der unterstützten Werte**

Die [SourceFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/sourceformat/) Klasse definiert Ganzzahlkonstanten, die die folgenden Präsentationsformate unterscheiden. Die untenstehenden Erweiterungen sind konventionelle Erweiterungen, keine Rekonstruktion des ursprünglichen Dateinamens.

| SourceFormat‑Wert | Erweiterung | Format |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint 97–2003‑Präsentation |
| `Pptx` | `.pptx` | Office Open XML‑Präsentation |
| `Pptm` | `.pptm` | Makro‑aktivierte Office Open XML‑Präsentation |
| `Pps` | `.pps` | PowerPoint 97–2003‑Bildschirmpräsentation |
| `Ppsx` | `.ppsx` | Office Open XML‑Bildschirmpräsentation |
| `Ppsm` | `.ppsm` | Makro‑aktivierte Office Open XML‑Bildschirmpräsentation |
| `Pot` | `.pot` | PowerPoint 97–2003‑Vorlage |
| `Potx` | `.potx` | Office Open XML‑Vorlage |
| `Potm` | `.potm` | Makro‑aktivierte Office Open XML‑Vorlage |
| `Odp` | `.odp` | OpenDocument‑Präsentation |
| `Otp` | `.otp` | OpenDocument‑Vorlage für Präsentationen |
| `Fodp` | `.fodp` | Flat XML ODF‑Präsentation |
| `Xml` | `.xml` | PowerPoint XML‑Präsentation |

## **Lesen des Quellformats aus einem Stream**

Dieses Beispiel erfordert eine vorhandene `sample.pps` Datei. Das Lesen ihrer Bytes in einen Speicher‑Stream modelliert Eingaben, die ohne Dateinamen empfangen werden, z. B. ein Datenbankwert oder ein hochgeladenes Byte‑Array. Der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/) Konstruktor erhält nur den Stream. Python liest die Dateibytes, und JPype konvertiert sie in ein Java‑Byte‑Array für den Java‑Speicher‑Stream.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation

try:
    data = Path("sample.pps").read_bytes()
    java_bytes = jpype.JArray(jpype.JByte)(data)
    stream = jpype.JClass("java.io.ByteArrayInputStream")(java_bytes)
    try:
        presentation = Presentation(stream)
        try:
            print(f"Source format: {presentation.getSourceFormat()}")
        finally:
            presentation.dispose()
    finally:
        stream.close()
except OSError as exception:
    print(f"Cannot read the presentation: {exception}")
```

PPT, PPS und POT verwenden dasselbe zugrundeliegende Binärformat. Beim Laden über einen Dateipfad kann die Erweiterung helfen, eine Bildschirmpräsentation oder Vorlage zu unterscheiden. Ohne Dateinamen kann alter PPS‑ und POT‑Inhalt als `SourceFormat.Ppt` gemeldet werden; das obige PPS‑Beispiel gibt den ganzzahligen Wert von `SourceFormat.Ppt` aus.

Wenn Ihre Anwendung die Unterscheidung bewahren muss, behalten Sie den ursprünglichen Dateinamen oder Subtyp‑Metadaten separat. Eine Erweiterung ist ein nützlicher Hinweis für diese alten Subtypen, sollte aber nicht die einzige Grundlage für die Identifizierung beliebiger Präsentationsinhalte sein.

## **Vergleich der Erkennung vor und nach dem Laden**

Verwenden Sie [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentationfactory/#getPresentationInfo) und [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentationinfo/#getLoadFormat), wenn Sie eine Datei prüfen müssen, bevor Sie ihr komplettes Präsentations‑Objektmodell laden. Verwenden Sie [Presentation.getSourceFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getSourceFormat), wenn die Instanz bereits existiert.

Dieses Beispiel erfordert `sample.pptx` und gibt die ganzzahligen Werte von `LoadFormat.Pptx` bzw. `SourceFormat.Pptx` aus. In der Produktion wählen Sie die für Ihre Verarbeitungsstufe geeignete API; eine bereits geladene Präsentation benötigt keine zweite Inspektion allein zum Erhalt ihres Quellformats.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PresentationFactory

path = "sample.pptx"
information = PresentationFactory.getInstance().getPresentationInfo(path)
print(f"Before loading: {information.getLoadFormat()}")

presentation = Presentation(path)
try:
    print(f"After loading: {presentation.getSourceFormat()}")
finally:
    presentation.dispose()
```

Die Ergebnisse verwenden Konstanten aus unterschiedlichen Klassen: [LoadFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/loadformat/) und [SourceFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/sourceformat/). Vergleichen Sie deren numerische Werte nicht und gehen Sie nicht davon aus, dass jedes Format identische Erkennungsergebnisse liefert. PowerPoint XML kann vor dem Laden als `LoadFormat.Unknown` gemeldet werden und nach dem Laden als `SourceFormat.Xml`.

## **Quell‑ und Ausgabformate getrennt halten**

Dieses Beispiel erfordert `sample.pptx` und schreibt `converted.odp`. Es gibt den ganzzahligen Wert von `SourceFormat.Pptx` sowohl vor als auch nach dem Speichern der ursprünglichen Instanz aus. Nur die neue Instanz, die aus der ODP‑Ausgabe geladen wird, meldet `Odp`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    print(f"Before saving: {presentation.getSourceFormat()}")

    presentation.save("converted.odp", SaveFormat.Odp)
    print(f"After saving: {presentation.getSourceFormat()}")

    reopened = Presentation("converted.odp")
    try:
        print(f"Reopened output: {reopened.getSourceFormat()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

Eine von Grund auf neu erstellte Präsentation mittels `Presentation()` meldet `SourceFormat.Pptx`. Sie hat keine Eingabedatei: Dies ist der Standardwert für eine neu erstellte Instanz, kein Hinweis darauf, dass eine PPTX‑Datei geladen wurde. Verfolgen Sie, ob Ihre Anwendung die Instanz erstellt oder geladen hat, falls diese Unterscheidung von Bedeutung ist.

## **Zuordnen eines Quellformats zu einer Erweiterung**

Das folgende Beispiel erfordert `sample.pptx`. Es ordnet jedem derzeit unterstützten [SourceFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/sourceformat/) Wert eine konventionelle Erweiterung zu, ohne den Eingabedateinamen zu analysieren. Die Rückfalloption verhindert, dass stillschweigend einer nicht erkannten Wert eine Erweiterung zugeordnet wird.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SourceFormat

extensions = {
    SourceFormat.Ppt: ".ppt",
    SourceFormat.Pptx: ".pptx",
    SourceFormat.Pptm: ".pptm",
    SourceFormat.Pps: ".pps",
    SourceFormat.Ppsx: ".ppsx",
    SourceFormat.Ppsm: ".ppsm",
    SourceFormat.Pot: ".pot",
    SourceFormat.Potx: ".potx",
    SourceFormat.Potm: ".potm",
    SourceFormat.Odp: ".odp",
    SourceFormat.Otp: ".otp",
    SourceFormat.Fodp: ".fodp",
    SourceFormat.Xml: ".xml",
}

presentation = Presentation("sample.pptx")
try:
    extension = extensions.get(presentation.getSourceFormat())
    print(extension if extension is not None else "No extension mapping is available.")
finally:
    presentation.dispose()
```

Diese Zuordnung konvertiert keine Datei und stellt keinen verlorenen alten PPS/POT‑Subtyp, der beim Stream‑Laden verloren ging, wieder her. Für das eigentliche Speichern wählen Sie explizit ein [SaveFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/saveformat/), oder nutzen Sie die in [Save Presentations in Their Original Format](/slides/de/python-java/save-presentation/#save-presentations-in-their-original-format) gezeigte Konvertierung.

## **Formate durch Speichern und erneutes Öffnen verifizieren**

Dieses eigenständige Beispiel erstellt eine Präsentation und schreibt drei Dateien im Arbeitsverzeichnis, überschreibt vorhandene Dateien mit denselben Namen. Es öffnet jede Ausgabe sowohl über den Pfad als auch über einen Speicher‑Stream erneut. Für PPTX und ODP melden beide Wege das gespeicherte Format. Für PPS meldet das Laden per Pfad `Pps`, während das Laden derselben Bytes ohne Dateinamen `Ppt` meldet.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    formats = [
        (SaveFormat.Pptx, "pptx"),
        (SaveFormat.Odp, "odp"),
        (SaveFormat.Pps, "pps"),
    ]

    for save_format, extension in formats:
        path = f"roundtrip.{extension}"
        presentation.save(path, save_format)

        from_file = Presentation(path)
        try:
            data = Path(path).read_bytes()
            java_bytes = jpype.JArray(jpype.JByte)(data)
            stream = jpype.JClass("java.io.ByteArrayInputStream")(java_bytes)
            try:
                from_stream = Presentation(stream)
                try:
                    print(f"{extension}: file={from_file.getSourceFormat()}, stream={from_stream.getSourceFormat()}")
                finally:
                    from_stream.dispose()
            finally:
                stream.close()
        finally:
            from_file.dispose()
except OSError as exception:
    print(f"Cannot read a saved presentation: {exception}")
finally:
    presentation.dispose()
```

| Gespeichertes Format | SourceFormat aus einem Dateipfad | SourceFormat aus einem namenlosen Stream |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` respectively | Wie beim Dateipfad |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` respectively | Wie beim Dateipfad |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` respectively | Wie beim Dateipfad |
| ODP, OTP | `Odp`, `Otp` respectively | Wie beim Dateipfad |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

PPS/POT‑Inhalte werden für namenlose Streams als `Ppt` identifiziert. Die Tabelle beschreibt die Formatidentifikation, nicht die Erhaltung aller Präsentations‑Features während der Konvertierung.

## **FAQ**

**Ändert das Speichern in ODP das Quellformat einer aus PPTX geladenen Präsentation?**

Nein. Die vorhandene Instanz meldet weiterhin `Pptx`. Eine aus der gespeicherten ODP‑Datei geladene Instanz meldet `Odp`.

**Kann ein Stream immer zwischen einer alten Präsentation, Bildschirmpräsentation und Vorlage unterscheiden?**

Nein. PPT, PPS und POT teilen das Binärformat. Bewahren Sie Dateinamen oder Subtyp‑Metadaten getrennt auf, wenn diese Unterscheidung erforderlich ist.

**Welche API soll ich verwenden, wenn die Präsentation bereits geladen ist?**

Verwenden Sie [Presentation.getSourceFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/#getSourceFormat). Nutzen Sie [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentationfactory/#getPresentationInfo) zur Inspektion vor dem Laden.