---
title: Správa textových odstavců PowerPointu na Androidu
linktitle: Správa odstavce
type: docs
weight: 40
url: /cs/androidjava/manage-paragraph/
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
- seznam s odrážkami
- vlastnosti odstavce
- importovat HTML
- text do HTML
- odstavec do HTML
- odstavec na obrázek
- text na obrázek
- exportovat odstavec
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Ovládněte formátování odstavců pomocí Aspose.Slides pro Android — optimalizujte zarovnání, rozestupy a styl v prezentacích PPT, PPTX a ODP v jazyce Java."
---
## **Úvod**

Aspose.Slides poskytuje všechny rozhraní a třídy, které potřebujete pro práci s texty, odstavci a částmi PowerPointu v jazyce Java.

* Aspose.Slides poskytuje rozhraní [ITextFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframe/) , které vám umožní přidávat objekty představující odstavec. Objekt `ITextFame` může obsahovat jeden nebo více odstavců (každý odstavec je vytvořen pomocí návratového znaku).
* Aspose.Slides poskytuje rozhraní [IParagraph](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iparagraph/) , které vám umožní přidávat objekty představující části. Objekt `IParagraph` může mít jednu nebo více částí (kolekci objektů iPortions).
* Aspose.Slides poskytuje rozhraní [IPortion](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iportion/) , které vám umožní přidávat objekty představující texty a jejich formátovací vlastnosti.

Objekt `IParagraph` je schopen zpracovávat texty s různými formátovacími vlastnostmi prostřednictvím svých podřízených objektů `IPortion`.

## **Přidání více odstavců obsahujících více textových částí**

Tyto kroky vám ukážou, jak přidat textový rámec obsahující 3 odstavce a každý odstavec obsahující 3 části:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/).
2. Získejte odkaz na příslušný snímek pomocí jeho indexu.
3. Přidejte na snímek obdélníkový [IAutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iautoshape/).
4. Získejte ITextFrame spojený s [IAutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iautoshape/).
5. Vytvořte dva objekty [IParagraph](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iparagraph/) , a přidejte je do kolekce `IParagraphs` v [ITextFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframe/).
6. Vytvořte tři objekty [IPortion](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iportion/) pro každý nový `IParagraph` (dvě objekty Portion pro výchozí odstavec) a přidejte každý objekt `IPortion` do kolekce IPortion každého `IParagraph`.
7. Nastavte text pro každou část.
8. Použijte požadované formátovací vlastnosti na každou část pomocí formátovacích vlastností nabízených objektem `IPortion`.
9. Uložte upravenou prezentaci.

Tento Java kód je implementací kroků pro přidání odstavců obsahujících části:

