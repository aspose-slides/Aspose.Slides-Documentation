---
title: Installation
type: docs
weight: 70
url: /python-java/installation/
keywords:
- download Aspose.Slides
- install Aspose.Slides
- Aspose.Slides installation
- Python
- Java
- JPype
- Windows
- macOS
- Linux
description: "Install Aspose.Slides for Python via Java on Windows, Linux, or macOS, configure Java and JPype, and verify the setup with a working example."
---

Aspose.Slides for Python via Java runs on Windows, Linux, and macOS. It uses JPype to access the Java library from Python. Microsoft PowerPoint is not required.

## **Prerequisites**

Before installing the Python packages, install Python and a JDK that meet the [System Requirements](/slides/python-java/system-requirements/). That page lists compatible versions, architecture requirements, and any dependencies needed to build JPype from source.

Set `JAVA_HOME` to the JDK installation directory, not its `bin` subdirectory, and add the JDK's `bin` directory to `PATH`. Open a new terminal after changing environment variables.

## **Install from PyPI**

Run the following commands in a terminal, not at the Python interactive prompt. Create a project directory and a virtual environment to keep the packages isolated from other projects.

### **Windows**

With your chosen Python interpreter available as `python` on `PATH`, run the following commands in Command Prompt:

```bat
mkdir slides-example
cd slides-example
python -m venv .venv
.venv\Scripts\activate.bat
```

### **Linux and macOS**

With your chosen Python version available as `python3`, run the following commands in Bash or zsh:

```bash
mkdir slides-example
cd slides-example
python3 -m venv .venv
source .venv/bin/activate
```

On Debian or Ubuntu, if creating the environment fails because `ensurepip` is unavailable, install the `python3-venv` package with `sudo apt-get install python3-venv`, then repeat the environment creation command. A separately installed Python version may need its matching version-specific `venv` package.

### **Install the Packages**

With the virtual environment active, install JPype and Aspose.Slides:

```sh
python -m pip install --upgrade pip
python -m pip install JPype1 aspose-slides-java
```

Using `python -m pip` ensures that packages are installed for the interpreter used to run your application.

To update an existing Aspose.Slides installation, run `python -m pip install --upgrade aspose-slides-java` in the same environment.

## **Install from a ZIP Archive**

You can also use the library from the [Aspose.Slides downloads page](https://releases.aspose.com/slides/python-java/):

1. Install Python and Java as described in [Prerequisites](#prerequisites).
2. Create and activate a virtual environment using the instructions above.
3. Install JPype with `python -m pip install JPype1`.
4. Download and extract the Aspose.Slides for Python via Java ZIP archive.
5. Locate the extracted `asposeslides` package directory. Keep its contents, including the `lib` directory and JAR file, together.
6. Place `example.py` from the next section alongside the `asposeslides` directory so that Python can import the package.

## **Verify the Installation**

Save the following code as `example.py`. It creates a presentation with a text box and saves it as `out.pptx` in the current working directory.

```python
import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import Presentation, SaveFormat, ShapeType

    presentation = Presentation()
    try:
        slide = presentation.getSlides().get_Item(0)
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 500, 80)
        shape.getTextFrame().setText("Aspose.Slides is ready!")
        presentation.save("out.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    jpype.shutdownJVM()
```

With the virtual environment active, run the example from the directory containing `example.py`:

```sh
python example.py
```

The `asposeslides` import registers the bundled Java library before the JVM starts. Import `asposeslides.api` after starting the JVM, and release presentation resources before shutting it down.

{{% alert color="info" title="Note" %}}

Without a license, the output includes an evaluation watermark. See [Evaluate Aspose.Slides](/slides/python-java/evaluate-aspose-slides/) for evaluation limitations and temporary license information.

{{% /alert %}}

## **FAQ**

**Why does Python report that the JVM cannot be found or loaded?**

Check that `JAVA_HOME` points to a JDK compatible with your Python and JPype installation, as described in [System Requirements](/slides/python-java/system-requirements/). See the [JPype installation troubleshooting guide](https://jpype.readthedocs.io/en/latest/install.html) for additional checks.

**Why does Python report that `asposeslides` is missing after installation?**

The package may have been installed for a different Python interpreter. Activate the virtual environment used for installation and run `python -m pip show aspose-slides-java`. For a ZIP installation, ensure that the `asposeslides` directory is alongside your script or otherwise available on Python's module search path.

**Can I run the example repeatedly in a notebook?**

The example is intended for a standalone Python process. Before adapting it for repeated notebook execution, see [Limitations and API Differences](/slides/python-java/limitations-and-api-differences/#import-the-library) for JVM lifecycle and notebook guidance.

**Why does pip fail with `CERTIFICATE_VERIFY_FAILED`?**

If your network uses an HTTPS inspection proxy, pip must trust its certificate authority. Configure the trusted CA bundle using pip's `--cert` option or the `PIP_CERT` environment variable, following the [pip HTTPS certificate instructions](https://pip.pypa.io/en/stable/topics/https-certificates/). The required configuration depends on your network and pip version.
