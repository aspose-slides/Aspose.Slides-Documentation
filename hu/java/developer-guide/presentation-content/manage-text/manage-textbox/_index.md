---
title: Szövegdobozok kezelése prezentációkban Java használatával
linktitle: Szövegdoboz kezelése
type: docs
weight: 20
url: /hu/java/manage-textbox/
keywords:
- szövegdoboz
- szövegkeret
- szöveg hozzáadása
- szöveg frissítése
- szövegdoboz létrehozása
- szövegdoboz ellenőrzése
- szövegoszlop hozzáadása
- hiperhivatkozás hozzáadása
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Az Aspose.Slides for Java megkönnyíti a szövegdobozok létrehozását, szerkesztését és klónozását PowerPoint és OpenDocument fájlokban, ezáltal javítva a prezentáció automatizálását."
---
## **Bevezetés**

A diákon lévő szövegek általában szövegdobozokban vagy alakzatokban vannak. Ezért egy szöveg hozzáadásához egy diára szövegdobozt kell létrehozni, majd szöveget kell elhelyezni a szövegdobozban. Az Aspose.Slides for Java biztosítja a [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IAutoShape) interfészt, amely lehetővé teszi, hogy szöveget tartalmazó alakzatot adjunk hozzá.

{{% alert title="Info" color="info" %}}
Az Aspose.Slides továbbiakban a [IShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IShape) interfészt is biztosítja, amely lehetővé teszi alakzatok hozzáadását a diákhoz. Azonban nem minden, az `IShape` interfészen keresztül hozzáadott alakzat képes szöveget tárolni. A [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IAutoShape) interfészen keresztül hozzáadott alakzatok viszont tartalmazhatnak szöveget.
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
Ezért, amikor olyan alakzattal dolgozunk, amelyhez szöveget szeretnénk hozzáadni, érdemes ellenőrizni és megerősíteni, hogy az `IAutoShape` interfészen keresztül lett-e átkonvertálva. Csak ekkor tudunk a [TextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/TextFrame) tulajdonsággal dolgozni, amely az `IAutoShape` része. Lásd a [Szöveg frissítése](https://docs.aspose.com/slides/hu/java/manage-textbox/#update-text) szekciót ezen az oldalon. 
{{% /alert %}}

## **Szövegdoboz létrehozása egy dián**

A szövegdoboz létrehozásához egy dián kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból. 
2. Szerezzen referenciát az újonnan létrehozott bemutató első diájához. 
3. Adj hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IAutoShape) objektumot a [ShapeType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IGeometryShape#setShapeType-int-) `Rectangle` értékkel a dia megadott pozíciójába, és szerezze meg az újonnan hozzáadott `IAutoShape` objektum referenciáját. 
4. Adj egy `TextFrame` tulajdonságot az `IAutoShape` objektumhoz, amely szöveget fog tartalmazni. Az alábbi példában ezt a szöveget adtuk hozzá: *Aspose TextBox*
5. Végül írd ki a PPTX fájlt a `Presentation` objektum segítségével. 

Ez a Java kód — az előző lépések megvalósítása — megmutatja, hogyan adhat szöveget egy diához:

```java
import com.aspose.slides.*;

// Példányosítja a Presentation objektumot
Presentation pres = new Presentation();
try {
    // Lekéri a prezentáció első diaját
    ISlide sld = pres.getSlides().get_Item(0);

    // Hozzáad egy AutoShape‑t, típusként Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Hozzáad egy TextFrame‑et a Rectangle-hez
    ashp.addTextFrame(" ");

    // Eléri a szövegkeretet
    ITextFrame txtFrame = ashp.getTextFrame();

    // Létrehozza a Paragraph objektumot a szövegkerethez
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Létrehozza a Portion objektumot a bekezdéshez
    IPortion portion = para.getPortions().get_Item(0);

    // Beállítja a szöveget
    portion.setText("Aspose TextBox");

    // Mentse a prezentációt a lemezen
    pres.save("TextBox_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Szövegdoboz alakzat ellenőrzése**

Az Aspose.Slides a [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) interfészén keresztül elérhető [isTextBox](https://reference.aspose.com/slides/hu/java/com.aspose.slides/autoshape/#isTextBox--) metódust biztosítja, amely lehetővé teszi az alakzatok vizsgálatát és a szövegdobozok azonosítását.

![Szövegdoboz és alakzat](istextbox.png)

Ez a Java kód megmutatja, hogyan ellenőrizheti, hogy egy alakzat szövegdobozként lett-e létrehozva:

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

Vegye figyelembe, hogy ha egyszerűen egy autoshape‑et ad hozzá az `addAutoShape` metódussal a [IShapeCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishapecollection/) interfészből, akkor az autoshape `isTextBox` metódusa `false` értéket ad. Azonban ha szöveget ad hozzá az autoshape-hez az `addTextFrame` vagy a `setText` metódussal, akkor az `isTextBox` tulajdonság `true`‑t ad vissza.

```java
import com.aspose.slides.*;

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

## **Az alakzat megtalálása, amelyik a szövegkeretet birtokolja**

Általános szövegfeldolgozó kódban előfordulhat, hogy egy [ITextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/) objektumot kap, anélkül, hogy tudná, melyik prezentációs objektum tartalmazza. Használja az [ITextFrame.getParentShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/#getParentShape--) metódust a tulajdonos [IShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/) visszakereséséhez.

Egy szövegkeret, amely egy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) vagy más szöveget tartalmazó alakzathoz tartozik, a [ITextFrame.getParentShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/#getParentShape--) módszerrel az alapesetben a tulajdonost adja vissza, míg a [ITextFrame.getParentCell](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/#getParentCell--) `null`‑t ad. Mindkét módszer csak olvasási célú navigációt biztosít, ezért meghívásuk nem módosítja a tulajdonjogot. Mindig ellenőrizze a visszatérő értéket `null`‑ra, mielőtt hozzáférne az alakzathoz.

A szöveg‑keret és táblacell tulajdonosok, valamint a SmartArt‑csomópontokhoz kapcsolódó alakzatok azonosításáról teljes példát a [Szöveg keresése és cseréje](/slides/hu/java/search-and-replace-text/) oldalon talál.

## **Oszlopok hozzáadása egy szövegdobozhoz**

Az Aspose.Slides biztosítja a [ColumnCount](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) és a [ColumnSpacing](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) tulajdonságokat (az [ITextFrameFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ITextFrameFormat) interfész és a [TextFrameFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/TextFrameFormat) osztály részeként), amelyek lehetővé teszik oszlopok hozzáadását a szövegdobozokhoz. Meghatározhatja a szövegdobozban lévő oszlopok számát, valamint a pontokban megadott távolságot az oszlopok között.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Lekéri a prezentáció első diaját
    ISlide slide = pres.getSlides().get_Item(0);

    // Hozzáad egy AutoShape‑t, típusként Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Hozzáad egy TextFrame‑et a Rectangle-hez
    aShape.addTextFrame("All these columns are limited to be within a single text container -- " +
            "you can add or delete text and the new or remaining text automatically adjusts " +
            "itself to flow within the container. You cannot have text flow from one container " +
            "to other though -- we told you PowerPoint's column options for text are limited!");

    // Lekéri a TextFrame szövegformátumát
    ITextFrameFormat format = aShape.getTextFrame().getTextFrameFormat();

    // Megadja a oszlopok számát a TextFrame-ben
    format.setColumnCount(3);

    // Megadja az oszlopok közti távolságot
    format.setColumnSpacing(10);

    // Mentse a prezentációt
    pres.save("ColumnCount.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Oszlopok hozzáadása egy szövegkerethez**

Az Aspose.Slides for Java biztosítja a [ColumnCount](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) tulajdonságot (az [ITextFrameFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ITextFrameFormat) interfész részeként), amely lehetővé teszi oszlopok hozzáadását a szövegkeretekben. Ezzel a tulajdonsággal megadhatja a kívánt oszlopszámot egy szövegkeretben.

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

## **Szöveg frissítése**

Az Aspose.Slides lehetővé teszi a szövegdobozban vagy a teljes prezentációban lévő szövegek módosítását vagy frissítését.

```java
import com.aspose.slides.*;

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
                    for (IPortion portion : paragraph.getPortions()) //Végigiterál a bekezdés minden részletén
                    {
                        portion.setText(portion.getText().replace("years", "months")); //Módosítja a szöveget
                        portion.getPortionFormat().setFontBold(NullableBool.True); //Módosítja a formázást
                    }
                }
            }
        }
    }

    //Mentés a módosított prezentáció
    pres.save("text-changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Szövegdoboz hozzáadása hiperhivatkozással**

Egy szövegdobozba beilleszthet hivatkozást. Amikor a szövegdobozra kattintanak, a felhasználók a hivatkozás megnyitására kerülnek.

A hivatkozást tartalmazó szövegdoboz hozzáadásához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a `Presentation` osztályból. 
2. Szerezzen referenciát az újonnan létrehozott prezentáció első diájához. 
3. Adj hozzá egy `AutoShape` objektumot a `ShapeType` `Rectangle` értékkel a dia megadott pozíciójába, és szerezze meg az újonnan hozzáadott AutoShape objektum referenciáját.
4. Adj egy `TextFrame`‑et az `AutoShape` objektumhoz, amely alapértelmezett szövege a *Aspose TextBox*. 
5. Példányosítsa az `IHyperlinkManager` osztályt. 
6. Rendelje az `IHyperlinkManager` objektumot a [HyperlinkClick](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Shape#getHyperlinkClick--) tulajdonsághoz, amely a `TextFrame` kívánt részéhez van társítva. 
7. Végül írd ki a PPTX fájlt a `Presentation` objektum segítségével. 

```java
import com.aspose.slides.*;

// Példányosít egy Presentation osztályt, amely egy PPTX-et képvisel
Presentation pres = new Presentation();
try {
    // Lekéri a prezentáció első diaját
    ISlide slide = pres.getSlides().get_Item(0);

    // Hozzáad egy AutoShape objektumot, típusként Rectangle
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // Átkonvertálja az alakzatot AutoShape-re
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // Eléri az AutoShape-hez társított ITextFrame tulajdonságot
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // Hozzáad némi szöveget a kerethez
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

## **GYIK**

**Mi a különbség a szövegdoboz és a helykitöltő között, amikor master diákon dolgozunk?**

Egy [helykitöltő](/slides/hu/java/manage-placeholder/) örökli a stílust és a pozíciót a [mester](/slides/hu/java/masterslide/) diáról, és a [elrendezések](/slides/hu/java/layoutslide/) során felülírható, míg egy szabályos szövegdoboz egy önálló objektum egy adott dián, és nem változik, ha az elrendezéseket váltja.

**Hogyan végezhetek tömeges szövegcserét a teljes prezentáción anélkül, hogy a diagramok, táblák és SmartArt szövegét érinteném?**

Korlátozza az iterációt azokra az autoshape‑ekre, amelyek szövegkerettel rendelkeznek, és hagyja ki a beágyazott objektumokat ([diagramok](https://reference.aspose.com/slides/hu/java/com.aspose.slides/chart/), [táblák](https://reference.aspose.com/slides/hu/java/com.aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/hu/java/com.aspose.slides/smartart/)) azzal, hogy a gyűjteményeiket külön-külön járja be, vagy kihagyja ezeket a típusokat.