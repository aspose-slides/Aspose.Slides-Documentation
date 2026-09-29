---
title: Aspose.Slides for Java
second_title: Aspose.Slides for Java
type: docs
weight: 20
url: /java/
keywords:
- documentation
- presentation processing
- presentation conversion
- PowerPoint
- OpenDocument
- Java
- Aspose.Slides
description: "Start here: install Aspose.Slides for Java, create a first presentation, and find the guides for common tasks, deployment and the API reference."
is_root: true
---

<img src="home_1.png" alt="Aspose.Slides for Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Java is a class library for creating, reading, editing and converting PowerPoint and OpenDocument presentations in Java applications, without Microsoft PowerPoint.

It loads and saves PPT, PPTX, PPS, POT and ODP, including macro-enabled and template variants, and exports to PDF, XPS, HTML, SVG, TIFF, Markdown and images.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Get Started</b></p>
<hr>
<p>GETTING STARTED</p>
<ul>
<li><a href="/slides/java/installation/">Installation</a></li>
<li><a href="/slides/java/create-presentation/">Create your first presentation</a></li>
<li><a href="/slides/java/system-requirements/">System requirements</a></li>
<li><a href="/slides/java/getting-started/">Getting started guide</a></li>
</ul>
<p>EVALUATE</p>
<ul>
<li><a href="/slides/java/supported-file-formats/">Supported file formats</a></li>
<li><a href="/slides/java/features-overview/">Features overview</a></li>
<li><a href="/slides/java/evaluate-aspose-slides/">Trial limitations</a></li>
<li><a href="/slides/java/licensing/">Licensing</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Build with Slides</b></p>
<hr>
<p>COMMON TASKS</p>
<ul>
<li><a href="/slides/java/open-presentation/">Open a presentation</a></li>
<li><a href="/slides/java/save-presentation/">Save a presentation</a></li>
<li><a href="/slides/java/convert-powerpoint-to-pdf/">Convert to PDF</a></li>
<li><a href="/slides/java/convert-slide/">Render slides as images</a></li>
<li><a href="/slides/java/manage-text/">Edit text and shapes</a></li>
</ul>
<p>SLIDES WORKFLOWS</p>
<ul>
<li><a href="/slides/java/powerpoint-charts/">Charts</a></li>
<li><a href="/slides/java/powerpoint-animation/">Animations</a></li>
<li><a href="/slides/java/manage-media-files/">Audio and video</a></li>
<li><a href="/slides/java/presentation-design/">Slide design</a></li>
<li><a href="/slides/java/merge-presentation/">Merge presentations</a></li>
</ul>
<p>EXAMPLES</p>
<ul>
<li><a href="/slides/java/examples/">Examples by slide element</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-Java">Examples on GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Deploy &amp; Support</b></p>
<hr>
<p>DEPLOY</p>
<ul>
<li><a href="/slides/java/system-requirements/#linux">Linux prerequisites</a></li>
<li><a href="/slides/java/how-to-run-aspose-slides-in-docker/">Run in Docker</a></li>
<li><a href="/slides/java/deploy-fonts/">Fonts</a></li>
<li><a href="/slides/java/security/">Security</a></li>
</ul>
<p>REFERENCE</p>
<ul>
<li><a href="https://reference.aspose.com/slides/java/">API reference</a></li>
<li><a href="https://releases.aspose.com/slides/java/release-notes/">Release notes</a></li>
<li><a href="/slides/java/known-issues/">Known issues</a></li>
<li><a href="/slides/java/api-limitations/">Output metadata limitations</a></li>
<li><a href="https://releases.aspose.com/slides/java/">Download</a></li>
</ul>
<p>SUPPORT</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Free support forum</a></li>
<li><a href="https://helpdesk.aspose.com/">Paid support helpdesk</a></li>
</ul>
</div>
</div>

------

<a name="your-first-presentation"></a>

## **Your first presentation**

Aspose.Slides for Java is published in Aspose's own Maven repository, not in Maven Central. Create a folder for a Maven project and save this *pom.xml* in it. It declares the repository, adds the library, and names the class to run:

```xml
<project xmlns="http://maven.apache.org/POM/4.0.0">
    <modelVersion>4.0.0</modelVersion>
    <groupId>com.example</groupId>
    <artifactId>hello-slides</artifactId>
    <version>1.0</version>

    <properties>
        <maven.compiler.release>11</maven.compiler.release>
        <project.build.sourceEncoding>UTF-8</project.build.sourceEncoding>
        <exec.mainClass>HelloSlides</exec.mainClass>
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
        <plugins>
            <plugin>
                <groupId>org.apache.maven.plugins</groupId>
                <artifactId>maven-compiler-plugin</artifactId>
                <version>3.15.0</version>
            </plugin>
        </plugins>
    </build>
</project>
```

Save this code as *src/main/java/HelloSlides.java*:

```java
import com.aspose.slides.*;

public class HelloSlides {
    public static void main(String[] args) {
        // Create a presentation. It already contains one empty slide.
        Presentation presentation = new Presentation();
        try {
            // Get the first slide.
            ISlide slide = presentation.getSlides().get_Item(0);

            // Add a cloud shape and put text in it.
            IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80);
            autoShape.getTextFrame().setText("Hello, Aspose!");

            // Save the presentation as a PPTX file.
            presentation.save("new_presentation.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

Then, with JDK 11 or later and Apache Maven installed, run this command in the project folder:

```bash
mvn compile exec:java
```

The program saves *new_presentation.pptx* in the project folder, with one slide holding a cloud shape with text. On Linux, fontconfig and at least one font must be installed; see [Installation](/slides/java/installation/#linux). Without a license, the saved file carries an evaluation watermark — see [Licensing](/slides/java/licensing/). For more ways to create and fill a presentation, see [Create Presentations](/slides/java/create-presentation/).
