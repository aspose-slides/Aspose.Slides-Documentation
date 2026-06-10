---
title: Szövegmezők kezelése prezentációkban Java használatával
linktitle: Szövegmező kezelése
type: docs
weight: 20
url: /hu/java/manage-textbox/
keywords:
- szövegmező
- szövegkeret
- szöveg hozzáadása
- szöveg frissítése
- szövegmező létrehozása
- szövegmező ellenőrzése
- szöveg oszlop hozzáadása
- hiperhivatkozás hozzáadása
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Az Aspose.Slides for Java megkönnyíti a szövegmezők létrehozását, szerkesztését és klónozását a PowerPoint és OpenDocument fájlokban, ezáltal javítva a prezentáció automatizálását."
---
## **Bevezetés**

A diákon lévő szövegek általában szövegmezőkben vagy alakzatokban találhatók. Ezért egy szöveg hozzáadásához a diára egy szövegmezőt kell hozzáadni, majd szöveget helyezni a szövegmezőbe. Az Aspose.Slides for Java a [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IAutoShape) interfészt biztosítja, amely lehetővé teszi, hogy szöveget tartalmazó alakzatot adjunk hozzá.

{{% alert title="Info" color="info" %}}

Az Aspose.Slides a [IShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IShape) interfészt is biztosítja, amely lehetővé teszi alakzatok hozzáadását a diákhoz. Azonban nem minden, az `IShape` interfészen keresztül hozzáadott alakzat képes szöveget tárolni. Azonban a [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IAutoShape) interfészen keresztül hozzáadott alakzatok tartalmazhatnak szöveget. 

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

