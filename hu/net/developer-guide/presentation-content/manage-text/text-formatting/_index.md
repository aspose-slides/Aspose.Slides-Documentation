---
title: Prezentáció szövegének formázása .NET-ben
linktitle: Szövegformázás
type: docs
weight: 50
url: /hu/net/text-formatting/
keywords:
- bekezdés igazítása
- szövegstílus
- szöveg háttér
- szöveg átlátszóság
- karaktertávolság
- betűtulajdonságok
- betűcsalád
- szöveg forgatás
- forgatási szög
- szövegdoboz
- sortávolság
- automatikus méretezés tulajdonság
- szövegdoboz rögzítése
- szöveg tabulálása
- alapértelmezett nyelv
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Formázza és stílusozza a szöveget PowerPoint és OpenDocument prezentációkban az Aspose.Slides for .NET használatával. Testreszabhatja a betűtípusokat, színeket, igazítást és egyebeket."
---
## **Áttekintés**

Ez a cikk azt mutatja be, hogyan formázható a szöveg PowerPoint és OpenDocument prezentációkban az Aspose.Slides for .NET segítségével. Kitér a háttérszínekre, átlátszóságra, karaktertávolságra, betűtulajdonságokra, forgatásra, bekezdésszakaszra, automatikus méretezés viselkedésére, szöveg rögzítésére, tabulátorokra és nyelvi beállításokra.

Hacsak másként nincs feltüntetve, a példák a [sample.pptx](sample.pptx) fájlt használják. Az első dián az első alakzat egy szövegdoboz, és az első bekezdés tartalmazza az alább látható szöveget. Mind a dia, mind az alakzat indexei nulláristól indulnak. A félkövér részeket kiválasztó példák a hatékony formázást, beleértve az örökölt félkövér formázást használják:

![Sample text](sample_text.png)

A szó szerinti szöveg vagy reguláris kifejezés egyezések megtalálásához és kiemeléséhez tekintse meg a [Szöveg keresése és cseréje](/slides/hu/net/search-and-replace-text/).

## **Szöveg hátterének szín beállítása**

Használja az [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) ahhoz, hogy beállítsa egy bekezdés alapértelmezett kiemelési színét, vagy használja az [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/highlightcolor/) egyedi szövegrészekhez.

Az alábbi példa egy világosszürke kiemelést állít be alapértelmezettként az első bekezdéshez. Az egyedi részekre megadott kiemelési színek felülbírálják ezt az alapértelmezést:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Állítsa be a teljes bekezdés kiemelési színét.
paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
```

Az eredmény:

![A szürke bekezdés](gray_paragraph.png)

Az alábbi kódrészlet bemutatja, hogyan állítható be a háttérszín **félkövér betűtípussal rendelkező szövegrészekhez**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // Állítsa be a szövegrész kiemelési színét.
        portion.PortionFormat.HighlightColor.Color = Color.LightGray;
    }
}

presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
```

Az eredmény:

![A szürke szövegrészek](gray_text_portions.png)

## **Szöveg bekezdések igazítása**

Használja az [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) a bekezdés igazításának beállításához egy szövegdobozon belül. Az érték lehet középre, balra, jobbra igazított, sorkizárt stb.

