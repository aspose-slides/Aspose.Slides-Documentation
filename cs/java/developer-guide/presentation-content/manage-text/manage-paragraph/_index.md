---
title: Správa textových odstavců PowerPointu v Javě
linktitle: Správa odstavce
type: docs
weight: 40
url: /cs/java/manage-paragraph/
aliases:
  - /java/paragraph/
  - /java/portion/
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
- import HTML
- text do HTML
- odstavec do HTML
- odstavec na obrázek
- text na obrázek
- exportovat odstavec
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Ovládněte formátování odstavců pomocí Aspose.Slides pro Java — optimalizujte zarovnání, rozestupy a styl v prezentacích PPT, PPTX a ODP v Javě."
---
## **Úvod**

Aspose.Slides poskytuje všechny rozhraní a třídy, které potřebujete k práci s texty, odstavci a částmi PowerPointu v jazyce Java.

* Aspose.Slides poskytuje rozhraní [ITextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/) umožňující přidávat objekty představující odstavec. Objekt `ITextFame` může mít jeden nebo více odstavců (každý odstavec je vytvořen pomocí návratu řádku).
* Aspose.Slides poskytuje rozhraní [IParagraph](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraph/) umožňující přidávat objekty představující části. Objekt `IParagraph` může mít jednu nebo více částí (kolekce objektů iPortions).
* Aspose.Slides poskytuje rozhraní [IPortion](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iportion/) umožňující přidávat objekty představující texty a jejich formátovací vlastnosti.

Objekt `IParagraph` je schopen zpracovávat texty s různými formátovacími vlastnostmi prostřednictvím svých podkladových objektů `IPortion`.

## **Přidání více odstavců obsahujících více částí**

Tyto kroky vám ukážou, jak přidat textový rámec obsahující 3 odstavce a každý odstavec obsahující 3 části:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
2. Získejte odkaz na požadovaný snímek pomocí jeho indexu.
3. Přidejte obdélníkový [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/) na snímek.
4. Získejte ITextFrame spojený s [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/).
5. Vytvořte dva objekty [IParagraph](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraph/) a přidejte je do kolekce `IParagraphs` [ITextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/).
6. Vytvořte tři objekty [IPortion](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iportion/) pro každý nový `IParagraph` (dvě objekty Portion pro výchozí odstavec) a přidejte každý objekt `IPortion` do kolekce IPortion každého `IParagraph`.
7. Nastavte text pro každou část.
8. Použijte požadované formátovací funkce na každou část pomocí formátovacích vlastností poskytovaných objektem `IPortion`.
9. Uložte upravenou prezentaci.

