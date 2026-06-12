---
title: Salva presentazioni in C++
linktitle: Salva presentazione
type: docs
weight: 80
url: /it/cpp/save-presentation/
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
- tipo di vista predefinita
- Formato Strict Office Open XML
- modalità Zip64
- aggiornamento miniatura
- avanzamento salvataggio
- C++
- Aspose.Slides
description: "Scopri come salvare presentazioni in C++ usando Aspose.Slides—esporta in PowerPoint o OpenDocument mantenendo layout, caratteri ed effetti."
---
## **Panoramica**

[Apri presentazioni in C++](/slides/it/cpp/open-presentation/) descrive come utilizzare la classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) per aprire una presentazione. Questo articolo spiega come creare e salvare presentazioni. La classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) contiene il contenuto di una presentazione. Che tu stia creando una presentazione da zero o modificando una esistente, vorrai salvarla al termine. Con Aspose.Slides per C++, puoi salvare su un **file** o **stream**. Questo articolo illustra i diversi modi per salvare una presentazione.

## **Salva presentazioni su file**

Salva una presentazione su file chiamando il metodo `Save` della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/). Passa il nome del file e il formato di salvataggio al metodo. L'esempio seguente mostra come salvare una presentazione con Aspose.Slides.

```cpp
// Istanzia la classe Presentation che rappresenta un file di presentazione.
auto presentation = MakeObject<Presentation>();

// Esegui qualche operazione qui...

// Salva la presentazione su un file.
presentation->Save(u"Output.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Salva presentazioni su stream**

Puoi salvare una presentazione su uno stream passando uno stream di output al metodo `Save` della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/). Una presentazione può essere scritta su molti tipi di stream. Nell'esempio seguente creiamo una nuova presentazione e la salviamo su un file stream.

```cpp
// Istanzia la classe Presentation che rappresenta un file di presentazione.
auto presentation = MakeObject<Presentation>();

auto fileStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

// Salva la presentazione sullo stream.
presentation->Save(fileStream, SaveFormat::Pptx);

presentation->Dispose();
fileStream->Close();
```

## **Salva presentazioni con un tipo di vista predefinito**

Aspose.Slides consente di impostare la vista iniziale che PowerPoint utilizza quando la presentazione generata si apre tramite la classe [ViewProperties](https://reference.aspose.com/slides/it/cpp/aspose.slides/viewproperties/). Usa il metodo [set_LastView](https://reference.aspose.com/slides/it/cpp/aspose.slides/viewproperties/set_lastview/) con un valore dell'enumerazione [ViewType](https://reference.aspose.com/slides/it/cpp/aspose.slides/viewtype/).

```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);

