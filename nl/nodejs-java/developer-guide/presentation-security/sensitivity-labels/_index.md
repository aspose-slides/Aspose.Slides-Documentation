---
title: Beheer gevoeligheidslabels in PowerPoint-presentaties in JavaScript
linktitle: Gevoeligheidslabels
type: docs
weight: 50
url: /nl/nodejs-java/sensitivity-labels/
keywords:
- gevoeligheidslabel
- Microsoft Purview
- Microsoft Information Protection
- MIP-metadata
- inhoudsaanduiding
- informatiebeveiliging
- documentbeheer
- PowerPoint
- PPTX
- presentatiebeveiliging
- Node.js
- JavaScript
- Aspose.Slides
description: "Lees, voeg toe, werk bij, verwijder en migreer Microsoft Purview-gevoeligheidslabels in PowerPoint-PPTX-presentaties met Aspose.Slides voor Node.js via Java."
---
## **Overzicht**

Microsoft Purview-gevoeligheidslabels helpen organisaties bij het classificeren en beheren van documenten. Tijdens geautomatiseerde verwerking van presentaties kan een toepassing een bestaand label moeten behouden, een label toepassen dat door een beleid is geselecteerd, de status bijwerken, of label‑metadata migreren die door een oudere Microsoft Information Protection (MIP)-workflow is geschreven.

