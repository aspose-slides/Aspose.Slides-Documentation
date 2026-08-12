---
title: Beheer gevoeligheidslabels in PowerPoint‑presentaties in .NET
linktitle: Gevoeligheidslabels
type: docs
weight: 50
url: /nl/net/sensitivity-labels/
keywords:
- gevoeligheidslabel
- Microsoft Purview
- Microsoft Information Protection
- MIP‑metadata
- inhoudsmarkering
- informatiebeveiliging
- documentbeheer
- PowerPoint
- PPTX
- presentatiebeveiliging
- .NET
- C#
- Aspose.Slides
description: "Lees, voeg toe, werk bij, verwijder en migreer Microsoft Purview-gevoeligheidslabels in PowerPoint‑PPTX‑presentaties met Aspose.Slides voor .NET."
---
## **Overzicht**

Microsoft Purview sensitivity labels helpen organisaties documenten te classificeren en te beheren. Tijdens geautomatiseerde presentatieverwerking kan een toepassing een bestaand label behouden, een door een beleid geselecteerd label toepassen, de status updaten, of labelmetadata migreren die door een oudere Microsoft Information Protection (MIP)‑workflow is geschreven.

Aspose.Slides stelt moderne sensitivity‑labelmetadata beschikbaar via [Presentation.SensitivityLabels](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/sensitivitylabels/). Deze eigenschap retourneert een [ISensitivityLabelCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/isensitivitylabelcollection/) die kan worden geïnspecteerd en aangepast vóórdat de presentatie wordt opgeslagen als PPTX.

{{% alert color="primary" title="Opmerking" %}}
Identificatoren van gevoeligheidslabels en beleidsinformatie worden gedefinieerd door uw Microsoft Purview‑configuratie. Controleer de beschikbaarheid van labels en beleidsvereisten in uw omgeving voordat u metadata toevoegt of migreert. De waarden van [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/nl/net/aspose.slides/isensitivitylabel/contentmarktypes/) beschrijven de inhoudsmarkeringen die aan een label zijn gekoppeld; ze voegen op zichzelf geen zichtbare tekst of vormen toe aan dia's.
{{% /alert %}}

## **Begrijp de eigenschappen van gevoeligheidslabels**

Elke [ISensitivityLabel](https://reference.aspose.com/slides/nl/net/aspose.slides/isensitivitylabel/) bevat de volgende metadata:

| Eigenschap | Doel |
| --- | --- |
| [ISensitivityLabel.Id](https://reference.aspose.com/slides/nl/net/aspose.slides/isensitivitylabel/id/) | Identificeert het gevoeligheidslabel in het Purview‑beleid. |
| [ISensitivityLabel.SiteId](https://reference.aspose.com/slides/nl/net/aspose.slides/isensitivitylabel/siteid/) | Identificeert de site die bij het labelbeleid hoort. |
| [ISensitivityLabel.IsEnabled](https://reference.aspose.com/slides/nl/net/aspose.slides/isensitivitylabel/isenabled/) | Geeft aan of het label is ingeschakeld. |
| [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/nl/net/aspose.slides/isensitivitylabel/isremoved/) | Geeft aan dat het label is verwijderd. Stel deze eigenschap in op `true` wanneer de verwijderingsstatus bewaard moet blijven in de metadata. |
| [ISensitivityLabel.AssignmentMethodType](https://reference.aspose.com/slides/nl/net/aspose.slides/isensitivitylabel/assignmentmethodtype/) | Specificeert of het label automatisch is toegepast of via een gebruikersbeslissing. |
| [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/nl/net/aspose.slides/isensitivitylabel/contentmarktypes/) | Lijst de type inhoudsmarkeringen die aan het label zijn gekoppeld. |

De [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/nl/net/aspose.slides/sensitivitylabelassignmenttype/)‑enumeratie beschrijft hoe een label werd toegewezen:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/nl/net/aspose.slides/sensitivitylabelassignmenttype/) vertegenwoordigt een standaard of automatisch toegepast label.  
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/nl/net/aspose.slides/sensitivitylabelassignmenttype/) vertegenwoordigt een label dat via een gebruikersbeslissing is toegepast, inclusief handmatig aangebrachte, aanbevolen en verplichte labels.

De [SensitivityLabelContentType](https://reference.aspose.com/slides/nl/net/aspose.slides/sensitivitylabelcontenttype/)‑enumeratie identificeert de markering die aan een label is gekoppeld:

| Waarde | Betekenis |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/nl/net/aspose.slides/sensitivitylabelcontenttype/) | Het label werd standaard of automatisch toegepast. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/nl/net/aspose.slides/sensitivitylabelcontenttype/) | Koptekstinhoudmarkering is gekoppeld aan het label. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/nl/net/aspose.slides/sensitivitylabelcontenttype/) | Voettekstinhoudmarkering is gekoppeld aan het label. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/nl/net/aspose.slides/sensitivitylabelcontenttype/) | Watermerkinhoudmarkering is gekoppeld aan het label. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/nl/net/aspose.slides/sensitivitylabelcontenttype/) | Versleutelingsbescherming is gekoppeld aan het label. |

