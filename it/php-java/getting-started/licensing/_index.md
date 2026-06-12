---
title: Licenza
type: docs
weight: 80
url: /it/php-java/licensing/
keywords:
- licenza
- licenza temporanea
- imposta licenza
- utilizza licenza
- convalida licenza
- file di licenza
- versione di valutazione
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Applica, gestisci e risolvi i problemi delle licenze in Aspose.Slides per PHP via Java. Garantisci accesso ininterrotto a tutte le funzionalità con la nostra guida passo-passo sulla licenza."
---
## **Introduzione**

A volte, per ottenere i migliori risultati di valutazione, può essere necessario un approccio pratico. Per questo motivo, Aspose.Slides offre diversi piani di acquisto e propone anche una Prova Gratuita e una Licenza Temporanea di 30 giorni per la valutazione.

{{% alert color="primary" %}}
Nota che esistono numerose politiche e pratiche generali che ti guidano su come valutare, licenziare correttamente e acquistare i nostri prodotti. Puoi trovarle nella sezione ["Politiche di Acquisto e FAQ"](https://purchase.aspose.com/policies).
{{% /alert %}}

## **Valuta Aspose.Slides**
Puoi scaricare facilmente Aspose.Slides per la valutazione. Il pacchetto di valutazione è identico a quello acquistato. La versione di valutazione diventa semplicemente licenziata dopo aver aggiunto qualche riga di codice per applicare la licenza. 

## **Limitazioni della Versione di Valutazione**
La versione di valutazione di Aspose.Slides (senza una licenza specificata) fornisce tutte le funzionalità del prodotto, ma inserisce una filigrana di valutazione nella parte superiore del documento all'apertura e al salvataggio. Inoltre, sei limitato a una diapositiva quando estrai testi dalle diapositive della presentazione.

{{% alert color="primary" %}} 
Se vuoi testare Aspose.Slides senza le limitazioni della versione di valutazione, puoi richiedere una **Licenza Temporanea di 30 giorni**. Consulta [Come ottenere una Licenza Temporanea?](https://purchase.aspose.com/temporary-license) per ulteriori informazioni.
{{% /alert %}} 

## **Informazioni sulla Licenza**
Puoi scaricare facilmente una versione di valutazione di Aspose.Slides per PHP via Java dalla sua [pagina di download](https://packagist.org/packages/aspose/slides). La versione di valutazione fornisce assolutamente **le stesse funzionalità** della versione licenziata di Aspose.Slides. Inoltre, la versione di valutazione diventa semplicemente licenziata dopo aver acquistato una licenza e aggiunto un paio di righe di codice per applicare la licenza.

La licenza è un file XML di testo semplice che contiene dettagli come il nome del prodotto, il numero di sviluppatori a cui è concessa, la data di scadenza dell'abbonamento e così via. Il file è firmato digitalmente, quindi non modificarlo. Anche l'aggiunta accidentale di una riga vuota al contenuto del file lo renderà invalido.

Per evitare le limitazioni associate alla versione di valutazione, è necessario impostare una licenza prima di utilizzare **Aspose.Slides**. È necessario impostare la licenza una sola volta per applicazione o processo.

{{% alert color="primary" %}} 
Potresti voler consultare [Licenza a Consumo](https://docs.aspose.com/slides/it/php-java/metered-licensing/).
{{% /alert %}} 

## **Licenza Acquistata**

Dopo l'acquisto, è necessario applicare il file o lo stream della licenza. 

{{% alert color="primary" %}}
Devi impostare la licenza:
* solo una volta per dominio dell'applicazione
* prima di utilizzare qualsiasi altra classe di Aspose.Slides
{{% /alert %}}

{{% alert color="primary" %}}
Puoi trovare le informazioni sui prezzi nella pagina [“Informazioni sui Prezzi”](https://purchase.aspose.com/pricing/slides/it/family).
{{% /alert %}}

### **Imposta una Licenza in Aspose.Slides per PHP via Java**

Le licenze possono essere applicate da queste posizioni:

* Percorso esplicito
* Stream
* Come Licenza a Consumo – un nuovo meccanismo di licenza

{{% alert color="primary" %}}
Usa il metodo **setLicense** per licenziare un componente.

Sebbene più chiamate a **setLicense** non siano dannose, sono uno spreco di risorse (processore).
{{% /alert %}}

{{% alert color="warning" %}}
Le nuove licenze possono attivare Aspose.Slides solo a partire dalla versione 21.4 o successive. Le versioni precedenti utilizzano un sistema di licenza diverso e non riconosceranno queste licenze.
{{% /alert %}}

#### **Applica una Licenza Utilizzando un File**

Questo frammento di codice è usato per impostare un file di licenza:

**PHP**

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\License;

$license = new License();
$license->setLicense("Aspose.Slides.lic");
?>
```

Quando chiami il metodo setLicense, il nome della licenza deve coincidere con quello del tuo file di licenza. Per esempio, puoi rinominare il file di licenza in "Aspose.Slides.lic.xml". Poi, nel tuo codice, devi passare il nuovo nome della licenza (Aspose.Slides.lic.xml) al metodo setLicense.

#### **Applica una Licenza da uno Stream**

Questo frammento di codice è usato per applicare una licenza da uno stream:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\License;

$license = new License();
$license->setLicense($stream);
?>
```

## **FAQ**

**Posso applicare la licenza in un ambiente completamente offline (senza accesso a internet)?**

Sì. La convalida della licenza viene eseguita localmente utilizzando il file di licenza; non è necessaria alcuna connessione a internet.

**Cosa succede dopo la scadenza dell'abbonamento di un anno? La libreria smetterà di funzionare?**

No. La licenza è perpetua: puoi continuare a utilizzare le versioni rilasciate prima della data di scadenza dell'abbonamento; semplicemente non potrai utilizzare le versioni più recenti senza rinnovare.