---
title: Dichiarazione
type: docs
weight: 60
url: /it/java/artifact-classifier-change/
keywords:
- classificatore Aspose.Slides
- classificatore artifact
- utilizza Aspose.Slides
- installazione Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Aspose.Slides per Java ora utilizza il classificatore jdk8 invece di jdk16. Scopri perché e come aggiornare le tue dipendenze."
---
## Modifica del classificatore dell'artifact da `jdk16` a `jdk8`

A partire dalla versione **26.10**, abbiamo modificato il classificatore usato nei nostri artifact pubblicati da **`jdk16`** (Java 6) a **`jdk8`** (Java 8).

### Cosa è cambiato

| | Prima | Dopo |
|---|---|---|
| Classificatore | `jdk16` | `jdk8` |
| Versione Java minima | Java 1.6 | Java 8 |

**Prima:**
```
com.aspose:aspose-slides:26.10:jdk16
```

**Dopo:**
```
com.aspose:aspose-slides:26.10:jdk8
```

### Perché abbiamo apportato questa modifica

Dopo una revisione interna, abbiamo deciso di **abbandonare il supporto per le versioni Java più vecchie** che non fornivano più valore e ostacolavano attivamente la manutenzione. Java 8 è stato selezionato come nuova baseline sicura per tutti i consumatori.

Nel contesto, il classificatore è stato aggiornato per riflettere la versione minima effettivamente supportata. Abbiamo inoltre allineato la denominazione al nome ufficiale di Oracle, dove il prodotto è indicato come **JDK 8** (anziché il formato legacy `1.8`).

### Cosa devi fare

1. **Aggiorna il classificatore** nelle dichiarazioni delle dipendenze da `jdk16` a `jdk8`.

   **Maven:**
   ```xml
   <dependency>
     <groupId>com.aspose</groupId>
     <artifactId>aspose-slides</artifactId>
     <version>26.10</version>
     <classifier>jdk8</classifier>
   </dependency>
   ```

   **Gradle:**
   ```groovy
   implementation 'com.aspose:aspose-slides:26.10:jdk8'
   ```

2. **Verifica che il tuo ambiente di runtime sia Java 8 o superiore.**

3. **Aggiorna eventuali file di lock o cache delle dipendenze** che fissano il vecchio classificatore.

### Nota di migrazione: jdk16 e jdk8

A partire dalla versione 26.10, entrambi i classificatori jdk16 e jdk8 forniranno JAR compatibili con Java 8 (compilati con compatibilità source/target impostata su Java 8).

- `jdk16` → continua a essere pubblicato per compatibilità retroattiva (integrazioni esistenti).
- `jdk8` → introdotto come nuovo classificatore preferito per ambienti Java 8.

⚠️ Nota: questa fase di pubblicazione doppia è prevista per terminare il 31 marzo 2027. Dopo tale data, il classificatore jdk16 sarà ritirato e solo jdk8 sarà supportato.

### Note di compatibilità

- Il classificatore `jdk16` **non sarà più pubblicato** dopo il **31 marzo 2027**.
- Se hai ancora bisogno del supporto per Java 1.6, rimani sulla linea di versione principale precedente finché non potrai migrare.

### Hai bisogno di aiuto?

Se incontri problemi durante la migrazione, contatta [supporto Aspose](https://forum.aspose.com/) per ulteriore assistenza.