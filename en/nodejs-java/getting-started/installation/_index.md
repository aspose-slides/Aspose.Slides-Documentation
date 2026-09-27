---
title: Installation
type: docs
weight: 70
url: /nodejs-java/installation/
keywords:
- install Aspose.Slides
- download Aspose.Slides
- use Aspose.Slides
- Aspose.Slides installation
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Install Aspose.Slides for Node.js via Java from npm on Windows, Linux, and macOS: the JDK, Python, and C++ build tools it needs, the npm command, and a first script to check the installation."
---

## **Overview**

This article explains how to install Aspose.Slides for Node.js via Java on Windows, Linux, and macOS, and how to check that the installation works.

Aspose.Slides for Node.js via Java is distributed as the `aspose.slides.via.java` package on npm. It runs Aspose.Slides in a Java virtual machine through the [`java`](https://github.com/joeferner/node-java) package, a native Node.js addon that npm compiles on your computer during installation. That is why the installation needs, besides Node.js:

- **A Java Development Kit (JDK) 8 or later.** A Java runtime alone is not enough: the build needs the JDK's header files.
- **Python 3**, which the build tool [node-gyp](https://github.com/nodejs/node-gyp) uses.
- **A C++ build toolchain** for your operating system.

## **Install the Prerequisites**

### **Windows**

1. Install [Node.js](https://nodejs.org/en/download) 20 or later.
1. Install a JDK, for example [Eclipse Temurin](https://adoptium.net/), and set the `JAVA_HOME` environment variable to its installation folder. The build uses the JDK that `JAVA_HOME` points to.
1. Install [Python 3](https://www.python.org/downloads/).
1. Install [Build Tools for Visual Studio 2022](https://aka.ms/vs/17/release/vs_BuildTools.exe) with the **Desktop development with C++** workload. Keep the workload's default components, which include **MSVC v143 - VS 2022 C++ x64/x86 build tools** and the **Windows 11 SDK**. Visual Studio 2026 does not work: the node-gyp version that the `java` package compiles with does not recognize it.

### **Linux**

Install Node.js 20 or later from [nodejs.org](https://nodejs.org/en/download) or your distribution's package source. Then install a JDK, Python 3, and the C++ build tools. On Debian and Ubuntu:

```bash
sudo apt-get update
sudo apt-get install -y default-jdk python3 build-essential
```

On Linux, the build finds the installed JDK without further configuration. If several JDKs are installed, set `JAVA_HOME` to the one you want to use.

### **macOS**

Install Node.js 20 or later, a JDK, and the Xcode Command Line Tools, which include Python 3 and the C++ compiler. See [Troubleshooting Installation](/slides/nodejs-java/troubleshooting-installation/) for macOS-specific notes.

## **Install from npm**

Create a project folder and install the package:

```bash
mkdir hello-slides
cd hello-slides
npm init -y
npm install aspose.slides.via.java
```

npm downloads Aspose.Slides and compiles the `java` bridge, which can take a few minutes. If the compilation fails, see [Troubleshooting Installation](/slides/nodejs-java/troubleshooting-installation/).

## **Check the Installation**

Create a file named *hello.js* in the project folder with the following code. It creates a presentation, adds a text box to its first slide, and saves the result as *hello.pptx*:

```javascript
const asposeSlides = require("aspose.slides.via.java");

const presentation = new asposeSlides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save("hello.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Aspose.Slides runs in a Java virtual machine that keeps Node.js running, so end the process explicitly.
process.exit(0);
```

Run the script:

```bash
node hello.js
```

If *hello.pptx* appears in the project folder, the installation works. The Java virtual machine that runs Aspose.Slides keeps Node.js from exiting on its own, which is why the script ends with `process.exit(0)`. [Create Presentations](/slides/nodejs-java/create-presentation/) explains the code.

## **Install from a ZIP Archive**

The package is also available as a ZIP archive with the same contents as the npm package. To install it from the archive:

1. Install the prerequisites for your operating system, as described above.
1. Download the archive from the [Aspose.Slides for Node.js via Java download page](https://releases.aspose.com/slides/nodejs-java/).
1. Create a project folder:

    ```bash
    mkdir hello-slides
    cd hello-slides
    npm init -y
    ```

1. Extract the archive into a subfolder named *aspose.slides.via.java* inside the project folder, so that the archive's *package.json* is at *hello-slides/aspose.slides.via.java/package.json*.
1. Install the package from that folder:

    ```bash
    npm install ./aspose.slides.via.java
    ```

    npm installs the `java` bridge that the package depends on and compiles it, as it does for the npm package.

1. Check the installation as described in [Check the Installation](#check-the-installation).

## **FAQ**

**Is there a free version or trial limitation?**

Yes. Without a license, Aspose.Slides runs in evaluation mode: it adds an evaluation watermark to every slide it saves and truncates text read from presentations. To remove these limitations, apply a valid [license](/slides/nodejs-java/licensing/).

**Why does my script not exit after it finishes?**

The `java` package starts a Java virtual machine inside the Node.js process, and that virtual machine keeps the process running. Call `process.exit` when your script has finished its work.
