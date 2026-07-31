---
title: A prezentáció diák méretének módosítása .NET‑ben
linktitle: Dia méret
type: docs
weight: 70
url: /hu/net/slide-size/
keywords:
- dia méret
- képarány
- standard
- szélesvászon
- 4:3
- 16:9
- dia méret beállítása
- dia méret módosítása
- egyedi dia méret
- különleges dia méret
- egyedülálló dia méret
- teljes méretű dia
- képernyő típusa
- ne méretezze
- illeszkedés biztosítása
- maximalizálás
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan lehet gyorsan átméretezni a diákat PPT, PPTX és ODP fájlokban .NET és Aspose.Slides segítségével, optimalizálja a prezentációkat bármely képernyőre a minőség megőrzése mellett."
---
## **Bevezetés**

Az Aspose.Slides for .NET átfogó eszközöket biztosít a diák méretének és képarányának beállításához a PowerPoint‑prezentációkban, ami mind a nyomtatáshoz, mind a képernyőn való megjelenítéshez kritikus.

Népszerű diákméretek és arányok:

- **Standard (4:3 képarány)**: Ideális régebbi képernyők és eszközök esetén.
- **Widescreen (16:9 képarány)**: Modern projektorok és kijelzők számára ajánlott.

Biztosítsa a következetességet a teljes prezentációban, mivel egyetlen diák mérete és képaránya vonatkozik minden diára. Az optimális eredmény érdekében állítsa be a diák méreteit a prezentáció létrehozásának kezdetén, hogy elkerülje a komplikációkat.

{{% alert color="primary" %}} 
Alapértelmezés szerint az Aspose.Slides‑el létrehozott prezentációk a standard 4:3 képarányt használják.
{{% /alert %}}

## **A diák méretének módosítása egy prezentációban**

Ez a példa bemutatja, hogyan lehet megváltoztatni egy prezentáció diák méretét az Aspose.Slides segítségével C#‑ban:

```csharp
using (Presentation pres = new Presentation("presentation-4x3.pptx"))
{
    pres.SlideSize.SetSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.Save("presentation-16x9.pptx", SaveFormat.Pptx);
}
```

## **Egyedi diák méretének megadása**

A diák méretének az Ön egyedi igényeihez, például különleges papírformátumokhoz vagy képernyőspecifikációkhoz igazítása előnyös lehet. Így állíthat be egyedi diák méretet az Aspose.Slides for .NET‑ben:

```csharp
using (Presentation pres = new Presentation("presentation.pptx"))
{
    pres.SlideSize.SetSize(780, 540, SlideSizeScaleType.DoNotScale); // A4 papírméret
    pres.Save("presentation-a4.pptx", SaveFormat.Pptx);
}
```

## **Diák tartalmának kezelése átméretezés után**

Az átméretezés után a diák tartalma torzulhat. Szabályozhatja, hogyan kezeli az Aspose.Slides ezt az átméretezést:

- **`DoNotScale`**: Az objektumok eredeti méretének megtartása a méretezés elkerülése érdekében.
- **`EnsureFit`**: Az objektumok méretezése kisebb diákra való illesztéshez, megakadályozva a tartalom elvesztését.
- **`Maximize`**: Az objektumok nagyítása nagyobb diákra, az esztétikai konzisztencia érdekében.

Az `Maximize` beállítás használatának példája a diák méretének beállításához:

```csharp
using (Presentation pres = new Presentation("presentation.pptx"))
{
   pres.SlideSize.SetSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
}
```

## **GYIK**

**Beállíthatok egyedi diák méretet inch‑en kívül más mértékegységekben (például pontok vagy milliméterek)?**

Igen. Az Aspose.Slides belsőként pontokat használ, ahol 1 pont = 1/72 inch. Bármely mértékegységet (például millimétert vagy centimétert) átkonvertálhat pontokra, és a konvertált értékeket használhatja a diák szélességének és magasságának meghatározásához.

**Egy nagyon nagy egyedi diák méret befolyásolja a teljesítményt és a memóriahasználatot a renderelés során?**

Igen. A nagyobb diák méretek (pontokban) és a magasabb renderelési lépték kombinációja megnöveli a memóriaigényt és hosszabb feldolgozási időt eredményez. Célszerű gyakorlati méretet választani, és a renderelési léptéket csak a kívánt kimeneti minőség eléréséhez szükséges mértékben módosítani.

**Meghatározhatok egy nem szabványos diák méretet, majd egyesíthetek diákokat olyan prezentációkból, amelyek más méretekkel rendelkeznek?**

Nem tud [prezentációkat egyesíteni](/slides/hu/net/merge-presentation/) eltérő diák méretek esetén – először méretezze át az egyik prezentációt a másikhoz illeszkedő méretre. Diák méretének módosításakor a [SlideSizeScaleType](https://reference.aspose.com/slides/hu/net/aspose.slides/slidesizescaletype/) opcióval választhatja ki, hogyan kezelje a meglévő tartalmat. A méretek egyeztetése után egyesítheti a diákokat a formázás megőrzésével.

**Létrehozhatok előnézeti képeket egyedi alakzatokhoz vagy a dia meghatározott területeihez, és ezek figyelembe veszik az új diák méretét?**

Igen. Az Aspose.Slides képes előnézeti képeket készíteni [teljes diák](https://reference.aspose.com/slides/hu/net/aspose.slides/slide/getimage/) számára, valamint [kijelölt alakzatok](https://reference.aspose.com/slides/hu/net/aspose.slides/shape/getimage/) esetén. A keletkező képek tükrözik a jelenlegi diák méretét és képarányát, ezáltal biztosítva az egységes keretezést és geometriát.