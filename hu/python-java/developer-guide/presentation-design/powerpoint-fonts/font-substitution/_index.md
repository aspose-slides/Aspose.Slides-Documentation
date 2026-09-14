---
title: Betűtípus-helyettesítés konfigurálása bemutatókban Python segítségével Java-n keresztül
linktitle: Betűtípus helyettesítés
type: docs
weight: 70
url: /hu/python-java/font-substitution/
keywords:
- betűtípus
- helyettesítő betűtípus
- betűtípus helyettesítés
- betűtípus cseréje
- betűtípus csere
- helyettesítési szabály
- cserélési szabály
- PowerPoint
- OpenDocument
- bemutató
- Python
- Java
- Aspose.Slides
description: "Betűtípus-helyettesítési szabályok konfigurálása és a helyettesített betűtípusok ellenőrzése az Aspose.Slides Python verziójában Java-n keresztül a PowerPoint és OpenDocument bemutatók renderelése vagy konvertálása során."
---
## **Áttekintés**

A betűtípus-helyettesítés lehetővé teszi az Aspose.Slides számára, hogy egy elérhető betűtípust használjon egy nem hozzáférhető betűtípus helyett, amikor egy bemutatót renderelnek vagy konvertálnak. A helyettesítés a renderelt kimenetet érinti; nem módosítja a bemutató tartalmához rendelt betűtípust.

Megadhatja a használni kívánt betűtípust, ha egy adott betűtípus nem érhető el, és megtekintheti az Aspose.Slides által a renderelés során végrehajtott helyettesítéseket. Ez segít a kimenetet konzisztensnek tartani különböző, eltérő betűtípusokkal rendelkező környezetekben.

## **Betűtípus-helyettesítések lekérése**

