---
title: Správa textových odstavců PowerPointu v .NET
linktitle: Správa odstavce
type: docs
weight: 40
url: /cs/net/manage-paragraph/
keywords:
- přidat text
- přidat odstavec
- spravovat text
- spravovat odstavec
- spravovat odrážku
- odsazení odstavce
- závěsné odsazení
- odrážka odstavce
- číslovaný seznam
- seznam s odrážkami
- vlastnosti odstavce
- import HTML
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
description: "Mistrovské formátování odstavců s Aspose.Slides pro .NET - optimalizujte zarovnání, rozestupy a styl v prezentacích PPT, PPTX a ODP v C#."
---
## **Úvod**

Aspose.Slides poskytuje všechny rozhraní a třídy, které potřebujete pro práci s texty, odstavci a částmi v PowerPointu v jazyce C#.

* Aspose.Slides poskytuje rozhraní [ITextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/), které vám umožní přidávat objekty představující odstavec. Objekt `ITextFame` může mít jeden nebo více odstavců (každý odstavec je vytvořen pomocí konce řádku).
* Aspose.Slides poskytuje rozhraní [IParagraph](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraph/), které vám umožní přidávat objekty představující části. Objekt `IParagraph` může mít jednu nebo více částí (kolekci objektů iPortions).
* Aspose.Slides poskytuje rozhraní [IPortion](https://reference.aspose.com/slides/cs/net/aspose.slides/iportion/), které vám umožní přidávat objekty představující texty a jejich formátovací vlastnosti. 

Objekt `IParagraph` je schopen zpracovávat texty s různými formátovacími vlastnostmi prostřednictvím svých podkladových objektů `IPortion`.

## **Přidání více odstavců obsahujících více částí**

Tyto kroky ukazují, jak přidat textový rámec obsahující 3 odstavce a každý odstavec obsahující 3 části:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) .
2. Získejte odkaz na příslušný snímek pomocí jeho indexu.
3. Přidejte obdélníkový [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/) na snímek.
4. Získejte ITextFrame spojený s [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/) .
5. Vytvořte dva objekty [IParagraph](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraph/) a přidejte je do kolekce `IParagraphs` objektu [ITextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/) .
6. Vytvořte tři objekty [IPortion](https://reference.aspose.com/slides/cs/net/aspose.slides/iportion/) pro každý nový `IParagraph` (dvě částové objekty pro výchozí odstavec) a přidejte každý objekt `IPortion` do kolekce IPortion každého `IParagraph` .
7. Nastavte text pro každou část.
8. Použijte požadované formátovací funkce na každou část pomocí formátovacích vlastností poskytovaných objektem `IPortion` .
9. Uložte upravenou prezentaci.

```c#
// Vytváří instanci třídy Presentation, která reprezentuje soubor PPTX
using (Presentation pres = new Presentation())
{
    // Přistupuje k prvnímu snímku
    ISlide slide = pres.Slides[0];

    // Přidá obdélníkový IAutoShape
    IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // Přistupuje k TextFrame AutoShape
    ITextFrame tf = ashp.TextFrame;

    // Vytváří odstavce a části s různými formáty textu
    IParagraph para0 = tf.Paragraphs[0];
    IPortion port01 = new Portion();
    IPortion port02 = new Portion();
    para0.Portions.Add(port01);
    para0.Portions.Add(port02);

    IParagraph para1 = new Paragraph();
    tf.Paragraphs.Add(para1);
    IPortion port10 = new Portion();
    IPortion port11 = new Portion();
    IPortion port12 = new Portion();
    para1.Portions.Add(port10);
    para1.Portions.Add(port11);
    para1.Portions.Add(port12);

    IParagraph para2 = new Paragraph();
    tf.Paragraphs.Add(para2);
    IPortion port20 = new Portion();
    IPortion port21 = new Portion();
    IPortion port22 = new Portion();
    para2.Portions.Add(port20);
    para2.Portions.Add(port21);
    para2.Portions.Add(port22);

    for (int i = 0; i < 3; i++)
        for (int j = 0; j < 3; j++)
        {
            tf.Paragraphs[i].Portions[j].Text = "Portion0" + j.ToString();
            if (j == 0)
            {
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.FillType = FillType.Solid;
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontBold = NullableBool.True;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontHeight = 15;
            }
            else if (j == 1)
            {
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.FillType = FillType.Solid;
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontItalic = NullableBool.True;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontHeight = 18;
            }
        }
    // Ukládá upravenou prezentaci
    pres.Save("multiParaPort_out.pptx", SaveFormat.Pptx);

}
```

## **Správa odrážek odstavců**

Seznamy s odrážkami vám pomáhají rychle a efektivně organizovat a prezentovat informace. Odstavce s odrážkami jsou vždy snadněji čitelné a pochopitelné.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) .
2. Získejte odkaz na příslušný snímek pomocí jeho indexu.
3. Přidejte [autoshape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/) na vybraný snímek.
4. Získejte [TextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/) autoshape . 
5. Odstraňte výchozí odstavec v `TextFrame` .
6. Vytvořte první instanci odstavce pomocí třídy [Paragraph](https://reference.aspose.com/slides/cs/net/aspose.slides/paragraph/) .
8. Nastavte typ odrážky `Type` pro odstavec na `Symbol` a nastavte znak odrážky.
9. Nastavte `Text` odstavce.
10. Nastavte `Indent` odstavce pro odrážku.
11. Nastavte barvu odrážky.
12. Nastavte výšku odrážky.
13. Přidejte nový odstavec do kolekce odstavců `TextFrame` .
14. Přidejte druhý odstavec a opakujte proces uvedený v krocích 7 až 13.
15. Uložte prezentaci.

```c#
// Vytváří instanci třídy Presentation, která reprezentuje soubor PPTX
using (Presentation pres = new Presentation())
{

    // Přistupuje k prvnímu snímku
    ISlide slide = pres.Slides[0];


    // Přidá a přistupuje k Autoshape
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Přistupuje k textovému rámci autoshape
    ITextFrame txtFrm = aShp.TextFrame;

    // Odstraňuje výchozí odstavec
    txtFrm.Paragraphs.RemoveAt(0);

    // Vytváří odstavec
    Paragraph para = new Paragraph();

    // Nastavuje styl odrážky odstavce a symbol
    para.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);

    // Nastavuje text odstavce
    para.Text = "Welcome to Aspose.Slides";

    // Nastavuje odsazení odrážky
    para.ParagraphFormat.Indent = 25;

    // Nastavuje barvu odrážky
    para.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // nastavte IsBulletHardColor na true, aby se použila vlastní barva odrážky

    // Nastavuje výšku odrážky
    para.ParagraphFormat.Bullet.Height = 100;

    // Přidává odstavec do textového rámce
    txtFrm.Paragraphs.Add(para);

    // Vytváří druhý odstavec
    Paragraph para2 = new Paragraph();

    // Nastavuje typ a styl odrážky odstavce
    para2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    para2.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;

    // Přidává text odstavce
    para2.Text = "This is numbered bullet";

    // Nastavuje odsazení odrážky
    para2.ParagraphFormat.Indent = 25;

    para2.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para2.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para2.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // nastavte IsBulletHardColor na true, aby se použila vlastní barva odrážky

    // Nastavuje výšku odrážky
    para2.ParagraphFormat.Bullet.Height = 100;

    // Přidává odstavec do textového rámce
    txtFrm.Paragraphs.Add(para2);


    // Ukládá upravenou prezentaci
    pres.Save("Bullet_out.pptx", SaveFormat.Pptx);

}
```

## **Správa obrázkových odrážek**

Seznamy s odrážkami vám pomáhají rychle a efektivně organizovat a prezentovat informace. Obrázkové odstavce jsou snadno čitelné a srozumitelné.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) .
2. Získejte odkaz na příslušný snímek pomocí jeho indexu.
3. Přidejte [autoshape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/) na snímek.
4. Získejte [TextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/textframe/) autoshape .
5. Odstraňte výchozí odstavec v `TextFrame` .
6. Vytvořte první instanci odstavce pomocí třídy [Paragraph](https://reference.aspose.com/slides/cs/net/aspose.slides/paragraph/) .
7. Načtěte obrázek v [IPPImage](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage/) .
8. Nastavte typ odrážky na [Picture](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage/) a nastavte obrázek.
9. Nastavte `Text` odstavce.
10. Nastavte `Indent` odstavce pro odrážku.
11. Nastavte barvu odrážky.
12. Nastavte výšku odrážky.
13. Přidejte nový odstavec do kolekce odstavců `TextFrame` .
14. Přidejte druhý odstavec a opakujte proces uvedený v předchozích krocích.
15. Uložte upravenou prezentaci.

```c#
// Vytváří instanci třídy Presentation, která reprezentuje soubor PPTX
Presentation presentation = new Presentation();

// Přistupuje k prvnímu snímku
ISlide slide = presentation.Slides[0];

// Vytváří obrázek pro odrážky
IImage image = Images.FromFile("bullets.png");
IPPImage ippxImage = presentation.Images.AddImage(image);
image.Dispose();

// Přidá a přistupuje k Autoshape
IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

// Přistupuje k textovému rámci autoshape
ITextFrame textFrame = autoShape.TextFrame;

// Odstraňuje výchozí odstavec
textFrame.Paragraphs.RemoveAt(0);

// Vytváří nový odstavec
Paragraph paragraph = new Paragraph();
paragraph.Text = "Welcome to Aspose.Slides";

// Nastavuje styl odrážky odstavce a obrázek
paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
paragraph.ParagraphFormat.Bullet.Picture.Image = ippxImage;

// Nastavuje výšku odrážky
paragraph.ParagraphFormat.Bullet.Height = 100;

// Přidává odstavec do textového rámce
textFrame.Paragraphs.Add(paragraph);

// Ukládá prezentaci jako soubor PPTX
presentation.Save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

// Ukládá prezentaci jako soubor PPT
presentation.Save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
```

## **Správa víceúrovňových odrážek**

Seznamy s odrážkami vám pomáhají rychle a efektivně organizovat a prezentovat informace. Víceúrovňové odrážky jsou snadno čitelné a srozumitelné.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation)class .
2. Získejte odkaz na příslušný snímek pomocí jeho indexu.
3. Přidejte [autoshape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/) v novém snímku.
4. Získejte [TextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/textframe/) autoshape .
5. Odstraňte výchozí odstavec v `TextFrame` .
6. Vytvořte první instanci odstavce pomocí třídy [Paragraph](https://reference.aspose.com/slides/cs/net/aspose.slides/paragraph/) a nastavte hloubku na 0.
7. Vytvořte druhou instanci odstavce pomocí třídy `Paragraph` a nastavte hloubku na 1.
8. Vytvořte třetí instanci odstavce pomocí třídy `Paragraph` a nastavte hloubku na 2.
9. Vytvořte čtvrtou instanci odstavce pomocí třídy `Paragraph` a nastavte hloubku na 3.
10. Přidejte nové odstavce do kolekce odstavců `TextFrame` .
11. Uložte upravenou prezentaci.

```c#
// Vytváří instanci třídy Presentation, která reprezentuje soubor PPTX
using (Presentation pres = new Presentation())
{

    // Přistupuje k prvnímu snímku
    ISlide slide = pres.Slides[0];
    
    // Přidá a přistupuje k Autoshape
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Přistupuje k textovému rámci vytvořeného autoshape
    ITextFrame text = aShp.AddTextFrame("");
    
    // Vymaže výchozí odstavec
    text.Paragraphs.Clear();

    // Přidává první odstavec
    IParagraph para1 = new Paragraph();
    para1.Text = "Content";
    para1.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para1.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Nastavuje úroveň odrážky
    para1.ParagraphFormat.Depth = 0;

    // Přidává druhý odstavec
    IParagraph para2 = new Paragraph();
    para2.Text = "Second Level";
    para2.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para2.ParagraphFormat.Bullet.Char = '-';
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Nastavuje úroveň odrážky
    para2.ParagraphFormat.Depth = 1;

    // Přidává třetí odstavec
    IParagraph para3 = new Paragraph();
    para3.Text = "Third Level";
    para3.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Nastavuje úroveň odrážky
    para3.ParagraphFormat.Depth = 2;

    // Přidává čtvrtý odstavec
    IParagraph para4 = new Paragraph();
    para4.Text = "Fourth Level";
    para4.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para4.ParagraphFormat.Bullet.Char = '-';
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Nastavuje úroveň odrážky
    para4.ParagraphFormat.Depth = 3;

    // Přidává odstavce do kolekce
    text.Paragraphs.Add(para1);
    text.Paragraphs.Add(para2);
    text.Paragraphs.Add(para3);
    text.Paragraphs.Add(para4);

    // Ukládá prezentaci jako soubor PPTX
    pres.Save("MultilevelBullet.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Správa odstavce s vlastním číslovaným seznamem**

Rozhraní [IBulletFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/ibulletformat/) poskytuje vlastnost [NumberedBulletStartWith](https://reference.aspose.com/slides/cs/net/aspose.slides/ibulletformat/numberedbulletstartwith) a další, které umožňují spravovat odstavce s vlastním číslováním nebo formátováním. 

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation)class .
2. Získejte odkaz na snímek obsahující odstavec.
3. Přidejte [autoshape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/) na snímek.
4. Získejte [TextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/textframe/) autoshape .
5. Odstraňte výchozí odstavec v `TextFrame` .
6. Vytvořte první instanci odstavce pomocí třídy [Paragraph](https://reference.aspose.com/slides/cs/net/aspose.slides/paragraph/) a nastavte [NumberedBulletStartWith](https://reference.aspose.com/slides/cs/net/aspose.slides/ibulletformat/numberedbulletstartwith) na 2.
7. Vytvořte druhý odstavec pomocí třídy `Paragraph` a nastavte `NumberedBulletStartWith` na 3.
8. Vytvořte třetí odstavec pomocí třídy `Paragraph` a nastavte `NumberedBulletStartWith` na 7.
9. Přidejte nové odstavce do kolekce odstavců `TextFrame` .
10. Uložte upravenou prezentaci.

```c#
using (var presentation = new Presentation())
{
	var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

	// Přistupuje k textovému rámci vytvořeného autoshape
	ITextFrame textFrame = shape.TextFrame;

	// Odstraňuje výchozí existující odstavec
	textFrame.Paragraphs.RemoveAt(0);

	// První seznam
	var paragraph1 = new Paragraph { Text = "bullet 2" };
	paragraph1.ParagraphFormat.Depth = 4; 
	paragraph1.ParagraphFormat.Bullet.NumberedBulletStartWith = 2;
	paragraph1.ParagraphFormat.Bullet.Type = BulletType.Numbered;
	textFrame.Paragraphs.Add(paragraph1);

	var paragraph2 = new Paragraph { Text = "bullet 3" };
	paragraph2.ParagraphFormat.Depth = 4;
	paragraph2.ParagraphFormat.Bullet.NumberedBulletStartWith = 3; 
	paragraph2.ParagraphFormat.Bullet.Type = BulletType.Numbered;  
	textFrame.Paragraphs.Add(paragraph2);

	
	var paragraph5 = new Paragraph { Text = "bullet 7" };
	paragraph5.ParagraphFormat.Depth = 4;
	paragraph5.ParagraphFormat.Bullet.NumberedBulletStartWith = 7;
	paragraph5.ParagraphFormat.Bullet.Type = BulletType.Numbered;
	textFrame.Paragraphs.Add(paragraph5);

	presentation.Save("SetCustomBulletsNumber-slides.pptx", SaveFormat.Pptx);
}
```

## **Nastavení odsazení první řádky odstavce**

Použijte vlastnost [IParagraphFormat.Indent](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/indent/) k řízení odsazení první řádky odstavce. Tato vlastnost posouvá pouze první řádek vzhledem k levému okraji odstavce. Kladná hodnota posune první řádek doprava, zatímco ostatní řádky zůstávají zarovnané k tělu odstavce.

Použijte [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/marginleft/) pokud potřebujete posunout celý odstavec. Použijte [IParagraphFormat.Indent](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/indent/) když chcete posunout jen první řádek.

Příklad níže vytváří několik odstavců a aplikuje různé hodnoty `Indent`, aby ukázal, jak odsazení první řádky ovlivňuje rozvržení odstavce.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) .
2. Získejte cílový snímek.
3. Přidejte obdélníkový [AutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/autoshape/) na snímek.
4. Přidejte prázdný [TextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/textframe/) do tvaru a odstraňte výchozí odstavec.
5. Vytvořte několik odstavců a nastavte různé hodnoty [Indent](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/indent/) pro ně.
6. Přidejte odstavce do textového rámce.
7. Uložte upravenou prezentaci.

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape rectangleShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.FillFormat.FillType = FillType.NoFill;
    rectangleShape.LineFormat.FillFormat.FillType = FillType.Solid;
    rectangleShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

    ITextFrame textFrame = rectangleShape.AddTextFrame(string.Empty);
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
    textFrame.Paragraphs.RemoveAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    firstParagraph.Text = "No first-line indent. Wrapped lines start at the same position as the first line.";
    firstParagraph.ParagraphFormat.MarginLeft = 20f;
    firstParagraph.ParagraphFormat.Indent = 0f;

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    secondParagraph.Text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.";
    secondParagraph.ParagraphFormat.MarginLeft = 20f;
    secondParagraph.ParagraphFormat.Indent = 20f;

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    thirdParagraph.Text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.";
    thirdParagraph.ParagraphFormat.MarginLeft = 20f;
    thirdParagraph.ParagraphFormat.Indent = 40f;

    textFrame.Paragraphs.Add(firstParagraph);
    textFrame.Paragraphs.Add(secondParagraph);
    textFrame.Paragraphs.Add(thirdParagraph);

    presentation.Save("paragraph_indent.pptx", SaveFormat.Pptx);
}
```

Výsledek:

![Odsazení první řádky odstavců](first_line_indent.png)

## **Nastavení závěsného odsazení odstavce**

Závěsné odsazení je rozvržení odstavce, při kterém první řádek začíná nalevo od zbytku řádků. V Aspose.Slides vytvoříte tento efekt pomocí vlastnosti [IParagraphFormat.Indent](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/indent/). Nastavte `Indent` na zápornou hodnotu, aby se první řádek posunul doleva vzhledem k tělu odstavce.

V praxi [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/marginleft/) určuje levou pozici těla odstavce a [IParagraphFormat.Indent](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/indent/) určuje pozici první řádky vzhledem k tomuto okraji. Pro vytvoření závěsného odsazení nastavte kladnou hodnotu `MarginLeft` a zápornou hodnotu `Indent`.

Toto formátování je užitečné pro bibliografie, odkazy, položky glosáře a další odstavce, kde mají zabalené řádky být zarovnány pod tělo odstavce, nikoli pod první znak první řádky.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) .
2. Získejte cílový snímek.
3. Přidejte obdélníkový [AutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/autoshape/) na snímek.
4. Přidejte prázdný [TextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/textframe/) do tvaru a odstraňte výchozí odstavec.
5. Vytvořte odstavce a nastavte kladnou hodnotu [MarginLeft](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/marginleft/) pro každý odstavec.
6. Nastavte zápornou hodnotu [Indent](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraphformat/indent/) pro vytvoření efektu závěsného odsazení.
7. Přidejte odstavce do textového rámce.
8. Uložte upravenou prezentaci.

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape rectangleShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.FillFormat.FillType = FillType.NoFill;
    rectangleShape.LineFormat.FillFormat.FillType = FillType.Solid;
    rectangleShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

    ITextFrame textFrame = rectangleShape.AddTextFrame(string.Empty);
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
    textFrame.Paragraphs.RemoveAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    firstParagraph.Text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.";
    firstParagraph.ParagraphFormat.MarginLeft = 40f;
    firstParagraph.ParagraphFormat.Indent = -20f;

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    secondParagraph.Text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.";
    secondParagraph.ParagraphFormat.MarginLeft = 60f;
    secondParagraph.ParagraphFormat.Indent = -30f;

    textFrame.Paragraphs.Add(firstParagraph);
    textFrame.Paragraphs.Add(secondParagraph);

    presentation.Save("hanging_indent.pptx", SaveFormat.Pptx);
}
```

Výsledek:

![Závěsné odsazení odstavců](hanging_indent.png)

## **Správa koncových vlastností odstavce**

1. Vytvořte instanci [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) třídy.
1. Získejte odkaz na snímek obsahující odstavec podle jeho pozice.
1. Přidejte obdélníkový [autoshape](https://reference.aspose.com/slides/cs/net/aspose.slides/autoshape/) na snímek.
1. Přidejte [TextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/textframe/) se dvěma odstavci do obdélníku.
1. Nastavte `FontHeight` a typ písma pro odstavce.
1. Nastavte koncové vlastnosti pro odstavce.
1. Zapište upravenou prezentaci jako soubor PPTX.

```c#
using (Presentation pres = new Presentation("Test.pptx"))
{
	IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);

	Paragraph para1 = new Paragraph();
	para1.Portions.Add(new Portion("Sample text"));

	Paragraph para2 = new Paragraph();
	para2.Portions.Add(new Portion("Sample text 2"));
	PortionFormat endParagraphPortionFormat = new PortionFormat();
	endParagraphPortionFormat.FontHeight = 48;
	endParagraphPortionFormat.LatinFont = new FontData("Times New Roman");
	para2.EndParagraphPortionFormat = endParagraphPortionFormat;

	shape.TextFrame.Paragraphs.Add(para1);
	shape.TextFrame.Paragraphs.Add(para2);

	pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Import HTML textu do odstavců**

