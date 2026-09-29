---
title: Exigences système
type: docs
weight: 60
url: /fr/java/system-requirements/
keywords:
- exigences système
- plates-formes prises en charge
- versions Java
- JDK
- JRE
- fontconfig
- polices
- Docker
- Alpine
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Vérifiez ce dont Aspose.Slides for Java a besoin avant de l’installer : les versions Java et systèmes d’exploitation pris en charge, ainsi que la bibliothèque de polices et les polices requises par Linux."
---
## **Introduction**

Aspose.Slides for Java est une bibliothèque autonome : elle ne nécessite pas Microsoft PowerPoint ni Microsoft Office. C’est un seul fichier JAR, publié dans le dépôt Maven d’Aspose. Le fichier JAR ne contient que des classes Java et des ressources, sans bibliothèques natives, et ne déclare aucune dépendance à d’autres bibliothèques. Le même fichier s’exécute donc sur tous les systèmes d’exploitation et processeurs pour lesquels un runtime Java pris en charge est disponible.

Cet article énumère les versions Java et les systèmes d’exploitation pris en charge ainsi que la bibliothèque de polices et les polices requises sous Linux, et se termine par un petit programme qui vérifie votre configuration. Pour ajouter la bibliothèque à un projet, consultez [Installation](/slides/fr/java/installation/).

## **Supported Java Versions**

Aspose.Slides pour Java fonctionne avec Java 8 ou ultérieur, avec un JDK ou un JRE. Cela comprend les versions à support à long terme Java 8, 11, 17, 21 et 25, ainsi que les versions ultérieures telles que Java 26 et Java 27. Le runtime Java peut provenir de n’importe quel fournisseur, par exemple Eclipse Temurin, Amazon Corretto, Oracle ou les paquets OpenJDK d’une distribution Linux.

Aspose.Slides ne nécessite aucune option JVM, comme `--add-opens`, sur aucune de ces versions. Sous Java 11, la JVM affiche un avertissement commençant par « WARNING: An illegal reflective access operation has occurred » ; cet avertissement n’affecte pas le résultat.

{{% alert color="warning" title="Warning" %}}
Java 6 et Java 7 sont obsolètes. Aspose.Slides pour Java 26.9 fonctionne encore avec eux mais affiche un avertissement de dépréciation. À partir de la version 26.10, Java 8 est le minimum, et Java 6 et Java 7 ne sont plus pris en charge.
{{% /alert %}}

