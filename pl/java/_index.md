---
title: Aspose.Slides dla Javy
second_title: Aspose.Slides dla Javy
type: docs
weight: 20
url: /pl/java/
keywords:
- dokumentacja
- przetwarzanie prezentacji
- konwersja prezentacji
- PowerPoint
- OpenDocument
- Java
- Aspose.Slides
description: "Rozpocznij tutaj: zainstaluj Aspose.Slides for Java, utwórz pierwszą prezentację i znajdź przewodniki dotyczące typowych zadań, referencję API oraz wsparcie."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Java jest biblioteką klas umożliwiającą tworzenie, odczytywanie, edytowanie i konwertowanie prezentacji PowerPoint oraz OpenDocument w aplikacjach Java, bez potrzeby korzystania z Microsoft PowerPoint.

Obsługuje wczytywanie i zapisywanie formatów PPT, PPTX, PPS, POT oraz ODP, w tym wersji z makrami i szablonów, oraz umożliwia eksport do PDF, XPS, HTML, SVG, TIFF, Markdown i obrazów.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Rozpocznij</b></p>
<hr>
<p>ROZPOCZĘCIE</p>
<ul>
<li><a href="/slides/pl/java/installation/">Instalacja</a></li>
<li><a href="/slides/pl/java/create-presentation/">Utwórz pierwszą prezentację</a></li>
<li><a href="/slides/pl/java/getting-started/">Przewodnik wprowadzający</a></li>
</ul>
<p>OCENA</p>
<ul>
<li><a href="/slides/pl/java/supported-file-formats/">Obsługiwane formaty plików</a></li>
<li><a href="/slides/pl/java/evaluate-aspose-slides/">Ograniczenia wersji próbnej</a></li>
<li><a href="/slides/pl/java/licensing/">Licencjonowanie</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Buduj przy pomocy Slides</b></p>
<hr>
<p>POSPOLNE ZADANIA</p>
<ul>
<li><a href="/slides/pl/java/open-presentation/">Otwórz prezentację</a></li>
<li><a href="/slides/pl/java/save-presentation/">Zapisz prezentację</a></li>
<li><a href="/slides/pl/java/convert-powerpoint-to-pdf/">Konwertuj do PDF</a></li>
<li><a href="/slides/pl/java/convert-slide/">Renderuj slajdy jako obrazy</a></li>
<li><a href="/slides/pl/java/manage-text/">Edytuj tekst i kształty</a></li>
</ul>
<p>PRZEPŁYWY PRACY SLIDES</p>
<ul>
<li><a href="/slides/pl/java/powerpoint-charts/">Wykresy</a></li>
<li><a href="/slides/pl/java/powerpoint-animation/">Animacje</a></li>
<li><a href="/slides/pl/java/manage-media-files/">Audio i wideo</a></li>
<li><a href="/slides/pl/java/presentation-design/">Projektowanie slajdów</a></li>
<li><a href="/slides/pl/java/merge-presentation/">Scalanie prezentacji</a></li>
</ul>
<p>PRZYKŁADY</p>
<ul>
<li><a href="/slides/pl/java/examples/">Przykłady według elementu slajdu</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-Java">Przykłady na GitHubie</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referencje &amp; Wsparcie</b></p>
<hr>
<p>REFERENCJE</p>
<ul>
<li><a href="https://reference.aspose.com/slides/pl/java/">Referencja API</a></li>
<li><a href="https://releases.aspose.com/slides/pl/java/release-notes/">Notatki o wydaniu</a></li>
<li><a href="/slides/pl/java/known-issues/">Znane problemy</a></li>
<li><a href="https://releases.aspose.com/slides/pl/java/">Pobierz</a></li>
</ul>
<p>WSPARCIE</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/pl/11">Darmowe forum wsparcia</a></li>
<li><a href="https://helpdesk.aspose.com/">Płatny helpdesk wsparcia</a></li>
</ul>
</div>
</div>

------

## **Twoja pierwsza prezentacja**

Aspose.Slides for Java jest publikowane w własnym repozytorium Maven firmy Aspose, a nie w Maven Central. Utwórz folder dla projektu Maven i zapisz w nim plik *pom.xml*. Definiuje ono repozytorium, dodaje bibliotekę i określa klasę do uruchomienia:

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

Zapisz ten kod jako *src/main/java/HelloSlides.java*:

```java
import com.aspose.slides.*;

public class HelloSlides {
    public static void main(String[] args) {
        // Utwórz prezentację. Zawiera ona już jeden pusty slajd.
        Presentation presentation = new Presentation();
        try {
            // Pobierz pierwszy slajd.
            ISlide slide = presentation.getSlides().get_Item(0);

            // Dodaj kształt chmury i umieść w nim tekst.
            IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80);
            autoShape.getTextFrame().setText("Hello, Aspose!");

            // Zapisz prezentację jako plik PPTX.
            presentation.save("new_presentation.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

Następnie, mając zainstalowane JDK 11 lub nowsze oraz Apache Maven, uruchom następujące polecenie w folderze projektu:

```bash
mvn compile exec:java
```

Program zapisuje *new_presentation.pptx* w folderze projektu, z jednym slajdem zawierającym kształt chmury z tekstem. W systemie Linux należy zainstalować fontconfig oraz przynajmniej jedną czcionkę; zobacz [Instalacja](/slides/pl/java/installation/#linux). Bez licencji zapisany plik zawiera znak wodny z oceną — zobacz [Licencjonowanie](/slides/pl/java/licensing/). Aby poznać więcej metod tworzenia i wypełniania prezentacji, zobacz [Tworzenie prezentacji](/slides/pl/java/create-presentation/).