---
title: Manage Sensitivity Labels in PowerPoint Presentations in .NET
linktitle: Sensitivity Labels
type: docs
weight: 50
url: /sv/net/sensitivity-labels/
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
- .NET
- C#
- Aspose.Slides
description: "Read, add, update, remove, and migrate Microsoft Purview sensitivity labels in PowerPoint PPTX presentations with Aspose.Slides for .NET."
---
## **Översikt**

Microsoft Purview-sensitivitetsetiketter hjälper organisationer att klassificera och styra dokument. Vid automatiserad bearbetning av presentationer kan en applikation behöva bevara en befintlig etikett, tillämpa en etikett som valts av en policy, uppdatera dess tillstånd eller migrera etiketmetadata som skrivits av ett äldre Microsoft Information Protection (MIP)-arbetsflöde.

Aspose.Slides exponerar modern metadata för sensitivitetsetiketter via [Presentation.SensitivityLabels](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/sensitivitylabels/). Denna egenskap returnerar en [ISensitivityLabelCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/isensitivitylabelcollection/) som kan inspekteras och modifieras innan presentationen sparas som PPTX.

{{% alert color="info" title="Note" %}}
Identifikatorer för sensitivitetsetiketter och policyinformation definieras av din Microsoft Purview‑konfiguration. Validera etikettens tillgänglighet och policykrav i din miljö innan du lägger till eller migrerar metadata. Värdena i [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/sv/net/aspose.slides/isensitivitylabel/contentmarktypes/) beskriver de innehållsmärkningar som är associerade med en etikett; de lägger inte själva till synlig text eller former på bilder.
{{% /alert %}}

## **Förstå egenskaper för sensitivitetsetiketter**

Varje [ISensitivityLabel](https://reference.aspose.com/slides/sv/net/aspose.slides/isensitivitylabel/) innehåller följande metadata:

| Egenskap | Syfte |
| --- | --- |
| [ISensitivityLabel.Id](https://reference.aspose.com/slides/sv/net/aspose.slides/isensitivitylabel/id/) | Identifierar sensitivitetsetiketten i Purview‑policyn. |
| [ISensitivityLabel.SiteId](https://reference.aspose.com/slides/sv/net/aspose.slides/isensitivitylabel/siteid/) | Identifierar webbplatsen som är associerad med etikettpolicyn. |
| [ISensitivityLabel.IsEnabled](https://reference.aspose.com/slides/sv/net/aspose.slides/isensitivitylabel/isenabled/) | Indikerar om etiketten är aktiverad. |
| [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/sv/net/aspose.slides/isensitivitylabel/isremoved/) | Indikerar att etiketten har tagits bort. Sätt denna egenskap till `true` när borttagningsstatusen måste behållas i metadata. |
| [ISensitivityLabel.AssignmentMethodType](https://reference.aspose.com/slides/sv/net/aspose.slides/isensitivitylabel/assignmentmethodtype/) | Anger om etiketten tillämpades automatiskt eller genom ett användarbeslut. |
| [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/sv/net/aspose.slides/isensitivitylabel/contentmarktypes/) | Listar de typer av innehållsmärkning som är associerade med etiketten. |

Enumerationtypen [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/sv/net/aspose.slides/sensitivitylabelassignmenttype/) beskriver hur en etikett tilldelades:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/sv/net/aspose.slides/sensitivitylabelassignmenttype/) representerar en standard- eller automatiskt tillämpad etikett.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/sv/net/aspose.slides/sensitivitylabelassignmenttype/) representerar en etikett som tillämpats genom ett användarbeslut, inklusive manuellt tillämpade, rekommenderade och obligatoriska etiketter.

Enumerationtypen [SensitivityLabelContentType](https://reference.aspose.com/slides/sv/net/aspose.slides/sensitivitylabelcontenttype/) identifierar märkningen som är associerad med en etikett:

| Värde | Betydelse |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/sv/net/aspose.slides/sensitivitylabelcontenttype/) | Etiketten tillämpades som standard eller automatiskt. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/sv/net/aspose.slides/sensitivitylabelcontenttype/) | Rubrikens innehållsmärkning är associerad med etiketten. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/sv/net/aspose.slides/sensitivitylabelcontenttype/) | Fotots innehållsmärkning är associerad med etiketten. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/sv/net/aspose.slides/sensitivitylabelcontenttype/) | Vattenstämpelns innehållsmärkning är associerad med etiketten. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/sv/net/aspose.slides/sensitivitylabelcontenttype/) | Krypteringsskydd är associerat med etiketten. |

Flera märkningstyper kan vara associerade med en etikett.

## **Lista befintliga sensitivitetsetiketter**

