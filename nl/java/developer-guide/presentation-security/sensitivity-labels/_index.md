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

Microsoft Purview-gevoeligheidslabels helpen organisaties documenten te classificeren en te beheren. Tijdens geautomatiseerde presentatieverwerking kan een applicatie een bestaand label moeten behouden, een label toepassen dat door een beleid is geselecteerd, de status bijwerken of labelmetadata migreren die door een oudere Microsoft Information Protection (MIP)-workflow zijn geschreven.

Aspose.Slides maakt moderne metadata van gevoeligheidslabels beschikbaar via [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipresentation/#getSensitivityLabels--). Deze methode retourneert een [ISensitivityLabelCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isensitivitylabelcollection/) die kan worden geïnspecteerd en aangepast voordat de presentatie wordt opgeslagen als PPTX.

{{% alert color="primary" title="Note" %}}
Identificatoren van gevoeligheidslabels en beleidsinformatie worden gedefinieerd door uw Microsoft Purview‑configuratie. Controleer de beschikbaarheid van labels en de beleidsvereisten in uw omgeving voordat u metadata toevoegt of migreert. De waarden van [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) beschrijven de inhoudsmarkeringen die aan een label zijn gekoppeld; ze voegen op zichzelf geen zichtbare tekst of vormen toe aan dia’s.
{{% /alert %}}

## **Begrijp de eigenschappen van gevoeligheidslabels**

Elk [ISensitivityLabel](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isensitivitylabel/) bevat de volgende metadata:

| Methoden | Doel |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isensitivitylabel/#getId--) en [ISensitivityLabel.setId](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isensitivitylabel/#setId-java.lang.String-) | Het identificatienummer van het gevoeligheidslabel in het Purview‑beleid ophalen of instellen. |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isensitivitylabel/#getSiteId--) en [ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isensitivitylabel/#setSiteId-java.util.UUID-) | De site die bij het labelbeleid hoort ophalen of instellen. |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isensitivitylabel/#isEnabled--) en [ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isensitivitylabel/#setEnabled-boolean-) | Controleren of het label is ingeschakeld en de status eventueel aanpassen. |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isensitivitylabel/#isRemoved--) en [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) | Controleren of het label is verwijderd. Stel de waarde in op `true` wanneer de verwijderingsstatus moet worden bewaard in de metadata. |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isensitivitylabel/#getAssignmentMethodType--) en [ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isensitivitylabel/#setAssignmentMethodType-int-) | Ophalen of instellen of het label automatisch of via een gebruikersbeslissing is toegepast. |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) | De soorten inhoudsmarkeringen die aan het label zijn gekoppeld ophalen. |

De klasse [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/sensitivitylabelassignmenttype/) definieert hoe een label is toegewezen:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/nl/java/com.aspose.slides/sensitivitylabelassignmenttype/) vertegenwoordigt een standaard of automatisch toegepast label.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/nl/java/com.aspose.slides/sensitivitylabelassignmenttype/) vertegenwoordigt een label dat via een gebruikersbeslissing is toegepast, inclusief handmatig toegepaste, aanbevolen en verplichte labels.

De klasse [SensitivityLabelContentType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/sensitivitylabelcontenttype/) definieert de markering die aan een label is gekoppeld:

| Waarde | Betekenis |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/nl/java/com.aspose.slides/sensitivitylabelcontenttype/) | Het label is standaard of automatisch toegepast. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/nl/java/com.aspose.slides/sensitivitylabelcontenttype/) | Er is een header‑inhoudsmarkering gekoppeld aan het label. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/nl/java/com.aspose.slides/sensitivitylabelcontenttype/) | Er is een footer‑inhoudsmarkering gekoppeld aan het label. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/nl/java/com.aspose.slides/sensitivitylabelcontenttype/) | Er is een watermerk‑inhoudsmarkering gekoppeld aan het label. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/nl/java/com.aspose.slides/sensitivitylabelcontenttype/) | Er is een encryptiebescherming gekoppeld aan het label. |

Meerdere markeringstypen kunnen aan één label worden gekoppeld.

## **Lijst bestaande gevoeligheidslabels**