Az alábbi kódrészlet mutatja, hogyan igazítható a bekezdés **középre**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Állítsa be a bekezdés igazítását középre.
paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
```

Az eredmény:

![Az igazított bekezdés](aligned_paragraph.png)

## **Betűk igazítása soron belül**

Használja az [IParagraphFormat.FontAlignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/fontalignment/) a szövegrészek függőleges igazításához különböző betűméretekkel egy soron belül. Ez a beállítás a teljes bekezdésre vonatkozik, és szabályozza az egyes sorokban való igazítást.

Az alábbi önálló példa négy felirattal ellátott szövegdobozt hoz létre egy dián. Minden bekezdés ugyanazt a szöveget tartalmazza 18, 36 és 54 pont méretben, különböző betűigazítással. Az Arial betűtípust használja, letiltja az automatikus méretezést és a tördelést, és a szövegdobozokat elég nagyra állítja egy sor számára.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var alignments = new[] { FontAlignment.Baseline, FontAlignment.Top, FontAlignment.Center, FontAlignment.Bottom };
var fontSizes = new[] { 18f, 36f, 54f };

for (var i = 0; i < alignments.Length; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 20 + i * 130, 660, 120);
    shape.FillFormat.FillType = FillType.NoFill;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;

    var textFrame = shape.TextFrame;
    textFrame.TextFrameFormat.AnchoringType = TextAnchorType.Top;
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
    textFrame.TextFrameFormat.WrapText = NullableBool.False;

    var label = textFrame.Paragraphs[0];
    label.Text = alignments[i].ToString();
    label.ParagraphFormat.Alignment = TextAlignment.Left;
    label.ParagraphFormat.DefaultPortionFormat.FontHeight = 14;
    label.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Arial");
    label.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    label.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;

    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.FontAlignment = alignments[i];
    paragraph.ParagraphFormat.Alignment = TextAlignment.Left;
    paragraph.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Arial");
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

    foreach (var fontSize in fontSizes)
    {
        var portion = new Portion("Ag ");
        portion.PortionFormat.FontHeight = fontSize;
        paragraph.Portions.Add(portion);
    }

    textFrame.Paragraphs.Add(paragraph);
}

presentation.Save("font_alignment.pptx", SaveFormat.Pptx);
```

Az eredmény:

![A Baseline, Top, Center és Bottom betűigazítás összehasonlítása vegyes betűméretekkel](font_alignment.png)

A betűigazítás betűmetrikákat használ, így az egyes betűk látható szélei nem feltétlenül illeszkednek pontosan. A példa egy nagybetűt és egy lejjebb nyúló karaktert is tartalmaz, hogy bemutassa a baseline és az alulra igazítás közti különbséget. A betűk elérhetősége és helyettesítése, a használt karakterek és a betűméretek különbsége befolyásolja az eredményt. A keretméretek, margók, sorköz, tördelés és automatikus méretezés szintén hatnak a elrendezésre; a módok összehasonlításakor használjon azonos betűket és elrendezési beállításokat.

Ez a beállítás különbözik a [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) beállítástól, amely a bekezdés vízszintes igazítását szabályozza, és a [ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/) beállítástól, amely a szövegtömb függőleges elhelyezkedését az alakzaton belül határozza meg. A felső- és alsó index formázása az [IBasePortionFormat.Escapement](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/escapement/) segítségével az egyes részeket a baseline-hez képest eltolja ahelyett, hogy a bekezdés sorainak betűigazítását állítaná be.

## **Szöveg átlátszóságának beállítása**

A szöveg átlátszóságát a [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/) színének alfa komponensével szabályozzuk. Az alábbi példákban a `alpha = 50` egy ARGB alfa-csatorna érték a 0‑255 skálán, nem pedig átlátszósági százalék.

Az alábbi kódrészlet bemutatja, hogyan alkalmazható átlátszóság a **teljes bekezdésre**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Állítsa be a szöveg félig átlátszó fekete kitöltését.
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
```

Az eredmény:

![Az átlátszó bekezdés](transparent_paragraph.png)

Az alábbi kódrészlet bemutatja, hogyan alkalmazható átlátszóság **félkövér betűtípussal rendelkező szövegrészekre**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // Állítsa be a szövegrész átlátszóságát.
        portion.PortionFormat.FillFormat.FillType = FillType.Solid;
        portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);
    }
}

presentation.Save("transparent_text_portions.pptx", SaveFormat.Pptx);
```

Az eredmény:

![Az átlátszó szövegrészek](transparent_text_portions.png)

## **Karaktertávolság beállítása szövegnél**

Használja az [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/spacing/) a karakterek közti távolság növeléséhez vagy szűkítéséhez egy szövegdobozban. A példák 3 pont távolságot adnak hozzá; a negatív értékek szűkítik a szöveget.

Az alábbi C# kód bemutatja, hogyan növelhető a karaktertávolság a **teljes bekezdésben**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Megjegyzés: Használjon negatív értékeket a karaktertávolság szorításához.
paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // Karaktertávolság növelése.

presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
```

Az eredmény:

![A karaktertávolság a bekezdésben](character_spacing_in_paragraph.png)

Az alábbi kódrészlet bemutatja, hogyan növelhető a karaktertávolság **félkövér betűtípussal rendelkező szövegrészekben**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // Megjegyzés: Használjon negatív értékeket a karaktertávolság szorításához.
        portion.PortionFormat.Spacing = 3;  // Karaktertávolság növelése.
    }
}

presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
```

Az eredmény:

![A karaktertávolság a szövegrészekben](character_spacing_in_text_portions.png)

### **Kernálás letiltása bizonyos betűtípusoknál**

Bizonyos esetekben az Aspose.Slides által megjelenített szöveg kissé szorosabb lehet, mint ugyanaz a szöveg a PowerPointban. Ez akkor fordulhat elő, ha a PowerPoint egyes betűtípusoknál figyelmen kívül hagyja a kernálási adatokat, még akkor is, ha a betűtípus tartalmaz érvényes kernálási információt, és a PowerPoint beállításaiban a kernálás engedélyezve van.

Az ilyen esetekben a megjelenített kimenet közelebb hozásához a PowerPointhoz, letilthatja a kernálást a szóban forgó betűtípust használó szövegrészeknél. Állítsa be az [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kerningminimalsize/) értékét nagyobbra, mint a tényleges betűméret. Ez a példa a "presentation.pptx" fájlt igényli, amelynek az első dián az első alakzat egy szövegdoboz. Ellenőrzi a hatékony betűneveket, beleértve az örökölt betűket, és 100 pontos küszöböt állít be a Roboto‑t használó részekhez. Ez letiltja a kernálást az olyan részeknél, amelyek betűmérete 100 pont alatti:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var targetFont = "Roboto";

foreach (var paragraph in autoShape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var textFormat = portion.PortionFormat.GetEffective();
        
        var usesTargetFont = textFormat.LatinFont?.FontName == targetFont || 
            textFormat.EastAsianFont?.FontName == targetFont || 
            textFormat.ComplexScriptFont?.FontName == targetFont;

        if (usesTargetFont)
        {
            portion.PortionFormat.KerningMinimalSize = 100;
        }
    }
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

A küszöb alatti egyező szöveg esetén ez a beállítás megakadályozza a kernálást, és segíthet az Aspose.Slides megjelenítésének összehangolásában a PowerPoint vizuális kimenetével azoknál a betűtípusoknál, amelyeket ez a PowerPoint‑specifikus viselkedés befolyásol.

## **Szöveg betűtulajdonságainak kezelése**

A betűtulajdonságok beállíthatók a bekezdés szintjén az [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) vagy egyes részeknél az [IPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/) segítségével.

Az alábbi példa az első bekezdés alapértelmezett betűtípusát 12 pontos Times New Roman-ra állítja félkövér, dőlt és pontozott aláhúzással. Az egyes részekre megadott formázás felülbírálja ezeket az alapértelmezéseket.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Állítsa be a bekezdés betűtulajdonságait.
var portionFormat = paragraph.ParagraphFormat.DefaultPortionFormat;
portionFormat.FontHeight = 12;
portionFormat.FontBold = NullableBool.True;
portionFormat.FontItalic = NullableBool.True;
portionFormat.FontUnderline = TextUnderlineType.Dotted;
portionFormat.LatinFont = new FontData("Times New Roman");

presentation.Save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
```

Az eredmény:

![A betűtulajdonságok a bekezdéshez](font_properties_for_paragraph.png)

Az alábbi példa 13 pontos Times New Roman, dőlt formázás és pontozott aláhúzás alkalmazását mutatja be azokban a részekben, amelyek hatékony formázása félkövér:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // Állítsa be a betűtulajdonságokat a szövegrészhez.
        portion.PortionFormat.FontHeight = 13;
        portion.PortionFormat.FontItalic = NullableBool.True;
        portion.PortionFormat.FontUnderline = TextUnderlineType.Dotted;
        portion.PortionFormat.LatinFont = new FontData("Times New Roman");
    }
}

presentation.Save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
```

