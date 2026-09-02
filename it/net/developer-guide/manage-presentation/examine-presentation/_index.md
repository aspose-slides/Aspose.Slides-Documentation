---
title: Recuperare e aggiornare le informazioni della presentazione in .NET
linktitle: Informazioni sulla presentazione
type: docs
weight: 30
url: /it/net/examine-presentation/
keywords:
- formato della presentazione
- proprietà della presentazione
- proprietà del documento
- ottenere proprietà
- leggere proprietà
- modificare proprietà
- cambiare proprietà
- aggiornare proprietà
- esaminare PPTX
- esaminare PPT
- esaminare ODP
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Esplora diapositive, struttura e metadati nelle presentazioni PowerPoint e OpenDocument usando .NET per ottenere rapidamente informazioni e audit più intelligenti dei contenuti."
---
## **Panoramica**

Questo articolo mostra come esaminare le informazioni di una presentazione in Aspose.Slides. Spiega come determinare il formato corrente di una presentazione senza caricare l'intero file, leggere le sue proprietà del documento e aggiornare tali proprietà quando necessario.

Gli esempi si basano sulle API [PresentationInfo](https://reference.aspose.com/slides/it/net/aspose.slides/presentationinfo/) e [DocumentProperties](https://reference.aspose.com/slides/it/net/aspose.slides/documentproperties/) e dimostrano operazioni tipiche per lavorare con i metadati delle presentazioni.

## **Verificare il formato di una presentazione**

Prima di lavorare su una presentazione, potresti voler scoprire in quale formato (PPT, PPTX, ODP e altri) la presentazione si trovi attualmente.

Puoi verificare il formato di una presentazione senza caricarla. Vedi questo codice C#:

```c#
using Aspose.Slides;

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
Console.WriteLine(info.LoadFormat); // PPTX

IPresentationInfo info2 = PresentationFactory.Instance.GetPresentationInfo("pres.ppt");
Console.WriteLine(info2.LoadFormat); // PPT

IPresentationInfo info3 = PresentationFactory.Instance.GetPresentationInfo("pres.odp");
Console.WriteLine(info3.LoadFormat); // ODP
```

## **Ottenere le proprietà della presentazione**

Questo codice C# ti mostra come ottenere le proprietà della presentazione (informazioni sulla presentazione):

```c#
using Aspose.Slides;

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
IDocumentProperties props = info.ReadDocumentProperties();
Console.WriteLine(props.CreatedTime);
Console.WriteLine(props.Subject);
Console.WriteLine(props.Title);
// ...
```

Potresti voler visualizzare le [proprietà nella classe DocumentProperties](https://reference.aspose.com/slides/it/net/aspose.slides/documentproperties/#properties).

## **Aggiornare le proprietà della presentazione**

Aspose.Slides fornisce il metodo [PresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/it/net/aspose.slides/presentationinfo/methods/updatedocumentproperties) che consente di apportare modifiche alle proprietà della presentazione.

Supponiamo di avere una presentazione PowerPoint con le proprietà del documento mostrate di seguito.

![Proprietà originali del documento della presentazione PowerPoint](input_properties.png)

Questo esempio di codice mostra come modificare alcune proprietà della presentazione:

```c#
using Aspose.Slides;

string fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo(fileName);

IDocumentProperties properties = info.ReadDocumentProperties();
properties.Title = "My title";
properties.LastSavedTime = DateTime.Now;

info.UpdateDocumentProperties(properties);
info.WriteBindedPresentation(fileName);
```

I risultati della modifica delle proprietà del documento sono mostrati di seguito.

![Proprietà del documento modificate della presentazione PowerPoint](output_properties.png)

## **Link utili**

Per ottenere maggiori informazioni su una presentazione e sui suoi attributi di sicurezza, potresti trovare utili questi collegamenti:

- [Proteggere le presentazioni con password](/slides/it/net/password-protected-presentation/)
- [Proteggere le presentazioni in scrittura](/slides/it/net/write-protected-presentation/)

## **FAQ**

**Come posso verificare se i font sono incorporati e quali sono?**

Cerca le [informazioni sui font incorporati](https://reference.aspose.com/slides/it/net/aspose.slides/fontsmanager/getembeddedfonts/) a livello di presentazione, quindi confronta tali voci con l'insieme dei [font effettivamente utilizzati nei contenuti](https://reference.aspose.com/slides/it/net/aspose.slides/fontsmanager/getfonts/) per identificare quali font sono critici per il rendering.

**Come posso rapidamente capire se il file ha diapositive nascoste e quante?**

Itera attraverso la [collezione di diapositive](https://reference.aspose.com/slides/it/net/aspose.slides/slidecollection/) e controlla il [segnalatore di visibilità](https://reference.aspose.com/slides/it/net/aspose.slides/slide/hidden/) di ciascuna diapositiva.

**Posso rilevare se vengono utilizzate dimensioni e orientamento personalizzati delle diapositive e se differiscono dalle impostazioni predefinite?**

Sì. Confronta l'attuale [dimensione della diapositiva](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/slidesize/) e l'orientamento con le impostazioni predefinite; questo aiuta a prevedere il comportamento per la stampa e l'esportazione.

**Esiste un modo rapido per verificare se i grafici fanno riferimento a fonti dati esterne?**

Sì. Scorri tutti i [grafici](https://reference.aspose.com/slides/it/net/aspose.slides.charts/chart/), verifica la loro [fonte dati](https://reference.aspose.com/slides/it/net/aspose.slides.charts/chartdata/datasourcetype/) e osserva se i dati sono interni o basati su collegamenti, inclusi eventuali collegamenti interrotti.

**Come posso valutare le diapositive 'pesanti' che potrebbero rallentare il rendering o l'esportazione PDF?**

Per ogni diapositiva, conta gli oggetti e cerca immagini di grandi dimensioni, trasparenza, ombre, animazioni e contenuti multimediali; assegna un punteggio di complessità approssimativo per evidenziare eventuali punti critici di prestazioni.