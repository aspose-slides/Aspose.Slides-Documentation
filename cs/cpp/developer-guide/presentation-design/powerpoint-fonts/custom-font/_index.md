---
title: Přizpůsobení písem PowerPointu v C++
linktitle: Vlastní písmo
type: docs
weight: 20
url: /cs/cpp/custom-font/
keywords:
- písmo
- vlastní písmo
- externí písmo
- načíst písmo
- spravovat písma
- složka písem
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Přizpůsobte písma v PowerPoint snímcích pomocí Aspose.Slides pro C++, aby vaše prezentace byly ostré a konzistentní na jakémkoli zařízení."
---
## **Přehled**

Aspose.Slides vám umožňuje používat vlastní písma v prezentacích, aniž byste je museli instalovat do operačního systému. Můžete načíst písma z vlastních složek, poskytnout písma pro konkrétní prezentaci prostřednictvím zdrojů písem na úrovni dokumentu, nebo načíst externí písma přímo z binárních dat.

Načtená písma jsou používána při vykreslování nebo exportu prezentace, například do PDF, obrázků a dalších podporovaných formátů. Tím se zajistí, aby výstup prezentace byl konzistentní napříč různými prostředími. Článek také vysvětluje, jak zkontrolovat složky písem používané Aspose.Slides a jak vymazat mezipaměť písem po práci s externími písmy.

Registrace vlastních písem pro vykreslování je oddělena od vkládání písem do souboru PPTX. Pokud musí být písmo uloženo přímo v prezentaci, použijte výslovně funkce vkládání písem.

{{% alert color="info" %}} 

Aspose Slides vám umožňuje načíst tato písma pomocí [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontsloader/loadexternalfonts/):

* TrueType (.ttf) a TrueType Collection (.ttc) písma. Viz [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) písma. Viz [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Načíst vlastní písma**

Aspose.Slides vám umožňuje načíst písma použité v prezentaci, aniž byste je instalovali do systému. To ovlivňuje výstup exportu — například PDF, obrázky a další podporované formáty — takže výsledné dokumenty vypadají konzistentně napříč prostředími. Písma jsou načítána z vlastních adresářů.

1. Zadejte jeden nebo více složek, které obsahují soubory písem.
2. Zavolejte statickou metodu [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontsloader/loadexternalfonts/) pro načtení písem z těchto složek.
3. Načtěte a vykreslete/exportujte prezentaci.
4. Zavolejte [FontsLoader.clearCache](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontsloader/clearcache/) pro vymazání mezipaměti písem.

Následující ukázka kódu demonstruje proces načítání písem:

```cpp
#include <DOM/Fonts/FontsLoader.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Definujte složky, které obsahují vlastní soubory písem.
String externalFontFolder = u"assets/fonts";
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// Načtěte vlastní písma ze zadaných složek.
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Vykreslete/exportujte prezentaci (např. do PDF, obrázků nebo jiných formátů) pomocí načtených písem.
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// Vymažte mezipaměť písem po dokončení práce.
FontsLoader::ClearCache();
```

{{% alert color="info" title="Note" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontsloader/loadexternalfonts/) přidává další složky do cest pro vyhledávání písem, ale nemění pořadí inicializace písem.  
Písma jsou inicializována v tomto pořadí:

1. Výchozí cesta operačního systému k písmům.
1. Cesty načtené pomocí [FontsLoader](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontsloader/).

{{%/alert %}}

## **Získat vlastní složky písem**
Aspose.Slides poskytuje [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontsloader/getfontfolders/), který vám umožní najít složky s písmy. Tato metoda vrací složky přidané pomocí metody `LoadExternalFonts` a systémové složky písem.

Tento C++ kód vám ukazuje, jak použít metodu [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontsloader/getfontfolders/):

``` cpp
#include <DOM/Fonts/FontsLoader.h>
using namespace Aspose::Slides;

// Tento řádek vypisuje složky, které jsou kontrolovány pro soubory písem.
// Jedná se o složky přidané metodou LoadExternalFonts a systémové složky písem.
auto fontFolders = FontsLoader::GetFontFolders();
```

## **Zadat vlastní písma používaná v prezentaci**
Aspose.Slides poskytuje vlastnost [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/cs/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/), která vám umožní zadat externí písma, která budou použita v prezentaci.

Tento C++ kód vám ukazuje, jak použít vlastnost [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/cs/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/):

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
    //pracujte s prezentací
    //CustomFont1, CustomFont2 stejně jako písma ze složek assets\fonts & global\fonts a jejich podsložek jsou k dispozici pro prezentaci
}
```

## **Spravovat písma externě**
Aspose.Slides poskytuje metodu [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontsloader/loadexternalfont/), která vám umožní načíst externí písma do bajtového pole.

Tento C++ kód demonstruje proces načítání písem do bajtového pole:

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IFontSources.h>
#include <system/io/file.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

// Cesta k adresáři dokumentů
const String outPath = u"../out/SpecifyFontsUsedWithPresentation.pptx";
const String templatePath = u"../templates/AccessSlides.pptx";

ArrayPtr<String> fontsLocation =  MakeArray<System::String>({ u"assets\\fonts", u"global\\fonts" });// ;
ArrayPtr<ArrayPtr<uint8_t>> memoryfontsLocation = MakeArray < ArrayPtr<uint8_t>>({ File::ReadAllBytes(u"../templates/CustomFont1.ttf"), File::ReadAllBytes(u"../templates/CustomFont2.ttf") });

SharedPtr < Aspose::Slides::LoadOptions > loadOptions = MakeObject <Aspose::Slides::LoadOptions>();

loadOptions->get_DocumentLevelFontSources()->set_FontFolders(fontsLocation);
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(memoryfontsLocation);
	
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath, loadOptions);
```

## **Často kladené otázky**

### Ovlivňují vlastní písma export do všech formátů (PDF, PNG, SVG, HTML)?

Ano. Připojená písma jsou používána rendererem ve všech exportních formátech.

### Jsou vlastní písma automaticky vložena do výsledného PPTX?

Ne. Registrace písma pro vykreslování není totéž jako jeho vložení do PPTX. Pokud potřebujete, aby písmo bylo součástí souboru prezentace, musíte použít výslovně [embedding features](/slides/cs/cpp/embedded-font/).

### Mohu řídit chování náhradního písma, když vlastní písmo postrádá určité glyfy?

Ano. Nakonfigurujte [font substitution](/slides/cs/cpp/font-substitution/), [replacement rules](/slides/cs/cpp/font-replacement/) a [fallback sets](/slides/cs/cpp/fallback-font/) pro přesné určení, které písmo se použije, když požadovaný glyf chybí.

### Mohu používat písma v Linux/Docker kontejnerech bez jejich systémové instalace?

Ano. Odkazujte na vlastní složky s písmy nebo načítejte písma z bajtových polí. Tím odstraníte jakoukoli závislost na systémových složkách písem v obrazu kontejneru.

### Co se týká licencí — mohu vložit jakékoli vlastní písmo bez omezení?

Vy jste zodpovědní za dodržování licenčních podmínek písma. Podmínky se liší; některé licence zakazují vkládání nebo komerční použití. Vždy si před šířením výstupů přečtěte EULA daného písma.