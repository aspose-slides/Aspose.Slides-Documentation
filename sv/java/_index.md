---
title: Aspose.Slides för Java
second_title: Aspose.Slides för Java
type: docs
weight: 20
url: /sv/java/
keywords:
- dokumentation
- presentationhantering
- presentationskonvertering
- PowerPoint
- OpenDocument
- Java
- Aspose.Slides
description: "Börja här: installera Aspose.Slides för Java, skapa en första presentation och hitta guiderna för vanliga uppgifter, distribution och API‑referensen."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Java är ett klassbibliotek för att skapa, läsa, redigera och konvertera PowerPoint‑ och OpenDocument‑presentationer i Java‑applikationer, utan Microsoft PowerPoint.

Det läser och sparar PPT, PPTX, PPS, POT och ODP, inklusive makro‑aktiverade och mall‑varianter, och exporterar till PDF, XPS, HTML, SVG, TIFF, Markdown och bilder.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Kom igång</b></p>
<hr>
<p>GETTING STARTED</p>
<ul>
<li><a href="/slides/sv/java/installation/">Installation</a></li>
<li><a href="/slides/sv/java/create-presentation/">Skapa din första presentation</a></li>
<li><a href="/slides/sv/java/system-requirements/">Systemkrav</a></li>
<li><a href="/slides/sv/java/getting-started/">Kom igång‑guide</a></li>
</ul>
<p>EVALUATE</p>
<ul>
<li><a href="/slides/sv/java/supported-file-formats/">Stödda filformat</a></li>
<li><a href="/slides/sv/java/features-overview/">Funktionsöversikt</a></li>
<li><a href="/slides/sv/java/evaluate-aspose-slides/">Begränsningar för provversion</a></li>
<li><a href="/slides/sv/java/licensing/">Licensiering</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Bygg med Slides</b></p>
<hr>
<p>COMMON TASKS</p>
<ul>
<li><a href="/slides/sv/java/open-presentation/">Öppna en presentation</a></li>
<li><a href="/slides/sv/java/save-presentation/">Spara en presentation</a></li>
<li><a href="/slides/sv/java/convert-powerpoint-to-pdf/">Konvertera till PDF</a></li>
<li><a href="/slides/sv/java/convert-slide/">Rendera bildspel som bilder</a></li>
<li><a href="/slides/sv/java/manage-text/">Redigera text och former</a></li>
</ul>
<p>SLIDES WORKFLOWS</p>
<ul>
<li><a href="/slides/sv/java/powerpoint-charts/">Diagram</a></li>
<li><a href="/slides/sv/java/powerpoint-animation/">Animationer</a></li>
<li><a href="/slides/sv/java/manage-media-files/">Ljud och video</a></li>
<li><a href="/slides/sv/java/presentation-design/">Slide-design</a></li>
<li><a href="/slides/sv/java/merge-presentation/">Slå ihop presentationer</a></li>
</ul>
<p>EXAMPLES</p>
<ul>
<li><a href="/slides/sv/java/examples/">Exempel per bildelement</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-Java">Exempel på GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Distribuera &amp; Support</b></p>
<hr>
<p>DEPLOY</p>
<ul>
<li><a href="/slides/sv/java/system-requirements/#linux">Linux‑förutsättningar</a></li>
<li><a href="/slides/sv/java/how-to-run-aspose-slides-in-docker/">Kör i Docker</a></li>
<li><a href="/slides/sv/java/deploy-fonts/">Typsnitt</a></li>
<li><a href="/slides/sv/java/security/">Säkerhet</a></li>
</ul>
<p>REFERENCE</p>
<ul>
<li><a href="https://reference.aspose.com/slides/java/">API‑referens</a></li>
<li><a href="https://releases.aspose.com/slides/java/release-notes/">Versionsnotiser</a></li>
<li><a href="/slides/sv/java/known-issues/">Kända problem</a></li>
<li><a href="/slides/sv/java/api-limitations/">Begränsningar för metadata</a></li>
<li><a href="https://products.aspose.com/slides/java/">Produktsida</a></li>
<li><a href="https://releases.aspose.com/slides/java/">Nedladdning</a></li>
</ul>
<p>SUPPORT</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Gratis supportforum</a></li>
<li><a href="https://helpdesk.aspose.com/">Betald support‑helpdesk</a></li>
</ul>
</div>
</div>

------

<a name="your-first-presentation"></a>

## **Din första presentation**

Aspose.Slides for Java publiceras i Asposes eget Maven‑arkiv, inte i Maven Central. Skapa en mapp för ett Maven‑projekt och spara denna *pom.xml* i den. Den deklarerar arkivet, lägger till biblioteket och anger klassen som ska köras:

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

Spara denna kod som *src/main/java/HelloSlides.java*:

```java
import com.aspose.slides.*;

public class HelloSlides {
    public static void main(String[] args) {
        // Skapa en presentation. Den innehåller redan en tom bild.
        Presentation presentation = new Presentation();
        try {
            // Hämta den första bilden.
            ISlide slide = presentation.getSlides().get_Item(0);

            // Lägg till en molnform och sätt in text i den.
            IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80);
            autoShape.getTextFrame().setText("Hello, Aspose!");

            // Spara presentationen som en PPTX-fil.
            presentation.save("new_presentation.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

Kör sedan, med JDK 11 eller senare och Apache Maven installerat, detta kommando i projektmappen:

```bash
mvn compile exec:java
```

Programmet sparar *new_presentation.pptx* i projektmappen, med en bild som innehåller en molnform med text. På Linux måste fontconfig och minst ett typsnitt vara installerade; se [Installation](/slides/sv/java/installation/#linux). Utan licens får den sparade filen ett utvärderingsvattenmärke — se [Licensiering](/slides/sv/java/licensing/). För fler sätt att skapa och fylla en presentation, se [Create Presentations](/slides/sv/java/create-presentation/).