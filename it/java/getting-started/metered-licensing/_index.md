---
title: Licenza a consumo
type: docs
weight: 100
url: /it/java/metered-licensing/
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
- Java
- Aspose.Slides
description: "Scopri come la licenza a consumo di Aspose.Slides per Java ti consente di elaborare file PowerPoint e OpenDocument in modo flessibile, pagando solo per ciò che utilizzi."
---
## **Introduzione**

La licenza a consumo è un meccanismo di licenza che può essere utilizzato insieme ai metodi di licenza esistenti. Se desideri essere fatturato in base all'utilizzo delle funzionalità dell'API Aspose.Slides, scegli la licenza a consumo.

## **Applicare le chiavi a consumo**

{{% alert color="info" %}} 

La licenza a consumo è un nuovo meccanismo di licenza che può essere utilizzato insieme ai metodi di licenza esistenti. Se desideri essere fatturato in base all'utilizzo delle funzionalità dell'API Aspose.Slides, scegli la licenza a consumo.

Quando acquisti una licenza a consumo, ottieni delle chiavi (e non un file di licenza). Questa chiave a consumo può essere applicata utilizzando la classe [Metered](https://reference.aspose.com/slides/it/java/com.aspose.slides/metered/) fornita da Aspose per le operazioni di misurazione. Per ulteriori dettagli, consulta le [FAQ sulla licenza a consumo](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Crea un'istanza della classe [Metered](https://reference.aspose.com/slides/it/java/com.aspose.slides/metered/).

1. Passa le tue chiavi pubblica e privata al metodo [setMeteredKey](https://reference.aspose.com/slides/it/java/com.aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-).

1. Esegui qualche elaborazione (esegui attività).

1. Chiama il metodo [getConsumptionQuantity](https://reference.aspose.com/slides/it/java/com.aspose.slides/metered/#getConsumptionQuantity--) della classe `Metered`.

Dovresti vedere la quantità di richieste API che hai consumato finora.

Questo esempio di codice ti mostra come utilizzare la licenza a consumo:

```java
// Crea un'istanza della classe Metered
com.aspose.slides.Metered metered = new com.aspose.slides.Metered();

try {
    // Passa le chiavi pubblica e privata all'oggetto Metered
    metered.setMeteredKey("<valid public key>", "<valid private key>");

    // Ottiene il valore della quantità consumata prima delle chiamate API
    double amountBefore = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed before: " + amountBefore);

    // Esegui qualche operazione con l'API Aspose.Slides qui
    // ...

    // Ottiene il valore della quantità consumata dopo le chiamate API
    double amountAfter = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed after: " + amountAfter);
} catch (Exception ex) {
    ex.printStackTrace();
}
```

{{% alert color="warning" title="NOTE"  %}} 

Per utilizzare la licenza a consumo, è necessaria una connessione internet stabile poiché il meccanismo di licenza utilizza Internet per interagire costantemente con i nostri servizi ed eseguire i calcoli.

{{% /alert %}} 

## **FAQ**

### Posso utilizzare una licenza a consumo insieme a una licenza regolare (perpetua o temporanea) nella stessa applicazione?

Sì. La licenza a consumo è un meccanismo di licenza aggiuntivo che può essere utilizzato insieme ai [metodi di licenza](/slides/it/java/licensing/). Decidi quale meccanismo applicare all'avvio dell'applicazione.

### Cosa conta esattamente come consumo con una licenza a consumo: operazioni o file?

L'utilizzo dell'API viene conteggiato, ovvero il numero di richieste o operazioni. Puoi ottenere il consumo corrente tramite i [metodi di tracciamento del consumo](https://reference.aspose.com/slides/it/java/com.aspose.slides/metered/).

### La licenza a consumo è adatta per microservizi e ambienti serverless in cui le istanze vengono riavviate frequentemente?

Sì. Poiché la contabilità avviene a livello di chiamata API, gli scenari con frequenti avvii a freddo sono compatibili, a condizione che vi sia un accesso di rete stabile per i calcoli a consumo.

### Le funzionalità della libreria differiscono quando si utilizza una licenza a consumo rispetto a una licenza perpetua?

No. Questo riguarda solo il meccanismo di licenza e fatturazione; le capacità del prodotto rimangono le stesse.

### Come si colloca la licenza a consumo rispetto alla versione di prova e alla licenza temporanea?

La versione di prova ha limitazioni e filigrane, la [licenza temporanea](https://purchase.aspose.com/temporary-license/) rimuove le limitazioni per 30 giorni, e la licenza a consumo rimuove le limitazioni e addebita in base all'uso effettivo.

### Posso controllare il budget reagendo automaticamente quando una soglia di consumo viene superata?

Sì. Una pratica comune è leggere periodicamente il consumo corrente tramite i [metodi di tracciamento](https://reference.aspose.com/slides/it/java/com.aspose.slides/metered/) e implementare i propri limiti o avvisi a livello di applicazione o di monitoraggio.