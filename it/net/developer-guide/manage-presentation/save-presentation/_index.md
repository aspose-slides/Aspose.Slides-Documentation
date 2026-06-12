---
title: Salva presentazioni in .NET
linktitle: Salva presentazione
type: docs
weight: 80
url: /it/net/save-presentation/
keywords:
- salva PowerPoint
- salva OpenDocument
- salva presentazione
- salva diapositiva
- salva PPT
- salva PPTX
- salva ODP
- presentazione su file
- presentazione su stream
- tipo di visualizzazione predefinita
- Formato Strict Office Open XML
- modalità Zip64
- aggiornamento miniatura
- avanzamento del salvataggio
- .NET
- C#
- Aspose.Slides
description: "Scopri come salvare presentazioni in .NET usando Aspose.Slides—esporta in PowerPoint o OpenDocument mantenendo layout, caratteri ed effetti."
---
## **Panoramica**

[Open Presentations in C#](/slides/it/net/open-presentation/) descrive come utilizzare la classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) per aprire una presentazione. Questo articolo spiega come creare e salvare le presentazioni. La classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) contiene il contenuto di una presentazione. Che tu stia creando una presentazione da zero o modificando una esistente, dovrai salvarla al termine. Con Aspose.Slides per .NET, puoi salvare su **file** o **stream**. Questo articolo spiega i diversi modi per salvare una presentazione.

## **Salva presentazioni su file**

Salva una presentazione su un file chiamando il metodo `Save` della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/). Passa il nome file e il formato di salvataggio al metodo. L'esempio seguente mostra come salvare una presentazione con Aspose.Slides.

```cs
// Istanzia la classe Presentation che rappresenta un file di presentazione.
using (Presentation presentation = new Presentation())
{
    // Esegui qualche operazione qui...

    // Salva la presentazione su un file.
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **Salva presentazioni su stream**

Puoi salvare una presentazione su uno stream passando uno stream di output al metodo `Save` della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/). Una presentazione può essere scritta su molti tipi di stream. Nell'esempio sotto, creiamo una nuova presentazione e la salviamo su uno stream di file.

```cs
// Istanzia la classe Presentation che rappresenta un file di presentazione.
using (Presentation presentation = new Presentation())
{
    using (FileStream fileStream = new FileStream("Output.pptx", FileMode.Create))
    {
        // Salva la presentazione sullo stream.
        presentation.Save(fileStream, SaveFormat.Pptx);
    }
}
```

## **Salva presentazioni con un tipo di visualizzazione predefinito**

Aspose.Slides consente di impostare la vista iniziale che PowerPoint utilizza quando la presentazione generata viene aperta tramite la classe [ViewProperties](https://reference.aspose.com/slides/it/net/aspose.slides/viewproperties/). Imposta la proprietà [LastView](https://reference.aspose.com/slides/it/net/aspose.slides/viewproperties/lastview/) su un valore dell'enumerazione [ViewType](https://reference.aspose.com/slides/it/net/aspose.slides/viewtype/).

```cs
using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```

## **Salva presentazioni nel formato Strict Office Open XML**

Aspose.Slides consente di salvare una presentazione nel formato Strict Office Open XML. Usa la classe [PptxOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/pptxoptions/) e imposta la sua proprietà di conformità durante il salvataggio. Se imposti `Conformance.Iso29500_2008_Strict`, il file di output viene salvato nel formato Strict Office Open XML.

L'esempio seguente crea una presentazione e la salva nel formato Strict Office Open XML.

```cs
PptxOptions options = new PptxOptions()
{
    Conformance = Conformance.Iso29500_2008_Strict
};

