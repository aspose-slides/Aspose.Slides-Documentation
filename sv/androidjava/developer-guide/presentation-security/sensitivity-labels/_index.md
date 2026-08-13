---
title: Hantera känslighetsetiketter i PowerPoint-presentationer på Android
linktitle: Känslighetsetiketter
type: docs
weight: 50
url: /sv/androidjava/sensitivity-labels/
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
- Android
- Java
- Aspose.Slides
description: "Läs, lägg till, uppdatera, ta bort och migrera Microsoft Purview-sensitivitetsetiketter i PowerPoint PPTX-presentationer med Aspose.Slides för Android via Java."
---
## **Översikt**

Microsoft Purview‑känslighetsetiketter hjälper organisationer att klassificera och hantera dokument. Vid automatiserad bearbetning av presentationer kan en applikation behöva bevara en befintlig etikett, tillämpa en etikett som valts av en policy, uppdatera dess status eller migrera etikettmetadata som skrivits av ett äldre Microsoft Information Protection (MIP)‑arbetsflöde.

Aspose.Slides för Android via Java exponerar modern metadata för känslighetsetiketter via [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--). Denna metod returnerar en [ISensitivityLabelCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isensitivitylabelcollection/) som kan inspekteras och modifieras innan presentationen sparas som PPTX.

{{% alert color="info" title="Note" %}}
Känslighetsetikettens identifierare och policyinformation definieras av din Microsoft Purview‑konfiguration. Validera etikettens tillgänglighet och policykrav i din miljö innan du lägger till eller migrerar metadata. Värdena från [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) beskriver de innehållsmärkningar som är kopplade till en etikett; de lägger inte själva till synlig text eller former på bilderna.
{{% /alert %}}

## **Förstå egenskaper för känslighetsetiketter**

Varje [ISensitivityLabel](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isensitivitylabel/) innehåller följande metadata:

| Metoder | Syfte |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isensitivitylabel/#getId--) och [ISensitivityLabel.setId](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isensitivitylabel/#setId-java.lang.String-) | Hämta eller ange identifieraren för känslighetsetiketten i Purview‑policyn. |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isensitivitylabel/#getSiteId--) och [ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isensitivitylabel/#setSiteId-java.util.UUID-) | Hämta eller ange den webbplats som är kopplad till etikettpolicyn. |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isensitivitylabel/#isEnabled--) och [ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isensitivitylabel/#setEnabled-boolean-) | Hämta eller ange om etiketten är aktiverad. |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isensitivitylabel/#isRemoved--) och [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) | Hämta eller ange om etiketten har tagits bort. Sätt värdet till `true` när borttagningsstatusen måste bevaras i metadata. |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isensitivitylabel/#getAssignmentMethodType--) och [ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isensitivitylabel/#setAssignmentMethodType-int-) | Hämta eller ange om etiketten tillämpades automatiskt eller genom ett användarbeslut. |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) | Hämta typerna av innehållsmärkningar som är kopplade till etiketten. |

Klassen [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) definierar hur en etikett tilldelades:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) representerar en standard‑ eller automatiskt tillämpad etikett.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/sensitivitylabelassignmenttype/) representerar en etikett som tillämpats genom ett användarbeslut, inklusive manuellt tillämpade, rekommenderade och obligatoriska etiketter.

Klassen [SensitivityLabelContentType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) definierar märkningarna som är associerade med en etikett:

| Value | Meaning |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Etiketten tillämpades som standard eller automatiskt. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Innehållsmärkning för rubrik är associerad med etiketten. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Innehållsmärkning för sidfot är associerad med etiketten. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Innehållsmärkning för vattenstämpel är associerad med etiketten. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/sensitivitylabelcontenttype/) | Krypteringsskydd är associerat med etiketten. |

Flera märkningstyper kan vara associerade med en etikett.

## **Lista befintliga känslighetsetiketter**

Läs den moderna etikettkollektionen från [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--) och iterera den. Följande exempel listar varje egenskap och innehållsmärkning som lagras för varje etikett:

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

