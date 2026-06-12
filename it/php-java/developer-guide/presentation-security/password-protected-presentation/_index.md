---
title: Presentazioni sicure con password in PHP
linktitle: Protezione con password
type: docs
weight: 20
url: /it/php-java/password-protected-presentation/
keywords:
- blocca PowerPoint
- blocca presentazione
- sblocca PowerPoint
- sblocca presentazione
- proteggi PowerPoint
- proteggi presentazione
- imposta password
- aggiungi password
- cripta PowerPoint
- cripta presentazione
- decripta PowerPoint
- decripta presentazione
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
- PHP
- Aspose.Slides
description: "Scopri come bloccare e sbloccare facilmente presentazioni PowerPoint e OpenDocument protette da password con Aspose.Slides per PHP. Proteggi le tue presentazioni."
---
## **Introduzione**

Quando proteggi una presentazione con password, imposti una password che applica determinate restrizioni sulla presentazione. Per rimuovere le restrizioni, è necessario inserire la password. Una presentazione protetta da password è considerata una presentazione bloccata.

Tipicamente, puoi impostare una password per applicare queste restrizioni su una presentazione:

- **Modifica**

  Se desideri che solo alcuni utenti possano modificare la tua presentazione, puoi impostare una restrizione di modifica. Questa restrizione impedisce alle persone di modificare, cambiare o copiare elementi nella presentazione (a meno che non forniscano la password).  

  Tuttavia, in questo caso, anche senza la password, un utente potrà accedere al documento e aprirlo. In modalità di sola lettura, l'utente può visualizzare il contenuto o gli elementi—collegamenti ipertestuali, animazioni, effetti e altri—della presentazione, ma non può copiare elementi né salvare la presentazione.  

- **Apertura**

  Se desideri che solo alcuni utenti possano aprire la tua presentazione, puoi impostare una restrizione di apertura. Questa restrizione impedisce alle persone di visualizzare il contenuto della presentazione (a meno che non forniscano la password).  

  Tecnicamente, la restrizione di apertura impedisce anche agli utenti di modificare le presentazioni: quando le persone non possono aprire una presentazione, non possono modificarla né apportare cambiamenti.  

  **Nota** che quando proteggi una presentazione con password per impedirne l'apertura, il file della presentazione diventa crittografato.

## **Come proteggere una presentazione con password online**

