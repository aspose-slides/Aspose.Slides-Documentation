---
title: Betűkészlethelyettesítés beállítása prezentációkban Python használatával
linktitle: Betűkészlethelyettesítés
type: docs
weight: 70
url: /hu/python-net/font-substitution/
keywords:
- betűkészlet
- helyettesítő betűkészlet
- betűkészlethelyettesítés
- betűkészlet cseréje
- betűkészletcsere
- helyettesítési szabály
- csereszabály
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Betűkészlethelyettesítési szabályok beállítása és helyettesített betűkészletek ellenőrzése az Aspose.Slides for Python .NET-en keresztül PowerPoint és OpenDocument prezentációk renderelése vagy konvertálása során."
---
## **Áttekintés**

A betűkészlethelyettesítés lehetővé teszi az Aspose.Slides számára, hogy egy elérhető betűkészletet használjon egy nem elérhető betűkészlet helyett, amikor egy bemutatót renderelnek vagy konvertálnak. A helyettesítés a megjelenített kimenetet befolyásolja; nem változtatja meg a bemutató tartalmához rendelt betűkészletet.

Megadhatja a használni kívánt betűkészletet, ha egy adott betűkészlet nem áll rendelkezésre, és ellenőrizheti az Aspose.Slides által a renderelés során végrehajtott helyettesítéseket. Ez segít abban, hogy a kimenet következetes maradjon a különböző telepített betűkészletekkel rendelkező környezetek között.

## **Betűkészlethelyettesítések lekérése**

Használja a [FontsManager.get_substitutions](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontsmanager/get_substitutions/) metódust annak meghatározásához, mely betűkészletek lesznek helyettesítve a bemutató renderelése során. A metódus [FontSubstitutionInfo](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontsubstitutioninfo/) objektumokat ad vissza, amelyek az eredeti és a helyettesített betűkészlet nevét tartalmazzák.

