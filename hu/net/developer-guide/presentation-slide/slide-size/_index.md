---
title: A prezentáció diák méretének módosítása .NET-ben
linktitle: Dia mérete
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
description: "Ismerje meg, hogyan lehet gyorsan átméretezni a diákat PPT, PPTX és ODP fájlokban .NET és az Aspose.Slides használatával, optimalizálja a prezentációkat bármely képernyőre minőségromlás nélkül."
---
## **Bevezetés**

Az Aspose.Slides for .NET átfogó eszközöket kínál a diák méretének és képarányának beállításához a PowerPoint‑prezentációkban, ami mind nyomtatás, mind képernyőmegjelenítés esetén kritikus.

Népszerű diák méretek és arányok:

- **Standard (4:3 képarány)**: Ideális régebbi képernyők és eszközök számára.
- **Widescreen (16:9 képarány)**: Ajánlott modern projektorokhoz és kijelzőkhöz.

Biztosítsa a következetességet a teljes prezentációban, mivel egyetlen diaképméret és képarány vonatkozik minden diára. A legjobb eredmény érdekében állítsa be a diaméreteket a prezentációkészítés elején, hogy elkerülje a komplikációkat.

{{% alert color="info" %}} 
Alapértelmezés szerint az Aspose.Slides‑el létrehozott prezentációk a szabványos 4:3 képarányt használják.
{{% /alert %}}

## **A diák méretének módosítása egy prezentációban**

Ez a példa bemutatja, hogyan lehet megváltoztatni egy prezentáció diaméretét az Aspose.Slides segítségével C#‑ban:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("presentation-4x3.pptx"))
{
    pres.SlideSize.SetSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.Save("presentation-16x9.pptx", SaveFormat.Pptx);
}
```

## **Egyedi diák méretek meghatározása**

Az egyedi igényekhez, például különleges papírformátumokhoz vagy képernyőspecifikációkhoz igazított diaméret előnyös lehet. Íme, hogyan állíthat be egyedi diaméretet az Aspose.Slides for .NET‑el:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("presentation.pptx"))
{
    pres.SlideSize.SetSize(780, 540, SlideSizeScaleType.DoNotScale); // A4 papírméret
    pres.Save("presentation-a4.pptx", SaveFormat.Pptx);
}
```

## **Diatartalom kezelése átméretezés után**

Az átméretezés után a diatartalom torzulhat. Szabályozhatja, hogy az Aspose.Slides hogyan kezeli ezt az átméretezést:

- **`DoNotScale`**: Az objektumok eredeti méretben maradnak, elkerülve a méretezést.
- **`EnsureFit`**: Az objektumok méretezése úgy, hogy kisebb diákra illeszkedjenek, megakadályozva a tartalom elvesztését.
- **`Maximize`**: Az objektumok nagyítása, hogy nagyobb diákra illeszkedjenek, ezzel esztétikai egységességet biztosítva.

Példa a `Maximize` beállítás használatára a diaméret módosításához:

```csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("presentation.pptx"))
{
   pres.SlideSize.SetSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
}
```

## **GYIK**

### Beállíthatok egyedi diaméretet hüvelyk helyett más mértékegységekben (például pontban vagy milliméterben)?

Igen. Az Aspose.Slides belsőleg pontokat használ, ahol 1 pont egy hüvelyk 1/72‑e. Bármely mértékegységet (például millimétert vagy centimétert) átalakíthat pontokra, és a konvertált értékekkel meghatározhatja a diák szélességét és magasságát.

### Egy nagyon nagy egyedi diaméret befolyásolja a teljesítményt és a memóriahasználatot a renderelés során?

Igen. A nagyobb diaméretek (pontokban) magasabb renderelési mérettel együtt megnövelt memóriafogyasztáshoz és hosszabb feldolgozási időhöz vezetnek. Célszerű praktikus diaméretet választani, és a renderelési méretet csak akkor módosítani, ha a kívánt kimeneti minőség eléréséhez szükséges.

### Meghatározhatok egy nem szabványos diaméretet, majd egyesíthetem a diákat olyan prezentációkból, amelyek más méretekkel rendelkeznek?

Nem tudja [prezentációk egyesítése](/slides/hu/net/merge-presentation/) amíg különböző diaméretek vannak — először átméretezze az egyiket, hogy egyezzen a másikkal. A diaméret módosításakor kiválaszthatja, hogyan kezelje a meglévő tartalmat a [SlideSizeScaleType](https://reference.aspose.com/slides/hu/net/aspose.slides/slidesizescaletype/) opcióval. A méretek összehangolása után egyesítheti a diákat a formázás megőrzésével.

### Létrehozhatok bélyegképeket egyedi alakzatokhoz vagy a dia adott területeihez, és azok figyelembe veszik az új diaméreteket?

Igen. Az Aspose.Slides képes bélyegképeket készíteni [teljes diákhoz](https://reference.aspose.com/slides/hu/net/aspose.slides/slide/getimage/) és [kiválasztott alakzatokhoz](https://reference.aspose.com/slides/hu/net/aspose.slides/shape/getimage/). A kapott képek tükrözik a aktuális diaméretet és képarányt, ezáltal biztosítva a következetes keretezést és geometriát.