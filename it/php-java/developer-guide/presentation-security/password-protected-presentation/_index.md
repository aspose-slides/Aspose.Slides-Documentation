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
- protegri PowerPoint
- protegri presentazione
- imposta password
- aggiungi password
- cifra PowerPoint
- cifra presentazione
- decifra PowerPoint
- decifra presentazione
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
- PHP
- Aspose.Slides
description: "Scopri come bloccare e sbloccare facilmente presentazioni PowerPoint e OpenDocument protette da password con Aspose.Slides per PHP. Metti al sicuro le tue presentazioni."
---
## **Introduzione**

Quando proteggi una presentazione con password, imposti una password che applica determinate restrizioni sulla presentazione. Per rimuovere le restrizioni, è necessario inserire la password. Una presentazione protetta da password è considerata una presentazione bloccata.

Tipicamente, puoi impostare una password per applicare queste restrizioni a una presentazione:

- **Modifica**

  Se desideri che solo alcuni utenti modifichino la tua presentazione, puoi impostare una restrizione di modifica. Questa restrizione impedisce alle persone di modificare, cambiare o copiare elementi nella tua presentazione (a meno che non forniscano la password).

  Tuttavia, in questo caso, anche senza la password, un utente potrà accedere al documento e aprirlo. In modalità sola lettura, l'utente può visualizzare i contenuti o elementi—collegamenti ipertestuali, animazioni, effetti e altri—della presentazione, ma non può copiare elementi né salvare la presentazione.

- **Apertura**

  Se desideri che solo alcuni utenti aprano la tua presentazione, puoi impostare una restrizione di apertura. Questa restrizione impedisce alle persone di visualizzare anche solo i contenuti della presentazione (a meno che non forniscano la password).

  Tecnicamente, la restrizione di apertura impedisce anche la modifica delle presentazioni: quando le persone non possono aprire una presentazione, non possono modificarla né apportare cambiamenti.

  **Note** che quando proteggi una presentazione con password per impedire l'apertura, il file della presentazione diventa crittografato.

## **Come proteggere con password una presentazione online**

