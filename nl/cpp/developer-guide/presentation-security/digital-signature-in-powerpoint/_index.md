---
title: Digitale Handtekeningen Toevoegen aan Presentaties in C++
linktitle: Digitale Handtekening
type: docs
weight: 10
url: /nl/cpp/digital-signature-in-powerpoint/
keywords:
- digitale handtekening
- digitaal certificaat
- certificeringsinstantie
- PFX‑certificaat
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Leer hoe u PowerPoint‑ en OpenDocument‑bestanden digitaal kunt ondertekenen met Aspose.Slides voor C++. Beveilig uw dia's in enkele seconden met duidelijke codevoorbeelden."
---
## **Inleiding**

**Digitaal certificaat** wordt gebruikt om een met wachtwoord beveiligde PowerPoint‑presentatie te maken, gemarkeerd als gemaakt door een bepaalde organisatie of persoon. Digitaal certificaat kan worden verkregen door contact op te nemen met een geautoriseerde organisatie - een certificeringsinstantie. Na het installeren van het digitale certificaat in het systeem, kan het worden gebruikt om een digitale handtekening toe te voegen aan de presentatie via Bestand -> Info -> Presentatie beveiligen:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Een presentatie kan meer dan één digitale handtekening bevatten. Nadat de digitale handtekening aan de presentatie is toegevoegd, verschijnt er een speciaal bericht in PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Om een presentatie te ondertekenen of de authenticiteit van presentatie‑handtekeningen te controleren, biedt de Aspose.Slides API de [**IDigitalSignature**](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_digital_signature) interface, de [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_digital_signature_collection) interface en de [**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_presentation#a6f78aff0f8ffa07ff67368fa003722b1) methode. Momenteel worden digitale handtekeningen alleen ondersteund voor het PPTX‑formaat.

## **Een digitale handtekening toevoegen vanuit een PFX‑certificaat**
De onderstaande code‑voorbeeld toont hoe je een digitale handtekening toevoegt vanuit een PFX‑certificaat:

1. Open het PFX‑bestand en geef het PFX‑wachtwoord door aan het [**DigitalSignature**](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.digital_signature) object.
1. Voeg de gemaakte handtekening toe aan het presentatie‑object.

``` cpp
auto pres = System::MakeObject<Presentation>();

// Maak een DigitalSignature-object aan met PFX-bestand en PFX-wachtwoord 
auto signature = System::MakeObject<DigitalSignature>(u"testsignature1.pfx", u"testpass1");

// Opmerking voor nieuwe digitale handtekening
signature->set_Comments(u"Aspose.Slides digital signing test.");

// Voeg digitale handtekening toe aan presentatie
pres->get_DigitalSignatures()->Add(signature);

// Sla presentatie op
pres->Save(u"SomePresentationSigned.pptx", SaveFormat::Pptx);
```

Nu is het mogelijk om te controleren of de presentatie digitaal is ondertekend en niet is aangepast:

``` cpp
// Open presentatie
auto pres = System::MakeObject<Presentation>(u"SomePresentationSigned.pptx");

if (pres->get_DigitalSignatures()->get_Count() > 0)
{
    bool allSignaturesAreValid = true;

    Console::WriteLine(u"Signatures used to sign the presentation: ");

    // Controleer of alle digitale handtekeningen geldig zijn
    for (auto signature : pres->get_DigitalSignatures())
    {
        Console::WriteLine(signature->get_Certificate()->get_SubjectName()->get_Name() 
            + u", " 
            + signature->get_SignTime().ToString(u"yyyy-MM-dd HH:mm") 
            + u" -- " 
            + (signature->get_IsValid() ? System::String(u"VALID") : System::String(u"INVALID")));
        allSignaturesAreValid &= signature->get_IsValid();
    }

    if (allSignaturesAreValid)
    {
        Console::WriteLine(u"Presentation is genuine, all signatures are valid.");
    }
    else
    {
        Console::WriteLine(u"Presentation has been modified since signing.");
    }
}
```

## **FAQ**

**Kan ik bestaande handtekeningen uit een bestand verwijderen?**

Ja. De collectie digitale handtekeningen ondersteunt [het verwijderen van individuele items](https://reference.aspose.com/slides/nl/cpp/aspose.slides/digitalsignaturecollection/removeat/) en [het volledig wissen ervan](https://reference.aspose.com/slides/nl/cpp/aspose.slides/digitalsignaturecollection/clear/); na het opslaan van het bestand bevat de presentatie geen handtekeningen meer.

**Wordt het bestand “alleen‑lezen” na ondertekenen?**

Nee. Een handtekening behoudt integriteit en auteurschap, maar blokkeert geen bewerkingen. Om bewerken te beperken, combineer dit met ["Alleen‑lezen" of een wachtwoord](/slides/nl/cpp/password-protected-presentation/).

**Wordt de handtekening correct weergegeven in verschillende versies van PowerPoint?**

De handtekening is aangemaakt voor de OOXML (PPTX) container. Moderne versies van PowerPoint die OOXML‑handtekeningen ondersteunen, geven de status van dergelijke handtekeningen correct weer.