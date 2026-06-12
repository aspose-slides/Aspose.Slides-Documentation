---
title: Salva presentazioni in modalità sola lettura usando Java
linktitle: Presentazione in sola lettura
type: docs
weight: 30
url: /it/java/read-only-presentation/
keywords:
- sola lettura
- protezione presentazione
- evitare modifiche
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Carica e salva file PowerPoint (PPT, PPTX) in modalità sola lettura con Aspose.Slides per Java, offrendo anteprime precise delle diapositive senza alterare le tue presentazioni."
---
## **Introduzione**

In PowerPoint 2019, Microsoft ha introdotto l'impostazione **Always Open Read-Only** come una delle opzioni che gli utenti possono usare per proteggere le loro presentazioni. Potresti voler utilizzare questa impostazione di sola lettura per proteggere una presentazione quando

- Vuoi impedire modifiche accidentali e mantenere al sicuro il contenuto della tua presentazione. 
- Vuoi avvisare le persone che la presentazione fornita è la versione finale. 

Dopo aver selezionato l'opzione **Always Open Read-Only** per una presentazione, quando gli utenti aprono la presentazione, vedono la raccomandazione **Read-Only** e possono vedere un messaggio in questa forma: *Per evitare modifiche accidentali, l'autore ha impostato questo file per l'apertura in sola lettura.*

La raccomandazione **Read-Only** è un deterrente semplice ma efficace che scoraggia la modifica perché gli utenti devono eseguire un'operazione per rimuoverla prima di poter modificare una presentazione. Se non vuoi che gli utenti apportino modifiche a una presentazione e desideri comunicarlo in modo educato, la raccomandazione **Read-Only** può essere una buona opzione per te. 

> Se una presentazione con la protezione **Read-Only** viene aperta in una versione più vecchia di Microsoft PowerPoint—che non supporta la funzione introdotta recentemente—la raccomandazione **Read-Only** viene ignorata (la presentazione viene aperta normalmente).

## **Applicare la modalità Read-Only**

Aspose.Slides for Java consente di impostare una presentazione su **Read-Only**, il che significa che gli utenti (dopo aver aperto la presentazione) vedono la raccomandazione **Read-Only**. Questo esempio di codice mostra come impostare una presentazione su **Read-Only** in Java usando Aspose.Slides:

```java
Presentation pres = new Presentation();
try {
    pres.getProtectionManager().setReadOnlyRecommended(true);
    pres.save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 

**Nota**: La raccomandazione **Read-Only** è intesa semplicemente per scoraggiare la modifica o impedire agli utenti di apportare cambiamenti accidentali a una presentazione PowerPoint. Se una persona motivata—che sa cosa sta facendo—decide di modificare la tua presentazione, può rimuovere facilmente l'impostazione Read-Only. Se hai davvero bisogno di impedire modifiche non autorizzate, è più opportuno utilizzare [protezioni più rigorose che includono crittografie e password](https://docs.aspose.com/slides/it/java/password-protected-presentation/). 

{{% /alert %}} 

## **FAQ**

**Qual è la differenza tra 'Read-Only recommended' e la protezione completa con password?**

'Read-Only recommended' visualizza solo un suggerimento per aprire il file in modalità sola lettura ed è facile da aggirare. [Password protection](/slides/it/java/password-protected-presentation/) limita realmente l'apertura o la modifica ed è appropriata quando sono necessari controlli di sicurezza reali.

**'Read-Only recommended' può essere combinato con filigrane per scoraggiare ulteriormente le modifiche?**

Sì. La raccomandazione può essere associata a [watermarks](/slides/it/java/watermark/) come deterrente visivo; sono meccanismi separati e funzionano bene insieme.

**Una macro o uno strumento esterno può ancora modificare il file quando la raccomandazione è abilitata?**

Sì. La raccomandazione non blocca le modifiche programmatiche. Per impedire modifiche automatizzate, usa [passwords and encryption](/slides/it/java/password-protected-presentation/).

**Come si collega 'Read-Only recommended' ai metodi 'isEncrypted' e 'isWriteProtected'?**

Sono segnali diversi. 'Read-Only recommended' è un prompt morbido e opzionale; [isWriteProtected](https://reference.aspose.com/slides/it/java/com.aspose.slides/protectionmanager/#isWriteProtected--) e [isEncrypted](https://reference.aspose.com/slides/it/java/com.aspose.slides/protectionmanager/#isEncrypted--) indicano restrizioni effettive di scrittura o lettura che dipendono da password o crittografia.