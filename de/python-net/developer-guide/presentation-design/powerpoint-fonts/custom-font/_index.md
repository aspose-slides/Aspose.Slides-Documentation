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
description: "Betten Sie benutzerdefinierte Schriftarten in PowerPoint‑Folien mit Aspose.Slides für Python über .NET ein, um Ihre Präsentationen auf allen Geräten scharf und konsistent zu halten."
---
## **Überblick**

Aspose.Slides für Python ermöglicht es Ihnen, zur Laufzeit benutzerdefinierte Schriftarten bereitzustellen, sodass Präsentationen korrekt dargestellt werden, selbst wenn die erforderlichen Schriftarten nicht auf dem Hostsystem installiert sind. Beim Export in PDF oder Bilder können Sie Schriftartenordner oder Schriftartdaten im Speicher angeben, um das Textlayout, die Glyphenmetriken und die Typografie beizubehalten. Dadurch wird das serverseitige Rendern in verschiedenen Umgebungen vorhersehbar, OS‑abhängige Schriftartenabhängigkeiten werden entfernt und unerwünschte Fallbacks oder Textumlagerungen vermieden. Der Artikel zeigt, wie Schriftquellen registriert werden.

Ein Präsentationsthema kann unterschiedliche Schriftfamilien für einzelne Schriftsysteme referenzieren. Diese Zuordnungen speichern Schriftartnamen, installieren oder laden die Schriftdateien jedoch nicht. Siehe [Skript‑spezifische Theme‑Schriften](/slides/de/python-net/script-specific-font-mappings/), um die Zuordnungen zu verwalten, und verwenden Sie die unten aufgeführten Lademöglichkeiten, um die referenzierten Schriftarten für ein konsistentes Rendering verfügbar zu machen.

