---
title: Betűtípushelyettesítés konfigurálása bemutatókban Python nyelven
linktitle: Betűtípushelyettesítés
type: docs
weight: 70
url: /hu/python-net/font-substitution/
keywords:
- betűtípus
- helyettesítő betűtípus
- betűtípushelyettesítés
- betűtípus cseréje
- betűtípuscsere
- helyettesítési szabály
- csereszabály
- PowerPoint
- OpenDocument
- bemutató
- Python
- Aspose.Slides
description: "Állítsa be a betűtípushelyettesítési szabályokat, és ellenőrizze a helyettesített betűtípusokat az Aspose.Slides for Python .NET-en keresztül a PowerPoint és OpenDocument bemutatók renderelése vagy konvertálása során."
---
## **Áttekintés**

A betűtípushelyettesítés lehetővé teszi, hogy az Aspose.Slides egy elérhető betűtípust használjon egy nem elérhető betűtípus helyett, amikor a bemutatót rendereli vagy konvertálja. A helyettesítés a megjelenített kimenetet érinti; nem változtatja meg a bemutató tartalmához rendelt betűtípust.

Megadhatja, hogy melyik betűtípust használja, ha egy adott betűtípus nem érhető el, és megtekintheti az Aspose.Slides által a renderelés során végrehajtott helyettesítéseket. Ez segít a kimenet konzisztens megtartásában a különböző telepített betűtípusokkal rendelkező környezetek között.

Ha egy betűtípus elérhető, de nincs dedikált félkövér betűtípusa, lásd a [A dedikált félkövér betűtípusok kezelése](/slides/hu/python-net/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface) szakaszt. Az a rész leírja, hogyan kell raszterizálni az érintett szöveget a PDF exportálása során, valamint a szövegkijelölésre, keresésre és skálázásra gyakorolt hatásait.

## **Betűtípushelyettesítések lekérése**

A [FontsManager.get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) metódus használatával meghatározható, mely betűtípusok lesznek helyettesítve a bemutató renderelésekor. A metódus [FontSubstitutionInfo](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstitutioninfo/) objektumokat ad vissza, amelyek az eredeti és a helyettesített betűtípusneveket tartalmazzák.

Az alábbi Python példa felsorolja a bemutató összes betűtípushelyettesítését:

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    for substitution in presentation.fonts_manager.get_substitutions():
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")
```

## **Betűtípushelyettesítések lekérése a kiválasztott diákhoz**

A [FontsManager.get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) használatával, diák indexeinek listájával csak a konkrét diákhoz szükséges helyettesítéseket vizsgálhatja meg. Ez hasznos, ha a bemutató egy részét rendereli vagy exportálja, fokozatosan ellenőrzi a nagy bemutatót, olyan diákot keres, amelyek nem elérhető betűtípusoktól függenek, minimális betűtípuscsomagot készít a kiszolgáló vagy konténer számára, vagy a renderelési eltéréseket diagnosztizálja anélkül, hogy a nem releváns diák feldolgozásra kerülnének.

A lista egy alapú (1‑től kezdődő) diák indexeket tartalmaz: a `1` az első diát jelöli. Ezzel szemben a [Presentation.slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) gyűjtemény nullával kezdődik, így ugyanaz a dia `presentation.slides[0]`‑ként érhető el. Tartsa ezt a különbséget szem előtt a lista összeállításakor, hogy elkerülje az egy off‑by‑one hibákat.

A metódust a [Presentation.fonts_manager](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/fonts_manager/) tulajdonságon keresztül kell meghívni. Ez csak a kiválasztott diák renderelése során meghatározott helyettesítéseket adja vissza. Minden eredmény egy [FontSubstitutionInfo](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstitutioninfo/) objektum, amely az eredeti és a helyettesített betűtípusneveket tartalmazza. Az eredmény tükrözi az aktuális betűtípus‑környezetet, a konfigurált visszaeső (fallback) szabályokat, a [IFontSubstRuleCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ifontsubstrulecollection/)‑ben tárolt helyettesítési szabályokat, valamint a [külső betűtípust](/slides/hu/python-net/custom-font/) betűtípusokat.

Ugyanaz a helyettesítés több kiválasztott dián is szükséges lehet. Távolítsa el a duplikátumokat, amikor betűtípus‑inventár vagy előfeldolgozó jelentést készít. Az alábbi példa minden visszaadott helyettesítést jelent, majd létrehoz egy rendezett listát az egyedi betűtípusleképezésekről:

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    selected_slides = [1, 3, 5]
    substitutions = list(presentation.fonts_manager.get_substitutions(selected_slides))

    print("Substitutions for the selected slides:")
    for substitution in substitutions:
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")

    preflight_entries = [f"{substitution.original_font_name} -> {substitution.substituted_font_name}" for substitution in substitutions]
    unique_preflight_entries = {entry.casefold(): entry for entry in preflight_entries}
    sorted_preflight_entries = sorted(unique_preflight_entries.values(), key=str.casefold)

    print("Deduplicated font preflight report:")
    for entry in sorted_preflight_entries:
        print(entry)
```

A [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) osztály mindkét változatát biztosítja a metódusnak. Válasszon egyet a renderelési művelet hatókörének megfelelően:

| Metódushívás | Használja, ha |
|---|---|
| [get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) with no arguments | A teljes bemutatóhoz szükséges helyettesítéseket szeretne. |
| [get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) with a list of slide indexes | Kiválasztott tartomány, fokozatos ellenőrzés vagy részleges export esetén szükséges helyettesítéseket. |

## **Betűtípushelyettesítési szabályok beállítása**

Az Aspose.Slides által egy forrásbetűtípus hiányában használandó betűtípus megadásához:

