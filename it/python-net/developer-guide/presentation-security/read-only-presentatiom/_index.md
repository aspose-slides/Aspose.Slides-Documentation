---
title: Salva le presentazioni in modalità sola lettura usando Python
linktitle: Presentazione sola lettura
type: docs
weight: 30
url: /it/python-net/read-only-presentation/
keywords:
- sola lettura
- proteggere la presentazione
- impedire modifiche
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Carica e salva file PowerPoint (PPT, PPTX) in modalità sola lettura con Aspose.Slides per Python tramite .NET, offrendo anteprime precise delle diapositive senza modificare le tue presentazioni."
---
## **Introduzione**

In PowerPoint 2019, Microsoft ha introdotto l'impostazione **Always Open Read-Only** come una delle opzioni che gli utenti possono usare per proteggere le proprie presentazioni. Potresti voler usare questa impostazione Read-Only per proteggere una presentazione quando

- Vuoi impedire modifiche accidentali e mantenere il contenuto della tua presentazione al sicuro. 
- Vuoi avvisare le persone che la presentazione fornita è la versione finale. 

Dopo aver selezionato l'opzione **Always Open Read-Only** per una presentazione, quando gli utenti la aprono vedono la raccomandazione **Read-Only** e possono vedere un messaggio del genere: *Per evitare modifiche accidentali, l'autore ha impostato questo file per l'apertura in sola lettura.*

La raccomandazione **Read-Only** è un deterrente semplice ma efficace che scoraggia la modifica perché gli utenti devono eseguire un'operazione per rimuoverla prima di poter modificare la presentazione. Se non desideri che gli utenti apportino modifiche a una presentazione e vuoi comunicarlo in modo cortese, la raccomandazione **Read-Only** può essere una buona opzione per te. 

> Se una presentazione con protezione **Read-Only** viene aperta in una versione più vecchia di Microsoft PowerPoint—che non supporta la funzione introdotta di recente—la raccomandazione **Read-Only** viene ignorata (la presentazione viene aperta normalmente).

## **Applicare la modalità Read-Only**

Aspose.Slides for Python via .NET consente di impostare una presentazione su **Read-Only**, il che significa che gli utenti (dopo averla aperta) vedono la raccomandazione **Read-Only**. Questo esempio di codice mostra come impostare una presentazione su **Read-Only** in Python usando Aspose.Slides:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.read_only_recommended = True
    pres.save("ReadOnlyPresentation.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 

**Nota**: La raccomandazione **Read-Only** è semplicemente pensata per scoraggiare la modifica o impedire agli utenti di effettuare modifiche accidentali a una presentazione PowerPoint. Se una persona motivata—che sa cosa sta facendo—decide di modificare la tua presentazione, può facilmente rimuovere l'impostazione Read-Only. Se hai davvero bisogno di prevenire modifiche non autorizzate, è meglio utilizzare [more stringent protections that involve encryptions and passwords](https://docs.aspose.com/slides/it/python-net/password-protected-presentation/). 

{{% /alert %}} 

## **FAQ**

**Qual è la differenza tra 'Read-Only recommended' e la protezione completa con password?**

'Read-Only recommended' visualizza solo un suggerimento per aprire il file in modalità sola lettura ed è facile da aggirare. [Password protection](/slides/it/python-net/password-protected-presentation/) limita effettivamente l'apertura o la modifica ed è appropriata quando hai bisogno di controlli di sicurezza reali.

**'Read-Only recommended' può essere combinato con filigrane per scoraggiare ulteriormente le modifiche?**

Sì. La raccomandazione può essere accoppiata con [watermarks](/slides/it/python-net/watermark/) come deterrente visivo; sono meccanismi separati e funzionano bene insieme.

**Una macro o uno strumento esterno può comunque modificare il file quando la raccomandazione è abilitata?**

Sì. La raccomandazione non blocca le modifiche programmatiche. Per impedire modifiche automatiche, usa [passwords and encryption](/slides/it/python-net/password-protected-presentation/).

**Come si collega 'Read-Only recommended' ai flag 'is_encrypted' e 'is_write_protected'?**

Sono segnali diversi. 'Read-Only recommended' è un prompt morbido e opzionale; [is_write_protected](https://reference.aspose.com/slides/it/python-net/aspose.slides/protectionmanager/is_write_protected/) e [is_encrypted](https://reference.aspose.com/slides/it/python-net/aspose.slides/protectionmanager/is_encrypted/) indicano restrizioni effettive di scrittura o lettura che dipendono da password o crittografia.