---
title: Spravovat textové odstavce PowerPointu v .NET
linktitle: Spravovat odstavec
type: docs
weight: 40
url: /cs/net/manage-paragraph/
aliases:
  - /net/paragraph/
  - /net/portion/
keywords:
- přidat text
- přidat odstavec
- spravovat text
- spravovat odstavec
- spravovat odrážku
- odsazení odstavce
- zavěšené odsazení
- odrážka odstavce
- číslovaný seznam
- odrážkový seznam
- vlastnosti odstavce
- importovat HTML
- text do HTML
- odstavec do HTML
- odstavec do obrázku
- text do obrázku
- exportovat odstavec
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Naučte se, jak pomocí Aspose.Slides pro .NET vytvářet a formátovat odstavce, úseky, odrážky, číslované seznamy, odsazení, HTML obsah a obrázky odstavců."
---
## **Přehled**

Aspose.Slides pro .NET představuje text jako hierarchii textových rámců, odstavců a úseků:

* [ITextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/) představuje kontejner textu v tvaru a poskytuje přístup k jeho kolekci odstavců.
* [IParagraph](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraph/) představuje jeden odstavec v textovém rámci a poskytuje přístup k jeho úsekům a formátování na úrovni odstavce.
* [IPortion](https://reference.aspose.com/slides/cs/net/aspose.slides/iportion/) představuje úsek textu v rámci odstavce. Každý úsek může mít vlastní text a formátování na úrovni znaků.

Odstavec tak může obsahovat text s různými fonty, barvami, velikostmi a dalším formátováním pomocí více úseků.

## **Vytváření a formátování odstavců**

### **Vytvoření odstavců s více úseky**

Následující kroky vytvoří textový rámec se třemi odstavci, z nichž každý obsahuje tři úseky:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
2. Získejte odkaz na příslušný snímek pomocí jeho indexu.
3. Přidejte obdélníkový [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/) na snímek.
4. Získejte [ITextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/) tvaru.
5. Použijte výchozí odstavec a přidejte dva další objekty [IParagraph](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraph/) do textového rámce.
6. Přidejte dostatek objektů [IPortion](https://reference.aspose.com/slides/cs/net/aspose.slides/iportion/) pro každý odstavec, aby obsahoval tři úseky. Výchozí odstavec již obsahuje jeden prázdný úsek.
7. Nastavte text každého úseku.
8. Použijte formátování na úrovni znaků pomocí [IPortion.PortionFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/iportion/portionformat/).
9. Uložte upravenou prezentaci.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);
var textFrame = shape.TextFrame;

var firstParagraph = textFrame.Paragraphs[0];
firstParagraph.Portions.Add(new Portion());
firstParagraph.Portions.Add(new Portion());

var secondParagraph = new Paragraph();
secondParagraph.Portions.Add(new Portion());
secondParagraph.Portions.Add(new Portion());
secondParagraph.Portions.Add(new Portion());
textFrame.Paragraphs.Add(secondParagraph);

var thirdParagraph = new Paragraph();
thirdParagraph.Portions.Add(new Portion());
thirdParagraph.Portions.Add(new Portion());
thirdParagraph.Portions.Add(new Portion());
textFrame.Paragraphs.Add(thirdParagraph);

var paragraphCount = textFrame.Paragraphs.Count;
for (var paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    var paragragaph = textFrame.Paragraphs[paragraphIndex];
    var portionCount = paragragaph.Portions.Count;
    for (var portionIndex = 0; portionIndex < portionCount; portionIndex++)
    {
        var portion = paragragaph.Portions[portionIndex];
        portion.Text = $"Portion {paragraphIndex + 1}.{portionIndex + 1}";

        if (portionIndex == 0)
        {
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;
            portion.PortionFormat.FontBold = NullableBool.True;
            portion.PortionFormat.FontHeight = 15;
        }
        else if (portionIndex == 1)
        {
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;
            portion.PortionFormat.FontItalic = NullableBool.True;
            portion.PortionFormat.FontHeight = 18;
        }
    }
}

presentation.Save("paragraphs_with_portions.pptx", SaveFormat.Pptx);
```

## **Vytvoření odrážkových a číslovaných seznamů**

### **Vytvoření odrážkového nebo číslovaného seznamu**

Odrážky a číslování usnadňují skenování souvisejících položek. V Aspose.Slides jsou nastavení seznamu definována přes [IBulletFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/ibulletformat/).

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
2. Získejte odkaz na příslušný snímek pomocí jeho indexu.
3. Přidejte [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/) na vybraný snímek.
4. Získejte [ITextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/).
5. Odstraňte výchozí odstavec z textového rámce.
6. Vytvořte [Paragraph](https://reference.aspose.com/slides/cs/net/aspose.slides/paragraph/) pro symbolovou odrážku.
7. Nastavte [IBulletFormat.Type](https://reference.aspose.com/slides/cs/net/aspose.slides/ibulletformat/type/) na [BulletType.Symbol](https://reference.aspose.com/slides/cs/net/aspose.slides/bullettype/) a určete znak odrážky.
8. Nastavte text odstavce, odsazení, barvu odrážky a výšku odrážky.
9. Přidejte odstavec do textového rámce.
10. Vytvořte druhý odstavec a nastavte [IBulletFormat.Type](https://reference.aspose.com/slides/cs/net/aspose.slides/ibulletformat/type/) na [BulletType.Numbered](https://reference.aspose.com/slides/cs/net/aspose.slides/bullettype/).
11. Nakonfigurujte styl číslované odrážky a přidejte odstavec do textového rámce.
12. Uložte prezentaci.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var symbolParagraph = new Paragraph { Text = "Welcome to Aspose.Slides" };
symbolParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
symbolParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
symbolParagraph.ParagraphFormat.Indent = 25;
symbolParagraph.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
symbolParagraph.ParagraphFormat.Bullet.Color.Color = Color.Black;
symbolParagraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
symbolParagraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(symbolParagraph);

var numberedParagraph = new Paragraph { Text = "This is a numbered item" };
numberedParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
numberedParagraph.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;
numberedParagraph.ParagraphFormat.Indent = 25;
numberedParagraph.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
numberedParagraph.ParagraphFormat.Bullet.Color.Color = Color.Black;
numberedParagraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
numberedParagraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(numberedParagraph);

presentation.Save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx);
```

### **Použití obrázkových odrážek**

Obrázkové odrážky umožňují použít vlastní obrázek místo symbolu nebo čísla.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
2. Získejte odkaz na příslušný snímek pomocí jeho indexu.
3. Přidejte [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/) a získejte jeho [ITextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/).
4. Odstraňte výchozí odstavec z textového rámce.
5. Načtěte obrázek odrážky a přidejte jej do kolekce obrázků prezentace jako [IPPImage](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage/).
6. Vytvořte [Paragraph](https://reference.aspose.com/slides/cs/net/aspose.slides/paragraph/) a nastavte jeho text.
7. Nastavte [IBulletFormat.Type](https://reference.aspose.com/slides/cs/net/aspose.slides/ibulletformat/type/) na [BulletType.Picture](https://reference.aspose.com/slides/cs/net/aspose.slides/bullettype/).
8. Přiřaďte obrázek pomocí [IBulletFormat.Picture](https://reference.aspose.com/slides/cs/net/aspose.slides/ibulletformat/picture/) a nastavte výšku odrážky.
9. Přidejte odstavec do textového rámce.
10. Uložte upravenou prezentaci.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var bulletImage = Images.FromFile("bullets.png");
var presentationImage = presentation.Images.AddImage(bulletImage);

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph = new Paragraph { Text = "Welcome to Aspose.Slides" };
paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
paragraph.ParagraphFormat.Bullet.Picture.Image = presentationImage;
paragraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(paragraph);

presentation.Save("picture_bullet.pptx", SaveFormat.Pptx);
presentation.Save("picture_bullet.ppt", SaveFormat.Ppt);
```

### **Vytvoření vícestupňového seznamu**

Nastavte [IParagraphFormat.Depth](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/depth/) pro umístění odstavců na různé úrovně seznamu. Horní úroveň má hloubku `0`.

1. Vytvořte [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) a získejte snímek.
2. Přidejte [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/) a vymažte výchozí odstavec z jeho textového rámce.
3. Vytvořte čtyři odstavce a nakonfigurujte jejich symboly odrážek.
4. Nastavte jejich hodnoty [IParagraphFormat.Depth](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/depth/) na `0`, `1`, `2` a `3`.
5. Přidejte odstavce do textového rámce a uložte prezentaci.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "Content" };
firstParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
firstParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.Depth = 0;

var secondParagraph = new Paragraph { Text = "Second level" };
secondParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
secondParagraph.ParagraphFormat.Bullet.Char = '-';
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.Depth = 1;

var thirdParagraph = new Paragraph { Text = "Third level" };
thirdParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
thirdParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
thirdParagraph.ParagraphFormat.Depth = 2;

var fourthParagraph = new Paragraph { Text = "Fourth level" };
fourthParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
fourthParagraph.ParagraphFormat.Bullet.Char = '-';
fourthParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
fourthParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
fourthParagraph.ParagraphFormat.Depth = 3;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);
textFrame.Paragraphs.Add(thirdParagraph);
textFrame.Paragraphs.Add(fourthParagraph);

presentation.Save("multilevel_list.pptx", SaveFormat.Pptx);
```

### **Zahájení číslovaných položek seznamu na vlastní hodnoty**

Použijte [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/cs/net/aspose.slides/ibulletformat/numberedbulletstartwith/) pro nastavení počátečního čísla zobrazovaného pro číslovaný odstavec.

1. Vytvořte [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) a přidejte [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/) na snímek.
2. Vymažte výchozí odstavec z textového rámce tvaru.
3. Vytvořte tři číslované odstavce.
4. Nastavte [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/cs/net/aspose.slides/ibulletformat/numberedbulletstartwith/) na `2`, `3` a `7` pro příslušné odstavce.
5. Přidejte odstavce do textového rámce a uložte prezentaci.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "Start at 2" };
firstParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
firstParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 2;
textFrame.Paragraphs.Add(firstParagraph);

var secondParagraph = new Paragraph { Text = "Start at 3" };
secondParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
secondParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 3;
textFrame.Paragraphs.Add(secondParagraph);

var thirdParagraph = new Paragraph { Text = "Start at 7" };
thirdParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
thirdParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 7;
textFrame.Paragraphs.Add(thirdParagraph);

presentation.Save("custom_numbered_list.pptx", SaveFormat.Pptx);
```

## **Řízení rozvržení odstavce a koncových vlastností**

### **Nastavení odsazení první řádky**

Použijte vlastnost [IParagraphFormat.Indent](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/indent/) pro řízení odsazení první řádky odstavce. Tato vlastnost posouvá pouze první řádek vzhledem k levému okraji odstavce. Kladná hodnota posune první řádek doprava, zatímco zbývající řádky zůstávají zarovnané k tělu odstavce.

Použijte [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/marginleft/) pokud potřebujete posunout celý odstavec. Použijte [IParagraphFormat.Indent](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/indent/) pokud chcete posunout pouze první řádek.

Níže uvedený příklad vytvoří několik odstavců a aplikuje různé hodnoty [IParagraphFormat.Indent](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/indent/) pro demonstraci, jak odsazení první řádky ovlivňuje rozvržení odstavce.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).
2. Získejte cílový snímek.
3. Přidejte obdélníkový [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/) na snímek.
4. Získejte [ITextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/) tvaru a odstraňte výchozí odstavec.
5. Vytvořte několik odstavců a nastavte pro ně různé hodnoty [Indent](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/indent/).
6. Přidejte odstavce do textového rámce.
7. Uložte upravenou prezentaci.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "No first-line indent. Wrapped lines start at the same position as the first line." };
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.MarginLeft = 20;
firstParagraph.ParagraphFormat.Indent = 0;

var secondParagraph = new Paragraph { Text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.MarginLeft = 20;
secondParagraph.ParagraphFormat.Indent = 20;

var thirdParagraph = new Paragraph { Text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see." };
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
thirdParagraph.ParagraphFormat.MarginLeft = 20;
thirdParagraph.ParagraphFormat.Indent = 40;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);
textFrame.Paragraphs.Add(thirdParagraph);

presentation.Save("paragraph_indent.pptx", SaveFormat.Pptx);
```

Výsledek:

![Odsazení první řádky odstavců](first_line_indent.png)

### **Nastavení zavěšeného odsazení**

Zavěšené odsazení je rozvržení odstavce, ve kterém první řádek začíná vlevo od zbývajících řádků. V Aspose.Slides vytvoříte tento efekt pomocí vlastnosti [IParagraphFormat.Indent](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/indent/). Nastavte `Indent` na zápornou hodnotu pro posunutí první řádky doleva vzhledem k tělu odstavce.

V praxi [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/marginleft/) určuje levou pozici těla odstavce a [IParagraphFormat.Indent](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/indent/) určuje pozici první řádky vzhledem k tomuto okraji. Pro vytvoření zavěšeného odsazení nastavte kladnou hodnotu `MarginLeft` a zápornou hodnotu `Indent`.

Toto formátování je užitečné pro bibliografie, reference, glosáře a další odstavce, kde musí být zalomené řádky zarovnány pod tělem odstavce, ne pod prvním znakem první řádky.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).
2. Získejte cílový snímek.
3. Přidejte obdélníkový [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/) na snímek.
4. Získejte [ITextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/) tvaru a odstraňte výchozí odstavec.
5. Vytvořte odstavce a nastavte pro každý odstavec kladnou hodnotu [MarginLeft](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/marginleft/).
6. Nastavte zápornou hodnotu [Indent](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/indent/) pro vytvoření efektu zavěšeného odsazení.
7. Přidejte odstavce do textového rámce.
8. Uložte upravenou prezentaci.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body." };
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.MarginLeft = 40;
firstParagraph.ParagraphFormat.Indent = -20;

var secondParagraph = new Paragraph { Text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.MarginLeft = 60;
secondParagraph.ParagraphFormat.Indent = -30;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);

presentation.Save("hanging_indent.pptx", SaveFormat.Pptx);
```

Výsledek:

![Zavěšené odsazení odstavců](hanging_indent.png)

### **Nastavení koncových vlastností odstavce**

Vlastnost [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraph/endparagraphportionformat/) řídí formátování koncového znaku odstavce. Následující příklad přiřadí velikost písma a latinský font koncovému znaku druhého odstavce:

1. Načtěte [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) a získejte snímek.
2. Přidejte [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/) a vymažte jeho výchozí odstavec.
3. Vytvořte dva odstavce a přidejte k nim textové úseky.
4. Vytvořte [PortionFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/portionformat/) pro koncový znak druhého odstavce.
5. Nastavte [IBasePortionFormat.FontHeight](https://reference.aspose.com/slides/cs/net/aspose.slides/ibaseportionformat/fontheight/) a [IBasePortionFormat.LatinFont](https://reference.aspose.com/slides/cs/net/aspose.slides/ibaseportionformat/latinfont/).
6. Přiřaďte formát k [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraph/endparagraphportionformat/) a uložte prezentaci.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Test.pptx");
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph();
firstParagraph.Portions.Add(new Portion("Sample text"));

var secondParagraph = new Paragraph();
secondParagraph.Portions.Add(new Portion("Sample text 2"));

var endParagraphFormat = new PortionFormat();
endParagraphFormat.FontHeight = 48;
endParagraphFormat.LatinFont = new FontData("Times New Roman");
secondParagraph.EndParagraphPortionFormat = endParagraphFormat;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);

presentation.Save("end_paragraph_format.pptx", SaveFormat.Pptx);
```

## **Import a export obsahu odstavců**

### **Import HTML textu do odstavců**

Použijte [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/cs/net/aspose.slides/paragraphcollection/addfromhtml/) pro konverzi HTML značek na odstavce a úseky v textovém rámci.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
2. Získejte snímek a přidejte [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/).
3. Získejte [ITextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/) tvaru a vymažte výchozí odstavec.
4. Načtěte zdrojový HTML soubor.
5. Předávejte HTML řetězec metodě [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/cs/net/aspose.slides/paragraphcollection/addfromhtml/).
6. Uložte upravenou prezentaci.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shapeWidth = presentation.SlideSize.Size.Width - 20;
var shapeHeight = presentation.SlideSize.Size.Height - 20;
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
shape.FillFormat.FillType = FillType.NoFill;
shape.TextFrame.Paragraphs.Clear();

using var reader = new StreamReader("file.html");
var html = reader.ReadToEnd();
shape.TextFrame.Paragraphs.AddFromHtml(html);

presentation.Save("html_text.pptx", SaveFormat.Pptx);
```

### **Export textu odstavce do HTML**

Použijte [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/cs/net/aspose.slides/paragraphcollection/exporttohtml/) pro export vybraného rozsahu odstavců jako HTML.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) a načtěte požadovanou prezentaci.
2. Získejte snímek a najděte [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/), který obsahuje text.
3. Získejte [ITextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/) tvaru.
4. Zavolejte [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/cs/net/aspose.slides/paragraphcollection/exporttohtml/) s počátečním indexem odstavce a počtem odstavců k exportu.
5. Zapište vrácený HTML řetězec do souboru.

```csharp
using System;
using System.IO;
using System.Text;
using Aspose.Slides;

using var presentation = new Presentation("ExportingHTMLText.pptx");
var shape = presentation.Slides[0].Shapes[0];

if (shape is IAutoShape textShape && textShape.TextFrame != null)
{
    var paragraphs = textShape.TextFrame.Paragraphs;
    var html = paragraphs.ExportToHtml(0, paragraphs.Count, null);
    using var writer = new StreamWriter("paragraphs.html", false, Encoding.UTF8);
    writer.Write(html);
}
else
{
    Console.WriteLine("The first shape is not a text shape.");
}
```

### **Vykreslení odstavce jako obrázku**

[IParagraph.GetImage](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraph/getimage/) vykreslí jednotlivý odstavec přímo a vrátí [IImage](https://reference.aspose.com/slides/cs/net/aspose.slides/iimage/). Výsledek můžete uložit do souboru nebo streamu pomocí [IImage.Save](https://reference.aspose.com/slides/cs/net/aspose.slides/iimage/save/). Není třeba vykreslovat celý tvar nebo ručně ořezávat bitmapu.

[IParagraph.GetImage](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraph/getimage/) může vrátit `null`, pokud odstavec nelze nalézt v nadřazené kolekci, nemá platné vykreslovací ohraničení nebo jej nelze vykreslit. Výsledek před uložením zkontrolujte a po použití uvolněte vrácený obrázek.

#### **Vykreslení odstavce ve výchozím měřítku**

Předpokládejme, že máme soubor prezentace s názvem sample.pptx s jedním snímkem, kde je první tvar textové pole obsahující tři odstavce.

![Textové pole se třemi odstavci](paragraph_to_image_input.png)

Následující příklad vykreslí druhý odstavec v běžném textovém tvaru ve výchozím měřítku a uloží získaný obrázek ve formátu PNG. Deklarace `using` zajistí správné uvolnění obrázku.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var shape = presentation.Slides[0].Shapes[0];
if (shape is IAutoShape textShape && 
    textShape.TextFrame != null && 
    textShape.TextFrame.Paragraphs.Count > 1)
{
    var paragraph = textShape.TextFrame.Paragraphs[1];
    using var paragraphImage = paragraph.GetImage();

    if (paragraphImage != null)
    {
        paragraphImage.Save("paragraph.png", ImageFormat.Png);
    }
    else
    {
        Console.WriteLine("The paragraph could not be rendered.");
    }
}
else
{
    Console.WriteLine("The expected text shape or paragraph was not found.");
}
```

Výsledek:

![Obrázek odstavce](paragraph_to_image_output.png)

#### **Vykreslení odstavce v buňce tabulky se škálováním**

Použijte přetížení [IParagraph.GetImage](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraph/getimage/), které přijímá parametry `float scaleX` a `float scaleY` pro nastavení horizontálního a vertikálního měřítka. Následující příklad vytvoří tabulku, vykreslí odstavec v její první buňce dvojnásobně ve výchozí šířce a výšce a uloží výsledek jako PNG obrázek.

```csharp
using System;
using Aspose.Slides;

var scaleX = 2f;
var scaleY = 2f;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var table = slide.Shapes.AddTable(50, 50, new[] { 300d }, new[] { 80d });
var paragraph = table[0, 0].TextFrame.Paragraphs[0];
paragraph.Text = "Text in a table cell";

using var paragraphImage = paragraph.GetImage(scaleX, scaleY);
if (paragraphImage != null)
{
    paragraphImage.Save("table_paragraph.png", ImageFormat.Png);
}
else
{
    Console.WriteLine("The paragraph could not be rendered.");
}
```

Faktor měřítka `1` zachová výchozí velikost pixelu v dané ose. Například `2` pro oba faktory vytvoří obrázek, jehož šířka i výška jsou přibližně dvojnásobkem výchozích rozměrů, což vede ke čtyřnásobnému počtu pixelů. Větší faktory obecně poskytují ostřejší text pro zvětšení nebo výstup ve vysokém rozlišení, ale také zvyšují použití paměti a velikost souboru. Faktory pod `1` vytvářejí menší obrázky s menšími detaily. Použijte stejné faktory pro zachování poměru stran odstavce; různé horizontální a vertikální faktory roztažením ovlivní výstup nezávisle.

Vykreslení celého tvaru pomocí [IShape.GetImage](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/getimage/) zůstává užitečné, když výstup musí zahrnovat výplň, okraj nebo další vizuální kontext tvaru. Pro obrázek jen s odstavcem použijte [IParagraph.GetImage](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraph/getimage/).

## **Časté dotazy**

**Mohu úplně zakázat zalamování řádků uvnitř textového rámce?**

Ano. Nastavte [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframeformat/wraptext/) na zakázání zalamování, aby řádky nebyly děleny na okrajích textového rámce.

**Jak mohu získat přesné ohraničení konkrétního odstavce na snímku?**

Použijte [IParagraph.GetRect](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraph/getrect/) k získání ohraničujícího obdélníku odstavce. [IPortion.GetRect](https://reference.aspose.com/slides/cs/net/aspose.slides/iportion/getrect/) poskytuje ohraničení jednotlivého úseku.

**Kde se řídí zarovnání odstavce (levé, pravé, středové nebo zarovnané do bloku)?**

[IParagraphFormat.Alignment](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/alignment/) je nastavení na úrovni odstavce a platí pro celý odstavec bez ohledu na formátování jednotlivých úseků.

**Mohu nastavit jazyk kontroly pravopisu pro část odstavce?**

Ano. Nastavte [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/cs/net/aspose.slides/ibaseportionformat/languageid/) pro jednotlivé úseky, takže jeden odstavec může obsahovat text v několika jazycích.