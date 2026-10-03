---
title: Exécuter Aspose.Slides pour Java dans Docker
linktitle: Docker
type: docs
weight: 150
url: /fr/java/how-to-run-aspose-slides-in-docker/
keywords:
- Docker
- Dockerfile
- conteneur Docker
- construction multi‑étapes
- image de conteneur
- Eclipse Temurin
- Maven
- Linux
- Ubuntu
- Alpine
- Debian
- fontconfig
- polices
- conversion PDF
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Créer et exécuter une application Aspose.Slides pour Java dans Docker : un Dockerfile multi‑étapes basé sur les images officielles Maven et Eclipse Temurin, les bibliothèques Linux et les polices nécessaires à Aspose.Slides, et comment copier les fichiers générés sur votre machine."
---
## **Vue d'ensemble**

Cet article montre comment exécuter Aspose.Slides pour Java dans un conteneur Docker. Vous créez un petit projet Maven qui génère une présentation avec une zone de texte et la convertit en PDF, l’emballe avec un Dockerfile multi‑étapes sur les images officielles Maven et Eclipse Temurin, l’exécute, puis copie les fichiers générés sur votre machine. L’article explique également ce dont Aspose.Slides a besoin dans une image Linux en plus de Java, et se termine par des variantes pour Alpine Linux et pour les images qui installent Java à partir des paquets de la distribution.

