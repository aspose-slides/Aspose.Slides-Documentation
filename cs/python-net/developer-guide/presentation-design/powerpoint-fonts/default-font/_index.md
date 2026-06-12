---
title: Přizpůsobení výchozích fontů v prezentacích s Pythonem
linktitle: Výchozí font
type: docs
weight: 30
url: /cs/python-net/default-font/
keywords:
- výchozí font
- běžný font
- normální font
- asijský font
- export PDF
- export XPS
- export obrázků
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Nastavte výchozí fonty v Aspose.Slides pro Python, aby byla zajištěna správná konverze PowerPointu (PPT, PPTX) a OpenDocumentu (ODP) do PDF, XPS a obrázků."
---
## **Přehled**

Aspose.Slides umožňuje zadat výchozí fonty, které se použijí při vykreslování prezentace. To je užitečné při generování náhledů snímků nebo při exportu prezentace do formátů, jako jsou PDF a XPS. Výchozí fonty se nastavují pomocí `LoadOptions` před načtením prezentace.

Vlastnost `default_regular_font` definuje výchozí font pro běžný text, zatímco `default_asian_font` definuje výchozí font pro asijský text. Po nastavení těchto možností lze prezentaci načíst a vykreslit pomocí určených fontů.

## **Použití výchozích fontů při renderování prezentace**
Aspose.Slides umožňuje nastavit výchozí font pro renderování prezentace do PDF, XPS nebo náhledů. Tento článek ukazuje, jak definovat DefaultRegularFont a DefaultAsianFont jako výchozí fonty. Postupujte podle následujících kroků pro načtení fontů z externích adresářů pomocí Aspose.Slides for Python via .NET API:

1. Vytvořte instanci LoadOptions.  
1. Nastavte DefaultRegularFont na požadovaný font. V následujícím příkladu byl použit Wingdings.  
1. Nastavte DefaultAsianFont na požadovaný font. V následujícím příkladu byl také použit Wingdings.  
1. Načtěte prezentaci pomocí Presentation a nastavte možnosti načtení.  
1. Nyní vygenerujte náhled snímku, PDF a XPS pro ověření výsledků.

Implementace výše uvedeného je uvedena níže.

```py
import aspose.slides as slides

# Použijte možnosti načtení k definování výchozích běžných a asijských fontů# Použijte možnosti načtení k definování výchozích běžných a asijských fontů
loadOptions = slides.LoadOptions(slides.LoadFormat.AUTO)
loadOptions.default_regular_font = "Wingdings"
loadOptions.default_asian_font = "Wingdings"

# Načtěte prezentaci
with slides.Presentation(path + "DefaultFonts.pptx", loadOptions) as pptx:
    # Vygenerujte náhled snímku
    with pptx.slides[0].get_image(1, 1) as img:
        img.save("output_out.png", slides.ImageFormat.PNG)

    # Vygenerujte PDF
    pptx.save("output_out.pdf", slides.export.SaveFormat.PDF)

    # Vygenerujte XPS
    pptx.save("output_out.xps", slides.export.SaveFormat.XPS)
```


## **FAQ**

**Co přesně ovlivňují default_regular_font a default_asian_font – pouze export, nebo také náhledy, PDF, XPS, HTML a SVG?**

Podílejí se na renderovací pipeline pro všechna podporovaná výstupní formáty. To zahrnuje náhledy snímků, [PDF](/slides/cs/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/cs/python-net/convert-powerpoint-to-xps/), [rasterové obrázky](/slides/cs/python-net/convert-powerpoint-to-png/), [HTML](/slides/cs/python-net/convert-powerpoint-to-html/) a [SVG](/slides/cs/python-net/render-a-slide-as-an-svg-image/), protože Aspose.Slides používá stejnou logiku rozložení a řešení glifů napříč těmito cíli.

**Aplikují se výchozí fonty při pouhém načtení a uložení PPTX bez jakéhokoli renderování?**

Ne. Výchozí fonty mají význam, když je nutné text měřit a vykreslovat. Přímé otevření a uložení prezentace nemění uložené běhy fontů ani strukturu souboru. Výchozí fonty vstupují do hry během operací, které renderují nebo znovu rozvrhují text.

**Pokud přidám vlastní složky s fonty nebo poskytnu fonty z paměti, budou brány v úvahu při výběru výchozích fontů?**

Ano. [Custom font sources](/slides/cs/python-net/custom-font/) rozšiřují katalog dostupných rodin a glifů, které engine může použít. Výchozí fonty a jakákoli [fallback rules](/slides/cs/python-net/fallback-font/) se nejprve vyhodnocují vůči těmto zdrojům, což zajišťuje spolehlivější pokrytí na serverech a v kontejnerech.

**Ovplyvní výchozí fonty metriky textu (kerning, posuny) a tím i zalomení řádků a zalamování?**

Ano. Změna fontu mění metriky glifů a může měnit zalomení řádků, zalamování a stránkování během renderování. Pro stabilitu rozložení [embed the original fonts](/slides/cs/python-net/embedded-font/) nebo vyberte metricky kompatibilní výchozí a náhradní rodiny.

**Je nastavení výchozích fontů vůbec nutné, pokud jsou všechny použité fonty v prezentaci vloženy?**

Často to není nutné, protože [embedded fonts](/slides/cs/python-net/embedded-font/) již zajišťují konzistentní vzhled. Výchozí fonty však mohou sloužit jako záložní řešení pro znaky, které nejsou zahrnuty v vložené sadě, nebo když soubor kombinuje vložený a nevložený text.