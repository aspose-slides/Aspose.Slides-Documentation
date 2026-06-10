---
title: Mérő licencelés
type: docs
weight: 90
url: /hu/net/metered-licensing/
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
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan teszi lehetővé az Aspose.Slides for .NET mérő licencelés, hogy rugalmasan dolgozzon PowerPoint és OpenDocument fájlokkal, csak a felhasznált mennyiségért fizetve."
---
## **Bevezetés**

A mérő licencelés egy licencelési mechanizmus, amelyet a meglévő licencelési módszerek mellett is használhat. Ha az Aspose.Slides API funkcióinak használata alapján szeretne számlázást, a mérő licencelést választja.

## **Mérőkulcsok alkalmazása**

Amikor megvásárol egy mérő licencet, kulcsokat kap (és nem licencfájlt). Ez a mérőkulcs alkalmazható a [Metered](https://reference.aspose.com/slides/hu/net/aspose.slides/metered/) osztály segítségével, amelyet az Aspose a mérési műveletekhez biztosít. További részletekért tekintse meg a [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered) cikket.

1. Hozzon létre egy példányt a [Metered](https://reference.aspose.com/slides/hu/net/aspose.slides/metered/) osztályból.  
1. Adja át a nyilvános és privát kulcsait a [SetMeteredKey](https://reference.aspose.com/slides/hu/net/aspose.slides/metered/setmeteredkey/) metódusnak.  
1. Végezzen némi feldolgozást (feladatok végrehajtása).  
1. Hívja meg a `Metered` osztály [GetConsumptionQuantity](https://reference.aspose.com/slides/hu/net/aspose.slides/metered/getconsumptionquantity/) metódusát.

Látnia kell az eddig felhasznált API‑kérések mennyiségét.

Ez a példakód megmutatja, hogyan használja a mérő licencelést:

```cs
// Létrehozza a Metered osztály egy példányát
Aspose.Slides.Metered metered = new Aspose.Slides.Metered();

// Átadja a nyilvános és privát kulcsokat a Metered objektumnak
metered.SetMeteredKey("<valid public key>", "<valid private key>");

// Lekéri a mérő adatmennyiséget az API hívás előtt
decimal amountBefore = Aspose.Slides.Metered.GetConsumptionQuantity();
Console.WriteLine("Amount consumed before: " + amountBefore.ToString());

// Valamilyen műveletet végez az Aspose.Slides API-val itt
// ...

// Lekéri a mérő adatmennyiséget az API hívás után
decimal amountAfter = Aspose.Slides.Metered.GetConsumptionQuantity();
Console.WriteLine("Amount consumed after: " + amountAfter.ToString());
```

{{% alert color="warning" title="MEGJEGYZÉS"  %}}  
A mérő licencelés használatához stabil internetkapcsolat szükséges, mivel a licencelési mechanizmus folyamatosan kommunikál a szolgáltatásainkkal és számításokat végez.  
{{% /alert %}}  

## **GYIK**

**Használhatok mérő licencet egy hagyományos (örökös vagy ideiglenes) licenc mellett ugyanabban az alkalmazásban?**  

Igen. A mérő licenc egy kiegészítő licencelési mechanizmus, amely a meglévő [licencelési módszerek](/slides/hu/net/licensing/) mellett alkalmazható. Az alkalmazás indításakor választhatja ki, melyik mechanizmust használja.

**Mi számít fogyasztásnak a mérő licenc alatt: műveletek vagy fájlok?**  

Az API‑használat számít, vagyis a kérések vagy műveletek száma. Az aktuális fogyasztást a [fogyasztás‑követési metódusokkal](https://reference.aspose.com/slides/hu/net/aspose.slides/metered/) érheti el.

**Alkalmas-e a mérő licenc mikro‑szolgáltatásokhoz és szerver‑ nélküli környezetekhez, ahol az instance‑ok gyakran újraindulnak?**  

Igen. Mivel a elszámolás API‑hívásonként történik, a gyakori hideg indításokkal járó forgatókönyvek is kompatibilisek, feltéve hogy a mérő számításokhoz stabil hálózati hozzáférés áll rendelkezésre.

**Eltér-e a könyvtár funkcionalitása mérő licenc használata esetén a örökös licenchez képest?**  

Nem. Ez csak a licencelési és számlázási mechanizmusra vonatkozik; a termék képességei azonosak.

**Hogyan viszonyul a mérő licenc a próbaverzióhoz és az ideiglenes licenchez?**  

A próbaverziónak korlátai és vízjelei vannak, a [ideiglenes licenc](https://purchase.aspose.com/temporary-license/) 30 napra eltávolítja a korlátokat, a mérő licenc pedig a korlátokat eltávolítja és a tényleges használat alapján számít fel díjat.

**Kezelhetem a költségvetést úgy, hogy automatikusan reagálok, ha a fogyasztási küszöböt meghaladják?**  

Igen. Gyakori gyakorlat, hogy időközönként a [követési metódusokkal](https://reference.aspose.com/slides/hu/net/aspose.slides/metered/) lekérdezi a jelenlegi fogyasztást, és saját korlátokat vagy riasztásokat valósít meg az alkalmazás‑ vagy felügyeleti szinten.