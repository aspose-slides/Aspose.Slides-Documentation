---
title: Prezentációs tulajdonságok kezelése PHP-ben
linktitle: Prezentációs tulajdonságok
type: docs
weight: 70
url: /hu/php-java/presentation-properties/
keywords:
- PowerPoint tulajdonságok
- prezentációs tulajdonságok
- dokumentum tulajdonságok
- beépített tulajdonságok
- egyéni tulajdonságok
- speciális tulajdonságok
- tulajdonságok kezelése
- tulajdonságok módosítása
- dokumentum metaadatok
- metaadatok szerkesztése
- helyesírás ellenőrző nyelv
- alapértelmezett nyelv
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Kezelje mester szintű prezentációs tulajdonságait az Aspose.Slides for PHP via Java megoldással, és egyszerűsítse a keresést, a márkaépítést és a munkafolyamatot PowerPoint és OpenDocument fájljaiban."
---
## **Bevezetés**

Az Aspose.Slides for PHP via Java támogatja a **beépített** és **egyéni** dokumentumtulajdonságokat. Ezeket a tulajdonságokat a bemutató metaadatainak olvasására és frissítésére használhatja, például a szerző, a cím és a felhasználó által meghatározott értékek esetén.

Az Aspose.Slides lehetővé teszi a bemutató dokumentumtulajdonságokkal való munkát a [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) osztályon keresztül. Ennek az osztálynak egy példányát a [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getDocumentProperties) adja vissza. A következő példák bemutatják, hogyan kell olvasni, módosítani és kezelni ezeket a tulajdonságokat. Feltételezik, hogy a PHP/Java Bridge és az Aspose.Slides PHP wrapper inicializálva van.

{{% alert color="info" title="Note" %}}
Az Aspose.Slides kezeli az alkalmazás- és gyártói metaadatokat a bemutatók mentésekor; ezek a mezők azonosítják a kimenetet létrehozó szoftvert.
{{% /alert %}}

## **Prezentációtulajdonságok kezelése**

A dokumentumtulajdonságok leíró információkat tárolnak a prezentáció tartalma mellett. Két kategóriába sorolhatók:

- **Beépített tulajdonságok** szabványos metaadatokat tartalmaznak, mint például a cím, a szerző és a dokumentum statisztikái.
- **Egyéni tulajdonságok** felhasználó által meghatározott név/érték párokat tárolnak.

Az Aspose.Slides for PHP via Java hozzáférést biztosít mindkét kategóriához. A PowerPointban válassza a **File → Info → Properties → Advanced Properties** menüt a dokumentum metaadatainak megtekintéséhez. A párbeszédpanel információkat csoportosít fülekre, például **Summary**, **Statistics**, **Contents** és **Custom**. Az **Custom** fül segítségével kezelheti a felhasználó által meghatározott tulajdonságokat.

## **Nyilvános tulajdonságok olvasása titkosított prezentációból**

Általában egy nyitó jelszó védi a prezentáció tartalmát és a dokumentumtulajdonságokat is. Ha a prezentációt a [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) `false` értékkel hívva titkosítják, a dokumentumtulajdonságok nyilvánosak maradnak. Egy alkalmazás ezután a [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) metódust `true` értékkel hívva olvashatja a nyilvános metaadatokat a nyitó jelszó megadása nélkül.

A [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) azt szabályozza, hogy az Aspose.Slides mit tölt be; semmit sem titkosít fel. Ha a tulajdonságok a titkosítás részei voltak, a jelszó nélkül történő betöltés sikertelen. Ha a prezentáció nincs titkosítva, az opciót figyelmen kívül hagyja, és a teljes prezentáció betöltődik.

A példa egy olyan titkosított prezentációt igényel, amelynek dokumentumtulajdonságai nyilvánosak maradtak. Ellenőrzi a betöltési módot a [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) segítségével, majd a beépített tulajdonságokat a [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getDocumentProperties) útján olvassa:
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

Ebbe az üzemmódban a diák tartalma nincs betöltve. Diák, alapvázlatok, elrendezések, alakzatok, média és egyéb prezentációs objektumok nem érhetők el. Az alkalmazásoknak mindig ellenőrizniük kell a [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) állapotát, mielőtt olyan műveletet végeznek, amely a teljes prezentációs objektummodellt igényli.

