---
title: Beheer van gevoeligheidslabels in PowerPoint presentaties op Android
linktitle: Gevoeligheidslabels
type: docs
weight: 50
url: /nl/androidjava/sensitivity-labels/
keywords:
- gevoeligheidslabel
- Microsoft Purview
- Microsoft Information Protection
- MIP-metadata
- contentmarkering
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

Microsoft Purview‑gevoelige labels helpen organisaties documenten te classificeren en te beheren. Tijdens geautomatiseerde presentatieverwerking kan een applicatie een bestaande label behouden, een label toepassen dat door een beleid is geselecteerd, de status bijwerken, of label‑metadata migreren die is geschreven door een oudere Microsoft Information Protection (MIP) workflow.

Aspose.Slides for Android via Java exposeert moderne metadata van gevoeligheidslabels via [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--). Deze methode retourneert een [ISensitivityLabelCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isensitivitylabelcollection/) die kan worden geïnspecteerd en aangepast voordat de presentatie wordt opgeslagen als PPTX.

{{% alert color="info" title="Opmerking" %}}
Identificatoren van gevoeligheidslabels en beleidsinformatie worden gedefinieerd door uw Microsoft Purview‑configuratie. Valideer de beschikbaarheid van labels en de beleidsvereisten in uw omgeving voordat u metadata toevoegt of migreert. De waarden van [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) beschrijven de content‑markeringen die aan een label zijn gekoppeld; ze voegen niet zelf zichtbaar tekst of vormen toe aan dia's.
{{% /alert %}}

## **Begrijpen van eigenschappen van gevoeligheidslabels**

Elke [ISensitivityLabel](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isensitivitylabel/) bevat de volgende metadata:

| Methoden | Doel |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isensitivitylabel/#getId--) en [ISensitivityLabel.setId](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isensitivitylabel/#setId-java.lang.String-) | Ophalen of instellen van de identificatie van het gevoeligheidslabel in het Purview‑beleid. |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isensitivitylabel/#getSiteId--) en [ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isensitivitylabel/#setSiteId-java.util.UUID-) | Ophalen of instellen van de site die aan het label‑beleid is gekoppeld. |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isensitivitylabel/#isEnabled--) en [ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isensitivitylabel/#setEnabled-boolean-) | Ophalen of instellen of het label is ingeschakeld. |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isensitivitylabel/#isRemoved--) en [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) | Ophalen of instellen of het label is verwijderd. Stel de waarde in op `true` wanneer de verwijderingsstatus in de metadata moet worden bewaard. |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isensitivitylabel/#getAssignmentMethodType--) en [ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isensitivitylabel/#setAssignmentMethodType-int-) | Ophalen of instellen of het label automatisch of via een gebruikersbeslissing is toegepast. |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) | Ophalen van de content‑markeringstypen die aan het label zijn gekoppeld. |

De klasse [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) definieert hoe een label is toegewezen:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) vertegenwoordigt een standaard‑ of automatisch toegepast label.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) vertegenwoordigt een label dat via een gebruikersbeslissing is toegepast, inclusief handmatig toegepaste, aanbevolen en verplichte labels.

De klasse [SensitivityLabelContentType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) definieert de markering die aan een label is gekoppeld:

| Waarde | Betekenis |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Het label is standaard of automatisch toegepast. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Koptekst‑contentmarkering is gekoppeld aan het label. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Voettekst‑contentmarkering is gekoppeld aan het label. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Watermerk‑contentmarkering is gekoppeld aan het label. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Encryptiebescherming is gekoppeld aan het label. |

Meerdere markeringstypen kunnen aan één label worden gekoppeld.

## **Lijst bestaande gevoeligheidslabels**

Lees de moderne labelcollectie uit [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--) en doorloop deze. Het volgende voorbeeld somt elke eigenschap en content‑markering op die voor elk label is opgeslagen:

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

## **Een gevoeligheidslabel toevoegen met content‑markering**

Gebruik [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) met het label‑identificatie, site‑identificatie, ingeschakelde status en toewijzingsmethode. Nadat de methode het nieuwe [ISensitivityLabel](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isensitivitylabel/) heeft geretourneerd, voeg je de vereiste markeringstypen toe via de lijst die wordt geretourneerd door [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--).

