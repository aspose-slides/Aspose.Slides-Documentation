---
title: Přizpůsobení písem PowerPointu v JavaScriptu
linktitle: Vlastní písmo
type: docs
weight: 20
url: /cs/nodejs-java/custom-font/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Přizpůsobte písma v PowerPoint slidech pomocí JavaScriptu a Aspose.Slides pro Node.js přes Java, aby vaše prezentace byly ostré a konzistentní na jakémkoli zařízení."
---
## **Přehled**

Aspose.Slides vám umožňuje používat vlastní písma v prezentacích, aniž byste je museli instalovat v operačním systému. Písma můžete načíst ze vlastních složek, poskytnout písma pro konkrétní prezentaci prostřednictvím zdrojů písem na úrovni dokumentu nebo načíst externí písma přímo z binárních dat.

Načtená písma jsou používána při vykreslování nebo exportu prezentace, například do PDF, obrázků a dalších podporovaných formátů. To pomáhá udržet výstup prezentace konzistentní napříč různými prostředími. Článek také vysvětluje, jak prozkoumat složky písem používané knihovnou Aspose.Slides a jak po práci s externími písmy vyčistit mezipaměť písem.

Registrace vlastních písem pro vykreslování je oddělena od vkládání písem do souboru PPTX. Pokud je písmo potřeba uložit přímo v samotné prezentaci, použijte explicitně funkce pro vkládání písem.

{{% alert color="primary" %}} 

Aspose Slides vám umožňuje načíst tato písma pomocí metody [loadExternalFonts](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* TrueType (.ttf) a TrueType Collection (.ttc) písma. Viz [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) písma. Viz [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Načíst vlastní písma**

Aspose.Slides vám umožňuje načíst písma používaná v prezentaci, aniž byste je instalovali v systému. To ovlivňuje výstup exportu – například PDF, obrázky a další podporované formáty – takže výsledné dokumenty vypadají konzistentně napříč prostředími. Písma jsou načítána z vlastních adresářů.

1. Zadejte jednu nebo více složek, které obsahují soubory písem.
2. Zavolejte statickou metodu [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/), která načte písma z těchto složek.
3. Načtěte a vykreslete/exportujte prezentaci.
4. Zavolejte [FontsLoader.clearCache](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontsloader/clearcache/), abyste vyprázdnili mezipaměť písem.

Následující ukázkový kód demonstruje proces načítání písem:

```js
// Definujte složky, které obsahují vlastní soubory písem.
let fontFolders = java.newArray("java.lang.String", [externalFontFolder1, externalFontFolder2]);

// Načtěte vlastní písma ze zadaných složek.
aspose.slides.FontsLoader.loadExternalFonts(fontFolders);

let presentation = null;
try {
    presentation = new aspose.slides.Presentation("sample.pptx");
    
    // Vykreslete/exportujte prezentaci (např. do PDF, obrázků nebo jiných formátů) pomocí načtených písem.
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Vymažte mezipaměť písem po dokončení práce.
    aspose.slides.FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) přidává další složky do cest pro vyhledávání písem, ale nemění pořadí inicializace písem.
Písma jsou inicializována v tomto pořadí:

1. Výchozí cesta k písmům operačního systému.
1. Cesty načtené pomocí [FontsLoader](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontsloader/).

{{%/alert %}}

## **Získat složku s vlastními písmy**
Aspose.Slides poskytuje metodu [getFontFolders](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontsloader/#getFontFolders--) pro vyhledání složek s písmy. Tato metoda vrací složky přidané pomocí metody `LoadExternalFonts` a systémové složky písem.

Tento JavaScriptový kód ukazuje, jak použít [getFontFolders](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontsloader/#getFontFolders--):

```javascript
// Tento řádek vypisuje složky, ve kterých se hledají soubory písem.
// Jedná se o složky přidané metodou LoadExternalFonts a systémové složky s písmy.
var fontFolders = aspose.slides.FontsLoader.getFontFolders();
```

## **Zadat vlastní písma použitá v prezentaci**
Aspose.Slides poskytuje vlastnost [setDocumentLevelFontSources](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-) pro určení externích písem, která budou použita v prezentaci.

Tento JavaScriptový kód ukazuje, jak použít vlastnost [setDocumentLevelFontSources](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-):

```javascript
var memoryFont1 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont1.ttf"));
var memoryFont2 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont2.ttf"));
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(java.newArray("java.lang.String", ["assets/fonts", "global/fonts"]));
loadOptions.getDocumentLevelFontSources().setMemoryFonts(java.newArray("[B", [java.newArray("byte", ["item1", "item2", "item3"])]));
var pres = new aspose.slides.Presentation("MyPresentation.pptx", loadOptions);
try {
    // Práce s prezentací
    // CustomFont1, CustomFont2 a písma ze složek assets\fonts a global\fonts a jejich podadresářů jsou k dispozici pro prezentaci
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Spravovat písma externě**

Aspose.Slides poskytuje metodu [loadExternalFont](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) pro načtení externích písem z binárních dat.

Tento JavaScriptový kód demonstruje proces načítání písem z pole bajtů:

```javascript
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALN.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNBI.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNI.TTF")));
try {
    var pres = new aspose.slides.Presentation("");
    try {
        // externí písmo načtené během životnosti prezentace
    } finally {
    }
} finally {
    java.callStaticMethodSync("com.aspose.slides.FontsLoader", "clearCache");
}
```

## **Často kladené otázky**

**Ovlivňují vlastní písma export do všech formátů (PDF, PNG, SVG, HTML)?**

Ano. Připojená písma jsou používána vykreslovacím systémem ve všech exportních formátech.

**Jsou vlastní písma automaticky vložena do výsledného souboru PPTX?**

Ne. Registrace písma pro vykreslování není totéž jako jeho vložení do souboru PPTX. Pokud potřebujete, aby písmo bylo součástí prezentace, musíte použít explicitní [funkce pro vkládání písem](/slides/cs/nodejs-java/embedded-font/).

**Mohu ovládat chování náhradního písma, když vlastní písmo postrádá některé glyfy?**

Ano. Nakonfigurujte [náhradu písem](/slides/cs/nodejs-java/font-substitution/), [pravidla nahrazování](/slides/cs/nodejs-java/font-replacement/) a [sady náhrad](/slides/cs/nodejs-java/fallback-font/), abyste přesně určili, které písmo se použije, když požadovaný glyf chybí.

**Mohu používat písma v Linux/Docker kontejnerech bez jejich instalace do systému?**

Ano. Odkazujte na své vlastní složky s písmy nebo načtěte písma z polí bajtů. Tím odstraníte jakoukoli závislost na systémových složkách písem v obrazci kontejneru.

**Co licence – mohu vložit jakékoli vlastní písmo bez omezení?**

Jste odpovědní za dodržování licencí písem. Podmínky se liší; některé licence zakazují vložení nebo komerční použití. Vždy si před distribucí výstupů přečtěte EULA daného písma.