---
title: "Presentaties beveiligen met wachtwoorden in JavaScript"
linktitle: "Wachtwoordbeveiliging"
type: docs
weight: 20
url: /nl/nodejs-java/password-protected-presentation/
keywords:
- vergrendel PowerPoint
- vergrendel presentatie
- ontgrendel PowerPoint
- ontgrendel presentatie
- bescherm PowerPoint
- bescherm presentatie
- wachtwoord instellen
- wachtwoord toevoegen
- versleutel PowerPoint
- versleutel presentatie
- ontsleutel PowerPoint
- ontsleutel presentatie
- schrijfbeveiliging
- PowerPoint-beveiliging
- presentatiebeveiliging
- wachtwoord verwijderen
- beveiliging verwijderen
- versleuteling verwijderen
- wachtwoord uitschakelen
- beveiliging uitschakelen
- schrijfbeveiliging verwijderen
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Vergrendel en ontgrendel moeiteloos wachtwoordbeveiligde PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor Node.js via Java. Bescherm uw presentaties."
---
## **Inleiding**

Wanneer u een presentatie met een wachtwoord beveiligt, stelt u een wachtwoord in dat bepaalde beperkingen op de presentatie afdwingt. Om de beperkingen te verwijderen, moet het wachtwoord worden ingevoerd. Een met wachtwoord beveiligde presentatie wordt beschouwd als een vergrendelde presentatie.

Meestal kunt u een wachtwoord instellen om deze beperkingen op een presentatie af te dwingen:

- **Wijziging**

  Als u wilt dat alleen bepaalde gebruikers uw presentatie mogen wijzigen, kunt u een wijzigingsbeperking instellen. Deze beperking voorkomt dat mensen de presentatie wijzigen, aanpassen of kopiëren (tenzij ze het wachtwoord invoeren). 

  In dit geval kan een gebruiker echter, zelfs zonder wachtwoord, wel uw document openen. In de alleen‑lezen‑modus kan de gebruiker de inhoud – hyperlinks, animaties, effecten en andere elementen – binnen uw presentatie bekijken, maar hij kan geen items kopiëren of de presentatie opslaan. 

- **Openen**

  Als u wilt dat alleen bepaalde gebruikers uw presentatie mogen openen, kunt u een openingsbeperking instellen. Deze beperking voorkomt dat mensen de inhoud van uw presentatie kunnen bekijken (tenzij ze het wachtwoord invoeren).

  Technisch gezien voorkomt de openingsbeperking ook dat gebruikers de presentatie wijzigen: wanneer mensen een presentatie niet kunnen openen, kunnen ze deze niet aanpassen of wijzigen. 
  
  **Opmerking** dat wanneer u een presentatie met een wachtwoord beveiligt om openen te voorkomen, het presentatiebestand wordt versleuteld.

## **Een presentatie online met wachtwoord beveiligen**

