---
title: Aspose.Slides for Java
second_title: Aspose.Slides for Java
type: docs
weight: 20
url: /hu/java/
keywords:
- dokumentáció
- prezentációfeldolgozás
- prezentációkonverzió
- PowerPoint
- OpenDocument
- Java
- Aspose.Slides
description: "Kezdje itt: telepítse az Aspose.Slides for Java-t, hozza létre az első prezentációt, és találja meg az útmutatókat a gyakori feladatokhoz, a telepítéshez és az API referenciához."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Az Aspose.Slides for Java egy osztálykönyvtár a PowerPoint és OpenDocument prezentációk létrehozásához, olvasásához, szerkesztéséhez és átalakításához Java alkalmazásokban, a Microsoft PowerPoint nélkül.

Betölti és menti a PPT, PPTX, PPS, POT és ODP formátumokat, beleértve a makrókat tartalmazó és sablon változatokat is, valamint exportál PDF, XPS, HTML, SVG, TIFF, Markdown és képek formátumba.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Kezdő lépések</b></p>
<hr>
<p>ELKEZDÉS</p>
<ul>
<li><a href="/slides/hu/java/installation/">Telepítés</a></li>
<li><a href="/slides/hu/java/create-presentation/">Készítsd el az első prezentációdat</a></li>
<li><a href="/slides/hu/java/system-requirements/">Rendszerkövetelmények</a></li>
<li><a href="/slides/hu/java/getting-started/">Első lépések útmutatója</a></li>
</ul>
<p>ÉRTÉKELÉS</p>
<ul>
<li><a href="/slides/hu/java/supported-file-formats/">Támogatott fájlformátumok</a></li>
<li><a href="/slides/hu/java/features-overview/">Funkciók áttekintése</a></li>
<li><a href="/slides/hu/java/evaluate-aspose-slides/">Próbaverzió korlátai</a></li>
<li><a href="/slides/hu/java/licensing/">Licencelés</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Slides használatával</b></p>
<hr>
<p>ÁLTALÁNOS FELADATOK</p>
<ul>
<li><a href="/slides/hu/java/open-presentation/">Prezentáció megnyitása</a></li>
<li><a href="/slides/hu/java/save-presentation/">Prezentáció mentése</a></li>
<li><a href="/slides/hu/java/convert-powerpoint-to-pdf/">PDF-be konvertálás</a></li>
<li><a href="/slides/hu/java/convert-slide/">Diák renderelése képekként</a></li>
<li><a href="/slides/hu/java/manage-text/">Szöveg és alakzatok szerkesztése</a></li>
</ul>
<p>SLIDES MUNKAFOLYAMOK</p>
<ul>
<li><a href="/slides/hu/java/powerpoint-charts/">Diagramok</a></li>
<li><a href="/slides/hu/java/powerpoint-animation/">Animációk</a></li>
<li><a href="/slides/hu/java/manage-media-files/">Hang és videó</a></li>
<li><a href="/slides/hu/java/presentation-design/">Dia tervezés</a></li>
<li><a href="/slides/hu/java/merge-presentation/">Prezentációk összevonása</a></li>
</ul>
<p>PELDÁK</p>
<ul>
<li><a href="/slides/hu/java/examples/">Példák diák elem szerint</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-Java">Példák a GitHubon</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Telepítés és támogatás</b></p>
<hr>
<p>TELEPÍTÉS</p>
<ul>
<li><a href="/slides/hu/java/system-requirements/#linux">Linux előfeltételek</a></li>
<li><a href="/slides/hu/java/how-to-run-aspose-slides-in-docker/">Dockerben futtatás</a></li>
<li><a href="/slides/hu/java/deploy-fonts/">Betűkészletek</a></li>
<li><a href="/slides/hu/java/security/">Biztonság</a></li>
</ul>
<p>REFERENCIA</p>
<ul>
<li><a href="https://reference.aspose.com/slides/hu/java/">API referencia</a></li>
<li><a href="https://releases.aspose.com/slides/hu/java/release-notes/">Kiadási megjegyzések</a></li>
<li><a href="/slides/hu/java/known-issues/">Ismert problémák</a></li>
<li><a href="/slides/hu/java/api-limitations/">Kimeneti metaadat korlátok</a></li>
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

<a name="your-first-presentation"></a>

## **Az első prezentációd**

Az Aspose.Slides for Java saját Maven tárolójában van közzétéve, nem a Maven Centralban. Hozzon létre egy mappát egy Maven projekthez, és mentse el ebbe a *pom.xml*-t. Ez deklarálja a tárolót, hozzáadja a könyvtárat, és megadja a futtatandó osztályt:

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

Mentse el ezt a kódot *src/main/java/HelloSlides.java* néven:

```java
import com.aspose.slides.*;

public class HelloSlides {
    public static void main(String[] args) {
        // Hozzon létre egy prezentációt. Már tartalmaz egy üres diát.
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

Ezután, JDK 11 vagy újabb és az Apache Maven telepítése után, futtassa ezt a parancsot a projekt mappában:

```bash
mvn compile exec:java
```

A program elmenti a *new_presentation.pptx*-t a projekt mappába, egy diával, amely felhő alakzatot és szöveget tartalmaz. Linuxon a fontconfig és legalább egy betűkészlet telepítve kell legyen; lásd a [Telepítés](/slides/hu/java/installation/#linux) részt. Licenc nélkül a mentett fájl egy értékelési vízjelet tartalmaz — lásd a [Licencelés](/slides/hu/java/licensing/) részt. További módok a prezentáció létrehozására és feltöltésére a [Prezentációk létrehozása](/slides/hu/java/create-presentation/) oldalon találhatók.