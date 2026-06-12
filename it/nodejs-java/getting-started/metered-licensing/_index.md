---
title: Licenza a consumo
type: docs
weight: 100
url: /it/nodejs-java/metered-licensing/
keywords:
- licenza
- licenza a consumo
- chiavi di licenza
- chiave pubblica
- chiave privata
- quantità di consumo
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Scopri come Aspose.Slides per Node.js tramite licenza a consumo Java ti consente di elaborare file PowerPoint e OpenDocument in modo flessibile, pagando solo per quello che usi."
---
## **Introduzione**

La licenza a consumo è un meccanismo di licenza che può essere utilizzato insieme ai metodi di licenza esistenti. Se desideri essere fatturato in base all'utilizzo delle funzionalità dell'API Aspose.Slides, scegli la licenza a consumo.

## **Applicare le chiavi a consumo**

Quando acquisti una licenza a consumo, ottieni delle chiavi (e non un file di licenza). Questa chiave a consumo può essere applicata utilizzando la classe [Metered](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/metered/) fornita da Aspose per le operazioni di misurazione. Per ulteriori dettagli, consulta le [FAQ Licenza a consumo](https://purchase.aspose.com/faqs/licensing/metered).

1. Crea un'istanza della classe [Metered](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/metered/).

1. Passa le chiavi pubbliche e private al metodo [setMeteredKey](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/metered/#setMeteredKey).

1. Esegui qualche elaborazione (esegui attività).

1. Chiama il metodo [getConsumptionQuantity](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/metered/#getConsumptionQuantity) della classe `Metered`.

Dovresti vedere la quantità di richieste API consumate finora.

Questo esempio di codice mostra come utilizzare la licenza a consumo:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Crea un'istanza della classe Metered
var metered = new aspose.slides.Metered();

// Passa le chiavi pubblica e privata all'oggetto Metered
metered.setMeteredKey("<valid public key>", "<valid private key>");

// Ottiene il valore della quantità consumata prima delle chiamate API
var amountBefore = aspose.slides.Metered.getConsumptionQuantity();
console.log("Amount consumed before:", amountBefore);

// Esegui qualche operazione con l'API Aspose.Slides qui
// ...

// Ottiene il valore della quantità consumata dopo le chiamate API
var amountAfter = aspose.slides.Metered.getConsumptionQuantity();
console.log("Amount consumed after:", amountAfter);
```

{{% alert color="warning" title="NOTE"  %}} 

Per utilizzare la licenza a consumo, è necessaria una connessione internet stabile perché il meccanismo di licenza utilizza internet per interagire costantemente con i nostri servizi e per eseguire i calcoli.

{{% /alert %}} 

## **FAQ**

**Posso utilizzare una licenza a consumo insieme a una licenza regolare (perpetua o temporanea) nella stessa applicazione?**

Sì. La licenza a consumo è un meccanismo di licenza aggiuntivo che può essere utilizzato insieme ai [metodi di licenza](/slides/it/nodejs-java/licensing/). Puoi scegliere quale meccanismo applicare all'avvio dell'applicazione.

**Cosa viene conteggiato esattamente come consumo con una licenza a consumo: operazioni o file?**

Viene conteggiato l'uso dell'API, ossia il numero di richieste o operazioni. È possibile ottenere il consumo corrente tramite i [metodi di tracciamento del consumo](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/metered/).

**La licenza a consumo è adatta per microservizi e ambienti serverless in cui le istanze si riavviano frequentemente?**

Sì. Poiché la contabilizzazione avviene a livello di chiamata API, gli scenari con frequenti cold start sono compatibili, a condizione che vi sia un accesso di rete stabile per i calcoli della licenza a consumo.

**Le funzionalità della libreria differiscono quando si utilizza una licenza a consumo rispetto a una licenza perpetua?**

No. Si tratta solo del meccanismo di licenza e fatturazione; le capacità del prodotto sono le stesse.

**Come si colloca la licenza a consumo rispetto alla versione di prova e alla licenza temporanea?**

La versione di prova ha limitazioni e filigrane, la [licenza temporanea](https://purchase.aspose.com/temporary-license/) rimuove le limitazioni per 30 giorni, e la licenza a consumo rimuove le limitazioni e addebita in base all'uso effettivo.

**Posso controllare il budget reagendo automaticamente quando viene superata una soglia di consumo?**

Sì. Una pratica comune è leggere periodicamente il consumo corrente tramite i [metodi di tracciamento](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/metered/) e implementare limiti o avvisi personalizzati a livello dell'applicazione o del monitoraggio.