---
title: Licenza a consumo
type: docs
weight: 90
url: /it/python-net/metered-licensing/
keywords:
- licenza
- licenza a consumo
- chiavi di licenza
- chiave pubblica
- chiave privata
- quantità di consumo
- Python
- Aspose.Slides
description: "Scopri come la licenza a consumo di Aspose.Slides per Python via .NET ti consente di elaborare file PowerPoint e OpenDocument in modo flessibile, pagando solo per ciò che utilizzi."
---
## **Introduzione**

La licenza a consumo è un meccanismo di licenza che può essere utilizzato insieme ai metodi di licenza esistenti. Se desideri essere fatturato in base all'utilizzo delle funzionalità dell'API Aspose.Slides, scegli la licenza a consumo.

## **Applicare le chiavi a consumo**

{{% alert color="primary" %}} 

La licenza a consumo è un nuovo meccanismo di licenza che può essere utilizzato insieme ai metodi di licenza esistenti. Se desideri essere fatturato in base all'utilizzo delle funzionalità dell'API Aspose.Slides, scegli la licenza a consumo.

Quando acquisti una licenza a consumo, ottieni delle chiavi (e non un file di licenza). Questa chiave a consumo può essere applicata usando la classe [Metered](https://reference.aspose.com/slides/it/python-net/aspose.slides/metered/) fornita da Aspose per le operazioni di misurazione. Per ulteriori dettagli, consulta le [FAQ sulla licenza a consumo](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Crea un'istanza della classe [Metered](https://reference.aspose.com/slides/it/python-net/aspose.slides/metered/).
2. Passa le tue chiavi pubbliche e private al metodo [set_metered_key](https://reference.aspose.com/slides/it/python-net/aspose.slides/metered/set_metered_key/#str-str).
3. Esegui qualche elaborazione (esegui attività).
4. Chiama il metodo [get_consumption_quantity](https://reference.aspose.com/slides/it/python-net/aspose.slides/metered/get_consumption_quantity/#) della classe `Metered`.

Dovresti vedere la quantità di richieste API che hai consumato finora.

Questo esempio di codice mostra come utilizzare la licenza a consumo:

```python
import aspose.slides as slides

# Crea un'istanza della classe Metered
metered = slides.Metered()

# Passa le chiavi pubblica e privata all'oggetto Metered
metered.set_metered_key("<valid public key>", "<valid private key>")

# Ottiene il valore della quantità consumata prima delle chiamate API
amount_before = slides.Metered.get_consumption_quantity()
print("Amount consumed before:", amount_before)

# Esegui qualche operazione con l'API Aspose.Slides qui
# ...

# Ottiene il valore della quantità consumata dopo le chiamate API
amount_after = slides.Metered.get_consumption_quantity()
print("Amount consumed after:", amount_after)
```

{{% alert color="warning" title="NOTE"  %}} 

Per utilizzare la licenza a consumo, è necessaria una connessione internet stabile perché il meccanismo di licenza utilizza internet per interagire costantemente con i nostri servizi e effettuare i calcoli.

{{% /alert %}} 

## **FAQ**

**Posso usare una licenza a consumo insieme a una regolare (perpetua o temporanea) nella stessa applicazione?**

Sì. La licenza a consumo è un meccanismo aggiuntivo che può essere usato insieme ai [metodi di licenza](/slides/it/python-net/licensing/). Decidi quale meccanismo applicare all’avvio dell’applicazione.

**Cosa conta esattamente come consumo con una licenza a consumo: operazioni o file?**

Viene conteggiato l'utilizzo dell'API, ovvero il numero di richieste o operazioni. Puoi ottenere il consumo attuale tramite i [metodi di tracciamento del consumo](https://reference.aspose.com/slides/it/python-net/aspose.slides/metered/).

**La licenza a consumo è adatta per microservizi e ambienti serverless in cui le istanze si riavviano frequentemente?**

Sì. Poiché la contabilizzazione avviene a livello di chiamata API, gli scenari con frequenti cold start sono compatibili, a condizione che vi sia un accesso di rete stabile per i calcoli a consumo.

**Le funzionalità della libreria cambiano usando una licenza a consumo rispetto a una licenza perpetua?**

No. Si tratta solo del meccanismo di licenza e fatturazione; le capacità del prodotto rimangono identiche.

**Come si colloca la licenza a consumo rispetto alla versione di prova e alla licenza temporanea?**

La versione di prova ha limitazioni e filigrane, la [licenza temporanea](https://purchase.aspose.com/temporary-license/) rimuove le limitazioni per 30 giorni, e la licenza a consumo rimuove le limitazioni e addebita in base all’uso reale.

**Posso controllare il budget reagendo automaticamente quando viene superata una soglia di consumo?**

Sì. Una pratica comune è leggere periodicamente il consumo corrente tramite i [metodi di tracciamento](https://reference.aspose.com/slides/it/python-net/aspose.slides/metered/) e implementare propri limiti o avvisi a livello di applicazione o di monitoraggio.