---
title: Installazione
type: docs
weight: 70
url: /it/java/installation/
keywords:
- installare Aspose.Slides
- scaricare Aspose.Slides
- usare Aspose.Slides
- installazione Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Installa Aspose.Slides per Java dal repository Maven di Aspose o come file JAR, configura i prerequisiti per Linux e verifica l'installazione con un primo programma."
---
## **Panoramica**

Questo articolo spiega come aggiungere Aspose.Slides for Java a un progetto. Aspose.Slides for Java è pubblicato nel repository Maven proprietario di Aspose, non in Maven Central, quindi un progetto Maven deve dichiarare quel repository. È anche possibile scaricare il file JAR e aggiungerlo al class path manualmente. Entrambe le soluzioni terminano con un breve programma che conferma che la libreria funziona.

Aspose.Slides for Java non richiede Microsoft PowerPoint. Genera programmaticamente i file di presentazione necessari. Tuttavia, per visualizzare le presentazioni generate, potrebbe essere necessario Microsoft PowerPoint o un altro visualizzatore di presentazioni.

## **Prerequisiti**

- Un Java Development Kit (JDK). Il progetto e i comandi di questo articolo richiedono JDK 11 o successivo. Con JDK 11, il programma che verifica l'installazione stampa un avviso che inizia con "WARNING: An illegal reflective access operation has occurred"; non influisce sul risultato e può essere ignorato.
- [Apache Maven](https://maven.apache.org/install.html), se utilizzi la via Maven.
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
           <version>26.10</version>
           <classifier>jdk8</classifier>
       </dependency>
   </dependencies>
   ```

Il classificatore `jdk8` è obbligatorio: seleziona la build Java SE della libreria. Sostituisci `26.10` con l'ultima versione elencata nel [repository](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). Il repository pubblica un file di checksum SHA-1 accanto a ogni JAR, che Maven verifica durante il download della libreria.

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

   Oltre al repository e alla dipendenza, questo *pom.xml* imposta la versione Java da compilare, indica la classe che `mvn exec:java` esegue e fissa il plugin del compilatore, poiché il plugin più vecchio che alcune installazioni Maven usano per impostazione predefinita ignora l'opzione `maven.compiler.release`.

2. Salva il primo esempio in [Crea presentazioni](/slides/it/java/create-presentation/) come *src/main/java/HelloSlides.java*.

3. Nella cartella del progetto, esegui:

   ```bash
   mvn compile exec:java
   ```

Maven scarica Aspose.Slides for Java, compila il programma ed lo esegue. Il programma salva *new_presentation.pptx* nella cartella del progetto.

## **Usa il file JAR senza Maven**

1. Scarica *aspose-slides-26.10-jdk8.jar* dalla [cartella della versione](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/26.10/) nel repository. Per un'altra versione, apri la sua cartella nel [repository](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) e scarica il file che termina con *-jdk8.jar*.
2. Salva il primo esempio in [Crea presentazioni](/slides/it/java/create-presentation/) come *HelloSlides.java* nella stessa cartella del file JAR.
3. In quella cartella, esegui:

   ```bash
   java -cp aspose-slides-26.10-jdk8.jar HelloSlides.java
   ```

Il JDK compila ed esegue il singolo file sorgente, e il programma salva *new_presentation.pptx* nella cartella. Nella tua applicazione, aggiungi il file JAR al class path nel tuo strumento di build o IDE.

## **Linux**

Aspose.Slides for Java utilizza il supporto ai font di Java, il quale su Linux richiede la libreria fontconfig e almeno un font installato. Senza di essi, il salvataggio di una presentazione fallisce con l'errore "Fontconfig head is null, check your fonts or fonts configuration". Le immagini server e container minime possono non includere entrambi; l'immagine container ufficiale di Ubuntu, ad esempio, non ne ha né uno né l'altro.

Su Debian e Ubuntu, questo comando installa un JDK, Maven, fontconfig e i font DejaVu:

```bash
sudo apt-get update && sudo apt-get install -y default-jdk maven fontconfig fonts-dejavu-core
```

I font utilizzati nelle tue presentazioni, o i loro sostituti adeguati, devono essere installati affinché il testo venga renderizzato correttamente.

## **FAQ**

### Come posso verificare che Aspose.Slides sia integrato correttamente?

Compila il tuo progetto, istanzia una [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) vuota e salvala con un nuovo nome. Se il file viene creato senza sollevare eccezioni, la libreria è stata integrata con successo.

### Come posso limitare il consumo di memoria durante l'elaborazione di presentazioni di grandi dimensioni?

Aumenta i limiti di memoria della JVM solo quanto necessario, e chiama [dispose](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#dispose--) su ogni istanza di [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) in un blocco `finally` per rilasciare rapidamente la cache. Questo previene errori di out‑of‑memory e mantiene prevedibile l'uso complessivo della memoria durante le operazioni batch.

### Posso escludere i formati di esportazione indesiderati per ridurre la dimensione finale del JAR?

Le attuali versioni di Aspose.Slides sono distribuite come una singola libreria monolitica, quindi non è possibile disabilitare esportatori specifici come PDF o SVG al momento della compilazione.