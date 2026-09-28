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
- vlastnosti písma
- rodina písma
- rotace textu
- úhel rotace
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

Tento článek ukazuje, jak formátovat text v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro .NET. Pokrývá barvy pozadí, průhlednost, rozestupy znaků, vlastnosti písma, rotaci, řádkování odstavců, chování automatického přizpůsobení, ukotvení textu, tabulátory a nastavení jazyka.

Pokud není uvedeno jinak, příklady používají [sample.pptx](sample.pptx). První tvar na první snímku je textové pole a jeho první odstavec obsahuje text zobrazený níže. Indexy snímků i tvarů jsou nulové. Příklady, které vybírají tučné úseky, používají efektivní formátování, včetně zděděného tučného formátování:

![Ukázkový text](sample_text.png)

Pro vyhledání a zvýraznění doslovného textu nebo shod regulárního výrazu viz [Hledat a nahradit text](/slides/cs/net/search-and-replace-text/).

## **Nastavení barvy pozadí textu**

Pomocí [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/defaultportionformat/) lze nastavit výchozí barvu zvýraznění odstavce, nebo použijte [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/cs/net/aspose.slides/ibaseportionformat/highlightcolor/) pro jednotlivé úseky textu.

Následující příklad nastavuje světle šedé zvýraznění jako výchozí pro první odstavec. Explicitní barvy zvýraznění na jednotlivých úsecích mají přednost před tímto výchozím nastavením:

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

Ukázkový kód níže demonstruje, jak nastavit barvu pozadí pro **úseky textu s tučným písmem**:

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
        // Nastavte barvu zvýraznění pro úsek textu.
        portion.PortionFormat.HighlightColor.Color = Color.LightGray;
    }
}

presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
```

Výsledek:

![Šedé úseky textu](gray_text_portions.png)

## **Zarovnání odstavců textu**

Pomocí [IParagraphFormat.Alignment](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/alignment/) lze nastavit zarovnání odstavce v textovém rámečku. Hodnota může být centrováno, zarovnáno vlevo, vpravo, do bloku apod.

Následující kód ukazuje, jak zarovnat odstavec na **střed**:

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

## **Nastavení průhlednosti textu**

Průhlednost textu se řídí alfa‑komponentou barvy přiřazené k [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/ibaseportionformat/fillformat/). V níže uvedených příkladech je `alpha = 50` hodnota kanálu ARGB na stupnici 0–255, nikoli procento průhlednosti.

Kód níže ukazuje, jak aplikovat průhlednost na **celý odstavec**:

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

Následující kód ukazuje, jak aplikovat průhlednost na **úseky textu s tučným písmem**:

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
        // Nastavte průhlednost úseku textu.
        portion.PortionFormat.FillFormat.FillType = FillType.Solid;
        portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);
    }
}

presentation.Save("transparent_text_portions.pptx", SaveFormat.Pptx);
```

Výsledek:

![Průhledné úseky textu](transparent_text_portions.png)

## **Nastavení rozestupu znaků v textu**

Použijte [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/cs/net/aspose.slides/ibaseportionformat/spacing/) ke zvětšení nebo zmenšení rozestupu mezi znaky v textovém poli. Příklady přidávají 3 body rozestupu; záporné hodnoty text zhutní.

Následující C# kód ukazuje, jak rozšířit rozestup znaků v **celém odstavci**:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Poznámka: Použijte záporné hodnoty ke zkomprimování mezery mezi znaky.
paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // Rozšířit mezery mezi znaky.

presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
```

Výsledek:

![Rozestup znaků v odstavci](character_spacing_in_paragraph.png)

Kód níže ukazuje, jak rozšířit rozestup znaků v **úsecích textu s tučným písmem**:

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
        // Poznámka: Použijte záporné hodnoty ke zkomprimování mezery mezi znaky.
        portion.PortionFormat.Spacing = 3;  // Rozšířit mezery mezi znaky.
    }
}

presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
```

Výsledek:

![Rozestup znaků v úsecích textu](character_spacing_in_text_portions.png)

### **Zakázání kerningu pro konkrétní písma**

V některých případech může text vykreslený Aspose.Slides vypadat mírně těsněji než stejný text v PowerPointu. K tomu může docházet, protože PowerPoint může ignorovat data kerningu pro určitá písma, i když písmo obsahuje platné informace o kerningu a kerning je v nastavení PowerPointu povolen.

Aby výstup byl bližší PowerPointu, můžete pro úseky textu, které používají dotčené písmo, kerning zakázat. Nastavte [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/cs/net/aspose.slides/ibaseportionformat/kerningminimalsize/) na hodnotu vyšší než skutečná velikost písma. Tento příklad vyžaduje soubor "presentation.pptx" s textovým polem jako prvním tvarem na prvním snímku. Kontroluje efektivní názvy písem, včetně zděděných, a nastavuje práh 100 bodů pro úseky používající Roboto. To zakáže kerning pro odpovídající úseky s velikostí písma pod 100 bodů:

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

