---
title: Opslaan van presentaties in alleen-lezen-modus met Java
linktitle: Alleen-lezen presentatie
type: docs
weight: 30
url: /nl/java/read-only-presentation/
keywords:
- alleen-lezen
- presentatie beschermen
- bewerken voorkomen
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Laad en sla PowerPoint-bestanden (PPT, PPTX) op in alleen-lezen-modus met Aspose.Slides for Java, met precieze dia-voorbeelden zonder je presentaties te wijzigen."
---
## **Introductie**

In PowerPoint 2019 heeft Microsoft de instelling **Always Open Read-Only** geïntroduceerd als een van de opties die gebruikers kunnen gebruiken om hun presentaties te beschermen. Je wilt deze Read‑Only‑instelling misschien gebruiken om een presentatie te beveiligen wanneer

- je per ongeluk bewerkingen wilt voorkomen en de inhoud van je presentatie veilig wilt houden.  
- je wilt aangeven dat de presentatie die je hebt geleverd de definitieve versie is.  

Nadat je de optie **Always Open Read-Only** voor een presentatie hebt geselecteerd, zien gebruikers bij het openen van de presentatie de aanbeveling **Read-Only** en kan er een bericht verschijnen in de volgende vorm: *Om per ongeluk wijzigingen te voorkomen, heeft de auteur dit bestand ingesteld om als read‑only te worden geopend.*

De Read‑Only‑aanbeveling is een eenvoudige maar effectieve afschrikmiddel die bewerken ontmoedigt omdat gebruikers eerst een handeling moeten uitvoeren om deze te verwijderen voordat ze de presentatie mogen bewerken. Als je niet wilt dat gebruikers wijzigingen aanbrengen in een presentatie en dit op een beleefde manier wilt communiceren, dan kan de Read‑Only‑aanbeveling een goede optie voor je zijn.

> Als een presentatie met de **Read-Only**‑bescherming wordt geopend in een oudere Microsoft PowerPoint‑toepassing — die de recent geïntroduceerde functie niet ondersteunt — wordt de **Read-Only**‑aanbeveling genegeerd (de presentatie wordt normaal geopend).

## **Read‑Only‑modus toepassen**

Aspose.Slides for Java stelt je in staat een presentatie **Read-Only** te maken, zodat gebruikers (nadat ze de presentatie hebben geopend) de **Read-Only**‑aanbeveling zien. Deze voorbeeldcode laat zien hoe je een presentatie **Read-Only** maakt in Java met Aspose.Slides:

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

**Opmerking**: De **Read-Only**‑aanbeveling is bedoeld om bewerken te ontmoedigen of om gebruikers te waarschuwen tegen per accidentele wijzigingen in een PowerPoint‑presentatie. Als een gemotiveerde persoon — die precies weet wat hij doet — besluit jouw presentatie te bewerken, kan hij de Read‑Only‑instelling eenvoudig verwijderen. Als je echt ongeautoriseerd bewerken moet voorkomen, kun je beter [meer strengere beveiligingen die encrypties en wachtwoorden omvatten](https://docs.aspose.com/slides/nl/java/password-protected-presentation/). 

{{% /alert %}} 

## **Veelgestelde vragen**

**Hoe verschilt ‘Read‑Only aanbevolen’ van volledige wachtwoordbeveiliging?**

‘Read‑Only aanbevolen’ toont slechts een suggestie om het bestand in read‑only modus te openen en is gemakkelijk te omzeilen. [Wachtwoordbeveiliging](/slides/nl/java/password-protected-presentation/) beperkt daadwerkelijk het openen of bewerken en is geschikt wanneer je echte beveiligingsmaatregelen nodig hebt.

**Kan ‘Read‑Only aanbevolen’ worden gecombineerd met watermerken om bewerkingen verder te ontmoedigen?**

Ja. De aanbeveling kan worden gekoppeld aan [watermerken](/slides/nl/java/watermark/) als visueel afschrikmiddel; ze zijn afzonderlijke mechanismen en werken goed samen.

**Kan een macro of extern hulpprogramma het bestand nog steeds wijzigen wanneer de aanbeveling is ingeschakeld?**

Ja. De aanbeveling blokkeert geen programmatologische wijzigingen. Gebruik [wachtwoorden en encryptie](/slides/nl/java/password-protected-presentation/) om geautomatiseerde bewerkingen te voorkomen.

**Hoe verhoudt ‘Read‑Only aanbevolen’ zich tot de methoden ‘isEncrypted’ en ‘isWriteProtected’?**

Het zijn verschillende signalen. ‘Read‑Only aanbevolen’ is een zachte, optionele prompt; [isWriteProtected](https://reference.aspose.com/slides/nl/java/com.aspose.slides/protectionmanager/#isWriteProtected--) en [isEncrypted](https://reference.aspose.com/slides/nl/java/com.aspose.slides/protectionmanager/#isEncrypted--) geven daadwerkelijke schrijfrestricties of leesbeperkingen aan die afhankelijk zijn van wachtwoorden of encryptie.