---
title: Wie man die Beispiele ausführt
type: docs
weight: 140
url: /de/php-java/how-to-run-the-examples/
keywords:
- Beispiele
- Softwareanforderungen
- GitHub
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Führen Sie Aspose.Slides für PHP via Java Beispiele schnell aus: Klonen Sie das Repository, stellen Sie die Pakete wieder her und bauen Sie dann die Funktionen für PPT, PPTX und ODP."
---

## **Download von GitHub**
Alle Beispiele von Aspose.Slides for PHP via Java werden auf [Github](https://github.com/aspose-slides/Aspose.Slides-for-Java) gehostet. Sie können das Repository entweder mit Ihrem bevorzugten Github‑Client klonen oder die ZIP‑Datei von [hier](https://codeload.github.com/aspose-slides/Aspose.Slides-for-Java/zip/master) herunterladen.

Entpacken Sie den Inhalt der ZIP‑Datei in einen beliebigen Ordner auf Ihrem Computer. Alle Beispiele befinden sich im Ordner **Examples**.

![todo:image_alt_text](examples_directory.png)

## **Beispiele in die IDE importieren**
Das Projekt verwendet das Maven‑Buildsystem. Jede moderne IDE kann das Projekt und seine Abhängigkeiten einfach öffnen oder importieren. Im Folgenden zeigen wir, wie Sie beliebte IDEs zum Erstellen und Ausführen der Beispiele verwenden.

### **IntelliJ IDEA**
Klicken Sie im Menü **File** und wählen Sie **Open**. Navigieren Sie zum Projektordner und wählen Sie die Datei **pom.xml** aus.

![todo:image_alt_text](idea_select_file_or_directory_to_import.png)

Das Projekt wird geöffnet und die Abhängigkeiten automatisch heruntergeladen. Im Register **Project** können Sie die Beispiele im Ordner **src/main/java** durchsuchen. Um ein Beispiel auszuführen, klicken Sie mit der rechten Maustaste auf die Datei und wählen „Run ..“. Das Beispiel wird ausgeführt und die Ausgabe erscheint im integrierten Konsolenfenster.

![todo:image_alt_text](idea_run_example.png)

### **Eclipse**
Klicken Sie im Menü **File** und wählen Sie **Import**. Wählen Sie **Maven** – Existing Maven Projects.

![todo:image_alt_text](eclipse_import.png)

Navigieren Sie zu dem Ordner, den Sie von GitHub geklont oder heruntergeladen haben, und wählen Sie die Datei **pom.xml** aus. Das Projekt wird geöffnet und die Abhängigkeiten automatisch heruntergeladen. Im Register **Package Explorer** können Sie die Beispiele im Ordner **src/main/java** durchsuchen. Um ein Beispiel auszuführen, klicken Sie mit der rechten Maustaste auf die Datei und wählen **Run As** – **Java Application**. Das Beispiel wird ausgeführt und die Ausgabe erscheint im integrierten Konsolenfenster.

![todo:image_alt_text](eclipse_run_example.png)

### **NetBeans**
Klicken Sie im Menü **File** und wählen Sie **Open Project**. Navigieren Sie zu dem Ordner, den Sie von GitHub geklont oder heruntergeladen haben. Das Symbol des Ordners **Examples** zeigt an, dass es sich um ein Maven‑Projekt handelt. Wählen Sie **Examples** und öffnen Sie es.

![todo:image_alt_text](netbeans_openproject.png)

Das Projekt wird geöffnet und die Abhängigkeiten automatisch heruntergeladen. Im Register **Projects** können Sie die Beispiele in **source packages** durchsuchen. Um ein Beispiel auszuführen, klicken Sie mit der rechten Maustaste auf die Datei und wählen **Run File**. Das Beispiel wird ausgeführt und die Ausgabe erscheint im integrierten Konsolenfenster.

![todo:image_alt_text](netbeans_run_example.png)

## **Aspose.Slides‑Bibliothek in das lokale Maven‑Repository hinzufügen**
Wenn Sie das Projekt **Aspose.Slides Examples** in die IDE importieren, lädt Maven die aspose.slides‑JAR‑Datei automatisch aus dem [Aspose Maven Repository](https://releases.aspose.com/php-java/repo/com/aspose/) herunter. Falls Sie keinen Internetzugang haben, können Sie die JAR‑Datei manuell in Ihr lokales Repository einfügen.

### **mvn install**
Laden Sie das [aspose.slides](https://releases.aspose.com/php-java/repo/com/aspose/aspose-slides/) herunter, entpacken Sie es und kopieren Sie die Datei aspose.slides‑version.jar an einen beliebigen Ort, z. B. auf das C‑Laufwerk. Führen Sie folgenden Befehl aus:
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


Jetzt ist die **aspose.slides**‑JAR‑Datei in Ihr lokales Maven‑Repository kopiert.

### **pom.xml**
Nach der Installation deklarieren Sie einfach die **aspose.slides**‑Koordinate in der pom.xml. Fügen Sie das folgende Repository im Repositories‑Tab und die Abhängigkeit im Dependencies‑Tab hinzu.
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


### **Done**
Bauen Sie das Projekt; jetzt kann die **aspose.slides**‑JAR‑Datei aus Ihrem lokalen Maven‑Repository abgerufen werden.

## **Beitragen**
Wenn Sie ein Beispiel hinzufügen oder verbessern möchten, ermutigen wir Sie, zum Projekt beizutragen. Alle Beispiele und Showcase‑Projekte in diesem Repository sind Open Source und können frei in Ihren eigenen Anwendungen verwendet werden.

Um beizutragen, können Sie das Repository forken, den Quellcode bearbeiten und einen Pull Request einreichen. Wir prüfen die Änderungen und übernehmen sie in das Repository, sofern sie hilfreich sind.