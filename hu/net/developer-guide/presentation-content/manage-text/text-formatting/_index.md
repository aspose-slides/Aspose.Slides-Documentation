---
title: "Prezentáció szövegének formázása .NET-ben"
linktitle: "Szövegformázás"
type: docs
weight: 50
url: /hu/net/text-formatting/
keywords:
- "bekezdés igazítása"
- "szövegstílus"
- "szöveg háttér"
- "szöveg átlátszóság"
- "karakterköz"
- "betűtulajdonságok"
- "betűcsalád"
- "szöveg forgatása"
- "forgatási szög"
- "szövegkeret"
- "sorköz"
- "automatikus illesztés tulajdonság"
- "szövegkeret rögzítése"
- "szöveg tabuláció"
- "alapértelmezett nyelv"
- PowerPoint
- OpenDocument
- "prezentáció"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Formázza és stílusozza a szöveget PowerPoint és OpenDocument prezentációkban az Aspose.Slides for .NET segítségével. Testreszabhat betűtípusokat, színeket, igazítást és egyebeket."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet szöveget formázni PowerPoint és OpenDocument bemutatókban az Aspose.Slides for .NET segítségével. Tárgyalja a háttérszíneket, átlátszóságot, karakterközöket, betűtulajdonságokat, elforgatást, bekezdésközöket, automatikus illesztés viselkedését, szöveg rögzítését, tabulátorállásokat és nyelvi beállításokat.

Kivéve, ha másként nem állítják, a példák a [sample.pptx](sample.pptx) fájlt használják. Az első dia első alakja egy szövegdoboz, és az első bekezdése az alább látható szöveget tartalmazza. Mind a dia, mind az alak indexe nullával kezdődik. A félkövér részeket kiválasztó példák hatékony formázást használnak, beleértve az örökölt félkövér formázást:

![Minta szöveg](sample_text.png)

A szöveg keresése és cseréje, hogy megtalálja és kiemelje a szó szerinti vagy reguláris kifejezéssel egyező szövegeket, lásd a [Szöveg keresése és cseréje](/slides/hu/net/search-and-replace-text/).

## **Szöveg háttérszín beállítása**

Használja az [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) a bekezdés alapértelmezett kiemelési színének beállításához, vagy használja az [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/highlightcolor/) egyedi szövegrészekhez.

A következő példa világosszürke kiemelést állít be alapértelmezettként az első bekezdéshez. Az egyedi részekre alkalmazott kiemelő színek felülbírálják ezt az alapértelmezést:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Állítsa be a kiemelés színét az egész bekezdéshez.
paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
```

Az eredmény:

![A szürke bekezdés](gray_paragraph.png)

Az alábbi kódpélda bemutatja, hogyan állítsuk be a háttérszínt **félkövér betűtípussal rendelkező szövegrészek** esetén:

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

![A szürke szövegrészek](gray_text_portions.png)

## **Szöveg bekezdések igazítása**

Használja az [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) a bekezdés igazításának beállításához egy szövegkereten belül. Az érték lehet középre, balra, jobbra, sorkizárt stb.

A következő kódrészlet megmutatja, hogyan igazítsuk a bekezdést **középre**:

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

## **Betűtípusok igazítása egy sorban**

Használja az [IParagraphFormat.FontAlignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/fontalignment/) a soron belül különböző betűméretű szövegrészek függőleges igazításához. Ez a beállítás az egész bekezdésre vonatkozik, és minden sorban szabályozza az igazítást.

A következő önálló példa négy címkézett szövegdobozt hoz létre egy dián. Minden bekezdés ugyanazt a szöveget tartalmazza 18, 36 és 54 pont méretben, különböző betűigazítással. Arial betűtípust használ, letiltja az automatikus illesztést és a sortörést, és úgy méretezi a szövegkereteket, hogy egy sor elférjen benne.

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

![Az alapvonal, felső, középső és alsó betűtípus-igazítás összehasonlítása vegyes betűméretekkel](font_alignment.png)

A betűigazítás betűmetrikákat használ, ezért az egyes betűk látható szélei nem feltétlenül illeszkednek pontosan egymáshoz. A példa nagybetűt és egy lejjebb nyúló betűt is tartalmaz, hogy megmutassa a különbséget az alapvonal és az alsó igazítás között. A betűk elérhetősége, helyettesítése, a használt karakterek és a betűméretek különbsége befolyásolja az eredményt. A keret méretei, margói, sortávolsága, sortörése és az automatikus illesztés szintén hatnak a megjelenésre; a módok összehasonlításához ugyanazokat a betűket és elrendezési beállításokat használja.

Ez a beállítás eltér a [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) beállítástól, amely a vízszintes bekezdésigazítást szabályozza, és a [ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/) beállítástól, amely a szövegtömb függőleges pozicionálását határozza meg az alakban. A felső- és alsó indexelés a [IBasePortionFormat.Escapement](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/escapement/) használatával egyes szövegrészeket az alapvonalhoz képest eltol, ahelyett, hogy a bekezdés soraira vonatkozó betűigazítást állítaná be.

## **Átlátszóság beállítása a szöveghez**

A szöveg átlátszóságát az [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/) színének alfa komponensével szabályozzák. Az alábbi példákban az `alpha = 50` egy ARGB alfa-csatorna érték a 0‑255 skálán, nem átlátszósági százalék.

Az alábbi kódpélda megmutatja, hogyan alkalmazzuk az átlátszóságot az **egész bekezdésre**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Állítson be félig átlátszó fekete kitöltést a szöveghez.
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
```

