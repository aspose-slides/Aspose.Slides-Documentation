---
title: Aspose.Slides für Android über Java installieren
type: docs
weight: 90
url: /de/androidjava/install-aspose-slides-for-android-via-java/
---




## **Installation**
Früher wurde Aspose.Slides für Android über Java als eine einzelne ZIP-Datei verteilt, die die JAR-Datei, Demos und die Produktdokumentation enthielt.

1. Wenn Sie eine Version älter als Aspose.Words für Android über Java 18.9 verwenden möchten, müssen Sie diese Version von Aspose.Slides.Android.zip in Ihr bevorzugtes Verzeichnis entpacken.
1. Fügen Sie die extrahierte Jar-Datei in Ihre Anwendung ein, indem Sie die Build-Pfad-Konfiguration verwenden. 
### **Referenz zu Aspose.Slides für Android über Java Jar hinzufügen**
1. Laden Sie die neueste Version von [Aspose.Slides für Android über Java](https://downloads.aspose.com/slides/androidjava) herunter.
1. Kopieren Sie aspose-slides-18.9-android.via.java.jar in den *libs/*-Ordner Ihres Projekts.

![todo:image_alt_text](install-aspose-slides-for-android-via-java_1.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_2.png)
### **Aspose.Slides für Android über Java aus dem Maven-Repository installieren**
1. Fügen Sie das Maven-Repository in Ihre build.gradle ein.
1. Fügen Sie die [Aspose.Slides für Android über Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) JAR als Abhängigkeit hinzu.

``` java

 // 1. Fügen Sie das Maven-Repository in Ihre build.gradle ein

repositories {

    mavenCentral()

    maven { url "https://releases.aspose.com/java/repo/" }

}

// 2. Fügen Sie die 'Aspose.Slides für Android über Java' JAR als Abhängigkeit hinzu

dependencies {

    ...

    ...

    compile (group: 'com.aspose', name: 'aspose-slides', version: 'XX.XX', classifier: 'android.via.java')

}

```
## **Ihre erste Anwendung mit Aspose.Slides für Android über Java**
In diesem Abschnitt lernen Sie, wie Sie mit Aspose.Slides für Android über Java beginnen. Wir möchten Ihnen zeigen, wie Sie ein neues Android-Projekt von Grund auf neu einrichten, eine Referenz zur Aspose.Slides JAR hinzufügen und eine neue PowerPoint-Präsentation erstellen, die im PPTX-Format auf der Festplatte gespeichert wird. Das Beispiel hier verwendet [Android Studio](https://developer.android.com/studio/index.html) für die Entwicklung und die Anwendung wird im Android Emulator ausgeführt. Um mit Aspose.Slides für Android über Java zu beginnen, folgen Sie diesem Schritt-für-Schritt-Tutorial, um eine App zu erstellen, die Aspose.Slides für Android über Java verwendet:

1. Laden Sie [Android Studio](https://developer.android.com/studio/index.html) herunter und installieren Sie es an einem beliebigen Ort.
1. Führen Sie Android Studio aus.
1. Erstellen Sie ein neues Android-Anwendungsprojekt.

![todo:image_alt_text](install-aspose-slides-for-android-via-java_3.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_4.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_5.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_6.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_7.png)





1. Kopieren Sie aspose-slides-XX.XX-android.via.java.jar in den libs/-Ordner Ihres Projekts.

![todo:image_alt_text](install-aspose-slides-for-android-via-java_1.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_2.png)




1. Wählen Sie den Projektbereich (aus dem Datei-Menü) und klicken Sie auf die Registerkarte Abhängigkeiten.
   1. Klicken Sie auf die Schaltfläche "+". Wählen Sie die Dateiabhängigkeit-Option.
   1. Wählen Sie die Aspose.Slides-Bibliothek aus dem libs-Ordner aus und klicken Sie auf OK.

![todo:image_alt_text](install-aspose-slides-for-android-via-java_10.png)




1. Synchronisieren Sie das Projekt bei Bedarf mit Gradle-Dateien. 

![todo:image_alt_text](install-aspose-slides-for-android-via-java_11.png)





1. Um auf die SD-Karte zuzugreifen, müssen besondere Berechtigungen hinzugefügt werden. Klicken Sie auf die Datei AndroidManifest.xml und wählen Sie die XML-Ansicht. Fügen Sie diese Zeile in die Datei ein: <uses-permission android:name="android.permission.WRITE_EXTERNAL_STORAGE" />



![todo:image_alt_text](install-aspose-slides-for-android-via-java_12.png)




1. Navigieren Sie zurück zum Code-Bereich der App und fügen Sie diese Imports hinzu: 

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

Jetzt fügen Sie diesen Code in den Körper der onCreate-Methode ein, um eine neue Präsentation von Grund auf mit Aspose.Slides zu erstellen und sie im PPTX-Format auf der SD-Karte zu speichern.

``` java

 try

{

    // Instanziieren Sie die Presentation-Klasse, die PPTX darstellt

    Presentation pres = new Presentation();



    // Zugriff auf die erste Folie

    ISlide sld = pres.getSlides().get_Item(0);



    // Fügen Sie eine AutoShape vom Typ Rechteck hinzu

    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);



    // Fügen Sie einen TextFrame zum Rechteck hinzu

    ashp.addTextFrame(" ");



    // Zugriff auf den Text-Frame

    ITextFrame txtFrame = ashp.getTextFrame();



    // Erstellen Sie das Paragraph-Objekt für den Text-Frame

    IParagraph para = txtFrame.getParagraphs().get_Item(0);



    // Erstellen Sie das Portion-Objekt für den Paragraphen

    IPortion portion = para.getPortions().get_Item(0);



    // Setzen Sie den Text

    portion.setText("Aspose TextBox");



    // Speichern Sie die PPTX auf der Karte

    String sdCardPath = Environment.getExternalStorageDirectory().getPath() + File.separator;

    pres.save(sdCardPath + "Textbox.pptx", SaveFormat.Pptx);

}

catch (Exception e)

{

   e.printStackTrace();

}

```

Der gesamte Code sollte so aussehen:

![todo:image_alt_text](install-aspose-slides-for-android-via-java_13.png)



1. Führen Sie die Anwendung jetzt erneut aus. Diesmal wird der Aspose.Slides-Code im Hintergrund ausgeführt und erstellt ein Dokument, das auf der SD-Karte gespeichert wird.

![todo:image_alt_text](install-aspose-slides-for-android-via-java_14.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_15.jpg)

1. Um das erstellte Dokument anzusehen, navigieren Sie zum Menü Werkzeuge. Wählen Sie Android und dann den Android Device Monitor aus.

![todo:image_alt_text](install-aspose-slides-for-android-via-java_16.jpg)




![todo:image_alt_text](install-aspose-slides-for-android-via-java_17.jpg)
## **Versionierung**
Seit 2018 entspricht die Versionierung von Aspose.Slides für Android über Java der von Aspose.Slides für Java. 