Használja a [FontsManager.getSubstitutions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontsmanager/#getSubstitutions) módszert annak meghatározásához, mely betűtípusok lesznek helyettesítve a bemutató renderelésekor. A metódus [FontSubstitutionInfo](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontsubstitutioninfo/) objektumokat ad vissza, amelyek az eredeti és a helyettesített betűtípusok nevét azonosítják.

A következő Python példa felsorolja az összes betűtípus-helyettesítést egy bemutatóhoz:
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    for substitution in presentation.getFontsManager().getSubstitutions():
        print(f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}")
finally:
    presentation.dispose()
```

## **Kijelölt diák betűtípus-helyettesítéseinek lekérése**

Használja a [FontsManager.getSubstitutions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontsmanager/#getSubstitutions) túltöltést egy Java egész szám tömb argumentummal, hogy csak a konkrét diák rendereléséhez szükséges helyettesítéseket ellenőrizze. Ez akkor hasznos, amikor a bemutató egy részét rendereli vagy exportálja, nagy bemutatót fokozatosan ellenőriz, olyan diákot keres, amelyek nem elérhető betűtípusokra támaszkodnak, egy minimális betűtípuscsomagot készít szerverhez vagy konténerhez, vagy a renderelési különbségeket diagnosztizálja anélkül, hogy a nem releváns diák feldolgozásra kerülnének.

`slides` tömb egy‑alapú diaindexeket tartalmaz: `1` az első diát jelöli. Ezzel ellentétben a [Presentation.getSlides](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getSlides) gyűjttár‑hozzáférő null‑alapú indexelést használ, így ugyanaz a dia így érhető el: `presentation.getSlides().get_Item(0)`. Tartsa szem előtt ezt a különbséget a tömb építésekor, hogy elkerülje az egy‑off hibákat.

Hívja meg a túltöltést a [Presentation.getFontsManager](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getFontsManager) módszeren keresztül. Ez csak a kiválasztott diák renderelése során meghatározott helyettesítéseket adja vissza. Minden eredmény egy [FontSubstitutionInfo](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontsubstitutioninfo/) objektum, amely az eredeti és a helyettesített betűtípusok nevét tartalmazza. Az eredmény tükrözi a jelenlegi betűtípus‑környezetet, a beállított tartalék‑szabályokat, a [FontSubstRuleCollection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontsubstrulecollection/)‑ban tárolt helyettesítési szabályokat, valamint a [külsőleg betöltött betűtípusok](/slides/hu/python-java/custom-font/) betűtípusokat.

Ugyanaz a helyettesítés több mint egy kijelölt dián is szükséges lehet. Szűrje ki a duplikátumokat, amikor betűtípus‑készletet vagy előellenőrző jelentést készít. A következő példa minden visszaadott helyettesítést jelent, majd egy rendezett listát hoz létre az egyedi betűtípus leképezésekről:
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    selected_slides = jpype.JArray(jpype.JInt)([1, 3, 5])
    substitutions = list(presentation.getFontsManager().getSubstitutions(selected_slides))

    print("Substitutions for the selected slides:")
    for substitution in substitutions:
        print(f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}")

    unique_entries = {}
    for substitution in substitutions:
        entry = f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}"
        unique_entries.setdefault(entry.casefold(), entry)

    print("Deduplicated font preflight report:")
    for key in sorted(unique_entries):
        print(unique_entries[key])
finally:
    presentation.dispose()
```

A [FontsManager](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontsmanager/) osztály mindkét túltöltést biztosítja. Válasszon egyet a renderelési művelet hatóköre szerint:

| Túlterhelés | Használja amikor |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontsmanager/#getSubstitutions) with no arguments | A teljes bemutatóhoz szükséges helyettesítéseket szeretné. |
| [getSubstitutions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontsmanager/#getSubstitutions) with a Java integer array | Kijelölt tartományhoz, fokozatos ellenőrzéshez vagy részleges exportáláshoz szükséges helyettesítéseket szeretne. |

## **Betűtípus-helyettesítési szabályok beállítása**

A betűtípus megadásához, amelyet az Aspose.Slidesnek kell használnia, ha a forrás betűtípus nem érhető el:

1. Töltse be a bemutatót.
2. Hozzon létre betűtípus‑definíciókat a forrás- és helyettesítő betűtípusokhoz.
3. Hozzon létre egy [FontSubstRule](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontsubstrule/) szabályt a [WhenInaccessible](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontsubstcondition/#WhenInaccessible) feltétellel.
4. Adja hozzá a szabályt egy [FontSubstRuleCollection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontsubstrulecollection/) gyűjteményhez.
5. Rendelje hozzá a gyűjteményt a [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontsmanager/#setFontSubstRuleList) módszerrel.
6. Renderelje vagy konvertálja a bemutatót.

A következő Python példa a `SomeRareFont` nem elérhetősége esetén az `Arial` betűtípust helyettesíti, majd rendereli az első diát az eredmény ellenőrzéséhez. A helyettesítő betűtípust az Aspose.Slidesnek elérhetőnek kell lennie.
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, FontSubstCondition, FontSubstRule, FontSubstRuleCollection, ImageFormat, Presentation

presentation = Presentation("Fonts.pptx")
try:
    source_font = FontData("SomeRareFont")
    substitute_font = FontData("Arial")
    substitution_rule = FontSubstRule(source_font, substitute_font, FontSubstCondition.WhenInaccessible)

    substitution_rules = FontSubstRuleCollection()
    substitution_rules.add(substitution_rule)
    presentation.getFontsManager().setFontSubstRuleList(substitution_rules)

    image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        image.save("slide.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Megjegyzés" %}}
A bemutató során használt betűtípusok feltétlen módosításához lásd a [Betűtípus csere](/slides/hu/python-java/font-replacement/) oldalt.
{{% /alert %}}

## **Korlátozások a matematikai egyenlet betűtípusoknál**

A helyettesítési szabályok a renderelés és konverzió során használt szabványos betűtípus‑kiválasztási folyamat részei. Rendszeres szövegnél működnek, amikor az Aspose.Slides egy nem elérhető betűtípust a szabály által meghatározott elérhető betűtípussal helyettesíti.

Az Office Math egyenleteknek további követelményük van. Ha egy egyenlet **Cambria Math** betűtípust használ, az Aspose.Slidesnek pontosan ezt a betűtípust kell rendelkezésre állnia az egyenlet elrendezésének kiszámításához és rendereléséhez. Egy olyan szabály, amely egy másik matematikai betűtípust, például a **STIX Two Math**‑ot helyettesíti, nem tudja helyettesíteni a **Cambria Math**‑ot erre a célra, és a renderelés továbbra is jelezheti, hogy a **Cambria Math** szükséges.

Az ilyen bemutató rendereléséhez vagy konvertálásához tegye a **Cambria Math** betűtípust az Aspose.Slides számára elérhetővé. Telepítse azt az operációs rendszerben vagy töltse be egy [külső betűtípusként](/slides/hu/python-java/custom-font/) .

Ez a korlátozás az egyenletelrendezésre vonatkozik. A fent leírt helyettesítési szabályok továbbra is érvényesek a bemutató normál szövegére.

## **GYIK**

**Mi a különbség a betűtípus csere és a betűtípus helyettesítés között?**

[Betűtípus csere](/slides/hu/python-java/font-replacement/) szándékosan megváltoztat egy betűtípust egy másikra a teljes bemutatóban. A betűtípus‑helyettesítés egy betűtípust választ a renderelt kimenethez, amikor a beállított feltétel teljesül, például ha az eredeti betűtípus nem érhető el.

**Mikor alkalmazzák a helyettesítési szabályokat?**

A szabályok a renderelés és konverzió során a [betűtípus‑kiválasztási sorozat](/slides/hu/python-java/font-selection-sequence/) résztvevői. A `WhenInaccessible` esetén a szabály csak akkor használatos, ha az Aspose.Slides nem fér hozzá a forrás betűtípushoz.

**Mi történik, ha egy betűtípus hiányzik, és nincs beállítva helyettesítési szabály?**

Az Aspose.Slides a legközelebbi elérhető betűtípust választja a betűtípus‑kiválasztási folyamata szerint. Az eredmény a futási környezetben elérhető betűtípusoktól függ.

**Betölthetek külső betűtípusokat a helyettesítés elkerüléséhez?**

Igen. [Külső betűtípusok betöltése](/slides/hu/python-java/custom-font/) lehetővé teszi, hogy az Aspose.Slides használja őket a renderelés és konverzió során.

**Terjeszti-e az Aspose a betűtípusokat a könyvtárral együtt?**

Nem. Önnek kell biztosítania a betűtípusokat és betartania azok licencfeltételeit.

**Eltérhetnek-e a helyettesítési eredmények Windows, Linux és macOS között?**

Igen. A telepített betűtípusok és a betűtípus‑keresési helyek operációs rendszerenként eltérnek, így egy gépen elérhető betűtípus egy másik gépen helyettesítést igényelhet.

**Hogyan tehetem a betűtípus‑kiválasztást konzisztenssé kötegelt konverziók során?**

Használjon ugyanazokat a betűtípus‑fájlokat és verziókat minden gépen vagy konténeren, [töltse be a szükséges külső betűtípusokat](/slides/hu/python-java/custom-font/), és [betűtípusok beágyazása](/slides/hu/python-java/embedded-font/) amikor a licenc megengedi. Ezen felül meghívhatja a [FontsManager.getSubstitutions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontsmanager/#getSubstitutions) metódust exportálás előtt az előre nem várt helyettesítések azonosításához.