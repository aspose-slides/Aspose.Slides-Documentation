---
title: System Requirements
type: docs
weight: 60
url: /java/system-requirements/
keywords:
- system requirements
- supported platforms
- Java versions
- JDK
- JRE
- fontconfig
- fonts
- Docker
- Alpine
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Check what Aspose.Slides for Java needs before you install it: the supported Java versions and operating systems, and the font library and fonts that Linux requires."
---

## **Introduction**

Aspose.Slides for Java is a standalone library: it does not need Microsoft PowerPoint or Microsoft Office. It is a single JAR file, published in Aspose's Maven repository. The JAR file contains only Java classes and resources, with no native libraries, and it declares no dependencies on other libraries. The same file therefore runs on every operating system and processor for which a supported Java runtime is available.

This article lists the supported Java versions and operating systems and the font library and fonts that Linux needs, and ends with a short program that checks your setup. To add the library to a project, see [Installation](/slides/java/installation/).

## **Supported Java Versions**

Aspose.Slides for Java runs on Java 8 or later, with a JDK or a JRE. This includes the long-term support releases Java 8, 11, 17, 21, and 25, and later releases such as Java 26 and Java 27. The Java runtime can come from any vendor, for example Eclipse Temurin, Amazon Corretto, Oracle, or the OpenJDK packages of a Linux distribution.

Aspose.Slides needs no JVM options, such as `--add-opens`, on any of these versions. On Java 11, the JVM prints a warning that begins with "WARNING: An illegal reflective access operation has occurred"; the warning does not affect the result.

{{% alert color="warning" title="Warning" %}}
Java 6 and Java 7 are deprecated. Aspose.Slides for Java 26.9 still runs on them but prints a deprecation warning. Starting with version 26.10, Java 8 is the minimum, and Java 6 and Java 7 are no longer supported.
{{% /alert %}}

