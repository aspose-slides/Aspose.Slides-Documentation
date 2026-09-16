---
title: Esporta presentazioni in XAML in .NET
linktitle: Presentazione in XAML
type: docs
weight: 30
url: /it/net/export-to-xaml/
keywords:
- esporta PowerPoint
- esporta OpenDocument
- esporta presentazione
- converti PowerPoint
- converti OpenDocument
- converti presentazione
- PowerPoint in XAML
- OpenDocument in XAML
- presentazione in XAML
- PPT in XAML
- PPTX in XAML
- ODP in XAML
- salva PPT come XAML
- salva PPTX come XAML
- salva ODP come XAML
- esporta PPT in XAML
- esporta PPTX in XAML
- esporta ODP in XAML
- .NET
- C#
- Aspose.Slides
description: "Converti le diapositive PowerPoint e OpenDocument in XAML con .NET usando Aspose.Slides—soluzione rapida, senza Office, che mantiene intatto il layout."
---
## **Panoramica**

Questo articolo spiega come esportare le presentazioni PowerPoint in XAML utilizzando Aspose.Slides. Include una breve introduzione a XAML, mostra come salvare una presentazione in XAML con le impostazioni predefinite e dimostra come personalizzare l'esportazione tramite [XamlOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export.xaml/xamloptions/), inclusa l'esportazione delle diapositive nascoste. L'articolo risponde inoltre a alcune domande comuni relative ai caratteri di fallback, alla compatibilità con gli stack XAML e al comportamento dell'esportazione delle diapositive nascoste.

## **Informazioni su XAML**

XAML è un linguaggio di markup basato su XML utilizzato per descrivere interfacce utente in framework come WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) e Xamarin.Forms.

È possibile lavorare con i file XAML in un designer visuale oppure scrivere e modificare direttamente il markup.

## **Esporta presentazioni in XAML con opzioni predefinite**

Il seguente esempio C# mostra come esportare una presentazione in XAML con le impostazioni predefinite:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

using var presentation = new Presentation("pres.pptx");
var xamlOptions = new XamlOptions();
presentation.Save(xamlOptions);
```

Per impostazione predefinita, le diapositive esportate vengono salvate in una sottocartella `pres` della directory di lavoro corrente del processo, come restituito da [Directory.GetCurrentDirectory](https://learn.microsoft.com/en-us/dotnet/api/system.io.directory.getcurrentdirectory). La cartella viene creata automaticamente e anche le eventuali immagini richieste vengono salvate lì.

Il nome della cartella di output è ricavato dal nome del file sorgente senza estensione. Per `pres.pptx`, i file di output sono denominati `pres/Slide_1.xaml`, `pres/Slide_2.xaml` e così via. Anche se si passa un percorso assoluto alla presentazione di input, la cartella di output viene creata in modo relativo alla directory di lavoro corrente, anziché accanto al file di input.

## **Esporta presentazioni in XAML con opzioni personalizzate**

Utilizzare l'interfaccia [IXamlOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export.xaml/ixamloptions/) per controllare come Aspose.Slides esporta una presentazione in XAML.

Per salvare l'output in una posizione personalizzata, implementare [IXamlOutputSaver](https://reference.aspose.com/slides/it/net/aspose.slides.export.xaml/ixamloutputsaver/) e assegnare un'istanza della propria implementazione alla proprietà [OutputSaver](https://reference.aspose.com/slides/it/net/aspose.slides.export.xaml/xamloptions/outputsaver/) di [XamlOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export.xaml/xamloptions/).

Per includere le diapositive nascoste nell'output XAML, impostare la proprietà [ExportHiddenSlides](https://reference.aspose.com/slides/it/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) su `true`, come mostrato nel seguente esempio C#:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

using var presentation = new Presentation("pres.pptx");
var xamlOptions = new XamlOptions { ExportHiddenSlides = true };
presentation.Save(xamlOptions);
```

## **Acquisisci tutti gli artefatti XAML generati**

