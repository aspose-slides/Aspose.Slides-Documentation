---
title: Proč ne Open XML SDK
type: docs
weight: 100
url: /cs/cpp/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- srovnání
- model objektu prezentace
- konverze vysoké kvality
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Zjistěte, proč je Aspose.Slides lepší volbou než bezplatný Open XML SDK: porovnejte funkce, konverzi bez automatizace a širokou podporu pro PPT, PPTX a ODP."
---
## **Přehled**

Tento článek vysvětluje, kdy mohou vývojáři zvolit Open XML SDK nebo Aspose.Slides pro práci s prezentačními dokumenty. Popisuje Open XML SDK jako knihovnu pro manipulaci s OOXML balíčky a jejich podkladovými XML elementy, zatímco Aspose.Slides je představen jako knihovna pro zpracování prezentací s vysoce úrovňovým objektovým modelem a podporou mnoha úkolů souvisejících s PowerPointem.

Článek porovnává obě možnosti podle podporovaných formátů, programovacího modelu, renderování, podpory platforem a běžných scénářů použití. Také objasňuje, že Open XML SDK může být vhodný pro základní operace s PPTX nebo přímý přístup k OOXML elementům, zatímco Aspose.Slides je vhodnější pro složité úkoly s prezentacemi, jako je práce s více formáty PowerPointu, kopírování nebo klonování tvarů, nahrazování textu, aplikování animací a převod prezentací do PDF, TIFF nebo XPS.

## **Co je Open XML SDK?**
Občas slyšíme tuto otázku: Proč bychom měli používat produkty Aspose místo bezplatného Open XML SDK? Na tuto otázku je snadné odpovědět: funkce a možnosti. Podle [MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk) je Open XML SDK definováno jako: Open XML SDK 2.0 zjednodušuje úkol manipulace s Open XML balíčky a podkladovými Open XML schématy uvnitř balíčku. Open XML SDK 2.0 zapouzdřuje mnoho běžných úkolů, které vývojáři provádějí na Open XML balíčcích, takže můžete provádět složité operace pomocí jen několika řádků kódu. OOXML dokumenty jsou v podstatě zipované XML soubory a Open XML SDK je kolekce tříd, která umožňuje pracovat s obsahem OOXML dokumentů silně typovaným způsobem. Místo rozbalení souboru pro extrahování XML, načtení XML do DOM stromu a přímé práce s XML elementy a atributy, Open XML SDK poskytuje třídy, které to umožňují.

## **Co je Aspose.Slides?**
Aspose.Slides je knihovna tříd, která umožňuje vaší aplikaci provádět následující úkoly zpracování prezentací:

- Programování s objektem **Presentation** modelu.
- Vysoce kvalitní konverze mezi všemi populárními podporovanými formáty PowerPointu, včetně konverze do PDF a XPS.
- Možnost generovat miniatury snímků v dobře známých formátech jako PNG, JPEG a BMP spolu s exportem snímků do SVG.
- Možnost vytvářet prezentace od nuly nebo jejich kombinací z jednoho či více dokumentů.
- Podpora přidávání animací, Ole rámců, tabulek, tvorby a správy grafů.
- Široké možnosti řízení formátování textu na úrovních TextFrames, Paragraphs a Portions.

Pro více informací o podporovaných funkcích navštivte [Aspose.Slides Features](/slides/cs/cpp/product-overview/).

## **Porovnat Open XML SDK a Aspose.Slides**
Následující tabulka porovnává funkce Open XML SDK a Aspose.Slides.

|**Funkce nebo kategorie funkcí**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Podporované formáty prezentací|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Konverze z PPT na PPTX|Ne|Ano|
|Programování na vyšší úrovni s objektem Presentation Document Object Model (DOM):<br>- Vyhledat a nahradit text.<br>- Sestavit snímky v prezentacích.|Ne|Ano|
|Detailní programování s dokumentovým modelem, přístup k jednotlivým prvkům a formátování, jako jsou TextHolders, TextFrames, Paragraphs a Portions.|Ano|Ano|
|Nízká úroveň přímého a úplného přístupu k podkladovým XML prvkům a atributům, jako jsou identifikátory vztahů, identifikátory seznamů OOXML dokumentu.|Ano|Ne|
|Renderování:<br>- Renderovat prezentace do PDF, PDF Notes, XPS, TIFF obrázků.<br>- Renderovat miniatury snímků do PNG, JPEG, BMP, SVG a TIFF.<br>- Specifikovat rozlišení obrazu, kvalitu, kompresi a další možnosti.|Ne|Ano|

## **Závěr**
Open XML SDK a Aspose.Slides nejsou přímou konkurencí, protože řeší zcela odlišné potřeby a publikum. Open XML SDK je knihovna tříd poskytující silně typovaný způsob práce s OOXML dokumenty. Aspose.Slides je velmi užitečná knihovna pro zpracování prezentací, která poskytuje vynikající podporu téměř pro všechny formáty souborů Microsoft PowerPoint. Pokud potřebujete jen poměrně základní programovací operaci na PPTX dokumentu, může být Open XML SDK vhodnou volbou. S Open XML SDK budete poměrně pohodlně provádět jednoduché úkoly, jako je generování jednoduchého PPTX dokumentu, odstraňování komentářů, záhlaví/pati, extrakce obrázků a podobně. Některé úkoly lze dosáhnout s Open XML SDK, ale ne s Aspose.Slides. Například pokud potřebujete přímý přístup k XML elementům a atributům OOXML dokumentu, měli byste použít Open XML SDK. Naopak, pokud potřebujete provádět složité operace na dokumentech, jako jsou následující úkoly, je pro vás nejlepší volbou Aspose.Slides:

- Podpora starších formátů PowerPointu kromě PPTX.
- Kopírování nebo klonování tvarů ve snímcích tak, aby kombinovaly objekty, styly a další formátování vhodným způsobem.
- Nahrazování formátovaného nebo neformátovaného textu.
- Aplikování animací a použití konektorů s tvary.
- Převod dokumentu do PDF nebo XPS tak, aby výsledek vypadal přesně jako by jej převáděl Microsoft PowerPoint.
- Vývoj aplikace v C++ jak pro desktopové, tak konzolové prostředí.