presentation->Save(u"SlideMasterView.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Salva presentazioni nel formato Strict Office Open XML**

Aspose.Slides consente di salvare una presentazione nel formato Strict Office Open XML. Usa la classe [PptxOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/pptxoptions/) e imposta la sua proprietà di conformità durante il salvataggio. Se imposti `Conformance.Iso29500_2008_Strict`, il file di output viene salvato nel formato Strict Office Open XML.

L'esempio seguente crea una presentazione e la salva nel formato Strict Office Open XML.

```cpp
auto options = MakeObject<PptxOptions>();
options->set_Conformance(Conformance::Iso29500_2008_Strict);

// Istanzia la classe Presentation che rappresenta un file di presentazione.
auto presentation = MakeObject<Presentation>();

// Salva la presentazione nel formato Strict Office Open XML.
presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Salva presentazioni nel formato Office Open XML in modalità Zip64**

Un file Office Open XML è un archivio ZIP che impone limiti di 4 GB (2^32 byte) sulla dimensione non compressa di qualsiasi file, sulla dimensione compressa di qualsiasi file e sulla dimensione totale dell'archivio, oltre a limitare l'archivio a 65 535 (2^16‑1) file. Le estensioni del formato ZIP64 aumentano questi limiti a 2^64.

Il metodo [IPptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/ipptxoptions/set_zip64mode/) consente di scegliere quando utilizzare le estensioni ZIP64 durante il salvataggio di un file Office Open XML.

Questo metodo può essere utilizzato con le seguenti modalità:

- `IfNecessary` utilizza le estensioni ZIP64 solo se la presentazione supera le limitazioni sopra indicate. È la modalità predefinita.
- `Never` non utilizza mai le estensioni ZIP64.
- `Always` utilizza sempre le estensioni ZIP64.

Il codice seguente dimostra come salvare una presentazione come PPTX con le estensioni ZIP64 abilitate:

```cpp
auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_Zip64Mode(Zip64Mode::Always);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="NOTE" color="warning" %}}
Quando salvi con `Zip64Mode.Never`, viene generata una [PptxException](https://reference.aspose.com/slides/it/cpp/aspose.slides/pptxexception/) se la presentazione non può essere salvata in formato ZIP32.
{{% /alert %}}

## **Salva presentazioni senza aggiornare la miniatura**

Il metodo [PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/) controlla la generazione della miniatura quando si salva una presentazione in PPTX:

- Se impostato a `true`, la miniatura viene aggiornata durante il salvataggio. È il valore predefinito.
- Se impostato a `false`, la miniatura corrente viene preservata. Se la presentazione non ha una miniatura, non ne viene generata alcuna.

Nel codice seguente la presentazione viene salvata in PPTX senza aggiornare la sua miniatura.

```cpp
auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_RefreshThumbnail(false);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
Questa opzione aiuta a ridurre il tempo necessario per salvare una presentazione in formato PPTX.
{{% /alert %}}

## **Salva aggiornamenti di avanzamento in percentuale**

L'interfaccia [IProgressCallback](https://reference.aspose.com/slides/it/cpp/aspose.slides/iprogresscallback/) viene utilizzata tramite il metodo `set_ProgressCallback` esposto dall'interfaccia [ISaveOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/isaveoptions/) e dalla classe astratta [SaveOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/saveoptions/). Assegna un'implementazione di [IProgressCallback](https://reference.aspose.com/slides/it/cpp/aspose.slides/iprogresscallback/) con `set_ProgressCallback` per ricevere gli aggiornamenti di avanzamento del salvataggio in percentuale.

Gli snippet di codice seguenti mostrano come utilizzare `IProgressCallback`.

```cpp
class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue)
    {
        // Usa qui il valore percentuale di avanzamento.
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};
```
```cpp
auto saveOptions = MakeObject<PdfOptions>();
saveOptions->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, saveOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
Aspose ha sviluppato un [app gratuita per la divisione di PowerPoint](https://products.aspose.app/slides/it/splitter) utilizzando la propria API. L'app consente di dividere una presentazione in più file salvando le diapositive selezionate come nuovi file PPTX o PPT.
{{% /alert %}}

## **FAQ**

**Il “salvataggio veloce” (salvataggio incrementale) è supportato in modo che vengano scritte solo le modifiche?**

No. Il salvataggio crea l'intero file di destinazione ogni volta; il “salvataggio veloce” incrementale non è supportato.

**È sicuro salvare la stessa istanza di Presentation da più thread?**

No. Un'istanza di [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) **non è thread‑safe** (/slides/it/cpp/multithreading/); salvala da un singolo thread.

**Cosa succede a collegamenti ipertestuali e file collegati esternamente durante il salvataggio?**

I [collegamenti ipertestuali](/slides/it/cpp/manage-hyperlinks/) vengono preservati. I file collegati esternamente (ad esempio video tramite percorsi relativi) non vengono copiati automaticamente: assicurati che i percorsi di riferimento rimangano accessibili.

**Posso impostare/salvare i metadati del documento (Autore, Titolo, Azienda, Data)?**

Sì. Le proprietà standard del [documento](/slides/it/cpp/presentation-properties/) sono supportate e verranno scritte nel file al momento del salvataggio.