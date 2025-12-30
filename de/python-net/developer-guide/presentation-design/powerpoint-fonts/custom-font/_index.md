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
description: "Binden Sie benutzerdefinierte Schriftarten in PowerPoint-Folien mit Aspose.Slides für Python über .NET ein, um Ihre Präsentationen auf jedem Gerät scharf und konsistent zu halten."
---

## **Übersicht**

Aspose.Slides für Python ermöglicht es, benutzerdefinierte Schriftarten zur Laufzeit bereitzustellen, sodass Präsentationen korrekt gerendert werden, selbst wenn die erforderlichen Schriftarten nicht auf dem Hostsystem installiert sind. Beim Export in PDF oder Bilder können Sie Schriftartenordner oder im Speicher befindliche Schriftartdaten bereitstellen, um das Textlayout, die Glyphenmetriken und die Typografie beizubehalten. Dadurch wird das serverseitige Rendering in verschiedenen Umgebungen vorhersehbar, OS‑bezogene Schriftartabhängigkeiten werden entfernt und unerwünschte Fallbacks oder Layout‑Neuberechnungen verhindert. Der Artikel zeigt, wie Schriftquellen registriert werden.

Aspose.Slides ermöglicht das Laden der folgenden Schriftarten über die Methoden `load_external_font` und `load_external_fonts` der Klasse [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/):