1. Ga naar onze [**Aspose.Slides Lock**](https://products.aspose.app/slides/nl/lock)‑pagina. 

   ![todo:image_alt_text](slides-lock.png)

2. Klik op **Drop or upload your files**.

3. Selecteer het bestand dat u op uw computer wilt beveiligen met een wachtwoord. 

4. Voer uw gewenste wachtwoord in voor bewerkingsbeveiliging; voer uw gewenste wachtwoord in voor weergave‑beveiliging. 

5. Als u wilt dat gebruikers uw presentatie zien als het definitieve exemplaar, schakelt u het selectievak **Mark as final** in.

6. Klik op **PROTECT NOW.** 

7. Klik op **DOWNLOAD NOW.**

## **Wachtwoordbeveiliging voor presentaties in Aspose.Slides**
**Ondersteunde formaten**

Aspose.Slides ondersteunt wachtwoordbeveiliging, versleuteling en vergelijkbare bewerkingen voor presentaties in de volgende formaten: 

- PPTX en PPT – Microsoft PowerPoint‑presentatie 
- ODP – OpenDocument‑presentatie 
- OTP – OpenDocument‑presentatiesjabloon 

**Ondersteunde bewerkingen**

Aspose.Slides stelt u in staat om wachtwoordbeveiliging op presentaties toe te passen om wijzigingen te voorkomen op de volgende manieren:

- Een presentatie versleutelen
- Een schrijfbeveiliging instellen voor een presentatie

**Andere bewerkingen**

Aspose.Slides biedt de mogelijkheid om andere taken met betrekking tot wachtwoordbeveiliging en versleuteling uit te voeren op de volgende manieren:

- Een presentatie ontsleutelen; een versleutelde presentatie openen
- Versleuteling verwijderen; wachtwoordbeveiliging uitschakelen
- Schrijfbeveiliging van een presentatie verwijderen
- De eigenschappen van een versleutelde presentatie opvragen
- Controleren of een presentatie versleuteld is
- Controleren of een presentatie met wachtwoord beveiligd is.

## **Een presentatie versleutelen**

U kunt een presentatie versleutelen door een wachtwoord in te stellen. Vervolgens moet een gebruiker het wachtwoord invoeren om de vergrendelde presentatie te wijzigen. 

Om een presentatie te versleutelen of met wachtwoord te beveiligen, moet u de encrypt‑methode gebruiken (van [ProtectionManager](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ProtectionManager)) om een wachtwoord voor de presentatie in te stellen. U geeft het wachtwoord door aan de encrypt‑methode en gebruikt vervolgens de save‑methode om de nu versleutelde presentatie op te slaan.

Deze voorbeeldcode laat zien hoe u een presentatie versleutelt:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Schrijfbeveiliging instellen voor een presentatie**

U kunt een markering “Niet wijzigen” aan een presentatie toevoegen. Op deze manier kunt u gebruikers duidelijk maken dat u niet wilt dat ze wijzigingen aanbrengen in de presentatie.  

**Opmerking** dat het proces van schrijfbeveiliging de presentatie niet versleutelt. Gebruikers – als ze dat willen – kunnen de presentatie wel wijzigen, maar om de wijzigingen op te slaan moeten ze een presentatie met een andere naam aanmaken. 

Om een schrijfbeveiliging in te stellen, moet u de [setWriteProtection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ProtectionManager#setWriteProtection-java.lang.String-)‑methode gebruiken. Deze voorbeeldcode laat zien hoe u een schrijfbeveiliging voor een presentatie instelt:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Een presentatie ontsleutelen; een versleutelde presentatie openen**

Aspose.Slides stelt u in staat een versleuteld bestand te laden door het wachtwoord door te geven. Om een presentatie te ontsleutelen, roept u de [removeEncryption](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ProtectionManager#removeEncryption--)‑methode aan zonder parameters. Vervolgens moet u het juiste wachtwoord invoeren om de presentatie te laden.

Deze voorbeeldcode laat zien hoe u een presentatie ontsleutelt: 

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("123123");
var presentation = new aspose.slides.Presentation("pres.pptx", loadOptions);
try {
    // werk met ontsleutelde presentatie
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Versleuteling verwijderen; wachtwoordbeveiliging uitschakelen**

U kunt de versleuteling of wachtwoordbeveiliging van een presentatie verwijderen. Op deze manier kunnen gebruikers de presentatie zonder beperkingen openen of wijzigen. 

Om versleuteling of wachtwoordbeveiliging te verwijderen, roept u de [removeEncryption](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ProtectionManager#removeEncryption--)‑methode aan. Deze voorbeeldcode laat zien hoe u versleuteling van een presentatie verwijdert:

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("123123");
var presentation = new aspose.slides.Presentation("pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Schrijfbeveiliging van een presentatie verwijderen**

U kunt Aspose.Slides gebruiken om de schrijfbeveiliging van een presentatiedocument te verwijderen. Op deze manier kunnen gebruikers wijzigen zoals ze willen – zonder waarschuwingen bij het uitvoeren van dergelijke handelingen.

U verwijdert de schrijfbeveiliging van een presentatie met de [removeWriteProtection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ProtectionManager#removeWriteProtection--)‑methode. Deze voorbeeldcode laat zien hoe u de schrijfbeveiliging van een presentatie verwijdert:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **De eigenschappen van een versleutelde presentatie opvragen**

Gebruikers hebben vaak moeite om de document‑eigenschappen van een versleutelde of met wachtwoord beveiligde presentatie op te vragen. Aspose.Slides biedt echter een mechanisme waarmee u een presentatie kunt beveiligen en tegelijkertijd gebruikers de mogelijkheid geeft de eigenschappen van die presentatie te benaderen.

**Opmerking** dat wanneer Aspose.Slides een presentatie versleutelt, de document‑eigenschappen van de presentatie standaard ook met wachtwoord worden beveiligd. Maar als u de eigenschappen van de presentatie toegankelijk wilt maken (zelfs nadat de presentatie is versleuteld), biedt Aspose.Slides precies die functionaliteit. 

Wilt u dat gebruikers de mogelijkheid behouden om de eigenschappen van een door u versleutelde presentatie te benaderen, stelt u de [encryptDocumentProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ProtectionManager#getEncryptDocumentProperties--)‑eigenschap in op `true`. Deze voorbeeldcode laat zien hoe u een presentatie versleutelt en tegelijk gebruikers toegang geeft tot de document‑eigenschappen:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(true);
    presentation.getProtectionManager().encrypt("123123");
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Controleren of een presentatie met een wachtwoord beveiligd is vóór het laden**

Voordat u een presentatie laadt, wilt u wellicht controleren of de presentatie niet met een wachtwoord is beveiligd. Op deze manier voorkomt u fouten en soortgelijke problemen die ontstaan wanneer een met wachtwoord beveiligde presentatie zonder wachtwoord wordt geladen.

Deze JavaScript‑code laat zien hoe u een presentatie kunt onderzoeken om te zien of deze met een wachtwoord beveiligd is (zonder de presentatie zelf te laden):

```javascript
var presentationInfo = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("example.pptx");
console.log("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Controleren of een presentatie versleuteld is**

Aspose.Slides stelt u in staat om te controleren of een presentatie versleuteld is. Hiervoor kunt u de [isEncrypted](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ProtectionManager#isEncrypted--)‑eigenschap gebruiken, die `true` teruggeeft als de presentatie versleuteld is en `false` als dat niet zo is.

Deze voorbeeldcode toont hoe u controleert of een presentatie versleuteld is:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    var isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Controleren of een presentatie schrijfbeveiligd is**

Aspose.Slides maakt het mogelijk om te controleren of een presentatie schrijfbeveiligd is. Hiervoor kunt u de [isWriteProtected](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ProtectionManager#isWriteProtected--)‑eigenschap gebruiken, die `true` teruggeeft als de presentatie versleuteld is en `false` als dat niet zo is.

Deze voorbeeldcode laat zien hoe u controleert of een presentatie schrijfbeveiligd is:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    var isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Valideren of bevestigen dat een specifiek wachtwoord is gebruikt om een presentatie te beveiligen**

U wilt wellicht controleren en bevestigen dat een specifiek wachtwoord is gebruikt om een presentatiedocument te beveiligen. Aspose.Slides biedt de middelen om een wachtwoord te valideren. 

Deze voorbeeldcode laat zien hoe u een wachtwoord valideert:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    // controleer of "pass" overeenkomt met
    var isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

Het resultaat is `true` als de presentatie is versleuteld met het opgegeven wachtwoord. Anders is het `false`. 

{{% alert color="primary" title="Zie ook" %}} 
- [Digitale handtekening in PowerPoint](/slides/nl/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Welke versleutelingsmethoden ondersteunt Aspose.Slides?**

Aspose.Slides ondersteunt moderne versleutelingsmethoden, waaronder AES‑gebaseerde algoritmen, waardoor een hoog beveiligingsniveau voor uw presentaties wordt gegarandeerd.

**Wat gebeurt er als een onjuist wachtwoord wordt ingevoerd bij het openen van een presentatie?**

Er wordt een uitzondering opgegooid als een onjuist wachtwoord wordt gebruikt, waarmee wordt aangegeven dat de toegang tot de presentatie wordt geweigerd. Dit helpt ongeautoriseerde toegang te voorkomen en beschermt de inhoud van de presentatie.

**Zijn er prestatie‑implicaties bij het werken met met wachtwoord beveiligde presentaties?**

Het versleutelings‑ en ontsleutelingsproces kan een lichte overhead veroorzaken tijdens het openen en opslaan. In de meeste gevallen is de impact minimaal en heeft deze geen significante invloed op de totale verwerkingstijd van uw presentatietaken.