Az eredmény:

![A betűtulajdonságok a szövegrészekhez](font_properties_for_text_portions.png)

## **Szövegmagasság normalizálásának vezérlése**

Használja az [IBasePortionFormat.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/normaliseheight/) sablon tipográfia reprodukciójánál vagy a karaktermagasság különbségeinek vizsgálatánál. PowerPointban a normalizálás engedélyezése függőlegesen nyújtja vagy összenyomja az egyes karaktereket, hogy egységes látható magasságot kapjanak a szövegrészben. Nem garantálja a különböző betűtípusok közötti azonos magasságot.

Állítsa a tulajdonságot [NullableBool.True vagy False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) értékre a normalizálás kifejezett engedélyezéséhez vagy letiltásához. A `NullableBool.NotDefined` a helyi beállítást üresen hagyja, így a részörökíti az értéket, például a bekezdés [DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) értékét. Ez nem jelenti a `False` értéket. Használja az [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) és olvassa a [IBasePortionFormatEffectiveData.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformateffectivedata/normaliseheight/) értéket a feloldott logikai értékhez.

Az alábbi önálló példa az **Arial** telepítését igényli. Két szövegbloport hoz létre, amelyek ugyanazt a nagy- és kisbetűs, lejjebb nyúló és ékezetes karaktereket tartalmazzák 54 pont méretben. Mindkét bekezdés alapértelmezés szerint engedélyezi a normalizálást. A felső rész kifejezetten letiltja, az alsó rész örökli. A keretméretek, margók és bekezdésközök azonosak, a tördelés és az automatikus méretezés le van tiltva a következetes összehasonlítás érdekében. A példa kiírja a `False: False` és `NotDefined: True` értékeket, majd elmenti a "text_height_normalization.pptx" fájlt.

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var settings = new[] { NullableBool.False, NullableBool.NotDefined };

for (var i = 0; i < settings.Length; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 60 + i * 200, 660, 150);
    shape.FillFormat.FillType = FillType.NoFill;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;

    var textFrame = shape.TextFrame;
    textFrame.Text = "Hxgjpq ÅÉ 0123";
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
    textFrame.TextFrameFormat.WrapText = NullableBool.False;
    textFrame.TextFrameFormat.AnchoringType = TextAnchorType.Top;
    textFrame.TextFrameFormat.MarginTop = 0;
    textFrame.TextFrameFormat.MarginLeft = 0;

    var paragraph = textFrame.Paragraphs[0];
    paragraph.ParagraphFormat.Alignment = TextAlignment.Left;
    paragraph.ParagraphFormat.SpaceBefore = 0;
    paragraph.ParagraphFormat.SpaceAfter = 0;
    paragraph.ParagraphFormat.SpaceWithin = 100;
    paragraph.ParagraphFormat.DefaultPortionFormat.NormaliseHeight = NullableBool.True;

    var portion = paragraph.Portions[0];
    portion.PortionFormat.LatinFont = new FontData("Arial");
    portion.PortionFormat.FontHeight = 54;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.NormaliseHeight = settings[i];

    Console.WriteLine($"{settings[i]}: {portion.PortionFormat.GetEffective().NormaliseHeight}");
}

