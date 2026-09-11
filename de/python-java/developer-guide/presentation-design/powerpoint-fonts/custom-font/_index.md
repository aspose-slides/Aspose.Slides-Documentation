---
title: Anpassen von PowerPoint-Schriftarten in Python über Java
linktitle: Benutzerdefinierte Schriftart
type: docs
weight: 20
url: /de/python-java/custom-font/
keywords:
- Schriftart
- benutzerdefinierte Schriftart
- externe Schriftart
- Schriftart laden
- Schriftarten verwalten
- Schriftartenordner
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Passen Sie Schriftarten in PowerPoint-Folien mit Aspose.Slides für Python über Java an, um Ihre Präsentationen auf jedem Gerät scharf und konsistent zu halten."
---
## **Übersicht**

Aspose.Slides ermöglicht das Verwenden benutzerdefinierter Schriftarten in Präsentationen, ohne sie im Betriebssystem zu installieren. Sie können Schriftarten aus eigenen Ordnern laden, Schriftarten für eine bestimmte Präsentation über dokumentenbezogene Schriftquellen bereitstellen oder externe Schriftarten direkt aus Binärdaten laden.

Geladene Schriftarten werden verwendet, wenn eine Präsentation gerendert oder exportiert wird, beispielsweise zu PDF, Bildern und anderen unterstützten Formaten. Dies hilft, die Ausgabe der Präsentation in verschiedenen Umgebungen konsistent zu halten. Der Artikel erklärt zudem, wie Sie die von Aspose.Slides verwendeten Schriftordner inspizieren und wie Sie den Schriftart-Cache nach der Arbeit mit externen Schriftarten leeren können.

Die Registrierung benutzerdefinierter Schriftarten für das Rendering ist getrennt vom Einbetten von Schriftarten in eine PPTX‑Datei. Wenn eine Schriftart innerhalb der Präsentation selbst gespeichert werden muss, verwenden Sie die Einbettungs‑Features explizit.

Ein Präsentationsthema kann für einzelne Schriftsysteme verschiedene Schriftfamilien referenzieren. Diese Zuordnungen speichern Schriftartnamen, installieren oder laden jedoch nicht die Schriftdateien. Siehe [Script‑Specific Theme Fonts](/slides/de/python-java/script-specific-font-mappings/), um die Zuordnungen zu verwalten, und nutzen Sie die unten stehenden Ladeoptionen, um die referenzierten Schriftarten für ein konsistentes Rendering verfügbar zu machen.

{{% alert color="info" title="Hinweis" %}}

