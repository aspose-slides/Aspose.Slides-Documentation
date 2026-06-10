---
title: Szövegmezők kezelése prezentációkban Androidon
linktitle: Szövegmező kezelése
type: docs
weight: 20
url: /hu/androidjava/manage-textbox/
keywords:
- szövegmező
- szövegkeret
- szöveg hozzáadása
- szöveg frissítése
- szövegmező létrehozása
- szövegmező ellenőrzése
- szövegoszlop hozzáadása
- hiperhivatkozás hozzáadása
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Az Aspose.Slides for Android via Java megkönnyíti a szövegmezők létrehozását, szerkesztését és klónozását PowerPoint és OpenDocument fájlokban, elősegítve a prezentáció automatizálását."
---
## **Bevezetés**

A diákon található szövegek általában szövegmezőkben vagy alakzatokban vannak. Ezért egy szöveg hozzáadásához a diára szövegmezőt kell létrehozni, majd a szövegmezőbe szöveget helyezni. Az Aspose.Slides for Android via Java biztosítja a [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IAutoShape) felületet, amely lehetővé teszi szöveget tartalmazó alakzat hozzáadását.

{{% alert title="Info" color="info" %}}
Az Aspose.Slides emellett biztosítja az [IShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShape) felületet, amely lehetővé teszi alakzatok hozzáadását a diákhoz. Azonban nem minden, a `IShape` felületen keresztül hozzáadott alakzat képes szöveget tartalmazni. Azonban a [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IAutoShape) felületen keresztül hozzáadott alakzatok tartalmazhatnak szöveget.
{{% /alert %}}

