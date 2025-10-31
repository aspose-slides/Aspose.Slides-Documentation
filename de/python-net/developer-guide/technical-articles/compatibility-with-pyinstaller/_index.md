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
description: "Packen Sie Aspose.Slides für Python via .NET mit PyInstaller. Folgen Sie diesem Leitfaden, um Ihre Anwendung zu bündeln, zu konfigurieren und bei Problemen zu beheben, sodass sie als eigenständige ausführbare Datei vorliegt."
---

## **Kompatibilität mit PyInstaller und cx_Freeze**

Aspose.Slides für Python via .NET-Erweiterungen sind standardmäßige Python‑C‑Erweiterungen, sodass sie mit Werkzeugen wie PyInstaller und cx_Freeze (oder ähnlichen) als Programmbibliotheken „gefroren“ werden können. Dadurch können Sie ausführbare Dateien aus Ihren Python‑Skripten erstellen. Solche Werkzeuge werden „Freezer“ genannt, weil sie Ihren Code und dessen Abhängigkeiten in einer einzigen verteilbaren Datei bündeln, die auf anderen Rechnern läuft, ohne dass eine Python‑Installation oder zusätzliche Bibliotheken erforderlich sind. Dieser Ansatz vereinfacht die Verteilung Ihrer Python‑Anwendungen.

Das Einfrieren einer Aspose.Slides für Python via .NET‑Erweiterung als Abhängigkeit wird unten anhand eines einfachen Programms gezeigt, das Aspose.Slides verwendet.

### **PyInstaller**

Im Allgemeinen ist nichts Besonderes erforderlich, wenn Sie ein Programm verpacken, das von einer Aspose.Slides für Python via .NET‑Erweiterung abhängt. Wenn ein Programm die Erweiterung auf eine Weise importiert, die für PyInstaller sichtbar ist, wird die Erweiterung mit dem Programm gebündelt. Da Aspose.Slides für Python via .NET PyInstaller‑Hooks enthält, werden dessen Abhängigkeiten automatisch erkannt und in das Paket kopiert.

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

Allerdings kann PyInstaller gelegentlich versteckte Importe übersehen – Module, die dynamisch oder indirekt von Ihrem Code importiert werden. Um einen versteckten Import einzubeziehen, verwenden Sie die Optionen von PyInstaller. Die Abhängigkeiten der Erweiterung sind in den PyInstaller‑Hooks angegeben, die mit Aspose.Slides für Python via .NET ausgeliefert werden.

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

Um ein Programm mit cx_Freeze einzufrieren, konfigurieren Sie es so, dass das Stamm‑Package der Aspose.Slides für Python via .NET‑Erweiterung, die Sie verwenden, einbezogen wird. Dadurch werden die Erweiterung und alle abhängigen Module zusammen mit Ihrer Anwendung in den Build kopiert.

#### **Verwendung des cxfreeze‑Skripts**

```bash
$ cxfreeze slide_app.py --packages=aspose
```

#### **Verwendung des Setup‑Skripts**

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

Nein, PowerPoint ist nicht erforderlich. Aspose.Slides ist eine eigenständige Engine; das Python‑Paket liefert alles Notwendige als Erweiterung für CPython. Der Benutzer muss .NET nicht separat installieren.

**Wie sollte ich die Lizenz korrekt an eine eingefrorene Anwendung anhängen?**

Sie können die Lizenz‑XML neben der ausführbaren Datei speichern oder sie als Ressource einbetten und vor dem ersten API‑Aufruf von einem zugänglichen Pfad aus laden. Wichtig: Ändern Sie den XML‑Inhalt nicht (nicht einmal Zeilenumbrüche).

**Was soll ich tun, wenn Schriftarten nach dem Build anders dargestellt werden als während der Entwicklung?**

Stellen Sie sicher, dass die von Ihnen verwendeten Schriftarten in der Zielumgebung verfügbar sind (eingebunden oder systemweit installiert) und dass deren Pfade zur Laufzeit korrekt aufgelöst werden; das Verhalten von Schriftarten ist insbesondere unter Linux empfindlich.