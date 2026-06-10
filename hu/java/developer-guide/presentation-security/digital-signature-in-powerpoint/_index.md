---
title: Digitális aláírások hozzáadása prezentációkhoz Java nyelven
linktitle: Digitális aláírás
type: docs
weight: 10
url: /hu/java/digital-signature-in-powerpoint/
keywords:
- digitális aláírás
- digitális tanúsítvány
- tanúsítvány kibocsátó
- PFX tanúsítvány
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Tanulja meg, hogyan lehet digitálisan aláírni a PowerPoint és OpenDocument fájlokat az Aspose.Slides for Java segítségével. Biztonságosan védi diáidat néhány másodperc alatt, világos kódrészletekkel."
---
## **Bevezetés**

**Digitális tanúsítvány** jelszóval védett PowerPoint prezentáció létrehozására szolgál, amelyet egy adott szervezet vagy személy készítettént jelölnek. A digitális tanúsítvány egy jogosult szervezet – tanúsítvány kibocsátó – felkeresésével szerezhető be. A digitális tanúsítvány telepítése után a prezentációhoz digitális aláírást adhatunk a Fájl -> Információ -> Prezentáció védelme menüponton keresztül:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Prezentáció több digitális aláírást is tartalmazhat. Miután a digitális aláírás hozzáadódik a prezentációhoz, a PowerPointban egy speciális üzenet jelenik meg:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

A prezentáció aláírásához vagy a prezentáció aláírásainak hitelességének ellenőrzéséhez a **Aspose.Slides API** biztosítja a [**IDigitalSignature**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IDigitalSignature) interfészt, a [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IDigitalSignatureCollection) interfészt és a [**IPresentation.getDigitalSignatures**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPresentation#getDigitalSignatures--) metódust. Jelenleg a digitális aláírások csak a PPTX formátumot támogatják.

## **Digitális aláírás hozzáadása PFX tanúsítványból**

Az alábbi kódrészlet bemutatja, hogyan adhatunk digitális aláírást egy PFX tanúsítványból:

1. Nyissa meg a PFX fájlt, és adja meg a PFX jelszót a [**DigitalSignature**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/DigitalSignature) objektumnak.
2. Adja hozzá a létrehozott aláírást a prezentáció objektumához.

```java
// A prezentáció fájl megnyitása
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

Most már ellenőrizhető, hogy a prezentáció digitálisan alá van-e írva, és nem lett-e módosítva:

```java
// Prezentáció megnyitása
Presentation pres = new Presentation("SomePresentationSigned.pptx");
try {
    if (pres.getDigitalSignatures().size() > 0)
    {
        boolean allSignaturesAreValid = true;

        System.out.println("Signatures used to sign the presentation: ");

        // Ellenőrizze, hogy minden digitális aláírás érvényes-e
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

Igen. A digitális aláírások gyűjteménye támogatja az [egyes elemek eltávolítását](https://reference.aspose.com/slides/hu/java/com.aspose.slides/digitalsignaturecollection/#removeAt-int-) valamint a [teljes törlést](https://reference.aspose.com/slides/hu/java/com.aspose.slides/digitalsignaturecollection/#clear--); a fájl mentése után a prezentációnak nem lesz aláírása.

**A fájl "csak olvasható" lesz aláírás után?**

Nem. Az aláírás megőrzi a szöveg integritását és szerzői jogát, de nem akadályozza a szerkesztést. A szerkesztés korlátozásához kombinálja a ["Csak olvasható" vagy jelszó](/slides/hu/java/password-protected-presentation/) opcióval.

**Megjelenik helyesen az aláírás a PowerPoint különböző verzióiban?**

Az aláírás az OOXML (PPTX) konténerhez készült. A modern PowerPoint verziók, amelyek támogatják az OOXML aláírásokat, helyesen jelenítik meg az ilyen aláírások állapotát.