---
title: Wachtwoordbeveiligde presentaties in JavaScript
linktitle: Wachtwoordbeveiliging
type: docs
weight: 20
url: /nl/nodejs-java/password-protected-presentation/
keywords:
- wachtwoordbeveiligde presentatie
- openingswachtwoord
- PowerPoint versleutelen
- PowerPoint ontsleutelen
- presentatiewachtwoord valideren
- presentatiewachtwoord controleren
- versleutelde presentatie openen
- versleuteling verwijderen
- PowerPoint
- PPT
- PPTX
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Versleutel, detecteer, valideer, open en ontsleutel wachtwoordbeveiligde PowerPoint PPT‑ en PPTX‑presentaties in JavaScript met Aspose.Slides."
---
## **Overzicht**

Een openings‑wachtwoord versleutelt een presentatie. Het juiste wachtwoord is vereist om de presentatie‑inhoud te laden en weer te geven, waardoor deze bescherming vertrouwelijkheid biedt.

Een openings‑wachtwoord verschilt van een schrijf‑beveiligingswachtwoord. Schrijfbescherming beperkt bewerken maar versleutelt de inhoud niet en voorkomt niet dat de presentatie wordt geladen. Zie voor het beheren van wachtwoorden voor het wijzigen van presentaties [Presentaties met alleen schrijfbeveiliging](/slides/nl/nodejs-java/write-protected-presentation/).

De workflows hieronder gelden voor zowel PPT‑ als PPTX‑presentaties. De voorbeelden gebruiken beide formaten wanneer hun bestand‑gebaseerde en stream‑gebaseerde gedrag belangrijk is.

## **Een presentatie versleutelen met een openings‑wachtwoord**

