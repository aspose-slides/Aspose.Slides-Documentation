---
title: Proč ne Open XML SDK
type: docs
weight: 50
url: /cs/net/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- srovnání
- model objektu prezentace
- konverze vysoké kvality
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Zjistěte, proč je Aspose.Slides lepší volbou než bezplatné Open XML SDK: porovnejte funkce, konverzi bez automatizace a širokou podporu pro PPT, PPTX a ODP."
---
## **Přehled**

Tento článek vysvětluje, kdy si vývojáři mohou vybrat Open XML SDK nebo Aspose.Slides pro práci s prezentačními dokumenty. Popisuje Open XML SDK jako knihovnu pro manipulaci s OOXML balíčky a jejich podkladovými XML prvky, zatímco Aspose.Slides je představena jako knihovna pro zpracování prezentací s vysoce úrovňovým objektním modelem a podporou mnoha úloh souvisejících s PowerPoint.

Článek porovnává obě možnosti podle podporovaných formátů, programového modelu, schopností vykreslování a tisku, podpory platforem a běžných scénářů použití. Také objasňuje, že Open XML SDK může být vhodné pro základní operace s PPTX nebo přímý přístup k OOXML prvkům, zatímco Aspose.Slides je vhodnější pro složité úkoly s prezentacemi, jako práce s různými formáty PowerPoint, kopírování nebo klonování tvarů, nahrazování textu, aplikování animací a konverze prezentací do PDF, TIFF nebo XPS.

## **Co je Open XML SDK?**
Někdy se setkáme s otázkou: *Proč bychom měli používat produkty Aspose místo volného Open XML SDK?*  

Odpověď na tuto otázku najdeme snadno v rámci funkcí a vlastností.  

Podle [MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk) je Open XML SDK definováno takto:  

> "Open XML SDK 2.0 zjednodušuje úkol manipulace s Open XML balíčky a podkladovými schématy Open XML uvnitř balíčku. Open XML SDK 2.0 zapouzdřuje mnoho běžných úkolů, které vývojáři provádějí na Open XML balíčcích, takže můžete provádět složité operace pouze pomocí několika řádků kódu. OOXML dokumenty jsou v podstatě zkomprimované XML soubory a Open XML SDK je kolekce tříd, která umožňuje pracovat s obsahem OOXML dokumentů silně typizovaným způsobem. Místo rozbalení souboru pro extrakci XML, načítání tohoto XML do DOM stromu a přímé práce s XML prvky a atributy, Open XML SDK poskytuje třídy k tomu."

## **Co je Aspose.Slides?**
Aspose.Slides je knihovna tříd, která umožňuje aplikacím provádět následující úkoly zpracování prezentací:  

- Programování s objektním modelem prezentace.  
- Kvalitní konverze zahrnující všechny populární podporované formáty PowerPoint, včetně konverze do PDF, XPS, TIFF a tisku.  
- Generování miniatur snímků ve známých formátech jako PNG, JPEG a BMP spolu s exportem snímků do SVG.  
- Vytváření prezentací od nuly nebo kombinováním prvků z jednoho či více dokumentů.  
- Přidávání animací, OLE rámců, tabulek, vytváření a správa grafů.  
- Rozsáhlé řízení a správa formátování textu na úrovních TextFrames, Paragraphs a Portions.  

Pro více podrobností o dostupných funkcích navštivte stránku [Aspose.Slides Features](/slides/cs/net/product-overview/).

## **Porovnejte Open XML SDK s Aspose.Slides**
Tato tabulka porovnává schopnosti a funkce Open XML SDK s Aspose.Slides.

|**Funkce nebo kategorie funkcí**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Podporované formáty prezentací|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Konverze z PPT na PPTX|Ne|Ano|
|<p>Programování na vysoké úrovni s objektním modelem dokumentu prezentace (DOM): </p><p>- Vyhledávat a nahrazovat text.</p><p>- Skládat snímky v prezentacích.</p>|Ne|Ano|
|Detailní programování s dokumentovým objektním modelem; přístup k jednotlivým prvkům a formátování, jako jsou TextHolders, TextFrames, Paragraphs a Portions.|Ano|Ano|
|Celozraký přímý a úplný přístup na nízké úrovni k podkladovým XML prvkům a atributům, jako jsou identifikátory vztahů, identifikátory seznamů OOXML dokumentu.|Ano|Ne|
|<p>Vykreslování a tisk:</p><p>- Vykreslovat prezentace do PDF, PDF Notes, XPS, TIFF obrázků.</p><p>- Vytvářet miniatury snímků do PNG, JPEG, BMP, SVG a TIFF.</p><p>- Specifikovat rozlišení obrázku, kvalitu, kompresi a další možnosti.</p><p>- Tisknout prezentace pomocí .NET tiskové infrastruktury. Součást má vestavěnou metodu tisku k tisku prezentací tak, jak je zobrazena v Náhledu tisku v MS PowerPoint.</p>|Ne|Ano|
|Podporované platformy|Windows, .NET|Windows, Linux, Java, .NET, Mono|

## **Závěr**
Open XML SDK a Aspose.Slides nekonkuruji přímo, protože řeší podstatně odlišné potřeby a cílí na různé publikum.  

{{% alert color="primary" %}} 

Open XML SDK je knihovna tříd, která poskytuje silně typizovaný způsob práce s OOXML dokumenty, zatímco Aspose.Slides je neuvěřitelně užitečná knihovna pro zpracování prezentací, která nabízí vynikající podporu pro téměř všechny soubory Microsoft PowerPoint. 

{{% /alert %}} 

Pokud je váš workflow základní programová operace na PPTX dokumentu, pak může být Open XML SDK dobrá volba. S Open XML SDK byste měli být schopni provádět jednoduché úkoly, jako je generování jednoduchého PPTX dokumentu nebo odstraňování komentářů, záhlaví/patiček, extrahování obrázků a podobně. Některé úkoly lze provést pomocí Open XML SDK, ale nelze je provést pomocí Aspose.Slides. Například pokud potřebujete přímý přístup k XML prvkům a atributům OOXML dokumentu, měli byste použít Open XML SDK.  

Pokud potřebujete provádět složité úkoly na dokumentech—jako jsou úkoly v níže uvedeném seznamu—pak je pro vás nejlepší volbou Aspose.Slides.  

- Operace zahrnující starší formáty PowerPoint (a také PPTX).  
- Kopírování nebo klonování tvarů v rámci snímků způsobem, který kombinuje objekty, styly a další formátovací prvky vhodným způsobem.  
- Nahrazování formátovaného nebo neformátovaného textu.  
- Používání animací a používání konektorů s tvary.  
- Převod dokumentu do PDF, TIFF nebo XPS tak, aby výsledek vypadal jako při převodu v Microsoft PowerPoint.  
- Vývoj .NET nebo Java aplikace jak pro desktop, tak pro webová prostředí.