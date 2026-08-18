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
description: "A Aspose.Slides for .NET fő prezentációs témái a PowerPoint fájlok létrehozásához, testreszabásához és konvertálásához egységes márkázással."
---
## **Bevezetés**

A prezentációtémája meghatároz egy összehangolt színek, betűtípusok, háttérstílusok, kitöltések, vonalak és effektusok halmazát. A témajavában működő objektumok ezekre a megosztott definíciókra hivatkoznak ahelyett, hogy minden vizuális tulajdonságot rögzített értékként tárolnának, így egy téma módosítása egyszerre sok objektumot frissíthet.

Az Aspose.Slides-ban a prezentációszintű téma a [Presentation.MasterTheme](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/mastertheme/) tulajdonságon keresztül érhető el. Egy prezentáció alacsonyabb szinteken is tartalmazhat téma felülírásokat. A master felülírhatja a prezentáció témáját a [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/masterthememanager/overridetheme/) segítségével, egy elrendezés felülírhatja az örökölt témát a [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/baseoverridethememanager/overridetheme/) segítségével, és egy egyedi dia is megteheti ugyanezt. Gyakorlatban egy dia hatékony témája ezen öröklődési láncon keresztül kerül feloldásra: prezentációs téma, master felülírás, elrendezés felülírás és dia felülírás.

![Témaelemek: színek, betűtípusok, háttérstílusok és effektusok](theme-constituents.png)

Az alábbi szakaszok a leggyakoribb téma munkafolyamatokat mutatják be: téma ellenőrzése, színek és betűtípusok módosítása, téma másolása vagy alkalmazása, háttér- és effektusstílusok frissítése, valamint a hatékony értékek kiolvasása öröklődés és felülírások feloldása után.

## **Téma ellenőrzése**

