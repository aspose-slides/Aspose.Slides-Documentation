---
title: Správa odrážkových a číslovaných seznamů v prezentacích v .NET
linktitle: Spravovat seznamy
type: docs
weight: 70
url: /cs/net/manage-lists/
aliases:
  - /net/manage-bullet-and-numbered-lists/
keywords:
- odrážka
- odrážkový seznam
- číslovaný seznam
- symbolická odrážka
- obrázková odrážka
- vlastní odrážka
- víceúrovňový seznam
- vytvořit odrážku
- přidat odrážku
- přidat seznam
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Naučte se, jak pomocí Aspose.Slides pro .NET vytvořit a formátovat odrážkové, obrázkové, víceúrovňové a číslované seznamy v prezentacích PowerPoint a OpenDocument."
---
## **Přehled**

Aspose.Slides pro .NET vám umožňuje vytvářet a formátovat odrážkové i číslované seznamy v prezentacích PowerPoint a OpenDocument. Položka seznamu je odstavec, jehož nastavení odrážky je řízeno pomocí formátu odstavce.

Použijte vlastnost [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/paragraphformat/) k přístupu k nastavením seznamu na úrovni odstavce. Hlavním vstupním bodem je [IParagraphFormat.Bullet](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/bullet/), který vrací objekt [IBulletFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/). S tímto objektem můžete nastavit typ odrážky, symbol, obrázek, barvu, velikost, styl číslování a počáteční číslo.

Tento článek ukazuje, jak:

- vytvořit odrážkový seznam s vlastním symbolem
- vytvořit obrázkovou odrážku
- vytvořit víceúrovňový seznam nastavením hloubky odstavce
- vytvořit číslovaný seznam
- prozkoumat a změnit formátování seznamu v existující prezentaci
- číst skutečné značky seznamu a čísla spolu s textem odstavce

## **Vytvoření odrážkového seznamu**

