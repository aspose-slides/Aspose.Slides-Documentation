---
title: Prezentáció szövegének formázása .NET-ben
linktitle: Szöveg formázása
type: docs
weight: 50
url: /hu/net/text-formatting/
keywords:
- bekezdés igazítása
- szöveg stílusa
- szöveg háttér
- szöveg átlátszóság
- karaktertávolság
- betűtulajdonságok
- betűcsalád
- szöveg forgatása
- forgatási szög
- szövegkeret
- sortávolság
- automatikus illesztés tulajdonság
- szövegkeret rögzítési pont
- szöveg tabuláció
- alapértelmezett nyelv
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Formázza és stílusozza a szöveget PowerPoint és OpenDocument prezentációkban az Aspose.Slides for .NET segítségével. Testreszabhatja a betűtípusokat, színeket, igazítást és egyéb beállításokat."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan formázzuk a szöveget PowerPoint‑ és OpenDocument‑prezentációkban az Aspose.Slides for .NET segítségével. Kitér a háttérszínekre, átlátszóságra, karaktertávolságra, betűtulajdonságokra, forgatásra, bekezdéstávolságra, automatikus illesztésre, szövegrögzítésre, tabulátorokra és nyelvi beállításokra.

Ha nincs másként megadva, a példák a [sample.pptx](sample.pptx) fájlt használják. Az első dián az első alakzat egy szövegdoboz, és az első bekezdés tartalmazza az alább látható szöveget. Mind a dia, mind az alakzat indexelése nullától indul. A félkövér részletek kiválasztására szolgáló példák hatékony formázást alkalmaznak, beleértve az örökölt félkövér formázást:

![Sample text](sample_text.png)

A szó szerinti szöveg vagy reguláris kifejezések kereséséhez és kiemeléséhez lásd a [Search and Replace Text](/slides/hu/net/search-and-replace-text/) oldalt.

## **Szöveg háttérszínének beállítása**

Használja az [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) tulajdonságot a bekezdés alapértelmezett kiemelés színének beállításához, vagy az [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/highlightcolor/) tulajdonságot az egyes szövegrészekhez.

Az alábbi példa világosszürke kiemelést állít be alapértelmezettként az első bekezdéshez. Az egyes részekre megadott explicit kiemelés felülírja ezt az alapértelmezést:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Állítsa be a kiemelés színét az egész bekezdésre.
paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
```

Az eredmény:

![The gray paragraph](gray_paragraph.png)

Az alábbi kódrészlet bemutatja, hogyan állítsuk be a háttérszínt **félkövér betűtípusú szövegrészek** számára:

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
        // Állítsa be a kiemelés színét a szövegrészhez.
        portion.PortionFormat.HighlightColor.Color = Color.LightGray;
    }
}

presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
```

Az eredmény:

![The gray text portions](gray_text_portions.png)

## **Szövegbekezdések igazítása**

Használja az [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) tulajdonságot a bekezdés igazításához egy szövegkeretben. Az érték lehet középre, balra, jobbra, sorkizárt stb.

Az alábbi kódrészlet bemutatja, hogyan igazítsuk a bekezdést **középre**:

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

![The aligned paragraph](aligned_paragraph.png)

## **Betűtípusok igazítása egy soron belül**

Használja az [IParagraphFormat.FontAlignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/fontalignment/) tulajdonságot a soron belüli, különböző betűméretű szövegrészek függőleges igazításához. Ez a beállítás az egész bekezdésre vonatkozik, és a soron belüli igazítást szabályozza.

Az alábbi önálló példa négy felcímzett szövegdobozt hoz létre egy dián. Minden bekezdés ugyanazt a szöveget tartalmazza 18, 36 és 54 pont méretben, különböző betűigazítással. Arial‑t használ, letiltja az automatikus illesztést és a tördelést, és a szövegkereteket elég nagyra állítja egy sorhoz.

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

![Comparison of Baseline, Top, Center, and Bottom font alignment with mixed font sizes](font_alignment.png)

