---
title: Správa textových polí v prezentacích na Androidu
linktitle: Správa textového pole
type: docs
weight: 20
url: /cs/androidjava/manage-textbox/
keywords:
- textové pole
- textový rámec
- přidat text
- aktualizovat text
- vytvořit textové pole
- zkontrolovat textové pole
- přidat textový sloupec
- přidat hyperodkaz
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides pro Android prostřednictvím Javy usnadňuje vytváření, úpravu a klonování textových polí v souborech PowerPoint a OpenDocument, což zlepšuje automatizaci vašich prezentací."
---
## **Úvod**

Texty na snímcích jsou obvykle umístěny v textových polích nebo tvarech. Proto musíte pro přidání textu na snímek nejprve přidat textové pole a poté do něj vložit text. Aspose.Slides pro Android via Java poskytuje rozhraní [IAutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IAutoShape) které vám umožňuje přidat tvar obsahující text.

{{% alert title="Info" color="info" %}}

Aspose.Slides také poskytuje rozhraní [IShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IShape) které umožňuje přidávat tvary na snímky. Nicméně ne všechny tvary přidané přes rozhraní `IShape` mohou obsahovat text. Tvary přidané přes rozhraní [IAutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IAutoShape) však mohou text obsahovat.

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

Proto, když pracujete s tvarem, ke kterému chcete přidat text, můžete chtít zkontrolovat a potvrdit, že byl převeden pomocí rozhraní `IAutoShape`. Teprve potom budete moci pracovat s [TextFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/TextFrame), který je vlastností pod `IAutoShape`. Viz sekce [Update Text](https://docs.aspose.com/slides/cs/androidjava/manage-textbox/#update-text) na této stránce.

{{% /alert %}}

## **Vytvoření textového pole na snímku**

Pro vytvoření textového pole na snímku postupujte podle těchto kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
2. Získejte odkaz na první snímek v nově vytvořené prezentaci. 
3. Přidejte objekt [IAutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IAutoShape) s [ShapeType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IGeometryShape#setShapeType-int-) nastaveným na `Rectangle` na určenou pozici na snímku a získejte odkaz na nově přidaný objekt `IAutoShape`.
4. Přidejte vlastnost `TextFrame` k objektu `IAutoShape`, která bude obsahovat text. V níže uvedeném příkladu jsme přidali tento text: *Aspose TextBox*
5. Nakonec zapište soubor PPTX pomocí objektu `Presentation`. 

Tento kód v jazyce Java — implementace výše uvedených kroků — ukazuje, jak přidat text na snímek:

```java
import com.aspose.slides.*;

// Vytvoří instanci Presentation
Presentation pres = new Presentation();
try {
    // Získá první snímek v prezentaci
    ISlide sld = pres.getSlides().get_Item(0);

    // Přidá AutoShape s typem nastaveným na Obdélník
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Přidá TextFrame k Obdélníku
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

## **Kontrola, zda jde o tvar textového pole**

Aspose.Slides poskytuje metodu [isTextBox](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iautoshape/#isTextBox--) z rozhraní [IAutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iautoshape/), která vám umožňuje prozkoumat tvary a identifikovat textová pole.

![Textové pole a tvar](istextbox.png)

Tento kód v jazyce Java ukazuje, jak zkontrolovat, zda byl tvar vytvořen jako textové pole: 

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

Všimněte si, že pokud pouze přidáte autoshape pomocí metody `addAutoShape` z rozhraní [IShapeCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishapecollection/), metoda `isTextBox` tohoto autoshape vrátí `false`. Po přidání textu do autoshape pomocí metody `addTextFrame` nebo `setText` se však vlastnost `isTextBox` vrátí `true`.

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

## **Nalezení tvaru, který vlastní TextFrame**

V obecném kódu pro zpracování textu můžete získat objekt [ITextFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframe/) aniž byste věděli, který objekt prezentace jej obsahuje. Použijte metodu [ITextFrame.getParentShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframe/#getParentShape--) k návratu k vlastnímu [IShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/).

Pro textový rámec, který patří k [IAutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iautoshape/) nebo jinému tvaru obsahujícímu text, metoda [ITextFrame.getParentShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframe/#getParentShape--) vrací vlastníka a [ITextFrame.getParentCell](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframe/#getParentCell--) vrací `null`. Obě metody poskytují pouze čtení, takže jejich volání nemění vlastnictví. Vždy před přístupem k tvaru zkontrolujte, zda vrácená hodnota není `null`.

Kompletní příklad, který identifikuje vlastníky tvarů a buněk tabulky, včetně tvarů spojených s uzly SmartArt, najdete v [Search and Replace Text](/slides/cs/androidjava/search-and-replace-text/).

## **Přidání sloupců do textového pole**

Aspose.Slides poskytuje vlastnosti [ColumnCount](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) a [ColumnSpacing](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) (z rozhraní [ITextFrameFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ITextFrameFormat) a třídy [TextFrameFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/TextFrameFormat)), které umožňují přidávat sloupce do textových polí. Můžete určit počet sloupců v textovém poli a nastavit mezery v bodech mezi sloupci.

Tento kód v jazyce Java demonstruje popsanou operaci: 

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Získá první snímek v prezentaci
    ISlide slide = pres.getSlides().get_Item(0);

    // Přidá AutoShape s typem nastaveným na Obdélník
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Přidá TextFrame k Obdélníku
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

## **Přidání sloupců do TextFrame**

Aspose.Slides pro Android via Java poskytuje vlastnost [ColumnCount](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) (z rozhraní [ITextFrameFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ITextFrameFormat)), která umožňuje přidávat sloupce v textových rámečcích. Pomocí této vlastnosti můžete nastavit požadovaný počet sloupců v textovém rámečku.

Tento kód v jazyce Java ukazuje, jak přidat sloupec uvnitř textového rámečku:

```java
import com.aspose.slides.*;

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
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test != null) test.dispose();
    }

    format.setColumnSpacing(20);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test1 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test1.getSlides().get_Item(0).getShapes().get_Item(0));
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
        IAutoShape autoShape = ((AutoShape)test2.getSlides().get_Item(0).getShapes().get_Item(0));
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

