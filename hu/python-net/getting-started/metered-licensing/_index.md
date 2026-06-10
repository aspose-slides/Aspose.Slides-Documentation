---
title: Mért licencelés
type: docs
weight: 90
url: /hu/python-net/metered-licensing/
keywords:
- licenc
- mért licenc
- licenckulcsok
- nyilvános kulcs
- privát kulcs
- fogyasztási mennyiség
- Python
- Aspose.Slides
description: "Ismerje meg, hogyan teszi lehetővé az Aspose.Slides for Python via .NET mérő licencelés, hogy rugalmasan dolgozzon PowerPoint és OpenDocument fájlokkal, és csak a felhasznált mennyiségért fizessen."
---
## **Bevezetés**

A mérő licencelés egy licencelési mechanizmus, amely meglévő licencelési módszerekkel együtt is használható. Ha azt szeretné, hogy az Aspose.Slides API funkcióinak használata alapján számlázzanak, a mérő licencelést választja.

## **Metered kulcsok alkalmazása**

{{% alert color="primary" %}} 

A mérő licencelés egy új licencelési mechanizmus, amely meglévő licencelési módszerekkel együtt is használható. Ha azt szeretné, hogy az Aspose.Slides API funkcióinak használata alapján számlázzanak, a mérő licencelést választja.

Amikor megvásárol egy mérő licencet, kulcsokat kap (és nem licencfájlt). Ez a mérő kulcs alkalmazható az Aspose által biztosított [Metered](https://reference.aspose.com/slides/hu/python-net/aspose.slides/metered/) osztály használatával a számlázási műveletekhez. További részletekért lásd a [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Hozzon létre egy példányt a [Metered](https://reference.aspose.com/slides/hu/python-net/aspose.slides/metered/) osztályból.  
2. Adja át a nyilvános és privát kulcsait a [set_metered_key](https://reference.aspose.com/slides/hu/python-net/aspose.slides/metered/set_metered_key/#str-str) metódusnak.  
3. Végezzen némi feldolgozást (feladatok végrehajtása).  
4. Hívja meg a `Metered` osztály [get_consumption_quantity](https://reference.aspose.com/slides/hu/python-net/aspose.slides/metered/get_consumption_quantity/#) metódusát.  

Látnia kell a eddig felhasznált API-kérések mennyiségét/mennyiségét.

Ez a példa kód megmutatja, hogyan használhatja a mérő licencelést:

```python
import aspose.slides as slides

# Létrehozza a Metered osztály egy példányát
metered = slides.Metered()

# Átadja a nyilvános és privát kulcsokat a Metered objektumnak
metered.set_metered_key("<valid public key>", "<valid private key>")

# Lekéri a fogyasztott mennyiség értékét az API hívások előtt
amount_before = slides.Metered.get_consumption_quantity()
print("Amount consumed before:", amount_before)

# Végrehajt valamit az Aspose.Slides API-val itt
# ...

# Lekéri a fogyasztott mennyiség értékét az API hívások után
amount_after = slides.Metered.get_consumption_quantity()
print("Amount consumed after:", amount_after)
```

{{% alert color="warning" title="NOTE"  %}} 

A mérő licencelés használatához stabil internetkapcsolatra van szükség, mivel a licencelési mechanizmus az internetet használja folyamatosan a szolgáltatásainkkal való interakcióra és számítások elvégzésére.

{{% /alert %}} 

## **FAQ**

**Használhatok‑e egy mérő licencet egy hagyományos (örökös vagy ideiglenes) licenccel együtt ugyanabban az alkalmazásban?**

Igen. A mérő egy kiegészítő licencelési mechanizmus, amely a meglévő [licencelési módszerekkel](/slides/hu/python-net/licensing/) együtt is használható. A futtatáskor választja ki, melyik mechanizmust alkalmazza.

**Mi számít pontosan fogyasztásnak a mérő licenc alatt: műveletek vagy fájlok?**

Az API használat számít, vagyis a kérések vagy műveletek száma. A jelenlegi fogyasztást a [fogyasztás‑nyomonkövető módszerekkel](https://reference.aspose.com/slides/hu/python-net/aspose.slides/metered/) érheti el.

**Alkalmas‑e a mérő licenc mikro‑szolgáltatásokhoz és szerver nélküli környezetekhez, ahol az instance‑ok gyakran újraindulnak?**

Igen. Mivel a elszámolás API‑hívási szinten történik, a gyakori hidegindulásos esetek kompatibilisek, feltéve hogy stabil hálózati hozzáférés áll rendelkezésre a mérő számításokhoz.

**Eltér‑e a könyvtár funkciója mérő licenc használatakor a örökös licenchez képest?**

Nem. Ez csak a licenc‑ és számlázási mechanizmust érinti; a termék képességei ugyanazok.

**Hogyan kapcsolódik a mérő a próbaverzióhoz és az ideiglenes licenchez?**

A próbaverzió korlátozásokkal és vízjelekkel rendelkezik, a [temporális licenc](https://purchase.aspose.com/temporary-license/) 30 napra eltávolítja a korlátozásokat, a mérő pedig eltávolítja a korlátozásokat, és a tényleges használat alapján díjat számít fel.

**Képes vagyok‑e a költségvetést szabályozni azáltal, hogy automatikusan reagálok, ha a fogyasztási küszöböt átlépik?**

Igen. Gyakori gyakorlat, hogy időnként beolvaszuk a jelenlegi fogyasztást a [követési módszerekkel](https://reference.aspose.com/slides/hu/python-net/aspose.slides/metered/), és saját korlátokat vagy riasztásokat valósítunk meg az alkalmazás vagy a megfigyelési szintjén.