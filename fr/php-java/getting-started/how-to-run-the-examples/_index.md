---
title: Comment exécuter les exemples
type: docs
weight: 140
url: /php-java/how-to-run-the-examples/
---

## **Télécharger depuis GitHub**
Tous les exemples d'Aspose.Slides pour PHP via Java sont hébergés sur [Github](https://github.com/aspose-slides/Aspose.Slides-for-Java). Vous pouvez soit cloner le dépôt en utilisant votre client Github préféré, soit télécharger le fichier ZIP [ici](https://codeload.github.com/aspose-slides/Aspose.Slides-for-Java/zip/master).

Extrayez le contenu du fichier ZIP dans n'importe quel dossier de votre ordinateur. Tous les exemples se trouvent dans le dossier **Examples**.

![todo:image_alt_text](examples_directory.png)

## **Importer des exemples dans l'IDE**
Le projet utilise le système de build Maven. N'importe quel IDE moderne peut facilement ouvrir ou importer le projet et ses dépendances. Ci-dessous, nous vous montrons comment utiliser des IDE populaires pour construire et exécuter les exemples.

### **IntelliJ IDEA**
Cliquez sur le menu **Fichier** et choisissez **Ouvrir**. Accédez au dossier du projet et sélectionnez le fichier **pom.xml**.

![todo:image_alt_text](idea_select_file_or_directory_to_import.png)

Cela ouvrira le projet et téléchargera automatiquement les dépendances. Dans l'onglet Projet, parcourez les exemples dans le dossier **src/main/java**. Pour exécuter un exemple, faites simplement un clic droit sur le fichier et choisissez "Exécuter ..", l'exemple sera exécuté et la sortie sera affichée dans la fenêtre de sortie de la console intégrée.

![todo:image_alt_text](idea_run_example.png)

### **Eclipse**
Cliquez sur le menu **Fichier** et choisissez **Importer**. Sélectionnez **Maven** - Projets Maven existants.

![todo:image_alt_text](eclipse_import.png)

Accédez au dossier que vous avez cloné ou téléchargé depuis GitHub et sélectionnez le fichier **pom.xml**. Cela ouvrira le projet et téléchargera automatiquement les dépendances. Dans l'onglet Explorateur de packages, parcourez les exemples dans le dossier **src/main/java**. Pour exécuter un exemple, faites simplement un clic droit sur le fichier et choisissez **Exécuter en tant que** - **Application Java**, l'exemple sera exécuté et la sortie sera affichée dans la fenêtre de sortie de la console intégrée.

![todo:image_alt_text](eclipse_run_example.png)

### **NetBeans**
Cliquez sur le menu **Fichier** et choisissez **Ouvrir le projet**. Accédez au dossier que vous avez cloné ou téléchargé depuis GitHub. L'icône du dossier **Examples** indiquera qu'il s'agit d'un projet Maven. Sélectionnez Examples et ouvrez-le.

![todo:image_alt_text](netbeans_openproject.png)

Cela ouvrira le projet et téléchargera automatiquement les dépendances. Dans l'onglet Projets, parcourez les exemples dans **packages source**. Pour exécuter un exemple, faites simplement un clic droit sur le fichier et choisissez **Exécuter le fichier**, l'exemple sera exécuté et la sortie sera affichée dans la fenêtre de sortie de la console intégrée.

![todo:image_alt_text](netbeans_run_example.png)

## **Ajouter la bibliothèque Aspose.Slides dans le dépôt local Maven**
Lorsque vous importez le projet **Aspose.Slides Examples** dans l'IDE, Maven télécharge automatiquement le fichier JAR aspose.slides depuis le [Dépôt Maven d'Aspose](https://releases.aspose.com/php-java/repo/com/aspose/). Dans le cas où vous n'avez pas accès à Internet, vous pouvez ajouter manuellement le JAR dans votre dépôt local.

### **mvn install**
Téléchargez le [aspose.slides](https://releases.aspose.com/php-java/repo/com/aspose/aspose-slides/), extrayez-le et copiez le aspose.slides-version.jar ailleurs, par exemple sur le lecteur c. Exécutez la commande suivante :

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

Maintenant, le JAR **aspose.slides** est copié dans votre dépôt local Maven.

### **pom.xml**
Après l'installation, déclarez simplement la coordonnée **aspose.slides** dans le pom.xml. Ajoutez le dépôt suivant dans l'onglet repositories et la dépendance dans l'onglet dependencies.

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
Construisez-le, maintenant le JAR **aspose.slides** est récupérable depuis votre dépôt local Maven.

## **Contribuer**
Si vous souhaitez ajouter ou améliorer un exemple, nous vous encourageons à contribuer au projet. Tous les exemples et projets vitrine de ce dépôt sont open source et peuvent être utilisés librement dans vos propres applications.

Pour contribuer, vous pouvez forker le dépôt, modifier le code source et soumettre une Pull Request. Nous examinerons les modifications et les inclurons dans le dépôt si elles sont jugées utiles.