Aspose.Slides lässt Sie die folgenden Schriftarten mit den Methoden `load_external_font` und `load_external_fonts` der [FontsLoader](https://reference.aspose.com/slides/de/python-net/aspose.slides/fontsloader/)-Klasse laden:

- TrueType (.ttf)- und TrueType Collection (.ttc)-Schriften. Siehe [TrueType](https://en.wikipedia.org/wiki/TrueType).
- OpenType (.otf)-Schriften. Siehe [OpenType](https://en.wikipedia.org/wiki/OpenType).

## **Benutzerdefinierte Schriftarten laden**

Aspose.Slides ermöglicht das Laden von in einer Präsentation verwendeten Schriftarten, ohne sie im System zu installieren. Dies wirkt sich auf die Exportausgabe aus – z. B. PDF, Bilder und andere unterstützte Formate – so dass die erzeugten Dokumente in allen Umgebungen einheitlich aussehen. Schriftarten werden aus benutzerdefinierten Verzeichnissen geladen.

1. Geben Sie einen oder mehrere Ordner an, die die Schriftdateien enthalten.
2. Rufen Sie die statische [FontsLoader.load_external_fonts](https://reference.aspose.com/slides/de/python-net/aspose.slides/fontsloader/load_external_fonts/)-Methode auf, um die Schriftarten aus diesen Ordnern zu laden.
3. Laden und rendern/exportieren Sie die Präsentation.
4. Rufen Sie [FontsLoader.clear_cache](https://reference.aspose.com/slides/de/python-net/aspose.slides/fontsloader/clear_cache/) auf, um den Schriftarten‑Cache zu leeren.

Das folgende Codebeispiel demonstriert den Schriftarten‑Ladevorgang:

```py
import aspose.slides as slides

# Definieren Sie Ordner, die benutzerdefinierte Schriftartdateien enthalten.
font_folders = ["fonts", "external_fonts"]

# Laden Sie benutzerdefinierte Schriftarten aus den angegebenen Ordnern.
slides.FontsLoader.load_external_fonts(font_folders)

with slides.Presentation("sample.pptx") as presentation:
    # Rendern/Exportieren Sie die Präsentation (z. B. nach PDF, Bildern oder anderen Formaten) unter Verwendung der geladenen Schriftarten.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF)

# Leeren Sie den Schriftarten-Cache, nachdem die Arbeit abgeschlossen ist.
slides.FontsLoader.clear_cache()
```

{{% alert color="info" title="Hinweis" %}}
[FontsLoader.load_external_fonts](https://reference.aspose.com/slides/de/python-net/aspose.slides/fontsloader/load_external_fonts/) fügt zusätzliche Ordner zu den Schriftarten‑Suchpfaden hinzu, ändert jedoch nicht die Reihenfolge der Schriftarten‑Initialisierung.  
Schriftarten werden in dieser Reihenfolge initialisiert:

1. Der standardmäßige Betriebssystem‑Schriftpfad.  
2. Die über [FontsLoader](https://reference.aspose.com/slides/de/python-net/aspose.slides/fontsloader/)-Methoden geladenen Pfade.  
{{%/alert %}}

## **Den Ordner für benutzerdefinierte Schriftarten abrufen**

Aspose.Slides stellt die Methode `get_font_folders` bereit, um Schriftarten‑Ordner abzurufen. Sie liefert sowohl die über `load_external_fonts` hinzugefügten Ordner als auch die System‑Schriftordner.

Dieses Python‑Beispiel zeigt, wie `get_font_folders` verwendet wird:

```python
import aspose.slides as slides

# Dieser Aufruf gibt die Ordner zurück, die auf Schriftdateien überprüft werden.
# Diese beinhalten Ordner, die über die load_external_fonts-Methode hinzugefügt wurden, sowie die System-Schriftordner.
font_folders = slides.FontsLoader.get_font_folders()
```

## **Benutzerdefinierte Schriftarten für eine Präsentation angeben**

Aspose.Slides bietet die Eigenschaft `document_level_font_sources`, mit der externe Schriftarten für eine Präsentation angegeben werden können.

Das folgende Python‑Beispiel zeigt die Verwendung von `document_level_font_sources`:

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
    # Arbeiten Sie mit der Präsentation.
    # CustomFont1, CustomFont2 und Schriftarten aus den Ordnern assets\fonts und global\fonts (einschließlich ihrer Unterordner) stehen der Präsentation zur Verfügung.
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
        # Externe Schriftarten sind für die Lebensdauer dieser Präsentationsinstanz verfügbar.
        print("processing")
finally:
    slides.FontsLoader.clear_cache()
```

## **FAQ**

### Beeinflussen benutzerdefinierte Schriftarten den Export in alle Formate (PDF, PNG, SVG, HTML)?

Ja. Verbundene Schriftarten werden vom Renderer für alle Exportformate verwendet.

### Werden benutzerdefinierte Schriftarten automatisch in die resultierende PPTX eingebettet?

Nein. Das Registrieren einer Schriftart für das Rendering ist nicht dasselbe wie das Einbetten in eine PPTX. Wenn die Schriftart in der Präsentationsdatei enthalten sein soll, müssen Sie die expliziten [Einbettungs‑Features](/slides/de/python-net/embedded-font/) nutzen.

### Kann ich das Fallback‑Verhalten steuern, wenn einer benutzerdefinierten Schriftart bestimmte Glyphen fehlen?

Ja. Konfigurieren Sie die [Schriftart‑Substitution](/slides/de/python-net/font-substitution/), [Ersetzungsregeln](/slides/de/python-net/font-replacement/) und [Fallback‑Sätze](/slides/de/python-net/fallback-font/), um genau festzulegen, welche Schriftart verwendet wird, wenn die gewünschte Glyphe fehlt.

### Kann ich Schriftarten in Linux/Docker‑Containern verwenden, ohne sie systemweit zu installieren?

Ja. Verweisen Sie auf eigene Schriftarten‑Ordner oder laden Sie Schriftarten aus Byte‑Arrays. Dadurch wird jede Abhängigkeit von System‑Schriftordnern im Container‑Image eliminiert.

### Wie sieht es mit Lizenzierung aus – kann ich jede benutzerdefinierte Schriftart ohne Einschränkungen einbetten?

Sie sind für die Einhaltung der Schriftart‑Lizenz verantwortlich. Die Bedingungen variieren; einige Lizenzen verbieten das Einbetten oder die kommerzielle Nutzung. Überprüfen Sie stets die EULA der Schriftart, bevor Sie Ausgaben verbreiten.