Aspose.Slides for Node.js via Java maakt moderne metadata van gevoeligheidslabels beschikbaar via [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#getSensitivityLabels). Deze methode retourneert een [SensitivityLabelCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sensitivitylabelcollection/) die kan worden geïnspecteerd en aangepast voordat de presentatie wordt opgeslagen als PPTX.

{{% alert color="primary" title="Note" %}}
Gevoeligheidslabel‑identifiers en beleidsinformatie worden gedefinieerd door uw Microsoft Purview‑configuratie. Controleer de beschikbaarheid van labels en de beleidsvereisten in uw omgeving voordat u metadata toevoegt of migreert. De waarden van [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) beschrijven de inhoudsaanduidingen die bij een label horen; ze voegen op zich geen zichtbare tekst of vormen toe aan dia's.
{{% /alert %}}

## **Begrijp de eigenschappen van gevoeligheidslabels**

Elke [SensitivityLabel](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sensitivitylabel/) bevat de volgende metadata:

| Methoden | Doel |
| --- | --- |
| [SensitivityLabel.getId](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sensitivitylabel/#getId) en [SensitivityLabel.setId](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sensitivitylabel/#setId) | Haal de gevoeligheidslabel‑identifier op of stel deze in het Purview‑beleid in. |
| [SensitivityLabel.getSiteId](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sensitivitylabel/#getSiteId) en [SensitivityLabel.setSiteId](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sensitivitylabel/#setSiteId) | Haal de site op die aan het labelbeleid is gekoppeld of stel deze in. |
| [SensitivityLabel.isEnabled](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sensitivitylabel/#isEnabled) en [SensitivityLabel.setEnabled](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sensitivitylabel/#setEnabled) | Haal op of stel in of het label is ingeschakeld. |
| [SensitivityLabel.isRemoved](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sensitivitylabel/#isRemoved) en [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) | Haal op of stel in of het label verwijderd is. Stel de waarde in op `true` wanneer de verwijderingsstatus in de metadata moet worden behouden. |
| [SensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) en [SensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | Haal op of stel in of het label automatisch is toegepast of via een gebruikersbeslissing. |
| [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | Haal de inhoudsaanduidingstypen op die aan het label zijn gekoppeld. |

De klasse [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) definieert hoe een label is toegewezen:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) vertegenwoordigt een standaard of automatisch toegepast label.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sensitivitylabelassignmenttype/) vertegenwoordigt een label dat via een gebruikersbeslissing is toegepast, inclusief handmatig toegepaste, aanbevolen en verplichte labels.

De klasse [SensitivityLabelContentType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) definieert de aanduiding die aan een label is gekoppeld:

| Waarde | Betekenis |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | Het label is standaard of automatisch toegepast. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | Koptekstinhoudsaanduiding is gekoppeld aan het label. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | Voettekstinhoudsaanduiding is gekoppeld aan het label. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | Watermerkinhoudsaanduiding is gekoppeld aan het label. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sensitivitylabelcontenttype/) | Encryptiebescherming is gekoppeld aan het label. |

Meerdere aanduidingstypen kunnen aan één label worden gekoppeld.

## **Lijst bestaande gevoeligheidslabels**

Lees de moderne labelcollectie via [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#getSensitivityLabels) en doorloop deze. Het volgende voorbeeld geeft elke eigenschap en inhoudsaanduiding weer die voor elk label is opgeslagen:

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

## **Voeg een gevoeligheidslabel toe met inhoudsaanduiding**

Gebruik [SensitivityLabelCollection.add](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sensitivitylabelcollection/#add) met de label‑identifier, site‑identifier, ingeschakelde status en toewijzingsmethode. Nadat de methode het nieuwe [SensitivityLabel](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sensitivitylabel/) heeft geretourneerd, voeg je de vereiste aanduidingswaarden toe via de lijst die wordt geretourneerd door [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes).

Het volgende voorbeeld voegt een handmatig geselecteerd label toe dat is gekoppeld aan voettekst‑ en watermerkaanduidingen, en slaat vervolgens het resultaat op als PPTX:

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

## **Werk een gevoeligheidslabel bij**

De waarden van [SensitivityLabel] zijn lees‑/schrijfbaar, behalve dat de lijst die wordt geretourneerd door [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) wordt aangepast via de lijstbewerkingen. Nadat je het benodigde label hebt gevonden, kun je de identifier, site‑identifier, ingeschakelde status, toewijzingsmethode, verwijderingsstatus en inhoudsaanduidingstypen bijwerken. Sla de presentatie op om de wijzigingen te behouden.

Het volgende voorbeeld werkt de ingeschakelde status en de toewijzingsmethode van het eerste label bij:

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

## **Markeer een gevoeligheidslabel als verwijderd**

Om het feit te behouden dat een label verwijderd is, zoek je het label en roep je [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) aan met `true`. Hiermee blijft het label behouden terwijl de verwijderingsstatus wordt vastgelegd. Als je in plaats daarvan een item uit de moderne collectie wilt verwijderen, gebruik dan [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sensitivitylabelcollection/#removeAt); gebruik [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sensitivitylabelcollection/#clear) om alle items te verwijderen.

Het volgende voorbeeld markeert een specifiek label als verwijderd en slaat de bijgewerkte presentatie op:

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

## **Lees en migreer legacy MIP-gevoeligheidslabels**

Oudere MIP‑gebaseerde workflows kunnen metadata van gevoeligheidslabels opslaan in aangepaste documenteigenschappen in plaats van in de moderne labelcollectie. Lees die metadata met [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/documentproperties/#getSensitivityLabels). De methode parseert de legacy‑aangepaste eigenschappen en retourneert een array van [SensitivityLabel]-objecten.

Om de metadata te migreren, voeg je elk geretourneerd label toe aan de moderne [SensitivityLabelCollection] via [SensitivityLabelCollection.add](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sensitivitylabelcollection/#add). Omdat het toevoegen van een dubbele label‑identifier een uitzondering oplevert, controleert het voorbeeld de doelcollectie voordat elk label wordt gekopieerd. Je kunt extra validatie toevoegen om te bevestigen dat elk legacy‑label nog steeds bestaat in het huidige Purview‑beleid.

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

De migratie kopieert de geparseerde labelobjecten naar de moderne collectie. Het is niet nodig om alle aangepaste documenteigenschappen te wissen, zodat metadata die niet gerelateerd is aan het label intact blijven. Gebruik [Presentation.save](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#save) met [SaveFormat.Pptx](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/saveformat/) om de moderne labelmetadata naar een PPTX‑bestand te schrijven.

## **FAQ**

**Voegt het toevoegen van een inhoudsaanduidingstype een zichtbare koptekst, voettekst of watermerk toe aan dia's?**

Nee. De waarden die via de lijst worden toegevoegd die wordt geretourneerd door [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) beschrijven de aanduidingen die bij het gevoeligheidslabel horen. Ze creëren geen zichtbare tekst of vormen in de presentatie. Voeg de overeenkomstige dia-inhoud apart toe als uw workflow die aanduidingen moet weergeven.

**Wat is het verschil tussen een label markeren als verwijderd en het verwijderen uit de collectie?**

Door [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sensitivitylabel/#setRemoved) aan te roepen met `true` blijft het label behouden en wordt de verwijderingsstatus geregistreerd. Door [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sensitivitylabelcollection/#removeAt) aan te roepen wordt het item uit de moderne collectie verwijderd. Kies de bewerking die overeenkomt met de metadata‑bewaarvereisten van uw organisatie.

**Kan een presentatie zowel legacy MIP‑metadata als moderne gevoeligheidslabels bevatten?**

Ja. Legacy‑labels kunnen blijven bestaan in aangepaste documenteigenschappen, terwijl moderne labels beschikbaar zijn via [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#getSensitivityLabels). Gebruik [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/documentproperties/#getSensitivityLabels) om de legacy‑metadata te lezen en migreer alleen de geldige labels die nog niet aanwezig zijn in de moderne collectie.

**Wat gebeurt er als een label met dezelfde identifier meer dan één keer wordt toegevoegd?**

[SensitivityLabelCollection.add](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sensitivitylabelcollection/#add) veroorzaakt een uitzondering wanneer de collectie al een label met dezelfde identifier bevat. Controleer de bestaande waarden die worden geretourneerd door [SensitivityLabel.getId](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sensitivitylabel/#getId) voordat u labels toevoegt of migreert.

**Welk uitvoerformaat moet worden gebruikt om bijgewerkte gevoeligheidslabels te behouden?**

Sla de presentatie op als PPTX door [Presentation.save](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#save) aan te roepen met [SaveFormat.Pptx](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/saveformat/), zoals getoond in de bovenstaande voorbeelden.