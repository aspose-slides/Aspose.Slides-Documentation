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
description: "Begin hier: installeer Aspose.Slides voor Java, maak een eerste presentatie en vind de handleidingen voor algemene taken, implementatie en de API‑referentie."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Java is een klassebibliotheek voor het maken, lezen, bewerken en converteren van PowerPoint- en OpenDocument‑presentaties in Java‑applicaties, zonder Microsoft PowerPoint.

Het laadt en slaat PPT, PPTX, PPS, POT en ODP, inclusief macro‑enabled en sjabloonvarianten, en exporteert naar PDF, XPS, HTML, SVG, TIFF, Markdown en afbeeldingen.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Aan de slag</b></p>
<hr>
<p>AAN DE SLAG</p>
<ul>
<li><a href="/slides/nl/java/installation/">Installatie</a></li>
<li><a href="/slides/nl/java/create-presentation/">Maak je eerste presentatie</a></li>
<li><a href="/slides/nl/java/system-requirements/">Systeemvereisten</a></li>
<li><a href="/slides/nl/java/getting-started/">Handleiding voor eerste stappen</a></li>
</ul>
<p>EVALUEREN</p>
<ul>
<li><a href="/slides/nl/java/supported-file-formats/">Ondersteunde bestandsformaten</a></li>
<li><a href="/slides/nl/java/features-overview/">Functies overzicht</a></li>
<li><a href="/slides/nl/java/evaluate-aspose-slides/">Beperkingen van de proefversie</a></li>
<li><a href="/slides/nl/java/licensing/">Licenties</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Bouw met Slides</b></p>
<hr>
<p>ALGEMENE TAKEN</p>
<ul>
<li><a href="/slides/nl/java/open-presentation/">Open een presentatie</a></li>
<li><a href="/slides/nl/java/save-presentation/">Sla een presentatie op</a></li>
<li><a href="/slides/nl/java/convert-powerpoint-to-pdf/">Converteer naar PDF</a></li>
<li><a href="/slides/nl/java/convert-slide/">Render dia's als afbeeldingen</a></li>
<li><a href="/slides/nl/java/manage-text/">Tekst en vormen bewerken</a></li>
</ul>
<p>SLIDES-WERKSTROMEN</p>
<ul>
<li><a href="/slides/nl/java/powerpoint-charts/">Grafieken</a></li>
<li><a href="/slides/nl/java/powerpoint-animation/">Animaties</a></li>
<li><a href="/slides/nl/java/manage-media-files/">Audio en video</a></li>
<li><a href="/slides/nl/java/presentation-design/">Dia‑ontwerp</a></li>
<li><a href="/slides/nl/java/merge-presentation/">Presentaties samenvoegen</a></li>
</ul>
<p>VOORBEELDEN</p>
<ul>
<li><a href="/slides/nl/java/examples/">Voorbeelden per dia‑element</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-Java">Voorbeelden op GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Implementatie &amp; ondersteuning</b></p>
<hr>
<p>IMPLEMENTEREN</p>
<ul>
<li><a href="/slides/nl/java/system-requirements/#linux">Linux‑vereisten</a></li>
<li><a href="/slides/nl/java/how-to-run-aspose-slides-in-docker/">Uitvoeren in Docker</a></li>
<li><a href="/slides/nl/java/deploy-fonts/">Lettertypen</a></li>
<li><a href="/slides/nl/java/security/">Beveiliging</a></li>
</ul>
<p>REFERENTIE</p>
<ul>
<li><a href="https://reference.aspose.com/slides/java/">API‑referentie</a></li>
<li><a href="https://releases.aspose.com/slides/java/release-notes/">Release‑opmerkingen</a></li>
<li><a href="/slides/nl/java/known-issues/">Gekende problemen</a></li>
<li><a href="/slides/nl/java/api-limitations/">Beperkingen van uitvoer‑metadata</a></li>
<li><a href="https://products.aspose.com/slides/java/">Productpagina</a></li>
<li><a href="https://releases.aspose.com/slides/java/">Download</a></li>
</ul>
<p>ONDERSTEUNING</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Gratis ondersteuningsforum</a></li>
<li><a href="https://helpdesk.aspose.com/">Betaalde ondersteunings‑helpdesk</a></li>
</ul>
</div>
</div>

------

<a name="your-first-presentation"></a>

## **Je eerste presentatie**

Aspose.Slides for Java wordt gepubliceerd in de eigen Maven‑repository van Aspose, niet in Maven Central. Maak een map voor een Maven‑project en sla dit *pom.xml* daarin op. Het declareert de repository, voegt de bibliotheek toe en geeft de te starten klasse aan:

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

            // Sla de presentatie op als een PPTX-bestand.
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

Het programma slaat *new_presentation.pptx* op in de projectmap, met één dia die een wolkvorm met tekst bevat. Op Linux moeten fontconfig en minstens één lettertype geïnstalleerd zijn; zie [Installatie](/slides/nl/java/installation/#linux). Zonder licentie bevat het opgeslagen bestand een evaluatiewatermerk — zie [Licenties](/slides/nl/java/licensing/). Voor meer mogelijkheden om een presentatie te maken en in te vullen, zie [Presentaties maken](/slides/nl/java/create-presentation/).