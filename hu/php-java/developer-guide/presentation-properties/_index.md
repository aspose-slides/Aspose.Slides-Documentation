---
title: Prezentációtulajdonságok kezelése PHP-ben
linktitle: Prezentáció tulajdonságok
type: docs
weight: 70
url: /hu/php-java/presentation-properties/
keywords:
- PowerPoint tulajdonságok
- prezentáció tulajdonságok
- dokumentum tulajdonságok
- beépített tulajdonságok
- egyéni tulajdonságok
- haladó tulajdonságok
- tulajdonságok kezelése
- tulajdonságok módosítása
- dokumentum metaadatok
- metaadatok szerkesztése
- helyesírási nyelv
- alapértelmezett nyelv
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Mester szintű prezentációtulajdonságok kezelése az Aspose.Slides for PHP via Java segítségével, és a keresés, márkajelzés és munkafolyamat egyszerűsítése PowerPoint és OpenDocument fájljaiban."
---
## **Bevezetés**

Aspose.Slides for PHP via Java támogatja a **beépített** és **egyéni** dokumentumtulajdonságokat. Ezeket a tulajdonságokat használhatja a prezentáció metaadatainak olvasására és frissítésére, például a szerző, a cím és a felhasználó által definiált értékek esetén.

Az Aspose.Slides lehetővé teszi, hogy a prezentáció dokumentumtulajdonságokkal a [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) osztályon keresztül dolgozzon. Ennek az osztálynak egy példányát a [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getdocumentproperties/) adja vissza. A következő példák bemutatják, hogyan olvassa, módosítsa és kezelje ezeket a tulajdonságokat. Feltételezik, hogy a PHP/Java Bridge és az Aspose.Slides PHP csomag inicializálva van.

{{% alert color="info" title="Megjegyzés" %}}
Az Aspose.Slides a mentéskor kezeli az alkalmazás- és gyártói metaadatokat a prezentációkban; ezek a mezők azonosítják a kimenetet létrehozó szoftvert.
{{% /alert %}}

## **Prezentációtulajdonságok kezelése**

A dokumentumtulajdonságok leíró információkat tárolnak a prezentáció tartalma mellett. Két kategóriába sorolhatók:

- **Beépített tulajdonságok** szabványos metaadatokat tartalmaznak, mint például a cím, a szerző és a dokumentum statisztikái.
- **Egyéni tulajdonságok** felhasználó által definiált név/érték párokat tárolnak.

Az Aspose.Slides for PHP via Java hozzáférést biztosít mindkét kategóriához. A PowerPointban válassza a **File → Info → Properties → Advanced Properties** menüt a dokumentum metaadatainak megtekintéséhez. A párbeszédpanel információkat csoportosítja fülekre, például **Summary**, **Statistics**, **Contents** és **Custom**. A **Custom** fület használja a felhasználó által definiált tulajdonságok kezeléséhez.

## **Nyilvános tulajdonságok olvasása titkosított prezentációból**

Nyitó jelszó általában védi a prezentáció tartalmát és a dokumentumtulajdonságokat is. Ha egy prezentációt a [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/setencryptdocumentproperties/) `false` értékkel hívás után titkosítják, a dokumentumtulajdonságai nyilvánosak maradnak. Ezután egy alkalmazás a [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) `true` értékkel hívásával olvashatja a nyilvános metaadatokat a nyitó jelszó megadása nélkül.

A [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) szabályozza, hogy az Aspose.Slides mit tölt be; semmit sem fejti fel. Ha a tulajdonságok a titkosítás részei voltak, a jelszó nélkül történő betöltés sikertelen. Ha a prezentáció nincs titkosítva, az opcionális beállítás figyelmen kívül marad, és a teljes prezentáció betöltődik.

A példa egy olyan titkosított prezentációt igényel, amelynek a dokumentumtulajdonságai nyilvánosak maradtak. A betöltési módot a [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/isonlydocumentpropertiesloaded/) ellenőrzi, majd a beépített tulajdonságokat a [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getdocumentproperties/) segítségével olvassa:
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

Ebben a módban a diák tartalma nem töltődik be. A diák, a master diák, elrendezések, alakzatok, média és egyéb prezentációs objektumok nem érhetők el. Az alkalmazásoknak mindig ellenőrizniük kell a [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/isonlydocumentpropertiesloaded/) állapotát, mielőtt olyan műveletet végeznek, amely a teljes prezentációs objektummodellt igényli.

