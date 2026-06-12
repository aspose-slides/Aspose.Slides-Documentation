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
- složka s písmy
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Přizpůsobte písma v PowerPoint slidech pomocí Aspose.Slides pro C++, aby vaše prezentace byly ostřejší a konzistentní na jakémkoli zařízení."
---
## **Přehled**

Aspose.Slides vám umožňuje používat vlastní písma v prezentacích, aniž byste je instalovali do operačního systému. Písma můžete načítat z vlastních složek, poskytnout písma pro konkrétní prezentaci prostřednictvím zdrojů písem na úrovni dokumentu, nebo načíst externí písma přímo z binárních dat.

Načtená písma jsou používána při vykreslování nebo exportu prezentace, například do PDF, obrazů a dalších podporovaných formátů. To pomáhá zachovat konzistentní výstup prezentace napříč různými prostředími. Článek také vysvětluje, jak prozkoumat složky s písmy používané Aspose.Slides a jak po práci s externími písmy vyprázdnit mezipaměť písem.

Registrace vlastních písem pro vykreslování je oddělená od vkládání písem do souboru PPTX. Pokud musí být písmo uloženo přímo v prezentaci, použijte funkce vkládání písem explicitně.

{{% alert color="primary" %}} 

Aspose Slides vám umožňuje načíst tato písma pomocí [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontsloader/loadexternalfonts/):

* Písma TrueType (.ttf) a TrueType Collection (.ttc). Viz [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Písma OpenType (.otf). Viz [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Načíst vlastní písma**

Aspose.Slides vám umožňuje načíst písma používaná v prezentaci, aniž byste je instalovali v systému. To ovlivňuje výstup exportu – například PDF, obrázky a další podporované formáty – takže výsledné dokumenty vypadají konzistentně napříč prostředími. Písma jsou načítána z vlastních adresářů.

1. Zadejte jednu nebo více složek obsahujících soubory písem.
2. Zavolejte statickou metodu [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontsloader/loadexternalfonts/), abyste načetli písma z těchto složek.
3. Načtěte a vykreslete/exportujte prezentaci.
4. Zavolejte [FontsLoader.clearCache](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontsloader/clearcache/), abyste vyprázdnili mezipaměť písem.

Následující ukázkový kód demonstruje proces načítání písem:

```cpp
// Definujte složky, které obsahují vlastní soubory písem.
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// Načtěte vlastní písma ze specifikovaných složek.
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Vykreslete/exportujte prezentaci (např. do PDF, obrázků nebo jiných formátů) pomocí načtených písem.
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// Vyprázdněte mezipaměť písem po dokončení práce.
FontsLoader::ClearCache();
```

{{% alert color="info" title="Note" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontsloader/loadexternalfonts/) přidává další složky do cest pro vyhledávání písem, ale nemění pořadí inicializace písem.
Písma jsou inicializována v tomto pořadí:

1. Výchozí cesta k písmům operačního systému.
1. Cesty načtené pomocí [FontsLoader](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontsloader/).

{{%/alert %}}

## **Získat vlastní složky s písmy**
Aspose.Slides poskytuje [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontsloader/getfontfolders/), který vám umožní najít složky s písmy. Tato metoda vrací složky přidané pomocí metody `LoadExternalFonts` a systémové složky s písmy.

Tento C++ kód vám ukazuje, jak použít metodu [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontsloader/getfontfolders/) :

``` cpp
// Tento řádek vypisuje složky, které jsou kontrolovány pro soubory písem.
// Jedná se o složky přidané metodou LoadExternalFonts a systémové složky s písmy.
auto fontFolders = FontsLoader::GetFontFolders();
```

## **Zadat vlastní písma používaná v prezentaci**
Aspose.Slides poskytuje vlastnost [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/cs/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/), která vám umožní určit externí písma, která budou použita s prezentací.

Tento C++ kód vám ukazuje, jak použít vlastnost [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/cs/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) :

``` cpp
auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    //pracujte s prezentací
    //CustomFont1, CustomFont2 i fonty ze složek assets\fonts & global\fonts a jejich podsložek jsou k dispozici pro prezentaci
}
```

## **Spravovat písma externě**
Aspose.Slides poskytuje metodu [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontsloader/loadexternalfont/), která vám umožní načíst externí písma do pole bajtů.

Tento C++ kód demonstruje proces načítání písem do pole bajtů:

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

## **Často kladené otázky**

**Ovlivňují vlastní písma export do všech formátů (PDF, PNG, SVG, HTML)?**

Ano. Připojená písma jsou rendererem používána ve všech exportních formátech.

**Jsou vlastní písma automaticky vkládána do výsledného PPTX?**

Ne. Registrace písma pro vykreslování není totéž jako jeho vložení do PPTX. Pokud potřebujete, aby bylo písmo zahrnuto přímo v souboru prezentace, musíte použít explicitní [embedding features](/slides/cs/cpp/embedded-font/).

**Mohu řídit chování fallbacku, když vlastní písmo postrádá některé glify?**

Ano. Nakonfigurujte [font substitution](/slides/cs/cpp/font-substitution/), [replacement rules](/slides/cs/cpp/font-replacement/) a [fallback sets](/slides/cs/cpp/fallback-font/), abyste přesně určili, které písmo se použije, když požadovaný glif chybí.

**Mohu používat písma v Linux/Docker kontejnerech, aniž bych je instaloval na úrovni systému?**

Ano. Odkazujte na své vlastní složky s písmy nebo načítejte písma z pole bajtů. Tím odstraníte jakoukoli závislost na systémových složkách s písmy v obrazu kontejneru.

**Co se týče licencí – mohu vložit jakékoli vlastní písmo bez omezení?**

Vy jste zodpovědní za dodržování licencí písem. Podmínky se liší; některé licence zakazují vkládání nebo komerční použití. Vždy si před distribucí výstupů přečtěte EULA daného písma.