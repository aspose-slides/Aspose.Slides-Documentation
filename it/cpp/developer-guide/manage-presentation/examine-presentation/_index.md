---
title: Recupera e Aggiorna le Informazioni della Presentazione in C++
linktitle: Informazioni sulla Presentazione
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
description: "Esplora diapositive, struttura e metadati nelle presentazioni PowerPoint e OpenDocument usando C++ per approfondimenti più rapidi e audit di contenuti più intelligenti."
---
## **Panoramica**

Questo articolo mostra come ispezionare le informazioni di una presentazione in Aspose.Slides. Spiega come determinare il formato corrente di una presentazione senza caricare l’intero file, leggere le sue proprietà documentali e aggiornare tali proprietà quando necessario.

Gli esempi si basano sulle API [PresentationInfo](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentationinfo/) e [DocumentProperties](https://reference.aspose.com/slides/it/cpp/aspose.slides/documentproperties/) e dimostrano le operazioni tipiche per lavorare con i metadati di una presentazione.

## **Verificare il Formato di una Presentazione**

Prima di lavorare su una presentazione, potresti voler scoprire in quale formato (PPT, PPTX, ODP e altri) si trovi al momento.

Puoi verificare il formato di una presentazione senza caricare la presentazione. Vedi questo codice C++:

``` cpp
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

## **Ottenere le Proprietà della Presentazione**

Questo codice C++ mostra come ottenere le proprietà della presentazione (informazioni sulla presentazione):

``` cpp
auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
auto props = info->ReadDocumentProperties();
Console::WriteLine(ObjectExt::ToString(props->get_CreatedTime()));
Console::WriteLine(props->get_Subject());
Console::WriteLine(props->get_Title());
// .. 
```

## **Aggiornare le Proprietà della Presentazione**

Aspose.Slides fornisce il metodo [PresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentationinfo/updatedocumentproperties/) che consente di modificare le proprietà della presentazione.

Supponiamo di avere una presentazione PowerPoint con le proprietà del documento riportate di seguito.

![Proprietà originali del documento della presentazione PowerPoint](input_properties.png)

Questo esempio di codice mostra come modificare alcune proprietà della presentazione:

```cpp
auto fileName = u"sample.pptx";

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);

auto properties = info->ReadDocumentProperties();
properties->set_Title(u"My title");
properties->set_LastSavedTime(DateTime::get_Now());

info->UpdateDocumentProperties(properties);
info->WriteBindedPresentation(fileName);
```

Il risultato della modifica delle proprietà del documento è mostrato di seguito.

![Proprietà modificate del documento della presentazione PowerPoint](output_properties.png)

## **Link Utili**

Per ottenere maggiori informazioni su una presentazione e sui suoi attributi di sicurezza, potresti trovare utili questi link:

- [Verifica se una Presentazione è Cifrata](https://docs.aspose.com/slides/it/cpp/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Verifica se una Presentazione è Protetta da Scrittura (sola lettura)](https://docs.aspose.com/slides/it/cpp/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Verifica se una Presentazione è Protetta da Password Prima di Caricarla](https://docs.aspose.com/slides/it/cpp/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Conferma la Password Usata per Proteggere una Presentazione](https://docs.aspose.com/slides/it/cpp/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **FAQ**

**Come posso verificare se i font sono incorporati e quali sono?**

Cerca le informazioni sui [font incorporati](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontsmanager/getembeddedfonts/) a livello di presentazione, quindi confronta tali voci con l’insieme dei [font effettivamente utilizzati nel contenuto](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontsmanager/getfonts/) per identificare quali font sono critici per il rendering.

**Come posso capire rapidamente se il file contiene diapositive nascoste e quante?**

Itera attraverso la [collezione di diapositive](https://reference.aspose.com/slides/it/cpp/aspose.slides/slidecollection/) e controlla il [flag di visibilità](https://reference.aspose.com/slides/it/cpp/aspose.slides/slide/get_hidden/) di ciascuna diapositiva.

**Posso rilevare se sono utilizzate dimensioni e orientamento personalizzati per le diapositive e se differiscono dai valori predefiniti?**

Sì. Confronta le [dimensioni e l’orientamento attuali della diapositiva](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/get_slidesize/) con le impostazioni standard; questo aiuta a prevedere il comportamento durante la stampa e l’esportazione.

**Esiste un modo rapido per vedere se i grafici fanno riferimento a fonti dati esterne?**

Sì. Percorri tutti i [grafici](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/chart/), verifica la loro [fonte dati](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) e annota se i dati sono interni o basati su collegamenti, includendo eventuali collegamenti interrotti.

**Come posso valutare le diapositive “pesanti” che potrebbero rallentare il rendering o l’esportazione PDF?**

Per ogni diapositiva, conta gli oggetti e cerca immagini di grandi dimensioni, trasparenze, ombre, animazioni e contenuti multimediali; assegna un punteggio di complessità approssimativo per segnalare potenziali colli di bottiglia delle prestazioni.