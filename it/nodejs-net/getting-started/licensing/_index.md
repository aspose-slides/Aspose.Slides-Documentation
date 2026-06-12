---
title: Licenza
description: "Aspose.Slides per Node.js via .NET offre diversi piani di acquisto o una Prova Gratuita e una Licenza Temporanea di 30 giorni per la valutazione, utilizzando le politiche di Licenza e Sottoscrizione."
type: docs
weight: 80
url: /it/nodejs-net/licensing/
---
A volte, per ottenere i migliori risultati di valutazione, potrebbe essere necessario un approccio pratico. Per questo motivo, Aspose.Slides offre diversi piani di acquisto e propone anche una Prova Gratuita e una Licenza Temporanea di 30 giorni per la valutazione.

{{% alert color="primary" %}}
Nota che esistono diverse politiche e pratiche generali che ti guidano su come valutare, licenziare correttamente e acquistare i nostri prodotti. Puoi trovarle nella sezione [Politiche di Acquisto e FAQ](https://purchase.aspose.com/policies).
{{% /alert %}}

## **Valuta Aspose.Slides**
Puoi scaricare facilmente Aspose.Slides per la valutazione. Il pacchetto di valutazione è identico a quello acquistato. La versione di valutazione diventa semplicemente licenziata dopo aver aggiunto alcune righe di codice per applicare la licenza. 

## **Limitazioni della Versione di Valutazione**
La versione di valutazione di Aspose.Slides (senza una licenza specificata) fornisce tutte le funzionalità del prodotto, ma inserisce una filigrana di valutazione nella parte superiore del documento all'apertura e al salvataggio. Inoltre sei limitato a una diapositiva quando estrai testi dalle diapositive della presentazione.

{{% alert color="primary" %}} 
Se desideri testare Aspose.Slides senza le limitazioni della versione di valutazione, puoi richiedere una **Licenza Temporanea di 30 Giorni**. Per ulteriori informazioni consulta [Come ottenere una Licenza Temporanea?](https://purchase.aspose.com/temporary-license).
{{% /alert %}} 

## **Informazioni sulla Licenza**
Puoi scaricare facilmente una versione di valutazione di Aspose.Slides per Node.js via .NET dalla sua [pagina di download](https://releases.aspose.com/slides/it/nodejs-net/). La versione di valutazione offre assolutamente **le stesse capacità** della versione con licenza di Aspose.Slides. Inoltre, la versione di valutazione diventa semplicemente licenziata dopo aver acquistato una licenza e aggiunto un paio di righe di codice per applicare la licenza.

La licenza è un file XML di testo semplice che contiene dettagli come il nome del prodotto, il numero di sviluppatori a cui è concessa, la data di scadenza della sottoscrizione e così via. Il file è firmato digitalmente, quindi non modificarlo. Anche l'aggiunta involontaria di un'interruzione di riga extra al contenuto del file lo invaliderebbe.

Per evitare le limitazioni associate alla versione di valutazione, devi impostare una licenza prima di utilizzare **Aspose.Slides**. È necessario impostare la licenza una sola volta per applicazione o processo.

## Licenza Acquistata

Dopo l'acquisto, devi applicare il file o lo stream della licenza. 

{{% alert color="primary" %}}
Devi impostare la licenza:
* solo una volta per dominio dell'applicazione
* prima di utilizzare qualsiasi altra classe di Aspose.Slides
{{% /alert %}}

{{% alert color="primary" %}}
Puoi trovare le informazioni sui prezzi nella pagina [“Pricing Information”](https://purchase.aspose.com/pricing/slides/it/family).
{{% /alert %}}

### **Impostazione di una Licenza in Aspose.Slides per Node.js via .NET**

Le licenze possono essere applicate da queste posizioni:
* Percorso esplicito
* Stream
* Come Licenza a Consumo – un nuovo meccanismo di licenza

{{% alert color="primary" %}}
Usa il metodo **setLicense** per licenziare un componente.

Sebbene chiamate multiple a **setLicense** non siano dannose, rappresentano uno spreco di risorse (processore).
{{% /alert %}}

{{% alert color="warning" %}}
Le nuove licenze possono attivare Aspose.Slides solo con la versione 21.4 o successive. Le versioni precedenti usano un sistema di licenza diverso e non riconosceranno queste licenze.
{{% /alert %}}

#### **Applicare una Licenza Utilizzando un File**
Questo frammento di codice viene utilizzato per impostare un file di licenza:

**Node.js**

```javascript
// Importa il modulo Aspose.Slides per la manipolazione di file PowerPoint
const asposeSlides = require('aspose.slides.via.net');

// Questa funzione configura la libreria Aspose.Slides con una licenza
function setupAsposeSlidesLicense() {
	
    // Inizializza la classe License dal modulo Aspose.Slides
    var license = new asposeSlides.License();
    
    // Applica la licenza da un file
    // Sostituisci "your_license_file.lic" con il percorso del tuo file di licenza reale
    license.setLicense("your_license_file.lic");
}

// Esegui la funzione per configurare la licenza per Aspose.Slides
setupAsposeSlidesLicense();
```
{{% alert color="primary" %}}
Quando chiami il metodo setLicense, il nome della licenza deve essere lo stesso del tuo file di licenza. Ad esempio, puoi rinominare il file di licenza in "Aspose.Slides.lic.xml". Quindi, nel tuo codice, devi passare il nuovo nome della licenza (Aspose.Slides.lic.xml) al metodo setLicense.
{{% /alert %}}