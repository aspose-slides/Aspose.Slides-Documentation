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
- rozšířené vlastnosti
- správa vlastností
- úprava vlastností
- metadata dokumentu
- úprava metadat
- jazyk korektury
- výchozí jazyk
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Ovládněte vlastnosti prezentace v Aspose.Slides pro PHP přes Java a zefektivněte vyhledávání, značkování a workflow ve vašich souborech PowerPoint a OpenDocument."
---
## **Úvod**

Aspose.Slides pro PHP přes Java podporuje **vestavěné** a **vlastní** vlastnosti dokumentu. Použijte tyto vlastnosti ke čtení a aktualizaci metadat prezentace, jako jsou autor, název a uživatelem definované hodnoty.

Aspose.Slides umožňuje pracovat s vlastnostmi dokumentu prezentace prostřednictvím třídy [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/). Instance této třídy je vrácena metodou [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getdocumentproperties/). Následující příklady ukazují, jak číst, upravovat a spravovat tyto vlastnosti. Předpokládají, že je inicializován PHP/Java Bridge a obal Aspose.Slides pro PHP.

{{% alert color="info" title="Note" %}}
Aspose.Slides spravuje metadata aplikace a tvůrce při ukládání prezentací; tato pole identifikují software, který vytvořil výstup.
{{% /alert %}}

## **Spravovat vlastnosti prezentace**

Vlastnosti dokumentu ukládají popisné informace vedle obsahu prezentace. Rozdělují se do dvou kategorií:

- **Vestavěné vlastnosti** obsahují standardní metadata, jako je název, autor a statistiky dokumentu.
- **Vlastní vlastnosti** ukládají uživatelem definované páry jméno/hodnota.

Aspose.Slides pro PHP přes Java poskytuje přístup k oběma kategoriím. V PowerPointu vyberte **Soubor → Informace → Vlastnosti → Pokročilé vlastnosti** pro prohlédnutí metadat dokumentu. Dialog skupinuje informace do záložek jako **Shrnutí**, **Statistiky**, **Obsah** a **Vlastní**. V kartě **Vlastní** můžete spravovat uživatelem definované vlastnosti.

## **Čtení veřejných vlastností z šifrované prezentace**

Otevírací heslo obvykle chrání jak obsah prezentace, tak i vlastnosti dokumentu. Když je prezentace šifrována po volání [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/setencryptdocumentproperties/) s hodnotou `false`, její vlastnosti dokumentu zůstávají veřejné. Aplikace pak může zavolat [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) s hodnotou `true` a přečíst veřejná metadata bez zadání otevíracího hesla.

[LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) řídí, co Aspose.Slides načte; nic nešifruje. Pokud byly vlastnosti zahrnuty do šifrování, načtení bez hesla selže. Pokud prezentace není šifrována, volba je ignorována a načte se celá prezentace.

Příklad vyžaduje šifrovanou prezentaci, jejíž vlastnosti dokumentu byly ponechány veřejné. Ověřuje režim načítání pomocí [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/isonlydocumentpropertiesloaded/) a poté čte vestavěné vlastnosti pomocí [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getdocumentproperties/):

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setOnlyLoadDocumentProperties(true);

