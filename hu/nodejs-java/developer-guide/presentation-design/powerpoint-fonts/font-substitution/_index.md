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
- csereszabály
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Betűtípus-helyettesítési szabályok konfigurálása és a helyettesített betűtípusok ellenőrzése az Aspose.Slides for Node.js-ban Java használatával PowerPoint és OpenDocument prezentációk renderelése vagy konvertálása során."
---
## **Áttekintés**

A betűtípus-helyettesítés lehetővé teszi, hogy az Aspose.Slides egy elérhető betűtípust használjon egy nem elérhető betűtípus helyett, amikor egy prezentációt renderelnek vagy konvertálnak. A helyettesítés a megjelenített kimenetet érinti; nem változtatja meg a prezentáció tartalmához rendelt betűtípust.

Megadhatja a használni kívánt betűtípust, amikor egy adott betűtípus nem áll rendelkezésre, és megtekintheti az Aspose.Slides által a renderelés során végrehajtott helyettesítéseket. Ez segít abban, hogy a kimenet következetes maradjon különböző, más betűtípusokkal rendelkező környezetekben.

Ha egy betűtípus elérhető, de nincs dedikált félkövér változata, lásd a [Kezelje a betűtípusokat, amelyeknek nincs dedikált félkövér változat](/slides/hu/nodejs-java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface) szakaszt. Az a szakasz bemutatja, hogyan kell rasterizálni az érintett szöveget PDF exportáláskor, valamint a szövegkijelölésre, keresésre és méretezésre gyakorolt hatásait.

## **Betűtípus-helyettesítések lekérése**

Használja a [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) metódust annak meghatározására, hogy mely betűtípusok lesznek helyettesítve a prezentáció renderelésekor. A metódus [FontSubstitutionInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstitutioninfo/) objektumokat ad vissza, amelyek az eredeti és a helyettesített betűtípusok nevét tartalmazzák.

