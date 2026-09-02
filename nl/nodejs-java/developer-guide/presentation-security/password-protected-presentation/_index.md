---
title: Beveilig presentaties met wachtwoorden in JavaScript
linktitle: Wachtwoordbeveiliging
type: docs
weight: 20
url: /nl/nodejs-java/password-protected-presentation/
keywords:
- PowerPoint vergrendelen
- presentatie vergrendelen
- PowerPoint ontgrendelen
- presentatie ontgrendelen
- PowerPoint beveiligen
- presentatie beveiligen
- wachtwoord instellen
- wachtwoord toevoegen
- PowerPoint versleutelen
- presentatie versleutelen
- PowerPoint ontsleutelen
- presentatie ontsleutelen
- schrijfbescherming
- PowerPoint beveiliging
- presentatie beveiliging
- wachtwoord verwijderen
- beveiliging verwijderen
- versleuteling verwijderen
- wachtwoord uitschakelen
- beveiliging uitschakelen
- schrijfbescherming verwijderen
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Vergrendel en ontgrendel moeiteloos wachtwoord-beveiligde PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor Node.js via Java. Beveilig uw presentaties."
---
## **Inleiding**

Wanneer je een presentatie met een wachtwoord beveiligt, stel je een wachtwoord in dat bepaalde beperkingen oplegt aan de presentatie. Om de beperkingen op te heffen, moet het wachtwoord worden ingevoerd. Een presentatie met wachtwoordbeveiliging wordt beschouwd als een vergrendelde presentatie.

Doorgaans kun je een wachtwoord instellen om deze beperkingen op een presentatie af te dwingen:

- **Bewerken**

  Als je wilt dat alleen bepaalde gebruikers je presentatie kunnen bewerken, kun je een bewerkingsbeperking instellen. Deze beperking voorkomt dat mensen de inhoud van je presentatie kunnen wijzigen, aanpassen of kopiëren (tenzij ze het wachtwoord invoeren). 

  In dit geval kan een gebruiker, zelfs zonder het wachtwoord, je document wel openen. In de alleen‑lezen‑modus kan de gebruiker de inhoud – hyperlinks, animaties, effecten en andere elementen – bekijken, maar hij kan geen items kopiëren of de presentatie opslaan. 

- **Openen**

  Als je wilt dat alleen bepaalde gebruikers je presentatie kunnen openen, kun je een openingsbeperking instellen. Deze beperking voorkomt dat mensen de inhoud van je presentatie kunnen zien (tenzij ze het wachtwoord invoeren).

  Technisch gezien voorkomt de openingsbeperking ook dat gebruikers je presentaties aanpassen: wanneer mensen een presentatie niet kunnen openen, kunnen ze deze niet wijzigen. 
  
  **Opmerking** dat wanneer je een presentatie met een wachtwoord beveiligt om te voorkomen dat deze wordt geopend, het presentatiebestand versleuteld wordt.

## **Hoe een presentatie online met een wachtwoord beveiligen**

