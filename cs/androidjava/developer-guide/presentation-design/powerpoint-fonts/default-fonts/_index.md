---
title: Určete výchozí fonty prezentace na Androidu
linktitle: Výchozí font
type: docs
weight: 30
url: /cs/androidjava/default-font/
keywords:
- výchozí font
- běžný font
- normální font
- ázijský font
- export do PDF
- export do XPS
- export obrázků
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Nastavte výchozí fonty v Aspose.Slides pro Android pomocí Javy, aby byla zajištěna správná konverze PowerPoint (PPT, PPTX) a OpenDocument (ODP) do PDF, XPS a obrázků."
---
## **Přehled**

Aspose.Slides vám umožňuje zadat výchozí fonty, které se používají při renderování prezentace. To je užitečné při vytváření miniatur snímků nebo při exportu prezentace do formátů, jako jsou PDF a XPS. Výchozí fonty jsou nakonfigurovány pomocí `LoadOptions` před načtením prezentace.

`setDefaultRegularFont` metoda určuje výchozí font pro běžný text, zatímco `setDefaultAsianFont` určuje výchozí font pro ázijský text. Po nastavení těchto možností lze prezentaci načíst a renderovat s použitím zadaných fontů.

## **Použití výchozích fontů při renderování prezentace**
Aspose.Slides vám umožňuje nastavit výchozí font pro renderování prezentace do PDF, XPS nebo miniatur. Tento článek ukazuje, jak definovat DefaultRegularFont a DefaultAsianFont pro použití jako výchozí fonty. Postupujte podle níže uvedených kroků pro načtení fontů z externích adresářů pomocí Aspose.Slides pro Android přes Java API:

1. Vytvořte instanci třídy LoadOptions.
1. [Nastavte DefaultRegularFont](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) na požadovaný font. V následujícím příkladu jsem použil Wingdings.
1. [Nastavte DefaultAsianFont](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) na požadovaný font. V následujícím vzorku jsem použil Wingdings.
1. Načtěte prezentaci pomocí třídy Presentation a nastavených možností načtení.
1. Nyní vygenerujte miniaturu snímku, PDF a XPS pro ověření výsledků.

Implementace výše uvedeného je uvedena níže.

```java
// Použijte možnosti načtení k definování výchozích běžných a ázijských fontů
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");

// Načtěte prezentaci
Presentation pres = new Presentation("DefaultFonts.pptx", loadOptions);
try {
    // Vygenerujte miniaturu snímku
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    try {
         // uložte obrázek na disk.
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }

    // Vygenerujte PDF
    pres.save("output_out.pdf", SaveFormat.Pdf);

    // Vygenerujte XPS
    pres.save("output_out.xps", SaveFormat.Xps);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Často kladené otázky**

**Co přesně ovlivňují DefaultRegularFont a DefaultAsianFont – jen export, nebo také miniatury, PDF, XPS, HTML a SVG?**

Podílejí se na renderovacím řetězci pro všechna podporovaná výstupy. To zahrnuje miniatury snímků, [PDF](/slides/cs/androidjava/convert-powerpoint-to-pdf/), [XPS](/slides/cs/androidjava/convert-powerpoint-to-xps/), [rastrické obrázky](/slides/cs/androidjava/convert-powerpoint-to-png/), [HTML](/slides/cs/androidjava/convert-powerpoint-to-html/), a [SVG](/slides/cs/androidjava/render-a-slide-as-an-svg-image/), protože Aspose.Slides používá stejnou logiku rozvržení a rozlišení glyfů napříč těmito cíli.

**Použijí se výchozí fonty při pouhém načtení a uložení PPTX bez jakéhokoli renderování?**

Ne. Výchozí fonty mají vliv pouze tehdy, když je třeba text měřit a kreslit. Přímé otevření a uložení prezentace nemění uložené běhy fontů ani strukturu souboru. Výchozí fonty vstupují do hry během operací, které renderují nebo přetékají text.

**Pokud přidám vlastní složky s fonty nebo poskytnu fonty z paměti, budou zohledněny při výběru výchozích fontů?**

Ano. [Vlastní zdroje fontů](/slides/cs/androidjava/custom-font/) rozšiřují katalog dostupných rodin a glyfů, které engine může použít. Výchozí fonty a jakákoli [pravidla záložních fontů](/slides/cs/androidjava/fallback-font/) se nejprve vyhodnocují proti těmto zdrojům, což poskytuje spolehlivější pokrytí na serverech a v kontejnerech.

**Ovlivní výchozí fonty metriky textu (kerning, posuny) a tím i zalamování řádků a balení?**

Ano. Změna fontu mění metriky glyfů a může změnit zalamování řádků, balení a stránkování během renderování. Pro stabilitu rozvržení [vložte původní fonty](/slides/cs/androidjava/embedded-font/) nebo vyberte metricky kompatibilní výchozí a záložní rodiny.

**Má smysl nastavovat výchozí fonty, pokud jsou všechny fonty v prezentaci vloženy?**

Často to není nutné, protože [vložené fonty](/slides/cs/androidjava/embedded-font/) již zajišťují konzistentní vzhled. Výchozí fonty však stále slouží jako bezpečnostní síť pro znaky, které nejsou pokryty vloženým podmnožinou, nebo když soubor kombinuje vložený a nevložený text.