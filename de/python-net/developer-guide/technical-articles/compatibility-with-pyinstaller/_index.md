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
description: "Verpacken Sie Aspose.Slides für Python via .NET mit PyInstaller. Befolgen Sie diese Anleitung, um Ihre Anwendung zu bündeln, zu konfigurieren und Fehler zu beheben, sodass sie als eigenständige ausführbare Datei vorliegt."
---

## **Kompatibilität mit PyInstaller und cx_Freeze**

Aspose.Slides for Python via .NET‑Erweiterungen sind Standard‑Python‑C‑Erweiterungen, sodass sie mit Werkzeugen wie PyInstaller und cx_Freeze (oder ähnlichen) als Programm‑Abhängigkeiten eingefroren werden können. Damit lassen sich ausführbare Dateien aus Ihren Python‑Skripten erstellen. Solche Werkzeuge werden „Freezer“ genannt, weil sie Ihren Code und seine Abhängigkeiten in einer einzigen verteilbaren Datei bündeln, die auf anderen Rechnern läuft, ohne dass eine Python‑Installation oder zusätzliche Bibliotheken erforderlich sind. Dieser Ansatz vereinfacht die Verteilung Ihrer Python‑Anwendungen.

Das Einfrieren einer Aspose.Slides for Python via .NET‑Erweiterung als Abhängigkeit wird im Folgenden mit einem einfachen Programm gezeigt, das Aspose.Slides verwendet.

### **PyInstaller**

Im Allgemeinen ist beim Verpacken eines Programms, das von einer Aspose.Slides for Python via .NET‑Erweiterung abhängt, nichts Besonderes erforderlich. Wenn ein Programm die Erweiterung auf eine Weise importiert, die für PyInstaller sichtbar ist, wird die Erweiterung mit dem Programm gebündelt. Da Aspose.Slides for Python via .NET PyInstaller‑Hooks enthält, werden die Abhängigkeiten automatisch erkannt und in das Bundle kopiert.

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


PyInstaller kann jedoch gelegentlich versteckte Importe übersehen – Module, die dynamisch oder indirekt von Ihrem Code importiert werden. Um einen versteckten Import einzubeziehen, verwenden Sie die Optionen von PyInstaller. Die Abhängigkeiten der Erweiterung sind in den PyInstaller‑Hooks festgelegt, die mit Aspose.Slides for Python via .NET ausgeliefert werden.

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

Um ein Programm mit cx_Freeze einzufrieren, konfigurieren Sie es so, dass das Root‑Package der von Ihnen verwendeten Aspose.Slides for Python via .NET‑Erweiterung eingeschlossen wird. Dadurch wird sichergestellt, dass die Erweiterung und alle abhängigen Module zusammen mit Ihrer Anwendung in den Build kopiert werden.

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

**Muss Microsoft PowerPoint oder .NET auf dem Rechner des Benutzers installiert sein?**

Nein, PowerPoint ist nicht erforderlich. Aspose.Slides ist eine eigenständige Engine; das Python‑Paket liefert alles, was als Erweiterung für CPython benötigt wird. Der Benutzer muss .NET nicht separat installieren.

**Wie binde ich die Lizenz korrekt in eine eingefrorene Anwendung ein?**

Sie können die Lizenz‑XML neben der ausführbaren Datei speichern oder sie als Ressource einbetten und vor dem ersten API‑Aufruf aus einem zugänglichen Pfad laden. Wichtig: Ändern Sie den XML‑Inhalt nicht (auch nicht die Zeilenumbrüche).

**Was ist zu tun, wenn Schriften nach dem Build anders dargestellt werden als während der Entwicklung?**

Stellen Sie sicher, dass die von Ihnen verwendeten Schriften in der Zielumgebung (eingebettet oder systemweit installiert) verfügbar sind und dass ihre Pfade zur Laufzeit korrekt aufgelöst werden; das Schriftverhalten ist besonders auf Linux sensibel.