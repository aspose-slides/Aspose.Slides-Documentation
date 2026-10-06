---
title: Aspose.Slides for Java
second_title: Aspose.Slides for Java
type: docs
weight: 20
url: /it/java/
keywords:
- documentazione
- elaborazione delle presentazioni
- conversione delle presentazioni
- PowerPoint
- OpenDocument
- Java
- Aspose.Slides
description: "Inizia qui: installa Aspose.Slides per Java, crea una prima presentazione e trova le guide per attività comuni, distribuzione e riferimento API."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Java è una libreria di classi per creare, leggere, modificare e convertire presentazioni PowerPoint e OpenDocument in applicazioni Java, senza Microsoft PowerPoint.

Carica e salva i formati PPT, PPTX, PPS, POT e ODP, comprese le varianti con macro e i modelli, ed esporta in PDF, XPS, HTML, SVG, TIFF, Markdown e immagini.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Inizia</b></p>
<hr>
<p>INIZIO</p>
<ul>
<li><a href="/slides/it/java/installation/">Installazione</a></li>
<li><a href="/slides/it/java/create-presentation/">Crea la tua prima presentazione</a></li>
<li><a href="/slides/it/java/system-requirements/">Requisiti di sistema</a></li>
<li><a href="/slides/it/java/getting-started/">Guida introduttiva</a></li>
</ul>
<p>VALUTAZIONE</p>
<ul>
<li><a href="/slides/it/java/supported-file-formats/">Formati file supportati</a></li>
<li><a href="/slides/it/java/features-overview/">Panoramica delle funzionalità</a></li>
<li><a href="/slides/it/java/evaluate-aspose-slides/">Limitazioni della versione di prova</a></li>
<li><a href="/slides/it/java/licensing/">Licenze</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Crea con Slides</b></p>
<hr>
<p>OPERAZIONI COMUNI</p>
<ul>
<li><a href="/slides/it/java/open-presentation/">Apri una presentazione</a></li>
<li><a href="/slides/it/java/save-presentation/">Salva una presentazione</a></li>
<li><a href="/slides/it/java/convert-powerpoint-to-pdf/">Converti in PDF</a></li>
<li><a href="/slides/it/java/convert-slide/">Renderizza diapositive come immagini</a></li>
<li><a href="/slides/it/java/manage-text/">Modifica testo e forme</a></li>
</ul>
<p>FLUSSI DI LAVORO DI SLIDES</p>
<ul>
<li><a href="/slides/it/java/powerpoint-charts/">Grafici</a></li>
<li><a href="/slides/it/java/powerpoint-animation/">Animazioni</a></li>
<li><a href="/slides/it/java/manage-media-files/">Audio e video</a></li>
<li><a href="/slides/it/java/presentation-design/">Design della diapositiva</a></li>
<li><a href="/slides/it/java/merge-presentation/">Unisci presentazioni</a></li>
</ul>
<p>ESEMPI</p>
<ul>
<li><a href="/slides/it/java/examples/">Esempi per elemento della diapositiva</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-Java">Esempi su GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Distribuzione &amp; Supporto</b></p>
<hr>
<p>DISTRIBUZIONE</p>
<ul>
<li><a href="/slides/it/java/system-requirements/#linux">Prerequisiti per Linux</a></li>
<li><a href="/slides/it/java/how-to-run-aspose-slides-in-docker/">Esegui in Docker</a></li>
<li><a href="/slides/it/java/deploy-fonts/">Font</a></li>
<li><a href="/slides/it/java/security/">Sicurezza</a></li>
</ul>
<p>RIFERIMENTO</p>
<ul>
<li><a href="https://reference.aspose.com/slides/it/java/">Riferimento API</a></li>
<li><a href="https://releases.aspose.com/slides/it/java/release-notes/">Note di rilascio</a></li>
<li><a href="/slides/it/java/known-issues/">Problemi noti</a></li>
<li><a href="/slides/it/java/api-limitations/">Limitazioni dei metadati di output</a></li>
<li><a href="https://releases.aspose.com/slides/it/java/">Download</a></li>
</ul>
<p>SUPPORTO</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/it/11">Forum di supporto gratuito</a></li>
<li><a href="https://helpdesk.aspose.com/">Helpdesk di supporto a pagamento</a></li>
</ul>
</div>
</div>

------

<a name="your-first-presentation"></a>

## **La tua prima presentazione**

Aspose.Slides for Java è pubblicato nel repository Maven di Aspose, non su Maven Central. Crea una cartella per un progetto Maven e salva qui il *pom.xml*. Dichiarano il repository, aggiungono la libreria e indicano la classe da eseguire:

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

Salva questo codice come *src/main/java/HelloSlides.java*:

```java
import com.aspose.slides.*;

public class HelloSlides {
    public static void main(String[] args) {
        // Crea una presentazione. Contiene già una diapositiva vuota.
        Presentation presentation = new Presentation();
        try {
            // Ottieni la prima diapositiva.
            ISlide slide = presentation.getSlides().get_Item(0);

            // Aggiungi una forma nuvola e inserisci del testo.
            IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80);
            autoShape.getTextFrame().setText("Hello, Aspose!");

            // Salva la presentazione come file PPTX.
            presentation.save("new_presentation.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

Quindi, con JDK 11 o successivo e Apache Maven installati, esegui questo comando nella cartella del progetto:

```bash
mvn compile exec:java
```

Il programma salva *new_presentation.pptx* nella cartella del progetto, con una diapositiva contenente una forma nuvola con testo. Su Linux, fontconfig e almeno un font devono essere installati; vedi [Installazione](/slides/it/java/installation/#linux). Senza licenza, il file salvato ha un watermark di valutazione — vedi [Licenze](/slides/it/java/licensing/). Per ulteriori modi di creare e compilare una presentazione, vedi [Crea presentazioni](/slides/it/java/create-presentation/).