Aspose.Slides poskytuje rozšířenou podporu pro import HTML textu do odstavců.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) .
2. Získejte odkaz na příslušný snímek pomocí jeho indexu.
3. Přidejte [autoshape](https://reference.aspose.com/slides/cs/net/aspose.slides/autoshape/) na snímek.
4. Přidejte a získejte `autoshape` [ITextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/) .
5. Odstraňte výchozí odstavec v `ITextFrame` .
6. Načtěte zdrojový HTML soubor v TextReader .
7. Vytvořte první instanci odstavce pomocí třídy [Paragraph](https://reference.aspose.com/slides/cs/net/aspose.slides/paragraph/) .
8. Přidejte obsah HTML souboru z načteného TextReaderu do [ParagraphCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/paragraphcollection/) rámce TextFrame .
9. Uložte upravenou prezentaci.

```c#
// Vytváří prázdnou instanci prezentace
using (Presentation pres = new Presentation())
{
    // Získává výchozí první snímek prezentace
    ISlide slide = pres.Slides[0];

    // Přidává AutoShape, který bude obsahovat HTML obsah
    IAutoShape ashape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, pres.SlideSize.Size.Width - 20, pres.SlideSize.Size.Height - 10);

    ashape.FillFormat.FillType = FillType.NoFill;

    // Přidává textový rámec do tvaru
    ashape.AddTextFrame("");

    // Vymaže všechny odstavce v přidaném textovém rámci
    ashape.TextFrame.Paragraphs.Clear();

    // Načte HTML soubor pomocí StreamReaderu
    TextReader tr = new StreamReader("file.html");

    // Přidá text z HTML StreamReaderu do textového rámce
    ashape.TextFrame.Paragraphs.AddFromHtml(tr.ReadToEnd());

    // Uloží prezentaci
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Export textu odstavce do HTML**

Aspose.Slides poskytuje rozšířenou podporu pro export textů (obsažených v odstavcích) do HTML.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) a načtěte požadovanou prezentaci.
2. Získejte odkaz na příslušný snímek pomocí jeho indexu.
3. Získejte tvar obsahující text, který bude exportován do HTML.
4. Získejte [TextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/textframe/) tvaru.
5. Vytvořte instanci `StreamWriter` a přidejte nový HTML soubor.
6. Zadejte počáteční index pro StreamWriter a exportujte požadované odstavce.

```c#
// Načte soubor prezentace
using (Presentation pres = new Presentation("ExportingHTMLText.pptx"))
{

    // Přistupuje k výchozímu prvnímu snímku prezentace
    ISlide slide = pres.Slides[0];

    // Získává požadovaný index
    int index = 0;

    // Přistupuje k přidanému tvaru
    IAutoShape ashape = (IAutoShape)slide.Shapes[index];

    StreamWriter sw = new StreamWriter("output_out.html", false, Encoding.UTF8);

    // Zapíše data odstavců do HTML specifikováním počátečního indexu odstavce a počtu odstavců k zkopírování
    sw.Write(ashape.TextFrame.Paragraphs.ExportToHtml(0, ashape.TextFrame.Paragraphs.Count, null));

    sw.Close();
}
```

## **Uložení odstavce jako obrázku**

V této sekci prozkoumáme dva příklady, které ukazují, jak uložit textový odstavec reprezentovaný rozhraním [IParagraph](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraph/) jako obrázek. Oba příklady zahrnují získání obrázku tvaru obsahujícího odstavec pomocí metod `GetImage` z rozhraní [IShape](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/) , výpočet ohraničení odstavce uvnitř tvaru a jeho export jako bitmapový obrázek. Tyto přístupy vám umožní extrahovat konkrétní části textu z PowerPoint prezentací a uložit je jako samostatné obrázky, což může být užitečné pro další použití v různých scénářích.

Předpokládejme, že máme soubor prezentace s názvem sample.pptx s jedním snímkem, kde je první tvar textové pole obsahující tři odstavce.

![Textové pole se třemi odstavci](paragraph_to_image_input.png)

**Příklad 1**

V tomto příkladu získáme druhý odstavec jako obrázek. K tomu extrahujeme obrázek tvaru z prvního snímku prezentace a poté vypočítáme ohraničení druhého odstavce v textovém rámci tvaru. Odstavec je následně překreslen na novém bitmapovém obrázku, který je uložen ve formátu PNG. Tato metoda je zvláště užitečná, když potřebujete uložit konkrétní odstavec jako samostatný obrázek při zachování přesných rozměrů a formátování textu.

```csharp
using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// Save the shape in memory as a bitmap.
using var shapeImage = firstShape.GetImage();
using var shapeImageStream = new MemoryStream();
shapeImage.Save(shapeImageStream, ImageFormat.Png);

// Create a shape bitmap from memory.
shapeImageStream.Seek(0, SeekOrigin.Begin);
using var shapeBitmap = Image.FromStream(shapeImageStream);

// Calculate the boundaries of the second paragraph.
var secondParagraph = firstShape.TextFrame.Paragraphs[1];
var paragraphRectangle = secondParagraph.GetRect();

// Calculate the size for the output image (minimum size - 1x1 pixel).
var imageWidth = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Width));
var imageHeight = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Height));

