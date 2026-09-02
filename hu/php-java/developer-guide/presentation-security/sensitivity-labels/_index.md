---
title: "Szenzitivitási címkék kezelése PowerPoint prezentációkban PHP-ben"
linktitle: "Szenzitivitási címkék"
type: docs
weight: 50
url: /hu/php-java/sensitivity-labels/
keywords:
- "szenzitivitási címke"
- "Microsoft Purview"
- "Microsoft Information Protection"
- "MIP metaadatok"
- "tartalomjelölés"
- "információvédelem"
- "dokumentumirányítás"
- "PowerPoint"
- "PPTX"
- "prezentációbiztonság"
- "PHP"
- "Aspose.Slides"
description: "Microsoft Purview szenzitivitási címkék olvasása, hozzáadása, frissítése, eltávolítása és migrálása PowerPoint PPTX prezentációkban PHP-ben."
---
## **Áttekintés**

A Microsoft Purview szenzitivitási címkék segítik a szervezeteket a dokumentumok osztályozásában és irányításában. Automatizált prezentációfeldolgozás során egy alkalmazásnak meg kell őriznie egy meglévő címkét, egy szabályzat által kiválasztott címkét alkalmaznia, frissítenie annak állapotát, vagy migrálnia kell a régebbi Microsoft Information Protection (MIP) munkafolyamat által írt címke metaadatokat.

