---
title: ".NET-ben a bemutatók betűtípus‑helyettesítésének konfigurálása"
linktitle: "Betűtípus‑helyettesítés"
type: docs
weight: 70
url: /hu/net/font-substitution/
keywords:
- betűtípus
- helyettesítő betűtípus
- betűtípus‑helyettesítés
- betűtípus cseréje
- betűtípus‑csere
- helyettesítési szabály
- csereszabály
- PowerPoint
- OpenDocument
- bemutató
- .NET
- C#
- Aspose.Slides
description: "Állítsa be a betűtípus‑helyettesítési szabályokat, és ellenőrizze a helyettesített betűtípusokat az Aspose.Slides for .NET‑ben PowerPoint és OpenDocument bemutatók renderelése vagy konvertálása során."
---
## **Áttekintés**

A betűtípus‑helyettesítés lehetővé teszi az Aspose.Slides számára, hogy elérhető betűtípust használjon egy olyan betűtípus helyett, amelyet a bemutató renderelése vagy konvertálása során nem lehet elérni. A helyettesítés a megjelenített kimenetet érinti; nem módosítja a bemutató tartalmához rendelt betűtípust.

Meghatározhatja a használni kívánt betűtípust, ha egy adott betűtípus nem érhető el, és ellenőrizheti a Aspose.Slides által a renderelés során végrehajtott helyettesítéseket. Ez segít a kimenetet konzisztenssé tenni különböző, eltérő betűtípusokkal rendelkező környezetekben.

Ha egy betűtípus elérhető, de nincs dedikált félkövér változata, lásd [A betűtípusok kezelése, ha nincs dedikált félkövér változat](/slides/hu/net/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Az a szakasz elmagyarázza, hogyan lehet rasterizálni az érintett szöveget a PDF exportálása során, valamint a szöveg kijelölésére, keresésére és méretezésére gyakorolt hatásokat.

## **Betűtípus helyettesítések lekérése**

Használja az [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) metódust annak meghatározásához, hogy mely betűtípusok lesznek helyettesítve a bemutató renderelésekor. A metódus [FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/) objektumokat ad vissza, amelyek az eredeti és a helyettesített betűtípusok neveit tartalmazzák.

A következő C# példa felsorolja a bemutató összes betűtípus‑helyettesítését:
```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}
```

## **Kijelölt diák betűtípus‑helyettesítéseinek lekérése**

Használja az [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) túlterhelést `int[] slides` argumentummal, hogy csak a konkrét diák rendereléséhez szükséges helyettesítéseket ellenőrizze. Ez akkor hasznos, amikor a bemutató egy részét rendereli vagy exportálja, nagy bemutatót fokozatosan ellenőriz, olyan diákot keres, amelyek nem elérhető betűtípusoktól függenek, minimális betűtípuskészletet készít szerver vagy tároló számára, vagy renderelési eltéréseket diagnosztizál anélkül, hogy a nem releváns diákok feldolgozására kerülne sor.

A `slides` tömb egy‑alapú (1‑től) diákindexeket tartalmaz: `1` a első diát jelöli. Ezzel szemben a [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) gyűjtemény indexelése nullától indul, így ugyanaz a dia `presentation.Slides[0]`‑ként érhető el. Ezt a különbséget tartsa szem előtt a tömb felépítésekor, hogy elkerülje az egy‑off‑by‑one hibákat.

Hívja meg a túlterhelést a [Presentation.FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/) tulajdonságon keresztül. Csak a kiválasztott diák renderelése során meghatározott helyettesítéseket adja vissza. Minden eredmény egy [FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/) objektum, amely tartalmazza az eredeti és a helyettesített betűtípusok neveit. Az eredmény tükrözi a jelenlegi betűtípus‑környezetet és a [külsőleg betöltött betűtípusokat](/slides/hu/net/custom-font/). Az [IFontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/ifontsubstrulecollection/)‑ben tárolt helyettesítési szabályok megváltoztatják a renderelt kimenetet, de az eredményben nem jelennek meg.

Hasonló helyettesítés több mint egy kiválasztott dián is szükséges lehet. Távolítsa el a duplikátumokat az eredményekből, amikor betűtípus‑készletet vagy előellenőrző jelentést készít. A következő példa minden visszaadott helyettesítést jelent, majd egy rendezett listát hoz létre az egyedi betűtípus‑leképezésekről:
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

Az [IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/) interfész mindkét túlterhelést biztosítja. Válassza ki a megfelelőet a renderelési művelet hatókörének megfelelően:

| Túlterhelés | Használja, ha |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) with no arguments | Ha a teljes bemutatóhoz szeretne helyettesítéseket. |
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) with `int[] slides` | Ha egy kiválasztott tartományhoz, fokozatos ellenőrzéshez vagy részleges exportáláshoz szeretne helyettesítéseket. |

## **Betűtípus‑helyettesítési szabályok beállítása**