{{% alert title="Megjegyzés" color="warning" %}} 
Ezért, ha olyan alakzattal dolgozik, amelyhez szöveget szeretne hozzáadni, érdemes ellenőrizni és megerősíteni, hogy az `IAutoShape` felületen keresztül lett átalakítva. csak ekkor lesz lehetősége a `IAutoShape` alatti [TextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/TextFrame) tulajdonsággal dolgozni. Tekintse meg a [Update Text](https://docs.aspose.com/slides/hu/androidjava/manage-textbox/#update-text) szekciót ezen az oldalon.
{{% /alert %}}

## **Szövegmező létrehozása egy dián**

A szövegmező létrehozásához egy dián kövesse ezeket a lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.  
2. Szerezzen referenciát az újonnan létrehozott prezentáció első diájához.  
3. Adj hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IAutoShape) objektumot, amelynek a [ShapeType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IGeometryShape#setShapeType-int-) értéke `Rectangle`, a megadott pozícióban a dián, és szerezze meg az újonnan hozzáadott `IAutoShape` objektum referenciáját.  
4. Adj egy `TextFrame` tulajdonságot az `IAutoShape` objektumhoz, amely szöveget tartalmaz. Az alábbi példában ezt a szöveget adtuk hozzá: *Aspose TextBox*  
5. Végül írja ki a PPTX fájlt a `Presentation` objektumon keresztül.  

Ez a Java kód – a fenti lépések megvalósítása – megmutatja, hogyan adhat szöveget egy diához:

```java
// Presentation példányosítása
Presentation pres = new Presentation();
try {
    // Az első diát kapja meg a prezentációban
    ISlide sld = pres.getSlides().get_Item(0);

    // AutoShape hozzáadása típus Rectangle beállítással
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // TextFrame hozzáadása a Rectangle-hez
    ashp.addTextFrame(" ");

    // A szövegkeret elérése
    ITextFrame txtFrame = ashp.getTextFrame();

    // Paragraph objektum létrehozása a szövegkerethez
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Portion objektum létrehozása a bekezdéshez
    IPortion portion = para.getPortions().get_Item(0);

    // Szöveg beállítása
    portion.setText("Aspose TextBox");

    // A prezentáció mentése a lemezre
    pres.save("TextBox_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Szövegmező alakzat ellenőrzése**

Az Aspose.Slides a [isTextBox](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/#isTextBox--) metódust biztosítja a [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) felületen, amely lehetővé teszi az alakzatok vizsgálatát és a szövegmezők azonosítását.

![Szövegmező és alakzat](istextbox.png)

Ez a Java kód megmutatja, hogyan ellenőrizhető, hogy egy alakzat szövegmezőként lett-e létrehozva:

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

Vegye figyelembe, hogy ha egyszerűen egy auto-shape‑t ad hozzá a [IShapeCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishapecollection/) felület `addAutoShape` metódusával, az auto-shape `isTextBox` metódusa `false` értéket ad vissza. Azonban ha szöveget ad hozzá az auto-shape‑hez az `addTextFrame` vagy a `setText` metódus segítségével, a `isTextBox` tulajdonság `true` értéket ad vissza.

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
// shape1.isTextBox() false értéket ad vissza
shape1.addTextFrame("shape 1");
// shape1.isTextBox() true értéket ad vissza

IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 110, 100, 40);
// shape2.isTextBox() false értéket ad vissza
shape2.getTextFrame().setText("shape 2");
// shape2.isTextBox() true értéket ad vissza

IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 210, 100, 40);
// shape3.isTextBox() false értéket ad vissza
shape3.addTextFrame("");
// shape3.isTextBox() false értéket ad vissza

IAutoShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 100, 40);
// shape4.isTextBox() false értéket ad vissza
shape4.getTextFrame().setText("");
// shape4.isTextBox() false értéket ad vissza
```

## **Oszlopok hozzáadása egy szövegmezőhöz**

Az Aspose.Slides a [ColumnCount](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) és a [ColumnSpacing](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) tulajdonságokat (az [ITextFrameFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ITextFrameFormat) felületen és a [TextFrameFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/TextFrameFormat) osztályon keresztül) biztosítja, amelyek lehetővé teszik oszlopok hozzáadását a szövegmezőkhöz. Megadhatja a szövegmező oszlopainak számát, és pontban megadhatja az oszlopok közötti távolságot.

```java
Presentation pres = new Presentation();
try {
    // Az első diát kapja meg a prezentációban
    ISlide slide = pres.getSlides().get_Item(0);

    // AutoShape hozzáadása típus Rectangle beállítással
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // TextFrame hozzáadása a Rectangle-hez
    aShape.addTextFrame("All these columns are limited to be within a single text container -- " +
            "you can add or delete text and the new or remaining text automatically adjusts " +
            "itself to flow within the container. You cannot have text flow from one container " +
            "to other though -- we told you PowerPoint's column options for text are limited!");

    // A TextFrame szövegformátumát kapja meg
    ITextFrameFormat format = aShape.getTextFrame().getTextFrameFormat();

    // Megadja a oszlopok számát a TextFrame-ben
    format.setColumnCount(3);

    // Megadja az oszlopok közötti távolságot
    format.setColumnSpacing(10);

    // A prezentáció mentése
    pres.save("ColumnCount.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Oszlopok hozzáadása a Szövegkerethez**
Az Aspose.Slides for Android via Java biztosítja a [ColumnCount](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) tulajdonságot (az [ITextFrameFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ITextFrameFormat) felületen), amely lehetővé teszi oszlopok hozzáadását a szövegkeretekhez. Ezzel a tulajdonsággal megadhatja a kívánt oszlopszámot a szövegkeretben.

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

Az Aspose.Slides lehetővé teszi a szövegmezőben vagy a teljes prezentációban lévő összes szöveg módosítását vagy frissítését.

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
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) //Végigiterál a szövegkeret bekezdésein
                {
                    for (IPortion portion : paragraph.getPortions()) //Végigiterál a bekezdés minden részén
                    {
                        portion.setText(portion.getText().replace("years", "months")); //Módosítja a szöveget
                        portion.getPortionFormat().setFontBold(NullableBool.True); //Módosítja a formázást
                    }
                }
            }
        }
    }

    //Mentés a módosított prezentációt
    pres.save("text-changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Szövegmező hozzáadása hiperhivatkozással** 

Hiperhivatkozást szúrhat be egy szövegmezőbe. Amikor a szövegmezőre kattintanak, a felhasználók a hivatkozás megnyitására lesznek irányítva. 

A hivatkozást tartalmazó szövegmező hozzáadásához kövesse ezeket a lépéseket:

1. Hozzon létre egy példányt a `Presentation` osztályból.  
2. Szerezzen referenciát az újonnan létrehozott prezentáció első diájához.  
3. Adj hozzá egy `AutoShape` objektumot, amelynek a `ShapeType` értéke `Rectangle`, a megadott pozícióban a dián, és szerezze meg az újonnan hozzáadott AutoShape objektum referenciáját.  
4. Adj egy `TextFrame`‑et az `AutoShape` objektumhoz, amely alapértelmezett szövegként a *Aspose TextBox* szöveget tartalmazza.  
5. Hozza létre az `IHyperlinkManager` osztályt.  
6. Rendelje hozzá az `IHyperlinkManager` objektumot a [HyperlinkClick](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Shape#getHyperlinkClick--) tulajdonáshoz, amely a `TextFrame` kívánt részéhez van társítva.  
7. Végül írja ki a PPTX fájlt a `Presentation` objektumon keresztül. 

Ez a Java kód – a fenti lépések megvalósítása – megmutatja, hogyan adhat szövegmezőt hiperhivatkozással egy diához:

```java
// PPTX-et képviselő Presentation osztály példányosítása
Presentation pres = new Presentation();
try {
    // Az első diát kapja meg a prezentációban
    ISlide slide = pres.getSlides().get_Item(0);

    // AutoShape objektum hozzáadása, típus Rectangle beállítással
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // Az alakzat átkonvertálása AutoShape-re
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // Az AutoShape-hez tartozó ITextFrame tulajdonság elérése
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // Szöveg hozzáadása a kerethez
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // A szövegrész hiperhivatkozásának beállítása
    IHyperlinkManager hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).
            getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");

    // A PPTX prezentáció mentése
    pres.save("hLink_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Mi a különbség a szövegmező és a szöveghelyőrző között a mesterdiák használatakor?**

Egy [placeholder](/slides/hu/androidjava/manage-placeholder/) örökli a stílust/pozíciót a [master](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/masterslide/) diától, és felülírható a [layouts](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/layoutslide/) diáknál, míg egy szabályos szövegmező egy önálló objektum egy adott dián, és nem változik, ha a layoutot megváltoztatja.

**Hogyan végezhetek tömeges szövegcsere műveletet a prezentáción anélkül, hogy a diagramok, táblázatok és SmartArt szövegét módosítanám?**

Korlátozza az iterációt azokra az auto-shape‑kre, amelyek rendelkeznek szövegkerettel, és hagyja ki a beágyazott objektumokat ([charts](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/chart/), [tables](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/smartart/)) azzal, hogy külön gyűjteményeken iterál, vagy egyszerűen kihagyja ezeket az objektumtípusokat.