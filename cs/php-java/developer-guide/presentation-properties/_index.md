---
title: Správa vlastností prezentace v PHP
linktitle: Vlastnosti prezentace
type: docs
weight: 70
url: /cs/php-java/presentation-properties/
keywords:
- Vlastnosti PowerPointu
- vlastnosti prezentace
- vlastnosti dokumentu
- vestavěné vlastnosti
- vlastní vlastnosti
- pokročilé vlastnosti
- spravovat vlastnosti
- upravit vlastnosti
- metadata dokumentu
- úprava metadat
- jazyk kontroly pravopisu
- výchozí jazyk
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Ovládejte vlastnosti prezentace v Aspose.Slides pro PHP via Java a zefektivněte vyhledávání, značkování a pracovní postup ve vašich souborech PowerPoint a OpenDocument."
---
## **Úvod**

Aspose.Slides podporuje dva typy vlastností dokumentu: **Built-in** a **Custom**. Oba tyto typy vlastností lze snadno přistupovat a spravovat pomocí API Aspose.Slides.

Aspose.Slides vám umožňuje pracovat s vlastnostmi dokumentu prezentace prostřednictvím třídy [DocumentProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/documentproperties/) . Instance této třídy je vrácena metodou [Presentation::getDocumentProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#getDocumentProperties). Následující příklady ukazují, jak číst, upravovat a spravovat tyto vlastnosti.

{{% alert color="info" title="Note" %}}
Upozorňujeme, že pole **Application** a **AppVersion** nelze upravit. Aspose.Slides je přepisuje při každém uložení, takže uložená prezentace vždy uvádí „Aspose.Slides for PHP via Java“ a verzi knihovny, která ji vytvořila. Jakákoli hodnota předaná metodě `setNameOfApplication` je při zápisu prezentace zahozena.
{{% /alert %}}

## **Správa vlastností prezentace**

Microsoft PowerPoint poskytuje funkci pro přidání některých vlastností k souborům prezentací. Tyto vlastnosti dokumentu umožňují uložit užitečné informace společně s dokumenty (soubory prezentací). Existují dva druhy vlastností dokumentu, jak následuje

- Systémově definované (Built-in) vlastnosti
- Uživatelem definované (Custom) vlastnosti

**Built-in** vlastnosti obsahují obecné informace o dokumentu, jako je název dokumentu, jméno autora, statistiky dokumentu atd. **Custom** vlastnosti jsou ty, které uživatelé definují jako páry **Name/Value**, kde jak název, tak hodnota jsou definovány uživatelem. Pomocí Aspose.Slides for PHP via Java mohou vývojáři přistupovat k hodnotám built-in vlastností i k vlastnostem custom.

## **Vlastnosti dokumentu v PowerPointu**

Microsoft PowerPoint 2007 umožňuje spravovat vlastnosti dokumentu souborů prezentací. Stačí kliknout na ikonu Office a dále na položku nabídky **Prepare | Properties | Advanced Properties** v Microsoft PowerPoint 2007, jak je znázorněno níže:

|**Výběr položky nabídky Advanced Properties**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Po výběru položky **Advanced Properties** se zobrazí dialogové okno, které vám umožní spravovat vlastnosti dokumentu souboru PowerPoint, jak je znázorněno níže na obrázku:

|**Dialog vlastností**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

V výše uvedeném **Dialogu vlastností** můžete vidět, že existuje mnoho záložek jako **General**, **Summary**, **Statistics**, **Contents** a **Custom**. Všechny tyto záložky umožňují konfigurovat různé typy informací souvisejících se soubory PowerPoint. Záložka **Custom** slouží ke správě vlastností custom v souborech PowerPoint.

Práce s vlastnostmi dokumentu pomocí Aspose.Slides for PHP via Java

Jak jsme již dříve popsali, Aspose.Slides for PHP via Java podporuje dva druhy vlastností dokumentu, **Built-in** a **Custom**. Vývojáři tak mohou přistupovat k oběma druhům vlastností pomocí API Aspose.Slides for PHP via Java. Aspose.Slides for PHP via Java poskytuje třídu [DocumentProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/documentproperties), která představuje vlastnosti dokumentu spojené se souborem prezentace prostřednictvím vlastnosti **Presentation.DocumentProperties**.

Vývojáři mohou použít vlastnost **DocumentProperties** vystavenou objektem [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation) k přístupu k vlastnostem dokumentu souborů prezentací, jak je popsáno níže:

## **Čtení veřejných vlastností z šifrované prezentace**

Otevírací heslo obvykle chrání jak obsah prezentace, tak vlastnosti dokumentu. Když je prezentace zašifrována předáním hodnoty `false` metodě [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties), její vlastnosti dokumentu zůstávají veřejné. Aplikace pak může předat `true` metodě [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) a načíst veřejná metadata bez zadání otevíracího hesla.

Volba načítání pouze vlastností dokumentu určuje, co Aspose.Slides načte; neprovádí žádné dešifrování. Pokud byly vlastnosti zahrnuty do šifrování, načtení bez hesla selže. Pokud prezentace není zašifrována, volba se ignoruje a načte se celá prezentace.

Následující příklad ověřuje režim načítání pomocí [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/cs/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) a poté čte built-in vlastnosti pomocí [Presentation::getDocumentProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#getDocumentProperties):

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setOnlyLoadDocumentProperties(true);

$presentation = new Presentation("public-properties-encrypted.pptx", $loadOptions);
try {
    if (java_values($presentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        $properties = $presentation->getDocumentProperties();

        echo("Author: " . $properties->getAuthor() . "\n");
        echo("Title: " . $properties->getTitle() . "\n");
        echo("Keywords: " . $properties->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode.\n");
    }
} finally {
    $presentation->dispose();
}
```

V tomto režimu se nenačítá obsah snímků. Snímek, mastery, rozvržení, tvary, média a další objekty prezentace nejsou dostupné. Aplikace by měly vždy zkontrolovat [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/cs/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) před provedením operace, která vyžaduje kompletní model objektů prezentace.

{{% alert color="warning" title="Warning" %}}
Veřejná metadata mohou odhalit jména autorů, názvy, předměty, klíčová slova, informace o společnosti, komentáře a vlastní hodnoty. Šifrujte citlivé vlastnosti spolu s prezentací. Nechte je veřejné pouze v případě, že indexovací, klasifikační, vyhledávací nebo systémy správy dokumentů mají konkrétní požadavek na přístup k nim bez hesla.
{{% /alert %}}

## **Aktualizace vlastností šifrované prezentace**

Pro šifrovaný soubor PPTX je prezentace načtená v režimu pouze vlastností dokumentu určena k čtení veřejných metadat. Aspose.Slides nemůže uložit změněné vlastnosti z tohoto objektu pouze s metadaty, protože veřejné vlastnosti musí zůstat v souladu s odpovídajícími daty v šifrované prezentaci. Aktualizace tedy vyžaduje správné otevírací heslo a kompletní načtení.

Následující příklad otevře prezentaci pomocí [LoadOptions::setPassword](https://reference.aspose.com/slides/cs/php-java/aspose.slides/loadoptions/#setPassword), aktualizuje veřejné built-in vlastnosti a výsledek uloží. Pak použije [PresentationInfo::isEncrypted](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationinfo/#isEncrypted) k ověření, že šifrování bylo zachováno, a znovu otevře veřejná metadata bez hesla pro ověření nových hodnot:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;
use aspose\slides\SaveFormat;

$inputPath = "public-properties-encrypted.pptx";
$outputPath = "updated-public-properties-encrypted.pptx";

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation($inputPath, $loadOptions);
try {
    $presentation->getDocumentProperties()->setTitle("Updated Product Roadmap");
    $presentation->getDocumentProperties()->setKeywords("roadmap, planning, indexed");
    $presentation->save($outputPath, SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($outputPath);
echo("The presentation is encrypted: " . (java_values($presentationInfo->isEncrypted()) ? "true" : "false") . "\n");

$metadataLoadOptions = new LoadOptions();
$metadataLoadOptions->setOnlyLoadDocumentProperties(true);

$metadataPresentation = new Presentation($outputPath, $metadataLoadOptions);
try {
    if (java_values($metadataPresentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        echo("Title: " . $metadataPresentation->getDocumentProperties()->getTitle() . "\n");
        echo("Keywords: " . $metadataPresentation->getDocumentProperties()->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode.\n");
    }
} finally {
    $metadataPresentation->dispose();
}
```

Pokud aplikace nemá povoleno dešifrovat nebo načíst obsah prezentace, musí veřejné vlastnosti šifrovaného souboru PPTX považovat za pouze ke čtení.

## **Přístup k built-in vlastnostem**

Tyto vlastnosti, které jsou vystaveny objektem [DocumentProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/documentproperties), zahrnují: **Creator** (Autor), **Description**, **Keywords**, **Created** (Datum vytvoření), **Modified** (Datum úpravy), **Printed** (Datum posledního tisku), **LastModifiedBy**, **Keywords**, **SharedDoc** (Je sdíleno mezi různými tvůrci?), **PresentationFormat**, **Subject** a **Title**.

```php
  # Instancujte třídu Presentation, která představuje prezentaci
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

## **Úprava built-in vlastností**

Úprava built-in vlastností souborů prezentace je stejně snadná jako jejich přístup. Jednoduše můžete přiřadit řetězcovou hodnotu libovolné požadované vlastnosti a hodnota vlastnosti bude změněna. V níže uvedeném příkladu jsme ukázali, jak lze pomocí Aspose.Slides for PHP via Java upravit built-in vlastnosti dokumentu prezentace.

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

Tento příklad upravuje built-in vlastnosti prezentace, které lze zobrazit níže:

|**Built-in vlastnosti dokumentu po úpravě**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Přidání vlastních dokumentových vlastností**

Aspose.Slides for PHP via Java také umožňuje vývojářům přidávat vlastní hodnoty pro vlastnosti dokumentu prezentace. Níže je uveden příklad, který ukazuje, jak nastavit vlastní vlastnosti pro prezentaci.

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
    # Odebrání vybrané vlastnosti
    $dProps->removeCustomProperty($getPropertyName);
    # Uložení prezentace
    $pres->save("CustomDemo.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|**Vlastní dokumentové vlastnosti přidány**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Přístup a úprava vlastních vlastností**

Aspose.Slides for PHP via Java také umožňuje vývojářům přistupovat k hodnotám vlastních vlastností. Níže je uveden příklad, který ukazuje, jak můžete přistupovat a upravovat všechny tyto vlastní vlastnosti pro prezentaci.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Vytvořte odkaz na objekt DocumentProperties spojený s prezentací
    $dp = $pres->getDocumentProperties();
    # Přístup a úprava vlastních vlastností
    for($i = 0; $i < java_values($dp->getCountOfCustomProperties()) ; $i++) {
      # Zobrazte názvy a hodnoty vlastních vlastností
      echo("Custom Property Name : " . $dp->getCustomPropertyName($i));
      echo("Custom Property Value : " . $dp->get_Item($dp->getCustomPropertyName($i)));
      # Upravit hodnoty vlastních vlastností
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

Tento příklad upravuje vlastní vlastnosti [PPTX ](https://docs.fileformat.com/presentation/pptx/) prezentace. Následující obrázky ukazují vlastní vlastnosti prezentace před a po úpravě:

|**Vlastní vlastnosti před úpravou**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Vlastní vlastnosti po úpravě**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Pokročilé vlastnosti dokumentu**

{{% alert color="info" title="Note" %}}
Do třídy [PresentationInfo](https://reference.aspose.com/slides/cs/php-java/aspose.slides/PresentationInfo) byly přidány nové metody [readDocumentProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/PresentationInfo/#readDocumentProperties), [updateDocumentProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) a [writeBindedPresentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/PresentationInfo/#writeBindedPresentation). Logika setteru vlastnosti [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/cs/php-java/aspose.slides/documentproperties/#setLastSavedTime) byla změněna.
{{% /alert %}}

Dvě nové metody [readDocumentProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/PresentationInfo/#readDocumentProperties) a [updateDocumentProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) byly přidány do třídy [PresentationInfo](https://reference.aspose.com/slides/cs/php-java/aspose.slides/PresentationInfo). Poskytují rychlý přístup k vlastnostem dokumentu a umožňují měnit a aktualizovat vlastnosti bez načítání celé prezentace.

Typický scénář načtení vlastností, změny některých hodnot a aktualizace dokumentu lze implementovat následujícím způsobem:

```php
  # načtěte informace o prezentaci
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

Nová šablona může být vytvořena od začátku a poté použita k aktualizaci více prezentací:

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

## **Nastavení jazyka kontroly pravopisu**

Aspose.Slides poskytuje vlastnost LanguageId (vystavenou třídou PortionFormat), která vám umožňuje nastavit jazyk kontroly pravopisu pro dokument PowerPoint. Jazyk kontroly pravopisu je jazyk, pro který jsou v PowerPointu kontrolovány pravopis a gramatika.

Tento PHP kód vám ukazuje, jak nastavit jazyk kontroly pravopisu pro PowerPoint: xxx Proč chybí LanguageId ve třídě Java PortionFormat?

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
    $portionFormat->setLanguageId("zh-CN");// nastavit Id jazykové kontroly pravopisu

    $newPortion->setText("1。");
    $paragraph->getPortions()->add($newPortion);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Nastavení výchozího jazyka**

Tento PHP kód vám ukazuje, jak nastavit výchozí jazyk pro celou prezentaci PowerPoint:

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

Vyzkoušejte online aplikaci [**Aspose.Slides Metadata**](https://products.aspose.app/slides/cs/metadata), abyste viděli, jak pracovat s vlastnostmi dokumentu pomocí API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/cs/metadata)

## **Často kladené otázky**

**Jak mohu odstranit built-in vlastnost z prezentace?**

Built-in vlastnosti jsou nedílnou součástí prezentace a nelze je zcela odstranit. Můžete však změnit jejich hodnoty nebo je nastavit na prázdné, pokud to konkrétní vlastnost umožňuje.

**Co se stane, když přidám vlastní vlastnost, která již existuje?**

Pokud přidáte vlastní vlastnost, která již existuje, její současná hodnota bude přepsána novou. Nemusíte vlastnost předem odstraňovat nebo kontrolovat, protože Aspose.Slides automaticky aktualizuje hodnotu vlastnosti.

**Mohu přistupovat k vlastnostem prezentace bez úplného načtení prezentace?**

Ano. Použijte [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationfactory/) a poté [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentationinfo/#readDocumentProperties) k načtení uložených metadat dokumentu bez vytvoření instance [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/). Viz [Build a Lightweight Presentation Inventory](/slides/cs/php-java/examine-presentation/) pro kompletní příklad reportování a omezení specifických formátů.

**Mohu číst veřejné vlastnosti šifrované prezentace bez jejího otevíracího hesla?**

Ano. Šifrování vlastností dokumentu muselo být vypnuto před tím, než byla prezentace zašifrována, a prezentace musí být načtena v režimu pouze vlastností dokumentu.

**Mohu aktualizovat šifrovaný soubor PPTX v režimu pouze vlastností dokumentu?**

Ne. Veřejná a šifrovaná data vlastností musí zůstat konzistentní, proto aktualizace šifrovaného souboru PPTX vyžaduje načtení celé prezentace s správným otevíracím heslem.