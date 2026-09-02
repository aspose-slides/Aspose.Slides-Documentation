---
title: Proč ne Open XML SDK
type: docs
weight: 120
url: /cs/java/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- porovnání
- model objektu prezentace
- vysoce kvalitní konverze
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Podívejte se, proč je Aspose.Slides lepší volbou než bezplatný Open XML SDK: porovnejte funkce, konverzi bez automatizace a širokou podporu pro PPT, PPTX a ODP."
---
## **Přehled**

Tento článek vysvětluje, kdy mohou vývojáři zvolit Open XML SDK nebo Aspose.Slides pro práci s prezentačními dokumenty. Popisuje Open XML SDK jako knihovnu pro manipulaci s balíčky OOXML a jejich podkladovými XML elementy, zatímco Aspose.Slides je představena jako knihovna pro zpracování prezentací s vysoceúrovňovým objektním modelem a podporou mnoha úkolů souvisejících s PowerPointem.

Článek porovnává obě možnosti podle podporovaných formátů, programovacího modelu, vykreslování, podpory platforem a běžných případů použití. Také objasňuje, že Open XML SDK může být vhodný pro základní operace s PPTX nebo přímý přístup k OOXML elementům, zatímco Aspose.Slides je vhodnější pro složité úkoly s prezentacemi, jako je práce s více formáty PowerPointu, kopírování nebo klonování tvarů, nahrazování textu, aplikace animací a převod prezentací do PDF, TIFF nebo XPS.

## **Co je Open XML SDK?**
Podle [Knihovna MSDN](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk) je Open XML SDK definováno jako:

Open XML SDK 2.0 zjednodušuje úlohu manipulace s Open XML balíčky a podkladovými Open XML schématovými elementy v balíčku. Open XML SDK 2.0 zapouzdřuje mnoho běžných úkolů, které vývojáři provádějí na Open XML balíčcích, takže můžete provádět složité operace s jen několika řádky kódu.

OOXML dokumenty jsou v podstatě zipované XML soubory a Open XML SDK je soubor tříd, které umožňují pracovat s obsahem OOXML dokumentů typově bezpečným způsobem. To znamená, že místo rozbalení souboru pro extrakci XML, načtení tohoto XML do DOM stromu a přímé práce s XML elementy a atributy, poskytuje Open XML SDK třídy, které to provádějí.

## **Co je Aspose.Slides?**
Aspose.Slides je knihovna tříd, která umožňuje vaší aplikaci provádět následující úlohy zpracování prezentací:

- Programování s objektním modelem **Presentation**.
- Vysoce kvalitní konverze mezi všemi populárními podporovanými formáty PowerPoint prezentací, včetně konverze do PDF, XPS a TIFF.
- Možnost generovat miniatury snímků v dobře známých formátech jako PNG, JPEG a BMP spolu s exportem snímků do SVG.
- Možnost vytvořit prezentace od nuly nebo kombinací jednoho či více dokumentů.
- Podpora přidávání animací, Ole rámců, tabulek, tvorby a správy grafů.
- Rozsáhlá kontrola pro správu formátování textu na úrovních TextFrames, Paragraphs a Portions.

Pro podrobnější informace o podporovaných funkcích navštivte [Funkce Aspose.Slides](/slides/cs/java/product-overview/).

## **Porovnejte Open XML SDK s Aspose.Slides**
{{% alert color="info" %}} 

Následující tabulka porovnává funkce Open XML SDK a Aspose.Slides.

{{% /alert %}} 

|**Funkce nebo kategorie**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Podporované formáty prezentací|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Konverze z PPT na PPTX |Ne|Ano|
|<p>Programování na vysoké úrovni s modelem objektu prezentačního dokumentu (DOM):</p><p>- Najít a nahradit text.</p><p>- Sestavit snímky v prezentacích.</p>|Ne|Ano|
|Podrobné programování s modelem objektu dokumentu, přístup k jednotlivým elementům a formátování jako TextHolders, TextFrames, Paragraphs a Portions.|Ano|Ano|
|Nízká úroveň přímého a úplného přístupu k podkladovým XML elementům a atributům, jako jsou identifikátory vztahů, identifikátory seznamů OOXML dokumentu.|Ano|Ne|
|<p>Vykreslování:</p><p>- Vykreslit prezentace do PDF, PDF poznámek, XPS, TIFF obrázků.</p><p>- Vykreslit miniatury snímků do PNG, JPEG, BMP, SVG a TIFF.</p><p>- Zadat rozlišení obrázku, kvalitu, kompresi a další možnosti.</p>|Ne|Ano |
|Podporované platformy|Windows, .NET|Windows, Linux,UNIX, MAC, Java, PHP, Mono|

## **Závěr**
{{% alert color="info" %}} 

Open XML SDK a Aspose.Slides nejsou přímou konkurencí, protože řeší zcela odlišné potřeby a publikum. Open XML SDK je knihovna tříd poskytující typově bezpečný způsob práce s OOXML dokumenty. Aspose.Slides je velmi užitečná knihovna pro zpracování prezentací, která poskytuje skvělou podporu pro téměř všechny soubory Microsoft PowerPoint.

Pokud potřebujete jen poměrně základní programovací operaci na PPTX dokumentu, může být Open XML SDK vhodnou volbou. S Open XML SDK budete poměrně pohodlně provádět jednoduché úkoly, jako je generování jednoduchého PPTX dokumentu nebo odstraňování komentářů, záhlaví/patická, extrakce obrázků a podobně. Některé úkoly lze dosáhnout pomocí Open XML SDK, ale ne pomocí Aspose.Slides. Například pokud potřebujete přímo přistupovat k XML elementům a atributům OOXML dokumentu, měli byste použít Open XML SDK. Pokud však potřebujete provádět složité operace na dokumentech, jako jsou některé z následujících úkolů, je pro vás nejlepší volbou Aspose.Slides:

- Podpora starších formátů PowerPointu kromě PPTX.
- Kopírování nebo klonování tvarů ve snímcích způsobem, který kombinuje objekty, styly a další formátování vhodným způsobem.
- Nahrazení formátovaného nebo neformátovaného textu.
- Aplikace animací a používání spojnic s tvary.
- Převod dokumentu do PDF, TIFF nebo XPS tak, aby výsledek odpovídal tomu, jak by jej převedl Microsoft PowerPoint.
- Vývoj .NET nebo Java aplikace v desktopových i webových prostředích.

{{% /alert %}}