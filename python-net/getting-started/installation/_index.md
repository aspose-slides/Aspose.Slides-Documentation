---
title: Installation
type: docs
weight: 70
url: /python-net/installation/
keywords: "Download Aspose.Slides, Install Aspose.Slides, Aspose.Slides Installation, Windows, macOS, Python"
description: "Install Aspose.Slides for Python via .NET in Windows or macOS"
---

## Common

Aspose.Slides for Python via .NET package includes necessary .NET libraries. A separate .NET installation is not required. But in each platform .NET can has specific dependencies and requirements that must be installed separately.

## **Windows**

**System Requirements**

Check and confirm that your machine's specifications meet or better the [system requirements](/slides/python-net/system-requirements/).

### **Install Aspose.Slides**

`pip` is the easiest way to download and install [Aspose.Slides for Python via .NET](https://pypi.org/project/aspose.slides/) on Windows devices.

To install Aspose.Slides, run this command:  `pip install aspose.slides`

**Use Aspose.Slides**

Run this code to create a PowerPoint presentation:

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

**System Requirements**

Check and confirm that your machine's specifications meet or better the [system requirements](/slides/python-net/system-requirements/).

### **Prerequisites**

**Python with shared libraries**

There are different ways to install Python in macOS. We recommend to use [pyenv tool](https://github.com/pyenv/pyenv#homebrew-in-macos) for this.

When pyenv is installed and configured, perform the following steps to install Python with shared libraries.

1. Install Python: `env PYTHON_CONFIGURE_OPTS="--enable-shared" pyenv install --verbose 3.9.13`
2. Configure it as a global Python installation: `pyenv global 3.9.13`
3. Configure it as a shell Python installation: `pyenv shell 3.9.13`
4. Create a symbolic link for the libpython library in a system library directory: `ln -s /Users/<username>/.pyenv/versions/3.9.13/lib/libpython3.9.dylib /usr/local/lib/libpython3.9.dylib` 

The Python version 3.9.13 is used as an example. You can install any necessary Python 3.5+ version.

**Install the libgdiplus library**

The libgdiplus library is a Windows GDI+ implementation fo macOS and Linux platforms. .NET use it in these platforms. Run `brew install mono-libgdiplus` command to install this library.

### **Install Aspose.Slides**

`pip` is the easiest way to download and install [Aspose.Slides for Python via .NET](https://pypi.org/project/aspose.slides/) on macOS devices. Run the `pip install aspose.slides` command to install it.

Create and run python file with the following source code to test Aspose.Slides for Python via .NET installation.

```python
# Imports Aspose.Slides for Python via .NET module
import aspose.slides as slides

# Instantiates a Presentation object that represents a presentation file
with slides.Presentation() as presentation:    
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```
