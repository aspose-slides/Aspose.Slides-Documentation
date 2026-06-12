---
title: Nastavení výchozích písem prezentace v JavaScriptu
linktitle: Výchozí písmo
type: docs
weight: 30
url: /cs/nodejs-java/default-font/
keywords:
- výchozí písmo
- běžné písmo
- normální písmo
- asijské písmo
- export PDF
- export XPS
- export obrázků
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Nastavte výchozí písma v Aspose.Slides pro Node.js přes Java, aby byla zajištěna správná konverze PowerPoint (PPT, PPTX) a OpenDocument (ODP) do PDF, XPS a obrázků."
---
## **Přehled**

Aspose.Slides vám umožňuje určit výchozí písma, která se použijí při vykreslování prezentace. To je užitečné při vytváření miniatur snímků nebo exportu prezentace do formátů, jako jsou PDF a XPS. Výchozí písma se nastavují pomocí `LoadOptions` před načtením prezentace.

Metoda `setDefaultRegularFont` určuje výchozí písmo pro běžný text, zatímco `setDefaultAsianFont` udává výchozí písmo pro asijský text. Po nastavení těchto možností lze prezentaci načíst a vykreslit pomocí určených písem.

## **Použití výchozích písem pro vykreslení prezentace**
Aspose.Slides vám umožňuje nastavit výchozí písmo pro vykreslení prezentace do PDF, XPS nebo miniatur. Tento článek ukazuje, jak definovat DefaultRegularFont a DefaultAsianFont pro použití jako výchozí písma. Postupujte podle níže uvedených kroků pro načtení písem z externích adresářů pomocí Aspose.Slides pro Node.js přes Java API:

1. Vytvořte instanci [LoadOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/LoadOptions).
2. Nastavte [DefaultRegularFont](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) na požadované písmo. V následujícím příkladu jsem použil Wingdings.
3. Nastavte [DefaultAsianFont](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) na požadované písmo. V následujícím vzorku jsem použil Wingdings.
4. Načtěte prezentaci pomocí třídy Presentation a nastavením možností načtení.
5. Nyní vygenerujte miniaturu snímku, PDF a XPS pro ověření výsledků.

Implementace výše uvedeného je uvedena níže.

```javascript
// Použijte možnosti načtení k definování výchozích běžných a asijských písem
var loadOptions = new aspose.slides.LoadOptions(aspose.slides.LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");
// Načtěte prezentaci
var pres = new aspose.slides.Presentation("DefaultFonts.pptx", loadOptions);
try {
    // Vygenerujte miniaturu snímku
    var slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    try {
        // uložte obrázek na disk.
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    // Vygenerujte PDF
    pres.save("output_out.pdf", aspose.slides.SaveFormat.Pdf);
    // Vygenerujte XPS
    pres.save("output_out.xps", aspose.slides.SaveFormat.Xps);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Často kladené otázky**

**Co přesně ovlivňují DefaultRegularFont a DefaultAsianFont — pouze export, nebo také miniatury, PDF, XPS, HTML a SVG?**

Podílejí se na renderovacím řetězci pro všechna podporovaná výstupy. To zahrnuje miniatury snímků, [PDF](/slides/cs/nodejs-java/convert-powerpoint-to-pdf/), [XPS](/slides/cs/nodejs-java/convert-powerpoint-to-xps/), [rastr (obrázky)](/slides/cs/nodejs-java/convert-powerpoint-to-png/), [HTML](/slides/cs/nodejs-java/convert-powerpoint-to-html/), a [SVG](/slides/cs/nodejs-java/render-a-slide-as-an-svg-image/), protože Aspose.Slides používá stejnou logiku rozložení a rozpoznávání glyfů napříč těmito cíli.

**Používají se výchozí písma při pouhém načtení a uložení PPTX bez jakéhokoli vykreslování?**

Ne. Výchozí písma jsou důležitá, když je třeba text měřit a kreslit. Přímé otevření a uložení prezentace nemění uložené běhy písem ani strukturu souboru. Výchozí písma se uplatní během operací, které renderují nebo přetékají text.

**Pokud přidám vlastní složky s písmy nebo poskytnu písma z paměti, budou brány v úvahu při výběru výchozích písem?**

Ano. [Vlastní zdroje písem](/slides/cs/nodejs-java/custom-font/) rozšiřují katalog dostupných rodin a glyfů, které může engine použít. Výchozí písma a všechny [pravidla náhrad](/slides/cs/nodejs-java/fallback-font/) se nejprve vyhodnotí vůči těmto zdrojům, což poskytuje spolehlivější pokrytí na serverech a v kontejnerech.

**Ovlivní výchozí písma textové metriky (kerning, posuny) a tím i zalamování řádků a zalamování?**

Ano. Změna písma mění metriky glyfů a může ovlivnit zalamování řádků, zalamování textu a stránkování během vykreslování. Pro stabilitu rozvržení [vložte původní písma](/slides/cs/nodejs-java/embedded-font/) nebo vyberte metricky kompatibilní výchozí a náhradní rodiny.

**Má smysl nastavovat výchozí písma, pokud jsou všechna písma použita v prezentaci vložena?**

Často to není nutné, protože [vložená písma](/slides/cs/nodejs-java/embedded-font/) již zajišťují konzistentní vzhled. Výchozí písma však stále pomáhají jako bezpečnostní síť pro znaky, které nejsou pokryty vloženým podmnožinou, nebo když soubor kombinuje vložený a nevložený text.