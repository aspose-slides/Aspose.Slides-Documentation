---
title: Betűtípus helyettesítés beállítása prezentációkban JavaScript használatával
linktitle: Betűtípus helyettesítés
type: docs
weight: 70
url: /hu/nodejs-java/font-substitution/
keywords:
- betűtípus
- helyettesítő betűtípus
- betűtípus helyettesítés
- betűtípus cseréje
- betűtípus csere
- helyettesítési szabály
- csere szabály
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Aktiválja az optimális betűtípus helyettesítést az Aspose.Slides for Node.js-ben, amikor PowerPoint és OpenDocument prezentációkat konvertál más fájlformátumokra JavaScript-ben."
---
## **Áttekintés**

A betűtípus helyettesítés lehetővé teszi az Aspose.Slides számára, hogy egy másik betűtípust használjon, ha az eredeti prezentáció betűtípusa nem elérhető a renderelés vagy konvertálás során. Ellenőrizheti, mely betűtípusok lettek helyettesítve a `FontsManager` osztály `getSubstitutions` metódusának használatával.

Az Aspose.Slides továbbá lehetővé teszi betűtípus helyettesítési szabályok meghatározását. Például megadhatja, hogy egy elérhetetlen betűtípust egy másik elérhető betűtípussal kell helyettesíteni, majd ezeket a szabályokat a prezentáció betűtípus-kezelője segítségével alkalmazni.

## **Betűtípus helyettesítési szabályok beállítása**

Az Aspose.Slides lehetővé teszi, hogy betűtípusok szabályait beállítsa, amelyek meghatározzák, mi történjen bizonyos feltételek mellett (például amikor egy betűtípus nem érhető el) a következőképpen:

1. Töltse be a megfelelő prezentációt.
2. Töltse be a helyettesítendő betűtípust.
3. Töltse be az új betűtípust.
4. Adjon hozzá egy szabályt a helyettesítéshez.
5. Adja hozzá a szabályt a prezentáció betűtípus helyettesítési szabálygyűjteményéhez.
6. Generálja le a diaképet a hatás megfigyeléséhez.

Ez a JavaScript kód bemutatja a betűtípus helyettesítési folyamatot:

```javascript
// Betölt egy prezentációt
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    // Betölti a helyettesítendő forrásbetűtípust
    var sourceFont = new aspose.slides.FontData("SomeRareFont");
    // Betölti az új betűtípust
    var destFont = new aspose.slides.FontData("Arial");
    // Hozzáad egy betűtípus szabályt a betűtípus cserehez
    var fontSubstRule = new aspose.slides.FontSubstRule(sourceFont, destFont, aspose.slides.FontSubstCondition.WhenInaccessible);
    // Hozzáadja a szabályt a betűtípus helyettesítési szabálygyűjteményhez
    var fontSubstRuleCollection = new aspose.slides.FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);
    // Hozzáad egy betűtípus szabálygyűjteményt a szabálykészlethez
    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);
    // Az Arial betűtípus lesz használva a SomeRareFont helyett, ha az utóbbi nem érhető el
    var slideImage = pres.getSlides().get_Item(0).getImage(1.0, 1.0);
    // Mentés a lemezen JPEG formátumban
    try {
        slideImage.save("Thumbnail_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{%  alert title="NOTE"  color="warning"   %}} 
Érdemes lehet megnézni [**Betűtípus helyettesítés**](/slides/hu/nodejs-java/font-replacement/).
{{% /alert %}}

## **Matematikai egyenlet betűtípusok korlátozásai**

A betűtípus helyettesítési szabályok részt vesznek a renderelés és konvertálás során használt szabványos betűtípus kiválasztási folyamatban. Alkalmazhatók szabályos szöveges helyzetekben, ahol az Aspose.Slides egy elérhetetlen betűtípust a konfigurált szabály szerint egy másik elérhető betűtípussal helyettesíthet.

Azonban az Office matematikai egyenleteknek fontos korlátozásuk van. Ha egy egyenletet **Cambria Math** betűtípussal hoztak létre, az Aspose.Slides továbbra is a eredeti **Cambria Math** betűtípust igényelheti az egyenlet elrendezésének helyes kiszámításához és rendereléséhez. Emiatt a **Cambria Math** helyettesítése egy másik matematikai betűtípussal, például **STIX Two Math**-sal, nem támogatott az egyenlet renderelésénél, és még mindig kivételt eredményezhet, amely jelzi, hogy **Cambria Math** szükséges.

Az ilyen prezentációk sikeres konvertálásához győződjön meg arról, hogy a **Cambria Math** betűtípus elérhető az Aspose.Slides számára futásidőben. A betűtípust telepítheti az operációs rendszerbe, vagy biztosíthatja [külső betűtípusként](/slides/hu/nodejs-java/custom-font/), hogy részt vehessen a normál betűtípus kiválasztási folyamatban a renderelés és konvertálás során.

Ez a korlátozás az egyenlet renderelésére vonatkozik. A fent leírt szabványos betűtípus helyettesítési szabályok továbbra is érvényesek a szabályos prezentációs szövegre, ha az eredeti betűtípus nem érhető el.

## **GYIK**

**Mi a különbség a betűtípus cseréje és a betűtípus helyettesítése között?**

[Csere](/slides/hu/nodejs-java/font-replacement/) egy kényszerített felülírás, amely egy betűtípust egy másikra cserél az egész prezentációban. A helyettesítés egy szabály, amely egy adott feltétel esetén aktiválódik, például amikor az eredeti betűtípus nem érhető el, és ekkor egy megadott tartalék betűtípust használ.

**Mikor pontosan kerülnek alkalmazásra a helyettesítési szabályok?**

A szabályok részt vesznek a szabványos [betűtípus kiválasztás](/slides/hu/nodejs-java/font-selection-sequence/) sorozatban, amely a betöltés, a renderelés és a konvertálás során kerül értékelésre; ha a kiválasztott betűtípus nem érhető el, a csere vagy a helyettesítés alkalmazásra kerül.

**Mi a alapértelmezett viselkedés, ha sem a csere, sem a helyettesítés nincs beállítva, és a betűtípus hiányzik a rendszeren?**

A könyvtár megpróbálja a legközelebbi elérhető rendszerbetűtípust választani, hasonlóan ahhoz, ahogy a PowerPoint viselkedne.

**Csatolhatok egyedi külső betűtípusokat futásidőben a helyettesítés elkerülése érdekében?**

Igen. Futásidőben [külső betűtípusok hozzáadása](/slides/hu/nodejs-java/custom-font/), hogy a könyvtár figyelembe vegye őket a kiválasztás és a renderelés során, beleértve a későbbi konvertálásokat is.

**Az Aspose terjeszt-e betűtípusokat a könyvtárral együtt?**

Nem. Az Aspose nem terjeszt fizetett vagy ingyenes betűtípusokat; a betűtípusokat saját belátása és felelőssége szerint adja hozzá és használja.

**Vannak különbségek a helyettesítési viselkedésben Windows, Linux és macOS rendszereken?**

Igen. A betűtípusok felderítése az operációs rendszer betűtárkijaitól indul. Az alapértelmezett elérhető betűtípusok és a keresési útvonalak platformonként eltérnek, ami befolyásolja a rendelkezésre állást és a helyettesítés szükségességét.

**Hogyan kell előkészíteni a környezetet a váratlan helyettesítések minimalizálása érdekében kötegelt konvertálások során?**

Szinkronizálja a betűtípuskészletet a gépek vagy konténerek között, [külső betűtípusok hozzáadása](/slides/hu/nodejs-java/custom-font/) a kimeneti dokumentumokhoz szükségesen, és ahol lehetséges, [betűtípusok beágyazása](/slides/hu/nodejs-java/embedded-font/) a prezentációkba, hogy a kiválasztott betűtípusok a renderelés során elérhetők legyenek.