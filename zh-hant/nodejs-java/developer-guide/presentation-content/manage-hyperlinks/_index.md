---
title: 在 JavaScript 中管理簡報超連結
linktitle: 管理超連結
type: docs
weight: 20
url: /zh-hant/nodejs-java/manage-hyperlinks/
keywords:
- 新增 URL
- 新增超連結
- 建立超連結
- 格式化超連結
- 移除超連結
- 更新超連結
- 文字超連結
- 投影片超連結
- 圖形超連結
- 影像超連結
- 影片超連結
- 可變超連結
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js 輕鬆管理 PowerPoint 與 OpenDocument 簡報中的超連結——在幾分鐘內提升互動性與工作流程。"
---
## **簡介**

超連結是對某個物件、資料或位置的參照。以下是在 PowerPoint 簡報中常見的超連結：

* 文字、形狀或媒體中的網站連結
* 投影片連結

Aspose.Slides for Node.js via Java 讓您能在簡報中執行多種與超連結相關的任務。

{{% alert color="primary" %}} 
您可能想看看 Aspose 簡易的[免費線上 PowerPoint 編輯器](https://products.aspose.app/slides/zh-hant/editor)。
{{% /alert %}} 

## **新增 URL 超連結**

### **將 URL 超連結新增至文字**

此 JavaScript 程式碼示範如何將網站超連結新增至文字：

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var shape1 = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50, false);
    shape1.addTextFrame("Aspose: File Format APIs");
    var portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    portionFormat.setFontHeight(32);
    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

### **將 URL 超連結新增至圖形或框架**

此 JavaScript 範例程式碼示範如何將網站超連結新增至圖形：

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50);
    shape.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    shape.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **將 URL 超連結新增至媒體**

Aspose.Slides 允許您將超連結新增至影像、音訊與視訊檔案。

此範例程式碼示範如何將超連結新增至**影像**：

```javascript
var pres = new aspose.slides.Presentation();
try {
    // 新增影像至簡報
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(picture);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // 在投影片 1 上建立圖片框架，基於先前新增的影像
    var pictureFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pictureFrame.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    pictureFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

此範例程式碼示範如何將超連結新增至**音訊檔案**：

```javascript
var pres = new aspose.slides.Presentation();
try {
    var audio = pres.getAudios().addAudio(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "audio.mp3")));
    var audioFrame = pres.getSlides().get_Item(0).getShapes().addAudioFrameEmbedded(10, 10, 100, 100, audio);
    audioFrame.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    audioFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

此範例程式碼示範如何將超連結新增至**視訊**：

