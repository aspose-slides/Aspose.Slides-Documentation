---
title: So führen Sie die Beispiele aus
type: docs
weight: 140
url: /php-java/how-to-run-the-examples/
---

## **Herunterladen von GitHub**
Alle Beispiele von Aspose.Slides für PHP über Java sind auf [Github](https://github.com/aspose-slides/Aspose.Slides-for-Java) gehostet. Sie können entweder das Repository mit Ihrem bevorzugten Github-Client klonen oder die ZIP-Datei [hier](https://codeload.github.com/aspose-slides/Aspose.Slides-for-Java/zip/master) herunterladen.

Entpacken Sie den Inhalt der ZIP-Datei in einen beliebigen Ordner auf Ihrem Computer. Alle Beispiele befinden sich im **Examples**-Ordner.

![todo:image_alt_text](examples_directory.png)

## **Beispiele in die IDE importieren**
Das Projekt verwendet das Maven-Bautool. Jede moderne IDE kann das Projekt und seine Abhängigkeiten problemlos öffnen oder importieren. Unten zeigen wir Ihnen, wie Sie beliebte IDEs verwenden, um die Beispiele zu erstellen und auszuführen.

### **IntelliJ IDEA**
Klicken Sie auf das **Datei**-Menü und wählen Sie **Öffnen**. Navigieren Sie zum Projektordner und wählen Sie die **pom.xml**-Datei aus.

![todo:image_alt_text](idea_select_file_or_directory_to_import.png)

Es wird das Projekt geöffnet und die Abhängigkeiten automatisch heruntergeladen. Im Projekt-Tab navigieren Sie zu den Beispielen im **src/main/java**-Ordner. Um ein Beispiel auszuführen, klicken Sie einfach mit der rechten Maustaste auf die Datei und wählen Sie "Ausführen ..", das Beispiel wird ausgeführt und die Ausgabe wird im integrierten Konsolenausgabefenster angezeigt.

![todo:image_alt_text](idea_run_example.png)

### **Eclipse**
Klicken Sie auf das **Datei**-Menü und wählen Sie **Importieren**. Wählen Sie **Maven** - Vorhandene Maven-Projekte.

![todo:image_alt_text](eclipse_import.png)

Navigieren Sie zu dem Ordner, den Sie von GitHub geklont oder heruntergeladen haben, und wählen Sie die **pom.xml**-Datei aus. Es wird das Projekt geöffnet und die Abhängigkeiten automatisch heruntergeladen. Im Package Explorer-Tab navigieren Sie zu den Beispielen im **src/main/java**-Ordner. Um ein Beispiel auszuführen, klicken Sie einfach mit der rechten Maustaste auf die Datei und wählen Sie **Ausführen als** - **Java-Anwendung**, das Beispiel wird ausgeführt und die Ausgabe wird im integrierten Konsolenausgabefenster angezeigt.

![todo:image_alt_text](eclipse_run_example.png)

### **NetBeans**
Klicken Sie auf das **Datei**-Menü und wählen Sie **Projekt öffnen**. Navigieren Sie zu dem Ordner, den Sie von GitHub geklont oder heruntergeladen haben. Das Symbol des **Examples**-Ordners zeigt, dass es sich um ein Maven-Projekt handelt. Wählen Sie Beispiele aus und öffnen Sie sie.

![todo:image_alt_text](netbeans_openproject.png)

Es wird das Projekt geöffnet und die Abhängigkeiten automatisch heruntergeladen. Im Projekte-Tab navigieren Sie zu den Beispielen in den **Quellpaketen**. Um ein Beispiel auszuführen, klicken Sie einfach mit der rechten Maustaste auf die Datei und wählen Sie **Datei ausführen**, das Beispiel wird ausgeführt und die Ausgabe wird im integrierten Konsolenausgabefenster angezeigt.

![todo:image_alt_text](netbeans_run_example.png)

## **Hinzufügen der Aspose.Slides-Bibliothek zum lokalen Maven-Repository**
Wenn Sie das **Aspose.Slides Examples**-Projekt in die IDE importieren, lädt Maven automatisch die aspose.slides JAR-Datei aus dem [Aspose Maven Repository](https://releases.aspose.com/php-java/repo/com/aspose/) herunter. Falls Sie keinen Internetzugang haben, können Sie die JAR-Datei manuell in Ihr lokales Repository hinzufügen.

### **mvn install**
Laden Sie die [aspose.slides](https://releases.aspose.com/php-java/repo/com/aspose/aspose-slides/) herunter, entpacken Sie sie und kopieren Sie die aspose.slides-version.jar an einen anderen Ort, zum Beispiel auf das C-Laufwerk. Geben Sie den folgenden Befehl ein:

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

Jetzt ist die **aspose.slides** JAR in Ihrem lokalen Maven-Repository kopiert.

### **pom.xml**
Nach der Installation deklarieren Sie einfach die **aspose.slides** Koordinate in der pom.xml. Fügen Sie das folgende Repository im Tab "Repositories" und die Abhängigkeit im Tab "Dependencies" hinzu.

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

### **Fertig**
Bauen Sie es, jetzt kann die **aspose.slides** JAR aus Ihrem lokalen Maven-Repository abgerufen werden.

## **Beitragen**
Wenn Sie ein Beispiel hinzufügen oder verbessern möchten, ermutigen wir Sie, zum Projekt beizutragen. Alle Beispiele und Showcase-Projekte in diesem Repository sind Open Source und können frei in Ihren eigenen Anwendungen verwendet werden.

Um beizutragen, können Sie das Repository forken, den Quellcode bearbeiten und einen Pull Request einreichen. Wir werden die Änderungen überprüfen und in das Repository aufnehmen, wenn sie als hilfreich erachtet werden.