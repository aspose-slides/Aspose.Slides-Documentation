---
title: Proč ne Open XML SDK
type: docs
weight: 50
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
description: "Zjistěte, proč je Aspose.Slides lepší volbou než bezplatný Open XML SDK: porovnejte funkce, konverzi bez automatizace a širokou podporu pro PPT, PPTX a ODP."
---
## **Přehled**

Tento článek vysvětluje, kdy si vývojáři mohou vybrat Open XML SDK nebo Aspose.Slides pro práci s prezentačními dokumenty. Popisuje Open XML SDK jako knihovnu pro manipulaci s balíčky OOXML a jejich podkladovými XML elementy, zatímco Aspose.Slides je představen jako knihovna pro zpracování prezentací s objektovým modelem vysoké úrovně a podporou mnoha úkolů souvisejících s PowerPointem.

Článek porovnává obě možnosti podle podporovaných formátů, programovacího modelu, renderování, podpory platforem a běžných scénářů použití. Rovněž objasňuje, že Open XML SDK může být vhodný pro základní operace s PPTX nebo přímý přístup k OOXML elementům, zatímco Aspose.Slides je vhodnější pro složité úkoly s prezentacemi, jako je práce s více formáty PowerPointu, kopírování nebo klonování tvarů, nahrazování textu, aplikování animací a převod prezentací do PDF, TIFF nebo XPS.

## **Co je Open XML SDK?**
Někdy dostaneme tuto otázku: *Proč bychom měli používat produkty Aspose místo bezplatného Open XML SDK?* 

Odpověď na tuto otázku najdeme snadno, pokud se zaměříme na funkce a vlastnosti. 

Podle [Knihovny MSDN](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk) je Open XML SDK definováno takto: 

> "Open XML SDK 2.0 zjednodušuje úkol manipulace s balíčky Open XML a podkladovými schématy Open XML v rámci balíčku. Open XML SDK 2.0 zapouzdřuje mnoho běžných úkolů, které vývojáři provádějí na balíčcích Open XML, takže můžete provádět složité operace pomocí jen několika řádků kódu. Dokumenty OOXML jsou v podstatě zabalené XML soubory a Open XML SDK je sbírka tříd, které vám umožňují pracovat s obsahem OOXML dokumentů silně typizovaným způsobem. Namísto rozbalení souboru k extrakci XML, načtení XML do DOM stromu a přímé práce s XML elementy a atributy, Open XML SDK poskytuje třídy, které to za vás udělají."

## **Co je Aspose.Slides?**
Aspose.Slides je knihovna tříd, která umožňuje aplikacím provádět následující úkoly zpracování prezentací: 

- Programování s objektovým modelem prezentace.  
- Vysoce kvalitní konverze zahrnující všechny populární podporované formáty PowerPoint prezentací, včetně konverze do PDF, XPS a TIFF.  
- Generování náhledových snímků ve známých formátech jako PNG, JPEG a BMP spolu s exportem snímků do SVG.  
- Vytváření prezentací od začátku nebo kombinováním prvků z jednoho či více dokumentů.  
- Přidávání animací, OLE rámců, tabulek, tvorba a správa grafů.  
- Rozsáhlé řízení a správa formátování textu na úrovních TextFrames, Paragraphs a Portions.  

  Pro více informací o dostupných funkcích si prosím přečtěte stránku [Funkce Aspose.Slides](/slides/cs/net/product-overview/).

## **Srovnání Open XML SDK s Aspose.Slides**
Tato tabulka porovnává schopnosti a funkce Open XML SDK s Aspose.Slides.

|**Funkce nebo kategorie funkcí**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Podporované formáty prezentací|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Konverze z PPT na PPTX|Ne|Ano|
|<p>Programování na vysoké úrovni s objektovým modelem dokumentu prezentace (DOM): </p><p>- Najít a nahradit texty.</p><p>- Sestavit snímky v prezentacích.</p>|Ne|Ano|
|Detailní programování s objektovým modelem dokumentu; přístup k jednotlivým elementům a formátování, jako jsou TextHolders, TextFrames, Paragraphs a Portions.|Ano|Ano|
|Nízká úroveň přímého a úplného přístupu k podkladovým XML elementům a atributům, jako jsou identifikátory vztahů, identifikátory seznamů OOXML dokumentu.|Ano|Ne|
|<p>Renderování prezentací:</p><p>- Renderovat prezentace do PDF, PDF Notes, XPS, TIFF obrázků.</p><p>- Renderovat náhledy snímků do PNG, JPEG, BMP, SVG a TIFF.</p><p>- Specifikovat rozlišení obrázku, kvalitu, kompresi a další možnosti.</p>|Ne|Ano|
|Podporované platformy|Windows, .NET|Windows, Linux, Java, .NET, Mono|

## **Závěr**
Open XML SDK a Aspose.Slides přímo nekonkurují, protože řeší podstatně odlišné potřeby a cílí na různé publikum. 

{{% alert color="info" %}} 

Open XML SDK je knihovna tříd, která poskytuje silně typizovaný způsob práce s OOXML dokumenty, zatímco Aspose.Slides je neuvěřitelně užitečná knihovna pro zpracování prezentací, která poskytuje skvělou podporu pro téměř všechny souborové formáty Microsoft PowerPoint. 

{{% /alert %}} 

Pokud je váš pracovní tok základní programová operace na PPTX dokumentu, pak může být Open XML SDK dobrou volbou. S Open XML SDK byste měli být schopni provádět jednoduché úkoly, jako je generování jednoduchého PPTX dokumentu nebo odstraňování komentářů, záhlaví/patiček, extrakce obrázků a podobně. Některé úkoly lze provést s Open XML SDK, ale ne s Aspose.Slides. Například pokud potřebujete přímo přistupovat k XML elementům a atributům OOXML dokumentu, měli byste použít Open XML SDK. 

Pokud potřebujete vykonávat složité úkoly na dokumentech—jako jsou úkoly uvedené níže—pak je Aspose.Slides vaší nejlepší volbou. 

- Operace zahrnující starší formáty PowerPointu (a také PPTX).  
- Kopírování nebo klonování tvarů v rámci snímků způsobem, který kombinuje objekty, styly a další formátovací prvky vhodným způsobem.  
- Nahrazování formátovaného nebo neformátovaného textu.  
- Aplikování animací a používání konektorů s tvary.  
- Konverze dokumentu do PDF, TIFF nebo XPS tak, aby výsledek vypadal, jako kdyby ho převáděl Microsoft PowerPoint.  
- Vývoj .NET nebo Java aplikace jak pro desktop, tak pro webová prostředí.