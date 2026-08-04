---
title: Presentazioni sicure con password in JavaScript
linktitle: Protezione con password
type: docs
weight: 20
url: /it/nodejs-java/password-protected-presentation/
keywords:
- blocca PowerPoint
- blocca presentazione
- sblocca PowerPoint
- sblocca presentazione
- proteggi PowerPoint
- proteggi presentazione
- imposta password
- aggiungi password
- crittografa PowerPoint
- crittografa presentazione
- decrittografa PowerPoint
- decrittografa presentazione
- protezione in scrittura
- sicurezza PowerPoint
- sicurezza presentazione
- rimuovi password
- rimuovi protezione
- rimuovi crittografia
- disabilita password
- disabilita protezione
- rimuovi protezione in scrittura
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Blocca e sblocca senza sforzo presentazioni PowerPoint e OpenDocument protette da password con Aspose.Slides per Node.js tramite Java. Metti al sicuro le tue presentazioni."
---
## **Introduzione**

Quando proteggi una presentazione con una password, imposti una password che applica determinate restrizioni alla presentazione. Per rimuovere le restrizioni è necessario inserire la password. Una presentazione protetta da password è considerata una presentazione bloccata.

Tipicamente, è possibile impostare una password per applicare queste restrizioni a una presentazione:

- **Modifica**

  Se desideri che solo alcuni utenti possano modificare la tua presentazione, puoi impostare una restrizione di modifica. Questa restrizione impedisce alle persone di modificare, cambiare o copiare elementi nella tua presentazione (a meno che non forniscano la password). 

  Tuttavia, in questo caso, anche senza password, un utente potrà accedere al documento e aprirlo. In modalità sola lettura, l'utente può visualizzare i contenuti o gli elementi — collegamenti ipertestuali, animazioni, effetti e altri — all'interno della presentazione, ma non può copiare elementi né salvare la presentazione. 

- **Apertura**

  Se desideri che solo alcuni utenti possano aprire la tua presentazione, puoi impostare una restrizione di apertura. Questa restrizione impedisce alle persone di visualizzare anche i contenuti della tua presentazione (a meno che non forniscano la password).

  Tecnicamente, la restrizione di apertura impedisce anche agli utenti di modificare le presentazioni: quando le persone non possono aprire una presentazione, non possono modificarla o apportare cambiamenti. 
  
  **Nota** che quando proteggi una presentazione con password per impedirne l'apertura, il file della presentazione diventa criptato.

## **Come proteggere con password una presentazione online**

