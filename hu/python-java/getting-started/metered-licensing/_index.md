---
title: Mérői licencelés
type: docs
weight: 100
url: /hu/python-java/metered-licensing/
keywords:
- licenc
- mérői licenc
- licenckulcsok
- nyilvános kulcs
- privát kulcs
- fogyasztási mennyiség
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Ismerje meg, hogyan teszi lehetővé az Aspose.Slides for Python via Java mérői licencelés a PowerPoint és OpenDocument fájlok rugalmas feldolgozását, és csak a felhasznált mennyiségért fizet."
---
## **Bevezetés**

A mérői licencelés egy olyan licencelési mechanizmus, amely meglévő licencelési módszerek mellett is használható. Ha az Aspose.Slides API funkcióinak használata alapján szeretne számlázást, válassza a mérői licencelést.

## **Mérői kulcsok alkalmazása**

{{% alert color="info" title="Note" %}}

A mérői licencelés egy új licencelési mechanizmus, amely meglévő licencelési módszerek mellett is használható. Ha az Aspose.Slides API funkcióinak használata alapján szeretne számlázást, válassza a mérői licencelést.

Amikor mérői licencet vásárol, kulcsokat kap (és nem licencfájlt). Ez a mérői kulcs alkalmazható az Aspose által a mérés műveletekhez biztosított [Metered](https://reference.aspose.com/slides/hu/python-java/aspose.slides/metered/) osztály használatával. További részletekért lásd a [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered) oldalt.

{{% /alert %}}

1. Hozzon létre egy példányt a [Metered](https://reference.aspose.com/slides/hu/python-java/aspose.slides/metered/) osztályból.

1. Adja át nyilvános és privát kulcsait a [setMeteredKey](https://reference.aspose.com/slides/hu/python-java/aspose.slides/metered/#setMeteredKey) metódusnak.

1. Végezzen némi feldolgozást (feladatok végrehajtása).

1. Hívja meg a [getConsumptionQuantity](https://reference.aspose.com/slides/hu/python-java/aspose.slides/metered/#getConsumptionQuantity) metódust a [Metered](https://reference.aspose.com/slides/hu/python-java/aspose.slides/metered/) osztályon.

Látnia kell az eddig felhasznált API‑kérések mennyiségét/kvantumát.

Ez a példa kód megmutatja, hogyan használja a mérői licencelést:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpway.startJVM()

from asposeslides.api import Metered

# Hozzon létre egy példányt a Metered osztályból.
metered = Metered()

try:
    # Adja át a nyilvános és privát kulcsokat a Metered objektumnak.
    metered.setMeteredKey("<valid public key>", "<valid private key>")

    # Szerezze be a felhasznált mennyiséget az API hívások előtt.
    amount_before = Metered.getConsumptionQuantity()
    print("Amount consumed before:", amount_before)

    # Végezzen valamilyen műveletet az Aspose.Slides API-val itt.
    # ...

    # Szerezze be a felhasznált mennyiséget az API hívások után.
    amount_after = Metered.getConsumptionQuantity()
    print("Amount consumed after:", amount_after)
except Exception as error:
    print(error)
```

{{% alert color="warning" title="Warning"  %}}

A mérői licencelés használatához stabil internetkapcsolat szükséges, mivel a licencelési mechanizmus folyamatosan az interneten keresztül kommunikál a szolgáltatásainkkal és számításokat végez.

{{% /alert %}}

## **GYIK**

**Használhatok mérői licencet egy hagyományos (örökös vagy ideiglenes) licenccel ugyanabban az alkalmazásban?**

Igen. A mérői licenc egy további licencelési mechanizmus, amely a meglévő [licencelési módszerek](/slides/hu/python-java/licensing/) mellett használható. A alkalmazás indításakor választható, melyik mechanizmust alkalmazza.

**Mi számít tényleges fogyasztásnak a mérői licenc alatt: műveletek vagy fájlok?**

Az API használat számít, vagyis a kérések vagy műveletek száma. A jelenlegi fogyasztást a [fogyasztás‑követő metódusok](https://reference.aspose.com/slides/hu/python-java/aspose.slides/metered/) segítségével lehet lekérdezni.

**Alkalmas-e a mérői licenc mikro‑szolgáltatásokhoz és serverless környezetekhez, ahol az instance‑k gyakran újraindulnak?**

Igen. Mivel a számlálás az API‑hívás szintjén történik, a gyakori hidegindításos forgatókönyvek kompatibilisek, feltéve, hogy a mérői számításokhoz stabil hálózati hozzáférés áll rendelkezésre.

**Eltér-e a könyvtár funkcionalitása mérői licenc használata esetén egy örökös licenchez képest?**

Nem. Ez csak a licencelési és számlázási mechanizmusra vonatkozik; a termék képességei azonosak.

**Hogyan viszonyul a mérői licenc a próbaverzióhoz és az ideiglenes licenchez?**

A próbaverzió korlátozásokkal és vízjelekkel rendelkezik, a [temporary license](https://purchase.aspose.com/temporary-license/) 30 napra eltávolítja a korlátozásokat, a mérői licenc pedig eltávolítja a korlátozásokat és a tényleges használat alapján számol.

**Képes vagyok a költségvetést szabályozni azáltal, hogy automatikusan reagálok, ha egy fogyasztási küszöböt meghaladnak?**

Igen. Gyakori megoldás a jelenlegi fogyasztás időközönkénti leolvasása a [követő metódusok](https://reference.aspose.com/slides/hu/python-java/aspose.slides/metered/) segítségével, majd saját korlátok vagy riasztások bevezetése az alkalmazás vagy a megfigyelési szintjén.