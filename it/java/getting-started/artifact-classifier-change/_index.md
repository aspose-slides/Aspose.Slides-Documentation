---
title: Dichiarazione
type: docs
weight: 60
url: /it/java/artifact-classifier-change/
keywords:
- classificatore Aspose.Slides
- classificatore artefatto
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
description: "Aspose.Slides per Java ora utilizza il classificatore jdk8 invece di jdk16. Scopri perché e come aggiornare le tue dipendenze."
---
## **Modifica del classificatore dell'artefatto da `jdk16` a `jdk8`**

A partire dalla versione **26.10**, abbiamo cambiato il classificatore usato nei nostri artefatti pubblicati da **`jdk16`** (Java 6) a **`jdk8`** (Java 8).

### **Cosa è cambiato**

| | Prima | Dopo |
|---|---|---|
| Classificatore | `jdk16` | `jdk8` |
| Versione minima di Java | Java 1.6 | Java 8 |

**Prima:**
```
com.aspose:aspose-slides:26.10:jdk16
```

**Dopo:**
```
com.aspose:aspose-slides:26.10:jdk8
```

### **Perché abbiamo effettuato questa modifica**

Dopo una revisione interna, abbiamo deciso di **abbandonare il supporto per le versioni Java più vecchie** che non fornivano più valore e ostacolavano attivamente la manutenzione. Java 8 è stato scelto come nuova base sicura per tutti i consumatori.

Come parte di questo, il classificatore è stato aggiornato per riflettere la reale versione minima supportata. Ci siamo anche allineati alla convenzione di denominazione corrente di Oracle, dove il prodotto è ufficialmente indicato come **JDK 8** (anziché il formato legacy `1.8`).

### **Cosa devi fare**

1. **Aggiorna il classificatore** nelle tue dichiarazioni di dipendenza da `jdk16` a `jdk8`.

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

2. **Verifica che il tuo ambiente di runtime** sia Java 8 o superiore.

3. **Aggiorna eventuali file lock** o cache di dipendenze che vincolano il vecchio classificatore.

### **Nota di migrazione: jdk16 e jdk8**

A partire dalla versione 26.10, entrambi i classificatori jdk16 e jdk8 forniranno JAR compatibili con Java 8 (creati con compatibilità source/target impostata a Java 8).

- `jdk16` → continua a essere pubblicato per la compatibilità retroattiva (integrazioni esistenti).
- `jdk8` → introdotto come nuovo classificatore preferito per ambienti Java 8.

⚠️ Nota: questa fase di pubblicazione duale è programmata per terminare il 31 marzo 2027. Dopo questa data, il classificatore jdk16 sarà ritirato e sarà supportato solo jdk8.

### **Note di compatibilità**

- Il classificatore `jdk16` **non è più pubblicato** dopo il **31 marzo 2027**.
- Se hai ancora bisogno del supporto per Java 1.6, rimani sulla precedente linea di versione principale finché non potrai migrare.

### **Hai bisogno di aiuto?**

Se riscontri problemi durante la migrazione, contatta [supporto Aspose](https://forum.aspose.com/) per ulteriore assistenza.