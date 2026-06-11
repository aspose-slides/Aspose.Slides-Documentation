---
title: Lägg till digitala signaturer i presentationer i .NET
linktitle: Digital signatur
type: docs
weight: 10
url: /sv/net/digital-signature-in-powerpoint/
keywords:
- digital signatur
- digitalt certifikat
- certifikatutfärdare
- PFX-certifikat
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lär dig hur du digitalt signerar PowerPoint och OpenDocument-filer med Aspose.Slides för .NET. Säkerställ dina bilder på några sekunder med tydliga kodexempel."
---
## **Introduktion**

**Digitalt certifikat** används för att skapa en lösenordsskyddad PowerPoint‑presentation, markerad som skapad av en viss organisation eller person. Digitalt certifikat kan erhållas genom att kontakta en auktoriserad organisation – en certifikatutfärdare. Efter att ha installerat det digitala certifikatet i systemet kan det användas för att lägga till en digital signatur i presentationen via Arkiv -> Info -> Skydda presentation:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Presentationen kan innehålla mer än en digital signatur. När den digitala signaturen har lagts till i presentationen visas ett särskilt meddelande i PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

För att signera en presentation eller kontrollera äktheten av presentationssignaturer tillhandahåller **Aspose.Slides API** gränssnitten [**IDigitalSignature**](https://reference.aspose.com/slides/sv/net/aspose.slides/idigitalsignature)interface, [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/sv/net/aspose.slides/IDigitalSignatureCollection)interface och egenskapen [**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/sv/net/aspose.slides/ipresentation/properties/digitalsignatures). För närvarande stöds digitala signaturer endast för PPTX‑format.

## **Lägg till en digital signatur från ett PFX‑certifikat**

Kodexemplet nedan visar hur man lägger till en digital signatur från ett PFX‑certifikat:

1. Öppna PFX‑filen och ange PFX‑lösenordet till [**DigitalSignature**](https://reference.aspose.com/slides/sv/net/aspose.slides/digitalsignature)object.
1. Lägg till den skapade signaturen i presentationsobjektet.

```c#
using (Presentation pres = new Presentation())
{
    // Skapa DigitalSignature-objekt med PFX-fil och PFX-lösenord 
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", @"testpass1");

    // Kommentera ny digital signatur
    signature.Comments = "Aspose.Slides digital signing test.";

    // Lägg till digital signatur till presentationen
    pres.DigitalSignatures.Add(signature);

    // Spara presentationen
    pres.Save("SomePresentationSigned.pptx", SaveFormat.Pptx);
}
```

Nu är det möjligt att kontrollera om presentationen är digitalt signerad och inte har ändrats:

```c#
 // Öppna presentationen
using (Presentation pres = new Presentation("SomePresentationSigned.pptx"))
{
    if (pres.DigitalSignatures.Count > 0)
    {
        bool allSignaturesAreValid = true;

        Console.WriteLine("Signatures used to sign the presentation: ");

        // Kontrollera om alla digitala signaturer är giltiga
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

**Kan jag ta bort befintliga signaturer från en fil?**

Ja. Samlingen av digitala signaturer stöder att [ta bort enskilda objekt](https://reference.aspose.com/slides/sv/net/aspose.slides/digitalsignaturecollection/removeat/) och [rensa den helt](https://reference.aspose.com/slides/sv/net/aspose.slides/digitalsignaturecollection/clear/); efter att du har sparat filen kommer presentationen att vara utan signaturer.

**Blir filen "skrivskyddad" efter signering?**

Nej. En signatur bevarar integritet och författarskap men hindrar inte redigeringar. För att begränsa redigering kan du kombinera den med ["Skrivskyddad" eller ett lösenord](/slides/sv/net/password-protected-presentation/).

**Kommer signaturen att visas korrekt i olika versioner av PowerPoint?**

Signaturen är skapad för OOXML‑behållaren (PPTX). Moderna versioner av PowerPoint som stödjer OOXML‑signaturer visar statusen för sådana signaturer korrekt.