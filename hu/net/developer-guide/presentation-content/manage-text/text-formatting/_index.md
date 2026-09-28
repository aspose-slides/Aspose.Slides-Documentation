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
- betűtípus tulajdonságok
- betűtípus család
- szöveg forgatása
- forgatási szög
- szövegkeret
- sortávolság
- automatikus illesztés tulajdonság
- szövegkeret horgony
- szöveg tabuláció
- alapértelmezett nyelv
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Formázza és stilizálja a szöveget PowerPoint és OpenDocument prezentációkban az Aspose.Slides for .NET segítségével. Testreszabhatja betűtípusokat, színeket, igazítást és egyebeket."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan formázhatja a szöveget PowerPoint és OpenDocument prezentációkban az Aspose.Slides for .NET segítségével. Tárgyalja a háttérszíneket, átlátszóságot, betűközt, betűtípus‑tulajdonságokat, forgatást, bekezdésközöket, automatikus illesztési viselkedést, szöveg‑horgonyzást, tabulátor‑állásokat és nyelvi beállításokat.

Kivéve, ha külön van feltüntetve, a példák a [sample.pptx](sample.pptx) fájlt használják. Az első dián az első alakzat egy szövegdoboz, és annak első bekezdése az alább látható szöveget tartalmazza. Mind a diák, mind az alakzat indexei nulláról indulnak. A félkövér részeket kiválasztó példák hatékony formázást használnak, beleértve az örökölt félkövér formázást:

![Minta szöveg](sample_text.png)

Az egyenes szöveg vagy reguláris kifejezés egyezéseinek kereséséhez és kiemeléséhez tekintse meg a [Keresés és csere szövegben](/slides/hu/net/search-and-replace-text/) útmutatót.

## **Szöveg háttérszínének beállítása**

Használja az [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/defaultportionformat/) interfészt a bekezdés alapértelmezett kiemelési színének beállításához, vagy az [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/hu/net/aspose.slides/ibaseportionformat/highlightcolor/) interfészt az egyedi szövegrészekhez.

Az alábbi példa egy világosszürke kiemelést állít be alapértelmezettként az első bekezdéshez. Az egyedi részeken megadott kiemelési színek felülbírálják ezt az alapértelmezést:

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

Az alábbi kódrészlet bemutatja, hogyan állítható be a háttérszín **félkövér betűtípussal** rendelkező **szövegrészek** számára:

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

Használja az [IParagraphFormat.Alignment](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/alignment/) interfészt a bekezdés igazításának beállításához a szövegkeretben. Az érték lehet középre igazított, balra, jobbra, sorkizárt stb.

Az alábbi kódrészlet megmutatja, hogyan igazítható a bekezdés **középre**:

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

## **Szöveg átlátszóságának beállítása**

A szöveg átlátszósága az [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/ibaseportionformat/fillformat/) színének alfa komponensén keresztül szabályozható. Az alábbi példákban az `alpha = 50` egy 0‑255 skálájú ARGB alfa‑csatorna‑érték, nem százalékos átlátszóság.

Az alábbi kódrészlet azt mutatja, hogyan alkalmazhatunk átlátszóságot az **egész bekezdésre**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Állítsa be a szöveg félig áttetsző fekete kitöltését.
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
```

Az eredmény:

![Az átlátszó bekezdés](transparent_paragraph.png)

Az alábbi kódrészlet azt mutatja, hogyan alkalmazhatunk átlátszóságot **félkövér betűtípussal** rendelkező szövegrészekre:

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

## **Karakterköz beállítása szöveghez**

Használja az [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/hu/net/aspose.slides/ibaseportionformat/spacing/) interfészt a karakterek közötti távolság növelésére vagy csökkentésére egy szövegdobozban. A példák 3 pontnyi távolságot adnak hozzá; negatív értékek összenyomják a szöveget.

Az alábbi C# kód azt mutatja, hogyan növelhető a karakterköz **az egész bekezdésben**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Megjegyzés: Negatív értékekkel a karakterköz összenyomható.
paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // Karakterköz növelése.

presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
```

Az eredmény:

![A karakterköz a bekezdésben](character_spacing_in_paragraph.png)

