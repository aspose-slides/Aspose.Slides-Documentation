---
title: Installazione
type: docs
weight: 70
url: /it/java/installation/
keywords:
- installare Aspose.Slides
- scaricare Aspose.Slides
- utilizzare Aspose.Slides
- installazione di Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Installa Aspose.Slides per Java dal repository Maven di Aspose o come file JAR, configura i requisiti preliminari per Linux e verifica l'installazione con un primo programma."
---
## **Panoramica**

Questo articolo spiega come aggiungere Aspose.Slides for Java a un progetto. Aspose.Slides for Java è pubblicato nel repository Maven proprietario di Aspose, non in Maven Central, quindi un progetto Maven deve dichiarare quel repository. È anche possibile scaricare il file JAR e aggiungerlo manualmente al class path. Entrambi i percorsi terminano con un breve programma che conferma che la libreria funziona.

Aspose.Slides for Java non richiede Microsoft PowerPoint. Genera programmaticamente i file di presentazione necessari. Tuttavia, per visualizzare le presentazioni generate, potrebbe essere necessario Microsoft PowerPoint o un altro visualizzatore di presentazioni.

## **Requisiti**

- Un Java Development Kit (JDK). Il progetto e i comandi in questo articolo richiedono JDK 11 o versioni successive. Su JDK 11, il programma che verifica l'installazione stampa un avviso che inizia con "WARNING: An illegal reflective access operation has occurred"; non influisce sul risultato e può essere ignorato.
- [Apache Maven](https://maven.apache.org/install.html), se utilizzi il percorso Maven.
- Su Linux, la libreria fontconfig e almeno un font installato. Vedi [Linux](#linux).

## **Installa dal repository Maven**

Aspose ospita le sue librerie Java nel proprio [Maven repository](https://releases.aspose.com/java/repo/com/aspose/). Per utilizzare [Aspose.Slides for Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) in un progetto Maven, aggiungi due voci al tuo *pom.xml*.

1. **Dichiara il repository Maven di Aspose.**

   ```xml
   <repositories>
       <repository>
           <id>AsposeJavaAPI</id>
           <name>Aspose Java API</name>
           <url>https://releases.aspose.com/java/repo/</url>
       </repository>
   </repositories>
   ```

2. **Aggiungi la dipendenza Aspose.Slides for Java.**

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

Il classificatore `jdk16` è obbligatorio: seleziona la versione Java SE della libreria. Sostituisci `26.9` con l'ultima versione elencata nel [repository](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). Il repository pubblica un file di checksum SHA-1 accanto a ogni JAR, che Maven verifica quando scarica la libreria.

### **Verifica l'installazione**

Per verificare la configurazione con un nuovo progetto:

1. Crea una cartella per il progetto e salva questo *pom.xml* al suo interno:

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

   Oltre al repository e alla dipendenza, questo *pom.xml* imposta la versione Java da compilare, indica la classe che `mvn exec:java` esegue e fissa il plugin del compilatore, poiché il plugin più vecchio usato di default da alcune installazioni Maven ignora l'impostazione `maven.compiler.release`.

2. Salva il primo esempio in [Create Presentations](/slides/it/java/create-presentation/) come *src/main/java/HelloSlides.java*.

3. Nella cartella del progetto, esegui:

   ```bash
   mvn compile exec:java
   ```

Maven scarica Aspose.Slides for Java, compila il programma e lo esegue. Il programma salva *new_presentation.pptx* nella cartella del progetto.

## **Usa il file JAR senza Maven**

1. Scarica *aspose-slides-26.9-jdk16.jar* dalla [cartella della versione](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/26.9/) nel repository. Per un'altra versione, apri la sua cartella nel [repository](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) e scarica il file che termina con *-jdk16.jar*.

2. Salva il primo esempio in [Create Presentations](/slides/it/java/create-presentation/) come *HelloSlides.java* nella stessa cartella del file JAR.

3. In quella cartella, esegui:

   ```bash
   java -cp aspose-slides-26.9-jdk16.jar HelloSlides.java
   ```

Il JDK compila ed esegue il singolo file sorgente, e il programma salva *new_presentation.pptx* nella cartella. Nella tua applicazione, aggiungi il file JAR al class path nel tuo strumento di build o IDE.

## **Linux**

Aspose.Slides for Java utilizza il supporto dei font di Java, che su Linux richiede la libreria fontconfig e almeno un font installato. Senza di essi, il salvataggio di una presentazione fallisce con l'errore "Fontconfig head is null, check your fonts or fonts configuration". Le immagini server e container minimaliste possono mancare di entrambi; l'immagine container Ubuntu ufficiale, ad esempio, non ne ha nessuno.

Su Debian e Ubuntu, questo comando installa un JDK, Maven, fontconfig e i font DejaVu:

```bash
sudo apt-get update && sudo apt-get install -y default-jdk maven fontconfig fonts-dejavu-core
```

I font utilizzati nelle tue presentazioni, o i loro sostituti appropriati, devono essere installati affinché il testo venga renderizzato correttamente.

## **FAQ**

### Come posso verificare che Aspose.Slides sia integrato correttamente?

Compila il tuo progetto, istanzia una [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/) vuota e salvala con un nuovo nome. Se il file viene creato senza generare eccezioni, la libreria è stata integrata correttamente.

### Come posso limitare il consumo di memoria durante l'elaborazione di presentazioni di grandi dimensioni?

Aumenta i limiti di memoria della JVM solo quanto necessario, e chiama [dispose](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#dispose--) su ogni istanza di [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/) in un blocco `finally` per rilasciare rapidamente la cache. Questo impedisce errori di out‑of‑memory e mantiene l'uso complessivo della memoria prevedibile durante le operazioni batch.

### Posso escludere formati di esportazione non desiderati per ridurre le dimensioni del JAR finale?

Le versioni attuali di Aspose.Slides vengono distribuite come una singola libreria monolitica, quindi non è possibile disabilitare esportatori specifici come PDF o SVG al momento della compilazione.