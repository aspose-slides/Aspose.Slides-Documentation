---
title: Betűkészletek beágyazása prezentációkba .NET-ben
linktitle: Beágyazott betűkészletek
type: docs
weight: 40
url: /hu/net/embedded-font/
keywords:
- betűkészlet hozzáadása
- betűkészlet beágyazása
- betűkészlet beágyazás
- beágyazott betűkészlet lekérése
- beágyazott betűkészlet hozzáadása
- beágyazott betűkészlet eltávolítása
- beágyazott betűkészlet tömörítése
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Kezelje a beágyazott betűkészleteket a PowerPointban az Aspose.Slides for .NET segítségével. Használjon C#-ot a betűkészletek hozzáadásához, lekérdezéséhez, eltávolításához és tömörítéséhez, hogy megőrizze a szöveg megjelenését és csökkentse a fájlméretet."
---
## **Bevezetés**

A betűkészletek beágyazása betűkészlet-adatot tárol a PowerPoint‑prezentációban. Ha a megtekintő támogatja a beágyazott betűkészleteket, akkor a szöveget ezekkel a betűkkel jelenítheti meg, még akkor is, ha nincsenek telepítve a célrendszeren. Ez segít megőrizni a sortöréseket, a szövegközt és a diaelrendezést.

Az Aspose.Slides for .NET lehetővé teszi a beágyazott betűkészletek lekérdezését, hozzáadását és eltávolítását a [FontsManager](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/fontsmanager/) tulajdonságán keresztül egy [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/)-nél. A beágyazott betűkészlet‑adat méretét is csökkenthetjük azáltal, hogy eltávolítjuk a prezentáció által nem használt karaktereket.

Az alábbi példák PPTX fájlokkal működnek. A betűkészlet beágyazása előtt győződjön meg arról, hogy a betűkészlet‑adat elérhető az Aspose.Slides számára, és a licenc engedélyezi a beágyazást.

## **Beágyazott betűkészletek lekérdezése és eltávolítása**

Használja a [GetEmbeddedFonts](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsmanager/getembeddedfonts/) metódust a prezentációban tárolt betűkészletek listázásához. Egy betűkészlet eltávolításához adja át a listából egy betűt a [RemoveEmbeddedFont](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsmanager/removeembeddedfont/) metódusnak, majd mentse a prezentációt.

Az alábbi példa listázza a `EmbeddedFonts.pptx` fájlban beágyazott betűkészleteket, és eltávolítja a Calibri‑t, ha megtalálható:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("EmbeddedFonts.pptx");
var fontsManager = presentation.FontsManager;
var embeddedFonts = fontsManager.GetEmbeddedFonts();

foreach (var font in embeddedFonts)
{
    Console.WriteLine(font.FontName);
}

