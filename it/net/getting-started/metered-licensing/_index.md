---
title: Licenza a consumo
type: docs
weight: 90
url: /it/net/metered-licensing/
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
- .NET
- C#
- Aspose.Slides
description: "Scopri come la licenza a consumo di Aspose.Slides per .NET ti consente di elaborare file PowerPoint e OpenDocument in modo flessibile, pagando solo per ciò che utilizzi."
---
## **Introduzione**

La licenza a consumo è un meccanismo di licenza che può essere utilizzato accanto ai metodi di licenza esistenti. Se desideri essere fatturato in base all'utilizzo delle funzionalità dell'API Aspose.Slides, scegli la licenza a consumo.

## **Applicare le chiavi a consumo**

Quando acquisti una licenza a consumo, ricevi le chiavi (e non un file di licenza). Questa chiave a consumo può essere applicata utilizzando la classe [Metered](https://reference.aspose.com/slides/it/net/aspose.slides/metered/) fornita da Aspose per le operazioni di misurazione. Per ulteriori dettagli, consulta le [FAQ sulla licenza a consumo](https://purchase.aspose.com/faqs/licensing/metered).

1. Crea un'istanza della classe [Metered](https://reference.aspose.com/slides/it/net/aspose.slides/metered/).
1. Passa le tue chiavi pubbliche e private al metodo [SetMeteredKey](https://reference.aspose.com/slides/it/net/aspose.slides/metered/setmeteredkey/).
1. Esegui qualche elaborazione (esegui attività).
1. Chiama il metodo [GetConsumptionQuantity](https://reference.aspose.com/slides/it/net/aspose.slides/metered/getconsumptionquantity/) della classe `Metered`.

Dovresti vedere la quantità di richieste API che hai consumato finora.

Questo esempio di codice mostra come utilizzare la licenza a consumo:

```cs
// Crea un'istanza della classe Metered
Aspose.Slides.Metered metered = new Aspose.Slides.Metered();

// Passa le chiavi pubblica e privata all'oggetto Metered
metered.SetMeteredKey("<valid public key>", "<valid private key>");

// Ottiene la quantità di dati a consumo prima della chiamata API
decimal amountBefore = Aspose.Slides.Metered.GetConsumptionQuantity();
Console.WriteLine("Amount consumed before: " + amountBefore.ToString());

// Esegui qualcosa con l'API Aspose.Slides qui
// ...

// Ottiene la quantità di dati a consumo dopo la chiamata API
decimal amountAfter = Aspose.Slides.Metered.GetConsumptionQuantity();
Console.WriteLine("Amount consumed after: " + amountAfter.ToString());
```

{{% alert color="warning" title="NOTE"  %}} 

Per utilizzare la licenza a consumo, è necessaria una connessione Internet stabile perché il meccanismo di licenza utilizza Internet per interagire costantemente con i nostri servizi e eseguire calcoli.

{{% /alert %}} 

## **FAQ**

**Posso utilizzare una licenza a consumo insieme a una licenza normale (perpetua o temporanea) nella stessa applicazione?**

Sì. La licenza a consumo è un meccanismo di licenza aggiuntivo che può essere utilizzato accanto ai [metodi di licenza](/slides/it/net/licensing/) esistenti. Decidi quale meccanismo applicare all'avvio dell'applicazione.

**Cosa conta esattamente come consumo con una licenza a consumo: operazioni o file?**

Viene conteggiato l'uso dell'API, cioè il numero di richieste o operazioni. Puoi ottenere il consumo corrente tramite i [metodi di tracciamento del consumo](https://reference.aspose.com/slides/it/net/aspose.slides/metered/).

**La licenza a consumo è adatta per microservizi e ambienti serverless in cui le istanze si riavviano frequentemente?**

Sì. Poiché la contabilizzazione avviene a livello di chiamata API, gli scenari con frequenti avvii a freddo sono compatibili, a condizione che sia presente un accesso di rete stabile per i calcoli a consumo.

**Le funzionalità della libreria differiscono quando si utilizza una licenza a consumo rispetto a una licenza perpetua?**

No. Si tratta solo del meccanismo di licenza e fatturazione; le capacità del prodotto sono le stesse.

**Come si colloca la licenza a consumo rispetto alla versione di prova e alla licenza temporanea?**

La versione di prova presenta limitazioni e filigrane, la [licenza temporanea](https://purchase.aspose.com/temporary-license/) rimuove le limitazioni per 30 giorni, e la licenza a consumo rimuove le limitazioni e addebita in base all'uso effettivo.

**Posso controllare il budget reagendo automaticamente quando viene superata una soglia di consumo?**

Sì. Una pratica comune è leggere periodicamente il consumo corrente tramite i [metodi di tracciamento](https://reference.aspose.com/slides/it/net/aspose.slides/metered/) e implementare i propri limiti o avvisi a livello dell'applicazione o del monitoraggio.