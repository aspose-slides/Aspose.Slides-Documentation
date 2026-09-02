---
title: Formátování textu prezentace v .NET
linktitle: Formátování textu
type: docs
weight: 50
url: /cs/net/text-formatting/
keywords:
- zarovnání odstavce
- styl textu
- pozadí textu
- průhlednost textu
- rozestup znaků
- vlastnosti fontu
- rodina fontů
- otočení textu
- úhel otočení
- textový rámec
- řádkování
- vlastnost automatického přizpůsobení
- ukotvení textového rámce
- tabulace textu
- výchozí jazyk
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Formátujte a stylujte text v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro .NET. Přizpůsobte fonty, barvy, zarovnání a další."
---
## **Přehled**

Tento článek ukazuje, jak formátovat text v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro .NET. Pokrývá barvy pozadí, průhlednost, rozestup znaků, vlastnosti fontu, otočení, mezery odstavců, chování automatického přizpůsobení, ukotvení textu, tabulátory a nastavení jazyka.

V níže uvedených příkladech použijeme soubor s názvem „sample.pptx“, který obsahuje jediný textový rámec na první snímku s následujícím textem:

![Ukázkový text](sample_text.png)

Pro vyhledání a zvýraznění doslovného textu nebo shod regulárních výrazů viz [Vyhledat a nahradit text](/slides/cs/net/search-and-replace-text/).

## **Nastavení barvy pozadí textu**

Použijte [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/defaultportionformat/) k nastavení výchozí barvy zvýraznění pro odstavec nebo použijte [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/cs/net/aspose.slides/ibaseportionformat/highlightcolor/) pro jednotlivé části textu.

Následující ukázkový kód ukazuje, jak nastavit barvu pozadí pro **celý odstavec**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Nastavte barvu zvýraznění pro celý odstavec.
    paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

    presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
}
```

Výsledek:

![Šedý odstavec](gray_paragraph.png)

Níže uvedený kód ukazuje, jak nastavit barvu pozadí pro **části textu s tučným písmem**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
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
}
```

Výsledek:

![Šedé části textu](gray_text_portions.png)

## **Zarovnání odstavců textu**

Použijte [IParagraphFormat.Alignment](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/alignment/) k nastavení zarovnání odstavce v textovém rámečku. Hodnota může být centrovaná, zarovnaná vlevo, vpravo, zarovnaná do bloku a podobně.

Následující ukázkový kód ukazuje, jak zarovnat odstavec na **střed**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Nastavte zarovnání odstavce na střed.
    paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

    presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
}
```

Výsledek:

![Zarovnaný odstavec](aligned_paragraph.png)

## **Nastavení průhlednosti textu**

Průhlednost textu se ovládá pomocí alfa komponenty barvy přiřazené k [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/ibaseportionformat/fillformat/). V níže uvedených příkladech `alpha = 50` představuje hodnotu alfa kanálu ARGB v rozsahu 0–255, nikoli procento průhlednosti.

Níže uvedený kód ukazuje, jak aplikovat průhlednost na **celý odstavec**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Nastavte výplňovou barvu textu na průhlednou barvu.
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

    presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
}
```

Výsledek:

![Průhledný odstavec](transparent_paragraph.png)

Následující ukázkový kód ukazuje, jak aplikovat průhlednost na **části textu s tučným písmem**:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
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
}
```

Výsledek:

![Průhledné části textu](transparent_text_portions.png)

## **Nastavení rozestupu znaků v textu**

Použijte [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/cs/net/aspose.slides/ibaseportionformat/spacing/) k rozšíření nebo zmenšení mezery mezi znaky v textovém rámečku.

Následující C# kód ukazuje, jak rozšířit rozestup znaků v **celém odstavci**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Poznámka: Použijte záporné hodnoty ke zmenšení rozestupu znaků.
    paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // Rozšířit rozestup znaků.

    presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
}
```

Výsledek:

![Rozestup znaků v odstavci](character_spacing_in_paragraph.png)

