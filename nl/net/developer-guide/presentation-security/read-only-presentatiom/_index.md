---
title: Presentaties opslaan in alleen-lezen modus in .NET
linktitle: Alleen-lezen presentatie
type: docs
weight: 30
url: /nl/net/read-only-presentation/
keywords:
- alleen-lezen
- presentatie beschermen
- bewerken voorkomen
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "PowerPoint-bestanden (PPT, PPTX) laden en opslaan in alleen-lezen modus met Aspose.Slides voor .NET, waardoor nauwkeurige dia-voorbeelden worden geboden zonder uw presentaties te wijzigen."
---
## **Inleiding**

In PowerPoint 2019 heeft Microsoft de instelling **Always Open Read-Only** geïntroduceerd als een van de opties die gebruikers kunnen gebruiken om hun presentaties te beschermen. Je wilt deze Read-Only‑instelling misschien gebruiken om een presentatie te beschermen wanneer

- Je wilt voorkomen dat er per ongeluk wijzigingen worden aangebracht en de inhoud van je presentatie veilig houden. 
- Je wilt aangeven dat de presentatie die je hebt geleverd de definitieve versie is. 

Nadat je de optie **Always Open Read-Only** voor een presentatie hebt geselecteerd, zien gebruikers bij het openen van de presentatie de aanbeveling **Read-Only** en kunnen ze een bericht in de volgende vorm zien: *Om onbedoelde wijzigingen te voorkomen, heeft de auteur dit bestand ingesteld om als alleen-lezen te worden geopend.*

De aanbeveling **Read-Only** is een eenvoudige maar effectieve afschrikmiddel die bewerken ontmoedigt omdat gebruikers een handeling moeten uitvoeren om deze te verwijderen voordat ze de presentatie mogen bewerken. Als je niet wilt dat gebruikers wijzigingen aanbrengen in een presentatie en dit op een beleefde manier wilt aangeven, dan kan de aanbeveling **Read-Only** een goede optie voor je zijn. 

> Als een presentatie met de **Read-Only**‑bescherming wordt geopend in een oudere Microsoft PowerPoint‑applicatie – die de recent geïntroduceerde functie niet ondersteunt – wordt de **Read-Only**‑aanbeveling genegeerd (de presentatie wordt normaal geopend).

## **Read‑Only‑modus toepassen**

Aspose.Slides for .NET stelt je in staat een presentatie op **Read-Only** te zetten, wat betekent dat gebruikers (nadat ze de presentatie hebben geopend) de aanbeveling **Read-Only** zien. Deze voorbeeldcode toont hoe je een presentatie op **Read-Only** zet in C# met Aspose.Slides:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    pres.ProtectionManager.ReadOnlyRecommended = true;
    pres.Save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert color="info" %}} 

**Opmerking**: De **Read-Only**‑aanbeveling is bedoeld om bewerken te ontmoedigen of gebruikers te weerhouden van per ongeluk wijzigingen aan te brengen in een PowerPoint‑presentatie. Als een gemotiveerde persoon – die weet wat hij doet – besluit je presentatie te bewerken, kan hij gemakkelijk de Read‑Only‑instelling verwijderen. Als je echt moet voorkomen dat onbevoegd wordt bewerkt, kun je beter gebruikmaken van [more stringent protections that involve encryptions and passwords](https://docs.aspose.com/slides/nl/net/password-protected-presentation/). 

{{% /alert %}} 

## **FAQ**

### Hoe verschilt 'Read-Only recommended' van volledige wachtwoordbeveiliging?

'Read-Only recommended' toont slechts een suggestie om het bestand in alleen-lezen modus te openen en is gemakkelijk te omzeilen. [Password protection](/slides/nl/net/password-protected-presentation/) beperkt daadwerkelijk het openen of bewerken en is geschikt wanneer je echte beveiligingscontroles nodig hebt.

### Kan 'Read-Only recommended' gecombineerd worden met watermerken om bewerken verder te ontmoedigen?

Ja. De aanbeveling kan worden gecombineerd met [watermarks](/slides/nl/net/watermark/) als een visueel afschrikmiddel; ze zijn afzonderlijke mechanismen en werken goed samen.

### Kan een macro of extern hulpmiddel het bestand nog steeds wijzigen wanneer de aanbeveling is ingeschakeld?

Ja. De aanbeveling blokkeert geen programmatische wijzigingen. Om geautomatiseerde bewerkingen te voorkomen, gebruik [passwords and encryption](/slides/nl/net/password-protected-presentation/).

### Hoe verhoudt 'Read-Only recommended' zich tot de vlaggen 'IsEncrypted' en 'IsWriteProtected'?

Ze zijn verschillende signalen. 'Read-Only recommended' is een zachte, optionele prompt; [IsWriteProtected](https://reference.aspose.com/slides/nl/net/aspose.slides/protectionmanager/iswriteprotected/) en [IsEncrypted](https://reference.aspose.com/slides/nl/net/aspose.slides/protectionmanager/isencrypted/) geven daadwerkelijke schrijf‑ of leesbeperkingen aan die afhankelijk zijn van wachtwoorden of encryptie.