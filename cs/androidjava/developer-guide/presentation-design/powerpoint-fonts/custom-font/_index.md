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
- spravovat písma
- složka s písmy
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Přizpůsobte písma ve snímcích PowerPointu pomocí Aspose.Slides pro Android v Javě, aby vaše prezentace byly ostlé a konzistentní na jakémkoli zařízení."
---
## **Přehled**

Aspose.Slides vám umožňuje používat vlastní písma v prezentacích, aniž byste je instalovali do operačního systému. Písma můžete načíst z vlastních složek, poskytnout písma pro konkrétní prezentaci prostřednictvím zdrojů písem na úrovni dokumentu, nebo načíst externí písma přímo z binárních dat.

Načtená písma se používají při vykreslování nebo exportu prezentace, například do PDF, obrázků a dalších podporovaných formátů. To pomáhá udržet výstup prezentace konzistentní napříč různými prostředími. Článek také vysvětluje, jak prohlédnout složky s písmy používané Aspose.Slides a jak vymazat mezipaměť písem po práci s externími písmy.

Registrace vlastních písem pro vykreslování je oddělena od vkládání písem do souboru PPTX. Pokud musí být písmo uloženo přímo v prezentaci, použijte funkce pro vkládání písem explicitně.

{{% alert color="info" %}} 
Aspose Slides vám umožňuje načíst tato písma pomocí metody [loadExternalFonts](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* Písma TrueType (.ttf) a TrueType Collection (.ttc). Viz [TrueType](https://en.wikipedia.org/wiki/TrueType).
* Písma OpenType (.otf). Viz [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **Načíst vlastní písma**

Aspose.Slides vám umožňuje načíst písma používaná v prezentaci, aniž byste je instalovali v systému. To ovlivňuje výstup exportu – například PDF, obrázky a další podporované formáty – takže výsledné dokumenty vypadají konzistentně napříč prostředími. Písma jsou načítána z vlastních adresářů.

1. Zadejte jednu nebo více složek, které obsahují soubory písem.
2. Zavolejte statickou metodu [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) pro načtení písem z těchto složek.
3. Načtěte a vykreslete/exportujte prezentaci.
4. Zavolejte [FontsLoader.clearCache](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/FontsLoader#clearCache--) pro vymazání mezipaměti písem.

Následující příklad kódu ukazuje proces načítání písem:

```java
import com.aspose.slides.*;

// Definujte složky, které obsahují vlastní soubory písem.
String externalFontFolder1 = "assets/fonts";
String externalFontFolder2 = "global/fonts";

String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// Load custom fonts from the specified folders.
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
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) přidává další složky do cest pro vyhledávání písem, ale nemění pořadí inicializace písem.
Písma jsou inicializována v tomto pořadí:

1. Výchozí cesta operačního systému k písmům.
1. Cesty načtené pomocí [FontsLoader](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fontsloader/).
{{%/alert %}}

## **Získat vlastní složky s písmy**
Aspose.Slides poskytuje metodu [getFontFolders](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) , která vám umožní najít složky s písmy. Tato metoda vrací složky přidané pomocí metody `LoadExternalFonts` a systémové složky s písmy.

Tento Java kód ukazuje, jak použít [getFontFolders](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fontsloader/#getFontFolders--):

```java
import com.aspose.slides.*;

// Tento řádek vypisuje složky, kde se hledají soubory písem.
// Jedná se o složky přidané metodou LoadExternalFonts a systémové složky s písmy.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Zadat vlastní písma používaná v prezentaci**
Aspose.Slides poskytuje vlastnost [setDocumentLevelFontSources](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-), která vám umožní zadat externí písma, která budou použita v prezentaci.

Tento Java kód ukazuje, jak použít vlastnost [setDocumentLevelFontSources](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

byte[] memoryFont1 = Files.readAllBytes(Paths.get("customfonts/CustomFont1.ttf"));
byte[] memoryFont2 = Files.readAllBytes(Paths.get("customfonts/CustomFont2.ttf"));

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // Pracujte s prezentací
    // CustomFont1, CustomFont2 a písma ze složek assets\fonts & global\fonts a jejich podsložek jsou k dispozici prezentaci
} finally {
    if (pres != null) pres.dispose();
}
```

## **Spravovat písma externě**

Aspose.Slides poskytuje metodu [loadExternalFont](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data), která vám umožní načíst externí písma z binárních dat.

Tento Java kód demonstruje proces načítání písma z pole bytů:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

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

### Ovlivňují vlastní písma export do všech formátů (PDF, PNG, SVG, HTML)?

Ano. Připojená písma používá renderér ve všech exportních formátech.

### Jsou vlastní písma automaticky vkládána do výsledného PPTX?

Ne. Registrace písma pro vykreslování není totéž jako jeho vložení do PPTX. Pokud potřebujete, aby písmo bylo součástí souboru prezentace, musíte použít explicitní [embedding features](/slides/cs/androidjava/embedded-font/).

### Mohu řídit chování náhradního písma, když vlastní písmo postrádá některé glyfy?

Ano. Nakonfigurujte [font substitution](/slides/cs/androidjava/font-substitution/), [replacement rules](/slides/cs/androidjava/font-replacement/) a [fallback sets](/slides/cs/androidjava/fallback-font/), abyste přesně určili, které písmo se použije, pokud požadovaný glyf chybí.

### Mohu použít písma v Linux/Docker kontejnerech bez instalace pro celý systém?

Ano. Odkazujte na vlastní složky s písmy nebo načtěte písma z polí bytů. Tím se odstraní jakákoli závislost na systémových složkách s písmy v obrazu kontejneru.

### Co licencování—mohu vložit jakékoli vlastní písmo bez omezení?

Vy jste zodpovědní za dodržování licencí písem. Podmínky se liší; některé licence zakazují vkládání nebo komerční použití. Vždy si před distribucí výstupů prostudujte EULA daného písma.