- TrueType‑Schriftarten (.ttf) und TrueType‑Sammlungen (.ttc). Siehe [TrueType](https://en.wikipedia.org/wiki/TrueType).
- OpenType‑Schriftarten (.otf). Siehe [OpenType](https://en.wikipedia.org/wiki/OpenType).

## **Benutzerdefinierte Schriftarten laden**

Aspose.Slides ermöglicht das Laden von in einer Präsentation verwendeten Schriftarten, ohne sie auf dem System zu installieren. Dies wirkt sich auf die Exportausgabe aus – beispielsweise PDF, Bilder und andere unterstützte Formate – sodass die resultierenden Dokumente in verschiedenen Umgebungen konsistent aussehen. Schriftarten werden aus benutzerdefinierten Verzeichnissen geladen.

1. Geben Sie einen oder mehrere Ordner an, die die Schriftdateien enthalten.
2. Rufen Sie die statische Methode [FontsLoader.load_external_fonts](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/load_external_fonts/) auf, um Schriftarten aus diesen Ordnern zu laden.
3. Laden und rendern/exportieren Sie die Präsentation.
4. Rufen Sie [FontsLoader.clear_cache](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/clear_cache/) auf, um den Schriftart-Cache zu leeren.

Das folgende Codebeispiel demonstriert den Schriftarten‑Ladevorgang:
```py
import aspose.slides as slides

# Ordner definieren, die benutzerdefinierte Schriftdateien enthalten.
font_folders = [ external_font_folder1, external_font_folder2 ]

# Benutzerdefinierte Schriften aus den angegebenen Ordnern laden.
slides.FontsLoader.load_external_fonts(font_folders)

with slides.Presentation("sample.pptx") as presentation:
    # Die Präsentation rendern/exportieren (z. B. als PDF, Bilder oder andere Formate) mit den geladenen Schriften.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF)

# Den Schriftart-Cache leeren, nachdem die Arbeit abgeschlossen ist.
slides.FontsLoader.clear_cache()
```


{{% alert color="info" title="Note" %}}
[FontsLoader.load_external_fonts](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/load_external_fonts/) fügt zusätzliche Ordner zu den Schriftart‑Suchpfaden hinzu, ändert jedoch nicht die Initialisierungsreihenfolge der Schriftarten.
Schriftarten werden in folgender Reihenfolge initialisiert:

1. Der standardmäßige Schriftartpfad des Betriebssystems.
1. Die über [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/) geladenen Pfade.
{{%/alert %}}

## **Den benutzerdefinierten Schriftarten‑Ordner abrufen**

Aspose.Slides stellt die Methode `get_font_folders` bereit, um Schriftordner abzurufen. Sie gibt sowohl die über `load_external_fonts` hinzugefügten Ordner als auch die System‑Schriftordner zurück.

Dieser Python‑Code zeigt, wie `get_font_folders` verwendet wird:
```python
import aspose.slides as slides

# Dieser Aufruf gibt die Ordner zurück, die auf Schriftdateien geprüft werden.
# Dazu gehören Ordner, die über die Methode load_external_fonts hinzugefügt wurden, sowie die System-Schriftordner.
font_folders = slides.FontsLoader.get_font_folders()
```


## **Benutzerdefinierte Schriftarten für eine Präsentation angeben**

Aspose.Slides stellt die Eigenschaft `document_level_font_sources` bereit, mit der Sie externe Schriftarten für eine Präsentation festlegen können.

Das folgende Python‑Beispiel zeigt, wie `document_level_font_sources` verwendet wird:
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
    # Arbeiten mit der Präsentation.
    # CustomFont1, CustomFont2 und Schriftarten aus den Ordnern assets\fonts und global\fonts (und deren Unterordner) stehen der Präsentation zur Verfügung.
    # ...
    print(len(presentation.slides))
```


## **Externe Schriftarten aus Binärdaten laden**

Aspose.Slides stellt die Methode `load_external_font` bereit, um externe Schriftarten aus Binärdaten zu laden.

Das folgende Python‑Beispiel demonstriert das Laden einer Schriftart aus einem Byte‑Array:
```python
import aspose.slides as slides

def read_all_bytes(file_path):
    with open(file_path, "rb") as file_stream:
        file_data = file_stream.read()
    return file_data

# Externe Schriftarten aus Byte-Arrays laden.
slides.FontsLoader.load_external_font(read_all_bytes("ARIALN.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNBI.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNI.TTF"))

try:
    with slides.Presentation() as presentation:
        # Externe Schriftarten stehen für die Lebensdauer dieser Präsentationsinstanz zur Verfügung.
        print("processing")
finally:
    slides.FontsLoader.clear_cache()
```


## **FAQ**

**Beeinflussen benutzerdefinierte Schriftarten den Export in alle Formate (PDF, PNG, SVG, HTML)?**

Ja. Verbundene Schriftarten werden vom Renderer in allen Exportformaten verwendet.

**Werden benutzerdefinierte Schriftarten automatisch in die resultierende PPTX eingebettet?**

Nein. Das Registrieren einer Schriftart für das Rendering ist nicht dasselbe wie das Einbetten in eine PPTX. Wenn die Schriftart in der Präsentationsdatei enthalten sein soll, müssen Sie die expliziten [Embedding‑Funktionen](/slides/de/python-net/embedded-font/) verwenden.

**Kann ich das Fallback‑Verhalten steuern, wenn einer benutzerdefinierten Schriftart bestimmte Glyphen fehlen?**

Ja. Konfigurieren Sie [Schriftart‑Substitution](/slides/de/python-net/font-substitution/), [Ersetzungsregeln](/slides/de/python-net/font-replacement/) und [Fallback‑Sätze](/slides/de/python-net/fallback-font/), um genau festzulegen, welche Schriftart verwendet wird, wenn die angeforderte Glyphe fehlt.

**Kann ich Schriftarten in Linux/Docker‑Containern verwenden, ohne sie systemweit zu installieren?**

Ja. Verweisen Sie auf eigene Schriftartenordner oder laden Sie Schriftarten aus Byte‑Arrays. Dadurch entfällt jede Abhängigkeit von System‑Schriftverzeichnissen im Container‑Image.

**Wie sieht es mit Lizenzen aus – kann ich beliebige benutzerdefinierte Schriftarten ohne Einschränkungen einbetten?**

Sie sind für die Einhaltung der Schriftlizenz verantwortlich. Die Bedingungen variieren; einige Lizenzen untersagen das Einbetten oder die kommerzielle Nutzung. Überprüfen Sie stets die EULA der Schriftart, bevor Sie Ausgaben verbreiten.