1. Töltse be a bemutatót.
2. Hozzon létre betűtípus‑definíciókat a forrás‑ és helyettesítő betűtípusokhoz.
3. Hozzon létre egy [FontSubstRule](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstrule/) objektumot a [WHEN_INACCESSIBLE](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstcondition/) feltétellel.
4. Adja hozzá a szabályt egy [FontSubstRuleCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstrulecollection/) gyűjteményhez.
5. Rendelje hozzá a gyűjteményt a [FontsManager.font_subst_rule_list](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/font_subst_rule_list/) tulajdonsághoz.
6. Renderelje vagy konvertálja a bemutatót.

Az alábbi Python példa a `SomeRareFont` helyett az `Arial` betűtípust használja, ha a `SomeRareFont` nem érhető el, majd renderezi az első diát az eredmény ellenőrzéséhez. A helyettesítő betűtípusnak elérhetőnek kell lennie az Aspose.Slides számára.

```python
import aspose.slides as slides

with slides.Presentation("Fonts.pptx") as presentation:
    source_font = slides.FontData("SomeRareFont")
    substitute_font = slides.FontData("Arial")
    substitution_rule = slides.FontSubstRule(source_font, substitute_font, slides.FontSubstCondition.WHEN_INACCESSIBLE)

    substitution_rules = slides.FontSubstRuleCollection()
    substitution_rules.add(substitution_rule)
    presentation.fonts_manager.font_subst_rule_list = substitution_rules

    with presentation.slides[0].get_image(1, 1) as image:
        image.save("slide.jpg", slides.ImageFormat.JPEG)
```

{{% alert color="info" title="Note" %}}
Az egész bemutatóban a betűtípusok feltétel nélküli módosításához lásd a [Betűtípuscsere](/slides/hu/python-net/font-replacement/) szakaszt.
{{% /alert %}}

## **Korlátozások a matematikai egyenlet betűtípusokra vonatkozóan**

A betűtípushelyettesítési szabályok a renderelés és konvertálás során használt standard betűtípus‑kiválasztási folyamat részei. Rendszeres szöveg esetén működnek, amikor az Aspose.Slides egy nem elérhető betűtípust a szabály által megadott elérhető betűtípussal helyettesíti.

Az Office Math egyenleteknek további követelményük van. Ha egy egyenlet **Cambria Math** betűtípust használ, az Aspose.Slidesnek pontosan ezt a betűtípust kell rendelkezésre állnia az egyenlet elrendezésének számításához és rendereléséhez. Egy olyan szabály, amely egy másik matematikai betűtípust, például a **STIX Two Math**‑ot helyettesíti, nem tudja helyettesíteni a **Cambria Math**‑ot ebben a célban, és a renderelés továbbra is azt jelezheti, hogy a **Cambria Math** szükséges.

Az ilyen bemutató rendereléséhez vagy konvertálásához tegye a **Cambria Math** betűtípust elérhetővé az Aspose.Slides számára. Telepítse azt az operációs rendszerbe, vagy töltse be [külső betűtípust](/slides/hu/python-net/custom-font/).

Ez a korlátozás az egyenletelrendezésre vonatkozik. A fent leírt helyettesítési szabályok továbbra is érvényesek a bemutató szabályos szövegére.

## **GYIK**

**Mi a különbség a betűtípuscsere és a betűtípushelyettesítés között?**

[Betűtípuscsere](/slides/hu/python-net/font-replacement/) szándékosan megváltoztat egy betűtípust egy másikra a teljes bemutatóban. A betűtípushelyettesítés a renderelt kimenethez választ egy betűtípust, amikor a konfigurált feltétel teljesül, például ha az eredeti betűtípus nem érhető el.

**Mikor alkalmazzák a helyettesítési szabályokat?**

A szabályok részt vesznek a [font selection sequence](/slides/hu/python-net/font-selection-sequence/) folyamatban a renderelés és konvertálás során. A `WHEN_INACCESSIBLE` esetén a szabály csak akkor használatos, ha az Aspose.Slides nem tudja elérni a forrásbetűtípust.

**Mi történik, ha egy betűtípus hiányzik, és nincs beállított helyettesítési szabály?**

Az Aspose.Slides a legközelebbi elérhető betűtípust választja a betűtípus‑kiválasztási folyamata szerint. Az eredmény a futási környezetben elérhető betűtípusoktól függ.

**Betölthetek külső betűtípusokat a helyettesítés elkerüléséhez?**

Igen. [külső betűtípusok betöltése](/slides/hu/python-net/custom-font/) lehetővé teszi, hogy az Aspose.Slides ezeket a renderelés és konvertálás során használja.

**Az Aspose a betűtípusokat a könyvtárral együtt szállítja?**

Nem. Ön felelős a betűtípusok biztosításáért és azok licencefeltételeinek betartásáért.

**Eltérhetnek a helyettesítési eredmények Windows, Linux és macOS között?**

Igen. A telepített betűtípusok és a betűtípus‑keresési helyek operációs rendszer szerint változnak, így egy gépen elérhető betűtípus egy másikon helyettesítést igényelhet.

**Hogyan tehetem a betűtípus kiválasztását következetessé kötegelt konverziók esetén?**

Használjon ugyanazokat a betűtípus‑fájlokat és verziókat minden gépen vagy konténeren, [szükséges külső betűtípusok betöltése](/slides/hu/python-net/custom-font/) és [betűtípusok beágyazása](/slides/hu/python-net/embedded-font/) esetén, ha a licence engedélyezi. Emellett meghívhatja a [FontsManager.get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) metódust exportálás előtt, hogy azonosítsa a váratlan helyettesítéseket.