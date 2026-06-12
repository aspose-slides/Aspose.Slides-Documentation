---
title: Licenze
type: docs
weight: 80
url: /it/nodejs-java/licensing/
keywords:
- licenza
- licenza temporanea
- impostare licenza
- utilizzare licenza
- validare licenza
- file di licenza
- versione di valutazione
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Applica, gestisci e risolvi i problemi delle licenze in Aspose.Slides per Node.js. Garantisci un accesso ininterrotto a tutte le funzionalità con la nostra guida passo-passo sulla licenza."
---
## **Introduzione**

A volte, per ottenere i migliori risultati di valutazione, potrebbe essere necessario un approccio pratico. Per questo motivo, Aspose.Slides offre diversi piani di acquisto e anche una versione di prova gratuita e una Licenza Temporanea di 30 giorni per la valutazione.

{{% alert color="primary" %}}
Nota che esistono numerose politiche generali e pratiche che ti guidano su come valutare, licenziare correttamente e acquistare i nostri prodotti. Puoi trovarle nella sezione [Politiche di acquisto e FAQ](https://purchase.aspose.com/policies).
{{% /alert %}}

## **Valutare Aspose.Slides**
Puoi scaricare facilmente Aspose.Slides per la valutazione. Il pacchetto di valutazione è lo stesso del pacchetto acquistato. La versione di valutazione diventa semplicemente licenziata dopo che aggiungi alcune righe di codice per applicare la licenza. 

## **Limitazione della versione di valutazione**
La versione di valutazione di Aspose.Slides (senza una licenza specificata) fornisce tutte le funzionalità del prodotto, ma inserisce una filigrana di valutazione nella parte superiore del documento all'apertura e al salvataggio. Sei inoltre limitato a una diapositiva quando estrai testi dalle diapositive della presentazione.

{{% alert color="primary" %}} 
Se desideri testare Aspose.Slides senza le limitazioni della versione di valutazione, puoi richiedere una **Licenza Temporanea di 30 giorni**. Consulta [Come ottenere una Licenza Temporanea?](https://purchase.aspose.com/temporary-license) per ulteriori informazioni.
{{% /alert %}} 

## **Informazioni sulla licenza**
Puoi scaricare facilmente una versione di valutazione di Aspose.Slides per Node.js tramite Java dalla sua [pagina di download](https://releases.aspose.com/slides/it/nodejs-java/). La versione di valutazione fornisce assolutamente **le stesse capacità** della versione con licenza di Aspose.Slides. Inoltre, la versione di valutazione diventa semplicemente licenziata dopo che acquisti una licenza e aggiungi un paio di righe di codice per applicare la licenza.

La licenza è un file XML di testo semplice che contiene dettagli come il nome del prodotto, il numero di sviluppatori a cui è concessa, la data di scadenza dell'abbonamento, ecc. Il file è firmato digitalmente, quindi non modificarlo. Anche una aggiunta involontaria di una riga vuota al contenuto del file lo invaliderà.

Per evitare le limitazioni associate alla versione di valutazione, è necessario impostare una licenza prima di utilizzare **Aspose.Slides**. È necessario impostare la licenza una sola volta per applicazione o processo.

{{% alert color="primary" %}} 
Potresti voler vedere [Licenza a consumo](https://docs.aspose.com/slides/it/nodejs-java/metered-licensing/).
{{% /alert %}} 

## **Licenza acquistata**

Dopo l'acquisto, devi applicare il file o lo stream della licenza. 

{{% alert color="primary" %}}
Devi impostare la licenza:
* solo una volta per dominio dell'applicazione
* prima di utilizzare qualsiasi altra classe di Aspose.Slides
{{% /alert %}}

{{% alert color="primary" %}}
Puoi trovare le informazioni sui prezzi nella pagina [Informazioni sui prezzi](https://purchase.aspose.com/pricing/slides/it/family).
{{% /alert %}}

### **Impostare una licenza in Aspose.Slides per Node.js tramite Java**

Le licenze possono essere applicate da questi percorsi:

* Percorso esplicito
* Stream
* Come Licenza a consumo – un nuovo meccanismo di licenza

{{% alert color="primary" %}}
Usa il metodo **setLicense** per licenziare un componente.

Sebbene più chiamate a **setLicense** non siano dannose, rappresentano uno spreco di risorse (processore).
{{% /alert %}}

{{% alert color="warning" %}}
Le nuove licenze possono attivare Aspose.Slides solo con la versione 21.4 o successive. Le versioni precedenti utilizzano un sistema di licenza diverso e non riconosceranno queste licenze.
{{% /alert %}}

#### **Applicare una licenza usando un file**

Questo frammento di codice viene utilizzato per impostare un file di licenza:

**Node.js**

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var license = new aspose.slides.License();
license.setLicense("Aspose.Slides.lic");
```

Quando chiami il metodo setLicense, il nome della licenza dovrebbe essere lo stesso del tuo file di licenza. Ad esempio, puoi rinominare il file di licenza in "Aspose.Slides.lic.xml". Quindi, nel tuo codice, devi passare il nuovo nome della licenza (Aspose.Slides.lic.xml) al metodo setLicense.

#### **Applicare una licenza da uno stream**

Questo frammento di codice viene utilizzato per applicare una licenza da uno stream:

**Node.js**

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var license = new aspose.slides.License();

var fs = require("fs");

var readStream = fs.createReadStream("Aspose.Slides.lic");

license.setLicense(readStream, function(err, list) {
    if(err) { 
        console.error(err); return; 
    }});
```

## **FAQ**

**Posso applicare la licenza in un ambiente completamente offline (senza accesso a Internet)?**

Sì. La convalida della licenza viene eseguita localmente utilizzando il file di licenza; non è necessaria alcuna connessione a Internet.

**Cosa succede dopo la scadenza dell'abbonamento di un anno? La libreria smetterà di funzionare?**

No. La licenza è perpetua: puoi continuare a utilizzare le versioni rilasciate prima della data di scadenza del tuo abbonamento; semplicemente non sarai idoneo a utilizzare versioni più recenti senza rinnovare.