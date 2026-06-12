---
title: Salva le presentazioni in modalità di sola lettura usando JavaScript
linktitle: Presentazione in sola lettura
type: docs
weight: 30
url: /it/nodejs-java/read-only-presentation/
keywords:
- sola lettura
- proteggere la presentazione
- impedire la modifica
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Carica e salva file PowerPoint in modalità sola lettura con Aspose.Slides per Node.js via Java, offrendo anteprime precise delle diapositive senza alterare le tue presentazioni."
---
## **Introduzione**

In PowerPoint 2019, Microsoft ha introdotto l'impostazione **Always Open Read-Only** come una delle opzioni che gli utenti possono utilizzare per proteggere le proprie presentazioni. Potresti voler utilizzare questa impostazione di sola lettura per proteggere una presentazione quando

- vuoi impedire modifiche accidentali e mantenere al sicuro il contenuto della tua presentazione. 
- vuoi segnalare alle persone che la presentazione fornita è la versione finale. 

Dopo aver selezionato l'opzione **Always Open Read-Only** per una presentazione, quando gli utenti aprono la presentazione vedono la raccomandazione **Read-Only** e potrebbero vedere un messaggio del tipo: *Per evitare modifiche accidentali, l'autore ha impostato questo file per l'apertura in sola lettura.*

La raccomandazione **Read-Only** è un deterrente semplice ma efficace che scoraggia la modifica perché gli utenti devono eseguire un'operazione per rimuoverla prima di poter modificare la presentazione. Se non desideri che gli utenti apportino modifiche a una presentazione e vuoi comunicarlo in modo cortese, la raccomandazione **Read-Only** può essere una buona opzione per te. 

> Se una presentazione con la protezione **Read-Only** viene aperta in una versione più vecchia di Microsoft PowerPoint—che non supporta la funzione recentemente introdotta—la raccomandazione **Read-Only** viene ignorata (la presentazione viene aperta normalmente).

## **Applicare la modalità Read-Only**

Aspose.Slides for Node.js via Java ti consente di impostare una presentazione su **Read-Only**, il che significa che gli utenti (dopo aver aperto la presentazione) vedono la raccomandazione **Read-Only**. Questo esempio di codice mostra come impostare una presentazione su **Read-Only** in JavaScript usando Aspose.Slides:

```javascript
var pres = new aspose.slides.Presentation();
try {
    pres.getProtectionManager().setReadOnlyRecommended(true);
    pres.save("ReadOnlyPresentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" %}} 

**Nota**: La raccomandazione **Read-Only** è semplicemente intesa a scoraggiare la modifica o a impedire modifiche accidentali a una presentazione PowerPoint. Se una persona motivata—che sa ciò che sta facendo—decide di modificare la tua presentazione, può facilmente rimuovere l'impostazione Read-Only. Se hai davvero bisogno di impedire modifiche non autorizzate, è meglio utilizzare [protezioni più rigorose che coinvolgono crittografie e password](https://docs.aspose.com/slides/it/nodejs-java/password-protected-presentation/).

{{% /alert %}} 

## **FAQ**

**In che modo 'Read-Only recommended' differisce dalla protezione completa con password?**

'Read-Only recommended' visualizza solo un suggerimento per aprire il file in modalità di sola lettura ed è facile da aggirare. [Protezione con password](/slides/it/nodejs-java/password-protected-presentation/) limita effettivamente l'apertura o la modifica ed è appropriata quando sono necessari controlli di sicurezza reali.

**Può 'Read-Only recommended' essere combinato con filigrane per scoraggiare ulteriormente le modifiche?**

Sì. La raccomandazione può essere accoppiata con [filigrane](/slides/it/nodejs-java/watermark/) come deterrente visivo; sono meccanismi separati e funzionano bene insieme.

**Una macro o uno strumento esterno può ancora modificare il file quando la raccomandazione è attiva?**

Sì. La raccomandazione non blocca le modifiche programmatiche. Per impedire modifiche automatizzate, usa [password e crittografia](/slides/it/nodejs-java/password-protected-presentation/).

**Come si relaziona 'Read-Only recommended' agli indicatori 'IsEncrypted' e 'IsWriteProtected'?**

Sono segnali diversi. 'Read-Only recommended' è un avviso morbido e opzionale; [isWriteProtected](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/protectionmanager/iswriteprotected/) e [isEncrypted](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/protectionmanager/isencrypted/) indicano restrizioni effettive di scrittura o lettura che dipendono da password o crittografia.