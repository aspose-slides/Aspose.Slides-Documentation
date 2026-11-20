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
- karakterköz
- betűtulajdonságok
- betűcsalád
- szöveg forgatás
- forgatási szög
- szövegkeret
- sortávolság
- automatikus illeszkedés tulajdonság
- szövegkeret rögzítési pont
- szöveg tabuláció
- alapértelmezett nyelv
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Formázza és stílusozza a szöveget PowerPoint és OpenDocument prezentációkban az Aspose.Slides for .NET segítségével. Testreszabhatja a betűket, színeket, igazítást és még sok mást."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan formázhatja a szöveget PowerPoint és OpenDocument prezentációkban az Aspose.Slides for .NET használatával. Kitér a háttérszínekre, átlátszóságra, karakterközökre, betűtulajdonságokra, forgatásra, bekezdésközökre, automatikus illeszkedés viselkedésére, szöveg rögzítésére, tabulátorokra és nyelvi beállításokra.

Kivéve, ha másként van megjegyezve, a példák a [sample.pptx](sample.pptx) fájlt használják. Az első dia első alakja egy szövegdoboz, és az első bekezdése a lenti szöveget tartalmazza. A diák és az alakok indexelése 0‑tól indul. A félkövér részeket kiválasztó példák hatékony formázást alkalmaznak, beleértve az örökölt félkövér formázást:

![Minta szöveg](sample_text.png)

Az egyenes szöveg vagy reguláris kifejezéssel való találatok kereséséhez és kiemeléséhez lásd a [Search and Replace Text](/slides/hu/net/search-and-replace-text/) oldalt.

## **Szöveg háttérszínének beállítása**

Használja az [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) elemet a bekezdés alapértelmezett kiemelési színének beállításához, vagy az [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/highlightcolor/) elemet az egyedi szövegrészekhez.

Az alábbi példa egy világosszürke kiemelést állít be az első bekezdés alapértelmezettként. Az egyes részeken megadott explicit kiemelési színek felülbírálják ezt az alapértelmezést:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Állítsa be a kiemelési színt az egész bekezdéshez.
paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
```

Az eredmény:

![A szürke bekezdés](gray_paragraph.png)

Az alábbi kódpélda bemutatja, hogyan állítható be a háttérszín a **félkövér betűtípussal rendelkező szövegrészek** esetén:

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
        // Állítsa be a kiemelési színt a szövegrészhez.
        portion.PortionFormat.HighlightColor.Color = Color.LightGray;
    }
}

presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
```

Az eredmény:

![A szürke szövegrészek](gray_text_portions.png)

## **Szöveg bekezdések igazítása**

Használja az [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) elemet a bekezdés igazításához egy szövegkereten belül. Az érték lehet középre, balra, jobbra igazított, sorkizárt stb.

Az alábbi kódpélda megmutatja, hogyan igazítható a bekezdés a **középre**:

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

## **Betűtípusok soron belüli igazítása**

Használja az [IParagraphFormat.FontAlignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/fontalignment/) elemet a soron belül különböző betűmérettel rendelkező szövegrészek függőleges igazításához. Ez a beállítás az egész bekezdésre vonatkozik, és minden sorban vezérli az igazítást.

Az alábbi önálló példa négy felcímzett szövegdobozt hoz létre egy dián. Minden bekezdés ugyanazt a szöveget tartalmazza 18, 36 és 54 pontban, különböző betűigazítással. Az Arial betűtípust használja, letiltja az automatikus illeszkedést és a sortörést, és a szövegkereteket elég nagyra állítja egy sorhoz.

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

A betűigazítás betűmetrikákat használ, ezért az egyes betűk látható szélei nem feltétlenül illeszkednek pontosan egymáshoz. A példa tartalmaz egy nagybetűt és egy lejjebb nyúló betűt, hogy bemutassa a baseline és a bottom igazítás közti különbséget. A betűk elérhetősége és helyettesítése, a használt karakterek és a betűméretbeli különbségek mind befolyásolják az eredményt. A keret méretei, margók, sorköz, sortörés és automatikus illeszkedés szintén hatnak a megjelenésre; a módok összehasonlításához használja ugyanazokat a betűtípusokat és elrendezési beállításokat.

