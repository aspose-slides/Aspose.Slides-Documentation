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
- mezera mezi znaky
- vlastnosti písma
- rodina písma
- rotace textu
- úhel rotace
- textový rám
- řádkování
- vlastnost automatického přizpůsobení
- ukotvení textového rámu
- tabulace textu
- výchozí jazyk
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Formátovat a stylovat text v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro .NET. Přizpůsobte písma, barvy, zarovnání a další."
---
## **Přehled**

Tento článek ukazuje, jak formátovat text v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro .NET. Pokrývá barvy pozadí, průhlednost, mezery mezi znaky, vlastnosti písma, rotaci, mezery odstavců, chování automatického přizpůsobení, ukotvení textu, tabulátory a nastavení jazyka.

Pokud není uvedeno jinak, příklady používají [sample.pptx](sample.pptx). Prvním tvarem na první snímku je textové pole a jeho první odstavec obsahuje text zobrazený níže. Indexy snímků i tvarů jsou nulové. Příklady, které vybírají tučné části, používají efektivní formátování, včetně zděděného tučného formátování:

![Ukázkový text](sample_text.png)

Chcete-li najít a zvýraznit doslovný text nebo shody regulárního výrazu, podívejte se na [Vyhledávání a nahrazování textu](/slides/cs/net/search-and-replace-text/).

## **Nastavení barvy pozadí textu**

Použijte [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) k nastavení výchozí barvy zvýraznění odstavce nebo použijte [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/highlightcolor/) pro jednotlivé textové části.

Následující příklad nastaví světle šedé zvýraznění jako výchozí pro první odstavec. Výslovné barvy zvýraznění u jednotlivých částí mají přednost před tímto výchozím nastavením:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Nastavte barvu zvýraznění pro celý odstavec.
presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
```

Výsledek:

![Šedý odstavec](gray_paragraph.png)

Následující ukázkový kód demonstruje, jak nastavit barvu pozadí pro **textové části s tučným písmem**:

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
        // Nastavte barvu zvýraznění pro textovou část.
        portion.PortionFormat.HighlightColor.Color = Color.LightGray;
    }
}

presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
```

Výsledek:

![Šedé textové části](gray_text_portions.png)

## **Zarovnání odstavců textu**

Použijte [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) k nastavení zarovnání odstavce v textovém rámci. Hodnota může být centrovaná, zarovnaná vlevo, vpravo, do bloku a podobně.

Následující ukázkový kód ukazuje, jak zarovnat odstavec do **středu**:

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

## **Zarovnání písem v řádku**

Použijte [IParagraphFormat.FontAlignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/fontalignment/) k vertikálnímu zarovnání textových částí s různou velikostí písma v řádku. Toto nastavení se vztahuje na celý odstavec a ovlivňuje zarovnání v každém řádku.

Následující samostatný příklad vytvoří čtyři označená textová pole na jednom snímku. Každý odstavec obsahuje stejný text ve velikostech 18, 36 a 54 bodů s odlišným zarovnáním písma. Používá Arial, vypíná automatické přizpůsobení a zalamování a udržuje textové rámce dostatečně velké pro jeden řádek.

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

Zarovnání písma používá fontové metriky, takže viditelné okraje jednotlivých znaků se nemusí přesně shodovat. Příklad zahrnuje jak velké písmeno, tak dolní kotvu, aby ukázal rozdíl mezi zarovnáním k základní lince a k dolnímu okraji. Dostupnost a náhrada fontů, použité znaky a rozdíly ve velikostech písma ovlivňují výsledek. Rozměry rámu, okraje, řádkování, zalamování a automatické přizpůsobení také ovlivňují rozvržení; při porovnávání režimů používejte stejné fonty a nastavení rozvržení.

Toto nastavení se liší od [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/), který řídí horizontální zarovnání odstavce, a od [ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/), který umísťuje textový blok vertikálně uvnitř tvaru. Formátování horního a dolního indexu pomocí [IBasePortionFormat.Escapement](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/escapement/) posouvá jednotlivé části vzhledem k základní lince místo nastavení zarovnání písma pro řádky odstavce.

## **Nastavení průhlednosti textu**

Průhlednost textu je řízena alfa komponentou barvy přiřazené k [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/). V níže uvedených příkladech je `alpha = 50` hodnota alfa kanálu ARGB v rozsahu 0–255, nikoli procento průhlednosti.

Následující ukázkový kód ukazuje, jak aplikovat průhlednost na **celý odstavec**:

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

