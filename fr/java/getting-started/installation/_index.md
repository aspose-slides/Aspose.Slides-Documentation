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

Cet article explique comment ajouter Aspose.Slides for Java à un projet. Aspose.Slides for Java est publié dans le dépôt Maven propre à Aspose, pas dans Maven Central, il faut donc qu’un projet Maven déclare ce dépôt. Vous pouvez également télécharger le fichier JAR et le placer vous‑même sur le classpath. Les deux méthodes se terminent par un petit programme qui confirme que la bibliothèque fonctionne.

Aspose.Slides for Java ne nécessite pas Microsoft PowerPoint. Il génère de manière programmatique les fichiers de présentation nécessaires. Cependant, pour visualiser les présentations générées, vous pouvez avoir besoin de Microsoft PowerPoint ou d’un autre visualiseur de présentations.

## **Prérequis**

- Un kit de développement Java (JDK). Le projet et les commandes de cet article nécessitent JDK 11 ou ultérieur. Sous JDK 11, le programme qui vérifie l’installation affiche un avertissement commençant par « WARNING: An illegal reflective access operation has occurred » ; cela n’affecte pas le résultat et peut être ignoré.
- [Apache Maven](https://maven.apache.org/install.html), si vous utilisez la voie Maven.
- Sous Linux, la bibliothèque fontconfig et au moins une police installée. Voir [Linux](#linux).

## **Installer depuis le dépôt Maven**

Aspose héberge ses bibliothèques Java dans son propre [Maven repository](https://releases.aspose.com/java/repo/com/aspose/). Pour utiliser [Aspose.Slides for Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) dans un projet Maven, ajoutez deux entrées à votre *pom.xml*.

1. **Déclarer le dépôt Maven d’Aspose.**

   ```xml
   <repositories>
       <repository>
           <id>AsposeJavaAPI</id>
           <name>Aspose Java API</name>
           <url>https://releases.aspose.com/java/repo/</url>
       </repository>
   </repositories>
   ```

2. **Ajouter la dépendance Aspose.Slides for Java.**

   ```xml
   <dependencies>
       <dependency>
           <groupId>com.aspose</groupId>
           <artifactId>aspose-slides</artifactId>
           <version>26.9</version>
           <classifier>jdk16</classifier>
       </dependency>
   </dependencies>
   ```

Le classifieur `jdk16` est requis : il sélectionne la version Java SE de la bibliothèque. Remplacez `26.9` par la dernière version répertoriée dans le [repository](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). Le dépôt publie un fichier de somme de contrôle SHA‑1 à côté de chaque JAR, que Maven vérifie lors du téléchargement de la bibliothèque.

### **Vérifier l'installation**

Pour tester la configuration avec un nouveau projet :

1. Créez un dossier pour le projet et enregistrez-y ce *pom.xml* :

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

   En plus du dépôt et de la dépendance, ce *pom.xml* fixe la version Java à compiler, indique la classe exécutée par `mvn exec:java` et verrouille le plugin du compilateur, car l’ancien plugin utilisé par défaut par certaines installations Maven ignore le paramètre `maven.compiler.release`.

2. Enregistrez le premier exemple de [Create Presentations](/slides/fr/java/create-presentation/) sous *src/main/java/HelloSlides.java*.

3. Dans le dossier du projet, exécutez :

   ```bash
   mvn compile exec:java
   ```

Maven télécharge Aspose.Slides for Java, compile le programme et l’exécute. Le programme enregistre *new_presentation.pptx* dans le dossier du projet.

## **Utiliser le fichier JAR sans Maven**

1. Téléchargez *aspose-slides-26.9-jdk16.jar* depuis le [version folder](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/26.9/) du dépôt. Pour une autre version, ouvrez son répertoire dans le [repository](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) et téléchargez le fichier se terminant par *-jdk16.jar*.
2. Enregistrez le premier exemple de [Create Presentations](/slides/fr/java/create-presentation/) sous *HelloSlides.java* dans le même dossier que le fichier JAR.
3. Dans ce dossier, exécutez :

   ```bash
   java -cp aspose-slides-26.9-jdk16.jar HelloSlides.java
   ```

Le JDK compile et exécute le fichier source unique, et le programme enregistre *new_presentation.pptx* dans le dossier. Dans votre propre application, ajoutez le fichier JAR au classpath de votre outil de construction ou de votre IDE.

## **Linux**

Aspose.Slides for Java utilise le support des polices de Java, qui sous Linux requiert la bibliothèque fontconfig et au moins une police installée. Sans ces éléments, l’enregistrement d’une présentation échoue avec l’erreur « Fontconfig head is null, check your fonts or fonts configuration ». Les images serveur et conteneur minimalistes peuvent ne contenir ni l’un ni l’autre ; l’image officielle Ubuntu, par exemple, ne possède aucun des deux.

Sur Debian et Ubuntu, cette commande installe un JDK, Maven, fontconfig et les polices DejaVu :

```bash
sudo apt-get update && sudo apt-get install -y default-jdk maven fontconfig fonts-dejavu-core
```

Les polices utilisées dans vos présentations, ou des substituts appropriés, doivent également être installées pour que le texte s’affiche correctement.

## **FAQ**

### Comment vérifier qu’Aspose.Slides est correctement intégré ?

Construisez votre projet, créez une instance vide de [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) et enregistrez‑la sous un nouveau nom. Si le fichier est créé sans lever d’exception, la bibliothèque a été intégrée avec succès.

### Comment limiter la consommation de mémoire lors du traitement de présentations volumineuses ?

Augmentez les limites de mémoire JVM uniquement autant que nécessaire, et appelez [dispose](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#dispose--) sur chaque instance de [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) dans un bloc `finally` afin de libérer rapidement le cache. Cela évite les erreurs d’out‑of‑memory et maintient une utilisation mémoire prévisible pendant les opérations en lot.

### Puis-je exclure les formats d’exportation indésirables pour réduire la taille du JAR final ?

Les versions actuelles d’Aspose.Slides sont distribuées comme une bibliothèque monolithique unique, il n’est donc pas possible de désactiver des exportateurs spécifiques tels que PDF ou SVG lors de la construction.