---
title: Betűtípus-helyettesítés beállítása prezentációkban Python használatával Java-n keresztül
linktitle: Betűtípus-helyettesítés
type: docs
weight: 70
url: /hu/python-java/font-substitution/
keywords:
- betűtípus
- helyettesítő betűtípus
- betűtípus-helyettesítés
- betűtípus cseréje
- betűtípus-csere
- helyettesítési szabály
- csereszabály
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Konfigurálja a betűtípus-helyettesítési szabályokat, és ellenőrizze a helyettesített betűtípusokat az Aspose.Slides for Python via Java-ben PowerPoint és OpenDocument prezentációk renderingja vagy konvertálása során."
---
## **Áttekintés**

A betűtípus‑helyettesítés lehetővé teszi, hogy az Aspose.Slides egy elérhető betűtípust használjon egy olyan betűtípus helyett, amelyet a prezentáció megjelenítése vagy konvertálása során nem lehet elérni. A helyettesítés a rendering eredményét érinti; nem módosítja a prezentáció tartalmához rendelt betűtípust.

Meghatározhatja, hogy mely betűtípust kell használni, ha egy adott betűtípus nem érhető el, és ellenőrizheti a Aspose.Slides által a rendering során alkalmazott helyettesítéseket. Ez segít egységes kimenetet biztosítani különböző környezetekben, ahol eltérő betűtípusok vannak telepítve.

Ha egy betűtípus elérhető, de nincs számára dedikált félkövér változat, tekintse meg a [Handle Fonts Without a Dedicated Bold Typeface](/slides/hu/python-java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface) című szakaszt. Ebben a szakaszban leírják, hogyan kell rasterizálni az érintett szöveget PDF‑exportáláskor, valamint az ennek szövegkijelölésre, keresésre és méretezésre gyakorolt hatásait.

## **Betűtípus‑helyettesítések lekérése**

Használja a [FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) metódust annak meghatározásához, mely betűtípusok lesznek helyettesítve a prezentáció rendering során. A metódus [FontSubstitutionInfo](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstitutioninfo/) objektumokat ad vissza, amelyek az eredeti és a helyettesített betűtípusneveket tartalmazzák.

Az alábbi Python‑példa felsorolja az összes betűtípus‑helyettesítést egy prezentációhoz:

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

## **Betűtípus‑helyettesítések lekérése a kiválasztott diákra**

Használja a [FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) túlterhelést Java‑egész számú tömb argumentummal, hogy csak a kiválasztott diák megjelenítéséhez szükséges helyettesítéseket ellenőrizze. Ez hasznos, ha a prezentáció egy részét rendereli vagy exportálja, fokozatosan ellenőrzi a nagy prezentációt, olyan diákokat keres, amelyek nem elérhető betűtípusokra támaszkodnak, vagy minimális betűtípus‑csomagot szeretne előkészíteni egy szerverhez vagy konténerhez, illetve a rendering‑különbségek diagnosztizálásához anélkül, hogy a nem releváns diákokat feldolgozná.

A `slides` tömb egy‑bázisú dia‑indexeket tartalmaz: a `1` az első diát jelöli. Ezzel szemben a [Presentation.getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides) gyűjteményelérő null‑bázisú indexelést használ, így ugyanaz a dia a `presentation.getSlides().get_Item(0)` kifejezéssel érhető el. Tartsa észben ezt a különbséget a tömb összeállításakor, hogy elkerülje az off‑by‑one hibákat.

Hívja a túlterhelést a [Presentation.getFontsManager](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getFontsManager) metóduson keresztül. Csak a kiválasztott diák renderelése közben meghatározott helyettesítéseket adja vissza. Minden eredmény egy [FontSubstitutionInfo](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstitutioninfo/) objektum, amely az eredeti és a helyettesített betűtípusneveket tartalmazza. Az eredmény tükrözi a jelenlegi betűtípus‑környezetet, a konfigurált visszaeső szabályokat, a [FontSubstRuleCollection](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrulecollection/)‑ben tárolt helyettesítési szabályokat és a [externally loaded fonts](/slides/hu/python-java/custom-font/) listáját.

Ugyanaz a helyettesítés több, mint egy kiválasztott diához is szükséges lehet. Szűrje le a duplikátumokat, amikor betűtípus‑leltárt vagy pre‑flight jelentést készít. Az alábbi példa minden visszaadott helyettesítést jelent, majd egy rendezett listát hoz létre az egyedi betűtípus‑leképezésekről:

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

A [FontsManager](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/) osztály mindkét túlterhelést biztosítja. Válassza a megfelelőt a rendering művelet hatókörétől függően:

| Metódus | Használja, ha |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) argumentumok nélkül | Az egész prezentációhoz szükséges helyettesítések. |
| [getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) Java‑egész számú tömbbel | Kiválasztott tartományhoz, fokozatos ellenőrzéshez vagy részleges exportáláshoz szükséges helyettesítések. |

## **Betűtípus‑helyettesítési szabályok beállítása**

