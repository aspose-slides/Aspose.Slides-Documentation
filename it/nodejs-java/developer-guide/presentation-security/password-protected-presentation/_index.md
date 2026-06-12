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
- protezione di scrittura
- sicurezza PowerPoint
- sicurezza presentazione
- rimuovi password
- rimuovi protezione
- rimuovi crittografia
- disabilita password
- disabilita protezione
- rimuovi protezione di scrittura
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Blocca e sblocca facilmente le presentazioni PowerPoint e OpenDocument protette da password con Aspose.Slides per Node.js tramite Java. Proteggi le tue presentazioni."
---
## **Introduzione**

Quando proteggi una presentazione con password, imposti una password che applica determinate restrizioni sulla presentazione. Per rimuovere le restrizioni, è necessario inserire la password. Una presentazione protetta da password è considerata una presentazione bloccata.

Tipicamente, puoi impostare una password per applicare queste restrizioni a una presentazione:

- **Modifica**

  Se desideri che solo alcuni utenti possano modificare la tua presentazione, puoi impostare una restrizione di modifica. Questa restrizione impedisce alle persone di modificare, cambiare o copiare elementi nella tua presentazione (a meno che non forniscano la password).

  Tuttavia, in questo caso, anche senza la password, un utente potrà accedere al documento e aprirlo. In modalità di sola lettura, l'utente può visualizzare il contenuto o gli elementi — collegamenti ipertestuali, animazioni, effetti e altri — all'interno della presentazione, ma non può copiare elementi né salvare la presentazione.

- **Apertura**

  Se desideri che solo alcuni utenti possano aprire la tua presentazione, puoi impostare una restrizione di apertura. Questa restrizione impedisce alle persone di visualizzare anche il contenuto della presentazione (a meno che non forniscano la password).

  Tecnicamente, la restrizione di apertura impedisce anche agli utenti di modificare le presentazioni: quando le persone non possono aprire una presentazione, non possono modificarla o apportare cambiamenti.

  **Nota** che quando proteggi una presentazione con password per impedire l'apertura, il file della presentazione diventa crittografato.

## **Come proteggere una presentazione con password online**

