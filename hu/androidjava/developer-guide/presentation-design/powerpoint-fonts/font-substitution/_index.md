---
title: Betűtípuscsere konfigurálása Androidon lévő prezentációkban
linktitle: Betűtípuscsere
type: docs
weight: 70
url: /hu/androidjava/font-substitution/
keywords:
- betűtípus
- helyettesítő betűtípus
- betűtípuscsere
- betűtípus cseréje
- betűtípuscsere
- helyettesítési szabály
- csere szabály
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Állítsa be a betűtípuscsere szabályait, és ellenőrizze a helyettesített betűtípusokat az Aspose.Slides for Android-ban Java használatával a prezentációk renderelése vagy konvertálása során."
---
## **Áttekintés**

A betűtípuscsere lehetővé teszi, hogy az Aspose.Slides egy elérhető betűtípust használjon egy nem hozzáférhető betűtípus helyett, amikor a prezentációt renderelik vagy konvertálják. A csere a renderelt kimenetet érinti; nem változtatja meg a prezentáció tartalmához rendelt betűtípust.

Megadhatja a használni kívánt betűtípust, ha egy adott betűtípus nem érhető el, és megtekintheti az Aspose.Slides által a renderelés során alkalmazott helyettesítéseket. Ez segít a kimenetet konzisztens módon tartani különböző Android-eszközök és eltérő elérhető betűtípusok környezetében.

Ha a betűtípus elérhető, de nincs dedikált félkövér változata, tekintse meg a [A dedikált félkövér betűtípus nélküli betűtípusok kezelése](/slides/hu/androidjava/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface) szakaszt. Ez a szakasz elmagyarázza, hogyan lehet raszterizálni az érintett szöveget a PDF exportálása során, valamint a szövegkijelölésre, keresésre és méretezésre gyakorolt hatásokat.

## **Betűtípuscsere lekérése**

Használja a [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) metódust annak meghatározására, hogy mely betűtípusok lesznek helyettesítve a prezentáció renderelésekor. A metódus [FontSubstitutionInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstitutioninfo/) objektumokat ad vissza, amelyek az eredeti és helyettesített betűtípusneveket azonosítják.

A következő Java példa felsorolja a prezentáció összes betűtípuscsere beállítását:

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

## **Kiválasztott diák betűtípuscsere lekérése**

Használja a [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) túlterhelést `int[] slides` argumentummal, hogy csak a konkrét diák rendereléséhez szükséges helyettesítéseket vizsgálja. Ez akkor hasznos, ha a prezentáció egy részét rendereli vagy exportálja, egy nagy prezentációt inkrementálisan ellenőriz, olyan diákra szeretne rámutatni, amelyek nem elérhető betűtípusoktól függenek, egy minimális betűtípuscsomagot szeretne előkészíteni egy Android‑alkalmazáshoz, vagy a renderelési különbségeket anélkül diagnosztizálja, hogy a nem releváns diákokat feldolgozná.

A `slides` tömb egy‑alapú diákindexeket tartalmaz: a `1` az első diát jelöli. Ezzel szemben a [Presentation.getSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--) gyűjteményelérő nullálo‑alapú indexelést használ, így ugyanaz a dia a `presentation.getSlides().get_Item(0)` kifejezéssel érhető el. Tartsa szem előtt ezt a különbséget a tömb felépítésekor, hogy elkerülje a „+1” hibákat.

Hívja meg a túlterhelést a [Presentation.getFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getFontsManager--) metóduson keresztül. Ez csak a kiválasztott diák renderelése közben meghatározott helyettesítéseket adja vissza. Minden eredmény egy [FontSubstitutionInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstitutioninfo/) objektum, amely az eredeti és helyettesített betűtípusneveket tartalmazza. Az eredmény tükrözi az aktuális betűtípus‑környezetet, a beállított tartalék‑szabályokat, a [IFontSubstRuleCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsubstrulecollection/)‑ben tárolt helyettesítési szabályokat, valamint a [külső betűtípusok](/slides/hu/androidjava/custom-font/) betöltését.

Ugyanaz a helyettesítés több kiválasztott dián is szükséges lehet. Szűrje ki a duplikált elemeket, amikor betűtípus‑készletet vagy előellenőrző jelentést készít. A következő példa minden visszaadott helyettesítést jelent, majd egy rendezett listát hoz létre az egyedi betűtípusleképezésekről:

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

Az [IFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/) felület mindkét túlterhelést biztosítja. Válassza ki a renderelési művelet kiterjedése szerint:

| Túlterhelés | Használja, ha |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) with no arguments | A teljes prezentációhoz szüksége van helyettesítésekre. |
| [getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) with `int[] slides` | Kiválasztott tartományhoz, inkrementális ellenőrzéshez vagy részleges exportáláshoz szüksége van helyettesítésekre. |

## **Betűtípuscsere szabályok beállítása**

