---
title: Převést prezentace PowerPoint do XML v .NET
linktitle: PowerPoint do XML
type: docs
weight: 145
url: /cs/net/convert-powerpoint-to-xml/
keywords:
- převést PowerPoint do XML
- převést prezentaci do XML
- PPT do XML
- PPTX do XML
- ODP do XML
- PowerPoint XML prezentace
- SaveFormat.Xml
- uložit prezentaci jako XML
- exportovat prezentaci do XML
- XML proud
- .NET
- C#
- Aspose.Slides
description: "Převést prezentace PowerPoint a OpenDocument do souborů nebo proudů PowerPoint XML v C# s Aspose.Slides pro .NET."
---
## **Přehled**

Aspose.Slides for .NET může převádět prezentace PowerPoint do formátu PowerPoint XML Presentation. Výstup XML je užitečný, když potřebujete textovou reprezentaci pro kontrolu struktury prezentace, řešení problémů s generovanými dokumenty, porovnání výstupu v automatizovaných testech nebo integraci s pracovním tokem, který používá XML místo balíčku prezentace.

Použijte metodu [Presentation.Save](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/save/) s hodnotou `Xml` z výčtu [SaveFormat](https://reference.aspose.com/slides/cs/net/aspose.slides.export/saveformat/). Výsledek můžete zapsat přímo do souboru nebo do proudu.

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` vytvoří PowerPoint XML Presentation. Neextrahuje jednotlivé části Office Open XML uložené uvnitř balíčku PPTX. Pokud potřebujete přesné části balíčku PPTX, například `ppt/presentation.xml` nebo jednotlivé soubory XML snímků, prozkoumejte samotný balíček PPTX.
{{% /alert %}}

## **Převést prezentaci do souboru XML**

Načtěte zdrojovou prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) a pak předávejte výstupní cestu a `SaveFormat.Xml` metodě [Presentation.Save](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/save/). Zdroj může být libovolný formát prezentace podporovaný pro načítání, například PPT, PPTX nebo ODP.

Následující příklad převádí prezentaci PPTX do souboru XML:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.xml", SaveFormat.Xml);
```

## **Zapsat výstup XML do proudu**

Použijte přetížení metodou proudu [Presentation.Save](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/save/) pokud musí XML zůstat v paměti nebo být předáno jiné komponentě, například webové službě, poskytovateli úložiště nebo zpracovatelskému řetězci XML. Následující příklad zapisuje výsledek do [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream) a přetáčí jej pro následné čtení:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
using var xmlStream = new MemoryStream();

presentation.Save(xmlStream, SaveFormat.Xml);
xmlStream.Position = 0;

// Předejte xmlStream dalšímu komponentu v pracovním toku.
```

## **Porovnat XML s formáty prezentace a exportu**

Zvolte výstupní formát podle toho, jak bude výsledek použit:

| Formát | Výstup | Typické použití |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Prezentace PowerPoint XML | Kontrola struktury, řešení problémů, porovnání vygenerovaného výstupu a integrace založené na XML |
| PPT (`.ppt`) | Starší binární soubor prezentace | Kompatibilita se staršími pracovními postupy PowerPoint |
| PPTX (`.pptx`) | Balíček Office Open XML obsahující více částí | Běžná editace PowerPoint a výměna prezentací |
| PDF nebo TIFF | Stránky s pevnou rozvržením nebo vícestránkový obrázek | Prohlížení, tisk a archivace |
| PNG, JPEG nebo SVG | Vykreslená reprezentace jednotlivého snímku | Náhledy, ukázky a obrazové zdroje |
| HTML nebo HTML5 | Webově orientovaný výstup prezentace | Prohlížení v prohlížeči a publikování na webu |

Na rozdíl od PPT a PPTX je výstup XML primárně určen pro kontrolu a datově orientované pracovní toky. Na rozdíl od formátů PDF, TIFF, HTML a obrázkových formátů snímků představuje data prezentace místo vykreslování snímků jako stránky nebo vizuální zdroje. Tabulka [podporované formáty souborů](/slides/cs/net/supported-file-formats/) uvádí PowerPoint XML Presentation jako formát pouze pro ukládání, takže jej nepoužívejte, když pracovní tok musí načíst exportovaný soubor zpět do Aspose.Slides pro další úpravy.

## **Často kladené otázky**

**Je `SaveFormat.Xml` to samé jako ukládání souboru PPTX?**

Ne. PPTX je balíček obsahující více částí Office Open XML, zatímco `SaveFormat.Xml` vytváří soubor PowerPoint XML Presentation.

**Mohu uložit výstup XML bez vytvoření souboru na disku?**

Ano. Předávejte zapisovatelný proud metodě [Presentation.Save](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/save/). Například použijte [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream) pro zpracování v paměti.

**Může Aspose.Slides znovu načíst exportovaný soubor XML?**

Ne. PowerPoint XML Presentation je momentálně podporována pro ukládání, ale ne pro načítání. Použijte PPTX nebo jiný podporovaný formát prezentace, pokud je potřeba provádět zpětnou úpravu.

**Převod XML vykresluje každý snímek jako stránku nebo obrázek?**

Ne. Převod XML zapisuje strukturovaná data prezentace. Pro výstup orientovaný na stránky použijte PDF nebo TIFF, nebo pro jednotlivé snímky PNG, JPEG a SVG.