```java
// Instancujte třídu Presentation, která představuje soubor PPTX
Presentation pres = new Presentation();
try {
    // Přístup k prvnímu snímku
    ISlide slide = pres.getSlides().get_Item(0);

    // Přidejte AutoShape typu Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // Přístup k TextFrame AutoShape
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

    //    Uložte PPTX na disk
    pres.save("multiParaPort_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Správa odrážek odstavců**

Seznamy s odrážkami vám pomáhají rychle a efektivně organizovat a prezentovat informace. Odrážkové odstavce jsou vždy snazší číst a pochopit.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
2. Získejte odkaz na požadovaný snímek pomocí jeho indexu.
3. Přidejte [autoshape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/) na vybraný snímek.
4. Získejte [TextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/) autoshape.
5. Odstraňte výchozí odstavec v `TextFrame`.
6. Vytvořte první odstavec pomocí třídy [Paragraph](https://reference.aspose.com/slides/cs/java/com.aspose.slides/paragraph/).
7. Nastavte pro odstavec typ odrážky `Type` na `Symbol` a zadejte znak odrážky.
8. Nastavte `Text` odstavce.
9. Nastavte `Indent` odstavce pro odrážku.
10. Nastavte barvu odrážky.
11. Nastavte výšku odrážky.
12. Přidejte nový odstavec do kolekce odstavců `TextFrame`.
13. Přidejte druhý odstavec a opakujte postup popsaný v krocích 7 až 13.
14. Uložte prezentaci.

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

    // Nastaví styl a znak odrážky odstavce
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char)8226);

    // Nastaví text odstavce
    para.setText("Welcome to Aspose.Slides");

    // Nastaví odsazení odrážky
    para.getParagraphFormat().setIndent(25);

    // Nastaví barvu odrážky
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // nastaví IsBulletHardColor na true pro použití vlastní barvy odrážky

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
    para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // nastaví IsBulletHardColor na true pro použití vlastní barvy odrážky

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

Seznamy s odrážkami vám pomáhají rychle a efektivně organizovat a prezentovat informace. Odstavce s obrázkovými odrážkami jsou snadno čitelné a srozumitelné.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
2. Získejte odkaz na požadovaný snímek pomocí jeho indexu.
3. Přidejte [autoshape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/) na snímek.
4. Získejte [TextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/) autoshape.
5. Odstraňte výchozí odstavec v `TextFrame`.
6. Vytvořte první odstavec pomocí třídy [Paragraph](https://reference.aspose.com/slides/cs/java/com.aspose.slides/paragraph/).
7. Načtěte obrázek v [IPPImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ippimage/).
8. Nastavte typ odrážky na [Picture](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ippimage/) a nastavte obrázek.
9. Nastavte `Text` odstavce.
10. Nastavte `Indent` odstavce pro odrážku.
11. Nastavte barvu odrážky.
12. Nastavte výšku odrážky.
13. Přidejte nový odstavec do kolekce odstavců `TextFrame`.
14. Přidejte druhý odstavec a opakujte postup podle předchozích kroků.
15. Uložte upravenou prezentaci.

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
    // Přidá a přistoupí k Autoshape
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Přistoupí k textovému rámci autoshape
    ITextFrame textFrame = autoShape.getTextFrame();

    // Odstraní výchozí odstavec
    textFrame.getParagraphs().removeAt(0);

    // Vytvoří nový odstavec
    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");

    // Nastaví styl a obrázek odrážky odstavce
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

## **Správa víceúrovňových odrážek**

Seznamy s odrážkami vám pomáhají rychle a efektivně organizovat a prezentovat informace. Víceúrovňové odrážky jsou snadno čitelné a srozumitelné.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
2. Získejte odkaz na požadovaný snímek pomocí jeho indexu.
3. Přidejte [autoshape] na nový snímek.
4. Získejte [TextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/) autoshape.
5. Odstraňte výchozí odstavec v `TextFrame`.
6. Vytvořte první odstavec pomocí třídy [Paragraph](https://reference.aspose.com/slides/cs/java/com.aspose.slides/paragraph/) a nastavte hloubku na 0.
7. Vytvořte druhý odstavec pomocí třídy `Paragraph` a nastavte hloubku na 1.
8. Vytvořte třetí odstavec pomocí třídy `Paragraph` a nastavte hloubku na 2.
9. Vytvořte čtvrtý odstavec pomocí třídy `Paragraph` a nastavte hloubku na 3.
10. Přidejte nové odstavce do kolekce odstavců `TextFrame`.
11. Uložte upravenou prezentaci.

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

    // Vyčistí výchozí odstavec
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

Rozhraní [IBulletFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibulletformat/) poskytuje vlastnost [NumberedBulletStartWith](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) a další, které vám umožňují spravovat odstavce s vlastním číslováním nebo formátováním.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
2. Získejte odkaz na snímek obsahující odstavec.
3. Přidejte [autoshape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/) na snímek.
4. Získejte [TextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/) autoshape.
5. Odstraňte výchozí odstavec v `TextFrame`.
6. Vytvořte první odstavec pomocí třídy [Paragraph](https://reference.aspose.com/slides/cs/java/com.aspose.slides/paragraph/) a nastavte [NumberedBulletStartWith](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) na 2.
7. Vytvořte druhý odstavec pomocí třídy `Paragraph` a nastavte `NumberedBulletStartWith` na 3.
8. Vytvořte třetí odstavec pomocí třídy `Paragraph` a nastavte `NumberedBulletStartWith` na 7.
9. Přidejte nové odstavce do kolekce odstavců `TextFrame`.
10. Uložte upravenou prezentaci.

```java
Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Přistupuje k textovému rámci vytvořeného autoshape
    ITextFrame textFrame = shape.getTextFrame();

    // Odstraní výchozí existující odstavec
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