A betűigazítás betűmetrikán alapul, ezért az egyes betűk látható szélei nem feltétlenül illeszkednek pontosan. A példa tartalmaz egy nagybetűt és egy lejjebb nyúló karaktert, hogy megmutassa a baseline és a bottom igazítás közti különbséget. A betűkészlet megléte és helyettesítése, a használt karakterek, valamint a betűméretek közti különbség mind hatással van az eredményre. A keretméretek, margók, sorköz, tördelés és automatikus illesztés szintén befolyásolják a megjelenítést; a módok összehasonlításához használja ugyanazt a betűtípust és elrendezési beállításokat.

Ez a beállítás eltér az [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/)‑tól, amely a vízszintes bekezdésigazítást szabályozza, valamint az [ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/)‑tól, amely a szövegtömb függőleges pozícióját határozza meg az alakzaton belül. A [IBasePortionFormat.Escapement](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/escapement/) segítségével a túl- és alulindexelés az egyes részeket a baseline‑hoz képest helyezi el, nem pedig a bekezdés soraira vonatkozó betűigazítást állítja be.

## **Szöveg átlátszóságának beállítása**

A szöveg átlátszósága az [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/) színének alfa komponensével szabályozható. Az alábbi példákban az `alpha = 50` egy ARGB alfa‑csatorna‑érték a 0‑255‑os skálán, nem átlátszósági százalék.

Az alábbi kódrészlet bemutatja, hogyan alkalmazzuk az átlátszóságot **az egész bekezdésre**:

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

![The transparent paragraph](transparent_paragraph.png)

Az alábbi kódrészlet bemutatja, hogyan alkalmazzuk az átlátszóságot **félkövér betűtípusú szövegrészek** esetén:

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

![The transparent text portions](transparent_text_portions.png)

## **Karaktertávolság beállítása a szövegben**

Használja az [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/spacing/) tulajdonságot a karakterek közti távolság növelésére vagy csökkentésére egy szövegdobozban. A példák 3 pont távolságot adnak hozzá; a negatív értékek szorosítják a szöveget.

Az alábbi C# kód bemutatja, hogyan növeljük a karaktertávolságot **az egész bekezdésben**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Megjegyzés: Negatív értékek használata a karaktertávolság összenyomásához.
paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // Növelje a karaktertávolságot.

presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
```

Az eredmény:

![The character spacing in the paragraph](character_spacing_in_paragraph.png)

Az alábbi kódrészlet bemutatja, hogyan növeljük a karaktertávolságot **félkövér betűtípusú szövegrészek** esetén:

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
        // Megjegyzés: Negatív értékek használata a karaktertávolság összenyomásához.
        portion.PortionFormat.Spacing = 3;  // Növelje a karaktertávolságot.
    }
}

presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
```

Az eredmény:

![The character spacing in the text portions](character_spacing_in_text_portions.png)

### **Kerning letiltása adott betűtípusoknál**

Bizonyos esetekben az Aspose.Slides által renderelt szöveg kissé szorosabb lehet, mint a PowerPoint-ban megjelenő változata. Ez akkor fordulhat elő, ha a PowerPoint figyelmen kívül hagyja a kerning adatokat egyes betűtípusoknál, még akkor is, ha a betűtípus tartalmaz érvényes kerning információt, és a PowerPoint beállításaiban a kerning engedélyezve van.

Ennek orvoslására letilthatja a kerninget azoknál a szövegrészeknél, amelyek az érintett betűtípust használják. Állítsa az [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kerningminimalsize/) értékét a tényleges betűméretnél nagyobbra. A példa a „presentation.pptx” fájlt igényli, amelynek az első diáján az első alakzat egy szövegdoboz. A hatékony betűneveket (az örökölt betűket is) ellenőrzi, és 100 pont küszöböt állít be a Roboto‑t használó részekhez. Ez letiltja a kerninget a 100 pontnál kisebb méretű részeknél:

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

A küszöb alatti szövegnél ez a beállítás megakadályozza a kerninget, és segíthet az Aspose.Slides renderelésének a PowerPoint‑specifikus viselkedés miatt kialakult eltérésekhez igazításában.

