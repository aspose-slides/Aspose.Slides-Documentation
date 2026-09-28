---
title: Spravovat odstavce textu PowerPointu v .NET
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
- odstavec na obrázek
- text na obrázek
- exportovat odstavec
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Zjistěte, jak vytvářet a formátovat odstavce, úseky, odrážky, číslované seznamy, odsazení, HTML obsah a obrázky odstavců pomocí Aspose.Slides pro .NET."
---
## **Přehled**

Aspose.Slides for .NET představuje text jako hierarchii textových rámců, odstavců a úseků:

* [ITextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/) představuje kontejner textu ve tvaru a poskytuje přístup k jeho kolekci odstavců.
* [IParagraph](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraph/) představuje jeden odstavec v textovém rámci a poskytuje přístup k jeho úsekům a formátování na úrovni odstavce.
* [IPortion](https://reference.aspose.com/slides/cs/net/aspose.slides/iportion/) představuje úsek textu v odstavci. Každý úsek může mít vlastní text a formátování na úrovni znaků.

Proto může odstavec obsahovat text s různými fonty, barvami, velikostmi a dalšími formátováními pomocí více úseků.

## **Vytváření a formátování odstavců**

### **Vytvoření odstavců s více úseky**

Následující kroky vytvoří textový rámec se třemi odstavci, z nichž každý obsahuje tři úseky:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
2. Získejte odkaz na požadovaný snímek pomocí jeho indexu.
3. Přidejte k snímku obdélníkový [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/).
4. Získejte [ITextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/) tvaru.
5. Použijte výchozí odstavec a přidejte dva další objekty [IParagraph](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraph/) do textového rámce.
6. Přidejte dostatek objektů [IPortion](https://reference.aspose.com/slides/cs/net/aspose.slides/iportion/) tak, aby každý odstavec obsahoval tři úseky. Výchozí odstavec již obsahuje jeden prázdný úsek.
7. Nastavte text pro každý úsek.
8. Aplikujte formátování na úrovni znaků prostřednictvím [IPortion.PortionFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/iportion/portionformat/).
9. Uložte upravenou prezentaci.

Tento příklad v C# implementuje kroky:

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

## **Vytváření odrážkových a číslovaných seznamů**

### **Vytvoření odrážkového nebo číslovaného seznamu**

Odrážky a číslování usnadňují přehled souvisejících položek. V Aspose.Slides jsou nastavení seznamu definována pomocí [IBulletFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/ibulletformat/).

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
2. Získejte odkaz na požadovaný snímek pomocí jeho indexu.
3. Přidejte k snímku [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/).
4. Získejte [ITextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/).
5. Odstraňte výchozí odstavec z textového rámce.
6. Vytvořte [Paragraph](https://reference.aspose.com/slides/cs/net/aspose.slides/paragraph/) pro symbolickou odrážku.
7. Nastavte [IBulletFormat.Type](https://reference.aspose.com/slides/cs/net/aspose.slides/ibulletformat/type/) na [BulletType.Symbol](https://reference.aspose.com/slides/cs/net/aspose.slides/bullettype/) a určete znak odrážky.
8. Nastavte text odstavce, odsazení, barvu odrážky a výšku odrážky.
9. Přidejte odstavec do textového rámce.
10. Vytvořte druhý odstavec a nastavte [IBulletFormat.Type](https://reference.aspose.com/slides/cs/net/aspose.slides/ibulletformat/type/) na [BulletType.Numbered](https://reference.aspose.com/slides/cs/net/aspose.slides/bullettype/).
11. Nastavte styl číslované odrážky a přidejte odstavec do textového rámce.
12. Uložte prezentaci.

Tento příklad v C# vytvoří symbolickou odrážku a číslovanou odrážku:

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

Obrázkové odrážky vám umožňují použít vlastní obrázek místo symbolu nebo čísla.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
2. Získejte odkaz na požadovaný snímek pomocí jeho indexu.
3. Přidejte [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/) a získejte jeho [ITextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/).
4. Odstraňte výchozí odstavec z textového rámce.
5. Načtěte obrázek odrážky a přidejte jej do kolekce obrázků prezentace jako [IPPImage](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage/).
6. Vytvořte [Paragraph](https://reference.aspose.com/slides/cs/net/aspose.slides/paragraph/) a nastavte jeho text.
7. Nastavte [IBulletFormat.Type](https://reference.aspose.com/slides/cs/net/aspose.slides/ibulletformat/type/) na [BulletType.Picture](https://reference.aspose.com/slides/cs/net/aspose.slides/bullettype/).
8. Přiřaďte obrázek pomocí [IBulletFormat.Picture](https://reference.aspose.com/slides/cs/net/aspose.slides/ibulletformat/picture/) a nastavte výšku odrážky.
9. Přidejte odstavec do textového rámce.
10. Uložte upravenou prezentaci.

Tento příklad v C# vytvoří obrázkovou odrážku:

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

### **Vytvoření víceúrovňového seznamu**

Nastavte [IParagraphFormat.Depth](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/depth/) pro umístění odstavců na různé úrovně seznamu. Nejvyšší úroveň má hloubku `0`.

1. Vytvořte [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) a přistupte ke snímku.
2. Přidejte [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/) a vymažte výchozí odstavec z jeho textového rámce.
3. Vytvořte čtyři odstavce a nakonfigurujte jejich symboly odrážek.
4. Nastavte jejich hodnoty [IParagraphFormat.Depth](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/depth/) na `0`, `1`, `2` a `3`.
5. Přidejte odstavce do textového rámce a uložte prezentaci.

Tento příklad v C# vytvoří čtyřúrovňový odrážkový seznam:

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

### **Nastavení počátečních hodnot číslovaného seznamu**

Použijte [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/cs/net/aspose.slides/ibulletformat/numberedbulletstartwith/) pro nastavení počátečního čísla zobrazovaného u číslovaného odstavce.

1. Vytvořte [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) a přidejte [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/) na snímek.
2. Vymažte výchozí odstavec z textového rámce tvaru.
3. Vytvořte tři číslované odstavce.
4. Nastavte [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/cs/net/aspose.slides/ibulletformat/numberedbulletstartwith/) na `2`, `3` a `7` pro příslušné odstavce.
5. Přidejte odstavce do textového rámce a uložte prezentaci.

Tento příklad v C# přiřadí vlastní počáteční číslo každému odstavci:

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

Použijte vlastnost [IParagraphFormat.Indent](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/indent/) k řízení odsazení první řádky odstavce. Tato vlastnost posouvá pouze první řádek vzhledem k levému okraji odstavce. Kladná hodnota posune první řádek doprava, zatímco ostatní řádky zůstávají zarovnány k tělu odstavce.

Použijte [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/marginleft/) když potřebujete posunout celý odstavec. Použijte [IParagraphFormat.Indent](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/indent/) když chcete posunout pouze první řádek.

Níže uvedený příklad vytvoří několik odstavců a použije různé hodnoty [IParagraphFormat.Indent](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/indent/) k ukázání, jak odsazení první řádky ovlivňuje rozvržení odstavce.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).
2. Získejte cílový snímek.
3. Přidejte k snímku obdélníkový [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/).
4. Získejte [ITextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/) tvaru a odstraňte výchozí odstavec.
5. Vytvořte několik odstavců a nastavte pro ně různé hodnoty [Indent](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/indent/).
6. Přidejte odstavce do textového rámce.
7. Uložte upravenou prezentaci.

Tento kód ukazuje, jak nastavit odsazení odstavce:

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

Zavěšené odsazení je rozvržení odstavce, ve kterém první řádek začíná vlevo od zbytku řádků. V Aspose.Slides tento efekt vytvoříte pomocí vlastnosti [IParagraphFormat.Indent](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/indent). Nastavte `Indent` na zápornou hodnotu, aby se první řádek posunul vlevo vzhledem k tělu odstavce.

V praxi [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/marginleft) určuje levou pozici těla odstavce a [IParagraphFormat.Indent](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/indent) určuje pozici první řádky vzhledem k tomuto okraji. Pro vytvoření zavěšeného odsazení nastavte kladnou hodnotu `MarginLeft` a zápornou hodnotu `Indent`.

Toto formátování je užitečné pro bibliografie, odkazy, glosářové položky a další odstavce, kde zabalené řádky musí být zarovnány pod tělo odstavce, nikoli pod první znak první řádky.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).
2. Získejte cílový snímek.
3. Přidejte k snímku obdélníkový [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/).
4. Získejte [ITextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/) tvaru a odstraňte výchozí odstavec.
5. Vytvořte odstavce a nastavte pro každý odstavec kladnou hodnotu [MarginLeft](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/marginleft/).
6. Nastavte zápornou hodnotu [Indent](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/indent/) k vytvoření efektu zavěšeného odsazení.
7. Přidejte odstavce do textového rámce.
8. Uložte upravenou prezentaci.

Tento kód ukazuje, jak nastavit zavěšené odsazení pro odstavec:

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

Vlastnost [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraph/endparagraphportionformat/) řídí formátování koncového značky odstavce. Následující příklad přiřadí velikost písma a latinské písmo ke koncové značce druhého odstavce:

1. Načtěte [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) a přistupte ke snímku.
2. Přidejte [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/) a vymažte jeho výchozí odstavec.
3. Vytvořte dva odstavce a přidejte do nich textové úseky.
4. Vytvořte [PortionFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/portionformat/) pro koncovou značku druhého odstavce.
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

## **Počítání vykreslených řádků**

Pro pravidla odstavců, která ovlivňují automatické zalamování a interpunkci na konci řádků, viz [Control Line Breaking](/slides/cs/net/text-formatting/#control-line-breaking) a [Control Hanging Punctuation](/slides/cs/net/text-formatting/#control-hanging-punctuation).

Použijte [IParagraph.GetLinesCount](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraph/getlinescount/) k počítání řádků obsazených odstavcem po rozvržení textu, včetně automatického zalamování. To je užitečné při kontrole délky textu a rozvržení v šablonách prezentací.

Odstavec je jednou položkou v [ITextFrame.Paragraphs](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/paragraphs/) a může obsazovat několik vykreslených řádků. Výslovný konec řádku uvnitř odstavce vynutí nový řádek, aniž by vytvořil další odstavec. Automatické zalamování vytváří řádky podle dostupné šířky, aniž by vkládalo výslovné konce řádků do textu. Počítání odstavců nebo znaků konce řádku tedy nedává počet vykreslených řádků.

Následující příklad vytvoří textový tvar, spočítá jeho řádky, zúží tvar a následně nahradí text kratším řetězcem. Zalamování je povoleno a automatické přizpůsobení je zakázáno, takže šířka tvaru řídí zalamování, aniž by se text automaticky zmenšoval nebo měnil velikost tvaru. Rozměry tvaru jsou v bodech. Nakonec příklad přidá další odstavec a sečte počty řádků napříč textovým rámcem.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 200);
var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.WrapText = NullableBool.True;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;

var paragraph = textFrame.Paragraphs[0];
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 20;
paragraph.Text = "This text demonstrates how automatic wrapping changes the number of rendered lines.";
Console.WriteLine($"Original width: {paragraph.GetLinesCount()}");

shape.Width = 150;
Console.WriteLine($"Narrower shape: {paragraph.GetLinesCount()}");

paragraph.Text = "Short text.";
Console.WriteLine($"Shorter text: {paragraph.GetLinesCount()}");

var secondParagraph = new Paragraph { Text = "Another paragraph." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 20;
textFrame.Paragraphs.Add(secondParagraph);

var totalLineCount = 0;
foreach (var currentParagraph in textFrame.Paragraphs)
{
    totalLineCount += currentParagraph.GetLinesCount();
}
Console.WriteLine($"Total lines in the text frame: {totalLineCount}");
```

S tímto textem a těmito rozměry zúžení tvaru zvyšuje počet řádků, zatímco nahrazení textu krátkým řetězcem jej snižuje. Přesné počty se mohou lišit podle dostupnosti a substituce fontů, velikosti písma, okrajů, odsazení, zalamování a nastavení automatického přizpůsobení. Používejte fonty a nastavení rozvržení určené pro cílové prostředí při kontrole šablony.

Samotný počet řádků neurčuje, zda text přeplňuje svůj kontejner. Důležité jsou také dostupná výška, výšky řádků, mezery mezi odstavci a řádky a chování automatického přizpůsobení; i jediný řádek může překročit dostupnou šířku, pokud je zalamování zakázáno.

## **Import a export obsahu odstavců**

### **Import HTML textu do odstavců**

Použijte [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/cs/net/aspose.slides/paragraphcollection/addfromhtml/) k převodu HTML značek na odstavce a úseky v textovém rámci.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
2. Získejte snímek a přidejte [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/).
3. Získejte [ITextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/) tvaru a odstraňte výchozí odstavec.
4. Přečtěte zdrojový HTML soubor.
5. Předávejte HTML řetězec metodě [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/cs/net/aspose.slides/paragraphcollection/addfromhtml/).
6. Uložte upravenou prezentaci.

Tento příklad v C# importuje HTML do textového rámce:

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

Použijte [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/cs/net/aspose.slides/paragraphcollection/exporttohtml/) k exportu vybraného rozsahu odstavců jako HTML.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) a načtěte požadovanou prezentaci.
2. Získejte snímek a najděte [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape), který obsahuje text.
3. Získejte [ITextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/).
4. Zavolejte [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/cs/net/aspose.slides/paragraphcollection/exporttohtml/) s indexem počátečního odstavce a počtem odstavců k exportu.
5. Zapište vrácený HTML řetězec do souboru.

Tento příklad v C# exportuje všechny odstavce z prvního textového tvaru:

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

[IParagraph.GetImage](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraph/getimage/) vykreslí jednotlivý odstavec přímo a vrátí [IImage](https://reference.aspose.com/slides/cs/net/aspose.slides/iimage/). Uložte výsledek do souboru nebo proudu pomocí [IImage.Save](https://reference.aspose.com/slides/cs/net/aspose.slides/iimage/save/). Není nutné vykreslovat obsahující tvar ani ručně ořezávat bitmapu.

[IParagraph.GetImage](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraph/getimage/) může vrátit `null`, pokud odstavec nelze najít v nadřazené kolekci, nemá platné vykreslovací ohraničení nebo jej nelze vykreslit. Zkontrolujte výsledek před uložením a po použití uvolněte vrácený obrázek.

#### **Vykreslení odstavce ve výchozím měřítku**

Předpokládejme, že máme soubor prezentace nazvaný sample.pptx s jedním snímkem, kde je první tvar textové pole obsahující tři odstavce.

![Textové pole se třemi odstavci](paragraph_to_image_input.png)

Následující příklad vykreslí druhý odstavec v běžném textovém tvaru ve výchozím měřítku a uloží vrácený obrázek ve formátu PNG. Deklarace `using` zajišťuje, že obrázek bude řádně uvolněn.

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

Použijte přetížení [IParagraph.GetImage](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraph/getimage/), které přijímá parametry `float scaleX` a `float scaleY` pro nastavení horizontálních a vertikálních faktorů měřítka. Následující příklad vytvoří tabulku, vykreslí odstavec v její první buňce dvakrát ve výchozí šířce a výšce a výsledek uloží jako PNG obrázek.

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

Faktor měřítka `1` zachová danou osu v její výchozí velikosti v pixelech. Například `2` pro oba faktory vytvoří obrázek, jehož šířka a výška jsou přibližně dvojnásobky výchozích rozměrů, což vede ke čtyřnásobnému počtu pixelů. Větší faktory obecně poskytují ostřejší text pro přiblížení nebo výstup ve vysokém rozlišení, ale také zvyšují paměťovou náročnost a velikost souboru. Faktory pod `1` vytvářejí menší obrázky s menšími detaily. Použijte stejné faktory pro zachování poměru stran odstavce; odlišné horizontální a vertikální faktory roztačí výstup nezávisle.

Vykreslení celého tvaru pomocí [IShape.GetImage](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/getimage/) zůstává užitečné, když výstup musí zahrnovat výplň, ohraničení nebo další vizuální kontext tvaru. Pro obrázek obsahující jen odstavec použijte [IParagraph.GetImage](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraph/getimage/).

## **Často kladené otázky**

**Mohu zcela zakázat zalamování řádků uvnitř textového rámce?**

Ano. Nastavte [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframeformat/wraptext/) a zakážete zalamování, takže řádky se nebudou lámat na okrajích textového rámce.

**Jak mohu získat přesné hranice konkrétního odstavce na snímku?**

Použijte [IParagraph.GetRect](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraph/getrect/) k získání ohraničujícího obdélníku odstavce. [IPortion.GetRect](https://reference.aspose.com/slides/cs/net/aspose.slides/iportion/getrect/) poskytuje hranice jednotlivého úseku.

**Kde se řídí zarovnání odstavce (vlevo, vpravo, na střed nebo do bloku)?**

[IParagraphFormat.Alignment](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/alignment/) je nastavení na úrovni odstavce a vztahuje se na celý odstavec bez ohledu na formátování jednotlivých úseků.

**Mohu nastavit jazyk kontroly pravopisu pro část odstavce?**

Ano. Nastavte [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/cs/net/aspose.slides/ibaseportionformat/languageid/) pro jednotlivé úseky, takže jeden odstavec může obsahovat text v několika jazycích.