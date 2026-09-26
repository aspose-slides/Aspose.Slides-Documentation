---
title: A prezentáció diák méretének módosítása PHP-ben
linktitle: Dia méret
type: docs
weight: 70
url: /hu/php-java/slide-size/
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
- képernyőtípus
- ne méretezzen
- biztosítsa a beilleszkedést
- maximalizálás
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Tanulja meg, hogyan méretezhet gyorsan diákat PPT, PPTX és ODP fájlokban PHP és Aspose.Slides használatával, optimalizálja a prezentációkat bármilyen képernyőre a minőség romlása nélkül."
---
## **Bevezetés**

Az Aspose.Slides átfogó eszközöket kínál a diák méretének és képarányának módosításához a PowerPoint‑prezentációkban, ami nyomtatás és képernyőmegjelenítés esetén egyaránt kritikus.

Népszerű diák méretei és arányai:

- **Standard (4:3 képarány)**: Ideális a régebbi képernyők és eszközök számára.
- **Widescreen (16:9 képarány)**: Ajánlott a modern projektorok és kijelzők számára.

Biztosítsa a konzisztenciát a teljes prezentációban, mivel egyetlen diák mérete és képaránya vonatkozik minden diára. Az optimális eredmény érdekében állítsa be a dia méreteit a prezentáció elkészítésének kezdetén, hogy elkerülje a problémákat.

{{% alert color="info" title="Note" %}}
Alapértelmezés szerint az Aspose.Slides‑al létrehozott prezentációk a szabványos 4:3 képarányt használják.
{{% /alert %}}

A jegyzet‑ és szórólap‑oldalak méretei különböznek a szokásos diákétól. Lásd a [Jegyzetoldal mérete](/slides/hu/php-java/notes-size/) szakaszt a méret és tájolás módosításához.

## **Dia méretének módosítása a prezentációkban**

Ez a mintakód megmutatja, hogyan módosíthatja egy prezentáció dia méretét az Aspose.Slides használatával:

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

## **Egyedi diák méreteinek meghatározása a prezentációkban**

Ha a gyakori diák méretek (4:3 és 16:9) nem felelnek meg az Ön munkájának, dönthet úgy, hogy egy adott vagy egyedi dia méretet használ. Például, ha egyedi oldalkiosztásra kívánja nyomtatni a prezentáció teljes méretű diáit, vagy ha a prezentációt bizonyos képernyőtípusokon szeretné megjeleníteni, akkor valószínűleg előnyös lesz egy egyedi méretbeállítás használata.

Ez a mintakód megmutatja, hogyan használhatja az Aspose.Slides for PHP‑t Java‑n keresztül egy egyedi dia méret meghatározásához egy prezentációban:

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

Miután megváltoztatta egy prezentáció dia méretét, a diák tartalma (például képek vagy objektumok) torzulhat. Alapértelmezés szerint az objektumok automatikusan átméreteződnek, hogy illeszkedjenek az új dia méretéhez. Azonban a prezentáció dia méretének módosításakor megadhat egy beállítást, amely meghatározza, hogyan kezeli az Aspose.Slides a diák tartalmát.

Attól függően, hogy mit kíván tenni vagy elérni, bármelyik következő beállítást használhatja:

- `DoNotScale`

  Ha NEM szeretné, hogy a diákon lévő objektumok átméreteződjenek, használja ezt a beállítást.

- `EnsureFit`

  Ha kisebb dia méretre szeretne méretezni, és azt igényli, hogy az Aspose.Slides lecsökkentse a diák objektumait, hogy mind elférjen a dián (így elkerülve a tartalom elvesztését), használja ezt a beállítást.

- `Maximize`

  Ha nagyobb dia méretre szeretne méretezni, és azt igényli, hogy az Aspose.Slides növelje a diák objektumait, hogy arányosak legyenek az új dia mérettel, használja ezt a beállítást.

Ez a mintakód megmutatja, hogyan használhatja a `Maximize` beállítást a prezentáció dia méretének módosításakor:

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

## **Gyakran Ismételt Kérdések**

**Beállíthatok egyedi dia méretet hüvelyken kívül más mértékegységekben (például pontban vagy milliméterben)?**

Igen. Az Aspose.Slides belsőleg pontokat használ, ahol 1 pont = 1/72 hüvelyk. Bármely mértékegységet (például millimétert vagy centimétert) átalakíthat pontokra, és a konvertált értékeket felhasználhatja a dia szélességének és magasságának meghatározásához.

**Nagy egyedi dia méret befolyásolja a teljesítményt és a memóriahasználatot a renderelés során?**

Igen. A nagyobb dia méretek (pontban) magasabb renderelési skálával együtt megnövekedett memóriafogyasztást és hosszabb feldolgozási időt eredményeznek. Törekedjen egy praktikus dia méretre, és a renderelési skálát csak akkor módosítsa, ha a kívánt kimeneti minőség eléréséhez szükséges.

**Megadhatok egy nem szabványos dia méretet, majd összevonhatok diákat különböző méretű prezentációkból?**

Nem [vonhat össze prezentációkat](/slides/hu/php-java/merge-presentation/) eltérő dia méretek esetén – először méretezze át az egyik prezentációt, hogy egyezzen a másikkel. A dia méretének módosításakor kiválaszthatja, hogyan kezelje a meglévő tartalmat a [SlideSizeScaleType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slidesizescaletype/) opcióval. A méretek egyeztetése után összevonhatja a diákot, miközben megtartja a formázást.

**Készíthetek előnézeti képeket egyedi alakzatok vagy egyes diaterületek számára, és figyelembe veszik a új dia méretet?**

Igen. Az Aspose.Slides előnézeti képeket képes renderelni [teljes diákra](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slide/#getImage) és [kiválasztott alakzatokra](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/#getImage). A kapott képek tükrözik az aktuális dia méretét és képarányát, biztosítva az egységes keretezést és geometriát.