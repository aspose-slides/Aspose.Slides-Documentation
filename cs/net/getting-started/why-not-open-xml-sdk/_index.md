---
title: Proč ne Open XML SDK
type: docs
weight: 50
url: /cs/net/why-not-open-xml-sdk/
aliases:
  - /net/slides-on-cloud-platforms/extracting-text/open-xml-sdk/
keywords:
- Open XML SDK
- porovnání
- objektový model prezentace
- vysoce kvalitní konverze
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Zjistěte, proč je Aspose.Slides lepší volba než bezplatné Open XML SDK: porovnejte funkce, konverzi bez automatizace a širokou podporu pro PPT, PPTX a ODP."
---
## **Přehled**

Tento článek vysvětluje, kdy mohou vývojáři zvolit Open XML SDK nebo Aspose.Slides pro práci s prezentačními dokumenty. Popisuje Open XML SDK jako knihovnu pro manipulaci s balíčky OOXML a jejich podkladovými XML prvky, zatímco Aspose.Slides je představen jako knihovna pro zpracování prezentací s vysoce úrovňovým objektovým modelem a podporou mnoha úloh souvisejících s PowerPointem.

Článek porovnává obě možnosti podle podporovaných formátů, programovacího modelu, schopností renderování a tisku, podpory platform a běžných scénářů použití. Také objasňuje, že Open XML SDK může být vhodný pro základní operace s PPTX nebo přímý přístup k OOXML prvkům, zatímco Aspose.Slides je vhodnější pro složité úlohy, jako je práce s více formáty PowerPointu, kopírování nebo klonování tvarů, nahrazování textu, aplikování animací a konverze prezentací do PDF, TIFF nebo XPS.

## **Co je Open XML SDK?**
Někdy se setkáváme s otázkou: *Proč bychom měli používat produkty Aspose místo bezplatného Open XML SDK?*  

Odpověď na tuto otázku je snadná, pokud se zaměříme na funkce a možnosti.  

Podle [MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk) je Open XML SDK definováno takto:  

> „Open XML SDK 2.0 zjednodušuje úlohu manipulace s Open XML balíčky a podkladovými elementy schématu Open XML uvnitř balíčku. Open XML SDK 2.0 zapouzdřuje mnoho běžných úkolů, které vývojáři provádějí na Open XML balíčcích, takže můžete provádět složité operace pomocí několika řádků kódu. OOXML dokumenty jsou v podstatě zkomprimované XML soubory a Open XML SDK je sbírka tříd, která vám umožňuje pracovat s obsahem OOXML dokumentů silně typovaným způsobem. Místo rozbalení souboru k extrakci XML, načtení XML do DOM stromu a přímé práce s XML elementy a atributy poskytuje Open XML SDK třídy, které to zařídit."

## **Co je Aspose.Slides?**
Aspose.Slides je knihovna tříd, která umožňuje aplikacím provádět následující úlohy zpracování prezentací:  

- Programování s objektovým modelem prezentace.  
- Vysoce kvalitní konverze zahrnující všechny populární podporované formáty PowerPointu, včetně konverze do PDF, XPS, TIFF a tisku.  
- Generování miniatur snímků v dobře známých formátech jako PNG, JPEG a BMP spolu s exportem snímků do SVG.  
- Vytváření prezentací od nuly nebo kombinací prvků z jednoho či více dokumentů.  
- Přidávání animací, OLE rámců, tabulek, tvorba a správa grafů.  
- Rozsáhlé řízení a správa formátování textu na úrovních TextFrames, Paragraphs a Portions.  

Pro více podrobností o dostupných funkcích navštivte stránku [Aspose.Slides Features](/slides/cs/net/product-overview/).

## **Porovnání Open XML SDK s Aspose.Slides**
Tabulka porovnává schopnosti a funkce Open XML SDK s Aspose.Slides.

|**Funkce nebo Kategorizace Funkcí**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Podporované formáty prezentací|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Konverze z PPT na PPTX|No|Yes|
|<p>Programování na vysoké úrovni s Presentation Document Object Model (DOM): </p><p>- Najít a nahradit texty.</p><p>- Sestavit snímky v prezentacích.</p>|No|Yes|
|Detailní programování s objektovým modelem dokumentu; přístup k jednotlivým prvkům a formátování, jako jsou TextHolders, TextFrames, Paragraphs a Portions.|Yes|Yes|
|Nízkourovňový přímý a úplný přístup k podkladovým XML elementům a atributům, jako jsou identifikátory vztahů, identifikátory seznamů OOXML dokumentu.|Yes|No|
|<p>Renderování a Tisk:</p><p>- Renderovat prezentace do PDF, PDF Notes, XPS, TIFF obrázků.</p><p>- Renderovat miniatury snímků do PNG, JPEG, BMP, SVG a TIFF.</p><p>- Zadávat rozlišení obrázku, kvalitu, kompresi a další volby.</p><p>- Tisknout prezentace pomocí .NET tiskové infrastruktury. Komponenta má vestavěnou metodu tisku, která tiskne prezentace tak, jak jsou zobrazeny v Náhledu tisku MS PowerPoint.</p>|No|Yes|
|Podporované platformy|Windows, .NET|Windows, Linux, Java, .NET, Mono|

## **Závěr**
Open XML SDK a Aspose.Slides přímo nekonkuruje, protože řeší podstatně odlišné potřeby a cílí na různé publikum.  

{{% alert color="info" %}}  

Open XML SDK je knihovna tříd, která poskytuje silně typovaný způsob práce s OOXML dokumenty, zatímco Aspose.Slides je mimořádně užitečná knihovna pro zpracování prezentací, která poskytuje skvělou podporu pro téměř všechny souborové formáty Microsoft PowerPoint.  

{{% /alert %}}  

Pokud je váš pracovní postup základní programovací operací na PPTX dokumentu, může být Open XML SDK vhodnou volbou. S Open XML SDK byste měli být schopni provádět jednoduché úkoly, jako je generování jednoduchého PPTX dokumentu nebo odstraňování komentářů, hlaviček/patiček, extrahování obrázků a podobně. Některé úkoly lze provést pomocí Open XML SDK, ale nelze je provést pomocí Aspose.Slides. Například pokud potřebujete přímo přistupovat k XML elementům a atributům OOXML dokumentu, měli byste použít Open XML SDK.  

Pokud potřebujete provádět složité úkoly na dokumentech – například úkoly uvedené níže – je Aspose.Slides nejlepší volbou.  

- Operace zahrnující starší formáty PowerPointu (a také PPTX).  
- Kopírování nebo klonování tvarů ve snímcích takovým způsobem, který kombinuje objekty, styly a další formátovací prvky vhodným způsobem.  
- Nahrazování formátovaného nebo neformátovaného textu.  
- Aplikování animací a používání spojnic s tvary.  
- Konverze dokumentu do PDF, TIFF nebo XPS tak, aby výsledek vypadal, jako kdyby jej převáděl Microsoft PowerPoint.  
- Vývoj .NET nebo Java aplikací jak pro desktop, tak pro webová prostředí.