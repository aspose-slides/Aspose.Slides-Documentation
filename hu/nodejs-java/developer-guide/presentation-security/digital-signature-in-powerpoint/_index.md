---
title: Digitális aláírások hozzáadása prezentációkhoz JavaScriptben
linktitle: Digitális aláírás
type: docs
weight: 10
url: /hu/nodejs-java/digital-signature-in-powerpoint/
keywords:
- digitális aláírás
- digitális tanúsítvány
- tanúsítvány kibocsátó
- PFX tanúsítvány
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Tanulja meg, hogyan lehet digitálisan aláírni PowerPoint és OpenDocument fájlokat az Aspose.Slides for Node.js segítségével Java-ban. Biztonságosan védje diáiát másodpercek alatt egyértelmű kódpéldákkal."
---
## **Bevezetés**

**Digitális tanúsítvány** is used to create a password protected PowerPoint presentation, marked as created by a particular organization or person. Digitális tanúsítvány can be obtained by contacting an authorized organization - a certificate authority. After installing digitális tanúsítvány into the system, it can be used to add a digital signature to the presentation via File -> Info -> Protect Presentation:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

A prezentáció több digitális aláírást is tartalmazhat. Miután a digitális aláírás hozzá lett adva a prezentációhoz, egy speciális üzenet jelenik meg a PowerPointban:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

A prezentáció aláírásához vagy az aláírások hitelességének ellenőrzéséhez a **Aspose.Slides API** a [**DigitalSignature**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/DigitalSignature) osztályt, a [**DigitalSignatureCollection**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/DigitalSignatureCollection) osztályt és a [**Presentation.getDigitalSignatures**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation#getDigitalSignatures--) metódust biztosítja. Jelenleg a digitális aláírások csak a PPTX formátumban támogatottak.

## **Digitális aláírás hozzáadása PFX tanúsítványból**
Az alábbi kódminta bemutatja, hogyan adhatunk hozzá digitális aláírást egy PFX tanúsítványból:

1. Nyissa meg a PFX fájlt, és adja át a PFX jelszót a [**DigitalSignature**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/DigitalSignature) objektumnak.
1. Adja hozzá a létrehozott aláírást a prezentáció objektumhoz.

```javascript
// A prezentációfájl megnyitása
var pres = new aspose.slides.Presentation();
try {
    // DigitalSignature objektum létrehozása PFX fájlból és PFX jelszóval
    var signature = new aspose.slides.DigitalSignature("testsignature1.pfx", "testpass1");
    // Új digitális aláírás megjegyzése
    signature.setComments("Aspose.Slides digital signing test.");
    // Digitális aláírás hozzáadása a prezentációhoz
    pres.getDigitalSignatures().add(signature);
    // Prezentáció mentése
    pres.save("SomePresentationSigned.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Most már ellenőrizhető, hogy a prezentáció digitálisan alá van-e írva, és nem módosult-e:

```javascript
// Prezentáció megnyitása
var pres = new aspose.slides.Presentation("SomePresentationSigned.pptx");
try {
    if (pres.getDigitalSignatures().size() > 0) {
        var allSignaturesAreValid = true;
        console.log("Signatures used to sign the presentation: ");
        // Ellenőrizze, hogy az összes digitális aláírás érvényes-e
        for (let i = 0; i < pres.getDigitalSignatures().size(); i++) {
        let signature = pres.getDigitalSignatures().get_Item(i);
            console.log((((signature.getComments() + ", ") + signature.getSignTime().toString()) + " -- ") + (signature.isValid() ? "VALID" : "INVALID"));
            allSignaturesAreValid &= signature.isValid();
        }
        if (allSignaturesAreValid) {
            console.log("Presentation is genuine, all signatures are valid.");
        } else {
            console.log("Presentation has been modified since signing.");
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **GYIK**

**Eltávolíthatok meglévő aláírásokat egy fájlból?**

Igen. A digitális aláírások gyűjteménye támogatja az [egyéni elemek eltávolítását](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/digitalsignaturecollection/removeat/) és a [teljes törlést](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/digitalsignaturecollection/clear/); a fájl mentése után a prezentáció nem lesz aláírva.

**A fájl írásvédett lesz az aláírás után?**

Nem. Az aláírás megőrzi a hitelességet és a szerzői jogot, de nem akadályozza a szerkesztést. A szerkesztés korlátozásához kombinálja azt a ["Read-only" or a password](/slides/hu/nodejs-java/password-protected-presentation/) opcióval.

**Az aláírás helyesen jelenik meg a PowerPoint különböző verzióiban?**

Az aláírás az OOXML (PPTX) konténerhez van létrehozva. A modern PowerPoint verziók, amelyek támogatják az OOXML aláírásokat, helyesen jelenítik meg az ilyen aláírások állapotát.