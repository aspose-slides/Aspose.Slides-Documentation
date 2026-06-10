---
title: Bekezdés határolók lekérése prezentációkból Java-ban
linktitle: Bekezdés
type: docs
weight: 60
url: /hu/java/paragraph/
keywords:
- bekezdés határolók
- szövegrész határolók
- bekezdés koordináta
- rész koordináta
- bekezdés méret
- szövegrész méret
- szövegkeret
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Tanulja meg, hogyan lehet lekérni a bekezdés és szövegrész határolókat az Aspose.Slides for Java-ban a PowerPoint-prezentációk szövegpozicionálásának optimalizálásához."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan lehet lekérni a bekezdések és szövegrészek határolóit, méretét és koordinátáit az Aspose.Slides-ben. Bemutatja, hogyan lehet egy bekezdés téglalapját egy `TextFrame`-ben a `getRect()` használatával, hogyan lehet a bekezdés és a rész koordinátáit egy táblázatcellában lévő szövegkeretben lekérni, és kiemeli a fontos részleteket, mint a mértékegységek, a szövegtördelés hatása a határolókra, pixel átváltás, és a hatékony bekezdésformázási értékek.

## **Bekezdés és szövegrész koordinátáinak lekérése egy TextFrame-ben**
Az Aspose.Slides for Java használatával a fejlesztők most már lekérhetik a TextFrame bekezdésgyűjteményében lévő bekezdés téglalapkoordinátáit. Lehetővé teszi továbbá, hogy lekérje a [a rész koordinátáit](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPortion#getCoordinates--) egy bekezdés részgyűjteményében. Ebben a témában egy példán keresztül bemutatjuk, hogyan lehet lekérni a bekezdés téglalapkoordinátáit a rész pozíciójával együtt.

``` java
AutoShape shape = (AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
TextFrame textFrame = (TextFrame)shape.getTextFrame();
for (IParagraph paragraph : textFrame.getParagraphs()){
  for (IPortion portion : paragraph.getPortions()){
    Point2D.Float point = portion.getCoordinates();
  }
}
```

## **Bekezdés téglalapkoordinátáinak lekérése**
A [**getRect()**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IParagraph#getRect--) metódus segítségével a fejlesztők lekérhetik a bekezdés határoló téglalapját.

```java
Presentation pres = new Presentation("HelloWorld.pptx");
try {
    IAutoShape shape = (IAutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITextFrame textFrame = shape.getTextFrame();
    Rectangle2D.Float rect = textFrame.getParagraphs().get_Item(0).getRect();
    System.out.println("X: " + rect.x + " Y: " + rect.y + " Width: " + rect.width + " Height: " + rect.height);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Bekezdés és szövegrész méretének lekérése egy táblázatcellában lévő TextFrame-ben**

A [Portion](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Portion) vagy [Paragraph](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Paragraph) méretének és koordinátáinak lekéréséhez egy táblázatcellában lévő szövegkeretben használhatja az [IPortion.getRect](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IPortion#getRect--) és [IParagraph.getRect](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IParagraph#getRect--) metódusokat.

Ez a mintakód bemutatja a leírt műveletet:

```java
Presentation pres = new Presentation("source.pptx");
try {
    Table tbl = (Table)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ICell cell = tbl.getRows().get_Item(1).get_Item(1);

    double x = tbl.getX() + tbl.getRows().get_Item(1).get_Item(1).getOffsetX();
    double y = tbl.getY() + tbl.getRows().get_Item(1).get_Item(1).getOffsetY();

    for (IParagraph para : cell.getTextFrame().getParagraphs())
    {
        if (para.getText().equals(""))
            continue;

        Rectangle2D.Float rect = para.getRect();
        IAutoShape shape =
                pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle,
                        (float)rect.getX() + (float)x, (float)rect.getY() + (float)y, (float)rect.getWidth(), (float)rect.getHeight());

        shape.getFillFormat().setFillType(FillType.NoFill);
        shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
        shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);

        for (IPortion portion : para.getPortions())
        {
            if (portion.getText().contains("0"))
            {
                rect = portion.getRect();
                shape =
                        pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle,
                                (float)rect.getX() + (float)x, (float)rect.getY() + (float)y, (float)rect.getWidth(), (float)rect.getHeight());

                shape.getFillFormat().setFillType(FillType.NoFill);
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Milyen mértékegységben adják vissza a bekezdés és szövegrészek koordinátáit?**  
Pontokban, ahol 1 hüvelyk = 72 pont. Ez minden koordinátára és méretre vonatkozik a dián.

**A szó tördelése befolyásolja a bekezdés határolóit?**  
Igen. Ha a [wrapping](https://reference.aspose.com/slides/hu/java/com.aspose.slides/textframeformat/#setWrapText-byte-) engedélyezve van a [TextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/textframe/)-ben, a szöveg a terület szélességéhez igazítva tördelődik, ami megváltoztatja a bekezdés tényleges határolóit.

**A bekezdés koordinátái megbízhatóan leképezhetők képpontokra az exportált képen?**  
Igen. Átalakíthatók pontokból képpontokra a következő képlettel: pixels = points × (DPI / 72). Az eredmény a renderelés/exportálás során választott DPI-től függ.

**Hogyan szerezhetem meg a „hatékony” bekezdésformázási paramétereket, figyelembe véve a stílusöröklődést?**  
Használja a [effective paragraph formatting data structure](/slides/hu/java/shape-effective-properties/); ez visszaadja a behúzások, távolságok, tördelés, RTL és egyéb értékek végső összevont értékeit.