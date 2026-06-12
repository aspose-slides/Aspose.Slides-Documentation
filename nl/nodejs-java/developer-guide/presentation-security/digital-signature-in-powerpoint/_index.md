---
title: Digitale Handtekeningen Toevoegen aan Presentaties in JavaScript
linktitle: Digitale Handtekening
type: docs
weight: 10
url: /nl/nodejs-java/digital-signature-in-powerpoint/
keywords:
- digitale handtekening
- digitaal certificaat
- certificaatautoriteit
- PFX-certificaat
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Leer hoe u PowerPoint- en OpenDocument-bestanden digitaal ondertekent met Aspose.Slides voor Node.js via Java. Beveilig uw dia's in enkele seconden met duidelijke code-voorbeelden."
---
## **Introductie**

**Digitaal certificaat** wordt gebruikt om een met wachtwoord beveiligde PowerPoint‑presentatie te maken, gemarkeerd als aangemaakt door een bepaalde organisatie of persoon. Een digitaal certificaat kan verkregen worden door contact op te nemen met een geautoriseerde organisatie – een certificaatautoriteit. Nadat het digitale certificaat in het systeem is geïnstalleerd, kan het worden gebruikt om een digitale handtekening aan de presentatie toe te voegen via Bestand → Info → Presentatie beveiligen:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Een presentatie kan meer dan één digitale handtekening bevatten. Nadat de digitale handtekening aan de presentatie is toegevoegd, verschijnt er een speciaal bericht in PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Om een presentatie te ondertekenen of de authenticiteit van presentatiehandtekeningen te controleren, biedt **Aspose.Slides API** de klasse [**DigitalSignature**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/DigitalSignature), de klasse [**DigitalSignatureCollection**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/DigitalSignatureCollection) en de methode [**Presentation.getDigitalSignatures**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation#getDigitalSignatures--) . Momenteel worden digitale handtekeningen alleen ondersteund voor het PPTX‑formaat.

## **Digitale handtekening toevoegen vanuit een PFX‑certificaat**
Het onderstaande codevoorbeeld toont hoe een digitale handtekening van een PFX‑certificaat kan worden toegevoegd:

1. Open het PFX‑bestand en geef het PFX‑wachtwoord door aan het object [**DigitalSignature**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/DigitalSignature).
2. Voeg de gemaakte handtekening toe aan het presentatie‑object.

```javascript
// Presentatiebestand openen
var pres = new aspose.slides.Presentation();
try {
    // DigitalSignature-object maken met PFX-bestand en PFX-wachtwoord
    var signature = new aspose.slides.DigitalSignature("testsignature1.pfx", "testpass1");
    // Commentaar toevoegen aan nieuwe digitale handtekening
    signature.setComments("Aspose.Slides digital signing test.");
    // Digitale handtekening aan presentatie toevoegen
    pres.getDigitalSignatures().add(signature);
    // Presentatie opslaan
    pres.save("SomePresentationSigned.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Nu is het mogelijk te controleren of de presentatie digitaal ondertekend is en niet is gewijzigd:

```javascript
// Presentatie openen
var pres = new aspose.slides.Presentation("SomePresentationSigned.pptx");
try {
    if (pres.getDigitalSignatures().size() > 0) {
        var allSignaturesAreValid = true;
        console.log("Signatures used to sign the presentation: ");
        // Controleren of alle digitale handtekeningen geldig zijn
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

**Kan ik bestaande handtekeningen uit een bestand verwijderen?**

Ja. De collectie digitale handtekeningen ondersteunt [het verwijderen van individuele items](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/digitalsignaturecollection/removeat/) en [het volledig wissen ervan](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/digitalsignaturecollection/clear/); nadat u het bestand opslaat, heeft de presentatie geen handtekeningen meer.

**Wordt het bestand "alleen-lezen" na ondertekening?**

Nee. Een handtekening behoudt integriteit en auteurschap, maar blokkeert geen bewerkingen. Om bewerken te beperken, combineer dit met ["Alleen-lezen" of een wachtwoord](/slides/nl/nodejs-java/password-protected-presentation/).

**Wordt de handtekening correct weergegeven in verschillende versies van PowerPoint?**

De handtekening is gemaakt voor de OOXML‑(PPTX)‑container. Moderne versies van PowerPoint die OOXML‑handtekeningen ondersteunen, geven de status van dergelijke handtekeningen correct weer.