Az eredmény:

![Az átlátszó bekezdés](transparent_paragraph.png)

A következő kódpélda megmutatja, hogyan alkalmazzuk az átlátszóságot **félkövér betűtípussal rendelkező szövegrészekre**:

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

## **Karakterköz beállítása a szöveghez**

Használja az [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/spacing/) a karakterek közötti távolság növelésére vagy csökkentésére egy szövegdobozban. A példák 3 pont távolságot adnak hozzá; negatív értékek szorítják a szöveget.

Az alábbi C# kód megmutatja, hogyan növelje a karakterközt az **egész bekezdésben**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Megjegyzés: Negatív értékek használata a karakterköz szorításához.
paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // Kiterjesztett karakterköz.

presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
```

Az eredmény:

![A karakterköz a bekezdésben](character_spacing_in_paragraph.png)

Az alábbi kódpélda megmutatja, hogyan növelje a karakterközt **félkövér betűtípussal rendelkező szövegrészekben**:

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
        // Megjegyzés: Negatív értékek használata a karakterköz szorításához.
        portion.PortionFormat.Spacing = 3;  // Karakterköz növelése.
    }
}

presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
```

Az eredmény:

![A karakterköz a szövegrészekben](character_spacing_in_text_portions.png)

### **Kerning letiltása bizonyos betűtípusoknál**

Bizonyos esetekben az Aspose.Slides által renderelt szöveg kissé szorosabb lehet, mint a PowerPoint-ban megjelenő szöveg. Ez akkor fordulhat elő, ha a PowerPoint egyes betűtípusoknál figyelmen kívül hagyja a kerning adatokat, még akkor is, ha a betűtípus tartalmaz érvényes kerning információt és a PowerPoint beállításaiban a kerning engedélyezve van.

Az ilyen esetekben, hogy a renderelt kimenet közelebb legyen a PowerPoint-hoz, letilthatja a kerninget azoknál a szövegrészeknél, amelyek az érintett betűtípust használják. Állítsa be az [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kerningminimalsize/) értékét nagyobbra, mint a tényleges betűméret. Ez a példa a „presentation.pptx” fájlt igényli, amelynek első diáján az első alak egy szövegdoboz. Ellenőrzi a hatékony betűneveket, beleértve az örökölt betűket, és 100 pontos küszöböt állít be a Roboto betűtípust használó részekhez. Ez letiltja a kerninget azokra a részekre, amelyek betűmérete 100 pont alatti:

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

Az alábbi küszöb alatti szövegek esetén ez a beállítás megakadályozza a kerninget, és segíthet az Aspose.Slides megjelenítését a PowerPoint vizuális kimenetével összehangolni a PowerPoint-specifikus viselkedés által érintett betűtípusok esetén.

## **Szöveg betűtulajdonságok kezelése**

A betűtulajdonságok beállíthatók a bekezdés szintjén az [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) vagy egyedi részeknél az [IPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/) segítségével.

A következő példa az első bekezdés alapértelmezett betűtípusát 12 pontos Times New Roman-ra állítja félkövér, dőlt és pontozott aláhúzással. Az egyedi részekre alkalmazott explicit formázás felülbírálja ezeket az alapértelmezéseket:

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

![A bekezdés betűtulajdonságai](font_properties_for_paragraph.png)

A következő példa 13 pontos Times New Roman-t, dőlt formázást és pontozott aláhúzást alkalmaz azokra a részekre, amelyek hatékony formázása félkövér:

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

![A szövegrészek betűtulajdonságai](font_properties_for_text_portions.png)

## **Szöveg forgatás beállítása**

Használja az [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/textverticaltype/) előre definiált szövegorientáció beállításához egy alakban.

Az alábbi kódpélda a szövegorientációt a formában a [TextVerticalType.Vertical270](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/) értékre állítja, ami a szöveget **90 fokkal balra (óramutatóval ellentétes irányban) fordítja**:

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

![A szöveg forgatás](text_rotation.png)