Un'esportazione XAML può produrre un documento XAML per ogni diapositiva esportata più immagini separate e risorse di supporto. Assegnare un [IXamlOutputSaver](https://reference.aspose.com/slides/it/net/aspose.slides.export.xaml/ixamloutputsaver/) personalizzato a [XamlOptions.OutputSaver](https://reference.aspose.com/slides/it/net/aspose.slides.export.xaml/xamloptions/outputsaver/) per ricevere questi artefatti anziché utilizzare il salvatore di file system predefinito. Avviare l'esportazione con la sovraccarico di [Presentation.Save](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/save/) specifico per XAML che accetta le opzioni XAML.

### **Comprendere il ciclo di vita del callback**

L'esportatore chiama [IXamlOutputSaver.Save](https://reference.aspose.com/slides/it/net/aspose.slides.export.xaml/ixamloutputsaver/save/) separatamente per ogni artefatto generato:

- `path` identifica l'artefatto e può includere directory relative. Conservare queste informazioni perché XAML può fare riferimento a risorse usando percorsi relativi.
- `data` contiene i byte dell'artefatto. Immagini e altre risorse binarie non devono essere decodificate come testo.
- Il salvatore è responsabile di conservare o persistere i dati prima di restituire. Gli esempi copiano ogni array di byte in memoria gestita dall'applicazione.
- Considerare l'esportazione riuscita solo quando l'operazione di salvataggio della presentazione restituisce e tutti i callback sono completati correttamente. Non sopprimere errori di archiviazione né avviare scritture in background non monitorate. Se la persistenza avviene successivamente, riportare il successo complessivo solo dopo che anche quel passaggio è riuscito.

