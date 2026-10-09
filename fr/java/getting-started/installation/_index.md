---
title: Installation
type: docs
weight: 70
url: /fr/java/installation/
keywords:
- installer Aspose.Slides
- télécharger Aspose.Slides
- utiliser Aspose.Slides
- installation Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Installez Aspose.Slides for Java depuis le dépôt Maven d'Aspose ou sous forme de fichier JAR, configurez les prérequis Linux et vérifiez l'installation avec un premier programme."
---
## **Vue d'ensemble**

Cet article explique comment ajouter Aspose.Slides for Java à un projet. Aspose.Slides for Java est publié dans le dépôt Maven propre à Aspose, pas dans Maven Central, il faut donc qu’un projet Maven déclare ce dépôt. Vous pouvez également télécharger le fichier JAR et l’ajouter vous‑même au classpath. Les deux approches se terminent par un petit programme qui confirme que la bibliothèque fonctionne.

Aspose.Slides for Java ne nécessite pas Microsoft PowerPoint. Il génère programmatiquement les fichiers de présentation nécessaires. Cependant, pour visualiser les présentations générées, il se peut que vous ayez besoin de Microsoft PowerPoint ou d’un autre visualiseur de présentations.

## **Prérequis**

- Un Kit de développement Java (JDK). Le projet et les commandes de cet article nécessitent JDK 11 ou supérieur. Sous JDK 11, le programme qui vérifie l’installation affiche un avertissement commençant par « WARNING: An illegal reflective access operation has occurred » ; cela n’affecte pas le résultat et peut être ignoré.
- [Apache Maven](https://maven.apache.org/install.html), si vous utilisez la voie Maven.
- Sous Linux, la bibliothèque fontconfig et au moins une police installée. Voir [Linux](#linux).

## **Installer depuis le dépôt Maven**

Aspose héberge ses bibliothèques Java dans son propre [dépôt Maven](https://releases.aspose.com/java/repo/com/aspose/). Pour utiliser [Aspose.Slides for Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) dans un projet Maven, ajoutez deux entrées à votre *pom.xml*.

1. **Déclarez le dépôt Maven d’Aspose.**

   ```xml
   <repositories>
       <repository>
           <id>AsposeJavaAPI</id>
           <name>Aspose Java API</name>
           <url>https://releases.aspose.com/java/repo/</url>
       </repository>
   </repositories>
   ```

2. **Ajoutez la dépendance Aspose.Slides for Java.**

   ```xml
   <dependencies>
       <dependency>
           <groupId>com.aspose</groupId>
           <artifactId>aspose-slides</artifactId>
           <version>26.10</version>
           <classifier>jdk8</classifier>
       </dependency>
   </dependencies>
   ```

Le classificateur `jdk8` est requis : il sélectionne la version Java SE de la bibliothèque. Remplacez `26.10` par la dernière version répertoriée dans le [dépôt](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). Le dépôt publie un fichier de somme de contrôle SHA‑1 à côté de chaque JAR, que Maven vérifie lors du téléchargement de la bibliothèque.

### **Vérifier l'installation**

Pour vérifier la configuration avec un nouveau projet :

1. Créez un dossier pour le projet et enregistrez ce *pom.xml* à l’intérieur :

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
               <version>26.10</version>
               <classifier>jdk8</classifier>
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

   En plus du dépôt et de la dépendance, ce *pom.xml* définit la version Java à compiler, indique la classe que `mvn exec:java` doit exécuter, et contraint le plugin du compilateur, car le plugin plus ancien utilisé par défaut par certaines installations Maven ignore le paramètre `maven.compiler.release`.

2. Enregistrez le premier exemple de [Créer des présentations](/slides/fr/java/create-presentation/) sous le nom *src/main/java/HelloSlides.java*.

3. Dans le dossier du projet, exécutez :

   ```bash
   mvn compile exec:java
   ```

Maven télécharge Aspose.Slides for Java, compile le programme et l’exécute. Le programme enregistre *new_presentation.pptx* dans le dossier du projet.

## **Utiliser le fichier JAR sans Maven**

1. Téléchargez *aspose-slides-26.10-jdk8.jar* depuis le [dossier de version](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/26.10/) du dépôt. Pour une autre version, ouvrez son dossier dans le [dépôt](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) et téléchargez le fichier se terminant par *-jdk8.jar*.
2. Enregistrez le premier exemple de [Créer des présentations](/slides/fr/java/create-presentation/) sous le nom *HelloSlides.java* dans le même dossier que le fichier JAR.
3. Dans ce dossier, exécutez :

   ```bash
   java -cp aspose-slides-26.10-jdk8.jar HelloSlides.java
   ```

Le JDK compile et exécute le fichier source unique, et le programme enregistre *new_presentation.pptx* dans le dossier. Dans votre propre application, ajoutez le fichier JAR au classpath de votre outil de construction ou de votre IDE.

## **Linux**

Aspose.Slides for Java utilise le support des polices Java, qui sous Linux nécessite la bibliothèque fontconfig et au moins une police installée. Sans eux, l’enregistrement d’une présentation échoue avec l’erreur « Fontconfig head is null, check your fonts or fonts configuration ». Les images serveur et conteneur minimales peuvent manquer des deux ; l’image de conteneur Ubuntu officielle, par exemple, ne les possède pas.

Sur Debian et Ubuntu, la commande suivante installe un JDK, Maven, fontconfig et les polices DejaVu :

```bash
sudo apt-get update && sudo apt-get install -y default-jdk maven fontconfig fonts-dejavu-core
```

Les polices utilisées dans vos présentations, ou des substituts appropriés, doivent également être installées pour que le texte s’affiche correctement.

## **FAQ**

### Comment vérifier qu’Aspose.Slides est intégré correctement ?

Compilez votre projet, créez une instance vide de [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) et enregistrez‑la sous un nouveau nom. Si le fichier est créé sans lever d’exception, la bibliothèque a été intégrée avec succès.

### Comment limiter la consommation de mémoire lors du traitement de présentations volumineuses ?

Augmentez les limites de mémoire JVM uniquement autant que nécessaire, et appelez [dispose](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#dispose--) sur chaque instance de [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) dans un bloc `finally` pour libérer rapidement le cache. Cela évite les erreurs de dépassement de mémoire et maintient une utilisation mémoire prévisible lors des traitements par lots.

### Puis‑je exclure des formats d’exportation indésirables pour réduire la taille finale du JAR ?

Les versions actuelles d’Aspose.Slides sont distribuées comme une bibliothèque monolithique unique, il n’est donc pas possible de désactiver des exportateurs spécifiques tels que PDF ou SVG lors de la construction.