The Maven project and the commands in [Installation](/slides/java/installation/) need JDK 11 or later. With Java 8, compile and run your program as shown in [Check Your Setup](#check-your-setup).

## **Supported Operating Systems**

Because the JAR file contains no native code, Aspose.Slides for Java runs on Windows, Linux, and macOS, on any processor architecture that the Java runtime supports, such as x64 and ARM64. The Java runtime is the only requirement on Windows. On Linux, Java's font support also needs the font library and fonts described in [Linux](#linux).

## **Linux**

Aspose.Slides for Java lays out and draws text with the font support of the Java runtime. On Linux, that support requires the fontconfig library and at least one installed font. Official container images of Linux distributions often have neither. Without them, the first example in [Create Presentations](/slides/java/create-presentation/) fails when it saves the presentation, leaves an empty file, and reports this error:

```text
java.lang.RuntimeException: Fontconfig head is null, check your fonts or fonts configuration
```

The official `eclipse-temurin` container images, for Ubuntu and for Alpine Linux, already contain fontconfig and the DejaVu fonts, so nothing needs to be installed on them. On other systems, install the packages below. The Debian, Ubuntu, and Red Hat commands use `sudo`; in a Dockerfile, run them in a `RUN` instruction without `sudo`. The DejaVu fonts are enough for Aspose.Slides to run; the fonts that your presentations use are covered in [Fonts](#fonts).

### **Debian and Ubuntu**

If you install Java from the Debian or Ubuntu packages with the default `apt-get` settings, as the command in [Installation](/slides/java/installation/#linux) does, the Java packages also install the fontconfig library, the DejaVu fonts, and the HarfBuzz library that these Java packages need, and nothing else is required.

With a Java runtime from another source, such as an Eclipse Temurin archive, install fontconfig and the DejaVu fonts:

```bash
sudo apt-get update && sudo apt-get install -y fontconfig fonts-dejavu-core
```

A Dockerfile often installs the Debian or Ubuntu Java packages, such as `openjdk-21-jdk-headless` or `default-jdk-headless`, with the `--no-install-recommends` option, which skips all three. Install fontconfig and the DejaVu fonts with the command above, and install HarfBuzz as well:

```bash
sudo apt-get install -y libharfbuzz0b
```

Without HarfBuzz, these Java packages print `Please install the openjdk-*-jre package or recommended packages for openjdk-*-jre-headless`, and saving fails with an `UnsatisfiedLinkError` that reports that `libharfbuzz.so.0` cannot be opened.

### **Red Hat Enterprise Linux**

The `java-<version>-openjdk-headless` packages of Red Hat Enterprise Linux do not install the fontconfig library. Install it together with the DejaVu fonts:

```bash
sudo dnf install -y fontconfig dejavu-sans-fonts
```

The full `java-<version>-openjdk` packages install fontconfig and fonts as dependencies, and so do the Amazon Corretto packages of Amazon Linux 2023, such as `java-21-amazon-corretto-headless`.

### **Alpine Linux**

In a Dockerfile based on Alpine Linux, install fontconfig and the DejaVu fonts:

```dockerfile
RUN apk add --no-cache fontconfig ttf-dejavu
```

On current Alpine releases, `ttf-dejavu` installs the `font-dejavu` package. Install Java with the `openjdk<version>-jre` or `openjdk<version>-jdk` package, such as `openjdk25-jdk`. The `openjdk<version>-jre-headless` packages of Alpine Linux do not contain Java's font library, so with them the program fails with `UnsatisfiedLinkError: no fontmanager in system library path`, even when fonts are installed.

### **Fonts**

For text to render with the right fonts and metrics, the fonts that your presentations use, or suitable substitutes, must be installed on the system or loaded by your application. See [Deploy Fonts](/slides/java/deploy-fonts/), [Font Substitution](/slides/java/font-substitution/), and [Custom Fonts](/slides/java/custom-font/).

## **Check Your Setup**

To check that the library and its requirements are in place, run a program that saves a presentation and renders a slide to an image. Saving and rendering use the font support of the Java runtime, which is what the Linux requirements above provide.

Save the code below as *CheckSetup.java* in the folder that contains the Aspose.Slides JAR file. To download the JAR file, see [Use the JAR File without Maven](/slides/java/installation/#use-the-jar-file-without-maven).

```java
import com.aspose.slides.*;

public class CheckSetup {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            // Add a rectangle with text to the first slide and save the presentation.
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
            shape.getTextFrame().setText("Hello, Aspose.Slides!");
            presentation.save("hello.pptx", SaveFormat.Pptx);

            // Render the slide at one pixel per point and save the image.
            IImage image = slide.getImage(1f, 1f);
            try {
                image.save("hello.png", ImageFormat.Png);
            } finally {
                image.dispose();
            }
        } finally {
            presentation.dispose();
        }
    }
}
```

With JDK 11 or later, run the program in that folder with the command below. If your JAR file has a different name, change the name in the commands.

```bash
java -cp aspose-slides-26.9-jdk16.jar CheckSetup.java
```

With Java 8, or on a system that has only a JRE, compile the program with `javac` from a JDK and then run the compiled class. On Linux and macOS, run:

```bash
javac -cp aspose-slides-26.9-jdk16.jar CheckSetup.java
java -cp aspose-slides-26.9-jdk16.jar:. CheckSetup
```

On Windows, run the same `javac` command, and then run the class with a semicolon as the class path separator. Keep the quotes, so that PowerShell does not treat the semicolon as the end of the command: `java -cp "aspose-slides-26.9-jdk16.jar;." CheckSetup`.

The program adds a rectangle with text to the first slide and saves the presentation as *hello.pptx* with the [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) method. It then renders the slide with [getImage](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#getImage-float-float-) and saves the result as *hello.png* with [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) in the [ImageFormat.Png](https://reference.aspose.com/slides/java/com.aspose.slides/imageformat/) format. The scale factors of 1 render one pixel per point, so the default 720 × 540 point slide becomes a 720 × 540 pixel image, with the text visible inside the rectangle. Without a license, both files also carry an evaluation watermark; see [Licensing](/slides/java/licensing/). If a requirement is missing, the program stops with one of the errors described in [Linux](#linux).

## **Development Tools**

You can build applications that use Aspose.Slides with any JDK of a supported Java version. Use Apache Maven with Aspose's Maven repository, as described in [Installation](/slides/java/installation/), or any other build tool that can use a Maven repository. You can also add the JAR file to the class path of your IDE or build tool yourself.

## **FAQ**

**Do I need Microsoft PowerPoint installed for conversions and rendering?**

No, PowerPoint is not required. Aspose.Slides is a standalone engine for [creating](/slides/java/create-presentation/), modifying, [converting](/slides/java/convert-presentation/), and [rendering](/slides/java/convert-powerpoint-to-png/) presentations.

**Does Aspose.Slides for Java need a display or a desktop environment on a Linux server?**

No. Aspose.Slides does not need an X server or a display, so it runs on servers and in containers. On Linux, it needs only the font library and fonts described in [Linux](#linux).

**Which fonts are needed for correct rendering?**

The fonts used in the presentation, or suitable [substitutes](/slides/java/font-substitution/), must be available. On Linux and macOS, install the font packages that your presentations need to get consistent rendering.

**Why does a custom font render as a fallback or missing text on Linux?**

If the font file has inconsistent or corrupted name-table entries, the Linux font-matching stack (FreeType/fontconfig) may select an invalid record, causing the font to be unresolved. Using a font version with corrected name-table records or installing a consistent replacement resolves the issue.