Tento kód v jazyce Java demonstruje operaci, při které jsou aktualizovány nebo změněny všechny texty v prezentaci:

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

Pro přidání textového pole obsahujícího odkaz postupujte podle těchto kroků:

1. Vytvořte instanci třídy `Presentation`. 
2. Získejte odkaz na první snímek v nově vytvořené prezentaci. 
3. Přidejte objekt `AutoShape` s `ShapeType` nastaveným na `Rectangle` na určenou pozici na snímku a získejte odkaz na nově přidaný objekt AutoShape.
4. Přidejte `TextFrame` k objektu `AutoShape` a nastavte text jeho první části. V níže uvedeném příkladu jsme použili tento text: *Aspose.Slides*
5. Získejte objekt [IHyperlinkManager](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ihyperlinkmanager/) z `PortionFormat` požadované části `TextFrame`.
6. Zavolejte [setExternalHyperlinkClick](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-) na tomto objektu a nastavte odkaz, který se otevře po kliknutí na text.
7. Nakonec zapište soubor PPTX pomocí objektu `Presentation`. 

Tento kód v jazyce Java — implementace výše uvedených kroků — ukazuje, jak přidat textové pole s hyperodkazem na snímek:

```java
import com.aspose.slides.*;

// Vytvoří instanci třídy Presentation, která představuje PPTX
Presentation pres = new Presentation();
try {
    // Získá první snímek v prezentaci
    ISlide slide = pres.getSlides().get_Item(0);

    // Přidá objekt AutoShape s typem nastaveným na Obdélník
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // Převede tvar na AutoShape
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // Přistoupí k vlastnosti ITextFrame spojené s AutoShape
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

Zástupce [placeholder](/slides/cs/androidjava/manage-placeholder/) dědí styl/pozici z [masteru](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/masterslide/) a může být přepsán v [rozložení](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/layoutslide/), zatímco běžné textové pole je nezávislý objekt na konkrétním snímku a při změně rozložení se nemění.

**Jak mohu provést hromadnou náhradu textu v celé prezentaci, aniž bych zasahoval do textu v grafech, tabulkách a SmartArt?**

Omezte iteraci na auto-tvary, které mají textové rámečky, a vyloučte vložené objekty ([grafy](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/chart/), [tabulky](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/smartart/)) tím, že jejich kolekce procházíte samostatně nebo přeskočíte tyto typy objektů.