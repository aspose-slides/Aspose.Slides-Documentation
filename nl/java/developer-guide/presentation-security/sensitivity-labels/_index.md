---
title: Beheer gevoeligheidslabels in PowerPoint-presentaties in Java
linktitle: Gevoeligheidslabels
type: docs
weight: 50
url: /nl/java/sensitivity-labels/
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
- Java
- Aspose.Slides
description: "Lees, voeg toe, werk bij, verwijder en migreer Microsoft Purview-gevoeligheidslabels in PowerPoint-PPTX-presentaties met Aspose.Slides voor Java."
---
## **Overzicht**

Microsoft Purview‑gevoeligheidslabels helpen organisaties documenten te classificeren en te beheren. Tijdens geautomatiseerde presentatieverwerking kan een applicatie een bestaand label moeten behouden, een label toepassen dat door een beleid is geselecteerd, de status bijwerken, of labelmetadata migreren die door een oudere Microsoft Information Protection (MIP)‑workflow is geschreven.

Aspose.Slides maakt moderne metadata van gevoeligheidslabels beschikbaar via [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipresentation/#getSensitivityLabels--). Deze methode retourneert een [ISensitivityLabelCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isensitivitylabelcollection/) die kan worden geïnspecteerd en gewijzigd voordat de presentatie wordt opgeslagen als PPTX.

{{% alert color="info" title="Opmerking" %}}
De identificatoren van gevoeligheidslabels en beleidsinformatie worden gedefinieerd door uw Microsoft Purview‑configuratie. Controleer de beschikbaarheid van labels en de beleidsvereisten in uw omgeving voordat u metadata toevoegt of migreert. De waarden van [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) beschrijven de inhoudsmarkeringen die aan een label zijn gekoppeld; ze voegen op zichzelf geen zichtbare tekst of vormen toe aan dia's.
{{% /alert %}}

## **Begrijp de eigenschappen van gevoeligheidslabels**

Elke [ISensitivityLabel](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isensitivitylabel/) bevat de volgende metadata:

| Methoden | Doel |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isensitivitylabel/#getId--) en [ISensitivityLabel.setId](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isensitivitylabel/#setId-java.lang.String-) | Haal of stel de identificator van het gevoeligheidslabel in het Purview‑beleid in. |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isensitivitylabel/#getSiteId--) en [ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isensitivitylabel/#setSiteId-java.util.UUID-) | Haal of stel de site op die aan het labelbeleid is gekoppeld. |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isensitivitylabel/#isEnabled--) en [ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isensitivitylabel/#setEnabled-boolean-) | Haal of stel in of het label is ingeschakeld. |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isensitivitylabel/#isRemoved--) en [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) | Haal of stel in of het label is verwijderd. Zet de waarde op `true` wanneer de verwijderingsstatus in de metadata moet worden behouden. |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isensitivitylabel/#getAssignmentMethodType--) en [ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isensitivitylabel/#setAssignmentMethodType-int-) | Haal of stel in of het label automatisch of via een gebruikersbeslissing is toegepast. |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) | Haal de soorten inhoudsmarkeringen op die aan het label zijn gekoppeld. |

De klasse [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/sensitivitylabelassignmenttype/) definieert hoe een label is toegewezen:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/nl/java/com.aspose.slides/sensitivitylabelassignmenttype/) vertegenwoordigt een standaard‑ of automatisch toegepast label.  
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/nl/java/com.aspose.slides/sensitivitylabelassignmenttype/) vertegenwoordigt een label dat via een gebruikersbeslissing is toegepast, inclusief handmatig toegepaste, aanbevolen en verplichte labels.

De klasse [SensitivityLabelContentType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/sensitivitylabelcontenttype/) definieert de markering die aan een label is gekoppeld:

| Waarde | Betekenis |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/nl/java/com.aspose.slides/sensitivitylabelcontenttype/) | Het label is standaard of automatisch toegepast. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/nl/java/com.aspose.slides/sensitivitylabelcontenttype/) | Koptekst‑inhoudsmarkering is gekoppeld aan het label. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/nl/java/com.aspose.slides/sensitivitylabelcontenttype/) | Voettekst‑inhoudsmarkering is gekoppeld aan het label. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/nl/java/com.aspose.slides/sensitivitylabelcontenttype/) | Watermerk‑inhoudsmarkering is gekoppeld aan het label. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/nl/java/com.aspose.slides/sensitivitylabelcontenttype/) | Encryptiebescherming is gekoppeld aan het label. |

Meerdere markeringstypen kunnen aan één label worden gekoppeld.

## **Lijst bestaande gevoeligheidslabels**