Le projet Maven et les commandes de [Installation](/slides/fr/java/installation/) nécessitent JDK 11 ou ultérieur. Avec Java 8, compilez et exécutez votre programme comme indiqué dans [Check Your Setup](#check-your-setup).

## **Supported Operating Systems**

Comme le fichier JAR ne contient pas de code natif, Aspose.Slides pour Java fonctionne sous Windows, Linux et macOS, sur toute architecture processeur supportée par le runtime Java, comme x64 et ARM64. Le runtime Java est la seule exigence sous Windows. Sous Linux, le support des polices de Java nécessite également la bibliothèque de polices et les polices décrites dans [Linux](#linux).

## **Linux**

Aspose.Slides pour Java met en page et dessine le texte avec le support des polices du runtime Java. Sous Linux, ce support requiert la bibliothèque fontconfig et au moins une police installée. Les images officielles de conteneurs des distributions Linux ne les contiennent souvent pas. Sans elles, le premier exemple de [Create Presentations](/slides/fr/java/create-presentation/) échoue lors de l’enregistrement de la présentation, laisse un fichier vide et signale l’erreur suivante :

```text
java.lang.RuntimeException: Fontconfig head is null, check your fonts or fonts configuration
```

Les images de conteneur officielles `eclipse-temurin`, pour Ubuntu et pour Alpine Linux, contiennent déjà fontconfig et les polices DejaVu, rien n’a donc besoin d’être installé. Sur d’autres systèmes, installez les paquets ci‑dessous. Les commandes pour Debian, Ubuntu et Red Hat utilisent `sudo `; dans un Dockerfile, exécutez‑les dans une instruction `RUN` sans `sudo`. Les polices DejaVu suffisent au fonctionnement d’Aspose.Slides ; les polices utilisées par vos présentations sont détaillées dans [Fonts](#fonts).

### **Debian and Ubuntu**

Si vous installez Java à partir des paquets Debian ou Ubuntu avec les paramètres par défaut d’`apt‑get`, comme le fait la commande de [Installation](/slides/fr/java/installation/#linux), les paquets Java installent également la bibliothèque fontconfig, les polices DejaVu et la bibliothèque HarfBuzz dont ces paquets Java ont besoin, et rien d’autre n’est requis.

Avec un runtime Java provenant d’une autre source, comme une archive Eclipse Temurin, installez fontconfig et les polices DejaVu :

```bash
sudo apt-get update && sudo apt-get install -y fontconfig fonts-dejavu-core
```

Un Dockerfile installe souvent les paquets Java Debian ou Ubuntu, tels que `openjdk-21-jdk-headless` ou `default-jdk-headless`, avec l’option `--no-install-recommends`, qui ignore les trois. Installez fontconfig et les polices DejaVu avec la commande ci‑dessus, et installez également HarfBuzz :

```bash
sudo apt-get install -y libharfbuzz0b
```

Sans HarfBuzz, ces paquets Java affichent `Please install the openjdk-*-jre package or recommended packages for openjdk-*-jre-headless`, et l’enregistrement échoue avec une `UnsatisfiedLinkError` indiquant que `libharfbuzz.so.0` ne peut pas être ouvert.

### **Red Hat Enterprise Linux**

Les paquets `java-<version>-openjdk-headless` de Red Hat Enterprise Linux n’installent pas la bibliothèque fontconfig. Installez‑la avec les polices DejaVu :

```bash
sudo dnf install -y fontconfig dejavu-sans-fonts
```

Les paquets complets `java-<version>-openjdk` installent fontconfig et les polices en tant que dépendances, tout comme les paquets Amazon Corretto d’Amazon Linux 2023, par exemple `java-21-amazon-corretto-headless`.

### **Alpine Linux**

Dans un Dockerfile basé sur Alpine Linux, installez fontconfig et les polices DejaVu :

```dockerfile
RUN apk add --no-cache fontconfig ttf-dejavu
```

Sur les versions actuelles d’Alpine, `ttf-dejavu` installe le paquet `font-dejavu`. Installez Java avec le paquet `openjdk<version>-jre` ou `openjdk<version>-jdk`, par exemple `openjdk25-jdk`. Les paquets `openjdk<version>-jre-headless` d’Alpine Linux ne contiennent pas la bibliothèque de polices de Java, si bien que le programme échoue avec `UnsatisfiedLinkError: no fontmanager in system library path`, même lorsque les polices sont installées.

### **Fonts**

Pour que le texte soit rendu avec les bonnes polices et métriques, les polices utilisées par vos présentations, ou des substituts appropriés, doivent être installées sur le système ou chargées par votre application. Consultez [Deploy Fonts](/slides/fr/java/deploy-fonts/), [Font Substitution](/slides/fr/java/font-substitution/) et [Custom Fonts](/slides/fr/java/custom-font/).

## **Check Your Setup**

Pour vérifier que la bibliothèque et ses prérequis sont en place, exécutez un programme qui enregistre une présentation et rend une diapositive sous forme d’image. L’enregistrement et le rendu utilisent le support des polices du runtime Java, fourni par les exigences Linux décrites plus haut.

Enregistrez le code ci‑dessous sous le nom *CheckSetup.java* dans le dossier contenant le fichier JAR Aspose.Slides. Pour télécharger le fichier JAR, consultez [Use the JAR File without Maven](/slides/fr/java/installation/#use-the-jar-file-without-maven).

```java
import com.aspose.slides.*;

public class CheckSetup {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            // Ajoutez un rectangle avec du texte à la première diapositive et enregistrez la présentation.
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
            shape.getTextFrame().setText("Hello, Aspose.Slides!");
            presentation.save("hello.pptx", SaveFormat.Pptx);

            // Rendez la diapositive à un pixel par point et enregistrez l'image.
            IImage image = slide.getImage(1f, 1f);
            try {
                image.save("hello.png", ImageFormat.Png);
            } finally {
                image.dispose();
            }
        } finally {
            presentation.dispose();
        }
    }
}
```

Avec JDK 11 ou ultérieur, exécutez le programme dans ce dossier avec la commande ci‑dessus. Si votre fichier JAR porte un nom différent, adaptez‑le dans les commandes.

```bash
java -cp aspose-slides-26.9-jdk16.jar CheckSetup.java
```

Avec Java 8, ou sur un système ne disposant que d’un JRE, compilez le programme avec `javac` depuis un JDK puis exécutez la classe compilée. Sous Linux et macOS, lancez :

```bash
javac -cp aspose-slides-26.9-jdk16.jar CheckSetup.java
java -cp aspose-slides-26.9-jdk16.jar:. CheckSetup
```

Sous Windows, lancez la même commande `javac`, puis exécutez la classe en utilisant le point‑virgule comme séparateur de chemin de classes. Conservez les guillemets, afin que PowerShell ne traite pas le point‑virgule comme la fin de la commande : `java -cp "aspose-slides-26.9-jdk16.jar;." CheckSetup`.

Le programme ajoute un rectangle contenant du texte à la première diapositive et enregistre la présentation sous le nom *hello.pptx* avec la méthode [save](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#save-java.lang.String-int-). Il rend ensuite la diapositive avec [getImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/slide/#getImage-float-float-) et enregistre le résultat sous le nom *hello.png* avec [IImage.save](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iimage/#save-java.lang.String-int-) au format [ImageFormat.Png](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imageformat/). Un facteur d’échelle de 1 rend un pixel par point, ainsi la diapositive par défaut de 720 × 540 points devient une image de 720 × 540 pixels, le texte étant visible à l’intérieur du rectangle. Sans licence, les deux fichiers portent également un filigrane d’évaluation ; voir [Licensing](/slides/fr/java/licensing/). Si un prérequis manque, le programme s’arrête avec l’une des erreurs décrites dans [Linux](#linux).

## **Development Tools**

Vous pouvez développer des applications utilisant Aspose.Slides avec n’importe quel JDK d’une version Java prise en charge. Utilisez Apache Maven avec le dépôt Maven d’Aspose, comme décrit dans [Installation](/slides/fr/java/installation/), ou tout autre outil de construction pouvant utiliser un dépôt Maven. Vous pouvez également ajouter le fichier JAR au classpath de votre IDE ou de votre outil de construction manuellement.

## **FAQ**

**Do I need Microsoft PowerPoint installed for conversions and rendering?**

No, PowerPoint is not required. Aspose.Slides is a standalone engine for [creating](/slides/fr/java/create-presentation/), modifying, [converting](/slides/fr/java/convert-presentation/), and [rendering](/slides/fr/java/convert-powerpoint-to-png/) presentations.

**Does Aspose.Slides for Java need a display or a desktop environment on a Linux server?**

No. Aspose.Slides does not need an X server or a display, so it runs on servers and in containers. On Linux, it needs only the font library and fonts described in [Linux](#linux).

**Which fonts are needed for correct rendering?**

The fonts used in the presentation, or suitable [substitutes](/slides/fr/java/font-substitution/), must be available. On Linux and macOS, install the font packages that your presentations need to get consistent rendering.

**Why does a custom font render as a fallback or missing text on Linux?**

If the font file has inconsistent or corrupted name-table entries, the Linux font-matching stack (FreeType/fontconfig) may select an invalid record, causing the font to be unresolved. Using a font version with corrected name-table records or installing a consistent replacement resolves the issue.