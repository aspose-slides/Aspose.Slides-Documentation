---
title: Betűtípus helyettesítés beállítása prezentációkban C++-ban
linktitle: Betűtípus helyettesítés
type: docs
weight: 70
url: /hu/cpp/font-substitution/
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
- C++
- Aspose.Slides
description: "Állítsa be a betűtípus helyettesítési szabályokat, és vizsgálja meg az Aspose.Slides for C++ által használt helyettesített betűtípusokat PowerPoint és OpenDocument prezentációk renderelése vagy konvertálása során."
---
## **Áttekintés**

A betűtípus helyettesítés lehetővé teszi az Aspose.Slides számára, hogy egy elérhető betűtípust használjon egy olyan betűtípussal helyettesítve, amelyet nem lehet elérni a bemutató renderelése vagy konvertálása során. A helyettesítés a megjelenített kimenetet érinti; nem változtatja meg a bemutató tartalmához rendelt betűtípust.

Megadhatja a használni kívánt betűtípust, ha egy adott betűtípus nem érhető el, és megtekintheti az Aspose.Slides által a renderelés során végrehajtott helyettesítéseket. Ez segít a kimenetet konzisztens módon tartani különböző, eltérő telepített betűtípusokkal rendelkező környezetekben.

## **Betűtípus helyettesítések lekérése**

Használja az [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ifontsmanager/getsubstitutions/) metódust annak meghatározásához, mely betűtípusok lesznek helyettesítve a bemutató renderelésekor. A metódus [FontSubstitutionInfo](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsubstitutioninfo/) objektumokat ad vissza, amelyek az eredeti és a helyettesített betűtípus neveket tartalmazzák.

Az alábbi C++ példa felsorolja az összes betűtípus helyettesítést egy bemutatóhoz:
```cpp
#include <DOM/FontSubstitutionInfo.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

for (auto&& substitution : presentation->get_FontsManager()->GetSubstitutions())
{
    Console::WriteLine(u"{0} -> {1}", substitution->get_OriginalFontName(), substitution->get_SubstitutedFontName());
}

presentation->Dispose();
```

## **Betűtípus helyettesítések lekérése a kiválasztott diákra**

Használja az [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ifontsmanager/getsubstitutions/) túlterhelését egy `System::ArrayPtr<int32_t> slides` argumentummal, hogy csak a konkrét diák rendereléséhez szükséges helyettesítéseket tekintse meg. Ez akkor hasznos, ha a bemutató egy részét rendereli vagy exportálja, nagy bemutatót inkrementálisan ellenőriz, olyan diát keres, amelyek nem elérhető betűtípusoktól függenek, minimális betűtípuscsomagot készít szerver vagy konténer számára, vagy a renderelési különbségeket diagnosztizálja a nem releváns diák feldolgozása nélkül.

A `slides` tömb egy‑bázisú diaindexeket tartalmaz: `1` az első diát jelöli. Ezzel szemben a [Presentation::get_Slide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_slide/) metódus null‑bázisú indexet használ, ezért ugyanaz a dia `presentation->get_Slide(0)` formában érhető el. Tartsa szem előtt ezt a különbséget a tömb felépítésekor, hogy elkerülje az egy‑indexes eltérést.

Hívja a túlterhelést a [Presentation::get_FontsManager](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_fontsmanager/) metóduson keresztül. Ez csak a kiválasztott diák renderelése során meghatározott helyettesítéseket adja vissza. Minden eredmény egy [FontSubstitutionInfo](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsubstitutioninfo/) objektum, amely az eredeti és a helyettesített betűtípus neveket tartalmazza. Az eredmény tükrözi a jelenlegi betűtípus környezetet, a beállított tartalék szabályokat, az [IFontSubstRuleCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ifontsubstrulecollection/)‑ben tárolt helyettesítési szabályokat, valamint a [külsőleg betöltött betűtípusokat](/slides/hu/cpp/custom-font/).

