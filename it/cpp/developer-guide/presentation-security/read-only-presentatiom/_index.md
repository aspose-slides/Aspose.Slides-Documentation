---
title: Salva Presentazioni in Modalità Sola Lettura Utilizzando C++
linktitle: Presentazione Sola Lettura
type: docs
weight: 30
url: /it/cpp/read-only-presentation/
keywords:
- solo lettura
- proteggere presentazione
- impedire modifica
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Carica e salva file PowerPoint (PPT, PPTX) in modalità sola lettura con Aspose.Slides per C++, offrendo anteprime precise delle diapositive senza modificare le tue presentazioni."
---
## **Introduzione**

In PowerPoint 2019, Microsoft ha introdotto l'impostazione **Always Open Read-Only** come una delle opzioni che gli utenti possono utilizzare per proteggere le proprie presentazioni. Potresti voler utilizzare questa impostazione Read-Only per proteggere una presentazione quando

- Vuoi evitare modifiche accidentali e mantenere al sicuro il contenuto della tua presentazione. 
- Vuoi avvisare le persone che la presentazione fornita è la versione finale. 

Dopo aver selezionato l'opzione **Always Open Read-Only** per una presentazione, quando gli utenti aprono la presentazione, vedono la raccomandazione **Read-Only** e possono vedere un messaggio del tipo: *Per evitare modifiche accidentali, l'autore ha impostato questo file per l'apertura in sola lettura.*

La raccomandazione **Read-Only** è un deterrente semplice ma efficace che scoraggia la modifica perché gli utenti devono eseguire un'operazione per rimuoverla prima di poter modificare una presentazione. Se non vuoi che gli utenti apportino modifiche a una presentazione e desideri comunicarglielo in modo cortese, la raccomandazione **Read-Only** può essere una buona opzione per te. 

> Se una presentazione con protezione **Read-Only** viene aperta in una versione più vecchia di Microsoft PowerPoint—che non supporta la funzione introdotta di recente—la raccomandazione **Read-Only** viene ignorata (la presentazione viene aperta normalmente).

## **Applica la modalità Read-Only**

Aspose.Slides for C++ consente di impostare una presentazione su **Read-Only**, il che significa che gli utenti (dopo aver aperto la presentazione) vedono la raccomandazione **Read-Only**. Questo esempio di codice mostra come impostare una presentazione su **Read-Only** in C++ utilizzando Aspose.Slides:

``` cpp
auto pres = System::MakeObject<Presentation>();
pres->get_ProtectionManager()->set_ReadOnlyRecommended(true);
pres->Save(u"ReadOnlyPresentation.pptx", SaveFormat::Pptx);
```

{{% alert color="primary" %}} 

**Nota**: La raccomandazione **Read-Only** è pensata semplicemente per scoraggiare la modifica o impedire agli utenti di apportare modifiche accidentali a una presentazione PowerPoint. Se una persona motivata—che sa quello che sta facendo—decide di modificare la tua presentazione, può rimuovere facilmente l'impostazione Read-Only. Se hai realmente bisogno di impedire modifiche non autorizzate, è preferibile utilizzare [protezioni più rigorose che includono crittografia e password](https://docs.aspose.com/slides/it/cpp/password-protected-presentation/). 

{{% /alert %}} 

## **FAQ**

**Qual è la differenza tra 'Read-Only recommended' e la protezione completa con password?**

'Read-Only recommended' visualizza solo un suggerimento per aprire il file in modalità sola lettura ed è facile da bypassare. [Protezione con password](/slides/it/cpp/password-protected-presentation/) limita effettivamente l'apertura o la modifica ed è appropriata quando sono necessari controlli di sicurezza reali.

**È possibile combinare 'Read-Only recommended' con filigrane per scoraggiare ulteriormente le modifiche?**

Sì. La raccomandazione può essere associata a [filigrane](/slides/it/cpp/watermark/) come deterrente visivo; sono meccanismi separati e funzionano bene insieme.

**Una macro o uno strumento esterno può comunque modificare il file quando la raccomandazione è attiva?**

Sì. La raccomandazione non blocca le modifiche programmatiche. Per impedire modifiche automatiche, utilizza [password e crittografia](/slides/it/cpp/password-protected-presentation/).

**Come si relaziona 'Read-Only recommended' con i flag 'is encrypted' e 'is write protected'?**

Sono segnali differenti. 'Read-Only recommended' è un avviso morbido e opzionale; [get_IsWriteProtected](https://reference.aspose.com/slides/it/cpp/aspose.slides/protectionmanager/get_iswriteprotected/) e [get_IsEncrypted](https://reference.aspose.com/slides/it/cpp/aspose.slides/protectionmanager/get_isencrypted/) indicano restrizioni reali di scrittura o lettura che dipendono da password o crittografia.