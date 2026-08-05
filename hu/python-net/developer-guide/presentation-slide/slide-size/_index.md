---
title: Diák méretének módosítása prezentációkban Python használatával
linktitle: Diák mérete
type: docs
weight: 70
url: /hu/python-net/slide-size/
keywords:
- diák mérete
- képarány
- szabványos
- szélesvásznú
- 4:3
- 16:9
- diák méretének beállítása
- diák méretének módosítása
- egyedi diák méret
- speciális diák méret
- különálló diák méret
- teljes méretű dia
- képernyő típusa
- ne méretezze
- illeszkedés biztosítása
- maximalizálás
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Ismerje meg, hogyan lehet gyorsan átméretezni a diákat PPT, PPTX és ODP fájlokban Python és Aspose.Slides használatával, optimalizálja a prezentációkat bármilyen képernyőre anélkül, hogy minőségromlást szenvedne."
---
## **Bevezetés**

Az Aspose.Slides átfogó eszközöket kínál a PowerPoint‑prezentációk diák méretének és képarányának beállításához, ami a nyomtatás és a képernyőn megjelenítés szempontjából egyaránt kritikus.

Népszerű diák méretek és arányok:
- **Standard (4:3 képarány)**: Ideális régebbi képernyők és eszközök számára.
- **Widescreen (16:9 képarány)**: Modern projektorok és kijelzők számára ajánlott.

Biztosítsa a konzisztenciát a teljes prezentációban, mivel egyetlen diaméret és képarány vonatkozik minden diára. A legjobb eredmény érdekében állítsa be a diák méretét a prezentáció létrehozásának kezdetén, hogy elkerülje a problémákat.

{{% alert color="primary" %}} 
Alapértelmezés szerint az Aspose.Slides‑el létrehozott prezentációk a szabványos 4:3 képarányt használják.
{{% /alert %}}

## **Diák méretének módosítása egy prezentációban**

Ez a példakód bemutatja, hogyan módosíthatja egy prezentáció diák méretét Pythonban az Aspose.Slides használatával:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(slides.SlideSizeType.ON_SCREEN16X9, slides.SlideSizeScaleType.DO_NOT_SCALE)
    pres.save("pres-4x3-aspect-ratio.pptx", slides.export.SaveFormat.PPTX)
```

## **Egyéni diák méretének megadása**

Ha a gyakori diák méretek (4:3 és 16:9) nem alkalmasak az Ön munkájhoz, dönthet úgy, hogy egy meghatározott vagy egyedi diáméretet használ. Például, ha teljes méretű diák nyomtatását tervezi egy egyedi oldalelrendezésre vagy ha bizonyos képernyőtípusokon szeretné megjeleníteni a prezentációt, valószínűleg hasznát veszi egy egyedi méretbeállításnak.

Ez a példakód bemutatja, hogyan használhatja az Aspose.Slides-t Pythonhoz .NET-en keresztül egy egyedi diák méretének megadásához egy prezentációban Pythonban:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(780, 540, slides.SlideSizeScaleType.DO_NOT_SCALE) # A4 papírméret
    pres.save("pres-a4-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

## **Diák tartalmának kezelése átméretezés után**

Megváltoztatja egy prezentáció diák méretét, a diák tartalma (például képek vagy objektumok) torzulhat. Alapértelmezés szerint az objektumok automatikusan méreteződnek, hogy illeszkedjenek az új diák méretéhez. Azonban a prezentáció diák méretének módosításakor megadhat egy beállítást, amely meghatározza, hogyan kezeli az Aspose.Slides a diák tartalmát.

A szándékaitól vagy a kívánt eredménytől függően az alábbi beállítások bármelyikét használhatja:
- `DO_NOT_SCALE`

  Ha NEM akarja, hogy a diákon lévő objektumok átméreteződjenek, használja ezt a beállítást.
- `ENSURE_FIT`

  Ha kisebb diák méretre szeretne skálázni, és arra van szüksége, hogy az Aspose.Slides lecsökkentse a diák objektumait, hogy azok mind elférjenek a diákon (így elkerülve a tartalom elvesztését), használja ezt a beállítást.
- `MAXIMIZE`

  Ha nagyobb diák méretre szeretne skálázni, és arra van szüksége, hogy az Aspose.Slides megnövelje a diák objektumait, hogy arányosak legyenek az új diák mérettel, használja ezt a beállítást.

Ez a példakód bemutatja, hogyan használhatja a `MAXIMIZE` beállítást egy prezentáció diák méretének módosításakor:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
   pres.slide_size.set_size(slides.SlideSizeType.LEDGER, slides.SlideSizeScaleType.MAXIMIZE)
```

## **GYIK**

**Beállíthatok egy egyéni diák méretet hüvelyken kívül más mértékegységgel (például pontban vagy milliméterben)?**

Igen. Az Aspose.Slides belsőleg pontként dolgozik, ahol 1 pont = 1/72 hüvelyk. Bármely mértékegységet (például millimétert vagy centimétert) átválthat pontokra, és a konvertált értékekkel határozhatja meg a diák szélességét és magasságát.

**Egy nagyon nagy egyéni diák méret befolyásolja a teljesítményt és a memóriafogyasztást a renderelés során?**

Igen. A nagyobb diák méretek (pontban) magasabb renderelési skálával együtt növelik a memóriahasználatot és a feldolgozási időt. Törekedjen egy praktikus diák méretre, és a renderelési skálát csak a kívánt kimeneti minőség eléréséhez szükséges mértékben módosítsa.

**Megadhatok egy nem szabványos diák méretet, majd összevonhatok diákokat olyan prezentációkból, amelyek különböző méretekkel rendelkeznek?**

Nem tudja [merge presentations](/slides/hu/python-net/merge-presentation/) összevonni őket, ha különböző diák méretekkel rendelkeznek – először méretezze át az egyik prezentációt, hogy egyezzen a másikkal. A diák méretének módosításakor kiválaszthatja, hogyan kezelje a meglévő tartalmat a [SlideSizeScaleType](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slidesizescaletype/) opcióval. A méretek egyeztetése után összevonhatja a diákot, miközben megőrzi a formázást.

**Létrehozhatok előnézeti képeket egyedi alakzatokhoz vagy a diák meghatározott részeihez, és ezek figyelembe veszik az új diák méretet?**

Igen. Az Aspose.Slides képes előnézeti képeket renderelni [entire slides](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slide/get_image/) valamint [selected shapes](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/get_image/) számára. A kapott képek tükrözik az aktuális diák méretét és képarányát, biztosítva az egységes keretezést és geometriát.