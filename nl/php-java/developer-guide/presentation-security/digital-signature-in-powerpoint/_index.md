---
title: Digitale handtekeningen toevoegen aan presentaties in PHP
linktitle: Digitale handtekening
type: docs
weight: 10
url: /nl/php-java/digital-signature-in-powerpoint/
keywords:
- digitale handtekening
- digitaal certificaat
- certificaatautoriteit
- PFX-certificaat
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Leer hoe u PowerPoint- en OpenDocument-bestanden digitaal kunt ondertekenen met Aspose.Slides voor PHP via Java. Beveilig uw dia's in enkele seconden met duidelijke code-voorbeelden."
---
## **Inleiding**

**Digitale certificaat** wordt gebruikt om een met wachtwoord beveiligde PowerPoint‑presentatie te maken, gemarkeerd als aangemaakt door een bepaalde organisatie of persoon. Een digitaal certificaat kan verkregen worden door contact op te nemen met een geautoriseerde organisatie – een certificeringsautoriteit. Nadat het digitale certificaat in het systeem is geïnstalleerd, kan het gebruikt worden om een digitale handtekening toe te voegen aan de presentatie via Bestand -> Info -> Presentatie beveiligen:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Een presentatie kan meer dan één digitale handtekening bevatten. Nadat de digitale handtekening aan de presentatie is toegevoegd, verschijnt er een speciaal bericht in PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Om een presentatie te ondertekenen of de authenticiteit van presentatiehandtekeningen te controleren, biedt de **Aspose.Slides API** de klasse **DigitalSignature**, de klasse **DigitalSignatureCollection** en de methode [**Presentation::getDigitalSignatures**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation/#getDigitalSignatures). Momenteel worden digitale handtekeningen alleen ondersteund voor het PPTX‑formaat.

## **Een digitale handtekening toevoegen vanuit een PFX‑certificaat**

De onderstaande codevoorbeeld toont hoe een digitale handtekening toe te voegen vanuit een PFX‑certificaat:

1. Open het PFX‑bestand en geef het PFX‑wachtwoord door aan het **DigitalSignature**‑object.  
1. Voeg de aangemaakte handtekening toe aan het presentatie‑object.

```php
  # Presentatiebestand openen
  $pres = new Presentation();
  try {
    # DigitalSignature-object maken met PFX-bestand en PFX-wachtwoord
    $signature = new DigitalSignature("testsignature1.pfx", "testpass1");
    # Commentaar voor nieuwe digitale handtekening
    $signature->setComments("Aspose.Slides digital signing test.");
    # Digitale handtekening toevoegen aan presentatie
    $pres->getDigitalSignatures()->add($signature);
    # Presentatie opslaan
    $pres->save("SomePresentationSigned.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

Nu is het mogelijk te controleren of de presentatie digitaal ondertekend is en niet gewijzigd is:

```php
  # Presentatie openen
  $pres = new Presentation("SomePresentationSigned.pptx");
  try {
    if (java_values($pres->getDigitalSignatures()->size()) > 0) {
      $allSignaturesAreValid = true;
      echo("Signatures used to sign the presentation: ");
      # Controleren of alle digitale handtekeningen geldig zijn
      foreach($pres->getDigitalSignatures() as $signature) {
        echo($signature->getComments() . ", " . $signature->getSignTime()->toString() . " -- " . $signature->isValid() ? "VALID" : "INVALID");
        $allSignaturesAreValid &= $signature->isValid();
      }
      if ($allSignaturesAreValid) {
        echo("Presentation is genuine, all signatures are valid.");
      } else {
        echo("Presentation has been modified since signing.");
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Kan ik bestaande handtekeningen uit een bestand verwijderen?**

Ja. De collectie digitale handtekeningen ondersteunt het [verwijderen van individuele items](https://reference.aspose.com/slides/nl/php-java/aspose.slides/digitalsignaturecollection/removeat/) en het [het volledig wissen](https://reference.aspose.com/slides/nl/php-java/aspose.slides/digitalsignaturecollection/clear/); nadat je het bestand hebt opgeslagen, bevat de presentatie geen handtekeningen meer.

**Wordt het bestand “alleen‑lezen” na ondertekening?**

Nee. Een handtekening behoudt de integriteit en auteurschap, maar blokkeert geen bewerkingen. Om bewerken te beperken, combineer je het met ["Alleen‑lezen" of een wachtwoord](/slides/nl/php-java/password-protected-presentation/).

**Wordt de handtekening correct weergegeven in verschillende versies van PowerPoint?**

De handtekening is gemaakt voor de OOXML‑ (PPTX)‑container. Moderne versies van PowerPoint die OOXML‑handtekeningen ondersteunen tonen de status van dergelijke handtekeningen correct.