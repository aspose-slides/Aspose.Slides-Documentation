---
title: Installer Aspose.Slides pour Android via Java
type: docs
weight: 90
url: /fr/androidjava/install-aspose-slides-for-android-via-java/
keywords:
- installer Aspose.Slides
- télécharger Aspose.Slides
- utiliser Aspose.Slides
- installation Aspose.Slides
- Gradle
- référentiel Maven
- PowerPoint
- OpenDocument
- présentation
- Android
- Java
- Aspose.Slides
description: "Ajoutez Aspose.Slides pour Android via Java à un projet Android Studio avec Gradle depuis le référentiel Maven d'Aspose, ou ajoutez le fichier JAR manuellement."
---
## **Aperçu**

Cet article explique comment ajouter Aspose.Slides for Android via Java à un projet Android. La méthode recommandée consiste à laisser Gradle télécharger la bibliothèque depuis le référentiel Maven d'Aspose. Vous pouvez également télécharger le fichier JAR et l'ajouter manuellement à votre projet.

La bibliothèque n’est pas publiée sur Maven Central ni sur le référentiel Maven de Google. Elle est disponible depuis le propre référentiel d'Aspose, sous la forme de l’artifact `aspose-slides` avec le classificateur `android.via.java`.

## **Installer depuis le référentiel Maven d'Aspose**

### **Étape 1 : Ajouter le référentiel**

Les nouveaux projets Android Studio déclarent leurs référentiels dans le bloc `dependencyResolutionManagement` du fichier *settings.gradle.kts*, et Gradle rejette les référentiels qu’un fichier de construction de module ajouterait. Ajoutez la ligne `maven` ci‑dessous au bloc `repositories` à l’intérieur de ce bloc existant, plutôt que de coller un second bloc `dependencyResolutionManagement` :

```kotlin
dependencyResolutionManagement {
    repositoriesMode.set(RepositoriesMode.FAIL_ON_PROJECT_REPOS)
    repositories {
        google()
        mavenCentral()
        maven { url = uri("https://releases.aspose.com/java/repo/") }
    }
}
```

### **Étape 2 : Ajouter la dépendance**

Ajoutez la bibliothèque au bloc `dependencies` du fichier de construction du module app, *app/build.gradle.kts* :

```kotlin
dependencies {
    implementation("com.aspose:aspose-slides:26.9:android.via.java")
}
```

La dernière partie des coordonnées, `android.via.java`, est le classificateur qui sélectionne la version Android de la bibliothèque. Sans ce classificateur, Gradle ne peut pas trouver l’artifact.

Synchronisez ensuite le projet avec les fichiers Gradle, afin que Gradle télécharge la bibliothèque.

### **Choisir une version**

Aspose.Slides for Android via Java n’est pas construit pour chaque version disponible dans le référentiel. Ses compilations sont publiées uniquement pour certaines versions d’Aspose.Slides for Java, et une version sans build Android ne pourra pas être résolue. Sélectionnez une version répertoriée sur la [page de téléchargement d'Aspose.Slides for Android via Java](https://releases.aspose.com/slides/fr/androidjava/).

### **Scripts de construction Groovy**

Si votre projet utilise des scripts de construction Groovy, ajoutez la ligne `maven` au bloc `repositories` à l’intérieur du bloc `dependencyResolutionManagement` existant de *settings.gradle* :

```groovy
dependencyResolutionManagement {
    repositoriesMode.set(RepositoriesMode.FAIL_ON_PROJECT_REPOS)
    repositories {
        google()
        mavenCentral()
        maven { url = 'https://releases.aspose.com/java/repo/' }
    }
}
```

Et ajoutez la dépendance à *app/build.gradle* :

```groovy
dependencies {
    implementation 'com.aspose:aspose-slides:26.9:android.via.java'
}
```

## **Ajouter le fichier JAR manuellement**

Si vous ne pouvez pas utiliser un référentiel Maven, ajoutez le fichier JAR à votre projet :

1. Téléchargez le fichier JAR depuis le dossier de version du [référentiel Maven d'Aspose](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). Pour la version 26.9, le fichier est *aspose-slides-26.9-android.via.java.jar* dans le dossier *26.9*.
2. Copiez le fichier dans le dossier *app/libs* de votre projet. Créez le dossier s’il n’existe pas.
3. Ajoutez le fichier au bloc `dependencies` de *app/build.gradle.kts*, puis synchronisez le projet :

```kotlin
dependencies {
    implementation(files("libs/aspose-slides-26.9-android.via.java.jar"))
}
```

## **Créer votre première présentation**

Après la synchronisation du projet, continuez avec [Créer des présentations](/slides/fr/androidjava/create-presentation/). Son premier exemple ajoute une zone de texte à une diapositive et enregistre la présentation dans le stockage privé de votre application, ce qui ne nécessite aucune autorisation de stockage. Sans licence, Aspose.Slides ajoute un filigrane d’évaluation à chaque diapositive enregistrée ; voir [Licences](/slides/fr/androidjava/licensing/).

## **Gestion des versions**

Depuis 2018, la gestion des versions d’Aspose.Slides for Android via Java suit celle d’Aspose.Slides for Java. Les builds Android ne sont pas publiés pour chaque version Java ; voir [Choisir une version](#choisir-une-version).

## **FAQ**

### Comment vérifier qu'Aspose.Slides est intégré correctement ?

Construisez votre projet, créez une instance vierge de [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/) et enregistrez‑la sous un nouveau nom. Si le fichier est créé sans lever d’exception, la bibliothèque a été intégrée avec succès.

### Comment limiter la consommation de mémoire lors du traitement de présentations volumineuses ?

Appelez la méthode [dispose](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/#dispose--) de chaque instance de [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/) dans un bloc `finally` afin de libérer rapidement ses ressources, et traitez une grande présentation à la fois. Cela aide à prévenir les erreurs d’absence de mémoire et maintient une utilisation de la mémoire globale prévisible lors des opérations par lots.

### Puis‑je exclure des formats d’exportation indésirables pour réduire la taille finale du JAR ?

Les versions actuelles d’Aspose.Slides sont distribuées comme une bibliothèque monolithique unique, il n’est donc pas possible de désactiver des exportateurs spécifiques tels que PDF ou SVG au moment de la construction.