---
title: Lägg till digitala signaturer i presentationer i Java
linktitle: Digital signatur
type: docs
weight: 10
url: /sv/java/digital-signature-in-powerpoint/
keywords:
- digital signatur
- digitalt certifikat
- certifikatutfärdare
- PFX-certifikat
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Lär dig hur du digitalt signerar PowerPoint- och OpenDocument-filer med Aspose.Slides för Java. Säkerställ dina bilder på sekunder med tydliga kodexempel."
---
## **Introduktion**

**Digital certificate** används för att skapa en lösenordsskyddad PowerPoint-presentation, markerad som skapad av en viss organisation eller person. Digitalt certifikat kan erhållas genom att kontakta en auktoriserad organisation - en certifikatutfärdare. Efter att ha installerat det digitala certifikatet i systemet kan det användas för att lägga till en digital signatur i presentationen via File -> Info -> Protect Presentation:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Presentation kan innehålla mer än en digital signatur. Efter att den digitala signaturen har lagts till i presentationen visas ett speciellt meddelande i PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

För att signera en presentation eller kontrollera äktheten hos presentationssignaturer tillhandahåller **Aspose.Slides API** [**IDigitalSignature**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IDigitalSignature)-gränssnittet, [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IDigitalSignatureCollection)-gränssnittet och [**IPresentation.getDigitalSignatures**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IPresentation#getDigitalSignatures--)‑metoden. För närvarande stöds digitala signaturer endast för PPTX‑format.

## **Lägg till en digital signatur från ett PFX‑certifikat**
Kodexemplet nedan demonstrerar hur man lägger till en digital signatur från ett PFX‑certifikat:

1. Öppna PFX‑filen och skicka PFX‑lösenordet till [**DigitalSignature**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/DigitalSignature)-objektet.
1. Lägg till den skapade signaturen i presentationsobjektet.

```java
// Öppnar presentationsfilen
Presentation pres = new Presentation();
try {
    // Skapa DigitalSignature-objekt med PFX-fil och PFX-lösenord
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", "testpass1");

    // Kommentar för ny digital signatur
    signature.setComments("Aspose.Slides digital signing test.");

    // Lägg till digital signatur i presentationen
    pres.getDigitalSignatures().add(signature);

    // Spara presentationen
    pres.save("SomePresentationSigned.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Nu är det möjligt att kontrollera om presentationen har signerats digitalt och inte har ändrats:

```java
// Öppna presentationen
Presentation pres = new Presentation("SomePresentationSigned.pptx");
try {
    if (pres.getDigitalSignatures().size() > 0)
    {
        boolean allSignaturesAreValid = true;

        System.out.println("Signatures used to sign the presentation: ");

        // Kontrollera om alla digitala signaturer är giltiga
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

## **Vanliga frågor**

**Kan jag ta bort befintliga signaturer från en fil?**

Ja. Samlingen med digitala signaturer stöder [ta bort enskilda objekt](https://reference.aspose.com/slides/sv/java/com.aspose.slides/digitalsignaturecollection/#removeAt-int-) och [tömma den helt](https://reference.aspose.com/slides/sv/java/com.aspose.slides/digitalsignaturecollection/#clear--); efter att du sparat filen kommer presentationen inte ha några signaturer.

**Blir filen "skrivskyddad" efter signering?**

Nej. En signatur bevarar integritet och författarskap men blockerar inte redigering. För att begränsa redigering, kombinera den med ["Read-only" eller ett lösenord](/slides/sv/java/password-protected-presentation/).

**Kommer signaturen att visas korrekt i olika versioner av PowerPoint?**

Signaturen skapas för OOXML‑behållaren (PPTX). Moderna versioner av PowerPoint som stöder OOXML‑signaturer visar statusen för sådana signaturer korrekt.