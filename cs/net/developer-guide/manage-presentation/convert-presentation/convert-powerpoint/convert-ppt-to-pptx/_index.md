---
title: Převod PPT na PPTX v .NET
linktitle: PPT na PPTX
type: docs
weight: 20
url: /cs/net/convert-ppt-to-pptx/
keywords:
- převod PowerPoint
- převod prezentace
- převod snímku
- převod PPT
- PPT na PPTX
- uložit PPT jako PPTX
- exportovat PPT do PPTX
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Převod starých souborů PPT na PPTX v .NET pomocí Aspose.Slides. Zahrnuje příklady v C# pro převod jednotlivých souborů i dávkový převod, zpracování chyb a poznámky o věrnosti."
---
## **Přehled**

PPT je starší binární formát PowerPointu, zatímco PPTX je novější formát Open XML. Aspose.Slides pro .NET může načíst soubor PPT a uložit jej jako PPTX bez Microsoft PowerPoint. Tento článek ukazuje, jak převést jeden soubor nebo adresář souborů a vysvětluje, co je třeba zkontrolovat po konverzi.

## **Převod souboru PPT na PPTX**

Načtěte zdrojový soubor pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/), poté zavolejte [IPresentation.Save](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentation/save/) s parametrem [SaveFormat.Pptx](https://reference.aspose.com/slides/cs/net/aspose.slides.export/saveformat/). Deklarace `using` uvolní prezentaci a její prostředky po ukončení rozsahu.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

// Načíst starou PPT prezentaci.
using var presentation = new Presentation("presentation.ppt");

// Uložit prezentaci ve formátu PPTX.
presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

Přípona souboru sama o sobě nevybírá výstupní formát; argument [SaveFormat.Pptx](https://reference.aspose.com/slides/cs/net/aspose.slides.export/saveformat/) to dělá. Pokud potřebujete zachovat původní soubor PPT, mějte vstupní a výstupní cesty odlišné.

## **Převod více souborů PPT**

Následující příklad převádí každý soubor `.ppt` v jednom adresáři. Každý soubor je zpracován nezávisle, takže jeden neúspěšný převod nepozastaví zbytek dávky.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var inputDirectory = "input";
var outputDirectory = "output";
Directory.CreateDirectory(outputDirectory);

foreach (var inputPath in Directory.EnumerateFiles(inputDirectory, "*.ppt", SearchOption.TopDirectoryOnly))
{
    var outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".pptx";
    var outputPath = Path.Combine(outputDirectory, outputFileName);

    try
    {
        using var presentation = new Presentation(inputPath);
        presentation.Save(outputPath, SaveFormat.Pptx);
        Console.WriteLine($"Converted: {inputPath}");
    }
    catch (Exception exception)
    {
        Console.Error.WriteLine($"Failed: {inputPath} ({exception.Message})");
    }
}
```

Pro produkční úlohy zaznamenejte kompletní výjimku, rozhodněte, zda lze přepsat existující výstupní soubor, a zapište názvy neúspěšných souborů do fronty pro opakování nebo revizi. Poškozené soubory, soubory chráněné heslem otevřené bez požadovaného hesla, nedostupné cesty a nepodporovaný obsah mohou způsobit selhání konverze. Viz [Password-Protected Presentations](/slides/cs/net/password-protected-presentation/) pro načítání šifrovaných souborů.

## **Věrnost a starší funkce**

Konverze obvykle zachovává snímky, hlavní šablony, rozvržení, text, tvary, obrázky, tabulky a grafy. Nicméně PPT a PPTX nevyjadřují každou funkci přesně stejným způsobem. Starší funkce, která nemá ekvivalent v PPTX nebo není podporována knihovnou, může být normalizována, vynechána nebo zobrazena odlišně.

Zkontrolujte převedený soubor, pokud obsahuje animace, přechody, vložené nebo propojené OLE objekty, ActiveX ovládací prvky, vložená média, neobvyklá písma nebo VBA makra. Pouhý soubor PPTX není formát s podporou maker, takže použijte vhodný workflow s podporou maker, pokud musí být VBA dostupné. Také ověřte, že požadovaná písma a externí zdroje jsou přítomny v prostředí, kde bude převedená prezentace otevřena nebo vykreslena.

U důležitých dokumentů znovu otevřete vygenerovaný PPTX programově a zkontrolujte klíčové počty snímků a obsah, poté porovnejte jeho vzhled a chování prezentace ve zamýšleném prohlížeči. Nepovažujte úspěšné volání [IPresentation.Save](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentation/save/) za důkaz, že každá starší funkce má přesnou reprezentaci v PPTX.

## **Kdy použít PPTX**

Použijte PPTX, pokud bude prezentace upravována v aktuálních verzích PowerPointu, vyměňována se systémy pracujícími s balíčky Open XML, nebo uložena ve formátu, který je snazší prohlížet a obnovit než starý binární PPT. Ponechte původní PPT jako archivní nebo záložní kopii, dokud převedená prezentace neprojde vašimi kontrolami věrnosti.

Pokud místo toho potřebujete PDF, HTML, obrázky, XPS nebo jiný výstupní typ, použijte specifické pokyny pro formát v článku [Convert Presentations to Multiple Formats](/slides/cs/net/convert-presentation/) místo předpokladu, že všechny cíle zachovají upravitelná PowerPointová vylepšení.

## **Online konvertor**

Pro příležitostný soubor nebo rychlé porovnání můžete použít [online PPT to PPTX converter](https://products.aspose.app/slides/cs/conversion/ppt-to-pptx). Pro opakované konverze, dávkové zpracování nebo zpracování chyb na úrovni aplikace použijte .NET API.

## **Související články**

- [PPT vs PPTX](/slides/cs/net/ppt-vs-pptx/)
- [Uložení prezentací v .NET](/slides/cs/net/save-presentation/)
- [Podporované formáty souborů](/slides/cs/net/supported-file-formats/)
- [Otevření prezentací v .NET](/slides/cs/net/open-presentation/)

## **Často kladené otázky**

**Mohu převést PPT na PPTX bez nainstalovaného Microsoft PowerPoint?**

Ano. Aspose.Slides pro .NET načítá a ukládá soubory prezentací bez potřeby Microsoft PowerPoint.

**Zachová konverze PPT na PPTX veškerý obsah přesně?**

Zachovává běžný obsah prezentace, ale přesná věrnost není garantována pro každou starší nebo nepodporovanou funkci. Přezkoumejte vygenerovaný soubor, pokud obsahuje makra, OLE nebo ActiveX objekty, média, specializované animace nebo neobvyklá písma.

**Mohu převést soubor PPT chráněný heslem?**

Ano, pokud při načítání souboru zadáte správné heslo. Chybějící nebo nesprávné heslo způsobí selhání načítací operace.

**Mám po konverzi smazat soubor PPT?**

Ponechte původní soubor, dokud neověříte PPTX ve vizualizérech a pracovních postupech, které pro vás jsou důležité. Poskytuje to záložní kopii pro případ, že se starší funkce převede jinak.