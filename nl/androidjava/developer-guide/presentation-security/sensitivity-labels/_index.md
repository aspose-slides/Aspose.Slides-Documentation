---
title: Beheer gevoeligheidslabels in PowerPoint-presentaties op Android
linktitle: Gevoeligheidslabels
type: docs
weight: 50
url: /nl/androidjava/sensitivity-labels/
keywords:
- gevoeligheidslabel
- Microsoft Purview
- Microsoft Information Protection
- MIP-metadata
- inhoudsmarkering
- informatiebeveiliging
- documentbeheer
- PowerPoint
- PPTX
- presentatiebeveiliging
- Android
- Java
- Aspose.Slides
description: "Lees, voeg toe, werk bij, verwijder en migreer Microsoft Purview-gevoeligheidslabels in PowerPoint PPTX-presentaties met Aspose.Slides voor Android via Java."
---
## **Overzicht**

Microsoft Purview-gevoeligheidslabels helpen organisaties documenten te classificeren en te beheren. Tijdens geautomatiseerde verwerking van presentaties kan een applicatie een bestaand label moeten behouden, een door een beleid geselecteerd label toepassen, de status bijwerken, of labelmetadata migreren die door een oudere Microsoft Information Protection (MIP)-workflow is geschreven.

Aspose.Slides for Android via Java maakt moderne metadata van gevoeligheidslabels beschikbaar via [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--). Deze methode retourneert een [ISensitivityLabelCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isensitivitylabelcollection/) die kan worden geïnspecteerd en aangepast voordat de presentatie wordt opgeslagen als PPTX.

{{% alert color="primary" title="Opmerking" %}}

Identificatoren van gevoeligheidslabels en beleidsinformatie worden gedefinieerd door uw Microsoft Purview‑configuratie. Controleer de beschikbaarheid van labels en de beleidsvereisten in uw omgeving voordat u metadata toevoegt of migreert. De waarden van [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) beschrijven de inhoudsmarkeringen die aan een label zijn gekoppeld; ze voegen op zichzelf geen zichtbare tekst of vormen toe aan dia’s.

{{% /alert %}}

## **Begrijp de eigenschappen van gevoeligheidslabels**

Elke [ISensitivityLabel](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isensitivitylabel/) bevat de volgende metadata:

| Methoden | Doel |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isensitivitylabel/#getId--) en [ISensitivityLabel.setId](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isensitivitylabel/#setId-java.lang.String-) | Haal de identificatie van het gevoeligheidslabel op of stel deze in de Purview-beleid in. |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isensitivitylabel/#getSiteId--) en [ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isensitivitylabel/#setSiteId-java.util.UUID-) | Haal de site op die aan het labelbeleid is gekoppeld of stel deze in. |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isensitivitylabel/#isEnabled--) en [ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isensitivitylabel/#setEnabled-boolean-) | Haal op of stel in of het label ingeschakeld is. |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isensitivitylabel/#isRemoved--) en [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) | Haal op of stel in of het label is verwijderd. Stel de waarde in op `true` wanneer de verwijderde status moet worden bewaard in de metadata. |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isensitivitylabel/#getAssignmentMethodType--) en [ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isensitivitylabel/#setAssignmentMethodType-int-) | Haal op of stel in of het label automatisch of via een gebruikersbeslissing is toegepast. |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) | Haal de inhoudsmarkeringstypen op die aan het label zijn gekoppeld. |

De klasse [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) definieert hoe een label is toegewezen:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) vertegenwoordigt een standaard of automatisch toegepast label.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) vertegenwoordigt een label dat via een gebruikersbeslissing is toegepast, inclusief handmatig toegepaste, aanbevolen en verplichte labels.

De klasse [SensitivityLabelContentType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) definieert de markering die aan een label is gekoppeld:

| Waarde | Betekenis |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Het label is standaard of automatisch toegepast. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Koptekstinhoudmarkering is gekoppeld aan het label. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Voettekstinhoudmarkering is gekoppeld aan het label. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Watermerkinhoudmarkering is gekoppeld aan het label. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Versleutelingsbescherming is gekoppeld aan het label. |

