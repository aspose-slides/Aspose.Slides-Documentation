---
title: Spusťte Aspose.Slides pro Java v Dockeru
linktitle: Docker
type: docs
weight: 150
url: /cs/java/how-to-run-aspose-slides-in-docker/
keywords:
- Docker
- Dockerfile
- Docker kontejner
- vícefázové sestavení
- obraz kontejneru
- Eclipse Temurin
- Maven
- Linux
- Ubuntu
- Alpine
- Debian
- fontconfig
- fonty
- konverze PDF
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Vytvořte a spusťte aplikaci Aspose.Slides pro Java v Dockeru: vícefázový Dockerfile na oficiálních obrazech Maven a Eclipse Temurin, Linuxové knihovny a fonty, které Aspose.Slides potřebuje, a jak zkopírovat vygenerované soubory do vašeho počítače."
---
## **Přehled**

Tento článek ukazuje, jak spustit Aspose.Slides pro Java v kontejneru Docker. Vytvoříte malý Maven projekt, který vytvoří prezentaci s textovým polem a převede ji do PDF, zabalí ji pomocí vícefázového Dockerfile na oficiálních obrazech Maven a Eclipse Temurin, spustí ji a zkopíruje vygenerované soubory do vašeho počítače. Článek také vysvětluje, co Aspose.Slides v Linuxovém obrazu kromě Javy potřebuje, a končí variantami pro Alpine Linux a pro obrazy, které instalují Javu z balíčků distribuce.

