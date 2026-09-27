---
title: Aspose.Slides pro Java
second_title: Aspose.Slides pro Java
type: docs
weight: 20
url: /cs/java/
keywords:
- dokumentace
- zpracování prezentací
- konverze prezentací
- PowerPoint
- OpenDocument
- Java
- Aspose.Slides
description: "Začněte zde: nainstalujte Aspose.Slides pro Java, vytvořte první prezentaci a najděte návody na běžné úkoly, API reference a podporu."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Java je knihovna tříd pro vytváření, čtení, úpravu a převod prezentací PowerPoint a OpenDocument v aplikacích Java, bez Microsoft PowerPoint.

Načítá a ukládá PPT, PPTX, PPS, POT a ODP, včetně variant s makry a šablon, a exportuje do PDF, XPS, HTML, SVG, TIFF, Markdown a obrázků.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Začínáme</b></p>
<hr>
<p>Jak začít</p>
<ul>
<li><a href="/slides/cs/java/installation/">Instalace</a></li>
<li><a href="/slides/cs/java/create-presentation/">Vytvořte svou první prezentaci</a></li>
<li><a href="/slides/cs/java/getting-started/">Průvodce pro začátečníky</a></li>
</ul>
<p>Vyzkoušení</p>
<ul>
<li><a href="/slides/cs/java/supported-file-formats/">Podporované formáty souborů</a></li>
<li><a href="/slides/cs/java/evaluate-aspose-slides/">Omezení zkušební verze</a></li>
<li><a href="/slides/cs/java/licensing/">Licencování</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Vytvářejte s Slides</b></p>
<hr>
<p>Běžné úkoly</p>
<ul>
<li><a href="/slides/cs/java/open-presentation/">Otevřít prezentaci</a></li>
<li><a href="/slides/cs/java/save-presentation/">Uložit prezentaci</a></li>
<li><a href="/slides/cs/java/convert-powerpoint-to-pdf/">Převést do PDF</a></li>
<li><a href="/slides/cs/java/convert-slide/">Vykreslovat snímky jako obrázky</a></li>
<li><a href="/slides/cs/java/manage-text/">Upravit text a tvary</a></li>
</ul>
<p>Workflowy Slides</p>
<ul>
<li><a href="/slides/cs/java/powerpoint-charts/">Grafy</a></li>
<li><a href="/slides/cs/java/powerpoint-animation/">Animace</a></li>
<li><a href="/slides/cs/java/manage-media-files/">Audio a video</a></li>
<li><a href="/slides/cs/java/presentation-design/">Design snímků</a></li>
<li><a href="/slides/cs/java/merge-presentation/">Sloučit prezentace</a></li>
</ul>
<p>Příklady</p>
<ul>
<li><a href="/slides/cs/java/examples/">Příklady podle prvků snímku</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-Java">Příklady na GitHubu</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Reference a podpora</b></p>
<hr>
<p>Reference</p>
<ul>
<li><a href="https://reference.aspose.com/slides/cs/java/">API reference</a></li>
<li><a href="https://releases.aspose.com/slides/cs/java/release-notes/">Poznámky k vydání</a></li>
<li><a href="/slides/cs/java/known-issues/">Známé problémy</a></li>
<li><a href="https://releases.aspose.com/slides/cs/java/">Stáhnout</a></li>
</ul>
<p>Podpora</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/cs/11">Bezplatné fórum podpory</a></li>
<li><a href="https://helpdesk.aspose.com/">Placená podpora (helpdesk)</a></li>
</ul>
</div>
</div>

------

## **Vaše první prezentace**

Aspose.Slides for Java je publikováno v Maven repozitáři společnosti Aspose, nikoli v Maven Central. Vytvořte složku pro Maven projekt a uložte do ní tento *pom.xml*. Definuje repozitář, přidá knihovnu a určuje třídu k spuštění:

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

Uložte tento kód jako *src/main/java/HelloSlides.java*:

```java
import com.aspose.slides.*;

public class HelloSlides {
    public static void main(String[] args) {
        // Vytvořte prezentaci. Už obsahuje jeden prázdný snímek.
        Presentation presentation = new Presentation();
        try {
            // Získejte první snímek.
            ISlide slide = presentation.getSlides().get_Item(0);

            // Přidejte tvar mraku a vložte do něj text.
            IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80);
            autoShape.getTextFrame().setText("Hello, Aspose!");

            // Uložte prezentaci jako soubor PPTX.
            presentation.save("new_presentation.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

Poté, s nainstalovaným JDK 11 nebo novějším a Apache Maven, spusťte v adresáři projektu tento příkaz:

```bash
mvn compile exec:java
```

Program uloží *new_presentation.pptx* do adresáře projektu, se snímkem obsahujícím tvar mraku s textem. Na Linuxu musí být nainstalován fontconfig a alespoň jeden font; viz [Installation](/slides/cs/java/installation/#linux). Bez licence obsahuje uložený soubor vodoznak zkušební verze — viz [Licensing](/slides/cs/java/licensing/). Další způsoby, jak vytvořit a naplnit prezentaci, najdete v [Create Presentations](/slides/cs/java/create-presentation/).