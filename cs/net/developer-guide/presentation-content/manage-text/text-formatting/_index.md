---
title: Formátování textu v prezentaci v .NET
linktitle: Formátování textu
type: docs
weight: 50
url: /cs/net/text-formatting/
keywords:
- zarovnání odstavce
- styl textu
- pozadí textu
- průhlednost textu
- mezery mezi znaky
- vlastnosti písma
- rodina písma
- otočení textu
- úhel otočení
- textový rámeček
- řádkování
- vlastnost automatického přizpůsobení
- ukotvení textového rámečku
- tabulace textu
- výchozí jazyk
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Formátujte a stylizujte text v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro .NET. Přizpůsobte písma, barvy, zarovnání a další."
---
## **Přehled**

Tento článek ukazuje, jak formátovat text v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro .NET. Pokrývá barvy pozadí, průhlednost, mezery mezi znaky, vlastnosti písma, otočení, mezery odstavců, chování automatického přizpůsobení, ukotvení textu, tabulátory a nastavení jazyka.

Pokud není uvedeno jinak, příklady používají [sample.pptx](sample.pptx). První tvar na první snímku je textové pole a jeho první odstavec obsahuje text zobrazený níže. Indexy snímků i tvarů jsou nulové. Příklady, které vybírají tučné části, používají efektivní formátování, včetně zděděného tučného formátování:

![Ukázkový text](sample_text.png)

Pro vyhledání a zvýraznění doslovného textu nebo shod regulárního výrazu viz [Vyhledávání a nahrazování textu](/slides/cs/net/search-and-replace-text/).

## **Nastavit barvu pozadí textu**

Použijte [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) k nastavení výchozí barvy zvýraznění pro odstavec nebo použijte [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/highlightcolor/) pro jednotlivé části textu.

Následující příklad nastaví světle šedé zvýraznění jako výchozí pro první odstavec. Výslovně nastavené barvy zvýraznění u jednotlivých částí mají přednost před tímto výchozím nastavením:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Nastavte barvu zvýraznění pro celý odstavec.
paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
```

Výsledek:

![Šedý odstavec](gray_paragraph.png)

Ukázkový kód níže ukazuje, jak nastavit barvu pozadí pro **části textu s tučným písmem**:

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
        // Nastavte barvu zvýraznění pro část textu.
        portion.PortionFormat.HighlightColor.Color = Color.LightGray;
    }
}

presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
```

Výsledek:

![Šedé textové části](gray_text_portions.png)

## **Zarovnat odstavce textu**

Použijte [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) k nastavení zarovnání odstavce v textovém rámečku. Hodnota může být centrovaná, zarovnaná vlevo, zarovnaná vpravo, do bloku a podobně.

Následující ukázkový kód ukazuje, jak zarovnat odstavec do **centra**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Nastavte zarovnání odstavce na střed.
paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
```

Výsledek:

![Zarovnaný odstavec](aligned_paragraph.png)

## **Zarovnat písma v řádku**

Použijte [IParagraphFormat.FontAlignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/fontalignment/) k vertikálnímu zarovnání částí textu s různými velikostmi písma v rámci řádku. Toto nastavení platí pro celý odstavec a řídí zarovnání v každém z jeho řádků.

Následující samostatný příklad vytvoří čtyři pojmenovaná textová pole na jednom snímku. Každý odstavec obsahuje stejný text ve velikostech 18, 36 a 54 bodů, s různým zarovnáním písma. Používá Arial, vypíná automatické přizpůsobení a zalamování a udržuje textové rámce dostatečně velké pro jeden řádek.

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

Výsledek:

![Porovnání zarovnání Baseline, Top, Center a Bottom při smíšených velikostech písma](font_alignment.png)

Zarovnání písma používá metriky písma, takže viditelné okraje jednotlivých písmen se nemusí přesně shodovat. Příklad obsahuje jak velké písmeno, tak dolní část, aby ukázal rozdíl mezi zarovnáním na základní linku a zarovnáním dole. Dostupnost písma a jeho náhrada, použité znaky a rozdíl ve velikostech písma ovlivňují výsledek. Rozměry rámce, okraje, řádkování, zalamování a automatické přizpůsobení také ovlivňují rozvržení; při porovnávání režimů používejte stejné fonty a nastavení rozvržení.

Toto nastavení se liší od [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/), které řídí horizontální zarovnání odstavce, a od [ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/), které umisťuje textový blok vertikálně uvnitř tvaru. Formátování horní indexu a dolního indexu pomocí [IBasePortionFormat.Escapement](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/escapement/) posouvá jednotlivé části relativně k základní lince místo nastavení zarovnání písma pro řádky odstavce.

## **Nastavit průhlednost textu**

Průhlednost textu se řídí alfou komponenty barvy přiřazené k [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/). V níže uvedených příkladech je `alpha = 50` hodnota alfa kanálu ARGB v rozsahu 0–255, ne procento průhlednosti.

Ukázkový kód níže ukazuje, jak aplikovat průhlednost na **celý odstavec**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Nastavte poloprůhlednou černou výplň pro text.
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
```

