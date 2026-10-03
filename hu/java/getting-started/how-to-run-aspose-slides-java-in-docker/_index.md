---
title: Az Aspose.Slides for Java futtatása Dockerben
linktitle: Docker
type: docs
weight: 150
url: /hu/java/how-to-run-aspose-slides-in-docker/
keywords:
- Docker
- Dockerfile
- Docker konténer
- többlépcsős építés
- konténer kép
- Eclipse Temurin
- Maven
- Linux
- Ubuntu
- Alpine
- Debian
- fontconfig
- betűtípusok
- PDF konverzió
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Az Aspose.Slides for Java alkalmazás építése és futtatása Dockerben: egy többlépcsős Dockerfile a hivatalos Maven és Eclipse Temurin képeken, a Linux könyvtárak és betűtípusok, amelyekre az Aspose.Slidesnek szüksége van, valamint a generált fájlok gépedre másolásának módja."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan futtatható az Aspose.Slides for Java egy Docker tárolóban. Egy kis Maven projektet épít fel, amely egy prezentációt hoz létre egy szövegdobozzal, majd PDF‑re konvertálja, a hivatalos Maven és Eclipse Temurin képeken egy többfázisú Dockerfile‑lal csomagolja, futtatja, és a generált fájlokat a gépedre másolja. A cikk továbbá elmagyarázza, milyen további komponensekre van szüksége az Aspose.Slides‑nek egy Linux képben a Java mellett, és alpines Linuxra, valamint olyan képekre, amelyek a Java‑t a disztribúció csomagjaiból telepítik, mutat variációkat.