Následující ukázkový kód ukazuje, jak aplikovat průhlednost na **textové části s tučným písmem**:

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
        // Nastavte průhlednost textové části.
        portion.PortionFormat.FillFormat.FillType = FillType.Solid;
        portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);
    }
}

presentation.Save("transparent_text_portions.pptx", SaveFormat.Pptx);
```

Výsledek:

![Průhledné textové části](transparent_text_portions.png)

## **Nastavení mezery mezi znaky v textu**

Použijte [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/spacing/) k rozšíření nebo zmenšení mezery mezi znaky v textovém poli. Příklady přidávají 3 body mezery; záporné hodnoty zmenšují text.

Následující kód C# ukazuje, jak rozšířit mezeru mezi znaky v **celém odstavci**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Poznámka: Použijte záporné hodnoty ke zmenšení mezery mezi znaky.
paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // Rozšířit mezeru mezi znaky.

presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
```

Výsledek:

![Mezera mezi znaky v odstavci](character_spacing_in_paragraph.png)

Následující ukázkový kód ukazuje, jak rozšířit mezeru mezi znaky v **textových částech s tučným písmem**:

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
        // Poznámka: Použijte záporné hodnoty ke zmenšení mezery mezi znaky.
        portion.PortionFormat.Spacing = 3;  // Rozšířit mezeru mezi znaky.
    }
}

presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
```

Výsledek:

![Mezera mezi znaky v textových částech](character_spacing_in_text_portions.png)

### **Zakázat kerning pro konkrétní fonty**

V některých případech může text vykreslený pomocí Aspose.Slides vypadat mírně těsněji než stejný text zobrazený v PowerPointu. K tomu může dojít, protože PowerPoint může ignorovat data kerningu pro určité fonty, i když font obsahuje platné informace o kerningu a kerning je v nastavení PowerPointu povolen.

Aby byl výstup při takových případech blíže PowerPointu, můžete zakázat kerning pro textové části, které používají dotčený font. Nastavte [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kerningminimalsize/) na hodnotu větší než skutečná velikost písma. Tento příklad vyžaduje soubor "presentation.pptx" s textovým polem jako prvním tvarem na prvním snímku. Kontroluje efektivní názvy fontů, včetně zděděných, a nastavuje práh 100 bodů pro části používající Roboto. Tím se zakáže kerning pro odpovídající části s velikostí písma pod 100 bodů:

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

Pro text pod prahem toto nastavení zabraňuje kerningu a může pomoci sladit vykreslování Aspose.Slides s vizuálním výstupem PowerPointu u fontů ovlivněných tímto specifickým chováním PowerPointu.

## **Správa vlastností písma textu**

Vlastnosti písma lze nastavit na úrovni odstavce pomocí [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) nebo na jednotlivých částech pomocí [IPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/).

Následující příklad nastaví výchozí písmo prvního odstavce na 12 bodů Times New Roman s tučným, kurzívovým a tečkovaným podtržením. Výslovné formátování jednotlivých částí má přednost před těmito výchozími nastaveními:

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

Následující příklad aplikuje 13 bodů Times New Roman, kurzívu a tečkované podtržení na části, jejichž efektivní formátování je tučné:

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
        // Nastavte vlastnosti písma pro textovou část.
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

## **Řízení normalizace výšky textu**

Použijte [IBasePortionFormat.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/normaliseheight/) při reprodukci typografie šablony nebo zkoumání rozdílů ve výšce znaků. V PowerPointu povolení normalizace roztahuje nebo zmenší jednotlivé znaky vertikálně tak, aby měly jednotnou viditelnou výšku v textové části. Není zaručeno, že výšky textu budou stejné napříč různými fonty.

Nastavte vlastnost na [NullableBool.True or False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) k explicitnímu povolení nebo zakázání normalizace. `NullableBool.NotDefined` ponechává místní nastavení nevyplněné, takže část dědí hodnotu, například z [DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) odstavce. To neznamená `False`. Použijte [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) a přečtěte [IBasePortionFormatEffectiveData.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformateffectivedata/normaliseheight/) k získání vyřešené boolean hodnoty.

Následující samostatný příklad vyžaduje nainstalovaný **Arial**. Vytvoří dva textové bloky obsahující stejná velká písmena, malá písmena, podřezové a diakritické znaky ve velikosti 54 bodů. Oba odstavce mají výchozí povolenou normalizaci. Horní část ji explicitně zakazuje; spodní část ji dědí. Rozměry rámu, okraje a mezery odstavců jsou identické, s vypnutým zalamováním a automatickým přizpůsobením, aby byl srovnávací test konzistentní. Příklad vypíše `False: False` a `NotDefined: True` a následně uloží "text_height_normalization.pptx".

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

Porovnání níže bylo exportováno ze uložené prezentace. Horní řada má normalizaci vypnutou (`False`); spodní řada dědí povolené nastavení (`NotDefined` → `True`). Pro reprodukci vzhledu mějte nainstalovaný Arial.

![Text Arial 54 bodů s vypnutou normalizací nahoře a zděděnou normalizací zapnutou dole](text_height_normalization.png)

Normalizace mění výšku znaků, aniž by změnila přiřazenou [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/) hodnotu, která určuje velikost písma v bodech. Odstavec [SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) řídí řádkování, zatímco textový rám [AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) ovlivňuje, jak se text nebo jeho kontejner přizpůsobí pro umístění. Tato nastavení mají různé účely a mohou nezávisle ovlivnit celkové rozložení. Další informace o formátování odstavců a dědičnosti najdete v [Manage Paragraph](/slides/cs/net/manage-paragraph/).

## **Použití a odstranění přeškrtnutí**

Použijte [IBasePortionFormat.StrikethroughType](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/strikethroughtype/) na textovou část k zobrazení oprav, zrušených výrazů nebo předchozích cen, aniž byste smazali původní text. Nastavte ji na [TextStrikethroughType.Single or Double](https://reference.aspose.com/slides/net/aspose.slides/textstrikethroughtype/) pro jednu nebo dvě čáry přes text.

Pro odstranění přeškrtnutí přiřaďte `TextStrikethroughType.None`. Tím se efekt explicitně zakáže, i když okolní formátování specifikuje přeškrtnutí. Naopak `TextStrikethroughType.NotDefined` ponechává místní nastavení nedefinované, což umožňuje, aby část zdědila formátování, například z odstavce. Není zaručeno, že přeškrtnutí bude odstraněno. Použijte [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) k přečtení výsledného formátování, včetně zděděných hodnot.

Následující samostatný příklad vytvoří tři srovnání cen. Každý odstavec má samostatné části pro popisek, předchozí cenu a aktuální cenu, takže pouze předchozí cena je ovlivněna. První řada aplikuje a poté odstraní přeškrtnutí; ostatní řady zachovávají jednoduché a dvojité přeškrtnutí. Změna této vlastnosti zachovává text a jeho další formátování, včetně tučné předchozí ceny.

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

// Použijte přeškrtnutí, pak jej explicitně odstraňte z první předchozí ceny.
paragraphs[0].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Single;
paragraphs[0].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.None;

paragraphs[1].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Single;
paragraphs[2].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Double;

presentation.Save("strikethrough.pptx", SaveFormat.Pptx);
```

