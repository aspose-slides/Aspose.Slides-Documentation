---
title: Digitale handtekeningen toevoegen aan presentaties in .NET
linktitle: Digitale handtekening
type: docs
weight: 10
url: /nl/net/digital-signature-in-powerpoint/
keywords:
- digitale handtekening
- digitaal certificaat
- certificaatautoriteit
- PFX-certificaat
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u PowerPoint- en OpenDocument-bestanden digitaal ondertekent met Aspose.Slides voor .NET. Beveilig uw dia's in enkele seconden met duidelijke codevoorbeelden."
---
## **Introductie**

**Digitaal certificaat** wordt gebruikt om een wachtwoordbeschermde PowerPoint‑presentatie te maken, gemarkeerd als gemaakt door een bepaalde organisatie of persoon. Een digitaal certificaat kan verkregen worden door contact op te nemen met een geautoriseerde organisatie – een certificaatautoriteit. Na het installeren van het digitale certificaat in het systeem kan het gebruikt worden om een digitale handtekening aan de presentatie toe te voegen via Bestand → Info → Presentatie beveiligen:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Een presentatie kan meer dan één digitale handtekening bevatten. Nadat de digitale handtekening aan de presentatie is toegevoegd, verschijnt er een speciaal bericht in PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Om een presentatie te ondertekenen of de authenticiteit van presentatiehandtekeningen te controleren, biedt de **Aspose.Slides API** de interface [**IDigitalSignature**](https://reference.aspose.com/slides/nl/net/aspose.slides/idigitalsignature), de interface [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/nl/net/aspose.slides/IDigitalSignatureCollection) en de eigenschap [**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/nl/net/aspose.slides/ipresentation/properties/digitalsignatures). Momenteel worden digitale handtekeningen alleen ondersteund voor het PPTX‑formaat.

## **Een digitale handtekening toevoegen vanuit een PFX‑certificaat**

Het onderstaande codevoorbeeld laat zien hoe u een digitale handtekening toevoegt vanuit een PFX‑certificaat:

1. Open het PFX‑bestand en geef het PFX‑wachtwoord door aan het **DigitalSignature**‑object.
2. Voeg de gemaakte handtekening toe aan het presentatie‑object.

```c#
using (Presentation pres = new Presentation())
{
    // Maak DigitalSignature-object aan met PFX-bestand en PFX-wachtwoord 
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", @"testpass1");

    // Voeg commentaar toe aan nieuwe digitale handtekening
    signature.Comments = "Aspose.Slides digital signing test.";

    // Voeg digitale handtekening toe aan presentatie
    pres.DigitalSignatures.Add(signature);

    // Sla presentatie op
    pres.Save("SomePresentationSigned.pptx", SaveFormat.Pptx);
}
```

Nu kunt u controleren of de presentatie digitaal ondertekend is en niet gewijzigd is:

```c#
// Open presentatie
using (Presentation pres = new Presentation("SomePresentationSigned.pptx"))
{
    if (pres.DigitalSignatures.Count > 0)
    {
        bool allSignaturesAreValid = true;

        Console.WriteLine("Signatures used to sign the presentation: ");

        // Controleer of alle digitale handtekeningen geldig zijn
        foreach (DigitalSignature signature in pres.DigitalSignatures)
        {
            Console.WriteLine(signature.Certificate.SubjectName.Name + ", "
                    + signature.SignTime.ToString("yyyy-MM-dd HH:mm") + " -- " + (signature.IsValid ? "VALID" : "INVALID"));
            allSignaturesAreValid &= signature.IsValid;
        }

        if (allSignaturesAreValid)
            Console.WriteLine("Presentation is genuine, all signatures are valid.");
        else
            Console.WriteLine("Presentation has been modified since signing.");
    }
}
```

## **FAQ**

**Kan ik bestaande handtekeningen uit een bestand verwijderen?**

Ja. De digitale handtekeningcollectie ondersteunt het [verwijderen van individuele items](https://reference.aspose.com/slides/nl/net/aspose.slides/digitalsignaturecollection/removeat/) en het [helemaal wissen ervan](https://reference.aspose.com/slides/nl/net/aspose.slides/digitalsignaturecollection/clear/); nadat u het bestand opslaat, heeft de presentatie geen handtekeningen meer.

**Wordt het bestand na ondertekening “alleen‑lezen”?**

Nee. Een handtekening waarborgt de integriteit en het auteurschap, maar blokkeert geen bewerkingen. Om bewerken te beperken, combineer dit met ["Alleen‑lezen" of een wachtwoord](/slides/nl/net/password-protected-presentation/).

**Wordt de handtekening correct weergegeven in verschillende versies van PowerPoint?**

De handtekening is aangemaakt voor de OOXML (PPTX)‑container. Moderne versies van PowerPoint die OOXML‑handtekeningen ondersteunen, geven de status van dergelijke handtekeningen correct weer.