Na svém počítači potřebujete jen Docker. JDK a Maven jsou součástí build obrazu, takže je nemusíte instalovat. Pro instalaci Dockeru viz [Get Docker](https://docs.docker.com/get-started/get-docker/).

## **Vyberte základní obrazy**

Dockerfile v tomto článku používá dva oficiální obrazy z Docker Hub:

- [maven](https://hub.docker.com/_/maven) s tagem `3.9-eclipse-temurin-21` sestavuje aplikaci. Obsahuje Apache Maven 3.9 a Eclipse Temurin JDK 21.
- [eclipse-temurin](https://hub.docker.com/_/eclipse-temurin) s tagem `21-jre` ji spouští. Obsahuje Eclipse Temurin Java 21 runtime na Ubuntu, bez JDK a Mavenu.

Aspose.Slides pro Java vykresluje text pomocí podpory fontů v Javě, která na Linuxu vyžaduje knihovny fontconfig a FreeType a alespoň jeden nainstalovaný font. Obrazy Eclipse Temurin již obsahují fontconfig, FreeType a písma DejaVu, takže Dockerfile v tomto článku neinstaluje žádné balíčky. V obrazu bez jakéhokoli fontu se ukládání prezentace zastaví chybou „Fontconfig head is null, check your fonts or fonts configuration“. Pokud stavíte na jiném základním obrazu, viz [Use Another Base Image](#use-another-base-image).

## **Vytvořte projekt**

Creejte složku pojmenovanou *hello-slides-docker* a přidejte do ní následující soubory.

*pom.xml* deklaruje Maven úložiště Aspose a závislost Aspose.Slides pro Java, jak je popsáno v [Installation](/slides/cs/java/installation/); Aspose.Slides pro Java není publikováno v Maven Central, takže je položka úložiště vyžadována. Prvek `finalName` pojmenovává aplikační JAR soubor *hello-slides.jar* a [maven-dependency-plugin](https://maven.apache.org/plugins/maven-dependency-plugin/) kopíruje závislosti aplikace do *target/lib*, když Maven vytvoří balíček. Nastavte verzi Aspose.Slides na nejnovější uvedenou v [repository](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/).

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

*src/main/java/HelloSlides.java* vytváří [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/), přidá obdélník s textem na první snímek a prezentaci uloží dvakrát metodou [save](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#save-java.lang.String-int-): jako PPTX i jako PDF. Oba soubory jsou umístěny do složky *output* v pracovním adresáři. Program pak vypíše fonty, které Aspose.Slides při vykreslování prezentace nahrazuje, pomocí [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ifontsmanager/#getSubstitutions--), takže můžete zjistit, zda kontejner obsahuje fonty použité v prezentaci.

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

*.dockerignore* udržuje složku *target* lokálního sestavení a výstup předchozích běhů mimo kontext Docker build, takže obraz je vytvořen pouze ze zdrojových souborů.

```text
target/
output/
```

## **Napište Dockerfile**

Přidejte soubor pojmenovaný *Dockerfile* do složky *hello-slides-docker*:

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

Soubor má dva fáze:

- **The build stage** začíná z Maven obrazu. Nejprve zkopíruje *pom.xml* a spustí `mvn dependency:go-offline`, což stáhne Aspose.Slides pro Java a Maven pluginy, takže Docker znovu použije tuto vrstvu, dokud se *pom.xml* nezmění. Pak zkopíruje zdrojový kód a spustí `mvn package`, který zkompiluje program do *target/hello-slides.jar* a zkopíruje Aspose.Slides JAR soubor do *target/lib*. Volba `-B` spouští Maven v neinteraktivním (batch) režimu.
- **The runtime stage** začíná z menšího Java runtime obrazu a zkopíruje pouze aplikační JAR soubor a složku *lib*. Vytvoří složku *output*, přiřadí ji uživateli `ubuntu`, ne-root uživateli, který je definován v Ubuntu‑založeném obrazu, a spustí aplikaci pod tímto uživatelem. Třída cesta `hello-slides.jar:lib/*` obsahuje aplikaci a každý JAR soubor v *lib*; Java sama rozšíří `*`.

Projekt je kompilován pro Java 11 (vlastnost `maven.compiler.release`), takže runtime fáze může použít novější verzi Javy. Například pro spuštění aplikace na Java 25 změňte obraz runtime fáze na `eclipse-temurin:25-jre`.

## **Sestavte a spusťte kontejner**

Otevřete terminál ve složce *hello-slides-docker*. Sestavte obraz a poté spusťte kontejner z něj:

```bash
docker build -t hello-slides .
docker run --name hello-slides-run hello-slides
```

První sestavení stáhne základní obrazy, Maven pluginy a Aspose.Slides pro Java, takže trvá několik minut; pozdější sestavení je znovu použijí. Kontejner spustí aplikaci a zastaví se. Vytiskne:

```text
Font substitution: Calibri -> DejaVu Sans
Saved output/hello.pptx and output/hello.pdf
```

První řádek ukazuje, že text používá Calibri, výchozí font nové prezentace, a že Calibri není v obrazu nainstalováno, takže Aspose.Slides nakreslil text písmem DejaVu Sans. Text v PDF je skutečný, výběrový text v tomto fontu. Bez licence Aspose.Slides také přidává vodotisk evaluace ke každému uloženému slidu; viz [Licensing](/slides/cs/java/licensing/).

## **Zkopírujte výstup na svůj počítač**

Soubory jsou ve složce */app/output* zastaveného kontejneru. Zkopírujte je do složky *output* na svém počítači a poté odstraňte kontejner:

```bash
docker cp hello-slides-run:/app/output/. ./output
docker rm hello-slides-run
```

Tyto dva příkazy fungují stejným způsobem v Bash, PowerShell i ve Windows Command Prompt.

Na Linuxu můžete místo toho připojit složku ze svého počítače do kontejneru, takže aplikace zapisuje soubory přímo tam:

```bash
mkdir -p output
docker run --rm --user "$(id -u):$(id -g)" -v "$(pwd)/output:/app/output" hello-slides
```

Volba `--user` spouští aplikaci s vašimi ID uživatele a skupiny, takže může zapisovat do vytvořené složky a soubory patří vám. `--rm` odstraňuje kontejner po jeho zastavení.

## **Spuštění na Alpine Linux**

Eclipse Temurin je také dostupný jako obraz založený na Alpine Linux, který je menší. Obsahuje také fontconfig, FreeType a písma DejaVu, takže aplikace nevyžaduje žádné další balíčky. Pro jeho použití nahraďte runtime fázi v *Dockerfile* (vše od druhé řádky `FROM`) následujícím:

```dockerfile
FROM eclipse-temurin:21-jre-alpine
WORKDIR /app
COPY --from=build /src/target/hello-slides.jar .
COPY --from=build /src/target/lib ./lib
RUN adduser -D app && mkdir output && chown app output
USER app
ENTRYPOINT ["java", "-cp", "hello-slides.jar:lib/*", "HelloSlides"]
```

Alpine obraz nemá uživatele `ubuntu`, takže tato fáze vytvoří uživatele s názvem `app` pomocí `adduser` a spustí aplikaci pod tímto uživatelem. Sestavte, spusťte a zkopírujte výstup pomocí stejných příkazů jako výše. Aplikace vytiskne stejné dva řádky.

## **Použijte jiný základní obraz**

Pokud váš obraz místo toho instalujete Javu z balíčků Linuxové distribuce, nainstalujte spolu s ní knihovny fontů Javy a font. V Debianu a Ubuntu balíček `openjdk-21-jre-headless` uvádí fontconfig, FreeType a HarfBuzz pouze jako doporučené balíčky, takže `apt-get install --no-install-recommends` je vynechá a aplikace se zastaví s `UnsatisfiedLinkError` pro `libfontmanager.so`. Tato runtime fáze nainstaluje Java 21, knihovny a písma DejaVu na Debian 13 a vytvoří ne-root uživatele s názvem `app`:

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

Stejná fáze funguje i na Ubuntu 26.04 s `FROM ubuntu:26.04`.

## **Často kladené otázky**

**Ukládání prezentace se zastaví s „Fontconfig head is null, check your fonts or fonts configuration“. Co chybí?**

Odpověď: Font. Podpora fontů v Javě nenašla v obrazu žádný nainstalovaný font. Nainstalujte balíček fontů, například `fonts-dejavu-core` na Debianu a Ubuntu, jak je uvedeno v [Use Another Base Image](#use-another-base-image). [Deploy Fonts](/slides/cs/java/deploy-fonts/) uvádí další balíčky fontů.

**Aplikace se zastaví s UnsatisfiedLinkError pro libfontmanager.so. Co chybí?**

Odpověď: Nativní knihovna podpory fontů Javy; zpráva uvádí soubor, který se nepodařilo načíst, například `libharfbuzz.so.0`. K tomu dochází, když je Java nainstalována z balíčků distribuce bez jejich doporučených balíčků. Nainstalujte knihovny uvedené v [Use Another Base Image](#use-another-base-image).

**Proč je text v PDF v jiném fontu než v PowerPointu?**

Odpověď: Fonty, které prezentace používá, nejsou v obrazu nainstalovány, takže Aspose.Slides vykresluje text náhradním fontem. Výstup aplikace uvádí každý nahrazený font. [Deploy Fonts](/slides/cs/java/deploy-fonts/) vysvětluje, jak nainstalovat fonty v obrazu nebo je načíst ze složky aplikace.

**Kolik paměti může aplikace v kontejneru využívat?**

Odpověď: Ve výchozím nastavení Java omezuje svůj haldu na čtvrtinu paměti dostupné kontejneru, například na cca 250 MB při spuštění kontejneru s `docker run -m 1g`. Pro zpracování velkých prezentací zvyšte podíl pomocí volby `MaxRAMPercentage`, například `docker run --rm -m 1g -e JAVA_TOOL_OPTIONS=-XX:MaxRAMPercentage=75 hello-slides`. Java pak vypíše řádek „Picked up JAVA_TOOL_OPTIONS“ před výstupem aplikace.

**Potřebuji JDK nebo Maven na svém počítači?**

Odpověď: Ne. Fáze build kompiluje aplikaci uvnitř Maven obrazu. JDK a Maven potřebujete jen tehdy, pokud chcete aplikaci také sestavit a spustit mimo Docker; viz [Installation](/slides/cs/java/installation/).