Gebruik [ProtectionManager.encrypt](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/protectionmanager/#encrypt) om een openings‑wachtwoord toe te wijzen. Gebruik vervolgens [Presentation.save](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#save) om de versleutelde presentatie op te slaan.

Het volgende voorbeeld versleutelt een PPTX‑presentatie:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("encrypted-pres.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Documenteigenschappen openbaar houden**

Standaard neemt Aspose.Slides documenteigenschappen op in de versleuteling van een presentatie. De methode [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) regelt dit gedrag onafhankelijk van de versleuteling van de dia‑inhoud. Geef `false` door vóór het aanroepen van [ProtectionManager.encrypt](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/protectionmanager/#encrypt) wanneer een indexerings‑, classificatie‑, zoek‑ of document‑beheersysteem metadata moet kunnen lezen zonder het openings‑wachtwoord.

Het volgende voorbeeld maakt een versleutelde PPTX‑presentatie terwijl de ingebouwde documenteigenschappen openbaar blijven:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const properties = presentation.getDocumentProperties();
    properties.setAuthor("Contoso Knowledge Management");
    properties.setTitle("Quarterly Product Roadmap");
    properties.setKeywords("roadmap, planning, internal");

    presentation.getSlides().get_Item(0).setName("Encrypted presentation content");
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("public-properties-encrypted.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het doorgeven van `false` aan [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) maakt niet de dia’s, masters, lay‑outs, vormen, media of andere presentatiedoelen openbaar. Het beïnvloedt alleen documenteigenschappen. Zie [Presentatie‑eigenschappen beheren](/slides/nl/nodejs-java/presentation-properties/) om die eigenschappen zonder het laden van de versleutelde inhoud te lezen.

## **Een versleutelde presentatie laden**

Stel [LoadOptions.setPassword](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/loadoptions/#setPassword) in op het openings‑wachtwoord en geef de opties door aan [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) bij het laden van het bestand. Het laden mislukt wanneer een openings‑wachtwoord vereist is maar het opgegeven wachtwoord ontbreekt of onjuist is.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    // Werk met de ontcijferde presentatie.
} finally {
    presentation.dispose();
}
```

## **Versleuteling van een presentatie verwijderen**

Laad de presentatie met het openings‑wachtwoord, roep [ProtectionManager.removeEncryption](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/protectionmanager/#removeEncryption) aan en sla het resultaat op. De opgeslagen presentatie kan daarna zonder wachtwoord worden geladen.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Een openings‑wachtwoord valideren vóór het laden**

Gebruik [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) om [PresentationInfo](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentationinfo/) te verkrijgen zonder een volledige presentaties instantie te maken. Controleer [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) voordat u een wachtwoord vraagt of valideert. Wanneer bescherming aanwezig is, valideer dan de opgegeven waarde met [PresentationInfo.checkPassword](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentationinfo/#checkPassword).

### **Bestandspad‑workflow**

Het volgende voorbeeld valideert een openings‑wachtwoord voor een PPTX‑bestand, geeft de gevalideerde waarde door aan [LoadOptions.setPassword](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/loadoptions/#setPassword) en laadt vervolgens de volledige presentatie:

```javascript
const slides = require("aspose.slides.via.java");

const filePath = "protected-presentation.pptx";
const password = "open_password";
const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo(filePath);

if (!presentationInfo.isPasswordProtected()) {
    console.log("The presentation does not have an opening password.");
} else if (!presentationInfo.checkPassword(password)) {
    console.log("The opening password is incorrect.");
} else {
    const loadOptions = new slides.LoadOptions();
    loadOptions.setPassword(password);

    const presentation = new slides.Presentation(filePath, loadOptions);
    try {
        console.log("The presentation was validated and loaded successfully.");
    } finally {
        presentation.dispose();
    }
}
```

### **Stream‑workflow**

Gebruik [PresentationFactory.getPresentationInfoFromStream](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfoFromStream) om een Node.js‑leesbare stream te inspecteren. Nadat de inspectiestream is verbruikt, maak een nieuwe stream voordat u de volledige presentatie laadt met [Presentation.createPresentationFromStream](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#createPresentationFromStream).

Het volgende voorbeeld gebruikt een PPT‑bestand:

```javascript
const slides = require("aspose.slides.via.java");
const fs = require("fs");

const filePath = "protected-presentation.ppt";
const password = "open_password";
const presentationFactory = slides.PresentationFactory.getInstance();
const infoStream = fs.createReadStream(filePath);

slides.PresentationFactory.getPresentationInfoFromStream(presentationFactory, infoStream, function(infoError, presentationInfo) {
    if (infoError) {
        console.log("The presentation information could not be read: " + infoError.message);
    } else if (!presentationInfo.isPasswordProtected()) {
        console.log("The presentation does not have an opening password.");
    } else if (!presentationInfo.checkPassword(password)) {
        console.log("The opening password is incorrect.");
    } else {
        const loadOptions = new slides.LoadOptions();
        loadOptions.setPassword(password);
        const presentationStream = fs.createReadStream(filePath);

        slides.Presentation.createPresentationFromStream(presentationStream, loadOptions, function(loadError, presentation) {
            if (loadError) {
                console.log("The presentation could not be loaded: " + loadError.message);
            } else {
                try {
                    console.log("The presentation was validated and loaded successfully.");
                } finally {
                    presentation.dispose();
                }
            }
        });
    }
});
```

### **Terugkeerwaarden van checkPassword**

[PresentationInfo.checkPassword](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentationinfo/#checkPassword) retourneert `true` alleen wanneer de presentatie een openings‑wachtwoord heeft en het opgegeven wachtwoord correct is. Het retourneert `false` in elk van de volgende gevallen:

- Het wachtwoord is onjuist.
- De presentatie heeft geen openings‑wachtwoord.
- Het opgegeven wachtwoord is `null` of leeg.

Het gedrag is hetzelfde voor PPT‑ en PPTX‑presentaties.

## **Controleren of een geladen presentatie versleuteld is**

Na het laden van een presentatie met het correcte wachtwoord, inspecteer [ProtectionManager.isEncrypted](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/protectionmanager/#isEncrypted) om te bevestigen dat de bronpresentatie versleuteld was. Om bescherming met een openings‑wachtwoord te detecteren vóór het laden, gebruik [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) zoals hierboven getoond.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    const isEncrypted = presentation.getProtectionManager().isEncrypted();
    console.log("The presentation is encrypted: " + isEncrypted);
} finally {
    presentation.dispose();
}
```

## **Beveiligingsaanbevelingen**

{{% alert color="warning" title="Beveiliging" %}}
Log geen openings‑wachtwoorden en voeg ze niet toe aan diagnostische berichten. Vermijd onnodige herhaalde validatie‑pogingen, houd wachtwoorden alleen in het geheugen zolang als nodig is, en hergebruik een succesvolle validatie‑resultaat bij het direct laden van de presentatie.

Openbare documenteigenschappen kunnen auteursnamen, titels, onderwerpsvelden, trefwoorden, bedrijfsinformatie, commentaren en aangepaste waarden onthullen, zelfs als de presentatiew inhoud versleuteld is. Versleutel gevoelige metadata samen met de presentatie. Het openbaar houden van eigenschappen moet een expliciete beslissing zijn, alleen genomen wanneer systemen moeten indexeren, classificeren, zoeken of het bestand moeten beheren zonder een openings‑wachtwoord.
{{% /alert %}}

## **Een presentatie online met wachtwoord beschermen**

1. Open de applicatie [Aspose.Slides Lock](https://products.aspose.app/slides/nl/lock).
2. Selecteer of upload de presentatie.
3. Voer een wachtwoord in voor weergave‑beveiliging.
4. Voer eventueel een afzonderlijk wachtwoord in voor bewerkings‑beveiliging.
5. Pas de beveiliging toe en download het resulterende bestand.

{{% alert color="info" title="Zie ook" %}}
- [Presentaties met alleen schrijfbeveiliging](/slides/nl/nodejs-java/write-protected-presentation/)
- [Digitale handtekening in PowerPoint](/slides/nl/nodejs-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Wat is het verschil tussen een openings‑wachtwoord en een schrijf‑beveiligingswachtwoord?**

Een openings‑wachtwoord versleutelt de presentatie en is vereist om de inhoud te laden. Een schrijf‑beveiligingswachtwoord beperkt bewerken zonder de inhoud te versleutelen.

**Kan ik een openings‑wachtwoord valideren zonder alle dia’s te laden?**

Ja. Verkrijg presentaties‑informatie, controleer of bescherming met een openings‑wachtwoord aanwezig is, en valideer het wachtwoord voordat u een volledige presentaties‑instantie creëert.

**Kan een applicatie metadata lezen zonder het openings‑wachtwoord?**

Ja, maar alleen wanneer de presentatie versleuteld is met uitgeschakelde document‑eigenschap‑versleuteling. De applicatie moet dan de uitsluitend‑document‑eigenschappen‑laadmodus gebruiken die wordt beschreven in [Presentatie‑eigenschappen beheren](/slides/nl/nodejs-java/presentation-properties/).

**Ondersteunen de wachtwoord‑validatie‑workflows zowel PPT als PPTX?**

Ja. Detectie en validatie van wachtwoorden op basis van bestandspad en stream werken identiek voor PPT‑ en PPTX‑presentaties.