---
title: Licenza a consumo
type: docs
weight: 100
url: /it/python-java/metered-licensing/
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
- Python
- Aspose.Slides
description: "Scopri come Aspose.Slides per Python tramite Java con licenza a consumo ti consente di elaborare file PowerPoint e OpenDocument in modo flessibile, pagando solo per quello che utilizzi."
---
## **Introduzione**

La licenza a consumo è un meccanismo di licenza che può essere utilizzato insieme ai metodi di licenza esistenti. Se desideri essere fatturato in base all'utilizzo delle funzionalità dell'API Aspose.Slides, scegli la licenza a consumo.

## **Applicare le chiavi a consumo**

{{% alert color="info" title="Nota" %}}

La licenza a consumo è un nuovo meccanismo di licenza che può essere utilizzato insieme ai metodi di licenza esistenti. Se desideri essere fatturato in base all'utilizzo delle funzionalità dell'API Aspose.Slides, scegli la licenza a consumo.

Quando acquisti una licenza a consumo, ricevi le chiavi (e non un file di licenza). Questa chiave a consumo può essere applicata utilizzando la classe [Metered](https://reference.aspose.com/slides/it/python-java/aspose.slides/metered/) fornita da Aspose per le operazioni di misurazione. Per ulteriori dettagli, consulta le [FAQ sulla licenza a consumo](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}}

1. Crea un'istanza della classe [Metered](https://reference.aspose.com/slides/it/python-java/aspose.slides/metered/).

1. Passa le tue chiavi pubbliche e private al metodo [setMeteredKey](https://reference.aspose.com/slides/it/python-java/aspose.slides/metered/#setMeteredKey).

1. Esegui un po' di elaborazione (esegui attività).

1. Chiama il metodo [getConsumptionQuantity](https://reference.aspose.com/slides/it/python-java/aspose.slides/metered/#getConsumptionQuantity) della classe [Metered](https://reference.aspose.com/slides/it/python-java/aspose.slides/metered/).

Dovresti vedere la quantità di richieste API che hai consumato finora.

Questo esempio di codice mostra come utilizzare la licenza a consumo:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Metered

# Crea un'istanza della classe Metered.
metered = Metered()

try:
    # Passa le chiavi pubblica e privata all'oggetto Metered.
    metered.setMeteredKey("<valid public key>", "<valid private key>")

    # Ottieni la quantità consumata prima delle chiamate API.
    amount_before = Metered.getConsumptionQuantity()
    print("Amount consumed before:", amount_before)

    # Esegui qualche operazione con l'API Aspose.Slides qui.
    # ...

    # Ottieni la quantità consumata dopo le chiamate API.
    amount_after = Metered.getConsumptionQuantity()
    print("Amount consumed after:", amount_after)
except Exception as error:
    print(error)
```

{{% alert color="warning" title="Avviso" %}}

Per utilizzare la licenza a consumo, è necessaria una connessione Internet stabile perché il meccanismo di licenza utilizza Internet per interagire costantemente con i nostri servizi e per eseguire i calcoli.

{{% /alert %}}

## **FAQ**

**Posso usare una licenza a consumo insieme a una licenza normale (perpetua o temporanea) nella stessa applicazione?**

Sì. La licenza a consumo è un meccanismo aggiuntivo che può essere usato insieme ai [metodi di licenza](/slides/it/python-java/licensing/). Decidi quale meccanismo applicare quando l'applicazione si avvia.

**Cosa conta esattamente come consumo con una licenza a consumo: operazioni o file?**

Viene conteggiato l'uso dell'API, cioè il numero di richieste o operazioni. Puoi ottenere il consumo corrente tramite i [metodi di tracciamento del consumo](https://reference.aspose.com/slides/it/python-java/aspose.slides/metered/).

**La licenza a consumo è adatta a microservizi e ambienti serverless dove le istanze si riavviano frequentemente?**

Sì. Poiché la contabilizzazione avviene a livello di chiamata API, gli scenari con frequenti avvii a freddo sono compatibili, a condizione che vi sia un accesso di rete stabile per i calcoli della licenza a consumo.

**Le funzionalità della libreria differiscono quando si usa una licenza a consumo rispetto a una licenza perpetua?**

No. Si tratta solo del meccanismo di licenza e fatturazione; le capacità del prodotto rimangono invariate.

**Come si colloca la licenza a consumo rispetto alla versione di prova e alla licenza temporanea?**

La versione di prova ha limitazioni e filigrane, la [licenza temporanea](https://purchase.aspose.com/temporary-license/) rimuove le limitazioni per 30 giorni, e la licenza a consumo rimuove le limitazioni e addebita in base all'uso effettivo.

**Posso controllare il budget reagendo automaticamente quando viene superata una soglia di consumo?**

Sì. Una pratica comune è leggere periodicamente il consumo corrente tramite i [metodi di tracciamento](https://reference.aspose.com/slides/it/python-java/aspose.slides/metered/) e implementare propri limiti o avvisi a livello dell'applicazione o del monitoraggio.