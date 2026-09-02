---
title: Hantera känslighetsetiketter i PowerPoint-presentationer i PHP
linktitle: Känslighetsetiketter
type: docs
weight: 50
url: /sv/php-java/sensitivity-labels/
keywords:
- känslighetsetikett
- Microsoft Purview
- Microsoft Information Protection
- MIP-metadata
- innehållsmarkering
- informationsskydd
- dokumentstyrning
- PowerPoint
- PPTX
- presentationssäkerhet
- PHP
- Aspose.Slides
description: "Läs, lägg till, uppdatera, ta bort och migrera Microsoft Purview‑känslighetsetiketter i PowerPoint‑PPTX‑presentationer i PHP."
---
## **Översikt**

Microsoft Purview‑känslighetsetiketter hjälper organisationer att klassificera och hantera dokument. Vid automatiserad presentation‑behandling kan en applikation behöva bevara en befintlig etikett, tillämpa en etikett som valts av en policy, uppdatera dess tillstånd eller migrera etikett‑metadata som skrivits av ett äldre Microsoft Information Protection (MIP)‑arbetsflöde.

Aspose.Slides för PHP via Java exponerar modern metadata för känslighetsetiketter genom [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#getSensitivityLabels). Denna metod returnerar en [SensitivityLabelCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/sensitivitylabelcollection/) som kan inspekteras och modifieras innan presentationen sparas som PPTX.

{{% alert color="primary" title="Obs" %}}

Identifierare för känslighetsetiketter och policyinformation definieras av din Microsoft Purview‑konfiguration. Validera etikettens tillgänglighet och policykrav i din miljö innan du lägger till eller migrerar metadata. Värdena för [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/sv/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) beskriver innehållsmarkeringarna som är associerade med en etikett; de lägger inte själva till synlig text eller former på bilder.

{{% /alert %}}

## **Förstå egenskaper för känslighetsetiketter**

Varje [SensitivityLabel](https://reference.aspose.com/slides/sv/php-java/aspose.slides/sensitivitylabel/) innehåller följande metadata:

| Metoder | Syfte |
| --- | --- |
| [SensitivityLabel::getId](https://reference.aspose.com/slides/sv/php-java/aspose.slides/sensitivitylabel/#getId) och [SensitivityLabel::setId](https://reference.aspose.com/slides/sv/php-java/aspose.slides/sensitivitylabel/#setId) | Hämta eller ange identifieraren för känslighetsetiketten i Purview‑policyn. |
| [SensitivityLabel::getSiteId](https://reference.aspose.com/slides/sv/php-java/aspose.slides/sensitivitylabel/#getSiteId) och [SensitivityLabel::setSiteId](https://reference.aspose.com/slides/sv/php-java/aspose.slides/sensitivitylabel/#setSiteId) | Hämta eller ange webbplatsen som är associerad med etikettpolicyn. |
| [SensitivityLabel::isEnabled](https://reference.aspose.com/slides/sv/php-java/aspose.slides/sensitivitylabel/#isEnabled) och [SensitivityLabel::setEnabled](https://reference.aspose.com/slides/sv/php-java/aspose.slides/sensitivitylabel/#setEnabled) | Hämta eller ange om etiketten är aktiverad. |
| [SensitivityLabel::isRemoved](https://reference.aspose.com/slides/sv/php-java/aspose.slides/sensitivitylabel/#isRemoved) och [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/sv/php-java/aspose.slides/sensitivitylabel/#setRemoved) | Hämta eller ange om etiketten har tagits bort. Sätt värdet till `true` när borttagningsstatusen måste bevaras i metadata. |
| [SensitivityLabel::getAssignmentMethodType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) och [SensitivityLabel::setAssignmentMethodType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | Hämta eller ange om etiketten applicerades automatiskt eller genom ett användarbeslut. |
| [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/sv/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | Hämta de innehållsmarkeringstyper som är associerade med etiketten. |

Klassen [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/sensitivitylabelassignmenttype/) definierar hur en etikett tilldelades:

- [SensitivityLabelAssignmentType::Standard](https://reference.aspose.com/slides/sv/php-java/aspose.slides/sensitivitylabelassignmenttype/) representerar en standard‑ eller automatiskt applicerad etikett.
- [SensitivityLabelAssignmentType::Privileged](https://reference.aspose.com/slides/sv/php-java/aspose.slides/sensitivitylabelassignmenttype/) representerar en etikett som applicerats genom ett användarbeslut, inklusive manuellt applicerade, rekommenderade och obligatoriska etiketter.

Klassen [SensitivityLabelContentType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/sensitivitylabelcontenttype/) definierar markeringen som är associerad med en etikett:

| Värde | Betydelse |
| --- | --- |
| [SensitivityLabelContentType::None](https://reference.aspose.com/slides/sv/php-java/aspose.slides/sensitivitylabelcontenttype/) | Etiketten applicerades som standard eller automatiskt. |
| [SensitivityLabelContentType::Header](https://reference.aspose.com/slides/sv/php-java/aspose.slides/sensitivitylabelcontenttype/) | Rubrik‑innehållsmarkering är associerad med etiketten. |
| [SensitivityLabelContentType::Footer](https://reference.aspose.com/slides/sv/php-java/aspose.slides/sensitivitylabelcontenttype/) | Sidfot‑innehållsmarkering är associerad med etiketten. |
| [SensitivityLabelContentType::Watermark](https://reference.aspose.com/slides/sv/php-java/aspose.slides/sensitivitylabelcontenttype/) | Vattenstämpel‑innehållsmarkering är associerad med etiketten. |
| [SensitivityLabelContentType::Encryption](https://reference.aspose.com/slides/sv/php-java/aspose.slides/sensitivitylabelcontenttype/) | Krypteringsskydd är associerat med etiketten. |

Flera markeringstyper kan vara associerade med en etikett.

## **Lista befintliga känslighetsetiketter**

Läs den moderna etikettkollektionen från [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#getSensitivityLabels) och iterera den. Följande exempel listar varje egenskap och innehållsmarkering som lagras för varje etikett:

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

## **Lägg till en känslighetsetikett med innehållsmarkering**

Använd [SensitivityLabelCollection::add](https://reference.aspose.com/slides/sv/php-java/aspose.slides/sensitivitylabelcollection/#add) med etikettidentifieraren, webbplatsidentifieraren, aktiveringsstatusen och tilldelningsmetoden. Efter att metoden returnerat den nya [SensitivityLabel](https://reference.aspose.com/slides/sv/php-java/aspose.slides/sensitivitylabel/) lägger du till de erforderliga markeringvärdena via listan som returneras av [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/sv/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes).

Följande exempel lägger till en manuellt vald etikett som är associerad med sidfot‑ och vattenstämpelmarkeringar, och sparar sedan resultatet som PPTX:

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

## **Uppdatera en känslighetsetikett**

Värdena i [SensitivityLabel](https://reference.aspose.com/slides/sv/php-java/aspose.slides/sensitivitylabel/) är läs‑/skrivbara, med undantag för att listan som returneras av [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/sv/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) modifieras via dess listoperationer. Efter att ha lokaliserat den önskade etiketten kan du uppdatera dess identifierare, webbplatsidentifierare, aktiveringsstatus, tilldelningsmetod, borttagningsstatus samt innehållsmarkeringstyper. Spara presentationen för att bevara ändringarna.

Följande exempel uppdaterar aktiveringsstatusen och tilldelningsmetoden för den första etiketten:

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

## **Markera en känslighetsetikett som borttagen**

För att bevara att en etikett har tagits bort, hitta etiketten och anropa [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/sv/php-java/aspose.slides/sensitivitylabel/#setRemoved) med `true`. Detta behåller etikettposten samtidigt som dess borttagningsstatus registreras. Om du istället behöver ta bort en post från den moderna kollektionen, använd [SensitivityLabelCollection::removeAt](https://reference.aspose.com/slides/sv/php-java/aspose.slides/sensitivitylabelcollection/#removeAt); använd [SensitivityLabelCollection::clear](https://reference.aspose.com/slides/sv/php-java/aspose.slides/sensitivitylabelcollection/#clear) för att radera alla poster.

Följande exempel markerar en specifik etikett som borttagen och sparar den uppdaterade presentationen:

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

## **Läs och migrera äldre MIP‑känslighetsetiketter**

Äldre MIP‑baserade arbetsflöden kan lagra metadata för känslighetsetiketter i anpassade dokumentegenskaper istället för den moderna etikettkollektionen. Läs den metadata med [DocumentProperties::getSensitivityLabels](https://reference.aspose.com/slides/sv/php-java/aspose.slides/documentproperties/#getSensitivityLabels). Metoden analyserar de äldre anpassade egenskaperna och returnerar en Java‑array av [SensitivityLabel](https://reference.aspose.com/slides/sv/php-java/aspose.slides/sensitivitylabel/)‑objekt.

För att migrera metadata, lägg till varje returnerad etikett i den moderna [SensitivityLabelCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/sensitivitylabelcollection/) via [SensitivityLabelCollection::add](https://reference.aspose.com/slides/sv/php-java/aspose.slides/sensitivitylabelcollection/#add). Eftersom att lägga till en duplicerad etikettidentifierare utlöser ett undantag, kontrollerar exemplet målkollektionen innan varje etikett kopieras. Du kan lägga till ytterligare validering för att bekräfta att varje äldre etikett fortfarande finns i den aktuella Purview‑policyn.

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

Migreringen kopierar de analyserade etikettobjekten till den moderna kollektionen. Det krävs ingen rensning av alla anpassade dokumentegenskaper, så orelaterad dokumentmetadata förblir intakt. Använd [Presentation::save](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#save) med [SaveFormat::Pptx](https://reference.aspose.com/slides/sv/php-java/aspose.slides/saveformat/) för att skriva den moderna etikettmetadata till en PPTX‑fil.

## **FAQ**

**Skapar tillägg av en innehållsmarkeringstyp en synlig rubrik, sidfot eller vattenstämpel på bilderna?**

Nej. Värden som läggs till via listan som returneras av [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/sv/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) beskriver de markeringar som är associerade med känslighetsetiketten. De skapar inte synlig text eller former i presentationen. Lägg till motsvarande bildinnehåll separat om ditt arbetsflöde måste rendera dessa markeringar.

**Vad är skillnaden mellan att markera en etikett som borttagen och att radera den från kollektionen?**

Att anropa [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/sv/php-java/aspose.slides/sensitivitylabel/#setRemoved) med `true` behåller etikettposten och registrerar dess borttagningsstatus. Att anropa [SensitivityLabelCollection::removeAt](https://reference.aspose.com/slides/sv/php-java/aspose.slides/sensitivitylabelcollection/#removeAt) tar bort posten från den moderna kollektionen. Välj den operation som motsvarar din organisations krav på metadata‑bevarande.

**Kan en presentation innehålla både äldre MIP‑metadata och moderna känslighetsetiketter?**

Ja. Äldre etiketter kan finnas kvar i anpassade dokumentegenskaper medan moderna etiketter är tillgängliga via [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#getSensitivityLabels). Använd [DocumentProperties::getSensitivityLabels](https://reference.aspose.com/slides/sv/php-java/aspose.slides/documentproperties/#getSensitivityLabels) för att läsa den äldre metadata och migrera endast de giltiga etiketter som ännu inte finns i den moderna kollektionen.

**Vad händer när en etikett med samma identifierare läggs till fler än en gång?**

[SensitivityLabelCollection::add](https://reference.aspose.com/slides/sv/php-java/aspose.slides/sensitivitylabelcollection/#add) kastar ett undantag när kollektionen redan innehåller en etikett med samma identifierare. Kontrollera befintliga värden som returneras av [SensitivityLabel::getId](https://reference.aspose.com/slides/sv/php-java/aspose.slides/sensitivitylabel/#getId) innan du lägger till eller migrerar etiketter.

**Vilket utskriftsformat bör användas för att bevara uppdaterade känslighetsetiketter?**

Spara presentationen som PPTX genom att anropa [Presentation::save](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#save) med [SaveFormat::Pptx](https://reference.aspose.com/slides/sv/php-java/aspose.slides/saveformat/), enligt exemplen ovan.