Lees de moderne labelcollectie via [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipresentation/#getSensitivityLabels--) en enumerateer deze. Het volgende voorbeeld toont elke eigenschap en inhoudsmarkering die voor elk label is opgeslagen:

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

## **Voeg een gevoeligheidslabel toe met inhoudsmarkering**

Gebruik [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) met het label‑identificatort, site‑identificatort, de ingeschakelde status en de toewijzingsmethode. Nadat de methode het nieuwe [ISensitivityLabel](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isensitivitylabel/) heeft geretourneerd, voeg je de vereiste markeerwaarden toe via de lijst die wordt geretourneerd door [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--).

Het volgende voorbeeld voegt een handmatig geselecteerd label toe dat gekoppeld is aan voettekst‑ en watermerk‑markeringen, en slaat vervolgens het resultaat op als PPTX:

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

## **Werk een gevoeligheidslabel bij**

De waarden van [ISensitivityLabel](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isensitivitylabel/) zijn lees‑/schrijfbaar, behalve dat de lijst die wordt geretourneerd door [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) wordt gewijzigd via de lijstbewerkingen. Na het vinden van het gewenste label kun je de identificator, site‑identificator, ingeschakelde status, toewijzingsmethode, verwijderingsstatus en inhoudsmarkeringstypen bijwerken. Sla de presentatie op om de wijzigingen te behouden.

Het volgende voorbeeld werkt de ingeschakelde status en de toewijzingsmethode van het eerste label bij:

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

## **Markeer een gevoeligheidslabel als verwijderd**

Om het feit te behouden dat een label is verwijderd, zoek je het label en roep je [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) aan met `true`. Dit behoudt de labelvermelding terwijl de verwijderingsstatus wordt vastgelegd. Als je in plaats daarvan een vermelding uit de moderne collectie wilt verwijderen, gebruik dan [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-); gebruik [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isensitivitylabelcollection/#clear--) om elke vermelding te verwijderen.

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

## **Lees en migreer legacy MIP‑gevoeligheidslabels**

Oudere MIP‑gebaseerde workflows kunnen metadata van gevoeligheidslabels opslaan in aangepaste documenteigenschappen in plaats van in de moderne labelcollectie. Lees die metadata met [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/nl/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--). De methode parseert de legacy‑aangepaste eigenschappen en retourneert een array van [ISensitivityLabel](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isensitivitylabel/)‑objecten.

Om de metadata te migreren, voeg je elk geretourneerd label toe aan de moderne [ISensitivityLabelCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isensitivitylabelcollection/) via [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-). Omdat het toevoegen van een dubbele label‑identificator een uitzondering veroorzaakt, controleert het voorbeeld de doelcollectie voordat elk label wordt gekopieerd. Je kunt extra validatie toevoegen om te bevestigen dat elk legacy‑label nog bestaat in het huidige Purview‑beleid.

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

De migratie kopieert de geparseerde labelobjecten naar de moderne collectie. Het is niet nodig om alle aangepaste documenteigenschappen te wissen, zodat niet‑gerelateerde documentmetadata intact blijft. Gebruik [IPresentation.save](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) met [SaveFormat.Pptx](https://reference.aspose.com/slides/nl/java/com.aspose.slides/saveformat/) om de moderne labelmetadata naar een PPTX‑bestand te schrijven.

## **FAQ**

**Maakt het toevoegen van een inhoudsmarkeringstype een zichtbare koptekst, voettekst of watermerk op dia's?**

Nee. De waarden die via de lijst die door [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) wordt geretourneerd worden toegevoegd, beschrijven de markeringen die bij het gevoeligheidslabel horen. Ze creëren geen zichtbare tekst of vormen in de presentatie. Voeg de corresponderende dia‑inhoud apart toe als uw workflow deze markeringen moet weergeven.

**Wat is het verschil tussen een label markeren als verwijderd en het verwijderen uit de collectie?**

Het aanroepen van [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) met `true` behoudt de labelvermelding en registreert de verwijderingsstatus. Het aanroepen van [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) verwijdert de vermelding uit de moderne collectie. Kies de handeling die past bij de metadata‑retentie‑vereisten van uw organisatie.

**Kan een presentatie zowel legacy MIP‑metadata als moderne gevoeligheidslabels bevatten?**

Ja. Legacy‑labels kunnen blijven staan in aangepaste documenteigenschappen, terwijl moderne labels beschikbaar zijn via [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipresentation/#getSensitivityLabels--). Gebruik [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/nl/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) om de legacy‑metadata te lezen en migreer alleen de geldige labels die nog niet aanwezig zijn in de moderne collectie.

**Wat gebeurt er als een label met dezelfde identificator meer dan één keer wordt toegevoegd?**

[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) veroorzaakt een uitzondering wanneer de collectie al een label met dezelfde identificator bevat. Controleer de bestaande waarden die door [ISensitivityLabel.getId](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isensitivitylabel/#getId--) worden geretourneerd voordat je labels toevoegt of migreert.

**Welk uitvoerformaat moet worden gebruikt om bijgewerkte gevoeligheidslabels te behouden?**

Sla de presentatie op als PPTX door [IPresentation.save](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) aan te roepen met [SaveFormat.Pptx](https://reference.aspose.com/slides/nl/java/com.aspose.slides/saveformat/), zoals in de bovenstaande voorbeelden.