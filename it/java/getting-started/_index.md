---
title: Iniziare
type: docs
weight: 10
url: /it/java/getting-started/
keywords:
- iniziare
- requisiti di sistema
- installazione
- prima presentazione
- Maven
- elaborazione PPT
- elaborazione PPTX
- elaborazione ODP
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Il percorso da un nuovo progetto Java a una prima presentazione salvata con Aspose.Slides: verifica i requisiti, aggiungi la libreria dal repository Maven di Aspose, esegui un primo programma e continua con le attività comuni."
---
## **Panoramica**

Segui i quattro passaggi seguenti in ordine. Ogni passaggio indica cosa fare e collega all'articolo con i dettagli. La valutazione, la licenza e l'assistenza sono trattati dopo i passaggi.

## **Passo 1: Verifica i requisiti di sistema**

Aspose.Slides for Java è un unico file JAR senza codice nativo, quindi funziona su qualsiasi sistema operativo che abbia un runtime Java supportato. [Requisiti di sistema](/slides/it/java/system-requirements/) elenca i sistemi operativi supportati e le versioni Java. Il progetto e i comandi nei passaggi successivi richiedono JDK 11 o successivo e, per la via Maven, [Apache Maven](https://maven.apache.org/install.html).

## **Passo 2: Aggiungi la libreria al tuo progetto**

Aspose.Slides for Java è pubblicato nel repository Maven proprietario di Aspose, non su Maven Central. Scegli una di queste opzioni:

- Con Maven: dichiara il repository `https://releases.aspose.com/java/repo/` nel tuo *pom.xml* e aggiungi la dipendenza `com.aspose:aspose-slides` con il classificatore `jdk16`.
- Senza Maven: scarica il file JAR il cui nome termina con *-jdk16.jar* dal repository e aggiungilo al classpath.

Su Linux, installa anche la libreria fontconfig e almeno un font. Senza di essi, il salvataggio di una presentazione fallisce con l'errore "Fontconfig head is null, check your fonts or fonts configuration".

[Installazione](/slides/it/java/installation/) fornisce le voci *pom.xml*, il download del JAR e il comando Linux.

## **Passo 3: Crea la tua prima presentazione**

L’avvio rapido sulla home page di Aspose.Slides for Java](/slides/it/java/#your-first-presentation) è un progetto Maven completo: un file *pom.xml* e un programma che aggiunge una forma nuvola con testo a una diapositiva e salva la presentazione come file PPTX. Lo esegui con `mvn compile exec:java`. [Crea presentazioni](/slides/it/java/create-presentation/) spiega lo stesso programma passo per passo. Per aprire una presentazione esistente e salvarla in un altro formato, vedi [Apri presentazioni](/slides/it/java/open-presentation/) e [Salva presentazioni](/slides/it/java/save-presentation/).

## **Passo 4: Continua con le attività comuni**

- [Apri una presentazione](/slides/it/java/open-presentation/)
- [Salva una presentazione](/slides/it/java/save-presentation/)
- [Converti una presentazione in PDF](/slides/it/java/convert-powerpoint-to-pdf/)
- [Rendi le diapositive come immagini](/slides/it/java/convert-slide/)
- [Modifica il testo della presentazione](/slides/it/java/manage-text/)
- [Esempi per elemento della diapositiva](/slides/it/java/examples/)

## **Valuta e licenzia**

Senza una licenza, Aspose.Slides viene eseguito in modalità di valutazione: aggiunge una filigrana a ogni diapositiva salvata e tronca il testo che il tuo codice legge dalle presentazioni.

- [Valuta Aspose.Slides](/slides/it/java/evaluate-aspose-slides/) descrive le limitazioni della valutazione e come richiedere una licenza temporanea.
- [Licenze](/slides/it/java/licensing/) mostra come applicare una licenza da un file o da uno stream.
- [Licenza a consumo](/slides/it/java/metered-licensing/) tratta la licenza fatturata in base all'uso.
- [Formati di file supportati](/slides/it/java/supported-file-formats/) elenca i formati che Aspose.Slides può caricare e salvare.

## **Ottieni aiuto**

[Supporto tecnico](/slides/it/java/technical-support/) spiega come fare una domanda sul [forum di supporto gratuito](https://forum.aspose.com/c/slides/it/11) e cosa includere quando segnali un problema.

## **FAQ**

**Devo avere Microsoft PowerPoint installato?**

No. Aspose.Slides legge e scrive i file di presentazione autonomamente e non utilizza PowerPoint, quindi funziona anche su server e su Linux.

**Perché Maven non trova Aspose.Slides for Java?**

La libreria non è presente in Maven Central. Dichiara il repository di Aspose nel tuo *pom.xml*, come mostrato in [Installazione](/slides/it/java/installation/), e Maven scaricherà la libreria da lì.

**Il classificatore `jdk16` significa che la libreria richiede Java 16?**

No. Il classificatore seleziona la build Java SE della libreria; l'altra build è per Android. La stessa build funziona sui JDK attuali, come JDK 21.