1. Ga naar onze [**Aspose.Slides Lock**](https://products.aspose.app/slides/nl/lock) pagina. 

   ![todo:image_alt_text](slides-lock.png)

2. Klik op **Drop or upload your files**.

3. Selecteer het bestand dat je wilt beveiligen met een wachtwoord op je computer. 

4. Voer je gewenste wachtwoord in voor bewerkingsbeveiliging; voer je gewenste wachtwoord in voor weergavebeveiliging. 

5. Als je wilt dat gebruikers je presentatie zien als de definitieve versie, vink dan het **Mark as final** selectievakje aan.

6. Klik op **PROTECT NOW.** 

7. Klik op **DOWNLOAD NOW.**

## **Wachtwoordbeveiliging voor presentaties in Aspose.Slides**
**Ondersteunde formaten**

Aspose.Slides ondersteunt wachtwoordbeveiliging, versleuteling en vergelijkbare bewerkingen voor presentaties in de volgende formaten: 

- PPTX and PPT - Microsoft PowerPoint Presentation 
- ODP - OpenDocument Presentation 
- OTP -  OpenDocument Presentation Template 

**Ondersteunde bewerkingen**

Aspose.Slides stelt je in staat om wachtwoordbeveiliging te gebruiken om wijzigingen in presentaties te voorkomen op de volgende manieren:

- Een presentatie versleutelen
- Schrijfbescherming instellen voor een presentatie

**Andere bewerkingen**

Aspose.Slides stelt je in staat om andere taken met betrekking tot wachtwoordbeveiliging en versleuteling uit te voeren op de volgende manieren:

- Een presentatie ontsleutelen; een versleutelde presentatie openen
- Versleuteling verwijderen; wachtwoordbeveiliging uitschakelen
- Schrijfbescherming van een presentatie verwijderen
- De eigenschappen van een versleutelde presentatie opvragen
- Controleren of een presentatie versleuteld is
- Controleren of een presentatie met een wachtwoord beveiligd is.

## **Een presentatie versleutelen**

Je kunt een presentatie versleutelen door een wachtwoord in te stellen. Vervolgens moet een gebruiker het wachtwoord invoeren om de vergrendelde presentatie te wijzigen. 

Om een presentatie te versleutelen of met een wachtwoord te beveiligen, moet je de encrypt‑methode (van [ProtectionManager](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ProtectionManager)) gebruiken om een wachtwoord voor de presentatie in te stellen. Je geeft het wachtwoord door aan de encrypt‑methode en gebruikt de save‑methode om de nu versleutelde presentatie op te slaan.

Deze voorbeeldcode laat zien hoe je een presentatie kunt versleutelen:

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

## **Schrijfbescherming instellen voor een presentatie**

Je kunt een markering “Do not modify” aan een presentatie toevoegen. Op deze manier kun je gebruikers laten weten dat je niet wilt dat ze wijzigingen aanbrengen in de presentatie.  

**Opmerking** dat het proces van schrijfbescherming de presentatie niet versleutelt. Gebruikers – als ze dat willen – kunnen de presentatie wel wijzigen, maar om de wijzigingen op te slaan moeten ze de presentatie onder een andere naam opslaan. 

Om schrijfbescherming in te stellen, moet je de [setWriteProtection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ProtectionManager#setWriteProtection-java.lang.String-) methode gebruiken. Deze voorbeeldcode laat zien hoe je schrijfbescherming aan een presentatie toevoegt:

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

Aspose.Slides maakt het mogelijk om een versleuteld bestand te laden door het wachtwoord door te geven. Om een presentatie te ontsleutelen, moet je de [removeEncryption](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ProtectionManager#removeEncryption--) methode aanroepen zonder parameters. Vervolgens moet je het juiste wachtwoord invoeren om de presentatie te laden.

Deze voorbeeldcode laat zien hoe je een presentatie ontsleutelt: 

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("123123");
var presentation = new aspose.slides.Presentation("pres.pptx", loadOptions);
try {
    // werk met ontcijferde presentatie
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Versleuteling verwijderen; wachtwoordbeveiliging uitschakelen**

Je kunt de versleuteling of wachtwoordbeveiliging van een presentatie verwijderen. Op deze manier kunnen gebruikers de presentatie zonder beperkingen openen of wijzigen. 

Om versleuteling of wachtwoordbeveiliging te verwijderen, moet je de [removeEncryption](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ProtectionManager#removeEncryption--) methode aanroepen. Deze voorbeeldcode laat zien hoe je de versleuteling van een presentatie verwijdert:

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

## **Schrijfbescherming van een presentatie verwijderen**

Je kunt Aspose.Slides gebruiken om de schrijfbescherming van een presentatiedocument te verwijderen. Op deze manier kunnen gebruikers wijzigen zoals ze willen – zonder waarschuwingen bij dergelijke handelingen.

Je kunt de schrijfbescherming van een presentatie verwijderen met de [removeWriteProtection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ProtectionManager#removeWriteProtection--) methode. Deze voorbeeldcode laat zien hoe je de schrijfbescherming van een presentatie verwijdert:

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

## **Eigenschappen van een versleutelde presentatie opvragen**

Gebruikers hebben vaak moeite om de document‑eigenschappen van een versleutelde of met een wachtwoord beveiligde presentatie op te halen. Aspose.Slides biedt echter een mechanisme waarmee je een presentatie kunt beveiligen met een wachtwoord terwijl gebruikers toch toegang houden tot de eigenschappen.

**Opmerking:** Standaard worden bij het versleutelen van een presentatie de document‑eigenschappen ook met een wachtwoord beveiligd. Als je wilt dat de document‑eigenschappen toegankelijk blijven na versleuteling, biedt Aspose.Slides precies die mogelijkheid.

Als je wilt dat gebruikers de eigenschappen van een versleutelde presentatie kunnen bekijken, geef dan `false` door aan `setEncryptDocumentProperties` op [ProtectionManager](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/protectionmanager/). Deze voorbeeldcode laat zien hoe je een presentatie versleutelt terwijl je gebruikers toch toegang geeft tot de document‑eigenschappen:

```javascript
const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Alleen document‑eigenschappen laden vanuit een versleutelde presentatie**

Om de metadata van een versleutelde presentatie te inspecteren zonder de dia’s of andere inhoud te laden, maak je een [LoadOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/loadoptions/) object aan en geef je `true` door aan `setOnlyLoadDocumentProperties`. In deze modus negeert Aspose.Slides het wachtwoord en laadt alleen de publiek toegankelijke document‑eigenschappen.

De volgende codevoorbeelden lezen ingebouwde en aangepaste document‑eigenschappen via `getDocumentProperties` op [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/):

```javascript
const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

const presentation = new aspose.slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    const documentProperties = presentation.getDocumentProperties();

    // Lees ingebouwde documenteigenschappen.
    console.log("Title: " + documentProperties.getTitle());
    console.log("Author: " + documentProperties.getAuthor());

    // Lees aangepaste documenteigenschappen.
    const customPropertyCount = documentProperties.getCountOfCustomProperties();

    for (let propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++) {
        const propertyName = documentProperties.getCustomPropertyName(propertyIndex);
        const propertyValue = documentProperties.get_Item(propertyName);

        console.log(propertyName + ": " + propertyValue);
    }
} finally {
    presentation.dispose();
}
```

Deze workflow werkt alleen wanneer de document‑eigenschappen **niet** versleuteld zijn (publiek) op het moment dat de presentatie wordt versleuteld. Als de document‑eigenschappen versleuteld zijn, leidt het doorgeven van `true` aan `LoadOptions.setOnlyLoadDocumentProperties` tot een uitzondering, omdat het wachtwoord in deze modus wordt genegeerd. Om versleutelde document‑eigenschappen op te halen of de volledige presentatie (inclusief dia’s en andere inhoud) te laden, moet je het juiste wachtwoord opgeven via `LoadOptions.setPassword` op [LoadOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/loadoptions/).

## **Controleren of een presentatie met een wachtwoord is beveiligd vóór het laden**

Voordat je een presentatie laadt, wil je wellicht controleren of de presentatie niet met een wachtwoord is beveiligd. Op die manier kun je fouten en soortgelijke problemen vermijden die zich voordoen wanneer een wachtwoord‑beveiligde presentatie zonder wachtwoord wordt geladen.

Deze JavaScript‑code laat zien hoe je een presentatie kunt onderzoeken om te zien of deze met een wachtwoord is beveiligd (zonder de presentatie zelf te laden):

```javascript
var presentationInfo = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("example.pptx");
console.log("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Controleren of een presentatie versleuteld is**

Aspose.Slides maakt het mogelijk om te controleren of een presentatie versleuteld is. Hiervoor kun je de [isEncrypted](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ProtectionManager#isEncrypted--) eigenschap gebruiken, die `true` retourneert als de presentatie versleuteld is of `false` als de presentatie niet versleuteld is.

Deze voorbeeldcode laat zien hoe je kunt controleren of een presentatie versleuteld is:

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

## **Controleren of een presentatie schrijfbeschermd is**

Aspose.Slides maakt het mogelijk om te controleren of een presentatie schrijfbeschermd is. Hiervoor kun je de [isWriteProtected](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ProtectionManager#isWriteProtected--) eigenschap gebruiken, die `true` retourneert als de presentatie versleuteld is of `false` als de presentatie niet versleuteld is.

Deze voorbeeldcode laat zien hoe je kunt controleren of een presentatie schrijfbeschermd is:

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

## **Valideren of bevestigen dat een specifiek wachtwoord is gebruikt om een presentatie te beschermen**

Je wilt mogelijk controleren en bevestigen dat een bepaald wachtwoord is gebruikt om een presentatiedocument te beschermen. Aspose.Slides biedt de mogelijkheid om een wachtwoord te valideren. 

Deze voorbeeldcode laat zien hoe je een wachtwoord kunt valideren:

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

Hij retourneert `true` als de presentatie is versleuteld met het opgegeven wachtwoord. Anders retourneert hij `false`. 

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/nl/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Welke encryptiemethoden ondersteunt Aspose.Slides?**

Aspose.Slides ondersteunt moderne encryptiemethoden, inclusief op AES gebaseerde algoritmen, waardoor een hoog beveiligingsniveau voor je presentaties wordt gegarandeerd.

**Wat gebeurt er als een onjuist wachtwoord wordt ingevoerd bij het openen van een presentatie?**

Er wordt een uitzondering opgegooid als een onjuist wachtwoord wordt gebruikt, waardoor je wordt gewaarschuwd dat de toegang tot de presentatie wordt geweigerd. Dit helpt onbevoegde toegang te voorkomen en beschermt de inhoud van de presentatie.

**Zijn er prestatie‑implicaties bij het werken met wachtwoord‑beveiligde presentaties?**

Het encryptie‑ en decryptie‑proces kan een lichte overhead met zich meebrengen tijdens het openen en opslaan. In de meeste gevallen is deze prestatie‑impact minimaal en heeft het geen significante invloed op de totale verwerkingstijd van je presentatietaken.