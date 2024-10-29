---
title: So führen Sie die Beispiele aus
type: docs
weight: 140
url: /de/java/how-to-run-the-examples/
---

## **Von GitHub herunterladen**
Alle Beispiele von Aspose.Slides für Java sind auf [Github](https://github.com/aspose-slides/Aspose.Slides-for-Java) gehostet. Sie können das Repository entweder mit Ihrem bevorzugten Github-Client klonen oder die ZIP-Datei [hier](https://codeload.github.com/aspose-slides/Aspose.Slides-for-Java/zip/master) herunterladen.

Entpacken Sie den Inhalt der ZIP-Datei in einen beliebigen Ordner auf Ihrem Computer. Alle Beispiele befinden sich im Ordner **Examples**.

![todo:image_alt_text](examples_directory.png)

## **Beispiele in die IDE importieren**
Das Projekt verwendet das Maven-Bausystem. Jede moderne IDE kann das Projekt und seine Abhängigkeiten problemlos öffnen oder importieren. Im Folgenden zeigen wir Ihnen, wie Sie beliebte IDEs verwenden, um die Beispiele zu erstellen und auszuführen.

### **IntelliJ IDEA**
Klicken Sie auf das Menü **Datei** und wählen Sie **Öffnen**. Navigieren Sie zum Projektordner und wählen Sie die Datei **pom.xml** aus.

![todo:image_alt_text](idea_select_file_or_directory_to_import.png)

Es wird das Projekt geöffnet und die Abhängigkeiten werden automatisch heruntergeladen. Im Projekt-Tab können Sie die Beispiele im Ordner **src/main/java** durchsuchen. Um ein Beispiel auszuführen, klicken Sie mit der rechten Maustaste auf die Datei und wählen Sie "Run ..", das Beispiel wird ausgeführt und die Ausgabe wird im integrierten Konsolenausgabefenster angezeigt.

![todo:image_alt_text](idea_run_example.png)

### **Eclipse**
Klicken Sie auf das Menü **Datei** und wählen Sie **Importieren**. Wählen Sie **Maven** - Vorhandene Maven-Projekte.

![todo:image_alt_text](eclipse_import.png)

Navigieren Sie zu dem Ordner, den Sie von GitHub geklont oder heruntergeladen haben, und wählen Sie die Datei **pom.xml** aus. Es wird das Projekt geöffnet und die Abhängigkeiten werden automatisch heruntergeladen. Im Package Explorer-Tab können Sie die Beispiele im Ordner **src/main/java** durchsuchen. Um ein Beispiel auszuführen, klicken Sie mit der rechten Maustaste auf die Datei und wählen Sie **Run As** - **Java-Anwendung**, das Beispiel wird ausgeführt und die Ausgabe wird im integrierten Konsolenausgabefenster angezeigt.

![todo:image_alt_text](eclipse_run_example.png)

### **NetBeans**
Klicken Sie auf das Menü **Datei** und wählen Sie **Projekt öffnen**. Navigieren Sie zu dem Ordner, den Sie von GitHub geklont oder heruntergeladen haben. Das Symbol des Ordners **Examples** zeigt an, dass es sich um ein Maven-Projekt handelt. Wählen Sie Beispiele aus und öffnen Sie es.

![todo:image_alt_text](netbeans_openproject.png)

Es wird das Projekt geöffnet und die Abhängigkeiten werden automatisch heruntergeladen. Im Projekte-Tab können Sie die Beispiele in **Quellpaketen** durchsuchen. Um ein Beispiel auszuführen, klicken Sie mit der rechten Maustaste auf die Datei und wählen Sie **Datei ausführen**, das Beispiel wird ausgeführt und die Ausgabe wird im integrierten Konsolenausgabefenster angezeigt.

![todo:image_alt_text](netbeans_run_example.png)

## **Aspose.Slides-Bibliothek in das lokale Maven-Repository hinzufügen**
Wenn Sie das Projekt **Aspose.Slides Examples** in die IDE importieren, lädt Maven automatisch die aspose.slides JAR-Datei aus dem [Aspose Maven Repository](https://releases.aspose.com/java/repo/com/aspose/). Falls Sie keinen Internetzugang haben, können Sie das JAR manuell in Ihr lokales Repository hinzufügen.

### **mvn install**
Laden Sie die [aspose.slides](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) herunter, extrahieren Sie sie und kopieren Sie die aspose.slides-version.jar an einen anderen Ort, z. B. auf das C-Laufwerk. Geben Sie den folgenden Befehl ein:

```
mvn install:install-file
    -Dfile=c:\aspose.slides-version.jar
    -DgroupId=com.aspose
    -DartifactId=aspose-slides
    -Dversion={version}
    -Dpackaging=jar
```

Jetzt ist die **aspose.slides** JAR in Ihr Maven-Lokales Repository kopiert.

### **pom.xml**
Nachdem es installiert wurde, erklären Sie einfach die **aspose.slides** Koordinaten in pom.xml. Fügen Sie das folgende Repository im Repositories-Tab und die Abhängigkeit im Abhängigkeiten-Tab hinzu.

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
Bauen Sie es, jetzt kann die **aspose.slides** JAR aus Ihrem Maven-Lokalen Repository abgerufen werden.

## **Beitragen**
Wenn Sie ein Beispiel hinzufügen oder verbessern möchten, ermutigen wir Sie, zum Projekt beizutragen. Alle Beispiele und Showcase-Projekte in diesem Repository sind Open Source und können in Ihren eigenen Anwendungen frei verwendet werden.

Um beizutragen, können Sie das Repository forken, den Quellcode bearbeiten und einen Pull-Request einreichen. Wir werden die Änderungen überprüfen und in das Repository aufnehmen, wenn sie hilfreich sind.