A forrás‑betűtípus nem elérhető esetén a következő lépésekkel adhatja meg, hogy az Aspose.Slides mely betűtípust használja:

1. Töltse be a prezentációt.  
2. Hozzon létre betűtípusdefiníciókat a forrás- és helyettesítő betűtípusokhoz.  
3. Hozzon létre egy [FontSubstRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstrule/) objektumot a [WhenInaccessible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstcondition/) feltétellel.  
4. Adja hozzá a szabályt egy [FontSubstRuleCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstrulecollection/) gyűjteményhez.  
5. Rendelje hozzá a gyűjteményt a [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-) metódus használatával.  
6. Renderelje vagy konvertálja a prezentációt.

A következő Java példa a `Arial` betűtípust helyettesíti a `SomeRareFont`‑nal, ha a `SomeRareFont` nem érhető el, majd rendereli az első diát az eredmény ellenőrzéséhez. A helyettesítő betűtípust az Aspose.Slides‑nek elérhetőnek kell lennie.

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
A prezentáció során használt betűtípusok feltétel nélküli megváltoztatásához tekintse meg a [Betűtípuscsere](/slides/hu/androidjava/font-replacement/) oldalt.
{{% /alert %}}

## **Matematikai egyenlet betűtípusok korlátai**

A betűtípushelyettesítési szabályok a renderelés és konverzió alatt használt szabványos betűtípus‑kiválasztási folyamat részei. Rendszeres szövegre akkor működnek, amikor az Aspose.Slides egy nem elérhető betűtípust kicserél a szabály által megadott elérhető betűtípusra.

Az Office Math egyenleteknek további követelményük van. Ha egy egyenlet **Cambria Math**‑ot használ, az Aspose.Slidesnek lehet, hogy pontosan ezt a betűtípust kell használnia az egyenlet elrendezésének kiszámításához és rendereléséhez. Egy másik matematikai betűtípust (például **STIX Two Math**) helyettesítő szabály nem cserélheti le **Cambria Math**‑ot erre a célra, és a renderelés továbbra is jelentheti, hogy **Cambria Math** szükséges.

Az ilyen prezentáció rendereléséhez vagy konvertálásához tegye **Cambria Math**‑ot elérhetővé az Aspose.Slides számára. Töltse be külső betűtípusként egy [external font](/slides/hu/androidjava/custom-font/)‑ként, hogy az alkalmazás használni tudja a renderelés és konverzió során.

Ez a korlátozás az egyenletelrendezésre vonatkozik. A fent leírt helyettesítési szabályok továbbra is érvényesek a szabályos prezentációs szövegre.

## **GYIK**

**Mi a különbség a betűtípuscsere és a betűtípus helyettesítés között?**

[Betűtípuscsere](/slides/hu/androidjava/font-replacement/) szándékosan megváltoztat egy betűtípust egy másikra a teljes prezentáció során. A betűtípus helyettesítés a renderelt kimenethez választ betűtípust, amikor a beállított feltétel teljesül, például ha az eredeti betűtípus nem érhető el.

**Mikor alkalmazzák a helyettesítési szabályokat?**

A szabályok részt vesznek a [betűtípus kiválasztási sorozat](/slides/hu/androidjava/font-selection-sequence/) során a renderelés és konverzió közben. A `WhenInaccessible` esetén a szabály csak akkor használatos, amikor az Aspose.Slides nem fér hozzá a forrás betűtípushoz.

**Mi történik, ha egy betűtípus hiányzik és nincs beállítva helyettesítési szabály?**

Az Aspose.Slides a legközelebbi elérhető betűtípust választja a betűtípus kiválasztási folyamata alapján. Az eredmény a futási környezetben elérhető betűtípusoktól függ.

**Betölthetek külső betűtípusokat a helyettesítés elkerüléséhez?**

Igen. Betöltheti a [külső betűtípusokat](/slides/hu/androidjava/custom-font/), hogy az Aspose.Slides használhassa őket a renderelés és konverzió során.

**Az Aspose a betűtípusokat a könyvtárral együtt terjeszti?**

Nem. Ön felelős a betűtípusok biztosításáért és a licencek betartásáért.

**Eltérhetnek a helyettesítési eredmények Android-eszközök között?**

Igen. Az elérhető rendszerbetűtípusok eltérhetnek Android‑verziók, eszközök és gyártók között, így egy környezetben elérhető betűtípus egy másikban helyettesítést igényelhet.

**Hogyan tehetem a betűtípus kiválasztását konzisztenssé Android-eszközök között?**

Csomagolja be a szükséges betűtípusfájlokat az alkalmazással, [töltse be őket külső betűtípusként](/slides/hu/androidjava/custom-font/), és [ágyazza be a betűtípusokat](/slides/hu/androidjava/embedded-font/) ha a licencek engedélyezik. Emellett hívhatja a [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) metódust exportálás előtt, hogy azonosítsa a váratlan helyettesítéseket.