Použijte metodu [IParagraphFormat.setIndent](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#setIndent-float-) k řízení odsazení první řádky odstavce. Tato metoda posouvá pouze první řádek vzhledem k levému okraji odstavce. Kladná hodnota posune první řádek doprava, zatímco ostatní řádky zůstávají zarovnány ke tělu odstavce.

Použijte [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) , když potřebujete přesunout celý odstavec. Použijte [IParagraphFormat.setIndent](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#setIndent-float-) , když potřebujete přesunout pouze první řádek.

Níže uvedený příklad vytvoří několik odstavců a aplikuje různé hodnoty odsazení, aby demonstroval, jak odsazení první řádky ovlivňuje rozvržení odstavce.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
2. Získejte cílový snímek.
3. Přidejte obdélníkový [AutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/autoshape/) na snímek.
4. Přidejte prázdný [TextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/textframe/) do tvaru a odstraňte výchozí odstavec.
5. Vytvořte několik odstavců a nastavte různé hodnoty [Indent](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#setIndent-float-) pro ně.
6. Přidejte odstavce do textového rámce.
7. Uložte upravenou prezentaci.

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

![Odsazení první řádky odstavců](first_line_indent.png)

## **Nastavení zavěšeného odsazení odstavce**

Zavěšené odsazení je rozvržení odstavce, ve kterém první řádek začíná vlevo od zbylých řádků. V Aspose.Slides vytvoříte tento efekt pomocí metody [IParagraphFormat.setIndent](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#setIndent-float-). Nastavte odsazení na zápornou hodnotu, aby se první řádek posunul vlevo vzhledem k tělu odstavce.

V praxi [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) určuje levou pozici těla odstavce a [IParagraphFormat.setIndent](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#setIndent-float-) určuje pozici první řádky vzhledem k tomuto okraji. Pro vytvoření zavěšeného odsazení nastavte kladnou hodnotu `MarginLeft` a zápornou hodnotu `Indent`.

Toto formátování je užitečné pro bibliografie, odkazy, položky glosáře a další odstavce, kde zalomené řádky musejí být zarovnány pod tělo odstavce místo pod první znak první řádky.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
2. Získejte cílový snímek.
3. Přidejte obdélníkový [AutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/autoshape/) na snímek.
4. Přidejte prázdný [TextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/textframe/) do tvaru a odstraňte výchozí odstavec.
5. Vytvořte odstavce a nastavte kladnou hodnotu [MarginLeft](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) pro každý odstavec.
6. Nastavte zápornou hodnotu [Indent](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#setIndent-float-) pro vytvoření efektu zavěšeného odsazení.
7. Přidejte odstavce do textového rámce.
8. Uložte upravenou prezentaci.

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

![Zavěšené odsazení odstavců](hanging_indent.png)

## **Správa koncových vlastností odstavce**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
2. Získejte odkaz na snímek obsahující odstavec pomocí jeho pozice.
3. Přidejte obdélníkový [autoshape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/) na snímek.
4. Přidejte [TextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/) s dvěma odstavci do obdélníku.
5. Nastavte `FontHeight` a typ písma pro odstavce.
6. Nastavte koncové vlastnosti pro odstavce.
7. Uložte upravenou prezentaci jako soubor PPTX.

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

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
2. Získejte odkaz na požadovaný snímek pomocí jeho indexu.
3. Přidejte [autoshape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/) na snímek.
4. Přidejte a získejte přístup k `autoshape` [ITextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/).
5. Odstraňte výchozí odstavec v `ITextFrame`.
6. Načtěte zdrojový HTML soubor do TextReaderu.
7. Vytvořte první odstavec pomocí třídy [Paragraph](https://reference.aspose.com/slides/cs/java/com.aspose.slides/paragraph/).
8. Přidejte obsah HTML souboru ze čteného TextReaderu do [ParagraphCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/paragraphcollection/) textového rámce.
9. Uložte upravenou prezentaci.

```java
// Vytvořte prázdnou instanci prezentace
Presentation pres = new Presentation();
try {
    // Přístup k výchozímu prvnímu snímku prezentace
    ISlide slide = pres.getSlides().get_Item(0);

    // Přidání AutoShape pro umístění HTML obsahu
    IAutoShape ashape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10,
            (float)pres.getSlideSize().getSize().getWidth() - 20, (float)pres.getSlideSize().getSize().getHeight() - 10);

    ashape.getFillFormat().setFillType(FillType.NoFill);

    // Přidání textového rámce do tvaru
    ashape.addTextFrame("");

    // Vymazání všech odstavců v přidaném textovém rámci
    ashape.getTextFrame().getParagraphs().clear();

    // Načítání HTML souboru pomocí StreamReader
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

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) a načtěte požadovanou prezentaci.
2. Získejte odkaz na požadovaný snímek pomocí jeho indexu.
3. Získejte tvar obsahující text, který bude exportován do HTML.
4. Získejte [TextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/textframe/) tvaru.
5. Vytvořte instanci `StreamWriter` a přidejte nový soubor HTML.
6. Zadejte počáteční index do StreamWriteru a exportujte požadované odstavce.

```java
// Načtěte soubor prezentace
Presentation pres = new Presentation("ExportingHTMLText.pptx");
try {
    // Přístup k výchozímu prvnímu snímku prezentace
    ISlide slide = pres.getSlides().get_Item(0);

    // Požadovaný index
    int index = 0;

    // Přístup k přidanému tvaru
    IAutoShape ashape = (IAutoShape) slide.getShapes().get_Item(index);

    // Vytvoření výstupního HTML souboru
    OutputStream os = new FileOutputStream("output.html");
    Writer writer = new OutputStreamWriter(os, "UTF-8");

    //Extrahování prvního odstavce jako HTML
    // Zapisování dat odstavců do HTML poskytnutím počátečního indexu odstavce, celkového počtu odstavců ke kopírování
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Uložení odstavce jako obrázku**

V této sekci prozkoumáme dva příklady, které ukazují, jak uložit textový odstavec, reprezentovaný rozhraním [IParagraph](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraph/), jako obrázek. Oba příklady zahrnují získání obrázku tvaru obsahujícího odstavec pomocí metod `getImage` z rozhraní [IShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/), výpočet ohraničení odstavce v rámci tvaru a export jako bitmapový obrázek. Tyto přístupy vám umožní extrahovat konkrétní části textu z PowerPoint prezentací a uložit je jako samostatné obrázky, což může být užitečné pro další použití v různých scénářích.

Předpokládejme, že máme soubor prezentace s názvem sample.pptx s jedním snímkem, kde je první tvar textové pole obsahující tři odstavce.

![Textové pole se třemi odstavci](paragraph_to_image_input.png)

**Example 1**

V tomto příkladu získáme druhý odstavec jako obrázek. K tomu extrahujeme obrázek tvaru z první snímku prezentace a poté vypočítáme ohraničení druhého odstavce v textovém rámci tvaru. Odstavec je pak překreslen na nový bitmapový obrázek, který je uložen ve formátu PNG. Tato metoda je zvláště užitečná, když potřebujete uložit konkrétní odstavec jako samostatný obrázek při zachování přesných rozměrů a formátování textu.

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
    Rectangle2D paragraphRectangle = secondParagraph.getRect();

    // Vypočítejte souřadnice a velikost výstupního obrázku (minimální velikost - 1x1 pixel).
    int imageX = (int) Math.floor(paragraphRectangle.getX());
    int imageY = (int) Math.floor(paragraphRectangle.getY());
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.getWidth()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.getHeight()));

    // Ořízněte bitmapu tvaru, aby získala pouze bitmapu odstavce.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

![Obrázek odstavce](paragraph_to_image_output.png)

**Example 2**

V tomto příkladu rozšíříme předchozí přístup přidáním škálovacích faktorů k obrázku odstavce. Tvar je extrahován z prezentace a uložen jako obrázek se škálovacím faktorem `2`. To umožňuje výstup ve vyšším rozlišení při exportu odstavce. Ohraničení odstavce je pak vypočítáno s ohledem na měřítko. Škálování může být zvláště užitečné, když je potřeba podrobnější obrázek, například pro použití ve vysoce kvalitních tištěných materiálech.

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
    Rectangle2D paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.setRect(
            paragraphRectangle.getX() * imageScaleX,
            paragraphRectangle.getY() * imageScaleY,
            paragraphRectangle.getWidth() * imageScaleX,
            paragraphRectangle.getHeight() * imageScaleY
    );

    // Vypočítejte souřadnice a velikost výstupního obrázku (minimální velikost - 1x1 pixel).
    int imageX = (int) Math.floor(paragraphRectangle.getX());
    int imageY = (int) Math.floor(paragraphRectangle.getY());
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.getWidth()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.getHeight()));

    // Ořízněte bitmapu tvaru, aby získala pouze bitmapu odstavce.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **FAQ**

**Mohu zcela zakázat zalamování řádků uvnitř textového rámce?**

Ano. Použijte nastavení zalamování textového rámce ([setWrapText](https://reference.aspose.com/slides/cs/java/com.aspose.slides/textframeformat/#setWrapText-byte-)), které vypne zalamování, takže řádky se nebudou lámat na okrajích rámce.

**Jak mohu získat přesné ohraničení konkrétního odstavce na snímku?**

Můžete získat ohraničující obdélník odstavce (a dokonce i jedné části), abyste znali jeho přesnou polohu a velikost na snímku.

**Kde se řídí zarovnání odstavce (levé/pravé/středové/justify)?**

[Alignment](https://reference.aspose.com/slides/cs/java/com.aspose.slides/paragraphformat/#setAlignment-int-) je nastavení na úrovni odstavce v [ParagraphFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/paragraphformat/); používá se na celý odstavec bez ohledu na formátování jednotlivých částí.

**Mohu nastavit jazyk kontroly pravopisu jen pro část odstavce (např. jedno slovo)?**

Ano. Jazyk se nastavuje na úrovni části ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/cs/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)), takže v jednom odstavci mohou koexistovat různé jazyky.