---
title: Androidon lévő prezentációkból származó bekezdés határok lekérése
linktitle: Bekezdés
type: docs
weight: 60
url: /hu/androidjava/paragraph/
keywords:
- bekezdés határok
- szövegrész határok
- bekezdés koordináta
- rész koordináta
- bekezdés méret
- szövegrész méret
- szövegkeret
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan lehet lekérni a bekezdés és szövegrész határait az Aspose.Slides for Android Java segítségével a PowerPoint prezentációkban a szöveg elhelyezésének optimalizálásához."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet lekérni a bekezdések és szövegrészek határait, méretét és koordinátáit az Aspose.Slides-ben. Megmutatja, hogyan lehet a `TextFrame`-ben egy bekezdés téglalapját lekérni a `getRect()` használatával, hogyan lehet a bekezdés és a rész koordinátáit egy táblázatcellában lévő szövegkeretben lekérni, és kiemeli a fontos részleteket, például a mértékegységeket, a szöveg tördelésének hatását a határokra, a pixellel való átváltást és a tényleges bekezdésformázási értékeket.

## **Bekezdés és rész koordinátáinak lekérése egy TextFrame-ben**
Az Aspose.Slides for Android Java-n keresztül használatával a fejlesztők most már lekérhetik egy bekezdés téglalap koordinátáit a TextFrame bekezdéggyűjteményében. Lehetővé teszi továbbá a [a rész koordinátái](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPortion#getCoordinates--) a bekezdés részgyűjteményében. Ebben a témában egy példán keresztül bemutatjuk, hogyan lehet lekérni egy bekezdés téglalap koordinátáit a rész pozíciójával együtt a bekezdésen belül.

``` java
AutoShape shape = (AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
TextFrame textFrame = (TextFrame)shape.getTextFrame();
for (IParagraph paragraph : textFrame.getParagraphs()){
  for (IPortion portion : paragraph.getPortions()){
    Point2D.Float point = portion.getCoordinates();
  }
}
```

## **Bekezdés téglalap koordinátáinak lekérése**
A [**getRect()**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IParagraph#getRect--) metódus használatával a fejlesztők lekérhetik a bekezdés határtéglalapját.

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

## **Bekezdés és rész méretének lekérése egy táblázatcellában lévő TextFrame-ben**

A [Portion](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Portion) vagy a [Paragraph](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Paragraph) méretének és koordinátáinak lekéréséhez egy táblázatcellában lévő szövegkeretben használhatja az [IPortion.getRect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPortion#getRect--) és az [IParagraph.getRect](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IParagraph#getRect--) metódusokat.

Ez a minta kód demonstrálja a leírt műveletet:

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

## **FAQ**

**Milyen mértékegységben vannak visszaadva a bekezdés és szövegrészek koordinátái?**

Pontokban, ahol 1 hüvelyk = 72 pont. Ez minden koordinátára és méretre vonatkozik a dián.

**A szó tördelése befolyásolja a bekezdés határait?**

Igen. Ha a [tördelés](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-) engedélyezve van a [TextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/textframe/)-ben, a szöveg a terület szélességéhez igazodva törik, ami megváltoztatja a bekezdés tényleges határait.

**A bekezdés koordinátái megbízhatóan leképezhetők képpontokra az exportált képen?**

Igen. A pontok képpontokra való átváltása: képpontok = pontok × (DPI / 72). Az eredmény a renderelés/exportálás során választott DPI-től függ.

**Hogyan lehet megkapni a „hatékony” bekezdésformázási paramétereket, figyelembe véve a stílusöröklődést?**

Használja a [effective paragraph formatting data structure](/slides/hu/androidjava/shape-effective-properties/); ez visszaadja a végső összevont értékeket a behúzásokra, távolságokra, tördelésre, RTL-re és egyebekre.