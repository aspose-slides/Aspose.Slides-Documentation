---
title: Licenza
type: docs
weight: 90
url: /it/androidjava/licensing/
keywords:
- licenza
- licenza temporanea
- imposta licenza
- usa licenza
- valida licenza
- file di licenza
- versione di valutazione
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Applica, gestisci e risolvi i problemi delle licenze in Aspose.Slides per Android via Java. Garantisci l'accesso continuo a tutte le funzionalità con la nostra guida alla licenza."
---
## **Panoramica**

Aspose.Slides può essere utilizzato in modalità di valutazione o con una licenza valida. La versione di valutazione fornisce le stesse funzionalità della versione con licenza, ma aggiunge una filigrana di valutazione a ogni diapositiva di ogni presentazione che salva e tronca il testo che il tuo codice legge dalle presentazioni.

Questo articolo spiega come funziona la licenza in Aspose.Slides e come applicare una licenza prima di utilizzare la libreria. Una licenza può essere caricata da un file, flusso o risorsa incorporata utilizzando la classe [License](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/). L'articolo mostra anche come verificare se una licenza è stata applicata correttamente.

## **Valutare Aspose.Slides**

{{% alert color="info" title="Nota" %}}

Puoi scaricare una versione di valutazione di **Aspose.Slides for Android via Java** dalla sua [pagina di download](https://releases.aspose.com/slides/androidjava/). La versione di valutazione fornisce le stesse funzionalità della versione con licenza del prodotto. Il pacchetto di valutazione è lo stesso del pacchetto acquistato. La versione di valutazione diventa semplicemente licenziata dopo aver aggiunto alcune righe di codice (per applicare la licenza).

Una volta soddisfatto della tua valutazione di **Aspose.Slides**, puoi [acquistare una licenza](https://purchase.aspose.com/pricing/slides/android-java/). Ti consigliamo di esaminare i diversi tipi di abbonamento. Se hai domande, contatta il team commerciale di Aspose.

Ogni licenza Aspose include un abbonamento di un anno per aggiornamenti gratuiti a nuove versioni o correzioni rilasciate durante il periodo di abbonamento. Gli utenti con prodotti con licenza (o anche versioni di valutazione) ricevono supporto tecnico gratuito e illimitato.

{{% /alert %}} 

**Limitazioni della versione di valutazione**

* La versione di valutazione (senza una licenza specificata) fornisce tutte le funzionalità del prodotto, ma aggiunge una casella di testo con filigrana di valutazione a ogni diapositiva di ogni presentazione che salva.
* Il testo che il tuo codice legge da una presentazione viene troncato ai primi caratteri, seguito da un avviso sulla limitazione di valutazione. Il testo che il tuo codice scrive viene salvato per intero.

{{% alert color="info" title="Nota" %}}

Per testare Aspose.Slides senza limitazioni, puoi richiedere una **Licenza Temporanea di 30 giorni**. Vedi la pagina [Come ottenere una Licenza Temporanea](https://purchase.aspose.com/temporary-license) per ulteriori informazioni.

{{% /alert %}}

## **Licenza in Aspose.Slides**

* Una versione di valutazione diventa licenziata dopo aver acquistato una licenza e aggiunto alcune righe di codice (per applicare la licenza).
* La licenza è un file XML di testo semplice che contiene dettagli come il nome del prodotto, il numero di sviluppatori a cui è concessa, la data di scadenza dell'abbonamento e così via. 
* Il file di licenza è firmato digitalmente, quindi non devi modificarlo. Anche l'aggiunta involontaria di un ritorno a capo extra al contenuto del file lo invaliderà.
* Aspose.Slides for Android via Java tenta tipicamente di trovare la licenza in queste posizioni:
  * Un percorso esplicito
  * La cartella contenente Aspose.Slides.jar
* Per evitare le limitazioni associate alla versione di valutazione, è necessario impostare una licenza prima di utilizzare **Aspose.Slides**. È sufficiente impostare la licenza una sola volta per applicazione o processo.

## **Applicare una licenza**

Una licenza può essere caricata da un **file** o da un **flusso**.

{{% alert color="info" title="Nota" %}}

Aspose.Slides fornisce la classe [License](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/) per le operazioni di licenza.

{{% /alert %}} 

{{% alert color="warning" title="Avvertenza" %}}

Le nuove licenze possono attivare Aspose.Slides solo con la versione 21.4 o successive. Le versioni precedenti usano un sistema di licenza diverso e non riconosceranno queste licenze.

{{% /alert %}}

### **File**

Il metodo più semplice per impostare una licenza richiede di posizionare il file di licenza nella cartella contenente Aspose.Slides.jar o il jar della tua applicazione.

{{% alert color="info" title="Nota" %}}

Su Android, la libreria e la tua app sono confezionate nell'APK, quindi non esiste una cartella che contenga il file JAR della libreria, e un percorso relativo come *Aspose.Slides.Android.via.Java.lic* non punta a un file nella tua app. Aggiungi il file di licenza alle risorse *assets* della tua app e caricalo da un flusso, come mostrato in [Flusso da App Assets](#stream-from-app-assets).

{{% /alert %}}

Questo codice Java mostra come impostare un file di licenza:

``` java
// Istanzia la classe License
com.aspose.slides.License license = new com.aspose.slides.License();

// Imposta il percorso del file di licenza
license.setLicense("Aspose.Slides.Android.via.Java.lic");
```

{{% alert color="warning" title="Avvertenza" %}}

Se posizioni il file di licenza in una directory diversa, quando chiami il metodo [setLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-) il nome del file di licenza alla fine del percorso specificato deve corrispondere al nome del tuo file di licenza.

Ad esempio, puoi cambiare il nome del file di licenza in *Aspose.Slides.Android.via.Java.lic.xml*. Quindi, nel tuo codice, devi passare il percorso al file (che termina con *Aspose.Slides.Android.via.Java.lic.xml*) al metodo [setLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-).

{{% /alert %}}

### **Flusso**

Puoi caricare una licenza da un flusso. Questo codice Java mostra come applicare una licenza da un flusso:

``` java
// Istanzia la classe License
com.aspose.slides.License license = new com.aspose.slides.License();

// Imposta la licenza tramite un flusso
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Android.via.Java.lic"));
```

### **Flusso da App Assets**

In un'app Android, inserisci il file di licenza nella cartella *assets* del modulo app, *app/src/main/assets*, così che venga confezionato nell'APK. Apri il file con il metodo [getAssets](https://developer.android.com/reference/android/content/Context#getAssets()) e passa il flusso al metodo [setLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-) . Il codice viene eseguito all'interno di un `Activity`, ad esempio nel suo metodo `onCreate`, prima che l'app utilizzi Aspose.Slides:

```java
import android.util.Log;
import com.aspose.slides.License;
import java.io.IOException;
import java.io.InputStream;

License license = new License();
try (InputStream licenseStream = getAssets().open("Aspose.Slides.Android.via.Java.lic")) {
    license.setLicense(licenseStream);
} catch (IOException exception) {
    Log.e("Licensing", "Cannot read the license file from the app's assets.", exception);
}
```

Il nome del file passato al metodo [open](https://developer.android.com/reference/android/content/res/AssetManager#open(java.lang.String)) è relativo alla cartella *assets*. Se il file non è presente, il codice registra l'errore e Aspose.Slides rimane in modalità di valutazione. Per verificare se la licenza è stata applicata, vedi [Convalidare una licenza](#validating-a-license).

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

{{% alert color="warning" title="Avvertenza" %}}

Il metodo [setLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-) non è thread‑safe. Se questo metodo deve essere chiamato simultaneamente da più thread, potresti voler utilizzare primitive di sincronizzazione (come un lock) per evitare problemi.

{{% /alert %}}

## **FAQ**

### Posso applicare la licenza in un ambiente completamente offline (senza accesso a internet)?

Sì. La convalida della licenza avviene localmente usando il file di licenza; non è necessaria alcuna connessione a internet.

### Cosa succede dopo la scadenza dell'abbonamento di un anno? La libreria smetterà di funzionare?

No. La licenza è perpetua: puoi continuare a utilizzare le versioni rilasciate prima della data di fine abbonamento; semplicemente non potrai usare le versioni più recenti senza rinnovare.