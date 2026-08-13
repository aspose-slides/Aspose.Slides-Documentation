---
title: Salva presentazioni in modalità sola lettura usando C++
linktitle: Presentazione in sola lettura
type: docs
weight: 30
url: /it/cpp/read-only-presentation/
keywords:
- sola lettura
- proteggere la presentazione
- impedire modifiche
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Carica e salva file PowerPoint (PPT, PPTX) in modalità sola lettura con Aspose.Slides per C++, offrendo anteprime precise delle diapositive senza alterare le tue presentazioni."
---
## **Introduzione**

In PowerPoint 2019, Microsoft ha introdotto l'impostazione **Always Open Read-Only** come una delle opzioni che gli utenti possono usare per proteggere le proprie presentazioni. Potresti voler utilizzare questa impostazione di sola lettura per proteggere una presentazione quando

- Vuoi impedire modifiche accidentali e mantenere al sicuro il contenuto della tua presentazione. 
- Vuoi avvisare le persone che la presentazione fornita è la versione finale. 

Dopo aver selezionato l'opzione **Always Open Read-Only** per una presentazione, quando gli utenti aprono la presentazione vedono il suggerimento **Read-Only** e possono vedere un messaggio in questa forma: *Per evitare modifiche accidentali, l'autore ha impostato questo file per aprirlo in modalità sola lettura.*

Il suggerimento **Read-Only** è un deterrente semplice ma efficace che scoraggia la modifica perché gli utenti devono eseguire un'operazione per rimuoverlo prima di poter modificare la presentazione. Se non vuoi che gli utenti apportino modifiche a una presentazione e desideri comunicarlo in modo educato, il suggerimento **Read-Only** può essere una buona opzione per te. 

> Se una presentazione con la protezione **Read-Only** viene aperta in una versione più vecchia di Microsoft PowerPoint—che non supporta la funzione introdotta di recente—il suggerimento **Read-Only** viene ignorato (la presentazione viene aperta normalmente).

## **Applicare la modalità di sola lettura**

Aspose.Slides per C++ consente di impostare una presentazione su **Read-Only**, il che significa che gli utenti (dopo aver aperto la presentazione) vedono il suggerimento **Read-Only**. Questo esempio di codice mostra come impostare una presentazione su **Read-Only** in C++ usando Aspose.Slides:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
pres->get_ProtectionManager()->set_ReadOnlyRecommended(true);
pres->Save(u"ReadOnlyPresentation.pptx", SaveFormat::Pptx);
```

{{% alert color="info" %}} 

**Nota**: Il suggerimento **Read-Only** è semplicemente pensato per scoraggiare la modifica o impedire modifiche accidentali a una presentazione PowerPoint. Se una persona motivata—che sa cosa sta facendo—decide di modificare la tua presentazione, può rimuovere facilmente l'impostazione Read-Only. Se hai davvero bisogno di impedire modifiche non autorizzate, è preferibile utilizzare [protezioni più rigorose che coinvolgono crittografie e password](https://docs.aspose.com/slides/it/cpp/password-protected-presentation/). 

{{% /alert %}} 

## **FAQ**

### In che modo 'Read-Only recommended' differisce dalla protezione completa con password?

'Read-Only recommended' mostra solo un suggerimento per aprire il file in modalità sola lettura ed è facile da aggirare. [Protezione con password](/slides/it/cpp/password-protected-presentation/) limita effettivamente l'apertura o la modifica ed è appropriata quando servono controlli di sicurezza reali.

### 'Read-Only recommended' può essere combinato con filigrane per scoraggiare ulteriormente le modifiche?

Sì. Il suggerimento può essere associato a [filigrane](/slides/it/cpp/watermark/) come deterrente visivo; sono meccanismi separati e funzionano bene insieme.

### Una macro o uno strumento esterno può comunque modificare il file quando il suggerimento è attivo?

Sì. Il suggerimento non blocca le modifiche programmatiche. Per impedire modifiche automatizzate, usa [password e crittografia](/slides/it/cpp/password-protected-presentation/).

### Come si relaziona 'Read-Only recommended' ai flag 'is encrypted' e 'is write protected'?

Sono segnali diversi. 'Read-Only recommended' è un avviso morbido e opzionale; [get_IsWriteProtected](https://reference.aspose.com/slides/it/cpp/aspose.slides/protectionmanager/get_iswriteprotected/) e [get_IsEncrypted](https://reference.aspose.com/slides/it/cpp/aspose.slides/protectionmanager/get_isencrypted/) indicano restrizioni effettive di scrittura o lettura che dipendono da password o crittografia.