Csak Dockerre van szükséged a gépeden. A JDK és a Maven a build képen szerepelnek, így nem kell őket telepíteni. A Docker telepítéséhez lásd [Docker beszerzése](https://docs.docker.com/get-started/get-docker/).

## **Válassz Alapképeket**

A Dockerfile ebben a cikkben két hivatalos képet használ a Docker Hub‑ról:

- [maven](https://hub.docker.com/_/maven) a `3.9-eclipse-temurin-21` címkével építi az alkalmazást. Apache Maven 3.9‑et és az Eclipse Temurin JDK 21‑et tartalmazza.
- [eclipse-temurin](https://hub.docker.com/_/eclipse-temurin) a `21-jre` címkével futtatja. Az Eclipse Temurin Java 21 futtatókörnyezetet tartalmazza Ubuntu‑on, a JDK és Maven nélkül.

Az Aspose.Slides for Java a Java betűtámogatásával rajzolja a szöveget, ami Linuxon a fontconfig és a FreeType könyvtárakat, valamint legalább egy telepített betűtípust igényel. Az Eclipse Temurin képek már tartalmazzák a fontconfig‑ot, a FreeType‑t és a DejaVu betűtípusokat, így ebben a cikkben a Dockerfile nem telepít semmilyen csomagot. Egy betűtípust sem tartalmazó képen a prezentáció mentése a „Fontconfig head is null, check your fonts or fonts configuration” hibaüzenettel leáll. Ha másik alapképre építesz, lásd [Use Another Base Image](#use-another-base-image).

## **Projekt Létrehozása**

Hozz létre egy *hello-slides-docker* nevű mappát, és helyezd el benne a következő fájlokat.

*pom.xml* deklarálja az Aspose Maven tárolóját és az Aspose.Slides for Java függőséget, ahogy a [Telepítés](/slides/hu/java/installation/) leírásában szerepel; az Aspose.Slides for Java nincs közzétéve a Maven Central‑ban, ezért a tároló bejegyzés szükséges. A `finalName` elem az alkalmazás JAR fájlját *hello-slides.jar*-nek nevezi, és a [maven-dependency-plugin](https://maven.apache.org/plugins/maven-dependency-plugin/) átmásolja az alkalmazás függőségeit a *target/lib* könyvtárba, amikor a Maven csomagolja. Állítsd be az Aspose.Slides verziót a legújabbra, ami a [tárolóban](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) szerepel.

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

*src/main/java/HelloSlides.java* egy [Prezentációt](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) hoz létre, hozzáad egy szöveges téglalapot az első diájához, és a [mentés](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#save-java.lang.String-int-) módszerrel kétszer menti a prezentációt: PPTX‑ként és PDF‑ként. Mindkét fájl a munkakönyvtár *output* mappájába kerül. A program ezután felsorolja azokat a betűtípusokat, amelyeket az Aspose.Slides helyettesít a prezentáció renderelésekor, az [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) használatával, így láthatod, hogy a tárolóban vannak‑e a prezentáció által használt betűtípusok.

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

*.dockerignore* a helyi build *target* mappáját és a korábbi futtatások kimenetét a Docker build kontextusból kizárja, így a kép csak a forrásfájlokból épül.

```text
target/
output/
```

## **Dockerfile Írása**

Adj hozzá egy *Dockerfile* nevű fájlt a *hello-slides-docker* mappához:

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

A fájl két szakaszból áll:

- **A build fázis** a Maven képből indul. Először átmásolja a *pom.xml*-t, és futtatja a `mvn dependency:go-offline` parancsot, amely letölti az Aspose.Slides for Java‑t és a Maven plugineket, így a Docker ezt a réteget újrahasználja, amíg a *pom.xml* nem változik. Ezután átmásolja a forráskódot, és futtatja a `mvn package` parancsot, amely a programot a *target/hello-slides.jar* fájlba fordítja, és az Aspose.Slides JAR‑t a *target/lib* könyvtárba másolja. A `-B` opció a Maven‑t nem interaktív (batch) módban indítja.
- **A runtime fázis** a kisebb Java futtatókörnyezet képből indul, és csak az alkalmazás JAR fájlját és a *lib* mappát másolja be. Létrehozza az *output* mappát, azt adja a `ubuntu` felhasználónak, az Ubuntu‑alapú kép nem‑root felhasználójának, és a programot ezzel a felhasználóval futtatja. Az osztályút `hello-slides.jar:lib/*` tartalmazza az alkalmazást és minden JAR‑t a *lib* könyvtárban; a Java maga bővíti a `*`‑t.

A projekt Java 11‑re (a `maven.compiler.release` tulajdonság) van lefordítva, így a runtime fázis használhat újabb Java verziót is. Például a Java 25‑ön való futtatáshoz módosítsd a runtime fázis képet `eclipse-temurin:25-jre`‑re.

## **A Konténer Építése és Futtatása**

Nyiss egy terminált a *hello-slides-docker* mappában. Építsd fel a képet, majd futtass egy tárolót belőle:

```bash
docker build -t hello-slides .
docker run --name hello-slides-run hello-slides
```

Az első build letölti az alapképeket, a Maven plugineket és az Aspose.Slides for Java‑t, ezért több percet vesz igénybe; a későbbi buildek újra felhasználják őket. A tároló futtatja az alkalmazást, majd leáll. Kiírja:

```text
Font substitution: Calibri -> DejaVu Sans
Saved output/hello.pptx and output/hello.pdf
```

Az első sor azt mutatja, hogy a szöveg a Calibri betűtípust használja, ami egy új prezentáció alapértelmezett betűtípusa, és hogy a Calibri nincs telepítve a képen, ezért az Aspose.Slides a szöveget a DejaVu Sans-szel rajzolta. A PDF‑ben a szöveg valós, kijelölhető szöveg ebben a betűtípusban. Licenc nélkül az Aspose.Slides minden mentett diára egy értékelő vízjeleket ad; lásd [Licencelés](/slides/hu/java/licensing/).

## **A Kimenet Másolása a Gépedre**

A fájlok a leállított tároló */app/output* mappájában vannak. Másold őket egy *output* mappába a gépeden, majd távolítsd el a tárolót:

```bash
docker cp hello-slides-run:/app/output/. ./output
docker rm hello-slides-run
```

Ezek a két parancs ugyanúgy működnek Bash‑ben, PowerShell‑ben, és a Windows Parancssorban.

Linuxon helyette egy mappát csatolhatsz a gépedről a tárolóba, így az alkalmazás közvetlenül oda írja a fájlokat:

```bash
mkdir -p output
docker run --rm --user "$(id -u):$(id -g)" -v "$(pwd)/output:/app/output" hello-slides
```

A `--user` opció a saját felhasználó‑ és csoport‑azonosítóddal futtatja az alkalmazást, így írni tud a létrehozott mappába, és a fájlok a tiéd lesznek. A `--rm` leálláskor eltávolítja a tárolót.

## **Futtatás Alpine Linuxon**

Az Eclipse Temurin elérhető Alpine Linux alapú képként is, amely kisebb. Tartalmazza a fontconfig‑ot, a FreeType‑t és a DejaVu betűtípusokat is, így az alkalmazásnak itt sem kell további csomagokat telepíteni. Használatához cseréld le a *Dockerfile*-ban a runtime fázist (a második `FROM` sortól kezdődően) a következőre:

```dockerfile
FROM eclipse-temurin:21-jre-alpine
WORKDIR /app
COPY --from=build /src/target/hello-slides.jar .
COPY --from=build /src/target/lib ./lib
RUN adduser -D app && mkdir output && chown app output
USER app
ENTRYPOINT ["java", "-cp", "hello-slides.jar:lib/*", "HelloSlides"]
```

Az Alpine kép nem tartalmaz `ubuntu` felhasználót, ezért ez a fázis létrehozza az `app` nevű felhasználót az `adduser` segítségével, és úgy futtatja az alkalmazást. Építsd, futtasd, és másold a kimenetet ugyanazokkal a parancsokkal, mint fent. Az alkalmazás ugyanazokat a két sorot írja ki.

## **Egy Másik Alapkép Használata**

Ha a képed a Linux disztribúció csomagjaiból telepíti a Java‑t, akkor telepítened kell a Java betűtárakat és egy betűtípust is. Debianon és Ubuntuon az `openjdk-21-jre-headless` csomag csak ajánlottként sorolja fel a fontconfig‑ot, a FreeType‑t és a HarfBuzz‑t, ezért az `apt-get install --no-install-recommends` nem telepíti őket, és az alkalmazás egy `UnsatisfiedLinkError` hibaüzenettel áll le a `libfontmanager.so` miatt. Ez a runtime fázis Debian 13‑on telepíti a Java 21‑et, a könyvtárakat és a DejaVu betűtípusokat, és létrehozza a `app` nevű nem‑root felhasználót:

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

Ugyanez a fázis Ubuntu 26.04‑en is működik a `FROM ubuntu:26.04` használatával.

## **GYIK**

**A prezentáció mentése leáll a „Fontconfig head is null, check your fonts or fonts configuration” üzenettel. Mi hiányzik?**  
Egy betűtípus. A Java betűtámogatása nem talált telepített betűtípust a képen. Telepíts egy betűtípus‑csomagot, például a `fonts-dejavu-core`‑t Debianon és Ubuntuon, ahogy a [Egy Másik Alapkép Használata](#use-another-base-image) leírásában szerepel. A [Betűtípusok Telepítése](/slides/hu/java/deploy-fonts/) más betűtípus‑csomagokat sorol fel.

**Az alkalmazás leáll egy `UnsatisfiedLinkError` hibával a libfontmanager.so‑ért. Mi hiányzik?**  
Egy natív könyvtár a Java betűtámogatásához; a hibaüzenet a betöltésre sikertelen fájlt nevezi, például `libharfbuzz.so.0`. Ez akkor fordul elő, amikor a Java‑t a disztribúció csomagjaiból telepítik a nem‑ajánlott csomagokkal. Telepítsd a [Egy Másik Alapkép Használata](#use-another-base-image) részben felsorolt könyvtárakat.

**Miért más betűtípussal jelenik meg a szöveg a PDF‑ben, mint a PowerPointban?**  
A prezentációban használt betűtípusok nincsenek telepítve a képen, ezért az Aspose.Slides helyettesítő betűtípussal rajzolja a szöveget. Az alkalmazás kimenete felsorolja az egyes lecserélt betűtípusokat. A [Betűtípusok Telepítése](/slides/hu/java/deploy-fonts/) elmagyarázza, hogyan telepítheted a betűtípusokat a képre vagy hogyan töltheted be őket az alkalmazás mappájából.

**Mennyit használhat a memória az alkalmazás a tárolóban?**  
Alapértelmezés szerint a Java a heap‑jét a konténer rendelkezésre álló memóriájának negyedére korlátozza, például körülbelül 250 MB‑ra, ha a tárolót a `docker run -m 1g` paranccsal indítod. Nagy prezentációk feldolgozásához növeld a részesedést a `MaxRAMPercentage` opcióval, például `docker run --rm -m 1g -e JAVA_TOOL_OPTIONS=-XX:MaxRAMPercentage=75 hello-slides`. A Java ekkor a alkalmazás kimenete előtt kiír egy „Picked up JAVA_TOOL_OPTIONS” sort.

**Szükségem van JDK‑ra vagy Maven‑ra a gépemen?**  
Nem. A build fázis a Maven képen belül fordítja le az alkalmazást. JDK‑ra és Maven‑ra csak akkor van szükséged, ha a Dockeron kívül is szeretnéd építeni és futtatni az alkalmazást; lásd [Telepítés](/slides/hu/java/installation/).