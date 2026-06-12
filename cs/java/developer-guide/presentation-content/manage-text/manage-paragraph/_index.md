---
title: Správa textových odstavců PowerPointu v Javě
linktitle: Správa odstavce
type: docs
weight: 40
url: /cs/java/manage-paragraph/
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
- Java
- Aspose.Slides
description: "Ovládněte formátování odstavců pomocí Aspose.Slides pro Javu—optimalizujte zarovnání, rozestupy a styl v prezentacích PPT, PPTX a ODP v Javě."
---
## **Úvod**

Aspose.Slides poskytuje všechna rozhraní a třídy, které potřebujete pro práci s texty, odstavci a částmi v PowerPointu v Javě.

* Aspose.Slides poskytuje rozhraní [ITextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/), které vám umožňuje přidávat objekty představující odstavec. Objekt `ITextFame` může mít jeden nebo více odstavců (každý odstavec je vytvořen pomocí návratu vozíku).
* Aspose.Slides poskytuje rozhraní [IParagraph](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraph/), které vám umožňuje přidávat objekty představující části. Objekt `IParagraph` může mít jednu nebo více částí (kolekce objektů iPortions).
* Aspose.Slides poskytuje rozhraní [IPortion](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iportion/), které vám umožňuje přidávat objekty představující texty a jejich formátovací vlastnosti. 

Objekt `IParagraph` je schopen zpracovávat texty s různými formátovacími vlastnostmi pomocí svých podřazených objektů `IPortion`.

## **Přidání více odstavců obsahujících více částí**

Tyto kroky ukazují, jak přidat textový rámec obsahující 3 odstavce a každý odstavec obsahující 3 části:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
2. Získejte odkaz na požadovaný snímek podle jeho indexu.
3. Přidejte obdélníkový [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/) do snímku.
4. Získejte `ITextFrame` přidružený k [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/).
5. Vytvořte dva objekty [IParagraph](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraph/) a přidejte je do kolekce `IParagraphs` rozhraní [ITextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/).
6. Vytvořte tři objekty [IPortion](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iportion/) pro každý nový `IParagraph` (dvě částové objekty pro výchozí odstavec) a přidejte každý objekt `IPortion` do kolekce IPortion každého `IParagraph`.
7. Nastavte text pro každou část.
8. Použijte požadované formátovací vlastnosti na každou část pomocí vlastností formátování vystavených objektem `IPortion`.
9. Uložte upravenou prezentaci.

Tento Java kód je implementací kroků pro přidání odstavců obsahujících části:

