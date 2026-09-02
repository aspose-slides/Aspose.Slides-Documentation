---
title: Přizpůsobení fontů v PowerPointu v Javě
linktitle: Vlastní font
type: docs
weight: 20
url: /cs/java/custom-font/
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
- Java
- Aspose.Slides
description: "Přizpůsobte písma v prezentacích PowerPoint pomocí Aspose.Slides pro Javu, aby vaše prezentace byly ostré a konzistentní na jakémkoli zařízení."
---
## **Přehled**

Aspose.Slides vám umožňuje používat vlastní písma v prezentacích, aniž byste je instalovali do operačního systému. Můžete načíst písma z vlastních složek, poskytnout písma pro konkrétní prezentaci prostřednictvím zdrojů písem na úrovni dokumentu nebo načíst externí písma přímo z binárních dat.

Nahraná písma jsou používána při vykreslování nebo exportu prezentace, například do PDF, obrázků a dalších podporovaných formátů. To pomáhá udržet výstup prezentace konzistentní napříč různými prostředími. Článek také vysvětluje, jak prozkoumat složky písem používané Aspose.Slides a jak vymazat mezipaměť písem po práci s externími písmy.

Registrace vlastních písem pro vykreslování je oddělena od vkládání písem do souboru PPTX. Pokud musí být písmo uloženo přímo v prezentaci, použijte funkce vkládání písem výslovně.

Téma prezentace může odkazovat na různé rodiny písem pro jednotlivé psací systémy. Toto mapování ukládá názvy písem, ale neinstaluje ani nenačítá soubory písem. Viz [Script-Specific Theme Fonts](/slides/cs/java/script-specific-font-mappings/) pro správu mapování a použijte níže uvedené možnosti načítání, aby byly odkazované fonty k dispozici pro konzistentní vykreslování.

{{% alert color="info" title="Note" %}}
Aspose Slides vám umožňuje načíst tato písma pomocí metody [loadExternalFonts](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* TrueType (.ttf) a TrueType Collection (.ttc) písma. Viz [TrueType](https://en.wikipedia.org/wiki/TrueType).
* OpenType (.otf) písma. Viz [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **Načíst vlastní písma**

Aspose.Slides vám umožňuje načíst písma používaná v prezentaci, aniž byste je instalovali do systému. To ovlivňuje výstup exportu – například PDF, obrázky a další podporované formáty – takže výsledné dokumenty vypadají konzistentně napříč prostředími. Písma jsou načítána z vlastních adresářů.

1. Zadejte jednu nebo více složek, které obsahují soubory písem.
2. Zavolejte statickou metodu [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) pro načtení písem z těchto složek.
3. Načtěte a vykreslete/exportujte prezentaci.
4. Zavolejte [FontsLoader.clearCache](https://reference.aspose.com/slides/cs/java/com.aspose.slides/FontsLoader#clearCache--) pro vymazání mezipaměti písem.

Následující příklad kódu demonstruje proces načítání písem:

```java
import com.aspose.slides.*;

// Definujte složky, které obsahují vlastní soubory písem.
String[] fontFolders = new String[] { "assets/fonts", "global/fonts" };

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
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) přidává další složky do cest pro vyhledávání písem, ale nemění pořadí inicializace písem.
Písma jsou inicializována v tomto pořadí:

1. Výchozí cesta písem operačního systému.
1. Cesty načtené prostřednictvím [FontsLoader](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fontsloader/).
{{%/alert %}}

## **Získat vlastní složky písem**

Aspose.Slides poskytuje metodu [getFontFolders](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fontsloader/#getFontFolders--) umožňující najít složky písem. Tato metoda vrací složky přidané pomocí metody `LoadExternalFonts` a systémové složky písem.

Tento Java kód ukazuje, jak použít [getFontFolders](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fontsloader/#getFontFolders--):

```java
import com.aspose.slides.*;

// Tento řádek vypisuje složky, ve kterých jsou hledány soubory písem.
// Jedná se o složky přidané metodou LoadExternalFonts a systémové složky s písmy.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Specifikovat vlastní písma použité v prezentaci**

Aspose.Slides poskytuje vlastnost [setDocumentLevelFontSources](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) umožňující určit externí písma, která budou použita s prezentací.

Tento Java kód ukazuje, jak použít vlastnost [setDocumentLevelFontSources](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

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
    // CustomFont1, CustomFont2 a písma ze složek assets\fonts a global\fonts a jejich podsložek jsou k dispozici prezentaci
} finally {
    if (pres != null) pres.dispose();
}
```

## **Spravovat písma externě**

Aspose.Slides poskytuje metodu [loadExternalFont](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) umožňující načíst externí písma z binárních dat.

Tento Java kód demonstruje proces načítání písem z pole bajtů:

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

Ano. Připojená písma jsou renderérem používána ve všech exportních formátech.

### Jsou vlastní písma automaticky vkládána do výsledného PPTX?

Ne. Registrace písma pro vykreslování není totéž jako jeho vložení do PPTX. Pokud potřebujete, aby bylo písmo součástí souboru prezentace, musíte použít výslovně [funkce vkládání](/slides/cs/java/embedded-font/).

### Můžu řídit chování při nedostatku některých znaků ve vlastním písmu?

Ano. Nakonfigurujte [náhradu písma](/slides/cs/java/font-substitution/), [pravidla nahrazování](/slides/cs/java/font-replacement/) a [sady záložních písem](/slides/cs/java/fallback-font/), abyste přesně určili, které písmo se použije, když požadovaný znak chybí.

### Můžu používat písma v Linux/Docker kontejnerech bez jejich systémové instalace?

Ano. Ukazujte na vlastní složky s písmy nebo načítejte písma z polí bajtů. To odstraňuje jakoukoli závislost na systémových složkách písem v obrazci kontejneru.

### Co licencování—mohu vložit libovolné vlastní písmo bez omezení?

Jste odpovědní za dodržování licenčních podmínek písem. Podmínky se liří; některé licence zakazují vkládání nebo komerční využití. Vždy si před distribucí výstupů přečtěte licenční smlouvu (EULA) daného písma.