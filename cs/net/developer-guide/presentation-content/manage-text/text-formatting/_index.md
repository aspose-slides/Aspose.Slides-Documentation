---
title: Formátování textu prezentace v .NET
linktitle: Formátování textu
type: docs
weight: 50
url: /cs/net/text-formatting/
keywords:
- zvýraznění textu
- regulární výraz
- zarovnání odstavce
- styl textu
- pozadí textu
- průhlednost textu
- mezera mezi znaky
- vlastnosti písma
- rodina písma
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
description: "Formátujte a stylujte text v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro .NET. Přizpůsobte písma, barvy, zarovnání a další."
---
## **Přehled**

Tento článek ukazuje, jak formátovat text v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro .NET. Pokrývá zvýraznění, barvy pozadí, průhlednost, mezery mezi znaky, vlastnosti písma, otočení, mezery odstavců, chování automatického přizpůsobení, ukotvení textu, tabulátory a nastavení jazyka.

V níže uvedených příkladech použijeme soubor s názvem **„sample.pptx“**, který obsahuje jediný textový rámeček na první snímku s následujícím textem:

![Ukázkový text](sample_text.png)

## **Zvýraznění textu**

Použijte metodu [ITextFrame.HighlightText](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/highlighttext/) , když potřebujete zvýraznit text, který odpovídá konkrétnímu vzorku v textovém rámci. Metoda aplikuje barvu zvýraznění na odpovídající fragmenty textu a lze ji použít spolu s [TextSearchOptions](https://reference.aspose.com/slides/cs/net/aspose.slides/textsearchoptions/) k řízení způsobu vyhledávání, například k vyhledání pouze celých slov.

Níže uvedený ukázkový kód zvýrazní všechny výskyty znaků **„try“** a poté zvýrazní pouze celé slovo **„to“**.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    // Získat první tvar z první snímku.
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];

    // Zvýraznit slovo "try" v tvaru.
    shape.TextFrame.HighlightText("try", Color.LightBlue);

    var searchOptions = new TextSearchOptions()
    {
        WholeWordsOnly = true
    };

    // Zvýraznit slovo "to" v tvaru.
    shape.TextFrame.HighlightText("to", Color.Violet, searchOptions, null);

    presentation.Save("highlighted_text.pptx", SaveFormat.Pptx);
}
```

Výsledek:

![Zvýrazněný text](highlighted_text.png)

## **Zvýraznění textu pomocí regulárních výrazů**

Metoda [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/highlightregex/) zvýrazní shody textu nalezené regulárním výrazem. V .NET je toto API k dispozici na rozhraní [ITextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/).

Níže uvedený ukázkový kód zvýrazní všechna slova, která obsahují **sedm nebo více znaků**:

```cs
using (var presentation = new Presentation(folderPath + "sample.pptx"))
{
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];

    var regex = new Regex(@"\b[^\s]{7,}\b");

    // Zvýraznit všechna slova, která mají sedm a více znaků.
    shape.TextFrame.HighlightRegex(regex, Color.Yellow, null);

    presentation.Save(folderPath + "highlighted_text_using_regex.pptx", SaveFormat.Pptx);
}
```

Výsledek:

![Zvýrazněný text pomocí regulárního výrazu](highlighted_text_using_regex.png)

## **Nastavení barvy pozadí textu**

Použijte [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/defaultportionformat/) k nastavení výchozí barvy zvýraznění pro odstavec nebo použijte [IPortionFormat.HighlightColor](https://reference.aspose.com/slides/cs/net/aspose.slides/iportionformat/highlightcolor/) pro jednotlivé textové úseky.

Níže uvedený ukázkový kód ukazuje, jak nastavit barvu pozadí pro **celý odstavec**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Nastavit barvu zvýraznění pro celý odstavec.
    paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

    presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
}
```

Výsledek:

![Šedý odstavec](gray_paragraph.png)

Níže uvedený ukázkový kód demonstruje, jak nastavit barvu pozadí pro **textové úseky s tučným písmem**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // Nastavit barvu zvýraznění pro textový úsek.
            portion.PortionFormat.HighlightColor.Color = Color.LightGray;
        }
    }

    presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
}
```

Výsledek:

![Šedé textové úseky](gray_text_portions.png)

## **Zarovnání odstavců textu**

Použijte [IParagraphFormat.Alignment](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/alignment/) k nastavení zarovnání odstavce v textovém rámci. Hodnota může být centrovaná, zarovnaná vlevo, vpravo, do bloku atd.

Níže uvedený ukázkový kód ukazuje, jak zarovnat odstavec **do středu**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Nastavit zarovnání odstavce na střed.
    paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

    presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
}
```

