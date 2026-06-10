---
title: Digitális aláírások hozzáadása prezentációkhoz Androidon
linktitle: Digitális aláírás
type: docs
weight: 10
url: /hu/androidjava/digital-signature-in-powerpoint/
keywords:
- digitális aláírás
- digitális tanúsítvány
- tanúsítvány kibocsátó
- PFX tanúsítvány
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan lehet digitálisan aláírni PowerPoint és OpenDocument fájlokat az Androidra készült Aspose.Slides segítségével. Biztosítsa diákját másodpercek alatt világos Java kódrészletekkel."
---
## **Bevezetés**

**Digitális tanúsítvány** arra szolgál, hogy jelszóval védett PowerPoint‑prezentációt hozzunk létre, amelyet egy adott szervezet vagy személy készített. A digitális tanúsítványt egy hitelesített szervezettel – egy tanúsítvány kibocsátóval (CA) – felveve lehet beszerezni. A digitális tanúsítvány rendszerbe telepítése után használható a prezentáció digitális aláírásához a Fájl -> Info -> Prezentáció védelme menüpontban:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

A prezentáció több digitális aláírást is tartalmazhat. Miután a digitális aláírás hozzá lett adva a prezentációhoz, egy speciális üzenet jelenik meg a PowerPointban:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

A prezentáció aláírásához vagy a prezentáció aláírásainak hitelességének ellenőrzéséhez a **Aspose.Slides API** biztosítja a [**IDigitalSignature**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IDigitalSignature) interfészt, a [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IDigitalSignatureCollection) interfészt és a [**IPresentation.getDigitalSignatures**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPresentation#getDigitalSignatures--) metódust. Jelenleg a digitális aláírások csak a PPTX formátumra támogatottak.

## **Digitális aláírás hozzáadása PFX tanúsítványból**

Az alábbi kódrészlet bemutatja, hogyan adhatunk digitális aláírást egy PFX tanúsítványból:

1. Nyissa meg a PFX fájlt, és adja meg a PFX jelszót a [**DigitalSignature**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/DigitalSignature) objektumnak.
2. Adja hozzá a létrehozott aláírást a prezentáció objektumhoz.

```java
// A prezentációfájl megnyitása
Presentation pres = new Presentation();
try {
    // DigitalSignature objektum létrehozása PFX fájllal és PFX jelszóval 
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", "testpass1");

    // Új digitális aláírás megjegyzése
    signature.setComments("Aspose.Slides digital signing test.");

    // Digitális aláírás hozzáadása a prezentációhoz
    pres.getDigitalSignatures().add(signature);

    // Prezentáció mentése
    pres.save("SomePresentationSigned.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Most már ellenőrizhető, hogy a prezentáció digitálisan alá van-e írva, és nem módosult-e:

```java
// Prezentáció megnyitása
Presentation pres = new Presentation("SomePresentationSigned.pptx");
try {
    if (pres.getDigitalSignatures().size() > 0)
    {
        boolean allSignaturesAreValid = true;

        System.out.println("Signatures used to sign the presentation: ");

        // Ellenőrizze, hogy az összes digitális aláírás érvényes-e
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

## **GYIK**

**Eltávolíthatok meglévő aláírásokat egy fájlból?**

Igen. A digitális aláírások gyűjteménye támogatja az [egyes elemek eltávolítását](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/digitalsignaturecollection/#removeAt-int-) és a [teljes törlést](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/digitalsignaturecollection/#clear--); a fájl mentése után a prezentációnak nem lesznek aláírásai.

**A fájl írásvédetté válik aláírás után?**

Nem. Egy aláírás megőrzi a hitelességet és a szerzői jogot, de nem blokkolja a szerkesztést. A szerkesztés korlátozásához kombinálja azt a ["Olvasásvédett" vagy jelszó](/slides/hu/androidjava/password-protected-presentation/) opcióval.

**Az aláírás helyesen jelenik meg a PowerPoint különböző verzióiban?**

Az aláírás az OOXML (PPTX) konténerhez van létrehozva. A modern PowerPoint‑verziók, amelyek támogatják az OOXML aláírásokat, helyesen jelenítik meg ezen aláírások állapotát.