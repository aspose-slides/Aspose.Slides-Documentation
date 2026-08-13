---
title: Salva le presentazioni in modalità sola lettura in .NET
linktitle: Presentazione sola lettura
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

In PowerPoint 2019, Microsoft ha introdotto l'impostazione **Always Open Read-Only** come una delle opzioni che gli utenti possono utilizzare per proteggere le loro presentazioni. Potresti voler usare questa impostazione di sola lettura per proteggere una presentazione quando

- Vuoi impedire modifiche accidentali e mantenere al sicuro il contenuto della tua presentazione.
- Vuoi informare le persone che la presentazione fornita è la versione finale. 

Dopo aver selezionato l'opzione **Always Open Read-Only** per una presentazione, quando gli utenti aprono la presentazione, vedono la raccomandazione **Read-Only** e possono vedere un messaggio in questa forma: *Per evitare modifiche accidentali, l'autore ha impostato questo file per aprirlo in sola lettura.*

La raccomandazione **Read-Only** è un deterrente semplice ma efficace che scoraggia la modifica perché gli utenti devono eseguire un'azione per rimuoverla prima di poter modificare una presentazione. Se non vuoi che gli utenti apportino modifiche a una presentazione e desideri comunicarlo in modo cortese, la raccomandazione **Read-Only** può essere una buona opzione per te. 

> Se una presentazione con la protezione **Read-Only** viene aperta in una versione più vecchia di Microsoft PowerPoint—che non supporta la funzione appena introdotta—la raccomandazione **Read-Only** viene ignorata (la presentazione viene aperta normalmente).

## **Applica modalità Read-Only**

Aspose.Slides per .NET ti consente di impostare una presentazione su **Read-Only**, il che significa che gli utenti (dopo aver aperto la presentazione) vedono la raccomandazione **Read-Only**. Questo codice di esempio mostra come impostare una presentazione su **Read-Only** in C# usando Aspose.Slides:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    pres.ProtectionManager.ReadOnlyRecommended = true;
    pres.Save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert color="info" %}} 

**Nota**: La raccomandazione **Read-Only** è semplicemente destinata a scoraggiare la modifica o a impedire agli utenti di apportare modifiche accidentali a una presentazione PowerPoint. Se una persona motivata—che sa quello che sta facendo—decide di modificare la tua presentazione, può rimuovere facilmente l'impostazione Read-Only. Se hai davvero bisogno di impedire modifiche non autorizzate, è meglio utilizzare [more stringent protections that involve encryptions and passwords](https://docs.aspose.com/slides/it/net/password-protected-presentation/). 

{{% /alert %}} 

## **FAQ**

### In che modo 'Read-Only recommended' è diverso dalla protezione completa con password?

'Read-Only recommended' visualizza solo un suggerimento per aprire il file in modalità di sola lettura ed è facile da aggirare. [Password protection](/slides/it/net/password-protected-presentation/) limita effettivamente l'apertura o la modifica ed è appropriato quando hai bisogno di controlli di sicurezza reali.

### È possibile combinare 'Read-Only recommended' con filigrane per scoraggiare ulteriormente le modifiche?

Sì. La raccomandazione può essere abbinata a [watermarks](/slides/it/net/watermark/) come deterrente visivo; sono meccanismi separati e funzionano bene insieme.

### Una macro o uno strumento esterno può ancora modificare il file quando la raccomandazione è abilitata?

Sì. La raccomandazione non blocca le modifiche programmatiche. Per impedire modifiche automatizzate, utilizza [passwords and encryption](/slides/it/net/password-protected-presentation/).

### Come si relaziona 'Read-Only recommended' con i flag 'IsEncrypted' e 'IsWriteProtected'?

Essi sono segnali diversi. 'Read-Only recommended' è un prompt morbido e opzionale; [IsWriteProtected](https://reference.aspose.com/slides/it/net/aspose.slides/protectionmanager/iswriteprotected/) e [IsEncrypted](https://reference.aspose.com/slides/it/net/aspose.slides/protectionmanager/isencrypted/) indicano restrizioni effettive di scrittura o lettura che dipendono da password o crittografia.