// Prepare a bitmap for the paragraph.
using var paragraphBitmap = new Bitmap(imageWidth, imageHeight);

// Redraw the paragraph from the shape bitmap to the paragraph bitmap.
using var imageGraphics = Graphics.FromImage(paragraphBitmap);
var drawingRectangle = new RectangleF(0, 0, paragraphRectangle.Width, paragraphRectangle.Height);
imageGraphics.DrawImage(shapeBitmap, drawingRectangle, paragraphRectangle, GraphicsUnit.Pixel);

paragraphBitmap.Save("paragraph.png", System.Drawing.Imaging.ImageFormat.Png);
```

Výsledek:

![Obrázek odstavce](paragraph_to_image_output.png)

**Příklad 2**

V tomto příkladu rozšíříme předchozí přístup přidáním škálovacích faktorů k obrázku odstavce. Tvar je extrahován z prezentace a uložen jako obrázek se škálovacím faktorem `2`. To umožňuje výstup s vyšším rozlišením při exportu odstavce. Ohraničení odstavce je pak vypočítáno s ohledem na měřítko. Škálování může být zvláště užitečné, když je potřeba podrobnější obrázek, například pro použití ve vysoce kvalitních tištěných materiálech.

```csharp
var imageScaleX = 2f;
var imageScaleY = imageScaleX;

