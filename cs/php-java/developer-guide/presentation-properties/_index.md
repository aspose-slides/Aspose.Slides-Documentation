---
title: Správa vlastností prezentace v PHP
linktitle: Vlastnosti prezentace
type: docs
weight: 70
url: /cs/php-java/presentation-properties/
keywords:
- Vlastnosti PowerPoint
- Vlastnosti prezentace
- Vlastnosti dokumentu
- Vestavěné vlastnosti
- Vlastní vlastnosti
- Pokročilé vlastnosti
- Správa vlastností
- Úprava vlastností
- Metadata dokumentu
- Úprava metadat
- Jazyk kontroly pravopisu
- Výchozí jazyk
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Zvládněte vlastnosti prezentace v Aspose.Slides pro PHP přes Java a zefektivněte vyhledávání, značkování a pracovní postup ve vašich souborech PowerPoint a OpenDocument."
---
## **Úvod**

Aspose.Slides pro PHP přes Java podporuje **vestavěné** a **vlastní** vlastnosti dokumentu. Použijte tyto vlastnosti ke čtení a aktualizaci metadat prezentace, jako je autor, název a uživatelem definované hodnoty.

Aspose.Slides vám umožňuje pracovat s vlastnostmi dokumentu prezentace pomocí třídy [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) . Instance této třídy je vrácena metodou [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getDocumentProperties). Následující příklady ukazují, jak číst, měnit a spravovat tyto vlastnosti. Předpokládají, že je inicializován PHP/Java Bridge a obal Aspose.Slides pro PHP.

{{% alert color="info" title="Note" %}}
Aspose.Slides spravuje metadata aplikace a výrobce při ukládání prezentací; tato pole identifikují software, který vytvořil výstup.
{{% /alert %}}

## **Správa vlastností prezentace**

Vlastnosti dokumentu ukládají popisné informace vedle obsahu prezentace. Patří do dvou kategorií:

- **Vestavěné vlastnosti** obsahují standardní metadata, jako je název, autor a statistiky dokumentu.
- **Vlastní vlastnosti** ukládají uživatelem definované páry název/hodnota.

Aspose.Slides pro PHP přes Java poskytuje přístup k oběma kategoriím. V PowerPointu vyberte **File → Info → Properties → Advanced Properties** pro prohlédnutí metadat dokumentu. Dialog seskupuje informace do záložek jako **Summary**, **Statistics**, **Contents** a **Custom**. Použijte záložku **Custom** pro správu uživatelem definovaných vlastností.

## **Čtení veřejných vlastností z šifrované prezentace**

Otevírací heslo obvykle chrání jak obsah prezentace, tak vlastnosti dokumentu. Když je prezentace šifrována po volání [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) s hodnotou `false`, její vlastnosti dokumentu zůstávají veřejné. Aplikace pak může zavolat [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) s hodnotou `true` a přečíst veřejná metadata bez zadání otevíracího hesla.

[LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) řídí, co Aspose.Slides načítá; nic než šifru neodšifruje. Pokud byly vlastnosti zahrnuty do šifrování, načtení bez hesla selže. Pokud prezentace není šifrována, volba se ignoruje a načte se celá prezentace.

Příklad vyžaduje šifrovanou prezentaci, jejíž vlastnosti dokumentu byly ponechány veřejné. Ověřuje režim načítání pomocí [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) a poté čte vestavěné vlastnosti pomocí [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getDocumentProperties):

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

V tomto režimu není načten obsah snímků. Snímky, předlohy, rozvržení, tvary, média a další objekty prezentace nejsou k dispozici. Aplikace by měly vždy zkontrolovat [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded), před provedením operace, která vyžaduje kompletní objektový model prezentace.

{{% alert color="warning" title="Warning" %}}
Veřejná metadata mohou odhalit jména autorů, názvy, předměty, klíčová slova, informace o společnosti, komentáře a vlastní hodnoty. Šifrujte citlivé vlastnosti společně s prezentací. Nechte je veřejné pouze v případě, že indexovací, klasifikační, vyhledávací nebo systémy pro správu dokumentů mají konkrétní požadavek na přístup k nim bez hesla.
{{% /alert %}}

## **Aktualizace vlastností šifrované prezentace**