presentation.Save("text_height_normalization.pptx", SaveFormat.Pptx);
```

Az alábbi összehasonlítás a mentett prezentációból lett exportálva. A felső sorban a normalizálás le van tiltva (`False`); az alsó sorban örökli a bekapcsolt beállítást (`NotDefined` → `True`). A megjelenés reprodukálásához tartsa telepítve az Arial‑t.

![Arial 54 pontos szöveg a normalizálás kikapcsolásával felül és az örökölt normalizálás engedélyezett állapottal alul](text_height_normalization.png)

A normalizálás a karaktermagasságot változtatja anélkül, hogy a [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/) értéke változna, ami a betűméretet pontban adja meg. A bekezdés [SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) szabályozza a sortávolságot, míg a szövegdoboz [AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) szabályozza, hogy a szöveg vagy a keret hogyan alkalmazkodik a mérethez. Ezek a beállítások külön célokat szolgálnak, és önállóan befolyásolhatják az elrendezést. A bekezdés formázásáról és öröklődéséről további információért tekintse meg a [Manage Paragraph](/slides/hu/net/manage-paragraph/) cikket.

## **Kihúzás alkalmazása és eltávolítása**

Használja a [IBasePortionFormat.StrikethroughType](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/strikethroughtype/) egy szövegrészen, hogy javításokat, törölt kifejezéseket vagy korábbi árakat jelenítsen meg anélkül, hogy törölné az eredeti szöveget. Állítsa [TextStrikethroughType.Single vagy Double](https://reference.aspose.com/slides/net/aspose.slides/textstrikethroughtype/) értékre egy vagy két vonal megjelenítéséhez a szöveg felett.

A kihúzás eltávolításához adja meg a `TextStrikethroughType.None` értéket. Ez kifejezetten letiltja a hatást, még ha a környező formázás meghatározza a kihúzást is. Ezzel szemben a `TextStrikethroughType.NotDefined` a helyi beállítást nem definiálja, lehetővé téve a rész számára, hogy örökölje a formázást, például a bekezdéstől. Nem garantálja, hogy a kihúzás eltávolításra kerül. Használja az [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) metódust a végső formázás, beleértve az örökölt értékek, kiolvasásához.

Az alábbi önálló példa három árösszehasonlítást hoz létre. Minden bekezdésnek külön részei vannak a címke, a korábbi ár és a jelenlegi ár számára, így csak a korábbi ár érintett. Az első sor alkalmazza, majd eltávolítja a kihúzást; a többi sor egy‑ és dupla kihúzást tartogat. Ennek a tulajdonságnak a módosítása megőrzi a szöveget és más formázását, beleértve a félkövér korábbi árat is.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 620, 220);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.NoFill;
shape.TextFrame.Paragraphs.Clear();

var labels = new[] { "None: ", "Single: ", "Double: " };

foreach (var label in labels)
{
    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.Alignment = TextAlignment.Left;
    paragraph.ParagraphFormat.SpaceAfter = 20;

    var format = paragraph.ParagraphFormat.DefaultPortionFormat;
    format.FontHeight = 28;
    format.LatinFont = new FontData("Arial");
    format.FillFormat.FillType = FillType.Solid;
    format.FillFormat.SolidFillColor.Color = Color.Black;

    paragraph.Portions.Add(new Portion(label));

    var previousPrice = new Portion("$100");
    previousPrice.PortionFormat.FontBold = NullableBool.True;
    paragraph.Portions.Add(previousPrice);
    paragraph.Portions.Add(new Portion(" → $80"));
    
    shape.TextFrame.Paragraphs.Add(paragraph);
}

var paragraphs = shape.TextFrame.Paragraphs;

// Alkalmazza a áthúzást, majd kifejezetten eltávolítja azt az első előző árnál.
paragraphs[0].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Single;
paragraphs[0].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.None;

paragraphs[1].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Single;
paragraphs[2].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Double;

presentation.Save("strikethrough.pptx", SaveFormat.Pptx);
```

Az eredmény, fentről lefelé: nincs kihúzás, egy vonallal kihúzva és dupla vonallal kihúzva.

![Az előző árak kihúzás nélkül, egy vonallal kihúzva és dupla vonallal kihúzva](strikethrough.png)

## **Szöveg forgatásának beállítása**

Használja az [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/textverticaltype/) előre definiált szövegorientáció beállításához egy alakzaton belül.

Az alábbi kódrészlet a szöveg orientációját a [TextVerticalType.Vertical270](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/) értékre állítja, amely **90 fokkal az óramutató járásával ellentétesen** forgatja a szöveget:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

presentation.Save("text_rotation.pptx", SaveFormat.Pptx);
```

Az eredmény:

![A szöveg forgatása](text_rotation.png)

## **Egyéni forgatás beállítása szövegdobozokhoz**

Használja az [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/rotationangle/) egyedi forgatási szög beállításához egy [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) számára.

Az alábbi kódrészlet a szövegdobozt 3 fokkal az óramutató irányába forgatja az alakzaton belül:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
```

