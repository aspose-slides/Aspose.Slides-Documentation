---
title: Incorporare i font nelle presentazioni in C++
linktitle: Font incorporati
type: docs
weight: 40
url: /it/cpp/embedded-font/
keywords:
- aggiungere font
- incorporare font
- incorporamento dei font
- recuperare font incorporato
- aggiungere font incorporato
- rimuovere font incorporato
- comprimere font incorporato
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Gestisci i font incorporati in PowerPoint con Aspose.Slides per C++. Aggiungi, recupera, rimuovi e comprimi i font per preservare l'aspetto del testo e ridurre le dimensioni del file."
---
## **Introduzione**

L'incorporamento dei caratteri memorizza i dati dei font all'interno di una presentazione PowerPoint. Quando un visualizzatore supporta i font incorporati, può visualizzare il testo con quei caratteri anche se non sono installati sul sistema di destinazione. Questo aiuta a preservare le interruzioni di riga, la spaziatura del testo e il layout delle diapositive.

Aspose.Slides per C++ consente di recuperare, aggiungere e rimuovere i font incorporati tramite il metodo [Presentation::get_FontsManager](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/get_fontsmanager/) di una [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/). È inoltre possibile ridurre le dimensioni dei dati dei font incorporati rimuovendo i caratteri che la presentazione non utilizza.

Gli esempi seguenti funzionano con file PPTX. Prima di incorporare un font, assicurarsi che i dati del font siano disponibili per Aspose.Slides e che la licenza consenta l'incorporamento.

## **Recupero e rimozione dei font incorporati**

Utilizzare [IFontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/it/cpp/aspose.slides/ifontsmanager/getembeddedfonts/) per elencare i font memorizzati in una presentazione. Per rimuoverne uno, passare un font da quell'elenco a [IFontsManager::RemoveEmbeddedFont](https://reference.aspose.com/slides/it/cpp/aspose.slides/ifontsmanager/removeembeddedfont/), quindi salvare la presentazione.

L'esempio seguente elenca i font incorporati in `EmbeddedFonts.pptx` e rimuove Calibri se presente:

```cpp
#include <DOM/IFontData.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"EmbeddedFonts.pptx");
auto fontsManager = presentation->get_FontsManager();
auto embeddedFonts = fontsManager->GetEmbeddedFonts();
SharedPtr<IFontData> fontToRemove;

for (auto&& font : embeddedFonts)
{
    Console::WriteLine(font->get_FontName());

    if (String::Equals(font->get_FontName(), u"Calibri", StringComparison::OrdinalIgnoreCase))
    {
        fontToRemove = font;
    }
}

if (fontToRemove != nullptr)
{
    fontsManager->RemoveEmbeddedFont(fontToRemove);
    presentation->Save(u"WithoutEmbeddedCalibri.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"Calibri is not embedded. No output file was created.");
}

presentation->Dispose();
```

Rimuovere un font incorporato elimina i dati del font memorizzati; non cambia il font assegnato al testo. Se il font è installato sul sistema di destinazione, il testo può comunque usarlo. Altrimenti, il rendering potrebbe richiedere la [font substitution](/slides/it/cpp/font-substitution/), il che può influire sul layout.

## **Ispezione dei dati dei font e dei permessi di incorporamento**

Utilizzare l'interfaccia [IFontsManager](https://reference.aspose.com/slides/it/cpp/aspose.slides/ifontsmanager/) per ispezionare i font prima di incorporarli. Chiamare [IFontsManager::GetFonts](https://reference.aspose.com/slides/it/cpp/aspose.slides/ifontsmanager/getfonts/) per recuperare i font utilizzati nella presentazione. Per ciascun font, passare un oggetto [IFontData](https://reference.aspose.com/slides/it/cpp/aspose.slides/ifontdata/) e il valore richiesto di [FontStyleType](https://reference.aspose.com/slides/it/cpp/aspose.slides/fontstyletype/) a [IFontsManager::GetFontBytes](https://reference.aspose.com/slides/it/cpp/aspose.slides/ifontsmanager/getfontbytes/). Il metodo restituisce i dati binari per quella variante di stile, oppure `nullptr` quando il font o lo stile richiesto non è disponibile. Non passare un risultato `nullptr` a [IFontsManager::GetFontEmbeddingLevel](https://reference.aspose.com/slides/it/cpp/aspose.slides/ifontsmanager/getfontembeddinglevel/), poiché tale metodo richiede un array di byte.

