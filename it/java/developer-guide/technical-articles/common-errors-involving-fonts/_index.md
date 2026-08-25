---
title: Eccezioni e errori comuni relativi ai caratteri su Linux
type: docs
weight: 200
url: /it/java/common-errors-involving-fonts/
aliases:
  - /java/technical-articles/common-errors-involving-fonts/
keywords: "Eccezione del font, Errore del font, Linux, Java, Aspose.Slides for Java"
description: "Eccezioni ed errori dei font su Linux"
---
## **Panoramica**

Quando Aspose.Slides viene utilizzato su Linux, possono verificarsi problemi relativi ai caratteri se il processo Java non può accedere alle cartelle dei caratteri richieste o alla directory temporanea, se non sono installati caratteri sul sistema, o se mancano librerie di sistema necessarie come fontconfig o libfreetype.

Questo articolo descrive gli errori e le eccezioni comuni relativi ai caratteri su Linux e fornisce soluzioni per risolverli. Spiega come verificare l'accesso alle directory dei caratteri e TEMP, installare i caratteri e le librerie richieste, e utilizzare `FontsLoader` per caricare i caratteri senza installarli a livello di sistema.

## **Testo o Immagini Mancanti (EMF o WMF) Quando il Codice Viene Eseguito su Linux**

Questo problema si verifica in sistemi con restrizioni nei seguenti casi:

1. Quando non ci sono caratteri installati o quando la cartella dei caratteri per il processo java non può essere accessa
2. Quando la directory TEMP non può essere accessa.

### **Soluzione**

Verifica e conferma che l'accesso alla directory TEMP e alla cartella dei caratteri sia stato garantito. 

{{% alert color="warning" %}}
In alcuni casi, potresti non essere in grado di concedere l'accesso alle cartelle a causa di restrizioni imposte dall'ambiente o da una politica di sicurezza. Prova queste soluzioni alternative: 
{{% /alert %}}

**Soluzione alternativa**

Usa [FontsLoader](https://reference.aspose.com/slides/it/java/com.aspose.slides/FontsLoader) per caricare i caratteri richiesti senza installarli:
```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```

Se la directory TEMP non può essere accessa, usa questo codice per specificare un'altra directory come TEMP per Java:
```
String newTempFolder = "pathToTmpFolder";
String oldValue = System.getProperty("java.io.tmpdir");
java.io.File file = new java.io.File(newTempFolder);
if (!file.exists())
    file.mkdir();
System.setProperty("java.io.tmpdir", newTempFolder);
try {

    FontsLoader.loadExternalFonts(pathToFontsFolders);

    Presentation pres = ...
    // ....

} finally {
    System.setProperty("java.io.tmpdir", oldValue);
}
```

## **Eccezione: InvalidOperationException: Impossibile Trovare Alcuni Caratteri Installati sul Sistema**

Questa eccezione si verifica quando

1) il processo Java non può accedere alla cartella dei caratteri  
2) non sono stati installati caratteri.

### **Soluzione**

1. Verifica e conferma che l'accesso alla cartella dei caratteri per il processo Java sia stato garantito.

2. Installa alcuni caratteri o utilizza [FontsLoader](https://reference.aspose.com/slides/it/java/com.aspose.slides/FontsLoader).

3. Installa i caratteri.

   * Ubuntu: 

     ```
     sudo apt-get update
     sudo apt-get install -y fonts-dejavu-core
     fc-cache -fv
```

   * CentOS: 

     ```
     sudo yum makecache
     sudo yum -y install dejavu-sans-fonts
     fc-cache -fv
```

   * Using [FontsLoader](https://reference.aspose.com/slides/it/java/com.aspose.slides/FontsLoader): 

     ```
     FontsLoader.loadExternalFonts(pathToFontsFolders);
```

## **Eccezione: InternalError: InvocationTargetException**

Durante la conversione di un file PPTX in PDF su Linux, la conversione potrebbe fallire con `java.lang.InternalError: java.lang.reflect.InvocationTargetException`. Se l'errore sottostante indica `Cannot load from short array because "sun.awt.FontConfiguration.head" is null`, la configurazione dei caratteri di Linux non è disponibile o la sua cache non è stata inizializzata.

### **Soluzione**

Installa fontconfig e ricostruisci la cache dei caratteri:
```bash
sudo yum install -y fontconfig
sudo fc-cache --force
```

## **Eccezione: NoClassDefFoundError: Impossibile Inizializzare la Classe com.aspose.slides.internal.ey.this**

Questa eccezione si verifica su un sistema Linux che manca di fontconfig e caratteri. 

### **Soluzione**

Installa fontconfig:

* Ubuntu:

  ```
  sudo apt-get update
  sudo apt-get -y install fontconfig
  ```

* CentOS:

  ```
  sudo yum makecache
  sudo yum -y install fontconfig
  ```

Inoltre, alcune versioni di open-jdk (ad esempio, **alpine JDK**) richiedono anche **caratteri installati**.

* Ubuntu:

  ```
  sudo apt-get install -y fonts-dejavu-core
  fc-cache -fv
  ```

* CentOS:

  ```
  sudo yum -y install dejavu-sans-fonts
  fc-cache -fv
  ```

## **Eccezione: UnsatisfiedLinkError: libfreetype.so.6: Impossibile Aprire il File Oggetto Condiviso: Nessun File o Directory Trovato**

Questa eccezione si verifica su un sistema Linux che manca della libreria libfreetype. 

### **Soluzione**

Installa libfreetype e fontconfig:

* Ubuntu: 

  ```
  sudo apt-get update
  sudo apt-get install libfreetype6
  sudo apt-get -y install fontconfig
  ```

* CentOS: 

  ```
  sudo yum makecache
  sudo yum install libfreetype6
  sudo yum -y install fontconfig
  ```

{{% alert title="TIP" color="info" %}} 
Non dimenticare di installare i caratteri o utilizzare FontsLoader.
{{% /alert %}}