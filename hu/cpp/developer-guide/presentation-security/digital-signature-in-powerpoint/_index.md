---
title: Digitális aláírások hozzáadása prezentációkhoz C++-ban
linktitle: Digitális aláírás
type: docs
weight: 10
url: /hu/cpp/digital-signature-in-powerpoint/
keywords:
- digitális aláírás
- digitális tanúsítvány
- tanúsítvány kibocsátó
- PFX tanúsítvány
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Tanulja meg, hogyan lehet digitálisan aláírni a PowerPoint és OpenDocument fájlokat az Aspose.Slides for C++ segítségével. Biztosítsa diái biztonságát másodpercek alatt egyértelmű kódrészletekkel."
---
## **Bevezetés**

**Digitális tanúsítvány** használható jelszóval védett PowerPoint‑prezentáció létrehozására, amelyet egy adott szervezet vagy személy készítettéként jelölnek meg. Digitális tanúsítványt egy engedéllyel rendelkező szervezet‑, tanúsítványkiadó megkeresésével szerezhetünk be. A digitális tanúsítvány rendszerbe telepítése után a prezentációhoz digitális aláírást adhatunk a Fájl → Információk → Prezentáció védése menüpont segítségével:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Prezentáció több digitális aláírást is tartalmazhat. Miután a digitális aláírás hozzá lett adva a prezentációhoz, egy speciális üzenet jelenik meg a PowerPointban:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

A prezentáció aláírásához vagy a prezentáció aláírásainak hitelességének ellenőrzéséhez a **Aspose.Slides API** a [**IDigitalSignature**](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_digital_signature) interfészt, a [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_digital_signature_collection) interfészt és a [**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_presentation#a6f78aff0f8ffa07ff67368fa003722b1) metódust biztosítja. Jelenleg a digitális aláírások csak a PPTX formátumhoz támogatottak.

## **Digitális aláírás hozzáadása PFX tanúsítványból**
A lenti kódrészlet bemutatja, hogyan adhatunk digitális aláírást egy PFX tanúsítványból:

1. Nyissa meg a PFX fájlt, és adja meg a PFX jelszót a [**DigitalSignature**](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.digital_signature) objektumnak.
2. Adja hozzá a létrehozott aláírást a prezentáció objektumhoz.

``` cpp
auto pres = System::MakeObject<Presentation>();

// DigitalSignature objektum létrehozása PFX fájllal és PFX jelszóval 
auto signature = System::MakeObject<DigitalSignature>(u"testsignature1.pfx", u"testpass1");

// Új digitális aláírás megjegyzése
signature->set_Comments(u"Aspose.Slides digital signing test.");

// Digitális aláírás hozzáadása a prezentációhoz
pres->get_DigitalSignatures()->Add(signature);

// Prezentáció mentése
pres->Save(u"SomePresentationSigned.pptx", SaveFormat::Pptx);
```

Most már ellenőrizhető, hogy a prezentáció digitálisan alá van-e írva, és nem módosult-e:

``` cpp
// Prezentáció megnyitása
auto pres = System::MakeObject<Presentation>(u"SomePresentationSigned.pptx");

if (pres->get_DigitalSignatures()->get_Count() > 0)
{
    bool allSignaturesAreValid = true;

    Console::WriteLine(u"Signatures used to sign the presentation: ");

    // Ellenőrizze, hogy minden digitális aláírás érvényes-e
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

## **GYIK**

**Eltávolíthatok meglévő aláírásokat egy fájlból?**

Igen. A digitális aláírások gyűjteménye támogatja az egyes elemek eltávolítását, valamint a teljes törlést; a fájl mentése után a prezentációnak már nincsenek aláírásai.

**A fájl csak‑olvasásra áll-e a aláírás után?**

Nem. Az aláírás megőrzi a dokumentum integritását és szerzői jogait, de nem akadályozza a szerkesztést. A szerkesztés korlátozásához kombinálja a ["Csak‑olvasás" vagy egy jelszó](/slides/hu/cpp/password-protected-presentation/) opcióval.

**Megjelenik helyesen a különböző PowerPoint verziókban az aláírás?**

Az aláírás az OOXML (PPTX) konténerhez készült. A modern PowerPoint‑verziók, amelyek támogatják az OOXML aláírásokat, helyesen jelenítik meg az ilyen aláírások állapotát.