1. Vai alla nostra pagina [**Aspose.Slides Lock**](https://products.aspose.app/slides/it/lock). 

   ![todo:image_alt_text](slides-lock.png)

2. Fai clic su **Drop or upload your files**.

3. Seleziona il file che desideri proteggere con password sul tuo computer. 

4. Inserisci la password preferita per la protezione in modifica; Inserisci la password preferita per la protezione della visualizzazione. 

5. Se desideri che gli utenti vedano la tua presentazione come copia finale, seleziona la casella di controllo **Mark as final**.

6. Fai clic su **PROTECT NOW.** 

7. Fai clic su **DOWNLOAD NOW.**

## **Protezione con password per le presentazioni in Aspose.Slides**
**Formati supportati**

Aspose.Slides supporta la protezione con password, la crittografia e operazioni simili per le presentazioni in questi formati: 

- PPTX e PPT - Microsoft PowerPoint Presentation 
- ODP - OpenDocument Presentation 
- OTP - OpenDocument Presentation Template 

**Operazioni supportate**

Aspose.Slides consente di utilizzare la protezione con password sulle presentazioni per prevenire modifiche in questi modi:

- Crittografare una presentazione
- Impostare una protezione in scrittura per una presentazione

**Altre operazioni**

Aspose.Slides consente di eseguire altre attività relative a protezione con password e crittografia nei seguenti modi:

- Decrittografare una presentazione; aprire una presentazione crittografata
- Rimuovere la crittografia; disabilitare la protezione con password
- Rimuovere la protezione in scrittura da una presentazione
- Ottenere le proprietà di una presentazione crittografata
- Verificare se una presentazione è crittografata
- Verificare se una presentazione è protetta da password.

## **Crittografare una presentazione**

Puoi crittografare una presentazione impostando una password. Per modificare la presentazione bloccata, un utente deve fornire la password. 

Per crittografare o proteggere con password una presentazione, devi utilizzare il metodo encrypt (da [ProtectionManager](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ProtectionManager)) per impostare una password per la presentazione. Passi la password al metodo encrypt e utilizzi il metodo save per salvare la presentazione ora crittografata.

Questo esempio di codice mostra come crittografare una presentazione:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Impostare la protezione in scrittura per una presentazione**

Puoi aggiungere una nota che dice “Do not modify” a una presentazione. In questo modo informi gli utenti che non vuoi che apportino modifiche alla presentazione.  

**Nota** che il processo di protezione in scrittura non crittografa la presentazione. Pertanto, gli utenti — se lo desiderano — possono modificare la presentazione, ma per salvare le modifiche dovranno creare una presentazione con un nome diverso. 

Per impostare una protezione in scrittura, devi utilizzare il metodo [setWriteProtection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ProtectionManager#setWriteProtection-java.lang.String-). Questo esempio di codice mostra come impostare una protezione in scrittura per una presentazione:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Decrittografare una presentazione; aprire una presentazione crittografata**

Aspose.Slides consente di caricare un file crittografato fornendo la sua password. Per decrittografare una presentazione, devi chiamare il metodo [removeEncryption](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ProtectionManager#removeEncryption--) senza parametri. Dovrai quindi inserire la password corretta per caricare la presentazione.

Questo esempio di codice mostra come decrittografare una presentazione: 

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("123123");
var presentation = new aspose.slides.Presentation("pres.pptx", loadOptions);
try {
    // lavorare con la presentazione decrittografata
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Rimuovere la crittografia; disabilitare la protezione con password**

Puoi rimuovere la crittografia o la protezione con password su una presentazione. In questo modo gli utenti possono accedere o modificare la presentazione senza restrizioni. 

Per rimuovere la crittografia o la protezione con password, devi chiamare il metodo [removeEncryption](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ProtectionManager#removeEncryption--). Questo esempio di codice mostra come rimuovere la crittografia da una presentazione:

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("123123");
var presentation = new aspose.slides.Presentation("pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Rimuovere la protezione in scrittura da una presentazione**

Puoi utilizzare Aspose.Slides per rimuovere la protezione in scrittura applicata a un file di presentazione. In questo modo gli utenti possono modificare a piacere — senza avvisi quando eseguono tali operazioni.

Puoi rimuovere la protezione in scrittura da una presentazione usando il metodo [removeWriteProtection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ProtectionManager#removeWriteProtection--). Questo esempio di codice mostra come rimuovere la protezione in scrittura da una presentazione:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Ottenere le proprietà di una presentazione crittografata**

Tipicamente, gli utenti hanno difficoltà a recuperare le proprietà del documento di una presentazione crittografata o protetta da password. Tuttavia, Aspose.Slides offre un meccanismo che consente di proteggere con password una presentazione mantenendo la possibilità per gli utenti di accedere alle sue proprietà.

**Nota:** Per impostazione predefinita, quando Aspose.Slides cripta una presentazione, anche le proprietà del documento della presentazione sono protette da password. Se è necessario rendere le proprietà del documento accessibili anche dopo la crittografia, Aspose.Slides lo consente.

Se desideri che gli utenti mantengano la possibilità di accedere alle proprietà di una presentazione crittografata, passa `false` a `setEncryptDocumentProperties` su [ProtectionManager](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/protectionmanager/). Questo esempio di codice mostra come crittografare una presentazione mantenendo l'accesso degli utenti alle sue proprietà del documento:

```javascript
const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Caricare solo le proprietà del documento da una presentazione crittografata**

Per ispezionare i metadati di una presentazione crittografata senza caricare le sue diapositive o altri contenuti, crea un oggetto [LoadOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/loadoptions/) e passa `true` a `setOnlyLoadDocumentProperties`. In questa modalità, Aspose.Slides ignora la password e carica solo le proprietà del documento che sono accessibili pubblicamente.

Il seguente esempio di codice legge le proprietà del documento integrate e personalizzate tramite `getDocumentProperties` su [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/):

```javascript
const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

const presentation = new aspose.slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    const documentProperties = presentation.getDocumentProperties();

    // Leggi le proprietà incorporate del documento.
    console.log("Title: " + documentProperties.getTitle());
    console.log("Author: " + documentProperties.getAuthor());

    // Leggi le proprietà personalizzate del documento.
    const customPropertyCount = documentProperties.getCountOfCustomProperties();

    for (let propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++) {
        const propertyName = documentProperties.getCustomPropertyName(propertyIndex);
        const propertyValue = documentProperties.get_Item(propertyName);

        console.log(propertyName + ": " + propertyValue);
    }
} finally {
    presentation.dispose();
}
```

Questo flusso di lavoro funziona solo quando le proprietà del documento sono state lasciate non criptate (pubbliche) al momento della crittografia della presentazione. Se le proprietà del documento sono criptate, passare `true` a `LoadOptions.setOnlyLoadDocumentProperties` provoca un'eccezione perché la password viene ignorata in questa modalità. Per accedere alle proprietà del documento criptate o caricare la presentazione completa, incluse le diapositive e gli altri contenuti, fornisci la password corretta tramite `LoadOptions.setPassword` su [LoadOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/loadoptions/).

## **Verificare se una presentazione è protetta da password prima di caricarla**

Prima di caricare una presentazione, potresti voler verificare e confermare che la presentazione non sia protetta da password. In questo modo eviti errori e problemi simili, che si verificano quando una presentazione protetta da password viene caricata senza la password.

Questo codice JavaScript mostra come esaminare una presentazione per verificare se è protetta da password (senza caricare la presentazione stessa):

```javascript
var presentationInfo = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("example.pptx");
console.log("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Verificare se una presentazione è crittografata**

Aspose.Slides consente di verificare se una presentazione è crittografata. Per eseguire questa operazione, puoi utilizzare la proprietà [isEncrypted](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ProtectionManager#isEncrypted--) che restituisce `true` se la presentazione è crittografata o `false` se la presentazione non è crittografata.

Questo esempio di codice mostra come verificare se una presentazione è crittografata:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    var isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Verificare se una presentazione è protetta in scrittura**

Aspose.Slides consente di verificare se una presentazione è protetta in scrittura. Per eseguire questa operazione, puoi utilizzare la proprietà [isWriteProtected](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ProtectionManager#isWriteProtected--) che restituisce `true` se la presentazione è protetta in scrittura o `false` se non lo è.

Questo esempio di codice mostra come verificare se una presentazione è protetta in scrittura:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    var isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Validare o confermare che una password specifica è stata utilizzata per proteggere una presentazione**

Potresti voler verificare e confermare che una password specifica sia stata utilizzata per proteggere un documento di presentazione. Aspose.Slides fornisce gli strumenti per convalidare una password. 

Questo esempio di codice mostra come convalidare una password:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    // controlla se "pass" corrisponde a
    var isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

Restituisce `true` se la presentazione è stata crittografata con la password specificata. Altrimenti, restituisce `false`.

{{% alert color="primary" title="Vedi anche" %}} 
- [Firma digitale in PowerPoint](/slides/it/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Quali metodi di criptazione sono supportati da Aspose.Slides?**

Aspose.Slides supporta metodi di crittografia moderni, inclusi algoritmi basati su AES, garantendo un alto livello di sicurezza dei dati per le tue presentazioni.

**Cosa succede se viene inserita una password errata durante il tentativo di aprire una presentazione?**

Viene generata un'eccezione se viene usata una password errata, avvisandoti che l'accesso alla presentazione è negato. Questo aiuta a prevenire accessi non autorizzati e protegge il contenuto della presentazione.

**Ci sono implicazioni di prestazioni quando si lavora con presentazioni protette da password?**

Il processo di crittografia e decrittografia può introdurre un leggero sovraccarico durante le operazioni di apertura e salvataggio. Nella maggior parte dei casi, questo impatto sulle prestazioni è minimo e non influisce in modo significativo sul tempo complessivo di elaborazione delle tue attività di presentazione.