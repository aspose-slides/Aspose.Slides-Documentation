---
title: Salva le presentazioni in modalità sola lettura usando PHP
linktitle: Presentazione sola lettura
type: docs
weight: 30
url: /it/php-java/read-only-presentation/
keywords:
- sola lettura
- proteggere la presentazione
- impedire modifiche
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Carica e salva file PowerPoint (PPT, PPTX) in modalità sola lettura con Aspose.Slides per PHP, offrendo anteprime precise delle diapositive senza modificare le tue presentazioni."
---
## **Introduzione**

In PowerPoint 2019, Microsoft ha introdotto l'impostazione **Always Open Read-Only** come una delle opzioni che gli utenti possono utilizzare per proteggere le proprie presentazioni. Potresti voler utilizzare questa impostazione Read-Only per proteggere una presentazione quando

- Vuoi impedire modifiche accidentali e mantenere al sicuro il contenuto della tua presentazione. 
- Vuoi avvisare le persone che la presentazione fornita è la versione finale. 

Dopo aver selezionato l'opzione **Always Open Read-Only** per una presentazione, quando gli utenti aprono la presentazione vedono la raccomandazione **Read-Only** e possono visualizzare un messaggio del questo tipo: *Per evitare modifiche accidentali, l'autore ha impostato questo file per aprirlo in modalità sola lettura.*

La raccomandazione **Read-Only** è un deterrente semplice ma efficace che scoraggia la modifica poiché gli utenti devono eseguire un'operazione per rimuoverla prima di poter modificare la presentazione. Se non vuoi che gli utenti apportino modifiche a una presentazione e desideri comunicarglielo in modo educato, la raccomandazione **Read-Only** può essere una buona opzione per te. 

> Se una presentazione protetta con **Read-Only** viene aperta in una versione più vecchia di Microsoft PowerPoint—che non supporta la funzione recentemente introdotta—la raccomandazione **Read-Only** viene ignorata (la presentazione viene aperta normalmente).

## **Applica modalità Read-Only**

Aspose.Slides per PHP via Java consente di impostare una presentazione su **Read-Only**, il che significa che gli utenti (dopo aver aperto la presentazione) vedono la raccomandazione **Read-Only**. Questo esempio di codice mostra come impostare una presentazione su **Read-Only** utilizzando Aspose.Slides:

```php
  $pres = new Presentation();
  try {
    $pres->getProtectionManager()->setReadOnlyRecommended(true);
    $pres->save("ReadOnlyPresentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 

**Nota**: La raccomandazione **Read-Only** è semplicemente intesa a scoraggiare le modifiche o a impedire agli utenti di apportare modifiche accidentali a una presentazione PowerPoint. Se una persona motivata—che sa cosa sta facendo—decide di modificare la tua presentazione, può facilmente rimuovere l'impostazione Read-Only. Se hai davvero bisogno di impedire modifiche non autorizzate, è meglio utilizzare [protezioni più rigorose che includono crittografia e password](https://docs.aspose.com/slides/it/php-java/password-protected-presentation/).

{{% /alert %}} 

## **FAQ**

**Come differisce 'Read-Only recommended' dalla protezione completa con password?**

'Read-Only recommended' visualizza solo un suggerimento per aprire il file in modalità sola lettura ed è facile da aggirare. [Protezione con password](/slides/it/php-java/password-protected-presentation/) restringe effettivamente l'apertura o la modifica ed è appropriata quando sono necessari controlli di sicurezza reali.

**Può 'Read-Only recommended' essere combinato con filigrane per scoraggiare ulteriormente le modifiche?**

Sì. La raccomandazione può essere associata a [filigrane](/slides/it/php-java/watermark/) come deterrente visivo; sono meccanismi separati e funzionano bene insieme.

**Una macro o uno strumento esterno può comunque modificare il file quando la raccomandazione è attiva?**

Sì. La raccomandazione non blocca le modifiche programmatiche. Per impedire modifiche automatizzate, usa [password e crittografia](/slides/it/php-java/password-protected-presentation/).

**Come si relaziona 'Read-Only recommended' ai metodi 'isEncrypted' e 'isWriteProtected'?**

Sono segnali diversi. 'Read-Only recommended' è un avviso morbido e opzionale; [isWriteProtected](https://reference.aspose.com/slides/it/php-java/aspose.slides/protectionmanager/iswriteprotected/) e [isEncrypted](https://reference.aspose.com/slides/it/php-java/aspose.slides/protectionmanager/isencrypted/) indicano restrizioni effettive di scrittura o lettura che dipendono da password o crittografia.