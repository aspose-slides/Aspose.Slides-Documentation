---
title: Installer Aspose.Slides pour Android via Java
type: docs
weight: 90
url: /fr/androidjava/install-aspose-slides-for-android-via-java/
keywords:
- installer Aspose.Slides
- télécharger Aspose.Slides
- utiliser Aspose.Slides
- installation d'Aspose.Slides
- PowerPoint
- OpenDocument
- présentation
- Android
- Java
- Aspose.Slides
description: "Installez rapidement Aspose.Slides pour Android. Guide étape par étape, exigences système et exemples de code Java - commencez dès aujourd'hui à travailler avec les présentations PowerPoint!"
---

## **Installation**
Auparavant, Aspose.Slides pour Android via Java était distribué sous forme d'un seul fichier ZIP contenant le fichier JAR, des démonstrations et la documentation du produit. 

1. Si vous souhaitez utiliser une version antérieure à Aspose.Words pour Android via Java 18.9, vous devez extraire ce fichier Aspose.Slides.Android.zip dans le répertoire de votre choix. 
1. Ajoutez le fichier JAR extrait à votre application en utilisant la configuration du Build Path. 
### **Ajouter une référence au JAR Aspose.Slides pour Android via Java**
1. Téléchargez la version la plus récente de[Aspose.Slides pour Android via Java](https://downloads.aspose.com/slides/androidjava)
1. Copiez aspose-slides-18.9-android.via.java.jar dans le *libs/*folder de votre projet

![todo:image_alt_text](install-aspose-slides-for-android-via-java_1.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_2.png)
### **Installer Aspose.Slides pour Android via Java depuis le référentiel Maven**
1. Ajoutez le référentiel Maven dans votre build.gradle. 
1. Ajoutez le JAR[Aspose.Slides pour Android via Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) en tant que dépendance.
``` java

 // 1. Ajouter le dépôt Maven dans votre build.gradle 

repositories {

    mavenCentral()

    maven { url "https://releases.aspose.com/java/repo/" }

}

// 2. Ajouter le JAR 'Aspose.Slides for Android via Java' en tant que dépendance

dependencies {

    ...

    ...

    compile (group: 'com.aspose', name: 'aspose-slides', version: 'XX.XX', classifier: 'android.via.java')

}
```

## **Votre première application utilisant Aspose.Slides pour Android via Java**
Dans cette section, vous apprendrez à démarrer avec Aspose.Slides pour Android via Java. Nous allons vous montrer comment créer un nouveau projet Android à partir de zéro, ajouter une référence au JAR Aspose.Slides, et créer une nouvelle présentation PowerPoint qui sera enregistrée sur le disque au format PPTX. L’exemple utilise[Android Studio](https://developer.android.com/studio/index.html) pour le développement et l’application est exécutée sur l’émulateur Android. Pour commencer avec Aspose.Slides pour Android via Java, suivez ce tutoriel pas à pas pour créer une application qui utilise Aspose.Slides pour Android via Java :

1. Téléchargez et installez[Android Studio](https://developer.android.com/studio/index.html)à l’emplacement de votre choix. 
1. Lancez Android Studio. 
1. Créez un nouveau projet d’application Android. 

![todo:image_alt_text](install-aspose-slides-for-android-via-java_3.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_4.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_5.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_6.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_7.png)





1. Copiez aspose-slides-XX.XX-android.via.java.jar dans le dossier libs/ de votre projet

![todo:image_alt_text](install-aspose-slides-for-android-via-java_1.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_2.png)




1. Sélectionnez la section Projet (dans le menu Fichier) et cliquez sur l’onglet Dépendances. 
   1. Cliquez sur le bouton “+”. Sélectionnez l’option de dépendance de fichier. 
   1. Sélectionnez la bibliothèque Aspose.Slides dans le dossier libs et cliquez sur OK. 

![todo:image_alt_text](install-aspose-slides-for-android-via-java_10.png)




1. Synchronisez le projet avec les fichiers Gradle si nécessaire. 

![todo:image_alt_text](install-aspose-slides-for-android-via-java_11.png)





1. Pour accéder à la carte SD, des autorisations spéciales doivent être ajoutées. Ouvrez le fichier AndroidManifest.xml et choisissez la vue XML. Ajoutez cette ligne <uses-permission android:name="android.permission.WRITE_EXTERNAL_STORAGE" />



![todo:image_alt_text](install-aspose-slides-for-android-via-java_12.png)




1. Revenez à la section code de l’application et ajoutez ces imports :
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


Maintenant, insérez ce code dans le corps de la méthode onCreate pour créer une nouvelle Presentation à partir de zéro en utilisant Aspose.Slides et l’enregistrer sur la carte SD au format PPTX.
``` java
 try
{
    // Instancier la classe Presentation qui représente un PPTX
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


Le code complet doit ressembler à ceci :

![todo:image_alt_text](install-aspose-slides-for-android-via-java_13.png)



1. Exécutez à nouveau l’application. Cette fois, le code Aspose.Slides s’exécutera en arrière‑plan et générera un document qui sera enregistré sur la carte SD. 

![todo:image_alt_text](install-aspose-slides-for-android-via-java_14.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_15.jpg)

1. Pour visualiser le document créé, accédez au menu Outils. Choisissez Android puis sélectionnez Android Device Monitor 

![todo:image_alt_text](install-aspose-slides-for-android-via-java_16.jpg)




![todo:image_alt_text](install-aspose-slides-for-android-via-java_17.jpg)
## **Versionnage**
Depuis 2018, le versionnage d’Aspose.Slides pour Android via Java est conforme à celui d’Aspose.Slides pour Java.  

## **FAQ**

**Comment vérifier que Aspose.Slides est correctement intégré ?**

Compilez votre projet, créez une [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) vierge et enregistrez‑la sous un nouveau nom. Si le fichier est créé sans lever d’exception, la bibliothèque a été intégrée avec succès.

**Comment limiter la consommation de mémoire lors du traitement de présentations volumineuses ?**

Augmentez les limites de mémoire JVM uniquement autant que nécessaire, et fermez chaque instance de[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) dans un`finally`pour libérer le cache immédiatement. Cela empêche les erreurs de dépassement de mémoire et maintient une utilisation prévisible de la mémoire pendant les traitements par lots.

**Puis‑je exclure des formats d’exportation indésirables afin de réduire la taille finale du JAR ?**

Les versions actuelles d’Aspose.Slides sont distribuées comme une bibliothèque monolithique unique, il n’est donc pas possible de désactiver certains exportateurs tels que PDF ou SVG lors de la compilation.