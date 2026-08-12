---
title: Správa citlivých štítků v prezentacích PowerPoint v PHP
linktitle: Citlivé štítky
type: docs
weight: 50
url: /cs/php-java/sensitivity-labels/
keywords:
- citlivý štítek
- Microsoft Purview
- Microsoft Information Protection
- metadata MIP
- označování obsahu
- ochrana informací
- správa dokumentů
- PowerPoint
- PPTX
- bezpečnost prezentace
- PHP
- Aspose.Slides
description: "Čtěte, přidávejte, aktualizujte, odstraňujte a migrujte citlivé štítky Microsoft Purview v prezentacích PowerPoint PPTX v PHP."
---
## **Přehled**

Microsoft Purview sensitivity labels pomáhají organizacím klasifikovat a spravovat dokumenty. Během automatického zpracování prezentací může aplikace potřebovat zachovat existující štítek, použít štítek vybraný politikou, aktualizovat jeho stav nebo migrovat metadata štítku vytvořená starším pracovním postupem Microsoft Information Protection (MIP).

Aspose.Slides for PHP via Java poskytuje moderní metadata citlivých štítků prostřednictvím [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#getSensitivityLabels). Tato metoda vrací [SensitivityLabelCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sensitivitylabelcollection/), kterou lze prozkoumat a upravit před uložením prezentace jako PPTX.

{{% alert color="primary" title="Poznámka" %}}

Identifikátory citlivých štítků a informace o politice jsou definovány ve vaší konfiguraci Microsoft Purview. Ověřte dostupnost štítků a požadavky politiky ve svém prostředí před přidáním nebo migrací metadat. Hodnoty [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) popisují označení obsahu spojená se štítkem; samy osevám nepřidávají viditelný text ani tvary do snímků.

{{% /alert %}}

## **Porozumění vlastnostem citlivých štítků**

Každý [SensitivityLabel](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sensitivitylabel/) obsahuje následující metadata:

| Metody | Účel |
| --- | --- |
| [SensitivityLabel::getId](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sensitivitylabel/#getId) a [SensitivityLabel::setId](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sensitivitylabel/#setId) | Získat nebo nastavit identifikátor citlivého štítku v politice Purview. |
| [SensitivityLabel::getSiteId](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sensitivitylabel/#getSiteId) a [SensitivityLabel::setSiteId](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sensitivitylabel/#setSiteId) | Získat nebo nastavit webové místo spojené s politikou štítku. |
| [SensitivityLabel::isEnabled](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sensitivitylabel/#isEnabled) a [SensitivityLabel::setEnabled](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sensitivitylabel/#setEnabled) | Získat nebo nastavit, zda je štítek povolen. |
| [SensitivityLabel::isRemoved](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sensitivitylabel/#isRemoved) a [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sensitivitylabel/#setRemoved) | Získat nebo nastavit, zda byl štítek odstraněn. Nastavte hodnotu na `true`, když má být stav odstranění zachován v metadatech. |
| [SensitivityLabel::getAssignmentMethodType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) a [SensitivityLabel::setAssignmentMethodType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | Získat nebo nastavit, zda byl štítek aplikován automaticky nebo na základě rozhodnutí uživatele. |
| [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | Získat typy označení obsahu spojené se štítkem. |

Třída [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sensitivitylabelassignmenttype/) definuje, jak byl štítek přiřazen:

- [SensitivityLabelAssignmentType::Standard](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sensitivitylabelassignmenttype/) představuje výchozí nebo automaticky aplikovaný štítek.  
- [SensitivityLabelAssignmentType::Privileged](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sensitivitylabelassignmenttype/) představuje štítek aplikovaný na základě rozhodnutí uživatele, včetně ručně aplikovaných, doporučených a povinných štítků.

Třída [SensitivityLabelContentType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sensitivitylabelcontenttype/) definuje označení spojené se štítkem:

| Hodnota | Význam |
| --- | --- |
| [SensitivityLabelContentType::None](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sensitivitylabelcontenttype/) | Štítek byl aplikován výchozím způsobem nebo automaticky. |
| [SensitivityLabelContentType::Header](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sensitivitylabelcontenttype/) | K štítku je přiřazeno označení obsahu v záhlaví. |
| [SensitivityLabelContentType::Footer](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sensitivitylabelcontenttype/) | K štítku je přiřazeno označení obsahu v zápatí. |
| [SensitivityLabelContentType::Watermark](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sensitivitylabelcontenttype/) | K štítku je přiřazeno označení obsahu ve vodotisku. |
| [SensitivityLabelContentType::Encryption](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sensitivitylabelcontenttype/) | K štítku je přiřazena ochrana šifrováním. |

Jednomu štítku může být přiřazeno více typů označení.

## **Seznam existujících citlivých štítků**

Načtěte moderní kolekci štítků pomocí [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#getSensitivityLabels) a projděte ji. Následující příklad vypíše všechny vlastnosti a označení obsahu uložená pro každý štítek:

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

## **Přidání citlivého štítku s označením obsahu**

Použijte [SensitivityLabelCollection::add](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sensitivitylabelcollection/#add) s identifikátorem štítku, identifikátorem webu, stavem povolení a metodou přiřazení. Po vrácení nového [SensitivityLabel](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sensitivitylabel/) přidejte požadované hodnoty označení přes seznam vrácený metodou [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes).

Následující příklad přidá ručně vybraný štítek spojený se značkami v zápatí a vodotisku a poté výsledek uloží jako PPTX:

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

## **Aktualizace citlivého štítku**

Hodnoty [SensitivityLabel](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sensitivitylabel/) jsou zapisovatelné, kromě seznamu vráceného metodou [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes), který se upravuje pomocí jeho operací seznamu. Po nalezení požadovaného štítku můžete aktualizovat jeho identifikátor, identifikátor webu, stav povolení, metodu přiřazení, stav odstranění a typy označení obsahu. Uložte prezentaci, aby se změny zachovaly.

Následující příklad aktualizuje stav povolení a metodu přiřazení prvního štítku:

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

## **Označení citlivého štítku jako odstraněného**

Chcete‑li zachovat fakt, že byl štítek odstraněn, najděte jej a zavolejte [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sensitivitylabel/#setRemoved) s hodnotou `true`. Tím se štítek ponechá v záznamu a zaznamená se jeho odstraněný stav. Pokud potřebujete ze moderní kolekce štítek smazat, použijte [SensitivityLabelCollection::removeAt](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sensitivitylabelcollection/#removeAt); pro smazání všech položek použijte [SensitivityLabelCollection::clear](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sensitivitylabelcollection/#clear).

Následující příklad označí konkrétní štítek jako odstraněný a uloží aktualizovanou prezentaci:

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

## **Čtení a migrace starých MIP citlivých štítků**

Starší pracovní postupy založené na MIP mohou uchovávat metadata citlivých štítků v uživatelských vlastnostech dokumentu místo moderní kolekce štítků. Načtěte tato metadata pomocí [DocumentProperties::getSensitivityLabels](https://reference.aspose.com/slides/cs/php-java/aspose.slides/documentproperties/#getSensitivityLabels). Metoda analyzuje staré uživatelské vlastnosti a vrací pole Java objektů [SensitivityLabel](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sensitivitylabel/).

Pro migraci metadat přidejte každý vrácený štítek do moderní [SensitivityLabelCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sensitivitylabelcollection/) pomocí [SensitivityLabelCollection::add](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sensitivitylabelcollection/#add). Protože přidání duplicitního identifikátoru štítku vyvolá výjimku, příklad nejprve zkontroluje cílovou kolekci, než jednotlivé štítky zkopíruje. Můžete přidat další ověření, aby bylo potvrzeno, že každý starý štítek stále existuje v aktuální politice Purview.

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

Migrace zkopíruje analyzované objekty štítků do moderní kolekce. Nepožaduje vymazání všech uživatelských vlastností dokumentu, takže nesouvisející metadata zůstávají nedotčena. Použijte [Presentation::save](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#save) s [SaveFormat::Pptx](https://reference.aspose.com/slides/cs/php-java/aspose.slides/saveformat/) pro zápis moderních metadat štítků do souboru PPTX.

## **Často kladené otázky**

**Vytváří přidání typu označení obsahu viditelný záhlaví, zápatí nebo vodotisk na snímcích?**

Ne. Hodnoty přidané přes seznam vrácený metodou [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) popisují označení spojená s citlivým štítkem. Nevytvářejí viditelný text ani tvary v prezentaci. Pokud váš pracovní postup musí tato označení vykreslit, přidejte odpovídající obsah snímku samostatně.

**Jaký je rozdíl mezi označením štítku jako odstraněného a jeho smazáním z kolekce?**

Volání [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sensitivitylabel/#setRemoved) s `true` ponechává záznam štítku a zaznamenává jeho stav odstranění. Volání [SensitivityLabelCollection::removeAt](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sensitivitylabelcollection/#removeAt) štítek z moderní kolekce odstraní. Vyberte operaci, která odpovídá požadavkům vaší organizace na uchovávání metadat.

**Může prezentace obsahovat jak stará MIP metadata, tak moderní citlivé štítky?**

Ano. Staré štítky mohou zůstat v uživatelských vlastnostech dokumentu, zatímco moderní štítky jsou dostupné prostřednictvím [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#getSensitivityLabels). Použijte [DocumentProperties::getSensitivityLabels](https://reference.aspose.com/slides/cs/php-java/aspose.slides/documentproperties/#getSensitivityLabels) pro načtení starých metadat a migrujte pouze platné štítky, které ještě nejsou v moderní kolekci.

**Co se stane, když je štítek se stejným identifikátorem přidán vícekrát?**

[SensitivityLabelCollection::add](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sensitivitylabelcollection/#add) vyvolá výjimku, pokud kolekce již obsahuje štítek se stejným identifikátorem. Před přidáním nebo migrací štítků zkontrolujte existující hodnoty vrácené metodou [SensitivityLabel::getId](https://reference.aspose.com/slides/cs/php-java/aspose.slides/sensitivitylabel/#getId).

**Jaký výstupní formát použít pro zachování aktualizovaných citlivých štítků?**

Uložte prezentaci jako PPTX voláním [Presentation::save](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#save) s [SaveFormat::Pptx](https://reference.aspose.com/slides/cs/php-java/aspose.slides/saveformat/), jak je ukázáno v příkladech výše.