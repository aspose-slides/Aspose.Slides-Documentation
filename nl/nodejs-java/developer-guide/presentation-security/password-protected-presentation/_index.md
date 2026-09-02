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
description: "Versleutel, detecteer, valideer, open en ontsleutel wachtwoordbeveiligde PowerPoint PPT en PPTX-presentaties in JavaScript met Aspose.Slides."
---
## **Overzicht**

Een openingswachtwoord versleutelt een presentatie. Het juiste wachtwoord is vereist om de presentatie‑inhoud te laden en te bekijken, zodat deze bescherming vertrouwelijkheid biedt.

Een openingswachtwoord verschilt van een schrijfbeschermingswachtwoord. Schrijfbescherming beperkt wijziging, maar versleutelt de inhoud niet en verhindert niet dat de presentatie wordt geladen. Om wachtwoorden voor het wijzigen van presentaties te beheren, zie [Presentaties met schrijfbescherming](/slides/nl/nodejs-java/write-protected-presentation/).

De onderstaande werkwijzen zijn van toepassing op zowel PPT‑ als PPTX‑presentaties. De voorbeelden gebruiken beide formaten wanneer hun bestands‑ en stroomgebaseerde gedrag belangrijk is.

## **Een presentatie versleutelen met een openingswachtwoord**

Gebruik [ProtectionManager.encrypt](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/protectionmanager/#encrypt) om een openingswachtwoord toe te wijzen. Gebruik vervolgens [Presentation.save](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#save) om de versleutelde presentatie op te slaan.

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

## **Een versleutelde presentatie laden**

Stel [LoadOptions.setPassword](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/loadoptions/#setPassword) in op het openingswachtwoord en geef de opties door aan [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) bij het laden van het bestand. Het laden mislukt wanneer een openingswachtwoord vereist is maar het opgegeven wachtwoord ontbreekt of onjuist is.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    // Werk met de ontsleutelde presentatie.
} finally {
    presentation.dispose();
}
```

## **Versleuteling van een presentatie verwijderen**

Laad de presentatie met het bijbehorende openingswachtwoord, roep [ProtectionManager.removeEncryption](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/protectionmanager/#removeEncryption) aan en sla het resultaat op. De opgeslagen presentatie kan vervolgens zonder wachtwoord worden geladen.

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

## **Een openingswachtwoord valideren vóór het laden**

Gebruik [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) om [PresentationInfo](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentationinfo/) te verkrijgen zonder een volledige presentatie‑instantie aan te maken. Controleer [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) voordat u een wachtwoord aanvraagt of valideert. Wanneer bescherming aanwezig is, valideer dan de opgegeven waarde met [PresentationInfo.checkPassword](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentationinfo/#checkPassword).

### **Bestandspad‑werkwijze**

Het volgende voorbeeld valideert een openingswachtwoord voor een PPTX‑bestand, geeft de gevalideerde waarde door aan [LoadOptions.setPassword](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/loadoptions/#setPassword), en laadt vervolgens de volledige presentatie:

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

### **Stroom‑werkwijze**

Gebruik [PresentationFactory.getPresentationInfoFromStream](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfoFromStream) om een leesbare Node.js‑stroom te inspecteren. Nadat de inspectiestroom is verbruikt, maak een nieuwe stroom aan voordat u de volledige presentatie laadt met [Presentation.createPresentationFromStream](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#createPresentationFromStream).

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

### **Returnwaarden van checkPassword**

[PresentationInfo.checkPassword](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentationinfo/#checkPassword) retourneert `true` alleen wanneer de presentatie een openingswachtwoord heeft en het opgegeven wachtwoord correct is. Het retourneert `false` in elk van de volgende gevallen:

- Het wachtwoord is onjuist.
- De presentatie heeft geen openingswachtwoord.
- Het opgegeven wachtwoord is `null` of leeg.

Het gedrag is hetzelfde voor PPT‑ en PPTX‑presentaties.

## **Controleren of een geladen presentatie versleuteld is**

Nadat u een presentatie hebt geladen met het juiste wachtwoord, controleer [ProtectionManager.isEncrypted](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/protectionmanager/#isEncrypted) om te bevestigen dat de oorspronkelijke presentatie versleuteld was. Om openings‑wachtwoordbescherming vóór het laden te detecteren, gebruik [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) zoals hierboven weergegeven.

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

{% alert color="warning" title="Beveiliging" %}
Log geen openingswachtwoorden en neem ze niet op in diagnostische berichten. Vermijd onnodige herhaalde validatie‑pogingen, bewaar wachtwoorden alleen in het geheugen zolang dat nodig is, en hergebruik een succesvolle validatie‑resultaat bij het direct laden van de presentatie.
{% /alert %}

## **Een presentatie online met een wachtwoord beschermen**

1. Open de toepassing [Aspose.Slides Lock](https://products.aspose.app/slides/nl/lock).
2. Selecteer of upload de presentatie.
3. Voer een wachtwoord in voor weergavebescherming.
4. Voer eventueel een afzonderlijk wachtwoord in voor bewerkingsbescherming.
5. Pas de bescherming toe en download het resulterende bestand.

{% alert color="info" title="Zie ook" %}
- [Presentaties met schrijfbescherming](/slides/nl/nodejs-java/write-protected-presentation/)
- [Digitale handtekening in PowerPoint](/slides/nl/nodejs-java/digital-signature-in-powerpoint/)
{% /alert %}

## **Veelgestelde vragen**

**Wat is het verschil tussen een openingswachtwoord en een schrijf‑beschermingswachtwoord?**

Een openingswachtwoord versleutelt de presentatie en is vereist om de inhoud te laden. Een schrijfbeschermingswachtwoord beperkt wijziging zonder de inhoud te versleutelen.

**Kan ik een openingswachtwoord valideren zonder alle dia's te laden?**

Ja. Verkrijg presentatiesinformatie, controleer of er een openings‑wachtwoordbescherming aanwezig is, en valideer het wachtwoord voordat u een volledige presentaties­instantie maakt.

**Ondersteunen de wachtwoord‑controlescenari’s zowel PPT als PPTX?**

Ja. Wachtwoorddetectie en -validatie op basis van bestandspad en stroom werken hetzelfde voor PPT‑ en PPTX‑presentaties.