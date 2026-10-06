---
title: Aspose.Slides for Java
second_title: Aspose.Slides for Java
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
description: "Zacznij tutaj: zainstaluj Aspose.Slides for Java, utwórz pierwszą prezentację i znajdź przewodniki dotyczące typowych zadań, wdrażania oraz referencji API."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Java jest biblioteką klas umożliwiającą tworzenie, odczyt, edycję i konwersję prezentacji PowerPoint i OpenDocument w aplikacjach Java, bez Microsoft PowerPoint.

Obsługuje ładowanie i zapisywanie formatów PPT, PPTX, PPS, POT i ODP, w tym wersje z makrami i szablony, oraz eksportuje do PDF, XPS, HTML, SVG, TIFF, Markdown i obrazów.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Rozpocznij</b></p>
<hr>
<p>Rozpoczęcie</p>
<ul>
<li><a href="/slides/pl/java/installation/">Instalacja</a></li>
<li><a href="/slides/pl/java/create-presentation/">Utwórz swoją pierwszą prezentację</a></li>
<li><a href="/slides/pl/java/system-requirements/">Wymagania systemowe</a></li>
<li><a href="/slides/pl/java/getting-started/">Przewodnik wprowadzający</a></li>
</ul>
<p>Ewaluacja</p>
<ul>
<li><a href="/slides/pl/java/supported-file-formats/">Obsługiwane formaty plików</a></li>
<li><a href="/slides/pl/java/features-overview/">Przegląd funkcji</a></li>
<li><a href="/slides/pl/java/evaluate-aspose-slides/">Ograniczenia wersji próbnej</a></li>
<li><a href="/slides/pl/java/licensing/">Licencjonowanie</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Buduj przy użyciu Slides</b></p>
<hr>
<p>Częste zadania</p>
<ul>
<li><a href="/slides/pl/java/open-presentation/">Otwórz prezentację</a></li>
<li><a href="/slides/pl/java/save-presentation/">Zapisz prezentację</a></li>
<li><a href="/slides/pl/java/convert-powerpoint-to-pdf/">Konwertuj do PDF</a></li>
<li><a href="/slides/pl/java/convert-slide/">Renderuj slajdy jako obrazy</a></li>
<li><a href="/slides/pl/java/manage-text/">Edytuj tekst i kształty</a></li>
</ul>
<p>Przepływy pracy Slides</p>
<ul>
<li><a href="/slides/pl/java/powerpoint-charts/">Wykresy</a></li>
<li><a href="/slides/pl/java/powerpoint-animation/">Animacje</a></li>
<li><a href="/slides/pl/java/manage-media-files/">Audio i wideo</a></li>
<li><a href="/slides/pl/java/presentation-design/">Projektowanie slajdów</a></li>
<li><a href="/slides/pl/java/merge-presentation/">Scalanie prezentacji</a></li>
</ul>
<p>Przykłady</p>
<ul>
<li><a href="/slides/pl/java/examples/">Przykłady według elementów slajdu</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-Java">Przykłady na GitHubie</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Wdrażanie i wsparcie</b></p>
<hr>
<p>Wdrażanie</p>
<ul>
<li><a href="/slides/pl/java/system-requirements/#linux">Wymagania wstępne Linux</a></li>
<li><a href="/slides/pl/java/how-to-run-aspose-slides-in-docker/">Uruchom w Dockerze</a></li>
<li><a href="/slides/pl/java/deploy-fonts/">Czcionki</a></li>
<li><a href="/slides/pl/java/security/">Bezpieczeństwo</a></li>
</ul>
<p>Referencja</p>
<ul>
<li><a href="https://reference.aspose.com/slides/pl/java/">Referencja API</a></li>
<li><a href="https://releases.aspose.com/slides/pl/java/release-notes/">Notatki wydania</a></li>
<li><a href="/slides/pl/java/known-issues/">Znane problemy</a></li>
<li><a href="/slides/pl/java/api-limitations/">Ograniczenia metadanych wyjściowych</a></li>
<li><a href="https://releases.aspose.com/slides/pl/java/">Pobierz</a></li>
</ul>
<p>Wsparcie</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/pl/11">Bezpłatne forum wsparcia</a></li>
<li><a href="https://helpdesk.aspose.com/">Płatny helpdesk wsparcia</a></li>
</ul>
</div>
</div>

------

<a name="your-first-presentation"></a>

## **Twoja pierwsza prezentacja**

Aspose.Slides for Java jest publikowane w własnym repozytorium Maven firmy Aspose, a nie w Maven Central. Utwórz folder dla projektu Maven i zapisz w nim plik *pom.xml*. Plik definiuje repozytorium, dodaje bibliotekę i określa klasę do uruchomienia:

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
        // Utwórz prezentację. Zawiera już jeden pusty slajd.
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

Następnie, mając zainstalowane JDK 11 lub nowsze oraz Apache Maven, uruchom to polecenie w folderze projektu:

```bash
mvn compile exec:java
```

Program zapisuje *new_presentation.pptx* w folderze projektu, zawierający jeden slajd z kształtem chmury i tekstem. W systemie Linux należy zainstalować fontconfig oraz przynajmniej jedną czcionkę; zobacz [Instalacja](/slides/pl/java/installation/#linux). Bez licencji zapisany plik zawiera znak wodny z oceną — zobacz [Licencjonowanie](/slides/pl/java/licensing/). Aby poznać więcej metod tworzenia i wypełniania prezentacji, zobacz [Tworzenie prezentacji](/slides/pl/java/create-presentation/).