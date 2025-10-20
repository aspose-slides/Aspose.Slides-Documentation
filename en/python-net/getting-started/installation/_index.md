---
title: Installation
type: docs
weight: 70
url: /python-net/installation/
keywords:
- download Aspose.Slides
- install Aspose.Slides
- use Aspose.Slides
- Aspose.Slides installation
- Windows
- macOS
- Python
description: "Learn how to quickly install Aspose.Slides for Python via .NET. Step-by-step guide, system requirements, and code samples — start working with PowerPoint presentations today!"
---

## **Overview**

The Aspose.Slides for Python via .NET package comes with all the essential .NET libraries bundled, which means there is no need to install .NET separately. This simplifies the setup process and allows developers to start working with presentations right away. However, it's important to note that, depending on your operating system or environment, you might still need to install some platform-specific dependencies required by .NET. Additionally, certain system requirements must be met to ensure full compatibility and proper functioning of the package.

## **Windows**

**System Requirements**

Check and confirm that your machine’s specifications meet or exceed the [system requirements](/slides/python-net/system-requirements/).

### **Install Aspose.Slides**

`pip` is the easiest way to download and install [Aspose.Slides for Python via .NET](https://pypi.org/project/aspose-slides/) on Windows.

To install Aspose.Slides, run the following command:

```sh
pip install aspose-slides
```

**Use Aspose.Slides**

Test your Aspose.Slides installation by running the following code to create a PowerPoint presentation:

```python
# Import Aspose.Slides for Python via .NET module.
import aspose.slides as slides

# Instantiate the Presentation class that represents a presentation file.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 20, 20, 300, 200)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **macOS**

**System Requirements**

Check and confirm that your machine’s specifications meet or exceed the [system requirements](/slides/python-net/system-requirements/).

### **Prerequisites**

**Python with Shared Libraries**

There are several ways to install Python on macOS, but we strongly recommend using the [pyenv tool](https://github.com/pyenv/pyenv#homebrew-in-macos).

After installing and configuring **pyenv**, install Python with shared libraries by running the following commands in the Terminal app:

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

Note: Python 3.5 or higher is required. Version 3.9.13 is used here only as an example.

**Install the libgdiplus Library**

The **libgdiplus** library is a Windows GDI+ implementation for macOS and Linux that .NET relies on for graphical functionality on those platforms.
To install this library on macOS, run the following command:

```sh
brew install mono-libgdiplus
```

### **Install Aspose.Slides**

`pip` is the easiest way to download and install [Aspose.Slides for Python via .NET](https://pypi.org/project/aspose-slides/) on macOS.

To install Aspose.Slides, run the following command:

```sh
pip install aspose-slides
```

**Use Aspose.Slides**

Test your Aspose.Slides installation by running the following code to create a PowerPoint presentation:

```python
# Import Aspose.Slides for Python via .NET module.
import aspose.slides as slides

# Instantiate the Presentation class that represents a presentation file.
with slides.Presentation() as presentation:    
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 20, 20, 300, 200)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Can I install Aspose.Slides in a virtual environment?**

Yes, you can install it in any Python virtual environment using `pip`. Just make sure the environment has access to required native dependencies depending on your OS.

**Can I use Aspose.Slides in Docker containers?**

Yes, but you need to make sure your Docker image includes the required native libraries (**libgdiplus**, font packages, etc.) and the correct version of Python.

**Is there a free version or trial limitation?**

Yes, by default, Aspose.Slides runs in evaluation mode, which places watermarks and may have other limitations. To remove restrictions, you need to apply a valid [license](/slides/python-net/licensing/).
