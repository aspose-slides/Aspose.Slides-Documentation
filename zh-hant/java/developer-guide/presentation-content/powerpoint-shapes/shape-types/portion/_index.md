---
title: 使用 Java 在簡報中管理文字段落
linktitle: 文字段落
type: docs
weight: 70
url: /zh-hant/java/portion/
keywords:
- 文字段落
- 文字片段
- 文字座標
- 文字位置
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Java 在 PowerPoint 簡報中管理文字段落，以提升效能和自訂能力。"
---
## **概述**

文字段落表示段落內的特定文字片段，讓您能夠獨立於周圍內容操作該片段。 在 Aspose.Slides 中，當您需要取得文字片段的位置、僅對段落的一部分套用格式，或在更細緻的層面控制文字行為時，可使用段落。

本文說明如何使用 `getCoordinates()` 方法取得段落開頭的座標。 同時也闡述常見的段落相關情境，例如將超連結套用於單一文字片段、了解格式如何透過段落、段落（paragraph）、文字框（text frame）與主題的繼承機制解析，以及處理指定字型不存在的情況。 此外，還指出同一段落內的個別段落可以設定不同的文字填充、顏色與透明度。

## **取得文字段落的座標**
[**getCoordinates()**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IPortion#getCoordinates--) 方法已新增至 [IPortion](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iportion/) 與 [Portion](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/portion/) 類別，可用於取得段落開頭的座標。

```java
// 實例化代表 PPTX 的 Presentation 類別
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

是的，您可以將[指派超連結](/slides/zh-hant/java/manage-hyperlinks/)給個別段落；只有該片段可點擊，整段文字不會被套用。

**樣式繼承如何運作：段落會覆寫哪些屬性，哪些會從段落（Paragraph）/文字框（TextFrame）繼承？**

段落層級的屬性具有最高優先權。若屬性未在[Portion](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/portion/)上設定，系統會從[Paragraph](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/paragraph/)取得；若仍未設定，則會從[TextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/textframe/)或[theme](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/theme/)樣式繼承。

**如果在目標機器/伺服器上缺少段落指定的字型，會發生什麼情況？**

[字型替代規則](/slides/zh-hant/java/font-selection-sequence/)會生效。文字可能會重新排版：度量、斷字與寬度都可能改變，這對精確定位非常重要。

**我能為段落設定特定的文字填充透明度或漸層，而不影響同段落的其他文字嗎？**

可以，於[Portion](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/portion/)層級的文字顏色、填充與透明度可以與相鄰的片段不同。