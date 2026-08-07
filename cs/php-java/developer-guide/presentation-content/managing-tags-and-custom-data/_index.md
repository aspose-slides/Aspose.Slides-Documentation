---
title: Správa značek a vlastních dat v prezentacích pomocí PHP
linktitle: Značky a vlastní data
type: docs
weight: 300
url: /cs/php-java/managing-tags-and-custom-data/
keywords:
- vlastnosti dokumentu
- značka
- vlastní data
- vlastní XML
- vlastní XML část
- XML metadata
- ItemId
- přidat značku
- párové hodnoty
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Naučte se, jak spravovat značky a vlastní XML data v prezentacích PowerPoint pomocí Aspose.Slides pro PHP přes Java, včetně přidávání, čtení, aktualizace, auditu a odstraňování vlastních XML částí."
---
## **Přehled**

Tento článek vysvětluje, jak Aspose.Slides pracuje s tagy a vlastními daty v prezentacích PowerPoint. Data specifická pro prezentaci lze uložit jako tagy nebo vlastní XML části. Tagy jsou jednoduché páry klíč‑hodnota typu řetězec, zatímco vlastní XML části mohou uchovávat strukturovaná metadata a aplikační XML náklady.

Aspose.Slides poskytuje rozhraní API pro přidávání, čtení, aktualizaci, auditování a odstraňování vlastních XML částí na úrovni prezentace, snímku a tvaru. Vlastní XML části jsou užitečné pro integrace, které ukládají informace jako identifikátory správy dokumentů, stav pracovního postupu, metadata souladu, data vazby šablony nebo jiné strukturované aplikační údaje uvnitř prezentace.

## **Ukládání dat v souborech prezentací**

Soubory PPTX — soubory s příponou `.pptx` — jsou uloženy ve formátu PresentationML, který je součástí specifikace Office Open XML. Office Open XML definuje strukturu balíčku a vztahy použité k ukládání obsahu prezentace a souvisejících dat.

Prezentace obsahuje více částí propojených vztahy. Například část snímku obsahuje obsah jednoho snímku a může mít explicitní vztahy k jiným částem definované podle ISO/IEC 29500.

Vlastní data lze uložit jako tagy ([TagCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/tagcollection/)) nebo vlastní XML části ([CustomXmlPartCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/customxmlpartcollection/)). Obě jsou dostupné přes třídu [`CustomData`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/customdata/).

{{% alert color="primary" %}}
Tagy ukládají jednoduché řetězcové páry klíč‑hodnota. Vlastní XML části ukládají strukturovaná XML data a mohou být asociovány s prezentací, snímkem nebo tvarem.
{{% /alert %}}

## **Práce s vlastními XML částmi**

