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
- složka s písmy
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Přizpůsobte písma v PowerPoint snímcích pomocí Aspose.Slides pro Javu, aby vaše prezentace byly ostré a konzistentní na jakémkoli zařízení."
---
## **Přehled**

Aspose.Slides vám umožňuje používat vlastní písma v prezentacích, aniž byste je instalovali do operačního systému. Můžete načíst písma z vlastních složek, poskytnout písma pro konkrétní prezentaci prostřednictvím zdrojů písem na úrovni dokumentu nebo načíst externí písma přímo z binárních dat.

Načtená písma se používají při vykreslování nebo exportu prezentace, například do PDF, obrázků a dalších podporovaných formátů. To pomáhá udržet výstup prezentace konzistentní napříč různými prostředími. Článek také vysvětluje, jak zkontrolovat složky písem používané Aspose.Slides a jak po práci s externími písmy vyprázdnit mezipaměť písem.

Registrace vlastních písem pro vykreslování je oddělena od vložení písem do souboru PPTX. Pokud musí být písmo uloženo přímo v prezentaci, použijte funkce pro vkládání písem explicitně.

{{% alert color="info" %}} 

Aspose Slides vám umožňuje tato písma načíst pomocí metody [loadExternalFonts](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* TrueType (.ttf) a TrueType Collection (.ttc) písma. Viz [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) písma. Viz [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Načtení vlastních písem**

Aspose.Slides vám umožňuje načíst písma použité v prezentaci, aniž byste je instalovali do systému. To ovlivňuje výstup exportu – například PDF, obrázky a další podporované formáty – takže výsledné dokumenty vypadají konzistentně napříč prostředími. Písma jsou načítána z vlastních adresářů.

1. Zadejte jeden nebo více složek, které obsahují soubory písem.
2. Zavolejte statickou metodu [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) pro načtení písem z těchto složek.
3. Načtěte a vykreslete/exportujte prezentaci.
4. Zavolejte [FontsLoader.clearCache](https://reference.aspose.com/slides/cs/java/com.aspose.slides/FontsLoader#clearCache--) pro vyprázdnění mezipaměti písem.

Následující ukázkový kód demonstruje proces načítání písem:

```java
import com.aspose.slides.*;

// Definujte složky, které obsahují soubory vlastních písem.
String[] fontFolders = new String[] { "assets/fonts", "global/fonts" };

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

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) přidává další složky do cest pro vyhledávání písem, ale nemění pořadí inicializace písem.
Písma jsou inicializována v tomto pořadí:

1. Výchozí cesta písem operačního systému.
1. Cesty načtené pomocí [FontsLoader](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fontsloader/).

{{%/alert %}}

## **Získání vlastních složek s písmy**
Aspose.Slides poskytuje metodu [getFontFolders](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fontsloader/#getFontFolders--) pro vyhledání složek s písmy. Tato metoda vrací složky přidané prostřednictvím metody `LoadExternalFonts` a systémové složky písem.

Tento Java kód ukazuje, jak použít [getFontFolders](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fontsloader/#getFontFolders--):

```java
import com.aspose.slides.*;

// Tento řádek vypisuje složky, kde se vyhledávají soubory písem.
// Jedná se o složky přidané metodou LoadExternalFonts a systémové složky písem.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Určení vlastních písem používaných v prezentaci**
Aspose.Slides poskytuje vlastnost [setDocumentLevelFontSources](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) pro určení externích písem, která budou použita v prezentaci. 

Tento Java kód ukazuje, jak použít [setDocumentLevelFontSources](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

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
    // Práce s prezentací
    // CustomFont1, CustomFont2 a písma ze složek assets\fonts a global\fonts a jejich podsložek jsou dostupná v prezentaci
} finally {
    if (pres != null) pres.dispose();
}
```

## **Správa písem externě**

Aspose.Slides poskytuje metodu [loadExternalFont](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) pro načtení externích písem z binárních dat.

Tento Java kód demonstruje proces načítání písma z pole bajtů:

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

Ano. Připojená písma používá vykreslovač napříč všemi exportními formáty.

### Jsou vlastní písma automaticky vložena do výsledného PPTX?

Ne. Registrace písma pro vykreslování není totéž jako jeho vložení do PPTX. Pokud potřebujete, aby bylo písmo součástí souboru prezentace, musíte použít explicitní funkce pro [vkládání písem](/slides/cs/java/embedded-font/).

### Mohu řídit chování při nedostatku některých znaků ve vlastním písmu?

Ano. Nakonfigurujte [náhradu písem](/slides/cs/java/font-substitution/), [pravidla nahrazování](/slides/cs/java/font-replacement/) a [sady náhradních písem](/slides/cs/java/fallback-font/), abyste přesně určili, které písmo se použije, když požadovaný znak chybí.

### Mohu používat písma v Linux/Docker kontejnerech bez instalace do systému?

Ano. Odkazujte na vlastní složky s písmy nebo načtěte písma z polí bajtů. Tím odstraníte jakoukoli závislost na systémových složkách s písmy v obrazu kontejneru.

### Co licence—mohu vložit jakékoli vlastní písmo bez omezení?

Jste odpovědní za dodržování licencí písem. Podmínky se liší; některé licence zakazují vkládání nebo komerční použití. Vždy si před distribucí výstupů přečtěte licenční smlouvu písma.