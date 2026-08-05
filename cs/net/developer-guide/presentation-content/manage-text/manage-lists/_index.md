---
title: Spravovat odrážkové a číslované seznamy v prezentacích v .NET
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
description: "Zjistěte, jak v PowerPoint a OpenDocument prezentacích pomocí Aspose.Slides pro .NET vytvořit a formátovat odrážkové, obrázkové, víceúrovňové a číslované seznamy."
---
## **Přehled**

Aspose.Slides pro .NET vám umožňuje vytvářet a formátovat odrážkové a číslované seznamy v prezentacích PowerPoint a OpenDocument. Položka seznamu je odstavec, jehož nastavení odrážky je řízeno prostřednictvím formátu odstavce.

Použijte vlastnost [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraph/paragraphformat/) k přístupu k nastavením seznamu na úrovni odstavce. Hlavním vstupním bodem je [IParagraphFormat.Bullet](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/bullet/), který vrací objekt [IBulletFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/ibulletformat/). S tímto objektem můžete nastavit typ odrážky, symbol, obrázek, barvu, velikost, styl číslování a počáteční číslo.

Tento článek ukazuje, jak:

- vytvořit odrážkový seznam s vlastním symbolem
- vytvořit obrázkovou odrážku
- vytvořit víceúrovňový seznam nastavením hloubky odstavce
- vytvořit číslovaný seznam
- prohlédnout a změnit formátování seznamu v existující prezentaci

## **Vytvoření odrážkového seznamu**

Pro vytvoření odrážkového seznamu přidejte objekty [IParagraph](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraph/) do [ITextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/) a nastavte [IBulletFormat.Type](https://reference.aspose.com/slides/cs/net/aspose.slides/ibulletformat/type/) na [BulletType.Symbol](https://reference.aspose.com/slides/cs/net/aspose.slides/bullettype/). Poté můžete nastavit [IBulletFormat.Char](https://reference.aspose.com/slides/cs/net/aspose.slides/ibulletformat/char/), [IBulletFormat.Color](https://reference.aspose.com/slides/cs/net/aspose.slides/ibulletformat/color/) a [IBulletFormat.Height](https://reference.aspose.com/slides/cs/net/aspose.slides/ibulletformat/height/) pro řízení vzhledu odrážky.

Následující C# kód demonstruje, jak vytvořit odrážkový seznam na snímku:

```csharp
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

![The symbol bullets](symbol_bullets.png)

## **Vytvoření číslovaného seznamu**

Používejte číslované seznamy, když má pořadí položek význam. Nastavte [IBulletFormat.Type](https://reference.aspose.com/slides/cs/net/aspose.slides/ibulletformat/type/) na [BulletType.Numbered](https://reference.aspose.com/slides/cs/net/aspose.slides/bullettype/). Můžete také zvolit formát číslování pomocí [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/cs/net/aspose.slides/ibulletformat/numberedbulletstyle/) nebo nastavit [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/cs/net/aspose.slides/ibulletformat/numberedbulletstartwith/), pokud má seznam začít hodnotou jinou než 1.

Následující C# kód ukazuje, jak vytvořit číslovaný seznam na snímku:

```csharp
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

![The numbered bullets](numbered_bullets.png)

## **Vytvoření obrázkové odrážky**

Aspose.Slides vám umožňuje nahradit běžný symbol odrážky obrázkem. Obrázkové odrážky fungují nejlépe s jednoduchými obrázky, které zůstávají čitelné při malé velikosti, například s ikonami nebo malými průhlednými PNG soubory.

{{% alert color="primary" %}}
Ideální je, když plánujete nahradit běžný symbol odrážky obrázkem, zvolit jednoduchou grafiku s průhledným pozadím. Takové obrázky dobře fungují jako vlastní symboly odrážek.
{{% /alert %}}

Pro vytvoření obrázkové odrážky přidejte obrázek do [Presentation.Images](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/images/) a přiřaďte získaný objekt obrázku k [IBulletFormat.Picture](https://reference.aspose.com/slides/cs/net/aspose.slides/ibulletformat/picture/). Nastavte [IBulletFormat.Type](https://reference.aspose.com/slides/cs/net/aspose.slides/ibulletformat/type/) na [BulletType.Picture](https://reference.aspose.com/slides/cs/net/aspose.slides/bullettype/) před přiřazením obrázku.

Předpokládejme, že máme soubor "image.png":

![A picture for the bullets](picture_for_bullets.png)

Následující C# kód ukazuje, jak vytvořit obrázkové odrážky na snímku:

```csharp
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

![The picture bullets](picture_bullets.png)

## **Vytvoření víceúrovňového seznamu**

Použijte [IParagraphFormat.Depth](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/depth/) k umístění položek seznamu na různé úrovně. Úroveň 0 je nejvyšší úroveň, úroveň 1 je pod ní atd.

Následující C# kód ukazuje, jak vytvořit víceúrovňový odrážkový seznam:

```csharp
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

![The multilevel list](multilevel_list.png)

## **Změna existujícího seznamu**

Pro změnu formátování seznamu v existující prezentaci přistupte k cílovému odstavci a aktualizujte jeho nastavení [IParagraphFormat.Bullet](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/bullet/). Stejné vlastnosti použité při vytváření seznamů lze použít i k prohlížení nebo úpravě seznamů načtených ze souboru PPT, PPTX nebo ODP.

Následující C# kód mění první odstavec v textovém rámci tak, aby používal číslovaný styl seznamu:

```csharp
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

## **Často kladené otázky**

**Lze odrážkové a číslované seznamy exportovat do PDF nebo obrázků?**

Ano. Aspose.Slides zachovává formátování seznamu, pokud cílový formát podporuje odpovídající rozložení textu a funkce odrážek.

**Mohu upravovat seznamy v existujících prezentacích?**

Ano. Načtěte prezentaci, přistupte k cílovému odstavci, prohlédněte nebo aktualizujte jeho nastavení [IParagraphFormat.Bullet](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/bullet/) a prezentaci uložte.

**Mohou seznamy obsahovat text v ne-latinových skriptech?**

Ano. Text položek seznamu může obsahovat Unicode znaky, takže můžete vytvářet seznamy ve vícejazykových prezentacích. Ujistěte se, že použité fonty v prezentaci podporují požadované znaky.