```java
// Vytvořte instanci třídy Presentation, která představuje soubor PPTX
Presentation pres = new Presentation();
try {
    // Přístup k prvnímu snímku
    ISlide slide = pres.getSlides().get_Item(0);

    // Přidejte AutoShape typu Obdélník
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // Získejte TextFrame AutoShape
    ITextFrame tf = ashp.getTextFrame();

    // Vytvořte odstavce a části s různými formáty textu
    IParagraph para0 = tf.getParagraphs().get_Item(0);
    IPortion port01 = new Portion();
    IPortion port02 = new Portion();
    para0.getPortions().add(port01);
    para0.getPortions().add(port02);

    IParagraph para1 = new Paragraph();
    tf.getParagraphs().add(para1);
    IPortion port10 = new Portion();
    IPortion port11 = new Portion();
    IPortion port12 = new Portion();
    para1.getPortions().add(port10);
    para1.getPortions().add(port11);
    para1.getPortions().add(port12);

    IParagraph para2 = new Paragraph();
    tf.getParagraphs().add(para2);
    IPortion port20 = new Portion();
    IPortion port21 = new Portion();
    IPortion port22 = new Portion();
    para2.getPortions().add(port20);
    para2.getPortions().add(port21);
    para2.getPortions().add(port22);

    for (int i = 0; i < 3; i++) 
    {
        for (int j = 0; j < 3; j++) 
        {
            IPortion portion = tf.getParagraphs().get_Item(i).getPortions().get_Item(j); 
            portion.setText("Portion0" + j);
            if (j == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
                portion.getPortionFormat().setFontBold(NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (j == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
                portion.getPortionFormat().setFontItalic(NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    // Uložte PPTX na disk
    pres.save("multiParaPort_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Správa odrážek odstavců**

Seznamy s odrážkami vám pomáhají rychle a efektivně organizovat a prezentovat informace. Odstavce s odrážkami jsou vždy snazší číst a pochopit.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/).
2. Získejte odkaz na příslušný snímek pomocí jeho indexu.
3. Přidejte na vybraný snímek [autoshape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iautoshape/).
4. Získejte [TextFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframe/) autoshape.
5. Odstraňte výchozí odstavec v `TextFrame`.
6. Vytvořte první odstavec pomocí třídy [Paragraph](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/paragraph/).
7. Nastavte typ odrážky `Type` odstavce na `Symbol` a nastavte znak odrážky.
8. Nastavte `Text` odstavce.
9. Nastavte `Indent` odstavce pro odrážku.
10. Nastavte barvu odrážky.
11. Nastavte výšku odrážky.
12. Přidejte nový odstavec do kolekce odstavců `TextFrame`.
13. Přidejte druhý odstavec a opakujte postup uvedený v krocích 7 až 13.
14. Uložte prezentaci.

Tento Java kód vám ukazuje, jak přidat odrážku odstavce:

```java
// Vytvoří instanci třídy Presentation, která představuje soubor PPTX
Presentation pres = new Presentation();
try {
    // Přistupuje k prvnímu snímku
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Přidá a přistoupí k Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Přistupuje k textovému rámci autoshape
    ITextFrame txtFrm = aShp.getTextFrame();

    // Odstraní výchozí odstavec
    txtFrm.getParagraphs().removeAt(0);

    // Vytvoří odstavec
    Paragraph para = new Paragraph();

    // Nastaví styl odrážky odstavce a symbol
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char)8226);

    // Nastaví text odstavce
    para.setText("Welcome to Aspose.Slides");

    // Nastaví odsazení odrážky
    para.getParagraphFormat().setIndent(25);

    // Nastaví barvu odrážky
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // nastavit IsBulletHardColor na true pro použití vlastní barvy odrážky

    // Nastaví výšku odrážky
    para.getParagraphFormat().getBullet().setHeight(100);

    // Přidá odstavec do textového rámce
    txtFrm.getParagraphs().add(para);

    // Vytvoří druhý odstavec
    Paragraph para2 = new Paragraph();

    // Nastaví typ a styl odrážky odstavce
    para2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);

    // Přidá text odstavce
    para2.setText("This is numbered bullet");

    // Nastaví odsazení odrážky
    para2.getParagraphFormat().setIndent(25);

    para2.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // nastavit IsBulletHardColor na true pro použití vlastní barvy odrážky

    // Nastaví výšku odrážky
    para2.getParagraphFormat().getBullet().setHeight(100);

    // Přidá odstavec do textového rámce
    txtFrm.getParagraphs().add(para2);
    
    // Uloží upravenou prezentaci
    pres.save("Bullet_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Správa obrázkových odrážek**

Seznamy s odrážkami vám pomáhají rychle a efektivně organizovat a prezentovat informace. Odrážky s obrázky jsou snadno čitelné a pochopitelné.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/).
2. Získejte odkaz na příslušný snímek pomocí jeho indexu.
3. Přidejte na snímek [autoshape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iautoshape/).
4. Získejte [TextFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframe/) autoshape.
5. Odstraňte výchozí odstavec v `TextFrame`.
6. Vytvořte první odstavec pomocí třídy [Paragraph](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/paragraph/).
7. Načtěte obrázek do [IPPImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ippimage/).
8. Nastavte typ odrážky na [Picture](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ippimage/) a nastavte obrázek.
9. Nastavte `Text` odstavce.
10. Nastavte `Indent` odstavce pro odrážku.
11. Nastavte barvu odrážky.
12. Nastavte výšku odrážky.
13. Přidejte nový odstavec do kolekce odstavců `TextFrame`.
14. Přidejte druhý odstavec a opakujte postup podle předchozích kroků.
15. Uložte upravenou prezentaci.

Tento Java kód vám ukazuje, jak přidávat a spravovat obrázkové odrážky:

```java
    // Vytvoří instanci třídy Presentation, která představuje soubor PPTX
    Presentation presentation = new Presentation();
    try {
        // Přistupuje k prvnímu snímku
        ISlide slide = presentation.getSlides().get_Item(0);

        // Vytvoří obrázek pro odrážky
        IPPImage picture;
        IImage image = Images.fromFile("bullets.png");
        try {
            picture = presentation.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
        // Přidá a získá autoshape
        IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

        // Přistupuje k textovému rámci autoshape
        ITextFrame textFrame = autoShape.getTextFrame();

        // Odstraní výchozí odstavec
        textFrame.getParagraphs().removeAt(0);

        // Vytvoří nový odstavec
        Paragraph paragraph = new Paragraph();
        paragraph.setText("Welcome to Aspose.Slides");

        // Nastaví styl odrážky odstavce a obrázek
        paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
        paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);

        // Nastaví výšku odrážky
        paragraph.getParagraphFormat().getBullet().setHeight(100);

        // Přidá odstavec do textového rámce
        textFrame.getParagraphs().add(paragraph);

        // Uloží prezentaci jako soubor PPTX
        presentation.save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

        // Uloží prezentaci jako soubor PPT
        presentation.save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
    } catch (IOException e) {
    } finally {
        if (presentation != null) presentation.dispose();
    }
```

## **Správa vícestupňových odrážek**

Seznamy s odrážkami vám pomáhají rychle a efektivně organizovat a prezentovat informace. Vícestupňové odrážky jsou snadno čitelné a pochopitelné.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/).
2. Získejte odkaz na příslušný snímek pomocí jeho indexu.
3. Přidejte na nový snímek [autoshape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iautoshape/).
4. Získejte [TextFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframe/) autoshape.
5. Odstraňte výchozí odstavec v `TextFrame`.
6. Vytvořte první odstavec pomocí třídy [Paragraph](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/paragraph/) a nastavte hloubku na 0.
7. Vytvořte druhý odstavec pomocí třídy `Paragraph` a nastavte hloubku na 1.
8. Vytvořte třetí odstavec pomocí třídy `Paragraph` a nastavte hloubku na 2.
9. Vytvořte čtvrtý odstavec pomocí třídy `Paragraph` a nastavte hloubku na 3.
10. Přidejte nové odstavce do kolekce odstavců `TextFrame`.
11. Uložte upravenou prezentaci.

Tento Java kód vám ukazuje, jak přidávat a spravovat vícestupňové odrážky:

```java
// Vytvoří instanci třídy Presentation, která představuje soubor PPTX
Presentation pres = new Presentation();
try {
    // Přistupuje k prvnímu snímku
    ISlide slide = pres.getSlides().get_Item(0);

    // Přidá a přistoupí k Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Přistupuje k textovému rámci vytvořeného autoshape
    ITextFrame text = aShp.addTextFrame("");

    // Vymaže výchozí odstavec
    text.getParagraphs().clear();

    // Přidá první odstavec
    IParagraph para1 = new Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Nastaví úroveň odrážky
    para1.getParagraphFormat().setDepth((short)0);

    // Přidá druhý odstavec
    IParagraph para2 = new Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Nastaví úroveň odrážky
    para2.getParagraphFormat().setDepth((short)1);

    // Přidá třetí odstavec
    IParagraph para3 = new Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Nastaví úroveň odrážky
    para3.getParagraphFormat().setDepth((short)2);

    // Přidá čtvrtý odstavec
    IParagraph para4 = new Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Nastaví úroveň odrážky
    para4.getParagraphFormat().setDepth((short)3);

    // Přidá odstavce do kolekce
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);

    // Uloží prezentaci jako soubor PPTX
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Správa odstavce s vlastním číslovaným seznamem**

Rozhraní [IBulletFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ibulletformat/) poskytuje vlastnost [NumberedBulletStartWith](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) a další, které vám umožňují spravovat odstavce s vlastním číslováním nebo formátováním.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/).
2. Získejte snímek obsahující odstavec.
3. Přidejte na snímek [autoshape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iautoshape/).
4. Získejte [TextFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframe/) autoshape.
5. Odstraňte výchozí odstavec v `TextFrame`.
6. Vytvořte první odstavec pomocí třídy [Paragraph](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/paragraph/) a nastavte [NumberedBulletStartWith](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) na 2.
7. Vytvořte druhý odstavec pomocí třídy `Paragraph` a nastavte `NumberedBulletStartWith` na 3.
8. Vytvořte třetí odstavec pomocí třídy `Paragraph` a nastavte `NumberedBulletStartWith` na 7.
9. Přidejte nové odstavce do kolekce odstavců `TextFrame`.
10. Uložte upravenou prezentaci.

Tento Java kód vám ukazuje, jak přidávat a spravovat odstavce s vlastním číslováním nebo formátováním:

```java
Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Přistupuje k textovému rámci vytvořeného autoshape
    ITextFrame textFrame = shape.getTextFrame();

    // Odstraňuje výchozí existující odstavec
    textFrame.getParagraphs().removeAt(0);

    // První seznam
    Paragraph paragraph1 = new Paragraph();
    paragraph1.setText("bullet 2");
    paragraph1.getParagraphFormat().setDepth((short)4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)2);
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.setText("bullet 3");
    paragraph2.getParagraphFormat().setDepth((short)4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)3);
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph2);


    Paragraph paragraph5 = new Paragraph();
    paragraph5.setText("bullet 7");
    paragraph5.getParagraphFormat().setDepth((short)4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)7);
    paragraph5.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph5);

    presentation.save("SetCustomBulletsNumber-slides.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Nastavení odsazení první řádky odstavce**

Použijte metodu [IParagraphFormat.setIndent](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) , která řídí odsazení první řádky odstavce. Tato metoda posouvá pouze první řádek vzhledem k levému okraji odstavce. Kladná hodnota posune první řádek doprava, zatímco zbylé řádky zůstávají zarovnány k tělu odstavce.

Použijte [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) , když potřebujete posunout celý odstavec. Použijte [IParagraphFormat.setIndent](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) , když potřebujete posunout jen první řádek.

Níže uvedený příklad vytvoří několik odstavců a použije různé hodnoty odsazení, aby ukázal, jak odsazení první řádky ovlivňuje rozvržení odstavce.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/).
2. Získejte cílový snímek.
3. Přidejte na snímek obdélníkový [AutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/autoshape/).
4. Přidejte k tvaru prázdný [TextFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/textframe/) a odstraňte výchozí odstavec.
5. Vytvořte několik odstavců a nastavte pro ně různé hodnoty [Indent](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) .
6. Přidejte odstavce do textového rámce.
7. Uložte upravenou prezentaci.

