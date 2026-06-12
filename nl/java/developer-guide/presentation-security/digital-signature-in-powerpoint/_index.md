---
title: Digitale handtekeningen toevoegen aan presentaties in Java
linktitle: Digitale handtekening
type: docs
weight: 10
url: /nl/java/digital-signature-in-powerpoint/
keywords:
- digitale handtekening
- digitaal certificaat
- certificaatautoriteit
- PFX‑certificaat
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Leer hoe u PowerPoint‑ en OpenDocument‑bestanden digitaal ondertekent met Aspose.Slides voor Java. Beveilig uw dia's in enkele seconden met duidelijke code‑voorbeelden."
---
## **Introductie**

**Digitaal certificaat** wordt gebruikt om een met wachtwoord beveiligde PowerPoint‑presentatie te maken, gemarkeerd als gemaakt door een bepaalde organisatie of persoon. Digitaal certificaat kan worden verkregen door contact op te nemen met een geautoriseerde organisatie – een certificeringsinstantie. Na het installeren van het digitale certificaat in het systeem, kan het worden gebruikt om een digitale handtekening aan de presentatie toe te voegen via Bestand -> Info -> Presentatie beveiligen:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Presentatie kan meer dan één digitale handtekening bevatten. Nadat de digitale handtekening aan de presentatie is toegevoegd, verschijnt er een speciaal bericht in PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Om een presentatie te ondertekenen of de authenticiteit van presentatiehandtekeningen te controleren, biedt **Aspose.Slides API** de interface [**IDigitalSignature**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IDigitalSignature) , de interface [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IDigitalSignatureCollection) en de methode [**IPresentation.getDigitalSignatures**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IPresentation#getDigitalSignatures--) . Momenteel worden digitale handtekeningen alleen ondersteund voor het PPTX‑formaat.

## **Een digitale handtekening toevoegen met een PFX‑certificaat**
De code‑voorbeeld hieronder toont hoe je een digitale handtekening toevoegt met een PFX‑certificaat:

1. Open het PFX‑bestand en geef het PFX‑wachtwoord door aan het object [**DigitalSignature**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/DigitalSignature) .
1. Voeg de gemaakte handtekening toe aan het presentatie‑object.

```java
// Openen van het presentiebestand
Presentation pres = new Presentation();
try {
    // Maak DigitalSignature object aan met PFX bestand en PFX wachtwoord 
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", "testpass1");

    // Commentaar bij nieuwe digitale handtekening
    signature.setComments("Aspose.Slides digital signing test.");

    // Voeg digitale handtekening toe aan de presentatie
    pres.getDigitalSignatures().add(signature);

    // Sla de presentatie op
    pres.save("SomePresentationSigned.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Nu is het mogelijk om te controleren of de presentatie digitaal ondertekend is en niet is gewijzigd:

```java
// Open presentatie
Presentation pres = new Presentation("SomePresentationSigned.pptx");
try {
    if (pres.getDigitalSignatures().size() > 0)
    {
        boolean allSignaturesAreValid = true;

        System.out.println("Signatures used to sign the presentation: ");

        // Controleer of alle digitale handtekeningen geldig zijn
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

Ja. De collectie digitale handtekeningen ondersteunt [het verwijderen van individuele items](https://reference.aspose.com/slides/nl/java/com.aspose.slides/digitalsignaturecollection/#removeAt-int-) en [het volledig leegmaken ervan](https://reference.aspose.com/slides/nl/java/com.aspose.slides/digitalsignaturecollection/#clear--) ; nadat je het bestand opslaat, bevat de presentatie geen handtekeningen meer.

**Wordt het bestand na ondertekening “alleen‑lezen”?**

Nee. Een handtekening behoudt de integriteit en het auteurschap, maar blokkeert geen bewerkingen. Om bewerken te beperken, combineer je het met ["Read-only" of een wachtwoord](/slides/nl/java/password-protected-presentation/) .

**Wordt de handtekening correct weergegeven in verschillende versies van PowerPoint?**

De handtekening is gemaakt voor de OOXML (PPTX) container. Moderne versies van PowerPoint die OOXML‑handtekeningen ondersteunen, geven de status van dergelijke handtekeningen correct weer.