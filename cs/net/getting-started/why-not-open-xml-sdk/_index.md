---
title: Proč ne Open XML SDK
type: docs
weight: 180
url: /cs/net/why-not-open-xml-sdk/
aliases:
  - /net/slides-on-cloud-platforms/extracting-text/open-xml-sdk/
keywords:
- Open XML SDK
- porovnávání
- model objektu prezentace
- vysoce kvalitní konverze
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Zjistěte, proč je Aspose.Slides lepší volbou než bezplatné Open XML SDK: porovnejte funkce, konverzi bez nutnosti automatizace a širokou podporu formátů PPT, PPTX a ODP."
---
## **Přehled**

Tento článek vysvětluje, kdy by vývojáři mohli zvolit Open XML SDK nebo Aspose.Slides pro práci s prezentačními dokumenty. Popisuje Open XML SDK jako knihovnu pro manipulaci s balíčky OOXML a jejich podkladovými XML prvky, zatímco Aspose.Slides je představen jako knihovna pro zpracování prezentací s vysoce úrovňovým objektním modelem a podporou mnoha úloh souvisejících s PowerPointem.

Článek porovnává obě možnosti podle podporovaných formátů, programovacího modelu, vykreslování, podpory platforem a běžných scénářů použití. Také objasňuje, že Open XML SDK může být vhodný pro základní operace s PPTX nebo přímý přístup k OOXML prvkům, zatímco Aspose.Slides je vhodnější pro komplexní úlohy, jako je práce s více formáty PowerPointu, kopírování nebo klonování tvarů, nahrazování textu, aplikování animací a konverze prezentací do PDF, TIFF nebo XPS.

## **Co je Open XML SDK?**
Někdy dostáváme tuto otázku: *Proč bychom měli používat produkty Aspose místo volně dostupného Open XML SDK?*

Odpověď na tuto otázku najdeme snadno v termínech funkcí a schopností.

Podle [Knihovny MSDN](https://learn.microsoft.com/en-us/office/open-xml/open-xml-sdk) je Open XML SDK definováno takto:

> "Open XML SDK 2.0 zjednodušuje úkol manipulace s Open XML balíčky a podkladovými schématy Open XML uvnitř balíčku. Open XML SDK 2.0 zapouzdřuje mnoho běžných úloh, které vývojáři provádějí na Open XML balíčcích, takže můžete provádět složité operace pomocí několika řádků kódu. OOXML dokumenty jsou v podstatě zabalené XML soubory a Open XML SDK je sbírka tříd, která umožňuje pracovat s obsahem OOXML dokumentů silně typovaným způsobem. Místo rozbalení souboru za účelem extrakce XML, načtení XML do DOM stromu a přímé práce s XML prvky a atributy, Open XML SDK poskytuje třídy k provedení těchto operací."

## **Co je Aspose.Slides?**
Aspose.Slides je knihovna tříd, která umožňuje aplikacím provádět následující úlohy zpracování prezentací:

- Programování s objektním modelem prezentace.
- Vysoce kvalitní konverze zahrnující všechny populární podporované formáty PowerPointu, včetně konverze do PDF, XPS a TIFF.
- Generování miniatur snímků ve známých formátech, jako jsou PNG, JPEG a BMP, spolu s exportem snímků do SVG.
- Vytváření prezentací od nuly nebo kombinováním prvků z jednoho či více dokumentů.
- Přidávání animací, OLE rámců, tabulek, vytváření a správa grafů.
- Řízení (rozsáhlé řízení) a správa formátování textu na úrovních TextFrames, Paragraphs a Portions.

  Pro více podrobností o dostupných funkcích si prosím prohlédněte stránku [Funkce Aspose.Slides](/slides/cs/net/product-overview/).

## **Porovnání Open XML SDK s Aspose.Slides**
Tato tabulka porovnává schopnosti a funkce Open XML SDK s Aspose.Slides.

|**Funkce nebo kategorie funkcí**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Podporované formáty prezentací|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Převod z PPT na PPTX|No|Yes|
|<p>Programování na vysoké úrovni s modelem objektů dokumentu prezentace (DOM):</p><p>- Najít a nahradit texty.</p><p>- Sestavit snímky v prezentacích.</p>|No|Yes|
|Detailní programování s modelem objektu dokumentu; přístup k jednotlivým prvkům a formátování, jako jsou TextHolders, TextFrames, Paragraphs a Portions.|Yes|Yes|
|Nízká úroveň přímého a úplného přístupu k podkladovým XML prvkům a atributům, jako jsou identifikátory vztahů, identifikátory seznamů OOXML dokumentu.|Yes|No|
|<p>Vykreslování prezentací:</p><p>- Vykreslit prezentace do PDF, PDF Notes, XPS, TIFF obrázků.</p><p>- Vykreslit miniatury snímků do PNG, JPEG, BMP, SVG a TIFF.</p><p>- Zadat rozlišení obrazu, kvalitu, kompresi a další možnosti.</p>|No|Yes|
|Podporované platformy|Windows, .NET|Windows, Linux, Java, .NET, Mono|

## **Závěr**
Open XML SDK a Aspose.Slides nekonkurovat přímo, protože řeší podstatně odlišné potřeby a cílí na různé publikum.

{{% alert color="info" title="Note" %}}
Open XML SDK je knihovna tříd, která poskytuje silně typovaný způsob práce s OOXML dokumenty, zatímco Aspose.Slides je neuvěřitelně užitečná knihovna pro zpracování prezentací, která poskytuje vynikající podporu pro téměř všechny souborové formáty Microsoft PowerPoint.
{{% /alert %}}

Pokud je váš pracovní postup základní programovací operací na PPTX dokumentu, pak může být Open XML SDK dobrá volba. S Open XML SDK byste měli být schopni pohodlně provádět jednoduché úkoly, jako je generování jednoduchého PPTX dokumentu nebo odstraňování komentářů, záhlaví/patiček, extrakce obrázků a podobně. Některé úkoly lze provést s Open XML SDK, ale ne s Aspose.Slides. Například pokud potřebujete přímo přistupovat k XML prvkům a atributům OOXML dokumentu, měli byste použít Open XML SDK.

Pokud potřebujete provádět složité úkoly na dokumentech—jako jsou úkoly v níže uvedeném seznamu—pak je Aspose.Slides vaší nejlepší volbou.

- Operace zahrnující starší formáty PowerPointu (a také PPTX).
- Kopírování nebo klonování tvarů v rámci snímků způsobem, který kombinuje objekty, styly a další formátovací prvky vhodným způsobem.
- Nahrazování formátovaného nebo neformátovaného textu.
- Aplikování animací a používání konektorů s tvary.
- Konverze dokumentu do PDF, TIFF nebo XPS tak, aby výsledek vypadal, jako by jej konvertoval Microsoft PowerPoint.
- Vývoj .NET nebo Java aplikace jak pro desktop, tak pro webové prostředí.