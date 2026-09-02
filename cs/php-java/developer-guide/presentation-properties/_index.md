---
title: Správa vlastností prezentace v PHP
linktitle: Vlastnosti prezentace
type: docs
weight: 70
url: /cs/php-java/presentation-properties/
keywords:
- vlastnosti PowerPointu
- vlastnosti prezentace
- vlastnosti dokumentu
- vestavěné vlastnosti
- vlastní vlastnosti
- pokročilé vlastnosti
- správa vlastností
- úprava vlastností
- metadata dokumentu
- úprava metadat
- jazyk pravopisu
- výchozí jazyk
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Ovládněte vlastnosti prezentace v Aspose.Slides pro PHP přes Java a zefektivněte vyhledávání, brandování a pracovní postup ve vašich souborech PowerPoint a OpenDocument."
---
## **Úvod**

Aspose.Slides podporuje dva typy vlastností dokumentu: **Built-in** a **Custom**. Oba tyto typy vlastností lze snadno získat a spravovat pomocí API Aspose.Slides.

Aspose.Slides vám umožňuje pracovat s vlastnostmi dokumentu prezentace prostřednictvím třídy [DocumentProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/documentproperties/) . Instance této třídy je vrácena metodou [Presentation::getDocumentProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#getDocumentProperties) . Následující příklady ukazují, jak číst, upravovat a spravovat tyto vlastnosti.

{{% alert color="info" title="Note" %}}
Všimněte si, že pole **Application** a **AppVersion** nelze upravit. Aspose.Slides je přepíše při každém uložení, takže uložená prezentace vždy uvádí „Aspose.Slides for PHP via Java“ a verzi knihovny, která ji vytvořila. Jakákoli hodnota předaná metodě `setNameOfApplication` je při zápisu prezentace zahozena.
{{% /alert %}} 

## **Správa vlastností prezentace**

Microsoft PowerPoint poskytuje funkci pro přidání některých vlastností do souborů prezentace. Tyto vlastnosti dokumentu umožňují uložit užitečné informace spolu s dokumenty (soubory prezentace). Existují dva typy vlastností dokumentu:

- Systémově definované (Built-in) vlastnosti
- Uživatelsky definované (Custom) vlastnosti

**Built-in** vlastnosti obsahují obecné informace o dokumentu, jako je název dokumentu, jméno autora, statistiky dokumentu a podobně. **Custom** vlastnosti jsou ty, které uživatelé definují jako páry **Name/Value**, kde jak název, tak hodnota jsou definovány uživatelem. Pomocí Aspose.Slides for PHP via Java mohou vývojáři přistupovat k hodnotám vestavěných i vlastních vlastností a měnit je.

## **Vlastnosti dokumentu v PowerPointu**

Microsoft PowerPoint 2007 umožňuje spravovat vlastnosti dokumentu souborů prezentace. Stačí kliknout na ikonu Office a dále na položku nabídky **Prepare | Properties | Advanced Properties** v Microsoft PowerPoint 2007, jak je ukázáno níže:

|**Výběr položky nabídky Pokročilé vlastnosti**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Po výběru položky **Advanced Properties** se zobrazí dialog, který umožňuje spravovat vlastnosti dokumentu souboru PowerPoint, jak je znázorněno na obrázku níže:

|**Dialog Vlastností**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

V tomto **Dialogu Vlastností** můžete vidět mnoho záložek, jako **General**, **Summary**, **Statistics**, **Contents** a **Custom**. Všechny tyto záložky umožňují konfigurovat různé typy informací souvisejících se soubory PowerPoint. Záložka **Custom** slouží k správě vlastních vlastností souborů PowerPoint.

## **Práce s vlastnostmi dokumentu pomocí Aspose.Slides for PHP via Java**

Jak jsme již dříve popsali, Aspose.Slides for PHP via Java podporuje dva typy vlastností dokumentu, které jsou **Built-in** a **Custom**. Vývojáři tedy mohou přistupovat k oběma typům vlastností pomocí API Aspose.Slides for PHP via Java. Aspose.Slides for PHP via Java poskytuje třídu [DocumentProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/documentproperties) , která představuje vlastnosti dokumentu spojené se souborem prezentace prostřednictvím vlastnosti **Presentation.DocumentProperties**.

Vývojáři mohou použít vlastnost **DocumentProperties**, kterou exponuje objekt [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation) , k přístupu k vlastnostem dokumentu souborů prezentace, jak je popsáno níže:

## **Přístup k vestavěným (Built-in) vlastnostem**

Tyto vlastnosti, které jsou vystaveny objektem [DocumentProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/documentproperties) , zahrnují: **Creator** (Author), **Description**, **Keywords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **Keywords**, **SharedDoc** (Is shared between different producers?), **PresentationFormat**, **Subject** a **Title**.

```php
  # Vytvořte instanci třídy Presentation, která představuje prezentaci
  $pres = new Presentation("Presentation.pptx");
  try {
    # Vytvořte odkaz na objekt IDocumentProperties přidružený k prezentaci
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

## **Úprava vestavěných (Built-in) vlastností**

Úprava vestavěných vlastností souborů prezentace je tak snadná jako k nim přístup. Jednoduše přiřadíte řetězcovou hodnotu k požadované vlastnosti a hodnota vlastnosti bude změněna. V níže uvedeném příkladu jsme ukázali, jak lze pomocí Aspose.Slides for PHP via Java upravit vestavěné vlastnosti dokumentu prezentace.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Vytvořte odkaz na objekt IDocumentProperties přidružený k prezentaci
    $dp = $pres->getDocumentProperties();
    # Nastavte vestavěné vlastnosti
    $dp->setAuthor("Aspose.Slides for PHP via Java");
    $dp->setTitle("Modifying Presentation Properties");
    $dp->setSubject("Aspose Subject");
    $dp->setComments("Aspose Description");
    $dp->setManager("Aspose Manager");
    # Uložte svou prezentaci do souboru
    $pres->save("DocProps.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Tento příklad upravuje vestavěné vlastnosti prezentace, což lze vidět na následujícím obrázku:

|**Vlastnosti vestavěného dokumentu po úpravě**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Přidání vlastních (Custom) vlastností dokumentu**

Aspose.Slides for PHP via Java také umožňuje vývojářům přidat vlastní hodnoty pro vlastnosti dokumentu prezentace. Níže je uveden příklad, který ukazuje, jak nastavit vlastní vlastnosti pro prezentaci.

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
    # Ukládání prezentace
    $pres->save("CustomDemo.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|**Přidané vlastní (Custom) vlastnosti dokumentu**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Přístup a úprava vlastních (Custom) vlastností**

Aspose.Slides for PHP via Java také umožňuje vývojářům přistupovat k hodnotám vlastních vlastností. Níže je uveden příklad, který ukazuje, jak můžete přistupovat a upravovat všechny tyto vlastní vlastnosti pro prezentaci.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Vytvořte odkaz na objekt DocumentProperties přidružený k prezentaci
    $dp = $pres->getDocumentProperties();
    # Přístup a úprava vlastních vlastností
    for($i = 0; $i < java_values($dp->getCountOfCustomProperties()) ; $i++) {
      # Zobrazte názvy a hodnoty vlastních vlastností
      echo("Custom Property Name : " . $dp->getCustomPropertyName($i));
      echo("Custom Property Value : " . $dp->get_Item($dp->getCustomPropertyName($i)));
      # Upravení hodnot vlastních vlastností
      $dp->set_Item($dp->getCustomPropertyName($i), "New Value " . $i + 1);
    }
    # Uložte svou prezentaci do souboru
    $pres->save("CustomDemoModified.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Tento příklad upravuje vlastní vlastnosti [PPTX ](https://docs.fileformat.com/presentation/pptx/)prezentace. Následující obrázky ukazují vlastní vlastnosti prezentace před a po úpravě:

|**Vlastní vlastnosti před úpravou**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Vlastní vlastnosti po úpravě**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Pokročilé vlastnosti dokumentu**

{{% alert color="info" title="Note" %}}
Byly přidány nové metody [readDocumentProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/PresentationInfo/#readDocumentProperties), [updateDocumentProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) a [writeBindedPresentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/PresentationInfo/#writeBindedPresentation) do třídy [PresentationInfo](https://reference.aspose.com/slides/cs/php-java/aspose.slides/PresentationInfo) , logika setteru vlastnosti [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/cs/php-java/aspose.slides/documentproperties/#setLastSavedTime) byla změněna.
{{% /alert %}} 

Tyto dvě nové metody [readDocumentProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/PresentationInfo/#readDocumentProperties) a [updateDocumentProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) byly přidány do třídy [PresentationInfo](https://reference.aspose.com/slides/cs/php-java/aspose.slides/PresentationInfo) . Poskytují rychlý přístup k vlastnostem dokumentu a umožňují měnit a aktualizovat vlastnosti bez načtení celé prezentace.

Typický scénář načtení vlastností, změna některé hodnoty a aktualizace dokumentu lze implementovat následujícím způsobem:

```php
  # načtěte informace o prezentaci
  $info = PresentationFactory->getInstance()->getPresentationInfo("presentation.pptx");
  # získejte aktuální vlastnosti
  $props = $info->readDocumentProperties();
  # nastavte nové hodnoty polí Author a Title
  $props->setAuthor("New Author");
  $props->setTitle("New Title");
  # aktualizujte prezentaci s novými hodnotami
  $info->updateDocumentProperties($props);
  $info->writeBindedPresentation("presentation.pptx");
```

Dalším způsobem je použít vlastnosti konkrétní prezentace jako šablonu pro aktualizaci vlastností v dalších prezentacích:

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

Novou šablonu lze vytvořit od začátku a poté použít k aktualizaci více prezentací:

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

## **Nastavení jazykové kontroly**

Aspose.Slides poskytuje vlastnost LanguageId (exponovanou třídou PortionFormat), která umožňuje nastavit jazykovou kontrolu pro dokument PowerPoint. Jazyková kontrola je jazyk, pro který jsou ve PowerPointu kontrolovány pravopis a gramatika.

Tento PHP kód ukazuje, jak nastavit jazykovou kontrolu pro PowerPoint: xxx Why is LanguageId missing from Java PortionFormat class?

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();
    $newPortion = new Portion();
    $font = new FontData("SimSun");
    $portionFormat = $newPortion->getPortionFormat();
    $portionFormat->setComplexScriptFont($font);
    $portionFormat->setEastAsianFont($font);
    $portionFormat->setLatinFont($font);
    $portionFormat->setLanguageId("zh-CN");// nastavte Id jazykové kontroly

    $newPortion->setText("1。");
    $paragraph->getPortions()->add($newPortion);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Nastavení výchozího jazyka**

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

Vyzkoušejte online aplikaci [**Aspose.Slides Metadata**](https://products.aspose.app/slides/cs/metadata) a zjistěte, jak pracovat s vlastnostmi dokumentu pomocí Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/cs/metadata)

## **Často kladené otázky**

**Jak mohu odebrat vestavěnou vlastnost z prezentace?**

Vestavěné vlastnosti jsou nedílnou součástí prezentace a nelze je zcela odstranit. Můžete však jejich hodnoty změnit nebo je nastavit na prázdné, pokud to konkrétní vlastnost umožňuje.

**Co se stane, když přidám vlastní vlastnost, která již existuje?**

Pokud přidáte vlastní vlastnost, která již existuje, její stávající hodnota bude přepsána novou. Nemusíte ji předtím odstraňovat ani kontrolovat, protože Aspose.Slides automaticky aktualizuje hodnotu vlastnosti.

**Mohu přistupovat k vlastnostem prezentace bez úplného načtení prezentace?**

Ano. Použijte [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationfactory/) a poté [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationinfo/#readDocumentProperties) k načtení uložených metadat dokumentu bez vytvoření instance [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) . Viz [Build a Lightweight Presentation Inventory](/slides/cs/php-java/examine-presentation/) pro kompletní příklad reportingu a omezení specifických formátů.