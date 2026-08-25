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
- téma színe
- kiegészítő paletta
- téma betűtípusa
- téma stílusa
- téma effektusa
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Mestertémák kezelése az Aspose.Slides for .NET-ben a PowerPoint fájlok létrehozásához, testreszabásához és konvertálásához egységes márkázással."
---
## **Bevezetés**

A prezentációs téma egy koordinált szín-, betűtípus-, háttérstílus-, kitöltési-, vonal- és effektuskészletet definiál. A téma‑tudatos objektumok ezekre a közös definíciókra hivatkoznak ahelyett, hogy minden vizuális tulajdonságot rögzített értékként tárolnának, így egy téma‑csere egyszerre több objektumot is frissíthet.

Az Aspose.Slides‑ben a prezentáció‑szintű téma a [Presentation.MasterTheme](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/mastertheme/) tulajdonságon keresztül érhető el. A prezentáció alacsonyabb szinteken is felülbírálhatja a témát. Egy mester felülbírálhatja a prezentáció témáját a [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/masterthememanager/overridetheme/) segítségével, egy elrendezés felülbírálhatja a neki örökölt témát a [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/baseoverridethememanager/overridetheme/) segítségével, és egy adott dia is megteheti ugyanezt. Gyakorlatilag egy dia hatékony témája ezen öröklődési lánc mentén kerül feloldásra: prezentációtéma, mester‑felülbírálás, elrendezés‑felülbírálás és dia‑felülbírálás.

![A téma összetevői: színek, betűtípusok, háttérstílusok és effektusok](theme-constituents.png)

Az alábbi szakaszok a leggyakoribb téma‑munkafolyamatokat mutatják be: téma ellenőrzése, színek és betűtípusok módosítása, téma másolása vagy alkalmazása, háttér‑ és effektus‑stílusok frissítése, valamint a hatékony értékek kiolvasása az öröklődés és felülbírálások után.

## **Téma ellenőrzése**

A [MasterTheme](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/mastertheme/) objektum a téma [ColorScheme](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/mastertheme/colorscheme/), [FontScheme](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/mastertheme/fontscheme/) és [FormatScheme](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/mastertheme/formatscheme/) elemeit teszi elérhetővé. Ezeknek a gyűjteményeknek az ellenőrzése a módosítás előtt különösen hasznos, ha a prezentáció külső forrásból származik, mivel a stílusbejegyzések száma és tartalma változhat.

Az alábbi példa elolvassa a fő téma‑tulajdonságokat, és jelentést készít arról, hogy hány háttér‑, kitöltési‑, vonal‑ és effektus‑stílus van tárolva a témában:

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

Ha egy fájl több mestert használ, ne feltételezzük, hogy minden dia ugyanazzal a hatékony témával rendelkezik. Ellenőrizzük a diával társított mestert, és használjuk a később ebben a cikkben bemutatott hatékony‑téma munkafolyamatot, ha elrendezés‑ vagy dia‑felülbírálások is előfordulhatnak.

## **Téma színeinek módosítása**

