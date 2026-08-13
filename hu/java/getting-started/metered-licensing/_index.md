---
title: Mérő licencelés
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
description: "Ismerje meg, hogyan teszi lehetővé az Aspose.Slides for Java mérő licencelése, hogy rugalmasan dolgozzon fel PowerPoint és OpenDocument fájlokkal, és csak a felhasznált mennyiségért fizessen."
---
## **Bevezetés**

A mérő licencelés egy licencelési mechanizmus, amely a meglévő licencelési módszerek mellett is használható. Ha az Aspose.Slides API funkcióinak felhasználása alapján szeretne számlázást kapni, a mérő licencelést kell választania.

## **Mérő kulcsok alkalmazása**

{{% alert color="info" %}} 

A mérő licencelés egy új licencelési mechanizmus, amely a meglévő licencelési módszerek mellett is használható. Ha az Aspose.Slides API funkcióinak felhasználása alapján szeretne számlázást kapni, a mérő licencelést kell választania.

Amikor megvásárol egy mérő licencet, kulcsokat kap (és nem licencfájlt). Ez a mérő kulcs a Aspose által a mérés műveletekhez biztosított [Metered](https://reference.aspose.com/slides/hu/java/com.aspose.slides/metered/) osztállyal alkalmazható. További részletekért tekintse meg a [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered) oldalt.

{{% /alert %}} 

1. Hozzon létre egy példányt a [Metered](https://reference.aspose.com/slides/hu/java/com.aspose.slides/metered/) osztályból.

1. Adja át a nyilvános és privát kulcsait a [setMeteredKey](https://reference.aspose.com/slides/hu/java/com.aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-) metódusnak.

1. Végezzen némi feldolgozást (feladatok végrehajtása).

1. Hívja meg a `Metered` osztály [getConsumptionQuantity](https://reference.aspose.com/slides/hu/java/com.aspose.slides/metered/#getConsumptionQuantity--) metódusát.

Látnia kell a felhasznált API kérések mennyiségét/számát eddig.

Ez a példakód megmutatja, hogyan kell használni a mérő licencelést:

```java
// Létrehozza a Metered osztály egy példányát
com.aspose.slides.Metered metered = new com.aspose.slides.Metered();

try {
    // Átadja a nyilvános és privát kulcsokat a Metered objektumnak
    metered.setMeteredKey("<valid public key>", "<valid private key>");

    // Lekéri a felhasznált mennyiség értékét az API hívások előtt
    double amountBefore = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed before: " + amountBefore);

    // Valamit csinál az Aspose.Slides API-val itt
    // ...

    // Lekéri a felhasznált mennyiség értékét az API hívások után
    double amountAfter = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed after: " + amountAfter);
} catch (Exception ex) {
    ex.printStackTrace();
}
```

{{% alert color="warning" title="NOTE"  %}} 

A mérő licencelés használatához stabil internetkapcsolatra van szükség, mivel a licencelési mechanizmus az internetet használja folyamatosan a szolgáltatásainkkal való interakcióhoz és a számítások elvégzéséhez.

{{% /alert %}} 

## **FAQ**

### Használhatok mérő licencet egy hagyományos (örökös vagy ideiglenes) licenccel együtt ugyanabban az alkalmazásban?

Igen. A mérő egy további licencelési mechanizmus, amely a meglévő [licencelési módszerek](/slides/hu/java/licensing/) mellett is használható. Ön döntheti el, melyik mechanizmust alkalmazza az alkalmazás indításakor.

### Mi számít pontosan fogyasztásnak egy mérő licenc alatt: műveletek vagy fájlok?

Az API használat számít, vagyis a kérések vagy műveletek száma. Az aktuális fogyasztást a [consumption-tracking methods](https://reference.aspose.com/slides/hu/java/com.aspose.slides/metered/) segítségével kérheti le.

### Alkalmazható a mérő licenc microservice és serverless környezetekben, ahol a példányok gyakran újraindulnak?

Igen. Mivel az elszámolás API-hívás szinten történik, a gyakori hidegindításokkal járó forgatókönyvek kompatibilisek, feltéve hogy stabil hálózati hozzáférés áll rendelkezésre a mérő számításokhoz.

### Különbözik a könyvtár funkcionalitása mérő licenc használata esetén az örökös licenchez képest?

Nem. Ez csak a licencelési és számlázási mechanizmusra vonatkozik; a termék képességei ugyanazok.

### Hogyan viszonyul a mérő a próbaverzióhoz és az ideiglenes licenchez?

A próbaverzió korlátozásokkal és vízjelekkel rendelkezik, a [temporary license](https://purchase.aspose.com/temporary-license/) 30 napra eltávolítja a korlátozásokat, a mérő pedig eltávolítja a korlátozásokat és a tényleges felhasználás alapján számít fel díjat.

### Képes vagyok-e a költségvetést automatikusan szabályozni, ha a fogyasztási küszöböt túllépik?

Igen. Gyakori megoldás, hogy időnként leolvassa az aktuális fogyasztást a [tracking methods](https://reference.aspose.com/slides/hu/java/com.aspose.slides/metered/) segítségével, és saját korlátokat vagy riasztásokat valósít meg az alkalmazás vagy a megfigyelési szintjén.