## **Egyéni forgatás beállítása szövegkeretekhez**

Használja az [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/rotationangle/) egyedi forgatási szög megadásához egy [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) számára.

Az alábbi kódpélda a szövegkeretet 3 fokkal óramutatóval egyaránt a forma belsejében forgatja el:

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

![Az egyéni szöveg forgatás](custom_text_rotation.png)

## **Bekezdés sorközének beállítása**

Az Aspose.Slides a [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/) és [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) tulajdonságokkal szabályozza a bekezdésközöket. Ezeket a tulajdonságokat a következőképpen használják:

* Pozitív érték esetén a sorköz a sor magasságának százalékában adható meg.
* Negatív érték esetén a sorköz pontban adható meg.

A következő példa az első bekezdésre 200 % sormagasságú (dupla) sorközöt állít be:

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

![A sorköz a bekezdésen belül](line_spacing.png)

## **Sortörés szabályainak vezérlése**

A bekezdés sortörés szabályai szűk szövegblokkoknál és olyan prezentációknál hasznosak, ahol latin és kelet-ázsiai szöveg keveredik. Ezek a tulajdonságok az [IParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/) részei, így egy egész bekezdésre vonatkoznak:

- [LatinLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/latinlinebreak/) szabályozza a latin sortörés szabályait. Vegyes szöveg esetén ennek módosítása befolyásolhatja a szomszédos kelet-ázsiai szöveg és írásjelek sortörését is.
- [EastAsianLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/eastasianlinebreak/) szabályozza a kelet-ázsiai sortörés szabályait, beleértve a sor elején és végén álló karakterek korlátozását.

Ezek a szabályok nem helyettesítik az [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/)-t, amely automatikus sortörést biztosít a szövegkereten belül. A sortörés szabályok a layoutot befolyásolják, amikor a sortörés megtörténik; nem illesztenek sortörés karaktert. Egy explicit sortörés új sort hoz létre a bekezdésen belül, függetlenül a rendelkezésre álló szélességtől.