## **Szöveg betűtulajdonságainak kezelése**

A betűtulajdonságok beállíthatók bekezdés szinten az [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) segítségével, vagy egyes részek esetén az [IPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/) használatával.

Az alábbi példa az első bekezdés alapértelmezett betűtípusát 12 pontos Times New Roman‑ra állítja be, félkövér, dőlt és pontozott aláhúzással. Az egyes részekre alkalmazott explicit formázás felülírja ezeket az alapértelmezéseket:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Állítsa be a betűtulajdonságokat a bekezdéshez.
var portionFormat = paragraph.ParagraphFormat.DefaultPortionFormat;
portionFormat.FontHeight = 12;
portionFormat.FontBold = NullableBool.True;
portionFormat.FontItalic = NullableBool.True;
portionFormat.FontUnderline = TextUnderlineType.Dotted;
portionFormat.LatinFont = new FontData("Times New Roman");

presentation.Save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
```

Az eredmény:

![The font properties for the paragraph](font_properties_for_paragraph.png)

Az alábbi példa 13 pontos Times New Roman‑t, dőlt formázást és pontozott aláhúzást alkalmaz azokra a részekre, amelyek hatékony formázása félkövér:

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

![The font properties for text portions](font_properties_for_text_portions.png)

## **Szövegmagasság normalizálásának szabályozása**

Használja az [IBasePortionFormat.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/normaliseheight/) tulajdonságot sablon‑tipográfia reprodukálásakor vagy a karaktermagasság‑különbségek vizsgálatakor. PowerPoint‑ban a normalizálás engedélyezése függőlegesen nyújtja vagy összehúzza az egyes karaktereket, hogy egységes látható magasságuk legyen a szövegrészben. Nem garantálja a különböző betűtípusok közötti azonos magasságot.

Állítsa a tulajdonságot a [NullableBool.True vagy False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) értékre a normalizálás explicit be‑ vagy kikapcsolásához. A `NullableBool.NotDefined` helyi beállítást hagy üresen, így a rész örökli az értéket, például a bekezdés [DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/)-ból. Ez nem jelenti a `False` értéket. Használja az [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) és olvassa ki az [IBasePortionFormatEffectiveData.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformateffectivedata/normaliseheight/) értékét a feloldott logikai eredményhez.

Az alábbi önálló példa **Arial**‑t igényel. Két szövegtömböt hoz létre, amelyek ugyanazokat a nagy‑ és kisbetűket, lejjebbnyúló karaktereket és ékezetes betűket tartalmazzák 54 pont méretben. Mindkét bekezdés alapértelmezés szerint engedélyezi a normalizálást. A felső rész explicit módon letiltja, az alsó rész örökli. A keretméretek, margók és bekezdéstávolság azonosak, a tördelés és az automatikus illesztés le van tiltva a konzisztens összehasonlítás érdekében. A példa kiírja a `False: False` és `NotDefined: True` értékeket, majd elmenti a „text_height_normalization.pptx” fájlt.

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

Az alább látható összehasonlítás a mentett prezentációból lett exportálva. A felső sorban a normalizálás le van tiltva (`False`); az alsó sor örökli a bekapcsolt beállítást (`NotDefined` → `True`). Az eredmény reprodukálásához telepítve kell legyen az Arial.

![Arial 54-point text with normalization disabled above and inherited normalization enabled below](text_height_normalization.png)

A normalizálás a karaktermagasságot változtatja meg anélkül, hogy a hozzárendelt [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/) értéket módosítaná, amely a betűméretet pontban adja meg. A bekezdés [SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) szabályozza a sorközöket, míg a szövegkeret [AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) befolyásolja, hogy a szöveg vagy a tárolója hogyan igazodik. Ezek a beállítások különböző célokat szolgálnak, és önállóan befolyásolhatják az elrendezést. További információkért a bekezdésformázásról és öröklődésről lásd a [Manage Paragraph](/slides/hu/net/manage-paragraph/) oldalt.

## **Áthúzás alkalmazása és eltávolítása**

Használja az [IBasePortionFormat.StrikethroughType](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/strikethroughtype/) tulajdonságot egy szövegrészre, hogy javításokat, törölt kifejezéseket vagy korábbi árakat jelenítsen meg anélkül, hogy törölné az eredeti szöveget. Állítsa a [TextStrikethroughType.Single vagy Double](https://reference.aspose.com/slides/net/aspose.slides/textstrikethroughtype/) értékre egy vagy két vonal megjelenítéséhez a szöveg felett.

Az áthúzás eltávolításához állítsa `TextStrikethroughType.None`‑ra. Ez explicit módon letiltja a hatást, még ha a környező formázás áthúzást tartalmaz is. Ezzel ellentétben a `TextStrikethroughType.NotDefined` helyi beállítást hagy üresen, lehetővé téve a rész számára, hogy örökölje a formázást, például a bekezdésből. Nem garantálja, hogy az áthúzás eltűnik. Használja az [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/)‑et az eredményes, örökölt értékek olvasásához.

Az alábbi önálló példa három árösszehasonlítást hoz létre. Minden bekezdés külön részekkel rendelkezik a címke, a régi ár és az aktuális ár számára, így csak a régi árra hat az áthúzás. Az első sorban az áthúzást alkalmazzák, majd eltávolítják; a többi sorban egy‑ és dupla áthúzás marad. Ennek a tulajdonságnak a módosítása megőrzi a szöveget és a többi formázást, beleértve a félkövér régi árat.

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

// Alkalmazza az áthúzást, majd kifejezetten távolítsa el az első korábbi árból.
paragraphs[0].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Single;
paragraphs[0].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.None;

paragraphs[1].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Single;
paragraphs[2].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Double;

presentation.Save("strikethrough.pptx", SaveFormat.Pptx);
```

