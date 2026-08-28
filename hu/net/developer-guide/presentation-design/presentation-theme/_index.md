---
title: Prezentációs témák kezelése .NET-ben
linktitle: Prezentációs téma
type: docs
weight: 10
url: /hu/net/presentation-theme/
keywords:
- PowerPoint téma
- prezentációs téma
- dia téma
- téma beállítása
- téma módosítása
- téma kezelése
- külső téma
- THMX
- téma szín
- kiegészítő paletta
- téma betűtípus
- téma stílus
- téma effektus
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Az Aspose.Slides for .NET fő prezentációs témái lehetővé teszik PowerPoint fájlok egységes márkajelzéssel történő létrehozását, testreszabását és konvertálását."
---
## **Bevezetés**

Egy prezentációs téma meghatároz egy koordinált szín-, betűtípus-, háttérstílus-, kitöltés-, vonal- és effektuskészletet. A témaközönséges objektumok ezekre a megosztott definíciókra hivatkoznak, ahelyett, hogy minden vizuális tulajdonságot rögzített értékként tárolnának, így egy téma módosítása egyszerre sok objektumot frissíthet.

Aspose.Slides esetén a prezentációszintű téma a [Presentation.MasterTheme](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/mastertheme/) tulajdonságon keresztül érhető el. A prezentáció alacsonyabb szinteken is tartalmazhat téma‑felülírásokat. A mester felülírhatja a prezentáció témáját a [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/masterthememanager/overridetheme/) segítségével, egy elrendezés felülírhatja az örökölt témát a [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/baseoverridethememanager/overridetheme/) segítségével, és egy egyedi dia is ugyanezt teheti. Gyakorlatban egy dia hatékony témája az öröklődési lánc mentén kerül feloldásra: prezentációs téma, mester‑felülírás, elrendezés‑felülírás és dia‑felülírás.

![Témaelemek: színek, betűkészletek, háttérstílusok és effektusok](theme-constituents.png)

Az alábbi szakaszok bemutatják a leggyakoribb téma‑munkafolyamatokat: téma ellenőrzése, színek és betűkészletek módosítása, téma másolása vagy alkalmazása, háttér‑ és effektusstílusok frissítése, valamint a hatékony értékek kiolvasása az öröklődés és felülírások feloldása után.

## **Téma ellenőrzése**

A [MasterTheme](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/mastertheme/) objektum a téma [ColorScheme](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/mastertheme/colorscheme/), [FontScheme](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/mastertheme/fontscheme/) és [FormatScheme](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/mastertheme/formatscheme/) definícióit teszi elérhetővé. Ezeknek a gyűjteményeknek az ellenőrzése a módosítás előtt különösen hasznos, ha a prezentáció külső forrásból származik, mivel a stílusbejegyzések száma és tartalma változhat.

Az alábbi példa beolvassa a fő téma‑tulajdonságokat, és jelentést készít arról, hány háttér‑, kitöltés‑, vonal‑ és effektusstílus van tárolva a témában:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var theme = presentation.MasterTheme;

Console.WriteLine($"Theme name: {theme.Name}");
Console.WriteLine($"Accent 1: {theme.ColorScheme.Accent1.Color}");
Console.WriteLine($"Major Latin font: {theme.FontScheme.Major.LatinFont.FontName}");
Console.WriteLine($"Minor Latin font: {theme.FontScheme.Minor.LatinFont.FontName}");
Console.WriteLine($"Background fill styles: {theme.FormatScheme.BackgroundFillStyles.Count}");
Console.WriteLine($"Fill styles: {theme.FormatScheme.FillStyles.Count}");
Console.WriteLine($"Line styles: {theme.FormatScheme.LineStyles.Count}");
Console.WriteLine($"Effect styles: {theme.FormatScheme.EffectStyles.Count}");
```

Ha egy fájl több mestert használ, ne feltételezzük, hogy minden dia ugyanazzal a hatékony témával rendelkezik. Ellenőrizzük a diával kapcsolatos mestert, és a későbbiekben bemutatott hatékony‑téma munkafolyamatot használjuk, ha elrendezés‑ vagy dia‑felülírások is jelen lehetnek.

## **Téma színeinek módosítása**

A témaközönséges kitöltések, vonalak és szöveg hivatkozhat egy logikai színre a [SchemeColor](https://reference.aspose.com/slides/hu/net/aspose.slides/schemecolor/) felsorolásból. Ha módosítjuk a megfelelő bejegyzést a téma [IColorScheme](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/icolorscheme/) objektumában, minden olyan objektum, amely még mindig erre a téma‑színre hivatkozik, az új érték szerint kerül feloldásra. Azok az objektumok, amelyek közvetlen RGB‑színt használnak, nem változnak a téma‑szín frissítésekor.

Az alábbi vég‑vég példában létrehozunk egy alakzatot, amely az `Accent4`‑et használja, megváltoztatjuk a téma `Accent4` színét pirosra, mentjük a prezentációt, újra megnyitjuk, és kiíratjuk a hatékony kitöltési színt:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
presentation.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
presentation.Save("theme-color.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("theme-color.pptx");
var savedSlide = savedPresentation.Slides[0];
var savedShape = savedSlide.Shapes[0];
var effectiveFill = savedShape.FillFormat.GetEffective();
Console.WriteLine($"Effective fill color: {effectiveFill.SolidFillColor}");
```

