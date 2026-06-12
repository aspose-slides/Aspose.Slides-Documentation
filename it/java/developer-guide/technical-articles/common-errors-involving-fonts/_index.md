---
title: "Eccezioni e errori comuni relativi ai font su Linux"
type: docs
weight: 200
url: /it/java/common-errors-involving-fonts/
keywords: "Eccezione del font, Errore del font, Linux, Java, Aspose.Slides per Java"
description: "Eccezioni e errori dei font su Linux"
---
## **Panoramica**

Quando Aspose.Slides viene utilizzato su Linux, possono verificarsi problemi relativi ai caratteri se il processo Java non riesce ad accedere alle cartelle dei font richiesti o alla directory temporanea, se non sono installati font sul sistema, oppure se mancano librerie di sistema necessarie come fontconfig o libfreetype.

Questo articolo descrive gli errori e le eccezioni più comuni relativi ai font su Linux e fornisce soluzioni per risolverli. Spiega come verificare l’accesso alle directory dei font e TEMP, installare i font e le librerie richieste e utilizzare `FontsLoader` per caricare i font senza installarli a livello di sistema.

## **Testo o Immagini Mancanti (EMF o WMF) Quando il Codice Viene Eseguito su Linux**

Questo problema si verifica in sistemi con restrizioni nei seguenti casi:

1. Quando non sono installati font o la cartella dei font per il processo Java non è accessibile
2. Quando la directory TEMP non è accessibile.

### **Soluzione**

Verificare e confermare che l’accesso alla directory TEMP e alla cartella dei font sia stato concesso. 

{{% alert color="warning" %}}

In alcuni casi potresti non essere in grado di concedere l’accesso alle cartelle a causa di restrizioni imposte dall’ambiente o da una policy di sicurezza. Prova queste soluzioni alternative: 

{{% /alert %}}

**Soluzione alternativa**

Usa [FontsLoader](https://reference.aspose.com/slides/it/java/com.aspose.slides/FontsLoader) per caricare i font richiesti senza installarli:

```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```

Se la directory TEMP non è accessibile, usa questo codice per specificare un’altra directory come TEMP per Java:
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

## **Eccezione: InvalidOperationException: Impossibile Trovare Nessun Font Installato sul Sistema**

Questa eccezione si verifica quando

1) il processo Java non può accedere alla cartella dei font  
2) non sono stati installati font.

### **Soluzione**

1. Verificare e confermare che l’accesso alla cartella dei font per il processo Java sia stato concesso.

2. Installare alcuni font o utilizzare [FontsLoader](https://reference.aspose.com/slides/it/java/com.aspose.slides/FontsLoader).

3. Installare i font.

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

## **Eccezione: NoClassDefFoundError: Impossibile Inizializzare la Classe com.aspose.slides.internal.ey.this**

Questa eccezione si verifica su un sistema Linux privo di fontconfig e font. 

### **Soluzione**

Installare fontconfig:

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

Inoltre, alcune versioni di open‑jdk (ad esempio, **alpine JDK**) richiedono anche **font installati**.

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

## **Eccezione: UnsatisfiedLinkError: libfreetype.so.6: Impossibile Aprire il File Object Condiviso: Nessun File o Directory di Questo Tipo**

Questa eccezione si verifica su un sistema Linux privo della libreria libfreetype. 

### **Soluzione**

Installare libfreetype e fontconfig:

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

{{% alert title="SUGGERIMENTO" color="primary" %}} 

Non dimenticare di installare i font o di utilizzare FontsLoader.

{{% /alert %}}  