{{% alert color="warning" title="Figyelmeztetés" %}}
A nyilvános metaadatok feltárhatják a szerző neveket, címeket, tárgyakat, kulcsszavakat, céges információkat, megjegyzéseket és egyéni értékeket. Titkosítsa az érzékeny tulajdonságokat a prezentációval együtt. Hagyja őket nyilvánosan csak akkor, ha az indexelés, osztályozás, keresés vagy dokumentumkezelő rendszereknek kifejezett igénye van a jelszó nélküli hozzáférésre.
{{% /alert %}}

## **Titkosított prezentáció tulajdonságainak frissítése**

Titkosított PPTX fájl esetén a [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) `true` értékkel hívott betöltés után a prezentáció csak a nyilvános metaadatok olvasására szolgál. Az Aspose.Slides nem tudja menteni a módosított tulajdonságokat ebből a csak-metaadat objektumból, mivel a nyilvános tulajdonságoknak konzisztensnek kell maradniuk a titkosított prezentációban lévő megfelelő adatokkal. Ennek frissítése ezért a helyes nyitó jelszót és a teljes betöltést igényli.

A példa egy olyan titkosított PPTX prezentációt igényel, amelynek a dokumentumtulajdonságai nyilvánosak, és ismert nyitó jelszóval rendelkezik. A teljes prezentációt a [LoadOptions::setPassword](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setpassword/) használatával nyitja meg, frissíti a nyilvános beépített tulajdonságokat, és elmenti az eredményt. Ezután a [PresentationInfo::isEncrypted](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/isencrypted/) segítségével ellenőrzi, hogy a titkosítás megmaradt-e, és a nyilvános metaadatokat jelszó nélkül nyitja meg az új értékek ellenőrzéséhez:
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

Ha egy alkalmazás nem jogosult a prezentáció tartalmának visszafejtésére vagy betöltésére, a titkosított PPTX fájl nyilvános tulajdonságait csak olvashatóként kell kezelnie.

## **Beépített tulajdonságok elérése**

A [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) osztály getter metódusokon keresztül teszi elérhetővé a beépített metaadatokat, többek között a [getAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getauthor/), [getTitle](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/gettitle/) és [getCreatedTime](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getcreatedtime/) metódusokat. Ez a példa megnyit egy meglévő prezentációt, és a tárolt metaadatokat kiírja a konzolra. Az értékek a bemeneti prezentációtól függenek; egyes mezők üresek lehetnek.
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

## **Beépített tulajdonságok módosítása**

A beépített metaadatok frissítéséhez használja a setter metódusokat a [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getdocumentproperties/) által visszaadott objektumon. Ez a példa megnyit egy meglévő prezentációt, meghívja a [setAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setauthor/), [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/settitle/), [setSubject](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setsubject/), [setComments](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setcomments/) és [setManager](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setmanager/) metódusokat, majd a [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) segítségével elmenti a frissített prezentációt. A mentett PPTX tartalmazza az új metaadatokat.
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

## **A hiperhivatkozás alapjának kezelése**

A [DocumentProperties::getHyperlinkBase](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/gethyperlinkbase/) visszaadja a dokumentumszintű alapot a relatív hiperhivatkozásokhoz. A [DocumentProperties::setHyperlinkBase](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/sethyperlinkbase/) használatával módosítható vagy törölhető ez az alap. Hasznos, ha egy prezentációt és a kapcsolódó fájljait egy másik helyre mozgatja. Ez különálló az egyes hiperhivatkozások [Hyperlink::getExternalUrl](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getexternalurl/) metódusától: az alap módosítása nem írja felül a tárolt hivatkozási címeket, és nem változtatja meg a abszolút célpontokat.

A példa egy prezentációt igényel, amely tartalmaz egy relatív hivatkozást, például `target.html`, és egy abszolút hivatkozást, például `https://example.org/absolute.html`. A meglévő alapot kiolvassa, új alapcímet ad meg, majd elmenti és újra megnyitja a prezentációt az érték ellenőrzéséhez. Ezután üres karakterlánccal törli az alapot, és külön mentett fájlban ellenőrzi az üres értéket. Cserélje ki a példában szereplő alapcímet a saját linkfájljai helyére.
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

