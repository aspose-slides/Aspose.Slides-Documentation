---
title: Exigences du système
type: docs
weight: 60
url: /fr/java/system-requirements/
keywords:
- exigences du système
- plateformes prises en charge
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
description: "Vérifiez ce dont Aspose.Slides for Java a besoin avant de l'installer: les versions Java prises en charge et les systèmes d'exploitation, ainsi que la bibliothèque de polices et les polices requises par Linux."
---
## **Introduction**

Aspose.Slides for Java est une bibliothèque autonome : elle ne nécessite pas Microsoft PowerPoint ni Microsoft Office. C’est un seul fichier JAR, publié dans le dépôt Maven d’Aspose. Le fichier JAR ne contient que des classes Java et des ressources, sans bibliothèques natives, et il ne déclare aucune dépendance à d’autres bibliothèques. Le même fichier s’exécute donc sur tous les systèmes d’exploitation et processeurs pour lesquels un runtime Java pris en charge est disponible.

Cet article répertorie les versions Java et les systèmes d’exploitation pris en charge ainsi que la bibliothèque de polices et les polices requises par Linux, et se termine par un petit programme qui vérifie votre configuration. Pour ajouter la bibliothèque à un projet, voir [Installation](/slides/fr/java/installation/).

## **Versions Java prises en charge**

Aspose.Slides for Java fonctionne avec Java 8 ou version ultérieure, avec un JDK ou un JRE. Cela inclut les versions à support à long terme Java 8, 11, 17, 21 et 25, ainsi que les versions ultérieures comme Java 26 et Java 27. Le runtime Java peut provenir de n’importe quel fournisseur, par exemple Eclipse Temurin, Amazon Corretto, Oracle ou les paquets OpenJDK d’une distribution Linux.

Aspose.Slides ne nécessite aucune option JVM, telle que `--add-opens`, sur aucune de ces versions. Sous Java 11, la JVM affiche un avertissement qui commence par « WARNING: An illegal reflective access operation has occurred » ; cet avertissement n’influe pas sur le résultat.

{{% alert color="warning" title="Warning" %}}
Java 6 et Java 7 sont obsolètes. Aspose.Slides for Java 26.9 fonctionne toujours avec eux mais affiche un avertissement de dépréciation. À partir de la version 26.10, Java 8 est le minimum, et Java 6 et Java 7 ne sont plus pris en charge.
{{% /alert %}}

