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
description: "A Aspose.Slides for .NET fő prezentációs témái, melyekkel PowerPoint fájlokat hozhat létre, testreszabhat és konvertálhat egységes márkajelzéssel."
---
## **Bevezetés**

A prezentációs téma egy koordinált szín-, betűtípus-, háttérstílus-, kitöltés-, vonal- és effektuskészletet határoz meg. A témára érzékeny objektumok ezekre a közös definíciókra hivatkoznak ahelyett, hogy minden vizuális tulajdonságot fix értékként tárolnának, így egy téma módosítása egyszerre frissítheti a sok objektumot.

Az Aspose.Slides‑ban a prezentációszintű téma a [Presentation.MasterTheme](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/mastertheme/) tulajdonságon keresztül érhető el. Egy prezentáció alacsonyabb szinteken is tartalmazhat téma felülírásokat. Egy mester felülírhatja a prezentáció témát a [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/masterthememanager/overridetheme/) segítségével, egy elrendezés felülírhatja az örökölt témát a [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/baseoverridethememanager/overridetheme/) használatával, és egy egyedi dia is megteheti ugyanezt. Gyakorlatban egy dia hatékony témája ezen öröklődési láncon keresztül kerül feloldásra: prezentációs téma, mester‑felülírás, elrendezés‑felülírás és dia‑felülírás.

![Téma összetevői: színek, betűtípusok, háttérstílusok és effektusok](theme-constituents.png)

Az alábbi szakaszok a leggyakoribb téma‑munkafolyamatokat mutatják be: téma vizsgálata, színek és betűtípusok módosítása, téma másolása vagy alkalmazása, háttér‑ és effektus‑stílusok frissítése, valamint hatékony értékek olvasása az öröklődés és a felülírások feloldása után.

## **Téma ellenőrzése**

A [MasterTheme](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/mastertheme/) objektum a téma [ColorScheme](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/mastertheme/colorscheme/), [FontScheme](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/mastertheme/fontscheme/) és [FormatScheme](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/mastertheme/formatscheme/) gyűjteményeit teszi elérhetővé. Ezeknek a gyűjteményeknek a vizsgálata a módosításuk előtt különösen hasznos, ha a prezentáció külső forrásból származik, mert a stíluselemek száma és tartalma változhat.

Az alábbi példa beolvassa a fő téma tulajdonságait, és jelzi, hány háttér‑, kitöltés‑, vonal‑ és effektus‑stílus található a témában:

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

Ha egy fájl több mestert használ, ne feltételezze, hogy minden dia ugyanazzal a hatékony témával rendelkezik. Ellenőrizze a diához tartozó mestert, és használja a később ebben a cikkben bemutatott hatékony‑téma munkafolyamatot, ha elrendezés‑ vagy diafelülírások lehetnek jelen.

## **Téma színeinek módosítása**

