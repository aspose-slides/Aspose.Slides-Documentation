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
description: "Führen Sie Aspose.Slides für Java-Beispiele schnell aus: Klonen Sie das Repository, stellen Sie die Pakete wieder her und bauen Sie dann die Funktionen für PPT, PPTX und ODP."
---
## **Aspose.Slides von GitHub herunterladen**
Alle Beispiele von Aspose.Slides für Java werden auf [Github](https://github.com/aspose-slides/Aspose.Slides-for-Java) gehostet. Sie können das Repository entweder mit Ihrem bevorzugten Github‑Client klonen oder die ZIP‑Datei von [hier](https://codeload.github.com/aspose-slides/Aspose.Slides-for-Java/zip/master) herunterladen.

Extrahieren Sie den Inhalt der ZIP‑Datei in einen beliebigen Ordner auf Ihrem Computer. Alle Beispiele befinden sich im Ordner **Examples**.

![todo:image_alt_text](examples_directory.png)

## **Beispiele in die IDE importieren**
Das Projekt verwendet das Maven‑Build‑System. Jede moderne IDE kann das Projekt und seine Abhängigkeiten problemlos öffnen oder importieren. Nachfolgend zeigen wir, wie Sie beliebte IDEs zum Erstellen und Ausführen der Beispiele verwenden.

### **IntelliJ IDEA**
Klicken Sie im Menü **File** auf **Open**. Navigieren Sie zum Projektordner und wählen Sie die Datei **pom.xml** aus.

![todo:image_alt_text](idea_select_file_or_directory_to_import.png)

Das Projekt wird geöffnet und die Abhängigkeiten werden automatisch heruntergeladen. Im Reiter **Project** können Sie die Beispiele im Ordner **src/main/java** durchsuchen. Um ein Beispiel auszuführen, klicken Sie mit der rechten Maustaste auf die Datei und wählen Sie „Run ..“, das Beispiel wird ausgeführt und die Ausgabe wird im integrierten Konsolenfenster angezeigt.

![todo:image_alt_text](idea_run_example.png)

### **Eclipse**
Klicken Sie im Menü **File** auf **Import**. Wählen Sie **Maven** - Existing Maven Projects.

![todo:image_alt_text](eclipse_import.png)

Navigieren Sie zu dem Ordner, den Sie von GitHub geklont oder heruntergeladen haben, und wählen Sie die Datei **pom.xml** aus. Das Projekt wird geöffnet und die Abhängigkeiten werden automatisch heruntergeladen. Im Reiter **Package Explorer** können Sie die Beispiele im Ordner **src/main/java** durchsuchen. Um ein Beispiel auszuführen, klicken Sie mit der rechten Maustaste auf die Datei und wählen **Run As** - **Java Application**, das Beispiel wird ausgeführt und die Ausgabe wird im integrierten Konsolenfenster angezeigt.

![todo:image_alt_text](eclipse_run_example.png)

### **NetBeans**
Klicken Sie im Menü **File** auf **Open Project**. Navigieren Sie zu dem Ordner, den Sie von GitHub geklont oder heruntergeladen haben. Das Symbol des **Examples**‑Ordners zeigt an, dass es sich um ein Maven‑Projekt handelt. Wählen Sie **Examples** aus und öffnen Sie es.

![todo:image_alt_text](netbeans_openproject.png)

Das Projekt wird geöffnet und die Abhängigkeiten werden automatisch heruntergeladen. Im Reiter **Projects** können Sie die Beispiele in **source packages** durchsuchen. Um ein Beispiel auszuführen, klicken Sie mit der rechten Maustaste auf die Datei und wählen **Run File**, das Beispiel wird ausgeführt und die Ausgabe wird im integrierten Konsolenfenster angezeigt.

![todo:image_alt_text](netbeans_run_example.png)

## **Aspose.Slides-Bibliothek in das lokale Maven‑Repository hinzufügen**
Wenn Sie das Projekt **Aspose.Slides Examples** in die IDE importieren, lädt Maven automatisch die aspose.slides‑JAR‑Datei aus dem [Aspose Maven Repository](https://releases.aspose.com/java/repo/com/aspose/) herunter. Falls Sie keinen Internetzugriff haben, können Sie die JAR‑Datei manuell in Ihr lokales Repository einfügen.

### **mvn install**
Laden Sie die [aspose.slides](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) herunter, extrahieren Sie sie und kopieren Sie die Datei aspose.slides‑version.jar an einen anderen Ort, zum Beispiel auf das C‑Laufwerk. Führen Sie den folgenden Befehl aus:

```
mvn install:install-file
    - Dfile=c:\aspose.slides-version.jar
    - DgroupId=com.aspose
    - DartifactId=aspose-slides
    - Dversion={version}
    - Dpackaging=jar
```

Nun ist das **aspose.slides**‑Jar in Ihr lokales Maven‑Repository kopiert.

### **pom.xml**
Nach der Installation deklarieren Sie einfach die **aspose.slides**‑Koordinate in der pom.xml. Fügen Sie das folgende Repository im Reiter **repositories** und die Abhängigkeit im Reiter **dependencies** hinzu.

``` xml
<repository>
    <id>AsposeJavaAPI</id>
    <name>Aspose Java API</name>
    <url>https://releases.aspose.com/java/repo/</url>
</repository>

<dependency>
    <groupId>com.aspose</groupId>
    <artifactId>aspose-slides</artifactId>
    <version>26.10</version>
    <classifier>jdk8</classifier>
</dependency>
```

### **Fertig**
Bauen Sie das Projekt, nun kann das **aspose.slides**‑Jar aus Ihrem lokalen Maven‑Repository abgerufen werden.

## **Beitragen**
Wenn Sie ein Beispiel hinzufügen oder verbessern möchten, ermutigen wir Sie, zum Projekt beizutragen. Alle Beispiele und Vorführungsprojekte in diesem Repository sind Open‑Source und können frei in Ihren eigenen Anwendungen verwendet werden.

Um beizutragen, können Sie das Repository forken, den Quellcode bearbeiten und einen Pull Request einreichen. Wir prüfen die Änderungen und nehmen sie in das Repository auf, wenn sie hilfreich sind.