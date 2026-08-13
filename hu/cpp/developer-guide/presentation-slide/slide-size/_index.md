---
title: A prezentáció diák méretének módosítása C++-ban
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
- egyedi dia méret
- speciális dia méret
- különleges dia méret
- teljes méretű dia
- képernyő típusa
- ne méretezze
- illeszkedés biztosítása
- maximalizálás
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan lehet gyorsan átméretezni a diákat PPT, PPTX és ODP fájlokban C++ és Aspose.Slides segítségével, optimalizálva a prezentációkat bármilyen képernyőn a minőség romlása nélkül."
---
## **Bevezetés**

Az Aspose.Slides átfogó eszközöket kínál a diák méretének és képarányának beállításához PowerPoint‑prezentációkban, ami fontos a nyomtatáshoz és a képernyőn való megjelenítéshez.  

Népszerű diaméretek és arányok:

- **Standard (4:3 képarány)**: Ideális régebbi képernyők és eszközök számára.
- **Widescreen (16:9 képarány)**: Ajánlott modern projektorok és kijelzők esetén.

Biztosítsa a konzisztenciát a teljes prezentáción belül, mivel egyetlen diák mérete és képaránya vonatkozik az összes diára. A legjobb eredmény érdekében állítsa be a diák méreteit a prezentáció elkészítésének kezdetén, hogy elkerülje a komplikációkat.

{{% alert color="info" %}} 
Alapértelmezés szerint az Aspose.Slides‑kel létrehozott prezentációk a szabványos 4:3 képarányt használják.
{{% /alert %}}

## **A diák méretének módosítása a prezentációkban**

Ez a mintakód bemutatja, hogyan lehet megváltoztatni egy prezentáció diájának méretét C++‑ban az Aspose.Slides használatával:

``` cpp
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres-4x3-aspect-ratio.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
```

## **Egyéni diaméretek megadása a prezentációkban**

Ha a gyakori diaméretek (4:3 és 16:9) nem megfelelőek az Ön munkájához, dönthet úgy, hogy egy specifikus vagy egyedi diaméretet használ. Például, ha teljes méretű diákat szeretne nyomtatni a prezentációjából egy egyedi oldalelrendezésre, vagy ha a prezentációt bizonyos típusú képernyőkön kívánja megjeleníteni, valószínűleg előnyös lesz egy egyedi méret beállítása a prezentációhoz.

Ez a mintakód bemutatja, hogyan lehet az Aspose.Slides for C++ használatával egyedi diaméretet megadni egy prezentációhoz C++‑ban:

``` cpp
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
// A4 papír méret
pres->get_SlideSize()->SetSize(780.0f, 540.0f, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-a4-slide-size.pptx", SaveFormat::Pptx);
```

## **Diák tartalmának kezelése átméretezés után**

Miután megváltoztatta egy prezentáció diájának méretét, a diák tartalma (például képek vagy objektumok) torzulhat. Alapértelmezés szerint az objektumok automatikusan átméreteződnek, hogy illeszkedjenek az új diamérethez. Azonban a prezentáció diaméretének módosításakor megadhat egy beállítást, amely meghatározza, hogyan kezeli az Aspose.Slides a diák tartalmát.

Attól függően, hogy mit kíván elérni, az alábbi beállítások bármelyikét használhatja:

- `DoNotScale`

  Ha NEM szeretné, hogy a diák objektumai átméreteződjenek, használja ezt a beállítást.

- `EnsureFit`

  Ha kisebb diaméretre szeretne skálázni, és azt szeretné, hogy az Aspose.Slides lecsökkentse a diák objektumait, hogy minden elférjen a diákon (így megakadályozva a tartalom elvesztését), használja ezt a beállítást.

- `Maximize`

  Ha nagyobb diaméretre szeretne skálázni, és azt szeretné, hogy az Aspose.Slides megnövelje a diák objektumait, hogy arányosak legyenek az új diamérettel, használja ezt a beállítást.

Ez a mintakód bemutatja, hogyan kell használni a `Maximize` beállítást egy prezentáció diájának méretének módosításakor:

``` cpp
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
```

## **GYIK**

### Can I set a custom slide size using units other than inches (for example, points or millimeters)?

Igen. Az Aspose.Slides belsőleg pontokat használ, ahol 1 pont = 1/72 hüvelyk. Bármilyen mértékegységet (például millimétert vagy centimétert) átalakíthat pontokra, és az átalakított értékeket felhasználhatja a dia szélességének és magasságának meghatározásához.

### Will a very large custom slide size affect performance and memory usage during rendering?

Igen. A nagyobb diaméretek (pontokban) magasabb renderelési mérettel együtt megnövelt memóriafogyasztást és hosszabb feldolgozási időt eredményeznek. Törekedjen gyakorlati diaméretre, és a renderelési méretet csak a kívánt kimeneti minőség eléréséhez szükséges mértékben állítsa be.

### Can I define one non-standard slide size and then merge slides from presentations that have different sizes?

Nem tudja [merge presentations](/slides/hu/cpp/merge-presentation/) funkcióval egyesíteni őket, ha különböző diaméretek vannak — először átméretezze az egyiket, hogy egyezzen a másikkal. A diaméret módosításakor kiválaszthatja, hogyan kezelje a meglévő tartalmat a [SlideSizeScaleType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/slidesizescaletype/) opcióval. A méretek egyeztetése után egyesítheti a diákot a formázás megőrzése mellett.

### Can I generate thumbnails for individual shapes or specific regions of a slide, and will they respect the new slide size?

Igen. Az Aspose.Slides képes bélyegképeket előállítani [entire slides](https://reference.aspose.com/slides/hu/cpp/aspose.slides/slide/getimage/) és [selected shapes](https://reference.aspose.com/slides/hu/cpp/aspose.slides/shape/getimage/) esetén is. A kapott képek tükrözik az aktuális diaméretet és képarányt, biztosítva az egységes keretezést és geometriát.