Läs den moderna etikettkollektionen från [Presentation.SensitivityLabels](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/sensitivitylabels/) och gå igenom den. Följande exempel listar varje egenskap och innehållsmärkning som lagras för varje etikett:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

foreach (var sensitivityLabel in sensitivityLabels)
{
    Console.WriteLine("Label ID: " + sensitivityLabel.Id);
    Console.WriteLine("Site ID: " + sensitivityLabel.SiteId);
    Console.WriteLine("Enabled: " + sensitivityLabel.IsEnabled);
    Console.WriteLine("Removed: " + sensitivityLabel.IsRemoved);
    Console.WriteLine("Assignment method: " + sensitivityLabel.AssignmentMethodType);

    foreach (var contentMarkType in sensitivityLabel.ContentMarkTypes)
    {
        Console.WriteLine("Content marking: " + contentMarkType);
    }
}
```

## **Lägg till en sensitivitetsetikett med innehållsmärkning**

Använd [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/sv/net/aspose.slides/isensitivitylabelcollection/add/) med etikettens identifierare, webbplatsens identifierare, aktiverat tillstånd och tilldelningsmetod. När metoden returnerar den nya [ISensitivityLabel](https://reference.aspose.com/slides/sv/net/aspose.slides/isensitivitylabel/), lägg till de erforderliga märkningvärdena via [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/sv/net/aspose.slides/isensitivitylabel/contentmarktypes/).

Följande exempel lägger till en manuellt vald etikett som är associerad med fot- och vattenstämpelmärkningar, och sparar sedan resultatet som PPTX:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

var labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
var siteIdentifier = Guid.Parse("{aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee}");
var isEnabled = true;
var assignmentMethod = SensitivityLabelAssignmentType.Privileged;

var sensitivityLabel = sensitivityLabels.Add(
    labelIdentifier,
    siteIdentifier,
    isEnabled,
    assignmentMethod);

sensitivityLabel.ContentMarkTypes.Add(SensitivityLabelContentType.Footer);
sensitivityLabel.ContentMarkTypes.Add(SensitivityLabelContentType.Watermark);

presentation.Save("presentation_with_label.pptx", SaveFormat.Pptx);
```

## **Uppdatera en sensitivitetsetikett**