1. Vai alla nostra pagina [**Aspose.Slides Lock**](https://products.aspose.app/slides/it/lock).

   ![todo:image_alt_text](slides-lock.png)

2. Fai clic su **Drop or upload your files**.

3. Seleziona il file che desideri proteggere con password sul tuo computer.

4. Inserisci la password preferita per la protezione della modifica; inserisci la password preferita per la protezione della visualizzazione.

5. Se vuoi che gli utenti vedano la tua presentazione come copia finale, spunta la casella di controllo **Mark as final**.

6. Fai clic su **PROTECT NOW.**

7. Fai clic su **DOWNLOAD NOW.**

## **Protezione con password per le presentazioni in Aspose.Slides**
**Formati supportati**

Aspose.Slides supporta la protezione con password, la crittografia e operazioni simili per presentazioni nei seguenti formati:

- PPTX e PPT – Microsoft PowerPoint Presentation
- ODP – OpenDocument Presentation
- OTP – OpenDocument Presentation Template

**Operazioni supportate**

Aspose.Slides ti consente di utilizzare la protezione con password sulle presentazioni per impedire modifiche in questi modi:

- Crittografare una presentazione
- Impostare una protezione di scrittura su una presentazione

**Altre operazioni**

Aspose.Slides ti consente di eseguire altre attività relative a protezione con password e crittografia in questi modi:

- Decrittare una presentazione; aprire una presentazione crittografata
- Rimuovere la crittografia; disabilitare la protezione con password
- Rimuovere la protezione di scrittura da una presentazione
- Ottenere le proprietà di una presentazione crittografata
- Verificare se una presentazione è crittografata
- Verificare se una presentazione è protetta da password.

## **Crittografia di una presentazione**

Puoi crittografare una presentazione impostando una password. Poi, per modificare la presentazione bloccata, un utente deve fornire la password.

Per crittografare o proteggere con password una presentazione, devi usare il metodo encrypt (da [ProtectionManager](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ProtectionManager)) per impostare una password per la presentazione. Passi la password al metodo encrypt e usi il metodo save per salvare la presentazione ora crittografata.

Questo esempio di codice ti mostra come crittografare una presentazione:

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

## **Impostare la protezione di scrittura su una presentazione**

Puoi aggiungere una nota “Do not modify” a una presentazione. In questo modo, avvisi gli utenti che non vuoi che apportino modifiche alla presentazione.

**Nota** che il processo di protezione di scrittura non crittografa la presentazione. Pertanto, gli utenti — se lo desiderano — possono modificare la presentazione, ma per salvare le modifiche dovranno creare una presentazione con un nome diverso.

Per impostare una protezione di scrittura, devi usare il metodo [setWriteProtection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ProtectionManager#setWriteProtection-java.lang.String-). Questo esempio di codice ti mostra come impostare la protezione di scrittura su una presentazione:

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

## **Decrittare una presentazione; aprire una presentazione crittografata**

Aspose.Slides ti consente di caricare un file crittografato passando la sua password. Per decrittare una presentazione, devi chiamare il metodo [removeEncryption](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ProtectionManager#removeEncryption--) senza parametri. Dovrai quindi inserire la password corretta per caricare la presentazione.

Questo esempio di codice ti mostra come decrittare una presentazione:

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("123123");
var presentation = new aspose.slides.Presentation("pres.pptx", loadOptions);
try {
    // lavorare con la presentazione decrittata
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Rimuovere la crittografia; disabilitare la protezione con password**

Puoi rimuovere la crittografia o la protezione con password su una presentazione. In questo modo, gli utenti possono accedere o modificare la presentazione senza restrizioni.

Per rimuovere la crittografia o la protezione con password, devi chiamare il metodo [removeEncryption](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ProtectionManager#removeEncryption--). Questo esempio di codice ti mostra come rimuovere la crittografia da una presentazione:

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

## **Rimuovere la protezione di scrittura da una presentazione**

Puoi usare Aspose.Slides per rimuovere la protezione di scrittura usata su un file di presentazione. In questo modo, gli utenti possono modificare come preferiscono — e non ricevono avvisi quando eseguono tali operazioni.

Puoi rimuovere la protezione di scrittura da una presentazione usando il metodo [removeWriteProtection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ProtectionManager#removeWriteProtection--) . Questo esempio di codice ti mostra come rimuovere la protezione di scrittura da una presentazione:

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

Tipicamente, gli utenti hanno difficoltà a ottenere le proprietà del documento di una presentazione crittografata o protetta da password. Aspose.Slides, tuttavia, offre un meccanismo che consente di proteggere una presentazione con password mantenendo la possibilità per gli utenti di accedere alle proprietà di quella presentazione.

**Nota** che quando Aspose.Slides cripta una presentazione, anche le proprietà del documento della presentazione vengono protette da password per impostazione predefinita. Ma se è necessario rendere le proprietà della presentazione accessibili (anche dopo la crittografia), Aspose.Slides consente di farlo.

Se vuoi che gli utenti conservino la possibilità di accedere alle proprietà di una presentazione che hai criptato, puoi impostare la proprietà [encryptDocumentProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ProtectionManager#getEncryptDocumentProperties--) su `true`. Questo esempio di codice ti mostra come crittografare una presentazione fornendo comunque agli utenti i mezzi per accedere alle sue proprietà di documento:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(true);
    presentation.getProtectionManager().encrypt("123123");
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Verificare se una presentazione è protetta da password prima di caricarla**

Prima di caricare una presentazione, potresti voler verificare e confermare che la presentazione non sia stata protetta da password. In questo modo, eviti errori e problemi simili che si verificano quando una presentazione protetta da password viene caricata senza la sua password.

Questo codice JavaScript ti mostra come esaminare una presentazione per vedere se è protetta da password (senza caricare la presentazione stessa):

```javascript
var presentationInfo = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("example.pptx");
console.log("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Verificare se una presentazione è crittografata**

Aspose.Slides ti consente di verificare se una presentazione è crittografata. Per eseguire questa operazione, puoi usare la proprietà [isEncrypted](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ProtectionManager#isEncrypted--) che restituisce `true` se la presentazione è crittografata o `false` se non lo è.

Questo esempio di codice ti mostra come verificare se una presentazione è crittografata:

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

## **Verificare se una presentazione è protetta da scrittura**

Aspose.Slides ti consente di verificare se una presentazione è protetta da scrittura. Per eseguire questa operazione, puoi usare la proprietà [isWriteProtected](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ProtectionManager#isWriteProtected--) che restituisce `true` se la presentazione è protetta da scrittura o `false` se non lo è.

Questo esempio di codice ti mostra come verificare se una presentazione è protetta da scrittura:

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

## **Convalidare o confermare che una password specifica sia stata usata per proteggere una presentazione**

Potresti voler verificare e confermare che una password specifica sia stata usata per proteggere un documento di presentazione. Aspose.Slides fornisce i mezzi per convalidare una password.

Questo esempio di codice ti mostra come convalidare una password:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    // verifica se "pass" corrisponde a
    var isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

Restituisce `true` se la presentazione è stata criptata con la password specificata. Altrimenti, restituisce `false`.

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/it/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Quali metodi di crittografia sono supportati da Aspose.Slides?**

Aspose.Slides supporta metodi di crittografia moderni, inclusi algoritmi basati su AES, garantendo un elevato livello di sicurezza dei dati per le tue presentazioni.

** Cosa accade se viene inserita una password errata durante il tentativo di aprire una presentazione?**

Viene generata un'eccezione se viene utilizzata una password errata, avvisandoti che l'accesso alla presentazione è negato. Questo aiuta a prevenire accessi non autorizzati e protegge il contenuto della presentazione.

**Ci sono implicazioni sulle prestazioni quando si lavora con presentazioni protette da password?**

Il processo di crittografia e decrittografia può introdurre un leggero overhead durante le operazioni di apertura e salvataggio. Nella maggior parte dei casi, questo impatto sulle prestazioni è minimo e non influisce in modo significativo sul tempo complessivo di elaborazione delle tue attività di presentazione.