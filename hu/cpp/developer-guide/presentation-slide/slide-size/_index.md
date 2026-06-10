---
title: A prezentáció diák méretének módosítása C++-ban
linktitle: Dia mérete
type: docs
weight: 70
url: /hu/cpp/slide-size/
keywords:
- dia mérete
- képarány
- standard
- szélesvászon
- 4:3
- 16:9
- dia méretének beállítása
- dia méretének módosítása
- egyedi dia méret
- különleges dia méret
- különálló dia méret
- teljes méretű dia
- képernyőtípus
- ne skálázza
- biztosítsa a passzolást
- maximalizálás
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
descriptions: "Ismerje meg, hogyan lehet gyorsan átméretezni diákat PPT, PPTX és ODP fájlokban C++ és Aspose.Slides segítségével, optimalizálja a prezentációkat bármilyen képernyőre a minőség romlása nélkül."
---
## **Bevezetés**

Az Aspose.Slides átfogó eszközöket biztosít a diák méretének és képarányának beállításához a PowerPoint‑prezentációkban, ami a nyomtatáshoz és a képernyőn való megjelenítéshez egyaránt kritikus.

Népszerű diaméretek és arányok:

- **Standard (4:3 képarány)**: Ideális régebbi képernyők és eszközök számára.
- **Szélesvászon (16:9 képarány)**: Ajánlott modern projektorok és kijelzők számára.

Biztosítsa a következetességet a prezentáció során, mivel egyetlen diaméret és képarány vonatkozik az összes diára. A legjobb eredmény érdekében állítsa be a diák méretét a prezentáció létrehozásának elején, hogy elkerülje a problémákat.

{{% alert color="primary" %}} 
Alapértelmezés szerint az Aspose.Slides‑kel létrehozott prezentációk a szabványos 4:3 képarányt használják.
{{% /alert %}}

## **Diaméret módosítása a prezentációkban**

Ez a mintakód bemutatja, hogyan módosítható a diaméret egy prezentációban C++‑ban az Aspose.Slides használatával:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres-4x3-aspect-ratio.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
```

## **Egyéni diaméretek meghatározása a prezentációkban**

Ha a gyakori diaméretek (4:3 és 16:9) nem felelnek meg a munkájának, úgy dönthet, hogy egy konkrét vagy egyedi diaméretet használ. Például ha teljes méretű diákat szeretne nyomtatni a prezentációból egy egyedi oldalelrendezésre, vagy ha a prezentációt bizonyos képernyőtípusokon kívánja megjeleníteni, akkor valószínűleg hasznos lesz egy egyéni méret beállítása a prezentációhoz.

Ez a mintakód bemutatja, hogyan használhatja az Aspose.Slides for C++‑t egy egyedi diaméret meghatározásához egy prezentációban C++‑ban:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
// A4 papír méret
pres->get_SlideSize()->SetSize(780.0f, 540.0f, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-a4-slide-size.pptx", SaveFormat::Pptx);
```

## **Diatartalom kezelése a méretezés után**

Miután megváltoztatja egy prezentáció diaméretét, a diák tartalma (például képek vagy objektumok) torzulhat. Alapértelmezés szerint az objektumok automatikusan átméreteződnek, hogy illeszkedjenek az új diamérethez. Azonban a prezentáció diaméretének módosításakor megadhat egy beállítást, amely meghatározza, hogyan kezeli az Aspose.Slides a diák tartalmát.

Attól függően, hogy mit kíván tenni vagy elérni, használhatja a következő beállítások egyikét:

- `DoNotScale`

  Ha NEM szeretné, hogy a diákon lévő objektumok átméreteződjenek, használja ezt a beállítást.

- `EnsureFit`

  Ha kisebb diaméretre szeretne skálázni, és azt igényli, hogy az Aspose.Slides a diák objektumait lecsökkentse annak érdekében, hogy mind bekerüljenek a diákra (ezzel elkerülve a tartalom elvesztését), használja ezt a beállítást.

- `Maximize`

  Ha nagyobb diaméretre szeretne skálázni, és azt igényli, hogy az Aspose.Slides a diák objektumait megnövelje, hogy arányosak legyenek az új diamérettel, használja ezt a beállítást.

Ez a mintakód bemutatja, hogyan használható a `Maximize` beállítás a prezentáció diaméretének módosításakor:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
```

## **GYIK**

**Beállíthatok egyedi diaméretet más egységekben, mint az inches (például pontok vagy milliméterek)?**

Igen. Az Aspose.Slides belsőleg pontokat használ, ahol 1 pont = 1/72 hüvelyk. Bármely egységet (például millimétert vagy centimétert) átalakíthat pontokra, és a konvertált értékeket felhasználhatja a diák szélességének és magasságának meghatározásához.

**Egy nagyon nagy egyedi diaméret befolyásolja a teljesítményt és a memóriahasználatot a renderelés során?**

Igen. A nagyobb diaméretek (pontban) magasabb renderelési skálával együtt növelik a memóriaigényt és meghosszabbítják a feldolgozási időt. Célozzon meg egy praktikus diaméretet, és a renderelési skálát csak akkor módosítsa, ha szükséges a kívánt kimeneti minőség eléréséhez.

**Definiálhatok egy nem szabványos diaméretet, majd egyesíthetek diákat olyan prezentációkból, amik különböző méretekkel rendelkeznek?**

Nem tudja [prezentációk egyesítése](/slides/hu/cpp/merge-presentation/) amíg különböző diaméretek vannak — először méretezze át az egyik prezentációt, hogy egyezzen a másikkal. Diaméret módosításakor kiválaszthatja, hogyan kezelje a meglévő tartalmat a [SlideSizeScaleType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/slidesizescaletype/) opcióval. A méretek egyeztetése után egyesítheti a diákot a formázás megőrzésével.

**Generálhatok bélyegképeket egyedi alakzatokhoz vagy egy diára jellemző területekhez, és ezeket a bélyegképeket figyelembe veszik az új diaméretet?**

Igen. Az Aspose.Slides tud bélyegképeket renderelni a [teljes diák](https://reference.aspose.com/slides/hu/cpp/aspose.slides/slide/getimage/) és a [kiválasztott alakzatok](https://reference.aspose.com/slides/hu/cpp/aspose.slides/shape/getimage/) számára is. A keletkező képek tükrözik az aktuális diaméretet és képarányt, biztosítva az egységes keretezést és geometriai pontosságot.