{{% alert color="warning" title="Warning" %}}
A nyilvános metaadatok felfedhetik a szerzők neveit, címeket, témákat, kulcsszavakat, céginformációkat, megjegyzéseket és egyéni értékeket. Titkosítsa az érzékeny tulajdonságokat a prezentációval együtt. Csak akkor hagyja nyilvánosan elérhetőnek, ha indexelés, osztályozás, keresés vagy dokumentumkezelő rendszereknek konkrétan szükségük van rá jelszó nélkül.
{{% /alert %}}

## **Titkosított prezentáció tulajdonságainak frissítése**

Egy titkosított PPTX fájl esetén a [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) `true` értékkel hívott betöltés után a prezentáció csak a nyilvános metaadatok olvasására szolgál. Az Aspose.Slides nem tudja elmenteni a módosított tulajdonságokat ebből a csak metaadatot tartalmazó objektumból, mivel a nyilvános tulajdonságoknak konzisztensnek kell lenniük a titkosított prezentációban lévő megfelelő adatokkal. Ezek frissítéséhez ezért a megfelelő nyitó jelszó és a teljes betöltés szükséges.

A példa egy titkosított PPTX prezentációt igényel, amelynek a dokumentumtulajdonságai nyilvánosak, és ismert a nyitó jelszó. A teljes prezentációt a [LoadOptions::setPassword](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setPassword) segítségével nyitja meg, frissíti a nyilvános beépített tulajdonságokat, és elmenti az eredményt. Ezután a [PresentationInfo::isEncrypted](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/#isEncrypted) metódust használja annak ellenőrzésére, hogy a titkosítás megmaradt-e, és újra megnyitja a nyilvános metaadatokat jelszó nélkül az új értékek ellenőrzéséhez:
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

Ha egy alkalmazás nem jogosult a prezentáció tartalmának feloldására vagy betöltésére, a titkosított PPTX fájl nyilvános tulajdonságait csak olvashatóként kezeli.

## **Beépített tulajdonságok elérése**

A [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) osztály getter metódusokkal teszi hozzáférhetővé a beépített metaadatokat, többek között a [getAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getAuthor), [getTitle](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getTitle) és [getCreatedTime](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getCreatedTime) metódusok. Ez a példa egy meglévő prezentációt nyit meg és a tárolt metaadatait a konzolra írja ki. Az értékek a bemeneti prezentációtól függenek; egyes mezők üresek lehetnek.
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

### **Revíziószám és szerkesztési idő jelentése**

A `presentations` mappában lévő minden PPTX fájl revíziószámának és teljes szerkesztési idejének jelentéséhez használja a [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/#readDocumentProperties) metódust a [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) olvasásához a diák betöltése nélkül. A PHP via Java API a szerkesztési időt milliszekundumban adja vissza. A példa átalakítja órákra, percekre és másodpercre, és napok számát is tartalmazza 24 óra vagy annál hosszabb időtartamok esetén.
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

Egy 17-es revíziószámmal és 1 nap, 2 óra, 5 perc szerkesztési idővel rendelkező prezentáció esetén a jelentés a következő kimenetet mutatja.
```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

A [DocumentProperties::getRevisionNumber](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getRevisionNumber) értéket olvas, amelyet az alkalmazások a [DocumentProperties::setRevisionNumber](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setRevisionNumber) segítségével módosíthatnak. Maga a revíziószám önmagában nem határozható meg, hogy hányszor mentették a prezentációt, vagy nem rekonstruálja a verziótörténetet.

A [DocumentProperties::getTotalEditingTime](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getTotalEditingTime) a fájlban rögzített szerkesztési időt olvassa. A prezentáció tárolt időtartama nulla (`00:00:00`) is lehet, még akkor is, ha valaki szerkesztette.

## **Beépített tulajdonságok módosítása**

A beépített metaadatok frissítéséhez használja a [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getDocumentProperties) által visszaadott objektum setter metódusait. Ez a példa egy meglévő prezentációt nyit meg, meghívja a [setAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setAuthor), [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setTitle), [setSubject](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setSubject), [setComments](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setComments) és [setManager](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setManager) metódusokat, majd a [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) segítségével menti a frissített prezentációt. A mentett PPTX tartalmazza az új metaadatokat.
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

A [DocumentProperties::getHyperlinkBase](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getHyperlinkBase) visszaadja a dokumentumszintű alapot a relatív hiperhivatkozásokhoz. A [DocumentProperties::setHyperlinkBase](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setHyperlinkBase) használatával módosíthatja vagy törölheti azt. Ez akkor hasznos, ha egy prezentációt és a hozzá kapcsolt fájlokat egy másik helyre mozgatja. Ez különálló egyedi hiperhivatkozás [Hyperlink::getExternalUrl](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/#getExternalUrl) metódusától: az alap módosítása nem írja át a tárolt linkcímeket, és nem változtatja meg a abszolút célpontokat.

A példa egy olyan prezentációt igényel, amely tartalmaz egy relatív hivatkozást, például `target.html`, és egy abszolút hivatkozást, például `https://example.org/absolute.html`. Kiolvassa a meglévő alapot, új alapcímet ad meg, elmenti és újra megnyitja a prezentációt az érték ellenőrzéséhez. Ezután egy üres karakterlánccal törli az alapot, és egy külön mentett fájlban ellenőrzi az üres értéket. Cserélje ki a példa alapcímét a saját linkelt fájljainak helyére.
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

A két ellenőrző üzenetnek `true` értéket kell kiírnia. Az alap törlése nem érinti az egyedi hiperhivatkozások címét.

Egy relatív hivatkozás a `target.pptx` fájlra a `old/target.pptx`‑t nyitotta meg, amikor az alap a `old` mappára mutatott. Az alap `new` mappára történő módosítása, a mentés és a prezentáció újranyitása után ugyanaz a hivatkozás a `new/target.pptx`‑t nyitotta meg. Egy abszolút hivatkozás továbbra is ugyanazt a fájlt nyitotta meg. Tesztelje a relatív hivatkozásait a PowerPointban a prezentáció áthelyezése vagy az alap módosítása előtt és után.

## **Egyéni prezentációtulajdonságok hozzáadása**

Az egyéni tulajdonságok olyan metaadatokat tárolnak, amelyeknek nincs megfelelő beépített mezője. A [DocumentProperties::set_Item](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#set_Item) metódus lehetővé teszi érték hozzárendelését tulajdonságnév alapján. Ez a példa egy prezentációt hoz létre, hozzáad két szöveges értéket és egy egész számú verzióértéket, majd a [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) segítségével elmenti a prezentációt. Egy meglévő névhez érték hozzárendelése felülírja az adott tulajdonság értékét.
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

Ez a példa egy egyéni tulajdonságokat tartalmazó prezentációt nyit meg, és a [getCountOfCustomProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getCountOfCustomProperties) segítségével iterálja őket. A [getCustomPropertyName](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getCustomPropertyName) nullától induló indexet fogad és visszaadja a [DocumentProperties::set_Item](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#set_Item) által használt nevet. A példa kiírja az eredeti nevet és értéket, minden értéket egy számozott szövegre cserél, típusfüggetlenül, és elmenti a módosításokat. Ha nincsenek egyéni tulajdonságok, a ciklus nem hajt végre változtatást.
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

Próbálja ki a [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) online alkalmazást, hogy megtekintse, hogyan dolgozhat a dokumentumtulajdonságokkal az Aspose.Slides API segítségével:
[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **GYIK**

**Hogyan távolíthatok el egy beépített tulajdonságot a prezentációból?**

A beépített tulajdonságok a prezentáció szerves részei, ezért nem távolíthatók el teljesen. Azonban megváltoztathatja az értéküket, vagy ha az adott tulajdonság megengedi, üresre állíthatja őket.

**Mi történik, ha egy már létező egyéni tulajdonságot adok hozzá?**

Ha egy már létező egyéni tulajdonságot ad hozzá, a meglévő érték felülíródik az újjal. Nem szükséges előre eltávolítani vagy ellenőrizni a tulajdonságot, mivel az Aspose.Slides automatikusan frissíti annak értékét.

**Elérhetem a prezentáció tulajdonságait anélkül, hogy teljesen betölteném a prezentációt?**

Igen. Használja a [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/presentationfactory/#getPresentationInfo) metódust, majd a [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/#readDocumentProperties) segítségével olvassa a tárolt dokumentum metaadatait anélkül, hogy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) példányt hozna létre. Tekintse meg a [Build a Lightweight Presentation Inventory](/slides/hu/php-java/examine-presentation/) cikket egy teljes jelentési példa és formátum‑specifikus korlátozásokért.

**Olvashatok nyilvános tulajdonságokat egy titkosított prezentációból a nyitó jelszó nélkül?**

Igen. A prezentációt a [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) `false` értékkel történő hívása után kell titkosítani, és a [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) `true` értékkel történő betöltése után kell betölteni.

**Frissíthetek egy titkosított PPTX fájlt csak dokumentumtulajdonságok módjában?**

Nem. A nyilvános és a titkosított tulajdonságadatoknak konzisztensnek kell maradniuk, ezért egy titkosított PPTX fájl frissítéséhez a teljes prezentációt a megfelelő nyitó jelszóval kell betölteni.