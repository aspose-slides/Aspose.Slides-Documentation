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
- convalidare licenza
- file di licenza
- versione di valutazione
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Applica, gestisci e risolvi i problemi delle licenze in Aspose.Slides per Java. Garantisci un accesso ininterrotto a tutte le funzionalità con la nostra guida passo passo sulla gestione delle licenze."
---
## **Panoramica**

Aspose.Slides può essere utilizzato in modalità di valutazione o con una licenza valida. La versione di valutazione fornisce le stesse funzionalità della versione con licenza, ma aggiunge una filigrana di valutazione quando le presentazioni vengono aperte o salvate e limita l'estrazione del testo a una sola diapositiva.

Questo articolo spiega come funziona la gestione delle licenze in Aspose.Slides e come applicare una licenza prima di utilizzare la libreria. Una licenza può essere caricata da un file, da uno stream o da una risorsa incorporata utilizzando la classe `License`. L'articolo mostra inoltre come convalidare se una licenza è stata applicata correttamente.

## **Valuta Aspose.Slides**

{{% alert color="primary" %}} 

È possibile scaricare una versione di valutazione di **Aspose.Slides for Java** dalla sua [pagina di download](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). La versione di valutazione fornisce le stesse funzionalità della versione con licenza del prodotto. Il pacchetto di valutazione è identico a quello acquistato. La versione di valutazione diventa semplicemente con licenza dopo aver aggiunto alcune righe di codice (per applicare la licenza).

Una volta soddisfatti della valutazione di **Aspose.Slides**, è possibile [acquistare una licenza](https://purchase.aspose.com/buy). Si consiglia di esaminare i diversi tipi di abbonamento. Per domande, contattare il team commerciale di Aspose.

Ogni licenza Aspose include un abbonamento di un anno per aggiornamenti gratuiti a nuove versioni o correzioni rilasciate durante il periodo di abbonamento. Gli utenti con prodotti con licenza (o anche versioni di valutazione) ricevono supporto tecnico gratuito e illimitato.

{{% /alert %}} 

**Limitazioni della versione di valutazione**

* Sebbene la versione di valutazione di Aspose.Slides (senza licenza specificata) fornisca tutte le funzionalità del prodotto, inserisce una filigrana di valutazione nella parte superiore del documento durante le operazioni di apertura e salvataggio. 
* L'estrazione del testo dalle diapositive è limitata a una sola diapositiva.

{{% alert color="primary" %}} 

Per testare Aspose.Slides senza limitazioni, è possibile richiedere una **Licenza Temporanea di 30 giorni**. Consultare la pagina [Come ottenere una Licenza Temporanea](https://purchase.aspose.com/temporary-license) per ulteriori informazioni.

{{% /alert %}}

## **Licenze in Aspose.Slides**

* Una versione di valutazione diventa con licenza dopo aver acquistato una licenza e aggiunto qualche riga di codice (per applicare la licenza).
* La licenza è un file XML di testo semplice che contiene dettagli come il nome del prodotto, il numero di sviluppatori a cui è concessa, la data di scadenza dell'abbonamento e così via. 
* Il file di licenza è firmato digitalmente, quindi non deve essere modificato. Anche l'aggiunta involontaria di un ritorno a capo extra al contenuto del file ne invaliderà la validità.
* Aspose.Slides per Java normalmente tenta di trovare la licenza nei seguenti percorsi:
  * Un percorso esplicito
  * La cartella contenente Aspose.Slides.jar
* Per evitare le limitazioni associate alla versione di valutazione, è necessario impostare una licenza prima di utilizzare **Aspose.Slides**. È necessario impostare la licenza una sola volta per applicazione o processo.

{{% alert color="primary" %}} 

Potresti voler consultare [Licenza a consumo](/slides/it/java/metered-licensing/).

{{% /alert %}} 


## **Applicare una licenza**

Una licenza può essere caricata da un **file** o da uno **stream**.

{{% alert color="primary" %}}

Aspose.Slides fornisce la classe [License](https://reference.aspose.com/slides/it/java/com.aspose.slides/License) per le operazioni di licenza.

{{% /alert %}} 

{{% alert color="warning" %}}

Le nuove licenze possono attivare Aspose.Slides solo con la versione 21.4 o successive. Le versioni precedenti utilizzano un sistema di licenza diverso e non riconosceranno queste licenze.

{{% /alert %}}

### **File**

Il metodo più semplice per impostare una licenza richiede di posizionare il file di licenza nella cartella contenente Aspose.Slides.jar o il jar della tua applicazione.

Questo codice Java mostra come impostare un file di licenza:

``` java
// Istanzia la classe License
com.aspose.slides.License license = new com.aspose.slides.License();

// Imposta il percorso del file di licenza
license.setLicense("Aspose.Slides.Java.lic");
```

{{% alert color="warning" %}} 

Se posizioni il file di licenza in una directory diversa, quando chiami il metodo [SetLicense](https://reference.aspose.com/slides/it/java/com.aspose.slides/License#setLicense-java.lang.String-) il nome del file di licenza alla fine del percorso esplicito specificato deve corrispondere al nome del tuo file di licenza.

Ad esempio, puoi cambiare il nome del file di licenza in *Aspose.Slides.Java.lic.xml*. Quindi, nel tuo codice, devi passare al metodo [SetLicense](https://reference.aspose.com/slides/it/java/com.aspose.slides/License#setLicense-java.lang.String-) il percorso del file (che termina con *Aspose.Slides.Java.lic.xml*).

{{% /alert %}}

### **Stream**

È possibile caricare una licenza da uno stream. Questo codice Java mostra come applicare una licenza da uno stream:

``` java
// Istanzia la classe License
com.aspose.slides.License license = new com.aspose.slides.License();

// Imposta la licenza tramite uno stream
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Java.lic"));
```

### **Bridge PHP/Java**

Se utilizzi Aspose.Slides per PHP tramite Java, puoi impostare una licenza attraverso un bridge PHP/Java. Questo bridge consente di utilizzare le classi Java nella sintassi PHP. Per ulteriori informazioni, consulta [Licenza in PHP](/slides/it/php-java/licensing/).

## **Convalidare una licenza**

Per verificare se una licenza è stata impostata correttamente, è possibile convalidarla. Questo codice Java mostra come convalidare una licenza:

```java
License license = new License();
license.setLicense("Aspose.Slides.Java.lic");

if (License.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **Sicurezza dei thread**

{{% alert title="Note" color="warning" %}} 

Il metodo [SetLicense](https://reference.aspose.com/slides/it/java/com.aspose.slides/License#setLicense-java.io.InputStream-) non è thread‑safe. Se questo metodo deve essere chiamato simultaneamente da più thread, potresti voler utilizzare primitive di sincronizzazione (come un lock) per evitare problemi. 

{{% /alert %}}

## **FAQ**

**Posso applicare la licenza in un ambiente completamente offline (senza accesso a internet)?**

Sì. La convalida della licenza viene eseguita localmente utilizzando il file di licenza; non è necessaria alcuna connessione a internet.

**Cosa succede quando scade l'abbonamento di un anno? La libreria smetterà di funzionare?**

No. La licenza è perpetua: è possibile continuare a utilizzare le versioni rilasciate prima della data di scadenza dell'abbonamento; semplicemente non sarà possibile utilizzare le versioni più recenti senza rinnovare.