Egenskaperna för [ISensitivityLabel](https://reference.aspose.com/slides/sv/net/aspose.slides/isensitivitylabel/) är läs-/skrivbara, med undantag för att samlingen som returneras av [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/sv/net/aspose.slides/isensitivitylabel/contentmarktypes/) modifieras via dess listoperationer. Efter att ha hittat den erforderliga etiketten kan du uppdatera dess identifierare, webbplatsidentifierare, aktiverade tillstånd, tilldelningsmetod, borttagningsstatus och typer av innehållsmärkning. Spara presentationen för att bevara ändringarna.

Följande exempel uppdaterar det aktiverade tillståndet och tilldelningsmetoden för den första etiketten:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;

if (sensitivityLabels.Count > 0)
{
    var sensitivityLabel = sensitivityLabels[0];
    sensitivityLabel.IsEnabled = true;
    sensitivityLabel.AssignmentMethodType = SensitivityLabelAssignmentType.Privileged;
}

presentation.Save("presentation_with_updated_label.pptx", SaveFormat.Pptx);
```

## **Markera en sensitivitetsetikett som borttagen**

För att bevara att en etikett har tagits bort, hitta etiketten och sätt [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/sv/net/aspose.slides/isensitivitylabel/isremoved/) till `true`. Detta behåller etikettposten samtidigt som dess borttagningsstatus registreras. Om du istället behöver ta bort en post från den moderna samlingen, använd [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/sv/net/aspose.slides/isensitivitylabelcollection/removeat/); använd [ISensitivityLabelCollection.Clear](https://reference.aspose.com/slides/sv/net/aspose.slides/isensitivitylabelcollection/clear/) för att radera alla poster.

Följande exempel markerar en specifik etikett som borttagen och sparar den uppdaterade presentationen:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var sensitivityLabels = presentation.SensitivityLabels;
var targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";

foreach (var sensitivityLabel in sensitivityLabels)
{
    var isTargetLabel = string.Equals(
        sensitivityLabel.Id,
        targetLabelIdentifier,
        StringComparison.OrdinalIgnoreCase);

    if (isTargetLabel)
    {
        sensitivityLabel.IsRemoved = true;
        break;
    }
}

presentation.Save("presentation_with_removed_label.pptx", SaveFormat.Pptx);
```

## **Läs och migrera äldre MIP‑sensitivitetsetiketter**

Äldre MIP‑baserade arbetsflöden kan lagra metadata för sensitivitetsetiketter i anpassade dokumentegenskaper istället för i den moderna etikettkollektionen. Läs den metadata med [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/sv/net/aspose.slides/idocumentproperties/getsensitivitylabels/). Metoden parsar de äldre anpassade egenskaperna och returnerar en array av [ISensitivityLabel](https://reference.aspose.com/slides/sv/net/aspose.slides/isensitivitylabel/)‑objekt.

För att migrera metadata, lägg till varje returnerad etikett i den moderna [ISensitivityLabelCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/isensitivitylabelcollection/) via [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/sv/net/aspose.slides/isensitivitylabelcollection/add/). Eftersom tillägg av en duplicerad etiketttidentifierare utlöser ett undantag, kontrollerar exemplet målkollektionen innan varje etikett kopieras. Du kan lägga till ytterligare validering för att bekräfta att varje äldre etikett fortfarande finns i den aktuella Purview‑policyn.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation_with_legacy_labels.pptx");
var legacySensitivityLabels = presentation.DocumentProperties.GetSensitivityLabels();
var modernSensitivityLabels = presentation.SensitivityLabels;

foreach (var legacySensitivityLabel in legacySensitivityLabels)
{
    var labelAlreadyExists = false;

    foreach (var modernSensitivityLabel in modernSensitivityLabels)
    {
        labelAlreadyExists = string.Equals(
            modernSensitivityLabel.Id,
            legacySensitivityLabel.Id,
            StringComparison.OrdinalIgnoreCase);

        if (labelAlreadyExists)
        {
            break;
        }
    }

    if (!labelAlreadyExists)
    {
        modernSensitivityLabels.Add(legacySensitivityLabel);
    }
}

presentation.Save("presentation_with_modern_labels.pptx", SaveFormat.Pptx);
```

Migreringen kopierar de parsade etikettsobjekten till den moderna kollektionen. Det kräver inte att alla anpassade dokumentegenskaper rensas, så orelaterad dokumentmetadata förblir intakt. Använd [IPresentation.Save](https://reference.aspose.com/slides/sv/net/aspose.slides/ipresentation/save/) med [SaveFormat.Pptx](https://reference.aspose.com/slides/sv/net/aspose.slides.export/saveformat/) för att skriva den moderna etiketmetadata till en PPTX‑fil.

## **FAQ**

**Skapar tillägg av en innehållsmärkningstyp en synlig rubrik, fot eller vattenstämpel på bilder?**

Nej. Värden som läggs till via [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/sv/net/aspose.slides/isensitivitylabel/contentmarktypes/) beskriver de märkningar som är associerade med sensitivitetsetiketten. De skapar inte synlig text eller former i presentationen. Lägg till motsvarande bildinnehåll separat om ditt arbetsflöde måste rendera dessa märkningar.

**Vad är skillnaden mellan att markera en etikett som borttagen och att ta bort den från samlingen?**

Att sätta [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/sv/net/aspose.slides/isensitivitylabel/isremoved/) till `true` behåller etikettsposten och registrerar dess borttagningsstatus. Att anropa [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/sv/net/aspose.slides/isensitivitylabelcollection/removeat/) tar bort posten från den moderna samlingen. Välj den operation som matchar din organisations krav på metadata‑behållning.

**Kan en presentation innehålla både äldre MIP‑metadata och moderna sensitivitetsetiketter?**

Ja. Äldre etiketter kan finnas kvar i anpassade dokumentegenskaper medan moderna etiketter är tillgängliga via [Presentation.SensitivityLabels](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/sensitivitylabels/). Använd [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/sv/net/aspose.slides/idocumentproperties/getsensitivitylabels/) för att läsa den äldre metadata och migrera endast de giltiga etiketter som ännu inte finns i den moderna samlingen.

**Vad händer när en etikett med samma identifierare läggs till mer än en gång?**

[ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/sv/net/aspose.slides/isensitivitylabelcollection/add/) kastar ett `ArgumentException` när kollektionen redan innehåller en etikett med samma identifierare. Kontrollera befintliga [ISensitivityLabel.Id](https://reference.aspose.com/slides/sv/net/aspose.slides/isensitivitylabel/id/)‑värden innan du lägger till eller migrerar etiketter.

**Vilket utdataformat bör användas för att bevara uppdaterade sensitivitetsetiketter?**

Spara presentationen som PPTX genom att anropa [IPresentation.Save](https://reference.aspose.com/slides/sv/net/aspose.slides/ipresentation/save/) med [SaveFormat.Pptx](https://reference.aspose.com/slides/sv/net/aspose.slides.export/saveformat/), som visas i exemplen ovan.