A következő Python példa felsorolja az összes betűkészlethelyettesítést egy bemutatóhoz:

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    for substitution in presentation.fonts_manager.get_substitutions():
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")
```

## **Kijelölt diák betűkészlethelyettesítéseinek lekérése**

Használja a [FontsManager.get_substitutions](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontsmanager/get_substitutions/) metódust diák indexek listájával, hogy csak a konkrét diák rendereléséhez szükséges helyettesítéseket ellenőrizze. Ez akkor hasznos, ha a bemutató egy részét rendereli vagy exportálja, nagy bemutatót fokozatosan ellenőriz, az elérhetetlen betűkészletektől függő diák helyét keresi, minimális betűkészletcsomagot készít szerverhez vagy konténerhez, vagy renderelési különbségeket diagnosztizál anélkül, hogy a nem kapcsolódó diák feldolgozásra kerülnének.

A lista egy-alapú diák indexeket tartalmaz: a `1` az első diát jelöli. Ezzel szemben a [Presentation.slides](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/slides/hu/) gyűjtemény nullára-indexelt, ezért ugyanaz a dia `presentation.slides[0]`-ként érhető el. Építse a listát ennek a különbségnek a figyelembevételével, hogy elkerülje az egyes hibákat.

Hívja meg a metódust a [Presentation.fonts_manager](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/fonts_manager/) tulajdonságon keresztül. Csak a kiválasztott diák renderelése közben meghatározott helyettesítéseket adja vissza. Minden eredmény egy [FontSubstitutionInfo](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontsubstitutioninfo/) objektum, amely tartalmazza az eredeti és a helyettesített betűkészlet nevét. Az eredmény tükrözi a jelenlegi betűkészlet-környezetet, a beállított tartalék szabályokat, az [IFontSubstRuleCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ifontsubstrulecollection/) gyűjteményben tárolt helyettesítési szabályokat, valamint a [külső betöltésű betűkészleteket](/slides/hu/python-net/custom-font/).

Ugyanaz a helyettesítés több mint egy kiválasztott dián is szükséges lehet. Szűrje ki a duplikátumokat, amikor betűkészlet-nyilvántartást vagy előellenőrző jelentést készít. A következő példa minden visszaadott helyettesítést jelent, majd egy rendezett listát hoz létre az egyedi betűkészlet-leképezésekről:

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

A [FontsManager](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontsmanager/) osztály mindkét formáját biztosítja a metódusnak. Válasszon egyet a renderelési művelet hatóköre szerint:

| Metódushívás | Mikor használja |
|---|---|
| [get_substitutions](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontsmanager/get_substitutions/) argumentumok nélkül | Ha a teljes bemutatóhoz szükséges helyettesítéseket akarja. |
| [get_substitutions](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontsmanager/get_substitutions/) diák indexek listájával | Ha a kiválasztott tartományhoz, fokozatos ellenőrzéshez vagy részleges exportáláshoz szükséges helyettesítések. |

## **Betűkészlethelyettesítési szabályok beállítása**

Az Aspose.Slides által egy forrásbetűkészlet nem elérhető esetén használandó betűkészlet megadásához:

1. Töltse be a bemutatót.
2. Hozzon létre betűkészlet-definíciókat a forrás- és helyettesítő betűkészletekhez.
3. Hozzon létre egy [FontSubstRule](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontsubstrule/) elemet a [WHEN_INACCESSIBLE](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontsubstcondition/) feltétellel.
4. Adja hozzá a szabályt egy [FontSubstRuleCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontsubstrulecollection/) gyűjteményhez.
5. Rendelje hozzá a gyűjteményt a [FontsManager.font_subst_rule_list](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontsmanager/font_subst_rule_list/) tulajdonsághoz.
6. Renderelje vagy konvertálja a bemutatót.

A következő Python példa a `Arial` betűkészletet használja a `SomeRareFont` helyett, ha a `SomeRareFont` nem érhető el, majd rendereli az első diát az eredmény ellenőrzéséhez. A helyettesítő betűkészletnek elérhetőnek kell lennie az Aspose.Slides számára.

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

{{% alert color="info" title="Megjegyzés" %}}
Ha a teljes bemutatóban használt betűkészleteket feltétlenül módosítani szeretné, lásd a [Betűkészletcsere](/slides/hu/python-net/font-replacement/) cikket.
{{% /alert %}}

## **Matematikai egyenlet betűkészletek korlátozásai**

A betűkészlethelyettesítési szabályok a renderelés és konverzió során használt szabványos betűkészlet-kiválasztási folyamat részei. Rendszeres szöveg esetén működnek, amikor az Aspose.Slides a szabály által megadott elérhető betűkészlettel helyettesíti a nem elérhető betűkészletet.

Az Office Math egyenletek további követelményt támasztanak. Ha egy egyenlet **Cambria Math** betűkészletet használ, az Aspose.Slides pontosan ezt a betűkészletet igényelheti az egyenlet elrendezésének kiszámításához és rendereléséhez. Egy olyan szabály, amely egy másik matematikai betűkészletet, például a **STIX Two Math**-ot helyettesíti, nem tudja felváltani a **Cambria Math**-ot ebben a célban, és a renderelés továbbra is jelezheti, hogy **Cambria Math** szükséges.

Az ilyen bemutató rendereléséhez vagy konvertálásához tegye a **Cambria Math** betűkészletet elérhetővé az Aspose.Slides számára. Telepítse a rendszerbe, vagy töltse be [külső betűkészletként](/slides/hu/python-net/custom-font/).

Ez a korlátozás az egyenletelrendezésre vonatkozik. A fent leírt helyettesítési szabályok továbbra is érvényesek a normál bemutató szövegre.

## **GYIK**

**Mi a különbség a betűkészletcsere és a betűkészlethelyettesítés között?**

[Betűkészletcsere](/slides/hu/python-net/font-replacement/) szándékosan megváltoztat egy betűkészletet egy másikra a teljes bemutató során. A betűkészlethelyettesítés egy betűkészletet választ a renderelt kimenethez, amikor a beállított feltétel teljesül, például ha az eredeti betűkészlet nem áll rendelkezésre.

**Mikor alkalmazzák a helyettesítési szabályokat?**

A szabályok részt vesznek a [betűkészlet kiválasztási sorozatban](/slides/hu/python-net/font-selection-sequence/) a renderelés és konverzió során. A `WHEN_INACCESSIBLE` esetén a szabály csak akkor kerül alkalmazásra, ha az Aspose.Slides nem tudja elérni a forrás betűkészletet.

**Mi történik, ha egy betűkészlet hiányzik és nincs beállítva helyettesítési szabály?**

Az Aspose.Slides a legközelebbi elérhető betűkészletet választja a betűkészlet-kiválasztási folyamata szerint. Az eredmény a futási környezetben elérhető betűkészletektől függ.

**Betölthetek külső betűkészleteket a helyettesítés elkerüléséhez?**

Igen. [Betöltheti a külső betűkészleteket](/slides/hu/python-net/custom-font/), így az Aspose.Slides használhatja őket a renderelés és konverzió során.

**Terjeszti-e az Aspose a betűkészleteket a könyvtárral együtt?**

Nem. Ön felelős a betűkészletek biztosításáért és azok licencfeltételeinek betartásáért.

**Különbözhetnek a helyettesítési eredmények Windows, Linux és macOS között?**

Igen. A telepített betűkészletek és a betűkészlet keresési helyei operációs rendszerenként eltérnek, így egy gépen elérhető betűkészlet másik gépen helyettesítést igényelhet.

**Hogyan tehetem a betűkészlet kiválasztását következetessé kötegelt konverziók során?**

Használja ugyanazokat a betűkészlet-fájlokat és verziókat minden gépen vagy konténeren, [töltse be a szükséges külső betűkészleteket](/slides/hu/python-net/custom-font/), és [ágyazza be a betűkészleteket](/slides/hu/python-net/embedded-font/) amennyiben a licenc engedélyezi. Emellett meghívhatja a [FontsManager.get_substitutions](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontsmanager/get_substitutions/) metódust exportálás előtt, hogy azonosítsa a váratlan helyettesítéseket.