1. Vai alla nostra pagina [**Aspose.Slides Lock**](https://products.aspose.app/slides/it/lock). 

   ![todo:image_alt_text](slides-lock.png)

2. Fai clic su **Drop or upload your files**.

3. Seleziona il file che desideri proteggere con password sul tuo computer. 

4. Inserisci la password preferita per la protezione in scrittura; Inserisci la password preferita per la protezione in visualizzazione. 

5. Se vuoi che gli utenti vedano la tua presentazione come copia finale, spunta la casella **Mark as final**.

6. Fai clic su **PROTECT NOW.** 

7. Fai clic su **DOWNLOAD NOW.**

## **Protezione con password per le presentazioni in Aspose.Slides**
**Formati supportati**

Aspose.Slides supporta la protezione con password, la crittografia e operazioni simili per le presentazioni nei seguenti formati: 

- PPTX e PPT – Microsoft PowerPoint Presentation 
- ODP – OpenDocument Presentation 
- OTP – OpenDocument Presentation Template 

**Operazioni supportate**

Aspose.Slides consente di utilizzare la protezione con password sulle presentazioni per impedire modifiche nei seguenti modi:

- Crittografia di una presentazione
- Impostazione di una protezione in scrittura su una presentazione

**Altre operazioni**

Aspose.Slides consente di eseguire altre attività relative alla protezione con password e alla crittografia nei seguenti modi:

- Decrittazione di una presentazione; apertura di una presentazione crittografata
- Rimozione della crittografia; disabilitazione della protezione con password
- Rimozione della protezione in scrittura da una presentazione
- Ottenimento delle proprietà di una presentazione crittografata
- Verifica se una presentazione è crittografata
- Verifica se una presentazione è protetta da password.

## **Crittografa una presentazione**

Puoi crittografare una presentazione impostando una password. Poi, per modificare la presentazione bloccata, l'utente deve fornire la password. 

Per crittografare o proteggere con password una presentazione, devi utilizzare il metodo encrypt (da [ProtectionManager](https://reference.aspose.com/slides/it/php-java/aspose.slides/protectionmanager/)) per impostare una password per la presentazione. Passi la password al metodo encrypt e usi il metodo save per salvare la presentazione ora crittografata.

Questo esempio di codice mostra come crittografare una presentazione:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->encrypt("123123");
    $presentation->save("encrypted-pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Imposta la protezione in scrittura su una presentazione**

Puoi aggiungere una nota “Do not modify” a una presentazione. In questo modo, informi gli utenti che non vuoi che apportino modifiche alla presentazione.  

**Nota** che il processo di protezione in scrittura non crittografa la presentazione. Pertanto, gli utenti—se lo desiderano—possono modificare la presentazione, ma per salvare le modifiche dovranno creare una presentazione con un nome diverso. 

Per impostare una protezione in scrittura, devi utilizzare il metodo [setWriteProtection](https://reference.aspose.com/slides/it/php-java/aspose.slides/protectionmanager/#setWriteProtection). Questo esempio di codice mostra come impostare una protezione in scrittura su una presentazione:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->setWriteProtection("123123");
    $presentation->save("write-protected-pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Carica una presentazione crittografata**

Aspose.Slides consente di caricare un file crittografato passando la sua password. Per decrittare una presentazione, devi chiamare il metodo [removeEncryption](https://reference.aspose.com/slides/it/php-java/aspose.slides/protectionmanager/#removeEncryption) senza parametri. Dovrai quindi inserire la password corretta per caricare la presentazione.

Questo esempio di codice mostra come decrittare una presentazione: 

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setPassword("123123");
  $presentation = new Presentation("pres.pptx", $loadOptions);
  try {
    # lavora con la presentazione decrittata
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Rimuovi la crittografia da una presentazione**

Puoi rimuovere la crittografia o la protezione con password su una presentazione. In questo modo, gli utenti possono accedere o modificare la presentazione senza restrizioni. 

Per rimuovere la crittografia o la protezione con password, devi chiamare il metodo [removeEncryption](https://reference.aspose.com/slides/it/php-java/aspose.slides/protectionmanager/#removeEncryption). Questo esempio di codice mostra come rimuovere la crittografia da una presentazione:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setPassword("123123");
  $presentation = new Presentation("pres.pptx", $loadOptions);
  try {
    $presentation->getProtectionManager()->removeEncryption();
    $presentation->save("encryption-removed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Rimuovi la protezione in scrittura da una presentazione**

Puoi usare Aspose.Slides per rimuovere la protezione in scrittura applicata a un file di presentazione. In questo modo, gli utenti possono modificare liberamente e non riceveranno avvisi durante tali operazioni.

Puoi rimuovere la protezione in scrittura da una presentazione usando il metodo [removeWriteProtection](https://reference.aspose.com/slides/it/php-java/aspose.slides/protectionmanager/#removeWriteProtection). Questo esempio di codice mostra come rimuovere la protezione in scrittura da una presentazione:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->removeWriteProtection();
    $presentation->save("write-protection-removed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Ottieni le proprietà di una presentazione crittografata**

Tipicamente, gli utenti hanno difficoltà a ottenere le proprietà del documento di una presentazione crittografata o protetta da password. Aspose.Slides, tuttavia, offre un meccanismo che consente di proteggere con password una presentazione mantenendo la possibilità per gli utenti di accedere alle proprietà di quella presentazione.

**Nota** che quando Aspose.Slides crittografa una presentazione, anche le proprietà del documento della presentazione vengono protette da password per impostazione predefinita. Ma se è necessario rendere le proprietà della presentazione accessibili (anche dopo la crittografia), Aspose.Slides lo permette. 

Se desideri che gli utenti mantengano la possibilità di accedere alle proprietà di una presentazione che hai crittografato, puoi usare il metodo [encryptDocumentProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/protectionmanager/#getEncryptDocumentProperties) con valore `true`. Questo esempio di codice mostra come crittografare una presentazione fornendo al contempo i mezzi per gli utenti di accedere alle sue proprietà del documento:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->setEncryptDocumentProperties(true);
    $presentation->getProtectionManager()->encrypt("123123");
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Verifica se una presentazione è protetta da password**

Prima di caricare una presentazione, potresti voler verificare e confermare che la presentazione non sia stata protetta con una password. In questo modo, eviti errori e problemi simili che si verificano quando una presentazione protetta da password viene caricata senza la sua password.

Questo codice PHP mostra come esaminare una presentazione per verificare se è protetta da password (senza caricare la presentazione stessa):

```php
  $presentationInfo = PresentationFactory->getInstance()->getPresentationInfo("example.pptx");
  echo("The presentation is password protected: " . $presentationInfo->isPasswordProtected());

```

## **Verifica se una presentazione è crittografata**

Aspose.Slides consente di verificare se una presentazione è crittografata. Per eseguire questa operazione, puoi utilizzare il metodo [isEncrypted](https://reference.aspose.com/slides/it/php-java/aspose.slides/protectionmanager/#isEncrypted), che restituisce `true` se la presentazione è crittografata o `false` se la presentazione non è crittografata.

Questo esempio di codice mostra come verificare se una presentazione è crittografata:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $isEncrypted = $presentation->getProtectionManager()->isEncrypted();
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Verifica se una presentazione è protetta in scrittura**

Aspose.Slides consente di verificare se una presentazione è protetta in scrittura. Per eseguire questa operazione, puoi utilizzare il metodo [isWriteProtected](https://reference.aspose.com/slides/it/php-java/aspose.slides/protectionmanager/#isWriteProtected), che restituisce `true` se la presentazione è protetta in scrittura o `false` se non lo è.

Questo esempio di codice mostra come verificare se una presentazione è protetta in scrittura:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $isEncrypted = $presentation->getProtectionManager()->isWriteProtected();
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Convalida o conferma che una password specifica sia stata utilizzata**

Potresti voler verificare e confermare che una password specifica sia stata utilizzata per proteggere un documento di presentazione. Aspose.Slides fornisce i mezzi per convalidare una password. 

Questo esempio di codice mostra come convalidare una password:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    # verifica se "pass" corrisponde a
    $isWriteProtected = $presentation->getProtectionManager()->checkWriteProtection("my_password");
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

Restituisce `true` se la presentazione è stata crittografata con la password specificata. In caso contrario, restituisce `false`. 

{{% alert color="primary" title="Vedi anche" %}} 
- [Digital Signature in PowerPoint](/slides/it/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Quali metodi di crittografia sono supportati da Aspose.Slides?**

Aspose.Slides supporta metodi di crittografia moderni, inclusi algoritmi basati su AES, garantendo un alto livello di sicurezza dei dati per le tue presentazioni.

** Cosa succede se viene inserita una password errata durante il tentativo di aprire una presentazione?**

Viene generata un'eccezione se viene utilizzata una password errata, avvisandoti che l'accesso alla presentazione è negato. Questo aiuta a prevenire accessi non autorizzati e protegge il contenuto della presentazione.

**Ci sono implicazioni sulle prestazioni quando si lavora con presentazioni protette da password?**

Il processo di crittografia e decrittazione può introdurre un leggero overhead durante le operazioni di apertura e salvataggio. Nella maggior parte dei casi, questo impatto sulle prestazioni è minimo e non influisce in modo significativo sul tempo complessivo di elaborazione delle attività della tua presentazione.