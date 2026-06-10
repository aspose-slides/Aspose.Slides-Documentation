---
title: Mérő licencelés
type: docs
weight: 100
url: /hu/php-java/metered-licensing/
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
- PHP
- Aspose.Slides
description: "Ismerje meg, hogyan teszi lehetővé az Aspose.Slides for PHP via Java mérő licencelés a PowerPoint és OpenDocument fájlok rugalmas feldolgozását, úgy, hogy csak a felhasznált mennyiségért fizet."
---
## **Bevezetés**

A mérő licencelés egy olyan licencelési mechanizmus, amely a meglévő licencelési módszerekkel együtt használható. Ha az Aspose.Slides API funkcióinak használata alapján szeretne számlázást, a mérő licencelést válassza.

## **Mérő kulcsok alkalmazása**

Amikor megvásárol egy mérő licencet, kulcsokat (és nem licencfájlt) kap. Ezt a mérő kulcsot a [Metered](https://reference.aspose.com/slides/hu/php-java/aspose.slides/metered/) osztály segítségével lehet alkalmazni, amelyet az Aspose biztosít a méréshez. További részletekért tekintse meg a [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered) oldalt.

1. Hozzon létre egy példányt a [Metered](https://reference.aspose.com/slides/hu/php-java/aspose.slides/metered/) osztályból.

1. Adja át a nyilvános és privát kulcsait a [setMeteredKey](https://reference.aspose.com/slides/hu/php-java/aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-) metódusnak.

1. Végezzen némi feldolgozást (feladatok végrehajtása).

1. Hívja meg a `Metered` osztály [getConsumptionQuantity](https://reference.aspose.com/slides/hu/php-java/aspose.slides/metered/#getConsumptionQuantity--) metódusát.

Látnia kell a eddig felhasznált API‑kérések mennyiségét.

Ez a példakód megmutatja, hogyan használható a mérő licencelés:

```php
// Létrehozza a Metered osztály egy példányát
$metered = new Metered();

try {
    // Átadja a nyilvános és privát kulcsokat a Metered objektumnak
    $metered->setMeteredKey("<valid pablic key>", "<valid private key>");

    // Lekéri a felhasznált mennyiségi értéket az API hívások előtt
    $amountBefore = Metered::getConsumptionQuantity();
    echo("Amount consumed before: " . $amountBefore);

    // Itt végezzen valamilyen műveletet az Aspose.Slides API-val
    // ...

    // Lekéri a felhasznált mennyiségi értéket az API hívások után
    $amountAfter = Metered::getConsumptionQuantity();
    echo("Amount consumed after: " . $amountAfter);
} catch (JavaException $ex) {
  $ex->printStackTrace();
}
```

{{% alert color="warning" title="MEGJEGYZÉS" %}} 
A mérő licencelés használatához stabil internetkapcsolat szükséges, mivel a licencelési mechanizmus folyamatosan az interneten keresztül kommunikál szolgáltatásainkkal és számításokat végez.
{{% /alert %}} 

## **GYIK**

**Használhatok‑e mérő licencet egy hagyományos (örök vagy ideiglenes) licenc mellé ugyanabban az alkalmazásban?**

Igen. A mérő egy további licencelési mechanizmus, amely a meglévő [licencelési módszerek](/slides/hu/php-java/licensing/) mellett alkalmazható. Ön dönthet arról, melyik mechanizmust használja az alkalmazás indításakor.

**Mi számít pontosan fogyasztásnak egy mérő licenc esetén: műveletek vagy fájlok?**

Az API‑használat számít, vagyis a kérések vagy műveletek száma. Az aktuális fogyasztást a [fogyasztás‑nyomon követő módszerek](https://reference.aspose.com/slides/hu/php-java/aspose.slides/metered/) segítségével érheti el.

**Alkalmas‑e a mérő licenc mikroszervizekhez és szerver‑nélküli környezetekhez, ahol a példányok gyakran újraindulnak?**

Igen. Mivel a számlálás API‑hívásonként történik, a gyakori hidegindításokkal járó scenáriók is kompatibilisek, feltéve hogy stabil hálózati hozzáférés áll rendelkezésre a mérő számításokhoz.

**Eltér‑e a könyvtár funkcionalitása mérő licenc használata esetén az örök licenchez képest?**

Nem. Ez csak a licencelési és számlázási mechanizmust érinti; a termék képességei változatlanok.

**Hogyan viszonyul a mérő licenc a próbaverzióhoz és az ideiglenes licenchez?**

A próbaverziónak korlátai és vízjelei vannak, a [ideiglenes licenc](https://purchase.aspose.com/temporary-license/) 30 napra eltávolítja a korlátokat, a mérő pedig a korlátok eltávolítását és a tényleges használat alapján történő díjszámítást biztosítja.

**Képes vagyok‑e a költségvetést automatikusan szabályozni, ha a fogyasztási küszöböt meghaladja?**

Igen. Gyakori gyakorlat, hogy időközönként lekérdezik az aktuális fogyasztást a [nyomon követő módszerek](https://reference.aspose.com/slides/hu/php-java/aspose.slides/metered/) segítségével, és saját korlátokat vagy riasztásokat valósítanak meg az alkalmazás vagy a felügyeleti szintjén.