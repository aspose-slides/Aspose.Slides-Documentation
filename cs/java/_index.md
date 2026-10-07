---
title: Aspose.Slides for Java
second_title: Aspose.Slides for Java
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
description: "Začněte zde: nainstalujte Aspose.Slides for Java, vytvořte první prezentaci a najděte průvodce pro běžné úkoly, nasazení a referenční dokumentaci API."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Java je knihovna tříd pro vytváření, čtení, editaci a konverzi prezentací PowerPoint a OpenDocument v Java aplikacích, bez Microsoft PowerPoint.

Načítá a ukládá soubory PPT, PPTX, PPS, POT a ODP, včetně variant s makry a šablon, a exportuje do PDF, XPS, HTML, SVG, TIFF, Markdown a obrázků.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Začínáme</b></p>
<hr>
<p>ZAČÁTEK</p>
<ul>
<li><a href="/slides/cs/java/installation/">Instalace</a></li>
<li><a href="/slides/cs/java/create-presentation/">Vytvořte svou první prezentaci</a></li>
<li><a href="/slides/cs/java/system-requirements/">Systémové požadavky</a></li>
<li><a href="/slides/cs/java/getting-started/">Průvodce pro začátečníky</a></li>
</ul>
<p>EVALUACE</p>
<ul>
<li><a href="/slides/cs/java/supported-file-formats/">Podporované formáty souborů</a></li>
<li><a href="/slides/cs/java/features-overview/">Přehled funkcí</a></li>
<li><a href="/slides/cs/java/evaluate-aspose-slides/">Omezení zkušební verze</a></li>
<li><a href="/slides/cs/java/licensing/">Licencování</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Vytvářejte pomocí Slides</b></p>
<hr>
<p>OBECNÉ ÚKOLY</p>
<ul>
<li><a href="/slides/cs/java/open-presentation/">Otevřít prezentaci</a></li>
<li><a href="/slides/cs/java/save-presentation/">Uložit prezentaci</a></li>
<li><a href="/slides/cs/java/convert-powerpoint-to-pdf/">Převést do PDF</a></li>
<li><a href="/slides/cs/java/convert-slide/">Vykreslit snímky jako obrázky</a></li>
<li><a href="/slides/cs/java/manage-text/">Upravit text a tvary</a></li>
</ul>
<p>PRACOVNÍ PROCESY</p>
<ul>
<li><a href="/slides/cs/java/powerpoint-charts/">Grafy</a></li>
<li><a href="/slides/cs/java/powerpoint-animation/">Animace</a></li>
<li><a href="/slides/cs/java/manage-media-files/">Audio a video</a></li>
<li><a href="/slides/cs/java/presentation-design/">Návrh snímků</a></li>
<li><a href="/slides/cs/java/merge-presentation/">Sloučit prezentace</a></li>
</ul>
<p>PŘÍKLADY</p>
<ul>
<li><a href="/slides/cs/java/examples/">Příklady podle prvku snímku</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-Java">Příklady na GitHubu</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Nasazení a podpora</b></p>
<hr>
<p>NASAZENÍ</p>
<ul>
<li><a href="/slides/cs/java/system-requirements/#linux">Požadavky pro Linux</a></li>
<li><a href="/slides/cs/java/how-to-run-aspose-slides-in-docker/">Spustit v Dockeru</a></li>
<li><a href="/slides/cs/java/deploy-fonts/">Písma</a></li>
<li><a href="/slides/cs/java/security/">Zabezpečení</a></li>
</ul>
<p>REFERENCE</p>
<ul>
<li><a href="https://reference.aspose.com/slides/java/">Reference API</a></li>
<li><a href="https://releases.aspose.com/slides/java/release-notes/">Poznámky k vydání</a></li>
<li><a href="/slides/cs/java/known-issues/">Známé problémy</a></li>
<li><a href="/slides/cs/java/api-limitations/">Omezení výstupních metadat</a></li>
<li><a href="https://products.aspose.com/slides/java/">Stránka produktu</a></li>
<li><a href="https://releases.aspose.com/slides/java/">Stáhnout</a></li>
</ul>
<p>PODPORA</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Bezplatné fórum podpory</a></li>
<li><a href="https://helpdesk.aspose.com/">Placený podpůrný helpdesk</a></li>
</ul>
</div>
</div>

------

<a name="your-first-presentation"></a>

## **Vaše první prezentace**

Aspose.Slides for Java je zveřejněn v Maven úložišti společnosti Aspose, nikoli v Maven Central. Vytvořte složku pro Maven projekt a uložte do ní tento *pom.xml*. Definuje úložiště, přidá knihovnu a určuje třídu, která se má spustit:

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
        // Vytvořte prezentaci. Již obsahuje jeden prázdný snímek.
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

Poté, s nainstalovaným JDK 11 nebo novějším a Apache Maven, spusťte tento příkaz ve složce projektu:

```bash
mvn compile exec:java
```

Program uloží *new_presentation.pptx* do složky projektu, s jedním snímkem obsahujícím tvar mraku s textem. Na Linuxu musí být nainstalován fontconfig a alespoň jeden font; viz [Installation](/slides/cs/java/installation/#linux). Bez licence bude uložený soubor obsahovat vodotisk pro hodnocení — viz [Licensing](/slides/cs/java/licensing/). Pro další možnosti, jak vytvořit a vyplnit prezentaci, viz [Create Presentations](/slides/cs/java/create-presentation/).