Výsledek, shora dolů: žádné přeškrtnutí, jednoduché přeškrtnutí a dvojité přeškrtnutí.

![Předchozí ceny bez přeškrtnutí, s jednoduchým a s dvojitým přeškrtnutím](strikethrough.png)

## **Nastavení rotace textu**

Použijte [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/textverticaltype/) k nastavení předdefinované orientace textu uvnitř tvaru.

Následující ukázkový kód nastaví orientaci textu v tvaru na [TextVerticalType.Vertical270](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/), což otáčí text **o 90 stupňů proti směru hodinových ručiček**:

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

![Rotace textu](text_rotation.png)

## **Zobrazit číslice vedle sebe ve svislém textu**

Aby se dvouciferné číslo udrželo pohromadě ve svislém japonském popisku, vložte obě číslice do jedné textové části a nastavte [IBasePortionFormat.Kumimoji](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kumimoji/) na tuto část. Příklad používá [TextVerticalType.EastAsianVertical](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/) a 40 bodů MS Gothic pro oba popisky. Pouze hodnota [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) přiřazená číselné části se liší.

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

V PowerPointu levý popisek (`True`) zobrazuje číslice svisle a vedle sebe mezi 和 a 年. V pravém popisku (`False`) je dvojice otočena o 90 stupňů po směru hodinových ručiček. Okolní japonské znaky zůstávají svislé v obou popiscích.

![Porovnání svislých datumových popisků v PowerPointu s svislými číslicemi vlevo a otočenými číslicemi vpravo.](vertical_date.png)

## **Nastavení vlastní rotace pro textové rámy**

Použijte [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/rotationangle/) k nastavení vlastní úhlu rotace pro [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/).

Následující ukázkový kód otočí textový rám o 3 stupně po směru hodinových ručiček uvnitř tvaru:

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

![Vlastní rotace textu](custom_text_rotation.png)

## **Nastavení řádkování odstavců**

