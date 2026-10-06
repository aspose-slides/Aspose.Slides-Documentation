---
title: A prezentáció diák méretének módosítása C++-ban
linktitle: Dia mérete
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
- különleges dia méret
- egyedülálló dia méret
- teljes méretű dia
- képernyő típus
- ne skálázza
- illeszkedés biztosítása
- maximalizálás
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan lehet gyorsan átméretezni a diákat PPT, PPTX és ODP fájlokban C++ és Aspose.Slides segítségével, optimalizálja a prezentációkat bármely képernyőhöz anélkül, hogy a minőség romlana."
---
## **Bevezetés**

Az Aspose.Slides átfogó eszközöket biztosít a diák méretének és képarányának beállításához a PowerPoint‑prezentációkban, ami a nyomtatás és a képernyőn megjelenítés szempontjából egyaránt kritikus.

Népszerű diák méretek és arányok:

- **Standard (4:3 képarány)**: Ideális régebbi képernyők és eszközök számára.
- **Widescreen (16:9 képarány)**: Ajánlott modern projektorokhoz és kijelzőkhöz.

Biztosítsa a konzisztenciát a teljes prezentációban, mivel egyetlen diák méret és képarány érvényes minden diára. A legjobb eredmény érdekében a diák méretét a prezentáció létrehozásának kezdetén állítsa be, hogy elkerülje a későbbi komplikációkat.

{{% alert color="info" %}} 
Alapértelmezés szerint az Aspose.Slides‑kel létrehozott prezentációk a standard 4:3 képarányt használják.
{{% /alert %}}

A jegyzet- és kézbesítőoldalak méretei különböznek a normál diákétól. Lásd a [Megjegyzés oldal mérete](/slides/hu/cpp/notes-size/) részt a méret és tájolás módosításához.

## **A diák méretének módosítása a prezentációkban**

 Ez a példakód bemutatja, hogyan módosítható egy prezentáció diák mérete C++‑ban az Aspose.Slides használatával:

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

## **Egyedi diák méretének megadása a prezentációkban**

Ha a gyakori diák méretek (4:3 és 16:9) nem megfelelőek az Ön munkájához, egy specifikus vagy egyedi diák méret használatát választhatja. Például, ha teljes méretű diák nyomtatását tervezi egy egyedi lapelrendezésre, vagy ha a prezentációt bizonyos képernyőtípusokon kívánja megjeleníteni, valószínűleg hasznos lesz egy egyedi méret beállítása a prezentációhoz.

Ez a példakód bemutatja, hogyan adható meg egy egyedi diák méret C++‑ban az Aspose.Slides segítségével:

``` cpp
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
// A4 papírméret
pres->get_SlideSize()->SetSize(780.0f, 540.0f, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-a4-slide-size.pptx", SaveFormat::Pptx);
```

## **Dia tartalmának kezelése átméretezés után**

Miután megváltoztatta egy prezentáció diák méretét, a diák tartalma (például képek vagy objektumok) torzulhat. Alapértelmezés szerint az objektumok automatikusan átméreteződnek, hogy illeszkedjenek az új diák méretéhez. Azonban a prezentáció diák méretének módosításakor megadhat egy beállítást, amely meghatározza, hogyan kezeli az Aspose.Slides a diák tartalmát.

Attól függően, hogy mit szeretne elérni, az alábbi beállítások közül választhat:

- `DoNotScale`

  Ha NEM szeretné, hogy a diák objektumai átméreteződjenek, használja ezt a beállítást.

- `EnsureFit`

  Ha kisebb diák méretre akar skálázni, és azt szeretné, hogy az Aspose.Slides lecsökkentse a diák objektumait, hogy mindegyik elférjen a diákon (ezáltal elkerülve a tartalom elvesztését), használja ezt a beállítást.

- `Maximize`

  Ha nagyobb diák méretre akar skálázni, és azt szeretné, hogy az Aspose.Slides megnövelje a diák objektumait, hogy arányosak legyenek az új diák méretével, használja ezt a beállítást.

Ez a példakód bemutatja, hogyan használható a `Maximize` beállítás a prezentáció diák méretének módosításakor:

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

### Beállíthatok egyedi diák méretet olyan egységekben, amelyek nem hüvelykek (például pont vagy milliméter)?

Igen. Az Aspose.Slides belsőleg pontokat használ, ahol 1 pont = 1/72 hüvelyk. Bármely egységet (például millimétert vagy centimétert) átalakíthat pontokra, és a konvertált értékekkel adhatja meg a diák szélességét és magasságát.

### Nagyon nagy egyedi diák méret hatással van a teljesítményre és a memóriahasználatra a renderelés során?

Igen. A nagyobb diák méretek (pontokban) és a magasabb renderelési skála kombinációja megnövekedett memóriafogyasztást és hosszabb feldolgozási időt eredményez. Törekedjen praktikus diák méretre, és csak akkor növelje a renderelési skálát, ha a kívánt kimeneti minőség eléréséhez szükséges.

### Meghatározhatok egy nem szabványos diák méretet, majd összevonhatok diáidat olyan prezentációkból, amelyek különböző méretekkel rendelkeznek?

Nem vonhat össze [prezentációkat](/slides/hu/cpp/merge-presentation/) különböző diák méretek esetén – először méretezze át az egyiket, hogy egyezzen a másikkal. A diák méretének módosításakor a [SlideSizeScaleType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/slidesizescaletype/) opcióval kiválaszthatja, hogyan kezelje a meglévő tartalmat. A méretek egyeztetése után összevonhatja a diákot, miközben megőrzi a formázást.

### Generálhatok előnézeti képeket egyedi alakzatokról vagy a dia egyes területeiről, és ezek figyelembe veszik az új diák méretét?

Igen. Az Aspose.Slides készíthet előnézeti képeket [teljes diákokról](https://reference.aspose.com/slides/hu/cpp/aspose.slides/slide/getimage/) és [kiválasztott alakzatokról](https://reference.aspose.com/slides/hu/cpp/aspose.slides/shape/getimage/) egyaránt. A keletkezett képek tükrözik az aktuális diák méretét és képarányát, biztosítva az egységes keretezést és geometriát.