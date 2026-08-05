---
title: "A prezentáció dia méretének módosítása Androidon"
linktitle: "Dia méret"
type: docs
weight: 70
url: /hu/androidjava/slide-size/
keywords:
- "dia méret"
- "képarány"
- "standard"
- "szélesvásznú"
- "4:3"
- "16:9"
- "dia méret beállítása"
- "dia méret módosítása"
- "egyedi dia méret"
- "különleges dia méret"
- "különálló dia méret"
- "teljes méretű dia"
- "képernyő típusa"
- "ne méretezze"
- "illeszkedés biztosítása"
- "maximalizálás"
- "PowerPoint"
- "OpenDocument"
- "prezentáció"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Gyorsan átméretezheti a diákat PPT, PPTX és ODP fájlokban Java és az Androidra készült Aspose.Slides segítségével, optimalizálja a prezentációkat bármely képernyőre minőségromlás nélkül."
---
## **Bevezetés**

Az Aspose.Slides átfogó eszközöket biztosít a diák méretének és képarányának beállításához a PowerPoint‑prezentációkban, ami mind nyomtatáshoz, mind képernyőn való megjelenítéshez kritikus.

Népszerű diaképek és arányok:

- **Standard (4:3 képarány)**: Ideális régebbi képernyőkhöz és eszközökhöz.  
- **Szélesvásznú (16:9 képarány)**: Ajánlott modern projektorokhoz és kijelzőkhöz.

Biztosítsa a konzisztenciát a teljes prezentációban, mivel egyetlen diaméret és képarány vonatkozik minden diára. A legjobb eredmény érdekében állítsa be a diák méretét a prezentációkészítés elején, hogy elkerülje a későbbi komplikációkat.

{{% alert color="primary" %}} 
Alapértelmezés szerint az Aspose.Slides‑kel létrehozott prezentációk a szabványos 4:3 képarányt használják.
{{% /alert %}}

## **A diák méretének módosítása a prezentációkban**

Ez a mintakód megmutatja, hogyan változtatható meg egy prezentáció diamérete Java‑ban az Aspose.Slides használatával:

```java
Presentation pres = new Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Egyéni diaképek megadása a prezentációkban**

Ha a gyakori diaméretek (4:3 és 16:9) nem megfelelőek az Ön munkájához, úgy dönthet egy specifikus vagy egyedi diaméret használata mellett. Például, ha teljes méretű diák nyomtatását tervezi egy egyedi oldalelrendezésre, vagy ha a prezentációt bizonyos képernyőtípusokon szeretné megjeleníteni, valószínűleg hasznos lesz az egyéni méret beállítása.

Ez a mintakód megmutatja, hogyan lehet az Aspose.Slides for Android‑t Java‑val használva egyedi diaméretet megadni egy Java‑prezentációhoz:

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

Miután megváltoztatta egy prezentáció diaméretét, a diák tartalma (képek vagy objektumok például) torzulhat. Alapértelmezés szerint az objektumok automatikusan átméreteződnek az új diamérethez igazodva. Azonban a diaméret módosításakor megadhat egy beállítást, amely meghatározza, hogyan kezeli az Aspose.Slides a diák tartalmát.

Attól függően, mit szeretne elérni, az alábbi beállítások valamelyikét használhatja:

- `DoNotScale`

  Ha **NEM** szeretné, hogy a diák objektumai átméreteződjenek, használja ezt a beállítást.

- `EnsureFit`

  Ha kisebb diaméretre szeretne skálázni, és azt akarja, hogy az Aspose.Slides lecsökkentse a diák objektumait, hogy mind elférjenek (így elkerülve a tartalom elvesztését), használja ezt a beállítást.

- `Maximize`

  Ha nagyobb diaméretre szeretne skálázni, és azt akarja, hogy az Aspose.Slides megnövelje a diák objektumait, hogy azok arányosan illeszkedjenek az új mérethez, használja ezt a beállítást.

Ez a mintakód megmutatja, hogyan kell használni a `Maximize` beállítást egy prezentáció diaméretének módosításakor:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Beállíthatok egyedi diaméretet hüvelyk helyett más mértékegységekben (például pontban vagy milliméterben)?**

Igen. Az Aspose.Slides belsőleg pontokat használ, ahol 1 pont = 1/72 hüvelyk. Bármely mértékegységet (például millimétert vagy centimétert) átalakíthat pontokra, és a kapott értékeket felhasználhatja a diák szélességének és magasságának meghatározásához.

**A nagyon nagy egyedi diaméret befolyásolja a teljesítményt és a memóriahasználatot a renderelés során?**

Igen. A nagyobb diaméretek (pontokban) magasabb renderelési mérettel kombinálva növelik a memóriaigényt és a feldolgozási időt. Célszerű gyakorlati diaméretet választani, és a renderelési méretet csak a kívánt kimeneti minőség eléréséhez szükséges mértékben módosítani.

**Definiálhatok egy nem szabványos diaméretet, majd összefésülhetem a diák különböző méretű prezentációkból?**

Nem [összefésülhetünk prezentációkat](/slides/hu/androidjava/merge-presentation/) akkor, ha eltérő diaméretek vannak – először egy prezentációt át kell méretezni, hogy egyezzen a másikkal. A diaméret módosításakor a [SlideSizeScaleType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slidesizescaletype/) opcióval meghatározhatja, hogyan kezelje a meglévő tartalmat. A méretek egyeztetése után összefésülheti a diákot, miközben megőrzi a formázást.

**Létrehozhatok miniatűr képeket egyedi alakzatokhoz vagy a dia meghatározott részeihez, és ezek tiszteletben tartják az új diaméretet?**

Igen. Az Aspose.Slides képes miniatűrök generálására [teljes diákhoz](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) valamint [kiválasztott alakzatokhoz](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/shape/#getImage-int-float-float-). A kapott képek tükrözik az aktuális diaméretet és képarányt, ezzel biztosítva az egységes keretezést és geometriát.