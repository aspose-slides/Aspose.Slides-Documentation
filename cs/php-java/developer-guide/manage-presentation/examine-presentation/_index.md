---
title: Načíst a aktualizovat informace o prezentaci v PHP
linktitle: Informace o prezentaci
type: docs
weight: 30
url: /cs/php-java/examine-presentation/
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
- PHP
- Aspose.Slides
description: "Prozkoumejte snímky, strukturu a metadata v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro PHP pro rychlejší poznatky a inteligentnější audity obsahu."
---
## **Přehled**

Tento článek ukazuje, jak prozkoumat informace o prezentaci v Aspose.Slides. Vysvětluje, jak určit aktuální formát prezentace, aniž by se načítal celý soubor, přečíst její vlastnosti dokumentu a v případě potřeby tyto vlastnosti aktualizovat.

Příklady jsou založeny na API [PresentationInfo](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationinfo/) a [DocumentProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/documentproperties/) a demonstrují typické operace pro práci s metadaty prezentace.

## **Zkontrolujte formát prezentace**

Před prací s prezentací můžete chtít zjistit, v jakém formátu (PPT, PPTX, ODP a další) se prezentace momentálně nachází.

Formát prezentace můžete zkontrolovat, aniž byste ji načítali. Viz následující PHP kód:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  echo($info->getLoadFormat());// PPTX

  $info2 = PresentationFactory->getInstance()->getPresentationInfo("pres.ppt");
  echo($info2->getLoadFormat());// PPT

  $info3 = PresentationFactory->getInstance()->getPresentationInfo("pres.odp");
  echo($info3->getLoadFormat());// ODP


```

## **Získání vlastností prezentace**

Tento PHP kód ukazuje, jak získat vlastnosti prezentace (informace o prezentaci):

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  $props = $info->readDocumentProperties();
  echo($props->getCreatedTime());
  echo($props->getSubject());
  echo($props->getTitle());
  # ..
```

Můžete se podívat na [vlastnosti v třídě DocumentProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/documentproperties/#DocumentProperties--) .

## **Aktualizace vlastností prezentace**

Aspose.Slides poskytuje metodu [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), která umožňuje provádět změny ve vlastnostech prezentace.

Předpokládejme, že máme PowerPointovou prezentaci s následujícími vlastnostmi dokumentu.

![Původní vlastnosti dokumentu PowerPointové prezentace](input_properties.png)

Tento příklad kódu ukazuje, jak upravit některé vlastnosti prezentace:

```php
$fileName = "sample.pptx";

$info = PresentationFactory::getInstance()->getPresentationInfo($fileName);

$properties = $info->readDocumentProperties();
$properties->setTitle("My title");
$properties->setLastSavedTime(new Java("java.util.Date"));

$info->updateDocumentProperties($properties);
$info->writeBindedPresentation($fileName);
```

Výsledky změny vlastností dokumentu jsou zobrazeny níže.

![Změněné vlastnosti dokumentu PowerPointové prezentace](output_properties.png)

## **Užitečné odkazy**

Pro získání dalších informací o prezentaci a jejích bezpečnostních atributech vám mohou být užitečné tyto odkazy:

- [Zabezpečení prezentací heslem](/slides/cs/php-java/password-protected-presentation/)
- [Zabezpečení prezentací proti zápisu](/slides/cs/php-java/write-protected-presentation/)

## **Často kladené otázky**

**Jak mohu zkontrolovat, zda jsou písma vložena a která to jsou?**

Vyhledejte informace o [vložených písmenech](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontsmanager/getembeddedfonts/) na úrovni prezentace a porovnejte je se seznamem [písmen skutečně použitých v obsahu](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontsmanager/getfonts/), abyste určili, která písma jsou klíčová pro vykreslování.

**Jak mohu rychle zjistit, zda soubor obsahuje skryté snímky a kolik jich je?**

Projděte [kolekci snímků](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slidecollection/) a pro každý snímek zkontrolujte [vlajku viditelnosti](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slide/gethidden/).

**Mohu zjistit, zda jsou použity vlastní velikost a orientace snímku a zda se liší od výchozích?**

Ano. Porovnejte aktuální [velikost snímku](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/getslidesize/) a orientaci se standardními předvolbami; to pomáhá předvídat chování při tisku a exportu.

**Existuje rychlý způsob, jak zjistit, zda grafy odkazují na externí datové zdroje?**

Ano. Procházejte všechny [grafy](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chart/), zkontrolujte jejich [datový zdroj](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdata/getdatasourcetype/) a poznamenejte, zda jsou data interní nebo odkazována, včetně případných poškozených odkazů.

**Jak mohu posoudit „těžké“ snímky, které mohou zpomalit vykreslování nebo export do PDF?**

Pro každý snímek spočítejte počet objektů a hledejte velké obrázky, průhlednost, stíny, animace a multimédia; přiřaďte hrubé skóre složitosti, abyste označili potenciální výkonnostní úzká místa.