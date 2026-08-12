---
title: Hantera känslighetsetiketter i PowerPoint-presentationer i JavaScript
linktitle: Känslighetsetiketter
type: docs
weight: 50
url: /sv/nodejs-java/sensitivity-labels/
keywords:
- känslighetsetikett
- Microsoft Purview
- Microsoft Information Protection
- MIP-metadata
- innehållsmärkning
- informationsskydd
- dokumentstyrning
- PowerPoint
- PPTX
- presentationssäkerhet
- Node.js
- JavaScript
- Aspose.Slides
description: "Läs, lägg till, uppdatera, ta bort och migrera Microsoft Purview-känslighetsetiketter i PowerPoint PPTX-presentationer med Aspose.Slides för Node.js via Java."
---
## **Översikt**

Microsoft Purview‑säkerhetsklassificeringsetiketter hjälper organisationer att klassificera och styra dokument. Vid automatiserad bearbetning av presentationer kan en applikation behöva bevara en befintlig etikett, tillämpa en etikett som valts av en policy, uppdatera dess tillstånd eller migrera etikettmetadata som skrivits av ett äldre Microsoft Information Protection (MIP)‑arbetsflöde.

Aspose.Slides for Node.js via Java exponerar modern metadata för känslighetsetiketter via [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#getSensitivityLabels). Denna metod returnerar en [SensitivityLabelCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sensitivitylabelcollection/) som kan inspekteras och modifieras innan presentationen sparas som PPTX.

{{% alert color="primary" title="Note" %}}
Sensitivity label‑identifierare och policyinformation definieras av din Microsoft Purview‑konfiguration. Validera etikettens tillgänglighet och policykrav i din miljö innan du lägger till eller migrerar metadata. Värdena från [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) beskriver innehållsmärkningarna som är associerade med en etikett; de lägger inte själva till synlig text eller former i bilderna.
{{% /alert %}}

## **Förstå egenskaper för känslighetsetiketter**

Varje [SensitivityLabel](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sensitivitylabel/) innehåller följande metadata:

| Metoder | Syfte |
| --- | --- |
| [SensitivityLabel.getId](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sensitivitylabel/#getId) och [SensitivityLabel.setId](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sensitivitylabel/#setId) | Hämta eller ange identifieraren för känslighetsetiketten i Purview‑policyn. |
| [SensitivityLabel.getSiteId](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sensitivitylabel/#getSiteId) och [SensitivityLabel.setSiteId](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sensitivitylabel/#setSiteId) | Hämta eller ange webbplatsen som är kopplad till etikettpolicyn. |
| [SensitivityLabel.isEnabled](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sensitivitylabel/#isEnabled) och [SensitivityLabel.setEnabled](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sensitivitylabel/#setEnabled) | Hämta eller ange om etiketten är aktiverad. |
| [SensitivityLabel.isRemoved](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sensitivitylabel/#isRemoved) och [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) | Hämta eller ange om etiketten har tagits bort. Sätt värdet till `true` när borttagningsstatusen måste bevaras i metadata. |
| [SensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) och [SensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | Hämta eller ange om etiketten tillämpades automatiskt eller genom ett användarbeslut. |
| [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | Hämta de innehållsmärknings typerna som är associerade med etiketten. |

Klassen [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) definierar hur en etikett tilldelades:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) representerar en standard‑ eller automatiskt tillämpad etikett.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) representerar en etikett som tillämpats genom ett användarbeslut, inklusive manuellt tillämpade, rekommenderade och obligatoriska etiketter.

Klassen [SensitivityLabelContentType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) definierar märkningen som är kopplad till en etikett:

| Värde | Betydelse |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | Etiketten tillämpades som standard eller automatiskt. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | Header‑innehållsmärkning är associerad med etiketten. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | Footer‑innehållsmärkning är associerad med etiketten. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | Watermark‑innehållsmärkning är associerad med etiketten. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | Encryption‑skydd är associerat med etiketten. |

Flera märkningstyper kan vara associerade med en etikett.

## **Lista befintliga känslighetsetiketter**

Läs den moderna etikettkollektionen från [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#getSensitivityLabels) och iterera över den. Följande exempel listar varje egenskap och innehållsmärkning som lagrats för varje etikett:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();
    const labelCount = sensitivityLabels.getCount();

    for (let labelIndex = 0; labelIndex < labelCount; labelIndex++) {
        const sensitivityLabel = sensitivityLabels.get_Item(labelIndex);
        const labelIdentifier = sensitivityLabel.getId();
        const siteIdentifier = sensitivityLabel.getSiteId();
        const isEnabled = sensitivityLabel.isEnabled();
        const isRemoved = sensitivityLabel.isRemoved();
        const assignmentMethod = sensitivityLabel.getAssignmentMethodType();

        console.log("Label ID: " + labelIdentifier);
        console.log("Site ID: " + siteIdentifier);
        console.log("Enabled: " + isEnabled);
        console.log("Removed: " + isRemoved);
        console.log("Assignment method: " + assignmentMethod);

        const contentMarkTypes = sensitivityLabel.getContentMarkTypes();
        const contentMarkCount = contentMarkTypes.size();

        for (let contentMarkIndex = 0; contentMarkIndex < contentMarkCount; contentMarkIndex++) {
            const contentMarkType = contentMarkTypes.get_Item(contentMarkIndex);
            console.log("Content marking: " + contentMarkType);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Lägg till en känslighetsetikett med innehållsmärkning**

Använd [SensitivityLabelCollection.add](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sensitivitylabelcollection/#add) med etikettens identifierare, webbplatsens identifierare, aktiveringsstatus och tilldelningsmetod. Efter att metoden returnerat den nya [SensitivityLabel](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sensitivitylabel/), lägg du till de erforderliga märkningvärdena via listan som returneras av [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes).

Följande exempel lägger till en manuellt vald etikett som är associerad med sidfot‑ och vattenstämpelmärkningar, och sparar sedan resultatet som PPTX:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();

    const labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    const siteIdentifier = java.callStaticMethodSync(
        "java.util.UUID",
        "fromString",
        "aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee");
    const isEnabled = true;
    const assignmentMethod = aspose.slides.SensitivityLabelAssignmentType.Privileged;

    const sensitivityLabel = sensitivityLabels.add(
        labelIdentifier,
        siteIdentifier,
        isEnabled,
        assignmentMethod);

    const contentMarkTypes = sensitivityLabel.getContentMarkTypes();
    contentMarkTypes.addItem(aspose.slides.SensitivityLabelContentType.Footer);
    contentMarkTypes.addItem(aspose.slides.SensitivityLabelContentType.Watermark);

    presentation.save("presentation_with_label.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Uppdatera en känslighetsetikett**

Värdena i [SensitivityLabel](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sensitivitylabel/) är läs‑ och skrivbara, förutom att listan som returneras av [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) modifieras via dess listoperationer. Efter att ha hittat den önskade etiketten kan du uppdatera dess identifierare, webbplatsidentifierare, aktiveringsstatus, tilldelningsmetod, borttagningsstatus och innehållsmärknings typer. Spara presentationen för att bevara förändringarna.

Följande exempel uppdaterar aktiveringsstatusen och tilldelningsmetoden för den första etiketten:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();
    const labelCount = sensitivityLabels.getCount();

    if (labelCount > 0) {
        const sensitivityLabel = sensitivityLabels.get_Item(0);
        sensitivityLabel.setEnabled(true);
        sensitivityLabel.setAssignmentMethodType(
            aspose.slides.SensitivityLabelAssignmentType.Privileged);
    }

    presentation.save("presentation_with_updated_label.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Markera en känslighetsetikett som borttagen**

För att bevara att en etikett har tagits bort, hitta etiketten och anropa [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) med `true`. Detta behåller etikettposten samtidigt som dess borttagningsstatus registreras. Om du i stället behöver radera en post från den moderna kollektionen, använd [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sensitivitylabelcollection/#removeAt); använd [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sensitivitylabelcollection/#clear) för att radera alla poster.

Följande exempel markerar en specifik etikett som borttagen och sparar den uppdaterade presentationen:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const sensitivityLabels = presentation.getSensitivityLabels();
    const targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    const labelCount = sensitivityLabels.getCount();

    for (let labelIndex = 0; labelIndex < labelCount; labelIndex++) {
        const sensitivityLabel = sensitivityLabels.get_Item(labelIndex);
        const labelIdentifier = sensitivityLabel.getId();
        const isTargetLabel = labelIdentifier.toLowerCase() === targetLabelIdentifier.toLowerCase();

        if (isTargetLabel) {
            sensitivityLabel.setRemoved(true);
            break;
        }
    }

    presentation.save("presentation_with_removed_label.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Läs och migrera äldre MIP‑känslighetsetiketter**

Äldre MIP‑baserade arbetsflöden kan lagra metadata för känslighetsetiketter i anpassade dokumentegenskaper i stället för den moderna etikettkollektionen. Läs den metadata med [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/documentproperties/#getSensitivityLabels). Metoden analyserar de äldre anpassade egenskaperna och returnerar en array av [SensitivityLabel](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sensitivitylabel/)‑objekt.

För att migrera metadata, lägg till varje returnerad etikett i den moderna [SensitivityLabelCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sensitivitylabelcollection/) via [SensitivityLabelCollection.add](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sensitivitylabelcollection/#add). Eftersom att lägga till en duplicerad etikettidentifierare kastar ett undantag, kontrollerar exemplet destinationens kollektion innan varje etikett kopieras. Du kan lägga till ytterligare validering för att bekräfta att varje äldre etikett fortfarande finns i den aktuella Purview‑policyn.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation_with_legacy_labels.pptx");
try {
    const legacySensitivityLabels = presentation.getDocumentProperties().getSensitivityLabels();
    const modernSensitivityLabels = presentation.getSensitivityLabels();

    for (let legacyLabelIndex = 0; legacyLabelIndex < legacySensitivityLabels.length; legacyLabelIndex++) {
        const legacySensitivityLabel = legacySensitivityLabels[legacyLabelIndex];
        const legacyLabelIdentifier = legacySensitivityLabel.getId();
        const modernLabelCount = modernSensitivityLabels.getCount();
        let labelAlreadyExists = false;

        for (let modernLabelIndex = 0; modernLabelIndex < modernLabelCount; modernLabelIndex++) {
            const modernSensitivityLabel = modernSensitivityLabels.get_Item(modernLabelIndex);
            const modernLabelIdentifier = modernSensitivityLabel.getId();

            labelAlreadyExists =
                modernLabelIdentifier.toLowerCase() === legacyLabelIdentifier.toLowerCase();

            if (labelAlreadyExists) {
                break;
            }
        }

        if (!labelAlreadyExists) {
            modernSensitivityLabels.add(legacySensitivityLabel);
        }
    }

    presentation.save("presentation_with_modern_labels.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Migreringen kopierar de analyserade etikettobjekten till den moderna kollektionen. Det krävs inte att alla anpassade dokumentegenskaper rensas, så orelaterad dokumentmetadata förblir intakt. Använd [Presentation.save](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#save) med [SaveFormat.Pptx](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/saveformat/) för att skriva den moderna etikettmetadata till en PPTX‑fil.

## **FAQ**

**Skapar tillägg av en innehållsmärkningstyp ett synligt sidhuvud, sidfot eller vattenstämpel på bildspel?**

Nej. Värden som läggs till via listan som returneras av [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) beskriver märkningarna som är associerade med känslighetsetiketten. De skapar inte synlig text eller former i presentationen. Lägg till motsvarande bildinnehåll separat om ditt arbetsflöde måste rendera dessa märkningar.

**Vad är skillnaden mellan att markera en etikett som borttagen och att ta bort den från kollektionen?**

Att anropa [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) med `true` behåller etikettposten och registrerar dess borttagningsstatus. Att anropa [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sensitivitylabelcollection/#removeAt) tar bort posten från den moderna kollektionen. Välj den operation som motsvarar din organisations krav på metadataretention.

**Kan en presentation innehålla både äldre MIP‑metadata och moderna känslighetsetiketter?**

Ja. Äldre etiketter kan finnas kvar i anpassade dokumentegenskaper medan moderna etiketter är tillgängliga via [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#getSensitivityLabels). Använd [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/documentproperties/#getSensitivityLabels) för att läsa den äldre metadata och migrera endast de giltiga etiketter som ännu inte finns i den moderna kollektionen.

**Vad händer när en etikett med samma identifierare läggs till mer än en gång?**

[SensitivityLabelCollection.add](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sensitivitylabelcollection/#add) kastar ett undantag när kollektionen redan innehåller en etikett med samma identifierare. Kontrollera befintliga värden som returneras av [SensitivityLabel.getId](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sensitivitylabel/#getId) innan du lägger till eller migrerar etiketter.

**Vilket utdataformat bör användas för att bevara uppdaterade känslighetsetiketter?**

Spara presentationen som PPTX genom att anropa [Presentation.save](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#save) med [SaveFormat.Pptx](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/saveformat/), som visas i exemplen ovan.