Ezért, amikor olyan alakzattal dolgozunk, amelyhez szöveget akarunk hozzáadni, érdemes ellenőrizni és megerősíteni, hogy az `IAutoShape` interfészen keresztül lett átkonvertálva. Csak ezután fogsz tudni a [TextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/TextFrame) felületével dolgozni, amely az `IAutoShape` alatti tulajdonság. Lásd az oldalon található [Update Text](https://docs.aspose.com/slides/hu/java/manage-textbox/#update-text) szekciót. 

{{% /alert %}}

## **Szövegmező létrehozása egy dián**

Egy szövegmező létrehozásához egy dián, kövesd az alábbi lépéseket:

1. Hozd létre a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztály egy példányát. 
2. Szerezz hivatkozást az újonnan létrehozott prezentáció első diájára. 
3. Adj hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IAutoShape) objektumot a [ShapeType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IGeometryShape#setShapeType-int-) `Rectangle` értékre beállítva, a dián egy megadott pozícióban, és szerezz hivatkozást az újonnan hozzáadott `IAutoShape` objektumra. 
4. `TextFrame` tulajdonságot add hozzá az `IAutoShape` objektumhoz, amely szöveget fog tartalmazni. Az alábbi példában ezt a szöveget adtuk hozzá: *Aspose TextBox*
5. Végül írd ki a PPTX fájlt a `Presentation` objektumon keresztül. 

Ez a Java kód – a fenti lépések megvalósítása – megmutatja, hogyan adhatunk szöveget egy diához:

```java
// Példányosítja a Presentation objektumot
Presentation pres = new Presentation();
try {
    // Lekéri a prezentáció első diáját
    ISlide sld = pres.getSlides().get_Item(0);

    // Hozzáad egy AutoShape-ot, amelynek típusa Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Szövegkeretet ad a téglalaphoz
    ashp.addTextFrame(" ");

    // Eléri a szövegkeretet
    ITextFrame txtFrame = ashp.getTextFrame();

    // Létrehozza a Paragraph objektumot a szövegkerethez
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Létrehozza a Portion objektumot a bekezdéshez
    IPortion portion = para.getPortions().get_Item(0);

    // Beállítja a szöveget
    portion.setText("Aspose TextBox");

    // Mentse a prezentációt a lemezre
    pres.save("TextBox_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Szövegmező alakzat ellenőrzése**

Az Aspose.Slides a [isTextBox](https://reference.aspose.com/slides/hu/java/com.aspose.slides/autoshape/#isTextBox--) metódust biztosítja a [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) interfészen keresztül, amely lehetővé teszi az alakzatok vizsgálatát és a szövegmezők azonosítását.

![Text box and shape](istextbox.png)

Ez a Java kód megmutatja, hogyan ellenőrizheted, hogy egy alakzat szövegmezőként lett-e létrehozva: 

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

Vedd figyelembe, hogy ha egyszerűen egy autoshape-et adsz hozzá az `addAutoShape` metódus segítségével a [IShapeCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishapecollection/) interfészen keresztül, az autoshape `isTextBox` metódusa `false` értéket ad vissza. Azonban miután szöveget adsz hozzá az autoshape-hez az `addTextFrame` vagy a `setText` metódus használatával, az `isTextBox` tulajdonság `true` értéket ad vissza.

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
// shape1.isTextBox() false-t ad vissza
shape1.addTextFrame("shape 1");
// shape1.isTextBox() true-t ad vissza

IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 110, 100, 40);
// shape2.isTextBox() false-t ad vissza
shape2.getTextFrame().setText("shape 2");
// shape2.isTextBox() true-t ad vissza

IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 210, 100, 40);
// shape3.isTextBox() false-t ad vissza
shape3.addTextFrame("");
// shape3.isTextBox() false-t ad vissza

IAutoShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 100, 40);
// shape4.isTextBox() false-t ad vissza
shape4.getTextFrame().setText("");
// shape4.isTextBox() false-t ad vissza
```

## **Oszlopok hozzáadása egy szövegmezőhöz**

Az Aspose.Slides a [ColumnCount](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) és [ColumnSpacing](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) tulajdonságokat (a [ITextFrameFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ITextFrameFormat) interfész és a [TextFrameFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/TextFrameFormat) osztály részeként) biztosítja, amelyek lehetővé teszik oszlopok hozzáadását a szövegmezőkhöz. Megadhatod a szövegmező oszlopainak számát, valamint a oszlopok közötti távolságot pontokban. 

Ez a Java kód bemutatja a leírt műveletet: 

```java
Presentation pres = new Presentation();
try {
    // Lekéri a prezentáció első diáját
    ISlide slide = pres.getSlides().get_Item(0);

    // Hozzáad egy AutoShape-ot, amelynek típusa Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Szövegkeretet ad a téglalaphoz
    aShape.addTextFrame("All these columns are limited to be within a single text container -- " +
            "you can add or delete text and the new or remaining text automatically adjusts " +
            "itself to flow within the container. You cannot have text flow from one container " +
            "to other though -- we told you PowerPoint's column options for text are limited!");

    // Lekéri a TextFrame szövegformátumát
    ITextFrameFormat format = aShape.getTextFrame().getTextFrameFormat();

    // Megadja az oszlopok számát a TextFrame-ben
    format.setColumnCount(3);

    // Megadja az oszlopok közötti távolságot
    format.setColumnSpacing(10);

    // Mentse a prezentációt
    pres.save("ColumnCount.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Oszlopok hozzáadása egy szövegkerethez**
Az Aspose.Slides for Java a [ColumnCount](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) tulajdonságot (a [ITextFrameFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ITextFrameFormat) interfész részeként) biztosítja, amely lehetővé teszi oszlopok hozzáadását a szövegkeretekhez. Ezzel a tulajdonsággal megadhatod a kívánt oszlopszámot egy szövegkeretben. 

Ez a Java kód megmutatja, hogyan adhatunk hozzá oszlopot egy szövegkeretben:

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

## **Szöveg frissítése**

Az Aspose.Slides lehetővé teszi egy szövegmezőben vagy a teljes prezentációban található szövegek módosítását vagy frissítését. 

Ez a Java kód bemutat egy olyan műveletet, ahol a prezentáció összes szövege frissül vagy megváltozik:

```java
Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) //Ellenőrzi, hogy az alakzat támogatja-e a szövegkeretet (IAutoShape).
            {
                IAutoShape autoShape = (IAutoShape)shape; 
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) //A szövegkeret bekezdésein iterál
                {
                    for (IPortion portion : paragraph.getPortions()) //Iterál a bekezdés minden részén
                    {
                        portion.setText(portion.getText().replace("years", "months")); //Módosítja a szöveget
                        portion.getPortionFormat().setFontBold(NullableBool.True); //Módosítja a formázást
                    }
                }
            }
        }
    }

    //Elmenti a módosított prezentációt
    pres.save("text-changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Szövegmező hozzáadása hiperhivatkozással** 

Beszúrhatsz egy hivatkozást egy szövegmezőbe. Amikor a szövegmezőre kattintanak, a felhasználók a hivatkozás megnyitására lesznek irányítva. 

Egy linket tartalmazó szövegmező hozzáadásához kövesd az alábbi lépéseket:

1. `Presentation` osztály egy példányának létrehozása. 
2. Szerezz hivatkozást az újonnan létrehozott prezentáció első diájára. 
3. `AutoShape` objektum hozzáadása a `ShapeType` `Rectangle` értékre állítva, a dián egy meghatározott pozícióban, és szerezz hivatkozást az újonnan hozzáadott AutoShape objektumra.
4. `TextFrame` hozzáadása az `AutoShape` objektumhoz, amely alapértelmezett szövegként *Aspose TextBox*-t tartalmaz. 
5. Példányosítsd az `IHyperlinkManager` osztályt. 
6. Rendeld hozzá az `IHyperlinkManager` objektumot a [HyperlinkClick](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Shape#getHyperlinkClick--) tulajdonsághoz, amely a `TextFrame` kívánt részéhez van társítva. 
7. Végül írd ki a PPTX fájlt a `Presentation` objektumon keresztül. 

Ez a Java kód – a fenti lépések megvalósítása – megmutatja, hogyan adhatunk szövegmezőt hiperhivatkozással egy diára:

```java
// PPTX-et képviselő Presentation osztály példányosítása
Presentation pres = new Presentation();
try {
    // Lekéri a prezentáció első diáját
    ISlide slide = pres.getSlides().get_Item(0);

    // Hozzáad egy AutoShape objektumot, amelynek típusa Rectangle
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // Átkonvertálja az alakzatot AutoShape-ra
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // Eléri az AutoShape-hoz társított ITextFrame tulajdonságot
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // Szöveget ad a kerethez
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // Beállítja a hiperhivatkozást a részlet szövegéhez
    IHyperlinkManager hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).
            getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");

    // Mentse a PPTX prezentációt
    pres.save("hLink_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Mi a különbség a szövegmező és a szöveghelykitöltő között a mesterdiák használatakor?**

A [placeholder](/slides/hu/java/manage-placeholder/) a [master](https://reference.aspose.com/slides/hu/java/com.aspose.slides/masterslide/) stílusát/pozícióját örökli, és a [layoutok](https://reference.aspose.com/slides/hu/java/com.aspose.slides/layoutslide/) során felülírható, míg egy szabályos szövegmező egy adott dián önálló objektum, és nem változik, amikor layoutot váltasz.

**Hogyan végezhetek tömeges szövegcserét a prezentációban anélkül, hogy a diagramok, táblázatok és SmartArt szövegét megérinteném?**

Korlátozd az iterációt azokra az autoshape-ekre, amelyek szövegkerettel rendelkeznek, és vedd ki a beágyazott objektumokat ([diagramok](https://reference.aspose.com/slides/hu/java/com.aspose.slides/chart/), [táblázatok](https://reference.aspose.com/slides/hu/java/com.aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/hu/java/com.aspose.slides/smartart/)) úgy, hogy a gyűjteményeiket külön járod be, vagy egyszerűen átléped ezeket az objektumtípusokat.