A témára érzékeny kitöltések, vonalak és szöveg hivatkozhat a [SchemeColor](https://reference.aspose.com/slides/hu/net/aspose.slides/schemecolor/) felsorolás logikai színére. Ha a téma [IColorScheme](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/icolorscheme/) megfelelő bejegyzését módosítja, minden objektum, amely még mindig erre a téma‑színre hivatkozik, az új értékhez lesz rendelve. Azok az objektumok, amelyek közvetlen RGB‑színt használnak, nem változnak a téma‑szín frissítésekor.

Az alábbi vég‑véges példa létrehoz egy alakzatot, amely a `Accent4`‑et használja, megváltoztatja a téma `Accent4` színét pirosra, elmenti a prezentációt, újból megnyitja, és kiírja a hatékony kitöltőszínt:

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

Mivel a téglalap továbbra is a `Accent4`‑hez van csatlakozva, látható színe a téma módosítása után piros lesz. Ha a séma‑színt közvetlen színre cseréli az alakzaton, a későbbi `Accent4` változtatások már nem befolyásolják azt a kitöltést.

### **Színek használata a kiegészítő palettáról**

A PowerPoint a téma színéből fényesebb és sötétebb változatokat származtat színátalakítások alkalmazásával. Az Aspose.Slides ezeket az átalakításokat a [ColorTransformOperation](https://reference.aspose.com/slides/hu/net/aspose.slides/colortransformoperation/) segítségével teszi elérhetővé.

![Fő téma színek és a kiegészítő palettából generált világosabb és sötétebb színek](additional-palette-colors.png)

**1** – Fő téma színek.  
**2** – Fényesebb és sötétebb változatok, a fő téma színekből előállítva.

Az alábbi példa hat téglalapot hoz létre a `Accent4` alapján, ötön színtranszformációt alkalmaz, és elmenti az eredményt:

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

Ezek a variánsok továbbra is a téma színén alapulnak. Ha a `Accent4` később változik, a transzformált színek az új `Accent4` értékből lesznek újraszámolva.

### **A `SchemeColor` értékek leképezése az `IColorScheme` helyekre**

A [SchemeColor](https://reference.aspose.com/slides/hu/net/aspose.slides/schemecolor/) felsorolás a `Text1`, `Background1`, `Text2` és `Background2` értékeket használja, míg az [IColorScheme](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/icolorscheme/) ugyanazokat a témahelyeket `Dark1`, `Light1`, `Dark2` és `Light2` néven teszi közzé. A leképezés rögzített:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Ezek ugyanazon témahelyek alternatív nevei; nem olyan értékek, amelyeket dinamikusan konvertálnak egyik formából a másikba.

## **Téma betűtípusainak módosítása**

A téma betűtípus‑sémája egy fő betűtípus‑készletet tartalmaz a címsorokhoz és egy mellék betűtípus‑készletet a törzsszöveghez. A [FontScheme.Major](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/fontscheme/major/) és a [FontScheme.Minor](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/fontscheme/minor/) tulajdonságok teszik elérhetővé ezeket a készleteket.

PowerPoint‑kompatibilis téma‑betűtípus azonosítók használhatók a szövegformázásban:

* `+mn‑lt` – Törzsszöveg Latin (Minor Latin Font)
* `+mj‑lt` – Címsor Latin (Major Latin Font)
* `+mn‑ea` – Törzsszöveg Kelet‑Ázsiai (Minor East Asian Font)
* `+mj‑ea` – Címsor Kelet‑Ázsiai (Major East Asian Font)

Az alábbi példa létrehoz egy címsort, amely a fő Latin téma‑betűtípust használja, és egy törzssort, amely a mellék Latin téma‑betűtípust használja. Ezután módosítja a téma betűtípusait, és elmenti az eredményt:

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

A címsor a fő betűtípust követi, a törzsszöveg a mellék betűtípust. Azok a szövegek, amelyek explicit betűtípus‑nevet tartalmaznak a témaazonosító helyett, nem váltanak automatikusan, ha a téma‑betűtípus‑séma megváltozik.

A fő‑ és mellék‑betűtípus‑gyűjtemények tartalmazhatnak betűtípus‑leképezéseket egyedi írásrendszerekhez, például cirill, arab, japán, grúz és thaana. Ezeknek a leképezéseknek a megtekintéséhez, hozzáadásához, cseréjéhez vagy eltávolításához lásd a [Script‑Specific Theme Fonts](/slides/hu/net/script-specific-font-mappings/) oldalt.

{{% alert color="info" title="Tip" %}}
További információk a prezentációs betűtípusokról: lásd a [PowerPoint Fonts](/slides/hu/net/powerpoint-fonts/).
{{% /alert %}}

## **Téma másolása vagy alkalmazása**

Az alábbi munkafolyamatok különböző téma‑kapcsolt problémákat oldanak meg.

### **Külső téma alkalmazása egy mesterhez tartozó diákra**

Használja a [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/hu/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) metódust, ha rendelkezik egy PowerPoint témafájllal (`.thmx`), és minden olyan diát újra szeretne stílusozni, amely egy adott mestertől függ. Válassza ki a mestert a [Presentation.Masters](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/masters/) gyűjteményből, amely a [IMasterSlideCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/imasterslidecollection/) interfészt valósítja meg, és adja át a témafájl elérési útját a metódusnak.

A metódus a következő műveleteket hajtja végre:

1. Létrehoz egy új mester‑diát a kiválasztott mester alapján.  
1. Alkalmazza a külső témát az új mesterre.  
1. Az új mestert hozzárendeli minden olyan diához, amely korábban a kiválasztott mesterhez tartozott.  
1. Visszaadja a frissen létrehozott [IMasterSlide](https://reference.aspose.com/slides/hu/net/aspose.slides/imasterslide/) objektumot.

Az alábbi példa egy külső témát alkalmaz az első mesterhez tartozó diákra, elmenti a prezentációt, és újra megnyitja az eredményt:

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

Érvénytelen, sérült vagy nem támogatott téma [PptxException](https://reference.aspose.com/slides/hu/net/aspose.slides/pptxexception/) vagy egyik formátum‑specifikus alosztályát idézheti elő. Ellenőrizze a felhasználók által megadott útvonalakat, kezelje a fájlrendszer‑hozzáférési hibákat, és csak akkor mentse a prezentációt, amikor a téma sikeresen alkalmazásra került.

Csak azok a diák kerülnek újra hozzárendelésre, amelyek az adott mestertől függenek. Más mesterekhez tartozó diák megtartják meglévő mestereiket és témáikat. A téma‑érzékeny színek, betűtípusok, kitöltések, vonalak, háttér és effektusok a külső témához lesznek igazítva. A közvetlenül hozzárendelt színek, betűtípusok, kitöltések és egyéb explicit formázás változatlan maradhat. Az elrendezés‑szintű és dia‑szintű felülírások is felülbírálhatják az új mesterből örökölt értékeket.

A téma hivatkozhat olyan betűtípusokra, amelyek nincsenek jelen a futási környezetben. A következetes megjelenítés és export érdekében telepítse a szükséges betűtípusokat, biztosítsa őket a [custom font sources](/slides/hu/net/custom-font/) segítségével, vagy konfigurálja a [font substitution](/slides/hu/net/font-substitution/) beállítást.

Ez egy közvetlen mester‑szintű munkafolyamat: a metódus egy `.thmx` fájl elérési útját várja, és nem igényel manuális dia‑ vagy elrendezés‑szintű téma‑felülírások létrehozását.

### **Különböző külső témák alkalmazása többmesterről álló prezentációban**

Amennyiben a releváns mester előre nem ismert, szerezze be egy reprezentatív dia segítségével a [ISlide.LayoutSlide](https://reference.aspose.com/slides/hu/net/aspose.slides/islide/layoutslide/) és a [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/hu/net/aspose.slides/ilayoutslide/masterslide/) referenciáit. A témák alkalmazása előtt tárolja el az eredeti mester‑referenciákat, mivel minden hívás egy új mestert hoz létre a prezentációban.

Az alábbi példa két szekcióból származó diák segítségével megkeresi a mestereket, és mindegyik csoporthoz eltérő külső témát alkalmaz:

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

Az első hívás csak a `firstGroupMaster`‑hez tartozó diákot érinti, a második csak a `secondGroupMaster`‑hez tartozókat. A többi mesterhez tartozó diákok nem kapnak új stílust.

### **A forrás téma megőrzése diák áthelyezésekor**

Ha egy diát egy másik prezentációba szeretne áthelyezni, és meg akarja őrizni az eredeti megjelenését, klónozza a forrás‑mestert a cél‑prezentációba a [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/hu/net/aspose.slides/imasterslidecollection/addclone/) segítségével, majd a diát a [ISlideCollection.AddClone](https://reference.aspose.com/slides/hu/net/aspose.slides/islidecollection/addclone/) és a klónozott mesterrel klónozza. Ez a mester, az elrendezései és a hozzájuk tartozó téma együtt kerül átvitelre.

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

Ez a preferált munkafolyamat, amikor a forrás‑dia megjelenésének változatlansága a cél‑prezentációban is kötelező. Egy nem kapcsolódó cél‑mesterre történő egyszerű tartalomklónozás megváltoztathatja a téma‑vezérelt színeket, betűtípusokat, háttereket és effektusokat.

### **Téma értékek alkalmazása meglévő diára**

Ha a cél‑dia a jelenlegi mesterén és elrendezésén marad, inicializáljon egy dia‑szintű felülírást a forrás‑témából. A [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/overridetheme/initfontschemefrom/) és [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/overridetheme/initformatschemefrom/) metódusok másolják a három fő téma‑komponenst a felülírásba.

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

Ez megváltoztatja a diára alkalmazott témát anélkül, hogy a többi diára örökölt témát módosítaná. A helyi felülírás eltávolításához és az örökölt értékek visszaállításához hívja meg a [OverrideTheme.Clear](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/overridetheme/clear/) metódust.

### **Téma felülírás alkalmazása elrendezésre**

Az elrendezés‑szintű felülírás azokat a diákot érinti, amelyek az adott elrendezést használják, kivéve, ha egy konkrét dia saját felülírással rendelkezik. Ugyanezeket az inicializációs metódusokat használhatja az elrendezés [LayoutSlideThemeManager](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/layoutslidethememanager/) segítségével:

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

Használjon mester‑ vagy prezentáció‑szintű témát, ha sok elrendezésnek és diáknak közös alap‑dizájnt kell megosztania; egy elrendezés‑felülírást, ha egy elrendezéscsaládnak eltérő stílusra van szüksége; és csak diák‑szintű felülírást a valódi kivételekhez. A túl sok dia‑szintű felülírás nehezíti a későbbi globális téma‑változások előrejelzését.

## **Téma háttérstílusok frissítése**

A téma háttér‑kitöltései a [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) gyűjteményben tárolódnak. A PowerPoint a felhasználói felületén több háttér‑lehetőséget mutathat meg, mint amennyi kitöltés‑definíció ténylegesen tárolva van ebben a gyűjteményben, mivel a UI kombinálhat téma‑kitöltéseket téma‑színekkel és más stílus‑referenciákkal.

![PowerPoint háttérstílus galéria egy prezentációs témához](presentation-design_8.png)

Mielőtt háttér‑stílust használna, ellenőrizze a tárolt gyűjteményt és a jelenlegi [Background.StyleIndex](https://reference.aspose.com/slides/hu/net/aspose.slides/background/styleindex/) értéket. A `StyleIndex` a `0`‑t használja „nincs téma‑kitöltés” esetén; a pozitív értékek téma‑háttér‑stílus‑referenciák. Ez eltér attól, amikor a .NET gyűjteményt közvetlenül indexeljük, ahol a `[0]` az első tárolt elemet jelenti. Ne feltételezze, hogy minden prezentáció ugyanannyi háttér‑kitöltés‑stílussal rendelkezik.

Az alábbi példa bejelenti a rendelkezésre álló háttér‑kitöltések számát, egy téma‑háttér‑referenciát rendel az első mesterhez, és elmenti a prezentációt:

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

A látható eredmény a mester által hivatkozott téma‑bejegyzéstől, valamint az elrendezés‑ vagy dia‑szintű háttér‑felülírásoktól függ. Ha egy dia saját háttérrel rendelkezik, a csak a mester hátterének módosítása nem változtatja meg azt a diát. Használja a [Background.GetEffective](https://reference.aspose.com/slides/hu/net/aspose.slides/background/geteffective/) metódust, ha a végleges háttér értékére van szüksége az öröklődés alkalmazása után.

{{% alert color="warning" title="Warning" %}}
A `StyleIndex` értékét ne tekintse nullától induló gyűjtemény‑indexnek. Kerülje, hogy egy fájlból származó stílus‑számot keményen kódolja, és feltételezze, hogy ugyanúgy néz ki egy másik fájlban; a téma‑stílus‑definíciók prezentáció‑specifikusak.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
A közvetlen háttér‑formázáshoz és a háttér‑öröklődéshez lásd a [Presentation Background](/slides/hu/net/presentation-background/) cikket.
{{% /alert %}}

## **Téma effektusok frissítése**

A téma formátum‑sémája különálló [FillStyles](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/formatscheme/fillstyles/), [LineStyles](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/formatscheme/linestyles/) és [EffectStyles](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/formatscheme/effectstyles/) gyűjteményeket tartalmaz. A tipikus Office‑témák gyakran három fő stílusbejegyzést tartalmaznak, amelyek vizuálisan a finom, közepes és intenzív formázásnak felelnek meg, de a kódnak minden gyűjteményt ellenőriznie kell, ahelyett hogy fix számú elemet feltételezne.

![Finom, közepes és erőteljes témaeffektek ugyanazon alakzatra alkalmazva](presentation-design_10.png)

C#‑ban ezen gyűjteményekhez való hozzáféréskor a gyűjtemény‑index nulla‑alapú: a `[0]` az első tárolt stílus, a `[2]` a harmadik. Egy alakzat stílus‑referencia‑indexei külön koncepció, amelyet az [IShapeStyle](https://reference.aspose.com/slides/hu/net/aspose.slides/ishapestyle/) tesz elérhetővé. Egy téma‑stílus módosítása olyan alakzatokat érint, amelyek hivatkoznak arra a téma‑stílusra; a közvetlen formázású alakzatok változatlanok maradhatnak.

Az alábbi példa ellenőrzi, hogy a szükséges stílusbejegyzések léteznek-e, megváltoztatja az első vonal‑stílust, a harmadik kitöltés‑stílust, egy külső árnyékot aktivál a harmadik effektus‑stílusban, majd elmenti az eredményt:

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

A slotokra hivatkozó alakzatok esetén az első téma‑vonal‑stílus pirosra, a harmadik téma‑kitöltés‑stílus erdőzöldre változik, a harmadik effektus‑stílus pedig egy 10 pont távolságú külső árnyékot kap. A pontos vizuális eredmény továbbra is attól függ, melyik stílus‑slotra hivatkozik az adott alakzat, és hogy a közvetlen formázás felülírja‑e a témát.

![Téma effektus‑stílusok módosítása után (vonal, kitöltés, árnyék)](presentation-design_11.png)

## **Hatékony témaértékek olvasása**

A nyers témaobjektumok azt mutatják, ami egy adott szinten definiálva van. A hatékony értékek azt mutatják, amit egy dia vagy alakzat ténylegesen használ az öröklődés és a helyi felülírások feloldása után. Diára a [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) hívható, háttérre a [Background.GetEffective](https://reference.aspose.com/slides/hu/net/aspose.slides/background/geteffective/), kitöltésre pedig a [FillFormat.GetEffective](https://reference.aspose.com/slides/hu/net/aspose.slides/fillformat/geteffective/).

Az alábbi példa beolvassa a hatékony témát, háttért és az első alakzat kitöltését egy diáról:

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

Használja a hatékony adatokat megjelenítési diagnosztikához, validáláshoz és összehasonlításokhoz. Ha csak a [Presentation.MasterTheme](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/mastertheme/) ellenőrzi, egyes mester‑, elrendezés‑, dia‑ vagy alakzat‑felülírásokat figyelmen kívül hagyhat, amelyek a végső megjelenést módosítják.

## **GYIK**

**Érint-e egy külső téma alkalmazása a prezentáció minden diaját?**  
Nem. A [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/hu/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) csak azokat a diákot rendeli újra, amelyek a kiválasztott mesterhez tartoznak. A más mestereket használó diák megtartják meglévő témáikat.

**Alkalmazhatok-e témát egyetlen diára anélkül, hogy megváltoztatnám a mestert?**  
Igen. Használja a dia [SlideThemeManager](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/slidethememanager/) objektumát, és inicializálja a felülírt témát. A változás csak arra a diára vonatkozik; a többi dia a meglévő témáit örökli.

**Mi a legbiztonságosabb módja egy téma átvitelének az egyik prezentációból a másikba?**  
Diák áthelyezésekor és a forrás megjelenésének megőrzésekor klónozza a forrás‑mestert a cél‑prezentációba, majd a diát a klónozott mesterrel a [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/hu/net/aspose.slides/imasterslidecollection/addclone/) és a [ISlideCollection.AddClone](https://reference.aspose.com/slides/hu/net/aspose.slides/islidecollection/addclone/) segítségével. Ez a mester, az elrendezések és a téma együtt kerül átvitelre.

**Hogyan tekinthetem meg a hatékony értékeket az öröklődés és a felülírások után?**  
Használja a [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) metódust egy dia vagy elrendezés témájához, valamint a megfelelő hatékony‑adat metódusokat olyan formátumobjektumokhoz, mint a [Background.GetEffective](https://reference.aspose.com/slides/hu/net/aspose.slides/background/geteffective/) és a [FillFormat.GetEffective](https://reference.aspose.com/slides/hu/net/aspose.slides/fillformat/geteffective/). Ezek az API‑k a öröklődés és a felülírások alkalmazása után visszaadják a feloldott értékeket.