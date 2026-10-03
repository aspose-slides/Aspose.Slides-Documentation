---
title: Déployer des polices pour Aspose.Slides for Java sur Linux et dans Docker
linktitle: Déployer des polices
type: docs
weight: 155
url: /fr/java/deploy-fonts/
keywords:
- déployer des polices
- installer des polices
- polices dans Docker
- polices sur Linux
- polices manquantes
- substitution de polices
- polices de base Microsoft
- ttf-mscorefonts-installer
- polices personnalisées
- police par défaut
- serveur
- conteneur
- conversion PDF
- présentation
- Java
- Aspose.Slides
description: "Déployer des polices pour Aspose.Slides for Java sur les serveurs Linux et dans les conteneurs Docker : vérifier quelles polices sont substituées, installer les paquets de polices sur Debian, Ubuntu et Alpine, ajouter vos propres fichiers de polices et définir une police par défaut."
---
## **Vue d'ensemble**

Aspose.Slides dessine le texte avec les polices qui sont disponibles lorsqu’il rend une présentation, par exemple lorsqu’il convertit des diapositives en PDF ou en images. Un poste de travail Windows possède généralement les polices utilisées par les présentations. Les serveurs et conteneurs Linux possèdent généralement peu de polices, de sorte qu’Aspose.Slides dessine le texte avec une police de substitution. Une police de substitution a des formes de lettres et des largeurs différentes, si bien que les lignes peuvent se renrouler différemment et le texte peut dépasser son cadre, et les caractères manquants dans la police de substitution ne sont pas rendus correctement. Si aucune police n’est installée, le support des polices de Java ne peut pas démarrer et Aspose.Slides s’arrête avec une erreur.

Cet article montre comment vérifier quelles polices Aspose.Slides substitue, comment installer des polices sur Debian, Ubuntu et Alpine Linux, comment ajouter vos propres fichiers de polices, et comment définir la police utilisée lorsqu’une police est manquante. Les exemples s’exécutent dans Docker sur les images officielles Eclipse Temurin, comme dans [Run Aspose.Slides for Java in Docker](/slides/fr/java/how-to-run-aspose-slides-in-docker/). Les commandes de package sont des instructions Dockerfile ; sur un serveur Linux, exécutez les mêmes commandes en tant que root.

Pour l’API de police elle‑même, comme l’incorporation de polices dans une présentation et les règles de repli et de remplacement, voir [PowerPoint Fonts](/slides/fr/java/powerpoint-fonts/).

## **Vérifier quelles polices sont substituées**

Le projet Maven suivant répertorie les polices qu’Aspose.Slides substitue dans l’environnement actuel. Créez un dossier nommé *font-check* et ajoutez‑y les fichiers ci‑dessous.