Az eredmény:

![Az egyéni szövegforgatás](custom_text_rotation.png)

## **Bekezdés sortávolságának beállítása**

Az Aspose.Slides a [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/) és [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) segítségével szabályozza a bekezdés távolságát. Ezeket a tulajdonságokat a következőképpen használja:

* Pozitív értékkel a sortávolságot a sor magasságának százalékában adja meg.
* Negatív értékkel a sortávolságot pontban adja meg.

Az alábbi példa az első bekezdésen belüli távolságot a sor magasságának 200 %-ára (dupla sorköz) állítja:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

paragraph.ParagraphFormat.SpaceWithin = 200;

presentation.Save("line_spacing.pptx", SaveFormat.Pptx);
```

Az eredmény:

![A sortávolság a bekezdésen belül](line_spacing.png)

## **Sor törésének vezérlése**

A bekezdés sortörés szabályai szűk szövegtömbökben és olyan prezentációkban hasznosak, ahol latin és kelet-ázsiai szöveg keveredik. A következő tulajdonságok az [IParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/) részei, így a teljes bekezdésre vonatkoznak:

- [LatinLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/latinlinebreak/) szabályozza a latin sorörés szabályait. Vegyes szöveg esetén ennek módosítása a kelet-ázsiai szöveg és írásjelek tördelését is befolyásolhatja.
- [EastAsianLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/eastasianlinebreak/) szabályozza a kelet-ázsiai sorörés szabályait, beleértve a karakterek korlátozását a sor elején és végén.

Ezek a szabályok nem helyettesítik az [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) beállítást, amely automatikus tördelést engedélyez egy szövegdobozban. A tördelés során befolyásolják a layoutot, de nem helyeznek be sorvége karaktert. Egy explicit sortörés új sort kényszerít a bekezdésben a rendelkezésre álló szélességtől függetlenül.

Az alábbi önálló példa egy szűk szövegtömböt hoz létre kínai és latin szöveggel. Mindkét sortörés szabályt explicit módon beállítja, majd elmenti a "line_breaking.pptx" fájlt. Az egyik szabály kísérletezéséhez módosítsa annak értékét, miközben a másik beállítást változatlanul hagyja. A példa 24‑pontos Arial és SimSun betűtípusokat használ 160‑pontos keretszélességgel és 0‑s horizontális margóval. Az [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) értéke [TextAutofitType.None](https://reference.aspose.com/slides/net/aspose.slides/textautofittype/), így a szöveg mérete és a keret méretei fixek maradnak.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 160, 300);
shape.FillFormat.FillType = FillType.NoFill;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.WrapText = NullableBool.True;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
textFrame.TextFrameFormat.MarginLeft = 0;
textFrame.TextFrameFormat.MarginRight = 0;

var paragraph = textFrame.Paragraphs[0];
paragraph.Text = "中文排版测试，PowerPoint 中文演示。";

var format = paragraph.ParagraphFormat;
format.Alignment = TextAlignment.Left;
format.DefaultPortionFormat.FontHeight = 24;
format.DefaultPortionFormat.LatinFont = new FontData("Arial");
format.DefaultPortionFormat.EastAsianFont = new FontData("SimSun");
format.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
format.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
format.LatinLineBreak = NullableBool.False;
format.EastAsianLineBreak = NullableBool.True;

presentation.Save("line_breaking.pptx", SaveFormat.Pptx);
```

## **Függőleges központozás vezérlése**

[IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/hangingpunctuation/) lehetővé teszi, hogy a megfelelő írásjelek a szövegsor jobb szélén túlra nyúljanak, ahelyett, hogy a következő sorba kerülnének. A teljes bekezdésre vonatkozik, és eltér a balra kihúzott behúzástól.

