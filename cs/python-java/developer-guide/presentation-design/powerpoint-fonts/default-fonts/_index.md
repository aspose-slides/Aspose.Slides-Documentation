---
title: Určete výchozí písma prezentace v Pythonu přes Java
linktitle: Výchozí písmo
type: docs
weight: 30
url: /cs/python-java/default-font/
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
- Python
- Java
- Aspose.Slides
description: "Nastavte výchozí písma v Aspose.Slides pro Python přes Java, aby převod PowerPoint (PPT, PPTX) a OpenDocument (ODP) na PDF, XPS a obrázky probíhal správně."
---
## **Přehled**

Aspose.Slides vám umožňuje specifikovat výchozí písma, která se používají při vykreslování prezentace. To je užitečné při generování náhledových snímků nebo při exportu prezentace do formátů, jako jsou PDF a XPS. Výchozí písma jsou nakonfigurována pomocí [LoadOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/loadoptions/) před načtením prezentace.

Metoda [setDefaultRegularFont](https://reference.aspose.com/slides/cs/python-java/aspose.slides/loadoptions/#setDefaultRegularFont) definuje výchozí písmo pro běžný text, zatímco [setDefaultAsianFont](https://reference.aspose.com/slides/cs/python-java/aspose.slides/loadoptions/#setDefaultAsianFont) definuje výchozí písmo pro asijský text. Po nastavení těchto možností může být prezentace načtena a vykreslena pomocí zadaných písem.

## **Použití výchozích písem při vykreslování prezentace**

Aspose.Slides vám umožňuje nastavit výchozí písma pro vykreslování prezentace do formátů PDF, XPS nebo náhledových snímků. V této části je ukázáno, jak definovat výchozí písma pro běžný a asijský text pomocí Aspose.Slides pro Python prostřednictvím Javy:

1. Vytvořte instanci [LoadOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/loadoptions/).
1. Použijte [setDefaultRegularFont](https://reference.aspose.com/slides/cs/python-java/aspose.slides/loadoptions/#setDefaultRegularFont) k zadání požadovaného písma. Následující příklad používá Wingdings.
1. Použijte [setDefaultAsianFont](https://reference.aspose.com/slides/cs/python-java/aspose.slides/loadoptions/#setDefaultAsianFont) k zadání požadovaného písma. Následující příklad také používá Wingdings.
1. Načtěte prezentaci pomocí [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) s nastavenými možnostmi načtení.
1. Vygenerujte náhled snímku, PDF a XPS a ověřte výsledky.

```python
from asposeslides.api import ImageFormat, LoadFormat, LoadOptions, Presentation, SaveFormat

# Použijte možnosti načtení k definování výchozích běžných a asijských písem.
load_options = LoadOptions(LoadFormat.Auto)
load_options.setDefaultRegularFont("Wingdings")
load_options.setDefaultAsianFont("Wingdings")

# Načtěte prezentaci.
presentation = Presentation("DefaultFonts.pptx", load_options)
try:
    # Vytvořte náhledový snímek.
    slide_image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        # Uložte obrázek na disk.
        slide_image.save("output.png", ImageFormat.Png)
    finally:
        slide_image.dispose()

    # Vytvořte PDF.
    presentation.save("output_out.pdf", SaveFormat.Pdf)

    # Vytvořte dokument XPS.
    presentation.save("output_out.xps", SaveFormat.Xps)
finally:
    presentation.dispose()
```

## **FAQ**

**Co přesně ovlivňují výchozí písma pro běžný a asijský text – jen export, nebo také náhledové snímky, PDF, XPS, HTML a SVG?**

Podílejí se na vykreslovací pipeline pro všechny podporované výstupy. To zahrnuje náhledové snímky, [PDF](/slides/cs/python-java/convert-powerpoint-to-pdf/), [XPS](/slides/cs/python-java/convert-powerpoint-to-xps/), [raster images](/slides/cs/python-java/convert-powerpoint-to-png/), [HTML](/slides/cs/python-java/convert-powerpoint-to-html/) a [SVG](/slides/cs/python-java/render-a-slide-as-an-svg-image/), protože Aspose.Slides používá stejnou logiku rozvržení a řešení glifů napříč těmito cíli.

**Použijí se výchozí písma při pouhém načtení a uložení PPTX bez jakéhokoli vykreslování?**

Ne. Výchozí písma mají význam, když je potřeba text měřit a kreslit. Přímé otevření a uložení prezentace nemění uložené běhy písem ani strukturu souboru. Výchozí písma vstupují do hry během operací, které vykreslují nebo přetékají text.

**Pokud přidám vlastní složky s fonty nebo dodám fonty z paměti, budou brány v úvahu při výběru výchozích písem?**

Ano. [Custom font sources](/slides/cs/python-java/custom-font/) rozšiřují katalog dostupných rodin a glifů, které může engine použít. Výchozí písma a jakákoli [fallback rules](/slides/cs/python-java/fallback-font/) se nejprve vyhodnocují vůči těmto zdrojům, což poskytuje spolehlivější pokrytí na serverech a v kontejnerech.

**Ovlivní výchozí písma metriky textu (kerning, posuny) a tím i zalomení řádků a zalamování?**

Ano. Změna písma mění metriky glifů a může měnit zalomení řádků, zalamování a stránkování během vykreslování. Pro stabilitu rozvržení [embed the original fonts](/slides/cs/python-java/embedded-font/) nebo vyberte metricky kompatibilní výchozí a záložní rodiny.

**Má smysl nastavovat výchozí písma, pokud jsou v prezentaci všechny použité fonty vložené?**

Často to není nutné, protože [embedded fonts](/slides/cs/python-java/embedded-font/) již zajišťují konzistentní vzhled. Výchozí písma stále slouží jako bezpečnostní síť pro znaky, které nejsou pokryty vloženým podmnožinou, nebo když soubor kombinuje vložený a nevložený text.