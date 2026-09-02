---
title: Presentazioni sicure con password su Android
linktitle: Protezione con password
type: docs
weight: 20
url: /it/androidjava/password-protected-presentation/
keywords:
- bloccare PowerPoint
- bloccare presentazione
- sbloccare PowerPoint
- sbloccare presentazione
- proteggere PowerPoint
- proteggere presentazione
- impostare password
- aggiungere password
- crittografare PowerPoint
- crittografare presentazione
- decrittografare PowerPoint
- decrittografare presentazione
- protezione di scrittura
- sicurezza PowerPoint
- sicurezza della presentazione
- rimuovere password
- rimuovere protezione
- rimuovere crittografia
- disabilitare password
- disabilitare protezione
- rimuovere protezione di scrittura
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Blocca e sblocca facilmente presentazioni PowerPoint e OpenDocument protette da password con Aspose.Slides per Android via Java. Proteggi le tue presentazioni."
---
## **Introduzione**

Quando proteggi una presentazione con una password, imposti una password che applica determinate restrizioni alla presentazione. Per rimuovere le restrizioni è necessario inserire la password. Una presentazione protetta da password è considerata una presentazione bloccata.

Tipicamente, puoi impostare una password per applicare queste restrizioni su una presentazione:

- **Modifica**

  Se desideri che solo alcuni utenti possano modificare la tua presentazione, puoi impostare una restrizione di modifica. Questa restrizione impedisce alle persone di modificare, cambiare o copiare elementi nella tua presentazione (a meno che non forniscano la password). 

  Tuttavia, in questo caso, anche senza la password, un utente potrà accedere al documento e aprirlo. In modalità di sola lettura, l'utente può visualizzare i contenuti o gli elementi—collegamenti ipertestuali, animazioni, effetti e altri—della presentazione, ma non può copiare elementi né salvare la presentazione. 

- **Apertura**

  Se desideri che solo alcuni utenti possano aprire la tua presentazione, puoi impostare una restrizione di apertura. Questa restrizione impedisce alle persone di visualizzare anche solo i contenuti della tua presentazione (a meno che non forniscano la password).

  Tecnicamente, la restrizione di apertura impedisce anche agli utenti di modificare le presentazioni: se le persone non possono aprire una presentazione, non possono modificarla o apportare modifiche. 
  
  **Nota** che quando proteggi una presentazione con password per impedirne l'apertura, il file della presentazione viene crittografato.

## **Protezione con password per le presentazioni in Aspose.Slides**
**Formati supportati**

Aspose.Slides supporta la protezione con password, la crittografia e operazioni simili per le presentazioni in questi formati: 

- PPTX e PPT - Presentazione Microsoft PowerPoint 
- ODP - Presentazione OpenDocument 
- OTP - Modello di presentazione OpenDocument 

**Operazioni supportate**

Aspose.Slides consente di utilizzare la protezione con password sulle presentazioni per impedire modifiche in questi modi:

- Crittografare una presentazione
- Impostare una protezione di scrittura su una presentazione

**Altre operazioni**

Aspose.Slides consente di eseguire altre operazioni relative alla protezione con password e alla crittografia in questi modi:

- Decrittografare una presentazione; aprire una presentazione crittografata
- Rimuovere la crittografia; disabilitare la protezione con password
- Rimuovere la protezione di scrittura da una presentazione
- Ottenere le proprietà di una presentazione crittografata
- Verificare se una presentazione è crittografata
- Verificare se una presentazione è protetta da password.

## **Crittografa una presentazione**

Puoi criptare una presentazione impostando una password. Poi, per modificare la presentazione bloccata, l'utente deve fornire la password. 

Per criptare o proteggere con password una presentazione, devi utilizzare il metodo encrypt (da [IProtectionManager](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IProtectionManager)) per impostare una password per la presentazione. Passi la password al metodo encrypt e usi il metodo save per salvare la presentazione ora criptata.

Questo esempio di codice mostra come criptare una presentazione:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Imposta la protezione di scrittura su una presentazione**

Puoi aggiungere un marchio con la dicitura “Do not modify” a una presentazione. In questo modo, informi gli utenti che non vuoi che apportino modifiche alla presentazione.  

**Nota** che il processo di protezione di scrittura non cripta la presentazione. Pertanto, gli utenti—se lo desiderano davvero—possono modificare la presentazione, ma per salvare le modifiche dovranno creare una presentazione con un nome diverso. 

Per impostare una protezione di scrittura, devi utilizzare il metodo [setWriteProtection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) . Questo esempio di codice mostra come impostare una protezione di scrittura su una presentazione:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Carica una presentazione crittografata**

Aspose.Slides consente di caricare un file crittografato passando la sua password. Per decrittografare una presentazione, devi chiamare il metodo [removeEncryption](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) senza parametri. Dovrai quindi inserire la password corretta per caricare la presentazione.

Questo esempio di codice mostra come decrittografare una presentazione: 

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // lavora con la presentazione decrittografata
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Rimuovi la crittografia da una presentazione**

Puoi rimuovere la crittografia o la protezione con password su una presentazione. In questo modo, gli utenti possono accedere o modificare la presentazione senza restrizioni. 

Per rimuovere la crittografia o la protezione con password, devi chiamare il metodo [removeEncryption](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) . Questo esempio di codice mostra come rimuovere la crittografia da una presentazione:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Rimuovi la protezione di scrittura da una presentazione**

Puoi usare Aspose.Slides per rimuovere la protezione di scrittura usata su un file di presentazione. In questo modo, gli utenti possono modificare come desiderano—e non ricevono avvisi quando eseguono tali operazioni.

