---
title: 從 Java 簡報中取得文字片段的邊界
linktitle: 片段邊界
type: docs
weight: 47
url: /zh-hant/java/portion-bounds/
keywords:
- 文字片段邊界
- 文字片段
- 文字部分
- 文字座標
- 文字位置
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Java 從 PowerPoint 簡報中取得文字片段的邊界。"
---
## **概觀**

文字片段表示段落內的特定文字片段，讓您能夠獨立於周圍內容操作該片段。在 Aspose.Slides 中，當您需要取得文字片段的邊界、僅對段落的部分套用格式，或以更細緻的層級控制文字行為時，即可使用段落 (portion)。

本文章說明如何使用 [IPortion.getRect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IPortion#getRect--) 取得段落的邊界矩形，並說明如何使用 [IPortion.getCoordinates](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IPortion#getCoordinates--) 取得段落起始位置的座標。此外，還會介紹常見的段落相關情境，例如對單一文字片段套用超連結、了解格式如何透過段落、文字框與主題繼承解決、以及處理指定字體不存在的情況。

## **取得文字片段的邊界**

使用 [IPortion.getRect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IPortion#getRect--) 取得文字片段的邊界矩形：

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            java.awt.geom.Rectangle2D.Float rectangle = portion.getRect();
            System.out.println("X = " + rectangle.x + "; Y = " + rectangle.y + "; Width = " + rectangle.width + "; Height = " + rectangle.height);
        }
    }
} finally {
    presentation.dispose();
}
```

## **取得文字片段的座標**

使用 [IPortion.getCoordinates](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IPortion#getCoordinates--) 取得文字片段起始位置的座標：

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            java.awt.geom.Point2D.Float point = portion.getCoordinates();
            System.out.println("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**我可以只對單一段落中的部分文字套用超連結嗎？**

是的，您可以[assign a hyperlink](/slides/zh-hant/java/manage-hyperlinks/)到個別的段落；只有該片段可點擊，而不會影響整個段落。

**樣式繼承如何運作：段落會覆寫哪些屬性，哪些會從段落或文字框繼承？**

段落層級的屬性具有最高優先權。如果在[IPortion](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iportion/)上未設定屬性，Aspose.Slides 會從[IParagraph](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraph/)取得；若仍未設定，則會使用[ITextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/)或[theme](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/theme/)的樣式。

**如果段落指定的字體在目標機器或伺服器上不存在，會發生什麼情況？**

會套用[Font substitution rules](/slides/zh-hant/java/font-selection-sequence/)。文字可能會重新排版：度量、斷字與寬度都可能改變，這對精確定位很重要。

**我可以獨立設定段落中特定文字片段的填充透明度或漸層嗎？**

可以，[IPortion](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iportion/)層級的文字顏色、填充與透明度可以與相鄰片段不同。