Meerdere markeringstypen kunnen aan één label worden gekoppeld.

## **Bestaande gevoeligheidslabels weergeven**

Lees de moderne labelverzameling via [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--) en doorloop deze. Het volgende voorbeeld somt elke eigenschap en inhoudsmarkering op die voor elk label is opgeslagen:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();

    for (ISensitivityLabel sensitivityLabel : sensitivityLabels) {
        System.out.println("Label ID: " + sensitivityLabel.getId());
        System.out.println("Site ID: " + sensitivityLabel.getSiteId());
        System.out.println("Enabled: " + sensitivityLabel.isEnabled());
        System.out.println("Removed: " + sensitivityLabel.isRemoved());
        System.out.println("Assignment method: " + sensitivityLabel.getAssignmentMethodType());

        for (Integer contentMarkType : sensitivityLabel.getContentMarkTypes()) {
            System.out.println("Content marking: " + contentMarkType);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Een gevoeligheidslabel toevoegen met inhoudsmarkering**

Gebruik [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) met het label‑identificatie, site‑identificatie, ingeschakelde status en toewijzingsmethode. Nadat de methode het nieuwe [ISensitivityLabel](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isensitivitylabel/) heeft geretourneerd, voeg je de vereiste markeringstypen toe via de lijst die wordt geretourneerd door [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--).

Het volgende voorbeeld voegt een handmatig geselecteerd label toe dat is gekoppeld aan voettekst‑ en watermerkmarkeringen, en slaat het resultaat vervolgens op als PPTX:

```java
import com.aspose.slides.*;
import java.util.UUID;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();

    String labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    UUID siteIdentifier = UUID.fromString("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee");
    boolean isEnabled = true;
    int assignmentMethod = SensitivityLabelAssignmentType.Privileged;

    ISensitivityLabel sensitivityLabel = sensitivityLabels.add(
            labelIdentifier,
            siteIdentifier,
            isEnabled,
            assignmentMethod);

    sensitivityLabel.getContentMarkTypes().addItem(SensitivityLabelContentType.Footer);
    sensitivityLabel.getContentMarkTypes().addItem(SensitivityLabelContentType.Watermark);

    presentation.save("presentation_with_label.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Een gevoeligheidslabel bijwerken**

De waarden van [ISensitivityLabel](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isensitivitylabel/) zijn lees‑ en schrijfbaar, behalve dat de lijst die wordt geretourneerd door [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) wordt aangepast via de lijstbewerkingen. Nadat je het gewenste label hebt gevonden, kun je de identificatie, site‑identificatie, ingeschakelde status, toewijzingsmethode, verwijderstatus en inhoudsmarkeringstypen bijwerken. Sla de presentatie op om de wijzigingen te bewaren.

Het volgende voorbeeld werkt de ingeschakelde status en toewijzingsmethode van het eerste label bij:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();

    if (sensitivityLabels.getCount() > 0) {
        ISensitivityLabel sensitivityLabel = sensitivityLabels.get_Item(0);
        sensitivityLabel.setEnabled(true);
        sensitivityLabel.setAssignmentMethodType(SensitivityLabelAssignmentType.Privileged);
    }

    presentation.save("presentation_with_updated_label.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Een gevoeligheidslabel markeren als verwijderd**

Om te behouden dat een label is verwijderd, zoek je het label en roep je [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) aan met `true`. Hiermee blijft de labelvermelding bestaan terwijl de verwijderstatus wordt geregistreerd. Als je in plaats daarvan een vermelding uit de moderne verzameling wilt verwijderen, gebruik dan [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-); gebruik [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isensitivitylabelcollection/#clear--) om elke vermelding te verwijderen.

Het volgende voorbeeld markeert een specifiek label als verwijderd en slaat de bijgewerkte presentatie op:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();
    String targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";

    for (ISensitivityLabel sensitivityLabel : sensitivityLabels) {
        boolean isTargetLabel = sensitivityLabel.getId().equalsIgnoreCase(targetLabelIdentifier);

        if (isTargetLabel) {
            sensitivityLabel.setRemoved(true);
            break;
        }
    }

    presentation.save("presentation_with_removed_label.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Legacy MIP-gevoeligheidslabels lezen en migreren**

Oudere MIP‑gebaseerde workflows kunnen gevoeligheidslabelmetadata opslaan in aangepaste documenteigenschappen in plaats van in de moderne labelverzameling. Lees die metadata met [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idocumentproperties/#getSensitivityLabels--). De methode parseert de legacy‑aangepaste eigenschappen en retourneert een array van [ISensitivityLabel](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isensitivitylabel/)‑objecten.

Om de metadata te migreren, voeg je elk geretourneerd label toe aan de moderne [ISensitivityLabelCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isensitivitylabelcollection/) via [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-). Omdat het toevoegen van een dubbel label‑identificatie een uitzondering veroorzaakt, controleert het voorbeeld de bestemmingsverzameling voordat elk label wordt gekopieerd. Je kunt extra validatie toevoegen om te bevestigen dat elk legacy‑label nog steeds bestaat in het huidige Purview‑beleid.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation_with_legacy_labels.pptx");
try {
    ISensitivityLabel[] legacySensitivityLabels = presentation.getDocumentProperties().getSensitivityLabels();
    ISensitivityLabelCollection modernSensitivityLabels = presentation.getSensitivityLabels();

    for (ISensitivityLabel legacySensitivityLabel : legacySensitivityLabels) {
        boolean labelAlreadyExists = false;

        for (ISensitivityLabel modernSensitivityLabel : modernSensitivityLabels) {
            labelAlreadyExists = modernSensitivityLabel.getId().equalsIgnoreCase(
                    legacySensitivityLabel.getId());

            if (labelAlreadyExists) {
                break;
            }
        }

        if (!labelAlreadyExists) {
            modernSensitivityLabels.add(legacySensitivityLabel);
        }
    }

    presentation.save("presentation_with_modern_labels.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De migratie kopieert de geparseerde labelobjecten naar de moderne verzameling. Het vereist geen opschoning van alle aangepaste documenteigenschappen, zodat niet‑gerelateerde documentmetadata intact blijft. Gebruik [IPresentation.save](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) met [SaveFormat.Pptx](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/saveformat/) om de moderne labelmetadata naar een PPTX‑bestand te schrijven.

## **Veelgestelde vragen**

**Maakt het toevoegen van een inhoudsmarkeringstype een zichtbare kop, voettekst of watermerk op dia's?**

Nee. De waarden die via de lijst worden toegevoegd die door [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) wordt geretourneerd, beschrijven de markeringen die aan het gevoeligheidslabel zijn gekoppeld. Ze creëren geen zichtbare tekst of vormen in de presentatie. Voeg de overeenkomstige dia‑inhoud apart toe als uw workflow die markeringen moet weergeven.

**Wat is het verschil tussen een label markeren als verwijderd en het verwijderen uit de verzameling?**

Het aanroepen van [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) met `true` behoudt de labelvermelding en registreert de verwijderde status. Het aanroepen van [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) verwijdert de vermelding uit de moderne verzameling. Kies de handeling die past bij de retentie‑eisen van uw organisatie.

**Kan een presentatie zowel legacy MIP‑metadata als moderne gevoeligheidslabels bevatten?**

Ja. Legacy‑labels kunnen blijven staan in aangepaste documenteigenschappen, terwijl moderne labels beschikbaar zijn via [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--). Gebruik [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) om de legacy‑metadata te lezen en migreer alleen de geldige labels die nog niet aanwezig zijn in de moderne verzameling.

**Wat gebeurt er als een label met dezelfde identificatie meer dan één keer wordt toegevoegd?**

[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) veroorzaakt een uitzondering wanneer de collectie al een label met dezelfde identificatie bevat. Controleer de bestaande waarden die worden geretourneerd door [ISensitivityLabel.getId](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isensitivitylabel/#getId--) voordat u labels toevoegt of migreert.

**Welk uitvoerformaat moet worden gebruikt om bijgewerkte gevoeligheidslabels te behouden?**

Sla de presentatie op als PPTX door [IPresentation.save](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) aan te roepen met [SaveFormat.Pptx](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/saveformat/), zoals getoond in de voorbeelden hierboven.