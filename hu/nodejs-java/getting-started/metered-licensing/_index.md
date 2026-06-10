---
title: "Mérő licencelés"
type: docs
weight: 100
url: /hu/nodejs-java/metered-licensing/
keywords:
- licenc
- mérő licenc
- licenckulcsok
- nyilvános kulcs
- privát kulcs
- fogyasztási mennyiség
- PowerPoint
- OpenDocument
- bemutató
- Node.js
- JavaScript
- Aspose.Slides
description: "Ismerje meg, hogyan teszi lehetővé az Aspose.Slides for Node.js Java mérő licencelése, hogy rugalmasan dolgozzon PowerPoint és OpenDocument fájlokkal, és csak a ténylegesen felhasznált mennyiségért fizessen."
---
## **Bevezetés**

A mérő licenc egy licencelési mechanizmus, amelyet a meglévő licencelési módszerek mellett is használhat. Ha az Aspose.Slides API funkciók használata alapján szeretne számlázást, a mérő licencet választja.

## **Mérő kulcsok alkalmazása**

Amikor mérő licencet vásárol, kulcsokat kap (és nem licencfájlt). Ez a mérő kulcs a [Metered](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/metered/) osztállyal alkalmazható, amelyet az Aspose biztosít a mérés műveleteihez. További részletekért lásd a [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

1. Hozzon létre egy példányt a [Metered](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/metered/) osztályból.

1. Adja át a nyilvános és privát kulcsait a [setMeteredKey](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/metered/#setMeteredKey) metódusnak.

1. Végezzen némi feldolgozást (feladatok végrehajtása).

1. Hívja meg a `Metered` osztály [getConsumptionQuantity](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/metered/#getConsumptionQuantity) metódusát.

Látni fogja az eddig felhasznált API-kérések mennyiségét.

Ez a mintakód bemutatja, hogyan használja a mérő licencet:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Létrehozza a Metered osztály egy példányát
var metered = new aspose.slides.Metered();

// Átadja a nyilvános és privát kulcsokat a Metered objektumnak
metered.setMeteredKey("<valid public key>", "<valid private key>");

// Lekéri a felhasznált mennyiség értékét az API hívások előtt
var amountBefore = aspose.slides.Metered.getConsumptionQuantity();
console.log("Amount consumed before:", amountBefore);

// Végezzen itt valamilyen műveletet az Aspose.Slides API-val
// ...

// Lekéri a felhasznált mennyiség értékét az API hívások után
var amountAfter = aspose.slides.Metered.getConsumptionQuantity();
console.log("Amount consumed after:", amountAfter);
```

{{% alert color="warning" title="NOTE"  %}} 
A mérő licenc használatához stabil internetkapcsolat szükséges, mivel a licencelési mechanizmus folyamatosan az interneten keresztül kommunikál szolgáltatásainkkal és számításokat végez.
{{% /alert %}} 

## **GYIK**

**Használhatok mérő licencet egy normál (örökös vagy ideiglenes) licenccel együtt ugyanabban az alkalmazásban?**  
Igen. A mérő egy további licencelési mechanizmus, amely a meglévő [licencelési módszerek](/slides/hu/nodejs-java/licensing/) mellett használható. Az alkalmazás indításakor választhatja ki, melyik mechanizmust alkalmazza.

**Pontosan mi számít fogyasztásnak egy mérő licenc esetén: műveletek vagy fájlok?**  
Az API használat számít, vagyis a kérések vagy műveletek száma. A jelenlegi fogyasztást a [fogyasztás‑követő módszerek](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/metered/) segítségével érheti el.

**Alkalmas a mérő licenc mikro‑szolgáltatásokhoz és szerver‑ nélküli környezetekhez, ahol a példányok gyakran újraindulnak?**  
Igen. Mivel a számlázás API‑hívásonként történik, a gyakori hideg indításokkal járó forgatókönyvek kompatibilisek, feltéve hogy stabil hálózati hozzáférés áll rendelkezésre a mérő számításokhoz.

**Eltér-e a könyvtár funkcionalitása mérő licenc esetén a örökös licenchez képest?**  
Nem. Ez csak a licencelési és számlázási mechanizmust érinti; a termék képességei ugyanazok.

**Hogyan viszonyul a mérő licenc a próbaverzióhoz és az ideiglenes licenchez?**  
A próbaverzió korlátozásokkal és vízjelekkel rendelkezik, a [ideiglenes licenc](https://purchase.aspose.com/temporary-license/) 30 napra eltávolítja a korlátozásokat, a mérő licenc pedig eltávolítja a korlátozásokat és a tényleges használat alapján számol.

**Kontrollálhatom a költségvetést úgy, hogy automatikusan reagálok, ha a fogyasztási küszöböt meghaladják?**  
Igen. Gyakori gyakorlat, hogy időnként leolvassa a jelenlegi fogyasztást a [követő módszerek](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/metered/) segítségével, és saját korlátokat vagy riasztásokat állít be az alkalmazás vagy a megfigyelési szint szerint.