```javascript
var pres = new aspose.slides.Presentation();
try {
    var video = pres.getVideos().addVideo(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "video.avi")));
    var videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video);
    videoFrame.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    videoFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{%  alert  title="Tip"  color="primary"  %}} 
您可能想看看 *[管理 OLE](/slides/zh-hant/nodejs-java/manage-ole/)*。
{{% /alert %}}

## **使用超連結建立目錄**

由於超連結允許您新增對物件或位置的參照，您可以利用它們建立目錄。

此範例程式碼示範如何使用超連結建立目錄：

```javascript
var pres = new aspose.slides.Presentation();
try {
    var firstSlide = pres.getSlides().get_Item(0);
    var secondSlide = pres.getSlides().addEmptySlide(firstSlide.getLayoutSlide());
    var contentTable = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 300, 100);
    contentTable.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    contentTable.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    contentTable.getTextFrame().getParagraphs().clear();
    var paragraph = new aspose.slides.Paragraph();
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    paragraph.setText("Title of slide 2 .......... ");
    var linkPortion = new aspose.slides.Portion();
    linkPortion.setText("Page 2");
    linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);
    paragraph.getPortions().add(linkPortion);
    contentTable.getTextFrame().getParagraphs().add(paragraph);
    pres.save("link_to_slide.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **格式化超連結**

### **色彩**

使用 [Hyperlink](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Hyperlink) 類別中的 [setColorSource](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Hyperlink#setColorSource-int-) 方法，您可以設定超連結的顏色，亦可取得超連結的顏色資訊。此功能首次於 PowerPoint 2019 中推出，因而此屬性的變更不適用於較舊的 PowerPoint 版本。

此範例程式碼示範在同一投影片中加入不同顏色的超連結的操作：

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 450, 50, false);
    shape1.addTextFrame("This is a sample of colored hyperlink.");
    var portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setColorSource(aspose.slides.HyperlinkColorSource.PortionFormat);
    portionFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portionFormat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    var shape2 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 450, 50, false);
    shape2.addTextFrame("This is a sample of usual hyperlink.");
    shape2.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    pres.save("presentation-out-hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **移除簡報中的超連結**

### **從文字移除超連結**

此 JavaScript 程式碼示範如何從簡報投影片中的文字移除超連結：

```javascript
var pres = new aspose.slides.Presentation("text.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let slide = pres.getSlides().get_Item(i);
        for (let j = 0; j < slide.getShapes().size(); j++) {
            let shape = slide.getShapes().get_Item(j);
            // 檢查形狀是否支援文字框 (IAutoShape)。
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                var autoShape = shape;
                // 遍歷文字框中的段落
                for (let i1 = 0; i1 < autoShape.getTextFrame().getParagraphs().getCount(); i1++) {
                    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(i1);
                    // 遍歷段落中的每個文字區段
                    for (let j1 = 0; j1 < paragraph.getPortions().getCount(); j1++) {
                        let portion = paragraph.getPortions().get_Item(j1)
                        portion.setText(portion.getText().replace("years", "months"));// 變更文字
                        portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));// 變更格式
                    }
                }
            }
        }
    }
    // 儲存已修改的簡報
    pres.save("text-changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **從圖形或框架移除超連結**

此 JavaScript 程式碼示範如何從簡報投影片中的圖形移除超連結：

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        shape.getHyperlinkManager().removeHyperlinkClick();
    }
    pres.save("pres-removed-hyperlinks.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **可變超連結**

[Hyperlink](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Hyperlink) 類別是可變的。使用此類別，您可以變更以下屬性的值：

- [Hyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Hyperlink#setTargetFrame-java.lang.String-)
- [Hyperlink.setTooltip(String value)](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Hyperlink#setTooltip-java.lang.String-)
- [Hyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Hyperlink#setHistory-boolean-)
- [Hyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Hyperlink#setHighlightClick-boolean-)
- [Hyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Hyperlink#setStopSoundOnClick-boolean-)

此程式碼片段示範如何將超連結新增至投影片，並在之後編輯其提示文字：

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50, false);
    shape1.addTextFrame("Aspose: File Format APIs");
    var portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    portionFormat.setFontHeight(32);
    pres.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **IHyperlinkQueries 支援的屬性**

您可以從簡報、投影片或定義了超連結的文字存取 [HyperlinkQueries](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/HyperlinkQueries)。

- [Presentation.getHyperlinkQueries()](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation#getHyperlinkQueries--)
- [BaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/BaseSlide#getHyperlinkQueries--)
- [TextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/TextFrame#getHyperlinkQueries--)

[HyperlinkQueries](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/HyperlinkQueries) 類別支援以下方法與屬性：

- [HyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkClicks--)
- [HyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkMouseOvers--)
- [HyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks--)
- [HyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks--)

## **FAQ**

**如何僅僅導向投影片之外，建立導向「區段」或區段第一張投影片的內部導覽？**

PowerPoint 中的區段是投影片的分組；導覽在技術上仍指向特定投影片。若要「導向區段」，通常會連結至該區段的第一張投影片。

**我能將超連結附加到母版投影片元素，使其在所有投影片上均可使用嗎？**

可以。母版投影片與版面配置元素支援超連結。這類連結會出現在子投影片上，且在投影片放映時可點擊。

**當匯出為 PDF、HTML、影像或影片時，超連結會被保留嗎？**

在 [PDF](/slides/zh-hant/nodejs-java/convert-powerpoint-to-pdf/) 和 [HTML](/slides/zh-hant/nodejs-java/convert-powerpoint-to-html/) 中，會保留連結，一般而言會保留下來。匯出成 [影像](/slides/zh-hant/nodejs-java/convert-powerpoint-to-png/) 與 [影片](/slides/zh-hant/nodejs-java/convert-powerpoint-to-video/) 時，因為這些格式的特性（點陣框架/影片不支援超連結），點擊功能將不會保留。