using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// Save the shape in memory as a bitmap with scaling.
using var shapeImage = firstShape.GetImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
using var shapeImageStream = new MemoryStream();
shapeImage.Save(shapeImageStream, ImageFormat.Png);

// Create a shape bitmap from memory.
shapeImageStream.Seek(0, SeekOrigin.Begin);
using var shapeBitmap = Image.FromStream(shapeImageStream);

// Calculate the boundaries of the second paragraph.
var secondParagraph = firstShape.TextFrame.Paragraphs[1];
var paragraphRectangle = secondParagraph.GetRect();
paragraphRectangle.X *= imageScaleX;
paragraphRectangle.Y *= imageScaleY;
paragraphRectangle.Width *= imageScaleX;
paragraphRectangle.Height *= imageScaleY;

// Calculate the size for the output image (minimum size - 1x1 pixel).
var imageWidth = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Width));
var imageHeight = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Height));

// Prepare a bitmap for the paragraph.
using var paragraphBitmap = new Bitmap(imageWidth, imageHeight);

// Redraw the paragraph from the shape bitmap to the paragraph bitmap.
using var imageGraphics = Graphics.FromImage(paragraphBitmap);
var drawingRectangle = new RectangleF(0, 0, paragraphRectangle.Width, paragraphRectangle.Height);
imageGraphics.DrawImage(shapeBitmap, drawingRectangle, paragraphRectangle, GraphicsUnit.Pixel);