var fontToRemove = Array.Find(embeddedFonts, font => string.Equals(font.FontName, "Calibri", StringComparison.OrdinalIgnoreCase));
if (fontToRemove != null)
{
    fontsManager.RemoveEmbeddedFont(fontToRemove);
    presentation.Save("WithoutEmbeddedCalibri.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Calibri is not embedded. No output file was created.");
}
```

A beágyazott betűkészlet eltávolítása a tárolt betűkészlet‑adatot törli; nem változtatja meg a szöveghez rendelt betűtípust. Ha a betűkészlet telepítve van a célrendszeren, a szöveg továbbra is használhatja azt. Ellenkező esetben a rendereléshez szükség lehet a [font substitution](/slides/hu/net/font-substitution/) alkalmazására, ami befolyásolhatja a megjelenést.

## **Betűkészlet-adatok és beágyazási jogosultságok ellenőrzése**

Használja az [IFontsManager](https://reference.aspose.com/slides/hu/net/aspose.slides/ifontsmanager/) interfészt a betűkészletek beágyazása előtti vizsgálathoz. Hívja meg az [IFontsManager.GetFonts](https://reference.aspose.com/slides/hu/net/aspose.slides/ifontsmanager/getfonts/) metódust a prezentációban használt betűkészletek lekérdezéséhez. Minden betűkészletnél adjon át egy [IFontData](https://reference.aspose.com/slides/hu/net/aspose.slides/ifontdata/) objektumot és a kívánt [FontStyleType](https://reference.aspose.com/slides/hu/net/aspose.slides/fontstyletype/) értéket a [IFontsManager.GetFontBytes](https://reference.aspose.com/slides/hu/net/aspose.slides/ifontsmanager/getfontbytes/) metódusnak. A metódus a betűkészlet‑stílus bináris adatait adja vissza, vagy `null`‑t, ha a kért betű vagy stílus nem érhető el. Ne adjon át `null` eredményt a [IFontsManager.GetFontEmbeddingLevel](https://reference.aspose.com/slides/hu/net/aspose.slides/ifontsmanager/getfontembeddinglevel/) metódusnak, mivel ez egy byte‑tömböt vár.

[EmbeddingLevel](https://reference.aspose.com/slides/hu/net/aspose.slides/embeddinglevel/) egy jelző‑enumeráció, amely a betűkészletben tárolt beágyazási korlátozásokat jelzi:

- `Installable` engedélyezi a beágyazást és a betűkészlet állandó telepítését egy másik rendszerre, a betűkészlet licencének feltételei szerint.
- `Restricted` megtiltja a beágyazást, kivéve ha a betűkészlet jogtulajdonosától engedélyt kapunk, amikor ez az egyetlen használati‑jogosultság jelző.
- `PreviewPrint` átmeneti használatot engedélyez megtekintéshez és nyomtatáshoz; a betűt tartalmazó dokumentumnak csak olvasható módú kell lennie.
- `Editable` átmeneti használatot engedélyez, és a dokumentum szerkeszthető és menthető.
- `NoSubsetting` további korlátozás, amely megtiltja a betűkészlet csak egy részhalmazának beágyazását. Ha ez a jelző jelen van, az összes karaktert be kell ágyazni.
- `BitmapOnly` további korlátozás, amely csak bitmap‑sorozatok beágyazását engedélyezi, nem az outline adatokat. Ha a betűkészlet nem tartalmaz bitmap‑sorozatokat, nem ágyazható be.

Az első négy érték a használati jogot írja le, míg a `NoSubsetting` és a `BitmapOnly` kombinálható velük. A módosítókat bit‑műveletekkel kell ellenőrizni. Mivel az `Installable` értéke nulla, ne használja a `HasFlag`‑et a detektálásához; maszkolja a használati‑jogosultsági biteket, és hasonlítsa össze az eredményt az `Installable`‑el. Az aktuális betűkészletek legfeljebb egy használati‑jogosultsági bitet állítanak be. Az régebbi betűkészletek, amelyek egynél több bitet állítanak be, a lenti segédfüggvény a legkevésbé korlátozó jogosultságot választja: `Editable`, majd `PreviewPrint`, majd `Restricted`.

Az alábbi példa ellenőrzi a `GetFonts` által visszaadott minden betűkészlethez elérhető normál, félkövér, dőlt és félkövér‑dőlt adatokat. Kihagyja a nem elérhető stílusokat, a korlátozott betűkészleteket, a csak bitmap‑betűket, a csak előnézet‑és‑nyomtatás‑célú betűket, mivel a kimenet szerkeszthető marad, valamint a már beágyazott betűkészleteket. Ha bármely elérhető stílus `NoSubsetting`‑et tartalmaz, az összes karaktert beágyazza az adott betűcsaládhoz.

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

static EmbeddingLevel GetUsagePermission(EmbeddingLevel level)
{
    const EmbeddingLevel permissionMask = EmbeddingLevel.Restricted | EmbeddingLevel.PreviewPrint | EmbeddingLevel.Editable;
    var permissions = level & permissionMask;

    if ((permissions & EmbeddingLevel.Editable) != 0)
    {
        return EmbeddingLevel.Editable;
    }

    if ((permissions & EmbeddingLevel.PreviewPrint) != 0)
    {
        return EmbeddingLevel.PreviewPrint;
    }

    if ((permissions & EmbeddingLevel.Restricted) != 0)
    {
        return EmbeddingLevel.Restricted;
    }

    return EmbeddingLevel.Installable;
}

using var presentation = new Presentation("Fonts.pptx");
var fontsManager = presentation.FontsManager;
var fontStyles = new[]
{
    FontStyleType.Regular,
    FontStyleType.Bold,
    FontStyleType.Italic,
    FontStyleType.Bold | FontStyleType.Italic
};

var embeddedFontNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
foreach (var embeddedFont in fontsManager.GetEmbeddedFonts())
{
    embeddedFontNames.Add(embeddedFont.FontName);
}

var embeddingPlan = new List<(IFontData Font, EmbedFontCharacters Rule)>();
foreach (var font in fontsManager.GetFonts())
{
    if (embeddedFontNames.Contains(font.FontName))
    {
        Console.WriteLine($"{font.FontName}: already embedded.");
        continue;
    }

    var hasAvailableData = false;
    var allAvailableStylesCanBeEmbedded = true;
    var previewPrintOnly = false;
    var requiresFullFont = false;

    foreach (var fontStyle in fontStyles)
    {
        var fontBytes = fontsManager.GetFontBytes(font, fontStyle);
        if (fontBytes == null)
        {
            Console.WriteLine($"{font.FontName} ({fontStyle}): font data is unavailable.");
            continue;
        }

        hasAvailableData = true;
        var embeddingLevel = fontsManager.GetFontEmbeddingLevel(fontBytes, font.FontName);
        var usagePermission = GetUsagePermission(embeddingLevel);
        var noSubsetting = (embeddingLevel & EmbeddingLevel.NoSubsetting) != 0;
        var bitmapOnly = (embeddingLevel & EmbeddingLevel.BitmapOnly) != 0;

        requiresFullFont |= noSubsetting;
        previewPrintOnly |= usagePermission == EmbeddingLevel.PreviewPrint;
        allAvailableStylesCanBeEmbedded &= usagePermission != EmbeddingLevel.Restricted && !bitmapOnly;

        Console.WriteLine($"{font.FontName} ({fontStyle}): {embeddingLevel}.");
    }

    if (!hasAvailableData)
    {
        Console.WriteLine($"{font.FontName}: skipped because no requested style is available.");
    }
    else if (!allAvailableStylesCanBeEmbedded)
    {
        Console.WriteLine($"{font.FontName}: skipped because at least one available style does not permit outline embedding.");
    }
    else if (previewPrintOnly)
    {
        Console.WriteLine($"{font.FontName}: skipped because this example produces an editable presentation.");
    }
    else
    {
        var rule = requiresFullFont ? EmbedFontCharacters.All : EmbedFontCharacters.OnlyUsed;
        embeddingPlan.Add((font, rule));
    }
}

foreach (var item in embeddingPlan)
{
    fontsManager.AddEmbeddedFont(item.Font, item.Rule);
}

presentation.Save("WithAuditedFonts.pptx", SaveFormat.Pptx);
```

