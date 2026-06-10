---
title: Dia méret módosítása prezentációkban Python segítségével
linktitle: Dia méret
type: docs
weight: 70
url: /hu/python-net/slide-size/
keywords:
- dia méret
- képarány
- szabványos
- szélesvásznú
- 4:3
- 16:9
- dia méret beállítása
- dia méret módosítása
- egyedi dia méret
- speciális dia méret
- különleges dia méret
- teljes méretű dia
- képernyő típusa
- ne méretezze
- biztosítsa a beleférést
- maximalizálás
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
descriptions: "Ismerje meg, hogyan lehet gyorsan átméretezni a diákat PPT, PPTX és ODP fájlokban Python és Aspose.Slides segítségével, optimalizálva a prezentációkat bármilyen képernyőhöz anélkül, hogy minőségromlás történne."
---
## **Bevezetés**

Az Aspose.Slides átfogó eszközöket biztosít a diák méretének és képarányának módosításához a PowerPoint‑prezentációkban, ami a nyomtatáshoz és a képernyőre való megjelenítéshez egyaránt kritikus.

Népszerű diákméretek és arányok:

- **Standard (4:3 képarány)**: Ideális régebbi képernyők és eszközök számára.
- **Widescreen (16:9 képarány)**: Modern projektorokhoz és kijelzőkhöz ajánlott.

Biztosítsa a következetességet a teljes prezentációban, mivel egyetlen diákméret és képarány vonatkozik minden diára. A legjobb eredmény érdekében állítsa be a diák méretét a prezentáció létrehozásának elején, hogy elkerülje a komplikációkat.

{{% alert color="primary" %}} 
Alapértelmezés szerint az Aspose.Slides‑kel létrehozott prezentációk a standard 4:3 képarányt használják.
{{% /alert %}}

## **A diák méretének módosítása egy prezentációban**

Ez a mintakód bemutatja, hogyan lehet megváltoztatni a diák méretét egy prezentációban Pythonban az Aspose.Slides használatával:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(slides.SlideSizeType.ON_SCREEN16X9, slides.SlideSizeScaleType.DO_NOT_SCALE)
    pres.save("pres-4x3-aspect-ratio.pptx", slides.export.SaveFormat.PPTX)
```

## **Egyéni diákméretek meghatározása**

Ha a gyakori diákméreteket (4:3 és 16:9) nem megfelelőnek találja a munkájához, úgy dönthet, hogy egy meghatározott vagy egyedi diákméretet használ. Például, ha a prezentációjából teljes méretű diák nyomtatását tervezi egy egyéni oldalelrendezésre, vagy ha a prezentációt bizonyos képernyőtípusokon szeretné megjeleníteni, valószínűleg hasznos lesz egy egyedi méretbeállítás használata.

Ez a mintakód bemutatja, hogyan lehet az Aspose.Slides for Python via .NET segítségével egyedi diákméretet megadni egy prezentációhoz Pythonban:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(780, 540, slides.SlideSizeScaleType.DO_NOT_SCALE) # A4 papírméret
    pres.save("pres-a4-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

## **Diák tartalmának kezelése átméretezés után**

A prezentáció diákméretének módosítása után a diák tartalma (például képek vagy objektumok) torzulhat. Alapértelmezés szerint az objektumok automatikusan átméreteződnek, hogy illeszkedjenek az új diákmérethez. Azonban a diákméret módosításakor megadhat egy beállítást, amely meghatározza, hogyan kezeli az Aspose.Slides a diák tartalmát.

Attól függően, hogy mit kíván elérni, az alábbi beállítások bármelyikét használhatja:

- `DO_NOT_SCALE`

  Ha NEM szeretné, hogy a diákon lévő objektumok átméreteződjenek, használja ezt a beállítást.

- `ENSURE_FIT`

  Ha kisebb diákméretre szeretne skálázni, és azt igényli, hogy az Aspose.Slides lecsökkentse a diák objektumait, hogy mindegyik elférjen a diákon (így elkerülve a tartalom elvesztését), használja ezt a beállítást.

- `MAXIMIZE`

  Ha nagyobb diákméretre szeretne skálázni, és azt igényli, hogy az Aspose.Slides megnövelje a diák objektumait, hogy arányosak legyenek az új diákmérettel, használja ezt a beállítást.

Ez a mintakód bemutatja, hogyan kell használni a `MAXIMIZE` beállítást a prezentáció diákjának méretének módosításakor:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
   pres.slide_size.set_size(slides.SlideSizeType.LEDGER, slides.SlideSizeScaleType.MAXIMIZE)
```

## **GYIK**

**Be lehet állítani egyedi diákméretet hüvelykekre vonatkozóan nem használt mértékegységgel (például pontokkal vagy milliméterrel)?**

Igen. Az Aspose.Slides belsőleg pontokat használ, ahol 1 pont = 1/72 hüvelyk. Bármely mértékegységet (például millimétert vagy centimétert) konvertálhat pontokba, és a konvertált értékekkel határozhatja meg a diák szélességét és magasságát.

**Egy nagyon nagy egyedi diákméret befolyásolja a teljesítményt és a memóriahasználatot a renderelés során?**

Igen. A nagyobb diákméretek (pontban) magasabb renderelési mérettel együtt növelik a memóriafogyasztást és a feldolgozási időt. Célszerű praktikus diákméretet választani, és a renderelési méretet csak szükség szerint módosítani a kívánt kimeneti minőség eléréséhez.

**Megadhatok egy nem szabványos diákméretet, majd egyesíthetek diákokat olyan prezentációkból, amelyek más méretekkel rendelkeznek?**

Nem tudja [összevonni a prezentációkat](/slides/hu/python-net/merge-presentation/) különböző diákméretek esetén – először méretezze át az egyiket, hogy egyezzen a másikkal. A diákméret módosításakor kiválaszthatja, hogyan kezelje a meglévő tartalmat a [SlideSizeScaleType](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slidesizescaletype/) beállítás segítségével. A méretek egyeztetése után egyesítheti a diákot a formázás megőrzésével.

**Készíthetek miniatűröket egyedi alakzatokhoz vagy a dia adott területeihez, és ezek figyelembe veszik az új diákméretet?**

Igen. Az Aspose.Slides előállíthat miniatűröket [teljes diákokhoz](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slide/get_image/) és [kiválasztott alakzatokhoz](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/get_image/). A kapott képek a jelenlegi diákméretet és képarányt tükrözik, biztosítva a következetes keretezést és geometriát.