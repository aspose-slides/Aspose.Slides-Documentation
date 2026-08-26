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
- zkoumat PPTX
- zkoumat PPT
- zkoumat ODP
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Prozkoumejte snímky, strukturu a metadata v prezentacích PowerPoint a OpenDocument pomocí Pythonu pro rychlejší analýzu a chytrější audit obsahu."
---
## **Přehled**

Tento článek ukazuje, jak v Aspose.Slides prohlížet informace o prezentaci. Vysvětluje, jak zjistit aktuální formát prezentace, aniž by se načítal celý soubor, jak přečíst její vlastnosti dokumentu a jak tyto vlastnosti aktualizovat podle potřeby.

Příklady jsou založeny na API [PresentationInfo](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationinfo/) a [DocumentProperties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/documentproperties/) a demonstrují typické operace pro práci s metadaty prezentace.

## **Zkontrolovat formát prezentace**

Před prací s prezentací můžete chtít zjistit, v jakém formátu (PPT, PPTX, ODP a dalších) se prezentace aktuálně nachází.

Formát prezentace lze zkontrolovat, aniž by se načítala samotná prezentace. Podívejte se na tento Python kód:

```py
import aspose.slides as slides

info1 = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print(info1.load_format, info1.load_format == slides.LoadFormat.PPTX)

info2 = slides.PresentationFactory.instance.get_presentation_info("pres.odp")
print(info2.load_format, info2.load_format == slides.LoadFormat.ODP)

info3 = slides.PresentationFactory.instance.get_presentation_info("pres.ppt")
print(info3.load_format, info3.load_format == slides.LoadFormat.PPT)
```

## **Získat vlastnosti prezentace**

Tento Python kód ukazuje, jak získat vlastnosti prezentace (informace o prezentaci):

```py
import aspose.slides as slides

info = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
props = info.read_document_properties()
print(props.created_time)
print(props.subject)
print(props.title)
```

Můžete se podívat na [properties under the DocumentProperties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/documentproperties/#properties) třídu.

## **Aktualizovat vlastnosti prezentace**

Aspose.Slides poskytuje metodu [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationinfo/update_document_properties/#idocumentproperties), která umožňuje provádět změny ve vlastnostech prezentace.

Předpokládejme, že máme PowerPoint prezentaci s následujícími vlastnostmi dokumentu.

![Original document properties of the PowerPoint presentation](input_properties.png)

Tento ukázkový kód ukazuje, jak upravit některé vlastnosti prezentace:

```py
import aspose.slides as slides
import datetime

file_name = "sample.pptx"

info = slides.PresentationFactory.instance.get_presentation_info(file_name)

properties = info.read_document_properties()
properties.title = "My title"
properties.last_saved_time = datetime.datetime.now()

info.update_document_properties(properties)
info.write_binded_presentation(file_name)
```

Výsledky změny vlastností dokumentu jsou zobrazeny níže.

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **Užitečné odkazy**

Pro získání dalších informací o prezentaci a jejích bezpečnostních atributech vám mohou být užitečné tyto odkazy:

- [Password-Protect Presentations](/slides/cs/python-net/password-protected-presentation/)
- [Write-Protect Presentations](/slides/cs/python-net/write-protected-presentation/)

## **Často kladené otázky**

**Jak mohu zkontrolovat, zda jsou písma vložena a která to jsou?**

Hledejte informace o [embedded-font information](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) na úrovni prezentace a poté porovnejte tyto položky s množinou [fonts actually used across content](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fontsmanager/get_fonts/), abyste identifikovali, která písma jsou kritická pro vykreslování.

**Jak rychle zjistit, zda soubor obsahuje skryté snímky a kolik jich je?**

Procházejte [slide collection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slidecollection/) a kontrolujte [visibility flag](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slide/hidden/) každého snímku.

**Mohu zjistit, zda je použita vlastní velikost a orientace snímku a zda se liší od výchozích?**

Ano. Porovnejte aktuální [slide size](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/slide_size/) a orientaci se standardními předvolbami; to pomůže předvídat chování při tisku a exportu.

**Existuje rychlý způsob, jak zjistit, zda grafy odkazují na externí zdroje dat?**

Ano. Projděte všechny [charts](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chart/), zkontrolujte jejich [data source](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdata/data_source_type/) a zaznamenejte, zda jsou data interní nebo odkazována, včetně poškozených odkazů.

**Jak mohu posoudit „těžké“ snímky, které mohou zpomalit vykreslování nebo export do PDF?**

Pro každý snímek spočítejte počet objektů a hledejte velké obrázky, průhlednost, stíny, animace a multimédia; přiřaďte hrubé hodnocení složitosti, abyste identifikovali potenciální úzká místa výkonu.