Az alábbi önálló példa 100‑pontos széles szövegdobozban engedélyezi a függőleges központozást, és elmenti a "hanging_punctuation.pptx" fájlt. 24‑pontos Arial betűtípussal és 0‑s horizontális margóval a végső pont a "sentence" szó után marad, és a jobb szövegszél fölé nyúlik. A tulajdonságot [NullableBool.False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) értékre állítva is kipróbálhatja: ebben az esetben a pont külön sorba kerül. A tördelés engedélyezve van, az automatikus méretezés le van tiltva, hogy a rendelkezésre álló szélesség fix maradjon.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 200);
shape.FillFormat.FillType = FillType.NoFill;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.WrapText = NullableBool.True;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
textFrame.TextFrameFormat.MarginLeft = 0;
textFrame.TextFrameFormat.MarginRight = 0;

var paragraph = textFrame.Paragraphs[0];
paragraph.Text = "Simple text, next sentence.";

var format = paragraph.ParagraphFormat;
format.Alignment = TextAlignment.Left;
format.DefaultPortionFormat.FontHeight = 24;
format.DefaultPortionFormat.LatinFont = new FontData("Arial");
format.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
format.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
format.HangingPunctuation = NullableBool.True;

presentation.Save("hanging_punctuation.pptx", SaveFormat.Pptx);
```

Nem minden írásjel függőlegesen kihúzható. Az [a fenti betű- és elrendezési feltételek](#control-line-breaking) szintén érvényesek erre az összehasonlításra: a betűtípus, a rendelkezésre álló szélesség, a margók vagy az automatikus méretezés módosítása eltüntetheti a látható különbséget.

## **Automatikus méretezés típusának beállítása szövegdobozokhoz**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) meghatározza, hogyan viselkedik a szöveg, amikor túllépi a konténer határait. Ezzel szabályozható, hogy a szöveg zsugorodjon, túlfusson vagy automatikusan átméretezze az alakzatot. Az alábbi példa a alakzatot úgy állítja be, hogy a szöveghez igazodva méretezze át, és elmenti a "autofit_type.pptx" fájlt.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

A *Megjelenített sorok számolása* után láthatja, hogyan változik a sorok száma automatikus tördelés után, illetve hogyan változik a szöveg vagy az alakzat szélessége, lásd a [Megjelenített sorok számolása](/slides/hu/net/manage-paragraph/). A sorok száma önmagában nem mutatja meg, hogy a szöveg túlnyúlik-e a konténerből.

## **Szövegdobozok rögzítésének beállítása**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/) meghatározza, hogyan helyezkedik el a szöveg függőlegesen egy alakzaton belül, például a tetején, közepén vagy alján. Az alábbi példa a szöveget az első alakzat aljához rögzíti, és elmenti a "text_anchor.pptx" fájlt.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
```

## **Szöveg tabulálásának beállítása**

Használja az [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaulttabsize/) és az [IParagraphFormat.Tabs](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/tabs/) segítségével a tabulátorok beállításához egy bekezdésen belül. Az alábbi példa a alapértelmezett tabulátor intervallumot 100 pontra állítja, és egy balra igazított tabulátort ad hozzá 30 pontnál. Ezek a beállítások a tabulátorokkal rendelkező szövegre hatnak.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.ParagraphFormat.DefaultTabSize = 100;
paragraph.ParagraphFormat.Tabs.Add(30, TabAlignment.Left);

presentation.Save("paragraph_tabs.pptx", SaveFormat.Pptx);
```

Az eredmény:

![A bekezdés tabulátorai](paragraph_tabs.png)

## **Ellenőrző nyelv beállítása**

Az Aspose.Slides a [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) segítségével lehetővé teszi a szövegrész ellenőrző nyelvének beállítását. Az ellenőrző nyelv határozza meg, hogy a PowerPoint milyen nyelvet használ a helyesírás- és nyelvtani ellenőrzéshez.

Az alábbi példa a "presentation.pptx" fájlt igényli, amelynek az első dián az első alakzat egy szövegdoboz, és legalább egy bekezdése van. A első bekezdés tartalmát "1。" szövegre cseréli, a SimSun betűtípust állítja be, és a `zh-CN` (egyszerűsített kínai) ellenőrző nyelvet rendeli hozzá. A "proofing_language.pptx" fájlba menti az eredményt:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var font = new FontData("SimSun");

var textPortion = new Portion();
textPortion.PortionFormat.ComplexScriptFont = font;
textPortion.PortionFormat.EastAsianFont = font;
textPortion.PortionFormat.LatinFont = font;

// Állítsa be a helyesírási nyelvet egyszerűsített kínai nyelvre.
textPortion.PortionFormat.LanguageId = "zh-CN";

textPortion.Text = "1。";
paragraph.Portions.Add(textPortion);

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

## **Alapértelmezett nyelv beállítása**

Használja a [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaulttextlanguage/) lehetőséget a prezentáció betöltése vagy létrehozása során létrehozott szöveg alapértelmezett nyelvének meghatározásához. Az alábbi példa egy prezentációt hoz létre, amelyben az alapértelmezett szövegnyelv az amerikai angol, hozzáad egy szövegdobozt, és az első szövegrészhez kiírja a `en-US` értéket.

```cs
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];