Använd [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) med etikettens identifierare, webbplatsidentifierare, aktiveringsstatus och tilldelningsmetod. När metoden returnerar den nya [ISensitivityLabel](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isensitivitylabel/) lägger du till de erforderliga märkningarna via listan som returneras av [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--).

Följande exempel lägger till en manuellt vald etikett som är kopplad till sidfot‑ och vattenstämpelmärkningar och sparar sedan resultatet som PPTX:

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

Värdena i [ISensitivityLabel](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isensitivitylabel/) är läs‑/skrivbara, förutom att listan som returneras av [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) modifieras via dess listoperationer. Efter att ha hittat den önskade etiketten kan du uppdatera dess identifierare, webbplatsidentifierare, aktiveringsstatus, tilldelningsmetod, borttagningsstatus och typer av innehållsmärkningar. Spara presentationen för att bevara ändringarna.

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

För att bevara att en etikett har tagits bort, hitta etiketten och anropa [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) med `true`. Detta behåller etikettposten samtidigt som borttagningsstatusen registreras. Om du istället behöver ta bort en post från den moderna kollektionen, använd [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-); använd [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isensitivitylabelcollection/#clear--) för att ta bort alla poster.

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

Äldre MIP‑baserade arbetsflöden kan lagra metadata för känslighetsetiketter i anpassade dokumentegenskaper i stället för den moderna etikettkollektionen. Läs den metadata med [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/idocumentproperties/#getSensitivityLabels--). Metoden analyserar de äldre anpassade egenskaperna och returnerar en array av [ISensitivityLabel](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isensitivitylabel/)‑objekt.

För att migrera metadata, lägg till varje returnerad etikett i den moderna [ISensitivityLabelCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isensitivitylabelcollection/) via [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-). Eftersom att lägga till en duplicerad etikettidentifierare ger ett undantag, kontrollerar exemplet destinationens kollektion innan varje etikett kopieras. Du kan lägga till ytterligare validering för att bekräfta att varje äldre etikett fortfarande finns i den aktuella Purview‑policyn.

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

Migreringen kopierar de analyserade etikettobjekten till den moderna kollektionen. Det krävs ingen rensning av alla anpassade dokumentegenskaper, så orelaterad dokumentmetadata förblir intakt. Använd [IPresentation.save](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) med [SaveFormat.Pptx](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/saveformat/) för att skriva den moderna etikettmetadata till en PPTX‑fil.

## **Vanliga frågor**

**Skapar tillägg av en innehållsmärkning en synlig rubrik, sidfot eller vattenstämpel på bilderna?**

Nej. Värden som läggs till via listan som returneras av [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) beskriver de märkningar som är kopplade till känslighetsetiketten. De skapar ingen synlig text eller former i presentationen. Lägg till motsvarande bildinnehåll separat om ditt arbetsflöde måste rendera dessa märkningar.

**Vad är skillnaden mellan att markera en etikett som borttagen och att ta bort den från kollektionen?**

Att anropa [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) med `true` behåller etikettposten och registrerar dess borttagningsstatus. Att anropa [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) tar bort posten från den moderna kollektionen. Välj den operation som matchar din organisations krav på metadata‑bevarandet.

**Kan en presentation innehålla både äldre MIP‑metadata och moderna känslighetsetiketter?**

Ja. Äldre etiketter kan finnas kvar i anpassade dokumentegenskaper medan moderna etiketter är tillgängliga via [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipresentation/#getSensitivityLabels--). Använd [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) för att läsa den äldre metadata och migrera endast de giltiga etiketter som ännu inte finns i den moderna kollektionen.

**Vad händer när en etikett med samma identifierare läggs till mer än en gång?**

[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) ger ett undantag när kollektionen redan innehåller en etikett med samma identifierare. Kontrollera befintliga värden som returneras av [ISensitivityLabel.getId](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/isensitivitylabel/#getId--) innan du lägger till eller migrerar etiketter.

**Vilket utdataformat bör användas för att bevara uppdaterade känslighetsetiketter?**

Spara presentationen som PPTX genom att anropa [IPresentation.save](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-) med [SaveFormat.Pptx](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/saveformat/), som visas i exemplen ovan.