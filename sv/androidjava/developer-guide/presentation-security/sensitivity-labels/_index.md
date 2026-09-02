---
title: Hantera sensitivitetsetiketter i PowerPoint-presentationer på Android
linktitle: Sensitivitetsetiketter
type: docs
weight: 50
url: /sv/androidjava/sensitivity-labels/
keywords:
- sensitivitetsetikett
- Microsoft Purview
- Microsoft Information Protection
- MIP-metadata
- innehållsmärkning
- informationsskydd
- dokumentstyrning
- PowerPoint
- PPTX
- presentationssäkerhet
- Android
- Java
- Aspose.Slides
description: "Läs, lägg till, uppdatera, ta bort och migrera Microsoft Purview-sensitivitetsetiketter i PowerPoint PPTX-presentationer med Aspose.Slides för Android via Java."
---
## **Översikt**

Microsoft Purview sensitivitetsetiketter hjälper organisationer att klassificera och hantera dokument. Vid automatiserad presentation bearbetning kan en applikation behöva bevara en befintlig etikett, tillämpa en etikett som valts av en policy, uppdatera dess status eller migrera etikettsmetadata som skrivits av ett äldre Microsoft Information Protection (MIP)-arbetsflöde.

Aspose.Slides för Android via Java exponerar modern metadata för sensitivitetsetiketter via [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--). Denna metod returnerar en [ISensitivityLabelCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isensitivitylabelcollection/) som kan inspekteras och modifieras innan presentationen sparas som PPTX.

{{% alert color="primary" title="Obs" %}}
Identifierare för sensitivitetsetiketter och policyinformation definieras av din Microsoft Purview‑konfiguration. Validera etikettillgänglighet och policyspecifikationer i din miljö innan du lägger till eller migrerar metadata. Värdena i [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) beskriver de innehållsmärkningar som är associerade med en etikett; de lägger inte själva till synlig text eller former på bilderna.
{{% /alert %}}

## **Förstå egenskaper för sensitivitetsetikett**

Varje [ISensitivityLabel](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isensitivitylabel/) innehåller följande metadata:

| Metoder | Syfte |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isensitivitylabel/#getId--) and [ISensitivityLabel.setId](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isensitivitylabel/#setId-java.lang.String-) | Hämta eller ange identifieraren för sensitivitetsetiketten i Purview‑policyn. |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isensitivitylabel/#getSiteId--) and [ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isensitivitylabel/#setSiteId-java.util.UUID-) | Hämta eller ange webbplatsen som är kopplad till etikettriktlinjen. |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isensitivitylabel/#isEnabled--) and [ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isensitivitylabel/#setEnabled-boolean-) | Hämta eller ange om etiketten är aktiverad. |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isensitivitylabel/#isRemoved--) and [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) | Hämta eller ange om etiketten har tagits bort. Sätt värdet till `true` när borttagningsstatusen måste behållas i metadata. |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isensitivitylabel/#getAssignmentMethodType--) and [ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isensitivitylabel/#setAssignmentMethodType-int-) | Hämta eller ange om etiketten tillämpades automatiskt eller genom ett användarbeslut. |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) | Hämta de innehållsmärknings typerna som är associerade med etiketten. |

Klassen [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) definierar hur en etikett tilldelades:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) representerar en standard‑ eller automatiskt tillämpad etikett.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) representerar en etikett som tillämpats genom ett användarbeslut, inklusive manuellt tillämpade, rekommenderade och obligatoriska etiketter.

Klassen [SensitivityLabelContentType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) definierar märkningarna som är associerade med en etikett:

| Värde | Betydelse |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Etiketten tillämpades som standard eller automatiskt. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Huvudrubrikens innehållsmärkning är associerad med etiketten. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Sidfotens innehållsmärkning är associerad med etiketten. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Vattenstämpelns innehållsmärkning är associerad med etiketten. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Krypteringsskydd är associerat med etiketten. |

Flera märkningstyper kan vara associerade med en etikett.

## **Lista befintliga sensitivitetsetiketter**

Läs den moderna etikettkollektionen från [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--) och iterera över den. Följande exempel listar varje egenskap och innehållsmärkning som lagras för varje etikett:

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

## **Lägg till en sensitivitetsetikett med innehållsmärkning**