K vytvoření odrážkového seznamu přidejte objekty [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) do [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) a nastavte [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) na [BulletType.Symbol](https://reference.aspose.com/slides/net/aspose.slides/bullettype/). Poté můžete nastavit [IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/), [IBulletFormat.Color](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/color/), a [IBulletFormat.Height](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/height/) pro řízení vzhledu odrážky.

Následující kód v C# demonstruje, jak vytvořit odrážkový seznam na snímku:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

static Paragraph CreateParagraph(string text)
{
    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    paragraph.ParagraphFormat.Bullet.Char = '*';
    paragraph.ParagraphFormat.Indent = 15;
    paragraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
    paragraph.ParagraphFormat.Bullet.Color.Color = Color.IndianRed;
    paragraph.ParagraphFormat.Bullet.Height = 100;
    paragraph.Text = text;
    return paragraph;
}

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph1 = CreateParagraph("The first paragraph");
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = CreateParagraph("The second paragraph");
textFrame.Paragraphs.Add(paragraph2);

presentation.Save("symbol_bullets.pptx", SaveFormat.Pptx);
```

Výsledek:

![Symbolické odrážky](symbol_bullets.png)

## **Vytvoření číslovaného seznamu**

Používejte číslované seznamy, když je důležité pořadí položek. Nastavte [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) na [BulletType.Numbered](https://reference.aspose.com/slides/net/aspose.slides/bullettype/). Můžete také zvolit formát číslování pomocí [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstyle/) nebo nastavit [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/), pokud má seznam začít od hodnoty jiného než 1.

Následující kód v C# ukazuje, jak vytvořit číslovaný seznam na snímku:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 90, 80);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph1 = new Paragraph();
paragraph1.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph1.Text = "Apple";
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = new Paragraph();
paragraph2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph2.Text = "Orange";
textFrame.Paragraphs.Add(paragraph2);

var paragraph3 = new Paragraph();
paragraph3.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph3.Text = "Banana";
textFrame.Paragraphs.Add(paragraph3);

presentation.Save("numbered_bullets.pptx", SaveFormat.Pptx);
```

Výsledek:

![Číslované odrážky](numbered_bullets.png)

## **Vytvoření obrázkové odrážky**

Aspose.Slides vám umožňuje nahradit běžný symbol odrážky obrázkem. Obrázkové odrážky fungují nejlépe s jednoduchými obrázky, které jsou i při malé velikosti čitelné, například ikony nebo malé průhledné soubory PNG.

{{% alert color="info" title="Note" %}}
Cílově, pokud plánujete nahradit běžný symbol odrážky obrázkem, je nejlepší zvolit jednoduchou grafiku s průhledným pozadím. Takové obrázky dobře fungují jako vlastní symboly odrážek.
{{% /alert %}}

Pro vytvoření obrázkové odrážky přidejte obrázek do [Presentation.Images](https://reference.aspose.com/slides/net/aspose.slides/presentation/images/) a přiřaďte vrácený objekt obrázku k [IBulletFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/picture/). Nastavte [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) na [BulletType.Picture](https://reference.aspose.com/slides/net/aspose.slides/bullettype/) před přiřazením obrázku.

Předpokládejme, že máme soubor „image.png“:

![Obrázek pro odrážky](picture_for_bullets.png)

Následující kód v C# ukazuje, jak vytvořit obrázkové odrážky na snímku:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

static Paragraph CreateParagraph(string text, IPPImage image)
{
    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
    paragraph.ParagraphFormat.Bullet.Picture.Image = image;
    paragraph.ParagraphFormat.Indent = 15;
    paragraph.ParagraphFormat.Bullet.Height = 100;
    paragraph.Text = text;
    return paragraph;
}

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var imageBytes = File.ReadAllBytes("image.png");
var bulletImage = presentation.Images.AddImage(imageBytes);

var paragraph1 = CreateParagraph("The first paragraph", bulletImage);
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = CreateParagraph("The second paragraph", bulletImage);
textFrame.Paragraphs.Add(paragraph2);

presentation.Save("picture_bullets.pptx", SaveFormat.Pptx);
```

Výsledek:

![Obrázkové odrážky](picture_bullets.png)

## **Vytvoření víceúrovňového seznamu**

Použijte [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) k umístění položek seznamu na různé úrovně. Úroveň 0 je nejvyšší úroveň, úroveň 1 je pod ní vnořená, a tak dále.

Následující kód v C# ukazuje, jak vytvořit víceúrovňový odrážkový seznam:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 260, 110);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph1 = new Paragraph();
paragraph1.ParagraphFormat.Depth = 0;
paragraph1.Text = "My text - Depth 0";
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = new Paragraph();
paragraph2.ParagraphFormat.Depth = 1;
paragraph2.Text = "My text - Depth 1";
textFrame.Paragraphs.Add(paragraph2);

var paragraph3 = new Paragraph();
paragraph3.ParagraphFormat.Depth = 2;
paragraph3.Text = "My text - Depth 2";
textFrame.Paragraphs.Add(paragraph3);

var paragraph4 = new Paragraph();
paragraph4.ParagraphFormat.Depth = 3;
paragraph4.Text = "My text - Depth 3";
textFrame.Paragraphs.Add(paragraph4);

presentation.Save("multilevel_bullets.pptx", SaveFormat.Pptx);
```

Výsledek:

![Víceúrovňový seznam](multilevel_list.png)

## **Změna existujícího seznamu**

Pro změnu formátování seznamu v existující prezentaci přistupte k cílovému odstavci a aktualizujte jeho nastavení [IParagraphFormat.Bullet](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/bullet/). Stejné vlastnosti použité k vytváření seznamů lze použít k prozkoumání nebo úpravě seznamů načtených ze souborů PPT, PPTX nebo ODP.

Následující kód v C# mění první odstavec v textovém rámci, aby používal styl číslovaného seznamu:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];
var autoShape = (IAutoShape)slide.Shapes[0];

var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletRomanUCPeriod;
paragraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 1;
paragraph.ParagraphFormat.MarginLeft = 30;
paragraph.ParagraphFormat.Indent = -20;

presentation.Save("updated_list.pptx", SaveFormat.Pptx);
```

## **Čtení skutečných hodnot odrážek**

Při extrahování obsahu prezentace uchovávejte značky seznamu spolu s textem odstavce. Zavolejte [IParagraphFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/geteffective/) a přistupte k [IParagraphFormatEffectiveData.Bullet](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformateffectivedata/bullet/), abyste získali efektivní formát odrážky. Zkontrolujte jeho [Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/type/) předtím, než přečtete [ActualBulletValue](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/actualbulletvalue/).

U číslovaných seznamů rozlište tyto tři hodnoty:

- [NumberedBulletStyle](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/numberedbulletstyle/) určuje formát, například arabské číslice následované tečkou nebo malá písmena následovaná tečkou.
- [NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/numberedbulletstartwith/) udává počáteční číslo pro skupinu číslovaných odstavců.
- [ActualBulletValue](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/actualbulletvalue/) vrací formátovanou značku pro konkrétní odstavec. Například druhá položka v seznamu začínajícím od 5 vrátí `6.`.

Zachovejte [Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) u každého odstavce, aby se udržela jeho úroveň vnoření. Skutečná značka neobsahuje celou hierarchii: vnořená položka může vrátit `c.` místo kombinovaného štítku jako `6.c.`.

Následující samostatný příklad vytváří seznamy, uloží je do prezentace a znovu načte prezentaci, aby nahlásil text, hloubku, typ odrážky a skutečnou hodnotu každého odstavce. Malý modrý obrázkový marker je vytvořen z vloženého SVG.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation())
{
    presentation.SlideSize.SetSize(720, 440, SlideSizeScaleType.DoNotScale);
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 20, 660, 400);
    shape.FillFormat.FillType = FillType.NoFill;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;

    var textFrame = shape.TextFrame;
    textFrame.Paragraphs.Clear();

    // Vytvořte obrázkový marker bez externího souboru obrázku.
    var svg = new SvgImage("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>");
    var bulletImage = presentation.Images.AddImage(svg);

    void AddParagraph(string text, short depth, BulletType type, short start = 1, NumberedBulletStyle style = NumberedBulletStyle.BulletArabicPeriod)
    {
        var paragraph = new Paragraph { Text = text };

        var format = paragraph.ParagraphFormat;
        format.Depth = depth;
        format.MarginLeft = 30 + depth * 40;
        format.Indent = -28;
        format.SpaceAfter = 8;
        format.DefaultPortionFormat.FontHeight = 22;
        format.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
        format.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
        format.Bullet.Type = type;
        format.Bullet.IsBulletHardColor = NullableBool.True;
        format.Bullet.Color.Color = Color.Black;
        if (type == BulletType.Numbered)
        {
            format.Bullet.NumberedBulletStyle = style;
            format.Bullet.NumberedBulletStartWith = start;
        }
        else if (type == BulletType.Symbol)
        {
            format.Bullet.Char = '\u2022';
        }
        else if (type == BulletType.Picture)
        {
            format.Bullet.Picture.Image = bulletImage;
        }

        textFrame.Paragraphs.Add(paragraph);
    }

    AddParagraph("First item", 0, BulletType.Numbered, 5);
    AddParagraph("Second item", 0, BulletType.Numbered, 5);
    AddParagraph("Nested item", 1, BulletType.Numbered, 3, NumberedBulletStyle.BulletAlphaLCPeriod);
    AddParagraph("Next nested item", 1, BulletType.Numbered, 3, NumberedBulletStyle.BulletAlphaLCPeriod);
    AddParagraph("Deep item", 2, BulletType.Numbered, 4, NumberedBulletStyle.BulletRomanLCPeriod);
    AddParagraph("Back to top level", 0, BulletType.Numbered, 5);
    AddParagraph("Symbol marker", 0, BulletType.Symbol);
    AddParagraph("No bullet", 0, BulletType.None);
    AddParagraph("Picture marker", 0, BulletType.Picture);
    presentation.Save("actual_bullet_values.pptx", SaveFormat.Pptx);
}

using var loadedPresentation = new Presentation("actual_bullet_values.pptx");
var loadedShape = (IAutoShape)loadedPresentation.Slides[0].Shapes[0];
Console.WriteLine("Text | Depth | Type | Actual value");
foreach (var paragraph in loadedShape.TextFrame.Paragraphs)
{
    var bullet = paragraph.ParagraphFormat.GetEffective().Bullet;
    string marker;
    switch (bullet.Type)
    {
        case BulletType.Numbered:
        case BulletType.Symbol:
            marker = bullet.ActualBulletValue;
            break;
        case BulletType.None:
            marker = $"{bullet.ActualBulletValue ?? "null"} (no bullet)";
            break;
        case BulletType.Picture:
            marker = $"{bullet.ActualBulletValue ?? "null"} (image required)";
            break;
        default:
            marker = "unsupported bullet type";
            break;
    }
    Console.WriteLine($"{paragraph.Text} | {paragraph.ParagraphFormat.Depth} | {bullet.Type} | {marker}");
}
```

Zdrojové seznamy jsou zobrazeny níže.

![Seznamy začínající od 5, vnořené položky s písmeny a římskými čísly, symbolová značka, odstavec bez odrážky a modrý obrázkový marker](actual_bullet_values.png)

Zpráva odpovídá značkám zobrazeným v PowerPointu:

```text
Text | Depth | Type | Actual value
First item | 0 | Numbered | 5.
Second item | 0 | Numbered | 6.
Nested item | 1 | Numbered | c.
Next nested item | 1 | Numbered | d.
Deep item | 2 | Numbered | iv.
Back to top level | 0 | Numbered | 7.
Symbol marker | 0 | Symbol | •
No bullet | 0 | None | null (no bullet)
Picture marker | 0 | Picture | null (image required)
```

Pro [BulletType.None a BulletType.Picture](https://reference.aspose.com/slides/net/aspose.slides/bullettype/) [ActualBulletValue](https://reference.aspose.com/slides/net/aspose.slides/ibulletformateffectivedata/actualbulletvalue/) vrací `null`, nikoli prázdný řetězec. Tyto typy zpracovávejte odděleně: první nemá žádnou značku, zatímco druhý vyžaduje samostatné získání obrázku odrážky. Obrázkovou odrážku nelze reprodukovat pouze extrahováním textové značky.

## **Často kladené otázky**

**Lze odrážkové a číslované seznamy exportovat do PDF nebo obrázků?**

Ano. Aspose.Slides zachovává formátování seznamu, pokud cílový formát podporuje odpovídající rozvržení textu a funkce odrážek.

**Mohu upravovat seznamy v existujících prezentacích?**

Ano. Načtěte prezentaci, přistupte k cílovému odstavci, prozkoumejte nebo aktualizujte jeho nastavení [IParagraphFormat.Bullet](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/bullet/), a uložte prezentaci.

**Mohou seznamy obsahovat ne-latiný text?**

Ano. Text položek seznamu může obsahovat Unicode znaky, takže můžete vytvářet seznamy v vícejazykových prezentacích. Ujistěte se, že použité fonty v prezentaci podporují požadované znaky.