Az eredmény felülről lefelé: nincs áthúzás, egyetlen áthúzás és dupla áthúzás.

![Previous prices without strikethrough, with single strikethrough, and with double strikethrough](strikethrough.png)

## **Szöveg forgatása**

Használja az [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/textverticaltype/) tulajdonságot egy előre definiált szövegtájolás beállításához egy alakzaton belül.

Az alábbi kódrészlet a [TextVerticalType.Vertical270](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/) értékre állítja a szöveg tájolását, ami **90 fokkal óramutató járásával ellentétesen** forgatja a szöveget:

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

![The text rotation](text_rotation.png)

## **Számjegyek egymás mellett való megjelenítése függőleges szövegben**

Kétjegyű szám függőleges japán címke esetén, helyezze a két számjegyet egy szövegrészbe, és állítsa be az [IBasePortionFormat.Kumimoji](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kumimoji/) attribútumot. A példa a [TextVerticalType.EastAsianVertical](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/) és a 40 pontos MS Gothic betűtípust használja mindkét címkéhez. Csak a numerikus részhez rendelt [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) érték különbözik.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

AddLabel(slide, 120, NullableBool.True);
AddLabel(slide, 360, NullableBool.False);

presentation.Save("vertical_date.pptx", SaveFormat.Pptx);

