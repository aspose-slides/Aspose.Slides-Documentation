---
title: Compatibility with PyInstaller and cx_Freeze
linktitle: Compatibility with PyInstaller
type: docs
weight: 122
url: /python-net/compatibility-with-pyinstaller/
keywords:
- compatibility
- PyInstaller
- cx_Freeze
- Python
- Aspose.Slides
description: "Package Aspose.Slides for Python via .NET with PyInstaller. Follow this guide to bundle, configure, and troubleshoot your app into a standalone executable."
---

## **Compatibility with PyInstaller and cx_Freeze**

Aspose.Slides for Python via .NET extensions are standard Python C extensions, so they can be frozen as program dependencies with tools like PyInstaller and cx_Freeze (or similar). This allows you to create executable files from your Python scripts. Such tools are called “freezers” because they bundle your code and its dependencies into a single distributable file that runs on other machines without requiring a Python installation or additional libraries. This approach simplifies distributing your Python applications.

Freezing an Aspose.Slides for Python via .NET extension as a dependency is illustrated below with a simple program that uses Aspose.Slides.

### **PyInstaller**

Generally, nothing special is required when packaging a program that depends on an Aspose.Slides for Python via .NET extension. When a program imports the extension in a way visible to PyInstaller, the extension will be bundled with the program. Because Aspose.Slides for Python via .NET includes PyInstaller hooks, its dependencies are automatically detected and copied into the bundle.

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

However, PyInstaller may occasionally miss hidden imports—modules that are imported dynamically or indirectly by your code. To include a hidden import, use PyInstaller’s options. The extension’s dependencies are specified in the PyInstaller hooks that ship with Aspose.Slides for Python via .NET.

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

To freeze a program with cx_Freeze, configure it to include the root package of the Aspose.Slides for Python via .NET extension you are using. This ensures the extension and all dependent modules are copied into the build alongside your application.

#### **Using the cxfreeze Script**

```bash
$ cxfreeze slide_app.py --packages=aspose
```

#### **Using the Setup Script**

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

**Do I need Microsoft PowerPoint or .NET installed on the user’s machine?**

No, PowerPoint is not required. Aspose.Slides is a self-contained engine; the Python package ships everything needed as an extension for CPython. The user does not need to install .NET separately.

**How should I properly attach the license to a frozen application?**

You can store the license XML next to the executable or embed it as a resource and load it from an accessible path before the first API call. Important: do not modify the XML content (not even line breaks).

**What should I do if fonts render differently after the build compared to development?**

Make sure the fonts you use are available in the target environment (bundled or system-installed) and that their paths are correctly resolved at runtime; font behavior is especially sensitive on Linux.
