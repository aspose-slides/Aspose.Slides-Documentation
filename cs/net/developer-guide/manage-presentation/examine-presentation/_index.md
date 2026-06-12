---
title: Získání a aktualizace informací o prezentaci v .NET
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
description: "Prozkoumejte snímky, strukturu a metadata v prezentacích PowerPoint a OpenDocument pomocí .NET pro rychlejší přehledy a chytřejší audit obsahu."
---
## **Přehled**

Tento článek ukazuje, jak prozkoumat informace o prezentaci v Aspose.Slides. Vysvětluje, jak určit aktuální formát prezentace, aniž byste načítali celý soubor, přečíst její vlastnosti dokumentu a v případě potřeby tyto vlastnosti aktualizovat.

Příklady jsou založeny na API [PresentationInfo](https://reference.aspose.com/slides/cs/net/aspose.slides/presentationinfo/) a [DocumentProperties](https://reference.aspose.com/slides/cs/net/aspose.slides/documentproperties/) a demonstrují typické operace pro práci s metadaty prezentace.

## **Zkontrolovat formát prezentace**

Před prací s prezentací možná chcete zjistit, v jakém formátu (PPT, PPTX, ODP a dalších) se prezentace právě nachází.

Formát prezentace můžete zkontrolovat, aniž byste ji načítali. Viz tento C# kód:

```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
Console.WriteLine(info.LoadFormat); // PPTX

IPresentationInfo info2 = PresentationFactory.Instance.GetPresentationInfo("pres.ppt");
Console.WriteLine(info2.LoadFormat); // PPT

IPresentationInfo info3 = PresentationFactory.Instance.GetPresentationInfo("pres.odp");
Console.WriteLine(info3.LoadFormat); // ODP
```

## **Získat vlastnosti prezentace**

Tento C# kód vám ukazuje, jak získat vlastnosti prezentace (informace o prezentaci):

```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
IDocumentProperties props = info.ReadDocumentProperties();
Console.WriteLine(props.CreatedTime);
Console.WriteLine(props.Subject);
Console.WriteLine(props.Title);
// ..
```

Možná budete chtít zobrazit [vlastnosti ve třídě DocumentProperties](https://reference.aspose.com/slides/cs/net/aspose.slides/documentproperties/#properties).

## **Aktualizovat vlastnosti prezentace**

Aspose.Slides poskytuje metodu [PresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/cs/net/aspose.slides/presentationinfo/methods/updatedocumentproperties), která umožňuje provádět změny ve vlastnostech prezentace.

Předpokládejme, že máme PowerPoint prezentaci s níže uvedenými vlastnostmi dokumentu.

![Původní vlastnosti dokumentu PowerPoint prezentace](input_properties.png)

Tento příklad kódu ukazuje, jak upravit některé vlastnosti prezentace:

```c#
string fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo(fileName);

IDocumentProperties properties = info.ReadDocumentProperties();
properties.Title = "My title";
properties.LastSavedTime = DateTime.Now;

info.UpdateDocumentProperties(properties);
info.WriteBindedPresentation(fileName);
```

Výsledky změny vlastností dokumentu jsou znázorněny níže.

![Změněné vlastnosti dokumentu PowerPoint prezentace](output_properties.png)

## **Užitečné odkazy**

Pro získání podrobnějších informací o prezentaci a jejích bezpečnostních atributech můžete najít tyto odkazy užitečné:

- [Kontrola, zda je prezentace šifrována](https://docs.aspose.com/slides/cs/net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Kontrola, zda je prezentace chráněna proti zápisu (read‑only)](https://docs.aspose.com/slides/cs/net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Kontrola, zda je prezentace chráněna heslem před načtením](https://docs.aspose.com/slides/cs/net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Potvrzení hesla použitého k ochraně prezentace](https://docs.aspose.com/slides/cs/net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **Často kladené otázky**

**Jak mohu zjistit, zda jsou písma vložena a která to jsou?**

Vyhledejte informace o [vložených písmenech](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsmanager/getembeddedfonts/) na úrovni prezentace a poté porovnejte tyto položky s množinou [skutečně použitých písem v obsahu](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsmanager/getfonts/), abyste identifikovali, která písma jsou kritická pro vykreslování.

**Jak rychle zjistit, zda soubor obsahuje skryté snímky a kolik jich je?**

Procházejte [kolekci snímků](https://reference.aspose.com/slides/cs/net/aspose.slides/slidecollection/) a kontrolujte u každého snímku jeho [vlajku viditelnosti](https://reference.aspose.com/slides/cs/net/aspose.slides/slide/hidden/).

**Mohu detekovat, zda je použita vlastní velikost a orientace snímku a zda se liší od výchozích?**

Ano. Porovnejte aktuální [velikost snímku](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/slidesize/) a orientaci se standardními předvolbami; to pomáhá předvídat chování při tisku a exportu.

**Je zde rychlý způsob, jak zjistit, zda grafy odkazují na externí zdroje dat?**

Ano. Procházejte všechny [grafy](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/chart/), kontrolujte jejich [zdroj dat](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/chartdata/datasourcetype/) a zaznamenejte, zda jsou data interní nebo založená na odkazu, včetně případných poškozených odkazů.

**Jak mohu posoudit „těžké“ snímky, které mohou zpomalit vykreslování nebo export do PDF?**

U každého snímku spočítejte počet objektů a hledejte velké obrázky, průhlednost, stíny, animace a multimédia; přiřaďte přibližné skóre složitosti, které označí potenciální problémy s výkonem.