static void AddLabel(ISlide slide, float x, NullableBool kumimoji)
{
    var label = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, 48, 120, 420);
    label.FillFormat.FillType = FillType.NoFill;
    label.LineFormat.FillFormat.FillType = FillType.NoFill;

    var frame = label.AddTextFrame("");
    frame.TextFrameFormat.TextVerticalType = TextVerticalType.EastAsianVertical;

    var paragraph = frame.Paragraphs[0];
    var format = paragraph.ParagraphFormat.DefaultPortionFormat;
    var font = new FontData("MS Gothic");
    format.LatinFont = font;
    format.EastAsianFont = font;
    format.FontHeight = 40;
    format.FillFormat.FillType = FillType.Solid;
    format.FillFormat.SolidFillColor.Color = System.Drawing.Color.Black;

    var digits = new Portion("12");
    digits.PortionFormat.Kumimoji = kumimoji;
    
    paragraph.Portions.Clear();
    paragraph.Portions.Add(new Portion("令和"));
    paragraph.Portions.Add(digits);
    paragraph.Portions.Add(new Portion("年"));
}
```

PowerPoint‑ban a bal oldali címke (`True`) függőlegesen álló, egymás mellett elhelyezkedő számjegyeket mutat a 和 és 年 között. A jobb címke (`False`) esetén a pár 90 fokkal az óramutató járásával megegyezően van elforgatva. A környező japán karakterek mindkét címkén álló helyzetben maradnak.

![PowerPoint comparison of vertical date labels with upright digits on the left and rotated digits on the right.](vertical_date.png)

## **Egyéni forgatás beállítása szövegkeretekhez**

Használja az [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/rotationangle/) tulajdonságot egy egyéni forgatási szög beállításához egy [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/)-hez.

Az alábbi kódrészlet 3 fokkal óramutató járásával megegyezően forgatja el a szövegkeretet az alakzaton belül:

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

![The custom text rotation](custom_text_rotation.png)

## **Bekezdések sortávolságának beállítása**

Az Aspose.Slides a következő tulajdonságokkal biztosítja a bekezdés távolság szabályozását: [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/) és [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/). Ezeket a következőképpen használhatja:

* Pozitív érték esetén a sortávolság a sormagasság százalékaként adható meg.
* Negatív érték esetén a sortávolság pontban adható meg.

Az alábbi példa a első bekezdés sortávolságát a sormagasság 200 %-ára (dupla sorköz) állítja be:

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

![The line spacing within the paragraph](line_spacing.png)

## **Sortörés szabályozása**

A bekezdés sortörés szabályai szűk szövegdobozokban és olyan prezentációkban hasznosak, ahol latin és kelet-ázsiai szöveg keveredik. Az alábbi tulajdonságok az [IParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/) részei, így az egész bekezdésre vonatkoznak:

- A [LatinLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/latinlinebreak/) szabályozza a latin sortörési szabályokat. Vegyes szöveg esetén a módosítása megváltoztathatja a szomszédos kelet‑ázsiai szöveg és írásjel tördelésének helyét is.
- Az [EastAsianLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/eastasianlinebreak/) szabályozza a kelet‑ázsiai sortörési szabályokat, beleértve a sor elején és végén megengedett karakterek korlátozását.

Ezek a szabályok nem helyettesítik az [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) tulajdonságot, amely automatikus tördelést engedélyez a szövegkereten belül. A sortörési szabályok befolyásolják az elrendezést, amikor a tördelés megtörténik; nem illesztik be a sortörés karaktereket. Egy explicit sortörés új sort hoz létre a bekezdésben a rendelkezésre álló szélességtől függetlenül.

Az alábbi önálló példa szűk szövegdobozt hoz létre, amely kínai és latin szöveget tartalmaz. Mindkét sortörési tulajdonságot explicit módon állítja be, majd elmenti a „line_breaking.pptx” fájlt. A szabályok kipróbálásához változtassa meg az adott tulajdonság értékét, miközben a másik beállítást változatlanul hagyja. A példa 24 pontos Arial‑t és SimSun‑t használ 160 pont széles kerettel és nulla vízszintes szövegkeret‑margóval. Az [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) értéke [TextAutofitType.None](https://reference.aspose.com/slides/net/aspose.slides/textautofittype/), így a szövegméret és a keretméretek rögzítve maradnak.

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

## **Függőleges központozás szabályozása**

Az [IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/hangingpunctuation/) lehetővé teszi, hogy a jogosult írásjelek a sor jobb szélén túlnyúljanak, ahelyett, hogy a következő sorba kerülnek. A beállítás az egész bekezdésre vonatkozik, és eltér a függőleges behúzástól.

Az alábbi önálló példa 100 pont széles szövegkeretben engedélyezi a függőleges központozást, és elmenti a „hanging_punctuation.pptx” fájlt. 24 pontos Arial‑t és nulla vízszintes szövegkeret‑margót használ; a végső pont a „sentence” szó után marad, és túlnyúlik a jobb szövegélén. Állítsa a tulajdonságot [NullableBool.False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) értékre a összehasonlításhoz: ebben az esetben a pont külön sorba kerül. A tördelés be van kapcsolva, az automatikus illesztés ki van kapcsolva a szélesség rögzítése érdekében.

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

Nem minden írásjel függhet fel. A fent leírt [betű- és elrendezési feltételek](#control-line-breaking) szintén alkalmazandók erre az összehasonlításra: a betűtípus, a rendelkezésre álló szélesség, a margók vagy az automatikus illesztés módosítása eltüntetheti a látható különbséget.

## **Automatikus illesztés típusa a szövegkeretekhez**

Az [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) határozza meg, hogyan viselkedjen a szöveg, ha meghaladja a tároló határait. Ezzel szabályozható, hogy a szöveg zsugorodjon, kilyukadjon, vagy a forma automatikusan átméreteződjön. Az alábbi példa úgy állítja be a formát, hogy a shape átméreteződjön a szöveghez, majd elmenti a „autofit_type.pptx” fájlt.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

Az automatikus tördelés utáni sorok számolásához és a szöveg vagy a shape szélességének változásának megtekintéséhez lásd a [Count Rendered Lines](/slides/hu/net/manage-paragraph/) oldalt. A sorok száma önmagában nem jelzi, hogy a szöveg túlnyúlik‑e a tárolón.

## **Szövegkeretek rögzítési pontjának beállítása**

Az [ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/) meghatározza, hogyan helyezkedik el a szöveg függőlegesen egy alakzaton belül, például a tetején, közepén vagy alján. Az alábbi példa a szöveget a első alakzat aljához rögzíti, majd elmenti a „text_anchor.pptx” fájlt.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
```

