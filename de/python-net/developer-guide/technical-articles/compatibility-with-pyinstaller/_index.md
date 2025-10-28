---
title: Kompatibilität mit PyInstaller und cx_Freeze
linktitle: Kompatibilität mit PyInstaller
type: docs
weight: 122
url: /de/python-net/compatibility-with-pyinstaller/
keywords:
- Kompatibilität
- PyInstaller
- cx_Freeze
- Python
- Aspose.Slides
description: "Paketieren Sie Aspose.Slides für Python via .NET mit PyInstaller. Folgen Sie dieser Anleitung, um Ihre Anwendung zu bündeln, zu konfigurieren und Probleme zu beheben, damit sie als eigenständige ausführbare Datei vorliegt."
---

## **Kompatibilität mit PyInstaller und cx_Freeze**

Aspose.Slides für Python via .NET-Erweiterungen sind standardmäßige Python‑C‑Erweiterungen, sodass sie mit Werkzeugen wie PyInstaller und cx_Freeze (oder ähnlichen) als Programm‑Abhängigkeiten „eingefroren“ werden können. Das ermöglicht Ihnen, ausführbare Dateien aus Ihren Python‑Skripten zu erstellen. Solche Werkzeuge werden „Freezer“ genannt, weil sie Ihren Code und dessen Abhängigkeiten in einer einzigen verteilterbaren Datei bündeln, die auf anderen Rechnern läuft, ohne dass eine Python‑Installation oder zusätzliche Bibliotheken erforderlich sind. Dieser Ansatz vereinfacht die Verteilung Ihrer Python‑Anwendungen.

Das Einfrieren einer Aspose.Slides für Python via .NET-Erweiterung als Abhängigkeit wird unten anhand eines einfachen Programms gezeigt, das Aspose.Slides verwendet.

### **PyInstaller**

Im Allgemeinen ist nichts Besonderes erforderlich, wenn Sie ein Programm paketieren, das von einer Aspose.Slides für Python via .NET-Erweiterung abhängt. Wenn ein Programm die Erweiterung in einer für PyInstaller sichtbaren Weise importiert, wird die Erweiterung mit dem Programm gebündelt. Da Aspose.Slides für Python via .NET PyInstaller‑Hooks enthält, werden seine Abhängigkeiten automatisch erkannt und in das Bündel kopiert.

slide_app.py:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50.0, 150.0, 300.0, 0.0)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```

```bash
$ pyinstaller slide_app.py
```

Allerdings kann PyInstaller gelegentlich versteckte Importe übersehen – Module, die von Ihrem Code dynamisch oder indirekt importiert werden. Um einen versteckten Import einzuschließen, verwenden Sie die Optionen von PyInstaller. Die Abhängigkeiten der Erweiterung sind in den PyInstaller‑Hooks angegeben, die mit Aspose.Slides für Python via .NET geliefert werden.

slide_app.spec:
```
a = Analysis(
    ['slide_app.py'],
    ...
    hiddenimports=['aspose.slides']
)
```

```bash
$ pyinstaller slide_app.spec
```

### **cx_Freeze**

Um ein Programm mit cx_Freeze einzufrieren, konfigurieren Sie es so, dass das Root‑Package der von Ihnen verwendeten Aspose.Slides für Python via .NET-Erweiterung einbezogen wird. Dadurch wird sichergestellt, dass die Erweiterung und alle abhängigen Module zusammen mit Ihrer Anwendung in den Build kopiert werden.

#### **Verwendung des cxfreeze‑Scripts**

```bash
$ cxfreeze slide_app.py --packages=aspose
```

#### **Verwendung des Setup‑Scripts**

setup.py:
```
executables = [Executable('slide_app.py')]

options = {
    'build_exe': {
        'packages': ['aspose'],
    }
}

setup(...
    options=options,
    executables=executables)
```

```bash
$ python setup.py build_exe
```

## **FAQ**

**Benötige ich Microsoft PowerPoint oder .NET auf dem Rechner des Benutzers?**

Nein, PowerPoint ist nicht erforderlich. Aspose.Slides ist eine eigenständige Engine; das Python‑Paket enthält alles Notwendige als Erweiterung für CPython. Der Benutzer muss .NET nicht separat installieren.

**Wie sollte ich die Lizenz korrekt an eine eingefrorene Anwendung anhängen?**

Sie können die Lizenz‑XML neben der ausführbaren Datei speichern oder sie als Ressource einbetten und vor dem ersten API‑Aufruf von einem zugänglichen Pfad laden. Wichtig: Ändern Sie den XML‑Inhalt nicht (auch keine Zeilenumbrüche).

**Was soll ich tun, wenn Schriftarten nach dem Build anders gerendert werden als in der Entwicklung?**

Stellen Sie sicher, dass die von Ihnen verwendeten Schriftarten in der Zielumgebung (eingebunden oder systemweit installiert) verfügbar sind und dass ihre Pfade zur Laufzeit korrekt aufgelöst werden; das Font‑Verhalten ist insbesondere unter Linux sehr empfindlich.