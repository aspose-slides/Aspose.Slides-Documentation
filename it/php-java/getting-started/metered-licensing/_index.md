---
title: Licenza a consumo
type: docs
weight: 100
url: /it/php-java/metered-licensing/
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
- PHP
- Aspose.Slides
description: "Scopri come la licenza a consumo di Aspose.Slides per PHP via Java ti consente di elaborare file PowerPoint e OpenDocument in modo flessibile, pagando solo per quello che usi."
---
## **Introduzione**

La licenza a consumo è un meccanismo di licenza che può essere utilizzato insieme ai metodi di licenza esistenti. Se desideri essere fatturato in base all'utilizzo delle funzionalità dell'Aspose.Slides API, scegli la licenza a consumo.

## **Applicare le chiavi a consumo**

Quando acquisti una licenza a consumo, ricevi le chiavi (e non un file di licenza). Questa chiave a consumo può essere applicata utilizzando la classe [Metered](https://reference.aspose.com/slides/it/php-java/aspose.slides/metered/) fornita da Aspose per le operazioni di misurazione. Per ulteriori dettagli, consulta le [FAQ sulla licenza a consumo](https://purchase.aspose.com/faqs/licensing/metered).

1. Crea un'istanza della classe [Metered](https://reference.aspose.com/slides/it/php-java/aspose.slides/metered/).

1. Passa le tue chiavi pubblica e privata al metodo [setMeteredKey](https://reference.aspose.com/slides/it/php-java/aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-).

1. Esegui qualche elaborazione (esegui operazioni).

1. Chiama il metodo [getConsumptionQuantity](https://reference.aspose.com/slides/it/php-java/aspose.slides/metered/#getConsumptionQuantity--) della classe `Metered`.

Dovresti vedere la quantità di richieste API che hai consumato finora.

Questo esempio di codice mostra come utilizzare la licenza a consumo:

```php
// Crea un'istanza della classe Metered
$metered = new Metered();

try {
    // Passa le chiavi pubblica e privata all'oggetto Metered
    $metered->setMeteredKey("<valid pablic key>", "<valid private key>");

    // Ottiene il valore della quantità consumata prima delle chiamate API
    $amountBefore = Metered::getConsumptionQuantity();
    echo("Amount consumed before: " . $amountBefore);

    // Esegue qualcosa con l'API Aspose.Slides qui
    // ...

    // Ottiene il valore della quantità consumata dopo le chiamate API
    $amountAfter = Metered::getConsumptionQuantity();
    echo("Amount consumed after: " . $amountAfter);
} catch (JavaException $ex) {
  $ex->printStackTrace();
}
```

{{% alert color="warning" title="NOTE"  %}} 
Per utilizzare la licenza a consumo, è necessaria una connessione internet stabile perché il meccanismo di licenza utilizza internet per interagire costantemente con i nostri servizi ed eseguire i calcoli.
{{% /alert %}} 

## **FAQ**

**Posso usare una licenza a consumo insieme a una licenza normale (perpetua o temporanea) nella stessa applicazione?**

Sì. La licenza a consumo è un meccanismo di licenza aggiuntivo che può essere utilizzato insieme ai [metodi di licenza](/slides/it/php-java/licensing/) esistenti. Decidi quale meccanismo applicare all'avvio dell'applicazione.

**Cosa conta esattamente come consumo con una licenza a consumo: operazioni o file?**

Si conta l'utilizzo dell'API, cioè il numero di richieste o operazioni. È possibile ottenere il consumo attuale tramite i [metodi di tracciamento del consumo](https://reference.aspose.com/slides/it/php-java/aspose.slides/metered/).

**La licenza a consumo è adatta a microservizi e ambienti serverless dove le istanze si riavviano frequentemente?**

Sì. Poiché la contabilità avviene a livello di chiamata API, gli scenari con frequenti avvii a freddo sono compatibili, a condizione che ci sia un accesso di rete stabile per i calcoli a consumo.

**Le funzionalità della libreria differiscono quando si utilizza una licenza a consumo rispetto a una licenza perpetua?**

No. Si tratta solo del meccanismo di licenza e fatturazione; le capacità del prodotto rimangono invariate.

**Come si colloca la licenza a consumo rispetto alla versione di prova e alla licenza temporanea?**

La versione di prova presenta limitazioni e filigrane, la [licenza temporanea](https://purchase.aspose.com/temporary-license/) rimuove le limitazioni per 30 giorni, e la licenza a consumo rimuove le limitazioni e addebita in base all'utilizzo reale.

**Posso controllare il budget reagendo automaticamente quando viene superata una soglia di consumo?**

Sì. Una pratica comune è leggere periodicamente il consumo attuale tramite i [metodi di tracciamento](https://reference.aspose.com/slides/it/php-java/aspose.slides/metered/) e implementare i propri limiti o avvisi a livello di applicazione o di monitoraggio.