// Adjunk hozzá egy új téglalap alakzatot szöveggel.
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
shape.TextFrame.Text = "Sample text";

// Ellenőrizze az első rész nyelvét.
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine(portion.PortionFormat.LanguageId);
```

## **Alapértelmezett szövegstílus beállítása**

A prezentáció szintjén alapértelmezett szövegformázás alkalmazásához használja a [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/defaulttextstyle/) lehetőséget.

Az alábbi példa egy új prezentációban a felső szintű bekezdésekhez 14‑pontos félkövér betűtípust állít be alapértelmezettként, és elmenti a "default_text_style.pptx" fájlt. A szöveg örökölheti ezeket az alapértékeket, hacsak egy specifikusabb formázás nem felülírja őket.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
// Szerezze meg a legfelső szintű bekezdés formátumát.
var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

if (paragraphFormat != null)
{
    paragraphFormat.DefaultPortionFormat.FontHeight = 14;
    paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
}

presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
```

## **Szöveg kinyerése a Nagybetűs hatással**

PowerPointban a **All Caps** betűhatás alkalmazása nagybetűsíti a szöveget a dián, még ha eredetileg kisbetűvel lett beírva. Amikor az Aspose.Slides-szel ilyen szövegrészt kérdezi le, a könyvtár pontosan a beírt szöveget adja vissza. A megjelenített szöveghez való illesztéshez ellenőrizze a [TextCapType](https://reference.aspose.com/slides/net/aspose.slides/textcaptype/) értékét, és konvertálja a visszakapott karakterláncot nagybetűssé, ha az `All` értéket tartalmaz.

Ez a példa a "sample2.pptx" fájlt igényli, amelynek az első dián az első alakzat egy szövegdoboz. Az első bekezdés első része a "Hello, Aspose!" szöveget tartalmazza, amelyre a **All Caps** hatás van alkalmazva, az alább látható kép szerint.

![A Nagybetűs hatás](all_caps_effect.png)

Az alábbi kódrészlet bemutatja, hogyan lehet kinyerni a **All Caps** hatással ellátott szöveget:

```cs
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample2.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var textPortion = autoShape.TextFrame.Paragraphs[0].Portions[0];

Console.WriteLine($"Original text: {textPortion.Text}");

var textFormat = textPortion.PortionFormat.GetEffective();
if (textFormat.TextCapType == TextCapType.All)
{
    var text = textPortion.Text.ToUpper();
    Console.WriteLine($"All-Caps effect: {text}");
}
```

Kimenet:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **GYIK**

**Hogyan módosíthatom egy dián lévő táblázat szövegét?**  
A táblázat szövegének módosításához a dián használja az [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) elemet. Iteráljon a cellákon, és frissítse az egyes cellákat az [ICell.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) és a bekezdés formázását az [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/paragraphformat/) segítségével.

**Hogyan alkalmazhatok színátmenetet a szövegre egy PowerPoint dián?**  
A szövegre színátmenet alkalmazásához használja az [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/) elemet. Állítsa az [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) értéket a [FillType.Gradient](https://reference.aspose.com/slides/net/aspose.slides/filltype/) típusra, és konfigurálja a gradient állomásokat, irányt és átlátszóságot.

Kapcsolódó funkció: [Szöveg formázása diákon belül](/slides/hu/features/text-formatting/).