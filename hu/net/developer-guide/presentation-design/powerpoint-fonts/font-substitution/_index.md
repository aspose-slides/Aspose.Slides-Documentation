---
title: Betűtípus-helyettesítés konfigurálása prezentációkban .NET-ben
linktitle: Betűtípus helyettesítés
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
description: "Konfigurálja a betűtípus-helyettesítési szabályokat, és ellenőrizze a helyettesített betűtípusokat az Aspose.Slides for .NET-ben PowerPoint és OpenDocument prezentációk renderelése vagy konvertálása során."
---
## **Áttekintés**

A betűtípus‑helyettesítés lehetővé teszi, hogy az Aspose.Slides egy elérhető betűtípust használjon egy olyan betűtípus helyett, amely a prezentáció renderelése vagy konvertálása során nem érhető el. A helyettesítés a megjelenített kimenetet érinti; nem módosítja a prezentáció tartalmához rendelt betűtípust.

Megadhatja a használni kívánt betűtípust, ha egy adott betűtípus nem érhető el, és megtekintheti a Aspose.Slides által a renderelés során végrehajtott helyettesítéseket. Ez segít a kimenetet konzisztenssé tenni különböző, eltérő betűtípusokkal rendelkező környezetek között.

## **Betűtípus‑helyettesítések lekérése**

Használja a [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/hu/net/aspose.slides/ifontsmanager/getsubstitutions/) metódust annak meghatározásához, mely betűtípusok lesznek helyettesítve a prezentáció renderelésekor. A metódus [FontSubstitutionInfo](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsubstitutioninfo/) objektumokat ad vissza, amelyek az eredeti és a helyettesített betűtípusneveket tartalmazzák.

