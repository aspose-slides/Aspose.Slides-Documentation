---
title: Betűtípus helyettesítés beállítása prezentációkban Java használatával
linktitle: Betűtípus helyettesítés
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
- csereszabály
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Állítson be betűtípus helyettesítési szabályokat, és ellenőrizze a helyettesített betűtípusokat az Aspose.Slides for Java-ban a PowerPoint és OpenDocument prezentációk renderelése vagy konvertálása során."
---
## **Áttekintés**

A betűtípus helyettesítés lehetővé teszi az Aspose.Slides számára, hogy elérhető betűtípust használjon egy nem elérhető betűtípus helyett, amikor egy prezentációt renderelnek vagy konvertálnak. A helyettesítés a renderelt kimenetet érinti; nem módosítja a prezentáció tartalmához rendelt betűtípust.

Megadhatja, mely betűtípust használja, amikor egy adott betűtípus nem érhető el, és megtekintheti a helyettesítéseket, amelyeket az Aspose.Slides a renderelés során végez. Ez segít a kimenet konzisztens megtartásában a különböző telepített betűtípusokkal rendelkező környezetek között.

Ha egy betűtípus elérhető, de nincs dedikált félkövér változata, lásd [Handle Fonts Without a Dedicated Bold Typeface](/slides/hu/java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Ez a szakasz elmagyarázza, hogyan lehet rasterizálni az érintett szöveget a PDF exportálása során, valamint a szövegkijelölésre, keresésre és méretezésre gyakorolt következményeket.

## **Betűtípus helyettesítések lekérése**

A [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) metódust használhatja annak meghatározására, hogy mely betűtípusok lesznek helyettesítve a prezentáció renderelésekor. A metódus [FontSubstitutionInfo](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstitutioninfo/) objektumokat ad vissza, amelyek az eredeti és a helyettesített betűtípusneveket azonosítják.

Az alábbi Java példa felsorolja a prezentáció összes betűtípus helyettesítését:

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

## **Kiválasztott diák betűtípus helyettesítéseinek lekérése**

Használja a [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) metódus túlterhelését `int[] slides` argumentummal, hogy csak a konkrét diák rendereléséhez szükséges helyettesítéseket tekintse meg. Ez hasznos, ha egy prezentáció egy részét rendereli vagy exportálja, egy nagy prezentációt fokozatosan ellenőriz, olyan diákot keres, amelyek nem elérhető betűtípusokra támaszkodnak, minimális betűtípuscsomagot készít szerver vagy konténer számára, vagy a renderelési különbségeket diagnosztizálja anélkül, hogy a nem releváns diákokat feldolgozná.

`slides` tömb egy‑alapú diák indexeket tartalmaz: `1` az első diát jelöli. Ezzel szemben a [Presentation.getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) gyűjteményelérő nulla‑alapú indexelést használ, így ugyanaz a dia `presentation.getSlides().get_Item(0)`‑ként érhető el. Ezt a különbséget tartsa szem előtt a tömb építésekor, hogy elkerülje az egy‑off hibákat.

Hívja meg a túlterhelést a [Presentation.getFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getFontsManager--) metóduson keresztül. Ez csak azokat a helyettesítéseket adja vissza, amelyek a kiválasztott diák renderelése közben lettek meghatározva. Minden eredmény egy [FontSubstitutionInfo](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstitutioninfo/) objektum, amely az eredeti és a helyettesített betűtípus nevet tartalmazza. Az eredmény tükrözi a jelenlegi betűtípus környezetet, a konfigurált visszalépési szabályokat és a [külsőleg betöltött betűtípusokat](/slides/hu/java/custom-font/). Az [IFontSubstRuleCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsubstrulecollection/)‑ben tárolt helyettesítési szabályok a prezentáció renderelésekor kerülnek alkalmazásra, de az eredmény nem sorolja fel őket; ellenőrizze a betűtípusokat a kimeneti fájlban.

Ugyanaz a helyettesítés több mint egy kiválasztott dián is szükséges lehet. Távolítsa el a duplikátumokat, amikor betűtípus leltárt vagy előellenőrző jelentést készít. Az alábbi példa minden visszaadott helyettesítést jelent, majd egy rendezett listát hoz létre az egyedi betűtípus leképezésekről:

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

Az [IFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/) interfész mindkét túlterhelést biztosítja. Válasszon a renderelési művelet köréhez illeszkedőt:

| Túlterhelés | Mikor használja |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) with no arguments | Amikor a teljes prezentációhoz szükséges helyettesítéseket szeretné. |
| [getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) with `int[] slides` | Amikor egy kiválasztott tartományhoz, fokozatos ellenőrzéshez vagy részleges exportáláshoz szükséges helyettesítéseket akarja. |

## **Betűtípus helyettesítési szabályok beállítása**

