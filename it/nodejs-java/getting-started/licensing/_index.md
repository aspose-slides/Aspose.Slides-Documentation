---
title: Licenze
type: docs
weight: 80
url: /it/nodejs-java/licensing/
keywords:
- licenza
- licenza temporanea
- imposta licenza
- usa licenza
- convalida licenza
- file di licenza
- versione di valutazione
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Applica, gestisci e risolvi i problemi delle licenze in Aspose.Slides per Node.js. Garantisci accesso ininterrotto a tutte le funzionalità con la nostra guida passo-passo sulla licenza."
---
## **Introduzione**

A volte, per ottenere i migliori risultati di valutazione, potrebbe essere necessario un approccio pratico. Per questo motivo, Aspose.Slides offre diversi piani di acquisto e mette a disposizione una Prova Gratuita e una Licenza Temporanea di 30 giorni per la valutazione.

{{% alert color="info" title="Note" %}}
Nota che esistono varie politiche e pratiche generali che ti guidano su come valutare, licenziare correttamente e acquistare i nostri prodotti. Puoi trovarle nella sezione ["Politiche di Acquisto e FAQ"](https://purchase.aspose.com/policies).
{{% /alert %}}

## **Valutare Aspose.Slides**
Puoi scaricare facilmente Aspose.Slides per la valutazione. Il pacchetto di valutazione è lo stesso del pacchetto acquistato. La versione di valutazione diventa semplicemente concessa in licenza dopo che aggiungi alcune righe di codice per applicare la licenza.

## **Limitazioni della Versione di Valutazione**
La versione di valutazione di Aspose.Slides (senza licenza specificata) fornisce la piena funzionalità del prodotto, con due limitazioni:

* Aggiunge una casella di testo con filigrana di valutazione a ogni diapositiva di ciascuna presentazione che salva.
* Il testo più lungo di cinque caratteri che il tuo codice legge da una presentazione viene troncato ai primi cinque caratteri, seguito da `... text has been truncated due to evaluation version limitation.` Il testo di cinque caratteri o meno viene restituito inalterato, e il testo scritto dal tuo codice viene salvato nella sua interezza.

{{% alert color="info" title="Note" %}}
Se desideri testare Aspose.Slides senza le limitazioni della versione di valutazione, puoi richiedere una **Licenza Temporanea di 30 giorni**. Consulta [Come ottenere una Licenza Temporanea?](https://purchase.aspose.com/temporary-license) per ulteriori informazioni.
{{% /alert %}}

## **Informazioni sulla Licenza**
Puoi scaricare facilmente una versione di valutazione di Aspose.Slides per Node.js tramite Java dalla sua [pagina di download](https://releases.aspose.com/slides/it/nodejs-java/). La versione di valutazione ha le stesse funzionalità della versione con licenza, con le limitazioni descritte sopra. Inoltre, la versione di valutazione diventa semplicemente concessa in licenza dopo aver acquistato una licenza e aver aggiunto un paio di righe di codice per applicarla.

La licenza è un file XML di testo semplice che contiene dettagli come il nome del prodotto, il numero di sviluppatori a cui è concessa in licenza, la data di scadenza dell'abbonamento e così via. Il file è firmato digitalmente, quindi non modificarlo. Anche l'aggiunta involontaria di una nuova riga extra al contenuto del file lo invaliderà.

Per evitare le limitazioni associate alla versione di valutazione, devi impostare una licenza prima di utilizzare **Aspose.Slides**. È necessario impostare la licenza una sola volta per applicazione o processo.

{{% alert color="info" title="Note" %}}
Potresti voler vedere [Licenza a Consumo](/slides/it/nodejs-java/metered-licensing/).
{{% /alert %}}

## **Licenza Acquistata**
Dopo l'acquisto, devi applicare il file o lo stream della licenza.

{{% alert color="info" title="Note" %}}
Devi impostare la licenza:
* solo una volta per processo
* prima di utilizzare qualsiasi altra classe Aspose.Slides
{{% /alert %}}

{{% alert color="info" title="Note" %}}
Puoi trovare le informazioni sui prezzi nella pagina [“Informazioni sui prezzi”](https://purchase.aspose.com/pricing/slides/it/family).
{{% /alert %}}

### **Impostare una Licenza in Aspose.Slides per Node.js tramite Java**
Le licenze possono essere applicate da queste posizioni:

* Percorso esplicito
* Stream
* Come Licenza a Consumo – un nuovo meccanismo di licenza

{{% alert color="info" title="Note" %}}
Usa il metodo **setLicense** per licenziare un componente.

Sebbene più chiamate a **setLicense** non siano dannose, sono uno spreco di risorse (processore).
{{% /alert %}}

#### **Applicare una Licenza Utilizzando un File**
Questo frammento di codice viene utilizzato per impostare un file di licenza:

**Node.js**

```javascript
const asposeSlides = require("aspose.slides.via.java");

const license = new asposeSlides.License();
license.setLicense("Aspose.Slides.lic");
console.log("The license was applied.");

// Aspose.Slides viene eseguito in una macchina virtuale Java che mantiene Node.js in esecuzione, quindi chiudi esplicitamente il processo.
process.exit(0);
```

Quando chiami il metodo setLicense, il nome della licenza deve coincidere con quello del tuo file di licenza. Ad esempio, puoi rinominare il file di licenza in "Aspose.Slides.lic.xml". Poi, nel tuo codice, devi passare il nuovo nome della licenza (Aspose.Slides.lic.xml) al metodo setLicense. Se il file è assente o non contiene una licenza valida, [setLicense](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/license/setlicense/) genera un'eccezione, che termina lo script con un errore.

#### **Applicare una Licenza da uno Stream**
Per applicare una licenza da uno stream, passa l'oggetto [License](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/license/) e uno stream leggibile al metodo statico [setLicenseFromStream](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/license/setlicense/). Lo stream viene letto in modo asincrono e il callback riceve un errore se lo stream non contiene una licenza valida:

**Node.js**

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");

const license = new asposeSlides.License();
const readStream = fs.createReadStream("Aspose.Slides.lic");
asposeSlides.License.setLicenseFromStream(license, readStream, function (error) {
    if (error) {
        console.error("The license was not applied:", error.message);
    } else {
        console.log("The license was applied.");
    }

    // Aspose.Slides viene eseguito in una macchina virtuale Java che mantiene Node.js in esecuzione, quindi chiudi esplicitamente il processo.
    process.exit(0);
});
```

La licenza viene applicata quando l'intero stream è stato letto, appena prima che il callback venga eseguito, quindi avvia altri lavori Aspose.Slides dal callback.

Entrambi gli esempi chiamano `process.exit(0)` alla fine, perché la macchina virtuale Java che esegue Aspose.Slides mantiene Node.js in esecuzione. In un'applicazione, continua con il tuo codice Aspose.Slides invece di terminare il processo.

## **FAQ**

### Posso applicare la licenza in un ambiente completamente offline (senza accesso a internet)?
Sì. La convalida della licenza viene eseguita localmente utilizzando il file di licenza; non è necessaria alcuna connessione internet.

### Cosa succede dopo la scadenza dell'abbonamento di un anno? La libreria smetterà di funzionare?
No. La licenza è perpetua: puoi continuare a utilizzare le versioni rilasciate prima della data di fine abbonamento; semplicemente non potrai utilizzare le versioni più recenti senza rinnovare.