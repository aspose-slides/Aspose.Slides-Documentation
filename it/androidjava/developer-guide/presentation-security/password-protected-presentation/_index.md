---
title: Presentazioni sicure con password su Android
linktitle: Protezione con password
type: docs
weight: 20
url: /it/androidjava/password-protected-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Blocca e sblocca facilmente presentazioni PowerPoint e OpenDocument protette da password con Aspose.Slides per Android via Java. Metti al sicuro le tue presentazioni."
---
## **Introduzione**

Quando proteggi una presentazione con una password, imposti una password che applica determinate restrizioni alla presentazione. Per rimuovere le restrizioni, è necessario inserire la password. Una presentazione protetta da password è considerata una presentazione bloccata.

Tipicamente, puoi impostare una password per applicare queste restrizioni a una presentazione:

- **Modifica**

  Se desideri che solo alcuni utenti possano modificare la tua presentazione, puoi impostare una restrizione di modifica. Questa restrizione impedisce alle persone di modificare, cambiare o copiare elementi nella tua presentazione (a meno che non forniscano la password).

  Tuttavia, in questo caso, anche senza la password, un utente potrà accedere al documento e aprirlo. In modalità di sola lettura, l'utente può visualizzare i contenuti o gli elementi—collegamenti ipertestuali, animazioni, effetti e altri—della presentazione, ma non può copiare elementi né salvare la presentazione.

- **Apertura**

  Se desideri che solo alcuni utenti possano aprire la tua presentazione, puoi impostare una restrizione di apertura. Questa restrizione impedisce alle persone di vedere anche i contenuti della tua presentazione (a meno che non forniscano la password).

  Tecnically, the opening restriction also prevents users from modifying your presentations: When people cannot open a presentation, they cannot make modify or make changes to it. 
  
  **Nota** che quando proteggi una presentazione con password per impedirne l'apertura, il file della presentazione viene crittografato.

## **Protezione con password per le presentazioni in Aspose.Slides**
**Formati supportati**

Aspose.Slides supporta la protezione con password, la crittografia e operazioni simili per le presentazioni in questi formati:

- PPTX e PPT - Microsoft PowerPoint Presentation 
- ODP - OpenDocument Presentation 
- OTP - OpenDocument Presentation Template 

**Operazioni supportate**

Aspose.Slides consente di utilizzare la protezione con password sulle presentazioni per impedire modifiche in questi modi:

- Crittografare una presentazione
- Impostare una protezione in scrittura su una presentazione

**Altre operazioni**

Aspose.Slides consente di eseguire altre attività relative alla protezione con password e alla crittografia in questi modi:

- Decrittografare una presentazione; aprire una presentazione crittografata
- Rimuovere la crittografia; disabilitare la protezione con password
- Rimuovere la protezione in scrittura da una presentazione
- Ottenere le proprietà di una presentazione crittografata
- Verificare se una presentazione è crittografata
- Verificare se una presentazione è protetta da password.

## **Crittografa una presentazione**

Puoi crittografare una presentazione impostando una password. Dopo, per modificare la presentazione bloccata, l'utente deve fornire la password.

Per crittografare o proteggere una presentazione con password, devi usare il metodo encrypt (da [IProtectionManager](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IProtectionManager)) per impostare una password per la presentazione. Passi la password al metodo encrypt e usi il metodo save per salvare la presentazione ora crittografata.

Questo esempio di codice mostra come crittografare una presentazione:

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

Puoi aggiungere una nota “Do not modify” a una presentazione. In questo modo, informi gli utenti che non desideri che apportino modifiche alla presentazione.

**Nota** che il processo di protezione in scrittura non crittografa la presentazione. Pertanto, gli utenti—se lo desiderano—possono modificare la presentazione, ma per salvare le modifiche dovranno creare una presentazione con un nome diverso.

