---
title: A prezentáció diák méretének módosítása PHP-ben
linktitle: Dia mérete
type: docs
weight: 70
url: /hu/php-java/slide-size/
keywords:
- dia mérete
- képarány
- standard
- szélesvászon
- 4:3
- 16:9
- dia méretének beállítása
- dia méretének módosítása
- egyéni dia méret
- különleges dia méret
- egyedi dia méret
- teljes méretű dia
- képernyőtípus
- ne skálázz
- biztosíts illeszkedést
- maximalizálás
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Ismerje meg, hogyan lehet gyorsan átméretezni a diákat PPT, PPTX és ODP fájlokban PHP és Aspose.Slides segítségével, optimalizálva a prezentációkat bármilyen képernyőre a minőség megőrzése nélkül."
---
## **Bevezetés**

Az Aspose.Slides átfogó eszközöket biztosít a diák méretének és képarányának beállításához a PowerPoint‑prezentációkban, ami kulcsfontosságú mind nyomtatáshoz, mind képernyőn történő megjelenítéshez.

Népszerű diák méretei és arányai:

- **Standard (4:3 képarány)**: Ideális régebbi képernyők és eszközök számára.
- **Widescreen (16:9 képarány)**: Ajánlott modern projektorok és kijelzők esetén.

Biztosítsa a konzisztenciát a teljes prezentációban, mivel egyetlen diák mérete és képaránya vonatkozik az összes diara. A legjobb eredmény érdekében állítsa be a dia méreteit a prezentáció létrehozásának elején, hogy elkerülje a későbbi problémákat.

{{% alert color="primary" %}} 
Alapértelmezés szerint az Aspose.Slides‑kel létrehozott prezentációk a standard 4:3 képarányt használják.
{{% /alert %}}

## **Diák méretének módosítása a prezentációkban**

Ez a példakód megmutatja, hogyan változtatható meg egy prezentáció diák mérete az Aspose.Slides használatával:

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

## **Egyéni diák méretének megadása a prezentációkban**

Ha a gyakori diák méretek (4:3 és 16:9) nem felelnek meg az Ön munkájának, dönthet úgy, hogy egy specifikus vagy egyedi diák méretet használ. Például, ha a prezentációból teljes méretű diák nyomtatását tervezi egy egyedi oldalelrendezésre, vagy ha a prezentációt bizonyos képernyőtípusokon kívánja megjeleníteni, valószínűleg hasznos lesz egy egyedi méretbeállítást alkalmazni.

Ez a példakód megmutatja, hogyan használható az Aspose.Slides for PHP via Java egyedi diák méret megadására egy prezentációhoz:

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

## **Dia tartalmának kezelése átméretezés után**

A prezentáció diák méretének módosítása után a diák tartalma (képek vagy objektumok például) torzulhat. Alapértelmezés szerint az objektumok automatikusan átméreteződnek, hogy illeszkedjenek az új diák méretéhez. A diák méretének megváltoztatásakor azonban megadhat egy beállítást, amely meghatározza, hogyan kezeli az Aspose.Slides a diák tartalmát.

Az Ön céljától függően az alábbi beállítások közül választhat:

- `DoNotScale`

  Ha NEM szeretné, hogy a diákon lévő objektumok átméreteződjenek, használja ezt a beállítást.

- `EnsureFit`

  Ha kisebb diák méretre szeretne skálázni, és azt szeretné, hogy az Aspose.Slides lecsökkentse a diák objektumait, hogy minden elférjen (így elkerülve a tartalom elvesztését), használja ezt a beállítást.

- `Maximize`

  Ha nagyobb diák méretre szeretne skálázni, és azt szeretné, hogy az Aspose.Slides felnagyítsa a diák objektumait, hogy arányosak legyenek az új diák méretével, használja ezt a beállítást.

Ez a példakód megmutatja, hogyan használható a `Maximize` beállítás egy prezentáció diák méretének módosításakor:

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

**Beállíthatok egy egyéni diák méretet olyan mértékegységgel, amely nem hüvelyk (például pont vagy milliméter)?**

Igen. Az Aspose.Slides belsőleg pontokat használ, ahol 1 pont = 1/72 hüvelyk. Bármely mértékegységet (például millimétert vagy centimétert) átválthat pontokra, és a konvertált értékekkel meghatározhatja a dia szélességét és magasságát.

**Nagy egyéni diák méret befolyásolja a teljesítményt és a memóriahasználatot a renderelés során?**

Igen. A nagyobb diák méretek (pontban) magasabb renderelési skálával együtt növelik a memóriafogyasztást és a feldolgozási időt. Törekedjen egy praktikus diák méretre, és a renderelési skálát csak a kívánt kimeneti minőség eléréséhez szükséges mértékben állítsa be.

**Definiálhatok egy nem szabványos diák méretet, majd egyesíthetek diákot olyan prezentációkból, amelynek különböző méretei vannak?**

Nem tudja [prezentációkat egyesíteni](/slides/hu/php-java/merge-presentation/) amíg különböző diák méretekkel rendelkeznek — először méretezze át az egyiket, hogy megfeleljen a másiknak. A diák méretének módosításakor kiválaszthatja, hogyan kezelje a meglévő tartalmat a [SlideSizeScaleType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slidesizescaletype/) beállítással. A méretek egyeztetése után egyesítheti a diákot a formázás megőrzése mellett.

**Létrehozhatok bélyegképeket egyedi alakzatokhoz vagy a dia meghatározott részeihez, és ezek figyelembe veszik az új diák méretet?**

Igen. Az Aspose.Slides képes bélyegképeket létrehozni [teljes diákokról](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slide/#getImage) és [kijelölt alakzatokról](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/#getImage) egyaránt. A keletkezett képek tükrözik az aktuális diák méretét és képarányát, biztosítva a konzisztens keretezést és geometriát.