Ez a beállítás különbözik az [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) elemtől, amely a vízszintes bekezdésigazítást szabályozza, valamint az [ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/) elemtől, amely a szövegdobozt függőlegesen helyezi el az alakzaton belül. A felső- és alsó indexelés a [IBasePortionFormat.Escapement](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/escapement/) segítségével egyedi részeket mozgat a baseline-hoz képest, ahelyett, hogy a bekezdés soraira alkalmazná a betűigazítást.

## **Szöveg átlátszóságának beállítása**

A szöveg átlátszóságát az [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/) színének alfa komponense szabályozza. Az alábbi példákban az `alpha = 50` egy ARGB alfa‑csatorna érték a 0‑255 tartományban, nem átlátszósági százalék.

Az alábbi kódpélda megmutatja, hogyan alkalmazzon átlátszóságot a **teljes bekezdésre**:

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

A következő kódpélda átlátszóságot alkalmaz a **félkövér betűtípussal rendelkező szövegrészek** esetén:

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

## **Karakterköz beállítása a szövegben**

Használja az [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/spacing/) elemet a karakterek közötti távolság növelésére vagy szűkülésére egy szövegdobozban. A példák 3 pont közközt adnak hozzá; a negatív értékek a szöveget összenyomják.

Az alábbi C# kód megmutatja, hogyan növelhető a karakterköz a **teljes bekezdésben**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Megjegyzés: Negatív értékekkel lehet összenyomni a karakterközt.
paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // Bővíti a karakterközt.

presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
```

Az eredmény:

![A karakterköz a bekezdésben](character_spacing_in_paragraph.png)

Az alábbi kódpélda megmutatja, hogyan növelhető a karakterköz a **félkövér betűtípussal rendelkező szövegrészek** esetén:

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
        // Megjegyzés: Negatív értékekkel lehet összenyomni a karakterközt.
        portion.PortionFormat.Spacing = 3;  // Bővíti a karakterközt.
    }
}

presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
```

Az eredmény:

![A karakterköz a szövegrészekben](character_spacing_in_text_portions.png)

### **Keretkötés letiltása bizonyos betűtípusoknál**

Bizonyos esetekben az Aspose.Slides által renderelt szöveg kissé szorosabb lehet, mint a PowerPointban megjelenő szöveg. Ennek oka, hogy a PowerPoint néhány betűtípusnál figyelmen kívül hagyja a keretkötési (kerning) adatokat, még akkor is, ha a betűtípus tartalmazza a megfelelő információkat és a PowerPoint beállításaiban a keretkötés be van kapcsolva.

Az ilyen esetekben a renderelt kimenet PowerPoint közelítéséhez letilthatja a keretkötést azoknál a szövegrészeknél, amelyek az érintett betűtípust használják. Állítsa az [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kerningminimalsize/) értékét a tényleges betűméretnél nagyobbra. Ez a példa a "presentation.pptx" fájlt igényli, amelynek első alakja egy szövegdoboz az első dián. Ellenőrzi a hatékony betűneveket, beleértve az örökölt betűket, és 100 pontos küszöböt állít be a Roboto betűtípust használó részekhez. Ez letiltja a keretkötést a 100 pont alatti méretű részeknél:

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

A küszöbnél kisebb szöveg esetén ez a beállítás megakadályozza a keretkötést, és segíthet az Aspose.Slides megjelenítésének a PowerPoint vizuális kimenetéhez igazításában az érintett betűtípusoknál.

## **Szöveg betűtulajdonságainak kezelése**

A betűtulajdonságok beállíthatók bekezdés szinten az [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) vagy egyedi részeknél az [IPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/) segítségével.

Az alábbi példa a első bekezdés alapértelmezett betűtípusát 12 pontos Times New Roman-ra állítja be félkövérrel, dőlt és pontozott aláhúzással. Az egyedi részeken megadott explicit formázás felülbírálja ezeket az alapértelmezéseket:

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

