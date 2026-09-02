---
title: Načtení a aktualizace informací o prezentaci v .NET
linktitle: Informace o prezentaci
type: docs
weight: 30
url: /cs/net/examine-presentation/
keywords:
- formát prezentace
- vlastnosti prezentace
- vlastnosti dokumentu
- získat vlastnosti
- číst vlastnosti
- změnit vlastnosti
- upravit vlastnosti
- aktualizovat vlastnosti
- prozkoumat PPTX
- prozkoumat PPT
- prozkoumat ODP
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Prozkoumejte snímky, strukturu a metadata v prezentacích PowerPoint a OpenDocument pomocí .NET pro rychlejší poznatky a chytřejší audit obsahu."
---
## **Přehled**

Tento článek ukazuje, jak prozkoumat informace o prezentaci v Aspose.Slides. Vysvětluje, jak zjistit aktuální formát prezentace, aniž by se načítal celý soubor, jak přečíst její vlastnosti dokumentu a jak tyto vlastnosti podle potřeby aktualizovat.

Příklady jsou založeny na API [PresentationInfo](https://reference.aspose.com/slides/cs/net/aspose.slides/presentationinfo/) a [DocumentProperties](https://reference.aspose.com/slides/cs/net/aspose.slides/documentproperties/) a ukazují typické operace pro práci s metadaty prezentace.

## **Zkontrolovat formát prezentace**

Před prací s prezentací možná budete chtít zjistit, v jakém formátu (PPT, PPTX, ODP a dalších) se prezentace momentálně nachází.

Formát prezentace můžete zkontrolovat, aniž byste prezentaci načítali. Viz následující C# kód:

```c#
using Aspose.Slides;

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
Console.WriteLine(info.LoadFormat); // PPTX

IPresentationInfo info2 = PresentationFactory.Instance.GetPresentationInfo("pres.ppt");
Console.WriteLine(info2.LoadFormat); // PPT

IPresentationInfo info3 = PresentationFactory.Instance.GetPresentationInfo("pres.odp");
Console.WriteLine(info3.LoadFormat); // ODP
```

## **Získat vlastnosti prezentace**

Tento C# kód ukazuje, jak získat vlastnosti prezentace (informace o prezentaci):

```c#
using Aspose.Slides;

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
IDocumentProperties props = info.ReadDocumentProperties();
Console.WriteLine(props.CreatedTime);
Console.WriteLine(props.Subject);
Console.WriteLine(props.Title);
// ...
```

Můžete se podívat na [vlastnosti ve třídě DocumentProperties](https://reference.aspose.com/slides/cs/net/aspose.slides/documentproperties/#properties).

## **Aktualizovat vlastnosti prezentace**

Aspose.Slides poskytuje metodu [PresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/cs/net/aspose.slides/presentationinfo/methods/updatedocumentproperties), která umožňuje měnit vlastnosti prezentace.

Předpokládejme, že máme PowerPoint prezentaci s následujícími vlastnostmi dokumentu.

![Původní vlastnosti dokumentu PowerPoint prezentace](input_properties.png)

Tento příklad kódu ukazuje, jak upravit některé vlastnosti prezentace:

```c#
using Aspose.Slides;

string fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo(fileName);

IDocumentProperties properties = info.ReadDocumentProperties();
properties.Title = "My title";
properties.LastSavedTime = DateTime.Now;

info.UpdateDocumentProperties(properties);
info.WriteBindedPresentation(fileName);
```

Výsledky změny vlastností dokumentu jsou zobrazeny níže.

![Změněné vlastnosti dokumentu PowerPoint prezentace](output_properties.png)

## **Užitečné odkazy**

Pro získání dalších informací o prezentaci a jejích bezpečnostních atributech mohou být užitečné tyto odkazy:

- [Prezentace chráněné heslem](/slides/cs/net/password-protected-presentation/)
- [Prezentace se zápisovou ochranou](/slides/cs/net/write-protected-presentation/)

## **Časté dotazy**

**Jak mohu zkontrolovat, zda jsou písma vložena a která konkrétně?**

Hledejte informace o [vložených písmech](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsmanager/getembeddedfonts/) na úrovni prezentace a porovnejte je s kolekcí [písmen skutečně použitého v obsahu](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsmanager/getfonts/), abyste určili, která písma jsou pro vykreslení kritická.

**Jak mohu rychle zjistit, zda soubor obsahuje skryté snímky a kolik jich je?**

Projděte [kolekci snímků](https://reference.aspose.com/slides/cs/net/aspose.slides/slidecollection/) a zkontrolujte u každého snímku [příznak viditelnosti](https://reference.aspose.com/slides/cs/net/aspose.slides/slide/hidden/).

**Mohu zjistit, zda jsou použity vlastní velikost a orientace snímku a zda se liší od výchozích?**

Ano. Porovnejte aktuální [velikost snímku](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/slidesize/) a orientaci se standardními předvolbami; pomůže to předvídat chování při tisku a exportu.

**Existuje rychlý způsob, jak zjistit, zda grafy odkazují na externí zdroje dat?**

Ano. Procházejte všechny [grafy](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/chart/), zkontrolujte jejich [zdroj dat](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/chartdata/datasourcetype/) a zaznamenejte, zda jsou data interní nebo odkazována, včetně případných neplatných odkazů.

**Jak mohu posoudit „těžké“ snímky, které mohou zpomalit vykreslování nebo export do PDF?**

Pro každý snímek spočítejte množství objektů a hledejte velké obrázky, průhlednosti, stíny, animace a multimédia; přidělte přibližné skóre složitosti, abyste označili potenciální úzká místa výkonu.