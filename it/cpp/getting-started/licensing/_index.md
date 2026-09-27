---
title: Licenze
type: docs
weight: 120
url: /it/cpp/licensing/
keywords:
- licenza
- licenza temporanea
- impostare licenza
- usare licenza
- validare licenza
- file di licenza
- versione di valutazione
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Applica, gestisci e risolvi i problemi di licenza in Aspose.Slides per C++. Garantisci accesso ininterrotto a tutte le funzionalità con la nostra guida passo passo alla licenza."
---
## **Panoramica**

Aspose.Slides può essere utilizzato in modalità di valutazione o con una licenza valida. La versione di valutazione fornisce le stesse funzionalità della versione con licenza, ma aggiunge una filigrana di valutazione a ogni diapositiva di ogni presentazione che salva e tronca il testo che il tuo codice legge dalle presentazioni.

Questo articolo spiega come funziona la licenza in Aspose.Slides e come applicare una licenza prima di utilizzare la libreria. Una licenza può essere caricata da un file o da uno stream utilizzando la classe `License`. L'articolo mostra anche come verificare se una licenza è stata applicata correttamente.

## **Valutare Aspose.Slides**

{{% alert color="info" title="Note" %}}
Puoi scaricare una versione di valutazione di **Aspose.Slides for C++** dalla [sua pagina di download su NuGet](https://www.nuget.org/packages/Aspose.Slides.Cpp/) o, come pacchetto ZIP, dalla [pagina di download](https://releases.aspose.com/slides/cpp/). La versione di valutazione offre le stesse funzionalità del prodotto con licenza. Infatti, il pacchetto di valutazione è identico a quello acquistato: diventa semplicemente con licenza una volta aggiunte alcune righe di codice per applicare la licenza.

Una volta che sei soddisfatto della tua valutazione di **Aspose.Slides**, puoi [acquistare una licenza](https://purchase.aspose.com/pricing/slides/cpp/). Ti consigliamo di esaminare i tipi di abbonamento disponibili. Se hai domande, non esitare a contattare il team commerciale di Aspose.

Ogni licenza Aspose include un abbonamento di un anno per aggiornamenti gratuiti, inclusi nuove versioni e correzioni di bug rilasciate durante tale periodo. Che tu stia usando una versione con licenza o di valutazione, ricevi supporto tecnico gratuito e illimitato.
{{% /alert %}} 

**Limitazioni della versione di valutazione**

* La versione di valutazione (senza una licenza specificata) fornisce tutte le funzionalità del prodotto, ma aggiunge una casella di testo con filigrana di valutazione a ogni diapositiva di ogni presentazione che salva.
* Il testo che il tuo codice legge da una presentazione viene troncato ai primi caratteri, seguito da un avviso sulla limitazione della valutazione. Il testo che il tuo codice scrive viene salvato per intero.

{{% alert color="info" title="Note" %}}
Per testare Aspose.Slides senza limitazioni, puoi richiedere una **licenza temporanea di 30 giorni**. Per ulteriori informazioni, consulta la pagina [Come ottenere una licenza temporanea](https://purchase.aspose.com/temporary-license).
{{% /alert %}}

## **Licenze in Aspose.Slides**

* La versione di valutazione diventa con licenza dopo aver acquistato una licenza e applicata aggiungendo un paio di righe di codice.
* La licenza è un file XML di testo semplice che contiene dettagli come il nome del prodotto, il numero di sviluppatori a cui è concessa, la data di scadenza dell'abbonamento e altro.
* Il file di licenza è firmato digitalmente, quindi non deve essere modificato. Anche una modifica accidentale, ad esempio l'aggiunta di un a capo, invaliderà il file.
* Quando passi un nome file senza cartella, Aspose.Slides for C++ cerca il file di licenza solo nella directory di lavoro corrente. Non ricerca nella cartella dell'eseguibile o della libreria Aspose.Slides, quindi fornisci il percorso completo quando il file di licenza è memorizzato altrove.
* Per evitare le limitazioni della versione di valutazione, devi impostare la licenza prima di utilizzare Aspose.Slides. Una licenza deve essere impostata una sola volta per applicazione o processo.

## **Applicare una licenza**

Una licenza può essere caricata da un **file** o da un **stream**.

{{% alert color="info" title="Note" %}}
Aspose.Slides fornisce la classe [License](https://reference.aspose.com/slides/cpp/aspose.slides/license/) per le operazioni di licenza.
{{% /alert %}} 

{{% alert color="warning" title="Warning" %}}
Le nuove licenze possono attivare Aspose.Slides solo con la versione 21.4 o successive. Le versioni precedenti utilizzano un sistema di licenza diverso e non riconosceranno queste licenze.
{{% /alert %}}

### **File**

La maniera più semplice per impostare una licenza è posizionare il file di licenza nella directory di lavoro del tuo programma e specificare solo il nome del file, senza il percorso. In caso contrario, specifica il percorso completo del file.

Il seguente codice C++ applica il file di licenza *Aspose.Slides.lic* dalla directory di lavoro del programma:
```c++
#include <Util/License.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

int main()
{
    auto license = MakeObject<License>();
    license->SetLicense(u"Aspose.Slides.lic");

    return 0;
}
```

Se la licenza è valida, [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) restituisce e il programma termina senza output; da quel momento Aspose.Slides funziona senza le limitazioni di valutazione. Se il file non si trova nella directory di lavoro, il metodo genera una [FileNotFoundException](https://reference.aspose.com/slides/cpp/system.io/filenotfoundexception/) con il messaggio *License "Aspose.Slides.lic" doesn't exist or access is restricted*. L'esempio non gestisce l'eccezione, quindi il programma si interrompe.

{{% alert color="warning" title="Warning" %}}
Se posizioni il file di licenza in una directory diversa, allora quando chiami il metodo [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/), il nome del file alla fine del percorso esplicito specificato deve corrispondere esattamente al nome del tuo file di licenza.

Ad esempio, se rinomini il tuo file di licenza in *Aspose.Slides.lic.xml*, devi passare il percorso completo terminante con *Aspose.Slides.lic.xml* al metodo [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) nel tuo codice.
{{% /alert %}}

### **Stream**

Carica una licenza da uno stream quando il tuo programma non conserva la licenza come file nominabile, ad esempio quando legge la licenza da un database. La classe [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) accetta qualsiasi [Stream](https://reference.aspose.com/slides/cpp/system.io/stream/) che contiene la licenza. Per abbreviare l'esempio, il seguente codice C++ apre *Aspose.Slides.lic* nella directory di lavoro con [File::OpenRead](https://reference.aspose.com/slides/cpp/system.io/file/openread/) e applica la licenza da quello stream:
```c++
#include <Util/License.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

int main()
{
    auto license = MakeObject<License>();
    auto stream = File::OpenRead(u"Aspose.Slides.lic");
    license->SetLicense(stream);

    return 0;
}
```

Una licenza valida produce lo stesso risultato dell'esempio con file. Se il file non esiste, [File::OpenRead](https://reference.aspose.com/slides/cpp/system.io/file/openread/) genera una [FileNotFoundException](https://reference.aspose.com/slides/cpp/system.io/filenotfoundexception/) prima che la licenza venga applicata, e il programma si interrompe.

## **Validare una licenza**

Per verificare se una licenza è stata impostata correttamente, chiama [License::IsLicensed](https://reference.aspose.com/slides/cpp/aspose.slides/license/islicensed/). Restituisce `true` solo dopo che una licenza valida è stata applicata, e `false` prima di ciò. Il seguente codice C++ applica il file di licenza dalla directory di lavoro e poi lo controlla:
```c++
#include <Util/License.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

int main()
{
    auto license = MakeObject<License>();
    license->SetLicense(u"Aspose.Slides.lic");

    if (license->IsLicensed())
    {
        Console::WriteLine(u"License is good!");
    }

    return 0;
}
```

Con una licenza valida, il programma stampa *License is good!*. Se il file è mancante o non è un file di licenza, [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) genera un'eccezione prima del controllo, e il programma si interrompe senza stampare nulla. Se il file è una licenza la cui firma non corrisponde, ad esempio perché è stata modificata, SetLicense restituisce senza errore ma `IsLicensed` restituisce `false`, quindi non viene stampato nulla e Aspose.Slides rimane in modalità di valutazione.

## **Sicurezza dei thread**

{{% alert color="warning" title="Warning" %}}
Il metodo [License::SetLicense](https://reference.aspose.com/slides/cpp/aspose.slides/license/setlicense/) non è **thread-safe**. Se devi chiamare questo metodo da più thread contemporaneamente, è consigliato utilizzare primitive di sincronizzazione (come un lock) per prevenire eventuali problemi.
{{% /alert %}}

## **FAQ**

### Posso applicare la licenza in un ambiente completamente offline (senza accesso a Internet)?

Sì. La convalida della licenza viene eseguita localmente utilizzando il file di licenza; non è necessaria alcuna connessione a Internet.

### Cosa succede dopo la scadenza dell'abbonamento di un anno? La libreria smetterà di funzionare?

No. La licenza è perpetua: puoi continuare a utilizzare le versioni rilasciate prima della data di scadenza del tuo abbonamento; semplicemente non potrai utilizzare versioni più recenti senza rinnovare.