[XamlOptions.ExportHiddenSlides](https://reference.aspose.com/slides/it/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) si applica anche a un salvatore personalizzato. Il suo valore predefinito, `false`, esclude i documenti XAML delle diapositive nascoste. Impostandolo su `true` le include insieme a tutte le risorse necessarie per la loro esportazione. Il numero di risorse dipende dalla presentazione; non presumere un callback per diapositiva o un ordine fisso dei callback.

### **Esporta in memoria e ispeziona gli artefatti**

Questo esempio completo carica `pres.pptx`, raccoglie ogni artefatto in un [Dictionary<string, byte[]>](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2) e ne stampa nome, tipo e conteggio byte. Preserva esattamente i nomi forniti. Nomi duplicati fanno fallire la raccolta invece di sovrascrivere silenziosamente un artefatto.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

public static class InMemoryXamlExample
{
    public static void Run()
    {
        var saver = new MemoryXamlSaver();
        using var presentation = new Presentation("pres.pptx");
        var options = new XamlOptions { OutputSaver = saver, ExportHiddenSlides = true };
        presentation.Save(options);

        bool inspectXamlText = false;
        foreach (var artifact in saver.Artifacts)
        {
            var extension = Path.GetExtension(artifact.Key).ToLowerInvariant();
            bool isXaml = extension == ".xaml";
            bool isImage = extension is ".png" or ".jpg" or ".jpeg" or ".gif" or ".bmp" or ".tif" or ".tiff" or ".svg";
            var kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
            Console.WriteLine($"{artifact.Key}: {artifact.Value.Length} bytes ({kind})");

            // Decodifica solo XAML, e solo quando è necessaria l'ispezione testuale.
            if (isXaml && inspectXamlText)
            {
                var markup = Encoding.UTF8.GetString(artifact.Value);
                Console.WriteLine(markup);
            }
        }
    }

    private sealed class MemoryXamlSaver : IXamlOutputSaver
    {
        public Dictionary<string, byte[]> Artifacts { get; } = new Dictionary<string, byte[]>(StringComparer.Ordinal);

        public void Save(string path, byte[] data)
        {
            var retainedData = (byte[])data.Clone();
            Artifacts.Add(path, retainedData);
        }
    }
}
```

Chiamare `InMemoryXamlExample.Run` dalla propria applicazione. I controlli di estensione sono utili per l'ispezione; conservare tutti gli artefatti, inclusi i tipi di risorsa meno familiari. Lasciare i byte invariati durante l'archiviazione o la trasmissione. Utilizzare [Encoding.UTF8.GetString](https://learn.microsoft.com/en-us/dotnet/api/system.text.encoding.getstring) solo per XAML che richiede elaborazione testuale.

### **Imballa gli artefatti raccolti in un archivio ZIP**

Questo esempio autonomo raccoglie l'esportazione, ne valida i nomi e scrive i byte originali in un archivio ZIP. Un nome di archivio univoco separa i lavori di esportazione concorrenti. Le voci ZIP usano la barra obliqua (`/`) e conservano le directory relative. Nomi non sicuri o che collidono dopo la normalizzazione provocano il rifiuto dell'intero pacchetto prima della scrittura.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

public static class ZipXamlExample
{
    public static void Run()
    {
        var saver = new CollectedXamlSaver();
        using var presentation = new Presentation("pres.pptx");
        var options = new XamlOptions { OutputSaver = saver, ExportHiddenSlides = false };
        presentation.Save(options);

        var entries = new Dictionary<string, byte[]>(StringComparer.OrdinalIgnoreCase);
        foreach (var artifact in saver.Artifacts)
        {
            var entryName = artifact.Key.Replace('\\', '/');
            var segments = entryName.Split('/');
            bool unsafeName = entryName.StartsWith("/", StringComparison.Ordinal) || entryName.Contains(':');
            foreach (var segment in segments)
            {
                unsafeName |= string.IsNullOrWhiteSpace(segment) || segment == "." || segment == "..";
            }

            if (unsafeName || !entries.TryAdd(entryName, artifact.Value))
            {
                Console.WriteLine($"Export rejected: unsafe or duplicate artifact name: {artifact.Key}");
                return;
            }
        }

        var archivePath = $"xaml-{Guid.NewGuid():N}.zip";
        using (var output = new FileStream(archivePath, FileMode.CreateNew, FileAccess.Write))
        using (var archive = new ZipArchive(output, ZipArchiveMode.Create))
        {
            foreach (var artifact in entries)
            {
                var entry = archive.CreateEntry(artifact.Key, CompressionLevel.Optimal);
                using var entryStream = entry.Open();
                entryStream.Write(artifact.Value, 0, artifact.Value.Length);
            }
        }

        // La directory ZIP è stata completata dallo smaltimento prima di segnalare il successo.
        Console.WriteLine($"Saved {entries.Count} artifacts to {archivePath}");
    }

    private sealed class CollectedXamlSaver : IXamlOutputSaver
    {
        public Dictionary<string, byte[]> Artifacts { get; } = new Dictionary<string, byte[]>(StringComparer.Ordinal);

        public void Save(string path, byte[] data)
        {
            var retainedData = (byte[])data.Clone();
            Artifacts.Add(path, retainedData);
        }
    }
}
```

Chiamare `ZipXamlExample.Run` dalla propria applicazione. L'esempio utilizza [ZipArchive](https://learn.microsoft.com/en-us/dotnet/api/system.io.compression.ziparchive) per scrivere un archivio locale; l'esportatore stesso non scrive file XAML o immagini sparsi. Per l'archiviazione remota, sostituire la fase di scrittura dell'archivio con gli upload degli array di byte raccolti. Usare un identificatore di lavoro di esportazione più il nome relativo completo dell'artefatto come chiave di blob, oppure memorizzare l'identificatore del lavoro, il nome relativo e i dati binari in una riga di database. Pubblicare il lavoro solo dopo che tutti gli upload sono completati o la transazione del database è stata confermata. Pulire l'output parziale se la persistenza fallisce.

Per presentazioni di grandi dimensioni, un salvatore personalizzato può persistere ogni artefatto direttamente nello storage dell'applicazione per evitare di mantenere una copia aggiuntiva dell'intera esportazione in memoria. L'esportatore continua a raccogliere tutti gli artefatti generati in memoria prima di chiamare il salvatore. Mantenere ogni callback sincrono dal punto di vista dell'esportatore: restituire solo dopo che la destinazione ha accettato i byte e consentire ai fallimenti di raggiungere il chiamante.

### **Conservare i nomi delle risorse e verificare i riferimenti**

- Normalizzare i separatori di percorso quando la destinazione lo richiede, ma preservare le directory relative. Non usare solo [Path.GetFileName](https://learn.microsoft.com/en-us/dotnet/api/system.io.path.getfilename) a meno che ogni nome generato sia noto per essere unico e i riferimenti alle risorse rimangano validi.
- Applicare la convalida dei nomi specifica per la destinazione. Quando si scrivono file sparsi, rifiutare percorsi radicati e segmenti di traversata, risolvere la destinazione con [Path.GetFullPath](https://learn.microsoft.com/en-us/dotnet/api/system.io.path.getfullpath) e verificare che rimanga sotto la directory di esportazione prevista, includendo il separatore di percorso nella verifica di contenimento. Utilizzare una directory controllata dall'applicazione senza collegamenti simbolici che possano ridirigere le scritture.
- Usare un salvatore e uno spazio di nomi di storage separati per ogni lavoro di esportazione. Rilevare collisioni dopo la normalizzazione dei separatori e secondo le regole di sensibilità a maiuscole/minuscole della destinazione.
- Prima della pubblicazione, analizzare ogni documento XAML come XML e ispezionare i riferimenti alle risorse basati su file, come gli attributi `Source` o `ImageSource` delle immagini. Risolvere ogni URI relativa rispetto alla directory dell'artefatto XAML contenente, normalizzare il nome di storage risultante e confermare che la chiave corrispondente nel dizionario, nella voce ZIP o nell'oggetto memorizzato esista. Trattare separatamente gli URI esterni e le espressioni di markup XAML dai nomi di file relativi.

Ad esempio, se `pres/Slide_1.xaml` fa riferimento a `images/image1.png`, la risorsa memorizzata deve essere disponibile come `pres/images/image1.png`. Conservare solo `image1.png` romperebbe tale relazione. Per lo storage a oggetti, mantenere la stessa struttura sotto il prefisso del lavoro e rendere quegli URL di risorsa accessibili al consumatore XAML. Riaprire lo ZIP completato per verificare i nomi delle voci e i byte delle risorse, e caricare diapositive rappresentative nell'ambiente XAML di destinazione per confermare che le immagini vengano risolte correttamente.

## **FAQ**

**Come posso garantire caratteri prevedibili se il carattere originale non è disponibile sulla macchina?**

Impostare [DefaultRegularFont](https://reference.aspose.com/slides/it/net/aspose.slides.export/saveoptions/defaultregularfont/) in [XamlOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export.xaml/xamloptions/) — viene utilizzato come carattere di fallback durante l'esportazione quando quello originale è mancante. Questo non garantisce che lo XAML generato faccia riferimento al carattere di fallback o che il carattere sia disponibile sulla macchina di destinazione. Assicurarsi che i caratteri a cui fa riferimento lo XAML siano disponibili nell'ambiente in cui viene visualizzato.

**Lo XAML esportato è destinato solo a WPF o può essere usato anche in altri stack XAML?**

Aspose.Slides esporta XAML WPF tramite la sua API pubblica. La compatibilità con altri stack XAML, come UWP e Xamarin.Forms, non è garantita. Testare il markup generato nell'ambiente di destinazione.

**Le diapositive nascoste sono supportate e come posso impedire che vengano esportate per impostazione predefinita?**

Per impostazione predefinita, le diapositive nascoste non sono incluse. È possibile controllare questo comportamento tramite [ExportHiddenSlides](https://reference.aspose.com/slides/it/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) in [XamlOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export.xaml/xamloptions/) — mantenerlo disabilitato se non è necessario esportarle.