---
title: Beheer gevoeligheidslabels in PowerPoint‑presentaties met PHP
linktitle: Gevoeligheidslabels
type: docs
weight: 50
url: /nl/php-java/sensitivity-labels/
keywords:
- gevoeligheidslabel
- Microsoft Purview
- Microsoft Information Protection
- MIP metadata
- inhoudsmarkering
- informatiebeveiliging
- documentbeheer
- PowerPoint
- PPTX
- presentatiebeveiliging
- PHP
- Aspose.Slides
description: "Lees, voeg toe, werk bij, verwijder en migreer Microsoft Purview‑gevoeligheidslabels in PowerPoint PPTX‑presentaties in PHP."
---
## **Overzicht**

Microsoft Purview-gevoeligheidslabels helpen organisaties documenten te classificeren en te beheren. Tijdens geautomatiseerde presentatieverwerking kan een toepassing een bestaand label moeten behouden, een label toepassen dat door een beleid is geselecteerd, de status bijwerken, of labelmetadata migren die door een oudere Microsoft Information Protection (MIP)-workflow is geschreven.

Aspose.Slides for PHP via Java maakt moderne gevoeligheidslabelmetadata beschikbaar via [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#getSensitivityLabels). Deze methode retourneert een [SensitivityLabelCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sensitivitylabelcollection/) die kan worden geïnspecteerd en aangepast voordat de presentatie wordt opgeslagen als PPTX.

{{% alert color="primary" title="Opmerking" %}}
Gevoeligheidslabelidentifiers en beleidsinformatie worden gedefinieerd door uw Microsoft Purview-configuratie. Controleer de beschikbaarheid van labels en beleidsvereisten in uw omgeving voordat u metadata toevoegt of migreert. De waarden van [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) beschrijven de inhoudsmarkeringen die aan een label zijn gekoppeld; ze voegen op zichzelf geen zichtbare tekst of vormen toe aan dia's.
{{% /alert %}}

## **Begrijp gevoeligheidslabeleigenschappen**

Elke [SensitivityLabel](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sensitivitylabel/) bevat de volgende metadata:

| Methoden | Doel |
| --- | --- |
| [SensitivityLabel::getId](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sensitivitylabel/#getId) en [SensitivityLabel::setId](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sensitivitylabel/#setId) | Ophalen of instellen van het gevoeligheidslabel‑identificatie in het Purview‑beleid. |
| [SensitivityLabel::getSiteId](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sensitivitylabel/#getSiteId) en [SensitivityLabel::setSiteId](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sensitivitylabel/#setSiteId) | Ophalen of instellen van de site die aan het labelbeleid is gekoppeld. |
| [SensitivityLabel::isEnabled](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sensitivitylabel/#isEnabled) en [SensitivityLabel::setEnabled](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sensitivitylabel/#setEnabled) | Ophalen of instellen of het label is ingeschakeld. |
| [SensitivityLabel::isRemoved](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sensitivitylabel/#isRemoved) en [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sensitivitylabel/#setRemoved) | Ophalen of instellen of het label is verwijderd. Stel de waarde in op `true` wanneer de verwijderingsstatus moet worden behouden in de metadata. |
| [SensitivityLabel::getAssignmentMethodType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) en [SensitivityLabel::setAssignmentMethodType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | Ophalen of instellen of het label automatisch is toegepast of via een gebruikersbeslissing. |
| [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | Ophalen van de types inhoudsmarkeringen die aan het label zijn gekoppeld. |

De klasse [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sensitivitylabelassignmenttype/) definieert hoe een label is toegewezen:

- [SensitivityLabelAssignmentType::Standard](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sensitivitylabelassignmenttype/) vertegenwoordigt een standaard of automatisch toegepast label.
- [SensitivityLabelAssignmentType::Privileged](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sensitivitylabelassignmenttype/) vertegenwoordigt een label dat via een gebruikersbeslissing is toegepast, inclusief handmatig toegepaste, aanbevolen en verplichte labels.

De klasse [SensitivityLabelContentType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sensitivitylabelcontenttype/) definieert de markering die bij een label hoort:

| Waarde | Betekenis |
| --- | --- |
| [SensitivityLabelContentType::None](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sensitivitylabelcontenttype/) | Het label is standaard of automatisch toegepast. |
| [SensitivityLabelContentType::Header](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sensitivitylabelcontenttype/) | Koptekstinhoudmarkering is gekoppeld aan het label. |
| [SensitivityLabelContentType::Footer](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sensitivitylabelcontenttype/) | Voettekstinhoudmarkering is gekoppeld aan het label. |
| [SensitivityLabelContentType::Watermark](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sensitivitylabelcontenttype/) | Watermerkinhoudmarkering is gekoppeld aan het label. |
| [SensitivityLabelContentType::Encryption](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sensitivitylabelcontenttype/) | Encryptiebescherming is gekoppeld aan het label. |

Meerdere markeringstypen kunnen aan één label worden gekoppeld.

## **Lijst bestaande gevoeligheidslabels**

Lees de moderne labelcollectie van [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#getSensitivityLabels) en doorloop deze. Het onderstaande voorbeeld geeft elke eigenschap en inhoudsmarkering weer die voor elk label is opgeslagen:

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

## **Voeg een gevoeligheidslabel toe met inhoudsmarkering**

Gebruik [SensitivityLabelCollection::add](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sensitivitylabelcollection/#add) met het label‑identificatie, site‑identificatie, de ingeschakelde status en de toekenningsmethode. Nadat de methode het nieuwe [SensitivityLabel](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sensitivitylabel/) heeft geretourneerd, voeg je de vereiste markeringwaarden toe via de lijst die wordt geretourneerd door [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes).

Het onderstaande voorbeeld voegt een handmatig geselecteerd label toe dat gekoppeld is aan voettekst‑ en watermerk‑markeringen, en slaat vervolgens het resultaat op als PPTX:

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

## **Werk een gevoeligheidslabel bij**

De waarden van [SensitivityLabel](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sensitivitylabel/) zijn lees‑/schrijfbaar, behalve dat de lijst die wordt geretourneerd door [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) wordt aangepast via zijn lijstbewerkingen. Nadat je het benodigde label hebt gevonden, kun je de identificatie, site‑identificatie, ingeschakelde status, toekenningsmethode, verwijderingsstatus en inhoudsmarkeringstypen bijwerken. Sla de presentatie op om de wijzigingen te bewaren.

Het onderstaande voorbeeld werkt de ingeschakelde status en toekenningsmethode van het eerste label bij:

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

## **Markeer een gevoeligheidslabel als verwijderd**

Om het feit te behouden dat een label is verwijderd, zoek je het label en roep je [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sensitivitylabel/#setRemoved) aan met `true`. Hiermee blijft de label‑vermelding behouden en wordt de verwijderingsstatus vastgelegd. Als je in plaats daarvan een vermelding uit de moderne collectie wilt verwijderen, gebruik dan [SensitivityLabelCollection::removeAt](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sensitivitylabelcollection/#removeAt); gebruik [SensitivityLabelCollection::clear](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sensitivitylabelcollection/#clear) om elke vermelding te verwijderen.

Het onderstaande voorbeeld markeert een specifiek label als verwijderd en slaat de bijgewerkte presentatie op:

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

## **Lees en migreer legacy MIP-gevoeligheidslabels**

Ouder MIP‑gebaseerde workflows kunnen gevoeligheidslabelmetadata opslaan in aangepaste documenteigenschappen in plaats van in de moderne labelcollectie. Lees die metadata met [DocumentProperties::getSensitivityLabels](https://reference.aspose.com/slides/nl/php-java/aspose.slides/documentproperties/#getSensitivityLabels). De methode analyseert de legacy‑aangepaste eigenschappen en retourneert een Java‑array van [SensitivityLabel](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sensitivitylabel/)‑objecten.

Om de metadata te migren, voeg je elk geretourneerd label toe aan de moderne [SensitivityLabelCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sensitivitylabelcollection/) via [SensitivityLabelCollection::add](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sensitivitylabelcollection/#add). Omdat het toevoegen van een dubbel label‑identificatie een uitzondering veroorzaakt, controleert het voorbeeld de doelcollectie voordat elk label wordt gekopieerd. Je kunt extra validatie toevoegen om te bevestigen dat elk legacy‑label nog steeds bestaat in het huidige Purview‑beleid.

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

De migratie kopieert de geanalyseerde labelobjecten naar de moderne collectie. Het is niet nodig om alle aangepaste documenteigenschappen te wissen, zodat gerelateerde documentmetadata intact blijft. Gebruik [Presentation::save](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#save) met [SaveFormat::Pptx](https://reference.aspose.com/slides/nl/php-java/aspose.slides/saveformat/) om de moderne labelmetadata naar een PPTX‑bestand te schrijven.

## **FAQ**

**Voegt het toevoegen van een inhoudsmarkeringstype een zichtbare koptekst, voettekst of watermerk toe aan dia's?**

Nee. Waarden die worden toegevoegd via de lijst die wordt geretourneerd door [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) beschrijven de markeringen die bij het gevoeligheidslabel horen. Ze creëren geen zichtbare tekst of vormen in de presentatie. Voeg de overeenkomstige dia‑inhoud apart toe als uw workflow die markeringen moet weergeven.

**Wat is het verschil tussen een label markeren als verwijderd en het verwijderen uit de collectie?**

Het aanroepen van [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sensitivitylabel/#setRemoved) met `true` houdt de labelvermelding vast en registreert de verwijderingsstatus. Het aanroepen van [SensitivityLabelCollection::removeAt](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sensitivitylabelcollection/#removeAt) verwijdert de vermelding uit de moderne collectie. Kies de bewerking die overeenkomt met de bewaareisen voor metadata van uw organisatie.

**Kan een presentatie zowel legacy MIP‑metadata als moderne gevoeligheidslabels bevatten?**

Ja. Legacy‑labels kunnen behouden blijven in aangepaste documenteigenschappen terwijl moderne labels beschikbaar zijn via [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#getSensitivityLabels). Gebruik [DocumentProperties::getSensitivityLabels](https://reference.aspose.com/slides/nl/php-java/aspose.slides/documentproperties/#getSensitivityLabels) om de legacy‑metadata te lezen en migreer alleen de geldige labels die nog niet in de moderne collectie aanwezig zijn.

**Wat gebeurt er wanneer een label met dezelfde identificatie meer dan eens wordt toegevoegd?**

[SensitivityLabelCollection::add](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sensitivitylabelcollection/#add) veroorzaakt een uitzondering wanneer de collectie al een label met dezelfde identificatie bevat. Controleer de bestaande waarden die worden geretourneerd door [SensitivityLabel::getId](https://reference.aspose.com/slides/nl/php-java/aspose.slides/sensitivitylabel/#getId) voordat je labels toevoegt of migreert.

**Welk uitvoerformaat moet worden gebruikt om bijgewerkte gevoeligheidslabels te behouden?**

Sla de presentatie op als PPTX door [Presentation::save](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#save) aan te roepen met [SaveFormat::Pptx](https://reference.aspose.com/slides/nl/php-java/aspose.slides/saveformat/), zoals getoond in de bovenstaande voorbeelden.