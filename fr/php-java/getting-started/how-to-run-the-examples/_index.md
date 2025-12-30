---
title: Comment exécuter les exemples
type: docs
weight: 140
url: /fr/php-java/how-to-run-the-examples/
keywords:
- exemples
- exigences logicielles
- GitHub
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Exécutez rapidement les exemples d'Aspose.Slides pour PHP via Java : clonez le dépôt, restaurez les packages, puis compilez et testez les fonctionnalités pour PPT, PPTX et ODP."
---

## **Télécharger depuis GitHub**
Tous les exemples d'Aspose.Slides pour PHP via Java sont hébergés sur [Github](https://github.com/aspose-slides/Aspose.Slides-for-Java). Vous pouvez soit cloner le référentiel avec votre client Github préféré, soit télécharger le fichier ZIP depuis [ici](https://codeload.github.com/aspose-slides/Aspose.Slides-for-Java/zip/master).

Extrayez le contenu du fichier ZIP dans n'importe quel dossier de votre ordinateur. Tous les exemples se trouvent dans le dossier **Examples**.

![todo:image_alt_text](examples_directory.png)

## **Importer les exemples dans l'IDE**
Le projet utilise le système de construction Maven. Tout IDE moderne peut facilement ouvrir ou importer le projet et ses dépendances. Vous trouverez ci‑dessous comment utiliser les IDE populaires pour compiler et exécuter les exemples.

### **IntelliJ IDEA**
Cliquez sur le menu **File** et choisissez **Open**. Parcourez le dossier du projet et sélectionnez le fichier **pom.xml**.

![todo:image_alt_text](idea_select_file_or_directory_to_import.png)

Le projet s'ouvrira et les dépendances seront téléchargées automatiquement. Dans l'onglet Project, parcourez les exemples dans le dossier **src/main/java**. Pour exécuter un exemple, faites simplement un clic droit sur le fichier et choisissez "Run ..", l'exemple sera exécuté et la sortie s'affichera dans la fenêtre de console intégrée.

![todo:image_alt_text](idea_run_example.png)

### **Eclipse**
Cliquez sur le menu **File** et choisissez **Import**. Sélectionnez **Maven** - Existing Maven Projects.

![todo:image_alt_text](eclipse_import.png)

Parcourez le dossier que vous avez cloné ou téléchargé depuis GitHub et sélectionnez le fichier **pom.xml**. Le projet s'ouvrira et les dépendances seront téléchargées automatiquement. Dans l'onglet Package Explorer, parcourez les exemples dans le dossier **src/main/java**. Pour exécuter un exemple, faites simplement un clic droit sur le fichier et choisissez **Run As** - **Java Application**, l'exemple sera exécuté et la sortie s'affichera dans la fenêtre de console intégrée.

![todo:image_alt_text](eclipse_run_example.png)

### **NetBeans**
Cliquez sur le menu **File** et choisissez **Open Project**. Parcourez le dossier que vous avez cloné ou téléchargé depuis GitHub. L'icône du dossier **Examples** indiquera qu'il s'agit d'un projet Maven. Sélectionnez **Examples** et ouvrez-le.

![todo:image_alt_text](netbeans_openproject.png)

Le projet s'ouvrira et les dépendances seront téléchargées automatiquement. Dans l'onglet Projects, parcourez les exemples dans **source packages**. Pour exécuter un exemple, faites simplement un clic droit sur le fichier et choisissez **Run File**, l'exemple sera exécuté et la sortie s'affichera dans la fenêtre de console intégrée.

![todo:image_alt_text](netbeans_run_example.png)

## **Ajouter la bibliothèque Aspose.Slides au dépôt local Maven**
Lorsque vous importez le projet **Aspose.Slides Examples** dans l'IDE, Maven télécharge automatiquement le fichier JAR aspose.slides depuis le [Aspose Maven Repository](https://releases.aspose.com/php-java/repo/com/aspose/). Si vous n'avez pas accès à Internet, vous pouvez ajouter manuellement le JAR à votre dépôt local.

### **mvn install**
Téléchargez le [aspose.slides](https://releases.aspose.com/php-java/repo/com/aspose/aspose-slides/), extrayez-le et copiez le fichier aspose.slides-version.jar ailleurs, par exemple sur le lecteur C. Exécutez la commande suivante:
```php

```

mvn install:install-file
    -Dfile=c:\aspose.slides-version.jar
    -DgroupId=com.aspose
    -DartifactId=aspose-slides
    -Dversion={version}
    -Dpackaging=jar
```php

```


Désormais, le JAR **aspose.slides** est copié dans votre dépôt local Maven.

### **pom.xml**
Après l'installation, il suffit de déclarer la coordonnée **aspose.slides** dans le pom.xml. Ajoutez le dépôt suivant dans l'onglet repositories et la dépendance dans l'onglet dependencies.
``` xml
<repository>
    <id>aspose-maven-repository</id>
    <url>http://repository.aspose.com/repo/</url>
</repository>

<dependency>
    <groupId>com.aspose</groupId>
    <artifactId>aspose-slides</artifactId>
    <version>18.6</version>
    <classifier>jdk16</classifier>
</dependency>
```php

```


### **Terminé**
Compilez-le, le JAR **aspose.slides** pourra désormais être récupéré depuis votre dépôt local Maven.

## **Contribuer**
Si vous souhaitez ajouter ou améliorer un exemple, nous vous encourageons à contribuer au projet. Tous les exemples et projets de démonstration dans ce dépôt sont open source et peuvent être utilisés librement dans vos propres applications.

Pour contribuer, vous pouvez forker le dépôt, modifier le code source et soumettre une Pull Request. Nous examinerons les modifications et les inclurons dans le dépôt si elles sont jugées utiles.