---
title: 在 Android 上管理簡報中的文字片段
linktitle: 文字片段
type: docs
weight: 70
url: /zh-hant/androidjava/portion/
keywords:
- 文字片段
- 文字部分
- 文字座標
- 文字位置
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Android 於 Java 環境中管理 PowerPoint 簡報的文字片段，以提升效能與客製化程度。"
---
## **簡介**

文字片段（Portion）代表段落中一個特定的文字片段，讓您可以獨立於周圍內容對該片段進行操作。在 Aspose.Slides 中，當您需要取得文字片段的位置、僅對段落的部分文字套用格式，或在更細緻的層面控制文字行為時，可使用 portion。

## **取得文字片段的座標**
[**getCoordinates()**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IPortion#getCoordinates--) 方法已加入至 [IPortion](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iportion/) 與 [Portion](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/portion/) 類別，可取得該片段起始位置的座標。

```java
// 實例化表示 PPTX 的 Presentation 類別
Presentation pres = new Presentation();
try {
    // 重新塑造簡報的內容
    IAutoShape shape = (IAutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    ITextFrame textFrame = (ITextFrame) shape.getTextFrame();
    
    for (IParagraph paragraph : textFrame.getParagraphs()) 
    {
        for (IPortion portion : paragraph.getPortions()) 
        {
            Point2D.Float point = portion.getCoordinates();
            System.out.println("X: " + point.x + " Y: " + point.y);
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **常見問題**

**我可以只對單一段落中的部分文字套用超連結嗎？**

是的，您可以將[指派超連結](/slides/zh-hant/androidjava/manage-hyperlinks/)給單獨的文字片段；只有該片段可點擊，而不會影響整個段落。

**樣式繼承如何運作：Portion 會覆寫什麼，哪些會從 Paragraph/TextFrame 繼承？**

Portion 級別的屬性具有最高優先權。如果屬性未在[Portion](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/portion/)上設定，系統會從[Paragraph](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/paragraph/)取得；若該處亦未設定，則會從[TextFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/textframe/)或[theme](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/theme/)樣式繼承。

**如果在目標機器/伺服器上缺少 Portion 指定的字型，會發生什麼情況？**

[字型替代規則](/slides/zh-hant/androidjava/font-selection-sequence/) 會被套用。文字可能重新換行：度量、斷字與寬度都可能改變，這會影響精確定位。

**我可以為特定 Portion 設定文字填充透明度或漸層，而不影響段落其他部份嗎？**

是的，於[Portion](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/portion/)層級的文字顏色、填充與透明度可以與相鄰的片段不同。