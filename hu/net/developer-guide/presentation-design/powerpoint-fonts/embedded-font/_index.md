---
title: Betűkészletek beágyazása prezentációkba .NET-ben
linktitle: Beágyazott betűkészletek
type: docs
weight: 40
url: /hu/net/embedded-font/
keywords:
- font hozzáadása
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
description: "Kezelje a beágyazott betűkészleteket PowerPointban az Aspose.Slides for .NET segítségével. Használjon C#-t a betűkészletek hozzáadására, lekérésére, eltávolítására és tömörítésére, hogy megőrizze a szöveg megjelenését és csökkentse a fájlméretet."
---
## **Bevezetés**

A betűkészletek beágyazása a betűkészlet‑adatokat egy PowerPoint‑prezentációban tárolja. Ha egy megjelenítő támogatja a beágyazott betűkészleteket, képes a szöveget azokkal a betűkészletekkel megjeleníteni, még akkor is, ha a cérrendszeren nincsenek telepítve. Ez segít megőrizni a sorok törését, a szöveg térközét és a dia elrendezését.

Aspose.Slides for .NET lehetővé teszi beágyazott betűkészletek lekérdezését, hozzáadását és eltávolítását a [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/) tulajdonságán keresztül egy [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) esetén. Emellett csökkentheti a beágyazott betűkészlet‑adatok méretét a prezentáció által nem használt karakterek eltávolításával.

Az alábbi példák PPTX fájlokkal működnek. A betűkészlet beágyazása előtt győződjön meg róla, hogy a betűkészlet adat elérhető az Aspose.Slides számára, és a licenc lehetővé teszi a beágyazást.

## **Beágyazott betűkészletek lekérdezése és eltávolítása**

Használja a [GetEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getembeddedfonts/) metódust a prezentációban tárolt betűkészletek listázásához. Egy betűkészlet eltávolításához adja át a listából származó betűkészletet a [RemoveEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/removeembeddedfont/) metódusnak, majd mentse a prezentációt.

Az alábbi példa listázza a beágyazott betűkészleteket a `EmbeddedFonts.pptx` fájlban, és eltávolítja a Calibri‑t, ha jelen van:

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

A beágyazott betűkészlet eltávolítása a tárolt betűkészlet‑adatokat törli; nem változtatja meg a szöveghez rendelt betűtípust. Ha a betűkészlet telepítve van a cérrendszeren, a szöveg továbbra is használhatja azt. Ellenkező esetben a megjelenítéshez [font substitution](/slides/hu/net/font-substitution/) lehet szükséges, ami befolyásolhatja az elrendezést.

## **Betűkészlet‑adatok és beágyazási jogosultságok ellenőrzése**

