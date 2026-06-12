---
title: Licenza
description: "Aspose.Slides per Python via Java offre diversi piani di acquisto o propone una prova gratuita e una licenza temporanea di 30 giorni per la valutazione, utilizzando le politiche di licenza e abbonamento."
type: docs
weight: 80
url: /it/python-java/licensing/
---
Talvolta, per ottenere i migliori risultati di valutazione, potrebbe essere necessario un approccio pratico. Per questo motivo, Aspose.Slides offre diversi piani di acquisto e propone anche una Prova gratuita e una Licenza temporanea di 30 giorni per la valutazione.

{{% alert color="primary" %}}
Nota che esistono diverse politiche e pratiche generali che ti guidano su come valutare, licenziare correttamente e acquistare i nostri prodotti. Puoi trovarle nella sezione ["Politiche di acquisto e FAQ"](https://purchase.aspose.com/policies).
{{% /alert %}}

## **Valutare Aspose.Slides**
Puoi scaricare facilmente Aspose.Slides per la valutazione. Il pacchetto di valutazione è identico a quello acquistato. La versione di valutazione diventa semplicemente licenziata dopo aver aggiunto alcune righe di codice per applicare la licenza. 

## **Limitazioni della versione di valutazione**
La versione di valutazione di Aspose.Slides (senza licenza specificata) fornisce tutte le funzionalità del prodotto, ma inserisce una filigrana di valutazione nella parte superiore del documento all'apertura e al salvataggio. Inoltre, sei limitato a una diapositiva quando estrai il testo dalle diapositive della presentazione.

{{% alert color="primary" %}} 
Se desideri testare Aspose.Slides senza le limitazioni della versione di valutazione, puoi richiedere una **Licenza temporanea di 30 giorni**. Consulta [How to get a Temporary License?](https://purchase.aspose.com/temporary-license) per ulteriori informazioni.
{{% /alert %}} 

## **Informazioni sulla licenza**
Puoi scaricare facilmente una versione di valutazione di Aspose.Slides per Python via Java dalla sua [pagina di download](https://releases.aspose.com/slides/it/python-java/). La versione di valutazione offre assolutamente **le stesse funzionalità** della versione con licenza di Aspose.Slides. Inoltre, la versione di valutazione diventa semplicemente licenziata dopo aver acquistato una licenza e aggiunto un paio di righe di codice per applicare la licenza.

La licenza è un file XML di testo semplice che contiene dettagli come il nome del prodotto, il numero di sviluppatori a cui è concessa la licenza, la data di scadenza dell'abbonamento e così via. Il file è firmato digitalmente, quindi non modificarlo. Anche l'aggiunta involontaria di un'interruzione di riga extra al contenuto del file lo invaliderà.

Per evitare le limitazioni associate alla versione di valutazione, è necessario impostare una licenza prima di utilizzare **Aspose.Slides**. È richiesto impostare la licenza una sola volta per applicazione o processo.

## Licenza acquistata

Dopo l'acquisto, devi applicare il file o lo stream della licenza. 

{{% alert color="primary" %}}
Devi impostare la licenza:
* solo una volta per dominio dell'applicazione
* prima di utilizzare qualsiasi altra classe Aspose.Slides
{{% /alert %}}

{{% alert color="primary" %}}
Puoi trovare le informazioni sui prezzi nella pagina ["Pricing Information"](https://purchase.aspose.com/pricing/slides/it/family).
{{% /alert %}}

### **Impostare una licenza in Aspose.Slides per Python via Java**

Le licenze possono essere applicate da queste posizioni:

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

Questo frammento di codice è usato per impostare un file di licenza:

**Python**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, License

license = License();
pres = Presentation()
license.setLicense("Aspose.Slides.lic");

jpype.shutdownJVM()
```

Quando chiami il metodo setLicense, il nome della licenza deve corrispondere al nome del tuo file di licenza. Ad esempio, puoi rinominare il file di licenza in "Aspose.Slides.lic.xml". Poi, nel tuo codice, devi passare il nuovo nome della licenza (Aspose.Slides.lic.xml) al metodo setLicense.

#### **Applicare una licenza da byte**

Questo frammento di codice è usato per applicare una licenza da byte:

**Python**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, License

license = License();
input = open("Aspose.Slides.lic", mode="rb")
data = input.read()
pres = Presentation()
license.setLicenseFromBytes(data);

jpype.shutdownJVM()
```

#### Applicare licenza a consumo

Aspose.Slides consente agli sviluppatori di applicare una chiave a consumo. Questo è un nuovo meccanismo di licenza.

Il nuovo meccanismo di licenza sarà utilizzato insieme al metodo di licenza esistente. I clienti che desiderano essere fatturati in base all'uso delle funzionalità API possono utilizzare la Licenza a consumo.

Dopo aver completato tutti i passaggi necessari per ottenere questo tipo di licenza, riceverai le chiavi, non il file di licenza. Questa chiave a consumo può essere applicata usando la classe **Metered** introdotta appositamente a questo scopo.

Il seguente esempio di codice mostra come impostare le chiavi pubbliche e private a consumo:

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, Metered, SaveFormat

# Crea un'istanza della classe CAD Metered
metered = Metered();

# Accedi alla proprietà set_metered_key e passa le chiavi pubblica e privata come parametri
metered.setMeteredKey("*****", "*****");

# Ottieni la quantità di dati a consumo prima di chiamare l'API
amountbefore = Metered.getConsumptionQuantity()

# Mostra le informazioni
print("Amount Consumed Before: \" + amountbefore + \"" )

# Carica il documento dal disco.
pres = Presentation();

# Ottieni il conteggio delle pagine del documento
print("Amount Consumed After: \" +  pres.getSlides().size()) + \"" )

# Salva come PDF
pres.save("out_pdf.pdf", SaveFormat.Pdf);

# Ottieni la quantità di dati a consumo dopo aver chiamato l'API
amountafter = Metered.getConsumptionQuantity()

# Mostra le informazioni
print("Amount Consumed After: \" + amountafter + \"" )

jpype.shutdownJVM()
```

{{% alert color="primary" %}}
Si noti che è necessario disporre di una connessione Internet stabile per l'uso corretto della licenza a consumo, poiché il meccanismo a consumo richiede un'interazione costante con i nostri servizi per effettuare i calcoli corretti. Per maggiori dettagli, consulta la sezione ["Metered Licensing FAQ"](https://purchase.aspose.com/faqs/licensing/metered).
{{% /alert %}}