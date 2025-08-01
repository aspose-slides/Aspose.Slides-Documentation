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
description: "Packen Sie Aspose.Slides for Python via .NET mit PyInstaller. Befolgen Sie diese Anleitung, um Ihre Anwendung als eigenständige ausführbare Datei zu bündeln, zu konfigurieren und Fehler zu beheben."
---

## Kompatibilität mit PyInstaller und cx_Freeze ##

'Aspose.Slides für Python über .NET'-Erweiterungen sind einfach Python C-Erweiterungen, die mit Hilfe von PyInstaller und cx_Freeze (oder ähnlichen Tools) als Programmbibliotheken eingefroren werden können. Das bedeutet, dass Sie Tools wie PyInstaller und cx_Freeze verwenden können, um ausführbare Dateien aus Ihren Python-Skripten zu erstellen. Diese Tools werden "Freezer" genannt, weil sie Ihren Code und die Abhängigkeiten in eine einzige Datei einfrieren, die auf anderen Maschinen ohne Python oder andere Bibliotheken ausgeführt werden kann. Dies erleichtert die Verbreitung Ihrer Python-Anwendungen an andere.

Das Einfrieren einer 'Aspose.Slides für Python über .NET'-Erweiterung als Programmbibliothek wird anhand eines Beispiels eines einfachen Programms veranschaulicht, das Aspose.Slides verwendet.

### PyInstaller
Im Allgemeinen muss beim Verpacken eines Programms, das von einer 'Aspose.Slides für Python über .NET'-Erweiterung abhängt, nichts Besonderes getan werden. Wenn ein Programm eine Erweiterung auf eine Weise importiert, die für PyInstaller sichtbar ist, wird die Erweiterung zusammen mit dem Programm gebündelt. Da 'Aspose.Slides für Python über .NET'-Erweiterungen mit PyInstaller-Hooks geliefert werden, werden ihre eigenen Abhängigkeiten gefunden und in das Bundle kopiert.

slide_app.py:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50.0, 150.0, 300.0, 0.0)
    presentation.save("NewPresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

```
$ pyinstaller slide_app.py
```

Manchmal kann PyInstaller jedoch einige versteckte Importe nicht erkennen, das sind Module, die durch Ihren Code dynamisch oder indirekt importiert werden. Um mit einem versteckten Import in PyInstaller umzugehen, verwenden Sie die Optionen von PyInstaller. Die Abhängigkeiten einer Erweiterung sind in den PyInstaller-Hooks angegeben, die mit der 'Aspose.Slides für Python über .NET'-Erweiterung geliefert werden.

slide_app.spec:
```
a = Analysis(
    ['slide_app.py'],
    ...
    hiddenimports=['aspose.slides']
)
```

```
$ pyinstaller slide_app.spec
```

### cx_Freeze ###
Um ein Programm mit cx_Freeze einzufrieren, verwenden Sie dessen Optionen, um das Stamm-Paket der 'Aspose.Slides für Python über .NET'-Erweiterung einzufrieren, die Sie verwenden. Dies stellt sicher, dass die Erweiterung und die Module, von denen sie abhängt, zusammen mit dem Programm kopiert werden.

#### Verwendung des cxfreeze-Skripts ####
```
$ cxfreeze slide_app.py --packages=aspose
```

#### Verwendung des Setup-Skripts ####
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

```
$ python setup.py build_exe
```