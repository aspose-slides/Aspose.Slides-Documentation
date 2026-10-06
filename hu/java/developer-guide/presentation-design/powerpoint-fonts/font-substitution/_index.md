---
title: Java használatával a prezentációk betűtípus‑helyettesítésének konfigurálása
linktitle: Betűtípus‑helyettesítés
type: docs
weight: 70
url: /hu/java/font-substitution/
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
- Java
- Aspose.Slides
description: "Betűtípus‑helyettesítési szabályok konfigurálása és a helyettesített betűtípusok ellenőrzése az Aspose.Slides for Java-ban PowerPoint és OpenDocument prezentációk renderelése vagy konvertálása során."
---
## **Áttekintés**

A betűtípus‑helyettesítés lehetővé teszi, hogy az Aspose.Slides egy elérhető betűtípust használjon egy nem hozzáférhető betűtípus helyett, amikor egy prezentációt renderelnek vagy konvertálnak. A helyettesítés a renderelt kimenetet érinti; nem változtatja meg a prezentáció tartalmához rendelt betűtípust.

Meghatározhatja a használni kívánt betűtípust, amikor egy adott betűtípus nem érhető el, és ellenőrizheti a helyettesítéseket, amelyeket az Aspose.Slides a renderelés során végrehajt. Ez segít a kimenet konzisztensségének megőrzésében különböző telepített betűtípusokkal rendelkező környezetek között.

## **Betűtípus‑helyettesítések lekérése**

Használja a [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) metódust annak meghatározásához, hogy mely betűtípusok lesznek helyettesítve a prezentáció renderelésekor. A metódus [FontSubstitutionInfo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fontsubstitutioninfo/) objektumokat ad vissza, amelyek az eredeti és a helyettesített betűtípusneveket tartalmazzák.

A következő Java példa felsorolja a prezentáció összes betűtípus‑helyettesítését:

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

## **Betűtípus‑helyettesítések lekérése kiválasztott diákhoz**

Használja a [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) túlterhelést `int[] slides` argumentummal, hogy csak a kiválasztott diák rendereléséhez szükséges helyettesítéseket ellenőrizze. Ez hasznos, amikor a prezentáció egy részét rendereli vagy exportálja, nagy prezentációt ellenőriz fokozatosan, a nem elérhető betűtípusoktól függő diákat keresi, minimális betűtípuscsomagot készít szerver vagy konténer számára, vagy a renderelési különbségeket diagnosztizálja anélkül, hogy a nem releváns diák feldolgozásra kerülnek.

