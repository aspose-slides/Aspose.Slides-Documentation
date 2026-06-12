---
title: Přizpůsobení písem PowerPointu v Javě
linktitle: Vlastní písmo
type: docs
weight: 20
url: /cs/java/custom-font/
keywords:
- písmo
- vlastní písmo
- externí písmo
- načíst písmo
- spravovat písma
- složka s písy
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Přizpůsobte písma v PowerPoint snímcích pomocí Aspose.Slides pro Javu, aby vaše prezentace byly ostré a konzistentní na jakémkoli zařízení."
---
## **Přehled**

Aspose.Slides umožňuje používat vlastní písma v prezentacích bez nutnosti instalace do operačního systému. Můžete načíst písma z vlastních složek, poskytnout písma pro konkrétní prezentaci pomocí fontových zdrojů na úrovni dokumentu, nebo načíst externí písma přímo z binárních dat.

Načtená písma se používají při vykreslování nebo exportu prezentace, například do PDF, obrázků a dalších podporovaných formátů. To pomáhá zachovat jednotný výstup prezentace napříč různými prostředími. Článek také vysvětluje, jak zkontrolovat složky písem používané Aspose.Slides a jak po práci s externími písmy vymazat mezipaměť písem.

Registrace vlastních písem pro vykreslování je oddělena od vkládání písem do souboru PPTX. Pokud je třeba, aby písmo bylo uloženo uvnitř samotné prezentace, použijte výslovně funkce vkládání písem.

{{% alert color="primary" %}} 

Aspose Slides umožňuje načíst tato písma pomocí metody [loadExternalFonts](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* Písma TrueType (.ttf) a TrueType Collection (.ttc). Viz [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Písma OpenType (.otf). Viz [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Načíst vlastní písma**

Aspose.Slides umožňuje načíst písma použité v prezentaci bez instalace do systému. To ovlivňuje výstup exportu – například PDF, obrázky a další podporované formáty – takže výsledné dokumenty vypadají jednotně napříč prostředími. Písma jsou načítána z vlastních adresářů.

1. Zadejte jednu nebo více složek, které obsahují soubory písem.
2. Zavolejte statickou metodu [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) k načtení písem z těchto složek.
3. Načtěte a vykreslete/exportujte prezentaci.
4. Zavolejte [FontsLoader.clearCache](https://reference.aspose.com/slides/cs/java/com.aspose.slides/FontsLoader#clearCache--) pro vymazání mezipaměti písem.

Následující ukázka kódu demonstruje proces načítání písem:

```java
// Definujte složky, které obsahují vlastní soubory písem.
String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// Načtěte vlastní písma ze specifikovaných složek.
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

{{% alert color="info" title="Note" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) přidává další složky do cest pro vyhledávání písem, ale nemění pořadí inicializace písem. Písma jsou inicializována v tomto pořadí:

1. Výchozí cesta k písmům operačního systému.
2. Cesty načtené pomocí [FontsLoader](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fontsloader/).

{{%/alert %}}

## **Získat vlastní složky s písmy**
Aspose.Slides poskytuje metodu [getFontFolders](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fontsloader/#getFontFolders--) umožňující najít složky s písmy. Tato metoda vrací složky přidané pomocí metody `LoadExternalFonts` a systémové složky s písmy.

Tento Java kód ukazuje, jak použít [getFontFolders](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fontsloader/#getFontFolders--):

```java
// Tento řádek vypisuje složky, kde se hledají soubory písem.
// Jedná se o složky přidané pomocí metody LoadExternalFonts a systémové složky s písy.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Zadat vlastní písma používaná v prezentaci**
Aspose.Slides poskytuje vlastnost [setDocumentLevelFontSources](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) , která umožňuje určit externí písma, která budou použita v prezentaci. 

Tento Java kód ukazuje, jak použít vlastnost [setDocumentLevelFontSources](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

```java
byte[] memoryFont1 = Files.readAllBytes("customfonts/CustomFont1.ttf");
byte[] memoryFont2 = Files.readAllBytes("customfonts/CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // Pracujte s prezentací
    // CustomFont1, CustomFont2 a písma ze složek assets\fonts a global\fonts a jejich podřízených složek jsou pro prezentaci k dispozici
} finally {
    if (pres != null) pres.dispose();
}
```

## **Spravovat písma externě**

Aspose.Slides poskytuje metodu [loadExternalFont](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data), která umožňuje načíst externí písma z binárních dat.

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

Ano. Připojená písma jsou vykreslovací komponentou používána ve všech exportních formátech.

**Jsou vlastní písma automaticky vložena do výsledného PPTX?**

Ne. Registrace písma pro vykreslování není totéž jako jeho vložení do PPTX. Pokud potřebujete, aby písmo bylo v souboru prezentace, musíte použít výslovně [embedding features](/slides/cs/java/embedded-font/).

**Mohu řídit chování při nedostatku určitých glyfů ve vlastním písmu?**

Ano. Nastavte [font substitution](/slides/cs/java/font-substitution/), [replacement rules](/slides/cs/java/font-replacement/) a [fallback sets](/slides/cs/java/fallback-font/) pro přesné určení, které písmo se použije, když požadovaný glyf chybí.

**Mohu používat písma v kontejnerech Linux/Docker, aniž bych je instaloval systémově?**

Ano. Odkazujte na vlastní složky s písmy nebo načtěte písma z pole bajtů. Tím odstraníte jakoukoli závislost na systémových složkách s písmy v obrazu kontejneru.

**Co se týče licencí – mohu vložit libovolné vlastní písmo bez omezení?**

Vy jste odpovědní za dodržování licenčních podmínek písem. Podmínky se liší; některé licence zakazují vkládání nebo komerční použití. Vždy si před distribucí výstupů prostudujte EULA daného písma.