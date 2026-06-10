---
title: A prezentáció dia méretének módosítása PHP-ben
linktitle: Dia méret
type: docs
weight: 70
url: /hu/php-java/slide-size/
keywords:
- dia méret
- képarány
- szabványos
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
- ne méretezze
- biztos illeszkedés
- maximalizálás
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
descriptions: "Ismerje meg, hogyan lehet gyorsan átméretezni a diákot PPT, PPTX és ODP fájlokban PHP és Aspose.Slides segítségével, valamint optimalizálja a prezentációkat bármilyen képernyőhöz a minőség elvesztése nélkül."
---
## **Bevezetés**

Az Aspose.Slides átfogó eszközöket biztosít a dia méretének és képarányának beállításához PowerPoint‑prezentációkban, ami fontos a nyomtatáshoz és a képernyőn történő megjelenítéshez. 

Népszerű dia méretek és arányok:

- **Standard (4:3 képarány)**: Ideális régebbi képernyők és eszközök számára.
- **Szélesvászon (16:9 képarány)**: Ajánlott modern projektorokhoz és kijelzőkhöz.

Biztosítsa a konzisztenciát a teljes prezentációban, mivel egyetlen dia méret és képarány vonatkozik az összes diára. A legjobb eredmény érdekében állítsa be a dia méreteit a prezentáció létrehozási folyamatának elején, hogy elkerülje a komplikációkat.

{{% alert color="primary" %}} 
Alapértelmezés szerint az Aspose.Slides‑kel létrehozott prezentációk a szabványos 4:3 képarányt használják.
{{% /alert %}}

## **Dia méretének módosítása a prezentációkban**

Ez a példa kód bemutatja, hogyan lehet megváltoztatni egy prezentáció dia méretét az Aspose.Slides használatával:

```php
  $pres = new Presentation("pres-4x3-aspect-ratio.pptx");
  try {
    $pres->getSlideSize()->setSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
    $pres->save("pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Egyéni dia méretek megadása a prezentációkban**

Ha a gyakori dia méreteket (4:3 és 16:9) nem megfelelőnek találja a munkájához, úgy dönthet, hogy egy meghatározott vagy egyedi dia méretet használ. Például, ha a prezentációból teljes méretű diák nyomtatását tervezi egy egyedi oldalelrendezésre, vagy ha a prezentációt bizonyos képernyő típusokon kívánja megjeleníteni, akkor valószínűleg hasznos lesz egy egyedi méret beállítása a prezentációhoz. 

Ez a példa kód bemutatja, hogyan használhatja az Aspose.Slides for PHP via Java‑t egy egyedi dia méret megadásához egy prezentációban :

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->getSlideSize()->setSize(780, 540, SlideSizeScaleType::DoNotScale);// A4 papírméret

    $pres->save("pres-a4-slide-size.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Dia tartalmának kezelése a méretezés után**

Miután megváltoztatta egy prezentáció dia méretét, a diák tartalma (például képek vagy objektumok) torzulhat. Alapértelmezés szerint az objektumok automatikusan átméreteződnek, hogy illeszkedjenek az új dia mérethez. Azonban a prezentáció dia méretének módosításakor megadhat egy beállítást, amely meghatározza, hogyan kezeli az Aspose.Slides a diák tartalmát.

Attól függően, hogy mit szeretne elérni, használhatja az alábbi beállítások bármelyikét:

- `DoNotScale`

  Ha NEM szeretné, hogy a diákon lévő objektumok át legyenek méretezve, használja ezt a beállítást.

- `EnsureFit`

  Ha kisebb dia méretre szeretne méretezni, és azt szeretné, hogy az Aspose.Slides lecsökkentse a diák objektumait, hogy mind elférjenek a diákon (ezzel elkerülve a tartalom elvesztését), használja ezt a beállítást.

- `Maximize`

  Ha nagyobb dia méretre szeretne méretezni, és azt szeretné, hogy az Aspose.Slides megnövelje a diák objektumait, hogy arányosak legyenek az új dia mérettel, használja ezt a beállítást.

Ez a példa kód bemutatja, hogyan kell használni a `Maximize` beállítást egy prezentáció dia méretének megváltoztatásakor:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->getSlideSize()->setSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **GYIK**

**Beállíthatok egyedi dia méretet hüvelyk helyett más mértékegységekben (például pont vagy milliméter) használva?**

Igen. Az Aspose.Slides belsőleg pontokat használ, ahol 1 pont = 1/72 hüvelyk. Bármely mértékegységet (például millimétert vagy centimétert) átalakíthat pontokra, és az átalakított értékeket használhatja a dia szélességének és magasságának meghatározásához.

**Egy nagyon nagy egyedi dia méret befolyásolja a teljesítményt és a memóriahasználatot a renderelés során?**

Igen. A nagyobb dia méretek (pontban) magasabb renderelési skálával együtt megnövelt memóriafogyasztást és hosszabb feldolgozási időt eredményeznek. Célozzon egy praktikus dia méretre, és a renderelési skálát csak akkor állítsa be, amikor szükséges a kívánt kimeneti minőség eléréséhez.

**Definiálhatok egy nem szabványos dia méretet, majd összevonhatok diákat olyan prezentációkból, amelyek különböző méretekkel rendelkeznek?**

Nem tudja [prezentációk összevonása](/slides/hu/php-java/merge-presentation/) amíg különböző dia méretekkel rendelkeznek — először méretezze át az egyik prezentációt, hogy megegyezzen a másikkal. A dia méretének módosításakor kiválaszthatja, hogyan kezelje a meglévő tartalmat a [SlideSizeScaleType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slidesizescaletype/) opcióval. A méretek egyeztetése után összevonhatja a diákot a formázás megőrzésével.

**Létrehozhatok miniatűr képeket egyedi alakzatokhoz vagy egy dia meghatározott területeihez, és figyelembe veszik az új dia méretet?**

Igen. Az Aspose.Slides képes miniatűr képeket előállítani a [teljes diák](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slide/#getImage) és a [kiválasztott alakzatok](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/#getImage) számára is. A keletkezett képek tükrözik az aktuális dia méretet és képarányt, biztosítva az egységes keretezést és geometriai arányt.