---
title: Licenza
type: docs
weight: 80
url: /it/python-net/licensing/
keywords:
- licenza
- licenza temporanea
- impostare licenza
- utilizzare licenza
- validare licenza
- file di licenza
- versione di valutazione
- Python
- Aspose.Slides
description: "Scopri come applicare, gestire e risolvere i problemi delle licenze in Aspose.Slides for Python via .NET. Garantisci un accesso ininterrotto a tutte le funzionalità con la nostra guida passo-passo sulla licenza."
---
## **Panoramica**

Aspose.Slides può essere utilizzato in modalità di valutazione o con una licenza valida. La versione di valutazione fornisce la stessa funzionalità della versione con licenza, ma aggiunge una filigrana di valutazione a ogni diapositiva di ciascuna presentazione che salva e tronca il testo che il tuo codice legge dalle presentazioni.

## **Valutare Aspose.Slides**

Puoi scaricare una versione di valutazione di **Aspose.Slides for Python via .NET** dalla sua [pagina di download](https://pypi.org/project/Aspose.Slides/). La versione di valutazione fornisce le stesse funzionalità del prodotto con licenza. Il pacchetto di valutazione è identico al pacchetto acquistato e diventa con licenza dopo aver aggiunto alcune righe di codice per applicare la licenza.

Quando sei soddisfatto della tua valutazione di **Aspose.Slides**, puoi [acquistare una licenza](https://purchase.aspose.com/pricing/slides/python-net/). Ti consigliamo di esaminare le opzioni di abbonamento disponibili. Se hai domande, contatta il team di vendita di Aspose.

Ogni licenza Aspose include un abbonamento di un anno con aggiornamenti gratuiti a nuove versioni e correzioni rilasciate durante quel periodo. Sia gli utenti con licenza che quelli in valutazione ricevono supporto tecnico gratuito e illimitato.

**Limitazioni della versione di valutazione**

* La versione di valutazione (quando non è applicata alcuna licenza) fornisce piena funzionalità, ma aggiunge una casella di testo con filigrana di valutazione a ogni diapositiva di ciascuna presentazione che salva.
* Il testo che il tuo codice legge da una presentazione viene troncato ai primi caratteri, seguito da un avviso sulla limitazione di valutazione. Il testo che il tuo codice scrive viene salvato per intero.

{{% alert color="info" title="Note" %}}
Per testare Aspose.Slides senza limitazioni, puoi richiedere una **licenza temporanea di 30 giorni**. Vedi la pagina [Come ottenere una licenza temporanea](https://purchase.aspose.com/temporary-license) per i dettagli.
{{% /alert %}}

## **Licenze in Aspose.Slides**

* Una versione di valutazione diventa licenziata dopo aver acquistato una licenza e aggiunto un paio di righe di codice per applicarla.
* La licenza è un file XML di testo semplice che contiene dettagli come il nome del prodotto, il numero di sviluppatori coperti, la data di scadenza dell'abbonamento e così via.
* Il file della licenza è firmato digitalmente, quindi non devi modificarlo. Anche l'aggiunta di un singolo ritorno a capo lo invaliderà.
* Aspose.Slides for Python via .NET cerca la licenza nel percorso che gli fornisci. Un percorso relativo, o un nome file senza percorso, viene risolto rispetto alla directory di lavoro corrente, che non è necessariamente la cartella che contiene il tuo script Python.
* Per evitare le limitazioni della valutazione, imposta la licenza prima di usare Aspose.Slides. È necessario impostarla una sola volta per applicazione o processo.

{{% alert color="info" title="Note" %}}
Potresti anche voler consultare [Licenza a consumo](/slides/it/python-net/metered-licensing/).
{{% /alert %}}

## **Applicare una licenza**

Una licenza può essere caricata da un **file** o da un **stream**.

{{% alert color="info" title="Note" %}}
Aspose.Slides fornisce la classe [License](https://reference.aspose.com/slides/python-net/aspose.slides/license/) per gestire le licenze.
{{% /alert %}}

{{% alert color="warning" title="Warning" %}}
Le nuove licenze possono attivare Aspose.Slides solo a partire dalla versione 21.4 o successive. Le versioni precedenti usano un sistema di licenza diverso e non riconosceranno queste licenze.
{{% /alert %}}

### **File**

Il modo più semplice per impostare una licenza è passare il percorso del file di licenza al metodo [set_license](https://reference.aspose.com/slides/python-net/aspose.slides/license/set_license/). Se passi solo il nome del file, come nell'esempio sotto, Aspose.Slides cerca il file nella directory di lavoro corrente.

Il seguente codice Python mostra come impostare il file di licenza:

```py
import aspose.slides as slides

# Crea un'istanza della classe License. 
license = slides.License()

# Imposta il percorso del file di licenza.
license.set_license("Aspose.Slides.lic")
```

{{% alert color="warning" title="Warning" %}}
Se posizioni il file di licenza in una directory diversa, quando chiami [License.set_license](https://reference.aspose.com/slides/python-net/aspose.slides/license/set_license/#str), il nome del file alla fine del percorso esplicito deve corrispondere al nome del tuo file di licenza.

Ad esempio, puoi rinominare il file di licenza in *Aspose.Slides.lic.xml*. Quindi, nel tuo codice, passa il percorso completo a quel file (terminante con Aspose.Slides.lic.xml) al metodo [License.set_license](https://reference.aspose.com/slides/python-net/aspose.slides/license/set_license/#str).
{{% /alert %}}

### **Stream**

Puoi caricare una licenza da uno stream. Il seguente esempio Python mostra come applicare una licenza da uno stream:

```py
import aspose.slides as slides

# Crea un'istanza della classe License.
license = slides.License()

# Imposta la licenza da uno stream.
with open("Aspose.Slides.lic", "rb") as stream:
    license.set_license(stream)
```

## **Convalidare una licenza**

Per verificare che la licenza sia stata applicata correttamente, puoi convalidarla. Il seguente codice Python dimostra come convalidare una licenza:

```py
import aspose.slides as slides

license = slides.License()

license.set_license("Aspose.Slides.lic")

if license.is_licensed():
    print("License is good!")
```

## **Sicurezza dei thread**

{{% alert color="warning" title="Warning" %}}
Il metodo [License.set_license](https://reference.aspose.com/slides/python-net/aspose.slides/license/set_license/) non è thread‑safe. Se devi chiamarlo contemporaneamente da più thread, utilizza un primitive di sincronizzazione, come `threading.Lock`, per evitare problemi.
{{% /alert %}}

## **FAQ**

### Posso applicare la licenza in un ambiente completamente offline (senza accesso a Internet)?

Sì. La convalida della licenza avviene localmente utilizzando il file di licenza; non è necessaria alcuna connessione a Internet.

### Cosa succede dopo la scadenza dell'abbonamento di un anno? La libreria smetterà di funzionare?

No. La licenza è perpetua: puoi continuare a utilizzare le versioni rilasciate prima della data di fine abbonamento; semplicemente non potrai utilizzare le versioni più recenti senza rinnovare.