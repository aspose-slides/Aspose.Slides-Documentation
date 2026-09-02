---
title: Presentazioni protette da password in Java
linktitle: Protezione con password
type: docs
weight: 20
url: /it/java/password-protected-presentation/
keywords:
- blocca PowerPoint
- blocca presentazione
- sblocca PowerPoint
- sblocca presentazione
- proteggi PowerPoint
- proteggi presentazione
- imposta password
- aggiungi password
- cifra PowerPoint
- cifra presentazione
- decifra PowerPoint
- decifra presentazione
- protezione in scrittura
- sicurezza PowerPoint
- sicurezza presentazione
- rimuovi password
- rimuovi protezione
- rimuovi cifratura
- disabilita password
- disabilita protezione
- rimuovi protezione in scrittura
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Scopri come bloccare e sbloccare facilmente presentazioni PowerPoint e OpenDocument protette da password con Aspose.Slides per Java. Metti al sicuro le tue presentazioni."
---
## **Introduzione**

Quando proteggi una presentazione con una password, imposti una password che applica determinate restrizioni sulla presentazione. Per rimuovere queste restrizioni è necessario inserire la password. Una presentazione protetta da password è considerata una presentazione bloccata.

Tipicamente, puoi impostare una password per applicare queste restrizioni su una presentazione:

- **Modifica**

Se vuoi che solo alcuni utenti possano modificare la tua presentazione, puoi impostare una restrizione di modifica. Questa restrizione impedisce alle persone di modificare, cambiare o copiare elementi nella tua presentazione a meno che non forniscano la password. 

Tuttavia, anche senza la password, un utente potrà comunque accedere e aprire il documento. In questa modalità di sola lettura, l'utente può visualizzare il contenuto—including hyperlink, animazioni, effetti e altri elementi—della presentazione, ma non può copiare elementi né salvare la presentazione.

- **Apertura**

Se vuoi che solo alcuni utenti possano aprire la tua presentazione, puoi impostare una restrizione di apertura. Questa restrizione impedisce alle persone di visualizzare il contenuto della presentazione a meno che non forniscano la password.

Tecnicamente, la restrizione di apertura impedisce anche la modifica delle presentazioni: se gli utenti non possono aprire una presentazione, non possono modificarla o apportare cambiamenti.

**Nota:** Quando proteggi con password una presentazione per impedire l'apertura, il file della presentazione diventa criptato.

## **Protezione con password in Aspose.Slides**
**Formati supportati**

Aspose.Slides supporta la protezione con password, la crittografia e operazioni similari per le presentazioni nei seguenti formati: 

- PPTX e PPT - Presentazione Microsoft PowerPoint 
- ODP - Presentazione OpenDocument 
- OTP - Modello di presentazione OpenDocument 

**Operazioni supportate**

Aspose.Slides consente di utilizzare la protezione con password sulle presentazioni per impedire modifiche nei seguenti modi:

- Cifrare una presentazione
- Impostare una protezione in scrittura su una presentazione

**Altre operazioni**

Aspose.Slides consente di eseguire altre attività relative alla protezione con password e alla crittografia nei seguenti modi:

- Decifrare una presentazione; aprire una presentazione cifrata
- Rimuovere la crittografia; disabilitare la protezione con password
- Rimuovere la protezione in scrittura da una presentazione
- Ottenere le proprietà di una presentazione cifrata
- Verificare se una presentazione è cifrata
- Verificare se una presentazione è protetta da password.

## **Proteggi una presentazione con una password**

Puoi cifrare una presentazione impostando una password. Successivamente, per modificare la presentazione bloccata, l'utente deve fornire la password. 