Használja az [IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/) interfészt a betűkészletek beágyazás előtti ellenőrzéséhez. Hívja meg az [IFontsManager.GetFonts](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getfonts/) metódust a prezentációban használt betűkészletek lekéréséhez. Minden betűkészlethez adjon át egy [IFontData](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/) objektumot és a szükséges [FontStyleType](https://reference.aspose.com/slides/net/aspose.slides/fontstyletype/) értéket az [IFontsManager.GetFontBytes](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getfontbytes/) metódusnak. A metódus visszaadja a betűkészlet‑stílus bináris adatait, vagy `null`‑t, ha a kért betűkészlet vagy stílus nem elérhető. Ne adjon át `null` eredményt a [IFontsManager.GetFontEmbeddingLevel](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getfontembeddinglevel/) metódusnak, mivel az byte‑tömböt vár.

Az [EmbeddingLevel](https://reference.aspose.com/slides/net/aspose.slides/embeddinglevel/) egy zászló‑enumeráció, amely a betűkészletben tárolt beágyazási korlátozásokat jelzi:

- `Installable` engedélyezi a beágyazást és a végleges telepítést egy másik rendszeren, a betűkészlet licencétől függően.
- `Restricted` megtiltja a beágyazást, kivéve ha a betűkészlet jogi tulajdonosától engedélyt kap, ha ez az egyetlen használati‑engedély zászló.
- `PreviewPrint` engedélyezi az ideiglenes használatot megtekintésre és nyomtatásra; a betűkészletet tartalmazó dokumentumnak csak olvashatónak kell lennie.
- `Editable` engedélyezi az ideiglenes használatot, és lehetővé teszi a dokumentum szerkesztését és mentését.
- `NoSubsetting` egy további korlátozás, amely megtiltja a csak egy részhalmaz beágyazását. Ha ez a zászló jelen van, az összes karaktert be kell ágyazni.
- `BitmapOnly` egy további korlátozás, amely csak bitmap‑varázlatok beágyazását engedélyezi, nem pedig vektoros adatot. Ha a betűkészletnek nincs bitmap‑varázlata, nem ágyazható be.

Az első négy érték a használati engedélyt írja le, míg a `NoSubsetting` és a `BitmapOnly` kombinálható velük. Ellenőrizze a módosítókat bitenkénti műveletekkel. Mivel a `Installable` értéke nulla, ne használja a `HasFlag`‑et a detektálásához; maszkolja a használati‑engedély biteket, és hasonlítsa össze az eredményt a `Installable`‑val. A jelenlegi betűkészleteknek legfeljebb egy használati‑engedély bitet kell beállítaniuk. A régebbi, több engedélyt is beállító betűkészletekkel való kompatibilitás érdekében az alábbi segédfüggvény a legkevésbé korlátozó engedélyt választja: `Editable`, majd `PreviewPrint`, végül `Restricted`.

Az alábbi példa ellenőrzi a `GetFonts` által visszaadott minden betűkészlethez elérhető normál, félkövér, dőlt és félkövér‑dőlt adatokat. Kihagyja a nem elérhető stílusokat, a korlátozott betűkészleteket, csak bitmap‑változatú betűkészleteket, a csak előnézethez és nyomtatáshoz korlátozott betűkészleteket, mivel a kimenet szerkeszthető marad, valamint a már beágyazott betűkészleteket. Ha bármely elérhető stílus `NoSubsetting`‑et tartalmaz, az összes karaktert beágyazza az adott betűkészlet‑családhoz.

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

Ez az ellenőrzés jelentést készít az egyes betűkészlet‑fájlokban kódolt korlátozásokról. Nem ad licencet, nem bizonyítja, hogy a betűkészletet jogszerűen szerezte be, és nem helyettesíti a betűkészlet licencszerződésének ellenőrzését a beágyazott másolat terjesztése előtt.

## **Beágyazott betűkészletek hozzáadása**

Használja az [AddEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/addembeddedfont/) metódust egy betűkészlet beágyazásához. Az általa kínált túlterhelések vagy egy [IFontData](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/) objektumot vagy egy betűkészlet‑adatokat tartalmazó byte‑tömböt fogadnak. Az [EmbedFontCharacters](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) enumeráció határozza meg, hogy mely karakterek legyenek belefoglalva:

- [All](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) beágyazza a betűkészlet összes karakterét. Ezt a beállítást akkor használja, amikor a címzetteknek szerkeszteniük kell a prezentációt és új szöveget kell beírniuk.
- [OnlyUsed](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) csak a prezentációban használt karaktereket ágyazza be, a fájlméret csökkentése érdekében. Ezt a beállítást egy kész, elsősorban megtekintésre szánt prezentáció esetén válassza.

Az alábbi példa a [GetFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getfonts/) metódust használja a `Fonts.pptx` fájlban használt betűkészletek lekéréséhez, és beágyazza azokat, amelyek még nem lettek beágyazva. A hozzáadandó betűkészleteknek elérhetőnek kell lenniük azon a gépen, amelyen a kód fut. A már létező beágyazott betűkészletek megtartják jelenlegi karakterkészletüket.

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

A [CompressEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressembeddedfonts/) a beágyazott betűkészlet‑adatokat a nem használt karakterek eltávolításával csökkenti. Már beágyazott betűkészleteken működik, ezért a méretcsökkentés a prezentációban található nem használt betűkészlet‑adat mennyiségétől függ.

Az alábbi példa tömöríti a betűkészleteket a `EmbeddedFonts.pptx` fájlban, és az eredményt külön fájlba menti:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("EmbeddedFonts.pptx");
Compress.CompressEmbeddedFonts(presentation);
presentation.Save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx);
```

Tartsa meg az eredeti fájlt, ha a címzettek később szöveget szeretnének hozzáadni. A tömörítés során eltávolított karakterek már nem állnak rendelkezésre a beágyazott betűkészletből, még akkor sem, ha eredetileg az összes karaktert beágyazta.

Ahhoz, hogy a megfelelő regisztrált betűkészlet legyen elsőbbségben az exportálás során a beágyazott betűkészlet eltávolítása nélkül, lásd a [Prefer Registered Fonts over Embedded Fonts](/slides/hu/net/font-selection-sequence/#prefer-registered-fonts-over-embedded-fonts) szakaszt (.NET 26.11 vagy újabb).

## **GYIK**

**Hogyan ellenőrizhetem, hogy egy beágyazott betűkészlet továbbra is helyettesítődik‑e a megjelenítés során?**

Hívja meg a [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getsubstitutions/) metódust abban a környezetben, ahol a prezentációt megjeleníti, hogy lásd, mely betűkészleteket cseréli le az Aspose.Slides. Emellett ellenőrizze a [font substitution](/slides/hu/net/font-substitution/) beállításokat és a [font fallback](/slides/hu/net/fallback-font/) szabályokat. A fallback a hiányzó karaktereket kezeli, így a betűkészlet beágyazása nem oldja meg azokat a karaktereket, amelyeket a betűkészlet maga nem tartalmaz.

**Érdemes gyakori betűkészleteket, például az Arial‑t vagy a Calibri‑t beágyazni?**

A döntést a célkörnyezet alapján hozza meg. Ha a szükséges betűkészletek minden olyan gépen elérhetők, amely megnyitja vagy megjeleníti a prezentációt, akkor a beágyazás felesleges fájlméretnövekedést okozhat. Ha a címzettek vagy a szerverek esetleg nem rendelkeznek ezekkel a betűkészletekkel, a beágyazás segíthet az eredeti megjelenés megtartásában, feltéve hogy a licencek megengedik.