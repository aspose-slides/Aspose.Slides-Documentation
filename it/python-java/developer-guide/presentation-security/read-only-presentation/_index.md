---
title: Salva le presentazioni in modalità sola lettura usando Python
linktitle: Presentazione Sola Lettura
type: docs
weight: 30
url: /it/python-java/read-only-presentation/
keywords:
- sola lettura
- proteggere la presentazione
- impedire modifiche
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Carica e salva file PowerPoint (PPT, PPTX) in modalità sola lettura con Aspose.Slides per Python via Java, offrendo anteprime precise delle slide senza modificare le tue presentazioni."
---
## **Introduzione**

In PowerPoint 2019, Microsoft ha introdotto l'impostazione **Always Open Read-Only** come una delle opzioni che gli utenti possono utilizzare per proteggere le proprie presentazioni. Potresti voler usare questa impostazione di sola lettura per proteggere una presentazione quando:

- Vuoi evitare modifiche accidentali e mantenere il contenuto della tua presentazione al sicuro. 
- Vuoi avvisare le persone che la presentazione fornita è la versione finale. 

Dopo aver selezionato l'opzione **Always Open Read-Only** per una presentazione, quando gli utenti aprono la presentazione, vedono la raccomandazione **Read-Only** e possono visualizzare un messaggio del tipo: *Per evitare modifiche accidentali, l'autore ha impostato questo file per aprirlo in modalità sola lettura.*

La raccomandazione **Read-Only** è un deterrente semplice ma efficace che scoraggia la modifica, poiché gli utenti devono eseguire un'operazione per rimuoverla prima di poter modificare una presentazione. Se non vuoi che gli utenti apportino modifiche a una presentazione e desideri comunicarlo in modo cortese, la raccomandazione **Read-Only** può essere una buona opzione per te. 

> Se una presentazione con la protezione **Read-Only** viene aperta in una versione più vecchia di Microsoft PowerPoint, che non supporta la funzione introdotta di recente, la raccomandazione **Read-Only** viene ignorata (la presentazione viene aperta normalmente).

## **Applica modalità Sola lettura**

Aspose.Slides for Python via Java ti consente di impostare una presentazione su **Read-Only**, il che significa che gli utenti (dopo aver aperto la presentazione) vedono la raccomandazione **Read-Only**. Questo codice di esempio mostra come impostare una presentazione su **Read-Only** in Python utilizzando Aspose.Slides:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getProtectionManager().setReadOnlyRecommended(True)
    presentation.save("ReadOnlyPresentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 

La raccomandazione **Read-Only** è semplicemente pensata per scoraggiare le modifiche o impedire agli utenti di apportare cambiamenti accidentali a una presentazione PowerPoint. Se una persona motivata—che sa quello che sta facendo—decide di modificare la tua presentazione, può facilmente rimuovere l'impostazione Read-Only. Se hai davvero bisogno di impedire modifiche non autorizzate, è preferibile utilizzare [protezioni più rigorose che coinvolgono crittografia e password](/slides/it/python-java/password-protected-presentation/). 

{{% /alert %}} 

## **FAQ**

**Qual è la differenza tra 'Read-Only recommended' e la protezione completa con password?**

'Read-Only recommended' visualizza solo un suggerimento per aprire il file in modalità sola lettura ed è facile da aggirare. [Protezione con password](/slides/it/python-java/password-protected-presentation/) restringe effettivamente l'apertura o la modifica ed è appropriata quando sono necessari controlli di sicurezza reali.

**Può 'Read-Only recommended' essere combinato con filigrane per scoraggiare ulteriormente le modifiche?**

Sì. La raccomandazione può essere accoppiata con [filigrane](/slides/it/python-java/watermark/) come deterrente visuale; sono meccanismi separati e funzionano bene insieme.

**Una macro o uno strumento esterno può ancora modificare il file quando la raccomandazione è attiva?**

Sì. La raccomandazione non blocca le modifiche programmatiche. Per impedire modifiche automatiche, usa [password e crittografia](/slides/it/python-java/password-protected-presentation/).

**Come si relaziona 'Read-Only recommended' ai metodi [isEncrypted](https://reference.aspose.com/slides/it/python-java/aspose.slides/protectionmanager/#isEncrypted) e [isWriteProtected](https://reference.aspose.com/slides/it/python-java/aspose.slides/protectionmanager/#isWriteProtected)?**

Sono segnali differenti. 'Read-Only recommended' è un avviso lieve e opzionale; [isWriteProtected](https://reference.aspose.com/slides/it/python-java/aspose.slides/protectionmanager/#isWriteProtected) e [isEncrypted](https://reference.aspose.com/slides/it/python-java/aspose.slides/protectionmanager/#isEncrypted) indicano restrizioni effettive di scrittura o lettura che dipendono da password o crittografia.