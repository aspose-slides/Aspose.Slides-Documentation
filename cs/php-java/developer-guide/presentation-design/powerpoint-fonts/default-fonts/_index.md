---
title: Určit výchozí písma prezentace v PHP
linktitle: Výchozí písmo
type: docs
weight: 30
url: /cs/php-java/default-font/
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
- PHP
- Aspose.Slides
description: "Nastavte výchozí písma v Aspose.Slides pro PHP přes Java, aby byla zajištěna správná konverze PowerPoint (PPT, PPTX) a OpenDocument (ODP) do PDF, XPS a obrázků."
---
## **Přehled**

Aspose.Slides vám umožňuje určit výchozí písma, která se používají při vykreslování prezentace. To je užitečné při generování miniatur snímků nebo při exportu prezentace do formátů, jako jsou PDF a XPS. Výchozí písma jsou nakonfigurována prostřednictvím `LoadOptions` před načtením prezentace.

Metoda `setDefaultRegularFont` určuje výchozí písmo pro běžný text, zatímco `setDefaultAsianFont` určuje výchozí písmo pro asijský text. Po nastavení těchto možností lze prezentaci načíst a vykreslit pomocí zadaných písem.

## **Použití výchozích písem pro vykreslení prezentace**
Aspose.Slides vám umožňuje nastavit výchozí písmo pro vykreslení prezentace do PDF, XPS nebo miniatur. Tento článek ukazuje, jak definovat DefaultRegularFont a DefaultAsianFont jako výchozí písma. Postupujte podle níže uvedených kroků pro načtení písem z externích adresářů pomocí Aspose.Slides pro PHP přes Java API:

1. Vytvořte instanci [LoadOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/LoadOptions).
1. [Set the DefaultRegularFont](https://reference.aspose.com/slides/cs/php-java/aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) na požadované písmo. V následujícím příkladu jsem použil Wingdings.
1. [Set the DefaultAsianFont](https://reference.aspose.com/slides/cs/php-java/aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) na požadované písmo. V příkladu jsem použil Wingdings.
1. Načtěte prezentaci pomocí třídy Presentation a nastavení možností načtení.
1. Nyní vygenerujte miniaturu snímku, PDF a XPS pro ověření výsledků.

```php
  # Použijte možnosti načtení k definování výchozích běžných a asijských písem
  $loadOptions = new LoadOptions(LoadFormat::Auto);
  $loadOptions->setDefaultRegularFont("Wingdings");
  $loadOptions->setDefaultAsianFont("Wingdings");
  # Načtěte prezentaci
  $pres = new Presentation("DefaultFonts.pptx", $loadOptions);
  try {
    # Vytvořte miniaturu snímku
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1, 1);
    try {
      # uložte obrázek na disk.
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # Vytvořte PDF
    $pres->save("output_out.pdf", SaveFormat::Pdf);
    # Vytvořte XPS
    $pres->save("output_out.xps", SaveFormat::Xps);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Často kladené otázky**

**Co přesně ovlivňují DefaultRegularFont a DefaultAsianFont – pouze export, nebo také miniatury, PDF, XPS, HTML a SVG?**

Podílejí se na renderovacím řetězci pro všechna podporovaná výstupy. To zahrnuje miniatury snímků, [PDF](/slides/cs/php-java/convert-powerpoint-to-pdf/), [XPS](/slides/cs/php-java/convert-powerpoint-to-xps/), [raster images](/slides/cs/php-java/convert-powerpoint-to-png/), [HTML](/slides/cs/php-java/convert-powerpoint-to-html/), a [SVG](/slides/cs/php-java/render-a-slide-as-an-svg-image/), protože Aspose.Slides používá stejnou logiku rozvržení a řešení glifů napříč těmito cíli.

**Používají se výchozí písma při jednoduchém načtení a uložení PPTX bez jakéhokoli renderování?**

Ne. Výchozí písma jsou relevantní, když je třeba text měřit a kreslit. Přímé otevření a uložení prezentace nemění uložené běhy písem ani strukturu souboru. Výchozí písma vstupují do hry během operací, které renderují nebo přeformátovávají text.

**Pokud přidám vlastní složky s písmy nebo poskytnu písma z paměti, budou brány v úvahu při výběru výchozích písem?**

Ano. [Custom font sources](/slides/cs/php-java/custom-font/) rozšiřují katalog dostupných rodin a glifů, které engine může použít. Výchozí písma a jakákoli [fallback rules](/slides/cs/php-java/fallback-font/) se nejprve řeší vůči těmto zdrojům, čímž poskytují spolehlivější pokrytí na serverech a v kontejnerech.

**Ovlivní výchozí písma metriky textu (kerning, posuny) a tím i zalomení řádků a zalamování?**

Ano. Změna písma mění metriky glifů a může ovlivnit zalomení řádků, zalamování a stránkování během renderování. Pro stabilitu rozvržení [embed the original fonts](/slides/cs/php-java/embedded-font/) nebo vyberte metricky kompatibilní výchozí a náhradní rodiny.

**Má smysl nastavit výchozí písma, pokud jsou všechna písma použita v prezentaci vložena?**

Často to není nutné, protože [embedded fonts](/slides/cs/php-java/embedded-font/) již zajišťují konzistentní vzhled. Výchozí písma stále slouží jako bezpečnostní síť pro znaky, které nejsou pokryty vloženým podmnožinou, nebo když soubor kombinuje vložený a nevložený text.