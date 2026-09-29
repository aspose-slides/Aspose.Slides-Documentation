---
title: Deploy Fonts for Aspose.Slides for Java on Linux and in Docker
linktitle: Deploy Fonts
type: docs
weight: 155
url: /java/deploy-fonts/
keywords:
- deploy fonts
- install fonts
- fonts in Docker
- fonts on Linux
- missing fonts
- font substitution
- Microsoft core fonts
- ttf-mscorefonts-installer
- custom fonts
- default font
- server
- container
- PDF conversion
- presentation
- Java
- Aspose.Slides
description: "Deploy fonts for Aspose.Slides for Java on Linux servers and in Docker containers: check which fonts are substituted, install font packages on Debian, Ubuntu, and Alpine, add your own font files, and set a default font."
---

## **Overview**

Aspose.Slides draws text with the fonts that are available to it when it renders a presentation, for example when it converts slides to PDF or to images. A Windows desktop usually has the fonts that presentations use. Linux servers and containers usually have few fonts, so Aspose.Slides draws the text with a substitute font. A substitute has different letter shapes and widths, so lines can wrap differently and text can overflow its shape, and characters that the substitute lacks are not drawn correctly. If no font is installed at all, Java's font support cannot start, and Aspose.Slides stops with an error.

This article shows how to check which fonts Aspose.Slides substitutes, how to install fonts on Debian, Ubuntu, and Alpine Linux, how to add your own font files, and how to set the font that is used when a font is missing. The examples run in Docker on the official Eclipse Temurin images, as in [Run Aspose.Slides for Java in Docker](/slides/java/how-to-run-aspose-slides-in-docker/). The package commands are Dockerfile instructions; on a Linux server, run the same commands as root.

For the font API itself, such as embedding fonts in a presentation and fallback and replacement rules, see [PowerPoint Fonts](/slides/java/powerpoint-fonts/).

## **Check Which Fonts Are Substituted**

The following Maven project reports the fonts that Aspose.Slides substitutes in the current environment. Create a folder named *font-check* and add the files below to it.

