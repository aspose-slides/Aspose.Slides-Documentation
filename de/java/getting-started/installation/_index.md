---
title: Installation
type: docs
weight: 70
url: /de/java/installation/
keywords:
- Aspose.Slides installieren
- Aspose.Slides herunterladen
- Aspose.Slides verwenden
- Aspose.Slides-Installation
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Installieren Sie Aspose.Slides for Java aus Asposes Maven-Repository oder als JAR-Datei, richten Sie die Linux-Voraussetzungen ein und prüfen Sie die Installation mit einem ersten Programm."
---
## **Übersicht**

Dieser Artikel erklärt, wie Aspose.Slides for Java zu einem Projekt hinzugefügt wird. Aspose.Slides for Java wird in Asposes eigenem Maven‑Repository veröffentlicht, nicht in Maven Central, sodass ein Maven‑Projekt dieses Repository deklarieren muss. Sie können die JAR‑Datei auch herunterladen und selbst zum Klassenpfad hinzufügen. Beide Wege enden mit einem kurzen Programm, das bestätigt, dass die Bibliothek funktioniert.

Aspose.Slides for Java benötigt Microsoft PowerPoint nicht. Es erzeugt die erforderlichen Präsentationsdateien programmgesteuert. Um die erzeugten Präsentationen anzusehen, benötigen Sie jedoch Microsoft PowerPoint oder einen anderen Präsentationsviewer.

## **Voraussetzungen**