A következő JavaScript példa felsorolja egy prezentáció összes betűtípus-helyettesítését:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var substitutions = presentation.getFontsManager().getSubstitutions().iterator();
    while (substitutions.hasNext()) {
        var substitution = substitutions.next();
        console.log(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }
} finally {
    presentation.dispose();
}
```

## **Betűtípus-helyettesítések lekérése a kiválasztott diákhoz**

Használja a [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) túlterhelést egy diákindexekből álló tömbbel, hogy csak a konkrét diákok rendereléséhez szükséges helyettesítéseket ellenőrizze. Ez akkor hasznos, ha a prezentáció egy részét rendereli vagy exportálja, fokozatosan ellenőrzi a nagyméretű prezentációt, olyan diákokat keres, amelyek nem elérhető betűtípusoktól függenek, minimális betűtípuscsomagot készít szerver vagy konténer részére, vagy a renderelési eltéréseket kívánja diagnosztizálni anélkül, hogy a nem releváns diákokat feldolgozná.

A túlterhelés egy Java primitív `int[]`‑t vár. Hozza létre a `java.newArray("int", [...])`‑vel; egy egyszerű JavaScript tömb `Integer[]`‑re konvertálódik, és nem felel meg ennek a túlterhelésnek.

A tömb egy‑bázisos diákindexeket tartalmaz: `1` az első diát jelöli. Ezzel szemben a [Presentation.getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getslides/) kollekcióhozzáférő nulla‑bázisos indexelést használ, így ugyanaz a dia `presentation.getSlides().get_Item(0)`‑ként érhető el. Tartsa szem előtt ezt a különbséget a tömb összeállításakor, hogy elkerülje az egy‑off hibákat.

Hívja a túlterhelést a [Presentation.getFontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getfontsmanager/) segítségével. Csak a kiválasztott diák renderelése közben meghatározott helyettesítéseket adja vissza. Minden eredmény egy [FontSubstitutionInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstitutioninfo/) objektum, amely tartalmazza az eredeti és a helyettesített betűtípusok neveit. Az eredmény tükrözi a jelenlegi betűtípus-környezetet, a beállított visszaesési szabályokat, a [FontSubstRuleCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrulecollection/)-ben tárolt helyettesítési szabályokat, valamint az [externally loaded fonts](/slides/hu/nodejs-java/custom-font/)-et.

Ugyanaz a helyettesítés több kiválasztott dia esetén is szükséges lehet. Szűrje le a duplikátumokat, amikor betűtípus‑leltárt vagy pre‑flight jelentést készít. A következő példa minden visszaadott helyettesítést jelent, majd egy rendezett listát hoz létre az egyedi betűtípus-leképezésekből:

```javascript
var aspose = aspose || {};
const java = require("java");
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var selectedSlides = java.newArray("int", [1, 3, 5]);
    var substitutions = [];
    var substitutionIterator = presentation.getFontsManager().getSubstitutions(selectedSlides).iterator();
    while (substitutionIterator.hasNext()) {
        substitutions.push(substitutionIterator.next());
    }

    console.log("Substitutions for the selected slides:");
    substitutions.forEach(function (substitution) {
        console.log(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    });

    var preflightEntries = substitutions.map(function (substitution) {
        return substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName();
    });
    var sortedPreflightEntries = Array.from(new Set(preflightEntries)).sort(function (first, second) {
        return first.localeCompare(second, undefined, { sensitivity: "base" });
    });

    console.log("Deduplicated font preflight report:");
    sortedPreflightEntries.forEach(function (entry) {
        console.log(entry);
    });
} finally {
    presentation.dispose();
}
```

A [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/) osztály mindkét túlterhelést biztosítja. Válasszon egyet a renderelési művelet hatókörének megfelelően:

| Overload | Use it when |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) argumentumok nélkül | A teljes prezentációhoz szükséges helyettesítéseket. |
| [getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) Java `int[]` csúszkaindexekkel | Kiválasztott tartomány, fokozatos ellenőrzés vagy részleges export esetén szükséges helyettesítéseket. |

## **Betűtípus-helyettesítési szabályok beállítása**

1. Töltse be a prezentációt.  
2. Hozzon létre betűtípus-definíciókat a forrás- és helyettesítő betűtípusokhoz.  
3. Hozzon létre egy [FontSubstRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrule/) a [WhenInaccessible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstcondition/) feltétellel.  
4. Adja hozzá a szabályt egy [FontSubstRuleCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrulecollection/)-hez.  
5. Rendelje hozzá a gyűjteményt a [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/setfontsubstrulelist/) metódus használatával.  
6. Renderelje vagy konvertálja a prezentációt.

A következő JavaScript példa a `Arial` betűtípust helyettesíti a `SomeRareFont`‑nal, ha a `SomeRareFont` nem érhető el, majd az első diát rendereli a végeredmény ellenőrzéséhez. A helyettesítő betűtípusnak elérhetőnek kell lennie az Aspose.Slides számára.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var sourceFont = new aspose.slides.FontData("SomeRareFont");
    var substituteFont = new aspose.slides.FontData("Arial");
    var substitutionRule = new aspose.slides.FontSubstRule(sourceFont, substituteFont, aspose.slides.FontSubstCondition.WhenInaccessible);

    var substitutionRules = new aspose.slides.FontSubstRuleCollection();
    substitutionRules.add(substitutionRule);
    presentation.getFontsManager().setFontSubstRuleList(substitutionRules);

    var image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0);
    try {
        image.save("slide.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Az egész prezentációban egy feltétel nélküli betűtípus‑cseréhez lásd a [Betűtípus csere](/slides/hu/nodejs-java/font-replacement/) oldalt.
{{% /alert %}}

## **Matematikai egyenlet betűtípusok korlátozásai**

A betűtípus-helyettesítési szabályok a renderelés és konvertálás során használt szabványos betűtípus‑kiválasztási folyamat részei. Általános szöveg esetén működnek, amikor az Aspose.Slides egy nem elérhető betűtípust a szabály által meghatározott elérhető betűtípussal helyettesíthet.

Az Office Math egyenletek további követelményeket támasztanak. Ha egy egyenlet **Cambria Math** betűtípust használ, az Aspose.Slides‑nek pontosan ezt a betűtípust kell rendelkezésre állnia az egyenlet elrendezésének kiszámításához és rendereléséhez. Egy másik matematikai betűtípusra, például **STIX Two Math**, mutató szabály nem helyettesítheti a **Cambria Math**‑ot ebben a célban, és a renderelés továbbra is azt jelezheti, hogy **Cambria Math** szükséges.

Az ilyen prezentáció rendereléséhez vagy konvertálásához tegye elérhetővé a **Cambria Math** betűtípust az Aspose.Slides számára. Telepítse a rendszerbe, vagy töltse be egy [external font](/slides/hu/nodejs-java/custom-font/)‑ként.

Ez a korlátozás az egyenlet‑elrendezésre vonatkozik. A fent leírt helyettesítési szabályok továbbra is érvényesek a prezentáció általános szövegére.

## **GYIK**

**Mi a különbség a betűtípus csere és a betűtípus helyettesítés között?**

A [Betűtípus csere](/slides/hu/nodejs-java/font-replacement/) szándékosan megváltoztat egy betűtípust egy másikra a teljes prezentációban. A betűtípus helyettesítés egy betűtípust választ a megjelenített kimenethez, amikor a konfigurált feltétel teljesül, például amikor az eredeti betűtípus nem áll rendelkezésre.

**Mikor alkalmazzák a helyettesítési szabályokat?**

A szabályok részt vesznek a [betűtípus kiválasztási sorozat](/slides/hu/nodejs-java/font-selection-sequence/) során a renderelés és konvertálás közben. A `WhenInaccessible` esetén a szabály csak akkor használatos, amikor az Aspose.Slides nem fér hozzá a forrás betűtípushoz.

**Mi történik, ha egy betűtípus hiányzik és nincs beállított helyettesítési szabály?**

Az Aspose.Slides a legközelebbi elérhető betűtípust választja a betűtípus‑kiválasztási folyamat szerint. Az eredmény a futási környezetben elérhető betűtípusoktól függ.

**Betölthetek külső betűtípusokat a helyettesítés elkerülése érdekében?**

Igen. A [Betűtípusok betöltése külső forrásból](/slides/hu/nodejs-java/custom-font/) lehetővé teszi, hogy az Aspose.Slides használja őket a renderelés és konvertálás során.

**Az Aspose a betűtípusokat a könyvtárral együtt terjeszti?**

Nem. Önnek kell biztosítania a betűtípusokat és betartania azok licencfeltételeit.

**A helyettesítési eredmények eltérhetnek Windows, Linux és macOS között?**

Igen. Az operációs rendszer szerint eltérőek a telepített betűtípusok és a betűtípus‑keresési helyek, így egy gépen elérhető betűtípus egy másikon helyettesítést igényelhet.

**Hogyan tehetem a betűtípus‑kiválasztást konzisztenssé kötegelt konverziók során?**

Használja ugyanazokat a betűtípus‑fájlokat és verziókat minden gépen vagy konténerben, [töltse be a szükséges külső betűtípusokat](/slides/hu/nodejs-java/custom-font/), és [ágyazza be a betűtípusokat](/slides/hu/nodejs-java/embedded-font/) ha a licence megengedi. Emellett meghívhatja a [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) exportálás előtt, hogy azonosítsa a váratlan helyettesítéseket.