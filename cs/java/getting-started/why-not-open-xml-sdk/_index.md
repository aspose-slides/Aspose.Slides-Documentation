---
title: Proč ne Open XML SDK
type: docs
weight: 120
url: /cs/java/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- porovnání
- model objektu prezentace
- konverze vysoké kvality
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Zjistěte, proč je Aspose.Slides lepší volbou než bezplatný Open XML SDK: porovnejte funkce, konverzi bez automatizace a širokou podporu pro PPT, PPTX a ODP."
---
## **Přehled**

Tento článek vysvětluje, kdy mohou vývojáři zvolit Open XML SDK nebo Aspose.Slides pro práci s prezentačními dokumenty. Popisuje Open XML SDK jako knihovnu pro manipulaci s balíčky OOXML a jejich podkladovými XML prvky, zatímco Aspose.Slides je představen jako knihovna pro zpracování prezentací s vysoceúrovňovým objektovým modelem a podporou mnoha úloh souvisejících s PowerPointem.

Článek porovnává obě možnosti podle podporovaných formátů, programovacího modelu, schopností vykreslování a tisku, podpory platforem a běžných scénářů použití. Také objasňuje, že Open XML SDK může být vhodný pro základní operace s PPTX nebo přímý přístup k OOXML prvkům, zatímco Aspose.Slides je vhodnější pro složité úlohy, jako je práce s více formáty PowerPointu, kopírování nebo klonování tvarů, nahrazování textu, aplikování animací a převod prezentací do PDF, TIFF nebo XPS.

## **Co je Open XML SDK?**
Podle [Knihovna MSDN](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk) je Open XML SDK definován jako:

Open XML SDK 2.0 zjednodušuje úlohu manipulace s balíčky Open XML a podkladovými schématy Open XML uvnitř balíčku. Open XML SDK 2.0 zapouzdřuje mnoho běžných úloh, které vývojáři provádějí na balíčcích Open XML, takže můžete provádět složité operace pomocí jen několika řádků kódu.

Dokumenty OOXML jsou v podstatě zkomprimované XML soubory a Open XML SDK je kolekce tříd, které umožňují pracovat s obsahem dokumentů OOXML typově zabezpečeným způsobem. To znamená, že místo rozbalení souboru k extrahování XML, načtení XML do DOM stromu a přímé práce s XML elementy a atributy, Open XML SDK poskytuje třídy, které to provádějí.

## **Co je Aspose.Slides?**
Aspose.Slides je knihovna tříd, která umožňuje vaší aplikaci provádět následující úlohy zpracování prezentací:

- Programování s objektním modelem **Presentation**.
- Vysoce kvalitní konverze mezi všemi populárními podporovanými formáty PowerPointu, včetně konverze do PDF, XPS a TIFF.
- Schopnost generovat miniatury snímků ve známých formátech, jako jsou PNG, JPEG a BMP, spolu s exportem snímků do SVG.
- Schopnost vytvářet prezentace od nuly nebo kombinovat z jednoho či více dokumentů.
- Podpora přidávání animací, Ole rámců, tabulek, tvorby a správy grafů.
- Rozsáhlá kontrola nad formátováním textu v TextFrames, odstavcích a částech.

Pro podrobnosti o podporovaných funkcích navštivte [Funkce Aspose.Slides](/slides/cs/java/product-overview/).

## **Porovnejte Open XML SDK s Aspose.Slides**
{{% alert color="info" %}} 

Následující tabulka porovnává funkce Open XML SDK a Aspose.Slides.

{{% /alert %}} 

|**Funkce nebo kategorie funkcí**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Podporované formáty prezentací|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Konverze z PPT na PPTX|Ne|Ano|
|<p>Programování na vysoké úrovni s objektním modelem dokumentu prezentace (DOM):</p><p>- Najít a nahradit text.</p><p>- Sestavit snímky v prezentacích.</p>|Ne|Ano|
|Detailní programování s objektním modelem dokumentu, přístup k jednotlivým prvkům a formátování, jako jsou TextHolders, TextFrames, Paragraphs a Portions.|Ano|Ano|
|Nízká úroveň přímého a úplného přístupu k podkladovým XML prvkům a atributům, jako jsou identifikátory vztahů, identifikátory seznamů OOXML dokumentu.|Ano|Ne|
|<p>Vykreslování:</p><p>- Vykreslovat prezentace do PDF, PDF poznámek, XPS, TIFF obrázků.</p><p>- Vytvářet miniatury snímků do PNG, JPEG, BMP, SVG a TIFF.</p><p>- Specifikovat rozlišení obrazu, kvalitu, kompresi a další možnosti.</p>|Ne|Ano|
|Podporované platformy|Windows, .NET|Windows, Linux,UNIX, MAC, Java, PHP, Mono|

## **Závěr**
{{% alert color="info" %}} 

Open XML SDK a Aspose.Slides nejsou přímou konkurencí, protože řeší zcela odlišné potřeby a publika. Open XML SDK je knihovna tříd, která poskytuje typově zabezpečený způsob práce s OOXML dokumenty. Aspose.Slides je velmi užitečná knihovna pro zpracování prezentací, která poskytuje vynikající podporu téměř pro všechny souborové formáty Microsoft PowerPoint.

Pokud potřebujete pouze poměrně základní programovou operaci s dokumentem PPTX, může být Open XML SDK vhodnou volbou. S Open XML SDK budete poměrně pohodlně provádět jednoduché úkoly, jako je generování jednoduchého PPTX dokumentu nebo odstraňování komentářů, záhlaví/patiček, extrakce obrázků a podobně. Některé úkoly lze dosáhnout pomocí Open XML SDK, ale ne pomocí Aspose.Slides. Například pokud potřebujete přímo přistupovat k XML prvkům a atributům OOXML dokumentu, měli byste použít Open XML SDK. Pokud však potřebujete provádět složité operace na dokumentech, jako jsou následující úlohy, je pro vás nejlepší volbou Aspose.Slides:

- Podpora starších formátů PowerPointu kromě PPTX.
- Kopírování nebo klonování tvarů ve snímcích způsobem, který kombinuje objekty, styly a další formátování vhodným způsobem.
- Nahrazení formátovaného nebo neformátovaného textu.
- Aplikování animací a použití propojek s tvary.
- Převod dokumentu do PDF, TIFF nebo XPS tak, aby vypadal přesně tak, jak by jej převedl Microsoft PowerPoint.
- Vývoj .NET nebo Java aplikace jak pro desktop, tak pro webová prostředí.

{{% /alert %}}