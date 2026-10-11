---
title: A prezentáció diája méretének módosítása JavaScriptben
linktitle: Dia mérete
type: docs
weight: 70
url: /hu/nodejs-java/slide-size/
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
- speciális dia méret
- különleges dia méret
- teljes méretű dia
- képernyőtípus
- ne méretezze
- biztos illeszkedés
- maximalizálás
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Ismerje meg, hogyan lehet gyorsan átméretezni a diákat PPT, PPTX és ODP fájlokban Node.js és Aspose.Slides segítségével, optimalizálja a prezentációkat bármilyen képernyőre a minőség megőrzése nélkül."
---
## **Bevezetés**

Az Aspose.Slides átfogó eszközöket biztosít a dia méretének és képarányának beállításához PowerPoint‑prezentációkban, ami mind a nyomtatás, mind a képernyőn való megjelenítés szempontjából kritikus.

Népszerű diák méretei és arányai:

- **Standard (4:3 képarány)**: Ideális régebbi képernyők és eszközök számára.
- **Widescreen (16:9 képarány)**: Ajánlott modern projektorok és kijelzők számára.

Biztosítsa a konzisztenciát a prezentációban, mivel egyetlen diaméret és képarány vonatkozik az összes diára. Az optimális eredmény érdekében állítsa be a diák méretét a prezentációkészítés elején, hogy elkerülje a problémákat.

{{% alert color="info" title="Note" %}}
Alapértelmezés szerint az Aspose.Slides‑el létrehozott prezentációk a standard 4:3 képarányt használják.
{{% /alert %}}

A jegyzet- és kéziszórólapok méretei különböznek a normál diákétól. Lásd a [Jegyzetoldal mérete](/slides/hu/nodejs-java/notes-size/) oldalt, hogy megváltoztassa méretüket és tájolásukat.

## **Diák méretének módosítása a prezentációkban**

Ez a mintakód bemutatja, hogyan lehet megváltoztatni egy prezentáció diájának méretét JavaScript‑ben az Aspose.Slides használatával:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(aspose.slides.SlideSizeType.OnScreen16x9, aspose.slides.SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Egyedi diák méreteinek megadása a prezentációkban**

Ha a szokásos diák méretei (4:3 és 16:9) nem felelnek meg az Ön munkájának, dönthet úgy, hogy egy meghatározott vagy egyedi diaméretet használ. Például, ha a prezentációból teljes méretű diákat szeretne nyomtatni egy egyedi oldaltervre, vagy ha a prezentációt bizonyos típusú képernyőkön kívánja megjeleníteni, valószínűleg hasznos lesz egy egyedi méret beállítása a prezentációhoz.

Ez a mintakód bemutatja, hogyan használható az Aspose.Slides for Node.js Java‑on keresztül egy egyedi diaméret megadásához a prezentációban JavaScript‑ben:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, aspose.slides.SlideSizeScaleType.DoNotScale);// A4 papírméret
    pres.save("pres-a4-slide-size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Problémák kezelése a diákméret változtatásakor a prezentációkban**

Miután megváltoztatja egy prezentáció diájának méretét, a diák tartalma (például képek vagy objektumok) torzulhat. Alapértelmezés szerint az objektumok automatikusan átméreteződnek, hogy illeszkedjenek az új diamérethez. Azonban a prezentáció diaméretének módosításakor megadhat egy beállítást, amely meghatározza, hogyan kezelje az Aspose.Slides a diák tartalmát.

Attól függően, hogy mit kíván elérni, az alábbi beállítások bármelyikét használhatja:

- `DoNotScale`

  Ha NEM szeretné, hogy a diákon lévő objektumok átméreteződjenek, használja ezt a beállítást.

- `EnsureFit`

  Ha kisebb diaméretre szeretne méretezni, és arra van szüksége, hogy az Aspose.Slides lecsökkentse a diák objektumait, hogy mind elférjenek a diákon (ezzel elkerülve a tartalom elvesztését), használja ezt a beállítást.

- `Maximize`

  Ha nagyobb diaméretre szeretne méretezni, és arra van szüksége, hogy az Aspose.Slides megnövelje a diák objektumait, hogy arányosak legyenek az új diamérettel, használja ezt a beállítást.

Ez a mintakód bemutatja, hogyan kell használni a `Maximize` beállítást a prezentáció diájának méretének módosításakor:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(aspose.slides.SlideSizeType.Ledger, aspose.slides.SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **GYIK**

**Beállíthatok egyedi diaméretet hüvelyken kívül más egységek (például pontok vagy milliméterek) használatával?**

Igen. Az Aspose.Slides belsőleg pontokat használ, ahol 1 pont = 1/72 hüvelyknek felel meg. Bármely egységet (például millimétert vagy centimétert) konvertálhat pontokra, és a konvertált értékeket felhasználhatja a dia szélességének és magasságának meghatározásához.

**Egy nagyon nagy egyedi diaméret befolyásolja a teljesítményt és a memóriahasználatot a renderelés során?**

Igen. A nagyobb diaméretek (pontban) és a magasabb renderelési méretezés együttesen megnövelt memóriafogyasztáshoz és hosszabb feldolgozási időkhöz vezetnek. Törekedjen egy praktikus diaméretre, és csak a szükséges mértékben állítsa be a renderelési méretezést a kívánt kimeneti minőség eléréséhez.

**Definiálhatok egy nem szabványos diaméretet, majd egyesíthetek diákat olyan prezentációkból, amelyek különböző méretekkel rendelkeznek?**

Nem tudja [prezentációk egyesítése](/slides/hu/nodejs-java/merge-presentation/) amíg különböző diaméretek vannak — először méretezze át az egyik prezentációt, hogy egyezzen a másikkal. A diaméret módosításakor választhat, hogy a meglévő tartalmat hogyan kezelje a [SlideSizeScaleType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slidesizescaletype/) opcióval. A méretek egyeztetése után egyesítheti a diákot a formázás megőrzésével.

**Létrehozhatok előnézeti képeket egyedi alakzatok vagy a dia meghatározott területei számára, és ezek figyelembe veszik az új diaméretet?**

Igen. Az Aspose.Slides képes előnézeti képeket generálni [teljes diákra](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slide/#getImage) és [kiválasztott alakzatokra](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/#getImage) egyaránt. A kapott képek tükrözik az aktuális diaméretet és képarányt, biztosítva a következetes keretezést és geometriát.