## **Szöveg tabulációjának beállítása**

Használja az [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaulttabsize/) és az [IParagraphFormat.Tabs](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/tabs/) tulajdonságokat a bekezdés tabulátorainak konfigurálásához. Az alábbi példa az alapértelmezett tabulátort 100 pontra, és egy balra igazított tabulátort 30 pontnál állít be. Ezek a beállítások a tabulátor karaktereket tartalmazó szöveget érintik.

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

![The paragraph tabs](paragraph_tabs.png)

## **Helyesírási nyelv beállítása**

Az Aspose.Slides az [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) segítségével lehetővé teszi a szövegrész helyesírási nyelvének beállítását. A helyesírási nyelv határozza meg, melyik nyelvet használja a PowerPoint a helyesírás‑ és nyelvtani ellenőrzéshez.

Az alábbi példa a „presentation.pptx” fájlt igényli, amelynek az első diáján az első alakzat egy szövegdoboz, és legalább egy bekezdést tartalmaz. Az első bekezdés tartalmát „1。”‑re cseréli, a betűtípusként SimSun‑t állít be, és a Simplified Chinese (`zh-CN`) helyesírási nyelvet rendeli hozzá. Az eredményt a „proofing_language.pptx” fájlba menti:

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

// Állítsa be a helyesírási nyelvet egyszerű kínai nyelvre.
textPortion.PortionFormat.LanguageId = "zh-CN";

textPortion.Text = "1。";
paragraph.Portions.Add(textPortion);

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

### **Nyelvi metaadata másolása**

Többnyelvű szöveg sablonból történő másolásakor őrizze meg mind az [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/), mind az [IBasePortionFormat.AlternativeLanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/alternativelanguageid/) értékét. Az alábbi önálló példa egy forrásrészletet hoz létre, amely US English nyelvű, alternatív nyelvként franciát tartalmaz, és a szöveget valamint az azonosítókat egy új prezentáció egy részébe másolja.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var source = new Portion("Hello! Bonjour!");
source.PortionFormat.LanguageId = "en-US";
source.PortionFormat.AlternativeLanguageId = "fr-FR";

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 80);
var paragraph = shape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var destination = new Portion();
destination.Text = source.Text;
destination.PortionFormat.LanguageId = source.PortionFormat.LanguageId;
    // Ha a forrásnak nincs alternatív nyelve, a null törli a cél értékét.
