---
title: Eccezioni e errori comuni legati ai font su Linux
type: docs
weight: 200
url: /it/java/common-errors-involving-fonts/
aliases:
  - /java/technical-articles/common-errors-involving-fonts/
keywords: "Eccezione font, Errore font, Linux, Java, Aspose.Slides per Java"
description: "Eccezioni e errori dei font su Linux"
---
## **Panoramica**

Quando Aspose.Slides viene utilizzato su Linux, possono verificarsi problemi legati ai font se il processo Java non riesce ad accedere alle cartelle dei font richiesti o alla directory temporanea, se non sono installati font sul sistema, o se mancano librerie di sistema necessarie come fontconfig o libfreetype.

Questo articolo descrive gli errori e le eccezioni più comuni relativi ai font su Linux e fornisce soluzioni per risolverli. Spiega come verificare l'accesso alle directory dei font e TEMP, installare i font e le librerie necessari, e usare `FontsLoader` per caricare i font senza installarli a livello di sistema.

## **Testo o immagini mancanti (EMF o WMF) quando il codice viene eseguito su Linux**

Questo problema si verifica nei sistemi con restrizioni nei seguenti casi:

1. Quando non sono installati font o quando la cartella dei font per il processo java non è accessibile
2. Quando la directory TEMP non è accessibile.

### **Soluzione**

Verifica e conferma che l'accesso alla directory TEMP e alla cartella dei font sia stato concesso. 

{{% alert color="warning" %}}
In alcuni casi potresti non essere in grado di concedere l'accesso alle cartelle a causa di restrizioni imposte dall'ambiente o da una politica di sicurezza. Prova queste soluzioni alternative: 
{{% /alert %}}

**Soluzione alternativa**

Utilizza [FontsLoader](https://reference.aspose.com/slides/it/java/com.aspose.slides/FontsLoader) per caricare i font necessari senza installarli:

```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```

Se la directory TEMP non è accessibile, usa questo codice per specificare un'altra directory come TEMP per Java:
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

## **Eccezione: InvalidOperationException: Impossibile trovare alcun font installato sul sistema**

Questa eccezione si verifica quando

1) il processo Java non può accedere alla cartella dei font  
2) non sono stati installati font.

### **Soluzione**

1. Verifica e conferma che l'accesso alla cartella dei font per il processo Java sia stato concesso.

2. Installa alcuni font o utilizza [FontsLoader](https://reference.aspose.com/slides/it/java/com.aspose.slides/FontsLoader).

3. Installa i font.

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

   * Utilizzando [FontsLoader](https://reference.aspose.com/slides/it/java/com.aspose.slides/FontsLoader): 

     ```
     FontsLoader.loadExternalFonts(pathToFontsFolders);
     ```

## **Eccezione: NoClassDefFoundError: Impossibile inizializzare la classe com.aspose.slides.internal.ey.this**

Questa eccezione si verifica su un sistema Linux che non dispone di fontconfig e di font. 

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

Inoltre, alcune versioni di open-jdk (ad esempio, **alpine JDK**) richiedono anche **font installati**.

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

## **Eccezione: UnsatisfiedLinkError: libfreetype.so.6: Impossibile aprire il file oggetto condiviso: Nessun file o directory**

Questa eccezione si verifica su un sistema Linux che non dispone della libreria libfreetype. 

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

{{% alert title="TIP" color="primary" %}} 
Non dimenticare di installare i font o di usare FontsLoader.
{{% /alert %}}