Ugyanaz a helyettesítés több mint egy kiválasztott dián is szükséges lehet. Szűrje le a duplikátumokat, amikor betűtípus leltárt vagy előellenőrző jelentést készít. Az alábbi példa minden visszakapott helyettesítést jelent, majd egy rendezett listát hoz létre az egyedi betűtípus leképezésekről:
```cpp
#include <DOM/FontSubstitutionInfo.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <system/array.h>
#include <system/collections/sorted_set.h>
#include <system/console.h>
#include <system/string.h>
#include <system/string_comparer.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

auto selectedSlides = MakeArray<int32_t>({1, 3, 5});
auto substitutions = presentation->get_FontsManager()->GetSubstitutions(selectedSlides);
auto sortedPreflightEntries = MakeObject<SortedSet<String>>(StringComparer::get_OrdinalIgnoreCase());

Console::WriteLine(u"Substitutions for the selected slides:");
for (auto&& substitution : substitutions)
{
    auto entry = String::Format(u"{0} -> {1}", substitution->get_OriginalFontName(), substitution->get_SubstitutedFontName());
    Console::WriteLine(entry);
    sortedPreflightEntries->Add(entry);
}

Console::WriteLine(u"Deduplicated font preflight report:");
for (auto&& entry : sortedPreflightEntries)
{
    Console::WriteLine(entry);
}

presentation->Dispose();
```

Az [IFontsManager](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ifontsmanager/) interfész mindkét túlterhelést biztosítja. Válasszon egyet a renderelési művelet körének megfelelően:

| Túlterhelés | Használja akkor, amikor |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ifontsmanager/getsubstitutions/) argumentumok nélkül | Az egész bemutatóhoz szükséges helyettesítésekre van szükség. |
| [GetSubstitutions](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ifontsmanager/getsubstitutions/) `System::ArrayPtr<int32_t> slides` argumentummal | Kiválasztott tartomány, inkrementális ellenőrzés vagy részleges export esetén szükséges helyettesítésekre van szükség. |

## **Betűtípus helyettesítési szabályok beállítása**

Az Aspose.Slides által egy forrás betűtípus hiányában használandó betűtípus megadásához:

1. Töltse be a bemutatót.  
2. Hozzon létre betűtípusdefiníciókat a forrás és helyettesítő betűtípusokhoz.  
3. Hozzon létre egy [FontSubstRule](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsubstrule/) objektumot a [WhenInaccessible](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsubstcondition/) feltétellel.  
4. Adja hozzá a szabályt egy [FontSubstRuleCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsubstrulecollection/) gyűjteményhez.  
5. Rendelje hozzá a gyűjteményt az [IFontsManager::set_FontSubstRuleList](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ifontsmanager/set_fontsubstrulelist/) metódus használatával.  
6. Renderelje vagy konvertálja a bemutatót.