Az alábbi kódrészlet azt mutatja, hogyan növelhető a karakterköz **félkövér betűtípussal** rendelkező szövegrészekben:

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
        // Megjegyzés: Negatív értékekkel a karakterköz összenyomható.
        portion.PortionFormat.Spacing = 3;  // Karakterköz növelése.
    }
}

presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
```

Az eredmény:

![A karakterköz a szövegrészekben](character_spacing_in_text_portions.png)

### **Kerning letiltása adott betűtípusoknál**

Bizonyos esetekben az Aspose.Slides által renderelt szöveg kissé szorosabbnak tűnhet, mint a PowerPointban megjelenített változat. Ennek oka lehet, hogy a PowerPoint figyelmen kívül hagyja a kerning adatokat bizonyos betűtípusok esetén, még ha a betűtípus tartalmaz érvényes kerning információt és a PowerPoint beállításaiban engedélyezve is van.

Az ilyen esetekben a kerning letiltható azoknál a szövegrészeknél, amelyek az érintett betűtípust használják. Állítsa az [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/hu/net/aspose.slides/ibaseportionformat/kerningminimalsize/) értékét a tényleges betűméretnél nagyobbra. Ez a példa a „presentation.pptx” fájlt igényli, amelynek első alakzata első dián egy szövegdoboz. Ellenőrzi a hatékony betűneveket, beleértve az örökölt betűtípusokat, és 100 pontos küszöböt állít be a Roboto betűtípust használó részekhez. Ez letiltja a kerninget a 100 pont alatti betűmérettel rendelkező egyező részeknél:

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

A küszöbnél alacsonyabb méretű egyező szöveg esetén ez a beállítás megakadályozza a kerninget, és segíthet a Aspose.Slides renderelését a PowerPoint vizuális kimenetéhez igazítani az érintett betűtípusoknál.

## **Szöveg betűtípus‑tulajdonságainak kezelése**

A betűtípus‑tulajdonságok beállíthatók a bekezdés szintjén az [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/defaultportionformat/) vagy egyedi részeken az [IPortionFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/iportionformat/) segítségével.

Az alábbi példa beállítja az első bekezdés alapértelmezett betűtípusát 12‑pontos Times New Roman‑ra, félkövér, dőlt és pontozott aláhúzással. Az egyedi részeken megadott formázás felülbírálja ezeket az alapértelmezéseket:

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

![A bekezdés betűtípus‑tulajdonságai](font_properties_for_paragraph.png)

Az alábbi példa 13‑pontos Times New Roman‑t, dőlt formázást és pontozott aláhúzást alkalmaz azokra a részekre, amelyek hatékony formázása félkövér:

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

![A szövegrészek betűtípus‑tulajdonságai](font_properties_for_text_portions.png)

## **Szöveg forgatása**

Használja az [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframeformat/textverticaltype/) interfészt egy előre definiált szövegorientáció beállításához az alakzaton belül.

Az alábbi kódrészlet a szövegorientációt a [TextVerticalType.Vertical270](https://reference.aspose.com/slides/hu/net/aspose.slides/textverticaltype/) értékre állítja, ami **90 fokkal balra forgatja** a szöveget:

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

## **Egyéni forgatás szövegkeretekhez**

Használja az [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframeformat/rotationangle/) interfészt egy egyéni forgatási szög beállításához egy [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/) számára.

Az alábbi kódrészlet 3 fokkal forgatja az óramutató járásával megegyező irányban a szövegkeretet a alakzaton belül:

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

![Az egyéni szöveg forgatása](custom_text_rotation.png)

## **Bekezdés sortávolságának beállítása**

Az Aspose.Slides a [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/spacebefore/) és [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/spacewithin/) használatával szabályozza a bekezdés távolságát. Ezeket a tulajdonságokat a következőképpen kell használni:

* Pozitív érték esetén a sortávolság a sormagasság százalékában van megadva.
* Negatív érték esetén a sortávolság pontban van megadva.

Az alábbi példa a bekezdésen belüli távolságot a sormagasság **200 %‑ára** állítja (dupla sorköz):

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

## **Sorok megtörésének szabályozása**

A bekezdés sorok megtörésének szabályai szűk szövegtömbök és latin és kelet-ázsiai szöveget keverő prezentációk esetén hasznosak. Az alábbi tulajdonságok az [IParagraphFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/) részei, ezért egy egész bekezdésre vonatkoznak:

- [LatinLineBreak](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/latinlinebreak/) szabályozza a latin sorok megtörését. Vegyes szöveg esetén ennek módosítása befolyásolhatja a kelet-ázsiai szöveg és az írásjelek tördelését is.
- [EastAsianLineBreak](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/eastasianlinebreak/) szabályozza a kelet-ázsiai sorok megtörését, beleértve a sor elején és végén álló karakterek korlátozását.

E szabályok nem helyettesítik az [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframeformat/wraptext/) beállítást, amely automatikus sortörést aktivál a szövegkereten belül. Ezek a szabályok a csomagolás során befolyásolják a layoutot; nem szúrnak be sorvége karaktert. Egy explicit sortörés új sort hoz létre a bekezdésen belül a rendelkezésre álló szélességtől függetlenül.

Az alábbi önmagában is futtatható példa egy szűk szövegtömböt hoz létre, amely kínai és latin szöveget tartalmaz. Mindkét sortörési szabályt expliciten beállítja, majd a „line_breaking.pptx” fájlt menti. A szabályok kipróbálásához módosítsa az adott tulajdonság értékét, miközben a másik beállítást változatlanul hagyja. A példa 24‑pontos Arial‑t és SimSun‑t használ, 160‑pontos keret szélességgel és vízszintes szövegkeret‑margóval 0. Az [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframeformat/autofittype/) értéke [TextAutofitType.None](https://reference.aspose.com/slides/hu/net/aspose.slides/textautofittype/), így a szövegméret és a keretméret rögzítve marad:

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

## **Függőleges írásjelek kezelése**

Az [IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/hangingpunctuation/) lehetővé teszi, hogy a jogosult írásjelek a sor jobb széle mögé nyúljanak, ahelyett, hogy a következő sorra kerülnek. Ez az egész bekezdésre érvényes, és eltér a függőleges behúzástól.

Az alábbi önálló példa engedélyezi a függő írásjeleket egy 100‑pontos szélességű szövegkeretben, és a „hanging_punctuation.pptx” fájlt menti. 24‑pontos Arial és vízszintes margó 0 esetén a végpont a „sentence” szó után marad, és a jobb szövegél fölé nyúlik. Állítsa a tulajdonságot [NullableBool.False](https://reference.aspose.com/slides/hu/net/aspose.slides/nullablebool/) értékre a összehasonlításhoz: ebben az esetben a pont külön sorba kerül. A sortörés engedélyezett, az autofit letiltott, hogy a rendelkezésre álló szélesség rögzítve maradjon.

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

Nem minden írásjel függő lehet. A fenti [betűtípus‑ és elrendezési feltételek](#conditions-and-limitations) szintén vonatkoznak erre a példára: a betűtípus, a rendelkezésre álló szélesség, a margók vagy az autofit beállítások módosítása eltüntetheti a látható különbséget.

## **Automatikus méretezés típusa szövegkeretekhez**

Az [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframeformat/autofittype/) határozza meg, hogyan viselkedik a szöveg, ha meghaladja a tartálya határait. Ezzel szabályozhatja, hogy a szöveg zsugorodjon, túlcsorduljon vagy a forma mérete automatikusan változzon. Az alábbi példa úgy konfigurálja a formát, hogy a szöveghez igazodjon, és a „autofit_type.pptx” fájlba menti az eredményt:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

A sorok számlálásához automatikus sortörés után, valamint a szöveg vagy forma szélesség változtatásának hatásának megtekintéséhez lásd a [Renderelt sorok számlálása](/slides/hu/net/manage-paragraph/) útmutatót. Maga a sorok száma önmagában nem jelzi, hogy a szöveg túlfut-e a tartályon.

## **Szövegkeret horgony beállítása**

Az [ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframeformat/anchoringtype/) határozza meg, hogyan helyezkedik el függőlegesen a szöveg egy alakzaton belül, például felül, középen vagy alul. Az alábbi példa a szöveget az első alakzat aljára horgonyozza, majd a „text_anchor.pptx” fájlba menti az eredményt:

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

Használja az [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/defaulttabsize/) és az [IParagraphFormat.Tabs](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/tabs/) interfészeket a tabulátor‑állások konfigurálásához egy bekezdésben. Az alábbi példa a default tabulátortávolságot 100 pontra állítja, és egy balra igazított tabulátor‑állást ad hozzá 30 pontnál. Ezek a beállítások a tabulátor‑karaktert tartalmazó szövegre hatnak.

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

## **Javító nyelv beállítása**

Az Aspose.Slides biztosítja az [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/hu/net/aspose.slides/ibaseportionformat/languageid/) interfészt, amely lehetővé teszi a szövegrész helyesírási nyelvének beállítását. A helyesírási nyelv határozza meg, hogy a PowerPoint milyen nyelven ellenőrizze a helyesírást és a nyelvtant.

Az alábbi példa a „presentation.pptx” fájlt igényli, amelynek első alakzata első dián egy szövegdoboz, és legalább egy bekezdést tartalmaz. A példa az első bekezdés tartalmát „1。”‑re cseréli, a betűtípust SimSun‑ra állítja, és a Simplified Chinese helyesírási nyelvet (`zh-CN`) rendeli hozzá. Az eredményt a „proofing_language.pptx” fájlba menti:

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

## **Alapértelmezett nyelv beállítása**

Használja a [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/hu/net/aspose.slides/loadoptions/defaulttextlanguage/) beállítást a betöltés vagy létrehozás során létrejövő szöveg alapértelmezett nyelvének meghatározásához. Az alábbi példa egy prezentációt hoz létre, amelynek alapértelmezett szövegnyelv az US English, egy szövegdobozt ad hozzá, és kiírja az első szövegrész nyelvi kódját `en-US`:

```cs
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];