*pom.xml* is the one from [Run Aspose.Slides for Java in Docker](/slides/java/how-to-run-aspose-slides-in-docker/#create-the-project), with the artifact ID and the JAR file name changed to *font-check*:

```xml
<project xmlns="http://maven.apache.org/POM/4.0.0">
    <modelVersion>4.0.0</modelVersion>
    <groupId>com.example</groupId>
    <artifactId>font-check</artifactId>
    <version>1.0</version>

    <properties>
        <maven.compiler.release>11</maven.compiler.release>
        <project.build.sourceEncoding>UTF-8</project.build.sourceEncoding>
    </properties>

    <repositories>
        <repository>
            <id>AsposeJavaAPI</id>
            <name>Aspose Java API</name>
            <url>https://releases.aspose.com/java/repo/</url>
        </repository>
    </repositories>

    <dependencies>
        <dependency>
            <groupId>com.aspose</groupId>
            <artifactId>aspose-slides</artifactId>
            <version>26.9</version>
            <classifier>jdk16</classifier>
        </dependency>
    </dependencies>

    <build>
        <finalName>font-check</finalName>
        <plugins>
            <plugin>
                <groupId>org.apache.maven.plugins</groupId>
                <artifactId>maven-compiler-plugin</artifactId>
                <version>3.15.0</version>
            </plugin>
            <plugin>
                <groupId>org.apache.maven.plugins</groupId>
                <artifactId>maven-dependency-plugin</artifactId>
                <version>3.11.0</version>
                <executions>
                    <execution>
                        <phase>package</phase>
                        <goals>
                            <goal>copy-dependencies</goal>
                        </goals>
                        <configuration>
                            <outputDirectory>${project.build.directory}/lib</outputDirectory>
                        </configuration>
                    </execution>
                </executions>
            </plugin>
        </plugins>
    </build>
</project>
```

*src/main/java/FontCheck.java* adds one text box per font name to a slide and assigns the font with the [setLatinFont](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setLatinFont-com.aspose.slides.IFontData-) method. The font names come from the command line; without arguments, the program checks Calibri, Arial, and Times New Roman. It prints the folders in which Aspose.Slides looks for fonts ([FontsLoader.getFontFolders](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#getFontFolders--)), renders the slide to *output/fonts.pdf*, and prints the substitutions reported by [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions--). The two optional steps at the start, loading a *fonts* folder and reading a `DEFAULT_FONT` variable, are explained later in this article.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.LinkedHashSet;
import java.util.List;
import java.util.Set;

public class FontCheck {
    public static void main(String[] args) {
        // The fonts to check: the command-line arguments, or three common Office fonts.
        String[] fontNames = args.length > 0 ? args : new String[] { "Calibri", "Arial", "Times New Roman" };

        // Load the font files from the fonts folder in the working directory, if there is one.
        File appFontFolder = new File("fonts");
        if (appFontFolder.isDirectory()) {
            FontsLoader.loadExternalFonts(new String[] { appFontFolder.getAbsolutePath() });
        }

        // Use the font named in the DEFAULT_FONT environment variable, if it is set, for text whose font is missing.
        LoadOptions loadOptions = new LoadOptions();
        String defaultFont = System.getenv("DEFAULT_FONT");
        if (defaultFont != null && !defaultFont.isEmpty()) {
            loadOptions.setDefaultRegularFont(defaultFont);
        }

        Set<String> fontFolders = new LinkedHashSet<>(Arrays.asList(FontsLoader.getFontFolders()));
        System.out.println("Font folders: " + String.join(", ", fontFolders));

        Presentation presentation = new Presentation(loadOptions);
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            for (int i = 0; i < fontNames.length; i++) {
                IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50 + i * 80, 600, 60);
                shape.getTextFrame().setText("This text is set in " + fontNames[i] + ".");
                shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new FontData(fontNames[i]));
            }

            File outputFolder = new File("output");
            outputFolder.mkdirs();
            presentation.save(new File(outputFolder, "fonts.pdf").getPath(), SaveFormat.Pdf);

            List<FontSubstitutionInfo> substitutions = new ArrayList<>();
            for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions()) {
                substitutions.add(substitution);
            }

            if (substitutions.isEmpty()) {
                System.out.println("No font substitutions.");
            } else {
                System.out.println("Font substitutions:");
                for (FontSubstitutionInfo substitution : substitutions) {
                    System.out.println("  " + substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
                }
            }
        } finally {
            presentation.dispose();
        }
    }
}
```

`getFontFolders` can return a folder more than once, so the program collects the folders in a set before it prints them.

*.dockerignore* keeps local build results out of the build context:

```text
target/
output/
```

*Dockerfile* builds the program with the Maven image and runs it on the Eclipse Temurin Java runtime image, which already contains fontconfig and the DejaVu fonts. [Run Aspose.Slides for Java in Docker](/slides/java/how-to-run-aspose-slides-in-docker/) explains each instruction.

```dockerfile
FROM maven:3.9-eclipse-temurin-21 AS build
WORKDIR /src
COPY pom.xml .
RUN mvn -B dependency:go-offline
COPY src ./src
RUN mvn -B package

FROM eclipse-temurin:21-jre
WORKDIR /app
COPY --from=build /src/target/font-check.jar .
COPY --from=build /src/target/lib ./lib
RUN mkdir output && chown ubuntu output
USER ubuntu
ENTRYPOINT ["java", "-cp", "font-check.jar:lib/*", "FontCheck"]
```

Build the image and run the check:

```bash
docker build -t font-check .
docker run --rm font-check
```

The image has only the DejaVu fonts, so all three fonts are replaced with DejaVu Sans:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> DejaVu Sans
  Arial -> DejaVu Sans
  Times New Roman -> DejaVu Sans
```

