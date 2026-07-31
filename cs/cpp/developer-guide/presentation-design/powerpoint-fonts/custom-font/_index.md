---
title: Přizpůsobení písem v PowerPointu v C++
linktitle: Vlastní písmo
type: docs
weight: 20
url: /cs/cpp/custom-font/
keywords:
- písmo
- vlastní písmo
- externí písmo
- načíst písmo
- správa písem
- složka písem
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Přizpůsobte písma v PowerPoint snímcích pomocí Aspose.Slides pro C++, aby vaše prezentace byly ostré a konzistentní na jakémkoli zařízení."
---
## **Přehled**

Aspose.Slides umožňuje používat vlastní písma v prezentacích bez jejich instalace do operačního systému. Můžete načíst písma z vlastních složek, poskytnout písma pro konkrétní prezentaci prostřednictvím zdrojů písem na úrovni dokumentu, nebo načíst externí písma přímo z binárních dat.

Načtená písma jsou používána při vykreslování nebo exportu prezentace, například do PDF, obrázků a dalších podporovaných formátů. To pomáhá udržet výstup prezentace konzistentní napříč různými prostředími. Článek také vysvětluje, jak prozkoumat složky písem používané Aspose.Slides a jak vymazat mezipaměť písem po práci s externími písmy.

Registrace vlastních písem pro vykreslování je oddělená od vkládání písem do souboru PPTX. Pokud musí být písmo uloženo přímo v prezentaci, použijte explicitně funkce vkládání písem.

{{% alert color="primary" %}} 
Aspose Slides vám umožňuje načíst tato písma pomocí [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontsloader/loadexternalfonts/):

* TrueType (.ttf) a TrueType Collection (.ttc) písma. Viz [TrueType](https://en.wikipedia.org/wiki/TrueType).
* OpenType (.otf) písma. Viz [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **Načíst vlastní písma**

Aspose.Slides umožňuje načíst písma používaná v prezentaci bez jejich instalace do systému. To ovlivňuje výstup exportu — například PDF, obrázky a další podporované formáty — takže výsledné dokumenty vypadají konzistentně napříč prostředími. Písma jsou načítána z vlastních adresářů.

1. Zadejte jednu nebo více složek, které obsahují soubory písem.
2. Zavolejte statickou metodu [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontsloader/loadexternalfonts/), která načte písma z těchto složek.
3. Načtěte a vykreslete/exportujte prezentaci.
4. Zavolejte [FontsLoader.clearCache](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontsloader/clearcache/) pro vymazání mezipaměti písem.

Následující ukázkový kód demonstruje proces načítání písem:

```cpp
// Definujte složky, které obsahují vlastní soubory písem.
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

1. Výchozí cesta k písmům operačního systému.
1. Cesty načtené pomocí [FontsLoader](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontsloader/).
{{%/alert %}}

## **Získat vlastní složky písem**

Aspose.Slides poskytuje [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontsloader/getfontfolders/), který vám umožní najít složky písem. Tato metoda vrací složky přidané pomocí metody `LoadExternalFonts` a systémové složky písem.

Tento C++ kód vám ukazuje, jak použít metodu [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontsloader/getfontfolders/):

``` cpp
// Tento řádek vypisuje složky, které jsou kontrolovány pro soubory písem.
// Jedná se o složky přidané metodou LoadExternalFonts a systémové složky písem.
auto fontFolders = FontsLoader::GetFontFolders();
```

## **Určení vlastních písem používaných v prezentaci**

Aspose.Slides poskytuje vlastnost [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/cs/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/), která vám umožní určit externí písma, která budou použita s prezentací.

Tento C++ kód vám ukazuje, jak použít vlastnost [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/cs/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/):

``` cpp
auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    //pracujte s prezentací
    //CustomFont1, CustomFont2 i fonty ze složek assets\fonts a global\fonts a jejich podadresářů jsou k dispozici v prezentaci
}
```

## **Správa písem externě**

Aspose.Slides poskytuje metodu [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontsloader/loadexternalfont/), která vám umožní načíst externí písma do pole bytů.

Tento C++ kód demonstruje proces načítání písem do pole bytů:

```cpp
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

## **FAQ**

**Ovlivňují vlastní písma export do všech formátů (PDF, PNG, SVG, HTML)?**

Ano. Připojená písma jsou používána vykreslovacím modulem ve všech exportních formátech.

**Jsou vlastní písma automaticky vložena do výsledného PPTX?**

Ne. Registrace písma pro vykreslování není totéž jako jeho vložení do PPTX. Pokud potřebujete, aby bylo písmo součástí souboru prezentace, musíte použít explicitní [vkládací funkce](/slides/cs/cpp/embedded-font/).

**Mohu řídit chování náhrady, když vlastní písmo postrádá určité glyfy?**

Ano. Nakonfigurujte [substituci písem](/slides/cs/cpp/font-substitution/), [pravidla náhrady](/slides/cs/cpp/font-replacement/) a [sady záložních písem](/slides/cs/cpp/fallback-font/), abyste přesně určili, které písmo se použije, když požadovaný glyf chybí.

**Mohu používat písma v kontejnerech Linux/Docker bez jejich systémové instalace?**

Ano. Odkazujte na své vlastní složky s písmy nebo načtěte písma z polí bytů. Tím se odstraní jakákoli závislost na systémových složkách s písmy v obrazu kontejneru.

**Jak to je s licencováním — mohu vložit jakékoli vlastní písmo bez omezení?**

Vy jste odpovědní za dodržování licencí písem. Podmínky se liší; některé licence zakazují vkládání nebo komerční použití. Vždy si před distribucí výstupů přečtěte licenční smlouvu (EULA) daného písma.