![A bekezdés betűtulajdonságai](font_properties_for_paragraph.png)

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
        // Állítsa be a szövegrész betűtulajdonságait.
        portion.PortionFormat.FontHeight = 13;
        portion.PortionFormat.FontItalic = NullableBool.True;
        portion.PortionFormat.FontUnderline = TextUnderlineType.Dotted;
        portion.PortionFormat.LatinFont = new FontData("Times New Roman");
    }
}

presentation.Save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
```

Az eredmény:

![A szövegrészek betűtulajdonságai](font_properties_for_text_portions.png)

## **Szövegmagasság normalizálásának szabályozása**

Használja az [IBasePortionFormat.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/normaliseheight/) elemet sablon tipográfia másolásához vagy a karaktermagasságbeli különbségek vizsgálatához. PowerPointban a normalizálás engedélyezése függőlegesen nyújtja vagy összenyomja az egyes karaktereket, hogy egységes látható magasságot kapjanak a szövegrészben. Nem garantálja a különböző betűtípusok közötti egyenlő magasságot.

Állítsa a tulajdonságot [NullableBool.True vagy False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) értékre a normalizálás kifejezett engedélyezéséhez vagy letiltásához. A `NullableBool.NotDefined` helyi beállítást üresen hagyja, így a részörökli az értéket, például a bekezdés [DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/)-től. Ez nem jelenti a `False` értéket. Használja az [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) és a [IBasePortionFormatEffectiveData.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformateffectivedata/normaliseheight/) lekérdezését a feloldott logikai érték megszerzéséhez.

Az alábbi önálló példa feltételezi, hogy az **Arial** betűtípus telepítve van. Két szövegrészt hoz létre, amelyek ugyanazokat a nagy- és kisbetűket, lejjebb nyúló betűket és ékezetes karaktereket tartalmazzák 54 pontban. Mindkét bekezdés alapértelmezés szerint engedélyezi a normalizálást. A felső rész kifejezetten letiltja, az alsó rész örökli. A keretméretek, margók és bekezdésközök azonosak, a sortörés és az automatikus illeszkedés le van tiltva a konzisztens összehasonlítás érdekében. A példa kiírja a `False: False` és `NotDefined: True` értékeket, majd elmenti a „text_height_normalization.pptx” fájlt.

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

Az alábbi összehasonlítás a mentett prezentációból exportálva látható. A felső sorban a normalizálás letiltott (`False`); az alsó sor örökli az engedélyezett beállítást (`NotDefined` → `True`). Az eredmény reprodukálásához telepítve kell lennie az Arial betűtípusnak.

![Arial 54 pontos szöveg normalizálás nélkül felül és normalizálással alul](text_height_normalization.png)

A normalizálás a karaktermagasságot változtatja anélkül, hogy a hozzárendelt [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/) értéket módosítaná, amely a betűméretet pontban adja meg. A bekezdés [SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) szabályozza a sorközöket, míg a szövegkeret [AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) vezérli, hogyan alkalmazkodik a szöveg vagy a konténer mérete. Ezek a beállítások különböző célokat szolgálnak, és önállóan befolyásolhatják az elrendezést. További információkért a bekezdésformázásról és öröklődésről lásd a [Manage Paragraph](/slides/hu/net/manage-paragraph/) oldalt.

## **Áthúzott vonal alkalmazása és eltávolítása**

Használja az [IBasePortionFormat.StrikethroughType](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/strikethroughtype/) elemet szövegrészen, hogy megjelenítse a javításokat, törölt kifejezéseket vagy korábbi árakat a szöveg törlése nélkül. Állítsa a [TextStrikethroughType.Single vagy Double](https://reference.aspose.com/slides/net/aspose.slides/textstrikethroughtype/) értékre egy vagy két áthúzott vonal megjelenítéséhez.

Az áthúzott vonal eltávolításához rendelje hozzá a `TextStrikethroughType.None` értéket. Ez kifejezetten letiltja a hatást, még ha a környező formázás meghatározna áthúzást is. Ezzel szemben a `TextStrikethroughType.NotDefined` helyi beállítást üresen hagyja, így a szövegrész örökölheti a formázást, például a bekezdéstől. Nem garantálja, hogy az áthúzás eltávolításra kerül. Használja az [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) metódust a végső formázás, beleértve az örökölt értékek, lekérdezéséhez.

Az alábbi önálló példa három árösszehasonlítást hoz létre. Minden bekezdés külön részekkel rendelkezik a címke, a korábbi ár és az aktuális ár számára, így csak a korábbi árra van hatással. Az első sor alkalmazza, majd eltávolítja az áthúzást; a többi sor egyes és dupla áthúzást tart fenn. Ennek a tulajdonságnak a módosítása megőrzi a szöveget és egyéb formázását, beleértve a félkövér korábbi árat.

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

// Alkalmazza az áthúzást, majd kifejezetten eltávolítja az első korábbi árból.
paragraphs[0].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Single;
paragraphs[0].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.None;

paragraphs[1].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Single;
paragraphs[2].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Double;

presentation.Save("strikethrough.pptx", SaveFormat.Pptx);
```

