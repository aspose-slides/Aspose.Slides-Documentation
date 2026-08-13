---
title: Presentaties opslaan in alleen-lezen-modus met Java
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
description: "Laad en sla PowerPoint-bestanden (PPT, PPTX) op in alleen-lezen-modus met Aspose.Slides for Java, en biedt nauwkeurige dia-voorbeelden zonder uw presentaties te wijzigen."
---
## **Inleiding**

In PowerPoint 2019 heeft Microsoft de instelling **Altijd als Alleen-lezen openen** geïntroduceerd als een van de opties die gebruikers kunnen gebruiken om hun presentaties te beschermen. U wilt deze Alleen-lezen‑instelling wellicht gebruiken om een presentatie te beschermen wanneer

- U per ongeluk bewerkingen wilt voorkomen en de inhoud van uw presentatie veilig wilt houden.  
- U wil aangeven dat de door u geleverde presentatie de definitieve versie is.  

Nadat u de optie **Altijd als Alleen-lezen openen** voor een presentatie hebt geselecteerd, zien gebruikers bij het openen van de presentatie de **Alleen-lezen**‑aanbeveling en krijgen ze mogelijk een bericht in de volgende vorm: *Om per ongeluk wijzigingen te voorkomen, heeft de auteur dit bestand ingesteld om als Alleen-lezen te openen.*

De Alleen-lezen‑aanbeveling is een eenvoudige maar effectieve afschrikmiddel die bewerken ontmoedigt omdat gebruikers een handeling moeten uitvoeren om het te verwijderen voordat ze een presentatie mogen bewerken. Als u niet wilt dat gebruikers wijzigingen aanbrengen in een presentatie en dit op een nette manier wilt aangeven, kan de Alleen-lezen‑aanbeveling een goede optie voor u zijn.  

> Als een presentatie met de **Alleen-lezen**‑bescherming wordt geopend in een oudere Microsoft PowerPoint‑applicatie – die de recent geïntroduceerde functie niet ondersteunt – wordt de **Alleen-lezen**‑aanbeveling genegeerd (de presentatie wordt normaal geopend).

## **Alleen-lezen‑modus toepassen**

Aspose.Slides for Java stelt u in staat een presentatie **Alleen-lezen** te maken, wat betekent dat gebruikers (nadat ze de presentatie hebben geopend) de **Alleen-lezen**‑aanbeveling zien. Deze voorbeeldcode laat zien hoe u een presentatie **Alleen-lezen** maakt in Java met Aspose.Slides:

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

**Opmerking**: De **Alleen-lezen**‑aanbeveling is bedoeld om bewerken te ontmoedigen of gebruikers te verhinderen per ongeluk wijzigingen aan te brengen in een PowerPoint‑presentatie. Als een gemotiveerde persoon – die weet wat hij doet – besluit uw presentatie te bewerken, kan hij de Alleen-lezen‑instelling gemakkelijk verwijderen. Als u echt ongeautoriseerde bewerkingen wilt voorkomen, bent u beter af met [strengere beschermingen die encryptie en wachtwoorden omvatten](https://docs.aspose.com/slides/nl/java/password-protected-presentation/). 

{{% /alert %}} 

## **FAQ**

### Hoe verschilt ‘Alleen-lezen aanbevolen’ van volledige wachtwoordbeveiliging?

‘Alleen-lezen aanbevolen’ toont slechts een suggestie om het bestand in de alleen-lezen‑modus te openen en is makkelijk te omzeilen. [Wachtwoordbeveiliging](/slides/nl/java/password-protected-presentation/) beperkt daadwerkelijk het openen of bewerken en is geschikt wanneer u echte beveiligingsmaatregelen nodig heeft.

### Kan ‘Alleen-lezen aanbevolen’ gecombineerd worden met watermerken om bewerkingen verder te ontmoedigen?

Ja. De aanbeveling kan worden gecombineerd met [watermerken](/slides/nl/java/watermark/) als visueel afschrikmiddel; ze zijn aparte mechanismen en werken goed samen.

### Kan een macro of extern hulpmiddel het bestand nog steeds wijzigen wanneer de aanbeveling is ingeschakeld?

Ja. De aanbeveling blokkeert geen programmaticale wijzigingen. Gebruik [wachtwoorden en encryptie](/slides/nl/java/password-protected-presentation/) om geautomatiseerde bewerkingen te voorkomen.

### Hoe verhoudt ‘Alleen-lezen aanbevolen’ zich tot de methoden ‘isEncrypted’ en ‘isWriteProtected’?

Het zijn verschillende signalen. ‘Alleen-lezen aanbevolen’ is een zachte, optionele prompt; [isWriteProtected](https://reference.aspose.com/slides/nl/java/com.aspose.slides/protectionmanager/#isWriteProtected--) en [isEncrypted](https://reference.aspose.com/slides/nl/java/com.aspose.slides/protectionmanager/#isEncrypted--) geven echte schrijf‑ of leestoegangbeperkingen aan die afhangen van wachtwoorden of encryptie.