Tento kód vám ukazuje, jak nastavit odsazení odstavce:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape rectangleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(FillType.NoFill);
    rectangleShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().removeAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().setMarginLeft(20f);
    firstParagraph.getParagraphFormat().setIndent(0f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().setMarginLeft(20f);
    secondParagraph.getParagraphFormat().setIndent(20f);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().setMarginLeft(20f);
    thirdParagraph.getParagraphFormat().setIndent(40f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

Výsledek:

![Odsazení první řádky odstavců](first_line_indent.png)

## **Nastavení zavěšeného odsazení pro odstavec**

Zavěšené odsazení je rozvržení odstavce, kde první řádek začíná vlevo od zbylých řádků. V Aspose.Slides vytvoříte tento efekt pomocí metody [IParagraphFormat.setIndent](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) . Nastavte odsazení na zápornou hodnotu, aby se první řádek posunul doleva vůči tělu odstavce.

V praxi [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) určuje levý pozici těla odstavce a [IParagraphFormat.setIndent](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) určuje pozici první řádky vzhledem k tomuto okraji. Pro vytvoření zavěšeného odsazení nastavte kladnou hodnotu `MarginLeft` a zápornou hodnotu `Indent`.

Toto formátování je užitečné pro bibliografie, odkazy, položky glosáře a další odstavce, kde musí zalomené řádky být zarovnány pod tělem odstavce místo pod prvním znakem první řádky.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/).
2. Získejte cílový snímek.
3. Přidejte na snímek obdélníkový [AutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/autoshape/).
4. Přidejte k tvaru prázdný [TextFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/textframe/) a odstraňte výchozí odstavec.
5. Vytvořte odstavce a nastavte pro každý odstavec kladnou hodnotu [MarginLeft](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) .
6. Nastavte zápornou hodnotu [Indent](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) , aby vznikl efekt zavěšeného odsazení.
7. Přidejte odstavce do textového rámce.
8. Uložte upravenou prezentaci.

Tento kód vám ukazuje, jak nastavit zavěšené odsazení pro odstavec:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape rectangleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(FillType.NoFill);
    rectangleShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().removeAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().setMarginLeft(40f);
    firstParagraph.getParagraphFormat().setIndent(-20f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().setMarginLeft(60f);
    secondParagraph.getParagraphFormat().setIndent(-30f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

Výsledek:

![Zavěšené odsazení odstavců](hanging_indent.png)

## **Správa koncových vlastností běhu odstavce**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/).
2. Získejte odkaz na snímek obsahující odstavec pomocí jeho pozice.
3. Přidejte na snímek obdélníkový [autoshape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iautoshape/) .
4. Přidejte do obdélníku [TextFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframe/) se dvěma odstavci.
5. Nastavte `FontHeight` a typ písma pro odstavce.
6. Nastavte koncové (End) vlastnosti pro odstavce.
7. Zapište upravenou prezentaci jako soubor PPTX.

Tento Java kód vám ukazuje, jak nastavit koncové (End) vlastnosti pro odstavce v PowerPointu:

```java
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);

    Paragraph para1 = new Paragraph();
    para1.getPortions().add(new Portion("Sample text"));

    Paragraph para2 = new Paragraph();
    para2.getPortions().add(new Portion("Sample text 2"));

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(48);
    portionFormat.setLatinFont(new FontData("Times New Roman"));
    para2.setEndParagraphPortionFormat(portionFormat);

    shape.getTextFrame().getParagraphs().add(para1);
    shape.getTextFrame().getParagraphs().add(para2);

    pres.save(resourcesOutputPath+"pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Import HTML textu do odstavců**

Aspose.Slides poskytuje rozšířenou podporu pro import HTML textu do odstavců.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/).
2. Získejte odkaz na příslušný snímek pomocí jeho indexu.
3. Přidejte na snímek [autoshape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iautoshape/) .
4. Přidejte a získejte [ITextFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframe/) autoshape.
5. Odstraňte výchozí odstavec v `ITextFrame` .
6. Načtěte zdrojový HTML soubor pomocí TextReader.
7. Vytvořte první odstavec pomocí třídy [Paragraph](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/paragraph/) .
8. Přidejte obsah HTML souboru ze čteného TextReaderu do [ParagraphCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/paragraphcollection/) TextFrame.
9. Uložte upravenou prezentaci.

Tento Java kód je implementací kroků pro import HTML textů do odstavců:

```java
// Vytvořte prázdnou instanci prezentace
Presentation pres = new Presentation();
try {
    // Přistupte k výchozímu prvnímu snímku prezentace
    ISlide slide = pres.getSlides().get_Item(0);

    // Přidání AutoShape pro uložení HTML obsahu
    IAutoShape ashape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10,
            (float)pres.getSlideSize().getSize().getWidth() - 20, (float)pres.getSlideSize().getSize().getHeight() - 10);

    ashape.getFillFormat().setFillType(FillType.NoFill);

    // Přidání textového rámce do tvaru
    ashape.addTextFrame("");

    // Vymazání všech odstavců v přidaném textovém rámci
    ashape.getTextFrame().getParagraphs().clear();

    // Načtení HTML souboru pomocí StreamReaderu
    TextReader tr = new StreamReader("file.html");

    // Přidání textu z HTML stream readeru do textového rámce
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());

    // Ukládání prezentace
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Export textu odstavce do HTML**

Aspose.Slides poskytuje rozšířenou podporu pro export textů (obsažených v odstavcích) do HTML.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) a načtěte požadovanou prezentaci.
2. Získejte odkaz na příslušný snímek pomocí jeho indexu.
3. Získejte tvar obsahující text, který bude exportován do HTML.
4. Získejte [TextFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/textframe/) tvar.
5. Vytvořte instanci `StreamWriter` a přidejte nový HTML soubor.
6. Zadejte počáteční index do StreamWriter a exportujte vámi vybrané odstavce.

Tento Java kód vám ukazuje, jak exportovat texty odstavců PowerPointu do HTML:

```java
// Načíst soubor prezentace
Presentation pres = new Presentation("ExportingHTMLText.pptx");
try {
    // Přistupuje k výchozímu prvnímu snímku prezentace
    ISlide slide = pres.getSlides().get_Item(0);

    // Požadovaný index
    int index = 0;

    // Přístup k přidanému tvaru
    IAutoShape ashape = (IAutoShape) slide.getShapes().get_Item(index);

    // Vytváří výstupní HTML soubor
    OutputStream os = new FileOutputStream("output.html");
    Writer writer = new OutputStreamWriter(os, "UTF-8");

    //Extrahuje první odstavec jako HTML
    // Zapisuje data odstavců do HTML poskytnutím počátečního indexu odstavce, celkového počtu odstavců ke kopírování
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Uložení odstavce jako obrázku**

V této sekci prozkoumáme dva příklady, které demonstrují, jak uložit textový odstavec, reprezentovaný rozhraním [IParagraph](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iparagraph/) , jako obrázek. Oba příklady zahrnují získání obrázku tvaru obsahujícího odstavec pomocí metod `getImage` z rozhraní [IShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/) , výpočet ohraničení odstavce uvnitř tvaru a jeho export jako bitmapový obrázek. Tyto přístupy vám umožňují extrahovat konkrétní části textu z prezentací PowerPoint a uložit je jako samostatné obrázky, což může být užitečné pro další použití v různých scénářích.

Předpokládejme, že máme soubor prezentace s názvem sample.pptx s jedním snímkem, kde je první tvar textové pole obsahující tři odstavce.

![Textové pole se třemi odstavci](paragraph_to_image_input.png)

**Příklad 1**

V tomto příkladu získáme druhý odstavec jako obrázek. K tomu extrahujeme obrázek tvaru z prvního snímku prezentace a poté vypočítáme ohraničení druhého odstavce v textovém rámci tvaru. Odstavec je následně překreslen na nový bitmapový obrázek, který je uložen ve formátu PNG. Tato metoda je zvláště užitečná, když potřebujete uložit konkrétní odstavec jako samostatný obrázek a zachovat přesné rozměry a formátování textu.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Uložte tvar v paměti jako bitmapu.
    IImage shapeImage = firstShape.getImage();
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // Vytvořte bitmapu tvaru z paměti.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // Vypočítejte ohraničení druhého odstavce.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    RectF paragraphRectangle = secondParagraph.getRect();

    // Vypočítejte souřadnice a velikost výstupního obrázku (minimální velikost - 1x1 pixel).
    int imageX = (int) Math.floor(paragraphRectangle.left);
    int imageY = (int) Math.floor(paragraphRectangle.top);
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.width()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.height()));

    // Ořízněte bitmapu tvaru, aby obsahovala pouze bitmapu odstavce.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

Výsledek:

![Obrázek odstavce](paragraph_to_image_output.png)

**Příklad 2**

V tomto příkladu rozšíříme předchozí přístup přidáním škálovacích faktorů k obrázku odstavce. Tvar je extrahován z prezentace a uložen jako obrázek se škálovacím faktorem `2`. To umožňuje výstup s vyšším rozlišením při exportu odstavce. Ohraničení odstavce je poté vypočítáno s ohledem na škálování. Škálování může být zvláště užitečné, když je potřeba detailnější obrázek, například pro použití v vysoce kvalitních tištěných materiálech.

```java
float imageScaleX = 2f;
float imageScaleY = imageScaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Uložte tvar v paměti jako bitmapu se škálováním.
    IImage shapeImage = firstShape.getImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // Vytvořte bitmapu tvaru z paměti.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // Vypočítejte ohraničení druhého odstavce.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    RectF paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.set(
            paragraphRectangle.left * imageScaleX,
            paragraphRectangle.top * imageScaleY,
            paragraphRectangle.right * imageScaleX,
            paragraphRectangle.bottom * imageScaleY
    );

    // Vypočítejte souřadnice a velikost výstupního obrázku (minimální velikost - 1x1 pixel).
    int imageX = (int) Math.floor(paragraphRectangle.left);
    int imageY = (int) Math.floor(paragraphRectangle.top);
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.width()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.height()));

    // Ořízněte bitmapu tvaru, aby obsahovala pouze bitmapu odstavce.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Často kladené otázky**

**Mohu zcela vypnout zalamování řádků uvnitř textového rámce?**

Ano. Použijte nastavení zalamování textového rámce ([setWrapText](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-)) , které vypne zalamování, takže řádky nebudou přerušeny na okrajích rámce.

**Jak mohu získat přesné ohraničení konkrétního odstavce na snímku?**

Můžete získat ohraničující obdélník odstavce (a dokonce i jednotlivé části), abyste znali jeho přesnou polohu a velikost na snímku.

**Kde se řídí zarovnání odstavce (levé/pravé/středové/justify)?**

[Alignment](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/paragraphformat/#setAlignment-int-) je nastavení na úrovni odstavce v [ParagraphFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/paragraphformat/) ; vztahuje se na celý odstavec bez ohledu na formátování jednotlivých částí.

**Mohu nastavit jazyk kontroly pravopisu jen pro část odstavce (např. jedno slovo)?**

Ano. Jazyk se nastavuje na úrovni části ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)) , takže v jednom odstavci může koexistovat více jazyků.