---
title: Aspose.Slides för Java
second_title: Aspose.Slides för Java
type: docs
weight: 20
url: /sv/java/
keywords:
- dokumentation
- presentation bearbetning
- presentation konvertering
- PowerPoint
- OpenDocument
- Java
- Aspose.Slides
description: "Börja här: installera Aspose.Slides för Java, skapa en första presentation och hitta guiderna för vanliga uppgifter, API-referensen och supporten."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides för Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides för Java är ett klassbibliotek för att skapa, läsa, redigera och konvertera PowerPoint‑ och OpenDocument‑presentationer i Java‑applikationer, utan Microsoft PowerPoint.

Det läser och sparar PPT, PPTX, PPS, POT och ODP, inklusive makroaktiverade och mallvarianter, och exporterar till PDF, XPS, HTML, SVG, TIFF, Markdown och bilder.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Kom igång</b></p>
<hr>
<p>KOM IGÅNG</p>
<ul>
<li><a href="/slides/sv/java/installation/">Installation</a></li>
<li><a href="/slides/sv/java/create-presentation/">Skapa din första presentation</a></li>
<li><a href="/slides/sv/java/getting-started/">Kom‑igång‑guide</a></li>
</ul>
<p>UTVÄRDERA</p>
<ul>
<li><a href="/slides/sv/java/supported-file-formats/">Stödda filformat</a></li>
<li><a href="/slides/sv/java/evaluate-aspose-slides/">Begränsningar i provversion</a></li>
<li><a href="/slides/sv/java/licensing/">Licensiering</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Bygg med Slides</b></p>
<hr>
<p>VANLIGA UPPGIFTER</p>
<ul>
<li><a href="/slides/sv/java/open-presentation/">Öppna en presentation</a></li>
<li><a href="/slides/sv/java/save-presentation/">Spara en presentation</a></li>
<li><a href="/slides/sv/java/convert-powerpoint-to-pdf/">Konvertera till PDF</a></li>
<li><a href="/slides/sv/java/convert-slide/">Rendera bildspel som bilder</a></li>
<li><a href="/slides/sv/java/manage-text/">Redigera text och former</a></li>
</ul>
<p>SLIDES-ARBETSFLODER</p>
<ul>
<li><a href="/slides/sv/java/powerpoint-charts/">Diagram</a></li>
<li><a href="/slides/sv/java/powerpoint-animation/">Animationer</a></li>
<li><a href="/slides/sv/java/manage-media-files/">Audio och video</a></li>
<li><a href="/slides/sv/java/presentation-design/">Bilddesign</a></li>
<li><a href="/slides/sv/java/merge-presentation/">Slå samman presentationer</a></li>
</ul>
<p>EXEMPEL</p>
<ul>
<li><a href="/slides/sv/java/examples/">Exempel per bildelement</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-Java">Exempel på GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referens &amp; Support</b></p>
<hr>
<p>REFERENS</p>
<ul>
<li><a href="https://reference.aspose.com/slides/java/">API-referens</a></li>
<li><a href="https://releases.aspose.com/slides/java/release-notes/">Versionsanteckningar</a></li>
<li><a href="/slides/sv/java/known-issues/">Kända problem</a></li>
<li><a href="https://releases.aspose.com/slides/java/">Ladda ner</a></li>
</ul>
<p>SUPPORT</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Gratis supportforum</a></li>
<li><a href="https://helpdesk.aspose.com/">Betald supporthelpdesk</a></li>
</ul>
</div>
</div>

------

## **Din första presentation**

Aspose.Slides för Java publiceras i Asposes eget Maven‑arkiv, inte i Maven Central. Skapa en mapp för ett Maven‑projekt och spara denna *pom.xml* i den. Den deklarerar arkivet, lägger till biblioteket och anger klassen som ska köras:

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
        // Skapa en presentation. Den innehåller redan ett tomt bildspel.
        Presentation presentation = new Presentation();
        try {
            // Hämta den första bilden.
            ISlide slide = presentation.getSlides().get_Item(0);

            // Lägg till en molnform och placera text i den.
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

Sedan, med JDK 11 eller senare samt Apache Maven installerat, kör detta kommando i projektmappen:

```bash
mvn compile exec:java
```

Programmet sparar *new_presentation.pptx* i projektmappen, med ett bildspel som innehåller en molnform med text. På Linux måste fontconfig och minst ett teckensnitt vara installerade; se [Installation](/slides/sv/java/installation/#linux). Utan licens innehåller den sparade filen ett utvärderingsvattenmärke — se [Licensiering](/slides/sv/java/licensing/). För fler sätt att skapa och fylla en presentation, se [Skapa presentationer](/slides/sv/java/create-presentation/).