Per cifrare o proteggere con password una presentazione, devi usare il metodo encrypt (da [IProtectionManager](https://reference.aspose.com/slides/it/java/com.aspose.slides/IProtectionManager)) per impostare una password per la presentazione. Passi la password al metodo encrypt e usi il metodo save per salvare la presentazione ora cifrata. 

Questo esempio di codice mostra come cifrare una presentazione:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Imposta la protezione in scrittura su una presentazione**

Puoi aggiungere una nota che recita “Do not modify” a una presentazione. In questo modo informi gli utenti che non vuoi che apportino modifiche alla presentazione.  

**Nota** che il processo di protezione in scrittura non cripta la presentazione. Pertanto, gli utenti—se lo desiderano davvero—possono modificare la presentazione, ma per salvare le modifiche dovranno creare una presentazione con un nome diverso. 

Per impostare una protezione in scrittura, devi usare il metodo [setWriteProtection](https://reference.aspose.com/slides/it/java/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) . Questo esempio di codice mostra come impostare una protezione in scrittura su una presentazione:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Carica una presentazione cifrata**

Aspose.Slides consente di caricare un file cifrato fornendo la sua password. Per decifrare una presentazione, devi chiamare il metodo [removeEncryption](https://reference.aspose.com/slides/it/java/com.aspose.slides/IProtectionManager#removeEncryption--) senza parametri. Dovrai quindi inserire la password corretta per caricare la presentazione. 

Questo esempio di codice mostra come decifrare una presentazione: 

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // lavorare con la presentazione decifrata
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Rimuovi la crittografia da una presentazione**

Puoi rimuovere la crittografia o la protezione con password su una presentazione. In questo modo gli utenti possono accedere o modificare la presentazione senza restrizioni. 

Per rimuovere la crittografia o la protezione con password, devi chiamare il metodo [removeEncryption](https://reference.aspose.com/slides/it/java/com.aspose.slides/IProtectionManager#removeEncryption--) . Questo esempio di codice mostra come rimuovere la crittografia da una presentazione:

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

## **Rimuovi la protezione in scrittura da una presentazione**

Puoi usare Aspose.Slides per rimuovere la protezione in scrittura utilizzata su un file di presentazione. In questo modo gli utenti possono modificare liberamente—e non ricevono avvisi quando eseguono tali operazioni.

Puoi rimuovere la protezione in scrittura da una presentazione usando il metodo [removeWriteProtection](https://reference.aspose.com/slides/it/java/com.aspose.slides/IProtectionManager#removeWriteProtection--) . Questo esempio di codice mostra come rimuovere la protezione in scrittura da una presentazione:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Ottieni le proprietà di una presentazione cifrata**

Tipicamente, gli utenti hanno difficoltà a recuperare le proprietà del documento di una presentazione cifrata o protetta da password. Tuttavia, Aspose.Slides offre un meccanismo che consente di proteggere con password una presentazione mantenendo la possibilità per gli utenti di accedere alle sue proprietà.

**Nota:** Per impostazione predefinita, quando Aspose.Slides cripta una presentazione, anche le proprietà del documento della presentazione sono protette da password. Se è necessario rendere le proprietà del documento accessibili anche dopo la crittografia, Aspose.Slides consente di farlo esattamente.

Se desideri che gli utenti mantengano la possibilità di accedere alle proprietà di una presentazione cifrata, passa `false` a [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) . Questo esempio di codice mostra come criptare una presentazione fornendo ancora agli utenti l'accesso alle proprietà del documento:

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

## **Carica solo le proprietà del documento da una presentazione cifrata**

Per ispezionare i metadati di una presentazione cifrata senza caricare le sue diapositive o altri contenuti, crea un oggetto [LoadOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/loadoptions/) e passa `true` a [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/iloadoptions/#setOnlyLoadDocumentProperties-boolean-) . In questa modalità, Aspose.Slides ignora la password e carica solo le proprietà del documento che sono pubblicamente accessibili.

Il seguente esempio di codice legge le proprietà di documento incorporate e personalizzate tramite [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipresentation/#getDocumentProperties--):

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    // Leggi le proprietà di documento integrate.
    System.out.println("Title: " + documentProperties.getTitle());
    System.out.println("Author: " + documentProperties.getAuthor());

    // Leggi le proprietà di documento personalizzate.
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

Questo flusso di lavoro funziona solo quando le proprietà del documento sono state lasciate non criptate (pubbliche) al momento della crittografia della presentazione. Se le proprietà del documento sono criptate, passare `true` a `loadOptions.setOnlyLoadDocumentProperties` genera un'eccezione perché la password è ignorata in questa modalità. Per accedere a proprietà del documento criptate o caricare l'intera presentazione, incluse diapositive e altri contenuti, fornisci la password corretta tramite [ILoadOptions.setPassword](https://reference.aspose.com/slides/it/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) .

## **Verifica se una presentazione è protetta da password**

Prima di caricare una presentazione, potresti voler controllare e confermare che la presentazione non sia stata protetta con una password. In questo modo eviti errori e problemi simili, che si verificano quando una presentazione protetta da password viene caricata senza la password.

Questo codice Java mostra come esaminare una presentazione per vedere se è protetta da password (senza caricare la presentazione stessa):

```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Verifica se una presentazione è cifrata**

Aspose.Slides consente di verificare se una presentazione è criptata. Per eseguire questa operazione, puoi usare la proprietà [isEncrypted](https://reference.aspose.com/slides/it/java/com.aspose.slides/IProtectionManager#isEncrypted--) che restituisce `true` se la presentazione è criptata o `false` se la presentazione non è criptata. 

Questo esempio di codice mostra come verificare se una presentazione è criptata:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Verifica se una presentazione è protetta in scrittura**

Aspose.Slides consente di verificare se una presentazione è protetta in scrittura. Per eseguire questa operazione, puoi usare la proprietà [isWriteProtected](https://reference.aspose.com/slides/it/java/com.aspose.slides/IProtectionManager#isWriteProtected--) che restituisce `true` se la presentazione è protetta in scrittura o `false` se la presentazione non è protetta in scrittura. 

Questo esempio di codice mostra come verificare se una presentazione è protetta in scrittura:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Convalida o conferma che una password specifica è stata usata**

Potresti voler controllare e confermare che una password specifica sia stata usata per proteggere un documento di presentazione. Aspose.Slides fornisce i mezzi per convalidare una password. 

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

Restituisce `true` se la presentazione è stata criptata con la password specificata. Altrimenti, restituisce `false`. 

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/it/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Quali metodi di cifratura sono supportati da Aspose.Slides?**

Aspose.Slides supporta metodi di cifratura moderni, inclusi algoritmi basati su AES, garantendo un alto livello di sicurezza dei dati per le tue presentazioni.

**Cosa succede se viene inserita una password errata durante il tentativo di aprire una presentazione?**

Viene generata un'eccezione se viene utilizzata una password errata, avvisandoti che l'accesso alla presentazione è negato. Questo aiuta a prevenire accessi non autorizzati e protegge il contenuto della presentazione.

**Ci sono implicazioni di prestazioni quando si lavora con presentazioni protette da password?**

Il processo di crittografia e decifratura può introdurre un leggero sovraccarico durante le operazioni di apertura e salvataggio. Nella maggior parte dei casi, questo impatto sulle prestazioni è minimo e non influisce in modo significativo sul tempo di elaborazione complessivo delle tue attività di presentazione.