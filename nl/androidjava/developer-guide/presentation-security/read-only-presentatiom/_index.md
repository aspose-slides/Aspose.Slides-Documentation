---
title: Presentaties opslaan in alleen-lezen modus op Android
linktitle: Alleen-lezen presentatie
type: docs
weight: 30
url: /nl/androidjava/read-only-presentation/
keywords:
- alleen-lezen
- presentatie beschermen
- bewerken voorkomen
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Sla PowerPoint-bestanden (PPT, PPTX) op in alleen-lezen modus met Aspose.Slides for Android via Java, waarbij nauwkeurige dia‑voorbeelden worden geboden zonder uw presentaties te wijzigen."
---
## **Introductie**

In PowerPoint 2019 heeft Microsoft de instelling **Always Open Read-Only** geïntroduceerd als een van de opties die gebruikers kunnen gebruiken om hun presentaties te beschermen. Je wilt deze Read-Only‑instelling misschien gebruiken om een presentatie te beschermen wanneer

- Je wilt per ongeluk bewerken voorkomen en de inhoud van je presentatie veilig houden. 
- Je wilt mensen laten weten dat de presentatie die je hebt aangeleverd de definitieve versie is. 

Nadat je de optie **Always Open Read-Only** voor een presentatie hebt geselecteerd, zien gebruikers bij het openen van de presentatie de **Read-Only**‑aanbeveling en kunnen ze een bericht in de volgende vorm zien: *Om onopzettelijke wijzigingen te voorkomen, heeft de auteur dit bestand ingesteld om als alleen-lezen te worden geopend.*

De Read-Only‑aanbeveling is een eenvoudige maar effectieve afschrikmiddel die bewerken ontmoedigt, omdat gebruikers een handeling moeten uitvoeren om het te verwijderen voordat ze een presentatie mogen bewerken. Als je niet wilt dat gebruikers wijzigingen aanbrengen in een presentatie en dit op een beleefde manier wilt aangeven, dan kan de Read-Only‑aanbeveling een goede optie voor je zijn. 

> Als een presentatie met **Read-Only**‑bescherming wordt geopend in een oudere Microsoft PowerPoint‑toepassing—die de recent geïntroduceerde functie niet ondersteunt—wordt de **Read-Only**‑aanbeveling genegeerd (de presentatie wordt normaal geopend).

## **Read-Only‑modus toepassen**

Aspose.Slides for Android via Java stelt je in staat om een presentatie op **Read-Only** te zetten, wat betekent dat gebruikers (nadat ze de presentatie hebben geopend) de **Read-Only**‑aanbeveling zien. Deze voorbeeldcode laat zien hoe je een presentatie op **Read-Only** zet in Java met behulp van Aspose.Slides:

```java
Presentation pres = new Presentation();
try {
    pres.getProtectionManager().setReadOnlyRecommended(true);
    pres.save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 

**Opmerking**: De **Read-Only**‑aanbeveling is bedoeld om bewerken te ontmoedigen of te voorkomen dat gebruikers per ongeluk wijzigingen aanbrengen in een PowerPoint‑presentatie. Als een gemotiveerde persoon—die weet wat hij doet—beslist je presentatie te bewerken, kan hij de Read-Only‑instelling gemakkelijk verwijderen. Als je echt ongeautoriseerd bewerken wilt voorkomen, kun je beter gebruikmaken van [strengere beveiligingen die versleuteling en wachtwoorden omvatten](https://docs.aspose.com/slides/nl/androidjava/password-protected-presentation/).

{{% /alert %}} 

## **FAQ**

**Hoe verschilt 'Read-Only recommended' van volledige wachtwoordbeveiliging?**

'Read-Only recommended' toont alleen een suggestie om het bestand in alleen-lezen-modus te openen en is gemakkelijk te omzeilen. [Wachtwoordbeveiliging](/slides/nl/androidjava/password-protected-presentation/) beperkt het openen of bewerken daadwerkelijk en is geschikt wanneer je echte beveiligingsmaatregelen nodig hebt.

**Kan 'Read-Only recommended' gecombineerd worden met watermerken om bewerken nog meer te ontmoedigen?**

Ja. De aanbeveling kan worden gekoppeld aan [watermerken](/slides/nl/androidjava/watermark/) als visueel afschrikmiddel; ze zijn afzonderlijke mechanismen en werken goed samen.

**Kan een macro of extern hulpmiddel het bestand nog steeds aanpassen wanneer de aanbeveling is ingeschakeld?**

Ja. De aanbeveling blokkeert geen programmatische wijzigingen. Om automatische bewerkingen te voorkomen, gebruik [wachtwoorden en versleuteling](/slides/nl/androidjava/password-protected-presentation/).

**Hoe verhoudt 'Read-Only recommended' zich tot de methoden 'isEncrypted' en 'isWriteProtected'?**

Het zijn verschillende signalen. 'Read-Only recommended' is een zachte, optionele prompt; [isWriteProtected](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/protectionmanager/#isWriteProtected--) en [isEncrypted](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/protectionmanager/#isEncrypted--) geven daadwerkelijke schrijf‑ of leestoegangbeperkingen aan die afhankelijk zijn van wachtwoorden of versleuteling.