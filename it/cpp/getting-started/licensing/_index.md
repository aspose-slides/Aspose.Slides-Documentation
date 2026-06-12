---
title: Licenze
type: docs
weight: 120
url: /it/cpp/licensing/
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
- C++
- Aspose.Slides
description: "Applica, gestisci e risolvi i problemi delle licenze in Aspose.Slides per C++. Garantisci un accesso ininterrotto a tutte le funzionalità con la nostra guida passo passo sulla licenza."
---
## **Panoramica**

Aspose.Slides può essere utilizzato in modalità di valutazione o con una licenza valida. La versione di valutazione fornisce le stesse funzionalità della versione con licenza, ma aggiunge una filigrana di valutazione quando le presentazioni vengono aperte o salvate e limita l'estrazione del testo a una diapositiva.

Questo articolo spiega come funziona la licenza in Aspose.Slides e come applicare una licenza prima di utilizzare la libreria. Una licenza può essere caricata da un file, uno stream o una risorsa incorporata utilizzando la classe `License`. L'articolo mostra anche come verificare se una licenza è stata applicata correttamente.

## **Valuta Aspose.Slides**

{{% alert color="primary" %}} 

Puoi scaricare una versione di valutazione di **Aspose.Slides for C++** dalla [sua pagina di download NuGet](https://www.nuget.org/packages/Aspose.Slides.CPP/). La versione di valutazione offre le stesse funzionalità del prodotto con licenza. Infatti, il pacchetto di valutazione è identico a quello acquistato: diventa semplicemente con licenza una volta aggiunte alcune righe di codice per applicare la licenza.

Una volta che sei soddisfatto della tua valutazione di **Aspose.Slides**, puoi [acquistare una licenza](https://purchase.aspose.com/buy). Ti consigliamo di esaminare i tipi di abbonamento disponibili. Se hai domande, non esitare a contattare il team commerciale di Aspose.

Ogni licenza Aspose include un abbonamento di un anno per aggiornamenti gratuiti, inclusi nuove versioni e correzioni di bug rilasciate durante quel periodo. Che tu stia usando una versione con licenza o di valutazione, ricevi supporto tecnico gratuito e illimitato.

{{% /alert %}} 

**Limitazioni della versione di valutazione**

* Sebbene la versione di valutazione di Aspose.Slides (quando non è applicata alcuna licenza) fornisca la piena funzionalità del prodotto, inserisce una filigrana di valutazione nella parte superiore del documento durante le operazioni di apertura e salvataggio.
* L'estrazione del testo è limitata a una diapositiva quando si utilizza la versione di valutazione.

{{% alert color="primary" %}} 

Per testare Aspose.Slides senza limitazioni, puoi richiedere una **Licenza Temporanea di 30 giorni**. Per ulteriori informazioni, consulta la pagina [How to Get a Temporary License](https://purchase.aspose.com/temporary-license).

{{% /alert %}}

## **Licenze in Aspose.Slides**

* Una versione di valutazione diventa licenziata dopo aver acquistato una licenza e averla applicata aggiungendo un paio di righe di codice.
* La licenza è un file XML di testo semplice che contiene dettagli come il nome del prodotto, il numero di sviluppatori a cui è concessa, la data di scadenza dell'abbonamento e altro.
* Il file di licenza è firmato digitalmente, quindi non deve essere modificato. Anche una modifica accidentale, ad esempio l'aggiunta di un ritorno a capo, invaliderà il file.
* Aspose.Slides for C++ tipicamente ricerca il file di licenza nei seguenti percorsi:
  * Un percorso specificato esplicitamente nel tuo codice
  * La cartella contenente il DLL del componente (incluso in Aspose.Slides)
  * La cartella contenente l'assembly che chiama il DLL del componente
* Per evitare le limitazioni della versione di valutazione, è necessario impostare la licenza prima di utilizzare Aspose.Slides. Una licenza deve essere impostata una sola volta per applicazione o processo.

## **Applicare una licenza**

Una licenza può essere caricata da un **file**, da uno **stream** o da una **risorsa incorporata**.

{{% alert color="primary" %}}

Aspose.Slides fornisce la classe [License](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.license/) per le operazioni di licenza.

{{% /alert %}} 

{{% alert color="warning" %}}

Le nuove licenze possono attivare Aspose.Slides solo con la versione 21.4 o successive. Le versioni precedenti usano un sistema di licenza diverso e non riconoscono queste licenze.

{{% /alert %}}

### **File**

Il modo più semplice per impostare una licenza è posizionare il file di licenza nella stessa cartella del DLL del componente (incluso in Aspose.Slides) e specificare solo il nome del file, senza il percorso.

Il seguente codice C++ mostra come impostare un file di licenza:

```c++
#include <Util/License.h>

using namespace Aspose::Slides;

int main()
{
    auto license = MakeObject<License>();
    license->SetLicense(u"Aspose.Slides.lic");

    return 0;
}
```

{{% alert color="warning" %}} 

Se posizioni il file di licenza in una directory diversa, allora quando chiami il metodo [License::SetLicense](https://reference.aspose.com/slides/it/cpp/aspose.slides/license/setlicense/), il nome del file alla fine del percorso esplicito specificato deve corrispondere esattamente al nome del tuo file di licenza.

Ad esempio, se rinomini il tuo file di licenza in *Aspose.Slides.lic.xml*, devi passare il percorso completo terminante con *Aspose.Slides.lic.xml* al metodo [License::SetLicense](https://reference.aspose.com/slides/it/cpp/aspose.slides/license/setlicense/) nel tuo codice.

{{% /alert %}}

### **Stream**

Puoi caricare una licenza da uno stream. Il seguente codice C++ mostra come applicare una licenza da uno stream:

```c++
auto license = MakeObject<License>();

auto stream = File::OpenRead(u"Aspose.Slides.lic");

license->SetLicense(stream);
```

## **Convalidare una licenza**

Per verificare se una licenza è stata impostata correttamente, è possibile convalidarla. Il seguente codice C++ mostra come convalidare una licenza:

```c++
auto license = MakeObject<License>();

license->SetLicense(u"Aspose.Slides.lic");

if (license->IsLicensed())
{
    Console::WriteLine(u"License is good!");
    Console::ReadKey();
}
```

## **Sicurezza dei thread**

{{% alert title="Note" color="warning" %}} 

Il metodo [License::SetLicense](https://reference.aspose.com/slides/it/cpp/aspose.slides/license/setlicense/) non è **thread-safe**. Se devi chiamare questo metodo da più thread simultaneamente, è consigliato utilizzare primitive di sincronizzazione (come un lock) per prevenire potenziali problemi.

{{% /alert %}}

## **FAQ**

**Posso applicare la licenza in un ambiente completamente offline (senza accesso a Internet)?**

Sì. La convalida della licenza avviene localmente usando il file di licenza; non è necessaria alcuna connessione a Internet.

**Cosa succede dopo la scadenza dell'abbonamento di un anno? La libreria smetterà di funzionare?**

No. La licenza è perpetua: puoi continuare a utilizzare le versioni rilasciate prima della data di fine abbonamento; semplicemente non potrai utilizzare le versioni più recenti senza rinnovare.