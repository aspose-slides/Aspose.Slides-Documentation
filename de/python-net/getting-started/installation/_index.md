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
description: "Erfahren Sie, wie Sie Aspose.Slides for Python via .NET schnell installieren. Schritt-für-Schritt-Anleitung, Systemanforderungen und Codebeispiele – beginnen Sie noch heute mit PowerPoint-Präsentationen zu arbeiten!"
---

## **Übersicht**

Das Aspose.Slides for Python via .NET-Paket wird mit allen erforderlichen .NET-Bibliotheken gebündelt geliefert, sodass .NET nicht separat installiert werden muss. Dies vereinfacht den Einrichtungsprozess und ermöglicht Entwicklern, sofort mit Präsentationen zu arbeiten. Es ist jedoch wichtig zu beachten, dass Sie je nach Betriebssystem oder Umgebung möglicherweise dennoch plattformspezifische Abhängigkeiten installieren müssen, die von .NET benötigt werden. Außerdem müssen bestimmte Systemanforderungen erfüllt sein, um die vollständige Kompatibilität und ordnungsgemäße Funktionsweise des Pakets zu gewährleisten.

## **Windows**

**Systemanforderungen**

Überprüfen und bestätigen Sie, dass die Spezifikationen Ihres Computers die [Systemanforderungen](/slides/de/python-net/system-requirements/) erfüllen oder übertreffen.

### **Aspose.Slides installieren**

`pip` ist der einfachste Weg, um [Aspose.Slides for Python via .NET](https://pypi.org/project/aspose-slides/) unter Windows herunterzuladen und zu installieren.

Um Aspose.Slides zu installieren, führen Sie den folgenden Befehl aus:
```sh
pip install aspose-slides
```


**Aspose.Slides verwenden**

Testen Sie Ihre Aspose.Slides-Installation, indem Sie den folgenden Code ausführen, um eine PowerPoint-Präsentation zu erstellen:
```python
# Aspose.Slides für Python via .NET Modul importieren.
import aspose.slides as slides

# Instanziieren der Presentation-Klasse, die eine Präsentationsdatei darstellt.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 20, 20, 300, 200)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```


## **macOS**

**Systemanforderungen**

Überprüfen und bestätigen Sie, dass die Spezifikationen Ihres Computers die [Systemanforderungen](/slides/de/python-net/system-requirements/) erfüllen oder übertreffen.

### **Voraussetzungen**

**Python mit gemeinsam genutzten Bibliotheken**

Es gibt mehrere Möglichkeiten, Python auf macOS zu installieren, aber wir empfehlen dringend die Verwendung des [pyenv-Tools](https://github.com/pyenv/pyenv#homebrew-in-macos).

Nachdem Sie **pyenv** installiert und konfiguriert haben, installieren Sie Python mit gemeinsam genutzten Bibliotheken, indem Sie die folgenden Befehle im Terminal ausführen:

1. Install Python:
```sh
env PYTHON_CONFIGURE_OPTS="--enable-shared" pyenv install --verbose 3.9.13
```


2. Set it as the global Python version:
```sh
pyenv global 3.9.13
```


3. Set it as the shell-specific Python version:
```sh
pyenv shell 3.9.13
```


4. Create a symbolic link for the libpython library in a system library directory:
```sh
ln -s /Users/<username>/.pyenv/versions/3.9.13/lib/libpython3.9.dylib /usr/local/lib/libpython3.9.dylib
```


Hinweis: Python 3.5 oder höher ist erforderlich. Version 3.9.13 wird hier nur als Beispiel verwendet.

**libgdiplus-Bibliothek installieren**

Die **libgdiplus**-Bibliothek ist eine Windows GDI+-Implementierung für macOS und Linux, von der .NET für die grafische Funktionalität auf diesen Plattformen abhängt.  
Um diese Bibliothek auf macOS zu installieren, führen Sie den folgenden Befehl aus:
```sh
brew install mono-libgdiplus
```


### **Aspose.Slides installieren**

`pip` ist der einfachste Weg, um [Aspose.Slides for Python via .NET](https://pypi.org/project/aspose-slides/) auf macOS herunterzuladen und zu installieren.

Um Aspose.Slides zu installieren, führen Sie den folgenden Befehl aus:
```sh
pip install aspose-slides
```


**Aspose.Slides verwenden**

Testen Sie Ihre Aspose.Slides-Installation, indem Sie den folgenden Code ausführen, um eine PowerPoint-Präsentation zu erstellen:
```python
# Aspose.Slides für Python via .NET Modul importieren.
import aspose.slides as slides

# Instanziieren der Presentation-Klasse, die eine Präsentationsdatei repräsentiert.
with slides.Presentation() as presentation:    
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 20, 20, 300, 200)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Kann ich Aspose.Slides in einer virtuellen Umgebung installieren?**

Ja, Sie können es in jeder Python‑virtuellen Umgebung mit `pip` installieren. Stellen Sie lediglich sicher, dass die Umgebung je nach Betriebssystem Zugriff auf die erforderlichen nativen Abhängigkeiten hat.

**Kann ich Aspose.Slides in Docker‑Containern verwenden?**

Ja, aber Sie müssen sicherstellen, dass Ihr Docker‑Image die erforderlichen nativen Bibliotheken (**libgdiplus**, Schriftpakete usw.) sowie die korrekte Python‑Version enthält.

**Gibt es eine kostenlose Version oder eine Testeinschränkung?**

Ja, standardmäßig läuft Aspose.Slides im Evaluierungsmodus, der Wasserzeichen einfügt und weitere Einschränkungen haben kann. Um die Beschränkungen zu entfernen, müssen Sie eine gültige [Lizenz](/slides/de/python-net/licensing/) anwenden.