---
title: Recupera e aggiorna le informazioni della presentazione in JavaScript
linktitle: Informazioni sulla presentazione
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
description: "Esplora diapositive, struttura e metadati nelle presentazioni PowerPoint e OpenDocument usando JavaScript per ottenere insight più rapidi e audit dei contenuti più intelligenti."
---
## **Panoramica**

Questo articolo mostra come ispezionare le informazioni di una presentazione in Aspose.Slides. Spiega come determinare il formato corrente di una presentazione senza caricare l’intero file, leggere le sue proprietà del documento e aggiornare tali proprietà quando necessario.

Gli esempi sono basati sulle API [PresentationInfo](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationinfo/) e [DocumentProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/documentproperties/) e dimostrano operazioni tipiche per lavorare con i metadati delle presentazioni.

## **Verifica il formato di una presentazione**

Prima di lavorare su una presentazione, potresti voler scoprire in quale formato (PPT, PPTX, ODP e altri) si trova al momento.

Puoi verificare il formato di una presentazione senza caricarla. Vedi questo codice JavaScript:

```javascript
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
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
var props = info.readDocumentProperties();
console.log(props.getCreatedTime());
console.log(props.getSubject());
console.log(props.getTitle());
// ...
```

Potresti voler vedere le [proprietà nella classe DocumentProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/documentproperties/#DocumentProperties--) .

## **Aggiorna le proprietà della presentazione**

Aspose.Slides fornisce il metodo [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) che consente di apportare modifiche alle proprietà della presentazione.

Supponiamo di avere una presentazione PowerPoint con le proprietà del documento mostrate di seguito.

![Proprietà originali del documento della presentazione PowerPoint](input_properties.png)

Questo esempio di codice mostra come modificare alcune proprietà della presentazione:

```javascript
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

Per ottenere ulteriori informazioni su una presentazione e i suoi attributi di sicurezza, potresti trovare utili questi link:

- [Verifica se una presentazione è crittografata](https://docs.aspose.com/slides/it/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Verifica se una presentazione è protetta da scrittura (sola lettura)](https://docs.aspose.com/slides/it/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Verifica se una presentazione è protetta da password prima di caricarla](https://docs.aspose.com/slides/it/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Conferma la password usata per proteggere una presentazione](https://docs.aspose.com/slides/it/nodejs-java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **FAQ**

**Come posso verificare se i caratteri sono incorporati e quali sono?**

Cerca le informazioni sui [font incorporati](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) a livello di presentazione, quindi confronta tali voci con l’insieme dei [font effettivamente utilizzati nei contenuti](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontsmanager/getfonts/) per identificare quali caratteri siano critici per il rendering.

**Come posso capire rapidamente se il file contiene diapositive nascoste e quante?**

Itera attraverso la [collezione di diapositive](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slidecollection/) e ispeziona il [flag di visibilità](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slide/gethidden/) di ciascuna diapositiva.

**Posso rilevare se viene usata una dimensione e un orientamento personalizzati della diapositiva e se differiscono dai valori predefiniti?**

Sì. Confronta la [dimensione attuale della diapositiva](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/getslidesize/) e l’orientamento con le impostazioni standard; questo aiuta a prevedere il comportamento in stampa ed esportazione.

**Esiste un modo rapido per vedere se i grafici fanno riferimento a sorgenti dati esterne?**

Sì. Scorri tutti i [grafici](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chart/), controlla la loro [sorgente dati](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) e verifica se i dati sono interni o basati su collegamenti, inclusi eventuali link interrotti.

**Come posso valutare le diapositive "pesanti" che potrebbero rallentare il rendering o l’esportazione in PDF?**

Per ogni diapositiva, conta gli oggetti e cerca immagini di grandi dimensioni, trasparenze, ombre, animazioni e contenuti multimediali; assegna un punteggio di complessità approssimativo per segnalare potenziali colli di bottiglia di prestazioni.