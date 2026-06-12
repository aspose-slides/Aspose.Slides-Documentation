---
title: Přizpůsobení písem PowerPointu na Androidu
linktitle: Vlastní písmo
type: docs
weight: 20
url: /cs/androidjava/custom-font/
keywords:
- písmo
- vlastní písmo
- externí písmo
- načíst písmo
- správa písem
- složka s písmy
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Přizpůsobte písma ve snímcích PowerPoint pomocí Aspose.Slides pro Android v Javě, aby vaše prezentace byly ostré a konzistentní na jakémkoli zařízení."
---
## **Přehled**

Aspose.Slides vám umožňuje používat vlastní písma v prezentacích, aniž byste je instalovali do operačního systému. Písma můžete načíst z vlastních složek, poskytnout písma pro konkrétní prezentaci prostřednictvím zdrojů písem na úrovni dokumentu, nebo načíst externí písma přímo z binárních dat.

Načtená písma se používají při vykreslování nebo exportu prezentace, například do PDF, obrázků a dalších podporovaných formátů. To pomáhá udržet výstup prezentace konzistentní napříč různými prostředími. Článek také vysvětluje, jak prohlížet složky písem používané Aspose.Slides a jak po práci s externími písmy vyprázdnit mezipaměť písem.

Registrace vlastních písem pro vykreslování je oddělena od vkládání písem do souboru PPTX. Pokud musí být písmo uloženo přímo v prezentaci, použijte výslovně funkce vkládání písem.

{{% alert color="primary" %}} 
Aspose Slides vám umožňuje tato písma načíst pomocí metody [loadExternalFonts](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* TrueType (.ttf) a TrueType Collection (.ttc) písma. Viz [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) písma. Viz [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Načíst vlastní písma**

Aspose.Slides vám umožňuje načíst písma používaná v prezentaci, aniž byste je instalovali do systému. To ovlivňuje výstup exportu – například PDF, obrázky a další podporované formáty – takže výsledné dokumenty vypadají konzistentně napříč prostředími. Písma jsou načítána z vlastních adresářů.

1. Zadejte jeden nebo více složek obsahujících soubory písem.
2. Zavolejte statickou metodu [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) pro načtení písem z těchto složek.
3. Načtěte a vykreslete/exportujte prezentaci.
4. Zavolejte [FontsLoader.clearCache](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/FontsLoader#clearCache--) pro vyprázdnění mezipaměti písem.

Následující ukázka kódu demonstruje proces načítání písem:

```java
// Definujte složky, které obsahují soubory vlastních písem.
String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// Načtěte vlastní písma ze zadaných složek.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");
    
    // Vykreslete/exportujte prezentaci (např. do PDF, obrázků nebo jiných formátů) pomocí načtených písem.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Vymažte mezipaměť písem po dokončení práce.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Poznámka" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) přidává další složky do cest pro vyhledávání písem, ale nemění pořadí inicializace písem.
Písma jsou inicializována v tomto pořadí:

1. Výchozí cesta písem operačního systému.
1. Cesty načtené pomocí [FontsLoader](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fontsloader/).

{{%/alert %}}

## **Získat vlastní složky s písmy**

Aspose.Slides poskytuje metodu [getFontFolders](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) umožňující najít složky s písmy. Tato metoda vrací složky přidané pomocí metody `LoadExternalFonts` a systémové složky s písmy.

Tento Java kód vám ukazuje, jak použít [getFontFolders](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fontsloader/#getFontFolders--):

```java
// Tento řádek vypisuje složky, kde jsou hledány soubory písem.
// Jedná se o složky přidané metodou LoadExternalFonts a systémové složky s písmy.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Určit vlastní písma používaná v prezentaci**

Aspose.Slides poskytuje vlastnost [setDocumentLevelFontSources](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) umožňující určit externí písma, která budou použita s prezentací.

Tento Java kód vám ukazuje, jak použít vlastnost [setDocumentLevelFontSources](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

```java
byte[] memoryFont1 = Files.readAllBytes("customfonts/CustomFont1.ttf");
byte[] memoryFont2 = Files.readAllBytes("customfonts/CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // Pracujte s prezentací
    // CustomFont1, CustomFont2 a písma ze složek assets\fonts & global\fonts a jejich podadresářů jsou k dispozici pro prezentaci
} finally {
    if (pres != null) pres.dispose();
}
```

## **Spravovat písma externě**

Aspose.Slides poskytuje metodu [loadExternalFont](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) umožňující načíst externí písma z binárních dat.

Tento Java kód demonstruje proces načítání písem z pole bajtů:

```java
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // externí písmo načtené během životnosti prezentace
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **Často kladené otázky**

**Ovlivňují vlastní písma export do všech formátů (PDF, PNG, SVG, HTML)?**

Ano. Připojená písma jsou renderérem použita ve všech exportních formátech.

**Jsou vlastní písma automaticky vložena do výsledného PPTX?**

Ne. Registrace písma pro vykreslování není totéž jako jeho vložení do PPTX. Pokud potřebujete, aby písmo bylo součástí souboru prezentace, musíte použít výslovně [funkce vkládání](/slides/cs/androidjava/embedded-font/).

**Mohu řídit chování fallbacku, když vlastní písmo postrádá určité glyfy?**

Ano. Nakonfigurujte [nahrazení písma](/slides/cs/androidjava/font-substitution/), [pravidla nahrazování](/slides/cs/androidjava/font-replacement/), a [sady fallback](/slides/cs/androidjava/fallback-font/), aby bylo přesně určeno, které písmo se použije, když požadovaný glyf chybí.

**Mohu použít písma v kontejnerech Linux/Docker bez jejich systémové instalace?**

Ano. Odkazujte na vlastní složky s písmy nebo načtěte písma z polí bajtů. Tím se odstraní jakákoliv závislost na systémových složkách s písmy v obrazu kontejneru.

**Jak to je s licencí – mohu vložit jakékoli vlastní písmo bez omezení?**

Jste odpovědní za dodržování licenčních podmínek písem. Podmínky se liíší; některé licence zakazují vkládání nebo komerční použití. Vždy si před distribucí výstupů prostudujte EULA daného písma.