Het volgende voorbeeld voegt een handmatig geselecteerd label toe dat is gekoppeld aan voettekst‑ en watermerk‑markeringen, en slaat het resultaat op als PPTX:

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

De waarden van [ISensitivityLabel](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isensitivitylabel/) kunnen gelezen en geschreven worden, behalve dat de lijst die wordt geretourneerd door [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) wordt aangepast via de lijstbewerkingen. Nadat u het gewenste label heeft gevonden, kunt u de identificatie, site‑identificatie, ingeschakelde status, toewijzingsmethode, verwijderingsstatus en content‑markeringstypen bijwerken. Sla de presentatie op om de wijzigingen te behouden.

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

Om te behouden dat een label is verwijderd, vindt u het label en roept u [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) aan met `true`. Dit behoudt de label‑invoer terwijl de verwijderingsstatus wordt vastgelegd. Als u in plaats daarvan een invoer uit de moderne collectie moet verwijderen, gebruikt u [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-); gebruik [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isensitivitylabelcollection/#clear--) om elke invoer te verwijderen.

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

## **Legacy MIP‑gevoeligheidslabels lezen en migreren**

Oudere MIP‑gebaseerde workflows kunnen metadata van gevoeligheidslabels opslaan in aangepaste documenteigenschappen in plaats van in de moderne labelcollectie. Lees die metadata met [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idocumentproperties/#getSensitivityLabels--). De methode parseert de legacy‑aangepaste eigenschappen en retourneert een array van [ISensitivityLabel](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isensitivitylabel/)‑objecten.

Om de metadata te migreren, voegt u elk geretourneerd label toe aan de moderne [ISensitivityLabelCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isensitivitylabelcollection/) via [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-). Omdat het toevoegen van een duplicaat label‑identificatie een uitzondering oplevert, controleert het voorbeeld de bestemmingscollectie voordat elk label wordt gekopieerd. U kunt extra validatie toevoegen om te bevestigen dat elk legacy‑label nog aanwezig is in het huidige Purview‑beleid.

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

De migratie kopieert de geparsete labelobjecten naar de moderne collectie. Het is niet nodig om alle aangepaste documenteigenschappen te wissen, zodat ongerelateerde documentmetadata intact blijven. Gebruik [IPresentation.save](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) met [SaveFormat.Pptx](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/saveformat/) om de moderne labelmetadata naar een PPTX‑bestand te schrijven.

## **Veelgestelde vragen**

**Voegt het toevoegen van een content‑markeringstype een zichtbare header, footer of watermerk toe aan dia's?**

Nee. De waarden die via de lijst die door [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) wordt geretourneerd worden toegevoegd, beschrijven de markeringen die bij het gevoeligheidslabel horen. Ze creëren geen zichtbare tekst of vormen in de presentatie. Voeg de overeenkomstige dia‑inhoud apart toe als uw workflow die markeringen moet renderen.

**Wat is het verschil tussen een label markeren als verwijderd en het uit de collectie verwijderen?**

Het aanroepen van [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) met `true` behoudt de label‑invoer en registreert de verwijderingsstatus. Het aanroepen van [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) verwijdert de invoer uit de moderne collectie. Kies de bewerking die past bij de retentie‑eisen van uw organisatie.

**Kan een presentatie zowel legacy MIP‑metadata als moderne gevoeligheidslabels bevatten?**

Ja. Legacy‑labels kunnen blijven bestaan in aangepaste documenteigenschappen, terwijl moderne labels beschikbaar zijn via [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--). Gebruik [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) om de legacy‑metadata te lezen en migreer alleen de geldige labels die nog niet aanwezig zijn in de moderne collectie.

**Wat gebeurt er wanneer een label met dezelfde identificatie meer dan één keer wordt toegevoegd?**

[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) geeft een uitzondering wanneer de collectie al een label met dezelfde identificatie bevat. Controleer bestaande waarden die worden geretourneerd door [ISensitivityLabel.getId](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isensitivitylabel/#getId--) vóór het toevoegen of migreren van labels.

**Welk output‑formaat moet worden gebruikt om bijgewerkte gevoeligheidslabels te behouden?**

Sla de presentatie op als PPTX door [IPresentation.save](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) aan te roepen met [SaveFormat.Pptx](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/saveformat/), zoals geïllustreerd in de voorbeelden hierboven.