---
title: Digitale handtekeningen toevoegen aan presentaties op Android
linktitle: Digitale handtekening
type: docs
weight: 10
url: /nl/androidjava/digital-signature-in-powerpoint/
keywords:
- digitale handtekening
- digitaal certificaat
- certificaatautoriteit
- PFX-certificaat
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Leer hoe u PowerPoint- en OpenDocument-bestanden digitaal ondertekent met Aspose.Slides voor Android. Beveilig uw dia's binnen enkele seconden met duidelijke Java-codevoorbeelden."
---
## **Inleiding**

**Digital certificate** wordt gebruikt om een met wachtwoord beveiligde PowerPoint‑presentatie te maken, gemarkeerd als aangemaakt door een bepaalde organisatie of persoon. Een digitaal certificaat kan verkregen worden door contact op te nemen met een geautoriseerde organisatie – een certificaatautoriteit. Nadat het digitale certificaat in het systeem is geïnstalleerd, kan het worden gebruikt om een digitale handtekening aan de presentatie toe te voegen via **Bestand → Info → Presentatie beveiligen**:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Een presentatie kan meer dan één digitale handtekening bevatten. Nadat de digitale handtekening aan de presentatie is toegevoegd, verschijnt er een speciaal bericht in PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Om een presentatie te ondertekenen of de authenticiteit van presentatiehandtekeningen te controleren, biedt de Aspose.Slides API de interface **IDigitalSignature**, de interface **IDigitalSignatureCollection** en de methode **IPresentation.getDigitalSignatures**. Momenteel worden digitale handtekeningen alleen ondersteund voor het PPTX‑formaat.

## **Een digitale handtekening toevoegen vanuit een PFX‑certificaat**
De onderstaande codevoorbeelden tonen hoe je een digitale handtekening toevoegt vanuit een PFX‑certificaat:

1. Open het PFX‑bestand en geef het PFX‑wachtwoord door aan het **DigitalSignature**‑object.  
2. Voeg de gemaakte handtekening toe aan het presentatie‑object.

```java
// Presentatiebestand openen
Presentation pres = new Presentation();
try {
    // Maak een DigitalSignature object met PFX bestand en PFX wachtwoord 
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", "testpass1");

    // Commentaar bij nieuwe digitale handtekening
    signature.setComments("Aspose.Slides digital signing test.");

    // Voeg digitale handtekening toe aan de presentatie
    pres.getDigitalSignatures().add(signature);

    // Sla presentatie op
    pres.save("SomePresentationSigned.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Nu is het mogelijk om te controleren of de presentatie digitaal ondertekend is en niet is gewijzigd:

```java
// Presentatie openen
Presentation pres = new Presentation("SomePresentationSigned.pptx");
try {
    if (pres.getDigitalSignatures().size() > 0)
    {
        boolean allSignaturesAreValid = true;

        System.out.println("Signatures used to sign the presentation: ");

        // Controleren of alle digitale handtekeningen geldig zijn
        for (IDigitalSignature signature : pres.getDigitalSignatures())
        {
            System.out.println(signature.getComments() + ", "
                    + signature.getSignTime().toString() + " -- " + (signature.isValid() ? "VALID" : "INVALID"));
            allSignaturesAreValid &= signature.isValid();
        }

        if (allSignaturesAreValid)
            System.out.println("Presentation is genuine, all signatures are valid.");
        else
            System.out.println("Presentation has been modified since signing.");
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Kan ik bestaande handtekeningen uit een bestand verwijderen?**

Ja. De collectie digitale handtekeningen ondersteunt het [verwijderen van individuele items](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/digitalsignaturecollection/#removeAt-int-) en het [volledig leegmaken](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/digitalsignaturecollection/#clear--); nadat je het bestand hebt opgeslagen, zal de presentatie geen handtekeningen meer bevatten.

**Wordt het bestand na ondertekening "alleen-lezen"?**

Nee. Een handtekening bewaart de integriteit en auteurschap, maar blokkeert geen bewerkingen. Om bewerken te beperken, combineer je dit met ["Read-only" of een wachtwoord](/slides/nl/androidjava/password-protected-presentation/).

**Wordt de handtekening correct weergegeven in verschillende versies van PowerPoint?**

De handtekening is gemaakt voor de OOXML‑ (PPTX‑)container. Moderne versies van PowerPoint die OOXML‑handtekeningen ondersteunen, tonen de status van dergelijke handtekeningen correct.