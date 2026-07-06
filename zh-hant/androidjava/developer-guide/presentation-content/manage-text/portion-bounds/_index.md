---
title: 在 Android 上從簡報取得文字區段邊界
linktitle: 區段邊界
type: docs
weight: 47
url: /zh-hant/androidjava/portion-bounds/
keywords:
- 文字區段邊界
- 文字區段
- 文字部分
- 文字座標
- 文字位置
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Android (Java) 在 PowerPoint 簡報中取得文字區段的邊界。"
---
## **概觀**

文字區段代表段落內的特定文字片段，並讓您能夠獨立於周圍內容處理該片段。在 Aspose.Slides 中，區段可用於需要取得文字片段的邊界、僅對段落的一部分套用格式，或在更細緻的層面控制文字行為的情況。

本文說明如何使用[IPortion.getRect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IPortion#getRect--)取得區段的邊界矩形。也說明如何使用[IPortion.getCoordinates](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IPortion#getCoordinates--)取得區段起始點的座標。此外，還強調了常見的區段相關情境，例如對單一文字片段套用超連結、了解格式如何透過區段、段落、文字框與主題繼承而決定，以及處理指定字型不存在的情況。

## **取得文字區段的邊界**

使用[IPortion.getRect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IPortion#getRect--)取得文字區段的邊界矩形：

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            android.graphics.RectF rectangle = portion.getRect();
            System.out.println("X = " + rectangle.left + "; Y = " + rectangle.top + "; Width = " + rectangle.width() + "; Height = " + rectangle.height());
        }
    }
} finally {
    presentation.dispose();
}
```

## **取得文字區段的座標**

使用[IPortion.getCoordinates](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IPortion#getCoordinates--)取得文字區段起始點的座標：

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            PointF point = portion.getCoordinates();
            System.out.println("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **常見問題**

**我可以只對單一段落中的部分文字套用超連結嗎？**

可以，您可以[分配超連結](/slides/zh-hant/androidjava/manage-hyperlinks/)給單獨的區段；只有該片段可點擊，而不是整段文字。

**樣式繼承如何運作：區段會覆寫哪些屬性，哪些會從段落或文字框取得？**

區段層級的屬性具有最高優先權。如果在[IPortion](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iportion/)上未設定屬性，Aspose.Slides 會從[IParagraph](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iparagraph/)取得。若仍未設定，則會使用[ITextFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextframe/)或[theme](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/theme/)的樣式。

**如果區段指定的字型在目標機器或伺服器上不存在，會發生什麼情況？**

會套用[字型替代規則](/slides/zh-hant/androidjava/font-selection-sequence/)。文字可能會重新換行：度量、斷字與寬度皆可能改變，這對精確定位很重要。

**我可以為區段設定獨立於段落其餘部分的文字填色透明度或漸層嗎？**

可以，於[IPortion](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iportion/)層級的文字顏色、填充與透明度可以與相鄰片段不同。