---
title: "Esegui Aspose.Slides per Java in Docker"
linktitle: "Docker"
type: docs
weight: 150
url: /it/java/how-to-run-aspose-slides-in-docker/
keywords:
- Docker
- Dockerfile
- Contenitore Docker
- compilazione multi-stage
- immagine del contenitore
- Eclipse Temurin
- Maven
- Linux
- Ubuntu
- Alpine
- Debian
- fontconfig
- font
- conversione PDF
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Compila ed esegui un'applicazione Aspose.Slides per Java in Docker: un Dockerfile multi-stage basato sulle immagini ufficiali Maven ed Eclipse Temurin, le librerie Linux e i font necessari ad Aspose.Slides, e come copiare i file generati sulla tua macchina."
---
## **Panoramica**

Questo articolo mostra come eseguire Aspose.Slides for Java in un contenitore Docker. Si crea un piccolo progetto Maven che genera una presentazione con una casella di testo e la converte in PDF, lo impacchetta con un Dockerfile multi‑stage sulle immagini ufficiali Maven e Eclipse Temurin, lo esegue e copia i file generati nella tua macchina. L’articolo spiega anche cosa richiede Aspose.Slides in un’immagine Linux oltre a Java e termina con varianti per Alpine Linux e per immagini che installano Java dai pacchetti della distribuzione.

