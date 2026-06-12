---
title: Come eseguire gli esempi
type: docs
weight: 140
url: /it/php-java/how-to-run-the-examples/
keywords:
- esempi
- requisiti software
- GitHub
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Esegui rapidamente gli esempi di Aspose.Slides per PHP via Java: clona il repository, ripristina i pacchetti, quindi compila e testa le funzionalità per PPT, PPTX e ODP."
---
## **Download da GitHub**
Tutti gli esempi di Aspose.Slides for PHP via Java sono ospitati su [Github](https://github.com/aspose-slides/Aspose.Slides-for-Java). Puoi clonare il repository con il tuo client GitHub preferito o scaricare il file ZIP da [qui](https://codeload.github.com/aspose-slides/Aspose.Slides-for-Java/zip/master).

Estrai il contenuto del file ZIP in qualsiasi cartella del tuo computer. Tutti gli esempi si trovano nella cartella **Examples**.

![todo:image_alt_text](examples_directory.png)

## **Importa gli esempi nell'IDE**
Il progetto utilizza il sistema di build Maven. Qualsiasi IDE moderno può aprire o importare facilmente il progetto e le sue dipendenze. Di seguito mostriamo come utilizzare IDE popolari per compilare ed eseguire gli esempi.

### **IntelliJ IDEA**
Fai clic sul menu **File** e scegli **Open**. Naviga fino alla cartella del progetto e seleziona il file **pom.xml**.

![todo:image_alt_text](idea_select_file_or_directory_to_import.png)

Il progetto si aprirà e scaricherà automaticamente le dipendenze. Nella scheda Project, sfoglia gli esempi nella cartella **src/main/java**. Per eseguire un esempio, fai clic destro sul file e scegli "Run .."; l'esempio verrà eseguito e l'output verrà mostrato nella finestra della console integrata.

![todo:image_alt_text](idea_run_example.png)

### **Eclipse**
Fai clic sul menu **File** e scegli **Import**. Seleziona **Maven** - Existing Maven Projects.

![todo:image_alt_text](eclipse_import.png)

Naviga fino alla cartella che hai clonato o scaricato da GitHub e seleziona il file **pom.xml**. Il progetto si aprirà e scaricherà automaticamente le dipendenze. Nella scheda Package Explorer, sfoglia gli esempi nella cartella **src/main/java**. Per eseguire un esempio, fai clic destro sul file e scegli **Run As** - **Java Application**; l'esempio verrà eseguito e l'output verrà mostrato nella finestra della console integrata.

![todo:image_alt_text](eclipse_run_example.png)

### **NetBeans**
Fai clic sul menu **File** e scegli **Open Project**. Naviga fino alla cartella che hai clonato o scaricato da GitHub. L'icona della cartella **Examples** indicherà che si tratta di un progetto Maven. Seleziona **Examples** e aprilo.

![todo:image_alt_text](netbeans_openproject.png)

Il progetto si aprirà e scaricherà automaticamente le dipendenze. Nella scheda Projects, sfoglia gli esempi in **source packages**. Per eseguire un esempio, fai clic destro sul file e scegli **Run File**; l'esempio verrà eseguito e l'output verrà mostrato nella finestra della console integrata.

![todo:image_alt_text](netbeans_run_example.png)

## **Aggiungi la libreria Aspose.Slides al repository locale Maven**
Quando importi il progetto **Aspose.Slides Examples** nell'IDE, Maven scarica automaticamente il file JAR aspose.slides dal [Aspose Maven Repository](https://releases.aspose.com/php-java/repo/com/aspose/). Nel caso tu non abbia accesso a Internet, puoi aggiungere manualmente il JAR al tuo repository locale.

### **mvn install**
Scarica il [aspose.slides](https://releases.aspose.com/php-java/repo/com/aspose/aspose-slides/), estrailo e copia il file aspose.slides-version.jar in un'altra posizione, ad esempio su disco C. Esegui il comando seguente:

```php

```
mvn install:install-file
    - Dfile=c:\aspose.slides-version.jar
    - DgroupId=com.aspose
    - DartifactId=aspose-slides
    - Dversion={version}
    - Dpackaging=jar
```php

```

Ora il JAR **aspose.slides** è copiato nel tuo repository locale Maven.

### **pom.xml**
Dopo l'installazione, dichiara semplicemente le coordinate **aspose.slides** in pom.xml. Aggiungi il repository seguente nella scheda repositories e la dipendenza nella scheda dependencies.

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


### **Fatto**
Compila il progetto, ora il JAR **aspose.slides** può essere recuperato dal tuo repository locale Maven.

## **Contribuisci**
Se desideri aggiungere o migliorare un esempio, ti invitiamo a contribuire al progetto. Tutti gli esempi e i progetti dimostrativi in questo repository sono open source e possono essere usati liberamente nelle tue applicazioni.

Per contribuire, puoi fare fork del repository, modificare il codice sorgente e inviare una Pull Request. Revisioneremo le modifiche e le includeremo nel repository se ritenute utili.