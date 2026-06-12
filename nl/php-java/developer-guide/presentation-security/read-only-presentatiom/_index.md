---
title: Presentaties opslaan in Alleen-lezen modus met PHP
linktitle: Alleen-lezen presentatie
type: docs
weight: 30
url: /nl/php-java/read-only-presentation/
keywords:
- alleen-lezen
- presentatie beveiligen
- bewerken voorkomen
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Laad en bewaar PowerPoint‑bestanden (PPT, PPTX) in alleen-lezen modus met Aspose.Slides voor PHP, en biedt nauwkeurige dia‑voorbeelden zonder uw presentaties te wijzigen."
---
## **Inleiding**

In PowerPoint 2019 heeft Microsoft de **Always Open Read-Only**‑instelling geïntroduceerd als een van de opties die gebruikers kunnen gebruiken om hun presentaties te beveiligen. U wilt deze Alleen-lezen‑instelling mogelijk gebruiken om een presentatie te beschermen wanneer

- u accidentele bewerkingen wilt voorkomen en de inhoud van uw presentatie veilig wilt houden. 
- u mensen wilt laten weten dat de door u geleverde presentatie de eindversie is. 

Nadat u de optie **Always Open Read-Only** voor een presentatie heeft geselecteerd, zien gebruikers bij het openen van de presentatie de **Read-Only**‑aanbeveling en kan er een bericht verschijnen in de volgende vorm: *Om accidentele wijzigingen te voorkomen, heeft de auteur dit bestand ingesteld om als alleen-lezen te openen.*

De **Read-Only**‑aanbeveling is een eenvoudige maar doeltreffende afschrikmiddel dat bewerken ontmoedigt, omdat gebruikers eerst een handeling moeten uitvoeren om deze te verwijderen voordat ze de presentatie mogen bewerken. Als u niet wilt dat gebruikers wijzigingen aanbrengen in een presentatie en dit op een beleefde manier wilt communiceren, kan de **Read-Only**‑aanbeveling een goede optie voor u zijn. 

> Als een presentatie met de **Read-Only**‑bescherming wordt geopend in een oudere versie van Microsoft PowerPoint – die de recent geïntroduceerde functie niet ondersteunt – wordt de **Read-Only**‑aanbeveling genegeerd (de presentatie wordt normaal geopend).

## **Alleen-lezen‑modus toepassen**

Aspose.Slides for PHP via Java stelt u in staat een presentatie **Read-Only** te maken, zodat gebruikers (nadat ze de presentatie hebben geopend) de **Read-Only**‑aanbeveling zien. Deze voorbeeldcode laat zien hoe u een presentatie **Read-Only** maakt met Aspose.Slides:

```php
  $pres = new Presentation();
  try {
    $pres->getProtectionManager()->setReadOnlyRecommended(true);
    $pres->save("ReadOnlyPresentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 

**Opmerking**: De **Read-Only**‑aanbeveling is uitsluitend bedoeld om bewerken te ontmoedigen of gebruikers te weerhouden van accidentele wijzigingen in een PowerPoint‑presentatie. Als een gemotiveerd persoon – die weet wat hij doet – besluit uw presentatie te bewerken, kan hij de Alleen-lezen‑instelling makkelijk verwijderen. Als u echt ongeautoriseerde bewerkingen moet voorkomen, bent u beter af met [meer strenge beveiligingen die encrypties en wachtwoorden omvatten](https://docs.aspose.com/slides/nl/php-java/password-protected-presentation/).

{{% /alert %}} 

## **FAQ**

**Hoe verschilt ‘Read-Only recommended’ van volledige wachtwoordbeveiliging?**

‘Read-Only recommended’ toont alleen een suggestie om het bestand in alleen-lezen‑modus te openen en is eenvoudig te omzeilen. [Password protection](/slides/nl/php-java/password-protected-presentation/) beperkt daadwerkelijk het openen of bewerken en is geschikt wanneer u echte beveiligingscontroles nodig heeft.

**Kan ‘Read-Only recommended’ worden gecombineerd met watermerken om bewerkingen nog meer te ontmoedigen?**

Ja. De aanbeveling kan worden gecombineerd met [watermarks](/slides/nl/php-java/watermark/) als visueel afschrikmiddel; ze zijn afzonderlijke mechanismen en werken goed samen.

**Kan een macro of extern hulpmiddel het bestand nog steeds wijzigen wanneer de aanbeveling is ingeschakeld?**

Ja. De aanbeveling blokkeert geen programmatische wijzigingen. Om geautomatiseerde bewerkingen te voorkomen, gebruikt u [passwords and encryption](/slides/nl/php-java/password-protected-presentation/).

**Hoe verhoudt ‘Read-Only recommended’ zich tot de methoden ‘isEncrypted’ en ‘isWriteProtected’?**

Het zijn verschillende signalen. ‘Read-Only recommended’ is een zachte, optionele prompt; [isWriteProtected](https://reference.aspose.com/slides/nl/php-java/aspose.slides/protectionmanager/iswriteprotected/) en [isEncrypted](https://reference.aspose.com/slides/nl/php-java/aspose.slides/protectionmanager/isencrypted/) geven daadwerkelijke schrijf‑ of leesbeperkingen aan die afhankelijk zijn van wachtwoorden of encryptie.