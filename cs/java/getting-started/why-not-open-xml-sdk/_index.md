---
title: Proč ne Open XML SDK
type: docs
weight: 180
url: /cs/java/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- porovnání
- objektový model prezentace
- vysoce kvalitní konverze
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Zjistěte, proč je Aspose.Slides lepší volbou než zdarma dostupný Open XML SDK: porovnejte funkce, konverzi bez automatizace a širokou podporu pro PPT, PPTX a ODP."
---
## **Přehled**

Tento článek vysvětluje, kdy by si vývojáři mohli vybrat Open XML SDK nebo Aspose.Slides pro práci s prezentačními dokumenty. Popisuje Open XML SDK jako knihovnu pro manipulaci s OOXML balíčky a jejich podkladovými XML elementy, zatímco Aspose.Slides je představen jako knihovna pro zpracování prezentací s vysoce úrovňovým objektovým modelem a podporou mnoha úloh souvisejících s PowerPointem.

Článek porovnává obě možnosti podle podporovaných formátů, programovacího modelu, vykreslování, podpory platforem a běžných případů použití. Také objasňuje, že Open XML SDK může být vhodné pro základní operace s PPTX nebo přímý přístup k OOXML elementům, zatímco Aspose.Slides je vhodnější pro složité prezentační úlohy, jako je práce s více formáty PowerPointu, kopírování nebo klonování tvarů, nahrazování textu, aplikování animací a převod prezentací do PDF, TIFF nebo XPS.

## **Co je Open XML SDK?**
Podle [MSDN Library](https://learn.microsoft.com/en-us/office/open-xml/open-xml-sdk) je Open XML SDK definováno takto:

Open XML SDK 2.0 zjednodušuje úlohu manipulace s Open XML balíčky a podkladovými Open XML schématy uvnitř balíčku. Open XML SDK 2.0 zapouzdřuje mnoho běžných úloh, které vývojáři provádějí na Open XML balíčcích, takže můžete provádět složité operace pomocí jen několika řádků kódu.

Dokumenty OOXML jsou v podstatě zipované XML soubory a Open XML SDK je kolekce tříd, která vám umožňuje pracovat s obsahem OOXML dokumentů typově bezpečným způsobem. To znamená, že místo rozbalení souboru pro extrakci XML, načtení tohoto XML do DOM stromu a přímé práce s XML elementy a atributy, Open XML SDK poskytuje třídy, které to provádějí.

## **Co je Aspose.Slides?**
Aspose.Slides je knihovna tříd, která umožňuje vaší aplikaci provádět následující úlohy zpracování prezentací:

- Programování s objektovým modelem **Presentation**.
- Vysoce kvalitní konverze mezi všemi populárními podporovanými formáty PowerPoint prezentací, včetně konverze do PDF, XPS a TIFF.
- Možnost generovat náhledy snímků v dobře známých formátech jako PNG, JPEG a BMP spolu s exportem snímku do SVG.
- Možnost vytvářet prezentace od nuly nebo kombinovat z jednoho či více dokumentů.
- Podpora přidávání animací, Ole rámců, tabulek, vytváření a správy grafů.
- Rozsáhlá kontrola nad formátováním textu v TextFrames, odstavcích a částech.

Pro více informací o podporovaných funkcích navštivte [Funkce Aspose.Slides](/slides/cs/java/product-overview/).

## **Srovnání Open XML SDK a Aspose.Slides**
{{% alert color="info" title="Note" %}}

The following table compares Open XML SDK and Aspose.Slides features.

{{% /alert %}}

|**Vlastnost nebo kategorie vlastností**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Podporované formáty prezentací|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Konverze z PPT na PPTX|Ne|Ano|
|<p>Programování na vysoké úrovni s objektním modelem dokumentu prezentace (DOM):</p><p>- Najít a nahradit text.</p><p>- Sestavit snímky v prezentacích.</p>|Ne|Ano|
|Podrobné programování s dokumentovým objektem modelu, přístup k jednotlivým elementům a formátování jako TextHolders, TextFrames, Paragraphs a Portions.|Ano|Ano|
|Nízká úroveň přímého a úplného přístupu k podkladovým XML elementům a atributům, jako jsou identifikátory vztahů, identifikátory seznamů OOXML dokumentu.|Ano|Ne|
|<p>Vykreslování:</p><p>- Vykreslit prezentace do PDF, PDF Notes, XPS, TIFF obrázků.</p><p>- Vykreslit náhledy snímků do PNG, JPEG, BMP, SVG a TIFF.</p><p>- Specifikovat rozlišení obrazu, kvalitu, kompresi a další možnosti.</p>|Ne|Ano |
|Podporované platformy|Windows, .NET|Windows, Linux,UNIX, MAC, Java, PHP, Mono|

## **Závěr**
{{% alert color="info" title="Note" %}}

Open XML SDK a Aspose.Slides nekonkurují přímo, protože řeší zcela odlišné potřeby a publikum. Open XML SDK je knihovna tříd poskytující typově silný způsob práce s OOXML dokumenty. Aspose.Slides je velmi užitečná knihovna pro zpracování prezentací, která poskytuje vynikající podporu téměř všech formátů souborů Microsoft PowerPoint.

Pokud potřebujete pouze poměrně jednoduchou programovou operaci na PPTX dokumentu, může být Open XML SDK vhodnou volbou. S Open XML SDK budete poměrně pohodlně provádět jednoduché úkoly, jako je generování jednoduchého PPTX dokumentu nebo odstraňování komentářů, záhlaví/patič, extrahování obrázků a podobně. Některé úkoly lze dosáhnout pomocí Open XML SDK, ale nelze je dosáhnout pomocí Aspose.Slides. Například pokud potřebujete přímo přistupovat k XML elementům a atributům OOXML dokumentu, měli byste použít Open XML SDK. Nicméně pokud potřebujete provádět složité operace na dokumentech, jako jsou některé z následujících úkolů, je použití Aspose.Slides nejlepší volbou:

- Podpora starších formátů PowerPointu kromě PPTX.
- Kopírování nebo klonování tvarů ve snímcích způsobem, který kombinuje objekty, styly a další formátování vhodným způsobem.
- Nahrazování formátovaného nebo neformátovaného textu.
- Aplikace animací a používání konektorů s tvary.
- Konverze dokumentu do PDF, TIFF nebo XPS tak, aby výsledek vypadal přesně jako konverze v Microsoft PowerPoint.
- Vývoj .NET nebo Java aplikace jak pro desktop, tak pro webová prostředí.

{{% /alert %}}