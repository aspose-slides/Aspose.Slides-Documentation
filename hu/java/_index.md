---
title: Aspose.Slides for Java
second_title: Aspose.Slides for Java
type: docs
weight: 20
url: /hu/java/
keywords:
- dokumentáció
- prezentáció feldolgozás
- prezentáció konvertálás
- PowerPoint
- OpenDocument
- Java
- Aspose.Slides
description: "Kezdje itt: telepítse az Aspose.Slides for Java-t, hozza létre az első prezentációt, és keresse meg az általános feladatokhoz, az API-referencia és a támogatás útmutatóit."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Az Aspose.Slides for Java egy osztálykönyvtár PowerPoint és OpenDocument előadások létrehozásához, olvasásához, szerkesztéséhez és konvertálásához Java alkalmazásokban, a Microsoft PowerPoint nélkül.

Betölti és menti a PPT, PPTX, PPS, POT és ODP formátumokat, beleértve a makróval ellátott és sablon változatokat is, és exportál PDF, XPS, HTML, SVG, TIFF, Markdown és képek formátumokba.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Kezdő lépések</b></p>
<hr>
<p>ELKEZDÉS</p>
<ul>
<li><a href="/slides/hu/java/installation/">Telepítés</a></li>
<li><a href="/slides/hu/java/create-presentation/">Az első előadás létrehozása</a></li>
<li><a href="/slides/hu/java/getting-started/">Első lépések útmutatója</a></li>
</ul>
<p>ÉRTÉKELÉS</p>
<ul>
<li><a href="/slides/hu/java/supported-file-formats/">Támogatott fájlformátumok</a></li>
<li><a href="/slides/hu/java/evaluate-aspose-slides/">Próba korlátozások</a></li>
<li><a href="/slides/hu/java/licensing/">Licencelés</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Készítés Slides-szel</b></p>
<hr>
<p>ÁLTALÁNOS FELADATOK</p>
<ul>
<li><a href="/slides/hu/java/open-presentation/">Előadás megnyitása</a></li>
<li><a href="/slides/hu/java/save-presentation/">Előadás mentése</a></li>
<li><a href="/slides/hu/java/convert-powerpoint-to-pdf/">PDF-re konvertálás</a></li>
<li><a href="/slides/hu/java/convert-slide/">Diák renderelése képekként</a></li>
<li><a href="/slides/hu/java/manage-text/">Szöveg és alakzatok szerkesztése</a></li>
</ul>
<p>SLIDES MUNKAFOLYAMOK</p>
<ul>
<li><a href="/slides/hu/java/powerpoint-charts/">Diagramok</a></li>
<li><a href="/slides/hu/java/powerpoint-animation/">Animációk</a></li>
<li><a href="/slides/hu/java/manage-media-files/">Hang és videó</a></li>
<li><a href="/slides/hu/java/presentation-design/">Dia tervezés</a></li>
<li><a href="/slides/hu/java/merge-presentation/">Előadások egyesítése</a></li>
</ul>
<p>PELDÁK</p>
<ul>
<li><a href="/slides/hu/java/examples/">Példák diaelemenként</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-Java">Példák a GitHub-on</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referencia &amp; Támogatás</b></p>
<hr>
<p>REFERENCIA</p>
<ul>
<li><a href="https://reference.aspose.com/slides/hu/java/">API referencia</a></li>
<li><a href="https://releases.aspose.com/slides/hu/java/release-notes/">Kiadási jegyzetek</a></li>
<li><a href="/slides/hu/java/known-issues/">Ismert problémák</a></li>
<li><a href="https://releases.aspose.com/slides/hu/java/">Letöltés</a></li>
</ul>
<p>TÁMOGATÁS</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/hu/11">Ingyenes támogatási fórum</a></li>
<li><a href="https://helpdesk.aspose.com/">Fizetős támogatási helpdesk</a></li>
</ul>
</div>
</div>

------

## **Az első előadásod**

Az Aspose.Slides for Java az Aspose saját Maven tárolójában van közzétéve, nem a Maven Centralban. Hozzon létre egy mappát egy Maven projekthez, és mentse ebbe a *pom.xml*-t. Ez deklarálja a tárolót, hozzáadja a könyvtárat, és megnevezi a futtatandó osztályt:

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

Mentse ezt a kódot *src/main/java/HelloSlides.java* néven:

```java
import com.aspose.slides.*;

public class HelloSlides {
    public static void main(String[] args) {
        // Hozzon létre egy prezentációt. Már egy üres diát tartalmaz.
        Presentation presentation = new Presentation();
        try {
            // Szerezze meg az első diát.
            ISlide slide = presentation.getSlides().get_Item(0);

            // Adjon hozzá egy felhő alakzatot, és helyezzen bele szöveget.
            IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80);
            autoShape.getTextFrame().setText("Hello, Aspose!");

            // Mentse a prezentációt PPTX fájlként.
            presentation.save("new_presentation.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

Ezután, a JDK 11 vagy újabb és az Apache Maven telepítése után, futtassa ezt a parancsot a projekt mappában:

```bash
mvn compile exec:java
```

A program elmenti a *new_presentation.pptx*-t a projekt mappájába, egyetlen diával, amely egy felhő alakzatot tartalmaz szöveggel. Linuxon a fontconfig és legalább egy betűkészlet telepítve kell legyen; lásd a [Telepítés](/slides/hu/java/installation/#linux) oldalt. Licenc nélkül a mentett fájl egy értékelési vízjelet tartalmaz – lásd a [Licencelés](/slides/hu/java/licensing/) oldalt. További módok az előadás létrehozására és kitöltésére a [Előadások létrehozása](/slides/hu/java/create-presentation/) oldalon.