Az eredmény felülről lefelé: nincs áthúzás, egyetlen áthúzás, és dupla áthúzás.

![Korábbi árak áthúzás nélkül, egyetlen áthúzással és dupla áthúzással](strikethrough.png)

## **Szöveg forgatásának beállítása**

Használja az [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/textverticaltype/) elemet előre definiált szövegorientáció beállításához egy alakzaton belül.

Az alábbi kódpélda a szövegorientációt a [TextVerticalType.Vertical270](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/) értékre állítja, amely **90 fokkal ellentétes irányban** forgatja a szöveget:

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

## **Egyéni forgatás beállítása szövegkeretekhez**

Használja az [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/rotationangle/) elemet egyéni forgatási szög beállításához egy [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) számára.

Az alábbi kódpélda a szövegkeretet 3 fokkal az óramutató járásával megegyező irányban forgatja az alakzaton belül:

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

## **Bekezdések sortávolságának beállítása**

Az Aspose.Slides biztosítja a [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/) és [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) elemeket a bekezdésköz szabályozásához. Ezeket a tulajdonságokat az alábbiak szerint használhatja:

* Pozitív érték esetén a sortávolság a sormagasság százalékában adható meg.
* Negatív érték esetén a sortávolság pontban adható meg.

Az alábbi példa a első bekezdésen belüli távolságot a sormagasság 200 %-ára (dupla sorköz) állítja:

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

![A bekezdésen belüli sortávolság](line_spacing.png)

## **Sortörés szabályozása**

A bekezdés sortörési szabályai keskeny szövegblokkoknál és olyan prezentációknál hasznosak, amelyek keverik a latin és a kelet-ázsiai szöveget. Az alábbi tulajdonságok az [IParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/) részei, így egy egész bekezdésre vonatkoznak:

- [LatinLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/latinlinebreak/) szabályozza a latin sortörési szabályokat. Vegyes szöveg esetén a változtatás befolyásolhatja a szomszédos kelet-ázsiai szöveg és írásjelek sortörését is.
- [EastAsianLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/eastasianlinebreak/) szabályozza a kelet-ázsiai sortörési szabályokat, beleértve a sor elején és végén lévő karakterek korlátozásait.

Ezek a szabályok nem helyettesítik az [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) elemet, amely a szövegkereten belüli automatikus sortörést engedélyezi. A sortörés szabályai a layoutot befolyásolják, amikor a sortörés megtörténik; nem szúrnak be sortörő karaktereket. Egy explicit sortörés új sort kényszerít a bekezdésen belül, függetlenül a rendelkezésre álló szélességtől.

