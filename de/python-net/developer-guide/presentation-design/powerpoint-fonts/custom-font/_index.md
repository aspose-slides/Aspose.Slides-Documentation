---
title: PowerPoint-Schriften in Python anpassen
linktitle: Benutzerdefinierte Schrift
type: docs
weight: 20
url: /de/python-net/custom-font/
keywords:
- Schrift
- benutzerdefinierte Schrift
- externe Schrift
- Schrift laden
- Schriften verwalten
- Schriftordner
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Binden Sie benutzerdefinierte Schriften in PowerPoint-Folien mit Aspose.Slides für Python über .NET ein, um Ihre Präsentationen auf jedem Gerät scharf und konsistent zu halten."
---

## **Übersicht**

Aspose.Slides for Python ermöglicht das Bereitstellen benutzerdefinierter Schriften zur Laufzeit, sodass Präsentationen korrekt gerendert werden, selbst wenn die benötigten Schriften nicht auf dem Hostsystem installiert sind. Beim Export in PDF oder Bilder können Sie Schriftordner oder im Speicher befindliche Schriftartdaten angeben, um das Textlayout, die Glyphenmetriken und die Typografie beizubehalten. Dadurch wird das serverseitige Rendering in verschiedenen Umgebungen vorhersehbar, OS‑abhängige Schriftabhängigkeiten entfallen und unerwünschte Fallbacks oder Neu­formatierungen werden verhindert. Der Artikel zeigt, wie Schriftquellen registriert werden.

Aspose.Slides lässt Sie die folgenden Schriften mit den Methoden `load_external_font` und `load_external_fonts` der Klasse [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/) laden:

- TrueType (.ttf)- und TrueType Collection (.ttc)-Schriften. Siehe [TrueType](https://en.wikipedia.org/wiki/TrueType).
- OpenType (.otf)-Schriften. Siehe [OpenType](https://en.wikipedia.org/wiki/OpenType).

## **Benutzerdefinierte Schriften laden**

Aspose.Slides ermöglicht das Laden von Schriften für das Rendern von Präsentationen, ohne sie zu installieren. Die Schriften werden aus einem benutzerdefinierten Verzeichnis geladen.

1. Rufen Sie die Methode `load_external_fonts` von [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/) auf.
2. Laden Sie die zu rendernde Präsentation.
3. Leeren Sie den Cache in der Klasse [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/).

Der folgende Python‑Code demonstriert den Schrift‑Ladevorgang:
```python
import aspose.slides as slides

# Ordner, in denen nach Schriften gesucht wird.
font_folders = [ "C:\\MyFonts", "D:\\MyAdditionalFonts" ]

# Schriften aus den benutzerdefinierten Verzeichnissen laden.
slides.FontsLoader.load_external_fonts(font_folders)

# Präsentation rendern.
with slides.Presentation("Fonts.pptx") as presentation:
    presentation.save("Fonts_out.pdf", slides.export.SaveFormat.PDF)

# Schrift-Cache leeren.
slides.FontsLoader.clear_cache()
```


## **Abrufen des Ordners für benutzerdefinierte Schriften**

Aspose.Slides stellt die Methode `get_font_folders` bereit, um Schriftordner abzurufen. Sie liefert sowohl die über `load_external_fonts` hinzugefügten Ordner als auch die System‑Schriftordner.

Dieser Python‑Code zeigt die Verwendung von `get_font_folders`:
```python
import aspose.slides as slides

# Dieser Aufruf gibt die Ordner zurück, die auf Schriftdateien geprüft werden.
# Diese beinhalten die über die Methode load_external_fonts hinzugefügten Ordner und die System-Schriftordner.
font_folders = slides.FontsLoader.get_font_folders()
```


## **Angeben benutzerdefinierter Schriften für eine Präsentation**

Aspose.Slides bietet die Eigenschaft `document_level_font_sources`, mit der Sie externe Schriften für eine Präsentation festlegen können.

Das folgende Python‑Beispiel zeigt die Nutzung von `document_level_font_sources`:
```python
import aspose.slides as slides

with open("CustomFont1.ttf", "br") as font1_stream:
    font1_data = font1_stream.read()
    
with open("CustomFont2.ttf", "br") as font2_stream:
    font2_data = font2_stream.read()

load_options = slides.LoadOptions()
load_options.document_level_font_sources.font_folders = ["assets\\fonts", "global\\fonts"] 
load_options.document_level_font_sources.memory_fonts = [font1_data, font2_data]

with slides.Presentation("Fonts.pptx", load_options) as presentation:
    # ...
    # Arbeit mit der Präsentation.
    # CustomFont1, CustomFont2 und Schriften aus den Ordnern assets\fonts und global\fonts (einschließlich ihrer Unterordner) stehen der Präsentation zur Verfügung.
    # ...
    print(len(presentation.slides))
```


## **Externe Schriften aus Binärdaten laden**

Aspose.Slides stellt die Methode `load_external_font` bereit, um externe Schriften aus Binärdaten zu laden.

Das folgende Python‑Beispiel demonstriert das Laden einer Schrift aus einem Byte‑Array:
```python
import aspose.slides as slides

def read_all_bytes(file_path):
    with open(file_path, "rb") as file_stream:
        file_data = file_stream.read()
    return file_data

# Externe Schriften aus Byte-Arrays laden.
slides.FontsLoader.load_external_font(read_all_bytes("ARIALN.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNBI.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNI.TTF"))

try:
    with slides.Presentation() as presentation:
        # Externe Schriften stehen für die Lebensdauer dieser Präsentationsinstanz zur Verfügung.
        print("processing")
finally:
    slides.FontsLoader.clear_cache()
```


## **FAQ**

**Beeinflussen benutzerdefinierte Schriften den Export in alle Formate (PDF, PNG, SVG, HTML)?**

Ja. Eingebundene Schriften werden vom Renderer in allen Exportformaten verwendet.

**Werden benutzerdefinierte Schriften automatisch in die resultierende PPTX eingebettet?**

Nein. Das Registrieren einer Schrift für das Rendering ist nicht dasselbe wie das Einbetten in eine PPTX. Wenn Sie die Schrift in der Präsentationsdatei verankern müssen, verwenden Sie die expliziten [embedding features](/slides/de/python-net/embedded-font/).

**Kann ich das Fallback-Verhalten steuern, wenn einer benutzerdefinierten Schrift bestimmte Glyphen fehlen?**

Ja. Konfigurieren Sie [font substitution](/slides/de/python-net/font-substitution/), [replacement rules](/slides/de/python-net/font-replacement/) und [fallback sets](/slides/de/python-net/fallback-font/), um genau festzulegen, welche Schrift verwendet wird, wenn die angeforderte Glyphe fehlt.

**Kann ich Schriften in Linux/Docker‑Containern verwenden, ohne sie systemweit zu installieren?**

Ja. Verweisen Sie auf eigene Schriftordner oder laden Sie Schriften aus Byte‑Arrays. Dadurch entfallen Abhängigkeiten von System‑Schriftverzeichnissen im Container‑Image.

**Wie steht es um die Lizenzierung – kann ich jede benutzerdefinierte Schrift ohne Einschränkungen einbetten?**

Sie sind für die Einhaltung der Schrift‑Lizenzierung verantwortlich. Die Bedingungen variieren; einige Lizenzen verbieten das Einbetten oder die kommerzielle Nutzung. Prüfen Sie stets die EULA der jeweiligen Schrift, bevor Sie Ausgaben verbreiten.