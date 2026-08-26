---
title: Recupera e Aggiorna le Informazioni della Presentazione in JavaScript
linktitle: Informazioni sulla Presentazione
type: docs
weight: 30
url: /it/nodejs-java/examine-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Esplora diapositive, struttura e metadati in presentazioni PowerPoint e OpenDocument usando JavaScript per ottenere rapidamente approfondimenti e audit dei contenuti più intelligenti."
---
## **Panoramica**

Questo articolo mostra come ispezionare le informazioni di una presentazione in Aspose.Slides. Spiega come determinare il formato corrente di una presentazione senza caricare l’intero file, leggere le sue proprietà del documento e aggiornare tali proprietà quando necessario.

Gli esempi si basano sulle API [PresentationInfo](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationinfo/) e [DocumentProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/documentproperties/) e dimostrano le operazioni tipiche per lavorare con i metadati della presentazione.

## **Verifica il formato di una presentazione**

Prima di lavorare su una presentazione, potresti voler scoprire in quale formato (PPT, PPTX, ODP e altri) si trova attualmente la presentazione.

Puoi verificare il formato di una presentazione senza caricarla. Vedi questo codice JavaScript:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
console.log(info.getLoadFormat());// PPTX
var info2 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
console.log(info2.getLoadFormat());// PPT
var info3 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.odp");
console.log(info3.getLoadFormat());// ODP
```

## **Ottieni le proprietà della presentazione**

Questo codice JavaScript mostra come ottenere le proprietà della presentazione (informazioni sulla presentazione):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
var props = info.readDocumentProperties();
console.log(props.getCreatedTime());
console.log(props.getSubject());
console.log(props.getTitle());
// ..
```

Potresti voler vedere le proprietà nella classe [DocumentProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/documentproperties/#DocumentProperties--) .

## **Aggiorna le proprietà della presentazione**

Aspose.Slides fornisce il metodo [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) che consente di apportare modifiche alle proprietà della presentazione.

Supponiamo di avere una presentazione PowerPoint con le proprietà del documento mostrate di seguito.

![Proprietà originali del documento della presentazione PowerPoint](input_properties.png)

Questo esempio di codice mostra come modificare alcune proprietà della presentazione:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let fileName = "sample.pptx";

let info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(fileName);

let properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(java.newInstanceSync("java.util.Date"));

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

I risultati della modifica delle proprietà del documento sono mostrati di seguito.

![Proprietà modificate del documento della presentazione PowerPoint](output_properties.png)

## **Link utili**

Per ottenere maggiori informazioni su una presentazione e i suoi attributi di sicurezza, potresti trovare utili questi collegamenti:

- [Proteggi con password le presentazioni](/slides/it/nodejs-java/password-protected-presentation/)
- [Proteggi le presentazioni da scrittura](/slides/it/nodejs-java/write-protected-presentation/)

## **FAQ**

**Come posso verificare se i font sono incorporati e quali sono?**

Cerca le [informazioni sui font incorporati](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) a livello di presentazione, quindi confronta tali voci con l'insieme dei [font effettivamente usati nel contenuto](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontsmanager/getfonts/) per identificare quali font sono fondamentali per il rendering.

**Come posso capire rapidamente se il file contiene diapositive nascoste e quante?**

Itera attraverso la [collezione di diapositive](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slidecollection/) e ispeziona la [bandiera di visibilità](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slide/gethidden/) di ciascuna diapositiva.

**Posso rilevare se vengono usate dimensioni e orientamento personalizzati della diapositiva e se differiscono dalle impostazioni predefinite?**

Sì. Confronta la [dimensione della diapositiva](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/getslidesize/) e l'orientamento corrente con le impostazioni standard; questo aiuta a prevedere il comportamento per la stampa e l'esportazione.

**Esiste un modo rapido per vedere se i grafici fanno riferimento a sorgenti di dati esterne?**

Sì. Scorri tutti i [grafici](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chart/), controlla la loro [sorgente dati](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdata/getdatasourcetype/), e nota se i dati sono interni o basati su collegamenti, includendo eventuali link interrotti.

**Come posso valutare le diapositive 'pesanti' che potrebbero rallentare il rendering o l'esportazione PDF?**

Per ogni diapositiva, conta gli oggetti e cerca immagini di grandi dimensioni, trasparenze, ombre, animazioni e contenuti multimediali; assegna un punteggio di complessità approssimativo per evidenziare potenziali colli di bottiglia delle prestazioni.