Az alábbi önálló példa egy keskeny szövegblokkot hoz létre, amely kínai és latin szöveget tartalmaz. Mindkét sortörési tulajdonságot explicite állítja be, majd elmenti a „line_breaking.pptx” fájlt. A két szabály kipróbálásához változtassa meg a megfelelő értéket, miközben a másik beállítást változatlanul hagyja. A példa 24 pontos Arial és SimSun betűtípusokat használ, 160 pont széles kerettel és 0‑s vízszintes szövegkeret-margóval. Az [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) értéke [TextAutofitType.None](https://reference.aspose.com/slides/net/aspose.slides/textautofittype/), így a szövegméret és a keretméretek rögzítve maradnak.

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

## **Függőleges írásjelek (hanging punctuation) szabályozása**

Az [IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/hangingpunctuation/) lehetővé teszi, hogy a megfelelő írásjelek túlnyúljanak a sor jobb szélének túlra ahelyett, hogy a következő sorba kerülnének. Ez a beállítás az egész bekezdésre vonatkozik, és különbözik a függőleges behúzástól.

Az alábbi önálló példa bekapcsolja a függőleges írásjeleket egy 100 pont széles szövegkeretben, és elmenti a „hanging_punctuation.pptx” fájlt. 24 pontos Arial és 0‑s vízszintes szövegkeret-margó használatával a végpont a „sentence” szó után marad, és túlnyúlik a jobb szélén. Állítsa a tulajdonságot [NullableBool.False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) értékre a összehasonlításhoz: ezekkel a beállításokkal a pont külön sorban jelenik meg. A sortörés engedélyezett, az automatikus illeszkedés le van tiltva a rendelkezésre álló szélesség rögzítése érdekében.

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

Nem minden írásjel függőlegesen helyezhető el. A [korábban leírt betű- és elrendezési feltételek](#control-line-breaking) szintén érvényesek erre az összehasonlításra: a betűtípus, a rendelkezésre álló szélesség, a margók vagy az automatikus illeszkedés módosítása eltüntetheti a látható különbséget.

## **Automatikus illeszkedés (Autofit) típusának beállítása szövegkeretekhez**

Az [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) határozza meg, hogyan viselkedik a szöveg, ha meghaladja a tároló határait. Használja a szöveg összehúzása, túlnyúlása vagy az alakzat automatikus átméretezése vezérlésére. Az alábbi példa úgy állítja be a formátumot, hogy az alakzat átméreteződjön a szöveghez igazodva, majd elmenti az eredményt a „autofit_type.pptx” fájlba.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

Az automatikus sortörés utáni sorok számolásához és ahhoz, hogy lássa, hogyan változik a szöveg vagy az alakzat szélessége, lásd a [Count Rendered Lines](/slides/hu/net/manage-paragraph/) oldalt. A sorok száma önmagában nem jelzi, hogy a szöveg túlcsordul-e a tárolóból.

## **Szövegkeret rögzítési pontjának beállítása**

Az [ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/) határozza meg, hogyan helyezkedik el a szöveg függőlegesen egy alakzaton belül, például a tetején, közepén vagy alján. Az alábbi példa a szöveget az első alakzat aljához rögzíti, és elmenti a „text_anchor.pptx” fájlt.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
```

## **Szöveg tabulátorainak beállítása**

Használja az [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaulttabsize/) és az [IParagraphFormat.Tabs](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/tabs/) elemeket a bekezdés tabulátorainak konfigurálásához. Az alábbi példa az alapértelmezett tabulátor-intervallumot 100 pontra állítja, és egy balra igazított tabulátort ad hozzá 30 pontban. Ezek a beállítások a tabulátor karaktert tartalmazó szövegre hatnak.

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

## **Helyesírási nyelv beállítása**

Az Aspose.Slides biztosítja az [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) elemet, amely lehetővé teszi a helyesírási nyelv beállítását egy szövegrészhez. A helyesírási nyelv meghatározza a PowerPointban a helyesírás‑ és nyelvtan‑ellenőrzés nyelvét.

Az alábbi példa a „presentation.pptx” fájlt igényli, amelynek első alakja egy szövegdoboz az első dián, és legalább egy bekezdést tartalmaz. A első bekezdés tartalmát „1。”‑re cseréli, a betűtípust SimSun-ra állítja, és a Simplified Chinese (`zh-CN`) helyesírási nyelvet rendeli hozzá. Az eredményt a „proofing_language.pptx” fájlba menti:

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

// Állítsa be a helyesírási nyelvet egyszerű kínaira.
textPortion.PortionFormat.LanguageId = "zh-CN";

textPortion.Text = "1。";
paragraph.Portions.Add(textPortion);

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

### **Nyelvi metaadat másolása**

Többnyelvű szöveg sablonból való másolásakor őrizze meg mind az [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/), mind az [IBasePortionFormat.AlternativeLanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/alternativelanguageid/) értékeket. Az alábbi önálló példa forrásrészletet hoz létre, amelynek nyelve az amerikai angol, alternatív nyelve a francia, majd a szöveget és az azonosítókat egy új prezentáció egy részébe másolja.

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

Ha forrást akar használni alternatív nyelv nélkül, hagyja ki a `"fr-FR"` hozzárendelését. Az alternatív azonosító ekkor `null`, és a másolási utasítás megőrzi ennek hiányát anélkül, hogy alapértelmezett értéket vezetne be, még ha a célhelyen korábban már be lett állítva alternatív nyelv.

Ezek az azonosítók nyelvi metaadatot tárolnak. Megőrzésük nem határozza meg, hogy a PowerPoint melyik szótárat használja a helyesírás vagy a nyelvtan ellenőrzéséhez.

## **Alapértelmezett nyelv beállítása**

Használja a [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaulttextlanguage/) elemet a betöltés vagy a prezentáció létrehozása során létrehozott szöveg alapértelmezett nyelvének meghatározásához. Az alábbi példa egy prezentációt hoz létre, amelyben az alapértelmezett szövegnyelv az amerikai angol, egy szövegdobozt ad hozzá, és az első szövegrésznek kiírja az `en-US` értéket.

```cs
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];

// Új téglalap alakzat hozzáadása szöveggel.
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
shape.TextFrame.Text = "Sample text";

// Ellenőrzi az első szövegrész nyelvét.
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine(portion.PortionFormat.LanguageId);
```

## **Alapértelmezett szövegstílus beállítása**

Az alapértelmezett szövegformázás a prezentáció szintjén történő alkalmazásához használja az [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/defaulttextstyle/) elemet.

Az alábbi példa egy 14 pontos félkövér betűtípust állít be alapértelmezettként a felső szintű bekezdésekhez egy új prezentációban, és elmenti a „default_text_style.pptx” fájlt. A szöveg örökölheti ezeket az alapértelmezéseket, hacsak egy konkrétabb formázás felül nem írja őket.

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

## **Szöveg kinyerése a Nagybetűs hatással (All‑Caps)**

PowerPointban a **All Caps** betűhatás alkalmazása a szöveget nagybetűsen jeleníti meg a dián, még akkor is, ha eredetileg kisbetűvel lett beírva. Amikor ilyen szövegrészt kér le az Aspose.Slides, a könyvtár pontosan a beírt szöveget adja vissza. A megjelenített szöveghez a [TextCapType](https://reference.aspose.com/slides/net/aspose.slides/textcaptype/) ellenőrzésével és a visszakapott karakterlánc nagybetűsre konvertálásával kell összevetni, ha az érték `All`.

Ez a példa a „sample2.pptx” fájlt igényli, amelynek első alakja egy szövegdoboz az első dián. Az első bekezdés első része a „Hello, Aspose!” szöveget tartalmazza az All Caps hatással, az alábbi ábrán látható módon.

![Az All Caps hatás](all_caps_effect.png)

Az alábbi kódpélda megmutatja, hogyan lehet kinyerni a **All Caps** hatással rendelkező szöveget:

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

**Hogyan módosíthatom a szöveget egy dián lévő táblázatban?**

A táblázat szövegének módosításához a dián használja az [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) elemet. Iteráljon a cellákon, és frissítse minden cellát az [ICell.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) segítségével, valamint a bekezdés formázását az [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/paragraphformat/) segítségével.

**Hogyan alkalmazhatok fokozatos színátmenetet a szövegre egy PowerPoint dián?**

A fokozatos színátmenet alkalmazásához a szövegre használja az [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/) elemet. Állítsa be az [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) értéket a [FillType.Gradient](https://reference.aspose.com/slides/net/aspose.slides/filltype/) típusra, és konfigurálja a gradient stop‑okat, irányt és átlátszóságot.

Kapcsolódó funkció: [Format text within slides](/slides/hu/features/text-formatting/).