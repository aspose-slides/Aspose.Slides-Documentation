---
title: Proč ne Open XML SDK
type: docs
weight: 120
url: /cs/java/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- porovnání
- objektový model prezentace
- konverze vysoké kvality
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Zjistěte, proč je Aspose.Slides lepší volbou než bezplatné Open XML SDK: porovnejte funkce, konverzi bez automatizace a širokou podporu pro PPT, PPTX a ODP."
---
## **Přehled**

Tento článek vysvětluje, kdy mohou vývojáři zvolit Open XML SDK nebo Aspose.Slides pro práci s prezentačními dokumenty. Popisuje Open XML SDK jako knihovnu pro manipulaci s balíčky OOXML a jejich podkladové XML prvky, zatímco Aspose.Slides je představen jako knihovna pro zpracování prezentací s vysoceúrovňovým objektovým modelem a podporou mnoha úkolů souvisejících s PowerPointem.

Článek porovnává obě možnosti podle podporovaných formátů, programového modelu, schopností renderování a tisku, podpory platforem a typických scénářů použití. Rovněž objasňuje, že Open XML SDK může být vhodný pro základní operace s PPTX nebo přímý přístup k OOXML prvkům, zatímco Aspose.Slides je vhodnější pro složité úkoly, jako je práce s více formáty PowerPointu, kopírování nebo klonování tvarů, nahrazování textu, aplikování animací a konverze prezentací do PDF, TIFF nebo XPS.

## **Co je Open XML SDK?**
Podle [Knihovny MSDN](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk) je Open XML SDK definováno jako:

Open XML SDK 2.0 zjednodušuje úkol manipulace s Open XML balíčky a podkladovými schématy Open XML uvnitř balíčku. Open XML SDK 2.0 zapouzdřuje mnoho běžných úkolů, které vývojáři provádějí na Open XML balíčcích, takže můžete provádět složité operace pomocí jen několika řádků kódu.

Dokumenty OOXML jsou v podstatě zipované XML soubory a Open XML SDK je sada tříd, která vám umožňuje pracovat s obsahem OOXML dokumentů typově bezpečným způsobem. To znamená, že místo rozbalení souboru pro extrakci XML, načtení tohoto XML do DOM stromu a přímé práce s XML elementy a atributy, Open XML SDK poskytuje třídy, které tuto činnost provádějí.

## **Co je Aspose.Slides?**
Aspose.Slides je knihovna tříd, která umožňuje vaší aplikaci provádět následující úkoly zpracování prezentací:

- Programování s objektovým modelem **Presentation**.
- Vysoce kvalitní konverze mezi všemi populárními podporovanými formáty PowerPoint prezentací, včetně konverze do PDF, XPS a TIFF.
- Možnost generovat miniatury snímků v dobře známých formátech, jako PNG, JPEG a BMP, spolu s exportem snímků do SVG.
- Možnost vytvářet prezentace od nuly nebo kombinovat jeden či více dokumentů.
- Podpora přidávání animací, Ole rámců, tabulek, tvorby a správy grafů.
- Rozsáhlá kontrola nad formátováním textu v TextFrames, odstavcích a úsecích.

Pro podrobnější informace o podporovaných funkcích navštivte [Funkce Aspose.Slides](/slides/cs/java/product-overview/).

## **Porovnání Open XML SDK a Aspose.Slides**
{{% alert color="primary" %}} 

Následující tabulka porovnává funkce Open XML SDK a Aspose.Slides.

{{% /alert %}} 

|**Funkce nebo kategorie funkcí**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Podporované formáty prezentací|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Konverze z PPT na PPTX|Ne|Ano|
|<p>Vysoceúrovňové programování s objektovým modelem dokumentu prezentace (DOM):</p><p>- Najít a nahradit text.</p><p>- Sestavit snímky v prezentacích.</p>|Ne|Ano|
|Podrobné programování s dokumentovým objektem, přístup k jednotlivým prvkům a formátování, jako jsou TextHolders, TextFrames, Paragraphs a Portions.|Ano|Ano|
|Nízkourovňový přímý a úplný přístup k podkladovým XML prvkům a atributům, jako jsou identifikátory vztahů, identifikátory seznamů OOXML dokumentu.|Ano|Ne|
|<p>Renderování:</p><p>- Renderovat prezentace do PDF, PDF poznámek, XPS, TIFF obrázků.</p><p>- Renderovat miniatury snímků do PNG, JPEG, BMP, SVG a TIFF.</p><p>- Specifikovat rozlišení obrazu, kvalitu, kompresi a další možnosti.</p>|Ne|Ano |
|Podporované platformy|Windows, .NET|Windows, Linux,UNIX, MAC, Java, PHP, Mono|

## **Závěr**
{{% alert color="primary" %}} 

Open XML SDK a Aspose.Slides nekonkurovat přímo, protože řeší poměrně odlišné potřeby a publika. Open XML SDK je knihovna tříd, která poskytuje typově silný způsob práce s OOXML dokumenty. Aspose.Slides je velmi užitečná knihovna pro zpracování prezentací, která poskytuje vynikající podporu téměř všech formátů souborů Microsoft PowerPoint.

Pokud potřebujete jen poměrně základní programovou operaci s PPTX dokumentem, může být Open XML SDK vhodnou volbou. S Open XML SDK budete pohodlně provádět jednoduché úkoly, jako je generování jednoduchého PPTX dokumentu nebo odstraňování komentářů, záhlaví/patiček, extrahování obrázků a další. Některé úkoly lze dosáhnout s Open XML SDK, ale nelze je realizovat s Aspose.Slides. Například pokud potřebujete přímý přístup k XML prvkům a atributům OOXML dokumentu, měli byste použít Open XML SDK. Naopak, pokud potřebujete provádět složité operace s dokumenty, jako jsou následující úkoly, je pro vás nejlepší volbou Aspose.Slides:

- Podpora starších formátů PowerPointu kromě PPTX.
- Kopírování nebo klonování tvarů ve snímcích způsobem, který kombinuje objekty, styly a další formátování vhodným způsobem.
- Nahrazení formátovaného nebo neformátovaného textu.
- Aplikace animací a použití spojnic s tvary.
- Konverze dokumentu do PDF, TIFF nebo XPS tak, aby výsledek vypadal přesně tak, jak by jej konvertoval Microsoft PowerPoint.
- Vývoj .NET nebo Java aplikace jak pro desktop, tak pro webová prostředí.

{{% /alert %}}