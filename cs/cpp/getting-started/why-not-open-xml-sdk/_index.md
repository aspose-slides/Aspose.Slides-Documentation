---
title: Proč ne Open XML SDK
type: docs
weight: 100
url: /cs/cpp/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- porovnání
- objektový model prezentace
- vysoce kvalitní konverze
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Zjistěte, proč je Aspose.Slides lepší volbou než bezplatný Open XML SDK: porovnejte funkce, konverzi bez automatizace a širokou podporu pro PPT, PPTX a ODP."
---
## **Přehled**

Tento článek vysvětluje, kdy mohou vývojáři zvolit Open XML SDK nebo Aspose.Slides pro práci s prezentačními dokumenty. Popisuje Open XML SDK jako knihovnu pro manipulaci s OOXML balíčky a jejich podkladovými XML elementy, zatímco Aspose.Slides je představen jako knihovna pro zpracování prezentací s vysoceúrovňovým objektovým modelem a podporou mnoha úkolů souvisejících s PowerPointem.

Článek porovnává obě možnosti podle podporovaných formátů, programovacího modelu, schopností renderování a tisku, podpory platforem a běžných případů použití. Rovněž objasňuje, že Open XML SDK může být vhodný pro základní operace s PPTX nebo přímý přístup k OOXML elementům, zatímco Aspose.Slides je vhodnější pro složité úkoly s prezentacemi, jako je práce s více formáty PowerPointu, kopírování nebo klonování tvarů, nahrazování textu, aplikace animací a převod prezentací do PDF, TIFF nebo XPS.

## **Co je Open XML SDK?**
Občas slyšíme tuto otázku: Proč bychom měli používat produkty Aspose místo bezplatného Open XML SDK? Tuto otázku lze snadno zodpovědět: funkce a schopnosti. Podle [MSDN knihovna](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk) je Open XML SDK definováno takto: Open XML SDK 2.0 zjednodušuje úlohu manipulace s Open XML balíčky a podkladovými elementy schématu Open XML v balíčku. Open XML SDK 2.0 zapouzdřuje mnoho běžných úkolů, které vývojáři provádějí na Open XML balíčcích, takže můžete provádět komplexní operace pomocí jen několika řádků kódu. OOXML dokumenty jsou v podstatě zipované XML soubory a Open XML SDK je sbírka tříd, která vám umožňuje pracovat s obsahem OOXML dokumentů typově bezpečným způsobem. Místo rozbalení souboru za účelem extrahování XML, načtení tohoto XML do DOM stromu a přímé práce s XML elementy a atributy poskytuje Open XML SDK třídy, které to dělají.

## **Co je Aspose.Slides?**
Aspose.Slides je knihovna tříd, která umožňuje vaší aplikaci provádět následující úkoly zpracování prezentací:

- Programování s **Presentation** objektním modelem.
- Vysoce kvalitní konverze mezi všemi populárními podporovanými formáty PowerPoint prezentací, včetně konverze do PDF a XPS.
- Možnost generovat náhledy snímků v dobře známých formátech jako PNG, JPEG a BMP spolu s exportem snímků do SVG.
- Možnost vytvářet prezentace od nuly nebo kombinovat z jednoho či více dokumentů.
- Podpora přidávání animací, Ole rámců, tabulek, tvorby a správy grafů.
- Rozsáhlá kontrola nad formátováním textu na úrovních TextFrames, Paragraphs a Portions.
  Pro další podrobnosti o podporovaných funkcích navštivte [Funkce Aspose.Slides](/slides/cs/cpp/product-overview/).

## **Porovnání Open XML SDK a Aspose.Slides**
Následující tabulka porovnává funkce Open XML SDK a Aspose.Slides.

|**Funkce nebo kategorie funkcí**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Podporované formáty prezentací|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Konverze z PPT na PPTX|Ne|Ano|
|<p>Vysoceúrovňové programování s modelem Presentation Document Object Model (DOM):</p><p>- Najít a nahradit text.</p><p>- Sestavit snímky v prezentacích.</p>|Ne|Ano|
|Detailní programování s objektovým modelem dokumentu, přístup k jednotlivým elementům a formátování jako TextHolders, TextFrames, Paragraphs a Portions.|Ano|Ano|
|Nízkourovňový přímý a úplný přístup k podkladovým XML elementům a atributům, jako jsou identifikátory vztahů, identifikátory seznamů OOXML dokumentu.|Ano|Ne|
|<p>Renderování:</p><p>- Renderovat prezentace do PDF, PDF Notes, XPS, TIFF obrázků.</p><p>- Renderovat náhledy snímků do PNG, JPEG, BMP, SVG a TIFF.</p><p>- Specifikovat rozlišení obrazu, kvalitu, kompresi a další možnosti.</p>|Ne|Ano|

## **Závěr**
Open XML SDK a Aspose.Slides nejsou přímou konkurencí, protože řeší zcela odlišné potřeby a publikum. Open XML SDK je knihovna tříd poskytující typově bezpečný způsob práce s OOXML dokumenty. Aspose.Slides je velmi užitečná knihovna pro zpracování prezentací, která poskytuje vynikající podporu pro téměř všechny formáty souborů Microsoft PowerPoint. Pokud potřebujete pouze poměrně základní programovací operaci na PPTX dokumentu, může být Open XML SDK vhodnou volbou. S Open XML SDK budete poměrně pohodlně provádět jednoduché úkoly jako generování jednoduchého PPTX dokumentu nebo odstraňování komentářů, záhlaví/patiček, extrahování obrázků a podobně. Některé úkoly lze dosáhnout s Open XML SDK, ale ne s Aspose.Slides. Například pokud potřebujete přímo přistupovat k XML elementům a atributům OOXML dokumentu, měli byste použít Open XML SDK. Naopak, pokud potřebujete provádět složité operace na dokumentech, jako jsou některé z následujících úkolů, je použití Aspose.Slides vaší nejlepší volbou:

- Podpora starších formátů PowerPointu kromě PPTX.
- Kopírování nebo klonování tvarů ve snímcích způsobem, který kombinuje objekty, styly a další formátování vhodným způsobem.
- Nahrazení formátovaného nebo neformátovaného textu.
- Aplikace animací a použití konektorů s tvary.
- Převod dokumentu do PDF nebo XPS tak, aby výsledek vypadal přesně jako při převodu v Microsoft PowerPoint.
- Vývoj C++ aplikace jak pro desktopové, tak pro konzolové prostředí.