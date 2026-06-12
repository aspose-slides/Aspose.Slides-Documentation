---
title: Recupera e Aggiorna le Informazioni della Presentazione in .NET
linktitle: Informazioni sulla Presentazione
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
- modificare proprietà
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
description: "Esplora diapositive, struttura e metadati nelle presentazioni PowerPoint e OpenDocument usando .NET per ottenere approfondimenti più rapidi e audit di contenuto più intelligenti."
---
## **Panoramica**

Questo articolo mostra come ispezionare le informazioni di una presentazione in Aspose.Slides. Spiega come determinare il formato corrente di una presentazione senza caricare l'intero file, leggere le sue proprietà del documento e aggiornare tali proprietà quando necessario.

Gli esempi si basano sulle API [PresentationInfo](https://reference.aspose.com/slides/it/net/aspose.slides/presentationinfo/) e [DocumentProperties](https://reference.aspose.com/slides/it/net/aspose.slides/documentproperties/) e dimostrano operazioni tipiche per lavorare con i metadati della presentazione.

## **Verificare il formato di una presentazione**

Prima di lavorare su una presentazione, potresti voler scoprire in quale formato (PPT, PPTX, ODP e altri) la presentazione è attualmente.

Puoi verificare il formato di una presentazione senza caricarla. Vedi questo codice C#:

```c#
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
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
IDocumentProperties props = info.ReadDocumentProperties();
Console.WriteLine(props.CreatedTime);
Console.WriteLine(props.Subject);
Console.WriteLine(props.Title);
// ...
```

Potresti voler vedere le [proprietà della classe DocumentProperties](https://reference.aspose.com/slides/it/net/aspose.slides/documentproperties/#properties).

## **Aggiornare le proprietà della presentazione**

Aspose.Slides fornisce il metodo [PresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/it/net/aspose.slides/presentationinfo/methods/updatedocumentproperties) che consente di apportare modifiche alle proprietà della presentazione.

Supponiamo di avere una presentazione PowerPoint con le proprietà del documento mostrate di seguito.

![Proprietà originali del documento della presentazione PowerPoint](input_properties.png)

Questo esempio di codice ti mostra come modificare alcune proprietà della presentazione:

```c#
string fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo(fileName);

IDocumentProperties properties = info.ReadDocumentProperties();
properties.Title = "My title";
properties.LastSavedTime = DateTime.Now;

info.UpdateDocumentProperties(properties);
info.WriteBindedPresentation(fileName);
```

Il risultato della modifica delle proprietà del documento è mostrato di seguito.

![Proprietà del documento modificate della presentazione PowerPoint](output_properties.png)

## **Link utili**

Per ottenere maggiori informazioni su una presentazione e sui suoi attributi di sicurezza, potresti trovare utili i seguenti collegamenti:

- [Verifica se una presentazione è crittografata](https://docs.aspose.com/slides/it/net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Verifica se una presentazione è protetta da scrittura (sola lettura)](https://docs.aspose.com/slides/it/net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Verifica se una presentazione è protetta da password prima di caricarla](https://docs.aspose.com/slides/it/net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Confermare la password usata per proteggere una presentazione](https://docs.aspose.com/slides/it/net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **FAQ**

**Come posso verificare se i font sono incorporati e quali sono?**

Cerca le [informazioni sui font incorporati](https://reference.aspose.com/slides/it/net/aspose.slides/fontsmanager/getembeddedfonts/) a livello di presentazione, quindi confronta tali voci con l'insieme dei [font effettivamente utilizzati nel contenuto](https://reference.aspose.com/slides/it/net/aspose.slides/fontsmanager/getfonts/) per identificare quali font sono critici per il rendering.

**Come posso capire rapidamente se il file contiene diapositive nascoste e quante?**

Itera attraverso la [collezione di diapositive](https://reference.aspose.com/slides/it/net/aspose.slides/slidecollection/) e ispeziona il [flag di visibilità](https://reference.aspose.com/slides/it/net/aspose.slides/slide/hidden/) di ogni diapositiva.

**Posso rilevare se vengono usate dimensioni e orientamento della diapositiva personalizzati e se differiscono dalle impostazioni predefinite?**

Sì. Confronta le attuali [dimensioni della diapositiva](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/slidesize/) e orientamento con i preset standard; ciò aiuta a prevedere il comportamento per la stampa e l'esportazione.

**Esiste un modo rapido per verificare se i grafici fanno riferimento a fonti di dati esterne?**

Sì. Scorri tutti i [grafici](https://reference.aspose.com/slides/it/net/aspose.slides.charts/chart/), controlla la loro [fonte dati](https://reference.aspose.com/slides/it/net/aspose.slides.charts/chartdata/datasourcetype/) e annota se i dati sono interni o basati su collegamenti, includendo eventuali collegamenti interrotti.

**Come posso valutare le diapositive 'pesanti' che potrebbero rallentare il rendering o l'esportazione PDF?**

Per ogni diapositiva, conta gli oggetti e cerca immagini di grandi dimensioni, trasparenze, ombre, animazioni e contenuti multimediali; assegna un punteggio di complessità approssimativo per segnalare eventuali punti critici di prestazioni.