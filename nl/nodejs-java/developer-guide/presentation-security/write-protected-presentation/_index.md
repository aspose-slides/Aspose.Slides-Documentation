---
title: Schrijfbeveiligde presentaties in JavaScript
linktitle: Schrijfbescherming
type: docs
weight: 25
url: /nl/nodejs-java/write-protected-presentation/
keywords:
- schrijfbescherming
- schrijfbeveiliging PowerPoint
- wachtwoord om te wijzigen
- beperken bewerken van presentatie
- verwijderen schrijfbescherming
- valideren wijzigingswachtwoord
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Instellen, detecteren, valideren en verwijderen van schrijfbeschermingswachtwoorden in PowerPoint PPT‑ en PPTX‑presentaties met Aspose.Slides voor Node.js via Java."
---
## **Introductie**

Een wachtwoord voor schrijfbescherming beperkt het wijzigen van een presentatie, maar versleutelt de inhoud niet. Gebruikers kunnen een schrijfbeveiligde presentatie laden en bekijken zonder het wachtwoord. Afhankelijk van de applicatie kunnen ze de inhoud ook bewerken en opslaan onder een andere naam, dus schrijfbescherming moet niet worden gezien als een vertrouwelijkheidsmechanisme.

Een openingswachtwoord heeft een ander doel: het versleutelt de presentatie en is vereist om de inhoud te laden. Zie [Password-Protect Presentations](/slides/nl/nodejs-java/password-protected-presentation/) om een presentatie te versleutelen of een openingswachtwoord te valideren.

De werkwijzen in dit artikel gelden voor zowel PPT‑ als PPTX‑presentaties. De voorbeelden gebruiken PPTX‑bestanden; bij het opslaan als PPT gebruikt u de extensie `.ppt` en het overeenkomstige PPT‑opslagformaat.

## **Schrijfbescherming instellen voor een presentatie**

Gebruik [ProtectionManager.setWriteProtection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/protectionmanager/#setWriteProtection) om een wachtwoord toe te wijzen voor het wijzigen van een presentatie. Het opslaan van de presentatie maakt de beschermingseigenschap permanent.

Het volgende voorbeeld stelt schrijfbescherming in voor een PPTX‑presentatie:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("modify_password");
    presentation.save("write-protected-pres.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Een schrijfbeveiligde presentatie laden**

Omdat schrijfbescherming de inhoud van de presentatie niet versleutelt, is er geen wachtwoord nodig om de presentatie te laden. Het wachtwoord is alleen relevant bij het valideren van de autorisatie om de beveiligde presentatie te wijzigen.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("write-protected-pres.pptx");
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Geef geen schrijfbeschermingswachtwoord door aan [LoadOptions.setPassword](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/loadoptions/#setPassword). Die methode accepteert een openingswachtwoord voor versleutelde inhoud. Als een presentatie beide beschermingssoorten heeft, levert u het openingswachtwoord om deze te laden en behandelt u het schrijfbeschermingswachtwoord apart.

## **Schrijfbescherming verwijderen van een presentatie**

Gebruik [ProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/protectionmanager/#removeWriteProtection) om de wijzigingsrestrictie weg te nemen, en sla vervolgens de presentatie op.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("write-protected-pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Controleren of een presentatie schrijfbeveiligd is**

Om een bestand te inspecteren zonder een volledige [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑instantie te maken, roep [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) aan en controleer [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentationinfo/#isWriteProtected). De methode gebruikt [NullableBool](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/nullablebool/) en retourneert `NullableBool.True` wanneer schrijfbescherming wordt gedetecteerd.

```javascript
const slides = require("aspose.slides.via.java");

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() === slides.NullableBool.True) {
    console.log("The presentation is write protected.");
} else {
    console.log("Write protection was not detected.");
}
```

De op streams gebaseerde methode [PresentationFactory.getPresentationInfoFromStream](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfoFromStream) biedt dezelfde informatie voor een presentatie die als een Node.js‑leesbare stream wordt aangeleverd.

## **Validatie van een schrijfbeschermingswachtwoord**

Gebruik [PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentationinfo/#checkWriteProtection) om een wijzigingswachtwoord te valideren zonder de volledige presentatie te laden. Controleer eerst [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentationinfo/#isWriteProtected) zodat de applicatie alleen een wachtwoord vraagt of valideert wanneer er schrijfbescherming aanwezig is.

```javascript
const slides = require("aspose.slides.via.java");

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() !== slides.NullableBool.True) {
    console.log("The presentation is not write protected.");
} else if (presentationInfo.checkWriteProtection("modify_password")) {
    console.log("The write-protection password is correct.");
} else {
    console.log("The write-protection password is incorrect.");
}
```

[PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentationinfo/#checkWriteProtection) valideert alleen het schrijfbeschermingswachtwoord. Het valideert geen openingswachtwoord en bepaalt niet of versleutelde inhoud kan worden geladen. Omgekeerd valideert [PresentationInfo.checkPassword](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentationinfo/#checkPassword) alleen een openingswachtwoord. Als een volledige presentatie reeds is geladen, biedt [ProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/protectionmanager/#checkWriteProtection) de equivalente schrijfbeschermingscontrole via zijn protectiemanager.

In productie‑applicaties mogen wachtwoorden niet in logs worden vastgelegd of in diagnostische berichten worden opgenomen. Vermijd onnodige herhaalde validatiepogingen en bewaar wachtwoorden in het geheugen alleen zolang als nodig is.

{{% alert color="info" title="Zie ook" %}}
- [Password-Protect Presentations](/slides/nl/nodejs-java/password-protected-presentation/)
- [Read-Only Presentations](/slides/nl/nodejs-java/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/nl/nodejs-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Versleutelt schrijfbescherming een presentatie?**

Nee. Het beperkt het wijzigen, maar laat de presentatietekst beschikbaar voor laden en bekijken.

**Is het schrijfbeschermingswachtwoord vereist om een presentatie te openen?**

Nee. Alleen een openingswachtwoord is vereist om versleutelde presentatiedata te laden.

**Kan een presentatie zowel een openingswachtwoord als een schrijfbeschermingswachtwoord hebben?**

Ja. Geef het openingswachtwoord via de laad‑opties op om de versleutelde presentatie te openen, en valideer het schrijfbeschermingswachtwoord apart wanneer autorisatie voor wijziging nodig is.