Pro text pod prahem toto nastavení zabraňuje kerningu a může pomoci sladit vykreslování Aspose.Slides s vizuálním výstupem PowerPointu pro písma, na která se toto chování PowerPointu vztahuje.

## **Správa vlastností písma textu**

Vlastnosti písma lze nastavit na úrovni odstavce pomocí [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/defaultportionformat/) nebo na jednotlivých úsecích pomocí [IPortionFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/iportionformat/).

Následující příklad nastavuje výchozí písmo prvního odstavce na Times New Roman 12 bodů s tučným, kurzívovým a tečkovaným podtržením. Explicitní formátování na jednotlivých úsecích má přednost před těmito výchozími hodnotami:

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

![Vlastnosti písma odstavce](font_properties_for_paragraph.png)

Následující příklad aplikuje Times New Roman 13 bodů, kurzívu a tečkované podtržení na úseky, jejichž efektivní formátování je tučné:

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
        // Nastavte vlastnosti písma pro úsek textu.
        portion.PortionFormat.FontHeight = 13;
        portion.PortionFormat.FontItalic = NullableBool.True;
        portion.PortionFormat.FontUnderline = TextUnderlineType.Dotted;
        portion.PortionFormat.LatinFont = new FontData("Times New Roman");
    }
}

presentation.Save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
```

Výsledek:

![Vlastnosti písma úseků textu](font_properties_for_text_portions.png)

## **Nastavení rotace textu**

Pomocí [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframeformat/textverticaltype/) lze nastavit předdefinovanou orientaci textu uvnitř tvaru.

Následující kód nastavuje orientaci textu ve tvaru na [TextVerticalType.Vertical270](https://reference.aspose.com/slides/cs/net/aspose.slides/textverticaltype/), což otáčí text **o 90 stupňů proti směru hodinových ručiček**:

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

## **Nastavení vlastní rotace pro textové rámečky**

Pomocí [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframeformat/rotationangle/) lze nastavit vlastní úhel rotace pro [ITextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/).

Níže uvedený kód otáčí textový rámeček o 3 stupně po směru hodinových ručiček uvnitř tvaru:

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

Aspose.Slides poskytuje [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/spacebefore/) a [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/spacewithin/) pro řízení řádkování odstavců. Tyto vlastnosti se používají následovně:

* Použijte kladnou hodnotu pro určení řádkování jako procento výšky řádku.
* Použijte zápornou hodnotu pro určení řádkování v bodech.

Následující příklad nastavuje řádkování uvnitř prvního odstavce na 200 % výšky řádku (dvojité řádkování):

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

Pravidla pro zalamování řádků odstavce jsou užitečná v úzkých textových blocích a prezentacích, které kombinují latinský a východoasijský text. Následující vlastnosti patří do [IParagraphFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/), takže se vztahují na celý odstavec:

- [LatinLineBreak](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/latinlinebreak/) řídí pravidla zalamování pro latinský text. Ve smíšeném textu jeho změna může také měnit, kde se zalamuje sousední východoasijský text a interpunkce.
- [EastAsianLineBreak](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/eastasianlinebreak/) řídí pravidla zalamování pro východoasijské texty, včetně omezení znaků na začátku a konci řádku.

Tato pravidla nenahrazují [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframeformat/wraptext/), který povoluje automatické zalamování v textovém rámečku. Pravidla ovlivňují rozvržení při zalamování; nevkládají znaky nového řádku. Explicitní zalomení řádku vynutí novou řádku v odstavci nezávisle na dostupné šířce.

Následující samostatný příklad vytvoří úzký textový blok obsahující čínštinu a latinku. Explicitně nastaví obě vlastnosti zalamování řádků a uloží soubor "line_breaking.pptx". Pro experimentování s libovolným pravidlem změňte hodnotu této vlastnosti při zachování ostatních nastavení. Příklad používá Arial 24 bodů a SimSun s šířkou rámečku 160 bodů a nulovými horizontálními okraji textového rámečku. [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframeformat/autofittype/) je nastaven na [TextAutofitType.None](https://reference.aspose.com/slides/cs/net/aspose.slides/textautofittype/), aby velikost textu a rozměry rámečku zůstaly pevné.

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

## **Řízení visící interpunkce**

[IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/hangingpunctuation/) umožňuje, aby oprávněná interpunkční znaménka přesahovala pravý okraj řádky textu místo aby se umístila na další řádek. Vztahuje se na celý odstavec a liší se od visícího odsazení.

Následující samostatný příklad povolí visící interpunkci v 100‑bodovém širokém textovém rámečku a uloží soubor "hanging_punctuation.pptx". S Arial 24 bodů a nulovými horizontálními okraji textového rámečku zůstane poslední tečka po slově „sentence“ a přesáhne pravý okraj textu. Nastavte vlastnost na [NullableBool.False](https://reference.aspose.com/slides/cs/net/aspose.slides/nullablebool/) pro srovnání: s tímto nastavením tečka zaujme samostatnou řádku. Zalamování je povoleno a automatické přizpůsobení vypnuto, aby šířka zůstala pevná.

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

Ne každé interpunkční znaménko může viset. Výše popsané [podmínky a omezení](#conditions-and-limitations) se vztahují i na toto srovnání: změna písma, dostupné šířky, okrajů nebo nastavení automatického přizpůsobení může rozdíl zrušit.

## **Nastavení typu automatického přizpůsobení pro textové rámečky**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframeformat/autofittype/) určuje, jak se text chová, když přesáhne hranice svého kontejneru. Použijte jej k řízení, zda se text zmenší, přeteče nebo automaticky změní velikost tvaru. Následující příklad konfiguruje tvar tak, aby se přizpůsobil svému textu, a výsledek uloží do souboru "autofit_type.pptx".

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

Pro spočítání řádků po automatickém zalomení a zobrazení, jak se mění šířka textu nebo tvaru, viz [Počítání vykreslených řádků](/slides/cs/net/manage-paragraph/). Pouze počet řádků neurčuje, zda text přeteče kontejner.

## **Nastavení ukotvení textových rámečků**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframeformat/anchoringtype/) určuje, jak je text vertikálně umístěn uvnitř tvaru, např. nahoře, uprostřed nebo dole. Následující příklad ukotví text ke spodnímu okraji prvního tvaru a výsledek uloží do souboru "text_anchor.pptx".

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
```