Aspose.Slides poskytuje [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/) a [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) k řízení mezer odstavců. Tyto vlastnosti se používají následovně:

* Použijte kladnou hodnotu k určení řádkování jako procenta výšky řádku.
* Použijte zápornou hodnotu k určení řádkování v bodech.

Následující příklad nastaví mezeru v prvním odstavci na 200 % výšky řádku (dvojité řádkování):

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

## **Řízení zalamování řádků**

Pravidla zalamování řádků v odstavcích jsou užitečná v úzkých textových blocích a prezentacích, které kombinují latinský a východoasijský text. Následující vlastnosti patří do [IParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/), takže se vztahují na celý odstavec:

- [LatinLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/latinlinebreak/) řídí pravidla zalamování latinského textu. V smíšeném textu jeho změna může také změnit, kde se zalamují sousední východoasijské znaky a interpunkce.
- [EastAsianLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/eastasianlinebreak/) řídí pravidla zalamování východoasijského textu, včetně omezení znaků na začátku a konci řádku.

Tato pravidla nenahrazují [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/), které umožňuje automatické zalamování v textovém rámci. Ovlivňují rozvržení při zalamování, nevkládají však znaky nového řádku. Explicitní zalomení řádku vynutí nový řádek v odstavci nezávisle na dostupné šířce.

