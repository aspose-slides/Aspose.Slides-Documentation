---
title: Betűtípus-helyettesítés konfigurálása prezentációkban .NET környezetben
linktitle: Betűtípus-helyettesítés
type: docs
weight: 70
url: /hu/net/font-substitution/
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
- .NET
- C#
- Aspose.Slides
description: "Betűtípus-helyettesítési szabályok konfigurálása és a helyettesített betűtípusok ellenőrzése az Aspose.Slides for .NET-ben PowerPoint és OpenDocument prezentációk renderelése vagy konvertálása során."
---
## **Áttekintés**

A betűtípushelyettesítés lehetővé teszi, hogy az Aspose.Slides egy elérhető betűtípust használjon egy olyan betűtípus helyett, amelyhez a prezentáció renderelése vagy konvertálása során nem fér hozzá. A helyettesítés a megjelenített kimenetet érinti; nem változtatja meg a prezentáció tartalmához rendelt betűtípust.

Megadhatja, hogy melyik betűtípust kell használni, amikor egy adott betűtípus nem érhető el, és megtekintheti az Aspose.Slides által a renderelés során végrehajtott helyettesítéseket. Ez segít a kimenet konzisztens megtartásában különböző, eltérő telepített betűtípusokkal rendelkező környezetekben.

## **Betűtípushelyettesítések lekérése**

Használja a [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) metódust annak meghatározásához, hogy mely betűtípusok lesznek helyettesítve a prezentáció renderelésekor. A metódus [FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/) objektumokat ad vissza, amelyek az eredeti és a helyettesített betűtípusok nevét tartalmazzák.

A következő C# példa felsorolja a prezentáció összes betűtípushelyettesítését:
```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}
```

## **Kiválasztott diák betűtípushelyettesítéseinek lekérése**

Használja az [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) túlterhelést `int[] slides` argumentummal, hogy csak a meghatározott diák rendereléséhez szükséges helyettesítéseket vizsgálja. Ez hasznos, ha a prezentáció egy részét rendereli vagy exportálja, fokozatosan ellenőrzi a nagy prezentációt, olyan diákot keres, amelyek nem elérhető betűtípusoktól függenek, minimális betűtípuscsomagot készít szerver vagy konténer számára, vagy a renderelési különbségeket diagnosztizálja anélkül, hogy a nem releváns diák feldolgozásra kerülnek.

A `slides` tömb egy-alapú diák indexeket tartalmaz: az `1` az első diát jelöli. Ezzel szemben a [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) gyűjtemény indexelője nullára alapozott, így ugyanaz a dia `presentation.Slides[0]` formában érhető el. Ügyeljen erre a különbségre a tömb felépítésekor, hogy elkerülje az egyes hibákat.

Hívja meg a túlterhelést a [Presentation.FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/) tulajdonságon keresztül. Csak azokat a helyettesítéseket adja vissza, amelyeket a kiválasztott diák renderelése során határozott meg. Minden eredmény egy [FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/) objektum, amely az eredeti és a helyettesített betűtípusok nevét tartalmazza. Az eredmény tükrözi a jelenlegi betűtípus‑környezetet és a [külsőleg betöltött betűtípusokat](/slides/hu/net/custom-font/). Az [IFontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/ifontsubstrulecollection/)‑ben tárolt helyettesítési szabályok módosítják a renderelt kimenetet, de az eredményben nem jelennek meg.

Egy ugyanaz a helyettesítés több mint egy kiválasztott dia esetén is szükséges lehet. Szűrje ki az ismétlődéseket, amikor betűtípus‑inventárt vagy előellenőrző jelentést készít. A következő példa minden visszaadott helyettesítést jelent, majd egy rendezett listát hoz létre az egyedi betűtípusleképezésekről:
```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

int[] selectedSlides = { 1, 3, 5 };
var substitutions = presentation.FontsManager.GetSubstitutions(selectedSlides).ToList();

Console.WriteLine("Substitutions for the selected slides:");
foreach (var substitution in substitutions)
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}

var preflightEntries = substitutions.Select(substitution => $"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
var uniquePreflightEntries = preflightEntries.Distinct(StringComparer.OrdinalIgnoreCase);
var sortedPreflightEntries = uniquePreflightEntries.OrderBy(entry => entry, StringComparer.OrdinalIgnoreCase).ToList();

Console.WriteLine("Deduplicated font preflight report:");
foreach (var entry in sortedPreflightEntries)
{
    Console.WriteLine(entry);
}
```

Az [IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/) interfész mindkét túlterhelést biztosítja. Válasszon egyet a renderelési művelet kiterjedésének megfelelően:

| Túlterhelés | Használja, ha |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) with no arguments | A teljes prezentációhoz szükséges helyettesítések. |
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) with `int[] slides` | Kiválasztott tartományhoz, fokozatos ellenőrzéshez vagy részleges exporthoz szükséges helyettesítések. |

## **Betűtípushelyettesítési szabályok beállítása**

Annak meghatározásához, hogy az Aspose.Slides milyen betűtípust használjon, amikor egy forrásbetűtípus nem érhető el:

1. Töltse be a prezentációt.
2. Hozzon létre betűtípusdefiníciókat a forrás- és helyettesítő betűtípusokhoz.
3. Hozzon létre egy [FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) szabályt a [WhenInaccessible](https://reference.aspose.com/slides/net/aspose.slides/fontsubstcondition/) feltétellel.
4. Adja hozzá a szabályt egy [FontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrulecollection/) gyűjteményhez.
5. Rendelje hozzá a gyűjteményt a [FontsManager.FontSubstRuleList](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/fontsubstrulelist/) tulajdonsághoz.
6. Renderelje vagy konvertálja a prezentációt.

A következő C# példa a `SomeRareFont` helyett az `Arial` betűtípust használja, ha a `SomeRareFont` nem érhető el, majd rendereli az első diát az eredmény ellenőrzéséhez. A helyettesítő betűtípusnak elérhetőnek kell lennie az Aspose.Slides számára.
```csharp
using Aspose.Slides;

using var presentation = new Presentation("Fonts.pptx");

var sourceFont = new FontData("SomeRareFont");
var substituteFont = new FontData("Arial");
var substitutionRule = new FontSubstRule(sourceFont, substituteFont, FontSubstCondition.WhenInaccessible);

var substitutionRules = new FontSubstRuleCollection();
substitutionRules.Add(substitutionRule);
presentation.FontsManager.FontSubstRuleList = substitutionRules;

using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("slide.jpg", ImageFormat.Jpeg);
```

{{% alert color="info" title="Note" %}}
A prezentációban használt betűtípusok feltétel nélküli módosításához tekintse meg a [Font Replacement](/slides/hu/net/font-replacement/) oldalt.
{{% /alert %}}

## **Korlátozások a matematikai egyenlet betűtípusokra vonatkozóan**

A betűtípushelyettesítési szabályok a renderelés és konvertálás során használt szabványos betűtípus‑kiválasztási folyamat részei. Rendszeres szöveg esetén működnek, ha az Aspose.Slides egy nem elérhető betűtípust a szabály által meghatározott elérhető betűtípussal helyettesíti.

Az Office Math egyenleteknek további követelményük van. Ha egy egyenlet **Cambria Math** betűtípust használ, az Aspose.Slidesnek pontosan ezt a betűtípust kell rendelkezésre állnia az egyenlet elrendezésének kiszámításához és rendereléséhez. Olyan szabály, amely egy másik matematikai betűtípust, például **STIX Two Math**‑ot helyettesít, nem tudja helyettesíteni a **Cambria Math**‑ot erre a célra, és a renderelés továbbra is jelzi, hogy **Cambria Math** szükséges.

Az ilyen prezentáció rendereléséhez vagy konvertálásához tegye elérhetővé a **Cambria Math** betűtípust az Aspose.Slides számára. Telepítse a rendszerbe, vagy töltse be [külső betűtípusként](/slides/hu/net/custom-font/).

Ez a korlátozás az egyenletelrendezésre vonatkozik. A fent leírt helyettesítési szabályok továbbra is érvényesek a szabályos prezentációs szövegre.

## **GYIK**

**Mi a különbség a betűtípuscsere és a betűtípushelyettesítés között?**

[Font replacement](/slides/hu/net/font-replacement/) szándékosan megváltoztatja a betűtípust egy másikra a teljes prezentációban. A betűtípushelyettesítés olyan betűtípust választ a megjelenített kimenethez, amikor a beállított feltétel teljesül, például ha az eredeti betűtípus nem érhető el.

**Mikor alkalmazzák a helyettesítési szabályokat?**

A szabályok a [font selection sequence](/slides/hu/net/font-selection-sequence/) részeként vesznek részt a renderelés és konvertálás során. `WhenInaccessible` esetén a szabály csak akkor kerül alkalmazásra, ha az Aspose.Slides nem tud hozzáférni a forrás betűtípushoz.

**Mi történik, ha egy betűtípus hiányzik, és nincs beállítva helyettesítési szabály?**

Az Aspose.Slides a legközelebbi elérhető betűtípust választja a betűtípus‑kiválasztási folyamatának megfelelően. Az eredmény a futási környezetben elérhető betűtípusoktól függ.

**Betölthetek külső betűtípusokat a helyettesítés elkerüléséhez?**

Igen. [Betöltheti a külső betűtípusokat](/slides/hu/net/custom-font/), így az Aspose.Slides használhatja őket a renderelés és konvertálás során.

**Az Aspose a betűtípusokat a könyvtárral együtt terjeszti?**

Nem. Önnek kell biztosítania a betűtípusokat és betartania azok licencfeltételeit.

**Eltérőek lehetnek a helyettesítési eredmények Windows, Linux és macOS között?**

Igen. A telepített betűtípusok és a betűtípus‑keresési helyek operációs rendszerenként eltérnek, ezért egy gépen elérhető betűtípus másik gépen helyettesítést igényelhet.

**Hogyan tehetem következetessé a betűtípus‑kiválasztást kötegelt konvertálások során?**

Használjon ugyanazokat a betűtípusfájlokat és verziókat minden gépen vagy konténerben, [töltse be a szükséges külső betűtípusokat](/slides/hu/net/custom-font/), és [ágyazza be a betűtípusokat](/slides/hu/net/embedded-font/), ha a licenc engedi. Exportálás előtt meghívhatja a [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) metódust is, hogy azonosítsa a váratlan helyettesítéseket.