Hai bisogno solo di Docker sulla tua macchina. JDK e Maven fanno parte dell’immagine di build, quindi non devi installarli. Per installare Docker, vedi [Ottieni Docker](https://docs.docker.com/get-started/get-docker/).

## **Scegli le Immagini Base**

Il Dockerfile di questo articolo utilizza due immagini ufficiali da Docker Hub:

- [maven](https://hub.docker.com/_/maven) con il tag `3.9-eclipse-temurin-21` compila l’applicazione. Contiene Apache Maven 3.9 e l’Eclipse Temurin JDK 21.
- [eclipse-temurin](https://hub.docker.com/_/eclipse-temurin) con il tag `21-jre` lo esegue. Contiene il runtime Eclipse Temurin Java 21 su Ubuntu, senza JDK né Maven.

Aspose.Slides for Java disegna il testo con il supporto dei font di Java, che su Linux richiede le librerie fontconfig e FreeType e almeno un font installato. Le immagini Eclipse Temurin contengono già fontconfig, FreeType e i font DejaVu, quindi il Dockerfile di questo articolo non installa pacchetti. In un’immagine senza alcun font, il salvataggio di una presentazione si interrompe con l’errore “Fontconfig head is null, check your fonts or fonts configuration”. Se compili su un’altra immagine base, vedi [Usa un’Altra Immagine Base](#use-another-base-image).

## **Crea il Progetto**

Crea una cartella denominata *hello-slides-docker* e aggiungi i seguenti file.

*pom.xml* dichiara il repository Maven di Aspose e la dipendenza Aspose.Slides for Java, come descritto in [Installazione](/slides/it/java/installation/); Aspose.Slides for Java non è pubblicato in Maven Central, quindi è necessario includere il repository. L’elemento `finalName` nome il file JAR dell’applicazione *hello-slides.jar*, e il [maven-dependency-plugin](https://maven.apache.org/plugins/maven-dependency-plugin/) copia le dipendenze dell’applicazione in *target/lib* quando Maven la impacchetta. Imposta la versione di Aspose.Slides all’ultima presente nel [repository](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/).

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

*src/main/java/HelloSlides.java* crea una [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/), aggiunge un rettangolo con testo alla prima diapositiva e salva la presentazione due volte con il metodo [save](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#save-java.lang.String-int-): come PPTX e come PDF. Entrambi i file vanno nella cartella *output* nella directory di lavoro. Il programma elenca poi i font che Aspose.Slides sostituisce durante il rendering della presentazione, usando [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/it/java/com.aspose.slides/ifontsmanager/#getSubstitutions--), così puoi verificare se il contenitore ha i font utilizzati dalla presentazione.

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

*.dockerignore* esclude la cartella *target* di una build locale e l’output di esecuzioni precedenti dal contesto di build Docker, così l’immagine viene costruita solo dai file sorgente.

```text
target/
output/
```

## **Scrivi il Dockerfile**

Aggiungi un file denominato *Dockerfile* nella cartella *hello-slides-docker*:

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

Il file ha due fasi:

- **La fase di build** parte dall’immagine Maven. Copia prima *pom.xml* ed esegue `mvn dependency:go-offline`, che scarica Aspose.Slides for Java e i plugin Maven, così Docker riutilizza quel layer finché *pom.xml* non cambia. Poi copia il codice sorgente ed esegue `mvn package`, che compila il programma in *target/hello-slides.jar* e copia il JAR di Aspose.Slides in *target/lib*. L’opzione `-B` esegue Maven in modalità non interattiva (batch).
- **La fase di runtime** parte dall’immagine runtime Java più piccola e copia solo il file JAR dell’applicazione e la cartella *lib*. Crea la cartella *output*, la assegna a `ubuntu`, l’utente non root definito dall’immagine basata su Ubuntu, ed esegue l’applicazione con quell’utente. Il classpath `hello-slides.jar:lib/*` contiene l’applicazione e tutti i JAR in *lib*; Java espande il carattere `*` autonomamente.

Il progetto è compilato per Java 11 (proprietà `maven.compiler.release`), quindi la fase di runtime può usare una versione Java più recente. Per esempio, per eseguire l’applicazione su Java 25, cambia l’immagine della fase di runtime in `eclipse-temurin:25-jre`.

## **Compila ed Esegui il Container**

Apri un terminale nella cartella *hello-slides-docker*. Compila l’immagine, quindi esegui un contenitore da essa:

```bash
docker build -t hello-slides .
docker run --name hello-slides-run hello-slides
```

La prima compilazione scarica le immagini base, i plugin Maven e Aspose.Slides for Java, quindi richiede diversi minuti; le compilazioni successive li riutilizzano. Il contenitore esegue l’applicazione e si arresta. Stampa:

```text
Font substitution: Calibri -> DejaVu Sans
Saved output/hello.pptx and output/hello.pdf
```

La prima riga mostra che il testo usa Calibri, il font predefinito di una nuova presentazione, e che Calibri non è installato nell’immagine, quindi Aspose.Slides ha disegnato il testo con DejaVu Sans. Il testo nel PDF è reale, selezionabile con quel font. Senza licenza, Aspose.Slides aggiunge anche una filigrana di valutazione a ogni diapositiva salvata; vedi [Licensing](/slides/it/java/licensing/).

## **Copia l'Uscita sulla Tua Macchina**

I file si trovano nella cartella */app/output* del contenitore arrestato. Copiali in una cartella *output* sulla tua macchina, quindi rimuovi il contenitore:

```bash
docker cp hello-slides-run:/app/output/. ./output
docker rm hello-slides-run
```

Questi due comandi funzionano allo stesso modo in Bash, PowerShell e nel Prompt dei comandi di Windows.

Su Linux, puoi invece **montare** una cartella della tua macchina nel contenitore, così l’applicazione scrive direttamente i file lì:

```bash
mkdir -p output
docker run --rm --user "$(id -u):$(id -g)" -v "$(pwd)/output:/app/output" hello-slides
```

L’opzione `--user` esegue l’applicazione con i tuoi UID e GID, così può scrivere nella cartella che hai creato e i file ti appartengono. `--rm` rimuove il contenitore al termine.

## **Esegui su Alpine Linux**

Eclipse Temurin è disponibile anche come immagine basata su Alpine Linux, più leggera. Contiene anch’essa fontconfig, FreeType e i font DejaVu, quindi l’applicazione non richiede pacchetti aggiuntivi. Per usarla, sostituisci la fase di runtime in *Dockerfile* (tutto dal secondo `FROM` in poi) con:

```dockerfile
FROM eclipse-temurin:21-jre-alpine
WORKDIR /app
COPY --from=build /src/target/hello-slides.jar .
COPY --from=build /src/target/lib ./lib
RUN adduser -D app && mkdir output && chown app output
USER app
ENTRYPOINT ["java", "-cp", "hello-slides.jar:lib/*", "HelloSlides"]
```

L’immagine Alpine non ha l’utente `ubuntu`, quindi questa fase crea un utente chiamato `app` con `adduser` ed esegue l’applicazione con quell’utente. Compila, esegui e copia l’output con gli stessi comandi di prima. L’applicazione stampa le stesse due righe.

## **Usa un’Altra Immagine Base**

Se la tua immagine installa Java dai pacchetti della distribuzione Linux, installa le librerie dei font di Java e un font insieme ad esso. Su Debian e Ubuntu, il pacchetto `openjdk-21-jre-headless` elenca fontconfig, FreeType e HarfBuzz solo come pacchetti consigliati, quindi `apt-get install --no-install-recommends` li esclude, e l’applicazione si interrompe con un `UnsatisfiedLinkError` per `libfontmanager.so`. Questa fase di runtime installa Java 21, le librerie e i font DejaVu su Debian 13, e crea un utente non root chiamato `app`:

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

La stessa fase funziona su Ubuntu 26.04 con `FROM ubuntu:26.04`.

## **FAQ**

**Il salvataggio della presentazione si interrompe con “Fontconfig head is null, check your fonts or fonts configuration”. Cosa manca?**

Un font. Il supporto dei font di Java non ha trovato alcun font installato nell’immagine. Installa un pacchetto di font, ad esempio `fonts-dejavu-core` su Debian e Ubuntu, come indicato in [Usa un’Altra Immagine Base](#use-another-base-image). [Deploy Fonts](/slides/it/java/deploy-fonts/) elenca altri pacchetti di font.

**L’applicazione si interrompe con UnsatisfiedLinkError per libfontmanager.so. Cosa manca?**

Una libreria nativa del supporto dei font di Java; il messaggio indica il file non caricato, ad esempio `libharfbuzz.so.0`. Ciò avviene quando Java è installato dai pacchetti della distribuzione senza i loro pacchetti consigliati. Installa le librerie elencate in [Usa un’Altra Immagine Base](#use-another-base-image).

**Perché il testo nel PDF ha un font diverso da quello di PowerPoint?**

I font usati dalla presentazione non sono installati nell’immagine, quindi Aspose.Slides disegna il testo con un font sostitutivo. L’output dell’applicazione elenca ciascun font sostituito. [Deploy Fonts](/slides/it/java/deploy-fonts/) spiega come installare i font nell’immagine o caricarli dalla cartella dell’applicazione.

**Quanta memoria può usare l’applicazione nel contenitore?**

Per impostazione predefinita, Java limita l’heap a un quarto della memoria disponibile per il contenitore, ad esempio circa 250 MB quando avvii il contenitore con `docker run -m 1g`. Per elaborare presentazioni grandi, aumenta la quota con l’opzione `MaxRAMPercentage`, ad esempio `docker run --rm -m 1g -e JAVA_TOOL_OPTIONS=-XX:MaxRAMPercentage=75 hello-slides`. Java stampa quindi una riga “Picked up JAVA_TOOL_OPTIONS” prima dell’output dell’applicazione.

**Devo avere JDK o Maven sulla mia macchina?**

No. La fase di build compila l’applicazione all’interno dell’immagine Maven. Hai bisogno di JDK e Maven solo se vuoi compilare ed eseguire l’applicazione al di fuori di Docker; vedi [Installazione](/slides/it/java/installation/).