Mivel a téglalap továbbra is az `Accent4`‑hez kapcsolódik, a látható színe piros lesz a téma módosítása után. Ha a sémaszínt közvetlen színre cseréljük az alakzaton, a későbbi `Accent4`‑változások már nem befolyásolják azt a kitöltést.

### **Kiegészítő paletta színeinek használata**

A PowerPoint világosabb és sötétebb változatokat állít elő egy téma‑színből színtranszformációk alkalmazásával. Az Aspose.Slides ezeket a transzformációkat a [ColorTransformOperation](https://reference.aspose.com/slides/hu/net/aspose.slides/colortransformoperation/) segítségével teszi elérhetővé.

![Az alapvető téma színek és a kiegészítő palettából generált világosabb és sötétebb színek](additional-palette-colors.png)

**1** – Alapvető téma színek.

**2** – A fő téma színekből előállított világosabb és sötétebb változatok.

Az alábbi példa hat téglalapot hoz létre az `Accent4`‑ből kiindulva, ötön luminancia‑transzformációt alkalmaz, és menti az eredményt:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);
shape1.FillFormat.FillType = FillType.Solid;
shape1.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);
shape2.FillFormat.FillType = FillType.Solid;
shape2.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.2f);
shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.8f);

var shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);
shape3.FillFormat.FillType = FillType.Solid;
shape3.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.4f);
shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.6f);

var shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);
shape4.FillFormat.FillType = FillType.Solid;
shape4.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.6f);
shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.4f);

var shape5 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);
shape5.FillFormat.FillType = FillType.Solid;
shape5.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape5.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.75f);

var shape6 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);
shape6.FillFormat.FillType = FillType.Solid;
shape6.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape6.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.5f);

presentation.Save("theme-color-palette.pptx", SaveFormat.Pptx);
```

Ezek a változatok továbbra is a téma‑színen alapulnak. Ha az `Accent4` később megváltozik, a transzformált színek újra lesznek számítva az új `Accent4` értékből.

### **`SchemeColor` értékek leképezése `IColorScheme` slotokra**

A [SchemeColor](https://reference.aspose.com/slides/hu/net/aspose.slides/schemecolor/) felsorolás a `Text1`, `Background1`, `Text2` és `Background2` slotokat használja, míg az [IColorScheme](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/icolorscheme/) a témaslotokat `Dark1`, `Light1`, `Dark2` és `Light2` néven teszi közzé. A leképezés rögzített:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Ezek ugyanazoknak a téma‑slotoknak alternatív nevei; nem dinamikusan átalakított értékek.

## **Téma betűkészleteinek módosítása**

A téma betűkészlet egy fő betűkészletet tartalmaz a címsorokhoz és egy alárendelt betűkészletet a törzsszöveghez. A [FontScheme.Major](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/fontscheme/major/) és a [FontScheme.Minor](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/fontscheme/minor/) tulajdonságok ezeket a készleteket exponálják.

PowerPoint‑kompatibilis téma‑betűazonosítók használhatók a szövegformázásban:

* `+mn-lt` – Testípus latin (Minor Latin Font)
* `+mj-lt` – Címsor latin (Major Latin Font)
* `+mn-ea` – Testípus kelet-ázsiai (Minor East Asian Font)
* `+mj-ea` – Címsor kelet-ázsiai (Major East Asian Font)

Az alábbi példa létrehoz egy címsort, amely a fő latin téma‑betűtípust használja, valamint egy törzssort, amely az alárendelt latin téma‑betűtípust használja. Ezután megváltoztatja a téma‑betűket és menti az eredményt:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var heading = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 60);
heading.TextFrame.Text = "Theme heading";
heading.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("+mj-lt");

var body = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 120, 500, 60);
body.TextFrame.Text = "Theme body text";
body.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("+mn-lt");

presentation.MasterTheme.FontScheme.Major.LatinFont = new FontData("Aptos Display");
presentation.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");

presentation.Save("theme-fonts.pptx", SaveFormat.Pptx);
```