Az Aspose.Slides for PHP via Java a modern szenzitivitási címke metaadatokat a [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#getSensitivityLabels) metóduson keresztül teszi elérhetővé. Ez a metódus egy [SensitivityLabelCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sensitivitylabelcollection/) ad vissza, amelyet a prezentáció PPTX formátumban történő mentése előtt ellenőrizni és módosítani lehet.

{{% alert color="primary" title="Megjegyzés" %}}
A szenzitivitási címke azonosítók és a szabályzati információk a Microsoft Purview beállításában vannak definiálva. Ellenőrizze a címkék elérhetőségét és a szabályzat követelményeit a környezetében, mielőtt metaadatot adna hozzá vagy migrálná. A [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) értékek leírják a címkéhez társított tartalomjelöléseket; ezek önmagukban nem adnak hozzá látható szöveget vagy alakzatot a diákhoz.
{{% /alert %}}

## **Értse meg a szenzitivitási címke tulajdonságait**

Minden [SensitivityLabel](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sensitivitylabel/) a következő metaadatokat tartalmazza:

| Módszerek | Cél |
| --- | --- |
| [SensitivityLabel::getId](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sensitivitylabel/#getId) és [SensitivityLabel::setId](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sensitivitylabel/#setId) | A szenzitivitási címke azonosítójának lekérdezése vagy beállítása a Purview szabályzatban. |
| [SensitivityLabel::getSiteId](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sensitivitylabel/#getSiteId) és [SensitivityLabel::setSiteId](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sensitivitylabel/#setSiteId) | A címke szabályzathoz kapcsolódó webhely lekérdezése vagy beállítása. |
| [SensitivityLabel::isEnabled](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sensitivitylabel/#isEnabled) és [SensitivityLabel::setEnabled](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sensitivitylabel/#setEnabled) | A címke engedélyezett állapotának lekérdezése vagy beállítása. |
| [SensitivityLabel::isRemoved](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sensitivitylabel/#isRemoved) és [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sensitivitylabel/#setRemoved) | A címke eltávolításra került-e állapot lekérdezése vagy beállítása. Állítsa `true`-ra, ha a eltávolítási állapotot a metaadatban meg kell őrizni. |
| [SensitivityLabel::getAssignmentMethodType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) és [SensitivityLabel::setAssignmentMethodType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | A címke automatikus vagy felhasználói döntés alapján történő alkalmazásának lekérdezése vagy beállítása. |
| [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | A címkéhez kapcsolódó tartalomjelölés típusok lekérdezése. |

A [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sensitivitylabelassignmenttype/) osztály meghatározza, hogyan lett egy címke hozzárendelve:

- [SensitivityLabelAssignmentType::Standard](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sensitivitylabelassignmenttype/) a alapértelmezett vagy automatikusan alkalmazott címkét jelöli.  
- [SensitivityLabelAssignmentType::Privileged](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sensitivitylabelassignmenttype/) felhasználói döntés alapján alkalmazott címkét jelöl, beleértve a manuálisan alkalmazott, ajánlott és kötelező címkéket.

A [SensitivityLabelContentType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sensitivitylabelcontenttype/) osztály definiálja a címkéhez kapcsolódó jelölést:

| Érték | Jelentés |
| --- | --- |
| [SensitivityLabelContentType::None](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sensitivitylabelcontenttype/) | A címke alapértelmezett vagy automatikus módon lett alkalmazva. |
| [SensitivityLabelContentType::Header](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sensitivitylabelcontenttype/) | Fejléc tartalomjelölés van társítva a címkéhez. |
| [SensitivityLabelContentType::Footer](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sensitivitylabelcontenttype/) | Lábléc tartalomjelölés van társítva a címkéhez. |
| [SensitivityLabelContentType::Watermark](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sensitivitylabelcontenttype/) | Vízjel tartalomjelölés van társítva a címkéhez. |
| [SensitivityLabelContentType::Encryption](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sensitivitylabelcontenttype/) | Titkosítási védelem van társítva a címkéhez. |

Több jelöléstípus is társítható egy címkéhez.

## **Létező szenzitivitási címkék listázása**

Olvassa be a modern címke gyűjteményt a [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#getSensitivityLabels) metódussal, és sorolja fel. Az alábbi példa minden tulajdonságot és a címkehez tárolt tartalomjelölést listáz:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();
    $sensitivityLabelCount = java_values($sensitivityLabels->getCount());

    for ($labelIndex = 0; $labelIndex < $sensitivityLabelCount; $labelIndex++) {
        $sensitivityLabel = $sensitivityLabels->get_Item($labelIndex);

        echo "Label ID: " . java_values($sensitivityLabel->getId()) . PHP_EOL;
        echo "Site ID: " . java_values($sensitivityLabel->getSiteId()->toString()) . PHP_EOL;
        echo "Enabled: " . (java_values($sensitivityLabel->isEnabled()) ? "true" : "false") . PHP_EOL;
        echo "Removed: " . (java_values($sensitivityLabel->isRemoved()) ? "true" : "false") . PHP_EOL;
        echo "Assignment method: " . java_values($sensitivityLabel->getAssignmentMethodType()) . PHP_EOL;

        $contentMarkIterator = $sensitivityLabel->getContentMarkTypes()->iterator();
        while (java_values($contentMarkIterator->hasNext())) {
            $contentMarkType = java_values($contentMarkIterator->next());
            echo "Content marking: " . $contentMarkType . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Szenzitivitási címke hozzáadása tartalomjelöléssel**

Használja a [SensitivityLabelCollection::add](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sensitivitylabelcollection/#add) metódust a címke azonosítóval, a webhely azonosítóval, az engedélyezett állapottal és a hozzárendelési módszerrel. A metódus visszaadja az új [SensitivityLabel](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sensitivitylabel/) objektumot, majd adja hozzá a szükséges jelölésértékeket a [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) által visszaadott listán keresztül.

Az alábbi példa manuálisan kiválasztott címkét ad hozzá, amelyhez lábléc és vízjel jelölések vannak társítva, majd elmenti az eredményt PPTX formátumban:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();

    $labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    $UUID = new JavaClass("java.util.UUID");
    $siteIdentifier = $UUID->fromString("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee");
    $isEnabled = true;
    $assignmentMethod = SensitivityLabelAssignmentType::Privileged;

    $sensitivityLabel = $sensitivityLabels->add(
        $labelIdentifier,
        $siteIdentifier,
        $isEnabled,
        $assignmentMethod
    );

    $contentMarkTypes = $sensitivityLabel->getContentMarkTypes();
    $contentMarkTypes->addItem(SensitivityLabelContentType::Footer);
    $contentMarkTypes->addItem(SensitivityLabelContentType::Watermark);

    $presentation->save("presentation_with_label.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Szenzitivitási címke frissítése**

A [SensitivityLabel](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sensitivitylabel/) értékek olvashatóak/írhatóak, kivéve a [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) által visszaadott listát, amelyet a lista műveleteken keresztül módosítanak. A kívánt címke megtalálása után frissítheti annak azonosítóját, webhely azonosítóját, engedélyezett állapotát, hozzárendelési módját, eltávolítási állapotát és tartalomjelölés típusait. Mentse a prezentációt a változások rögzítéséhez.

Az alábbi példa frissíti az első címke engedélyezett állapotát és hozzárendelési módját:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();
    $sensitivityLabelCount = java_values($sensitivityLabels->getCount());

    if ($sensitivityLabelCount > 0) {
        $sensitivityLabel = $sensitivityLabels->get_Item(0);
        $sensitivityLabel->setEnabled(true);
        $sensitivityLabel->setAssignmentMethodType(SensitivityLabelAssignmentType::Privileged);
    }

    $presentation->save("presentation_with_updated_label.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Szenzitivitási címke eltávolítva jelölése**

A címke eltávolításának megőrzéséhez találja meg a címkét, és hívja meg a [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sensitivitylabel/#setRemoved) metódust `true` értékkel. Ez megőrzi a címke bejegyzést miközben rögzíti az eltávolított állapotát. Ha ehelyett egy bejegyzést szeretne törölni a modern gyűjteményből, használja a [SensitivityLabelCollection::removeAt](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sensitivitylabelcollection/#removeAt) metódust; a [SensitivityLabelCollection::clear](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sensitivitylabelcollection/#clear) metódussal minden bejegyzést törölhet.

Az alábbi példa egy konkrét címkét eltávolítottként jelöl, és elmenti a frissített prezentációt:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();
    $targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    $sensitivityLabelCount = java_values($sensitivityLabels->getCount());

    for ($labelIndex = 0; $labelIndex < $sensitivityLabelCount; $labelIndex++) {
        $sensitivityLabel = $sensitivityLabels->get_Item($labelIndex);
        $labelIdentifier = java_values($sensitivityLabel->getId());
        $isTargetLabel = strcasecmp($labelIdentifier, $targetLabelIdentifier) === 0;

        if ($isTargetLabel) {
            $sensitivityLabel->setRemoved(true);
            break;
        }
    }

    $presentation->save("presentation_with_removed_label.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Régi MIP szenzitivitási címkék beolvasása és migrálása**

A régebbi MIP-alapú munkafolyamatok a szenzitivitási címke metaadatokat egyedi dokumentumtulajdonságokban tárolhatják a modern címke gyűjtemény helyett. Olvassa be ezeket a metaadatokat a [DocumentProperties::getSensitivityLabels](https://reference.aspose.com/slides/hu/php-java/aspose.slides/documentproperties/#getSensitivityLabels) metódussal. A metódus feldolgozza a régi egyedi tulajdonságokat, és egy Java tömböt ad vissza [SensitivityLabel](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sensitivitylabel/) objektumokkal.

A metaadatok migrálásához adja hozzá minden visszaadott címkét a modern [SensitivityLabelCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sensitivitylabelcollection/) gyűjteményhez a [SensitivityLabelCollection::add](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sensitivitylabelcollection/#add) használatával. Mivel egy duplikált címke azonosító hozzáadása kivételt eredményez, a példa ellenőrzi a célgyűjteményt minden címke másolása előtt. További ellenőrzést is végezhet annak biztosítására, hogy minden régi címke még létezik-e az aktuális Purview szabályzatban.

A migráció átmásolja a feldolgozott címkeobjektumokat a modern gyűjteménybe. Nem szükséges az összes egyedi dokumentumtulajdonság törlése, így a nem kapcsolódó dokumentum metaadatok érintetlenek maradnak. Használja a [Presentation::save](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#save) metódust a [SaveFormat::Pptx](https://reference.aspose.com/slides/hu/php-java/aspose.slides/saveformat/) paraméterrel, hogy a modern címke metaadatokat PPTX fájlba írja.

```php
$presentation = new Presentation("presentation_with_legacy_labels.pptx");
try {
    $legacySensitivityLabels = $presentation->getDocumentProperties()->getSensitivityLabels();
    $modernSensitivityLabels = $presentation->getSensitivityLabels();

    $Array = new JavaClass("java.lang.reflect.Array");
    $legacyLabelCount = java_values($Array->getLength($legacySensitivityLabels));

    for ($legacyLabelIndex = 0; $legacyLabelIndex < $legacyLabelCount; $legacyLabelIndex++) {
        $legacySensitivityLabel = $legacySensitivityLabels[$legacyLabelIndex];
        $legacyLabelIdentifier = java_values($legacySensitivityLabel->getId());
        $labelAlreadyExists = false;
        $modernLabelCount = java_values($modernSensitivityLabels->getCount());

        for ($modernLabelIndex = 0; $modernLabelIndex < $modernLabelCount; $modernLabelIndex++) {
            $modernSensitivityLabel = $modernSensitivityLabels->get_Item($modernLabelIndex);
            $modernLabelIdentifier = java_values($modernSensitivityLabel->getId());
            $labelAlreadyExists = strcasecmp(
                $modernLabelIdentifier,
                $legacyLabelIdentifier
            ) === 0;

            if ($labelAlreadyExists) {
                break;
            }
        }

        if (!$labelAlreadyExists) {
            $modernSensitivityLabels->add($legacySensitivityLabel);
        }
    }

    $presentation->save("presentation_with_modern_labels.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **GyIK**

**A tartalomjelölés típus hozzáadása látható fejlécet, láblécet vagy vízjelet hoz létre a diákon?**

Nem. A [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) lista által hozzáadott értékek a címkehez tartozó jelöléseket írják le; ezek önmagukban nem hoznak létre látható szöveget vagy alakzatot a prezentációban. Ha a munkafolyamatnak meg kell jelenítenie ezeket a jelöléseket, adja hozzá a megfelelő dia tartalmat külön.

**Mi a különbség a címke eltávolítottként jelölése és a gyűjteményből való törlése között?**

A [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sensitivitylabel/#setRemoved) `true` értékkel való meghívása megtartja a címke bejegyzést és rögzíti az eltávolított állapotát. A [SensitivityLabelCollection::removeAt](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sensitivitylabelcollection/#removeAt) meghívása törli a bejegyzést a modern gyűjteményből. Válassza azt a műveletet, amely megfelel szervezete metaadat-megőrzési követelményeinek.

**Tartalmazhat egy prezentáció egyszerre régi MIP metaadatokat és modern szenzitivitási címkéket?**

Igen. A régi címkék megmaradhatnak az egyedi dokumentumtulajdonságokban, míg a modern címkék a [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#getSensitivityLabels) segítségével érhetők el. Használja a [DocumentProperties::getSensitivityLabels](https://reference.aspose.com/slides/hu/php-java/aspose.slides/documentproperties/#getSensitivityLabels) metódust a régi metaadatok beolvasásához, és csak a modern gyűjteményben még nem létező, érvényes címkéket migrálja.

**Mi történik, ha ugyanazzal az azonosítóval több címkét adunk hozzá?**

A [SensitivityLabelCollection::add](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sensitivitylabelcollection/#add) kivételt dob, ha a gyűjtemény már tartalmaz egy azonos azonosítóval rendelkező címkét. Ellenőrizze a [SensitivityLabel::getId](https://reference.aspose.com/slides/hu/php-java/aspose.slides/sensitivitylabel/#getId) által visszaadott meglévő értékeket, mielőtt címkét adna hozzá vagy migrálná.

**Melyik kimeneti formátumot kell használni a frissített szenzitivitási címkék megőrzéséhez?**

Mentse a prezentációt PPTX formátumban a [Presentation::save](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/#save) [SaveFormat::Pptx](https://reference.aspose.com/slides/hu/php-java/aspose.slides/saveformat/) paraméterrel, ahogyan a fenti példákban is látható.