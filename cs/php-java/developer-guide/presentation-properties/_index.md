---
title: Správa vlastností prezentace v PHP
linktitle: Vlastnosti prezentace
type: docs
weight: 70
url: /cs/php-java/presentation-properties/
keywords:
- Vlastnosti PowerPointu
- Vlastnosti prezentace
- Vlastnosti dokumentu
- Vestavěné vlastnosti
- Vlastní vlastnosti
- Rozšířené vlastnosti
- Spravovat vlastnosti
- Upravit vlastnosti
- Metadata dokumentu
- Upravit metadata
- Jazyk kontroly pravopisu
- Výchozí jazyk
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Zvládněte vlastnosti prezentace v Aspose.Slides pro PHP přes Java a zjednodušte vyhledávání, brandování a workflow ve vašich souborech PowerPoint a OpenDocument."
---
## **Úvod**

Aspose.Slides podporuje dva typy vlastností dokumentu: **Built-in** a **Custom**. Oba tyto typy vlastností lze snadno přistupovat a spravovat pomocí API Aspose.Slides.

Aspose.Slides vám umožňuje pracovat s vlastnostmi dokumentu prezentace prostřednictvím třídy [DocumentProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/documentproperties/). Instanci této třídy vrací metoda [Presentation::getDocumentProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#getDocumentProperties). Následující příklady ukazují, jak číst, upravovat a spravovat tyto vlastnosti.

{{% alert color="primary" %}} 
Upozorňujeme, že pole **Application** a **Producer** nelze upravit, protože tato pole vždy zobrazí „Aspose Ltd.“ a „Aspose.Slides for PHP via Java x.x.x“.
{{% /alert %}} 

## **Správa vlastností prezentace**

Microsoft PowerPoint poskytuje funkci pro přidání některých vlastností do souborů prezentací. Tyto vlastnosti dokumentu umožňují uložit užitečné informace spolu s dokumenty (soubory prezentací). Existují dva typy vlastností dokumentu, jak následuje:

- Systémové definované (Built-in) vlastnosti
- Uživatelsky definované (Custom) vlastnosti

**Built-in** vlastnosti obsahují obecné informace o dokumentu, jako je název dokumentu, jméno autora, statistika dokumentu a podobně. **Custom** vlastnosti jsou ty, které uživatelé definují jako páry **Název/Hodnota**, kde jak název, tak hodnota jsou definovány uživatelem. Pomocí Aspose.Slides pro PHP přes Java mohou vývojáři přistupovat a upravovat hodnoty vestavěných i uživatelských vlastností.

## **Vlastnosti dokumentu v PowerPointu**

Microsoft PowerPoint 2007 umožňuje spravovat vlastnosti dokumentu souborů prezentací. Vše, co musíte udělat, je kliknout na ikonu Office a následně na položku nabídky **Prepare | Properties | Advanced Properties** v Microsoft PowerPoint 2007, jak je znázorněno níže:

|**Výběr položky nabídky Advanced Properties**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Po výběru položky **Advanced Properties** se zobrazí dialogové okno, které vám umožní spravovat vlastnosti dokumentu souboru PowerPoint, jak je znázorněno níže na obrázku:

|**Dialog Vlastnosti**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

V výše uvedeném **Dialogu Vlastnosti** můžete vidět, že existuje mnoho záložek, jako **General**, **Summary**, **Statistics**, **Contents** a **Custom**. Všechny tyto záložky umožňují konfigurovat různé typy informací souvisejících se soubory PowerPoint. Záložka **Custom** slouží ke správě uživatelských vlastností souborů PowerPoint.

Práce s vlastnostmi dokumentu pomocí Aspose.Slides pro PHP přes Java

Jak jsme již dříve popsali, Aspose.Slides pro PHP přes Java podporuje dva typy vlastností dokumentu, a to **Built-in** a **Custom** vlastnosti. Vývojáři tak mohou přistupovat k oběma typům vlastností pomocí API Aspose.Slides pro PHP přes Java. Aspose.Slides pro PHP přes Java poskytuje třídu [DocumentProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/documentproperties), která představuje vlastnosti dokumentu spojené se souborem prezentace prostřednictvím vlastnosti **Presentation.DocumentProperties**.

Vývojáři mohou použít vlastnost **DocumentProperties**, kterou vystavuje objekt [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation), k přístupu k vlastnostem dokumentu souborů prezentací, jak je popsáno níže:

## **Přístup k vestavěným vlastnostem**

Tyto vlastnosti, které vystavuje objekt [DocumentProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/documentproperties), zahrnují: **Creator** (Autor), **Description**, **Keywords**, **Created** (Datum vytvoření), **Modified** (Datum úpravy), **Printed** (Datum posledního tisku), **LastModifiedBy**, **Keywords**, **SharedDoc** (Je sdílen mezi různými producenty?), **PresentationFormat**, **Subject** a **Title**.

```php
  # Vytvořte instanci třídy Presentation, která představuje prezentaci
  $pres = new Presentation("Presentation.pptx");
  try {
    # Vytvořte odkaz na objekt IDocumentProperties spojený s prezentací
    $dp = $pres->getDocumentProperties();
    # Zobrazte vestavěné vlastnosti
    echo("Category : " . $dp->getCategory());
    echo("Current Status : " . $dp->getContentStatus());
    echo("Creation Date : " . $dp->getCreatedTime());
    echo("Author : " . $dp->getAuthor());
    echo("Description : " . $dp->getComments());
    echo("KeyWords : " . $dp->getKeywords());
    echo("Last Modified By : " . $dp->getLastSavedBy());
    echo("Supervisor : " . $dp->getManager());
    echo("Modified Date : " . $dp->getLastSavedTime());
    echo("Presentation Format : " . $dp->getPresentationFormat());
    echo("Last Print Date : " . $dp->getLastPrinted());
    echo("Is Shared between producers : " . $dp->getSharedDoc());
    echo("Subject : " . $dp->getSubject());
    echo("Title : " . $dp->getTitle());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Upravit vestavěné vlastnosti**

Úprava vestavěných vlastností souborů prezentací je tak snadná jako jejich přístup. Jednoduše přiřadíte řetězcovou hodnotu k libovolné požadované vlastnosti a hodnota vlastnosti bude upravena. V níže uvedeném příkladu jsme ukázali, jak můžeme upravit vestavěné vlastnosti dokumentu souboru prezentace pomocí Aspose.Slides pro PHP přes Java.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Vytvořte odkaz na objekt IDocumentProperties spojený s prezentací
    $dp = $pres->getDocumentProperties();
    # Nastavte vestavěné vlastnosti
    $dp->setAuthor("Aspose.Slides for PHP via Java");
    $dp->setTitle("Modifying Presentation Properties");
    $dp->setSubject("Aspose Subject");
    $dp->setComments("Aspose Description");
    $dp->setManager("Aspose Manager");
    # Uložte prezentaci do souboru
    $pres->save("DocProps.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Tento příklad upravuje vestavěné vlastnosti prezentace, které lze zobrazit níže:

|**Vestavěné vlastnosti dokumentu po úpravě**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Přidat uživatelské vlastnosti dokumentu**

Aspose.Slides pro PHP přes Java také umožňuje vývojářům přidat vlastní hodnoty pro vlastnosti dokumentu prezentace. Níže je uveden příklad, který ukazuje, jak nastavit vlastní vlastnosti pro prezentaci.

```php
  $pres = new Presentation();
  try {
    # Získání vlastností dokumentu
    $dProps = $pres->getDocumentProperties();
    # Přidání vlastních vlastností
    $dProps->set_Item("New Custom", 12);
    $dProps->set_Item("My Name", "Mudassir");
    $dProps->set_Item("Custom", 124);
    # Získání názvu vlastnosti na konkrétním indexu
    $getPropertyName = $dProps->getCustomPropertyName(2);
    # Odstranění vybrané vlastnosti
    $dProps->removeCustomProperty($getPropertyName);
    # Uložení prezentace
    $pres->save("CustomDemo.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|**Přidány vlastní vlastnosti dokumentu**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Přístup a úprava vlastních vlastností**

Aspose.Slides pro PHP přes Java také umožňuje vývojářům přistupovat k hodnotám vlastních vlastností. Níže je uveden příklad, který ukazuje, jak můžete přistupovat a upravovat všechny tyto vlastní vlastnosti pro prezentaci.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Vytvořte odkaz na objekt DocumentProperties spojený s prezentací
    $dp = $pres->getDocumentProperties();
    # Přístup k vlastním vlastnostem a jejich úprava
    for($i = 0; $i < java_values($dp->getCountOfCustomProperties()) ; $i++) {
      # Zobrazte názvy a hodnoty vlastních vlastností
      echo("Custom Property Name : " . $dp->getCustomPropertyName($i));
      echo("Custom Property Value : " . $dp->get_Item($dp->getCustomPropertyName($i)));
      # Upravte hodnoty vlastních vlastností
      $dp->set_Item($dp->getCustomPropertyName($i), "New Value " . $i + 1);
    }
    # Uložte prezentaci do souboru
    $pres->save("CustomDemoModified.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Tento příklad upravuje vlastní vlastnosti [PPTX](https://docs.fileformat.com/presentation/pptx/) prezentace. Následující obrázky ukazují vlastní vlastnosti prezentace před a po úpravě:

|**Vlastní vlastnosti před úpravou**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Vlastní vlastnosti po úpravě**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Rozšířené vlastnosti dokumentu**

{{% alert color="primary" %}} 
Byly přidány nové metody [readDocumentProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/PresentationInfo/#readDocumentProperties), [updateDocumentProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) a [writeBindedPresentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/PresentationInfo/#writeBindedPresentation) do třídy [PresentationInfo](https://reference.aspose.com/slides/cs/php-java/aspose.slides/PresentationInfo), logika setteru vlastnosti [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/cs/php-java/aspose.slides/documentproperties/#setLastSavedTime) byla změněna.
{{% /alert %}} 

Do třídy [PresentationInfo](https://reference.aspose.com/slides/cs/php-java/aspose.slides/PresentationInfo) byly přidány dvě nové metody [readDocumentProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/PresentationInfo/#readDocumentProperties) a [updateDocumentProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties). Poskytují rychlý přístup k vlastnostem dokumentu a umožňují měnit a aktualizovat vlastnosti bez načítání celé prezentace.

Typický scénář načtení vlastností, změny některé hodnoty a aktualizace dokumentu lze implementovat následujícím způsobem:

```php
  # načíst informace o prezentaci
  $info = PresentationFactory->getInstance()->getPresentationInfo("presentation.pptx");
  # získat aktuální vlastnosti
  $props = $info->readDocumentProperties();
  # nastavit nové hodnoty polí Autor a Název
  $props->setAuthor("New Author");
  $props->setTitle("New Title");
  # aktualizovat prezentaci s novými hodnotami
  $info->updateDocumentProperties($props);
  $info->writeBindedPresentation("presentation.pptx");
```

Existuje další způsob, jak použít vlastnosti konkrétní prezentace jako šablonu pro aktualizaci vlastností v jiných prezentacích:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("template.pptx");
  $template = $info->readDocumentProperties();
  $template->setAuthor("Template Author");
  $template->setTitle("Template Title");
  $template->setCategory("Template Category");
  $template->setKeywords("Keyword1, Keyword2, Keyword3");
  $template->setCompany("Our Company");
  $template->setComments("Created from template");
  $template->setContentType("Template Content");
  $template->setSubject("Template Subject");
  updateByTemplate("doc1.pptx", $template);
  updateByTemplate("doc2.odp", $template);
  updateByTemplate("doc3.ppt", $template);
```

```php

```

Nová šablona může být vytvořena od nuly a poté použita k aktualizaci více prezentací:

```php
  $template = new DocumentProperties();
  $template->setAuthor("Template Author");
  $template->setTitle("Template Title");
  $template->setCategory("Template Category");
  $template->setKeywords("Keyword1, Keyword2, Keyword3");
  $template->setCompany("Our Company");
  $template->setComments("Created from template");
  $template->setContentType("Template Content");
  $template->setSubject("Template Subject");
  updateByTemplate("doc1.pptx", $template);
  updateByTemplate("doc2.odp", $template);
  updateByTemplate("doc3.ppt", $template);
```

## **Nastavit jazyk kontroly pravopisu**

Aspose.Slides poskytuje vlastnost LanguageId (vystavenou třídou PortionFormat), která vám umožňuje nastavit jazyk kontroly pravopisu pro dokument PowerPoint. Jazyk kontroly pravopisu je jazyk, pro který jsou v PowerPointu kontrolovány pravopis a gramatika.

Tento PHP kód ukazuje, jak nastavit jazyk kontroly pravopisu pro PowerPoint: xxx Proč v Java třídě PortionFormat chybí LanguageId?

```php
  $pres = new Presentation($pptxFileName);
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();
    $newPortion = new Portion();
    $font = new FontData("SimSun");
    $portionFormat = $newPortion->getPortionFormat();
    $portionFormat::setComplexScriptFont($font);
    $portionFormat::setEastAsianFont($font);
    $portionFormat::setLatinFont($font);
    $portionFormat::setLanguageId("zh-CN");// nastavit Id jazykové kontroly pravopisu

    $newPortion->setText("1。");
    $paragraph->getPortions()->add($newPortion);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Nastavit výchozí jazyk**

Tento PHP kód ukazuje, jak nastavit výchozí jazyk pro celou prezentaci PowerPoint:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setDefaultTextLanguage("en-US");
  $pres = new Presentation($loadOptions);
  try {
    # Přidá nový obdélníkový tvar s textem
    $shp = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    $shp->getTextFrame()->setText("New Text");
    # Zkontroluje jazyk první části
    echo($shp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getLanguageId());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Živý příklad**

Vyzkoušejte online aplikaci [**Aspose.Slides Metadata**](https://products.aspose.app/slides/cs/metadata) a uvidíte, jak pracovat s vlastnostmi dokumentu pomocí API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/cs/metadata)

## **Často kladené otázky**

**Jak mohu odebrat vestavěnou vlastnost z prezentace?**

Vestavěné vlastnosti jsou nedílnou součástí prezentace a nelze je zcela odstranit. Můžete však změnit jejich hodnoty nebo je nastavit na prázdnou, pokud to konkrétní vlastnost umožňuje.

**Co se stane, když přidám vlastní vlastnost, která již existuje?**

Pokud přidáte vlastní vlastnost, která již existuje, její stávající hodnota bude přepsána novou. Nemusíte vlastnost nejprve odstraňovat nebo kontrolovat, protože Aspose.Slides automaticky aktualizuje hodnotu vlastnosti.

**Mohu získat přístup k vlastnostem prezentace bez úplného načtení prezentace?**

Ano, můžete přistupovat k vlastnostem prezentace bez úplného načtení prezentace pomocí metody `getPresentationInfo` ze třídy [PresentationFactory](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationfactory/). Poté použijte metodu `readDocumentProperties` poskytovanou třídou [PresentationInfo](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationinfo/) pro efektivní načtení vlastností, čímž šetříte paměť a zvyšujete výkon.