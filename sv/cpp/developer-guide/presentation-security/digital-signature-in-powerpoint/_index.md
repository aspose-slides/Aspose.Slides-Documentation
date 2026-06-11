---
title: Lägg till digitala signaturer i presentationer i C++
linktitle: Digital signatur
type: docs
weight: 10
url: /sv/cpp/digital-signature-in-powerpoint/
keywords:
- digital signatur
- digitalt certifikat
- certifikatutfärdare
- PFX-certifikat
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Lär dig hur du digitalt signerar PowerPoint- och OpenDocument-filer med Aspose.Slides för C++. Skydda dina bilder på sekunder med tydliga kodexempel."
---
## **Introduktion**

**Digitalt certifikat** används för att skapa en lösenordsskyddad PowerPoint-presentation, markerad som skapad av en viss organisation eller person. Digitalt certifikat kan erhållas genom att kontakta en auktoriserad organisation – en certifikatutfärdare. Efter att ha installerat digitalt certifikat i systemet kan det användas för att lägga till en digital signatur i presentationen via Arkiv -> Info -> Skydda presentation:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

En presentation kan innehålla mer än en digital signatur. När den digitala signaturen har lagts till i presentationen visas ett specialmeddelande i PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

För att signera en presentation eller kontrollera äktheten hos presentationssignaturer tillhandahåller **Aspose.Slides API** [**IDigitalSignature**](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_digital_signature)‑gränssnittet, [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_digital_signature_collection)‑gränssnittet och [**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_presentation#a6f78aff0f8ffa07ff67368fa003722b1)‑metoden. För närvarande stöds digitala signaturer endast för PPTX‑format.

## **Lägg till en digital signatur från ett PFX‑certifikat**
Kodexemplet nedan visar hur man lägger till en digital signatur från ett PFX‑certifikat:

1. Öppna PFX‑filen och skicka PFX‑lösenordet till [**DigitalSignature**](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.digital_signature)‑objektet.
2. Lägg till den skapade signaturen i presentationsobjektet.

``` cpp
auto pres = System::MakeObject<Presentation>();

// Skapa DigitalSignature-objekt med PFX-fil och PFX-lösenord 
auto signature = System::MakeObject<DigitalSignature>(u"testsignature1.pfx", u"testpass1");

// Kommentera ny digital signatur
signature->set_Comments(u"Aspose.Slides digital signing test.");

// Lägg till digital signatur i presentationen
pres->get_DigitalSignatures()->Add(signature);

// Spara presentationen
pres->Save(u"SomePresentationSigned.pptx", SaveFormat::Pptx);
```

Nu är det möjligt att kontrollera om presentationen har signerats digitalt och inte har modifierats:

``` cpp
// Öppna presentation
auto pres = System::MakeObject<Presentation>(u"SomePresentationSigned.pptx");

if (pres->get_DigitalSignatures()->get_Count() > 0)
{
    bool allSignaturesAreValid = true;

    Console::WriteLine(u"Signatures used to sign the presentation: ");

    // Kontrollera om alla digitala signaturer är giltiga
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

## **Vanliga frågor**

**Kan jag ta bort befintliga signaturer från en fil?**

Ja. Samlingen av digitala signaturer stöder [att ta bort enskilda objekt](https://reference.aspose.com/slides/sv/cpp/aspose.slides/digitalsignaturecollection/removeat/) och [att rensa hela samlingen](https://reference.aspose.com/slides/sv/cpp/aspose.slides/digitalsignaturecollection/clear/); efter att du sparat filen kommer presentationen inte ha några signaturer.

**Blir filen "read-only" efter signering?**

Nej. En signatur bevarar integritet och författarskap men blockerar inte redigering. För att begränsa redigering kombineras den med ["Read-only" eller ett lösenord](/slides/sv/cpp/password-protected-presentation/).

**Visas signaturen korrekt i olika versioner av PowerPoint?**

Signaturen är skapad för OOXML‑behållaren (PPTX). Moderna versioner av PowerPoint som stöder OOXML‑signaturer visar statusen för sådana signaturer korrekt.