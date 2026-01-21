---
title: Wie man Beispiele ausführt
type: docs
weight: 140
url: /de/java/how-to-run-the-examples/
keywords:
- Beispiele
- Softwareanforderungen
- GitHub
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Führen Sie Aspose.Slides für Java-Beispiele schnell aus: Klonen Sie das Repository, stellen Sie die Pakete wieder her und bauen sowie testen Sie anschließend die Funktionen für PPT, PPTX und ODP."
---

## **Aspose.Slides von GitHub herunterladen**
Alle Beispiele von Aspose.Slides für Java werden auf [Github](https://github.com/aspose-slides/Aspose.Slides-for-Java) gehostet. Sie können entweder das Repository mit Ihrem bevorzugten Github-Client klonen oder die ZIP-Datei von [hier](https://codeload.github.com/aspose-slides/Aspose.Slides-for-Java/zip/master) herunterladen.

Extrahieren Sie den Inhalt der ZIP-Datei in einen beliebigen Ordner auf Ihrem Computer. Alle Beispiele befinden sich im Ordner **Examples**.

![todo:image_alt_text](examples_directory.png)

## **Beispiele in die IDE importieren**
Das Projekt verwendet das Maven-Bautools. Jede moderne IDE kann das Projekt und seine Abhängigkeiten leicht öffnen oder importieren. Im Folgenden zeigen wir, wie man beliebte IDEs verwendet, um die Beispiele zu bauen und auszuführen.

### **IntelliJ IDEA**
Klicken Sie im Menü **File** auf **Open**. Navigieren Sie zum Projektordner und wählen Sie die Datei **pom.xml** aus.

![todo:image_alt_text](idea_select_file_or_directory_to_import.png)

Das Projekt wird geöffnet und die Abhängigkeiten automatisch heruntergeladen. Im Register **Project** können Sie die Beispiele im Ordner **src/main/java** durchsuchen. Um ein Beispiel auszuführen, klicken Sie mit der rechten Maustaste auf die Datei und wählen Sie "Run ..". Das Beispiel wird ausgeführt und die Ausgabe wird im integrierten Konsolenfenster angezeigt.

![todo:image_alt_text](idea_run_example.png)

### **Eclipse**
Klicken Sie im Menü **File** auf **Import**. Wählen Sie **Maven** – Existing Maven Projects.

![todo:image_alt_text](eclipse_import.png)

Navigieren Sie zu dem Ordner, den Sie von GitHub geklont oder heruntergeladen haben, und wählen Sie die Datei **pom.xml** aus. Das Projekt wird geöffnet und die Abhängigkeiten automatisch heruntergeladen. Im Register **Package Explorer** können Sie die Beispiele im Ordner **src/main/java** durchsuchen. Um ein Beispiel auszuführen, klicken Sie mit der rechten Maustaste auf die Datei und wählen **Run As** – **Java Application**, das Beispiel wird ausgeführt und die Ausgabe wird im integrierten Konsolenfenster angezeigt.

![todo:image_alt_text](eclipse_run_example.png)

### **NetBeans**
Klicken Sie im Menü **File** auf **Open Project**. Navigieren Sie zu dem Ordner, den Sie von GitHub geklont oder heruntergeladen haben. Das Symbol des Ordners **Examples** zeigt, dass es sich um ein Maven-Projekt handelt. Wählen Sie **Examples** aus und öffnen Sie es.

![todo:image_alt_text](netbeans_openproject.png)

Das Projekt wird geöffnet und die Abhängigkeiten automatisch heruntergeladen. Im Register **Projects** können Sie die Beispiele in **source packages** durchsuchen. Um ein Beispiel auszuführen, klicken Sie mit der rechten Maustaste auf die Datei und wählen **Run File**, das Beispiel wird ausgeführt und die Ausgabe wird im integrierten Konsolenfenster angezeigt.

![todo:image_alt_text](netbeans_run_example.png)

## **Aspose.Slides-Bibliothek in das lokale Maven-Repository hinzufügen**
Wenn Sie das Projekt **Aspose.Slides Examples** in die IDE importieren, lädt Maven automatisch die aspose.slides JAR-Datei aus dem [Aspose Maven Repository](https://releases.aspose.com/java/repo/com/aspose/) herunter. Falls Sie keinen Internetzugriff haben, können Sie die JAR manuell zu Ihrem lokalen Repository hinzufügen.

### **mvn install**
Laden Sie die [aspose.slides](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) herunter, entpacken Sie sie und kopieren Sie die aspose.slides-version.jar an einen anderen Ort, zum Beispiel auf Laufwerk C. Führen Sie den folgenden Befehl aus:
```
mvn install:install-file
    -Dfile=c:\aspose.slides-version.jar
    -DgroupId=com.aspose
    -DartifactId=aspose-slides
    -Dversion={version}
    -Dpackaging=jar
```


Jetzt ist die **aspose.slides**-Jar in Ihr lokales Maven-Repository kopiert.

### **pom.xml**
Nach der Installation deklarieren Sie einfach die **aspose.slides**-Koordinate in pom.xml. Fügen Sie das folgende Repository im Reiter **repositories** und die Abhängigkeit im Reiter **dependencies** hinzu.
``` xml
<repository>
    <id>AsposeJavaAPI</id>
    <name>Aspose Java API</name>
    <url>https://releases.aspose.com/java/repo/</url>
</repository>

<dependency>
    <groupId>com.aspose</groupId>
    <artifactId>aspose-slides</artifactId>
    <version>25.12</version>
    <classifier>jdk16</classifier>
</dependency>
```


### **Fertig**
Bauen Sie das Projekt, jetzt kann die **aspose.slides**-Jar aus Ihrem lokalen Maven-Repository abgerufen werden.

## **Beitragen**
Wenn Sie ein Beispiel hinzufügen oder verbessern möchten, ermutigen wir Sie, zum Projekt beizutragen. Alle Beispiele und Demonstrationsprojekte in diesem Repository sind Open Source und können frei in Ihren eigenen Anwendungen verwendet werden.

Um beizutragen, können Sie das Repository forken, den Quellcode bearbeiten und eine Pull Request einreichen. Wir werden die Änderungen prüfen und sie in das Repository aufnehmen, wenn sie hilfreich sind.