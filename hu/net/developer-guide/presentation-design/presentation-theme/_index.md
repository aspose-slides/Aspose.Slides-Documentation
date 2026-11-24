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
- téma effekt
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Az Aspose.Slides for .NET fő prezentációs témái a PowerPoint fájlok létrehozásához, testreszabásához és konvertálásához egységes márkaarculattal."
---
## **Bevezetés**

A prezentációs téma egy koordinált szín-, betűtípus-, háttérstílus-, kitöltés-, vonal- és effektuskészletet határoz meg. A témát figyelembe vevő objektumok ezekre a közös definíciókra hivatkoznak ahelyett, hogy minden vizuális tulajdonságot rögzített értékként tárolnának, így egy téma módosítása egyszerre sok objektumot frissíthet.

Az Aspose.Slides-ban a prezentáció szintű téma a [Presentation.MasterTheme](https://reference.aspose.com/slides/net/aspose.slides/presentation/mastertheme/) tulajdonságon keresztül érhető el. Egy prezentáció tartalmazhat téma felülírásokat alacsonyabb szinteken is. Egy mester felülírhatja a prezentáció témáját a [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/net/aspose.slides.theme/masterthememanager/overridetheme/) segítségével, egy elrendezés felülírhatja az örökölt témáját a [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/net/aspose.slides.theme/baseoverridethememanager/overridetheme/) segítségével, és egy egyedi dia is ezt megteheti. Gyakorlatban egy dia hatékony témája ezen öröklődési láncon keresztül határozódik meg: prezentáció téma, mester felülírás, elrendezés felülírás és dia felülírás.

![Témaelemek: színek, betűtípusok, háttérstílusok és effektek](theme-constituents.png)

Az alábbi szakaszok a leggyakoribb téma munkafolyamatokat mutatják: egy téma ellenőrzése, színek és betűtípusok módosítása, egy téma másolása vagy alkalmazása, háttér- és effektusstílusok frissítése, valamint a hatékony értékek kiolvasása az öröklődés és felülírások feloldása után.

## **Téma megtekintése**

A [MasterTheme](https://reference.aspose.com/slides/net/aspose.slides.theme/mastertheme/) objektum exponálja a téma [ColorScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/mastertheme/colorscheme/), [FontScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/mastertheme/fontscheme/) és [FormatScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/mastertheme/formatscheme/) gyűjteményeit. Ezen gyűjtemények ellenőrzése módosítás előtt különösen hasznos, ha a prezentáció külső forrásból származik, mivel a stílusbejegyzések száma és tartalma változhat.

A következő példa beolvassa a fő téma tulajdonságait, és jelentést készít arról, hány háttér, kitöltés, vonal és effektus stílus van tárolva a témában:

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

Ha egy fájl több mestert használ, ne feltételezd, hogy minden dia ugyanazzal a hatékony témával rendelkezik. Ellenőrizd a diához társított mestert, és használd az alább bemutatott hatékony‑téma munkafolyamatot, ha elrendezési vagy dia felülírások lehetnek jelen.

## **Téma színeinek módosítása**

A témát figyelembe vevő kitöltések, vonalak és szöveg egy logikai színre hivatkozhat a [SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/schemecolor/) felsorolásból. Ha módosítod a megfelelő bejegyzést a téma [IColorScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/icolorscheme/) gyűjteményében, az összes olyan objektum, amely még mindig arra a téma színre hivatkozik, az új értékhez lesz feloldva. Azok az objektumok, amelyek közvetlen RGB színt használnak, nem változnak meg egy téma‑szín frissítéskor.

A következő vég‑végi példa egy olyan alakzatot hoz létre, amely `Accent4`‑et használ, a téma `Accent4` színét pirosra változtatja, menti a prezentációt, újra megnyitja, és kiírja a hatékony kitöltő színt:

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

Mivel a téglalap továbbra is a `Accent4`‑hez van kapcsolva, a látható színe pirosra változik a téma módosítása után. Ha a séma színt közvetlen színre cseréled az alakzaton, a későbbi `Accent4` változtatások már nem befolyásolják azt a kitöltést.

### **Színek használata a kiegészítő palettáról**

A PowerPoint világosabb és sötétebb változatokat származtat egy téma színből színtranszformációk alkalmazásával. Az Aspose.Slides ezeket a transzformációkat a [ColorTransformOperation](https://reference.aspose.com/slides/net/aspose.slides/colortransformoperation/) segítségével teszi elérhetővé.

![A fő téma színek és a kiegészítő palettáról generált világosabb és sötétebb színek](additional-palette-colors.png)

**1** – A fő téma színek.

**2** – A fő téma színekből előállított világosabb és sötétebb változatok.

A következő példa hat téglalapot hoz létre `Accent4` alapján, ötön luminancia‑transzformációt alkalmaz, és elmenti az eredményt:

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

Ezek a változatok továbbra is a téma színre épülnek. Ha a `Accent4` később változik, a transzformált színek az új `Accent4` értékből kerülnek újraszámításra.

### **`SchemeColor` értékek hozzárendelése az `IColorScheme` helyekhez**

A [SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/schemecolor/) felsorolás a `Text1`, `Background1`, `Text2` és `Background2` értékeket használja, míg az [IColorScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/icolorscheme/) ugyanazokat a témahelyeket `Dark1`, `Light1`, `Dark2` és `Light2` néven exponálja. A leképezés rögzített:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Ezek ugyanazon témahelyek alternatív nevei; nem dinamikusan átalakított értékek.

## **Téma betűtípusainak módosítása**

Egy téma betűtípuskészlet fő (major) betűtípust tartalmaz a címsorokhoz, és egy mellék (minor) betűtípust a törzsszöveghez. A [FontScheme.Major](https://reference.aspose.com/slides/net/aspose.slides.theme/fontscheme/major/) és a [FontScheme.Minor](https://reference.aspose.com/slides/net/aspose.slides.theme/fontscheme/minor/) tulajdonságok exponálják ezeket a készleteket.

PowerPoint‑kompatibilis téma betűtípus azonosítók használhatók a szövegformázásban:

* `+mn-lt` – Törzs betűtípus Latin (Minor Latin Font)
* `+mj-lt` – Címsor betűtípus Latin (Major Latin Font)
* `+mn-ea` – Törzs betűtípus Kelet-Ázsiai (Minor East Asian Font)
* `+mj-ea` – Címsor betűtípus Kelet-Ázsiai (Major East Asian Font)
* `+mn-cs` – Törzs betűtípus Komplex skript (Minor Complex Script Font)
* `+mj-cs` – Címsor betűtípus Komplex skript (Major Complex Script Font)

A következő példa létrehoz egy címsort, amely a fő latin téma betűtípust használ, és egy törzssort, amely a mellék latin téma betűtípust használ. Ezután megváltoztatja a téma betűtípusait és menti az eredményt:

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

A címsor a fő betűtípust, a törzsszöveg a mellék betűtípust követi. Egy kifejezetten megadott betűtípusnév, amely nem téma‑azonosító, nem vált automatikusan, amikor a téma‑betűtípuskészlet módosul.

A fő és mellék betűtípusgyűjtemények tartalmazhatnak betűtípus‑leképezéseket az egyes írásrendszerekhez, például cirill, arab, japán, grúz vagy thaana. Ezek ellenőrzéséhez, hozzáadásához, cseréjéhez vagy eltávolításához lásd a [Script-Specific Theme Fonts](/slides/hu/net/script-specific-font-mappings/) oldalt.

{{% alert color="info" title="Tip" %}}
További információkért a prezentáció betűtípusaival kapcsolatban lásd a [PowerPoint Fonts](/slides/hu/net/powerpoint-fonts/) oldalt.
{{% /alert %}}

### **Téma betűtű

hivatkozások feloldása**

A szöveg vizsgálatakor az [IFontData.FontName](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/fontname/) tartalmazhat olyan téma‑hivatkozást, mint a `+mn-lt`, ahelyett, hogy betűcsalád nevet adnál meg. Hívd meg az [IFontData.GetFontName](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/getfontname/)‑t a megfelelő [IThemeEffectiveData](https://reference.aspose.com/slides/net/aspose.slides.theme/ithemeeffectivedata/)‑val, hogy feloldja a hivatkozást. A `+mj` és `+mn` előtagok a fő‑ és mellék‑betűtípus készleteket választják; a `-lt`, `-ea` és `-cs` utótagok a latin, kelet‑ázsiai és komplex‑szkript betűtípusokat jelölik.

Szerezd meg a hatékony témát az [IThemeable.CreateThemeEffective](https://reference.aspose.com/slides/net/aspose.slides.theme/ithemeable/createthemeeffective/) hívásával azon objektumon, amelynek a témája a vizsgált szövegre vonatkozik. Egy dián lévő szokásos szöveg esetén használd a `slide.CreateThemeEffective()`‑t, hogy a kontextus tartalmazza a dia örökölt témáját és a helyi felülírásokat. Elrendezés vagy mester vizsgálatakor használd a saját hatékony témáját. Ne feltételezd, hogy az első mester témája minden diára érvényes.

A következő példa egy szövegrészt hoz létre, amely kifejezetten a mellék latin betűtípust hivatkozza. Egy diátéma‑betűtípus‑sémát inicializál a [IOverrideTheme.InitFontSchemeFromInherited](https://reference.aspose.com/slides/net/aspose.slides.theme/ioverridetheme/initfontschemefrominherited/) segítségével, és a fő‑ és mellék‑latin családokat `Arial`‑ra és `Calibri`‑ra állítja, így a példa bemeneti fájl nélkül is reprodukálható.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var theme = slide.ThemeManager.OverrideTheme;
theme.InitFontSchemeFromInherited();
theme.FontScheme.Major.LatinFont = new FontData("Arial");
theme.FontScheme.Minor.LatinFont = new FontData("Calibri");

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
shape.TextFrame.Text = "Text using the minor theme font";

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.PortionFormat.LatinFont = new FontData("+mn-lt");

var font = portion.PortionFormat.LatinFont;
var effectiveTheme = slide.CreateThemeEffective();
Console.WriteLine($"{font.FontName} -> {font.GetFontName(effectiveTheme)}");

var explicitFont = new FontData("Verdana");
Console.WriteLine($"{explicitFont.FontName} -> {explicitFont.GetFontName(effectiveTheme)}");
```

A kimenet `+mn-lt -> Calibri`, majd `Verdana -> Verdana`. A tárolt hivatkozás változatlan marad, míg a kifejezett családnevet változatlanul visszaadja. Ha a rész `+mj-lt`‑t használt volna, akkor ebben a témában `Arial`‑ra oldódna fel.

A téma‑hivatkozás feloldása megállapítja a téma által megadott betűcsaládot. Nem ellenőrzi a betűtípus elérhetőségét, illetve nem határozza meg, hogy a megjelenítés során végül melyik betűtípus‑fájl kerül használatra helyettesítés vagy glyph fallback után. Lásd a [Font Selection Sequence](/slides/hu/net/font-selection-sequence/) és a [Font Substitution](/slides/hu/net/font-substitution/) oldalakat a különálló lépésekhez.

## **Téma másolása vagy alkalmazása**

Az alábbi munkafolyamatok különböző téma‑kapcsolódó problémákat oldanak meg.

### **Külső téma alkalmazása egy mesterhez tartozó diákra**

Használd az [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/)‑t, ha PowerPoint téma fájlod (`.thmx`) van, és minden, egy adott mesterhez tartozó diát újrastílusozni szeretnél. Válaszd ki a mestert a [Presentation.Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) gyűjteményből, amely az [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/)‑t valósítja meg, és add át a téma fájl útvonalát a metódusnak.

A metódus a következő műveleteket hajtja végre:

1. Létrehoz egy új mesterdiát a kiválasztott mester alapján.
1. Alkalmazza a külső témát az új mesterre.
1. Az új mestert hozzárendeli minden diához, amely korábban a kiválasztott mesterhez tartozott.
1. Visszaadja a frissen létrehozott [IMasterSlide](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/)‑t.

A következő példa egy külső témát alkalmaz azokra a diákra, amelyek az első mestertől függnek, menti a prezentációt, és újra megnyitja az eredményt:

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

Érvénytelen, sérült vagy nem támogatott téma [PptxException](https://reference.aspose.com/slides/net/aspose.slides/pptxexception/) vagy annak formátumalapú alosztályait okozhatja. Ellenőrizd a felhasználók által megadott útvonalakat, kezeld a fájlrendszer‑hozzáférési hibákat, és csak a téma sikeres alkalmazása után mentsd a prezentációt.

Csak a kiválasztott mesterhez tartozó diákok kerülnek átírásra. Más mesterekhez tartozó diákok megtartják meglévő mestereiket és témáikat. A téma‑érzékeny színek, betűtípusok, kitöltések, vonalak, háttér és effektek a külső témához lesznek feloldva. A közvetlenül hozzárendelt színek, betűtípusok, kitöltések és egyéb explicit formázások változatlanok maradhatnak. Az elrendezés‑ és diaszintű felülírások szintén felülbírálhatják az új mesterből öröklött értékeket.

A téma hivatkozhat olyan betűtípusokra, amelyek a futási környezetben nem érhetők el. A következetes megjelenítés és export érdekében telepítsd a szükséges betűtípusokat, biztosítsd őket [egyedi betűtípus‑források](/slides/hu/net/custom-font/) révén, vagy konfiguráld a [betűtípus‑helyettesítést](/slides/hu/net/font-substitution/).

Ez egy közvetlen mester‑szintű munkafolyamat: a metódus egy `.thmx` fájl elérési útját várja, és nem igényel manuális diaszintű vagy elrendezés‑szintű téma‑felülírások létrehozását.

### **Különböző külső témák alkalmazása több‑mesteres prezentációban**

Ha a releváns mester nincs előre ismert, szerezd be egy reprezentatív dia segítségével a [ISlide.LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/islide/layoutslide/) és a [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/ilayoutslide/masterslide/) segítségével. A tényleges téma alkalmazása előtt tárold el az eredeti mester hivatkozásait, mivel minden hívás egy új mestert hoz létre a prezentációban.

A következő példa két szakaszból származó diák segítségével megkeresi a mestereket, és mindegyik csoportnál másik külső témát alkalmaz:

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

Az első hívás csak azokra a diákra van hatással, amelyek a `firstGroupMaster`‑re támaszkodnak, a második hívás csak a `secondGroupMaster`‑re támaszkodó diákokra. A többi mesterhez tartozó diákok nincsenek újrastílusozva.

### **Forrástéma megőrzése diák áthelyezésekor**

Ha egy diát egy másik prezentációba szeretnél áthelyezni, miközben megőrzöd az eredeti megjelenését, klónozd a forrás mestert a cél prezentációba az [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/addclone/) segítségével, majd klónozd a diát az [ISlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/addclone/)‑nal és a klónozott mesterrel. Ez a mester‑, elrendezés‑ és a kapcsolódó téma együttes átvitelét biztosítja.

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

Ez az előnyben részesített munkafolyamat, amikor a forrásdia pontosan ugyanúgy kell, hogy kinézzen a célhelyen. A tartalom egyszerű klónozása egy nem kapcsolódó célmestre megváltoztathatja a téma‑vezérelt színeket, betűtípusokat, háttérstílusokat és effekteket.

### **Témaértékek alkalmazása egy meglévő diára**

Ha a cél dia a jelenlegi mesterén és elrendezésén marad, inicializálj egy diaszintű felülírást a forrástémából. Az [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/net/aspose.slides.theme/overridetheme/initcolorschemefrom/), az [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/net/aspose.slides.theme/overridetheme/initfontschemefrom/) és az [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/net/aspose.slides.theme/overridetheme/initformatschemefrom/) metódusok a három fő téma‑komponenst másolják a felülírásba.

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

Ez a dia által használt témát módosítja anélkül, hogy a többi diára örökölt témát érintené. A helyi felülírás eltávolításához és az öröklött értékek visszaállításához hívd meg az [OverrideTheme.Clear](https://reference.aspose.com/slides/net/aspose.slides.theme/overridetheme/clear/)‑t.

### **Téma felülírásának alkalmazása egy elrendezésre**

Az elrendezés‑szintű felülírás az arra épülő diákra vonatkozik, kivéve, ha egy adott dia saját felülírással rendelkezik. Ugyanazokat az inicializáló metódusokat a layout [LayoutSlideThemeManager](https://reference.aspose.com/slides/net/aspose.slides.theme/layoutslidethememanager/)‑én keresztül is használhatod:

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

Használj mester‑ vagy prezentáció‑szintű témát, ha sok elrendezésnek és diáknak közös alaptervezést kell megosztania, egy elrendezés‑felülírást, ha egy elrendezéscsaládnak más stílusra van szüksége, és csak diaszintű felülírást a valódi kivételekhez. A túlzott diaszintű felülírások megnehezítik a későbbi globális téma‑módosítások előrejelzését.

## **Téma háttérstílusok frissítése**

A téma háttérkitöltései a [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/backgroundfillstyles/)‑ban vannak tárolva. A PowerPoint a felhasználói felületen több háttérválasztást mutathat meg, mint a gyűjteményben fizikailag tárolt kitöltésdefiníciók száma, mivel a UI kombinálhat téma‑kitöltéseket téma‑színekkel és más stílus‑hivatkozásokkal.

![PowerPoint háttérstílus galéria egy prezentációs témához](presentation-design_8.png)

Mielőtt háttérstílust használnál, ellenőrizd a tárolt gyűjteményt és a jelenlegi [Background.StyleIndex](https://reference.aspose.com/slides/net/aspose.slides/background/styleindex/) értéket. A `StyleIndex` a `0`‑t használja "nincs téma‑kitöltés" esetén; a pozitív értékek téma‑háttér‑stílus hivatkozások. Ez különbözik a .NET gyűjtemény közvetlen indexelésétől, ahol a `[0]` az első tárolt elemet jelenti. Ne feltételezd, hogy minden prezentáció ugyanannyi háttérkitöltési stílussal rendelkezik.

A következő példa kiírja a rendelkezésre álló háttérkitöltések számát, egy téma‑háttér‑hivatkozást ad az első mesterhez, és elmenti a prezentációt:

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

A látható eredmény a mester által hivatkozott téma‑bejegyzéstől és az elrendezés‑ vagy diaszintű háttér‑felülírásoktól függ. Ha egy dia saját háttérrel rendelkezik, a csak a mester háttér módosítása nem feltétlenül változtatja meg azt a diát. Használd a [Background.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/background/geteffective/)‑t, ha a végső, öröklődés után alkalmazott háttérre van szükséged.

{{% alert color="warning" title="Warning" %}}
Ne kezeld a `StyleIndex`‑et nullával kezdődő gyűjtemény‑indexként. Kerüld a stilusszámok hard‑kódolását egyik fájlból a másikba, mivel a téma‑stílusdefiníciók prezentációnként eltérnek.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Közvetlen háttérformázáshoz és háttér‑öröklődéshez lásd a [Presentation Background](/slides/hu/net/presentation-background/) oldalt.
{{% /alert %}}

## **Téma effektek frissítése**

A téma formátumsémája külön [FillStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/fillstyles/), [LineStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/linestyles/) és [EffectStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/effectstyles/) gyűjteményeket tartalmaz. A tipikus Office‑témák gyakran három fő stílusbejegyzést tartalmaznak, amely vizuálisan finom, mérsékelt és intenzív formázásnak felel meg, de a kód mindig ellenőrizze a gyűjteményeket a fix mennyiség helyett.

![Finom, közepes és intenzív témaeffektek ugyanarra az alakra alkalmazva](presentation-design_10.png)

Amikor ezeket a gyűjteményeket C#‑ben éred el, a gyűjtemény‑index nullával kezdődik: a `[0]` az első tárolt stílus, a `[2]` a harmadik. Egy alakzat style‑referencia indexei egy külön fogalom, amelyet az [IShapeStyle](https://reference.aspose.com/slides/net/aspose.slides/ishapestyle/) exponál. Egy téma‑stílus módosítása azokra az alakzatokra hat, amelyek arra a téma‑stílusra hivatkoznak; a közvetlen formázással ellátott alakzatok változatlanok maradhatnak.

A következő példa ellenőrzi, hogy a szükséges stílusbejegyzések léteznek-e, módosítja az első vonal‑stílust, a harmadik kitöltő‑stílust, engedélyezi a kívülről származó árnyékot a harmadik effektus‑stílusban, és elmenti az eredményt:

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

A vonal‑stílusokra hivatkozó alakzatoknál az első téma‑vonal‑stílus pirosra változik, a harmadik téma‑kitöltő‑stílus szilárd erdei zöldre, a harmadik effektus‑stílus pedig egy 10 pont távolságú külső árnyékot kap. A pontos vizuális eredmény továbbra is attól függ, hogy melyik stílushelyet hivatkozza az egyes alakzat, és hogy a közvetlen formázás felülírja‑e a témát.

![Témaeffektus stílusok vonal, kitöltés és árnyék beállítások módosítása után](presentation-design_11.png)

## **Alakzatra vonatkozó téma‑kitöltés és vonal‑stílusok kiválasztása**

Egy alakzat függetlenül kiválaszthatja a kitöltését és a körvonalát a [FillStyleIndex](https://reference.aspose.com/slides/net/aspose.slides/ishapestyle/fillstyleindex/) és a [LineStyleIndex](https://reference.aspose.com/slides/net/aspose.slides/ishapestyle/linestyleindex/) segítségével. Mindkét tulajdonságnál az `1` index a megfelelő téma‑gyűjtemény első bejegyzését (`FillStyles[0]` vagy `LineStyles[0]`) választja, a `2` a második bejegyzést.

A következő példa két kitöltési stílust (arany és égkék) és két vonal‑stílust (sötétkék 6 pt‑nél és sötétvörös 12 pt‑nél) állít be egy új prezentáció alap‑témájában. A diát három szakaszban menti, hogy PowerPoint‑ban összehasonlíthasd az eredményeket.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var styles = presentation.MasterTheme.FormatScheme;

var goldFill = styles.FillStyles[0];
goldFill.FillType = FillType.Solid;
goldFill.SolidFillColor.Color = Color.Gold;
var blueFill = styles.FillStyles[1];
blueFill.FillType = FillType.Solid;
blueFill.SolidFillColor.Color = Color.SkyBlue;

var thinLine = styles.LineStyles[0];
thinLine.FillFormat.FillType = FillType.Solid;
thinLine.FillFormat.SolidFillColor.Color = Color.DarkBlue;
thinLine.Width = 6;
var thickLine = styles.LineStyles[1];
thickLine.FillFormat.FillType = FillType.Solid;
thickLine.FillFormat.SolidFillColor.Color = Color.DarkRed;
thickLine.Width = 12;

var shapes = presentation.Slides[0].Shapes;
var left = shapes.AddAutoShape(ShapeType.Rectangle, 100, 205, 200, 130);
var right = shapes.AddAutoShape(ShapeType.Rectangle, 420, 205, 200, 130);
left.ShapeStyle.FillStyleIndex = 1;
right.ShapeStyle.FillStyleIndex = 2;
left.ShapeStyle.LineStyleIndex = 1;
right.ShapeStyle.LineStyleIndex = 1;
presentation.Save("01-initial.pptx", SaveFormat.Pptx);

right.ShapeStyle.LineStyleIndex = 2;
presentation.Save("02-line-changed.pptx", SaveFormat.Pptx);

goldFill.SolidFillColor.Color = Color.SeaGreen;
presentation.Save("03-theme-changed.pptx", SaveFormat.Pptx);
```

| Kezdeti stílusok | Jobb körvonal módosítása | Első téma‑kitöltés szerkesztése |
|:---:|:---:|:---:|
| ![Arany és az égkék téglalapok illeszkedő vékony sötétkék körvonalakkal](theme-style-initial.png) | ![Az égkék téglalap most vastag sötétvörös körvonalat kap](theme-style-line-changed.png) | ![A bal téglalap most zöld, és mindkét körvonal változatlan](theme-style-fill-changed.png) |

Másik vonal‑stílus kiválasztása csak a jobb téglalap körvonalát módosítja. Az első téma‑kitöltés szerkesztése minden olyan alakzatra hat, amely azt használja. Itt csak a bal téglalap válik zöldre.

Egy meglévő alakzatra a helyi kitöltő‑szín, vonal‑szín vagy vonal‑szélesség felülírhatja a téma‑stílus ennek a részének. Ha egy stílus‑index módosítása nem hoz látható változást, ellenőrizd az alakzat [közvetlen formázását](/slides/hu/net/shape-formatting/).

## **Megállapítás, hogy egy hatékony szilárd kitöltés téma‑színt használ‑e**

Egy kitöltés lehet közvetlenül az objektumon tárolva vagy örökölt egy bekezdésből, elrendezésből, mesterből, téma‑stílusból vagy egy másik formázási szintből. Hívd meg a [IFillFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/geteffective/)‑t, hogy ezt a hierarchiát átalakítsd egy változtathatatlan [IFillFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ifillformateffectivedata/) objektummá. Először ellenőrizd a [IFillFormatEffectiveData.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformateffectivedata/filltype/) értékét. Csak ha `FillType.Solid`, olvasd a szilárd‑kitöltés tulajdonságait.

Szilárd kitöltés esetén a [IFillFormatEffectiveData.SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformateffectivedata/solidfillcolor/) a végleges renderelt RGB értéket adja vissza az öröklődés, téma‑keresés és színtranszformációk alkalmazása után. A [IFillFormatEffectiveData.SolidFillSchemeColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformateffectivedata/solidfillschemecolor/) a megfelelő logikai [SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/schemecolor/) slot‑ot adja vissza, például `Text1` vagy `Accent6`. A `SchemeColor.NotDefined` érték azt jelenti, hogy a hatékony szilárd kitöltés nem egy séma‑színen alapul. Egy olyan munkafolyamatban, ahol a kitöltések csak téma‑színek vagy közvetlen RGB‑színek lehetnek, ez az érték egy közvetlen RGB‑kitöltést azonosít.

Ne csak a helyi [IColorFormat.SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/schemecolor/) értékét használd a kitöltés osztályozásához. Például egy szövegrésznek lehet nincs helyi séma‑színe (`NotDefined`), míg a hatékony kitöltése egy téma‑színre hagyatkozik, és `Text1`‑re vagy `Accent6`‑ra oldódik fel. Ezzel szemben a `SolidFillSchemeColor` megmondja, mely logikai téma‑slot adta a hatékony színt, de nem mutatja, hogy a slot az objektumból, bekezdésből, elrendezésből, mesterből vagy más szintből származik.

A következő példa betölt egy prezentációt, auditálja a forma‑ és szövegrész‑kitöltéseket, kiírja minden végső RGB értéket és a kapcsolódó séma‑színt, és jelzi azokat a szilárd kitöltéseket, amelyek nem követik a téma‑színváltozásokat:

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

A `NotDefined` ágba azok a szilárd kitöltések kerülnek, amelyek nem fognak reagálni a téma‑színszlotok változására. Ezeket az objektumokat akkor kell felülvizsgálni, amikor egy prezentációnak új márka‑palettát kell követnie. A jelentett RGB érték még mindig a jelenlegi megjelenést mutatja, míg a séma‑érték megmagyarázza, hogy ez a megjelenés kapcsolódik‑e a témához.

A hatékony‑formátum objektumok pillanatképek. A prezentáció téma, egy téma‑felülírás vagy bármely örökölt formázás módosítása után hívd meg újra a `GetEffective`‑et, és olvasd ki az új `IFillFormatEffectiveData` objektumot, mielőtt színeket hasonlítanál vagy jelentened.

## **Hatékony témaértékek olvasása**

A nyers témaobjektumok azt mutatják, mi van definiálva egy adott szinten. A hatékony értékek azt mutatják, mit használ egy dia vagy forma az öröklődés és a helyi felülírások feloldása után. Egy dián hívd meg a [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/)‑t. Háttér esetén a [Background.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/background/geteffective/)‑t, kitöltésnél pedig a [FillFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/fillformat/geteffective/)‑t.

A következő példa beolvassa a hatékony témát, a háttér‑stílust és az első forma‑kitöltést egy diáról:

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

Használd a hatékony adatokat renderelési diagnosztikához, validációhoz és összehasonlításokhoz. Ha csak a [Presentation.MasterTheme](https://reference.aspose.com/slides/net/aspose.slides/presentation/mastertheme/)‑t ellenőrzöd, elmulaszthatod a egyes mesterek, elrendezések, diák vagy formák felülírásait, amelyek a végső megjelenést változtatják.

## **GYIK**

**Az külső téma alkalmazása befolyásolja-e a prezentáció minden diát?**

Nem. Az [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) csak azoknak a diáknak a mesterét rendeli át, amelyek a kiválasztott mesterhez tartoznak. Az más mestereket használó diák megőrzik meglévő témáikat.

**Alkalmazhatok‑e egy témát egyetlen diára a mester módosítása nélkül?**

Igen. Használd a dia [SlideThemeManager](https://reference.aspose.com/slides/net/aspose.slides.theme/slidethememanager/)‑t, és inicializáld a felülírási témáját. A változás csak a kérdéses diára lesz lokális; a többi dia továbbra is örökli a meglévő témáját.

**Mi a legbiztonságosabb módja egy téma átvitelének egyik prezentációból a másikba?**

Ha egy diát áthelyezel, és meg akarod őrizni a forrás‑megjelenést, klónozd a forrás mestert a célhelyre az [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/addclone/)‑nal, majd a diát a [ISlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/addclone/)‑nal és a klónozott mesterrel. Ez együtt tartja a mestert, az elrendezéseket és a témát.

**Hogyan tekinthetem meg a hatékony értékeket az öröklődés és felülírások után?**

Használd a [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/)‑t egy dia vagy elrendezés téma esetén, valamint a megfelelő hatékony‑adat módszereket formátumobjektumokhoz, például a [Background.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/background/geteffective/) és a [FillFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/fillformat/geteffective/)‑t. Ezek az API‑k a öröklődés és a felülírások alkalmazása után feloldott értékeket adják vissza.