Vous avez seulement besoin de Docker sur votre machine. Le JDK et Maven font partie de l’image de construction, vous n’avez donc pas besoin de les installer. Pour installer Docker, consultez [Obtenir Docker](https://docs.docker.com/get-started/get-docker/).

## **Choisir les images de base**

Le Dockerfile de cet article utilise deux images officielles de Docker Hub :

- [maven](https://hub.docker.com/_/maven) avec le tag `3.9-eclipse-temurin-21` compile l’application. Elle contient Apache Maven 3.9 et le JDK Eclipse Temurin 21.
- [eclipse-temurin](https://hub.docker.com/_/eclipse-temurin) avec le tag `21-jre` l’exécute. Elle contient le runtime Java 21 Eclipse Temurin sur Ubuntu, sans le JDK ni Maven.

Aspose.Slides pour Java rend le texte avec le support des polices de Java, qui sous Linux nécessite les bibliothèques fontconfig et FreeType ainsi qu’au moins une police installée. Les images Eclipse Temurin contiennent déjà fontconfig, FreeType et les polices DejaVu, de sorte que le Dockerfile de cet article n’installe aucun paquet. Dans une image sans aucune police, l’enregistrement d’une présentation s’arrête avec l’erreur "Fontconfig head is null, check your fonts or fonts configuration". Si vous construisez sur une autre image de base, consultez [Utiliser une autre image de base](#use-another-base-image).

## **Créer le projet**

Créez un dossier nommé *hello-slides-docker* et ajoutez-y les fichiers suivants.

*pom.xml* déclare le référentiel Maven d’Aspose ainsi que la dépendance Aspose.Slides pour Java, comme décrit dans [Installation](/slides/fr/java/installation/); Aspose.Slides pour Java n’est pas publié dans Maven Central, donc l’entrée du référentiel est nécessaire. L’élément `finalName` nomme le fichier JAR de l’application *hello-slides.jar*, et le [maven-dependency-plugin](https://maven.apache.org/plugins/maven-dependency-plugin/) copie les dépendances de l’application vers *target/lib* lorsque Maven le packge. Définissez la version d’Aspose.Slides à la plus récente listée dans le [repository](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/).

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

*src/main/java/HelloSlides.java* crée une [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/), ajoute un rectangle contenant du texte à la première diapositive, et enregistre la présentation deux fois avec la méthode [save](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#save-java.lang.String-int-): au format PPTX puis PDF. Les deux fichiers sont placés dans le dossier *output* du répertoire de travail. Le programme liste ensuite les polices que Aspose.Slides remplace lors du rendu de la présentation, en utilisant [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ifontsmanager/#getSubstitutions--), afin que vous puissiez voir si le conteneur possède les polices utilisées par la présentation.

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

*.dockerignore* conserve le dossier *target* d’une construction locale, ainsi que la sortie des exécutions précédentes, hors du contexte de construction Docker, de sorte que l’image est construite uniquement à partir des fichiers source.

```text
target/
output/
```

## **Écrire le Dockerfile**

Ajoutez un fichier nommé *Dockerfile* au dossier *hello-slides-docker* :

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

Le fichier comporte deux étapes :

- **L’étape de construction** débute à partir de l’image Maven. Elle copie d’abord *pom.xml* puis exécute `mvn dependency:go-offline`, ce qui télécharge Aspose.Slides pour Java et les plugins Maven, de sorte que Docker réutilise cette couche tant que *pom.xml* ne change pas. Elle copie ensuite le code source et exécute `mvn package`, qui compile le programme dans *target/hello-slides.jar* et copie le JAR Aspose.Slides dans *target/lib*. L’option `-B` exécute Maven en mode non interactif (batch).
- **L’étape d’exécution** commence à partir de l’image runtime Java plus petite et ne copie que le fichier JAR de l’application et le dossier *lib*. Elle crée le dossier *output*, le donne à `ubuntu`, l’utilisateur non root défini par l’image basée sur Ubuntu, et exécute l’application avec cet utilisateur. Le classpath `hello-slides.jar:lib/*` contient l’application et chaque fichier JAR présent dans *lib* ; Java développe lui‑même le `*`.

Le projet est compilé pour Java 11 (la propriété `maven.compiler.release`), de sorte que l’étape d’exécution peut utiliser une version Java plus récente. Par exemple, pour exécuter l’application avec Java 25, changez l’image de l’étape d’exécution en `eclipse-temurin:25-jre`.

## **Construire et exécuter le conteneur**

Ouvrez un terminal dans le dossier *hello-slides-docker*. Construisez l’image, puis lancez un conteneur à partir de celle‑ci :

```bash
docker build -t hello-slides .
docker run --name hello-slides-run hello-slides
```

Le premier build télécharge les images de base, les plugins Maven et Aspose.Slides pour Java, ce qui prend plusieurs minutes ; les builds suivants les réutilisent. Le conteneur exécute l’application puis s’arrête. Il affiche :

```text
Font substitution: Calibri -> DejaVu Sans
Saved output/hello.pptx and output/hello.pdf
```

La première ligne indique que le texte utilise Calibri, la police par défaut d’une nouvelle présentation, et que Calibri n’est pas installé dans l’image, si bien qu’Aspose.Slides a rendu le texte avec DejaVu Sans. Le texte du PDF est réel, sélectionnable dans cette police. Sans licence, Aspose.Slides ajoute également un filigrane d’évaluation à chaque diapositive enregistrée ; voir [Licensing](/slides/fr/java/licensing/).

## **Copier la sortie sur votre machine**

Les fichiers se trouvent dans le dossier */app/output* du conteneur arrêté. Copiez‑les dans un dossier *output* sur votre machine, puis supprimez le conteneur :

```bash
docker cp hello-slides-run:/app/output/. ./output
docker rm hello-slides-run
```

Ces deux commandes fonctionnent de la même façon sous Bash, PowerShell et l’invite de commande Windows.

Sous Linux, vous pouvez à la place monter un dossier de votre machine dans le conteneur, de sorte que l’application écrive directement ses fichiers à cet endroit :

```bash
mkdir -p output
docker run --rm --user "$(id -u):$(id -g)" -v "$(pwd)/output:/app/output" hello-slides
```

L’option `--user` exécute l’application avec vos UID et GID, ce qui lui permet d’écrire dans le dossier que vous avez créé et les fichiers vous appartiennent. `--rm` supprime le conteneur lorsqu’il s’arrête.

## **Exécuter sur Alpine Linux**

Eclipse Temurin est également disponible sous forme d’image basée sur Alpine Linux, qui est plus petite. Elle contient également fontconfig, FreeType et les polices DejaVu, de sorte que l’application n’a pas besoin de paquets supplémentaires. Pour l’utiliser, remplacez l’étape d’exécution dans *Dockerfile* (tout à partir de la deuxième ligne `FROM`) par :

```dockerfile
FROM eclipse-temurin:21-jre-alpine
WORKDIR /app
COPY --from=build /src/target/hello-slides.jar .
COPY --from=build /src/target/lib ./lib
RUN adduser -D app && mkdir output && chown app output
USER app
ENTRYPOINT ["java", "-cp", "hello-slides.jar:lib/*", "HelloSlides"]
```

L’image Alpine ne possède pas d’utilisateur `ubuntu`, ainsi cette étape crée un utilisateur nommé `app` avec `adduser` et exécute l’application avec cet utilisateur. Construisez, exécutez et copiez la sortie avec les mêmes commandes qu’auparavant. L’application affiche les mêmes deux lignes.

## **Utiliser une autre image de base**

Si votre image installe Java à partir des paquets de la distribution Linux, installez les bibliothèques de polices de Java ainsi qu’une police. Sous Debian et Ubuntu, le paquet `openjdk-21-jre-headless` ne répertorie fontconfig, FreeType et HarfBuzz que comme paquets recommandés, ainsi `apt-get install --no-install-recommends` les laisse de côté, et l’application s’arrête avec une `UnsatisfiedLinkError` pour `libfontmanager.so`. Cette étape d’exécution installe Java 21, les bibliothèques et les polices DejaVu sur Debian 13, et crée un utilisateur non root nommé `app` :

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

La même étape fonctionne sur Ubuntu 26.04 avec `FROM ubuntu:26.04`.

## **FAQ**

**L’enregistrement de la présentation s’arrête avec "Fontconfig head is null, check your fonts or fonts configuration". Qu’est‑ce qui manque ?**  
Une police. Le support des polices de Java n’a trouvé aucune police installée dans l’image. Installez un paquet de polices, par exemple `fonts-dejavu-core` sur Debian et Ubuntu, comme indiqué dans [Utiliser une autre image de base](#use-another-base-image). [Deploy Fonts](/slides/fr/java/deploy-fonts/) répertorie d’autres paquets de polices.

**L’application s’arrête avec une UnsatisfiedLinkError pour libfontmanager.so. Qu’est‑ce qui manque ?**  
Une bibliothèque native du support des polices de Java ; le message indique le fichier qui n’a pas pu être chargé, par exemple `libharfbuzz.so.0`. Cela se produit lorsque Java est installé à partir des paquets de la distribution sans leurs paquets recommandés. Installez les bibliothèques listées dans [Utiliser une autre image de base](#use-another-base-image).

**Pourquoi le texte du PDF apparaît‑il dans une police différente de celle de PowerPoint ?**  
Les polices utilisées par la présentation ne sont pas installées dans l’image, si bien qu’Aspose.Slides rend le texte avec une police de substitution. La sortie de l’application indique chaque police remplacée. [Deploy Fonts](/slides/fr/java/deploy-fonts/) explique comment installer des polices dans l’image ou les charger depuis le dossier de l’application.

**Quelle quantité de mémoire l’application peut‑elle utiliser dans le conteneur ?**  
Par défaut, Java limite son tas à un quart de la mémoire disponible pour le conteneur, par exemple à environ 250 Mo lorsque vous lancez le conteneur avec `docker run -m 1g`. Pour traiter de grandes présentations, augmentez cette part avec l’option `MaxRAMPercentage`, par exemple `docker run --rm -m 1g -e JAVA_TOOL_OPTIONS=-XX:MaxRAMPercentage=75 hello-slides`. Java indique alors une ligne "Picked up JAVA_TOOL_OPTIONS" avant la sortie de l’application.

**Ai‑je besoin d’un JDK ou de Maven sur ma machine ?**  
Non. L’étape de construction compile l’application à l’intérieur de l’image Maven. Vous n’avez besoin d’un JDK et de Maven que si vous souhaitez également construire et exécuter l’application hors Docker ; voir [Installation](/slides/fr/java/installation/).