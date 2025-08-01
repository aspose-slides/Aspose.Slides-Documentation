---
title: Installation
type: docs
weight: 70
url: /de/python-net/installation/
keywords:
- Aspose.Slides herunterladen
- Aspose.Slides installieren
- Aspose.Slides verwenden
- Aspose.Slides-Installation
- Windows
- macOS
- Python
description: "Erfahren Sie, wie Sie Aspose.Slides for Python via .NET schnell installieren. Schritt-für-Schritt-Anleitung, Systemanforderungen und Codebeispiele — starten Sie noch heute mit der Arbeit an PowerPoint-Präsentationen!"
---

Das Aspose.Slides-Paket für Python über .NET kommt mit den benötigten .NET-Bibliotheken, sodass eine separate .NET-Installation nicht erforderlich ist. Abhängig von Ihrer Plattform müssen Sie jedoch möglicherweise spezifische Abhängigkeiten für .NET installieren und bestimmte Anforderungen erfüllen.

## **Windows**

**Systemanforderungen**

Überprüfen Sie, ob die Spezifikationen Ihres Rechners die [Systemanforderungen](/slides/de/python-net/system-requirements/) erfüllen oder übertreffen.

### **Aspose.Slides installieren**

`pip` ist der einfachste Weg, [Aspose.Slides für Python über .NET](https://pypi.org/project/aspose.slides/) auf Windows-Geräten herunterzuladen und zu installieren.

Um Aspose.Slides zu installieren, führen Sie diesen Befehl aus:  `pip install aspose.slides`

**Aspose.Slides verwenden**

Testen Sie Ihre Aspose.Slides-Installation, indem Sie diesen Code ausführen, um eine PowerPoint-Präsentation zu erstellen:

```python
# Imports Aspose.Slides for Python via .NET module
import aspose.slides as slides

# Instantiates a Presentation object that represents a presentation file
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **macOS**

**Systemanforderungen**

Überprüfen Sie, ob die Spezifikationen Ihres Rechners die [Systemanforderungen](/slides/de/python-net/system-requirements/) erfüllen oder übertreffen.

### **Voraussetzungen**

**Python mit freigegebenen Bibliotheken**

Es gibt verschiedene Möglichkeiten, Python unter macOS zu installieren, aber wir empfehlen dringend, das [pyenv-Tool](https://github.com/pyenv/pyenv#homebrew-in-macos) zu verwenden.

Nachdem Sie pyenv installiert und konfiguriert haben, müssen Sie Python mit freigegebenen Bibliotheken installieren, indem Sie diese Befehle in der Terminal-App ausführen:

1. Python installieren: `env PYTHON_CONFIGURE_OPTS="--enable-shared" pyenv install --verbose 3.9.13`
2. Als globale Python-Installation konfigurieren: `pyenv global 3.9.13`
3. Als Shell-Python-Installation konfigurieren: `pyenv shell 3.9.13`
4. Erstellen Sie einen symbolischen Link für die libpython-Bibliothek in einem Systembibliotheksverzeichnis: `ln -s /Users/<username>/.pyenv/versions/3.9.13/lib/libpython3.9.dylib /usr/local/lib/libpython3.9.dylib` 

Hinweis: Python 3.5 und höher ist erforderlich. Python-Version 3.9.13 wurde einfach als Beispiel verwendet.

**Die libgdiplus-Bibliothek installieren**

Die libgdiplus-Bibliothek ist eine Windows GDI+-Implementierung für macOS und Linux, die .NET auf diesen Plattformen verwendet. Um diese Bibliothek zu installieren, führen Sie diesen Befehl aus: `brew install mono-libgdiplus` 

### **Aspose.Slides installieren**

`pip` ist der einfachste Weg, [Aspose.Slides für Python über .NET](https://pypi.org/project/aspose.slides/) auf macOS-Geräten herunterzuladen und zu installieren. Um Aspose.Slides zu installieren, führen Sie diesen Befehl aus: `pip install aspose.slides`

**Aspose.Slides verwenden**

Testen Sie Ihre Aspose.Slides-Installation, indem Sie diesen Code ausführen, um eine PowerPoint-Präsentation zu erstellen:

```python
# Imports Aspose.Slides for Python via .NET module
import aspose.slides as slides

# Instantiates a Presentation object that represents a presentation file
with slides.Presentation() as presentation:    
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```