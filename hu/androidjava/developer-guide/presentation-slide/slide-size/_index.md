---
title: A prezentáció diák méretének módosítása Androidon
linktitle: Dia méret
type: docs
weight: 70
url: /hu/androidjava/slide-size/
keywords:
- dia méret
- képarány
- standard
- szélesvászon
- 4:3
- 16:9
- diáméret beállítása
- diáméret módosítása
- egyedi diáméret
- különleges diáméret
- egyedülálló diáméret
- teljes méretű dia
- képernyőtípus
- ne skálázza
- illeszkedés biztosítása
- maximalizálás
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
descriptions: "Gyorsan átméretezheti a diákat PPT, PPTX és ODP fájlokban Java és az Androidra készült Aspose.Slides segítségével, optimalizálja a prezentációkat bármilyen képernyőre a minőség elvesztése nélkül."
---
## **Bevezetés**

Az Aspose.Slides átfogó eszközöket biztosít a diák méretének és képarányának beállításához PowerPoint‑prezentációkban, ami a nyomtatáshoz és a képernyőn való megjelenítéshez egyaránt fontos.

Népszerű diaméretek és arányok:

- **Standard (4:3 képarány)**: Ideális régebbi képernyők és eszközök számára.
- **Widescreen (16:9 képarány)**: Modern projektorok és kijelzők számára ajánlott.

Biztosítsa a konzisztenciát a teljes prezentációban, mivel egyetlen diaméret és képarány vonatkozik minden diára. A legjobb eredmény érdekében állítsa be a diák méretét a prezentáció létrehozásának elején, hogy elkerülje a problémákat.

{{% alert color="primary" %}} 
Alapértelmezés szerint az Aspose.Slides‑el létrehozott prezentációk a standard 4:3 képarányt használják.
{{% /alert %}}

## **Diák méretének módosítása a prezentációkban**

Ez a példa kód bemutatja, hogyan változtatható meg egy diát mérete egy prezentációban Java‑ban az Aspose.Slides használatával:

```java
Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Egyedi diaméretek megadása a prezentációkban**

Ha úgy találja, hogy a gyakori diaméretek (4:3 és 16:9) nem alkalmasak a munkájához, dönthet úgy, hogy egy meghatározott vagy egyedi diaméretet használ. Például, ha teljes méretű diák nyomtatását tervezi egy egyedi oldalelrendezésre, vagy ha a prezentációt bizonyos képernyőtípusokon szeretné megjeleníteni, akkor valószínűleg előnyös lesz egy egyedi méret beállítása a prezentációhoz.

Ez a példa kód bemutatja, hogyan használhatja az Aspose.Slides for Android‑t Java‑n keresztül egy egyedi diaméret megadásához egy prezentációban Java‑ban:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale); // A4 papírméret
    pres.save("pres-a4-slide-size.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Diák tartalmának kezelése átméretezés után**

A prezentáció diaméretének megváltoztatása után a diák tartalma (például képek vagy objektumok) torzulhat. Alapértelmezés szerint az objektumok automatikusan átméreteződnek, hogy illeszkedjenek az új diamérethez. Azonban diaméret változtatásakor megadhat egy beállítást, amely meghatározza, hogyan kezelje az Aspose.Slides a diák tartalmát.

Attól függően, hogy mit szeretne elérni, az alábbi beállítások bármelyikét használhatja:

- `DoNotScale` – Ha NEM szeretné, hogy a diákon lévő objektumok átméreteződjenek, használja ezt a beállítást.

- `EnsureFit` – Ha kisebb diaméretre szeretne skálázni, és azt szeretné, hogy az Aspose.Slides lecsökkentse a diák objektumait, hogy mind elférjenek a diákon (így elkerülhető a tartalom vesztesége), használja ezt a beállítást.

- `Maximize` – Ha nagyobb diaméretre szeretne skálázni, és azt szeretné, hogy az Aspose.Slides megnövelje a diák objektumait, hogy arányosak legyenek az új diamérettel, használja ezt a beállítást.

Ez a példa kód bemutatja, hogyan használható a `Maximize` beállítás a prezentáció diaméretének módosításakor:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Beállíthatok egyedi diaméretet más egységekben, mint az hüvelyk (például pontok vagy milliméterek)?**

Igen. Az Aspose.Slides belsőleg pontokat használ, ahol 1 pont = 1/72 hüvelyk. Bármely egységet (például millimétert vagy centimétert) átalakíthat pontokra, és a konvertált értékeket felhasználhatja a dia szélességének és magasságának meghatározásához.

**Egy nagyon nagy egyedi diaméret befolyásolja a teljesítményt és a memóriahasználatot a renderelés során?**

Igen. A nagyobb diaméretek (pontban) magasabb renderelési mérettel kombinálva megnövelik a memóriafogyasztást és a feldolgozási időt. Törekedjen egy gyakorlati diaméretre, és csak akkor módosítsa a renderelési méretet, amikor a kívánt kimeneti minőség eléréséhez szükséges.

**Definiálhatok egy nem szabványos diaméretet, majd összevonhatom a különböző méretű prezentációk diáit?**

Nem tudja [prezentációk egyesítése](/slides/hu/androidjava/merge-presentation/) amíg a diák méretei különböznek – először méretezze át az egyik prezentációt, hogy megegyezzen a másikkal. A diaméret változtatásakor a [SlideSizeScaleType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slidesizescaletype/) opcióval választhatja ki, hogyan kezelje a meglévő tartalmat. A méretek egyeztetése után egyesítheti a diákot, miközben megőrzi a formázást.

**Létrehozhatok bélyegképeket egyedi alakzatokhoz vagy egy dián belüli meghatározott területekhez, és figyelembe veszik az új diaméretet?**

Igen. Az Aspose.Slides képes bélyegképeket generálni [teljes diákra](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) valamint [kijelölt alakzatokra](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/shape/#getImage-int-float-float-). A kapott képek tükrözik a aktuális diaméretet és képarányt, biztosítva az egységes keretezést és geometriát.