Az [MasterTheme](https://reference.aspose.com/slides/hu/net/aspose.slides/theme/mastertheme/) objektum elérhetővé teszi a téma [ColorScheme](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/mastertheme/colorscheme/), [FontScheme](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/mastertheme/fontscheme/), és [FormatScheme](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/mastertheme/formatscheme/) részeit. Ezeknek a gyűjteményeknek a ellenőrzése a módosítás előtt különösen hasznos, ha egy prezentáció külső forrásból származik, mivel a stílusbejegyzések száma és tartalma változhat.

A következő példa beolvassa a fő téma tulajdonságait, és jelentést készít arról, hány háttér-, kitöltés-, vonal- és effektusstílus van tárolva a témában:

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

Ha egy fájl több masterrel rendelkezik, ne feltételezze, hogy minden diának ugyanaz a hatékony témája. Ellenőrizze a diához tartozó mastert, és használja a cikk később bemutatott hatékony-téma munkafolyamatot, ha elrendezés- vagy diaszintű felülírások léteznek.

## **Téma színeinek módosítása**

A témaérzékeny kitöltések, vonalak és szövegek hivatkozhatnak a [SchemeColor](https://reference.aspose.com/slides/hu/net/aspose.slides/schemecolor/) felsorolás logikai színére. Amikor módosítja a megfelelő bejegyzést a téma [IColorScheme](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/icolorscheme/) gyűjteményében, minden objektum, amely még a témaszínre hivatkozik, az új értékre lesz feloldva. Azok az objektumok, amelyek közvetlen RGB színt használnak, nem változnak egy téma‑szín frissítés hatására.

A következő végponttól‑végpontig példában egy alakzatot hozunk létre, amely az `Accent4` színt használja, megváltoztatjuk a téma `Accent4` színét vörösre, elmentjük a prezentációt, újra megnyitjuk, és kiíratjuk a hatékony kitöltési színt:

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

Mivel a téglalap továbbra is a `Accent4` színhez kapcsolódik, a látható színe a téma módosítása után vörös lesz. Ha az alakzaton a séma színét közvetlen színre cseréli, a későbbi `Accent4` változások már nem befolyásolják azt a kitöltést.

### **Színek használata a kiegészítő palettáról**

A PowerPoint a téma színéből világosabb és sötétebb változatokat származtat színtranszformációk alkalmazásával. Az Aspose.Slides ezeket a transzformációkat a [ColorTransformOperation](https://reference.aspose.com/slides/hu/net/aspose.slides/colortransformoperation/) segítségével teszi elérhetővé.

![Fő téma színek és a kiegészítő palettából generált világosabb és sötétebb színek](additional-palette-colors.png)

**1** - Fő téma színek.

**2** - A fő téma színekből előállított világosabb és sötétebb változatok.

A következő példában hat téglalapot hozunk létre az `Accent4` alapján, ötödikre luminancia transzformációt alkalmazunk, és elmentjük az eredményt:

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

Ezek a változatok a téma színén alapulnak. Ha a `Accent4` később változik, a transzformált színek az új `Accent4` értékből lesznek újraszámolva.

### **`SchemeColor` értékek leképezése az `IColorScheme` helyekre**

A [SchemeColor](https://reference.aspose.com/slides/hu/net/aspose.slides/schemecolor/) felsorolás a `Text1`, `Background1`, `Text2`, és `Background2` értékeket használja, míg az [IColorScheme](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/icolorscheme/) ugyanazokat a témahelyeket `Dark1`, `Light1`, `Dark2` és `Light2` néven teszi elérhetővé. A leképezés rögzített:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Ezek ugyanannak a témahelynek alternatív nevei; nem olyan értékek, amelyek dinamikusan konvertálódnak az egyik formából a másikba.

## **Téma betűtípusainak módosítása**

Egy téma betűtípus sémája egy fő betűtípus készletet tartalmaz a címsorokhoz és egy kisebb betűtípus készletet a szövegtesthez. A [FontScheme.Major](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/fontscheme/major/) és a [FontScheme.Minor](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/fontscheme/minor/) tulajdonságok ezeket a készleteket teszik elérhetővé.

PowerPoint‑kompatibilis téma betűtípus azonosítók használhatók a szövegformázásban:

* `+mn-lt` - Szöveg betűtípusa Latin (Minor Latin Font)
* `+mj-lt` - Címsor betűtípusa Latin (Major Latin Font)
* `+mn-ea` - Szöveg betűtípusa Kelet-Ázsiai (Minor East Asian Font)
* `+mj-ea` - Címsor betűtípusa Kelet-Ázsiai (Major East Asian Font)

A következő példa egy címsort hoz létre, amely a fő Latin téma betűtípust használja, és egy szövegsort, amely a kisebb Latin téma betűtípust használja. Ezután módosítja a téma betűtípusait és elmenti az eredményt:

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

A címsor a fő betűtípust, a szövegtest a kisebb betűtípust követi. A szöveg, amely explicite betűtárgy nevet tartalmaz a témaazonosító helyett, nem vált automatikusan, amikor a téma betűtípus sémája megváltozik.

{{% alert color="info" title="Tip" %}}
További információk a prezentáció betűtípusairól: lásd a [PowerPoint Fonts](/slides/hu/net/powerpoint-fonts/).
{{% /alert %}}

## **Téma másolása vagy alkalmazása**

Két gyakori munkafolyamat létezik, és különböző problémákat oldanak meg.

### **Forrás téma megőrzése diák áthelyezésekor**

Ha egy diákat egy másik prezentációba szeretné áthelyezni, miközben megőrzi az eredeti megjelenését, klónozza a forrás mastert a célprezentációba az [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/hu/net/aspose.slides/imasterslidecollection/addclone/) segítségével, majd klónozza a diát az [ISlideCollection.AddClone](https://reference.aspose.com/slides/hu/net/aspose.slides/islidecollection/addclone/) és a klónozott masterrel. Ez együtt viszi a mastert, annak elrendezéseit és a kapcsolódó témát.

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

Ez a preferált munkafolyamat, ha a forrásdiának ugyanúgy kell kinéznie a célnál. Egyszerűen a tartalom klónozása egy nem kapcsolódó célmasterre megváltoztathatja a téma által vezérelt színeket, betűtípusokat, háttereket és effektusokat.

### **Téma értékek alkalmazása meglévő diára**

Ha a céldiának a jelenlegi masterén és elrendezésén kell maradnia, inicializáljon egy diákszintű felülírást a forrás témából. Az [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/overridetheme/initfontschemefrom/), és [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/overridetheme/initformatschemefrom/) metódusok a három fő téma komponenst másolják a felülírásba.

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

Ez megváltoztatja a diára alkalmazott témát anélkül, hogy megváltoztatná a többi dia által örökölt témát. A helyi felülírás eltávolításához és az örökölt értékek visszaállításához hívja meg a [OverrideTheme.Clear](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/overridetheme/clear/).

### **Téma felülírás alkalmazása elrendezésre**

Egy elrendezés-szintű felülírás azokat a diákra vonatkozik, amelyek azt az elrendezést használják, kivéve, ha egy adott dia saját felülírással rendelkezik. Ugyanezen inicializációs metódusok használhatók az elrendezés [LayoutSlideThemeManager](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/layoutslidethememanager/) segítségével:

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

Használjon master vagy prezentáció-szintű témát, ha sok elrendezésnek és diáknak ugyanazt az alapdesign-t kell megosztania, egy elrendezés felülírást, ha egy elrendezéscsaládnak más stílusra van szüksége, és csak diákszintű felülírást valós esetekhez. A túl sok diákszintű felülírás nehezebbé teszi a későbbi globális téma változtatások előrejelzését.

## **Téma háttérstílusok frissítése**

A téma háttérkitöltései a [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) gyűjteményben vannak tárolva. A PowerPoint a felhasználói felületén több háttérválasztékot jeleníthet meg, mint a gyűjteményben fizikailag tárolt kitöltésdefiníciók száma, mivel a UI a téma kitöltéseket témaszínek és egyéb stílusreferenciák kombinációival képes összekapcsolni.

![PowerPoint háttérstílus galéria egy prezentáció témához](presentation-design_8.png)

Mielőtt háttérstílust használna, ellenőrizze a tárolt gyűjteményt és az aktuális [Background.StyleIndex](https://reference.aspose.com/slides/hu/net/aspose.slides/background/styleindex/). A `StyleIndex` a `0` értéket használja a témamentes kitöltéshez; a pozitív értékek a téma háttérstílusra mutató referenciák. Ez eltér attól, amikor a .NET gyűjteményt közvetlenül indexeli, ahol a `[0]` az első tárolt elemet jelenti. Ne feltételezze, hogy minden prezentáció ugyanannyi háttérkitöltés stílussal rendelkezik.

A következő példa jelzi a rendelkezésre álló háttérkitöltés számát, egy témás háttérreferenciát rendeli az első masterhez, és elmenti a prezentációt:

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

A látható eredmény a master által hivatkozott téma bejegyzésétől és az elrendezés vagy dia szintjén lévő háttér felülírásoktól függ. Ha egy dia saját háttérrel rendelkezik, a master háttér módosítása önmagában nem változtatja meg azt a diát. Használja a [Background.GetEffective](https://reference.aspose.com/slides/hu/net/aspose.slides/background/geteffective/) metódust, ha a végső háttér ismeretére van szükség az öröklődés alkalmazása után.

{{% alert color="warning" title="Warning" %}}
Ne kezelje a `StyleIndex`‑et nulláralapú gyűjtemény indexként. Kerülje a stílus számának egy fájlból történő hard‑kódolását és annak feltételezését, hogy egy másik fájlban ugyanúgy néz ki; a téma stílusdefiníciók prezentációnként eltérőek.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
A közvetlen háttérformázáshoz és háttéröröklődéshez lásd a [Presentation Background](/slides/hu/net/presentation-background/).
{{% /alert %}}

## **Téma effektusok frissítése**

Egy téma formátum séma különálló [FillStyles](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/formatscheme/fillstyles/), [LineStyles](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/formatscheme/linestyles/), és [EffectStyles](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/formatscheme/effectstyles/) gyűjteményeket tartalmaz. A tipikus Office témák gyakran három fő stílusbejegyzést tartalmaznak, amelyek vizuálisan a finom, közepes és intenzív formázásnak felelnek meg, de a kódnak minden gyűjteményt ellenőriznie kell ahelyett, hogy rögzített számot feltételezne.

![Finom, közepes és intenzív téma effektusok ugyanarra az alakzatra alkalmazva](presentation-design_10.png)

Amikor ezeket a gyűjteményeket C#‑ban érjük el, a gyűjtemény indexelése nulláralapú: a `[0]` az első tárolt stílus, a `[2]` a harmadik. Egy alakzat stílusreferencia indexei egy külön koncepció, amelyet az [IShapeStyle](https://reference.aspose.com/slides/hu/net/aspose.slides/ishapestyle/) tesz elérhetővé. Egy téma stílus módosítása azokra az alakzatokra hat, amelyek arra a téma stílusra hivatkoznak; a közvetlen formázású alakzatok változatlanul maradhatnak.

A következő példa ellenőrzi, hogy a szükséges stílusbejegyzések léteznek, megváltoztatja az első vonalstílust, a harmadik kitöltőstílust, engedélyezi a külső árnyékot a harmadik effektusstílusban, és elmenti az eredményt:

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

Azoknál az alakzatoknál, amelyek ezekre a helyekre hivatkoznak, az első téma vonalstílus piros lesz, a harmadik téma kitöltőstílus szilárd erdőzöld, és a harmadik effektusstílus külső árnyékot kap 10 pont távolsággal. A pontos vizuális eredmény még mindig attól függ, hogy mely stílushelyekre hivatkozik az egyes alakzat, és hogy a közvetlen formázás felülírja-e a témát.

![Téma effektus stílusok a vonal, kitöltés és árnyék beállítások módosítása után](presentation-design_11.png)

## **Hatékony téma értékek kiolvasása**

A nyers téma objektumok megmutatják, hogy mi van definiálva egy adott szinten. A hatékony értékek elmondják, hogy egy dia vagy alakzat valójában mit használ az öröklődés és a helyi felülírások feloldása után. Diához hívja a [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/). Háttérhez használja a [Background.GetEffective](https://reference.aspose.com/slides/hu/net/aspose.slides/background/geteffective/), kitöltéshez pedig a [FillFormat.GetEffective](https://reference.aspose.com/slides/hu/net/aspose.slides/fillformat/geteffective/) metódust.

A következő példa kiolvassa a hatékony témát, a hátteret és az első alakzat kitöltését egy diáról:

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

Használja a hatékony adatokat a renderelési diagnosztikához, validáláshoz és összehasonlításhoz. Ha csak a [Presentation.MasterTheme](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/mastertheme/) elemet ellenőrzi, elmulaszthat egy master, elrendezés, dia vagy alakzat felülírást, amely a végső megjelenést módosítja.

## **GYIK**

**Alkalmazhatok egy témát egyetlen diára anélkül, hogy a mastert módosítanám?**

Igen. Használja a dia [SlideThemeManager](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/slidethememanager/) objektumát és inicializálja annak felülírási témáját. A változás csak arra a diára vonatkozik; a többi dia továbbra is a meglévő témákat örökli.

**Mi a legbiztonságosabb módja egy téma átvitelének az egyik prezentációból a másikba?**

Amikor egy diát áthelyez és megőrzi a forrás megjelenését, klónozza a forrás mastert a célba, majd a diát azzal a masterrel a [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/hu/net/aspose.slides/imasterslidecollection/addclone/) és a [ISlideCollection.AddClone](https://reference.aspose.com/slides/hu/net/aspose.slides/islidecollection/addclone/) segítségével. Ez a mastert, az elrendezéseket és a témát együtt tartja.

**Hogyan tekinthetem meg a hatékony értékeket az öröklődés és felülírások után?**

Használja a [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) metódust egy dia vagy elrendezés téma esetén, valamint a megfelelő hatékony-adat metódusokat formátumobjektumokhoz, például a [Background.GetEffective](https://reference.aspose.com/slides/hu/net/aspose.slides/background/geteffective/) és a [FillFormat.GetEffective](https://reference.aspose.com/slides/hu/net/aspose.slides/fillformat/geteffective/). Ezek az API‑k a feloldott értékeket adják vissza az öröklődés és felülírások alkalmazása után.