---
title: Proč ne Open XML SDK
type: docs
weight: 120
url: /cs/php-java/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- porovnání
- model objektu prezentace
- konverze vysoké kvality
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Zjistěte, proč je Aspose.Slides lepší volbou než bezplatný Open XML SDK: porovnejte funkce, konverzi bez automatizace a širokou podporu pro PPT, PPTX a ODP."
---
## **Přehled**

Tento článek vysvětluje, kdy si vývojáři mohou vybrat Open XML SDK nebo Aspose.Slides pro práci s prezentačními dokumenty. Popisuje Open XML SDK jako knihovnu pro manipulaci s OOXML balíčky a jejich podkladovými XML elementy, zatímco Aspose.Slides je představen jako knihovna pro zpracování prezentací s vysoceúrovňovým objektovým modelem a podporou mnoha úkolů souvisejících s PowerPointem.

Článek srovnává obě možnosti podle podporovaných formátů, programovacího modelu, schopností renderování a tisku, podpory platforem a běžných případů použití. Také objasňuje, že Open XML SDK může být vhodný pro základní operace s PPTX nebo přímý přístup k OOXML elementům, zatímco Aspose.Slides je vhodnější pro složité úkoly, jako práce s více formáty PowerPointu, kopírování nebo klonování tvarů, nahrazování textu, aplikaci animací a konverzi prezentací do PDF, TIFF nebo XPS.

## **Co je Open XML SDK?**
Podle [Knihovna MSDN](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk) je Open XML SDK definováno jako:

Open XML SDK 2.0 zjednodušuje úlohu manipulace s Open XML balíčky a podkladovými Open XML schématy v balíčku. Open XML SDK 2.0 zapouzdřuje mnoho běžných úkolů, které vývojáři provádějí na Open XML balíčcích, takže můžete provádět složité operace během několika řádků kódu.

OOXML dokumenty jsou v podstatě zipované XML soubory a Open XML SDK je kolekce tříd, která vám umožňuje pracovat s obsahem OOXML dokumentů silně typizovaným způsobem. Místo rozbalení souboru pro extrahování XML, načtení tohoto XML do DOM stromu a přímé práce s XML elementy a atributy, Open XML SDK poskytuje třídy pro tuto práci.

## **Co je Aspose.Slides?**
Aspose.Slides je knihovna tříd, která umožňuje vaší aplikaci provádět následující úkoly zpracování prezentací:

- Programování s **Presentation** objektovým modelem.
- Vysoce kvalitní konverze mezi všemi populárními podporovanými formáty PowerPoint prezentací, včetně konverze do PDF, XPS a TIFF.
- Schopnost generovat miniatury snímků ve známých formátech, jako PNG, JPEG a BMP, spolu s exportem snímků do SVG.
- Schopnost vytvářet prezentace od nuly nebo kombinovat z jednoho či více dokumentů.
- Podpora přidávání animací, Ole Frames, tabulek, vytváření a správy grafů.
- Široké možnosti řízení formátování textu na úrovni TextFrames, odstavců a částí.

Pro více informací o podporovaných funkcích navštivte [Funkce Aspose.Slides](/slides/cs/php-java/product-overview/).

## **Porovnání Open XML SDK s Aspose.Slides**
{{% alert color="primary" %}} 

Následující tabulka porovnává funkce Open XML SDK a Aspose.Slides.

{{% /alert %}} 

|**Funkce nebo kategorie funkcí**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Podporované formáty prezentací|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Převod z PPT na PPTX|Ne|Ano|
|<p>Programování na vysoké úrovni s objektním modelem dokumentu prezentace (DOM):</p><p>- Najít a nahradit text.</p><p>- Sestavit snímky v prezentacích.</p>|Ne|Ano|
|Detailní programování s objektovým modelem dokumentu, přístup k jednotlivým prvkům a formátování, jako jsou TextHolders, TextFrames, Paragraphs a Portions.|Ano|Ano|
|Nízká úroveň přímý a úplný přístup k podkladovým XML prvkům a atributům, jako jsou identifikátory vztahů, identifikátory seznamů OOXML dokumentu.|Ano|Ne|
|<p>Renderování:</p><p>- Renderovat prezentace do PDF, PDF Notes, XPS, TIFF obrázků.</p><p>- Renderovat miniatury snímků do PNG, JPEG, BMP, SVG a TIFF.</p><p>- Specifikovat rozlišení obrazu, kvalitu, kompresi a další možnosti.</p>|Ne|Ano|
|Podporované platformy|Windows, .NET|Windows, Linux,UNIX, MAC, Java, PHP, Mono|

## **Závěr**
{{% alert color="primary" %}} 

Open XML SDK a Aspose.Slides nejsou přímou konkurencí, protože adresují poměrně odlišné potřeby a publikum. Open XML SDK je knihovna tříd, která poskytuje silně typizovaný způsob práce s OOXML dokumenty. Aspose.Slides je velmi užitečná knihovna pro zpracování prezentací, která poskytuje vynikající podporu téměř pro všechny souborové formáty Microsoft PowerPoint.

Pokud potřebujete pouze poměrně základní programovou operaci na PPTX dokumentu, může být Open XML SDK vhodnou volbou. S Open XML SDK budete pohodlně provádět jednoduché úkoly, jako je generování jednoduchého PPTX dokumentu, odstraňování komentářů, záhlaví/patiček, extrahování obrázků a podobně. Některé úkoly lze dosáhnout s Open XML SDK, ale nelze je dosáhnout s Aspose.Slides. Například pokud potřebujete přímo přistupovat k XML elementům a atributům OOXML dokumentu, měli byste použít Open XML SDK. Pokud však potřebujete provádět složité operace na dokumentech, jako jsou následující úlohy, je použití Aspose.Slides nejlepší volbou:

- Podpora starších formátů PowerPointu kromě PPTX.
- Kopírování nebo klonování tvarů ve snímcích způsobem, který kombinuje objekty, styly a další formátování vhodným způsobem.
- Nahrazení formátovaného nebo neformátovaného textu.
- Aplikace animací a používání spojnic s tvary.
- Konverze dokumentu do PDF, TIFF nebo XPS tak, aby výsledek vypadal přesně jako při konverzi v Microsoft PowerPoint.
- Vývoj .NET nebo Java aplikace jak pro desktopové, tak webové prostředí.

{{% /alert %}}