Az alábbi C++ példa a `SomeRareFont` helyett `Arial`-t használ, ha a `SomeRareFont` nem elérhető, majd rendereli az első diát az eredmény ellenőrzéséhez. A helyettesítő betűtípusnak elérhetőnek kell lennie az Aspose.Slides számára.
```cpp
#include <DOM/FontSubstCondition.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/Fonts/FontSubstRule.h>
#include <DOM/Fonts/FontSubstRuleCollection.h>
#include <DOM/IFontsManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Fonts.pptx");

auto sourceFont = MakeObject<FontData>(u"SomeRareFont");
auto substituteFont = MakeObject<FontData>(u"Arial");
auto substitutionRule = MakeObject<FontSubstRule>(sourceFont, substituteFont, FontSubstCondition::WhenInaccessible);

auto substitutionRules = MakeObject<FontSubstRuleCollection>();
substitutionRules->Add(substitutionRule);
presentation->get_FontsManager()->set_FontSubstRuleList(substitutionRules);

auto image = presentation->get_Slide(0)->GetImage(1.0f, 1.0f);
image->Save(u"slide.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

{{% alert color="info" title="Megjegyzés" %}}
Az egész bemutatóban használt betűtípusok feltétel nélküli módosításához tekintse meg a [Font Replacement](/slides/hu/cpp/font-replacement/) oldalt.
{{% /alert %}}

## **Korlátozások a matematikai egyenlet betűtípusoknál**

A betűtípus helyettesítési szabályok a renderelés és konvertálás során használt szabványos betűtípus kiválasztási folyamat részei. Reguláris szövegnél akkor működnek, ha az Aspose.Slides egy nem elérhető betűtípust a szabály által megadott elérhető betűtípussal helyettesít.

Az Office Math egyenleteknek további követelményük van. Ha egy egyenlet **Cambria Math** betűtípust használ, az Aspose.Slidesnek pontosan ezt a betűtípust szüksége lehet az egyenlet elrendezésének kiszámításához és rendereléséhez. Olyan szabály, amely egy másik matematikai betűtípust, például **STIX Two Math**-ot helyettesít, nem tudja helyettesíteni a **Cambria Math**-ot ebben a célban, és a renderelés továbbra is azt jelezheti, hogy **Cambria Math** szükséges.

Az ilyen bemutató rendereléséhez vagy konvertálásához tegye elérhetővé a **Cambria Math** betűtípust az Aspose.Slides számára. Telepítse a rendszerbe, vagy töltse be [külső betűtípusként](/slides/hu/cpp/custom-font/).

Ez a korlátozás az egyenlet elrendezésére vonatkozik. A fent leírt helyettesítési szabályok továbbra is érvényesek a bemutató szokásos szövegére.

## **GYIK**

**Mi a különbség a betűtípus csere és a betűtíp

us helyettesítés között?**  
[Font replacement](/slides/hu/cpp/font-replacement/) szándékosan megváltoztat egy betűtípust egy másikra a teljes bemutató során. A betűtípus helyettesítés egy betűtípust választ a renderelt kimenethez, amikor a konfigurált feltétel teljesül, például ha az eredeti betűtípus nem érhető el.

**Mikor alkalmazzák a helyettesítési szabályokat?**  
A szabályok részt vesznek a [betűtípus kiválasztási sorozat](/slides/hu/cpp/font-selection-sequence/) során a renderelés és konvertálás alatt. A `WhenInaccessible` esetén a szabály csak akkor használatos, ha az Aspose.Slides nem tudja elérni a forrás betűtípust.

**Mi történik, ha egy betűtípus hiányzik és nincs beállítva helyettesítési szabály?**  
Az Aspose.Slides a legközelebbi elérhető betűtípust választja a betűtípus kiválasztási folyamata szerint. Az eredmény a futási környezetben elérhető betűtípusoktól függ.

**Betölthetek külső betűtípusokat a helyettesítés elkerülése érdekében?**  
Igen. [Betöltheti a külső betűtípusokat](/slides/hu/cpp/custom-font/), hogy az Aspose.Slides a renderelés és konvertálás során használhassa őket.

**Terjeszti-e az Aspose a betűtípusokat a könyvtárral együtt?**  
Nem. Ön felelős a betűtípusok biztosításáért és a licencfeltételek betartásáért.

**Eltérhetnek-e a helyettesítési eredmények Windows, Linux és macOS között?**  
Igen. A telepített betűtípusok és a betűtípus keresési helyek operációs rendszerenként eltérnek, így egy gépen elérhető betűtípus egy másikon helyettesítést igényelhet.

**Hogyan tehetem a betűtípus választást konzisztenssé kötegelt konverziókban?**  
Használja ugyanazokat a betűtípus fájlokat és verziókat minden gépen vagy konténeren, [töltse be a szükséges külső betűtípusokat](/slides/hu/cpp/custom-font/), és [ágyazza be a betűtípusokat](/slides/hu/cpp/embedded-font/) ahol a licenc engedélyezi. Emellett meghívhatja az [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ifontsmanager/getsubstitutions/) metódust exportálás előtt, hogy azonosítsa a váratlan helyettesítéseket.