Aspose.Slides ermöglicht das Laden dieser Schriftarten mit der [loadExternalFonts](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontsloader/#loadExternalFonts)‑Methode:

* TrueType (.ttf) und TrueType Collection (.ttc) Schriftarten. Siehe [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) Schriftarten. Siehe [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Benutzerdefinierte Schriftarten laden**

Aspose.Slides ermöglicht das Laden von Schriftarten, die in einer Präsentation verwendet werden, ohne sie im System zu installieren. Dies wirkt sich auf die Exportausgabe – wie PDF, Bilder und andere unterstützte Formate – aus, sodass die resultierenden Dokumente in verschiedenen Umgebungen konsistent aussehen. Schriftarten werden aus benutzerdefinierten Verzeichnissen geladen.

1. Geben Sie einen oder mehrere Ordner an, die die Schriftdateien enthalten.
2. Rufen Sie die statische [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontsloader/#loadExternalFonts)‑Methode auf, um Schriftarten aus diesen Ordnern zu laden.
3. Laden und rendern/exportieren Sie die Präsentation.
4. Rufen Sie [FontsLoader.clearCache](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontsloader/#clearCache) auf, um den Schriftart‑Cache zu leeren.

Das folgende Codebeispiel demonstriert den Schriftarten‑Ladevorgang:

```python
from jpype import JArray, JString
from asposeslides.api import FontsLoader, Presentation, SaveFormat

# Ordner definieren, die benutzerdefinierte Schriftdateien enthalten.
font_folders = JArray(JString)(["assets/fonts", "global/fonts"])

# Benutzerdefinierte Schriftarten aus den angegebenen Ordnern laden.
FontsLoader.loadExternalFonts(font_folders)

presentation = None
try:
    presentation = Presentation("sample.pptx")

    # Präsentation mit den geladenen Schriftarten rendern/exportieren.
    presentation.save("output.pdf", SaveFormat.Pdf)
finally:
    if presentation is not None:
        presentation.dispose()

    # Schriftarten-Cache leeren, nachdem die Arbeit abgeschlossen ist.
    FontsLoader.clearCache()
```

{{% alert color="info" title="Hinweis" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontsloader/#loadExternalFonts) fügt zusätzliche Ordner zu den Schriftart‑Suchpfaden hinzu, ändert jedoch nicht die Reihenfolge der Schriftart‑Initialisierung.
Schriftarten werden in dieser Reihenfolge initialisiert:

1. Der standardmäßige Schriftartpfad des Betriebssystems.
1. Die über [FontsLoader](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontsloader/) geladenen Pfade.

{{%/alert %}}

## **Benutzerdefinierte Schriftartenordner abrufen**
Aspose.Slides stellt die [getFontFolders](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontsloader/#getFontFolders)‑Methode bereit, mit der Sie Schriftordner finden können. Diese Methode gibt Ordner zurück, die über die [loadExternalFonts](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontsloader/#loadExternalFonts)‑Methode hinzugefügt wurden, sowie System‑Schriftordner.

Dieser Python‑Code zeigt, wie Sie [getFontFolders](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontsloader/#getFontFolders) verwenden:

```python
from asposeslides.api import FontsLoader

# Ordner abrufen, die über loadExternalFonts hinzugefügt wurden, und System-Schriftordner.
font_folders = FontsLoader.getFontFolders()
```

## **Benutzerdefinierte Schriftarten für eine Präsentation festlegen**
Aspose.Slides bietet die [getDocumentLevelFontSources](https://reference.aspose.com/slides/de/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources)‑Methode, mit der Sie externe Schriftarten angeben können, die mit der Präsentation verwendet werden sollen.

Dieser Python‑Code zeigt, wie Sie die [getDocumentLevelFontSources](https://reference.aspose.com/slides/de/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources)‑Methode verwenden:

```python
from pathlib import Path
from jpype import JArray, JByte, JString
from asposeslides.api import LoadOptions, Presentation

memory_font_primary = Path("customfonts/CustomFont1.ttf").read_bytes()
memory_font_secondary = Path("customfonts/CustomFont2.ttf").read_bytes()

load_options = LoadOptions()
font_folders = JArray(JString)(["assets/fonts", "global/fonts"])
memory_fonts = JArray(JByte, 2)([memory_font_primary, memory_font_secondary])
load_options.getDocumentLevelFontSources().setFontFolders(font_folders)
load_options.getDocumentLevelFontSources().setMemoryFonts(memory_fonts)

presentation = Presentation("MyPresentation.pptx", load_options)
try:
    # Arbeiten mit der Präsentation.
    # CustomFont1, CustomFont2 und Schriftarten aus assets/fonts und global/fonts
    # und deren Unterordner stehen der Präsentation zur Verfügung.
    pass
finally:
    presentation.dispose()
```

## **Schriftarten extern verwalten**

Aspose.Slides stellt die [loadExternalFont](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontsloader/#loadExternalFont)‑Methode bereit, mit der Sie externe Schriftarten aus Binärdaten laden können.

Dieser Python‑Code demonstriert das Laden einer Schriftart aus einem Byte‑Array:

```python
from pathlib import Path
from jpype import JArray, JByte
from asposeslides.api import FontsLoader, Presentation

font_data = Path("ARIALN.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))
font_data = Path("ARIALNBI.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))
font_data = Path("ARIALNI.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))

try:
    presentation = Presentation()
    try:
        # Externe Schriftarten werden während der Lebensdauer der Präsentation geladen.
        pass
    finally:
        presentation.dispose()
finally:
    FontsLoader.clearCache()
```

## **FAQ**

**Beeinflussen benutzerdefinierte Schriftarten den Export in alle Formate (PDF, PNG, SVG, HTML)?**

Ja. Verbundene Schriftarten werden vom Renderer für alle Exportformate verwendet.

**Werden benutzerdefinierte Schriftarten automatisch in die resultierende PPTX eingebettet?**

Nein. Das Registrieren einer Schriftart für die Darstellung ist nicht dasselbe wie das Einbetten in eine PPTX. Wenn Sie die Schriftart in der Präsentationsdatei benötigen, müssen Sie die expliziten Einbettungs‑Features verwenden.

**Kann ich das Fallback‑Verhalten steuern, wenn einer benutzerdefinierten Schriftart bestimmte Glyphen fehlen?**

Ja. Konfigurieren Sie [font substitution](/slides/de/python-java/font-substitution/), [replacement rules](/slides/de/python-java/font-replacement/) und [fallback sets](/slides/de/python-java/fallback-font/), um genau festzulegen, welche Schriftart verwendet wird, wenn die angeforderte Glyphe fehlt.

**Kann ich Schriftarten in Linux/Docker‑Containern verwenden, ohne sie systemweit zu installieren?**

Ja. Verweisen Sie auf eigene Schriftartenordner oder laden Sie Schriftarten aus Byte‑Arrays. Dadurch entfällt jede Abhängigkeit von Systemschriftverzeichnissen im Container‑Image.

**Wie sieht es mit Lizenzierung aus – kann ich jede benutzerdefinierte Schriftart ohne Einschränkungen einbetten?**

Sie sind für die Einhaltung der Schriftlizenz verantwortlich. Die Bedingungen variieren; einige Lizenzen verbieten das Einbetten oder die kommerzielle Nutzung. Prüfen Sie immer die EULA der Schriftart, bevor Sie Ausgaben verbreiten.