Le projet Maven et les commandes dans [Installation](/slides/fr/java/installation/) nécessitent JDK 11 ou supérieur. Avec Java 8, compilez et exécutez votre programme comme indiqué dans [Vérifier votre configuration](#check-your-setup).

## **Systèmes d’exploitation pris en charge**

Comme le fichier JAR ne contient aucun code natif, Aspose.Slides for Java fonctionne sous Windows, Linux et macOS, sur toute architecture processeur prise en charge par le runtime Java, telle que x64 et ARM64. Le runtime Java est la seule exigence sous Windows. Sous Linux, le support des polices Java nécessite également la bibliothèque de polices et les polices décrites dans [Linux](#linux).

## **Linux**

Aspose.Slides for Java effectue la mise en page et le rendu du texte avec le support des polices du runtime Java. Sous Linux, ce support nécessite la bibliothèque fontconfig et au moins une police installée. Les images officielles de conteneurs des distributions Linux en sont souvent dépourvues. Sans elles, le premier exemple de [Créer des présentations](/slides/fr/java/create-presentation/) échoue lors de l’enregistrement de la présentation, laisse un fichier vide et signale cette erreur :

```text
java.lang.RuntimeException: Fontconfig head is null, check your fonts or fonts configuration
```

Les images officielles de conteneur `eclipse-temurin`, pour Ubuntu et Alpine Linux, contiennent déjà fontconfig et les polices DejaVu, donc aucune installation n’est nécessaire. Sur d’autres systèmes, installez les paquets ci‑dessous. Les commandes pour Debian, Ubuntu et Red Hat utilisent `sudo` ; dans un Dockerfile, exécutez‑les dans une instruction `RUN` sans `sudo`. Les polices DejaVu suffisent pour faire fonctionner Aspose.Slides ; les polices utilisées par vos présentations sont détaillées dans [Polices](#fonts).

### **Debian et Ubuntu**

Si vous installez Java à partir des paquets Debian ou Ubuntu avec les paramètres par défaut de `apt-get`, comme la commande dans [Installation](/slides/fr/java/installation/#linux) le fait, les paquets Java installent également la bibliothèque fontconfig, les polices DejaVu et la bibliothèque HarfBuzz dont ces paquets Java ont besoin, et rien d’autre n’est requis.

Avec un runtime Java provenant d’une autre source, comme une archive Eclipse Temurin, installez fontconfig et les polices DejaVu :

```bash
sudo apt-get update && sudo apt-get install -y fontconfig fonts-dejavu-core
```

Un Dockerfile installe souvent les paquets Java Debian ou Ubuntu, comme `openjdk-21-jdk-headless` ou `default-jdk-headless`, avec l’option `--no-install-recommends`, qui ignore les trois. Installez fontconfig et les polices DejaVu avec la commande ci‑dessus, et installez également HarfBuzz :

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

Dans les versions actuelles d’Alpine, `ttf-dejavu` installe le paquet `font-dejavu`. Installez Java avec le paquet `openjdk<version>-jre` ou `openjdk<version>-jdk`, comme `openjdk25-jdk`. Les paquets `openjdk<version>-jre-headless` d’Alpine Linux ne contiennent pas la bibliothèque de polices de Java, de sorte qu’avec eux le programme échoue avec `UnsatisfiedLinkError: no fontmanager in system library path`, même si les polices sont installées.

### **Polices**

Pour que le texte s’affiche avec les bonnes polices et métriques, les polices utilisées par vos présentations, ou des substituts appropriés, doivent être installées sur le système ou chargées par votre application. Voir [Déployer les polices](/slides/fr/java/deploy-fonts/), [Substitution de polices](/slides/fr/java/font-substitution/), et [Polices personnalisées](/slides/fr/java/custom-font/).

## **Vérifier votre configuration**

Pour vérifier que la bibliothèque et ses exigences sont présentes, exécutez un programme qui enregistre une présentation et rend une diapositive en image. L’enregistrement et le rendu utilisent le support des polices du runtime Java, fourni par les exigences Linux ci‑dessus.

Enregistrez le code ci‑dessus sous le nom *CheckSetup.java* dans le dossier contenant le fichier JAR d’Aspose.Slides. Pour télécharger le fichier JAR, voir [Utiliser le fichier JAR sans Maven](/slides/fr/java/installation/#use-the-jar-file-without-maven).

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

Avec JDK 11 ou version ultérieure, exécutez le programme dans ce dossier avec la commande ci‑dessous. Si votre fichier JAR porte un nom différent, modifiez le nom dans les commandes.

```bash
java -cp aspose-slides-26.10-jdk8.jar CheckSetup.java
```

Avec Java 8, ou sur un système ne disposant que d’un JRE, compilez le programme avec `javac` provenant d’un JDK puis exécutez la classe compilée. Sous Linux et macOS, lancez :

```bash
javac -cp aspose-slides-26.10-jdk8.jar CheckSetup.java
java -cp aspose-slides-26.10-jdk8.jar:. CheckSetup
```

Sous Windows, lancez la même commande `javac`, puis exécutez la classe avec un point‑virgule comme séparateur de chemin de classe. Conservez les guillemets, afin que PowerShell ne considère pas le point‑virgule comme la fin de la commande : `java -cp "aspose-slides-26.10-jdk8.jar;." CheckSetup`.

Le programme ajoute un rectangle avec du texte à la première diapositive et enregistre la présentation sous le nom *hello.pptx* à l’aide de la méthode [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-). Il rend ensuite la diapositive avec [getImage](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#getImage-float-float-) et enregistre le résultat sous *hello.png* avec [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) au format [ImageFormat.Png](https://reference.aspose.com/slides/java/com.aspose.slides/imageformat/). Les facteurs d’échelle de 1 rendent un pixel par point, ainsi la diapositive par défaut de 720 × 540 points devient une image de 720 × 540 pixels, le texte étant visible à l’intérieur du rectangle. Sans licence, les deux fichiers portent également un filigrane d’évaluation ; voir [Licence](/slides/fr/java/licensing/). Si une exigence est manquante, le programme s’arrête avec l’une des erreurs décrites dans [Linux](#linux).

## **Outils de développement**

Vous pouvez créer des applications qui utilisent Aspose.Slides avec n’importe quel JDK d’une version Java prise en charge. Utilisez Apache Maven avec le dépôt Maven d’Aspose, comme décrit dans [Installation](/slides/fr/java/installation/), ou tout autre outil de construction pouvant utiliser un dépôt Maven. Vous pouvez également ajouter vous‑même le fichier JAR au classpath de votre IDE ou de votre outil de construction.

## **FAQ**

**Dois‑je installer Microsoft PowerPoint pour les conversions et le rendu ?**

Non, PowerPoint n’est pas requis. Aspose.Slides est un moteur autonome pour [création](/slides/fr/java/create-presentation/), la modification, [conversion](/slides/fr/java/convert-presentation/), et le [rendu](/slides/fr/java/convert-powerpoint-to-png/) des présentations.

**Aspose.Slides for Java a‑t‑il besoin d’un affichage ou d’un environnement de bureau sur un serveur Linux ?**

Non. Aspose.Slides n’a pas besoin d’un serveur X ou d’un affichage, il fonctionne donc sur les serveurs et dans les conteneurs. Sous Linux, il ne nécessite que la bibliothèque de polices et les polices décrites dans [Linux](#linux).

**Quelles polices sont nécessaires pour un rendu correct ?**

Les polices utilisées dans la présentation, ou des [substituts](/slides/fr/java/font-substitution/), doivent être disponibles. Sous Linux et macOS, installez les paquets de polices dont vos présentations ont besoin pour obtenir un rendu cohérent.

**Pourquoi une police personnalisée s’affiche-t‑elle comme police de secours ou texte manquant sous Linux ?**

Si le fichier de police contient des entrées de table de noms incohérentes ou corrompues, la pile de correspondance de polices Linux (FreeType/fontconfig) peut sélectionner un enregistrement invalide, entraînant l’incapacité à résoudre la police. Utiliser une version de police avec des tables de noms corrigées ou installer un remplacement cohérent résout le problème.