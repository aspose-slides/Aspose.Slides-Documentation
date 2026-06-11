---
title: Lägg till digitala signaturer till presentationer i JavaScript
linktitle: Digital signatur
type: docs
weight: 10
url: /sv/nodejs-java/digital-signature-in-powerpoint/
keywords:
- digital signatur
- digitalt certifikat
- certifikatutfärdare
- PFX‑certifikat
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Lär dig hur du digitalt signerar PowerPoint‑ och OpenDocument‑filer med Aspose.Slides för Node.js via Java. Säkerställ dina bilder på några sekunder med tydliga kodexempel."
---
## **Introduktion**

**Digitalt certifikat** används för att skapa en lösenordsskyddad PowerPoint-presentation, markerad som skapad av en viss organisation eller person. Digitalt certifikat kan erhållas genom att kontakta en auktoriserad organisation – en certifikatutfärdare. Efter att ha installerat det digitala certifikatet i systemet kan det användas för att lägga till en digital signatur i presentationen via Arkiv → Info → Skydda presentation:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

En presentation kan innehålla mer än en digital signatur. När den digitala signaturen har lagts till i presentationen visas ett speciellt meddelande i PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

För att signera en presentation eller kontrollera äktheten hos presentationssignaturer tillhandahåller Aspose.Slides API klassen DigitalSignature, klassen DigitalSignatureCollection och metoden Presentation.getDigitalSignatures. För närvarande stöds digitala signaturer endast för PPTX-format.

## **Lägg till digital signatur från PFX‑certifikat**
Kodexemplet nedan visar hur man lägger till en digital signatur från ett PFX‑certifikat:

1. Öppna PFX‑filen och skicka PFX‑lösenordet till DigitalSignature‑objektet.
2. Lägg till den skapade signaturen i presentationsobjektet.

```javascript
// Öppnar presentationsfilen
var pres = new aspose.slides.Presentation();
try {
    // Skapa DigitalSignature-objekt med PFX-fil och PFX-lösenord
    var signature = new aspose.slides.DigitalSignature("testsignature1.pfx", "testpass1");
    // Kommentar för ny digital signatur
    signature.setComments("Aspose.Slides digital signing test.");
    // Lägg till digital signatur i presentationen
    pres.getDigitalSignatures().add(signature);
    // Spara presentationen
    pres.save("SomePresentationSigned.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Nu är det möjligt att kontrollera om presentationen var digitalt signerad och inte har ändrats:

```javascript
// Öppna presentationen
var pres = new aspose.slides.Presentation("SomePresentationSigned.pptx");
try {
    if (pres.getDigitalSignatures().size() > 0) {
        var allSignaturesAreValid = true;
        console.log("Signatures used to sign the presentation: ");
        // Kontrollera om alla digitala signaturer är giltiga
        for (let i = 0; i < pres.getDigitalSignatures().size(); i++) {
        let signature = pres.getDigitalSignatures().get_Item(i);
            console.log((((signature.getComments() + ", ") + signature.getSignTime().toString()) + " -- ") + (signature.isValid() ? "VALID" : "INVALID"));
            allSignaturesAreValid &= signature.isValid();
        }
        if (allSignaturesAreValid) {
            console.log("Presentation is genuine, all signatures are valid.");
        } else {
            console.log("Presentation has been modified since signing.");
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Kan jag ta bort befintliga signaturer från en fil?**

Ja. Samlingen av digitala signaturer stöder att ta bort enskilda objekt och att rensa den helt; efter att du sparat filen kommer presentationen inte ha några signaturer.

**Blir filen "skrivskyddad" efter signering?**

Nej. En signatur bevarar integritet och författarskap men hindrar inte redigering. För att begränsa redigering, kombinera den med ["Skrivskyddad" eller ett lösenord](/slides/sv/nodejs-java/password-protected-presentation/).

**Kommer signaturen att visas korrekt i olika versioner av PowerPoint?**

Signaturen är skapad för OOXML‑behållaren (PPTX). Moderna versioner av PowerPoint som stödjer OOXML‑signaturer visar statusen för sådana signaturer korrekt.