* pom.xml * est celui de [Run Aspose.Slides for Java in Docker](/slides/fr/java/how-to-run-aspose-slides-in-docker/#create-the-project), avec l’ID d’artéfact et le nom du fichier JAR changés en *font-check* :

```xml
<project xmlns="http://maven.apache.org/POM/4.0.0">
    <modelVersion>4.0.0</modelVersion>
    <groupId>com.example</groupId>
    <artifactId>font-check</artifactId>
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
        <finalName>font-check</finalName>
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

* src/main/java/FontCheck.java * ajoute une zone de texte par nom de police à une diapositive et attribue la police avec la méthode [setLatinFont](https://reference.aspose.com/slides/fr/java/com.aspose.slides/baseportionformat/#setLatinFont-com.aspose.slides.IFontData-). Les noms de police proviennent de la ligne de commande ; sans arguments, le programme vérifie Calibri, Arial et Times New Roman. Il affiche les dossiers dans lesquels Aspose.Slides recherche les polices ([FontsLoader.getFontFolders](https://reference.aspose.com/slides/fr/java/com.aspose.slides/fontsloader/#getFontFolders--)), rend la diapositive vers *output/fonts.pdf* et affiche les substitutions rapportées par [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ifontsmanager/#getSubstitutions--). Les deux étapes optionnelles au début, le chargement d’un dossier *fonts* et la lecture d’une variable `DEFAULT_FONT`, sont expliquées plus loin dans cet article.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.LinkedHashSet;
import java.util.List;
import java.util.Set;

public class FontCheck {
    public static void main(String[] args) {
        // Les polices à vérifier : les arguments de la ligne de commande, ou trois polices Office courantes.
        String[] fontNames = args.length > 0 ? args : new String[] { "Calibri", "Arial", "Times New Roman" };

        // Charge les fichiers de polices depuis le dossier fonts du répertoire de travail, si celui-ci existe.
        File appFontFolder = new File("fonts");
        if (appFontFolder.isDirectory()) {
            FontsLoader.loadExternalFonts(new String[] { appFontFolder.getAbsolutePath() });
        }

        // Utilise la police nommée dans la variable d'environnement DEFAULT_FONT, si elle est définie, pour le texte dont la police est manquante.
        LoadOptions loadOptions = new LoadOptions();
        String defaultFont = System.getenv("DEFAULT_FONT");
        if (defaultFont != null && !defaultFont.isEmpty()) {
            loadOptions.setDefaultRegularFont(defaultFont);
        }

        Set<String> fontFolders = new LinkedHashSet<>(Arrays.asList(FontsLoader.getFontFolders()));
        System.out.println("Font folders: " + String.join(", ", fontFolders));

        Presentation presentation = new Presentation(loadOptions);
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            for (int i = 0; i < fontNames.length; i++) {
                IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50 + i * 80, 600, 60);
                shape.getTextFrame().setText("This text is set in " + fontNames[i] + ".");
                shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new FontData(fontNames[i]));
            }

            File outputFolder = new File("output");
            outputFolder.mkdirs();
            presentation.save(new File(outputFolder, "fonts.pdf").getPath(), SaveFormat.Pdf);

            List<FontSubstitutionInfo> substitutions = new ArrayList<>();
            for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions()) {
                substitutions.add(substitution);
            }

            if (substitutions.isEmpty()) {
                System.out.println("No font substitutions.");
            } else {
                System.out.println("Font substitutions:");
                for (FontSubstitutionInfo substitution : substitutions) {
                    System.out.println("  " + substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
                }
            }
        } finally {
            presentation.dispose();
        }
    }
}
```

`getFontFolders` peut renvoyer un même dossier plusieurs fois, de sorte que le programme collecte les dossiers dans un ensemble avant de les afficher.

*.dockerignore* exclut les résultats de construction locaux du contexte de construction :

```text
target/
output/
```

* Dockerfile * construit le programme avec l’image Maven et l’exécute sur l’image d’exécution Java Eclipse Temurin, qui contient déjà fontconfig et les polices DejaVu. [Run Aspose.Slides for Java in Docker](/slides/fr/java/how-to-run-aspose-slides-in-docker/) explique chaque instruction.

```dockerfile
FROM maven:3.9-eclipse-temurin-21 AS build
WORKDIR /src
COPY pom.xml .
RUN mvn -B dependency:go-offline
COPY src ./src
RUN mvn -B package

FROM eclipse-temurin:21-jre
WORKDIR /app
COPY --from=build /src/target/font-check.jar .
COPY --from=build /src/target/lib ./lib
RUN mkdir output && chown ubuntu output
USER ubuntu
ENTRYPOINT ["java", "-cp", "font-check.jar:lib/*", "FontCheck"]
```

Construisez l’image et exécutez la vérification :

```bash
docker build -t font-check .
docker run --rm font-check
```

L’image ne possède que les polices DejaVu, donc les trois polices sont remplacées par DejaVu Sans :

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> DejaVu Sans
  Arial -> DejaVu Sans
  Times New Roman -> DejaVu Sans
```

Pour vérifier les polices de vos propres présentations, passez leurs noms en arguments, par exemple `docker run --rm font-check "Segoe UI" Consolas`. Pour copier *output/fonts.pdf* hors du conteneur, utilisez les commandes de [Copy the Output to Your Machine](/slides/fr/java/how-to-run-aspose-slides-in-docker/#copy-the-output-to-your-machine).

## **Installer des polices sur Debian et Ubuntu**

### **Polices de base Microsoft**

Le paquet `ttf-mscorefonts-installer` télécharge et installe les polices de base Microsoft pour le Web, parmi lesquelles Arial, Times New Roman, Courier New, Verdana, Georgia et Trebuchet MS. Les polices sont sous licence EULA de Microsoft, et le paquet ne les installe qu’après acceptation de l’EULA. Un build Docker ne peut pas répondre à l’invite, de sorte que le programme d’installation refuse l’EULA et n’installe aucune police, tandis que `apt-get install` signale quand même le succès. Acceptez l’EULA avec `debconf-set-selections` **avant** l’installation du paquet. L’accepter dans une instruction ultérieure ne sert à rien : le paquet est alors déjà installé, et apt ne relance pas l’installeur.

Ajoutez cette instruction à l’étape d’exécution du *Dockerfile*, juste après sa ligne `FROM`, afin qu’elle s’exécute en tant que root, avant l’instruction `USER` :

```dockerfile
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

Construisez l’image et relancez la vérification avec les mêmes deux commandes. Arial et Times New Roman sont maintenant installés :

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

Calibri, la police par défaut d’une présentation créée par Aspose.Slides, ne fait pas partie des polices de base, de sorte qu’elle est toujours remplacée. Voir [Set a Default Font for Missing Fonts](#set-a-default-font-for-missing-fonts).

Les images Eclipse Temurin basées sur Ubuntu activent `multiverse`, le composant Ubuntu qui contient le paquet. Sur Debian, le paquet se trouve dans le composant `contrib`, que les images Debian n’activent pas. Dans une étape d’exécution basée sur Debian, comme celle de [Use Another Base Image](/slides/fr/java/how-to-run-aspose-slides-in-docker/#use-another-base-image), activez `contrib` dans la même instruction :

```dockerfile
RUN sed -i 's/^Components: main$/Components: main contrib/' /etc/apt/sources.list.d/debian.sources \
    && echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

### **Autres packages de polices**

Debian et Ubuntu fournissent également des polices librement sous licence, par exemple :

| Package | Polices |
|---|---|
| `fonts-dejavu-core` | DejaVu Sans, DejaVu Serif, DejaVu Sans Mono |
| `fonts-liberation` | Liberation Sans, Serif et Mono, avec les mêmes métriques qu’Arial, Times New Roman et Courier New |
| `fonts-crosextra-carlito` | Carlito, avec les mêmes métriques que Calibri |
| `fonts-crosextra-caladea` | Caladea, avec les mêmes métriques que Cambria |

Installez‑les avec `apt-get install` dans une instruction `RUN` de l’étape d’exécution, de la même façon que les polices de base Microsoft. Aspose.Slides for Java n’applique pas les alias de police de la configuration Linux : avec `fonts-liberation` installé, le texte en Arial est toujours rendu avec la police de substitution générale, pas avec Liberation Sans. Pour utiliser une police compatible métriquement à la place d’une police manquante, définissez‑la comme [police par défaut](#set-a-default-font-for-missing-fonts) ou ajoutez une [règle de substitution de police](/slides/fr/java/font-substitution/).

## **Ajouter vos propres fichiers de polices**

Les polices que les distributions ne conditionnent pas, comme les polices de votre organisation ou d’autres polices que vous êtes autorisé à utiliser sur le serveur, peuvent être ajoutées sous forme de fichiers de polices. Placez les fichiers de polices, par exemple les fichiers *.ttf*, dans un dossier nommé *fonts* à l’intérieur du dossier *font-check*. Les exemples ci‑dessous utilisent les fichiers de Carlito, une police avec les mêmes métriques que Calibri, que vous pouvez télécharger depuis [Google Fonts](https://fonts.google.com/specimen/Carlito).

### **Installer les polices dans un dossier système**

Aspose.Slides lit les polices dans les dossiers affichés sur la ligne `Font folders`. Pour installer vos polices pour chaque application de l’image, copiez‑les dans */usr/local/share/fonts*, le dossier des polices installées localement. Ajoutez cette instruction à l’étape d’exécution du *Dockerfile*, après l’instruction `RUN` qui installe les polices de base Microsoft :

```dockerfile
COPY fonts/ /usr/local/share/fonts/
```

Reconstruisez l’image, puis vérifiez Calibri et Carlito :

```bash
docker build -t font-check .
docker run --rm font-check Calibri Carlito
```

Carlito n’est plus substitué :

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

### **Charger les polices depuis le dossier de l’application**

Au lieu d’installer les polices dans un dossier système, vous pouvez les embarquer avec l’application et les charger avec [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/fr/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---). Les polices sont alors disponibles uniquement pour Aspose.Slides, et elles sont déployées avec l’application. *FontCheck* le fait : lorsque son répertoire de travail, */app* dans le conteneur, contient un dossier *fonts*, le programme transmet ce dossier à `loadExternalFonts` avant de créer la présentation. [Custom Font](/slides/fr/java/custom-font/) décrit les autres façons de fournir des polices, comme le chargement depuis la mémoire.

Dans le *Dockerfile*, supprimez l’instruction `COPY fonts/ /usr/local/share/fonts/` et ajoutez‑la après l’instruction qui copie le dossier *lib* :

```dockerfile
COPY fonts/ ./fonts/
```

Reconstruisez l’image et exécutez la vérification avec les mêmes deux commandes. Le dossier d’application apparaît maintenant parmi les dossiers de police, et Carlito n’est toujours pas substitué :

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

`loadExternalFonts` ajoute des polices aux polices installées, mais le support des polices de Java requiert toujours au moins une police installée. Dans une image dépourvue de toute police, `loadExternalFonts` s’arrête avec l’erreur « Fontconfig head is null, check your fonts or fonts configuration ».

## **Définir une police par défaut pour les polices manquantes**

Lorsqu’une police est manquante, Aspose.Slides utilise une police de substitution qu’il choisit lui‑même. Pour la choisir vous‑même, transmettez le nom de la police à la méthode [setDefaultRegularFont](https://reference.aspose.com/slides/fr/java/com.aspose.slides/loadoptions/#setDefaultRegularFont-java.lang.String-) de [LoadOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/loadoptions/) et passez les options au constructeur [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/). *FontCheck* lit le nom de la police depuis la variable d’environnement `DEFAULT_FONT`. Avec Carlito chargé, utilisez‑le pour les polices manquantes :

```bash
docker run --rm -e DEFAULT_FONT=Carlito font-check
```

Calibri est maintenant dessiné avec Carlito, dont les caractères ont les mêmes largeurs que ceux de Calibri, de sorte que le texte conserve ses sauts de ligne :

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Carlito
```

La police par défaut remplace chaque police manquante. Pour mapper des polices individuelles, par exemple Arial vers Liberation Sans et Calibri vers Carlito, utilisez les [règles de substitution de police](/slides/fr/java/font-substitution/). Les règles modifient le rendu, mais `getSubstitutions` ne les reflète pas, il faut donc vérifier les polices dans le fichier de sortie. Pour le texte asiatique, appelez également [setDefaultAsianFont](https://reference.aspose.com/slides/fr/java/com.aspose.slides/loadoptions/#setDefaultAsianFont-java.lang.String-); voir [Default Font](/slides/fr/java/default-font/).

## **Installer des polices sur Alpine Linux**

L’image Eclipse Temurin basée sur Alpine contient également les polices DejaVu ; [Run on Alpine Linux](/slides/fr/java/how-to-run-aspose-slides-in-docker/#run-on-alpine-linux) décrit son étape d’exécution. Pour installer également les polices de base Microsoft, remplacez l’étape d’exécution du Dockerfile *font-check* par celle‑ci :

```dockerfile
FROM eclipse-temurin:21-jre-alpine
RUN apk add --no-cache msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -f
WORKDIR /app
COPY --from=build /src/target/font-check.jar .
COPY --from=build /src/target/lib ./lib
RUN adduser -D app && mkdir output && chown app output
USER app
ENTRYPOINT ["java", "-cp", "font-check.jar:lib/*", "FontCheck"]
```

`update-ms-fonts` télécharge et installe les mêmes polices de base Microsoft que le paquet Debian et Ubuntu, et leur EULA s’applique de la même façon. `fc-cache` met à jour le cache des polices de fontconfig. Construisez l’image et exécutez la vérification avec les deux commandes de [Check Which Fonts Are Substituted](#check-which-fonts-are-substituted). Il affiche :

```text
Font folders: /usr/share/fonts, /home/app/.local/share/fonts, /home/app/.fonts
Font substitutions:
  Calibri -> Arial
```

Les autres étapes de cette page fonctionnent de la même manière sur Alpine : copiez le dossier *fonts* vers */usr/local/share/fonts* ou vers le dossier de l’application, et définissez `DEFAULT_FONT` pour choisir la police par défaut. L’image Alpine ne possède pas de dossier */usr/local/share/fonts*, de sorte que ce dossier n’apparaît sur la ligne `Font folders` qu’après qu’une instruction `COPY` l’a créé.

## **FAQ**

**Pourquoi une présentation apparaît‑elle différemment lorsqu’elle est convertie sur un serveur ?**

Le serveur ne possède pas les polices utilisées par la présentation, de sorte qu’Aspose.Slides dessine le texte avec une police de substitution dont les lettres ont d’autres largeurs. Exécutez *FontCheck* avec les noms de police de la présentation pour voir quelles polices sont substituées, puis installez ces polices ou chargez‑les depuis le dossier de l’application.

**Le build a installé ttf‑mscorefonts‑installer, mais Arial est toujours substitué. Pourquoi ?**

L’EULA n’a pas été acceptée avant l’installation du paquet, de sorte que le programme d’installation a sauté les polices. Placez la commande `debconf-set-selections` avant `apt-get install` dans l’instruction qui installe le paquet, comme indiqué dans [Microsoft Core Fonts](#microsoft-core-fonts), et reconstruisez l’image.

**L’ordinateur qui ouvre le PDF a‑t‑il besoin des polices ?**

Non. Dans ces exemples, le PDF contient les polices qui ont servi à dessiner le texte, de sorte qu’il apparaît de la même façon sur n’importe quel ordinateur. Les polices ne sont nécessaires que là où Aspose.Slides rend la présentation.