A téma‑tudatos kitöltések, vonalak és szöveg logikai színre hivatkozhat a [SchemeColor](https://reference.aspose.com/slides/hu/net/aspose.slides/schemecolor/) felsorolásból. Ha megváltoztatjuk a megfelelő bejegyzést a téma [IColorScheme](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/icolorscheme/) gyűjteményében, akkor minden objektum, amely még mindig arra a téma‑színre hivatkozik, az új érték szerint kerül feloldásra. Azok az objektumok, amelyek közvetlen RGB‑színt használnak, nem változnak meg egy téma‑szín frissítésekor.

Az alábbi vég‑végére példakód egy olyan alakzatot hoz létre, amely az `Accent4`-et használja, megváltoztatja a téma `Accent4` színét pirosra, elmenti a prezentációt, újra megnyitja, és kiírja a hatékony kitöltőszínt:

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

Mivel a téglalap továbbra is az `Accent4`-hez van kapcsolva, látható színe piros lesz a téma módosítása után. Ha a sémaszínt közvetlen színre cseréljük az alakzaton, a későbbi `Accent4` változások már nem befolyásolják azt a kitöltést.

### **A kiegészítő palettáról származó színek használata**

A PowerPoint a téma színéből világosabb és sötétebb változatokat származtat a színátalakítások alkalmazásával. Az Aspose.Slides ezeket az átalakításokat a [ColorTransformOperation](https://reference.aspose.com/slides/hu/net/aspose.slides/colortransformoperation/) segítségével teszi elérhetővé.

![A fő téma színei és a kiegészítő palettából előállított világosabb‑sötétebb színek](additional-palette-colors.png)

**1** – A fő téma színei.  
**2** – A fő téma színei alapján előállított világosabb és sötétebb változatok.

Az alábbi példa hat téglalapot hoz létre az `Accent4` alapján, ötön alkalmaz szín‑fényerősség‑átalakítást, majd elmenti az eredményt:

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

Ezek a variánsok továbbra is a téma színére épülnek. Ha később megváltozik az `Accent4`, a transzformált színek az új `Accent4` értékből lesznek újraszámolva.

### **A `SchemeColor` értékek leképezése az `IColorScheme` helyekre**

A [SchemeColor](https://reference.aspose.com/slides/hu/net/aspose.slides/schemecolor/) felsorolás a `Text1`, `Background1`, `Text2` és `Background2` értékeket használja, míg az [IColorScheme](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/icolorscheme/) ugyanazokat a témahelyeket `Dark1`, `Light1`, `Dark2` és `Light2` néven teszi elérhetővé. A leképezés rögzített:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Ezek ugyanazon témahelyek alternatív nevei; nem olyan értékek, amelyeket dinamikusan konvertálnak egyik formából a másikba.

## **Téma betűtípusainak módosítása**

Egy téma‑betűtípus‑készlet fő betűtípust tartalmaz a címsorokhoz, és kisebb betűtípust a törzsszöveghez. A [FontScheme.Major](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/fontscheme/major/) és a [FontScheme.Minor](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/fontscheme/minor/) tulajdonságok ezeket a készleteket teszik elérhetővé.

A PowerPoint‑kompatibilis téma‑betűtípus azonosítók a szövegformázásban használhatók:

* `+mn-lt` – Body Font Latin (Minor Latin Font)
* `+mj-lt` – Heading Font Latin (Major Latin Font)
* `+mn-ea` – Body Font East Asian (Minor East Asian Font)
* `+mj-ea` – Heading Font East Asian (Major East Asian Font)

Az alábbi példa egy címsort hoz létre, amely a fő latin téma‑betűtípust használja, valamint egy törzssort, amely a kisebb latin téma‑betűtípust használja. Ezután megváltoztatja a téma betűtípusait, és elmenti az eredményt:

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

A cím a fő betűtípust követi, a törzsszöveg a kisebb betűtípust. Az olyan szöveg, amely kifejezett betűtárgy nevet tartalmaz a téma‑azonosító helyett, nem vált automatikusan át a téma‑betűtípus‑készlet változása esetén.

A fő és kisebb betűtípus‑gyűjtemények tartalmazhatnak betűtípus‑leképezéseket egyedi írásrendszerekhez is, például cirill, arab, japán, grúz és thaana. Ezeknek a leképezéseknek az ellenőrzéséhez, hozzáadásához, cseréjéhez vagy eltávolításához lásd a [Script‑Specific Theme Fonts](/slides/hu/net/script-specific-font-mappings/) oldalt.

{{% alert color="info" title="Tipp" %}}
További információk a prezentáció betűtípusaival kapcsolatban: [PowerPoint Fonts](/slides/hu/net/powerpoint-fonts/).
{{% /alert %}}

## **Téma másolása vagy alkalmazása**

Két gyakori munkafolyamat létezik, amelyek különböző problémákat oldanak meg.

### **Forrástéma megőrzése diák áthelyezésekor**

Ha egy dia áthelyezésekor meg akarjuk őrizni az eredeti megjelenést, klónozzuk a forrás‑mestert a célprezentációba a [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/hu/net/aspose.slides/imasterslidecollection/addclone/) segítségével, majd a diát a [ISlideCollection.AddClone](https://reference.aspose.com/slides/hu/net/aspose.slides/islidecollection/addclone/) és a klónozott mester használatával klónozzuk. Így a mester, az elrendezései és a kapcsolódó téma is együttesen kerül át.

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

Ez a preferált munkafolyamat, ha a forrásdia megjelenésének egyeznie kell a célban is. Egy nem kapcsolódó célmesterre történő egyszerű tartalomklónozás megváltoztathatja a téma‑alapú színeket, betűtípusokat, háttereket és effektusokat.

### **Témaértékek alkalmazása meglévő diára**

Ha a céldia a jelenlegi mesterén és elrendezésén kell maradjon, inicializáljunk egy dia‑szintű felülbírálást a forrástémából. A [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/overridetheme/initfontschemefrom/) és [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/overridetheme/initformatschemefrom/) metódusok a három fő téma‑komponenst másolják a felülbírálásba.

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

Ez megváltoztatja az adott dia által használt témát anélkül, hogy a többi dia örökölt témáját befolyásolná. A helyi felülbírálás eltávolításához és az örökölt értékek visszaállításához hívjuk meg az [OverrideTheme.Clear](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/overridetheme/clear/) metódust.

### **Téma felülbírálás alkalmazása elrendezésre**

Az elrendezés‑szintű felülbírálás az azt használó diákra vonatkozik, hacsak egy adott dia saját felülbírálást nem tartalmaz. Ugyanezeket az inicializáló metódusokat a layout [LayoutSlideThemeManager](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/layoutslidethememanager/) használatával is alkalmazhatjuk:

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

Használjunk mester‑ vagy prezentáció‑szintű témát, ha sok elrendezésnek és diáknak kell ugyanazt az alap‑designt megosztania; egy elrendezés‑felülbírálást, ha egy elrendezés‑családnak eltérő stilizálásra van szüksége; és egy dia‑felülbírálást csak valódi kivételek esetén. A túlzott dia‑szintű felülbírálások megnehezítik a későbbi globális téma‑változtatások előrejelzését.

## **Téma háttérstílusok frissítése**

A téma háttér‑kitöltései a [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) gyűjteményben tárolódnak. A PowerPoint felhasználói felülete több háttér‑választást kínálhat, mint amennyi kitöltésdefiníció fizikailag tárolva van ebben a kollekcióban, mivel a UI kombinálhat téma‑kitöltéseket téma‑színekkel és más stílus‑referenciákkal.

![PowerPoint háttérstílus galéria egy prezentációs témához](presentation-design_8.png)

Mielőtt egy háttér‑stílust használna, ellenőrizze a tárolt gyűjteményt és a jelenlegi [Background.StyleIndex](https://reference.aspose.com/slides/hu/net/aspose.slides/background/styleindex/) értéket. A `StyleIndex` a `0`‑t használja témamentes kitöltéshez; a pozitív értékek téma‑háttér‑stílus‑referenciák. Ez eltér a .NET kollekció közvetlen indexelésétől, ahol a `[0]` az első tárolt elemet jelenti. Ne feltételezzük, hogy minden prezentáció ugyanannyi háttér‑kitöltés‑stílust tartalmaz.

Az alábbi példa jelentést készít a rendelkezésre álló háttér‑kitöltések számáról, egy tematikus háttér‑referenciát rendeli az első mesterhez, majd elmenti a prezentációt:

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

A látható eredmény a mestertől referenciált téma‑bejegyzéstől és a elrendezés‑ vagy diaszintű háttér‑felülbírálásoktól függ. Ha egy dia saját háttérrel rendelkezik, csak a mester háttér módosítása nem feltétlenül változtatja meg azt a diát. Használja a [Background.GetEffective](https://reference.aspose.com/slides/hu/net/aspose.slides/background/geteffective/) metódust, ha a teljes háttérre van szüksége az öröklődés után.

{{% alert color="warning" title="Figyelmeztetés" %}}
Ne kezelje a `StyleIndex`‑et nulla‑alapú kollekció‑indexként. Kerülje el egy stílusszám kódba ültetését egy fájlból, és annak feltételezését, hogy egy másik fájlban ugyanúgy néz ki; a téma‑stílusdefiníciók prezentációnként eltérőek.
{{% /alert %}}

{{% alert color="info" title="Tipp" %}}
Közvetlen háttér‑formázáshoz és háttér‑öröklődéshez lásd a [Presentation Background](/slides/hu/net/presentation-background/) oldalt.
{{% /alert %}}

## **Téma effektusok frissítése**

Egy téma‑formátum‑készlet külön [FillStyles](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/formatscheme/fillstyles/), [LineStyles](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/formatscheme/linestyles/) és [EffectStyles](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/formatscheme/effectstyles/) gyűjteményt tartalmaz. A tipikus Office‑témák gyakran három fő stílusbejegyzést tartalmaznak, amelyek vizuálisan a finom, közepes és intenzív formázásnak felelnek meg, de a kódnak minden gyűjteményt ellenőriznie kell a fix szám feltételezése helyett.

![Finom, közepes és intenzív téma‑effektusok egyforma alakzatra alkalmazva](presentation-design_10.png)

C#‑ban ezekhez a gyűjteményekhez való hozzáféréskor a kollekcióindex nulla‑alapú: `[0]` az első tárolt stílus, `[2]` a harmadik. Az alakzat stílus‑referencia‑indexei egy külön fogalom, amely a [IShapeStyle](https://reference.aspose.com/slides/hu/net/aspose.slides/ishapestyle/) révén érhető el. Egy téma‑stílus módosítása azokra az alakzatokra hat, amelyek arra a téma‑stílusra hivatkoznak; a közvetlen formázással rendelkező alakzatok változatlanok maradhatnak.

Az alábbi példa ellenőrzi, hogy a szükséges stílusbejegyzések léteznek, módosítja az első vonal‑stílust, a harmadik kitöltő‑stílust, egy külső árnyékot kapcsol be a harmadik effektus‑stílusban, majd elmenti az eredményt:

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

Az ezekre a helyekre hivatkozó alakzatok esetén az első téma‑vonal‑stílus piros, a harmadik téma‑kitöltő‑stílus szilárd erdőzöld, a harmadik effektus‑stílus pedig külső árnyékot kap 10 pont távolsággal. A pontos vizuális eredmény továbbra is attól függ, hogy mely stílus‑helyeket hivatkozza az egyes alakzat, és hogy a közvetlen formázás felülbírálja-e a témát.

![Téma‑effektus‑stílusok módosítása után: vonal, kitöltés és árnyék beállításai](presentation-design_11.png)

## **Hatékony témaértékek kiolvasása**

A nyers témaobjektumok azt mutatják, hogy mi van definiálva egy adott szinten. A hatékony értékek azt mutatják, hogy egy dia vagy alakzat valójában mit használ az öröklődés és a helyi felülbírálások után. Diára vonatkozóan hívja meg a [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) metódust. Háttérre a [Background.GetEffective](https://reference.aspose.com/slides/hu/net/aspose.slides/background/geteffective/) használható, kitöltésre pedig a [FillFormat.GetEffective](https://reference.aspose.com/slides/hu/net/aspose.slides/fillformat/geteffective/) metódus.

Az alábbi példa kiolvassa a hatékony témát, a háttér‑stílust és az első alakzat kitöltését egy diáról:

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

Használja a hatékony adatokat renderelési diagnosztikához, validáláshoz és összehasonlításokhoz. Ha csak a [Presentation.MasterTheme](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/mastertheme/) ellenőrzésével foglalkozik, lemaradhat egy mester, elrendezés, dia vagy alakzat felülbírálásáról, amely megváltoztatja a végső megjelenést.

## **GYIK**

**Alkalmazhatok egy témát egyetlen diára anélkül, hogy a mestert módosítanám?**

Igen. Használja a dia [SlideThemeManager](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/slidethememanager/) objektumát, és inicializálja annak felülbíráló témáját. A változás csak arra a diára marad lokálisan; a többi dia a meglévő témáját örökli.

**Mi a legbiztonságosabb módja egy téma átvitelének egyik prezentációból a másikba?**

Diák áthelyezésekor és a forrás megjelenésének megőrzésekor klónozza a forrás‑mestert a célba, majd a diát a klónozott mesterrel a [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/hu/net/aspose.slides/imasterslidecollection/addclone/) és a [ISlideCollection.AddClone](https://reference.aspose.com/slides/hu/net/aspose.slides/islidecollection/addclone/) metódusokkal. Így a mester, az elrendezések és a téma együtt kerül át.

**Hogyan tekinthetem meg a hatékony értékeket az öröklődés és felülbírálások után?**

Használja a [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) metódust egy dia vagy elrendezés téma esetén, és a megfelelő hatékony‑adat metódusokat a formátumobjektumokhoz, mint például a [Background.GetEffective](https://reference.aspose.com/slides/hu/net/aspose.slides/background/geteffective/) és a [FillFormat.GetEffective](https://reference.aspose.com/slides/hu/net/aspose.slides/fillformat/geteffective/). Ezek az API‑k a feloldott értékeket adják vissza az öröklődés és felülbírálások alkalmazása után.