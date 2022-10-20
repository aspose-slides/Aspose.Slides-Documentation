---
title: Installation
type: docs
weight: 70
url: /python-net/installation/
keywords: "Download Aspose.Slides, Install Aspose.Slides, Aspose.Slides Installation, Windows, macOS, Python"
description: "Install Aspose.Slides for Python via .NET in Windows or macOS"
---

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

Get these prerequisites first:

**Install Xcode command line tools**

1. Open the Terminal app.
2. Run this code to install Xcode: `xcode-select --install`
3. Click **Install**. 
4. Click **Agree**.

**Install Homebrew**

1. Open the Terminal app.
2. Run this code to install homebrew: `/bin/bash -c "$(curl -fsSL https://raw.githubusercontent.com/Homebrew/install/HEAD/install.sh)"`
3. Enter your admin password and follow the prompts.

**Install Python 3.9.13 pyenv**

1. Open the Terminal app.
2. Run this code to see the python versions installed on your Mac: `pyenv install --list` 
3. Install Python 3.9.13: `pyenv install 3.9.13`
4. Check the default python version: `pyenv global`
5. Make Python 3.9.13 the default: `pyenv global 3.9.13` 
6. Force pyenv to install python dynamic/shared library: `env PYTHON_CONFIGURE_OPTS="--enable-shared" pyenv install --verbose 3.9.13`
7. Create a symbolic link: `ln -s /Users/<username>/.pyenv/versions/3.9.13/lib/libpython3.9.dylib /usr/local/lib/libpython3.9.dylib`

### **Install Aspose.Slides**

`pip` is the easiest way to download and install [Aspose.Slides for Python via .NET](https://pypi.org/project/aspose.slides/) on macOS devices. 

1. Open the Terminal app.
2. Run this code: `pip install aspose.slides`
3. Pay attention to the prompts.

Create a PowerPoint presentation file by running a simple python code:

1. Open Visual Studio Code on your mac.

2. Create a file with the .py extension.

3. Copy and paste this code:

   ```python
   # Imports Aspose.Slides for Python via .NET module
   import aspose.slides as slides
   
   # Instantiates a Presentation object that represents a presentation file
   with slides.Presentation() as presentation:    
       slide = presentation.slides[0]
       slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)
       presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
   ```

4. Run the code.

You should find the resulting PowerPoint file in your home (user) folder.  