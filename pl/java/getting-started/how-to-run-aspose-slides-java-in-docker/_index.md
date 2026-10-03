---
title: Uruchom Aspose.Slides for Java w Dockerze
linktitle: Docker
type: docs
weight: 150
url: /pl/java/how-to-run-aspose-slides-in-docker/
keywords:
- Docker
- Dockerfile
- Kontener Docker
- Build wielostopniowy
- Obraz kontenera
- Eclipse Temurin
- Maven
- Linux
- Ubuntu
- Alpine
- Debian
- fontconfig
- czcionki
- konwersja PDF
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Zbuduj i uruchom aplikację Aspose.Slides for Java w Dockerze: wielostopniowy Dockerfile na oficjalnych obrazach Maven i Eclipse Temurin, biblioteki i czcionki Linuksa wymagane przez Aspose.Slides oraz sposób kopiowania wygenerowanych plików na swój komputer."
---
## **Przegląd**

Ten artykuł pokazuje, jak uruchomić Aspose.Slides for Java w kontenerze Docker. Tworzysz mały projekt Maven, który tworzy prezentację z polem tekstowym i konwertuje ją na PDF, pakuje ją przy użyciu wielostopniowego Dockerfile na oficjalnych obrazach Maven i Eclipse Temurin, uruchamia ją i kopiuje wygenerowane pliki na swój komputer. Artykuł wyjaśnia także, co Aspose.Slides potrzebuje w obrazie Linux oprócz Javy, oraz kończy się wariantami dla Alpine Linux i dla obrazów instalujących Javę z pakietów dystrybucji.

