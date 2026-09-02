---
title: Hantera känslighetsetiketter i PowerPoint-presentationer i Java
linktitle: Känslighetsetiketter
type: docs
weight: 50
url: /sv/java/sensitivity-labels/
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
- Java
- Aspose.Slides
description: "Läs, lägg till, uppdatera, ta bort och migrera Microsoft Purview‑känslighetsetiketter i PowerPoint PPTX‑presentationer med Aspose.Slides för Java."
---
## **Översikt**

Microsoft Purview‑känslighetsetiketter hjälper organisationer att klassificera och styra dokument. Vid automatiserad bildspelsbehandling kan en applikation behöva bevara en befintlig etikett, tillämpa en etikett som valts av en policy, uppdatera dess status eller migrera etikettmetadata som skrivits av ett äldre Microsoft Information Protection (MIP)‑arbetsflöde.

Aspose.Slides exponerar modern metadata för känslighetsetiketter via [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipresentation/#getSensitivityLabels--). Denna metod returnerar en [ISensitivityLabelCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isensitivitylabelcollection/) som kan inspekteras och ändras innan presentationen sparas som PPTX.

{{% alert color="primary" title="Note" %}}
Känslighetsetikettidentifierare och policyinformation definieras av din Microsoft Purview‑konfiguration. Validera etikettillgänglighet och policykrav i din miljö innan du lägger till eller migrerar metadata. Värdena från [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) beskriver innehållsmärkningar som är knutna till en etikett; de lägger inte själva till synlig text eller former på bilder.
{{% /alert %}}

## **Förstå egenskaper för känslighetsetiketter**

Varje [ISensitivityLabel](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isensitivitylabel/) innehåller följande metadata:

| Metoder | Syfte |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isensitivitylabel/#getId--) och [ISensitivityLabel.setId](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isensitivitylabel/#setId-java.lang.String-) | Hämta eller sätt identifieraren för känslighetsetiketten i Purview‑policyn. |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isensitivitylabel/#getSiteId--) och [ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isensitivitylabel/#setSiteId-java.util.UUID-) | Hämta eller sätt webbplatsen som är associerad med etikettpolicyn. |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isensitivitylabel/#isEnabled--) och [ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isensitivitylabel/#setEnabled-boolean-) | Hämta eller sätt om etiketten är aktiverad. |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isensitivitylabel/#isRemoved--) och [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) | Hämta eller sätt om etiketten har tagits bort. Sätt värdet till `true` när borttagningsstatusen måste behållas i metadata. |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isensitivitylabel/#getAssignmentMethodType--) och [ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isensitivitylabel/#setAssignmentMethodType-int-) | Hämta eller sätt om etiketten applicerades automatiskt eller via ett användarbeslut. |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) | Hämta de typ av innehållsmärkningar som är associerade med etiketten. |

Klassen [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/sensitivitylabelassignmenttype/) definierar hur en etikett tilldelades:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/sv/java/com.aspose.slides/sensitivitylabelassignmenttype/) representerar en standard‑ eller automatiskt tillämpad etikett.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/sv/java/com.aspose.slides/sensitivitylabelassignmenttype/) representerar en etikett som tillämpats genom ett användarbeslut, inklusive manuellt tillämpade, rekommenderade och obligatoriska etiketter.

Klassen [SensitivityLabelContentType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/sensitivitylabelcontenttype/) definierar märkningen som är associerad med en etikett:

| Värde | Betydelse |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/sv/java/com.aspose.slides/sensitivitylabelcontenttype/) | Etiketten tillämpades som standard eller automatiskt. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/sv/java/com.aspose.slides/sensitivitylabelcontenttype/) | Rubrikens innehållsmärkning är associerad med etiketten. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/sv/java/com.aspose.slides/sensitivitylabelcontenttype/) | Sidfotens innehållsmärkning är associerad med etiketten. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/sv/java/com.aspose.slides/sensitivitylabelcontenttype/) | Vattenstämpelns innehållsmärkning är associerad med etiketten. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/sv/java/com.aspose.slides/sensitivitylabelcontenttype/) | Krypteringsskydd är associerat med etiketten. |

Flera märkningstyper kan vara associerade med en etikett.

## **Lista befintliga känslighetsetiketter**

