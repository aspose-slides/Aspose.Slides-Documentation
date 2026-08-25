---
title: Personalizza i font di PowerPoint in C++
linktitle: Font personalizzato
type: docs
weight: 20
url: /it/cpp/custom-font/
keywords:
- font
- font personalizzato
- font esterno
- caricare font
- gestire i font
- cartella font
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Personalizza i font nelle diapositive PowerPoint con Aspose.Slides per C++ per mantenere le tue presentazioni nitide e coerenti su qualsiasi dispositivo."
---
## **Panoramica**

Aspose.Slides consente di utilizzare font personalizzati nelle presentazioni senza installarli nel sistema operativo. È possibile caricare i font da cartelle personalizzate, fornire font per una presentazione specifica tramite font a livello di documento o caricare font esterni direttamente da dati binari.

I font caricati vengono utilizzati quando una presentazione viene renderizzata o esportata, ad esempio in PDF, immagini e altri formati supportati. Questo aiuta a mantenere l'output della presentazione coerente tra ambienti diversi. L'articolo spiega anche come ispezionare le cartelle dei font usate da Aspose.Slides e come cancellare la cache dei font dopo aver lavorato con font esterni.

La registrazione di font personalizzati per il rendering è separata dall'incorporamento dei font in un file PPTX. Se un font deve essere memorizzato all'interno della presentazione stessa, utilizzare esplicitamente le funzionalità di incorporamento dei font.

Un tema di presentazione può fare riferimento a diverse famiglie di font per singoli sistemi di scrittura. queste mappature memorizzano i nomi dei font ma non installano né caricano i file dei font. Vedere [Script-Specific Theme Fonts](/slides/it/cpp/script-specific-font-mappings/) per gestire le mappature e utilizzare le opzioni di caricamento qui sotto per rendere i font di riferimento disponibili per un rendering coerente.

{{% alert color="info" title="Note" %}}

Aspose Slides consente di caricare questi font usando [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontsloader/loadexternalfonts/):

* Font TrueType (.ttf) e TrueType Collection (.ttc). Vedere [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Font OpenType (.otf). Vedere [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Caricare Font Personalizzati**

Aspose.Slides consente di caricare i font utilizzati in una presentazione senza installarli sul sistema. Questo influisce sull'output di esportazione—come PDF, immagini e altri formati supportati—così i documenti risultanti hanno un aspetto coerente tra ambienti. I font vengono caricati da directory personalizzate.

1. Specificare una o più cartelle che contengono i file dei font.  
2. Chiamare il metodo statico [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontsloader/loadexternalfonts/) per caricare i font da tali cartelle.  
3. Caricare e renderizzare/esportare la presentazione.  
4. Chiamare [FontsLoader.clearCache](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontsloader/clearcache/) per cancellare la cache dei font.

Il seguente esempio di codice dimostra il processo di caricamento dei font:

```cpp
#include <DOM/Fonts/FontsLoader.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Definisci le cartelle che contengono i file di font personalizzati.
String externalFontFolder = u"assets/fonts";
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// Carica i font personalizzati dalle cartelle specificate.
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Renderizza/esporta la presentazione (ad esempio, in PDF, immagini o altri formati) usando i font caricati.
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// Svuota la cache dei font dopo che il lavoro è terminato.
FontsLoader::ClearCache();
```

{{% alert color="info" title="Note" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontsloader/loadexternalfonts/) aggiunge cartelle aggiuntive ai percorsi di ricerca dei font, ma non modifica l'ordine di inizializzazione dei font.  
I font vengono inizializzati in questo ordine:

1. Il percorso predefinito dei font del sistema operativo.  
1. I percorsi caricati tramite [FontsLoader](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontsloader/).

{{%/alert %}}

## **Ottenere Cartelle di Font Personalizzati**

Aspose.Slides fornisce [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontsloader/getfontfolders/) per consentire di trovare le cartelle dei font. Questo metodo restituisce le cartelle aggiunte tramite il metodo `LoadExternalFonts` e le cartelle di sistema dei font.

Questo codice C++ mostra come utilizzare il metodo [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontsloader/getfontfolders()):

``` cpp
#include <DOM/Fonts/FontsLoader.h>
using namespace Aspose::Slides;

// Questa riga restituisce le cartelle che vengono controllate per i file di font.
// Sono le cartelle aggiunte tramite il metodo LoadExternalFonts e le cartelle di sistema dei font.
auto fontFolders = FontsLoader::GetFontFolders();
```

## **Specificare Font Personalizzati Usati con una Presentazione**

Aspose.Slides fornisce la proprietà [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/it/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) per consentire di specificare font esterni che verranno usati con la presentazione.

Questo codice C++ mostra come utilizzare la proprietà [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/it/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/):

``` cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IFontSources.h>
#include <system/io/file.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    //lavora con la presentazione
    //CustomFont1, CustomFont2 così come i font dalle cartelle assets\fonts e global\fonts e dalle loro sottocartelle sono disponibili per la presentazione
}
```

## **Gestire i Font Esternamente**

Aspose.Slides fornisce il metodo [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontsloader/loadexternalfont/) per consentire di caricare font esterni in un array di byte.

Questo codice C++ dimostra il processo di caricamento del font in un array di byte:

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IFontSources.h>
#include <system/io/file.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

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

## **FAQ**

### I font personalizzati influiscono sull'esportazione in tutti i formati (PDF, PNG, SVG, HTML)?

Sì. I font collegati vengono utilizzati dal renderer in tutti i formati di esportazione.

### I font personalizzati vengono incorporati automaticamente nel PPTX risultante?

No. Registrare un font per il rendering non è la stessa cosa dell'incorporarlo in un PPTX. Se è necessario che il font sia contenuto nel file della presentazione, occorre utilizzare esplicitamente le [funzionalità di incorporamento](/slides/it/cpp/embedded-font/).

### Posso controllare il comportamento di fallback quando un font personalizzato manca di alcuni glifi?

Sì. Configurare la [sostituzione dei font](/slides/it/cpp/font-substitution/), le [regole di sostituzione](/slides/it/cpp/font-replacement/) e i [set di fallback](/slides/it/cpp/fallback-font/) per definire esattamente quale font usare quando il glifo richiesto è assente.

### Posso usare i font in container Linux/Docker senza installarli a livello di sistema?

Sì. Puntare alle proprie cartelle di font o caricare i font da array di byte. In questo modo non vi è alcuna dipendenza dalle directory di sistema dei font nell'immagine del container.

### E per quanto riguarda le licenze—posso incorporare qualsiasi font personalizzato senza restrizioni?

Sei responsabile della conformità alle licenze dei font. I termini variano; alcune licenze vietano l'incorporamento o l'uso commerciale. Consulta sempre l'EULA del font prima di distribuire gli output.