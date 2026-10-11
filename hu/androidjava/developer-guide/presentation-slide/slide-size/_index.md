---
title: A prezentáció diákméretének módosítása Androidon
linktitle: Dia mérete
type: docs
weight: 70
url: /hu/androidjava/slide-size/
keywords:
- dia mérete
- képarány
- standard
- szélesvásznú
- 4:3
- 16:9
- dia méretének beállítása
- dia méretének módosítása
- egyedi dia mérete
- különleges dia mérete
- egyedi dia méret
- teljes méretű dia
- képernyő típusa
- ne méretezze
- biztosítsa a megfelelő illeszkedést
- maximalizálás
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Gyorsan átméretezi a diákat PPT, PPTX és ODP fájlokban Java és Aspose.Slides for Android segítségével, optimalizálja a prezentációkat bármely képernyőre minőségvesztés nélkül."
---
## **Bevezetés**

Az Aspose.Slides átfogó eszközöket biztosít a diák méretének és képarányának beállításához a PowerPoint‑prezentációkban, ami a nyomtatáshoz és a képernyőn történő megjelenítéshez egyaránt lényeges.

Népszerű diaméretek és arányok:

- **Standard (4:3 képarány)**: Ideális régebbi képernyők és eszközök számára.
- **Szélesvásznú (16:9 képarány)**: Ajánlott modern projektorok és kijelzők számára.

Biztosítsa a következetességet a teljes prezentáció során, mivel egyetlen diaméret és képarány vonatkozik az összes diára. A legjobb eredmény érdekében állítsa be a diaméreteket a prezentáció létrehozásának kezdetén, hogy elkerülje a komplikációkat.

{{% alert color="info" title="Note" %}}
Alapértelmezés szerint az Aspose.Slides‑kel létrehozott prezentációk a standard 4:3 képarányt használják.
{{% /alert %}}

A jegyzet- és kiosztóoldalak külön méretekkel rendelkeznek a szokásos diákhoz képest. A méretük és tájolásuk módosításához lásd a [Notes Page Size](/slides/hu/androidjava/notes-size/) oldalt.

## **A dia méretének módosítása a prezentációkban**

Ez a mintakód bemutatja, hogyan lehet megváltoztatni egy prezentáció diaméretét Java‑ban az Aspose.Slides használatával:

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

## **Egyedi diaméretek megadása a prezentációkban**

Ha a gyakori diaméretek (4:3 és 16:9) nem felelnek meg az Ön munkájának, úgy dönthet egy specifikus vagy egyedi diaméret használata mellett. Például, ha teljes méretű diákat szeretne nyomtatni a prezentációból egy egyedi oldalelrendezésre, vagy ha egy adott képernyő típuson kívánja megjeleníteni a prezentációt, egyedi méret beállítása hasznos lehet.

Ez a mintakód bemutatja, hogyan kell az Aspose.Slides for Android‑ot Java‑val használni egy egyedi diaméret megadásához egy prezentációban:

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

Miután megváltoztatja egy prezentáció diaméretét, a diák tartalma (képek vagy objektumok stb.) torzulhat. Alapértelmezés szerint az objektumok automatikusan átméreteződnek az új diamérethez igazodva. Azonban a diaméret módosításakor megadhat egy beállítást, amely meghatározza, hogyan kezelje az Aspose.Slides a diák tartalmát.

Attól függően, hogy mit akar elérni, a következő beállítások közül választhat:

- `DoNotScale`

  Ha NEM szeretné, hogy a diákon lévő objektumok átméreteződjenek, használja ezt a beállítást.

- `EnsureFit`

  Ha kisebb diaméretre szeretne skálázni, és azt szeretné, hogy az Aspose.Slides lecsökkentse a diák objektumait, hogy mind mind elférjenek (így elkerülheti a tartalom elvesztését), használja ezt a beállítást.

- `Maximize`

  Ha nagyobb diaméretre szeretne skálázni, és azt szeretné, hogy az Aspose.Slides megnövelje a diák objektumait, hogy arányosak legyenek az új diamérettel, használja ezt a beállítást.

Ez a mintakód bemutatja, hogyan használja a `Maximize` beállítást a prezentáció diaméretének módosításakor:

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

**Beállíthatok egyedi diaméretet inch‑en kívül más egységek (például pont vagy milliméter) használatával?**

Igen. Az Aspose.Slides belsőleg pontokat használ, ahol 1 pont = 1/72 hüvelyk. Bármely egységet (például millimétert vagy centimétert) átalakíthat pontokra, és az átalakított értékeket felhasználhatja a dia szélességének és magasságának meghatározásához.

**A nagyon nagy egyedi diaméret befolyásolja a teljesítményt és a memóriahasználatot a renderelés során?**

Igen. A nagyobb diaméretek (pontokban) magasabb renderelési skálával együtt növelik a memóriafogyasztást és a feldolgozási időt. Célszerű praktikus diaméretet választani, és a renderelési skálát csak a kívánt kimeneti minőség eléréséhez szükséges mértékben módosítani.

**Definiálhatok egy nem szabványos diaméretet, majd összevonhatok diákot olyan prezentációkból, amelyek más méretekkel rendelkeznek?**

Nem vonhat össze [merge presentations](/slides/hu/androidjava/merge-presentation/) olyan prezentációkat, amelyek különböző diaméretekkel rendelkeznek – először módosítsa az egyik prezentáció méretét, hogy megegyezzen a másikkal. A diaméret módosításakor a [SlideSizeScaleType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slidesizescaletype/) opcióval választhatja ki, hogyan kezelje a meglévő tartalmat. A méretek összehangolása után a diák összevonhatók, miközben megőrzik a formázást.

**Készíthetek bélyegképeket egyedi alakzatokról vagy a dia meghatározott területeiről, és ezek figyelembe veszik az új diaméretet?**

Igen. Az Aspose.Slides képes bélyegképeket előállítani [entire slides]https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) és [selected shapes]https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) esetén is. A keletkezett képek tükrözik az aktuális diaméretet és képarányt, biztosítva a következetes keretezést és geometriát.