---
title: Betűtípus-helyettesítés beállítása a prezentációkban Androidon
linktitle: Betűtípus-helyettesítés
type: docs
weight: 70
url: /hu/androidjava/font-substitution/
keywords:
- betűtípus
- helyettesítő betűtípus
- betűtípus-helyettesítés
- betűtípus cseréje
- betűtípus csere
- helyettesítési szabály
- csereszabály
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Állítsa be a betűtípus-helyettesítési szabályokat, és vizsgálja meg a helyettesített betűtípusokat az Aspose.Slides for Androidban Java segítségével a prezentációk renderelése vagy konvertálása során."
---
## **Áttekintés**

A betűtípus-helyettesítés lehetővé teszi az Aspose.Slides számára, hogy egy elérhető betűtípust használjon egy nem hozzáférhető betűtípus helyett, amikor egy prezentációt renderelnek vagy konvertálnak. A helyettesítés a renderelt kimenetet érinti; nem módosítja a prezentáció tartalmához rendelt betűtípust.

Megadhatja a használandó betűtípust, ha egy adott betűtípus nem érhető el, és megtekintheti az Aspose.Slides által a renderelés során végrehajtott helyettesítéseket. Ez segít a kimenetet következetesen tartani az Android eszközök és a különböző elérhető betűtípusokkal rendelkező környezetek között.

## **Betűtípus-helyettesítések lekérése**

Használja az [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) metódust annak meghatározásához, hogy mely betűtípusok lesznek helyettesítve a prezentáció renderelésekor. A metódus [FontSubstitutionInfo](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fontsubstitutioninfo/) objektumokat ad vissza, amelyek az eredeti és a helyettesített betűtípusok neveit azonosítják.

Az alábbi Java példa felsorolja a prezentáció összes betűtípus-helyettesítését:

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

## **Kijelölt diák betűtípus-helyettesítéseinek lekérése**

Használja az [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) túlterhelést egy `int[] slides` argumentummal, hogy csak a konkrét diák rendereléséhez szükséges helyettesítéseket vizsgálja. Ez akkor hasznos, amikor a prezentáció egy részét rendereli vagy exportálja, fokozatosan ellenőrzi egy nagy prezentációt, olyan diákot keres, amelyek nem elérhető betűtípusoktól függenek, egy Android alkalmazáshoz minimális betűtípus-csomagot készít, vagy a renderelési különbségeket diagnosztizálja anélkül, hogy a nem releváns diákra feldolgozást végezne.

