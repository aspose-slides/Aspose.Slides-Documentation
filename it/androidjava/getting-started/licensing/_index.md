---
title: Licenze
type: docs
weight: 90
url: /it/androidjava/licensing/
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
- Android
- Java
- Aspose.Slides
description: "Applica, gestisci e risolvi i problemi delle licenze in Aspose.Slides per Android via Java. Assicura un accesso ininterrotto a tutte le funzionalità con la nostra guida alle licenze."
---
## **Panoramica**

Aspose.Slides può essere usato in modalità di valutazione o con una licenza valida. La versione di valutazione fornisce le stesse funzionalità della versione con licenza, ma aggiunge una filigrana di valutazione quando le presentazioni vengono aperte o salvate e limita l'estrazione del testo a una sola diapositiva.

Questo articolo spiega come funziona la licenza in Aspose.Slides e come applicare una licenza prima di usare la libreria. Una licenza può essere caricata da un file, da uno stream o da una risorsa incorporata utilizzando la classe `License`. L'articolo mostra anche come verificare se una licenza è stata applicata correttamente.

## **Valuta Aspose.Slides**

{{% alert color="info" %}} 

Puoi scaricare una versione di valutazione di **Aspose.Slides for Android via Java** dalla sua [pagina di download](https://releases.aspose.com/slides/it/androidjava/). La versione di valutazione offre le stesse funzionalità della versione con licenza del prodotto. Il pacchetto di valutazione è identico al pacchetto acquistato. La versione di valutazione diventa semplicemente licenziata dopo aver aggiunto poche righe di codice (per applicare la licenza).

Una volta soddisfatto della tua valutazione di **Aspose.Slides**, puoi [acquistare una licenza](https://purchase.aspose.com/buy). Ti consigliamo di esaminare i diversi tipi di abbonamento. Se hai domande, contatta il team commerciale di Aspose.

Ogni licenza Aspose include un abbonamento di un anno per aggiornamenti gratuiti a nuove versioni o correzioni rilasciate entro il periodo di abbonamento. Gli utenti con prodotti licenziati (o anche versioni di valutazione) ottengono supporto tecnico gratuito e illimitato.

{{% /alert %}} 

**Limitazioni della versione di valutazione**

* Sebbene la versione di valutazione di Aspose.Slides (senza licenza specificata) offra tutte le funzionalità del prodotto, inserisce una filigrana di valutazione in cima al documento durante le operazioni di apertura e salvataggio. 
* L'estrazione di testi dalle diapositive è limitata a una sola diapositiva.

{{% alert color="info" %}} 

Per testare Aspose.Slides senza limitazioni, puoi richiedere una **Licenza Temporanea di 30 giorni**. Consulta la pagina [Come ottenere una Licenza Temporanea](https://purchase.aspose.com/temporary-license) per maggiori informazioni.

{{% /alert %}}

## **Licenze in Aspose.Slides**

* Una versione di valutazione diventa licenziata dopo aver acquistato una licenza e aggiunto un paio di righe di codice (per applicare la licenza).
* La licenza è un file XML di testo semplice che contiene dettagli come il nome del prodotto, il numero di sviluppatori a cui è concessa, la data di scadenza dell'abbonamento e così via. 
* Il file di licenza è firmato digitalmente, quindi non devi modificarlo. Anche l'aggiunta involontaria di una riga vuota al contenuto del file lo rende invalido.
* Aspose.Slides for Android via Java cerca tipicamente la licenza in queste posizioni:
  * Un percorso esplicito
  * La cartella contenente Aspose.Slides.jar
* Per evitare le limitazioni associate alla versione di valutazione, è necessario impostare una licenza prima di usare **Aspose.Slides**. Devi impostare la licenza una sola volta per applicazione o processo.

## **Applicare una licenza**

Una licenza può essere caricata da un **file** o da uno **stream**.

{{% alert color="info" %}}

Aspose.Slides fornisce la classe [License](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/license/) per le operazioni di licenza.

{{% /alert %}} 

{{% alert color="warning" %}}

Le licenze nuove possono attivare Aspose.Slides solo con la versione 21.4 o successive. Le versioni precedenti usano un sistema di licenza diverso e non riconoscono queste licenze.

{{% /alert %}}

### **File**

Il metodo più semplice per impostare una licenza richiede di posizionare il file di licenza nella cartella contenente Aspose.Slides.jar o nel jar della tua applicazione.

Questo codice Java mostra come impostare un file di licenza:

``` java
// Istanzia la classe License
com.aspose.slides.License license = new com.aspose.slides.License();

// Imposta il percorso del file di licenza
license.setLicense("Aspose.Slides.Android.via.Java.lic");
```

{{% alert color="warning" %}} 

Se posizioni il file di licenza in una directory diversa, quando chiami il metodo [SetLicense](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-) il nome del file di licenza alla fine del percorso esplicito deve corrispondere esattamente al nome del tuo file di licenza.

Ad esempio, puoi cambiare il nome del file di licenza in *Aspose.Slides.Android.via.Java.lic.xml*. Quindi, nel tuo codice, devi passare il percorso al file (terminante con *Aspose.Slides.Android.via.Java.lic.xml*) al metodo [SetLicense](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-).

{{% /alert %}}

### **Stream**

Puoi caricare una licenza da uno stream. Questo codice Java mostra come applicare una licenza da uno stream:

``` java
// Istanzia la classe License
com.aspose.slides.License license = new com.aspose.slides.License();

// Imposta la licenza tramite uno stream
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Android.via.Java.lic"));
```

## **Convalidare una licenza**

Per verificare se una licenza è stata impostata correttamente, puoi convalidarla. Questo codice Java mostra come convalidare una licenza:

```java
import com.aspose.slides.*;

License license = new License();
license.setLicense("Aspose.Slides.Android.via.Java.lic");

if (license.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **Sicurezza dei thread**

{{% alert title="Nota" color="warning" %}} 

Il metodo [SetLicense](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-) non è sicuro per i thread. Se questo metodo deve essere chiamato simultaneamente da più thread, potresti voler utilizzare primitive di sincronizzazione (come un lock) per evitare problemi. 

{{% /alert %}}

## **FAQ**

### Posso applicare la licenza in un ambiente completamente offline (senza accesso a Internet)?

Sì. La convalida della licenza avviene localmente usando il file di licenza; non è necessaria alcuna connessione Internet.

### Cosa succede dopo la scadenza dell'abbonamento di un anno? La libreria smette di funzionare?

No. La licenza è perpetua: puoi continuare a usare le versioni rilasciate prima della data di scadenza del tuo abbonamento; semplicemente non potrai utilizzare versioni più recenti senza rinnovare.