// Új téglalap alakzatot adjon hozzá szöveggel.
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
shape.TextFrame.Text = "Sample text";

// Ellenőrizze az első szövegrész nyelvét.
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine(portion.PortionFormat.LanguageId);
```

## **Alapértelmezett szövegstílus beállítása**

Az alapértelmezett szövegformázás prezentációs szinten történő alkalmazásához használja a [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentation/defaulttextstyle/) interfészt.

Az alábbi példa 14‑pontos félkövér betűtípust állít be alapértelmezettként a legfelső szintű bekezdésekhez egy új prezentációban, majd a „default_text_style.pptx” fájlba menti. A szöveg örökölheti ezeket az alapértelmezéseket, hacsak nincs specifikusabb formázás, amely felülírja őket.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
// Szerezze be a legfelső szintű bekezdésformátumot.
var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

if (paragraphFormat != null)
{
    paragraphFormat.DefaultPortionFormat.FontHeight = 14;
    paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
}

presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
```

## **Szöveg kinyerése ALL CAPS hatással**

PowerPointban az **All Caps** betűhatás alkalmazása nagybetűs megjelenítést eredményez a dián, még ha a szöveget eredetileg kisbetűvel írták is. Amikor az Aspose.Slides-szel ilyen szövegrészt kérdezi le, a könyvtár pontosan a beírt szöveget adja vissza. A megjelenített szöveghez való illesztéshez ellenőrizze a [TextCapType](https://reference.aspose.com/slides/hu/net/aspose.slides/textcaptype/) értékét, és konvertálja a visszaadott karakterláncot nagybetűssé, ha a value `All`.

Ez a példa a „sample2.pptx” fájlt igényli, amelynek első alakzata első dián egy szövegdoboz. Az első bekezdés első része a „Hello, Aspose!” szöveget tartalmazza, All Caps hatással, ahogy alább látható.

![Az All Caps hatás](all_caps_effect.png)

Az alábbi kódrészlet megmutatja, hogyan nyerhető ki a szöveg az **All Caps** hatással:

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

A táblázatban lévő szöveg módosításához használja az [ITable](https://reference.aspose.com/slides/hu/net/aspose.slides/itable/) interfészt. Iterálja végig a cellákat, és frissítse őket az [ICell.TextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/icell/textframe/) és a bekezdés formázást az [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraph/paragraphformat/) segítségével.

**Hogyan alkalmazhatok színátmenetet a szövegre egy PowerPoint dián?**

A színátmenet alkalmazásához használja az [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/ibaseportionformat/fillformat/) interfészt. Állítsa az [IFillFormat.FillType](https://reference.aspose.com/slides/hu/net/aspose.slides/ifillformat/filltype/) értékét [FillType.Gradient](https://reference.aspose.com/slides/hu/net/aspose.slides/filltype/)-ra, és konfigurálja a gradient‑állomásokat, irányt és átlátszóságot.