Výsledek:

![Průhledný odstavec](transparent_paragraph.png)

Následující ukázkový kód ukazuje, jak aplikovat průhlednost na **části textu s tučným písmem**:

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
        // Nastavte průhlednost části textu.
        portion.PortionFormat.FillFormat.FillType = FillType.Solid;
        portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);
    }
}

presentation.Save("transparent_text_portions.pptx", SaveFormat.Pptx);
```

Výsledek:

![Průhledné textové části](transparent_text_portions.png)

## **Nastavit mezery mezi znaky v textu**

Použijte [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/spacing/) k rozšíření nebo zmenšení mezer mezi znaky v textovém poli. Příklady přidávají 3 body mezery; záporné hodnoty zmenšují text.

Následující C# kód ukazuje, jak rozšířit mezery mezi znaky v **celém odstavci**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Poznámka: Použijte záporné hodnoty k zmenšení mezery mezi znaky.
paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // Zvětšit mezeru mezi znaky.

presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
```

Výsledek:

![Mezery mezi znaky v odstavci](character_spacing_in_paragraph.png)

Ukázkový kód níže ukazuje, jak rozšířit mezery mezi znaky v **částech textu s tučným písmem**:

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
        // Poznámka: Použijte záporné hodnoty k zmenšení mezery mezi znaky.
        portion.PortionFormat.Spacing = 3;  // Zvětšit mezeru mezi znaky.
    }
}

presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
```

Výsledek:

![Mezery mezi znaky v textových částech](character_spacing_in_text_portions.png)

### **Zakázat kerning pro konkrétní písma**

V některých případech může text vykreslený pomocí Aspose.Slides vypadat mírně těsněji než stejný text zobrazený v PowerPointu. K tomu může dojít, protože PowerPoint může ignorovat data kerningu pro určitá písma, i když písmo obsahuje platné informace o kerningu a kerning je v nastavení PowerPointu povolen.

Pro dosažení výsledku blíže k PowerPointu můžete v takových případech zakázat kerning pro části textu, které používají dotčené písmo. Nastavte [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kerningminimalsize/) na hodnotu vyšší než skutečná velikost písma. Tento příklad vyžaduje soubor "presentation.pptx" s textovým polem jako prvním tvarem na první snímku. Kontroluje efektivní názvy písem, včetně zděděných, a nastavuje práh 100 bodů pro části, které používají Roboto. Tím se zakáže kerning pro odpovídající části s velikostí písma pod 100 bodů:

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

Pro text pod prahovou hodnotou toto nastavení zabraňuje kerningu a může pomoci sladit vykreslování Aspose.Slides s vizuálním výstupem PowerPointu u písem, která jsou tímto chováním PowerPointu ovlivněna.

## **Spravovat vlastnosti písma textu**

Vlastnosti písma lze nastavit na úrovni odstavce pomocí [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) nebo na jednotlivých částech pomocí [IPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/).

Následující příklad nastaví výchozí písmo prvního odstavce na 12‑bodové Times New Roman s tučným, kurzívním a tečkovaným podtržením. Výslovné formátování na jednotlivých částech má přednost před těmito výchozími nastaveními:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Nastavte vlastnosti písma pro odstavec.
var portionFormat = paragraph.ParagraphFormat.DefaultPortionFormat;
portionFormat.FontHeight = 12;
portionFormat.FontBold = NullableBool.True;
portionFormat.FontItalic = NullableBool.True;
portionFormat.FontUnderline = TextUnderlineType.Dotted;
portionFormat.LatinFont = new FontData("Times New Roman");

presentation.Save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
```

Výsledek:

![Vlastnosti písma pro odstavec](font_properties_for_paragraph.png)

Následující příklad aplikuje 13‑bodové Times New Roman, kurzíva a tečkované podtržení na části, jejichž efektivní formátování je tučné:

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
        // Nastavte vlastnosti písma pro část textu.
        portion.PortionFormat.FontHeight = 13;
        portion.PortionFormat.FontItalic = NullableBool.True;
        portion.PortionFormat.FontUnderline = TextUnderlineType.Dotted;
        portion.PortionFormat.LatinFont = new FontData("Times New Roman");
    }
}