// Istanzia la classe Presentation che rappresenta un file di presentazione.
using (Presentation presentation = new Presentation())
{
    // Salva la presentazione nel formato Strict Office Open XML.
    presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
}
```

## **Salva presentazioni nel formato Office Open XML in modalità Zip64**

Un file Office Open XML è un archivio ZIP che impone limiti di 4 GB (2^32 byte) sulla dimensione non compressa di qualsiasi file, sulla dimensione compressa di qualsiasi file e sulla dimensione totale dell'archivio, e limita l'archivio a 65 535 (2^16‑1) file. Le estensioni del formato ZIP64 aumentano questi limiti a 2^64.

La proprietà [IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/it/net/aspose.slides.export/ipptxoptions/zip64mode/) consente di scegliere quando utilizzare le estensioni del formato ZIP64 durante il salvataggio di un file Office Open XML.

Questa proprietà offre i seguenti modi:

- `IfNecessary` usa le estensioni ZIP64 solo se la presentazione supera le limitazioni sopra. È la modalità predefinita.
- `Never` non usa mai le estensioni ZIP64.
- `Always` usa sempre le estensioni ZIP64.

Il codice seguente dimostra come salvare una presentazione come PPTX con le estensioni ZIP64 abilitate:

```cs
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        Zip64Mode = Zip64Mode.Always
    });
}
```

{{% alert title="NOTE" color="warning" %}}
Quando salvi con `Zip64Mode.Never`, viene generata un'eccezione [PptxException](https://reference.aspose.com/slides/it/net/aspose.slides/pptxexception/) se la presentazione non può essere salvata nel formato ZIP32.
{{% /alert %}}

## **Salva presentazioni senza aggiornare la miniatura**

La proprietà [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/it/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) controlla la generazione della miniatura quando si salva una presentazione in PPTX:

- Se impostata su `true`, la miniatura viene aggiornata durante il salvataggio. È il valore predefinito.
- Se impostata su `false`, la miniatura corrente viene mantenuta. Se la presentazione non ha una miniatura, non ne viene generata alcuna.

Nel codice sotto, la presentazione viene salvata in PPTX senza aggiornare la sua miniatura.

```cs
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        RefreshThumbnail = false
    });
}
```

{{% alert title="Info" color="info" %}}
Questa opzione aiuta a ridurre il tempo necessario per salvare una presentazione nel formato PPTX.
{{% /alert %}}

## **Salva aggiornamenti di avanzamento in percentuale**

L'interfaccia [IProgressCallback](https://reference.aspose.com/slides/it/net/aspose.slides/iprogresscallback/) viene utilizzata tramite la proprietà `ProgressCallback` esposta dall'interfaccia [ISaveOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/isaveoptions/) e dalla classe astratta [SaveOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/saveoptions/). Assegna un'implementazione di [IProgressCallback](https://reference.aspose.com/slides/it/net/aspose.slides/iprogresscallback/) a `ProgressCallback` per ricevere aggiornamenti di avanzamento del salvataggio in percentuale.

Il codice seguente mostra come utilizzare `IProgressCallback`.

```cs
ISaveOptions saveOptions = new PdfOptions();
saveOptions.ProgressCallback = new ExportProgressHandler();

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pdf", SaveFormat.Pdf, saveOptions);
}
```

```cs
class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        // Usa qui il valore percentuale di avanzamento.
        int progress = Convert.ToInt32(progressValue);

        Console.WriteLine(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Aspose ha sviluppato un'applicazione gratuita [PowerPoint Splitter](https://products.aspose.app/slides/it/splitter) utilizzando la propria API. L'app consente di dividere una presentazione in più file salvando le diapositive selezionate come nuovi file PPTX o PPT.
{{% /alert %}}

## **FAQ**

**Il \"fast save\" (salvataggio incrementale) è supportato in modo che vengano scritte solo le modifiche?**

No. Il salvataggio crea il file di destinazione completo ogni volta; il \"fast save\" incrementale non è supportato.

**È sicuro salvare la stessa istanza di Presentation da più thread?**

No. Un'istanza di [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) [non è thread‑safe](/slides/it/net/multithreading/); salvala da un singolo thread.

** cosa succede a collegamenti ipertestuali e file collegati esternamente durante il salvataggio?**

I [collegamenti ipertestuali](/slides/it/net/manage-hyperlinks/) vengono preservati. I file collegati esternamente (ad es. video tramite percorsi relativi) non vengono copiati automaticamente: assicurati che i percorsi di riferimento rimangano accessibili.

**Posso impostare/salvare i metadati del documento (Autore, Titolo, Azienda, Data)?**

Sì. Le [proprietà del documento](/slides/it/net/presentation-properties/) standard sono supportate e verranno scritte nel file al momento del salvataggio.