Metoda [`CustomData::getCustomXmlParts()`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/customdata/#getCustomXmlParts) vrací kolekci vlastních XML částí spojených s konkrétním objektem prezentace. Například:

- `$presentation->getCustomData()->getCustomXmlParts()` obsahuje vlastní XML části spojené přímo s prezentací.
- `$slide->getCustomData()->getCustomXmlParts()` obsahuje vlastní XML části spojené s konkrétním snímkem.
- `$shape->getCustomData()->getCustomXmlParts()` obsahuje vlastní XML části spojené s konkrétním tvarem.

Použijte [`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#getAllCustomXmlParts), pokud potřebujete prozkoumat všechny vlastní XML části v prezentaci bez ohledu na to, kde jsou přiřazeny.

### **Přidání vlastní XML části do prezentace**

Použijte [`CustomXmlPartCollection::add`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/customxmlpartcollection/#add) pro přidání XML dat do kolekce vlastních XML částí. XML musí být platné a nesmí být prázdné.

Následující příklad přidává strukturovaná metadata do kolekce vlastních dat na úrovni prezentace:

```php
$customXmlContent =
    '<?xml version="1.0" encoding="UTF-8"?>' .
    '<metadata xmlns="urn:example:metadata">' .
        '<documentId>DOC-1001</documentId>' .
        '<workflowState>Draft</workflowState>' .
    '</metadata>';

$presentation = new Presentation();
try {
    $customXmlPart = $presentation->getCustomData()->getCustomXmlParts()->add($customXmlContent);

    // add přiřadí identifikátor automaticky. Nastavte konkrétní UUID pouze v případě potřeby.
    $UUID = new JavaClass("java.util.UUID");
    $customXmlPart->setItemId($UUID->randomUUID());

    $presentation->save("presentation_with_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Metoda `add` může také přijímat XML jako pole bajtů nebo vstupní proud, což je užitečné, když je XML obsah již dostupný v binární formě.

### **Přidání vlastní XML části do snímku nebo tvaru**

Vlastní XML data lze přiřadit konkrétnímu snímku nebo tvaru místo celé prezentace. To je užitečné, pokud metadata popisují jen jeden objekt, například klíč šablony, externí identifikátor záznamu nebo informační vazbu.

Následující příklad přidává jednu vlastní XML část do snímku a další do tvaru:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $slide->getCustomData()->getCustomXmlParts()->add(
        '<slideMetadata xmlns="urn:example:slides">' .
            '<templateKey>TitleSlide</templateKey>' .
        '</slideMetadata>'
    );

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 250, 80);

    $shape->getTextFrame()->setText("Customer data");
    $shape->getCustomData()->getCustomXmlParts()->add(
        '<shapeMetadata xmlns="urn:example:shapes">' .
            '<recordId>CRM-4281</recordId>' .
        '</shapeMetadata>'
    );

    $presentation->save("object_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Úroveň, na které je část přidána, určuje, která kolekce `getCustomData()->getCustomXmlParts()` obsahuje vztah k této části. Data na úrovni prezentace jsou vhodná pro metadata dokumentu jako celku, data na úrovni snímku pro informace, které patří konkrétnímu snímku, a data na úrovni tvaru pro metadata svázaná s jednotlivým tvarem.

### **Seznam a audit všech vlastních XML částí**

Použijte [`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#getAllCustomXmlParts) pro získání všech vlastních XML částí z prezentace. Každý [`CustomXmlPart`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/customxmlpart/) vystavuje svůj identifikátor, XML obsah a přidružené schémata jmenných prostorů.

Následující příklad vypisuje všechny vlastní XML části a jejich schémata jmenných prostorů:

```php
$presentation = new Presentation("presentation.pptx");
try {
    foreach ($presentation->getAllCustomXmlParts() as $customXmlPart) {
        echo "ItemId: " . $customXmlPart->getItemId() . PHP_EOL;
        echo "XML:" . PHP_EOL;
        echo $customXmlPart->getXmlAsString() . PHP_EOL;

        foreach ($customXmlPart->getNamespaceSchemas() as $namespaceSchema) {
            echo "Namespace schema: " . $namespaceSchema . PHP_EOL;
        }

        echo PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

[`CustomXmlPart::getNamespaceSchemas()`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/customxmlpart/#getNamespaceSchemas) vrací XML schémata přidružená k vlastní XML části. Tato informace může být užitečná při auditu prezentací, které obsahují XML vytvořené externími systémy.

### **Čtení a aktualizace XML obsahu a ItemId**

Použijte [`CustomXmlPart::getXmlAsString()`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/customxmlpart/#getXmlAsString) a [`setXmlAsString()`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/customxmlpart/#setXmlAsString) pro práci s XML jako řetězcem UTF‑8, nebo [`getXmlData()`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/customxmlpart/#getXmlData) a [`setXmlData()`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/customxmlpart/#setXmlData) pro práci s čistými bajty XML.

Metoda [`CustomXmlPart::getItemId()`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/customxmlpart/#getItemId) vrací UUID, které identifikuje vlastní XML část v dokumentu Office Open XML. Použijte [`setItemId()`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/customxmlpart/#setItemId), pokud integrace vyžaduje nový identifikátor.

Následující příklad aktualizuje XML obsah a identifikátor:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $customXmlPart = $presentation->getAllCustomXmlParts()[0];

    // Přečtěte aktuální XML jako text.
    $currentXmlContent = $customXmlPart->getXmlAsString();
    echo $currentXmlContent . PHP_EOL;

    // Aktualizujte XML jako řetězec UTF-8.
    $customXmlPart->setXmlAsString(
        '<metadata xmlns="urn:example:metadata">' .
            '<documentId>DOC-1001</documentId>' .
            '<workflowState>Approved</workflowState>' .
        '</metadata>'
    );

    // getXmlData poskytuje stejný XML obsah jako surové bajty.
    $customXmlData = $customXmlPart->getXmlData();

    // Nahraďte identifikátor, pokud to vyžaduje integrace.
    $UUID = new JavaClass("java.util.UUID");
    $customXmlPart->setItemId($UUID->randomUUID());

    $presentation->save("updated_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Při volání `setXmlAsString` nebo `setXmlData` poskytněte platné, neprázdné XML. Použijte buď řetězcovou, nebo bajtovou reprezentaci podle toho, zda aplikace pracuje primárně s řetězci nebo s bajty.

### **Odstranění vlastní XML části**

Aspose.Slides poskytuje několik způsobů, jak odstranit vlastní XML data:

- [`CustomXmlPart::remove`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/customxmlpart/#remove) odstraňuje vlastní XML část z prezentace.
- [`CustomXmlPartCollection::remove`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/customxmlpartcollection/#remove) odstraňuje konkrétní část z kolekce vlastních XML částí.
- [`CustomXmlPartCollection::removeAt`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/customxmlpartcollection/#removeAt) odstraňuje část na zadaném indexu kolekce.
- [`CustomXmlPartCollection::clear`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/customxmlpartcollection/#clear) odstraňuje všechny části z konkrétní kolekce.

Následující příklad odstraňuje jednu vlastní XML část na úrovni prezentace podle reference:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $customXmlParts = $presentation->getCustomData()->getCustomXmlParts();

    if (java_values($customXmlParts->size()) > 0) {
        $customXmlPart = $customXmlParts->get_Item(0);
        $customXmlParts->remove($customXmlPart);
    }

    $presentation->save("custom_xml_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Pokud již máte objekt `CustomXmlPart` a chcete tuto část odstranit z prezentace místo adresování konkrétní kolekce, zavolejte `$customXmlPart->remove()`.

Můžete také odstranit položku podle indexu:

```php
$presentation->getCustomData()->getCustomXmlParts()->removeAt(0);
```

### **Vymazání všech vlastních XML částí ze sbírky**

Použijte `clear`, když mají být odstraněny všechny vlastní XML části spojené s konkrétním objektem prezentace.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getSlides()->get_Item(0)->getCustomData()->getCustomXmlParts()->clear();

    $presentation->save("slide_custom_xml_cleared.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`clear` ovlivňuje pouze vybranou kolekci. Například vymazání kolekce snímku nevymaže kolekce na úrovni prezentace ani tvaru.

Pro odstranění každé vlastní XML části v prezentaci iterujte přes `getAllCustomXmlParts()` a odstraňte každou část:

```php
$presentation = new Presentation("presentation.pptx");
try {
    foreach ($presentation->getAllCustomXmlParts() as $customXmlPart) {
        $customXmlPart->remove();
    }

    $presentation->save("all_custom_xml_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Zpracování propojených nebo sdílených vlastních XML částí**

V prezentaci Office Open XML může být stejná vlastní XML část odkazována z více objektů prezentace. Například existující soubor může obsahovat vztahy z více snímků nebo tvarů ke stejné podkladové vlastní XML části.

Sdílenou část byste měli považovat za jeden datový objekt s více odkazy:

- Aktualizace pomocí `setXmlAsString`, `setXmlData` nebo `setItemId` mění podkladovou vlastní XML část, takže změna se projeví všude, kde je část odkazována.
- `getItemId()` lze použít k identifikaci stejné vlastní XML části při auditu kolekcí na úrovni objektů.
- Odstranění části z konkrétní kolekce `getCustomXmlParts()` ji odebere jen z této kolekce. Použijte `CustomXmlPart::remove()` pokud má být část odstraněna z celé prezentace.
- Před smazáním nebo nahrazením sdílené části prozkoumejte kolekce na úrovni objektů, abyste zjistili, zda na ni ještě odkazují jiné snímky nebo tvary.

Přetížení `add` vytváří novou vlastní XML část z XML obsahu; nepřijímá existující `CustomXmlPart`. Proto se sdílené vztahy nejčastěji vyskytují při načítání prezentací, které je již obsahují.

Následující příklad auditu kolekcí na úrovni prezentace, snímku a tvaru podle `ItemId` a hlásí části odkazované z více míst:

```php
function registerCustomXmlParts($ownerName, $customXmlParts, &$referencesByItemId) {
    $partCount = java_values($customXmlParts->size());

    for ($i = 0; $i < $partCount; $i++) {
        $customXmlPart = $customXmlParts->get_Item($i);
        $itemId = java_values($customXmlPart->getItemId()->toString());

        if (!isset($referencesByItemId[$itemId])) {
            $referencesByItemId[$itemId] = [];
        }

        $referencesByItemId[$itemId][] = $ownerName;
    }
}

$presentation = new Presentation("presentation.pptx");
try {
    $referencesByItemId = [];

    registerCustomXmlParts(
        "Presentation",
        $presentation->getCustomData()->getCustomXmlParts(),
        $referencesByItemId
    );

    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        registerCustomXmlParts(
            "Slide " . ($slideIndex + 1),
            $slide->getCustomData()->getCustomXmlParts(),
            $referencesByItemId
        );

        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            registerCustomXmlParts(
                "Slide " . ($slideIndex + 1) . ", shape " . $shapeIndex,
                $shape->getCustomData()->getCustomXmlParts(),
                $referencesByItemId
            );
        }
    }

    foreach ($referencesByItemId as $itemId => $owners) {
        if (count($owners) > 1) {
            echo "Shared custom XML part: " . $itemId . PHP_EOL;

            foreach ($owners as $ownerName) {
                echo "  Referenced by: " . $ownerName . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Tento typ auditu je užitečný před úpravou nebo smazáním vlastních XML dat v prezentacích vytvořených externími systémy, protože stejná metadata mohou být součástí více vztahů.

## **Získání hodnot tagů**

V Slides odpovídá tag metodě `DocumentProperties::getKeywords()`. Tento ukázkový kód ukazuje, jak získat hodnotu tagu pomocí Aspose.Slides pro PHP via Java pro [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/):

```php
$presentation = new Presentation("presentation.pptx");
try {
    $keywords = $presentation->getDocumentProperties()->getKeywords();
} finally {
    $presentation->dispose();
}
```

## **Přidání tagů do prezentací**

Aspose.Slides umožňuje přidávat tagy do prezentací. Tag obvykle sestává ze dvou položek:

- název vlastní vlastnosti, například `MyTag`;
- hodnota vlastní vlastnosti, například `My Tag Value`.

Pokud potřebujete klasifikovat prezentace podle konkrétního pravidla nebo vlastnosti, můžete pro tento účel přidat tagy. Například pokud chcete kategorizovat prezentace ze severoamerických zemí, můžete vytvořit tag „North American“ a přiřadit jako jeho hodnotu příslušnou zemi.

Tento ukázkový kód ukazuje, jak přidat tag k [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) pomocí Aspose.Slides pro PHP via Java:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $tags = $presentation->getCustomData()->getTags();
    $tags->set_Item("MyTag", "My Tag Value");
} finally {
    $presentation->dispose();
}
```

Tagy lze také nastavit pro [Slide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slide/):

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getCustomData()->getTags()->set_Item("tag", "value");
} finally {
    $presentation->dispose();
}
```

Nebo pro jednotlivý [Shape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/):

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 50);
    $shape->getTextFrame()->setText("My text");
    $shape->getCustomData()->getTags()->set_Item("tag", "value");
} finally {
    $presentation->dispose();
}
```

### **Omezení**

Tagy přidané prostřednictvím kolekce `getCustomData()->getTags()` jsou uloženy pouze v souboru PowerPoint. **Nejsou** převedeny do struktury tagů PDF při exportu prezentace do PDF. V důsledku toho nelze získat vlastní identifikátor uložený jako tag z označeného PDF.

**Obejití**: Můžete uložit vlastní identifikátor do **Alt Text** objektu (například `$shape->setAlternativeText("MyId")`). Po exportu do PDF se může Alt Text objevit ve struktuře tagů PDF.

## **Často kladené otázky**

**Mohu odstranit všechny tagy z prezentace, snímku nebo tvaru v jedné operaci?**

Ano. Kolekce [tagů](https://reference.aspose.com/slides/cs/php-java/aspose.slides/tagcollection/) podporuje operaci [clear](https://reference.aspose.com/slides/cs/php-java/aspose.slides/tagcollection/#clear), která najednou smaže všechny páry klíč‑hodnota.

**Jak mohu smazat jeden tag podle jeho názvu, aniž bych procházel celou sbírku?**

Použijte `remove(name)` na kolekci [tagů](https://reference.aspose.com/slides/cs/php-java/aspose.slides/tagcollection/) pro smazání tagu podle jeho klíče.

**Jak mohu získat kompletní seznam názvů tagů pro analytiku nebo filtrování?**

Použijte `getNamesOfTags` na kolekci [tagů](https://reference.aspose.com/slides/cs/php-java/aspose.slides/tagcollection/); vrátí pole všech názvů tagů.

**Jak mohu najít všechny vlastní XML části bez ohledu na to, kde jsou uloženy?**

Použijte [`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#getAllCustomXmlParts) pro získání všech vlastních XML částí v prezentaci.

**Mám použít `getXmlAsString`/`setXmlAsString` nebo `getXmlData`/`setXmlData` k aktualizaci vlastní XML části?**

Použijte `getXmlAsString` a `setXmlAsString`, když aplikace pracuje s XML textem v kódování UTF‑8. Použijte `getXmlData` a `setXmlData`, když je XML již dostupné jako pole bajtů nebo je výhodnější binární zpracování. Obě reprezentace odkazují na stejný XML obsah vlastní XML části.