Ahhoz, hogy meghatározza, mely betűtípust használja az Aspose.Slides egy forrás‑betűtípus hiánya esetén:

1. Töltse be a prezentációt.
2. Hozzon létre betűtípus‑definíciókat a forrás és a helyettesítő betűtípusokhoz.
3. Hozzon létre egy [FontSubstRule](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrule/) objektumot a [WhenInaccessible](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstcondition/#WhenInaccessible) feltétellel.
4. Adja hozzá a szabályt egy [FontSubstRuleCollection](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrulecollection/) gyűjteményhez.
5. Rendelje hozzá a gyűjteményt a [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#setFontSubstRuleList) metódussal.
6. Renderelje vagy konvertálja a prezentációt.

Az alábbi Python‑példa a `Arial`‑t helyettesíti a `SomeRareFont`‑nal, amikor a `SomeRareFont` nem elérhető, majd rendereli az első diát a végeredmény ellenőrzéséhez. A helyettesítő betűtípusnak elérhetőnek kell lennie az Aspose.Slides számára.

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

{{% alert color="info" title="Note" %}}
Az egész prezentációban használt betűtípusok feltétel nélküli módosításához lásd a [Font Replacement](/slides/hu/python-java/font-replacement/).
{{% /alert %}}

## **Matematikai egyenlet‑betűtípusok korlátozásai**

A betűtípus‑helyettesítési szabályok a rendering és konvertálás során használt standard betűtípus‑kiválasztási folyamat részei. Szokásos szövegre működnek, amikor az Aspose.Slides helyettesítheti a nem elérhető betűtípust a szabályban megadott elérhető betűtípussal.

Az Office Math egyenleteknek további követelményük van. Ha egy egyenlet **Cambria Math**‑ot használ, az Aspose.Slidesnek pontosan ezt a betűtípust kell rendelkezésre állnia az egyenlet elrendezésének kiszámításához és rendereléséhez. Egy másik matematikai betűtípust, például **STIX Two Math**‑ot helyettesítő szabály nem tudja felváltani a **Cambria Math**‑ot, ezért a rendering továbbra is jelezheti, hogy a **Cambria Math**‑ra van szükség.

Ilyen prezentáció rendereléséhez vagy konvertálásához tegye a **Cambria Math** betűtípust elérhetővé az Aspose.Slides számára. Telepítse a rendszerben, vagy töltse be egy [external font](/slides/hu/python-java/custom-font/)‑ként.

Ez a korlátozás az egyenlet‑elrendezésre vonatkozik. A fent leírt helyettesítési szabályok továbbra is érvényesek a szokásos prezentáció‑szövegre.

## **GYIK**

**Mi a különbség a betűtípus‑cseréhez és a betűtípus‑helyettesítéshez?**

[Font replacement](/slides/hu/python-java/font-replacement/) szándékosan megváltoztat egy betűtípust egy másikra a teljes prezentációban. A betűtípus‑helyettesítés pedig a renderelt kimenethez választ betűtípust, amikor a konfigurált feltétel teljesül, például ha az eredeti betűtípus nem elérhető.

**Mikor alkalmazzák a helyettesítési szabályokat?**

A szabályok részt vesznek a [font selection sequence](/slides/hu/python-java/font-selection-sequence/) folyamatában rendering és konvertálás közben. A `WhenInaccessible` szabály csak akkor kerül használatra, amikor az Aspose.Slides nem tudja elérni a forrás‑betűtípust.

**Mi történik, ha egy betűtípus hiányzik, és nincs konfigurálva helyettesítési szabály?**

Az Aspose.Slides a legközelebbi elérhető betűtípust választja a betűtípus‑kiválasztási folyamata alapján. Az eredmény a futásidejű környezetben elérhető betűtípusoktól függ.

**Betölthetek külső betűtípusokat a helyettesítés elkerüléséhez?**

Igen. Betöltheti a [external fonts](/slides/hu/python-java/custom-font/)‑t, hogy az Aspose.Slides használni tudja őket rendering és konvertálás közben.

**Az Aspose terjeszti a betűtípusokat a könyvtárral együtt?**

Nem. Ön felelős a betűtípusok biztosításáért és a licencfeltételek betartásáért.

**Eltérhetnek a helyettesítési eredmények Windows, Linux és macOS között?**

Igen. A telepített betűtípusok és a betűtípus‑keresési helyek operációs rendszerenként eltérnek, ezért egy gépen elérhető betűtípus egy másikon helyettesítést igényelhet.

**Hogyan tehetem a betűtípus‑kiválasztást konzisztenssé kötegelt konverziók során?**

Használja ugyanazokat a betűtáfileket és verziókat minden gépen vagy konténeren, [load required external fonts](/slides/hu/python-java/custom-font/), és [embed fonts](/slides/hu/python-java/embedded-font/) ha a licenc megengedi. Emellett hívhatja a [FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) metódust exportálás előtt, hogy azonosítsa a nem várt helyettesítéseket.