Následující samostatný příklad vytvoří úzký textový blok obsahující čínský a latinský text. Explicitně nastaví obě vlastnosti zalamování řádků a uloží "line_breaking.pptx". Pro experimentování s některým pravidlem změňte hodnotu dané vlastnosti při zachování ostatních nastavení. Příklad používá 24 bodů Arial a SimSun s šířkou rámu 160 bodů a nulovými horizontálními okraji textového rámu. [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) je nastaven na [TextAutofitType.None](https://reference.aspose.com/slides/net/aspose.slides/textautofittype/) aby velikost textu a rozměry rámu zůstaly pevné.

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

## **Řízení zavěšené interpunkce**

[IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/hangingpunctuation/) umožňuje oprávněné interpunkční znaky přesáhnout pravý okraj řádku textu místo aby zaujaly další řádek. Používá se pro celý odstavec a liší se od zavěšeného odsazení.

Následující samostatný příklad povoluje zavěšenou interpunkci v 100 bodům širokém textovém rámci a uloží "hanging_punctuation.pptx". S 24 body Arial a nulovými horizontálními okraji textového rámu zůstane poslední tečka za slovem "sentence" a přesáhne pravý okraj textu. Nastavte vlastnost na [NullableBool.False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) pro porovnání: s tímto nastavením tečka zabírá samostatný řádek. Zalamování je povoleno a automatické přizpůsobení je vypnuto, aby šířka zůstala pevná.

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

Ne každá interpunkční značka může být zavěšena. [Podmínky fontu a rozvržení popsané výše](#control-line-breaking) se také vztahují na toto srovnání: změna fontu, dostupné šířky, okrajů nebo nastavení automatického přizpůsobení může viditelný rozdíl odstranit.

## **Nastavení typu automatického přizpůsobení pro textové rámy**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) určuje, jak se text chová, když přesáhne hranice svého kontejneru. Použijte jej k řízení, zda se text zmenší, přeteče, nebo se tvar automaticky přizpůsobí. Následující příklad konfiguruje tvar tak, aby se přizpůsobil textu, a uloží výsledek do "autofit_type.pptx".

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

Pro spočítání řádků po automatickém zalamování a sledování, jak se mění šířka textu nebo tvaru, viz [Count Rendered Lines](/slides/cs/net/manage-paragraph/). Pouhý počet řádků neudává, zda text přesahuje svůj kontejner.

## **Nastavení ukotvení textových rámů**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/) určuje, jak je text vertikálně umístěn uvnitř tvaru, např. nahoře, uprostřed nebo dole. Následující příklad ukotví text ke dnu prvního tvaru a uloží výsledek do "text_anchor.pptx".

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
```

## **Nastavení tabulátorů textu**

Použijte [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaulttabsize/) a [IParagraphFormat.Tabs](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/tabs/) k nakonfigurování tabulátorů v odstavci. Následující příklad nastaví výchozí interval tabulátoru na 100 bodů a přidá levý tabulátor na 30 bodů. Tato nastavení ovlivňují text obsahující znak tabulátoru.

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

## **Nastavení jazykové kontroly**

Aspose.Slides poskytuje [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/), který umožňuje nastavit jazyk pro jazykovou kontrolu textové části. Jazyk pro jazykovou kontrolu určuje jazyk používaný pro kontrolu pravopisu a gramatiky v PowerPointu.

Následující příklad vyžaduje "presentation.pptx" s textovým polem jako prvním tvarem na první snímku a alespoň jedním odstavcem. Nahrazuje obsah prvního odstavce textem "1。", nastaví SimSun jako písmo a přiřadí jazyk jazykové kontroly pro zjednodušenou čínštinu (`zh-CN`). Výsledek uloží do "proofing_language.pptx":

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

// Nastavte jazyk pro jazykovou kontrolu na zjednodušenou čínštinu.
textPortion.PortionFormat.LanguageId = "zh-CN";

textPortion.Text = "1。";
paragraph.Portions.Add(textPortion);

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

### **Kopírování jazykových metadat**

Při kopírování vícejazyčného textu ze šablony zachovejte jak [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/), tak [IBasePortionFormat.AlternativeLanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/alternativelanguageid/). Následující samostatný příklad vytvoří zdrojovou část s US English jako jazykem a francouzštinou jako alternativním jazykem a zkopíruje text a identifikátory do části v nové prezentaci.

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
// Pokud zdroj nemá alternativní jazyk, null vymaže hodnotu v cíli.
destination.PortionFormat.AlternativeLanguageId = source.PortionFormat.AlternativeLanguageId;
paragraph.Portions.Add(destination);

presentation.Save("copied_language_metadata.pptx", SaveFormat.Pptx);
```

Pro vyzkoušení zdroje bez alternativního jazyka vynechte přiřazení "fr-FR". Alternativní identifikátor bude poté `null` a stejný příkaz pro kopírování zachová jeho nepřítomnost, aniž by zaváděl výchozí hodnotu, i když cíl dříve měl alternativní jazyk nastaven. Tyto identifikátory jsou uloženy jako jazyková metadata. Jejich zachování neurčuje, který slovník PowerPoint použije pro kontrolu pravopisu nebo gramatiky.

## **Nastavení výchozího jazyka**

Použijte [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaulttextlanguage/) k definování výchozího jazyka pro text vytvořený při načítání nebo vytváření prezentace. Následující příklad vytvoří prezentaci s US English jako výchozím jazykem textu, přidá textové pole a vytiskne `en-US` pro jeho první textovou část.

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

// Zkontrolujte jazyk první části.
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine(portion.PortionFormat.LanguageId);
```

## **Nastavení výchozího stylu textu**

Pro aplikaci výchozího formátování textu na úrovni prezentace použijte [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/defaulttextstyle/).

Následující příklad nastaví 14 bodové tučné písmo jako výchozí pro odstavce nejvyšší úrovně v nové prezentaci a uloží ji do "default_text_style.pptx". Text může tyto výchozí hodnoty zdědit, pokud nebudou přepsány specifičtějším formátováním.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
// Získá formát odstavce nejvyšší úrovně.
var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

if (paragraphFormat != null)
{
    paragraphFormat.DefaultPortionFormat.FontHeight = 14;
    paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
}

presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
```

## **Extrahování textu s efektem VELKÁ PÍSMENA**

V PowerPointu aplikace efekt **All Caps** (všechna písmena velká) způsobí, že se text na snímku zobrazuje velkými písmeny, i když byl původně zadán malými. Když takovou textovou část získáte s Aspose.Slides, knihovna vrátí text přesně tak, jak byl zadán. Pro sladění se zobrazeným textem zkontrolujte [TextCapType](https://reference.aspose.com/slides/net/aspose.slides/textcaptype/) a převěďte vrácený řetězec na velká písmena, když je hodnota `All`.

Tento příklad vyžaduje "sample2.pptx" s textovým polem jako prvním tvarem na první snímku. První část prvního odstavce obsahuje "Hello, Aspose!" s aplikovaným efektem All Caps, jak je zobrazeno níže.

![Efekt All Caps](all_caps_effect.png)

Následující ukázkový kód ukazuje, jak extrahovat text s aplikovaným efektem **All Caps**:

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

Chcete-li upravit text v tabulce na snímku, použijte [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/). Procházejte buňky a aktualizujte každou buňku pomocí [ICell.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) a formátování odstavců pomocí [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/paragraphformat/).

**Jak použít gradientovou barvu na text na snímku PowerPointu?**

Chcete-li aplikovat gradientovou barvu na text, použijte [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/). Nastavte [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) na [FillType.Gradient](https://reference.aspose.com/slides/net/aspose.slides/filltype/) a nakonfigurujte gradientové kroky, směr a průhlednost.

[Formátování textu v prezentacích](/slides/cs/features/text-formatting/)