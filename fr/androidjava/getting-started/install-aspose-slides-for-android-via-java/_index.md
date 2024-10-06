---
title: Installer Aspose.Slides pour Android via Java
type: docs
weight: 90
url: /androidjava/install-aspose-slides-for-android-via-java/
---




## **Installation**
Auparavant, Aspose.Slides pour Android via Java était distribué sous la forme d'un seul fichier ZIP contenant le fichier JAR, des démos et la documentation produit.

1. Si vous souhaitez utiliser une version antérieure à Aspose.Words pour Android via Java 18.9, vous devez extraire cette version d'Aspose.Slides.Android.zip dans le répertoire de votre choix.
1. Ajoutez le fichier Jar extrait dans votre application en utilisant la configuration du chemin de construction.
### **Ajouter une référence à Aspose.Slides pour Android via Java Jar**
1. Téléchargez la version la plus récente d'[Aspose.Slides pour Android via Java](https://downloads.aspose.com/slides/androidjava)
1. Copiez aspose-slides-18.9-android.via.java.jar dans le dossier *libs/* de votre projet

![todo:image_alt_text](install-aspose-slides-for-android-via-java_1.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_2.png)
### **Installer Aspose.Slides pour Android via Java depuis le dépôt Maven**
1. Ajoutez le dépôt maven dans votre build.gradle.
1. Ajoutez le JAR [Aspose.Slides pour Android via Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) comme dépendance.

``` java

 // 1. Ajoutez le dépôt maven dans votre build.gradle 

repositories {

    mavenCentral()

    maven { url "https://releases.aspose.com/java/repo/" }

}

// 2. Ajoutez le JAR 'Aspose.Slides pour Android via Java' comme dépendance

dependencies {

    ...

    ...

    compile (group: 'com.aspose', name: 'aspose-slides', version: 'XX.XX', classifier: 'android.via.java')

}

```
## **Votre Première Application Utilisant Aspose.Slides pour Android via Java**
Dans cette section, vous apprendrez à démarrer avec Aspose.Slides pour Android via Java. Nous avons l'intention de vous montrer comment configurer un nouveau projet Android à partir de zéro, ajouter une référence au JAR Aspose.Slides et créer une nouvelle présentation PowerPoint qui est enregistrée sur le disque au format PPTX. L'exemple ici utilise [Android Studio](https://developer.android.com/studio/index.html) pour le développement et l'application est exécutée sur l'émulateur Android. Pour commencer avec Aspose.Slides pour Android via Java, suivez ce tutoriel étape par étape pour créer une application qui utilise Aspose.Slides pour Android via Java :

1. Téléchargez et installez [Android Studio](https://developer.android.com/studio/index.html) à n'importe quel emplacement.
1. Exécutez Android Studio.
1. Créez un nouveau projet d'application Android.

![todo:image_alt_text](install-aspose-slides-for-android-via-java_3.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_4.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_5.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_6.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_7.png)





1. Copiez aspose-slides-XX.XX-android.via.java.jar dans le dossier libs de votre projet

![todo:image_alt_text](install-aspose-slides-for-android-via-java_1.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_2.png)




1. Sélectionnez la section Projet (dans le menu fichier) et cliquez sur l'onglet Dépendances.
   1. Cliquez sur le bouton "+" et sélectionnez l'option de dépendance de fichier.
   1. Sélectionnez la bibliothèque Aspose.Slides dans le dossier libs et cliquez sur OK.

![todo:image_alt_text](install-aspose-slides-for-android-via-java_10.png)




1. Synchronisez le projet avec les fichiers gradle si nécessaire. 

![todo:image_alt_text](install-aspose-slides-for-android-via-java_11.png)





1. Pour accéder à la carte SD, des permissions spéciales doivent être ajoutées. Cliquez sur le fichier AndroidManifest.xml et choisissez la vue XML. Ajoutez cette ligne au fichier <uses-permission android:name="android.permission.WRITE_EXTERNAL_STORAGE" />



![todo:image_alt_text](install-aspose-slides-for-android-via-java_12.png)




1. Revenez à la section code de l'application et ajoutez ces importations : 

``` java

 import java.io.File;

import com.aspose.slides.IAutoShape;

import com.aspose.slides.IParagraph;

import com.aspose.slides.IPortion;

import com.aspose.slides.ISlide;

import com.aspose.slides.ITextFrame;

import com.aspose.slides.Presentation;

import com.aspose.slides.SaveFormat;

import com.aspose.slides.ShapeType;

import android.os.Environment; 

```

Maintenant, insérez ce code dans le corps de la méthode onCreate pour créer une nouvelle présentation à partir de zéro en utilisant Aspose.Slides et l'enregistrer sur la carte SD au format PPTX.

``` java

 try

{

    // Instancier la classe Presentation qui représente PPTX

    Presentation pres = new Presentation();



    // Accéder à la première diapositive

    ISlide sld = pres.getSlides().get_Item(0);



    // Ajouter une AutoShape de type Rectangle

    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);



    // Ajouter un TextFrame au Rectangle

    ashp.addTextFrame(" ");



    // Accéder au cadre de texte

    ITextFrame txtFrame = ashp.getTextFrame();



    // Créer l'objet Paragraph pour le cadre de texte

    IParagraph para = txtFrame.getParagraphs().get_Item(0);



    // Créer l'objet Portion pour le paragraphe

    IPortion portion = para.getPortions().get_Item(0);



    // Définir le texte

    portion.setText("Aspose TextBox");



    // Enregistrer le PPTX sur la carte

    String sdCardPath = Environment.getExternalStorageDirectory().getPath() + File.separator;

    pres.save(sdCardPath + "Textbox.pptx",SaveFormat.Pptx);

}

catch (Exception e)

{

   e.printStackTrace();

}

```

Le code complet devrait ressembler à ceci :

![todo:image_alt_text](install-aspose-slides-for-android-via-java_13.png)



1. Maintenant, exécutez à nouveau l'application. Cette fois, le code Aspose.Slides s'exécutera en arrière-plan et générera un document qui est enregistré sur la carte SD.

![todo:image_alt_text](install-aspose-slides-for-android-via-java_14.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_15.jpg)

1. Pour voir le document créé, naviguez vers le menu Outils. Choisissez Android puis sélectionnez Android Device Monitor

![todo:image_alt_text](install-aspose-slides-for-android-via-java_16.jpg)




![todo:image_alt_text](install-aspose-slides-for-android-via-java_17.jpg)
## **Versioning**
Depuis 2018, le versionnage d'Aspose.Slides pour Android via Java est conforme à celui d'Aspose.Slides pour Java.