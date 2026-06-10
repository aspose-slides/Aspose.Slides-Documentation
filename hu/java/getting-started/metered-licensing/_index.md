---
title: Mérő Licencelés
type: docs
weight: 100
url: /hu/java/metered-licensing/
keywords:
- licenc
- mérő licenc
- licenckulcsok
- nyilvános kulcs
- privát kulcs
- fogyasztási mennyiség
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan teszi lehetővé az Aspose.Slides for Java mérő licencelése a PowerPoint és OpenDocument fájlok rugalmas feldolgozását, csak a felhasznált mennyiségért fizetve."
---
## **Bevezetés**

A mérés alapú licencelés egy olyan licencmechanizmus, amely létező licencelési módszerekkel együttesen használható. Ha azt szeretné, hogy a Aspose.Slides API funkcióinak használata alapján kerüljenek számlázásra, a mérés alapú licencelést kell választania.

## **Mérőkulcsok alkalmazása**

{{% alert color="primary" %}} 

A mérés alapú licencelés egy új licencmechanizmus, amely létező licencelési módszerekkel együttesen használható. Ha azt szeretné, hogy a Aspose.Slides API funkcióinak használata alapján kerüljenek számlázásra, a mérés alapú licencelést kell választania.

Amikor metered licencet vásárol, kulcsokat kap (és nem licencfájlt). Ez a mérőkulcs a Aspose által biztosított [Metered](https://reference.aspose.com/slides/hu/java/com.aspose.slides/metered/) osztály használatával alkalmazható a mérési műveletekhez. További részletekért tekintse meg a [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered) oldalt.

{{% /alert %}} 

1. Hozzon létre egy példányt a [Metered](https://reference.aspose.com/slides/hu/java/com.aspose.slides/metered/) osztályból.

1. Adja át nyilvános és privát kulcsait a [setMeteredKey](https://reference.aspose.com/slides/hu/java/com.aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-) metódusnak.

1. Végezzen némi feldolgozást (feladatok végrehajtása).

1. `Metered` osztály [getConsumptionQuantity](https://reference.aspose.com/slides/hu/java/com.aspose.slides/metered/#getConsumptionQuantity--) metódusát hívja.

Látnia kell a eddig felhasznált API kérések mennyiségét/mennyiségét.

Ez a minta kód bemutatja, hogyan kell használni a mérés alapú licencelést:

```java
// Létrehoz egy példányt a Metered osztályból
com.aspose.slides.Metered metered = new com.aspose.slides.Metered();

try {
    // Átadja a nyilvános és privát kulcsokat a Metered objektumnak
    metered.setMeteredKey("<valid public key>", "<valid private key>");

    // Lekéri a felhasznált mennyiség értékét API hívások előtt
    double amountBefore = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed before: " + amountBefore);

    // Végezzen valamit az Aspose.Slides API-val itt
    // ...

    // Lekéri a felhasznált mennyiség értékét API hívások után
    double amountAfter = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed after: " + amountAfter);
} catch (Exception ex) {
    ex.printStackTrace();
}
```

{{% alert color="warning" title="NOTE"  %}} 

A mérés alapú licencelés használatához stabil internetkapcsolatra van szükség, mivel a licencmechanizmus az internetet használja folyamatosan a szolgáltatásainkkal való interakcióhoz és számítások végrehajtásához.

{{% /alert %}} 

## **GYIK**

**Használhatok metered licencet egy szokásos (örökös vagy ideiglenes) licenccel ugyanabban az alkalmazásban?**

Igen. A metered egy további licencmechanizmus, amely létező [licencelési módszerekkel](/slides/hu/java/licensing/) együttesen használható. Ön választja ki, melyik mechanizmust alkalmazza az alkalmazás indításakor.

**Mi számít pontosan fogyasztásnak egy metered licenc alatt: műveletek vagy fájlok?**

Az API használat számít, vagyis a kérések vagy műveletek száma. A jelenlegi fogyasztást a [consumption‑tracking methods](https://reference.aspose.com/slides/hu/java/com.aspose.slides/metered/) segítségével érheti el.

**Alkalmas a metered mikro‑szolgáltatásokhoz és szerver‑l nélküli környezetekhez, ahol a példányok gyakran újraindulnak?**

Igen. Mivel a nyilvántartás az API‑hívások szintjén történik, a gyakori hideg indításokkal járó forgatókönyvek kompatibilisek, feltéve hogy stabil hálózati hozzáférés áll rendelkezésre a metered számításokhoz.

**Eltér-e a könyvtár funkciója, ha metered licencet használunk a örökös licenchez képest?**

Nem. Ez csak a licencelési és számlázási mechanizmust érinti; a termék képességei ugyanazok.

**Hogyan viszonyul a metered a próbaverzióhoz és az ideiglenes licenchez?**

A próbaverzió korlátozásokkal és vízjelekkel rendelkezik, a [temporary license](https://purchase.aspose.com/temporary-license/) 30 napra eltávolítja a korlátozásokat, a metered pedig eltávolítja a korlátozásokat és a tényleges használat alapján számít fel díjat.

**Korlátozhatom a költségvetést úgy, hogy automatikusan reagálok, amikor a fogyasztási küszöböt meghaladja?**

Igen. Gyakori megoldás, hogy időközönként lekérdezi a jelenlegi fogyasztást a [tracking methods](https://reference.aspose.com/slides/hu/java/com.aspose.slides/metered/) segítségével, és saját korlátokat vagy riasztásokat valósít meg az alkalmazás vagy a felügyeleti szintjén.