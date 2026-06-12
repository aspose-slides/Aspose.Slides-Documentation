---
title: Správa textových polí v prezentacích pomocí Javy
linktitle: Správa textového pole
type: docs
weight: 20
url: /cs/java/manage-textbox/
keywords:
- textové pole
- textový rámec
- přidat text
- aktualizovat text
- vytvořit textové pole
- zkontrolovat textové pole
- přidat sloupec textu
- přidat hyperodkaz
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Aspose.Slides pro Javu usnadňuje vytváření, úpravu a klonování textových polí v souborech PowerPoint a OpenDocument, což zlepšuje automatizaci vašich prezentací."
---
## **Úvod**

Texty na snímcích jsou běžně umístěny v textových polích nebo tvarech. Proto, abyste přidali text na snímek, musíte nejprve přidat textové pole a poté do něj vložit text. Aspose.Slides pro Java poskytuje rozhraní [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IAutoShape), které umožňuje přidat tvar obsahující text.

{{% alert title="Info" color="info" %}}
Aspose.Slides také poskytuje rozhraní [IShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IShape), které umožňuje přidávat tvary na snímky. Ne všechny tvary přidané přes rozhraní `IShape` mohou obsahovat text. Tvary přidané přes rozhraní [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IAutoShape) však mohou text obsahovat. 
{{% /alert %}}

{{% alert title="Poznámka" color="warning" %}} 
Proto, když pracujete s tvarem, ke kterému chcete přidat text, měli byste ověřit a potvrdit, že byl převeden pomocí rozhraní `IAutoShape`. Teprve potom budete moci pracovat s [TextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/TextFrame), což je vlastnost pod `IAutoShape`. Viz sekce [Update Text](https://docs.aspose.com/slides/cs/java/manage-textbox/#update-text) na této stránce. 
{{% /alert %}}

## **Vytvoření textového pole na snímku**

Pro vytvoření textového pole na snímku postupujte následovně:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).  
2. Získejte odkaz na první snímek nově vytvořené prezentace.  
3. Přidejte objekt [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IAutoShape) s typem [ShapeType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IGeometryShape#setShapeType-int-) nastaveným na `Rectangle` na požadovanou pozici na snímku a získejte odkaz na nově přidaný objekt `IAutoShape`.  
4. Přidejte vlastnost `TextFrame` k objektu `IAutoShape`, která bude obsahovat text. V níže uvedeném příkladu jsme přidali tento text: *Aspose TextBox*  
5. Nakonec zapište soubor PPTX pomocí objektu `Presentation`.  

Tento Java kód—implementace výše uvedených kroků—ukazuje, jak přidat text na snímek:

```java
// Vytvoří instanci Presentation
Presentation pres = new Presentation();
try {
    // Získá první snímek v prezentaci
    ISlide sld = pres.getSlides().get_Item(0);

    // Přidá AutoShape s typem nastaveným na Obdélník
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Přidá TextFrame do Obdélníku
    ashp.addTextFrame(" ");

    // Přistoupí k textovému rámci
    ITextFrame txtFrame = ashp.getTextFrame();

    // Vytvoří objekt Paragraph pro textový rámec
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Vytvoří objekt Portion pro odstavec
    IPortion portion = para.getPortions().get_Item(0);

    // Nastaví text
    portion.setText("Aspose TextBox");

    // Uloží prezentaci na disk
    pres.save("TextBox_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Kontrola, zda se jedná o tvar textového pole**

Aspose.Slides poskytuje metodu [isTextBox](https://reference.aspose.com/slides/cs/java/com.aspose.slides/autoshape/#isTextBox--) z rozhraní [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/), která umožňuje prozkoumat tvary a identifikovat textová pole.

![Text box and shape](istextbox.png)

Tento Java kód ukazuje, jak zkontrolovat, zda byl tvar vytvořen jako textové pole: 

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ForEach.shape(presentation, (shape, slide, index) -> {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;
            System.out.println(autoShape.isTextBox() ? "shape is a text box" : "shape is not a text box");
        }
    });
} finally {
    presentation.dispose();
}
```

Všimněte si, že pokud jen přidáte automatický tvar pomocí metody `addAutoShape` z rozhraní [IShapeCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishapecollection/), metoda `isTextBox` tohoto automatického tvaru vrátí `false`. Po přidání textu do automatického tvaru pomocí metody `addTextFrame` nebo `setText` se pak vlastnost `isTextBox` nastaví na `true`.

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
// shape1.isTextBox() vrací false
shape1.addTextFrame("shape 1");
// shape1.isTextBox() vrací true

IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 110, 100, 40);
// shape2.isTextBox() vrací false
shape2.getTextFrame().setText("shape 2");
// shape2.isTextBox() vrací true

IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 210, 100, 40);
// shape3.isTextBox() vrací false
shape3.addTextFrame("");
// shape3.isTextBox() vrací false

IAutoShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 100, 40);
// shape4.isTextBox() vrací false
shape4.getTextFrame().setText("");
// shape4.isTextBox() vrací false
```

## **Přidání sloupců do textového pole**

Aspose.Slides poskytuje vlastnosti [ColumnCount](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) a [ColumnSpacing](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) (z rozhraní [ITextFrameFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ITextFrameFormat) a třídy [TextFrameFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/TextFrameFormat)), které umožňují přidávat sloupce do textových polí. Můžete určit počet sloupců v textovém poli a nastavit mezery mezi sloupci v bodech. 

Tento Java kód demonstruje popsanou operaci: 

```java
Presentation pres = new Presentation();
try {
    // Získá první snímek v prezentaci
    ISlide slide = pres.getSlides().get_Item(0);

    // Přidá AutoShape s typem nastaveným na Obdélník
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Přidá TextFrame do Obdélníku
    aShape.addTextFrame("All these columns are limited to be within a single text container -- " +
            "you can add or delete text and the new or remaining text automatically adjusts " +
            "itself to flow within the container. You cannot have text flow from one container " +
            "to other though -- we told you PowerPoint's column options for text are limited!");

    // Získá formát textu TextFrame
    ITextFrameFormat format = aShape.getTextFrame().getTextFrameFormat();

    // Určuje počet sloupců v TextFrame
    format.setColumnCount(3);

    // Určuje mezery mezi sloupci
    format.setColumnSpacing(10);

    // Uloží prezentaci
    pres.save("ColumnCount.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Přidání sloupců do textového rámce**

Aspose.Slides pro Java poskytuje vlastnost [ColumnCount](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) (z rozhraní [ITextFrameFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ITextFrameFormat)), která umožňuje přidávat sloupce v textových rámcích. Pomocí této vlastnosti můžete určit požadovaný počet sloupců v textovém rámci. 

Tento Java kód ukazuje, jak přidat sloupec do textového rámce:

```java
String outPptxFileName = "ColumnsTest.pptx";
Presentation pres = new Presentation();
try {
    IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.getTextFrame().getTextFrameFormat();

    format.setColumnCount(2);
    shape1.getTextFrame().setText("All these columns are forced to stay within a single text container -- " +
            "you can add or delete text - and the new or remaining text automatically adjusts " +
            "itself to stay within the container. You cannot have text spill over from one container " +
            "to other, though -- because PowerPoint's column options for text are limited!");
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test.getSlides().get_Item(0).getShapes().get_Item(0));
        Assert.assertTrue(2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(Double.NaN == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test != null) test.dispose();
    }

    format.setColumnSpacing(20);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test1 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test1.getSlides().get_Item(0).getShapes().get_Item(0));
        Assert.assertTrue(2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(20 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test1 != null) test1.dispose();
    }

    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test2 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test2.getSlides().get_Item(0).getShapes().get_Item(0));
        Assert.assertTrue(3 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(15 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test2 != null) test2.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Aktualizace textu**

Aspose.Slides umožňuje měnit nebo aktualizovat text obsažený v textovém poli nebo veškerý text v celé prezentaci. 

Tento Java kód demonstruje operaci, při níž jsou aktualizovány nebo změněny všechny texty v prezentaci:

```java
Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) // Kontroluje, zda tvar podporuje textový rámec (IAutoShape).
            {
                IAutoShape autoShape = (IAutoShape)shape; 
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) // Prochází odstavce v textovém rámci
                {
                    for (IPortion portion : paragraph.getPortions()) // Prochází každou část v odstavci
                    {
                        portion.setText(portion.getText().replace("years", "months")); // Mění text
                        portion.getPortionFormat().setFontBold(NullableBool.True); // Mění formátování
                    }
                }
            }
        }
    }

    // Uloží upravenou prezentaci
    pres.save("text-changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Přidání textového pole s hyperodkazem** 

Do textového pole můžete vložit odkaz. Po kliknutí na textové pole se uživatelé dostanou na tento odkaz. 

Pro přidání textového pole obsahujícího odkaz postupujte následovně:

1. Vytvořte instanci třídy `Presentation`.  
2. Získejte odkaz na první snímek nově vytvořené prezentace.  
3. Přidejte objekt `AutoShape` s nastaveným `ShapeType` na `Rectangle` na požadovanou pozici na snímku a získejte odkaz na nově přidaný objekt AutoShape.  
4. Přidejte `TextFrame` k objektu `AutoShape`, který bude obsahovat *Aspose TextBox* jako výchozí text.  
5. Vytvořte instanci třídy `IHyperlinkManager`.  
6. Přiřaďte objekt `IHyperlinkManager` k vlastnosti [HyperlinkClick](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Shape#getHyperlinkClick--) u požadované části `TextFrame`.  
7. Nakonec zapište soubor PPTX pomocí objektu `Presentation`.  

Tento Java kód—implementace výše uvedených kroků—ukazuje, jak přidat textové pole s hyperodkazem na snímek:

```java
// Vytvoří instanci třídy Presentation, která představuje PPTX
Presentation pres = new Presentation();
try {
    // Získá první snímek v prezentaci
    ISlide slide = pres.getSlides().get_Item(0);

    // Přidá objekt AutoShape s typem nastaveným na Obdélník
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // Přetypuje tvar na AutoShape
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // Přistoupí k vlastnosti ITextFrame spojené s AutoShape
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // Přidá text do rámce
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // Nastaví hyperodkaz pro text části
    IHyperlinkManager hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).
            getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");

    // Uloží PPTX prezentaci
    pres.save("hLink_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Často kladené otázky**

**Jaký je rozdíl mezi textovým polem a zástupným textovým polem při práci s hlavními snímky?**

[Placeholder](/slides/cs/java/manage-placeholder/) dědí styl/pozici z [masteru](https://reference.aspose.com/slides/cs/java/com.aspose.slides/masterslide/) a lze jej přepsat na [layoutu](https://reference.aspose.com/slides/cs/java/com.aspose.slides/layoutslide/), zatímco běžné textové pole je samostatný objekt na konkrétním snímku a při změně layoutu se nemění.

**Jak mohu provést hromadnou náhradu textu v celé prezentaci, aniž bych zasáhl do textu uvnitř grafů, tabulek a SmartArt?**

Omezte iteraci na automatické tvary, které mají textové rámce, a vyloučte vložené objekty ([grafy](https://reference.aspose.com/slides/cs/java/com.aspose.slides/chart/), [tabulky](https://reference.aspose.com/slides/cs/java/com.aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/cs/java/com.aspose.slides/smartart/)) tím, že budete jejich kolekce procházet odděleně nebo přeskočíte tyto typy objektů.