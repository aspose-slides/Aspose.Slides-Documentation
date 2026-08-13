---
title: Licenza
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
description: "Applica, gestisci e risolvi i problemi delle licenze in Aspose.Slides per Java. Garantisci accesso ininterrotto a tutte le funzionalità con la nostra guida passo‑passo alla licenza."
---
## **Panoramica**

Aspose.Slides può essere utilizzato in modalità di valutazione o con una licenza valida. La versione di valutazione fornisce la stessa funzionalità della versione con licenza, ma aggiunge una filigrana di valutazione quando le presentazioni vengono aperte o salvate e limita l'estrazione del testo a una diapositiva.

Questo articolo spiega come funzionano le licenze in Aspose.Slides e come applicare una licenza prima di utilizzare la libreria. Una licenza può essere caricata da un file, uno stream o una risorsa incorporata utilizzando la classe `License`. L'articolo mostra anche come convalidare se una licenza è stata applicata correttamente.

## **Valuta Aspose.Slides**

{{% alert color="info" %}} 

Puoi scaricare una versione di valutazione di **Aspose.Slides for Java** dalla sua [pagina di download](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). La versione di valutazione fornisce le stesse funzionalità della versione con licenza del prodotto. Il pacchetto di valutazione è identico al pacchetto acquistato. La versione di valutazione diventa semplicemente licenziata dopo aver aggiunto alcune righe di codice (per applicare la licenza).

Una volta terminata la tua valutazione di **Aspose.Slides**, puoi [acquistare una licenza](https://purchase.aspose.com/buy). Ti consigliamo di esplorare i diversi tipi di abbonamento. Se hai domande, contatta il team commerciale di Aspose.

Ogni licenza Aspose include un abbonamento di un anno per aggiornamenti gratuiti a nuove versioni o correzioni rilasciate entro il periodo di abbonamento. Gli utenti con prodotti con licenza (o anche versioni di valutazione) ottengono supporto tecnico gratuito e illimitato.

{{% /alert %}} 

**Limitazioni della versione di valutazione**

* Mentre la versione di valutazione di Aspose.Slides (senza licenza specificata) fornisce la piena funzionalità del prodotto, inserisce una filigrana di valutazione nella parte superiore del documento durante le operazioni di apertura e salvataggio. 
* Sei limitato a una diapositiva quando estrai testi dalle diapositive della presentazione.

{{% alert color="info" %}} 

Per testare Aspose.Slides senza limitazioni, puoi richiedere una **Licenza Temporanea di 30 Giorni**. Consulta la pagina [Come ottenere una Licenza Temporanea](https://purchase.aspose.com/temporary-license) per ulteriori informazioni.

{{% /alert %}}

## **Licenze in Aspose.Slides**

* Una versione di valutazione diventa licenziata dopo aver acquistato una licenza e aver aggiunto un paio di righe di codice (per applicare la licenza).
* La licenza è un file XML di testo semplice che contiene dettagli come il nome del prodotto, il numero di sviluppatori a cui è concessa, la data di scadenza dell'abbonamento e così via. 
* Il file di licenza è firmato digitalmente, quindi non devi modificare il file. Anche l'aggiunta involontaria di una riga vuota al contenuto invaliderà la licenza.
* Aspose.Slides for Java tenta tipicamente di trovare la licenza in queste posizioni:
  * Un percorso esplicito
  * La cartella contenente Aspose.Slides.jar
* Per evitare le limitazioni associate alla versione di valutazione, è necessario impostare una licenza prima di utilizzare **Aspose.Slides**. Devi impostare una licenza una sola volta per applicazione o processo.

{{% alert color="info" %}} 

Potresti voler vedere [Licenza a consumo](/slides/it/java/metered-licensing/).

{{% /alert %}} 


## **Applicare una Licenza**

Una licenza può essere caricata da un **file** o da uno **stream**.

{{% alert color="info" %}}

Aspose.Slides fornisce la classe [License](https://reference.aspose.com/slides/it/java/com.aspose.slides/License) per le operazioni di licenziamento.

{{% /alert %}} 

{{% alert color="warning" %}}

Le nuove licenze possono attivare Aspose.Slides solo con la versione 21.4 o successive. Le versioni precedenti utilizzano un sistema di licenza differente e non riconosceranno queste licenze.

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

Ad esempio, puoi cambiare il nome del file di licenza in *Aspose.Slides.Java.lic.xml*. Quindi, nel tuo codice, devi passare il percorso al file (terminante con *Aspose.Slides.Java.lic.xml*) al metodo [SetLicense](https://reference.aspose.com/slides/it/java/com.aspose.slides/License#setLicense-java.lang.String-).

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

Se utilizzi Aspose.Slides per PHP tramite Java, puoi impostare una licenza tramite un bridge PHP/Java. Questo bridge consente di usare classi Java nella sintassi PHP. Per ulteriori informazioni, consulta [License in PHP](/slides/it/php-java/licensing/).

## **Validare una Licenza**

Per verificare se una licenza è stata impostata correttamente, puoi validararla. Questo codice Java mostra come validare una licenza:

```java
import com.aspose.slides.*;

License license = new License();
license.setLicense("Aspose.Slides.Java.lic");

if (license.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **Sicurezza dei Thread**

{{% alert title="Nota" color="warning" %}} 

Il metodo [SetLicense](https://reference.aspose.com/slides/it/java/com.aspose.slides/License#setLicense-java.io.InputStream-) non è thread‑safe. Se questo metodo deve essere chiamato simultaneamente da più thread, potresti voler usare primitive di sincronizzazione (come un lock) per evitare problemi. 

{{% /alert %}}

## **FAQ**

### Posso applicare la licenza in un ambiente completamente offline (senza accesso a Internet)?

Sì. La convalida della licenza avviene localmente utilizzando il file di licenza; non è necessaria alcuna connessione a Internet.

### Cosa succede dopo la scadenza dell'abbonamento di un anno? La libreria smetterà di funzionare?

No. La licenza è perpetua: puoi continuare a utilizzare le versioni rilasciate prima della data di fine abbonamento; semplicemente non avrai diritto a utilizzare versioni più recenti senza rinnovare.