- Ein Java Development Kit (JDK). Das Projekt und die Befehle in diesem Artikel benötigen JDK 11 oder höher. Unter JDK 11 gibt das Prüfprogramm eine Warnung aus, die mit „WARNING: An illegal reflective access operation has occurred“ beginnt; sie hat keinen Einfluss auf das Ergebnis und kann ignoriert werden.
- [Apache Maven](https://maven.apache.org/install.html), falls Sie den Maven‑Weg nutzen.
- Unter Linux die fontconfig‑Bibliothek und mindestens eine installierte Schriftart. Siehe [Linux](#linux).

## **Installation aus dem Maven‑Repository**

Aspose hostet seine Java‑Bibliotheken in seinem eigenen [Maven‑Repository](https://releases.aspose.com/java/repo/com/aspose/). Um [Aspose.Slides for Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) in einem Maven‑Projekt zu verwenden, fügen Sie zwei Einträge zu Ihrer *pom.xml* hinzu.

1. **Deklarieren Sie das Aspose‑Maven‑Repository.**

   ```xml
   <repositories>
       <repository>
           <id>AsposeJavaAPI</id>
           <name>Aspose Java API</name>
           <url>https://releases.aspose.com/java/repo/</url>
       </repository>
   </repositories>
   ```

2. **Fügen Sie die Aspose.Slides for Java‑Abhängigkeit hinzu.**

   ```xml
   <dependencies>
       <dependency>
           <groupId>com.aspose</groupId>
           <artifactId>aspose-slides</artifactId>
           <version>26.9</version>
           <classifier>jdk16</classifier>
       </dependency>
   </dependencies>
   ```

Der Klassifizierer `jdk16` ist erforderlich: Er wählt den Java‑SE‑Build der Bibliothek aus. Ersetzen Sie `26.9` durch die neueste Version, die im [Repository](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) aufgeführt ist. Das Repository veröffentlicht neben jeder JAR‑Datei eine SHA‑1‑Prüfsummendatei, die Maven beim Herunterladen der Bibliothek überprüft.

### **Installation prüfen**

Um die Einrichtung mit einem neuen Projekt zu prüfen:

1. Erstellen Sie einen Ordner für das Projekt und speichern Sie diese *pom.xml* darin:

   ```xml
   <project xmlns="http://maven.apache.org/POM/4.0.0">
       <modelVersion>4.0.0</modelVersion>
       <groupId>com.example</groupId>
       <artifactId>hello-slides</artifactId>
       <version>1.0</version>

       <properties>
           <maven.compiler.release>11</maven.compiler.release>
           <project.build.sourceEncoding>UTF-8</project.build.sourceEncoding>
           <exec.mainClass>HelloSlides</exec.mainClass>
       </properties>

       <repositories>
           <repository>
               <id>AsposeJavaAPI</id>
               <name>Aspose Java API</name>
               <url>https://releases.aspose.com/java/repo/</url>
           </repository>
       </repositories>

       <dependencies>
           <dependency>
               <groupId>com.aspose</groupId>
               <artifactId>aspose-slides</artifactId>
               <version>26.9</version>
               <classifier>jdk16</classifier>
           </dependency>
       </dependencies>

       <build>
           <plugins>
               <plugin>
                   <groupId>org.apache.maven.plugins</groupId>
                   <artifactId>maven-compiler-plugin</artifactId>
                   <version>3.15.0</version>
               </plugin>
           </plugins>
       </build>
   </project>
   ```

   Neben dem Repository und der Abhängigkeit legt diese *pom.xml* das Java‑Release fest, das kompiliert werden soll, gibt die Klasse an, die `mvn exec:java` ausführt, und fixiert das Compiler‑Plugin, weil das ältere Plugin, das manche Maven‑Installationen standardmäßig verwenden, die Einstellung `maven.compiler.release` ignoriert.

2. Speichern Sie das erste Beispiel aus [Create Presentations](/slides/de/java/create-presentation/) als *src/main/java/HelloSlides.java*.

3. Führen Sie im Projektordner aus:

   ```bash
   mvn compile exec:java
   ```

Maven lädt Aspose.Slides for Java herunter, kompiliert das Programm und führt es aus. Das Programm speichert *new_presentation.pptx* im Projektordner.

## **JAR‑Datei ohne Maven verwenden**

1. Laden Sie *aspose-slides-26.9-jdk16.jar* aus dem [Versionsordner](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/26.9/) im Repository herunter. Für eine andere Version öffnen Sie den entsprechenden Ordner im [Repository](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) und laden die Datei herunter, die auf *-jdk16.jar* endet.
2. Speichern Sie das erste Beispiel aus [Create Presentations](/slides/de/java/create-presentation/) als *HelloSlides.java* im selben Ordner wie die JAR‑Datei.
3. Führen Sie in diesem Ordner aus:

   ```bash
   java -cp aspose-slides-26.9-jdk16.jar HelloSlides.java
   ```

Das JDK kompiliert und führt die einzelne Quellcodedatei aus, und das Programm speichert *new_presentation.pptx* im Ordner. Fügen Sie in Ihrer eigenen Anwendung die JAR‑Datei dem Klassenpfad in Ihrem Build‑Tool oder Ihrer IDE hinzu.

## **Linux**

Aspose.Slides for Java verwendet die Schriftunterstützung von Java, die unter Linux die fontconfig‑Bibliothek und mindestens eine installierte Schriftart erfordert. Ohne diese schlägt das Speichern einer Präsentation mit der Fehlermeldung „Fontconfig head is null, check your fonts or fonts configuration“ fehl. Minimal‑Server‑ und Container‑Images können beides fehlen; das offizielle Ubuntu‑Container‑Image hat beispielsweise weder fontconfig noch Schriftarten.

Auf Debian und Ubuntu installiert dieser Befehl ein JDK, Maven, fontconfig und die DejaVu‑Schriften:

```bash
sudo apt-get update && sudo apt-get install -y default-jdk maven fontconfig fonts-dejavu-core
```

Die in Ihren Präsentationen verwendeten Schriften bzw. passende Ersatzschriften müssen ebenfalls installiert sein, damit Text korrekt gerendert wird.

## **FAQ**

### Wie kann ich überprüfen, dass Aspose.Slides korrekt integriert ist?

Bauen Sie Ihr Projekt, instanziieren Sie ein leeres [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) und speichern Sie es unter einem neuen Namen. Wenn die Datei ohne Ausnahmefehler erstellt wird, wurde die Bibliothek erfolgreich integriert.

### Wie kann ich den Speicherverbrauch bei der Verarbeitung großer Präsentationen begrenzen?

Erhöhen Sie die JVM‑Speichergrenzen nur so hoch wie nötig und rufen Sie [dispose](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#dispose--) für jede [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)-Instanz in einem `finally`‑Block auf, um den Cache sofort freizugeben. Das verhindert Out‑Of‑Memory‑Fehler und hält die Gesamtspeichernutzung während Batch‑Operationen vorhersehbar.

### Kann ich unerwünschte Exportformate ausschließen, um die finale JAR‑Größe zu reduzieren?

Aktuelle Aspose.Slides‑Versionen werden als ein einziges monolithisches Bibliothekspaket ausgeliefert, sodass Sie spezifische Exporter wie PDF oder SVG zur Build‑Zeit nicht deaktivieren können.