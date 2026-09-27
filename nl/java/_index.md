---
title: Aspose.Slides voor Java
second_title: Aspose.Slides voor Java
type: docs
weight: 20
url: /nl/java/
keywords:
- documentatie
- presentatieverwerking
- presentatieconversie
- PowerPoint
- OpenDocument
- Java
- Aspose.Slides
description: "Begin hier: installeer Aspose.Slides for Java, maak een eerste presentatie en vind de gidsen voor veelvoorkomende taken, de API-referentie en ondersteuning."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Java is een class library voor het maken, lezen, bewerken en converteren van PowerPoint- en OpenDocument‑presentaties in Java‑toepassingen, zonder Microsoft PowerPoint.

Het laadt en slaat PPT, PPTX, PPS, POT en ODP op, inclusief macro‑ingeschakelde en sjabloonvarianten, en exporteert naar PDF, XPS, HTML, SVG, TIFF, Markdown en afbeeldingen.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Aan de slag</b></p>
<hr>
<p>GETTING STARTED</p>
<ul>
<li><a href="/slides/nl/java/installation/">Installatie</a></li>
<li><a href="/slides/nl/java/create-presentation/">Maak uw eerste presentatie</a></li>
<li><a href="/slides/nl/java/getting-started/">Startgids</a></li>
</ul>
<p>EVALUATE</p>
<ul>
<li><a href="/slides/nl/java/supported-file-formats/">Ondersteunde bestandsformaten</a></li>
<li><a href="/slides/nl/java/evaluate-aspose-slides/">Beperking van de proefversie</a></li>
<li><a href="/slides/nl/java/licensing/">Licenties</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Bouw met Slides</b></p>
<hr>
<p>COMMON TASKS</p>
<ul>
<li><a href="/slides/nl/java/open-presentation/">Open een presentatie</a></li>
<li><a href="/slides/nl/java/save-presentation/">Sla een presentatie op</a></li>
<li><a href="/slides/nl/java/convert-powerpoint-to-pdf/">Converteren naar PDF</a></li>
<li><a href="/slides/nl/java/convert-slide/">Render dia's als afbeeldingen</a></li>
<li><a href="/slides/nl/java/manage-text/">Tekst en vormen bewerken</a></li>
</ul>
<p>SLIDES WORKFLOWS</p>
<ul>
<li><a href="/slides/nl/java/powerpoint-charts/">Grafieken</a></li>
<li><a href="/slides/nl/java/powerpoint-animation/">Animaties</a></li>
<li><a href="/slides/nl/java/manage-media-files/">Audio en video</a></li>
<li><a href="/slides/nl/java/presentation-design/">Diaontwerp</a></li>
<li><a href="/slides/nl/java/merge-presentation/">Presentaties samenvoegen</a></li>
</ul>
<p>EXAMPLES</p>
<ul>
<li><a href="/slides/nl/java/examples/">Voorbeelden per dia‑element</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-Java">Voorbeelden op GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referentie &amp; Support</b></p>
<hr>
<p>REFERENCE</p>
<ul>
<li><a href="https://reference.aspose.com/slides/nl/java/">API-referentie</a></li>
<li><a href="https://releases.aspose.com/slides/nl/java/release-notes/">Release‑opmerkingen</a></li>
<li><a href="/slides/nl/java/known-issues/">Bekende problemen</a></li>
<li><a href="https://releases.aspose.com/slides/nl/java/">Download</a></li>
</ul>
<p>SUPPORT</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/nl/11">Gratis ondersteuningsforum</a></li>
<li><a href="https://helpdesk.aspose.com/">Betaalde ondersteuningshelpdesk</a></li>
</ul>
</div>
</div>

------

## **Uw eerste presentatie**

Aspose.Slides for Java wordt gepubliceerd in de eigen Maven‑repository van Aspose, niet in Maven Central. Maak een map aan voor een Maven‑project en sla hierin dit *pom.xml* bestand op. Het declareert de repository, voegt de bibliotheek toe en geeft de klasse op die moet worden uitgevoerd:

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

Sla deze code op als *src/main/java/HelloSlides.java*:

```java
import com.aspose.slides.*;

public class HelloSlides {
    public static void main(String[] args) {
        // Maak een presentatie. Deze bevat al één lege dia.
        Presentation presentation = new Presentation();
        try {
            // Haal de eerste dia op.
            ISlide slide = presentation.getSlides().get_Item(0);

            // Voeg een wolkvorm toe en zet er tekst in.
            IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80);
            autoShape.getTextFrame().setText("Hello, Aspose!");

            // Sla de presentatie op als een PPTX‑bestand.
            presentation.save("new_presentation.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

Voer vervolgens, met JDK 11 of hoger en Apache Maven geïnstalleerd, dit commando uit in de projectmap:

```bash
mvn compile exec:java
```

Het programma slaat *new_presentation.pptx* op in de projectmap, met één dia waarop een wolk‑vorm met tekst staat. Op Linux moeten fontconfig en ten minste één lettertype geïnstalleerd zijn; zie [Installatie](/slides/nl/java/installation/#linux). Zonder licentie bevat het opgeslagen bestand een evaluatiewatermerk — zie [Licenties](/slides/nl/java/licensing/). Voor meer manieren om een presentatie te maken en te vullen, zie [Presentaties maken](/slides/nl/java/create-presentation/).