$presentation = new Presentation("public-properties-encrypted.pptx", $loadOptions);
try {
    if (java_values($presentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        $documentProperties = $presentation->getDocumentProperties();

        echo("Author: " . $documentProperties->getAuthor() . "\n");
        echo("Title: " . $documentProperties->getTitle() . "\n");
        echo("Keywords: " . $documentProperties->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode." . "\n");
    }
} finally {
    $presentation->dispose();
}
```

V tomto režimu není načítán obsah snímků. Snímky, mastery, rozložení, tvary, média a další objekty prezentace nejsou k dispozici. Aplikace by měly vždy před provedením operace, která vyžaduje kompletní model objektů prezentace, zkontrolovat [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/isonlydocumentpropertiesloaded/).

{{% alert color="warning" title="Warning" %}}
Veřejná metadata mohou odhalit jména autorů, názvy, předměty, klíčová slova, informace o společnosti, komentáře a vlastní hodnoty. Šifrujte citlivé vlastnosti spolu s prezentací. Ponechte je veřejné pouze tehdy, když mají indexační, klasifikační, vyhledávací nebo systémy správy dokumentů konkrétní požadavek na přístup bez hesla.
{{% /alert %}}

## **Aktualizace vlastností šifrované prezentace**

Pro šifrovaný soubor PPTX je prezentace načtená po volání [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) s `true` určena ke čtení veřejných metadat. Aspose.Slides nemůže uložit změněné vlastnosti z tohoto objektu jen s metadaty, protože veřejné vlastnosti musí zůstat konzistentní s odpovídajícími daty uvnitř šifrované prezentace. Aktualizace tedy vyžaduje správné otevírací heslo a kompletní načtení.

Příklad vyžaduje šifrovanou PPTX prezentaci s veřejnými vlastnostmi dokumentu a známým otevíracím heslem. Otevře kompletní prezentaci pomocí [LoadOptions::setPassword](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setpassword/), aktualizuje veřejné vestavěné vlastnosti a uloží výsledek. Poté použije [PresentationInfo::isEncrypted](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/isencrypted/) k ověření, že šifrování bylo zachováno, a znovu otevře veřejná metadata bez hesla k ověření nových hodnot:

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
    $documentProperties = $presentation->getDocumentProperties();
    $documentProperties->setTitle("Updated Product Roadmap");
    $documentProperties->setKeywords("roadmap, planning, indexed");
    
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
        echo("The presentation was not loaded in document-properties-only mode." . "\n");
    }
} finally {
    $metadataPresentation->dispose();
}
```

Pokud aplikace nemá oprávnění dešifrovat nebo načíst obsah prezentace, musí veřejné vlastnosti šifrovaného souboru PPTX považovat za pouze ke čtení.

## **Přístup k vestavěným vlastnostem**

Třída [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) vystavuje vestavěná metadata prostřednictvím metod getter, včetně [getAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getauthor/), [getTitle](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/gettitle/) a [getCreatedTime](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getcreatedtime/). Tento příklad otevře existující prezentaci a vypíše její uložená metadata do konzole. Hodnoty závisí na vstupní prezentaci; některá pole mohou být prázdná.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("AccessBuiltInProperties.pptx");
try {
    $documentProperties = $presentation->getDocumentProperties();

    echo("Category: " . $documentProperties->getCategory() . "\n");
    echo("Content status: " . $documentProperties->getContentStatus() . "\n");
    echo("Creation date: " . $documentProperties->getCreatedTime() . "\n");
    echo("Author: " . $documentProperties->getAuthor() . "\n");
    echo("Comments: " . $documentProperties->getComments() . "\n");
    echo("Keywords: " . $documentProperties->getKeywords() . "\n");
    echo("Last modified by: " . $documentProperties->getLastSavedBy() . "\n");
    echo("Manager: " . $documentProperties->getManager() . "\n");
    echo("Modified date: " . $documentProperties->getLastSavedTime() . "\n");
    echo("Presentation format: " . $documentProperties->getPresentationFormat() . "\n");
    echo("Last print date: " . $documentProperties->getLastPrinted() . "\n");
    echo("Is shared between producers: " . (java_values($documentProperties->getSharedDoc()) ? "true" : "false") . "\n");
    echo("Subject: " . $documentProperties->getSubject() . "\n");
    echo("Title: " . $documentProperties->getTitle() . "\n");
} finally {
    $presentation->dispose();
}
```

## **Úprava vestavěných vlastností**

Pro aktualizaci vestavěných metadat použijte metody setter na objektu vráceném metodou [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getdocumentproperties/). Tento příklad otevře existující prezentaci, zavolá [setAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setauthor/), [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/settitle/), [setSubject](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setsubject/), [setComments](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setcomments/) a [setManager](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setmanager/), poté uloží aktualizovanou prezentaci pomocí [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/). Uložený soubor PPTX obsahuje nová metadata.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("ModifyBuiltInProperties.pptx");
try {
    $documentProperties = $presentation->getDocumentProperties();

    $documentProperties->setAuthor("Aspose.Slides for PHP via Java");
    $documentProperties->setTitle("Manage PowerPoint Presentation Properties");
    $documentProperties->setSubject("Modify Built-in Properties");
    $documentProperties->setComments("Aspose description");
    $documentProperties->setManager("Aspose manager");

    $presentation->save("DocumentProperties_output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Správa základní adresy hypertextových odkazů**

[DocumentProperties::getHyperlinkBase](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/gethyperlinkbase/) vrací úroveň dokumentu pro relativní hypertextové odkazy. Použijte [DocumentProperties::setHyperlinkBase](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/sethyperlinkbase/) k jejímu změnění nebo vymazání. To je užitečné při přesunu prezentace a jejích souvisejících souborů na jiné místo. Je to oddělené od [Hyperlink::getExternalUrl](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getexternalurl/) jednotlivých odkazů: změna základny nepřepíše uložené adresy odkazů ani nezmění absolutní cíle.

Příklad vyžaduje prezentaci obsahující jak relativní odkaz, například `target.html`, tak absolutní odkaz, například `https://example.org/absolute.html`. Přečte existující základnu, přiřadí novou základní adresu a uloží a znovu otevře prezentaci k ověření hodnoty. Poté základnu vymaže prázdným řetězcem a ověří prázdnou hodnotu v samostatném uloženém souboru. Nahraďte příkladovou základní adresu umístěním vašich propojených souborů.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("hyperlinks.pptx");
try {
    echo("Original base: " . $presentation->getDocumentProperties()->getHyperlinkBase() . "\n");

    $newBase = "https://example.com/new/";
    $presentation->getDocumentProperties()->setHyperlinkBase($newBase);
    $presentation->save("hyperlinks-updated.pptx", SaveFormat::Pptx);

    $updatedPresentation = new Presentation("hyperlinks-updated.pptx");
    try {
        echo("Base preserved: " . ((string) $updatedPresentation->getDocumentProperties()->getHyperlinkBase() === $newBase ? "true" : "false") . "\n");

        $updatedPresentation->getDocumentProperties()->setHyperlinkBase("");
        $updatedPresentation->save("hyperlinks-cleared.pptx", SaveFormat::Pptx);

        $clearedPresentation = new Presentation("hyperlinks-cleared.pptx");
        try {
            echo("Base cleared: " . ((string) $clearedPresentation->getDocumentProperties()->getHyperlinkBase() === "" ? "true" : "false") . "\n");
        } finally {
            $clearedPresentation->dispose();
        }
    } finally {
        $updatedPresentation->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Obě ověřovací zprávy by měly vypsat `true`. Vymazání základny ponechá jednotlivé adresy hypertextových odkazů nedotčeny.

Relativní odkaz na `target.pptx` otevřel `old/target.pptx`, když základna ukazovala na složku `old`. Po změně základny na složku `new`, uložení a opětovném otevření prezentace se stejný odkaz otevřel `new/target.pptx`. Absolutní odkaz nadále otevíral stejný soubor. Otestujte své relativní odkazy v PowerPointu před a po přesunu prezentace nebo změně její základny.

## **Přidání vlastních vlastností prezentace**

Vlastní vlastnosti ukládají metadata, pro která neexistuje odpovídající vestavěné pole. Metoda [DocumentProperties::set_Item](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/set_item/) umožňuje přiřadit hodnotu podle názvu vlastnosti. Tento příklad vytvoří prezentaci, přidá dva textové hodnoty a celočíselnou verzi a uloží prezentaci pomocí [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/). Přiřazení hodnoty k existujícímu názvu nahradí hodnotu této vlastnosti.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $documentProperties = $presentation->getDocumentProperties();

    $documentProperties->set_Item("Reviewed by", "John Smith");
    $documentProperties->set_Item("Confidentiality level", "Internal");
    $documentProperties->set_Item("Document version", 2);

    $presentation->save("CustomDocumentProperties_output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Přístup a úprava vlastních vlastností**

Tento příklad otevře prezentaci obsahující vlastní vlastnosti a použije [getCountOfCustomProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getcountofcustomproperties/) k jejich iteraci. [getCustomPropertyName](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getcustompropertyname/) přijímá index začínající nulou a vrací název použitý v [DocumentProperties::set_Item](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/set_item/). Příklad vypíše každý původní název a hodnotu, nahradí každou hodnotu číslovaným řetězcem bez ohledu na původní typ a uloží změny. Pokud neexistují žádné vlastní vlastnosti, smyčka nedělá žádné změny.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("AccessAndModifyProperties.pptx");
try {
    $documentProperties = $presentation->getDocumentProperties();

    for ($i = 0; $i < java_values($documentProperties->getCountOfCustomProperties()); $i++) {
        $propertyName = $documentProperties->getCustomPropertyName($i);
        $propertyValue = $documentProperties->get_Item($propertyName);

        echo("Custom property name: " . $propertyName . "\n");
        echo("Custom property value: " . $propertyValue . "\n");

        $documentProperties->set_Item($propertyName, "New Value " . ($i + 1));
    }

    $presentation->save("CustomProperties_output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ukázkový příklad**

Vyzkoušejte online aplikaci [**Zobrazit a upravit metadata PowerPoint**](https://products.aspose.app/slides/metadata) a podívejte se, jak pracovat s vlastnostmi dokumentu pomocí API Aspose.Slides:

[![Zobrazit a upravit metadata PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **Často kladené otázky**

**Jak mohu odstranit vestavěnou vlastnost z prezentace?**

Vestavěné vlastnosti jsou nedílnou součástí prezentace a nelze je zcela odstranit. Můžete však změnit jejich hodnoty nebo je nastavit na prázdné, pokud to konkrétní vlastnost umožňuje.

**Co se stane, pokud přidám vlastní vlastnost, která už existuje?**

Pokud přidáte vlastní vlastnost, která již existuje, její stávající hodnota bude přepsána novou. Není nutné vlastnost předem odstraňovat nebo kontrolovat, protože Aspose.Slides automaticky aktualizuje hodnotu vlastnosti.

**Mohu přistupovat k vlastnostem prezentace bez úplného načtení prezentace?**

Ano. Použijte [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/presentationfactory/getpresentationinfo/) a poté [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/readdocumentproperties/) k přečtení uložených metadat dokumentu bez vytváření instance [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/). Viz [Build a Lightweight Presentation Inventory](/slides/cs/php-java/examine-presentation/) pro kompletní příklad reportování a omezení specifická pro formát.

**Mohu přečíst veřejné vlastnosti šifrované prezentace bez jejího otevíracího hesla?**

Ano. Prezentace musí být šifrována po volání [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/setencryptdocumentproperties/) s `false` a musí být načtena po volání [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) s `true`.

**Mohu aktualizovat šifrovaný soubor PPTX v režimu pouze vlastností dokumentu?**

Ne. Veřejná a šifrovaná data vlastností musí zůstat konzistentní, takže aktualizace šifrovaného souboru PPTX vyžaduje načtení kompletní prezentace s správným otevíracím heslem.