---
title: A prezentáció dia méretének módosítása .NET-ben
linktitle: Dia méret
type: docs
weight: 70
url: /hu/net/slide-size/
keywords:
- dia méret
- képarány
- standard
- szélesvásznú
- "4:3"
- "16:9"
- dia méret beállítása
- dia méret módosítása
- egyedi dia méret
- különleges dia méret
- egyedi dia méret
- teljes méretű dia
- képernyő típusa
- ne méretezze
- illeszkedés biztosítása
- maximálás
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan méretezhet gyorsan diákot PPT, PPTX és ODP fájlokban .NET és Aspose.Slides segítségével, optimalizálja a prezentációkat bármilyen képernyőhöz a minőségromlás nélkül."
---
## **Bevezetés**

Az Aspose.Slides for .NET átfogó eszközöket biztosít a dia méretének és képarányának beállításához a PowerPoint‑prezentációkban, ami a nyomtatáshoz és a képernyőn megjelenítéshez egyaránt kritikus.

Népszerű dia méretek és arányok:

- **Standard (4:3 képarány)**: Ideális régebbi képernyők és eszközök számára.
- **Widescreen (16:9 képarány)**: Ajánlott modern projektorokhoz és kijelzőkhöz.

Biztosítsa a konzisztenciát a teljes prezentációban, mivel egyetlen dia méret és képarány vonatkozik minden diára. Az optimális eredmény érdekében állítsa be a dia méreteit a prezentáció létrehozási folyamatának elején, hogy elkerülje a problémákat.

{{% alert color="info" %}} 
Alapértelmezés szerint az Aspose.Slides‑vel létrehozott prezentációk a standard 4:3 képarányt használják.
{{% /alert %}}

A jegyzet- és szórólapoldalak külön méretekkel rendelkeznek a normál diákhoz képest. Lásd a [Jegyzetoldal mérete](/slides/hu/net/notes-size/) részt a méret és tájolás módosításához.

## **A dia méretének módosítása a prezentációban**

Ez a példa bemutatja, hogyan lehet módosítani egy prezentáció dia méretét az Aspose.Slides segítségével C#‑ban:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("presentation-4x3.pptx"))
{
    pres.SlideSize.SetSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.Save("presentation-16x9.pptx", SaveFormat.Pptx);
}
```

## **Egyedi dia méretek megadása**

A dia méretének személyre szabása az adott igényekhez, például egyedi papírelrendezésekhez vagy képernyő specifikációkhoz, előnyös lehet. Íme, hogyan állíthat be egy egyedi dia méretet az Aspose.Slides for .NET‑vel:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("presentation.pptx"))
{
    pres.SlideSize.SetSize(780, 540, SlideSizeScaleType.DoNotScale); // A4 papír méret
    pres.Save("presentation-a4.pptx", SaveFormat.Pptx);
}
```

## **Dia tartalom kezelése átméretezés után**

Átméretezés után a dia tartalma torzulhat. Szabályozhatja, hogyan kezeli az Aspose.Slides ezt az átméretezést:

- **`DoNotScale`**: Az objektumokat eredeti méretükben tartja, hogy elkerülje a méretezést.
- **`EnsureFit`**: Az objektumokat úgy méretezi, hogy kisebb diákra illeszkedjenek, megakadályozva a tartalom elvesztését.
- **`Maximize`**: Az objektumokat nagyobbra méretezi, hogy nagyobb diákhoz igazodjanak az esztétikai konzisztencia érdekében.

Példa a `Maximize` beállítás használatára a dia méretének igazításához:

```csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("presentation.pptx"))
{
   pres.SlideSize.SetSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
}
```

## **GYIK**

### Beállíthatok egyedi dia méretet hüvelyk helyett más mértékegységek (például pont vagy milliméter) használatával?

Igen. Az Aspose.Slides belsőleg pontokat használ, ahol 1 pont = 1/72 hüvelyknek felel meg. Bármely mértékegységet (például millimétert vagy centimétert) átalakíthat pontokra, és a konvertált értékekkel meghatározhatja a dia szélességét és magasságát.

### Nagyon nagy egyedi dia méret befolyásolja a teljesítményt és a memóriahasználatot a renderelés során?

Igen. A nagyobb dia méretek (pontban) magasabb renderelési skálával együtt növelik a memóriafogyasztást és a feldolgozási időt. Célozzon meg egy praktikus dia méretet, és a renderelési skálát csak szükség szerint állítsa be a kívánt kimeneti minőség eléréséhez.

### Definiálhatok egy nem szabványos dia méretet, majd egyesíthetek diákat olyan prezentációkból, amelyek különböző méretekkel rendelkeznek?

Nem [prezentációk egyesítése](/slides/hu/net/merge-presentation/) amíg különböző dia méretekkel rendelkeznek — először méretezze át az egyiket, hogy egyezzen a másikkal. A dia méretének módosításakor kiválaszthatja, hogy a meglévő tartalmat a [SlideSizeScaleType](https://reference.aspose.com/slides/hu/net/aspose.slides/slidesizescaletype/) opcióval hogyan kezelje. A méretek összehangolása után egyesítheti a diákat, miközben megőrzi a formázást.

### Létrehozhatok bélyegképeket az egyes alakzatok vagy a dia egy meghatározott területei számára, és figyelembe veszik az új dia méretet?

Igen. Az Aspose.Slides képes bélyegképeket készíteni [teljes diákhoz](https://reference.aspose.com/slides/hu/net/aspose.slides/slide/getimage/) és [kiválasztott alakzatokhoz](https://reference.aspose.com/slides/hu/net/aspose.slides/shape/getimage/). A létrehozott képek tükrözik az aktuális dia méretét és képarányát, biztosítva a konzisztens keretezést és geometriát.