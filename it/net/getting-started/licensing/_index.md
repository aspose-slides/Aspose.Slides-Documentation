---
title: Licenze
type: docs
weight: 80
url: /it/net/licensing/
keywords:
- licenza
- licenza temporanea
- imposta licenza
- utilizza licenza
- verifica licenza
- file di licenza
- versione di valutazione
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Applica, gestisci e risolvi i problemi delle licenze in Aspose.Slides per .NET. Garantisci un accesso ininterrotto a tutte le funzionalità con la nostra guida passo-passo sulla licenza."
---
## **Panoramica**

Aspose.Slides può essere utilizzato in modalità di valutazione o con una licenza valida. La versione di valutazione fornisce le stesse funzionalità della versione con licenza, ma aggiunge una filigrana di valutazione quando le presentazioni vengono aperte o salvate e limita l'estrazione del testo a una sola diapositiva.

Questo articolo spiega come funziona la licenza in Aspose.Slides e come applicare una licenza prima di utilizzare la libreria. Una licenza può essere caricata da un file, stream o risorsa incorporata utilizzando la classe `License`. L'articolo mostra anche come verificare se una licenza è stata applicata correttamente.

## **Valuta Aspose.Slides**

{{% alert color="info" %}} 

Puoi scaricare una versione di valutazione di **Aspose.Slides per .NET** dalla [pagina di download NuGet](https://www.nuget.org/packages/Aspose.Slides.NET/). La versione di valutazione fornisce le stesse funzionalità della versione con licenza del prodotto. Il pacchetto di valutazione è identico al pacchetto acquistato. La versione di valutazione diventa semplicemente licenziata dopo aver aggiunto poche righe di codice (per applicare la licenza).

Una volta soddisfatto della tua valutazione di **Aspose.Slides**, puoi [acquistare una licenza](https://purchase.aspose.com/buy). Ti consigliamo di esaminare i diversi tipi di abbonamento. Se hai domande, contatta il team commerciale di Aspose.

Ogni licenza Aspose include un abbonamento di un anno per aggiornamenti gratuiti a nuove versioni o correzioni rilasciate durante il periodo di abbonamento. Gli utenti con prodotti con licenza o anche versioni di valutazione ricevono supporto tecnico gratuito e illimitato.

{{% /alert %}} 

**Limitazioni della versione di valutazione**

* Sebbene la versione di valutazione di Aspose.Slides (senza licenza specificata) fornisca tutte le funzionalità del prodotto, inserisce una filigrana di valutazione in alto al documento durante le operazioni di apertura e salvataggio. 
* È consentita l'estrazione del testo da una sola diapositiva.

{{% alert color="info" %}} 

Per testare Aspose.Slides senza limitazioni, puoi richiedere una **Licenza Temporanea di 30 giorni**. Consulta la pagina [Come ottenere una Licenza Temporanea](https://purchase.aspose.com/temporary-license) per ulteriori informazioni.

{{% /alert %}}

## **Licenze in Aspose.Slides**
* Una versione di valutazione diventa licenziata dopo aver acquistato una licenza e aver aggiunto un paio di righe di codice (per applicare la licenza).
* La licenza è un file XML di testo puro che contiene dettagli come il nome del prodotto, il numero di sviluppatori a cui è concessa, la data di scadenza dell'abbonamento, ecc. 
* Il file di licenza è firmato digitalmente, quindi non devi modificarlo. Anche l'aggiunta involontaria di un ritorno a capo extra al contenuto del file lo invaliderà.
* Aspose.Slides per .NET tenta tipicamente di trovare la licenza in queste posizioni:
  * Un percorso esplicito
  * La cartella contenente il dll del componente (inclusa in Aspose.Slides)
  * La cartella contenente l'assembly che ha chiamato il dll del componente (inclusa in Aspose.Slides)
  * La cartella contenente l'assembly di ingresso (il tuo .exe)
  * Una risorsa incorporata nell'assembly che ha chiamato il dll del componente (inclusa in Aspose.Slides).
* Per evitare le limitazioni associate alla versione di valutazione, è necessario impostare una licenza prima di utilizzare Aspose.Slides. È necessario impostare la licenza una sola volta per applicazione o processo.

{{% alert color="info" %}} 

Potresti voler vedere [Licenza a Consumo](https://docs.aspose.com/slides/it/net/metered-licensing/).

{{% /alert %}} 


## **Applica una Licenza**
Una licenza può essere caricata da un **file**, **stream** o **risorsa incorporata**. 

{{% alert color="info" %}}

Aspose.Slides fornisce la classe [License](https://reference.aspose.com/slides/it/net/aspose.slides/license) per le operazioni relative alla licenza.

{{% /alert %}} 

{{% alert color="warning" %}} 

Le nuove licenze possono attivare Aspose.Slides solo a partire dalla versione 21.4. Le versioni precedenti utilizzano un sistema di licenza diverso e non riconosceranno queste licenze.

{{% /alert %}}

### **File**
Il metodo più semplice per impostare una licenza richiede di posizionare il file di licenza nella stessa cartella contenente il DLL del componente (inclusa in Aspose.Slides) e specificare solo il nome del file senza il percorso.

Questo codice C# mostra come impostare un file di licenza:

``` csharp
// Istanzia la classe License 
Aspose.Slides.License license = new Aspose.Slides.License();

// Imposta il percorso del file di licenza
license.SetLicense("Aspose.Slides.lic");
```

{{% alert color="warning" %}} 

Se posizioni il file di licenza in una directory diversa, quando chiami il metodo [SetLicense](https://reference.aspose.com/slides/it/net/aspose.slides/license/setlicense/#setlicense_1), il nome del file di licenza alla fine dell'esplicito specificato deve essere identico al nome del tuo file di licenza.

Ad esempio, puoi cambiare il nome del file di licenza in *Aspose.Slides.lic.xml*. Quindi, nel tuo codice, devi passare il percorso al file (terminante con *Aspose.Slides.lic.xml*) al metodo [SetLicense](https://reference.aspose.com/slides/it/net/aspose.slides/license/setlicense/#setlicense_1).

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

### **Risorsa Incorporata**
Puoi includere la licenza nella tua applicazione (per evitare di perderla) aggiungendo la licenza come risorsa incorporata in uno degli assembly che chiamano il DLL del componente (inclusa in Aspose.Slides). 

Ecco come aggiungere un file di licenza come risorsa incorporata:

1. In Visual Studio, aggiungi il file di licenza (.lic) al progetto così: vai su **File** > **Aggiungi elemento esistente** > **Aggiungi**. 
2. Seleziona il file in **Esplora soluzioni**.
3. Nella finestra **Proprietà**, imposta **Azione di compilazione** su **Embedded Resource**.
4. Per accedere alla licenza incorporata nell'assembly, aggiungi il file di licenza come risorsa incorporata al progetto, quindi passa il nome del file di licenza al metodo `SetLicense`. 


La classe `License` trova automaticamente il file di licenza nelle risorse incorporate. Non è necessario chiamare i metodi `GetExecutingAssembly` e `GetManifestResourceStream` della classe `System.Reflection.Assembly` nel Microsoft .NET Framework.

Questo codice C# mostra come impostare una licenza come risorsa incorporata:

``` csharp
// Istanzia la classe License
Aspose.Slides.License license = new Aspose.Slides.License();

// Passa il nome del file di licenza incorporato nell'assembly
license.SetLicense("Aspose.Slides.lic");
```

## **Convalida una Licenza**

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

## **Sicurezza dei Thread**

{{% alert title="Nota" color="warning" %}} 

Il metodo [license.SetLicense](https://reference.aspose.com/slides/it/net/aspose.slides/license/setlicense/) non è thread‑safe. Se questo metodo deve essere chiamato simultaneamente da più thread, potresti voler utilizzare primitive di sincronizzazione (come un lock) per evitare problemi. 

{{% /alert %}}

## **FAQ**

### Posso applicare la licenza in un ambiente completamente offline (senza accesso a Internet)?

Sì. La convalida della licenza viene eseguita localmente utilizzando il file di licenza; non è necessaria alcuna connessione a Internet.

### Cosa succede dopo la scadenza dell'abbonamento di un anno? La libreria smetterà di funzionare?

No. La licenza è perpetua: puoi continuare a utilizzare le versioni rilasciate prima della data di fine abbonamento; semplicemente non avrai diritto a utilizzare le versioni più recenti senza rinnovare.