Az alábbi C# példa felsorolja az összes betűtípus‑helyettesítést egy prezentációhoz:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}
```

## **Betűtípus‑helyettesítések lekérése a kijelölt diákhoz**

Használja a [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/hu/net/aspose.slides/ifontsmanager/getsubstitutions/) túlterhelését `int[] slides` argumentummal, hogy csak a konkrét diák rendereléséhez szükséges helyettesítéseket ellenőrizze. Ez akkor hasznos, amikor a prezentáció egy részét rendereli vagy exportálja, egy nagy prezentációt fokozatosan ellenőriz, olyan diákot keres, amelyek nem elérhető betűtípusoktól függenek, minimális betűtípuscsomagot készít szerverhez vagy konténerhez, vagy a renderelési különbségeket diagnosztizálja anélkül, hogy a nem releváns diákokat feldolgozná.

A `slides` tömb egy‑bázisú diaindexeket tartalmaz: `1` az első diát jelöli. Ezzel szemben a [Presentation.Slides](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/slides/hu/) gyűjtemény indexelője null‑bázisú, így ugyanazt a diát `presentation.Slides[0]`‑ként érhetjük el. Ezt a különbséget tartsa szem előtt a tömb felépítésekor, hogy elkerülje az egy‑értékelt hibákat.

Hívja meg a túlterhelést a [Presentation.FontsManager](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/fontsmanager/) tulajdonságon keresztül. Csak a kiválasztott diák renderelése során meghatározott helyettesítéseket adja vissza. Minden eredmény egy [FontSubstitutionInfo](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsubstitutioninfo/) objektum, amely az eredeti és a helyettesített betűtípusneveket tartalmazza. Az eredmény tükrözi a jelenlegi betűtípus‑környezetet, a konfigurált tartalék‑szabályokat, az [IFontSubstRuleCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/ifontsubstrulecollection/)‑ben tárolt helyettesítési szabályokat, valamint a [külsőleg betöltött betűtípusokat](/slides/hu/net/custom-font/).

Ugyanaz a helyettesítés több kijelölt dián is szükséges lehet. Szűrje le a duplikátumokat, amikor betűtípus‑leltárt vagy előzetes jelentést készít. Az alábbi példa minden visszaadott helyettesítést jelent, majd egy rendezett listát hoz létre az egyedi betűtípus‑leképezésekről:

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

Az [IFontsManager](https://reference.aspose.com/slides/hu/net/aspose.slides/ifontsmanager/) interfész mindkét túlterhelést biztosítja. Válasszon egyet a renderelési művelet hatókörének megfelelően:

| Túlterhelés | Mikor használja |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/hu/net/aspose.slides/ifontsmanager/getsubstitutions/) argumentumok nélkül | A teljes prezentációhoz szükséges helyettesítések. |
| [GetSubstitutions](https://reference.aspose.com/slides/hu/net/aspose.slides/ifontsmanager/getsubstitutions/) `int[] slides` paraméterrel | Kiválasztott tartományhoz, fokozatos ellenőrzéshez vagy részleges exportáláshoz szükséges helyettesítések. |

## **Betűtípus‑helyettesítési szabályok beállítása**

A forrás‑betűtípus nem elérhető esetén a használni kívánt betűtípust a következőképpen adhatja meg:

1. Töltse be a prezentációt.  
2. Hozzon létre betűtípus‑definíciókat a forrás‑ és helyettesítő betűtípusokhoz.  
3. Hozzon létre egy [FontSubstRule](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsubstrule/) elemet a [WhenInaccessible](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsubstcondition/) feltétellel.  
4. Adja hozzá a szabályt egy [FontSubstRuleCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsubstrulecollection/) gyűjteményhez.  
5. Rendelje hozzá a gyűjteményt a [FontsManager.FontSubstRuleList](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsmanager/fontsubstrulelist/) tulajdonsághoz.  
6. Renderelje vagy konvertálja a prezentációt.

Az alábbi C# példa a `Arial`‑t helyettesíti a `SomeRareFont`‑lel, ha a `SomeRareFont` nem érhető el, majd rendereli az első diát a végeredmény ellenőrzéséhez. A helyettesítő betűtípust az Aspose.Slides‑nek elérhetőnek kell lennie.

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
Egy prezentációban mindenhol alkalmazott betűtípusok feltétel nélküli módosításáért lásd a [Font Replacement](/slides/hu/net/font-replacement/) oldalt.
{{% /alert %}}

## **Korlátozások a matematikai egyenlet betűtípusokra vonatkozóan**

A betűtípus‑helyettesítési szabályok a renderelés és konvertálás során használt szabványos betűtípus‑kiválasztási folyamat részei. Rendszeres szövegre működnek, amikor az Aspose.Slides egy nem elérhető betűtípust helyettesíthet a szabály által megadott elérhető betűtípussal.

Az Office Math egyenleteknek további követelményük van. Ha egy egyenlet **Cambria Math** betűtípust használ, az Aspose.Slidesnek pontosan ezt a betűtípust kell rendelkezésre állnia az egyenlet elrendezésének kiszámításához és rendereléséhez. Egy olyan szabály, amely egy másik matematikai betűtípust, például **STIX Two Math**‑ot helyettesít, nem tudja helyettesíteni a **Cambria Math**‑ot ebben a célban, és a renderelés továbbra is jelezheti, hogy **Cambria Math** szükséges.

Az ilyen prezentáció rendereléséhez vagy konvertálásához tegye **Cambria Math**‑ot elérhetővé az Aspose.Slides számára. Telepítse a operációs rendszerbe, vagy töltse be [külső betűtípusként](/slides/hu/net/custom-font/).

Ez a korlátozás az egyenlet‑elrendezésre vonatkozik. A fent leírt helyettesítési szabályok továbbra is érvényesek a prezentáció normál szövegeire.

## **GYIK**

**Mi a különbség a betűtípus‑cserélés és a betűtípus‑helyettesítés között?**

A [Font replacement](/slides/hu/net/font-replacement/) szándékosan megváltoztat egy betűtípust egy másikra a teljes prezentációban. A betűtípus‑helyettesítés egy betűtípust választ a megjelenített kimenethez, amikor a beállított feltétel teljesül, például ha az eredeti betűtípus nem érhető el.

**Mikor alkalmazzák a helyettesítési szabályokat?**

A szabályok a [font selection sequence](/slides/hu/net/font-selection-sequence/) részét képezik renderelés és konvertálás közben. A `WhenInaccessible` esetén a szabály csak akkor használatos, amikor az Aspose.Slides nem fér hozzá a forrás‑betűtípushoz.

**Mi történik, ha egy betűtípus hiányzik, és nincs beállítva helyettesítési szabály?**

Az Aspose.Slides a legközelebbi elérhető betűtípust választja a betűtípus‑kiválasztási folyamata alapján. Az eredmény a futási környezetben elérhető betűtípusoktól függ.

**Betölthetek külső betűtípusokat a helyettesítés elkerülésére?**

Igen. Betöltheti a [külső betűtípusokat](/slides/hu/net/custom-font/), hogy az Aspose.Slides használhassa őket renderelés és konvertálás során.

**Az Aspose a betűtípusokat a könyvtárral együtt szállítja?**

Nem. A betűtípusok biztosítása és a licencfeltételek betartása a felhasználó felelőssége.

**Eltérhetnek a helyettesítési eredmények Windows, Linux és macOS között?**

Igen. A telepített betűtípusok és a betűtípus‑keresési helyek operációs rendszerenként eltérnek, ezért egy gépen elérhető betűtípus egy másikon helyettesítést igényelhet.

**Hogyan tehetem a betűtípus‑kiválasztást konzisztenssé kötegelt konverziók során?**

Használja ugyanazt a betűtófájl‑verziót minden gépen vagy konténerben, töltse be a szükséges [külső betűtípusokat](/slides/hu/net/custom-font/), és [ágyazza be a betűtípusokat](/slides/hu/net/embedded-font/), ha a licenc engedélyezi. Exportálás előtt hívhatja a [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/hu/net/aspose.slides/ifontsmanager/getsubstitutions/) metódust is, hogy azonosítsa a nem várt helyettesítéseket.