paragraphBitmap.Save("paragraph.png", System.Drawing.Imaging.ImageFormat.Png);
```

## **Často kladené otázky**

**Mohu úplně zakázat zalomení řádků uvnitř textového rámce?**

Ano. Použijte nastavení zalamování textového rámce ([WrapText](https://reference.aspose.com/slides/cs/net/aspose.slides/textframeformat/wraptext/)) a vypněte zalamování, aby řádky neprobíhaly na okrajích rámce.

**Jak získat přesné ohraničení konkrétního odstavce na snímku?**

Můžete získat ohraničující obdélník odstavce (a dokonce i jedné části) a tak znát jeho přesnou pozici a velikost na snímku.

**Kde je řízena zarovnání odstavce (vlevo/vpravo/na střed/justify)?**

[Alignment](https://reference.aspose.com/slides/cs/net/aspose.slides/paragraphformat/alignment/) je nastavení na úrovni odstavce v [ParagraphFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/paragraphformat/); platí pro celý odstavec bez ohledu na formátování jednotlivých částí.

**Mohu nastavit jazyk kontroly pravopisu jen pro část odstavce (např. jedno slovo)?**

Ano. Jazyk se nastavuje na úrovni části ([PortionFormat.LanguageId](https://reference.aspose.com/slides/cs/net/aspose.slides/baseportionformat/languageid/)), takže v jednom odstavci mohou koexistovat více jazyků.