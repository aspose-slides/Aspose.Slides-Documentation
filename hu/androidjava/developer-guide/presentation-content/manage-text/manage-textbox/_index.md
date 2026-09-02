---
title: Szövegdobozok kezelése prezentációkban Androidon
linktitle: Szövegdoboz kezelése
type: docs
weight: 20
url: /hu/androidjava/manage-textbox/
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
- Android
- Java
- Aspose.Slides
description: "Az Aspose.Slides for Android via Java lehetővé teszi, hogy egyszerűen hozz létre, szerkessz és klónozz szövegdobozokat a PowerPoint és OpenDocument fájlokban, ezáltal javítva a prezentáció automatizálását."
---
## **Bevezetés**

A diákon lévő szövegek általában szövegdobozokban vagy alakzatokban találhatók. Ezért a diához szöveget hozzáadni egy szövegdobozt kell létrehozni, majd szöveget helyezni a szövegdobozba. Az Aspose.Slides for Android via Java a [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IAutoShape) interfészt biztosítja, amely lehetővé teszi szöveget tartalmazó alakzat hozzáadását.

{{% alert title="Info" color="info" %}}
Az Aspose.Slides emellett a [IShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShape) interfészt is biztosítja, amely lehetővé teszi alakzatok hozzáadását a diákhoz. Azonban nem minden, az `IShape` interfészen keresztül hozzáadott alakzat képes szöveget tartalmazni. Azonban a [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IAutoShape) interfészen keresztül hozzáadott alakzatok szöveget tartalmazhatnak.
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
Ezért, ha egy olyan alakzattal dolgozol, amelyhez szöveget szeretnél hozzáadni, érdemes ellenőrizni és megerősíteni, hogy az `IAutoShape` interfészen keresztül lett átkonvertálva. Csak ekkor tudsz a [TextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/TextFrame) segítségével dolgozni, amely az `IAutoShape` egyik tulajdonsága. Lásd az [Update Text](https://docs.aspose.com/slides/hu/androidjava/manage-textbox/#update-text) szekciót ezen az oldalon.
{{% /alert %}}

## **Szövegdoboz létrehozása a dián**

A szövegdoboz létrehozásához a dián kövesd ezeket a lépéseket:

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.  
2. Szerezz egy referenciát az újonnan létrehozott prezentáció első diájához.  
3. Adj hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IAutoShape) objektumot a [ShapeType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IGeometryShape#setShapeType-int-) `Rectangle` értékkel a dián egy meghatározott pozícióban, és szerezz referenciát az újonnan hozzáadott `IAutoShape` objektumhoz.  
4. Adj egy `TextFrame` tulajdonságot az `IAutoShape` objektumhoz, amely szöveget tartalmaz. Az alábbi példában ezt a szöveget adtuk hozzá: *Aspose TextBox*  
5. Végül írd ki a PPTX fájlt a `Presentation` objektum segítségével.  

Ez a Java kód – a fenti lépések megvalósítása – bemutatja, hogyan lehet szöveget hozzáadni egy diához:

```java
import com.aspose.slides.*;

// Példányosítja a Presentation objektumot
Presentation pres = new Presentation();
try {
    // Lekéri a prezentáció első diáját
    ISlide sld = pres.getSlides().get_Item(0);

    // Hozzáad egy AutoShape-et, amelynek típusa Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Hozzáad egy TextFrame-et a téglalaphoz
    ashp.addTextFrame(" ");

    // Eléri a szövegkeretet
    ITextFrame txtFrame = ashp.getTextFrame();

    // Létrehozza a Paragraph objektumot a szövegkerethez
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Létrehozza a Portion objektumot a bekezdéshez
    IPortion portion = para.getPortions().get_Item(0);

    // Beállítja a szöveget
    portion.setText("Aspose TextBox");

    // Mentés a prezentációt a lemezre
    pres.save("TextBox_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ellenőrizd, hogy egy alakzat szövegdoboz-e**

Az Aspose.Slides a [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) interfész [isTextBox](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/#isTextBox--) metódusát biztosítja, amely lehetővé teszi az alakzatok vizsgálatát és a szövegdobozok azonosítását.

![Szövegdoboz és alakzat](istextbox.png)

Ez a Java kód megmutatja, hogyan ellenőrizheted, hogy egy alakzat szövegdobozként lett-e létrehozva:

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

Fontos megjegyezni, hogy ha csak egy autoshape-et adsz hozzá az [IShapeCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishapecollection/) interfész `addAutoShape` metódusával, az autoshape `isTextBox` metódusa `false` értéket ad vissza. Azonban ha szöveget adsz hozzá az autoshape-hez a `addTextFrame` vagy a `setText` metódussal, akkor az `isTextBox` tulajdonság `true` értéket ad.

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

## **Az a alakzat megtalálása, amelyik a szövegkeretet birtokolja**

Általános szövegfeldolgozó kódban előfordulhat, hogy egy [ITextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/) objektumot kapsz anélkül, hogy tudnád, mely prezentációs objektum tartalmazza. Használd a [ITextFrame.getParentShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/#getParentShape--) metódust, hogy visszafelé navigálj a tulajdonos [IShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/) objektusra.

Egy olyan szövegkeret esetén, amely egy [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) vagy egy másik szöveget tartalmazó alakzat része, a [ITextFrame.getParentShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/#getParentShape--) visszaadja a tulajdonost, míg a [ITextFrame.getParentCell](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/#getParentCell--) `null` értéket ad. Mindkét metódus csak olvasásra szolgáló navigációt biztosít, így meghívásuk nem változtatja meg a tulajdonjogot. Mindig ellenőrizd a visszakapott értéket `null`-ra, mielőtt hozzáférnél az alakzathoz.

A teljes példáért, amely az alakzat- és táblázatcellatulajdonosokat azonosítja, beleértve a SmartArt csomópontokhoz tartozó alakzatokat is, lásd a [Search and Replace Text](/slides/hu/androidjava/search-and-replace-text/) oldalt.

## **Oszlopok hozzáadása szövegdobozhoz**

Az Aspose.Slides a [ColumnCount](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) és a [ColumnSpacing](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) tulajdonságokat (az [ITextFrameFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ITextFrameFormat) interfész és a [TextFrameFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/TextFrameFormat) osztály részeként) biztosítja, amelyek lehetővé teszik oszlopok hozzáadását a szövegdobozokhoz. Megadhatod a szövegdobozban lévő oszlopok számát, valamint beállíthatod az oszlopok közötti távolságot pontban.

Ez a Java kód bemutatja a leírt műveletet:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Lekéri a prezentáció első diáját
    ISlide slide = pres.getSlides().get_Item(0);

    // Hozzáad egy AutoShape-et, amelynek típusa Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Hozzáad egy TextFrame-et a téglalaphoz
    aShape.addTextFrame("All these columns are limited to be within a single text container -- " +
            "you can add or delete text and the new or remaining text automatically adjusts " +
            "itself to flow within the container. You cannot have text flow from one container " +
            "to other though -- we told you PowerPoint's column options for text are limited!");

    // Lekéri a TextFrame szövegformátumát
    ITextFrameFormat format = aShape.getTextFrame().getTextFrameFormat();

    // Megadja a oszlopok számát a TextFrame-ben
    format.setColumnCount(3);

    // Megadja az oszlopok közötti távolságot
    format.setColumnSpacing(10);

    // Mentés a prezentációt
    pres.save("ColumnCount.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Oszlopok hozzáadása szövegkerethez**
Az Aspose.Slides for Android via Java a [ColumnCount](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) tulajdonságot (az [ITextFrameFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ITextFrameFormat) interfész részeként) kínálja, amely lehetővé teszi oszlopok hozzáadását szövegkeretekben. Ezzel a tulajdonsággal megadhatod a kívánt oszlopok számát egy szövegkeretben.

Ez a Java kód megmutatja, hogyan lehet egy oszlopot hozzáadni egy szövegkerethez:

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

## **Szöveg frissítése**

Az Aspose.Slides lehetővé teszi a szövegdobozban vagy a prezentációban található összes szöveg módosítását vagy frissítését.

Ez a Java kód bemutat egy műveletet, amely során a prezentációban lévő összes szöveg frissül vagy módosul:

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
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) //Végig iterál a szövegkeret bekezdésein.
                {
                    for (IPortion portion : paragraph.getPortions()) //Végig iterál a bekezdés minden részén.
                    {
                        portion.setText(portion.getText().replace("years", "months")); //Módosítja a szöveget.
                        portion.getPortionFormat().setFontBold(NullableBool.True); //Módosítja a formázást.
                    }
                }
            }
        }
    }

    //Mentés a módosított prezentáció.
    pres.save("text-changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Szövegdoboz hozzáadása hiperhivatkozással** 

Beszúrhatsz egy hivatkozást egy szövegdobozba. Amikor a szövegdobozt rákattintják, a felhasználók a hivatkozásra navigálnak. 

Egy hivatkozást tartalmazó szövegdoboz hozzáadásához kövesd az alábbi lépéseket:

1. `Presentation` osztály példányát hozd létre.  
2. Szerezz referenciát az újonnan létrehozott prezentáció első diájához.  
3. Adj hozzá egy `AutoShape` objektumot `ShapeType` értékkel `Rectangle` a dián egy meghatározott pozícióban, és szerezz referenciát az újonnan hozzáadott AutoShape objektumhoz.  
4. Adj egy `TextFrame`-et az `AutoShape` objektumhoz, és állítsd be az első rész szövegét. Az alábbi példában ezt a szöveget használtuk: *Aspose.Slides*  
5. Szerezd meg az [IHyperlinkManager](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ihyperlinkmanager/) objektumot a `TextFrame` kívánt részének `PortionFormat`-jéből.  
6. Hívd meg a [setExternalHyperlinkClick](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-) metódust ezen az objektumon, hogy beállítsd a szöveg kattintásakor megnyíló hivatkozást.  
7. Végül írd ki a PPTX fájlt a `Presentation` objektum segítségével. 

Ez a Java kód – a fenti lépések megvalósítása – bemutatja, hogyan adhatunk szövegdobozt hiperhivatkozással egy diára:

```java
import com.aspose.slides.*;

// Létrehozza a Presentation osztály egy példányát, amely egy PPTX-et képvisel
Presentation pres = new Presentation();
try {
    // Lekéri a prezentáció első diáját
    ISlide slide = pres.getSlides().get_Item(0);

    // Hozzáad egy AutoShape objektumot, amelynek típusa Rectangle
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // Átkonvertálja az alakzatot AutoShape-re
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // Eléri az AutoShape-hez tartozó ITextFrame tulajdonságot
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // Szöveget ad a kerethez
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // Beállítja a hiperhivatkozást a rész szövegéhez
    IHyperlinkManager hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).
            getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");

    // Mentés a PPTX prezentációt
    pres.save("hLink_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Mi a különbség a szövegdoboz és a szöveghelykitöltő között a mesterdiák használatakor?**

Egy [placeholder](/slides/hu/androidjava/manage-placeholder/) örökli a stílust/pozíciót a [master](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/masterslide/) diától, és felülírható a [layouts](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/layoutslide/) során, míg egy hagyományos szövegdoboz független objektum egy adott dián, és nem változik, ha elrendezést váltasz.

**Hogyan hajthatok végre tömeges szövegcserét a prezentációban anélkül, hogy a diagramok, táblázatok és SmartArt szövegeit érinteném?**

Korlátozd az iterációt azokra az autoshape-ekre, amelyek rendelkeznek szövegkerettel, és vedd ki a beágyazott objektumokat ([charts](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/chart/), [tables](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/smartart/)) úgy, hogy külön bejárod azok gyűjteményeit, vagy kihagyod ezeket az objektumtípusokat.