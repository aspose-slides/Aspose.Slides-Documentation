---
title: Presentaties opslaan in Alleen-lezen-modus op Android
linktitle: Alleen-lezen-presentatie
type: docs
weight: 30
url: /nl/androidjava/read-only-presentation/
keywords:
- alleen-lezen
- presentatie beveiligen
- bewerken voorkomen
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Sla PowerPoint-bestanden (PPT, PPTX) op in alleen-lezen-modus met Aspose.Slides voor Android via Java, met nauwkeurige dia-voorbeelden zonder uw presentaties te wijzigen."
---
## **Inleiding**

In PowerPoint 2019 heeft Microsoft de instelling **Always Open Read-Only** geïntroduceerd als een van de opties die gebruikers kunnen gebruiken om hun presentaties te beveiligen. U wilt deze Read-Only‑instelling wellicht gebruiken om een presentatie te beschermen wanneer

- u per ongeluk wijzigingen wilt voorkomen en de inhoud van uw presentatie veilig wilt houden.  
- u wilt aangeven dat de presentatie die u hebt geleverd de definitieve versie is.  

Nadat u de optie **Always Open Read-Only** voor een presentatie hebt gekozen, zien gebruikers bij het openen van de presentatie de **Read-Only**‑aanbeveling en krijgen ze eventueel de volgende melding te zien: *Om per ongeluk wijzigingen te voorkomen, heeft de auteur dit bestand ingesteld om als alleen-lezen te openen.*

De Read-Only‑aanbeveling is een eenvoudige maar effectieve afschrikking die bewerken ontmoedigt, omdat gebruikers eerst een handeling moeten uitvoeren om deze te verwijderen voordat ze de presentatie mogen bewerken. Als u niet wilt dat gebruikers wijzigingen aanbrengen in een presentatie en dit op een beleefde manier wilt communiceren, kan de Read-Only‑aanbeveling een goede optie voor u zijn.  

> Als een presentatie met **Read-Only**‑beveiliging wordt geopend in een oudere Microsoft PowerPoint‑applicatie die de recent geïntroduceerde functie niet ondersteunt, wordt de **Read-Only**‑aanbeveling genegeerd (de presentatie wordt normaal geopend).

## **Read-Only‑modus toepassen**

Aspose.Slides for Android via Java stelt u in staat om een presentatie **Read-Only** te maken, zodat gebruikers (nadat ze de presentatie hebben geopend) de **Read-Only**‑aanbeveling zien. Deze voorbeeldcode laat zien hoe u een presentatie **Read-Only** maakt in Java met Aspose.Slides:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getProtectionManager().setReadOnlyRecommended(true);
    pres.save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}} 

**Opmerking**: De **Read-Only**‑aanbeveling is uitsluitend bedoeld om bewerken te ontmoedigen of om gebruikers te behoeden voor onbedoelde wijzigingen in een PowerPoint‑presentatie. Als een gemotiveerde persoon—die weet wat hij doet—beslist uw presentatie te bewerken, kan hij de Read-Only‑instelling gemakkelijk verwijderen. Als u serieus ongeautoriseerde bewerking wilt voorkomen, kunt u beter gebruikmaken van [strengerere beveiligingen die encryptie en wachtwoorden omvatten](https://docs.aspose.com/slides/nl/androidjava/password-protected-presentation/).

{{% /alert %}} 

## **FAQ**

### Hoe verschilt ‘Read-Only recommended’ van volledige wachtwoordbeveiliging?

‘Read-Only recommended’ toont alleen een suggestie om het bestand in alleen-lezen‑modus te openen en is eenvoudig te omzeilen. [Wachtwoordbeveiliging](/slides/nl/androidjava/password-protected-presentation/) beperkt daadwerkelijk het openen of bewerken en is geschikt wanneer u echte beveiligingscontroles nodig heeft.

### Kan ‘Read-Only recommended’ gecombineerd worden met watermerken om bewerkingen verder af te schrikken?

Ja. De aanbeveling kan worden gecombineerd met [watermerken](/slides/nl/androidjava/watermark/) als een visuele afschrikking; het zijn afzonderlijke mechanismen die goed samenwerken.

### Kan een macro of extern hulpmiddel het bestand nog steeds wijzigen wanneer de aanbeveling is ingeschakeld?

Ja. De aanbeveling blokkeert geen programmatische wijzigingen. Gebruik [wachtwoorden en encryptie](/slides/nl/androidjava/password-protected-presentation/) om geautomatiseerde bewerkingen te voorkomen.

### Hoe verhoudt ‘Read-Only recommended’ zich tot de methoden ‘isEncrypted’ en ‘isWriteProtected’?

Het zijn verschillende signalen. ‘Read-Only recommended’ is een zachte, optionele prompt; [isWriteProtected](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/protectionmanager/#isWriteProtected--) en [isEncrypted](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/protectionmanager/#isEncrypted--) geven daadwerkelijke schrijf‑ of leembeperkingen aan die afhankelijk zijn van wachtwoorden of encryptie.