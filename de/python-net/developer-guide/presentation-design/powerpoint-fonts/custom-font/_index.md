---
title: PowerPoint-Schriftarten in Python anpassen
linktitle: Benutzerdefinierte Schriftart
type: docs
weight: 20
url: /de/python-net/custom-font/
keywords:
- Schriftart
- benutzerdefinierte Schriftart
- externe Schriftart
- Schriftart laden
- Schriftarten verwalten
- Schriftartenordner
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Betten Sie benutzerdefinierte Schriftarten in PowerPoint-Folien mit Aspose.Slides for Python via .NET ein, um Ihre Präsentationen auf jedem Gerät gestochen scharf und konsistent zu halten."
---

{{% alert color="primary" %}} 

Aspose Slides ermöglicht es Ihnen, diese Schriftarten mit der Methode `load_external_fonts` der [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/) Klasse zu laden:

* TrueType (.ttf) und TrueType Collection (.ttc) Schriftarten. Siehe [TrueType](https://de.wikipedia.org/wiki/TrueType).

* OpenType (.otf) Schriftarten. Siehe [OpenType](https://de.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Benutzerdefinierte Schriftarten laden**

Aspose.Slides ermöglicht es Ihnen, Schriftarten zu laden, die in Präsentationen gerendert werden, ohne dass diese Schriftarten installiert werden müssen. Die Schriftarten werden aus einem benutzerdefinierten Verzeichnis geladen. 

1. Erstellen Sie eine Instanz der [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/) Klasse und rufen Sie die Methode `load_external_fonts` auf.
2. Laden Sie die Präsentation, die gerendert werden soll.
3. Leeren Sie den Cache in der [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/) Klasse.

Dieser Python-Code zeigt den Prozess des Ladevorgangs von Schriftarten:

```python
import aspose.slides as slides

# Der Pfad zum Dokumentenverzeichnis.
dataDir = "C:\\"

# Verzeichnisse zur Suche nach Schriftarten
folders = [ dataDir ]

# Lädt die Schriftarten aus dem benutzerdefinierten Schriftartenverzeichnis
slides.FontsLoader.load_external_fonts(folders)

# Führen Sie einige Arbeiten aus und rendern Sie die Präsentation/Folie
with slides.Presentation(path + "DefaultFonts.pptx") as presentation:
    presentation.save("NewFonts_out.pptx", slides.export.SaveFormat.PPTX)

# Leert den Schriftarten-Cache
slides.FontsLoader.clear_cache()
```

## **Benutzerdefinierten Schriftartenordner abrufen**
Aspose.Slides bietet die Methode `get_font_folders()`, mit der Sie Schriftartenordner finden können. Diese Methode gibt Ordner zurück, die über die Methode `LoadExternalFonts` hinzugefügt wurden, sowie Systemschriftartenordner.

Dieser Python-Code zeigt Ihnen, wie Sie `get_font_folders()` verwenden:

```python
# Diese Zeile gibt die Ordner aus, die auf Schriftartdateien überprüft werden.
# Das sind Ordner, die über die Methode load_external_fonts hinzugefügt wurden und Systemschriftartenordner.
fontFolders = slides.FontsLoader.get_font_folders()

```


## **Benutzerdefinierte Schriftarten für Präsentationen angeben**
Aspose.Slides bietet die Eigenschaft `document_level_font_sources`, um externe Schriftarten anzugeben, die mit der Präsentation verwendet werden sollen.

Dieser Python-Code zeigt Ihnen, wie Sie die Eigenschaft `document_level_font_sources` verwenden:

```python
import aspose.slides as slides

with open(path + "CustomFont1.ttf", "br") as font1:
    memoryFont1 = font1.read()
    with open(path + "CustomFont2.ttf", "br") as font2:
        memoryFont2 = font2.read()

        loadOptions = slides.LoadOptions()
        loadOptions.document_level_font_sources.font_folders =  ["assets\\fonts", "global\\fonts"] 
        loadOptions.document_level_font_sources.memory_fonts = [ memoryFont1, memoryFont2 ]
        with slides.Presentation(path + "DefaultFonts.pptx", loadOptions) as presentation:
            # Arbeiten Sie mit der Präsentation
            # CustomFont1, CustomFont2 und Schriftarten aus den Ordnern assets\fonts & global\fonts und deren Unterordnern sind für die Präsentation verfügbar
            print(len(presentation.slides))
```

## **Schriftarten extern verwalten**

Aspose.Slides bietet die Methode `load_external_font`(data), um externe Schriftarten aus Binärdaten zu laden.

Dieser Python-Code demonstriert den Prozess des Ladevorgangs von Schriftarten aus Byte-Arrays:

```python
from aspose.slides import FontsLoader, Presentation

def read_all_bytes(path):
    with open(path, "rb") as in_file:
        bytes = in_file.read()
    return bytes

FontsLoader.load_external_font(read_all_bytes("ARIALN.TTF"))
FontsLoader.load_external_font(read_all_bytes("ARIALNBI.TTF"))
FontsLoader.load_external_font(read_all_bytes("ARIALNI.TTF"))

try:
    with Presentation() as pres:
        # Externe Schriftart während der Lebensdauer der Präsentation geladen
        print("Verarbeitung")
finally:
    FontsLoader.clear_cache()

```