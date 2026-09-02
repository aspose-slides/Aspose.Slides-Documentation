---
title: Recuperare e aggiornare le informazioni di presentazione in C++
linktitle: Informazioni sulla presentazione
type: docs
weight: 30
url: /it/cpp/examine-presentation/
keywords:
- formato della presentazione
- proprietà della presentazione
- proprietà del documento
- ottenere proprietà
- leggere proprietà
- cambiare proprietà
- modificare proprietà
- aggiornare proprietà
- esaminare PPTX
- esaminare PPT
- esaminare ODP
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Esplora diapositive, struttura e metadati in presentazioni PowerPoint e OpenDocument usando C++ per ottenere rapidamente informazioni e audit più intelligenti dei contenuti."
---
## **Panoramica**

Questo articolo mostra come ispezionare le informazioni di presentazione in Aspose.Slides. Spiega come determinare il formato corrente di una presentazione senza caricare il file completo, leggere le sue proprietà del documento e aggiornare tali proprietà quando necessario.

Gli esempi si basano sulle API [PresentationInfo](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentationinfo/) e [DocumentProperties](https://reference.aspose.com/slides/it/cpp/aspose.slides/documentproperties/) e dimostrano operazioni tipiche per lavorare con i metadati delle presentazioni.

## **Verifica il formato di una presentazione**

Prima di lavorare su una presentazione, potresti voler scoprire in quale formato (PPT, PPTX, ODP e altri) è attualmente.

Puoi verificare il formato di una presentazione senza caricare la presentazione. Vedi questo codice C++:

``` cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
// PPTX
Console::WriteLine(ObjectExt::ToString(info->get_LoadFormat()));

auto info2 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.ppt");
// PPT
Console::WriteLine(ObjectExt::ToString(info2->get_LoadFormat()));

auto info3 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.odp");
// ODP
Console::WriteLine(ObjectExt::ToString(info3->get_LoadFormat()));
```

## **Ottieni le proprietà della presentazione**

Questo codice C++ mostra come ottenere le proprietà della presentazione (informazioni sulla presentazione):

``` cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
auto props = info->ReadDocumentProperties();
Console::WriteLine(ObjectExt::ToString(props->get_CreatedTime()));
Console::WriteLine(props->get_Subject());
Console::WriteLine(props->get_Title());
// .. 
```

## **Aggiorna le proprietà della presentazione**

Aspose.Slides fornisce il metodo [PresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentationinfo/updatedocumentproperties/) che consente di modificare le proprietà della presentazione.

Supponiamo di avere una presentazione PowerPoint con le proprietà del documento mostrate di seguito.

![Proprietà originali del documento della presentazione PowerPoint](input_properties.png)

Questo esempio di codice mostra come modificare alcune proprietà della presentazione:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/date_time.h>
using namespace Aspose::Slides;
using namespace System;

auto fileName = u"sample.pptx";

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);

auto properties = info->ReadDocumentProperties();
properties->set_Title(u"My title");
properties->set_LastSavedTime(DateTime::get_Now());

info->UpdateDocumentProperties(properties);
info->WriteBindedPresentation(fileName);
```

I risultati della modifica delle proprietà del documento sono mostrati di seguito.

![Proprietà modificate del documento della presentazione PowerPoint](output_properties.png)

## **Link utili**

Per ottenere ulteriori informazioni su una presentazione e i suoi attributi di sicurezza, potresti trovare utili questi collegamenti:

- [Presentazioni protette da password](/slides/it/cpp/password-protected-presentation/)
- [Presentazioni protette in scrittura](/slides/it/cpp/write-protected-presentation/)

## **FAQ**

**Come posso verificare se i font sono incorporati e quali sono?**

Cerca le informazioni sui font incorporati a livello di presentazione, quindi confronta quelle voci con l'insieme dei font effettivamente utilizzati nel contenuto per identificare quali sono critici per il rendering.

**Come posso capire rapidamente se il file contiene diapositive nascoste e quante?**

Itera attraverso la [slide collection](https://reference.aspose.com/slides/it/cpp/aspose.slides/slidecollection/) e ispeziona il flag di visibilità di ciascuna diapositiva tramite [visibility flag](https://reference.aspose.com/slides/it/cpp/aspose.slides/slide/get_hidden/).

**Posso rilevare se vengono usate dimensioni e orientamento personalizzati delle diapositive e se differiscono dai valori predefiniti?**

Sì. Confronta la [slide size and orientation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/get_slidesize/) attuali con i preset standard; questo aiuta a prevedere il comportamento per stampa ed esportazione.

**Esiste un modo rapido per verificare se i grafici fanno riferimento a fonti dati esterne?**

Sì. Scorri tutti i [charts](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/chart/), controlla il loro [data source](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) e nota se è interno o basato su collegamento, inclusi eventuali collegamenti interrotti.

**Come posso valutare le diapositive “pesanti” che potrebbero rallentare il rendering o l'esportazione PDF?**

Per ogni diapositiva, conta gli oggetti e cerca immagini grandi, trasparenze, ombre, animazioni e contenuti multimediali; assegna un punteggio di complessità approssimativo per evidenziare potenziali colli di bottiglia delle prestazioni.