[EmbeddingLevel](https://reference.aspose.com/slides/it/cpp/aspose.slides/embeddinglevel/) è un'enumerazione a flag che segnala le restrizioni di incorporamento memorizzate nel font:

- `Installable` consente l'incorporamento e l'installazione permanente su un altro sistema, soggetto alla licenza del font.
- `Restricted` proibisce l'incorporamento a meno che non venga ottenuta l'autorizzazione dal proprietario legale del font quando è l'unico flag di permesso d'uso.
- `PreviewPrint` consente l'uso temporaneo per visualizzazione e stampa; un documento contenente il font deve essere di sola lettura.
- `Editable` consente l'uso temporaneo e permette al documento di essere modificato e salvato.
- `NoSubsetting` è una restrizione aggiuntiva che proibisce l'incorporamento di una sola sottoinsieme di glifi. Incorporare tutti i caratteri quando questo flag è presente.
- `BitmapOnly` è una restrizione aggiuntiva che consente di incorporare solo le versioni bitmap, non i dati di contorno. Se il font non dispone di versioni bitmap, non può essere incorporato.

I primi quattro valori descrivono il permesso di utilizzo, mentre `NoSubsetting` e `BitmapOnly` possono essere combinati con essi. Verificare i modificatori con operazioni bitwise. Poiché `Installable` è zero, mascherare i bit di permesso d'uso e confrontare il risultato con `Installable`. I font attuali dovrebbero impostare al massimo un bit di permesso d'uso. Per compatibilità con i font più vecchi che impostano più di uno, l'aiutante sottostante seleziona il permesso meno restrittivo: `Editable`, poi `PreviewPrint`, poi `Restricted`.

L'esempio seguente verifica i dati regolari, grassetto, corsivo e grassetto‑corsivo disponibili per ogni font restituito da `GetFonts`. Ignora gli stili non disponibili, i font restritti, i font solo bitmap, i font limitati a anteprima e stampa perché l'output rimane modificabile, e i font già incorporati. Se un qualsiasi stile disponibile presenta `NoSubsetting`, incorpora tutti i caratteri per quella famiglia di font.

```cpp
#include <DOM/EmbeddingLevel.h>
#include <DOM/FontStyleType.h>
#include <DOM/IFontData.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <Export/EmbedFontCharacters.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/collections/list.h>
#include <system/collections/sorted_set.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparer.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Collections::Generic;

auto getUsagePermission = [](EmbeddingLevel level)
{
    const auto permissionMask = EmbeddingLevel::Restricted | EmbeddingLevel::PreviewPrint | EmbeddingLevel::Editable;
    auto permissions = level & permissionMask;

    if ((permissions & EmbeddingLevel::Editable) != EmbeddingLevel::Installable)
    {
        return EmbeddingLevel::Editable;
    }

    if ((permissions & EmbeddingLevel::PreviewPrint) != EmbeddingLevel::Installable)
    {
        return EmbeddingLevel::PreviewPrint;
    }

    if ((permissions & EmbeddingLevel::Restricted) != EmbeddingLevel::Installable)
    {
        return EmbeddingLevel::Restricted;
    }

    return EmbeddingLevel::Installable;
};

auto presentation = MakeObject<Presentation>(u"Fonts.pptx");
auto fontsManager = presentation->get_FontsManager();
auto fontStyles = MakeArray<FontStyleType>({
    FontStyleType::Regular,
    FontStyleType::Bold,
    FontStyleType::Italic,
    FontStyleType::Bold | FontStyleType::Italic
});
auto fontStyleNames = MakeArray<String>({u"regular", u"bold", u"italic", u"bold-italic"});

auto embeddedFontNames = MakeObject<SortedSet<String>>(StringComparer::get_OrdinalIgnoreCase());
for (auto&& embeddedFont : fontsManager->GetEmbeddedFonts())
{
    embeddedFontNames->Add(embeddedFont->get_FontName());
}

auto fontsToEmbedAll = MakeObject<List<SharedPtr<IFontData>>>();
auto fontsToEmbedUsedOnly = MakeObject<List<SharedPtr<IFontData>>>();
for (auto&& font : fontsManager->GetFonts())
{
    if (embeddedFontNames->Contains(font->get_FontName()))
    {
        Console::WriteLine(u"{0}: already embedded.", font->get_FontName());
        continue;
    }

    auto hasAvailableData = false;
    auto allAvailableStylesCanBeEmbedded = true;
    auto previewPrintOnly = false;
    auto requiresFullFont = false;

    for (auto styleIndex = 0; styleIndex < fontStyles->get_Length(); styleIndex++)
    {
        auto fontStyle = fontStyles[styleIndex];
        auto fontBytes = fontsManager->GetFontBytes(font, fontStyle);
        if (fontBytes == nullptr)
        {
            Console::WriteLine(u"{0} ({1}): font data is unavailable.", font->get_FontName(), fontStyleNames[styleIndex]);
            continue;
        }

        hasAvailableData = true;
        auto embeddingLevel = fontsManager->GetFontEmbeddingLevel(fontBytes, font->get_FontName());
        auto usagePermission = getUsagePermission(embeddingLevel);
        auto noSubsetting = (embeddingLevel & EmbeddingLevel::NoSubsetting) != EmbeddingLevel::Installable;
        auto bitmapOnly = (embeddingLevel & EmbeddingLevel::BitmapOnly) != EmbeddingLevel::Installable;

        requiresFullFont |= noSubsetting;
        previewPrintOnly |= usagePermission == EmbeddingLevel::PreviewPrint;
        allAvailableStylesCanBeEmbedded &= usagePermission != EmbeddingLevel::Restricted && !bitmapOnly;

        Console::WriteLine(u"{0} ({1}): embedding level {2}.", font->get_FontName(), fontStyleNames[styleIndex], static_cast<uint16_t>(embeddingLevel));
    }

    if (!hasAvailableData)
    {
        Console::WriteLine(u"{0}: skipped because no requested style is available.", font->get_FontName());
    }
    else if (!allAvailableStylesCanBeEmbedded)
    {
        Console::WriteLine(u"{0}: skipped because at least one available style does not permit outline embedding.", font->get_FontName());
    }
    else if (previewPrintOnly)
    {
        Console::WriteLine(u"{0}: skipped because this example produces an editable presentation.", font->get_FontName());
    }
    else if (requiresFullFont)
    {
        fontsToEmbedAll->Add(font);
    }
    else
    {
        fontsToEmbedUsedOnly->Add(font);
    }
}

for (auto&& font : fontsToEmbedAll)
{
    fontsManager->AddEmbeddedFont(font, EmbedFontCharacters::All);
}

for (auto&& font : fontsToEmbedUsedOnly)
{
    fontsManager->AddEmbeddedFont(font, EmbedFontCharacters::OnlyUsed);
}

presentation->Save(u"WithAuditedFonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Questa ispezione segnala le restrizioni codificate in ciascun file di font. Non concede una licenza, non dimostra che il font sia stato ottenuto legalmente, né sostituisce il controllo dell'accordo di licenza del font prima di distribuire una copia incorporata.

## **Aggiunta di font incorporati**

Utilizzare [IFontsManager::AddEmbeddedFont](https://reference.aspose.com/slides/it/cpp/aspose.slides/ifontsmanager/addembeddedfont/) per incorporare un font. Le sue overload accettano sia un oggetto [IFontData](https://reference.aspose.com/slides/it/cpp/aspose.slides/ifontdata/) sia un array di byte contenente i dati del font. L'enumerazione [EmbedFontCharacters](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/embedfontcharacters/) controlla quali caratteri vengono inclusi:

- [All](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/embedfontcharacters/) incorpora tutti i caratteri nel font. Utilizzare questa opzione quando i destinatari devono modificare la presentazione e inserire nuovo testo.
- [OnlyUsed](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/embedfontcharacters/) incorpora solo i caratteri usati nella presentazione per ridurre la dimensione del file. Scegliere questa opzione per una presentazione finale destinata principalmente alla visualizzazione.

L'esempio seguente utilizza [IFontsManager::GetFonts](https://reference.aspose.com/slides/it/cpp/aspose.slides/ifontsmanager/getfonts/) per recuperare i font usati in `Fonts.pptx` e incorpora quelli non già incorporati. I font da aggiungere devono essere disponibili sulla macchina che esegue il codice. I font già incorporati mantengono i set di caratteri attuali.

```cpp
#include <DOM/IFontData.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <Export/EmbedFontCharacters.h>
#include <Export/SaveFormat.h>
#include <system/collections/sorted_set.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparer.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Collections::Generic;

auto presentation = MakeObject<Presentation>(u"Fonts.pptx");
auto fontsManager = presentation->get_FontsManager();
auto allFonts = fontsManager->GetFonts();
auto embeddedFonts = fontsManager->GetEmbeddedFonts();
auto embeddedFontNames = MakeObject<SortedSet<String>>(StringComparer::get_OrdinalIgnoreCase());

for (auto&& embeddedFont : embeddedFonts)
{
    embeddedFontNames->Add(embeddedFont->get_FontName());
}

for (auto&& font : allFonts)
{
    if (!embeddedFontNames->Contains(font->get_FontName()))
    {
        fontsManager->AddEmbeddedFont(font, EmbedFontCharacters::All);
        embeddedFontNames->Add(font->get_FontName());
    }
}

presentation->Save(u"WithEmbeddedFonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Compressione dei font incorporati**

[Compress::CompressEmbeddedFonts](https://reference.aspose.com/slides/it/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) riduce i dati dei font incorporati rimuovendo i caratteri inutilizzati. Funziona sui font già incorporati, quindi la riduzione delle dimensioni dipende da quante informazioni di font inutilizzate contiene la presentazione.

L'esempio seguente comprime i font in `EmbeddedFonts.pptx` e salva il risultato in un file separato:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;
using namespace System;

auto presentation = MakeObject<Presentation>(u"EmbeddedFonts.pptx");
Compress::CompressEmbeddedFonts(presentation);
presentation->Save(u"CompressedEmbeddedFonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Conservare il file originale se i destinatari potrebbero aver bisogno di aggiungere testo in seguito. I caratteri rimossi durante la compressione non sono più disponibili dal font incorporato, anche se in origine era stato incorporato l'intero set di caratteri.

## **FAQ**

**Come posso verificare se un font incorporato verrà comunque sostituito durante il rendering?**

Chiamare [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/it/cpp/aspose.slides/ifontsmanager/getsubstitutions/) nell'ambiente in cui si rende la presentazione per vedere quali font Aspose.Slides sostituirà. Controllare anche le impostazioni di [font substitution](/slides/it/cpp/font-substitution/) e le regole di [font fallback](/slides/it/cpp/fallback-font/). Il fallback gestisce i caratteri mancanti, quindi incorporare un font non risolve i caratteri che il font stesso non contiene.

**Devo incorporare font comuni come Arial e Calibri?**

Basare la decisione sull'ambiente di destinazione. Se i font richiesti sono disponibili su ogni macchina che apre o rende la presentazione, incorporarli potrebbe aumentare inutilmente la dimensione del file. Se i destinatari o i server potrebbero non avere quei font, incorporarli può aiutare a preservare l'aspetto previsto, a condizione che le licenze lo consentano.