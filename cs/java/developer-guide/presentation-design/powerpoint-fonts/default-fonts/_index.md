---
title: Určete výchozí písma prezentace v Java
linktitle: Výchozí písmo
type: docs
weight: 30
url: /cs/java/default-font/
keywords:
- výchozí písmo
- běžné písmo
- normální písmo
- asijské písmo
- export do PDF
- export do XPS
- export obrázků
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Nastavte výchozí písma v Aspose.Slides pro Java, aby byla zajištěna správná konverze PowerPointu (PPT, PPTX) a OpenDocumentu (ODP) do PDF, XPS a obrázků."
---
## **Přehled**

Aspose.Slides vám umožňuje určit výchozí písma, která se používají při vykreslování prezentace. To je užitečné při vytváření miniatur snímků nebo exportu prezentace do formátů, jako jsou PDF a XPS. Výchozí písma jsou nakonfigurována pomocí `LoadOptions` před načtením prezentace.

Metoda `setDefaultRegularFont` určuje výchozí písmo pro běžný text, zatímco `setDefaultAsianFont` určuje výchozí písmo pro asijský text. Po nastavení těchto možností lze načíst a vykreslit prezentaci pomocí zadaných písem.

## **Použití výchozích písem pro vykreslení prezentace**
Aspose.Slides vám umožňuje nastavit výchozí písmo pro vykreslení prezentace do PDF, XPS nebo miniatur. Tento článek ukazuje, jak definovat DefaultRegularFont a DefaultAsianFont pro jejich použití jako výchozí písma. Postupujte podle níže uvedených kroků pro načtení písem z externích adresářů pomocí Aspose.Slides pro Java API:

1. Vytvořte instanci [LoadOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/LoadOptions).
1. [Nastavte DefaultRegularFont](https://reference.aspose.com/slides/cs/java/com.aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) na požadované písmo. V následujícím příkladu jsem použil Wingdings.
1. [Nastavte DefaultAsianFont](https://reference.aspose.com/slides/cs/java/com.aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) na požadované písmo. V následujícím vzorku jsem použil Wingdings.
1. Načtěte prezentaci pomocí třídy Presentation a nastavených možností načtení.
1. Nyní vygenerujte miniaturu snímku, PDF a XPS pro ověření výsledků.

Implementace výše je uvedena níže.

```java
// Použijte možnosti načtení k definování výchozích regulárních a asijských písem
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");

// Load the presentation
Presentation pres = new Presentation("DefaultFonts.pptx", loadOptions);
try {
    // Vytvořte miniaturu snímku
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    try {
         // uložte obrázek na disk.
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }

    // Vytvořte PDF
    pres.save("output_out.pdf", SaveFormat.Pdf);

    // Vytvořte XPS
    pres.save("output_out.xps", SaveFormat.Xps);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Často kladené otázky**

**Co přesně ovlivňují DefaultRegularFont a DefaultAsianFont – pouze export, nebo i miniatury, PDF, XPS, HTML a SVG?**

Podílejí se na renderovacím řetězci pro všechna podporovaná výstupy. To zahrnuje miniatury snímků, [PDF](/slides/cs/java/convert-powerpoint-to-pdf/), [XPS](/slides/cs/java/convert-powerpoint-to-xps/), [raster images](/slides/cs/java/convert-powerpoint-to-png/), [HTML](/slides/cs/java/convert-powerpoint-to-html/), a [SVG](/slides/cs/java/render-a-slide-as-an-svg-image/), protože Aspose.Slides používá stejnou logiku rozložení a řešení glifů napříč těmito cíli.

**Používají se výchozí písma při pouhém načtení a uložení PPTX bez jakéhokoli renderování?**

Ne. Výchozí písma jsou relevantní, když je třeba text změřit a vykreslit. Přímé otevření a uložení prezentace nemění uložené běhy písem ani strukturu souboru. Výchozí písma se uplatní při operacích, které renderují nebo přetvářejí text.

**Pokud přidám své vlastní složky s písmy nebo poskytnu písma z paměti, budou brány v úvahu při výběru výchozích písem?**

Ano. [Custom font sources](/slides/cs/java/custom-font/) rozšiřují katalog dostupných rodin a glifů, které engine může použít. Výchozí písma a případná [fallback rules](/slides/cs/java/fallback-font/) se nejprve resolvou proti těmto zdrojům, což poskytuje spolehlivější pokrytí na serverech a v kontejnerech.

**Ovlivní výchozí písma metriky textu (kerning, šířky) a tím i zalamování řádků a obalování?**

Ano. Změna písma mění metriky glifů a může ovlivnit zalamování řádků, obalování a stránkování během renderování. Pro stabilitu rozvržení [embed the original fonts](/slides/cs/java/embedded-font/) nebo vyberte metricky kompatibilní výchozí a náhradní rodiny.

**Má smysl nastavit výchozí písma, pokud jsou všechna písma použita v prezentaci vložena?**

Často to není nutné, protože [embedded fonts](/slides/cs/java/embedded-font/) již zajišťují konzistentní vzhled. Výchozí písma stále pomáhají jako záchranná síť pro znaky, které nejsou pokryty vloženým podmnožinou, nebo když soubor kombinuje vložený a nevložený text.