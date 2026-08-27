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
description: "Aspose.Slides for Java usnadňuje vytváření, úpravu a klonování textových polí v souborech PowerPoint a OpenDocument, což zvyšuje efektivitu automatizace vašich prezentací."
---
## **Úvod**

Texty na snímcích se obvykle nacházejí v textových polích nebo tvarech. Proto musíte pro přidání textu na snímek nejprve přidat textové pole a pak do něj vložit text. Aspose.Slides pro Java poskytuje rozhraní [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IAutoShape), které vám umožní přidat tvar obsahující text.

{{% alert title="Info" color="info" %}}
Aspose.Slides také poskytuje rozhraní [IShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IShape), které umožňuje přidávat tvary na snímky. Nicméně ne všechny tvary přidané přes rozhraní `IShape` mohou obsahovat text. Tvary přidané přes rozhraní [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IAutoShape) však mohou text obsahovat.
{{% /alert %}}

{{% alert title="Note" color="warning" %}}
Proto při práci s tvarem, ke kterému chcete přidat text, byste měli zkontrolovat a potvrdit, že byl přetypován přes rozhraní `IAutoShape`. Teprve poté budete moci pracovat s [TextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/TextFrame), což je vlastnost pod `IAutoShape`. Viz část [Update Text](https://docs.aspose.com/slides/cs/java/manage-textbox/#update-text) na této stránce.
{{% /alert %}}

## **Vytvoření textového pole na snímku**

Pro vytvoření textového pole na snímku postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation). 
2. Získejte referenci na první snímek v nově vytvořené prezentaci. 
3. Přidejte objekt [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IAutoShape) s typem [ShapeType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IGeometryShape#setShapeType-int-) nastaveným na `Rectangle` na určené pozici na snímku a získejte referenci na nově přidaný objekt `IAutoShape`. 
4. Přidejte vlastnost `TextFrame` k objektu `IAutoShape`, která bude obsahovat text. V níže uvedeném příkladu jsme přidali tento text: *Aspose TextBox*
5. Nakonec zapište soubor PPTX pomocí objektu `Presentation`. 

Tento Java kód —implementace výše uvedených kroků—ukazuje, jak přidat text na snímek:

```java
import com.aspose.slides.*;

// Vytváří instanci Presentation
Presentation pres = new Presentation();
try {
    // Získá první snímek v prezentaci
    ISlide sld = pres.getSlides().get_Item(0);

    // Přidá AutoShape s typem nastaveným na Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Přidá TextFrame do obdélníku
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

## **Kontrola, zda jde o tvar typu Text Box**

Aspose.Slides poskytuje metodu [isTextBox](https://reference.aspose.com/slides/cs/java/com.aspose.slides/autoshape/#isTextBox--) z rozhraní [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/), která vám umožní prozkoumat tvary a identifikovat textová pole.

![Textové pole a tvar](istextbox.png)

Tento Java kód ukazuje, jak zkontrolovat, zda byl tvar vytvořen jako textové pole: 

```java
import com.aspose.slides.*;

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

Všimněte si, že pokud jednoduše přidáte autoshape pomocí metody `addAutoShape` z rozhraní [IShapeCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishapecollection/), metoda `isTextBox` autoshape vrátí `false`. Po přidání textu do autoshape pomocí metody `addTextFrame` nebo `setText` však vlastnost `isTextBox` vrátí `true`.

```java
import com.aspose.slides.*;

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

## **Najděte tvar, který vlastní Text Frame**

V obecném kódu pro zpracování textu můžete získat objekt [ITextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/) aniž byste věděli, který objekt prezentace jej obsahuje. Použijte metodu [ITextFrame.getParentShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/#getParentShape--) k navigaci zpět k vlastnímu [IShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/).

Pro textový rámec, který patří [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/) nebo jinému tvaru obsahujícímu text, vrací [ITextFrame.getParentShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/#getParentShape--) vlastníka a [ITextFrame.getParentCell](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/#getParentCell--) vrací `null`. Obě metody poskytují pouze pro čtení navigaci, takže jejich volání nemění vlastnictví. Vždy před přístupem k tvaru zkontrolujte návratovou hodnotu na `null`.

Kompletní příklad, který identifikuje vlastníky tvarů a buněk tabulky, včetně tvarů spojených s uzly SmartArt, najdete v [Search and Replace Text](/slides/cs/java/search-and-replace-text/).

## **Přidání sloupců do textového pole**

Aspose.Slides poskytuje vlastnosti [ColumnCount](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) a [ColumnSpacing](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) (z rozhraní [ITextFrameFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ITextFrameFormat) a třídy [TextFrameFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/TextFrameFormat)), které umožňují přidávat sloupce do textových polí. Můžete určit počet sloupců v textovém poli a nastavit mezery v bodech mezi sloupci. 

Tento kód v jazyce Java demonstruje popsanou operaci: 

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Získá první snímek v prezentaci
    ISlide slide = pres.getSlides().get_Item(0);

    // Přidá AutoShape s typem nastaveným na Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Přidá TextFrame do obdélníku
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

## **Přidání sloupců do Text Frame**

Aspose.Slides pro Java poskytuje vlastnost [ColumnCount](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) (z rozhraní [ITextFrameFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ITextFrameFormat)), která umožňuje přidávat sloupce do textových rámců. Touto vlastností můžete nastavit požadovaný počet sloupců v textovém rámci. 

Tento Java kód ukazuje, jak přidat sloupec do textového rámce:

```java
import com.aspose.slides.*;

String outPptxFileName = "ColumnsTest.pptx";
Presentation pres = new Presentation();
try {
    IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    ITextFrameFormat format = shape1.getTextFrame().getTextFrameFormat();

    format.setColumnCount(2);
    shape1.getTextFrame().setText("All these columns are forced to stay within a single text container -- " +
            "you can add or delete text - and the new or remaining text automatically adjusts " +
            "itself to stay within the container. You cannot have text spill over from one container " +
            "to other, though -- because PowerPoint's column options for text are limited!");
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = (IAutoShape)test.getSlides().get_Item(0).getShapes().get_Item(0);
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test != null) test.dispose();
    }

    format.setColumnSpacing(20);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test1 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = (IAutoShape)test1.getSlides().get_Item(0).getShapes().get_Item(0);
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test1 != null) test1.dispose();
    }

    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test2 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = (IAutoShape)test2.getSlides().get_Item(0).getShapes().get_Item(0);
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test2 != null) test2.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Aktualizace textu**

