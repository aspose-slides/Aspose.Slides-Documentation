---
title: Licenza
type: docs
weight: 80
url: /it/python-net/licensing/
keywords:
- licenza
- licenza temporanea
- imposta licenza
- usa licenza
- valida licenza
- file di licenza
- versione di valutazione
- Python
- Aspose.Slides
description: "Scopri come applicare, gestire e risolvere i problemi delle licenze in Aspose.Slides per Python via .NET. Garantisci un accesso ininterrotto a tutte le funzionalità con la nostra guida passo-passo sulla gestione delle licenze."
---
## **Panoramica**

Aspose.Slides può essere utilizzato in modalità di valutazione o con una licenza valida. La versione di valutazione fornisce la stessa funzionalità della versione con licenza, ma aggiunge una filigrana di valutazione quando le presentazioni sono aperte o salvate e limita l'estrazione del testo a una diapositiva.

## **Valutare Aspose.Slides**

Puoi scaricare una versione di valutazione di **Aspose.Slides for Python via .NET** dalla sua [pagina di download](https://pypi.org/project/Aspose.Slides/). La versione di valutazione offre le stesse funzionalità del prodotto con licenza. Il pacchetto di valutazione è identico al pacchetto acquistato e diventa licenziato dopo aver aggiunto qualche riga di codice per applicare la licenza.

Quando sei soddisfatto della tua valutazione di **Aspose.Slides**, puoi [acquistare una licenza](https://purchase.aspose.com/buy). Ti consigliamo di esaminare le opzioni di abbonamento disponibili. Se hai domande, contatta il team commerciale di Aspose.

Ogni licenza Aspose include un abbonamento di un anno con aggiornamenti gratuiti alle nuove versioni e correzioni rilasciate durante tale periodo. Sia gli utenti con licenza sia quelli in valutazione ricevono supporto tecnico gratuito e illimitato.

**Limitazioni della Versione di Valutazione**

* Sebbene la versione di valutazione di Aspose.Slides (quando non è applicata alcuna licenza) fornisca la piena funzionalità, aggiunge una filigrana di valutazione nella parte superiore del documento ogni volta che lo apri o lo salvi.
* Quando estrai testo da una presentazione, sei limitato a una diapositiva.

{{% alert color="primary" %}}
Per testare Aspose.Slides senza limitazioni, puoi richiedere una **Licenza Temporanea di 30 giorni**. Vedi la pagina [Come Ottenere una Licenza Temporanea](https://purchase.aspose.com/temporary-license) per i dettagli.
{{% /alert %}}

## **Licenze in Aspose.Slides**

* Una versione di valutazione diventa licenziata dopo aver acquistato una licenza e aver aggiunto un paio di righe di codice per applicarla.
* La licenza è un file XML di testo semplice che contiene dettagli come il nome del prodotto, il numero di sviluppatori coperti, la data di scadenza dell'abbonamento, ecc.
* Il file di licenza è firmato digitalmente, quindi non deve essere modificato. Anche l'aggiunta di un singolo a capo invaliderà la licenza.
* Aspose.Slides for Python via .NET tipicamente cerca la licenza in queste posizioni:
  * Un percorso esplicito fornito da te
  * La cartella che contiene lo script Python che chiama Aspose.Slides for Python via .NET
* Per evitare le limitazioni della valutazione, imposta la licenza prima di utilizzare Aspose.Slides. È necessario impostarla una sola volta per applicazione o processo.

{{% alert color="primary" %}}
Potresti anche voler esaminare [Licenze a Consumo](/slides/it/python-net/metered-licensing/).
{{% /alert %}}

## **Applicare una Licenza**

Una licenza può essere caricata da un **file**, **flusso** o **risorsa incorporata**. 

{{% alert color="primary" %}}
Aspose.Slides fornisce la classe [License](https://reference.aspose.com/slides/it/python-net/aspose.slides/license/) per gestire le licenze.
{{% /alert %}}

{{% alert color="warning" %}}
Le nuove licenze possono attivare Aspose.Slides solo con la versione 21.4 o successive. Le versioni precedenti utilizzano un sistema di licenze diverso e non riconosceranno queste licenze.
{{% /alert %}}

### **File**

Il modo più semplice per impostare una licenza è posizionare il file di licenza nella stessa cartella del DLL del componente e specificare solo il nome del file (senza percorso).

Il seguente codice Python mostra come impostare il file di licenza:

```py
import aspose.slides as slides

# Istanzia la classe License.
license = slides.License()

# Imposta il percorso del file di licenza.
license.set_license("Aspose.Slides.lic")
```

{{% alert color="warning" %}}
Se posizioni il file di licenza in una directory diversa, quando chiami [License.set_license()](https://reference.aspose.com/slides/it/python-net/aspose.slides/license/set_license/#str), il nome del file alla fine del percorso esplicito deve corrispondere al nome del tuo file di licenza.

Ad esempio, puoi rinominare il file di licenza in *Aspose.Slides.lic.xml*. Quindi, nel tuo codice, passa il percorso completo a quel file (che termina con Aspose.Slides.lic.xml) al metodo [License.set_license()](https://reference.aspose.com/slides/it/python-net/aspose.slides/license/set_license/#str).
{{% /alert %}}

### **Flusso**

Puoi caricare una licenza da un flusso. Il seguente esempio Python mostra come applicare una licenza da un flusso:

```py
import aspose.slides as slides

# Istanzia la classe License.
license = slides.License()

# Imposta la licenza da un flusso.
license.set_license(stream)
```

## **Validare una Licenza**

Per verificare che la licenza sia stata applicata correttamente, puoi convalidarla. Il seguente codice Python dimostra come convalidare una licenza:

```py
import aspose.slides as slides

license = slides.License()

license.set_license("Aspose.Slides.lic")

if license.is_licensed():
    print("License is good!")
```

## **Sicurezza dei Thread**

{{% alert title="Nota" color="warning" %}}
I metodi [License.set_license](https://reference.aspose.com/slides/it/python-net/aspose.slides/license/) non sono thread‑safe. Se devono essere chiamati contemporaneamente da più thread, utilizza primitive di sincronizzazione (ad esempio, `threading.Lock`) per evitare problemi.
{{% /alert %}}

## **FAQ**

**Posso applicare la licenza in un ambiente completamente offline (senza accesso a Internet)?**

Sì. La convalida della licenza avviene localmente utilizzando il file di licenza; non è necessaria alcuna connessione a Internet.

**Cosa succede dopo la scadenza dell'abbonamento di un anno? La libreria smetterà di funzionare?**

No. La licenza è perpetua: puoi continuare a utilizzare le versioni rilasciate prima della data di scadenza del tuo abbonamento; semplicemente non potrai utilizzare le versioni più recenti senza rinnovare.