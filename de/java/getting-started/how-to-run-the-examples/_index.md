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
description: "Führen Sie Aspose.Slides für Java-Beispiele schnell aus: Klonen Sie das Repository, stellen Sie die Pakete wieder her und bauen sowie testen Sie Funktionen für PPT, PPTX und ODP."
---

## **Aspose.Slides von GitHub herunterladen**
Alle Beispiele von Aspose.Slides für Java werden auf [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-Java) gehostet. Sie können das Repository entweder mit Ihrem bevorzugten GitHub‑Client klonen oder die ZIP‑Datei von [hier](https://codeload.github.com/aspose-slides/Aspose.Slides-for-Java/zip/master) herunterladen.

Entpacken Sie den Inhalt der ZIP‑Datei in einen beliebigen Ordner auf Ihrem Computer. Alle Beispiele befinden sich im Ordner **Examples**.

![todo:image_alt_text](examples_directory.png)

## **Beispiele in die IDE importieren**
Das Projekt verwendet das Maven‑Buildsystem. Jede moderne IDE kann das Projekt und seine Abhängigkeiten leicht öffnen oder importieren. Im Folgenden zeigen wir, wie Sie beliebte IDEs verwenden, um die Beispiele zu erstellen und auszuführen.

### **IntelliJ IDEA**
Klicken Sie im **File**‑Menü auf **Open**. Navigieren Sie zum Projektordner und wählen Sie die Datei **pom.xml** aus.

![todo:image_alt_text](idea_select_file_or_directory_to_import.png)

Die IDE öffnet das Projekt und lädt die Abhängigkeiten automatisch herunter. Im Projekt‑Tab können Sie die Beispiele im Ordner **src/main/java** durchsuchen. Um ein Beispiel auszuführen, klicken Sie mit der rechten Maustaste auf die Datei und wählen Sie „Run ..“, das Beispiel wird ausgeführt und die Ausgabe erscheint im integrierten Konsolen‑Fenster.

![todo:image_alt_text](idea_run_example.png)

### **Eclipse**
Klicken Sie im **File**‑Menü auf **Import**. Wählen Sie **Maven** – Existing Maven Projects.

![todo:image_alt_text](eclipse_import.png)

Navigieren Sie zu dem Ordner, den Sie von GitHub geklont oder heruntergeladen haben, und wählen Sie die Datei **pom.xml** aus. Das Projekt wird geöffnet und die Abhängigkeiten automatisch heruntergeladen. Im **Package Explorer**‑Tab können Sie die Beispiele im Ordner **src/main/java** durchsuchen. Um ein Beispiel auszuführen, klicken Sie mit der rechten Maustaste auf die Datei und wählen Sie **Run As** – **Java Application**, das Beispiel wird ausgeführt und die Ausgabe erscheint im integrierten Konsolen‑Fenster.

![todo:image_alt_text](eclipse_run_example.png)

### **NetBeans**
Klicken Sie im **File**‑Menü auf **Open Project**. Navigieren Sie zu dem Ordner, den Sie von GitHub geklont oder heruntergeladen haben. Das Symbol des Ordners **Examples** zeigt an, dass es sich um ein Maven‑Projekt handelt. Wählen Sie **Examples** und öffnen Sie es.

![todo:image_alt_text](netbeans_openproject.png)

Die IDE öffnet das Projekt und lädt die Abhängigkeiten automatisch herunter. Im **Projects**‑Tab können Sie die Beispiele in **source packages** durchsuchen. Um ein Beispiel auszuführen, klicken Sie mit der rechten Maustaste auf die Datei und wählen Sie **Run File**, das Beispiel wird ausgeführt und die Ausgabe erscheint im integrierten Konsolen‑Fenster.

![todo:image_alt_text](netbeans_run_example.png)

## **Aspose.Slides‑Bibliothek in das lokale Maven‑Repository hinzufügen**
Wenn Sie das Projekt **Aspose.Slides Examples** in Ihre IDE importieren, lädt Maven die aspose.slides‑JAR‑Datei automatisch aus dem [Aspose Maven Repository](https://releases.aspose.com/java/repo/com/aspose/) herunter. Falls Sie keinen Internetzugriff haben, können Sie die JAR‑Datei manuell in Ihr lokales Repository einfügen.

### **mvn install**
Laden Sie die [aspose.slides](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) herunter, entpacken Sie sie und kopieren Sie die Datei aspose.slides‑version.jar an einen beliebigen Ort, z. B. auf Laufwerk C. Führen Sie dann den folgenden Befehl aus:
```
mvn install:install-file
    -Dfile=c:\aspose.slides-version.jar
    -DgroupId=com.aspose
    -DartifactId=aspose-slides
    -Dversion={version}
    -Dpackaging=jar
```


Jetzt ist das **aspose.slides**‑JAR in Ihrem lokalen Maven‑Repository abgelegt.

### **pom.xml**
Nach der Installation deklarieren Sie einfach die **aspose.slides**‑Koordinate in der pom.xml. Fügen Sie das folgende Repository im Reiter **repositories** und die Abhängigkeit im Reiter **dependencies** hinzu.
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


### **Fertig**
Bauen Sie das Projekt; das **aspose.slides**‑JAR kann nun aus Ihrem lokalen Maven‑Repository abgerufen werden.

## **Beitragen**
Wenn Sie ein Beispiel hinzufügen oder verbessern möchten, ermutigen wir Sie, zum Projekt beizutragen. Alle Beispiele und Showcase‑Projekte in diesem Repository sind Open Source und können frei in eigenen Anwendungen verwendet werden.

Um beizutragen, können Sie das Repository forken, den Quellcode bearbeiten und einen Pull Request einreichen. Wir prüfen die Änderungen und integrieren sie, wenn sie hilfreich sind.