Använd [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) med etikettidentifieraren, webbplatsidentifieraren, aktiveringsstatusen och tilldelningsmetoden. Efter att metoden returnerat den nya [ISensitivityLabel](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isensitivitylabel/), lägg till de nödvändiga märkningsvärdena via listan som returneras av [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--).

Följande exempel lägger till en manuellt vald etikett som är associerad med sidfot- och vattenstämpelmärkningar, och sparar sedan resultatet som PPTX:

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

## **Uppdatera en sensitivitetsetikett**

Värdena i [ISensitivityLabel](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isensitivitylabel/) kan läsas/skrivas, förutom att listan som returneras av [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) modifieras via dess listoperationer. Efter att ha hittat den önskade etiketten kan du uppdatera dess identifierare, webbplatsidentifierare, aktiveringsstatus, tilldelningsmetod, borttagningsstatus och typer av innehållsmärkning. Spara presentationen för att bevara förändringarna.

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

## **Markera en sensitivitetsetikett som borttagen**

För att bevara att en etikett har tagits bort, hitta etiketten och anropa [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) med `true`. Detta behåller etikettposten samtidigt som dess borttagningsstatus registreras. Om du istället behöver ta bort en post från den moderna kollektionen, använd [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-); använd [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isensitivitylabelcollection/#clear--) för att radera alla poster.

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

## **Läs och migrera äldre MIP‑sensitivitetsetiketter**

Äldre MIP‑baserade arbetsflöden kan lagra metadata för sensitivitetsetiketter i anpassade dokumentegenskaper istället för den moderna etikettkollektionen. Läs den metadata med [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/idocumentproperties/#getSensitivityLabels--). Metoden parsar de äldre anpassade egenskaperna och returnerar en array av [ISensitivityLabel](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isensitivitylabel/)‑objekt.

För att migrera metadata, lägg till varje returnerad etikett i den moderna [ISensitivityLabelCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isensitivitylabelcollection/) via [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-). Eftersom att lägga till en duplicerad etikettidentifierare orsakar ett undantag, kontrollerar exemplet målkollektionen innan varje etikett kopieras. Du kan lägga till ytterligare validering för att bekräfta att varje äldre etikett fortfarande finns i den nuvarande Purview‑policyn.

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

Migreringen kopierar de parsade etikettobjekten till den moderna kollektionen. Det kräver ingen rensning av alla anpassade dokumentegenskaper, så orelaterad dokumentmetadata förblir intakt. Använd [IPresentation.save](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) med [SaveFormat.Pptx](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/saveformat/) för att skriva den moderna etikettmetadata till en PPTX‑fil.

## **Vanliga frågor**

**Skapar tillägg av en innehållsmärkning en synlig rubrik, sidfot eller vattenstämpel på bilderna?**

Nej. Värden som läggs till via listan som returneras av [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) beskriver de märkningar som är associerade med sensitivitetsetiketten. De skapar ingen synlig text eller former i presentationen. Lägg till motsvarande bildinnehåll separat om ditt arbetsflöde måste rendera dessa märkningar.

**Vad är skillnaden mellan att markera en etikett som borttagen och att ta bort den från kollektionen?**

Att anropa [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) med `true` behåller etikettposten och registrerar dess borttagningsstatus. Att anropa [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) tar bort posten från den moderna kollektionen. Välj den operation som matchar ditt företags krav på retention av metadata.

**Kan en presentation innehålla både äldre MIP‑metadata och moderna sensitivitetsetiketter?**

Ja. Äldre etiketter kan finnas kvar i anpassade dokumentegenskaper medan moderna etiketter är tillgängliga via [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--). Använd [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) för att läsa den äldre metadata och migrera endast de giltiga etiketter som ännu inte finns i den moderna kollektionen.

**Vad händer när en etikett med samma identifierare läggs till mer än en gång?**

[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) kastar ett undantag när kollektionen redan innehåller en etikett med samma identifierare. Kontrollera befintliga värden som returneras av [ISensitivityLabel.getId](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isensitivitylabel/#getId--) innan du lägger till eller migrerar etiketter.

**Vilket utskriftsformat bör användas för att bevara uppdaterade sensitivitetsetiketter?**

Spara presentationen som PPTX genom att anropa [IPresentation.save](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) med [SaveFormat.Pptx](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/saveformat/), som visas i exemplen ovan.