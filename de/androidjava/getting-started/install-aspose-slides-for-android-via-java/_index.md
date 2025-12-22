---
title: Installieren Sie Aspose.Slides für Android via Java
type: docs
weight: 90
url: /de/androidjava/install-aspose-slides-for-android-via-java/
keywords:
- Aspose.Slides installieren
- Aspose.Slides herunterladen
- Aspose.Slides verwenden
- Aspose.Slides Installation
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Installieren Sie Aspose.Slides für Android schnell. Schritt-für-Schritt-Anleitung, Systemanforderungen und Java-Code-Beispiele — beginnen Sie noch heute mit PowerPoint-Präsentationen!"
---

## **Installation**
Zuvor wurde Aspose.Slides für Android via Java als eine einzelne ZIP-Datei verteilt, die die JAR-Datei, Demos und die Produktdokumentation enthielt.

1. Wenn Sie eine ältere Version als Aspose.Words für Android via Java 18.9 verwenden möchten, müssen Sie die entsprechende Aspose.Slides.Android.zip in Ihr gewünschtes Verzeichnis entpacken. 
1. Fügen Sie die entpackte Jar-Datei in Ihre Anwendung ein, indem Sie die Build‑Path‑Konfiguration verwenden. 
### **Verweis auf Aspose.Slides für Android via Java Jar hinzufügen**
1. Laden Sie die neueste Version von [Aspose.Slides for Android via Java](https://downloads.aspose.com/slides/androidjava) herunter
1. Kopieren Sie aspose-slides-18.9-android.via.java.jar in den *libs/*‑Ordner Ihres Projekts

![todo:image_alt_text](install-aspose-slides-for-android-via-java_1.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_2.png)
### **Aspose.Slides für Android via Java aus dem Maven‑Repository installieren**
1. Fügen Sie das Maven‑Repository zu Ihrer build.gradle‑Datei hinzu. 
1. Fügen Sie den [Aspose.Slides for Android via Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) JAR als Abhängigkeit hinzu.
``` java

 // 1. Fügen Sie das Maven-Repository zu Ihrer build.gradle hinzu 

repositories {

    mavenCentral()

    maven { url "https://releases.aspose.com/java/repo/" }

}

// 2. Fügen Sie das 'Aspose.Slides for Android via Java' JAR als Abhängigkeit hinzu

dependencies {

    ...

    ...

    compile (group: 'com.aspose', name: 'aspose-slides', version: 'XX.XX', classifier: 'android.via.java')

}
```

## **Ihre erste Anwendung mit Aspose.Slides für Android via Java**
In diesem Abschnitt erfahren Sie, wie Sie mit Aspose.Slides für Android via Java beginnen. Wir zeigen Ihnen, wie Sie ein neues Android‑Projekt von Grund auf einrichten, einen Verweis auf die Aspose.Slides‑JAR hinzufügen und eine neue PowerPoint‑Präsentation erstellen, die im PPTX‑Format auf die Festplatte gespeichert wird. Das Beispiel verwendet [Android Studio](https://developer.android.com/studio/index.html) für die Entwicklung und die Anwendung wird im Android‑Emulator ausgeführt. Um mit Aspose.Slides für Android via Java zu starten, folgen Sie dieser Schritt‑für‑Schritt‑Anleitung, um eine App zu erstellen, die Aspose.Slides für Android via Java nutzt:

1. Laden Sie [Android Studio](https://developer.android.com/studio/index.html) herunter und installieren Sie es an einem beliebigen Ort.
1. Starten Sie Android Studio.
1. Erstellen Sie ein neues Android‑Anwendungsprojekt.

![todo:image_alt_text](install-aspose-slides-for-android-via-java_3.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_4.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_5.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_6.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_7.png)





1. Kopieren Sie aspose-slides-XX.XX-android.via.java.jar in den libs‑Ordner Ihres Projekts

![todo:image_alt_text](install-aspose-slides-for-android-via-java_1.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_2.png)




1. Wählen Sie im Menü **Projekt** den Abschnitt **Projekt** und öffnen Sie die Registerkarte **Abhängigkeiten**.  
   1. Klicken Sie auf die Schaltfläche „+“ und wählen Sie die Option **Datei‑Abhängigkeit**.  
   1. Wählen Sie die Aspose.Slides‑Bibliothek aus dem libs‑Ordner und klicken Sie auf **OK**.

![todo:image_alt_text](install-aspose-slides-for-android-via-java_10.png)




1. Synchronisieren Sie das Projekt bei Bedarf mit den Gradle‑Dateien. 

![todo:image_alt_text](install-aspose-slides-for-android-via-java_11.png)





1. Um auf die SD‑Karte zuzugreifen, müssen spezielle Berechtigungen hinzugefügt werden. Öffnen Sie die Datei AndroidManifest.xml und wechseln Sie zur XML‑Ansicht. Fügen Sie folgende Zeile hinzu: `<uses-permission android:name="android.permission.WRITE_EXTERNAL_STORAGE" />`

![todo:image_alt_text](install-aspose-slides-for-android-via-java_12.png)




1. Navigieren Sie zurück zum Code‑Abschnitt der App und fügen Sie diese Imports hinzu:  
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


Nun fügen Sie diesen Code in den Body der Methode onCreate ein, um eine neue Presentation von Grund auf mit Aspose.Slides zu erstellen und sie im PPTX‑Format auf die SD‑Karte zu speichern.  
``` java

 try
{
    // Instanziieren der Presentation-Klasse, die ein PPTX darstellt
    Presentation pres = new Presentation();

    // Zugriff auf die erste Folie
    ISlide sld = pres.getSlides().get_Item(0);

    // Ein AutoShape vom Typ Rechteck hinzufügen
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // TextFrame zum Rechteck hinzufügen
    ashp.addTextFrame(" ");

    // Zugriff auf das TextFrame
    ITextFrame txtFrame = ashp.getTextFrame();

    // Paragraph-Objekt für das TextFrame erstellen
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Portion-Objekt für den Absatz erstellen
    IPortion portion = para.getPortions().get_Item(0);

    // Text setzen
    portion.setText("Aspose TextBox");

    // PPTX auf die Karte speichern
    String sdCardPath = Environment.getExternalStorageDirectory().getPath() + File.separator;
    pres.save(sdCardPath + "Textbox.pptx",SaveFormat.Pptx);
}
catch (Exception e)
{
   e.printStackTrace();
}
```


Der vollständige Code sollte wie folgt aussehen:

![todo:image_alt_text](install-aspose-slides-for-android-via-java_13.png)



1. Führen Sie die Anwendung erneut aus. Dieses Mal wird der Aspose.Slides‑Code im Hintergrund ausgeführt und erzeugt ein Dokument, das auf der SD‑Karte gespeichert wird.

![todo:image_alt_text](install-aspose-slides-for-android-via-java_14.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_15.jpg)

1. Um das erstellte Dokument anzuzeigen, navigieren Sie zum Menü **Tools**. Wählen Sie **Android** und dann **Android Device Monitor**.

![todo:image_alt_text](install-aspose-slides-for-android-via-java_16.jpg)




![todo:image_alt_text](install-aspose-slides-for-android-via-java_17.jpg)
## **Versionierung**
Seit 2018 entspricht die Versionierung von Aspose.Slides für Android via Java der von Aspose.Slides für Java.

## **FAQ**

**Wie kann ich überprüfen, ob Aspose.Slides korrekt integriert ist?**

Bauen Sie Ihr Projekt, instanziieren Sie eine leere [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) und speichern Sie sie unter einem neuen Namen. Wenn die Datei ohne Ausnahmen erstellt wird, war die Bibliothek erfolgreich integriert.

**Wie kann ich den Speicherverbrauch bei der Verarbeitung großer Präsentationen begrenzen?**

Erhöhen Sie die JVM‑Speichergrenzen nur soweit wie nötig und schließen Sie jede [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)-Instanz in einem `finally`‑Block, um den Cache sofort freizugeben. Das verhindert Out‑of‑Memory‑Fehler und hält den Gesamtspeicherverbrauch während Batch‑Operationen vorhersehbar.

**Kann ich unerwünschte Exportformate ausschließen, um die endgültige JAR‑Größe zu reduzieren?**

Aktuelle Aspose.Slides‑Releases werden als eine einzelne monolithische Bibliothek ausgeliefert, sodass Sie bestimmte Exporter wie PDF oder SVG zur Build‑Zeit nicht deaktivieren können.