## **Nastavení tabulátorů v textu**

Použijte [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/defaulttabsize/) a [IParagraphFormat.Tabs](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/tabs/) ke konfiguraci tabulátorů v odstavci. Následující příklad nastaví výchozí interval tabulátoru na 100 bodů a přidá levý zarovnaný tabulátor na 30 bodů. Tato nastavení ovlivňují text obsahující znak tabulátoru.

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

Aspose.Slides poskytuje [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/cs/net/aspose.slides/ibaseportionformat/languageid/), který umožňuje nastavit jazyk kontroly pravopisu a gramatiky pro úsek textu. Jazyková kontrola určuje, jaký jazyk se použije při kontrole pravopisu a gramatiky v PowerPointu.

Následující příklad vyžaduje soubor "presentation.pptx" s textovým polem jako prvním tvarem na první snímku a alespoň jedním odstavcem. Nahrazuje obsah prvního odstavce řetězcem "1。", nastaví písmo SimSun a přiřadí jazyk kontroly zjednodušené čínštiny (`zh-CN`). Výsledek uloží do souboru "proofing_language.pptx":

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

## **Nastavení výchozího jazyka**

Použijte [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/cs/net/aspose.slides/loadoptions/defaulttextlanguage/) k definování výchozího jazyka pro text vytvořený při načítání nebo tvorbě prezentace. Následující příklad vytvoří prezentaci s US English jako výchozím jazykem textu, přidá textové pole a vytiskne `en-US` pro jeho první úsek textu.

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

// Zkontrolujte jazyk první úseku.
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine(portion.PortionFormat.LanguageId);
```

## **Nastavení výchozího stylu textu**

Pro aplikaci výchozího formátování textu na úrovni prezentace použijte [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/cs/net/aspose.slides/ipresentation/defaulttextstyle/).

Následující příklad nastaví 14‑bodové tučné písmo jako výchozí pro odstavce nejvyšší úrovně v nové prezentaci a uloží ji do souboru "default_text_style.pptx". Text může tyto výchozí hodnoty zdědit, pokud není přepsán konkrétnějším formátováním.

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

## **Extrahování textu s efektem VŠECH VELKÝCH PÍSMEN**

V PowerPointu aplikace efektu **All Caps** (všechna písmena) způsobí, že se text na snímku zobrazí velkými písmeny, i když byl původně zadán malými. Když takový úsek textu získáte pomocí Aspose.Slides, knihovna vrátí text přesně tak, jak byl zadán. Pro sladění s zobrazovaným textem zkontrolujte [TextCapType](https://reference.aspose.com/slides/cs/net/aspose.slides/textcaptype/) a při hodnotě `All` převeďte vrácený řetězec na velká písmena.

Tento příklad vyžaduje soubor "sample2.pptx" s textovým polem jako prvním tvarem na první snímku. První úsek prvního odstavce obsahuje "Hello, Aspose!" s aplikovaným efektem All Caps, jak je zobrazeno níže.

![Efekt All Caps](all_caps_effect.png)

Níže uvedený kód ukazuje, jak extrahovat text s aplikovaným efektem **All Caps**:

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

Pro úpravu textu v tabulce na snímku použijte [ITable](https://reference.aspose.com/slides/cs/net/aspose.slides/itable/). Procházejte buňky a aktualizujte každou buňku přes [ICell.TextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/icell/textframe/) a formátování odstavců přes [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraph/paragraphformat/).

**Jak aplikovat barevný přechod na text na snímku PowerPoint?**

Pro aplikaci barevného přechodu na text použijte [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/ibaseportionformat/fillformat/). Nastavte [IFillFormat.FillType](https://reference.aspose.com/slides/cs/net/aspose.slides/ifillformat/filltype/) na [FillType.Gradient](https://reference.aspose.com/slides/cs/net/aspose.slides/filltype/) a nakonfigurujte zastavení přechodu, směr a průhlednost.