---
title: Licenze
type: docs
weight: 80
url: /it/net/licensing/
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
- .NET
- C#
- Aspose.Slides
description: "Applica, gestisci e risolvi i problemi delle licenze in Aspose.Slides per .NET. Garantisce un accesso ininterrotto a tutte le funzionalità con la nostra guida passo-passo sulla gestione delle licenze."
---
## **Panoramica**

Aspose.Slides può essere utilizzato in modalità di valutazione o con una licenza valida. La versione di valutazione fornisce le stesse funzionalità della versione con licenza, ma aggiunge una filigrana di valutazione a ogni diapositiva di ciascuna presentazione che salva e tronca il testo che il tuo codice legge dalle presentazioni.

Questo articolo spiega come funziona la licenza in Aspose.Slides e come applicare una licenza prima di utilizzare la libreria. Una licenza può essere caricata da un file, uno stream o una risorsa incorporata utilizzando la classe `License`. L'articolo mostra anche come convalidare se una licenza è stata applicata correttamente.

## **Valuta Aspose.Slides**
{{% alert color="info" title="Note" %}}
Puoi scaricare una versione di valutazione di **Aspose.Slides for .NET** dalla [pagina di download NuGet](https://www.nuget.org/packages/Aspose.Slides.NET/). La versione di valutazione fornisce le stesse funzionalità della versione con licenza del prodotto. Il pacchetto di valutazione è lo stesso del pacchetto acquistato. La versione di valutazione diventa semplicemente con licenza dopo aver aggiunto alcune righe di codice (per applicare la licenza).

Una volta che sei soddisfatto della tua valutazione di **Aspose.Slides**, puoi [acquistare una licenza](https://purchase.aspose.com/pricing/slides/it/net/). Ti consigliamo di esaminare i diversi tipi di abbonamento. Se hai domande, contatta il team commerciale di Aspose.

Ogni licenza Aspose include un abbonamento di un anno per aggiornamenti gratuiti a nuove versioni o correzioni rilasciate durante il periodo di abbonamento. Gli utenti con prodotti con licenza o anche versioni di valutazione ricevono supporto tecnico gratuito e illimitato.
{{% /alert %}}

**Limitazioni della versione di valutazione**

* La versione di valutazione (senza specificare una licenza) fornisce la piena funzionalità del prodotto, ma aggiunge una casella di testo con filigrana di valutazione a ogni diapositiva di ciascuna presentazione che salva.
* Il testo che il tuo codice legge da una presentazione viene troncato ai primi caratteri, seguito da un avviso sulla limitazione della valutazione. Il testo che il tuo codice scrive viene salvato per intero.

{{% alert color="info" title="Note" %}}
Per testare Aspose.Slides senza limitazioni, puoi richiedere una **Licenza Temporanea di 30 giorni**. Consulta la pagina [Come ottenere una licenza temporanea](https://purchase.aspose.com/temporary-license) per ulteriori informazioni.
{{% /alert %}}

## **Licenze in Aspose.Slides**
* Una versione di valutazione diventa con licenza dopo aver acquistato una licenza e aver aggiunto un paio di righe di codice (per applicare la licenza).
* La licenza è un file XML in testo semplice che contiene dettagli come il nome del prodotto, il numero di sviluppatori a cui è licenziata, la data di scadenza dell'abbonamento, ecc.
* Il file di licenza è firmato digitalmente, quindi non devi modificarlo. Anche l'aggiunta accidentale di un ulteriore a capo al contenuto del file lo renderà invalido.
* Aspose.Slides for .NET solitamente tenta di trovare la licenza in queste posizioni:
  * Un percorso esplicito
  * La cartella contenente il dll del componente (inclusa in Aspose.Slides)
  * La cartella contenente l'assembly che ha chiamato il dll del componente (inclusa in Aspose.Slides)
  * La cartella contenente l'assembly di ingresso (il tuo .exe)
  * Una risorsa incorporata nell'assembly che ha chiamato il dll del componente (inclusa in Aspose.Slides).
* Per evitare le limitazioni associate alla versione di valutazione, è necessario impostare una licenza prima di utilizzare Aspose.Slides. È necessario impostare una licenza una sola volta per applicazione o processo.

{{% alert color="info" title="Note" %}}
Potresti voler vedere [Licenze a consumo](/slides/it/net/metered-licensing/).
{{% /alert %}}

## **Applica una licenza**
Una licenza può essere caricata da un **file**, **stream** o **risorsa incorporata**. 

{{% alert color="info" title="Note" %}}
Aspose.Slides fornisce la classe [License](https://reference.aspose.com/slides/it/net/aspose.slides/license) per le operazioni di licenza.
{{% /alert %}} 

{{% alert color="warning" title="Warning" %}}
Le nuove licenze possono attivare Aspose.Slides solo con la versione 21.4 o successive. Le versioni precedenti usano un sistema di licenza diverso e non riconosceranno queste licenze.
{{% /alert %}}

### **File**
Il metodo più semplice per impostare una licenza richiede di posizionare il file di licenza nella stessa cartella contenente il DLL del componente (incluso in Aspose.Slides) e specificare solo il nome del file senza il percorso.

Questo codice C# mostra come impostare un file di licenza:

``` csharp
// Istanzia la classe License 
Aspose.Slides.License license = new Aspose.Slides.License();

// Imposta il percorso del file di licenza
license.SetLicense("Aspose.Slides.lic");
```

{{% alert color="warning" title="Warning" %}}
Se posizioni il file di licenza in una directory diversa, quando chiami il metodo [SetLicense](https://reference.aspose.com/slides/it/net/aspose.slides/license/setlicense/#setlicense_1), il nome del file di licenza alla fine del percorso specificato deve corrispondere al nome del tuo file di licenza.

Ad esempio, puoi cambiare il nome del file di licenza in *Aspose.Slides.lic.xml*. Quindi, nel tuo codice, devi passare il percorso al file (che termina con *Aspose.Slides.lic.xml*) al metodo [SetLicense](https://reference.aspose.com/slides/it/net/aspose.slides/license/setlicense/#setlicense_1).
{{% /alert %}}

### **Stream**
Puoi caricare una licenza da uno stream. Questo codice C# mostra come applicare una licenza da uno stream:

``` csharp
// Istanzia la classe License
Aspose.Slides.License license = new Aspose.Slides.License();

// Apre il file di licenza come stream
using FileStream licenseStream = File.OpenRead("Aspose.Slides.lic");

// Imposta la licenza tramite stream
license.SetLicense(licenseStream);
```

### **Risorsa incorporata**
Puoi pacchettizzare la licenza con la tua applicazione (per evitarne la perdita) aggiungendo la licenza come risorsa incorporata in uno degli assembly che chiamano il DLL del componente (incluso in Aspose.Slides). 

Questo è il modo in cui aggiungi un file di licenza come risorsa incorporata:

1. In Visual Studio, aggiungi il file di licenza (.lic) al progetto in questo modo: vai su **File** > **Aggiungi elemento esistente** > **Aggiungi**. 
2. Seleziona il file in **Solution Explorer**.
3. Nella finestra **Properties**, imposta **Build Action** su **Embedded Resource**.
4. Per accedere alla licenza incorporata nell'assembly, aggiungi il file di licenza come risorsa incorporata al progetto, quindi passa il nome del file di licenza al metodo `SetLicense`. 

La classe `License` trova automaticamente il file di licenza nelle risorse incorporate. Non è necessario chiamare i metodi `GetExecutingAssembly` e `GetManifestResourceStream` della classe `System.Reflection.Assembly` nel Microsoft .NET Framework.

Questo codice C# mostra come impostare una licenza come risorsa incorporata:

``` csharp
// Istanzia la classe License
Aspose.Slides.License license = new Aspose.Slides.License();

// Passa il nome del file di licenza incorporato nell'assembly
license.SetLicense("Aspose.Slides.lic");
```

## **Convalida di una licenza**

Per verificare se una licenza è stata impostata correttamente, puoi convalidarla. Questo codice C# mostra come convalidare una licenza:

```c#
Aspose.Slides.License license = new Aspose.Slides.License();

license.SetLicense("Aspose.Slides.lic");

if (license.IsLicensed())
{
    Console.WriteLine("License is good!");
    Console.Read();
}
```

## **Sicurezza dei thread**

{{% alert color="warning" title="Warning" %}}
Il metodo [license.SetLicense](https://reference.aspose.com/slides/it/net/aspose.slides/license/setlicense/) non è thread‑safe. Se questo metodo deve essere chiamato simultaneamente da più thread, potresti voler utilizzare primitive di sincronizzazione (come un lock) per evitare problemi. 
{{% /alert %}}

## **FAQ**

### Posso applicare la licenza in un ambiente completamente offline (senza accesso a Internet)?

Sì. La convalida della licenza viene eseguita localmente utilizzando il file di licenza; non è necessaria alcuna connessione a Internet.

### Cosa succede dopo la scadenza dell'abbonamento di un anno? La libreria smetterà di funzionare?

No. La licenza è perpetua: puoi continuare a utilizzare le versioni rilasciate prima della data di scadenza del tuo abbonamento; semplicemente non potrai utilizzare le versioni più recenti senza rinnovare.