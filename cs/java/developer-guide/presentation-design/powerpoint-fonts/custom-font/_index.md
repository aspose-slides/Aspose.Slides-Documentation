---
title: Přizpůsobení fontů PowerPointu v Javě
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
description: "Přizpůsobte písma v PowerPoint snímcích pomocí Aspose.Slides pro Javu, aby vaše prezentace byly ostré a konzistentní na jakémkoli zařízení."
---
## **Přehled**

Aspose.Slides vám umožňuje používat vlastní písma v prezentacích bez jejich instalace do operačního systému. Můžete načíst písma z vlastních složek, poskytnout písma pro konkrétní prezentaci prostřednictvím zdrojů písma na úrovni dokumentu nebo načíst externí písma přímo z binárních dat.

Načtená písma se používají při vykreslování nebo exportu prezentace, například do PDF, obrázků a dalších podporovaných formátů. To pomáhá udržet výstup prezentace konzistentní napříč různými prostředími. Článek také vysvětluje, jak zkontrolovat složky s fonty používané Aspose.Slides a jak vymazat mezipaměť fontů po práci s externími fonty.

Registrace vlastních fontů pro vykreslování je oddělena od vkládání fontů do souboru PPTX. Pokud má být font uložen uvnitř samotné prezentace, použijte explicitně funkce pro vkládání fontů.

Téma prezentace může odkazovat na různé rodiny fontů pro jednotlivé psací systémy. Tyto mapování ukládají názvy fontů, ale neinstalují ani nenačítají soubory fontů. Viz [Script-Specific Theme Fonts](/slides/cs/java/script-specific-font-mappings/) pro správu mapování a použijte níže uvedené možnosti načítání, aby byly odkazované fonty k dispozici pro konzistentní vykreslování.

{{% alert color="info" title="Note" %}}
Aspose Slides vám umožňuje načíst tyto fonty pomocí metody [loadExternalFonts](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* TrueType (.ttf) a TrueType Collection (.ttc) fonty. Viz [TrueType](https://en.wikipedia.org/wiki/TrueType).
* OpenType (.otf) fonty. Viz [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **Načíst vlastní fonty**

Aspose.Slides vám umožňuje načíst fonty používané v prezentaci bez jejich instalace do systému. To ovlivňuje výstup exportu – například do PDF, obrázků a dalších podporovaných formátů – takže výsledné dokumenty vypadají konzistentně napříč prostředími. Fonty jsou načítány z vlastních adresářů.

1. Zadejte jednu nebo více složek, které obsahují soubory fontů.
2. Zavolejte statickou metodu [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) pro načtení fontů z těchto složek.
3. Načtěte a vykreslete/exportujte prezentaci.
4. Zavolejte [FontsLoader.clearCache](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fontsloader/#clearCache--) pro vymazání mezipaměti fontů.

Následující ukázka kódu demonstruje proces načítání fontů:

```java
import com.aspose.slides.*;

// Definujte složky, které obsahují soubory vlastních fontů.
String[] fontFolders = new String[] { "assets/fonts", "global/fonts" };

// Načtěte vlastní fonty ze zadaných složek.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    // Vykreslete/exportujte prezentaci (např. do PDF, obrázků nebo jiných formátů) pomocí načtených fontů.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Vymažte mezipaměť fontů po dokončení práce.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) přidává další složky do cest pro vyhledávání fontů, ale nemění pořadí inicializace fontů. Fonty jsou inicializovány v tomto pořadí:

1. Výchozí cesta fontů operačního systému.
1. Cesty načtené pomocí [FontsLoader](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fontsloader/).
{{%/alert %}}

## **Získat vlastní fontové složky**
Aspose.Slides poskytuje metodu [getFontFolders](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fontsloader/#getFontFolders--) která vám umožní najít složky s fonty. Tato metoda vrací složky přidané pomocí metody `LoadExternalFonts` a systémové fontové složky.

Tento Java kód ukazuje, jak použít [getFontFolders](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fontsloader/#getFontFolders--):

```java
import com.aspose.slides.*;

// Tento řádek vypisuje složky, kde se hledají soubory fontů.
// Jedná se o složky přidané metodou LoadExternalFonts a systémové složky s fonty.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Zadání vlastních fontů použité v prezentaci**
Aspose.Slides poskytuje vlastnost [setDocumentLevelFontSources](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) která vám umožní zadat externí fonty, které budou použity s prezentací.

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
    // CustomFont1, CustomFont2 a fonty ze složek assets\fonts & global\fonts a jejich podadresářů jsou k dispozici pro prezentaci
} finally {
    if (pres != null) pres.dispose();
}
```

## **Správa fontů externě**
Aspose.Slides poskytuje metodu [loadExternalFont](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data), která vám umožní načíst externí fonty z binárních dat.

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
        // externí font načten během životnosti prezentace
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **Časté dotazy**

### Ovlivňují vlastní fonty export do všech formátů (PDF, PNG, SVG, HTML)?
Ano. Připojené fonty jsou používány rendererem ve všech exportních formátech.

### Jsou vlastní fonty automaticky vkládány do výsledného PPTX?
Ne. Registrace fontu pro vykreslování není totéž jako jeho vložení do PPTX. Pokud potřebujete, aby byl font součástí souboru prezentace, musíte použít explicitně [embedding features](/slides/cs/java/embedded-font/).

### Můžu kontrolovat chování při nedostatku některých glyfů ve vlastním fontu?
Ano. Nastavte [font substitution](/slides/cs/java/font-substitution/), [replacement rules](/slides/cs/java/font-replacement/), a [fallback sets](/slides/cs/java/fallback-font/) pro definování přesně, který font se použije, když požadovaný glyf chybí.

### Můžu používat fonty v Linux/Docker kontejnerech bez jejich instalace na úrovni systému?
Částečně. Aspose.Slides dokáže používat fonty z vašich vlastních složek nebo z pole bajtů bez instalace, ale podpora fontů v Javě stále vyžaduje alespoň jeden nainstalovaný font v obrazu. Bez něj načítání selže s chybou „Fontconfig head is null, check your fonts or fonts configuration“. Viz [Deploy Fonts](/slides/cs/java/deploy-fonts/).

### Jak to je s licencováním – mohu vložit jakýkoli vlastní font bez omezení?
Jste odpovědní za dodržování licenčních podmínek fontů. Podmínky se liší; některé licence zakazují vkládání nebo komerční využití. Vždy si před distribucí výstupů prostudujte EULA daného fontu.