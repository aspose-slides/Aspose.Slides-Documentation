---
title: A prezentáció diájának méretének módosítása Androidon
linktitle: Dia Mérete
type: docs
weight: 70
url: /hu/androidjava/slide-size/
keywords:
- dia méret
- képarány
- szabványos
- szélesvászon
- 4:3
- 16:9
- dia méretének beállítása
- dia méretének módosítása
- egyedi dia méret
- különleges dia méret
- egyedi dia méret
- teljes méretű dia
- képernyő típus
- ne méretezze
- illeszkedés biztosítása
- maximalizálás
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: Gyorsan átméretezheti a diákat PPT, PPTX és ODP fájlokban Java és Aspose.Slides for Android segítségével, optimalizálja a prezentációkat bármilyen képernyőre minőségromlás nélkül.
---
## **Bevezetés**

Az Aspose.Slides átfogó eszközöket biztosít a diák méretének és képarányának beállításához a PowerPoint‑prezentációkban, ami mind a nyomtatás, mind a képernyőn megjelenítés szempontjából kritikus.

Népszerű diák méretek és arányok:
- **Standard (4:3 képarány)**: Ideális régebbi képernyők és eszközök számára.
- **Widescreen (16:9 képarány)**: Ajánlott modern projektorok és kijelzők számára.

Biztosítsa a konzisztenciát a teljes prezentációban, mivel egyetlen diák mérete és képaránya minden diára vonatkozik. A legjobb eredmény érdekében állítsa be a diák méretét a prezentáció létrehozásának elején, hogy elkerülje a problémákat.

{{% alert color="info" %}} 
Alapértelmezés szerint az Aspose.Slides‑kel létrehozott prezentációk a standard 4:3 képarányt használják.
{{% /alert %}}

## **Diák méretének módosítása a prezentációkban**

Ez a példa kód bemutatja, hogyan változtatható meg egy prezentáció diájának mérete Java‑ban az Aspose.Slides használatával:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Egyedi diák méretek megadása a prezentációkban**

Ha a gyakori diák méretek (4:3 és 16:9) nem megfelelőek az Ön munkájához, dönthet úgy, hogy egy adott vagy egyedi diák méretet használ. Például, ha teljes méretű diákat szeretne nyomtatni a prezentációjából egy egyedi oldalelrendezésre, vagy ha bizonyos képernyőtípusokon kívánja megjeleníteni a prezentációt, valószínűleg hasznára válik egy egyedi méret beállítása.

Ez a példa kód bemutatja, hogyan használható az Aspose.Slides for Android Java‑on keresztül egy egyedi diák méret megadásához egy prezentációban Java‑ban:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // A4 papírméret
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Diák tartalmának kezelése átméretezés után**

A prezentáció diák méretének megváltoztatása után a diák tartalma (például képek vagy objektumok) torzulhat. Alapértelmezés szerint az objektumok automatikusan átméreteződnek, hogy illeszkedjenek az új diák méretéhez. Azonban a prezentáció diák méretének módosításakor megadhat egy beállítást, amely meghatározza, hogyan kezeli az Aspose.Slides a diák tartalmát.

Attól függően, hogy mit kíván tenni vagy elérni, a következő beállítások bármelyike használható:
- `DoNotScale`

  Ha NEM kívánja, hogy a diák objektumai átméreteződjenek, használja ezt a beállítást.

- `EnsureFit`

  Ha kisebb diák méretre kíván skálázni, és azt szeretné, hogy az Aspose.Slides lecsökkentse a diák objektumait, hogy mind elférjenek a diákon (ezáltal elkerülve a tartalom elvesztését), használja ezt a beállítást.

- `Maximize`

  Ha nagyobb diák méretre kíván skálázni, és azt szeretné, hogy az Aspose.Slides megnövelje a diák objektumait, hogy arányosak legyenek az új diák mérettel, használja ezt a beállítást.

Ez a példa kód bemutatja, hogyan kell használni a `Maximize` beállítást a prezentáció diák méretének módosításakor:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

### Beállíthatok egyedi diák méretet hüvelyk helyett más mértékegységgel (például ponttal vagy milliméterrel)?

Igen. Az Aspose.Slides belsőleg pontokat használ, ahol 1 pont = 1/72 hüvelyk. Bármely mértékegységet (például millimétert vagy centimétert) átalakíthat pontokra, és a konvertált értékekkel meghatározhatja a diák szélességét és magasságát.

### Nagyon nagy egyedi diák méret befolyásolja a teljesítményt és a memóriahasználatot a renderelés során?

Igen. A nagyobb diák méretek (pontban) magasabb renderelési skálával együtt megnövekedett memóriafogyasztást és hosszabb feldolgozási időt eredményeznek. Törekedjen egy gyakorlati diák méretre, és csak szükség szerint állítsa a renderelési skálát a kívánt kimeneti minőség eléréséhez.

### Definiálhatok egy nem szabványos diák méretet, majd összevonhatok diákot olyan prezentációkból, amelyek eltérő méretekkel rendelkeznek?

Nem vonhat össze [prezentációkat](/slides/hu/androidjava/merge-presentation/) amíg különböző diák méretekkel rendelkeznek – először méretezze át az egyik prezentációt, hogy egyezzen a másikkal. A diák méretének változtatásakor kiválaszthatja a meglévő tartalom kezelését a [SlideSizeScaleType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slidesizescaletype/) lehetőséggel. A méretek egyeztetése után összevonhatja a diákot, miközben megőrzi a formázást.

### Generálhatok bélyegképeket egyedi alakzatokhoz vagy a dia meghatározott részeihez, és ezek figyelembe veszik az új diák méretét?

Igen. Az Aspose.Slides képes bélyegképeket renderelni [teljes diákra](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) és [kijelölt alakzatokra](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/shape/#getImage-int-float-float-). A kapott képek tükrözik az aktuális diák méretét és képarányát, biztosítva az egységes keretezést és geometriát.