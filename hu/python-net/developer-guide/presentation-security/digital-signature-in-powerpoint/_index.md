---
title: Digitális aláírások hozzáadása prezentációkhoz Pythonban
linktitle: Digitális aláírás
type: docs
weight: 10
url: /hu/python-net/digital-signature-in-powerpoint/
keywords:
- digitális aláírás
- digitális tanúsítvány
- tanúsítványkiadó
- PFX tanúsítvány
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Ismerje meg, hogyan lehet digitálisan aláírni PowerPoint és OpenDocument fájlokat az Aspose.Slides for Python via .NET segítségével. Biztonságosan védeje diákját néhány másodperc alatt egyértelmű kódpéldákkal."
---
## **Bevezetés**

**Digitális tanúsítvány** használható jelszóval védett PowerPoint prezentáció létrehozására, amelyet egy adott szervezet vagy személy készítettként jelölnek meg. A digitális tanúsítványt egy jogosult szervezet – tanúsítvány kibocsátó – felkeresésével lehet megszerezni. A digitális tanúsítvány rendszerbe telepítése után használható digitális aláírás hozzáadására a prezentációhoz a Fájl -> Információ -> Prezentáció védelme útján:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

A prezentáció több digitális aláírást is tartalmazhat. Miután a digitális aláírás hozzá lett adva a prezentációhoz, egy speciális üzenet jelenik meg a PowerPointban:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

A prezentáció aláírásához vagy az aláírások hitelességének ellenőrzéséhez a **Aspose.Slides API** biztosítja a [**DigitalSignature**](https://reference.aspose.com/slides/hu/python-net/aspose.slides/digitalsignature/) osztályt, a [**DigitalSignatureCollection**](https://reference.aspose.com/slides/hu/python-net/aspose.slides/DigitalSignatureCollection/) osztályt és a [**Presentation.digital_signatures**](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/digital_signatures/) tulajdonságot. Jelenleg a digitális aláírások csak a PPTX formátumhoz támogatottak.

## **Digitális aláírás hozzáadása PFX tanúsítványból**

Az alábbi kódrészlet bemutatja, hogyan adhatunk hozzá digitális aláírást egy PFX tanúsítványból:

1. Nyissa meg a PFX fájlt, és adja át a PFX jelszót a [**DigitalSignature**](https://reference.aspose.com/slides/hu/python-net/aspose.slides/digitalsignature/) objektumnak.
2. Adja hozzá a létrehozott aláírást a prezentáció objektumhoz.

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    # Létrehozza a DigitalSignature objektumot PFX fájllal és PFX jelszóval 
    signature = slides.DigitalSignature(path + "testsignature1.pfx", "testpass1")

    # Megjegyzés új digitális aláíráshoz
    signature.comments = "Aspose.Slides digital signing test."

    # Digitális aláírás hozzáadása a prezentációhoz
    pres.digital_signatures.add(signature)

    # prezentáció mentése
    pres.save("SomePresentationSigned.pptx", slides.export.SaveFormat.PPTX)
```

Most már ellenőrizhető, hogy a prezentáció digitálisan aláírt‑e és nem módosult‑e:

```py
# Nyissa meg a prezentációt
with slides.Presentation("SomePresentationSigned.pptx") as pres:
    if len(pres.digital_signatures) > 0:
        allSignaturesAreValid = True

        print("Signatures used to sign the presentation: ")
        # Ellenőrizze, hogy minden digitális aláírás érvényes-e
        for signature in pres.digital_signatures :
            print(signature.certificate.subject_name.name + ", "
                    + signature.sign_time.strftime("yyyy-MM-dd HH:mm") + " -- " + "VALID" if signature.is_valid else "INVALID")
            allSignaturesAreValid = allSignaturesAreValid and signature.is_valid
        

        if allSignaturesAreValid:
            print("Presentation is genuine, all signatures are valid.")
        else:
            print("Presentation has been modified since signing.")
```

## **GYIK**

**Eltávolíthatok meglévő aláírásokat egy fájlból?**

Igen. A digitális aláírások gyűjteménye támogatja az [egyedi elemek eltávolítását](https://reference.aspose.com/slides/hu/python-net/aspose.slides/digitalsignaturecollection/remove_at/) és a [teljes kiürítést](https://reference.aspose.com/slides/hu/python-net/aspose.slides/digitalsignaturecollection/clear/); a fájl mentése után a prezentációnak már nem lesz aláírása.

**A fájl csak olvasható lesz aláírás után?**

Nem. Az aláírás megőrzi a integritást és a szerzői jogot, de nem akadályozza a módosításokat. A szerkesztés korlátozásához kombinálja a ["Csak olvasható" vagy jelszó](/slides/hu/python-net/password-protected-presentation/) lehetőséggel.

**Az aláírás helyesen jelenik meg a PowerPoint különböző verzióiban?**

Az aláírás az OOXML (PPTX) konténerhez készül. A modern PowerPoint verziók, amelyek támogatják az OOXML aláírásokat, helyesen jelenítik meg az ilyen aláírások állapotát.