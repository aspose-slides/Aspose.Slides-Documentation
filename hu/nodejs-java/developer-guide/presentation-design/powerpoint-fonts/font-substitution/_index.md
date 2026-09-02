---
title: Betűtípus-helyettesítés beállítása prezentációkban JavaScript használatával
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
description: "Állítsa be a betűtípus-helyettesítési szabályokat, és ellenőrizze a helyettesített betűtípusokat az Aspose.Slides for Node.js-ben Java használatával a PowerPoint és OpenDocument prezentációk megjelenítése vagy konvertálása során."
---
## **Áttekintés**

A betűtípus-helyettesítés lehetővé teszi az Aspose.Slides számára, hogy egy elérhető betűtípust használjon egy olyan betűtípus helyett, amelyhez nem lehet hozzáférni a bemutató megjelenítése vagy konvertálása során. A helyettesítés a megjelenített kimenetet érinti; nem változtatja meg a prezentáció tartalmához rendelt betűtípust.

Megadhatja a használni kívánt betűtípust, ha egy adott betűtípus nem elérhető, és megtekintheti a helyettesítéseket, amelyeket az Aspose.Slides a megjelenítés során végez. Ez segít abban, hogy a kimenet konzisztens maradjon a különböző telepített betűtípusokkal rendelkező környezetek között.

## **Betűtípus-helyettesítések lekérése**

Használja a [FontsManager.getSubstitutions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) metódust annak meghatározásához, hogy mely betűtípusok lesznek helyettesítve a prezentáció megjelenítésekor. A metódus [FontSubstitutionInfo](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontsubstitutioninfo/) objektumokat ad vissza, amelyek az eredeti és a helyettesített betűtípusok neveit tartalmazzák.

A következő JavaScript példa felsorolja az összes betűtípus-helyettesítést egy prezentációhoz:

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

## **Kiválasztott diák betűtípus-helyettesítéseinek lekérése**

Használja a [FontsManager.getSubstitutions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) túlterhelést egy diák indexek tömbjével, hogy csak a konkrét diák megjelenítéséhez szükséges helyettesítéseket vizsgálja. Ez hasznos, ha a prezentáció egy részét jeleníti meg vagy exportálja, egy nagy prezentációt fokozatosan ellenőrzi, olyan diákat keres, amelyek nem elérhető betűtípusoktól függenek, egy minimális betűtípus-csomagot készít szerver vagy konténer számára, vagy a megjelenítési különbségeket diagnosztizálja anélkül, hogy a nem releváns diákat feldolgozná.

A túlterhelés egy Java primitív `int[]` típusú tömböt vár. Hozza létre a `java.newArray("int", [...])` segítségével; egy egyszerű JavaScript tömb `Integer[]`-re konvertálódik, és nem felel meg ennek a túlterhelésnek.

A tömb egy‑bázisú diák indexeket tartalmaz: `1` az első diát jelöli. Ezzel szemben a [Presentation.getSlides](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/getslides/) gyűjtemény-elérő nulla‑bázisú indexelést használ, így ugyanaz a dia `presentation.getSlides().get_Item(0)`‑ként érhető el. Tartsa szem előtt ezt a különbséget a tömb építésekor, hogy elkerülje az egy‑eltérésű hibákat.

Hívja meg a túlterhelést a [Presentation.getFontsManager](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/getfontsmanager/) segítségével. Csak azokat a helyettesítéseket adja vissza, amelyeket a kiválasztott diák megjelenítése során határozott meg. Minden eredmény egy [FontSubstitutionInfo](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontsubstitutioninfo/) objektum, amely tartalmazza az eredeti és a helyettesített betűtípusok neveit. Az eredmény tükrözi a jelenlegi betűtípus-környezetet, a konfigurált tartalék szabályokat, a [FontSubstRuleCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontsubstrulecollection/) tárolt helyettesítési szabályokat, valamint a [külsőleg betöltött betűtípusokat](/slides/hu/nodejs-java/custom-font/).

Ugyanaz a helyettesítés több, mint egy kiválasztott dián is szükséges lehet. Távolítsa el a duplikátumokat az eredményekből, amikor betűtípus-inventárt vagy előzetes jelentést készít. A következő példa minden visszaadott helyettesítést jelent, majd egy rendezett listát hoz létre az egyedi betűtípus-leképezésekből:

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

A [FontsManager](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontsmanager/) osztály mindkét túlterhelést biztosítja. Válasszon egyet a megjelenítési művelet hatóköre szerint:

| Túlterhelés | Mikor használja |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) paraméterek nélkül | Szüksége van helyettesítésekre a teljes prezentációhoz. |
| [getSubstitutions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) Java `int[]` diák indexekkel | Szüksége van helyettesítésekre egy kiválasztott tartományra, fokozatos ellenőrzésre vagy részleges exportálásra. |

## **Betűtípus-helyettesítési szabályok beállítása**

