---
title: "Personalizza i caratteri PowerPoint in C++"
linktitle: "Carattere personalizzato"
type: docs
weight: 20
url: /it/cpp/custom-font/
keywords:
- "font"
- "carattere personalizzato"
- "carattere esterno"
- "caricare carattere"
- "gestire i caratteri"
- "cartella dei caratteri"
- "PowerPoint"
- "OpenDocument"
- "presentazione"
- "C++"
- "Aspose.Slides"
description: "Personalizza i caratteri nelle diapositive PowerPoint con Aspose.Slides per C++ per mantenere le tue presentazioni nitide e coerenti su qualsiasi dispositivo."
---
## **Panoramica**

Aspose.Slides consente di utilizzare caratteri personalizzati in presentazioni senza installarli sul sistema operativo. È possibile caricare i caratteri da cartelle personalizzate, fornire caratteri per una presentazione specifica tramite origini di caratteri a livello di documento, oppure caricare caratteri esterni direttamente da dati binari.

I caratteri caricati vengono utilizzati quando una presentazione viene resa o esportata, ad esempio in PDF, immagini e altri formati supportati. Questo aiuta a mantenere l’output della presentazione coerente tra ambienti diversi. L’articolo spiega anche come ispezionare le cartelle dei caratteri usate da Aspose.Slides e come cancellare la cache dei caratteri dopo aver lavorato con caratteri esterni.

La registrazione di caratteri personalizzati per il rendering è separata dall’incorporamento dei caratteri in un file PPTX. Se un carattere deve essere memorizzato all’interno della presentazione stessa, utilizzare esplicitamente le funzionalità di incorporamento dei caratteri.

{{% alert color="primary" %}} 

Aspose Slides consente di caricare questi caratteri usando [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontsloader/loadexternalfonts/):

* Caratteri TrueType (.ttf) e TrueType Collection (.ttc). Vedi [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Caratteri OpenType (.otf). Vedi [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Carica caratteri personalizzati**

Aspose.Slides consente di caricare i caratteri usati in una presentazione senza installarli sul sistema. Questo influisce sull’output di esportazione—come PDF, immagini e altri formati supportati—in modo che i documenti risultanti abbiano un aspetto coerente tra ambienti. I caratteri vengono caricati da directory personalizzate.

1. Specifica una o più cartelle che contengono i file dei caratteri.
2. Chiama il metodo statico [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontsloader/loadexternalfonts/) per caricare i caratteri da quelle cartelle.
3. Carica e rendi/esporta la presentazione.
4. Chiama [FontsLoader.clearCache](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontsloader/clearcache/) per cancellare la cache dei caratteri.

Il seguente esempio di codice dimostra il processo di caricamento dei caratteri:

```cpp
// Definisci le cartelle che contengono file di caratteri personalizzati.
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// Carica i caratteri personalizzati dalle cartelle specificate.
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Esegui il rendering/esportazione della presentazione (ad esempio in PDF, immagini o altri formati) usando i caratteri caricati.
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// Cancella la cache dei caratteri dopo aver terminato il lavoro.
FontsLoader::ClearCache();
```

{{% alert color="info" title="Note" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontsloader/loadexternalfonts/) aggiunge cartelle aggiuntive ai percorsi di ricerca dei caratteri, ma non modifica l’ordine di inizializzazione dei caratteri.
I caratteri vengono inizializzati in questo ordine:

1. Il percorso predefinito dei caratteri del sistema operativo.
1. I percorsi caricati tramite [FontsLoader](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontsloader/).

{{%/alert %}}

## **Ottieni cartelle dei caratteri personalizzati**
Aspose.Slides fornisce [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontsloader/getfontfolders/) per consentire di trovare le cartelle dei caratteri. Questo metodo restituisce le cartelle aggiunte tramite il metodo `LoadExternalFonts` e le cartelle dei caratteri di sistema.

Questo codice C++ mostra come utilizzare il metodo [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontsloader/getfontfolders/):

```cpp
// Questa riga stampa le cartelle controllate per i file dei caratteri.
// Sono le cartelle aggiunte tramite il metodo LoadExternalFonts e le cartelle dei caratteri di sistema.
auto fontFolders = FontsLoader::GetFontFolders();
```

## **Specifica i caratteri personalizzati usati con una presentazione**
Aspose.Slides fornisce la proprietà [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/it/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) per consentire di specificare i caratteri esterni che verranno usati con la presentazione.

Questo codice C++ mostra come utilizzare la proprietà [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/it/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/):

```cpp
auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    //lavora con la presentazione
    //CustomFont1, CustomFont2 così come i caratteri dalle cartelle assets\fonts e global\fonts e le loro sottocartelle sono disponibili per la presentazione
}
```

## **Gestisci i caratteri esternamente**
Aspose.Slides fornisce il metodo [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontsloader/loadexternalfont/) per consentire di caricare caratteri esterni in un array di byte.

Questo codice C++ dimostra il processo di caricamento dei caratteri in un array di byte:

```cpp
// Il percorso della directory dei documenti
const String outPath = u"../out/SpecifyFontsUsedWithPresentation.pptx";
const String templatePath = u"../templates/AccessSlides.pptx";

ArrayPtr<String> fontsLocation =  MakeArray<System::String>({ u"assets\\fonts", u"global\\fonts" });// ;
ArrayPtr<ArrayPtr<uint8_t>> memoryfontsLocation = MakeArray < ArrayPtr<uint8_t>>({ File::ReadAllBytes(u"../templates/CustomFont1.ttf"), File::ReadAllBytes(u"../templates/CustomFont2.ttf") });

SharedPtr < Aspose::Slides::LoadOptions > loadOptions = MakeObject <Aspose::Slides::LoadOptions>();

loadOptions->get_DocumentLevelFontSources()->set_FontFolders(fontsLocation);
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(memoryfontsLocation);
	
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath, loadOptions);
```

## **Domande frequenti**

**I caratteri personalizzati influenzano l'esportazione in tutti i formati (PDF, PNG, SVG, HTML)?**

Sì. I caratteri collegati sono usati dal renderer in tutti i formati di esportazione.

**I caratteri personalizzati vengono automaticamente incorporati nel PPTX risultante?**

No. Registrare un carattere per il rendering non è la stessa cosa di incorporarlo in un PPTX. Se è necessario che il carattere sia incluso nel file della presentazione, è necessario utilizzare le [funzionalità di incorporamento](/slides/it/cpp/embedded-font/).

**Posso controllare il comportamento di fallback quando un carattere personalizzato manca di alcuni glifi?**

Sì. Configura la [sostituzione dei caratteri](/slides/it/cpp/font-substitution/), le [regole di sostituzione](/slides/it/cpp/font-replacement/) e i [set di fallback](/slides/it/cpp/fallback-font/) per definire esattamente quale carattere viene usato quando il glifo richiesto è assente.

**Posso usare i caratteri in contenitori Linux/Docker senza installarli a livello di sistema?**

Sì. Puntare alle proprie cartelle dei caratteri o caricare i caratteri da array di byte. Questo elimina qualsiasi dipendenza dalle directory dei caratteri di sistema nell'immagine del contenitore.

**E per quanto riguarda le licenze—posso incorporare qualsiasi carattere personalizzato senza restrizioni?**

Sei responsabile della conformità alle licenze dei caratteri. I termini variano; alcune licenze vietano l'incorporamento o l'uso commerciale. Controlla sempre l'EULA del carattere prima di distribuire i risultati.