Az alábbi önálló példa egy keskeny szövegblokkot hoz létre, amely kínai és latin szöveget tartalmaz. Mindkét sortörés tulajdonságot explicit módon beállítja, majd elmenti a „line_breaking.pptx” fájlt. Az egyes szabályok teszteléséhez módosítsa a megfelelő tulajdonság értékét, miközben a másik beállítást változatlanul hagyja. A példa 24 pont Arial és SimSun betűtípusokat használ 160 pont széles kerettel és nulla vízszintes szövegkeret-margóval. Az [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) értéke [TextAutofitType.None](https://reference.aspose.com/slides/net/aspose.slides/textautofittype/), így a szövegméret és a keret méretei rögzítve maradnak.

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

## **Függő írásjelek vezérlése**

Az [IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/hangingpunctuation/) lehetővé teszi, hogy az igénybe vehető írásjelek a sor jobb szélén túlra nyúlnak, ahelyett, hogy a következő sorra kerülnének. A beállítás az egész bekezdésre vonatkozik, és eltér a függő behúzástól.

Az alábbi önálló példa bekapcsolja a függő írásjeleket egy 100 pont széles szövegkeretben, majd elmenti a „hanging_punctuation.pptx” fájlt. 24 pont Arial és nulla vízszintes szövegkeret-margó mellett a végző pont a „sentence” után marad, és a jobb szövegél fölé nyúlik. Állítsa a tulajdonságot [NullableBool.False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/)-ra a összehasonlításhoz: ezen beállítások mellett a pont külön sorba kerül. A sortörés engedélyezett, az automatikus illesztés letiltott, hogy a rendelkezésre álló szélesség rögzített maradjon.

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

Nem minden írásjel képes függő módra. Az [a fent leírt betű- és elrendezési feltételek](#control-line-breaking) szintén érvényesek erre az összehasonlításra: a betűtípus, a rendelkezésre álló szélesség, a margók vagy az automatikus illesztés módosítása eltüntetheti a látható különbséget.

## **Automatikus illesztés típusának beállítása szövegkeretekhez**

Az [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) meghatározza, hogyan viselkedik a szöveg, ha meghaladja a tároló határait. Ezzel szabályozható, hogy a szöveg zsugorodjon, kifolyjon vagy a forma automatikusan átméreteződjön. A következő példa a formát úgy konfigurálja, hogy a szöveghez igazodva méretezze át, majd elmenti az eredményt a „autofit_type.pptx” fájlba.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

Az automatikus sortörés utáni sorok számolásához és ahhoz, hogy lássa, hogyan változik a szöveg vagy a forma szélessége, lásd a [Megjelenített sorok számolása](/slides/hu/net/manage-paragraph/). A sorok száma önmagában nem mutatja, hogy a szöveg kifolyik-e a tárolóból.

## **Szövegkeretek rögzítési pontjának beállítása**

Az [ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/) definiálja, hogyan helyezkedik el a szöveg függőlegesen egy alakban, például a tetején, közepén vagy alján. A következő példa a szöveget az első alak aljára rögzíti, majd elmenti az eredményt a „text_anchor.pptx” fájlba.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
```

## **Szöveg tabulátor beállítása**

Használja az [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaulttabsize/) és az [IParagraphFormat.Tabs](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/tabs/) elemeket tabulátorok konfigurálásához egy bekezdésben. A következő példa az alapértelmezett tabulátor-intervallumot 100 pontra állítja, és egy balra igazított tabulátort ad hozzá 30 pontnál. Ezek a beállítások a tabulátor karaktereket tartalmazó szövegre hatnak.

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

Az Aspose.Slides a [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) segítségével lehetővé teszi, hogy egy szövegrésznek ellenőrző nyelvet állítson be. Az ellenőrző nyelv határozza meg, hogy a PowerPoint milyen nyelven ellenőrzi a helyesírást és a nyelvtant.

A következő példa a „presentation.pptx” fájlt igényli, amelynek első diáján az első alak egy szövegdoboz, és legalább egy bekezdést tartalmaz. Lecseréli az első bekezdés tartalmát „1。”‑ra, a betűtípust SimSun‑ra állítja, és a Simplified Chinese ellenőrző nyelvet (`zh-CN`) rendeli hozzá. Az eredményt a „proofing_language.pptx” fájlba menti:

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

// Állítsa be a lektorálási nyelvet egyszerű kínai nyelvre.
textPortion.PortionFormat.LanguageId = "zh-CN";

textPortion.Text = "1。";
paragraph.Portions.Add(textPortion);

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

## **Alapértelmezett nyelv beállítása**

Használja a [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaulttextlanguage/) beállítást a szövegek alapértelmezett nyelvének meghatározásához a prezentáció betöltése vagy létrehozása során. A következő példa egy prezentációt hoz létre, amelynek alapértelmezett szövegnyelvének az amerikai angolt (`en-US`) állítja be, egy szövegdobozt ad hozzá, és az első szövegrészhez kiírja az `en-US` értéket.

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

// Ellenőrizze az első rész nyelvét.
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine(portion.PortionFormat.LanguageId);
```

## **Alapértelmezett szövegstílus beállítása**

Az alapértelmezett szövegformázás alkalmazásához a prezentáció szintjén használja a [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/defaulttextstyle/) elemet.

A következő példa egy 14 pontos félkövér betűtípust állít be alapértelmezettként a felső szintű bekezdésekhez egy új prezentációban, majd elmenti a „default_text_style.pptx” fájlt. A szöveg örökölheti ezeket az alapértelmezéseket, hacsak egy specifikusabb formázás nem írja felül őket.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
// Get the top level paragraph format.
var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

if (paragraphFormat != null)
{
    paragraphFormat.DefaultPortionFormat.FontHeight = 14;
    paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
}

presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
```

## **Szöveg kinyerése a NAGYBETŰS hatással**

PowerPointban a **All Caps** betűhatás alkalmazása a szöveget nagybetűsnek jeleníti meg a dián, még akkor is, ha eredetileg kisbetűkkel lett beírva. Amikor ilyen szövegrészt kér le az Aspose.Slides, a könyvtár pontosan úgy adja vissza a szöveget, ahogy beírták. A megjelenített szöveghez való illeszkedéshez ellenőrizze a [TextCapType](https://reference.aspose.com/slides/net/aspose.slides/textcaptype/) típusát, és konvertálja a visszakapott karakterláncot nagybetűssé, ha az érték `All`.

Ez a példa a „sample2.pptx” fájlt igényli, amelynek első diáján az első alak egy szövegdoboz. Az első bekezdés első része a „Hello, Aspose!” szöveget tartalmazza a NAGYBETŰS hatással, ahogy az alább látható.

![A NAGYBETŰS hatás](all_caps_effect.png)

Az alábbi kódpélda megmutatja, hogyan nyerje ki a szöveget a **NAGYBETŰS** hatással:

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

A táblázatban lévő szöveg módosításához használja a [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) elemet. Iteráljon a cellákon, és frissítse az egyes cellákat a [ICell.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) és a bekezdésformázást a [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/paragraphformat/) segítségével.

**Hogyan alkalmazhatok fokozatos színátmenetet a szövegre egy PowerPoint diá körül?**

A szöveg fokozatos színátmenet alkalmazásához használja az [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/) elemet. Állítsa a [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) értékét a [FillType.Gradient](https://reference.aspose.com/slides/net/aspose.slides/filltype/) típusra, és konfigurálja a gradient állomásokat, irányt és átlátszóságot.