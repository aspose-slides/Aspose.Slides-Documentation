---
title: Digitale handtekeningen aan presentaties toevoegen met Python
linktitle: Digitale handtekening
type: docs
weight: 10
url: /nl/python-net/digital-signature-in-powerpoint/
keywords:
- digitale handtekening
- digitaal certificaat
- certificaatautoriteit
- PFX-certificaat
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Leer hoe u PowerPoint- en OpenDocument-bestanden digitaal ondertekent met Aspose.Slides voor Python via .NET. Beveilig uw dia's in enkele seconden met duidelijke code-voorbeelden."
---
## **Introductie**

**Digital certificate** wordt gebruikt om een met wachtwoord beveiligde PowerPoint‑presentatie te maken, gemarkeerd als gemaakt door een bepaalde organisatie of persoon. Een digitaal certificaat kan verkregen worden door contact op te nemen met een geautoriseerde organisatie – een certificaatautoriteit. Nadat het digitale certificaat in het systeem is geïnstalleerd, kan het gebruikt worden om een digitale handtekening aan de presentatie toe te voegen via Bestand -> Info -> Presentatie beveiligen:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Een presentatie kan meer dan één digitale handtekening bevatten. Nadat de digitale handtekening is toegevoegd aan de presentatie, verschijnt er een speciaal bericht in PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Om een presentatie te ondertekenen of de authenticiteit van presentatiehandtekeningen te controleren, biedt de **Aspose.Slides API** de [**DigitalSignature**](https://reference.aspose.com/slides/nl/python-net/aspose.slides/digitalsignature/)‑klasse, de [**DigitalSignatureCollection**](https://reference.aspose.com/slides/nl/python-net/aspose.slides/DigitalSignatureCollection/)‑klasse en de eigenschap [**Presentation.digital_signatures**](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/digital_signatures/). Momenteel worden digitale handtekeningen alleen ondersteund voor het PPTX‑formaat.

## **Digitale handtekening toevoegen vanuit PFX‑certificaat**

Het codevoorbeeld hieronder toont hoe een digitale handtekening toe te voegen vanuit een PFX‑certificaat:

1. Open het PFX‑bestand en geef het PFX‑wachtwoord door aan het [**DigitalSignature**](https://reference.aspose.com/slides/nl/python-net/aspose.slides/digitalsignature/)‑object.
2. Voeg de gemaakte handtekening toe aan het presentatie‑object.

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    # Maak DigitalSignature-object met PFX-bestand en PFX-wachtwoord
    signature = slides.DigitalSignature(path + "testsignature1.pfx", "testpass1")

    # Voeg opmerking toe aan nieuwe digitale handtekening
    signature.comments = "Aspose.Slides digital signing test."

    # Voeg digitale handtekening toe aan presentatie
    pres.digital_signatures.add(signature)

    # sla presentatie op
    pres.save("SomePresentationSigned.pptx", slides.export.SaveFormat.PPTX)
```

Nu is het mogelijk om te controleren of de presentatie digitaal ondertekend is en niet is gewijzigd:

```py
# Open presentatie
with slides.Presentation("SomePresentationSigned.pptx") as pres:
    if len(pres.digital_signatures) > 0:
        allSignaturesAreValid = True

        print("Signatures used to sign the presentation: ")
        # Controleer of alle digitale handtekeningen geldig zijn
        for signature in pres.digital_signatures :
            print(signature.certificate.subject_name.name + ", "
                    + signature.sign_time.strftime("yyyy-MM-dd HH:mm") + " -- " + "VALID" if signature.is_valid else "INVALID")
            allSignaturesAreValid = allSignaturesAreValid and signature.is_valid
        

        if allSignaturesAreValid:
            print("Presentation is genuine, all signatures are valid.")
        else:
            print("Presentation has been modified since signing.")
```

## **FAQ**

**Kan ik bestaande handtekeningen uit een bestand verwijderen?**

Ja. De collectie digitale handtekeningen ondersteunt het [verwijderen van individuele items](https://reference.aspose.com/slides/nl/python-net/aspose.slides/digitalsignaturecollection/remove_at/) en het [volledig leegmaken](https://reference.aspose.com/slides/nl/python-net/aspose.slides/digitalsignaturecollection/clear/); nadat u het bestand heeft opgeslagen, zal de presentatie geen handtekeningen meer bevatten.

**Wordt het bestand 'alleen-lezen' na ondertekening?**

Nee. Een handtekening behoudt integriteit en auteurschap, maar blokkeert geen bewerkingen. Om bewerken te beperken, combineer dit met ["Alleen-lezen" of een wachtwoord](/slides/nl/python-net/password-protected-presentation/).

**Wordt de handtekening correct weergegeven in verschillende versies van PowerPoint?**

De handtekening is gemaakt voor de OOXML (PPTX)‑container. Moderne versies van PowerPoint die OOXML‑handtekeningen ondersteunen, geven de status van dergelijke handtekeningen correct weer.