Läs den moderna etikettsamlingen från [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipresentation/#getSensitivityLabels--) och iterera igenom den. Följande exempel listar varje egenskap och innehållsmärkning som lagras för varje etikett:

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

## **Lägg till en känslighetsetikett med innehållsmärkning**

Använd [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) med etikettidentifieraren, webbplatsidentifieraren, aktiveringsstatusen och tilldelningsmetoden. När metoden returnerar den nya [ISensitivityLabel](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isensitivitylabel/), lägg till de nödvändiga märkningarna via listan som returneras av [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--).

Följande exempel lägger till en manuellt vald etikett som är associerad med sidfot‑ och vattenstämpelmärkningar, och sparar sedan resultatet som PPTX:

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

## **Uppdatera en känslighetsetikett**

Värdena i [ISensitivityLabel](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isensitivitylabel/) är läsbara och skrivbara, förutom att listan som returneras av [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) modifieras via dess listoperationer. Efter att ha hittat den önskade etiketten kan du uppdatera dess identifierare, webbplatsidentifierare, aktiveringsstatus, tilldelningsmetod, borttagningsstatus och innehållsmärkningstyper. Spara presentationen för att behålla ändringarna.

Följande exempel uppdaterar aktiveringsstatusen och tilldelningsmetoden för den första etiketten:

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

## **Markera en känslighetsetikett som borttagen**

För att bevara att en etikett har tagits bort, hitta etiketten och anropa [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) med `true`. Detta behåller etikettposten samtidigt som dess borttagningsstatus registreras. Om du istället behöver radera en post från den moderna samlingen, använd [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-); använd [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isensitivitylabelcollection/#clear--) för att radera alla poster.

Följande exempel markerar en specifik etikett som borttagen och sparar den uppdaterade presentationen:

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

## **Läs och migrera äldre MIP‑känslighetsetiketter**

Äldre MIP‑baserade arbetsflöden kan lagra metadata för känslighetsetiketter i anpassade dokumentegenskaper istället för i den moderna etikettsamlingen. Läs den metadata med [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/sv/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--). Metoden analyserar de äldre anpassade egenskaperna och returnerar en array av [ISensitivityLabel](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isensitivitylabel/)‑objekt.

För att migrera metadata, lägg till varje returnerad etikett i den moderna [ISensitivityLabelCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isensitivitylabelcollection/) via [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-). Eftersom ett duplicerat etikettidentifierare ger ett undantag, kontrollerar exemplet destinationens samling innan varje etikett kopieras. Du kan lägga till ytterligare validering för att bekräfta att varje äldre etikett fortfarande finns i den aktuella Purview‑policyn.

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

Migreringen kopierar de analyserade etikettsobjekten till den moderna samlingen. Det krävs ingen rensning av alla anpassade dokumentegenskaper, så orelaterad dokumentmetadata förblir intakt. Använd [IPresentation.save](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) med [SaveFormat.Pptx](https://reference.aspose.com/slides/sv/java/com.aspose.slides/saveformat/) för att skriva den moderna etikettmetadata till en PPTX‑fil.

## **FAQ**

**Skapar tillägg av en innehållsmärkningstyp en synlig rubrik, sidfot eller vattenstämpel på bilderna?**

Nej. Värden som läggs till via listan som returneras av [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) beskriver de märkningar som är kopplade till känslighetsetiketten. De skapar inte synlig text eller former i presentationen. Lägg till motsvarande bildinnehåll separat om ditt arbetsflöde måste rendera dessa märkningar.

**Vad är skillnaden mellan att markera en etikett som borttagen och att radera den från samlingen?**

Genom att anropa [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) med `true` behålls etikettposten och dess borttagningsstatus registreras. Genom att anropa [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) tas posten bort från den moderna samlingen. Välj den operation som motsvarar din organisations krav på metadata‑bevarande.

**Kan en presentation innehålla både äldre MIP‑metadata och moderna känslighetsetiketter?**

Ja. Äldre etiketter kan finnas kvar i anpassade dokumentegenskaper medan moderna etiketter är tillgängliga via [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipresentation/#getSensitivityLabels--). Använd [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/sv/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) för att läsa den äldre metadata och migrera endast de giltiga etiketter som ännu inte finns i den moderna samlingen.

**Vad händer när en etikett med samma identifierare läggs till mer än en gång?**

[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) kastar ett undantag när samlingen redan innehåller en etikett med samma identifierare. Kontrollera befintliga värden som returneras av [ISensitivityLabel.getId](https://reference.aspose.com/slides/sv/java/com.aspose.slides/isensitivitylabel/#getId--) innan du lägger till eller migrerar etiketter.

**Vilket utdataformat bör användas för att bevara uppdaterade känslighetsetiketter?**

Spara presentationen som PPTX genom att anropa [IPresentation.save](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) med [SaveFormat.Pptx](https://reference.aspose.com/slides/sv/java/com.aspose.slides/saveformat/), som visas i exemplen ovan.