---
title: Betűkészlet-helyettesítés konfigurálása prezentációkban Java használatával
linktitle: Betűkészlet helyettesítés
type: docs
weight: 70
url: /hu/java/font-substitution/
keywords:
- betűkészlet
- helyettesítő betűkészlet
- betűkészlet helyettesítés
- betűkészlet cseréje
- betűkészlet csere
- helyettesítési szabály
- csereszabály
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Betűkészlet-helyettesítési szabályok konfigurálása és a helyettesített betűkészletek ellenőrzése az Aspose.Slides for Java-ban a PowerPoint és OpenDocument prezentációk renderelése vagy konvertálása során."
---
## **Áttekintés**

A betűkészlethelyettesítés lehetővé teszi, hogy az Aspose.Slides egy elérhető betűkészletet használjon egy nem hozzáférhető betűkészlet helyett, amikor a prezentáció megjelenik vagy konvertálódik. A helyettesítés csak a renderelt kimenetet érinti; nem módosítja a prezentáció tartalmához tartozó betűkészletet.

Megadhatja, hogy melyik betűkészletet használja, ha egy bizonyos betűkészlet nem elérhető, és ellenőrizheti az Aspose.Slides által a renderelés során végrehajtott helyettesítéseket. Ez segít abban, hogy a kimenet konzisztens maradjon a különböző telepített betűkészletekkel rendelkező környezetek között.

## **Betűkészlethelyettesítések lekérése**

Használja a [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) metódust annak meghatározásához, hogy mely betűkészletek lesznek helyettesítve a prezentáció renderelése során. A metódus [FontSubstitutionInfo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fontsubstitutioninfo/) objektumokat ad vissza, amelyek az eredeti és a helyettesített betűkészlet nevét tartalmazzák.

Az alábbi Java példa felsorolja az összes betűkészlethelyettesítést egy prezentációhoz:

```java
import com.aspose.slides.FontSubstitutionInfo;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions()) {
        System.out.println(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }
} finally {
    presentation.dispose();
}
```

## **Betűkészlethelyettesítések lekérése a kiválasztott diákhoz**

Használja az [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) túlterhelést `int[] slides` argumentummal, hogy csak a konkrét diák rendereléséhez szükséges helyettesítéseket vizsgálja. Ez hasznos, ha a prezentáció egy részét rendereli vagy exportálja, egy nagy prezentációt fokozatosan ellenőrzi, olyan diákat keres, amelyek nem elérhető betűkészletektől függenek, minimális betűkészletcsomagot készít szerver vagy konténer számára, vagy a renderelési eltéréseket diagnosztizálja anélkül, hogy a nem releváns diák feldolgozása megtörténne.