Aspose.Slides vám umožňuje změnit nebo aktualizovat text obsažený v textovém poli nebo veškerý text v prezentaci. 

Tento Java kód demonstruje operaci, při které jsou aktualizovány nebo změněny všechny texty v prezentaci:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) //Kontroluje, zda tvar podporuje textový rámec (IAutoShape). 
            {
                IAutoShape autoShape = (IAutoShape)shape; 
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) //Iteruje přes odstavce v textovém rámci
                {
                    for (IPortion portion : paragraph.getPortions()) //Iteruje přes každou část v odstavci
                    {
                        portion.setText(portion.getText().replace("years", "months")); //Mění text
                        portion.getPortionFormat().setFontBold(NullableBool.True); //Mění formátování
                    }
                }
            }
        }
    }

    //Uloží upravenou prezentaci
    pres.save("text-changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Přidání textového pole s hyperodkazem** 

Můžete vložit odkaz do textového pole. Když je textové pole kliknuto, uživatelé jsou přesměrováni na otevření odkazu. 

Pro přidání textového pole obsahujícího odkaz postupujte podle následujících kroků:

1. Vytvořte instanci třídy `Presentation`. 
2. Získejte referenci na první snímek v nově vytvořené prezentaci. 
3. Přidejte objekt `AutoShape` s `ShapeType` nastaveným na `Rectangle` na určené pozici na snímku a získejte referenci na nově přidaný objekt AutoShape.
4. Přidejte `TextFrame` k objektu `AutoShape`, který bude obsahovat *Aspose TextBox* jako výchozí text. 
5. Vytvořte instanci třídy `IHyperlinkManager`. 
6. Přiřaďte objekt `IHyperlinkManager` k vlastnosti [HyperlinkClick](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Shape#getHyperlinkClick--) spojené s požadovanou částí `TextFrame`. 
7. Nakonec zapište soubor PPTX pomocí objektu `Presentation`. 

Tento Java kód —implementace výše uvedených kroků—ukazuje, jak přidat textové pole s hyperodkazem na snímek:

```java
import com.aspose.slides.*;

// Vytvoří instanci třídy Presentation, která představuje soubor PPTX
Presentation pres = new Presentation();
try {
    // Získá první snímek v prezentaci
    ISlide slide = pres.getSlides().get_Item(0);

    // Přidá objekt AutoShape s typem nastaveným na Rectangle
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // Přetypuje tvar na AutoShape
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // Přistupuje k vlastnosti ITextFrame spojené s AutoShape
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // Přidá nějaký text do rámce
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

## **FAQ**

**Jaký je rozdíl mezi textovým polem a textovým zástupcem při práci s hlavními snímky?**

[placeholder](/slides/cs/java/manage-placeholder/) dědí styl/pozici z [master](https://reference.aspose.com/slides/cs/java/com.aspose.slides/masterslide/) a může být přepsán na [layouts](https://reference.aspose.com/slides/cs/java/com.aspose.slides/layoutslide/), zatímco běžné textové pole je samostatný objekt na konkrétním snímku a při změně rozložení se nemění.

**Jak mohu provést hromadnou náhradu textu v celé prezentaci, aniž bych zasáhl do textu v grafech, tabulkách a SmartArt?**

Omezte iteraci na autoshapes, které mají textové rámce, a vyloučte vložené objekty ([charts](https://reference.aspose.com/slides/cs/java/com.aspose.slides/chart/), [tables](https://reference.aspose.com/slides/cs/java/com.aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/cs/java/com.aspose.slides/smartart/)) tím, že jejich kolekce projdete samostatně nebo přeskočíte tyto typy objektů.