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
description: "Állítsa be a betűtípus helyettesítési szabályokat, és ellenőrizze a helyettesített betűtípusokat az Aspose.Slides for C++ könyvtárban PowerPoint és OpenDocument prezentációk renderelése vagy konvertálása során."
---
## **Áttekintés**

A betűtípus helyettesítés lehetővé teszi az Aspose.Slides számára, hogy egy elérhető betűtípust használjon egy olyan betűtípus helyett, amelyhez a prezentáció renderelése vagy konvertálása során nem fér hozzá. A helyettesítés a renderelt kimenetet érinti; nem módosítja a prezentáció tartalmához rendelt betűtípust.

Meghatározhatja, hogy melyik betűtípust kell használni, ha egy adott betűtípus nem áll rendelkezésre, illetve megtekintheti a helyettesítéseket, amelyeket az Aspose.Slides a renderelés során végez. Ez segít egységes kimenetet biztosítani a különböző, eltérő betűtípusokkal rendelkező környezetekben.

Ha egy betűtípus elérhető, de nincs hozzá dedikált félkövér változat, lásd a [Handle Fonts Without a Dedicated Bold Typeface](/slides/hu/cpp/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface) szakaszt. Ott leírják, hogyan lehet raszterizálni a befolyásolt szöveget PDF‑exportálás során, és milyen hatásai vannak a szövegkijelölésnek, keresésnek és méretezésnek.

## **Betűtípus helyettesítések lekérdezése**

Használja a [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) metódust annak meghatározásához, mely betűtípusok lesznek helyettesítve a prezentáció renderelésekor. A metódus [FontSubstitutionInfo](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstitutioninfo/) objektumokat ad vissza, amelyek az eredeti és a helyettesített betűtípus neveket tartalmazzák.

A következő C++ példa felsorolja az összes betűtípus helyettesítést egy prezentációhoz:

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

## **Betűtípus helyettesítések lekérdezése a kiválasztott diákhoz**

Használja a [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) túlterhelést a `System::ArrayPtr<int32_t> slides` argumentummal, hogy csak a kiválasztott diák rendereléséhez szükséges helyettesítéseket vizsgálja. Ez akkor hasznos, ha a prezentáció egy részét rendereli vagy exportálja, fokozatosan ellenőrzi egy nagy prezentációt, azonosítja a nem elérhető betűtípusokra támaszkodó diákat, minimális betűtípuscsomagot készít szerverhez vagy konténerhez, vagy a renderelési eltéréseket a nem releváns diák feldolgozása nélkül szeretné diagnosztizálni.

A `slides` tömb egy‑alapú diavetítési indexeket tartalmaz: az `1` az első diát jelöli. Ezzel szemben a [Presentation::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slide/) metódus nulla‑alapú indexet használ, így ugyanaz a dia `presentation->get_Slide(0)`‑ként érhető el. Építse fel a tömböt ennek a különbségnek a figyelembevételével, hogy elkerülje az egy‑eltéréses hibákat.

Hívja meg a túlterhelést a [Presentation::get_FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_fontsmanager/) metóduson keresztül. Ez csak azokat a helyettesítéseket adja vissza, amelyeket a kiválasztott diák renderelése közben határozott meg. Minden eredmény egy [FontSubstitutionInfo](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstitutioninfo/) objektum, amely az eredeti és a helyettesített betűtípus neveket tartalmazza. Az eredmény tükrözi a jelenlegi betűtípus‑környezetet, a konfigurált visszaeső szabályokat, az [IFontSubstRuleCollection](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsubstrulecollection/)‑ben tárolt helyettesítési szabályokat, valamint a [külső betöltött betűtípusokat](/slides/hu/cpp/custom-font/).

Ugyanaz a helyettesítés több mint egy kiválasztott dia esetén is szükséges lehet. Szűrje le az eredményeket, amikor betűtípus‑leltárt vagy preflight jelentést készít. A következő példa minden visszaadott helyettesítést jelent, majd egy rendezett listát hoz létre az egyedi betűtípus‑leképezésekről:

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

Az [IFontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/) felület mindkét túlterhelést biztosítja. Válassza ki a megfelelőt a renderelési művelet hatókörének megfelelően:

| Túlterhelés | Használat esetén |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) argumentumok nélkül | Ha a teljes prezentációhoz szükséges helyettesítések. |
| [GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) `System::ArrayPtr<int32_t> slides` argumentummal | Ha egy kiválasztott tartományhoz, fokozatos ellenőrzéshez vagy részleges exportáláshoz szükséges helyettesítések. |

## **Betűtípus helyettesítési szabályok beállítása**

A forrásbetűtípus hiányában az Aspose.Slides által használandó betűtípus megadásához:

1. Töltse be a prezentációt.
2. Hozzon létre betűtípus‑definíciókat a forrás‑ és a helyettesítő betűtípusokhoz.
3. Hozzon létre egy [FontSubstRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstrule/) objektumot a [WhenInaccessible](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstcondition/) feltétellel.
4. Adja hozzá a szabályt egy [FontSubstRuleCollection](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstrulecollection/) példányhoz.
5. Rendelje hozzá a gyűjteményt az [IFontsManager::set_FontSubstRuleList](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/set_fontsubstrulelist/) metódus használatával.
6. Renderelje vagy konvertálja a prezentációt.

A következő C++ példa a `Arial`‑t helyettesíti a `SomeRareFont`‑nal, ha az utóbbi nem áll rendelkezésre, majd rendereli az első diát a végeredmény ellenőrzéséhez. A helyettesítő betűtípusnak elérhetőnek kell lennie az Aspose.Slides számára.

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

{{% alert color="info" title="Note" %}}
Az egész prezentációban alkalmazott betűtípusok feltétel nélküli módosításához lásd a [Font Replacement](/slides/hu/cpp/font-replacement/) szakaszt.
{{% /alert %}}

## **Korlátozások a matematikai egyenlet‑betűtípusokra**

A betűtípus helyettesítési szabályok a szabványos betűtípus‑kiválasztási folyamat részei, amely a renderelés és a konvertálás során használatos. Rendszeres szövegre működnek, amikor az Aspose.Slides egy nem elérhető betűtípust a szabályban megadott elérhető betűtípussal helyettesíthet.

Az Office Math egyenleteknek további követelményük van. Ha egy egyenlet **Cambria Math**‑ot használ, az Aspose.Slides pontosan ezt a betűtípust igényelheti az egyenlet elrendezésének kiszámításához és rendereléséhez. Egy másik matematikai betűtípust (például **STIX Two Math**) helyettesítő szabály nem cserélheti le a **Cambria Math**‑ot, és a renderelés továbbra is azt jelezheti, hogy a **Cambria Math** szükséges.

Az ilyen prezentáció rendereléséhez vagy konvertálásához tegye elérhetővé a **Cambria Math**‑ot az Aspose.Slides számára. Telepítse a rendszerbe, vagy töltse be egy [külső betűtípusként](/slides/hu/cpp/custom-font/).

Ez a korlátozás az egyenlet‑elrendezésre vonatkozik. A fent leírt helyettesítési szabályok továbbra is érvényesek a prezentáció szokásos szövegeire.

## **GYIK**

**Mi a különbség a betűtípus‑cserélés és a betűtípus‑helyettesítés között?**

A [Font replacement](/slides/hu/cpp/font-replacement/) szándékosan megváltoztat egy betűtípust egy másikra a teljes prezentáció során. A betűtípus‑helyettesítés a renderelt kimenethez választ betűtípust, ha a konfigurált feltétel teljesül, például ha az eredeti betűtípus nem érhető el.

**Mikor alkalmazzák a helyettesítési szabályokat?**

A szabályok részt vesznek a [font selection sequence](/slides/hu/cpp/font-selection-sequence/) folyamatában renderelés és konvertálás közben. A `WhenInaccessible` esetén a szabály csak akkor használatos, ha az Aspose.Slides nem tudja elérni a forrás‑betűtípust.

**Mi történik, ha egy betűtípus hiányzik, és nincs konfigurálva helyettesítési szabály?**

Az Aspose.Slides a legközelebbi elérhető betűtípust választja a betűtípus‑kiválasztási folyamata szerint. Az eredmény a futásidő környezetben elérhető betűtípusoktól függ.

**Betölthetek külső betűtípusokat a helyettesítés elkerülése érdekében?**

Igen. [Load external fonts](/slides/hu/cpp/custom-font/) segítségével az Aspose.Slides használhatja őket renderelés és konvertálás során.

**Az Aspose terjeszti a betűtípusokat a könyvtárral együtt?**

Nem. A betűtípusok biztosításáért és a licencfeltételek betartásáért Ön felel.

**A helyettesítési eredmények eltérhetnek Windows, Linux és macOS között?**

Igen. A telepített betűtípusok és a betűtípus‑keresési helyek operációs rendszer szerint változnak, ezért egy gépen elérhető betűtípus másik gépen helyettesítést igényelhet.

**Hogyan tehetem a betűtípus‑kiválasztást konzisztenssé kötegelt konvertálásoknál?**

Használjon azonos betűtárgy‑fájlokat és verziókat minden gépen vagy konténerben, [load required external fonts](/slides/hu/cpp/custom-font/), és [embed fonts](/slides/hu/cpp/embedded-font/) amikor a licenc megengedi. A [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) meghívásával exportálás előtt azonosíthatja a váratlan helyettesítéseket.