destination.PortionFormat.AlternativeLanguageId = source.PortionFormat.AlternativeLanguageId;
paragraph.Portions.Add(destination);

presentation.Save("copied_language_metadata.pptx", SaveFormat.Pptx);
```

Ha forrásból nincs alternatív nyelv, hagyja el a `"fr-FR"`‑et. Ekkor az alternatív azonosító `null`, és a másolási utasítás megőrzi a hiányt alapértelmezett érték bevezetése nélkül, még ha a célhelyen korábban alternatív nyelv is megvolt.

Ezek az azonosítók nyelvi metaadatként vannak tárolva. Megőrzésük nem határozza meg, hogy a PowerPoint melyik szótárat használja a helyesírás‑ vagy nyelvtani ellenőrzéshez.

## **Alapértelmezett nyelv beállítása**

Használja a [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaulttextlanguage/) tulajdonságot a betöltés vagy létrehozás során létrehozott szöveg alapértelmezett nyelvének meghatározásához. Az alábbi példa egy US English alapértelmezett szövegnyelvű prezentációt hoz létre, szövegdobozt ad hozzá, és az első szövegrésznek `en-US`‑t ír ki.

```cs
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];

// Új négyszög alakzat hozzáadása szöveggel.
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
shape.TextFrame.Text = "Sample text";

// Ellenőrizze az első rész nyelvét.
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine(portion.PortionFormat.LanguageId);
```

## **Alapértelmezett szövegstílus beállítása**

A prezentáció szintjén az alapértelmezett szövegformázás alkalmazásához használja az [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/defaulttextstyle/)‑t.

Az alábbi példa 14 pontos félkövér betűtípust állít be alapértelmezettként a legfelső szintű bekezdésekhez egy új prezentációban, majd elmenti a „default_text_style.pptx” fájlt. A szöveg örökölni tudja ezeket az alapértelmezéseket, hacsak nincs specifikusabb formázás, amely felülírja őket.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
// Szerezze meg a legfelső szintű bekezdésformátumot.
var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

if (paragraphFormat != null)
{
    paragraphFormat.DefaultPortionFormat.FontHeight = 14;
    paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
}

presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
```

## **Szöveg kinyerése All‑Caps hatással**

PowerPoint‑ban az **All Caps** betűeffektus alkalmazása a szöveget nagybetűként jeleníti meg a dián, még ha eredetileg kisbetűkkel lett beírva. Amikor ilyen szövegrészt olvas ki az Aspose.Slides, a könyvtár a beírt eredeti szöveget adja vissza. A megjelenített szöveghez való igazításhoz ellenőrizze a [TextCapType](https://reference.aspose.com/slides/net/aspose.slides/textcaptype/) értékét, és konvertálja a visszaadott karakterláncot nagybetűssé, ha a típus `All`.

Ez a példa a „sample2.pptx” fájlt igényli, amelynek első diáján az első alakzat egy szövegdoboz. Az első bekezdés első része a „Hello, Aspose!” szöveget tartalmazza, az All Caps hatással, ahogy alább látható.

![The All Caps effect](all_caps_effect.png)

Az alábbi kódrészlet bemutatja, hogyan nyerjük ki a **All Caps** hatással rendelkező szöveget:

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

**Hogyan módosíthatom a táblázat szövegét egy dián?**

A táblázat szövegének módosításához egy dián használja az [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) interfészt. Iteráljon a cellákon, és frissítse minden cellát az [ICell.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) és a bekezdésformázást az [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/paragraphformat/) segítségével.

**Hogyan alkalmazhatok gradienst a szöveg színére egy PowerPoint diáron?**

A szöveghez való gradiensek alkalmazásához használja az [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/)‑t. Állítsa az [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) értékét [FillType.Gradient](https://reference.aspose.com/slides/net/aspose.slides/filltype/)‑ra, és konfigurálja a gradient‑állomásokat, irányt és átlátszóságot.

Kapcsolódó funkció: [Format text within slides](/slides/hu/features/text-formatting/).