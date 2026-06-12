---
title: Presentaties opslaan in alleen-lezen modus in .NET
linktitle: Alleen-lezen presentatie
type: docs
weight: 30
url: /nl/net/read-only-presentation/
keywords:
- alleen-lezen
- presentatie beveiligen
- bewerken voorkomen
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Laad en sla PowerPoint-bestanden (PPT, PPTX) op in alleen-lezen modus met Aspose.Slides voor .NET, waardoor nauwkeurige dia-voorvertoningen mogelijk zijn zonder uw presentaties te wijzigen."
---
## **Inleiding**

In PowerPoint 2019 heeft Microsoft de instelling **Altijd openen als alleen-lezen** geïntroduceerd als een van de opties die gebruikers kunnen gebruiken om hun presentaties te beschermen. Je wilt deze Alleen-lezen‑instelling wellicht gebruiken om een presentatie te beveiligen wanneer

- Je per ongeluk bewerken wilt voorkomen en de inhoud van je presentatie veilig wilt houden.  
- Je wilt aangeven dat de presentatie die je hebt verstrekt de definitieve versie is.  

Nadat je de optie **Altijd openen als alleen-lezen** voor een presentatie hebt geselecteerd, zien gebruikers bij het openen van de presentatie de **Alleen-lezen**‑aanbeveling en mogelijk een bericht in de volgende vorm: *Om per ongeluk wijzigingen te voorkomen, heeft de auteur dit bestand ingesteld om als alleen-lezen te worden geopend.*

De Alleen-lezen‑aanbeveling is een eenvoudige maar doeltreffende afschrikker die bewerken ontmoedigt, omdat gebruikers eerst een handeling moeten verrichten om deze te verwijderen voordat ze de presentatie mogen bewerken. Als je niet wilt dat gebruikers wijzigingen aanbrengen in een presentatie en dit op een beleefde manier wilt communiceren, dan kan de Alleen-lezen‑aanbeveling een goede optie voor je zijn.  

> Als een presentatie met de **Alleen-lezen**‑beveiliging wordt geopend in een oudere versie van Microsoft PowerPoint — die de recent geïntroduceerde functie niet ondersteunt — wordt de **Alleen-lezen**‑aanbeveling genegeerd (de presentatie wordt normaal geopend).

## **Alleen-lezen‑modus toepassen**

Aspose.Slides voor .NET stelt je in staat een presentatie **Alleen-lezen** te maken, waardoor gebruikers (nadat ze de presentatie hebben geopend) de **Alleen-lezen**‑aanbeveling zien. Deze voorbeeldcode laat zien hoe je een presentatie **Alleen-lezen** maakt in C# met Aspose.Slides:

```c#
using (Presentation pres = new Presentation())
{
    pres.ProtectionManager.ReadOnlyRecommended = true;
    pres.Save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}} 

**Opmerking**: De **Alleen-lezen**‑aanbeveling is enkel bedoeld om bewerken te ontmoedigen of gebruikers te weerhouden van onbedoelde wijzigingen aan een PowerPoint‑presentatie. Als een gemotiveerde persoon — die weet wat hij doet — beslist je presentatie te bewerken, kan hij de Alleen-lezen‑instelling eenvoudig verwijderen. Als je echt ongeautoriseerde bewerkingen moet voorkomen, kun je beter gebruikmaken van [strengere beveiligingen die encryptie en wachtwoorden omvatten](https://docs.aspose.com/slides/nl/net/password-protected-presentation/). 

{{% /alert %}} 

## **FAQ**

**Hoe verschilt ‘Alleen-lezen aanbevolen’ van volledige wachtwoordbeveiliging?**

‘Alleen-lezen aanbevolen’ toont alleen een suggestie om het bestand in de alleen-lezen‑modus te openen en is gemakkelijk te omzeilen. [Wachtwoordbeveiliging](/slides/nl/net/password-protected-presentation/) beperkt daadwerkelijk het openen of bewerken en is geschikt wanneer je echte beveiligingscontroles nodig hebt.

**Kan ‘Alleen-lezen aanbevolen’ worden gecombineerd met watermerken om bewerkingen verder te ontmoedigen?**

Ja. De aanbeveling kan worden gekoppeld aan [watermerken](/slides/nl/net/watermark/) als visuele afschrikking; ze zijn aparte mechanismen en werken goed samen.

**Kan een macro of extern gereedschap het bestand nog steeds wijzigen wanneer de aanbeveling is ingeschakeld?**

Ja. De aanbeveling blokkeert geen programmatiche wijzigingen. Gebruik [wachtwoorden en encryptie](/slides/nl/net/password-protected-presentation/) om geautomatiseerde bewerkingen te voorkomen.

**Hoe verhoudt ‘Alleen-lezen aanbevolen’ zich tot de vlaggen ‘IsEncrypted’ en ‘IsWriteProtected’?**

Het zijn verschillende signalen. ‘Alleen-lezen aanbevolen’ is een zachte, optionele prompt; [IsWriteProtected](https://reference.aspose.com/slides/nl/net/aspose.slides/protectionmanager/iswriteprotected/) en [IsEncrypted](https://reference.aspose.com/slides/nl/net/aspose.slides/protectionmanager/isencrypted/) duiden op daadwerkelijke schrijf‑ of leembeperkingen die afhangen van wachtwoorden of encryptie.