Ez a vizsgálat jelentést készít a betűkészlet‑fájlokban kódolt korlátozásokról. Nem ad licencet, nem bizonyítja, hogy a betűkészletet jogszerűen szerezte be, és nem helyettesíti a betűkészlet licencszerződésének ellenőrzését a beágyazott másolat terjesztése előtt.

## **Beágyazott betűkészletek hozzáadása**

Használja a [AddEmbeddedFont](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsmanager/addembeddedfont/) metódust betűkészlet beágyazásához. A túlterhelések vagy egy [IFontData](https://reference.aspose.com/slides/hu/net/aspose.slides/ifontdata/) objektumot, vagy egy byte‑tömböt várnak, amely a betűkészlet‑adatot tartalmazza. Az [EmbedFontCharacters](https://reference.aspose.com/slides/hu/net/aspose.slides.export/embedfontcharacters/) enumeráció szabályozza, hogy mely karakterek legyenek belefoglalva:

- [All](https://reference.aspose.com/slides/hu/net/aspose.slides.export/embedfontcharacters/) az összes karaktert beágyazza a betűkészletből. Ezt a lehetőséget akkor válassza, ha a címzetteknek szerkeszteniük kell a prezentációt és új szöveget beírni.
- [OnlyUsed](https://reference.aspose.com/slides/hu/net/aspose.slides.export/embedfontcharacters/) csak a prezentációban használt karaktereket ágyazza be a fájlméret csökkentése érdekében. Válassza ezt a befejezett, főként megtekintésre szánt prezentációk esetén.

Az alábbi példa a [GetFonts](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsmanager/getfonts/) metódussal lekéri a `Fonts.pptx` fájlban használt betűkészleteket, és beágyazza azokat, amelyek még nincsenek beágyazva. A hozzáadandó betűkészleteknek elérhetőnek kell lenniük a kódot futtató gépen. A már létező beágyazott betűkészletek megtartják a jelenlegi karakterkészletüket.

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Fonts.pptx");
var fontsManager = presentation.FontsManager;
var allFonts = fontsManager.GetFonts();
var embeddedFonts = fontsManager.GetEmbeddedFonts();
var embeddedFontNames = embeddedFonts.Select(font => font.FontName);
var embeddedNames = new HashSet<string>(embeddedFontNames, StringComparer.OrdinalIgnoreCase);

foreach (var font in allFonts)
{
    if (!embeddedNames.Contains(font.FontName))
    {
        fontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);
        embeddedNames.Add(font.FontName);
    }
}

presentation.Save("WithEmbeddedFonts.pptx", SaveFormat.Pptx);
```

## **Beágyazott betűkészletek tömörítése**

A [CompressEmbeddedFonts](https://reference.aspose.com/slides/hu/net/aspose.slides.lowcode/compress/compressembeddedfonts/) csökkenti a beágyazott betűkészlet‑adat méretét a nem használt karakterek eltávolításával. Már beágyazott betűkészleteken dolgozik, így a méretcsökkentés attól függ, mennyi felesleges betűkészlet‑adatot tartalmaz a prezentáció.

Az alábbi példa tömöríti a `EmbeddedFonts.pptx` fájl betűkészleteit, és a végeredményt külön fájlként menti:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("EmbeddedFonts.pptx");
Compress.CompressEmbeddedFonts(presentation);
presentation.Save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx);
```

Tartsa meg az eredeti fájlt, ha a címzettek később szöveget szeretnének hozzáadni. A tömörítés során eltávolított karakterek már nem érhetők el a beágyazott betűkészletből, még akkor sem, ha eleinte minden karaktert beágyazott.

## **GYIK**

**Hogyan ellenőrizhetem, hogy egy beágyazott betűkészlet továbbra is helyettesítésre kerül-e a renderelés során?**

Hívja meg a [GetSubstitutions](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsmanager/getsubstitutions/) metódust abban a környezetben, ahol a prezentációt rendereli, hogy megtudja, mely betűkészleteket fogja az Aspose.Slides helyettesíteni. Ellenőrizze továbbá a [font substitution](/slides/hu/net/font-substitution/) beállításokat és a [font fallback](/slides/hu/net/fallback-font/) szabályokat. A fallback a hiányzó karaktereket kezeli, ezért egy betűkészlet beágyazása nem old meg minden olyan karaktert, amelyet a betűkészlet maga sem tartalmaz.

**Érdemes-e általános betűkészleteket, például az Arial‑t és a Calibri‑t beágyazni?**

A döntést a célkörnyezet alapján hozza. Ha a szükséges betűkészletek minden gépen elérhetők, amely megnyitja vagy rendereli a prezentációt, a beágyazás felesleges fájlméret-növekedést okozhat. Ha a címzettek vagy szerverek esetleg nem rendelkeznek ezekkel a betűkészletekkel, a beágyazás segíthet megőrizni a kívánt megjelenést, feltéve hogy a licencük engedélyezi azt.