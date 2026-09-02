---
title: Proč ne Open XML SDK
type: docs
weight: 120
url: /cs/php-java/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- porovnání
- objektový model prezentace
- vysoce kvalitní převod
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Zjistěte, proč je Aspose.Slides lepší volbou než bezplatné Open XML SDK: porovnejte funkce, převod bez nutnosti automatizace a širokou podporu pro PPT, PPTX a ODP."
---
## **Přehled**

Tento článek vysvětluje, kdy si vývojáři mohou vybrat Open XML SDK nebo Aspose.Slides pro práci s prezentačními dokumenty. Popisuje Open XML SDK jako knihovnu pro manipulaci s OOXML balíčky a jejich podkladovými XML elementy, zatímco Aspose.Slides je představen jako knihovna pro zpracování prezentací s vysoceúrovňovým objektovým modelem a podporou mnoha úkolů souvisejících s PowerPointem.

Článek porovnává obě možnosti podle podporovaných formátů, programového modelu, vykreslování, podpory platforem a běžných scénářů použití. Také objasňuje, že Open XML SDK může být vhodný pro základní operace s PPTX nebo přímý přístup k OOXML elementům, zatímco Aspose.Slides je vhodnější pro složité úkoly, jako práce s více formáty PowerPointu, kopírování nebo klonování tvarů, nahrazování textu, aplikování animací a převod prezentací do PDF, TIFF nebo XPS.

## **Co je Open XML SDK?**
Podle [Knihovny MSDN](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk) je Open XML SDK definován jako:

Open XML SDK 2.0 zjednodušuje úkol manipulace s Open XML balíčky a podkladovými Open XML schématy uvnitř balíčku. Open XML SDK 2.0 zapouzdřuje mnoho běžných úloh, které vývojáři provádějí na Open XML balíčcích, takže můžete provádět složité operace jen s několika řádky kódu.

OOXML dokumenty jsou v podstatě zkomprimované XML soubory a Open XML SDK je sbírka tříd, která umožňuje pracovat s obsahem OOXML dokumentů typově bezpečným způsobem. Místo rozbalení souboru za účelem extrakce XML, načtení tohoto XML do DOM stromu a přímé práce s XML elementy a atributy, Open XML SDK poskytuje třídy, které to umožňují.

## **Co je Aspose.Slides?**
Aspose.Slides je knihovna tříd, která umožňuje vaší aplikaci provádět následující úkoly zpracování prezentací:

- Programování pomocí objektového modelu **Presentation**.
- Vysoce kvalitní převody mezi všemi populárními podporovanými formáty PowerPoint prezentací, včetně převodu do PDF, XPS a TIFF.
- Schopnost generovat miniatury snímků v dobře známých formátech jako PNG, JPEG a BMP spolu s exportem snímků do SVG.
- Schopnost vytvářet prezentace od nuly nebo kombinací z jednoho či více dokumentů.
- Podpora přidávání animací, Ole rámců, tabulek, vytváření a správy grafů.
- Možnost rozsáhlé kontroly nad formátováním textu na úrovních TextFrames, Paragraphs a Portions.

Pro více informací o podporovaných funkcích navštivte [Funkce Aspose.Slides](/slides/cs/php-java/product-overview/).

## **Porovnejte Open XML SDK s Aspose.Slides**
{{% alert color="info" %}} 

Následující tabulka porovnává funkce Open XML SDK a Aspose.Slides.

{{% /alert %}} 

|**Funkce nebo kategorie funkcí**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Podporované formáty prezentací|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Převod z PPT na PPTX|Ne|Ano|
|<p>Vysoceúrovňové programování pomocí objektového modelu dokumentu prezentace (DOM):</p><p>- Najít a nahradit text.</p><p>- Sestavit snímky v prezentacích.</p>|Ne|Ano|
|Detailní programování s objektovým modelem dokumentu, přístup k jednotlivým elementům a formátování, jako jsou TextHolders, TextFrames, Paragraphs a Portions.|Ano|Ano|
|Nízká úroveň přímého a úplného přístupu k podkladovým XML elementům a atributům, jako jsou identifikátory vztahů, identifikátory seznamů OOXML dokumentu.|Ano|Ne|
|<p>Vykreslování:</p><p>- Vykreslit prezentace do PDF, PDF Notes, XPS, TIFF obrázků.</p><p>- Vykreslit miniatury snímků do PNG, JPEG, BMP, SVG a TIFF.</p><p>- Specifikovat rozlišení obrazu, kvalitu, kompresi a další možnosti.</p>|Ne|Ano|
|Podporované platformy|Windows, .NET|Windows, Linux,UNIX, MAC, Java, PHP, Mono|

## **Závěr**
{{% alert color="info" %}} 

Open XML SDK a Aspose.Slides nekonkurují přímo, protože řeší poměrně odlišné potřeby a publikum. Open XML SDK je knihovna tříd, která poskytuje typově bezpečný způsob práce s OOXML dokumenty. Aspose.Slides je velmi užitečná knihovna pro zpracování prezentací, která poskytuje skvělou podporu pro téměř všechny formáty souborů Microsoft PowerPoint.

Pokud potřebujete jen poměrně základní programovací operaci na PPTX dokumentu, pak může být Open XML SDK vhodnou volbou. S Open XML SDK budete pohodlně provádět jednoduché úkoly, jako je generování jednoduchého PPTX dokumentu nebo odstraňování komentářů, záhlaví/patiček, extrakce obrázků a podobně. Některé úkoly lze dosáhnout pomocí Open XML SDK, ale nelze je dosáhnout pomocí Aspose.Slides. Například pokud potřebujete přímo přistupovat k XML elementům a atributům OOXML dokumentu, měli byste použít Open XML SDK. Pokud však potřebujete provádět složité operace na dokumentech, jako jsou některé z následujících úkolů, je použití Aspose.Slides nejlepší volbou:

- Podpora starších formátů PowerPointu kromě PPTX.
- Kopírování nebo klonování tvarů ve snímcích tak, aby kombinovaly objekty, styly a další formátování vhodným způsobem.
- Nahrazení formátovaného nebo neformátovaného textu.
- Aplikování animací a použití spojnic s tvary.
- Převod dokumentu do PDF, TIFF nebo XPS tak, aby vypadal přesně tak, jako by jej konvertoval Microsoft PowerPoint.
- Vývoj .NET nebo Java aplikace v desktopových i webových prostředích.

{{% /alert %}}