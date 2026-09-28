---
title: Přehled funkcí
type: docs
weight: 94
url: /cs/net/features-overview/
keywords:
- funkce
- podporované platformy
- formáty souborů
- konverze
- vykreslování
- obsah prezentace
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Zkontrolujte, co Aspose.Slides pro .NET zahrnuje, než jej budete hodnotit: podporované platformy, formáty souborů, vykreslování snímků a obsah, který můžete vytvářet a upravovat."
---
## **Přehled**

Aspose.Slides for .NET je knihovna tříd pro vytváření, čtení, úpravu, konverzi a vykreslování prezentací PowerPoint a OpenDocument. Nemá vlastní uživatelské rozhraní a nevyžaduje Microsoft PowerPoint ani Office, takže ji můžete použít v konzolových aplikacích, desktopových aplikacích jako Windows Forms, webových aplikacích a webových službách. Tento článek shrnuje, co knihovna pokrývá, a odkazuje na články, které popisují jednotlivé oblasti.

## **Podporované platformy**

Aspose.Slides for .NET je distribuován jako dva balíčky NuGet se stejným API:

|**Balíček**|**Sestavení v balíčku**|**Operační systémy**|
| :- | :- | :- |
|[Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/)|.NET Framework 4.6.2, .NET Standard 2.0 a .NET 6. Používejte s .NET Framework 4.6.2 nebo novějším, nebo s .NET 6 nebo novějším.|Windows. Linux a macOS s knihovnou `libgdiplus` a přepínačem `System.Drawing.EnableUnixSupport`.|
|[Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/)|.NET 6. Používejte s .NET 6 nebo novějším.|Windows (x86, x64), Linux (x64 s glibc 2.23 nebo novějším, ARM64 s glibc 2.39 nebo novějším) a macOS (x64, ARM64).|

[Instalace](/slides/cs/net/installation/) vysvětluje, který balíček zvolit a co každý z nich vyžaduje na Linuxu. [Systémové požadavky](/slides/cs/net/system-requirements/) podrobně uvádějí podporované platformy.

## **Formáty souborů a konverze**

Aspose.Slides otevírá a ukládá prezentace PPT, PPTX, PPS, POT, PPSX, POTX, PPTM, PPSM, POTM, ODP, OTP, FODP a PowerPoint XML. Importuje obsah PDF a HTML do snímků a ukládá prezentace jako PDF, XPS, HTML, HTML5, TIFF, animovaný GIF, SWF, Markdown a XAML. [Podporované formáty souborů](/slides/cs/net/supported-file-formats/) uvádí každý formát spolu s API, které jej čte nebo zapisuje.

|**Funkce**|**Popis**|
| :- | :- |
|[PPT a PPTX](/slides/cs/net/ppt-vs-pptx/)|Čtení a zápis binárního formátu PowerPoint 97‑2003 i formátu Office Open XML.|
|[Konverze PPT na PPTX](/slides/cs/net/convert-ppt-to-pptx/)|Převod starých PPT prezentací na PPTX.|
|[Portable Document Format (PDF)](/slides/cs/net/convert-powerpoint-to-pdf/)|Export prezentací do PDF, včetně dokumentů PDF/A a PDF/UA.|
|[XML Paper Specification (XPS)](/slides/cs/net/convert-powerpoint-to-xps/)|Export prezentací do XPS dokumentů.|
|[Tagged Image File Format (TIFF)](/slides/cs/net/convert-powerpoint-to-tiff/)|Export prezentací do TIFF obrázků.|
|[HTML](/slides/cs/net/convert-powerpoint-to-html/)|Export prezentací do HTML a HTML5.|
|[Import PDF a HTML](/slides/cs/net/import-presentation/)|Vytváření snímků z PDF stránek a HTML obsahu.|

## **Vykreslování prezentací**

Aspose.Slides vykresluje snímky a jednotlivé tvary jako PNG, JPEG, BMP, GIF, TIFF a SVG obrázky a snímky jako EMF metafily. Viz [Převod snímků prezentace na obrázky](/slides/cs/net/convert-slide/), [Vykreslení snímku jako SVG obrázku](/slides/cs/net/render-a-slide-as-an-svg-image/) a [Vytvoření náhledů tvarů](/slides/cs/net/create-shape-thumbnails/).

## **Obsahové funkce**

Aspose.Slides vám umožňuje vytvářet, číst a upravovat téměř veškerý obsah prezentace:

|**Oblast**|**Co můžete dělat**|
| :- | :- |
|[Snímky](/slides/cs/net/presentation-slide/)|Přidávat, klonovat, přeskupovat a odstraňovat snímky; aplikovat rozvržení a master šablony; organizovat snímky do sekcí; měnit velikost snímku.|
|[Design](/slides/cs/net/presentation-design/)|Nastavovat pozadí, barvy motivu, záhlaví a zápatí a písma.|
|[Text](/slides/cs/net/manage-text/)|Vytvářet a upravovat textové rámečky, odstavce a úseky; nastavovat písma, barvy, odrážky a zarovnání; hledat a nahrazovat text.|
|[Tvary](/slides/cs/net/powerpoint-shapes/)|Vytvářet AutoShape, čáry, konektory, seskupovat tvary a obrázkové rámečky; nastavovat pozici, velikost, čáru a výplň (pevnou, gradientní nebo vzorovanou); hledat tvar podle alternativního textu.|
|[Tabulky](/slides/cs/net/powerpoint-table/), [grafy](/slides/cs/net/powerpoint-charts/), a [SmartArt](/slides/cs/net/powerpoint-smartart/)|Vytvářet a upravovat tabulky, grafy Microsoft Office a diagramy SmartArt.|
|[Média](/slides/cs/net/manage-media-files/), [OLE objekty](/slides/cs/net/manage-ole/), a [ActiveX ovládací prvky](/slides/cs/net/activex/)|Přidávat vložené nebo odkazované audio a video rámečky, vkládat OLE objekty a přidávat, upravovat nebo odstraňovat ActiveX ovládací prvky.|
|[Poznámky](/slides/cs/net/presentation-notes/) a [komentáře](/slides/cs/net/presentation-comments/)|Přidávat, číst a upravovat poznámky přednášejícího a recenzní komentáře.|
|[Animace](/slides/cs/net/powerpoint-animation/) a [přechody](/slides/cs/net/slide-transition/)|Aplikovat animační efekty na tvary, nastavovat přechody snímků a konfigurovat nastavení prezentace.|
|[Zabezpečení](/slides/cs/net/presentation-security/)|Šifrovat prezentace heslem, nastavit ochranu proti zápisu a pracovat s digitálními podpisy.|
|[VBA makra](/slides/cs/net/presentation-via-vba/)|Přidávat, extrahovat a odstraňovat VBA moduly v makrem povolených prezentacích.|
|[Vlastnosti](/slides/cs/net/presentation-properties/)|Číst a upravovat vlastnosti dokumentu.|

## **Často kladené otázky**

**Potřebuji na serveru nebo PC nainstalovat Microsoft PowerPoint, aby knihovna fungovala?**

Ne. PowerPoint není vyžadován; Aspose.Slides je samostatný engine pro vytváření, úpravu, konverzi a vykreslování prezentací.

**Jak funguje vícevláknové zpracování? Lze proces paralelizovat?**

Je bezpečné zpracovávat různé dokumenty v různých vláknech; stejný [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) objekt nesmí být používán [více vlákny](/slides/cs/net/multithreading/) současně.

**Podporují se hesla souborů a šifrování?**

Ano. [Můžete](/slides/cs/net/password-protected-presentation/) otevřít šifrované prezentace, nastavit nebo odebrat heslo pro otevření i zápis a zkontrolovat stav ochrany.

**Musím se starat o písma v Linux kontejnerech?**

Ano. Písma použitá ve vašich prezentacích, nebo vhodné náhrady, musí být nainstalována v systému, aby byl text vykreslen správně. Můžete také [specifikovat adresáře písem](/slides/cs/net/custom-font/) ve své aplikaci. [Instalace](/slides/cs/net/installation/) uvádí Linuxové předpoklady pro každý balíček.

**Jsou v evaluační verzi omezení?**

Ano. Bez [licence](/slides/cs/net/licensing/) přidává Aspose.Slides vodotisk „Evaluation“ na každý uložený snímek a zkracuje text načtený z prezentací. K plnohodnotnému testování je k dispozici [30‑denní dočasná licence](https://purchase.aspose.com/temporary-license/).

**Je podporován import externích formátů do prezentace (PDF nebo HTML do PPTX)?**

Ano. Můžete přidat [PDF stránky a HTML obsah](/slides/cs/net/import-presentation/) do prezentace a převést je na snímky.