A két ellenőrző üzenetnek `true` értéket kell kiírnia. Az alap törlése sem változtatja meg az egyes hiperhivatkozások címét.

Egy relatív hivatkozás a `target.pptx` fájlra a `old/target.pptx`-t nyitotta meg, amikor az alap a `old` mappára mutatott. Az alap `new` mappára való módosítása, a mentés és a prezentáció újranyitása után ugyanaz a hivatkozás a `new/target.pptx`-t nyitja meg. Egy abszolút hivatkozás továbbra is ugyanazt a fájlt nyitja. Tesztelje a relatív hivatkozásait a PowerPointban a prezentáció áthelyezése vagy az alap módosítása előtt és után.

## **Egyéni prezentációtulajdonságok hozzáadása**

Az egyéni tulajdonságok olyan metaadatokat tárolnak, amelyekhez nincs megfelelő beépített mező. A [DocumentProperties::set_Item](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/set_item/) metódus lehetővé teszi a tulajdonságnév alapján történő értékadás. Ez a példa létrehoz egy prezentációt, két szöveges értéket és egy egész számú verzióértéket ad hozzá, majd a [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) segítségével elmenti a prezentációt. Egy meglévő névhez való értékadás felülírja a tulajdonság eredeti értékét.
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

## **Egyéni tulajdonságok elérése és módosítása**

Ez a példa megnyit egy prezentációt, amely egyéni tulajdonságokat tartalmaz, és a [getCountOfCustomProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getcountofcustomproperties/) segítségével iterálja őket. A [getCustomPropertyName](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getcustompropertyname/) nullától induló indexet fogad, és visszaadja a [DocumentProperties::set_Item](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/set_item/) által használt nevet. A példa kiírja minden eredeti nevet és értéket, minden értéket egy számozott karakterlánccal helyettesít, függetlenül az eredeti típustól, majd elmenti a módosításokat. Ha nincsenek egyéni tulajdonságok, a ciklus nem hajt végre változtatást.
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

## **Élő példa**

Próbálja ki a [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) online alkalmazást, hogy megtudja, hogyan dolgozhat a dokumentumtulajdonságokkal az Aspose.Slides API segítségével:
[![Nézze meg és szerkessze a PowerPoint metaadatokat](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **GYIK**

**Hogyan távolíthatok el egy beépített tulajdonságot egy prezentációból?**

A beépített tulajdonságok a prezentáció szerves részei, és nem távolíthatók el teljesen. Azonban módosíthatja az értéküket, vagy ha a konkrét tulajdonság megengedi, beállíthatja őket üresre.

**Mi történik, ha olyan egyéni tulajdonságot adok hozzá, amely már létezik?**

Ha olyan egyéni tulajdonságot ad hozzá, amely már létezik, a meglévő érték felül lesz írva az újjal. Nem kell előre eltávolítani vagy ellenőrizni a tulajdonságot, mivel az Aspose.Slides automatikusan frissíti a tulajdonság értékét.

**Elérhetem a prezentáció tulajdonságait a teljes prezentáció betöltése nélkül?**

Igen. Használja a [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/presentationfactory/getpresentationinfo/) metódust, majd a [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/readdocumentproperties/) metódust a tárolt dokumentum metaadatok olvasásához anélkül, hogy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) példányt hozna létre. Tekintse meg a [Könnyűsúlyú prezentáció-inventár létrehozása](/slides/hu/php-java/examine-presentation/) cikket a teljes jelentési példáért és a formátumspecifikus korlátozásokért.

**Olvashatom egy titkosított prezentáció nyilvános tulajdonságait a nyitó jelszó nélkül?**

Igen. A prezentációt úgy kell titkosítani, hogy a [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/setencryptdocumentproperties/) `false` értékkel legyen meghívva, és a [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) `true` értékkel történő betöltés után legyen betöltve.

**Frissíthetek egy titkosított PPTX fájlt csak-dokumentumtulajdonságok módban?**

Nem. A nyilvános és a titkosított tulajdonság adatoknak konzisztensnek kell maradniuk, ezért egy titkosított PPTX fájl frissítéséhez a teljes prezentációt a megfelelő nyitó jelszóval kell betölteni.