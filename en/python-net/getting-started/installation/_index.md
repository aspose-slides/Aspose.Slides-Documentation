---
title: Installation
type: docs
weight: 70
url: /python-net/installation/
keywords: "Download Aspose.Slides, Install Aspose.Slides, Aspose.Slides Installation, Windows, macOS, Python"
description: "Install Aspose.Slides for Python via .NET in Windows or macOS"
---

The Aspose.Slides for Python via .NET package comes with the .NET libraries it needs, so a separate .NET installation is not required. However, depending on your platform, you may have to install specific dependencies for .NET and meet certain requirements.

## **Windows**

**System Requirements**

Check and confirm that your machine's specifications meet or better the [system requirements](/slides/python-net/system-requirements/).

### **Install Aspose.Slides**

`pip` is the easiest way to download and install [Aspose.Slides for Python via .NET](https://pypi.org/project/aspose.slides/) on Windows devices.

To install Aspose.Slides, run this command:  `pip install aspose.slides`

**Use Aspose.Slides**

Test your Aspose.Slides installation by running this code to create a PowerPoint presentation:

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

There are different ways to install Python in macOS, but we strongly recommend you use the [pyenv tool](https://github.com/pyenv/pyenv#homebrew-in-macos).

After you install and configure pyenv, you have to install python with shared libraries by running these commands in the Terminal app:

1. Install Python: `env PYTHON_CONFIGURE_OPTS="--enable-shared" pyenv install --verbose 3.9.13`
2. Configure it as a global Python installation: `pyenv global 3.9.13`
3. Configure it as a shell Python installation: `pyenv shell 3.9.13`
4. Create a symbolic link for the libpython library in a system library directory: `ln -s /Users/<username>/.pyenv/versions/3.9.13/lib/libpython3.9.dylib /usr/local/lib/libpython3.9.dylib` 

Note: Python 3.5 and above is required. Python version 3.9.13 was simply used as an example. 

**Install the libgdiplus library**

The libgdiplus library is a Windows GDI+ implementation for macOS and Linux that .NET uses on those platforms. To install this library, run this command: `brew install mono-libgdiplus` 

### **Install Aspose.Slides**

`pip` is the easiest way to download and install [Aspose.Slides for Python via .NET](https://pypi.org/project/aspose.slides/) on macOS devices. To install Aspose.Slides, run this command: `pip install aspose.slides`

**Use Aspose.Slides**

Test your Aspose.Slides installation by running this code to create a PowerPoint presentation:

```python
# Imports Aspose.Slides for Python via .NET module
import aspose.slides as slides

# Instantiates a Presentation object that represents a presentation file
with slides.Presentation() as presentation:    
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```