Pro šifrovaný soubor PPTX je prezentace načtená po volání [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) s hodnotou `true` určena k čtení veřejných metadat. Aspose.Slides nemůže uložit změněné vlastnosti z tohoto objektu obsahujícího pouze metadata, protože veřejné vlastnosti musí zůstat v souladu s odpovídajícími daty uvnitř šifrované prezentace. Aktualizace proto vyžaduje správné otevírací heslo a kompletní načtení.

Příklad vyžaduje šifrovanou PPTX prezentaci s veřejnými vlastnostmi dokumentu a známým otevíracím heslem. Otevře kompletní prezentaci pomocí [LoadOptions::setPassword](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setPassword), aktualizuje veřejné vestavěné vlastnosti a uloží výsledek. Poté použije [PresentationInfo::isEncrypted](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/#isEncrypted) k ověření, že šifrování bylo zachováno, a znovu otevře veřejná metadata bez hesla pro ověření nových hodnot:

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

Pokud aplikace nemá povoleno dešifrovat nebo načíst obsah prezentace, musí považovat veřejné vlastnosti šifrovaného souboru PPTX za pouze pro čtení.

## **Přístup k vestavěným vlastnostem**

Třída [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) zpřístupňuje vestavěná metadata pomocí getter metod, včetně [getAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getAuthor), [getTitle](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getTitle) a [getCreatedTime](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getCreatedTime). Tento příklad otevře existující prezentaci a vypíše její uložená metadata do konzole. Hodnoty závisí na vstupní prezentaci; některá pole mohou být prázdná.

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

### **Zpráva o čísle revize a době úprav**

Pro zjištění čísla revize a celkové doby úprav každého souboru PPTX ve složce `presentations` použijte [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/#readDocumentProperties), abyste načetli jeho [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) bez načítání snímků pro úpravy. API PHP přes Java vrací dobu úprav v milisekundách. Příklad ji převádí na hodiny, minuty a sekundy a zahrnuje počet dní pro trvání 24 hodin a více.

```php
use aspose\slides\PresentationFactory;

echo "File | RevisionNumber | TotalEditingTime\n";
foreach (new GlobIterator("presentations/*.pptx") as $file) {
    if (!$file->isFile()) {
        continue;
    }

    $info = PresentationFactory::getInstance()->getPresentationInfo($file->getRealPath());
    $properties = $info->readDocumentProperties();
    $totalSeconds = (int) (java_values($properties->getTotalEditingTime()) / 1000);
    $days = intdiv($totalSeconds, 86400);
    $time = sprintf("%02d:%02d:%02d", intdiv($totalSeconds, 3600) % 24, intdiv($totalSeconds, 60) % 60, $totalSeconds % 60);
    $editingTime = $days > 0 ? $days . "." . $time : $time;
    printf("%s | %d | %s\n", $file->getFilename(), java_values($properties->getRevisionNumber()), $editingTime);
}
```

Pro prezentaci s číslem revize 17 a zaznamenanou dobou úprav 1 den, 2 hodiny a 5 minut zpráva zobrazí následující výstup.

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

[DocumentProperties::getRevisionNumber](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getRevisionNumber) čte hodnotu, kterou aplikace mohou změnit pomocí [DocumentProperties::setRevisionNumber](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setRevisionNumber). Samotné číslo revize neukazuje, kolikrát byla prezentace uložena, ani neumožňuje rekonstruovat historii verzí.

[DocumentProperties::getTotalEditingTime](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getTotalEditingTime) čte dobu úprav zaznamenanou v souboru. Prezentace může mít uloženou dobu nula (`00:00:00`), i když byla někým upravována.

## **Úprava vestavěných vlastností**

Pro aktualizaci vestavěných metadat použijte metody setter na objektu vráceném metodou [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getDocumentProperties). Tento příklad otevře existující prezentaci, zavolá [setAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setAuthor), [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setTitle), [setSubject](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setSubject), [setComments](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setComments) a [setManager](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setManager), pak uloží aktualizovanou prezentaci pomocí [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save). Uložený PPTX obsahuje nová metadata.

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

## **Správa základny hyperodkazu**

[DocumentProperties::getHyperlinkBase](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getHyperlinkBase) vrací úrovňový základ dokumentu pro relativní hyperodkazy. Použijte [DocumentProperties::setHyperlinkBase](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setHyperlinkBase) pro změnu nebo vymazání. To je užitečné při přesunu prezentace a jejích propojených souborů na jiné místo. Je to oddělené od individuálního hyperodkazu [Hyperlink::getExternalUrl](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/#getExternalUrl): změna základu nepřepíše uložené adresy odkazů ani nezmění absolutní cíle.

Příklad vyžaduje prezentaci obsahující jak relativní odkaz, např. `target.html`, tak absolutní odkaz, např. `https://example.org/absolute.html`. Přečte existující základ, přiřadí novou adresu základu a uloží a znovu otevře prezentaci pro kontrolu hodnoty. Poté základ vymaže pomocí prázdného řetězce a ověří prázdnou hodnotu v samostatném uloženém souboru. Nahraďte ukázkovou adresu základu umístěním vašich propojených souborů.

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

Obě ověřovací zprávy by měly vypsat `true`. Vymazání základu ponechá adresy jednotlivých hyperodkazů nedotčeny.

Relativní odkaz na `target.pptx` otevřel `old/target.pptx`, když základ ukazoval na složku `old`. Po změně základu na složku `new`, uložení a opětovném otevření prezentace stejný odkaz otevřel `new/target.pptx`. Absolutní odkaz nadále otevřel stejný soubor. Otestujte své relativní odkazy v PowerPointu před a po přesunu prezentace nebo změně jejího základu.

## **Přidání vlastních vlastností prezentace**

Vlastní vlastnosti ukládají metadata, která nemají odpovídající vestavěné pole. Metoda [DocumentProperties::set_Item](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#set_Item) vám umožňuje přiřadit hodnotu podle názvu vlastnosti. Tento příklad vytvoří prezentaci, přidá dva textové hodnoty a celočíselnou verzi, a uloží prezentaci pomocí [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save). Přiřazení hodnoty k existujícímu názvu nahradí hodnotu této vlastnosti.

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

Tento příklad otevře prezentaci obsahující vlastní vlastnosti a použije [getCountOfCustomProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getCountOfCustomProperties), aby je prošel. [getCustomPropertyName](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getCustomPropertyName) přijímá index počínaje nulou a vrací název použitý v [DocumentProperties::set_Item](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#set_Item). Příklad vypíše každý původní název a hodnotu, nahradí každou hodnotu číslovaným řetězcem bez ohledu na původní typ a uloží změny. Pokud nejsou žádné vlastní vlastnosti, smyčka neprovede žádné změny.

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

## **Živý příklad**

Vyzkoušejte online aplikaci [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata), abyste viděli, jak pracovat s vlastnostmi dokumentu pomocí Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **Často kladené dotazy**

**Jak mohu odstranit vestavěnou vlastnost z prezentace?**

Vestavěné vlastnosti jsou nedílnou součástí prezentace a nelze je zcela odstranit. Můžete však buď změnit jejich hodnoty, nebo je nastavit na prázdné, pokud to konkrétní vlastnost umožňuje.

**Co se stane, když přidám vlastní vlastnost, která již existuje?**

Pokud přidáte vlastní vlastnost, která již existuje, její stávající hodnota bude přepsána novou. Nemusíte vlastnost předtím odstraňovat nebo kontrolovat, protože Aspose.Slides automaticky aktualizuje hodnotu vlastnosti.

**Mohu získat přístup k vlastnostem prezentace bez úplného načtení prezentace?**

Ano. Použijte [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/presentationfactory/#getPresentationInfo) a poté [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/#readDocumentProperties), abyste načetli uložená metadata dokumentu bez vytváření instance [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/). Viz [Build a Lightweight Presentation Inventory](/slides/cs/php-java/examine-presentation/) pro kompletní příklad reportování a specifická omezení formátu.

**Mohu číst veřejné vlastnosti šifrované prezentace bez jejího otevíracího hesla?**

Ano. Prezentace musí být šifrována po volání [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) s hodnotou `false` a musí být načtena po volání [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) s hodnotou `true`.

**Mohu aktualizovat šifrovaný soubor PPTX v režimu pouze vlastnosti dokumentu?**

Ne. Veřejná a šifrovaná data vlastností musí zůstat konzistentní, takže aktualizace šifrovaného souboru PPTX vyžaduje načtení celé prezentace se správným otevíracím heslem.