Níže uvedený kód ukazuje, jak rozšířit rozestup znaků v **částech textu s tučným písmem**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // Poznámka: Použijte záporné hodnoty ke zmenšení rozestupu znaků.
            portion.PortionFormat.Spacing = 3;  // Rozšířit rozestup znaků.
        }
    }

    presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
}
```

Výsledek:

![Rozestup znaků v částech textu](character_spacing_in_text_portions.png)

### **Zakázání kerningu pro konkrétní fonty**

V některých případech může text vykreslený pomocí Aspose.Slides vypadat mírně těsněji než stejný text zobrazený v PowerPointu. K tomu může dojít, protože PowerPoint může ignorovat data kerningu pro určité fonty, i když font obsahuje platné informace o kerningu a kerning je v nastavení PowerPointu povolen.

Aby výstup byl v takových případech bližší PowerPointu, můžete zakázat kerning pro části textu, které používají dotčený font. Nastavte [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/cs/net/aspose.slides/ibaseportionformat/kerningminimalsize/) na hodnotu výrazně vyšší než skutečná velikost fontu:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("presentation.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var targetFont = "Roboto";

    foreach (var paragraph in autoShape.TextFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            if ((portion.PortionFormat.LatinFont != null &&
                 portion.PortionFormat.LatinFont.FontName == targetFont) ||
                (portion.PortionFormat.EastAsianFont != null &&
                 portion.PortionFormat.EastAsianFont.FontName == targetFont) ||
                (portion.PortionFormat.ComplexScriptFont != null &&
                 portion.PortionFormat.ComplexScriptFont.FontName == targetFont))
            {
                portion.PortionFormat.KerningMinimalSize = 100;
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

Toto nastavení zabraňuje aplikaci kerningu na odpovídající části textu a může pomoci sladit vykreslování Aspose.Slides s vizuálním výstupem PowerPointu u fontů, které jsou tímto chováním ovlivněny.

## **Správa vlastností fontu textu**

Vlastnosti fontu lze nastavit na úrovni odstavce prostřednictvím [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/defaultportionformat/) nebo na úrovni jednotlivých částí pomocí [IPortionFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/iportionformat/).

Následující kód nastavuje font a styl textu pro celý odstavec: aplikuje velikost fontu, tučné, kurzíva, tečkované podtržení a font Times New Roman na všechny části odstavce.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Nastavte vlastnosti fontu pro odstavec.
    paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 12;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontItalic = NullableBool.True;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontUnderline = TextUnderlineType.Dotted;
    paragraph.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Times New Roman");

    presentation.Save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
}
```

Výsledek:

![Vlastnosti fontu pro odstavec](font_properties_for_paragraph.png)

Níže uvedený kód aplikuje podobné vlastnosti na **části textu s tučným písmem**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // Nastavte vlastnosti fontu pro část textu.
            portion.PortionFormat.FontHeight = 13;
            portion.PortionFormat.FontItalic = NullableBool.True;
            portion.PortionFormat.FontUnderline = TextUnderlineType.Dotted;
            portion.PortionFormat.LatinFont = new FontData("Times New Roman");
        }
    }

    presentation.Save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
}
```

Výsledek:

![Vlastnosti fontu pro části textu](font_properties_for_text_portions.png)

## **Nastavení otočení textu**

Použijte [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframeformat/textverticaltype/) k nastavení předdefinované orientace textu v tvaru.

Následující ukázkový kód nastavuje orientaci textu v tvaru na `Vertical270`, což otočí text **o 90 stupňů proti směru hodinových ručiček**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

    presentation.Save("text_rotation.pptx", SaveFormat.Pptx);
}
```

Výsledek:

![Otočení textu](text_rotation.png)

## **Nastavení vlastního otočení pro textové rámečky**

Použijte [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframeformat/rotationangle/) k nastavení vlastního úhlu otočení pro [ITextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/).

Níže uvedený kód otáčí textový rámeček o 3 stupně po směru hodinových ručiček v rámci tvaru:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

    presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
}
```

Výsledek:

![Vlastní otočení textu](custom_text_rotation.png)

## **Nastavení řádkování odstavců**

Aspose.Slides poskytuje [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/spacebefore/) a [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/spacewithin/) k řízení mezery odstavců. Tyto vlastnosti se používají následovně:

* Použijte kladnou hodnotu k určení řádkování jako procenta výšky řádku.
* Použijte zápornou hodnotu k určení řádkování v bodech.

Následující ukázkový kód ukazuje, jak specifikovat řádkování v odstavci:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    paragraph.ParagraphFormat.SpaceWithin = 200;

    presentation.Save("line_spacing.pptx", SaveFormat.Pptx);
}
```

Výsledek:

![Řádkování v odstavci](line_spacing.png)

## **Nastavení typu automatického přizpůsobení pro textové rámečky**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframeformat/autofittype/) určuje, jak se text chová, když přesáhne hranice svého kontejneru. Použijte jej k řízení, zda se text zmenšuje, přetéká nebo automaticky mění velikost tvaru.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
}
```

## **Nastavení ukotvení textových rámců**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframeformat/anchoringtype/) definuje, jak je text vertikálně umístěn uvnitř tvaru, například nahoře, uprostřed nebo dole.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

    presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
}
```

## **Nastavení tabulace textu**

