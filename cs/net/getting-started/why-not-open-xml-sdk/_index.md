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
- model objektu prezentace
- vysoce kvalitní konverze
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Zjistěte, proč je Aspose.Slides lepší volbou než bezplatné Open XML SDK: porovnejte funkce, konverzi bez automatizace a širokou podporu pro PPT, PPTX a ODP."
---
## **Přehled**

Tento článek vysvětluje, kdy vývojáři mohou zvolit Open XML SDK nebo Aspose.Slides pro práci s prezentačními dokumenty. Popisuje Open XML SDK jako knihovnu pro manipulaci s balíčky OOXML a jejich podkladovými XML elementy, zatímco Aspose.Slides je představena jako knihovna pro zpracování prezentací s vysoceúrovňovým objektovým modelem a podporou mnoha úkolů souvisejících s PowerPointem.

Článek porovnává obě možnosti podle podporovaných formátů, programového modelu, možností renderování a tisku, podpory platforem a běžných případů použití. Také objasňuje, že Open XML SDK může být vhodné pro základní operace s PPTX nebo přímý přístup k OOXML elementům, zatímco Aspose.Slides je vhodnější pro složité úkoly s prezentacemi, jako je práce s více formáty PowerPointu, kopírování nebo klonování tvarů, nahrazování textu, aplikování animací a konverze prezentací do PDF, TIFF nebo XPS.

## **Co je Open XML SDK?**
Občas dostáváme tuto otázku: *Proč bychom měli používat produkty Aspose místo volně dostupného Open XML SDK?* 

Odpovědět na tuto otázku najdeme snadno z hlediska funkcí a vlastností. 

Podle [MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk) je Open XML SDK definováno takto: 

> "The Open XML SDK 2.0 simplifies the task of manipulating Open XML packages and the underlying Open XML schema elements within a package. The Open XML SDK 2.0 encapsulates many common tasks that developers perform on Open XML packages, so that you can perform complex operations with just a few lines of code. OOXML documents are essentially zipped XML files and Open XML SDK is a collection of classes that allows you to work with the content of OOXML documents in a strongly-typed way. That is instead of unzipping a file to extract XML, loading that XML into a DOM tree, and working with XML elements and attributes directly, Open XML SDK provides classes to do that."

## **Co je Aspose.Slides?**
Aspose.Slides je knihovna tříd, která umožňuje aplikacím provádět následující úkoly zpracování prezentací: 

- Programování s objektovým modelem prezentace.  
- Vysoce kvalitní konverze zahrnující všechny populární podporované formáty PowerPoint prezentací, včetně konverze do PDF, XPS, TIFF a tisku.  
- Generování náhledů snímků v běžně používaných formátech jako PNG, JPEG a BMP spolu s exportem snímků do SVG.  
- Vytváření prezentací od nuly nebo kombinováním prvků z jednoho či více dokumentů.  
- Přidávání animací, OLE rámců, tabulek, vytváření a správa grafů.  
- Ovládání (rozsáhlé řízení) a správa formátování textu na úrovních TextFrames, Paragraphs a Portions.  

Pro více podrobností o dostupných funkcích navštivte stránku [Aspose.Slides Features](/slides/cs/net/product-overview/).

## **Porovnat Open XML SDK s Aspose.Slides**
Tato tabulka porovnává možnosti a funkce Open XML SDK s Aspose.Slides.

|**Funkce nebo kategorie funkcí**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Podporované formáty prezentací|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Konverze z PPT na PPTX|Ne|Ano|
|<p>Programování na vysoké úrovni s objektem Presentation Document Object Model (DOM): </p><p>- Najděte a nahraďte texty.</p><p>- Sestavujte snímky v prezentacích.</p>|Ne|Ano|
|Detailní programování s objektovým modelem dokumentu; přístup k jednotlivým elementům a formátování, jako jsou TextHolders, TextFrames, Paragraphs a Portions.|Ano|Ano|
|Nízká úroveň přímého a úplného přístupu k podkladovým XML elementům a atributům, jako jsou identifikátory vztahů, seznamové identifikátory OOXML dokumentu.|Ano|Ne|
|<p>Renderování a tisk:</p><p>- Renderování prezentací do PDF, PDF Notes, XPS, TIFF obrázků.</p><p>- Renderování náhledů snímků do PNG, JPEG, BMP, SVG a TIFF.</p><p>- Specifikace rozlišení obrázku, kvality, komprese a dalších možností.</p><p>- Tisk prezentací pomocí .NET tiskové infrastruktury. Komponenta má vestavěnou metodu tisku pro tisk prezentací tak, jak jsou zobrazeny v Náhledu tisku MS PowerPointu.</p>|Ne|Ano|
|Podporované platformy|Windows, .NET|Windows, Linux, Java, .NET, Mono|

## **Závěr**
Open XML SDK a Aspose.Slides přímo nekonkurovat, protože řeší podstatně odlišné potřeby a cílí na různé publikum. 

{{% alert color="primary" %}} 
Open XML SDK je knihovna tříd, která poskytuje silně typovaný způsob práce s OOXML dokumenty, zatímco Aspose.Slides je nesmírně užitečná knihovna pro zpracování prezentací, která poskytuje vynikající podporu pro téměř všechny souborové formáty Microsoft PowerPoint. 
{{% /alert %}} 

Pokud je váš pracovní postup základní programová operace s PPTX dokumentem, může být Open XML SDK dobrá volba. S Open XML SDK byste měli být schopni provádět jednoduché úkoly, jako je generování jednoduchého PPTX dokumentu nebo odstraňování komentářů, záhlaví/patiček, extrakce obrázků a podobně. Některé úkoly lze provést pomocí Open XML SDK, ale nelze je provést pomocí Aspose.Slides. Například pokud potřebujete přímý přístup k XML elementům a atributům OOXML dokumentu, měli byste použít Open XML SDK. 

Pokud potřebujete provádět složité úkoly na dokumentech — jako jsou úkoly v následujícím seznamu — pak je Aspose.Slides vaší nejlepší volbou. 

- Operace zahrnující starší formáty PowerPointu (a také PPTX).  
- Kopírování nebo klonování tvarů ve snímcích způsobem, který kombinuje objekty, styly a další formátovací prvky vhodným způsobem.  
- Nahrazování formátovaného nebo neformátovaného textu.  
- Aplikování animací a používání konektorů s tvary.  
- Konverze dokumentu do PDF, TIFF nebo XPS tak, aby výsledek vypadal, jako kdyby konverzi provedl Microsoft PowerPoint.  
- Vývoj .NET nebo Java aplikace jak pro desktop, tak pro webová prostředí.