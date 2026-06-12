---
title: Presentaties opslaan in alleen-lezen-modus met JavaScript
linktitle: Alleen-lezen-presentatie
type: docs
weight: 30
url: /nl/nodejs-java/read-only-presentation/
keywords:
- alleen lezen
- presentatie beschermen
- bewerken voorkomen
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Laad en sla PowerPoint-bestanden op in alleen-lezen-modus met Aspose.Slides voor Node.js via Java, waardoor nauwkeurige dia-voorbeelden worden geboden zonder uw presentaties te wijzigen."
---
## **Inleiding**

In PowerPoint 2019 heeft Microsoft de instelling **Altijd lezen‑alleen openen** geïntroduceerd als een van de opties die gebruikers kunnen gebruiken om hun presentaties te beschermen. U wilt deze lezen‑alleen‑instelling mogelijk gebruiken om een presentatie te beschermen wanneer

- U per ongeluk bewerkingen wilt voorkomen en de inhoud van uw presentatie veilig wilt houden. 
- U mensen wilt laten weten dat de door u aangeleverde presentatie de definitieve versie is. 

Nadat u de optie **Altijd lezen‑alleen openen** voor een presentatie hebt geselecteerd, zien gebruikers bij het openen van de presentatie de aanbeveling **Lezen‑alleen** en mogelijk een bericht in de volgende vorm: *Om onbedoelde wijzigingen te voorkomen, heeft de auteur dit bestand ingesteld om als lezen‑alleen te worden geopend.*

De aanbeveling **Lezen‑alleen** is een eenvoudige maar effectieve afschrikmiddel die bewerken ontmoedigt, omdat gebruikers een handeling moeten uitvoeren om deze te verwijderen voordat ze de presentatie mogen bewerken. Als u niet wilt dat gebruikers wijzigingen aanbrengen in een presentatie en dit op een beleefde manier wilt communiceren, kan de aanbeveling **Lezen‑alleen** een goede optie voor u zijn. 

> Als een presentatie met de **Lezen‑alleen**‑beveiliging wordt geopend in een oudere Microsoft PowerPoint‑toepassing—die de recent geïntroduceerde functie niet ondersteunt—wordt de aanbeveling **Lezen‑alleen** genegeerd (de presentatie wordt normaal geopend).

## **Lezen‑alleen‑modus toepassen**

Aspose.Slides for Node.js via Java stelt u in staat een presentatie **Lezen‑alleen** te maken, waardoor gebruikers (nadat ze de presentatie hebben geopend) de aanbeveling **Lezen‑alleen** zien. Deze voorbeeldcode laat zien hoe u een presentatie **Lezen‑alleen** maakt in JavaScript met Aspose.Slides:

```javascript
var pres = new aspose.slides.Presentation();
try {
    pres.getProtectionManager().setReadOnlyRecommended(true);
    pres.save("ReadOnlyPresentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" %}} 

**Opmerking**: De aanbeveling **Lezen‑alleen** is bedoeld om bewerken te ontmoedigen of gebruikers te weerhouden van onbedoelde wijzigingen in een PowerPoint‑presentatie. Als een gemotiveerde persoon—die weet wat die doet—beslist uw presentatie te bewerken, kan hij of zij de Lezen‑alleen‑instelling eenvoudig verwijderen. Als u serieus ongeautoriseerd bewerken moet voorkomen, kunt u beter gebruikmaken van [meer stringente bescherming die encryptie en wachtwoorden omvatten](https://docs.aspose.com/slides/nl/nodejs-java/password-protected-presentation/).

{{% /alert %}} 

## **FAQ**

**Hoe verschilt ‘Lezen‑alleen aanbevolen’ van volledige wachtwoordbeveiliging?**

‘Lezen‑alleen aanbevolen’ toont alleen een suggestie om het bestand in lezen‑alleen‑modus te openen en is makkelijk te omzeilen. [Wachtwoordbeveiliging](/slides/nl/nodejs-java/password-protected-presentation/) beperkt het openen of bewerken daadwerkelijk en is geschikt wanneer u echte beveiligingsmaatregelen nodig heeft.

**Kan ‘Lezen‑alleen aanbevolen’ worden gecombineerd met watermerken om bewerkingen nog meer te ontmoedigen?**

Ja. De aanbeveling kan worden gekoppeld aan [watermerken](/slides/nl/nodejs-java/watermark/) als een visueel afschrikmiddel; ze zijn afzonderlijke mechanismen en werken goed samen.

**Kan een macro of extern hulpmiddel het bestand nog steeds wijzigen wanneer de aanbeveling is ingeschakeld?**

Ja. De aanbeveling blokkeert geen programmatische wijzigingen. Gebruik [wachtwoorden en encryptie](/slides/nl/nodejs-java/password-protected-presentation/) om geautomatiseerde bewerkingen te voorkomen.

**Hoe verhoudt ‘Lezen‑alleen aanbevolen’ zich tot de vlaggen ‘IsEncrypted’ en ‘IsWriteProtected’?**

Het zijn verschillende signalen. ‘Lezen‑alleen aanbevolen’ is een zachte, optionele prompt; [isWriteProtected](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/protectionmanager/iswriteprotected/) en [isEncrypted](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/protectionmanager/isencrypted/) duiden op daadwerkelijke schrijf‑ of leesrestricties die afhankelijk zijn van wachtwoorden of encryptie.