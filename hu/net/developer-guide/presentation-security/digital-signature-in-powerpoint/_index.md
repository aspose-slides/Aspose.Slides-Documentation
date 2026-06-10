---
title: Digitális aláírások hozzáadása prezentációkhoz .NET-ben
linktitle: Digitális aláírás
type: docs
weight: 10
url: /hu/net/digital-signature-in-powerpoint/
keywords:
- digitális aláírás
- digitális tanúsítvány
- tanúsító hatóság
- PFX tanúsítvány
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Tanulja meg, hogyan írhat digitálisan alá PowerPoint és OpenDocument fájlokat az Aspose.Slides for .NET segítségével. Biztosítsa diait másodpercek alatt egyértelmű kódpéldákkal."
---
## **Bevezetés**

**Digitális tanúsítvány** által jelszóval védett PowerPoint‑prezentáció hozható létre, amelyet egy adott szervezet vagy személy hozott létre. A digitális tanúsítványt egy hitelesített szervezet – egy tanúsító hatóság felkeresésével lehet beszerezni. A digitális tanúsítvány telepítése után használható a prezentáció digitális aláírásának hozzáadására a **Fájl** → **Infó** → **Prezentáció védelme** menüpontokon keresztül:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Prezentáció több digitális aláírást is tartalmazhat. Miután a digitális aláírás hozzá lett adva a prezentációhoz, egy speciális üzenet jelenik meg a PowerPointban:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

A prezentáció aláírásához vagy a prezentáció aláírásainak hitelességének ellenőrzéséhez a **Aspose.Slides API** a [**IDigitalSignature**](https://reference.aspose.com/slides/hu/net/aspose.slides/idigitalsignature) interfészt, a [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/hu/net/aspose.slides/IDigitalSignatureCollection) interfészt és a [**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentation/properties/digitalsignatures) tulajdonságot biztosítja. Jelenleg a digitális aláírások csak PPTX formátum esetén támogatottak.

## **Digitális aláírás hozzáadása PFX tanúsítványból**

Az alábbi kódrészlet bemutatja, hogyan adhatsz digitális aláírást egy PFX tanúsítványból:

1. Nyisd meg a PFX fájlt, és add át a PFX jelszót a [**DigitalSignature**](https://reference.aspose.com/slides/hu/net/aspose.slides/digitalsignature) objektumnak.
1. Add hozzá a létrehozott aláírást a prezentáció objektumhoz.

```c#
using (Presentation pres = new Presentation())
{
    // Hozzon létre DigitalSignature objektumot PFX fájllal és PFX jelszóval 
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", @"testpass1");

    // Megjegyzés az új digitális aláíráshoz
    signature.Comments = "Aspose.Slides digital signing test.";

    // Digitális aláírás hozzáadása a prezentációhoz
    pres.DigitalSignatures.Add(signature);

    // Prezentáció mentése
    pres.Save("SomePresentationSigned.pptx", SaveFormat.Pptx);
}
```

Most már lehetséges ellenőrizni, hogy a prezentáció digitálisan alá van-e írva, és nem módosult-e:

```c#
// Prezentáció megnyitása
using (Presentation pres = new Presentation("SomePresentationSigned.pptx"))
{
    if (pres.DigitalSignatures.Count > 0)
    {
        bool allSignaturesAreValid = true;

        Console.WriteLine("Signatures used to sign the presentation: ");

        // Ellenőrizze, hogy az összes digitális aláírás érvényes-e
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

## **GYIK**

**Eltávolíthatok meglévő aláírásokat egy fájlból?**

Igen. A digitális aláírások gyűjteménye támogatja az [egyedi tételek eltávolítását](https://reference.aspose.com/slides/hu/net/aspose.slides/digitalsignaturecollection/removeat/) és a [teljes törlést](https://reference.aspose.com/slides/hu/net/aspose.slides/digitalsignaturecollection/clear/); a fájl mentése után a prezentációnak nem lesz aláírása.

**A fájl "csak olvasható" lesz az aláírás után?**

Nem. Az aláírás megőrzi az integritást és a szerzői jogot, de nem gátolja a szerkesztést. A szerkesztés korlátozásához kombináld a ["Csak olvasható" vagy jelszó](/slides/hu/net/password-protected-presentation/) opcióval.

**Megjelenik-e helyesen az aláírás a PowerPoint különböző verzióiban?**

Az aláírás az OOXML (PPTX) konténerhez van létrehozva. A modern PowerPoint‑verziók, amelyek támogatják az OOXML aláírásokat, helyesen jelenítik meg az ilyen aláírások állapotát.