A forrásbetűtípus nem elérhető esetén megadható, mely betűtípust használja az Aspose.Slides:

1. Töltse be a prezentációt.
2. Hozzon létre betűtípusdefiníciókat a forrás- és helyettesítő betűtípusokhoz.
3. Hozzon létre egy [FontSubstRule](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstrule/) elemet a [WhenInaccessible](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstcondition/) feltétellel.
4. Hozza hozzá a szabályt egy [FontSubstRuleCollection](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstrulecollection/) gyűjteményhez.
5. Rendelje hozzá a gyűjteményt a [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-) metódussal.
6. Renderelje vagy konvertálja a prezentációt.

Az alábbi Java példa `Arial` betűtípust helyettesíti a `SomeRareFont`-nal, amikor a `SomeRareFont` nem érhető el, majd a első diát rendereli, hogy ellenőrizze az eredményt. A helyettesítő betűtípusnak elérhetőnek kell lennie az Aspose.Slides számára.

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
Feltétel nélküli változtatáshoz a teljes prezentációban használt betűtípusokra, lásd [Font Replacement](/slides/hu/java/font-replacement/).
{{% /alert %}}

## **Matematikai egyenlet betűtípusok korlátozásai**

A betűtípus helyettesítési szabályok a renderelés és konvertálás során használt szabványos betűtípus kiválasztási folyamat részét képezik. Rendszeres szövegeknél működnek, amikor az Aspose.Slides egy nem elérhető betűtípust a szabályban megadott elérhető betűtípussal helyettesíthet.

Az Office Math egyenletek további követelményt támasztanak. Ha egy egyenlet **Cambria Math** betűtípust használ, az Aspose.Slidesnek pontosan ezt a betűtípust kell rendelkezésére állnia az egyenlet elrendezésének kiszámításához és rendereléséhez. Egy olyan szabály, amely egy másik matematikai betűtípust, például **STIX Two Math**, helyettesíti, nem tudja helyettesíteni a **Cambria Math**‑ot ebben a célban, és a renderelés továbbra is jelentheti, hogy **Cambria Math** szükséges.

Az ilyen prezentáció rendereléséhez vagy konvertálásához tegye a **Cambria Math** betűtípust elérhetővé az Aspose.Slides számára. Telepítse azt az operációs rendszerben, vagy töltse be egy [external font](/slides/hu/java/custom-font/)‑ként.

Ez a korlátozás az egyenletelrendezésre vonatkozik. A fent leírt helyettesítési szabályok továbbra is érvényesek a prezentáció normál szövegére.

## **GYIK**

**Mi a különbség a betűtípus cseréje és a betűtípus helyettesítése között?**

[Font replacement](/slides/hu/java/font-replacement/) szándékosan megváltoztat egy betűtípust egy másikra a teljes prezentációban. A betűtípus helyettesítés a renderelt kimenethez választ betűtípust, amikor a konfigurált feltétel teljesül, például amikor az eredeti betűtípus nem elérhető.

**Mikor alkalmazzák a helyettesítési szabályokat?**

A szabályok részt vesznek a [font selection sequence](/slides/hu/java/font-selection-sequence/) folyamatában renderelés és konvertálás során. A `WhenInaccessible` esetén a szabály csak akkor használatos, amikor az Aspose.Slides nem fér hozzá a forrásbetűtípushoz.

**Mi történik, ha egy betűtípus hiányzik és nincs beállítva helyettesítési szabály?**

Az Aspose.Slides a legközelebbi elérhető betűtípust választja a betűtípus kiválasztási folyamata szerint. Az eredmény a futási környezetben rendelkezésre álló betűtípusoktól függ.

**Betölthetek külső betűtípusokat a helyettesítés elkerülésére?**

Igen. [Betöltheti a külső betűtípusokat](/slides/hu/java/custom-font/), hogy az Aspose.Slides használhassa őket renderelés és konvertálás során.

**Az Aspose a betűtípusokat a könyvtárral együtt terjeszti?**

Nem. Ön felelős a betűtípusok biztosításáért és azok licencfeltételeinek betartásáért.

**Eltérhetnek a helyettesítési eredmények Windows, Linux és macOS között?**

Igen. A telepített betűtípusok és a betűtípus keresési helyek operációs rendszerenként eltérnek, így egy gépen elérhető betűtípus egy másikon helyettesítést igényelhet.

**Hogyan tehetem a betűtípus kiválasztást konzisztenssé kötegelt konverziók során?**

Használjon ugyanazokat a betűtípusfájlokat és verziókat minden gépen vagy konténerben, [töltse be a szükséges külső betűtípusokat](/slides/hu/java/custom-font/), és [ágyazza be a betűtípusokat](/slides/hu/java/embedded-font/), ha a licenc engedi. A [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) meghívásával exportálás előtt azonosíthatja a váratlan helyettesítéseket.