Lees de moderne labelverzameling via [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipresentation/#getSensitivityLabels--) en doorloop deze. Het volgende voorbeeld geeft elke eigenschap en inhoudsmarkering weer die voor elk label is opgeslagen:

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

Gebruik [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) met het label‑identificatienummer, het site‑identificatienummer, de ingeschakelde status en de toewijzingsmethode. Nadat de methode het nieuwe [ISensitivityLabel](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isensitivitylabel/) heeft geretourneerd, voegt u de benodigde markeringwaarden toe via de lijst die wordt teruggegeven door [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--).

Het volgende voorbeeld voegt een handmatig geselecteerd label toe dat is gekoppeld aan footer‑ en watermerk‑markeringen, en slaat het resultaat vervolgens op als PPTX:

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

De waarden van [ISensitivityLabel](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isensitivitylabel/) zijn lees‑ en schrijfbaar, behalve dat de lijst die wordt teruggegeven door [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) wordt aangepast via de lijst‑operaties. Nadat u het gewenste label hebt gevonden, kunt u het identificatienummer, site‑identificatienummer, de ingeschakelde status, de toewijzingsmethode, de verwijderingsstatus en de inhoudsmarkeringstypen bijwerken. Sla de presentatie op om de wijzigingen te behouden.

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

## **Een gevoeligheidslabel markeren als verwijderd**

Om vast te leggen dat een label is verwijderd, zoekt u het label en roept u [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) aan met `true`. Hiermee blijft het label‑item bestaan, maar wordt de verwijderingsstatus geregistreerd. Als u in plaats daarvan een item uit de moderne verzameling wilt verwijderen, gebruikt u [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-); gebruik [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isensitivitylabelcollection/#clear--) om alle items te verwijderen.

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

Oudere MIP‑gebaseerde workflows kunnen gevoeligheidslabel‑metadata opslaan in aangepaste documenteigenschappen in plaats van in de moderne labelverzameling. Lees die metadata met [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/nl/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--). De methode analyseert de legacy‑eigenschappen en retourneert een array van [ISensitivityLabel](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isensitivitylabel/)‑objecten.

Om de metadata te migreren, voegt u elk geretourneerd label toe aan de moderne [ISensitivityLabelCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isensitivitylabelcollection/) via [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-). Omdat het toevoegen van een dubbel label‑identificatienummer een uitzondering veroorzaakt, controleert het voorbeeld de doelverzameling vóór het kopiëren van elk label. U kunt extra validatie toevoegen om te bevestigen dat elk legacy‑label nog steeds bestaat in het huidige Purview‑beleid.

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

De migratie kopieert de geanalyseerde labelobjecten naar de moderne verzameling. Het is niet nodig om alle aangepaste documenteigenschappen te wissen, zodat niet‑gerelateerde metadata behouden blijft. Gebruik [IPresentation.save](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) met [SaveFormat.Pptx](https://reference.aspose.com/slides/nl/java/com.aspose.slides/saveformat/) om de moderne labelmetadata naar een PPTX‑bestand te schrijven.

## **FAQ**

**Wordt er een zichtbaar header, footer of watermerk op dia’s gemaakt wanneer een inhoudsmarkeringstype wordt toegevoegd?**

Nee. De waarden die via de lijst van [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) worden toegevoegd, beschrijven de markeringen die bij het gevoeligheidslabel horen. Ze maken geen zichtbare tekst of vormen in de presentatie. Voeg de overeenkomstige dia‑inhoud apart toe als uw workflow deze markeringen moet weergeven.

**Wat is het verschil tussen een label markeren als verwijderd en het verwijderen uit de collectie?**

Het aanroepen van [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) met `true` behoudt het labelitem en registreert de verwijderingsstatus. Het aanroepen van [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) verwijdert het item uit de moderne collectie. Kies de bewerking die past bij de retentie‑vereisten van uw organisatie.

**Kan een presentatie zowel legacy MIP‑metadata als moderne gevoeligheidslabels bevatten?**

Ja. Legacy‑labels kunnen blijven bestaan in aangepaste documenteigenschappen, terwijl moderne labels beschikbaar zijn via [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipresentation/#getSensitivityLabels--). Gebruik [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/nl/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) om de legacy‑metadata te lezen en migreer alleen de geldige labels die nog niet in de moderne collectie aanwezig zijn.

**Wat gebeurt er als een label met hetzelfde identificatienummer meer dan één keer wordt toegevoegd?**

[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) veroorzaakt een uitzondering wanneer de collectie al een label met hetzelfde identificatienummer bevat. Controleer de bestaande waarden die door [ISensitivityLabel.getId](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isensitivitylabel/#getId--) worden geretourneerd voordat u labels toevoegt of migreert.

**Welk uitvoerformaat moet worden gebruikt om bijgewerkte gevoeligheidslabels te behouden?**

Sla de presentatie op als PPTX door [IPresentation.save](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) aan te roepen met [SaveFormat.Pptx](https://reference.aspose.com/slides/nl/java/com.aspose.slides/saveformat/), zoals getoond in de voorbeelden hierboven.