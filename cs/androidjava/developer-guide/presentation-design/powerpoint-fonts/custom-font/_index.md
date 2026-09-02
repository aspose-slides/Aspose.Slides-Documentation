---
title: Přizpůsobení fontů PowerPoint na Androidu
linktitle: Vlastní font
type: docs
weight: 20
url: /cs/androidjava/custom-font/
keywords:
- font
- vlastní font
- externí font
- načíst font
- správa fontů
- složka fontů
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Přizpůsobte fonty v PowerPoint snímcích pomocí Aspose.Slides pro Android v Javě, aby vaše prezentace byly ostré a konzistentní na jakémkoli zařízení."
---
## **Přehled**

Aspose.Slides umožňuje používat vlastní fonty v prezentacích, aniž byste je instalovali do operačního systému. Fonty můžete načíst z vlastních složek, poskytnout fonty pro konkrétní prezentaci prostřednictvím zdrojů fontů na úrovni dokumentu nebo načíst externí fonty přímo z binárních dat.

Načtené fonty se použijí při vykreslování nebo exportu prezentace, například do PDF, obrázků a dalších podporovaných formátů. To pomáhá udržet výstup prezentace konzistentní napříč různými prostředími. Článek také popisuje, jak prozkoumat složky s fonty používané Aspose.Slides a jak po práci s externími fonty vymazat cache fontů.

Registrace vlastních fontů pro vykreslování je oddělena od vložení fontů do souboru PPTX. Pokud má být font uložen uvnitř samotné prezentace, použijte funkce vložení fontů explicitně.

Motiv prezentace může odkazovat na různé rodiny fontů pro jednotlivé písmo‑systémy. Tyto mapování ukládají názvy fontů, ale neinstalují ani nenačítají soubory fontů. Viz [Písmo specifické pro skript](/slides/cs/androidjava/script-specific-font-mappings/), kde můžete mapování spravovat, a použijte níže uvedené možnosti načítání, aby byly odkazované fonty k dispozici pro konzistentní vykreslování.

{{% alert color="info" title="Poznámka" %}}

Aspose Slides umožňuje načíst tyto fonty pomocí metody [loadExternalFonts](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* TrueType (.ttf) a TrueType Collection (.ttc) fonty. Viz [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) fonty. Viz [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Načíst vlastní fonty**

Aspose.Slides umožňuje načíst fonty používané v prezentaci, aniž byste je instalovali do systému. To ovlivňuje výstup při exportu – například do PDF, obrázků a dalších podporovaných formátů – takže výsledné dokumenty vypadají konzistentně napříč prostředími. Fonty jsou načteny z vlastních adresářů.

1. Zadejte jednu nebo více složek, které obsahují soubory fontů.
2. Vyvolejte statickou metodu [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) k načtení fontů z těchto složek.
3. Načtěte a vykreslete/exportujte prezentaci.
4. Vyvolejte [FontsLoader.clearCache](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/FontsLoader#clearCache--) k vyprázdnění mezipaměti fontů.

Následující ukázkový kód demonstruje proces načítání fontů:

```java
import com.aspose.slides.*;

// Definujte složky, které obsahují soubory vlastních fontů.
String externalFontFolder1 = "assets/fonts";
String externalFontFolder2 = "global/fonts";

String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// Načíst vlastní fonty ze zadaných složek.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    // Vykreslit/exportovat prezentaci (např. do PDF, obrázků nebo jiných formátů) pomocí načtených fontů.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Vyprázdnit mezipaměť fontů po dokončení práce.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Poznámka" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) přidává další složky do cest pro vyhledávání fontů, ale nemění pořadí inicializace fontů. Fonty jsou inicializovány v tomto pořadí:

1. Výchozí cesta k fontům operačního systému.
2. Cesty načtené pomocí [FontsLoader](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fontsloader/).

{{%/alert %}}

## **Získat složky s vlastními fonty**

Aspose.Slides poskytuje metodu [getFontFolders](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) k vyhledání složek s fonty. Tato metoda vrací složky přidané prostřednictvím metody `LoadExternalFonts` a systémové složky s fonty.

Tento Java kód ukazuje, jak použít [getFontFolders](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fontsloader/#getFontFolders--):

```java
import com.aspose.slides.*;

// Tento řádek vypisuje složky, ve kterých se hledají soubory fontů.
// Jedná se o složky přidané metodou LoadExternalFonts a systémové složky s fonty.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Zadat vlastní fonty používané v prezentaci**

Aspose.Slides poskytuje vlastnost [setDocumentLevelFontSources](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) k určení externích fontů, které budou použity s prezentací.

Tento Java kód ukazuje, jak použít [setDocumentLevelFontSources](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) vlastnost:

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
    // CustomFont1, CustomFont2 a fonty ze složek assets\fonts & global\fonts a jejich podadresářů jsou k dispozici prezentaci
} finally {
    if (pres != null) pres.dispose();
}
```

## **Spravovat fonty externě**

Aspose.Slides poskytuje metodu [loadExternalFont](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) k načtení externích fontů z binárních dat.

Tento Java kód demonstruje proces načítání fontu z pole bajtů:

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
        // externí font načtený během životnosti prezentace
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **Často kladené otázky**

### Ovlivňují vlastní fonty export do všech formátů (PDF, PNG, SVG, HTML)?

Ano. Připojené fonty používá renderér při exportu do všech formátů.

### Jsou vlastní fonty automaticky vloženy do výsledného PPTX?

Ne. Registrace fontu pro vykreslování není totéž jako jeho vložení do PPTX. Pokud potřebujete, aby byl font součástí souboru prezentace, musíte použít explicitní [funkce vložení](/slides/cs/androidjava/embedded-font/).

### Mohu řídit chování náhradního fontu, když vlastní font postrádá určité glyphy?

Ano. Nakonfigurujte [font substitution](/slides/cs/androidjava/font-substitution/), [replacement rules](/slides/cs/androidjava/font-replacement/) a [fallback sets](/slides/cs/androidjava/fallback-font/) pro definování, který font se použije, když požadovaný glyph chybí.

### Mohu používat fonty v Linux/Docker kontejnerech bez jejich instalace do systému?

Ano. Odkazujte na vlastní složky s fonty nebo načtěte fonty z pole bajtů. Tím se odstraní jakákoli závislost na systémových složkách s fonty v obrazu kontejneru.

### Jak to je s licencí – mohu vložit libovolný vlastní font bez omezení?

Jste zodpovědní za dodržování licenčních podmínek fontů. Podmínky se liší; některé licence zakazují vkládání nebo komerční použití. Vždy si před distribucí výstupů přečtěte EULA daného fontu.