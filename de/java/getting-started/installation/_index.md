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
description: "Installieren Sie Aspose.Slides für Java aus Asposes Maven-Repository oder als JAR-Datei, richten Sie die Linux-Voraussetzungen ein und prüfen Sie die Installation mit einem ersten Programm."
---
## **Übersicht**

Dieser Artikel erklärt, wie man Aspose.Slides for Java zu einem Projekt hinzufügt. Aspose.Slides for Java wird im eigenen Maven‑Repository von Aspose veröffentlicht, nicht im Maven Central, sodass ein Maven‑Projekt dieses Repository deklarieren muss. Man kann auch die JAR‑Datei herunterladen und selbst zum Klassenpfad hinzufügen. Beide Wege enden mit einem kurzen Programm, das bestätigt, dass die Bibliothek funktioniert.

Aspose.Slides for Java benötigt nicht Microsoft PowerPoint. Es erzeugt die erforderlichen Präsentationsdateien programmgesteuert. Um die erzeugten Präsentationen anzuzeigen, benötigen Sie jedoch möglicherweise Microsoft PowerPoint oder einen anderen Präsentationsbetrachter.

## **Voraussetzungen**

- Ein Java Development Kit (JDK). Das Projekt und die Befehle in diesem Artikel benötigen JDK 11 oder höher. Unter JDK 11 gibt das Programm, das die Installation prüft, eine Warnung aus, die mit „WARNING: An illegal reflective access operation has occurred“ beginnt; sie beeinflusst das Ergebnis nicht und kann ignoriert werden.
- [Apache Maven](https://maven.apache.org/install.html), wenn Sie den Maven‑Weg verwenden.
- Unter Linux benötigen Sie die Bibliothek fontconfig und mindestens eine installierte Schriftart. Siehe [Linux](#linux).

## **Installation aus dem Maven-Repository**

Aspose veröffentlicht seine Java‑Bibliotheken in seinem eigenen [Maven-Repository](https://releases.aspose.com/java/repo/com/aspose/). Um [Aspose.Slides for Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) in einem Maven‑Projekt zu verwenden, fügen Sie zwei Einträge zu Ihrer *pom.xml* hinzu.

1. **Deklarieren Sie das Aspose Maven-Repository.**

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
           <version>26.10</version>
           <classifier>jdk8</classifier>
       </dependency>
   </dependencies>
   ```

Der `jdk8`‑Classifier ist erforderlich: er wählt den Java‑SE‑Build der Bibliothek aus. Ersetzen Sie `26.10` durch die neueste Version im [Repository](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). Das Repository veröffentlicht zu jeder JAR‑Datei eine SHA‑1‑Prüfsummendatei, die Maven beim Herunterladen der Bibliothek prüft.

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
               <version>26.10</version>
               <classifier>jdk8</classifier>
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

   Zusätzlich zum Repository und zur Abhängigkeit legt diese *pom.xml* die zu kompilierende Java‑Version fest, benennt die Klasse, die `mvn exec:java` ausführt, und fixiert das Compiler‑Plugin, weil das ältere Plugin, das einige Maven‑Installationen standardmäßig verwenden, die Einstellung `maven.compiler.release` ignoriert.

2. Speichern Sie das erste Beispiel aus [Erstellen von Präsentationen](/slides/de/java/create-presentation/) als *src/main/java/HelloSlides.java*.

3. Führen Sie im Projektordner aus:

   ```bash
   mvn compile exec:java
   ```

Maven lädt Aspose.Slides for Java herunter, kompiliert das Programm und führt es aus. Das Programm speichert *new_presentation.pptx* im Projektordner.

## **Verwendung der JAR-Datei ohne Maven**

1. Laden Sie *aspose-slides-26.10-jdk8.jar* aus dem [Versionsordner](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/26.10/) im Repository herunter. Für eine andere Version öffnen Sie dessen Ordner im [Repository](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) und laden die Datei herunter, die auf *-jdk8.jar* endet.
2. Speichern Sie das erste Beispiel aus [Erstellen von Präsentationen](/slides/de/java/create-presentation/) als *HelloSlides.java* im selben Ordner wie die JAR‑Datei.
3. Führen Sie in diesem Ordner aus:

   ```bash
   java -cp aspose-slides-26.10-jdk8.jar HelloSlides.java
   ```

Das JDK kompiliert und führt die einzelne Quellcode‑Datei aus, und das Programm speichert *new_presentation.pptx* im Ordner. Fügen Sie in Ihrer eigenen Anwendung die JAR‑Datei dem Klassenpfad in Ihrem Build‑Tool oder Ihrer IDE hinzu.

## **Linux**

Aspose.Slides for Java verwendet die Schriftunterstützung von Java, die unter Linux die Bibliothek fontconfig und mindestens eine installierte Schriftart benötigt. Ohne diese schlägt das Speichern einer Präsentation mit dem Fehler „Fontconfig head is null, check your fonts or fonts configuration“ fehl. Minimal‑Server‑ und Container‑Images können beides nicht enthalten; das offizielle Ubuntu‑Container‑Image beispielsweise hat keines von beidem.

Unter Debian und Ubuntu installiert dieser Befehl ein JDK, Maven, fontconfig und die DejaVu‑Schriften:

```bash
sudo apt-get update && sudo apt-get install -y default-jdk maven fontconfig fonts-dejavu-core
```

Die in Ihren Präsentationen verwendeten Schriftarten oder geeignete Ersatzschriften müssen ebenfalls installiert sein, damit Text korrekt dargestellt wird.

## **FAQ**

### Wie kann ich überprüfen, ob Aspose.Slides korrekt integriert ist?

Erstellen Sie Ihr Projekt, erzeugen Sie eine leere [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) und speichern Sie sie unter einem neuen Namen. Wenn die Datei ohne Ausnahmen erstellt wird, wurde die Bibliothek erfolgreich integriert.

### Wie kann ich den Speicherverbrauch bei der Verarbeitung großer Präsentationen begrenzen?

Erhöhen Sie die JVM‑Speichergrenzen nur so weit wie nötig und rufen Sie [dispose](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#dispose--) für jede [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)‑Instanz in einem `finally`‑Block auf, um den Cache umgehend freizugeben. Dies verhindert Out‑of‑Memory‑Fehler und hält die Gesamtspeichernutzung während Batch‑Vorgängen vorhersehbar.

### Kann ich unerwünschte Exportformate ausschließen, um die endgültige JAR‑Größe zu reduzieren?

Die aktuellen Aspose.Slides‑Versionen werden als eine einzige monolithische Bibliothek ausgeliefert, sodass Sie bestimmte Exporter wie PDF oder SVG zur Build‑Zeit nicht deaktivieren können.