Potrzebujesz jedynie Dockera na swoim komputerze. JDK i Maven są częścią obrazu budującego, więc nie musisz ich instalować. Aby zainstalować Dockera, zobacz [Get Docker](https://docs.docker.com/get-started/get-docker/).

## **Wybierz obrazy bazowe**

Dockerfile w tym artykule używa dwóch oficjalnych obrazów z Docker Hub:

- [maven](https://hub.docker.com/_/maven) z tagiem `3.9-eclipse-temurin-21` buduje aplikację. Zawiera Apache Maven 3.9 i Eclipse Temurin JDK 21.
- [eclipse-temurin](https://hub.docker.com/_/eclipse-temurin) z tagiem `21-jre` uruchamia go. Zawiera środowisko uruchomieniowe Eclipse Temurin Java 21 na Ubuntu, bez JDK i Maven.

Aspose.Slides for Java rysuje tekst przy użyciu obsługi czcionek Java, co w systemie Linux wymaga bibliotek fontconfig i FreeType oraz co najmniej jednej zainstalowanej czcionki. Obrazy Eclipse Temurin już zawierają fontconfig, FreeType i czcionki DejaVu, więc Dockerfile w tym artykule nie instalują żadnych dodatkowych pakietów. W obrazie bez żadnych czcionek zapisanie prezentacji zatrzymuje się błędem „Fontconfig head is null, check your fonts or fonts configuration”. Jeśli budujesz na innym obrazie bazowym, zobacz [Use Another Base Image](#use-another-base-image).

## **Utwórz projekt**

Utwórz folder o nazwie *hello-slides-docker* i dodaj do niego następujące pliki.

*pom.xml* deklaruje repozytorium Maven firmy Aspose oraz zależność Aspose.Slides for Java, jak opisano w [Instalacja](/slides/pl/java/installation/); Aspose.Slides for Java nie jest publikowane w Maven Central, więc wpis repozytorium jest wymagany. Element `finalName` nadaje nazwę plikowi JAR aplikacji *hello-slides.jar*, a [maven-dependency-plugin](https://maven.apache.org/plugins/maven-dependency-plugin/) kopiuje zależności aplikacji do *target/lib* podczas pakowania przez Maven. Ustaw wersję Aspose.Slides na najnowszą dostępną w [repozytorium](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/).

```xml
<project xmlns="http://maven.apache.org/POM/4.0.0">
    <modelVersion>4.0.0</modelVersion>
    <groupId>com.example</groupId>
    <artifactId>hello-slides</artifactId>
    <version>1.0</version>

    <properties>
        <maven.compiler.release>11</maven.compiler.release>
        <project.build.sourceEncoding>UTF-8</project.build.sourceEncoding>
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
        <finalName>hello-slides</finalName>
        <plugins>
            <plugin>
                <groupId>org.apache.maven.plugins</groupId>
                <artifactId>maven-compiler-plugin</artifactId>
                <version>3.15.0</version>
            </plugin>
            <plugin>
                <groupId>org.apache.maven.plugins</groupId>
                <artifactId>maven-dependency-plugin</artifactId>
                <version>3.11.0</version>
                <executions>
                    <execution>
                        <phase>package</phase>
                        <goals>
                            <goal>copy-dependencies</goal>
                        </goals>
                        <configuration>
                            <outputDirectory>${project.build.directory}/lib</outputDirectory>
                        </configuration>
                    </execution>
                </executions>
            </plugin>
        </plugins>
    </build>
</project>
```

*src/main/java/HelloSlides.java* tworzy [Prezentację](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/), dodaje prostokąt z tekstem do pierwszego slajdu i zapisuje prezentację dwukrotnie przy użyciu metody [save](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#save-java.lang.String-int-): jako PPTX i jako PDF. Oba pliki trafiają do folderu *output* w katalogu roboczym. Program następnie wypisuje czcionki, które Aspose.Slides zastępuje podczas renderowania prezentacji, używając [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ifontsmanager/#getSubstitutions--), abyś mógł zobaczyć, czy kontener posiada czcionki używane w prezentacji.

```java
import com.aspose.slides.*;
import java.io.File;

public class HelloSlides {
    public static void main(String[] args) {
        File outputFolder = new File("output");
        outputFolder.mkdirs();

        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
            shape.getTextFrame().setText("Hello from a Docker container!");

            String pptxPath = new File(outputFolder, "hello.pptx").getPath();
            String pdfPath = new File(outputFolder, "hello.pdf").getPath();
            presentation.save(pptxPath, SaveFormat.Pptx);
            presentation.save(pdfPath, SaveFormat.Pdf);

            for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions()) {
                System.out.println("Font substitution: " + substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
            }

            System.out.println("Saved " + pptxPath + " and " + pdfPath);
        } finally {
            presentation.dispose();
        }
    }
}
```

*.dockerignore* utrzymuje folder *target* lokalnego builda oraz output wcześniejszych uruchomień poza kontekstem budowania Docker, dzięki czemu obraz jest budowany wyłącznie z plików źródłowych.

```text
target/
output/
```

## **Napisz Dockerfile**

Dodaj plik o nazwie *Dockerfile* do folderu *hello-slides-docker*:

```dockerfile
FROM maven:3.9-eclipse-temurin-21 AS build
WORKDIR /src
COPY pom.xml .
RUN mvn -B dependency:go-offline
COPY src ./src
RUN mvn -B package

FROM eclipse-temurin:21-jre
WORKDIR /app
COPY --from=build /src/target/hello-slides.jar .
COPY --from=build /src/target/lib ./lib
RUN mkdir output && chown ubuntu output
USER ubuntu
ENTRYPOINT ["java", "-cp", "hello-slides.jar:lib/*", "HelloSlides"]
```

Plik ma dwa etapy:

- **The build stage** zaczyna się od obrazu Maven. Najpierw kopiuje *pom.xml* i uruchamia `mvn dependency:go-offline`, co pobiera Aspose.Slides for Java oraz wtyczki Maven, więc Docker ponownie używa tej warstwy, dopóki *pom.xml* się nie zmieni. Następnie kopiuje kod źródłowy i uruchamia `mvn package`, co kompiluje program do *target/hello-slides.jar* i kopiuje plik JAR Aspose.Slides do *target/lib*. Opcja `-B` uruchamia Maven w trybie nieinteraktywnym (batch).
- **The runtime stage** zaczyna się od mniejszego obrazu środowiska uruchomieniowego Java i kopiuje tylko plik JAR aplikacji oraz folder *lib*. Tworzy folder *output*, przydziela go użytkownikowi `ubuntu`, nieuprzywilejowanemu użytkownikowi definiowanemu w obrazie opartym na Ubuntu, i uruchamia aplikację jako ten użytkownik. Ścieżka klas `hello-slides.jar:lib/*` zawiera aplikację i każdy plik JAR w *lib*; Java sam rozwija `*`.

Projekt jest kompilowany dla Java 11 (właściwość `maven.compiler.release`), więc etap uruchomieniowy może używać nowszej wersji Java. Na przykład, aby uruchomić aplikację na Java 25, zmień obraz etapu uruchomieniowego na `eclipse-temurin:25-jre`.

## **Zbuduj i uruchom kontener**

Otwórz terminal w folderze *hello-slides-docker*. Zbuduj obraz, a następnie uruchom z niego kontener:

```bash
docker build -t hello-slides .
docker run --name hello-slides-run hello-slides
```

Pierwsze budowanie pobiera obrazy bazowe, wtyczki Maven oraz Aspose.Slides for Java, więc trwa kilka minut; późniejsze budowania je ponownie wykorzystują. Kontener uruchamia aplikację i zatrzymuje się. Wypisuje:

```text
Font substitution: Calibri -> DejaVu Sans
Saved output/hello.pptx and output/hello.pdf
```

Pierwsza linia pokazuje, że tekst używa czcionki Calibri, domyślnej czcionki nowej prezentacji, oraz że Calibri nie jest zainstalowana w obrazie, więc Aspose.Slides narysował tekst czcionką DejaVu Sans. Tekst w PDF jest prawdziwym, zaznaczalnym tekstem w tej czcionce. Bez licencji Aspose.Slides dodaje również znak wodny oceniający do każdego zapisanego slajdu; zobacz [Licensing](/slides/pl/java/licensing/).

## **Skopiuj wynik na swój komputer**

Pliki znajdują się w folderze */app/output* zatrzymanego kontenera. Skopiuj je do folderu *output* na swoim komputerze, a następnie usuń kontener:

```bash
docker cp hello-slides-run:/app/output/. ./output
docker rm hello-slides-run
```

Te dwa polecenia działają tak samo w Bash, PowerShell i Windows Command Prompt.

W systemie Linux możesz zamiast tego zamontować folder z Twojego komputera w kontenerze, aby aplikacja zapisywała pliki bezpośrednio tam:

```bash
mkdir -p output
docker run --rm --user "$(id -u):$(id -g)" -v "$(pwd)/output:/app/output" hello-slides
```

Opcja `--user` uruchamia aplikację z Twoim identyfikatorem użytkownika i grupy, dzięki czemu może ona zapisywać do utworzonego folderu, a pliki będą do Ciebie należeć. `--rm` usuwa kontener po jego zatrzymaniu.

## **Uruchom na Alpine Linux**

Eclipse Temurin jest dostępny także jako obraz oparty na Alpine Linux, który jest mniejszy. Zawiera również fontconfig, FreeType i czcionki DejaVu, więc aplikacja nie potrzebuje tam dodatkowych pakietów. Aby go użyć, zastąp etap uruchomieniowy w *Dockerfile* (wszystko od drugiej linii `FROM`) następującym kodem:

```dockerfile
FROM eclipse-temurin:21-jre-alpine
WORKDIR /app
COPY --from=build /src/target/hello-slides.jar .
COPY --from=build /src/target/lib ./lib
RUN adduser -D app && mkdir output && chown app output
USER app
ENTRYPOINT ["java", "-cp", "hello-slides.jar:lib/*", "HelloSlides"]
```

Obraz Alpine nie ma użytkownika `ubuntu`, więc ten etap tworzy użytkownika o nazwie `app` przy pomocy `adduser` i uruchamia aplikację jako ten użytkownik. Zbuduj, uruchom i skopiuj wynik przy użyciu tych samych poleceń co powyżej. Aplikacja wypisuje te same dwie linie.

## **Użyj innego obrazu bazowego**

Jeśli Twój obraz zamiast tego instaluję Jave z pakietów dystrybucji Linux, zainstaluj razem z nią biblioteki czcionek Javy oraz czcionkę. Na Debianie i Ubuntu pakiet `openjdk-21-jre-headless` wymienia fontconfig, FreeType i HarfBuzz jedynie jako pakiety rekomendowane, więc `apt-get install --no-install-recommends` je pomija, a aplikacja zatrzymuje się z `UnsatisfiedLinkError` dla `libfontmanager.so`. Ten etap uruchomieniowy instaluję Java 21, biblioteki i czcionki DejaVu na Debian 13, i tworzy nieuprzywilejowanego użytkownika o nazwie `app`:

```dockerfile
FROM debian:trixie
RUN apt-get update \
    && apt-get install -y --no-install-recommends openjdk-21-jre-headless libfontconfig1 libfreetype6 libharfbuzz0b fonts-dejavu-core \
    && rm -rf /var/lib/apt/lists/*
WORKDIR /app
COPY --from=build /src/target/hello-slides.jar .
COPY --from=build /src/target/lib ./lib
RUN useradd --create-home app && mkdir output && chown app output
USER app
ENTRYPOINT ["java", "-cp", "hello-slides.jar:lib/*", "HelloSlides"]
```

Ten sam etap działa na Ubuntu 26.04 z `FROM ubuntu:26.04`.

## **FAQ**

**Zapis prezentacji zatrzymuje się komunikatem „Fontconfig head is null, check your fonts or fonts configuration”. Co jest brakujące?**

Odpowiedź: Czcionka. Obsługa czcionek w Javie nie znalazła żadnej zainstalowanej czcionki w obrazie. Zainstaluj pakiet czcionek, np. `fonts-dejavu-core` na Debianie i Ubuntu, jak w [Use Another Base Image](#use-another-base-image). [Wdrożenie czcionek](/slides/pl/java/deploy-fonts/) wymienia inne pakiety czcionek.

**Aplikacja zatrzymuje się z UnsatisfiedLinkError dla libfontmanager.so. Co jest brakujące?**

Odpowiedź: Biblioteka natywna obsługi czcionek Javy; komunikat podaje nazwę pliku, którego nie udało się załadować, np. `libharfbuzz.so.0`. Dzieje się tak, gdy Java jest instalowana z pakietów dystrybucji bez ich rekomendowanych pakietów. Zainstaluj biblioteki wymienione w [Use Another Base Image](#use-another-base-image).

**Dlaczego tekst w PDF ma inną czcionkę niż w PowerPoint?**

Odpowiedź: Czcionki używane w prezentacji nie są zainstalowane w obrazie, więc Aspose.Slides rysuje tekst zastępczą czcionką. Wyjście aplikacji wymienia każdą zastąpioną czcionkę. [Wdrożenie czcionek](/slides/pl/java/deploy-fonts/) wyjaśnia, jak zainstalować czcionki w obrazie lub załadować je z folderu aplikacji.

**Ile pamięci może używać aplikacja w kontenerze?**

Odpowiedź: Domyślnie Java ogranicza stertę do jednej czwartej pamięci dostępnej dla kontenera, np. do około 250 MB przy uruchomieniu kontenera poleceniem `docker run -m 1g`. Aby przetwarzać duże prezentacje, zwiększ udział za pomocą opcji `MaxRAMPercentage`, np. `docker run --rm -m 1g -e JAVA_TOOL_OPTIONS=-XX:MaxRAMPercentage=75 hello-slides`. Java wypisze wtedy linię „Picked up JAVA_TOOL_OPTIONS” przed wynikiem aplikacji.

**Czy potrzebuję JDK lub Maven na moim komputerze?**

Odpowiedź: Nie. Etap budowania kompiluje aplikację wewnątrz obrazu Maven. Potrzebujesz JDK i Maven tylko wtedy, gdy chcesz również budować i uruchamiać aplikację poza Dockerem; zobacz [Instalacja](/slides/pl/java/installation/).