`slides` tömb egy‑bázisú (1‑től számított) diák indexeket tartalmaz: `1` az első diát jelöli. Ezzel szemben a [Presentation.getSlides](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#getSlides--) gyűjtemény‑hozzáférő nulla‑alapú indexelést használ, így ugyanaz a dia `presentation.getSlides().get_Item(0)`‑ként érhető el. Tartsa szem előtt ezt a különbséget a tömb létrehozásakor, hogy elkerülje az egy‑off‑by‑one hibákat.

Hívja meg a túlterhelést a [Presentation.getFontsManager](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#getFontsManager--) metóduson keresztül. Ez csak a kiválasztott diák renderelésekor meghatározott helyettesítéseket adja vissza. Minden eredmény egy [FontSubstitutionInfo](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fontsubstitutioninfo/) objektum, amely az eredeti és a helyettesített betűtípusneveket tartalmazza. Az eredmény tükrözi a jelenlegi betűtípus‑környezetet, a konfigurált fallback szabályokat és a [külső betöltött betűtípusokat](/slides/hu/java/custom-font/). Az [IFontSubstRuleCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifontsubstrulecollection/)‑ben tárolt helyettesítési szabályok a prezentáció renderelésekor vannak alkalmazva, de az eredmény nem listázza őket; ellenőrizze inkább a betűtípusokat a kimeneti fájlban.

Ugyanaz a helyettesítés több mint egy kiválasztott diát is érinthet. Szűrje le a duplikátumokat, amikor betűtípus‑leltárt vagy előellenőrző jelentést készít. A következő példa minden visszaadott helyettesítést jelent, majd létrehozik egy rendezett listát az egyedi betűtípus‑hozzárendelésekről:

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

Az [IFontsManager](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifontsmanager/) interfész mindkét túlterhelést biztosítja. Válassza ki a megfelelőt a renderelési művelet hatókörének megfelelően:

| Túlterhelés | Használja, ha |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) with no arguments | A teljes prezentációhoz szükséges helyettesítéseket szeretné. |
| [getSubstitutions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) with `int[] slides` | Kiválasztott tartományhoz, fokozatos ellenőrzéshez vagy részleges exporthoz szükséges helyettesítéseket szeretne. |

## **Betűtípus‑helyettesítési szabályok beállítása**

A megadáshoz, hogy mely betűtípust használja az Aspose.Slides, ha a forrás‑betűtípus nem érhető el:

1. Töltse be a prezentációt.
2. Hozzon létre betűtípus‑definíciókat a forrás‑ és helyettesítő betűtípusokhoz.
3. Hozzon létre egy [FontSubstRule](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fontsubstrule/) objektumot a [WhenInaccessible](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fontsubstcondition/) feltétellel.
4. Adja hozzá a szabályt egy [FontSubstRuleCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fontsubstrulecollection/) gyűjteményhez.
5. Rendelje hozzá a gyűjteményt a [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-) metódus használatával.
6. Renderelje vagy konvertálja a prezentációt.

A következő Java példa a `Arial` betűtípust helyettesíti a `SomeRareFont`-ra, amikor a `SomeRareFont` nem érhető el, majd rendereli az első diát a változat ellenőrzéséhez. A helyettesítő betűtípusnak elérhetőnek kell lennie az Aspose.Slides számára.

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

{{% alert color="info" title="Note" %}}
Az egész prezentációban használt betűtípusok feltétel nélküli módosításához tekintse meg a [Betűtípuscsere](/slides/hu/java/font-replacement/) oldalt.
{{% /alert %}}

## **Korlátozások a matematikai egyenlet betűtípusokra**

A betűtípus‑helyettesítési szabályok a renderelés és konvertálás során használt szabványos betűtípus‑kiválasztási folyamat részét képezik. Rendszeres szövegnél működnek, amikor az Aspose.Slides helyettesítheti a nem elérhető betűtípust a szabály által megadott elérhető betűtípussal.

Az Office Math egyenleteknek további követelményük van. Ha egy egyenlet a **Cambria Math** betűtípust használja, az Aspose.Slides számára szükség lehet arra a pontos betűtípusra az egyenlet elrendezésének kiszámításához és rendereléséhez. Egy olyan szabály, amely egy másik matematikai betűtípust, például a **STIX Two Math**‑ot helyettesíti, nem tudja felváltoztatni a **Cambria Math**‑ot erre a célra, és a renderelés továbbra is azt jelezheti, hogy a **Cambria Math** szükséges.

A fent említett prezentáció rendereléséhez vagy konvertálásához tegye a **Cambria Math** betűtípust elérhetővé az Aspose.Slides számára. Telepítse a operációs rendszerben vagy töltse be egy [külső betűtípusként](/slides/hu/java/custom-font/).

Ez a korlátozás az egyenlet elrendezésére vonatkozik. A fent leírt helyettesítési szabályok továbbra is érvényesek a prezentáció normál szövegére.

## **GYIK**

**Mi a különbség a betűtípuscsere és a betűtípus‑helyettesítés között?**

Az [Betűtípuscsere](/slides/hu/java/font-replacement/) szándékosan megváltoztat egy betűtípust egy másikra a teljes prezentációban. A betűtípus‑helyettesítés egy betűtípust választ a renderelt kimenethez, amikor a konfigurált feltétel teljesül, például amikor az eredeti betűtípus nem érhető el.

**Mikor kerülnek alkalmazásra a helyettesítési szabályok?**

A szabályok a [betűtípus‑kiválasztási sorozat](/slides/hu/java/font-selection-sequence/) részeként vesznek részt a renderelés és konvertálás során. A `WhenInaccessible` esetén a szabály csak akkor használatos, ha az Aspose.Slides nem tudja elérni a forrás‑betűtípust.

**Mi történik, ha egy betűtípus hiányzik, és nincs beállítva helyettesítési szabály?**

Az Aspose.Slides a legközelebbi elérhető betűtípust választja a betűtípus‑kiválasztási folyamat alapján. Az eredmény a futásidejű környezetben elérhető betűtípusoktól függ.

**Betölthetek külső betűtípusokat a helyettesítés elkerülésére?**

Igen. Betölthet [külső betűtípusokat](/slides/hu/java/custom-font/), így az Aspose.Slides használni tudja őket a renderelés és konvertálás során.

**Az Aspose terjeszti a betűtípusokat a könyvtárral együtt?**

Nem. A betűtípusok biztosítása és licencük betartása a felhasználó felelőssége.

**Eltérhetnek a helyettesítési eredmények Windows, Linux és macOS között?**

Igen. A telepített betűtípusok és a betűtípus‑keresési helyek operációs rendszerenként változnak, így egy gépen elérhető betűtípus egy másikon helyettesítést igényelhet.

**Hogyan tehetem konzisztenssé a betűtípus‑kiválasztást kötegelt konverziók során?**

Használja ugyanazokat a betűtípus‑fájlokat és verziókat minden gépen vagy konténeren, [töltse be a szükséges külső betűtípusokat](/slides/hu/java/custom-font/), és [ágyazza be a betűtípusokat](/slides/hu/java/embedded-font/), ha a licenc megengedi. Emellett a [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) meghívásával exportálás előtt azonosíthatja a váratlan helyettesítéseket.