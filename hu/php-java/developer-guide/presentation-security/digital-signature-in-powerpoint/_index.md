---
title: Digitális aláírások hozzáadása prezentációkhoz PHP-ben
linktitle: Digitális aláírás
type: docs
weight: 10
url: /hu/php-java/digital-signature-in-powerpoint/
keywords:
- digitális aláírás
- digitális tanúsítvány
- tanúsítványkiadó
- PFX tanúsítvány
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Ismerje meg, hogyan lehet digitálisan aláírni a PowerPoint és OpenDocument fájlokat az Aspose.Slides for PHP (Java-on keresztül) segítségével. Biztonságossá tegye diavetítéseit másodpercek alatt egyértelmű kódrészletekkel."
---
## **Bevezetés**

**Digitális tanúsítvány** a jelszóval védett powerpoint prezentáció létrehozásához használható, amelyet egy adott szervezet vagy személy készítettnek jelölnek. A digitális tanúsítványt egy hitelesített szervezet - egy tanúsítványkiadó felkeresésével lehet beszerezni. A digitális tanúsítvány telepítése után a rendszerben használható a prezentációhoz digitális aláírás hozzáadásához a File -> Info -> Protect Presentation menüpontban:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

A prezentáció több digitális aláírást is tartalmazhat. Miután a digitális aláírás hozzá lett adva a prezentációhoz, egy speciális üzenet jelenik meg a PowerPointban:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

A prezentáció aláírásához vagy a prezentáció aláírásainak hitelességének ellenőrzéséhez az **Aspose.Slides API** a [**DigitalSignature**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/DigitalSignature) osztályt, a [**DigitalSignatureCollection**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/DigitalSignatureCollection) osztályt és a [**Presentation::getDigitalSignatures**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation/#getDigitalSignatures) metódust biztosítja. Jelenleg a digitális aláírások csak a PPTX formátumhoz vannak támogatva.

## **Digitális aláírás hozzáadása PFX tanúsítványból**

Az alábbi kódrészlet bemutatja, hogyan adhatunk digitális aláírást egy PFX tanúsítványból:

1. Nyissa meg a PFX fájlt, és adja át a PFX jelszót a [**DigitalSignature**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/DigitalSignature) objektumnak.
2. Adja hozzá a létrehozott aláírást a prezentáció objektumhoz.

```php
  # A prezentációs fájl megnyitása
  $pres = new Presentation();
  try {
    # DigitalSignature objektum létrehozása PFX fájllal és PFX jelszóval
    $signature = new DigitalSignature("testsignature1.pfx", "testpass1");
    # Új digitális aláírás megjegyzése
    $signature->setComments("Aspose.Slides digital signing test.");
    # Digitális aláírás hozzáadása a prezentációhoz
    $pres->getDigitalSignatures()->add($signature);
    # Prezentáció mentése
    $pres->save("SomePresentationSigned.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

Most már ellenőrizhető, hogy a prezentáció digitálisan aláírt‑e, és nem módosult‑e:

```php
  # Prezentáció megnyitása
  $pres = new Presentation("SomePresentationSigned.pptx");
  try {
    if (java_values($pres->getDigitalSignatures()->size()) > 0) {
      $allSignaturesAreValid = true;
      echo("Signatures used to sign the presentation: ");
      # Ellenőrizze, hogy az összes digitális aláírás érvényes-e
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

## **GYIK**

**Eltávolíthatok meglévő aláírásokat egy fájlból?**

Igen. A digitális aláírások gyűjteménye támogatja az [egyedi elemek eltávolítását](https://reference.aspose.com/slides/hu/php-java/aspose.slides/digitalsignaturecollection/removeat/) és a [teljes törlést](https://reference.aspose.com/slides/hu/php-java/aspose.slides/digitalsignaturecollection/clear/); a fájl mentése után a prezentációnak nem lesz aláírása.

**Válik a fájl aláírás után „csak olvashatóvá”?**

Nem. Az aláírás megőrzi a integritást és a szerzői jogot, de nem akadályozza a szerkesztést. A szerkesztés korlátozásához kombinálja azt a ["Read-only" vagy jelszó](/slides/hu/php-java/password-protected-presentation/) lehetőséggel.

**Megjelenik‑e az aláírás helyesen a PowerPoint különböző verzióiban?**

Az aláírás az OOXML (PPTX) konténerhez lett létrehozva. A modern PowerPoint verziók, amelyek támogatják az OOXML aláírásokat, helyesen jelenítik meg az ilyen aláírások állapotát.