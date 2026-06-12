---
title: Získání a aktualizace informací o prezentaci v PHP
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
- zkoumat PPTX
- zkoumat PPT
- zkoumat ODP
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Prozkoumejte snímky, strukturu a metadata v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro PHP pro rychlejší poznatky a chytřejší audity obsahu."
---
## **Přehled**

Tento článek ukazuje, jak prozkoumat informace o prezentaci v Aspose.Slides. Vysvětluje, jak určit aktuální formát prezentace bez načtení celého souboru, přečíst její vlastnosti dokumentu a aktualizovat tyto vlastnosti podle potřeby.

Příklady jsou založeny na API [PresentationInfo](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationinfo/) a [DocumentProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/documentproperties/) a demonstrují typické operace pro práci s metadaty prezentace.

## **Zkontrolovat formát prezentace**

Před prací s prezentací můžete chtít zjistit, v jakém formátu (PPT, PPTX, ODP a dalších) se prezentace momentálně nachází.

Formát prezentace můžete zkontrolovat bez načtení prezentace. Viz tento PHP kód:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  echo($info->getLoadFormat());// PPTX

  $info2 = PresentationFactory->getInstance()->getPresentationInfo("pres.ppt");
  echo($info2->getLoadFormat());// PPT

  $info3 = PresentationFactory->getInstance()->getPresentationInfo("pres.odp");
  echo($info3->getLoadFormat());// ODP


```

## **Získat vlastnosti prezentace**

Tento PHP kód ukazuje, jak získat vlastnosti prezentace (informace o prezentaci):

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  $props = $info->readDocumentProperties();
  echo($props->getCreatedTime());
  echo($props->getSubject());
  echo($props->getTitle());
  # ..

```

Možná budete chtít zobrazit [vlastnosti třídy DocumentProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/documentproperties/#DocumentProperties--) .

## **Aktualizovat vlastnosti prezentace**

Aspose.Slides poskytuje metodu [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) , která umožňuje provádět změny ve vlastnostech prezentace.

Předpokládejme, že máme PowerPointovou prezentaci s následujícími vlastnostmi dokumentu.

![Original document properties of the PowerPoint presentation](input_properties.png)

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

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **Užitečné odkazy**

Pro získání dalších informací o prezentaci a jejích bezpečnostních atributech vám mohou být užitečné tyto odkazy:

- [Kontrola, zda je prezentace šifrována](https://docs.aspose.com/slides/cs/php-java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Kontrola, zda je prezentace chráněna proti zápisu (pouze ke čtení)](https://docs.aspose.com/slides/cs/php-java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Kontrola, zda je prezentace chráněna heslem před načtením](https://docs.aspose.com/slides/cs/php-java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Ověření hesla použitého k ochraně prezentace](https://docs.aspose.com/slides/cs/php-java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **Často kladené otázky**

**Jak mohu zkontrolovat, zda jsou písma vložena a která to jsou?**

Vyhledejte informace o [embedded-font](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontsmanager/getembeddedfonts/) na úrovni prezentace a porovnejte je s množinou [písmen skutečně použitých v obsahu](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontsmanager/getfonts/) pro identifikaci kritických písem pro vykreslení.

**Jak rychle zjistit, zda soubor obsahuje skryté snímky a kolik jich je?**

Procházejte [slide collection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slidecollection/) a kontrolujte příznak [visibility](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slide/gethidden/) každého snímku.

**Mohu zjistit, zda jsou použity vlastní velikosti a orientace snímků a zda se liší od výchozích?**

Ano. Porovnejte aktuální [slide size](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/getslidesize/) a orientaci se standardními předvolbami; to pomáhá předvídat chování při tisku a exportu.

**Existuje rychlý způsob, jak zjistit, zda grafy odkazují na externí zdroje dat?**

Ano. Projděte všechny [charts](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chart/) , zkontrolujte jejich [data source](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdata/getdatasourcetype/) a zaznamenejte, zda jsou data interní nebo odkazována, včetně případných neplatných odkazů.

**Jak mohu posoudit „těžké“ snímky, které mohou zpomalovat vykreslování nebo export do PDF?**

Pro každý snímek spočítejte počet objektů a hledejte velké obrázky, průhlednost, stíny, animace a multimédia; přiřaďte hrubé skóre složitosti pro označení potenciálních výkonových úzkých míst.