Použijte [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/defaulttabsize/) a [IParagraphFormat.Tabs](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/tabs/) k nastavení tabulátorů v odstavci.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    paragraph.ParagraphFormat.DefaultTabSize = 100;
    paragraph.ParagraphFormat.Tabs.Add(30, TabAlignment.Left);

    presentation.Save("paragraph_tabs.pptx", SaveFormat.Pptx);
}
```

Výsledek:

![Tabulátory v odstavci](paragraph_tabs.png)

## **Nastavení jazyka kontroly pravopisu**

Aspose.Slides poskytuje [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/cs/net/aspose.slides/ibaseportionformat/languageid/), který umožňuje nastavit jazyk kontroly pravopisu pro část textu. Jazyk kontroly pravopisu určuje jazyk použitého pravopisu a gramatické kontroly v PowerPointu.

Následující ukázkový kód ukazuje, jak nastavit jazyk kontroly pravopisu pro část textu:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("presentation.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    var paragraph = autoShape.TextFrame.Paragraphs[0];
    paragraph.Portions.Clear();

    var font = new FontData("SimSun");

    var textPortion = new Portion();
    textPortion.PortionFormat.ComplexScriptFont = font;
    textPortion.PortionFormat.EastAsianFont = font;
    textPortion.PortionFormat.LatinFont = font;

    // Nastavte Id jazyka kontroly pravopisu.
    textPortion.PortionFormat.LanguageId = "zh-CN";

    textPortion.Text = "1。";
    paragraph.Portions.Add(textPortion);

    presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
}
```

## **Nastavení výchozího jazyka**

Použijte [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/cs/net/aspose.slides/loadoptions/defaulttextlanguage/) k definování výchozího jazyka pro text vytvářený při načítání nebo vytváření prezentace.

```cs
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using (var presentation = new Presentation(loadOptions))
{
    var slide = presentation.Slides[0];

    // Přidejte nový tvar obdélníku s textem.
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.TextFrame.Text = "Sample text";

    // Zkontrolujte jazyk první části.
    var portion = shape.TextFrame.Paragraphs[0].Portions[0];
    Console.WriteLine(portion.PortionFormat.LanguageId);
}
```

## **Nastavení výchozího stylu textu**

Pro aplikaci výchozího formátování textu na úrovni celé prezentace použijte [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentation/defaulttextstyle/).

Následující ukázkový kód ukazuje, jak nastavit výchozí tučný font s velikostí 14 pt pro veškerý text napříč snímky v nové prezentaci.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation())
{
    // Získat formát odstavce nejvyšší úrovně.
    var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

    if (paragraphFormat != null)
    {
        paragraphFormat.DefaultPortionFormat.FontHeight = 14;
        paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    }

    presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
}
```

## **Extrahování textu s efektem Všech Velkých Písmen**

V PowerPointu aplikace fontového efektu **All Caps** způsobí, že se text na snímku zobrazuje velkými písmeny, i když byl původně zadán malými. Při načtení takové části textu pomocí Aspose.Slides knihovna vrátí text přesně tak, jak byl zadán. Pro získání zobrazeného textu zkontrolujte [TextCapType](https://reference.aspose.com/slides/cs/net/aspose.slides/textcaptype/) a při hodnotě `All` převede vrácený řetězec na velká písmena.

Předpokládejme, že máme následující textový rámec na první snímku souboru sample2.pptx.

![Efekt Všech Velkých Písmen](all_caps_effect.png)

Níže uvedený kód ukazuje, jak extrahovat text s aplikovaným efektem **All Caps**:

```cs
using Aspose.Slides;

using (var presentation = new Presentation("sample2.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var textPortion = autoShape.TextFrame.Paragraphs[0].Portions[0];

    Console.WriteLine($"Original text: {textPortion.Text}");

    var textFormat = textPortion.PortionFormat.GetEffective();
    if (textFormat.TextCapType == TextCapType.All)
    {
        var text = textPortion.Text.ToUpper();
        Console.WriteLine($"All-Caps effect: {text}");
    }
}
```

Výstup:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **Často kladené otázky**

**Jak upravit text v tabulce na snímku?**

Pro úpravu textu v tabulce na snímku použijte [ITable](https://reference.aspose.com/slides/cs/net/aspose.slides/itable/). Procházejte buňky a aktualizujte každou buňku přes [ICell.TextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/icell/textframe/) a formátování odstavců přes [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraph/paragraphformat/).

**Jak aplikovat gradientní barvu na text v PowerPoint snímku?**

Pro aplikaci gradientní barvy na text použijte [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/ibaseportionformat/fillformat/). Nastavte [IFillFormat.FillType](https://reference.aspose.com/slides/cs/net/aspose.slides/ifillformat/filltype/) na [FillType.Gradient](https://reference.aspose.com/slides/cs/net/aspose.slides/filltype/) a nakonfigurujte gradientní body, směr a průhlednost.