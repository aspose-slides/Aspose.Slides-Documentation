---
title: Installa Aspose.Slides per Android via Java
type: docs
weight: 90
url: /it/androidjava/install-aspose-slides-for-android-via-java/
keywords:
- installare Aspose.Slides
- scaricare Aspose.Slides
- usare Aspose.Slides
- installazione Aspose.Slides
- Gradle
- repository Maven
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Aggiungi Aspose.Slides per Android via Java a un progetto Android Studio con Gradle dal repository Maven di Aspose, o aggiungi manualmente il file JAR."
---
## **Panoramica**

Questo articolo spiega come aggiungere Aspose.Slides per Android via Java a un progetto Android. Il modo consigliato è far scaricare la libreria da Gradle dal repository Maven di Aspose. È possibile anche scaricare il file JAR e aggiungerlo manualmente al progetto.

La libreria non è pubblicata su Maven Central né sul repository Maven di Google. È disponibile dal repository proprio di Aspose, come l'artifact `aspose-slides` con il classificatore `android.via.java`.

## **Installa dal repository Maven di Aspose**

### **Passo 1: Aggiungi il repository**

I nuovi progetti Android Studio dichiarano i repository nel blocco `dependencyResolutionManagement` di *settings.gradle.kts*, e Gradle rifiuta i repository che un file di build del modulo aggiunge. Aggiungi la riga `maven` mostrata di seguito al blocco `repositories` all'interno di quel blocco esistente, invece di incollare un secondo blocco `dependencyResolutionManagement`:

```kotlin
dependencyResolutionManagement {
    repositoriesMode.set(RepositoriesMode.FAIL_ON_PROJECT_REPOS)
    repositories {
        google()
        mavenCentral()
        maven { url = uri("https://releases.aspose.com/java/repo/") }
    }
}
```

### **Passo 2: Aggiungi la dipendenza**

Aggiungi la libreria al blocco `dependencies` del file di build del modulo app, *app/build.gradle.kts*:

```kotlin
dependencies {
    implementation("com.aspose:aspose-slides:26.9:android.via.java")
}
```

L'ultima parte delle coordinate, `android.via.java`, è il classificatore che seleziona la build Android della libreria. Senza di esso, Gradle non può trovare l'artifact.

Quindi sincronizza il progetto con i file Gradle, così Gradle scarica la libreria.

### **Scegli una versione**

Aspose.Slides per Android via Java non è costruito per ogni versione nel repository. Le sue build sono pubblicate solo per alcune versioni di Aspose.Slides per Java, e una versione priva di build Android non riesce a risolversi. Scegli una versione elencata nella [pagina di download di Aspose.Slides per Android via Java](https://releases.aspose.com/slides/it/androidjava/).

### **Script di build Groovy**

Se il tuo progetto utilizza script di build Groovy, aggiungi la riga `maven` al blocco `repositories` all'interno del blocco `dependencyResolutionManagement` esistente di *settings.gradle*:

```groovy
dependencyResolutionManagement {
    repositoriesMode.set(RepositoriesMode.FAIL_ON_PROJECT_REPOS)
    repositories {
        google()
        mavenCentral()
        maven { url = 'https://releases.aspose.com/java/repo/' }
    }
}
```

E aggiungi la dipendenza a *app/build.gradle*:

```groovy
dependencies {
    implementation 'com.aspose:aspose-slides:26.9:android.via.java'
}
```

## **Aggiungi il file JAR manualmente**

Se non puoi usare un repository Maven, aggiungi il file JAR al tuo progetto:

1. Scarica il file JAR dalla cartella della versione nel [repository Maven di Aspose](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). Per la versione 26.9, il file è *aspose-slides-26.9-android.via.java.jar* nella cartella *26.9*.
1. Copia il file nella cartella *app/libs* del tuo progetto. Crea la cartella se non esiste.
1. Aggiungi il file al blocco `dependencies` di *app/build.gradle.kts*, poi sincronizza il progetto:

```kotlin
dependencies {
    implementation(files("libs/aspose-slides-26.9-android.via.java.jar"))
}
```

## **Crea la tua prima presentazione**

Dopo che il progetto è sincronizzato, continua con [Crea presentazioni](/slides/it/androidjava/create-presentation/). Il suo primo esempio aggiunge una casella di testo a una diapositiva e salva la presentazione nella memoria privata della tua app, che non richiede il permesso di archiviazione. Senza una licenza, Aspose.Slides aggiunge una filigrana di valutazione a ogni diapositiva salvata; vedi [Licenze](/slides/it/androidjava/licensing/).

## **Versionamento**

Dal 2018, il versionamento di Aspose.Slides per Android via Java è conforme a quello di Aspose.Slides per Java. Le build Android non sono pubblicate per ogni versione Java; vedi [Scegli una versione](#choose-a-version).

## **FAQ**

### Come posso verificare che Aspose.Slides sia integrato correttamente?

Compila il tuo progetto, istanzia una [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/) vuota e salvala con un nuovo nome. Se il file viene creato senza lanciare eccezioni, la libreria è stata integrata correttamente.

### Come posso limitare il consumo di memoria quando elaboro presentazioni di grandi dimensioni?

Chiama il metodo [dispose](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#dispose--) di ogni istanza di [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/) in un blocco `finally` per rilasciare rapidamente le sue risorse, e processa una grande presentazione alla volta. Questo aiuta a prevenire errori di out-of-memory e mantiene prevedibile l'uso complessivo della memoria durante le operazioni batch.

### Posso escludere formati di esportazione indesiderati per ridurre la dimensione finale del JAR?

Le attuali versioni di Aspose.Slides vengono distribuite come una singola libreria monolitica, quindi non è possibile disabilitare esportatori specifici come PDF o SVG al momento della compilazione.