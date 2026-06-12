---
title: Licenze
type: docs
weight: 90
url: /it/androidjava/licensing/
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
- Android
- Java
- Aspose.Slides
description: "Applica, gestisci e risolvi i problemi delle licenze in Aspose.Slides per Android via Java. Garantisci un accesso ininterrotto a tutte le funzionalità con la nostra guida sulla licenza."
---
## **Panoramica**

Aspose.Slides può essere utilizzato in modalità di valutazione o con una licenza valida. La versione di valutazione fornisce le stesse funzionalità della versione con licenza, ma aggiunge una filigrana di valutazione quando le presentazioni vengono aperte o salvate e limita l’estrazione del testo a una diapositiva.

Questo articolo spiega come funziona la licenza in Aspose.Slides e come applicare una licenza prima di utilizzare la libreria. Una licenza può essere caricata da un file, da uno stream o da una risorsa incorporata utilizzando la classe `License`. L’articolo mostra anche come convalidare se una licenza è stata applicata correttamente.

## **Valutare Aspose.Slides**

{{% alert color="primary" %}} 

Puoi scaricare una versione di valutazione di **Aspose.Slides for Android via Java** dalla sua [pagina di download](https://releases.aspose.com/slides/it/androidjava/). La versione di valutazione offre le stesse funzionalità della versione con licenza del prodotto. Il pacchetto di valutazione è identico a quello acquistato. La versione di valutazione diventa semplicemente con licenza dopo aver aggiunto qualche riga di codice (per applicare la licenza).

Una volta soddisfatto della tua valutazione di **Aspose.Slides**, puoi [acquistare una licenza](https://purchase.aspose.com/buy). Ti consigliamo di esaminare i diversi tipi di abbonamento. Se hai domande, contatta il team commerciale di Aspose.

Ogni licenza Aspose include un abbonamento di un anno per aggiornamenti gratuiti a nuove versioni o correzioni rilasciate durante il periodo di abbonamento. Gli utenti con prodotti con licenza (o anche versioni di valutazione) ottengono supporto tecnico gratuito e illimitato.

{{% /alert %}} 

**Limitazioni della versione di valutazione**

* Sebbene la versione di valutazione di Aspose.Slides (senza una licenza specificata) fornisca tutte le funzionalità del prodotto, inserisce una filigrana di valutazione nella parte superiore del documento durante le operazioni di apertura e salvataggio. 
* Sei limitato a una sola diapositiva quando estrai il testo dalle presentazioni.

{{% alert color="primary" %}} 

Per testare Aspose.Slides senza limitazioni, puoi richiedere una **Licenza Temporanea di 30 giorni**. Consulta la pagina [How to get a Temporary License](https://purchase.aspose.com/temporary-license) per ulteriori informazioni.

{{% /alert %}}

## **Licenze in Aspose.Slides**

* Una versione di valutazione diventa con licenza dopo aver acquistato una licenza e aggiunto un paio di righe di codice (per applicare la licenza).
* La licenza è un file XML di testo semplice che contiene dettagli come il nome del prodotto, il numero di sviluppatori a cui è concessa, la data di scadenza dell’abbonamento e così via. 
* Il file di licenza è firmato digitalmente, quindi non devi modificarlo. Anche una singola aggiunta involontaria di un ritorno a capo al contenuto del file lo renderà non valido.
* Aspose.Slides for Android via Java tenta tipicamente di trovare la licenza in queste posizioni:
  * Un percorso esplicito
  * La cartella contenente Aspose.Slides.jar
* Per evitare le limitazioni associate alla versione di valutazione, devi impostare una licenza prima di utilizzare **Aspose.Slides**. È necessario impostare la licenza una sola volta per applicazione o processo.

## **Applicare una licenza**

Una licenza può essere caricata da un **file** o da **uno stream**.

{{% alert color="primary" %}}

Aspose.Slides fornisce la classe [License](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/license/) per le operazioni di licenza.

{{% /alert %}} 

{{% alert color="warning" %}}

Le nuove licenze possono attivare Aspose.Slides solo a partire dalla versione 21.4. Le versioni precedenti utilizzano un sistema di licenza diverso e non riconoscono queste licenze.

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

Se posizioni il file di licenza in una directory diversa, quando chiami il metodo [SetLicense](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-) il nome del file di licenza alla fine del percorso esplicito specificato deve corrispondere al nome del tuo file di licenza.

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

## **Convalidare una Licenza**

Per verificare se una licenza è stata impostata correttamente, puoi convalidarla. Questo codice Java mostra come convalidare una licenza:

```java
License license = new License();
license.setLicense("Aspose.Slides.Android.via.Java.lic");

if (License.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **Sicurezza dei Thread**

{{% alert title="Note" color="warning" %}} 

Il metodo [SetLicense](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-) non è thread‑safe. Se questo metodo deve essere chiamato simultaneamente da più thread, potresti voler utilizzare primitive di sincronizzazione (come un lock) per evitare problemi. 

{{% /alert %}}

## **FAQ**

**Posso applicare la licenza in un ambiente completamente offline (senza accesso a Internet)?**

Sì. La convalida della licenza avviene localmente usando il file di licenza; non è necessaria alcuna connessione a Internet.

**Cosa succede dopo la scadenza dell’abbonamento di un anno? La libreria smetterà di funzionare?**

No. La licenza è perpetua: puoi continuare a utilizzare le versioni rilasciate prima della data di scadenza del tuo abbonamento; semplicemente non potrai utilizzare versioni più recenti senza rinnovare.