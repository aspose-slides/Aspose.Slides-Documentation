---  
title: Salva le presentazioni in modalità sola lettura su Android  
linktitle: Presentazione in sola lettura  
type: docs  
weight: 30  
url: /it/androidjava/read-only-presentation/  
keywords:  
- sola lettura  
- proteggere la presentazione  
- impedire la modifica  
- PowerPoint  
- OpenDocument  
- presentazione  
- Android  
- Java  
- Aspose.Slides  
description: "Salva i file PowerPoint (PPT, PPTX) in modalità sola lettura con Aspose.Slides per Android via Java, offrendo anteprime precise delle diapositive senza modificare le tue presentazioni."  
---
## **Introduzione**

In PowerPoint 2019, Microsoft ha introdotto l'impostazione **Always Open Read-Only** come una delle opzioni che gli utenti possono usare per proteggere le loro presentazioni. Potresti voler usare questa impostazione Read-Only per proteggere una presentazione quando

- Vuoi evitare modifiche accidentali e mantenere il contenuto della tua presentazione al sicuro. 
- Vuoi avvisare le persone che la presentazione che hai fornito è la versione finale. 

Dopo aver selezionato l'opzione **Always Open Read-Only** per una presentazione, quando gli utenti aprono la presentazione, vedono la raccomandazione **Read-Only** e possono vedere un messaggio in questa forma: *Per evitare modifiche accidentali, l'autore ha impostato questo file per aprirlo in sola lettura.*

La raccomandazione **Read-Only** è un deterrente semplice ma efficace che scoraggia la modifica poiché gli utenti devono eseguire un'operazione per rimuoverla prima di poter modificare una presentazione. Se non vuoi che gli utenti apportino modifiche a una presentazione e desideri comunicarlo in modo cortese, la raccomandazione **Read-Only** può essere una buona soluzione per te. 

> Se una presentazione con la protezione **Read-Only** viene aperta in una versione più vecchia di Microsoft PowerPoint—che non supporta la funzione introdotta di recente—la raccomandazione **Read-Only** viene ignorata (la presentazione viene aperta normalmente).

## **Applicare la modalità Read-Only**

Aspose.Slides per Android via Java consente di impostare una presentazione su **Read-Only**, il che significa che gli utenti (dopo aver aperto la presentazione) vedono la raccomandazione **Read-Only**. Questo esempio di codice mostra come impostare una presentazione su **Read-Only** in Java utilizzando Aspose.Slides:

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

**Nota**: La raccomandazione **Read-Only** è semplicemente intesa a scoraggiare la modifica o impedire agli utenti di apportare modifiche accidentali a una presentazione PowerPoint. Se una persona motivata—che sa cosa sta facendo—decide di modificare la tua presentazione, può facilmente rimuovere l'impostazione Read-Only. Se hai davvero bisogno di impedire modifiche non autorizzate, è meglio utilizzare [Protezione con password](/slides/it/androidjava/password-protected-presentation/).

{{% /alert %}} 

## **FAQ**

**Come differisce 'Read-Only recommended' dalla protezione completa con password?**

'Read-Only recommended' mostra solo un suggerimento per aprire il file in modalità sola lettura ed è facile da bypassare. [Protezione con password](/slides/it/androidjava/password-protected-presentation/) in realtà limita l'apertura o la modifica ed è appropriata quando hai bisogno di controlli di sicurezza reali.

**È possibile combinare 'Read-Only recommended' con filigrane per scoraggiare ulteriormente le modifiche?**

Sì. La raccomandazione può essere associata a [filigrane](/slides/it/androidjava/watermark/) come deterrente visivo; sono meccanismi separati e funzionano bene insieme.

**Una macro o uno strumento esterno può ancora modificare il file quando la raccomandazione è attiva?**

Sì. La raccomandazione non blocca le modifiche programmatiche. Per impedire le modifiche automatiche, usa [password e crittografia](/slides/it/androidjava/password-protected-presentation/).

**Come si relaziona 'Read-Only recommended' ai metodi 'isEncrypted' e 'isWriteProtected'?**

Sono segnali diversi. 'Read-Only recommended' è un avviso morbido e opzionale; [isWriteProtected](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/protectionmanager/#isWriteProtected--) e [isEncrypted](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/protectionmanager/#isEncrypted--) indicano restrizioni effettive di scrittura o lettura che dipendono da password o crittografia.