A betűtípus megadásához, amelyet az Aspose.Slides akkor használjon, amikor a forrás betűtípus nem érhető el:
1. Töltse be a bemutatót.
2. Hozzon létre betűtípus‑definíciókat a forrás- és helyettesítő betűtípusokhoz.
3. Hozzon létre egy [FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) elemet a [WhenInaccessible](https://reference.aspose.com/slides/net/aspose.slides/fontsubstcondition/) feltétellel.
4. Adja hozzá a szabályt egy [FontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrulecollection/) gyűjteményhez.
5. Rendelje a gyűjteményt a [FontsManager.FontSubstRuleList](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/fontsubstrulelist/) tulajdonsághoz.
6. Renderelje vagy konvertálja a bemutatót.

A következő C# példa `Arial`‑t helyettesít a `SomeRareFont` helyett, amikor a `SomeRareFont` nem érhető el, és ezután rendereli az első diát az eredmény ellenőrzéséhez. A helyettesítő betűtípust az Aspose.Slides‑nek elérhetőnek kell lennie.
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
Feltétel nélküli módosításhoz a teljes bemutatóban használt betűtípusok esetén, lásd a [Betűtípus-cserék](/slides/hu/net/font-replacement/) oldalt.
{{% /alert %}}

## **A matematikai egyenlet betűtípusokra vonatkozó korlátozások**

A betűtípus‑helyettesítési szabályok a renderelés és konverzió során használt szabványos betűtípus‑kiválasztási folyamat részei. Rendszeres szövegnél működnek, ha az Aspose.Slides egy nem elérhető betűtípust a szabály által meghatározott elérhető betűtípussal helyettesíti.

Az Office Math egyenleteknek további követelményük van. Ha egy egyenlet **Cambria Math** betűtípust használ, az Aspose.Slides pontosan ezt a betűtípust igényelheti az egyenlet elrendezésének kiszámításához és rendereléséhez. Egy másik matematikai betűtípust, például **STIX Two Math**, helyettesítő szabály nem helyettesítheti a **Cambria Math**‑ot ebben a célban, és a renderelés továbbra is azt jelezheti, hogy **Cambria Math** szükséges.

Az ilyen bemutató rendereléséhez vagy konvertálásához tegye elérhetővé a **Cambria Math** betűtípust az Aspose.Slides számára. Telepítse a operációs rendszerben, vagy töltse be [külső betűtípusként](/slides/hu/net/custom-font/).

Ez a korlátozás az egyenletelrendezésre vonatkozik. A fent leírt helyettesítési szabályok továbbra is érvényesek a bemutató normál szövegére.

## **GYIK**

**Mi a különbség a betűtípus‑csere és a betűtípus‑helyettesítés között?**

[Betűtípus‑csere](/slides/hu/net/font-replacement/) szándékosan megváltoztat egy betűtípust egy másikra az egész bemutatóban. A betűtípus‑helyettesítés egy betűtípust választ a renderelt kimenethez, amikor a konfigurált feltétel teljesül, például amikor az eredeti betűtípus nem érhető el.

**Mikor alkalmazzák a helyettesítési szabályokat?**

A szabályok részt vesznek a [betűtípus‑kiválasztási sorrendben](/slides/hu/net/font-selection-sequence/) a renderelés és konverzió során. A `WhenInaccessible` esetén a szabály csak akkor használatos, amikor az Aspose.Slides nem tudja elérni a forrás betűtípust.

**Mi történik, ha egy betűtípus hiányzik, és nincs konfigurálva helyettesítési szabály?**

Az Aspose.Slides a legközelebbi elérhető betűtípust választja a betűtípus‑kiválasztási folyamata alapján. Az eredmény a futási környezetben elérhető betűtípusoktól függ.

**Betölthetek külső betűtípusokat a helyettesítés elkerüléséhez?**

Igen. [Külső betűtípusok betöltésével](/slides/hu/net/custom-font/) az Aspose.Slides renderelés és konverzió során használhatja őket.

**Az Aspose terjeszti a betűtípusokat a könyvtárral együtt?**

Nem. Ön felelős a betűtípusok biztosításáért és a licencük betartásáért.

**Eltérhetnek a helyettesítési eredmények Windows, Linux és macOS között?**

Igen. A telepített betűtípusok és a betűtípus‑keresési helyek operációs rendszerenként eltérnek, így egy gépen elérhető betűtípus egy másikon helyettesítést igényelhet.

**Hogyan tehetem a betűtípus‑kiválasztást konzisztenssé kötegelt konverziók esetén?**

Használja ugyanazokat a betűtípus‑fájlokat és verziókat minden gépen vagy tárolóban, [szükséges külső betűtípusok betöltésével](/slides/hu/net/custom-font/) és [betűtípusok beágyazásával](/slides/hu/net/embedded-font/) a licenc megengedése esetén. Emellett meghívhatja az [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) metódust exportálás előtt, hogy azonosítsa a váratlan helyettesítéseket.