To check the fonts of your own presentations, pass their names as arguments, for example `docker run --rm font-check "Segoe UI" Consolas`. To copy *output/fonts.pdf* out of the container, use the commands in [Copy the Output to Your Machine](/slides/java/how-to-run-aspose-slides-in-docker/#copy-the-output-to-your-machine).

## **Install Fonts on Debian and Ubuntu**

### **Microsoft Core Fonts**

The `ttf-mscorefonts-installer` package downloads and installs Microsoft's core fonts for the web, among them Arial, Times New Roman, Courier New, Verdana, Georgia, and Trebuchet MS. The fonts are licensed under Microsoft's end-user license agreement (EULA), and the package installs them only after the EULA is accepted. A Docker build cannot answer the prompt, so the installer declines the EULA and installs no fonts, while `apt-get install` still reports success. Accept the EULA with `debconf-set-selections` **before** the package is installed. Accepting it in a later instruction does not help: the package is then already installed, and apt does not run its installer again.

Add this instruction to the runtime stage of the *Dockerfile*, directly after its `FROM` line, so that it runs as root, before the `USER` instruction:

```dockerfile
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

Build the image and run the check again with the same two commands. Arial and Times New Roman are now installed:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

Calibri, the default font of a presentation that Aspose.Slides creates, is not one of the core fonts, so it is still replaced. See [Set a Default Font for Missing Fonts](#set-a-default-font-for-missing-fonts).

The Ubuntu-based Eclipse Temurin images enable `multiverse`, the Ubuntu component that contains the package. On Debian, the package is in the `contrib` component, which the Debian images do not enable. In a Debian-based runtime stage, such as the one in [Use Another Base Image](/slides/java/how-to-run-aspose-slides-in-docker/#use-another-base-image), enable `contrib` in the same instruction:

```dockerfile
RUN sed -i 's/^Components: main$/Components: main contrib/' /etc/apt/sources.list.d/debian.sources \
    && echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

### **Other Font Packages**

Debian and Ubuntu also package freely licensed fonts, for example:

| Package | Fonts |
|---|---|
| `fonts-dejavu-core` | DejaVu Sans, DejaVu Serif, DejaVu Sans Mono |
| `fonts-liberation` | Liberation Sans, Serif, and Mono, with the same metrics as Arial, Times New Roman, and Courier New |
| `fonts-crosextra-carlito` | Carlito, with the same metrics as Calibri |
| `fonts-crosextra-caladea` | Caladea, with the same metrics as Cambria |

Install them with `apt-get install` in a `RUN` instruction of the runtime stage, the same way as the Microsoft core fonts. Aspose.Slides for Java does not apply the font aliases of the Linux font configuration: with `fonts-liberation` installed, text in Arial is still drawn with the general substitute font, not with Liberation Sans. To use a metric-compatible font in place of a missing one, set it as the [default font](#set-a-default-font-for-missing-fonts) or add a [font substitution rule](/slides/java/font-substitution/).

## **Add Your Own Font Files**

Fonts that the distributions do not package, such as your organization's fonts or other fonts that you are licensed to use on the server, can be added as font files. Put the font files, for example *.ttf* files, in a folder named *fonts* inside the *font-check* folder. The examples below use the files of Carlito, a font with the same metrics as Calibri, which you can download from [Google Fonts](https://fonts.google.com/specimen/Carlito).

### **Install the Fonts in a System Font Folder**

Aspose.Slides reads the fonts in the folders printed on the `Font folders` line. To install your fonts for every application in the image, copy them into */usr/local/share/fonts*, the folder for locally installed fonts. Add this instruction to the runtime stage of the *Dockerfile*, after the `RUN` instruction that installs the Microsoft core fonts:

```dockerfile
COPY fonts/ /usr/local/share/fonts/
```

Rebuild the image, then check Calibri and Carlito:

```bash
docker build -t font-check .
docker run --rm font-check Calibri Carlito
```

Carlito is no longer substituted:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

### **Load Fonts from the Application Folder**

Instead of installing the fonts in a system folder, you can ship them with the application and load them with [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---). The fonts are then available to Aspose.Slides only, and they are deployed together with the application. *FontCheck* does this: when its working directory, */app* in the container, contains a *fonts* folder, the program passes that folder to `loadExternalFonts` before it creates the presentation. [Custom Font](/slides/java/custom-font/) describes the other ways to supply fonts, such as loading them from memory.

In the *Dockerfile*, remove the `COPY fonts/ /usr/local/share/fonts/` instruction and add this one after the instruction that copies the *lib* folder:

```dockerfile
COPY fonts/ ./fonts/
```

Rebuild the image and run the check with the same two commands. The application folder now appears among the font folders, and Carlito is still not substituted:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

`loadExternalFonts` adds fonts to the installed ones, but Java's font support still needs at least one installed font. In an image without any, `loadExternalFonts` stops with the error "Fontconfig head is null, check your fonts or fonts configuration".

## **Set a Default Font for Missing Fonts**

When a font is missing, Aspose.Slides uses a substitute that it chooses itself. To choose it yourself, pass the font name to the [setDefaultRegularFont](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setDefaultRegularFont-java.lang.String-) method of [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/) and pass the options to the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) constructor. *FontCheck* reads the font name from the `DEFAULT_FONT` environment variable. With Carlito loaded, use it for missing fonts:

```bash
docker run --rm -e DEFAULT_FONT=Carlito font-check
```

Calibri is now drawn with Carlito, whose characters have the same widths as those of Calibri, so the text keeps its line breaks:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Carlito
```

The default font replaces every missing font. To map individual fonts, for example Arial to Liberation Sans and Calibri to Carlito, use [font substitution rules](/slides/java/font-substitution/). Rules change the rendered output, but `getSubstitutions` does not reflect them, so check the fonts in the output file instead. For Asian text, also call [setDefaultAsianFont](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setDefaultAsianFont-java.lang.String-); see [Default Font](/slides/java/default-font/).

## **Install Fonts on Alpine Linux**

The Alpine-based Eclipse Temurin image also contains the DejaVu fonts; [Run on Alpine Linux](/slides/java/how-to-run-aspose-slides-in-docker/#run-on-alpine-linux) describes its runtime stage. To install the Microsoft core fonts on it as well, replace the runtime stage of the *font-check* Dockerfile with this one:

```dockerfile
FROM eclipse-temurin:21-jre-alpine
RUN apk add --no-cache msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -f
WORKDIR /app
COPY --from=build /src/target/font-check.jar .
COPY --from=build /src/target/lib ./lib
RUN adduser -D app && mkdir output && chown app output
USER app
ENTRYPOINT ["java", "-cp", "font-check.jar:lib/*", "FontCheck"]
```

`update-ms-fonts` downloads and installs the same Microsoft core fonts as the Debian and Ubuntu package, and their EULA applies in the same way. `fc-cache` updates the font cache of fontconfig. Build the image and run the check with the two commands from [Check Which Fonts Are Substituted](#check-which-fonts-are-substituted). It prints:

```text
Font folders: /usr/share/fonts, /home/app/.local/share/fonts, /home/app/.fonts
Font substitutions:
  Calibri -> Arial
```

The other steps on this page work the same way on Alpine: copy the *fonts* folder to */usr/local/share/fonts* or to the application folder, and set `DEFAULT_FONT` to choose the default font. The Alpine image has no */usr/local/share/fonts* folder, so that folder appears on the `Font folders` line only after a `COPY` instruction creates it.

## **FAQ**

**Why does a presentation look different when it is converted on a server?**

The server does not have the fonts that the presentation uses, so Aspose.Slides draws the text with a substitute font whose letters have other widths. Run *FontCheck* with the presentation's font names to see which fonts are substituted, then install those fonts or load them from the application folder.

**The build installed ttf-mscorefonts-installer, but Arial is still substituted. Why?**

The EULA was not accepted before the package was installed, so the installer skipped the fonts. Put the `debconf-set-selections` command before `apt-get install` in the instruction that installs the package, as shown in [Microsoft Core Fonts](#microsoft-core-fonts), and rebuild the image.

**Does the computer that opens the PDF need the fonts?**

No. In these examples, the PDF contains the fonts that were used to draw the text, so it looks the same on any computer. The fonts are needed only where Aspose.Slides renders the presentation.
