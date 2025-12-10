---
title: Comment exécuter les exemples
type: docs
weight: 140
url: /fr/java/how-to-run-the-examples/
keywords:
- exemples
- exigences logicielles
- GitHub
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Exécutez rapidement les exemples Aspose.Slides pour Java : clonez le dépôt, restaurez les packages, puis compilez et testez les fonctionnalités pour PPT, PPTX et ODP."
---

## **Télécharger Aspose.Slides depuis GitHub**
Tous les exemples d'Aspose.Slides pour Java sont hébergés sur [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java). Vous pouvez soit cloner le dépôt avec votre client GitHub préféré, soit télécharger le fichier ZIP depuis [ici](https://codeload.github.com/aspose-slides/Aspose.Slides-for-Java/zip/master).

Extrayez le contenu du fichier ZIP vers n'importe quel dossier de votre ordinateur. Tous les exemples se trouvent dans le dossier **Examples**.

![todo:image_alt_text](examples_directory.png)

## **Importer les exemples dans l'IDE**
Le projet utilise le système de construction Maven. Tout IDE moderne peut facilement ouvrir ou importer le projet et ses dépendances. Ci-dessous, nous vous montrons comment utiliser les IDE populaires pour compiler et exécuter les exemples.

### **IntelliJ IDEA**
Cliquez sur le menu **File** et choisissez **Open**. Parcourez le dossier du projet et sélectionnez le fichier **pom.xml**.

![todo:image_alt_text](idea_select_file_or_directory_to_import.png)

Il ouvrira le projet et téléchargera automatiquement les dépendances. Depuis l'onglet Project, parcourez les exemples dans le dossier **src/main/java**. Pour exécuter un exemple, faites simplement un clic droit sur le fichier et choisissez "Run ..", l'exemple sera exécuté et la sortie sera affichée dans la fenêtre de console intégrée.

![todo:image_alt_text](idea_run_example.png)

### **Eclipse**
Cliquez sur le menu **File** et choisissez **Import**. Sélectionnez **Maven** - Existing Maven Projects.

![todo:image_alt_text](eclipse_import.png)

Parcourez le dossier que vous avez cloné ou téléchargé depuis GitHub et sélectionnez le fichier **pom.xml**. Il ouvrira le projet et téléchargera automatiquement les dépendances. Depuis l'onglet Package Explorer, parcourez les exemples dans le dossier **src/main/java**. Pour exécuter un exemple, faites simplement un clic droit sur le fichier et choisissez **Run As** - **Java Application**, l'exemple sera exécuté et la sortie sera affichée dans la fenêtre de console intégrée.

![todo:image_alt_text](eclipse_run_example.png)

### **NetBeans**
Cliquez sur le menu **File** et choisissez **Open Project**. Parcourez le dossier que vous avez cloné ou téléchargé depuis GitHub. L'icône du dossier **Examples** indiquera qu'il s'agit d'un projet Maven. Sélectionnez **Examples** et ouvrez-le.

![todo:image_alt_text](netbeans_openproject.png)

Il ouvrira le projet et téléchargera automatiquement les dépendances. Depuis l'onglet Projects, parcourez les exemples dans **source packages**. Pour exécuter un exemple, faites simplement un clic droit sur le fichier et choisissez **Run File**, l'exemple sera exécuté et la sortie sera affichée dans la fenêtre de console intégrée.

![todo:image_alt_text](netbeans_run_example.png)

## **Ajouter la bibliothèque Aspose.Slides dans le référentiel Maven local**
Lorsque vous importez le projet **Aspose.Slides Examples** dans l'IDE, Maven télécharge automatiquement le fichier JAR aspose.slides depuis le [Répertoire Maven d'Aspose](https://releases.aspose.com/java/repo/com/aspose/). Si vous n'avez pas d'accès à Internet, vous pouvez ajouter manuellement le JAR dans votre référentiel local.

### **mvn install**
Téléchargez le [aspose.slides](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/), extrayez-le et copiez le fichier aspose.slides-version.jar à un autre endroit, par exemple le lecteur C. Exécutez la commande suivante :
```
mvn install:install-file
    -Dfile=c:\aspose.slides-version.jar
    -DgroupId=com.aspose
    -DartifactId=aspose-slides
    -Dversion={version}
    -Dpackaging=jar
```


Le JAR **aspose.slides** est maintenant copié dans votre référentiel Maven local.

### **pom.xml**
Après l'installation, il suffit de déclarer le coordinate **aspose.slides** dans le pom.xml. Ajoutez le dépôt suivant dans l'onglet repositories et la dépendance dans l'onglet dependencies.
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
```


### **Terminé**
Compilez-le, le JAR **aspose.slides** peut désormais être récupéré depuis votre référentiel Maven local.

## **Contribuer**
Si vous souhaitez ajouter ou améliorer un exemple, nous vous encourageons à contribuer au projet. Tous les exemples et projets de démonstration de ce référentiel sont open source et peuvent être utilisés librement dans vos propres applications.

Pour contribuer, vous pouvez forker le référentiel, modifier le code source et soumettre une Pull Request. Nous examinerons les modifications et les inclurons dans le référentiel si elles sont utiles.