A címsor a fő betűtípust követi, a törzsszöveg az alárendelt betűtípust. A kifejezetten betűnevet tartalmazó szöveg nem vált automatikusan, ha a téma‑betűkészlet változik.

A fő és alárendelt betűkészlet tartalmazhat betűtérképeket egyedi írásrendszerekhez, például cirill, arab, japán, grúz és thaana. Ezeknek a lekérdezéséhez, hozzáadásához, cseréjéhez vagy eltávolításához lásd a [Script‑Specific Theme Fonts](/slides/hu/net/script-specific-font-mappings/) oldalt.

{{% alert color="info" title="Tip" %}}
További információ a prezentáció‑betűkről: lásd a [PowerPoint betűk](/slides/hu/net/powerpoint-fonts/).
{{% /alert %}}

## **Téma másolása vagy alkalmazása**

Az alábbi munkafolyamatok különböző téma‑kapcsolódó problémákat oldanak meg.

### **Külső téma alkalmazása a mesterhez kapcsolódó diákra**

Használd a [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/hu/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) módszert, ha van egy PowerPoint téma‑fájlod (`.thmx`), és minden, egy adott mesterhez kapcsolódó diát új stílusba szeretnél helyezni. Válaszd ki a mestert a [Presentation.Masters](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/masters/) gyűjteményből, amely a [IMasterSlideCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/imasterslidecollection/) interfészt valósítja meg, majd add át a téma‑fájl elérési útját a metódusnak.

A metódus a következő lépéseket hajtja végre:

1. Létrehoz egy új mester‑diát a kiválasztott mester alapján.
2. Alkalmazza a külső témát az új mesterre.
3. Hozzárendeli az új mestert minden, korábban a kiválasztott mesterhez tartozó diához.
4. Visszaadja az újonnan létrehozott [IMasterSlide](https://reference.aspose.com/slides/hu/net/aspose.slides/imasterslide/) objektumot.

Az alábbi példa külső témát alkalmaz az első mesterhez tartozó diákra, menti a prezentációt, majd újra megnyitja az eredményt:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var selectedMaster = presentation.Masters[0];
var themedMaster = selectedMaster.ApplyExternalThemeToDependingSlides("corporate-theme.thmx");

Console.WriteLine($"Created master: {themedMaster.Name}");
presentation.Save("presentation-with-external-theme.pptx", SaveFormat.Pptx);
```

Érvénytelen, sérült vagy nem támogatott téma [PptxException](https://reference.aspose.com/slides/hu/net/aspose.slides/pptxexception/) vagy annak formátum‑specifikus alosztályait okozhatja. Érvényesítsd a felhasználók által megadott útvonalakat, kezeld a fájlrendszeri hozzáférési hibákat, és csak akkor mentsd a prezentációt, ha a téma sikeresen alkalmazva lett.

Csak a kiválasztott mesterhez tartozó diák kerülnek átállításra. Más mesterekhez tartozó diák megtartják a meglévő mestereiket és témáikat. A téma‑tudatos színek, betűk, kitöltések, vonalak, háttérstílusok és effektusok a külső téma alapján kerülnek feloldásra. A közvetlenül hozzárendelt színek, betűk, kitöltések és egyéb explicit formázások változatlanok maradhatnak. Az elrendezés‑ és dia‑szintű felülírások szintén felülbírálhatják az új mesterből örökölt értékeket.

A téma hivatkozhat olyan betűkre, amelyek nincs telepítve a futtatási környezetben. A következetes megjelenítés és export érdekében telepítsd a szükséges betűket, biztosítsd őket a [custom font sources](/slides/hu/net/custom-font/) segítségével, vagy konfiguráld a [font substitution](/slides/hu/net/font-substitution/) beállítást.

Ez egy közvetlen mester‑szintű munkafolyamat: a metódus egy `.thmx` fájl elérési útját várja, és nem igényel manuális diával vagy elrendezéssel kapcsolatos téma‑felülírások létrehozását.

### **Különböző külső témák alkalmazása több‑mesteres prezentációban**

Ha a megfelelő mestert nem lehet előre tudni, szerezd be egy reprezentatív dia segítségével a [ISlide.LayoutSlide](https://reference.aspose.com/slides/hu/net/aspose.slides/islide/layoutslide/) és a [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/hu/net/aspose.slides/ilayoutslide/masterslide/) segítségével. Tárold el az eredeti mester‑referenciákat a témaalkalmazások előtt, mert minden hívás új mestert hoz létre a prezentációban.

Az alábbi példa két szakasz diáit használja, meghatározza a mestereiket, és mindkét csoportnak más‑más külső témát alkalmaz:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("multi-master-presentation.pptx");

if (presentation.Slides.Count < 5)
{
    Console.WriteLine("The presentation does not contain the expected representative slides.");
}
else
{
    var firstGroupMaster = presentation.Slides[0].LayoutSlide.MasterSlide;
    var secondGroupMaster = presentation.Slides[4].LayoutSlide.MasterSlide;

    if (ReferenceEquals(firstGroupMaster, secondGroupMaster))
    {
        Console.WriteLine("The representative slides use the same master.");
    }
    else
    {
        var firstThemedMaster = firstGroupMaster.ApplyExternalThemeToDependingSlides("blue-theme.thmx");
        var secondThemedMaster = secondGroupMaster.ApplyExternalThemeToDependingSlides("green-theme.thmx");

        Console.WriteLine($"First themed master: {firstThemedMaster.Name}");
        Console.WriteLine($"Second themed master: {secondThemedMaster.Name}");
        presentation.Save("multi-master-with-external-themes.pptx", SaveFormat.Pptx);
    }
}
```

Az első hívás csak a `firstGroupMaster`‑hez tartozó diákra hat, a második csak a `secondGroupMaster`‑hez tartozó diákra. A másik mesterekhez tartozó diákok nem kapnak új stílust.

### **Forrástéma megőrzése diák áthelyezésekor**

Ha egy diát egy másik prezentációba szeretnél áthelyezni, miközben megőrzöd az eredeti megjelenését, klónozd a forrás‑mestert a célnak megfelelő prezentációba a [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/hu/net/aspose.slides/imasterslidecollection/addclone/) segítségével, majd klónozd a diát a [ISlideCollection.AddClone](https://reference.aspose.com/slides/hu/net/aspose.slides/islidecollection/addclone/) és a klónozott mesterrel. Így a mester, annak elrendezései és a kapcsolódó téma együtt kerül átvitelre.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var sourceSlide = source.Slides[0];
var sourceMaster = sourceSlide.LayoutSlide.MasterSlide;
var clonedMaster = target.Masters.AddClone(sourceMaster);
target.Slides.AddClone(sourceSlide, clonedMaster, true);

target.Save("theme-preserved.pptx", SaveFormat.Pptx);
```

Ez a leginkább ajánlott megközelítés, amikor a forrásdia megjelenésének változatlansága kritikus a célhelyen. A csak tartalom klónozása egy nem kapcsolódó cél‑mesterre megváltoztathatja a téma‑alapú színeket, betűket, háttérstílusokat és effektusokat.

### **Témaértékek alkalmazása egy létező diára**

Ha a cél‑dia a jelenlegi mesterén és elrendezésén marad, inicializálj egy dia‑szintű felülírást a forrástémából. A [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/overridetheme/initfontschemefrom/) és [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/overridetheme/initformatschemefrom/) metódusok a három fő témaelemet átmásolják a felülírásba.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var targetSlide = target.Slides[0];
var overrideTheme = targetSlide.ThemeManager.OverrideTheme;
overrideTheme.InitColorSchemeFrom(source.MasterTheme.ColorScheme);
overrideTheme.InitFontSchemeFrom(source.MasterTheme.FontScheme);
overrideTheme.InitFormatSchemeFrom(source.MasterTheme.FormatScheme);

target.Save("theme-applied-to-slide.pptx", SaveFormat.Pptx);
```

Ez megváltoztatja a diára vonatkozó témát anélkül, hogy a többi dia örökölt témáját módosítaná. A helyi felülírás eltávolításához és az örökölt értékek visszaállításához hívd meg az [OverrideTheme.Clear](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/overridetheme/clear/) metódust.

### **Téma felülírás alkalmazása egy elrendezésre**

Az elrendezés‑szintű felülírás az arra épülő diákra hat, kivéve, ha egy adott dia saját felülírással rendelkezik. Az ugyanazok a inicializáló metódusok használhatók az elrendezés [LayoutSlideThemeManager](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/layoutslidethememanager/) objektumán keresztül:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var targetLayout = target.Slides[0].LayoutSlide;
var overrideTheme = targetLayout.ThemeManager.OverrideTheme;
overrideTheme.InitColorSchemeFrom(source.MasterTheme.ColorScheme);
overrideTheme.InitFontSchemeFrom(source.MasterTheme.FontScheme);
overrideTheme.InitFormatSchemeFrom(source.MasterTheme.FormatScheme);

target.Save("theme-applied-to-layout.pptx", SaveFormat.Pptx);
```

Használj mester‑ vagy prezentáció‑szintű témát, ha sok elrendezésnek és diának közös alapszerkezetet kell megosztania, elrendezés‑felülírást, ha egy elrendezéscsaládnál eltérő stílusra van szükség, és dia‑felülírást csak valódi kivételekhez. A túlzott dia‑szintű felülírások megnehezítik a későbbi globális téma‑változtatások előrejelzését.

## **A téma háttérstílusok frissítése**

A téma háttér‑kitöltései a [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) gyűjteményben tárolódnak. A PowerPoint a felhasználói felületen több háttér‑választási lehetőséget jeleníthet meg, mint a gyűjteményben ténylegesen tárolt kitöltés‑definíciók száma, mivel a felület a téma‑kitöltéseket téma‑színekkel és egyéb stílushivatkozásokkal kombinálhatja.

![PowerPoint háttérstílus galéria egy prezentációs témához](presentation-design_8.png)

Mielőtt háttérstílust alkalmaznál, ellenőrizd a tárolt gyűjteményt és a jelenlegi [Background.StyleIndex](https://reference.aspose.com/slides/hu/net/aspose.slides/background/styleindex/)-et. A `StyleIndex` a `0`‑t használja a témához nem kötött kitöltéshez; a pozitív értékek téma‑háttér‑stílus hivatkozások. Ez eltér a .NET gyűjtemény közvetlen indexelésétől, ahol a `[0]` az első tárolt elemet jelenti. Ne feltételezd, hogy minden prezentáció ugyanannyi háttér‑kitöltési stílust tartalmaz.

Az alábbi példa kiírja a rendelkezésre álló háttér‑kitöltési darabszámot, a témához kötött háttér‑hivatkozást hozzárendeli az első mesterhez, majd menti a prezentációt:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var backgroundStyles = presentation.MasterTheme.FormatScheme.BackgroundFillStyles;
Console.WriteLine($"Background fill styles: {backgroundStyles.Count}");

if (backgroundStyles.Count == 0)
{
    throw new InvalidOperationException("The presentation theme does not contain background fill styles.");
}

presentation.Masters[0].Background.Type = BackgroundType.Themed;
presentation.Masters[0].Background.StyleIndex = 1;

presentation.Save("theme-background.pptx", SaveFormat.Pptx);
```

A látható eredmény a mester által hivatkozott téma‑bejegyzéstől, valamint az elrendezés‑ vagy dia‑szintű háttér‑felülírásoktól függ. Ha egy dia saját háttérrel rendelkezik, a mester‑háttér módosítása nem feltétlenül változtatja meg azt a diát. Használd a [Background.GetEffective](https://reference.aspose.com/slides/hu/net/aspose.slides/background/geteffective/) metódust, ha a teljes öröklődés után a végleges háttérre van szükséged.

{{% alert color="warning" title="Warning" %}}
Ne kezeld a `StyleIndex`‑et nullára indexelt gyűjtemény‑indexként. Kerüld a egy fájlból származó stílusszám közvetlen kódba írását, mivel a téma‑stílusdefiníciók prezentációnként eltérőek lehetnek.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Közvetlen háttérformázáshoz és háttér‑öröklődéshez lásd a [Presentation Background](/slides/hu/net/presentation-background/).
{{% /alert %}}

## **A téma effektusok frissítése**

A téma formátum‑sémája külön [FillStyles](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/formatscheme/fillstyles/), [LineStyles](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/formatscheme/linestyles/) és [EffectStyles](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/formatscheme/effectstyles/) gyűjteményeket tartalmaz. A tipikus Office‑témák gyakran három fő stílusbejegyzést tartalmaznak, amelyek vizuálisan a finom, közepes és intenzív formázásnak felelnek meg, de a kódnak minden gyűjteményt külön ellenőriznie kell a rögzített szám feltételezése helyett.

![Finom, közepes és intenzív téma‑effektusok ugyanazon alakzatra alkalmazva](presentation-design_10.png)

C#‑ban a gyűjtemény indexelése nullára kezdődik: a `[0]` az első tárolt stílus, a `[2]` a harmadik. Az alakzat stílus‑hivatkozási indexe egy külön fogalom, amelyet az [IShapeStyle](https://reference.aspose.com/slides/hu/net/aspose.slides/ishapestyle/) exponál. Egy téma‑stílus módosítása azoknál az alakzatoknál hat, amelyek erre a téma‑stílusra hivatkoznak; a közvetlen formázással rendelkező alakzatok változatlanok maradhatnak.

Az alábbi példa ellenőrzi, hogy a szükséges stílusbejegyzések léteznek, módosítja az első vonal‑stílust, a harmadik kitöltés‑stílust, engedélyezi a külső árnyékot a harmadik effektus‑stílusban, majd menti az eredményt:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Subtle_Moderate_Intense.pptx");
var formatScheme = presentation.MasterTheme.FormatScheme;

if (formatScheme.LineStyles.Count < 1 || formatScheme.FillStyles.Count < 3 || formatScheme.EffectStyles.Count < 3)
{
    throw new InvalidOperationException("The theme does not contain the style entries required by this example.");
}

formatScheme.LineStyles[0].FillFormat.FillType = FillType.Solid;
formatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Red;
formatScheme.FillStyles[2].FillType = FillType.Solid;
formatScheme.FillStyles[2].SolidFillColor.Color = Color.ForestGreen;
formatScheme.EffectStyles[2].EffectFormat.EnableOuterShadowEffect();
formatScheme.EffectStyles[2].EffectFormat.OuterShadowEffect.Distance = 10f;

presentation.Save("theme-effects.pptx", SaveFormat.Pptx);
```

A hivatkozott slotok esetén az első téma‑vonal‑stílus piros lesz, a harmadik téma‑kitöltés‑stílus szilárd erdőzöldre változik, a harmadik effektus‑stílus pedig 10 pont távolságú külső árnyékot kap. A pontos vizuális eredmény attól függ, hogy az egyes alakzatok mely slotokra hivatkoznak, és hogy a közvetlen formázás felülírja‑e a témát.

![Téma‑effektus‑stílusok módosítás után: vonal, kitöltés és árnyék beállítások](presentation-design_11.png)

## **A hatékony szilárd kitöltés téma‑színének meghatározása**

Egy kitöltés tárolódhat közvetlenül egy objektumon, vagy öröklődhet bekezdésből, elrendezésből, mesterből, téma‑stílusból vagy egy másik formázási szintből. Hívd meg a [IFillFormat.GetEffective](https://reference.aspose.com/slides/hu/net/aspose.slides/ifillformat/geteffective/) metódust, hogy ezt a hierarchiát egy változhatatlan [IFillFormatEffectiveData](https://reference.aspose.com/slides/hu/net/aspose.slides/ifillformateffectivedata/) objektummá alakítsa. Először ellenőrizd a [IFillFormatEffectiveData.FillType](https://reference.aspose.com/slides/hu/net/aspose.slides/ifillformateffectivedata/filltype/) értékét. Csak akkor, ha `FillType.Solid`, olvasd ki a szilárd‑kitöltés tulajdonságait.

Szilárd kitöltésnél a [IFillFormatEffectiveData.SolidFillColor](https://reference.aspose.com/slides/hu/net/aspose.slides/ifillformateffectivedata/solidfillcolor/) visszaadja a végső megjelenített RGB‑értéket az öröklődés, téma‑lekérdezés és színtranszformációk alkalmazása után. A [IFillFormatEffectiveData.SolidFillSchemeColor](https://reference.aspose.com/slides/hu/net/aspose.slides/ifillformateffectivedata/solidfillschemecolor/) visszaadja a megfelelő logikai [SchemeColor](https://reference.aspose.com/slides/hu/net/aspose.slides/schemecolor/) slotot, például `Text1` vagy `Accent6`. A `SchemeColor.NotDefined` érték azt jelenti, hogy a hatékony szilárd kitöltés nem egy sémaszín alapján jött létre. Egy olyan munkafolyamatban, ahol a kitöltések vagy téma‑színek, vagy közvetlen RGB‑színek, ez az érték azonosítja a közvetlen RGB‑kitöltést.

Ne csak a helyi [IColorFormat.SchemeColor](https://reference.aspose.com/slides/hu/net/aspose.slides/icolorformat/schemecolor/) értéket használd a kitöltés osztályozásához. Például egy szövegrésznek lehet helyi `NotDefined` sémaszíne, míg a hatékony kitöltése örökölt téma‑színből származik, és `Text1` vagy `Accent6`‑ra feloldódik. Ezzel szemben a `SolidFillSchemeColor` megmondja, mely logikai téma‑slot hozta létre a hatékony színt, de nem mutatja meg, hogy a slot az objektumból, bekezdésből, elrendezésből, mesterből vagy egy másik szintből származik-e.

Az alábbi példa betölti a prezentációt, ellenőrzi mind az alakzat‑kitöltéseket, mind a szövegrész‑kitöltéseket, kiírja az egyes végső RGB‑értékeket és a hozzájuk tartozó sémaszínt, valamint jelzi azokat a szilárd kitöltéseket, amelyek nem követik a téma‑szín változásait:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");

var slideCount = presentation.Slides.Count;
for (var slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];

    var shapeCount = slide.Shapes.Count;
    for (var shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++)
    {
        var shape = slide.Shapes[shapeIndex];
        var shapeName = $"Slide {slideIndex + 1}, shape {shapeIndex + 1}";
        AuditFill(shapeName, shape.FillFormat);

        if (shape is IAutoShape autoShape)
        {
            var paragraphCount = autoShape.TextFrame.Paragraphs.Count;
            for (var paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
            {
                var paragraph = autoShape.TextFrame.Paragraphs[paragraphIndex];

                var portionCount = paragraph.Portions.Count;
                for (var portionIndex = 0; portionIndex < portionCount; portionIndex++)
                {
                    var portion = paragraph.Portions[portionIndex];
                    var portionName = $"{shapeName}, paragraph {paragraphIndex + 1}, portion {portionIndex + 1}";
                    AuditFill(portionName, portion.PortionFormat.FillFormat);
                }
            }
        }
    }
}

static void AuditFill(string objectName, IFillFormat localFill)
{
    var effectiveFill = localFill.GetEffective();

    if (effectiveFill.FillType != FillType.Solid)
    {
        Console.WriteLine($"{objectName}: fill type = {effectiveFill.FillType}; not a solid fill.");
        return;
    }

    var rgb = effectiveFill.SolidFillColor;
    var effectiveSchemeColor = effectiveFill.SolidFillSchemeColor;
    var localSchemeColor = localFill.SolidFillColor.SchemeColor;

    Console.WriteLine($"{objectName}: RGB = #{rgb.R:X2}{rgb.G:X2}{rgb.B:X2}");
    Console.WriteLine($"{objectName}: local scheme = {localSchemeColor}, effective scheme = {effectiveSchemeColor}");

    if (effectiveSchemeColor == SchemeColor.NotDefined)
    {
        Console.WriteLine($"{objectName}: direct RGB or another non-scheme fill; audit as theme-independent.");
    }
    else
    {
        Console.WriteLine($"{objectName}: theme-dependent through {effectiveSchemeColor}.");
    }
}
```

A `NotDefined` ága egy auditlistát ad a szilárd kitöltésekről, amelyek nem reagálnak a téma‑színslotok változásaira. Ezeket az objektumokat érdemes felülvizsgálni, ha egy prezentációnak új márkaszínpalettát kell követnie. A jelentett RGB‑érték továbbra is a jelenlegi megjelenést mutatja, míg a sémaváltozó elmagyarázza, hogy a megjelenés kapcsolódik‑e a témához.

A hatékony‑formátum objektumok pillanatfelvételek. A prezentáció témájának, egy téma‑felülírásnak vagy bármely örökölt formázásnak a megváltoztatása után hívd meg újra a `GetEffective`‑et, és olvasd ki az új `IFillFormatEffectiveData` objektumot a színek összehasonlítása vagy jelentése előtt.

## **Hatékony témaértékek kiolvasása**

A nyers témaobjektumok megmutatják, mi van definiálva egy adott szinten. A hatékony értékek megmutatják, mit használ valójában egy dia vagy alakzat az öröklődés és a helyi felülírások feloldása után. Diára a [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) metódust hívd, háttérhez a [Background.GetEffective](https://reference.aspose.com/slides/hu/net/aspose.slides/background/geteffective/)-et, kitöltéshez pedig a [FillFormat.GetEffective](https://reference.aspose.com/slides/hu/net/aspose.slides/fillformat/geteffective/)-et.

Az alábbi példa kiolvassa a hatékony témát, a háttér‑stílust, valamint a dián lévő első alakzat kitöltését:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];
var effectiveTheme = slide.ThemeManager.CreateThemeEffective();
var effectiveBackground = slide.Background.GetEffective();

Console.WriteLine($"Effective major Latin font: {effectiveTheme.FontScheme.Major.LatinFont.FontName}");
Console.WriteLine($"Effective minor Latin font: {effectiveTheme.FontScheme.Minor.LatinFont.FontName}");
Console.WriteLine($"Effective background fill type: {effectiveBackground.FillFormat.FillType}");

if (slide.Shapes.Count > 0)
{
    var effectiveFill = slide.Shapes[0].FillFormat.GetEffective();
    Console.WriteLine($"First shape effective fill type: {effectiveFill.FillType}");
    if (effectiveFill.FillType == FillType.Solid)
    {
        Console.WriteLine($"First shape effective fill color: {effectiveFill.SolidFillColor}");
    }
}
```

Használd a hatékony adatokat megjelenítési diagnosztikához, validációhoz és összehasonlításokhoz. Ha csak a [Presentation.MasterTheme](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/mastertheme/)‑t ellenőrzöd, lemaradhatsz egy mester‑, elrendezés‑, dia‑ vagy alakzat‑felülírásról, amely megváltoztatja a végső megjelenést.

## **GYIK**

**Befolyásolja-e egy külső téma alkalmazása a prezentáció minden diaját?**

Nem. A [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/hu/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) csak azokat a diákat rendeli át, amelyek a kiválasztott mesterhez tartoznak. A más mestereket használó diák megtartják meglévő témáikat.

**Alkalmazhatok‑e témát egyetlen diára a mester megváltoztatása nélkül?**

Igen. Használd a dia [SlideThemeManager](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/slidethememanager/)‑ét, és inicializáld a felülírt témát. A változás csak az adott diára vonatkozik; a többi dia a meglévő témáját továbbra is örökli.

**Mi a legbiztonságosabb módja egy téma átvitelének az egyik prezentációból a másikba?**

Dia áthelyezésekor és a forrás‑megjelenés megőrzésekor klónozd a forrás‑mestert a cél‑prezentációba, majd klónozd a diát azzal a mesterrel a [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/hu/net/aspose.slides/imasterslidecollection/addclone/) és a [ISlideCollection.AddClone](https://reference.aspose.com/slides/hu/net/aspose.slides/islidecollection/addclone/) segítségével. Így a mester, elrendezések és a téma együtt maradnak.

**Hogyan tekinthetem meg a hatékony értékeket az öröklődés és felülírások után?**

Használd a [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) metódust egy dia vagy elrendezés témájához, valamint a megfelelő hatékony‑adat metódusokat a formátumobjektumokhoz, például a [Background.GetEffective](https://reference.aspose.com/slides/hu/net/aspose.slides/background/geteffective/) és a [FillFormat.GetEffective](https://reference.aspose.com/slides/hu/net/aspose.slides/fillformat/geteffective/) metódusokat. Ezek az API‑k visszaadják az öröklődés és felülírások alkalmazása után feloldott értékeket.