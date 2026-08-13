---
title: Personalizza i font PowerPoint in C++
linktitle: Font personalizzato
type: docs
weight: 20
url: /it/cpp/custom-font/
keywords:
- font
- font personalizzato
- font esterno
- caricare font
- gestire font
- cartella dei font
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Personalizza i font nelle diapositive PowerPoint con Aspose.Slides per C++ per mantenere le tue presentazioni nitide e coerenti su qualsiasi dispositivo."
---
## **Panoramica**

Aspose.Slides consente di utilizzare caratteri personalizzati nelle presentazioni senza installarli sul sistema operativo. È possibile caricare i caratteri da cartelle personalizzate, fornire caratteri per una presentazione specifica tramite font a livello di documento, oppure caricare caratteri esterni direttamente da dati binari.

I caratteri caricati vengono utilizzati quando una presentazione viene renderizzata o esportata, ad esempio in PDF, immagini e altri formati supportati. Questo aiuta a mantenere coerente l'output della presentazione in ambienti diversi. L'articolo spiega anche come ispezionare le cartelle dei caratteri utilizzate da Aspose.Slides e come svuotare la cache dei caratteri dopo aver lavorato con caratteri esterni.

La registrazione di caratteri personalizzati per il rendering è separata dall'incorporamento dei caratteri in un file PPTX. Se un carattere deve essere memorizzato all'interno della presentazione, utilizzare esplicitamente le funzionalità di incorporamento dei caratteri.

{{% alert color="info" %}} 
Aspose Slides consente di caricare questi caratteri usando [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontsloader/loadexternalfonts/):

* TrueType (.ttf) e TrueType Collection (.ttc). Vedi [TrueType](https://en.wikipedia.org/wiki/TrueType).
* OpenType (.otf). Vedi [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Caricare caratteri personalizzati**

Aspose.Slides consente di caricare i caratteri utilizzati in una presentazione senza installarli sul sistema. Questo influisce sull'output di esportazione — ad esempio PDF, immagini e altri formati supportati — in modo che i documenti risultanti siano coerenti in tutti gli ambienti. I caratteri vengono caricati da directory personalizzate.

1. Specificare una o più cartelle che contengono i file dei caratteri.
2. Chiamare il metodo statico [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontsloader/loadexternalfonts/) per caricare i caratteri da quelle cartelle.
3. Caricare e renderizzare/esportare la presentazione.
4. Chiamare [FontsLoader.clearCache](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontsloader/clearcache/) per svuotare la cache dei caratteri.

Il seguente esempio di codice dimostra il processo di caricamento dei caratteri:

```cpp
#include <DOM/Fonts/FontsLoader.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Definisci le cartelle che contengono i file dei font personalizzati.
String externalFontFolder = u"assets/fonts";
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// Carica i font personalizzati dalle cartelle specificate.
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Renderizza/esporta la presentazione (ad es., in PDF, immagini o altri formati) usando i font caricati.
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// Svuota la cache dei font dopo aver terminato il lavoro.
FontsLoader::ClearCache();
```

{{% alert color="info" title="Note" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontsloader/loadexternalfonts/) aggiunge cartelle aggiuntive ai percorsi di ricerca dei caratteri, ma non modifica l'ordine di inizializzazione dei caratteri.
I caratteri sono inizializzati in questo ordine:

1. Il percorso predefinito dei caratteri del sistema operativo.
1. I percorsi caricati tramite [FontsLoader](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontsloader/).

{{%/alert %}}

## **Ottenere cartelle dei caratteri personalizzati**

Aspose.Slides fornisce [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontsloader/getfontfolders/) per consentire di trovare le cartelle dei caratteri. Questo metodo restituisce le cartelle aggiunte tramite il metodo `LoadExternalFonts` e le cartelle dei caratteri di sistema.

Questo codice C++ mostra come utilizzare il metodo [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontsloader/getfontfolders/):

``` cpp
#include <DOM/Fonts/FontsLoader.h>
using namespace Aspose::Slides;

// Questa riga restituisce le cartelle che vengono controllate per i file dei font.
// Sono le cartelle aggiunte tramite il metodo LoadExternalFonts e le cartelle dei font di sistema.
auto fontFolders = FontsLoader::GetFontFolders();
```

## **Specificare i caratteri personalizzati usati con una presentazione**

Aspose.Slides fornisce la proprietà [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/it/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) per consentire di specificare i caratteri esterni che saranno usati con la presentazione.

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
    //lavorare con la presentazione
    //CustomFont1, CustomFont2 così come i font dalle cartelle assets\fonts e global\fonts e le loro sottocartelle sono disponibili per la presentazione
}
```

## **Gestire i caratteri esternamente**

Aspose.Slides fornisce il metodo [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontsloader/loadexternalfont/) per consentire di caricare caratteri esterni in un array di byte.

Questo codice C++ dimostra il processo di caricamento dei caratteri in un array di byte:

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IFontSources.h>
#include <system/io/file.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

// Il percorso alla directory dei documenti
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

### I caratteri personalizzati influiscono sull'esportazione in tutti i formati (PDF, PNG, SVG, HTML)?

Sì. I caratteri collegati vengono utilizzati dal renderer in tutti i formati di esportazione.

### I caratteri personalizzati vengono incorporati automaticamente nel PPTX risultante?

No. Registrare un carattere per il rendering non è la stessa cosa di incorporarlo in un PPTX. Se è necessario che il carattere sia contenuto all'interno del file di presentazione, è necessario utilizzare le esplicite [funzionalità di incorporamento](/slides/it/cpp/embedded-font/).

### Posso controllare il comportamento di fallback quando un carattere personalizzato manca di alcuni glifi?

Sì. Configura [sostituzione dei caratteri](/slides/it/cpp/font-substitution/), [regole di sostituzione](/slides/it/cpp/font-replacement/), e [insiemi di fallback](/slides/it/cpp/fallback-font/) per definire esattamente quale carattere viene usato quando il glifo richiesto è mancante.

### Posso utilizzare i caratteri in contenitori Linux/Docker senza installarli a livello di sistema?

Sì. Puntare alle proprie cartelle dei caratteri o caricare i caratteri da array di byte. Questo elimina qualsiasi dipendenza dalle directory dei caratteri di sistema nell'immagine del contenitore.

### Cosa riguarda le licenze — posso incorporare qualsiasi carattere personalizzato senza restrizioni?

Sei responsabile della conformità alle licenze dei caratteri. I termini variano; alcune licenze vietano l'incorporamento o l'uso commerciale. Consulta sempre l'EULA del carattere prima di distribuire i risultati.