```java
// Vytvořte třídu Presentation, která představuje soubor PPTX
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

Seznamy s odrážkami vám pomáhají rychle a efektivně organizovat a prezentovat informace. Odrážkované odstavce jsou vždy snazší číst a pochopit.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
2. Získejte odkaz na požadovaný snímek podle jeho indexu.
3. Přidejte [autoshape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/) na vybraný snímek.
4. Získejte `TextFrame` autoshape. 
5. Odstraňte výchozí odstavec v `TextFrame`.
6. Vytvořte první odstavec pomocí třídy [Paragraph](https://reference.aspose.com/slides/cs/java/com.aspose.slides/paragraph/).
7. Nastavte typ odrážky `Type` na `Symbol` a zadejte znak odrážky.
8. Nastavte text odstavce.
9. Nastavte odsazení `Indent` odrážky.
10. Nastavte barvu odrážky.
11. Nastavte výšku odrážky.
12. Přidejte nový odstavec do kolekce odstavců `TextFrame`.
13. Přidejte druhý odstavec a opakujte postup od kroků 7 až 13.
14. Uložte prezentaci.

Tento Java kód vám ukazuje, jak přidat odrážku odstavce:

```java
// Vytvoří objekt třídy Presentation, který představuje soubor PPTX
Presentation pres = new Presentation();
try {
    // Přistupuje k prvnímu snímku
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Přidá a získá Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Přistupuje k textovému rámci autoshape
    ITextFrame txtFrm = aShp.getTextFrame();

    // Odstraní výchozí odstavec
    txtFrm.getParagraphs().removeAt(0);

    // Vytvoří odstavec
    Paragraph para = new Paragraph();

    // Nastaví styl a symbol odrážky odstavce
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

Seznamy s odrážkami vám pomáhají rychle a efektivně organizovat a prezentovat informace. Odrážky s obrázky jsou snadno čitelné a srozumitelné.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
2. Získejte odkaz na požadovaný snímek podle jeho indexu.
3. Přidejte [autoshape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/) do snímku.
4. Získejte `TextFrame` autoshape. 
5. Odstraňte výchozí odstavec v `TextFrame`.
6. Vytvořte první odstavec pomocí třídy [Paragraph](https://reference.aspose.com/slides/cs/java/com.aspose.slides/paragraph/).
7. Načtěte obrázek v [IPPImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ippimage/).
8. Nastavte typ odrážky na [Picture](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ippimage/) a přiřaďte obrázek.
9. Nastavte text odstavce.
10. Nastavte odsazení `Indent` odrážky.
11. Nastavte barvu odrážky.
12. Nastavte výšku odrážky.
13. Přidejte nový odstavec do kolekce odstavců `TextFrame`.
14. Přidejte druhý odstavec a opakujte postup podle předchozích kroků.
15. Uložte upravenou prezentaci.

Tento Java kód vám ukazuje, jak přidat a spravovat obrázkové odrážky:

```java
// Vytvoří objekt třídy Presentation, který představuje soubor PPTX
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
    // Přidá a získá Autoshape
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

Seznamy s odrážkami vám pomáhají rychle a efektivně organizovat a prezentovat informace. Vícestupňové odrážky jsou snadno čitelné a srozumitelné.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
2. Získejte odkaz na požadovaný snímek podle jeho indexu.
3. Přidejte [autoshape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/) do nového snímku.
4. Získejte `TextFrame` autoshape. 
5. Odstraňte výchozí odstavec v `TextFrame`.
6. Vytvořte první odstavec pomocí třídy [Paragraph](https://reference.aspose.com/slides/cs/java/com.aspose.slides/paragraph/) a nastavte úroveň na 0.
7. Vytvořte druhý odstavec pomocí třídy `Paragraph` a nastavte úroveň na 1.
8. Vytvořte třetí odstavec pomocí třídy `Paragraph` a nastavte úroveň na 2.
9. Vytvořte čtvrtý odstavec pomocí třídy `Paragraph` a nastavte úroveň na 3.
10. Přidejte nové odstavce do kolekce odstavců `TextFrame`.
11. Uložte upravenou prezentaci.

Tento Java kód vám ukazuje, jak přidat a spravovat vícestupňové odrážky:

```java
// Vytvoří objekt třídy Presentation, který představuje soubor PPTX
Presentation pres = new Presentation();
try {
    // Přistupuje k prvnímu snímku
    ISlide slide = pres.getSlides().get_Item(0);

    // Přidá a získá Autoshape
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

Rozhraní [IBulletFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibulletformat/) poskytuje vlastnost [NumberedBulletStartWith](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) a další, které vám umožňují spravovat odstavce s vlastním číslováním nebo formátováním. 

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
2. Získejte odkaz na snímek obsahující odstavec.
3. Přidejte [autoshape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/) do snímku.
4. Získejte `TextFrame` autoshape.
5. Odstraňte výchozí odstavec v `TextFrame`.
6. Vytvořte první odstavec pomocí třídy [Paragraph](https://reference.aspose.com/slides/cs/java/com.aspose.slides/paragraph/) a nastavte [NumberedBulletStartWith](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) na 2.
7. Vytvořte druhý odstavec pomocí třídy `Paragraph` a nastavte `NumberedBulletStartWith` na 3.
8. Vytvořte třetí odstavec pomocí třídy `Paragraph` a nastavte `NumberedBulletStartWith` na 7.
9. Přidejte nové odstavce do kolekce odstavců `TextFrame`.
10. Uložte upravenou prezentaci.

Tento Java kód vám ukazuje, jak přidat a spravovat odstavce s vlastním číslováním nebo formátováním:

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

Použijte metodu [IParagraphFormat.setIndent](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#setIndent-float-) k řízení odsazení první řádky odstavce. Tato metoda posouvá pouze první řádek vzhledem k levému okraji odstavce. Kladná hodnota posune první řádek doprava, zatímco zbývající řádky zůstávají zarovnané k tělu odstavce.

Použijte [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-), když potřebujete posunout celý odstavec. Použijte [IParagraphFormat.setIndent](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#setIndent-float-), když potřebujete posunout pouze první řádek.

Níže uvedený příklad vytváří několik odstavců a aplikuje různé hodnoty odsazení, aby ukázal, jak odsazení první řádky ovlivňuje rozvržení odstavce.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
2. Získejte cílový snímek.
3. Přidejte obdélníkový [AutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/autoshape/) do snímku.
4. Přidejte prázdný [TextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/textframe/) do tvaru a odstraňte výchozí odstavec.
5. Vytvořte několik odstavců a nastavte různé hodnoty [Indent](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#setIndent-float-) pro ně.
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

## **Nastavení zavěšeného odsazení odstavce**

Zavěšené odsazení je rozložení odstavce, při kterém první řádek začíná vlevo od zbývajících řádků. V Aspose.Slides vytvoříte tento efekt pomocí metody [IParagraphFormat.setIndent](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#setIndent-float-). Nastavte odsazení na zápornou hodnotu, aby se první řádek posunul doleva vzhledem k tělu odstavce.

V praxi [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) určuje levou pozici těla odstavce a [IParagraphFormat.setIndent](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#setIndent-float-) určuje pozici první řádky vzhledem k tomuto okraji. Pro vytvoření zavěšeného odsazení nastavte kladnou hodnotu `MarginLeft` a zápornou hodnotu `Indent`.

Toto formátování je užitečné pro bibliografie, odkazy, glosáře a další odstavce, kde musí být zalomené řádky zarovnány pod tělo odstavce, nikoli pod první znak první řádky.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
2. Získejte cílový snímek.
3. Přidejte obdélníkový [AutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/autoshape/) do snímku.
4. Přidejte prázdný [TextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/textframe/) do tvaru a odstraňte výchozí odstavec.
5. Vytvořte odstavce a nastavte kladnou hodnotu [MarginLeft](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) pro každý odstavec.
6. Nastavte zápornou hodnotu [Indent](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#setIndent-float-) pro vytvoření efektu zavěšeného odsazení.
7. Přidejte odstavce do textového rámce.
8. Uložte upravenou prezentaci.

Tento kód vám ukazuje, jak nastavit zavěšené odsazení odstavce:

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

## **Správa koncových vlastností odstavce**

1. Vytvořte instanci [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
1. Získejte referenci na snímek obsahující odstavec podle jeho pozice.
1. Přidejte obdélníkový [autoshape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/) do snímku.
1. Přidejte [TextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/) se dvěma odstavci do obdélníku.
1. Nastavte `FontHeight` a typ písma pro odstavce.
1. Nastavte koncové vlastnosti pro odstavce.
1. Uložte upravenou prezentaci jako soubor PPTX.

Tento Java kód vám ukazuje, jak nastavit koncové vlastnosti odstavců v PowerPointu: 

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
2. Získejte odkaz na požadovaný snímek podle jeho indexu.
3. Přidejte [autoshape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/) do snímku.
4. Přidejte a získejte `ITextFrame` autoshape.
5. Odstraňte výchozí odstavec v `ITextFrame`.
6. Přečtěte zdrojový HTML soubor pomocí TextReaderu.
7. Vytvořte první odstavec pomocí třídy [Paragraph](https://reference.aspose.com/slides/cs/java/com.aspose.slides/paragraph/).
8. Přidejte obsah HTML souboru z TextReaderu do kolekce [ParagraphCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/paragraphcollection/) TextFrame.
9. Uložte upravenou prezentaci.

Tento Java kód je implementací kroků pro import HTML textu do odstavců:

```java
// Vytvořte prázdnou instanci prezentace
Presentation pres = new Presentation();
try {
    // Přistupte k výchozímu prvnímu snímku prezentace
    ISlide slide = pres.getSlides().get_Item(0);

    // Přidání AutoShape pro umístění HTML obsahu
    IAutoShape ashape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10,
            (float)pres.getSlideSize().getSize().getWidth() - 20, (float)pres.getSlideSize().getSize().getHeight() - 10);

    ashape.getFillFormat().setFillType(FillType.NoFill);

    // Přidání textového rámce do tvaru
    ashape.addTextFrame("");

    // Vymazání všech odstavců ve vytvořeném textovém rámci
    ashape.getTextFrame().getParagraphs().clear();

    // Načtení HTML souboru pomocí StreamReaderu
    TextReader tr = new StreamReader("file.html");

    // Přidání textu z HTML StreamReaderu do textového rámce
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());

    // Uložení prezentace
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Export textu odstavce do HTML**

Aspose.Slides poskytuje rozšířenou podporu pro export textů (obsažených v odstavcích) do HTML.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) a načtěte požadovanou prezentaci.
2. Získejte odkaz na požadovaný snímek podle jeho indexu.
3. Získejte tvar obsahující text, který bude exportován do HTML.
4. Získejte `TextFrame` tvaru.
5. Vytvořte instanci `StreamWriter` a otevřete nový HTML soubor.
6. Zadejte počáteční index pro `StreamWriter` a exportujte požadované odstavce.

Tento Java kód vám ukazuje, jak exportovat texty odstavců PowerPointu do HTML:

```java
// Načtěte soubor prezentace
Presentation pres = new Presentation("ExportingHTMLText.pptx");
try {
    // Přistupte k výchozímu prvnímu snímku prezentace
    ISlide slide = pres.getSlides().get_Item(0);

    // Požadovaný index
    int index = 0;

    // Přistupování k přidanému tvaru
    IAutoShape ashape = (IAutoShape) slide.getShapes().get_Item(index);

    // Vytváření výstupního HTML souboru
    OutputStream os = new FileOutputStream("output.html");
    Writer writer = new OutputStreamWriter(os, "UTF-8");

    //Extrahování prvního odstavce jako HTML
    // Zapisování dat odstavců do HTML pomocí zadání počátečního indexu odstavce a celkového počtu odstavců ke zkopírování
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Uložení odstavce jako obrázku**

V této části prozkoumáme dva příklady, které demonstrují, jak uložit textový odstavec reprezentovaný rozhraním [IParagraph](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraph/) jako obrázek. Oba příklady zahrnují získání obrázku tvaru obsahujícího odstavec pomocí metod `getImage` rozhraní [IShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/), výpočet ohraničení odstavce uvnitř tvaru a export jako bitmapového obrázku. Tyto přístupy vám umožní extrahovat konkrétní části textu z PowerPoint prezentací a uložit je jako samostatné obrázky, což může být užitečné pro další použití v různých scénářích.

Předpokládejme, že máme soubor prezentace s názvem sample.pptx s jedním snímkem, kde je první tvar textové pole obsahující tři odstavce.

![Textové pole se třemi odstavci](paragraph_to_image_input.png)

**Příklad 1**

V tomto příkladu získáme druhý odstavec jako obrázek. K tomu extrahujeme obrázek tvaru z prvního snímku prezentace a poté vypočítáme ohraničení druhého odstavce v textovém rámci tvaru. Odstavec je následně překreslen na nový bitmapový obrázek, který je uložen ve formátu PNG. Tato metoda je obzvláště užitečná, když potřebujete uložit konkrétní odstavec jako samostatný obrázek při zachování přesných rozměrů a formátování textu.

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

    // Vypočítejte hranice druhého odstavce.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    Rectangle2D paragraphRectangle = secondParagraph.getRect();

    // Vypočítejte souřadnice a velikost výstupního obrázku (minimální velikost - 1x1 pixel).
    int imageX = (int) Math.floor(paragraphRectangle.getX());
    int imageY = (int) Math.floor(paragraphRectangle.getY());
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.getWidth()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.getHeight()));

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

V tomto příkladu rozšiřujeme předchozí přístup přidáním měřítka k obrázku odstavce. Tvar je extrahován z prezentace a uložen jako obrázek se škálovacím faktorem `2`. To umožňuje výstup s vyšším rozlišením při exportu odstavce. Ohraničení odstavce je pak vypočítáno s ohledem na měřítko. Škálování může být zvláště užitečné, když je potřeba detailnější obrázek, například pro použití ve vysoce kvalitních tištěných materiálech.

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

    // Vypočítejte hranice druhého odstavce.
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

    // Ořízněte bitmapu tvaru, aby obsahovala pouze bitmapu odstavce.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Časté dotazy**

**Mohu úplně zakázat zalamování textu uvnitř textového rámce?**

Ano. Použijte nastavení zalamování textového rámce ([setWrapText](https://reference.aspose.com/slides/cs/java/com.aspose.slides/textframeformat/#setWrapText-byte-)) a vypněte zalamování, aby se řádky nelámal na okrajích rámce.

**Jak mohu získat přesné ohraničení konkrétního odstavce na snímku?**

Můžete získat ohraničující obdélník odstavce (a dokonce i jednotlivé části), abyste znali jeho přesnou polohu a velikost na snímku.

**Kde se řídí zarovnání odstavce (vlevo/vpravo/na střed/justify)?**

[Alignment](https://reference.aspose.com/slides/cs/java/com.aspose.slides/paragraphformat/#setAlignment-int-) je nastavení na úrovni odstavce v [ParagraphFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/paragraphformat/); platí pro celý odstavec bez ohledu na formátování jednotlivých částí.

**Mohu nastavit jazyk kontroly pravopisu jen pro část odstavce (např. jedno slovo)?**

Ano. Jazyk se nastavuje na úrovni části ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/cs/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)), takže v jednom odstavci může být použito více jazyků.