1. Vai alla pagina [**Aspose.Slides Lock**](https://products.aspose.app/slides/it/lock).

   ![todo:image_alt_text](slides-lock.png)

2. Fai clic su **Drop or upload your files**.

3. Seleziona il file che desideri proteggere con password sul tuo computer.

4. Inserisci la password desiderata per la protezione di modifica; Inserisci la password desiderata per la protezione di visualizzazione.

5. Se desideri che gli utenti vedano la tua presentazione come copia finale, seleziona la casella di controllo **Mark as final**.

6. Fai clic su **PROTECT NOW.**

7. Fai clic su **DOWNLOAD NOW.**

## **Protezione con password per le presentazioni in Aspose.Slides**
**Formati supportati**

Aspose.Slides supporta la protezione con password, la crittografia e operazioni simili per le presentazioni nei seguenti formati:

- PPTX e PPT - Presentazione Microsoft PowerPoint
- ODP - Presentazione OpenDocument
- OTP - Modello di presentazione OpenDocument

**Operazioni supportate**

Aspose.Slides consente di utilizzare la protezione con password sulle presentazioni per impedire modifiche in questi modi:

- Crittografare una presentazione
- Impostare una protezione di scrittura su una presentazione

**Altre operazioni**

Aspose.Slides consente di eseguire altre attività relative a protezione con password e crittografia in questi modi:

- Decrittografare una presentazione; aprire una presentazione crittografata
- Rimuovere la crittografia; disabilitare la protezione con password
- Rimuovere la protezione di scrittura da una presentazione
- Ottenere le proprietà di una presentazione crittografata
- Verificare se una presentazione è crittografata
- Verificare se una presentazione è protetta da password.

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

## **Imposta la protezione di scrittura su una presentazione**

Puoi aggiungere un'indicazione “Do not modify” a una presentazione. In questo modo, informi gli utenti che non vuoi che apportino modifiche alla presentazione.

**Note** che il processo di protezione di scrittura non crittografa la presentazione. Pertanto, gli utenti—se lo desiderano—possono modificare la presentazione, ma per salvare le modifiche dovranno creare una presentazione con un nome diverso.

Per impostare una protezione di scrittura, devi utilizzare il metodo [setWriteProtection](https://reference.aspose.com/slides/it/php-java/aspose.slides/protectionmanager/#setWriteProtection). Questo esempio di codice mostra come impostare una protezione di scrittura su una presentazione:

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

Aspose.Slides consente di caricare un file crittografato passando la sua password. Per decrittografare una presentazione, devi chiamare il metodo [removeEncryption](https://reference.aspose.com/slides/it/php-java/aspose.slides/protectionmanager/#removeEncryption) senza parametri. Dovrai quindi inserire la password corretta per caricare la presentazione.

Questo esempio di codice mostra come decrittografare una presentazione:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setPassword("123123");
  $presentation = new Presentation("pres.pptx", $loadOptions);
  try {
    # lavora con la presentazione decrittografata
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

## **Rimuovi la protezione di scrittura da una presentazione**

Puoi utilizzare Aspose.Slides per rimuovere la protezione di scrittura utilizzata su un file di presentazione. In questo modo, gli utenti possono modificare liberamente e non ricevono avvisi durante tali operazioni.

Puoi rimuovere la protezione di scrittura da una presentazione usando il metodo [removeWriteProtection](https://reference.aspose.com/slides/it/php-java/aspose.slides/protectionmanager/#removeWriteProtection). Questo esempio di codice mostra come rimuovere la protezione di scrittura da una presentazione:

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

Tipicamente, gli utenti faticano a recuperare le proprietà del documento di una presentazione crittografata o protetta da password. Tuttavia, Aspose.Slides offre un meccanismo che consente di proteggere con password una presentazione mantenendo la possibilità per gli utenti di accedere alle proprietà.

**Note:** Per impostazione predefinita, quando Aspose.Slides crittografa una presentazione, anche le proprietà del documento della presentazione sono protette da password. Se è necessario rendere le proprietà del documento accessibili anche dopo la crittografia, Aspose.Slides lo permette.

Se vuoi che gli utenti mantengano la possibilità di accedere alle proprietà di una presentazione crittografata, passa `false` a [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties). Questo esempio di codice mostra come crittografare una presentazione mantenendo l'accesso degli utenti alle proprietà del documento:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->setEncryptDocumentProperties(false);
    $presentation->getProtectionManager()->encrypt("123123");
    $presentation->save("encrypted-pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Carica solo le proprietà del documento da una presentazione crittografata**

Per esaminare i metadati di una presentazione crittografata senza caricare le diapositive o altri contenuti, crea un oggetto [LoadOptions](https://reference.aspose.com/slides/it/php-java/aspose.slides/loadoptions/) e passa `true` a [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties). In questa modalità, Aspose.Slides ignora la password e carica solo le proprietà del documento pubblicamente accessibili.

Il seguente esempio di codice legge le proprietà di documento integrate e personalizzate tramite [Presentation::getDocumentProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#getDocumentProperties):

```php
$loadOptions = new LoadOptions();
$loadOptions->setOnlyLoadDocumentProperties(true);

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    $documentProperties = $presentation->getDocumentProperties();

    # Leggi le proprietà del documento predefinite.
    echo("Title: " . $documentProperties->getTitle() . "\n");
    echo("Author: " . $documentProperties->getAuthor() . "\n");

    # Leggi le proprietà del documento personalizzate.
    $customPropertyCount = java_values($documentProperties->getCountOfCustomProperties());

    for ($propertyIndex = 0; $propertyIndex < $customPropertyCount; $propertyIndex++) {
        $propertyName = $documentProperties->getCustomPropertyName($propertyIndex);
        $propertyValue = java_values($documentProperties->get_Item($propertyName));

        echo($propertyName . ": " . $propertyValue . "\n");
    }
} finally {
    $presentation->dispose();
}
```

Questo flusso di lavoro funziona solo quando le proprietà del documento sono state lasciate non crittografate (pubbliche) al momento della crittografia della presentazione. Se le proprietà del documento sono crittografate, passare `true` a [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) genera un'eccezione perché la password viene ignorata in questa modalità. Per accedere a proprietà del documento crittografate o caricare l'intera presentazione, incluse diapositive e altri contenuti, fornisci la password corretta tramite [LoadOptions::setPassword](https://reference.aspose.com/slides/it/php-java/aspose.slides/loadoptions/#setPassword).

## **Verifica se una presentazione è protetta da password**

Prima di caricare una presentazione, potresti volere verificare e confermare che la presentazione non sia protetta da password. In questo modo, eviti errori e problemi simili che si verificano quando si carica una presentazione protetta da password senza fornire la password.

Questo codice PHP mostra come esaminare una presentazione per vedere se è protetta da password (senza caricare la presentazione stessa):

```php
  $presentationInfo = PresentationFactory->getInstance()->getPresentationInfo("example.pptx");
  echo("The presentation is password protected: " . $presentationInfo->isPasswordProtected());

```

## **Verifica se una presentazione è crittografata**

Aspose.Slides consente di verificare se una presentazione è crittografata. Per eseguire questa operazione, puoi utilizzare il metodo [isEncrypted](https://reference.aspose.com/slides/it/php-java/aspose.slides/protectionmanager/#isEncrypted), che restituisce `true` se la presentazione è crittografata o `false` se non lo è.

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

## **Verifica se una presentazione è protetta da scrittura**

Aspose.Slides consente di verificare se una presentazione è protetta da scrittura. Per eseguire questa operazione, puoi utilizzare il metodo [isWriteProtected](https://reference.aspose.com/slides/it/php-java/aspose.slides/protectionmanager/#isWriteProtected), che restituisce `true` se la presentazione è crittografata o `false` se non lo è.

Questo esempio di codice mostra come verificare se una presentazione è protetta da scrittura:

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

## **Convalida o conferma che una password specifica è stata usata**

Potresti voler verificare e confermare che una password specifica sia stata usata per proteggere un documento di presentazione. Aspose.Slides fornisce gli strumenti per convalidare una password.

Questo esempio di codice mostra come convalidare una password:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    # verifica se "pass" corrisponde
    $isWriteProtected = $presentation->getProtectionManager()->checkWriteProtection("my_password");
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

Restituisce `true` se la presentazione è stata crittografata con la password specificata. Altrimenti, restituisce `false`.

{{% alert color="primary" title="Vedi anche" %}} 
- [Firma digitale in PowerPoint](/slides/it/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Quali metodi di crittografia sono supportati da Aspose.Slides?**

Aspose.Slides supporta metodi di crittografia moderni, inclusi algoritmi basati su AES, garantendo un alto livello di sicurezza dei dati per le tue presentazioni.

**Cosa succede se viene inserita una password errata durante il tentativo di aprire una presentazione?**

Viene generata un'eccezione se la password inserita è errata, segnalando che l'accesso alla presentazione è negato. Questo aiuta a prevenire accessi non autorizzati e protegge il contenuto della presentazione.

**Ci sono implicazioni di prestazioni quando si lavora con presentazioni protette da password?**

Il processo di crittografia e decrittografia può introdurre un leggero overhead durante le operazioni di apertura e salvataggio. Nella maggior parte dei casi, l'impatto sulle prestazioni è minimo e non influisce in modo significativo sul tempo complessivo di elaborazione delle tue attività di presentazione.