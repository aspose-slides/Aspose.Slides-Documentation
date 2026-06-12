---
title: Salva le presentazioni in modalità sola lettura in .NET
linktitle: Presentazione Sola Lettura
type: docs
weight: 30
url: /it/net/read-only-presentation/
keywords:
- sola lettura
- proteggere presentazione
- impedire modifiche
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Carica e salva file PowerPoint (PPT, PPTX) in modalità sola lettura con Aspose.Slides per .NET, offrendo anteprime precise delle diapositive senza alterare le tue presentazioni."
---
## **Introduzione**

In PowerPoint 2019, Microsoft ha introdotto l'impostazione **Always Open Read-Only** come una delle opzioni che gli utenti possono utilizzare per proteggere le proprie presentazioni. Potresti voler utilizzare questa impostazione Read-Only per proteggere una presentazione quando

- Desideri impedire modifiche accidentali e mantenere il contenuto della tua presentazione sicuro.
- Vuoi avvisare le persone che la presentazione fornita è la versione finale.

Dopo aver selezionato l'opzione **Always Open Read-Only** per una presentazione, quando gli utenti aprono la presentazione vedono la raccomandazione **Read-Only** e potrebbero visualizzare un messaggio in questa forma: *To prevent accidental changes, the author has set this file to open as read-only.*

La raccomandazione Read-Only è un deterrente semplice ma efficace che scoraggia la modifica perché gli utenti devono eseguire un'operazione per rimuoverla prima di poter modificare una presentazione. Se non desideri che gli utenti apportino modifiche a una presentazione e vuoi comunicarlo in modo educato, la raccomandazione Read-Only può essere una buona opzione per te. 

> Se una presentazione con la protezione **Read-Only** viene aperta in una versione più vecchia di Microsoft PowerPoint—che non supporta la funzione introdotta di recente—la raccomandazione **Read-Only** viene ignorata (la presentazione viene aperta normalmente).

## **Applica Modalità Read-Only**

Aspose.Slides per .NET consente di impostare una presentazione su **Read-Only**, il che significa che gli utenti (dopo aver aperto la presentazione) vedono la raccomandazione **Read-Only**. Questo esempio di codice mostra come impostare una presentazione su **Read-Only** in C# usando Aspose.Slides:

```c#
using (Presentation pres = new Presentation())
{
    pres.ProtectionManager.ReadOnlyRecommended = true;
    pres.Save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}} 

**Nota**: La raccomandazione **Read-Only** è semplicemente destinata a scoraggiare la modifica o a impedire agli utenti di apportare modifiche accidentali a una presentazione PowerPoint. Se una persona motivata—che sa quello che sta facendo—decide di modificare la tua presentazione, può rimuovere facilmente l'impostazione Read-Only. Se hai davvero bisogno di impedire modifiche non autorizzate, è meglio utilizzare [protezioni più rigorose che coinvolgono crittografie e password](https://docs.aspose.com/slides/it/net/password-protected-presentation/). 

{{% /alert %}} 

## **FAQ**

**In che modo 'Read-Only recommended' differisce dalla protezione con password completa?**

'Read-Only recommended' mostra solo un suggerimento per aprire il file in modalità read-only ed è facile da aggirare. [Protezione con password](/slides/it/net/password-protected-presentation/) limita effettivamente l'apertura o la modifica ed è appropriata quando sono necessari controlli di sicurezza reali.

**È possibile combinare 'Read-Only recommended' con filigrane per scoraggiare ulteriormente le modifiche?**

Sì. La raccomandazione può essere associata a [filigrane](/slides/it/net/watermark/) come deterrente visivo; sono meccanismi separati e funzionano bene insieme.

**Una macro o uno strumento esterno può ancora modificare il file quando la raccomandazione è attiva?**

Sì. La raccomandazione non blocca le modifiche programmatiche. Per impedire modifiche automatizzate, utilizza [password e crittografia](/slides/it/net/password-protected-presentation/).

**Come si relaziona 'Read-Only recommended' alle flag 'IsEncrypted' e 'IsWriteProtected'?**

Sono segnali diversi. 'Read-Only recommended' è un suggerimento morbido e opzionale; [IsWriteProtected](https://reference.aspose.com/slides/it/net/aspose.slides/protectionmanager/iswriteprotected/) e [IsEncrypted](https://reference.aspose.com/slides/it/net/aspose.slides/protectionmanager/isencrypted/) indicano restrizioni reali di scrittura o lettura che dipendono da password o crittografia.