presentation.Save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
```

Výsledek:

![Vlastnosti písma pro textové části](font_properties_for_text_portions.png)

## **Nastavit otočení textu**

Použijte [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/textverticaltype/) k nastavení předdefinované orientace textu uvnitř tvaru.

Následující ukázkový kód nastaví orientaci textu ve tvaru na [TextVerticalType.Vertical270](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/), což otáčí text **o 90 stupňů proti směru hodinových ručiček**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

presentation.Save("text_rotation.pptx", SaveFormat.Pptx);
```

Výsledek:

![Otočení textu](text_rotation.png)

## **Nastavit vlastní otočení pro textové rámečky**

Použijte [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/rotationangle/) k nastavení vlastního úhlu otočení pro [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/).

Ukázkový kód níže otáčí textový rámec o 3 stupně po směru hodinových ručiček uvnitř tvaru:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
```

Výsledek:

![Vlastní otočení textu](custom_text_rotation.png)

## **Nastavit řádkování odstavců**

Aspose.Slides poskytuje [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/) a [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) k řízení mezery odstavců. Tyto vlastnosti se používají následovně:

* Použijte kladnou hodnotu pro specifikaci řádkování jako procenta výšky řádku.  
* Použijte zápornou hodnotu pro specifikaci řádkování v bodech.

Následující příklad nastaví mezeru uvnitř prvního odstavce na 200 % výšky řádku (dvojité řádkování):

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

Výsledek:

![Řádkování v odstavci](line_spacing.png)

## **Řídit zalamování řádků**

Pravidla zalamování řádků odstavce jsou užitečná v úzkých textových blocích a v prezentacích, které kombinují latinský a východoasijský text. Následující vlastnosti patří do [IParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/), takže se vztahují na celý odstavec:

- [LatinLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/latinlinebreak/) řídí pravidla zalamování latinských řádků. V smíšeném textu jeho změna může také změnit, kde se zalamuje sousední východoasijský text a interpunkce.  
- [EastAsianLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/eastasianlinebreak/) řídí pravidla zalamování východoasijských řádků, včetně omezení na znaky na začátku a konci řádku.

Tato pravidla nenahrazují [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/), který umožňuje automatické zalamování v rámci textového rámce. Pravidla ovlivňují rozložení, když k zalamování dochází; nevkládají znaky pro zalomení řádku. Výslovné zalomení řádku vynutí nový řádek v odstavci nezávisle na dostupné šířce.

Následující samostatný příklad vytvoří úzký textový blok obsahující čínštinu a latinku. Explicitně nastaví obě vlastnosti zalamování a uloží soubor "line_breaking.pptx". Pro experimentování s libovolným pravidlem změňte hodnotu dané vlastnosti při zachování ostatních nastavení. Příklad používá 24‑bodové Arial a SimSun, šířku rámce 160 bodů a nulové vodorovné okraje textového rámce. [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) je nastaven na [TextAutofitType.None](https://reference.aspose.com/slides/net/aspose.slides/textautofittype/), aby velikost textu a rozměry rámce zůstaly pevné.

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

## **Řídit závěsné interpunkční znaménka**

[IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/hangingpunctuation/) umožňuje oprávněné interpunkční znaménko přesáhnout pravý okraj řádku textu místo toho, aby obsadilo následující řádek. Používá se na celý odstavec a liší se od vkládání závěsného odsazení.

Následující samostatný příklad povolí závěsnou interpunkci v 100‑bodovém širokém textovém rámci a uloží soubor "hanging_punctuation.pptx". Při použití 24‑bodového Arial a nulových vodorovných okrajů textového rámce zůstane koncová tečka za slovem „sentence“ a přesáhne pravý okraj textu. Nastavte vlastnost na [NullableBool.False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) pro srovnání: s těmito nastaveními tečka obsadí samostatný řádek. Zalamování je povoleno a automatické přizpůsobení zakázáno, aby byla dostupná šířka pevná.

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

Ne každé interpunkční znaménko může viset. [Podmínky písma a rozvržení popsané výše](#control-line-breaking) se také vztahují na toto srovnání: změna písma, dostupné šířky, okrajů nebo nastavení automatického přizpůsobení může viditelný rozdíl odstranit.

## **Nastavit typ automatického přizpůsobení pro textové rámečky**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) určuje, jak se text chová, když přesáhne hranice svého kontejneru. Použijte jej k řízení, zda se text zmenší, přeteče, nebo automaticky upraví velikost tvaru. Následující příklad konfiguruje tvar tak, aby se změnil rozměr a přizpůsobil se textu, a uloží výsledek do souboru "autofit_type.pptx".

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

Pro spočítání řádků po automatickém zalamování a zjištění, jak změna šířky textu nebo tvaru ovlivní výsledek, viz [Počítání vykreslených řádků](/slides/cs/net/manage-paragraph/). Pouze počet řádků neukazuje, zda text přesahuje svůj kontejner.

## **Nastavit ukotvení textových rámců**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/) definuje, jak je text vertikálně umístěn uvnitř tvaru, například nahoře, uprostřed nebo dole. Následující příklad ukotví text ke dnu prvního tvaru a uloží výsledek do souboru "text_anchor.pptx".

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
```