Per impostare una protezione in scrittura, devi usare il metodo [setWriteProtection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-). Questo esempio di codice mostra come impostare una protezione in scrittura su una presentazione:

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
    // lavorare con la presentazione decrittografata
} finally {
    if (presentation != null) presentation.dispose();
}
}
```

## **Rimuovi la crittografia da una presentazione**

Puoi rimuovere la crittografia o la protezione con password su una presentazione. In questo modo, gli utenti possono accedere o modificare la presentazione senza restrizioni.

Per rimuovere la crittografia o la protezione con password, devi chiamare il metodo [removeEncryption](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--). Questo esempio di codice mostra come rimuovere la crittografia da una presentazione:

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

Puoi usare Aspose.Slides per rimuovere la protezione in scrittura applicata a un file di presentazione. In questo modo, gli utenti possono modificare liberamente e non ricevono avvisi quando eseguono tali operazioni.

Puoi rimuovere la protezione in scrittura da una presentazione usando il metodo [removeWriteProtection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IProtectionManager#removeWriteProtection--) . Questo esempio di codice mostra come rimuovere la protezione in scrittura da una presentazione:

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

Tipicamente, gli utenti hanno difficoltà a ottenere le proprietà del documento di una presentazione crittografata o protetta da password. Aspose.Slides, tuttavia, offre un meccanismo che consente di proteggere con password una presentazione mantenendo la possibilità per gli utenti di accedere alle proprietà di tale presentazione.

**Nota** che quando Aspose.Slides crittografa una presentazione, le proprietà del documento della presentazione vengono protette da password per impostazione predefinita. Ma se è necessario rendere le proprietà della presentazione accessibili (anche dopo la crittografia), Aspose.Slides consente di farlo esattamente.

Se desideri che gli utenti mantengano la capacità di accedere alle proprietà di una presentazione che hai crittografato, puoi impostare la proprietà [encryptDocumentProperties](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IProtectionManager#getEncryptDocumentProperties--) su `true`. Questo esempio di codice mostra come crittografare una presentazione fornendo allo stesso tempo gli strumenti per gli utenti per accedere alle sue proprietà del documento:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(true);
    presentation.getProtectionManager().encrypt("123123");
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Verifica se una presentazione è protetta da password**

Prima di caricare una presentazione, potresti voler verificare e confermare che la presentazione non sia stata protetta da una password. In questo modo, eviti errori e problemi simili che si verificano quando si tenta di caricare una presentazione protetta senza conoscere la password.

Questo codice Java mostra come esaminare una presentazione per vedere se è protetta da password (senza caricare la presentazione stessa):

```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Verifica se una presentazione è crittografata**

Aspose.Slides consente di verificare se una presentazione è crittografata. Per eseguire questa operazione, puoi utilizzare la proprietà [isEncrypted](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IProtectionManager#isEncrypted--), che restituisce `true` se la presentazione è crittografata o `false` se non lo è.

Questo esempio di codice mostra come verificare se una presentazione è crittografata:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Verifica se una presentazione è protetta in scrittura**

Aspose.Slides consente di verificare se una presentazione è protetta in scrittura. Per eseguire questa operazione, puoi utilizzare la proprietà [isWriteProtected](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IProtectionManager#isWriteProtected--), che restituisce `true` se la presentazione è protetta in scrittura o `false` se non lo è.

Questo esempio di codice mostra come verificare se una presentazione è protetta in scrittura:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Convalida o conferma che una password specifica sia stata usata**

Potresti voler controllare e confermare che una password specifica sia stata usata per proteggere un documento di presentazione. Aspose.Slides fornisce gli strumenti per convalidare una password.

Questo esempio di codice mostra come convalidare una password:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    // verifica se "pass" corrisponde
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

Restituisce `true` se la presentazione è stata crittografata con la password specificata. Altrimenti restituisce `false`. 

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/it/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Domande frequenti**

**Quali metodi di crittografia sono supportati da Aspose.Slides?**

Aspose.Slides supporta metodi di crittografia moderni, inclusi gli algoritmi basati su AES, garantendo un alto livello di sicurezza dei dati per le tue presentazioni.

**Cosa succede se viene inserita una password errata durante il tentativo di aprire una presentazione?**

Viene generata un'eccezione se viene utilizzata una password errata, segnalando che l'accesso alla presentazione è negato. Ciò aiuta a prevenire accessi non autorizzati e protegge il contenuto della presentazione.

**Ci sono implicazioni di prestazioni quando si lavora con presentazioni protette da password?**

Il processo di crittografia e decrittografia può introdurre un leggero sovraccarico durante le operazioni di apertura e salvataggio. Nella maggior parte dei casi, questo impatto sulle prestazioni è minimo e non influisce in modo significativo sul tempo complessivo di elaborazione delle attività della presentazione.