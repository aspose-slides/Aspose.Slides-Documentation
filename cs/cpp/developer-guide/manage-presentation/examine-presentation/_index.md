---
title: Získání a aktualizace informací o prezentaci v C++
linktitle: Informace o prezentaci
type: docs
weight: 30
url: /cs/cpp/examine-presentation/
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
- C++
- Aspose.Slides
description: "Prozkoumejte snímky, strukturu a metadata v prezentacích PowerPoint a OpenDocument pomocí C++ pro rychlejší získání informací a inteligentnější audit obsahu."
---
## **Přehled**

Tento článek ukazuje, jak prozkoumat informace o prezentaci v Aspose.Slides. Vysvětluje, jak zjistit aktuální formát prezentace, aniž by bylo načteno celé soubor, přečíst její vlastnosti dokumentu a v případě potřeby tyto vlastnosti aktualizovat.

Příklady jsou založeny na API [PresentationInfo](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentationinfo/) a [DocumentProperties](https://reference.aspose.com/slides/cs/cpp/aspose.slides/documentproperties/) a ukazují typické operace pro práci s metadaty prezentace.

## **Zkontrolujte formát prezentace**

Před prací s prezentací možná budete chtít zjistit, v jakém formátu (PPT, PPTX, ODP a další) se prezentace aktuálně nachází.

Formát prezentace můžete ověřit, aniž byste načetli samotnou prezentaci. Viz následující C++ kód:

``` cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
// PPTX
Console::WriteLine(ObjectExt::ToString(info->get_LoadFormat()));

auto info2 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.ppt");
// PPT
Console::WriteLine(ObjectExt::ToString(info2->get_LoadFormat()));

auto info3 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.odp");
// ODP
Console::WriteLine(ObjectExt::ToString(info3->get_LoadFormat()));
```

## **Získání vlastností prezentace**

Tento C++ kód ukazuje, jak získat vlastnosti prezentace (informace o prezentaci):

``` cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
auto props = info->ReadDocumentProperties();
Console::WriteLine(ObjectExt::ToString(props->get_CreatedTime()));
Console::WriteLine(props->get_Subject());
Console::WriteLine(props->get_Title());
// .. 
```

## **Aktualizace vlastností prezentace**

Aspose.Slides poskytuje metodu [PresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentationinfo/updatedocumentproperties/), která umožňuje provádět změny ve vlastnostech prezentace.

Předpokládejme, že máme PowerPoint prezentaci se zobrazenými vlastnostmi dokumentu níže.

![Původní vlastnosti dokumentu PowerPoint prezentace](input_properties.png)

Tento příklad kódu ukazuje, jak upravit některé vlastnosti prezentace:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/date_time.h>
using namespace Aspose::Slides;
using namespace System;

auto fileName = u"sample.pptx";

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);

auto properties = info->ReadDocumentProperties();
properties->set_Title(u"My title");
properties->set_LastSavedTime(DateTime::get_Now());

info->UpdateDocumentProperties(properties);
info->WriteBindedPresentation(fileName);
```

Výsledky změny vlastností dokumentu jsou zobrazeny níže.

![Změněné vlastnosti dokumentu PowerPoint prezentace](output_properties.png)

## **Užitečné odkazy**

Pro získání více informací o prezentaci a jejích bezpečnostních atributech vám mohou být užitečné tyto odkazy:

- [Prezentace chráněné heslem](/slides/cs/cpp/password-protected-presentation/)
- [Prezentace chráněné proti zápisu](/slides/cs/cpp/write-protected-presentation/)

## **Často kladené otázky**

**Jak mohu zkontrolovat, zda jsou písma vložena a která konkrétně?**

Vyhledejte [informace o vložených písmenech](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontsmanager/getembeddedfonts/) na úrovni prezentace a poté porovnejte tyto položky se sadou [skutečně v obsahu použitých písem](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontsmanager/getfonts/) a zjistěte, která písma jsou pro vykreslování kritická.

**Jak mohu rychle zjistit, zda soubor obsahuje skryté snímky a kolik jich je?**

Procházejte [kolekci snímků](https://reference.aspose.com/slides/cs/cpp/aspose.slides/slidecollection/) a zkontrolujte [vlajku viditelnosti](https://reference.aspose.com/slides/cs/cpp/aspose.slides/slide/get_hidden/) každého snímku.

**Mohu zjistit, zda jsou použity vlastní velikost a orientace snímku, a zda se liší od výchozích?**

Ano. Porovnejte aktuální [velikost a orientaci snímku](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_slidesize/) se standardními předvolbami; to pomůže předvídat chování při tisku a exportu.

**Existuje rychlý způsob, jak zjistit, zda grafy odkazují na externí datové zdroje?**

Ano. Procházejte všechny [grafy](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/chart/), zkontrolujte jejich [datový zdroj](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/chartdata/get_datasourcetype/), a zaznamenejte, zda jsou data interní nebo odkazována, včetně případných nefunkčních odkazů.

**Jak mohu posoudit „těžké“ snímky, které mohou zpomalit vykreslování nebo export do PDF?**

U každého snímku spočítejte počet objektů a hledejte velké obrázky, průhlednost, stíny, animace a multimédia; přiřaďte hrubé skóre složitosti, abyste označili potenciální úzká místa výkonu.