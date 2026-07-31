---
title: A prezentáció dia méretének módosítása C++-ban
linktitle: Dia méret
type: docs
weight: 70
url: /hu/cpp/slide-size/
keywords:
- dia méret
- képarány
- standard
- szélesvászon
- 4:3
- 16:9
- dia méret beállítása
- dia méret módosítása
- egyéni dia méret
- különleges dia méret
- egyedi dia méret
- teljes méretű dia
- képernyőtípus
- ne méretezze
- illeszkedés biztosítása
- maximalizálás
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan lehet gyorsan átméretezni a diákat PPT, PPTX és ODP fájlokban C++ és Aspose.Slides használatával, optimalizálja a prezentációkat bármilyen képernyőhöz minőségromlás nélkül."
---
## **Bevezetés**

Az Aspose.Slides átfogó eszközöket biztosít a diák méretének és képarányának beállításához a PowerPoint‑prezentációkban, ami a nyomtatás és a képernyőn való megjelenítés szempontjából egyaránt kritikus.

Népszerű dia méretek és arányok:

- **Standard (4:3 képarány)**: Ideális régebbi képernyők és eszközök számára.  
- **Widescreen (16:9 képarány)**: Ajánlott modern projektorokhoz és kijelzőkhöz.

Biztosítsa a konzisztenciát a teljes prezentációban, mivel egyetlen dia méret és képarány vonatkozik az összes diára. A legjobb eredmény elérése érdekében állítsa be a dia méreteket a prezentáció létrehozásának kezdetén, hogy elkerülje a későbbi komplikációkat.

{{% alert color="primary" %}} 
Alapértelmezés szerint az Aspose.Slides‑kel létrehozott prezentációk a standard 4:3 képarányt használják.  
{{% /alert %}}

## **A diák méretének módosítása a prezentációkban**

Ez a mintakód megmutatja, hogyan módosíthatja a dia méretét egy prezentációban C++‑ban az Aspose.Slides használatával:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres-4x3-aspect-ratio.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
```

## **Egyéni dia méretek megadása a prezentációkban**

Ha a gyakori dia méretek (4:3 és 16:9) nem megfelelőek a munkájához, dönthet úgy, hogy egy specifikus vagy egyedi dia méretet használ. Például, ha a prezentációból teljes méretű diákat szeretne nyomtatni egy egyedi oldalelrendezésre, vagy ha a prezentációt bizonyos képernyőtípusokon kívánja megjeleníteni, valószínűleg hasznát veszi egy egyedi méret beállításának.

Ez a mintakód megmutatja, hogyan használhatja az Aspose.Slides for C++‑t egy egyedi dia méret megadásához egy prezentációban C++‑ban:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
// A4 papírméret
pres->get_SlideSize()->SetSize(780.0f, 540.0f, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-a4-slide-size.pptx", SaveFormat::Pptx);
```

## **Diátartalom kezelése átméretezés után**

Miután módosította egy prezentáció dia méretét, a diák tartalma (például képek vagy objektumok) torzulhat. Alapértelmezés szerint az objektumok automatikusan átméreteződnek, hogy illeszkedjenek az új dia mérethez. Azonban a prezentáció dia méretének módosításakor megadhat egy beállítást, amely meghatározza, hogyan kezeli az Aspose.Slides a diákon lévő tartalmakat.

Attól függően, hogy mit kíván elérni, az alábbi beállítások valamelyikét használhatja:

- `DoNotScale`

  Ha NEM szeretné, hogy a diákon lévő objektumok átméreteződjenek, használja ezt a beállítást.

- `EnsureFit`

  Ha kisebb dia méretre szeretne skálázni, és azt szeretné, hogy az Aspose.Slides lecsökkentse a diák objektumait, hogy mindegyik elférjen a dián (így elkerülve a tartalom elvesztését), használja ezt a beállítást.

- `Maximize`

  Ha nagyobb dia méretre szeretne skálázni, és azt szeretné, hogy az Aspose.Slides megnövelje a diák objektumait, hogy arányosak legyenek az új dia mérettel, használja ezt a beállítást.

Ez a mintakód megmutatja, hogyan használhatja a `Maximize` beállítást a prezentáció dia méretének módosításakor:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
```

## **GYIK**

**Beállíthatok egyedi dia méretet olyan mértékegységgel, amely nem hüvelyk (például pont vagy milliméter)?**

Igen. Az Aspose.Slides belsőleg pontot használ, ahol 1 pont = 1/72 hüvelyk. Bármely mértékegységet (például milliméter vagy centiméter) átválthat pontokra, és a konvertált értékeket használhatja a dia szélességének és magasságának meghatározására.

**Egy nagyon nagy egyedi dia méret befolyásolja a renderelés teljesítményét és memóriahasználatát?**

Igen. A nagyobb dia méretek (pontban) és a magasabb renderelési skála növelik a memóriafogyasztást és a feldolgozási időt. Célszerű gyakorlati méretet választani, és a renderelési skálát csak akkor növelni, ha a kívánt kimeneti minőség megköveteli.

**Megadhatok egy nem standard dia méretet, majd összevonhatok diákot olyan prezentációkból, amelyek különböző méretűek?**

Nem [prezentációk egyesítése](/slides/hu/cpp/merge-presentation/) akkor, ha különböző dia méretűek — először méretezze át az egyik prezentációt, hogy megegyezzen a másikkal. A dia méret módosításakor kiválaszthatja, hogyan kezelje a meglévő tartalmat a [SlideSizeScaleType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/slidesizescaletype/) opcióval. A méretek egyeztetése után összevonhatja a diákot, miközben a formázás megmarad.

**Generálhatok bélyegképeket egyedi alakzatokhoz vagy a dia bizonyos területeihez, és ezek figyelembe veszik az új dia méretet?**

Igen. Az Aspose.Slides képes bélyegképeket létrehozni [teljes diákhoz]https://reference.aspose.com/slides/hu/cpp/aspose.slides/slide/getimage/ és [kiválasztott alakzatokhoz]https://reference.aspose.com/slides/hu/cpp/aspose.slides/shape/getimage/. A létrehozott képek tükrözik az aktuális dia méretet és képarányt, ezáltal biztosítva a konzisztens keretezést és geometriát.