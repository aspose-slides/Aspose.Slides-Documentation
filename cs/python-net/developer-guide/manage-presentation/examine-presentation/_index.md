---
title: Načíst a aktualizovat informace o prezentaci v Pythonu
linktitle: Informace o prezentaci
type: docs
weight: 30
url: /cs/python-net/examine-presentation/
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
- Python
- Aspose.Slides
description: "Prozkoumejte snímky, strukturu a metadata v prezentacích PowerPoint a OpenDocument pomocí Pythonu pro rychlejší poznatky a chytřejší audit obsahu."
---
## **Přehled**

Tento článek ukazuje, jak prozkoumat informace o prezentaci v Aspose.Slides. Vysvětluje, jak zjistit aktuální formát prezentace bez načítání celého souboru, přečíst její vlastnosti dokumentu a v případě potřeby tyto vlastnosti aktualizovat.

Příklady jsou založeny na API [PresentationInfo](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationinfo/) a [DocumentProperties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/documentproperties/) a demonstrují typické operace pro práci s metadaty prezentace.

## **Kontrola formátu prezentace**

Před prací s prezentací možná budete chtít zjistit, v jakém formátu (PPT, PPTX, ODP a dalších) se prezentace momentálně nachází.

Formát prezentace můžete zjistit bez načítání samotné prezentace. Viz tento kód v Pythonu:

```py
import aspose.slides as slides

info1 = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print(info1.load_format, info1.load_format == slides.LoadFormat.PPTX)

info2 = slides.PresentationFactory.instance.get_presentation_info("pres.odp")
print(info2.load_format, info2.load_format == slides.LoadFormat.ODP)

info3 = slides.PresentationFactory.instance.get_presentation_info("pres.ppt")
print(info3.load_format, info3.load_format == slides.LoadFormat.PPT)
```

## **Získání vlastností prezentace**

Tento kód v Pythonu ukazuje, jak získat vlastnosti prezentace (informace o prezentaci):

```py
import aspose.slides as slides

info = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
props = info.read_document_properties()
print(props.created_time)
print(props.subject)
print(props.title)
```

Můžete se podívat na [vlastnosti ve třídě DocumentProperties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/documentproperties/#properties).

## **Aktualizace vlastností prezentace**

Aspose.Slides poskytuje metodu [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationinfo/update_document_properties/#idocumentproperties), která umožňuje provádět změny ve vlastnostech prezentace.

Předpokládejme, že máme PowerPoint prezentaci s následujícími vlastnostmi dokumentu.

![Původní vlastnosti dokumentu PowerPoint prezentace](input_properties.png)

Tento příklad kódu ukazuje, jak upravit některé vlastnosti prezentace:

```py
file_name = "sample.pptx"

info = PresentationFactory.instance.get_presentation_info(file_name)

properties = info.read_document_properties()
properties.title = "My title"
properties.last_saved_time = datetime.now()

info.update_document_properties(properties)
info.write_binded_presentation(file_name)
```

Výsledky změny vlastností dokumentu jsou zobrazeny níže.

![Změněné vlastnosti dokumentu PowerPoint prezentace](output_properties.png)

## **Užitečné odkazy**

Pro získání dalších informací o prezentaci a jejích bezpečnostních atributech mohou být tyto odkazy užitečné:

- [Kontrola, zda je prezentace šifrována](https://docs.aspose.com/slides/cs/python-net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Kontrola, zda je prezentace chráněna proti zápisu (read-only)](https://docs.aspose.com/slides/cs/python-net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Kontrola, zda je prezentace chráněna heslem před načtením](https://docs.aspose.com/slides/cs/python-net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Potvrzení hesla použitého k ochraně prezentace](https://docs.aspose.com/slides/cs/python-net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **Často kladené otázky**

**Jak mohu zkontrolovat, zda jsou písma vložena a která to jsou?**

Hledejte informace o [vložených fondech](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) na úrovni prezentace a porovnejte je se sadou [fondu skutečně použitých v obsahu](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontsmanager/get_fonts/), abyste určili, která písma jsou kritická pro vykreslování.

**Jak rychle zjistit, zda soubor obsahuje skryté snímky a kolik jich je?**

Projděte [kolekci snímků](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slidecollection/) a zkontrolujte [příznak viditelnosti](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slide/hidden/) každého snímku.

**Mohu zjistit, zda jsou použity vlastní velikost a orientace snímku a zda se liší od výchozích?**

Ano. Porovnejte aktuální [velikost snímku](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/slide_size/) a orientaci se standardními předvolbami; pomůže vám to předvídat chování při tisku a exportu.

**Existuje rychlý způsob, jak zjistit, zda grafy odkazují na externí datové zdroje?**

Ano. Projděte všechny [grafy](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chart/), zkontrolujte jejich [datový zdroj](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdata/data_source_type/) a zaznamenejte, zda jsou data interní nebo založená na odkazu, včetně případných poškozených odkazů.

**Jak mohu posoudit „těžké“ snímky, které mohou zpomalit vykreslování nebo export do PDF?**

U každého snímku spočítejte počet objektů a hledejte velké obrázky, průhlednost, stíny, animace a multimédia; přiřaďte přibližné skóre složitosti, abyste označili potenciální výkonnostní úzká místa.