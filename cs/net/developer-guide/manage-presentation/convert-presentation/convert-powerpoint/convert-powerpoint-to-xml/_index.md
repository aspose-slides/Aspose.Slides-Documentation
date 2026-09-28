---
title: Převést prezentace PowerPoint do XML v .NET
linktitle: PowerPoint na XML
type: docs
weight: 145
url: /cs/net/convert-powerpoint-to-xml/
keywords:
- převést PowerPoint na XML
- převést prezentaci na XML
- PPT na XML
- PPTX na XML
- ODP na XML
- PowerPoint XML prezentace
- SaveFormat.Xml
- uložit prezentaci jako XML
- exportovat prezentaci do XML
- XML proud
- .NET
- C#
- Aspose.Slides
description: "Převeďte prezentace PowerPoint a OpenDocument do souborů nebo proudů PowerPoint XML v jazyce C# s knihovnou Aspose.Slides pro .NET."
---
## **Přehled**

Aspose.Slides pro .NET dokáže převést prezentace PowerPoint do formátu PowerPoint XML Presentation. Výstup XML je užitečný, když potřebujete textovou reprezentaci pro kontrolu struktury prezentace, řešení problémů s generovanými dokumenty, porovnání výstupu v automatizovaných testech nebo integraci s pracovním tokem, který využívá XML místo balíčku prezentace.

Použijte metodu [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) s hodnotou `Xml` z výčtu [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/). Výsledek můžete zapsat přímo do souboru nebo do proudu.

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` vytváří PowerPoint XML Presentation. Neextrahuje jednotlivé části Office Open XML uložené uvnitř balíčku PPTX. Pokud potřebujete přesné části balíčku PPTX, jako například `ppt/presentation.xml` nebo jednotlivé soubory XML snímků, prohlédněte si samotný balíček PPTX.
{{% /alert %}}

## **Převést prezentaci do souboru XML**

Načtěte zdrojovou prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) a poté předávejte výstupní cestu a `SaveFormat.Xml` metodě [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). Zdroj může být libovolný formát prezentace podporovaný pro načítání, například PPT, PPTX nebo ODP.

Následující příklad převádí prezentaci PPTX do souboru XML:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.xml", SaveFormat.Xml);
```

## **Zapsat výstup XML do proudu**

Použijte přetížení metodou proudu [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/), když musí XML zůstat v paměti nebo být předáno dalšímu komponentu, například webové službě, poskytovateli úložiště nebo zpracovateli XML. Následující příklad zapíše výsledek do [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream?view=net-10.0) a přetočí jej pro následné čtení:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
using var xmlStream = new MemoryStream();

presentation.Save(xmlStream, SaveFormat.Xml);
xmlStream.Position = 0;

// Předat xmlStream dalšímu komponentu v pracovním postupu.
```

## **Porovnat XML s formáty prezentace a exportu**

Zvolte výstupní formát podle toho, jak bude výsledek použit:

| Formát | Výstup | Typické použití |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML Presentation | Kontrola struktury, řešení problémů, porovnání generovaného výstupu a integrace založená na XML |
| PPT (`.ppt`) | Starý binární soubor prezentace | Kompatibilita se staršími pracovními postupy PowerPoint |
| PPTX (`.pptx`) | Balíček Office Open XML obsahující více částí | Běžná úprava PowerPointu a výměna prezentací |
| PDF nebo TIFF | Stránky s pevně daným rozložením nebo obrázky TIFF | Prohlížení, tisk a archivace |
| PNG, JPEG nebo SVG | Vykreslená reprezentace jednotlivého snímku | Náhledy, miniatury a obrazové zdroje |
| HTML nebo HTML5 | Webově orientovaný výstup prezentace | Prohlížení v prohlížeči a publikování na webu |

Na rozdíl od PPT a PPTX je výstup XML primárně určen pro kontrolu a datově orientované pracovní postupy. Na rozdíl od PDF, TIFF, HTML a formátů obrázků snímků představuje data prezentace, nikoli vykreslené snímky jako stránky nebo vizuální zdroje. Tabulka [supported file formats](/slides/cs/net/supported-file-formats/) uvádí všechny formáty, které Aspose.Slides může načíst, importovat, uložit nebo vykreslit.

## **Často kladené otázky**

**Je `SaveFormat.Xml` stejné jako ukládání souboru PPTX?**

Ne. PPTX je balíček obsahující více částí Office Open XML, zatímco `SaveFormat.Xml` vytváří soubor PowerPoint XML Presentation.

**Mohu uložit výstup XML bez vytváření souboru na disku?**

Ano. Předávejte zapisovatelný proud metodě [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). Například použijte [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream?view=net-10.0) pro zpracování v paměti.

**Může Aspose.Slides načíst exportovaný XML soubor znovu?**

Ano. Předávejte XML soubor nebo proud konstruktoru [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/). [Presentation.SourceFormat](https://reference.aspose.com/slides/net/aspose.slides/presentation/sourceformat/) pak vrátí `SourceFormat.Xml`. [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) pro tento formát hlásí `LoadFormat.Unknown`, takže jej nepoužívejte k rozhodování, zda lze XML soubor otevřít.

**Vykresluje konverze XML každý snímek jako stránku nebo obrázek?**

Ne. Konverze XML zapisuje strukturovaná data prezentace. Pro výstup orientovaný na stránky použijte PDF nebo TIFF, pro jednotlivé obrázky snímků PNG, JPEG nebo SVG.