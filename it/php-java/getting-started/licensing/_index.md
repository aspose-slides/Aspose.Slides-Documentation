---
title: Licenze
type: docs
weight: 80
url: /it/php-java/licensing/
keywords:
- licenza
- licenza temporanea
- imposta licenza
- usare licenza
- convalida licenza
- file di licenza
- versione di valutazione
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Applica, gestisci e risolvi i problemi delle licenze in Aspose.Slides per PHP via Java. Garantisci un accesso ininterrotto a tutte le funzionalità con la nostra guida passo-passo sulla licenza."
---
## **Introduzione**

A volte, per ottenere i migliori risultati di valutazione, potrebbe essere necessario un approccio pratico. Per questo motivo, Aspose.Slides offre diversi piani di acquisto e anche una Prova Gratuita e una Licenza Temporanea di 30 giorni per la valutazione.

{{% alert color="info" title="Note" %}}
Nota che esistono numerose politiche e pratiche generali che ti guidano su come valutare, licenziare correttamente e acquistare i nostri prodotti. Puoi trovarle nella sezione ["Politiche di Acquisto e FAQ"](https://purchase.aspose.com/policies).
{{% /alert %}}

## **Valutare Aspose.Slides**
Puoi scaricare facilmente Aspose.Slides per la valutazione. Il pacchetto di valutazione è lo stesso del pacchetto acquistato. La versione di valutazione diventa semplicemente licenziata dopo aver aggiunto qualche riga di codice per applicare la licenza.

## **Limitazioni della Versione di Valutazione**
La versione di valutazione di Aspose.Slides (senza una licenza specificata) fornisce la piena funzionalità del prodotto, con due limitazioni:

* Aggiunge una casella di testo con filigrana di valutazione al centro di ogni diapositiva di ogni presentazione che salva.
* Il testo che il tuo codice legge da una presentazione viene troncato ai primi caratteri, seguito da un avviso sulla limitazione di valutazione. Il testo che il tuo codice scrive viene salvato per intero.

{{% alert color="info" title="Note" %}}
Se vuoi testare Aspose.Slides senza le limitazioni della versione di valutazione, puoi richiedere una **Licenza Temporanea di 30 giorni**. Consulta [How to get a Temporary License?](https://purchase.aspose.com/temporary-license) per maggiori informazioni.
{{% /alert %}}

## **Informazioni sulla Licenza**
Puoi scaricare facilmente una versione di valutazione di Aspose.Slides per PHP via Java dalla sua [pagina di download](https://packagist.org/packages/aspose/slides). La versione di valutazione fornisce assolutamente **le stesse capacità** della versione con licenza di Aspose.Slides. Inoltre, la versione di valutazione diventa semplicemente licenziata dopo aver acquistato una licenza e aggiunto un paio di righe di codice per applicare la licenza.

La licenza è un file XML di testo semplice che contiene dettagli come il nome del prodotto, il numero di sviluppatori a cui è concessa, la data di scadenza dell'abbonamento e così via. Il file è firmato digitalmente, quindi non modificarlo. Anche l'aggiunta involontaria di un ritorno a capo extra al contenuto del file lo invaliderà.

Per evitare le limitazioni associate alla versione di valutazione, è necessario impostare una licenza prima di utilizzare **Aspose.Slides**. È necessario impostare la licenza una sola volta per applicazione o processo.

{{% alert color="info" title="Note" %}}
Potresti voler vedere [Metered Licensing](/slides/it/php-java/metered-licensing/).
{{% /alert %}}

## **Licenza Acquistata**
Dopo l'acquisto, è necessario applicare il file o lo stream della licenza.

{{% alert color="info" title="Note" %}}
È necessario impostare la licenza:
* solo una volta per dominio dell'applicazione
* prima di utilizzare qualsiasi altra classe di Aspose.Slides
{{% /alert %}}

{{% alert color="info" title="Note" %}}
Puoi trovare le informazioni sui prezzi nella pagina [“Pricing Information”](https://purchase.aspose.com/pricing/slides/it/family).
{{% /alert %}}

### **Imposta una Licenza in Aspose.Slides per PHP via Java**
Le licenze possono essere applicate da queste posizioni:

* Percorso esplicito
* Stream
* Come Licenza a Consumo – un nuovo meccanismo di licenza

{{% alert color="info" title="Note" %}}
Utilizza il metodo **setLicense** per licenziare un componente.

Sebbene più chiamate a **setLicense** non siano dannose, sono uno spreco di risorse (processore).
{{% /alert %}}

{{% alert color="warning" title="Warning" %}}
Le nuove licenze possono attivare Aspose.Slides solo con la versione 21.4 o successive. Le versioni precedenti utilizzano un sistema di licenza diverso e non riconosceranno queste licenze.
{{% /alert %}}

#### **Applica una Licenza Utilizzando un File**
Questo frammento di codice viene usato per impostare un file di licenza:

**PHP**

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/it/lib/aspose.slides.php");

use aspose\slides\License;

$license = new License();
$license->setLicense(__DIR__ . "/Aspose.Slides.lic");
```

Il campione si aspetta il file di licenza accanto allo script e passa il suo percorso assoluto: Aspose.Slides viene eseguito all'interno di Tomcat, quindi non risolve un percorso relativo rispetto alla cartella del tuo script. Quando chiami il metodo setLicense, il nome della licenza deve essere lo stesso del tuo file di licenza. Per esempio, puoi cambiare il nome del file di licenza in "Aspose.Slides.lic.xml". Quindi, nel tuo codice, devi passare il nuovo nome della licenza (Aspose.Slides.lic.xml) al metodo setLicense.

#### **Applica una Licenza da uno Stream**
Questo frammento di codice viene usato per applicare una licenza da uno stream:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/it/lib/aspose.slides.php");

use aspose\slides\License;

$stream = new Java("java.io.FileInputStream", __DIR__ . "/Aspose.Slides.lic");

$license = new License();
$license->setLicense($stream);

$stream->close();
```

## **FAQ**

### Posso applicare la licenza in un ambiente completamente offline (senza accesso a internet)?
Sì. La convalida della licenza viene eseguita localmente usando il file di licenza; non è necessaria alcuna connessione a internet.

### Cosa succede quando scade l'abbonamento di un anno? La libreria smetterà di funzionare?
No. La licenza è perpetua: puoi continuare a usare le versioni rilasciate prima della data di scadenza del tuo abbonamento; semplicemente non sarai idoneo a utilizzare versioni più recenti senza rinnovare.