Az Aspose.Slides által egy forrás betűtípus hiányában használandó betűtípus megadásához:
1. Töltse be a prezentációt.
2. Hozzon létre betűtípus-definíciókat a forrás és a helyettesítő betűtípusokhoz.
3. Hozzon létre egy [FontSubstRule](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontsubstrule/) objektumot a [WhenInaccessible](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontsubstcondition/) feltétellel.
4. Adja hozzá a szabályt egy [FontSubstRuleCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontsubstrulecollection/) gyűjteményhez.
5. Rendelje hozzá a gyűjteményt a [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontsmanager/setfontsubstrulelist/) metódus használatával.
6. Jelenítse meg vagy konvertálja a prezentációt.

A következő JavaScript példa a `SomeRareFont` helyett `Arial`-t helyettesíti, ha a `SomeRareFont` nem érhető el, majd megjeleníti az első diát az eredmény ellenőrzéséhez. A helyettesítő betűtípusnak elérhetőnek kell lennie az Aspose.Slides számára.

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
Egy teljes prezentációra kiterjedő feltétel nélküli betűtípus-cseréhez lásd a [Font Replacement](/slides/hu/nodejs-java/font-replacement/) oldalt.
{{% /alert %}}

## **Matematikai egyenlet betűtípusok korlátozásai**

A betűtípus-helyettesítési szabályok a megjelenítés és konvertálás során használt szabványos betűtípus-kiválasztási folyamat részei. Rendszeres szövegnél működnek, amikor az Aspose.Slides egy elérhetetlen betűtípust egy szabály által meghatározott elérhető betűtípussal helyettesíthet.

Az Office Math egyenleteknek további követelményük van. Ha egy egyenlet **Cambria Math** betűtípust használ, az Aspose.Slidesnek pontosan ezt a betűtípust kell tudnia a képlet elrendezésének kiszámításához és megjelenítéséhez. Egy olyan szabály, amely egy másik matematikai betűtípust, például **STIX Two Math**-ot helyettesít, nem tudja lecserélni a **Cambria Math**-ot erre a célra, és a megjelenítés továbbra is azt jelezheti, hogy **Cambria Math** szükséges.

Az ilyen prezentáció megjelenítéséhez vagy konvertálásához tegye **Cambria Math**-ot elérhetővé az Aspose.Slides számára. Telepítse az operációs rendszerbe, vagy töltse be [külső betűtípusként](/slides/hu/nodejs-java/custom-font/).

Ez a korlátozás az egyenletelrendezésre vonatkozik. A fent leírt helyettesítési szabályok továbbra is érvényesek a normál prezentációs szövegre.

## **GYIK**

**Mi a különbség a betűtípus-cserélés és a betűtípus-helyettesítés között?**

[Font replacement](/slides/hu/nodejs-java/font-replacement/) szándékosan megváltoztat egy betűtípust egy másikra a teljes prezentáció során. A betűtípus-helyettesítés egy betűtípust választ a megjelenített kimenethez, ha a konfigurált feltétel teljesül, például amikor az eredeti betűtípus nem érhető el.

**Mikor alkalmazzák a helyettesítési szabályokat?**

A szabályok a [betűtípus-kiválasztási sorozat](/slides/hu/nodejs-java/font-selection-sequence/) részeként vesznek részt a megjelenítés és konvertálás során. A `WhenInaccessible` esetén a szabály csak akkor használatos, amikor az Aspose.Slides nem tudja elérni a forrás betűtípust.

**Mi történik, ha egy betűtípus hiányzik és nincs konfigurálva helyettesítési szabály?**

Az Aspose.Slides a legközelebbi elérhető betűtípust választja a betűtípus-kiválasztási folyamata szerint. Az eredmény a futásidejű környezetben elérhető betűtípusoktól függ.

**Betölthetek külső betűtípusokat a helyettesítés elkerüléséhez?**

Igen. [Betöltheti a külső betűtípusokat](/slides/hu/nodejs-java/custom-font/), így az Aspose.Slides használhatja őket a megjelenítés és konvertálás során.

**Az Aspose a betűtípusokat a könyvtárral együtt terjeszti?**

Nem. Ön felelős a betűtípusok biztosításáért és azok licencfeltételeinek betartásáért.

**A helyettesítési eredmények eltérhetnek Windows, Linux és macOS között?**

Igen. A telepített betűtípusok és a betűtípus-keresési helyek operációs rendszerenként eltérnek, így egy gépen elérhető betűtípus egy másikon helyettesítést igényelhet.

**Hogyan tehetem egységessé a betűtípus-kiválasztást kötegelt konvertálások során?**

Használja ugyanazokat a betűtípus-fájlokat és verziókat minden gépen vagy konténerben, [töltse be a szükséges külső betűtípusokat](/slides/hu/nodejs-java/custom-font/), és ha a licenc megengedi, [ágyazza be a betűtípusokat](/slides/hu/nodejs-java/embedded-font/). Ezen felül a [FontsManager.getSubstitutions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) metódust is meghívhatja az exportálás előtt a váratlan helyettesítések azonosításához.