Výsledek:

![Zarovnaný odstavec](aligned_paragraph.png)

## **Nastavení průhlednosti textu**

Průhlednost textu se řídí alfa komponentou barvy přiřazené [IPortionFormat.FillFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/iportionformat/fillformat/). V níže uvedených příkladech je `alpha = 50` hodnota ARGB alfa kanálu v rozsahu 0–255, nikoli procento průhlednosti.

Níže uvedený ukázkový kód ukazuje, jak aplikovat průhlednost na **celý odstavec**:

```cs
int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Nastavit barvu výplně textu na průhlednou barvu.
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

    presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
}
```

Výsledek:

![Průhledný odstavec](transparent_paragraph.png)

Níže uvedený ukázkový kód ukazuje, jak aplikovat průhlednost na **textové úseky s tučným písmem**:

```cs
int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // Nastavit průhlednost textového úseku.
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);
        }
    }

    presentation.Save("transparent_text_portions.pptx", SaveFormat.Pptx);
}
```

Výsledek:

![Průhledné textové úseky](transparent_text_portions.png)

## **Nastavení mezery mezi znaky pro text**

Použijte [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/cs/net/aspose.slides/ibaseportionformat/spacing/) k rozšíření nebo zmenšení mezery mezi znaky v textovém rámečku.

Níže uvedený C# kód ukazuje, jak rozšířit mezeru mezi znaky v **celém odstavci**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Poznámka: Použijte záporné hodnoty ke zmenšení mezery mezi znaky.
    paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // Rozšířit mezeru mezi znaky.

    presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
}
```

Výsledek:

![Mezera mezi znaky v odstavci](character_spacing_in_paragraph.png)

Níže uvedený ukázkový kód ukazuje, jak rozšířit mezeru mezi znaky v **textových úsecích s tučným písmem**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
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
}
```

Výsledek:

![Mezera mezi znaky v textových úsecích](character_spacing_in_text_portions.png)

### **Zakázání kerningu pro konkrétní písma**

V některých případech může text vykreslený Aspose.Slides vypadat o něco těsněji než stejný text zobrazený v PowerPointu. K tomu může docházet, protože PowerPoint může ignorovat data kerningu pro určitá písma, i když písmo obsahuje platné informace o kerningu a kerning je v nastavení PowerPointu povolen.

Aby výstup lépe odpovídal PowerPointu, můžete pro textové úseky používající dotčené písmo zakázat kerning. Nastavte [IPortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/cs/net/aspose.slides/ibaseportionformat/kerningminimalsize/) na hodnotu podstatně vyšší než skutečná velikost písma:

```cs
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

Toto nastavení zabraňuje aplikaci kerningu na odpovídající textové úseky a může pomoci sladit vykreslování Aspose.Slides s vizuálním výstupem PowerPointu pro písma ovlivněná tímto specifickým chováním PowerPointu.

## **Správa vlastností písma textu**

Vlastnosti písma lze nastavit na úrovni odstavce přes [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/defaultportionformat/) nebo na jednotlivých úsecích pomocí [IPortionFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/iportionformat/).

Níže uvedený kód nastaví písmo a styl textu pro celý odstavec: aplikuje velikost písma, tučné, kurzívu, tečkované podtržení a písmo Times New Roman na všechny úseky v odstavci.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // Nastavit vlastnosti písma pro odstavec.
    paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 12;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontItalic = NullableBool.True;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontUnderline = TextUnderlineType.Dotted;
    paragraph.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Times New Roman");

    presentation.Save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
}
```

Výsledek:

![Vlastnosti písma pro odstavec](font_properties_for_paragraph.png)

Níže uvedený ukázkový kód aplikuje podobné vlastnosti na **textové úseky s tučným písmem**:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // Nastavit vlastnosti písma pro textový úsek.
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

![Vlastnosti písma pro textové úseky](font_properties_for_text_portions.png)

## **Nastavení otočení textu**

Použijte [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframeformat/textverticaltype/) k nastavení předdefinované orientace textu uvnitř tvaru.

Níže uvedený ukázkový kód nastaví orientaci textu ve tvaru na `Vertical270`, což otočí text **o 90 stupňů proti směru hodinových ručiček**:

```cs
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

Níže uvedený ukázkový kód otočí textový rámeček o 3 stupně po směru hodinových ručiček uvnitř tvaru:

```cs
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

Aspose.Slides poskytuje [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/spacebefore/) a [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/spacewithin/) k řízení řádkování odstavců. Tyto vlastnosti se používají následovně:

* Použijte kladnou hodnotu k určení řádkování jako procenta výšky řádku.
* Použijte zápornou hodnotu k určení řádkování v bodech.

Níže uvedený ukázkový kód ukazuje, jak specifikovat řádkování v odstavci:

```cs
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

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframeformat/autofittype/) určuje, jak se text chová, když přesáhne hranice svého kontejneru. Použijte jej k řízení, zda se text zmenší, přeteče nebo automaticky změní velikost tvaru.

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
}
```

## **Nastavení ukotvení textových rámečků**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframeformat/anchoringtype/) určuje, jak je text vertikálně umístěn uvnitř tvaru, například nahoře, uprostřed nebo dole.

```cs
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

![Tabulátory odstavce](paragraph_tabs.png)

## **Nastavení jazykové korektury**

Aspose.Slides poskytuje [IPortionFormat.LanguageId](https://reference.aspose.com/slides/cs/net/aspose.slides/iportionformat/languageid/), který umožňuje nastavit jazyk korektury pro textový úsek. Jazyk korektury určuje jazyk používaný pro kontrolu pravopisu a gramatiky v PowerPointu.

Níže uvedený ukázkový kód ukazuje, jak nastavit jazyk korektury pro textový úsek:

```cs
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

    // Nastavit Id jazykové korektury.
    textPortion.PortionFormat.LanguageId = "zh-CN";

    textPortion.Text = "1。";
    paragraph.Portions.Add(textPortion);

    presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
}
```

## **Nastavení výchozího jazyka**

Použijte [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/cs/net/aspose.slides/loadoptions/defaulttextlanguage/) k definování výchozího jazyka pro text vytvářený při načítání nebo tvorbě prezentace.

```cs
var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using (var presentation = new Presentation(loadOptions))
{
    var slide = presentation.Slides[0];

    // Přidat nový obdélníkový tvar s textem.
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.TextFrame.Text = "Sample text";

    // Zkontrolovat jazyk prvního úseku.
    var portion = shape.TextFrame.Paragraphs[0].Portions[0];
    Console.WriteLine(portion.PortionFormat.LanguageId);
}
```

## **Nastavení výchozího stylu textu**

Pro aplikaci výchozího formátování textu na úrovni celé prezentace použijte [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentation/defaulttextstyle/).

Níže uvedený ukázkový kód ukazuje, jak nastavit výchozí tučné písmo o velikosti 14 pt pro veškerý text napříč snímky v nové prezentaci.

```cs
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

## **Extrahování textu s efektem VELKÝCH PÍSMEN**

V PowerPointu aplikování efektního **All Caps** způsobí, že se text na snímku zobrazí velkými písmeny, i když byl původně napsán malými. Když takový textový úsek získáte pomocí Aspose.Slides, knihovna vrátí text přesně tak, jak byl zadán. Pro získání zobrazeného textu zkontrolujte [TextCapType](https://reference.aspose.com/slides/cs/net/aspose.slides/textcaptype/) a převod vráceného řetězce na velká písmena, pokud je hodnota `All`.

Předpokládejme, že na první snímek souboru **sample2.pptx** máme následující textový rámeček.

![Efekt All Caps](all_caps_effect.png)

Níže uvedený ukázkový kód ukazuje, jak extrahovat text s aplikovaným efektem **All Caps**:

```cs
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

Pro úpravu textu v tabulce na snímku použijte [ITable](https://reference.aspose.com/slides/cs/net/aspose.slides/itable/). Procházejte buňky a aktualizujte každou buňku pomocí [ICell.TextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/icell/textframe/) a formátování odstavců pomocí [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraph/paragraphformat/).

**Jak aplikovat gradientní barvu na text v PowerPoint snímku?**

Pro aplikaci gradientní barvy na text použijte [IPortionFormat.FillFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/iportionformat/fillformat/). Nastavte [IFillFormat.FillType](https://reference.aspose.com/slides/cs/net/aspose.slides/ifillformat/filltype/) na [FillType.Gradient](https://reference.aspose.com/slides/cs/net/aspose.slides/filltype/) a nakonfigurujte gradientní zastávky, směr a průhlednost.