Meerdere markeringstypen kunnen aan één label worden gekoppeld.

## **Lijst bestaande gevoeligheidslabels**

Lees de moderne labelcollectie uit [Presentation.SensitivityLabels](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/sensitivitylabels/) en doorloop deze. Het volgende voorbeeld lijst elke eigenschap en inhoudsmarkering op die voor elk label is opgeslagen:

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

## **Voeg een gevoeligheidslabel met inhoudsmarkering toe**

Gebruik [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/nl/net/aspose.slides/isensitivitylabelcollection/add/) met de label‑identificator, site‑identificator, ingeschakelde status en toewijzingsmethode. Nadat de methode het nieuwe [ISensitivityLabel](https://reference.aspose.com/slides/nl/net/aspose.slides/isensitivitylabel/) heeft geretourneerd, voeg je de vereiste markeringswaarden toe via [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/nl/net/aspose.slides/isensitivitylabel/contentmarktypes/).

Het volgende voorbeeld voegt een handmatig geselecteerd label toe dat is gekoppeld aan voettekst‑ en watermerk‑markeringen, en slaat vervolgens het resultaat op als PPTX:

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

## **Werk een gevoeligheidslabel bij**

De eigenschappen van [ISensitivityLabel](https://reference.aspose.com/slides/nl/net/aspose.slides/isensitivitylabel/) zijn lees‑/schrijfbaar, behalve dat de collectie die door [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/nl/net/aspose.slides/isensitivitylabel/contentmarktypes/) wordt geretourneerd, wordt gewijzigd via de lijstbewerkingen. Nadat het gewenste label is gevonden, kun je de identificator, site‑identificator, ingeschakelde status, toewijzingsmethode, verwijderingsstatus en inhoudsmarkeringstypen bijwerken. Sla de presentatie op om de wijzigingen te behouden.

Het volgende voorbeeld werkt de ingeschakelde status en toewijzingsmethode van het eerste label bij:

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

## **Markeer een gevoeligheidslabel als verwijderd**

Om het feit te behouden dat een label is verwijderd, zoek je het label en stel je [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/nl/net/aspose.slides/isensitivitylabel/isremoved/) in op `true`. Dit behoudt de label‑vermelding terwijl de verwijderingsstatus wordt vastgelegd. Als je in plaats daarvan een vermelding uit de moderne collectie moet verwijderen, gebruik dan [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/nl/net/aspose.slides/isensitivitylabelcollection/removeat/); gebruik [ISensitivityLabelCollection.Clear](https://reference.aspose.com/slides/nl/net/aspose.slides/isensitivitylabelcollection/clear/) om elke vermelding te verwijderen.

Het volgende voorbeeld markeert een specifiek label als verwijderd en slaat de bijgewerkte presentatie op:

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

## **Lees en migreer legacy MIP gevoeligheidslabels**

Ouder‑MIP‑gebaseerde workflows kunnen metadata van gevoeligheidslabels opslaan in aangepaste document‑eigenschappen in plaats van in de moderne labelcollectie. Lees die metadata met [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/nl/net/aspose.slides/idocumentproperties/getsensitivitylabels/). De methode parseert de legacy‑aangepaste eigenschappen en retourneert een array van [ISensitivityLabel](https://reference.aspose.com/slides/nl/net/aspose.slides/isensitivitylabel/)‑objecten.

Om de metadata te migreren, voeg je elk geretourneerd label toe aan de moderne [ISensitivityLabelCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/isensitivitylabelcollection/) via [ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/nl/net/aspose.slides/isensitivitylabelcollection/add/). Omdat het toevoegen van een dubbele label‑identificator een uitzondering veroorzaakt, controleert het voorbeeld de bestemmingscollectie voordat elk label wordt gekopieerd. Je kunt extra validatie toevoegen om te bevestigen dat elk legacy‑label nog steeds bestaat in het huidige Purview‑beleid.

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

De migratie kopieert de geparseerde label‑objecten naar de moderne collectie. Het is niet nodig om alle aangepaste document‑eigenschappen te wissen, zodat niet‑gerelateerde documentmetadata intact blijft. Gebruik [IPresentation.Save](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentation/save/) met [SaveFormat.Pptx](https://reference.aspose.com/slides/nl/net/aspose.slides.export/saveformat/) om de moderne labelmetadata naar een PPTX‑bestand te schrijven.

## **Veelgestelde vragen**

**Voegt het toevoegen van een inhoudsmarkeringstype een zichtbaar kop‑, voet‑ of watermerk toe aan de dia's?**

Nee. De waarden die via [ISensitivityLabel.ContentMarkTypes](https://reference.aspose.com/slides/nl/net/aspose.slides/isensitivitylabel/contentmarktypes/) worden toegevoegd, beschrijven de markeringen die bij het gevoeligheidslabel horen. Ze creëren geen zichtbare tekst of vormen in de presentatie. Voeg de overeenkomstige dia‑inhoud apart toe als uw workflow die markeringen moet weergeven.

**Wat is het verschil tussen een label markeren als verwijderd en het verwijderen uit de collectie?**

Het instellen van [ISensitivityLabel.IsRemoved](https://reference.aspose.com/slides/nl/net/aspose.slides/isensitivitylabel/isremoved/) op `true` behoudt de labelvermelding en registreert de verwijderingsstatus. Het aanroepen van [ISensitivityLabelCollection.RemoveAt](https://reference.aspose.com/slides/nl/net/aspose.slides/isensitivitylabelcollection/removeat/) verwijdert de vermelding uit de moderne collectie. Kies de bewerking die overeenkomt met de metadata‑bewaringsvereisten van uw organisatie.

**Kan een presentatie zowel legacy‑MIP‑metadata als moderne gevoeligheidslabels bevatten?**

Ja. Legacy‑labels kunnen in aangepaste document‑eigenschappen blijven staan, terwijl moderne labels beschikbaar zijn via [Presentation.SensitivityLabels](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/sensitivitylabels/). Gebruik [IDocumentProperties.GetSensitivityLabels](https://reference.aspose.com/slides/nl/net/aspose.slides/idocumentproperties/getsensitivitylabels/) om de legacy‑metadata te lezen en migreer alleen de geldige labels die nog niet in de moderne collectie aanwezig zijn.

**Wat gebeurt er wanneer een label met dezelfde identificator meer dan één keer wordt toegevoegd?**

[ISensitivityLabelCollection.Add](https://reference.aspose.com/slides/nl/net/aspose.slides/isensitivitylabelcollection/add/) veroorzaakt een `ArgumentException` wanneer de collectie al een label met dezelfde identificator bevat. Controleer bestaande [ISensitivityLabel.Id](https://reference.aspose.com/slides/nl/net/aspose.slides/isensitivitylabel/id/)‑waarden voordat u labels toevoegt of migreert.

**Welk uitvoerformaat moet worden gebruikt om bijgewerkte gevoeligheidslabels te behouden?**

Sla de presentatie op als PPTX door [IPresentation.Save](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentation/save/) aan te roepen met [SaveFormat.Pptx](https://reference.aspose.com/slides/nl/net/aspose.slides.export/saveformat/), zoals getoond in de voorbeelden hierboven.