## **Nastavit tabulaci textu**

Použijte [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaulttabsize/) a [IParagraphFormat.Tabs](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/tabs/) k nastavení tabulátorů v odstavci. Následující příklad nastaví výchozí interval tabulátoru na 100 bodů a přidá levý zarovnaný tabulátor na 30 bodů. Tato nastavení ovlivňují text obsahující znak tabulátoru.

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

Výsledek:

![Tabulátory odstavce](paragraph_tabs.png)

## **Nastavit jazyk kontroly pravopisu**

Aspose.Slides poskytuje [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/), který umožňuje nastavit jazyk kontroly pravopisu pro část textu. Jazyk kontroly pravopisu určuje jazyk používaný pro kontrolu pravopisu a gramatiky v PowerPointu.

Následující příklad vyžaduje soubor "presentation.pptx" s textovým polem jako prvním tvarem na první snímku a alespoň jedním odstavcem. Nahradí obsah prvního odstavce řetězcem "1。", nastaví SimSun jako písmo a přiřadí zjednodušenou čínštinu jako jazyk kontroly pravopisu (`zh-CN`). Výsledek uloží do souboru "proofing_language.pptx":

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

// Nastavte jazyk kontroly pravopisu na zjednodušenou čínštinu.
textPortion.PortionFormat.LanguageId = "zh-CN";

textPortion.Text = "1。";
paragraph.Portions.Add(textPortion);

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

## **Nastavit výchozí jazyk**

Použijte [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaulttextlanguage/) k definování výchozího jazyka pro text vytvořený při načítání nebo vytváření prezentace. Následující příklad vytvoří prezentaci s americkou angličtinou jako výchozím jazykem textu, přidá textové pole a vytiskne `en-US` pro jeho první část textu.

```cs
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];

// Přidejte nový obdélníkový tvar s textem.
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
shape.TextFrame.Text = "Sample text";

// Zkontrolujte jazyk první části textu.
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine(portion.PortionFormat.LanguageId);
```

## **Nastavit výchozí textový styl**

Pro aplikaci výchozího formátování textu na úrovni prezentace použijte [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/defaulttextstyle/).

Následující příklad nastaví 14‑bodové tučné písmo jako výchozí pro odstavce nejvyšší úrovně v nové prezentaci a uloží ji do souboru "default_text_style.pptx". Text může tyto výchozí hodnoty zdědit, pokud není přepsán konkrétnějším formátováním.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
// Získat formát odstavce nejvyšší úrovně.
var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

if (paragraphFormat != null)
{
    paragraphFormat.DefaultPortionFormat.FontHeight = 14;
    paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
}

presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
```

## **Extrahovat text s efektem Všech Velkých Písmen**

V PowerPointu aplikace efektu **All Caps** na písmo způsobí, že se text na snímku zobrazuje velkými písmeny, i když byl původně zadán malými. Když takovou část textu získáte pomocí Aspose.Slides, knihovna vrátí text přesně tak, jak byl zadán. Pro shodu se zobrazovaným textem zkontrolujte [TextCapType](https://reference.aspose.com/slides/net/aspose.slides/textcaptype/) a převádějte vrácený řetězec na velká písmena, pokud je hodnota `All`.

Tento příklad vyžaduje soubor "sample2.pptx" s textovým polem jako prvním tvarem na první snímku. První část prvního odstavce obsahuje "Hello, Aspose!" s aplikovaným efektem All Caps, jak je zobrazeno níže.

![Efekt Všech Velkých Písmen](all_caps_effect.png)

Ukázkový kód níže ukazuje, jak extrahovat text s aplikovaným **efektem All Caps**:

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

Výstup:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **Často kladené otázky**

**Jak upravit text v tabulce na snímku?**

Pro úpravu textu v tabulce na snímku použijte [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/). Procházejte buňky a aktualizujte každou buňku pomocí [ICell.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) a formátování odstavců pomocí [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/paragraphformat/).

**Jak aplikovat gradientní barvu na text ve snímku PowerPoint?**

Pro aplikaci gradientní barvy na text použijte [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/). Nastavte [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) na [FillType.Gradient](https://reference.aspose.com/slides/net/aspose.slides/filltype/) a nakonfigurujte gradientní zastávky, směr a průhlednost.