Puoi rimuovere la protezione di scrittura da una presentazione utilizzando il metodo [removeWriteProtection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IProtectionManager#removeWriteProtection--) . Questo esempio di codice mostra come rimuovere la protezione di scrittura da una presentazione:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Ottieni le proprietà di una presentazione crittografata**

Tipicamente, gli utenti hanno difficoltà a recuperare le proprietà del documento di una presentazione crittografata o protetta da password. Tuttavia, Aspose.Slides offre un meccanismo che consente di proteggere con password una presentazione mantenendo la possibilità per gli utenti di accedere alle sue proprietà.

**Nota:** Per impostazione predefinita, quando Aspose.Slides cripta una presentazione, anche le proprietà del documento della presentazione sono protette da password. Se devi rendere le proprietà del documento accessibili anche dopo la crittografia, Aspose.Slides ti permette di farlo.

Se desideri che gli utenti mantengano la possibilità di accedere alle proprietà di una presentazione crittografata, passa `false` a [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-). Questo esempio di codice mostra come criptare una presentazione mantenendo l'accesso degli utenti alle sue proprietà del documento:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Carica solo le proprietà del documento da una presentazione crittografata**

Per ispezionare i metadati di una presentazione crittografata senza caricare le sue diapositive o altri contenuti, crea un oggetto [LoadOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/loadoptions/) e passa `true` a [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iloadoptions/#setOnlyLoadDocumentProperties-boolean-). In questa modalità, Aspose.Slides ignora la password e carica solo le proprietà del documento pubblicamente accessibili.

Il seguente esempio di codice legge le proprietà del documento incorporate e personalizzate tramite [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--):

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    // Leggi le proprietà del documento incorporate.
    System.out.println("Title: " + documentProperties.getTitle());
    System.out.println("Author: " + documentProperties.getAuthor());

    // Leggi le proprietà del documento personalizzate.
    int customPropertyCount = documentProperties.getCountOfCustomProperties();

    for (int propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++) {
        String propertyName = documentProperties.getCustomPropertyName(propertyIndex);
        Object propertyValue = documentProperties.get_Item(propertyName);

        System.out.println(propertyName + ": " + propertyValue);
    }
} finally {
    presentation.dispose();
}
```

Questo flusso di lavoro funziona solo quando le proprietà del documento sono state lasciate non crittografate (pubbliche) al momento della crittografia della presentazione. Se le proprietà del documento sono crittografate, passare `true` a `loadOptions.setOnlyLoadDocumentProperties` genera un'eccezione perché la password viene ignorata in questa modalità. Per accedere alle proprietà del documento crittografate o caricare l'intera presentazione, incluse le diapositive e altri contenuti, fornisci la password corretta tramite [ILoadOptions.setPassword](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-).

## **Verifica se una presentazione è protetta da password**

Prima di caricare una presentazione, potresti voler verificare e confermare che la presentazione non sia stata protetta da password. In questo modo eviti errori e problemi simili, che si verificano quando una presentazione protetta da password viene caricata senza la password.

Questo codice Java mostra come esaminare una presentazione per vedere se è protetta da password (senza caricare la presentazione stessa):

```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Verifica se una presentazione è crittografata**

Aspose.Slides consente di verificare se una presentazione è crittografata. Per eseguire questa operazione, puoi usare la proprietà [isEncrypted](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IProtectionManager#isEncrypted--) , che restituisce `true` se la presentazione è crittografata o `false` se la presentazione non è crittografata.

Questo esempio di codice mostra come verificare se una presentazione è crittografata:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Verifica se una presentazione è protetta da scrittura**

Aspose.Slides consente di verificare se una presentazione è protetta da scrittura. Per eseguire questa operazione, puoi usare la proprietà [isWriteProtected](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IProtectionManager#isWriteProtected--) , che restituisce `true` se la presentazione è crittografata o `false` se la presentazione non è crittografata.

Questo esempio di codice mostra come verificare se una presentazione è protetta da scrittura:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Convalida o conferma che una password specifica è stata usata**

Potresti voler verificare e confermare che una password specifica sia stata usata per proteggere un documento di presentazione. Aspose.Slides fornisce i mezzi per convalidare una password. 

Questo esempio di codice mostra come convalidare una password:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    // verifica se "pass" corrisponde a
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

Restituisce `true` se la presentazione è stata crittografata con la password specificata. Altrimenti restituisce `false`. 

{{% alert color="primary" title="Vedi anche" %}} 
- [Firma digitale in PowerPoint](/slides/it/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Quali metodi di crittografia sono supportati da Aspose.Slides?**

Aspose.Slides supporta metodi di crittografia moderni, inclusi gli algoritmi basati su AES, garantendo un elevato livello di sicurezza dei dati per le tue presentazioni.

**Cosa succede se viene inserita una password errata durante il tentativo di aprire una presentazione?**

Viene generata un'eccezione se viene utilizzata una password errata, avvisandoti che l'accesso alla presentazione è negato. Questo aiuta a prevenire accessi non autorizzati e protegge il contenuto della presentazione.

**Ci sono implicazioni sulle prestazioni quando si lavora con presentazioni protette da password?**

Il processo di crittografia e decrittografia può introdurre un leggero overhead durante le operazioni di apertura e salvataggio. Nella maggior parte dei casi, questo impatto sulle prestazioni è minimo e non influisce in modo significativo sul tempo complessivo di elaborazione delle tue attività di presentazione.