A `slides` tömb egy‑alapú diaindexeket tartalmaz: az `1` az első diát jelöli. Ezzel szemben a [Presentation.getSlides](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#getSlides--) kollekciólekérő nulla‑alapú indexelést használ, így ugyanaz a dia `presentation.getSlides().get_Item(0)`‑ként érhető el. Tartsa szem előtt ezt a különbséget a tömb építésekor, hogy elkerülje az egyes eltérésekből adódó hibákat.

Hívja a túlterhelést a [Presentation.getFontsManager](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#getFontsManager--) metóduson keresztül. Ez csak a kiválasztott diák renderelése közben meghatározott helyettesítéseket adja vissza. Minden eredmény egy [FontSubstitutionInfo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fontsubstitutioninfo/) objektum, amely az eredeti és a helyettesített betűkészlet nevét tartalmazza. Az eredmény tükrözi az aktuális betűkészlet‑környezetet, a konfigurált tartalék szabályokat, a [IFontSubstRuleCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifontsubstrulecollection/) tárolt helyettesítési szabályokat, valamint a [külsőleg betöltött betűkészleteket](/slides/hu/java/custom-font/).

Ugyanaz a helyettesítés több kiválasztott dia esetén is szükséges lehet. Távolítsa el a duplikátumokat az eredményekből, amikor betűkészlet‑leltárt vagy előzetes ellenőrzési jelentést készít. Az alábbi példa minden visszaadott helyettesítést jelent, majd egy rendezett listát hoz létre az egyedi betűkészlet‑leképezésekről:

```java
import com.aspose.slides.FontSubstitutionInfo;
import com.aspose.slides.Presentation;
import java.util.ArrayList;
import java.util.List;
import java.util.Set;
import java.util.TreeSet;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    int[] selectedSlides = { 1, 3, 5 };
    List<FontSubstitutionInfo> substitutions = new ArrayList<>();
    for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions(selectedSlides)) {
        substitutions.add(substitution);
    }

    System.out.println("Substitutions for the selected slides:");
    for (FontSubstitutionInfo substitution : substitutions) {
        System.out.println(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }

    Set<String> sortedPreflightEntries = new TreeSet<>(String.CASE_INSENSITIVE_ORDER);
    for (FontSubstitutionInfo substitution : substitutions) {
        String entry = substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName();
        sortedPreflightEntries.add(entry);
    }

    System.out.println("Deduplicated font preflight report:");
    for (String entry : sortedPreflightEntries) {
        System.out.println(entry);
    }
} finally {
    presentation.dispose();
}
```

Az [IFontsManager](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifontsmanager/) interfész mindkét túlterhelést biztosítja. Válasszon egyet a renderelési művelet hatókörének megfelelően:

| Túlterhelés | Használja, ha |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) with no arguments | Az egész prezentációhoz szükséges helyettesítések. |
| [getSubstitutions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) with `int[] slides` | Kiválasztott tartományhoz, fokozatos ellenőrzéshez vagy részleges exporthoz szükséges helyettesítések. |

## **Betűkészlethelyettesítési szabályok beállítása**

Az Aspose.Slides által használandó betűkészlet megadásához, ha a forrás betűkészlet nem érhető el:

1. Töltse be a prezentációt.
2. Hozzon létre betűkészletdefiníciókat a forrás és a helyettesítő betűkészletekhez.
3. Hozzon létre egy [FontSubstRule](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fontsubstrule/) objektumot a [WhenInaccessible](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fontsubstcondition/) feltétellel.
4. Adja hozzá a szabályt egy [FontSubstRuleCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fontsubstrulecollection/) gyűjteményhez.
5. Rendelje hozzá a gyűjteményt a [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-) metódus használatával.
6. Renderelje vagy konvertálja a prezentációt.

Az alábbi Java példa a `SomeRareFont` helyett az `Arial` betűkészletet használja, ha a `SomeRareFont` nem érhető el, majd rendereli az első diát az eredmény ellenőrzéséhez. A helyettesítő betűkészletnek elérhetőnek kell lennie az Aspose.Slides számára.

```java
import com.aspose.slides.FontData;
import com.aspose.slides.FontSubstCondition;
import com.aspose.slides.FontSubstRule;
import com.aspose.slides.FontSubstRuleCollection;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontSubstRule;
import com.aspose.slides.IFontSubstRuleCollection;
import com.aspose.slides.IImage;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontData sourceFont = new FontData("SomeRareFont");
    IFontData substituteFont = new FontData("Arial");
    IFontSubstRule substitutionRule = new FontSubstRule(sourceFont, substituteFont, FontSubstCondition.WhenInaccessible);

    IFontSubstRuleCollection substitutionRules = new FontSubstRuleCollection();
    substitutionRules.add(substitutionRule);
    presentation.getFontsManager().setFontSubstRuleList(substitutionRules);

    IImage image = presentation.getSlides().get_Item(0).getImage(1f, 1f);
    try {
        image.save("slide.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Megjegyzés" %}}
A teljes prezentációban használt betűkészletek feltétel nélküli megváltoztatásához tekintse meg a [Font Replacement](/slides/hu/java/font-replacement/) oldalt.
{{% /alert %}}

## **Korlátozások a matematikai egyenlet betűkészleteihez**

A betűkészlethelyettesítési szabályok a renderelés és konvertálás során használt szabványos betűkészlet‑kiválasztási folyamat részei. Rendszeres szövegnél működnek, amikor az Aspose.Slides egy nem elérhető betűkészletet helyettesíthet a szabály által megadott elérhető betűkészlettel.

Az Office Math egyenleteknek további követelményük van. Ha egy egyenlet a **Cambria Math** betűkészletet használja, az Aspose.Slidesnek pontosan ezt a betűkészletet kell rendelkezésre állnia az egyenlet elrendezésének kiszámításához és rendereléséhez. Egy másik matematikai betűkészletet, például a **STIX Two Math**‑ot helyettesítő szabály nem képes felváltani a **Cambria Math**‑ot ebben a célban, és a renderelés továbbra is azt jelezheti, hogy a **Cambria Math** szükséges.

Az ilyen prezentáció rendereléséhez vagy konvertálásához tegye a **Cambria Math** betűkészletet elérhetővé az Aspose.Slides számára. Telepítse a operációs rendszerben, vagy töltse be [külső betűkészlet](/slides/hu/java/custom-font/)ként.

Ez a korlátozás az egyenletelrendezésre vonatkozik. A fent leírt helyettesítési szabályok továbbra is érvényesek a prezentáció rendszeres szövegére.

## **GYIK**

**Mi a különbség a betűkészletcsere és a betűkészlethelyettesítés között?**

[Font replacement](/slides/hu/java/font-replacement/) szándékosan egy betűkészletet egy másikra cserél a teljes prezentációban. A betűkészlethelyettesítés a renderelt kimenethez választ betűkészletet, amikor a konfigurált feltétel teljesül, például amikor az eredeti betűkészlet nem érhető el.

**Mikor alkalmazzák a helyettesítési szabályokat?**

A szabályok a renderelés és konvertálás során a [betűkészlet‑kiválasztási sorozat](/slides/hu/java/font-selection-sequence/) részeként működnek. A `WhenInaccessible` esetén a szabály csak akkor kerül alkalmazásra, amikor az Aspose.Slides nem tudja elérni a forrás betűkészletet.

**Mi történik, ha egy betűkészlet hiányzik és nincs beállítva helyettesítési szabály?**

Az Aspose.Slides a legközelebbi elérhető betűkészletet választja a betűkészlet‑kiválasztási folyamata alapján. Az eredmény a futásidő környezetben elérhető betűkészletektől függ.

**Betölthetek külső betűkészleteket a helyettesítés elkerülésére?**

Igen. [Külső betűkészleteket](/slides/hu/java/custom-font/) tölthet be, hogy az Aspose.Slides azok felhasználhassa a renderelés és konvertálás során.

**Az Aspose a betűkészleteket a könyvtárral együtt terjeszti?**

Nem. Ön felel a betűkészletek biztosításáért és a licencfeltételek betartásáért.

**A helyettesítési eredmények különbözhetnek Windows, Linux és macOS között?**

Igen. Az operációs rendszer szerint változnak a telepített betűkészletek és a betűkészlet‑keresési helyek, így egy gépen elérhető betűkészlet egy másikon helyettesítést igényelhet.

**Hogyan tehetem a betűkészlet‑kiválasztást konzisztenssé kötegelt konverziók során?**

Használja ugyanazokat a betűkészlet‑fájlokat és verziókat minden gépen vagy konténerben, [töltse be a szükséges külső betűkészleteket](/slides/hu/java/custom-font/), és [ágyazza be a betűkészleteket](/slides/hu/java/embedded-font/) ha a licenc megengedi. Emellett meghívhatja a [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) metódust exportálás előtt, hogy azonosítsa a váratlan helyettesítéseket.