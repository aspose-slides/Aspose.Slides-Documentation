---
title: Prezentáció diákméretének módosítása .NET‑ben
linktitle: Dia mérete
type: docs
weight: 70
url: /hu/net/slide-size/
keywords:
- dia mérete
- méretarány
- standard
- szélesvászon
- 4:3
- 16:9
- dia méretének beállítása
- dia méretének módosítása
- egyedi dia méret
- különleges dia méret
- egyedi dia méret
- teljes méretű dia
- képernyő típus
- ne méretezze
- biztosítsa a illeszkedést
- maximalizálás
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
descriptions: "Tanulja meg, hogyan méretezheti gyorsan át a diákat PPT, PPTX és ODP fájlokban .NET és Aspose.Slides használatával, optimalizálja a prezentációkat bármilyen képernyőre minőségromlás nélkül."
---
## **Bevezetés**

Az Aspose.Slides for .NET átfogó eszközöket biztosít a dia méretének és méretarányának beállításához a PowerPoint‑prezentációkban, ami a nyomtatás és a képernyőn való megjelenítés egyaránt kritikus.

Népszerű diaméretek és arányok:

- **Standard (4:3 Méretarány)**: Ideális régebbi képernyők és eszközök számára.
- **Widescreen (16:9 Méretarány)**: Ajánlott modern projektorokhoz és kijelzőkhöz.

Biztosítsa a konzisztenciát a prezentáció során, mivel egyetlen dia méret és méretarány vonatkozik az összes diára. A legjobb eredmény érdekében állítsa be a dia méreteit a prezentáció létrehozásának elején, hogy elkerülje a problémákat.

{{% alert color="primary" %}} 
Alapértelmezés szerint az Aspose.Slides‑el létrehozott prezentációk a standard 4:3 méretarányt használják.
{{% /alert %}}

## **A dia méretének módosítása egy prezentációban**

Ez a példa bemutatja, hogyan változtatható meg egy prezentáció dia mérete az Aspose.Slides segítségével C#-ban:

```csharp
using (Presentation pres = new Presentation("presentation-4x3.pptx"))
{
    pres.SlideSize.SetSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.Save("presentation-16x9.pptx", SaveFormat.Pptx);
}
```

## **Egyéni diaméretek megadása**

Az egyedi igényekhez, például egyedi papírelrendezésekhez vagy képernyőspecifikációkhoz igazított dia méret hasznos lehet. Íme, hogyan állíthat be egyedi diaméretet az Aspose.Slides for .NET‑el:

```csharp
using (Presentation pres = new Presentation("presentation.pptx"))
{
    pres.SlideSize.SetSize(780, 540, SlideSizeScaleType.DoNotScale); // A4 papírméret
    pres.Save("presentation-a4.pptx", SaveFormat.Pptx);
}
```

## **Dia tartalmának kezelése átméretezés után**

Az átméretezés után a dia tartalma torzulhat. Szabályozhatja, hogyan kezeli ezt az Aspose.Slides:

- **`DoNotScale`**: Az objektumokat az eredeti méretükben tartja, elkerülve a méretezést.
- **`EnsureFit`**: Az objektumokat úgy méretezi, hogy kisebb diákra illeszkedjenek, megakadályozva a tartalom elvesztését.
- **`Maximize`**: Az objektumokat nagyobb diákhoz igazítja, esztétikai konzisztenciát biztosítva.

Példa a `Maximize` beállítás használatára a dia méretének módosításához:

```csharp
using (Presentation pres = new Presentation("presentation.pptx"))
{
   pres.SlideSize.SetSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
}
```

## **GYIK**

**Beállíthatok-e egyedi diaméretet más mértékegységgel, mint hüvelyk (például pontok vagy milliméterek)?**

Igen. Az Aspose.Slides belsőleg pontokat használ, ahol 1 pont = 1/72 hüvelyk. Bármely mértékegységet (például millimétert vagy centimétert) átalakíthat pontokra, és a konvertált értékeket felhasználhatja a dia szélességének és magasságának meghatározásához.

**A nagyon nagy egyedi diaméret befolyásolja a teljesítményt és a memóriahasználatot a renderelés során?**

Igen. A nagyobb diaméretek (pontban) magasabb renderelési skálával együtt megnövekedett memóriahasználathoz és hosszabb feldolgozási időhöz vezetnek. Törekedjen a gyakorlati diaméretre, és csak a szükséges mértékben állítsa be a renderelési skálát a kívánt kimeneti minőség eléréséhez.

**Megadhatok-e egy nem szabványos diaméretet, majd összefűzhetek diákat olyan prezentációkból, amelyek különböző méretekkel rendelkeznek?**

Nem lehet [merge presentations](/slides/hu/net/merge-presentation/) akkor, ha a prezentációk különböző diaméretekkel rendelkeznek – először méretezze át az egyiket, hogy megegyezzen a másikkal. A dia méretének módosításakor választhat, hogyan kezelje a meglévő tartalmat a [SlideSizeScaleType](https://reference.aspose.com/slides/hu/net/aspose.slides/slidesizescaletype/) opció segítségével. A méretek egyeztetése után összefűzheti a diákat a formázás megőrzésével.

**Létrehozhatok-e bélyegképeket egyedi alakzatokhoz vagy a dia meghatározott területeihez, és figyelembe veszik-e az új dia méretet?**

Igen. Az Aspose.Slides képes bélyegképeket renderelni [entire slides](https://reference.aspose.com/slides/hu/net/aspose.slides/slide/getimage/) és [selected shapes](https://reference.aspose.com/slides/hu/net/aspose.slides/shape/getimage/) esetén is. A kapott képek tükrözik a jelenlegi dia méretét és méretarányát, ezzel biztosítva a konzisztens keretezést és geometriát.