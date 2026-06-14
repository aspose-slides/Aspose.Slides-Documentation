---
title: 使用 JavaScript 在簡報中管理上標與下標
linktitle: 上標與下標
type: docs
weight: 80
url: /zh-hant/nodejs-java/superscript-and-subscript/
keywords:
- 上標
- 下標
- 加入上標
- 加入下標
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "精通 Aspose.Slides for Node.js 中的上標與下標，透過 Java 提升簡報的專業文字格式，達到最大影響力。"
---
## **概觀**

Aspose.Slides 提供將上標與下標文字整合至您的 PowerPoint（PPT、PPTX）與 OpenDocument（ODP）簡報的功能。無論您是需要突顯化學式、數學方程式，或以腳註方式註解內容，這些特殊的格式選項都有助於保持清晰與精確。本文將教您如何無縫套用上標與下標樣式，確保每張投影片都呈現專業成果。

## **管理上標與下標文字**

您可以在任何段落區段中加入上標與下標文字。若要在 Aspose.Slides 文字方塊中加入上標或下標文字，必須使用[**setEscapement**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/BasePortionFormat#setEscapement-float-) 方法，該方法屬於[PortionFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/PortionFormat) 類別。

此屬性用於取得或設定上標或下標文字（值範圍從 -100%（下標）到 100%（上標））。例如：

- 建立[Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。
- 使用 Index 取得投影片的參考。
- 在投影片上加入一個[AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/AutoShape)，其類型為[Rectangle](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ShapeType#Rectangle)。
- 存取與[AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/AutoShape) 相關聯的[TextFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/TextFrame)。
- 清除現有段落
- 建立一個用於容納上標文字的新段落物件，並將其加入[TextFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/TextFrame) 的[Paragraphs collection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/TextFrame#getParagraphs--) 中。
- 建立新的 Portion 物件
- 將該 Portion 的 Escapement 屬性設定為 0 到 100 之間，以加入上標。（0 表示無上標）
- 為[Portion](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Portion) 設定文字，然後將其加入段落的 portion 集合中。
- 建立一個用於容納下標文字的新段落物件，並將其加入 ITextFrame 的 IParagraphs 集合。
- 建立新的 Portion 物件
- 將該 Portion 的 Escapement 屬性設定為 0 到 -100 之間，以加入下標。（0 表示無下標）
- 為[Portion](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Portion) 設定文字，然後將其加入段落的 portion 集合中。
- 將簡報儲存為 PPTX 檔案。

以下示範上述步驟的實作方式。

```javascript
// 實例化一個代表 PPTX 的 Presentation 類別
var pres = new aspose.slides.Presentation();
try {
    // 取得投影片
    var slide = pres.getSlides().get_Item(0);
    // 建立文字方塊
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 200, 100);
    var textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();
    // 建立上標文字的段落
    var superPar = new aspose.slides.Paragraph();
    // 建立包含普通文字的 Portion
    var portion1 = new aspose.slides.Portion();
    portion1.setText("SlideTitle");
    superPar.getPortions().add(portion1);
    // 建立包含上標文字的 Portion
    var superPortion = new aspose.slides.Portion();
    superPortion.getPortionFormat().setEscapement(30);
    superPortion.setText("TM");
    superPar.getPortions().add(superPortion);
    // 建立下標文字的段落
    var paragraph2 = new aspose.slides.Paragraph();
    // 建立包含普通文字的 Portion
    var portion2 = new aspose.slides.Portion();
    portion2.setText("a");
    paragraph2.getPortions().add(portion2);
    // 建立包含下標文字的 Portion
    var subPortion = new aspose.slides.Portion();
    subPortion.getPortionFormat().setEscapement(-25);
    subPortion.setText("i");
    paragraph2.getPortions().add(subPortion);
    // 將段落新增至文字方塊
    textFrame.getParagraphs().add(superPar);
    textFrame.getParagraphs().add(paragraph2);
    pres.save("formatText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **常見問題**

**匯出為 PDF 或其他格式時，上標與下標會被保留嗎？**

是的，Aspose.Slides 在將簡報匯出為 PDF、PPT/PPTX、影像以及其他支援的格式時，會正確保留上標與下標的格式。這些特殊的格式在所有輸出檔案中皆保持完整。

**上標與下標可以與其他格式樣式（例如粗體或斜體）結合使用嗎？**

是的，Aspose.Slides 允許您在單一 Portion 內混合各種文字樣式。您可以啟用粗體、斜體、底線，並同時透過設定[PortionFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/portionformat/) 中的相應屬性來套用上標或下標。

**上標與下標格式在表格、圖表或 SmartArt 內的文字是否也適用？**

是的，Aspose.Slides 支援在大多數物件內的格式設定，包括表格與圖表元素。使用 SmartArt 時，您須存取相應的元素（例如[SmartArtNode](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/smartartnode/)）及其文字容器，然後以類似方式設定[PortionFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/portionformat/) 的屬性。