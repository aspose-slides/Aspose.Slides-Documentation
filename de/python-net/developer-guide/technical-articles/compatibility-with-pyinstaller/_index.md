---
title: Kompatibilität mit PyInstaller und cx_Freeze
linktitle: Kompatibilität mit PyInstaller
type: docs
weight: 122
url: /de/python-net/developer-guide/technical-articles/compatibility-with-pyinstaller/
keywords:
- Kompatibilität
- PyInstaller
- cx_Freeze
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET mit PyInstaller paketieren. Folgen Sie dieser Anleitung, um Ihre Anwendung in eine eigenständige ausführbare Datei zu bündeln, zu konfigurieren und zu trouble­shooten."
---

## **Kompatibilität mit PyInstaller und cx_Freeze**

Aspose.Slides for Python via .NET‑Erweiterungen sind Standard‑Python‑C‑Erweiterungen, sodass sie mit Tools wie PyInstaller und cx_Freeze (oder ähnlichen) als Programmbibliotheken „eingefroren“ werden können. Dadurch lassen sich ausführbare Dateien aus Ihren Python‑Skripten erzeugen. Solche Tools werden „Freezer“ genannt, weil sie Ihren Code und seine Abhängigkeiten in einer einzigen verteilbaren Datei zusammenfassen, die auf anderen Rechnern läuft, ohne dass eine Python‑Installation oder zusätzliche Bibliotheken erforderlich sind. Dieser Ansatz vereinfacht die Verteilung Ihrer Python‑Anwendungen.

Das Einfrieren einer Aspose.Slides for Python via .NET‑Erweiterung als Abhängigkeit wird im Folgenden anhand eines einfachen Programms gezeigt, das Aspose.Slides verwendet.

### **PyInstaller**

Im Allgemeinen ist nichts Besonderes erforderlich, wenn Sie ein Programm paketieren, das von einer Aspose.Slides for Python via .NET‑Erweiterung abhängt. Wird die Erweiterung in einer für PyInstaller sichtbaren Weise importiert, wird sie zusammen mit dem Programm gebündelt. Da Aspose.Slides for Python via .NET PyInstaller‑Hooks enthält, werden seine Abhängigkeiten automatisch erkannt und in das Bundle kopiert.

`slide_app.py`:
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

Allerdings kann es vorkommen, dass PyInstaller versteckte Importe – Module, die dynamisch oder indirekt von Ihrem Code geladen werden – übersieht. Um einen versteckten Import einzubeziehen, verwenden Sie die entsprechenden Optionen von PyInstaller. Die Abhängigkeiten der Erweiterung sind in den PyInstaller‑Hooks definiert, die mit Aspose.Slides for Python via .NET ausgeliefert werden.

`slide_app.spec`:
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

Um ein Programm mit cx_Freeze einzufrieren, konfigurieren Sie es so, dass das Stamm‑Package der von Ihnen verwendeten Aspose.Slides for Python via .NET‑Erweiterung einbezogen wird. Dadurch wird sichergestellt, dass die Erweiterung und alle abhängigen Module neben Ihrer Anwendung in den Build kopiert werden.

#### **Verwendung des cxfreeze‑Scripts**

```bash
$ cxfreeze slide_app.py --packages=aspose
```

#### **Verwendung des Setup‑Scripts**

`setup.py`:
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

**Muss auf dem Rechner des Benutzers Microsoft PowerPoint oder .NET installiert sein?**

Nein, PowerPoint wird nicht benötigt. Aspose.Slides ist eine eigenständige Engine; das Python‑Paket liefert alles, was als CPython‑Erweiterung erforderlich ist. Der Benutzer muss .NET nicht separat installieren.

**Wie füge ich die Lizenzdatei korrekt zu einer eingefrorenen Anwendung hinzu?**

Sie können die Lizenz‑XML neben der ausführbaren Datei ablegen oder sie als Ressource einbetten und vor dem ersten API‑Aufruf aus einem zugänglichen Pfad laden. Wichtig: Ändern Sie den XML‑Inhalt nicht (auch nicht die Zeilenumbrüche).

**Was tun, wenn nach dem Build die Schriftarten anders dargestellt werden als in der Entwicklungsumgebung?**

Stellen Sie sicher, dass die von Ihnen genutzten Schriftarten in der Zielumgebung (entweder gebündelt oder systemweit installiert) verfügbar sind und dass ihre Pfade zur Laufzeit korrekt aufgelöst werden; das Schriftverhalten ist insbesondere unter Linux sehr empfindlich.