`slides` tömb egy alapú diák indexeket tartalmaz: `1` az első diát jelöli. Ezzel szemben a [Presentation.getSlides](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#getSlides--) gyűjtemény hozzáférő nulla-alapú indexelést használ, így ugyanaz a dia `presentation.getSlides().get_Item(0)`-ként érhető el. Tartsa ezt a különbséget szem előtt a tömb építésekor, hogy elkerülje az egyes eltolódásokat.

Hívja meg a túlterhelést a [Presentation.getFontsManager](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#getFontsManager--) metóduson keresztül. Ez csak a kiválasztott diák renderelése során meghatározott helyettesítéseket adja vissza. Minden eredmény egy [FontSubstitutionInfo](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fontsubstitutioninfo/) objektum, amely tartalmazza az eredeti és a helyettesített betűtípus nevét. Az eredmény tükrözi a jelenlegi betűtípus-környezetet, a konfigurált tartalék szabályokat, az [IFontSubstRuleCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ifontsubstrulecollection/) tárolt helyettesítési szabályokat, valamint a [külsőleg betöltött betűtípusokat](/slides/hu/androidjava/custom-font/).

Ugyanaz a helyettesítés több, mint egy kiválasztott dián is szükséges lehet. Szűrje le a duplikált eredményeket, amikor betűtípus-inventárt vagy előellenőrzési jelentést készít. Az alábbi példa minden visszaadott helyettesítést jelent, majd létrehozza a egyedi betűtípus leképezések rendezett listáját:

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

Az [IFontsManager](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ifontsmanager/) interfész mindkét túlterhelést biztosítja. Válasszon egyet a renderelési művelet hatóköre szerint:

| Túlterhelés | Mikor használja |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) argumentumok nélkül | Ha a teljes prezentáció helyettesítéseire van szükség. |
| [getSubstitutions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) `int[] slides` argumentummal | Ha egy kijelölt tartomány, fokozatos ellenőrzés vagy részleges export helyettesítéseire van szükség. |

## **Betűtípus-helyettesítési szabályok beállítása**

A betűtípus megadásához, amelyet az Aspose.Slides használjon, ha a forrás betűtípus nem érhető el:

1. Töltse be a prezentációt.  
2. Hozzon létre betűtípus-definíciókat a forrás és helyettesítő betűtípusokhoz.  
3. Hozzon létre egy [FontSubstRule](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fontsubstrule/) elemet a [WhenInaccessible](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fontsubstcondition/) feltétellel.  
4. Adja hozzá a szabályt egy [FontSubstRuleCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fontsubstrulecollection/) gyűjteményhez.  
5. A gyűjteményt rendelje hozzá a [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-) metódussal.  
6. Renderelje vagy konvertálja a prezentációt.

Az alábbi Java példa a `Arial` betűtípust helyettesíti a `SomeRareFont` helyett, amikor a `SomeRareFont` nem érhető el, majd rendereli az első diát a végeredmény ellenőrzéséhez. A helyettesítő betűtípusnak elérhetőnek kell lennie az Aspose.Slides számára.

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
Az egész prezentációban használt betűtípusok feltétel nélküli módosításához lásd a [Font Replacement](/slides/hu/androidjava/font-replacement/) oldalt.
{{% /alert %}}

## **Korlátozások a matematikai egyenlet betűtípusokra**

A betűtípus‑helyettesítési szabályok a renderelés és konverzió során használt szabványos betűtípus‑kiválasztási folyamat részei. Rendszeres szövegnél akkor működnek, ha az Aspose.Slides egy nem elérhető betűtípust a szabály által meghatározott elérhető betűtípussal tud helyettesíteni.

Az Office Math egyenleteknek további követelményük van. Ha egy egyenlet **Cambria Math** betűtípust használ, az Aspose.Slidesnek pontosan ezt a betűtípust kell rendelkezésre állnia az egyenlet elrendezésének kiszámításához és rendereléséhez. Egy olyan szabály, amely egy másik matematikai betűtípust, például a **STIX Two Math**‑ot helyettesíti, nem helyettesítheti a **Cambria Math**‑ot ebben a célban, és a renderelés továbbra is jelezheti, hogy **Cambria Math** szükséges.

Az ilyen prezentáció rendereléséhez vagy konvertálásához tegye a **Cambria Math** betűtípust elérhetővé az Aspose.Slides számára. Töltse be külső betűtípusként ([external font](/slides/hu/androidjava/custom-font/)), hogy az alkalmazás a renderelés és konverzió során használhassa.

Ez a korlátozás az egyenletelrendezésre vonatkozik. A fent leírt helyettesítési szabályok továbbra is érvényesek a prezentáció szokásos szövegére.

## **GYIK**

**Mi a különbség a betűtípus-csere és a betűtípus-helyettesítés között?**  
A [Font replacement](/slides/hu/androidjava/font-replacement/) szándékosan megváltoztat egy betűtípust egy másikra a teljes prezentációban. A betűtípus-helyettesítés egy betűtípust választ a renderelt kimenethez, amikor a konfigurált feltétel teljesül, például ha az eredeti betűtípus nem érhető el.

**Mikor kerülnek alkalmazásra a helyettesítési szabályok?**  
A szabályok a [font selection sequence](/slides/hu/androidjava/font-selection-sequence/) részeként vesznek részt a renderelés és konverzió során. A `WhenInaccessible` esetén a szabály csak akkor használatos, amikor az Aspose.Slides nem tud hozzáférni a forrás betűtípushoz.

**Mi történik, ha egy betűtípus hiányzik és nincs beállítva helyettesítési szabály?**  
Az Aspose.Slides a legközelebbi elérhető betűtípust választja ki a betűtípus‑kiválasztási folyamata szerint. Az eredmény a futási környezetben elérhető betűtípusoktól függ.

**Betölthetek külső betűtípusokat a helyettesítés elkerüléséhez?**  
Igen. [Külső betűtípusok](/slides/hu/androidjava/custom-font/) betöltésével az Aspose.Slides használhatja azokat a renderelés és konverzió során.

**Az Aspose terjeszt‑e betűtípusokat a könyvtárral?**  
Nem. Ön felelős a betűtípusok biztosításáért és azok licencfeltételeinek betartásáért.

**Eltérhetnek a helyettesítési eredmények az Android eszközök között?**  
Igen. Az elérhető rendszerbetűtípusok különbözhetnek Android verziók, eszközök és gyártók között, ezért egy környezetben elérhető betűtípus egy másikban helyettesítést igényelhet.

**Hogyan tehetem következetessé a betűtípus kiválasztását Android eszközök között?**  
Csomagolja ugyanazokat a szükséges betűtípus‑fájlokat az alkalmazásba, [töltse be őket külső betűtípusként](/slides/hu/androidjava/custom-font/), és [ágyazza be a betűtípusokat](/slides/hu/androidjava/embedded-font/) a licenc engedélyezése esetén. Emellett az exportálás előtt meghívhatja az [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) metódust, hogy azonosítsa a váratlan helyettesítéseket.