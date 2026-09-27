---
title: Licenze
type: docs
weight: 90
url: /it/java/licensing/
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
- Java
- Aspose.Slides
description: "Applica, gestisci e risolvi i problemi di licenza in Aspose.Slides per Java. Garantisci l'accesso continuo a tutte le funzionalità con la nostra guida passo passo sulla licenza."
---
## **Panoramica**

Aspose.Slides può essere utilizzato in modalità valutazione o con una licenza valida. La versione di valutazione fornisce le stesse funzionalità della versione con licenza, ma aggiunge una filigrana di valutazione a ogni slide di ogni presentazione salvata e tronca il testo che il tuo codice legge attraverso l'API.

Questo articolo spiega come funziona la licenza in Aspose.Slides e come applicare una licenza prima di utilizzare la libreria. Una licenza può essere caricata da un file, stream o risorsa incorporata utilizzando la classe `License`. L'articolo mostra anche come convalidare se una licenza è stata applicata correttamente.

## **Valutare Aspose.Slides**

{{% alert color="info" title="Note" %}}

Puoi scaricare una versione di valutazione di **Aspose.Slides for Java** dalla sua [pagina di download](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). La versione di valutazione fornisce le stesse funzionalità della versione con licenza del prodotto. Il pacchetto di valutazione è identico a quello acquistato. La versione di valutazione diventa semplicemente licenziata dopo aver aggiunto alcune righe di codice (per applicare la licenza).

Una volta soddisfatto della tua valutazione di **Aspose.Slides**, puoi [acquistare una licenza](https://purchase.aspose.com/pricing/slides/java/). Ti consigliamo di esaminare i diversi tipi di abbonamento. Se hai domande, contatta il team di vendita di Aspose.

Ogni licenza Aspose include un abbonamento di un anno per aggiornamenti gratuiti a nuove versioni o correzioni rilasciate entro il periodo di abbonamento. Gli utenti con prodotti con licenza (o anche versioni di valutazione) ottengono supporto tecnico gratuito e illimitato.

{{% /alert %}} 

**Limitazioni della versione di valutazione**

* La versione di valutazione (senza una licenza specificata) fornisce la piena funzionalità del prodotto, ma aggiunge una casella di testo con filigrana di valutazione a ogni slide di ogni presentazione salvata.
* Il testo che il tuo codice legge tramite l'API, incluso il testo appena impostato, viene troncato ai primi caratteri, seguito da un avviso sulla limitazione di valutazione. Il testo che il tuo codice scrive viene salvato per intero.

{{% alert color="info" title="Note" %}}

Per testare Aspose.Slides senza limitazioni, puoi richiedere una **Licenza Temporanea di 30 giorni**. Consulta la pagina [How to get a Temporary License](https://purchase.aspose.com/temporary-license) per ulteriori informazioni.

{{% /alert %}}

## **Licenze in Aspose.Slides**

* Una versione di valutazione diventa licenziata dopo aver acquistato una licenza e aver aggiunto un paio di righe di codice (per applicare la licenza).
* La licenza è un file XML di testo semplice che contiene dettagli come il nome del prodotto, il numero di sviluppatori a cui è concessa, la data di scadenza dell'abbonamento, ecc.
* Il file di licenza è firmato digitalmente, quindi non devi modificarlo. Anche l'aggiunta involontaria di un'interruzione di riga al contenuto del file lo invaliderà.
* Aspose.Slides for Java cerca tipicamente la licenza in queste posizioni:
  * Un percorso esplicito
  * La cartella contenente Aspose.Slides.jar
* Per evitare le limitazioni associate alla versione di valutazione, è necessario impostare una licenza prima di usare **Aspose.Slides**. È necessario impostare la licenza una sola volta per applicazione o processo.

{{% alert color="info" title="Note" %}}

Potresti voler consultare [Metered Licensing](/slides/it/java/metered-licensing/).

{{% /alert %}} 


## **Applicare una licenza**

Una licenza può essere caricata da un **file** o da **stream**.

{{% alert color="info" title="Note" %}}

Aspose.Slides fornisce la classe [License](https://reference.aspose.com/slides/java/com.aspose.slides/license/) per le operazioni di licenza.

{{% /alert %}} 

{{% alert color="warning" title="Warning" %}}

Le nuove licenze possono attivare Aspose.Slides solo con la versione 21.4 o successive. Le versioni precedenti usano un sistema di licenza diverso e non riconosceranno queste licenze.

{{% /alert %}}

### **File**

Il metodo più semplice per impostare una licenza richiede di posizionare il file di licenza nella cartella contenente Aspose.Slides.jar o nel jar della tua applicazione.

Questo codice Java mostra come impostare un file di licenza:

``` java
// Istanzia la classe License
com.aspose.slides.License license = new com.aspose.slides.License();

// Imposta il percorso del file di licenza
license.setLicense("Aspose.Slides.Java.lic");
```

{{% alert color="warning" title="Warning" %}}

Se posizioni il file di licenza in una directory diversa, quando chiami il metodo [setLicense](https://reference.aspose.com/slides/java/com.aspose.slides/license/#setLicense-java.lang.String-) il nome del file di licenza alla fine del percorso specificato deve coincidere con il nome del tuo file di licenza.

Ad esempio, puoi cambiare il nome del file di licenza in *Aspose.Slides.Java.lic.xml*. Quindi, nel tuo codice, devi passare il percorso al file (termine con *Aspose.Slides.Java.lic.xml*) al metodo [setLicense](https://reference.aspose.com/slides/java/com.aspose.slides/license/#setLicense-java.lang.String-).

{{% /alert %}}

### **Stream**

Puoi caricare una licenza da uno stream. Questo codice Java mostra come applicare una licenza da uno stream:

``` java
// Istanzia la classe License
com.aspose.slides.License license = new com.aspose.slides.License();

// Imposta la licenza tramite uno stream
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Java.lic"));
```

### **PHP/Java Bridge**

Se usi Aspose.Slides for PHP tramite Java, puoi impostare una licenza attraverso un bridge PHP/Java. Questo bridge consente di utilizzare classi Java con sintassi PHP. Per ulteriori informazioni, consulta [License in PHP](/slides/it/php-java/licensing/).

## **Convalidare una licenza**

Per verificare se una licenza è stata impostata correttamente, è possibile convalidarla. Questo codice Java mostra come convalidare una licenza:

```java
import com.aspose.slides.*;

License license = new License();
license.setLicense("Aspose.Slides.Java.lic");

if (license.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **Sicurezza dei thread**

{{% alert color="warning" title="Warning" %}}

Il metodo [setLicense](https://reference.aspose.com/slides/java/com.aspose.slides/license/#setLicense-java.io.InputStream-) non è thread‑safe. Se questo metodo deve essere chiamato simultaneamente da più thread, potresti voler utilizzare primitive di sincronizzazione (come un lock) per evitare problemi.

{{% /alert %}}

## **FAQ**

### Posso applicare la licenza in un ambiente completamente offline (senza accesso a Internet)?

Sì. La convalida della licenza avviene localmente usando il file di licenza; non è necessaria una connessione a Internet.

### Cosa succede dopo la scadenza dell'abbonamento di un anno? La libreria smetterà di funzionare?

No. La licenza è perpetua: puoi continuare a utilizzare le versioni rilasciate prima della data di fine abbonamento; semplicemente non potrai utilizzare le versioni più recenti senza rinnovare.